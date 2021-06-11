// Decompiled with JetBrains decompiler
// Type: rhino.NativeString
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.text;
using java.util;
using rhino.regexp;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal sealed class NativeString : IdScriptableObject
  {
    [Modifiers]
    private static object STRING_TAG;
    private const int Id_length = 1;
    private const int MAX_INSTANCE_ID = 1;
    private const int ConstructorId_fromCharCode = -1;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_toSource = 3;
    private const int Id_valueOf = 4;
    private const int Id_charAt = 5;
    private const int Id_charCodeAt = 6;
    private const int Id_indexOf = 7;
    private const int Id_lastIndexOf = 8;
    private const int Id_split = 9;
    private const int Id_substring = 10;
    private const int Id_toLowerCase = 11;
    private const int Id_toUpperCase = 12;
    private const int Id_substr = 13;
    private const int Id_concat = 14;
    private const int Id_slice = 15;
    private const int Id_bold = 16;
    private const int Id_italics = 17;
    private const int Id_fixed = 18;
    private const int Id_strike = 19;
    private const int Id_small = 20;
    private const int Id_big = 21;
    private const int Id_blink = 22;
    private const int Id_sup = 23;
    private const int Id_sub = 24;
    private const int Id_fontsize = 25;
    private const int Id_fontcolor = 26;
    private const int Id_link = 27;
    private const int Id_anchor = 28;
    private const int Id_equals = 29;
    private const int Id_equalsIgnoreCase = 30;
    private const int Id_match = 31;
    private const int Id_search = 32;
    private const int Id_replace = 33;
    private const int Id_localeCompare = 34;
    private const int Id_toLocaleLowerCase = 35;
    private const int Id_toLocaleUpperCase = 36;
    private const int Id_trim = 37;
    private const int Id_trimLeft = 38;
    private const int Id_trimRight = 39;
    private const int Id_includes = 40;
    private const int Id_startsWith = 41;
    private const int Id_endsWith = 42;
    private const int Id_normalize = 43;
    private const int Id_repeat = 44;
    private const int Id_codePointAt = 45;
    private const int Id_padStart = 46;
    private const int Id_padEnd = 47;
    private const int SymbolId_iterator = 48;
    private const int MAX_PROTOTYPE_ID = 48;
    private const int ConstructorId_charAt = -5;
    private const int ConstructorId_charCodeAt = -6;
    private const int ConstructorId_indexOf = -7;
    private const int ConstructorId_lastIndexOf = -8;
    private const int ConstructorId_split = -9;
    private const int ConstructorId_substring = -10;
    private const int ConstructorId_toLowerCase = -11;
    private const int ConstructorId_toUpperCase = -12;
    private const int ConstructorId_substr = -13;
    private const int ConstructorId_concat = -14;
    private const int ConstructorId_slice = -15;
    private const int ConstructorId_equalsIgnoreCase = -30;
    private const int ConstructorId_match = -31;
    private const int ConstructorId_search = -32;
    private const int ConstructorId_replace = -33;
    private const int ConstructorId_localeCompare = -34;
    private const int ConstructorId_toLocaleLowerCase = -35;
    [Modifiers]
    private CharSequence @string;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(852)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getLength()
    {
      object obj = (object) this.@string.__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return ((CharSequence) ref charSequence).length();
    }

    [LineNumberTable(new byte[] {159, 135, 170, 104, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeString([In] CharSequence obj0)
    {
      object obj1 = (object) obj0.__\u003Cref\u003E;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      NativeString nativeString = this;
      object obj2 = obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      this.@string = charSequence;
    }

    [LineNumberTable(new byte[] {162, 23, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeString realThis([In] Scriptable obj0, [In] IdFunctionObject obj1) => obj0 is NativeString ? (NativeString) obj0 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));

    [LineNumberTable(new byte[] {162, 149, 104, 138, 116, 162, 112, 116, 159, 0, 101, 127, 6, 154, 109, 117, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int js_indexOf([In] int obj0, [In] string obj1, [In] object[] obj2)
    {
      string str = ScriptRuntime.toString(obj2, 0);
      double num = ScriptRuntime.toInteger(obj2, 1);
      if (num > (double) String.instancehelper_length(obj1) && obj0 != 41 && obj0 != 42)
        return -1;
      if (num < 0.0)
        num = 0.0;
      else if (num > (double) String.instancehelper_length(obj1))
        num = (double) String.instancehelper_length(obj1);
      else if (obj0 == 42 && (Double.isNaN(num) || num > (double) String.instancehelper_length(obj1)))
        num = (double) String.instancehelper_length(obj1);
      if (42 == obj0)
      {
        if (obj2.Length == 0 || obj2.Length == 1 || obj2.Length == 2 && object.ReferenceEquals(obj2[1], Undefined.__\u003C\u003Einstance))
          num = (double) String.instancehelper_length(obj1);
        return String.instancehelper_endsWith(String.instancehelper_substring(obj1, 0, ByteCodeHelper.d2i(num)), str) ? 0 : -1;
      }
      if (obj0 != 41)
        return String.instancehelper_indexOf(obj1, str, ByteCodeHelper.d2i(num));
      return String.instancehelper_startsWith(obj1, str, ByteCodeHelper.d2i(num)) ? 0 : -1;
    }

    [LineNumberTable(new byte[] {163, 110, 110, 104, 106, 162, 102, 111, 105, 105, 226, 69, 107, 135, 105, 106, 136, 105, 174})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string js_pad(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] IdFunctionObject obj2,
      [In] object[] obj3,
      [In] Boolean obj4)
    {
      string str1 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj0, obj1, obj2));
      long length = ScriptRuntime.toLength(obj3, 0);
      if (length <= (long) String.instancehelper_length(str1))
        return str1;
      string str2 = " ";
      if (obj3.Length >= 2 && !Undefined.isUndefined(obj3[1]))
      {
        str2 = ScriptRuntime.toString(obj3[1]);
        if (String.instancehelper_length(str2) < 1)
          return str1;
      }
      int num = (int) (length - (long) String.instancehelper_length(str1));
      StringBuilder stringBuilder = new StringBuilder();
      do
      {
        stringBuilder.append(str2);
      }
      while (stringBuilder.length() < num);
      stringBuilder.setLength(num);
      return obj4.booleanValue() ? stringBuilder.append(str1).toString() : stringBuilder.insert(0, str1).toString();
    }

    [LineNumberTable(new byte[] {162, 175, 104, 138, 114, 106, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int js_lastIndexOf([In] string obj0, [In] object[] obj1)
    {
      string str = ScriptRuntime.toString(obj1, 0);
      double num = ScriptRuntime.toNumber(obj1, 1);
      if (Double.isNaN(num) || num > (double) String.instancehelper_length(obj0))
        num = (double) String.instancehelper_length(obj0);
      else if (num < 0.0)
        num = 0.0;
      return String.instancehelper_lastIndexOf(obj0, str, ByteCodeHelper.d2i(num));
    }

    [LineNumberTable(new byte[] {158, 194, 138, 115, 171, 105, 105, 103, 133, 116, 138, 108, 105, 105, 103, 165, 102, 106, 100, 100, 100, 130, 196})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence js_substring(
      [In] Context obj0,
      [In] CharSequence obj1,
      [In] object[] obj2)
    {
      object obj3 = (object) obj1.__\u003Cref\u003E;
      object obj4 = obj3;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      int num1 = ((CharSequence) ref charSequence1).length();
      double num2 = ScriptRuntime.toInteger(obj2, 0);
      if (num2 < 0.0)
        num2 = 0.0;
      else if (num2 > (double) num1)
        num2 = (double) num1;
      double num3;
      if (obj2.Length <= 1 || object.ReferenceEquals(obj2[1], Undefined.__\u003C\u003Einstance))
      {
        num3 = (double) num1;
      }
      else
      {
        num3 = ScriptRuntime.toInteger(obj2[1]);
        if (num3 < 0.0)
          num3 = 0.0;
        else if (num3 > (double) num1)
          num3 = (double) num1;
        if (num3 < num2)
        {
          if (obj0.getLanguageVersion() != 120)
          {
            double num4 = num2;
            num2 = num3;
            num3 = num4;
          }
          else
            num3 = num2;
        }
      }
      object obj5 = obj3;
      int num5 = ByteCodeHelper.d2i(num2);
      int num6 = ByteCodeHelper.d2i(num3);
      int num7 = num5;
      object obj6 = obj5;
      charSequence1.__\u003Cref\u003E = (__Null) obj6;
      object obj7 = (object) ((CharSequence) ref charSequence1).subSequence(num7, num6).__\u003Cref\u003E;
      CharSequence charSequence2;
      charSequence2.__\u003Cref\u003E = (__Null) obj7;
      return charSequence2;
    }

    [LineNumberTable(new byte[] {158, 184, 170, 101, 178, 140, 149, 105, 106, 105, 105, 103, 165, 101, 101, 133, 105, 107, 105, 135, 105, 103, 229, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence js_substr([In] CharSequence obj0, [In] object[] obj1)
    {
      object obj2 = (object) obj0.__\u003Cref\u003E;
      if (obj1.Length < 1)
      {
        object obj3 = obj2;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        return charSequence;
      }
      double num1 = ScriptRuntime.toInteger(obj1[0]);
      object obj4 = obj2;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      int num2 = ((CharSequence) ref charSequence1).length();
      if (num1 < 0.0)
      {
        num1 += (double) num2;
        if (num1 < 0.0)
          num1 = 0.0;
      }
      else if (num1 > (double) num2)
        num1 = (double) num2;
      double num3 = (double) num2;
      if (obj1.Length > 1)
      {
        object val = obj1[1];
        if (!Undefined.isUndefined(val))
        {
          double num4 = ScriptRuntime.toInteger(val);
          if (num4 < 0.0)
            num4 = 0.0;
          num3 = num4 + num1;
          if (num3 > (double) num2)
            num3 = (double) num2;
        }
      }
      object obj5 = obj2;
      int num5 = ByteCodeHelper.d2i(num1);
      int num6 = ByteCodeHelper.d2i(num3);
      int num7 = num5;
      object obj6 = obj5;
      charSequence1.__\u003Cref\u003E = (__Null) obj6;
      object obj7 = (object) ((CharSequence) ref charSequence1).subSequence(num7, num6).__\u003Cref\u003E;
      CharSequence charSequence2;
      charSequence2.__\u003Cref\u003E = (__Null) obj7;
      return charSequence2;
    }

    [LineNumberTable(new byte[] {163, 16, 99, 99, 98, 100, 105, 232, 69, 103, 103, 104, 107, 102, 234, 61, 232, 70, 104, 105, 104, 44, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string js_concat([In] string obj0, [In] object[] obj1)
    {
      int length = obj1.Length;
      switch (length)
      {
        case 0:
          return obj0;
        case 1:
          string str1 = ScriptRuntime.toString(obj1[0]);
          return String.instancehelper_concat(obj0, str1);
        default:
          int num = String.instancehelper_length(obj0);
          string[] strArray = new string[length];
          for (int index = 0; index != length; ++index)
          {
            string str2 = ScriptRuntime.toString(obj1[index]);
            strArray[index] = str2;
            num += String.instancehelper_length(str2);
          }
          StringBuilder stringBuilder = new StringBuilder(num);
          stringBuilder.append(obj0);
          for (int index = 0; index != length; ++index)
            stringBuilder.append(strArray[index]);
          return stringBuilder.toString();
      }
    }

    [LineNumberTable(new byte[] {158, 167, 106, 151, 115, 104, 104, 104, 104, 102, 164, 116, 135, 108, 105, 106, 105, 105, 103, 133, 101, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence js_slice([In] CharSequence obj0, [In] object[] obj1)
    {
      object obj2 = (object) obj0.__\u003Cref\u003E;
      double num1 = obj1.Length >= 1 ? ScriptRuntime.toInteger(obj1[0]) : 0.0;
      object obj3 = obj2;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      int num2 = ((CharSequence) ref charSequence1).length();
      if (num1 < 0.0)
      {
        num1 += (double) num2;
        if (num1 < 0.0)
          num1 = 0.0;
      }
      else if (num1 > (double) num2)
        num1 = (double) num2;
      double num3;
      if (obj1.Length < 2 || object.ReferenceEquals(obj1[1], Undefined.__\u003C\u003Einstance))
      {
        num3 = (double) num2;
      }
      else
      {
        num3 = ScriptRuntime.toInteger(obj1[1]);
        if (num3 < 0.0)
        {
          num3 += (double) num2;
          if (num3 < 0.0)
            num3 = 0.0;
        }
        else if (num3 > (double) num2)
          num3 = (double) num2;
        if (num3 < num1)
          num3 = num1;
      }
      object obj4 = obj2;
      int num4 = ByteCodeHelper.d2i(num1);
      int num5 = ByteCodeHelper.d2i(num3);
      int num6 = num4;
      object obj5 = obj4;
      charSequence1.__\u003Cref\u003E = (__Null) obj5;
      object obj6 = (object) ((CharSequence) ref charSequence1).subSequence(num6, num5).__\u003Cref\u003E;
      CharSequence charSequence2;
      charSequence2.__\u003Cref\u003E = (__Null) obj6;
      return charSequence2;
    }

    [LineNumberTable(new byte[] {162, 33, 103, 102, 105, 102, 99, 105, 106, 103, 108, 134, 105, 106, 102, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string tagify([In] Scriptable obj0, [In] string obj1, [In] string obj2, [In] object[] obj3)
    {
      string str = ScriptRuntime.toString((object) obj0);
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append('<').append(obj1);
      if (obj2 != null)
        stringBuilder.append(' ').append(obj2).append("=\"").append(ScriptRuntime.toString(obj3, 0)).append('"');
      stringBuilder.append('>').append(str).append("</").append(obj1).append('>');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {163, 72, 110, 138, 116, 176, 112, 166, 143, 117, 176, 104, 136, 99, 104, 104, 122, 136, 102, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string js_repeat(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] IdFunctionObject obj2,
      [In] object[] obj3)
    {
      string str = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj0, obj1, obj2));
      double integer = ScriptRuntime.toInteger(obj3, 0);
      if (integer < 0.0 || integer == double.PositiveInfinity)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.rangeError("Invalid count value"));
      if (integer == 0.0 || String.instancehelper_length(str) == 0)
        return "";
      long num1 = (long) String.instancehelper_length(str) * ByteCodeHelper.d2l(integer);
      StringBuilder stringBuilder1 = integer <= (double) int.MaxValue && num1 <= (long) int.MaxValue ? new StringBuilder((int) num1) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.rangeError("Invalid size or count value"));
      stringBuilder1.append(str);
      int num2 = 1;
      int num3;
      for (num3 = ByteCodeHelper.d2i(integer); num2 <= num3 / 2; num2 *= 2)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        object obj = (object) stringBuilder1;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        stringBuilder2.append(charSequence2);
      }
      if (num2 < num3)
        stringBuilder1.append(stringBuilder1.substring(0, String.instancehelper_length(str) * (num3 - num2)));
      return stringBuilder1.toString();
    }

    [LineNumberTable(new byte[] {162, 132, 103, 106, 102, 127, 2, 109, 114, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ScriptableObject defaultIndexPropertyDescriptor([In] object obj0)
    {
      object obj1 = (object) this.getParentScope();
      if ((Scriptable) obj1 == null)
        obj1 = (object) this;
      NativeObject nativeObject1 = new NativeObject();
      NativeObject nativeObject2 = nativeObject1;
      object obj2 = obj1;
      TopLevel.Builtins builtins = TopLevel.Builtins.__\u003C\u003EObject;
      Scriptable scope;
      if (obj2 != null)
        scope = obj2 is Scriptable scriptable2 ? scriptable2 : throw new IncompatibleClassChangeError();
      else
        scope = (Scriptable) null;
      TopLevel.Builtins type = builtins;
      ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeObject2, scope, type);
      nativeObject1.defineProperty("value", obj0, 0);
      nativeObject1.defineProperty("writable", (object) Boolean.valueOf(false), 0);
      nativeObject1.defineProperty("enumerable", (object) Boolean.valueOf(true), 0);
      nativeObject1.defineProperty("configurable", (object) Boolean.valueOf(false), 0);
      return (ScriptableObject) nativeObject1;
    }

    [LineNumberTable(new byte[] {159, 136, 162, 123, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      object obj = (object) "";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      new NativeString(charSequence).exportAsJSClass(48, obj0, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "String";

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getMaxInstanceId() => 1;

    [LineNumberTable(new byte[] {1, 109, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo([In] string obj0) => String.instancehelper_equals(obj0, (object) "length") ? IdScriptableObject.instanceIdInfo(7, 1) : base.findInstanceIdInfo(obj0);

    [LineNumberTable(new byte[] {9, 100, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getInstanceIdName([In] int obj0) => obj0 == 1 ? "length" : base.getInstanceIdName(obj0);

    [LineNumberTable(new byte[] {17, 100, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue([In] int obj0)
    {
      if (obj0 != 1)
        return base.getInstanceIdValue(obj0);
      object obj = (object) this.@string.__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return (object) ScriptRuntime.wrapInt(((CharSequence) ref charSequence).length());
    }

    [LineNumberTable(new byte[] {25, 147, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties([In] IdFunctionObject obj0)
    {
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -1, "fromCharCode", 1);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -5, "charAt", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -6, "charCodeAt", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -7, "indexOf", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -8, "lastIndexOf", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -9, "split", 3);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -10, "substring", 3);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -11, "toLowerCase", 1);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -12, "toUpperCase", 1);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -13, "substr", 3);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -14, "concat", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -15, "slice", 3);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -30, "equalsIgnoreCase", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -31, "match", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -32, "search", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -33, "replace", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -34, "localeCompare", 2);
      this.addIdFunctionProperty((Scriptable) obj0, NativeString.STRING_TAG, -35, "toLocaleLowerCase", 1);
      base.fillConstructorProperties(obj0);
    }

    [LineNumberTable(new byte[] {66, 101, 120, 161, 130, 159, 160, 106, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId([In] int obj0)
    {
      if (obj0 == 48)
      {
        this.initPrototypeMethod(NativeString.STRING_TAG, obj0, (Symbol) SymbolKey.__\u003C\u003EITERATOR, "[Symbol.iterator]", 0);
      }
      else
      {
        int arity;
        string propertyName;
        switch (obj0 - 1)
        {
          case 0:
            arity = 1;
            propertyName = "constructor";
            break;
          case 1:
            arity = 0;
            propertyName = "toString";
            break;
          case 2:
            arity = 0;
            propertyName = "toSource";
            break;
          case 3:
            arity = 0;
            propertyName = "valueOf";
            break;
          case 4:
            arity = 1;
            propertyName = "charAt";
            break;
          case 5:
            arity = 1;
            propertyName = "charCodeAt";
            break;
          case 6:
            arity = 1;
            propertyName = "indexOf";
            break;
          case 7:
            arity = 1;
            propertyName = "lastIndexOf";
            break;
          case 8:
            arity = 2;
            propertyName = "split";
            break;
          case 9:
            arity = 2;
            propertyName = "substring";
            break;
          case 10:
            arity = 0;
            propertyName = "toLowerCase";
            break;
          case 11:
            arity = 0;
            propertyName = "toUpperCase";
            break;
          case 12:
            arity = 2;
            propertyName = "substr";
            break;
          case 13:
            arity = 1;
            propertyName = "concat";
            break;
          case 14:
            arity = 2;
            propertyName = "slice";
            break;
          case 15:
            arity = 0;
            propertyName = "bold";
            break;
          case 16:
            arity = 0;
            propertyName = "italics";
            break;
          case 17:
            arity = 0;
            propertyName = "fixed";
            break;
          case 18:
            arity = 0;
            propertyName = "strike";
            break;
          case 19:
            arity = 0;
            propertyName = "small";
            break;
          case 20:
            arity = 0;
            propertyName = "big";
            break;
          case 21:
            arity = 0;
            propertyName = "blink";
            break;
          case 22:
            arity = 0;
            propertyName = "sup";
            break;
          case 23:
            arity = 0;
            propertyName = "sub";
            break;
          case 24:
            arity = 0;
            propertyName = "fontsize";
            break;
          case 25:
            arity = 0;
            propertyName = "fontcolor";
            break;
          case 26:
            arity = 0;
            propertyName = "link";
            break;
          case 27:
            arity = 0;
            propertyName = "anchor";
            break;
          case 28:
            arity = 1;
            propertyName = "equals";
            break;
          case 29:
            arity = 1;
            propertyName = "equalsIgnoreCase";
            break;
          case 30:
            arity = 1;
            propertyName = "match";
            break;
          case 31:
            arity = 1;
            propertyName = "search";
            break;
          case 32:
            arity = 2;
            propertyName = "replace";
            break;
          case 33:
            arity = 1;
            propertyName = "localeCompare";
            break;
          case 34:
            arity = 0;
            propertyName = "toLocaleLowerCase";
            break;
          case 35:
            arity = 0;
            propertyName = "toLocaleUpperCase";
            break;
          case 36:
            arity = 0;
            propertyName = "trim";
            break;
          case 37:
            arity = 0;
            propertyName = "trimLeft";
            break;
          case 38:
            arity = 0;
            propertyName = "trimRight";
            break;
          case 39:
            arity = 1;
            propertyName = "includes";
            break;
          case 40:
            arity = 1;
            propertyName = "startsWith";
            break;
          case 41:
            arity = 1;
            propertyName = "endsWith";
            break;
          case 42:
            arity = 0;
            propertyName = "normalize";
            break;
          case 43:
            arity = 1;
            propertyName = "repeat";
            break;
          case 44:
            arity = 1;
            propertyName = "codePointAt";
            break;
          case 45:
            arity = 1;
            propertyName = "padStart";
            break;
          case 46:
            arity = 1;
            propertyName = "padEnd";
            break;
          default:
            string str = String.valueOf(obj0);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
        }
        this.initPrototypeMethod(NativeString.STRING_TAG, obj0, propertyName, (string) null, arity);
      }
    }

    [LineNumberTable(new byte[] {160, 207, 109, 142, 167, 255, 160, 255, 82, 102, 122, 107, 113, 99, 98, 152, 99, 197, 101, 101, 102, 105, 105, 50, 168, 232, 69, 101, 105, 100, 171, 141, 148, 132, 186, 255, 3, 70, 120, 191, 3, 120, 255, 30, 70, 121, 108, 127, 3, 106, 134, 127, 2, 108, 200, 112, 240, 70, 112, 113, 191, 1, 140, 101, 142, 101, 142, 101, 238, 70, 182, 112, 207, 112, 210, 121, 255, 11, 69, 112, 237, 69, 112, 205, 121, 223, 10, 112, 202, 121, 223, 10, 175, 175, 175, 175, 175, 175, 175, 175, 175, 180, 180, 180, 212, 105, 106, 105, 107, 5, 230, 73, 101, 101, 101, 133, 163, 106, 110, 37, 225, 73, 112, 109, 104, 104, 135, 5, 236, 69, 112, 174, 112, 174, 112, 137, 99, 115, 136, 101, 116, 168, 172, 112, 137, 99, 115, 136, 133, 172, 112, 137, 131, 101, 116, 168, 172, 112, 191, 16, 170, 127, 0, 124, 124, 124, 144, 223, 13, 172, 112, 140, 159, 6, 10, 225, 70, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      [In] IdFunctionObject obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      if (!obj0.hasTag(NativeString.STRING_TAG))
        return base.execIdCall(obj0, obj1, obj2, obj3, obj4);
      int num1 = obj0.methodId();
      while (true)
      {
        switch (num1)
        {
          case -35:
          case -34:
          case -33:
          case -32:
          case -31:
          case -30:
          case -15:
          case -14:
          case -13:
          case -12:
          case -11:
          case -10:
          case -9:
          case -8:
          case -7:
          case -6:
          case -5:
            if (obj4.Length > 0)
            {
              obj3 = ScriptRuntime.toObject(obj1, obj2, (object) ScriptRuntime.toCharSequence(obj4[0]).__\u003Cref\u003E);
              object[] objArray = new object[obj4.Length - 1];
              if (objArray.Length >= 0)
                ByteCodeHelper.arraycopy((object) obj4, 1, (object) objArray, 0, objArray.Length);
              obj4 = objArray;
            }
            else
              obj3 = ScriptRuntime.toObject(obj1, obj2, (object) ScriptRuntime.toCharSequence((object) obj3).__\u003Cref\u003E);
            num1 = -num1;
            continue;
          case -1:
            goto label_10;
          case 1:
            goto label_16;
          case 2:
          case 4:
            goto label_21;
          case 3:
            goto label_24;
          case 5:
          case 6:
            goto label_25;
          case 7:
            goto label_33;
          case 8:
            goto label_41;
          case 9:
            goto label_42;
          case 10:
            goto label_43;
          case 11:
            goto label_44;
          case 12:
            goto label_45;
          case 13:
            goto label_46;
          case 14:
            goto label_47;
          case 15:
            goto label_48;
          case 16:
            goto label_49;
          case 17:
            goto label_50;
          case 18:
            goto label_51;
          case 19:
            goto label_52;
          case 20:
            goto label_53;
          case 21:
            goto label_54;
          case 22:
            goto label_55;
          case 23:
            goto label_56;
          case 24:
            goto label_57;
          case 25:
            goto label_58;
          case 26:
            goto label_59;
          case 27:
            goto label_60;
          case 28:
            goto label_61;
          case 29:
          case 30:
            goto label_62;
          case 31:
          case 32:
          case 33:
            goto label_63;
          case 34:
            goto label_64;
          case 35:
            goto label_65;
          case 36:
            goto label_66;
          case 37:
            goto label_67;
          case 38:
            goto label_74;
          case 39:
            goto label_78;
          case 40:
          case 41:
          case 42:
            goto label_34;
          case 43:
            goto label_82;
          case 44:
            goto label_94;
          case 45:
            goto label_95;
          case 46:
          case 47:
            goto label_40;
          case 48:
            goto label_98;
          default:
            goto label_99;
        }
      }
label_10:
      int length1 = obj4.Length;
      if (length1 < 1)
        return (object) "";
      StringBuilder stringBuilder1 = new StringBuilder(length1);
      for (int index = 0; index != length1; ++index)
        stringBuilder1.append(ScriptRuntime.toUint16(obj4[index]));
      return (object) stringBuilder1.toString();
label_16:
      object obj5 = obj4.Length != 0 ? (!ScriptRuntime.isSymbol(obj4[0]) || obj3 == null ? (object) ScriptRuntime.toCharSequence(obj4[0]).__\u003Cref\u003E : (object) Object.instancehelper_toString(obj4[0])) : (object) "";
      if (obj3 == null)
      {
        object obj6 = obj5;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj6;
        return (object) new NativeString(charSequence);
      }
      if (obj5 is string)
        return obj5;
      object obj7 = obj5;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj7;
      return (object) ((CharSequence) ref charSequence1).toString();
label_21:
      object obj8 = (object) NativeString.realThis(obj3, obj0).@string.__\u003Cref\u003E;
      if (obj8 is string)
        return obj8;
      object obj9 = obj8;
      CharSequence charSequence2;
      charSequence2.__\u003Cref\u003E = (__Null) obj9;
      return (object) ((CharSequence) ref charSequence2).toString();
label_24:
      object obj10 = (object) NativeString.realThis(obj3, obj0).@string.__\u003Cref\u003E;
      StringBuilder stringBuilder2 = new StringBuilder().append("(new String(\"");
      object obj11 = obj10;
      CharSequence charSequence3;
      charSequence3.__\u003Cref\u003E = (__Null) obj11;
      string str1 = ScriptRuntime.escapeString(((CharSequence) ref charSequence3).toString());
      return (object) stringBuilder2.append(str1).append("\"))").toString();
label_25:
      object obj12 = (object) ScriptRuntime.toCharSequence((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)).__\u003Cref\u003E;
      double integer1 = ScriptRuntime.toInteger(obj4, 0);
      if (integer1 >= 0.0)
      {
        double num2 = integer1;
        object obj6 = obj12;
        CharSequence charSequence4;
        charSequence4.__\u003Cref\u003E = (__Null) obj6;
        double num3 = (double) ((CharSequence) ref charSequence4).length();
        if (num2 < num3)
        {
          object obj13 = obj12;
          int num4 = ByteCodeHelper.d2i(integer1);
          object obj14 = obj13;
          charSequence4.__\u003Cref\u003E = (__Null) obj14;
          int i = (int) ((CharSequence) ref charSequence4).charAt(num4);
          return num1 == 5 ? (object) String.valueOf((char) i) : (object) ScriptRuntime.wrapInt(i);
        }
      }
      return num1 == 5 ? (object) "" : (object) ScriptRuntime.__\u003C\u003ENaNobj;
label_33:
      return (object) ScriptRuntime.wrapInt(NativeString.js_indexOf(7, ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)), obj4));
label_34:
      string str2 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0));
      if (obj4.Length > 0 && obj4[0] is NativeRegExp)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError2("msg.first.arg.not.regexp", (object) ((Class) ClassLiteral<String>.Value).getSimpleName(), (object) obj0.getFunctionName()));
      int num5 = NativeString.js_indexOf(num1, str2, obj4);
      switch (num1)
      {
        case 40:
          return (object) Boolean.valueOf(num5 != -1);
        case 41:
          return (object) Boolean.valueOf(num5 == 0);
        case 42:
          return (object) Boolean.valueOf(num5 != -1);
      }
label_40:
      return (object) NativeString.js_pad(obj1, obj3, obj0, obj4, Boolean.valueOf(num1 == 46));
label_41:
      return (object) ScriptRuntime.wrapInt(NativeString.js_lastIndexOf(ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)), obj4));
label_42:
      string str3 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0));
      return ScriptRuntime.checkRegExpProxy(obj1).js_split(obj1, obj2, str3, obj4);
label_43:
      object obj15 = (object) ScriptRuntime.toCharSequence((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)).__\u003Cref\u003E;
      Context context = obj1;
      object obj16 = obj15;
      object[] objArray1 = obj4;
      object obj17 = obj16;
      CharSequence charSequence5;
      charSequence5.__\u003Cref\u003E = (__Null) obj17;
      CharSequence charSequence6 = charSequence5;
      object[] objArray2 = objArray1;
      return (object) NativeString.js_substring(context, charSequence6, objArray2).__\u003Cref\u003E;
label_44:
      return (object) String.instancehelper_toLowerCase(ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)), (Locale) Locale.ROOT);
label_45:
      return (object) String.instancehelper_toUpperCase(ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)), (Locale) Locale.ROOT);
label_46:
      object obj18 = (object) ScriptRuntime.toCharSequence((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)).__\u003Cref\u003E;
      object[] objArray3 = obj4;
      object obj19 = obj18;
      CharSequence charSequence7;
      charSequence7.__\u003Cref\u003E = (__Null) obj19;
      return (object) NativeString.js_substr(charSequence7, objArray3).__\u003Cref\u003E;
label_47:
      return (object) NativeString.js_concat(ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)), obj4);
label_48:
      object obj20 = (object) ScriptRuntime.toCharSequence((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)).__\u003Cref\u003E;
      object[] objArray4 = obj4;
      object obj21 = obj20;
      CharSequence charSequence8;
      charSequence8.__\u003Cref\u003E = (__Null) obj21;
      return (object) NativeString.js_slice(charSequence8, objArray4).__\u003Cref\u003E;
label_49:
      return (object) NativeString.tagify(obj3, "b", (string) null, (object[]) null);
label_50:
      return (object) NativeString.tagify(obj3, "i", (string) null, (object[]) null);
label_51:
      return (object) NativeString.tagify(obj3, "tt", (string) null, (object[]) null);
label_52:
      return (object) NativeString.tagify(obj3, "strike", (string) null, (object[]) null);
label_53:
      return (object) NativeString.tagify(obj3, "small", (string) null, (object[]) null);
label_54:
      return (object) NativeString.tagify(obj3, "big", (string) null, (object[]) null);
label_55:
      return (object) NativeString.tagify(obj3, "blink", (string) null, (object[]) null);
label_56:
      return (object) NativeString.tagify(obj3, "sup", (string) null, (object[]) null);
label_57:
      return (object) NativeString.tagify(obj3, "sub", (string) null, (object[]) null);
label_58:
      return (object) NativeString.tagify(obj3, "font", "size", obj4);
label_59:
      return (object) NativeString.tagify(obj3, "font", "color", obj4);
label_60:
      return (object) NativeString.tagify(obj3, "a", "href", obj4);
label_61:
      return (object) NativeString.tagify(obj3, "a", "name", obj4);
label_62:
      string str4 = ScriptRuntime.toString((object) obj3);
      string str5 = ScriptRuntime.toString(obj4, 0);
      return (object) ScriptRuntime.wrapBoolean(num1 != 29 ? String.instancehelper_equalsIgnoreCase(str4, str5) : String.instancehelper_equals(str4, (object) str5));
label_63:
      int i1 = num1 != 31 ? (num1 != 32 ? 2 : 3) : 1;
      ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0);
      return ScriptRuntime.checkRegExpProxy(obj1).action(obj1, obj2, obj3, obj4, i1);
label_64:
      string str6 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0));
      Collator instance = Collator.getInstance(obj1.getLocale());
      instance.setStrength(3);
      instance.setDecomposition(1);
      return (object) ScriptRuntime.wrapNumber((double) instance.compare(str6, ScriptRuntime.toString(obj4, 0)));
label_65:
      return (object) String.instancehelper_toLowerCase(ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)), obj1.getLocale());
label_66:
      return (object) String.instancehelper_toUpperCase(ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0)), obj1.getLocale());
label_67:
      string str7 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0));
      char[] charArray1 = String.instancehelper_toCharArray(str7);
      int index1 = 0;
      while (index1 < charArray1.Length && ScriptRuntime.isJSWhitespaceOrLineTerminator((int) charArray1[index1]))
        ++index1;
      int length2 = charArray1.Length;
      while (length2 > index1 && ScriptRuntime.isJSWhitespaceOrLineTerminator((int) charArray1[length2 - 1]))
        length2 += -1;
      return (object) String.instancehelper_substring(str7, index1, length2);
label_74:
      string str8 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0));
      char[] charArray2 = String.instancehelper_toCharArray(str8);
      int index2 = 0;
      while (index2 < charArray2.Length && ScriptRuntime.isJSWhitespaceOrLineTerminator((int) charArray2[index2]))
        ++index2;
      int length3 = charArray2.Length;
      return (object) String.instancehelper_substring(str8, index2, length3);
label_78:
      string str9 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0));
      char[] charArray3 = String.instancehelper_toCharArray(str9);
      int num6 = 0;
      int length4 = charArray3.Length;
      while (length4 > num6 && ScriptRuntime.isJSWhitespaceOrLineTerminator((int) charArray3[length4 - 1]))
        length4 += -1;
      return (object) String.instancehelper_substring(str9, num6, length4);
label_82:
      if (obj4.Length == 0 || Undefined.isUndefined(obj4[0]))
      {
        string str10 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0));
        Normalizer.Form nfc = (Normalizer.Form) Normalizer.Form.NFC;
        object obj6 = (object) str10;
        CharSequence charSequence4;
        charSequence4.__\u003Cref\u003E = (__Null) obj6;
        return (object) Normalizer.normalize(charSequence4, nfc);
      }
      string str11 = ScriptRuntime.toString(obj4, 0);
      Normalizer.Form form1;
      if (String.instancehelper_equals(((Enum) Normalizer.Form.NFD).name(), (object) str11))
        form1 = (Normalizer.Form) Normalizer.Form.NFD;
      else if (String.instancehelper_equals(((Enum) Normalizer.Form.NFKC).name(), (object) str11))
        form1 = (Normalizer.Form) Normalizer.Form.NFKC;
      else if (String.instancehelper_equals(((Enum) Normalizer.Form.NFKD).name(), (object) str11))
        form1 = (Normalizer.Form) Normalizer.Form.NFKD;
      else
        form1 = String.instancehelper_equals(((Enum) Normalizer.Form.NFC).name(), (object) str11) ? (Normalizer.Form) Normalizer.Form.NFC : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.rangeError("The normalization form should be one of 'NFC', 'NFD', 'NFKC', 'NFKD'."));
      string str12 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0));
      Normalizer.Form form2 = form1;
      object obj22 = (object) str12;
      CharSequence charSequence9;
      charSequence9.__\u003Cref\u003E = (__Null) obj22;
      return (object) Normalizer.normalize(charSequence9, form2);
label_94:
      return (object) NativeString.js_repeat(obj1, obj3, obj0, obj4);
label_95:
      string str13 = ScriptRuntime.toString((object) ScriptRuntimeES6.requireObjectCoercible(obj1, obj3, obj0));
      double integer2 = ScriptRuntime.toInteger(obj4, 0);
      return integer2 < 0.0 || integer2 >= (double) String.instancehelper_length(str13) ? Undefined.__\u003C\u003Einstance : (object) Integer.valueOf(String.instancehelper_codePointAt(str13, ByteCodeHelper.d2i(integer2)));
label_98:
      return (object) new NativeStringIterator(obj2, obj3);
label_99:
      string str14 = new StringBuilder().append("String.prototype has no method: ").append(obj0.getFunctionName()).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str14);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CharSequence toCharSequence()
    {
      object obj = (object) this.@string.__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [LineNumberTable(684)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.@string.__\u003Cref\u003E is string)
        return (string) this.@string.__\u003Cref\u003E;
      object obj = (object) this.@string.__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return ((CharSequence) ref charSequence).toString();
    }

    [LineNumberTable(new byte[] {162, 66, 127, 6, 159, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get([In] int obj0, [In] Scriptable obj1)
    {
      if (0 <= obj0)
      {
        int num1 = obj0;
        object obj2 = (object) this.@string.__\u003Cref\u003E;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        int num2 = ((CharSequence) ref charSequence).length();
        if (num1 < num2)
        {
          // ISSUE: variable of the null type
          __Null local = this.@string.__\u003Cref\u003E;
          int num3 = obj0;
          object obj3 = (object) local;
          charSequence.__\u003Cref\u003E = (__Null) obj3;
          return (object) String.valueOf(((CharSequence) ref charSequence).charAt(num3));
        }
      }
      return base.get(obj0, obj1);
    }

    [LineNumberTable(new byte[] {162, 74, 127, 6, 129, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put([In] int obj0, [In] Scriptable obj1, [In] object obj2)
    {
      if (0 <= obj0)
      {
        int num1 = obj0;
        object obj = (object) this.@string.__\u003Cref\u003E;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        int num2 = ((CharSequence) ref charSequence).length();
        if (num1 < num2)
          return;
      }
      base.put(obj0, obj1, obj2);
    }

    [LineNumberTable(new byte[] {162, 82, 127, 6, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has([In] int obj0, [In] Scriptable obj1)
    {
      if (0 <= obj0)
      {
        int num1 = obj0;
        object obj = (object) this.@string.__\u003Cref\u003E;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        int num2 = ((CharSequence) ref charSequence).length();
        if (num1 < num2)
          return true;
      }
      return base.has(obj0, obj1);
    }

    [LineNumberTable(new byte[] {162, 90, 127, 6, 98, 113, 132, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getAttributes([In] int obj0)
    {
      if (0 <= obj0)
      {
        int num1 = obj0;
        object obj = (object) this.@string.__\u003Cref\u003E;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        int num2 = ((CharSequence) ref charSequence).length();
        if (num1 < num2)
        {
          int num3 = 5;
          if (Context.getContext().getLanguageVersion() < 200)
            num3 |= 2;
          return num3;
        }
      }
      return base.getAttributes(obj0);
    }

    [LineNumberTable(new byte[] {158, 216, 100, 102, 118, 105, 159, 12, 127, 9, 44, 168, 109, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object[] getIds([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      Context currentContext = Context.getCurrentContext();
      if (currentContext == null || currentContext.getLanguageVersion() < 200)
        return base.getIds(num1 != 0, num2 != 0);
      object[] ids = base.getIds(num1 != 0, num2 != 0);
      int length = ids.Length;
      object obj2 = (object) this.@string.__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      int num3 = ((CharSequence) ref charSequence).length();
      object[] objArray = new object[length + num3];
      int index = 0;
      while (true)
      {
        int num4 = index;
        object obj3 = (object) this.@string.__\u003Cref\u003E;
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        int num5 = ((CharSequence) ref charSequence).length();
        if (num4 < num5)
        {
          objArray[index] = (object) Integer.valueOf(index);
          ++index;
        }
        else
          break;
      }
      ByteCodeHelper.arraycopy((object) ids, 0, (object) objArray, index, ids.Length);
      return objArray;
    }

    [LineNumberTable(new byte[] {162, 119, 114, 111, 104, 127, 12, 114, 127, 17, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override ScriptableObject getOwnPropertyDescriptor(
      [In] Context obj0,
      [In] object obj1)
    {
      if (!(obj1 is Symbol) && obj0 != null && obj0.getLanguageVersion() >= 200)
      {
        ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(obj0, obj1);
        if (stringIdOrIndex.stringId == null && 0 <= stringIdOrIndex.index)
        {
          int index1 = stringIdOrIndex.index;
          object obj2 = (object) this.@string.__\u003Cref\u003E;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj2;
          int num = ((CharSequence) ref charSequence).length();
          if (index1 < num)
          {
            // ISSUE: variable of the null type
            __Null local = this.@string.__\u003Cref\u003E;
            int index2 = stringIdOrIndex.index;
            object obj3 = (object) local;
            charSequence.__\u003Cref\u003E = (__Null) obj3;
            return this.defaultIndexPropertyDescriptor((object) String.valueOf(((CharSequence) ref charSequence).charAt(index2)));
          }
        }
      }
      return base.getOwnPropertyDescriptor(obj0, obj1);
    }

    [LineNumberTable(new byte[] {163, 141, 109, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId([In] Symbol obj0) => SymbolKey.__\u003C\u003EITERATOR.equals((object) obj0) ? 48 : 0;

    [LineNumberTable(new byte[] {163, 155, 98, 162, 159, 47, 104, 101, 124, 99, 133, 101, 124, 99, 133, 104, 124, 99, 229, 69, 104, 101, 102, 104, 101, 102, 104, 104, 102, 200, 159, 54, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 133, 159, 73, 102, 99, 133, 104, 101, 102, 104, 104, 102, 200, 102, 98, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 133, 159, 11, 102, 98, 133, 102, 99, 133, 102, 98, 133, 102, 99, 133, 133, 159, 85, 102, 98, 133, 102, 99, 133, 102, 99, 133, 102, 98, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 133, 159, 11, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 99, 133, 133, 104, 101, 102, 103, 104, 102, 200, 159, 19, 102, 99, 133, 102, 99, 133, 102, 99, 133, 102, 98, 133, 102, 98, 130, 130, 102, 99, 130, 102, 99, 130, 104, 101, 102, 101, 101, 102, 195, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId([In] string obj0)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(obj0))
      {
        case 3:
          switch (String.instancehelper_charAt(obj0, 2))
          {
            case 'b':
              if (String.instancehelper_charAt(obj0, 0) == 's' && String.instancehelper_charAt(obj0, 1) == 'u')
              {
                num = 24;
                break;
              }
              goto label_62;
            case 'g':
              if (String.instancehelper_charAt(obj0, 0) == 'b' && String.instancehelper_charAt(obj0, 1) == 'i')
              {
                num = 21;
                break;
              }
              goto label_62;
            case 'p':
              if (String.instancehelper_charAt(obj0, 0) == 's' && String.instancehelper_charAt(obj0, 1) == 'u')
              {
                num = 23;
                break;
              }
              goto label_62;
            default:
              goto label_62;
          }
          break;
        case 4:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'b':
              str = "bold";
              num = 16;
              goto label_62;
            case 'l':
              str = "link";
              num = 27;
              goto label_62;
            case 't':
              str = "trim";
              num = 37;
              goto label_62;
            default:
              goto label_62;
          }
        case 5:
          switch (String.instancehelper_charAt(obj0, 4))
          {
            case 'd':
              str = "fixed";
              num = 18;
              goto label_62;
            case 'e':
              str = "slice";
              num = 15;
              goto label_62;
            case 'h':
              str = "match";
              num = 31;
              goto label_62;
            case 'k':
              str = "blink";
              num = 22;
              goto label_62;
            case 'l':
              str = "small";
              num = 20;
              goto label_62;
            case 't':
              str = "split";
              num = 9;
              goto label_62;
            default:
              goto label_62;
          }
        case 6:
          switch (String.instancehelper_charAt(obj0, 1))
          {
            case 'a':
              str = "padEnd";
              num = 47;
              goto label_62;
            case 'e':
              switch (String.instancehelper_charAt(obj0, 0))
              {
                case 'r':
                  str = "repeat";
                  num = 44;
                  goto label_62;
                case 's':
                  str = "search";
                  num = 32;
                  goto label_62;
                default:
                  goto label_62;
              }
            case 'h':
              str = "charAt";
              num = 5;
              goto label_62;
            case 'n':
              str = "anchor";
              num = 28;
              goto label_62;
            case 'o':
              str = "concat";
              num = 14;
              goto label_62;
            case 'q':
              str = "equals";
              num = 29;
              goto label_62;
            case 't':
              str = "strike";
              num = 19;
              goto label_62;
            case 'u':
              str = "substr";
              num = 13;
              goto label_62;
            default:
              goto label_62;
          }
        case 7:
          switch (String.instancehelper_charAt(obj0, 1))
          {
            case 'a':
              str = "valueOf";
              num = 4;
              goto label_62;
            case 'e':
              str = "replace";
              num = 33;
              goto label_62;
            case 'n':
              str = "indexOf";
              num = 7;
              goto label_62;
            case 't':
              str = "italics";
              num = 17;
              goto label_62;
            default:
              goto label_62;
          }
        case 8:
          switch (String.instancehelper_charAt(obj0, 6))
          {
            case 'c':
              str = "toSource";
              num = 3;
              goto label_62;
            case 'e':
              str = "includes";
              num = 40;
              goto label_62;
            case 'f':
              str = "trimLeft";
              num = 38;
              goto label_62;
            case 'n':
              str = "toString";
              num = 2;
              goto label_62;
            case 'r':
              str = "padStart";
              num = 46;
              goto label_62;
            case 't':
              str = "endsWith";
              num = 42;
              goto label_62;
            case 'z':
              str = "fontsize";
              num = 25;
              goto label_62;
            default:
              goto label_62;
          }
        case 9:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'f':
              str = "fontcolor";
              num = 26;
              goto label_62;
            case 'n':
              str = "normalize";
              num = 43;
              goto label_62;
            case 's':
              str = "substring";
              num = 10;
              goto label_62;
            case 't':
              str = "trimRight";
              num = 39;
              goto label_62;
            default:
              goto label_62;
          }
        case 10:
          switch (String.instancehelper_charAt(obj0, 0))
          {
            case 'c':
              str = "charCodeAt";
              num = 6;
              goto label_62;
            case 's':
              str = "startsWith";
              num = 41;
              goto label_62;
            default:
              goto label_62;
          }
        case 11:
          switch (String.instancehelper_charAt(obj0, 2))
          {
            case 'L':
              str = "toLowerCase";
              num = 11;
              goto label_62;
            case 'U':
              str = "toUpperCase";
              num = 12;
              goto label_62;
            case 'd':
              str = "codePointAt";
              num = 45;
              goto label_62;
            case 'n':
              str = "constructor";
              num = 1;
              goto label_62;
            case 's':
              str = "lastIndexOf";
              num = 8;
              goto label_62;
            default:
              goto label_62;
          }
        case 13:
          str = "localeCompare";
          num = 34;
          goto default;
        case 16:
          str = "equalsIgnoreCase";
          num = 30;
          goto default;
        case 17:
          switch (String.instancehelper_charAt(obj0, 8))
          {
            case 'L':
              str = "toLocaleLowerCase";
              num = 35;
              goto label_62;
            case 'U':
              str = "toLocaleUpperCase";
              num = 36;
              goto label_62;
            default:
              goto label_62;
          }
        default:
label_62:
          if (str != null && !object.ReferenceEquals((object) str, (object) obj0) && !String.instancehelper_equals(str, (object) obj0))
          {
            num = 0;
            break;
          }
          break;
      }
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeString()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeString"))
        return;
      NativeString.STRING_TAG = (object) "String";
    }
  }
}
