// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.MipMapGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.gl
{
  public class MipMapGenerator : Object
  {
    private static bool useHWMipMap;

    [LineNumberTable(new byte[] {159, 176, 103, 105, 161, 127, 5, 137, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void generateMipMap(
      int target,
      Pixmap pixmap,
      int textureWidth,
      int textureHeight)
    {
      if (!MipMapGenerator.useHWMipMap)
        MipMapGenerator.generateMipMapCPU(target, pixmap, textureWidth, textureHeight);
      else if (Core.app.isAndroid() || Core.app.isWeb() || Core.app.isIOS())
        MipMapGenerator.generateMipMapGLES20(target, pixmap);
      else
        MipMapGenerator.generateMipMapDesktop(target, pixmap, textureWidth, textureHeight);
    }

    [LineNumberTable(new byte[] {14, 118, 49, 133, 107, 112, 105, 105, 98, 110, 110, 107, 121, 106, 131, 118, 49, 165, 105, 105, 100, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generateMipMapCPU([In] int obj0, [In] Pixmap obj1, [In] int obj2, [In] int obj3)
    {
      Gl.texImage2D(obj0, 0, obj1.getGLInternalFormat(), obj1.getWidth(), obj1.getHeight(), 0, obj1.getGLFormat(), obj1.getGLType(), (Buffer) obj1.getPixels());
      if (Core.gl20 == null && obj2 != obj3)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("texture width and height must be square when using mipmapping.");
      }
      int num1 = obj1.getWidth() / 2;
      int num2 = obj1.getHeight() / 2;
      int level = 1;
      while (num1 > 0 && num2 > 0)
      {
        Pixmap pixmap = new Pixmap(num1, num2, obj1.getFormat());
        pixmap.setBlending(Pixmap.Blending.__\u003C\u003Enone);
        pixmap.drawPixmap(obj1, 0, 0, obj1.getWidth(), obj1.getHeight(), 0, 0, num1, num2);
        if (level > 1)
          obj1.dispose();
        obj1 = pixmap;
        Gl.texImage2D(obj0, level, obj1.getGLInternalFormat(), obj1.getWidth(), obj1.getHeight(), 0, obj1.getGLFormat(), obj1.getGLType(), (Buffer) obj1.getPixels());
        num1 = obj1.getWidth() / 2;
        num2 = obj1.getHeight() / 2;
        ++level;
      }
    }

    [LineNumberTable(new byte[] {159, 189, 118, 49, 133, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generateMipMapGLES20([In] int obj0, [In] Pixmap obj1)
    {
      Gl.texImage2D(obj0, 0, obj1.getGLInternalFormat(), obj1.getWidth(), obj1.getHeight(), 0, obj1.getGLFormat(), obj1.getGLType(), (Buffer) obj1.getPixels());
      Gl.generateMipmap(obj0);
    }

    [LineNumberTable(new byte[] {3, 123, 110, 118, 49, 133, 136, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generateMipMapDesktop([In] int obj0, [In] Pixmap obj1, [In] int obj2, [In] int obj3)
    {
      if (Core.graphics.supportsExtension("GL_ARB_framebuffer_object") || Core.graphics.supportsExtension("GL_EXT_framebuffer_object") || Core.gl30 != null)
      {
        Gl.texImage2D(obj0, 0, obj1.getGLInternalFormat(), obj1.getWidth(), obj1.getHeight(), 0, obj1.getGLFormat(), obj1.getGLType(), (Buffer) obj1.getPixels());
        Gl.generateMipmap(obj0);
      }
      else
        MipMapGenerator.generateMipMapCPU(obj0, obj1, obj2, obj3);
    }

    [LineNumberTable(new byte[] {159, 154, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private MipMapGenerator()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setUseHardwareMipMap(bool useHWMipMap) => MipMapGenerator.useHWMipMap = useHWMipMap;

    [LineNumberTable(new byte[] {159, 168, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void generateMipMap(Pixmap pixmap, int textureWidth, int textureHeight) => MipMapGenerator.generateMipMap(3553, pixmap, textureWidth, textureHeight);

    [MethodImpl(MethodImplOptions.NoInlining)]
    static MipMapGenerator()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.gl.MipMapGenerator"))
        return;
      MipMapGenerator.useHWMipMap = true;
    }
  }
}
