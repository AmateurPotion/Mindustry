// Decompiled with JetBrains decompiler
// Type: rhino.GeneratedClassLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;

namespace rhino
{
  public interface GeneratedClassLoader
  {
    [Signature("(Ljava/lang/String;[B)Ljava/lang/Class<*>;")]
    Class defineClass(string str, byte[] barr);

    [Signature("(Ljava/lang/Class<*>;)V")]
    void linkClass(Class c);
  }
}
