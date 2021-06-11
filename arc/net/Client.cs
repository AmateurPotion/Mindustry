// Decompiled with JetBrains decompiler
// Type: arc.net.Client
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.util.async;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.nio;
using java.nio.channels;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace arc.net
{
  [Implements(new string[] {"arc.net.EndPoint"})]
  public class Client : Connection, EndPoint, Runnable
  {
    [Modifiers]
    private NetSerializer serialization;
    private Selector selector;
    private int emptySelects;
    private volatile bool tcpRegistered;
    private volatile bool udpRegistered;
    private object tcpRegistrationLock;
    private object udpRegistrationLock;
    private volatile bool shutdown;
    [Modifiers]
    private object updateLock;
    private Thread updateThread;
    private int connectTimeout;
    private InetAddress connectHost;
    private int connectTcpPort;
    private int connectUdpPort;
    private bool isClosed;
    private AsyncExecutor discoverExecutor;
    [Signature("Larc/func/Prov<Ljava/net/DatagramPacket;>;")]
    private Prov discoveryPacket;

    [LineNumberTable(new byte[] {12, 232, 26, 107, 139, 235, 71, 108, 240, 92, 135, 135, 169, 189, 2, 97, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Client(int writeBufferSize, int objectBufferSize, NetSerializer serialization)
    {
      Client client = this;
      this.tcpRegistrationLock = (object) new Object();
      this.udpRegistrationLock = (object) new Object();
      this.updateLock = (object) new Object();
      this.discoverExecutor = new AsyncExecutor(6);
      this.discoveryPacket = (Prov) new Client.__\u003C\u003EAnon0();
      this.endPoint = (EndPoint) this;
      this.serialization = serialization;
      this.initialize(serialization, writeBufferSize, objectBufferSize);
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
      throw new RuntimeException("Error opening selector.", (Exception) ioException2);
    }

    [Signature("(Larc/func/Prov<Ljava/net/DatagramPacket;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDiscoveryPacket(Prov discoveryPacket) => this.discoveryPacket = discoveryPacket;

    [LineNumberTable(new byte[] {160, 251, 107, 173, 149, 104, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      this.close(DcReason.__\u003C\u003Eclosed);
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
      if (this.isClosed)
        return;
      this.isClosed = true;
      this.selector.wakeup();
    }

    [Signature("(ILjava/lang/String;IILarc/func/Cons<Ljava/net/DatagramPacket;>;Ljava/lang/Runnable;)V")]
    [LineNumberTable(new byte[] {161, 58, 171, 255, 0, 85, 255, 1, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void discoverHosts(
      int udpPort,
      string multicastGroup,
      int multicastPort,
      int timeoutMillis,
      Cons handler,
      Runnable done)
    {
      bool[] flagArray = new bool[1]{ false };
      this.discoverExecutor.submit((AsyncTask) new Client.__\u003C\u003EAnon1(this, udpPort, timeoutMillis, handler, flagArray, done));
      this.discoverExecutor.submit((AsyncTask) new Client.__\u003C\u003EAnon2(this, multicastGroup, multicastPort, timeoutMillis, handler, flagArray, done));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 9, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.close();
      this.selector.close();
    }

    [LineNumberTable(new byte[] {160, 242, 106, 97, 102, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop()
    {
      if (this.shutdown)
        return;
      this.close();
      this.shutdown = true;
      Thread.MemoryBarrier();
      this.selector.wakeup();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {43, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connect(int timeout, string host, int tcpPort, int udpPort) => this.connect(timeout, InetAddress.getByName(host), tcpPort, udpPort);

    [LineNumberTable(new byte[] {160, 211, 110, 138, 255, 3, 71, 226, 58, 97, 230, 69, 226, 60, 97, 110, 102, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void run()
    {
      this.shutdown = false;
      Thread.MemoryBarrier();
      while (!this.shutdown)
      {
        ArcNetException arcNetException1;
        try
        {
          try
          {
            this.update(250);
            continue;
          }
          catch (IOException ex)
          {
          }
        }
        catch (ArcNetException ex)
        {
          arcNetException1 = (ArcNetException) ByteCodeHelper.MapException<ArcNetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_6;
        }
        this.close();
        continue;
label_6:
        ArcNetException arcNetException2 = arcNetException1;
        this.lastProtocolError = arcNetException2;
        Thread.MemoryBarrier();
        this.close();
        throw Throwable.__\u003Cunmap\u003E((Exception) arcNetException2);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {65, 99, 112, 114, 144, 103, 103, 103, 104, 102, 135, 101, 114, 175, 109, 110, 108, 105, 157, 191, 51, 127, 5, 146, 150, 63, 12, 97, 133, 106, 208, 159, 55, 101, 138, 110, 110, 108, 115, 191, 64, 127, 6, 106, 104, 103, 109, 144, 150, 63, 16, 129, 101, 106, 191, 23, 255, 51, 69, 226, 61, 98, 102, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connect(int timeout, InetAddress host, int tcpPort, int udpPort)
    {
      if (host == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("host cannot be null.");
      }
      if (object.ReferenceEquals((object) Thread.currentThread(), (object) this.getUpdateThread()))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Cannot connect on the connection's update thread.");
      }
      this.connectTimeout = timeout;
      this.connectHost = host;
      this.connectTcpPort = tcpPort;
      this.connectUdpPort = udpPort;
      this.close();
      this.id = -1;
      object updateLock1;
      long num;
      Exception exception1;
      IOException ioException1;
      try
      {
        if (udpPort != -1)
          this.udp = new UdpConnection(this.serialization, ((Buffer) this.tcp.readBuffer).capacity());
        System.Threading.Monitor.Enter(updateLock1 = this.updateLock);
        try
        {
          this.tcpRegistered = false;
          Thread.MemoryBarrier();
          this.selector.wakeup();
          num = java.lang.System.currentTimeMillis() + (long) timeout;
          this.tcp.connect(this.selector, (SocketAddress) new InetSocketAddress(host, tcpPort), 5000);
          System.Threading.Monitor.Exit(updateLock1);
          goto label_16;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_12;
      }
      Exception exception2 = exception1;
      IOException ioException2;
      try
      {
        Exception exception3 = exception2;
        System.Threading.Monitor.Exit(updateLock1);
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      catch (IOException ex)
      {
        ioException2 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException3 = ioException2;
      goto label_74;
label_12:
      ioException3 = ioException1;
      goto label_74;
label_16:
      object registrationLock1;
      IOException ioException4;
      try
      {
        System.Threading.Monitor.Enter(registrationLock1 = this.tcpRegistrationLock);
        goto label_19;
      }
      catch (IOException ex)
      {
        ioException4 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      ioException3 = ioException4;
      goto label_74;
label_19:
      Exception exception4;
      IOException ioException5;
      while (true)
      {
        try
        {
          try
          {
            if (!this.tcpRegistered)
            {
              if (java.lang.System.currentTimeMillis() < num)
              {
                try
                {
                  Object.instancehelper_wait(this.tcpRegistrationLock, 100L);
                }
                catch (InterruptedException ex)
                {
                }
              }
              else
                goto label_28;
            }
            else
              goto label_28;
          }
          catch (Exception ex)
          {
            exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            break;
          }
        }
        catch (IOException ex)
        {
          ioException5 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_27;
        }
      }
      Exception exception5 = exception4;
      goto label_35;
label_27:
      ioException3 = ioException5;
      goto label_74;
label_28:
      Exception exception6;
      IOException ioException6;
      try
      {
        try
        {
          if (!this.tcpRegistered)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new SocketTimeoutException("Connected, but timed out during TCP registration.\nNote: Client#update must be called in a separate thread during connect.");
          }
          System.Threading.Monitor.Exit(registrationLock1);
          goto label_39;
        }
        catch (Exception ex)
        {
          exception6 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (IOException ex)
      {
        ioException6 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_34;
      }
      exception5 = exception6;
      goto label_35;
label_34:
      ioException3 = ioException6;
      goto label_74;
label_39:
      InetSocketAddress inetSocketAddress;
      object updateLock2;
      Exception exception7;
      IOException ioException7;
      try
      {
        if (udpPort == -1)
          return;
        inetSocketAddress = new InetSocketAddress(host, udpPort);
        System.Threading.Monitor.Enter(updateLock2 = this.updateLock);
        try
        {
          this.udpRegistered = false;
          Thread.MemoryBarrier();
          this.selector.wakeup();
          this.udp.connect(this.selector, inetSocketAddress);
          System.Threading.Monitor.Exit(updateLock2);
          goto label_49;
        }
        catch (Exception ex)
        {
          exception7 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (IOException ex)
      {
        ioException7 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_45;
      }
      Exception exception8 = exception7;
      IOException ioException8;
      try
      {
        Exception exception3 = exception8;
        System.Threading.Monitor.Exit(updateLock2);
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      catch (IOException ex)
      {
        ioException8 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      ioException3 = ioException8;
      goto label_74;
label_45:
      ioException3 = ioException7;
      goto label_74;
label_49:
      object registrationLock2;
      IOException ioException9;
      try
      {
        System.Threading.Monitor.Enter(registrationLock2 = this.udpRegistrationLock);
        goto label_52;
      }
      catch (IOException ex)
      {
        ioException9 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      ioException3 = ioException9;
      goto label_74;
label_52:
      Exception exception9;
      IOException ioException10;
      while (true)
      {
        try
        {
          try
          {
            if (!this.udpRegistered)
            {
              if (java.lang.System.currentTimeMillis() < num)
              {
                this.udp.send((object) new FrameworkMessage.RegisterUDP()
                {
                  connectionID = this.id
                }, (SocketAddress) inetSocketAddress);
                try
                {
                  Object.instancehelper_wait(this.udpRegistrationLock, 100L);
                }
                catch (InterruptedException ex)
                {
                }
              }
              else
                goto label_62;
            }
            else
              goto label_62;
          }
          catch (Exception ex)
          {
            exception9 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            break;
          }
        }
        catch (IOException ex)
        {
          ioException10 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_61;
        }
      }
      Exception exception10 = exception9;
      goto label_69;
label_61:
      ioException3 = ioException10;
      goto label_74;
label_62:
      Exception exception11;
      IOException ioException11;
      try
      {
        try
        {
          if (!this.udpRegistered)
          {
            string str = new StringBuilder().append("Connected, but timed out during UDP registration: ").append((object) host).append(":").append(udpPort).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new SocketTimeoutException(str);
          }
          System.Threading.Monitor.Exit(registrationLock2);
          return;
        }
        catch (Exception ex)
        {
          exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (IOException ex)
      {
        ioException11 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_68;
      }
      exception10 = exception11;
      goto label_69;
label_68:
      ioException3 = ioException11;
      goto label_74;
label_69:
      Exception exception12 = exception10;
      IOException ioException12;
      try
      {
        Exception exception3 = exception12;
        System.Threading.Monitor.Exit(registrationLock2);
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      catch (IOException ex)
      {
        ioException12 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      ioException3 = ioException12;
      goto label_74;
label_35:
      Exception exception13 = exception5;
      IOException ioException13;
      try
      {
        Exception exception3 = exception13;
        System.Threading.Monitor.Exit(registrationLock1);
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      catch (IOException ex)
      {
        ioException13 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      ioException3 = ioException13;
label_74:
      IOException ioException14 = ioException3;
      this.close();
      throw Throwable.__\u003Cunmap\u003E((Exception) ioException14);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Thread getUpdateThread() => this.updateThread;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 89, 104, 144, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reconnect(int timeout)
    {
      if (this.connectHost == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("This client has never been connected.");
      }
      this.connect(timeout, this.connectHost, this.connectTcpPort, this.connectUdpPort);
    }

    [LineNumberTable(new byte[] {160, 203, 107, 102, 122, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void keepAlive()
    {
      if (!this.isConnected)
        return;
      long num = java.lang.System.currentTimeMillis();
      if (this.tcp.needsKeepAlive(num))
        this.sendTCP((object) FrameworkMessage.keepAlive);
      if (this.udp == null || !this.udpRegistered || !this.udp.needsKeepAlive(num))
        return;
      this.sendUDP((object) FrameworkMessage.keepAlive);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 103, 107, 173, 117, 102, 98, 100, 144, 140, 99, 110, 109, 167, 136, 102, 149, 34, 129, 133, 103, 103, 109, 106, 127, 1, 102, 110, 135, 105, 103, 159, 32, 109, 100, 101, 109, 105, 114, 110, 110, 107, 104, 103, 127, 73, 104, 223, 0, 114, 105, 110, 110, 107, 103, 127, 73, 223, 0, 106, 98, 104, 153, 121, 98, 109, 112, 98, 191, 9, 103, 179, 17, 161, 101, 151, 106, 102, 110, 136, 102, 104, 134})]
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
              goto label_86;
            }
            else
              goto label_86;
          }
          catch (InterruptedException ex)
          {
          }
        }
      }
      else
      {
        this.emptySelects = 0;
        this.isClosed = false;
        Set set1 = this.selector.selectedKeys();
        Set set2;
        System.Threading.Monitor.Enter((object) (set2 = set1));
        Iterator iterator;
        // ISSUE: fault handler
        try
        {
          iterator = set1.iterator();
        }
        __fault
        {
          System.Threading.Monitor.Exit((object) set2);
        }
        while (true)
        {
          int num2;
          // ISSUE: fault handler
          try
          {
            if (iterator.hasNext())
            {
              this.keepAlive();
              SelectionKey selectionKey = (SelectionKey) iterator.next();
              iterator.remove();
              try
              {
                num2 = selectionKey.readyOps();
                if ((num2 & 1) == 1)
                {
                  if (!object.ReferenceEquals(selectionKey.attachment(), (object) this.tcp))
                    goto label_66;
                  else
                    goto label_20;
                }
                else
                  goto label_76;
              }
              catch (CancelledKeyException ex)
              {
              }
            }
            else
              break;
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
          // ISSUE: variable of the null type
          __Null local = null;
          goto label_81;
label_20:
          object obj;
          object registrationLock;
          Exception exception1;
          Exception exception2;
          while (true)
          {
            // ISSUE: fault handler
            try
            {
              do
              {
                obj = this.tcp.readObject();
                if (obj != null)
                {
                  if (this.tcpRegistered)
                    goto label_42;
                }
                else
                  goto label_76;
              }
              while (!(obj is FrameworkMessage.RegisterTCP));
              this.id = ((FrameworkMessage.RegisterTCP) obj).connectionID;
              System.Threading.Monitor.Enter(registrationLock = this.tcpRegistrationLock);
              try
              {
                this.tcpRegistered = true;
                Thread.MemoryBarrier();
                Object.instancehelper_notifyAll(this.tcpRegistrationLock);
                if (this.udp == null)
                  this.setConnected(true);
                System.Threading.Monitor.Exit(registrationLock);
              }
              catch (Exception ex)
              {
                exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                break;
              }
            }
            catch (CancelledKeyException ex)
            {
              goto label_31;
            }
            __fault
            {
              System.Threading.Monitor.Exit((object) set2);
            }
            // ISSUE: fault handler
            try
            {
              if (this.udp == null)
              {
                this.notifyConnected();
                continue;
              }
              continue;
            }
            catch (CancelledKeyException ex)
            {
              goto label_41;
            }
            __fault
            {
              System.Threading.Monitor.Exit((object) set2);
            }
label_42:
            // ISSUE: fault handler
            try
            {
              if (this.udp != null)
              {
                if (!this.udpRegistered)
                {
                  if (obj is FrameworkMessage.RegisterUDP)
                  {
                    System.Threading.Monitor.Enter(registrationLock = this.udpRegistrationLock);
                    try
                    {
                      this.udpRegistered = true;
                      Thread.MemoryBarrier();
                      Object.instancehelper_notifyAll(this.udpRegistrationLock);
                      this.setConnected(true);
                      System.Threading.Monitor.Exit(registrationLock);
                    }
                    catch (Exception ex)
                    {
                      exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                      goto label_50;
                    }
                  }
                  else
                    continue;
                }
                else
                  goto label_61;
              }
              else
                goto label_61;
            }
            catch (CancelledKeyException ex)
            {
              goto label_51;
            }
            __fault
            {
              System.Threading.Monitor.Exit((object) set2);
            }
            // ISSUE: fault handler
            try
            {
              this.notifyConnected();
              continue;
            }
            catch (CancelledKeyException ex)
            {
              goto label_60;
            }
            __fault
            {
              System.Threading.Monitor.Exit((object) set2);
            }
label_61:
            // ISSUE: fault handler
            try
            {
              if (this.isConnected)
                this.notifyReceived(obj);
            }
            catch (CancelledKeyException ex)
            {
              goto label_65;
            }
            __fault
            {
              System.Threading.Monitor.Exit((object) set2);
            }
          }
          Exception exception3 = exception1;
          // ISSUE: fault handler
          try
          {
            exception2 = exception3;
            try
            {
              Exception exception4 = exception2;
              System.Threading.Monitor.Exit(registrationLock);
              throw Throwable.__\u003Cunmap\u003E(exception4);
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
          goto label_81;
label_31:
          local = null;
          goto label_81;
label_41:
          local = null;
          goto label_81;
label_50:
          Exception exception5 = exception2;
          // ISSUE: fault handler
          try
          {
            Exception exception4 = exception5;
            try
            {
              Exception exception6 = exception4;
              System.Threading.Monitor.Exit(registrationLock);
              throw Throwable.__\u003Cunmap\u003E(exception6);
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
          goto label_81;
label_51:
          local = null;
          goto label_81;
label_60:
          local = null;
          goto label_81;
label_65:
          local = null;
          goto label_81;
label_66:
          // ISSUE: fault handler
          try
          {
            try
            {
              if (this.udp.readFromAddress() == null)
                continue;
            }
            catch (CancelledKeyException ex)
            {
              goto label_73;
            }
            try
            {
              obj = this.udp.readObject();
              if (obj == null)
                continue;
            }
            catch (CancelledKeyException ex)
            {
              goto label_74;
            }
            try
            {
              this.notifyReceived(obj);
              goto label_76;
            }
            catch (CancelledKeyException ex)
            {
              goto label_75;
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) set2);
          }
label_73:
          local = null;
          goto label_81;
label_74:
          local = null;
          goto label_81;
label_75:
          local = null;
          goto label_81;
label_76:
          // ISSUE: fault handler
          try
          {
            if ((num2 & 4) == 4)
            {
              this.tcp.writeOperation();
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
label_81:;
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
label_86:
      if (!this.isConnected)
        return;
      if (this.tcp.isTimedOut(java.lang.System.currentTimeMillis()))
        this.close();
      else
        this.keepAlive();
      if (!this.isIdle())
        return;
      this.notifyIdle();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 34, 104, 113, 103, 108, 104, 127, 8, 104, 162, 127, 5, 105, 102, 118, 98, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void broadcast([In] int obj0, [In] DatagramSocket obj1)
    {
      ByteBuffer bb = ByteBuffer.allocate(64);
      this.serialization.write(bb, (object) new FrameworkMessage.DiscoverHost());
      ((Buffer) bb).flip();
      byte[] numArray = new byte[((Buffer) bb).limit()];
      bb.get(numArray);
      Iterator iterator1 = Collections.list(NetworkInterface.getNetworkInterfaces()).iterator();
label_1:
      while (iterator1.hasNext())
      {
        NetworkInterface networkInterface = (NetworkInterface) iterator1.next();
        if (networkInterface.isUp())
        {
          Iterator iterator2 = networkInterface.getInterfaceAddresses().iterator();
          while (true)
          {
            InetAddress broadcast;
            do
            {
              if (iterator2.hasNext())
                broadcast = ((InterfaceAddress) iterator2.next()).getBroadcast();
              else
                goto label_1;
            }
            while (broadcast == null);
            DatagramSocket datagramSocket = obj1;
            DatagramPacket.__\u003Cclinit\u003E();
            DatagramPacket datagramPacket = new DatagramPacket(numArray, numArray.Length, broadcast, obj0);
            datagramSocket.send(datagramPacket);
          }
        }
      }
    }

    [Modifiers]
    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static DatagramPacket lambda\u0024new\u00240()
    {
      DatagramPacket.__\u003Cclinit\u003E();
      return new DatagramPacket(new byte[256], 256);
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    [LineNumberTable(new byte[] {161, 62, 102, 103, 104, 135, 113, 103, 103, 139, 105, 102, 101, 135, 111, 232, 48, 252, 74, 105, 102, 101, 135, 111, 250, 58, 105, 102, 101, 135, 111, 235, 58, 105, 102, 101, 135, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object lambda\u0024discoverHosts\u00241(
      [In] int obj0,
      [In] int obj1,
      [In] Cons obj2,
      [In] bool[] obj3,
      [In] Runnable obj4)
    {
      DatagramSocket datagramSocket;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        datagramSocket = new DatagramSocket();
        try
        {
          datagramSocket.setBroadcast(true);
          this.broadcast(obj0, datagramSocket);
          datagramSocket.setSoTimeout(obj1);
          while (true)
          {
            DatagramPacket datagramPacket = (DatagramPacket) this.discoveryPacket.get();
            datagramSocket.receive(datagramPacket);
            obj2.get((object) datagramPacket);
          }
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        lock (obj3)
        {
          if (!obj3[0])
          {
            obj3[0] = true;
            obj4.run();
          }
        }
      }
      Exception exception2 = exception1;
      Exception exception3;
      // ISSUE: fault handler
      try
      {
        exception3 = exception2;
        try
        {
          datagramSocket.close();
          goto label_25;
        }
        catch (Exception ex)
        {
          exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        lock (obj3)
        {
          if (!obj3[0])
          {
            obj3[0] = true;
            obj4.run();
          }
        }
      }
      Exception exception4 = exception2;
      // ISSUE: fault handler
      try
      {
        Exception exception5 = exception4;
        Throwable.instancehelper_addSuppressed(exception3, exception5);
      }
      __fault
      {
        lock (obj3)
        {
          if (!obj3[0])
          {
            obj3[0] = true;
            obj4.run();
          }
        }
      }
label_25:
      // ISSUE: fault handler
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      __fault
      {
        lock (obj3)
        {
          if (!obj3[0])
          {
            obj3[0] = true;
            obj4.run();
          }
        }
      }
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    [LineNumberTable(new byte[] {161, 83, 134, 104, 113, 103, 108, 136, 122, 135, 113, 103, 104, 140, 106, 102, 101, 135, 112, 233, 42, 252, 80, 106, 102, 101, 135, 112, 250, 58, 106, 102, 101, 135, 112, 235, 58, 106, 102, 101, 135, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object lambda\u0024discoverHosts\u00242(
      [In] string obj0,
      [In] int obj1,
      [In] int obj2,
      [In] Cons obj3,
      [In] bool[] obj4,
      [In] Runnable obj5)
    {
      DatagramSocket datagramSocket1;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        datagramSocket1 = new DatagramSocket();
        try
        {
          ByteBuffer bb = ByteBuffer.allocate(64);
          this.serialization.write(bb, (object) new FrameworkMessage.DiscoverHost());
          ((Buffer) bb).flip();
          byte[] numArray = new byte[((Buffer) bb).limit()];
          bb.get(numArray);
          DatagramSocket datagramSocket2 = datagramSocket1;
          DatagramPacket.__\u003Cclinit\u003E();
          DatagramPacket datagramPacket1 = new DatagramPacket(numArray, numArray.Length, InetAddress.getByName(obj0), obj1);
          datagramSocket2.send(datagramPacket1);
          datagramSocket1.setSoTimeout(obj2);
          while (true)
          {
            DatagramPacket datagramPacket2 = (DatagramPacket) this.discoveryPacket.get();
            datagramSocket1.receive(datagramPacket2);
            obj3.get((object) datagramPacket2);
          }
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        lock (obj4)
        {
          if (!obj4[0])
          {
            obj4[0] = true;
            obj5.run();
          }
        }
      }
      Exception exception2 = exception1;
      Exception exception3;
      // ISSUE: fault handler
      try
      {
        exception3 = exception2;
        try
        {
          datagramSocket1.close();
          goto label_25;
        }
        catch (Exception ex)
        {
          exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        lock (obj4)
        {
          if (!obj4[0])
          {
            obj4[0] = true;
            obj5.run();
          }
        }
      }
      Exception exception4 = exception2;
      // ISSUE: fault handler
      try
      {
        Exception exception5 = exception4;
        Throwable.instancehelper_addSuppressed(exception3, exception5);
      }
      __fault
      {
        lock (obj4)
        {
          if (!obj4[0])
          {
            obj4[0] = true;
            obj5.run();
          }
        }
      }
label_25:
      // ISSUE: fault handler
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      __fault
      {
        lock (obj4)
        {
          if (!obj4[0])
          {
            obj4[0] = true;
            obj5.run();
          }
        }
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {35, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connect(int timeout, string host, int tcpPort) => this.connect(timeout, InetAddress.getByName(host), tcpPort, -1);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {51, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connect(int timeout, InetAddress host, int tcpPort) => this.connect(timeout, host, tcpPort, -1);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 80, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reconnect() => this.reconnect(this.connectTimeout);

    [LineNumberTable(new byte[] {160, 228, 104, 142, 156, 34, 161, 113, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void start()
    {
      if (this.updateThread != null)
      {
        this.shutdown = true;
        Thread.MemoryBarrier();
        try
        {
          this.updateThread.join(5000L);
          goto label_5;
        }
        catch (InterruptedException ex)
        {
        }
      }
label_5:
      this.updateThread = new Thread((Runnable) this, nameof (Client));
      this.updateThread.setDaemon(true);
      this.updateThread.start();
    }

    [LineNumberTable(new byte[] {161, 20, 120, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setKeepAliveUDP(int keepAliveMillis)
    {
      if (this.udp == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Not connected via UDP.");
      }
      this.udp.keepAliveMillis = keepAliveMillis;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NetSerializer getSerialization() => this.serialization;

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) Client.lambda\u0024new\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : AsyncTask
    {
      private readonly Client arg\u00241;
      private readonly int arg\u00242;
      private readonly int arg\u00243;
      private readonly Cons arg\u00244;
      private readonly bool[] arg\u00245;
      private readonly Runnable arg\u00246;

      internal __\u003C\u003EAnon1(
        [In] Client obj0,
        [In] int obj1,
        [In] int obj2,
        [In] Cons obj3,
        [In] bool[] obj4,
        [In] Runnable obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public object call() => this.arg\u00241.lambda\u0024discoverHosts\u00241(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : AsyncTask
    {
      private readonly Client arg\u00241;
      private readonly string arg\u00242;
      private readonly int arg\u00243;
      private readonly int arg\u00244;
      private readonly Cons arg\u00245;
      private readonly bool[] arg\u00246;
      private readonly Runnable arg\u00247;

      internal __\u003C\u003EAnon2(
        [In] Client obj0,
        [In] string obj1,
        [In] int obj2,
        [In] int obj3,
        [In] Cons obj4,
        [In] bool[] obj5,
        [In] Runnable obj6)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
      }

      public object call() => this.arg\u00241.lambda\u0024discoverHosts\u00242(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247);
    }
  }
}
