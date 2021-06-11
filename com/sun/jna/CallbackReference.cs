// Decompiled with JetBrains decompiler
// Type: com.sun.jna.CallbackReference
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using com.sun.jna.win32;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.@ref;
using java.lang.reflect;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace com.sun.jna
{
  [Signature("Ljava/lang/ref/WeakReference<Lcom/sun/jna/Callback;>;")]
  public class CallbackReference : WeakReference
  {
    [Modifiers]
    [Signature("Ljava/util/Map<Lcom/sun/jna/Callback;Lcom/sun/jna/CallbackReference;>;")]
    internal static Map callbackMap;
    [Modifiers]
    [Signature("Ljava/util/Map<Lcom/sun/jna/Callback;Lcom/sun/jna/CallbackReference;>;")]
    internal static Map directCallbackMap;
    [Modifiers]
    [Signature("Ljava/util/Map<Lcom/sun/jna/Pointer;Ljava/lang/ref/Reference<Lcom/sun/jna/Callback;>;>;")]
    internal static Map pointerCallbackMap;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Object;Ljava/lang/Object;>;")]
    internal static Map allocations;
    [Modifiers]
    [Signature("Ljava/util/Map<Lcom/sun/jna/CallbackReference;Ljava/lang/ref/Reference<Lcom/sun/jna/CallbackReference;>;>;")]
    private static Map allocatedMemory;
    [Modifiers]
    private static Method PROXY_CALLBACK_METHOD;
    [Modifiers]
    [Signature("Ljava/util/Map<Lcom/sun/jna/Callback;Lcom/sun/jna/CallbackThreadInitializer;>;")]
    private static Map initializers;
    internal Pointer cbstruct;
    internal Pointer trampoline;
    internal CallbackProxy proxy;
    internal Method method;
    internal int callingConvention;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {158, 222, 130, 99, 141, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Pointer getNativeString([In] object obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      if (obj0 == null)
        return (Pointer) null;
      NativeString nativeString = new NativeString(Object.instancehelper_toString(obj0), num != 0);
      CallbackReference.allocations.put(obj0, (object) nativeString);
      return nativeString.getPointer();
    }

    [LineNumberTable(406)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Callback getCallback() => (Callback) ((Reference) this).get();

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/Pointer;Z)Lcom/sun/jna/Callback;")]
    [LineNumberTable(new byte[] {159, 109, 162, 99, 162, 104, 112, 112, 108, 98, 113, 102, 109, 115, 255, 33, 69, 143, 148, 109, 115, 108, 159, 9, 105, 115, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Callback getCallback([In] Class obj0, [In] Pointer obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      if (obj1 == null)
        return (Callback) null;
      if (!obj0.isInterface())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Callback type must be an interface");
      }
      Map map = num1 == 0 ? CallbackReference.callbackMap : CallbackReference.directCallbackMap;
      Map pointerCallbackMap;
      Monitor.Enter((object) (pointerCallbackMap = CallbackReference.pointerCallbackMap));
      Callback callback1;
      // ISSUE: fault handler
      try
      {
        Reference reference = (Reference) CallbackReference.pointerCallbackMap.get((object) obj1);
        if (reference != null)
        {
          Callback callback2 = (Callback) reference.get();
          if (callback2 != null && !obj0.isAssignableFrom(Object.instancehelper_getClass((object) callback2)))
          {
            string str = new StringBuilder().append("Pointer ").append((object) obj1).append(" already mapped to ").append((object) callback2).append(".\nNative code may be re-using a default function pointer, in which case you may need to use a common Callback class wherever the function pointer is reused.").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
          }
          Callback callback3 = callback2;
          Monitor.Exit((object) pointerCallbackMap);
          callback1 = callback3;
          return callback1;
        }
        int num2 = !((Class) ClassLiteral<AltCallingConvention>.Value).isAssignableFrom(obj0) ? 0 : 63;
        HashMap hashMap = new HashMap(Native.getLibraryOptions(obj0));
        ((Map) hashMap).put((object) "invoking-method", (object) CallbackReference.getCallbackMethod(obj0));
        CallbackReference.NativeFunctionHandler nativeFunctionHandler = new CallbackReference.NativeFunctionHandler(obj1, num2, (Map) hashMap);
        Callback callback4 = (Callback) Proxy.newProxyInstance(obj0.getClassLoader(CallbackReference.__\u003CGetCallerID\u003E()), new Class[1]
        {
          obj0
        }, (InvocationHandler) nativeFunctionHandler, CallbackReference.__\u003CGetCallerID\u003E());
        map.remove((object) callback4);
        CallbackReference.pointerCallbackMap.put((object) obj1, (object) new WeakReference((object) callback4));
        Callback callback5 = callback4;
        Monitor.Exit((object) pointerCallbackMap);
        callback1 = callback5;
      }
      __fault
      {
        Monitor.Exit((object) pointerCallbackMap);
      }
      return callback1;
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/reflect/Method;")]
    [LineNumberTable(new byte[] {160, 222, 108, 108, 113, 173, 111, 109, 115, 134, 130, 120, 102, 138, 106, 103, 115, 232, 61, 232, 70, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Method getCallbackMethod([In] Class obj0)
    {
      Method[] declaredMethods = obj0.getDeclaredMethods(CallbackReference.__\u003CGetCallerID\u003E());
      Method[] methods = obj0.getMethods(CallbackReference.__\u003CGetCallerID\u003E());
      HashSet.__\u003Cclinit\u003E();
      HashSet hashSet = new HashSet((Collection) Arrays.asList((object[]) declaredMethods));
      ((Set) hashSet).retainAll((Collection) Arrays.asList((object[]) methods));
      Iterator iterator = ((Set) hashSet).iterator();
      while (iterator.hasNext())
      {
        Method method = (Method) iterator.next();
        if (Callback.FORBIDDEN_NAMES.contains((object) method.getName()))
          iterator.remove();
      }
      Method[] array = (Method[]) ((Set) hashSet).toArray((object[]) new Method[((Set) hashSet).size()]);
      if (array.Length == 1)
        return CallbackReference.checkMethod(array[0]);
      for (int index = 0; index < array.Length; ++index)
      {
        Method method = array[index];
        if (String.instancehelper_equals("callback", (object) method.getName()))
          return CallbackReference.checkMethod(method);
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException("Callback must implement a single public method, or one public method named 'callback'");
    }

    [LineNumberTable(331)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Method getCallbackMethod([In] Callback obj0) => CallbackReference.getCallbackMethod(CallbackReference.findCallbackClass(Object.instancehelper_getClass((object) obj0)));

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {160, 159, 141, 102, 109, 102, 109, 108, 223, 27, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Class getNativeType([In] Class obj0)
    {
      if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj0))
      {
        Structure.validate(obj0);
        if (!((Class) ClassLiteral<Structure.ByValue>.Value).isAssignableFrom(obj0))
          return (Class) ClassLiteral<Pointer>.Value;
      }
      else
      {
        if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(obj0))
          return NativeMappedConverter.getInstance(obj0).nativeType();
        if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<String>.Value) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<WString>.Value) || (object.ReferenceEquals((object) obj0, (object) ClassLiteral<string[]>.Value) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<WString[]>.Value)) || ((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj0))
          return (Class) ClassLiteral<Pointer>.Value;
      }
      return obj0;
    }

    [Signature("(Ljava/lang/Class<*>;)Z")]
    [LineNumberTable(new byte[] {162, 65, 255, 160, 184, 73, 109, 109, 235, 53})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isAllowableNativeType([In] Class obj0) => object.ReferenceEquals((object) obj0, (object) Void.TYPE) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<Void>.Value) || (object.ReferenceEquals((object) obj0, (object) Boolean.TYPE) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<Boolean>.Value)) || (object.ReferenceEquals((object) obj0, (object) Byte.TYPE) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<Byte>.Value) || (object.ReferenceEquals((object) obj0, (object) Short.TYPE) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<Short>.Value))) || (object.ReferenceEquals((object) obj0, (object) Character.TYPE) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<Character>.Value) || (object.ReferenceEquals((object) obj0, (object) Integer.TYPE) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<Integer>.Value)) || (object.ReferenceEquals((object) obj0, (object) Long.TYPE) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<Long>.Value) || (object.ReferenceEquals((object) obj0, (object) Float.TYPE) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<Float>.Value)))) || (object.ReferenceEquals((object) obj0, (object) Double.TYPE) || object.ReferenceEquals((object) obj0, (object) ClassLiteral<Double>.Value) || ((Class) ClassLiteral<Structure.ByValue>.Value).isAssignableFrom(obj0) && ((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj0) || ((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(obj0));

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {160, 191, 109, 159, 11, 104, 130, 103, 103, 175, 105, 146, 97, 226, 56, 230, 76, 114, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Class findCallbackClass([In] Class obj0)
    {
      if (!((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj0))
      {
        string str = new StringBuilder().append(obj0.getName()).append(" is not derived from com.sun.jna.Callback").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (obj0.isInterface())
        return obj0;
      Class[] interfaces = obj0.getInterfaces();
      for (int index = 0; index < interfaces.Length; ++index)
      {
        if (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(interfaces[index]))
        {
          Class @class;
          try
          {
            CallbackReference.getCallbackMethod(interfaces[index]);
            @class = interfaces[index];
          }
          catch (IllegalArgumentException ex)
          {
            goto label_10;
          }
          return @class;
label_10:
          break;
        }
      }
      return ((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj0.getSuperclass()) ? CallbackReference.findCallbackClass(obj0.getSuperclass()) : obj0;
    }

    [LineNumberTable(new byte[] {160, 177, 110, 155, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Method checkMethod([In] Method obj0)
    {
      if (obj0.getParameterTypes().Length > 256)
      {
        string str = new StringBuilder().append("Method signature exceeds the maximum parameter count: ").append((object) obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(str);
      }
      return obj0;
    }

    [LineNumberTable(new byte[] {161, 15, 136, 148, 109, 103, 15, 162, 130})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    protected internal virtual void dispose()
    {
      if (this.cbstruct == null)
        return;
      try
      {
        Native.freeNativeCallback(this.cbstruct.peer);
      }
      finally
      {
        this.cbstruct.peer = 0L;
        this.cbstruct = (Pointer) null;
        CallbackReference.allocatedMemory.remove((object) this);
      }
    }

    [LineNumberTable(new byte[] {159, 35, 162, 98, 99, 130, 106, 130, 108, 149, 109, 179, 113, 109, 111, 100, 106, 107, 120, 109, 168, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Pointer getFunctionPointer([In] Callback obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      if (obj0 == null)
        return (Pointer) null;
      Pointer nativeFunctionPointer;
      if ((nativeFunctionPointer = CallbackReference.getNativeFunctionPointer(obj0)) != null)
        return nativeFunctionPointer;
      Map libraryOptions = Native.getLibraryOptions(Object.instancehelper_getClass((object) obj0));
      int num2 = !(obj0 is AltCallingConvention) ? (libraryOptions == null || !libraryOptions.containsKey((object) "calling-convention") ? 0 : ((Integer) libraryOptions.get((object) "calling-convention")).intValue()) : 63;
      Map map = num1 == 0 ? CallbackReference.callbackMap : CallbackReference.directCallbackMap;
      Pointer trampoline;
      lock (CallbackReference.pointerCallbackMap)
      {
        CallbackReference callbackReference = (CallbackReference) map.get((object) obj0);
        if (callbackReference == null)
        {
          callbackReference = new CallbackReference(obj0, num2, num1 != 0);
          map.put((object) obj0, (object) callbackReference);
          CallbackReference.pointerCallbackMap.put((object) callbackReference.getTrampoline(), (object) new WeakReference((object) obj0));
          if (CallbackReference.initializers.containsKey((object) obj0))
            callbackReference.setCallbackOptions(1);
        }
        trampoline = callbackReference.getTrampoline();
      }
      return trampoline;
    }

    [LineNumberTable(new byte[] {161, 43, 109, 108, 104, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Pointer getNativeFunctionPointer([In] Callback obj0)
    {
      if (Proxy.isProxyClass(Object.instancehelper_getClass((object) obj0)))
      {
        InvocationHandler invocationHandler = Proxy.getInvocationHandler((object) obj0, CallbackReference.__\u003CGetCallerID\u003E());
        if (invocationHandler is CallbackReference.NativeFunctionHandler)
          return ((CallbackReference.NativeFunctionHandler) invocationHandler).getPointer();
      }
      return (Pointer) null;
    }

    [LineNumberTable(new byte[] {159, 99, 162, 105, 108, 231, 70, 102, 102, 104, 105, 141, 159, 6, 98, 162, 105, 103, 98, 226, 53, 241, 79, 102, 108, 194, 109, 99, 99, 108, 109, 109, 99, 104, 134, 215, 101, 104, 174, 149, 109, 237, 69, 102, 106, 109, 100, 236, 61, 238, 70, 106, 100, 169, 109, 112, 108, 159, 11, 243, 59, 241, 72, 106, 105, 159, 8, 147, 142, 251, 69, 118, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CallbackReference([In] Callback obj0, [In] int obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector((object) obj0);
      CallbackReference callbackReference = this;
      TypeMapper typeMapper = Native.getTypeMapper(Object.instancehelper_getClass((object) obj0));
      this.callingConvention = obj1;
      int num2 = Platform.isPPC() ? 1 : 0;
      if (num1 != 0)
      {
        Method callbackMethod = CallbackReference.getCallbackMethod(obj0);
        Class[] parameterTypes = callbackMethod.getParameterTypes();
        int index = 0;
        while (index < parameterTypes.Length)
        {
          if (num2 != 0 && (object.ReferenceEquals((object) parameterTypes[index], (object) Float.TYPE) || object.ReferenceEquals((object) parameterTypes[index], (object) Double.TYPE)))
          {
            num1 = 0;
            break;
          }
          if (typeMapper != null && typeMapper.getFromNativeConverter(parameterTypes[index]) != null)
          {
            num1 = 0;
            break;
          }
          ++index;
          GC.KeepAlive((object) this);
        }
        if (typeMapper != null && typeMapper.getToNativeConverter(callbackMethod.getReturnType()) != null)
          num1 = 0;
      }
      string stringEncoding = Native.getStringEncoding(Object.instancehelper_getClass((object) obj0));
      long nativeCallback;
      if (num1 != 0)
      {
        this.method = CallbackReference.getCallbackMethod(obj0);
        Class[] parameterTypes = this.method.getParameterTypes();
        Class returnType = this.method.getReturnType();
        int num3 = 1;
        if (obj0 is DLLCallback)
          num3 |= 2;
        nativeCallback = Native.createNativeCallback(obj0, this.method, parameterTypes, returnType, obj1, num3, stringEncoding);
      }
      else
      {
        this.proxy = !(obj0 is CallbackProxy) ? (CallbackProxy) new CallbackReference.DefaultCallbackProxy(this, CallbackReference.getCallbackMethod(obj0), typeMapper, stringEncoding) : (CallbackProxy) obj0;
        Class[] parameterTypes = this.proxy.getParameterTypes();
        Class c = this.proxy.getReturnType();
        if (typeMapper != null)
        {
          int index = 0;
          while (index < parameterTypes.Length)
          {
            FromNativeConverter fromNativeConverter = typeMapper.getFromNativeConverter(parameterTypes[index]);
            if (fromNativeConverter != null)
              parameterTypes[index] = fromNativeConverter.nativeType();
            ++index;
            GC.KeepAlive((object) this);
          }
          ToNativeConverter toNativeConverter = typeMapper.getToNativeConverter(c);
          if (toNativeConverter != null)
            c = toNativeConverter.nativeType();
        }
        int index1 = 0;
        while (index1 < parameterTypes.Length)
        {
          parameterTypes[index1] = this.getNativeType(parameterTypes[index1]);
          if (!CallbackReference.isAllowableNativeType(parameterTypes[index1]))
          {
            string str = new StringBuilder().append("Callback argument ").append((object) parameterTypes[index1]).append(" requires custom type conversion").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            IllegalArgumentException argumentException = new IllegalArgumentException(str);
            GC.KeepAlive((object) this);
            throw argumentException;
          }
          ++index1;
          GC.KeepAlive((object) this);
        }
        Class nativeType = this.getNativeType(c);
        if (!CallbackReference.isAllowableNativeType(nativeType))
        {
          string str = new StringBuilder().append("Callback return type ").append((object) nativeType).append(" requires custom type conversion").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          IllegalArgumentException argumentException = new IllegalArgumentException(str);
          GC.KeepAlive((object) this);
          throw argumentException;
        }
        int num3 = !(obj0 is DLLCallback) ? 0 : 2;
        nativeCallback = Native.createNativeCallback((Callback) this.proxy, CallbackReference.PROXY_CALLBACK_METHOD, parameterTypes, nativeType, obj1, num3, stringEncoding);
      }
      this.cbstruct = nativeCallback == 0L ? (Pointer) null : new Pointer(nativeCallback);
      CallbackReference.allocatedMemory.put((object) this, (object) new WeakReference((object) this));
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {161, 1, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer getTrampoline()
    {
      if (this.trampoline == null)
        this.trampoline = this.cbstruct.getPointer(0L);
      return this.trampoline;
    }

    [LineNumberTable(new byte[] {160, 252, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setCallbackOptions([In] int obj0) => this.cbstruct.setInt((long) Pointer.__\u003C\u003ESIZE, obj0);

    [LineNumberTable(new byte[] {28, 108, 99, 154, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static CallbackThreadInitializer setCallbackThreadInitializer(
      [In] Callback obj0,
      [In] CallbackThreadInitializer obj1)
    {
      Map initializers;
      Monitor.Enter((object) (initializers = CallbackReference.initializers));
      CallbackThreadInitializer threadInitializer1;
      // ISSUE: fault handler
      try
      {
        if (obj1 != null)
        {
          CallbackThreadInitializer threadInitializer2 = (CallbackThreadInitializer) CallbackReference.initializers.put((object) obj0, (object) obj1);
          Monitor.Exit((object) initializers);
          threadInitializer1 = threadInitializer2;
          return threadInitializer1;
        }
        CallbackThreadInitializer threadInitializer3 = (CallbackThreadInitializer) CallbackReference.initializers.remove((object) obj0);
        Monitor.Exit((object) initializers);
        threadInitializer1 = threadInitializer3;
      }
      __fault
      {
        Monitor.Exit((object) initializers);
      }
      return threadInitializer1;
    }

    [LineNumberTable(new byte[] {55, 98, 104, 141, 108, 113, 111, 98, 99, 104, 109, 109, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ThreadGroup initializeThread(
      [In] Callback obj0,
      [In] CallbackReference.AttachOptions obj1)
    {
      if (obj0 is CallbackReference.DefaultCallbackProxy)
        obj0 = ((CallbackReference.DefaultCallbackProxy) obj0).getCallback();
      CallbackThreadInitializer threadInitializer;
      lock (CallbackReference.initializers)
        threadInitializer = (CallbackThreadInitializer) CallbackReference.initializers.get((object) obj0);
      ThreadGroup threadGroup = (ThreadGroup) null;
      if (threadInitializer != null)
      {
        threadGroup = threadInitializer.getThreadGroup(obj0);
        obj1.name = threadInitializer.getName(obj0);
        obj1.daemon = threadInitializer.isDaemon(obj0);
        obj1.detach = threadInitializer.detach(obj0);
        obj1.write();
      }
      return threadGroup;
    }

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/Pointer;)Lcom/sun/jna/Callback;")]
    [LineNumberTable(131)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Callback getCallback(Class type, Pointer p) => CallbackReference.getCallback(type, p, false);

    [LineNumberTable(new byte[] {161, 10, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void finalize() => this.dispose();

    [HideFromJava]
    ~CallbackReference()
    {
      if (ByteCodeHelper.SkipFinalizer())
        return;
      try
      {
        this.finalize();
      }
      catch
      {
      }
    }

    [LineNumberTable(new byte[] {161, 29, 112, 123, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void disposeAll()
    {
      Iterator iterator = ((Collection) new LinkedList((Collection) CallbackReference.allocatedMemory.keySet())).iterator();
      while (iterator.hasNext())
        ((CallbackReference) iterator.next()).dispose();
    }

    [LineNumberTable(426)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pointer getFunctionPointer(Callback cb) => CallbackReference.getFunctionPointer(cb, false);

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Callback access\u0024000([In] CallbackReference obj0) => obj0.getCallback();

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Pointer access\u0024100([In] object obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      return CallbackReference.getNativeString(obj0, num != 0);
    }

    [LineNumberTable(new byte[] {159, 129, 77, 106, 106, 138, 138, 101, 234, 69, 191, 29, 2, 97, 208})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static CallbackReference()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.CallbackReference"))
        return;
      CallbackReference.callbackMap = (Map) new WeakHashMap();
      CallbackReference.directCallbackMap = (Map) new WeakHashMap();
      CallbackReference.pointerCallbackMap = (Map) new WeakHashMap();
      CallbackReference.allocations = (Map) new WeakHashMap();
      CallbackReference.allocatedMemory = Collections.synchronizedMap((Map) new WeakHashMap());
      try
      {
        CallbackReference.PROXY_CALLBACK_METHOD = ((Class) ClassLiteral<CallbackProxy>.Value).getMethod("callback", new Class[1]
        {
          (Class) ClassLiteral<object[]>.Value
        }, CallbackReference.__\u003CGetCallerID\u003E());
        goto label_7;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new Error("Error looking up CallbackProxy.callback() method");
label_7:
      CallbackReference.initializers = (Map) new WeakHashMap();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (CallbackReference.__\u003CcallerID\u003E == null)
        CallbackReference.__\u003CcallerID\u003E = (CallerID) new CallbackReference.__\u003CCallerID\u003E();
      return CallbackReference.__\u003CcallerID\u003E;
    }

    internal class AttachOptions : Structure
    {
      [Modifiers]
      [Signature("Ljava/util/List<Ljava/lang/String;>;")]
      public static List FIELDS;
      public bool daemon;
      public bool detach;
      public string name;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {37, 232, 71, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal AttachOptions()
      {
        CallbackReference.AttachOptions attachOptions = this;
        this.setStringEncoding("utf8");
      }

      [Signature("()Ljava/util/List<Ljava/lang/String;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override List getFieldOrder() => CallbackReference.AttachOptions.FIELDS;

      [LineNumberTable(88)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static AttachOptions()
      {
        Structure.__\u003Cclinit\u003E();
        if (ByteCodeHelper.isAlreadyInited("com.sun.jna.CallbackReference$AttachOptions"))
          return;
        CallbackReference.AttachOptions.FIELDS = Structure.createFieldsOrder(nameof (daemon), nameof (detach), nameof (name));
      }
    }

    [InnerClass]
    [Implements(new string[] {"com.sun.jna.CallbackProxy"})]
    internal class DefaultCallbackProxy : Object, CallbackProxy, Callback
    {
      [Modifiers]
      private Method callbackMethod;
      private ToNativeConverter toNative;
      [Modifiers]
      private FromNativeConverter[] fromNative;
      [Modifiers]
      private string encoding;
      [Modifiers]
      internal CallbackReference this\u00240;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;

      [LineNumberTable(496)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Callback getCallback() => CallbackReference.access\u0024000(this.this\u00240);

      [LineNumberTable(new byte[] {161, 95, 111, 103, 104, 103, 103, 109, 109, 142, 99, 141, 108, 111, 151, 99, 241, 59, 230, 72, 136, 210, 2, 97, 191, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DefaultCallbackProxy(
        [In] CallbackReference obj0,
        [In] Method obj1,
        [In] TypeMapper obj2,
        [In] string obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        CallbackReference.DefaultCallbackProxy defaultCallbackProxy = this;
        this.callbackMethod = obj1;
        this.encoding = obj3;
        Class[] parameterTypes = obj1.getParameterTypes();
        Class returnType = obj1.getReturnType();
        this.fromNative = new FromNativeConverter[parameterTypes.Length];
        if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(returnType))
          this.toNative = (ToNativeConverter) NativeMappedConverter.getInstance(returnType);
        else if (obj2 != null)
          this.toNative = obj2.getToNativeConverter(returnType);
        for (int index1 = 0; index1 < this.fromNative.Length; ++index1)
        {
          if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(parameterTypes[index1]))
          {
            FromNativeConverter[] fromNative = this.fromNative;
            int index2 = index1;
            NativeMappedConverter.__\u003Cclinit\u003E();
            NativeMappedConverter nativeMappedConverter = new NativeMappedConverter(parameterTypes[index1]);
            fromNative[index2] = (FromNativeConverter) nativeMappedConverter;
          }
          else if (obj2 != null)
            this.fromNative[index1] = obj2.getFromNativeConverter(parameterTypes[index1]);
        }
        if (!((AccessibleObject) obj1).isAccessible())
        {
          try
          {
            ((AccessibleObject) obj1).setAccessible(true);
            return;
          }
          catch (SecurityException ex)
          {
          }
          string str = new StringBuilder().append("Callback method is inaccessible, make sure the interface is public: ").append((object) obj1).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
      }

      [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
      [LineNumberTable(new byte[] {161, 193, 107, 109, 154, 109, 153, 109, 154, 109, 148, 109, 147, 176, 109, 103, 108, 113, 113, 102, 99, 98, 109, 102, 99, 162, 159, 3, 152})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object convertArgument([In] object obj0, [In] Class obj1)
      {
        if (obj0 is Pointer)
        {
          if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<String>.Value))
            obj0 = (object) ((Pointer) obj0).getString(0L, this.encoding);
          else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<WString>.Value))
            obj0 = (object) new WString(((Pointer) obj0).getWideString(0L));
          else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<string[]>.Value))
            obj0 = (object) ((Pointer) obj0).getStringArray(0L, this.encoding);
          else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<WString[]>.Value))
            obj0 = (object) ((Pointer) obj0).getWideStringArray(0L);
          else if (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj1))
            obj0 = (object) CallbackReference.getCallback(obj1, (Pointer) obj0);
          else if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj1))
          {
            if (((Class) ClassLiteral<Structure.ByValue>.Value).isAssignableFrom(obj1))
            {
              Structure structure = Structure.newInstance(obj1);
              byte[] buf = new byte[structure.size()];
              ((Pointer) obj0).read(0L, buf, 0, buf.Length);
              structure.getPointer().write(0L, buf, 0, buf.Length);
              structure.read();
              obj0 = (object) structure;
            }
            else
            {
              Structure structure = Structure.newInstance(obj1, (Pointer) obj0);
              structure.conditionalAutoRead();
              obj0 = (object) structure;
            }
          }
        }
        else if ((object.ReferenceEquals((object) Boolean.TYPE, (object) obj1) || object.ReferenceEquals((object) ClassLiteral<Boolean>.Value, (object) obj1)) && obj0 is Number)
          obj0 = (object) Function.valueOf(((Number) obj0).intValue() != 0);
        return obj0;
      }

      [LineNumberTable(new byte[] {161, 234, 104, 153, 99, 162, 103, 109, 109, 130, 108, 122, 154, 122, 120, 122, 223, 33, 109, 98, 109, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object convertResult([In] object obj0)
      {
        if (this.toNative != null)
          obj0 = this.toNative.toNative(obj0, (ToNativeContext) new CallbackResultContext(this.callbackMethod));
        if (obj0 == null)
          return (object) null;
        Class @class = Object.instancehelper_getClass(obj0);
        if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(@class))
          return ((Class) ClassLiteral<Structure.ByValue>.Value).isAssignableFrom(@class) ? obj0 : (object) ((Structure) obj0).getPointer();
        if (object.ReferenceEquals((object) @class, (object) Boolean.TYPE) || object.ReferenceEquals((object) @class, (object) ClassLiteral<Boolean>.Value))
          return ((Boolean) Boolean.TRUE).equals(obj0) ? (object) Function.INTEGER_TRUE : (object) Function.INTEGER_FALSE;
        if (object.ReferenceEquals((object) @class, (object) ClassLiteral<String>.Value) || object.ReferenceEquals((object) @class, (object) ClassLiteral<WString>.Value))
          return (object) CallbackReference.access\u0024100(obj0, object.ReferenceEquals((object) @class, (object) ClassLiteral<WString>.Value));
        if (object.ReferenceEquals((object) @class, (object) ClassLiteral<string[]>.Value) || object.ReferenceEquals((object) @class, (object) ClassLiteral<WString>.Value))
        {
          StringArray stringArray1;
          if (object.ReferenceEquals((object) @class, (object) ClassLiteral<string[]>.Value))
          {
            StringArray.__\u003Cclinit\u003E();
            stringArray1 = new StringArray((string[]) obj0, this.encoding);
          }
          else
          {
            StringArray.__\u003Cclinit\u003E();
            stringArray1 = new StringArray((WString[]) obj0);
          }
          StringArray stringArray2 = stringArray1;
          CallbackReference.allocations.put(obj0, (object) stringArray2);
          return (object) stringArray2;
        }
        return ((Class) ClassLiteral<Callback>.Value).isAssignableFrom(@class) ? (object) CallbackReference.getFunctionPointer((Callback) obj0) : obj0;
      }

      [LineNumberTable(new byte[] {161, 130, 108, 168, 106, 100, 101, 106, 144, 116, 98, 236, 56, 233, 76, 99, 104, 135, 255, 44, 74, 226, 56, 98, 238, 71, 226, 59, 98, 206, 2, 98, 211, 105, 150, 238, 61, 232, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object invokeCallback([In] object[] obj0)
      {
        Class[] parameterTypes = this.callbackMethod.getParameterTypes();
        object[] objArray = new object[obj0.Length];
        for (int index = 0; index < obj0.Length; ++index)
        {
          Class @class = parameterTypes[index];
          object obj = obj0[index];
          if (this.fromNative[index] != null)
          {
            CallbackParameterContext parameterContext = new CallbackParameterContext(@class, this.callbackMethod, obj0, index);
            objArray[index] = this.fromNative[index].fromNative(obj, (FromNativeContext) parameterContext);
          }
          else
            objArray[index] = this.convertArgument(obj, @class);
        }
        object obj1 = (object) null;
        Callback callback = this.getCallback();
        if (callback != null)
        {
          IllegalArgumentException argumentException1;
          IllegalAccessException illegalAccessException1;
          InvocationTargetException invocationTargetException1;
          try
          {
            try
            {
              try
              {
                obj1 = this.convertResult(this.callbackMethod.invoke((object) callback, objArray, CallbackReference.DefaultCallbackProxy.__\u003CGetCallerID\u003E()));
                goto label_14;
              }
              catch (IllegalArgumentException ex)
              {
                argumentException1 = (IllegalArgumentException) ByteCodeHelper.MapException<IllegalArgumentException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              }
            }
            catch (IllegalAccessException ex)
            {
              illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              goto label_12;
            }
          }
          catch (InvocationTargetException ex)
          {
            invocationTargetException1 = (InvocationTargetException) ByteCodeHelper.MapException<InvocationTargetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_13;
          }
          IllegalArgumentException argumentException2 = argumentException1;
          Native.getCallbackExceptionHandler().uncaughtException(callback, (Exception) argumentException2);
          goto label_14;
label_12:
          IllegalAccessException illegalAccessException2 = illegalAccessException1;
          Native.getCallbackExceptionHandler().uncaughtException(callback, (Exception) illegalAccessException2);
          goto label_14;
label_13:
          InvocationTargetException invocationTargetException2 = invocationTargetException1;
          Native.getCallbackExceptionHandler().uncaughtException(callback, invocationTargetException2.getTargetException());
        }
label_14:
        for (int index = 0; index < objArray.Length; ++index)
        {
          if (objArray[index] is Structure && !(objArray[index] is Structure.ByValue))
            ((Structure) objArray[index]).autoWrite();
        }
        return obj1;
      }

      [LineNumberTable(new byte[] {161, 181, 157, 97, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object callback([In] object[] obj0)
      {
        object obj;
        Exception exception;
        try
        {
          obj = this.invokeCallback(obj0);
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_3;
        }
        return obj;
label_3:
        Exception t = exception;
        Native.getCallbackExceptionHandler().uncaughtException(this.getCallback(), t);
        return (object) null;
      }

      [Signature("()[Ljava/lang/Class<*>;")]
      [LineNumberTable(636)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Class[] getParameterTypes() => this.callbackMethod.getParameterTypes();

      [Signature("()Ljava/lang/Class<*>;")]
      [LineNumberTable(640)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Class getReturnType() => this.callbackMethod.getReturnType();

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (CallbackReference.DefaultCallbackProxy.__\u003CcallerID\u003E == null)
          CallbackReference.DefaultCallbackProxy.__\u003CcallerID\u003E = (CallerID) new CallbackReference.DefaultCallbackProxy.__\u003CCallerID\u003E();
        return CallbackReference.DefaultCallbackProxy.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [InnerClass]
    internal class NativeFunctionHandler : Object, InvocationHandler
    {
      [Modifiers]
      private Function function;
      [Modifiers]
      [Signature("Ljava/util/Map<Ljava/lang/String;*>;")]
      private Map options;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;

      [Signature("(Lcom/sun/jna/Pointer;ILjava/util/Map<Ljava/lang/String;*>;)V")]
      [LineNumberTable(new byte[] {162, 26, 104, 103, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NativeFunctionHandler([In] Pointer obj0, [In] int obj1, [In] Map obj2)
      {
        CallbackReference.NativeFunctionHandler nativeFunctionHandler = this;
        this.options = obj2;
        Function.__\u003Cclinit\u003E();
        this.function = new Function(obj0, obj1, (string) obj2.get((object) "string-encoding"));
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Pointer getPointer() => (Pointer) this.function;

      [Throws(new string[] {"java.lang.Throwable"})]
      [LineNumberTable(new byte[] {162, 34, 112, 127, 1, 118, 108, 159, 17, 98, 109, 108, 109, 100, 112, 157, 134, 104, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object invoke([In] object obj0, [In] Method obj1, [In] object[] obj2)
      {
        if (Library.Handler.OBJECT_TOSTRING.equals((object) obj1))
        {
          string str = new StringBuilder().append("Proxy interface to ").append((object) this.function).toString();
          Class callbackClass = CallbackReference.findCallbackClass(((Method) this.options.get((object) "invoking-method")).getDeclaringClass());
          return (object) new StringBuilder().append(str).append(" (").append(callbackClass.getName()).append(")").toString();
        }
        if (Library.Handler.OBJECT_HASHCODE.equals((object) obj1))
          return (object) Integer.valueOf(Object.instancehelper_hashCode((object) this));
        if (Library.Handler.OBJECT_EQUALS.equals((object) obj1))
        {
          object obj = obj2[0];
          return obj != null && Proxy.isProxyClass(Object.instancehelper_getClass(obj)) ? (object) Function.valueOf(object.ReferenceEquals((object) Proxy.getInvocationHandler(obj, CallbackReference.NativeFunctionHandler.__\u003CGetCallerID\u003E()), (object) this)) : (object) Boolean.FALSE;
        }
        if (Function.isVarArgs(obj1))
          obj2 = Function.concatenateVarArgs(obj2);
        return this.function.invoke(obj1.getReturnType(), obj2, this.options);
      }

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (CallbackReference.NativeFunctionHandler.__\u003CcallerID\u003E == null)
          CallbackReference.NativeFunctionHandler.__\u003CcallerID\u003E = (CallerID) new CallbackReference.NativeFunctionHandler.__\u003CCallerID\u003E();
        return CallbackReference.NativeFunctionHandler.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
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
