// Decompiled with JetBrains decompiler
// Type: com.sun.jna.Native
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.awt;
using java.io;
using java.lang;
using java.lang.@ref;
using java.lang.reflect;
using java.net;
using java.nio;
using java.nio.charset;
using java.security;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace com.sun.jna
{
  public sealed class Native : Object, Version
  {
    internal static string __\u003C\u003EDEFAULT_ENCODING;
    public static bool DEBUG_LOAD;
    public static bool DEBUG_JNA_LOAD;
    internal static string jnidispatchPath;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Class<*>;Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;>;")]
    private static Map typeOptions;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Class<*>;Ljava/lang/ref/Reference<*>;>;")]
    private static Map libraries;
    private const string _OPTION_ENCLOSING_LIBRARY = "enclosing-library";
    [Modifiers]
    private static Callback.UncaughtExceptionHandler DEFAULT_HANDLER;
    private static Callback.UncaughtExceptionHandler callbackExceptionHandler;
    internal static int __\u003C\u003EPOINTER_SIZE;
    internal static int __\u003C\u003ELONG_SIZE;
    internal static int __\u003C\u003EWCHAR_SIZE;
    internal static int __\u003C\u003ESIZE_T_SIZE;
    internal static int __\u003C\u003EBOOL_SIZE;
    private const int TYPE_VOIDP = 0;
    private const int TYPE_LONG = 1;
    private const int TYPE_WCHAR_T = 2;
    private const int TYPE_SIZE_T = 3;
    private const int TYPE_BOOL = 4;
    [Modifiers]
    internal static int MAX_ALIGNMENT;
    [Modifiers]
    internal static int MAX_PADDING;
    [Modifiers]
    private static object finalizer;
    internal const string JNA_TMPLIB_PREFIX = "jna";
    [Signature("Ljava/util/Map<Ljava/lang/Class<*>;[J>;")]
    private static Map registeredClasses;
    [Signature("Ljava/util/Map<Ljava/lang/Class<*>;Lcom/sun/jna/NativeLibrary;>;")]
    private static Map registeredLibraries;
    internal const int CB_HAS_INITIALIZER = 1;
    private const int CVT_UNSUPPORTED = -1;
    private const int CVT_DEFAULT = 0;
    private const int CVT_POINTER = 1;
    private const int CVT_STRING = 2;
    private const int CVT_STRUCTURE = 3;
    private const int CVT_STRUCTURE_BYVAL = 4;
    private const int CVT_BUFFER = 5;
    private const int CVT_ARRAY_BYTE = 6;
    private const int CVT_ARRAY_SHORT = 7;
    private const int CVT_ARRAY_CHAR = 8;
    private const int CVT_ARRAY_INT = 9;
    private const int CVT_ARRAY_LONG = 10;
    private const int CVT_ARRAY_FLOAT = 11;
    private const int CVT_ARRAY_DOUBLE = 12;
    private const int CVT_ARRAY_BOOLEAN = 13;
    private const int CVT_BOOLEAN = 14;
    private const int CVT_CALLBACK = 15;
    private const int CVT_FLOAT = 16;
    private const int CVT_NATIVE_MAPPED = 17;
    private const int CVT_NATIVE_MAPPED_STRING = 18;
    private const int CVT_NATIVE_MAPPED_WSTRING = 19;
    private const int CVT_WSTRING = 20;
    private const int CVT_INTEGER_TYPE = 21;
    private const int CVT_POINTER_TYPE = 22;
    private const int CVT_TYPE_MAPPER = 23;
    private const int CVT_TYPE_MAPPER_STRING = 24;
    private const int CVT_TYPE_MAPPER_WSTRING = 25;
    internal const int CB_OPTION_DIRECT = 1;
    internal const int CB_OPTION_IN_DLL = 2;
    [Modifiers]
    [Signature("Ljava/lang/ThreadLocal<Lcom/sun/jna/Memory;>;")]
    private static ThreadLocal nativeThreadTerminationFlag;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Thread;Lcom/sun/jna/Pointer;>;")]
    private static Map nativeThreads;
    static IntPtr __\u003Cjniptr\u003EinitIDs\u0028\u0029V;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EsetProtected\u0028Z\u0029V;
    static IntPtr __\u003Cjniptr\u003EisProtected\u0028\u0029Z;
    static IntPtr __\u003Cjniptr\u003EgetWindowHandle0\u0028Ljava\u002Fawt\u002FComponent\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003E_getDirectBufferPointer\u0028Ljava\u002Fnio\u002FBuffer\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003Esizeof\u0028I\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetNativeVersion\u0028\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetAPIChecksum\u0028\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetLastError\u0028\u0029I;
    static IntPtr __\u003Cjniptr\u003EsetLastError\u0028I\u0029V;
    static IntPtr __\u003Cjniptr\u003Eunregister\u0028Ljava\u002Flang\u002FClass\u003B\u005BJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EregisterMethod\u0028Ljava\u002Flang\u002FClass\u003BLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u005BI\u005BJ\u005BJIJJLjava\u002Flang\u002Freflect\u002FMethod\u003BJIZ\u005BLcom\u002Fsun\u002Fjna\u002FToNativeConverter\u003BLcom\u002Fsun\u002Fjna\u002FFromNativeConverter\u003BLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003Effi_prep_cif\u0028IIJJ\u0029J;
    static IntPtr __\u003Cjniptr\u003Effi_call\u0028JJJJ\u0029V;
    static IntPtr __\u003Cjniptr\u003Effi_prep_closure\u0028JLcom\u002Fsun\u002Fjna\u002FNative\u0024ffi_callback\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003Effi_free_closure\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003Einitialize_ffi_type\u0028J\u0029I;
    static IntPtr __\u003Cjniptr\u003EfreeNativeCallback\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EcreateNativeCallback\u0028Lcom\u002Fsun\u002Fjna\u002FCallback\u003BLjava\u002Flang\u002Freflect\u002FMethod\u003B\u005BLjava\u002Flang\u002FClass\u003BLjava\u002Flang\u002FClass\u003BIILjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EinvokeInt\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029I;
    static IntPtr __\u003Cjniptr\u003EinvokeLong\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EinvokeVoid\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EinvokeFloat\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029F;
    static IntPtr __\u003Cjniptr\u003EinvokeDouble\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029D;
    static IntPtr __\u003Cjniptr\u003EinvokePointer\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EinvokeStructure\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003BJJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EinvokeObject\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FObject\u003B;
    static IntPtr __\u003Cjniptr\u003Eopen\u0028Ljava\u002Flang\u002FString\u003BI\u0029J;
    static IntPtr __\u003Cjniptr\u003Eclose\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EfindSymbol\u0028JLjava\u002Flang\u002FString\u003B\u0029J;
    static IntPtr __\u003Cjniptr\u003EindexOf\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJB\u0029J;
    static IntPtr __\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BBII\u0029V;
    static IntPtr __\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BSII\u0029V;
    static IntPtr __\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BCII\u0029V;
    static IntPtr __\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BIII\u0029V;
    static IntPtr __\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BJII\u0029V;
    static IntPtr __\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BFII\u0029V;
    static IntPtr __\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BDII\u0029V;
    static IntPtr __\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BBII\u0029V;
    static IntPtr __\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BSII\u0029V;
    static IntPtr __\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BCII\u0029V;
    static IntPtr __\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BIII\u0029V;
    static IntPtr __\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BJII\u0029V;
    static IntPtr __\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BFII\u0029V;
    static IntPtr __\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BDII\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetByte\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029B;
    static IntPtr __\u003Cjniptr\u003EgetChar\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029C;
    static IntPtr __\u003Cjniptr\u003EgetShort\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029S;
    static IntPtr __\u003Cjniptr\u003EgetInt\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029I;
    static IntPtr __\u003Cjniptr\u003EgetLong\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetFloat\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029F;
    static IntPtr __\u003Cjniptr\u003EgetDouble\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029D;
    static IntPtr __\u003Cjniptr\u003E_getPointer\u0028J\u0029J;
    static IntPtr __\u003Cjniptr\u003EgetWideString\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029Ljava\u002Flang\u002FString\u003B;
    static IntPtr __\u003Cjniptr\u003EgetStringBytes\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029\u005BB;
    static IntPtr __\u003Cjniptr\u003EsetMemory\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJB\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetByte\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJB\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetShort\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJS\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetChar\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJC\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetInt\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJI\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetLong\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetFloat\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJF\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetDouble\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJD\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetPointer\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetWideString\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJLjava\u002Flang\u002FString\u003B\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetDirectByteBuffer\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029Ljava\u002Fnio\u002FByteBuffer\u003B;
    static IntPtr __\u003Cjniptr\u003Emalloc\u0028J\u0029J;
    static IntPtr __\u003Cjniptr\u003Efree\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetDirectByteBuffer\u0028JJ\u0029Ljava\u002Fnio\u002FByteBuffer\u003B;
    static IntPtr __\u003Cjniptr\u003EsetDetachState\u0028ZJ\u0029V;
    [HideFromJava]
    public const string VERSION = "4.4.0";
    [HideFromJava]
    public const string VERSION_NATIVE = "5.1.0";

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {162, 115, 103, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getStringEncoding(Class cls) => (string) Native.getLibraryOptions(cls).get((object) "string-encoding") ?? Native.getDefaultStringEncoding();

    [Signature("(Ljava/lang/Class<*>;)Lcom/sun/jna/TypeMapper;")]
    [LineNumberTable(new byte[] {162, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TypeMapper getTypeMapper(Class cls) => (TypeMapper) Native.getLibraryOptions(cls).get((object) "type-mapper");

    [Signature("(Ljava/lang/Class<*>;)I")]
    [LineNumberTable(new byte[] {162, 134, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getStructureAlignment(Class cls)
    {
      Integer integer = (Integer) Native.getLibraryOptions(cls).get((object) "structure-alignment");
      return integer == null ? 0 : integer.intValue();
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;)I")]
    [LineNumberTable(new byte[] {164, 122, 104, 103, 100, 104, 175, 159, 6, 115, 103, 173, 156, 98, 159, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getNativeSize(Class type, object value)
    {
      if (type.isArray())
      {
        int length = Array.getLength(value);
        if (length > 0)
        {
          object obj = Array.get(value, 0);
          return length * Native.getNativeSize(type.getComponentType(), obj);
        }
        string str = new StringBuilder().append("Arrays of length zero not allowed: ").append((object) type).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(type))
      {
        if (!((Class) ClassLiteral<Structure.ByReference>.Value).isAssignableFrom(type))
          return Structure.size(type, (Structure) value);
      }
      int nativeSize;
      IllegalArgumentException argumentException1;
      try
      {
        nativeSize = Native.getNativeSize(type);
      }
      catch (IllegalArgumentException ex)
      {
        argumentException1 = (IllegalArgumentException) ByteCodeHelper.MapException<IllegalArgumentException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_10;
      }
      return nativeSize;
label_10:
      IllegalArgumentException argumentException2 = argumentException1;
      string str1 = new StringBuilder().append("The type \"").append(type.getName()).append("\" is not supported: ").append(Throwable.instancehelper_getMessage((Exception) argumentException2)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str1);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;)TT;")]
    [LineNumberTable(544)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object loadLibrary(string name, Class interfaceClass) => Native.loadLibrary(name, interfaceClass, Collections.emptyMap());

    [Signature("(Ljava/lang/Class<*>;)Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;")]
    [LineNumberTable(new byte[] {162, 31, 108, 113, 99, 138, 151, 103, 99, 136, 162, 109, 113, 99, 109, 206, 114, 104, 115, 99, 255, 6, 70, 228, 82, 247, 42, 97, 166, 228, 82, 238, 44, 98, 255, 23, 83, 232, 48, 104, 110, 157, 110, 157, 110, 157, 138, 105, 141, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Map getLibraryOptions(Class type)
    {
      Map libraries1;
      Monitor.Enter((object) (libraries1 = Native.libraries));
      Map map1;
      Map map2;
      // ISSUE: fault handler
      try
      {
        map1 = (Map) Native.typeOptions.get((object) type);
        if (map1 != null)
        {
          Map map3 = map1;
          Monitor.Exit((object) libraries1);
          map2 = map3;
          return map2;
        }
        Monitor.Exit((object) libraries1);
      }
      __fault
      {
        Monitor.Exit((object) libraries1);
      }
      Class @class = Native.findEnclosingLibraryClass(type);
      if (@class != null)
        Native.loadLibraryInstance(@class);
      else
        @class = type;
      Map libraries2;
      Monitor.Enter((object) (libraries2 = Native.libraries));
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        map1 = (Map) Native.typeOptions.get((object) @class);
        if (map1 != null)
        {
          Native.typeOptions.put((object) type, (object) map1);
          Map map3 = map1;
          Monitor.Exit((object) libraries2);
          map2 = map3;
          return map2;
        }
        try
        {
          try
          {
            Field field = @class.getField("OPTIONS", Native.__\u003CGetCallerID\u003E());
            ((AccessibleObject) field).setAccessible(true);
            map1 = (Map) field.get((object) null, Native.__\u003CGetCallerID\u003E());
            if (map1 == null)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalStateException("Null options field");
            }
            goto label_24;
          }
          catch (NoSuchFieldException ex)
          {
          }
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
            exception1 = (Exception) m0;
            goto label_19;
          }
        }
      }
      __fault
      {
        Monitor.Exit((object) libraries2);
      }
      // ISSUE: fault handler
      try
      {
        map1 = Collections.emptyMap();
        goto label_24;
      }
      __fault
      {
        Monitor.Exit((object) libraries2);
      }
label_19:
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string str = new StringBuilder().append("OPTIONS must be a public field of type java.util.Map (").append((object) exception3).append("): ").append((object) @class).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      __fault
      {
        Monitor.Exit((object) libraries2);
      }
label_24:
      try
      {
        HashMap hashMap = new HashMap(map1);
        if (!((Map) hashMap).containsKey((object) "type-mapper"))
          ((Map) hashMap).put((object) "type-mapper", Native.lookupField(@class, "TYPE_MAPPER", (Class) ClassLiteral<TypeMapper>.Value));
        if (!((Map) hashMap).containsKey((object) "structure-alignment"))
          ((Map) hashMap).put((object) "structure-alignment", Native.lookupField(@class, "STRUCTURE_ALIGNMENT", (Class) ClassLiteral<Integer>.Value));
        if (!((Map) hashMap).containsKey((object) "string-encoding"))
          ((Map) hashMap).put((object) "string-encoding", Native.lookupField(@class, "STRING_ENCODING", (Class) ClassLiteral<String>.Value));
        Map map3 = Native.cacheOptions(@class, (Map) hashMap, (object) null);
        if (!object.ReferenceEquals((object) type, (object) @class))
          Native.typeOptions.put((object) type, (object) map3);
        map2 = map3;
      }
      finally
      {
        Monitor.Exit((object) libraries2);
      }
      return map2;
    }

    [Modifiers]
    [Signature("(Lcom/sun/jna/Callback;Ljava/lang/reflect/Method;[Ljava/lang/Class<*>;Ljava/lang/Class<*>;IILjava/lang/String;)J")]
    internal static long createNativeCallback(
      [In] Callback obj0,
      [In] Method obj1,
      [In] Class[] obj2,
      [In] Class obj3,
      [In] int obj4,
      [In] int obj5,
      [In] string obj6)
    {
      lock ((object) ClassLiteral<Native>.Value)
      {
        JNI.Frame frame = new JNI.Frame();
        if (Native.__\u003Cjniptr\u003EcreateNativeCallback\u0028Lcom\u002Fsun\u002Fjna\u002FCallback\u003BLjava\u002Flang\u002Freflect\u002FMethod\u003B\u005BLjava\u002Flang\u002FClass\u003BLjava\u002Flang\u002FClass\u003BIILjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
          Native.__\u003Cjniptr\u003EcreateNativeCallback\u0028Lcom\u002Fsun\u002Fjna\u002FCallback\u003BLjava\u002Flang\u002Freflect\u002FMethod\u003B\u005BLjava\u002Flang\u002FClass\u003BLjava\u002Flang\u002FClass\u003BIILjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (createNativeCallback), "(Lcom/sun/jna/Callback;Ljava/lang/reflect/Method;[Ljava/lang/Class;Ljava/lang/Class;IILjava/lang/String;)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
          IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
          IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
          IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
          IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
          int num8 = obj4;
          int num9 = obj5;
          IntPtr num10 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj6);
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int, int, IntPtr)>) Native.__\u003Cjniptr\u003EcreateNativeCallback\u0028Lcom\u002Fsun\u002Fjna\u002FCallback\u003BLjava\u002Flang\u002Freflect\u002FMethod\u003B\u005BLjava\u002Flang\u002FClass\u003BLjava\u002Flang\u002FClass\u003BIILjava\u002Flang\u002FString\u003B\u0029J)(num2, (int) num3, (int) num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9, num10);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }
    }

    [Modifiers]
    internal static void freeNativeCallback([In] long obj0)
    {
      lock ((object) ClassLiteral<Native>.Value)
      {
        JNI.Frame frame = new JNI.Frame();
        if (Native.__\u003Cjniptr\u003EfreeNativeCallback\u0028J\u0029V == IntPtr.Zero)
          Native.__\u003Cjniptr\u003EfreeNativeCallback\u0028J\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (freeNativeCallback), "(J)V");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, IntPtr, long)>) Native.__\u003Cjniptr\u003EfreeNativeCallback\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Callback.UncaughtExceptionHandler getCallbackExceptionHandler() => Native.callbackExceptionHandler;

    [Modifiers]
    internal static long indexOf([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] byte obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EindexOf\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJB\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EindexOf\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJB\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (indexOf), "(Lcom/sun/jna/Pointer;JJB)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        int num7 = (int) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, long, long, byte)>) Native.__\u003Cjniptr\u003EindexOf\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJB\u0029J)((byte) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void read(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BBII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BBII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (read), "(Lcom/sun/jna/Pointer;JJ[BII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BBII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void read(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] short[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BSII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BSII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (read), "(Lcom/sun/jna/Pointer;JJ[SII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BSII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void read(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] char[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BCII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BCII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (read), "(Lcom/sun/jna/Pointer;JJ[CII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BCII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void read(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] int[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BIII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BIII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (read), "(Lcom/sun/jna/Pointer;JJ[III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void read(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] long[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BJII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BJII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (read), "(Lcom/sun/jna/Pointer;JJ[JII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BJII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void read(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] float[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BFII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BFII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (read), "(Lcom/sun/jna/Pointer;JJ[FII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BFII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void read(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] double[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BDII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BDII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (read), "(Lcom/sun/jna/Pointer;JJ[DII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Eread\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BDII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void write(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BBII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BBII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (write), "(Lcom/sun/jna/Pointer;JJ[BII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BBII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void write(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] short[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BSII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BSII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (write), "(Lcom/sun/jna/Pointer;JJ[SII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BSII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void write(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] char[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BCII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BCII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (write), "(Lcom/sun/jna/Pointer;JJ[CII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BCII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void write(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] int[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BIII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BIII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (write), "(Lcom/sun/jna/Pointer;JJ[III)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BIII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void write(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] long[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BJII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BJII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (write), "(Lcom/sun/jna/Pointer;JJ[JII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BJII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void write(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] float[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BFII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BFII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (write), "(Lcom/sun/jna/Pointer;JJ[FII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BFII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void write(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] double[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BDII\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BDII\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (write), "(Lcom/sun/jna/Pointer;JJ[DII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr, int, int)>) Native.__\u003Cjniptr\u003Ewrite\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u005BDII\u0029V)((int) num2, (int) num3, num4, num5, num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {160, 249, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pointer getDirectBufferPointer(Buffer b)
    {
      long directBufferPointer = Native._getDirectBufferPointer(b);
      return directBufferPointer == 0L ? (Pointer) null : new Pointer(directBufferPointer);
    }

    [Modifiers]
    internal static byte getByte([In] Pointer obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetByte\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029B == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetByte\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029B = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getByte), "(Lcom/sun/jna/Pointer;JJ)B");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<byte (IntPtr, IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetByte\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029B)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static char getChar([In] Pointer obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetChar\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029C == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetChar\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029C = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getChar), "(Lcom/sun/jna/Pointer;JJ)C");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<char (IntPtr, IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetChar\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029C)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static short getShort([In] Pointer obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetShort\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029S == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetShort\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029S = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getShort), "(Lcom/sun/jna/Pointer;JJ)S");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<short (IntPtr, IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetShort\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029S)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int getInt([In] Pointer obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetInt\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029I == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetInt\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029I = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getInt), "(Lcom/sun/jna/Pointer;JJ)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetInt\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029I)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long getLong([In] Pointer obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetLong\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetLong\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getLong), "(Lcom/sun/jna/Pointer;JJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetLong\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029J)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static float getFloat([In] Pointer obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetFloat\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029F == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetFloat\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029F = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getFloat), "(Lcom/sun/jna/Pointer;JJ)F");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<float (IntPtr, IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetFloat\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029F)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static double getDouble([In] Pointer obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetDouble\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029D == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetDouble\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029D = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getDouble), "(Lcom/sun/jna/Pointer;JJ)D");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<double (IntPtr, IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetDouble\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029D)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {167, 225, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Pointer getPointer([In] long obj0)
    {
      long pointer = Native._getPointer(obj0);
      return pointer == 0L ? (Pointer) null : new Pointer(pointer);
    }

    [Modifiers]
    internal static ByteBuffer getDirectByteBuffer(
      [In] Pointer obj0,
      [In] long obj1,
      [In] long obj2,
      [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetDirectByteBuffer\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029Ljava\u002Fnio\u002FByteBuffer\u003B == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetDirectByteBuffer\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029Ljava\u002Fnio\u002FByteBuffer\u003B = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getDirectByteBuffer), "(Lcom/sun/jna/Pointer;JJJ)Ljava/nio/ByteBuffer;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num8 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, IntPtr, long, long, long)>) Native.__\u003Cjniptr\u003EgetDirectByteBuffer\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029Ljava\u002Fnio\u002FByteBuffer\u003B)((long) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
        return (ByteBuffer) ((JNI.Frame) ref local).UnwrapLocalRef(num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static string getWideString([In] Pointer obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetWideString\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetWideString\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getWideString), "(Lcom/sun/jna/Pointer;JJ)Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num7 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetWideString\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029Ljava\u002Flang\u002FString\u003B)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(751)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getDefaultStringEncoding() => java.lang.System.getProperty("jna.encoding", Native.__\u003C\u003EDEFAULT_ENCODING);

    [LineNumberTable(new byte[] {167, 238, 110, 131, 150, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getString([In] Pointer obj0, [In] long obj1, [In] string obj2)
    {
      byte[] stringBytes = Native.getStringBytes(obj0, obj0.peer, obj1);
      if (obj2 != null)
      {
        string str;
        try
        {
          str = String.newhelper(stringBytes, obj2);
        }
        catch (UnsupportedEncodingException ex)
        {
          goto label_4;
        }
        return str;
label_4:;
      }
      return String.newhelper(stringBytes);
    }

    [Modifiers]
    internal static void setMemory([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] long obj3, [In] byte obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetMemory\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJB\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetMemory\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJB\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setMemory), "(Lcom/sun/jna/Pointer;JJJB)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        long num7 = obj3;
        int num8 = (int) obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, long, byte)>) Native.__\u003Cjniptr\u003EsetMemory\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJB\u0029V)((byte) num2, (long) num3, (long) num4, num5, (IntPtr) num6, (IntPtr) num7, (IntPtr) num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setByte([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] byte obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetByte\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJB\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetByte\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJB\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setByte), "(Lcom/sun/jna/Pointer;JJB)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        int num7 = (int) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, byte)>) Native.__\u003Cjniptr\u003EsetByte\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJB\u0029V)((byte) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setShort([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] short obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetShort\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJS\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetShort\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJS\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setShort), "(Lcom/sun/jna/Pointer;JJS)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        int num7 = (int) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, short)>) Native.__\u003Cjniptr\u003EsetShort\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJS\u0029V)((short) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setChar([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] char obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetChar\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJC\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetChar\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJC\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setChar), "(Lcom/sun/jna/Pointer;JJC)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        int num7 = (int) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, char)>) Native.__\u003Cjniptr\u003EsetChar\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJC\u0029V)((char) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setInt([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetInt\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJI\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetInt\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJI\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setInt), "(Lcom/sun/jna/Pointer;JJI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, int)>) Native.__\u003Cjniptr\u003EsetInt\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJI\u0029V)((int) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setLong([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetLong\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetLong\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setLong), "(Lcom/sun/jna/Pointer;JJJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, long)>) Native.__\u003Cjniptr\u003EsetLong\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029V)((long) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setFloat([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] float obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetFloat\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJF\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetFloat\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJF\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setFloat), "(Lcom/sun/jna/Pointer;JJF)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        double num7 = (double) obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, float)>) Native.__\u003Cjniptr\u003EsetFloat\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJF\u0029V)((float) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setDouble([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] double obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetDouble\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJD\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetDouble\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJD\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setDouble), "(Lcom/sun/jna/Pointer;JJD)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        double num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, double)>) Native.__\u003Cjniptr\u003EsetDouble\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJD\u0029V)((double) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setPointer([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] long obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetPointer\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetPointer\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setPointer), "(Lcom/sun/jna/Pointer;JJJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        long num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, long)>) Native.__\u003Cjniptr\u003EsetPointer\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJJ\u0029V)((long) num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void setWideString([In] Pointer obj0, [In] long obj1, [In] long obj2, [In] string obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetWideString\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJLjava\u002Flang\u002FString\u003B\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetWideString\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJLjava\u002Flang\u002FString\u003B\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setWideString), "(Lcom/sun/jna/Pointer;JJLjava/lang/String;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, long, IntPtr)>) Native.__\u003Cjniptr\u003EsetWideString\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJLjava\u002Flang\u002FString\u003B\u0029V)(num2, (long) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {162, 156, 131, 150, 97, 223, 15, 121, 47, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static byte[] getBytes([In] string obj0, [In] string obj1)
    {
      if (obj1 != null)
      {
        byte[] bytes;
        try
        {
          bytes = String.instancehelper_getBytes(obj0, obj1);
        }
        catch (UnsupportedEncodingException ex)
        {
          goto label_4;
        }
        return bytes;
label_4:
        java.lang.System.err.println(new StringBuilder().append("JNA Warning: Encoding '").append(obj1).append("' is unsupported").toString());
      }
      java.lang.System.err.println(new StringBuilder().append("JNA Warning: Encoding with fallback ").append(java.lang.System.getProperty("file.encoding")).toString());
      return String.instancehelper_getBytes(obj0);
    }

    [Modifiers]
    public static void free(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Efree\u0028J\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Efree\u0028J\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (free), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) Native.__\u003Cjniptr\u003Efree\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static long malloc(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Emalloc\u0028J\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Emalloc\u0028J\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (malloc), "(J)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) Native.__\u003Cjniptr\u003Emalloc\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static void invokeVoid([In] Function obj0, [In] long obj1, [In] int obj2, [In] object[] obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EinvokeVoid\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EinvokeVoid\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (invokeVoid), "(Lcom/sun/jna/Function;JI[Ljava/lang/Object;)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, int, IntPtr)>) Native.__\u003Cjniptr\u003EinvokeVoid\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029V)(num2, (int) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int invokeInt([In] Function obj0, [In] long obj1, [In] int obj2, [In] object[] obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EinvokeInt\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029I == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EinvokeInt\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029I = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (invokeInt), "(Lcom/sun/jna/Function;JI[Ljava/lang/Object;)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, IntPtr, long, int, IntPtr)>) Native.__\u003Cjniptr\u003EinvokeInt\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029I)(num2, (int) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long invokeLong([In] Function obj0, [In] long obj1, [In] int obj2, [In] object[] obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EinvokeLong\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EinvokeLong\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (invokeLong), "(Lcom/sun/jna/Function;JI[Ljava/lang/Object;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, long, int, IntPtr)>) Native.__\u003Cjniptr\u003EinvokeLong\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029J)(num2, (int) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static float invokeFloat([In] Function obj0, [In] long obj1, [In] int obj2, [In] object[] obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EinvokeFloat\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029F == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EinvokeFloat\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029F = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (invokeFloat), "(Lcom/sun/jna/Function;JI[Ljava/lang/Object;)F");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<float (IntPtr, IntPtr, IntPtr, long, int, IntPtr)>) Native.__\u003Cjniptr\u003EinvokeFloat\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029F)(num2, (int) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static double invokeDouble([In] Function obj0, [In] long obj1, [In] int obj2, [In] object[] obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EinvokeDouble\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029D == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EinvokeDouble\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029D = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (invokeDouble), "(Lcom/sun/jna/Function;JI[Ljava/lang/Object;)D");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<double (IntPtr, IntPtr, IntPtr, long, int, IntPtr)>) Native.__\u003Cjniptr\u003EinvokeDouble\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029D)(num2, (int) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {167, 116, 114, 42, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Structure invokeStructure(
      [In] Function obj0,
      [In] long obj1,
      [In] int obj2,
      [In] object[] obj3,
      [In] Structure obj4)
    {
      Native.invokeStructure(obj0, obj1, obj2, obj3, obj4.getPointer().peer, obj4.getTypeInfo().peer);
      return obj4;
    }

    [Modifiers]
    internal static object invokeObject([In] Function obj0, [In] long obj1, [In] int obj2, [In] object[] obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EinvokeObject\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FObject\u003B == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EinvokeObject\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FObject\u003B = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (invokeObject), "(Lcom/sun/jna/Function;JI[Ljava/lang/Object;)Ljava/lang/Object;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num8 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, IntPtr, long, int, IntPtr)>) Native.__\u003Cjniptr\u003EinvokeObject\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029Ljava\u002Flang\u002FObject\u003B)(num2, (int) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, num7);
        return ((JNI.Frame) ref local).UnwrapLocalRef(num8);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long invokePointer([In] Function obj0, [In] long obj1, [In] int obj2, [In] object[] obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EinvokePointer\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EinvokePointer\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (invokePointer), "(Lcom/sun/jna/Function;JI[Ljava/lang/Object;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, long, int, IntPtr)>) Native.__\u003Cjniptr\u003EinvokePointer\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003B\u0029J)(num2, (int) num3, (long) num4, (IntPtr) num5, (IntPtr) num6, num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Signature("(Ljava/lang/Class<*>;)Z")]
    [LineNumberTable(new byte[] {164, 188, 109, 162, 155, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isSupportedNativeType(Class cls)
    {
      if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(cls))
        return true;
      int num;
      try
      {
        num = Native.getNativeSize(cls) == 0 ? 0 : 1;
      }
      catch (IllegalArgumentException ex)
      {
        goto label_5;
      }
      return num != 0;
label_5:
      return false;
    }

    [LineNumberTable(new byte[] {160, 128, 101, 101, 101, 101, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void dispose()
    {
      CallbackReference.disposeAll();
      Memory.disposeAll();
      NativeLibrary.disposeAll();
      Native.unregisterAll();
      Native.jnidispatchPath = (string) null;
      java.lang.System.setProperty("jna.loaded", "false");
    }

    [LineNumberTable(new byte[] {165, 32, 108, 127, 5, 123, 130, 106, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void unregisterAll()
    {
      lock (Native.registeredClasses)
      {
        Iterator iterator = Native.registeredClasses.entrySet().iterator();
        while (iterator.hasNext())
        {
          Map.Entry entry = (Map.Entry) iterator.next();
          Native.unregister((Class) entry.getKey(), (long[]) entry.getValue());
        }
        Native.registeredClasses.clear();
      }
    }

    [LineNumberTable(new byte[] {164, 58, 127, 17, 153, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void markTemporaryFile([In] File obj0)
    {
      IOException ioException;
      try
      {
        File.__\u003Cclinit\u003E();
        new File(obj0.getParentFile(), new StringBuilder().append(obj0.getName()).append(".x").toString()).createNewFile();
        return;
      }
      catch (IOException ex)
      {
        ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      Throwable.instancehelper_printStackTrace((Exception) ioException);
    }

    [Modifiers]
    private static long _getDirectBufferPointer([In] Buffer obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003E_getDirectBufferPointer\u0028Ljava\u002Fnio\u002FBuffer\u003B\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003E_getDirectBufferPointer\u0028Ljava\u002Fnio\u002FBuffer\u003B\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (_getDirectBufferPointer), "(Ljava/nio/Buffer;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) Native.__\u003Cjniptr\u003E_getDirectBufferPointer\u0028Ljava\u002Fnio\u002FBuffer\u003B\u0029J)(num2, num3, num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {161, 25, 131, 102, 101, 98, 226, 61, 230, 71, 99, 166, 131, 152, 97, 255, 15, 69, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string toString(byte[] buf, string encoding)
    {
      int num = buf.Length;
      for (int index = 0; index < num; ++index)
      {
        if (buf[index] == (byte) 0)
        {
          num = index;
          break;
        }
      }
      if (num == 0)
        return "";
      if (encoding != null)
      {
        string str;
        try
        {
          str = String.newhelper(buf, 0, num, encoding);
        }
        catch (UnsupportedEncodingException ex)
        {
          goto label_11;
        }
        return str;
label_11:
        java.lang.System.err.println(new StringBuilder().append("JNA Warning: Encoding '").append(encoding).append("' is unsupported").toString());
      }
      java.lang.System.err.println(new StringBuilder().append("JNA Warning: Decoding with fallback ").append(java.lang.System.getProperty("file.encoding")).toString());
      return String.newhelper(buf, 0, num);
    }

    [Signature("([CII)Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(new byte[] {161, 98, 102, 98, 100, 102, 101, 194, 100, 162, 108, 105, 228, 52, 230, 80, 100, 108, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static List toStringList(char[] buf, int offset, int len)
    {
      ArrayList arrayList = new ArrayList();
      int num1 = offset;
      int num2 = offset + len;
      for (int index = offset; index < num2; ++index)
      {
        if (buf[index] == char.MinValue)
        {
          if (num1 == index)
            return (List) arrayList;
          string str = String.newhelper(buf, num1, index - num1);
          ((List) arrayList).add((object) str);
          num1 = index + 1;
        }
      }
      if (num1 < num2)
      {
        string str = String.newhelper(buf, num1, num2 - num1);
        ((List) arrayList).add((object) str);
      }
      return (List) arrayList;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;Ljava/util/Map<Ljava/lang/String;*>;)TT;")]
    [LineNumberTable(new byte[] {161, 194, 109, 127, 26, 186, 105, 108, 119, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object loadLibrary(string name, Class interfaceClass, Map options)
    {
      if (!((Class) ClassLiteral<Library>.Value).isAssignableFrom(interfaceClass))
      {
        string str = new StringBuilder().append("Interface (").append(interfaceClass.getSimpleName()).append(") of library=").append(name).append(" does not extend ").append(((Class) ClassLiteral<Library>.Value).getSimpleName()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      Library.Handler handler = new Library.Handler(name, interfaceClass, options);
      object obj = Proxy.newProxyInstance(interfaceClass.getClassLoader(Native.__\u003CGetCallerID\u003E()), new Class[1]
      {
        interfaceClass
      }, (InvocationHandler) handler, Native.__\u003CGetCallerID\u003E());
      Native.cacheOptions(interfaceClass, options, obj);
      return interfaceClass.cast(obj);
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/util/Map<Ljava/lang/String;*>;Ljava/lang/Object;)Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;")]
    [LineNumberTable(new byte[] {166, 145, 103, 109, 108, 109, 99, 242, 70, 113, 103, 103, 117, 110, 106, 226, 61, 232, 71, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Map cacheOptions([In] Class obj0, [In] Map obj1, [In] object obj2)
    {
      HashMap hashMap = new HashMap(obj1);
      ((Map) hashMap).put((object) "enclosing-library", (object) obj0);
      lock (Native.libraries)
      {
        Native.typeOptions.put((object) obj0, (object) hashMap);
        if (obj2 != null)
          Native.libraries.put((object) obj0, (object) new WeakReference(obj2));
        if (!obj0.isInterface())
        {
          if (((Class) ClassLiteral<Library>.Value).isAssignableFrom(obj0))
          {
            Class[] interfaces = obj0.getInterfaces();
            int length = interfaces.Length;
            for (int index = 0; index < length; ++index)
            {
              Class @class = interfaces[index];
              if (((Class) ClassLiteral<Library>.Value).isAssignableFrom(@class))
              {
                Native.cacheOptions(@class, (Map) hashMap, obj2);
                break;
              }
            }
          }
        }
      }
      return (Map) hashMap;
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {161, 242, 99, 194, 108, 109, 113, 113, 99, 138, 138, 121, 109, 130, 109, 136, 109, 105, 100, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Class findEnclosingLibraryClass([In] Class obj0)
    {
      if (obj0 == null)
        return (Class) null;
      Map libraries;
      Monitor.Enter((object) (libraries = Native.libraries));
      // ISSUE: fault handler
      try
      {
        if (Native.typeOptions.containsKey((object) obj0))
        {
          Class class1 = (Class) ((Map) Native.typeOptions.get((object) obj0)).get((object) "enclosing-library");
          if (class1 != null)
          {
            Class class2 = class1;
            Monitor.Exit((object) libraries);
            return class2;
          }
          Class class3 = obj0;
          Monitor.Exit((object) libraries);
          return class3;
        }
        Monitor.Exit((object) libraries);
      }
      __fault
      {
        Monitor.Exit((object) libraries);
      }
      if (((Class) ClassLiteral<Library>.Value).isAssignableFrom(obj0))
        return obj0;
      if (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj0))
        obj0 = CallbackReference.findCallbackClass(obj0);
      return Native.findEnclosingLibraryClass(obj0.getDeclaringClass(Native.__\u003CGetCallerID\u003E())) ?? Native.findEnclosingLibraryClass(obj0.getSuperclass());
    }

    [Signature("(Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {161, 212, 108, 150, 108, 103, 100, 111, 140, 125, 226, 58, 249, 77, 245, 61, 98, 223, 40, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void loadLibraryInstance([In] Class obj0)
    {
      Map libraries;
      Monitor.Enter((object) (libraries = Native.libraries));
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        if (obj0 != null)
        {
          if (!Native.libraries.containsKey((object) obj0))
          {
            try
            {
              foreach (Field field in obj0.getFields(Native.__\u003CGetCallerID\u003E()))
              {
                if (object.ReferenceEquals((object) field.getType(), (object) obj0) && Modifier.isStatic(field.getModifiers()))
                {
                  Native.libraries.put((object) obj0, (object) new WeakReference(field.get((object) null, Native.__\u003CGetCallerID\u003E())));
                  break;
                }
              }
              goto label_15;
            }
            catch (Exception ex)
            {
              M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
              if (m0 == null)
                throw;
              else
                exception1 = (Exception) m0;
            }
          }
          else
            goto label_15;
        }
        else
          goto label_15;
      }
      __fault
      {
        Monitor.Exit((object) libraries);
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string str = new StringBuilder().append("Could not access instance of ").append((object) obj0).append(" (").append((object) exception3).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      __fault
      {
        Monitor.Exit((object) libraries);
      }
label_15:
      // ISSUE: fault handler
      try
      {
        Monitor.Exit((object) libraries);
      }
      __fault
      {
        Monitor.Exit((object) libraries);
      }
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/String;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {162, 86, 109, 103, 159, 13, 97, 130, 97, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lookupField([In] Class obj0, [In] string obj1, [In] Class obj2)
    {
      object obj;
      Exception exception1;
      try
      {
        try
        {
          Field field = obj0.getField(obj1, Native.__\u003CGetCallerID\u003E());
          ((AccessibleObject) field).setAccessible(true);
          obj = field.get((object) null, Native.__\u003CGetCallerID\u003E());
        }
        catch (NoSuchFieldException ex)
        {
          goto label_6;
        }
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
          exception1 = (Exception) m0;
          goto label_7;
        }
      }
      return obj;
label_6:
      return (object) null;
label_7:
      Exception exception2 = exception1;
      string str = new StringBuilder().append(obj1).append(" must be a public field of type ").append(obj2.getName()).append(" (").append((object) exception2).append("): ").append((object) obj0).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {162, 187, 104, 106, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] toByteArray(string s, string encoding)
    {
      byte[] bytes = Native.getBytes(s, encoding);
      byte[] numArray = new byte[bytes.Length + 1];
      ByteCodeHelper.arraycopy_primitive_1((Array) bytes, 0, (Array) numArray, 0, bytes.Length);
      return numArray;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 96, 102, 230, 70, 104, 112, 101, 105, 115, 117, 114, 232, 58, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void removeTemporaryFiles()
    {
      File[] fileArray = Native.getTempDir().listFiles((FilenameFilter) new Native.\u0035());
      for (int index = 0; fileArray != null && index < fileArray.Length; ++index)
      {
        File file1 = fileArray[index];
        string name = file1.getName();
        string str = String.instancehelper_substring(name, 0, String.instancehelper_length(name) - 2);
        File.__\u003Cclinit\u003E();
        File file2 = new File(file1.getParentFile(), str);
        if (!file2.exists() || file2.delete())
          file1.delete();
      }
    }

    [LineNumberTable(new byte[] {163, 54, 127, 74, 119, 100, 100, 176, 103, 159, 11, 114, 113, 108, 103, 255, 9, 70, 110, 103, 252, 69, 2, 98, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void loadNativeDispatchLibraryFromClasspath()
    {
      IOException ioException;
      try
      {
        StringBuilder stringBuilder = new StringBuilder().append("/com/sun/jna/").append(Platform.__\u003C\u003ERESOURCE_PREFIX).append("/");
        string str1 = java.lang.System.mapLibraryName("jnidispatch");
        object obj1 = (object) ".jnilib";
        object obj2 = (object) ".dylib";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        string str2 = String.instancehelper_replace(str1, charSequence2, charSequence3);
        File fromResourcePath = Native.extractFromResourcePath(stringBuilder.append(str2).toString(), ((Class) ClassLiteral<Native>.Value).getClassLoader(Native.__\u003CGetCallerID\u003E()));
        if (fromResourcePath == null && fromResourcePath == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new UnsatisfiedLinkError("Could not find JNA native support");
        }
        if (Native.DEBUG_JNA_LOAD)
          java.lang.System.@out.println(new StringBuilder().append("Trying ").append(fromResourcePath.getAbsolutePath()).toString());
        java.lang.System.setProperty("jnidispatch.path", fromResourcePath.getAbsolutePath());
        java.lang.System.load(fromResourcePath.getAbsolutePath(), Native.__\u003CGetCallerID\u003E());
        Native.jnidispatchPath = fromResourcePath.getAbsolutePath();
        if (Native.DEBUG_JNA_LOAD)
          java.lang.System.@out.println(new StringBuilder().append("Found jnidispatch at ").append(Native.jnidispatchPath).toString());
        if (!Native.isUnpacked(fromResourcePath) || Boolean.getBoolean("jnidispatch.preserve"))
          return;
        Native.deleteLibrary(fromResourcePath);
        return;
      }
      catch (IOException ex)
      {
        ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      string message = Throwable.instancehelper_getMessage((Exception) ioException);
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsatisfiedLinkError(message);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {163, 117, 116, 109, 99, 140, 99, 177, 99, 159, 21, 119, 127, 22, 109, 136, 104, 144, 136, 99, 108, 104, 151, 159, 33, 99, 191, 5, 99, 154, 223, 8, 2, 97, 146, 99, 159, 11, 108, 191, 16, 111, 105, 100, 191, 6, 227, 69, 103, 125, 108, 135, 137, 108, 115, 250, 71, 117, 100, 28, 117, 103, 255, 2, 58, 98, 191, 28, 117, 100, 214})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static File extractFromResourcePath(string name, ClassLoader loader)
    {
      int num1 = Native.DEBUG_LOAD || Native.DEBUG_JNA_LOAD && String.instancehelper_indexOf(name, "jnidispatch") != -1 ? 1 : 0;
      if (loader == null)
      {
        loader = Thread.currentThread().getContextClassLoader();
        if (loader == null)
          loader = ((Class) ClassLiteral<Native>.Value).getClassLoader(Native.__\u003CGetCallerID\u003E());
      }
      if (num1 != 0)
        java.lang.System.@out.println(new StringBuilder().append("Looking in classpath from ").append((object) loader).append(" for ").append(name).toString());
      string str1 = !String.instancehelper_startsWith(name, "/") ? NativeLibrary.mapSharedLibraryName(name) : name;
      string str2 = !String.instancehelper_startsWith(name, "/") ? new StringBuilder().append(Platform.__\u003C\u003ERESOURCE_PREFIX).append("/").append(str1).toString() : name;
      if (String.instancehelper_startsWith(str2, "/"))
        str2 = String.instancehelper_substring(str2, 1);
      URL resource = loader.getResource(str2);
      if (resource == null && String.instancehelper_startsWith(str2, Platform.__\u003C\u003ERESOURCE_PREFIX))
        resource = loader.getResource(str1);
      if (resource == null)
      {
        string property = java.lang.System.getProperty("java.class.path");
        if (loader is URLClassLoader)
          property = Object.instancehelper_toString((object) Arrays.asList((object[]) ((URLClassLoader) loader).getURLs()));
        string str3 = new StringBuilder().append("Native library (").append(str2).append(") not found in resource path (").append(property).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str3);
      }
      if (num1 != 0)
        java.lang.System.@out.println(new StringBuilder().append("Found library resource at ").append((object) resource).toString());
      File file = (File) null;
      if (String.instancehelper_equals(String.instancehelper_toLowerCase(resource.getProtocol()), (object) "file"))
      {
        try
        {
          File.__\u003Cclinit\u003E();
          URI.__\u003Cclinit\u003E();
          file = new File(new URI(resource.toString()));
          goto label_19;
        }
        catch (URISyntaxException ex)
        {
        }
        File.__\u003Cclinit\u003E();
        file = new File(resource.getPath());
label_19:
        if (num1 != 0)
          java.lang.System.@out.println(new StringBuilder().append("Looking in ").append(file.getAbsolutePath()).toString());
        if (!file.exists())
        {
          string str3 = new StringBuilder().append("File URL ").append((object) resource).append(" could not be properly decoded").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException(str3);
        }
      }
      else if (!Boolean.getBoolean("jna.nounpack"))
      {
        InputStream resourceAsStream = loader.getResourceAsStream(str2);
        if (resourceAsStream == null)
        {
          string str3 = new StringBuilder().append("Can't obtain InputStream for ").append(str2).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException(str3);
        }
        FileOutputStream fileOutputStream = (FileOutputStream) null;
        IOException ioException1;
        // ISSUE: fault handler
        try
        {
          File tempDir = Native.getTempDir();
          file = File.createTempFile("jna", !Platform.isWindows() ? (string) null : ".dll", tempDir);
          if (!Boolean.getBoolean("jnidispatch.preserve"))
            file.deleteOnExit();
          fileOutputStream = new FileOutputStream(file);
          byte[] numArray = new byte[1024];
          int num2;
          while ((num2 = resourceAsStream.read(numArray, 0, numArray.Length)) > 0)
            fileOutputStream.write(numArray, 0, num2);
          goto label_42;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        __fault
        {
          try
          {
            resourceAsStream.close();
            goto label_36;
          }
          catch (IOException ex)
          {
          }
label_36:
          if (fileOutputStream != null)
          {
            try
            {
              fileOutputStream.close();
              goto label_40;
            }
            catch (IOException ex)
            {
            }
          }
label_40:;
        }
        IOException ioException2 = ioException1;
        // ISSUE: fault handler
        try
        {
          IOException ioException3 = ioException2;
          string str3 = new StringBuilder().append("Failed to create temporary file for ").append(name).append(" library: ").append(Throwable.instancehelper_getMessage((Exception) ioException3)).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException(str3);
        }
        __fault
        {
          try
          {
            resourceAsStream.close();
            goto label_53;
          }
          catch (IOException ex)
          {
          }
label_53:
          if (fileOutputStream != null)
          {
            try
            {
              fileOutputStream.close();
              goto label_57;
            }
            catch (IOException ex)
            {
            }
          }
label_57:;
        }
label_42:
        try
        {
          resourceAsStream.close();
          goto label_45;
        }
        catch (IOException ex)
        {
        }
label_45:
        if (fileOutputStream != null)
        {
          try
          {
            fileOutputStream.close();
            goto label_58;
          }
          catch (IOException ex)
          {
          }
        }
      }
label_58:
      return file;
    }

    [LineNumberTable(968)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isUnpacked([In] File obj0) => String.instancehelper_startsWith(obj0.getName(), "jna");

    [LineNumberTable(new byte[] {160, 148, 104, 194, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool deleteLibrary([In] File obj0)
    {
      if (obj0.delete())
        return true;
      Native.markTemporaryFile(obj0);
      return false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 69, 107, 99, 103, 172, 213, 127, 21, 103, 112, 162, 104, 159, 16, 104, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static File getTempDir()
    {
      string property = java.lang.System.getProperty("jna.tmpdir");
      File file1;
      if (property != null)
      {
        file1 = new File(property);
        file1.mkdirs();
      }
      else
      {
        File.__\u003Cclinit\u003E();
        File file2 = new File(java.lang.System.getProperty("java.io.tmpdir"));
        File.__\u003Cclinit\u003E();
        file1 = new File(file2, new StringBuilder().append("jna-").append(String.instancehelper_hashCode(java.lang.System.getProperty("user.name"))).toString());
        file1.mkdirs();
        if (!file1.exists() || !file1.canWrite())
          file1 = file2;
      }
      if (!file1.exists())
      {
        string str = new StringBuilder().append("JNA temporary directory '").append((object) file1).append("' does not exist").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str);
      }
      if (!file1.canWrite())
      {
        string str = new StringBuilder().append("JNA temporary directory '").append((object) file1).append("' is not writable").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str);
      }
      return file1;
    }

    [Signature("(Ljava/lang/Class<*>;)I")]
    [LineNumberTable(new byte[] {164, 154, 109, 173, 124, 124, 124, 127, 1, 124, 124, 124, 124, 109, 109, 135, 134, 117, 109, 191, 2, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getNativeSize(Class cls)
    {
      if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(cls))
        cls = NativeMappedConverter.getInstance(cls).nativeType();
      if (object.ReferenceEquals((object) cls, (object) Boolean.TYPE) || object.ReferenceEquals((object) cls, (object) ClassLiteral<Boolean>.Value))
        return 4;
      if (object.ReferenceEquals((object) cls, (object) Byte.TYPE) || object.ReferenceEquals((object) cls, (object) ClassLiteral<Byte>.Value))
        return 1;
      if (object.ReferenceEquals((object) cls, (object) Short.TYPE) || object.ReferenceEquals((object) cls, (object) ClassLiteral<Short>.Value))
        return 2;
      if (object.ReferenceEquals((object) cls, (object) Character.TYPE) || object.ReferenceEquals((object) cls, (object) ClassLiteral<Character>.Value))
        return Native.__\u003C\u003EWCHAR_SIZE;
      if (object.ReferenceEquals((object) cls, (object) Integer.TYPE) || object.ReferenceEquals((object) cls, (object) ClassLiteral<Integer>.Value))
        return 4;
      if (object.ReferenceEquals((object) cls, (object) Long.TYPE) || object.ReferenceEquals((object) cls, (object) ClassLiteral<Long>.Value))
        return 8;
      if (object.ReferenceEquals((object) cls, (object) Float.TYPE) || object.ReferenceEquals((object) cls, (object) ClassLiteral<Float>.Value))
        return 4;
      if (object.ReferenceEquals((object) cls, (object) Double.TYPE) || object.ReferenceEquals((object) cls, (object) ClassLiteral<Double>.Value))
        return 8;
      if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(cls))
        return ((Class) ClassLiteral<Structure.ByValue>.Value).isAssignableFrom(cls) ? Structure.size(cls) : Native.__\u003C\u003EPOINTER_SIZE;
      if (((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(cls) || Platform.__\u003C\u003EHAS_BUFFERS && Native.Buffers.isBuffer(cls) || (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(cls) || object.ReferenceEquals((object) ClassLiteral<String>.Value, (object) cls) || object.ReferenceEquals((object) ClassLiteral<WString>.Value, (object) cls)))
        return Native.__\u003C\u003EPOINTER_SIZE;
      string str = new StringBuilder().append("Native size for type \"").append(cls.getName()).append("\" is unknown").toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [Signature("()Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {165, 3, 229, 69, 102, 99, 144, 101, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Class getCallingClass()
    {
      Class[] classContext = new Native.\u0036().getClassContext();
      if (classContext == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("The SecurityManager implementation on this platform is broken; you must explicitly provide the class to register");
      }
      if (classContext.Length < 4)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("This method must be called from the static initializer of a class");
      }
      return classContext[3];
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {164, 237, 108, 112, 111, 2, 230, 69, 114, 101, 144, 127, 16, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Class findDirectMappedClass([In] Class obj0)
    {
      Method[] declaredMethods = obj0.getDeclaredMethods(Native.__\u003CGetCallerID\u003E());
      int length = declaredMethods.Length;
      for (int index = 0; index < length; ++index)
      {
        if ((declaredMethods[index].getModifiers() & 256) != 0)
          return obj0;
      }
      int num = String.instancehelper_lastIndexOf(obj0.getName(), "$");
      if (num != -1)
      {
        string str = String.instancehelper_substring(obj0.getName(), 0, num);
        Class directMappedClass;
        try
        {
          directMappedClass = Native.findDirectMappedClass(Class.forName(str, true, obj0.getClassLoader(Native.__\u003CGetCallerID\u003E()), Native.__\u003CGetCallerID\u003E()));
        }
        catch (ClassNotFoundException ex)
        {
          goto label_10;
        }
        return directMappedClass;
label_10:;
      }
      string str1 = new StringBuilder().append("Can't determine class with native methods from the current context (").append((object) obj0).append(")").toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str1);
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/String;)V")]
    [LineNumberTable(new byte[] {165, 247, 103, 117, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void register(Class cls, string libName)
    {
      NativeLibrary instance = NativeLibrary.getInstance(libName, Collections.singletonMap((object) "classloader", (object) cls.getClassLoader(Native.__\u003CGetCallerID\u003E())));
      Native.register(cls, instance);
    }

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/NativeLibrary;)V")]
    [LineNumberTable(new byte[] {166, 6, 108, 102, 103, 113, 137, 120, 111, 9, 232, 70, 109, 109, 111, 103, 137, 105, 106, 106, 106, 106, 99, 106, 99, 159, 91, 223, 45, 202, 126, 115, 229, 70, 113, 120, 130, 116, 130, 113, 110, 130, 177, 109, 103, 127, 0, 106, 103, 101, 159, 45, 216, 112, 178, 237, 70, 255, 85, 71, 113, 116, 197, 127, 2, 121, 133, 127, 5, 130, 255, 8, 22, 235, 109, 125, 159, 0, 105, 106, 113, 99, 226, 61, 232, 71, 145, 255, 6, 69, 242, 59, 251, 75, 2, 97, 255, 45, 159, 143, 235, 160, 116, 109, 110, 109, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void register(Class cls, NativeLibrary lib)
    {
      Method[] declaredMethods = cls.getDeclaredMethods(Native.__\u003CGetCallerID\u003E());
      ArrayList arrayList = new ArrayList();
      Map options = lib.getOptions();
      TypeMapper typeMapper = (TypeMapper) options.get((object) "type-mapper");
      Native.cacheOptions(cls, options, (object) null);
      Method[] methodArray = declaredMethods;
      int length = methodArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Method method = methodArray[index];
        if ((method.getModifiers() & 256) != 0)
          ((List) arrayList).add((object) method);
      }
      long[] numArray1 = new long[((List) arrayList).size()];
      for (int index1 = 0; index1 < numArray1.Length; ++index1)
      {
        Method method = (Method) ((List) arrayList).get(index1);
        string str1 = "(";
        Class returnType = method.getReturnType();
        Class[] parameterTypes = method.getParameterTypes();
        long[] numArray2 = new long[parameterTypes.Length];
        long[] numArray3 = new long[parameterTypes.Length];
        int[] numArray4 = new int[parameterTypes.Length];
        ToNativeConverter[] toNativeConverterArray = new ToNativeConverter[parameterTypes.Length];
        FromNativeConverter fromNativeConverter = (FromNativeConverter) null;
        int conversion1 = Native.getConversion(returnType, typeMapper);
        int num1 = 0;
        long num2;
        long peer1;
        switch (conversion1)
        {
          case -1:
            string str2 = new StringBuilder().append((object) returnType).append(" is not a supported return type (in method ").append(method.getName()).append(" in ").append((object) cls).append(")").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str2);
          case 3:
            num2 = peer1 = Structure.FFIType.get((object) ClassLiteral<Pointer>.Value).peer;
            break;
          case 4:
            num2 = Structure.FFIType.get((object) ClassLiteral<Pointer>.Value).peer;
            peer1 = Structure.FFIType.get((object) returnType).peer;
            break;
          case 17:
          case 18:
          case 19:
          case 21:
          case 22:
            num2 = Structure.FFIType.get((object) ClassLiteral<Pointer>.Value).peer;
            peer1 = Structure.FFIType.get((object) NativeMappedConverter.getInstance(returnType).nativeType()).peer;
            break;
          case 23:
          case 24:
          case 25:
            fromNativeConverter = typeMapper.getFromNativeConverter(returnType);
            num2 = Structure.FFIType.get(!returnType.isPrimitive() ? (object) (Class) ClassLiteral<Pointer>.Value : (object) returnType).peer;
            peer1 = Structure.FFIType.get((object) fromNativeConverter.nativeType()).peer;
            break;
          default:
            num2 = peer1 = Structure.FFIType.get((object) returnType).peer;
            break;
        }
        for (int index2 = 0; index2 < parameterTypes.Length; ++index2)
        {
          Class @class = parameterTypes[index2];
          str1 = new StringBuilder().append(str1).append(Native.getSignature(@class)).toString();
          int conversion2 = Native.getConversion(@class, typeMapper);
          numArray4[index2] = conversion2;
          if (conversion2 == -1)
          {
            string str3 = new StringBuilder().append((object) @class).append(" is not a supported argument type (in method ").append(method.getName()).append(" in ").append((object) cls).append(")").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str3);
          }
          if (conversion2 == 17 || conversion2 == 18 || (conversion2 == 19 || conversion2 == 21))
            @class = NativeMappedConverter.getInstance(@class).nativeType();
          else if (conversion2 == 23 || conversion2 == 24 || conversion2 == 25)
            toNativeConverterArray[index2] = typeMapper.getToNativeConverter(@class);
          switch (conversion2)
          {
            case 0:
              long[] numArray5 = numArray3;
              int index3 = index2;
              long[] numArray6 = numArray2;
              int num3 = index2;
              long peer2 = Structure.FFIType.get((object) @class).peer;
              int index4 = num3;
              long[] numArray7 = numArray6;
              long num4 = peer2;
              numArray7[index4] = peer2;
              numArray5[index3] = num4;
              break;
            case 4:
            case 17:
            case 18:
            case 19:
            case 21:
            case 22:
              numArray2[index2] = Structure.FFIType.get((object) @class).peer;
              numArray3[index2] = Structure.FFIType.get((object) ClassLiteral<Pointer>.Value).peer;
              break;
            case 23:
            case 24:
            case 25:
              numArray3[index2] = Structure.FFIType.get(!@class.isPrimitive() ? (object) (Class) ClassLiteral<Pointer>.Value : (object) @class).peer;
              numArray2[index2] = Structure.FFIType.get((object) toNativeConverterArray[index2].nativeType()).peer;
              break;
            default:
              long[] numArray8 = numArray3;
              int index5 = index2;
              long[] numArray9 = numArray2;
              int num5 = index2;
              long peer3 = Structure.FFIType.get((object) ClassLiteral<Pointer>.Value).peer;
              int index6 = num5;
              long[] numArray10 = numArray9;
              long num6 = peer3;
              numArray10[index6] = peer3;
              numArray8[index5] = num6;
              break;
          }
        }
        string str4 = new StringBuilder().append(new StringBuilder().append(str1).append(")").toString()).append(Native.getSignature(returnType)).toString();
        foreach (Class exceptionType in method.getExceptionTypes())
        {
          if (((Class) ClassLiteral<LastErrorException>.Value).isAssignableFrom(exceptionType))
          {
            num1 = 1;
            break;
          }
        }
        Function function = lib.getFunction(method.getName(), method);
        try
        {
          numArray1[index1] = Native.registerMethod(cls, method.getName(), str4, numArray4, numArray3, numArray2, conversion1, num2, peer1, method, function.peer, function.getCallingConvention(), num1 != 0, toNativeConverterArray, fromNativeConverter, function.encoding);
          continue;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchMethodError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
        string str5 = new StringBuilder().append("No method ").append(method.getName()).append(" with signature ").append(str4).append(" in ").append((object) cls).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsatisfiedLinkError(str5);
      }
      lock (Native.registeredClasses)
      {
        Native.registeredClasses.put((object) cls, (object) numArray1);
        Native.registeredLibraries.put((object) cls, (object) lib);
      }
    }

    [Modifiers]
    [Signature("(Ljava/lang/Class<*>;[J)V")]
    private static void unregister([In] Class obj0, [In] long[] obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eunregister\u0028Ljava\u002Flang\u002FClass\u003B\u005BJ\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eunregister\u0028Ljava\u002Flang\u002FClass\u003B\u005BJ\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (unregister), "(Ljava/lang/Class;[J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, IntPtr)>) Native.__\u003Cjniptr\u003Eunregister\u0028Ljava\u002Flang\u002FClass\u003B\u005BJ\u0029V)(num2, num3, num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Signature("(Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {165, 54, 108, 113, 99, 103, 108, 140, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unregister(Class cls)
    {
      lock (Native.registeredClasses)
      {
        long[] numArray = (long[]) Native.registeredClasses.get((object) cls);
        if (numArray == null)
          return;
        Native.unregister(cls, numArray);
        Native.registeredClasses.remove((object) cls);
        Native.registeredLibraries.remove((object) cls);
      }
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {165, 78, 104, 159, 6, 107, 115, 115, 115, 115, 115, 115, 115, 115, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getSignature([In] Class obj0)
    {
      if (obj0.isArray())
        return new StringBuilder().append("[").append(Native.getSignature(obj0.getComponentType())).toString();
      if (obj0.isPrimitive())
      {
        if (object.ReferenceEquals((object) obj0, (object) Void.TYPE))
          return "V";
        if (object.ReferenceEquals((object) obj0, (object) Boolean.TYPE))
          return "Z";
        if (object.ReferenceEquals((object) obj0, (object) Byte.TYPE))
          return "B";
        if (object.ReferenceEquals((object) obj0, (object) Short.TYPE))
          return "S";
        if (object.ReferenceEquals((object) obj0, (object) Character.TYPE))
          return "C";
        if (object.ReferenceEquals((object) obj0, (object) Integer.TYPE))
          return "I";
        if (object.ReferenceEquals((object) obj0, (object) Long.TYPE))
          return "J";
        if (object.ReferenceEquals((object) obj0, (object) Float.TYPE))
          return "F";
        if (object.ReferenceEquals((object) obj0, (object) Double.TYPE))
          return "D";
      }
      return new StringBuilder().append("L").append(Native.replace(".", "/", obj0.getName())).append(";").toString();
    }

    [LineNumberTable(new byte[] {165, 97, 134, 104, 100, 104, 162, 111, 104, 144, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string replace([In] string obj0, [In] string obj1, [In] string obj2)
    {
      StringBuilder stringBuilder = new StringBuilder();
      while (true)
      {
        int num = String.instancehelper_indexOf(obj2, obj0);
        if (num != -1)
        {
          stringBuilder.append(String.instancehelper_substring(obj2, 0, num));
          stringBuilder.append(obj1);
          obj2 = String.instancehelper_substring(obj2, num + String.instancehelper_length(obj0));
        }
        else
          break;
      }
      stringBuilder.append(obj2);
      return stringBuilder.toString();
    }

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/TypeMapper;)I")]
    [LineNumberTable(new byte[] {165, 145, 121, 121, 121, 121, 118, 118, 118, 118, 148, 102, 104, 104, 99, 103, 109, 131, 109, 131, 131, 99, 103, 109, 131, 109, 131, 195, 109, 130, 109, 130, 109, 131, 111, 130, 109, 109, 130, 130, 107, 127, 91, 99, 98, 98, 98, 99, 99, 99, 195, 104, 147, 109, 131, 109, 131, 109, 131, 109, 108, 109, 131, 109, 131, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getConversion([In] Class obj0, [In] TypeMapper obj1)
    {
      if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Boolean>.Value))
        obj0 = (Class) Boolean.TYPE;
      else if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Byte>.Value))
        obj0 = (Class) Byte.TYPE;
      else if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Short>.Value))
        obj0 = (Class) Short.TYPE;
      else if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Character>.Value))
        obj0 = (Class) Character.TYPE;
      else if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Integer>.Value))
        obj0 = (Class) Integer.TYPE;
      else if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Long>.Value))
        obj0 = (Class) Long.TYPE;
      else if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Float>.Value))
        obj0 = (Class) Float.TYPE;
      else if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Double>.Value))
        obj0 = (Class) Double.TYPE;
      else if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Void>.Value))
        obj0 = (Class) Void.TYPE;
      if (obj1 != null)
      {
        FromNativeConverter fromNativeConverter = obj1.getFromNativeConverter(obj0);
        ToNativeConverter toNativeConverter = obj1.getToNativeConverter(obj0);
        if (fromNativeConverter != null)
        {
          Class @class = fromNativeConverter.nativeType();
          if (object.ReferenceEquals((object) @class, (object) ClassLiteral<String>.Value))
            return 24;
          return object.ReferenceEquals((object) @class, (object) ClassLiteral<WString>.Value) ? 25 : 23;
        }
        if (toNativeConverter != null)
        {
          Class @class = toNativeConverter.nativeType();
          if (object.ReferenceEquals((object) @class, (object) ClassLiteral<String>.Value))
            return 24;
          return object.ReferenceEquals((object) @class, (object) ClassLiteral<WString>.Value) ? 25 : 23;
        }
      }
      if (((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(obj0))
        return 1;
      if (object.ReferenceEquals((object) ClassLiteral<String>.Value, (object) obj0))
        return 2;
      if (((Class) ClassLiteral<WString>.Value).isAssignableFrom(obj0))
        return 20;
      if (Platform.__\u003C\u003EHAS_BUFFERS && Native.Buffers.isBuffer(obj0))
        return 5;
      if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj0))
        return ((Class) ClassLiteral<Structure.ByValue>.Value).isAssignableFrom(obj0) ? 4 : 3;
      if (obj0.isArray())
      {
        switch (String.instancehelper_charAt(obj0.getName(), 1))
        {
          case 'B':
            return 6;
          case 'C':
            return 8;
          case 'D':
            return 12;
          case 'F':
            return 11;
          case 'I':
            return 9;
          case 'J':
            return 10;
          case 'S':
            return 7;
          case 'Z':
            return 13;
        }
      }
      if (obj0.isPrimitive())
        return object.ReferenceEquals((object) obj0, (object) Boolean.TYPE) ? 14 : 0;
      if (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj0))
        return 15;
      if (((Class) ClassLiteral<IntegerType>.Value).isAssignableFrom(obj0))
        return 21;
      if (((Class) ClassLiteral<PointerType>.Value).isAssignableFrom(obj0))
        return 22;
      if (!((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(obj0))
        return -1;
      Class class1 = NativeMappedConverter.getInstance(obj0).nativeType();
      if (object.ReferenceEquals((object) class1, (object) ClassLiteral<String>.Value))
        return 18;
      return object.ReferenceEquals((object) class1, (object) ClassLiteral<WString>.Value) ? 19 : 17;
    }

    [Modifiers]
    [Signature("(Ljava/lang/Class<*>;Ljava/lang/String;Ljava/lang/String;[I[J[JIJJLjava/lang/reflect/Method;JIZ[Lcom/sun/jna/ToNativeConverter;Lcom/sun/jna/FromNativeConverter;Ljava/lang/String;)J")]
    private static long registerMethod(
      [In] Class obj0,
      [In] string obj1,
      [In] string obj2,
      [In] int[] obj3,
      [In] long[] obj4,
      [In] long[] obj5,
      [In] int obj6,
      [In] long obj7,
      [In] long obj8,
      [In] Method obj9,
      [In] long obj10,
      [In] int obj11,
      [In] bool obj12,
      [In] ToNativeConverter[] obj13,
      [In] FromNativeConverter obj14,
      [In] string obj15)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EregisterMethod\u0028Ljava\u002Flang\u002FClass\u003BLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u005BI\u005BJ\u005BJIJJLjava\u002Flang\u002Freflect\u002FMethod\u003BJIZ\u005BLcom\u002Fsun\u002Fjna\u002FToNativeConverter\u003BLcom\u002Fsun\u002Fjna\u002FFromNativeConverter\u003BLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EregisterMethod\u0028Ljava\u002Flang\u002FClass\u003BLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u005BI\u005BJ\u005BJIJJLjava\u002Flang\u002Freflect\u002FMethod\u003BJIZ\u005BLcom\u002Fsun\u002Fjna\u002FToNativeConverter\u003BLcom\u002Fsun\u002Fjna\u002FFromNativeConverter\u003BLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (registerMethod), "(Ljava/lang/Class;Ljava/lang/String;Ljava/lang/String;[I[J[JIJJLjava/lang/reflect/Method;JIZ[Lcom/sun/jna/ToNativeConverter;Lcom/sun/jna/FromNativeConverter;Ljava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        IntPtr num6 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj2);
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        IntPtr num8 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj4);
        IntPtr num9 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj5);
        int num10 = obj6;
        long num11 = obj7;
        long num12 = obj8;
        IntPtr num13 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj9);
        long num14 = obj10;
        int num15 = obj11;
        int num16 = obj12 ? 1 : 0;
        IntPtr num17 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj13);
        IntPtr num18 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj14);
        IntPtr num19 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj15);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, int, long, long, IntPtr, long, int, bool, IntPtr, IntPtr, IntPtr)>) Native.__\u003Cjniptr\u003EregisterMethod\u0028Ljava\u002Flang\u002FClass\u003BLjava\u002Flang\u002FString\u003BLjava\u002Flang\u002FString\u003B\u005BI\u005BJ\u005BJIJJLjava\u002Flang\u002Freflect\u002FMethod\u003BJIZ\u005BLcom\u002Fsun\u002Fjna\u002FToNativeConverter\u003BLcom\u002Fsun\u002Fjna\u002FFromNativeConverter\u003BLjava\u002Flang\u002FString\u003B\u0029J)(num2, num3, num4, (bool) num5, (int) num6, (long) num7, num8, (long) num9, (long) num10, (int) num11, (IntPtr) num12, num13, (IntPtr) num14, (IntPtr) num15, (IntPtr) num16, num17, num18, num19);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static string getNativeVersion()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetNativeVersion\u0028\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetNativeVersion\u0028\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getNativeVersion), "()Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num4 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr)>) Native.__\u003Cjniptr\u003EgetNativeVersion\u0028\u0029Ljava\u002Flang\u002FString\u003B)(num2, num3);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static string getAPIChecksum()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetAPIChecksum\u0028\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetAPIChecksum\u0028\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getAPIChecksum), "()Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num4 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr)>) Native.__\u003Cjniptr\u003EgetAPIChecksum\u0028\u0029Ljava\u002Flang\u002FString\u003B)(num2, num3);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static void invokeStructure(
      [In] Function obj0,
      [In] long obj1,
      [In] int obj2,
      [In] object[] obj3,
      [In] long obj4,
      [In] long obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EinvokeStructure\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003BJJ\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EinvokeStructure\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003BJJ\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (invokeStructure), "(Lcom/sun/jna/Function;JI[Ljava/lang/Object;JJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        int num6 = obj2;
        IntPtr num7 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj3);
        long num8 = obj4;
        long num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, IntPtr, long, int, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EinvokeStructure\u0028Lcom\u002Fsun\u002Fjna\u002FFunction\u003BJI\u005BLjava\u002Flang\u002FObject\u003BJJ\u0029V)((long) num2, (long) num3, num4, (int) num5, (long) num6, num7, (IntPtr) num8, (IntPtr) num9);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long open([In] string obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eopen\u0028Ljava\u002Flang\u002FString\u003BI\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eopen\u0028Ljava\u002Flang\u002FString\u003BI\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (open), "(Ljava/lang/String;I)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr, int)>) Native.__\u003Cjniptr\u003Eopen\u0028Ljava\u002Flang\u002FString\u003BI\u0029J)((int) num2, num3, num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static long _getPointer([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003E_getPointer\u0028J\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003E_getPointer\u0028J\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (_getPointer), "(J)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) Native.__\u003Cjniptr\u003E_getPointer\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static byte[] getStringBytes([In] Pointer obj0, [In] long obj1, [In] long obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetStringBytes\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029\u005BB == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetStringBytes\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029\u005BB = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getStringBytes), "(Lcom/sun/jna/Pointer;JJ)[B");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        long num5 = obj1;
        long num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num7 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetStringBytes\u0028Lcom\u002Fsun\u002Fjna\u002FPointer\u003BJJ\u0029\u005BB)((long) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
        return (byte[]) ((JNI.Frame) ref local).UnwrapLocalRef(num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static void setDetachState([In] bool obj0, [In] long obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetDetachState\u0028ZJ\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetDetachState\u0028ZJ\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setDetachState), "(ZJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        int num4 = obj0 ? 1 : 0;
        long num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, bool, long)>) Native.__\u003Cjniptr\u003EsetDetachState\u0028ZJ\u0029V)((long) num2, (bool) num3, (IntPtr) num4, (IntPtr) num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {162, 210, 140, 215, 2, 97, 223, 10, 112, 107, 134, 109, 108, 105, 127, 49, 105, 103, 159, 6, 140, 103, 159, 6, 109, 108, 103, 103, 159, 27, 97, 225, 70, 138, 110, 103, 137, 103, 135, 127, 10, 103, 159, 6, 145, 103, 159, 6, 109, 108, 103, 103, 159, 31, 97, 98, 223, 28, 133, 143, 103, 159, 5, 107, 103, 159, 5, 129, 161, 108, 167, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void loadNativeDispatchLibrary()
    {
      if (!Boolean.getBoolean("jna.nounpack"))
      {
        IOException ioException1;
        try
        {
          Native.removeTemporaryFiles();
          goto label_4;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        IOException ioException2 = ioException1;
        java.lang.System.err.println(new StringBuilder().append("JNA Warning: IOException removing temporary files: ").append(Throwable.instancehelper_getMessage((Exception) ioException2)).toString());
      }
label_4:
      string property1 = java.lang.System.getProperty("jna.boot.library.name", "jnidispatch");
      string property2 = java.lang.System.getProperty("jna.boot.library.path");
      if (property2 != null)
      {
        StringTokenizer stringTokenizer = new StringTokenizer(property2, (string) File.pathSeparator);
        while (stringTokenizer.hasMoreTokens())
        {
          string str1 = stringTokenizer.nextToken();
          File.__\u003Cclinit\u003E();
          File file1 = new File(str1);
          string str2 = java.lang.System.mapLibraryName(property1);
          object obj1 = (object) ".jnilib";
          object obj2 = (object) ".dylib";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj2;
          CharSequence charSequence2 = charSequence1;
          object obj3 = obj1;
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence3 = charSequence1;
          string str3 = String.instancehelper_replace(str2, charSequence2, charSequence3);
          File file2 = new File(file1, str3);
          string absolutePath = file2.getAbsolutePath();
          if (Native.DEBUG_JNA_LOAD)
            java.lang.System.@out.println(new StringBuilder().append("Looking in ").append(absolutePath).toString());
          if (file2.exists())
          {
            try
            {
              if (Native.DEBUG_JNA_LOAD)
                java.lang.System.@out.println(new StringBuilder().append("Trying ").append(absolutePath).toString());
              java.lang.System.setProperty("jnidispatch.path", absolutePath);
              java.lang.System.load(absolutePath, Native.__\u003CGetCallerID\u003E());
              Native.jnidispatchPath = absolutePath;
              if (!Native.DEBUG_JNA_LOAD)
                return;
              java.lang.System.@out.println(new StringBuilder().append("Found jnidispatch at ").append(absolutePath).toString());
              return;
            }
            catch (Exception ex)
            {
              if (ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
                throw;
            }
          }
          if (Platform.isMac())
          {
            string str4;
            string str5;
            if (String.instancehelper_endsWith(absolutePath, "dylib"))
            {
              str4 = "dylib";
              str5 = "jnilib";
            }
            else
            {
              str4 = "jnilib";
              str5 = "dylib";
            }
            string str6 = new StringBuilder().append(String.instancehelper_substring(absolutePath, 0, String.instancehelper_lastIndexOf(absolutePath, str4))).append(str5).toString();
            if (Native.DEBUG_JNA_LOAD)
              java.lang.System.@out.println(new StringBuilder().append("Looking in ").append(str6).toString());
            if (new File(str6).exists())
            {
              UnsatisfiedLinkError unsatisfiedLinkError1;
              try
              {
                if (Native.DEBUG_JNA_LOAD)
                  java.lang.System.@out.println(new StringBuilder().append("Trying ").append(str6).toString());
                java.lang.System.setProperty("jnidispatch.path", str6);
                java.lang.System.load(str6, Native.__\u003CGetCallerID\u003E());
                Native.jnidispatchPath = str6;
                if (!Native.DEBUG_JNA_LOAD)
                  return;
                java.lang.System.@out.println(new StringBuilder().append("Found jnidispatch at ").append(str6).toString());
                return;
              }
              catch (Exception ex)
              {
                M0 m0 = ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 0);
                if (m0 == null)
                  throw;
                else
                  unsatisfiedLinkError1 = (UnsatisfiedLinkError) m0;
              }
              UnsatisfiedLinkError unsatisfiedLinkError2 = unsatisfiedLinkError1;
              java.lang.System.err.println(new StringBuilder().append("File found at ").append(str6).append(" but not loadable: ").append(Throwable.instancehelper_getMessage((Exception) unsatisfiedLinkError2)).toString());
            }
          }
        }
      }
      if (!Boolean.getBoolean("jna.nosys"))
      {
        try
        {
          if (Native.DEBUG_JNA_LOAD)
            java.lang.System.@out.println(new StringBuilder().append("Trying (via loadLibrary) ").append(property1).toString());
          java.lang.System.loadLibrary(property1, Native.__\u003CGetCallerID\u003E());
          if (!Native.DEBUG_JNA_LOAD)
            return;
          java.lang.System.@out.println("Found jnidispatch on system path");
          return;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }
      if (!Boolean.getBoolean("jna.noclasspath"))
      {
        Native.loadNativeDispatchLibraryFromClasspath();
      }
      else
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsatisfiedLinkError("Unable to locate JNA native support library");
      }
    }

    [LineNumberTable(new byte[] {117, 108, 108, 106, 162, 105, 105, 106, 138, 100, 162, 102, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isCompatibleVersion([In] string obj0, [In] string obj1)
    {
      string[] strArray1 = String.instancehelper_split(obj0, "\\.");
      string[] strArray2 = String.instancehelper_split(obj1, "\\.");
      if (strArray1.Length < 3 || strArray2.Length < 3)
        return false;
      int num1 = Integer.parseInt(strArray1[0]);
      int num2 = Integer.parseInt(strArray2[0]);
      int num3 = Integer.parseInt(strArray1[1]);
      int num4 = Integer.parseInt(strArray2[1]);
      return num1 == num2 && num3 <= num4;
    }

    [Modifiers]
    private static int @sizeof([In] int obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Esizeof\u0028I\u0029I == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Esizeof\u0028I\u0029I = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (@sizeof), "(I)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        int num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, int)>) Native.__\u003Cjniptr\u003Esizeof\u0028I\u0029I)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    private static void initIDs()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EinitIDs\u0028\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EinitIDs\u0028\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (initIDs), "()V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr)>) Native.__\u003Cjniptr\u003EinitIDs\u0028\u0029V)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void setProtected(bool b)
    {
      lock ((object) ClassLiteral<Native>.Value)
      {
        JNI.Frame frame = new JNI.Frame();
        if (Native.__\u003Cjniptr\u003EsetProtected\u0028Z\u0029V == IntPtr.Zero)
          Native.__\u003Cjniptr\u003EsetProtected\u0028Z\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setProtected), "(Z)V");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
          int num4 = b ? 1 : 0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, IntPtr, bool)>) Native.__\u003Cjniptr\u003EsetProtected\u0028Z\u0029V)((bool) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }
    }

    [Obsolete]
    [LineNumberTable(153)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float parseVersion(string v) => Float.parseFloat(String.instancehelper_substring(v, 0, String.instancehelper_lastIndexOf(v, ".")));

    [LineNumberTable(272)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Native()
    {
    }

    [Modifiers]
    public static bool isProtected()
    {
      lock ((object) ClassLiteral<Native>.Value)
      {
        JNI.Frame frame = new JNI.Frame();
        if (Native.__\u003Cjniptr\u003EisProtected\u0028\u0029Z == IntPtr.Zero)
          Native.__\u003Cjniptr\u003EisProtected\u0028\u0029Z = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (isProtected), "()Z");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr)>) Native.__\u003Cjniptr\u003EisProtected\u0028\u0029Z)(num2, num3);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }
    }

    [Obsolete]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setPreserveLastError(bool enable)
    {
    }

    [Obsolete]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool getPreserveLastError() => true;

    [Throws(new string[] {"java.awt.HeadlessException"})]
    [LineNumberTable(324)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long getWindowID(Window w) => Native.AWT.getWindowID(w);

    [Throws(new string[] {"java.awt.HeadlessException"})]
    [LineNumberTable(334)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long getComponentID(Component c) => Native.AWT.getComponentID((object) c);

    [Throws(new string[] {"java.awt.HeadlessException"})]
    [LineNumberTable(344)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pointer getWindowPointer(Window w)
    {
      Pointer.__\u003Cclinit\u003E();
      return new Pointer(Native.AWT.getWindowID(w));
    }

    [Throws(new string[] {"java.awt.HeadlessException"})]
    [LineNumberTable(354)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pointer getComponentPointer(Component c)
    {
      Pointer.__\u003Cclinit\u003E();
      return new Pointer(Native.AWT.getComponentID((object) c));
    }

    [Modifiers]
    internal static long getWindowHandle0([In] Component obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetWindowHandle0\u0028Ljava\u002Fawt\u002FComponent\u003B\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetWindowHandle0\u0028Ljava\u002Fawt\u002FComponent\u003B\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getWindowHandle0), "(Ljava/awt/Component;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, IntPtr)>) Native.__\u003Cjniptr\u003EgetWindowHandle0\u0028Ljava\u002Fawt\u002FComponent\u003B\u0029J)(num2, num3, num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(378)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string toString(byte[] buf) => Native.toString(buf, Native.getDefaultStringEncoding());

    [LineNumberTable(new byte[] {161, 59, 99, 102, 101, 98, 226, 61, 230, 71, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string toString(char[] buf)
    {
      int num = buf.Length;
      for (int index = 0; index < num; ++index)
      {
        if (buf[index] == char.MinValue)
        {
          num = index;
          break;
        }
      }
      return num == 0 ? "" : String.newhelper(buf, 0, num);
    }

    [Signature("([C)Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(454)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static List toStringList(char[] buf) => Native.toStringList(buf, 0, buf.Length);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;)TT;")]
    [LineNumberTable(507)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object loadLibrary(Class interfaceClass) => Native.loadLibrary((string) null, interfaceClass);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/util/Map<Ljava/lang/String;*>;)TT;")]
    [LineNumberTable(526)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object loadLibrary(Class interfaceClass, Map options) => Native.loadLibrary((string) null, interfaceClass, options);

    [LineNumberTable(770)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static byte[] getBytes([In] string obj0) => Native.getBytes(obj0, Native.getDefaultStringEncoding());

    [LineNumberTable(803)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] toByteArray(string s) => Native.toByteArray(s, Native.getDefaultStringEncoding());

    [LineNumberTable(new byte[] {162, 198, 103, 106, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static char[] toCharArray(string s)
    {
      char[] charArray = String.instancehelper_toCharArray(s);
      char[] chArray = new char[charArray.Length + 1];
      ByteCodeHelper.arraycopy_primitive_2((Array) charArray, 0, (Array) chArray, 0, charArray.Length);
      return chArray;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(983)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static File extractFromResourcePath(string name) => Native.extractFromResourcePath(name, (ClassLoader) null);

    [Modifiers]
    public static int getLastError()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetLastError\u0028\u0029I == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetLastError\u0028\u0029I = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getLastError), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) Native.__\u003Cjniptr\u003EgetLastError\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void setLastError(int i)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EsetLastError\u0028I\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EsetLastError\u0028I\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (setLastError), "(I)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        int num4 = i;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, int)>) Native.__\u003Cjniptr\u003EsetLastError\u0028I\u0029V)((int) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {163, 241, 103, 104, 144, 108, 104, 159, 6, 103, 232, 72, 108, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Library synchronizedLibrary(Library library)
    {
      Class @class = Object.instancehelper_getClass((object) library);
      if (!Proxy.isProxyClass(@class))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Library must be a proxy class");
      }
      InvocationHandler invocationHandler = Proxy.getInvocationHandler((object) library, Native.__\u003CGetCallerID\u003E());
      if (!(invocationHandler is Library.Handler))
      {
        string str = new StringBuilder().append("Unrecognized proxy handler: ").append((object) invocationHandler).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      Native.\u0033 obj = new Native.\u0033((Library.Handler) invocationHandler, library);
      return (Library) Proxy.newProxyInstance(@class.getClassLoader(Native.__\u003CGetCallerID\u003E()), @class.getInterfaces(), (InvocationHandler) obj, Native.__\u003CGetCallerID\u003E());
    }

    [LineNumberTable(new byte[] {164, 23, 108, 162, 112, 245, 77, 124, 99, 142, 156, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getWebStartLibraryPath(string libName)
    {
      if (java.lang.System.getProperty("javawebstart.version") == null)
        return (string) null;
      try
      {
        ClassLoader classLoader = ((Class) ClassLiteral<Native>.Value).getClassLoader(Native.__\u003CGetCallerID\u003E());
        string str = (string) ((Method) AccessController.doPrivileged((PrivilegedAction) new Native.\u0034(), Native.__\u003CGetCallerID\u003E())).invoke((object) classLoader, new object[1]
        {
          (object) libName
        }, Native.__\u003CGetCallerID\u003E());
        if (str != null)
          return new File(str).getParent();
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_8;
      }
      return (string) null;
label_8:
      return (string) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setCallbackExceptionHandler(Callback.UncaughtExceptionHandler eh) => Native.callbackExceptionHandler = eh != null ? eh : Native.DEFAULT_HANDLER;

    [LineNumberTable(new byte[] {164, 222, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void register(string libName) => Native.register(Native.findDirectMappedClass(Native.getCallingClass()), libName);

    [LineNumberTable(new byte[] {164, 232, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void register(NativeLibrary lib) => Native.register(Native.findDirectMappedClass(Native.getCallingClass()), lib);

    [LineNumberTable(new byte[] {165, 25, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setCallbackThreadInitializer(
      Callback cb,
      CallbackThreadInitializer initializer)
    {
      CallbackReference.setCallbackThreadInitializer(cb, initializer);
    }

    [LineNumberTable(new byte[] {165, 46, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unregister() => Native.unregister(Native.findDirectMappedClass(Native.getCallingClass()));

    [Signature("(Ljava/lang/Class<*>;)Z")]
    [LineNumberTable(new byte[] {165, 69, 108, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool registered(Class cls)
    {
      int num;
      lock (Native.registeredClasses)
        num = Native.registeredClasses.containsKey((object) cls) ? 1 : 0;
      return num != 0;
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;)Lcom/sun/jna/NativeMapped;")]
    [LineNumberTable(1841)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeMapped fromNative([In] Class obj0, [In] object obj1) => (NativeMapped) NativeMappedConverter.getInstance(obj0).fromNative(obj1, new FromNativeContext(obj0));

    [LineNumberTable(new byte[] {166, 195, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeMapped fromNative([In] Method obj0, [In] object obj1)
    {
      Class returnType = obj0.getReturnType();
      return (NativeMapped) NativeMappedConverter.getInstance(returnType).fromNative(obj1, (FromNativeContext) new MethodResultContext(returnType, (Function) null, (object[]) null, obj0));
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Class<*>;")]
    [LineNumberTable(1850)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Class nativeType([In] Class obj0) => NativeMappedConverter.getInstance(obj0).nativeType();

    [LineNumberTable(1856)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object toNative([In] ToNativeConverter obj0, [In] object obj1) => obj0.toNative(obj1, new ToNativeContext());

    [LineNumberTable(1860)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object fromNative([In] FromNativeConverter obj0, [In] object obj1, [In] Method obj2) => obj0.fromNative(obj1, (FromNativeContext) new MethodResultContext(obj2.getReturnType(), (Function) null, (object[]) null, obj2));

    [Modifiers]
    public static long ffi_prep_cif(int i1, int i2, long l1, long l2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Effi_prep_cif\u0028IIJJ\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Effi_prep_cif\u0028IIJJ\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (ffi_prep_cif), "(IIJJ)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        int num4 = i1;
        int num5 = i2;
        long num6 = l1;
        long num7 = l2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, int, int, long, long)>) Native.__\u003Cjniptr\u003Effi_prep_cif\u0028IIJJ\u0029J)((long) num2, (long) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void ffi_call(long l1, long l2, long l3, long l4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Effi_call\u0028JJJJ\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Effi_call\u0028JJJJ\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (ffi_call), "(JJJJ)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = l1;
        long num5 = l2;
        long num6 = l3;
        long num7 = l4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, long, long)>) Native.__\u003Cjniptr\u003Effi_call\u0028JJJJ\u0029V)((long) num2, (long) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static long ffi_prep_closure(long l, Native.ffi_callback n)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Effi_prep_closure\u0028JLcom\u002Fsun\u002Fjna\u002FNative\u0024ffi_callback\u003B\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Effi_prep_closure\u0028JLcom\u002Fsun\u002Fjna\u002FNative\u0024ffi_callback\u003B\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (ffi_prep_closure), "(JLcom/sun/jna/Native$ffi_callback;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = l;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) n);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, IntPtr)>) Native.__\u003Cjniptr\u003Effi_prep_closure\u0028JLcom\u002Fsun\u002Fjna\u002FNative\u0024ffi_callback\u003B\u0029J)(num2, (long) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    public static void ffi_free_closure(long l)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Effi_free_closure\u0028J\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Effi_free_closure\u0028J\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (ffi_free_closure), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = l;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) Native.__\u003Cjniptr\u003Effi_free_closure\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int initialize_ffi_type([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Einitialize_ffi_type\u0028J\u0029I == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Einitialize_ffi_type\u0028J\u0029I = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (initialize_ffi_type), "(J)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) Native.__\u003Cjniptr\u003Einitialize_ffi_type\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {166, 229, 102, 102, 102, 107, 100, 109, 105, 100, 109, 105, 127, 2, 107, 100, 109, 105, 127, 5, 127, 9, 57, 133, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void main(string[] args)
    {
      Package package = ((Class) ClassLiteral<Native>.Value).getPackage();
      string str1 = (package == null ? "Java Native Access (JNA)" : package.getSpecificationTitle()) ?? "Java Native Access (JNA)";
      string str2 = (package == null ? "4.4.0" : package.getSpecificationVersion()) ?? "4.4.0";
      java.lang.System.@out.println(new StringBuilder().append(str1).append(" API Version ").append(str2).toString());
      string str3 = (package == null ? "4.4.0 (package information missing)" : package.getImplementationVersion()) ?? "4.4.0 (package information missing)";
      java.lang.System.@out.println(new StringBuilder().append("Version: ").append(str3).toString());
      java.lang.System.@out.println(new StringBuilder().append(" Native: ").append(Native.getNativeVersion()).append(" (").append(Native.getAPIChecksum()).append(")").toString());
      java.lang.System.@out.println(new StringBuilder().append(" Prefix: ").append(Platform.__\u003C\u003ERESOURCE_PREFIX).toString());
    }

    [LineNumberTable(2042)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static long open([In] string obj0) => Native.open(obj0, -1);

    [Modifiers]
    internal static void close([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003Eclose\u0028J\u0029V == IntPtr.Zero)
        Native.__\u003Cjniptr\u003Eclose\u0028J\u0029V = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (close), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) Native.__\u003Cjniptr\u003Eclose\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static long findSymbol([In] long obj0, [In] string obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EfindSymbol\u0028JLjava\u002Flang\u002FString\u003B\u0029J == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EfindSymbol\u0028JLjava\u002Flang\u002FString\u003B\u0029J = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (findSymbol), "(JLjava/lang/String;)J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = obj0;
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr, long, IntPtr)>) Native.__\u003Cjniptr\u003EfindSymbol\u0028JLjava\u002Flang\u002FString\u003B\u0029J)(num2, (long) num3, (IntPtr) num4, num5);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(2140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getString([In] Pointer obj0, [In] long obj1) => Native.getString(obj0, obj1, Native.getDefaultStringEncoding());

    [Modifiers]
    [Obsolete]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    public static ByteBuffer getDirectByteBuffer(long l1, long l2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Native.__\u003Cjniptr\u003EgetDirectByteBuffer\u0028JJ\u0029Ljava\u002Fnio\u002FByteBuffer\u003B == IntPtr.Zero)
        Native.__\u003Cjniptr\u003EgetDirectByteBuffer\u0028JJ\u0029Ljava\u002Fnio\u002FByteBuffer\u003B = JNI.Frame.GetFuncPtr(Native.__\u003CGetCallerID\u003E(), "com/sun/jna/Native", nameof (getDirectByteBuffer), "(JJ)Ljava/nio/ByteBuffer;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Native.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Native>.Value);
        long num4 = l1;
        long num5 = l2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num6 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long, long)>) Native.__\u003Cjniptr\u003EgetDirectByteBuffer\u0028JJ\u0029Ljava\u002Fnio\u002FByteBuffer\u003B)((long) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
        return (ByteBuffer) ((JNI.Frame) ref local).UnwrapLocalRef(num6);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [LineNumberTable(new byte[] {157, 97, 98, 102, 227, 71, 108, 112, 104, 130, 109, 112, 109, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void detach(bool detach)
    {
      int num = detach ? 1 : 0;
      Thread thread = Thread.currentThread();
      if (num != 0)
      {
        Native.nativeThreads.remove((object) thread);
        Pointer pointer = (Pointer) Native.nativeThreadTerminationFlag.get();
        Native.setDetachState(true, 0L);
      }
      else
      {
        if (Native.nativeThreads.containsKey((object) thread))
          return;
        Pointer pointer = (Pointer) Native.nativeThreadTerminationFlag.get();
        Native.nativeThreads.put((object) thread, (object) pointer);
        Native.setDetachState(false, pointer.peer);
      }
    }

    [LineNumberTable(2251)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Pointer getTerminationFlag([In] Thread obj0) => (Pointer) Native.nativeThreads.get((object) obj0);

    [Modifiers]
    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void access\u0024000() => Native.dispose();

    [LineNumberTable(new byte[] {159, 115, 141, 111, 111, 175, 102, 106, 138, 234, 72, 234, 127, 133, 116, 107, 191, 38, 159, 39, 255, 91, 73, 107, 107, 107, 107, 203, 101, 108, 134, 110, 117, 103, 148, 123, 208, 234, 164, 168, 106, 234, 163, 15, 234, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Native()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.Native"))
        return;
      Native.__\u003C\u003EDEFAULT_ENCODING = Charset.defaultCharset().name();
      Native.DEBUG_LOAD = Boolean.getBoolean("jna.debug_load");
      Native.DEBUG_JNA_LOAD = Boolean.getBoolean("jna.debug_load.jna");
      Native.jnidispatchPath = (string) null;
      Native.typeOptions = (Map) new WeakHashMap();
      Native.libraries = (Map) new WeakHashMap();
      Native.DEFAULT_HANDLER = (Callback.UncaughtExceptionHandler) new Native.\u0031();
      Native.callbackExceptionHandler = Native.DEFAULT_HANDLER;
      Native.loadNativeDispatchLibrary();
      if (!Native.isCompatibleVersion("5.1.0", Native.getNativeVersion()))
      {
        string property = java.lang.System.getProperty("line.separator");
        string str = new StringBuilder().append(property).append(property).append("There is an incompatible JNA native library installed on this system").append(property).append("Expected: ").append("5.1.0").append(property).append("Found:    ").append(Native.getNativeVersion()).append(property).append(Native.jnidispatchPath == null ? java.lang.System.getProperty("java.library.path") : new StringBuilder().append("(at ").append(Native.jnidispatchPath).append(")").toString()).append(".").append(property).append("To resolve this issue you may do one of the following:").append(property).append(" - remove or uninstall the offending library").append(property).append(" - set the system property jna.nosys=true").append(property).append(" - set jna.boot.library.path to include the path to the version of the ").append(property).append("   jnidispatch library included with the JNA jar file you are using").append(property).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new Error(str);
      }
      Native.__\u003C\u003EPOINTER_SIZE = Native.@sizeof(0);
      Native.__\u003C\u003ELONG_SIZE = Native.@sizeof(1);
      Native.__\u003C\u003EWCHAR_SIZE = Native.@sizeof(2);
      Native.__\u003C\u003ESIZE_T_SIZE = Native.@sizeof(3);
      Native.__\u003C\u003EBOOL_SIZE = Native.@sizeof(4);
      Native.initIDs();
      if (Boolean.getBoolean("jna.protected"))
        Native.setProtected(true);
      Native.MAX_ALIGNMENT = Platform.isSPARC() || Platform.isWindows() || Platform.isLinux() && (Platform.isARM() || Platform.isPPC()) || (Platform.isAIX() || Platform.isAndroid()) ? 8 : Native.__\u003C\u003ELONG_SIZE;
      Native.MAX_PADDING = !Platform.isMac() || !Platform.isPPC() ? Native.MAX_ALIGNMENT : 8;
      java.lang.System.setProperty("jna.loaded", "true");
      Native.finalizer = (object) new Native.\u0032();
      Native.registeredClasses = (Map) new WeakHashMap();
      Native.registeredLibraries = (Map) new WeakHashMap();
      Native.nativeThreadTerminationFlag = (ThreadLocal) new Native.\u0037();
      Native.nativeThreads = Collections.synchronizedMap((Map) new WeakHashMap());
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Native.__\u003CcallerID\u003E == null)
        Native.__\u003CcallerID\u003E = (CallerID) new Native.__\u003CCallerID\u003E();
      return Native.__\u003CcallerID\u003E;
    }

    [Modifiers]
    public static string DEFAULT_ENCODING
    {
      [HideFromJava] get => Native.__\u003C\u003EDEFAULT_ENCODING;
    }

    [Modifiers]
    public static int POINTER_SIZE
    {
      [HideFromJava] get => Native.__\u003C\u003EPOINTER_SIZE;
    }

    [Modifiers]
    public static int LONG_SIZE
    {
      [HideFromJava] get => Native.__\u003C\u003ELONG_SIZE;
    }

    [Modifiers]
    public static int WCHAR_SIZE
    {
      [HideFromJava] get => Native.__\u003C\u003EWCHAR_SIZE;
    }

    [Modifiers]
    public static int SIZE_T_SIZE
    {
      [HideFromJava] get => Native.__\u003C\u003ESIZE_T_SIZE;
    }

    [Modifiers]
    public static int BOOL_SIZE
    {
      [HideFromJava] get => Native.__\u003C\u003EBOOL_SIZE;
    }

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal sealed class \u0031 : Object, Callback.UncaughtExceptionHandler
    {
      [LineNumberTable(120)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
      }

      [LineNumberTable(new byte[] {73, 127, 15, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void uncaughtException([In] Callback obj0, [In] Exception obj1)
      {
        java.lang.System.err.println(new StringBuilder().append("JNA: Callback ").append((object) obj0).append(" threw the following exception:").toString());
        Throwable.instancehelper_printStackTrace(obj1);
      }
    }

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal sealed class \u0032 : Object
    {
      [LineNumberTable(230)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032() => GC.KeepAlive((object) this);

      [LineNumberTable(new byte[] {160, 119, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void finalize() => Native.access\u0024000();

      [HideFromJava]
      ~\u0032()
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
    }

    [EnclosingMethod(null, "synchronizedLibrary", "(Lcom.sun.jna.Library;)Lcom.sun.jna.Library;")]
    [SpecialName]
    internal sealed class \u0033 : Object, InvocationHandler
    {
      [Modifiers]
      internal Library.Handler val\u0024handler;
      [Modifiers]
      internal Library val\u0024library;

      [LineNumberTable(1132)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Library.Handler obj0, [In] Library obj1)
      {
        this.val\u0024handler = obj0;
        this.val\u0024library = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [Throws(new string[] {"java.lang.Throwable"})]
      [LineNumberTable(new byte[] {163, 253, 114, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object invoke([In] object obj0, [In] Method obj1, [In] object[] obj2)
      {
        object obj;
        lock (this.val\u0024handler.getNativeLibrary())
          obj = this.val\u0024handler.invoke((object) this.val\u0024library, obj1, obj2);
        return obj;
      }
    }

    [Signature("Ljava/lang/Object;Ljava/security/PrivilegedAction<Ljava/lang/reflect/Method;>;")]
    [EnclosingMethod(null, "getWebStartLibraryPath", "(Ljava.lang.String;)Ljava.lang.String;")]
    [SpecialName]
    internal sealed class \u0034 : Object, PrivilegedAction
    {
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;

      [LineNumberTable(1166)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034()
      {
      }

      [LineNumberTable(new byte[] {164, 32, 127, 4, 103, 154, 97})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Method run()
      {
        Method method;
        try
        {
          Method declaredMethod = ((Class) ClassLiteral<ClassLoader>.Value).getDeclaredMethod("findLibrary", new Class[1]
          {
            (Class) ClassLiteral<String>.Value
          }, Native.\u0034.__\u003CGetCallerID\u003E());
          ((AccessibleObject) declaredMethod).setAccessible(true);
          method = declaredMethod;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
          else
            goto label_4;
        }
        return method;
label_4:
        return (Method) null;
      }

      [Modifiers]
      [LineNumberTable(1166)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object run() => (object) this.run();

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (Native.\u0034.__\u003CcallerID\u003E == null)
          Native.\u0034.__\u003CcallerID\u003E = (CallerID) new Native.\u0034.__\u003CCallerID\u003E();
        return Native.\u0034.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [EnclosingMethod(null, "removeTemporaryFiles", "()V")]
    [SpecialName]
    internal sealed class \u0035 : Object, FilenameFilter
    {
      [LineNumberTable(1235)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035()
      {
      }

      [LineNumberTable(1238)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool accept([In] File obj0, [In] string obj1) => String.instancehelper_endsWith(obj1, ".x") && String.instancehelper_startsWith(obj1, "jna");
    }

    [EnclosingMethod(null, "getCallingClass", "()Ljava.lang.Class;")]
    [SpecialName]
    internal sealed class \u0036 : SecurityManager
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(1397)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036()
      {
      }

      [Signature("()[Ljava/lang/Class<*>;")]
      [LineNumberTable(1400)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Class[] getClassContext() => base.getClassContext();

      [HideFromJava]
      static \u0036() => SecurityManager.__\u003Cclinit\u003E();
    }

    [Signature("Ljava/lang/ThreadLocal<Lcom/sun/jna/Memory;>;")]
    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal sealed class \u0037 : ThreadLocal
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(2207)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037()
      {
      }

      [LineNumberTable(new byte[] {168, 48, 104, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual Memory initialValue()
      {
        Memory memory = new Memory(4L);
        memory.clear();
        return memory;
      }

      [Modifiers]
      [LineNumberTable(2207)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual object initialValue() => (object) this.initialValue();

      [HideFromJava]
      static \u0037() => ThreadLocal.__\u003Cclinit\u003E();
    }

    [InnerClass]
    internal class AWT : Object
    {
      [Throws(new string[] {"java.awt.HeadlessException"})]
      [LineNumberTable(2267)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static long getWindowID([In] Window obj0) => Native.AWT.getComponentID((object) obj0);

      [Throws(new string[] {"java.awt.HeadlessException"})]
      [LineNumberTable(new byte[] {168, 110, 103, 144, 103, 104, 144, 104, 144, 108, 113, 104, 240, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static long getComponentID([In] object obj0)
      {
        if (GraphicsEnvironment.isHeadless())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new HeadlessException("No native windows when headless");
        }
        Component component = (Component) obj0;
        if (component.isLightweight())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Component must be heavyweight");
        }
        if (!component.isDisplayable())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Component must be displayable");
        }
        if (Platform.isX11() && String.instancehelper_startsWith(java.lang.System.getProperty("java.version"), "1.4") && !component.isVisible())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Component must be visible");
        }
        return Native.getWindowHandle0(component);
      }

      [LineNumberTable(2265)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private AWT()
      {
      }
    }

    [InnerClass]
    internal class Buffers : Object
    {
      [Signature("(Ljava/lang/Class<*>;)Z")]
      [LineNumberTable(2258)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool isBuffer([In] Class obj0) => ((Class) ClassLiteral<Buffer>.Value).isAssignableFrom(obj0);

      [LineNumberTable(2256)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Buffers()
      {
      }
    }

    public interface ffi_callback
    {
      void invoke(long l1, long l2, long l3);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
