// Decompiled with JetBrains decompiler
// Type: rhino.regexp.CompilerState
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
  internal class CompilerState : Object
  {
    internal Context cx;
    internal char[] cpbegin;
    internal int cpend;
    internal int cp;
    internal int flags;
    internal int backReferenceLimit;
    internal int maxBackReference;
    internal int parenCount;
    internal int parenNesting;
    internal int classCount;
    internal int progLength;
    internal RENode result;

    [LineNumberTable(new byte[] {170, 98, 104, 103, 103, 103, 103, 104, 107, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal CompilerState([In] Context obj0, [In] char[] obj1, [In] int obj2, [In] int obj3)
    {
      CompilerState compilerState = this;
      this.cx = obj0;
      this.cpbegin = obj1;
      this.cp = 0;
      this.cpend = obj2;
      this.flags = obj3;
      this.backReferenceLimit = int.MaxValue;
      this.maxBackReference = 0;
      this.parenCount = 0;
      this.classCount = 0;
      this.progLength = 0;
    }
  }
}
