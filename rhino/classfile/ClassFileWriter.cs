// Decompiled with JetBrains decompiler
// Type: rhino.classfile.ClassFileWriter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.classfile
{
  public class ClassFileWriter : Object
  {
    public const short ACC_PUBLIC = 1;
    public const short ACC_PRIVATE = 2;
    public const short ACC_PROTECTED = 4;
    public const short ACC_STATIC = 8;
    public const short ACC_FINAL = 16;
    public const short ACC_SUPER = 32;
    public const short ACC_SYNCHRONIZED = 32;
    public const short ACC_VOLATILE = 64;
    public const short ACC_TRANSIENT = 128;
    public const short ACC_NATIVE = 256;
    public const short ACC_ABSTRACT = 1024;
    private const int SuperBlockStartsSize = 4;
    private const int LineNumberTableSize = 16;
    private const int ExceptionTableSize = 4;
    [Modifiers]
    private static int MajorVersion;
    [Modifiers]
    private static int MinorVersion;
    [Modifiers]
    private static bool GenerateStackMap;
    private const int FileHeaderConstant = -889275714;
    private const bool DEBUGSTACK = false;
    private const bool DEBUGLABELS = false;
    private const bool DEBUGCODE = false;
    private const int MIN_LABEL_TABLE_SIZE = 32;
    private const int MIN_FIXUP_TABLE_SIZE = 40;
    private int[] itsSuperBlockStarts;
    private int itsSuperBlockStartsTop;
    private UintMap itsJumpFroms;
    private string generatedClassName;
    private ExceptionTableEntry[] itsExceptionTable;
    private int itsExceptionTableTop;
    private int[] itsLineNumberTable;
    private int itsLineNumberTableTop;
    private byte[] itsCodeBuffer;
    private int itsCodeBufferTop;
    private ConstantPool itsConstantPool;
    private ClassFileMethod itsCurrentMethod;
    private short itsStackTop;
    private short itsMaxStack;
    private short itsMaxLocals;
    private ObjArray itsMethods;
    private ObjArray itsFields;
    private ObjArray itsInterfaces;
    private short itsFlags;
    private short itsThisClassIndex;
    private short itsSuperClassIndex;
    private short itsSourceFileNameIndex;
    private int[] itsLabelTable;
    private int itsLabelTableTop;
    private long[] itsFixupTable;
    private int itsFixupTableTop;
    private ObjArray itsVarDescriptors;
    private ObjArray itsBootstrapMethods;
    private int itsBootstrapMethodsLength;
    private char[] tmpCharBuffer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {84, 232, 21, 103, 231, 69, 231, 70, 240, 71, 107, 107, 235, 75, 103, 237, 75, 103, 108, 114, 114, 99, 210, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClassFileWriter(string className, string superClassName, string sourceFileName)
    {
      ClassFileWriter classFileWriter = this;
      this.itsSuperBlockStarts = (int[]) null;
      this.itsSuperBlockStartsTop = 0;
      this.itsJumpFroms = (UintMap) null;
      this.itsCodeBuffer = new byte[256];
      this.itsMethods = new ObjArray();
      this.itsFields = new ObjArray();
      this.itsInterfaces = new ObjArray();
      this.itsBootstrapMethodsLength = 0;
      this.tmpCharBuffer = new char[64];
      this.generatedClassName = className;
      this.itsConstantPool = new ConstantPool(this);
      this.itsThisClassIndex = this.itsConstantPool.addClass(className);
      this.itsSuperClassIndex = this.itsConstantPool.addClass(superClassName);
      if (sourceFileName != null)
        this.itsSourceFileNameIndex = this.itsConstantPool.addUtf8(sourceFileName);
      this.itsFlags = (short) 33;
    }

    [LineNumberTable(new byte[] {158, 23, 162, 109, 109, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addField(string fieldName, string type, short flags)
    {
      int num = (int) flags;
      this.itsFields.add((object) new ClassFileField(this.itsConstantPool.addUtf8(fieldName), this.itsConstantPool.addUtf8(type), (short) num));
    }

    [LineNumberTable(new byte[] {165, 87, 109, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addInterface(string interfaceName) => this.itsInterfaces.add((object) Short.valueOf(this.itsConstantPool.addClass(interfaceName)));

    [LineNumberTable(new byte[] {171, 185, 98, 130, 98, 104, 100, 177, 104, 100, 241, 70, 98, 104, 137, 110, 110, 110, 111, 111, 111, 111, 116, 114, 126, 11, 200, 116, 114, 116, 11, 200, 116, 114, 116, 11, 200, 106, 107, 106, 113, 116, 114, 116, 120, 235, 61, 232, 70, 104, 106, 106, 175, 133, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] toByteArray()
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      if (this.itsBootstrapMethods != null)
      {
        ++num2;
        num1 = (int) this.itsConstantPool.addUtf8("BootstrapMethods");
      }
      if (this.itsSourceFileNameIndex != (short) 0)
      {
        ++num2;
        num3 = (int) this.itsConstantPool.addUtf8("SourceFile");
      }
      int num4 = 0;
      int writeSize = this.getWriteSize();
      byte[] numArray = new byte[writeSize];
      int num5 = ClassFileWriter.putInt32(-889275714, numArray, num4);
      int num6 = ClassFileWriter.putInt16(ClassFileWriter.MinorVersion, numArray, num5);
      int num7 = ClassFileWriter.putInt16(ClassFileWriter.MajorVersion, numArray, num6);
      int num8 = this.itsConstantPool.write(numArray, num7);
      int num9 = ClassFileWriter.putInt16((int) this.itsFlags, numArray, num8);
      int num10 = ClassFileWriter.putInt16((int) this.itsThisClassIndex, numArray, num9);
      int num11 = ClassFileWriter.putInt16((int) this.itsSuperClassIndex, numArray, num10);
      int num12 = ClassFileWriter.putInt16(this.itsInterfaces.size(), numArray, num11);
      for (int index = 0; index < this.itsInterfaces.size(); ++index)
        num12 = ClassFileWriter.putInt16((int) ((Short) this.itsInterfaces.get(index)).shortValue(), numArray, num12);
      int num13 = ClassFileWriter.putInt16(this.itsFields.size(), numArray, num12);
      for (int index = 0; index < this.itsFields.size(); ++index)
        num13 = ((ClassFileField) this.itsFields.get(index)).write(numArray, num13);
      int num14 = ClassFileWriter.putInt16(this.itsMethods.size(), numArray, num13);
      for (int index = 0; index < this.itsMethods.size(); ++index)
        num14 = ((ClassFileMethod) this.itsMethods.get(index)).write(numArray, num14);
      int num15 = ClassFileWriter.putInt16(num2, numArray, num14);
      if (this.itsBootstrapMethods != null)
      {
        int num16 = ClassFileWriter.putInt16(num1, numArray, num15);
        int num17 = ClassFileWriter.putInt32(this.itsBootstrapMethodsLength + 2, numArray, num16);
        num15 = ClassFileWriter.putInt16(this.itsBootstrapMethods.size(), numArray, num17);
        for (int index = 0; index < this.itsBootstrapMethods.size(); ++index)
        {
          ClassFileWriter.BootstrapEntry bootstrapEntry = (ClassFileWriter.BootstrapEntry) this.itsBootstrapMethods.get(index);
          ByteCodeHelper.arraycopy_primitive_1((Array) bootstrapEntry.code, 0, (Array) numArray, num15, bootstrapEntry.code.Length);
          num15 += bootstrapEntry.code.Length;
        }
      }
      if (this.itsSourceFileNameIndex != (short) 0)
      {
        int num16 = ClassFileWriter.putInt16(num3, numArray, num15);
        int num17 = ClassFileWriter.putInt32(2, numArray, num16);
        num15 = ClassFileWriter.putInt16((int) this.itsSourceFileNameIndex, numArray, num17);
      }
      if (num15 != writeSize)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException();
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {157, 255, 98, 109, 109, 144, 107, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void startMethod(string methodName, string type, short flags)
    {
      int num1 = (int) flags;
      int num2 = (int) this.itsConstantPool.addUtf8(methodName);
      int num3 = (int) this.itsConstantPool.addUtf8(type);
      this.itsCurrentMethod = new ClassFileMethod(methodName, (short) num2, type, (short) num3, (short) num1);
      this.itsJumpFroms = new UintMap();
      this.itsMethods.add((object) this.itsCurrentMethod);
      this.addSuperBlockStart(0);
    }

    [LineNumberTable(new byte[] {166, 138, 104, 112, 110, 108, 166, 103, 104, 105, 232, 69, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int theOpCode)
    {
      if (ClassFileWriter.opcodeCount(theOpCode) != 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Unexpected operands");
      }
      int num = (int) this.itsStackTop + ClassFileWriter.stackChange(theOpCode);
      if (num < 0 || (int) short.MaxValue < num)
        ClassFileWriter.badStack(num);
      this.addToCodeBuffer(theOpCode);
      this.itsStackTop = (short) num;
      if (num > (int) this.itsMaxStack)
        this.itsMaxStack = (short) num;
      if (theOpCode != 191)
        return;
      this.addSuperBlockStart(this.itsCodeBufferTop);
    }

    [LineNumberTable(new byte[] {167, 255, 104, 101, 131, 105, 105, 108, 134, 254, 69, 103, 104, 106, 167, 104, 105, 103, 98, 177, 168, 162, 176, 104, 105, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addInvoke(
      int theOpCode,
      string className,
      string methodName,
      string methodType)
    {
      int num1 = ClassFileWriter.sizeOfParameters(methodType);
      int num2 = (int) ((uint) num1 >> 16);
      int num3 = (int) this.itsStackTop + (int) (short) num1 + ClassFileWriter.stackChange(theOpCode);
      if (num3 < 0 || (int) short.MaxValue < num3)
        ClassFileWriter.badStack(num3);
      switch (theOpCode)
      {
        case 182:
        case 183:
        case 184:
        case 185:
          this.addToCodeBuffer(theOpCode);
          if (theOpCode == 185)
          {
            this.addToCodeInt16((int) this.itsConstantPool.addInterfaceMethodRef(className, methodName, methodType));
            this.addToCodeBuffer(num2 + 1);
            this.addToCodeBuffer(0);
          }
          else
            this.addToCodeInt16((int) this.itsConstantPool.addMethodRef(className, methodName, methodType));
          this.itsStackTop = (short) num3;
          if (num3 <= (int) this.itsMaxStack)
            break;
          this.itsMaxStack = (short) num3;
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("bad opcode for method reference");
      }
    }

    [LineNumberTable(new byte[] {167, 215, 110, 105, 143, 190, 100, 162, 100, 130, 176, 108, 102, 144, 103, 135, 104, 105, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int theOpCode, string className, string fieldName, string fieldType)
    {
      int num1 = (int) this.itsStackTop + ClassFileWriter.stackChange(theOpCode);
      int num2;
      switch (String.instancehelper_charAt(fieldType, 0))
      {
        case 'D':
        case 'J':
          num2 = 2;
          break;
        default:
          num2 = 1;
          break;
      }
      int num3 = num2;
      int num4;
      switch (theOpCode)
      {
        case 178:
        case 180:
          num4 = num1 + num3;
          break;
        case 179:
        case 181:
          num4 = num1 - num3;
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("bad opcode for field reference");
      }
      if (num4 < 0 || (int) short.MaxValue < num4)
        ClassFileWriter.badStack(num4);
      int num5 = (int) this.itsConstantPool.addFieldRef(className, fieldName, fieldType);
      this.addToCodeBuffer(theOpCode);
      this.addToCodeInt16(num5);
      this.itsStackTop = (short) num4;
      if (num4 <= (int) this.itsMaxStack)
        return;
      this.itsMaxStack = (short) num4;
    }

    [LineNumberTable(new byte[] {157, 251, 162, 104, 144, 134, 135, 98, 103, 102, 103, 166, 98, 200, 171, 98, 200, 177, 99, 99, 104, 101, 198, 255, 0, 77, 201, 144, 105, 99, 114, 109, 103, 109, 113, 113, 113, 150, 139, 108, 113, 112, 107, 111, 111, 111, 105, 101, 112, 101, 112, 101, 240, 69, 109, 109, 109, 237, 45, 237, 87, 172, 99, 104, 102, 104, 102, 101, 134, 141, 107, 107, 103, 109, 108, 109, 113, 109, 52, 232, 69, 107, 107, 103, 109, 109, 105, 109, 109, 108, 121, 102, 102, 102, 102, 139, 109, 109, 109, 109, 237, 52, 235, 80, 101, 107, 103, 109, 171, 141, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stopMethod(short maxLocals)
    {
      int num1 = (int) maxLocals;
      if (this.itsCurrentMethod == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("No method to stop");
      }
      this.fixLabelGotos();
      this.itsMaxLocals = (short) num1;
      ClassFileWriter.StackMapTable stackMapTable = (ClassFileWriter.StackMapTable) null;
      if (ClassFileWriter.GenerateStackMap)
      {
        this.finalizeSuperBlockStarts();
        stackMapTable = new ClassFileWriter.StackMapTable(this);
        stackMapTable.generate();
      }
      int num2 = 0;
      if (this.itsLineNumberTable != null)
        num2 = 8 + this.itsLineNumberTableTop * 4;
      int num3 = 0;
      if (this.itsVarDescriptors != null)
        num3 = 8 + this.itsVarDescriptors.size() * 10;
      int num4 = 0;
      if (stackMapTable != null)
      {
        int writeSize = stackMapTable.computeWriteSize();
        if (writeSize > 0)
          num4 = 6 + writeSize;
      }
      int length = 14 + this.itsCodeBufferTop + 2 + this.itsExceptionTableTop * 8 + 2 + num2 + num3 + num4;
      if (length > 65536)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ClassFileWriter.ClassFileFormatException("generated bytecode for method exceeds 64K limit.");
      }
      byte[] numArray1 = new byte[length];
      int num5 = 0;
      int num6 = ClassFileWriter.putInt16((int) this.itsConstantPool.addUtf8("Code"), numArray1, num5);
      int num7 = ClassFileWriter.putInt32(length - 6, numArray1, num6);
      int num8 = ClassFileWriter.putInt16((int) this.itsMaxStack, numArray1, num7);
      int num9 = ClassFileWriter.putInt16((int) this.itsMaxLocals, numArray1, num8);
      int num10 = ClassFileWriter.putInt32(this.itsCodeBufferTop, numArray1, num9);
      ByteCodeHelper.arraycopy_primitive_1((Array) this.itsCodeBuffer, 0, (Array) numArray1, num10, this.itsCodeBufferTop);
      int num11 = num10 + this.itsCodeBufferTop;
      int num12;
      if (this.itsExceptionTableTop > 0)
      {
        num12 = ClassFileWriter.putInt16(this.itsExceptionTableTop, numArray1, num11);
        for (int index = 0; index < this.itsExceptionTableTop; ++index)
        {
          ExceptionTableEntry exceptionTableEntry = this.itsExceptionTable[index];
          int labelPc1 = this.getLabelPC(exceptionTableEntry.itsStartLabel);
          int labelPc2 = this.getLabelPC(exceptionTableEntry.itsEndLabel);
          int labelPc3 = this.getLabelPC(exceptionTableEntry.itsHandlerLabel);
          int itsCatchType = (int) exceptionTableEntry.itsCatchType;
          if (labelPc1 == -1)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException("start label not defined");
          }
          if (labelPc2 == -1)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException("end label not defined");
          }
          if (labelPc3 == -1)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException("handler label not defined");
          }
          int num13 = ClassFileWriter.putInt16(labelPc1, numArray1, num12);
          int num14 = ClassFileWriter.putInt16(labelPc2, numArray1, num13);
          int num15 = ClassFileWriter.putInt16(labelPc3, numArray1, num14);
          num12 = ClassFileWriter.putInt16(itsCatchType, numArray1, num15);
        }
      }
      else
        num12 = ClassFileWriter.putInt16(0, numArray1, num11);
      int num16 = 0;
      if (this.itsLineNumberTable != null)
        ++num16;
      if (this.itsVarDescriptors != null)
        ++num16;
      if (num4 > 0)
        ++num16;
      int num17 = ClassFileWriter.putInt16(num16, numArray1, num12);
      if (this.itsLineNumberTable != null)
      {
        int num13 = ClassFileWriter.putInt16((int) this.itsConstantPool.addUtf8("LineNumberTable"), numArray1, num17);
        int num14 = ClassFileWriter.putInt32(2 + this.itsLineNumberTableTop * 4, numArray1, num13);
        num17 = ClassFileWriter.putInt16(this.itsLineNumberTableTop, numArray1, num14);
        for (int index = 0; index < this.itsLineNumberTableTop; ++index)
          num17 = ClassFileWriter.putInt32(this.itsLineNumberTable[index], numArray1, num17);
      }
      if (this.itsVarDescriptors != null)
      {
        int num13 = ClassFileWriter.putInt16((int) this.itsConstantPool.addUtf8("LocalVariableTable"), numArray1, num17);
        int num14 = this.itsVarDescriptors.size();
        int num15 = ClassFileWriter.putInt32(2 + num14 * 10, numArray1, num13);
        num17 = ClassFileWriter.putInt16(num14, numArray1, num15);
        for (int index = 0; index < num14; ++index)
        {
          int[] numArray2 = (int[]) this.itsVarDescriptors.get(index);
          int num18 = numArray2[0];
          int num19 = numArray2[1];
          int num20 = numArray2[2];
          int num21 = numArray2[3];
          int num22 = this.itsCodeBufferTop - num20;
          int num23 = ClassFileWriter.putInt16(num20, numArray1, num17);
          int num24 = ClassFileWriter.putInt16(num22, numArray1, num23);
          int num25 = ClassFileWriter.putInt16(num18, numArray1, num24);
          int num26 = ClassFileWriter.putInt16(num19, numArray1, num25);
          num17 = ClassFileWriter.putInt16(num21, numArray1, num26);
        }
      }
      if (num4 > 0)
      {
        int num13 = ClassFileWriter.putInt16((int) this.itsConstantPool.addUtf8("StackMapTable"), numArray1, num17);
        stackMapTable.write(numArray1, num13);
      }
      this.itsCurrentMethod.setCodeAttribute(numArray1);
      this.itsExceptionTable = (ExceptionTableEntry[]) null;
      this.itsExceptionTableTop = 0;
      this.itsLineNumberTableTop = 0;
      this.itsCodeBufferTop = 0;
      this.itsCurrentMethod = (ClassFileMethod) null;
      this.itsMaxStack = (short) 0;
      this.itsStackTop = (short) 0;
      this.itsLabelTableTop = 0;
      this.itsFixupTableTop = 0;
      this.itsVarDescriptors = (ObjArray) null;
      this.itsSuperBlockStarts = (int[]) null;
      this.itsSuperBlockStartsTop = 0;
      this.itsJumpFroms = (UintMap) null;
    }

    [LineNumberTable(new byte[] {167, 182, 110, 108, 102, 255, 11, 69, 109, 103, 135, 162, 176, 104, 105, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int theOpCode, string className)
    {
      int num1 = (int) this.itsStackTop + ClassFileWriter.stackChange(theOpCode);
      if (num1 < 0 || (int) short.MaxValue < num1)
        ClassFileWriter.badStack(num1);
      switch (theOpCode)
      {
        case 187:
        case 189:
        case 192:
        case 193:
          int num2 = (int) this.itsConstantPool.addClass(className);
          this.addToCodeBuffer(theOpCode);
          this.addToCodeInt16(num2);
          this.itsStackTop = (short) num1;
          if (num1 <= (int) this.itsMaxStack)
            break;
          this.itsMaxStack = (short) num1;
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("bad opcode for class reference");
      }
    }

    [LineNumberTable(new byte[] {168, 96, 101, 100, 105, 104, 140, 140, 101, 140, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPush(int k)
    {
      if ((int) (sbyte) k == k)
      {
        if (k == -1)
          this.add(2);
        else if (0 <= k && k <= 5)
          this.add((int) (sbyte) (3 + k));
        else
          this.add(16, (int) (sbyte) k);
      }
      else if ((int) (short) k == k)
        this.add(17, (int) (short) k);
      else
        this.addLoadConstant(k);
    }

    [LineNumberTable(new byte[] {166, 168, 110, 108, 134, 255, 161, 120, 69, 238, 83, 110, 108, 176, 103, 103, 142, 103, 100, 103, 109, 98, 232, 71, 100, 100, 103, 103, 109, 98, 106, 199, 165, 101, 112, 103, 104, 165, 101, 112, 103, 103, 165, 108, 112, 103, 103, 197, 108, 112, 103, 103, 229, 69, 108, 112, 178, 101, 138, 135, 140, 103, 135, 226, 77, 108, 112, 104, 107, 103, 137, 103, 135, 162, 208, 104, 105, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int theOpCode, int theOperand)
    {
      int num = (int) this.itsStackTop + ClassFileWriter.stackChange(theOpCode);
      if (num < 0 || (int) short.MaxValue < num)
        ClassFileWriter.badStack(num);
      switch (theOpCode)
      {
        case 16:
          if ((int) (sbyte) theOperand != theOperand)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("out of range byte");
          }
          this.addToCodeBuffer(theOpCode);
          this.addToCodeBuffer((int) (sbyte) theOperand);
          break;
        case 17:
          if ((int) (short) theOperand != theOperand)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("out of range short");
          }
          this.addToCodeBuffer(theOpCode);
          this.addToCodeInt16(theOperand);
          break;
        case 18:
        case 19:
        case 20:
          if (0 > theOperand || theOperand >= 65536)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ClassFileWriter.ClassFileFormatException("out of range index");
          }
          if (theOperand >= 256 || theOpCode == 19 || theOpCode == 20)
          {
            if (theOpCode == 18)
              this.addToCodeBuffer(19);
            else
              this.addToCodeBuffer(theOpCode);
            this.addToCodeInt16(theOperand);
            break;
          }
          this.addToCodeBuffer(theOpCode);
          this.addToCodeBuffer(theOperand);
          break;
        case 21:
        case 22:
        case 23:
        case 24:
        case 25:
        case 54:
        case 55:
        case 56:
        case 57:
        case 58:
        case 169:
          if (theOperand < 0 || 65536 <= theOperand)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ClassFileWriter.ClassFileFormatException("out of range variable");
          }
          if (theOperand >= 256)
          {
            this.addToCodeBuffer(196);
            this.addToCodeBuffer(theOpCode);
            this.addToCodeInt16(theOperand);
            break;
          }
          this.addToCodeBuffer(theOpCode);
          this.addToCodeBuffer(theOperand);
          break;
        case 153:
        case 154:
        case 155:
        case 156:
        case 157:
        case 158:
        case 159:
        case 160:
        case 161:
        case 162:
        case 163:
        case 164:
        case 165:
        case 166:
        case 168:
        case 198:
        case 199:
          if ((theOperand & int.MinValue) != int.MinValue && (theOperand < 0 || theOperand > (int) ushort.MaxValue))
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("Bad label for branch");
          }
          int itsCodeBufferTop = this.itsCodeBufferTop;
          this.addToCodeBuffer(theOpCode);
          if ((theOperand & int.MinValue) != int.MinValue)
          {
            this.addToCodeInt16(theOperand);
            int key = theOperand + itsCodeBufferTop;
            this.addSuperBlockStart(key);
            this.itsJumpFroms.put(key, itsCodeBufferTop);
            break;
          }
          int labelPc = this.getLabelPC(theOperand);
          if (labelPc != -1)
          {
            this.addToCodeInt16(labelPc - itsCodeBufferTop);
            this.addSuperBlockStart(labelPc);
            this.itsJumpFroms.put(labelPc, itsCodeBufferTop);
            break;
          }
          this.addLabelFixup(theOperand, itsCodeBufferTop + 1);
          this.addToCodeInt16(0);
          break;
        case 167:
          this.addSuperBlockStart(this.itsCodeBufferTop + 3);
          goto case 153;
        case 180:
        case 181:
          if (0 > theOperand || theOperand >= 65536)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("out of range field");
          }
          this.addToCodeBuffer(theOpCode);
          this.addToCodeInt16(theOperand);
          break;
        case 188:
          if (0 > theOperand || theOperand >= 256)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("out of range index");
          }
          this.addToCodeBuffer(theOpCode);
          this.addToCodeBuffer(theOperand);
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Unexpected opcode for 1 operand");
      }
      this.itsStackTop = (short) num;
      if (num <= (int) this.itsMaxStack)
        return;
      this.itsMaxStack = (short) num;
    }

    [LineNumberTable(new byte[] {167, 119, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLoadConstant(string k) => this.add(18, this.itsConstantPool.addConstant(k));

    [LineNumberTable(new byte[] {169, 129, 103, 111, 100, 103, 225, 72, 102, 112, 104, 103, 122, 130, 104, 105, 103, 154, 104, 100, 130, 98, 111, 98, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPush(string k)
    {
      int k1 = String.instancehelper_length(k);
      int utfEncodingLimit = this.itsConstantPool.getUtfEncodingLimit(k, 0, k1);
      if (utfEncodingLimit == k1)
      {
        this.addLoadConstant(k);
      }
      else
      {
        this.add(187, "java/lang/StringBuilder");
        this.add(89);
        this.addPush(k1);
        this.addInvoke(183, "java/lang/StringBuilder", "<init>", "(I)V");
        int num = 0;
        while (true)
        {
          this.add(89);
          this.addLoadConstant(String.instancehelper_substring(k, num, utfEncodingLimit));
          this.addInvoke(182, "java/lang/StringBuilder", "append", "(Ljava/lang/String;)Ljava/lang/StringBuilder;");
          this.add(87);
          if (utfEncodingLimit != k1)
          {
            num = utfEncodingLimit;
            utfEncodingLimit = this.itsConstantPool.getUtfEncodingLimit(k, utfEncodingLimit, k1);
          }
          else
            break;
        }
        this.addInvoke(182, "java/lang/StringBuilder", "toString", "()Ljava/lang/String;");
      }
    }

    [LineNumberTable(new byte[] {169, 92, 99, 101, 103, 141, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPush(long k)
    {
      int k1 = (int) k;
      if ((long) k1 == k)
      {
        this.addPush(k1);
        this.add(133);
      }
      else
        this.addLoadConstant(k);
    }

    [LineNumberTable(new byte[] {169, 249, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addALoad(int local) => this.xop(42, 25, local);

    [LineNumberTable(new byte[] {169, 217, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addILoad(int local) => this.xop(26, 21, local);

    [LineNumberTable(new byte[] {169, 225, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLLoad(int local) => this.xop(30, 22, local);

    [LineNumberTable(new byte[] {169, 233, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addFLoad(int local) => this.xop(34, 23, local);

    [LineNumberTable(new byte[] {169, 241, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addDLoad(int local) => this.xop(38, 24, local);

    [LineNumberTable(new byte[] {160, 243, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int putInt16([In] int obj0, [In] byte[] obj1, [In] int obj2)
    {
      obj1[obj2 + 0] = (byte) ((uint) obj0 >> 8);
      obj1[obj2 + 1] = (byte) obj0;
      return obj2 + 2;
    }

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ConstantPool access\u0024800([In] ClassFileWriter obj0) => obj0.itsConstantPool;

    [LineNumberTable(new byte[] {159, 48, 66, 255, 163, 169, 160, 152, 194, 226, 76, 232, 98, 162, 168, 226, 70, 226, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int opcodeLength([In] int obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      switch (obj0)
      {
        case 0:
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
        case 8:
        case 9:
        case 10:
        case 11:
        case 12:
        case 13:
        case 14:
        case 15:
        case 26:
        case 27:
        case 28:
        case 29:
        case 30:
        case 31:
        case 32:
        case 33:
        case 34:
        case 35:
        case 36:
        case 37:
        case 38:
        case 39:
        case 40:
        case 41:
        case 42:
        case 43:
        case 44:
        case 45:
        case 46:
        case 47:
        case 48:
        case 49:
        case 50:
        case 51:
        case 52:
        case 53:
        case 59:
        case 60:
        case 61:
        case 62:
        case 63:
        case 64:
        case 65:
        case 66:
        case 67:
        case 68:
        case 69:
        case 70:
        case 71:
        case 72:
        case 73:
        case 74:
        case 75:
        case 76:
        case 77:
        case 78:
        case 79:
        case 80:
        case 81:
        case 82:
        case 83:
        case 84:
        case 85:
        case 86:
        case 87:
        case 88:
        case 89:
        case 90:
        case 91:
        case 92:
        case 93:
        case 94:
        case 95:
        case 96:
        case 97:
        case 98:
        case 99:
        case 100:
        case 101:
        case 102:
        case 103:
        case 104:
        case 105:
        case 106:
        case 107:
        case 108:
        case 109:
        case 110:
        case 111:
        case 112:
        case 113:
        case 114:
        case 115:
        case 116:
        case 117:
        case 118:
        case 119:
        case 120:
        case 121:
        case 122:
        case 123:
        case 124:
        case 125:
        case 126:
        case (int) sbyte.MaxValue:
        case 128:
        case 129:
        case 130:
        case 131:
        case 133:
        case 134:
        case 135:
        case 136:
        case 137:
        case 138:
        case 139:
        case 140:
        case 141:
        case 142:
        case 143:
        case 144:
        case 145:
        case 146:
        case 147:
        case 148:
        case 149:
        case 150:
        case 151:
        case 152:
        case 172:
        case 173:
        case 174:
        case 175:
        case 176:
        case 177:
        case 190:
        case 191:
        case 194:
        case 195:
        case 196:
        case 202:
        case 254:
        case (int) byte.MaxValue:
          return 1;
        case 16:
        case 18:
        case 188:
          return 2;
        case 17:
        case 19:
        case 20:
        case 153:
        case 154:
        case 155:
        case 156:
        case 157:
        case 158:
        case 159:
        case 160:
        case 161:
        case 162:
        case 163:
        case 164:
        case 165:
        case 166:
        case 167:
        case 168:
        case 178:
        case 179:
        case 180:
        case 181:
        case 182:
        case 183:
        case 184:
        case 187:
        case 189:
        case 192:
        case 193:
        case 198:
        case 199:
          return 3;
        case 21:
        case 22:
        case 23:
        case 24:
        case 25:
        case 54:
        case 55:
        case 56:
        case 57:
        case 58:
        case 169:
          return num != 0 ? 3 : 2;
        case 132:
          return num != 0 ? 5 : 3;
        case 185:
        case 186:
        case 200:
        case 201:
          return 5;
        case 197:
          return 4;
        default:
          string str = new StringBuilder().append("Bad opcode: ").append(obj0).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 96, 255, 90, 75, 130, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string descriptorToInternalName([In] string obj0)
    {
      switch (String.instancehelper_charAt(obj0, 0))
      {
        case 'B':
        case 'C':
        case 'D':
        case 'F':
        case 'I':
        case 'J':
        case 'S':
        case 'V':
        case 'Z':
        case '[':
          return obj0;
        case 'L':
          return ClassFileWriter.classDescriptorToInternalName(obj0);
        default:
          string str = new StringBuilder().append("bad descriptor:").append(obj0).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 140, 103, 105, 105, 156, 98, 98, 99, 131, 103, 159, 90, 98, 165, 230, 72, 102, 102, 100, 133, 100, 105, 102, 100, 139, 159, 81, 98, 229, 73, 102, 102, 100, 229, 70, 102, 102, 100, 107, 140, 98, 130, 101, 197, 102, 159, 92, 98, 162, 230, 74, 230, 69, 99, 207})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int sizeOfParameters([In] string obj0)
    {
      int num1 = String.instancehelper_length(obj0);
      int num2 = String.instancehelper_lastIndexOf(obj0, 41);
      if (3 <= num1 && String.instancehelper_charAt(obj0, 0) == '(' && (1 <= num2 && num2 + 1 < num1))
      {
        int num3 = 1;
        int num4 = 1;
        int num5 = 0;
        int num6 = 0;
        while (num4 != num2)
        {
          switch (String.instancehelper_charAt(obj0, num4))
          {
            case 'B':
            case 'C':
            case 'F':
            case 'I':
            case 'S':
            case 'Z':
              num5 += -1;
              ++num6;
              ++num4;
              continue;
            case 'D':
            case 'J':
              num5 += -1;
              goto case 'B';
            case 'L':
label_12:
              num5 += -1;
              ++num6;
              int num7 = num4 + 1;
              int num8 = String.instancehelper_indexOf(obj0, 59, num7);
              if (num7 + 1 > num8 || num8 >= num2)
              {
                num3 = 0;
                goto label_15;
              }
              else
              {
                num4 = num8 + 1;
                continue;
              }
            case '[':
              ++num4;
              int num9 = (int) String.instancehelper_charAt(obj0, num4);
              while (true)
              {
                switch (num9)
                {
                  case 66:
                  case 67:
                  case 68:
                  case 70:
                  case 73:
                  case 74:
                  case 83:
                  case 90:
                    goto label_11;
                  case 76:
                    goto label_12;
                  case 91:
                    ++num4;
                    num9 = (int) String.instancehelper_charAt(obj0, num4);
                    continue;
                  default:
                    goto label_10;
                }
              }
label_10:
              num3 = 0;
              goto label_15;
label_11:
              num5 += -1;
              ++num6;
              ++num4;
              continue;
            default:
              num3 = 0;
              goto label_15;
          }
        }
label_15:
        if (num3 != 0)
        {
          switch (String.instancehelper_charAt(obj0, num2 + 1))
          {
            case 'B':
            case 'C':
            case 'F':
            case 'I':
            case 'L':
            case 'S':
            case 'Z':
            case '[':
              ++num5;
              goto case 'V';
            case 'D':
            case 'J':
              ++num5;
              goto case 'B';
            case 'V':
              if (num3 != 0)
                return num6 << 16 | (int) ushort.MaxValue & num5;
              break;
            default:
              num3 = 0;
              goto case 'V';
          }
        }
      }
      string str = new StringBuilder().append("Bad parameter signature: ").append(obj0).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {124, 159, 11, 131, 131, 131, 131, 131, 131, 131, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static char arrayTypeToName([In] int obj0)
    {
      switch (obj0)
      {
        case 4:
          return 'Z';
        case 5:
          return 'C';
        case 6:
          return 'F';
        case 7:
          return 'D';
        case 8:
          return 'B';
        case 9:
          return 'S';
        case 10:
          return 'I';
        case 11:
          return 'J';
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("bad operand");
      }
    }

    [LineNumberTable(new byte[] {171, 70, 108, 226, 69, 111, 119, 138, 242, 69, 108, 105, 106, 104, 144, 101, 103, 105, 255, 94, 73, 112, 102, 130, 110, 108, 106, 100, 130, 106, 102, 133, 98, 108, 111, 105, 105, 132, 104, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int[] createInitialLocals()
    {
      int[] numArray1 = new int[(int) this.itsMaxLocals];
      int num1 = 0;
      if (((int) this.itsCurrentMethod.getFlags() & 8) == 0)
      {
        if (String.instancehelper_equals("<init>", (object) this.itsCurrentMethod.getName()))
        {
          int[] numArray2 = numArray1;
          int index = num1;
          ++num1;
          numArray2[index] = 6;
        }
        else
        {
          int[] numArray2 = numArray1;
          int index = num1;
          ++num1;
          int num2 = TypeInfo.OBJECT((int) this.itsThisClassIndex);
          numArray2[index] = num2;
        }
      }
      string type = this.itsCurrentMethod.getType();
      int num3 = String.instancehelper_indexOf(type, 40);
      int num4 = String.instancehelper_indexOf(type, 41);
      if (num3 != 0 || num4 < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("bad method type");
      }
      int num5 = num3 + 1;
      StringBuilder stringBuilder = new StringBuilder();
      while (num5 < num4)
      {
        switch (String.instancehelper_charAt(type, num5))
        {
          case 'B':
          case 'C':
          case 'D':
          case 'F':
          case 'I':
          case 'J':
          case 'S':
          case 'Z':
            stringBuilder.append(String.instancehelper_charAt(type, num5));
            ++num5;
            break;
          case 'L':
            int num2 = String.instancehelper_indexOf(type, 59, num5) + 1;
            string str = String.instancehelper_substring(type, num5, num2);
            stringBuilder.append(str);
            num5 = num2;
            break;
          case '[':
            stringBuilder.append('[');
            ++num5;
            continue;
        }
        int num6 = TypeInfo.fromType(ClassFileWriter.descriptorToInternalName(stringBuilder.toString()), this.itsConstantPool);
        int[] numArray2 = numArray1;
        int index = num1;
        ++num1;
        int num7 = num6;
        numArray2[index] = num7;
        if (TypeInfo.isTwoWords(num6))
          ++num1;
        stringBuilder.setLength(0);
      }
      return numArray1;
    }

    [LineNumberTable(202)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string classDescriptorToInternalName([In] string obj0) => String.instancehelper_substring(obj0, 1, String.instancehelper_length(obj0) - 1);

    [LineNumberTable(new byte[] {160, 249, 106, 106, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int putInt32([In] int obj0, [In] byte[] obj1, [In] int obj2)
    {
      obj1[obj2 + 0] = (byte) ((uint) obj0 >> 24);
      obj1[obj2 + 1] = (byte) ((uint) obj0 >> 16);
      obj1[obj2 + 2] = (byte) ((uint) obj0 >> 8);
      obj1[obj2 + 3] = (byte) obj0;
      return obj2 + 4;
    }

    [LineNumberTable(new byte[] {172, 15, 106, 104, 110, 111, 110, 148, 135, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addSuperBlockStart([In] int obj0)
    {
      if (!ClassFileWriter.GenerateStackMap)
        return;
      if (this.itsSuperBlockStarts == null)
        this.itsSuperBlockStarts = new int[4];
      else if (this.itsSuperBlockStarts.Length == this.itsSuperBlockStartsTop)
      {
        int[] numArray = new int[this.itsSuperBlockStartsTop * 2];
        ByteCodeHelper.arraycopy_primitive_4((Array) this.itsSuperBlockStarts, 0, (Array) numArray, 0, this.itsSuperBlockStartsTop);
        this.itsSuperBlockStarts = numArray;
      }
      int[] superBlockStarts = this.itsSuperBlockStarts;
      ClassFileWriter classFileWriter1 = this;
      int superBlockStartsTop = classFileWriter1.itsSuperBlockStartsTop;
      ClassFileWriter classFileWriter2 = classFileWriter1;
      int index = superBlockStartsTop;
      classFileWriter2.itsSuperBlockStartsTop = superBlockStartsTop + 1;
      int num = obj0;
      superBlockStarts[index] = num;
    }

    [LineNumberTable(new byte[] {170, 189, 103, 110, 105, 102, 100, 106, 133, 176, 104, 113, 105, 103, 144, 105, 233, 47, 233, 83, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void fixLabelGotos()
    {
      byte[] itsCodeBuffer = this.itsCodeBuffer;
      for (int index1 = 0; index1 < this.itsFixupTableTop; ++index1)
      {
        long num1 = this.itsFixupTable[index1];
        int index2 = (int) (num1 >> 32);
        int index3 = (int) num1;
        int key = this.itsLabelTable[index2];
        if (key == -1)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("unlocated label");
        }
        this.addSuperBlockStart(key);
        this.itsJumpFroms.put(key, index3 - 1);
        int num2 = key - (index3 - 1);
        if ((int) (short) num2 != num2)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ClassFileWriter.ClassFileFormatException("Program too complex: too big jump offset");
        }
        itsCodeBuffer[index3] = (byte) (num2 >> 8);
        itsCodeBuffer[index3 + 1] = (byte) num2;
      }
      this.itsFixupTableTop = 0;
    }

    [LineNumberTable(new byte[] {172, 35, 106, 107, 105, 109, 231, 61, 230, 69, 114, 105, 98, 107, 106, 101, 100, 138, 100, 227, 57, 230, 74, 103, 114, 174})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void finalizeSuperBlockStarts()
    {
      if (!ClassFileWriter.GenerateStackMap)
        return;
      for (int index = 0; index < this.itsExceptionTableTop; ++index)
        this.addSuperBlockStart(this.getLabelPC(this.itsExceptionTable[index].itsHandlerLabel));
      Arrays.sort(this.itsSuperBlockStarts, 0, this.itsSuperBlockStartsTop);
      int num = this.itsSuperBlockStarts[0];
      int index1 = 1;
      for (int index2 = 1; index2 < this.itsSuperBlockStartsTop; ++index2)
      {
        int itsSuperBlockStart = this.itsSuperBlockStarts[index2];
        if (num != itsSuperBlockStart)
        {
          if (index1 != index2)
            this.itsSuperBlockStarts[index1] = itsSuperBlockStart;
          ++index1;
          num = itsSuperBlockStart;
        }
      }
      this.itsSuperBlockStartsTop = index1;
      if (this.itsSuperBlockStarts[index1 - 1] != this.itsCodeBufferTop)
        return;
      --this.itsSuperBlockStartsTop;
    }

    [LineNumberTable(new byte[] {170, 160, 100, 112, 105, 105, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLabelPC(int label)
    {
      if (label >= 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Bad label, no biscuit");
      }
      label &= int.MaxValue;
      if (label >= this.itsLabelTableTop)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Bad label");
      }
      return this.itsLabelTable[label];
    }

    [LineNumberTable(new byte[] {161, 235, 255, 163, 169, 160, 152, 226, 114, 194, 194, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int opcodeCount([In] int obj0)
    {
      switch (obj0)
      {
        case 0:
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
        case 8:
        case 9:
        case 10:
        case 11:
        case 12:
        case 13:
        case 14:
        case 15:
        case 26:
        case 27:
        case 28:
        case 29:
        case 30:
        case 31:
        case 32:
        case 33:
        case 34:
        case 35:
        case 36:
        case 37:
        case 38:
        case 39:
        case 40:
        case 41:
        case 42:
        case 43:
        case 44:
        case 45:
        case 46:
        case 47:
        case 48:
        case 49:
        case 50:
        case 51:
        case 52:
        case 53:
        case 59:
        case 60:
        case 61:
        case 62:
        case 63:
        case 64:
        case 65:
        case 66:
        case 67:
        case 68:
        case 69:
        case 70:
        case 71:
        case 72:
        case 73:
        case 74:
        case 75:
        case 76:
        case 77:
        case 78:
        case 79:
        case 80:
        case 81:
        case 82:
        case 83:
        case 84:
        case 85:
        case 86:
        case 87:
        case 88:
        case 89:
        case 90:
        case 91:
        case 92:
        case 93:
        case 94:
        case 95:
        case 96:
        case 97:
        case 98:
        case 99:
        case 100:
        case 101:
        case 102:
        case 103:
        case 104:
        case 105:
        case 106:
        case 107:
        case 108:
        case 109:
        case 110:
        case 111:
        case 112:
        case 113:
        case 114:
        case 115:
        case 116:
        case 117:
        case 118:
        case 119:
        case 120:
        case 121:
        case 122:
        case 123:
        case 124:
        case 125:
        case 126:
        case (int) sbyte.MaxValue:
        case 128:
        case 129:
        case 130:
        case 131:
        case 133:
        case 134:
        case 135:
        case 136:
        case 137:
        case 138:
        case 139:
        case 140:
        case 141:
        case 142:
        case 143:
        case 144:
        case 145:
        case 146:
        case 147:
        case 148:
        case 149:
        case 150:
        case 151:
        case 152:
        case 172:
        case 173:
        case 174:
        case 175:
        case 176:
        case 177:
        case 190:
        case 191:
        case 194:
        case 195:
        case 196:
        case 202:
        case 254:
        case (int) byte.MaxValue:
          return 0;
        case 16:
        case 17:
        case 18:
        case 19:
        case 20:
        case 21:
        case 22:
        case 23:
        case 24:
        case 25:
        case 54:
        case 55:
        case 56:
        case 57:
        case 58:
        case 153:
        case 154:
        case 155:
        case 156:
        case 157:
        case 158:
        case 159:
        case 160:
        case 161:
        case 162:
        case 163:
        case 164:
        case 165:
        case 166:
        case 167:
        case 168:
        case 169:
        case 178:
        case 179:
        case 180:
        case 181:
        case 182:
        case 183:
        case 184:
        case 185:
        case 187:
        case 188:
        case 189:
        case 192:
        case 193:
        case 198:
        case 199:
        case 200:
        case 201:
          return 1;
        case 132:
        case 197:
          return 2;
        case 170:
        case 171:
          return -1;
        default:
          string str = new StringBuilder().append("Bad opcode: ").append(obj0).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {162, 200, 191, 163, 169, 227, 75, 227, 100, 227, 160, 70, 226, 99, 226, 107, 226, 84, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int stackChange([In] int obj0)
    {
      switch (obj0)
      {
        case 0:
        case 47:
        case 49:
        case 95:
        case 116:
        case 117:
        case 118:
        case 119:
        case 132:
        case 134:
        case 138:
        case 139:
        case 143:
        case 145:
        case 146:
        case 147:
        case 167:
        case 169:
        case 177:
        case 178:
        case 179:
        case 184:
        case 186:
        case 188:
        case 189:
        case 190:
        case 192:
        case 193:
        case 196:
        case 200:
        case 202:
        case 254:
        case (int) byte.MaxValue:
          return 0;
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
        case 8:
        case 11:
        case 12:
        case 13:
        case 16:
        case 17:
        case 18:
        case 19:
        case 21:
        case 23:
        case 25:
        case 26:
        case 27:
        case 28:
        case 29:
        case 34:
        case 35:
        case 36:
        case 37:
        case 42:
        case 43:
        case 44:
        case 45:
        case 89:
        case 90:
        case 91:
        case 133:
        case 135:
        case 140:
        case 141:
        case 168:
        case 187:
        case 197:
        case 201:
          return 1;
        case 9:
        case 10:
        case 14:
        case 15:
        case 20:
        case 22:
        case 24:
        case 30:
        case 31:
        case 32:
        case 33:
        case 38:
        case 39:
        case 40:
        case 41:
        case 92:
        case 93:
        case 94:
          return 2;
        case 46:
        case 48:
        case 50:
        case 51:
        case 52:
        case 53:
        case 54:
        case 56:
        case 58:
        case 59:
        case 60:
        case 61:
        case 62:
        case 67:
        case 68:
        case 69:
        case 70:
        case 75:
        case 76:
        case 77:
        case 78:
        case 87:
        case 96:
        case 98:
        case 100:
        case 102:
        case 104:
        case 106:
        case 108:
        case 110:
        case 112:
        case 114:
        case 120:
        case 121:
        case 122:
        case 123:
        case 124:
        case 125:
        case 126:
        case 128:
        case 130:
        case 136:
        case 137:
        case 142:
        case 144:
        case 149:
        case 150:
        case 153:
        case 154:
        case 155:
        case 156:
        case 157:
        case 158:
        case 170:
        case 171:
        case 172:
        case 174:
        case 176:
        case 180:
        case 181:
        case 182:
        case 183:
        case 185:
        case 191:
        case 194:
        case 195:
        case 198:
        case 199:
          return -1;
        case 55:
        case 57:
        case 63:
        case 64:
        case 65:
        case 66:
        case 71:
        case 72:
        case 73:
        case 74:
        case 88:
        case 97:
        case 99:
        case 101:
        case 103:
        case 105:
        case 107:
        case 109:
        case 111:
        case 113:
        case 115:
        case (int) sbyte.MaxValue:
        case 129:
        case 131:
        case 159:
        case 160:
        case 161:
        case 162:
        case 163:
        case 164:
        case 165:
        case 166:
        case 173:
        case 175:
          return -2;
        case 79:
        case 81:
        case 83:
        case 84:
        case 85:
        case 86:
        case 148:
        case 151:
        case 152:
          return -3;
        case 80:
        case 82:
          return -4;
        default:
          string str = new StringBuilder().append("Bad opcode: ").append(obj0).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 123, 100, 157, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void badStack([In] int obj0)
    {
      string str = obj0 >= 0 ? new StringBuilder().append("Too big stack: ").append(obj0).toString() : new StringBuilder().append("Stack underflow: ").append(obj0).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException(str);
    }

    [LineNumberTable(new byte[] {170, 242, 104, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addToCodeBuffer([In] int obj0) => this.itsCodeBuffer[this.addReservedCodeSpace(1)] = (byte) obj0;

    [LineNumberTable(new byte[] {170, 247, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addToCodeInt16([In] int obj0)
    {
      int num = this.addReservedCodeSpace(2);
      ClassFileWriter.putInt16(obj0, this.itsCodeBuffer, num);
    }

    [LineNumberTable(new byte[] {170, 169, 100, 112, 105, 105, 112, 103, 114, 104, 143, 111, 111, 167, 105, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addLabelFixup([In] int obj0, [In] int obj1)
    {
      if (obj0 >= 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Bad label, no biscuit");
      }
      obj0 &= int.MaxValue;
      if (obj0 >= this.itsLabelTableTop)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Bad label");
      }
      int itsFixupTableTop = this.itsFixupTableTop;
      if (this.itsFixupTable == null || itsFixupTableTop == this.itsFixupTable.Length)
      {
        if (this.itsFixupTable == null)
        {
          this.itsFixupTable = new long[40];
        }
        else
        {
          long[] numArray = new long[this.itsFixupTable.Length * 2];
          ByteCodeHelper.arraycopy_primitive_8((Array) this.itsFixupTable, 0, (Array) numArray, 0, itsFixupTableTop);
          this.itsFixupTable = numArray;
        }
      }
      this.itsFixupTableTop = itsFixupTableTop + 1;
      this.itsFixupTable[itsFixupTableTop] = (long) obj0 << 32 | (long) obj1;
    }

    [LineNumberTable(new byte[] {167, 65, 159, 1, 103, 130, 103, 130, 103, 130, 103, 130, 103, 130, 103, 130, 180})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLoadConstant(int k)
    {
      switch (k)
      {
        case 0:
          this.add(3);
          break;
        case 1:
          this.add(4);
          break;
        case 2:
          this.add(5);
          break;
        case 3:
          this.add(6);
          break;
        case 4:
          this.add(7);
          break;
        case 5:
          this.add(8);
          break;
        default:
          this.add(18, this.itsConstantPool.addConstant(k));
          break;
      }
    }

    [LineNumberTable(new byte[] {167, 95, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLoadConstant(long k) => this.add(20, this.itsConstantPool.addConstant(k));

    [LineNumberTable(new byte[] {167, 111, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLoadConstant(double k) => this.add(20, this.itsConstantPool.addConstant(k));

    [LineNumberTable(new byte[] {170, 4, 152, 103, 130, 105, 130, 105, 130, 105, 130, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void xop([In] int obj0, [In] int obj1, [In] int obj2)
    {
      switch (obj2)
      {
        case 0:
          this.add(obj0);
          break;
        case 1:
          this.add(obj0 + 1);
          break;
        case 2:
          this.add(obj0 + 2);
          break;
        case 3:
          this.add(obj0 + 3);
          break;
        default:
          this.add(obj1, obj2);
          break;
      }
    }

    [LineNumberTable(new byte[] {170, 252, 104, 112, 103, 100, 106, 106, 100, 130, 103, 111, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int addReservedCodeSpace([In] int obj0)
    {
      if (this.itsCurrentMethod == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("No method to add to");
      }
      int itsCodeBufferTop = this.itsCodeBufferTop;
      int num = itsCodeBufferTop + obj0;
      if (num > this.itsCodeBuffer.Length)
      {
        int length = this.itsCodeBuffer.Length * 2;
        if (num > length)
          length = num;
        byte[] numArray = new byte[length];
        ByteCodeHelper.arraycopy_primitive_1((Array) this.itsCodeBuffer, 0, (Array) numArray, 0, itsCodeBufferTop);
        this.itsCodeBuffer = numArray;
      }
      this.itsCodeBufferTop = num;
      return itsCodeBufferTop;
    }

    [LineNumberTable(new byte[] {170, 87, 109, 127, 6, 100, 159, 6, 134, 132, 136, 140, 116, 223, 6, 117, 191, 6, 175, 191, 6, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTableSwitchJump(int switchStart, int caseIndex, int jumpTarget)
    {
      if (jumpTarget < 0 || this.itsCodeBufferTop < jumpTarget)
      {
        string str = new StringBuilder().append("Bad jump target: ").append(jumpTarget).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (caseIndex < -1)
      {
        string str = new StringBuilder().append("Bad case index: ").append(caseIndex).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      int num1 = 3 & (switchStart ^ -1);
      int num2 = caseIndex >= 0 ? switchStart + 1 + num1 + 4 * (3 + caseIndex) : switchStart + 1 + num1;
      if (switchStart < 0 || this.itsCodeBufferTop - 16 - num1 - 1 < switchStart)
      {
        string str = new StringBuilder().append(switchStart).append(" is outside a possible range of tableswitch in already generated code").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (((int) byte.MaxValue & (int) (sbyte) this.itsCodeBuffer[switchStart]) != 170)
      {
        string str = new StringBuilder().append(switchStart).append(" is not offset of tableswitch statement").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (num2 < 0 || this.itsCodeBufferTop < num2 + 4)
      {
        string str = new StringBuilder().append("Too big case index: ").append(caseIndex).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ClassFileWriter.ClassFileFormatException(str);
      }
      ClassFileWriter.putInt32(jumpTarget - switchStart, this.itsCodeBuffer, num2);
    }

    [LineNumberTable(new byte[] {170, 135, 100, 144, 105, 105, 144, 107, 176, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void markLabel(int label)
    {
      if (label >= 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Bad label, no biscuit");
      }
      label &= int.MaxValue;
      if (label > this.itsLabelTableTop)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Bad label");
      }
      if (this.itsLabelTable[label] != -1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Can only mark label once");
      }
      this.itsLabelTable[label] = this.itsCodeBufferTop;
    }

    [LineNumberTable(new byte[] {171, 141, 130, 104, 177, 100, 110, 100, 100, 100, 100, 144, 100, 112, 62, 198, 100, 112, 62, 198, 100, 104, 100, 100, 132, 104, 100, 100, 100, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getWriteSize()
    {
      int num1 = 0;
      if (this.itsSourceFileNameIndex != (short) 0)
      {
        int num2 = (int) this.itsConstantPool.addUtf8("SourceFile");
      }
      int num3 = num1 + 8 + this.itsConstantPool.getWriteSize() + 2 + 2 + 2 + 2 + 2 * this.itsInterfaces.size() + 2;
      for (int index = 0; index < this.itsFields.size(); ++index)
        num3 += ((ClassFileField) this.itsFields.get(index)).getWriteSize();
      int num4 = num3 + 2;
      for (int index = 0; index < this.itsMethods.size(); ++index)
        num4 += ((ClassFileMethod) this.itsMethods.get(index)).getWriteSize();
      int num5 = num4 + 2;
      if (this.itsSourceFileNameIndex != (short) 0)
        num5 = num5 + 2 + 4 + 2;
      if (this.itsBootstrapMethods != null)
        num5 = num5 + 2 + 4 + 2 + this.itsBootstrapMethodsLength;
      return num5;
    }

    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getSlashedForm([In] string obj0) => String.instancehelper_replace(obj0, '.', '/');

    [LineNumberTable(new byte[] {106, 103, 100, 105, 101, 101, 106, 102, 103, 5, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string classNameToSignature(string name)
    {
      int num = String.instancehelper_length(name);
      int index1 = 1 + num;
      char[] chArray = new char[index1 + 1];
      chArray[0] = 'L';
      chArray[index1] = ';';
      String.instancehelper_getChars(name, 0, num, chArray, 1);
      for (int index2 = 1; index2 != index1; ++index2)
      {
        if (chArray[index2] == '.')
          chArray[index2] = '/';
      }
      return String.newhelper(chArray, 0, index1 + 1);
    }

    [LineNumberTable(new byte[] {160, 117, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int putInt64([In] long obj0, [In] byte[] obj1, [In] int obj2)
    {
      obj2 = ClassFileWriter.putInt32((int) ((ulong) obj0 >> 32), obj1, obj2);
      return ClassFileWriter.putInt32((int) obj0, obj1, obj2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string bytecodeStr([In] int obj0) => "";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public string getClassName() => this.generatedClassName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFlags(short flags) => this.itsFlags = flags;

    [LineNumberTable(new byte[] {158, 19, 98, 109, 109, 137, 187, 229, 61, 197, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addField(string fieldName, string type, short flags, int value)
    {
      int num = (int) flags;
      ClassFileField classFileField = new ClassFileField(this.itsConstantPool.addUtf8(fieldName), this.itsConstantPool.addUtf8(type), (short) num);
      classFileField.setAttributes(this.itsConstantPool.addUtf8("ConstantValue"), (short) 0, (short) 0, this.itsConstantPool.addConstant(value));
      this.itsFields.add((object) classFileField);
    }

    [LineNumberTable(new byte[] {158, 14, 98, 109, 109, 137, 187, 229, 61, 197, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addField(string fieldName, string type, short flags, long value)
    {
      int num = (int) flags;
      ClassFileField classFileField = new ClassFileField(this.itsConstantPool.addUtf8(fieldName), this.itsConstantPool.addUtf8(type), (short) num);
      classFileField.setAttributes(this.itsConstantPool.addUtf8("ConstantValue"), (short) 0, (short) 2, this.itsConstantPool.addConstant(value));
      this.itsFields.add((object) classFileField);
    }

    [LineNumberTable(new byte[] {158, 9, 98, 109, 109, 137, 188, 229, 61, 197, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addField(string fieldName, string type, short flags, double value)
    {
      int num = (int) flags;
      ClassFileField classFileField = new ClassFileField(this.itsConstantPool.addUtf8(fieldName), this.itsConstantPool.addUtf8(type), (short) num);
      classFileField.setAttributes(this.itsConstantPool.addUtf8("ConstantValue"), (short) 0, (short) 2, this.itsConstantPool.addConstant(value));
      this.itsFields.add((object) classFileField);
    }

    [LineNumberTable(new byte[] {165, 184, 109, 109, 120, 104, 139, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addVariableDescriptor(string name, string type, int startPC, int register)
    {
      int[] numArray = new int[4]
      {
        (int) this.itsConstantPool.addUtf8(name),
        (int) this.itsConstantPool.addUtf8(type),
        startPC,
        register
      };
      if (this.itsVarDescriptors == null)
        this.itsVarDescriptors = new ObjArray();
      this.itsVarDescriptors.add((object) numArray);
    }

    [LineNumberTable(new byte[] {167, 103, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLoadConstant(float k) => this.add(18, this.itsConstantPool.addConstant(k));

    [LineNumberTable(new byte[] {167, 134, 110, 108, 134, 107, 108, 112, 108, 144, 109, 107, 107, 103, 140, 107, 103, 140, 104, 108, 112, 108, 144, 107, 103, 137, 176, 104, 105, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int theOpCode, int theOperand1, int theOperand2)
    {
      int num = (int) this.itsStackTop + ClassFileWriter.stackChange(theOpCode);
      if (num < 0 || (int) short.MaxValue < num)
        ClassFileWriter.badStack(num);
      switch (theOpCode)
      {
        case 132:
          if (theOperand1 < 0 || 65536 <= theOperand1)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ClassFileWriter.ClassFileFormatException("out of range variable");
          }
          if (theOperand2 < 0 || 65536 <= theOperand2)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ClassFileWriter.ClassFileFormatException("out of range increment");
          }
          if (theOperand1 > (int) byte.MaxValue || theOperand2 > (int) sbyte.MaxValue)
          {
            this.addToCodeBuffer(196);
            this.addToCodeBuffer(132);
            this.addToCodeInt16(theOperand1);
            this.addToCodeInt16(theOperand2);
            break;
          }
          this.addToCodeBuffer(132);
          this.addToCodeBuffer(theOperand1);
          this.addToCodeBuffer(theOperand2);
          break;
        case 197:
          if (0 > theOperand1 || theOperand1 >= 65536)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("out of range index");
          }
          if (0 > theOperand2 || theOperand2 >= 256)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("out of range dimensions");
          }
          this.addToCodeBuffer(197);
          this.addToCodeInt16(theOperand1);
          this.addToCodeBuffer(theOperand2);
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Unexpected opcode for 2 operands");
      }
      this.itsStackTop = (short) num;
      if (num <= (int) this.itsMaxStack)
        return;
      this.itsMaxStack = (short) num;
    }

    [LineNumberTable(new byte[] {168, 50, 105, 208, 135, 131, 105, 108, 134, 138, 104, 139, 110, 101, 109, 108, 180, 177, 107, 104, 135, 104, 105, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addInvokeDynamic(
      string methodName,
      string methodType,
      ClassFileWriter.MHandle bsm,
      params object[] bsmArgs)
    {
      if (ClassFileWriter.MajorVersion < 51)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Please build and run with JDK 1.7 for invokedynamic support");
      }
      int num1 = (int) this.itsStackTop + (int) (short) ClassFileWriter.sizeOfParameters(methodType);
      if (num1 < 0 || (int) short.MaxValue < num1)
        ClassFileWriter.badStack(num1);
      ClassFileWriter.BootstrapEntry bootstrapEntry = new ClassFileWriter.BootstrapEntry(this, bsm, bsmArgs);
      if (this.itsBootstrapMethods == null)
        this.itsBootstrapMethods = new ObjArray();
      int num2 = this.itsBootstrapMethods.indexOf((object) bootstrapEntry);
      if (num2 == -1)
      {
        num2 = this.itsBootstrapMethods.size();
        this.itsBootstrapMethods.add((object) bootstrapEntry);
        this.itsBootstrapMethodsLength += bootstrapEntry.code.Length;
      }
      int num3 = (int) this.itsConstantPool.addInvokeDynamic(methodName, methodType, num2);
      this.addToCodeBuffer(186);
      this.addToCodeInt16(num3);
      this.addToCodeInt16(0);
      this.itsStackTop = (short) num1;
      if (num1 <= (int) this.itsMaxStack)
        return;
      this.itsMaxStack = (short) num1;
    }

    [LineNumberTable(new byte[] {157, 29, 130, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPush(bool k) => this.add(!k ? 3 : 4);

    [LineNumberTable(new byte[] {169, 106, 137, 104, 144, 138, 118, 104, 105, 170, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addPush(double k)
    {
      if (k == 0.0)
      {
        this.add(14);
        if (1.0 / k >= 0.0)
          return;
        this.add(119);
      }
      else if (k == 1.0 || k == -1.0)
      {
        this.add(15);
        if (k >= 0.0)
          return;
        this.add(119);
      }
      else
        this.addLoadConstant(k);
    }

    [LineNumberTable(2587)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUnderStringSizeLimit(string k) => this.itsConstantPool.isUnderUtfEncodingLimit(k);

    [LineNumberTable(new byte[] {169, 177, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addIStore(int local) => this.xop(59, 54, local);

    [LineNumberTable(new byte[] {169, 185, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLStore(int local) => this.xop(63, 55, local);

    [LineNumberTable(new byte[] {169, 193, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addFStore(int local) => this.xop(67, 56, local);

    [LineNumberTable(new byte[] {169, 201, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addDStore(int local) => this.xop(71, 57, local);

    [LineNumberTable(new byte[] {169, 209, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAStore(int local) => this.xop(75, 58, local);

    [LineNumberTable(new byte[] {170, 0, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLoadThis() => this.add(42);

    [LineNumberTable(new byte[] {170, 27, 100, 159, 19, 114, 108, 134, 102, 139, 112, 99, 110, 99, 109, 134, 100, 110, 142, 104, 105, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int addTableSwitch(int low, int high)
    {
      if (low > high)
      {
        string str = new StringBuilder().append("Bad bounds: ").append(low).append(' ').append(high).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ClassFileWriter.ClassFileFormatException(str);
      }
      int num1 = (int) this.itsStackTop + ClassFileWriter.stackChange(170);
      if (num1 < 0 || (int) short.MaxValue < num1)
        ClassFileWriter.badStack(num1);
      int num2 = high - low + 1;
      int num3 = 3 & (this.itsCodeBufferTop ^ -1);
      int num4 = this.addReservedCodeSpace(1 + num3 + 4 * (3 + num2));
      int num5 = num4;
      byte[] itsCodeBuffer1 = this.itsCodeBuffer;
      int index1 = num4;
      int num6 = num4 + 1;
      itsCodeBuffer1[index1] = (byte) 170;
      for (; num3 != 0; num3 += -1)
      {
        byte[] itsCodeBuffer2 = this.itsCodeBuffer;
        int index2 = num6;
        ++num6;
        itsCodeBuffer2[index2] = (byte) 0;
      }
      int num7 = num6 + 4;
      int num8 = ClassFileWriter.putInt32(low, this.itsCodeBuffer, num7);
      ClassFileWriter.putInt32(high, this.itsCodeBuffer, num8);
      this.itsStackTop = (short) num1;
      if (num1 > (int) this.itsMaxStack)
        this.itsMaxStack = (short) num1;
      return num5;
    }

    [LineNumberTable(new byte[] {170, 60, 108, 114, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void markTableSwitchDefault(int switchStart)
    {
      this.addSuperBlockStart(this.itsCodeBufferTop);
      this.itsJumpFroms.put(this.itsCodeBufferTop, switchStart);
      this.setTableSwitchJump(switchStart, -1, this.itsCodeBufferTop);
    }

    [LineNumberTable(new byte[] {170, 66, 108, 114, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void markTableSwitchCase(int switchStart, int caseIndex)
    {
      this.addSuperBlockStart(this.itsCodeBufferTop);
      this.itsJumpFroms.put(this.itsCodeBufferTop, switchStart);
      this.setTableSwitchJump(switchStart, caseIndex, this.itsCodeBufferTop);
    }

    [LineNumberTable(new byte[] {170, 73, 109, 127, 6, 104, 108, 114, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void markTableSwitchCase(int switchStart, int caseIndex, int stackTop)
    {
      if (0 > stackTop || stackTop > (int) this.itsMaxStack)
      {
        string str = new StringBuilder().append("Bad stack index: ").append(stackTop).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.itsStackTop = (short) stackTop;
      this.addSuperBlockStart(this.itsCodeBufferTop);
      this.itsJumpFroms.put(this.itsCodeBufferTop, switchStart);
      this.setTableSwitchJump(switchStart, caseIndex, this.itsCodeBufferTop);
    }

    [LineNumberTable(new byte[] {170, 119, 103, 114, 104, 143, 111, 111, 167, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int acquireLabel()
    {
      int itsLabelTableTop = this.itsLabelTableTop;
      if (this.itsLabelTable == null || itsLabelTableTop == this.itsLabelTable.Length)
      {
        if (this.itsLabelTable == null)
        {
          this.itsLabelTable = new int[32];
        }
        else
        {
          int[] numArray = new int[this.itsLabelTable.Length * 2];
          ByteCodeHelper.arraycopy_primitive_4((Array) this.itsLabelTable, 0, (Array) numArray, 0, itsLabelTableTop);
          this.itsLabelTable = numArray;
        }
      }
      this.itsLabelTableTop = itsLabelTableTop + 1;
      this.itsLabelTable[itsLabelTableTop] = -1;
      return itsLabelTableTop | int.MinValue;
    }

    [LineNumberTable(new byte[] {156, 204, 66, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void markLabel(int label, short stackTop)
    {
      int num = (int) stackTop;
      this.markLabel(label);
      this.itsStackTop = (short) num;
    }

    [LineNumberTable(new byte[] {170, 155, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void markHandler(int theLabel)
    {
      this.itsStackTop = (short) 1;
      this.markLabel(theLabel);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCurrentCodeOffset() => this.itsCodeBufferTop;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short getStackTop() => this.itsStackTop;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStackTop(short n) => this.itsStackTop = n;

    [LineNumberTable(new byte[] {170, 229, 105, 108, 102, 104, 105, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void adjustStackTop(int delta)
    {
      int num = (int) this.itsStackTop + delta;
      if (num < 0 || (int) short.MaxValue < num)
        ClassFileWriter.badStack(num);
      this.itsStackTop = (short) num;
      if (num <= (int) this.itsMaxStack)
        return;
      this.itsMaxStack = (short) num;
    }

    [LineNumberTable(new byte[] {171, 15, 110, 112, 110, 112, 110, 240, 71, 143, 102, 234, 69, 103, 99, 110, 106, 105, 111, 135, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addExceptionHandler(
      int startLabel,
      int endLabel,
      int handlerLabel,
      string catchClassName)
    {
      if ((startLabel & int.MinValue) != int.MinValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Bad startLabel");
      }
      if ((endLabel & int.MinValue) != int.MinValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Bad endLabel");
      }
      if ((handlerLabel & int.MinValue) != int.MinValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Bad handlerLabel");
      }
      int num = catchClassName != null ? (int) this.itsConstantPool.addClass(catchClassName) : 0;
      ExceptionTableEntry exceptionTableEntry = new ExceptionTableEntry(startLabel, endLabel, handlerLabel, (short) num);
      int exceptionTableTop = this.itsExceptionTableTop;
      if (exceptionTableTop == 0)
        this.itsExceptionTable = new ExceptionTableEntry[4];
      else if (exceptionTableTop == this.itsExceptionTable.Length)
      {
        ExceptionTableEntry[] exceptionTableEntryArray = new ExceptionTableEntry[exceptionTableTop * 2];
        ByteCodeHelper.arraycopy_fast((Array) this.itsExceptionTable, 0, (Array) exceptionTableEntryArray, 0, exceptionTableTop);
        this.itsExceptionTable = exceptionTableEntryArray;
      }
      this.itsExceptionTable[exceptionTableTop] = exceptionTableEntry;
      this.itsExceptionTableTop = exceptionTableTop + 1;
    }

    [LineNumberTable(new byte[] {156, 166, 162, 104, 112, 103, 99, 111, 106, 105, 111, 135, 115, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLineNumberEntry(short lineNumber)
    {
      int num = (int) lineNumber;
      if (this.itsCurrentMethod == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("No method to stop");
      }
      int lineNumberTableTop = this.itsLineNumberTableTop;
      if (lineNumberTableTop == 0)
        this.itsLineNumberTable = new int[16];
      else if (lineNumberTableTop == this.itsLineNumberTable.Length)
      {
        int[] numArray = new int[lineNumberTableTop * 2];
        ByteCodeHelper.arraycopy_primitive_4((Array) this.itsLineNumberTable, 0, (Array) numArray, 0, lineNumberTableTop);
        this.itsLineNumberTable = numArray;
      }
      this.itsLineNumberTable[lineNumberTableTop] = (this.itsCodeBufferTop << 16) + num;
      this.itsLineNumberTableTop = lineNumberTableTop + 1;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {171, 136, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(OutputStream oStream)
    {
      byte[] byteArray = this.toByteArray();
      oStream.write(byteArray);
    }

    [LineNumberTable(new byte[] {171, 254, 106, 106, 100, 130, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal char[] getCharBuffer([In] int obj0)
    {
      if (obj0 > this.tmpCharBuffer.Length)
      {
        int length = this.tmpCharBuffer.Length * 2;
        if (obj0 > length)
          length = obj0;
        this.tmpCharBuffer = new char[length];
      }
      return this.tmpCharBuffer;
    }

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024000([In] ClassFileWriter obj0) => obj0.itsSuperBlockStartsTop;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int[] access\u0024100([In] ClassFileWriter obj0) => obj0.createInitialLocals();

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int[] access\u0024200([In] ClassFileWriter obj0) => obj0.itsSuperBlockStarts;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024300([In] ClassFileWriter obj0) => obj0.itsCodeBufferTop;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024400([In] ClassFileWriter obj0) => obj0.itsExceptionTableTop;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ExceptionTableEntry[] access\u0024500([In] ClassFileWriter obj0) => obj0.itsExceptionTable;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static UintMap access\u0024600([In] ClassFileWriter obj0) => obj0.itsJumpFroms;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static byte[] access\u0024700([In] ClassFileWriter obj0) => obj0.itsCodeBuffer;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024410([In] ClassFileWriter obj0)
    {
      ClassFileWriter classFileWriter1 = obj0;
      int exceptionTableTop = classFileWriter1.itsExceptionTableTop;
      ClassFileWriter classFileWriter2 = classFileWriter1;
      int num = exceptionTableTop;
      classFileWriter2.itsExceptionTableTop = exceptionTableTop - 1;
      return num;
    }

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static char access\u0024900([In] int obj0) => ClassFileWriter.arrayTypeToName(obj0);

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u00241000([In] string obj0) => ClassFileWriter.sizeOfParameters(obj0);

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static short access\u00241100([In] ClassFileWriter obj0) => obj0.itsThisClassIndex;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string access\u00241200([In] string obj0) => ClassFileWriter.descriptorToInternalName(obj0);

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u00241300([In] int obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      return ClassFileWriter.opcodeLength(obj0, num != 0);
    }

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static short access\u00241400([In] ClassFileWriter obj0) => obj0.itsMaxLocals;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static short access\u00241500([In] ClassFileWriter obj0) => obj0.itsMaxStack;

    [LineNumberTable(new byte[] {159, 128, 77, 98, 133, 112, 99, 171, 167, 99, 101, 111, 101, 107, 103, 98, 106, 218, 102, 102, 109, 131, 145, 34, 161, 230, 55, 102, 102, 109, 134, 145, 34, 97, 226, 54, 161, 102, 102, 109, 131, 145, 34, 97, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ClassFileWriter()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.classfile.ClassFileWriter"))
        return;
      InputStream inputStream = (InputStream) null;
      int num1 = 48;
      int num2 = 0;
      // ISSUE: fault handler
      try
      {
        inputStream = ((Class) ClassLiteral<ClassFileWriter>.Value).getResourceAsStream("ClassFileWriter.class") ?? ClassLoader.getSystemResourceAsStream("org/mozilla/classfile/ClassFileWriter.class");
        byte[] numArray = new byte[8];
        int num3;
        for (int index = 0; index < 8; index += num3)
        {
          num3 = inputStream.read(numArray, index, 8 - index);
          if (num3 < 0)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IOException();
          }
        }
        num2 = (int) (sbyte) numArray[4] << 8 | (int) numArray[5];
        num1 = (int) (sbyte) numArray[6] << 8 | (int) numArray[7];
        goto label_17;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      __fault
      {
        ClassFileWriter.MinorVersion = num2;
        ClassFileWriter.MajorVersion = num1;
        ClassFileWriter.GenerateStackMap = num1 >= 50;
        if (inputStream != null)
        {
          try
          {
            inputStream.close();
            goto label_15;
          }
          catch (IOException ex)
          {
          }
        }
label_15:;
      }
      ClassFileWriter.MinorVersion = num2;
      ClassFileWriter.MajorVersion = num1;
      ClassFileWriter.GenerateStackMap = num1 >= 50;
      if (inputStream == null)
        return;
      try
      {
        inputStream.close();
      }
      catch (IOException ex)
      {
      }
      return;
label_17:
      ClassFileWriter.MinorVersion = num2;
      ClassFileWriter.MajorVersion = num1;
      ClassFileWriter.GenerateStackMap = num1 >= 50;
      if (inputStream == null)
        return;
      try
      {
        inputStream.close();
      }
      catch (IOException ex)
      {
      }
    }

    internal sealed class BootstrapEntry : Object
    {
      [Modifiers]
      internal byte[] code;
      [Modifiers]
      internal ClassFileWriter this\u00240;

      [LineNumberTable(new byte[] {177, 3, 111, 103, 108, 121, 111, 103, 63, 0, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal BootstrapEntry(
        ClassFileWriter _param1,
        ClassFileWriter.MHandle _param2,
        params object[] _param3)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ClassFileWriter.BootstrapEntry bootstrapEntry = this;
        this.code = new byte[4 + _param3.Length * 2];
        ClassFileWriter.putInt16((int) ClassFileWriter.access\u0024800(_param1).addMethodHandle(_param2), this.code, 0);
        ClassFileWriter.putInt16(_param3.Length, this.code, 2);
        for (int index = 0; index < _param3.Length; ++index)
          ClassFileWriter.putInt16(ClassFileWriter.access\u0024800(_param1).addConstant(_param3[index]), this.code, 4 + index * 2);
      }

      [LineNumberTable(new byte[] {177, 15, 121, 43})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool equals([In] object obj0) => obj0 is ClassFileWriter.BootstrapEntry && Arrays.equals(this.code, ((ClassFileWriter.BootstrapEntry) obj0).code);

      [LineNumberTable(4487)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int hashCode() => Arrays.hashCode(this.code) ^ -1;
    }

    public class ClassFileFormatException : RuntimeException
    {
      private const long serialVersionUID = 1263998431033790599;

      [LineNumberTable(new byte[] {172, 70, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ClassFileFormatException([In] string obj0)
        : base(obj0)
      {
      }
    }

    public sealed class MHandle : Object
    {
      [Modifiers]
      internal byte tag;
      [Modifiers]
      internal string owner;
      [Modifiers]
      internal string name;
      [Modifiers]
      internal string desc;

      [LineNumberTable(new byte[] {156, 94, 163, 104, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MHandle(byte tag, string owner, string name, string desc)
      {
        int num = (int) (sbyte) tag;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ClassFileWriter.MHandle mhandle = this;
        this.tag = (byte) num;
        this.owner = owner;
        this.name = name;
        this.desc = desc;
      }

      [LineNumberTable(new byte[] {172, 90, 105, 130, 104, 130, 103, 127, 16, 62})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool equals(object obj)
      {
        if (object.ReferenceEquals(obj, (object) this))
          return true;
        if (!(obj is ClassFileWriter.MHandle))
          return false;
        ClassFileWriter.MHandle mhandle = (ClassFileWriter.MHandle) obj;
        return (int) (sbyte) this.tag == (int) (sbyte) mhandle.tag && String.instancehelper_equals(this.owner, (object) mhandle.owner) && (String.instancehelper_equals(this.name, (object) mhandle.name) && String.instancehelper_equals(this.desc, (object) mhandle.desc));
      }

      [LineNumberTable(3289)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int hashCode() => (int) (sbyte) this.tag + String.instancehelper_hashCode(this.owner) * String.instancehelper_hashCode(this.name) * String.instancehelper_hashCode(this.desc);

      [LineNumberTable(3294)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append(this.owner).append('.').append(this.name).append(this.desc).append(" (").append((int) (sbyte) this.tag).append(')').toString();
    }

    internal sealed class StackMapTable : Object
    {
      internal const bool DEBUGSTACKMAP = false;
      private int[] locals;
      private int localsTop;
      private int[] stack;
      private int stackTop;
      private SuperBlock[] workList;
      private int workListTop;
      private SuperBlock[] superBlocks;
      private SuperBlock[] superBlockDeps;
      private byte[] rawStackMap;
      private int rawStackMapTop;
      private bool wide;
      [Modifiers]
      internal ClassFileWriter this\u00240;

      [LineNumberTable(new byte[] {172, 137, 111, 103, 114, 103, 103, 103, 103, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal StackMapTable([In] ClassFileWriter obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ClassFileWriter.StackMapTable stackMapTable1 = this;
        this.superBlocks = (SuperBlock[]) null;
        ClassFileWriter.StackMapTable stackMapTable2 = this;
        this.stack = (int[]) null;
        this.locals = (int[]) null;
        this.workList = (SuperBlock[]) null;
        this.rawStackMap = (byte[]) null;
        this.localsTop = 0;
        this.stackTop = 0;
        this.workListTop = 0;
        this.rawStackMapTop = 0;
        this.wide = false;
      }

      [LineNumberTable(new byte[] {172, 150, 118, 140, 115, 142, 112, 142, 144, 241, 56, 233, 85, 140, 230, 75})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void generate()
      {
        this.superBlocks = new SuperBlock[ClassFileWriter.access\u0024000(this.this\u00240)];
        int[] numArray = ClassFileWriter.access\u0024100(this.this\u00240);
        for (int index = 0; index < ClassFileWriter.access\u0024000(this.this\u00240); ++index)
        {
          int num1 = ClassFileWriter.access\u0024200(this.this\u00240)[index];
          int num2 = index != ClassFileWriter.access\u0024000(this.this\u00240) - 1 ? ClassFileWriter.access\u0024200(this.this\u00240)[index + 1] : ClassFileWriter.access\u0024300(this.this\u00240);
          this.superBlocks[index] = new SuperBlock(index, num1, num2, numArray);
        }
        this.superBlockDeps = this.getSuperBlockDependencies();
        this.verify();
      }

      [LineNumberTable(new byte[] {176, 86, 103, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual int computeWriteSize()
      {
        this.rawStackMap = new byte[this.getWorstCaseWriteSize()];
        this.computeRawStackMap();
        return this.rawStackMapTop + 2;
      }

      [LineNumberTable(new byte[] {176, 93, 113, 114, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual int write([In] byte[] obj0, [In] int obj1)
      {
        obj1 = ClassFileWriter.putInt32(this.rawStackMapTop + 2, obj0, obj1);
        obj1 = ClassFileWriter.putInt16(this.superBlocks.Length - 1, obj0, obj1);
        ByteCodeHelper.arraycopy_primitive_1((Array) this.rawStackMap, 0, (Array) obj0, obj1, this.rawStackMapTop);
        return obj1 + this.rawStackMapTop;
      }

      [LineNumberTable(new byte[] {172, 229, 141, 115, 110, 114, 115, 106, 105, 235, 58, 233, 72, 114, 119, 117, 106, 106, 235, 60, 232, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private SuperBlock[] getSuperBlockDependencies()
      {
        SuperBlock[] superBlockArray = new SuperBlock[this.superBlocks.Length];
        for (int index = 0; index < ClassFileWriter.access\u0024400(this.this\u00240); ++index)
        {
          ExceptionTableEntry exceptionTableEntry = ClassFileWriter.access\u0024500(this.this\u00240)[index];
          int labelPc = this.this\u00240.getLabelPC(exceptionTableEntry.itsStartLabel);
          SuperBlock superBlockFromOffset1 = this.getSuperBlockFromOffset(this.this\u00240.getLabelPC(exceptionTableEntry.itsHandlerLabel));
          SuperBlock superBlockFromOffset2 = this.getSuperBlockFromOffset(labelPc);
          superBlockArray[superBlockFromOffset1.getIndex()] = superBlockFromOffset2;
        }
        int[] keys = ClassFileWriter.access\u0024600(this.this\u00240).getKeys();
        int length = keys.Length;
        for (int index = 0; index < length; ++index)
        {
          int key = keys[index];
          SuperBlock superBlockFromOffset1 = this.getSuperBlockFromOffset(ClassFileWriter.access\u0024600(this.this\u00240).getInt(key, -1));
          SuperBlock superBlockFromOffset2 = this.getSuperBlockFromOffset(key);
          superBlockArray[superBlockFromOffset2.getIndex()] = superBlockFromOffset1;
        }
        return superBlockArray;
      }

      [LineNumberTable(new byte[] {173, 61, 108, 120, 37, 230, 69, 119, 103, 166, 117, 105, 8, 230, 69, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void verify()
      {
        int[] numArray = ClassFileWriter.access\u0024100(this.this\u00240);
        this.superBlocks[0].merge(numArray, numArray.Length, new int[0], 0, ClassFileWriter.access\u0024800(this.this\u00240));
        this.workList = new SuperBlock[1]
        {
          this.superBlocks[0]
        };
        this.workListTop = 1;
        this.executeWorkList();
        SuperBlock[] superBlocks = this.superBlocks;
        int length = superBlocks.Length;
        for (int index = 0; index < length; ++index)
        {
          SuperBlock superBlock = superBlocks[index];
          if (!superBlock.isInitialized())
            this.killSuperBlock(superBlock);
        }
        this.executeWorkList();
      }

      [LineNumberTable(new byte[] {172, 190, 116, 99, 98, 114, 226, 60, 230, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private SuperBlock getSuperBlockFromOffset([In] int obj0)
      {
        SuperBlock[] superBlocks = this.superBlocks;
        int length = superBlocks.Length;
        for (int index = 0; index < length; ++index)
        {
          SuperBlock superBlock = superBlocks[index];
          if (superBlock != null)
          {
            if (obj0 >= superBlock.getStart() && obj0 < superBlock.getEnd())
              return superBlock;
          }
          else
            break;
        }
        string str = new StringBuilder().append("bad offset: ").append(obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }

      [LineNumberTable(new byte[] {173, 47, 98, 100, 144, 102, 52, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int getOperand([In] int obj0, [In] int obj1)
      {
        int num = 0;
        if (obj1 > 4)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("bad operand size");
        }
        for (int index = 0; index < obj1; ++index)
          num = num << 8 | (int) ClassFileWriter.access\u0024700(this.this\u00240)[obj0 + index];
        return num;
      }

      [LineNumberTable(new byte[] {173, 142, 108, 123, 103, 108, 108, 109, 109, 103, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void executeWorkList()
      {
        while (this.workListTop > 0)
        {
          SuperBlock[] workList = this.workList;
          ClassFileWriter.StackMapTable stackMapTable1 = this;
          int num = stackMapTable1.workListTop - 1;
          ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
          int index = num;
          stackMapTable2.workListTop = num;
          SuperBlock superBlock = workList[index];
          superBlock.setInQueue(false);
          this.locals = superBlock.getLocals();
          this.stack = superBlock.getStack();
          this.localsTop = this.locals.Length;
          this.stackTop = this.stack.Length;
          this.executeBlock(superBlock);
        }
      }

      [LineNumberTable(new byte[] {173, 96, 103, 115, 37, 231, 71, 115, 110, 115, 115, 115, 106, 119, 115, 103, 104, 226, 54, 233, 81, 115, 110, 115, 106, 127, 37, 108, 228, 58, 233, 74, 109, 37, 166, 105, 111, 109, 47, 168})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void killSuperBlock([In] SuperBlock obj0)
      {
        int[] numArray1 = new int[0];
        int[] numArray2 = new int[1]
        {
          TypeInfo.OBJECT("java/lang/Throwable", ClassFileWriter.access\u0024800(this.this\u00240))
        };
        for (int index = 0; index < ClassFileWriter.access\u0024400(this.this\u00240); ++index)
        {
          ExceptionTableEntry exceptionTableEntry = ClassFileWriter.access\u0024500(this.this\u00240)[index];
          int labelPc1 = this.this\u00240.getLabelPC(exceptionTableEntry.itsStartLabel);
          int labelPc2 = this.this\u00240.getLabelPC(exceptionTableEntry.itsEndLabel);
          SuperBlock superBlockFromOffset = this.getSuperBlockFromOffset(this.this\u00240.getLabelPC(exceptionTableEntry.itsHandlerLabel));
          if (obj0.getStart() > labelPc1 && obj0.getStart() < labelPc2 || labelPc1 > obj0.getStart() && labelPc1 < obj0.getEnd() && superBlockFromOffset.isInitialized())
          {
            numArray1 = superBlockFromOffset.getLocals();
            break;
          }
        }
        for (int index = 0; index < ClassFileWriter.access\u0024400(this.this\u00240); ++index)
        {
          if (this.this\u00240.getLabelPC(ClassFileWriter.access\u0024500(this.this\u00240)[index].itsStartLabel) == obj0.getStart())
          {
            if (ClassFileWriter.access\u0024400(this.this\u00240) - index + 1 >= 0)
              ByteCodeHelper.arraycopy_fast((Array) ClassFileWriter.access\u0024500(this.this\u00240), index + 1, (Array) ClassFileWriter.access\u0024500(this.this\u00240), index + 1 - 1, ClassFileWriter.access\u0024400(this.this\u00240) - index + 1);
            ClassFileWriter.access\u0024410(this.this\u00240);
            index += -1;
          }
        }
        obj0.merge(numArray1, numArray1.Length, numArray2, numArray2.Length, ClassFileWriter.access\u0024800(this.this\u00240));
        int index1 = obj0.getEnd() - 1;
        ClassFileWriter.access\u0024700(this.this\u00240)[index1] = (byte) 191;
        for (int start = obj0.getStart(); start < index1; ++start)
          ClassFileWriter.access\u0024700(this.this\u00240)[start] = (byte) 0;
      }

      [LineNumberTable(new byte[] {173, 157, 226, 74, 115, 110, 232, 71, 105, 232, 75, 231, 71, 112, 107, 107, 101, 231, 69, 104, 109, 109, 105, 103, 105, 114, 234, 70, 232, 56, 232, 76, 117, 112, 116, 116, 109, 133, 116, 170, 105, 102, 47, 169, 142, 127, 1, 37, 134, 232, 45, 235, 10, 233, 160, 86, 105, 105, 234, 70, 174})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void executeBlock([In] SuperBlock obj0)
      {
        int num1 = 0;
        int num2;
        for (int start = obj0.getStart(); start < obj0.getEnd(); start += num2)
        {
          num1 = (int) ClassFileWriter.access\u0024700(this.this\u00240)[start];
          num2 = this.execute(start);
          if (this.isBranch(num1))
            this.flowInto(this.getBranchTarget(start));
          else if (num1 == 170)
          {
            int num3 = start + 1 + (3 & (start ^ -1));
            int operand1 = this.getOperand(num3, 4);
            this.flowInto(this.getSuperBlockFromOffset(start + operand1));
            int operand2 = this.getOperand(num3 + 4, 4);
            int num4 = this.getOperand(num3 + 8, 4) - operand2 + 1;
            int num5 = num3 + 12;
            for (int index = 0; index < num4; ++index)
              this.flowInto(this.getSuperBlockFromOffset(start + this.getOperand(num5 + 4 * index, 4)));
          }
          for (int index = 0; index < ClassFileWriter.access\u0024400(this.this\u00240); ++index)
          {
            ExceptionTableEntry exceptionTableEntry = ClassFileWriter.access\u0024500(this.this\u00240)[index];
            int labelPc1 = this.this\u00240.getLabelPC(exceptionTableEntry.itsStartLabel);
            int labelPc2 = this.this\u00240.getLabelPC(exceptionTableEntry.itsEndLabel);
            if (start >= labelPc1 && start < labelPc2)
            {
              SuperBlock superBlockFromOffset = this.getSuperBlockFromOffset(this.this\u00240.getLabelPC(exceptionTableEntry.itsHandlerLabel));
              int num3 = exceptionTableEntry.itsCatchType != (short) 0 ? TypeInfo.OBJECT((int) exceptionTableEntry.itsCatchType) : TypeInfo.OBJECT((int) ClassFileWriter.access\u0024800(this.this\u00240).addClass("java/lang/Throwable"));
              superBlockFromOffset.merge(this.locals, this.localsTop, new int[1]
              {
                num3
              }, 1, ClassFileWriter.access\u0024800(this.this\u00240));
              this.addToWorkList(superBlockFromOffset);
            }
          }
        }
        if (this.isSuperBlockEnd(num1))
          return;
        int index1 = obj0.getIndex() + 1;
        if (index1 >= this.superBlocks.Length)
          return;
        this.flowInto(this.superBlocks[index1]);
      }

      [LineNumberTable(new byte[] {174, 39, 142, 194, 255, 162, 212, 70, 133, 103, 117, 229, 73, 231, 75, 231, 78, 103, 133, 103, 133, 103, 229, 85, 231, 75, 231, 80, 103, 229, 77, 231, 70, 231, 73, 103, 229, 71, 231, 70, 231, 74, 103, 229, 71, 231, 70, 231, 73, 103, 133, 124, 229, 69, 107, 133, 124, 229, 69, 107, 133, 124, 229, 69, 107, 133, 124, 229, 69, 107, 133, 123, 229, 69, 106, 133, 123, 229, 69, 106, 229, 71, 102, 133, 103, 102, 103, 133, 103, 103, 103, 103, 197, 101, 141, 140, 117, 159, 4, 103, 133, 103, 133, 103, 133, 103, 133, 108, 37, 138, 133, 255, 7, 69, 108, 133, 103, 102, 112, 127, 14, 110, 133, 108, 121, 103, 127, 10, 37, 138, 229, 69, 108, 102, 115, 105, 105, 108, 105, 39, 168, 104, 104, 105, 143, 110, 102, 108, 106, 98, 208, 107, 109, 105, 113, 221, 108, 121, 108, 105, 39, 168, 107, 109, 105, 113, 221, 167, 108, 102, 115, 110, 120, 133, 103, 103, 103, 133, 103, 103, 103, 103, 103, 133, 103, 104, 103, 104, 103, 133, 104, 104, 104, 133, 104, 103, 104, 103, 104, 133, 104, 104, 104, 104, 104, 133, 107, 109, 109, 111, 103, 133, 103, 106, 102, 115, 100, 108, 144, 106, 105, 116, 109, 162, 103, 226, 72, 191, 6, 99, 141, 112, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int execute([In] int obj0)
      {
        int num1 = (int) ClassFileWriter.access\u0024700(this.this\u00240)[obj0];
        int num2 = 0;
        switch (num1)
        {
          case 0:
          case 132:
          case 167:
          case 200:
label_73:
            if (num2 == 0)
              num2 = ClassFileWriter.access\u00241300(num1, this.wide);
            if (this.wide && num1 != 196)
              this.wide = false;
            return num2;
          case 1:
            this.push(5);
            goto case 0;
          case 2:
          case 3:
          case 4:
          case 5:
          case 6:
          case 7:
          case 8:
          case 16:
          case 17:
          case 21:
          case 26:
          case 27:
          case 28:
          case 29:
            this.push(1);
            goto case 0;
          case 9:
          case 10:
          case 22:
          case 30:
          case 31:
          case 32:
          case 33:
            this.push(4);
            goto case 0;
          case 11:
          case 12:
          case 13:
          case 23:
          case 34:
          case 35:
          case 36:
          case 37:
            this.push(2);
            goto case 0;
          case 14:
          case 15:
          case 24:
          case 38:
          case 39:
          case 40:
          case 41:
            this.push(3);
            goto case 0;
          case 18:
          case 19:
          case 20:
            int num3 = num1 != 18 ? this.getOperand(obj0 + 1, 2) : this.getOperand(obj0 + 1);
            int constantType = (int) (sbyte) ClassFileWriter.access\u0024800(this.this\u00240).getConstantType(num3);
            switch (constantType)
            {
              case 3:
                this.push(1);
                goto label_73;
              case 4:
                this.push(2);
                goto label_73;
              case 5:
                this.push(4);
                goto label_73;
              case 6:
                this.push(3);
                goto label_73;
              case 8:
                this.push(TypeInfo.OBJECT("java/lang/String", ClassFileWriter.access\u0024800(this.this\u00240)));
                goto label_73;
              default:
                string str1 = new StringBuilder().append("bad const type ").append(constantType).toString();
                Throwable.__\u003CsuppressFillInStackTrace\u003E();
                throw new IllegalArgumentException(str1);
            }
          case 25:
            this.executeALoad(this.getOperand(obj0 + 1, !this.wide ? 1 : 2));
            goto case 0;
          case 42:
          case 43:
          case 44:
          case 45:
            this.executeALoad(num1 - 42);
            goto case 0;
          case 46:
          case 51:
          case 52:
          case 53:
          case 96:
          case 100:
          case 104:
          case 108:
          case 112:
          case 120:
          case 122:
          case 124:
          case 126:
          case 128:
          case 130:
          case 148:
          case 149:
          case 150:
          case 151:
          case 152:
            this.pop();
            goto case 116;
          case 47:
          case 97:
          case 101:
          case 105:
          case 109:
          case 113:
          case 121:
          case 123:
          case 125:
          case (int) sbyte.MaxValue:
          case 129:
          case 131:
            this.pop();
            goto case 117;
          case 48:
          case 98:
          case 102:
          case 106:
          case 110:
          case 114:
            this.pop();
            goto case 118;
          case 49:
          case 99:
          case 103:
          case 107:
          case 111:
          case 115:
            this.pop();
            goto case 119;
          case 50:
            this.pop();
            int num4 = (int) ((uint) this.pop() >> 8);
            string constantData1 = (string) ClassFileWriter.access\u0024800(this.this\u00240).getConstantData(num4);
            if (String.instancehelper_charAt(constantData1, 0) != '[')
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalStateException("bad array type");
            }
            string str2 = ClassFileWriter.access\u00241200(String.instancehelper_substring(constantData1, 1));
            this.push(TypeInfo.OBJECT((int) ClassFileWriter.access\u0024800(this.this\u00240).addClass(str2)));
            goto case 0;
          case 54:
            this.executeStore(this.getOperand(obj0 + 1, !this.wide ? 1 : 2), 1);
            goto case 0;
          case 55:
            this.executeStore(this.getOperand(obj0 + 1, !this.wide ? 1 : 2), 4);
            goto case 0;
          case 56:
            this.executeStore(this.getOperand(obj0 + 1, !this.wide ? 1 : 2), 2);
            goto case 0;
          case 57:
            this.executeStore(this.getOperand(obj0 + 1, !this.wide ? 1 : 2), 3);
            goto case 0;
          case 58:
            this.executeAStore(this.getOperand(obj0 + 1, !this.wide ? 1 : 2));
            goto case 0;
          case 59:
          case 60:
          case 61:
          case 62:
            this.executeStore(num1 - 59, 1);
            goto case 0;
          case 63:
          case 64:
          case 65:
          case 66:
            this.executeStore(num1 - 63, 4);
            goto case 0;
          case 67:
          case 68:
          case 69:
          case 70:
            this.executeStore(num1 - 67, 2);
            goto case 0;
          case 71:
          case 72:
          case 73:
          case 74:
            this.executeStore(num1 - 71, 3);
            goto case 0;
          case 75:
          case 76:
          case 77:
          case 78:
            this.executeAStore(num1 - 75);
            goto case 0;
          case 79:
          case 80:
          case 81:
          case 82:
          case 83:
          case 84:
          case 85:
          case 86:
            this.pop();
            goto case 159;
          case 87:
          case 153:
          case 154:
          case 155:
          case 156:
          case 157:
          case 158:
          case 179:
          case 194:
          case 195:
          case 198:
          case 199:
            this.pop();
            goto case 0;
          case 88:
            this.pop2();
            goto case 0;
          case 89:
            int num5 = this.pop();
            this.push(num5);
            this.push(num5);
            goto case 0;
          case 90:
            int num6 = this.pop();
            int num7 = this.pop();
            this.push(num6);
            this.push(num7);
            this.push(num6);
            goto case 0;
          case 91:
            int num8 = this.pop();
            long num9 = this.pop2();
            this.push(num8);
            this.push2(num9);
            this.push(num8);
            goto case 0;
          case 92:
            long num10 = this.pop2();
            this.push2(num10);
            this.push2(num10);
            goto case 0;
          case 93:
            long num11 = this.pop2();
            int num12 = this.pop();
            this.push2(num11);
            this.push(num12);
            this.push2(num11);
            goto case 0;
          case 94:
            long num13 = this.pop2();
            long num14 = this.pop2();
            this.push2(num13);
            this.push2(num14);
            this.push2(num13);
            goto case 0;
          case 95:
            int num15 = this.pop();
            int num16 = this.pop();
            this.push(num15);
            this.push(num16);
            goto case 0;
          case 116:
          case 136:
          case 139:
          case 142:
          case 145:
          case 146:
          case 147:
          case 190:
          case 193:
            this.pop();
            goto case 2;
          case 117:
          case 133:
          case 140:
          case 143:
            this.pop();
            goto case 9;
          case 118:
          case 134:
          case 137:
          case 144:
            this.pop();
            goto case 11;
          case 119:
          case 135:
          case 138:
          case 141:
            this.pop();
            goto case 14;
          case 159:
          case 160:
          case 161:
          case 162:
          case 163:
          case 164:
          case 165:
          case 166:
          case 181:
            this.pop();
            goto case 87;
          case 170:
            int num17 = obj0 + 1 + (3 & (obj0 ^ -1));
            int operand1 = this.getOperand(num17 + 4, 4);
            num2 = 4 * (this.getOperand(num17 + 8, 4) - operand1 + 4) + num17 - obj0;
            this.pop();
            goto case 0;
          case 172:
          case 173:
          case 174:
          case 175:
          case 176:
          case 177:
            this.clearStack();
            goto case 0;
          case 178:
            int operand2 = this.getOperand(obj0 + 1, 2);
            this.push(TypeInfo.fromType(ClassFileWriter.access\u00241200(((FieldOrMethodRef) ClassFileWriter.access\u0024800(this.this\u00240).getConstantData(operand2)).getType()), ClassFileWriter.access\u0024800(this.this\u00240)));
            goto case 0;
          case 180:
            this.pop();
            goto case 178;
          case 182:
          case 183:
          case 184:
          case 185:
            int operand3 = this.getOperand(obj0 + 1, 2);
            FieldOrMethodRef constantData2 = (FieldOrMethodRef) ClassFileWriter.access\u0024800(this.this\u00240).getConstantData(operand3);
            string type = constantData2.getType();
            string name = constantData2.getName();
            int num18 = (int) ((uint) ClassFileWriter.access\u00241000(type) >> 16);
            for (int index = 0; index < num18; ++index)
              this.pop();
            if (num1 != 184)
            {
              int num19 = this.pop();
              int tag = TypeInfo.getTag(num19);
              if (tag == TypeInfo.UNINITIALIZED_VARIABLE(0) || tag == 6)
              {
                if (String.instancehelper_equals("<init>", (object) name))
                {
                  int num20 = TypeInfo.OBJECT((int) ClassFileWriter.access\u00241100(this.this\u00240));
                  this.initializeTypeInfo(num19, num20);
                }
                else
                {
                  Throwable.__\u003CsuppressFillInStackTrace\u003E();
                  throw new IllegalStateException("bad instance");
                }
              }
            }
            int num21 = String.instancehelper_indexOf(type, 41);
            string str3 = ClassFileWriter.access\u00241200(String.instancehelper_substring(type, num21 + 1));
            if (!String.instancehelper_equals(str3, (object) "V"))
            {
              this.push(TypeInfo.fromType(str3, ClassFileWriter.access\u0024800(this.this\u00240)));
              goto case 0;
            }
            else
              goto case 0;
          case 186:
            int operand4 = this.getOperand(obj0 + 1, 2);
            string constantData3 = (string) ClassFileWriter.access\u0024800(this.this\u00240).getConstantData(operand4);
            int num22 = (int) ((uint) ClassFileWriter.access\u00241000(constantData3) >> 16);
            for (int index = 0; index < num22; ++index)
              this.pop();
            int num23 = String.instancehelper_indexOf(constantData3, 41);
            string str4 = ClassFileWriter.access\u00241200(String.instancehelper_substring(constantData3, num23 + 1));
            if (!String.instancehelper_equals(str4, (object) "V"))
            {
              this.push(TypeInfo.fromType(str4, ClassFileWriter.access\u0024800(this.this\u00240)));
              goto case 0;
            }
            else
              goto case 0;
          case 187:
            this.push(TypeInfo.UNINITIALIZED_VARIABLE(obj0));
            goto case 0;
          case 188:
            this.pop();
            int num24 = (int) ClassFileWriter.access\u0024900((int) (sbyte) ClassFileWriter.access\u0024700(this.this\u00240)[obj0 + 1]);
            this.push(TypeInfo.OBJECT((int) ClassFileWriter.access\u0024800(this.this\u00240).addClass(new StringBuilder().append("[").append((char) num24).toString())));
            goto case 0;
          case 189:
            int operand5 = this.getOperand(obj0 + 1, 2);
            string constantData4 = (string) ClassFileWriter.access\u0024800(this.this\u00240).getConstantData(operand5);
            this.pop();
            this.push(TypeInfo.OBJECT(new StringBuilder().append("[L").append(constantData4).append(';').toString(), ClassFileWriter.access\u0024800(this.this\u00240)));
            goto case 0;
          case 191:
            int num25 = this.pop();
            this.clearStack();
            this.push(num25);
            goto case 0;
          case 192:
            this.pop();
            this.push(TypeInfo.OBJECT(this.getOperand(obj0 + 1, 2)));
            goto case 0;
          case 196:
            this.wide = true;
            goto case 0;
          default:
            string str5 = new StringBuilder().append("bad opcode: ").append(num1).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str5);
        }
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool isBranch([In] int obj0)
      {
        switch (obj0)
        {
          case 153:
          case 154:
          case 155:
          case 156:
          case 157:
          case 158:
          case 159:
          case 160:
          case 161:
          case 162:
          case 163:
          case 164:
          case 165:
          case 166:
          case 167:
          case 198:
          case 199:
          case 200:
            return true;
          default:
            return false;
        }
      }

      [LineNumberTable(new byte[] {173, 0, 116, 143, 142})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private SuperBlock getBranchTarget([In] int obj0) => this.getSuperBlockFromOffset(ClassFileWriter.access\u0024700(this.this\u00240)[obj0] != (byte) 200 ? obj0 + (int) (short) this.getOperand(obj0 + 1, 2) : obj0 + this.getOperand(obj0 + 1, 4));

      [LineNumberTable(new byte[] {174, 15, 127, 12, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void flowInto([In] SuperBlock obj0)
      {
        if (!obj0.merge(this.locals, this.localsTop, this.stack, this.stackTop, ClassFileWriter.access\u0024800(this.this\u00240)))
          return;
        this.addToWorkList(obj0);
      }

      [LineNumberTable(new byte[] {174, 21, 104, 103, 103, 111, 110, 116, 135, 155})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void addToWorkList([In] SuperBlock obj0)
      {
        if (obj0.isInQueue())
          return;
        obj0.setInQueue(true);
        obj0.setInitialized(true);
        if (this.workListTop == this.workList.Length)
        {
          SuperBlock[] superBlockArray = new SuperBlock[this.workListTop * 2];
          ByteCodeHelper.arraycopy_fast((Array) this.workList, 0, (Array) superBlockArray, 0, this.workListTop);
          this.workList = superBlockArray;
        }
        SuperBlock[] workList = this.workList;
        ClassFileWriter.StackMapTable stackMapTable1 = this;
        int workListTop = stackMapTable1.workListTop;
        ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
        int index = workListTop;
        stackMapTable2.workListTop = workListTop + 1;
        SuperBlock superBlock = obj0;
        workList[index] = superBlock;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool isSuperBlockEnd([In] int obj0)
      {
        switch (obj0)
        {
          case 167:
          case 170:
          case 171:
          case 172:
          case 173:
          case 174:
          case 176:
          case 177:
          case 191:
          case 200:
            return true;
          default:
            return false;
        }
      }

      [LineNumberTable(4250)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int pop()
      {
        int[] stack = this.stack;
        ClassFileWriter.StackMapTable stackMapTable1 = this;
        int num = stackMapTable1.stackTop - 1;
        ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
        int index = num;
        stackMapTable2.stackTop = num;
        return stack[index];
      }

      [LineNumberTable(new byte[] {176, 31, 111, 116, 116, 135, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void push([In] int obj0)
      {
        if (this.stackTop == this.stack.Length)
        {
          int[] numArray = new int[Math.max(this.stackTop * 2, 4)];
          ByteCodeHelper.arraycopy_primitive_4((Array) this.stack, 0, (Array) numArray, 0, this.stackTop);
          this.stack = numArray;
        }
        int[] stack = this.stack;
        ClassFileWriter.StackMapTable stackMapTable1 = this;
        int stackTop = stackMapTable1.stackTop;
        ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
        int index = stackTop;
        stackMapTable2.stackTop = stackTop + 1;
        int num = obj0;
        stack[index] = num;
      }

      [LineNumberTable(new byte[] {176, 65, 104, 105, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private long pop2()
      {
        long num = (long) this.pop();
        return TypeInfo.isTwoWords((int) num) ? num : num << 32 | (long) (this.pop() & 16777215);
      }

      [LineNumberTable(new byte[] {175, 247, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void executeStore([In] int obj0, [In] int obj1)
      {
        this.pop();
        this.setLocal(obj0, obj1);
      }

      [LineNumberTable(new byte[] {175, 228, 104, 103, 208, 137, 223, 22})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void executeALoad([In] int obj0)
      {
        int local = this.getLocal(obj0);
        switch (TypeInfo.getTag(local))
        {
          case 5:
          case 6:
          case 7:
          case 8:
            this.push(local);
            break;
          default:
            string str = new StringBuilder().append("bad local variable type: ").append(local).append(" at index: ").append(obj0).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
      }

      [LineNumberTable(new byte[] {175, 243, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void executeAStore([In] int obj0) => this.setLocal(obj0, this.pop());

      [MethodImpl(MethodImplOptions.NoInlining)]
      private void clearStack() => this.stackTop = 0;

      [LineNumberTable(3480)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int getOperand([In] int obj0) => this.getOperand(obj0, 1);

      [LineNumberTable(new byte[] {176, 0, 116, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void initializeTypeInfo([In] int obj0, [In] int obj1)
      {
        this.initializeTypeInfo(obj0, obj1, this.locals, this.localsTop);
        this.initializeTypeInfo(obj0, obj1, this.stack, this.stackTop);
      }

      [LineNumberTable(new byte[] {176, 50, 111, 102, 105, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void push2([In] long obj0)
      {
        this.push((int) (obj0 & 16777215L));
        obj0 = (long) ((ulong) obj0 >> 32);
        if (obj0 == 0L)
          return;
        this.push((int) (obj0 & 16777215L));
      }

      [LineNumberTable(new byte[] {176, 14, 105, 137})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int getLocal([In] int obj0) => obj0 < this.localsTop ? this.locals[obj0] : 0;

      [LineNumberTable(new byte[] {176, 21, 105, 105, 116, 103, 137, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void setLocal([In] int obj0, [In] int obj1)
      {
        if (obj0 >= this.localsTop)
        {
          int[] numArray = new int[obj0 + 1];
          ByteCodeHelper.arraycopy_primitive_4((Array) this.locals, 0, (Array) numArray, 0, this.localsTop);
          this.locals = numArray;
          this.localsTop = obj0 + 1;
        }
        this.locals[obj0] = obj1;
      }

      [LineNumberTable(new byte[] {176, 6, 103, 102, 4, 230, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void initializeTypeInfo([In] int obj0, [In] int obj1, [In] int[] obj2, [In] int obj3)
      {
        for (int index = 0; index < obj3; ++index)
        {
          if (obj2[index] == obj0)
            obj2[index] = obj1;
        }
      }

      [LineNumberTable(new byte[] {176, 171, 126, 41})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int getWorstCaseWriteSize() => (this.superBlocks.Length - 1) * (7 + (int) ClassFileWriter.access\u00241400(this.this\u00240) * 3 + (int) ClassFileWriter.access\u00241500(this.this\u00240) * 3);

      [LineNumberTable(new byte[] {176, 103, 105, 103, 98, 111, 106, 105, 105, 141, 104, 144, 237, 69, 105, 107, 2, 232, 69, 171, 106, 172, 108, 171, 206, 172, 104, 106, 204, 238, 71, 172, 99, 232, 10, 233, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void computeRawStackMap()
      {
        int[] numArray = this.superBlocks[0].getTrimmedLocals();
        int num1 = -1;
        for (int index1 = 1; index1 < this.superBlocks.Length; ++index1)
        {
          SuperBlock superBlock = this.superBlocks[index1];
          int[] trimmedLocals = superBlock.getTrimmedLocals();
          int[] stack = superBlock.getStack();
          int num2 = superBlock.getStart() - num1 - 1;
          if (stack.Length == 0)
          {
            int num3 = numArray.Length <= trimmedLocals.Length ? numArray.Length : trimmedLocals.Length;
            int num4 = Math.abs(numArray.Length - trimmedLocals.Length);
            int index2 = 0;
            while (index2 < num3 && numArray[index2] == trimmedLocals[index2])
              ++index2;
            if (index2 == trimmedLocals.Length && num4 == 0)
              this.writeSameFrame(num2);
            else if (index2 == trimmedLocals.Length && num4 <= 3)
              this.writeChopFrame(num4, num2);
            else if (index2 == numArray.Length && num4 <= 3)
              this.writeAppendFrame(trimmedLocals, num4, num2);
            else
              this.writeFullFrame(trimmedLocals, stack, num2);
          }
          else if (stack.Length == 1)
          {
            if (Arrays.equals(numArray, trimmedLocals))
              this.writeSameLocalsOneStackItemFrame(stack, num2);
            else
              this.writeFullFrame(trimmedLocals, stack, num2);
          }
          else
            this.writeFullFrame(trimmedLocals, stack, num2);
          numArray = trimmedLocals;
          num1 = superBlock.getStart();
        }
      }

      [LineNumberTable(new byte[] {176, 176, 197, 222, 124, 184})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void writeSameFrame([In] int obj0)
      {
        if (obj0 <= 63)
        {
          byte[] rawStackMap = this.rawStackMap;
          ClassFileWriter.StackMapTable stackMapTable1 = this;
          int rawStackMapTop = stackMapTable1.rawStackMapTop;
          ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
          int index = rawStackMapTop;
          stackMapTable2.rawStackMapTop = rawStackMapTop + 1;
          int num = (int) (sbyte) obj0;
          rawStackMap[index] = (byte) num;
        }
        else
        {
          byte[] rawStackMap = this.rawStackMap;
          ClassFileWriter.StackMapTable stackMapTable1 = this;
          int rawStackMapTop = stackMapTable1.rawStackMapTop;
          ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
          int index = rawStackMapTop;
          stackMapTable2.rawStackMapTop = rawStackMapTop + 1;
          rawStackMap[index] = (byte) 251;
          this.rawStackMapTop = ClassFileWriter.putInt16(obj0, this.rawStackMap, this.rawStackMapTop);
        }
      }

      [LineNumberTable(new byte[] {176, 228, 127, 3, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void writeChopFrame([In] int obj0, [In] int obj1)
      {
        byte[] rawStackMap = this.rawStackMap;
        ClassFileWriter.StackMapTable stackMapTable1 = this;
        int rawStackMapTop = stackMapTable1.rawStackMapTop;
        ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
        int index = rawStackMapTop;
        stackMapTable2.rawStackMapTop = rawStackMapTop + 1;
        int num = (int) (sbyte) (251 - obj0);
        rawStackMap[index] = (byte) num;
        this.rawStackMapTop = ClassFileWriter.putInt16(obj1, this.rawStackMap, this.rawStackMapTop);
      }

      [LineNumberTable(new byte[] {176, 221, 101, 127, 3, 120, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void writeAppendFrame([In] int[] obj0, [In] int obj1, [In] int obj2)
      {
        int num1 = obj0.Length - obj1;
        byte[] rawStackMap = this.rawStackMap;
        ClassFileWriter.StackMapTable stackMapTable1 = this;
        int rawStackMapTop = stackMapTable1.rawStackMapTop;
        ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
        int index = rawStackMapTop;
        stackMapTable2.rawStackMapTop = rawStackMapTop + 1;
        int num2 = (int) (sbyte) (251 + obj1);
        rawStackMap[index] = (byte) num2;
        this.rawStackMapTop = ClassFileWriter.putInt16(obj2, this.rawStackMap, this.rawStackMapTop);
        this.rawStackMapTop = this.writeTypes(obj0, num1);
      }

      [LineNumberTable(new byte[] {176, 209, 123, 120, 153, 109, 153, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void writeFullFrame([In] int[] obj0, [In] int[] obj1, [In] int obj2)
      {
        byte[] rawStackMap = this.rawStackMap;
        ClassFileWriter.StackMapTable stackMapTable1 = this;
        int rawStackMapTop = stackMapTable1.rawStackMapTop;
        ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
        int index = rawStackMapTop;
        stackMapTable2.rawStackMapTop = rawStackMapTop + 1;
        rawStackMap[index] = byte.MaxValue;
        this.rawStackMapTop = ClassFileWriter.putInt16(obj2, this.rawStackMap, this.rawStackMapTop);
        this.rawStackMapTop = ClassFileWriter.putInt16(obj0.Length, this.rawStackMap, this.rawStackMapTop);
        this.rawStackMapTop = this.writeTypes(obj0);
        this.rawStackMapTop = ClassFileWriter.putInt16(obj1.Length, this.rawStackMap, this.rawStackMapTop);
        this.rawStackMapTop = this.writeTypes(obj1);
      }

      [LineNumberTable(new byte[] {176, 191, 197, 255, 2, 69, 124, 184, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void writeSameLocalsOneStackItemFrame([In] int[] obj0, [In] int obj1)
      {
        if (obj1 <= 63)
        {
          byte[] rawStackMap = this.rawStackMap;
          ClassFileWriter.StackMapTable stackMapTable1 = this;
          int rawStackMapTop = stackMapTable1.rawStackMapTop;
          ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
          int index = rawStackMapTop;
          stackMapTable2.rawStackMapTop = rawStackMapTop + 1;
          int num = (int) (sbyte) (64 + obj1);
          rawStackMap[index] = (byte) num;
        }
        else
        {
          byte[] rawStackMap = this.rawStackMap;
          ClassFileWriter.StackMapTable stackMapTable1 = this;
          int rawStackMapTop = stackMapTable1.rawStackMapTop;
          ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
          int index = rawStackMapTop;
          stackMapTable2.rawStackMapTop = rawStackMapTop + 1;
          rawStackMap[index] = (byte) 247;
          this.rawStackMapTop = ClassFileWriter.putInt16(obj1, this.rawStackMap, this.rawStackMapTop);
        }
        this.writeType(obj0[0]);
      }

      [LineNumberTable(new byte[] {176, 244, 104, 124, 136, 186})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int writeType([In] int obj0)
      {
        int num1 = obj0 & (int) byte.MaxValue;
        byte[] rawStackMap = this.rawStackMap;
        ClassFileWriter.StackMapTable stackMapTable1 = this;
        int rawStackMapTop = stackMapTable1.rawStackMapTop;
        ClassFileWriter.StackMapTable stackMapTable2 = stackMapTable1;
        int index = rawStackMapTop;
        stackMapTable2.rawStackMapTop = rawStackMapTop + 1;
        int num2 = (int) (sbyte) num1;
        rawStackMap[index] = (byte) num2;
        if (num1 == 7 || num1 == 8)
          this.rawStackMapTop = ClassFileWriter.putInt16((int) ((uint) obj0 >> 8), this.rawStackMap, this.rawStackMapTop);
        return this.rawStackMapTop;
      }

      [LineNumberTable(4443)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int writeTypes([In] int[] obj0) => this.writeTypes(obj0, 0);

      [LineNumberTable(new byte[] {176, 237, 103, 47, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int writeTypes([In] int[] obj0, [In] int obj1)
      {
        for (int index = obj1; index < obj0.Length; ++index)
          this.rawStackMapTop = this.writeType(obj0[index]);
        return this.rawStackMapTop;
      }
    }
  }
}
