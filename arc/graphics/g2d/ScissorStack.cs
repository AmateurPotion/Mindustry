// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.ScissorStack
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics.gl;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class ScissorStack : Object
  {
    [Modifiers]
    internal static Rect viewport;
    internal static Vec2 tmp;
    [Signature("Larc/struct/Seq<Larc/math/geom/Rect;>;")]
    private static Seq scissors;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 175, 134, 108, 124, 101, 175, 124, 115, 127, 4, 141, 115, 127, 5, 142, 101, 103, 103, 106, 182, 107, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool push(Rect scissor)
    {
      ScissorStack.fix(scissor);
      if (ScissorStack.scissors.size == 0)
      {
        if ((double) scissor.width < 1.0 || (double) scissor.height < 1.0)
          return false;
        Draw.flush();
        Gl.enable(3089);
      }
      else
      {
        Rect rect = (Rect) ScissorStack.scissors.get(ScissorStack.scissors.size - 1);
        float num1 = Math.max(rect.x, scissor.x);
        float num2 = Math.min(rect.x + rect.width, scissor.x + scissor.width);
        if ((double) (num2 - num1) < 1.0)
          return false;
        float num3 = Math.max(rect.y, scissor.y);
        float num4 = Math.min(rect.y + rect.height, scissor.y + scissor.height);
        if ((double) (num4 - num3) < 1.0)
          return false;
        Draw.flush();
        scissor.x = num1;
        scissor.y = num3;
        scissor.width = num2 - num1;
        scissor.height = Math.max(1f, num4 - num3);
      }
      ScissorStack.scissors.add((object) scissor);
      HdpiUtils.glScissor(ByteCodeHelper.f2i(scissor.x), ByteCodeHelper.f2i(scissor.y), ByteCodeHelper.f2i(scissor.width), ByteCodeHelper.f2i(scissor.height));
      return true;
    }

    [LineNumberTable(new byte[] {19, 101, 112, 108, 140, 112, 159, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Rect pop()
    {
      Draw.flush();
      Rect rect1 = (Rect) ScissorStack.scissors.pop();
      if (ScissorStack.scissors.size == 0)
      {
        Gl.disable(3089);
      }
      else
      {
        Rect rect2 = (Rect) ScissorStack.scissors.peek();
        HdpiUtils.glScissor(ByteCodeHelper.f2i(rect2.x), ByteCodeHelper.f2i(rect2.y), ByteCodeHelper.f2i(rect2.width), ByteCodeHelper.f2i(rect2.height));
      }
      return rect1;
    }

    [LineNumberTable(new byte[] {40, 114, 114, 114, 114, 109, 109, 148, 109, 109, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void fix([In] Rect obj0)
    {
      obj0.x = (float) Math.round(obj0.x);
      obj0.y = (float) Math.round(obj0.y);
      obj0.width = (float) Math.round(obj0.width);
      obj0.height = (float) Math.round(obj0.height);
      if ((double) obj0.width < 0.0)
      {
        obj0.width = -obj0.width;
        obj0.x -= obj0.width;
      }
      if ((double) obj0.height >= 0.0)
        return;
      obj0.height = -obj0.height;
      obj0.y -= obj0.height;
    }

    [LineNumberTable(new byte[] {59, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void calculateScissors(
      Camera camera,
      Mat batchTransform,
      Rect area,
      Rect scissor)
    {
      ScissorStack.calculateScissors(camera, 0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight(), batchTransform, area, scissor);
    }

    [LineNumberTable(new byte[] {75, 121, 109, 117, 113, 145, 127, 12, 109, 117, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void calculateScissors(
      Camera camera,
      float viewportX,
      float viewportY,
      float viewportWidth,
      float viewportHeight,
      Mat batchTransform,
      Rect area,
      Rect scissor)
    {
      ScissorStack.tmp.set(area.x, area.y);
      ScissorStack.tmp.mul(batchTransform);
      camera.project(ScissorStack.tmp, viewportX, viewportY, viewportWidth, viewportHeight);
      scissor.x = ScissorStack.tmp.x;
      scissor.y = ScissorStack.tmp.y;
      ScissorStack.tmp.set(area.x + area.width, area.y + area.height);
      ScissorStack.tmp.mul(batchTransform);
      camera.project(ScissorStack.tmp, viewportX, viewportY, viewportWidth, viewportHeight);
      scissor.width = ScissorStack.tmp.x - scissor.x;
      scissor.height = ScissorStack.tmp.y - scissor.y;
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScissorStack()
    {
    }

    [LineNumberTable(new byte[] {31, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool pushWorld(Rect scissorWorld)
    {
      ScissorStack.calculateScissors(Core.camera, Tmp.__\u003C\u003Em1.idt(), Tmp.__\u003C\u003Er1.set(scissorWorld), scissorWorld);
      return ScissorStack.push(scissorWorld);
    }

    [LineNumberTable(86)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Rect peek() => (Rect) ScissorStack.scissors.peek();

    [LineNumberTable(new byte[] {90, 108, 127, 12, 134, 112, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Rect getViewport()
    {
      if (ScissorStack.scissors.size == 0)
      {
        ScissorStack.viewport.set(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
        return ScissorStack.viewport;
      }
      Rect rect = (Rect) ScissorStack.scissors.peek();
      ScissorStack.viewport.set(rect);
      return ScissorStack.viewport;
    }

    [LineNumberTable(new byte[] {159, 138, 141, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ScissorStack()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.g2d.ScissorStack"))
        return;
      ScissorStack.viewport = new Rect();
      ScissorStack.tmp = new Vec2();
      ScissorStack.scissors = new Seq();
    }
  }
}
