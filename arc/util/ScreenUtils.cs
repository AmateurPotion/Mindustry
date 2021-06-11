// Decompiled with JetBrains decompiler
// Type: arc.util.ScreenUtils
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public sealed class ScreenUtils : Object
  {
    [LineNumberTable(new byte[] {159, 116, 163, 107, 107, 116, 102, 103, 99, 101, 104, 112, 15, 200, 98, 103, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] getFrameBufferPixels(int x, int y, int w, int h, bool flipY)
    {
      int num1 = flipY ? 1 : 0;
      Gl.pixelStorei(3333, 1);
      ByteBuffer byteBuffer = Buffers.newByteBuffer(w * h * 4);
      Gl.readPixels(x, y, w, h, 6408, 5121, (Buffer) byteBuffer);
      byte[] numArray = new byte[w * h * 4];
      if (num1 != 0)
      {
        int num2 = w * 4;
        for (int index = 0; index < h; ++index)
        {
          ((Buffer) byteBuffer).position((h - index - 1) * num2);
          byteBuffer.get(numArray, index * num2, num2);
        }
      }
      else
      {
        ((Buffer) byteBuffer).clear();
        byteBuffer.get(numArray);
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {18, 139, 109, 103, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap getFrameBufferPixmap(int x, int y, int w, int h)
    {
      Gl.pixelStorei(3333, 1);
      Pixmap pixmap = new Pixmap(w, h, Pixmap.Format.__\u003C\u003Ergba8888);
      ByteBuffer pixels = pixmap.getPixels();
      Gl.readPixels(x, y, w, h, 6408, 5121, (Buffer) pixels);
      return pixmap;
    }

    [LineNumberTable(new byte[] {159, 166, 108, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void saveScreenshot(Fi file, int x, int y, int width, int height)
    {
      Pixmap frameBufferPixmap = ScreenUtils.getFrameBufferPixmap(x, y, width, height, true);
      PixmapIO.writePNG(file, frameBufferPixmap);
      frameBufferPixmap.dispose();
    }

    [LineNumberTable(new byte[] {159, 123, 131, 107, 109, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap getFrameBufferPixmap(int x, int y, int w, int h, bool flip)
    {
      int num = flip ? 1 : 0;
      byte[] frameBufferPixels = ScreenUtils.getFrameBufferPixels(x, y, w, h, num != 0);
      Pixmap pixmap = new Pixmap(w, h, Pixmap.Format.__\u003C\u003Ergba8888);
      Buffers.copy(frameBufferPixels, 0, (Buffer) pixmap.getPixels(), frameBufferPixels.Length);
      return pixmap;
    }

    [LineNumberTable(new byte[] {3, 103, 135, 106, 109, 105, 104, 110, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextureRegion getFrameBufferTexture(int x, int y, int w, int h)
    {
      int width = Mathf.nextPowerOfTwo(w);
      int height = Mathf.nextPowerOfTwo(h);
      Pixmap frameBufferPixmap = ScreenUtils.getFrameBufferPixmap(x, y, w, h);
      Pixmap pixmap = new Pixmap(width, height, Pixmap.Format.__\u003C\u003Ergba8888);
      pixmap.drawPixmap(frameBufferPixmap, 0, 0);
      TextureRegion textureRegion = new TextureRegion(new Texture(pixmap), 0, h, w, -h);
      pixmap.dispose();
      frameBufferPixmap.dispose();
      return textureRegion;
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScreenUtils()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void saveScreenshot(Fi file) => ScreenUtils.saveScreenshot(file, 0, 0, Core.graphics.getWidth(), Core.graphics.getHeight());

    [LineNumberTable(new byte[] {159, 178, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextureRegion getFrameBufferTexture() => ScreenUtils.getFrameBufferTexture(0, 0, Core.graphics.getBackBufferWidth(), Core.graphics.getBackBufferHeight());

    [LineNumberTable(new byte[] {159, 119, 66, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] getFrameBufferPixels(bool flipY)
    {
      int num = flipY ? 1 : 0;
      return ScreenUtils.getFrameBufferPixels(0, 0, Core.graphics.getBackBufferWidth(), Core.graphics.getBackBufferHeight(), num != 0);
    }
  }
}
