// Decompiled with JetBrains decompiler
// Type: arc.net.Server
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util.async;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.nio;
using java.nio.channels;
using java.nio.channels.spi;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace arc.net
{
  [Implements(new string[] {"arc.net.EndPoint"})]
  public class Server : Object, EndPoint, Runnable
  {
    [Modifiers]
    private NetSerializer serializer;
    [Modifiers]
    private int writeBufferSize;
    [Modifiers]
    private int objectBufferSize;
    [Modifiers]
    private Selector selector;
    private int emptySelects;
    private ServerSocketChannel serverChannel;
    private UdpConnection udp;
    private Connection[] connections;
    [Signature("Larc/struct/IntMap<Larc/net/Connection;>;")]
    private IntMap pendingConnections;
    internal NetListener[] listeners;
    private object listenerLock;
    private int nextConnectionID;
    private volatile bool shutdown;
    [Modifiers]
    private object updateLock;
    private Thread updateThread;
    private int multicastPort;
    protected internal InetAddress multicastGroup;
    internal Server.DiscoveryReceiver __\u003C\u003EdiscoveryReceiver;
    protected internal ServerDiscoveryHandler discoveryHandler;
    private NetListener dispatchListener;

    [LineNumberTable(new byte[] {41, 232, 0, 108, 107, 108, 107, 135, 139, 235, 69, 236, 116, 103, 103, 135, 176, 189, 2, 97, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Server(int writeBufferSize, int objectBufferSize, NetSerializer serializer)
    {
      Server server = this;
      this.connections = new Connection[0];
      this.pendingConnections = new IntMap();
      this.listeners = new NetListener[0];
      this.listenerLock = (object) new Object();
      this.nextConnectionID = 1;
      this.updateLock = (object) new Object();
      this.multicastPort = 21010;
      this.dispatchListener = (NetListener) new Server.\u0031(this);
      this.writeBufferSize = writeBufferSize;
      this.objectBufferSize = objectBufferSize;
      this.serializer = serializer;
      this.discoveryHandler = (ServerDiscoveryHandler) new Server.__\u003C\u003EAnon0();
      IOException ioException1;
      try
      {
        this.selector = Selector.open();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException("Error opening the selector.", (Exception) ioException2);
    }

    [LineNumberTable(new byte[] {56, 135, 190, 2, 97, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMulticast(string group, int multicastPort)
    {
      this.multicastPort = multicastPort;
      IOException ioException;
      try
      {
        this.multicastGroup = InetAddress.getByName(group);
        return;
      }
      catch (IOException ex)
      {
        ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      Throwable.instancehelper_printStackTrace((Exception) ioException);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDiscoveryHandler(ServerDiscoveryHandler newDiscoveryHandler) => this.discoveryHandler = newDiscoveryHandler;

    [LineNumberTable(new byte[] {161, 126, 99, 112, 109, 103, 99, 102, 107, 8, 166, 106, 101, 107, 104, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addListener(NetListener listener)
    {
      if (listener == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("listener cannot be null.");
      }
      object listenerLock;
      System.Threading.Monitor.Enter(listenerLock = this.listenerLock);
      // ISSUE: fault handler
      try
      {
        NetListener[] listeners = this.listeners;
        int length = listeners.Length;
        for (int index = 0; index < length; ++index)
        {
          if (object.ReferenceEquals((object) listener, (object) listeners[index]))
          {
            System.Threading.Monitor.Exit(listenerLock);
            return;
          }
        }
        NetListener[] netListenerArray = new NetListener[length + 1];
        netListenerArray[0] = listener;
        ByteCodeHelper.arraycopy((object) listeners, 0, (object) netListenerArray, 1, length);
        this.listeners = netListenerArray;
        System.Threading.Monitor.Exit(listenerLock);
      }
      __fault
      {
        System.Threading.Monitor.Exit(listenerLock);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {82, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind(int tcpPort, int udpPort) => this.bind(new InetSocketAddress(tcpPort), new InetSocketAddress(udpPort));

    [LineNumberTable(new byte[] {160, 237, 110, 138, 182, 2, 97, 102, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void run()
    {
      this.shutdown = false;
      Thread.MemoryBarrier();
      while (!this.shutdown)
      {
        try
        {
          this.update(250);
          continue;
        }
        catch (IOException ex)
        {
        }
        this.close();
      }
    }

    [LineNumberTable(new byte[] {160, 252, 106, 97, 110, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop()
    {
      if (this.shutdown)
        return;
      this.shutdown = true;
      Thread.MemoryBarrier();
      this.close();
    }

    [LineNumberTable(new byte[] {161, 54, 118, 104, 151, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void removeConnection([In] Connection obj0)
    {
      ArrayList.__\u003Cclinit\u003E();
      ArrayList arrayList = new ArrayList((Collection) Arrays.asList((object[]) this.connections));
      arrayList.remove((object) obj0);
      this.connections = (Connection[]) arrayList.toArray((object[]) new Connection[0]);
      this.pendingConnections.remove(obj0.id);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {89, 102, 109, 140, 118, 113, 109, 148, 99, 183, 178, 121, 114, 250, 69, 242, 61, 97, 102, 142, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind(InetSocketAddress tcpPort, InetSocketAddress udpPort)
    {
      this.close();
      object updateLock;
      System.Threading.Monitor.Enter(updateLock = this.updateLock);
      IOException ioException1;
      // ISSUE: fault handler
      try
      {
        this.selector.wakeup();
        try
        {
          this.serverChannel = this.selector.provider().openServerSocketChannel();
          this.serverChannel.socket().bind((SocketAddress) tcpPort);
          ((AbstractSelectableChannel) this.serverChannel).configureBlocking(false);
          ((SelectableChannel) this.serverChannel).register(this.selector, 16);
          if (udpPort != null)
          {
            this.udp = new UdpConnection(this.serializer, this.objectBufferSize);
            this.udp.bind(this.selector, udpPort);
          }
          if (this.multicastGroup != null)
          {
            if (udpPort != null)
            {
              if (this.multicastPort == udpPort.getPort())
                goto label_13;
            }
            this.__\u003C\u003EdiscoveryReceiver = new Server.DiscoveryReceiver(this, this.multicastPort);
            this.__\u003C\u003EdiscoveryReceiver.start();
            goto label_13;
          }
          else
            goto label_13;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
      }
      __fault
      {
        System.Threading.Monitor.Exit(updateLock);
      }
      IOException ioException2 = ioException1;
      // ISSUE: fault handler
      try
      {
        IOException ioException3 = ioException2;
        this.close();
        throw Throwable.__\u003Cunmap\u003E((Exception) ioException3);
      }
      __fault
      {
        System.Threading.Monitor.Exit(updateLock);
      }
label_13:
      // ISSUE: fault handler
      try
      {
        System.Threading.Monitor.Exit(updateLock);
      }
      __fault
      {
        System.Threading.Monitor.Exit(updateLock);
      }
    }

    [LineNumberTable(new byte[] {161, 164, 103, 105, 45, 134, 140, 103, 131, 145, 34, 129, 167, 104, 107, 167, 104, 100, 103, 167, 174, 151, 140, 151, 34, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      Connection[] connections = this.connections;
      int index = 0;
      for (int length = connections.Length; index < length; ++index)
        connections[index].close(DcReason.__\u003C\u003Eclosed);
      this.connections = new Connection[0];
      ServerSocketChannel serverChannel = this.serverChannel;
      if (serverChannel != null)
      {
        try
        {
          ((AbstractInterruptibleChannel) serverChannel).close();
          goto label_7;
        }
        catch (IOException ex)
        {
        }
label_7:
        this.serverChannel = (ServerSocketChannel) null;
      }
      if (this.__\u003C\u003EdiscoveryReceiver != null)
      {
        this.__\u003C\u003EdiscoveryReceiver.close();
        this.__\u003C\u003EdiscoveryReceiver = (Server.DiscoveryReceiver) null;
      }
      UdpConnection udp = this.udp;
      if (udp != null)
      {
        udp.close();
        this.udp = (UdpConnection) null;
      }
      object updateLock;
      System.Threading.Monitor.Enter(updateLock = this.updateLock);
      // ISSUE: fault handler
      try
      {
        System.Threading.Monitor.Exit(updateLock);
      }
      __fault
      {
        System.Threading.Monitor.Exit(updateLock);
      }
      this.selector.wakeup();
      try
      {
        this.selector.selectNow();
      }
      catch (IOException ex)
      {
      }
    }

    [LineNumberTable(new byte[] {160, 227, 102, 103, 105, 101, 111, 237, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void keepAlive()
    {
      long num = java.lang.System.currentTimeMillis();
      Connection[] connections = this.connections;
      int index = 0;
      for (int length = connections.Length; index < length; ++index)
      {
        Connection connection = connections[index];
        if (connection.tcp.needsKeepAlive(num))
          connection.sendTCP((object) FrameworkMessage.keepAlive);
      }
    }

    [LineNumberTable(new byte[] {161, 3, 103, 152, 103, 103, 99, 135, 147, 136, 119, 105, 103, 104, 103, 140, 99, 137, 143, 103, 105, 137, 99, 177, 2, 97, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void acceptOperation([In] SocketChannel obj0)
    {
      Connection connection = this.newConnection();
      connection.initialize(this.serializer, this.writeBufferSize, this.objectBufferSize);
      connection.endPoint = (EndPoint) this;
      UdpConnection udp = this.udp;
      if (udp != null)
        connection.udp = udp;
      try
      {
        connection.tcp.accept(this.selector, obj0).attach((object) connection);
        Server server1 = this;
        int nextConnectionId = server1.nextConnectionID;
        Server server2 = server1;
        int num = nextConnectionId;
        server2.nextConnectionID = nextConnectionId + 1;
        int key = num;
        if (this.nextConnectionID == -1)
          this.nextConnectionID = 1;
        connection.id = key;
        connection.setConnected(true);
        connection.addListener(this.dispatchListener);
        if (udp == null)
          this.addConnection(connection);
        else
          this.pendingConnections.put(key, (object) connection);
        connection.sendTCP((object) new FrameworkMessage.RegisterTCP()
        {
          connectionID = key
        });
        if (udp != null)
          return;
        connection.notifyConnected();
        return;
      }
      catch (IOException ex)
      {
      }
      connection.close(DcReason.__\u003C\u003Eerror);
    }

    [LineNumberTable(new byte[] {161, 47, 111, 100, 117, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addConnection([In] Connection obj0)
    {
      Connection[] connectionArray = new Connection[this.connections.Length + 1];
      connectionArray[0] = obj0;
      ByteCodeHelper.arraycopy((object) this.connections, 0, (object) connectionArray, 1, this.connections.Length);
      this.connections = connectionArray;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {124, 107, 173, 117, 134, 100, 144, 140, 99, 110, 109, 167, 136, 155, 34, 129, 133, 103, 109, 106, 104, 127, 4, 102, 110, 103, 142, 137, 132, 109, 127, 1, 133, 167, 110, 100, 98, 105, 218, 255, 28, 61, 98, 127, 8, 191, 56, 135, 188, 31, 6, 98, 191, 56, 165, 105, 104, 114, 130, 105, 100, 186, 31, 16, 98, 157, 197, 100, 120, 194, 219, 255, 14, 61, 98, 111, 151, 100, 133, 104, 121, 112, 100, 226, 61, 232, 73, 217, 255, 13, 61, 98, 127, 24, 183, 105, 201, 110, 104, 108, 100, 127, 11, 105, 104, 109, 114, 130, 130, 137, 159, 9, 63, 16, 129, 197, 100, 117, 226, 71, 252, 59, 97, 100, 142, 154, 101, 151, 102, 104, 113, 103, 111, 142, 111, 141, 105, 231, 55, 235, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(int timeout)
    {
      this.updateThread = Thread.currentThread();
      object updateLock;
      System.Threading.Monitor.Enter(updateLock = this.updateLock);
      // ISSUE: fault handler
      try
      {
        System.Threading.Monitor.Exit(updateLock);
      }
      __fault
      {
        System.Threading.Monitor.Exit(updateLock);
      }
      long num1 = java.lang.System.currentTimeMillis();
      if ((timeout <= 0 ? this.selector.selectNow() : this.selector.select((long) timeout)) == 0)
      {
        ++this.emptySelects;
        if (this.emptySelects == 100)
        {
          this.emptySelects = 0;
          long num2 = java.lang.System.currentTimeMillis() - num1;
          try
          {
            if (num2 < 25L)
            {
              Thread.sleep(25L - num2);
              goto label_134;
            }
            else
              goto label_134;
          }
          catch (InterruptedException ex)
          {
          }
        }
      }
      else
      {
        this.emptySelects = 0;
        Set set1 = this.selector.selectedKeys();
        Set set2;
        System.Threading.Monitor.Enter((object) (set2 = set1));
        UdpConnection udp;
        Iterator iterator;
        // ISSUE: fault handler
        try
        {
          udp = this.udp;
          iterator = set1.iterator();
        }
        __fault
        {
          System.Threading.Monitor.Exit((object) set2);
        }
        while (true)
        {
          SelectionKey selectionKey;
          Connection connection1;
          int num2;
          IOException ioException1;
          ArcNetException arcNetException1;
          // ISSUE: fault handler
          try
          {
            if (iterator.hasNext())
            {
              this.keepAlive();
              selectionKey = (SelectionKey) iterator.next();
              iterator.remove();
              connection1 = (Connection) selectionKey.attachment();
              try
              {
                num2 = selectionKey.readyOps();
                if (connection1 != null)
                {
                  if (udp != null)
                  {
                    if (connection1.udpRemoteAddress == null)
                    {
                      connection1.close(DcReason.__\u003C\u003Eerror);
                      continue;
                    }
                  }
                }
                else
                  goto label_57;
              }
              catch (CancelledKeyException ex)
              {
                goto label_27;
              }
              try
              {
                if ((num2 & 1) == 1)
                {
                  try
                  {
                    try
                    {
                      while (true)
                      {
                        object obj = connection1.tcp.readObject();
                        if (obj != null)
                          connection1.notifyReceived(obj);
                        else
                          goto label_41;
                      }
                    }
                    catch (IOException ex)
                    {
                      ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
                      goto label_28;
                    }
                  }
                  catch (ArcNetException ex)
                  {
                    arcNetException1 = (ArcNetException) ByteCodeHelper.MapException<ArcNetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
                    goto label_29;
                  }
                }
                else
                  goto label_41;
              }
              catch (CancelledKeyException ex)
              {
                goto label_30;
              }
            }
            else
              break;
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
label_27:
          // ISSUE: variable of the null type
          __Null local = null;
          goto label_126;
label_28:
          IOException ioException2 = ioException1;
          goto label_31;
label_29:
          ioException2 = (IOException) arcNetException1;
          goto label_31;
label_30:
          local = null;
          goto label_126;
label_31:
          Exception exception1 = (Exception) ioException2;
          CharSequence charSequence1;
          // ISSUE: fault handler
          try
          {
            Exception exception2 = exception1;
            try
            {
              Exception exception3 = exception2;
              ArcNet.handleError((Exception) new ArcNetException(new StringBuilder().append("Error reading TCP from connection: ").append((object) connection1).toString(), (Exception) exception3));
              Connection connection2 = connection1;
              DcReason reason;
              if (Throwable.instancehelper_getMessage((Exception) exception3) != null)
              {
                string message = Throwable.instancehelper_getMessage((Exception) exception3);
                object obj = (object) "closed";
                charSequence1.__\u003Cref\u003E = (__Null) obj;
                CharSequence charSequence2 = charSequence1;
                if (String.instancehelper_contains(message, charSequence2))
                {
                  reason = DcReason.__\u003C\u003Eclosed;
                  goto label_37;
                }
              }
              reason = DcReason.__\u003C\u003Eerror;
label_37:
              connection2.close(reason);
              goto label_41;
            }
            catch (CancelledKeyException ex)
            {
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
          local = null;
          goto label_126;
label_41:
          IOException ioException3;
          // ISSUE: fault handler
          try
          {
            if ((num2 & 4) == 4)
            {
              try
              {
                connection1.tcp.writeOperation();
                continue;
              }
              catch (IOException ex)
              {
                ioException3 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              }
            }
            else
              continue;
          }
          catch (CancelledKeyException ex)
          {
            goto label_47;
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
          IOException ioException4 = ioException3;
          IOException ioException5;
          // ISSUE: fault handler
          try
          {
            ioException5 = ioException4;
            try
            {
              IOException ioException6 = ioException5;
              Connection connection2 = connection1;
              DcReason reason;
              if (Throwable.instancehelper_getMessage((Exception) ioException6) != null)
              {
                string message = Throwable.instancehelper_getMessage((Exception) ioException6);
                object obj = (object) "closed";
                charSequence1.__\u003Cref\u003E = (__Null) obj;
                CharSequence charSequence2 = charSequence1;
                if (String.instancehelper_contains(message, charSequence2))
                {
                  reason = DcReason.__\u003C\u003Eclosed;
                  goto label_53;
                }
              }
              reason = DcReason.__\u003C\u003Eerror;
label_53:
              connection2.close(reason);
              continue;
            }
            catch (CancelledKeyException ex)
            {
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
          local = null;
          goto label_126;
label_47:
          local = null;
          goto label_126;
label_57:
          // ISSUE: fault handler
          try
          {
            ServerSocketChannel serverChannel;
            try
            {
              if ((num2 & 16) == 16)
              {
                serverChannel = this.serverChannel;
                if (serverChannel == null)
                  continue;
              }
              else
                goto label_73;
            }
            catch (CancelledKeyException ex)
            {
              goto label_65;
            }
            try
            {
              try
              {
                SocketChannel socketChannel = serverChannel.accept();
                if (socketChannel != null)
                {
                  this.acceptOperation(socketChannel);
                  continue;
                }
                continue;
              }
              catch (IOException ex)
              {
                ioException5 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
                goto label_66;
              }
            }
            catch (CancelledKeyException ex)
            {
              goto label_67;
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
label_65:
          local = null;
          goto label_126;
label_66:
          IOException ioException7 = ioException5;
          IOException ioException8;
          // ISSUE: fault handler
          try
          {
            ioException8 = ioException7;
            try
            {
              ArcNet.handleError((Exception) ioException8);
              continue;
            }
            catch (CancelledKeyException ex)
            {
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
          local = null;
          goto label_126;
label_67:
          local = null;
          goto label_126;
label_73:
          InetSocketAddress inetSocketAddress;
          // ISSUE: fault handler
          try
          {
            try
            {
              if (udp == null)
              {
                ((AbstractInterruptibleChannel) selectionKey.channel()).close();
                continue;
              }
            }
            catch (CancelledKeyException ex)
            {
              goto label_80;
            }
            try
            {
              try
              {
                inetSocketAddress = udp.readFromAddress();
                goto label_88;
              }
              catch (IOException ex)
              {
                ioException8 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
                goto label_81;
              }
            }
            catch (CancelledKeyException ex)
            {
              goto label_82;
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
label_80:
          local = null;
          goto label_126;
label_81:
          IOException ioException9 = ioException8;
          // ISSUE: fault handler
          try
          {
            IOException ioException6 = ioException9;
            try
            {
              ArcNet.handleError((Exception) ioException6);
              continue;
            }
            catch (CancelledKeyException ex)
            {
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
          local = null;
          goto label_126;
label_82:
          local = null;
          goto label_126;
label_88:
          object obj1;
          ArcNetException arcNetException2;
          // ISSUE: fault handler
          try
          {
            if (inetSocketAddress != null)
            {
              try
              {
                Connection[] connections = this.connections;
                int length = connections.Length;
                for (int index = 0; index < length; ++index)
                {
                  Connection connection2 = connections[index];
                  if (inetSocketAddress.equals((object) connection2.udpRemoteAddress))
                  {
                    connection1 = connection2;
                    break;
                  }
                }
                try
                {
                  obj1 = udp.readObject();
                  goto label_105;
                }
                catch (ArcNetException ex)
                {
                  arcNetException2 = (ArcNetException) ByteCodeHelper.MapException<ArcNetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
                }
              }
              catch (CancelledKeyException ex)
              {
                goto label_99;
              }
            }
            else
              continue;
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
          ArcNetException arcNetException3 = arcNetException2;
          // ISSUE: fault handler
          try
          {
            ArcNetException arcNetException4 = arcNetException3;
            try
            {
              ArcNetException arcNetException5 = arcNetException4;
              ArcNet.handleError((Exception) new ArcNetException(new StringBuilder().append("Error reading UDP from connection: ").append(connection1 != null ? (object) inetSocketAddress : (object) inetSocketAddress).toString(), (Exception) arcNetException5));
              continue;
            }
            catch (CancelledKeyException ex)
            {
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
          local = null;
          goto label_126;
label_99:
          local = null;
          goto label_126;
label_105:
          // ISSUE: fault handler
          try
          {
            Connection connection2;
            try
            {
              if (obj1 is FrameworkMessage)
              {
                if (obj1 is FrameworkMessage.RegisterUDP)
                {
                  connection2 = (Connection) this.pendingConnections.remove(((FrameworkMessage.RegisterUDP) obj1).connectionID);
                  if (connection2 != null)
                  {
                    if (connection2.udpRemoteAddress != null)
                      continue;
                  }
                  else
                    continue;
                }
                else
                  goto label_112;
              }
              else
                goto label_121;
            }
            catch (CancelledKeyException ex)
            {
              goto label_117;
            }
            try
            {
              connection2.udpRemoteAddress = inetSocketAddress;
              this.addConnection(connection2);
              connection2.sendTCP((object) new FrameworkMessage.RegisterUDP());
              connection2.notifyConnected();
              continue;
            }
            catch (CancelledKeyException ex)
            {
              goto label_118;
            }
label_112:
            try
            {
              if (obj1 is FrameworkMessage.DiscoverHost)
              {
                try
                {
                  this.discoveryHandler.onDiscoverReceived(inetSocketAddress.getAddress(), (ServerDiscoveryHandler.ReponseHandler) new Server.__\u003C\u003EAnon1(udp, inetSocketAddress));
                  continue;
                }
                catch (IOException ex)
                {
                  goto label_119;
                }
              }
              else
                goto label_121;
            }
            catch (CancelledKeyException ex)
            {
              goto label_120;
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
label_117:
          local = null;
          goto label_126;
label_118:
          local = null;
          goto label_126;
label_119:
          continue;
label_120:
          local = null;
          goto label_126;
label_121:
          // ISSUE: fault handler
          try
          {
            if (connection1 != null)
            {
              connection1.notifyReceived(obj1);
              continue;
            }
            continue;
          }
          catch (CancelledKeyException ex)
          {
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
          local = null;
label_126:
          // ISSUE: fault handler
          try
          {
            if (connection1 != null)
              connection1.close(DcReason.__\u003C\u003Eerror);
            else
              ((AbstractInterruptibleChannel) selectionKey.channel()).close();
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
        }
        // ISSUE: fault handler
        try
        {
          System.Threading.Monitor.Exit((object) set2);
        }
        __fault
        {
          System.Threading.Monitor.Exit((object) set2);
        }
      }
label_134:
      long num3 = java.lang.System.currentTimeMillis();
      Connection[] connections1 = this.connections;
      int index1 = 0;
      for (int length = connections1.Length; index1 < length; ++index1)
      {
        Connection connection = connections1[index1];
        if (connection.tcp.isTimedOut(num3))
          connection.close(DcReason.__\u003C\u003Etimeout);
        else if (connection.tcp.needsKeepAlive(num3))
          connection.sendTCP((object) FrameworkMessage.keepAlive);
        if (connection.isIdle())
          connection.notifyIdle();
      }
    }

    [LineNumberTable(413)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Connection newConnection() => new Connection();

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240(
      [In] InetAddress obj0,
      [In] ServerDiscoveryHandler.ReponseHandler obj1)
    {
      obj1.respond(ByteBuffer.allocate(0));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(305)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024update\u00241(
      [In] UdpConnection obj0,
      [In] InetSocketAddress obj1,
      [In] ByteBuffer obj2)
    {
      obj0.datagramChannel.send(obj2, (SocketAddress) obj1);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {73, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind(int tcpPort) => this.bind(new InetSocketAddress(tcpPort), (InetSocketAddress) null);

    [LineNumberTable(new byte[] {160, 248, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void start() => new Thread((Runnable) this, nameof (Server)).start();

    [LineNumberTable(new byte[] {161, 65, 103, 105, 100, 8, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendToAllTCP(object @object)
    {
      Connection[] connections = this.connections;
      int index = 0;
      for (int length = connections.Length; index < length; ++index)
        connections[index].sendTCP(@object);
    }

    [LineNumberTable(new byte[] {161, 73, 103, 105, 100, 105, 232, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendToAllExceptTCP(int connectionID, object @object)
    {
      Connection[] connections = this.connections;
      int index = 0;
      for (int length = connections.Length; index < length; ++index)
      {
        Connection connection = connections[index];
        if (connection.id != connectionID)
          connection.sendTCP(@object);
      }
    }

    [LineNumberTable(new byte[] {161, 82, 103, 105, 100, 105, 104, 226, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendToTCP(int connectionID, object @object)
    {
      Connection[] connections = this.connections;
      int index = 0;
      for (int length = connections.Length; index < length; ++index)
      {
        Connection connection = connections[index];
        if (connection.id == connectionID)
        {
          connection.sendTCP(@object);
          break;
        }
      }
    }

    [LineNumberTable(new byte[] {161, 93, 103, 105, 100, 8, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendToAllUDP(object @object)
    {
      Connection[] connections = this.connections;
      int index = 0;
      for (int length = connections.Length; index < length; ++index)
        connections[index].sendUDP(@object);
    }

    [LineNumberTable(new byte[] {161, 101, 103, 105, 100, 105, 232, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendToAllExceptUDP(int connectionID, object @object)
    {
      Connection[] connections = this.connections;
      int index = 0;
      for (int length = connections.Length; index < length; ++index)
      {
        Connection connection = connections[index];
        if (connection.id != connectionID)
          connection.sendUDP(@object);
      }
    }

    [LineNumberTable(new byte[] {161, 110, 103, 105, 100, 105, 104, 226, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendToUDP(int connectionID, object @object)
    {
      Connection[] connections = this.connections;
      int index = 0;
      for (int length = connections.Length; index < length; ++index)
      {
        Connection connection = connections[index];
        if (connection.id == connectionID)
        {
          connection.sendUDP(@object);
          break;
        }
      }
    }

    [LineNumberTable(new byte[] {161, 142, 99, 112, 109, 103, 99, 105, 107, 102, 106, 98, 103, 104, 236, 58, 232, 72, 103, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeListener(NetListener listener)
    {
      if (listener == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("listener cannot be null.");
      }
      object listenerLock;
      System.Threading.Monitor.Enter(listenerLock = this.listenerLock);
      // ISSUE: fault handler
      try
      {
        NetListener[] listeners = this.listeners;
        int length = listeners.Length;
        NetListener[] netListenerArray1 = new NetListener[length - 1];
        int index1 = 0;
        int num = 0;
        for (; index1 < length; ++index1)
        {
          NetListener netListener1 = listeners[index1];
          if (!object.ReferenceEquals((object) listener, (object) netListener1))
          {
            if (num == length - 1)
            {
              System.Threading.Monitor.Exit(listenerLock);
              return;
            }
            NetListener[] netListenerArray2 = netListenerArray1;
            int index2 = num;
            ++num;
            NetListener netListener2 = netListener1;
            netListenerArray2[index2] = netListener2;
          }
        }
        this.listeners = netListenerArray1;
        System.Threading.Monitor.Exit(listenerLock);
      }
      __fault
      {
        System.Threading.Monitor.Exit(listenerLock);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 205, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.close();
      this.selector.close();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Thread getUpdateThread() => this.updateThread;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Connection[] getConnections() => this.connections;

    [Modifiers]
    protected internal object discoveryReceiver
    {
      [HideFromJava] get => (object) this.__\u003C\u003EdiscoveryReceiver;
      [HideFromJava] [param: In] set => this.__\u003C\u003EdiscoveryReceiver = (Server.DiscoveryReceiver) value;
    }

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0031 : Object, NetListener
    {
      [Modifiers]
      internal Server this\u00240;

      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Server obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 184, 108, 105, 41, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void connected([In] Connection obj0)
      {
        NetListener[] listeners = this.this\u00240.listeners;
        int index = 0;
        for (int length = listeners.Length; index < length; ++index)
          listeners[index].connected(obj0);
      }

      [LineNumberTable(new byte[] {159, 190, 108, 108, 105, 42, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void disconnected([In] Connection obj0, [In] DcReason obj1)
      {
        this.this\u00240.removeConnection(obj0);
        NetListener[] listeners = this.this\u00240.listeners;
        int index = 0;
        for (int length = listeners.Length; index < length; ++index)
          listeners[index].disconnected(obj0, obj1);
      }

      [LineNumberTable(new byte[] {5, 108, 105, 42, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void received([In] Connection obj0, [In] object obj1)
      {
        NetListener[] listeners = this.this\u00240.listeners;
        int index = 0;
        for (int length = listeners.Length; index < length; ++index)
          listeners[index].received(obj0, obj1);
      }

      [LineNumberTable(new byte[] {11, 108, 105, 41, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void idle([In] Connection obj0)
      {
        NetListener[] listeners = this.this\u00240.listeners;
        int index = 0;
        for (int length = listeners.Length; index < length; ++index)
          listeners[index].idle(obj0);
      }
    }

    internal class DiscoveryReceiver : Object
    {
      internal MulticastSocket socket;
      internal Thread multicastThread;
      internal int multicastPort;
      [Modifiers]
      internal Server this\u00240;

      [LineNumberTable(new byte[] {161, 229, 239, 60, 231, 69, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal DiscoveryReceiver([In] Server obj0, [In] int obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Server.DiscoveryReceiver discoveryReceiver = this;
        this.socket = (MulticastSocket) null;
        this.multicastPort = obj1;
      }

      [LineNumberTable(new byte[] {161, 246, 251, 82})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void start() => this.multicastThread = Threads.daemon("Server Multicast Discovery", (Runnable) new Server.DiscoveryReceiver.__\u003C\u003EAnon0(this));

      [LineNumberTable(new byte[] {161, 235, 115, 104, 118, 221, 2, 97, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void close()
      {
        IOException ioException;
        try
        {
          if (this.multicastThread != null)
            this.multicastThread.interrupt();
          if (this.socket == null)
            return;
          this.socket.leaveGroup(this.this\u00240.multicastGroup);
          ((DatagramSocket) this.socket).close();
          return;
        }
        catch (IOException ex)
        {
          ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        ArcNet.handleError((Exception) ioException);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 248, 113, 118, 154, 108, 255, 17, 71, 97, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024start\u00241()
      {
        IOException ioException;
        try
        {
          this.socket = new MulticastSocket(this.multicastPort);
          this.socket.joinGroup(this.this\u00240.multicastGroup);
          DatagramPacket.__\u003Cclinit\u003E();
          DatagramPacket datagramPacket = new DatagramPacket(new byte[512], 512);
          while (true)
          {
            ((DatagramSocket) this.socket).receive(datagramPacket);
            this.this\u00240.discoveryHandler.onDiscoverReceived(datagramPacket.getAddress(), (ServerDiscoveryHandler.ReponseHandler) new Server.DiscoveryReceiver.__\u003C\u003EAnon1(this, datagramPacket));
          }
        }
        catch (IOException ex)
        {
          ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        ArcNet.handleError((Exception) ioException);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [Modifiers]
      [LineNumberTable(new byte[] {161, 254, 103, 110, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024start\u00240([In] DatagramPacket obj0, [In] ByteBuffer obj1)
      {
        byte[] numArray = obj1.array();
        DatagramPacket.__\u003Cclinit\u003E();
        DatagramPacket datagramPacket = new DatagramPacket(numArray, numArray.Length);
        datagramPacket.setSocketAddress(obj0.getSocketAddress());
        ((DatagramSocket) this.socket).send(datagramPacket);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly Server.DiscoveryReceiver arg\u00241;

        internal __\u003C\u003EAnon0([In] Server.DiscoveryReceiver obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024start\u00241();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : ServerDiscoveryHandler.ReponseHandler
      {
        private readonly Server.DiscoveryReceiver arg\u00241;
        private readonly DatagramPacket arg\u00242;

        internal __\u003C\u003EAnon1([In] Server.DiscoveryReceiver obj0, [In] DatagramPacket obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void respond([In] ByteBuffer obj0) => this.arg\u00241.lambda\u0024start\u00240(this.arg\u00242, obj0);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : ServerDiscoveryHandler
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void onDiscoverReceived([In] InetAddress obj0, [In] ServerDiscoveryHandler.ReponseHandler obj1) => Server.lambda\u0024new\u00240(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : ServerDiscoveryHandler.ReponseHandler
    {
      private readonly UdpConnection arg\u00241;
      private readonly InetSocketAddress arg\u00242;

      internal __\u003C\u003EAnon1([In] UdpConnection obj0, [In] InetSocketAddress obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void respond([In] ByteBuffer obj0) => Server.lambda\u0024update\u00241(this.arg\u00241, this.arg\u00242, obj0);
    }
  }
}
