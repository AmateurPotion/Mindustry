// Decompiled with JetBrains decompiler
// Type: rhino.regexp.REProgState
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
  internal class REProgState : Object
  {
    [Modifiers]
    internal REProgState previous;
    [Modifiers]
    internal int min;
    [Modifiers]
    internal int max;
    [Modifiers]
    internal int index;
    [Modifiers]
    internal int continuationOp;
    [Modifiers]
    internal int continuationPc;
    [Modifiers]
    internal REBackTrackData backTrack;

    [LineNumberTable(new byte[] {170, 128, 104, 103, 103, 103, 104, 104, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal REProgState(
      [In] REProgState obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] REBackTrackData obj4,
      [In] int obj5,
      [In] int obj6)
    {
      REProgState reProgState = this;
      this.previous = obj0;
      this.min = obj1;
      this.max = obj2;
      this.index = obj3;
      this.continuationOp = obj5;
      this.continuationPc = obj6;
      this.backTrack = obj4;
    }
  }
}
