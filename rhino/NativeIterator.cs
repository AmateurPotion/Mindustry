// Decompiled with JetBrains decompiler
// Type: rhino.NativeIterator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public sealed class NativeIterator : IdScriptableObject
  {
    [Modifiers]
    private static object ITERATOR_TAG;
    private const string STOP_ITERATION = "StopIteration";
    public const string ITERATOR_PROPERTY_NAME = "__iterator__";
    private const int Id_constructor = 1;
    private const int Id_next = 2;
    private const int Id___iterator__ = 3;
    private const int MAX_PROTOTYPE_ID = 3;
    private object objectIterator;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {9, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getStopIterationObject(Scriptable scope) => ScriptableObject.getTopScopeValue(ScriptableObject.getTopLevelScope(scope), NativeIterator.ITERATOR_TAG);

    [LineNumberTable(new byte[] {159, 185, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeIterator()
    {
    }

    [LineNumberTable(new byte[] {106, 152, 111, 102, 37, 171, 107, 116, 227, 70, 103, 99, 104, 250, 70, 139, 100, 227, 70, 177, 104, 105, 101, 37, 138, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object jsConstructor(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3)
    {
      if (obj3.Length == 0 || obj3[0] == null || object.ReferenceEquals(obj3[0], Undefined.__\u003C\u003Einstance))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.no.properties", (object) ScriptRuntime.toString(obj3.Length != 0 ? obj3[0] : Undefined.__\u003C\u003Einstance)));
      Scriptable scriptable = ScriptRuntime.toObject(obj0, obj1, obj3[0]);
      int num = obj3.Length <= 1 || !ScriptRuntime.toBoolean(obj3[1]) ? 0 : 1;
      if (obj2 != null)
      {
        Iterator javaIterator = NativeIterator.getJavaIterator((object) scriptable);
        if (javaIterator != null)
        {
          obj1 = ScriptableObject.getTopLevelScope(obj1);
          return obj0.getWrapFactory().wrap(obj0, obj1, (object) new NativeIterator.WrappedJavaIterator(javaIterator, obj1), (Class) ClassLiteral<NativeIterator.WrappedJavaIterator>.Value);
        }
        Scriptable iterator = ScriptRuntime.toIterator(obj0, obj1, scriptable, num != 0);
        if (iterator != null)
          return (object) iterator;
      }
      object enumObj = ScriptRuntime.enumInit((object) scriptable, obj0, obj1, num == 0 ? 5 : 3);
      ScriptRuntime.setEnumNumbers(enumObj, true);
      NativeIterator nativeIterator = new NativeIterator(enumObj);
      nativeIterator.setPrototype(ScriptableObject.getClassPrototype(obj1, nativeIterator.getClassName()));
      nativeIterator.setParentScope(obj1);
      return (object) nativeIterator;
    }

    [LineNumberTable(new byte[] {160, 86, 108, 136, 102, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object next([In] Context obj0, [In] Scriptable obj1)
    {
      if (!ScriptRuntime.enumNext(this.objectIterator).booleanValue())
      {
        JavaScriptException.__\u003Cclinit\u003E();
        object stopIterationObject = NativeIterator.getStopIterationObject(obj1);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JavaScriptException(stopIterationObject, (string) null, 0);
      }
      return ScriptRuntime.enumId(this.objectIterator, obj0);
    }

    [Signature("(Ljava/lang/Object;)Ljava/util/Iterator<*>;")]
    [LineNumberTable(new byte[] {160, 101, 104, 108, 98, 104, 103, 104, 108, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Iterator getJavaIterator([In] object obj0)
    {
      if (!(obj0 is Wrapper))
        return (Iterator) null;
      object obj = ((Wrapper) obj0).unwrap();
      Iterator iterator = (Iterator) null;
      if (obj is Iterator)
        iterator = (Iterator) obj;
      if (obj is Iterable)
        iterator = ((Iterable) obj).iterator();
      return iterator;
    }

    [LineNumberTable(new byte[] {159, 188, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeIterator([In] object obj0)
    {
      NativeIterator nativeIterator = this;
      this.objectIterator = obj0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Iterator";

    [LineNumberTable(new byte[] {159, 139, 162, 102, 170, 109, 138, 200, 102, 108, 103, 99, 134, 237, 69, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Context obj0, [In] ScriptableObject obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      new NativeIterator().exportAsJSClass(3, (Scriptable) obj1, num != 0);
      if (obj0.getLanguageVersion() >= 200)
        ES6Generator.init(obj1, num != 0);
      else
        NativeGenerator.init(obj1, num != 0);
      NativeIterator.StopIteration stopIteration = new NativeIterator.StopIteration();
      stopIteration.setPrototype(ScriptableObject.getObjectPrototype((Scriptable) obj1));
      stopIteration.setParentScope((Scriptable) obj1);
      if (num != 0)
        stopIteration.sealObject();
      ScriptableObject.defineProperty((Scriptable) obj1, "StopIteration", (object) stopIteration, 2);
      obj1.associateValue(NativeIterator.ITERATOR_TAG, (object) stopIteration);
    }

    [LineNumberTable(new byte[] {53, 150, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 2;
          name = "constructor";
          break;
        case 2:
          arity = 0;
          name = "next";
          break;
        case 3:
          arity = 1;
          name = "__iterator__";
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(NativeIterator.ITERATOR_TAG, id, name, arity);
    }

    [LineNumberTable(new byte[] {75, 109, 142, 135, 100, 172, 105, 140, 136, 178, 201, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeIterator.ITERATOR_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      if (num == 1)
        return NativeIterator.jsConstructor(cx, scope, thisObj, args);
      NativeIterator nativeIterator = thisObj is NativeIterator ? (NativeIterator) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(f));
      switch (num)
      {
        case 2:
          return nativeIterator.next(cx, scope);
        case 3:
          return (object) thisObj;
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 144, 98, 98, 103, 100, 102, 100, 101, 102, 100, 101, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 4:
          str = "next";
          num = 2;
          break;
        case 11:
          str = "constructor";
          num = 1;
          break;
        case 12:
          str = "__iterator__";
          num = 3;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeIterator()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeIterator"))
        return;
      NativeIterator.ITERATOR_TAG = (object) "Iterator";
    }

    public class StopIteration : NativeObject
    {
      private object value;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object getValue() => this.value;

      [LineNumberTable(new byte[] {22, 232, 59, 235, 70, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StopIteration(object val)
      {
        NativeIterator.StopIteration stopIteration = this;
        this.value = Undefined.__\u003C\u003Einstance;
        this.value = val;
      }

      [LineNumberTable(new byte[] {19, 8, 171})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StopIteration()
      {
        NativeIterator.StopIteration stopIteration = this;
        this.value = Undefined.__\u003C\u003Einstance;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string getClassName() => nameof (StopIteration);

      [LineNumberTable(90)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool hasInstance(Scriptable instance) => instance is NativeIterator.StopIteration;

      [HideFromJava]
      static StopIteration() => NativeObject.__\u003Cclinit\u003E();
    }

    public class WrappedJavaIterator : Object
    {
      [Modifiers]
      [Signature("Ljava/util/Iterator<*>;")]
      private Iterator iterator;
      [Modifiers]
      private Scriptable scope;

      [Signature("(Ljava/util/Iterator<*>;Lrhino/Scriptable;)V")]
      [LineNumberTable(new byte[] {160, 114, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal WrappedJavaIterator([In] Iterator obj0, [In] Scriptable obj1)
      {
        NativeIterator.WrappedJavaIterator wrappedJavaIterator = this;
        this.iterator = obj0;
        this.scope = obj1;
      }

      [LineNumberTable(new byte[] {160, 120, 141, 107, 146})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next()
      {
        if (!this.iterator.hasNext())
        {
          JavaScriptException.__\u003Cclinit\u003E();
          object stopIterationObject = NativeIterator.getStopIterationObject(this.scope);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new JavaScriptException(stopIterationObject, (string) null, 0);
        }
        return this.iterator.next();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object __iterator__(bool b) => (object) this;
    }
  }
}
