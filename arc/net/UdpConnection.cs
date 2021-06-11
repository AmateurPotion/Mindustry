// Decompiled with JetBrains decompiler
// Type: arc.net.UdpConnection
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.nio;
using java.nio.channels;
using java.nio.channels.spi;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.net
{
  internal class UdpConnection : Object
  {
    internal InetSocketAddress connectedAddress;
    internal DatagramChannel datagramChannel;
    internal int keepAliveMillis;
    [Modifiers]
    internal ByteBuffer readBuffer;
    [Modifiers]
    internal ByteBuffer writeBuffer;
    [Modifiers]
    private NetSerializer serialization;
    private SelectionKey selectionKey;
    [Modifiers]
    private object writeLock;
    private long lastCommunicationTime;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {52, 103, 99, 112, 173, 191, 42, 10, 98, 159, 52, 108, 109, 142, 139, 115, 159, 14, 31, 7, 135, 110, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int send([In] object obj0, [In] SocketAddress obj1)
    {
      DatagramChannel datagramChannel = this.datagramChannel;
      if (datagramChannel == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SocketException("Connection is closed.");
      }
      object writeLock;
      System.Threading.Monitor.Enter(writeLock = this.writeLock);
      Exception exception1;
      Exception exception2;
      Exception exception3;
      try
      {
        try
        {
          try
          {
            this.serialization.write(this.writeBuffer, obj0);
            goto label_18;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception1 = (Exception) m0;
          }
        }
        catch (Exception ex)
        {
          exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_10;
        }
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_11;
      }
      Exception exception4 = exception1;
      Exception exception5;
      Exception exception6;
      try
      {
        Exception exception7 = exception4;
        try
        {
          Exception exception8 = exception7;
          string message = new StringBuilder().append("Error serializing object of type: ").append(Object.instancehelper_getClass(obj0).getName()).toString();
          Exception exception9 = exception8;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcNetException(message, (Exception) exception9);
        }
        catch (Exception ex)
        {
          exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception6 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_17;
      }
      Exception exception10 = exception5;
      goto label_27;
label_17:
      Exception exception11 = exception6;
      goto label_31;
label_10:
      exception10 = exception2;
      goto label_27;
label_11:
      exception11 = exception3;
      goto label_31;
label_18:
      int num1;
      Exception exception12;
      Exception exception13;
      try
      {
        try
        {
          ((Buffer) this.writeBuffer).flip();
          int num2 = ((Buffer) this.writeBuffer).limit();
          datagramChannel.send(this.writeBuffer, obj1);
          this.lastCommunicationTime = java.lang.System.currentTimeMillis();
          num1 = (((Buffer) this.writeBuffer).hasRemaining() ? 0 : 1) == 0 ? -1 : num2;
          goto label_23;
        }
        catch (Exception ex)
        {
          exception12 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception13 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_22;
      }
      exception10 = exception12;
      goto label_27;
label_22:
      exception11 = exception13;
      goto label_31;
label_23:
      Exception exception14;
      try
      {
        ((Buffer) this.writeBuffer).clear();
        System.Threading.Monitor.Exit(writeLock);
        goto label_26;
      }
      catch (Exception ex)
      {
        exception14 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception11 = exception14;
      goto label_31;
label_26:
      return num1;
label_27:
      Exception exception15 = exception10;
      Exception exception16;
      try
      {
        Exception exception7 = exception15;
        ((Buffer) this.writeBuffer).clear();
        throw Throwable.__\u003Cunmap\u003E(exception7);
      }
      catch (Exception ex)
      {
        exception16 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception11 = exception16;
label_31:
      Exception exception17;
      while (true)
      {
        Exception exception7 = exception11;
        Exception exception8;
        try
        {
          exception17 = exception7;
          System.Threading.Monitor.Exit(writeLock);
          break;
        }
        catch (Exception ex)
        {
          exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        exception11 = exception8;
      }
      throw Throwable.__\u003Cunmap\u003E(exception17);
    }

    [LineNumberTable(new byte[] {77, 135, 104, 107, 103, 104, 188, 34, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      this.connectedAddress = (InetSocketAddress) null;
      try
      {
        if (this.datagramChannel == null)
          return;
        ((AbstractInterruptibleChannel) this.datagramChannel).close();
        this.datagramChannel = (DatagramChannel) null;
        if (this.selectionKey == null)
          return;
        this.selectionKey.selector().wakeup();
      }
      catch (IOException ex)
      {
      }
    }

    [LineNumberTable(new byte[] {159, 165, 232, 57, 203, 203, 103, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UdpConnection([In] NetSerializer obj0, [In] int obj1)
    {
      UdpConnection udpConnection = this;
      this.keepAliveMillis = 19000;
      this.writeLock = (object) new Object();
      this.serialization = obj0;
      this.readBuffer = ByteBuffer.allocate(obj1);
      this.writeBuffer = ByteBuffer.allocateDirect(obj1);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 189, 102, 108, 140, 113, 113, 113, 141, 147, 139, 217, 226, 61, 97, 102, 159, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connect([In] Selector obj0, [In] InetSocketAddress obj1)
    {
      this.close();
      ((Buffer) this.readBuffer).clear();
      ((Buffer) this.writeBuffer).clear();
      IOException ioException1;
      try
      {
        this.datagramChannel = obj0.provider().openDatagramChannel();
        this.datagramChannel.socket().bind((SocketAddress) null);
        this.datagramChannel.socket().connect((SocketAddress) obj1);
        ((AbstractSelectableChannel) this.datagramChannel).configureBlocking(false);
        this.selectionKey = ((SelectableChannel) this.datagramChannel).register(obj0, 1);
        this.lastCommunicationTime = java.lang.System.currentTimeMillis();
        this.connectedAddress = obj1;
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      this.close();
      string str = new StringBuilder().append("Unable to connect to: ").append((object) obj1).toString();
      IOException ioException3 = ioException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException(str, (Exception) ioException3);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {18, 103, 99, 112, 139, 104, 114, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual InetSocketAddress readFromAddress()
    {
      DatagramChannel datagramChannel = this.datagramChannel;
      if (datagramChannel == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SocketException("Connection is closed.");
      }
      this.lastCommunicationTime = java.lang.System.currentTimeMillis();
      if (!datagramChannel.isConnected())
        return (InetSocketAddress) datagramChannel.receive(this.readBuffer);
      datagramChannel.read(this.readBuffer);
      return this.connectedAddress;
    }

    [LineNumberTable(new byte[] {30, 172, 114, 109, 117, 191, 11, 244, 69, 108, 38, 236, 59, 100, 98, 178, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readObject()
    {
      ((Buffer) this.readBuffer).flip();
      object obj1;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        object obj2 = this.serialization.read(this.readBuffer);
        if (((Buffer) this.readBuffer).hasRemaining())
        {
          string message = new StringBuilder().append("Incorrect number of bytes (").append(((Buffer) this.readBuffer).remaining()).append(" remaining) used to deserialize object: ").append(obj2).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcNetException(message);
        }
        obj1 = obj2;
        goto label_9;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      __fault
      {
        ((Buffer) this.readBuffer).clear();
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcNetException("Error during deserialization.", (Exception) exception3);
      }
      __fault
      {
        ((Buffer) this.readBuffer).clear();
      }
label_9:
      ((Buffer) this.readBuffer).clear();
      return obj1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool needsKeepAlive([In] long obj0) => this.connectedAddress != null && this.keepAliveMillis > 0 && obj0 - this.lastCommunicationTime > (long) this.keepAliveMillis;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 172, 102, 108, 140, 113, 113, 109, 147, 221, 226, 61, 97, 102, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind([In] Selector obj0, [In] InetSocketAddress obj1)
    {
      this.close();
      ((Buffer) this.readBuffer).clear();
      ((Buffer) this.writeBuffer).clear();
      IOException ioException1;
      try
      {
        this.datagramChannel = obj0.provider().openDatagramChannel();
        this.datagramChannel.socket().bind((SocketAddress) obj1);
        ((AbstractSelectableChannel) this.datagramChannel).configureBlocking(false);
        this.selectionKey = ((SelectableChannel) this.datagramChannel).register(obj0, 1);
        this.lastCommunicationTime = java.lang.System.currentTimeMillis();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      this.close();
      throw Throwable.__\u003Cunmap\u003E((Exception) ioException2);
    }
  }
}
