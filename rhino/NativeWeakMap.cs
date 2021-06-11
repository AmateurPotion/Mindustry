// Decompiled with JetBrains decompiler
// Type: rhino.NativeWeakMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class NativeWeakMap : IdScriptableObject
  {
    [Modifiers]
    private static object MAP_TAG;
    private bool instanceOfWeakMap;
    [Signature("Ljava/util/WeakHashMap<Lrhino/Scriptable;Ljava/lang/Object;>;")]
    [NonSerialized]
    private WeakHashMap map;
    [Modifiers]
    private static object NULL_VALUE;
    private const int Id_constructor = 1;
    private const int Id_delete = 2;
    private const int Id_get = 3;
    private const int Id_has = 4;
    private const int Id_set = 5;
    private const int SymbolId_toStringTag = 6;
    private const int MAX_PROTOTYPE_ID = 6;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 168, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeWeakMap()
    {
      NativeWeakMap nativeWeakMap = this;
      this.instanceOfWeakMap = false;
      this.map = new WeakHashMap();
    }

    [LineNumberTable(new byte[] {60, 99, 172, 103, 136, 140, 122, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeWeakMap realThis([In] Scriptable obj0, [In] IdFunctionObject obj1)
    {
      if (obj0 == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
      NativeWeakMap nativeWeakMap1;
      try
      {
        NativeWeakMap nativeWeakMap2 = (NativeWeakMap) obj0;
        nativeWeakMap1 = nativeWeakMap2.instanceOfWeakMap ? nativeWeakMap2 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<ClassCastException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_8;
      }
      return nativeWeakMap1;
label_8:
      throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
    }

    [LineNumberTable(new byte[] {17, 104, 135, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_delete([In] object obj0) => !ScriptRuntime.isObject(obj0) ? (object) Boolean.valueOf(false) : (object) Boolean.valueOf(this.map.remove(obj0) != null);

    [LineNumberTable(new byte[] {25, 104, 134, 109, 99, 102, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_get([In] object obj0)
    {
      if (!ScriptRuntime.isObject(obj0))
        return Undefined.__\u003C\u003Einstance;
      object objA = this.map.get(obj0);
      if (objA == null)
        return Undefined.__\u003C\u003Einstance;
      return object.ReferenceEquals(objA, NativeWeakMap.NULL_VALUE) ? (object) null : objA;
    }

    [LineNumberTable(new byte[] {38, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_has([In] object obj0) => !ScriptRuntime.isObject(obj0) ? (object) Boolean.valueOf(false) : (object) Boolean.valueOf(this.map.containsKey(obj0));

    [LineNumberTable(new byte[] {49, 104, 214, 108, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_set([In] object obj0, [In] object obj1)
    {
      if (!ScriptRuntime.isObject(obj0))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.arg.not.object", (object) ScriptRuntime.@typeof(obj0)));
      object obj = obj1 != null ? obj1 : NativeWeakMap.NULL_VALUE;
      this.map.put((object) (Scriptable) obj0, obj);
      return (object) this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "WeakMap";

    [LineNumberTable(new byte[] {159, 136, 66, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeWeakMap().exportAsJSClass(6, obj0, num != 0);
    }

    [LineNumberTable(new byte[] {159, 179, 109, 142, 103, 159, 2, 100, 102, 103, 102, 140, 130, 149, 159, 1, 159, 1, 159, 1, 223, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeWeakMap.MAP_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      switch (f.methodId())
      {
        case 1:
          if (thisObj != null)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.no.new", (object) "WeakMap"));
          NativeWeakMap nativeWeakMap = new NativeWeakMap();
          nativeWeakMap.instanceOfWeakMap = true;
          if (args.Length > 0)
            NativeMap.loadFromIterable(cx, scope, (ScriptableObject) nativeWeakMap, args[0]);
          return (object) nativeWeakMap;
        case 2:
          return this.realThis(thisObj, f).js_delete(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 3:
          return this.realThis(thisObj, f).js_get(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 4:
          return this.realThis(thisObj, f).js_has(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 5:
          return this.realThis(thisObj, f).js_set(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0], args.Length <= 1 ? Undefined.__\u003C\u003Einstance : args[1]);
        default:
          string str = new StringBuilder().append("WeakMap.prototype has no method: ").append(f.getFunctionName()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {77, 100, 104, 38, 133, 161, 130, 158, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      if (id == 6)
      {
        this.initPrototypeValue(6, (Symbol) SymbolKey.__\u003C\u003ETO_STRING_TAG, (object) this.getClassName(), 3);
      }
      else
      {
        int arity;
        string propertyName;
        switch (id - 1)
        {
          case 0:
            arity = 0;
            propertyName = "constructor";
            break;
          case 1:
            arity = 1;
            propertyName = "delete";
            break;
          case 2:
            arity = 1;
            propertyName = "get";
            break;
          case 3:
            arity = 1;
            propertyName = "has";
            break;
          case 4:
            arity = 2;
            propertyName = "set";
            break;
          default:
            string str = String.valueOf(id);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
        }
        this.initPrototypeMethod(NativeWeakMap.MAP_TAG, id, propertyName, (string) null, arity);
      }
    }

    [LineNumberTable(new byte[] {114, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(Symbol k) => SymbolKey.__\u003C\u003ETO_STRING_TAG.equals((object) k) ? 6 : 0;

    [LineNumberTable(new byte[] {160, 64, 98, 130, 103, 103, 104, 101, 124, 98, 133, 101, 121, 98, 133, 101, 118, 98, 162, 100, 102, 100, 101, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 3:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'g':
              if (String.instancehelper_charAt(s, 2) == 't' && String.instancehelper_charAt(s, 1) == 'e')
              {
                num = 3;
                break;
              }
              goto label_10;
            case 'h':
              if (String.instancehelper_charAt(s, 2) == 's' && String.instancehelper_charAt(s, 1) == 'a')
              {
                num = 4;
                break;
              }
              goto label_10;
            case 's':
              if (String.instancehelper_charAt(s, 2) == 't' && String.instancehelper_charAt(s, 1) == 'e')
              {
                num = 5;
                break;
              }
              goto label_10;
            default:
              goto label_10;
          }
          break;
        case 6:
          str = "delete";
          num = 2;
          goto default;
        case 11:
          str = "constructor";
          num = 1;
          goto default;
        default:
label_10:
          if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
          {
            num = 0;
            break;
          }
          break;
      }
      return num;
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {160, 112, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      this.map = new WeakHashMap();
    }

    [LineNumberTable(new byte[] {159, 139, 178, 234, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeWeakMap()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeWeakMap"))
        return;
      NativeWeakMap.MAP_TAG = (object) "WeakMap";
      NativeWeakMap.NULL_VALUE = (object) new Object();
    }
  }
}
