// Decompiled with JetBrains decompiler
// Type: rhino.regexp.RECompiled
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
  internal class RECompiled : Object
  {
    [Modifiers]
    internal char[] source;
    internal int parenCount;
    internal int flags;
    internal byte[] program;
    internal int classCount;
    internal RECharSet[] classList;
    internal int anchorCh;

    [LineNumberTable(new byte[] {170, 58, 8, 167, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal RECompiled([In] string obj0)
    {
      RECompiled reCompiled = this;
      this.anchorCh = -1;
      this.source = String.instancehelper_toCharArray(obj0);
    }
  }
}
