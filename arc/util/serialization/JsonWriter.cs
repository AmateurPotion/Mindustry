// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.JsonWriter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.math;
using java.util.regex;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.serialization
{
  [Implements(new string[] {"arc.util.serialization.BaseJsonWriter"})]
  public class JsonWriter : Writer, BaseJsonWriter, Closeable, AutoCloseable
  {
    [Modifiers]
    internal Writer writer;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/util/serialization/JsonWriter$JsonObject;>;")]
    private Seq stack;
    private JsonWriter.JsonObject current;
    private bool named;
    private JsonWriter.OutputType outputType;
    private bool quoteLongValues;

    [LineNumberTable(new byte[] {159, 166, 232, 58, 171, 107, 167, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonWriter(Writer writer)
    {
      JsonWriter jsonWriter = this;
      this.stack = new Seq();
      this.outputType = JsonWriter.OutputType.__\u003C\u003Ejson;
      this.quoteLongValues = false;
      this.writer = writer;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {40, 105, 109, 109, 142, 143, 120, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void requireCommaOrName()
    {
      if (this.current == null)
        return;
      if (this.current.array)
      {
        if (!this.current.needsComma)
          this.current.needsComma = true;
        else
          this.writer.write(44);
      }
      else
      {
        if (!this.named)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Name must be set.");
        }
        this.named = false;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 191, 127, 6, 109, 142, 109, 119, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter name(string name)
    {
      if (this.current == null || this.current.array)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Current item must be an object.");
      }
      if (!this.current.needsComma)
        this.current.needsComma = true;
      else
        this.writer.write(44);
      this.writer.write(this.outputType.quoteName(name));
      this.writer.write(58);
      this.named = true;
      return (BaseJsonWriter) this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {69, 120, 117, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter pop()
    {
      if (this.named)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Expected an object, array, or value since a name was set.");
      }
      ((JsonWriter.JsonObject) this.stack.pop()).close();
      this.current = this.stack.size != 0 ? (JsonWriter.JsonObject) this.stack.peek() : (JsonWriter.JsonObject) null;
      return (BaseJsonWriter) this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Writer getWriter() => this.writer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOutputType(JsonWriter.OutputType outputType) => this.outputType = outputType;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setQuoteLongValues(bool quoteLongValues) => this.quoteLongValues = quoteLongValues;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {12, 102, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter @object()
    {
      this.requireCommaOrName();
      Seq stack = this.stack;
      JsonWriter jsonWriter = this;
      JsonWriter.JsonObject jsonObject1 = new JsonWriter.JsonObject(this, false);
      JsonWriter.JsonObject jsonObject2 = jsonObject1;
      this.current = jsonObject1;
      stack.add((object) jsonObject2);
      return (BaseJsonWriter) this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {19, 102, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter array()
    {
      this.requireCommaOrName();
      Seq stack = this.stack;
      JsonWriter jsonWriter = this;
      JsonWriter.JsonObject jsonObject1 = new JsonWriter.JsonObject(this, true);
      JsonWriter.JsonObject jsonObject2 = jsonObject1;
      this.current = jsonObject1;
      stack.add((object) jsonObject2);
      return (BaseJsonWriter) this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {26, 159, 9, 106, 104, 103, 103, 147, 102, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter value(object value)
    {
      if (this.quoteLongValues && (value is Long || value is Double || (value is BigDecimal || value is BigInteger)))
        value = (object) Object.instancehelper_toString(value);
      else if (value is Number)
      {
        Number number = (Number) value;
        long num = number.longValue();
        if (number.doubleValue() == (double) num)
          value = (object) Long.valueOf(num);
      }
      this.requireCommaOrName();
      this.writer.write(this.outputType.quoteValue(value));
      return (BaseJsonWriter) this;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter @object(string name) => this.name(name).@object();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter array(string name) => this.name(name).array();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter set(string name, object value) => this.name(name).value(value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {77, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(char[] cbuf, int off, int len) => this.writer.write(cbuf, off, len);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {82, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flush() => this.writer.flush();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {87, 110, 105, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      while (this.stack.size > 0)
        this.pop();
      this.writer.close();
    }

    void IDisposable.__\u003Coverridestub\u003Ejava\u002Elang\u002EAutoCloseable\u003A\u003Aclose() => this.close();

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonWriter\u0024OutputType;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(190)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.JsonWriter$1"))
          return;
        JsonWriter.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonWriter\u0024OutputType = new int[JsonWriter.OutputType.values().Length];
        try
        {
          JsonWriter.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonWriter\u0024OutputType[JsonWriter.OutputType.__\u003C\u003Eminimal.ordinal()] = 1;
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
          JsonWriter.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonWriter\u0024OutputType[JsonWriter.OutputType.__\u003C\u003Ejavascript.ordinal()] = 2;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [InnerClass]
    internal class JsonObject : Object
    {
      [Modifiers]
      internal bool array;
      internal bool needsComma;
      [Modifiers]
      internal JsonWriter this\u00240;

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {159, 91, 130, 111, 103, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal JsonObject([In] JsonWriter obj0, [In] bool obj1)
      {
        int num = obj1 ? 1 : 0;
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        JsonWriter.JsonObject jsonObject = this;
        this.array = num != 0;
        obj0.writer.write(num == 0 ? 123 : 91);
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {160, 98, 126})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void close() => this.this\u00240.writer.write(!this.array ? 125 : 93);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/util/serialization/JsonWriter$OutputType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class OutputType : Enum
    {
      [Modifiers]
      internal static JsonWriter.OutputType __\u003C\u003Ejson;
      [Modifiers]
      internal static JsonWriter.OutputType __\u003C\u003Ejavascript;
      [Modifiers]
      internal static JsonWriter.OutputType __\u003C\u003Eminimal;
      private static Pattern javascriptPattern;
      private static Pattern minimalNamePattern;
      private static Pattern minimalValuePattern;
      [Modifiers]
      private static JsonWriter.OutputType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 71, 103, 110, 110, 110, 110, 159, 4, 127, 61, 135, 159, 10, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string quoteName(string value)
      {
        StringBuilder builder = new StringBuilder(value);
        Strings.replace(builder, '\\', "\\\\");
        Strings.replace(builder, '\r', "\\r");
        Strings.replace(builder, '\n', "\\n");
        Strings.replace(builder, '\t', "\\t");
        CharSequence charSequence1;
        switch (JsonWriter.\u0031.\u0024SwitchMap\u0024arc\u0024util\u0024serialization\u0024JsonWriter\u0024OutputType[this.ordinal()])
        {
          case 1:
            string str1 = value;
            object obj1 = (object) "//";
            charSequence1.__\u003Cref\u003E = (__Null) obj1;
            CharSequence charSequence2 = charSequence1;
            if (!String.instancehelper_contains(str1, charSequence2))
            {
              string str2 = value;
              object obj2 = (object) "/*";
              charSequence1.__\u003Cref\u003E = (__Null) obj2;
              CharSequence charSequence3 = charSequence1;
              if (!String.instancehelper_contains(str2, charSequence3))
              {
                Pattern minimalNamePattern = JsonWriter.OutputType.minimalNamePattern;
                object obj3 = (object) builder;
                charSequence1.__\u003Cref\u003E = (__Null) obj3;
                CharSequence charSequence4 = charSequence1;
                if (minimalNamePattern.matcher(charSequence4).matches())
                  return builder.toString();
                goto case 2;
              }
              else
                goto case 2;
            }
            else
              goto case 2;
          case 2:
            Pattern javascriptPattern = JsonWriter.OutputType.javascriptPattern;
            object obj4 = (object) builder;
            charSequence1.__\u003Cref\u003E = (__Null) obj4;
            CharSequence charSequence5 = charSequence1;
            if (javascriptPattern.matcher(charSequence5).matches())
              return builder.toString();
            break;
        }
        Strings.replace(builder, '"', "\\\"");
        return new StringBuilder().append('"').append(builder.toString()).append('"').toString();
      }

      [LineNumberTable(new byte[] {116, 105, 103, 114, 103, 110, 110, 110, 110, 127, 39, 127, 24, 104, 127, 22, 135, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string quoteValue(object value)
      {
        if (value == null)
          return "null";
        string str1 = Object.instancehelper_toString(value);
        if (value is Number || value is Boolean)
          return str1;
        StringBuilder builder = new StringBuilder(str1);
        Strings.replace(builder, '\\', "\\\\");
        Strings.replace(builder, '\r', "\\r");
        Strings.replace(builder, '\n', "\\n");
        Strings.replace(builder, '\t', "\\t");
        if (object.ReferenceEquals((object) this, (object) JsonWriter.OutputType.__\u003C\u003Eminimal) && !String.instancehelper_equals(str1, (object) "true") && (!String.instancehelper_equals(str1, (object) "false") && !String.instancehelper_equals(str1, (object) "null")))
        {
          string str2 = str1;
          object obj1 = (object) "//";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj1;
          CharSequence charSequence2 = charSequence1;
          if (!String.instancehelper_contains(str2, charSequence2))
          {
            string str3 = str1;
            object obj2 = (object) "/*";
            charSequence1.__\u003Cref\u003E = (__Null) obj2;
            CharSequence charSequence3 = charSequence1;
            if (!String.instancehelper_contains(str3, charSequence3))
            {
              int num = builder.length();
              if (num > 0 && builder.charAt(num - 1) != ' ')
              {
                Pattern minimalValuePattern = JsonWriter.OutputType.minimalValuePattern;
                object obj3 = (object) builder;
                charSequence1.__\u003Cref\u003E = (__Null) obj3;
                CharSequence charSequence4 = charSequence1;
                if (minimalValuePattern.matcher(charSequence4).matches())
                  return builder.toString();
              }
            }
          }
        }
        Strings.replace(builder, '"', "\\\"");
        return new StringBuilder().append('"').append(builder.toString()).append('"').toString();
      }

      [LineNumberTable(142)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static JsonWriter.OutputType[] values() => (JsonWriter.OutputType[]) JsonWriter.OutputType.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(142)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private OutputType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(142)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static JsonWriter.OutputType valueOf(string name) => (JsonWriter.OutputType) Enum.valueOf((Class) ClassLiteral<JsonWriter.OutputType>.Value, name);

      [LineNumberTable(new byte[] {159, 106, 77, 144, 240, 77, 240, 47, 255, 4, 83, 111, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static OutputType()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.JsonWriter$OutputType"))
          return;
        JsonWriter.OutputType.__\u003C\u003Ejson = new JsonWriter.OutputType(nameof (json), 0);
        JsonWriter.OutputType.__\u003C\u003Ejavascript = new JsonWriter.OutputType(nameof (javascript), 1);
        JsonWriter.OutputType.__\u003C\u003Eminimal = new JsonWriter.OutputType(nameof (minimal), 2);
        JsonWriter.OutputType.\u0024VALUES = new JsonWriter.OutputType[3]
        {
          JsonWriter.OutputType.__\u003C\u003Ejson,
          JsonWriter.OutputType.__\u003C\u003Ejavascript,
          JsonWriter.OutputType.__\u003C\u003Eminimal
        };
        JsonWriter.OutputType.javascriptPattern = Pattern.compile("^[a-zA-Z_$][a-zA-Z_$0-9]*$");
        JsonWriter.OutputType.minimalNamePattern = Pattern.compile("^[^\":,}/ ][^:]*$");
        JsonWriter.OutputType.minimalValuePattern = Pattern.compile("^[^\":,{\\[\\]/ ][^}\\],]*$");
      }

      [Modifiers]
      public static JsonWriter.OutputType json
      {
        [HideFromJava] get => JsonWriter.OutputType.__\u003C\u003Ejson;
      }

      [Modifiers]
      public static JsonWriter.OutputType javascript
      {
        [HideFromJava] get => JsonWriter.OutputType.__\u003C\u003Ejavascript;
      }

      [Modifiers]
      public static JsonWriter.OutputType minimal
      {
        [HideFromJava] get => JsonWriter.OutputType.__\u003C\u003Eminimal;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        json,
        javascript,
        minimal,
      }
    }
  }
}
