// Decompiled with JetBrains decompiler
// Type: rhino.classfile.ClassFileField
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.classfile
{
  internal sealed class ClassFileField : Object
  {
    [Modifiers]
    private short itsNameIndex;
    [Modifiers]
    private short itsTypeIndex;
    [Modifiers]
    private short itsFlags;
    private bool itsHasAttributes;
    private short itsAttr1;
    private short itsAttr2;
    private short itsAttr3;
    private int itsIndex;

    [LineNumberTable(new byte[] {159, 141, 70, 104, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ClassFileField([In] short obj0, [In] short obj1, [In] short obj2)
    {
      int num1 = (int) obj0;
      int num2 = (int) obj1;
      int num3 = (int) obj2;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ClassFileField classFileField = this;
      this.itsNameIndex = (short) num1;
      this.itsTypeIndex = (short) num2;
      this.itsFlags = (short) num3;
      this.itsHasAttributes = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setAttributes([In] short obj0, [In] short obj1, [In] short obj2, [In] int obj3)
    {
      int num1 = (int) obj0;
      int num2 = (int) obj1;
      int num3 = (int) obj2;
      this.itsHasAttributes = true;
      this.itsAttr1 = (short) num1;
      this.itsAttr2 = (short) num2;
      this.itsAttr3 = (short) num3;
      this.itsIndex = obj3;
    }

    [LineNumberTable(new byte[] {159, 162, 111, 111, 111, 136, 140, 106, 111, 111, 111, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int write([In] byte[] obj0, [In] int obj1)
    {
      obj1 = ClassFileWriter.putInt16((int) this.itsFlags, obj0, obj1);
      obj1 = ClassFileWriter.putInt16((int) this.itsNameIndex, obj0, obj1);
      obj1 = ClassFileWriter.putInt16((int) this.itsTypeIndex, obj0, obj1);
      if (!this.itsHasAttributes)
      {
        obj1 = ClassFileWriter.putInt16(0, obj0, obj1);
      }
      else
      {
        obj1 = ClassFileWriter.putInt16(1, obj0, obj1);
        obj1 = ClassFileWriter.putInt16((int) this.itsAttr1, obj0, obj1);
        obj1 = ClassFileWriter.putInt16((int) this.itsAttr2, obj0, obj1);
        obj1 = ClassFileWriter.putInt16((int) this.itsAttr3, obj0, obj1);
        obj1 = ClassFileWriter.putInt16(this.itsIndex, obj0, obj1);
      }
      return obj1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getWriteSize()
    {
      int num = 6;
      return this.itsHasAttributes ? num + 10 : num + 2;
    }
  }
}
