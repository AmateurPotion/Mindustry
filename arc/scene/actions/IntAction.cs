// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.IntAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class IntAction : TemporalAction
  {
    private int start;
    private int end;
    private int value;

    [LineNumberTable(new byte[] {159, 154, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntAction()
    {
      IntAction intAction = this;
      this.start = 0;
      this.end = 1;
    }

    [LineNumberTable(new byte[] {159, 160, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntAction(int start, int end)
    {
      IntAction intAction = this;
      this.start = start;
      this.end = end;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void begin() => this.value = this.start;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void update(float percent) => this.value = ByteCodeHelper.f2i((float) this.start + (float) (this.end - this.start) * percent);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getValue() => this.value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(int value) => this.value = value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getStart() => this.start;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStart(int start) => this.start = start;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getEnd() => this.end;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEnd(int end) => this.end = end;
  }
}
