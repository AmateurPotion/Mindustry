// Decompiled with JetBrains decompiler
// Type: rhino.NativeJavaObject
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.lang.reflect;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Scriptable", "rhino.SymbolScriptable", "rhino.Wrapper"})]
  public class NativeJavaObject : Object, Scriptable, SymbolScriptable, Wrapper
  {
    private const int JSTYPE_UNDEFINED = 0;
    private const int JSTYPE_NULL = 1;
    private const int JSTYPE_BOOLEAN = 2;
    private const int JSTYPE_NUMBER = 3;
    private const int JSTYPE_STRING = 4;
    private const int JSTYPE_JAVA_CLASS = 5;
    private const int JSTYPE_JAVA_OBJECT = 6;
    private const int JSTYPE_JAVA_ARRAY = 7;
    private const int JSTYPE_OBJECT = 8;
    internal const byte CONVERSION_TRIVIAL = 1;
    internal const byte CONVERSION_NONTRIVIAL = 0;
    internal const byte CONVERSION_NONE = 99;
    protected internal Scriptable prototype;
    protected internal Scriptable parent;
    [NonSerialized]
    protected internal object javaObject;
    [Signature("Ljava/lang/Class<*>;")]
    [NonSerialized]
    protected internal Class staticType;
    [NonSerialized]
    internal JavaMembers __\u003C\u003Emembers;
    [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/FieldAndMethods;>;")]
    [NonSerialized]
    private Map fieldAndMethods;
    [NonSerialized]
    protected internal bool isAdapter;
    [Modifiers]
    private static object COERCED_INTERFACE_KEY;
    private static Method adapter_writeAdapterObject;
    private static Method adapter_readAdapterObject;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object unwrap() => this.javaObject;

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {161, 102, 113, 162, 223, 21, 104, 135, 162, 154, 134, 107, 197, 191, 8, 98, 109, 135, 135, 165, 109, 103, 109, 102, 102, 135, 109, 107, 172, 108, 123, 103, 136, 135, 165, 118, 103, 250, 70, 123, 159, 4, 104, 123, 103, 136, 135, 165, 104, 173, 154, 98, 109, 135, 135, 197, 104, 141, 104, 109, 135, 136, 109, 135, 105, 130, 103, 165, 109, 103, 104, 109, 135, 104, 105, 98, 149, 143, 109, 182, 104, 104, 104, 107, 137, 108, 37, 213, 2, 97, 231, 59, 232, 73, 99, 104, 109, 105, 98, 105, 223, 1, 141, 231, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object coerceTypeImpl([In] Class obj0, [In] object obj1)
    {
      if (obj1 != null && object.ReferenceEquals((object) Object.instancehelper_getClass(obj1), (object) obj0))
        return obj1;
      switch (NativeJavaObject.getJSTypeCode(obj1))
      {
        case 0:
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EStringClass) || object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EObjectClass))
            return (object) "undefined";
          NativeJavaObject.reportConversionError((object) "undefined", obj0);
          break;
        case 1:
          if (obj0.isPrimitive())
            NativeJavaObject.reportConversionError(obj1, obj0);
          return (object) null;
        case 2:
          if (object.ReferenceEquals((object) obj0, (object) Boolean.TYPE) || object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EBooleanClass) || object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EObjectClass))
            return obj1;
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return (object) Object.instancehelper_toString(obj1);
          NativeJavaObject.reportConversionError(obj1, obj0);
          break;
        case 3:
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return (object) ScriptRuntime.toString(obj1);
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EObjectClass))
          {
            Context currentContext = Context.getCurrentContext();
            return currentContext != null && currentContext.hasFeature(18) && (double) Math.round(NativeJavaObject.toDouble(obj1)) == NativeJavaObject.toDouble(obj1) ? NativeJavaObject.coerceToNumber((Class) Long.TYPE, obj1) : NativeJavaObject.coerceToNumber((Class) Double.TYPE, obj1);
          }
          if (obj0.isPrimitive() && !object.ReferenceEquals((object) obj0, (object) Boolean.TYPE) || ScriptRuntime.__\u003C\u003ENumberClass.isAssignableFrom(obj0))
            return NativeJavaObject.coerceToNumber(obj0, obj1);
          NativeJavaObject.reportConversionError(obj1, obj0);
          break;
        case 4:
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EStringClass) || obj0.isInstance(obj1))
            return (object) Object.instancehelper_toString(obj1);
          if (object.ReferenceEquals((object) obj0, (object) Character.TYPE) || object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003ECharacterClass))
          {
            object obj2 = obj1;
            CharSequence.Cast(obj2);
            object obj3 = obj2;
            CharSequence charSequence;
            charSequence.__\u003Cref\u003E = (__Null) obj3;
            if (((CharSequence) ref charSequence).length() != 1)
              return NativeJavaObject.coerceToNumber(obj0, obj1);
            object obj4 = obj1;
            CharSequence.Cast(obj4);
            int num = 0;
            object obj5 = obj4;
            charSequence.__\u003Cref\u003E = (__Null) obj5;
            return (object) Character.valueOf(((CharSequence) ref charSequence).charAt(num));
          }
          if (obj0.isPrimitive() && !object.ReferenceEquals((object) obj0, (object) Boolean.TYPE) || ScriptRuntime.__\u003C\u003ENumberClass.isAssignableFrom(obj0))
            return NativeJavaObject.coerceToNumber(obj0, obj1);
          NativeJavaObject.reportConversionError(obj1, obj0);
          break;
        case 5:
          if (obj1 is Wrapper)
            obj1 = ((Wrapper) obj1).unwrap();
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EClassClass) || object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EObjectClass))
            return obj1;
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return (object) Object.instancehelper_toString(obj1);
          NativeJavaObject.reportConversionError(obj1, obj0);
          break;
        case 6:
        case 7:
          if (obj1 is Wrapper)
            obj1 = ((Wrapper) obj1).unwrap();
          if (obj0.isPrimitive())
          {
            if (object.ReferenceEquals((object) obj0, (object) Boolean.TYPE))
              NativeJavaObject.reportConversionError(obj1, obj0);
            return NativeJavaObject.coerceToNumber(obj0, obj1);
          }
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return (object) Object.instancehelper_toString(obj1);
          if (obj0.isInstance(obj1))
            return obj1;
          NativeJavaObject.reportConversionError(obj1, obj0);
          break;
        case 8:
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return (object) ScriptRuntime.toString(obj1);
          if (obj0.isPrimitive())
          {
            if (object.ReferenceEquals((object) obj0, (object) Boolean.TYPE))
              NativeJavaObject.reportConversionError(obj1, obj0);
            return NativeJavaObject.coerceToNumber(obj0, obj1);
          }
          if (obj0.isInstance(obj1))
            return obj1;
          if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EDateClass) && obj1 is NativeDate)
            return (object) new Date(ByteCodeHelper.d2l(((NativeDate) obj1).getJSTimeValue()));
          if (obj0.isArray() && obj1 is NativeArray)
          {
            NativeArray nativeArray = (NativeArray) obj1;
            long length = nativeArray.getLength();
            Class componentType = obj0.getComponentType();
            object obj = Array.newInstance(componentType, (int) length);
            for (int index = 0; (long) index < length; ++index)
            {
              try
              {
                Array.set(obj, index, NativeJavaObject.coerceTypeImpl(componentType, nativeArray.get(index, (Scriptable) nativeArray)));
                continue;
              }
              catch (EvaluatorException ex)
              {
              }
              NativeJavaObject.reportConversionError(obj1, obj0);
            }
            return obj;
          }
          if (obj1 is Wrapper)
          {
            obj1 = ((Wrapper) obj1).unwrap();
            if (obj0.isInstance(obj1))
              return obj1;
            NativeJavaObject.reportConversionError(obj1, obj0);
            break;
          }
          if (obj0.isInterface())
          {
            switch (obj1)
            {
              case NativeObject _:
              case NativeFunction _:
              case ArrowFunction _:
                return NativeJavaObject.createInterfaceAdapter(obj0, (ScriptableObject) obj1);
            }
          }
          NativeJavaObject.reportConversionError(obj1, obj0);
          break;
      }
      return obj1;
    }

    [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)Z")]
    [LineNumberTable(new byte[] {160, 127, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool canConvert(object fromObj, Class to) => NativeJavaObject.getConversionWeight(fromObj, to) < 99;

    [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)I")]
    [LineNumberTable(new byte[] {160, 156, 135, 191, 16, 157, 226, 69, 107, 226, 70, 109, 98, 109, 98, 109, 98, 112, 226, 69, 104, 109, 98, 112, 169, 141, 99, 109, 99, 144, 226, 70, 109, 98, 105, 98, 107, 109, 98, 112, 226, 70, 109, 98, 109, 98, 112, 226, 70, 98, 104, 140, 105, 130, 109, 98, 123, 106, 38, 225, 71, 150, 130, 104, 203, 130, 109, 98, 109, 98, 109, 136, 130, 136, 136, 130, 104, 130, 99, 117, 233, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int getConversionWeight([In] object obj0, [In] Class obj1)
    {
      int jsTypeCode = NativeJavaObject.getJSTypeCode(obj0);
      switch (jsTypeCode)
      {
        case 0:
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EStringClass) || object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EObjectClass))
            return 1;
          break;
        case 1:
          if (!obj1.isPrimitive())
            return 1;
          break;
        case 2:
          if (object.ReferenceEquals((object) obj1, (object) Boolean.TYPE))
            return 1;
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EBooleanClass))
            return 2;
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EObjectClass))
            return 3;
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return 4;
          break;
        case 3:
          if (obj1.isPrimitive())
          {
            if (object.ReferenceEquals((object) obj1, (object) Double.TYPE))
              return 1;
            if (!object.ReferenceEquals((object) obj1, (object) Boolean.TYPE))
              return 1 + NativeJavaObject.getSizeRank(obj1);
            break;
          }
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return 9;
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EObjectClass))
            return 10;
          if (ScriptRuntime.__\u003C\u003ENumberClass.isAssignableFrom(obj1))
            return 2;
          break;
        case 4:
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return 1;
          if (obj1.isInstance(obj0))
            return 2;
          if (obj1.isPrimitive())
          {
            if (object.ReferenceEquals((object) obj1, (object) Character.TYPE))
              return 3;
            if (!object.ReferenceEquals((object) obj1, (object) Boolean.TYPE))
              return 4;
            break;
          }
          break;
        case 5:
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EClassClass))
            return 1;
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EObjectClass))
            return 3;
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return 4;
          break;
        case 6:
        case 7:
          object obj = obj0;
          if (obj is Wrapper)
            obj = ((Wrapper) obj).unwrap();
          if (obj1.isInstance(obj))
            return 0;
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return 2;
          if (obj1.isPrimitive() && !object.ReferenceEquals((object) obj1, (object) Boolean.TYPE) && jsTypeCode != 7)
            return 2 + NativeJavaObject.getSizeRank(obj1);
          break;
        case 8:
          if (!object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EObjectClass) && obj1.isInstance(obj0))
            return 1;
          if (obj1.isArray())
          {
            if (obj0 is NativeArray)
              return 2;
            break;
          }
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EObjectClass))
            return 3;
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EStringClass))
            return 4;
          if (object.ReferenceEquals((object) obj1, (object) ScriptRuntime.__\u003C\u003EDateClass))
          {
            if (obj0 is NativeDate)
              return 1;
            break;
          }
          if (obj1.isInterface())
          {
            switch (obj0)
            {
              case NativeFunction _:
                return 1;
              case NativeObject _:
                return 2;
              default:
                return 12;
            }
          }
          else
          {
            if (obj1.isPrimitive() && !object.ReferenceEquals((object) obj1, (object) Boolean.TYPE))
              return 4 + NativeJavaObject.getSizeRank(obj1);
            break;
          }
      }
      return 99;
    }

    [Signature("(Lrhino/Scriptable;Ljava/lang/Object;Ljava/lang/Class<*>;Z)V")]
    [LineNumberTable(new byte[] {159, 135, 67, 104, 103, 103, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaObject(Scriptable scope, object javaObject, Class staticType, bool isAdapter)
    {
      int num = isAdapter ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      NativeJavaObject nativeJavaObject = this;
      this.parent = scope;
      this.javaObject = javaObject;
      this.staticType = staticType;
      this.isAdapter = num != 0;
      this.initMembers();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPrototype(Scriptable m) => this.prototype = m;

    [LineNumberTable(new byte[] {159, 180, 104, 142, 135, 158, 111, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void initMembers()
    {
      this.__\u003C\u003Emembers = JavaMembers.lookupClass(this.parent, this.javaObject == null ? this.staticType : Object.instancehelper_getClass(this.javaObject), this.staticType, this.isAdapter);
      this.fieldAndMethods = this.__\u003C\u003Emembers.getFieldAndMethodsObjects((Scriptable) this, this.javaObject, false);
    }

    [LineNumberTable(new byte[] {16, 104, 109, 99, 226, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(string name, Scriptable start)
    {
      if (this.fieldAndMethods != null)
      {
        object obj = this.fieldAndMethods.get((object) name);
        if (obj != null)
          return obj;
      }
      return this.__\u003C\u003Emembers.get((Scriptable) this, name, this.javaObject, false);
    }

    [LineNumberTable(new byte[] {161, 55, 99, 98, 109, 98, 104, 98, 104, 98, 104, 98, 104, 104, 98, 104, 98, 104, 130, 130, 104, 130, 103, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getJSTypeCode([In] object obj0)
    {
      if (obj0 == null)
        return 1;
      if (object.ReferenceEquals(obj0, Undefined.__\u003C\u003Einstance))
        return 0;
      if (CharSequence.IsInstance(obj0))
        return 4;
      switch (obj0)
      {
        case Number _:
          return 3;
        case Boolean _:
          return 2;
        case Scriptable _:
          switch (obj0)
          {
            case NativeJavaClass _:
              return 5;
            case NativeJavaArray _:
              return 7;
            case Wrapper _:
              return 6;
            default:
              return 8;
          }
        case Class _:
          return 5;
        default:
          return Object.instancehelper_getClass(obj0).isArray() ? 7 : 6;
      }
    }

    [Signature("(Ljava/lang/Class<*>;)I")]
    [LineNumberTable(new byte[] {161, 33, 109, 98, 109, 98, 109, 98, 109, 98, 109, 98, 109, 98, 109, 98, 109, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int getSizeRank([In] Class obj0)
    {
      if (object.ReferenceEquals((object) obj0, (object) Double.TYPE))
        return 1;
      if (object.ReferenceEquals((object) obj0, (object) Float.TYPE))
        return 2;
      if (object.ReferenceEquals((object) obj0, (object) Long.TYPE))
        return 3;
      if (object.ReferenceEquals((object) obj0, (object) Integer.TYPE))
        return 4;
      if (object.ReferenceEquals((object) obj0, (object) Short.TYPE))
        return 5;
      if (object.ReferenceEquals((object) obj0, (object) Character.TYPE))
        return 6;
      if (object.ReferenceEquals((object) obj0, (object) Byte.TYPE))
        return 7;
      return object.ReferenceEquals((object) obj0, (object) Boolean.TYPE) ? 99 : 8;
    }

    [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {162, 182, 134, 102, 229, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void reportConversionError([In] object obj0, [In] Class obj1) => throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.conversion.not.allowed", (object) String.valueOf(obj0), (object) JavaMembers.javaSignature(obj1)));

    [LineNumberTable(new byte[] {162, 128, 104, 109, 104, 109, 104, 136, 146, 200, 191, 13, 2, 97, 130, 131, 127, 18, 129, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double toDouble([In] object obj0)
    {
      switch (obj0)
      {
        case Number _:
          return ((Number) obj0).doubleValue();
        case string _:
          return ScriptRuntime.toNumber((string) obj0);
        case Scriptable _:
          return obj0 is Wrapper ? NativeJavaObject.toDouble(((Wrapper) obj0).unwrap()) : ScriptRuntime.toNumber(obj0);
        default:
          Method method;
          try
          {
            try
            {
              method = Object.instancehelper_getClass(obj0).getMethod("doubleValue", (Class[]) null, NativeJavaObject.__\u003CGetCallerID\u003E());
              goto label_12;
            }
            catch (NoSuchMethodException ex)
            {
            }
          }
          catch (SecurityException ex)
          {
            goto label_10;
          }
          goto label_11;
label_10:
          null = null;
label_11:
          method = (Method) null;
label_12:
          if (method != null)
          {
            double num;
            try
            {
              try
              {
                num = ((Number) method.invoke(obj0, (object[]) null, NativeJavaObject.__\u003CGetCallerID\u003E())).doubleValue();
              }
              catch (IllegalAccessException ex)
              {
                goto label_17;
              }
            }
            catch (InvocationTargetException ex)
            {
              goto label_18;
            }
            return num;
label_17:
            goto label_19;
label_18:
            null = null;
label_19:
            NativeJavaObject.reportConversionError(obj0, (Class) Double.TYPE);
          }
          return ScriptRuntime.toNumber(Object.instancehelper_toString(obj0));
      }
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {162, 30, 167, 122, 109, 130, 255, 2, 71, 159, 8, 145, 11, 225, 69, 125, 109, 130, 105, 152, 168, 105, 108, 122, 108, 218, 232, 69, 122, 109, 130, 255, 5, 70, 122, 109, 226, 73, 114, 114, 243, 70, 122, 109, 130, 255, 6, 70, 122, 109, 130, 255, 6, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object coerceToNumber([In] Class obj0, [In] object obj1)
    {
      Class @class = Object.instancehelper_getClass(obj1);
      if (object.ReferenceEquals((object) obj0, (object) Character.TYPE) || object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003ECharacterClass))
        return object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003ECharacterClass) ? obj1 : (object) Character.valueOf((char) NativeJavaObject.toInteger(obj1, ScriptRuntime.__\u003C\u003ECharacterClass, 0.0, (double) ushort.MaxValue));
      if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EObjectClass) || object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EDoubleClass) || object.ReferenceEquals((object) obj0, (object) Double.TYPE))
        return object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EDoubleClass) ? obj1 : (object) Double.valueOf(NativeJavaObject.toDouble(obj1));
      if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EFloatClass) || object.ReferenceEquals((object) obj0, (object) Float.TYPE))
      {
        if (object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EFloatClass))
          return obj1;
        double num1 = NativeJavaObject.toDouble(obj1);
        if (Double.isInfinite(num1) || Double.isNaN(num1) || num1 == 0.0)
          return (object) Float.valueOf((float) num1);
        double num2 = Math.abs(num1);
        if (num2 < 1.40129846432482E-45)
          return (object) Float.valueOf(num1 <= 0.0 ? -0.0f : 0.0f);
        return num2 > 3.40282346638529E+38 ? (object) Float.valueOf(num1 <= 0.0 ? float.NegativeInfinity : float.PositiveInfinity) : (object) Float.valueOf((float) num1);
      }
      if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EIntegerClass) || object.ReferenceEquals((object) obj0, (object) Integer.TYPE))
        return object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EIntegerClass) ? obj1 : (object) Integer.valueOf((int) NativeJavaObject.toInteger(obj1, ScriptRuntime.__\u003C\u003EIntegerClass, (double) int.MinValue, (double) int.MaxValue));
      if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003ELongClass) || object.ReferenceEquals((object) obj0, (object) Long.TYPE))
      {
        if (object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003ELongClass))
          return obj1;
        DoubleConverter doubleConverter;
        double num1 = DoubleConverter.ToDouble(4890909195324358655L, ref doubleConverter);
        double num2 = DoubleConverter.ToDouble(-4332462841530417152L, ref doubleConverter);
        return (object) Long.valueOf(NativeJavaObject.toInteger(obj1, ScriptRuntime.__\u003C\u003ELongClass, num2, num1));
      }
      if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EShortClass) || object.ReferenceEquals((object) obj0, (object) Short.TYPE))
        return object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EShortClass) ? obj1 : (object) Short.valueOf((short) (int) NativeJavaObject.toInteger(obj1, ScriptRuntime.__\u003C\u003EShortClass, (double) short.MinValue, (double) short.MaxValue));
      if (!object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EByteClass) && !object.ReferenceEquals((object) obj0, (object) Byte.TYPE))
        return (object) Double.valueOf(NativeJavaObject.toDouble(obj1));
      return object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EByteClass) ? obj1 : (object) Byte.valueOf((byte) (int) NativeJavaObject.toInteger(obj1, ScriptRuntime.__\u003C\u003EByteClass, (double) sbyte.MinValue, (double) sbyte.MaxValue));
    }

    [Signature("(Ljava/lang/Class<*>;Lrhino/ScriptableObject;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {162, 16, 108, 104, 131, 130, 102, 137, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static object createInterfaceAdapter(Class type, ScriptableObject so)
    {
      object key = Kit.makeHashKeyFromPair(NativeJavaObject.COERCED_INTERFACE_KEY, (object) type);
      object associatedValue = so.getAssociatedValue(key);
      if (associatedValue != null)
        return associatedValue;
      object obj = InterfaceAdapter.create(Context.getContext(), type, so);
      return so.associateValue(key, obj);
    }

    [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;DD)J")]
    [LineNumberTable(new byte[] {162, 159, 137, 144, 172, 104, 139, 169, 138, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long toInteger([In] object obj0, [In] Class obj1, [In] double obj2, [In] double obj3)
    {
      double num1 = NativeJavaObject.toDouble(obj0);
      if (Double.isInfinite(num1) || Double.isNaN(num1))
        NativeJavaObject.reportConversionError((object) ScriptRuntime.toString(obj0), obj1);
      double num2 = num1 <= 0.0 ? Math.ceil(num1) : Math.floor(num1);
      if (num2 < obj2 || num2 > obj3)
        NativeJavaObject.reportConversionError((object) ScriptRuntime.toString(obj0), obj1);
      return ByteCodeHelper.d2l(num2);
    }

    [LineNumberTable(new byte[] {159, 161, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaObject()
    {
    }

    [Signature("(Lrhino/Scriptable;Ljava/lang/Object;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {159, 166, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaObject(Scriptable scope, object javaObject, Class staticType)
      : this(scope, javaObject, staticType, false)
    {
    }

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(string name, Scriptable start) => this.__\u003C\u003Emembers.has(name, false);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(int index, Scriptable start) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Symbol key, Scriptable start) => false;

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(Symbol key, Scriptable start) => Scriptable.NOT_FOUND;

    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int index, Scriptable start) => throw Throwable.__\u003Cunmap\u003E((Exception) this.__\u003C\u003Emembers.reportMemberNotFound(Integer.toString(index)));

    [LineNumberTable(new byte[] {43, 119, 151, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(string name, Scriptable start, object value)
    {
      if (this.prototype == null || this.__\u003C\u003Emembers.has(name, false))
        this.__\u003C\u003Emembers.put((Scriptable) this, name, this.javaObject, value, false);
      else
        this.prototype.put(name, this.prototype, value);
    }

    [LineNumberTable(new byte[] {54, 103, 119, 119, 109, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(Symbol symbol, Scriptable start, object value)
    {
      string str = Object.instancehelper_toString((object) symbol);
      if (this.prototype == null || this.__\u003C\u003Emembers.has(str, false))
      {
        this.__\u003C\u003Emembers.put((Scriptable) this, str, this.javaObject, value, false);
      }
      else
      {
        if (!(this.prototype is SymbolScriptable))
          return;
        ((SymbolScriptable) this.prototype).put(symbol, this.prototype, value);
      }
    }

    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(int index, Scriptable start, object value) => throw Throwable.__\u003Cunmap\u003E((Exception) this.__\u003C\u003Emembers.reportMemberNotFound(Integer.toString(index)));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasInstance(Scriptable value) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(string name)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(Symbol key)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void delete(int index)
    {
    }

    [LineNumberTable(new byte[] {87, 117, 102, 42, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getPrototype() => this.prototype == null && this.javaObject is string ? TopLevel.getBuiltinPrototype(ScriptableObject.getTopLevelScope(this.parent), TopLevel.Builtins.__\u003C\u003EString) : this.prototype;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getParentScope() => this.parent;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParentScope(Scriptable m) => this.parent = m;

    [LineNumberTable(171)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getIds() => this.__\u003C\u003Emembers.getIds(false);

    [Obsolete]
    [Signature("(Lrhino/Scriptable;Ljava/lang/Object;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {160, 67, 102})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object wrap(Scriptable scope, object obj, Class staticType)
    {
      Context context = Context.getContext();
      return context.getWrapFactory().wrap(context, scope, obj, staticType);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getClassName() => "JavaObject";

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {160, 84, 99, 109, 135, 109, 167, 112, 177, 109, 104, 109, 136, 144, 105, 104, 103, 152, 98, 154, 114, 118, 98, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getDefaultValue(Class hint)
    {
      if (hint == null)
      {
        if (this.javaObject is Boolean)
          hint = ScriptRuntime.__\u003C\u003EBooleanClass;
        if (this.javaObject is Number)
          hint = ScriptRuntime.__\u003C\u003ENumberClass;
      }
      object obj1;
      if (hint == null || object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003EStringClass))
      {
        obj1 = (object) Object.instancehelper_toString(this.javaObject);
      }
      else
      {
        string name;
        if (object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003EBooleanClass))
        {
          name = "booleanValue";
        }
        else
        {
          if (!object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003ENumberClass))
            throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.default.value"));
          name = "doubleValue";
        }
        object obj2 = this.get(name, (Scriptable) this);
        if (obj2 is Function)
        {
          Function function = (Function) obj2;
          obj1 = function.call(Context.getContext(), function.getParentScope(), (Scriptable) this, ScriptRuntime.__\u003C\u003EemptyArgs);
        }
        else
          obj1 = !object.ReferenceEquals((object) hint, (object) ScriptRuntime.__\u003C\u003ENumberClass) || !(this.javaObject is Boolean) ? (object) Object.instancehelper_toString(this.javaObject) : (object) ScriptRuntime.wrapNumber(!((Boolean) this.javaObject).booleanValue() ? 0.0 : 1.0);
      }
      return obj1;
    }

    [Obsolete]
    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;)Ljava/lang/Object;")]
    [LineNumberTable(464)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object coerceType(Class type, object value) => NativeJavaObject.coerceTypeImpl(type, value);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {162, 190, 134, 108, 107, 103, 139, 148, 191, 8, 2, 97, 139, 98, 172, 104, 147, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeObject([In] ObjectOutputStream obj0)
    {
      obj0.defaultWriteObject();
      obj0.writeBoolean(this.isAdapter);
      if (this.isAdapter)
      {
        if (NativeJavaObject.adapter_writeAdapterObject == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException();
        }
        object[] objArray = new object[2]
        {
          this.javaObject,
          (object) obj0
        };
        try
        {
          NativeJavaObject.adapter_writeAdapterObject.invoke((object) null, objArray, NativeJavaObject.__\u003CGetCallerID\u003E());
          goto label_9;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException();
      }
      obj0.writeObject(this.javaObject);
label_9:
      if (this.staticType != null)
        obj0.writeObject((object) this.staticType.getName());
      else
        obj0.writeObject((object) null);
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {162, 216, 134, 108, 107, 103, 107, 143, 191, 13, 2, 97, 139, 98, 172, 108, 99, 147, 167, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      this.isAdapter = obj0.readBoolean();
      if (this.isAdapter)
      {
        if (NativeJavaObject.adapter_readAdapterObject == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ClassNotFoundException();
        }
        object[] objArray = new object[2]
        {
          (object) this,
          (object) obj0
        };
        try
        {
          this.javaObject = NativeJavaObject.adapter_readAdapterObject.invoke((object) null, objArray, NativeJavaObject.__\u003CGetCallerID\u003E());
          goto label_9;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException();
      }
      this.javaObject = obj0.readObject();
label_9:
      string str = (string) obj0.readObject();
      this.staticType = str == null ? (Class) null : Class.forName(str, NativeJavaObject.__\u003CGetCallerID\u003E());
      this.initMembers();
    }

    [LineNumberTable(new byte[] {158, 177, 109, 234, 70, 103, 107, 134, 104, 109, 182, 104, 109, 255, 2, 70, 226, 61, 97, 102, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeJavaObject()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeJavaObject"))
        return;
      NativeJavaObject.COERCED_INTERFACE_KEY = (object) "Coerced Interface";
      Class[] classArray = new Class[2];
      Class @class = Kit.classOrNull("rhino.JavaAdapter");
      if (@class == null)
        return;
      try
      {
        classArray[0] = ScriptRuntime.__\u003C\u003EObjectClass;
        classArray[1] = Kit.classOrNull("java.io.ObjectOutputStream");
        NativeJavaObject.adapter_writeAdapterObject = @class.getMethod("writeAdapterObject", classArray, NativeJavaObject.__\u003CGetCallerID\u003E());
        classArray[0] = ScriptRuntime.__\u003C\u003EScriptableClass;
        classArray[1] = Kit.classOrNull("java.io.ObjectInputStream");
        NativeJavaObject.adapter_readAdapterObject = @class.getMethod("readAdapterObject", classArray, NativeJavaObject.__\u003CGetCallerID\u003E());
        return;
      }
      catch (NoSuchMethodException ex)
      {
      }
      NativeJavaObject.adapter_writeAdapterObject = (Method) null;
      NativeJavaObject.adapter_readAdapterObject = (Method) null;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (NativeJavaObject.__\u003CcallerID\u003E == null)
        NativeJavaObject.__\u003CcallerID\u003E = (CallerID) new NativeJavaObject.__\u003CCallerID\u003E();
      return NativeJavaObject.__\u003CcallerID\u003E;
    }

    [Modifiers]
    protected internal object members
    {
      [HideFromJava] get => (object) this.__\u003C\u003Emembers;
      [HideFromJava] [param: In] set => this.__\u003C\u003Emembers = (JavaMembers) value;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
