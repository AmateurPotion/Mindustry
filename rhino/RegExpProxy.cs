// Decompiled with JetBrains decompiler
// Type: rhino.RegExpProxy
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;

namespace rhino
{
  public interface RegExpProxy
  {
    const int RA_MATCH = 1;
    const int RA_REPLACE = 2;
    const int RA_SEARCH = 3;

    object compileRegExp(Context c, string str1, string str2);

    object js_split(Context c, Scriptable s, string str, object[] objarr);

    object action(Context c, Scriptable s1, Scriptable s2, object[] objarr, int i);

    bool isRegExp(Scriptable s);

    Scriptable wrapRegExp(Context c, Scriptable s, object obj);

    int find_split(
      Context c,
      Scriptable s1,
      string str1,
      string str2,
      Scriptable s2,
      int[] iarr1,
      int[] iarr2,
      bool[] barr,
      string[][] strarr);

    [HideFromJava]
    static class __Fields
    {
      public const int RA_MATCH = 1;
      public const int RA_REPLACE = 2;
      public const int RA_SEARCH = 3;
    }
  }
}
