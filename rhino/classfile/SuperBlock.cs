// Decompiled with JetBrains decompiler
// Type: rhino.classfile.SuperBlock
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
  internal sealed class SuperBlock : Object
  {
    [Modifiers]
    private int index;
    [Modifiers]
    private int start;
    [Modifiers]
    private int end;
    [Modifiers]
    private int[] locals;
    private int[] stack;
    private bool isInitialized;
    private bool isInQueue;

    [LineNumberTable(new byte[] {159, 153, 104, 103, 103, 103, 110, 114, 108, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SuperBlock([In] int obj0, [In] int obj1, [In] int obj2, [In] int[] obj3)
    {
      SuperBlock superBlock = this;
      this.index = obj0;
      this.start = obj1;
      this.end = obj2;
      this.locals = new int[obj3.Length];
      ByteCodeHelper.arraycopy_primitive_4((Array) obj3, 0, (Array) this.locals, 0, obj3.Length);
      this.stack = new int[0];
      this.isInitialized = false;
      this.isInQueue = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getStart() => this.start;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getEnd() => this.end;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getIndex() => this.index;

    [LineNumberTable(new byte[] {24, 104, 111, 109, 112, 103, 98, 149, 145, 146, 235, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool merge([In] int[] obj0, [In] int obj1, [In] int[] obj2, [In] int obj3, [In] ConstantPool obj4)
    {
      if (!this.isInitialized)
      {
        ByteCodeHelper.arraycopy_primitive_4((Array) obj0, 0, (Array) this.locals, 0, obj1);
        this.stack = new int[obj3];
        ByteCodeHelper.arraycopy_primitive_4((Array) obj2, 0, (Array) this.stack, 0, obj3);
        this.isInitialized = true;
        return true;
      }
      if (this.locals.Length == obj1 && this.stack.Length == obj3)
      {
        int num1 = this.mergeState(this.locals, obj0, obj1, obj4) ? 1 : 0;
        int num2 = this.mergeState(this.stack, obj2, obj3, obj4) ? 1 : 0;
        return num1 != 0 || num2 != 0;
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException("bad merge attempt");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isInitialized() => this.isInitialized;

    [LineNumberTable(new byte[] {159, 169, 109, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int[] getLocals()
    {
      int[] numArray = new int[this.locals.Length];
      ByteCodeHelper.arraycopy_primitive_4((Array) this.locals, 0, (Array) numArray, 0, this.locals.Length);
      return numArray;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setInQueue([In] bool obj0) => this.isInQueue = obj0;

    [LineNumberTable(new byte[] {17, 109, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int[] getStack()
    {
      int[] numArray = new int[this.stack.Length];
      ByteCodeHelper.arraycopy_primitive_4((Array) this.stack, 0, (Array) numArray, 0, this.stack.Length);
      return numArray;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isInQueue() => this.isInQueue;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setInitialized([In] bool obj0) => this.isInitialized = obj0;

    [LineNumberTable(new byte[] {159, 184, 138, 120, 103, 134, 132, 98, 102, 111, 4, 230, 69, 103, 107, 109, 112, 230, 61, 238, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int[] getTrimmedLocals()
    {
      int index1 = this.locals.Length - 1;
      while (index1 >= 0 && this.locals[index1] == 0 && !TypeInfo.isTwoWords(this.locals[index1 - 1]))
        index1 += -1;
      int num = index1 + 1;
      int length = num;
      for (int index2 = 0; index2 < num; ++index2)
      {
        if (TypeInfo.isTwoWords(this.locals[index2]))
          length += -1;
      }
      int[] numArray = new int[length];
      int index3 = 0;
      int index4 = 0;
      while (index3 < length)
      {
        numArray[index3] = this.locals[index4];
        if (TypeInfo.isTwoWords(this.locals[index4]))
          ++index4;
        ++index3;
        ++index4;
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {59, 98, 102, 132, 112, 102, 226, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool mergeState([In] int[] obj0, [In] int[] obj1, [In] int obj2, [In] ConstantPool obj3)
    {
      int num1 = 0;
      for (int index = 0; index < obj2; ++index)
      {
        int num2 = obj0[index];
        obj0[index] = TypeInfo.merge(obj0[index], obj1[index], obj3);
        if (num2 != obj0[index])
          num1 = 1;
      }
      return num1 != 0;
    }

    [LineNumberTable(131)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("sb ").append(this.index).toString();
  }
}
