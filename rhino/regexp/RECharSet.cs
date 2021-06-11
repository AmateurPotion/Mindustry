// Decompiled with JetBrains decompiler
// Type: rhino.regexp.RECharSet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.regexp
{
  [SourceFile("NativeRegExp.java")]
  internal sealed class RECharSet : Object
  {
    [Modifiers]
    internal int length;
    [Modifiers]
    internal int startIndex;
    [Modifiers]
    internal int strlength;
    [Modifiers]
    internal bool sense;
    [NonSerialized]
    internal volatile bool converted;
    [NonSerialized]
    internal volatile byte[] bits;

    [LineNumberTable(new byte[] {156, 187, 99, 104, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal RECharSet([In] int obj0, [In] int obj1, [In] int obj2, [In] bool obj3)
    {
      int num = obj3 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      RECharSet reCharSet = this;
      this.length = obj0;
      this.startIndex = obj1;
      this.strlength = obj2;
      this.sense = num != 0;
    }
  }
}
