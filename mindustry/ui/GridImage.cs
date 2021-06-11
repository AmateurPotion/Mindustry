// Decompiled with JetBrains decompiler
// Type: mindustry.ui.GridImage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.scene;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.ui
{
  public class GridImage : Element
  {
    private int imageWidth;
    private int imageHeight;

    [LineNumberTable(new byte[] {159, 151, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GridImage(int w, int h)
    {
      GridImage gridImage = this;
      this.imageWidth = w;
      this.imageHeight = h;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setImageSize(int w, int h)
    {
      this.imageWidth = w;
      this.imageHeight = h;
    }

    [LineNumberTable(new byte[] {159, 158, 113, 113, 134, 131, 115, 147, 109, 63, 31, 201, 109, 63, 18, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      float num1 = this.getWidth() / (float) this.imageWidth;
      float num2 = this.getHeight() / (float) this.imageHeight;
      float num3 = 1f;
      int num4 = 10;
      int num5 = ByteCodeHelper.f2i(Math.max((float) num4, num1) / num1);
      int num6 = ByteCodeHelper.f2i(Math.max((float) num4, num2) / num2);
      for (int index = 0; index <= this.imageWidth; index += num5)
        Fill.crect((float) ByteCodeHelper.f2i(this.x + num1 * (float) index - num3), this.y - num3, 2f, this.getHeight() + (float) (index == this.imageWidth ? 1 : 0));
      for (int index = 0; index <= this.imageHeight; index += num6)
        Fill.crect(this.x - num3, (float) ByteCodeHelper.f2i(this.y + (float) index * num2 - num3), this.getWidth(), 2f);
    }
  }
}
