// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.UBJsonReader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.util.serialization
{
  public class UBJsonReader : Object, BaseJsonReader
  {
    public bool oldFormat;

    [LineNumberTable(new byte[] {159, 161, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UBJsonReader()
    {
      UBJsonReader ubJsonReader = this;
      this.oldFormat = true;
    }

    [LineNumberTable(new byte[] {159, 170, 130, 103, 213, 102, 38, 230, 60, 100, 98, 141, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue parse(InputStream input)
    {
      DataInputStream din = (DataInputStream) null;
      JsonValue jsonValue;
      IOException ioException1;
      // ISSUE: fault handler
      try
      {
        din = new DataInputStream(input);
        jsonValue = this.parse(din);
        goto label_5;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      __fault
      {
        Streams.close((Closeable) din);
      }
      IOException ioException2 = ioException1;
      // ISSUE: fault handler
      try
      {
        IOException ioException3 = ioException2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException((Exception) ioException3);
      }
      __fault
      {
        Streams.close((Closeable) din);
      }
label_5:
      Streams.close((Closeable) din);
      return jsonValue;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {0, 147, 102, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue parse(DataInputStream din)
    {
      try
      {
        return this.parse(din, din.readByte());
      }
      finally
      {
        Streams.close((Closeable) din);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 128, 99, 101, 104, 101, 104, 101, 107, 101, 103, 101, 103, 101, 110, 101, 110, 101, 127, 0, 101, 126, 101, 109, 101, 108, 101, 110, 101, 109, 106, 110, 106, 105, 101, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual JsonValue parse(DataInputStream din, byte type)
    {
      int num = (int) (sbyte) type;
      switch (num)
      {
        case 65:
        case 97:
          return this.parseData(din, (byte) num);
        case 66:
          return new JsonValue((long) this.readUChar(din));
        case 67:
          return new JsonValue((long) din.readChar());
        case 68:
          return new JsonValue(din.readDouble());
        case 70:
          return new JsonValue(false);
        case 73:
          return new JsonValue(!this.oldFormat ? (long) din.readShort() : (long) din.readInt());
        case 76:
          return new JsonValue(din.readLong());
        case 83:
        case 115:
          return new JsonValue(this.parseString(din, (byte) num));
        case 84:
          return new JsonValue(true);
        case 85:
          return new JsonValue((long) this.readUChar(din));
        case 90:
          return new JsonValue(JsonValue.ValueType.__\u003C\u003EnullValue);
        case 91:
          return this.parseArray(din);
        case 100:
          return new JsonValue((double) din.readFloat());
        case 105:
          return new JsonValue(!this.oldFormat ? (long) (sbyte) din.readByte() : (long) din.readShort());
        case 108:
          return new JsonValue((long) din.readInt());
        case 123:
          return this.parseObject(din);
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Unrecognized data type");
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {44, 107, 104, 98, 101, 104, 136, 99, 101, 107, 117, 103, 142, 99, 100, 116, 106, 104, 100, 105, 105, 144, 104, 135, 100, 114, 110, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual JsonValue parseArray(DataInputStream din)
    {
      JsonValue jsonValue1 = new JsonValue(JsonValue.ValueType.__\u003C\u003Earray);
      int num1 = (int) (sbyte) din.readByte();
      int num2 = 0;
      if (num1 == 36)
      {
        num2 = (int) (sbyte) din.readByte();
        num1 = (int) (sbyte) din.readByte();
      }
      long num3 = -1;
      if (num1 == 35)
      {
        num3 = this.parseSize(din, false, -1L);
        if (num3 < 0L)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Unrecognized data type");
        }
        if (num3 == 0L)
          return jsonValue1;
        num1 = num2 != 0 ? num2 : (int) (sbyte) din.readByte();
      }
      JsonValue jsonValue2 = (JsonValue) null;
      long num4 = 0;
      for (; ((FilterInputStream) din).available() > 0 && num1 != 93; num1 = num2 != 0 ? num2 : (int) (sbyte) din.readByte())
      {
        JsonValue jsonValue3 = this.parse(din, (byte) num1);
        jsonValue3.parent = jsonValue1;
        if (jsonValue2 != null)
        {
          jsonValue3.prev = jsonValue2;
          jsonValue2.next = jsonValue3;
          ++jsonValue1.size;
        }
        else
        {
          jsonValue1.child = jsonValue3;
          jsonValue1.size = 1;
        }
        jsonValue2 = jsonValue3;
        if (num3 > 0L && ++num4 >= num3)
          break;
      }
      return jsonValue1;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {79, 107, 104, 98, 101, 104, 136, 99, 101, 107, 117, 103, 136, 99, 100, 116, 107, 118, 105, 104, 100, 105, 105, 144, 104, 135, 100, 114, 104, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual JsonValue parseObject(DataInputStream din)
    {
      JsonValue jsonValue1 = new JsonValue(JsonValue.ValueType.__\u003C\u003Eobject);
      int num1 = (int) (sbyte) din.readByte();
      int num2 = 0;
      if (num1 == 36)
      {
        num2 = (int) (sbyte) din.readByte();
        num1 = (int) (sbyte) din.readByte();
      }
      long num3 = -1;
      if (num1 == 35)
      {
        num3 = this.parseSize(din, false, -1L);
        if (num3 < 0L)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Unrecognized data type");
        }
        if (num3 == 0L)
          return jsonValue1;
        num1 = (int) (sbyte) din.readByte();
      }
      JsonValue jsonValue2 = (JsonValue) null;
      long num4 = 0;
      for (; ((FilterInputStream) din).available() > 0 && num1 != 125; num1 = (int) (sbyte) din.readByte())
      {
        string name = this.parseString(din, true, (byte) num1);
        JsonValue jsonValue3 = this.parse(din, num2 != 0 ? (byte) num2 : din.readByte());
        jsonValue3.setName(name);
        jsonValue3.parent = jsonValue1;
        if (jsonValue2 != null)
        {
          jsonValue3.prev = jsonValue2;
          jsonValue2.next = jsonValue3;
          ++jsonValue1.size;
        }
        else
        {
          jsonValue1.child = jsonValue3;
          jsonValue1.size = 1;
        }
        jsonValue2 = jsonValue3;
        if (num3 > 0L && ++num4 >= num3)
          break;
      }
      return jsonValue1;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(223)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual short readUChar(DataInputStream din) => (short) ((int) (short) (sbyte) din.readByte() & (int) byte.MaxValue);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(188)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string parseString(DataInputStream din, byte type)
    {
      int num = (int) (sbyte) type;
      return this.parseString(din, false, (byte) num);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 100, 67, 104, 119, 107, 99, 105, 106, 104, 100, 105, 144, 104, 135, 228, 54, 236, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual JsonValue parseData(DataInputStream din, byte blockType)
    {
      int num1 = (int) (sbyte) blockType;
      int num2 = (int) (sbyte) din.readByte();
      long num3 = num1 != 65 ? (long) this.readUChar(din) : this.readUInt(din);
      JsonValue jsonValue1 = new JsonValue(JsonValue.ValueType.__\u003C\u003Earray);
      JsonValue jsonValue2 = (JsonValue) null;
      for (long index = 0; index < num3; ++index)
      {
        JsonValue jsonValue3 = this.parse(din, (byte) num2);
        jsonValue3.parent = jsonValue1;
        if (jsonValue2 != null)
        {
          jsonValue2.next = jsonValue3;
          ++jsonValue1.size;
        }
        else
        {
          jsonValue1.child = jsonValue3;
          jsonValue1.size = 1;
        }
        jsonValue2 = jsonValue3;
      }
      return jsonValue1;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(203)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual long parseSize(
      DataInputStream din,
      bool useIntOnError,
      long defaultValue)
    {
      int num = useIntOnError ? 1 : 0;
      return this.parseSize(din, din.readByte(), num != 0, defaultValue);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 94, 69, 99, 101, 109, 101, 107, 111, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string parseString(DataInputStream din, bool sOptional, byte type)
    {
      int num1 = (int) (sbyte) type;
      int num2 = sOptional ? 1 : 0;
      long size = -1;
      switch (num1)
      {
        case 83:
          size = this.parseSize(din, true, -1L);
          break;
        case 115:
          size = (long) this.readUChar(din);
          break;
        default:
          if (num2 != 0)
          {
            size = this.parseSize(din, (byte) num1, false, -1L);
            break;
          }
          break;
      }
      if (size < 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Unrecognized data type, string expected");
      }
      return size > 0L ? this.readString(din, size) : "";
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual long readUInt(DataInputStream din) => (long) din.readInt();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 90, 69, 110, 110, 109, 108, 99, 109, 117, 116, 114, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual long parseSize(
      DataInputStream din,
      byte type,
      bool useIntOnError,
      long defaultValue)
    {
      int num1 = (int) (sbyte) type;
      int num2 = useIntOnError ? 1 : 0;
      switch (num1)
      {
        case 73:
          return (long) this.readUShort(din);
        case 76:
          return din.readLong();
        case 105:
          return (long) this.readUChar(din);
        case 108:
          return this.readUInt(din);
        default:
          return num2 != 0 ? (long) ((int) (short) num1 & (int) byte.MaxValue) << 24 | (long) ((int) (short) (sbyte) din.readByte() & (int) byte.MaxValue) << 16 | (long) ((int) (short) (sbyte) din.readByte() & (int) byte.MaxValue) << 8 | (long) ((int) (short) (sbyte) din.readByte() & (int) byte.MaxValue) : defaultValue;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 121, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string readString(DataInputStream din, long size)
    {
      byte[] numArray = new byte[(int) size];
      din.readFully(numArray);
      return String.newhelper(numArray, Strings.__\u003C\u003Eutf8);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(227)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int readUShort(DataInputStream din) => (int) din.readShort() & (int) ushort.MaxValue;

    [LineNumberTable(new byte[] {159, 184, 127, 13, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue parse(Fi file)
    {
      JsonValue jsonValue;
      Exception exception1;
      try
      {
        jsonValue = this.parse((InputStream) file.read(8192));
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return jsonValue;
label_5:
      Exception exception2 = exception1;
      string message = new StringBuilder().append("Error parsing file: ").append((object) file).toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException(message, (Exception) exception3);
    }
  }
}
