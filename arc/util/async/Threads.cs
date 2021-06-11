// Decompiled with JetBrains decompiler
// Type: arc.util.async.Threads
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.async
{
  public class Threads : Object
  {
    [LineNumberTable(new byte[] {159, 167, 185, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sleep(long ms, int ns)
    {
      InterruptedException interruptedException1;
      try
      {
        Thread.sleep(ms, ns);
        return;
      }
      catch (InterruptedException ex)
      {
        interruptedException1 = (InterruptedException) ByteCodeHelper.MapException<InterruptedException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      InterruptedException interruptedException2 = interruptedException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) interruptedException2);
    }

    [LineNumberTable(new byte[] {159, 189, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Thread daemon(Runnable runnable)
    {
      Thread thread = new Thread(runnable);
      thread.setDaemon(true);
      thread.start();
      return thread;
    }

    [LineNumberTable(new byte[] {159, 175, 182})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void throwAppException(Exception t) => Time.runTask(0.0f, (Runnable) new Threads.__\u003C\u003EAnon0(t));

    [LineNumberTable(new byte[] {5, 104, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Thread daemon(string name, Runnable runnable)
    {
      Thread thread = new Thread(runnable, name);
      thread.setDaemon(true);
      thread.start();
      return thread;
    }

    [LineNumberTable(new byte[] {159, 159, 184, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sleep(long ms)
    {
      InterruptedException interruptedException1;
      try
      {
        Thread.sleep(ms);
        return;
      }
      catch (InterruptedException ex)
      {
        interruptedException1 = (InterruptedException) ByteCodeHelper.MapException<InterruptedException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      InterruptedException interruptedException2 = interruptedException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) interruptedException2);
    }

    [LineNumberTable(new byte[] {159, 154, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void yield() => Thread.yield();

    [Modifiers]
    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024throwAppException\u00240([In] Exception obj0)
    {
      Exception exception = obj0;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(exception);
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Threads()
    {
    }

    [LineNumberTable(new byte[] {159, 182, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Thread thread(Runnable runnable)
    {
      Thread thread = new Thread(runnable);
      thread.start();
      return thread;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Exception arg\u00241;

      internal __\u003C\u003EAnon0([In] Exception obj0) => this.arg\u00241 = obj0;

      public void run() => Threads.lambda\u0024throwAppException\u00240(this.arg\u00241);
    }
  }
}
