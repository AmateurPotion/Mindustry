// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ToNativeConverter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;

namespace com.sun.jna
{
  public interface ToNativeConverter
  {
    object toNative(object obj, ToNativeContext tnc);

    [Signature("()Ljava/lang/Class<*>;")]
    Class nativeType();
  }
}
