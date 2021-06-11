// Decompiled with JetBrains decompiler
// Type: com.sun.jna.Library
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

namespace com.sun.jna
{
  public interface Library
  {
    const string OPTION_TYPE_MAPPER = "type-mapper";
    const string OPTION_FUNCTION_MAPPER = "function-mapper";
    const string OPTION_INVOCATION_MAPPER = "invocation-mapper";
    const string OPTION_STRUCTURE_ALIGNMENT = "structure-alignment";
    const string OPTION_STRING_ENCODING = "string-encoding";
    const string OPTION_ALLOW_OBJECTS = "allow-objects";
    const string OPTION_CALLING_CONVENTION = "calling-convention";
    const string OPTION_OPEN_FLAGS = "open-flags";
    const string OPTION_CLASSLOADER = "classloader";

    class Handler : Object, InvocationHandler
    {
      [Modifiers]
      internal static Method OBJECT_TOSTRING;
      [Modifiers]
      internal static Method OBJECT_HASHCODE;
      [Modifiers]
      internal static Method OBJECT_EQUALS;
      [Modifiers]
      private NativeLibrary nativeLibrary;
      [Modifiers]
      [Signature("Ljava/lang/Class<*>;")]
      private Class interfaceClass;
      [Modifiers]
      [Signature("Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;")]
      private Map options;
      [Modifiers]
      private InvocationMapper invocationMapper;
      [Modifiers]
      [Signature("Ljava/util/Map<Ljava/lang/reflect/Method;Lcom/sun/jna/Library$Handler$FunctionInfo;>;")]
      private Map functions;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(Ljava/lang/String;Ljava/lang/Class<*>;Ljava/util/Map<Ljava/lang/String;*>;)V")]
      [LineNumberTable(new byte[] {108, 40, 171, 117, 191, 16, 104, 191, 17, 103, 108, 179, 114, 151, 114, 156, 114, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Handler(string libname, Class interfaceClass, Map options)
      {
        Library.Handler handler = this;
        this.functions = (Map) new WeakHashMap();
        if (libname != null && String.instancehelper_equals("", (object) String.instancehelper_trim(libname)))
        {
          string str = new StringBuilder().append("Invalid library name \"").append(libname).append("\"").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
        if (!interfaceClass.isInterface())
        {
          string str = new StringBuilder().append(libname).append(" does not implement an interface: ").append(interfaceClass.getName()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
        this.interfaceClass = interfaceClass;
        this.options = (Map) new HashMap(options);
        int num = !((Class) ClassLiteral<AltCallingConvention>.Value).isAssignableFrom(interfaceClass) ? 0 : 63;
        if (this.options.get((object) "calling-convention") == null)
          this.options.put((object) "calling-convention", (object) Integer.valueOf(num));
        if (this.options.get((object) "classloader") == null)
          this.options.put((object) "classloader", (object) interfaceClass.getClassLoader(Library.Handler.__\u003CGetCallerID\u003E()));
        this.nativeLibrary = NativeLibrary.getInstance(libname, this.options);
        this.invocationMapper = (InvocationMapper) this.options.get((object) "invocation-mapper");
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual NativeLibrary getNativeLibrary() => this.nativeLibrary;

      [LineNumberTable(188)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getLibraryName() => this.nativeLibrary.getName();

      [Signature("()Ljava/lang/Class<*>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Class getInterfaceClass() => this.interfaceClass;

      [Throws(new string[] {"java.lang.Throwable"})]
      [LineNumberTable(new byte[] {160, 86, 109, 127, 1, 109, 108, 109, 100, 112, 157, 198, 114, 102, 109, 114, 102, 103, 99, 104, 148, 99, 99, 99, 132, 116, 104, 109, 142, 111, 142, 143, 104, 136, 104, 143})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object invoke(object proxy, Method method, object[] inArgs)
      {
        if (Library.Handler.OBJECT_TOSTRING.equals((object) method))
          return (object) new StringBuilder().append("Proxy interface to ").append((object) this.nativeLibrary).toString();
        if (Library.Handler.OBJECT_HASHCODE.equals((object) method))
          return (object) Integer.valueOf(Object.instancehelper_hashCode((object) this));
        if (Library.Handler.OBJECT_EQUALS.equals((object) method))
        {
          object inArg = inArgs[0];
          return inArg != null && Proxy.isProxyClass(Object.instancehelper_getClass(inArg)) ? (object) Function.valueOf(object.ReferenceEquals((object) Proxy.getInvocationHandler(inArg, Library.Handler.__\u003CGetCallerID\u003E()), (object) this)) : (object) Boolean.FALSE;
        }
        Library.Handler.FunctionInfo functionInfo = (Library.Handler.FunctionInfo) this.functions.get((object) method);
        if (functionInfo == null)
        {
          lock (this.functions)
          {
            functionInfo = (Library.Handler.FunctionInfo) this.functions.get((object) method);
            if (functionInfo == null)
            {
              int num = Function.isVarArgs(method) ? 1 : 0;
              InvocationHandler invocationHandler = (InvocationHandler) null;
              if (this.invocationMapper != null)
                invocationHandler = this.invocationMapper.getInvocationHandler(this.nativeLibrary, method);
              Function function = (Function) null;
              Class[] classArray = (Class[]) null;
              HashMap hashMap = (HashMap) null;
              if (invocationHandler == null)
              {
                function = this.nativeLibrary.getFunction(method.getName(), method);
                classArray = method.getParameterTypes();
                hashMap = new HashMap(this.options);
                ((Map) hashMap).put((object) "invoking-method", (object) method);
              }
              functionInfo = new Library.Handler.FunctionInfo(invocationHandler, function, classArray, num != 0, (Map) hashMap);
              this.functions.put((object) method, (object) functionInfo);
            }
          }
        }
        if (functionInfo.isVarArgs)
          inArgs = Function.concatenateVarArgs(inArgs);
        return functionInfo.handler != null ? functionInfo.handler.invoke(proxy, method, inArgs) : functionInfo.function.invoke(method, functionInfo.parameterTypes, method.getReturnType(), inArgs, functionInfo.options);
      }

      [LineNumberTable(new byte[] {159, 112, 173, 127, 0, 127, 0, 191, 29, 2, 97, 144})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Handler()
      {
        if (!ByteCodeHelper.isAlreadyInited("com.sun.jna.Library$Handler"))
        {
          try
          {
            Library.Handler.OBJECT_TOSTRING = ((Class) ClassLiteral<Object>.Value).getMethod("toString", new Class[0], Library.Handler.__\u003CGetCallerID\u003E());
            Library.Handler.OBJECT_HASHCODE = ((Class) ClassLiteral<Object>.Value).getMethod("hashCode", new Class[0], Library.Handler.__\u003CGetCallerID\u003E());
            Library.Handler.OBJECT_EQUALS = ((Class) ClassLiteral<Object>.Value).getMethod("equals", new Class[1]
            {
              (Class) ClassLiteral<Object>.Value
            }, Library.Handler.__\u003CGetCallerID\u003E());
            return;
          }
          catch (Exception ex)
          {
            if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
              throw;
          }
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new Error("Error retrieving Object.toString() method");
        }
      }

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (Library.Handler.__\u003CcallerID\u003E == null)
          Library.Handler.__\u003CcallerID\u003E = (CallerID) new Library.Handler.__\u003CCallerID\u003E();
        return Library.Handler.__\u003CcallerID\u003E;
      }

      [InnerClass]
      internal sealed class FunctionInfo : Object
      {
        [Modifiers]
        internal InvocationHandler handler;
        [Modifiers]
        internal Function function;
        [Modifiers]
        internal bool isVarArgs;
        [Modifiers]
        [Signature("Ljava/util/Map<Ljava/lang/String;*>;")]
        internal Map options;
        [Modifiers]
        [Signature("[Ljava/lang/Class<*>;")]
        internal Class[] parameterTypes;

        [Signature("(Ljava/lang/reflect/InvocationHandler;Lcom/sun/jna/Function;[Ljava/lang/Class<*>;ZLjava/util/Map<Ljava/lang/String;*>;)V")]
        [LineNumberTable(new byte[] {159, 107, 163, 104, 103, 103, 103, 104, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal FunctionInfo(
          [In] InvocationHandler obj0,
          [In] Function obj1,
          [In] Class[] obj2,
          [In] bool obj3,
          [In] Map obj4)
        {
          int num = obj3 ? 1 : 0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          Library.Handler.FunctionInfo functionInfo = this;
          this.handler = obj0;
          this.function = obj1;
          this.isVarArgs = num != 0;
          this.options = obj4;
          this.parameterTypes = obj2;
        }
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [HideFromJava]
    static class __Fields
    {
      public const string OPTION_TYPE_MAPPER = "type-mapper";
      public const string OPTION_FUNCTION_MAPPER = "function-mapper";
      public const string OPTION_INVOCATION_MAPPER = "invocation-mapper";
      public const string OPTION_STRUCTURE_ALIGNMENT = "structure-alignment";
      public const string OPTION_STRING_ENCODING = "string-encoding";
      public const string OPTION_ALLOW_OBJECTS = "allow-objects";
      public const string OPTION_CALLING_CONVENTION = "calling-convention";
      public const string OPTION_OPEN_FLAGS = "open-flags";
      public const string OPTION_CLASSLOADER = "classloader";
    }
  }
}
