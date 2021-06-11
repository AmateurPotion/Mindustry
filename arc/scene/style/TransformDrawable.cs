// Decompiled with JetBrains decompiler
// Type: arc.scene.style.TransformDrawable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;

namespace arc.scene.style
{
  [Implements(new string[] {"arc.scene.style.Drawable"})]
  public interface TransformDrawable : Drawable
  {
    new void draw(
      float f1,
      float f2,
      float f3,
      float f4,
      float f5,
      float f6,
      float f7,
      float f8,
      float f9);
  }
}
