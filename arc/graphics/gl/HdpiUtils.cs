// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.HdpiUtils
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.graphics.gl
{
  public class HdpiUtils : Object
  {
    private static HdpiMode mode;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 182, 127, 13, 113, 159, 0, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void glScissor(int x, int y, int width, int height)
    {
      if (object.ReferenceEquals((object) HdpiUtils.mode, (object) HdpiMode.__\u003C\u003Elogical) && (Core.graphics.getWidth() != Core.graphics.getBackBufferWidth() || Core.graphics.getHeight() != Core.graphics.getBackBufferHeight()))
        Gl.scissor(HdpiUtils.toBackBufferX(x), HdpiUtils.toBackBufferY(y), HdpiUtils.toBackBufferX(width), HdpiUtils.toBackBufferY(height));
      else
        Gl.scissor(x, y, width, height);
    }

    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toBackBufferX(int logicalX) => ByteCodeHelper.f2i((float) (logicalX * Core.graphics.getBackBufferWidth()) / (float) Core.graphics.getWidth());

    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toBackBufferY(int logicalY) => ByteCodeHelper.f2i((float) (logicalY * Core.graphics.getBackBufferHeight()) / (float) Core.graphics.getHeight());

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HdpiUtils()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setMode(HdpiMode mode) => HdpiUtils.mode = mode;

    [LineNumberTable(new byte[] {3, 127, 13, 113, 159, 0, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void glViewport(int x, int y, int width, int height)
    {
      if (object.ReferenceEquals((object) HdpiUtils.mode, (object) HdpiMode.__\u003C\u003Elogical) && (Core.graphics.getWidth() != Core.graphics.getBackBufferWidth() || Core.graphics.getHeight() != Core.graphics.getBackBufferHeight()))
        Gl.viewport(HdpiUtils.toBackBufferX(x), HdpiUtils.toBackBufferY(y), HdpiUtils.toBackBufferX(width), HdpiUtils.toBackBufferY(height));
      else
        Gl.viewport(x, y, width, height);
    }

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toLogicalX(int backBufferX) => ByteCodeHelper.f2i((float) (backBufferX * Core.graphics.getWidth()) / (float) Core.graphics.getBackBufferWidth());

    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toLogicalY(int backBufferY) => ByteCodeHelper.f2i((float) (backBufferY * Core.graphics.getHeight()) / (float) Core.graphics.getBackBufferHeight());

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static HdpiUtils()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.gl.HdpiUtils"))
        return;
      HdpiUtils.mode = HdpiMode.__\u003C\u003Elogical;
    }
  }
}
