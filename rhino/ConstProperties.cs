// Decompiled with JetBrains decompiler
// Type: rhino.ConstProperties
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace rhino
{
  public interface ConstProperties
  {
    void putConst(string str, Scriptable s, object obj);

    void defineConst(string str, Scriptable s);

    bool isConst(string str);
  }
}
