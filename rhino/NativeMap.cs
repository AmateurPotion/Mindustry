// Decompiled with JetBrains decompiler
// Type: rhino.NativeMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class NativeMap : IdScriptableObject
  {
    [Modifiers]
    private static object MAP_TAG;
    internal const string ITERATOR_TAG = "Map Iterator";
    [Modifiers]
    private static object NULL_VALUE;
    [Modifiers]
    private Hashtable entries;
    private bool instanceOfMap;
    private const int Id_constructor = 1;
    private const int Id_set = 2;
    private const int Id_get = 3;
    private const int Id_delete = 4;
    private const int Id_has = 5;
    private const int Id_clear = 6;
    private const int Id_keys = 7;
    private const int Id_values = 8;
    private const int Id_entries = 9;
    private const int Id_forEach = 10;
    private const int SymbolId_getSize = 11;
    private const int SymbolId_toStringTag = 12;
    private const int MAX_PROTOTYPE_ID = 12;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 145, 232, 70, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeMap()
    {
      NativeMap nativeMap = this;
      this.entries = new Hashtable();
      this.instanceOfMap = false;
    }

    [LineNumberTable(new byte[] {110, 112, 193, 105, 141, 225, 70, 115, 97, 114, 167, 108, 125, 105, 105, 151, 108, 110, 135, 108, 110, 135, 122, 113, 95, 30, 255, 39, 48, 238, 80, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void loadFromIterable(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] ScriptableObject obj2,
      [In] object obj3)
    {
      if (obj3 == null || Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, obj3))
        return;
      object target = ScriptRuntime.callIterator(obj3, obj0, obj1);
      if (Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, target))
        return;
      Callable propFunctionAndThis = ScriptRuntime.getPropFunctionAndThis((object) ScriptableObject.ensureScriptableObject((object) obj0.newObject(obj1, obj2.getClassName())).getPrototype(), "set", obj0, obj1);
      ScriptRuntime.lastStoredScriptable(obj0);
      IteratorLikeIterable iteratorLikeIterable = new IteratorLikeIterable(obj0, obj1, target);
      Exception exception1 = (Exception) null;
      Exception exception2;
      // ISSUE: fault handler
      try
      {
        IteratorLikeIterable.Itr itr = iteratorLikeIterable.iterator();
        while (((Iterator) itr).hasNext())
        {
          Scriptable s = ScriptableObject.ensureScriptable(((Iterator) itr).next());
          object objA = !(s is Symbol) ? s.get(0, s) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.arg.not.object", (object) ScriptRuntime.@typeof((object) s)));
          if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
            objA = Undefined.__\u003C\u003Einstance;
          object instance = s.get(1, s);
          if (object.ReferenceEquals(instance, Scriptable.NOT_FOUND))
            instance = Undefined.__\u003C\u003Einstance;
          propFunctionAndThis.call(obj0, obj1, (Scriptable) obj2, new object[2]
          {
            objA,
            instance
          });
        }
        goto label_23;
      }
      catch (Exception ex)
      {
        exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      __fault
      {
        if (iteratorLikeIterable != null)
        {
          if (exception1 != null)
          {
            Exception exception3;
            try
            {
              iteratorLikeIterable.close();
              goto label_21;
            }
            catch (Exception ex)
            {
              exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exception4 = exception3;
            Throwable.instancehelper_addSuppressed(exception1, exception4);
          }
          else
            iteratorLikeIterable.close();
        }
label_21:;
      }
      Exception exception5 = exception2;
      Exception exception6;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception5;
        exception6 = exception3;
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      __fault
      {
        if (iteratorLikeIterable != null)
        {
          if (exception6 != null)
          {
            Exception exception3;
            try
            {
              iteratorLikeIterable.close();
              goto label_37;
            }
            catch (Exception ex)
            {
              exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exception4 = exception3;
            Throwable.instancehelper_addSuppressed(exception6, exception4);
          }
          else
            iteratorLikeIterable.close();
        }
label_37:;
      }
label_23:
      if (iteratorLikeIterable == null)
        return;
      if (null != null)
      {
        Exception exception3;
        try
        {
          iteratorLikeIterable.close();
          return;
        }
        catch (Exception ex)
        {
          exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Throwable.instancehelper_addSuppressed((Exception) null, exception3);
      }
      else
        iteratorLikeIterable.close();
    }

    [LineNumberTable(new byte[] {160, 86, 99, 172, 103, 136, 140, 122, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeMap realThis([In] Scriptable obj0, [In] IdFunctionObject obj1)
    {
      if (obj0 == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
      NativeMap nativeMap1;
      try
      {
        NativeMap nativeMap2 = (NativeMap) obj0;
        nativeMap1 = nativeMap2.instanceOfMap ? nativeMap2 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<ClassCastException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_8;
      }
      return nativeMap1;
label_8:
      throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
    }

    [LineNumberTable(new byte[] {32, 140, 98, 110, 109, 139, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_set([In] object obj0, [In] object obj1)
    {
      object obj = obj1 != null ? obj1 : NativeMap.NULL_VALUE;
      object key = obj0;
      if (key is Number && ((Number) key).doubleValue() == ScriptRuntime.__\u003C\u003EnegativeZero)
        key = (object) Double.valueOf(0.0);
      this.entries.put(key, obj);
      return (object) this;
    }

    [LineNumberTable(new byte[] {44, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_delete([In] object obj0) => (object) Boolean.valueOf(this.entries.delete(obj0) != null);

    [LineNumberTable(new byte[] {49, 109, 99, 134, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_get([In] object obj0)
    {
      object objA = this.entries.get(obj0);
      if (objA == null)
        return Undefined.__\u003C\u003Einstance;
      return object.ReferenceEquals(objA, NativeMap.NULL_VALUE) ? (object) null : objA;
    }

    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_has([In] object obj0) => (object) Boolean.valueOf(this.entries.has(obj0));

    [LineNumberTable(new byte[] {72, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_clear()
    {
      this.entries.clear();
      return Undefined.__\u003C\u003Einstance;
    }

    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_iterator([In] Scriptable obj0, [In] NativeCollectionIterator.Type obj1)
    {
      NativeCollectionIterator.__\u003Cclinit\u003E();
      return (object) new NativeCollectionIterator(obj0, "Map Iterator", obj1, this.entries.iterator());
    }

    [LineNumberTable(new byte[] {77, 104, 151, 135, 103, 159, 4, 139, 103, 131, 100, 167, 99, 105, 110, 163, 127, 5, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_forEach([In] Context obj0, [In] Scriptable obj1, [In] object obj2, [In] object obj3)
    {
      Callable callable = obj2 is Callable ? (Callable) obj2 : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError2("msg.isnt.function", obj2, (object) ScriptRuntime.@typeof(obj2)));
      int num = obj0.isStrictMode() ? 1 : 0;
      Iterator iterator = this.entries.iterator();
      while (iterator.hasNext())
      {
        Hashtable.Entry entry1 = (Hashtable.Entry) iterator.next();
        Scriptable s2 = ScriptRuntime.toObjectOrNull(obj0, obj3, obj1);
        if (s2 == null && num == 0)
          s2 = obj1;
        if (s2 == null)
          s2 = Undefined.__\u003C\u003ESCRIPTABLE_UNDEFINED;
        Hashtable.Entry entry2 = entry1;
        object objA = entry2.value;
        if (object.ReferenceEquals(objA, NativeMap.NULL_VALUE))
          objA = (object) null;
        callable.call(obj0, obj1, s2, new object[3]
        {
          objA,
          entry2.key,
          (object) this
        });
      }
      return Undefined.__\u003C\u003Einstance;
    }

    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_getSize() => (object) Integer.valueOf(this.entries.size());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Map";

    [LineNumberTable(new byte[] {159, 139, 130, 102, 139, 109, 114, 114, 120, 141, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Context obj0, [In] Scriptable obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      NativeMap nativeMap = new NativeMap();
      nativeMap.exportAsJSClass(12, obj1, false);
      ScriptableObject desc = (ScriptableObject) obj0.newObject(obj1);
      desc.put("enumerable", (Scriptable) desc, (object) Boolean.valueOf(false));
      desc.put("configurable", (Scriptable) desc, (object) Boolean.valueOf(true));
      desc.put("get", (Scriptable) desc, nativeMap.get((Symbol) NativeSet.GETSIZE, (Scriptable) nativeMap));
      nativeMap.defineOwnProperty(obj0, (object) "size", desc);
      if (num == 0)
        return;
      nativeMap.sealObject();
    }

    [LineNumberTable(new byte[] {159, 178, 109, 142, 103, 159, 26, 100, 102, 103, 102, 140, 130, 149, 223, 18, 159, 1, 159, 1, 159, 1, 143, 149, 149, 149, 223, 20, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeMap.MAP_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      switch (f.methodId())
      {
        case 1:
          if (thisObj != null)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.no.new", (object) "Map"));
          NativeMap nativeMap = new NativeMap();
          nativeMap.instanceOfMap = true;
          if (args.Length > 0)
            NativeMap.loadFromIterable(cx, scope, (ScriptableObject) nativeMap, args[0]);
          return (object) nativeMap;
        case 2:
          return this.realThis(thisObj, f).js_set(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0], args.Length <= 1 ? Undefined.__\u003C\u003Einstance : args[1]);
        case 3:
          return this.realThis(thisObj, f).js_get(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 4:
          return this.realThis(thisObj, f).js_delete(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 5:
          return this.realThis(thisObj, f).js_has(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 6:
          return this.realThis(thisObj, f).js_clear();
        case 7:
          return this.realThis(thisObj, f).js_iterator(scope, NativeCollectionIterator.Type.KEYS);
        case 8:
          return this.realThis(thisObj, f).js_iterator(scope, NativeCollectionIterator.Type.VALUES);
        case 9:
          return this.realThis(thisObj, f).js_iterator(scope, NativeCollectionIterator.Type.BOTH);
        case 10:
          return this.realThis(thisObj, f).js_forEach(cx, scope, args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0], args.Length <= 1 ? Undefined.__\u003C\u003Einstance : args[1]);
        case 11:
          return this.realThis(thisObj, f).js_getSize();
        default:
          string str = new StringBuilder().append("Map.prototype has no method: ").append(f.getFunctionName()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 103, 148, 120, 129, 105, 38, 133, 193, 130, 159, 22, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      switch (id)
      {
        case 11:
          this.initPrototypeMethod(NativeMap.MAP_TAG, id, (Symbol) NativeSet.GETSIZE, "get size", 0);
          break;
        case 12:
          this.initPrototypeValue(12, (Symbol) SymbolKey.__\u003C\u003ETO_STRING_TAG, (object) this.getClassName(), 3);
          break;
        default:
          int arity;
          string propertyName;
          switch (id)
          {
            case 1:
              arity = 0;
              propertyName = "constructor";
              break;
            case 2:
              arity = 2;
              propertyName = "set";
              break;
            case 3:
              arity = 1;
              propertyName = "get";
              break;
            case 4:
              arity = 1;
              propertyName = "delete";
              break;
            case 5:
              arity = 1;
              propertyName = "has";
              break;
            case 6:
              arity = 0;
              propertyName = "clear";
              break;
            case 7:
              arity = 0;
              propertyName = "keys";
              break;
            case 8:
              arity = 0;
              propertyName = "values";
              break;
            case 9:
              arity = 0;
              propertyName = "entries";
              break;
            case 10:
              arity = 1;
              propertyName = "forEach";
              break;
            default:
              string str = String.valueOf(id);
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalArgumentException(str);
          }
          this.initPrototypeMethod(NativeMap.MAP_TAG, id, propertyName, (string) null, arity);
          break;
      }
    }

    [LineNumberTable(new byte[] {160, 165, 109, 131, 205, 131, 109, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(Symbol k)
    {
      if (NativeSet.GETSIZE.equals((object) k))
        return 11;
      if (SymbolKey.__\u003C\u003EITERATOR.equals((object) k))
        return 9;
      return SymbolKey.__\u003C\u003ETO_STRING_TAG.equals((object) k) ? 12 : 0;
    }

    [LineNumberTable(new byte[] {160, 188, 98, 162, 159, 23, 104, 101, 124, 98, 133, 101, 124, 98, 133, 104, 124, 98, 229, 69, 102, 98, 133, 102, 98, 133, 104, 101, 102, 100, 101, 102, 196, 104, 101, 102, 101, 101, 102, 197, 102, 162, 183})]
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
              goto label_17;
            case 'h':
              if (String.instancehelper_charAt(s, 2) == 's' && String.instancehelper_charAt(s, 1) == 'a')
              {
                num = 5;
                break;
              }
              goto label_17;
            case 's':
              if (String.instancehelper_charAt(s, 2) == 't' && String.instancehelper_charAt(s, 1) == 'e')
              {
                num = 2;
                break;
              }
              goto label_17;
            default:
              goto label_17;
          }
          break;
        case 4:
          str = "keys";
          num = 7;
          goto default;
        case 5:
          str = "clear";
          num = 6;
          goto default;
        case 6:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'd':
              str = "delete";
              num = 4;
              goto label_17;
            case 'v':
              str = "values";
              num = 8;
              goto label_17;
            default:
              goto label_17;
          }
        case 7:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'e':
              str = "entries";
              num = 9;
              goto label_17;
            case 'f':
              str = "forEach";
              num = 10;
              goto label_17;
            default:
              goto label_17;
          }
        case 11:
          str = "constructor";
          num = 1;
          goto default;
        default:
label_17:
          if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
          {
            num = 0;
            break;
          }
          break;
      }
      return num;
    }

    [LineNumberTable(new byte[] {159, 141, 82, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeMap()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeMap"))
        return;
      NativeMap.MAP_TAG = (object) "Map";
      NativeMap.NULL_VALUE = (object) new Object();
    }
  }
}
