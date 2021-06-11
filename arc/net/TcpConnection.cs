// Decompiled with JetBrains decompiler
// Type: arc.net.TcpConnection
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
  internal class TcpConnection : Object
  {
    internal SocketChannel socketChannel;
    internal int keepAliveMillis;
    [Modifiers]
    internal ByteBuffer readBuffer;
    [Modifiers]
    internal ByteBuffer writeBuffer;
    internal bool bufferPositionFix;
    internal int timeoutMillis;
    internal float idleThreshold;
    [Modifiers]
    internal NetSerializer serialization;
    private SelectionKey selectionKey;
    private volatile long lastWriteTime;
    private volatile long lastReadTime;
    private int currentObjectLength;
    [Modifiers]
    private object writeLock;

    [LineNumberTable(new byte[] {159, 170, 232, 52, 171, 107, 235, 70, 171, 103, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TcpConnection([In] NetSerializer obj0, [In] int obj1, [In] int obj2)
    {
      TcpConnection tcpConnection = this;
      this.keepAliveMillis = 8000;
      this.timeoutMillis = 12000;
      this.idleThreshold = 0.1f;
      this.writeLock = (object) new Object();
      this.serialization = obj0;
      this.writeBuffer = ByteBuffer.allocate(obj1);
      this.readBuffer = ByteBuffer.allocate(obj2);
      ((Buffer) this.readBuffer).flip();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 69, 103, 99, 112, 141, 108, 204, 185, 223, 3, 228, 84, 241, 41, 98, 112, 255, 2, 85, 231, 45, 173, 109, 119, 174, 171, 175, 177, 116, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int send([In] object obj0)
    {
      if (this.socketChannel == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SocketException("Connection is closed.");
      }
      object writeLock;
      System.Threading.Monitor.Enter(writeLock = this.writeLock);
      int num1;
      int lengthLength;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        num1 = ((Buffer) this.writeBuffer).position();
        lengthLength = this.serialization.getLengthLength();
        try
        {
          ((Buffer) this.writeBuffer).position(((Buffer) this.writeBuffer).position() + lengthLength);
          this.serialization.write(this.writeBuffer, obj0);
          goto label_10;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        System.Threading.Monitor.Exit(writeLock);
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string message = new StringBuilder().append("Error serializing object of type: ").append(Object.instancehelper_getClass(obj0).getName()).toString();
        Exception cause = exception3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcNetException(message, cause);
      }
      __fault
      {
        System.Threading.Monitor.Exit(writeLock);
      }
label_10:
      int num2;
      try
      {
        int num3 = ((Buffer) this.writeBuffer).position();
        ((Buffer) this.writeBuffer).position(num1);
        this.serialization.writeLength(this.writeBuffer, num3 - lengthLength - num1);
        ((Buffer) this.writeBuffer).position(num3);
        if (num1 == 0 && !this.writeToSocket())
          this.selectionKey.interestOps(5);
        else
          this.selectionKey.selector().wakeup();
        ByteCodeHelper.VolatileWrite(ref this.lastWriteTime, java.lang.System.currentTimeMillis());
        num2 = num3 - num1;
      }
      finally
      {
        System.Threading.Monitor.Exit(writeLock);
      }
      return num2;
    }

    [LineNumberTable(new byte[] {160, 111, 104, 107, 103, 104, 188, 34, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      try
      {
        if (this.socketChannel == null)
          return;
        ((AbstractInterruptibleChannel) this.socketChannel).close();
        this.socketChannel = (SocketChannel) null;
        if (this.selectionKey == null)
          return;
        this.selectionKey.selector().wakeup();
      }
      catch (IOException ex)
      {
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {9, 102, 108, 108, 108, 135, 108, 103, 135, 104, 104, 135, 110, 141, 255, 27, 70, 226, 59, 98, 102, 159, 4, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connect([In] Selector obj0, [In] SocketAddress obj1, [In] int obj2)
    {
      this.close();
      ((Buffer) this.writeBuffer).clear();
      ((Buffer) this.readBuffer).clear();
      ((Buffer) this.readBuffer).flip();
      this.currentObjectLength = 0;
      IOException ioException1;
      try
      {
        SocketChannel socketChannel = obj0.provider().openSocketChannel();
        Socket socket = socketChannel.socket();
        socket.setTcpNoDelay(true);
        socket.connect(obj1, obj2);
        ((AbstractSelectableChannel) socketChannel).configureBlocking(false);
        this.socketChannel = socketChannel;
        this.selectionKey = ((SelectableChannel) socketChannel).register(obj0, 1);
        this.selectionKey.attach((object) this);
        TcpConnection tcpConnection = this;
        long num1 = java.lang.System.currentTimeMillis();
        long num2 = num1;
        ByteCodeHelper.VolatileWrite(ref this.lastWriteTime, num1);
        ByteCodeHelper.VolatileWrite(ref this.lastReadTime, num2);
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      this.close();
      throw Throwable.__\u003Cunmap\u003E((Exception) new IOException(new StringBuilder().append("Unable to connect to: ").append((object) obj1).toString(), (Exception) ioException2));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {36, 103, 99, 144, 139, 108, 110, 108, 109, 108, 100, 112, 146, 110, 130, 151, 105, 159, 11, 115, 255, 11, 69, 103, 142, 108, 109, 108, 100, 112, 148, 110, 130, 135, 108, 109, 175, 191, 13, 2, 98, 178, 110, 112, 120, 191, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readObject()
    {
      SocketChannel socketChannel = this.socketChannel;
      if (socketChannel == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SocketException("Connection is closed.");
      }
      if (this.currentObjectLength == 0)
      {
        int lengthLength = this.serialization.getLengthLength();
        if (((Buffer) this.readBuffer).remaining() < lengthLength)
        {
          this.readBuffer.compact();
          int num = socketChannel.read(this.readBuffer);
          ((Buffer) this.readBuffer).flip();
          if (num == -1)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new SocketException("Connection is closed.");
          }
          ByteCodeHelper.VolatileWrite(ref this.lastReadTime, java.lang.System.currentTimeMillis());
          if (((Buffer) this.readBuffer).remaining() < lengthLength)
            return (object) null;
        }
        this.currentObjectLength = this.serialization.readLength(this.readBuffer);
        if (this.currentObjectLength <= 0)
        {
          string message = new StringBuilder().append("Invalid object length: ").append(this.currentObjectLength).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcNetException(message);
        }
        if (this.currentObjectLength > ((Buffer) this.readBuffer).capacity())
        {
          string message = new StringBuilder().append("Unable to read object larger than read buffer: ").append(this.currentObjectLength).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcNetException(message);
        }
      }
      int currentObjectLength = this.currentObjectLength;
      if (((Buffer) this.readBuffer).remaining() < currentObjectLength)
      {
        this.readBuffer.compact();
        int num = socketChannel.read(this.readBuffer);
        ((Buffer) this.readBuffer).flip();
        if (num == -1)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new SocketException("Connection is closed.");
        }
        ByteCodeHelper.VolatileWrite(ref this.lastReadTime, java.lang.System.currentTimeMillis());
        if (((Buffer) this.readBuffer).remaining() < currentObjectLength)
          return (object) null;
      }
      this.currentObjectLength = 0;
      int num1 = ((Buffer) this.readBuffer).position();
      int num2 = ((Buffer) this.readBuffer).limit();
      ((Buffer) this.readBuffer).limit(num1 + currentObjectLength);
      object obj;
      Exception exception1;
      try
      {
        obj = this.serialization.read(this.readBuffer);
        goto label_23;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcNetException("Error during deserialization.", (Exception) exception2);
label_23:
      ((Buffer) this.readBuffer).limit(num2);
      if (((Buffer) this.readBuffer).position() - num1 != currentObjectLength)
      {
        string message = new StringBuilder().append("Incorrect number of bytes (").append(num1 + currentObjectLength - ((Buffer) this.readBuffer).position()).append(" remaining) used to deserialize object: ").append(obj).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcNetException(message);
      }
      return obj;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {100, 109, 136, 141, 114, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeOperation()
    {
      lock (this.writeLock)
      {
        if (this.writeToSocket())
          this.selectionKey.interestOps(1);
        ByteCodeHelper.VolatileWrite(ref this.lastWriteTime, java.lang.System.currentTimeMillis());
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTimedOut([In] long obj0) => this.socketChannel != null && this.timeoutMillis > 0 && obj0 - ByteCodeHelper.VolatileRead(ref this.lastReadTime) > (long) this.timeoutMillis;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool needsKeepAlive([In] long obj0) => this.socketChannel != null && this.keepAliveMillis > 0 && obj0 - ByteCodeHelper.VolatileRead(ref this.lastWriteTime) > (long) this.keepAliveMillis;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 178, 108, 108, 108, 135, 103, 104, 103, 135, 174, 159, 5, 127, 2, 98, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SelectionKey accept([In] Selector obj0, [In] SocketChannel obj1)
    {
      ((Buffer) this.writeBuffer).clear();
      ((Buffer) this.readBuffer).clear();
      ((Buffer) this.readBuffer).flip();
      this.currentObjectLength = 0;
      SelectionKey selectionKey;
      IOException ioException1;
      try
      {
        this.socketChannel = obj1;
        ((AbstractSelectableChannel) obj1).configureBlocking(false);
        obj1.socket().setTcpNoDelay(true);
        this.selectionKey = ((SelectableChannel) obj1).register(obj0, 1);
        TcpConnection tcpConnection = this;
        long num1 = java.lang.System.currentTimeMillis();
        long num2 = num1;
        ByteCodeHelper.VolatileWrite(ref this.lastWriteTime, num1);
        ByteCodeHelper.VolatileWrite(ref this.lastReadTime, num2);
        selectionKey = this.selectionKey;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_4;
      }
      return selectionKey;
label_4:
      IOException ioException2 = ioException1;
      this.close();
      throw Throwable.__\u003Cunmap\u003E((Exception) ioException2);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {110, 103, 99, 144, 103, 103, 104, 104, 103, 135, 105, 130, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool writeToSocket()
    {
      SocketChannel socketChannel = this.socketChannel;
      if (socketChannel == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SocketException("Connection is closed.");
      }
      ByteBuffer writeBuffer = this.writeBuffer;
      ((Buffer) writeBuffer).flip();
      while (((Buffer) writeBuffer).hasRemaining())
      {
        if (this.bufferPositionFix)
        {
          writeBuffer.compact();
          ((Buffer) writeBuffer).flip();
        }
        if (socketChannel.write(writeBuffer) == 0)
          break;
      }
      writeBuffer.compact();
      return ((Buffer) writeBuffer).position() == 0;
    }
  }
}
