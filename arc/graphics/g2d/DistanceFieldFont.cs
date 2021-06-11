// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.DistanceFieldFont
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.graphics.gl;
using IKVM.Attributes;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class DistanceFieldFont : Font
  {
    private float distanceFieldSmoothing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDistanceFieldSmoothing() => this.distanceFieldSmoothing;

    [Signature("(Larc/graphics/g2d/Font$FontData;Larc/struct/Seq<Larc/graphics/g2d/TextureRegion;>;Z)V")]
    [LineNumberTable(new byte[] {159, 132, 130, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistanceFieldFont(Font.FontData data, Seq pageRegions, bool integer)
    {
      int num = integer ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(data, pageRegions, num != 0);
    }

    [LineNumberTable(new byte[] {159, 131, 130, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistanceFieldFont(Font.FontData data, TextureRegion region, bool integer)
    {
      int num = integer ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(data, region, num != 0);
    }

    [LineNumberTable(new byte[] {159, 130, 130, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistanceFieldFont(Fi fontFile, bool flip)
    {
      int num = flip ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(fontFile, num != 0);
    }

    [LineNumberTable(new byte[] {159, 129, 133, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistanceFieldFont(Fi fontFile, Fi imageFile, bool flip, bool integer)
    {
      int num1 = flip ? 1 : 0;
      int num2 = integer ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(fontFile, imageFile, num1 != 0, num2 != 0);
    }

    [LineNumberTable(new byte[] {159, 128, 130, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistanceFieldFont(Fi fontFile, Fi imageFile, bool flip)
    {
      int num = flip ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(fontFile, imageFile, num != 0);
    }

    [LineNumberTable(new byte[] {159, 127, 130, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistanceFieldFont(Fi fontFile, TextureRegion region, bool flip)
    {
      int num = flip ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(fontFile, region, num != 0);
    }

    [LineNumberTable(new byte[] {16, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistanceFieldFont(Fi fontFile, TextureRegion region)
      : base(fontFile, region)
    {
    }

    [LineNumberTable(new byte[] {20, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistanceFieldFont(Fi fontFile)
      : base(fontFile)
    {
    }

    [LineNumberTable(new byte[] {28, 230, 79, 230, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Shader createDistanceFieldShader() => new Shader("attribute vec4 a_position;\nattribute vec4 a_color;\nattribute vec2 a_texCoord0;\nuniform mat4 u_projTrans;\nvarying vec4 v_color;\nvarying vec2 v_texCoords;\n\nvoid main(){\n\tv_color = a_color;\n\tv_color.a = v_color.a * (255.0/254.0);\n\tv_texCoords = a_texCoord0;\n\tgl_Position =  u_projTrans * a_position;\n}\n", "uniform sampler2D u_texture;\nuniform float u_smoothing;\nvarying vec4 v_color;\nvarying vec2 v_texCoords;\n\nvoid main(){\n\tif (u_smoothing > 0.0) {\n\t\tfloat smoothing = 0.25 / u_smoothing;\n\t\tfloat distance = texture2D(u_texture, v_texCoords).a;\n\t\tfloat alpha = smoothstep(0.5 - smoothing, 0.5 + smoothing, distance);\n\t\tgl_FragColor = vec4(v_color.rgb, alpha * v_color.a);\n\t} else {\n\t\tgl_FragColor = v_color * texture2D(u_texture, v_texCoords);\n\t}\n}\n");

    [LineNumberTable(new byte[] {63, 167, 103, 123, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void load(Font.FontData data)
    {
      base.load(data);
      Iterator iterator = this.getRegions().iterator();
      while (iterator.hasNext())
        ((TextureRegion) iterator.next()).texture.setFilter(Texture.TextureFilter.__\u003C\u003Elinear, Texture.TextureFilter.__\u003C\u003Elinear);
    }

    [LineNumberTable(123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FontCache newFontCache()
    {
      DistanceFieldFont.DistanceFieldFontCache.__\u003Cclinit\u003E();
      return (FontCache) new DistanceFieldFont.DistanceFieldFontCache(this, this.integer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDistanceFieldSmoothing(float distanceFieldSmoothing) => this.distanceFieldSmoothing = distanceFieldSmoothing;

    [InnerClass]
    internal class DistanceFieldFontCache : FontCache
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {104, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private float getSmoothingFactor()
      {
        DistanceFieldFont font = (DistanceFieldFont) this.getFont();
        return font.getDistanceFieldSmoothing() * font.getScaleX();
      }

      [LineNumberTable(new byte[] {109, 101, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void setSmoothingUniform([In] float obj0)
      {
        Draw.flush();
        Draw.getShader().setUniformf("u_smoothing", obj0);
      }

      [LineNumberTable(new byte[] {96, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DistanceFieldFontCache([In] DistanceFieldFont obj0)
        : base((Font) obj0, obj0.usesIntegerPositions())
      {
      }

      [LineNumberTable(new byte[] {159, 105, 130, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DistanceFieldFontCache([In] DistanceFieldFont obj0, [In] bool obj1)
      {
        int num = obj1 ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector((Font) obj0, num != 0);
      }

      [LineNumberTable(new byte[] {115, 109, 102, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        this.setSmoothingUniform(this.getSmoothingFactor());
        base.draw();
        this.setSmoothingUniform(0.0f);
      }

      [LineNumberTable(new byte[] {122, 109, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw([In] int obj0, [In] int obj1)
      {
        this.setSmoothingUniform(this.getSmoothingFactor());
        base.draw(obj0, obj1);
        this.setSmoothingUniform(0.0f);
      }

      [HideFromJava]
      static DistanceFieldFontCache() => FontCache.__\u003Cclinit\u003E();
    }
  }
}
