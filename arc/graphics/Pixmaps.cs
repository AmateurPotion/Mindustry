// Decompiled with JetBrains decompiler
// Type: arc.graphics.Pixmaps
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public class Pixmaps : Object
  {
    private static Pixmap drawPixmap;
    private static IntSeq tmpArray;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 121, 103, 177, 107, 106, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void drawPixel(Texture texture, int x, int y, int color)
    {
      if (Pixmaps.drawPixmap == null)
        Pixmaps.drawPixmap = new Pixmap(1, 1, Pixmap.Format.__\u003C\u003Ergba8888);
      Pixmaps.drawPixmap.setColor(color);
      Pixmaps.drawPixmap.fill();
      texture.draw(Pixmaps.drawPixmap, x, y);
    }

    [LineNumberTable(new byte[] {75, 103, 135, 110, 110, 116, 127, 32, 232, 61, 41, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap outline(Pixmap input, Color color)
    {
      Pixmap pixmap = Pixmaps.copy(input);
      pixmap.setColor(color);
      for (int x = 0; x < pixmap.getWidth(); ++x)
      {
        for (int y = 0; y < pixmap.getHeight(); ++y)
        {
          if (Pixmaps.empty(input.getPixel(x, y)) && (!Pixmaps.empty(input.getPixel(x, y + 1)) || !Pixmaps.empty(input.getPixel(x, y - 1)) || (!Pixmaps.empty(input.getPixel(x - 1, y)) || !Pixmaps.empty(input.getPixel(x + 1, y)))))
            pixmap.draw(x, y);
        }
      }
      return pixmap;
    }

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap scale(Pixmap input, float scale) => Pixmaps.scale(input, scale, scale);

    [LineNumberTable(new byte[] {99, 109, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap resize(Pixmap input, int width, int height)
    {
      Pixmap pixmap = new Pixmap(width, height, Pixmap.Format.__\u003C\u003Ergba8888);
      pixmap.drawPixmap(input, width / 2 - input.getWidth() / 2, height / 2 - input.getHeight() / 2);
      return pixmap;
    }

    [LineNumberTable(new byte[] {43, 100, 136, 103, 135, 110, 110, 114, 130, 105, 105, 127, 8, 98, 226, 61, 40, 232, 72, 99, 232, 51, 41, 233, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap outline(Pixmap input, Color color, int thickness)
    {
      if (thickness == 1)
        return Pixmaps.outline(input, color);
      Pixmap pixmap = Pixmaps.copy(input);
      pixmap.setColor(color);
      for (int x = 0; x < pixmap.getWidth(); ++x)
      {
        for (int y = 0; y < pixmap.getHeight(); ++y)
        {
          if (Pixmaps.empty(input.getPixel(x, y)))
          {
            int num = 0;
            for (int index1 = -thickness; index1 <= thickness; ++index1)
            {
              for (int index2 = -thickness; index2 <= thickness; ++index2)
              {
                if ((double) Mathf.dst2((float) index1, (float) index2) <= (double) (thickness * thickness) && !Pixmaps.empty(input.getPixel(x + index1, y + index2)))
                {
                  num = 1;
                  goto label_15;
                }
              }
            }
label_15:
            if (num != 0)
              pixmap.draw(x, y);
          }
        }
      }
      return pixmap;
    }

    [LineNumberTable(new byte[] {22, 104, 103, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap scale(
      Pixmap pixmap,
      int width,
      int height,
      Pixmap.PixmapFilter filter)
    {
      Pixmap pixmap1 = new Pixmap(width, height);
      pixmap1.setFilter(filter);
      pixmap1.drawPixmap(pixmap, 0, 0, pixmap.getWidth(), pixmap.getHeight(), 0, 0, width, height);
      return pixmap1;
    }

    [LineNumberTable(new byte[] {159, 162, 104, 102, 102, 50, 38, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap noise(int w, int h)
    {
      Pixmap pixmap = new Pixmap(w, h);
      for (int x = 0; x < w; ++x)
      {
        for (int y = 0; y < h; ++y)
          pixmap.draw(x, y, Tmp.__\u003C\u003Ec1.rand());
      }
      return pixmap;
    }

    [LineNumberTable(new byte[] {5, 114, 246, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap median(Pixmap input, int radius, double percentile, IntSeq tmp)
    {
      Pixmap pixmap = new Pixmap(input.getWidth(), input.getHeight());
      input.each((Intc2) new Pixmaps.__\u003C\u003EAnon0(tmp, pixmap, radius, input, percentile));
      return pixmap;
    }

    [LineNumberTable(new byte[] {33, 127, 12, 107, 107, 63, 5, 38, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap scale(Pixmap input, float scalex, float scaley)
    {
      Pixmap pixmap = new Pixmap(ByteCodeHelper.f2i((float) input.getWidth() * scalex), ByteCodeHelper.f2i((float) input.getHeight() * scaley), Pixmap.Format.__\u003C\u003Ergba8888);
      for (int x = 0; x < pixmap.getWidth(); ++x)
      {
        for (int y = 0; y < pixmap.getHeight(); ++y)
          pixmap.draw(x, y, input.getPixel(ByteCodeHelper.f2i((float) x / scalex), ByteCodeHelper.f2i((float) y / scaley)));
      }
      return pixmap;
    }

    [LineNumberTable(new byte[] {16, 119, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap copy(Pixmap input)
    {
      Pixmap pixmap = new Pixmap(input.getWidth(), input.getHeight(), Pixmap.Format.__\u003C\u003Ergba8888);
      pixmap.drawPixmap(input, 0, 0);
      return pixmap;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool empty(int i) => (i & (int) byte.MaxValue) == 0;

    [LineNumberTable(new byte[] {160, 86, 109, 154, 102, 119, 103, 102, 40, 230, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap huePixmap(int width, int height)
    {
      Pixmap pixmap = new Pixmap(width, height, Pixmap.Format.__\u003C\u003Ergba8888);
      Color color = new Color(1f, 1f, 1f, 1f);
      for (int x = 0; x < width; ++x)
      {
        color.fromHsv((float) x / (float) width, 1f, 1f);
        pixmap.setColor(color);
        for (int y = 0; y < height; ++y)
          pixmap.draw(x, y);
      }
      return pixmap;
    }

    [LineNumberTable(new byte[] {160, 104, 109, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap blankPixmap()
    {
      Pixmap pixmap = new Pixmap(1, 1, Pixmap.Format.__\u003C\u003Ergba8888);
      pixmap.setColor(Color.__\u003C\u003Ewhite);
      pixmap.fill();
      return pixmap;
    }

    [LineNumberTable(new byte[] {160, 111, 107, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Texture blankTexture()
    {
      Texture texture = new Texture(Pixmaps.blankPixmap());
      texture.setWrap(Texture.TextureWrap.__\u003C\u003Erepeat, Texture.TextureWrap.__\u003C\u003Erepeat);
      return texture;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {7, 102, 127, 3, 102, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024median\u00241(
      [In] IntSeq obj0,
      [In] Pixmap obj1,
      [In] int obj2,
      [In] Pixmap obj3,
      [In] double obj4,
      [In] int obj5,
      [In] int obj6)
    {
      obj0.clear();
      Geometry.circle(obj5, obj6, obj1.getWidth(), obj1.getHeight(), obj2, (Intc2) new Pixmaps.__\u003C\u003EAnon1(obj0, obj3));
      obj0.sort();
      obj1.draw(obj5, obj6, obj0.get(Mathf.clamp(ByteCodeHelper.d2i((double) obj0.size * obj4), 0, obj0.size - 1)));
    }

    [Modifiers]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024median\u00240([In] IntSeq obj0, [In] Pixmap obj1, [In] int obj2, [In] int obj3) => obj0.add(obj1.getPixel(obj2, obj3));

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pixmaps()
    {
    }

    [LineNumberTable(new byte[] {159, 172, 104, 103, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Texture noiseTex(int w, int h)
    {
      Pixmap pixmap = Pixmaps.noise(w, h);
      Texture texture = new Texture(pixmap);
      texture.setWrap(Texture.TextureWrap.__\u003C\u003Erepeat);
      pixmap.dispose();
      return texture;
    }

    [LineNumberTable(new byte[] {159, 180, 103, 112, 103, 105, 109, 116, 13, 200, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void flip(Pixmap pixmap)
    {
      ByteBuffer pixels = pixmap.getPixels();
      byte[] numArray = new byte[pixmap.getWidth() * pixmap.getHeight() * 4];
      int num = pixmap.getWidth() * 4;
      for (int index = 0; index < pixmap.getHeight(); ++index)
      {
        ((Buffer) pixels).position((pixmap.getHeight() - index - 1) * num);
        pixels.get(numArray, index * num, num);
      }
      ((Buffer) pixels).clear();
      pixels.put(numArray);
    }

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap median(Pixmap input, int radius, double percentile) => Pixmaps.median(input, radius, percentile, Pixmaps.tmpArray);

    [LineNumberTable(new byte[] {89, 119, 110, 110, 63, 43, 41, 233, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap zoom(Pixmap input, int scale)
    {
      Pixmap pixmap1 = new Pixmap(input.getWidth(), input.getHeight(), Pixmap.Format.__\u003C\u003Ergba8888);
      for (int index1 = 0; index1 < pixmap1.getWidth(); ++index1)
      {
        for (int index2 = 0; index2 < pixmap1.getHeight(); ++index2)
        {
          Pixmap pixmap2 = pixmap1;
          int x1 = index1;
          int y1 = index2;
          Pixmap pixmap3 = input;
          int num1 = index1;
          int num2 = scale;
          int num3 = num2 != -1 ? num1 / num2 : -num1;
          int num4 = pixmap1.getWidth() / 2;
          int num5 = scale;
          int num6 = num5 != -1 ? num4 / num5 : -num4;
          int x2 = num3 + num6;
          int num7 = index2;
          int num8 = scale;
          int num9 = num8 != -1 ? num7 / num8 : -num7;
          int num10 = pixmap1.getHeight() / 2;
          int num11 = scale;
          int num12 = num11 != -1 ? num10 / num11 : -num10;
          int y2 = num9 + num12;
          int pixel = pixmap3.getPixel(x2, y2);
          pixmap2.draw(x1, y1, pixel);
        }
      }
      return pixmap1;
    }

    [LineNumberTable(new byte[] {106, 109, 103, 102, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap resize(Pixmap input, int width, int height, int backgroundColor)
    {
      Pixmap pixmap = new Pixmap(width, height, Pixmap.Format.__\u003C\u003Ergba8888);
      pixmap.setColor(backgroundColor);
      pixmap.fill();
      pixmap.drawPixmap(input, width / 2 - input.getWidth() / 2, height / 2 - input.getHeight() / 2);
      return pixmap;
    }

    [LineNumberTable(new byte[] {115, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap crop(Pixmap input, int x, int y, int width, int height)
    {
      Pixmap pixmap = new Pixmap(width, height, Pixmap.Format.__\u003C\u003Ergba8888);
      pixmap.drawPixmap(input, 0, 0, x, y, width, height);
      return pixmap;
    }

    [LineNumberTable(new byte[] {121, 102, 151, 110, 110, 127, 19, 106, 127, 5, 127, 5, 255, 23, 59, 41, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap rotate(Pixmap input, float angle)
    {
      Vec2 vec2 = new Vec2();
      Pixmap pixmap = new Pixmap(input.getHeight(), input.getWidth(), Pixmap.Format.__\u003C\u003Ergba8888);
      for (int x = 0; x < input.getWidth(); ++x)
      {
        for (int y = 0; y < input.getHeight(); ++y)
        {
          vec2.set((float) x - (float) input.getWidth() / 2f + 0.5f, (float) y - (float) input.getHeight() / 2f);
          vec2.rotate(-angle);
          int num1 = ByteCodeHelper.f2i(vec2.x + (float) input.getWidth() / 2f + 0.01f);
          int num2 = ByteCodeHelper.f2i(vec2.y + (float) input.getHeight() / 2f + 0.01f);
          pixmap.draw(num1 - input.getWidth() / 2 + pixmap.getWidth() / 2, num2 - input.getHeight() / 2 + pixmap.getHeight() / 2, input.getPixel(x, y));
        }
      }
      return pixmap;
    }

    [LineNumberTable(new byte[] {160, 78, 107, 107, 40, 38, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void traverse(Pixmap input, Intc2 t)
    {
      for (int i1 = 0; i1 < input.getWidth(); ++i1)
      {
        for (int i2 = 0; i2 < input.getHeight(); ++i2)
          t.get(i1, i2);
      }
    }

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Texture hueTexture(int width, int height) => new Texture(Pixmaps.huePixmap(width, height));

    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextureRegion blankTextureRegion() => new TextureRegion(Pixmaps.blankTexture());

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Pixmaps()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.Pixmaps"))
        return;
      Pixmaps.tmpArray = new IntSeq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Intc2
    {
      private readonly IntSeq arg\u00241;
      private readonly Pixmap arg\u00242;
      private readonly int arg\u00243;
      private readonly Pixmap arg\u00244;
      private readonly double arg\u00245;

      internal __\u003C\u003EAnon0([In] IntSeq obj0, [In] Pixmap obj1, [In] int obj2, [In] Pixmap obj3, [In] double obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] int obj0, [In] int obj1) => Pixmaps.lambda\u0024median\u00241(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Intc2
    {
      private readonly IntSeq arg\u00241;
      private readonly Pixmap arg\u00242;

      internal __\u003C\u003EAnon1([In] IntSeq obj0, [In] Pixmap obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] int obj0, [In] int obj1) => Pixmaps.lambda\u0024median\u00240(this.arg\u00241, this.arg\u00242, obj0, obj1);
    }
  }
}
