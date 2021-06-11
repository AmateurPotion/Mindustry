// Decompiled with JetBrains decompiler
// Type: rhino.NativeJavaClass
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Function"})]
  public class NativeJavaClass : NativeJavaObject, Function, Scriptable, Callable
  {
    internal const string javaClassPropertyName = "__javaObject__";
    [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/FieldAndMethods;>;")]
    private Map staticFieldAndMethods;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("()Ljava/lang/Class<*>;")]
    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class getClassObject() => (Class) this.unwrap();

    [Signature("(Lrhino/Scriptable;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {159, 171, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaClass(Scriptable scope, Class cl)
      : this(scope, cl, false)
    {
    }

    [Signature("(Lrhino/Scriptable;Ljava/lang/Class<*>;Z)V")]
    [LineNumberTable(new byte[] {159, 134, 98, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaClass(Scriptable scope, Class cl, bool isAdapter)
    {
      int num = isAdapter ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(scope, (object) cl, (Class) null, num != 0);
    }

    [LineNumberTable(new byte[] {160, 86, 135, 139, 104, 105, 46, 230, 72, 255, 9, 69, 215, 102, 103, 143, 109, 146, 234, 61, 232, 72, 135, 99, 101, 98, 103, 101, 108, 107, 105, 141, 229, 57, 230, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object constructInternal([In] object[] obj0, [In] MemberBox obj1)
    {
      Class[] argTypes = obj1.argTypes;
      if (obj1.vararg)
      {
        object[] objArray = new object[argTypes.Length];
        for (int index = 0; index < argTypes.Length - 1; ++index)
          objArray[index] = Context.jsToJava(obj0[index], argTypes[index]);
        object obj;
        if (obj0.Length == argTypes.Length && (obj0[obj0.Length - 1] == null || obj0[obj0.Length - 1] is NativeArray || obj0[obj0.Length - 1] is NativeJavaArray))
        {
          obj = Context.jsToJava(obj0[obj0.Length - 1], argTypes[argTypes.Length - 1]);
        }
        else
        {
          Class componentType = argTypes[argTypes.Length - 1].getComponentType();
          obj = Array.newInstance(componentType, obj0.Length - argTypes.Length + 1);
          for (int index = 0; index < Array.getLength(obj); ++index)
          {
            object java = Context.jsToJava(obj0[argTypes.Length - 1 + index], componentType);
            Array.set(obj, index, java);
          }
        }
        objArray[argTypes.Length - 1] = obj;
        obj0 = objArray;
      }
      else
      {
        object[] objArray = obj0;
        for (int index = 0; index < obj0.Length; ++index)
        {
          object objB = obj0[index];
          object java = Context.jsToJava(objB, argTypes[index]);
          if (!object.ReferenceEquals(java, objB))
          {
            if (object.ReferenceEquals((object) obj0, (object) objArray))
              obj0 = (object[]) objArray.Clone();
            obj0[index] = java;
          }
        }
      }
      return obj1.newInstance(obj0);
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/String;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {160, 168, 127, 4, 108, 227, 69, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Class findNestedClass([In] Class obj0, [In] string obj1)
    {
      string className = new StringBuilder().append(obj0.getName()).append('$').append(obj1).toString();
      ClassLoader classLoader = obj0.getClassLoader(NativeJavaClass.__\u003CGetCallerID\u003E());
      return classLoader == null ? Kit.classOrNull(className) : Kit.classOrNull(classLoader, className);
    }

    [LineNumberTable(256)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[JavaClass ").append(this.getClassObject().getName()).append("]").toString();

    [LineNumberTable(new byte[] {92, 103, 103, 105, 103, 108, 105, 100, 104, 102, 39, 235, 69, 145, 100, 144, 104, 199, 119, 103, 100, 37, 135, 215, 112, 110, 137, 114, 255, 20, 71, 226, 59, 130, 105, 100, 132, 104, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable construct(Context cx, Scriptable scope, object[] args)
    {
      Class classObject = this.getClassObject();
      int modifiers = classObject.getModifiers();
      if (!Modifier.isInterface(modifiers) && !Modifier.isAbstract(modifiers))
      {
        NativeJavaMethod ctors = this.__\u003C\u003Emembers.ctors;
        int cachedFunction = ctors.findCachedFunction(cx, args);
        if (cachedFunction < 0)
        {
          string str = NativeJavaMethod.scriptSignature(args);
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.no.java.ctor", (object) classObject.getName(), (object) str));
        }
        return NativeJavaClass.constructSpecific(cx, scope, args, ctors.methods[cachedFunction]);
      }
      if (args.Length == 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.adapter.zero.args"));
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope((Scriptable) this);
      string str1 = "";
      Scriptable scriptable;
      Exception exception;
      try
      {
        if (String.instancehelper_equals("Dalvik", (object) java.lang.System.getProperty("java.vm.name")) && classObject.isInterface())
        {
          object interfaceAdapter = NativeJavaObject.createInterfaceAdapter(classObject, ScriptableObject.ensureScriptableObject(args[0]));
          return cx.getWrapFactory().wrapAsJavaObject(cx, scope, interfaceAdapter, (Class) null);
        }
        object objA = topLevelScope.get("JavaAdapter", topLevelScope);
        if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        {
          Function function = (Function) objA;
          object[] objarr = new object[2]
          {
            (object) this,
            args[0]
          };
          scriptable = function.construct(cx, topLevelScope, objarr);
        }
        else
          goto label_17;
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
          exception = (Exception) m0;
          goto label_15;
        }
      }
      return scriptable;
label_15:
      string message = Throwable.instancehelper_getMessage((Exception) exception);
      if (message != null)
        str1 = message;
label_17:
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.cant.instantiate", (object) str1, (object) classObject.getName()));
    }

    [LineNumberTable(new byte[] {160, 78, 168, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Scriptable constructSpecific(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] object[] obj2,
      [In] MemberBox obj3)
    {
      object obj = NativeJavaClass.constructInternal(obj2, obj3);
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(obj1);
      return obj0.getWrapFactory().wrapNewObject(obj0, topLevelScope, obj);
    }

    [LineNumberTable(new byte[] {159, 167, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaClass()
    {
    }

    [LineNumberTable(new byte[] {159, 180, 108, 121, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initMembers()
    {
      Class javaObject = (Class) this.javaObject;
      this.__\u003C\u003Emembers = JavaMembers.lookupClass(this.parent, javaObject, javaObject, this.isAdapter);
      this.staticFieldAndMethods = this.__\u003C\u003Emembers.getFieldAndMethodsObjects((Scriptable) this, (object) javaObject, true);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "JavaClass";

    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(string name, Scriptable start) => this.__\u003C\u003Emembers.has(name, true) || String.instancehelper_equals("__javaObject__", (object) name);

    [LineNumberTable(new byte[] {9, 109, 130, 104, 109, 99, 162, 111, 181, 102, 103, 135, 109, 244, 70, 110, 100, 140, 104, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(string name, Scriptable start)
    {
      if (String.instancehelper_equals(name, (object) "prototype"))
        return (object) null;
      if (this.staticFieldAndMethods != null)
      {
        object obj = this.staticFieldAndMethods.get((object) name);
        if (obj != null)
          return obj;
      }
      if (this.__\u003C\u003Emembers.has(name, true))
        return this.__\u003C\u003Emembers.get((Scriptable) this, name, this.javaObject, true);
      Context context = Context.getContext();
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(start);
      WrapFactory wrapFactory = context.getWrapFactory();
      if (String.instancehelper_equals("__javaObject__", (object) name))
        return wrapFactory.wrap(context, topLevelScope, this.javaObject, ScriptRuntime.__\u003C\u003EClassClass);
      Scriptable scriptable = wrapFactory.wrapJavaClass(context, topLevelScope, NativeJavaClass.findNestedClass(this.getClassObject(), name) ?? throw Throwable.__\u003Cunmap\u003E((Exception) this.__\u003C\u003Emembers.reportMemberNotFound(name)));
      scriptable.setParentScope((Scriptable) this);
      return (object) scriptable;
    }

    [LineNumberTable(new byte[] {46, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(string name, Scriptable start, object value) => this.__\u003C\u003Emembers.put((Scriptable) this, name, this.javaObject, value, true);

    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object[] getIds() => this.__\u003C\u003Emembers.getIds(true);

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {60, 112, 103, 109, 102, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object getDefaultValue(Class hint)
    {
      if (hint == null || object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003EStringClass))
        return (object) this.toString();
      if (object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003EBooleanClass))
        return (object) Boolean.TRUE;
      return object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003ENumberClass) ? (object) ScriptRuntime.__\u003C\u003ENaNobj : (object) this;
    }

    [LineNumberTable(new byte[] {75, 113, 103, 138, 104, 108, 105, 130, 103, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args)
    {
      if (args.Length == 1 && args[0] is Scriptable)
      {
        Class classObject = this.getClassObject();
        Scriptable prototype = (Scriptable) args[0];
        do
        {
          if (prototype is Wrapper)
          {
            object obj = ((Wrapper) prototype).unwrap();
            if (classObject.isInstance(obj))
              return (object) prototype;
          }
          prototype = prototype.getPrototype();
        }
        while (prototype != null);
      }
      return (object) this.construct(cx, scope, args);
    }

    [LineNumberTable(new byte[] {160, 156, 144, 140, 205})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasInstance(Scriptable value)
    {
      if (!(value is Wrapper) || value is NativeJavaClass)
        return false;
      object obj = ((Wrapper) value).unwrap();
      return this.getClassObject().isInstance(obj);
    }

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (NativeJavaClass.__\u003CcallerID\u003E == null)
        NativeJavaClass.__\u003CcallerID\u003E = (CallerID) new NativeJavaClass.__\u003CCallerID\u003E();
      return NativeJavaClass.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    static NativeJavaClass() => NativeJavaObject.__\u003Cclinit\u003E();

    private new sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
