// Decompiled with JetBrains decompiler
// Type: rhino.module.ModuleScriptProvider
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.net;

namespace rhino.module
{
  public interface ModuleScriptProvider
  {
    [Throws(new string[] {"java.lang.Exception"})]
    ModuleScript getModuleScript(
      Context c,
      string str,
      URI uri1,
      URI uri2,
      Scriptable s);
  }
}
