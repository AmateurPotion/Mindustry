// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.ParallelAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util.pooling;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class ParallelAction : Action
  {
    [Signature("Larc/struct/Seq<Larc/scene/Action;>;")]
    internal Seq actions;
    private bool complete;

    [LineNumberTable(new byte[] {33, 108, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAction(Action action)
    {
      this.actions.add((object) action);
      if (this.actor == null)
        return;
      action.setActor(this.actor);
    }

    [LineNumberTable(new byte[] {159, 158, 232, 61, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParallelAction()
    {
      ParallelAction parallelAction = this;
      this.actions = new Seq(4);
    }

    [LineNumberTable(new byte[] {159, 161, 232, 58, 236, 71, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParallelAction(Action action1)
    {
      ParallelAction parallelAction = this;
      this.actions = new Seq(4);
      this.addAction(action1);
    }

    [LineNumberTable(new byte[] {159, 165, 232, 54, 236, 75, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParallelAction(Action action1, Action action2)
    {
      ParallelAction parallelAction = this;
      this.actions = new Seq(4);
      this.addAction(action1);
      this.addAction(action2);
    }

    [LineNumberTable(new byte[] {159, 170, 232, 49, 236, 80, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParallelAction(Action action1, Action action2, Action action3)
    {
      ParallelAction parallelAction = this;
      this.actions = new Seq(4);
      this.addAction(action1);
      this.addAction(action2);
      this.addAction(action3);
    }

    [LineNumberTable(new byte[] {159, 176, 232, 43, 236, 86, 103, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParallelAction(Action action1, Action action2, Action action3, Action action4)
    {
      ParallelAction parallelAction = this;
      this.actions = new Seq(4);
      this.addAction(action1);
      this.addAction(action2);
      this.addAction(action3);
      this.addAction(action4);
    }

    [LineNumberTable(new byte[] {159, 183, 232, 36, 236, 93, 103, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParallelAction(
      Action action1,
      Action action2,
      Action action3,
      Action action4,
      Action action5)
    {
      ParallelAction parallelAction = this;
      this.actions = new Seq(4);
      this.addAction(action1);
      this.addAction(action2);
      this.addAction(action3);
      this.addAction(action4);
      this.addAction(action5);
    }

    [LineNumberTable(new byte[] {1, 106, 103, 103, 135, 103, 237, 71, 103, 239, 57, 110, 123, 211, 103, 39, 231, 60, 227, 61, 232, 71, 103, 230, 61, 139, 103, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool act(float delta)
    {
      if (this.complete)
        return true;
      this.complete = true;
      Pool pool = this.getPool();
      this.setPool((Pool) null);
      Seq actions;
      int index;
      int size;
      // ISSUE: fault handler
      try
      {
        actions = this.actions;
        index = 0;
        size = actions.size;
      }
      __fault
      {
        this.setPool(pool);
      }
      int num;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            if (this.actor != null)
            {
              Action action = (Action) actions.get(index);
              if (action.getActor() != null && !action.act(delta))
                this.complete = false;
              if (this.actor == null)
              {
                num = 1;
                break;
              }
            }
            else
              goto label_15;
          }
          else
            goto label_15;
        }
        __fault
        {
          this.setPool(pool);
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          this.setPool(pool);
        }
      }
      this.setPool(pool);
      return num != 0;
label_15:
      try
      {
        return this.complete;
      }
      finally
      {
        this.setPool(pool);
      }
    }

    [LineNumberTable(new byte[] {20, 103, 103, 109, 49, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void restart()
    {
      this.complete = false;
      Seq actions = this.actions;
      int index = 0;
      for (int size = actions.size; index < size; ++index)
        ((Action) actions.get(index)).restart();
    }

    [LineNumberTable(new byte[] {28, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      base.reset();
      this.actions.clear();
    }

    [LineNumberTable(new byte[] {39, 103, 109, 50, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setActor(Element actor)
    {
      Seq actions = this.actions;
      int index = 0;
      for (int size = actions.size; index < size; ++index)
        ((Action) actions.get(index)).setActor(actor);
      base.setActor(actor);
    }

    [Signature("()Larc/struct/Seq<Larc/scene/Action;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getActions() => this.actions;

    [LineNumberTable(new byte[] {50, 104, 109, 105, 103, 109, 112, 14, 198, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString()
    {
      StringBuilder stringBuilder = new StringBuilder(64);
      stringBuilder.append(base.toString());
      stringBuilder.append('(');
      Seq actions = this.actions;
      int index = 0;
      for (int size = actions.size; index < size; ++index)
      {
        if (index > 0)
          stringBuilder.append(", ");
        stringBuilder.append(actions.get(index));
      }
      stringBuilder.append(')');
      return stringBuilder.toString();
    }
  }
}
