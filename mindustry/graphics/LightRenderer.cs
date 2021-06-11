// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.LightRenderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class LightRenderer : Object
  {
    private const int scaling = 4;
    private float[] vertices;
    private FrameBuffer buffer;
    [Signature("Larc/struct/Seq<Ljava/lang/Runnable;>;")]
    private Seq lights;

    [LineNumberTable(new byte[] {159, 158, 168, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LightRenderer()
    {
      LightRenderer lightRenderer = this;
      this.vertices = new float[24];
      this.buffer = new FrameBuffer();
      this.lights = new Seq();
    }

    [LineNumberTable(new byte[] {127, 103, 108, 161, 159, 4, 101, 112, 143, 127, 1, 102, 98, 101, 107, 143, 101, 127, 0, 144, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      if (!Vars.enableLight)
      {
        this.lights.clear();
      }
      else
      {
        this.buffer.resize(Core.graphics.getWidth() / 4, Core.graphics.getHeight() / 4);
        Draw.color();
        this.buffer.begin(Color.__\u003C\u003Eclear);
        Gl.blendEquationSeparate(32774, 32776);
        Iterator iterator = this.lights.iterator();
        while (iterator.hasNext())
          ((Runnable) iterator.next()).run();
        Draw.reset();
        this.buffer.end();
        Gl.blendEquationSeparate(32774, 32774);
        Draw.color();
        Shaders.light.ambient.set(Vars.state.rules.ambientLight);
        this.buffer.blit((Shader) Shaders.light);
        this.lights.clear();
      }
    }

    [LineNumberTable(173)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool enabled() => Vars.state.rules.lighting && (double) Vars.state.rules.ambientLight.a > 9.99999974737875E-06;

    [LineNumberTable(new byte[] {159, 172, 137, 105, 250, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(float x, float y, float radius, Color color, float opacity)
    {
      if (!this.enabled())
        return;
      this.add((Runnable) new LightRenderer.__\u003C\u003EAnon0(color.toFloatBits(), opacity, x, y, radius));
    }

    [LineNumberTable(new byte[] {159, 183, 137, 105, 249, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(float x, float y, TextureRegion region, Color color, float opacity)
    {
      if (!this.enabled())
        return;
      this.add((Runnable) new LightRenderer.__\u003C\u003EAnon1(color.toFloatBits(), opacity, region, x, y));
    }

    [LineNumberTable(new byte[] {2, 137, 255, 3, 160, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void line(
      float x,
      float y,
      float x2,
      float y2,
      float stroke,
      Color tint,
      float alpha)
    {
      if (!this.enabled())
        return;
      this.add((Runnable) new LightRenderer.__\u003C\u003EAnon2(this, tint, alpha, x2, x, y2, y, stroke));
    }

    [LineNumberTable(new byte[] {159, 166, 137, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Runnable run)
    {
      if (!this.enabled())
        return;
      this.lights.add((object) run);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 176, 103, 103, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024add\u00240(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4)
    {
      Draw.color(obj0);
      Draw.alpha(obj1);
      Draw.rect("circle-shadow", obj2, obj3, obj4 * 2f, obj4 * 2f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 187, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024add\u00241(
      [In] float obj0,
      [In] float obj1,
      [In] TextureRegion obj2,
      [In] float obj3,
      [In] float obj4)
    {
      Draw.color(obj0);
      Draw.alpha(obj1);
      Draw.rect(obj2, obj3, obj4);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {5, 136, 118, 159, 1, 108, 104, 104, 104, 168, 119, 124, 124, 123, 155, 106, 106, 105, 106, 106, 141, 106, 106, 105, 107, 107, 142, 107, 107, 106, 107, 107, 142, 107, 107, 106, 107, 107, 142, 153, 144, 104, 104, 104, 136, 106, 106, 105, 106, 106, 141, 106, 106, 105, 107, 107, 142, 116, 116, 106, 107, 107, 142, 116, 116, 106, 107, 107, 142, 153, 106, 106, 105, 106, 106, 141, 106, 106, 105, 107, 107, 142, 116, 116, 106, 107, 107, 142, 116, 116, 106, 107, 107, 142, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024line\u00242(
      [In] Color obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] float obj6)
    {
      Draw.color(obj0, obj1);
      float angle = Mathf.angleExact(obj2 - obj3, obj4 - obj5);
      TextureAtlas.AtlasRegion atlasRegion1 = Core.atlas.find("circle-end");
      TextureAtlas.AtlasRegion atlasRegion2 = Core.atlas.find("circle-mid");
      float floatBits = Draw.getColor().toFloatBits();
      float u1 = atlasRegion2.u;
      float v2_1 = atlasRegion2.v2;
      float u2_1 = atlasRegion2.u2;
      float v1 = atlasRegion2.v;
      Vec2 vec2_1 = Tmp.__\u003C\u003Ev1.trnsExact(angle + 90f, obj6);
      float num1 = obj3 - vec2_1.x;
      float num2 = obj5 - vec2_1.y;
      float num3 = obj3 + vec2_1.x;
      float num4 = obj5 + vec2_1.y;
      float num5 = obj2 + vec2_1.x;
      float num6 = obj4 + vec2_1.y;
      float num7 = obj2 - vec2_1.x;
      float num8 = obj4 - vec2_1.y;
      this.vertices[0] = num1;
      this.vertices[1] = num2;
      this.vertices[2] = floatBits;
      this.vertices[3] = u1;
      this.vertices[4] = v2_1;
      this.vertices[5] = 0.0f;
      this.vertices[6] = num3;
      this.vertices[7] = num4;
      this.vertices[8] = floatBits;
      this.vertices[9] = u1;
      this.vertices[10] = v1;
      this.vertices[11] = 0.0f;
      this.vertices[12] = num5;
      this.vertices[13] = num6;
      this.vertices[14] = floatBits;
      this.vertices[15] = u2_1;
      this.vertices[16] = v1;
      this.vertices[17] = 0.0f;
      this.vertices[18] = num7;
      this.vertices[19] = num8;
      this.vertices[20] = floatBits;
      this.vertices[21] = u2_1;
      this.vertices[22] = v2_1;
      this.vertices[23] = 0.0f;
      Draw.vert(atlasRegion1.texture, this.vertices, 0, this.vertices.Length);
      Vec2 vec2_2 = Tmp.__\u003C\u003Ev2.trnsExact(angle, obj6);
      float u2 = atlasRegion1.u;
      float v2_2 = atlasRegion1.v2;
      float u2_2 = atlasRegion1.u2;
      float v2 = atlasRegion1.v;
      this.vertices[0] = num7;
      this.vertices[1] = num8;
      this.vertices[2] = floatBits;
      this.vertices[3] = u2;
      this.vertices[4] = v2_2;
      this.vertices[5] = 0.0f;
      this.vertices[6] = num5;
      this.vertices[7] = num6;
      this.vertices[8] = floatBits;
      this.vertices[9] = u2;
      this.vertices[10] = v2;
      this.vertices[11] = 0.0f;
      this.vertices[12] = num5 + vec2_2.x;
      this.vertices[13] = num6 + vec2_2.y;
      this.vertices[14] = floatBits;
      this.vertices[15] = u2_2;
      this.vertices[16] = v2;
      this.vertices[17] = 0.0f;
      this.vertices[18] = num7 + vec2_2.x;
      this.vertices[19] = num8 + vec2_2.y;
      this.vertices[20] = floatBits;
      this.vertices[21] = u2_2;
      this.vertices[22] = v2_2;
      this.vertices[23] = 0.0f;
      Draw.vert(atlasRegion1.texture, this.vertices, 0, this.vertices.Length);
      this.vertices[0] = num3;
      this.vertices[1] = num4;
      this.vertices[2] = floatBits;
      this.vertices[3] = u2;
      this.vertices[4] = v2_2;
      this.vertices[5] = 0.0f;
      this.vertices[6] = num1;
      this.vertices[7] = num2;
      this.vertices[8] = floatBits;
      this.vertices[9] = u2;
      this.vertices[10] = v2;
      this.vertices[11] = 0.0f;
      this.vertices[12] = num1 - vec2_2.x;
      this.vertices[13] = num2 - vec2_2.y;
      this.vertices[14] = floatBits;
      this.vertices[15] = u2_2;
      this.vertices[16] = v2;
      this.vertices[17] = 0.0f;
      this.vertices[18] = num3 - vec2_2.x;
      this.vertices[19] = num4 - vec2_2.y;
      this.vertices[20] = floatBits;
      this.vertices[21] = u2_2;
      this.vertices[22] = v2_2;
      this.vertices[23] = 0.0f;
      Draw.vert(atlasRegion1.texture, this.vertices, 0, this.vertices.Length);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;

      internal __\u003C\u003EAnon0([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void run() => LightRenderer.lambda\u0024add\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;
      private readonly TextureRegion arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;

      internal __\u003C\u003EAnon1(
        [In] float obj0,
        [In] float obj1,
        [In] TextureRegion obj2,
        [In] float obj3,
        [In] float obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void run() => LightRenderer.lambda\u0024add\u00241(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly LightRenderer arg\u00241;
      private readonly Color arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;
      private readonly float arg\u00247;
      private readonly float arg\u00248;

      internal __\u003C\u003EAnon2(
        [In] LightRenderer obj0,
        [In] Color obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5,
        [In] float obj6,
        [In] float obj7)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
        this.arg\u00248 = obj7;
      }

      public void run() => this.arg\u00241.lambda\u0024line\u00242(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248);
    }
  }
}
