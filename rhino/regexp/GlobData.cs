// Decompiled with JetBrains decompiler
// Type: rhino.regexp.GlobData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.regexp
{
  [SourceFile("RegExpImpl.java")]
  internal sealed class GlobData : Object
  {
    internal int mode;
    internal bool global;
    internal string str;
    internal Scriptable arrayobj;
    internal Function lambda;
    internal string repstr;
    internal int dollar;
    internal StringBuilder charBuf;
    internal int leftIndex;

    [LineNumberTable(new byte[] {162, 103, 232, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal GlobData()
    {
      GlobData globData = this;
      this.dollar = -1;
    }
  }
}
