// Decompiled with JetBrains decompiler
// Type: arc.net.Connection
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace arc.net
{
  public class Connection : Object
  {
    internal int id;
    private string name;
    internal EndPoint endPoint;
    internal TcpConnection tcp;
    internal UdpConnection udp;
    internal InetSocketAddress udpRemoteAddress;
    private NetListener[] listeners;
    [Modifiers]
    private object listenerLock;
    private int lastPingID;
    private long lastPingSendTime;
    private int returnTripTime;
    internal volatile bool isConnected;
    internal volatile ArcNetException lastProtocolError;
    private object arbitraryData;

    [LineNumberTable(new byte[] {160, 151, 108, 99, 113, 99, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual InetSocketAddress getRemoteAddressTCP()
    {
      if (this.tcp.socketChannel != null)
      {
        Socket socket = this.tcp.socketChannel.socket();
        if (socket != null)
          return (InetSocketAddress) socket.getRemoteSocketAddress();
      }
      return (InetSocketAddress) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ArcNetException getLastProtocolError() => this.lastProtocolError;

    [LineNumberTable(new byte[] {127, 99, 112, 109, 103, 99, 102, 107, 8, 166, 106, 101, 107, 104, 118})]
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

    [LineNumberTable(new byte[] {22, 179, 127, 15, 97, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int sendTCP(object @object)
    {
      if (@object == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("object cannot be null.");
      }
      int num;
      IOException ioException1;
      ArcNetException arcNetException;
      try
      {
        try
        {
          num = this.tcp.send(@object);
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_6;
        }
      }
      catch (ArcNetException ex)
      {
        arcNetException = (ArcNetException) ByteCodeHelper.MapException<ArcNetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_7;
      }
      return num;
label_6:
      IOException ioException2 = ioException1;
      goto label_8;
label_7:
      ioException2 = (IOException) arcNetException;
label_8:
      Exception exception = (Exception) ioException2;
      this.close(DcReason.__\u003C\u003Eerror);
      ArcNet.handleError((Exception) exception);
      return 0;
    }

    [LineNumberTable(new byte[] {39, 99, 112, 103, 107, 108, 109, 176, 147, 127, 16, 98, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int sendUDP(object @object)
    {
      if (@object == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("object cannot be null.");
      }
      InetSocketAddress inetSocketAddress = this.udpRemoteAddress;
      if (inetSocketAddress == null && this.udp != null)
        inetSocketAddress = this.udp.connectedAddress;
      if (inetSocketAddress == null)
      {
        if (this.isConnected)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Connection is not connected via UDP.");
        }
      }
      int num;
      IOException ioException1;
      ArcNetException arcNetException;
      try
      {
        try
        {
          if (inetSocketAddress == null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new SocketException("Connection is closed.");
          }
          num = this.udp.send(@object, (SocketAddress) inetSocketAddress);
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_13;
        }
      }
      catch (ArcNetException ex)
      {
        arcNetException = (ArcNetException) ByteCodeHelper.MapException<ArcNetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_14;
      }
      return num;
label_13:
      IOException ioException2 = ioException1;
      goto label_15;
label_14:
      ioException2 = (IOException) arcNetException;
label_15:
      Exception exception = (Exception) ioException2;
      this.close(DcReason.__\u003C\u003Eerror);
      ArcNet.handleError((Exception) exception);
      return 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getID() => this.id;

    [LineNumberTable(new byte[] {160, 79, 99, 112, 109, 103, 99, 99, 107, 105, 107, 102, 106, 98, 103, 104, 236, 58, 232, 72, 103, 119})]
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
        if (length == 0)
        {
          System.Threading.Monitor.Exit(listenerLock);
        }
        else
        {
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
      }
      __fault
      {
        System.Threading.Monitor.Exit(listenerLock);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isConnected() => this.isConnected;

    [LineNumberTable(new byte[] {59, 105, 110, 107, 117, 107, 99, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close(DcReason reason)
    {
      int num = this.isConnected ? 1 : 0;
      this.isConnected = false;
      Thread.MemoryBarrier();
      this.tcp.close();
      if (this.udp != null && this.udp.connectedAddress != null)
        this.udp.close();
      if (num != 0)
        this.notifyDisconnected(reason);
      this.setConnected(false);
    }

    [LineNumberTable(new byte[] {160, 106, 103, 105, 42, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void notifyDisconnected([In] DcReason obj0)
    {
      NetListener[] listeners = this.listeners;
      int index = 0;
      for (int length = listeners.Length; index < length; ++index)
        listeners[index].disconnected(this, obj0);
    }

    [LineNumberTable(new byte[] {159, 57, 66, 110, 107, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setConnected([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      this.isConnected = num != 0;
      Thread.MemoryBarrier();
      if (num == 0 || this.name != null)
        return;
      this.name = new StringBuilder().append("Connection ").append(this.id).toString();
    }

    [LineNumberTable(new byte[] {160, 206, 124, 53})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isIdle() => (double) ((float) ((Buffer) this.tcp.writeBuffer).position() / (float) ((Buffer) this.tcp.writeBuffer).capacity()) < (double) this.tcp.idleThreshold;

    [LineNumberTable(new byte[] {159, 176, 232, 49, 231, 70, 108, 235, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Connection()
    {
      Connection connection = this;
      this.id = -1;
      this.listeners = new NetListener[0];
      this.listenerLock = (object) new Object();
    }

    [LineNumberTable(new byte[] {159, 180, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void initialize([In] NetSerializer obj0, [In] int obj1, [In] int obj2) => this.tcp = new TcpConnection(obj0, obj1, obj2);

    [LineNumberTable(new byte[] {78, 102, 121, 107, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateReturnTripTime()
    {
      FrameworkMessage.Ping ping1 = new FrameworkMessage.Ping();
      FrameworkMessage.Ping ping2 = ping1;
      Connection connection1 = this;
      int lastPingId = connection1.lastPingID;
      Connection connection2 = connection1;
      int num = lastPingId;
      connection2.lastPingID = lastPingId + 1;
      ping2.id = num;
      this.lastPingSendTime = java.lang.System.currentTimeMillis();
      this.sendTCP((object) ping1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getReturnTripTime() => this.returnTripTime;

    [LineNumberTable(new byte[] {102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setKeepAliveTCP(int keepAliveMillis) => this.tcp.keepAliveMillis = keepAliveMillis;

    [LineNumberTable(new byte[] {118, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTimeout(int timeoutMillis) => this.tcp.timeoutMillis = timeoutMillis;

    [LineNumberTable(new byte[] {160, 100, 103, 105, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void notifyConnected()
    {
      NetListener[] listeners = this.listeners;
      int index = 0;
      for (int length = listeners.Length; index < length; ++index)
        listeners[index].connected(this);
    }

    [LineNumberTable(new byte[] {160, 112, 103, 105, 105, 104, 226, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void notifyIdle()
    {
      NetListener[] listeners = this.listeners;
      int index = 0;
      for (int length = listeners.Length; index < length; ++index)
      {
        listeners[index].idle(this);
        if (!this.isIdle())
          break;
      }
    }

    [LineNumberTable(new byte[] {160, 121, 104, 103, 104, 112, 213, 103, 168, 103, 105, 42, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void notifyReceived([In] object obj0)
    {
      if (obj0 is FrameworkMessage.Ping)
      {
        FrameworkMessage.Ping ping = (FrameworkMessage.Ping) obj0;
        if (ping.isReply)
        {
          if (ping.id == this.lastPingID - 1)
            this.returnTripTime = (int) (java.lang.System.currentTimeMillis() - this.lastPingSendTime);
        }
        else
        {
          ping.isReply = true;
          this.sendTCP((object) ping);
        }
      }
      NetListener[] listeners = this.listeners;
      int index = 0;
      for (int length = listeners.Length; index < length; ++index)
        listeners[index].received(this, obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual EndPoint getEndPoint() => this.endPoint;

    [LineNumberTable(new byte[] {160, 166, 108, 99, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual InetSocketAddress getRemoteAddressUDP() => this.udp.connectedAddress ?? this.udpRemoteAddress;

    [LineNumberTable(new byte[] {159, 69, 162, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBufferPositionFix(bool bufferPositionFix) => this.tcp.bufferPositionFix = bufferPositionFix;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setName(string name) => this.name = name;

    [LineNumberTable(313)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTcpWriteBufferSize() => ((Buffer) this.tcp.writeBuffer).position();

    [LineNumberTable(new byte[] {160, 216, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIdleThreshold(float idleThreshold) => this.tcp.idleThreshold = idleThreshold;

    [LineNumberTable(new byte[] {160, 220, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.name != null ? this.name : new StringBuilder().append("Connection ").append(this.id).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getArbitraryData() => this.arbitraryData;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setArbitraryData(object arbitraryData) => this.arbitraryData = arbitraryData;
  }
}
