// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.VertexData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.gl
{
  [Implements(new string[] {"arc.util.Disposable"})]
  public interface VertexData : Disposable
  {
    void set(float[] farr, int i1, int i2);

    void update(int i1, float[] farr, int i2, int i3);

    int size();

    int max();

    void bind(Shader s);

    void unbind(Shader s);

    [Modifiers]
    void render(IndexData indices, int primitiveType, int offset, int count);

    [LineNumberTable(new byte[] {159, 159, 105, 108, 127, 18, 191, 5, 146, 137})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Erender(
      [In] VertexData obj0,
      [In] IndexData obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4)
    {
      if (obj1.size() > 0)
      {
        if (obj4 + obj3 > obj1.max())
        {
          string message = new StringBuilder().append("Mesh attempting to access memory outside of the index buffer (count: ").append(obj4).append(", offset: ").append(obj3).append(", max: ").append(obj1.max()).append(")").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        Gl.drawElements(obj2, obj4, 5123, obj3 * 2);
      }
      else
        Gl.drawArrays(obj2, obj3, obj4);
    }

    FloatBuffer buffer();

    [HideFromJava]
    new static class __DefaultMethods
    {
      public static void render([In] VertexData obj0, [In] IndexData obj1, [In] int obj2, [In] int obj3, [In] int obj4)
      {
        VertexData vertexData = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(vertexData, ToString);
        VertexData.\u003Cdefault\u003Erender(vertexData, obj1, obj2, obj3, obj4);
      }
    }
  }
}
