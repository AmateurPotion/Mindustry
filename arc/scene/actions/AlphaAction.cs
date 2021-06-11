// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.AlphaAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class AlphaAction : TemporalAction
  {
    private float start;
    private float end;
    private Color color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAlpha(float alpha) => this.end = alpha;

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AlphaAction()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 121, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void begin()
    {
      if (this.color == null)
        this.color = this.target.__\u003C\u003Ecolor;
      this.start = this.color.a;
    }

    [LineNumberTable(new byte[] {159, 165, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void update(float percent) => this.color.a = this.start + (this.end - this.start) * percent;

    [LineNumberTable(new byte[] {159, 170, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      base.reset();
      this.color = (Color) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Color getColor() => this.color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(Color color) => this.color = color;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAlpha() => this.end;
  }
}
