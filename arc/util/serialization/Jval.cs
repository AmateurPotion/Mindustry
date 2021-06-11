// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.Jval
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.regex;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.serialization
{
  public class Jval : Object
  {
    [Modifiers]
    internal static string eol;
    internal static Jval __\u003C\u003ETRUE;
    internal static Jval __\u003C\u003EFALSE;
    internal static Jval __\u003C\u003ENULL;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private object value;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {11, 127, 2, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Jval read(string text)
    {
      Jval jval;
      IOException ioException1;
      try
      {
        jval = new Jval.Hparser(text).parse();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return jval;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {160, 105, 134, 218, 226, 61, 129, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(Jval.Jformat format)
    {
      StringWriter stringWriter = new StringWriter();
      IOException ioException1;
      try
      {
        this.writeTo((Writer) stringWriter, format);
        goto label_4;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
label_4:
      return stringWriter.toString();
    }

    [LineNumberTable(new byte[] {107, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(string name, string defaultValue)
    {
      Jval jval = this.get(name);
      return jval != null && !jval.isNull() ? jval.asString() : defaultValue;
    }

    [LineNumberTable(new byte[] {54, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Jval get(string name)
    {
      if (name == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("name is null");
      }
      return (Jval) this.asObject().get((object) name);
    }

    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Jval.JsonArray asArray()
    {
      if (!(this.value is Jval.JsonArray))
      {
        string str = new StringBuilder().append("Not an array: ").append(this.toString()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(str);
      }
      return (Jval.JsonArray) this.value;
    }

    [LineNumberTable(new byte[] {73, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(string name)
    {
      if (name == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("name is null");
      }
      return this.asObject().containsKey((object) name);
    }

    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isArray() => this.value is Jval.JsonArray;

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string asString()
    {
      if (!(this.value is string) && !(this.value is Number))
      {
        string str = new StringBuilder().append("Not a string: ").append(this.toString()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(str);
      }
      return String.valueOf(this.value);
    }

    [LineNumberTable(153)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(string name) => this.getString(name, "");

    [LineNumberTable(new byte[] {19, 114, 116, 116, 116, 116, 245, 59})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Jval.Jtype getType()
    {
      if (this.value == null)
        return Jval.Jtype.__\u003C\u003Enil;
      if (this.value is Number)
        return Jval.Jtype.__\u003C\u003Enumber;
      if (this.value is string)
        return Jval.Jtype.__\u003C\u003Estring;
      if (this.value is Boolean)
        return Jval.Jtype.__\u003C\u003Ebool;
      if (this.value is Jval.JsonMap)
        return Jval.Jtype.__\u003C\u003Eobject;
      return this.value is Jval.JsonArray ? Jval.Jtype.__\u003C\u003Earray : (Jval.Jtype) null;
    }

    [LineNumberTable(new byte[] {159, 163, 104, 135, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Jval([In] object obj0)
    {
      Jval jval = this;
      this.value = obj0;
      if (this.getType() == null)
      {
        string str = new StringBuilder().append("Invalid JSON value: ").append(obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 88, 103, 127, 9, 102, 159, 75, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      Jval.Jtype type = this.getType();
      switch (Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype[type.ordinal()])
      {
        case 1:
          return "null";
        case 2:
          string str1;
          if (String.instancehelper_endsWith(Object.instancehelper_toString(this.value), ".0"))
          {
            string str2 = Object.instancehelper_toString(this.value);
            object obj1 = (object) "";
            object obj2 = (object) ".0";
            CharSequence charSequence1;
            charSequence1.__\u003Cref\u003E = (__Null) obj2;
            CharSequence charSequence2 = charSequence1;
            object obj3 = obj1;
            charSequence1.__\u003Cref\u003E = (__Null) obj3;
            CharSequence charSequence3 = charSequence1;
            str1 = String.instancehelper_replace(str2, charSequence2, charSequence3);
          }
          else
            str1 = Object.instancehelper_toString(this.value);
          return String.instancehelper_replace(str1, 'E', 'e');
        case 3:
        case 4:
          return Object.instancehelper_toString(this.value);
        default:
          return this.toString(Jval.Jformat.__\u003C\u003Eplain);
      }
    }

    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Number asNumber()
    {
      if (!(this.value is Number))
      {
        string str = new StringBuilder().append("Not a number: ").append(this.toString()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(str);
      }
      return (Number) this.value;
    }

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Jval.JsonMap asObject()
    {
      if (!(this.value is Jval.JsonMap))
      {
        string str = new StringBuilder().append("Not an object: ").append(this.toString()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(str);
      }
      return (Jval.JsonMap) this.value;
    }

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Jval valueOf(string @string) => @string == null ? Jval.__\u003C\u003ENULL : new Jval((object) @string);

    [LineNumberTable(new byte[] {59, 115, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(string name, Jval val)
    {
      if (name == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("name is null");
      }
      this.asObject().put((object) name, (object) val);
    }

    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int asInt() => this.asNumber().intValue();

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long asLong() => this.asNumber().longValue();

    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float asFloat() => this.asNumber().floatValue();

    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double asDouble() => this.asNumber().doubleValue();

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool asBool()
    {
      if (!(this.value is Boolean))
      {
        string str = new StringBuilder().append("Not a bool: ").append(this.toString()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(str);
      }
      return ((Boolean) this.value).booleanValue();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNull() => this.value == null;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 70, 108, 159, 2, 110, 130, 110, 130, 179, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeTo(Writer writer, Jval.Jformat format)
    {
      Jval.WritingBuffer writingBuffer = new Jval.WritingBuffer(writer, 128);
      switch (Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jformat[format.ordinal()])
      {
        case 1:
          new Jval.Jwriter(false).save(this, (Writer) writingBuffer, 0);
          break;
        case 2:
          new Jval.Jwriter(true).save(this, (Writer) writingBuffer, 0);
          break;
        case 3:
          new Jval.Hwriter().save(this, (Writer) writingBuffer, -1, "", true);
          break;
      }
      writingBuffer.flush();
    }

    [LineNumberTable(new byte[] {159, 182, 127, 2, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Jval read(Reader reader)
    {
      Jval jval;
      IOException ioException1;
      try
      {
        jval = new Jval.Hparser(reader).parse();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return jval;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {159, 190, 127, 12, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Jval read(byte[] bytes)
    {
      Jval jval;
      IOException ioException1;
      try
      {
        jval = new Jval.Hparser((Reader) new InputStreamReader((InputStream) new ByteArrayInputStream(bytes))).parse();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return jval;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException((Exception) ioException2);
    }

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Jval valueOf(int value) => new Jval((object) Integer.valueOf(value));

    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Jval valueOf(long value) => new Jval((object) Long.valueOf(value));

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Jval valueOf(float value) => new Jval((object) Float.valueOf(value));

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Jval valueOf(double value) => new Jval((object) Double.valueOf(value));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Jval valueOf(bool value) => value ? Jval.__\u003C\u003ETRUE : Jval.__\u003C\u003EFALSE;

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isObject() => this.value is Jval.JsonMap;

    [LineNumberTable(86)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNumber() => this.value is Number;

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isString() => this.value is Structs;

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBoolean() => this.value is Boolean;

    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTrue() => object.ReferenceEquals(this.value, (object) Boolean.TRUE);

    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isFalse() => object.ReferenceEquals(this.value, (object) Boolean.FALSE);

    [LineNumberTable(new byte[] {64, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(string name, string val) => this.add(name, Jval.valueOf(val));

    [LineNumberTable(new byte[] {68, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Jval remove(string name)
    {
      if (name == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("name is null");
      }
      return (Jval) this.asObject().removeKey((object) name);
    }

    [LineNumberTable(new byte[] {78, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(string name, int defaultValue)
    {
      Jval jval = this.get(name);
      return jval != null ? jval.asInt() : defaultValue;
    }

    [LineNumberTable(new byte[] {83, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getLong(string name, long defaultValue)
    {
      Jval jval = this.get(name);
      return jval != null ? jval.asLong() : defaultValue;
    }

    [LineNumberTable(new byte[] {88, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFloat(string name, float defaultValue)
    {
      Jval jval = this.get(name);
      return jval != null ? jval.asFloat() : defaultValue;
    }

    [LineNumberTable(new byte[] {93, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double getDouble(string name, double defaultValue)
    {
      Jval jval = this.get(name);
      return jval != null ? jval.asDouble() : defaultValue;
    }

    [LineNumberTable(new byte[] {159, 105, 66, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getBool(string name, bool defaultValue)
    {
      int num = defaultValue ? 1 : 0;
      Jval jval = this.get(name);
      return jval != null ? jval.asBool() : num != 0;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {121, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeTo(Writer writer) => this.writeTo(writer, Jval.Jformat.__\u003C\u003Eplain);

    [LineNumberTable(new byte[] {160, 117, 159, 50, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object @object) => @object != null && object.ReferenceEquals((object) @object.GetType(), (object) ((object) this).GetType()) && (this.value == null && ((Jval) @object).value == null || ((Jval) @object).value != null && this.value != null && Object.instancehelper_equals(this.value, ((Jval) @object).value));

    [LineNumberTable(new byte[] {159, 139, 77, 143, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Jval()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.Jval"))
        return;
      Jval.eol = java.lang.System.getProperty("line.separator");
      Jval.__\u003C\u003ETRUE = new Jval((object) Boolean.valueOf(true));
      Jval.__\u003C\u003EFALSE = new Jval((object) Boolean.valueOf(false));
      Jval.__\u003C\u003ENULL = new Jval((object) null);
    }

    [Modifiers]
    public static Jval TRUE
    {
      [HideFromJava] get => Jval.__\u003C\u003ETRUE;
    }

    [Modifiers]
    public static Jval FALSE
    {
      [HideFromJava] get => Jval.__\u003C\u003EFALSE;
    }

    [Modifiers]
    public static Jval NULL
    {
      [HideFromJava] get => Jval.__\u003C\u003ENULL;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jformat;
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 92, 173, 255, 160, 167, 46})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.Jval$1"))
          return;
        Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype = new int[Jval.Jtype.values().Length];
        try
        {
          Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype[Jval.Jtype.__\u003C\u003Enil.ordinal()] = 1;
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
          Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype[Jval.Jtype.__\u003C\u003Enumber.ordinal()] = 2;
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
          Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype[Jval.Jtype.__\u003C\u003Estring.ordinal()] = 3;
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
          Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype[Jval.Jtype.__\u003C\u003Ebool.ordinal()] = 4;
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
          Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype[Jval.Jtype.__\u003C\u003Eobject.ordinal()] = 5;
          goto label_22;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_22:
        try
        {
          Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype[Jval.Jtype.__\u003C\u003Earray.ordinal()] = 6;
          goto label_26;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_26:
        Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jformat = new int[Jval.Jformat.values().Length];
        try
        {
          Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jformat[Jval.Jformat.__\u003C\u003Eplain.ordinal()] = 1;
          goto label_31;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_31:
        try
        {
          Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jformat[Jval.Jformat.__\u003C\u003Eformatted.ordinal()] = 2;
          goto label_35;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_35:
        try
        {
          Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jformat[Jval.Jformat.__\u003C\u003Ehjson.ordinal()] = 3;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    internal class Hparser : Object
    {
      [Modifiers]
      private string buffer;
      private Reader reader;
      private int index;
      private int line;
      private int lineOffset;
      private int current;
      private StringBuilder captureBuffer;
      private StringBuilder peek;
      private bool capture;
      private bool isArray;

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 229, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Hparser([In] Reader obj0)
        : this(Jval.Hparser.readToEnd(obj0))
      {
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 1, 103, 134, 185, 205, 127, 9, 129, 102, 103, 134, 127, 6, 129})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual Jval parse()
      {
        this.read();
        this.skipWhiteSpace();
        switch (this.current)
        {
          case 91:
          case 123:
            return this.checkTrailing(this.readValue());
          default:
            Jval jval1;
            Exception exception1;
            try
            {
              jval1 = this.checkTrailing(this.readObject(true));
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
                goto label_7;
              }
            }
            return jval1;
label_7:
            Exception exception2 = exception1;
            this.reset();
            this.read();
            this.skipWhiteSpace();
            Jval jval2;
            try
            {
              jval2 = this.checkTrailing(this.readValue());
            }
            catch (Exception ex)
            {
              if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
                throw;
              else
                goto label_12;
            }
            return jval2;
label_12:
            throw Throwable.__\u003Cunmap\u003E((Exception) exception2);
        }
      }

      [LineNumberTable(new byte[] {160, 223, 104, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Hparser([In] string obj0)
      {
        Jval.Hparser hparser = this;
        this.buffer = obj0;
        this.reset();
      }

      [LineNumberTable(new byte[] {160, 246, 125, 103, 107, 113, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void reset()
      {
        Jval.Hparser hparser1 = this;
        Jval.Hparser hparser2 = this;
        int num1 = 0;
        int num2 = num1;
        this.current = num1;
        int num3 = num2;
        int num4 = num3;
        this.lineOffset = num3;
        this.index = num4;
        this.line = 1;
        this.peek = new StringBuilder();
        this.reader = (Reader) new StringReader(this.buffer);
        this.capture = false;
        this.captureBuffer = (StringBuilder) null;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 235, 107, 102, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static string readToEnd([In] Reader obj0)
      {
        char[] chArray = new char[8192];
        StringBuilder stringBuilder = new StringBuilder();
        int num;
        while ((num = obj0.read(chArray, 0, chArray.Length)) != -1)
          stringBuilder.append(chArray, 0, num);
        return stringBuilder.toString();
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {162, 125, 106, 110, 172, 142, 114, 111, 145, 139, 110, 155})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool read()
      {
        if (this.current == 10)
        {
          ++this.line;
          this.lineOffset = this.index;
        }
        if (this.peek.length() > 0)
        {
          this.current = (int) this.peek.charAt(0);
          this.peek.deleteCharAt(0);
        }
        else
          this.current = this.reader.read();
        if (this.current < 0)
          return false;
        ++this.index;
        if (this.capture)
          this.captureBuffer.append((char) this.current);
        return true;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {162, 93, 107, 113, 158, 103, 117, 116, 135, 103, 125, 103, 172})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void skipWhiteSpace()
      {
        while (!this.isEndOfText())
        {
          while (this.isWhiteSpace())
            this.read();
          if (this.current == 35 || this.current == 47 && this.peek() == 47)
          {
label_4:
            this.read();
            if (this.current >= 0 && this.current != 10)
              goto label_4;
          }
          else
          {
            if (this.current != 47 || this.peek() != 42)
              break;
            this.read();
            do
            {
              this.read();
            }
            while (this.current >= 0 && (this.current != 42 || this.peek() != 47));
            this.read();
            this.read();
          }
        }
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 33, 191, 10, 135, 135, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Jval readValue()
      {
        switch (this.current)
        {
          case 34:
          case 39:
            return this.readString();
          case 91:
            return this.readArray();
          case 123:
            return this.readObject(false);
          default:
            return this.readTfnns();
        }
      }

      [Throws(new string[] {"arc.util.serialization.Jval$JsonParseException", "java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 27, 102, 127, 20})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual Jval checkTrailing([In] Jval obj0)
      {
        this.skipWhiteSpace();
        if (!this.isEndOfText())
          throw Throwable.__\u003Cunmap\u003E((Exception) this.error(new StringBuilder().append("Extra characters in input: ").append(this.current).toString()));
        return obj0;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {159, 22, 66, 106, 102, 134, 99, 141, 121, 140, 103, 102, 106, 145, 102, 110, 102, 112, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Jval readObject([In] bool obj0)
      {
        int num = obj0 ? 1 : 0;
        if (num == 0)
          this.read();
        Jval.JsonMap jsonMap = new Jval.JsonMap();
        this.skipWhiteSpace();
        while (true)
        {
          do
          {
            if (num != 0)
            {
              if (this.isEndOfText())
                goto label_12;
            }
            else
            {
              if (this.isEndOfText())
                throw Throwable.__\u003Cunmap\u003E((Exception) this.error("End of input while parsing an object (did you forget a closing '}'?)"));
              if (this.readIf('}'))
                goto label_12;
            }
            string str = this.readName();
            this.skipWhiteSpace();
            if (!this.readIf(':'))
              throw Throwable.__\u003Cunmap\u003E((Exception) this.expected("':'"));
            this.skipWhiteSpace();
            jsonMap.put((object) str, (object) this.readValue());
            this.skipWhiteSpace();
          }
          while (!this.readIf(','));
          this.skipWhiteSpace();
        }
label_12:
        return new Jval((object) jsonMap);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool isEndOfText() => this.current == -1;

      [LineNumberTable(new byte[] {162, 178, 110, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Jval.JsonParseException error([In] string obj0)
      {
        int num1 = this.index - this.lineOffset;
        int num2 = !this.isEndOfText() ? this.index - 1 : this.index;
        return new Jval.JsonParseException(obj0, num2, this.line, num1 - 1);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(582)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Jval readString()
      {
        Jval.__\u003Cclinit\u003E();
        return new Jval((object) this.readStringInternal(true));
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 90, 103, 103, 102, 102, 106, 167, 102, 108, 102, 112, 108, 153, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Jval readArray()
      {
        this.isArray = true;
        this.read();
        Jval.JsonArray jsonArray = new Jval.JsonArray();
        this.skipWhiteSpace();
        if (this.readIf(']'))
          return new Jval((object) jsonArray);
        do
        {
          this.skipWhiteSpace();
          jsonArray.add((object) this.readValue());
          this.skipWhiteSpace();
          if (this.readIf(','))
            this.skipWhiteSpace();
          if (this.readIf(']'))
            goto label_7;
        }
        while (!this.isEndOfText());
        throw Throwable.__\u003Cunmap\u003E((Exception) this.error("End of input while parsing an array (did you forget a closing ']'?)"));
label_7:
        this.isArray = false;
        return new Jval((object) jsonArray);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 49, 102, 103, 104, 127, 18, 142, 103, 127, 31, 159, 38, 223, 0, 108, 127, 94, 102, 102, 134, 130, 111, 105, 167, 131, 123, 174, 182, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Jval readTfnns()
      {
        StringBuilder stringBuilder = new StringBuilder();
        int current = this.current;
        if (Jval.Hwriter.isPunctuatorChar(current))
          throw Throwable.__\u003Cunmap\u003E((Exception) this.error(new StringBuilder().append("Found a punctuator character '").append((char) current).append("' when expecting a quoteless string (check your syntax)").toString()));
        stringBuilder.append((char) this.current);
        Jval number;
        while (true)
        {
          this.read();
          int num1 = this.current < 0 || this.current == 13 || this.current == 10 || (this.current == 44 && this.isArray || this.current == 93) ? 1 : 0;
          if (num1 != 0 || this.current == 44 || (this.current == 125 || this.current == 35) || this.current == 47 && (this.peek() == 47 || this.peek() == 42))
          {
            switch (current)
            {
              case 102:
              case 110:
              case 116:
                string str = String.instancehelper_trim(stringBuilder.toString());
                int num2 = -1;
                switch (String.instancehelper_hashCode(str))
                {
                  case 3392903:
                    if (String.instancehelper_equals(str, (object) "null"))
                    {
                      num2 = 1;
                      break;
                    }
                    break;
                  case 3569038:
                    if (String.instancehelper_equals(str, (object) "true"))
                    {
                      num2 = 2;
                      break;
                    }
                    break;
                  case 97196323:
                    if (String.instancehelper_equals(str, (object) "false"))
                    {
                      num2 = 0;
                      break;
                    }
                    break;
                }
                switch (num2)
                {
                  case 0:
                    goto label_14;
                  case 1:
                    goto label_15;
                  case 2:
                    goto label_16;
                }
                break;
              default:
                if (current == 45 || current >= 48 && current <= 57)
                {
                  number = Jval.Hparser.tryParseNumber(stringBuilder, false);
                  if (number == null)
                    break;
                  goto label_18;
                }
                else
                  break;
            }
            if (num1 != 0)
              goto label_20;
          }
          stringBuilder.append((char) this.current);
        }
label_14:
        return Jval.__\u003C\u003EFALSE;
label_15:
        return Jval.__\u003C\u003ENULL;
label_16:
        return Jval.__\u003C\u003ETRUE;
label_18:
        return number;
label_20:
        if (stringBuilder.length() > 0 && stringBuilder.charAt(stringBuilder.length() - 1) == ',')
          stringBuilder.setLength(stringBuilder.length() - 1);
        Jval.__\u003Cclinit\u003E();
        return new Jval((object) String.instancehelper_trim(stringBuilder.toString()));
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(746)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int peek() => this.peek(0);

      [LineNumberTable(new byte[] {158, 235, 130, 105, 147, 102, 108, 138, 119, 130, 184, 111, 100, 120, 216, 122, 100, 158, 120, 184, 99, 152, 99, 141, 105, 127, 31, 163, 106, 139, 159, 68, 127, 9, 193})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static Jval tryParseNumber([In] StringBuilder obj0, [In] bool obj1)
      {
        int num1 = obj1 ? 1 : 0;
        int num2 = 0;
        int num3 = obj0.length();
        if (num2 < num3 && obj0.charAt(num2) == '-')
          ++num2;
        if (num2 >= num3)
          return (Jval) null;
        StringBuilder stringBuilder1 = obj0;
        int num4 = num2;
        int num5 = num2 + 1;
        int num6 = (int) stringBuilder1.charAt(num4);
        if (!Jval.Hparser.isDigit((char) num6))
          return (Jval) null;
        if (num6 == 48 && num5 < num3 && Jval.Hparser.isDigit(obj0.charAt(num5)))
          return (Jval) null;
        while (num5 < num3 && Jval.Hparser.isDigit(obj0.charAt(num5)))
          ++num5;
        if (num5 < num3 && obj0.charAt(num5) == '.')
        {
          int num7 = num5 + 1;
          if (num7 < num3)
          {
            StringBuilder stringBuilder2 = obj0;
            int num8 = num7;
            num5 = num7 + 1;
            if (Jval.Hparser.isDigit(stringBuilder2.charAt(num8)))
            {
              while (num5 < num3 && Jval.Hparser.isDigit(obj0.charAt(num5)))
                ++num5;
              goto label_16;
            }
          }
          return (Jval) null;
        }
label_16:
        if (num5 < num3 && Character.toLowerCase(obj0.charAt(num5)) == 'e')
        {
          int num7 = num5 + 1;
          if (num7 < num3 && (obj0.charAt(num7) == '+' || obj0.charAt(num7) == '-'))
            ++num7;
          if (num7 < num3)
          {
            StringBuilder stringBuilder2 = obj0;
            int num8 = num7;
            num5 = num7 + 1;
            if (Jval.Hparser.isDigit(stringBuilder2.charAt(num8)))
            {
              while (num5 < num3 && Jval.Hparser.isDigit(obj0.charAt(num5)))
                ++num5;
              goto label_24;
            }
          }
          return (Jval) null;
        }
label_24:
        int num9 = num5;
        while (num5 < num3 && Jval.Hparser.isWhiteSpace((int) obj0.charAt(num5)))
          ++num5;
        int num10 = 0;
        if (num5 < num3 && num1 != 0)
        {
          switch (obj0.charAt(num5))
          {
            case '#':
            case ',':
            case ']':
            case '}':
              num10 = 1;
              break;
            case '/':
              if (num3 <= num5 + 1 || obj0.charAt(num5 + 1) != '/' && obj0.charAt(num5 + 1) != '*')
                break;
              goto case '#';
          }
        }
        if (num5 < num3 && num10 == 0)
          return (Jval) null;
        string str1 = obj0.substring(0, num9);
        string str2 = str1;
        object obj2 = (object) ".";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        if (!String.instancehelper_contains(str2, charSequence2))
        {
          string str3 = str1;
          object obj3 = (object) ",";
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence3 = charSequence1;
          if (!String.instancehelper_contains(str3, charSequence3))
          {
            string str4 = str1;
            object obj4 = (object) "e";
            charSequence1.__\u003Cref\u003E = (__Null) obj4;
            CharSequence charSequence4 = charSequence1;
            if (!String.instancehelper_contains(str4, charSequence4))
            {
              Jval jval;
              try
              {
                Jval.__\u003Cclinit\u003E();
                jval = new Jval((object) Long.valueOf(Long.parseLong(str1)));
              }
              catch (NumberFormatException ex)
              {
                goto label_39;
              }
              return jval;
label_39:;
            }
          }
        }
        Jval.__\u003Cclinit\u003E();
        return new Jval((object) Double.valueOf(Double.parseDouble(str1)));
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {158, 221, 162, 105, 130, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool readIf([In] char obj0)
      {
        if (this.current != (int) obj0)
          return false;
        this.read();
        return true;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 134, 156, 102, 137, 106, 121, 109, 105, 145, 103, 109, 112, 106, 113, 109, 127, 23, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private string readName()
      {
        if (this.current == 34 || this.current == 39)
          return this.readStringInternal(false);
        StringBuilder stringBuilder = new StringBuilder();
        int num = -1;
        int index = this.index;
        while (this.current != 58)
        {
          if (Jval.Hparser.isWhiteSpace(this.current))
          {
            if (num < 0)
              num = stringBuilder.length();
          }
          else
          {
            if (this.current < 32)
              throw Throwable.__\u003Cunmap\u003E((Exception) this.error("Name is not closed"));
            if (Jval.Hwriter.isPunctuatorChar(this.current))
              throw Throwable.__\u003Cunmap\u003E((Exception) this.error(new StringBuilder().append("Found '").append((char) this.current).append("' where a key name was expected (check your syntax or use quotes if the key name includes {}[],: or whitespace)").toString()));
            stringBuilder.append((char) this.current);
          }
          this.read();
        }
        if (stringBuilder.length() == 0)
          throw Throwable.__\u003Cunmap\u003E((Exception) this.error("Found ':' but no key name (for an empty key name use quotes)"));
        if (num >= 0 && num != stringBuilder.length())
        {
          this.index = index + num;
          throw Throwable.__\u003Cunmap\u003E((Exception) this.error("Found whitespace in your key name (use quotes to include)"));
        }
        return stringBuilder.toString();
      }

      [LineNumberTable(new byte[] {162, 171, 104, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Jval.JsonParseException expected([In] string obj0) => this.isEndOfText() ? this.error("Unexpected end of input") : this.error(new StringBuilder().append("Expected ").append(obj0).toString());

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {158, 252, 162, 103, 103, 102, 114, 146, 137, 103, 135, 154, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private string readStringInternal([In] bool obj0)
      {
        int num = obj0 ? 1 : 0;
        int current = this.current;
        this.read();
        this.startCapture();
        while (this.current >= 0 && this.current != current)
        {
          if (this.current == 92)
            this.readEscape();
          else
            this.read();
        }
        string str = this.endCapture();
        this.read();
        if (num == 0 || current != 39 || (this.current != 39 || String.instancehelper_length(str) != 0))
          return str;
        this.read();
        return this.readMlString();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool isWhiteSpace([In] int obj0) => obj0 == 32 || obj0 == 9 || (obj0 == 10 || obj0 == 13);

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 205, 105, 191, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void skipIndent([In] int obj0)
      {
        while (true)
        {
          int num = obj0;
          obj0 += -1;
          if (num > 0 && Jval.Hparser.isWhiteSpace(this.current) && this.current != 10)
            this.read();
          else
            break;
        }
      }

      [LineNumberTable(new byte[] {162, 145, 104, 107, 103, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void startCapture()
      {
        if (this.captureBuffer == null)
          this.captureBuffer = new StringBuilder();
        this.capture = true;
        this.captureBuffer.append((char) this.current);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 236, 102, 103, 255, 75, 70, 115, 133, 109, 133, 110, 133, 110, 133, 110, 133, 110, 133, 103, 102, 103, 104, 145, 234, 59, 230, 71, 122, 130, 145, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void readEscape()
      {
        this.pauseCapture();
        this.read();
        switch (this.current)
        {
          case 34:
          case 35:
          case 39:
          case 47:
          case 92:
            this.captureBuffer.append((char) this.current);
            break;
          case 98:
            this.captureBuffer.append('\b');
            break;
          case 102:
            this.captureBuffer.append('\f');
            break;
          case 110:
            this.captureBuffer.append('\n');
            break;
          case 114:
            this.captureBuffer.append('\r');
            break;
          case 116:
            this.captureBuffer.append('\t');
            break;
          case 117:
            char[] chArray = new char[4];
            for (int index = 0; index < 4; ++index)
            {
              this.read();
              if (!this.isHexDigit())
                throw Throwable.__\u003Cunmap\u003E((Exception) this.expected("hexadecimal digit"));
              chArray[index] = (char) this.current;
            }
            this.captureBuffer.append((char) Integer.parseInt(String.newhelper(chArray), 16));
            break;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) this.expected("valid escape sequence"));
        }
        this.capture = true;
        this.read();
      }

      [LineNumberTable(new byte[] {162, 158, 134, 110, 108, 142, 134, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private string endCapture()
      {
        this.pauseCapture();
        string str;
        if (this.captureBuffer.length() > 0)
        {
          str = this.captureBuffer.toString();
          this.captureBuffer.setLength(0);
        }
        else
          str = "";
        this.capture = false;
        return str;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 160, 102, 162, 208, 191, 1, 106, 103, 231, 69, 122, 106, 100, 103, 100, 159, 2, 167, 100, 105, 166, 106, 105, 103, 140, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private string readMlString()
      {
        StringBuilder stringBuilder = new StringBuilder();
        int num1 = 0;
        int num2 = this.index - this.lineOffset - 4;
        while (Jval.Hparser.isWhiteSpace(this.current) && this.current != 10)
          this.read();
        if (this.current == 10)
        {
          this.read();
          this.skipIndent(num2);
        }
        while (this.current >= 0)
        {
          if (this.current == 39)
          {
            ++num1;
            this.read();
            if (num1 == 3)
            {
              if (stringBuilder.charAt(stringBuilder.length() - 1) == '\n')
                stringBuilder.deleteCharAt(stringBuilder.length() - 1);
              return stringBuilder.toString();
            }
          }
          else
          {
            for (; num1 > 0; num1 += -1)
              stringBuilder.append('\'');
            if (this.current == 10)
            {
              stringBuilder.append('\n');
              this.read();
              this.skipIndent(num2);
            }
            else
            {
              if (this.current != 13)
                stringBuilder.append((char) this.current);
              this.read();
            }
          }
        }
        throw Throwable.__\u003Cunmap\u003E((Exception) this.error("Bad multiline string"));
      }

      [LineNumberTable(new byte[] {162, 152, 108, 115, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void pauseCapture()
      {
        int num = this.captureBuffer.length();
        if (num > 0)
          this.captureBuffer.deleteCharAt(num - 1);
        this.capture = false;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool isHexDigit() => this.current >= 48 && this.current <= 57 || this.current >= 97 && this.current <= 102 || this.current >= 65 && this.current <= 70;

      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool isDigit([In] char obj0)
      {
        switch (obj0)
        {
          case '0':
          case '1':
          case '2':
          case '3':
          case '4':
          case '5':
          case '6':
          case '7':
          case '8':
          case '9':
            return true;
          default:
            return false;
        }
      }

      [LineNumberTable(810)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool isWhiteSpace() => Jval.Hparser.isWhiteSpace((int) (ushort) this.current);

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {162, 111, 110, 108, 102, 110, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int peek([In] int obj0)
      {
        while (obj0 >= this.peek.length())
        {
          int num = this.reader.read();
          if (num < 0)
            return num;
          this.peek.append((char) num);
        }
        return (int) this.peek.charAt(obj0);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(707)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static Jval tryParseNumber([In] string obj0) => Jval.Hparser.tryParseNumber(new StringBuilder(obj0), true);
    }

    internal class Hwriter : Object
    {
      internal static Pattern needsEscapeName;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(838)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Hwriter()
      {
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {158, 187, 163, 99, 104, 107, 161, 159, 14, 103, 99, 139, 108, 130, 127, 0, 117, 119, 107, 124, 133, 113, 180, 104, 105, 99, 139, 104, 105, 106, 30, 200, 109, 104, 130, 104, 122, 130, 112, 130, 104, 172})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void save([In] Jval obj0, [In] Writer obj1, [In] int obj2, [In] string obj3, [In] bool obj4)
      {
        int num1 = obj4 ? 1 : 0;
        if (obj0 == null)
        {
          obj1.write(obj3);
          obj1.write("null");
        }
        else
        {
          switch (Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype[obj0.getType().ordinal()])
          {
            case 3:
              this.writeString(obj0.asString(), obj1, obj2, obj3);
              break;
            case 4:
              obj1.write(obj3);
              obj1.write(!obj0.isTrue() ? "false" : "true");
              break;
            case 5:
              Jval.JsonMap jsonMap = obj0.asObject();
              if (num1 == 0)
                obj1.write(" ");
              if (obj2 >= 0)
                obj1.write(123);
              int num2 = 0;
              Iterator iterator = jsonMap.iterator();
              while (iterator.hasNext())
              {
                ObjectMap.Entry entry = (ObjectMap.Entry) iterator.next();
                int num3 = num2;
                ++num2;
                if (num3 != 0 || obj2 >= 0)
                  this.nl(obj1, obj2 + 1);
                obj1.write(Jval.Hwriter.escapeName((string) entry.key));
                obj1.write(":");
                this.save((Jval) entry.value, obj1, obj2 + 1, " ", false);
              }
              if (jsonMap.size > 0)
                this.nl(obj1, obj2);
              if (obj2 < 0)
                break;
              obj1.write(125);
              break;
            case 6:
              Jval.JsonArray jsonArray = obj0.asArray();
              int size = jsonArray.size;
              if (num1 == 0)
                obj1.write(" ");
              obj1.write(91);
              for (int index = 0; index < size; ++index)
              {
                this.nl(obj1, obj2 + 1);
                this.save((Jval) jsonArray.get(index), obj1, obj2 + 1, "", true);
              }
              if (size > 0)
                this.nl(obj1, obj2);
              obj1.write(93);
              break;
            default:
              obj1.write(obj3);
              obj1.write(obj0.toString());
              break;
          }
        }
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool isPunctuatorChar([In] int obj0) => obj0 == 123 || obj0 == 125 || (obj0 == 91 || obj0 == 93) || (obj0 == 44 || obj0 == 58);

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {162, 216, 107, 119})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void nl([In] Writer obj0, [In] int obj1)
      {
        obj0.write(Jval.eol);
        for (int index = 0; index < obj1; ++index)
          obj0.write("  ");
      }

      [LineNumberTable(new byte[] {163, 19, 127, 11, 159, 11})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static string escapeName([In] string obj0)
      {
        if (String.instancehelper_length(obj0) != 0)
        {
          Pattern needsEscapeName = Jval.Hwriter.needsEscapeName;
          object obj = (object) obj0;
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          if (!needsEscapeName.matcher(charSequence2).find())
            return obj0;
        }
        return new StringBuilder().append("\"").append(Jval.Jwriter.escapeString(obj0)).append("\"").toString();
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {163, 26, 104, 127, 2, 161, 119, 116, 98, 104, 121, 105, 98, 226, 61, 232, 71, 103, 255, 15, 69, 104, 104, 138, 99, 121, 105, 99, 226, 61, 232, 70, 100, 127, 18, 161, 102, 121, 105, 99, 98, 236, 60, 232, 70, 127, 21, 127, 23, 127, 0})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void writeString([In] string obj0, [In] Writer obj1, [In] int obj2, [In] string obj3)
      {
        if (String.instancehelper_length(obj0) == 0)
        {
          obj1.write(new StringBuilder().append(obj3).append("\"\"").toString());
        }
        else
        {
          int num1 = (int) String.instancehelper_charAt(obj0, 0);
          int num2 = (int) String.instancehelper_charAt(obj0, String.instancehelper_length(obj0) - 1);
          int num3 = String.instancehelper_length(obj0) <= 1 ? 0 : (int) String.instancehelper_charAt(obj0, 1);
          int num4 = 0;
          char[] charArray = String.instancehelper_toCharArray(obj0);
          char[] chArray1 = charArray;
          int length1 = chArray1.Length;
          for (int index = 0; index < length1; ++index)
          {
            if (Jval.Hwriter.needsQuotes(chArray1[index]))
            {
              num4 = 1;
              break;
            }
          }
          if (num4 == 0 && !Jval.Hparser.isWhiteSpace(num1) && !Jval.Hparser.isWhiteSpace(num2))
          {
            switch (num1)
            {
              case 34:
              case 35:
              case 39:
                goto label_11;
              case 47:
                if (num3 == 42 || num3 == 47)
                  goto label_11;
                else
                  break;
            }
            if (!Jval.Hwriter.isPunctuatorChar(num1) && Jval.Hparser.tryParseNumber(obj0) == null && !Jval.Hwriter.startsWithKeyword(obj0))
            {
              obj1.write(new StringBuilder().append(obj3).append(obj0).toString());
              return;
            }
          }
label_11:
          int num5 = 1;
          char[] chArray2 = charArray;
          int length2 = chArray2.Length;
          for (int index = 0; index < length2; ++index)
          {
            if (Jval.Hwriter.needsEscape(chArray2[index]))
            {
              num5 = 0;
              break;
            }
          }
          if (num5 != 0)
          {
            obj1.write(new StringBuilder().append(obj3).append("\"").append(obj0).append("\"").toString());
          }
          else
          {
            int num6 = 1;
            int num7 = 1;
            char[] chArray3 = charArray;
            int length3 = chArray3.Length;
            for (int index = 0; index < length3; ++index)
            {
              int num8 = (int) chArray3[index];
              if (Jval.Hwriter.needsEscapeML((char) num8))
              {
                num6 = 0;
                break;
              }
              if (!Jval.Hparser.isWhiteSpace(num8))
                num7 = 0;
            }
            if (num6 != 0 && num7 == 0)
            {
              string str = obj0;
              object obj = (object) "'''";
              CharSequence charSequence1;
              charSequence1.__\u003Cref\u003E = (__Null) obj;
              CharSequence charSequence2 = charSequence1;
              if (!String.instancehelper_contains(str, charSequence2))
              {
                this.writeMLString(obj0, obj1, obj2, obj3);
                return;
              }
            }
            obj1.write(new StringBuilder().append(obj3).append("\"").append(Jval.Jwriter.escapeString(obj0)).append("\"").toString());
          }
        }
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool needsQuotes([In] char obj0)
      {
        switch (obj0)
        {
          case '\b':
          case '\t':
          case '\n':
          case '\f':
          case '\r':
            return true;
          default:
            return false;
        }
      }

      [LineNumberTable(new byte[] {163, 99, 126, 113, 98, 125, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool startsWithKeyword([In] string obj0)
      {
        int num;
        if (String.instancehelper_startsWith(obj0, "true") || String.instancehelper_startsWith(obj0, "null"))
        {
          num = 4;
        }
        else
        {
          if (!String.instancehelper_startsWith(obj0, "false"))
            return false;
          num = 5;
        }
        while (num < String.instancehelper_length(obj0) && Jval.Hparser.isWhiteSpace((int) String.instancehelper_charAt(obj0, num)))
          ++num;
        if (num == String.instancehelper_length(obj0))
          return true;
        switch (String.instancehelper_charAt(obj0, num))
        {
          case '#':
          case ',':
          case ']':
          case '}':
            return true;
          case '/':
            if (String.instancehelper_length(obj0) <= num + 1 || String.instancehelper_charAt(obj0, num + 1) != '/' && String.instancehelper_charAt(obj0, num + 1) != '*')
              break;
            goto case '#';
        }
        return false;
      }

      [LineNumberTable(999)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool needsEscape([In] char obj0)
      {
        int num = (int) obj0;
        switch (num)
        {
          case 34:
          case 92:
            return true;
          default:
            if (!Jval.Hwriter.needsQuotes((char) num))
              return false;
            goto case 34;
        }
      }

      [LineNumberTable(new byte[] {158, 148, 162, 223, 0, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool needsEscapeML([In] char obj0)
      {
        int num = (int) obj0;
        switch (num)
        {
          case 9:
          case 10:
          case 13:
            return false;
          default:
            return Jval.Hwriter.needsQuotes((char) num);
        }
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {163, 77, 159, 31, 101, 127, 2, 105, 144, 101, 104, 139, 120, 117, 8, 200, 104, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void writeMLString([In] string obj0, [In] Writer obj1, [In] int obj2, [In] string obj3)
      {
        string str1 = obj0;
        object obj4 = (object) "";
        object obj5 = (object) "\r";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj5;
        CharSequence charSequence2 = charSequence1;
        object obj6 = obj4;
        charSequence1.__\u003Cref\u003E = (__Null) obj6;
        CharSequence charSequence3 = charSequence1;
        string[] strArray1 = String.instancehelper_split(String.instancehelper_replace(str1, charSequence2, charSequence3), "\n", -1);
        if (strArray1.Length == 1)
        {
          obj1.write(new StringBuilder().append(obj3).append("'''").toString());
          obj1.write(strArray1[0]);
          obj1.write("'''");
        }
        else
        {
          ++obj2;
          this.nl(obj1, obj2);
          obj1.write("'''");
          string[] strArray2 = strArray1;
          int length = strArray2.Length;
          for (int index = 0; index < length; ++index)
          {
            string str2 = strArray2[index];
            this.nl(obj1, String.instancehelper_length(str2) <= 0 ? 0 : obj2);
            obj1.write(str2);
          }
          this.nl(obj1, obj2);
          obj1.write("'''");
        }
      }

      [LineNumberTable(839)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Hwriter()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.Jval$Hwriter"))
          return;
        Jval.Hwriter.needsEscapeName = Pattern.compile("[,\\{\\[\\}\\]\\s:#\"']|//|/\\*");
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/util/serialization/Jval$Jformat;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Jformat : Enum
    {
      [Modifiers]
      internal static Jval.Jformat __\u003C\u003Eplain;
      [Modifiers]
      internal static Jval.Jformat __\u003C\u003Eformatted;
      [Modifiers]
      internal static Jval.Jformat __\u003C\u003Ehjson;
      [Modifiers]
      private static Jval.Jformat[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(309)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Jval.Jformat[] values() => (Jval.Jformat[]) Jval.Jformat.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(309)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Jformat([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(309)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Jval.Jformat valueOf(string name) => (Jval.Jformat) Enum.valueOf((Class) ClassLiteral<Jval.Jformat>.Value, name);

      [LineNumberTable(new byte[] {159, 65, 173, 144, 144, 240, 58})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Jformat()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.Jval$Jformat"))
          return;
        Jval.Jformat.__\u003C\u003Eplain = new Jval.Jformat(nameof (plain), 0);
        Jval.Jformat.__\u003C\u003Eformatted = new Jval.Jformat(nameof (formatted), 1);
        Jval.Jformat.__\u003C\u003Ehjson = new Jval.Jformat(nameof (hjson), 2);
        Jval.Jformat.\u0024VALUES = new Jval.Jformat[3]
        {
          Jval.Jformat.__\u003C\u003Eplain,
          Jval.Jformat.__\u003C\u003Eformatted,
          Jval.Jformat.__\u003C\u003Ehjson
        };
      }

      [Modifiers]
      public static Jval.Jformat plain
      {
        [HideFromJava] get => Jval.Jformat.__\u003C\u003Eplain;
      }

      [Modifiers]
      public static Jval.Jformat formatted
      {
        [HideFromJava] get => Jval.Jformat.__\u003C\u003Eformatted;
      }

      [Modifiers]
      public static Jval.Jformat hjson
      {
        [HideFromJava] get => Jval.Jformat.__\u003C\u003Ehjson;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        plain,
        formatted,
        hjson,
      }
    }

    [Signature("Larc/struct/Seq<Larc/util/serialization/Jval;>;")]
    public class JsonArray : Seq
    {
      [LineNumberTable(242)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JsonArray()
      {
      }
    }

    [Signature("Larc/struct/ArrayMap<Ljava/lang/String;Larc/util/serialization/Jval;>;")]
    public class JsonMap : ArrayMap
    {
      [LineNumberTable(237)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JsonMap()
      {
      }
    }

    public class JsonParseException : RuntimeException
    {
      internal int __\u003C\u003Eoffset;
      internal int __\u003C\u003Eline;
      internal int __\u003C\u003Ecolumn;

      [LineNumberTable(new byte[] {162, 205, 127, 26, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal JsonParseException([In] string obj0, [In] int obj1, [In] int obj2, [In] int obj3)
        : base(new StringBuilder().append(obj0).append(" at ").append(obj2).append(":").append(obj3).toString())
      {
        Jval.JsonParseException jsonParseException = this;
        this.__\u003C\u003Eoffset = obj1;
        this.__\u003C\u003Eline = obj2;
        this.__\u003C\u003Ecolumn = obj3;
      }

      [Modifiers]
      public int offset
      {
        [HideFromJava] get => this.__\u003C\u003Eoffset;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eoffset = value;
      }

      [Modifiers]
      public int line
      {
        [HideFromJava] get => this.__\u003C\u003Eline;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eline = value;
      }

      [Modifiers]
      public int column
      {
        [HideFromJava] get => this.__\u003C\u003Ecolumn;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ecolumn = value;
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/util/serialization/Jval$Jtype;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Jtype : Enum
    {
      [Modifiers]
      internal static Jval.Jtype __\u003C\u003Estring;
      [Modifiers]
      internal static Jval.Jtype __\u003C\u003Enumber;
      [Modifiers]
      internal static Jval.Jtype __\u003C\u003Eobject;
      [Modifiers]
      internal static Jval.Jtype __\u003C\u003Earray;
      [Modifiers]
      internal static Jval.Jtype __\u003C\u003Ebool;
      [Modifiers]
      internal static Jval.Jtype __\u003C\u003Enil;
      [Modifiers]
      private static Jval.Jtype[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(322)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Jval.Jtype[] values() => (Jval.Jtype[]) Jval.Jtype.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(322)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Jtype([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(322)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Jval.Jtype valueOf(string name) => (Jval.Jtype) Enum.valueOf((Class) ClassLiteral<Jval.Jtype>.Value, name);

      [LineNumberTable(new byte[] {159, 62, 173, 63, 65})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Jtype()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.Jval$Jtype"))
          return;
        Jval.Jtype.__\u003C\u003Estring = new Jval.Jtype(nameof (@string), 0);
        Jval.Jtype.__\u003C\u003Enumber = new Jval.Jtype(nameof (number), 1);
        Jval.Jtype.__\u003C\u003Eobject = new Jval.Jtype(nameof (@object), 2);
        Jval.Jtype.__\u003C\u003Earray = new Jval.Jtype(nameof (array), 3);
        Jval.Jtype.__\u003C\u003Ebool = new Jval.Jtype(nameof (@bool), 4);
        Jval.Jtype.__\u003C\u003Enil = new Jval.Jtype(nameof (nil), 5);
        Jval.Jtype.\u0024VALUES = new Jval.Jtype[6]
        {
          Jval.Jtype.__\u003C\u003Estring,
          Jval.Jtype.__\u003C\u003Enumber,
          Jval.Jtype.__\u003C\u003Eobject,
          Jval.Jtype.__\u003C\u003Earray,
          Jval.Jtype.__\u003C\u003Ebool,
          Jval.Jtype.__\u003C\u003Enil
        };
      }

      [Modifiers]
      public static Jval.Jtype @string
      {
        [HideFromJava] get => Jval.Jtype.__\u003C\u003Estring;
      }

      [Modifiers]
      public static Jval.Jtype number
      {
        [HideFromJava] get => Jval.Jtype.__\u003C\u003Enumber;
      }

      [Modifiers]
      public static Jval.Jtype @object
      {
        [HideFromJava] get => Jval.Jtype.__\u003C\u003Eobject;
      }

      [Modifiers]
      public static Jval.Jtype array
      {
        [HideFromJava] get => Jval.Jtype.__\u003C\u003Earray;
      }

      [Modifiers]
      public static Jval.Jtype @bool
      {
        [HideFromJava] get => Jval.Jtype.__\u003C\u003Ebool;
      }

      [Modifiers]
      public static Jval.Jtype nil
      {
        [HideFromJava] get => Jval.Jtype.__\u003C\u003Enil;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        @string,
        number,
        @object,
        array,
        @bool,
        nil,
      }
    }

    internal class Jwriter : Object
    {
      internal bool format;

      [LineNumberTable(new byte[] {158, 144, 98, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Jwriter([In] bool obj0)
      {
        int num = obj0 ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Jval.Jwriter jwriter = this;
        this.format = num != 0;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {163, 147, 98, 159, 14, 103, 104, 126, 110, 106, 104, 118, 139, 109, 105, 127, 16, 108, 98, 101, 107, 104, 133, 104, 105, 107, 104, 105, 110, 112, 105, 120, 108, 226, 58, 232, 72, 107, 104, 130, 122, 130, 104, 113, 104, 130, 172})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void save([In] Jval obj0, [In] Writer obj1, [In] int obj2)
      {
        int num = 0;
        switch (Jval.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024Jval\u0024Jtype[obj0.getType().ordinal()])
        {
          case 3:
            obj1.write(34);
            obj1.write(Jval.Jwriter.escapeString(obj0.asString()));
            obj1.write(34);
            break;
          case 4:
            obj1.write(!obj0.isTrue() ? "false" : "true");
            break;
          case 5:
            Jval.JsonMap jsonMap = obj0.asObject();
            obj1.write(123);
            Iterator iterator = jsonMap.iterator();
            while (iterator.hasNext())
            {
              ObjectMap.Entry entry = (ObjectMap.Entry) iterator.next();
              if (num != 0)
                obj1.write(",");
              this.nl(obj1, obj2 + 1);
              obj1.write(34);
              obj1.write(Jval.Jwriter.escapeString((string) entry.key));
              obj1.write("\":");
              Jval jval = (Jval) entry.value;
              Jval.Jtype type = jval.getType();
              if (this.format && !object.ReferenceEquals((object) type, (object) Jval.Jtype.__\u003C\u003Earray) && !object.ReferenceEquals((object) type, (object) Jval.Jtype.__\u003C\u003Eobject))
                obj1.write(" ");
              this.save(jval, obj1, obj2 + 1);
              num = 1;
            }
            if (num != 0)
              this.nl(obj1, obj2);
            obj1.write(125);
            break;
          case 6:
            Jval.JsonArray jsonArray = obj0.asArray();
            int size = jsonArray.size;
            if (obj2 != 0)
              obj1.write(32);
            obj1.write(91);
            for (int index = 0; index < size; ++index)
            {
              if (num != 0)
                obj1.write(",");
              Jval jval = (Jval) jsonArray.get(index);
              if (!object.ReferenceEquals((object) jval.getType(), (object) Jval.Jtype.__\u003C\u003Earray))
                this.nl(obj1, obj2 + 1);
              this.save(jval, obj1, obj2 + 1);
              num = 1;
            }
            if (num != 0)
              this.nl(obj1, obj2);
            obj1.write(93);
            break;
          default:
            obj1.write(obj0.toString());
            break;
        }
      }

      [LineNumberTable(new byte[] {163, 199, 133, 110, 110, 102, 127, 5, 233, 60, 233, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static string escapeString([In] string obj0)
      {
        if (obj0 == null)
          return (string) null;
        for (int index = 0; index < String.instancehelper_length(obj0); ++index)
        {
          if (Jval.Jwriter.getEscapedChar(String.instancehelper_charAt(obj0, index)) != null)
          {
            StringBuilder stringBuilder1 = new StringBuilder();
            if (index > 0)
            {
              StringBuilder stringBuilder2 = stringBuilder1;
              string str = obj0;
              int num1 = index;
              int num2 = 0;
              object obj = (object) str;
              CharSequence charSequence1;
              charSequence1.__\u003Cref\u003E = (__Null) obj;
              CharSequence charSequence2 = charSequence1;
              int num3 = num2;
              int num4 = num1;
              stringBuilder2.append(charSequence2, num3, num4);
            }
            return Jval.Jwriter.doEscapeString(stringBuilder1, obj0, index);
          }
        }
        return obj0;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {163, 140, 104, 107, 151})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void nl([In] Writer obj0, [In] int obj1)
      {
        if (!this.format)
          return;
        obj0.write(Jval.eol);
        for (int index = 0; index < obj1; ++index)
          obj0.write("  ");
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      private static string getEscapedChar([In] char obj0)
      {
        switch (obj0)
        {
          case '\b':
            return "\\b";
          case '\t':
            return "\\t";
          case '\n':
            return "\\n";
          case '\f':
            return "\\f";
          case '\r':
            return "\\r";
          case '"':
            return "\\\"";
          case '\\':
            return "\\\\";
          default:
            return (string) null;
        }
      }

      [LineNumberTable(new byte[] {163, 212, 98, 107, 109, 99, 127, 3, 104, 228, 59, 233, 72, 127, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static string doEscapeString([In] StringBuilder obj0, [In] string obj1, [In] int obj2)
      {
        int num1 = obj2;
        CharSequence charSequence1;
        for (int index = obj2; index < String.instancehelper_length(obj1); ++index)
        {
          string escapedChar = Jval.Jwriter.getEscapedChar(String.instancehelper_charAt(obj1, index));
          if (escapedChar != null)
          {
            StringBuilder stringBuilder = obj0;
            string str = obj1;
            int num2 = num1;
            int num3 = index;
            int num4 = num2;
            object obj = (object) str;
            charSequence1.__\u003Cref\u003E = (__Null) obj;
            CharSequence charSequence2 = charSequence1;
            int num5 = num4;
            int num6 = num3;
            stringBuilder.append(charSequence2, num5, num6);
            obj0.append(escapedChar);
            num1 = index + 1;
          }
        }
        StringBuilder stringBuilder1 = obj0;
        string str1 = obj1;
        int num7 = num1;
        int num8 = String.instancehelper_length(obj1);
        int num9 = num7;
        object obj3 = (object) str1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        int num10 = num9;
        int num11 = num8;
        stringBuilder1.append(charSequence3, num10, num11);
        return obj0.toString();
      }
    }

    internal class WritingBuffer : Writer
    {
      [Modifiers]
      private Writer writer;
      [Modifiers]
      private char[] buffer;
      private int fill;

      [LineNumberTable(new byte[] {160, 143, 8, 167, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal WritingBuffer([In] Writer obj0, [In] int obj1)
      {
        Jval.WritingBuffer writingBuffer = this;
        this.fill = 0;
        this.writer = obj0;
        this.buffer = new char[obj1];
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 185, 120, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void flush()
      {
        this.writer.write(this.buffer, 0, this.fill);
        this.fill = 0;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 150, 113, 134, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] int obj0)
      {
        if (this.fill > this.buffer.Length - 1)
          this.flush();
        char[] buffer = this.buffer;
        Jval.WritingBuffer writingBuffer1 = this;
        int fill = writingBuffer1.fill;
        Jval.WritingBuffer writingBuffer2 = writingBuffer1;
        int index = fill;
        writingBuffer2.fill = fill + 1;
        int num = (int) (ushort) obj0;
        buffer[index] = (char) num;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 158, 113, 102, 106, 110, 161, 116, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] char[] obj0, [In] int obj1, [In] int obj2)
      {
        if (this.fill > this.buffer.Length - obj2)
        {
          this.flush();
          if (obj2 > this.buffer.Length)
          {
            this.writer.write(obj0, obj1, obj2);
            return;
          }
        }
        ByteCodeHelper.arraycopy_primitive_2((Array) obj0, obj1, (Array) this.buffer, this.fill, obj2);
        this.fill += obj2;
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 171, 113, 102, 106, 110, 161, 118, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] string obj0, [In] int obj1, [In] int obj2)
      {
        if (this.fill > this.buffer.Length - obj2)
        {
          this.flush();
          if (obj2 > this.buffer.Length)
          {
            this.writer.write(obj0, obj1, obj2);
            return;
          }
        }
        String.instancehelper_getChars(obj0, obj1, obj1 + obj2, this.buffer, this.fill);
        this.fill += obj2;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void close()
      {
      }
    }
  }
}
