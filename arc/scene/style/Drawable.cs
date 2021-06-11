// Decompiled with JetBrains decompiler
// Type: arc.scene.style.Drawable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.style
{
  public interface Drawable
  {
    void draw(float f1, float f2, float f3, float f4);

    [Modifiers]
    float imageSize();

    [LineNumberTable(40)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003EimageSize([In] Drawable obj0) => obj0.getMinWidth();

    float getMinWidth();

    float getMinHeight();

    float getTopHeight();

    float getLeftWidth();

    float getBottomHeight();

    float getRightWidth();

    void draw(
      float f1,
      float f2,
      float f3,
      float f4,
      float f5,
      float f6,
      float f7,
      float f8,
      float f9);

    void setLeftWidth(float f);

    void setRightWidth(float f);

    void setTopHeight(float f);

    void setBottomHeight(float f);

    void setMinWidth(float f);

    void setMinHeight(float f);

    [HideFromJava]
    static class __DefaultMethods
    {
      public static float imageSize([In] Drawable obj0)
      {
        Drawable drawable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(drawable, ToString);
        return Drawable.\u003Cdefault\u003EimageSize(drawable);
      }
    }
  }
}
