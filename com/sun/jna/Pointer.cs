// Decompiled with JetBrains decompiler
// Type: com.sun.jna.Pointer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.lang.reflect;
using java.nio;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class Pointer : Object
  {
    internal static int __\u003C\u003ESIZE;
    internal static Pointer __\u003C\u003ENULL;
    protected internal long peer;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {99, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(long offset, byte[] buf, int index, int length) => Native.read(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 152, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(long offset, byte[] buf, int index, int length) => Native.write(this, this.peer, offset, buf, index, length);

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer share(long offset) => this.share(offset, 0L);

    [LineNumberTable(new byte[] {50, 105, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer share(long offset, long sz) => offset == 0L ? this : new Pointer(this.peer + offset);

    [LineNumberTable(new byte[] {58, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(long size) => this.setMemory(0L, size, (byte) 0);

    [LineNumberTable(new byte[] {63, 105, 130, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o) => object.ReferenceEquals(o, (object) this) || o != null && (o is Pointer && ((Pointer) o).peer == this.peer);

    [LineNumberTable(651)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer getPointer(long offset) => Native.getPointer(this.peer + offset);

    [LineNumberTable(707)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(long offset, string encoding) => Native.getString(this, offset, encoding);

    [Signature("(JLjava/lang/Class<*>;Ljava/lang/Object;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {161, 2, 98, 109, 103, 109, 145, 106, 134, 98, 127, 0, 120, 122, 115, 122, 114, 122, 114, 122, 114, 122, 114, 122, 115, 122, 115, 109, 104, 99, 146, 113, 132, 162, 114, 104, 111, 114, 104, 116, 178, 104, 99, 132, 104, 105, 106, 137, 131, 124, 104, 99, 132, 108, 102, 108, 144, 130, 117, 104, 100, 113, 112, 106, 131, 98, 104, 113, 144, 106, 98, 99, 144, 144, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object getValue([In] long obj0, [In] Class obj1, [In] object obj2)
    {
      object obj3 = (object) null;
      if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj1))
      {
        Structure structure = (Structure) obj2;
        if (((Class) ClassLiteral<Structure.ByReference>.Value).isAssignableFrom(obj1))
        {
          structure = Structure.updateStructureByReference(obj1, structure, this.getPointer(obj0));
        }
        else
        {
          structure.useMemory(this, (int) obj0, true);
          structure.read();
        }
        obj3 = (object) structure;
      }
      else if (object.ReferenceEquals((object) obj1, (object) Boolean.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Boolean>.Value))
        obj3 = (object) Function.valueOf(this.getInt(obj0) != 0);
      else if (object.ReferenceEquals((object) obj1, (object) Byte.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Byte>.Value))
        obj3 = (object) Byte.valueOf(this.getByte(obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Short.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Short>.Value))
        obj3 = (object) Short.valueOf(this.getShort(obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Character.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Character>.Value))
        obj3 = (object) Character.valueOf(this.getChar(obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Integer.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Integer>.Value))
        obj3 = (object) Integer.valueOf(this.getInt(obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Long.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Long>.Value))
        obj3 = (object) Long.valueOf(this.getLong(obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Float.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Float>.Value))
        obj3 = (object) Float.valueOf(this.getFloat(obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Double.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Double>.Value))
        obj3 = (object) Double.valueOf(this.getDouble(obj0));
      else if (((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(obj1))
      {
        Pointer pointer1 = this.getPointer(obj0);
        if (pointer1 != null)
        {
          Pointer pointer2 = !(obj2 is Pointer) ? (Pointer) null : (Pointer) obj2;
          obj3 = pointer2 == null || pointer1.peer != pointer2.peer ? (object) pointer1 : (object) pointer2;
        }
      }
      else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<String>.Value))
      {
        Pointer pointer = this.getPointer(obj0);
        obj3 = pointer == null ? (object) (string) null : (object) pointer.getString(0L);
      }
      else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<WString>.Value))
      {
        Pointer pointer = this.getPointer(obj0);
        obj3 = pointer == null ? (object) (WString) null : (object) new WString(pointer.getWideString(0L));
      }
      else if (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj1))
      {
        Pointer pointer = this.getPointer(obj0);
        if (pointer == null)
        {
          obj3 = (object) null;
        }
        else
        {
          Callback cb = (Callback) obj2;
          Pointer functionPointer = CallbackReference.getFunctionPointer(cb);
          if (!pointer.equals((object) functionPointer))
            cb = CallbackReference.getCallback(obj1, pointer);
          obj3 = (object) cb;
        }
      }
      else if (Platform.__\u003C\u003EHAS_BUFFERS && ((Class) ClassLiteral<Buffer>.Value).isAssignableFrom(obj1))
      {
        Pointer pointer1 = this.getPointer(obj0);
        if (pointer1 == null)
        {
          obj3 = (object) null;
        }
        else
        {
          Pointer pointer2 = obj2 != null ? Native.getDirectBufferPointer((Buffer) obj2) : (Pointer) null;
          if (pointer2 == null || !pointer2.equals((object) pointer1))
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException("Can't autogenerate a direct buffer on memory read");
          }
          obj3 = obj2;
        }
      }
      else if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(obj1))
      {
        NativeMapped nativeMapped = (NativeMapped) obj2;
        if (nativeMapped != null)
        {
          object obj4 = this.getValue(obj0, nativeMapped.nativeType(), (object) null);
          obj3 = nativeMapped.fromNative(obj4, new FromNativeContext(obj1));
          if (Object.instancehelper_equals((object) nativeMapped, obj3))
            obj3 = (object) nativeMapped;
        }
        else
        {
          NativeMappedConverter instance = NativeMappedConverter.getInstance(obj1);
          object nativeValue = this.getValue(obj0, instance.nativeType(), (object) null);
          obj3 = instance.fromNative(nativeValue, new FromNativeContext(obj1));
        }
      }
      else if (obj1.isArray())
      {
        obj3 = obj2;
        if (obj3 == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Need an initialized array");
        }
        this.readArray(obj0, obj3, obj1.getComponentType());
      }
      else
      {
        string str = new StringBuilder().append("Reading \"").append((object) obj1).append("\" from memory is not supported").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return obj3;
    }

    [Signature("(JLjava/lang/Object;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {163, 20, 122, 125, 122, 126, 122, 125, 122, 125, 122, 125, 122, 126, 122, 127, 3, 122, 127, 3, 109, 114, 109, 114, 109, 114, 109, 103, 109, 115, 99, 200, 106, 134, 114, 119, 116, 108, 102, 104, 114, 103, 103, 116, 106, 144, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setValue([In] long obj0, [In] object obj1, [In] Class obj2)
    {
      if (object.ReferenceEquals((object) obj2, (object) Boolean.TYPE) || object.ReferenceEquals((object) obj2, (object) ClassLiteral<Boolean>.Value))
        this.setInt(obj0, !((Boolean) Boolean.TRUE).equals(obj1) ? 0 : -1);
      else if (object.ReferenceEquals((object) obj2, (object) Byte.TYPE) || object.ReferenceEquals((object) obj2, (object) ClassLiteral<Byte>.Value))
        this.setByte(obj0, obj1 != null ? ((Byte) obj1).byteValue() : (byte) 0);
      else if (object.ReferenceEquals((object) obj2, (object) Short.TYPE) || object.ReferenceEquals((object) obj2, (object) ClassLiteral<Short>.Value))
        this.setShort(obj0, obj1 != null ? ((Short) obj1).shortValue() : (short) 0);
      else if (object.ReferenceEquals((object) obj2, (object) Character.TYPE) || object.ReferenceEquals((object) obj2, (object) ClassLiteral<Character>.Value))
        this.setChar(obj0, obj1 != null ? ((Character) obj1).charValue() : char.MinValue);
      else if (object.ReferenceEquals((object) obj2, (object) Integer.TYPE) || object.ReferenceEquals((object) obj2, (object) ClassLiteral<Integer>.Value))
        this.setInt(obj0, obj1 != null ? ((Integer) obj1).intValue() : 0);
      else if (object.ReferenceEquals((object) obj2, (object) Long.TYPE) || object.ReferenceEquals((object) obj2, (object) ClassLiteral<Long>.Value))
        this.setLong(obj0, obj1 != null ? ((Long) obj1).longValue() : 0L);
      else if (object.ReferenceEquals((object) obj2, (object) Float.TYPE) || object.ReferenceEquals((object) obj2, (object) ClassLiteral<Float>.Value))
        this.setFloat(obj0, obj1 != null ? ((Float) obj1).floatValue() : 0.0f);
      else if (object.ReferenceEquals((object) obj2, (object) Double.TYPE) || object.ReferenceEquals((object) obj2, (object) ClassLiteral<Double>.Value))
        this.setDouble(obj0, obj1 != null ? ((Double) obj1).doubleValue() : 0.0);
      else if (object.ReferenceEquals((object) obj2, (object) ClassLiteral<Pointer>.Value))
        this.setPointer(obj0, (Pointer) obj1);
      else if (object.ReferenceEquals((object) obj2, (object) ClassLiteral<String>.Value))
        this.setPointer(obj0, (Pointer) obj1);
      else if (object.ReferenceEquals((object) obj2, (object) ClassLiteral<WString>.Value))
        this.setPointer(obj0, (Pointer) obj1);
      else if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj2))
      {
        Structure structure = (Structure) obj1;
        if (((Class) ClassLiteral<Structure.ByReference>.Value).isAssignableFrom(obj2))
        {
          this.setPointer(obj0, structure?.getPointer());
          structure?.autoWrite();
        }
        else
        {
          structure.useMemory(this, (int) obj0, true);
          structure.write();
        }
      }
      else if (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj2))
        this.setPointer(obj0, CallbackReference.getFunctionPointer((Callback) obj1));
      else if (Platform.__\u003C\u003EHAS_BUFFERS && ((Class) ClassLiteral<Buffer>.Value).isAssignableFrom(obj2))
      {
        Pointer pointer = obj1 != null ? Native.getDirectBufferPointer((Buffer) obj1) : (Pointer) null;
        this.setPointer(obj0, pointer);
      }
      else if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(obj2))
      {
        NativeMappedConverter instance = NativeMappedConverter.getInstance(obj2);
        Class @class = instance.nativeType();
        this.setValue(obj0, instance.toNative(obj1, new ToNativeContext()), @class);
      }
      else if (obj2.isArray())
      {
        this.writeArray(obj0, obj1, obj2.getComponentType());
      }
      else
      {
        string str = new StringBuilder().append("Writing ").append((object) obj2).append(" to memory is not supported").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {162, 88, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] getByteArray(long offset, int arraySize)
    {
      byte[] buf = new byte[arraySize];
      this.read(offset, buf, 0, arraySize);
      return buf;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => (int) ((long) ((ulong) this.peer >> 32) + (this.peer & -1L));

    [LineNumberTable(new byte[] {37, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pointer(long peer)
    {
      Pointer pointer = this;
      this.peer = peer;
    }

    [LineNumberTable(new byte[] {163, 202, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInt(long offset, int value) => Native.setInt(this, this.peer, offset, value);

    [LineNumberTable(685)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getWideString(long offset) => Native.getWideString(this, this.peer, offset);

    [LineNumberTable(811)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getStringArray(long offset, string encoding) => this.getStringArray(offset, -1, encoding);

    [LineNumberTable(838)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getWideStringArray(long offset) => this.getWideStringArray(offset, -1);

    [LineNumberTable(new byte[] {158, 140, 67, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMemory(long offset, long length, byte value)
    {
      int num = (int) (sbyte) value;
      Native.setMemory(this, this.peer, offset, length, (byte) num);
    }

    [LineNumberTable(new byte[] {164, 17, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPointer(long offset, Pointer value) => Native.setPointer(this, this.peer, offset, value == null ? 0L : value.peer);

    [LineNumberTable(589)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(long offset) => Native.getInt(this, this.peer, offset);

    [LineNumberTable(553)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte getByte(long offset) => Native.getByte(this, this.peer, offset);

    [LineNumberTable(577)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short getShort(long offset) => Native.getShort(this, this.peer, offset);

    [LineNumberTable(565)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char getChar(long offset) => Native.getChar(this, this.peer, offset);

    [LineNumberTable(601)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getLong(long offset) => Native.getLong(this, this.peer, offset);

    [LineNumberTable(625)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFloat(long offset) => Native.getFloat(this, this.peer, offset);

    [LineNumberTable(637)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double getDouble(long offset) => Native.getDouble(this, this.peer, offset);

    [LineNumberTable(696)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(long offset) => this.getString(offset, Native.getDefaultStringEncoding());

    [Signature("(JLjava/lang/Object;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {161, 98, 98, 103, 130, 109, 153, 109, 153, 109, 153, 109, 153, 109, 153, 109, 153, 109, 153, 109, 153, 112, 108, 109, 106, 105, 50, 168, 133, 101, 100, 111, 103, 167, 107, 135, 107, 105, 134, 171, 123, 233, 57, 232, 75, 101, 112, 109, 104, 122, 106, 124, 25, 200, 130, 223, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readArray([In] long obj0, [In] object obj1, [In] Class obj2)
    {
      int length1 = Array.getLength(obj1);
      object obj = obj1;
      if (object.ReferenceEquals((object) obj2, (object) Byte.TYPE))
        this.read(obj0, (byte[]) obj, 0, length1);
      else if (object.ReferenceEquals((object) obj2, (object) Short.TYPE))
        this.read(obj0, (short[]) obj, 0, length1);
      else if (object.ReferenceEquals((object) obj2, (object) Character.TYPE))
        this.read(obj0, (char[]) obj, 0, length1);
      else if (object.ReferenceEquals((object) obj2, (object) Integer.TYPE))
        this.read(obj0, (int[]) obj, 0, length1);
      else if (object.ReferenceEquals((object) obj2, (object) Long.TYPE))
        this.read(obj0, (long[]) obj, 0, length1);
      else if (object.ReferenceEquals((object) obj2, (object) Float.TYPE))
        this.read(obj0, (float[]) obj, 0, length1);
      else if (object.ReferenceEquals((object) obj2, (object) Double.TYPE))
        this.read(obj0, (double[]) obj, 0, length1);
      else if (((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(obj2))
        this.read(obj0, (Pointer[]) obj, 0, length1);
      else if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj2))
      {
        Structure[] structureArray = (Structure[]) obj;
        if (((Class) ClassLiteral<Structure.ByReference>.Value).isAssignableFrom(obj2))
        {
          Pointer[] pointerArray = this.getPointerArray(obj0, structureArray.Length);
          for (int index = 0; index < structureArray.Length; ++index)
            structureArray[index] = Structure.updateStructureByReference(obj2, structureArray[index], pointerArray[index]);
        }
        else
        {
          Structure structure = structureArray[0];
          if (structure == null)
          {
            structure = Structure.newInstance(obj2, this.share(obj0));
            structure.conditionalAutoRead();
            structureArray[0] = structure;
          }
          else
          {
            structure.useMemory(this, (int) obj0, true);
            structure.read();
          }
          Structure[] array = structure.toArray(structureArray.Length);
          for (int index = 1; index < structureArray.Length; ++index)
          {
            if (structureArray[index] == null)
            {
              structureArray[index] = array[index];
            }
            else
            {
              structureArray[index].useMemory(this, (int) (obj0 + (long) (index * structureArray[index].size())), true);
              structureArray[index].read();
            }
          }
        }
      }
      else if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(obj2))
      {
        NativeMapped[] nativeMappedArray = (NativeMapped[]) obj;
        NativeMappedConverter instance = NativeMappedConverter.getInstance(obj2);
        int nativeSize = Native.getNativeSize(Object.instancehelper_getClass(obj), obj);
        int length2 = nativeMappedArray.Length;
        int num = length2 != -1 ? nativeSize / length2 : -nativeSize;
        for (int index = 0; index < nativeMappedArray.Length; ++index)
        {
          object nativeValue = this.getValue(obj0 + (long) (num * index), instance.nativeType(), (object) nativeMappedArray[index]);
          nativeMappedArray[index] = (NativeMapped) instance.fromNative(nativeValue, new FromNativeContext(obj2));
        }
      }
      else
      {
        string str = new StringBuilder().append("Reading array of ").append((object) obj2).append(" from memory not supported").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {112, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(long offset, short[] buf, int index, int length) => Native.read(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {125, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(long offset, char[] buf, int index, int length) => Native.read(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 74, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(long offset, int[] buf, int index, int length) => Native.read(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 87, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(long offset, long[] buf, int index, int length) => Native.read(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 100, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(long offset, float[] buf, int index, int length) => Native.read(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(long offset, double[] buf, int index, int length) => Native.read(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 126, 103, 113, 134, 116, 230, 59, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(long offset, Pointer[] buf, int index, int length)
    {
      for (int index1 = 0; index1 < length; ++index1)
      {
        Pointer pointer1 = this.getPointer(offset + (long) (index1 * Pointer.__\u003C\u003ESIZE));
        Pointer pointer2 = buf[index1 + index];
        if (pointer2 == null || pointer1 == null || pointer1.peer != pointer2.peer)
          buf[index1 + index] = pointer1;
      }
    }

    [LineNumberTable(new byte[] {162, 164, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer[] getPointerArray(long offset, int arraySize)
    {
      Pointer[] buf = new Pointer[arraySize];
      this.read(offset, buf, 0, arraySize);
      return buf;
    }

    [LineNumberTable(new byte[] {162, 239, 134, 98, 103, 107, 98, 104, 140, 106, 114, 105, 100, 104, 139, 101, 98, 110, 140, 106, 114, 105, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getStringArray(long offset, int length, string encoding)
    {
      ArrayList arrayList = new ArrayList();
      int num1 = 0;
      if (length != -1)
      {
        Pointer pointer = this.getPointer(offset + (long) num1);
        int num2 = 0;
        while (true)
        {
          do
          {
            int num3 = num2;
            ++num2;
            int num4 = length;
            if (num3 < num4)
            {
              string str = pointer != null ? (!String.instancehelper_equals("--WIDE-STRING--", (object) encoding) ? pointer.getString(0L, encoding) : pointer.getWideString(0L)) : (string) null;
              ((List) arrayList).add((object) str);
            }
            else
              goto label_7;
          }
          while (num2 >= length);
          num1 += Pointer.__\u003C\u003ESIZE;
          pointer = this.getPointer(offset + (long) num1);
        }
      }
      else
      {
        Pointer pointer;
        for (; (pointer = this.getPointer(offset + (long) num1)) != null; num1 += Pointer.__\u003C\u003ESIZE)
        {
          string str = pointer != null ? (!String.instancehelper_equals("--WIDE-STRING--", (object) encoding) ? pointer.getString(0L, encoding) : pointer.getWideString(0L)) : (string) null;
          ((List) arrayList).add((object) str);
        }
      }
label_7:
      return (string[]) ((List) arrayList).toArray((object[]) new string[((List) arrayList).size()]);
    }

    [Obsolete]
    [LineNumberTable(854)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getStringArray(long offset, int length, bool wide)
    {
      int num = wide ? 1 : 0;
      return this.getStringArray(offset, length, num == 0 ? Native.getDefaultStringEncoding() : "--WIDE-STRING--");
    }

    [LineNumberTable(842)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getWideStringArray(long offset, int length) => this.getStringArray(offset, length, "--WIDE-STRING--");

    [LineNumberTable(new byte[] {158, 137, 99, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setByte(long offset, byte value)
    {
      int num = (int) (sbyte) value;
      Native.setByte(this, this.peer, offset, (byte) num);
    }

    [LineNumberTable(new byte[] {158, 134, 130, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setShort(long offset, short value)
    {
      int num = (int) value;
      Native.setShort(this, this.peer, offset, (short) num);
    }

    [LineNumberTable(new byte[] {158, 131, 162, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setChar(long offset, char value)
    {
      int num = (int) value;
      Native.setChar(this, this.peer, offset, (char) num);
    }

    [LineNumberTable(new byte[] {163, 215, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLong(long offset, long value) => Native.setLong(this, this.peer, offset, value);

    [LineNumberTable(new byte[] {163, 245, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFloat(long offset, float value) => Native.setFloat(this, this.peer, offset, value);

    [LineNumberTable(new byte[] {164, 2, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDouble(long offset, double value) => Native.setDouble(this, this.peer, offset, value);

    [Signature("(JLjava/lang/Object;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {163, 73, 109, 108, 107, 114, 108, 107, 114, 108, 107, 114, 108, 107, 114, 109, 109, 114, 109, 109, 114, 109, 109, 114, 109, 109, 117, 109, 112, 106, 106, 103, 136, 111, 234, 59, 232, 72, 109, 101, 102, 100, 111, 136, 139, 103, 108, 106, 103, 140, 157, 234, 58, 232, 73, 117, 109, 104, 105, 122, 106, 115, 18, 200, 98, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeArray([In] long obj0, [In] object obj1, [In] Class obj2)
    {
      if (object.ReferenceEquals((object) obj2, (object) Byte.TYPE))
      {
        byte[] buf = (byte[]) obj1;
        this.write(obj0, buf, 0, buf.Length);
      }
      else if (object.ReferenceEquals((object) obj2, (object) Short.TYPE))
      {
        short[] buf = (short[]) obj1;
        this.write(obj0, buf, 0, buf.Length);
      }
      else if (object.ReferenceEquals((object) obj2, (object) Character.TYPE))
      {
        char[] buf = (char[]) obj1;
        this.write(obj0, buf, 0, buf.Length);
      }
      else if (object.ReferenceEquals((object) obj2, (object) Integer.TYPE))
      {
        int[] buf = (int[]) obj1;
        this.write(obj0, buf, 0, buf.Length);
      }
      else if (object.ReferenceEquals((object) obj2, (object) Long.TYPE))
      {
        long[] buf = (long[]) obj1;
        this.write(obj0, buf, 0, buf.Length);
      }
      else if (object.ReferenceEquals((object) obj2, (object) Float.TYPE))
      {
        float[] buf = (float[]) obj1;
        this.write(obj0, buf, 0, buf.Length);
      }
      else if (object.ReferenceEquals((object) obj2, (object) Double.TYPE))
      {
        double[] buf = (double[]) obj1;
        this.write(obj0, buf, 0, buf.Length);
      }
      else if (((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(obj2))
      {
        Pointer[] buf = (Pointer[]) obj1;
        this.write(obj0, buf, 0, buf.Length);
      }
      else if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj2))
      {
        Structure[] structureArray = (Structure[]) obj1;
        if (((Class) ClassLiteral<Structure.ByReference>.Value).isAssignableFrom(obj2))
        {
          Pointer[] buf = new Pointer[structureArray.Length];
          for (int index = 0; index < structureArray.Length; ++index)
          {
            if (structureArray[index] == null)
            {
              buf[index] = (Pointer) null;
            }
            else
            {
              buf[index] = structureArray[index].getPointer();
              structureArray[index].write();
            }
          }
          this.write(obj0, buf, 0, buf.Length);
        }
        else
        {
          Structure structure = structureArray[0];
          if (structure == null)
          {
            structure = Structure.newInstance(obj2, this.share(obj0));
            structureArray[0] = structure;
          }
          else
            structure.useMemory(this, (int) obj0, true);
          structure.write();
          Structure[] array = structure.toArray(structureArray.Length);
          for (int index = 1; index < structureArray.Length; ++index)
          {
            if (structureArray[index] == null)
              structureArray[index] = array[index];
            else
              structureArray[index].useMemory(this, (int) (obj0 + (long) (index * structureArray[index].size())), true);
            structureArray[index].write();
          }
        }
      }
      else if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(obj2))
      {
        NativeMapped[] nativeMappedArray = (NativeMapped[]) obj1;
        NativeMappedConverter instance = NativeMappedConverter.getInstance(obj2);
        Class @class = instance.nativeType();
        int nativeSize = Native.getNativeSize(Object.instancehelper_getClass(obj1), obj1);
        int length = nativeMappedArray.Length;
        int num = length != -1 ? nativeSize / length : -nativeSize;
        for (int index = 0; index < nativeMappedArray.Length; ++index)
        {
          object native = instance.toNative((object) nativeMappedArray[index], new ToNativeContext());
          this.setValue(obj0 + (long) (index * num), native, @class);
        }
      }
      else
      {
        string str = new StringBuilder().append("Writing array of ").append((object) obj2).append(" to memory not supported").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 166, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(long offset, short[] buf, int index, int length) => Native.write(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 180, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(long offset, char[] buf, int index, int length) => Native.write(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 194, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(long offset, int[] buf, int index, int length) => Native.write(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 208, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(long offset, long[] buf, int index, int length) => Native.write(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 222, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(long offset, float[] buf, int index, int length) => Native.write(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 236, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(long offset, double[] buf, int index, int length) => Native.write(this, this.peer, offset, buf, index, length);

    [LineNumberTable(new byte[] {160, 247, 103, 53, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(long bOff, Pointer[] buf, int index, int length)
    {
      for (int index1 = 0; index1 < length; ++index1)
        this.setPointer(bOff + (long) (index1 * Pointer.__\u003C\u003ESIZE), buf[index + index1]);
    }

    [LineNumberTable(new byte[] {164, 52, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWideString(long offset, string value) => Native.setWideString(this, this.peer, offset, value);

    [LineNumberTable(new byte[] {164, 77, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setString(long offset, string value) => this.setString(offset, value, Native.getDefaultStringEncoding());

    [LineNumberTable(new byte[] {164, 90, 104, 107, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setString(long offset, string value, string encoding)
    {
      byte[] bytes = Native.getBytes(value, encoding);
      this.write(offset, bytes, 0, bytes.Length);
      this.setByte(offset + (long) bytes.Length, (byte) 0);
    }

    [Modifiers]
    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pointer createConstant(long peer) => (Pointer) new Pointer.Opaque(peer, (Pointer.\u0031) null);

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pointer createConstant(int peer) => (Pointer) new Pointer.Opaque((long) peer & -1L, (Pointer.\u0031) null);

    [LineNumberTable(new byte[] {31, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Pointer()
    {
    }

    [LineNumberTable(136)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long indexOf(long offset, byte value)
    {
      int num = (int) (sbyte) value;
      return Native.indexOf(this, this.peer, offset, (byte) num);
    }

    [LineNumberTable(613)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NativeLong getNativeLong(long offset)
    {
      NativeLong.__\u003Cclinit\u003E();
      return new NativeLong(NativeLong.__\u003C\u003ESIZE != 8 ? (long) this.getInt(offset) : this.getLong(offset));
    }

    [LineNumberTable(663)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ByteBuffer getByteBuffer(long offset, long length) => Native.getDirectByteBuffer(this, this.peer, offset, length).order(ByteOrder.nativeOrder());

    [Obsolete]
    [LineNumberTable(680)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(long offset, bool wide) => wide ? this.getWideString(offset) : this.getString(offset);

    [LineNumberTable(new byte[] {162, 97, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char[] getCharArray(long offset, int arraySize)
    {
      char[] buf = new char[arraySize];
      this.read(offset, buf, 0, arraySize);
      return buf;
    }

    [LineNumberTable(new byte[] {162, 106, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short[] getShortArray(long offset, int arraySize)
    {
      short[] buf = new short[arraySize];
      this.read(offset, buf, 0, arraySize);
      return buf;
    }

    [LineNumberTable(new byte[] {162, 115, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int[] getIntArray(long offset, int arraySize)
    {
      int[] buf = new int[arraySize];
      this.read(offset, buf, 0, arraySize);
      return buf;
    }

    [LineNumberTable(new byte[] {162, 124, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long[] getLongArray(long offset, int arraySize)
    {
      long[] buf = new long[arraySize];
      this.read(offset, buf, 0, arraySize);
      return buf;
    }

    [LineNumberTable(new byte[] {162, 133, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] getFloatArray(long offset, int arraySize)
    {
      float[] buf = new float[arraySize];
      this.read(offset, buf, 0, arraySize);
      return buf;
    }

    [LineNumberTable(new byte[] {162, 142, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double[] getDoubleArray(long offset, int arraySize)
    {
      double[] buf = new double[arraySize];
      this.read(offset, buf, 0, arraySize);
      return buf;
    }

    [LineNumberTable(new byte[] {162, 151, 102, 98, 104, 99, 104, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer[] getPointerArray(long offset)
    {
      ArrayList arrayList = new ArrayList();
      int num = 0;
      for (Pointer pointer = this.getPointer(offset); pointer != null; pointer = this.getPointer(offset + (long) num))
      {
        ((List) arrayList).add((object) pointer);
        num += Pointer.__\u003C\u003ESIZE;
      }
      return (Pointer[]) ((List) arrayList).toArray((object[]) new Pointer[((List) arrayList).size()]);
    }

    [LineNumberTable(803)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getStringArray(long offset) => this.getStringArray(offset, -1, Native.getDefaultStringEncoding());

    [LineNumberTable(821)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getStringArray(long offset, int length) => this.getStringArray(offset, length, Native.getDefaultStringEncoding());

    [Obsolete]
    [LineNumberTable(834)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getStringArray(long offset, bool wide)
    {
      int num = wide ? 1 : 0;
      return this.getStringArray(offset, -1, num != 0);
    }

    [LineNumberTable(new byte[] {163, 228, 104, 143, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setNativeLong(long offset, NativeLong value)
    {
      if (NativeLong.__\u003C\u003ESIZE == 8)
        this.setLong(offset, value.longValue());
      else
        this.setInt(offset, value.intValue());
    }

    [Obsolete]
    [LineNumberTable(new byte[] {158, 105, 98, 99, 170, 136})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setString(long offset, string value, bool wide)
    {
      if (wide)
        this.setWideString(offset, value);
      else
        this.setString(offset, value);
    }

    [LineNumberTable(new byte[] {164, 64, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setString(long offset, WString value) => this.setWideString(offset, value?.toString());

    [LineNumberTable(new byte[] {164, 97, 98, 134, 124, 103, 139, 137, 108, 121, 105, 107, 114, 117, 235, 56, 233, 74, 124, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string dump(long offset, int size)
    {
      StringWriter stringWriter = new StringWriter(String.instancehelper_length("memory dump") + 2 + size * 2 + size / 4 * 4);
      PrintWriter printWriter = new PrintWriter((Writer) stringWriter);
      printWriter.println("memory dump");
      for (int index = 0; index < size; ++index)
      {
        int num1 = (int) (sbyte) this.getByte(offset + (long) index);
        int num2 = index;
        int num3 = 4;
        if ((num3 != -1 ? num2 % num3 : 0) == 0)
          printWriter.print("[");
        if (num1 >= 0 && num1 < 16)
          printWriter.print("0");
        printWriter.print(Integer.toHexString(num1 & (int) byte.MaxValue));
        int num4 = index;
        int num5 = 4;
        if ((num5 != -1 ? num4 % num5 : 0) == 3 && index < size - 1)
          printWriter.println("]");
      }
      if (stringWriter.getBuffer().charAt(stringWriter.getBuffer().length() - 2) != ']')
        printWriter.println("]");
      return stringWriter.toString();
    }

    [LineNumberTable(1260)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("native@0x").append(Long.toHexString(this.peer)).toString();

    [LineNumberTable(1265)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long nativeValue(Pointer p) => p == null ? 0L : p.peer;

    [LineNumberTable(new byte[] {164, 132, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void nativeValue(Pointer p, long value) => p.peer = value;

    [LineNumberTable(new byte[] {159, 129, 141, 109, 240, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Pointer()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.Pointer"))
        return;
      if ((Pointer.__\u003C\u003ESIZE = Native.__\u003C\u003EPOINTER_SIZE) == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new Error("Native library not initialized");
      }
      Pointer.__\u003C\u003ENULL = (Pointer) null;
    }

    [Modifiers]
    public static int SIZE
    {
      [HideFromJava] get => Pointer.__\u003C\u003ESIZE;
    }

    [Modifiers]
    public static Pointer NULL
    {
      [HideFromJava] get => Pointer.__\u003C\u003ENULL;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      \u0031() => throw null;
    }

    [InnerClass]
    internal class Opaque : Pointer
    {
      [Modifiers]
      private string MSG;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(1274)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Opaque([In] long obj0, [In] Pointer.\u0031 obj1)
        : this(obj0)
      {
      }

      [LineNumberTable(new byte[] {164, 137, 105, 63, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Opaque([In] long obj0)
        : base(obj0)
      {
        Pointer.Opaque opaque = this;
        this.MSG = new StringBuilder().append("This pointer is opaque: ").append((object) this).toString();
      }

      [LineNumberTable(1279)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Pointer share([In] long obj0, [In] long obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1283)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void clear([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1287)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override long indexOf([In] long obj0, [In] byte obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1291)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read([In] long obj0, [In] byte[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1295)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read([In] long obj0, [In] char[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1299)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read([In] long obj0, [In] short[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1303)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read([In] long obj0, [In] int[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1307)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read([In] long obj0, [In] long[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1311)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read([In] long obj0, [In] float[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1315)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read([In] long obj0, [In] double[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1319)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read([In] long obj0, [In] Pointer[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1323)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write([In] long obj0, [In] byte[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1327)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write([In] long obj0, [In] char[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1331)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write([In] long obj0, [In] short[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1335)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write([In] long obj0, [In] int[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1339)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write([In] long obj0, [In] long[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1343)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write([In] long obj0, [In] float[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1347)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write([In] long obj0, [In] double[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1351)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write([In] long obj0, [In] Pointer[] obj1, [In] int obj2, [In] int obj3)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1355)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override ByteBuffer getByteBuffer([In] long obj0, [In] long obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1359)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte getByte([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1363)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override char getChar([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1367)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override short getShort([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1371)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override int getInt([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1375)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override long getLong([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1379)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getFloat([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1383)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override double getDouble([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1387)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Pointer getPointer([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1391)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string getString([In] long obj0, [In] string obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1395)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string getWideString([In] long obj0)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1399)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setByte([In] long obj0, [In] byte obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1403)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setChar([In] long obj0, [In] char obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1407)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setShort([In] long obj0, [In] short obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1411)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setInt([In] long obj0, [In] int obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1415)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setLong([In] long obj0, [In] long obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1419)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setFloat([In] long obj0, [In] float obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1423)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setDouble([In] long obj0, [In] double obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1427)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setPointer([In] long obj0, [In] Pointer obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1431)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setString([In] long obj0, [In] string obj1, [In] string obj2)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1435)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setWideString([In] long obj0, [In] string obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1439)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setMemory([In] long obj0, [In] long obj1, [In] byte obj2)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1443)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string dump([In] long obj0, [In] int obj1)
      {
        string msg = this.MSG;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(msg);
      }

      [LineNumberTable(1447)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string toString() => new StringBuilder().append("const@0x").append(Long.toHexString(this.peer)).toString();

      [HideFromJava]
      static Opaque() => Pointer.__\u003Cclinit\u003E();
    }
  }
}
