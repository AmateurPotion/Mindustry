// Decompiled with JetBrains decompiler
// Type: rhino.SymbolScriptable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace rhino
{
  public interface SymbolScriptable
  {
    object get(Symbol s1, Scriptable s2);

    bool has(Symbol s1, Scriptable s2);

    void put(Symbol s1, Scriptable s2, object obj);

    void delete(Symbol s);
  }
}
