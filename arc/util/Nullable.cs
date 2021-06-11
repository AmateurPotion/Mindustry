// Decompiled with JetBrains decompiler
// Type: arc.util.Nullable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang.annotation;

namespace arc.util
{
  [Modifiers]
  [AnnotationAttribute("arc.util.NullableAttribute")]
  [Documented(new object[] {64, "Ljava/lang/annotation/Documented;"})]
  [Target(new object[] {64, "Ljava/lang/annotation/Target;", "value", new object[] {91, new object[] {101, "Ljava/lang/annotation/ElementType, IKVM/OpenJDK/Core, Version=8/6/9/0, Culture=neutral, PublicKeyToken=null;", "METHOD"}, new object[] {101, "Ljava/lang/annotation/ElementType, IKVM/OpenJDK/Core, Version=8/6/9/0, Culture=neutral, PublicKeyToken=null;", "FIELD"}, new object[] {101, "Ljava/lang/annotation/ElementType, IKVM/OpenJDK/Core, Version=8/6/9/0, Culture=neutral, PublicKeyToken=null;", "PARAMETER"}, new object[] {101, "Ljava/lang/annotation/ElementType, IKVM/OpenJDK/Core, Version=8/6/9/0, Culture=neutral, PublicKeyToken=null;", "LOCAL_VARIABLE"}}})]
  [Retention(new object[] {64, "Ljava/lang/annotation/Retention;", "value", new object[] {101, "Ljava/lang/annotation/RetentionPolicy, IKVM/OpenJDK/Core, Version=8/6/9/0, Culture=neutral, PublicKeyToken=null;", "RUNTIME"}})]
  [Implements(new string[] {"java.lang.annotation.Annotation"})]
  public interface Nullable : Annotation
  {
  }
}
