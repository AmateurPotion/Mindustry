// Decompiled with JetBrains decompiler
// Type: rhino.ScriptableObject
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.lang.annotation;
using java.lang.reflect;
using java.util;
using java.util.function;
using rhino.annotations;
using rhino.debug;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino
{
  [Implements(new string[] {"rhino.Scriptable", "rhino.SymbolScriptable", "rhino.debug.DebuggableObject", "rhino.ConstProperties"})]
  public abstract class ScriptableObject : 
    Object,
    Scriptable,
    SymbolScriptable,
    DebuggableObject,
    ConstProperties
  {
    public const int EMPTY = 0;
    public const int READONLY = 1;
    public const int DONTENUM = 2;
    public const int PERMANENT = 4;
    public const int UNINITIALIZED_CONST = 8;
    public const int CONST = 13;
    private Scriptable prototypeObject;
    private Scriptable parentScopeObject;
    [NonSerialized]
    private SlotMapContainer slotMap;
    [NonSerialized]
    private ExternalArrayData externalData;
    [Signature("Ljava/util/Map<Ljava/lang/Object;Ljava/lang/Object;>;")]
    private volatile Map associatedValues;
    private bool isExtensible;
    private bool isSealed;
    [Modifiers]
    private static Method GET_ARRAY_LENGTH;
    [Modifiers]
    [Signature("Ljava/util/Comparator<Ljava/lang/Object;>;")]
    private static Comparator KEY_COMPARATOR;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {168, 17, 162, 105, 109, 98, 104, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getProperty(Scriptable obj, string name)
    {
      Scriptable s = obj;
      object objA;
      do
      {
        objA = obj.get(name, s);
        if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
          obj = obj.getPrototype();
        else
          break;
      }
      while (obj != null);
      return objA;
    }

    [Signature("<T:Ljava/lang/Object;>(Lrhino/Scriptable;ILjava/lang/Class<TT;>;)TT;")]
    [LineNumberTable(new byte[] {168, 63, 104, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getTypedProperty(Scriptable s, int index, Class type)
    {
      object objA = ScriptableObject.getProperty(s, index);
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        objA = (object) null;
      return type.cast(Context.jsToJava(objA, type));
    }

    [LineNumberTable(new byte[] {165, 123, 104, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void defineProperty(string propertyName, object value, int attributes)
    {
      this.checkNotSealed((object) propertyName, 0);
      this.put(propertyName, (Scriptable) this, value);
      this.setAttributes(propertyName, attributes);
    }

    [LineNumberTable(new byte[] {160, 207, 102, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private SlotMapContainer createSlotMap([In] int obj0)
    {
      Context currentContext = Context.getCurrentContext();
      return currentContext != null && currentContext.hasFeature(17) ? (SlotMapContainer) new ThreadSafeSlotMapContainer(obj0) : new SlotMapContainer(obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool avoidObjectDetection() => false;

    [LineNumberTable(new byte[] {169, 222, 105, 110, 180, 105, 108, 144, 102, 130, 104, 110, 108, 105, 108, 144, 99, 162, 104, 136, 211, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool putImpl([In] object obj0, [In] int obj1, [In] Scriptable obj2, [In] object obj3)
    {
      ScriptableObject.Slot slot;
      if (!object.ReferenceEquals((object) this, (object) obj2))
      {
        slot = this.slotMap.query(obj0, obj1);
        if (!this.isExtensible && (slot == null || !(slot is ScriptableObject.GetterSlot) && (slot.getAttributes() & 1) != 0) && Context.getContext().isStrictMode())
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.extensible"));
        if (slot == null)
          return false;
      }
      else if (!this.isExtensible)
      {
        slot = this.slotMap.query(obj0, obj1);
        if ((slot == null || !(slot is ScriptableObject.GetterSlot) && (slot.getAttributes() & 1) != 0) && Context.getContext().isStrictMode())
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.extensible"));
        if (slot == null)
          return true;
      }
      else
      {
        if (this.isSealed)
          this.checkNotSealed(obj0, obj1);
        slot = this.slotMap.get(obj0, obj1, ScriptableObject.SlotAccess.MODIFY);
      }
      if ((slot.getAttributes() & 1) != 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.const.redecl", (object) Object.instancehelper_toString(obj0)));
      return slot.setValue(obj3, (Scriptable) this, obj2);
    }

    [LineNumberTable(new byte[] {167, 85, 104, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static SymbolScriptable ensureSymbolScriptable(object arg) => arg is SymbolScriptable ? (SymbolScriptable) arg : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.object.not.symbolscriptable", (object) ScriptRuntime.@typeof(arg)));

    [LineNumberTable(new byte[] {167, 253, 104, 129, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkNotSealed([In] object obj0, [In] int obj1)
    {
      if (this.isSealed())
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.modify.sealed", obj0 == null ? (object) Integer.toString(obj1) : (object) Object.instancehelper_toString(obj0)));
    }

    [LineNumberTable(new byte[] {170, 10, 118, 104, 102, 104, 208, 105, 110, 102, 130, 104, 110, 102, 162, 136, 115, 167, 99, 100, 100, 167, 118, 101, 136, 101, 138, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool putConstImpl([In] string obj0, [In] int obj1, [In] Scriptable obj2, [In] object obj3, [In] int obj4)
    {
      if (!ScriptableObject.\u0024assertionsDisabled && obj4 == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (!this.isExtensible && Context.getContext().isStrictMode())
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.extensible"));
      ScriptableObject.Slot slot1;
      if (!object.ReferenceEquals((object) this, (object) obj2))
      {
        slot1 = this.slotMap.query((object) obj0, obj1);
        if (slot1 == null)
          return false;
      }
      else if (!this.isExtensible())
      {
        slot1 = this.slotMap.query((object) obj0, obj1);
        if (slot1 == null)
          return true;
      }
      else
      {
        this.checkNotSealed((object) obj0, obj1);
        ScriptableObject.Slot slot2 = this.slotMap.get((object) obj0, obj1, ScriptableObject.SlotAccess.MODIFY_CONST);
        int num = slot2.getAttributes();
        if (num == 0)
        {
          num = num | 8 | 1;
          slot2.setAttributes(num);
        }
        if ((num & 1) == 0)
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.const.redecl", (object) obj0));
        if ((num & 8) != 0)
        {
          slot2.value = obj3;
          if (obj4 != 8)
            slot2.setAttributes(num & -9);
        }
        return true;
      }
      return slot1.setValue(obj3, (Scriptable) this, obj2);
    }

    [LineNumberTable(648)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAttributes(string name) => this.findAttributeSlot(name, 0, ScriptableObject.SlotAccess.QUERY).getAttributes();

    [LineNumberTable(664)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAttributes(int index) => this.findAttributeSlot((string) null, index, ScriptableObject.SlotAccess.QUERY).getAttributes();

    [LineNumberTable(new byte[] {162, 67, 104, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAttributes(string name, int attributes)
    {
      this.checkNotSealed((object) name, 0);
      this.findAttributeSlot(name, 0, ScriptableObject.SlotAccess.MODIFY).setAttributes(attributes);
    }

    [LineNumberTable(new byte[] {162, 83, 104, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAttributes(int index, int attributes)
    {
      this.checkNotSealed((object) null, index);
      this.findAttributeSlot((string) null, index, ScriptableObject.SlotAccess.MODIFY).setAttributes(attributes);
    }

    [LineNumberTable(new byte[] {170, 54, 111, 99, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ScriptableObject.Slot findAttributeSlot(
      [In] string obj0,
      [In] int obj1,
      [In] ScriptableObject.SlotAccess obj2)
    {
      return this.slotMap.get((object) obj0, obj1, obj2) ?? throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.prop.not.found", obj0 == null ? (object) Integer.toString(obj1) : (object) obj0));
    }

    [LineNumberTable(new byte[] {170, 63, 111, 99, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ScriptableObject.Slot findAttributeSlot(
      [In] Symbol obj0,
      [In] ScriptableObject.SlotAccess obj1)
    {
      return this.slotMap.get((object) obj0, 0, obj1) ?? throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.prop.not.found", (object) obj0));
    }

    [LineNumberTable(new byte[] {158, 216, 166, 102, 140, 99, 200, 104, 154, 110, 104, 97, 167, 99, 104, 102, 177, 99, 137, 135, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setGetterOrSetter([In] string obj0, [In] int obj1, [In] Callable obj2, [In] bool obj3, [In] bool obj4)
    {
      int num1 = obj4 ? 1 : 0;
      int num2 = obj3 ? 1 : 0;
      if (obj0 != null && obj1 != 0)
      {
        string str = obj0;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (num1 == 0)
        this.checkNotSealed((object) obj0, obj1);
      ScriptableObject.GetterSlot getterSlot;
      if (this.isExtensible())
      {
        getterSlot = (ScriptableObject.GetterSlot) this.slotMap.get((object) obj0, obj1, ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER);
      }
      else
      {
        ScriptableObject.Slot slot = this.slotMap.query((object) obj0, obj1);
        if (!(slot is ScriptableObject.GetterSlot))
          return;
        getterSlot = (ScriptableObject.GetterSlot) slot;
      }
      if (num1 == 0 && (getterSlot.getAttributes() & 1) != 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.modify.readonly", (object) obj0));
      if (num2 != 0)
        getterSlot.setter = (object) obj2;
      else
        getterSlot.getter = (object) obj2;
      getterSlot.value = Undefined.__\u003C\u003Einstance;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isExtensible() => this.isExtensible;

    [LineNumberTable(new byte[] {161, 147, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(string name)
    {
      this.checkNotSealed((object) name, 0);
      this.slotMap.remove((object) name, 0);
    }

    [LineNumberTable(new byte[] {166, 5, 98, 102, 167, 109, 104, 137, 162, 171, 98, 103, 100, 99, 136, 101, 133, 156, 104, 99, 134, 98, 134, 99, 210, 99, 103, 115, 103, 37, 171, 169, 110, 105, 138, 163, 172, 99, 105, 102, 100, 137, 102, 134, 156, 105, 100, 135, 98, 135, 100, 212, 153, 105, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void defineProperty(
      string propertyName,
      object delegateTo,
      Method getter,
      Method setter,
      int attributes)
    {
      MemberBox memberBox1 = (MemberBox) null;
      if (getter != null)
      {
        memberBox1 = new MemberBox(getter);
        int num;
        if (!Modifier.isStatic(getter.getModifiers()))
        {
          num = delegateTo == null ? 0 : 1;
          memberBox1.delegateTo = delegateTo;
        }
        else
        {
          num = 1;
          memberBox1.delegateTo = (object) Void.TYPE;
        }
        string str = (string) null;
        Class[] parameterTypes = getter.getParameterTypes();
        if (parameterTypes.Length == 0)
        {
          if (num != 0)
            str = "msg.obj.getter.parms";
        }
        else if (parameterTypes.Length == 1)
        {
          Class @class = parameterTypes[0];
          if (!object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EScriptableClass) && !object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EScriptableObjectClass))
            str = "msg.bad.getter.parms";
          else if (num == 0)
            str = "msg.bad.getter.parms";
        }
        else
          str = "msg.bad.getter.parms";
        if (str != null)
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1(str, (object) getter.toString()));
      }
      MemberBox memberBox2 = (MemberBox) null;
      if (setter != null)
      {
        memberBox2 = object.ReferenceEquals((object) setter.getReturnType(), (object) Void.TYPE) ? new MemberBox(setter) : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.setter.return", (object) setter.toString()));
        int num;
        if (!Modifier.isStatic(setter.getModifiers()))
        {
          num = delegateTo == null ? 0 : 1;
          memberBox2.delegateTo = delegateTo;
        }
        else
        {
          num = 1;
          memberBox2.delegateTo = (object) Void.TYPE;
        }
        string str = (string) null;
        Class[] parameterTypes = setter.getParameterTypes();
        if (parameterTypes.Length == 1)
        {
          if (num != 0)
            str = "msg.setter2.expected";
        }
        else if (parameterTypes.Length == 2)
        {
          Class @class = parameterTypes[0];
          if (!object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EScriptableClass) && !object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EScriptableObjectClass))
            str = "msg.setter2.parms";
          else if (num == 0)
            str = "msg.setter1.parms";
        }
        else
          str = "msg.setter.parms";
        if (str != null)
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1(str, (object) setter.toString()));
      }
      ScriptableObject.GetterSlot getterSlot = (ScriptableObject.GetterSlot) this.slotMap.get((object) propertyName, 0, ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER);
      getterSlot.setAttributes(attributes);
      getterSlot.getter = (object) memberBox1;
      getterSlot.setter = (object) memberBox2;
    }

    [LineNumberTable(new byte[] {156, 224, 132, 151, 99, 136, 103, 104, 43, 200, 109, 162, 99, 141, 127, 8, 159, 6, 133, 99, 115, 100, 171, 159, 3, 134, 135, 109, 35, 98, 162, 104, 133, 105, 172, 103, 143, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object[] getIds([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      int length1 = this.externalData != null ? this.externalData.getArrayLength() : 0;
      object[] objArray1;
      if (length1 == 0)
      {
        objArray1 = ScriptRuntime.__\u003C\u003EemptyArgs;
      }
      else
      {
        objArray1 = new object[length1];
        for (int index = 0; index < length1; ++index)
          objArray1[index] = (object) Integer.valueOf(index);
      }
      if (this.slotMap.isEmpty())
        return objArray1;
      int length2 = length1;
      long num3 = this.slotMap.readLock();
      try
      {
        Iterator iterator = this.slotMap.iterator();
        while (iterator.hasNext())
        {
          ScriptableObject.Slot slot = (ScriptableObject.Slot) iterator.next();
          if ((num1 != 0 || (slot.getAttributes() & 2) == 0) && (num2 != 0 || !(slot.name is Symbol)))
          {
            if (length2 == length1)
            {
              object[] objArray2 = objArray1;
              objArray1 = new object[this.slotMap.dirtySize() + length1];
              if (objArray2 != null)
                ByteCodeHelper.arraycopy((object) objArray2, 0, (object) objArray1, 0, length1);
            }
            object[] objArray3 = objArray1;
            int index = length2;
            ++length2;
            Integer integer = slot.name == null ? Integer.valueOf(slot.indexOrHash) : (Integer) slot.name;
            objArray3[index] = (object) integer;
          }
        }
      }
      finally
      {
        this.slotMap.unlockRead(num3);
      }
      object[] objArray4;
      if (length2 == objArray1.Length + length1)
      {
        objArray4 = objArray1;
      }
      else
      {
        objArray4 = new object[length2];
        ByteCodeHelper.arraycopy((object) objArray1, 0, (object) objArray4, 0, length2);
      }
      Context currentContext = Context.getCurrentContext();
      if (currentContext != null && currentContext.hasFeature(16))
        Arrays.sort(objArray4, ScriptableObject.KEY_COMPARATOR);
      return objArray4;
    }

    [Signature("(Lrhino/Scriptable;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {163, 57, 98, 137, 109, 138, 197, 99, 136, 134, 105, 105, 101, 105, 99, 134, 119, 100, 105, 131, 154, 131, 172, 110, 105, 227, 29, 233, 104, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getDefaultValue(Scriptable @object, Class typeHint)
    {
      Context c = (Context) null;
      for (int index = 0; index < 2; ++index)
      {
        int num = !object.ReferenceEquals((object) typeHint, (object) ScriptRuntime.__\u003C\u003EStringClass) ? (index == 1 ? 1 : 0) : (index != 0 ? 0 : 1);
        string name = num == 0 ? "valueOf" : "toString";
        object property = ScriptableObject.getProperty(@object, name);
        if (property is Function)
        {
          Function function = (Function) property;
          if (c == null)
            c = Context.getContext();
          object obj1 = function.call(c, function.getParentScope(), @object, ScriptRuntime.__\u003C\u003EemptyArgs);
          if (obj1 != null)
          {
            if (!(obj1 is Scriptable) || object.ReferenceEquals((object) typeHint, (object) ScriptRuntime.__\u003C\u003EScriptableClass) || object.ReferenceEquals((object) typeHint, (object) ScriptRuntime.__\u003C\u003EFunctionClass))
              return obj1;
            if (num != 0 && obj1 is Wrapper)
            {
              object obj2 = ((Wrapper) obj1).unwrap();
              if (obj2 is string)
                return obj2;
            }
          }
        }
      }
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.default.value", typeHint != null ? (object) typeHint.getName() : (object) "undefined"));
    }

    [Throws(new string[] {"java.lang.IllegalAccessException", "java.lang.InstantiationException", "java.lang.reflect.InvocationTargetException"})]
    [Signature("<T::Lrhino/Scriptable;>(Lrhino/Scriptable;Ljava/lang/Class<TT;>;ZZ)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {158, 100, 68, 138, 99, 98, 108, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string defineClass(
      Scriptable scope,
      Class clazz,
      bool @sealed,
      bool mapInheritance)
    {
      int num1 = @sealed ? 1 : 0;
      int num2 = mapInheritance ? 1 : 0;
      BaseFunction baseFunction = ScriptableObject.buildClassCtor(scope, clazz, num1 != 0, num2 != 0);
      if (baseFunction == null)
        return (string) null;
      string className = baseFunction.getClassPrototype().getClassName();
      ScriptableObject.defineProperty(scope, className, (object) baseFunction, 2);
      return className;
    }

    [Throws(new string[] {"java.lang.IllegalAccessException", "java.lang.InstantiationException", "java.lang.reflect.InvocationTargetException"})]
    [Signature("<T::Lrhino/Scriptable;>(Lrhino/Scriptable;Ljava/lang/Class<TT;>;ZZ)Lrhino/BaseFunction;")]
    [LineNumberTable(new byte[] {158, 97, 164, 103, 106, 101, 115, 101, 105, 223, 31, 108, 159, 7, 112, 130, 152, 108, 108, 112, 226, 44, 233, 92, 109, 99, 106, 109, 103, 226, 61, 232, 70, 100, 102, 37, 203, 120, 169, 111, 105, 110, 115, 232, 70, 99, 99, 104, 112, 108, 98, 103, 140, 100, 202, 100, 136, 233, 69, 102, 102, 102, 102, 134, 109, 105, 142, 105, 141, 103, 102, 104, 102, 108, 104, 108, 134, 100, 102, 37, 235, 69, 127, 4, 105, 103, 159, 4, 138, 99, 103, 103, 123, 107, 133, 105, 110, 105, 223, 25, 108, 100, 197, 108, 101, 110, 133, 99, 99, 110, 112, 110, 112, 110, 112, 110, 165, 100, 110, 105, 110, 105, 113, 231, 72, 157, 108, 109, 107, 180, 106, 132, 122, 105, 135, 12, 203, 111, 204, 181, 165, 114, 208, 109, 105, 103, 159, 4, 127, 20, 99, 231, 159, 168, 235, 160, 93, 100, 118, 208, 99, 103, 105, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static BaseFunction buildClassCtor(
      [In] Scriptable obj0,
      [In] Class obj1,
      [In] bool obj2,
      [In] bool obj3)
    {
      int num1 = obj2 ? 1 : 0;
      int num2 = obj3 ? 1 : 0;
      Method[] methodList = FunctionObject.getMethodList(obj1);
      for (int index = 0; index < methodList.Length; ++index)
      {
        Method method = methodList[index];
        if (String.instancehelper_equals(method.getName(), (object) "init"))
        {
          Class[] parameterTypes = method.getParameterTypes();
          if (parameterTypes.Length == 3 && object.ReferenceEquals((object) parameterTypes[0], (object) ScriptRuntime.__\u003C\u003EContextClass) && (object.ReferenceEquals((object) parameterTypes[1], (object) ScriptRuntime.__\u003C\u003EScriptableClass) && object.ReferenceEquals((object) parameterTypes[2], (object) Boolean.TYPE)) && Modifier.isStatic(method.getModifiers()))
          {
            object[] objArray = new object[3]
            {
              (object) Context.getContext(),
              (object) obj0,
              num1 == 0 ? (object) Boolean.FALSE : (object) Boolean.TRUE
            };
            method.invoke((object) null, objArray, ScriptableObject.__\u003CGetCallerID\u003E());
            return (BaseFunction) null;
          }
          if (parameterTypes.Length == 1 && object.ReferenceEquals((object) parameterTypes[0], (object) ScriptRuntime.__\u003C\u003EScriptableClass) && Modifier.isStatic(method.getModifiers()))
          {
            object[] objArray = new object[1]
            {
              (object) obj0
            };
            method.invoke((object) null, objArray, ScriptableObject.__\u003CGetCallerID\u003E());
            return (BaseFunction) null;
          }
        }
      }
      Constructor[] constructors = obj1.getConstructors(ScriptableObject.__\u003CGetCallerID\u003E());
      Constructor constructor = (Constructor) null;
      for (int index = 0; index < constructors.Length; ++index)
      {
        if (constructors[index].getParameterTypes().Length == 0)
        {
          constructor = constructors[index];
          break;
        }
      }
      Scriptable scope1 = constructor != null ? (Scriptable) constructor.newInstance(ScriptRuntime.__\u003C\u003EemptyArgs, ScriptableObject.__\u003CGetCallerID\u003E()) : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.zero.arg.ctor", (object) obj1.getName()));
      string className1 = scope1.getClassName();
      object property = ScriptableObject.getProperty(ScriptableObject.getTopLevelScope(obj0), className1);
      if (property is BaseFunction)
      {
        object prototypeProperty = ((BaseFunction) property).getPrototypeProperty();
        if (prototypeProperty != null && Object.instancehelper_equals((object) obj1, (object) Object.instancehelper_getClass(prototypeProperty)))
          return (BaseFunction) property;
      }
      Scriptable s = (Scriptable) null;
      if (num2 != 0)
      {
        Class superclass = obj1.getSuperclass();
        if (ScriptRuntime.__\u003C\u003EScriptableClass.isAssignableFrom(superclass) && !Modifier.isAbstract(superclass.getModifiers()))
        {
          Class clazz = ScriptableObject.extendsScriptable(superclass);
          string className2 = ScriptableObject.defineClass(obj0, clazz, num1 != 0, num2 != 0);
          if (className2 != null)
            s = ScriptableObject.getClassPrototype(obj0, className2);
        }
      }
      if (s == null)
        s = ScriptableObject.getObjectPrototype(obj0);
      scope1.setPrototype(s);
      object objB = (object) ScriptableObject.findAnnotatedMember((AccessibleObject[]) methodList, (Class) ClassLiteral<JSConstructor>.Value);
      if ((Member) objB == null)
        objB = (object) ScriptableObject.findAnnotatedMember((AccessibleObject[]) constructors, (Class) ClassLiteral<JSConstructor>.Value);
      if ((Member) objB == null)
        objB = (object) FunctionObject.findSingleMethod(methodList, "jsConstructor");
      if (objB == null)
      {
        if (constructors.Length == 1)
          objB = (object) constructors[0];
        else if (constructors.Length == 2)
        {
          if (constructors[0].getParameterTypes().Length == 0)
            objB = (object) constructors[1];
          else if (constructors[1].getParameterTypes().Length == 0)
            objB = (object) constructors[0];
        }
        if (objB == null)
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.ctor.multiple.parms", (object) obj1.getName()));
      }
      string name1 = className1;
      object obj4 = objB;
      Scriptable scriptable1 = obj0;
      Member methodOrConstructor;
      if (obj4 != null)
        methodOrConstructor = obj4 is Member member2 ? member2 : throw new IncompatibleClassChangeError();
      else
        methodOrConstructor = (Member) null;
      Scriptable scope2 = scriptable1;
      FunctionObject functionObject1 = new FunctionObject(name1, methodOrConstructor, scope2);
      if (functionObject1.isVarArgsMethod())
      {
        object obj5 = objB;
        Member member3;
        if (obj5 != null)
          member3 = obj5 is Member member7 ? member7 : throw new IncompatibleClassChangeError();
        else
          member3 = (Member) null;
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.varargs.ctor", (object) member3.getName()));
      }
      functionObject1.initAsConstructor(obj0, scope1);
      Method method1 = (Method) null;
      HashSet hashSet1 = new HashSet();
      HashSet hashSet2 = new HashSet();
      Method[] methodArray = methodList;
      int length = methodArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Method getter = methodArray[index];
        if (!object.ReferenceEquals((object) getter, objB))
        {
          string name2 = getter.getName();
          if (String.instancehelper_equals(name2, (object) "finishInit"))
          {
            Class[] parameterTypes = getter.getParameterTypes();
            if (parameterTypes.Length == 3 && object.ReferenceEquals((object) parameterTypes[0], (object) ScriptRuntime.__\u003C\u003EScriptableClass) && (object.ReferenceEquals((object) parameterTypes[1], (object) ClassLiteral<FunctionObject>.Value) && object.ReferenceEquals((object) parameterTypes[2], (object) ScriptRuntime.__\u003C\u003EScriptableClass)) && Modifier.isStatic(getter.getModifiers()))
            {
              method1 = getter;
              continue;
            }
          }
          if (String.instancehelper_indexOf(name2, 36) == -1 && !String.instancehelper_equals(name2, (object) "jsConstructor"))
          {
            Annotation annotation = (Annotation) null;
            string str1 = (string) null;
            if (((AccessibleObject) getter).isAnnotationPresent((Class) ClassLiteral<JSFunction>.Value))
              annotation = getter.getAnnotation((Class) ClassLiteral<JSFunction>.Value);
            else if (((AccessibleObject) getter).isAnnotationPresent((Class) ClassLiteral<JSStaticFunction>.Value))
              annotation = getter.getAnnotation((Class) ClassLiteral<JSStaticFunction>.Value);
            else if (((AccessibleObject) getter).isAnnotationPresent((Class) ClassLiteral<JSGetter>.Value))
              annotation = getter.getAnnotation((Class) ClassLiteral<JSGetter>.Value);
            else if (((AccessibleObject) getter).isAnnotationPresent((Class) ClassLiteral<JSSetter>.Value))
              continue;
            if (annotation == null)
            {
              if (String.instancehelper_startsWith(name2, "jsFunction_"))
                str1 = "jsFunction_";
              else if (String.instancehelper_startsWith(name2, "jsStaticFunction_"))
                str1 = "jsStaticFunction_";
              else if (String.instancehelper_startsWith(name2, "jsGet_"))
                str1 = "jsGet_";
              else
                continue;
            }
            int num3 = annotation is JSStaticFunction || object.ReferenceEquals((object) str1, (object) "jsStaticFunction_") ? 1 : 0;
            HashSet hashSet3 = num3 == 0 ? hashSet2 : hashSet1;
            string propertyName1 = ScriptableObject.getPropertyName(name2, str1, annotation);
            if (hashSet3.contains((object) propertyName1))
              throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("duplicate.defineClass.name", (object) name2, (object) propertyName1));
            hashSet3.add((object) propertyName1);
            string str2 = propertyName1;
            if (annotation is JSGetter || object.ReferenceEquals((object) str1, (object) "jsGet_"))
            {
              if (!(scope1 is ScriptableObject))
                throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.extend.scriptable", (object) Object.instancehelper_getClass((object) scope1).toString(), (object) str2));
              Method setterMethod = ScriptableObject.findSetterMethod(methodList, str2, "jsSet_");
              int attributes = 6 | (setterMethod == null ? 1 : 0);
              ((ScriptableObject) scope1).defineProperty(str2, (object) null, getter, setterMethod, attributes);
            }
            else
            {
              if (num3 != 0 && !Modifier.isStatic(getter.getModifiers()))
                throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError("jsStaticFunction must be used with static method."));
              FunctionObject functionObject2 = new FunctionObject(str2, (Member) getter, scope1);
              if (functionObject2.isVarArgsConstructor())
              {
                object obj5 = objB;
                Member member3;
                if (obj5 != null)
                  member3 = obj5 is Member member17 ? member17 : throw new IncompatibleClassChangeError();
                else
                  member3 = (Member) null;
                throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.varargs.fun", (object) member3.getName()));
              }
              Scriptable scriptable2 = num3 == 0 ? scope1 : (Scriptable) functionObject1;
              string str3 = str2;
              FunctionObject functionObject3 = functionObject2;
              int num4 = 2;
              object obj6 = (object) functionObject3;
              string str4 = str3;
              Scriptable destination;
              if (scriptable2 != null)
                destination = scriptable2 is Scriptable scriptable12 ? scriptable12 : throw new IncompatibleClassChangeError();
              else
                destination = (Scriptable) null;
              string propertyName2 = str4;
              object obj7 = obj6;
              int attributes = num4;
              ScriptableObject.defineProperty(destination, propertyName2, obj7, attributes);
              if (num1 != 0)
                functionObject2.sealObject();
            }
          }
        }
      }
      if (method1 != null)
      {
        object[] objArray = new object[3]
        {
          (object) obj0,
          (object) functionObject1,
          (object) scope1
        };
        method1.invoke((object) null, objArray, ScriptableObject.__\u003CGetCallerID\u003E());
      }
      if (num1 != 0)
      {
        functionObject1.sealObject();
        if (scope1 is ScriptableObject)
          ((ScriptableObject) scope1).sealObject();
      }
      return (BaseFunction) functionObject1;
    }

    [LineNumberTable(new byte[] {165, 154, 104, 105, 129, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void defineProperty(
      Scriptable destination,
      string propertyName,
      object value,
      int attributes)
    {
      if (!(destination is ScriptableObject))
        destination.put(propertyName, destination, value);
      else
        ((ScriptableObject) destination).defineProperty(propertyName, value, attributes);
    }

    [LineNumberTable(new byte[] {167, 196, 103, 99, 130, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable getTopLevelScope(Scriptable obj)
    {
      while (true)
      {
        Scriptable parentScope = obj.getParentScope();
        if (parentScope != null)
          obj = parentScope;
        else
          break;
      }
      return obj;
    }

    [Signature("<T::Lrhino/Scriptable;>(Ljava/lang/Class<*>;)Ljava/lang/Class<TT;>;")]
    [LineNumberTable(new byte[] {165, 107, 109, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Class extendsScriptable([In] Class obj0) => ScriptRuntime.__\u003C\u003EScriptableClass.isAssignableFrom(obj0) ? obj0 : (Class) null;

    [LineNumberTable(new byte[] {167, 169, 104, 136, 104, 110, 104, 103, 109, 98, 130, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable getClassPrototype(Scriptable scope, string className)
    {
      scope = ScriptableObject.getTopLevelScope(scope);
      object property = ScriptableObject.getProperty(scope, className);
      object prototypeProperty;
      switch (property)
      {
        case BaseFunction _:
          prototypeProperty = ((BaseFunction) property).getPrototypeProperty();
          break;
        case Scriptable _:
          Scriptable s = (Scriptable) property;
          prototypeProperty = s.get("prototype", s);
          break;
        default:
          return (Scriptable) null;
      }
      return prototypeProperty is Scriptable ? (Scriptable) prototypeProperty : (Scriptable) null;
    }

    [LineNumberTable(2035)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable getObjectPrototype(Scriptable scope) => TopLevel.getBuiltinPrototype(ScriptableObject.getTopLevelScope(scope), TopLevel.Builtins.__\u003C\u003EObject);

    [Signature("([Ljava/lang/reflect/AccessibleObject;Ljava/lang/Class<+Ljava/lang/annotation/Annotation;>;)Ljava/lang/reflect/Member;")]
    [LineNumberTable(new byte[] {165, 40, 111, 105, 7, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Member findAnnotatedMember([In] AccessibleObject[] obj0, [In] Class obj1)
    {
      AccessibleObject[] accessibleObjectArray = obj0;
      int length = accessibleObjectArray.Length;
      for (int index = 0; index < length; ++index)
      {
        AccessibleObject accessibleObject = accessibleObjectArray[index];
        if (accessibleObject.isAnnotationPresent(obj1))
          return (Member) accessibleObject;
      }
      return (Member) null;
    }

    [LineNumberTable(new byte[] {165, 75, 99, 141, 98, 107, 108, 110, 124, 104, 113, 105, 113, 110, 120, 242, 69, 104, 110, 104, 140, 107, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string getPropertyName([In] string obj0, [In] string obj1, [In] Annotation obj2)
    {
      if (obj1 != null)
        return String.instancehelper_substring(obj0, String.instancehelper_length(obj1));
      string str = (string) null;
      switch (obj2)
      {
        case JSGetter _:
          str = ((JSGetter) obj2).value();
          if ((str == null || String.instancehelper_length(str) == 0) && (String.instancehelper_length(obj0) > 3 && String.instancehelper_startsWith(obj0, "get")))
          {
            str = String.instancehelper_substring(obj0, 3);
            if (Character.isUpperCase(String.instancehelper_charAt(str, 0)))
            {
              if (String.instancehelper_length(str) == 1)
              {
                str = String.instancehelper_toLowerCase(str, (Locale) Locale.ROOT);
                break;
              }
              if (!Character.isUpperCase(String.instancehelper_charAt(str, 1)))
              {
                str = new StringBuilder().append(Character.toLowerCase(String.instancehelper_charAt(str, 0))).append(String.instancehelper_substring(str, 1)).toString();
                break;
              }
              break;
            }
            break;
          }
          break;
        case JSFunction _:
          str = ((JSFunction) obj2).value();
          break;
        case JSStaticFunction _:
          str = ((JSStaticFunction) obj2).value();
          break;
      }
      if (str == null || String.instancehelper_length(str) == 0)
        str = obj0;
      return str;
    }

    [LineNumberTable(new byte[] {165, 51, 113, 113, 112, 115, 115, 100, 118, 123, 227, 59, 233, 73, 120, 118, 112, 3, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Method findSetterMethod([In] Method[] obj0, [In] string obj1, [In] string obj2)
    {
      string str1 = new StringBuilder().append("set").append(Character.toUpperCase(String.instancehelper_charAt(obj1, 0))).append(String.instancehelper_substring(obj1, 1)).toString();
      Method[] methodArray1 = obj0;
      int length1 = methodArray1.Length;
      for (int index = 0; index < length1; ++index)
      {
        Method method = methodArray1[index];
        JSSetter annotation = (JSSetter) method.getAnnotation((Class) ClassLiteral<JSSetter>.Value);
        if (annotation != null && (String.instancehelper_equals(obj1, (object) annotation.value()) || String.instancehelper_equals("", (object) annotation.value()) && String.instancehelper_equals(str1, (object) method.getName())))
          return method;
      }
      string str2 = new StringBuilder().append(obj2).append(obj1).toString();
      Method[] methodArray2 = obj0;
      int length2 = methodArray2.Length;
      for (int index = 0; index < length2; ++index)
      {
        Method method = methodArray2[index];
        if (String.instancehelper_equals(str2, (object) method.getName()))
          return method;
      }
      return (Method) null;
    }

    [LineNumberTable(new byte[] {167, 221, 107, 140, 240, 77, 108, 247, 51, 103, 104, 136, 151, 109, 230, 69, 108, 237, 57, 111, 232, 69, 108, 225, 60, 101, 139, 108, 35, 98, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sealObject()
    {
      if (this.isSealed)
        return;
      long num = this.slotMap.readLock();
      Iterator iterator;
      // ISSUE: fault handler
      try
      {
        iterator = this.slotMap.iterator();
      }
      __fault
      {
        this.slotMap.unlockRead(num);
      }
      ScriptableObject.Slot slot;
      LazilyLoadedCtor lazilyLoadedCtor;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        while (true)
        {
          object obj;
          do
          {
            if (iterator.hasNext())
            {
              slot = (ScriptableObject.Slot) iterator.next();
              obj = slot.value;
            }
            else
              goto label_14;
          }
          while (!(obj is LazilyLoadedCtor));
          lazilyLoadedCtor = (LazilyLoadedCtor) obj;
          try
          {
            lazilyLoadedCtor.init();
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            break;
          }
          slot.value = lazilyLoadedCtor.getValue();
        }
      }
      __fault
      {
        this.slotMap.unlockRead(num);
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        slot.value = lazilyLoadedCtor.getValue();
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      __fault
      {
        this.slotMap.unlockRead(num);
      }
label_14:
      try
      {
        this.isSealed = true;
      }
      finally
      {
        this.slotMap.unlockRead(num);
      }
    }

    [LineNumberTable(new byte[] {161, 91, 108, 129, 116, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(string name, Scriptable start, object value)
    {
      if (this.putImpl((object) name, 0, start, value))
        return;
      if (object.ReferenceEquals((object) start, (object) this))
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      start.put(name, start, value);
    }

    [LineNumberTable(new byte[] {161, 131, 108, 129, 116, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(Symbol key, Scriptable start, object value)
    {
      if (this.putImpl((object) key, 0, start, value))
        return;
      if (object.ReferenceEquals((object) start, (object) this))
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      ScriptableObject.ensureSymbolScriptable((object) start).put(key, start, value);
    }

    [LineNumberTable(new byte[] {162, 91, 104, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAttributes(Symbol key, int attributes)
    {
      this.checkNotSealed((object) key, 0);
      this.findAttributeSlot(key, ScriptableObject.SlotAccess.MODIFY).setAttributes(attributes);
    }

    [LineNumberTable(new byte[] {167, 91, 104, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static ScriptableObject ensureScriptableObject(object arg) => arg is ScriptableObject ? (ScriptableObject) arg : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.arg.not.object", (object) ScriptRuntime.@typeof(arg)));

    [LineNumberTable(new byte[] {166, 187, 108, 159, 3, 140, 108, 159, 3, 140, 114, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void checkPropertyDefinition(ScriptableObject desc)
    {
      object property1 = ScriptableObject.getProperty((Scriptable) desc, "get");
      if (!object.ReferenceEquals(property1, Scriptable.NOT_FOUND) && !object.ReferenceEquals(property1, Undefined.__\u003C\u003Einstance) && !(property1 is Callable))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(property1));
      object property2 = ScriptableObject.getProperty((Scriptable) desc, "set");
      if (!object.ReferenceEquals(property2, Scriptable.NOT_FOUND) && !object.ReferenceEquals(property2, Undefined.__\u003C\u003Einstance) && !(property2 is Callable))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(property2));
      if (this.isDataDescriptor(desc) && this.isAccessorDescriptor(desc))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.both.data.and.accessor.desc"));
    }

    [LineNumberTable(new byte[] {166, 118, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void defineOwnProperty(Context cx, object id, ScriptableObject desc)
    {
      this.checkPropertyDefinition(desc);
      this.defineOwnProperty(cx, id, desc, true);
    }

    [LineNumberTable(new byte[] {157, 208, 67, 110, 136, 99, 105, 102, 169, 169, 99, 121, 140, 175, 103, 104, 174, 136, 109, 110, 137, 109, 110, 169, 108, 105, 101, 113, 174, 109, 110, 106, 99, 139, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void defineOwnProperty(
      Context cx,
      object id,
      ScriptableObject desc,
      bool checkValid)
    {
      int num1 = checkValid ? 1 : 0;
      ScriptableObject.Slot slot = this.getSlot(cx, id, ScriptableObject.SlotAccess.QUERY);
      int num2 = slot != null ? 0 : 1;
      if (num1 != 0)
      {
        ScriptableObject propertyDescriptor = slot?.getPropertyDescriptor(cx, (Scriptable) this);
        this.checkPropertyChange(id, propertyDescriptor, desc);
      }
      int num3 = this.isAccessorDescriptor(desc) ? 1 : 0;
      int attributeBitset;
      if (slot == null)
      {
        slot = this.getSlot(cx, id, num3 == 0 ? ScriptableObject.SlotAccess.MODIFY : ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER);
        attributeBitset = this.applyDescriptorToAttributeBitset(7, desc);
      }
      else
        attributeBitset = this.applyDescriptorToAttributeBitset(slot.getAttributes(), desc);
      if (num3 != 0)
      {
        if (!(slot is ScriptableObject.GetterSlot))
          slot = this.getSlot(cx, id, ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER);
        ScriptableObject.GetterSlot getterSlot = (ScriptableObject.GetterSlot) slot;
        object property1 = ScriptableObject.getProperty((Scriptable) desc, "get");
        if (!object.ReferenceEquals(property1, Scriptable.NOT_FOUND))
          getterSlot.getter = property1;
        object property2 = ScriptableObject.getProperty((Scriptable) desc, "set");
        if (!object.ReferenceEquals(property2, Scriptable.NOT_FOUND))
          getterSlot.setter = property2;
        getterSlot.value = Undefined.__\u003C\u003Einstance;
        getterSlot.setAttributes(attributeBitset);
      }
      else
      {
        if (slot is ScriptableObject.GetterSlot && this.isDataDescriptor(desc))
          slot = this.getSlot(cx, id, ScriptableObject.SlotAccess.CONVERT_ACCESSOR_TO_DATA);
        object property = ScriptableObject.getProperty((Scriptable) desc, "value");
        if (!object.ReferenceEquals(property, Scriptable.NOT_FOUND))
          slot.value = property;
        else if (num2 != 0)
          slot.value = Undefined.__\u003C\u003Einstance;
        slot.setAttributes(attributeBitset);
      }
    }

    [LineNumberTable(new byte[] {170, 165, 104, 143, 104, 104, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual ScriptableObject.Slot getSlot(
      Context cx,
      object id,
      ScriptableObject.SlotAccess accessType)
    {
      if (id is Symbol)
        return this.slotMap.get(id, 0, accessType);
      ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(cx, id);
      return stringIdOrIndex.stringId == null ? this.slotMap.get((object) null, stringIdOrIndex.index, accessType) : this.slotMap.get((object) stringIdOrIndex.stringId, 0, accessType);
    }

    [LineNumberTable(new byte[] {166, 204, 99, 155, 118, 114, 145, 127, 4, 145, 104, 104, 139, 108, 118, 114, 177, 127, 3, 177, 108, 127, 0, 177, 127, 0, 177, 105, 145, 241, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void checkPropertyChange(
      object id,
      ScriptableObject current,
      ScriptableObject desc)
    {
      if (current == null)
      {
        if (!this.isExtensible())
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.extensible"));
      }
      else
      {
        if (!ScriptableObject.isFalse(current.get("configurable", (Scriptable) current)))
          return;
        if (ScriptableObject.isTrue(ScriptableObject.getProperty((Scriptable) desc, "configurable")))
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.change.configurable.false.to.true", id));
        if (ScriptableObject.isTrue(current.get("enumerable", (Scriptable) current)) != ScriptableObject.isTrue(ScriptableObject.getProperty((Scriptable) desc, "enumerable")))
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.change.enumerable.with.configurable.false", id));
        int num1 = this.isDataDescriptor(desc) ? 1 : 0;
        int num2 = this.isAccessorDescriptor(desc) ? 1 : 0;
        if (num1 == 0 && num2 == 0)
          return;
        if (num1 != 0 && this.isDataDescriptor(current))
        {
          if (!ScriptableObject.isFalse(current.get("writable", (Scriptable) current)))
            return;
          if (ScriptableObject.isTrue(ScriptableObject.getProperty((Scriptable) desc, "writable")))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.change.writable.false.to.true.with.configurable.false", id));
          if (!this.sameValue(ScriptableObject.getProperty((Scriptable) desc, "value"), current.get("value", (Scriptable) current)))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.change.value.with.writable.false", id));
        }
        else if (num2 != 0 && this.isAccessorDescriptor(current))
        {
          if (!this.sameValue(ScriptableObject.getProperty((Scriptable) desc, "set"), current.get("set", (Scriptable) current)))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.change.setter.with.configurable.false", id));
          if (!this.sameValue(ScriptableObject.getProperty((Scriptable) desc, "get"), current.get("get", (Scriptable) current)))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.change.getter.with.configurable.false", id));
        }
        else
        {
          if (this.isDataDescriptor(current))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.change.property.data.to.accessor.with.configurable.false", id));
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.change.property.accessor.to.data.with.configurable.false", id));
        }
      }
    }

    [LineNumberTable(1972)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool isAccessorDescriptor(ScriptableObject desc) => ScriptableObject.hasProperty((Scriptable) desc, "get") || ScriptableObject.hasProperty((Scriptable) desc, "set");

    [LineNumberTable(new byte[] {167, 30, 108, 109, 211, 108, 109, 211, 108, 109, 211})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int applyDescriptorToAttributeBitset(
      int attributes,
      ScriptableObject desc)
    {
      object property1 = ScriptableObject.getProperty((Scriptable) desc, "enumerable");
      if (!object.ReferenceEquals(property1, Scriptable.NOT_FOUND))
        attributes = !ScriptRuntime.toBoolean(property1) ? attributes | 2 : attributes & -3;
      object property2 = ScriptableObject.getProperty((Scriptable) desc, "writable");
      if (!object.ReferenceEquals(property2, Scriptable.NOT_FOUND))
        attributes = !ScriptRuntime.toBoolean(property2) ? attributes | 1 : attributes & -2;
      object property3 = ScriptableObject.getProperty((Scriptable) desc, "configurable");
      if (!object.ReferenceEquals(property3, Scriptable.NOT_FOUND))
        attributes = !ScriptRuntime.toBoolean(property3) ? attributes | 4 : attributes & -5;
      return attributes;
    }

    [LineNumberTable(1963)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool isDataDescriptor(ScriptableObject desc) => ScriptableObject.hasProperty((Scriptable) desc, "value") || ScriptableObject.hasProperty((Scriptable) desc, "writable");

    [LineNumberTable(new byte[] {161, 34, 110, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(string name, Scriptable start)
    {
      ScriptableObject.Slot slot = this.slotMap.query((object) name, 0);
      return slot == null ? Scriptable.NOT_FOUND : slot.getValue(start);
    }

    [LineNumberTable(1902)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static bool isFalse(object value) => !ScriptableObject.isTrue(value);

    [LineNumberTable(1898)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static bool isTrue(object value) => !object.ReferenceEquals(value, Scriptable.NOT_FOUND) && ScriptRuntime.toBoolean(value);

    [LineNumberTable(new byte[] {167, 7, 109, 130, 109, 199, 112, 110, 110, 112, 130, 118, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool sameValue(object newValue, object currentValue)
    {
      if (object.ReferenceEquals(newValue, Scriptable.NOT_FOUND))
        return true;
      if (object.ReferenceEquals(currentValue, Scriptable.NOT_FOUND))
        currentValue = Undefined.__\u003C\u003Einstance;
      if (currentValue is Number && newValue is Number)
      {
        double num1 = ((Number) currentValue).doubleValue();
        double num2 = ((Number) newValue).doubleValue();
        if (Double.isNaN(num1) && Double.isNaN(num2))
          return true;
        if (num1 == 0.0 && Double.doubleToLongBits(num1) != Double.doubleToLongBits(num2))
          return false;
      }
      return ScriptRuntime.shallowEq(currentValue, newValue);
    }

    [LineNumberTable(2295)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasProperty(Scriptable obj, string name) => !object.ReferenceEquals((object) null, (object) ScriptableObject.getBase(obj, name));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isSealed() => this.isSealed;

    [LineNumberTable(new byte[] {168, 86, 162, 105, 109, 98, 104, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getProperty(Scriptable obj, int index)
    {
      Scriptable s = obj;
      object objA;
      do
      {
        objA = obj.get(index, s);
        if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
          obj = obj.getPrototype();
        else
          break;
      }
      while (obj != null);
      return objA;
    }

    [LineNumberTable(new byte[] {169, 127, 106, 98, 104, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Scriptable getBase([In] Scriptable obj0, [In] string obj1)
    {
      while (!obj0.has(obj1, obj0))
      {
        obj0 = obj0.getPrototype();
        if (obj0 == null)
          break;
      }
      return obj0;
    }

    [LineNumberTable(new byte[] {169, 136, 106, 98, 104, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Scriptable getBase([In] Scriptable obj0, [In] int obj1)
    {
      while (!obj0.has(obj1, obj0))
      {
        obj0 = obj0.getPrototype();
        if (obj0 == null)
          break;
      }
      return obj0;
    }

    [LineNumberTable(new byte[] {169, 145, 111, 98, 104, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Scriptable getBase([In] Scriptable obj0, [In] Symbol obj1)
    {
      while (!ScriptableObject.ensureSymbolScriptable((object) obj0).has(obj1, obj0))
      {
        obj0 = obj0.getPrototype();
        if (obj0 == null)
          break;
      }
      return obj0;
    }

    [LineNumberTable(new byte[] {169, 106, 104, 104, 141, 231, 72, 103, 99, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object callMethod(Context cx, Scriptable obj, string methodName, object[] args)
    {
      object property = ScriptableObject.getProperty(obj, methodName);
      Function function = property is Function ? (Function) property : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError((object) obj, (object) methodName));
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(obj);
      return cx != null ? function.call(cx, topLevelScope, obj, args) : Context.call((ContextFactory) null, (Callable) function, topLevelScope, obj, args);
    }

    [LineNumberTable(new byte[] {169, 158, 105, 99, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object getAssociatedValue(object key) => this.associatedValues?.get(key);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getParentScope() => this.parentScopeObject;

    [LineNumberTable(new byte[] {161, 68, 110, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(Symbol key, Scriptable start)
    {
      ScriptableObject.Slot slot = this.slotMap.query((object) key, 0);
      return slot == null ? Scriptable.NOT_FOUND : slot.getValue(start);
    }

    [LineNumberTable(new byte[] {161, 49, 104, 110, 141, 166, 110, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int index, Scriptable start)
    {
      if (this.externalData != null)
        return index < this.externalData.getArrayLength() ? this.externalData.getArrayElement(index) : Scriptable.NOT_FOUND;
      ScriptableObject.Slot slot = this.slotMap.query((object) null, index);
      return slot == null ? Scriptable.NOT_FOUND : slot.getValue(start);
    }

    [LineNumberTable(new byte[] {123, 102, 108, 109, 122, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static ScriptableObject buildDataDescriptor(
      Scriptable scope,
      object value,
      int attributes)
    {
      NativeObject nativeObject = new NativeObject();
      ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeObject, scope, TopLevel.Builtins.__\u003C\u003EObject);
      nativeObject.defineProperty(nameof (value), value, 0);
      nativeObject.defineProperty("writable", (object) Boolean.valueOf((attributes & 1) == 0), 0);
      nativeObject.defineProperty("enumerable", (object) Boolean.valueOf((attributes & 2) == 0), 0);
      nativeObject.defineProperty("configurable", (object) Boolean.valueOf((attributes & 4) == 0), 0);
      return (ScriptableObject) nativeObject;
    }

    [LineNumberTable(new byte[] {160, 200, 99, 102, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void checkValidAttributes([In] int obj0)
    {
      if ((obj0 & -16) != 0)
      {
        string str = String.valueOf(obj0);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 214, 232, 159, 26, 103, 231, 160, 230, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScriptableObject()
    {
      ScriptableObject scriptableObject = this;
      this.isExtensible = true;
      this.isSealed = false;
      this.slotMap = this.createSlotMap(0);
    }

    [LineNumberTable(new byte[] {160, 218, 232, 159, 22, 103, 231, 160, 234, 99, 139, 103, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScriptableObject(Scriptable scope, Scriptable prototype)
    {
      ScriptableObject scriptableObject = this;
      this.isExtensible = true;
      this.isSealed = false;
      if (scope == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.parentScopeObject = scope;
      this.prototypeObject = prototype;
      this.slotMap = this.createSlotMap(0);
    }

    [LineNumberTable(347)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getTypeOf() => this.avoidObjectDetection() ? "undefined" : "object";

    public abstract string getClassName();

    [LineNumberTable(368)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(string name, Scriptable start) => !object.ReferenceEquals((object) null, (object) this.slotMap.query((object) name, 0));

    [LineNumberTable(new byte[] {161, 9, 104, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(int index, Scriptable start)
    {
      if (this.externalData != null)
        return index < this.externalData.getArrayLength();
      return !object.ReferenceEquals((object) null, (object) this.slotMap.query((object) null, index));
    }

    [LineNumberTable(390)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Symbol key, Scriptable start) => !object.ReferenceEquals((object) null, (object) this.slotMap.query((object) key, 0));

    [LineNumberTable(new byte[] {161, 106, 104, 110, 143, 101, 255, 12, 69, 161, 108, 129, 116, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(int index, Scriptable start, object value)
    {
      if (this.externalData != null)
      {
        if (index < this.externalData.getArrayLength())
        {
          this.externalData.setArrayElement(index, value);
        }
        else
        {
          JavaScriptException.__\u003Cclinit\u003E();
          Scriptable scriptable = ScriptRuntime.newNativeError(Context.getCurrentContext(), (Scriptable) this, TopLevel.NativeErrors.RangeError, new object[1]
          {
            (object) "External array index out of bounds "
          });
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new JavaScriptException((object) scriptable, (string) null, 0);
        }
      }
      else
      {
        if (this.putImpl((object) null, index, start, value))
          return;
        if (object.ReferenceEquals((object) start, (object) this))
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        start.put(index, start, value);
      }
    }

    [LineNumberTable(new byte[] {161, 160, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(int index)
    {
      this.checkNotSealed((object) null, index);
      this.slotMap.remove((object) null, index);
    }

    [LineNumberTable(new byte[] {161, 169, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(Symbol key)
    {
      this.checkNotSealed((object) key, 0);
      this.slotMap.remove((object) key, 0);
    }

    [LineNumberTable(new byte[] {161, 189, 109, 129, 116, 104, 144, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putConst(string name, Scriptable start, object value)
    {
      if (this.putConstImpl(name, 0, start, value, 1))
        return;
      if (object.ReferenceEquals((object) start, (object) this))
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      if (start is ConstProperties)
        ((ConstProperties) start).putConst(name, start, value);
      else
        start.put(name, start, value);
    }

    [LineNumberTable(new byte[] {161, 201, 113, 129, 116, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void defineConst(string name, Scriptable start)
    {
      if (this.putConstImpl(name, 0, start, Undefined.__\u003C\u003Einstance, 8))
        return;
      if (object.ReferenceEquals((object) start, (object) this))
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      if (!(start is ConstProperties))
        return;
      ((ConstProperties) start).defineConst(name, start);
    }

    [LineNumberTable(new byte[] {161, 216, 110, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isConst(string name)
    {
      ScriptableObject.Slot slot = this.slotMap.query((object) name, 0);
      return slot != null && (slot.getAttributes() & 5) == 5;
    }

    [Obsolete]
    [LineNumberTable(601)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int getAttributes(string name, Scriptable start) => this.getAttributes(name);

    [Obsolete]
    [LineNumberTable(610)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int getAttributes(int index, Scriptable start) => this.getAttributes(index);

    [Obsolete]
    [LineNumberTable(new byte[] {161, 250, 104})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setAttributes(string name, Scriptable start, int attributes) => this.setAttributes(name, attributes);

    [Obsolete]
    [LineNumberTable(new byte[] {162, 4, 104})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAttributes(int index, Scriptable start, int attributes) => this.setAttributes(index, attributes);

    [LineNumberTable(668)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAttributes(Symbol sym) => this.findAttributeSlot(sym, ScriptableObject.SlotAccess.QUERY).getAttributes();

    [LineNumberTable(new byte[] {158, 217, 131, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setGetterOrSetter(
      string name,
      int index,
      Callable getterOrSetter,
      bool isSetter)
    {
      int num = isSetter ? 1 : 0;
      this.setGetterOrSetter(name, index, getterOrSetter, num != 0, false);
    }

    [LineNumberTable(new byte[] {158, 205, 162, 102, 108, 110, 99, 98, 104, 103, 114, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getGetterOrSetter(string name, int index, bool isSetter)
    {
      int num = isSetter ? 1 : 0;
      if (name != null && index != 0)
      {
        string str = name;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      ScriptableObject.Slot slot = this.slotMap.query((object) name, index);
      if (slot == null)
        return (object) null;
      if (!(slot is ScriptableObject.GetterSlot))
        return Undefined.__\u003C\u003Einstance;
      ScriptableObject.GetterSlot getterSlot = (ScriptableObject.GetterSlot) slot;
      return (num == 0 ? getterSlot.getter : getterSlot.setter) ?? Undefined.__\u003C\u003Einstance;
    }

    [LineNumberTable(new byte[] {158, 199, 66, 110, 104, 114, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool isGetterOrSetter(string name, int index, bool setter)
    {
      int num = setter ? 1 : 0;
      ScriptableObject.Slot slot = this.slotMap.query((object) name, index);
      return slot is ScriptableObject.GetterSlot && (num != 0 && ((ScriptableObject.GetterSlot) slot).setter != null || num == 0 && ((ScriptableObject.GetterSlot) slot).getter != null);
    }

    [LineNumberTable(new byte[] {162, 180, 102, 108, 104, 152, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addLazilyInitializedValue(
      [In] string obj0,
      [In] int obj1,
      [In] LazilyLoadedCtor obj2,
      [In] int obj3)
    {
      if (obj0 != null && obj1 != 0)
      {
        string str = obj0;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.checkNotSealed((object) obj0, obj1);
      ScriptableObject.GetterSlot getterSlot = (ScriptableObject.GetterSlot) this.slotMap.get((object) obj0, obj1, ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER);
      getterSlot.setAttributes(obj3);
      getterSlot.getter = (object) null;
      getterSlot.setter = (object) null;
      getterSlot.value = (object) obj2;
    }

    [LineNumberTable(new byte[] {162, 201, 135, 99, 173, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setExternalArrayData(ExternalArrayData array)
    {
      this.externalData = array;
      if (array == null)
        this.delete("length");
      else
        this.defineProperty("length", (object) null, ScriptableObject.GET_ARRAY_LENGTH, (Method) null, 3);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ExternalArrayData getExternalArrayData() => this.externalData;

    [LineNumberTable(851)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getExternalArrayLength() => (object) Integer.valueOf(this.externalData != null ? this.externalData.getArrayLength() : 0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getPrototype() => this.prototypeObject;

    [LineNumberTable(new byte[] {162, 241, 104, 113, 144, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPrototype(Scriptable m)
    {
      if (!this.isExtensible() && Context.getContext().getLanguageVersion() >= 180)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.extensible"));
      this.prototypeObject = m;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParentScope(Scriptable m) => this.parentScopeObject = m;

    [LineNumberTable(902)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getIds() => this.getIds(false, false);

    [LineNumberTable(917)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getAllIds() => this.getIds(true, false);

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(935)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getDefaultValue(Class typeHint) => ScriptableObject.getDefaultValue((Scriptable) this, typeHint);

    [LineNumberTable(998)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasInstance(Scriptable instance) => ScriptRuntime.jsDelegatesTo(instance, (Scriptable) this);

    [LineNumberTable(1030)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual object equivalentValues(object value) => object.ReferenceEquals((object) this, value) ? (object) Boolean.TRUE : Scriptable.NOT_FOUND;

    [Throws(new string[] {"java.lang.IllegalAccessException", "java.lang.InstantiationException", "java.lang.reflect.InvocationTargetException"})]
    [Signature("<T::Lrhino/Scriptable;>(Lrhino/Scriptable;Ljava/lang/Class<TT;>;)V")]
    [LineNumberTable(new byte[] {163, 247, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void defineClass(Scriptable scope, Class clazz) => ScriptableObject.defineClass(scope, clazz, false, false);

    [Throws(new string[] {"java.lang.IllegalAccessException", "java.lang.InstantiationException", "java.lang.reflect.InvocationTargetException"})]
    [Signature("<T::Lrhino/Scriptable;>(Lrhino/Scriptable;Ljava/lang/Class<TT;>;Z)V")]
    [LineNumberTable(new byte[] {158, 109, 130, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void defineClass(Scriptable scope, Class clazz, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      ScriptableObject.defineClass(scope, clazz, num != 0, false);
    }

    [LineNumberTable(new byte[] {165, 136, 104, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void defineProperty(Symbol key, object value, int attributes)
    {
      this.checkNotSealed((object) key, 0);
      this.put(key, (Scriptable) this, value);
      this.setAttributes(key, attributes);
    }

    [LineNumberTable(new byte[] {165, 172, 104, 103, 104, 98, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void defineConstProperty(Scriptable destination, string propertyName)
    {
      if (destination is ConstProperties)
        ((ConstProperties) destination).defineConst(propertyName, destination);
      else
        ScriptableObject.defineProperty(destination, propertyName, Undefined.__\u003C\u003Einstance, 13);
    }

    [Signature("(Ljava/lang/String;Ljava/lang/Class<*>;I)V")]
    [LineNumberTable(new byte[] {165, 198, 103, 110, 105, 106, 107, 101, 101, 101, 103, 101, 135, 104, 106, 106, 100, 101, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void defineProperty(string propertyName, Class clazz, int attributes)
    {
      int num = String.instancehelper_length(propertyName);
      if (num == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      char[] chArray = new char[3 + num];
      String.instancehelper_getChars(propertyName, 0, num, chArray, 3);
      chArray[3] = Character.toUpperCase(chArray[3]);
      chArray[0] = 'g';
      chArray[1] = 'e';
      chArray[2] = 't';
      string str1 = String.newhelper(chArray);
      chArray[0] = 's';
      string str2 = String.newhelper(chArray);
      Method[] methodList = FunctionObject.getMethodList(clazz);
      Method singleMethod1 = FunctionObject.findSingleMethod(methodList, str1);
      Method singleMethod2 = FunctionObject.findSingleMethod(methodList, str2);
      if (singleMethod2 == null)
        attributes |= 1;
      this.defineProperty(propertyName, (object) null, singleMethod1, singleMethod2, attributes);
    }

    [LineNumberTable(new byte[] {166, 98, 105, 104, 105, 108, 105, 104, 229, 60, 230, 70, 105, 45, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void defineOwnProperties(Context cx, ScriptableObject props)
    {
      object[] ids = props.getIds(false, true);
      ScriptableObject[] scriptableObjectArray = new ScriptableObject[ids.Length];
      int index1 = 0;
      for (int length = ids.Length; index1 < length; ++index1)
      {
        ScriptableObject desc = ScriptableObject.ensureScriptableObject(ScriptRuntime.getObjectElem((Scriptable) props, ids[index1], cx));
        this.checkPropertyDefinition(desc);
        scriptableObjectArray[index1] = desc;
      }
      int index2 = 0;
      for (int length = ids.Length; index2 < length; ++index2)
        this.defineOwnProperty(cx, ids[index2], scriptableObjectArray[index2]);
    }

    [LineNumberTable(1981)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool isGenericDescriptor(ScriptableObject desc) => !this.isDataDescriptor(desc) && !this.isAccessorDescriptor(desc);

    [LineNumberTable(new byte[] {167, 79, 104, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static Scriptable ensureScriptable(object arg) => arg is Scriptable ? (Scriptable) arg : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.arg.not.object", (object) ScriptRuntime.@typeof(arg)));

    [Signature("([Ljava/lang/String;Ljava/lang/Class<*>;I)V")]
    [LineNumberTable(new byte[] {167, 110, 103, 103, 100, 104, 99, 103, 37, 171, 106, 234, 56, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void defineFunctionProperties(string[] names, Class clazz, int attributes)
    {
      Method[] methodList = FunctionObject.getMethodList(clazz);
      for (int index = 0; index < names.Length; ++index)
      {
        string name = names[index];
        FunctionObject functionObject = new FunctionObject(name, (Member) (FunctionObject.findSingleMethod(methodList, name) ?? throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.method.not.found", (object) name, (object) clazz.getName()))), (Scriptable) this);
        this.defineProperty(name, (object) functionObject, attributes);
      }
    }

    [LineNumberTable(2045)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable getFunctionPrototype(Scriptable scope) => TopLevel.getBuiltinPrototype(ScriptableObject.getTopLevelScope(scope), TopLevel.Builtins.__\u003C\u003EFunction);

    [LineNumberTable(2050)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable getGeneratorFunctionPrototype(Scriptable scope) => TopLevel.getBuiltinPrototype(ScriptableObject.getTopLevelScope(scope), TopLevel.Builtins.__\u003C\u003EGeneratorFunction);

    [LineNumberTable(2055)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable getArrayPrototype(Scriptable scope) => TopLevel.getBuiltinPrototype(ScriptableObject.getTopLevelScope(scope), TopLevel.Builtins.__\u003C\u003EArray);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void preventExtensions() => this.isExtensible = false;

    [LineNumberTable(new byte[] {168, 32, 162, 110, 109, 98, 104, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getProperty(Scriptable obj, Symbol key)
    {
      Scriptable s2 = obj;
      object objA;
      do
      {
        objA = ScriptableObject.ensureSymbolScriptable((object) obj).get(key, s2);
        if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
          obj = obj.getPrototype();
        else
          break;
      }
      while (obj != null);
      return objA;
    }

    [Signature("<T:Ljava/lang/Object;>(Lrhino/Scriptable;Ljava/lang/String;Ljava/lang/Class<TT;>;)TT;")]
    [LineNumberTable(new byte[] {168, 114, 104, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getTypedProperty(Scriptable s, string name, Class type)
    {
      object objA = ScriptableObject.getProperty(s, name);
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        objA = (object) null;
      return type.cast(Context.jsToJava(objA, type));
    }

    [LineNumberTable(new byte[] {157, 77, 98, 104, 99, 97, 104, 135, 105, 145, 99, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void redefineProperty(Scriptable obj, string name, bool isConst)
    {
      int num = isConst ? 1 : 0;
      Scriptable scriptable = ScriptableObject.getBase(obj, name);
      if (scriptable == null)
        return;
      if (scriptable is ConstProperties && ((ConstProperties) scriptable).isConst(name))
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.const.redecl", (object) name));
      if (num != 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.var.redecl", (object) name));
    }

    [LineNumberTable(2334)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasProperty(Scriptable obj, int index) => !object.ReferenceEquals((object) null, (object) ScriptableObject.getBase(obj, index));

    [LineNumberTable(2341)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasProperty(Scriptable obj, Symbol key) => !object.ReferenceEquals((object) null, (object) ScriptableObject.getBase(obj, key));

    [LineNumberTable(new byte[] {168, 198, 104, 99, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void putProperty(Scriptable obj, string name, object value) => (ScriptableObject.getBase(obj, name) ?? obj).put(name, obj, value);

    [LineNumberTable(new byte[] {168, 208, 104, 99, 98, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void putProperty(Scriptable obj, Symbol key, object value) => ScriptableObject.ensureSymbolScriptable((object) (ScriptableObject.getBase(obj, key) ?? obj)).put(key, obj, value);

    [LineNumberTable(new byte[] {168, 230, 104, 101, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void putConstProperty(Scriptable obj, string name, object value)
    {
      Scriptable scriptable = ScriptableObject.getBase(obj, name) ?? obj;
      if (!(scriptable is ConstProperties))
        return;
      ((ConstProperties) scriptable).putConst(name, obj, value);
    }

    [LineNumberTable(new byte[] {168, 251, 104, 99, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void putProperty(Scriptable obj, int index, object value) => (ScriptableObject.getBase(obj, index) ?? obj).put(index, obj, value);

    [LineNumberTable(new byte[] {169, 13, 104, 99, 98, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool deleteProperty(Scriptable obj, string name)
    {
      Scriptable scriptable = ScriptableObject.getBase(obj, name);
      if (scriptable == null)
        return true;
      scriptable.delete(name);
      return !scriptable.has(name, obj);
    }

    [LineNumberTable(new byte[] {169, 32, 104, 99, 98, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool deleteProperty(Scriptable obj, int index)
    {
      Scriptable scriptable = ScriptableObject.getBase(obj, index);
      if (scriptable == null)
        return true;
      scriptable.delete(index);
      return !scriptable.has(index, obj);
    }

    [LineNumberTable(new byte[] {169, 49, 99, 134, 103, 130, 104, 99, 133, 103, 100, 130, 99, 100, 98, 130, 112, 103, 42, 166, 130, 103, 42, 166, 101, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object[] getPropertyIds(Scriptable obj)
    {
      if (obj == null)
        return ScriptRuntime.__\u003C\u003EemptyArgs;
      object[] objArray = obj.getIds();
      ObjToIntMap objToIntMap = (ObjToIntMap) null;
label_3:
      object[] ids;
      while (true)
      {
        do
        {
          obj = obj.getPrototype();
          if (obj != null)
            ids = obj.getIds();
          else
            goto label_15;
        }
        while (ids.Length == 0);
        if (objToIntMap == null)
        {
          if (objArray.Length == 0)
            objArray = ids;
          else
            break;
        }
        else
          goto label_12;
      }
      ObjToIntMap.__\u003Cclinit\u003E();
      objToIntMap = new ObjToIntMap(objArray.Length + ids.Length);
      for (int index = 0; index != objArray.Length; ++index)
        objToIntMap.intern(objArray[index]);
      objArray = (object[]) null;
label_12:
      int index1 = 0;
      while (true)
      {
        if (index1 != ids.Length)
        {
          objToIntMap.intern(ids[index1]);
          ++index1;
        }
        else
          goto label_3;
      }
label_15:
      if (objToIntMap != null)
        objArray = objToIntMap.getKeys();
      return objArray;
    }

    [LineNumberTable(2511)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object callMethod(Scriptable obj, string methodName, object[] args) => ScriptableObject.callMethod((Context) null, obj, methodName, args);

    [LineNumberTable(new byte[] {169, 175, 136, 104, 103, 104, 99, 162, 104, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getTopScopeValue(Scriptable scope, object key)
    {
      scope = ScriptableObject.getTopLevelScope(scope);
      do
      {
        if (scope is ScriptableObject)
        {
          object associatedValue = ((ScriptableObject) scope).getAssociatedValue(key);
          if (associatedValue != null)
            return associatedValue;
        }
        scope = scope.getPrototype();
      }
      while (scope != null);
      return (object) null;
    }

    [LineNumberTable(new byte[] {169, 204, 110, 105, 104, 102, 147})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public object associateValue(object key, object value)
    {
      if (value == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      object obj1 = (object) this.associatedValues;
      if ((Map) obj1 == null)
      {
        obj1 = (object) new HashMap();
        this.associatedValues = (Map) obj1;
        Thread.MemoryBarrier();
      }
      object obj2 = obj1;
      object obj3 = key;
      object obj4 = value;
      object obj5 = obj3;
      Map map1;
      if (obj2 != null)
        map1 = obj2 is Map map3 ? map3 : throw new IncompatibleClassChangeError();
      else
        map1 = (Map) null;
      object obj6 = obj5;
      object obj7 = obj4;
      return Kit.initHash(map1, obj6, obj7);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {170, 128, 102, 140, 108, 99, 137, 103, 127, 1, 103, 164, 108, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeObject([In] ObjectOutputStream obj0)
    {
      obj0.defaultWriteObject();
      long num1 = this.slotMap.readLock();
      try
      {
        int num2 = this.slotMap.dirtySize();
        if (num2 == 0)
        {
          obj0.writeInt(0);
        }
        else
        {
          obj0.writeInt(num2);
          Iterator iterator = this.slotMap.iterator();
          while (iterator.hasNext())
          {
            ScriptableObject.Slot slot = (ScriptableObject.Slot) iterator.next();
            obj0.writeObject((object) slot);
          }
        }
      }
      finally
      {
        this.slotMap.unlockRead(num1);
      }
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {170, 147, 134, 103, 109, 102, 108, 12, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      int num = obj0.readInt();
      this.slotMap = this.createSlotMap(num);
      for (int index = 0; index < num; ++index)
        this.slotMap.addSlot((ScriptableObject.Slot) obj0.readObject());
    }

    [LineNumberTable(new byte[] {170, 158, 110, 101, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual ScriptableObject getOwnPropertyDescriptor(
      Context cx,
      object id)
    {
      ScriptableObject.Slot slot1 = this.getSlot(cx, id, ScriptableObject.SlotAccess.QUERY);
      if (slot1 == null)
        return (ScriptableObject) null;
      Scriptable parentScope = this.getParentScope();
      ScriptableObject.Slot slot2 = slot1;
      Context context = cx;
      Scriptable scriptable1 = parentScope ?? (Scriptable) this;
      Scriptable scriptable2;
      if (scriptable1 != null)
        scriptable2 = scriptable1 is Scriptable scriptable4 ? scriptable4 : throw new IncompatibleClassChangeError();
      else
        scriptable2 = (Scriptable) null;
      return slot2.getPropertyDescriptor(context, scriptable2);
    }

    [LineNumberTable(2853)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.slotMap.size();

    [LineNumberTable(2857)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.slotMap.isEmpty();

    [LineNumberTable(new byte[] {170, 188, 98, 104, 112, 104, 112, 104, 147, 122, 98, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(object key)
    {
      object objA = (object) null;
      switch (key)
      {
        case string _:
          objA = this.get((string) key, (Scriptable) this);
          break;
        case Symbol _:
          objA = this.get((Symbol) key, (Scriptable) this);
          break;
        case Number _:
          objA = this.get(((Number) key).intValue(), (Scriptable) this);
          break;
      }
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND) || object.ReferenceEquals(objA, Undefined.__\u003C\u003Einstance))
        return (object) null;
      return objA is Wrapper ? ((Wrapper) objA).unwrap() : objA;
    }

    [LineNumberTable(new byte[] {159, 136, 173, 245, 160, 78, 191, 18, 2, 97, 236, 170, 212})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ScriptableObject()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.ScriptableObject"))
        return;
      ScriptableObject.\u0024assertionsDisabled = !((Class) ClassLiteral<ScriptableObject>.Value).desiredAssertionStatus();
      NoSuchMethodException suchMethodException1;
      try
      {
        ScriptableObject.GET_ARRAY_LENGTH = ((Class) ClassLiteral<ScriptableObject>.Value).getMethod("getExternalArrayLength", new Class[0], ScriptableObject.__\u003CGetCallerID\u003E());
        goto label_6;
      }
      catch (NoSuchMethodException ex)
      {
        suchMethodException1 = (NoSuchMethodException) ByteCodeHelper.MapException<NoSuchMethodException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      NoSuchMethodException suchMethodException2 = suchMethodException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) suchMethodException2);
label_6:
      ScriptableObject.KEY_COMPARATOR = (Comparator) new ScriptableObject.KeyComparator();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (ScriptableObject.__\u003CcallerID\u003E == null)
        ScriptableObject.__\u003CcallerID\u003E = (CallerID) new ScriptableObject.__\u003CCallerID\u003E();
      return ScriptableObject.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    [NameSig("getSlot", "(Lrhino.Context;Ljava.lang.Object;Lrhino.ScriptableObject$SlotAccess;)Lrhino.ScriptableObject$Slot;")]
    protected internal object getSlot([In] Context obj0, [In] object obj1, [In] Enum obj2) => (object) this.getSlot(obj0, obj1, (ScriptableObject.SlotAccess) obj2);

    [HideFromJava]
    [NameSig("getSlot", "(Lrhino.Context;Ljava.lang.Object;Lrhino.ScriptableObject$SlotAccess;)Lrhino.ScriptableObject$Slot;")]
    protected internal object \u003Cnonvirtual\u003E0([In] Context obj0, [In] object obj1, [In] Enum obj2) => (object) this.getSlot(obj0, obj1, (ScriptableObject.SlotAccess) obj2);

    internal sealed class GetterSlot : ScriptableObject.Slot
    {
      internal object getter;
      internal object setter;

      [LineNumberTable(new byte[] {160, 77, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal GetterSlot([In] object obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1, obj2)
      {
      }

      [LineNumberTable(new byte[] {160, 82, 103, 102, 108, 122, 122, 112, 186, 123, 107, 109, 127, 11, 109, 159, 6, 178, 107, 109, 127, 11, 109, 159, 6, 178})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal override ScriptableObject getPropertyDescriptor(
        [In] Context obj0,
        [In] Scriptable obj1)
      {
        int attributes = this.getAttributes();
        NativeObject nativeObject1 = new NativeObject();
        ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeObject1, obj1, TopLevel.Builtins.__\u003C\u003EObject);
        nativeObject1.defineProperty("enumerable", (object) Boolean.valueOf((attributes & 2) == 0), 0);
        nativeObject1.defineProperty("configurable", (object) Boolean.valueOf((attributes & 4) == 0), 0);
        if (this.getter == null && this.setter == null)
          nativeObject1.defineProperty("writable", (object) Boolean.valueOf((attributes & 1) == 0), 0);
        string name = this.name != null ? Object.instancehelper_toString(this.name) : "f";
        if (this.getter != null)
        {
          if (this.getter is MemberBox)
          {
            NativeObject nativeObject2 = nativeObject1;
            FunctionObject.__\u003Cclinit\u003E();
            FunctionObject functionObject = new FunctionObject(name, ((MemberBox) this.getter).member(), obj1);
            nativeObject2.defineProperty("get", (object) functionObject, 0);
          }
          else if (this.getter is Member)
          {
            NativeObject nativeObject2 = nativeObject1;
            FunctionObject.__\u003Cclinit\u003E();
            FunctionObject functionObject = new FunctionObject(name, (Member) this.getter, obj1);
            nativeObject2.defineProperty("get", (object) functionObject, 0);
          }
          else
            nativeObject1.defineProperty("get", this.getter, 0);
        }
        if (this.setter != null)
        {
          if (this.setter is MemberBox)
          {
            NativeObject nativeObject2 = nativeObject1;
            FunctionObject.__\u003Cclinit\u003E();
            FunctionObject functionObject = new FunctionObject(name, ((MemberBox) this.setter).member(), obj1);
            nativeObject2.defineProperty("set", (object) functionObject, 0);
          }
          else if (this.setter is Member)
          {
            NativeObject nativeObject2 = nativeObject1;
            FunctionObject.__\u003Cclinit\u003E();
            FunctionObject functionObject = new FunctionObject(name, (Member) this.setter, obj1);
            nativeObject2.defineProperty("set", (object) functionObject, 0);
          }
          else
            nativeObject1.defineProperty("set", this.setter, 0);
        }
        return (ScriptableObject) nativeObject1;
      }

      [LineNumberTable(new byte[] {160, 115, 107, 107, 102, 171, 135, 102, 104, 159, 27, 215, 162, 102, 112, 108, 167, 104, 105, 204, 104, 99, 143, 104, 145, 107, 111, 109, 187, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal override bool setValue([In] object obj0, [In] Scriptable obj1, [In] Scriptable obj2)
      {
        if (this.setter == null)
        {
          if (this.getter == null)
            return base.setValue(obj0, obj1, obj2);
          Context context = Context.getContext();
          if (context.isStrictMode() || context.hasFeature(11))
          {
            string str = "";
            str = this.name != null ? new StringBuilder().append("[").append(obj2.getClassName()).append("].").append(Object.instancehelper_toString(this.name)).toString() : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError2("msg.set.prop.no.setter", (object) str, (object) Context.toString(obj0)));
          }
          else
            return true;
        }
        else
        {
          Context context = Context.getContext();
          if (this.setter is MemberBox)
          {
            MemberBox setter = (MemberBox) this.setter;
            Class[] argTypes = setter.argTypes;
            int typeTag = FunctionObject.getTypeTag(argTypes[argTypes.Length - 1]);
            object obj3 = FunctionObject.convertArg(context, obj2, obj0, typeTag);
            object obj4;
            object[] objArray;
            if (setter.delegateTo == null)
            {
              obj4 = (object) obj2;
              objArray = new object[1]{ obj3 };
            }
            else
            {
              obj4 = setter.delegateTo;
              objArray = new object[2]
              {
                (object) obj2,
                obj3
              };
            }
            setter.invoke(obj4, objArray);
          }
          else if (this.setter is Function)
          {
            Function setter = (Function) this.setter;
            setter.call(context, setter.getParentScope(), obj2, new object[1]
            {
              obj0
            });
          }
          return true;
        }
      }

      [LineNumberTable(new byte[] {160, 166, 107, 109, 172, 104, 98, 136, 103, 139, 105, 109, 108, 103, 213, 104, 105, 137, 139, 112, 35, 98, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal override object getValue([In] Scriptable obj0)
      {
        if (this.getter != null)
        {
          if (this.getter is MemberBox)
          {
            MemberBox getter = (MemberBox) this.getter;
            object obj;
            object[] objArray;
            if (getter.delegateTo == null)
            {
              obj = (object) obj0;
              objArray = ScriptRuntime.__\u003C\u003EemptyArgs;
            }
            else
            {
              obj = getter.delegateTo;
              objArray = new object[1]{ (object) obj0 };
            }
            return getter.invoke(obj, objArray);
          }
          if (this.getter is Function)
          {
            Function getter = (Function) this.getter;
            Context context = Context.getContext();
            return getter.call(context, getter.getParentScope(), obj0, ScriptRuntime.__\u003C\u003EemptyArgs);
          }
        }
        object obj1 = this.value;
        if (obj1 is LazilyLoadedCtor)
        {
          LazilyLoadedCtor lazilyLoadedCtor = (LazilyLoadedCtor) obj1;
          try
          {
            lazilyLoadedCtor.init();
          }
          finally
          {
            this.value = obj1 = lazilyLoadedCtor.getValue();
          }
        }
        return obj1;
      }
    }

    [Signature("Ljava/lang/Object;Ljava/util/Comparator<Ljava/lang/Object;>;")]
    public sealed class KeyComparator : Object, Comparator
    {
      [LineNumberTable(2888)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public KeyComparator()
      {
      }

      [LineNumberTable(new byte[] {170, 218, 104, 104, 108, 108, 100, 130, 100, 130, 130, 130, 104, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compare(object o1, object o2)
      {
        if (o1 is Integer)
        {
          if (!(o2 is Integer))
            return -1;
          int num1 = ((Integer) o1).intValue();
          int num2 = ((Integer) o2).intValue();
          if (num1 < num2)
            return -1;
          return num1 > num2 ? 1 : 0;
        }
        return o2 is Integer ? 1 : 0;
      }

      [HideFromJava]
      public virtual Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [HideFromJava]
      public virtual Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [HideFromJava]
      public virtual Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);

      bool Comparator.__\u003Coverridestub\u003Ejava\u002Eutil\u002EComparator\u003A\u003Aequals(
        [In] object obj0)
      {
        return Object.instancehelper_equals((object) this, obj0);
      }
    }

    internal class Slot : Object
    {
      internal object name;
      internal int indexOrHash;
      private short attributes;
      internal object value;
      [NonSerialized]
      internal ScriptableObject.Slot next;
      [NonSerialized]
      internal ScriptableObject.Slot orderedNext;

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual object getValue([In] Scriptable obj0) => this.value;

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual int getAttributes() => (int) this.attributes;

      [LineNumberTable(new byte[] {110, 102, 104})]
      [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
      internal virtual void setAttributes([In] int obj0)
      {
        ScriptableObject.checkValidAttributes(obj0);
        this.attributes = (short) obj0;
      }

      [LineNumberTable(165)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual ScriptableObject getPropertyDescriptor(
        [In] Context obj0,
        [In] Scriptable obj1)
      {
        return ScriptableObject.buildDataDescriptor(obj1, this.value, (int) this.attributes);
      }

      [LineNumberTable(new byte[] {88, 106, 108, 150, 130, 105, 103, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool setValue([In] object obj0, [In] Scriptable obj1, [In] Scriptable obj2)
      {
        if (((int) this.attributes & 1) != 0)
        {
          if (Context.getContext().isStrictMode())
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.modify.readonly", this.name));
          return true;
        }
        if (!object.ReferenceEquals((object) obj1, (object) obj2))
          return false;
        this.value = obj0;
        return true;
      }

      [LineNumberTable(new byte[] {73, 104, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Slot([In] object obj0, [In] int obj1, [In] int obj2)
      {
        ScriptableObject.Slot slot = this;
        this.name = obj0;
        this.indexOrHash = obj1;
        this.attributes = (short) obj2;
      }

      [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
      [LineNumberTable(new byte[] {81, 102, 104, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void readObject([In] ObjectInputStream obj0)
      {
        obj0.defaultReadObject();
        if (this.name == null)
          return;
        this.indexOrHash = Object.instancehelper_hashCode(this.name);
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lrhino/ScriptableObject$SlotAccess;>;")]
    [Modifiers]
    [Serializable]
    internal sealed class SlotAccess : Enum
    {
      [Modifiers]
      public static ScriptableObject.SlotAccess QUERY;
      [Modifiers]
      public static ScriptableObject.SlotAccess MODIFY;
      [Modifiers]
      public static ScriptableObject.SlotAccess MODIFY_CONST;
      [Modifiers]
      public static ScriptableObject.SlotAccess MODIFY_GETTER_SETTER;
      [Modifiers]
      public static ScriptableObject.SlotAccess CONVERT_ACCESSOR_TO_DATA;
      [Modifiers]
      private static ScriptableObject.SlotAccess[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(94)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static ScriptableObject.SlotAccess[] values() => (ScriptableObject.SlotAccess[]) ScriptableObject.SlotAccess.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(94)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private SlotAccess([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(94)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static ScriptableObject.SlotAccess valueOf([In] string obj0) => (ScriptableObject.SlotAccess) Enum.valueOf((Class) ClassLiteral<ScriptableObject.SlotAccess>.Value, obj0);

      [LineNumberTable(new byte[] {159, 119, 173, 63, 49})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static SlotAccess()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.ScriptableObject$SlotAccess"))
          return;
        ScriptableObject.SlotAccess.QUERY = new ScriptableObject.SlotAccess(nameof (QUERY), 0);
        ScriptableObject.SlotAccess.MODIFY = new ScriptableObject.SlotAccess(nameof (MODIFY), 1);
        ScriptableObject.SlotAccess.MODIFY_CONST = new ScriptableObject.SlotAccess(nameof (MODIFY_CONST), 2);
        ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER = new ScriptableObject.SlotAccess(nameof (MODIFY_GETTER_SETTER), 3);
        ScriptableObject.SlotAccess.CONVERT_ACCESSOR_TO_DATA = new ScriptableObject.SlotAccess(nameof (CONVERT_ACCESSOR_TO_DATA), 4);
        ScriptableObject.SlotAccess.\u0024VALUES = new ScriptableObject.SlotAccess[5]
        {
          ScriptableObject.SlotAccess.QUERY,
          ScriptableObject.SlotAccess.MODIFY,
          ScriptableObject.SlotAccess.MODIFY_CONST,
          ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER,
          ScriptableObject.SlotAccess.CONVERT_ACCESSOR_TO_DATA
        };
      }
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
