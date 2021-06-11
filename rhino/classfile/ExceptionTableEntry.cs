// Decompiled with JetBrains decompiler
// Type: rhino.classfile.ExceptionTableEntry
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.classfile
{
  internal sealed class ExceptionTableEntry : Object
  {
    internal int itsStartLabel;
    internal int itsEndLabel;
    internal int itsHandlerLabel;
    internal short itsCatchType;

    [LineNumberTable(new byte[] {159, 141, 99, 104, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ExceptionTableEntry([In] int obj0, [In] int obj1, [In] int obj2, [In] short obj3)
    {
      int num = (int) obj3;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ExceptionTableEntry exceptionTableEntry = this;
      this.itsStartLabel = obj0;
      this.itsEndLabel = obj1;
      this.itsHandlerLabel = obj2;
      this.itsCatchType = (short) num;
    }
  }
}
