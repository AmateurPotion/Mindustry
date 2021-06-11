// Decompiled with JetBrains decompiler
// Type: rhino.regexp.REGlobalData
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
  internal class REGlobalData : Object
  {
    internal bool multiline;
    internal RECompiled regexp;
    internal int skipped;
    internal int cp;
    internal long[] parens;
    internal REProgState stateStackTop;
    internal REBackTrackData backTrackStackTop;

    [LineNumberTable(2864)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int parensIndex([In] int obj0) => (int) this.parens[obj0];

    [LineNumberTable(2871)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int parensLength([In] int obj0) => (int) ((ulong) this.parens[obj0] >> 32);

    [LineNumberTable(new byte[] {170, 202, 127, 1, 150, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setParens([In] int obj0, [In] int obj1, [In] int obj2)
    {
      if (this.backTrackStackTop != null && object.ReferenceEquals((object) this.backTrackStackTop.parens, (object) this.parens))
        this.parens = (long[]) this.parens.Clone();
      this.parens[obj0] = (long) obj1 & (long) uint.MaxValue | (long) obj2 << 32;
    }

    [LineNumberTable(2847)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal REGlobalData()
    {
    }
  }
}
