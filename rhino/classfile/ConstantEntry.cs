// Decompiled with JetBrains decompiler
// Type: rhino.classfile.ConstantEntry
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.classfile
{
  internal sealed class ConstantEntry : Object
  {
    [Modifiers]
    private int type;
    [Modifiers]
    private int intval;
    private long longval;
    [Modifiers]
    private string str1;
    [Modifiers]
    private string str2;
    [Modifiers]
    private int hashcode;

    [LineNumberTable(new byte[] {159, 153, 104, 103, 103, 103, 104, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ConstantEntry([In] int obj0, [In] int obj1, [In] string obj2, [In] string obj3)
    {
      ConstantEntry constantEntry = this;
      this.type = obj0;
      this.intval = obj1;
      this.str1 = obj2;
      this.str2 = obj3;
      this.hashcode = obj0 ^ obj1 + String.instancehelper_hashCode(obj2) * String.instancehelper_hashCode(obj3);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => this.hashcode;

    [LineNumberTable(new byte[] {159, 168, 104, 130, 103, 110, 130, 191, 51, 175, 143, 159, 12, 122, 115, 11, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals([In] object obj0)
    {
      if (!(obj0 is ConstantEntry))
        return false;
      ConstantEntry constantEntry = (ConstantEntry) obj0;
      if (this.type != constantEntry.type)
        return false;
      switch (this.type)
      {
        case 3:
        case 4:
          return this.intval == constantEntry.intval;
        case 5:
        case 6:
          return this.longval == constantEntry.longval;
        case 12:
          return String.instancehelper_equals(this.str1, (object) constantEntry.str1) && String.instancehelper_equals(this.str2, (object) constantEntry.str2);
        case 18:
          return this.intval == constantEntry.intval && String.instancehelper_equals(this.str1, (object) constantEntry.str1) && String.instancehelper_equals(this.str2, (object) constantEntry.str2);
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("unsupported constant type");
      }
    }
  }
}
