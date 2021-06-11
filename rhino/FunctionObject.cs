// Decompiled with JetBrains decompiler
// Type: rhino.FunctionObject
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.lang.reflect;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class FunctionObject : BaseFunction
  {
    private const short VARARGS_METHOD = -1;
    private const short VARARGS_CTOR = -2;
    private static bool sawSecurityException;
    public const int JAVA_UNSUPPORTED_TYPE = 0;
    public const int JAVA_STRING_TYPE = 1;
    public const int JAVA_INT_TYPE = 2;
    public const int JAVA_BOOLEAN_TYPE = 3;
    public const int JAVA_DOUBLE_TYPE = 4;
    public const int JAVA_SCRIPTABLE_TYPE = 5;
    public const int JAVA_OBJECT_TYPE = 6;
    internal MemberBox member;
    [Modifiers]
    private string functionName;
    [NonSerialized]
    private byte[] typeTags;
    [Modifiers]
    private int parmsLength;
    [NonSerialized]
    private bool hasVoidReturn;
    [NonSerialized]
    private int returnTypeTag;
    [Modifiers]
    private bool isStatic;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Ljava/lang/Class<*>;)[Ljava/lang/reflect/Method;")]
    [LineNumberTable(new byte[] {160, 140, 194, 103, 215, 226, 61, 129, 134, 99, 140, 98, 103, 106, 114, 108, 134, 228, 58, 230, 73, 103, 99, 105, 102, 14, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Method[] getMethodList([In] Class obj0)
    {
      Method[] methodArray1 = (Method[]) null;
      try
      {
        if (!FunctionObject.sawSecurityException)
        {
          methodArray1 = obj0.getDeclaredMethods(FunctionObject.__\u003CGetCallerID\u003E());
          goto label_5;
        }
        else
          goto label_5;
      }
      catch (SecurityException ex)
      {
      }
      FunctionObject.sawSecurityException = true;
label_5:
      if (methodArray1 == null)
        methodArray1 = obj0.getMethods(FunctionObject.__\u003CGetCallerID\u003E());
      int length = 0;
      for (int index = 0; index < methodArray1.Length; ++index)
      {
        if (FunctionObject.sawSecurityException)
        {
          if (object.ReferenceEquals((object) methodArray1[index].getDeclaringClass(), (object) obj0))
            goto label_13;
        }
        else if (Modifier.isPublic(methodArray1[index].getModifiers()))
          goto label_13;
        methodArray1[index] = (Method) null;
        continue;
label_13:
        ++length;
      }
      Method[] methodArray2 = new Method[length];
      int num = 0;
      for (int index1 = 0; index1 < methodArray1.Length; ++index1)
      {
        if (methodArray1[index1] != null)
        {
          Method[] methodArray3 = methodArray2;
          int index2 = num;
          ++num;
          Method method = methodArray1[index1];
          methodArray3[index2] = method;
        }
      }
      return methodArray2;
    }

    [LineNumberTable(new byte[] {160, 117, 98, 105, 100, 113, 99, 135, 10, 203, 226, 56, 230, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Method findSingleMethod([In] Method[] obj0, [In] string obj1)
    {
      Method method1 = (Method) null;
      int index = 0;
      for (int length = obj0.Length; index != length; ++index)
      {
        Method method2 = obj0[index];
        if (method2 != null && String.instancehelper_equals(obj1, (object) method2.getName()))
          method1 = method1 == null ? method2 : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.no.overload", (object) obj1, (object) method2.getDeclaringClass().getName()));
      }
      return method1;
    }

    [LineNumberTable(new byte[] {23, 104, 104, 118, 137, 118, 145, 108, 103, 108, 99, 158, 109, 154, 191, 16, 177, 141, 191, 10, 159, 1, 177, 172, 103, 103, 108, 104, 107, 100, 105, 38, 171, 236, 58, 232, 75, 109, 109, 105, 110, 137, 141, 98, 109, 110, 103, 37, 235, 69, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FunctionObject(string name, Member methodOrConstructor, Scriptable scope)
    {
      FunctionObject functionObject = this;
      if (methodOrConstructor is Constructor)
      {
        MemberBox.__\u003Cclinit\u003E();
        this.member = new MemberBox((Constructor) methodOrConstructor);
        this.isStatic = true;
      }
      else
      {
        MemberBox.__\u003Cclinit\u003E();
        this.member = new MemberBox((Method) methodOrConstructor);
        this.isStatic = this.member.isStatic();
      }
      string name1 = this.member.getName();
      this.functionName = name;
      Class[] argTypes = this.member.argTypes;
      int length = argTypes.Length;
      if (length == 4 && (argTypes[1].isArray() || argTypes[2].isArray()))
      {
        if (argTypes[1].isArray())
        {
          if (!this.isStatic || !object.ReferenceEquals((object) argTypes[0], (object) ScriptRuntime.__\u003C\u003EContextClass) || (!object.ReferenceEquals((object) argTypes[1].getComponentType(), (object) ScriptRuntime.__\u003C\u003EObjectClass) || !object.ReferenceEquals((object) argTypes[2], (object) ScriptRuntime.__\u003C\u003EFunctionClass)) || !object.ReferenceEquals((object) argTypes[3], (object) Boolean.TYPE))
            throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.varargs.ctor", (object) name1));
          this.parmsLength = -2;
        }
        else
        {
          if (!this.isStatic || !object.ReferenceEquals((object) argTypes[0], (object) ScriptRuntime.__\u003C\u003EContextClass) || (!object.ReferenceEquals((object) argTypes[1], (object) ScriptRuntime.__\u003C\u003EScriptableClass) || !object.ReferenceEquals((object) argTypes[2].getComponentType(), (object) ScriptRuntime.__\u003C\u003EObjectClass)) || !object.ReferenceEquals((object) argTypes[3], (object) ScriptRuntime.__\u003C\u003EFunctionClass))
            throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.varargs.fun", (object) name1));
          this.parmsLength = -1;
        }
      }
      else
      {
        this.parmsLength = length;
        if (length > 0)
        {
          this.typeTags = new byte[length];
          for (int index = 0; index != length; ++index)
          {
            int typeTag = FunctionObject.getTypeTag(argTypes[index]);
            this.typeTags[index] = typeTag != 0 ? (byte) typeTag : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.bad.parms", (object) argTypes[index].getName(), (object) name1));
          }
        }
      }
      if (this.member.isMethod())
      {
        Class returnType = this.member.method().getReturnType();
        if (object.ReferenceEquals((object) returnType, (object) Void.TYPE))
          this.hasVoidReturn = true;
        else
          this.returnTypeTag = FunctionObject.getTypeTag(returnType);
      }
      else
      {
        Class declaringClass = this.member.getDeclaringClass();
        if (!ScriptRuntime.__\u003C\u003EScriptableClass.isAssignableFrom(declaringClass))
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.bad.ctor.return", (object) declaringClass.getName()));
      }
      ScriptRuntime.setFunctionProtoAndParent((BaseFunction) this, scope);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isVarArgsMethod() => this.parmsLength == -1;

    [LineNumberTable(new byte[] {160, 194, 103, 135, 135, 205, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void initAsConstructor([In] Scriptable obj0, [In] Scriptable obj1)
    {
      ScriptRuntime.setFunctionProtoAndParent((BaseFunction) this, obj0);
      this.setImmunePrototypeProperty((object) obj1);
      obj1.setParentScope((Scriptable) this);
      ScriptableObject.defineProperty(obj1, "constructor", (object) this, 7);
      this.setParentScope(obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isVarArgsConstructor() => this.parmsLength == -2;

    [Signature("(Ljava/lang/Class<*>;)I")]
    [LineNumberTable(new byte[] {98, 109, 98, 122, 98, 122, 98, 122, 98, 109, 98, 109, 226, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getTypeTag(Class type)
    {
      if (object.ReferenceEquals((object) type, (object) ScriptRuntime.__\u003C\u003EStringClass))
        return 1;
      if (object.ReferenceEquals((object) type, (object) ScriptRuntime.__\u003C\u003EIntegerClass) || object.ReferenceEquals((object) type, (object) Integer.TYPE))
        return 2;
      if (object.ReferenceEquals((object) type, (object) ScriptRuntime.__\u003C\u003EBooleanClass) || object.ReferenceEquals((object) type, (object) Boolean.TYPE))
        return 3;
      if (object.ReferenceEquals((object) type, (object) ScriptRuntime.__\u003C\u003EDoubleClass) || object.ReferenceEquals((object) type, (object) Double.TYPE))
        return 4;
      if (ScriptRuntime.__\u003C\u003EScriptableClass.isAssignableFrom(type))
        return 5;
      return object.ReferenceEquals((object) type, (object) ScriptRuntime.__\u003C\u003EObjectClass) ? 6 : 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getArity() => this.parmsLength < 0 ? 1 : this.parmsLength;

    [LineNumberTable(new byte[] {119, 159, 3, 104, 98, 135, 104, 98, 140, 104, 98, 181, 104, 98, 141, 137, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object convertArg(Context cx, Scriptable scope, object arg, int typeTag)
    {
      switch (typeTag)
      {
        case 1:
          return arg is string ? arg : (object) ScriptRuntime.toString(arg);
        case 2:
          return arg is Integer ? arg : (object) Integer.valueOf(ScriptRuntime.toInt32(arg));
        case 3:
          if (arg is Boolean)
            return arg;
          return ScriptRuntime.toBoolean(arg) ? (object) Boolean.TRUE : (object) Boolean.FALSE;
        case 4:
          return arg is Double ? arg : (object) Double.valueOf(ScriptRuntime.toNumber(arg));
        case 5:
          return (object) ScriptRuntime.toObjectOrNull(cx, arg, scope);
        case 6:
          return arg;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
      }
    }

    [LineNumberTable(211)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getLength() => this.getArity();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getFunctionName() => this.functionName == null ? "" : this.functionName;

    [LineNumberTable(new byte[] {160, 109, 109, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Member getMethodOrConstructor() => this.member.isMethod() ? (Member) this.member.method() : (Member) this.member.ctor();

    [LineNumberTable(new byte[] {160, 188, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAsConstructor(Scriptable scope, Scriptable prototype)
    {
      this.initAsConstructor(scope, prototype);
      ScriptableObject.defineProperty(scope, prototype.getClassName(), (object) this, 2);
    }

    [Obsolete]
    [Signature("(Lrhino/Context;Lrhino/Scriptable;Ljava/lang/Object;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {160, 214, 103, 99, 102, 144})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object convertArg(Context cx, Scriptable scope, object arg, Class desired)
    {
      int typeTag = FunctionObject.getTypeTag(desired);
      if (typeTag == 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.cant.convert", (object) desired.getName()));
      return FunctionObject.convertArg(cx, scope, arg, typeTag);
    }

    [LineNumberTable(new byte[] {160, 234, 98, 132, 134, 107, 237, 61, 230, 71, 108, 105, 120, 111, 98, 101, 104, 113, 122, 117, 112, 103, 165, 107, 109, 106, 99, 105, 104, 170, 107, 100, 196, 132, 246, 71, 172, 99, 109, 103, 116, 107, 106, 141, 230, 57, 237, 74, 104, 136, 108, 109, 179, 246, 60, 232, 72, 109, 111, 132, 238, 69, 99, 104, 105, 104, 242, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args)
    {
      int num1 = 0;
      int length = args.Length;
      for (int index = 0; index < length; ++index)
      {
        if (args[index] is ConsString)
          args[index] = (object) Object.instancehelper_toString(args[index]);
      }
      object obj1;
      if (this.parmsLength < 0)
      {
        if (this.parmsLength == -1)
        {
          obj1 = this.member.invoke((object) null, new object[4]
          {
            (object) cx,
            (object) thisObj,
            (object) args,
            (object) this
          });
          num1 = 1;
        }
        else
        {
          Boolean boolean = (thisObj != null ? 0 : 1) == 0 ? (Boolean) Boolean.FALSE : (Boolean) Boolean.TRUE;
          object[] objArray = new object[4]
          {
            (object) cx,
            (object) args,
            (object) this,
            (object) boolean
          };
          obj1 = !this.member.isCtor() ? this.member.invoke((object) null, objArray) : this.member.newInstance(objArray);
        }
      }
      else
      {
        if (!this.isStatic)
        {
          Class declaringClass = this.member.getDeclaringClass();
          if (!declaringClass.isInstance((object) thisObj))
          {
            int num2 = 0;
            if (object.ReferenceEquals((object) thisObj, (object) scope))
            {
              Scriptable parentScope = this.getParentScope();
              if (!object.ReferenceEquals((object) scope, (object) parentScope))
              {
                num2 = declaringClass.isInstance((object) parentScope) ? 1 : 0;
                if (num2 != 0)
                  thisObj = parentScope;
              }
            }
            if (num2 == 0)
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.incompat.call", (object) this.functionName));
          }
        }
        object[] objArray;
        if (this.parmsLength == length)
        {
          objArray = args;
          for (int index = 0; index != this.parmsLength; ++index)
          {
            object objA = args[index];
            object objB = FunctionObject.convertArg(cx, scope, objA, (int) (sbyte) this.typeTags[index]);
            if (!object.ReferenceEquals(objA, objB))
            {
              if (object.ReferenceEquals((object) objArray, (object) args))
                objArray = (object[]) args.Clone();
              objArray[index] = objB;
            }
          }
        }
        else if (this.parmsLength == 0)
        {
          objArray = ScriptRuntime.__\u003C\u003EemptyArgs;
        }
        else
        {
          objArray = new object[this.parmsLength];
          for (int index = 0; index != this.parmsLength; ++index)
          {
            object obj2 = index >= length ? Undefined.__\u003C\u003Einstance : args[index];
            objArray[index] = FunctionObject.convertArg(cx, scope, obj2, (int) (sbyte) this.typeTags[index]);
          }
        }
        if (this.member.isMethod())
        {
          obj1 = this.member.invoke((object) thisObj, objArray);
          num1 = 1;
        }
        else
          obj1 = this.member.newInstance(objArray);
      }
      if (num1 != 0)
      {
        if (this.hasVoidReturn)
          obj1 = Undefined.__\u003C\u003Einstance;
        else if (this.returnTypeTag == 0)
          obj1 = cx.getWrapFactory().wrap(cx, scope, obj1, (Class) null);
      }
      return obj1;
    }

    [LineNumberTable(new byte[] {161, 85, 119, 194, 191, 19, 2, 97, 172, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scriptable createObject(Context cx, Scriptable scope)
    {
      if (!this.member.isCtor())
      {
        if (this.parmsLength != -2)
        {
          Scriptable scriptable;
          Exception exception;
          try
          {
            scriptable = (Scriptable) this.member.getDeclaringClass().newInstance(FunctionObject.__\u003CGetCallerID\u003E());
            goto label_8;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception = (Exception) m0;
          }
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) exception));
label_8:
          scriptable.setPrototype(this.getClassPrototype());
          scriptable.setParentScope(this.getParentScope());
          return scriptable;
        }
      }
      return (Scriptable) null;
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {161, 110, 102, 105, 108, 113, 107, 49, 198, 109, 108, 103, 109, 137, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      if (this.parmsLength > 0)
      {
        Class[] argTypes = this.member.argTypes;
        this.typeTags = new byte[this.parmsLength];
        for (int index = 0; index != this.parmsLength; ++index)
          this.typeTags[index] = (byte) FunctionObject.getTypeTag(argTypes[index]);
      }
      if (!this.member.isMethod())
        return;
      Class returnType = this.member.method().getReturnType();
      if (object.ReferenceEquals((object) returnType, (object) Void.TYPE))
        this.hasVoidReturn = true;
      else
        this.returnTypeTag = FunctionObject.getTypeTag(returnType);
    }

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (FunctionObject.__\u003CcallerID\u003E == null)
        FunctionObject.__\u003CcallerID\u003E = (CallerID) new FunctionObject.__\u003CCallerID\u003E();
      return FunctionObject.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    static FunctionObject() => BaseFunction.__\u003Cclinit\u003E();

    private new sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
