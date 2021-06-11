// Decompiled with JetBrains decompiler
// Type: mindustry.ui.WarningBar
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.scene;
using IKVM.Attributes;
using IKVM.Runtime;
using mindustry.graphics;
using System.Runtime.CompilerServices;

namespace mindustry.ui
{
  public class WarningBar : Element
  {
    public float barWidth;
    public float spacing;
    public float skew;

    [LineNumberTable(new byte[] {159, 149, 104, 191, 11, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WarningBar()
    {
      WarningBar warningBar = this;
      this.barWidth = 40f;
      this.spacing = this.barWidth * 2f;
      this.skew = this.barWidth;
      this.setColor(Pal.accent);
    }

    [LineNumberTable(new byte[] {159, 158, 107, 139, 150, 105, 117, 31, 50, 233, 73, 106, 127, 6, 159, 22, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      Draw.color(this.__\u003C\u003Ecolor);
      Draw.alpha(this.parentAlpha);
      int num = ByteCodeHelper.f2i(this.width / this.spacing) + 2;
      for (int index = 0; index < num; ++index)
      {
        float x1 = this.x + (float) (index - 1) * this.spacing;
        Fill.quad(x1, this.y, x1 + this.skew, this.y + this.height, x1 + this.skew + this.barWidth, this.y + this.height, x1 + this.barWidth, this.y);
      }
      Lines.stroke(3f);
      Lines.line(this.x, this.y, this.x + this.width, this.y);
      Lines.line(this.x, this.y + this.height, this.x + this.width, this.y + this.height);
      Draw.reset();
    }
  }
}
