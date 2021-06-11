// Decompiled with JetBrains decompiler
// Type: rhino.classfile.ConstantPool
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
  internal sealed class ConstantPool : Object
  {
    private const int ConstantPoolSize = 256;
    internal const byte CONSTANT_Class = 7;
    internal const byte CONSTANT_Fieldref = 9;
    internal const byte CONSTANT_Methodref = 10;
    internal const byte CONSTANT_InterfaceMethodref = 11;
    internal const byte CONSTANT_String = 8;
    internal const byte CONSTANT_Integer = 3;
    internal const byte CONSTANT_Float = 4;
    internal const byte CONSTANT_Long = 5;
    internal const byte CONSTANT_Double = 6;
    internal const byte CONSTANT_NameAndType = 12;
    internal const byte CONSTANT_Utf8 = 1;
    internal const byte CONSTANT_MethodType = 16;
    internal const byte CONSTANT_MethodHandle = 15;
    internal const byte CONSTANT_InvokeDynamic = 18;
    [Modifiers]
    private ClassFileWriter cfw;
    private const int MAX_UTF_ENCODING_SIZE = 65535;
    [Modifiers]
    private UintMap itsStringConstHash;
    [Modifiers]
    private ObjToIntMap itsUtf8Hash;
    [Modifiers]
    private ObjToIntMap itsFieldRefHash;
    [Modifiers]
    private ObjToIntMap itsMethodRefHash;
    [Modifiers]
    private ObjToIntMap itsClassHash;
    [Modifiers]
    private ObjToIntMap itsConstantHash;
    private int itsTop;
    private int itsTopIndex;
    [Modifiers]
    private UintMap itsConstantData;
    [Modifiers]
    private UintMap itsPoolTypes;
    private byte[] itsPool;

    [LineNumberTable(new byte[] {160, 211, 142, 135, 106, 123, 107, 155, 185, 103, 124, 127, 2, 120, 116, 109, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual short addMethodHandle([In] ClassFileWriter.MHandle obj0)
    {
      int key = this.itsConstantHash.get((object) obj0, -1);
      if (key == -1)
      {
        int num1 = (sbyte) obj0.tag > (sbyte) 4 ? (obj0.tag != (byte) 9 ? (int) this.addMethodRef(obj0.owner, obj0.name, obj0.desc) : (int) this.addInterfaceMethodRef(obj0.owner, obj0.name, obj0.desc)) : (int) this.addFieldRef(obj0.owner, obj0.name, obj0.desc);
        this.ensure(4);
        byte[] itsPool1 = this.itsPool;
        ConstantPool constantPool1 = this;
        int itsTop1 = constantPool1.itsTop;
        ConstantPool constantPool2 = constantPool1;
        int index1 = itsTop1;
        constantPool2.itsTop = itsTop1 + 1;
        itsPool1[index1] = (byte) 15;
        byte[] itsPool2 = this.itsPool;
        ConstantPool constantPool3 = this;
        int itsTop2 = constantPool3.itsTop;
        ConstantPool constantPool4 = constantPool3;
        int index2 = itsTop2;
        constantPool4.itsTop = itsTop2 + 1;
        int tag = (int) (sbyte) obj0.tag;
        itsPool2[index2] = (byte) tag;
        this.itsTop = ClassFileWriter.putInt16(num1, this.itsPool, this.itsTop);
        ConstantPool constantPool5 = this;
        int itsTopIndex = constantPool5.itsTopIndex;
        ConstantPool constantPool6 = constantPool5;
        int num2 = itsTopIndex;
        constantPool6.itsTopIndex = itsTopIndex + 1;
        key = num2;
        this.itsConstantHash.put((object) obj0, key);
        this.itsPoolTypes.put(key, 15);
      }
      return (short) key;
    }

    [LineNumberTable(new byte[] {44, 152, 114, 104, 114, 104, 120, 104, 115, 104, 114, 104, 115, 104, 173, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int addConstant([In] object obj0)
    {
      switch (obj0)
      {
        case Integer _:
        case Byte _:
        case Short _:
          return this.addConstant(((Number) obj0).intValue());
        case Character _:
          return this.addConstant((int) ((Character) obj0).charValue());
        case Boolean _:
          return this.addConstant(!((Boolean) obj0).booleanValue() ? 0 : 1);
        case Float _:
          return this.addConstant(((Float) obj0).floatValue());
        case Long _:
          return this.addConstant(((Long) obj0).longValue());
        case Double _:
          return this.addConstant(((Double) obj0).doubleValue());
        case string _:
          return this.addConstant((string) obj0);
        case ClassFileWriter.MHandle _:
          return (int) this.addMethodHandle((ClassFileWriter.MHandle) obj0);
        default:
          string str = new StringBuilder().append("value ").append(obj0).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {159, 148, 232, 161, 114, 107, 107, 107, 107, 107, 203, 107, 235, 158, 133, 103, 103, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ConstantPool([In] ClassFileWriter obj0)
    {
      ConstantPool constantPool = this;
      this.itsStringConstHash = new UintMap();
      this.itsUtf8Hash = new ObjToIntMap();
      this.itsFieldRefHash = new ObjToIntMap();
      this.itsMethodRefHash = new ObjToIntMap();
      this.itsClassHash = new ObjToIntMap();
      this.itsConstantHash = new ObjToIntMap();
      this.itsConstantData = new UintMap();
      this.itsPoolTypes = new UintMap();
      this.cfw = obj0;
      this.itsTopIndex = 1;
      this.itsPool = new byte[256];
      this.itsTop = 0;
    }

    [LineNumberTable(new byte[] {160, 108, 110, 103, 98, 107, 103, 110, 100, 173, 103, 104, 103, 125, 120, 118, 109, 105, 205, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual short addClass([In] string obj0)
    {
      int key = this.itsClassHash.get((object) obj0, -1);
      if (key == -1)
      {
        string str = obj0;
        if (String.instancehelper_indexOf(obj0, 46) > 0)
        {
          str = ClassFileWriter.getSlashedForm(obj0);
          key = this.itsClassHash.get((object) str, -1);
          if (key != -1)
            this.itsClassHash.put((object) obj0, key);
        }
        if (key == -1)
        {
          int num1 = (int) this.addUtf8(str);
          this.ensure(3);
          byte[] itsPool = this.itsPool;
          ConstantPool constantPool1 = this;
          int itsTop = constantPool1.itsTop;
          ConstantPool constantPool2 = constantPool1;
          int index = itsTop;
          constantPool2.itsTop = itsTop + 1;
          itsPool[index] = (byte) 7;
          this.itsTop = ClassFileWriter.putInt16(num1, this.itsPool, this.itsTop);
          ConstantPool constantPool3 = this;
          int itsTopIndex = constantPool3.itsTopIndex;
          ConstantPool constantPool4 = constantPool3;
          int num2 = itsTopIndex;
          constantPool4.itsTopIndex = itsTopIndex + 1;
          key = num2;
          this.itsClassHash.put((object) str, key);
          if (!String.instancehelper_equals(obj0, (object) str))
            this.itsClassHash.put((object) obj0, key);
        }
      }
      this.setConstantData(key, (object) obj0);
      this.itsPoolTypes.put(key, 7);
      return (short) key;
    }

    [LineNumberTable(new byte[] {105, 110, 103, 135, 104, 135, 162, 107, 135, 109, 132, 110, 139, 107, 103, 106, 116, 105, 120, 122, 154, 119, 248, 54, 235, 78, 110, 105, 164, 116, 146, 103, 121, 173, 99, 176, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual short addUtf8([In] string obj0)
    {
      int key = this.itsUtf8Hash.get((object) obj0, -1);
      if (key == -1)
      {
        int num1 = String.instancehelper_length(obj0);
        int num2;
        if (num1 > (int) ushort.MaxValue)
        {
          num2 = 1;
        }
        else
        {
          num2 = 0;
          this.ensure(3 + num1 * 3);
          int itsTop = this.itsTop;
          byte[] itsPool1 = this.itsPool;
          int index1 = itsTop;
          int num3 = itsTop + 1;
          itsPool1[index1] = (byte) 1;
          int num4 = num3 + 2;
          char[] charBuffer = this.cfw.getCharBuffer(num1);
          String.instancehelper_getChars(obj0, 0, num1, charBuffer, 0);
          for (int index2 = 0; index2 != num1; ++index2)
          {
            int num5 = (int) charBuffer[index2];
            if (num5 != 0 && num5 <= (int) sbyte.MaxValue)
            {
              byte[] itsPool2 = this.itsPool;
              int index3 = num4;
              ++num4;
              int num6 = (int) (sbyte) num5;
              itsPool2[index3] = (byte) num6;
            }
            else if (num5 > 2047)
            {
              byte[] itsPool2 = this.itsPool;
              int index3 = num4;
              int num6 = num4 + 1;
              int num7 = (int) (sbyte) (224 | num5 >> 12);
              itsPool2[index3] = (byte) num7;
              byte[] itsPool3 = this.itsPool;
              int index4 = num6;
              int num8 = num6 + 1;
              int num9 = (int) (sbyte) (128 | num5 >> 6 & 63);
              itsPool3[index4] = (byte) num9;
              byte[] itsPool4 = this.itsPool;
              int index5 = num8;
              num4 = num8 + 1;
              int num10 = (int) (sbyte) (128 | num5 & 63);
              itsPool4[index5] = (byte) num10;
            }
            else
            {
              byte[] itsPool2 = this.itsPool;
              int index3 = num4;
              int num6 = num4 + 1;
              int num7 = (int) (sbyte) (192 | num5 >> 6);
              itsPool2[index3] = (byte) num7;
              byte[] itsPool3 = this.itsPool;
              int index4 = num6;
              num4 = num6 + 1;
              int num8 = (int) (sbyte) (128 | num5 & 63);
              itsPool3[index4] = (byte) num8;
            }
          }
          int num11 = num4 - (this.itsTop + 1 + 2);
          if (num11 > (int) ushort.MaxValue)
          {
            num2 = 1;
          }
          else
          {
            this.itsPool[this.itsTop + 1] = (byte) ((uint) num11 >> 8);
            this.itsPool[this.itsTop + 2] = (byte) num11;
            this.itsTop = num4;
            ConstantPool constantPool1 = this;
            int itsTopIndex = constantPool1.itsTopIndex;
            ConstantPool constantPool2 = constantPool1;
            int num5 = itsTopIndex;
            constantPool2.itsTopIndex = itsTopIndex + 1;
            key = num5;
            this.itsUtf8Hash.put((object) obj0, key);
          }
        }
        if (num2 != 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Too big string");
        }
      }
      this.setConstantData(key, (object) obj0);
      this.itsPoolTypes.put(key, 1);
      return (short) key;
    }

    [LineNumberTable(new byte[] {159, 184, 103, 123, 120, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int addConstant([In] int obj0)
    {
      this.ensure(5);
      byte[] itsPool = this.itsPool;
      ConstantPool constantPool1 = this;
      int itsTop = constantPool1.itsTop;
      ConstantPool constantPool2 = constantPool1;
      int index = itsTop;
      constantPool2.itsTop = itsTop + 1;
      itsPool[index] = (byte) 3;
      this.itsTop = ClassFileWriter.putInt32(obj0, this.itsPool, this.itsTop);
      this.itsPoolTypes.put(this.itsTopIndex, 3);
      ConstantPool constantPool3 = this;
      int itsTopIndex = constantPool3.itsTopIndex;
      ConstantPool constantPool4 = constantPool3;
      int num = itsTopIndex;
      constantPool4.itsTopIndex = itsTopIndex + 1;
      return (int) (short) num;
    }

    [LineNumberTable(new byte[] {0, 104, 123, 120, 103, 110, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int addConstant([In] long obj0)
    {
      this.ensure(9);
      byte[] itsPool = this.itsPool;
      ConstantPool constantPool1 = this;
      int itsTop = constantPool1.itsTop;
      ConstantPool constantPool2 = constantPool1;
      int index = itsTop;
      constantPool2.itsTop = itsTop + 1;
      itsPool[index] = (byte) 5;
      this.itsTop = ClassFileWriter.putInt64(obj0, this.itsPool, this.itsTop);
      int itsTopIndex = this.itsTopIndex;
      this.itsTopIndex += 2;
      this.itsPoolTypes.put(itsTopIndex, 5);
      return itsTopIndex;
    }

    [LineNumberTable(new byte[] {19, 104, 123, 104, 120, 103, 110, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int addConstant([In] double obj0)
    {
      this.ensure(9);
      byte[] itsPool = this.itsPool;
      ConstantPool constantPool1 = this;
      int itsTop = constantPool1.itsTop;
      ConstantPool constantPool2 = constantPool1;
      int index = itsTop;
      constantPool2.itsTop = itsTop + 1;
      itsPool[index] = (byte) 6;
      this.itsTop = ClassFileWriter.putInt64(Double.doubleToLongBits(obj0), this.itsPool, this.itsTop);
      int itsTopIndex = this.itsTopIndex;
      this.itsTopIndex += 2;
      this.itsPoolTypes.put(itsTopIndex, 6);
      return itsTopIndex;
    }

    [LineNumberTable(new byte[] {10, 103, 123, 104, 120, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int addConstant([In] float obj0)
    {
      this.ensure(5);
      byte[] itsPool = this.itsPool;
      ConstantPool constantPool1 = this;
      int itsTop = constantPool1.itsTop;
      ConstantPool constantPool2 = constantPool1;
      int index = itsTop;
      constantPool2.itsTop = itsTop + 1;
      itsPool[index] = (byte) 4;
      this.itsTop = ClassFileWriter.putInt32(Float.floatToIntBits(obj0), this.itsPool, this.itsTop);
      this.itsPoolTypes.put(this.itsTopIndex, 4);
      ConstantPool constantPool3 = this;
      int itsTopIndex = constantPool3.itsTopIndex;
      ConstantPool constantPool4 = constantPool3;
      int num = itsTopIndex;
      constantPool4.itsTopIndex = itsTopIndex + 1;
      return num;
    }

    [LineNumberTable(new byte[] {30, 110, 110, 103, 116, 103, 123, 120, 141, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int addConstant([In] string obj0)
    {
      int key1 = (int) ushort.MaxValue & (int) this.addUtf8(obj0);
      int key2 = this.itsStringConstHash.getInt(key1, -1);
      if (key2 == -1)
      {
        ConstantPool constantPool1 = this;
        int itsTopIndex = constantPool1.itsTopIndex;
        ConstantPool constantPool2 = constantPool1;
        int num = itsTopIndex;
        constantPool2.itsTopIndex = itsTopIndex + 1;
        key2 = num;
        this.ensure(3);
        byte[] itsPool = this.itsPool;
        ConstantPool constantPool3 = this;
        int itsTop = constantPool3.itsTop;
        ConstantPool constantPool4 = constantPool3;
        int index = itsTop;
        constantPool4.itsTop = itsTop + 1;
        itsPool[index] = (byte) 8;
        this.itsTop = ClassFileWriter.putInt16(key1, this.itsPool, this.itsTop);
        this.itsStringConstHash.put(key1, key2);
      }
      this.itsPoolTypes.put(key2, 8);
      return key2;
    }

    [LineNumberTable(new byte[] {160, 136, 169, 110, 103, 105, 104, 103, 127, 2, 120, 120, 121, 141, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual short addFieldRef([In] string obj0, [In] string obj1, [In] string obj2)
    {
      FieldOrMethodRef fieldOrMethodRef = new FieldOrMethodRef(obj0, obj1, obj2);
      int key = this.itsFieldRefHash.get((object) fieldOrMethodRef, -1);
      if (key == -1)
      {
        int num1 = (int) this.addNameAndType(obj1, obj2);
        int num2 = (int) this.addClass(obj0);
        this.ensure(5);
        byte[] itsPool = this.itsPool;
        ConstantPool constantPool1 = this;
        int itsTop = constantPool1.itsTop;
        ConstantPool constantPool2 = constantPool1;
        int index = itsTop;
        constantPool2.itsTop = itsTop + 1;
        itsPool[index] = (byte) 9;
        this.itsTop = ClassFileWriter.putInt16(num2, this.itsPool, this.itsTop);
        this.itsTop = ClassFileWriter.putInt16(num1, this.itsPool, this.itsTop);
        ConstantPool constantPool3 = this;
        int itsTopIndex = constantPool3.itsTopIndex;
        ConstantPool constantPool4 = constantPool3;
        int num3 = itsTopIndex;
        constantPool4.itsTopIndex = itsTopIndex + 1;
        key = num3;
        this.itsFieldRefHash.put((object) fieldOrMethodRef, key);
      }
      this.setConstantData(key, (object) fieldOrMethodRef);
      this.itsPoolTypes.put(key, 9);
      return (short) key;
    }

    [LineNumberTable(new byte[] {160, 178, 105, 104, 103, 124, 120, 120, 138, 110, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual short addInterfaceMethodRef([In] string obj0, [In] string obj1, [In] string obj2)
    {
      int num1 = (int) this.addNameAndType(obj1, obj2);
      int num2 = (int) this.addClass(obj0);
      this.ensure(5);
      byte[] itsPool = this.itsPool;
      ConstantPool constantPool1 = this;
      int itsTop = constantPool1.itsTop;
      ConstantPool constantPool2 = constantPool1;
      int index = itsTop;
      constantPool2.itsTop = itsTop + 1;
      itsPool[index] = (byte) 11;
      this.itsTop = ClassFileWriter.putInt16(num2, this.itsPool, this.itsTop);
      this.itsTop = ClassFileWriter.putInt16(num1, this.itsPool, this.itsTop);
      this.setConstantData(this.itsTopIndex, (object) new FieldOrMethodRef(obj0, obj1, obj2));
      this.itsPoolTypes.put(this.itsTopIndex, 11);
      ConstantPool constantPool3 = this;
      int itsTopIndex = constantPool3.itsTopIndex;
      ConstantPool constantPool4 = constantPool3;
      int num3 = itsTopIndex;
      constantPool4.itsTopIndex = itsTopIndex + 1;
      return (short) num3;
    }

    [LineNumberTable(new byte[] {160, 157, 169, 110, 103, 105, 104, 103, 127, 2, 120, 120, 121, 141, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual short addMethodRef([In] string obj0, [In] string obj1, [In] string obj2)
    {
      FieldOrMethodRef fieldOrMethodRef = new FieldOrMethodRef(obj0, obj1, obj2);
      int key = this.itsMethodRefHash.get((object) fieldOrMethodRef, -1);
      if (key == -1)
      {
        int num1 = (int) this.addNameAndType(obj1, obj2);
        int num2 = (int) this.addClass(obj0);
        this.ensure(5);
        byte[] itsPool = this.itsPool;
        ConstantPool constantPool1 = this;
        int itsTop = constantPool1.itsTop;
        ConstantPool constantPool2 = constantPool1;
        int index = itsTop;
        constantPool2.itsTop = itsTop + 1;
        itsPool[index] = (byte) 10;
        this.itsTop = ClassFileWriter.putInt16(num2, this.itsPool, this.itsTop);
        this.itsTop = ClassFileWriter.putInt16(num1, this.itsPool, this.itsTop);
        ConstantPool constantPool3 = this;
        int itsTopIndex = constantPool3.itsTopIndex;
        ConstantPool constantPool4 = constantPool3;
        int num3 = itsTopIndex;
        constantPool4.itsTopIndex = itsTopIndex + 1;
        key = num3;
        this.itsMethodRefHash.put((object) fieldOrMethodRef, key);
      }
      this.setConstantData(key, (object) fieldOrMethodRef);
      this.itsPoolTypes.put(key, 10);
      return (short) key;
    }

    [LineNumberTable(new byte[] {160, 192, 139, 142, 103, 105, 103, 126, 120, 120, 118, 109, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual short addInvokeDynamic([In] string obj0, [In] string obj1, [In] int obj2)
    {
      ConstantEntry constantEntry = new ConstantEntry(18, obj2, obj0, obj1);
      int key = this.itsConstantHash.get((object) constantEntry, -1);
      if (key == -1)
      {
        int num1 = (int) this.addNameAndType(obj0, obj1);
        this.ensure(5);
        byte[] itsPool = this.itsPool;
        ConstantPool constantPool1 = this;
        int itsTop = constantPool1.itsTop;
        ConstantPool constantPool2 = constantPool1;
        int index = itsTop;
        constantPool2.itsTop = itsTop + 1;
        itsPool[index] = (byte) 18;
        this.itsTop = ClassFileWriter.putInt16(obj2, this.itsPool, this.itsTop);
        this.itsTop = ClassFileWriter.putInt16(num1, this.itsPool, this.itsTop);
        ConstantPool constantPool3 = this;
        int itsTopIndex = constantPool3.itsTopIndex;
        ConstantPool constantPool4 = constantPool3;
        int num2 = itsTopIndex;
        constantPool4.itsTopIndex = itsTopIndex + 1;
        key = num2;
        this.itsConstantHash.put((object) constantEntry, key);
        this.setConstantData(key, (object) obj1);
        this.itsPoolTypes.put(key, 18);
      }
      return (short) key;
    }

    [LineNumberTable(new byte[] {84, 108, 130, 102, 102, 104, 105, 102, 104, 135, 133, 100, 226, 54, 230, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getUtfEncodingLimit([In] string obj0, [In] int obj1, [In] int obj2)
    {
      if ((obj2 - obj1) * 3 <= (int) ushort.MaxValue)
        return obj2;
      int maxValue = (int) ushort.MaxValue;
      for (int index = obj1; index != obj2; ++index)
      {
        int num = (int) String.instancehelper_charAt(obj0, index);
        if (0 != num && num <= (int) sbyte.MaxValue)
          maxValue += -1;
        else if (num < 2047)
          maxValue += -2;
        else
          maxValue += -3;
        if (maxValue < 0)
          return index;
      }
      return obj2;
    }

    [LineNumberTable(new byte[] {70, 103, 106, 98, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isUnderUtfEncodingLimit([In] string obj0)
    {
      int num = String.instancehelper_length(obj0);
      if (num * 3 <= (int) ushort.MaxValue)
        return true;
      return num <= (int) ushort.MaxValue && num == this.getUtfEncodingLimit(obj0, 0, num);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getWriteSize() => 2 + this.itsTop;

    [LineNumberTable(new byte[] {159, 173, 112, 116, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int write([In] byte[] obj0, [In] int obj1)
    {
      obj1 = ClassFileWriter.putInt16((int) (short) this.itsTopIndex, obj0, obj1);
      ByteCodeHelper.arraycopy_primitive_1((Array) this.itsPool, 0, (Array) obj0, obj1, this.itsTop);
      obj1 += this.itsTop;
      return obj1;
    }

    [LineNumberTable(357)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual byte getConstantType([In] int obj0) => (byte) this.itsPoolTypes.getInt(obj0, 0);

    [LineNumberTable(349)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object getConstantData([In] int obj0) => this.itsConstantData.getObject(obj0);

    [LineNumberTable(new byte[] {160, 247, 113, 106, 107, 137, 103, 116, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void ensure([In] int obj0)
    {
      if (this.itsTop + obj0 <= this.itsPool.Length)
        return;
      int length = this.itsPool.Length * 2;
      if (this.itsTop + obj0 > length)
        length = this.itsTop + obj0;
      byte[] numArray = new byte[length];
      ByteCodeHelper.arraycopy_primitive_1((Array) this.itsPool, 0, (Array) numArray, 0, this.itsTop);
      this.itsPool = numArray;
    }

    [LineNumberTable(new byte[] {160, 239, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setConstantData([In] int obj0, [In] object obj1) => this.itsConstantData.put(obj0, obj1);

    [LineNumberTable(new byte[] {160, 97, 104, 104, 103, 124, 120, 120, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private short addNameAndType([In] string obj0, [In] string obj1)
    {
      int num1 = (int) this.addUtf8(obj0);
      int num2 = (int) this.addUtf8(obj1);
      this.ensure(5);
      byte[] itsPool = this.itsPool;
      ConstantPool constantPool1 = this;
      int itsTop = constantPool1.itsTop;
      ConstantPool constantPool2 = constantPool1;
      int index = itsTop;
      constantPool2.itsTop = itsTop + 1;
      itsPool[index] = (byte) 12;
      this.itsTop = ClassFileWriter.putInt16(num1, this.itsPool, this.itsTop);
      this.itsTop = ClassFileWriter.putInt16(num2, this.itsPool, this.itsTop);
      this.itsPoolTypes.put(this.itsTopIndex, 12);
      ConstantPool constantPool3 = this;
      int itsTopIndex = constantPool3.itsTopIndex;
      ConstantPool constantPool4 = constantPool3;
      int num3 = itsTopIndex;
      constantPool4.itsTopIndex = itsTopIndex + 1;
      return (short) num3;
    }
  }
}
