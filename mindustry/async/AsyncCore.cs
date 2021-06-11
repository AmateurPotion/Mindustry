// Decompiled with JetBrains decompiler
// Type: mindustry.async.AsyncCore
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.concurrent;
using mindustry.game;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.async
{
  public class AsyncCore : Object
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/async/AsyncProcess;>;")]
    private Seq processes;
    [Modifiers]
    [Signature("Larc/struct/Seq<Ljava/util/concurrent/Future<*>;>;")]
    private Seq futures;
    [Modifiers]
    private ExecutorService executor;

    [LineNumberTable(new byte[] {159, 186, 143, 127, 1, 102, 130, 172, 127, 1, 104, 159, 9, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void begin()
    {
      if (!Vars.state.isPlaying())
        return;
      Iterator iterator1 = this.processes.iterator();
      while (iterator1.hasNext())
        ((AsyncProcess) iterator1.next()).begin();
      this.futures.clear();
      Iterator iterator2 = this.processes.iterator();
      while (iterator2.hasNext())
      {
        AsyncProcess asyncProcess1 = (AsyncProcess) iterator2.next();
        if (asyncProcess1.shouldProcess())
        {
          Seq futures = this.futures;
          ExecutorService executor = this.executor;
          AsyncProcess asyncProcess2 = asyncProcess1;
          Objects.requireNonNull((object) asyncProcess2);
          Runnable runnable = (Runnable) new AsyncCore.__\u003C\u003EAnon3(asyncProcess2);
          Future future = executor.submit(runnable);
          futures.add((object) future);
        }
      }
    }

    [LineNumberTable(new byte[] {12, 108, 166, 127, 1, 102, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void end()
    {
      if (!Vars.state.isPlaying())
        return;
      this.complete();
      Iterator iterator = this.processes.iterator();
      while (iterator.hasNext())
        ((AsyncProcess) iterator.next()).end();
    }

    [LineNumberTable(new byte[] {159, 169, 232, 50, 249, 69, 139, 255, 1, 72, 245, 71, 245, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AsyncCore()
    {
      AsyncCore asyncCore = this;
      this.processes = Seq.with((object[]) new AsyncProcess[1]
      {
        (AsyncProcess) new PhysicsProcess()
      });
      this.futures = new Seq();
      this.executor = Executors.newFixedThreadPool(this.processes.size, (ThreadFactory) new AsyncCore.__\u003C\u003EAnon0());
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new AsyncCore.__\u003C\u003EAnon1(this));
      Events.on((Class) ClassLiteral<EventType.ResetEvent>.Value, (Cons) new AsyncCore.__\u003C\u003EAnon2(this));
    }

    [LineNumberTable(new byte[] {24, 159, 1, 185, 2, 97, 140, 162, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void complete()
    {
      Iterator iterator = this.futures.iterator();
      while (iterator.hasNext())
      {
        Future future = (Future) iterator.next();
        Exception exception1;
        try
        {
          future.get();
          continue;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception exception2 = exception1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException(exception2);
      }
      this.futures.clear();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 163, 108, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Thread lambda\u0024new\u00242([In] Runnable obj0)
    {
      Thread thread = new Thread(obj0, "AsyncLogic-Thread");
      thread.setDaemon(true);
      thread.setUncaughtExceptionHandler((Thread.UncaughtExceptionHandler) new AsyncCore.__\u003C\u003EAnon4());
      return thread;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 171, 102, 127, 1, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] EventType.WorldLoadEvent obj0)
    {
      this.complete();
      Iterator iterator = this.processes.iterator();
      while (iterator.hasNext())
        ((AsyncProcess) iterator.next()).init();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 178, 102, 127, 1, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00244([In] EventType.ResetEvent obj0)
    {
      this.complete();
      Iterator iterator = this.processes.iterator();
      while (iterator.hasNext())
        ((AsyncProcess) iterator.next()).reset();
    }

    [Modifiers]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] Thread obj0, [In] Exception obj1) => Core.app.post((Runnable) new AsyncCore.__\u003C\u003EAnon5(obj1));

    [Modifiers]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] Exception obj0)
    {
      Exception exception = obj0;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(exception);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : ThreadFactory
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public Thread newThread([In] Runnable obj0) => AsyncCore.lambda\u0024new\u00242(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly AsyncCore arg\u00241;

      internal __\u003C\u003EAnon1([In] AsyncCore obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly AsyncCore arg\u00241;

      internal __\u003C\u003EAnon2([In] AsyncCore obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00244((EventType.ResetEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly AsyncProcess arg\u00241;

      internal __\u003C\u003EAnon3([In] AsyncProcess obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.process();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Thread.UncaughtExceptionHandler
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void uncaughtException([In] Thread obj0, [In] Exception obj1) => AsyncCore.lambda\u0024new\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly Exception arg\u00241;

      internal __\u003C\u003EAnon5([In] Exception obj0) => this.arg\u00241 = obj0;

      public void run() => AsyncCore.lambda\u0024new\u00240(this.arg\u00241);
    }
  }
}
