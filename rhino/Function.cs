// Decompiled with JetBrains decompiler
// Type: rhino.Function
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;

namespace rhino
{
  [Implements(new string[] {"rhino.Scriptable", "rhino.Callable"})]
  public interface Function : Scriptable, Callable
  {
    new object call(Context c, Scriptable s1, Scriptable s2, object[] objarr);

    Scriptable construct(Context c, Scriptable s, object[] objarr);
  }
}
