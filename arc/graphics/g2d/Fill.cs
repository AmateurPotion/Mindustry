// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.Fill
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.g2d
{
  public class Fill : Object
  {
    private static float[] vertices;
    private static TextureRegion circleRegion;
    private static FloatSeq polyFloats;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 132, 120, 180, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circle(float x, float y, float radius)
    {
      if (Fill.circleRegion == null || Fill.circleRegion.texture.isDisposed())
        Fill.circleRegion = (TextureRegion) Core.atlas.find(nameof (circle));
      Draw.rect(Fill.circleRegion, x, y, radius * 2f, radius * 2f);
    }

    [LineNumberTable(new byte[] {160, 156, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void square(float x, float y, float radius) => Fill.rect(x, y, radius * 2f, radius * 2f);

    [LineNumberTable(new byte[] {160, 160, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void square(float x, float y, float radius, float rotation) => Draw.rect((TextureRegion) Core.atlas.white(), x, y, radius * 2f, radius * 2f, rotation);

    [LineNumberTable(new byte[] {160, 144, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(float x, float y, float w, float h, float rot) => Draw.rect((TextureRegion) Core.atlas.white(), x, y, w, h, rot);

    [LineNumberTable(new byte[] {160, 89, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void poly(float x, float y, int sides, float radius) => Fill.poly(x, y, sides, radius, 0.0f);

    [LineNumberTable(new byte[] {105, 146, 146, 138, 105, 111, 111, 113, 113, 113, 113, 255, 18, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void light(
      float x,
      float y,
      int sides,
      float radius,
      Color center,
      Color edge)
    {
      float floatBits1 = center.toFloatBits();
      float floatBits2 = edge.toFloatBits();
      sides = Mathf.ceil((float) sides / 2f) * 2;
      float num1 = 360f / (float) sides;
      for (int index = 0; index < sides; index += 2)
      {
        float num2 = Angles.trnsx(num1 * (float) index, radius);
        float num3 = Angles.trnsy(num1 * (float) index, radius);
        float num4 = Angles.trnsx(num1 * (float) (index + 1), radius);
        float num5 = Angles.trnsy(num1 * (float) (index + 1), radius);
        float num6 = Angles.trnsx(num1 * (float) (index + 2), radius);
        float num7 = Angles.trnsy(num1 * (float) (index + 2), radius);
        Fill.quad(x, y, floatBits1, x + num2, y + num3, floatBits2, x + num4, y + num5, floatBits2, x + num6, y + num7, floatBits2);
      }
    }

    [LineNumberTable(new byte[] {41, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tri(float x1, float y1, float x2, float y2, float x3, float y3) => Fill.quad(x1, y1, x2, y2, x3, y3, x3, y3);

    [LineNumberTable(new byte[] {160, 140, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rect(float x, float y, float w, float h) => Draw.rect((TextureRegion) Core.atlas.white(), x, y, w, h);

    [LineNumberTable(new byte[] {160, 93, 103, 134, 108, 108, 111, 112, 119, 119, 127, 7, 133, 138, 107, 116, 116, 119, 119, 119, 119, 255, 12, 57, 235, 74, 142, 137, 133, 116, 117, 119, 119, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void poly(float x, float y, int sides, float radius, float rotation)
    {
      if (sides == 3)
      {
        float num1 = 120f;
        float num2 = Angles.trnsx(rotation, radius);
        float num3 = Angles.trnsy(rotation, radius);
        float num4 = Angles.trnsx(num1 + rotation, radius);
        float num5 = Angles.trnsy(num1 + rotation, radius);
        float num6 = Angles.trnsx(num1 * 2f + rotation, radius);
        float num7 = Angles.trnsy(num1 * 2f + rotation, radius);
        Fill.tri(x + num2, y + num3, x + num4, y + num5, x + num6, y + num7);
      }
      else
      {
        float num1 = 360f / (float) sides;
        for (int index = 0; index < sides; index += 2)
        {
          float num2 = Angles.trnsx(num1 * (float) index + rotation, radius);
          float num3 = Angles.trnsy(num1 * (float) index + rotation, radius);
          float num4 = Angles.trnsx(num1 * (float) (index + 1) + rotation, radius);
          float num5 = Angles.trnsy(num1 * (float) (index + 1) + rotation, radius);
          float num6 = Angles.trnsx(num1 * (float) (index + 2) + rotation, radius);
          float num7 = Angles.trnsy(num1 * (float) (index + 2) + rotation, radius);
          Fill.quad(x, y, x + num2, y + num3, x + num4, y + num5, x + num6, y + num7);
        }
        int num8 = sides;
        int num9 = 2;
        if ((num9 != -1 ? num8 % num9 : 0) == 0 || sides < 4)
          return;
        int num10 = sides - 2;
        float num11 = Angles.trnsx(num1 * (float) num10 + rotation, radius);
        float num12 = Angles.trnsy(num1 * (float) num10 + rotation, radius);
        float num13 = Angles.trnsx(num1 * (float) (num10 + 1) + rotation, radius);
        float num14 = Angles.trnsy(num1 * (float) (num10 + 1) + rotation, radius);
        Fill.tri(x, y, x + num11, y + num12, x + num13, y + num14);
      }
    }

    [LineNumberTable(new byte[] {160, 85, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void poly(FloatSeq vertices) => Fill.poly(vertices.items, vertices.size);

    [LineNumberTable(new byte[] {159, 158, 108, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void quad(
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3,
      float x4,
      float y4)
    {
      float packedColor = Core.batch.getPackedColor();
      Fill.quad(x1, y1, packedColor, x2, y2, packedColor, x3, y3, packedColor, x4, y4, packedColor);
    }

    [LineNumberTable(new byte[] {160, 152, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rects(float x, float y, float w, float h, float skew) => Fill.quad(x, y, x + w, y, x + w + skew, y + h, x + skew, y + h);

    [LineNumberTable(new byte[] {160, 148, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void crect(float x, float y, float w, float h) => Draw.rect((TextureRegion) Core.atlas.white(), x + w / 2f, y + h / 2f, w, h);

    [LineNumberTable(new byte[] {61, 102, 121, 143, 127, 85, 188, 185, 249, 72, 249, 72, 249, 72, 249, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void dropShadow(
      float x,
      float y,
      float width,
      float height,
      float blur,
      float opacity)
    {
      float clearFloatBits = Color.__\u003C\u003EclearFloatBits;
      float floatBits = Color.toFloatBits(0.0f, 0.0f, 0.0f, opacity);
      float num1 = blur / 2f;
      float num2 = blur;
      float num3 = x - Math.max(width / 2f - num1, 0.0f);
      float num4 = y - Math.max(height / 2f - num1, 0.0f);
      float num5 = x + Math.max(width / 2f - num1, 0.0f);
      float num6 = y + Math.max(height / 2f - num1, 0.0f);
      float num7 = num3 - num2;
      float num8 = num4 - num2;
      float num9 = num5 + num2;
      float num10 = num6 + num2;
      Fill.quad(num3, num4, floatBits, num5, num4, floatBits, num5, num6, floatBits, num3, num6, floatBits);
      Fill.quad(num3, num4, floatBits, num7, num8, clearFloatBits, num9, num8, clearFloatBits, num5, num4, floatBits);
      Fill.quad(num5, num4, floatBits, num9, num8, clearFloatBits, num9, num10, clearFloatBits, num5, num6, floatBits);
      Fill.quad(num3, num6, floatBits, num7, num10, clearFloatBits, num9, num10, clearFloatBits, num5, num6, floatBits);
      Fill.quad(num3, num4, floatBits, num7, num8, clearFloatBits, num7, num10, clearFloatBits, num3, num6, floatBits);
    }

    [LineNumberTable(new byte[] {159, 163, 107, 108, 103, 103, 105, 105, 105, 104, 104, 136, 105, 106, 106, 105, 105, 137, 107, 107, 107, 105, 105, 137, 107, 107, 107, 105, 105, 137, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void quad(
      float x1,
      float y1,
      float c1,
      float x2,
      float y2,
      float c2,
      float x3,
      float y3,
      float c3,
      float x4,
      float y4,
      float c4)
    {
      TextureAtlas.AtlasRegion atlasRegion = Core.atlas.white();
      float packedMixColor = Core.batch.getPackedMixColor();
      float u = atlasRegion.u;
      float v = atlasRegion.v;
      Fill.vertices[0] = x1;
      Fill.vertices[1] = y1;
      Fill.vertices[2] = c1;
      Fill.vertices[3] = u;
      Fill.vertices[4] = v;
      Fill.vertices[5] = packedMixColor;
      Fill.vertices[6] = x2;
      Fill.vertices[7] = y2;
      Fill.vertices[8] = c2;
      Fill.vertices[9] = u;
      Fill.vertices[10] = v;
      Fill.vertices[11] = packedMixColor;
      Fill.vertices[12] = x3;
      Fill.vertices[13] = y3;
      Fill.vertices[14] = c3;
      Fill.vertices[15] = u;
      Fill.vertices[16] = v;
      Fill.vertices[17] = packedMixColor;
      Fill.vertices[18] = x4;
      Fill.vertices[19] = y4;
      Fill.vertices[20] = c4;
      Fill.vertices[21] = u;
      Fill.vertices[22] = v;
      Fill.vertices[23] = packedMixColor;
      Draw.vert(atlasRegion.texture, Fill.vertices, 0, Fill.vertices.Length);
    }

    [LineNumberTable(new byte[] {160, 71, 165, 104, 63, 8, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void poly(float[] vertices, int length)
    {
      if (length < 6)
        return;
      for (int index = 2; index < length - 4; index += 6)
        Fill.quad(vertices[0], vertices[1], vertices[index], vertices[index + 1], vertices[index + 2], vertices[index + 3], vertices[index + 4], vertices[index + 5]);
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Fill()
    {
    }

    [LineNumberTable(new byte[] {7, 159, 23, 105, 105, 105, 104, 104, 137, 105, 106, 105, 105, 105, 138, 107, 107, 106, 105, 105, 138, 107, 107, 106, 105, 105, 138, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void quad(
      TextureRegion region,
      float x1,
      float y1,
      float x2,
      float y2,
      float x3,
      float y3,
      float x4,
      float y4)
    {
      float u = region.u;
      float v = region.v;
      float u2 = region.u2;
      float v2 = region.v2;
      float packedColor = Core.batch.getPackedColor();
      float packedMixColor = Core.batch.getPackedMixColor();
      Fill.vertices[0] = x1;
      Fill.vertices[1] = y1;
      Fill.vertices[2] = packedColor;
      Fill.vertices[3] = u;
      Fill.vertices[4] = v;
      Fill.vertices[5] = packedMixColor;
      Fill.vertices[6] = x2;
      Fill.vertices[7] = y2;
      Fill.vertices[8] = packedColor;
      Fill.vertices[9] = u;
      Fill.vertices[10] = v2;
      Fill.vertices[11] = packedMixColor;
      Fill.vertices[12] = x3;
      Fill.vertices[13] = y3;
      Fill.vertices[14] = packedColor;
      Fill.vertices[15] = u2;
      Fill.vertices[16] = v2;
      Fill.vertices[17] = packedMixColor;
      Fill.vertices[18] = x4;
      Fill.vertices[19] = y4;
      Fill.vertices[20] = packedColor;
      Fill.vertices[21] = u2;
      Fill.vertices[22] = v;
      Fill.vertices[23] = packedMixColor;
      Draw.vert(region.texture, Fill.vertices, 0, Fill.vertices.Length);
    }

    [LineNumberTable(new byte[] {50, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void dropShadowRect(
      float x,
      float y,
      float width,
      float height,
      float blur,
      float opacity)
    {
      Fill.dropShadow(x + width / 2f, y + height / 2f, width, height, blur, opacity);
    }

    [LineNumberTable(new byte[] {123, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void polyBegin() => Fill.polyFloats.clear();

    [LineNumberTable(new byte[] {127, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void polyPoint(float x, float y) => Fill.polyFloats.add(x, y);

    [LineNumberTable(new byte[] {160, 67, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void polyEnd() => Fill.poly(Fill.polyFloats.items, Fill.polyFloats.size);

    [LineNumberTable(new byte[] {159, 140, 173, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fill()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.Fill"))
        return;
      Fill.vertices = new float[24];
      Fill.polyFloats = new FloatSeq();
    }
  }
}
