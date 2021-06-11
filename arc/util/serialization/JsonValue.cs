// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.JsonValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.function;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.serialization
{
  [Signature("Ljava/lang/Object;Ljava/lang/Iterable<Larc/util/serialization/JsonValue;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class JsonValue : Object, Iterable, IEnumerable
  {
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public string name;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public JsonValue child;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public JsonValue next;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public JsonValue prev;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public JsonValue parent;
    public int size;
    private JsonValue.ValueType type;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private string stringValue;
    private double doubleValue;
    private long longValue;

    [LineNumberTable(1251)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue.JsonIterator iterator() => new JsonValue.JsonIterator(this);

    [LineNumberTable(new byte[] {162, 27, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(string name, string defaultValue)
    {
      JsonValue jsonValue = this.get(name);
      return jsonValue == null || !jsonValue.isValue() || jsonValue.isNull() ? defaultValue : jsonValue.asString();
    }

    [LineNumberTable(new byte[] {162, 51, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(string name, int defaultValue)
    {
      JsonValue jsonValue = this.get(name);
      return jsonValue == null || !jsonValue.isValue() || jsonValue.isNull() ? defaultValue : jsonValue.asInt();
    }

    [LineNumberTable(new byte[] {162, 33, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFloat(string name, float defaultValue)
    {
      JsonValue jsonValue = this.get(name);
      return jsonValue == null || !jsonValue.isValue() || jsonValue.isNull() ? defaultValue : jsonValue.asFloat();
    }

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(string name) => this.get(name) != null;

    [LineNumberTable(new byte[] {54, 103, 121, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue get(string name)
    {
      JsonValue jsonValue = this.child;
      while (jsonValue != null && (jsonValue.name == null || !String.instancehelper_equalsIgnoreCase(jsonValue.name, name)))
        jsonValue = jsonValue.next;
      return jsonValue;
    }

    [LineNumberTable(908)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNumber() => object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003EdoubleValue) || object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003ElongValue);

    [LineNumberTable(903)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isString() => object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003EstringValue);

    [LineNumberTable(new byte[] {164, 118, 104, 120, 120, 166, 122, 102, 98, 111, 105, 127, 6, 226, 61, 237, 70, 120, 159, 66, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string trace()
    {
      if (this.parent == null)
      {
        if (object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
          return "[]";
        return object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Eobject) ? "{}" : "";
      }
      string str1;
      if (object.ReferenceEquals((object) this.parent.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        str1 = "[]";
        int num = 0;
        JsonValue jsonValue = this.parent.child;
        while (jsonValue != null)
        {
          if (object.ReferenceEquals((object) jsonValue, (object) this))
          {
            str1 = new StringBuilder().append("[").append(num).append("]").toString();
            break;
          }
          jsonValue = jsonValue.next;
          ++num;
        }
      }
      else if (String.instancehelper_indexOf(this.name, 46) != -1)
      {
        StringBuilder stringBuilder = new StringBuilder().append(".\"");
        string name = this.name;
        object obj1 = (object) "\\\"";
        object obj2 = (object) "\"";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        string str2 = String.instancehelper_replace(name, charSequence2, charSequence3);
        str1 = stringBuilder.append(str2).append("\"").toString();
      }
      else
        str1 = new StringBuilder().append('.').append(this.name).toString();
      return new StringBuilder().append(this.parent.trace()).append(str1).toString();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string name() => this.name;

    [LineNumberTable(899)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isObject() => object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Eobject);

    [LineNumberTable(new byte[] {159, 181, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonValue(string value)
    {
      JsonValue jsonValue = this;
      this.set(value);
    }

    [LineNumberTable(new byte[] {160, 145, 159, 11, 140, 140, 136, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int asInt()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
          return Integer.parseInt(this.stringValue);
        case 2:
          return ByteCodeHelper.d2i(this.doubleValue);
        case 3:
          return (int) this.longValue;
        case 4:
          return this.longValue != 0L ? 1 : 0;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch("int"));
      }
    }

    [LineNumberTable(new byte[] {162, 18, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue getChild(string name) => this.get(name)?.child;

    [LineNumberTable(895)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isArray() => object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray);

    [LineNumberTable(new byte[] {160, 91, 159, 11, 141, 136, 136, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float asFloat()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
          return Float.parseFloat(this.stringValue);
        case 2:
          return (float) this.doubleValue;
        case 3:
          return (float) this.longValue;
        case 4:
          return this.longValue != 0L ? 1f : 0.0f;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch("float"));
      }
    }

    [LineNumberTable(new byte[] {160, 127, 159, 11, 140, 140, 135, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long asLong()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
          return Long.parseLong(this.stringValue);
        case 2:
          return ByteCodeHelper.d2l(this.doubleValue);
        case 3:
          return this.longValue;
        case 4:
          return this.longValue != 0L ? 1L : 0L;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch("long"));
      }
    }

    [LineNumberTable(new byte[] {160, 109, 159, 11, 141, 135, 136, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double asDouble()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
          return Double.parseDouble(this.stringValue);
        case 2:
          return this.doubleValue;
        case 3:
          return (double) this.longValue;
        case 4:
          return this.longValue != 0L ? 1.0 : 0.0;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch("double"));
      }
    }

    [LineNumberTable(new byte[] {160, 71, 159, 15, 135, 156, 156, 151, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string asString()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
          return this.stringValue;
        case 2:
          return this.stringValue != null ? this.stringValue : Double.toString(this.doubleValue);
        case 3:
          return this.stringValue != null ? this.stringValue : Long.toString(this.longValue);
        case 4:
          return this.longValue != 0L ? "true" : "false";
        case 5:
          return (string) null;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch("string"));
      }
    }

    [LineNumberTable(new byte[] {160, 199, 159, 11, 140, 141, 137, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short asShort()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
          return Short.parseShort(this.stringValue);
        case 2:
          return (short) ByteCodeHelper.d2i(this.doubleValue);
        case 3:
          return (short) (int) this.longValue;
        case 4:
          return (short) (this.longValue != 0L);
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch("short"));
      }
    }

    [LineNumberTable(new byte[] {160, 181, 159, 11, 141, 141, 137, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte asByte()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
          return Byte.parseByte(this.stringValue);
        case 2:
          return (byte) ByteCodeHelper.d2i(this.doubleValue);
        case 3:
          return (byte) (int) this.longValue;
        case 4:
          return (byte) (this.longValue != 0L);
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch("byte"));
      }
    }

    [LineNumberTable(920)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBoolean() => object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003EbooleanValue);

    [LineNumberTable(new byte[] {160, 163, 159, 11, 145, 145, 142, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool asBoolean()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
          return String.instancehelper_equalsIgnoreCase(this.stringValue, "true");
        case 2:
          return this.doubleValue != 0.0;
        case 3:
          return this.longValue != 0L;
        case 4:
          return this.longValue != 0L;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch("boolean"));
      }
    }

    [LineNumberTable(new byte[] {163, 223, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string prettyPrint(JsonWriter.OutputType outputType, int singleLineColumns) => this.prettyPrint(new JsonValue.PrettyPrintSettings()
    {
      outputType = outputType,
      singleLineColumns = singleLineColumns
    });

    [LineNumberTable(new byte[] {163, 230, 107, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string prettyPrint(JsonValue.PrettyPrintSettings settings)
    {
      StringBuilder stringBuilder = new StringBuilder(512);
      this.prettyPrint(this, stringBuilder, 0, settings);
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {162, 124, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Named value not found: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asInt();
    }

    [LineNumberTable(new byte[] {116, 104, 101, 104, 108, 150, 113, 153, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue remove(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
        return (JsonValue) null;
      if (jsonValue.prev == null)
      {
        this.child = jsonValue.next;
        if (this.child != null)
          this.child.prev = (JsonValue) null;
      }
      else
      {
        jsonValue.prev.next = jsonValue.next;
        if (jsonValue.next != null)
          jsonValue.next.prev = jsonValue.prev;
      }
      --this.size;
      return jsonValue;
    }

    [LineNumberTable(new byte[] {162, 84, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Named value not found: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asString();
    }

    [LineNumberTable(new byte[] {159, 176, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonValue(JsonValue.ValueType type)
    {
      JsonValue jsonValue = this;
      this.type = type;
    }

    [LineNumberTable(new byte[] {163, 161, 111, 107, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toJson(JsonWriter.OutputType outputType)
    {
      if (this.isValue())
        return this.asString();
      StringBuilder stringBuilder = new StringBuilder(512);
      this.json(this, stringBuilder, outputType);
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {163, 88, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChild(string name, JsonValue value)
    {
      value.name = name;
      this.addChild(value);
    }

    [LineNumberTable(new byte[] {159, 189, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonValue(long value)
    {
      JsonValue jsonValue = this;
      this.set(value, (string) null);
    }

    [LineNumberTable(new byte[] {159, 128, 162, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonValue(bool value)
    {
      int num = value ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      JsonValue jsonValue = this;
      this.set(num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setName(string name) => this.name = name;

    [LineNumberTable(new byte[] {1, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonValue(double value, string stringValue)
    {
      JsonValue jsonValue = this;
      this.set(value, stringValue);
    }

    [LineNumberTable(new byte[] {5, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonValue(long value, string stringValue)
    {
      JsonValue jsonValue = this;
      this.set(value, stringValue);
    }

    [LineNumberTable(new byte[] {163, 135, 103, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(string value)
    {
      this.stringValue = value;
      this.type = value != null ? JsonValue.ValueType.__\u003C\u003EstringValue : JsonValue.ValueType.__\u003C\u003EnullValue;
    }

    [LineNumberTable(new byte[] {163, 141, 105, 109, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(double value, string stringValue)
    {
      this.doubleValue = value;
      this.longValue = ByteCodeHelper.d2l(value);
      this.stringValue = stringValue;
      this.type = JsonValue.ValueType.__\u003C\u003EdoubleValue;
    }

    [LineNumberTable(new byte[] {163, 149, 103, 105, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(long value, string stringValue)
    {
      this.longValue = value;
      this.doubleValue = (double) value;
      this.stringValue = stringValue;
      this.type = JsonValue.ValueType.__\u003C\u003ElongValue;
    }

    [LineNumberTable(new byte[] {158, 139, 130, 111, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(bool value)
    {
      this.longValue = !value ? 0L : 1L;
      this.type = JsonValue.ValueType.__\u003C\u003EbooleanValue;
    }

    [LineNumberTable(new byte[] {41, 103, 103, 101, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue get(int index)
    {
      JsonValue jsonValue;
      for (jsonValue = this.child; jsonValue != null && index > 0; jsonValue = jsonValue.next)
        index += -1;
      return jsonValue;
    }

    [LineNumberTable(600)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private RuntimeException typeMismatch([In] string obj0) => (RuntimeException) new IllegalStateException(new StringBuilder().append("\"").append(this.name != null ? this.name : "value").append("\" should be a ").append(obj0).append(", but it is a ").append((object) this.type).append(".").toString());

    [LineNumberTable(new byte[] {163, 47, 255, 15, 70, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isValue()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
        case 2:
        case 3:
        case 4:
        case 5:
          return true;
        default:
          return false;
      }
    }

    [LineNumberTable(924)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003EnullValue);

    [LineNumberTable(new byte[] {160, 217, 159, 11, 157, 141, 137, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char asChar()
    {
      switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[this.type.ordinal()])
      {
        case 1:
          return String.instancehelper_length(this.stringValue) == 0 ? char.MinValue : String.instancehelper_charAt(this.stringValue, 0);
        case 2:
          return (char) ByteCodeHelper.d2i(this.doubleValue);
        case 3:
          return (char) this.longValue;
        case 4:
          return (char) (this.longValue != 0L ? 1 : 0);
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch("char"));
      }
    }

    [LineNumberTable(new byte[] {163, 94, 103, 103, 99, 169, 104, 103, 129, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChild(JsonValue value)
    {
      value.parent = this;
      JsonValue jsonValue = this.child;
      if (jsonValue == null)
      {
        this.child = value;
      }
      else
      {
        while (jsonValue.next != null)
          jsonValue = jsonValue.next;
        jsonValue.next = value;
      }
    }

    [LineNumberTable(new byte[] {163, 168, 107, 104, 145, 135, 105, 98, 106, 115, 105, 105, 241, 60, 233, 70, 130, 105, 101, 107, 104, 145, 135, 105, 106, 105, 17, 233, 70, 105, 101, 104, 120, 104, 105, 103, 104, 106, 111, 104, 111, 104, 142, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void json([In] JsonValue obj0, [In] StringBuilder obj1, [In] JsonWriter.OutputType obj2)
    {
      if (obj0.isObject())
      {
        if (obj0.child == null)
        {
          obj1.append("{}");
        }
        else
        {
          obj1.length();
          obj1.append('{');
          for (JsonValue jsonValue = obj0.child; jsonValue != null; jsonValue = jsonValue.next)
          {
            obj1.append(obj2.quoteName(jsonValue.name));
            obj1.append(':');
            this.json(jsonValue, obj1, obj2);
            if (jsonValue.next != null)
              obj1.append(',');
          }
          obj1.append('}');
        }
      }
      else if (obj0.isArray())
      {
        if (obj0.child == null)
        {
          obj1.append("[]");
        }
        else
        {
          obj1.length();
          obj1.append('[');
          for (JsonValue jsonValue = obj0.child; jsonValue != null; jsonValue = jsonValue.next)
          {
            this.json(jsonValue, obj1, obj2);
            if (jsonValue.next != null)
              obj1.append(',');
          }
          obj1.append(']');
        }
      }
      else if (obj0.isString())
        obj1.append(obj2.quoteValue((object) obj0.asString()));
      else if (obj0.isDouble())
      {
        double num = obj0.asDouble();
        obj0.asLong();
        obj1.append(num);
      }
      else if (obj0.isLong())
        obj1.append(obj0.asLong());
      else if (obj0.isBoolean())
        obj1.append(obj0.asBoolean());
      else if (obj0.isNull())
      {
        obj1.append("null");
      }
      else
      {
        string message = new StringBuilder().append("Unknown object type: ").append((object) obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message);
      }
    }

    [LineNumberTable(912)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDouble() => object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003EdoubleValue);

    [LineNumberTable(916)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLong() => object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003ElongValue);

    [LineNumberTable(new byte[] {163, 236, 104, 107, 104, 145, 109, 167, 118, 109, 106, 115, 108, 109, 127, 2, 112, 116, 103, 98, 229, 54, 236, 77, 130, 108, 105, 101, 107, 104, 145, 109, 118, 168, 118, 111, 106, 110, 127, 3, 112, 120, 104, 98, 229, 56, 238, 75, 130, 108, 105, 101, 104, 120, 104, 106, 103, 105, 106, 111, 104, 111, 104, 142, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void prettyPrint(
      [In] JsonValue obj0,
      [In] StringBuilder obj1,
      [In] int obj2,
      [In] JsonValue.PrettyPrintSettings obj3)
    {
      JsonWriter.OutputType outputType = obj3.outputType;
      if (obj0.isObject())
      {
        if (obj0.child == null)
        {
          obj1.append("{}");
        }
        else
        {
          int num1 = JsonValue.isFlat(obj0) ? 0 : 1;
          int num2 = obj1.length();
label_4:
          obj1.append(num1 == 0 ? "{ " : "{\n");
          for (JsonValue jsonValue = obj0.child; jsonValue != null; jsonValue = jsonValue.next)
          {
            if (num1 != 0)
              JsonValue.indent(obj2, obj1);
            obj1.append(outputType.quoteName(jsonValue.name));
            obj1.append(": ");
            this.prettyPrint(jsonValue, obj1, obj2 + 1, obj3);
            if ((num1 == 0 || !object.ReferenceEquals((object) outputType, (object) JsonWriter.OutputType.__\u003C\u003Eminimal)) && jsonValue.next != null)
              obj1.append(',');
            obj1.append(num1 == 0 ? ' ' : '\n');
            if (num1 == 0 && obj1.length() - num2 > obj3.singleLineColumns)
            {
              obj1.setLength(num2);
              num1 = 1;
              goto label_4;
            }
          }
          if (num1 != 0)
            JsonValue.indent(obj2 - 1, obj1);
          obj1.append('}');
        }
      }
      else if (obj0.isArray())
      {
        if (obj0.child == null)
        {
          obj1.append("[]");
        }
        else
        {
          int num1 = JsonValue.isFlat(obj0) ? 0 : 1;
          int num2 = obj3.wrapNumericArrays || !JsonValue.isNumeric(obj0) ? 1 : 0;
          int num3 = obj1.length();
label_20:
          obj1.append(num1 == 0 ? "[ " : "[\n");
          for (JsonValue jsonValue = obj0.child; jsonValue != null; jsonValue = jsonValue.next)
          {
            if (num1 != 0)
              JsonValue.indent(obj2, obj1);
            this.prettyPrint(jsonValue, obj1, obj2 + 1, obj3);
            if ((num1 == 0 || !object.ReferenceEquals((object) outputType, (object) JsonWriter.OutputType.__\u003C\u003Eminimal)) && jsonValue.next != null)
              obj1.append(',');
            obj1.append(num1 == 0 ? ' ' : '\n');
            if (num2 != 0 && num1 == 0 && obj1.length() - num3 > obj3.singleLineColumns)
            {
              obj1.setLength(num3);
              num1 = 1;
              goto label_20;
            }
          }
          if (num1 != 0)
            JsonValue.indent(obj2 - 1, obj1);
          obj1.append(']');
        }
      }
      else if (obj0.isString())
        obj1.append(outputType.quoteValue((object) obj0.asString()));
      else if (obj0.isDouble())
      {
        double num = obj0.asDouble();
        obj0.asLong();
        obj1.append(num);
      }
      else if (obj0.isLong())
        obj1.append(obj0.asLong());
      else if (obj0.isBoolean())
        obj1.append(obj0.asBoolean());
      else if (obj0.isNull())
      {
        obj1.append("null");
      }
      else
      {
        string message = new StringBuilder().append("Unknown object type: ").append((object) obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message);
      }
    }

    [LineNumberTable(new byte[] {14, 106, 50, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isFlat([In] JsonValue obj0)
    {
      for (JsonValue jsonValue = obj0.child; jsonValue != null; jsonValue = jsonValue.next)
      {
        if (jsonValue.isObject() || jsonValue.isArray())
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {26, 102, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void indent([In] int obj0, [In] StringBuilder obj1)
    {
      for (int index = 0; index < obj0; ++index)
        obj1.append('\t');
    }

    [LineNumberTable(new byte[] {20, 106, 42, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isNumeric([In] JsonValue obj0)
    {
      for (JsonValue jsonValue = obj0.child; jsonValue != null; jsonValue = jsonValue.next)
      {
        if (!jsonValue.isNumber())
          return false;
      }
      return true;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 61, 104, 107, 104, 159, 2, 118, 127, 7, 98, 111, 106, 127, 5, 124, 110, 127, 3, 240, 58, 238, 72, 108, 105, 101, 107, 104, 159, 2, 109, 127, 7, 98, 111, 106, 110, 127, 3, 240, 60, 238, 70, 108, 105, 101, 104, 127, 9, 104, 106, 103, 126, 109, 127, 8, 104, 127, 5, 104, 158, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void prettyPrint(
      [In] JsonValue obj0,
      [In] Writer obj1,
      [In] int obj2,
      [In] JsonValue.PrettyPrintSettings obj3)
    {
      JsonWriter.OutputType outputType = obj3.outputType;
      if (obj0.isObject())
      {
        if (obj0.child == null)
        {
          Writer writer = obj1;
          object obj = (object) "{}";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          writer.append(charSequence2);
        }
        else
        {
          int num = !JsonValue.isFlat(obj0) || obj0.size > 6 ? 1 : 0;
          Writer writer1 = obj1;
          object obj4 = num == 0 ? (object) "{ " : (object) "{\n";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj4;
          CharSequence charSequence2 = charSequence1;
          writer1.append(charSequence2);
          for (JsonValue jsonValue = obj0.child; jsonValue != null; jsonValue = jsonValue.next)
          {
            if (num != 0)
              JsonValue.indent(obj2, obj1);
            Writer writer2 = obj1;
            object obj5 = (object) outputType.quoteName(jsonValue.name);
            charSequence1.__\u003Cref\u003E = (__Null) obj5;
            CharSequence charSequence3 = charSequence1;
            writer2.append(charSequence3);
            Writer writer3 = obj1;
            object obj6 = (object) ": ";
            charSequence1.__\u003Cref\u003E = (__Null) obj6;
            CharSequence charSequence4 = charSequence1;
            writer3.append(charSequence4);
            this.prettyPrint(jsonValue, obj1, obj2 + 1, obj3);
            if ((num == 0 || !object.ReferenceEquals((object) outputType, (object) JsonWriter.OutputType.__\u003C\u003Eminimal)) && jsonValue.next != null)
              obj1.append(',');
            obj1.append(num == 0 ? ' ' : '\n');
          }
          if (num != 0)
            JsonValue.indent(obj2 - 1, obj1);
          obj1.append('}');
        }
      }
      else if (obj0.isArray())
      {
        if (obj0.child == null)
        {
          Writer writer = obj1;
          object obj = (object) "[]";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          writer.append(charSequence2);
        }
        else
        {
          int num = JsonValue.isFlat(obj0) ? 0 : 1;
          Writer writer = obj1;
          object obj = num == 0 ? (object) "[ " : (object) "[\n";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          writer.append(charSequence2);
          for (JsonValue jsonValue = obj0.child; jsonValue != null; jsonValue = jsonValue.next)
          {
            if (num != 0)
              JsonValue.indent(obj2, obj1);
            this.prettyPrint(jsonValue, obj1, obj2 + 1, obj3);
            if ((num == 0 || !object.ReferenceEquals((object) outputType, (object) JsonWriter.OutputType.__\u003C\u003Eminimal)) && jsonValue.next != null)
              obj1.append(',');
            obj1.append(num == 0 ? ' ' : '\n');
          }
          if (num != 0)
            JsonValue.indent(obj2 - 1, obj1);
          obj1.append(']');
        }
      }
      else if (obj0.isString())
      {
        Writer writer = obj1;
        object obj = (object) outputType.quoteValue((object) obj0.asString());
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        writer.append(charSequence2);
      }
      else if (obj0.isDouble())
      {
        double num = obj0.asDouble();
        obj0.asLong();
        Writer writer = obj1;
        object obj = (object) Double.toString(num);
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        writer.append(charSequence2);
      }
      else if (obj0.isLong())
      {
        Writer writer = obj1;
        object obj = (object) Long.toString(obj0.asLong());
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        writer.append(charSequence2);
      }
      else if (obj0.isBoolean())
      {
        Writer writer = obj1;
        object obj = (object) Boolean.toString(obj0.asBoolean());
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        writer.append(charSequence2);
      }
      else if (obj0.isNull())
      {
        Writer writer = obj1;
        object obj = (object) "null";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        writer.append(charSequence2);
      }
      else
      {
        string message = new StringBuilder().append("Unknown object type: ").append((object) obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {31, 102, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void indent([In] int obj0, [In] Writer obj1)
    {
      for (int index = 0; index < obj0; ++index)
        obj1.append('\t');
    }

    [LineNumberTable(new byte[] {159, 185, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonValue(double value)
    {
      JsonValue jsonValue = this;
      this.set(value, (string) null);
    }

    [LineNumberTable(new byte[] {71, 103, 103, 101, 137, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue require(int index)
    {
      JsonValue jsonValue;
      for (jsonValue = this.child; jsonValue != null && index > 0; jsonValue = jsonValue.next)
        index += -1;
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Child not found with index: ").append(index).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue;
    }

    [LineNumberTable(new byte[] {85, 103, 121, 105, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue require(string name)
    {
      JsonValue jsonValue = this.child;
      while (jsonValue != null && (jsonValue.name == null || !String.instancehelper_equalsIgnoreCase(jsonValue.name, name)))
        jsonValue = jsonValue.next;
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Child not found with name: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue;
    }

    [LineNumberTable(new byte[] {98, 104, 101, 104, 108, 150, 113, 153, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue remove(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
        return (JsonValue) null;
      if (jsonValue.prev == null)
      {
        this.child = jsonValue.next;
        if (this.child != null)
          this.child.prev = (JsonValue) null;
      }
      else
      {
        jsonValue.prev.next = jsonValue.next;
        if (jsonValue.next != null)
          jsonValue.next.prev = jsonValue.prev;
      }
      --this.size;
      return jsonValue;
    }

    [LineNumberTable(new byte[] {160, 235, 127, 29, 108, 98, 141, 159, 18, 103, 133, 124, 133, 124, 130, 119, 130, 98, 130, 159, 11, 228, 43, 240, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] asStringArray()
    {
      if (!object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        string str = new StringBuilder().append("Value is not an array: ").append((object) this.type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      string[] strArray = new string[this.size];
      int index = 0;
      JsonValue jsonValue = this.child;
      while (jsonValue != null)
      {
        string str1;
        switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[jsonValue.type.ordinal()])
        {
          case 1:
            str1 = jsonValue.stringValue;
            break;
          case 2:
            str1 = this.stringValue == null ? Double.toString(jsonValue.doubleValue) : this.stringValue;
            break;
          case 3:
            str1 = this.stringValue == null ? Long.toString(jsonValue.longValue) : this.stringValue;
            break;
          case 4:
            str1 = jsonValue.longValue == 0L ? "false" : "true";
            break;
          case 5:
            str1 = (string) null;
            break;
          default:
            string str2 = new StringBuilder().append("Value cannot be converted to string: ").append((object) jsonValue.type).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str2);
        }
        strArray[index] = str1;
        jsonValue = jsonValue.next;
        ++index;
      }
      return strArray;
    }

    [LineNumberTable(new byte[] {161, 13, 127, 29, 108, 98, 141, 159, 11, 109, 130, 104, 130, 104, 130, 119, 130, 159, 11, 228, 46, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] asFloatSeq()
    {
      if (!object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        string str = new StringBuilder().append("Value is not an array: ").append((object) this.type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      float[] numArray = new float[this.size];
      int index = 0;
      JsonValue jsonValue = this.child;
      while (jsonValue != null)
      {
        float num;
        switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[jsonValue.type.ordinal()])
        {
          case 1:
            num = Float.parseFloat(jsonValue.stringValue);
            break;
          case 2:
            num = (float) jsonValue.doubleValue;
            break;
          case 3:
            num = (float) jsonValue.longValue;
            break;
          case 4:
            num = jsonValue.longValue == 0L ? 0.0f : 1f;
            break;
          default:
            string str = new StringBuilder().append("Value cannot be converted to float: ").append((object) jsonValue.type).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        numArray[index] = num;
        jsonValue = jsonValue.next;
        ++index;
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {161, 44, 127, 29, 108, 98, 141, 159, 11, 110, 130, 103, 130, 104, 130, 119, 130, 159, 11, 228, 46, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double[] asDoubleArray()
    {
      if (!object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        string str = new StringBuilder().append("Value is not an array: ").append((object) this.type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      double[] numArray = new double[this.size];
      int index = 0;
      JsonValue jsonValue = this.child;
      while (jsonValue != null)
      {
        double num;
        switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[jsonValue.type.ordinal()])
        {
          case 1:
            num = Double.parseDouble(jsonValue.stringValue);
            break;
          case 2:
            num = jsonValue.doubleValue;
            break;
          case 3:
            num = (double) jsonValue.longValue;
            break;
          case 4:
            num = jsonValue.longValue == 0L ? 0.0 : 1.0;
            break;
          default:
            string str = new StringBuilder().append("Value cannot be converted to double: ").append((object) jsonValue.type).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        numArray[index] = num;
        jsonValue = jsonValue.next;
        ++index;
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {161, 75, 127, 29, 108, 98, 141, 159, 11, 108, 130, 108, 130, 103, 130, 113, 130, 159, 11, 228, 46, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long[] asLongArray()
    {
      if (!object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        string str = new StringBuilder().append("Value is not an array: ").append((object) this.type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      long[] numArray = new long[this.size];
      int index = 0;
      JsonValue jsonValue = this.child;
      while (jsonValue != null)
      {
        long num;
        switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[jsonValue.type.ordinal()])
        {
          case 1:
            num = Long.parseLong(jsonValue.stringValue);
            break;
          case 2:
            num = ByteCodeHelper.d2l(jsonValue.doubleValue);
            break;
          case 3:
            num = jsonValue.longValue;
            break;
          case 4:
            num = jsonValue.longValue == 0L ? 0L : 1L;
            break;
          default:
            string str = new StringBuilder().append("Value cannot be converted to long: ").append((object) jsonValue.type).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        numArray[index] = num;
        jsonValue = jsonValue.next;
        ++index;
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {161, 106, 127, 29, 108, 98, 141, 159, 11, 108, 130, 108, 130, 104, 130, 110, 130, 159, 11, 228, 46, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int[] asIntArray()
    {
      if (!object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        string str = new StringBuilder().append("Value is not an array: ").append((object) this.type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      int[] numArray = new int[this.size];
      int index = 0;
      JsonValue jsonValue = this.child;
      while (jsonValue != null)
      {
        int num;
        switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[jsonValue.type.ordinal()])
        {
          case 1:
            num = Integer.parseInt(jsonValue.stringValue);
            break;
          case 2:
            num = ByteCodeHelper.d2i(jsonValue.doubleValue);
            break;
          case 3:
            num = (int) jsonValue.longValue;
            break;
          case 4:
            num = jsonValue.longValue != 0L ? 1 : 0;
            break;
          default:
            string str = new StringBuilder().append("Value cannot be converted to int: ").append((object) jsonValue.type).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        numArray[index] = num;
        jsonValue = jsonValue.next;
        ++index;
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {161, 137, 127, 29, 108, 98, 141, 159, 11, 108, 130, 110, 130, 107, 130, 110, 130, 159, 11, 228, 46, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool[] asBooleanArray()
    {
      if (!object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        string str = new StringBuilder().append("Value is not an array: ").append((object) this.type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      bool[] flagArray = new bool[this.size];
      int index = 0;
      JsonValue jsonValue = this.child;
      while (jsonValue != null)
      {
        int num;
        switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[jsonValue.type.ordinal()])
        {
          case 1:
            num = Boolean.parseBoolean(jsonValue.stringValue) ? 1 : 0;
            break;
          case 2:
            num = jsonValue.doubleValue == 0.0 ? 1 : 0;
            break;
          case 3:
            num = jsonValue.longValue == 0L ? 1 : 0;
            break;
          case 4:
            num = jsonValue.longValue != 0L ? 1 : 0;
            break;
          default:
            string str = new StringBuilder().append("Value cannot be converted to boolean: ").append((object) jsonValue.type).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        flagArray[index] = num != 0;
        jsonValue = jsonValue.next;
        ++index;
      }
      return flagArray;
    }

    [LineNumberTable(new byte[] {161, 168, 127, 29, 108, 98, 141, 159, 11, 109, 130, 109, 130, 105, 130, 110, 130, 159, 11, 228, 46, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] asByteArray()
    {
      if (!object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        string str = new StringBuilder().append("Value is not an array: ").append((object) this.type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      byte[] numArray = new byte[this.size];
      int index = 0;
      JsonValue jsonValue = this.child;
      while (jsonValue != null)
      {
        int num;
        switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[jsonValue.type.ordinal()])
        {
          case 1:
            num = (int) (sbyte) Byte.parseByte(jsonValue.stringValue);
            break;
          case 2:
            num = (int) (sbyte) ByteCodeHelper.d2i(jsonValue.doubleValue);
            break;
          case 3:
            num = (int) (sbyte) (int) jsonValue.longValue;
            break;
          case 4:
            num = jsonValue.longValue != 0L ? 1 : 0;
            break;
          default:
            string str = new StringBuilder().append("Value cannot be converted to byte: ").append((object) jsonValue.type).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        numArray[index] = (byte) num;
        jsonValue = jsonValue.next;
        ++index;
      }
      return numArray;
    }

    [LineNumberTable(new byte[] {161, 199, 127, 29, 108, 98, 141, 159, 11, 108, 130, 109, 130, 105, 130, 110, 130, 159, 11, 228, 46, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short[] asShortArray()
    {
      if (!object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        string str = new StringBuilder().append("Value is not an array: ").append((object) this.type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      short[] numArray = new short[this.size];
      int index = 0;
      JsonValue jsonValue = this.child;
      while (jsonValue != null)
      {
        int num;
        switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[jsonValue.type.ordinal()])
        {
          case 1:
            num = (int) Short.parseShort(jsonValue.stringValue);
            break;
          case 2:
            num = (int) (short) ByteCodeHelper.d2i(jsonValue.doubleValue);
            break;
          case 3:
            num = (int) (short) (int) jsonValue.longValue;
            break;
          case 4:
            num = jsonValue.longValue != 0L ? 1 : 0;
            break;
          default:
            string str = new StringBuilder().append("Value cannot be converted to short: ").append((object) jsonValue.type).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        numArray[index] = (short) num;
        jsonValue = jsonValue.next;
        ++index;
      }
      return numArray;
    }

    [LineNumberTable(596)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void mismatch([In] string obj0) => throw Throwable.__\u003Cunmap\u003E((Exception) this.typeMismatch(obj0));

    [LineNumberTable(new byte[] {161, 238, 127, 29, 108, 98, 141, 159, 11, 125, 130, 109, 130, 105, 130, 110, 130, 159, 11, 228, 46, 240, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char[] asCharArray()
    {
      if (!object.ReferenceEquals((object) this.type, (object) JsonValue.ValueType.__\u003C\u003Earray))
      {
        string str = new StringBuilder().append("Value is not an array: ").append((object) this.type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
      char[] chArray = new char[this.size];
      int index = 0;
      JsonValue jsonValue = this.child;
      while (jsonValue != null)
      {
        int num;
        switch (JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[jsonValue.type.ordinal()])
        {
          case 1:
            num = String.instancehelper_length(jsonValue.stringValue) != 0 ? (int) String.instancehelper_charAt(jsonValue.stringValue, 0) : 0;
            break;
          case 2:
            num = (int) (ushort) ByteCodeHelper.d2i(jsonValue.doubleValue);
            break;
          case 3:
            num = (int) (ushort) (int) jsonValue.longValue;
            break;
          case 4:
            num = jsonValue.longValue != 0L ? 1 : 0;
            break;
          default:
            string str = new StringBuilder().append("Value cannot be converted to char: ").append((object) jsonValue.type).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        chArray[index] = (char) num;
        jsonValue = jsonValue.next;
        ++index;
      }
      return chArray;
    }

    [LineNumberTable(636)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasChild(string name) => this.getChild(name) != null;

    [LineNumberTable(new byte[] {162, 39, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double getDouble(string name, double defaultValue)
    {
      JsonValue jsonValue = this.get(name);
      return jsonValue == null || !jsonValue.isValue() || jsonValue.isNull() ? defaultValue : jsonValue.asDouble();
    }

    [LineNumberTable(new byte[] {162, 45, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getLong(string name, long defaultValue)
    {
      JsonValue jsonValue = this.get(name);
      return jsonValue == null || !jsonValue.isValue() || jsonValue.isNull() ? defaultValue : jsonValue.asLong();
    }

    [LineNumberTable(new byte[] {158, 228, 162, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getBoolean(string name, bool defaultValue)
    {
      int num = defaultValue ? 1 : 0;
      JsonValue jsonValue = this.get(name);
      return jsonValue == null || !jsonValue.isValue() || jsonValue.isNull() ? num != 0 : jsonValue.asBoolean();
    }

    [LineNumberTable(new byte[] {158, 226, 99, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte getByte(string name, byte defaultValue)
    {
      int num = (int) (sbyte) defaultValue;
      JsonValue jsonValue = this.get(name);
      return jsonValue == null || !jsonValue.isValue() || jsonValue.isNull() ? (byte) num : jsonValue.asByte();
    }

    [LineNumberTable(new byte[] {158, 225, 162, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short getShort(string name, short defaultValue)
    {
      int num = (int) defaultValue;
      JsonValue jsonValue = this.get(name);
      return jsonValue == null || !jsonValue.isValue() || jsonValue.isNull() ? (short) num : jsonValue.asShort();
    }

    [LineNumberTable(new byte[] {158, 223, 98, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char getChar(string name, char defaultValue)
    {
      int num = (int) defaultValue;
      JsonValue jsonValue = this.get(name);
      return jsonValue == null || !jsonValue.isValue() || jsonValue.isNull() ? (char) num : jsonValue.asChar();
    }

    [LineNumberTable(new byte[] {162, 94, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFloat(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Named value not found: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asFloat();
    }

    [LineNumberTable(new byte[] {162, 104, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double getDouble(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Named value not found: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asDouble();
    }

    [LineNumberTable(new byte[] {162, 114, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getLong(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Named value not found: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asLong();
    }

    [LineNumberTable(new byte[] {162, 134, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getBoolean(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Named value not found: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asBoolean();
    }

    [LineNumberTable(new byte[] {162, 144, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte getByte(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Named value not found: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asByte();
    }

    [LineNumberTable(new byte[] {162, 154, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short getShort(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Named value not found: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asShort();
    }

    [LineNumberTable(new byte[] {162, 164, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char getChar(string name)
    {
      JsonValue jsonValue = this.get(name);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Named value not found: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asChar();
    }

    [LineNumberTable(new byte[] {162, 174, 104, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Indexed value not found: ").append(this.name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asString();
    }

    [LineNumberTable(new byte[] {162, 184, 104, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFloat(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Indexed value not found: ").append(this.name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asFloat();
    }

    [LineNumberTable(new byte[] {162, 194, 104, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double getDouble(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Indexed value not found: ").append(this.name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asDouble();
    }

    [LineNumberTable(new byte[] {162, 204, 104, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getLong(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Indexed value not found: ").append(this.name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asLong();
    }

    [LineNumberTable(new byte[] {162, 214, 104, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Indexed value not found: ").append(this.name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asInt();
    }

    [LineNumberTable(new byte[] {162, 224, 104, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getBoolean(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Indexed value not found: ").append(this.name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asBoolean();
    }

    [LineNumberTable(new byte[] {162, 234, 104, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte getByte(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Indexed value not found: ").append(this.name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asByte();
    }

    [LineNumberTable(new byte[] {162, 244, 104, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short getShort(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Indexed value not found: ").append(this.name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asShort();
    }

    [LineNumberTable(new byte[] {162, 254, 104, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char getChar(int index)
    {
      JsonValue jsonValue = this.get(index);
      if (jsonValue == null)
      {
        string str = new StringBuilder().append("Indexed value not found: ").append(this.name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return jsonValue.asChar();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue.ValueType type() => this.type;

    [LineNumberTable(new byte[] {163, 8, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setType(JsonValue.ValueType type)
    {
      if (type == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("type cannot be null.");
      }
      this.type = type;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue parent() => this.parent;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue child() => this.child;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue next() => this.next;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setNext(JsonValue next) => this.next = next;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue prev() => this.prev;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPrev(JsonValue prev) => this.prev = prev;

    [LineNumberTable(new byte[] {163, 218, 127, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (!this.isValue())
        return new StringBuilder().append(this.name != null ? new StringBuilder().append(this.name).append(": ").toString() : "").append(this.prettyPrint(JsonWriter.OutputType.__\u003C\u003Eminimal, 0)).toString();
      return this.name == null ? this.asString() : new StringBuilder().append(this.name).append(": ").append(this.asString()).toString();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 55, 102, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void prettyPrint(JsonWriter.OutputType outputType, Writer writer) => this.prettyPrint(this, writer, 0, new JsonValue.PrettyPrintSettings()
    {
      outputType = outputType
    });

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    Iterator Iterable.__\u003Coverridestub\u003Ejava\u002Elang\u002EIterable\u003A\u003Aiterator() => this.\u003Cbridge\u003Eiterator();

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(185)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.JsonValue$1"))
          return;
        JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType = new int[JsonValue.ValueType.values().Length];
        try
        {
          JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[JsonValue.ValueType.__\u003C\u003EstringValue.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[JsonValue.ValueType.__\u003C\u003EdoubleValue.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[JsonValue.ValueType.__\u003C\u003ElongValue.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[JsonValue.ValueType.__\u003C\u003EbooleanValue.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          JsonValue.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonValue\u0024ValueType[JsonValue.ValueType.__\u003C\u003EnullValue.ordinal()] = 5;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [Signature("Ljava/lang/Object;Ljava/util/Iterator<Larc/util/serialization/JsonValue;>;Ljava/lang/Iterable<Larc/util/serialization/JsonValue;>;")]
    [Implements(new string[] {"java.util.Iterator", "java.lang.Iterable"})]
    public class JsonIterator : Object, Iterator, Iterable, IEnumerable
    {
      internal JsonValue entry;
      internal JsonValue current;
      [Modifiers]
      internal JsonValue this\u00240;

      [LineNumberTable(new byte[] {164, 154, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JsonIterator(JsonValue _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        JsonValue.JsonIterator jsonIterator = this;
        this.entry = this.this\u00240.child;
      }

      [LineNumberTable(new byte[] {164, 163, 108, 115, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual JsonValue next()
      {
        this.current = this.entry;
        if (this.current == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        this.entry = this.current.next;
        return this.current;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext() => this.entry != null;

      [LineNumberTable(new byte[] {164, 170, 109, 118, 159, 1, 123, 159, 9, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        if (this.current.prev == null)
        {
          this.this\u00240.child = this.current.next;
          if (this.this\u00240.child != null)
            this.this\u00240.child.prev = (JsonValue) null;
        }
        else
        {
          this.current.prev.next = this.current.next;
          if (this.current.next != null)
            this.current.next.prev = this.current.prev;
        }
        --this.this\u00240.size;
      }

      [Signature("()Ljava/util/Iterator<Larc/util/serialization/JsonValue;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) this;

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(1292)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Enext() => (object) this.next();

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

      object Iterator.__\u003Coverridestub\u003Ejava\u002Eutil\u002EIterator\u003A\u003Anext() => this.\u003Cbridge\u003Enext();
    }

    public class PrettyPrintSettings : Object
    {
      public JsonWriter.OutputType outputType;
      public int singleLineColumns;
      public bool wrapNumericArrays;

      [LineNumberTable(1282)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PrettyPrintSettings()
      {
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/util/serialization/JsonValue$ValueType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ValueType : Enum
    {
      [Modifiers]
      internal static JsonValue.ValueType __\u003C\u003Eobject;
      [Modifiers]
      internal static JsonValue.ValueType __\u003C\u003Earray;
      [Modifiers]
      internal static JsonValue.ValueType __\u003C\u003EstringValue;
      [Modifiers]
      internal static JsonValue.ValueType __\u003C\u003EdoubleValue;
      [Modifiers]
      internal static JsonValue.ValueType __\u003C\u003ElongValue;
      [Modifiers]
      internal static JsonValue.ValueType __\u003C\u003EbooleanValue;
      [Modifiers]
      internal static JsonValue.ValueType __\u003C\u003EnullValue;
      [Modifiers]
      private static JsonValue.ValueType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(1278)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static JsonValue.ValueType[] values() => (JsonValue.ValueType[]) JsonValue.ValueType.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(1278)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ValueType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(1278)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static JsonValue.ValueType valueOf(string name) => (JsonValue.ValueType) Enum.valueOf((Class) ClassLiteral<JsonValue.ValueType>.Value, name);

      [LineNumberTable(new byte[] {158, 79, 173, 63, 81})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ValueType()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.JsonValue$ValueType"))
          return;
        JsonValue.ValueType.__\u003C\u003Eobject = new JsonValue.ValueType(nameof (@object), 0);
        JsonValue.ValueType.__\u003C\u003Earray = new JsonValue.ValueType(nameof (array), 1);
        JsonValue.ValueType.__\u003C\u003EstringValue = new JsonValue.ValueType(nameof (stringValue), 2);
        JsonValue.ValueType.__\u003C\u003EdoubleValue = new JsonValue.ValueType(nameof (doubleValue), 3);
        JsonValue.ValueType.__\u003C\u003ElongValue = new JsonValue.ValueType(nameof (longValue), 4);
        JsonValue.ValueType.__\u003C\u003EbooleanValue = new JsonValue.ValueType(nameof (booleanValue), 5);
        JsonValue.ValueType.__\u003C\u003EnullValue = new JsonValue.ValueType(nameof (nullValue), 6);
        JsonValue.ValueType.\u0024VALUES = new JsonValue.ValueType[7]
        {
          JsonValue.ValueType.__\u003C\u003Eobject,
          JsonValue.ValueType.__\u003C\u003Earray,
          JsonValue.ValueType.__\u003C\u003EstringValue,
          JsonValue.ValueType.__\u003C\u003EdoubleValue,
          JsonValue.ValueType.__\u003C\u003ElongValue,
          JsonValue.ValueType.__\u003C\u003EbooleanValue,
          JsonValue.ValueType.__\u003C\u003EnullValue
        };
      }

      [Modifiers]
      public static JsonValue.ValueType @object
      {
        [HideFromJava] get => JsonValue.ValueType.__\u003C\u003Eobject;
      }

      [Modifiers]
      public static JsonValue.ValueType array
      {
        [HideFromJava] get => JsonValue.ValueType.__\u003C\u003Earray;
      }

      [Modifiers]
      public static JsonValue.ValueType stringValue
      {
        [HideFromJava] get => JsonValue.ValueType.__\u003C\u003EstringValue;
      }

      [Modifiers]
      public static JsonValue.ValueType doubleValue
      {
        [HideFromJava] get => JsonValue.ValueType.__\u003C\u003EdoubleValue;
      }

      [Modifiers]
      public static JsonValue.ValueType longValue
      {
        [HideFromJava] get => JsonValue.ValueType.__\u003C\u003ElongValue;
      }

      [Modifiers]
      public static JsonValue.ValueType booleanValue
      {
        [HideFromJava] get => JsonValue.ValueType.__\u003C\u003EbooleanValue;
      }

      [Modifiers]
      public static JsonValue.ValueType nullValue
      {
        [HideFromJava] get => JsonValue.ValueType.__\u003C\u003EnullValue;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        @object,
        array,
        stringValue,
        doubleValue,
        longValue,
        booleanValue,
        nullValue,
      }
    }
  }
}
