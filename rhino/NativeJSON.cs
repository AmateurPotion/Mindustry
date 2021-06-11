// Decompiled with JetBrains decompiler
// Type: rhino.NativeJSON
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using rhino.json;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public sealed class NativeJSON : IdScriptableObject
  {
    [Modifiers]
    private static object JSON_TAG;
    private const int MAX_STRINGIFY_GAP_LENGTH = 10;
    private const int Id_toSource = 1;
    private const int Id_parse = 2;
    private const int Id_stringify = 3;
    private const int LAST_METHOD_ID = 3;
    private const int MAX_ID = 3;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 177, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeJSON()
    {
    }

    [LineNumberTable(new byte[] {77, 105, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object parse(Context cx, Scriptable scope, string jtext, Callable reviver)
    {
      object obj = NativeJSON.parse(cx, scope, jtext);
      Scriptable s = cx.newObject(scope);
      s.put("", s, obj);
      return NativeJSON.walk(cx, scope, reviver, s, (object) "");
    }

    [LineNumberTable(new byte[] {69, 127, 4, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object parse([In] Context obj0, [In] Scriptable obj1, [In] string obj2)
    {
      object obj;
      JsonParser.ParseException parseException;
      try
      {
        obj = new JsonParser(obj0, obj1).parseValue(obj2);
      }
      catch (JsonParser.ParseException ex)
      {
        parseException = (JsonParser.ParseException) ByteCodeHelper.MapException<JsonParser.ParseException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return obj;
label_3:
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("SyntaxError", Throwable.instancehelper_getMessage((Exception) parseException)));
    }

    [LineNumberTable(new byte[] {160, 107, 102, 134, 98, 130, 104, 108, 107, 102, 104, 127, 14, 109, 114, 107, 114, 142, 165, 105, 113, 105, 169, 105, 111, 107, 118, 105, 107, 104, 106, 202, 239, 71, 103, 104, 109, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object stringify(
      Context cx,
      Scriptable scope,
      object value,
      object replacer,
      object space)
    {
      string str1 = "";
      string str2 = "";
      LinkedList linkedList = (LinkedList) null;
      Callable callable = (Callable) null;
      if (replacer is Callable)
        callable = (Callable) replacer;
      else if (replacer is NativeArray)
      {
        linkedList = new LinkedList();
        NativeArray nativeArray = (NativeArray) replacer;
        Iterator iterator = nativeArray.getIndexIds().iterator();
        while (iterator.hasNext())
        {
          int index = ((Integer) iterator.next()).intValue();
          object val = nativeArray.get(index, (Scriptable) nativeArray);
          switch (val)
          {
            case string _:
            case Number _:
              ((List) linkedList).add(val);
              continue;
            case NativeString _:
            case NativeNumber _:
              ((List) linkedList).add((object) ScriptRuntime.toString(val));
              continue;
            default:
              continue;
          }
        }
      }
      if (space is NativeNumber)
        space = (object) Double.valueOf(ScriptRuntime.toNumber(space));
      else if (space is NativeString)
        space = (object) ScriptRuntime.toString(space);
      if (space is Number)
      {
        int num = Math.min(10, ByteCodeHelper.d2i(ScriptRuntime.toInteger(space)));
        str2 = num <= 0 ? "" : NativeJSON.repeat(' ', num);
        space = (object) Integer.valueOf(num);
      }
      else if (space is string)
      {
        str2 = (string) space;
        if (String.instancehelper_length(str2) > 10)
          str2 = String.instancehelper_substring(str2, 0, 10);
      }
      NativeJSON.StringifyState stringifyState = new NativeJSON.StringifyState(cx, scope, str1, str2, callable, (List) linkedList, space);
      NativeObject nativeObject = new NativeObject();
      nativeObject.setParentScope(scope);
      nativeObject.setPrototype(ScriptableObject.getObjectPrototype(scope));
      nativeObject.defineProperty("", value, 0);
      return NativeJSON.str((object) "", (Scriptable) nativeObject, stringifyState);
    }

    [LineNumberTable(new byte[] {86, 105, 150, 175, 107, 103, 107, 108, 138, 105, 104, 109, 110, 138, 139, 98, 100, 114, 110, 138, 235, 48, 234, 84, 101, 104, 124, 109, 110, 105, 148, 143, 105, 151, 240, 53, 235, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object walk(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Callable obj2,
      [In] Scriptable obj3,
      [In] object obj4)
    {
      object obj5 = !(obj4 is Number) ? obj3.get((string) obj4, obj3) : obj3.get(((Number) obj4).intValue(), obj3);
      if (obj5 is Scriptable)
      {
        Scriptable s = (Scriptable) obj5;
        if (s is NativeArray)
        {
          long length = ((NativeArray) s).getLength();
          for (long index = 0; index < length; ++index)
          {
            if (index > (long) int.MaxValue)
            {
              string str = Long.toString(index);
              object objA = NativeJSON.walk(obj0, obj1, obj2, s, (object) str);
              if (object.ReferenceEquals(objA, Undefined.__\u003C\u003Einstance))
                s.delete(str);
              else
                s.put(str, s, objA);
            }
            else
            {
              int i = (int) index;
              object objA = NativeJSON.walk(obj0, obj1, obj2, s, (object) Integer.valueOf(i));
              if (object.ReferenceEquals(objA, Undefined.__\u003C\u003Einstance))
                s.delete(i);
              else
                s.put(i, s, objA);
            }
          }
        }
        else
        {
          object[] ids = s.getIds();
          int length = ids.Length;
          for (int index = 0; index < length; ++index)
          {
            object obj6 = ids[index];
            object objA = NativeJSON.walk(obj0, obj1, obj2, s, obj6);
            if (object.ReferenceEquals(objA, Undefined.__\u003C\u003Einstance))
            {
              if (obj6 is Number)
                s.delete(((Number) obj6).intValue());
              else
                s.delete((string) obj6);
            }
            else if (obj6 is Number)
              s.put(((Number) obj6).intValue(), s, objA);
            else
              s.put((string) obj6, s, objA);
          }
        }
      }
      return obj2.call(obj0, obj1, obj3, new object[2]
      {
        obj4,
        obj5
      });
    }

    [LineNumberTable(new byte[] {159, 95, 98, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string repeat([In] char obj0, [In] int obj1)
    {
      int num = (int) obj0;
      char[] chArray = new char[obj1];
      Arrays.fill(chArray, (char) num);
      return String.newhelper(chArray);
    }

    [LineNumberTable(new byte[] {160, 163, 104, 143, 178, 122, 113, 104, 255, 2, 69, 104, 255, 8, 69, 104, 111, 104, 105, 104, 177, 105, 115, 147, 104, 172, 104, 110, 159, 1, 135, 166, 112, 104, 141, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object str([In] object obj0, [In] Scriptable obj1, [In] NativeJSON.StringifyState obj2)
    {
      object val = !(obj0 is string) ? ScriptableObject.getProperty(obj1, ((Number) obj0).intValue()) : ScriptableObject.getProperty(obj1, (string) obj0);
      if (val is Scriptable && ScriptableObject.hasProperty((Scriptable) val, "toJSON") && ScriptableObject.getProperty((Scriptable) val, "toJSON") is Callable)
        val = ScriptableObject.callMethod(obj2.cx, (Scriptable) val, "toJSON", new object[1]
        {
          obj0
        });
      if (obj2.replacer != null)
        val = obj2.replacer.call(obj2.cx, obj2.scope, obj1, new object[2]
        {
          obj0,
          val
        });
      if (val is NativeNumber)
        val = (object) Double.valueOf(ScriptRuntime.toNumber(val));
      else if (val is NativeString)
        val = (object) ScriptRuntime.toString(val);
      else if (val is NativeBoolean)
        val = ((NativeBoolean) val).getDefaultValue(ScriptRuntime.__\u003C\u003EBooleanClass);
      if (val == null)
        return (object) "null";
      if (Object.instancehelper_equals(val, (object) Boolean.TRUE))
        return (object) "true";
      if (Object.instancehelper_equals(val, (object) Boolean.FALSE))
        return (object) "false";
      if (CharSequence.IsInstance(val))
        return (object) NativeJSON.quote(Object.instancehelper_toString(val));
      switch (val)
      {
        case Number _:
          double num = ((Number) val).doubleValue();
          return !Double.isNaN(num) && num != double.PositiveInfinity && num != double.NegativeInfinity ? (object) ScriptRuntime.toString(val) : (object) "null";
        case Scriptable _:
          switch (val)
          {
            case Callable _:
              break;
            case NativeArray _:
              return (object) NativeJSON.ja((NativeArray) val, obj2);
            default:
              return (object) NativeJSON.jo((Scriptable) val, obj2);
          }
          break;
      }
      return Undefined.__\u003C\u003Einstance;
    }

    [LineNumberTable(new byte[] {161, 69, 110, 105, 103, 105, 104, 159, 43, 108, 133, 108, 133, 108, 133, 108, 133, 108, 133, 108, 130, 108, 130, 101, 108, 123, 105, 98, 232, 34, 233, 99, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string quote([In] string obj0)
    {
      StringBuilder stringBuilder = new StringBuilder(String.instancehelper_length(obj0) + 2);
      stringBuilder.append('"');
      int num1 = String.instancehelper_length(obj0);
      for (int index = 0; index < num1; ++index)
      {
        int num2 = (int) String.instancehelper_charAt(obj0, index);
        switch (num2)
        {
          case 8:
            stringBuilder.append("\\b");
            break;
          case 9:
            stringBuilder.append("\\t");
            break;
          case 10:
            stringBuilder.append("\\n");
            break;
          case 12:
            stringBuilder.append("\\f");
            break;
          case 13:
            stringBuilder.append("\\r");
            break;
          case 34:
            stringBuilder.append("\\\"");
            break;
          case 92:
            stringBuilder.append("\\\\");
            break;
          default:
            if (num2 < 32)
            {
              stringBuilder.append("\\u");
              string str = String.format("%04x", new object[1]
              {
                (object) Integer.valueOf(num2)
              });
              stringBuilder.append(str);
              break;
            }
            stringBuilder.append((char) num2);
            break;
        }
      }
      stringBuilder.append('"');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 25, 111, 144, 141, 103, 127, 7, 134, 103, 138, 105, 145, 144, 110, 142, 233, 54, 234, 80, 104, 140, 109, 159, 13, 127, 2, 106, 223, 29, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string ja([In] NativeArray obj0, [In] NativeJSON.StringifyState obj1)
    {
      if (obj1.stack.search((object) obj0) != -1)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.cyclic.value"));
      obj1.stack.push((object) obj0);
      string indent = obj1.indent;
      obj1.indent = new StringBuilder().append(obj1.indent).append(obj1.gap).toString();
      LinkedList linkedList = new LinkedList();
      long length = obj0.getLength();
      for (long index = 0; index < length; ++index)
      {
        object objA = index <= (long) int.MaxValue ? NativeJSON.str((object) Integer.valueOf((int) index), (Scriptable) obj0, obj1) : NativeJSON.str((object) Long.toString(index), (Scriptable) obj0, obj1);
        if (object.ReferenceEquals(objA, Undefined.__\u003C\u003Einstance))
          ((List) linkedList).add((object) "null");
        else
          ((List) linkedList).add(objA);
      }
      string str1;
      if (((List) linkedList).isEmpty())
        str1 = "[]";
      else if (String.instancehelper_length(obj1.gap) == 0)
      {
        str1 = new StringBuilder().append('[').append(NativeJSON.join((Collection) linkedList, ",")).append(']').toString();
      }
      else
      {
        string str2 = new StringBuilder().append(",\n").append(obj1.indent).toString();
        string str3 = NativeJSON.join((Collection) linkedList, str2);
        str1 = new StringBuilder().append("[\n").append(obj1.indent).append(str3).append('\n').append(indent).append(']').toString();
      }
      obj1.stack.pop();
      obj1.indent = indent;
      return str1;
    }

    [LineNumberTable(new byte[] {160, 232, 111, 144, 141, 103, 159, 7, 104, 142, 167, 134, 120, 107, 113, 127, 8, 110, 157, 122, 233, 56, 235, 78, 104, 140, 109, 159, 13, 127, 2, 106, 255, 29, 69, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string jo([In] Scriptable obj0, [In] NativeJSON.StringifyState obj1)
    {
      if (obj1.stack.search((object) obj0) != -1)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.cyclic.value"));
      obj1.stack.push((object) obj0);
      string indent = obj1.indent;
      obj1.indent = new StringBuilder().append(obj1.indent).append(obj1.gap).toString();
      object[] objArray1 = obj1.propertyList == null ? obj0.getIds() : obj1.propertyList.toArray();
      LinkedList linkedList = new LinkedList();
      object[] objArray2 = objArray1;
      int length = objArray2.Length;
      for (int index = 0; index < length; ++index)
      {
        object obj = objArray2[index];
        object objA = NativeJSON.str(obj, obj0, obj1);
        if (!object.ReferenceEquals(objA, Undefined.__\u003C\u003Einstance))
        {
          string str1 = new StringBuilder().append(NativeJSON.quote(Object.instancehelper_toString(obj))).append(":").toString();
          if (String.instancehelper_length(obj1.gap) > 0)
            str1 = new StringBuilder().append(str1).append(" ").toString();
          string str2 = new StringBuilder().append(str1).append(objA).toString();
          ((List) linkedList).add((object) str2);
        }
      }
      string str3;
      if (((List) linkedList).isEmpty())
        str3 = "{}";
      else if (String.instancehelper_length(obj1.gap) == 0)
      {
        str3 = new StringBuilder().append('{').append(NativeJSON.join((Collection) linkedList, ",")).append('}').toString();
      }
      else
      {
        string str1 = new StringBuilder().append(",\n").append(obj1.indent).toString();
        string str2 = NativeJSON.join((Collection) linkedList, str1);
        str3 = new StringBuilder().append("{\n").append(obj1.indent).append(str2).append('\n').append(indent).append('}').toString();
      }
      obj1.stack.pop();
      obj1.indent = indent;
      return str3;
    }

    [Signature("(Ljava/util/Collection<Ljava/lang/Object;>;Ljava/lang/String;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {160, 219, 107, 134, 103, 110, 113, 104, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string join([In] Collection obj0, [In] string obj1)
    {
      if (obj0 == null || obj0.isEmpty())
        return "";
      Iterator iterator = obj0.iterator();
      if (!iterator.hasNext())
        return "";
      StringBuilder stringBuilder = new StringBuilder(Object.instancehelper_toString(iterator.next()));
      while (iterator.hasNext())
        stringBuilder.append(obj1).append(Object.instancehelper_toString(iterator.next()));
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {159, 136, 66, 102, 103, 108, 103, 99, 134, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      NativeJSON nativeJson = new NativeJSON();
      nativeJson.activatePrototypeMap(3);
      nativeJson.setPrototype(ScriptableObject.getObjectPrototype(obj0));
      nativeJson.setParentScope(obj0);
      if (num != 0)
        nativeJson.sealObject();
      ScriptableObject.defineProperty(obj0, "JSON", (object) nativeJson, 2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "JSON";

    [LineNumberTable(new byte[] {159, 187, 167, 150, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111, 98, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      if (id <= 3)
      {
        int arity;
        string name;
        switch (id - 1)
        {
          case 0:
            arity = 0;
            name = "toSource";
            break;
          case 1:
            arity = 2;
            name = "parse";
            break;
          case 2:
            arity = 3;
            name = "stringify";
            break;
          default:
            string str = String.valueOf(id);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
        }
        this.initPrototypeMethod(NativeJSON.JSON_TAG, id, name, arity);
      }
      else
      {
        string str = String.valueOf(id);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException(str);
      }
    }

    [LineNumberTable(new byte[] {23, 109, 142, 103, 153, 166, 105, 98, 102, 133, 104, 143, 201, 103, 154, 166, 165, 229, 70, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeJSON.JSON_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      switch (num)
      {
        case 1:
          return (object) "JSON";
        case 2:
          string jtext = ScriptRuntime.toString(args, 0);
          object obj1 = (object) null;
          if (args.Length > 1)
            obj1 = args[1];
          return obj1 is Callable ? NativeJSON.parse(cx, scope, jtext, (Callable) obj1) : NativeJSON.parse(cx, scope, jtext);
        case 3:
          object obj2 = (object) null;
          object replacer = (object) null;
          object space = (object) null;
          switch (args.Length)
          {
            case 1:
              obj2 = args[0];
              break;
            case 2:
              replacer = args[1];
              goto case 1;
            case 3:
              space = args[2];
              goto case 2;
          }
          return NativeJSON.stringify(cx, scope, obj2, replacer, space);
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
      }
    }

    [LineNumberTable(new byte[] {161, 118, 98, 130, 159, 4, 102, 98, 130, 102, 98, 130, 102, 162, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 5:
          str = "parse";
          num = 2;
          break;
        case 8:
          str = "toSource";
          num = 1;
          break;
        case 9:
          str = "stringify";
          num = 3;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeJSON()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeJSON"))
        return;
      NativeJSON.JSON_TAG = (object) "JSON";
    }

    [InnerClass]
    internal class StringifyState : Object
    {
      [Signature("Ljava/util/Stack<Lrhino/Scriptable;>;")]
      internal Stack stack;
      internal string indent;
      internal string gap;
      internal Callable replacer;
      [Signature("Ljava/util/List<Ljava/lang/Object;>;")]
      internal List propertyList;
      internal object space;
      internal Context cx;
      internal Scriptable scope;

      [Signature("(Lrhino/Context;Lrhino/Scriptable;Ljava/lang/String;Ljava/lang/String;Lrhino/Callable;Ljava/util/List<Ljava/lang/Object;>;Ljava/lang/Object;)V")]
      [LineNumberTable(new byte[] {160, 83, 232, 75, 235, 54, 103, 135, 103, 104, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal StringifyState(
        [In] Context obj0,
        [In] Scriptable obj1,
        [In] string obj2,
        [In] string obj3,
        [In] Callable obj4,
        [In] List obj5,
        [In] object obj6)
      {
        NativeJSON.StringifyState stringifyState = this;
        this.stack = new Stack();
        this.cx = obj0;
        this.scope = obj1;
        this.indent = obj2;
        this.gap = obj3;
        this.replacer = obj4;
        this.propertyList = obj5;
        this.space = obj6;
      }
    }
  }
}
