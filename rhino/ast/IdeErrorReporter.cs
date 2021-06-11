// Decompiled with JetBrains decompiler
// Type: rhino.ast.IdeErrorReporter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;

namespace rhino.ast
{
  [Implements(new string[] {"rhino.ErrorReporter"})]
  public interface IdeErrorReporter : ErrorReporter
  {
    void warning(string str1, string str2, int i1, int i2);

    void error(string str1, string str2, int i1, int i2);
  }
}
