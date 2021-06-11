// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.Draw
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.gl;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.g2d
{
  public class Draw : Object
  {
    private static ScreenQuad squad;
    [Modifiers]
    private static Color[] carr;
    [Modifiers]
    private static float[] vertices;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private static Camera lastProj;
    private static Rect lastViewport;
    public static float scl;
    public static float xscl;
    public static float yscl;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {161, 10, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Mat proj()
    {
      Draw.lastProj = (Camera) null;
      return Core.batch.getProjection();
    }

    [LineNumberTable(389)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Mat trans() => Core.batch.getTransform();

    [LineNumberTable(new byte[] {161, 15, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void trans(Mat trans) => Core.batch.setTransform(trans);

    [LineNumberTable(new byte[] {160, 240, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void flush() => Core.batch.flush();

    [LineNumberTable(new byte[] {160, 106, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void color(float r, float g, float b, float a) => Core.batch.setColor(r, g, b, a);

    [LineNumberTable(new byte[] {160, 192, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(TextureRegion region, float x, float y) => Draw.rect(region, x, y, (float) region.width * Draw.scl * Draw.xscl, (float) region.height * Draw.scl * Draw.yscl);

    [LineNumberTable(new byte[] {160, 128, 101, 101, 112, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void reset()
    {
      Draw.color();
      Draw.mixcol();
      Draw.xscl = Draw.yscl = 1f;
      Lines.stroke(1f);
    }

    [LineNumberTable(new byte[] {113, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void mixcol(Color color, float a) => Core.batch.setMixColor(color.r, color.g, color.b, Mathf.clamp(a));

    [LineNumberTable(new byte[] {160, 135, 127, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void alpha(float alpha) => Core.batch.setColor(Core.batch.getColor().r, Core.batch.getColor().g, Core.batch.getColor().b, alpha);

    [LineNumberTable(new byte[] {160, 228, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(TextureRegion region, float x, float y, float rotation) => Draw.rect(region, x, y, (float) region.width * Draw.scl * Draw.xscl, (float) region.height * Draw.scl * Draw.yscl, rotation);

    [LineNumberTable(new byte[] {160, 70, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void color(Color color) => Core.batch.setColor(color);

    [LineNumberTable(new byte[] {160, 98, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void color() => Core.batch.setPackedColor(Color.__\u003C\u003EwhiteFloatBits);

    [LineNumberTable(new byte[] {160, 196, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(string region, float x, float y) => Draw.rect((TextureRegion) Core.atlas.find(region), x, y);

    [LineNumberTable(new byte[] {160, 74, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void color(Color color, float alpha) => Core.batch.setColor(color.r, color.g, color.b, alpha);

    [LineNumberTable(new byte[] {160, 208, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(
      TextureRegion region,
      float x,
      float y,
      float w,
      float h,
      float rotation)
    {
      Draw.rect(region, x, y, w, h, w / 2f, h / 2f, rotation);
    }

    [LineNumberTable(new byte[] {160, 232, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(string region, float x, float y, float rotation) => Draw.rect((TextureRegion) Core.atlas.find(region), x, y, rotation);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void scl(float nxscl, float nyscl)
    {
      Draw.xscl = nxscl;
      Draw.yscl = nyscl;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void scl() => Draw.xscl = Draw.yscl = 1f;

    [LineNumberTable(new byte[] {160, 94, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void color(Color a, Color b, float s) => Core.batch.setColor(Tmp.__\u003C\u003Ec1.set(a).lerp(b, s));

    [LineNumberTable(new byte[] {160, 120, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blend(Blending blending) => Core.batch.setBlending(blending);

    [LineNumberTable(new byte[] {160, 124, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blend() => Draw.blend(Blending.__\u003C\u003Enormal);

    [LineNumberTable(new byte[] {160, 86, 104, 104, 104, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void color(Color a, Color b, Color c, float progress)
    {
      Draw.carr[0] = a;
      Draw.carr[1] = b;
      Draw.carr[2] = c;
      Draw.color(Tmp.__\u003C\u003Ec1.lerp(Draw.carr, progress));
    }

    [LineNumberTable(new byte[] {160, 188, 127, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(TextureRegion region, float x, float y, float w, float h) => Core.batch.draw(region, x - w / 2f, y - h / 2f, 0.0f, 0.0f, w, h, 0.0f);

    [LineNumberTable(new byte[] {101, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void z(float z) => Core.batch.z(z);

    [LineNumberTable(new byte[] {160, 216, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(TextureRegion region, Position pos, float w, float h) => Draw.rect(region, pos.getX(), pos.getY(), w, h);

    [LineNumberTable(new byte[] {117, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void mixcol() => Core.batch.setPackedMixColor(Color.__\u003C\u003EclearFloatBits);

    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float z() => Core.batch.sortAscending ? Core.batch.z : -Core.batch.z;

    [LineNumberTable(new byte[] {160, 224, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(TextureRegion region, Position pos, float rotation) => Draw.rect(region, pos.getX(), pos.getY(), rotation);

    [LineNumberTable(155)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color getColor() => Core.batch.getColor();

    [LineNumberTable(new byte[] {126, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tint(Color color) => Core.batch.setColor(color.r, color.g, color.b, Core.batch.getColor().a);

    [LineNumberTable(new byte[] {160, 254, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void proj(Camera proj) => Draw.proj(proj.__\u003C\u003Emat);

    [LineNumberTable(new byte[] {159, 108, 98, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sort(bool sort)
    {
      int num = sort ? 1 : 0;
      Core.batch.setSort(num != 0);
    }

    [LineNumberTable(new byte[] {160, 161, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void draw(float z, Runnable run)
    {
      Draw.z(z);
      Core.batch.draw(run);
    }

    [LineNumberTable(new byte[] {160, 168, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void drawRange(float z, Runnable begin, Runnable end) => Draw.drawRange(z, 1f / 1000f, begin, end);

    [LineNumberTable(new byte[] {160, 174, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void drawRange(float z, float range, Runnable begin, Runnable end)
    {
      Draw.draw(z - range, begin);
      Draw.draw(z + range, end);
    }

    [LineNumberTable(new byte[] {160, 184, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(string region, float x, float y, float w, float h) => Draw.rect((TextureRegion) Core.atlas.find(region), x, y, w, h);

    [LineNumberTable(new byte[] {159, 110, 66, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shader(Shader shader, bool apply)
    {
      int num = apply ? 1 : 0;
      Core.batch.setShader(shader, num != 0);
    }

    [LineNumberTable(new byte[] {82, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shader() => Core.batch.setShader((Shader) null);

    [LineNumberTable(new byte[] {160, 212, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(string region, float x, float y, float w, float h, float rotation) => Draw.rect((TextureRegion) Core.atlas.find(region), x, y, w, h, w / 2f, h / 2f, rotation);

    [LineNumberTable(new byte[] {160, 116, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void colorl(float l, float a) => Draw.color(l, l, l, a);

    [LineNumberTable(new byte[] {161, 2, 127, 7, 103, 144, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void proj(Mat proj)
    {
      Draw.lastProj = Core.camera == null || !object.ReferenceEquals((object) Core.camera.__\u003C\u003Emat, (object) proj) ? (Camera) null : Core.camera;
      if (Draw.lastProj != null)
        Draw.lastProj.bounds(Draw.lastViewport);
      Core.batch.setProjection(proj);
    }

    [LineNumberTable(new byte[] {74, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shader(Shader shader) => Draw.shader(shader, true);

    [LineNumberTable(new byte[] {160, 140, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void fbo(FrameBuffer buffer, int worldWidth, int worldHeight, int tilesize) => Draw.fbo((Texture) buffer.getTexture(), worldWidth, worldHeight, tilesize);

    [LineNumberTable(new byte[] {160, 200, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(
      TextureRegion region,
      float x,
      float y,
      float w,
      float h,
      float originX,
      float originY,
      float rotation)
    {
      Core.batch.draw(region, x - w / 2f, y - h / 2f, originX, originY, w, h, rotation);
    }

    [LineNumberTable(new byte[] {160, 236, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vert(Texture texture, float[] vertices, int offset, int length) => Core.batch.draw(texture, vertices, offset, length);

    [LineNumberTable(new byte[] {160, 82, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void color(float color) => Core.batch.setPackedColor(color);

    [LineNumberTable(new byte[] {32, 133, 106, 105, 106, 112, 106, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void beginStencil()
    {
      Draw.flush();
      Gl.stencilMask((int) byte.MaxValue);
      Gl.colorMask(false, false, false, false);
      Gl.enable(2960);
      Gl.stencilFunc(519, 1, (int) byte.MaxValue);
      Gl.stencilMask((int) byte.MaxValue);
      Gl.stencilOp(7681, 7681, 7681);
    }

    [LineNumberTable(new byte[] {43, 133, 116, 105, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void beginStenciled()
    {
      Draw.flush();
      Gl.stencilOp(7680, 7680, 7680);
      Gl.colorMask(true, true, true, true);
      Gl.stencilFunc(514, 1, (int) byte.MaxValue);
    }

    [LineNumberTable(new byte[] {51, 133, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void endStencil()
    {
      Draw.flush();
      Gl.disable(2960);
    }

    [LineNumberTable(new byte[] {160, 244, 101, 102, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void proj(float x, float y, float w, float h)
    {
      Draw.flush();
      Draw.lastProj = (Camera) null;
      Core.batch.getProjection().setOrtho(x, y, w, h);
    }

    [LineNumberTable(new byte[] {161, 28, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextureRegion wrap(Texture texture)
    {
      Tmp.__\u003C\u003Etr2.set(texture);
      return Tmp.__\u003C\u003Etr2;
    }

    [LineNumberTable(new byte[] {8, 102, 134, 134, 134, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void batch(Batch nextBatch, Runnable run)
    {
      Batch batch = Core.batch;
      batch.flush();
      Core.batch = nextBatch;
      run.run();
      nextBatch.flush();
      Core.batch = batch;
    }

    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color getMixColor() => Core.batch.getMixColor();

    [LineNumberTable(new byte[] {160, 111, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void colorl(float l) => Draw.color(l, l, l);

    [Signature("(Larc/graphics/g2d/TextureRegion;FFFFFLarc/func/Cons<Larc/math/geom/Vec2;>;)V")]
    [LineNumberTable(new byte[] {161, 37, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rectv(
      TextureRegion region,
      float x,
      float y,
      float width,
      float height,
      float rotation,
      Cons tweaker)
    {
      Draw.rectv(region, x, y, width, height, width / 2f, height / 2f, rotation, tweaker);
    }

    [LineNumberTable(120)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Shader getShader() => Core.batch.getShader();

    [LineNumberTable(new byte[] {159, 167, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ScreenQuad getQuad()
    {
      if (Draw.squad == null)
        Draw.squad = new ScreenQuad();
      return Draw.squad;
    }

    [LineNumberTable(new byte[] {159, 182, 103, 102, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blit(Texture texture, Shader shader)
    {
      texture.bind(0);
      shader.bind();
      shader.apply();
      Draw.getQuad().render(shader);
    }

    [LineNumberTable(new byte[] {160, 102, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void color(float r, float g, float b) => Core.batch.setColor(r, g, b, 1f);

    [LineNumberTable(new byte[] {160, 145, 106, 127, 23, 121, 121, 121, 153, 107, 146, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void fbo(Texture texture, int worldWidth, int worldHeight, int tilesize)
    {
      float num1 = (float) (worldWidth * tilesize);
      float num2 = (float) (worldHeight * tilesize);
      float num3 = Core.camera.__\u003C\u003Eposition.x + (float) tilesize / 2f;
      float num4 = Core.camera.__\u003C\u003Eposition.y + (float) tilesize / 2f;
      float u = (num3 - Core.camera.width / 2f) / num1;
      float v2 = (num4 - Core.camera.height / 2f) / num2;
      float u2 = (num3 + Core.camera.width / 2f) / num1;
      float v = (num4 + Core.camera.height / 2f) / num2;
      Tmp.__\u003C\u003Etr1.set(texture);
      Tmp.__\u003C\u003Etr1.set(u, v, u2, v2);
      Draw.rect(Tmp.__\u003C\u003Etr1, Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y, Core.camera.width, Core.camera.height);
    }

    [Signature("(Larc/graphics/g2d/TextureRegion;FFFFFFFLarc/func/Cons<Larc/math/geom/Vec2;>;)V")]
    [LineNumberTable(new byte[] {161, 41, 111, 176, 104, 104, 101, 101, 105, 170, 107, 139, 113, 113, 114, 114, 115, 115, 108, 140, 117, 108, 140, 117, 108, 140, 117, 108, 140, 117, 108, 140, 104, 104, 104, 136, 109, 109, 105, 105, 105, 105, 105, 137, 105, 105, 105, 106, 106, 138, 106, 106, 106, 106, 106, 138, 106, 106, 106, 106, 106, 138, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rectv(
      TextureRegion region,
      float x,
      float y,
      float width,
      float height,
      float originX,
      float originY,
      float rotation,
      Cons tweaker)
    {
      x -= width / 2f;
      y -= height / 2f;
      float num1 = x + originX;
      float num2 = y + originY;
      float num3 = -originX;
      float num4 = -originY;
      float num5 = width - originX;
      float num6 = height - originY;
      float num7 = Mathf.cosDeg(rotation);
      float num8 = Mathf.sinDeg(rotation);
      float x1 = num7 * num3 - num8 * num4 + num1;
      float y1 = num8 * num3 + num7 * num4 + num2;
      float x2 = num7 * num3 - num8 * num6 + num1;
      float y2 = num8 * num3 + num7 * num6 + num2;
      float x3 = num7 * num5 - num8 * num6 + num1;
      float y3 = num8 * num5 + num7 * num6 + num2;
      float x4 = x1 + (x3 - x2);
      float y4 = y3 - (y2 - y1);
      tweaker.get((object) Tmp.__\u003C\u003Ev1.set(x1, y1));
      float x5 = Tmp.__\u003C\u003Ev1.x;
      float y5 = Tmp.__\u003C\u003Ev1.y;
      tweaker.get((object) Tmp.__\u003C\u003Ev1.set(x2, y2));
      float x6 = Tmp.__\u003C\u003Ev1.x;
      float y6 = Tmp.__\u003C\u003Ev1.y;
      tweaker.get((object) Tmp.__\u003C\u003Ev1.set(x3, y3));
      float x7 = Tmp.__\u003C\u003Ev1.x;
      float y7 = Tmp.__\u003C\u003Ev1.y;
      tweaker.get((object) Tmp.__\u003C\u003Ev1.set(x4, y4));
      float x8 = Tmp.__\u003C\u003Ev1.x;
      float y8 = Tmp.__\u003C\u003Ev1.y;
      float u = region.u;
      float v2 = region.v2;
      float u2 = region.u2;
      float v = region.v;
      float packedColor = Core.batch.getPackedColor();
      float packedMixColor = Core.batch.getPackedMixColor();
      Draw.vertices[0] = x5;
      Draw.vertices[1] = y5;
      Draw.vertices[2] = packedColor;
      Draw.vertices[3] = u;
      Draw.vertices[4] = v2;
      Draw.vertices[5] = packedMixColor;
      Draw.vertices[6] = x6;
      Draw.vertices[7] = y6;
      Draw.vertices[8] = packedColor;
      Draw.vertices[9] = u;
      Draw.vertices[10] = v;
      Draw.vertices[11] = packedMixColor;
      Draw.vertices[12] = x7;
      Draw.vertices[13] = y7;
      Draw.vertices[14] = packedColor;
      Draw.vertices[15] = u2;
      Draw.vertices[16] = v;
      Draw.vertices[17] = packedMixColor;
      Draw.vertices[18] = x8;
      Draw.vertices[19] = y8;
      Draw.vertices[20] = packedColor;
      Draw.vertices[21] = u2;
      Draw.vertices[22] = v2;
      Draw.vertices[23] = packedMixColor;
      Draw.vert(region.texture, Draw.vertices, 0, Draw.vertices.Length);
    }

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Draw()
    {
    }

    [LineNumberTable(new byte[] {159, 174, 102, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blit(Shader shader)
    {
      shader.bind();
      shader.apply();
      Draw.getQuad().render(shader);
    }

    [LineNumberTable(new byte[] {159, 191, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blit(FrameBuffer buffer, Shader shader) => Draw.blit((Texture) buffer.getTexture(), shader);

    [LineNumberTable(new byte[] {3, 101, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void batch(Batch nextBatch)
    {
      Draw.flush();
      Core.batch = nextBatch;
    }

    [LineNumberTable(new byte[] {20, 133, 134, 133, 134, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stencil(Runnable stencil, Runnable contents)
    {
      Draw.beginStencil();
      stencil.run();
      Draw.beginStenciled();
      contents.run();
      Draw.endStencil();
    }

    [LineNumberTable(new byte[] {57, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void scl(float nscl) => Draw.scl(nscl, nscl);

    [LineNumberTable(new byte[] {159, 107, 130, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sortAscending(bool ascend)
    {
      int num = ascend ? 1 : 0;
      Core.batch.setSortAscending(num != 0);
    }

    [LineNumberTable(new byte[] {121, 116, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tint(Color a, Color b, float s)
    {
      Tmp.__\u003C\u003Ec1.set(a).lerp(b, s);
      Core.batch.setColor(Tmp.__\u003C\u003Ec1.r, Tmp.__\u003C\u003Ec1.g, Tmp.__\u003C\u003Ec1.b, Core.batch.getColor().a);
    }

    [LineNumberTable(new byte[] {160, 66, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void colorMul(Color color, float mul) => Draw.color(color.r * mul, color.g * mul, color.b * mul, 1f);

    [LineNumberTable(new byte[] {160, 78, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void color(int color) => Core.batch.setColor(Tmp.__\u003C\u003Ec1.rgba8888(color));

    [LineNumberTable(new byte[] {160, 180, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect() => Fill.rect(Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y, Core.camera.width, Core.camera.height);

    [LineNumberTable(new byte[] {160, 204, 127, 31})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(
      string region,
      float x,
      float y,
      float w,
      float h,
      float originX,
      float originY,
      float rotation)
    {
      Core.batch.draw((TextureRegion) Core.atlas.find(region), x - w / 2f, y - h / 2f, originX, originY, w, h, rotation);
    }

    [LineNumberTable(new byte[] {160, 220, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(TextureRegion region, Position pos, float w, float h, float rotation) => Draw.rect(region, pos.getX(), pos.getY(), w, h, rotation);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Rect lastViewport() => Draw.lastViewport;

    [LineNumberTable(394)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isCamera() => object.ReferenceEquals((object) Draw.lastProj, (object) Core.camera);

    [Signature("(Larc/graphics/g2d/TextureRegion;FFFFLarc/func/Cons<Larc/math/geom/Vec2;>;)V")]
    [LineNumberTable(new byte[] {161, 33, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rectv(
      TextureRegion region,
      float x,
      float y,
      float width,
      float height,
      Cons tweaker)
    {
      Draw.rectv(region, x, y, width, height, 0.0f, tweaker);
    }

    [LineNumberTable(new byte[] {159, 138, 77, 107, 140, 138, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Draw()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.Draw"))
        return;
      Draw.carr = new Color[3];
      Draw.vertices = new float[24];
      Draw.lastViewport = new Rect();
      Draw.scl = 1f;
      Draw.xscl = 1f;
      Draw.yscl = 1f;
    }
  }
}
