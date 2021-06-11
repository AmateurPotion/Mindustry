// Decompiled with JetBrains decompiler
// Type: rhino.NativeCallSite
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class NativeCallSite : IdScriptableObject
  {
    private const string CALLSITE_TAG = "CallSite";
    private ScriptStackElement element;
    private const int Id_constructor = 1;
    private const int Id_getThis = 2;
    private const int Id_getTypeName = 3;
    private const int Id_getFunction = 4;
    private const int Id_getFunctionName = 5;
    private const int Id_getMethodName = 6;
    private const int Id_getFileName = 7;
    private const int Id_getLineNumber = 8;
    private const int Id_getColumnNumber = 9;
    private const int Id_getEvalOrigin = 10;
    private const int Id_isToplevel = 11;
    private const int Id_isEval = 12;
    private const int Id_isNative = 13;
    private const int Id_isConstructor = 14;
    private const int Id_toString = 15;
    private const int MAX_PROTOTYPE_ID = 15;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 168, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeCallSite()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 102, 119, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static NativeCallSite make([In] Scriptable obj0, [In] Scriptable obj1)
    {
      NativeCallSite nativeCallSite = new NativeCallSite();
      Scriptable m = (Scriptable) obj1.get("prototype", obj1);
      nativeCallSite.setParentScope(obj0);
      nativeCallSite.setPrototype(m);
      return nativeCallSite;
    }

    [LineNumberTable(new byte[] {117, 107, 138, 99, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object getFunctionName([In] Scriptable obj0)
    {
      while (true)
      {
        switch (obj0)
        {
          case null:
          case NativeCallSite _:
            goto label_2;
          default:
            obj0 = obj0.getPrototype();
            continue;
        }
      }
label_2:
      if (obj0 == null)
        return Scriptable.NOT_FOUND;
      NativeCallSite nativeCallSite = (NativeCallSite) obj0;
      return nativeCallSite.element == null ? (object) null : (object) nativeCallSite.element.__\u003C\u003EfunctionName;
    }

    [LineNumberTable(new byte[] {160, 64, 107, 138, 99, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object getFileName([In] Scriptable obj0)
    {
      while (true)
      {
        switch (obj0)
        {
          case null:
          case NativeCallSite _:
            goto label_2;
          default:
            obj0 = obj0.getPrototype();
            continue;
        }
      }
label_2:
      if (obj0 == null)
        return Scriptable.NOT_FOUND;
      NativeCallSite nativeCallSite = (NativeCallSite) obj0;
      return nativeCallSite.element == null ? (object) null : (object) nativeCallSite.element.__\u003C\u003EfileName;
    }

    [LineNumberTable(new byte[] {160, 75, 107, 138, 99, 134, 103, 118, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object getLineNumber([In] Scriptable obj0)
    {
      while (true)
      {
        switch (obj0)
        {
          case null:
          case NativeCallSite _:
            goto label_2;
          default:
            obj0 = obj0.getPrototype();
            continue;
        }
      }
label_2:
      if (obj0 == null)
        return Scriptable.NOT_FOUND;
      NativeCallSite nativeCallSite = (NativeCallSite) obj0;
      return nativeCallSite.element == null || nativeCallSite.element.__\u003C\u003ElineNumber < 0 ? Undefined.__\u003C\u003Einstance : (object) Integer.valueOf(nativeCallSite.element.__\u003C\u003ElineNumber);
    }

    [LineNumberTable(new byte[] {104, 107, 138, 99, 134, 103, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object js_toString([In] Scriptable obj0)
    {
      while (true)
      {
        switch (obj0)
        {
          case null:
          case NativeCallSite _:
            goto label_2;
          default:
            obj0 = obj0.getPrototype();
            continue;
        }
      }
label_2:
      if (obj0 == null)
        return Scriptable.NOT_FOUND;
      NativeCallSite nativeCallSite = (NativeCallSite) obj0;
      StringBuilder sb = new StringBuilder();
      nativeCallSite.element.renderJavaStyle(sb);
      return (object) sb.toString();
    }

    [LineNumberTable(new byte[] {159, 139, 130, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeCallSite().exportAsJSClass(15, obj0, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setElement([In] ScriptStackElement obj0) => this.element = obj0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "CallSite";

    [LineNumberTable(new byte[] {159, 184, 159, 42, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 0;
          name = "constructor";
          break;
        case 2:
          arity = 0;
          name = "getThis";
          break;
        case 3:
          arity = 0;
          name = "getTypeName";
          break;
        case 4:
          arity = 0;
          name = "getFunction";
          break;
        case 5:
          arity = 0;
          name = "getFunctionName";
          break;
        case 6:
          arity = 0;
          name = "getMethodName";
          break;
        case 7:
          arity = 0;
          name = "getFileName";
          break;
        case 8:
          arity = 0;
          name = "getLineNumber";
          break;
        case 9:
          arity = 0;
          name = "getColumnNumber";
          break;
        case 10:
          arity = 0;
          name = "getEvalOrigin";
          break;
        case 11:
          arity = 0;
          name = "isToplevel";
          break;
        case 12:
          arity = 0;
          name = "isEval";
          break;
        case 13:
          arity = 0;
          name = "isNative";
          break;
        case 14:
          arity = 0;
          name = "isConstructor";
          break;
        case 15:
          arity = 0;
          name = "toString";
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod((object) "CallSite", id, name, arity);
    }

    [LineNumberTable(new byte[] {62, 109, 142, 103, 159, 39, 136, 136, 136, 232, 69, 134, 226, 70, 134, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag((object) "CallSite"))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      switch (num)
      {
        case 1:
          return (object) NativeCallSite.make(scope, (Scriptable) f);
        case 2:
        case 3:
        case 4:
        case 9:
          return Undefined.__\u003C\u003Einstance;
        case 5:
          return NativeCallSite.getFunctionName(thisObj);
        case 6:
          return (object) null;
        case 7:
          return NativeCallSite.getFileName(thisObj);
        case 8:
          return NativeCallSite.getLineNumber(thisObj);
        case 10:
        case 11:
        case 12:
        case 13:
        case 14:
          return (object) Boolean.FALSE;
        case 15:
          return NativeCallSite.js_toString(thisObj);
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {97, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.element == null ? "" : this.element.toString();

    [LineNumberTable(new byte[] {160, 96, 98, 162, 159, 27, 102, 99, 133, 102, 98, 133, 104, 101, 102, 104, 104, 102, 200, 102, 99, 133, 159, 11, 102, 98, 133, 102, 98, 133, 102, 98, 133, 102, 98, 133, 133, 159, 11, 102, 99, 133, 102, 98, 130, 102, 98, 130, 102, 99, 130, 130, 104, 101, 102, 101, 101, 102, 194, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 6:
          str = "isEval";
          num = 12;
          break;
        case 7:
          str = "getThis";
          num = 2;
          break;
        case 8:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'i':
              str = "isNative";
              num = 13;
              break;
            case 't':
              str = "toString";
              num = 15;
              break;
          }
          break;
        case 10:
          str = "isToplevel";
          num = 11;
          break;
        case 11:
          switch (String.instancehelper_charAt(s, 4))
          {
            case 'i':
              str = "getFileName";
              num = 7;
              break;
            case 't':
              str = "constructor";
              num = 1;
              break;
            case 'u':
              str = "getFunction";
              num = 4;
              break;
            case 'y':
              str = "getTypeName";
              num = 3;
              break;
          }
          break;
        case 13:
          switch (String.instancehelper_charAt(s, 3))
          {
            case 'E':
              str = "getEvalOrigin";
              num = 10;
              break;
            case 'L':
              str = "getLineNumber";
              num = 8;
              break;
            case 'M':
              str = "getMethodName";
              num = 6;
              break;
            case 'o':
              str = "isConstructor";
              num = 14;
              break;
          }
          break;
        case 15:
          switch (String.instancehelper_charAt(s, 3))
          {
            case 'C':
              str = "getColumnNumber";
              num = 9;
              break;
            case 'F':
              str = "getFunctionName";
              num = 5;
              break;
          }
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [HideFromJava]
    static NativeCallSite() => IdScriptableObject.__\u003Cclinit\u003E();
  }
}
