// Decompiled with JetBrains decompiler
// Type: arc.util.TaskQueue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class TaskQueue : Object
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Ljava/lang/Runnable;>;")]
    private Seq runnables;
    [Modifiers]
    [Signature("Larc/struct/Seq<Ljava/lang/Runnable;>;")]
    private Seq executedRunnables;

    [LineNumberTable(new byte[] {159, 147, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TaskQueue()
    {
      TaskQueue taskQueue = this;
      this.runnables = new Seq();
      this.executedRunnables = new Seq();
    }

    [LineNumberTable(new byte[] {159, 168, 109, 108, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      lock (this.runnables)
        this.runnables.clear();
    }

    [LineNumberTable(new byte[] {159, 174, 109, 108, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void post(Runnable runnable)
    {
      lock (this.runnables)
        this.runnables.add((object) runnable);
    }

    [LineNumberTable(new byte[] {159, 152, 109, 108, 114, 108, 143, 127, 1, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void run()
    {
      lock (this.runnables)
      {
        this.executedRunnables.clear();
        this.executedRunnables.addAll(this.runnables);
        this.runnables.clear();
      }
      Iterator iterator = this.executedRunnables.iterator();
      while (iterator.hasNext())
        ((Runnable) iterator.next()).run();
    }

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.runnables.size;
  }
}
