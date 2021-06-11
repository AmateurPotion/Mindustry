// Decompiled with JetBrains decompiler
// Type: rhino.regexp.RENode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.regexp
{
  [SourceFile("NativeRegExp.java")]
  internal class RENode : Object
  {
    internal byte op;
    internal RENode next;
    internal RENode kid;
    internal RENode kid2;
    internal int parenIndex;
    internal int min;
    internal int max;
    internal int parenCount;
    internal bool greedy;
    internal int startIndex;
    internal int kidlen;
    internal int bmsize;
    internal int index;
    internal bool sense;
    internal char chr;
    internal int length;
    internal int flatIndex;

    [LineNumberTable(new byte[] {156, 226, 163, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal RENode([In] byte obj0)
    {
      int num = (int) (sbyte) obj0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      RENode reNode = this;
      this.op = (byte) num;
    }
  }
}
