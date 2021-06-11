// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.ColorAction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.actions
{
  public class ColorAction : TemporalAction
  {
    [Modifiers]
    private Color end;
    private float startR;
    private float startG;
    private float startB;
    private float startA;
    private Color color;

    [LineNumberTable(new byte[] {8, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEndColor(Color color) => this.end.set(color);

    [LineNumberTable(new byte[] {159, 153, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ColorAction()
    {
      ColorAction colorAction = this;
      this.end = new Color();
    }

    [LineNumberTable(new byte[] {159, 160, 121, 113, 113, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void begin()
    {
      if (this.color == null)
        this.color = this.target.__\u003C\u003Ecolor;
      this.startR = this.color.r;
      this.startG = this.color.g;
      this.startB = this.color.b;
      this.startA = this.color.a;
    }

    [LineNumberTable(new byte[] {159, 169, 127, 1, 127, 1, 127, 1, 127, 1, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void update(float percent) => this.color.set(this.startR + (this.end.r - this.startR) * percent, this.startG + (this.end.g - this.startG) * percent, this.startB + (this.end.b - this.startB) * percent, this.startA + (this.end.a - this.startA) * percent);

    [LineNumberTable(new byte[] {159, 178, 102, 103})]
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
    public virtual Color getEndColor() => this.end;
  }
}
