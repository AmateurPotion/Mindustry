// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.PixmapRegion
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.g2d
{
  public class PixmapRegion : Object
  {
    public Pixmap pixmap;
    public int x;
    public int y;
    public int width;
    public int height;

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPixel(int x, int y) => this.pixmap.getPixel(this.x + x, this.y + y);

    [LineNumberTable(new byte[] {159, 165, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPixel(int x, int y, Color color)
    {
      int pixel = this.getPixel(x, y);
      color.set(pixel);
      return pixel;
    }

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap crop() => Pixmaps.crop(this.pixmap, this.x, this.y, this.width, this.height);

    [LineNumberTable(new byte[] {159, 156, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PixmapRegion(Pixmap pixmap)
    {
      PixmapRegion pixmapRegion = this;
      this.set(pixmap);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual PixmapRegion set(
      Pixmap pixmap,
      int x,
      int y,
      int width,
      int height)
    {
      this.pixmap = pixmap;
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
      return this;
    }

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual PixmapRegion set(Pixmap pixmap) => this.set(pixmap, 0, 0, pixmap.getWidth(), pixmap.getHeight());

    [LineNumberTable(new byte[] {159, 152, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PixmapRegion(Pixmap pixmap, int x, int y, int width, int height)
    {
      PixmapRegion pixmapRegion = this;
      this.set(pixmap, x, y, width, height);
    }
  }
}
