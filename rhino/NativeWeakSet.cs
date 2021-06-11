// Decompiled with JetBrains decompiler
// Type: rhino.NativeWeakSet
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
  public class NativeWeakSet : IdScriptableObject
  {
    [Modifiers]
    private static object MAP_TAG;
    private bool instanceOfWeakSet;
    [Signature("Ljava/util/WeakHashMap<Lrhino/Scriptable;Ljava/lang/Boolean;>;")]
    [NonSerialized]
    private WeakHashMap map;
    private const int Id_constructor = 1;
    private const int Id_add = 2;
    private const int Id_delete = 3;
    private const int Id_has = 4;
    private const int SymbolId_toStringTag = 5;
    private const int MAX_PROTOTYPE_ID = 5;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 168, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeWeakSet()
    {
      NativeWeakSet nativeWeakSet = this;
      this.instanceOfWeakSet = false;
      this.map = new WeakHashMap();
    }

    [LineNumberTable(new byte[] {39, 99, 172, 103, 136, 140, 122, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeWeakSet realThis([In] Scriptable obj0, [In] IdFunctionObject obj1)
    {
      if (obj0 == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
      NativeWeakSet nativeWeakSet1;
      try
      {
        NativeWeakSet nativeWeakSet2 = (NativeWeakSet) obj0;
        nativeWeakSet1 = nativeWeakSet2.instanceOfWeakSet ? nativeWeakSet2 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<ClassCastException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_8;
      }
      return nativeWeakSet1;
label_8:
      throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
    }

    [LineNumberTable(new byte[] {14, 104, 214, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_add([In] object obj0)
    {
      if (!ScriptRuntime.isObject(obj0))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.arg.not.object", (object) ScriptRuntime.@typeof(obj0)));
      this.map.put((object) (Scriptable) obj0, (object) Boolean.TRUE);
      return (object) this;
    }

    [LineNumberTable(new byte[] {24, 104, 135, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_delete([In] object obj0) => !ScriptRuntime.isObject(obj0) ? (object) Boolean.valueOf(false) : (object) Boolean.valueOf(this.map.remove(obj0) != null);

    [LineNumberTable(new byte[] {32, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_has([In] object obj0) => !ScriptRuntime.isObject(obj0) ? (object) Boolean.valueOf(false) : (object) Boolean.valueOf(this.map.containsKey(obj0));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "WeakSet";

    [LineNumberTable(new byte[] {159, 137, 98, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeWeakSet().exportAsJSClass(5, obj0, num != 0);
    }

    [LineNumberTable(new byte[] {159, 176, 109, 142, 103, 157, 100, 102, 103, 102, 140, 130, 149, 159, 1, 159, 1, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeWeakSet.MAP_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      switch (f.methodId())
      {
        case 1:
          if (thisObj != null)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.no.new", (object) "WeakSet"));
          NativeWeakSet nativeWeakSet = new NativeWeakSet();
          nativeWeakSet.instanceOfWeakSet = true;
          if (args.Length > 0)
            NativeSet.loadFromIterable(cx, scope, (ScriptableObject) nativeWeakSet, args[0]);
          return (object) nativeWeakSet;
        case 2:
          return this.realThis(thisObj, f).js_add(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 3:
          return this.realThis(thisObj, f).js_delete(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 4:
          return this.realThis(thisObj, f).js_has(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        default:
          string str = new StringBuilder().append("WeakMap.prototype has no method: ").append(f.getFunctionName()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {56, 100, 104, 38, 133, 161, 130, 154, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      if (id == 5)
      {
        this.initPrototypeValue(5, (Symbol) SymbolKey.__\u003C\u003ETO_STRING_TAG, (object) this.getClassName(), 3);
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
            propertyName = "add";
            break;
          case 2:
            arity = 1;
            propertyName = "delete";
            break;
          case 3:
            arity = 1;
            propertyName = "has";
            break;
          default:
            string str = String.valueOf(id);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
        }
        this.initPrototypeMethod(NativeWeakSet.MAP_TAG, id, propertyName, (string) null, arity);
      }
    }

    [LineNumberTable(new byte[] {89, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(Symbol k) => SymbolKey.__\u003C\u003ETO_STRING_TAG.equals((object) k) ? 5 : 0;

    [LineNumberTable(new byte[] {103, 98, 130, 103, 100, 104, 101, 121, 98, 133, 101, 118, 98, 162, 100, 102, 100, 101, 102, 130, 183})]
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
            case 'a':
              if (String.instancehelper_charAt(s, 2) == 'd' && String.instancehelper_charAt(s, 1) == 'd')
              {
                num = 2;
                break;
              }
              goto label_8;
            case 'h':
              if (String.instancehelper_charAt(s, 2) == 's' && String.instancehelper_charAt(s, 1) == 'a')
              {
                num = 4;
                break;
              }
              goto label_8;
            default:
              goto label_8;
          }
          break;
        case 6:
          str = "delete";
          num = 3;
          goto default;
        case 11:
          str = "constructor";
          num = 1;
          goto default;
        default:
label_8:
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
    [LineNumberTable(new byte[] {160, 81, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      this.map = new WeakHashMap();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeWeakSet()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeWeakSet"))
        return;
      NativeWeakSet.MAP_TAG = (object) "WeakSet";
    }
  }
}
