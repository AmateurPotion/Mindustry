// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.RepeatAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class RepeatAction : DelegateAction
  {
    public const int FOREVER = -1;
    private int repeatCount;
    private int executedCount;
    private bool finished;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCount(int count) => this.repeatCount = count;

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RepeatAction()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 112, 111, 106, 119, 112, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool @delegate(float delta)
    {
      if (this.executedCount == this.repeatCount)
        return true;
      if (this.action.act(delta))
      {
        if (this.finished)
          return true;
        if (this.repeatCount > 0)
          ++this.executedCount;
        if (this.executedCount == this.repeatCount)
          return true;
        if (this.action != null)
          this.action.restart();
      }
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void finish() => this.finished = true;

    [LineNumberTable(new byte[] {159, 174, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void restart()
    {
      base.restart();
      this.executedCount = 0;
      this.finished = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCount() => this.repeatCount;
  }
}
