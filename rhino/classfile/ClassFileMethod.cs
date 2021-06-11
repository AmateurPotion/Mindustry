// Decompiled with JetBrains decompiler
// Type: rhino.classfile.ClassFileMethod
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.classfile
{
  internal sealed class ClassFileMethod : Object
  {
    [Modifiers]
    private string itsName;
    [Modifiers]
    private string itsType;
    [Modifiers]
    private short itsNameIndex;
    [Modifiers]
    private short itsTypeIndex;
    [Modifiers]
    private short itsFlags;
    private byte[] itsCodeAttribute;

    [LineNumberTable(new byte[] {159, 141, 104, 104, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ClassFileMethod([In] string obj0, [In] short obj1, [In] string obj2, [In] short obj3, [In] short obj4)
    {
      int num1 = (int) obj1;
      int num2 = (int) obj3;
      int num3 = (int) obj4;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ClassFileMethod classFileMethod = this;
      this.itsName = obj0;
      this.itsNameIndex = (short) num1;
      this.itsType = obj2;
      this.itsTypeIndex = (short) num2;
      this.itsFlags = (short) num3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setCodeAttribute([In] byte[] obj0) => this.itsCodeAttribute = obj0;

    [LineNumberTable(new byte[] {159, 160, 111, 111, 143, 106, 149, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int write([In] byte[] obj0, [In] int obj1)
    {
      obj1 = ClassFileWriter.putInt16((int) this.itsFlags, obj0, obj1);
      obj1 = ClassFileWriter.putInt16((int) this.itsNameIndex, obj0, obj1);
      obj1 = ClassFileWriter.putInt16((int) this.itsTypeIndex, obj0, obj1);
      obj1 = ClassFileWriter.putInt16(1, obj0, obj1);
      ByteCodeHelper.arraycopy_primitive_1((Array) this.itsCodeAttribute, 0, (Array) obj0, obj1, this.itsCodeAttribute.Length);
      obj1 += this.itsCodeAttribute.Length;
      return obj1;
    }

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getWriteSize() => 8 + this.itsCodeAttribute.Length;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getName() => this.itsName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getType() => this.itsType;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual short getFlags() => this.itsFlags;
  }
}
