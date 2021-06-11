// Decompiled with JetBrains decompiler
// Type: rhino.regexp.SubString
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.regexp
{
  public class SubString : Object
  {
    internal string str;
    internal int index;
    internal int length;

    [LineNumberTable(new byte[] {159, 150, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SubString()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SubString(string source, int start, int len)
    {
      SubString subString = this;
      this.str = source;
      this.index = start;
      this.length = len;
    }

    [LineNumberTable(new byte[] {159, 167, 159, 9, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.str == null ? "" : String.instancehelper_substring(this.str, this.index, this.index + this.length);

    [LineNumberTable(new byte[] {159, 153, 104, 103, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SubString(string str)
    {
      SubString subString = this;
      this.str = str;
      this.index = 0;
      this.length = String.instancehelper_length(str);
    }
  }
}
