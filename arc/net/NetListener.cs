// Decompiled with JetBrains decompiler
// Type: arc.net.NetListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.concurrent;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.net
{
  public interface NetListener
  {
    [Modifiers]
    void connected(Connection connection);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Econnected([In] NetListener obj0, [In] Connection obj1)
    {
    }

    [Modifiers]
    void disconnected(Connection connection, DcReason reason);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Edisconnected([In] NetListener obj0, [In] Connection obj1, [In] DcReason obj2)
    {
    }

    [Modifiers]
    void received(Connection connection, object @object);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Ereceived([In] NetListener obj0, [In] Connection obj1, [In] object obj2)
    {
    }

    [Modifiers]
    void idle(Connection connection);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eidle([In] NetListener obj0, [In] Connection obj1)
    {
    }

    class LagListener : NetListener.QueuedListener
    {
      [Modifiers]
      private ScheduledExecutorService threadPool;
      [Modifiers]
      private int lagMillisMin;
      [Modifiers]
      private int lagMillisMax;
      [Modifiers]
      [Signature("Ljava/util/LinkedList<Ljava/lang/Runnable;>;")]
      internal LinkedList runnables;

      [Modifiers]
      [LineNumberTable(new byte[] {84, 109, 113, 111, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024queue\u00240()
      {
        Runnable runnable;
        lock (this.runnables)
          runnable = (Runnable) this.runnables.removeLast();
        runnable.run();
      }

      [LineNumberTable(new byte[] {71, 233, 60, 235, 69, 103, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LagListener(int lagMillisMin, int lagMillisMax, NetListener listener)
        : base(listener)
      {
        NetListener.LagListener lagListener = this;
        this.runnables = new LinkedList();
        this.lagMillisMin = lagMillisMin;
        this.lagMillisMax = lagMillisMax;
        this.threadPool = Executors.newScheduledThreadPool(1);
      }

      [LineNumberTable(new byte[] {78, 109, 108, 111, 127, 4, 254, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void queue(Runnable runnable)
      {
        lock (this.runnables)
          this.runnables.addFirst((object) runnable);
        this.threadPool.schedule((Runnable) new NetListener.LagListener.__\u003C\u003EAnon0(this), (long) (this.lagMillisMin + ByteCodeHelper.d2i(Math.random() * (double) (this.lagMillisMax - this.lagMillisMin))), (TimeUnit) TimeUnit.MILLISECONDS);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly NetListener.LagListener arg\u00241;

        internal __\u003C\u003EAnon0([In] NetListener.LagListener obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024queue\u00240();
      }
    }

    abstract class QueuedListener : Object, NetListener
    {
      [Modifiers]
      internal NetListener listener;

      protected internal abstract void queue(Runnable r);

      [Modifiers]
      [LineNumberTable(61)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024connected\u00240([In] Connection obj0) => this.listener.connected(obj0);

      [Modifiers]
      [LineNumberTable(65)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024disconnected\u00241([In] Connection obj0, [In] DcReason obj1) => this.listener.disconnected(obj0, obj1);

      [Modifiers]
      [LineNumberTable(69)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024received\u00242([In] Connection obj0, [In] object obj1) => this.listener.received(obj0, obj1);

      [Modifiers]
      [LineNumberTable(73)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024idle\u00243([In] Connection obj0) => this.listener.idle(obj0);

      [LineNumberTable(new byte[] {4, 104, 99, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public QueuedListener(NetListener listener)
      {
        NetListener.QueuedListener queuedListener = this;
        if (listener == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("listener cannot be null.");
        }
        this.listener = listener;
      }

      [LineNumberTable(new byte[] {11, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void connected(Connection connection) => this.queue((Runnable) new NetListener.QueuedListener.__\u003C\u003EAnon0(this, connection));

      [LineNumberTable(new byte[] {15, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void disconnected(Connection connection, DcReason reason) => this.queue((Runnable) new NetListener.QueuedListener.__\u003C\u003EAnon1(this, connection, reason));

      [LineNumberTable(new byte[] {19, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void received(Connection connection, object @object) => this.queue((Runnable) new NetListener.QueuedListener.__\u003C\u003EAnon2(this, connection, @object));

      [LineNumberTable(new byte[] {23, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void idle(Connection connection) => this.queue((Runnable) new NetListener.QueuedListener.__\u003C\u003EAnon3(this, connection));

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly NetListener.QueuedListener arg\u00241;
        private readonly Connection arg\u00242;

        internal __\u003C\u003EAnon0([In] NetListener.QueuedListener obj0, [In] Connection obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024connected\u00240(this.arg\u00242);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly NetListener.QueuedListener arg\u00241;
        private readonly Connection arg\u00242;
        private readonly DcReason arg\u00243;

        internal __\u003C\u003EAnon1(
          [In] NetListener.QueuedListener obj0,
          [In] Connection obj1,
          [In] DcReason obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024disconnected\u00241(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly NetListener.QueuedListener arg\u00241;
        private readonly Connection arg\u00242;
        private readonly object arg\u00243;

        internal __\u003C\u003EAnon2([In] NetListener.QueuedListener obj0, [In] Connection obj1, [In] object obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024received\u00242(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly NetListener.QueuedListener arg\u00241;
        private readonly Connection arg\u00242;

        internal __\u003C\u003EAnon3([In] NetListener.QueuedListener obj0, [In] Connection obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024idle\u00243(this.arg\u00242);
      }
    }

    class ThreadedListener : NetListener.QueuedListener
    {
      internal ExecutorService __\u003C\u003EthreadPool;

      [LineNumberTable(new byte[] {46, 105, 99, 144, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ThreadedListener(NetListener listener, ExecutorService threadPool)
        : base(listener)
      {
        NetListener.ThreadedListener threadedListener = this;
        if (threadPool == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("threadPool cannot be null.");
        }
        this.__\u003C\u003EthreadPool = threadPool;
      }

      [LineNumberTable(new byte[] {39, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ThreadedListener(NetListener listener)
        : this(listener, Executors.newFixedThreadPool(1))
      {
      }

      [LineNumberTable(new byte[] {54, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void queue(Runnable runnable) => ((Executor) this.__\u003C\u003EthreadPool).execute(runnable);

      [Modifiers]
      protected internal ExecutorService threadPool
      {
        [HideFromJava] get => this.__\u003C\u003EthreadPool;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EthreadPool = value;
      }
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static void connected([In] NetListener obj0, [In] Connection obj1)
      {
        NetListener netListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(netListener, ToString);
        NetListener.\u003Cdefault\u003Econnected(netListener, obj1);
      }

      public static void disconnected([In] NetListener obj0, [In] Connection obj1, [In] DcReason obj2)
      {
        NetListener netListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(netListener, ToString);
        NetListener.\u003Cdefault\u003Edisconnected(netListener, obj1, obj2);
      }

      public static void received([In] NetListener obj0, [In] Connection obj1, [In] object obj2)
      {
        NetListener netListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(netListener, ToString);
        NetListener.\u003Cdefault\u003Ereceived(netListener, obj1, obj2);
      }

      public static void idle([In] NetListener obj0, [In] Connection obj1)
      {
        NetListener netListener = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(netListener, ToString);
        NetListener.\u003Cdefault\u003Eidle(netListener, obj1);
      }
    }
  }
}
