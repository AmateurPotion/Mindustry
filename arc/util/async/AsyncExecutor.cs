// Decompiled with JetBrains decompiler
// Type: arc.util.async.AsyncExecutor
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

namespace arc.util.async
{
  public class AsyncExecutor : Object, Disposable
  {
    [Modifiers]
    private ExecutorService executor;

    [LineNumberTable(new byte[] {159, 163, 104, 246, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AsyncExecutor(int maxConcurrent)
    {
      AsyncExecutor asyncExecutor = this;
      this.executor = Executors.newFixedThreadPool(maxConcurrent, (ThreadFactory) new AsyncExecutor.__\u003C\u003EAnon0());
    }

    [Signature("(Ljava/lang/Runnable;)Larc/util/async/AsyncResult<Ljava/lang/Void;>;")]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AsyncResult submit(Runnable run) => this.submit((AsyncTask) new AsyncExecutor.__\u003C\u003EAnon1(run));

    [Signature("<T:Ljava/lang/Object;>(Larc/util/async/AsyncTask<TT;>;)Larc/util/async/AsyncResult<TT;>;")]
    [LineNumberTable(new byte[] {159, 185, 109, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AsyncResult submit(AsyncTask task)
    {
      if (this.executor.isShutdown())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Cannot run tasks on an executor that has been shutdown (disposed)");
      }
      ExecutorService executor = this.executor;
      AsyncTask asyncTask = task;
      Objects.requireNonNull((object) asyncTask);
      Callable callable = (Callable) new AsyncExecutor.__\u003C\u003EAnon2(asyncTask);
      return new AsyncResult(executor.submit(callable));
    }

    [LineNumberTable(new byte[] {5, 139, 191, 13, 2, 97, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.executor.shutdown();
      InterruptedException interruptedException1;
      try
      {
        this.executor.awaitTermination(long.MaxValue, (TimeUnit) TimeUnit.SECONDS);
        return;
      }
      catch (InterruptedException ex)
      {
        interruptedException1 = (InterruptedException) ByteCodeHelper.MapException<InterruptedException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      InterruptedException interruptedException2 = interruptedException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("Couldn't shutdown loading thread", (Exception) interruptedException2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 165, 108, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Thread lambda\u0024new\u00241([In] Runnable obj0)
    {
      Thread thread = new Thread(obj0, "AsynchExecutor-Thread");
      thread.setDaemon(true);
      thread.setUncaughtExceptionHandler((Thread.UncaughtExceptionHandler) new AsyncExecutor.__\u003C\u003EAnon3());
      return thread;
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Void lambda\u0024submit\u00242([In] Runnable obj0)
    {
      obj0.run();
      return (Void) null;
    }

    [Modifiers]
    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] Thread obj0, [In] Exception obj1) => Throwable.instancehelper_printStackTrace(obj1);

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : ThreadFactory
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public Thread newThread([In] Runnable obj0) => AsyncExecutor.lambda\u0024new\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : AsyncTask
    {
      private readonly Runnable arg\u00241;

      internal __\u003C\u003EAnon1([In] Runnable obj0) => this.arg\u00241 = obj0;

      public object call() => (object) AsyncExecutor.lambda\u0024submit\u00242(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Callable
    {
      private readonly AsyncTask arg\u00241;

      internal __\u003C\u003EAnon2([In] AsyncTask obj0) => this.arg\u00241 = obj0;

      public object call() => this.arg\u00241.call();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Thread.UncaughtExceptionHandler
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void uncaughtException([In] Thread obj0, [In] Exception obj1) => AsyncExecutor.lambda\u0024new\u00240(obj0, obj1);
    }
  }
}
