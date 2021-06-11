// Decompiled with JetBrains decompiler
// Type: rhino.regexp.REBackTrackData
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
  internal class REBackTrackData : Object
  {
    [Modifiers]
    internal REBackTrackData previous;
    [Modifiers]
    internal int op;
    [Modifiers]
    internal int pc;
    [Modifiers]
    internal int cp;
    [Modifiers]
    internal int continuationOp;
    [Modifiers]
    internal int continuationPc;
    [Modifiers]
    internal long[] parens;
    [Modifiers]
    internal REProgState stateStackTop;

    [LineNumberTable(new byte[] {170, 151, 104, 108, 103, 103, 104, 104, 104, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal REBackTrackData(
      [In] REGlobalData obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5)
    {
      REBackTrackData reBackTrackData = this;
      this.previous = obj0.backTrackStackTop;
      this.op = obj1;
      this.pc = obj2;
      this.cp = obj3;
      this.continuationOp = obj4;
      this.continuationPc = obj5;
      this.parens = obj0.parens;
      this.stateStackTop = obj0.stateStackTop;
    }
  }
}
