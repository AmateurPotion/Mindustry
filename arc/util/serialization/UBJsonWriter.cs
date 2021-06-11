// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.UBJsonWriter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.io;
using java.lang;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.serialization
{
  [Implements(new string[] {"java.io.Closeable", "arc.util.serialization.BaseJsonWriter"})]
  public class UBJsonWriter : Object, Closeable, AutoCloseable, BaseJsonWriter
  {
    [Modifiers]
    internal DataOutputStream @out;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/util/serialization/UBJsonWriter$JsonObject;>;")]
    private Seq stack;
    private UBJsonWriter.JsonObject current;
    private bool named;

    [LineNumberTable(new byte[] {159, 164, 232, 60, 235, 69, 112, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UBJsonWriter(OutputStream @out)
    {
      UBJsonWriter ubJsonWriter = this;
      this.stack = new Seq();
      if (!(@out is DataOutputStream))
        @out = (OutputStream) new DataOutputStream(@out);
      this.@out = (DataOutputStream) @out;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {41, 127, 6, 108, 102, 109, 111, 105, 109, 143, 109, 141, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter name(string name)
    {
      if (this.current == null || this.current.array)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Current item must be an object.");
      }
      byte[] bytes = String.instancehelper_getBytes(name, Strings.__\u003C\u003Eutf8);
      if (bytes.Length <= (int) sbyte.MaxValue)
      {
        this.@out.writeByte(105);
        this.@out.writeByte(bytes.Length);
      }
      else if (bytes.Length <= (int) short.MaxValue)
      {
        this.@out.writeByte(73);
        this.@out.writeShort(bytes.Length);
      }
      else
      {
        this.@out.writeByte(108);
        this.@out.writeInt(bytes.Length);
      }
      ((FilterOutputStream) this.@out).write(bytes);
      this.named = true;
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 181, 104, 109, 120, 167, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter @object()
    {
      if (this.current != null && !this.current.array)
      {
        if (!this.named)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Name must be set.");
        }
        this.named = false;
      }
      Seq stack = this.stack;
      UBJsonWriter ubJsonWriter = this;
      UBJsonWriter.JsonObject jsonObject1 = new UBJsonWriter.JsonObject(this, false);
      UBJsonWriter.JsonObject jsonObject2 = jsonObject1;
      this.current = jsonObject1;
      stack.add((object) jsonObject2);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {15, 104, 109, 120, 167, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter array()
    {
      if (this.current != null && !this.current.array)
      {
        if (!this.named)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Name must be set.");
        }
        this.named = false;
      }
      Seq stack = this.stack;
      UBJsonWriter ubJsonWriter = this;
      UBJsonWriter.JsonObject jsonObject1 = new UBJsonWriter.JsonObject(this, true);
      UBJsonWriter.JsonObject jsonObject2 = jsonObject1;
      this.current = jsonObject1;
      stack.add((object) jsonObject2);
      return this;
    }

    [LineNumberTable(new byte[] {162, 17, 104, 109, 120, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkName()
    {
      if (this.current == null || this.current.array)
        return;
      if (!this.named)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Name must be set.");
      }
      this.named = false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {85, 102, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(int value)
    {
      this.checkName();
      this.@out.writeByte(108);
      this.@out.writeInt(value);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {158, 233, 98, 120, 99, 142, 117, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual UBJsonWriter pop(bool silent)
    {
      int num = silent ? 1 : 0;
      if (this.named)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Expected an object, array, or value since a name was set.");
      }
      if (num != 0)
        this.stack.pop();
      else
        ((UBJsonWriter.JsonObject) this.stack.pop()).close();
      this.current = this.stack.size != 0 ? (UBJsonWriter.JsonObject) this.stack.peek() : (UBJsonWriter.JsonObject) null;
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(657)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter pop() => this.pop(false);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {5, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter @object(string name)
    {
      this.name(name).@object();
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 24, 104, 104, 143, 103, 106, 40, 137, 108, 104, 104, 143, 103, 106, 40, 137, 108, 104, 117, 114, 104, 117, 115, 104, 117, 111, 104, 117, 111, 104, 117, 137, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(JsonValue value)
    {
      if (value.isObject())
      {
        if (value.name != null)
          this.@object(value.name);
        else
          this.@object();
        for (JsonValue jsonValue = value.child; jsonValue != null; jsonValue = jsonValue.next)
          this.value(jsonValue);
        this.pop();
      }
      else if (value.isArray())
      {
        if (value.name != null)
          this.array(value.name);
        else
          this.array();
        for (JsonValue jsonValue = value.child; jsonValue != null; jsonValue = jsonValue.next)
          this.value(jsonValue);
        this.pop();
      }
      else if (value.isBoolean())
      {
        if (value.name != null)
          this.name(value.name);
        this.value(value.asBoolean());
      }
      else if (value.isDouble())
      {
        if (value.name != null)
          this.name(value.name);
        this.value(value.asDouble());
      }
      else if (value.isLong())
      {
        if (value.name != null)
          this.name(value.name);
        this.value(value.asLong());
      }
      else if (value.isString())
      {
        if (value.name != null)
          this.name(value.name);
        this.value(value.asString());
      }
      else if (value.isNull())
      {
        if (value.name != null)
          this.name(value.name);
        this.value();
      }
      else
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException("Unhandled JsonValue type");
      }
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {31, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter array(string name)
    {
      this.name(name).array();
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 97, 98, 102, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(bool value)
    {
      int num = value ? 1 : 0;
      this.checkName();
      this.@out.writeByte(num == 0 ? 70 : 84);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {119, 102, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(double value)
    {
      this.checkName();
      this.@out.writeByte(68);
      this.@out.writeDouble(value);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {96, 102, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(long value)
    {
      this.checkName();
      this.@out.writeByte(76);
      this.@out.writeLong(value);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 89, 102, 108, 109, 102, 109, 111, 105, 109, 143, 109, 141, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(string value)
    {
      this.checkName();
      byte[] bytes = String.instancehelper_getBytes(value, Strings.__\u003C\u003Eutf8);
      this.@out.writeByte(83);
      if (bytes.Length <= (int) sbyte.MaxValue)
      {
        this.@out.writeByte(105);
        this.@out.writeByte(bytes.Length);
      }
      else if (bytes.Length <= (int) short.MaxValue)
      {
        this.@out.writeByte(73);
        this.@out.writeShort(bytes.Length);
      }
      else
      {
        this.@out.writeByte(108);
        this.@out.writeInt(bytes.Length);
      }
      ((FilterOutputStream) this.@out).write(bytes);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 95, 102, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value()
    {
      this.checkName();
      this.@out.writeByte(90);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 114, 99, 102, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(byte value)
    {
      int num = (int) (sbyte) value;
      this.checkName();
      this.@out.writeByte(105);
      this.@out.writeByte(num);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 111, 66, 102, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(short value)
    {
      int num = (int) value;
      this.checkName();
      this.@out.writeByte(73);
      this.@out.writeShort(num);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {107, 102, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(float value)
    {
      this.checkName();
      this.@out.writeByte(100);
      this.@out.writeFloat(value);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 94, 66, 102, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(char value)
    {
      int num = (int) value;
      this.checkName();
      this.@out.writeByte(73);
      this.@out.writeChar(num);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 68, 99, 103, 107, 103, 118, 117, 117, 117, 118, 118, 106, 114, 104, 109, 104, 146, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(object @object)
    {
      if (@object == null)
        return this.value();
      if (@object is Number)
      {
        Number number = (Number) @object;
        if (@object is Byte)
          return this.value(number.byteValue());
        if (@object is Short)
          return this.value(number.shortValue());
        if (@object is Integer)
          return this.value(number.intValue());
        if (@object is Long)
          return this.value(number.longValue());
        if (@object is Float)
          return this.value(number.floatValue());
        return @object is Double ? this.value(number.doubleValue()) : this;
      }
      if (@object is Character)
        return this.value(((Character) @object).charValue());
      if (CharSequence.IsInstance(@object))
        return this.value(Object.instancehelper_toString(@object));
      if (@object is Boolean)
        return this.value(((Boolean) @object).booleanValue());
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException("Unknown object type.");
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 112, 103, 109, 109, 109, 105, 105, 46, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(byte[] values)
    {
      this.array();
      this.@out.writeByte(36);
      this.@out.writeByte(105);
      this.@out.writeByte(35);
      this.value(values.Length);
      int index = 0;
      for (int length = values.Length; index < length; ++index)
        this.@out.writeByte((int) (sbyte) values[index]);
      this.pop(true);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 130, 103, 109, 109, 109, 105, 105, 46, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(short[] values)
    {
      this.array();
      this.@out.writeByte(36);
      this.@out.writeByte(73);
      this.@out.writeByte(35);
      this.value(values.Length);
      int index = 0;
      for (int length = values.Length; index < length; ++index)
        this.@out.writeShort((int) values[index]);
      this.pop(true);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 148, 103, 109, 109, 109, 105, 105, 46, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(int[] values)
    {
      this.array();
      this.@out.writeByte(36);
      this.@out.writeByte(108);
      this.@out.writeByte(35);
      this.value(values.Length);
      int index = 0;
      for (int length = values.Length; index < length; ++index)
        this.@out.writeInt(values[index]);
      this.pop(true);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 166, 103, 109, 109, 109, 105, 105, 46, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(long[] values)
    {
      this.array();
      this.@out.writeByte(36);
      this.@out.writeByte(76);
      this.@out.writeByte(35);
      this.value(values.Length);
      int index = 0;
      for (int length = values.Length; index < length; ++index)
        this.@out.writeLong(values[index]);
      this.pop(true);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 184, 103, 109, 109, 109, 105, 105, 46, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(float[] values)
    {
      this.array();
      this.@out.writeByte(36);
      this.@out.writeByte(100);
      this.@out.writeByte(35);
      this.value(values.Length);
      int index = 0;
      for (int length = values.Length; index < length; ++index)
        this.@out.writeFloat(values[index]);
      this.pop(true);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 203, 103, 109, 109, 109, 105, 105, 46, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(double[] values)
    {
      this.array();
      this.@out.writeByte(36);
      this.@out.writeByte(68);
      this.@out.writeByte(35);
      this.value(values.Length);
      int index = 0;
      for (int length = values.Length; index < length; ++index)
        this.@out.writeDouble(values[index]);
      this.pop(true);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 220, 103, 105, 54, 166, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(bool[] values)
    {
      this.array();
      int index = 0;
      for (int length = values.Length; index < length; ++index)
        this.@out.writeByte(!values[index] ? 70 : 84);
      this.pop();
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 234, 103, 109, 109, 109, 105, 105, 46, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(char[] values)
    {
      this.array();
      this.@out.writeByte(36);
      this.@out.writeByte(67);
      this.@out.writeByte(35);
      this.value(values.Length);
      int index = 0;
      for (int length = values.Length; index < length; ++index)
        this.@out.writeChar((int) values[index]);
      this.pop(true);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 252, 103, 109, 109, 109, 105, 108, 110, 102, 109, 111, 105, 109, 143, 109, 141, 236, 52, 233, 78, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter value(string[] values)
    {
      this.array();
      this.@out.writeByte(36);
      this.@out.writeByte(83);
      this.@out.writeByte(35);
      this.value(values.Length);
      int index = 0;
      for (int length = values.Length; index < length; ++index)
      {
        byte[] bytes = String.instancehelper_getBytes(values[index], Strings.__\u003C\u003Eutf8);
        if (bytes.Length <= (int) sbyte.MaxValue)
        {
          this.@out.writeByte(105);
          this.@out.writeByte(bytes.Length);
        }
        else if (bytes.Length <= (int) short.MaxValue)
        {
          this.@out.writeByte(73);
          this.@out.writeShort(bytes.Length);
        }
        else
        {
          this.@out.writeByte(108);
          this.@out.writeInt(bytes.Length);
        }
        ((FilterOutputStream) this.@out).write(bytes);
      }
      this.pop(true);
      return this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(486)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, object value) => this.name(name).value(value);

    [LineNumberTable(new byte[] {159, 170, 108, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.stack.clear();
      this.current = (UBJsonWriter.JsonObject) null;
      this.named = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOutputType(JsonWriter.OutputType outputType)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setQuoteLongValues(bool quoteLongValues)
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(495)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, byte value)
    {
      int num = (int) (sbyte) value;
      return this.name(name).value((byte) num);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(503)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, short value)
    {
      int num = (int) value;
      return this.name(name).value((short) num);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(511)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, int value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(519)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, long value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(527)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, float value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(535)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, double value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(543)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, bool value)
    {
      int num = value ? 1 : 0;
      return this.name(name).value(num != 0);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(551)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, char value)
    {
      int num = (int) value;
      return this.name(name).value((char) num);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(559)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, string value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(567)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, byte[] value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(575)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, short[] value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(583)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, int[] value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(591)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, long[] value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(599)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, float[] value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(607)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, double[] value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(615)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, bool[] value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(623)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, char[] value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(631)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name, string[] value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(639)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual UBJsonWriter set(string name) => this.name(name).value();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {162, 46, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flush() => this.@out.flush();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {162, 52, 110, 105, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      while (this.stack.size > 0)
        this.pop();
      ((FilterOutputStream) this.@out).close();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter \u003Cbridge\u003Epop() => (BaseJsonWriter) this.pop();

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter \u003Cbridge\u003Eset(string str, object obj) => (BaseJsonWriter) this.set(str, obj);

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter \u003Cbridge\u003Earray(string str) => (BaseJsonWriter) this.array(str);

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter \u003Cbridge\u003Eobject(string str) => (BaseJsonWriter) this.@object(str);

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter \u003Cbridge\u003Evalue(object obj) => (BaseJsonWriter) this.value(obj);

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter \u003Cbridge\u003Earray() => (BaseJsonWriter) this.array();

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter \u003Cbridge\u003Eobject() => (BaseJsonWriter) this.@object();

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter \u003Cbridge\u003Ename(string str) => (BaseJsonWriter) this.name(str);

    void IDisposable.__\u003Coverridestub\u003Ejava\u002Elang\u002EAutoCloseable\u003A\u003Aclose() => this.close();

    BaseJsonWriter BaseJsonWriter.__\u003Coverridestub\u003Earc\u002Eutil\u002Eserialization\u002EBaseJsonWriter\u003A\u003Aname(
      [In] string obj0)
    {
      return this.\u003Cbridge\u003Ename(obj0);
    }

    BaseJsonWriter BaseJsonWriter.__\u003Coverridestub\u003Earc\u002Eutil\u002Eserialization\u002EBaseJsonWriter\u003A\u003Aobject() => this.\u003Cbridge\u003Eobject();

    BaseJsonWriter BaseJsonWriter.__\u003Coverridestub\u003Earc\u002Eutil\u002Eserialization\u002EBaseJsonWriter\u003A\u003Aarray() => this.\u003Cbridge\u003Earray();

    BaseJsonWriter BaseJsonWriter.__\u003Coverridestub\u003Earc\u002Eutil\u002Eserialization\u002EBaseJsonWriter\u003A\u003Avalue(
      [In] object obj0)
    {
      return this.\u003Cbridge\u003Evalue(obj0);
    }

    BaseJsonWriter BaseJsonWriter.__\u003Coverridestub\u003Earc\u002Eutil\u002Eserialization\u002EBaseJsonWriter\u003A\u003Aobject(
      [In] string obj0)
    {
      return this.\u003Cbridge\u003Eobject(obj0);
    }

    BaseJsonWriter BaseJsonWriter.__\u003Coverridestub\u003Earc\u002Eutil\u002Eserialization\u002EBaseJsonWriter\u003A\u003Aarray(
      [In] string obj0)
    {
      return this.\u003Cbridge\u003Earray(obj0);
    }

    BaseJsonWriter BaseJsonWriter.__\u003Coverridestub\u003Earc\u002Eutil\u002Eserialization\u002EBaseJsonWriter\u003A\u003Aset(
      [In] string obj0,
      [In] object obj1)
    {
      return this.\u003Cbridge\u003Eset(obj0, obj1);
    }

    BaseJsonWriter BaseJsonWriter.__\u003Coverridestub\u003Earc\u002Eutil\u002Eserialization\u002EBaseJsonWriter\u003A\u003Apop() => this.\u003Cbridge\u003Epop();

    [InnerClass]
    internal class JsonObject : Object
    {
      [Modifiers]
      internal bool array;
      [Modifiers]
      internal UBJsonWriter this\u00240;

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {158, 227, 130, 111, 103, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal JsonObject([In] UBJsonWriter obj0, [In] bool obj1)
      {
        int num = obj1 ? 1 : 0;
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        UBJsonWriter.JsonObject jsonObject = this;
        this.array = num != 0;
        obj0.@out.writeByte(num == 0 ? 123 : 91);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {162, 66, 126})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void close() => this.this\u00240.@out.writeByte(!this.array ? 125 : 93);
    }
  }
}
