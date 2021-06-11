// Decompiled with JetBrains decompiler
// Type: rhino.annotations.JSGetter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang.annotation;

namespace rhino.annotations
{
  [Modifiers]
  [AnnotationAttribute("rhino.annotations.JSGetterAttribute")]
  [Documented(new object[] {64, "Ljava/lang/annotation/Documented;"})]
  [Retention(new object[] {64, "Ljava/lang/annotation/Retention;", "value", new object[] {101, "Ljava/lang/annotation/RetentionPolicy, IKVM/OpenJDK/Core, Version=8/6/9/0, Culture=neutral, PublicKeyToken=null;", "RUNTIME"}})]
  [Target(new object[] {64, "Ljava/lang/annotation/Target;", "value", new object[] {91, new object[] {101, "Ljava/lang/annotation/ElementType, IKVM/OpenJDK/Core, Version=8/6/9/0, Culture=neutral, PublicKeyToken=null;", "METHOD"}}})]
  [Implements(new string[] {"java.lang.annotation.Annotation"})]
  public interface JSGetter : Annotation
  {
    [AnnotationDefault("")]
    string value();
  }
}
