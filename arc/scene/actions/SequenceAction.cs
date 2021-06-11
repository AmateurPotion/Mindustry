// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.SequenceAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.pooling;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class SequenceAction : ParallelAction
  {
    private int index;

    [LineNumberTable(new byte[] {159, 155, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SequenceAction()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SequenceAction(Action action1)
    {
      SequenceAction sequenceAction = this;
      this.addAction(action1);
    }

    [LineNumberTable(new byte[] {159, 162, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SequenceAction(Action action1, Action action2)
    {
      SequenceAction sequenceAction = this;
      this.addAction(action1);
      this.addAction(action2);
    }

    [LineNumberTable(new byte[] {159, 167, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SequenceAction(Action action1, Action action2, Action action3)
    {
      SequenceAction sequenceAction = this;
      this.addAction(action1);
      this.addAction(action2);
      this.addAction(action3);
    }

    [LineNumberTable(new byte[] {159, 173, 104, 103, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SequenceAction(Action action1, Action action2, Action action3, Action action4)
    {
      SequenceAction sequenceAction = this;
      this.addAction(action1);
      this.addAction(action2);
      this.addAction(action3);
      this.addAction(action4);
    }

    [LineNumberTable(new byte[] {159, 180, 104, 103, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SequenceAction(
      Action action1,
      Action action2,
      Action action3,
      Action action4,
      Action action5)
    {
      SequenceAction sequenceAction = this;
      this.addAction(action1);
      this.addAction(action2);
      this.addAction(action3);
      this.addAction(action4);
      this.addAction(action5);
    }

    [LineNumberTable(new byte[] {159, 190, 117, 103, 135, 127, 0, 242, 70, 103, 39, 231, 58, 98, 110, 219, 103, 35, 231, 60, 130, 134, 103, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      if (this.index >= this.actions.size)
        return true;
      Pool pool = this.getPool();
      this.setPool((Pool) null);
      int num;
      // ISSUE: fault handler
      try
      {
        if (((Action) this.actions.get(this.index)).act(delta))
        {
          if (this.actor == null)
            num = 1;
          else
            goto label_8;
        }
        else
          goto label_11;
      }
      __fault
      {
        this.setPool(pool);
      }
      this.setPool(pool);
      return num != 0;
label_8:
      // ISSUE: fault handler
      try
      {
        ++this.index;
        num = this.index >= this.actions.size ? 1 : 0;
      }
      __fault
      {
        this.setPool(pool);
      }
      this.setPool(pool);
      return num != 0;
label_11:
      try
      {
        return false;
      }
      finally
      {
        this.setPool(pool);
      }
    }

    [LineNumberTable(new byte[] {15, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void restart()
    {
      base.restart();
      this.index = 0;
    }
  }
}
