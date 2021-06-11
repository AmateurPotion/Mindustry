// Decompiled with JetBrains decompiler
// Type: rhino.classfile.FieldOrMethodRef
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.classfile
{
  internal sealed class FieldOrMethodRef : Object
  {
    [Modifiers]
    private string className;
    [Modifiers]
    private string name;
    [Modifiers]
    private string type;
    private int hashCode;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getType() => this.type;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName() => this.name;

    [LineNumberTable(new byte[] {159, 146, 232, 107, 231, 22, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal FieldOrMethodRef([In] string obj0, [In] string obj1, [In] string obj2)
    {
      FieldOrMethodRef fieldOrMethodRef = this;
      this.hashCode = -1;
      this.className = obj0;
      this.name = obj1;
      this.type = obj2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getClassName() => this.className;

    [LineNumberTable(new byte[] {159, 166, 104, 130, 103, 127, 0, 115, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals([In] object obj0)
    {
      if (!(obj0 is FieldOrMethodRef))
        return false;
      FieldOrMethodRef fieldOrMethodRef = (FieldOrMethodRef) obj0;
      return String.instancehelper_equals(this.className, (object) fieldOrMethodRef.className) && String.instancehelper_equals(this.name, (object) fieldOrMethodRef.name) && String.instancehelper_equals(this.type, (object) fieldOrMethodRef.type);
    }

    [LineNumberTable(new byte[] {159, 177, 105, 108, 108, 108, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      if (this.hashCode == -1)
        this.hashCode = String.instancehelper_hashCode(this.className) ^ String.instancehelper_hashCode(this.name) ^ String.instancehelper_hashCode(this.type);
      return this.hashCode;
    }
  }
}
