// Decompiled with JetBrains decompiler
// Type: rhino.NativeSet
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
  public class NativeSet : IdScriptableObject
  {
    [Modifiers]
    private static object SET_TAG;
    internal const string ITERATOR_TAG = "Set Iterator";
    [Modifiers]
    internal static SymbolKey GETSIZE;
    [Modifiers]
    private Hashtable entries;
    private bool instanceOfSet;
    private const int Id_constructor = 1;
    private const int Id_add = 2;
    private const int Id_delete = 3;
    private const int Id_has = 4;
    private const int Id_clear = 5;
    private const int Id_keys = 6;
    private const int Id_values = 6;
    private const int Id_entries = 7;
    private const int Id_forEach = 8;
    private const int SymbolId_getSize = 9;
    private const int SymbolId_toStringTag = 10;
    private const int MAX_PROTOTYPE_ID = 10;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 145, 232, 70, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeSet()
    {
      NativeSet nativeSet = this;
      this.entries = new Hashtable();
      this.instanceOfSet = false;
    }

    [LineNumberTable(new byte[] {86, 112, 193, 105, 141, 225, 70, 115, 97, 146, 167, 108, 122, 121, 117, 110, 95, 30, 255, 39, 59, 238, 69, 127, 24})]
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
      Callable propFunctionAndThis = ScriptRuntime.getPropFunctionAndThis((object) ScriptableObject.ensureScriptableObject((object) obj0.newObject(obj1, obj2.getClassName())).getPrototype(), "add", obj0, obj1);
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
          object objA = ((Iterator) itr).next();
          object obj = !object.ReferenceEquals(objA, Scriptable.NOT_FOUND) ? objA : Undefined.__\u003C\u003Einstance;
          propFunctionAndThis.call(obj0, obj1, (Scriptable) obj2, new object[1]
          {
            obj
          });
        }
        goto label_17;
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
              goto label_15;
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
label_15:;
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
              goto label_31;
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
label_31:;
      }
label_17:
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

    [LineNumberTable(new byte[] {116, 99, 172, 103, 136, 140, 122, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeSet realThis([In] Scriptable obj0, [In] IdFunctionObject obj1)
    {
      if (obj0 == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
      NativeSet nativeSet1;
      try
      {
        NativeSet nativeSet2 = (NativeSet) obj0;
        nativeSet1 = nativeSet2.instanceOfSet ? nativeSet2 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<ClassCastException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_8;
      }
      return nativeSet1;
label_8:
      throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
    }

    [LineNumberTable(new byte[] {26, 98, 110, 109, 139, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_add([In] object obj0)
    {
      object key = obj0;
      if (key is Number && ((Number) key).doubleValue() == ScriptRuntime.__\u003C\u003EnegativeZero)
        key = (object) Double.valueOf(0.0);
      this.entries.put(key, key);
      return (object) this;
    }

    [LineNumberTable(new byte[] {36, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_delete([In] object obj0) => (object) Boolean.valueOf(this.entries.delete(obj0) != null);

    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_has([In] object obj0) => (object) Boolean.valueOf(this.entries.has(obj0));

    [LineNumberTable(new byte[] {45, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_clear()
    {
      this.entries.clear();
      return Undefined.__\u003C\u003Einstance;
    }

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_iterator([In] Scriptable obj0, [In] NativeCollectionIterator.Type obj1)
    {
      NativeCollectionIterator.__\u003Cclinit\u003E();
      return (object) new NativeCollectionIterator(obj0, "Set Iterator", obj1, this.entries.iterator());
    }

    [LineNumberTable(new byte[] {58, 104, 140, 135, 103, 159, 4, 139, 103, 131, 100, 167, 99, 127, 10, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_forEach([In] Context obj0, [In] Scriptable obj1, [In] object obj2, [In] object obj3)
    {
      Callable callable = obj2 is Callable ? (Callable) obj2 : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(obj2));
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
        callable.call(obj0, obj1, s2, new object[3]
        {
          entry2.value,
          entry2.value,
          (object) this
        });
      }
      return Undefined.__\u003C\u003Einstance;
    }

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_getSize() => (object) Integer.valueOf(this.entries.size());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Set";

    [LineNumberTable(new byte[] {159, 139, 130, 102, 139, 109, 114, 114, 120, 141, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Context obj0, [In] Scriptable obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      NativeSet nativeSet = new NativeSet();
      nativeSet.exportAsJSClass(10, obj1, false);
      ScriptableObject desc = (ScriptableObject) obj0.newObject(obj1);
      desc.put("enumerable", (Scriptable) desc, (object) Boolean.valueOf(false));
      desc.put("configurable", (Scriptable) desc, (object) Boolean.valueOf(true));
      desc.put("get", (Scriptable) desc, nativeSet.get((Symbol) NativeSet.GETSIZE, (Scriptable) nativeSet));
      nativeSet.defineOwnProperty(obj0, (object) "size", desc);
      if (num == 0)
        return;
      nativeSet.sealObject();
    }

    [LineNumberTable(new byte[] {159, 178, 109, 142, 103, 159, 18, 100, 102, 103, 102, 140, 130, 181, 159, 1, 159, 1, 159, 1, 143, 149, 149, 223, 20, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeSet.SET_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      switch (f.methodId())
      {
        case 1:
          if (thisObj != null)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.no.new", (object) "Set"));
          NativeSet nativeSet = new NativeSet();
          nativeSet.instanceOfSet = true;
          if (args.Length > 0)
            NativeSet.loadFromIterable(cx, scope, (ScriptableObject) nativeSet, args[0]);
          return (object) nativeSet;
        case 2:
          return this.realThis(thisObj, f).js_add(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 3:
          return this.realThis(thisObj, f).js_delete(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 4:
          return this.realThis(thisObj, f).js_has(args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0]);
        case 5:
          return this.realThis(thisObj, f).js_clear();
        case 6:
          return this.realThis(thisObj, f).js_iterator(scope, NativeCollectionIterator.Type.VALUES);
        case 7:
          return this.realThis(thisObj, f).js_iterator(scope, NativeCollectionIterator.Type.BOTH);
        case 8:
          return this.realThis(thisObj, f).js_forEach(cx, scope, args.Length <= 0 ? Undefined.__\u003C\u003Einstance : args[0], args.Length <= 1 ? Undefined.__\u003C\u003Einstance : args[1]);
        case 9:
          return this.realThis(thisObj, f).js_getSize();
        default:
          string str = new StringBuilder().append("Set.prototype has no method: ").append(f.getFunctionName()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 69, 148, 120, 129, 105, 38, 133, 193, 130, 159, 14, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      switch (id)
      {
        case 9:
          this.initPrototypeMethod(NativeSet.SET_TAG, id, (Symbol) NativeSet.GETSIZE, "get size", 0);
          break;
        case 10:
          this.initPrototypeValue(10, (Symbol) SymbolKey.__\u003C\u003ETO_STRING_TAG, (object) this.getClassName(), 3);
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
              arity = 1;
              propertyName = "add";
              break;
            case 3:
              arity = 1;
              propertyName = "delete";
              break;
            case 4:
              arity = 1;
              propertyName = "has";
              break;
            case 5:
              arity = 0;
              propertyName = "clear";
              break;
            case 6:
              arity = 0;
              propertyName = "values";
              break;
            case 7:
              arity = 0;
              propertyName = "entries";
              break;
            case 8:
              arity = 1;
              propertyName = "forEach";
              break;
            default:
              string str = String.valueOf(id);
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalArgumentException(str);
          }
          this.initPrototypeMethod(NativeSet.SET_TAG, id, propertyName, (string) null, arity);
          break;
      }
    }

    [LineNumberTable(new byte[] {160, 123, 109, 131, 109, 130, 109, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(Symbol k)
    {
      if (NativeSet.GETSIZE.equals((object) k))
        return 9;
      if (SymbolKey.__\u003C\u003EITERATOR.equals((object) k))
        return 6;
      return SymbolKey.__\u003C\u003ETO_STRING_TAG.equals((object) k) ? 10 : 0;
    }

    [LineNumberTable(new byte[] {160, 143, 98, 162, 159, 23, 104, 101, 124, 98, 133, 104, 124, 98, 229, 69, 102, 98, 133, 102, 98, 133, 104, 101, 102, 100, 101, 102, 196, 104, 101, 102, 100, 101, 102, 196, 102, 162, 183})]
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
              goto label_15;
            case 'h':
              if (String.instancehelper_charAt(s, 2) == 's' && String.instancehelper_charAt(s, 1) == 'a')
              {
                num = 4;
                break;
              }
              goto label_15;
            default:
              goto label_15;
          }
          break;
        case 4:
          str = "keys";
          num = 6;
          goto default;
        case 5:
          str = "clear";
          num = 5;
          goto default;
        case 6:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'd':
              str = "delete";
              num = 3;
              goto label_15;
            case 'v':
              str = "values";
              num = 6;
              goto label_15;
            default:
              goto label_15;
          }
        case 7:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'e':
              str = "entries";
              num = 7;
              goto label_15;
            case 'f':
              str = "forEach";
              num = 8;
              goto label_15;
            default:
              goto label_15;
          }
        case 11:
          str = "constructor";
          num = 1;
          goto default;
        default:
label_15:
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
    static NativeSet()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeSet"))
        return;
      NativeSet.SET_TAG = (object) "Set";
      NativeSet.GETSIZE = new SymbolKey("[Symbol.getSize]");
    }
  }
}
