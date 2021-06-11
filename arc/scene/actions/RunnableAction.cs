// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.RunnableAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.pooling;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class RunnableAction : Action
  {
    private Runnable runnable;
    private bool ran;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRunnable(Runnable runnable) => this.runnable = runnable;

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RunnableAction()
    {
    }

    [LineNumberTable(new byte[] {159, 168, 103, 135, 143, 103, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void run()
    {
      Pool pool = this.getPool();
      this.setPool((Pool) null);
      try
      {
        this.runnable.run();
      }
      finally
      {
        this.setPool(pool);
      }
    }

    [LineNumberTable(new byte[] {159, 159, 104, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      if (!this.ran)
      {
        this.ran = true;
        this.run();
      }
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void restart() => this.ran = false;

    [LineNumberTable(new byte[] {159, 184, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      base.reset();
      this.runnable = (Runnable) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Runnable getRunnable() => this.runnable;
  }
}
