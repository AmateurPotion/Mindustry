// Decompiled with JetBrains decompiler
// Type: arc.fx.filters.ZoomFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.fx.filters
{
  public sealed class ZoomFilter : FxFilter
  {
    public float originX;
    public float originY;
    public float zoom;

    [LineNumberTable(new byte[] {159, 154, 242, 59, 107, 107, 203, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ZoomFilter()
      : base(nameof (zoom), nameof (zoom))
    {
      ZoomFilter zoomFilter = this;
      this.originX = 0.5f;
      this.originY = 0.5f;
      this.zoom = 1f;
      this.rebind();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOrigin(int align)
    {
      float num1 = (align & 8) == 0 ? ((align & 16) == 0 ? 0.5f : 1f) : 0.0f;
      float num2 = (align & 4) == 0 ? ((align & 2) == 0 ? 0.5f : 1f) : 0.0f;
      this.originX = num1;
      this.originY = num2;
    }

    [LineNumberTable(new byte[] {159, 185, 113, 118, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setParams()
    {
      this.__\u003C\u003Eshader.setUniformi("u_texture0", 0);
      this.__\u003C\u003Eshader.setUniformf("u_offsetX", this.originX);
      this.__\u003C\u003Eshader.setUniformf("u_offsetY", this.originY);
      this.__\u003C\u003Eshader.setUniformf("u_zoom", this.zoom);
    }
  }
}
