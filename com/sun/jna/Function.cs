// Decompiled with JetBrains decompiler
// Type: com.sun.jna.Function
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
  public class Function : Pointer
  {
    public const int MAX_NARGS = 256;
    public const int C_CONVENTION = 0;
    public const int ALT_CONVENTION = 63;
    private const int MASK_CC = 63;
    public const int THROW_LAST_ERROR = 64;
    public const int USE_VARARGS = 384;
    [Modifiers]
    internal static Integer INTEGER_TRUE;
    [Modifiers]
    internal static Integer INTEGER_FALSE;
    private NativeLibrary library;
    [Modifiers]
    private string functionName;
    [Modifiers]
    internal string encoding;
    [Modifiers]
    internal int callFlags;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;*>;")]
    internal Map options;
    internal const string OPTION_INVOKING_METHOD = "invoking-method";
    [Modifiers]
    private static VarArgsChecker IS_VARARGS;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(832)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Boolean valueOf([In] bool obj0) => obj0 ? (Boolean) Boolean.TRUE : (Boolean) Boolean.FALSE;

    [LineNumberTable(new byte[] {160, 150, 104, 106, 141, 144, 108, 103, 108, 107, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Function([In] Pointer obj0, [In] int obj1, [In] string obj2)
    {
      Function function = this;
      this.checkCallingConvention(obj1 & 63);
      if (obj0 == null || obj0.peer == 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("Function address may not be null");
      }
      this.functionName = obj0.toString();
      this.callFlags = obj1;
      this.peer = obj0.peer;
      this.options = (Map) Collections.EMPTY_MAP;
      this.encoding = obj2 == null ? Native.getDefaultStringEncoding() : obj2;
    }

    [LineNumberTable(793)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isVarArgs([In] Method obj0) => Function.IS_VARARGS.isVarArgs(obj0);

    [LineNumberTable(new byte[] {162, 139, 110, 103, 109, 113, 140, 103, 106, 23, 230, 69, 108, 110, 239, 70, 105, 164})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object[] concatenateVarArgs([In] object[] obj0)
    {
      if (obj0 != null && obj0.Length > 0)
      {
        object obj = obj0[obj0.Length - 1];
        Class @class = obj == null ? (Class) null : Object.instancehelper_getClass(obj);
        if (@class != null && @class.isArray())
        {
          object[] objArray1 = (object[]) obj;
          for (int index = 0; index < objArray1.Length; ++index)
          {
            if (objArray1[index] is Float)
              objArray1[index] = (object) Double.valueOf((double) ((Float) objArray1[index]).floatValue());
          }
          object[] objArray2 = new object[obj0.Length + objArray1.Length];
          ByteCodeHelper.arraycopy((object) obj0, 0, (object) objArray2, 0, obj0.Length - 1);
          ByteCodeHelper.arraycopy((object) objArray1, 0, (object) objArray2, obj0.Length - 1, objArray1.Length);
          objArray2[objArray2.Length - 1] = (object) null;
          obj0 = objArray2;
        }
      }
      return obj0;
    }

    [Signature("(Ljava/lang/Class<*>;[Ljava/lang/Object;Ljava/util/Map<Ljava/lang/String;*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {160, 192, 113, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object invoke(Class returnType, object[] inArgs, Map options)
    {
      Method method = (Method) options.get((object) "invoking-method");
      Class[] classArray = method == null ? (Class[]) null : method.getParameterTypes();
      return this.invoke(method, classArray, returnType, inArgs, options);
    }

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Function getFunction(Pointer p, int callFlags, string encoding) => new Function(p, callFlags, encoding);

    [Throws(new string[] {"java.lang.IllegalArgumentException"})]
    [LineNumberTable(new byte[] {160, 167, 103, 191, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkCallingConvention([In] int obj0)
    {
      if ((obj0 & 63) != obj0)
      {
        string str = new StringBuilder().append("Unrecognized calling convention: ").append(obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [Signature("(Ljava/lang/reflect/Method;[Ljava/lang/Class<*>;Ljava/lang/Class<*>;[Ljava/lang/Object;Ljava/util/Map<Ljava/lang/String;*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {160, 205, 103, 100, 106, 144, 105, 172, 114, 119, 114, 115, 105, 148, 176, 242, 58, 232, 73, 99, 99, 109, 104, 100, 105, 101, 105, 105, 206, 142, 132, 99, 142, 139, 223, 9, 103, 109, 103, 100, 101, 105, 108, 145, 110, 110, 110, 107, 118, 110, 110, 106, 114, 19, 232, 69, 98, 115, 241, 42, 235, 91})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object invoke(
      [In] Method obj0,
      [In] Class[] obj1,
      [In] Class obj2,
      [In] object[] obj3,
      [In] Map obj4)
    {
      object[] objArray = new object[0];
      if (obj3 != null)
      {
        if (obj3.Length > 256)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new UnsupportedOperationException("Maximum argument count is 256");
        }
        objArray = new object[obj3.Length];
        ByteCodeHelper.arraycopy((object) obj3, 0, (object) objArray, 0, objArray.Length);
      }
      TypeMapper typeMapper = (TypeMapper) obj4.get((object) "type-mapper");
      int num1 = ((Boolean) Boolean.TRUE).equals(obj4.get((object) "allow-objects")) ? 1 : 0;
      int num2 = objArray.Length <= 0 || obj0 == null ? 0 : (Function.isVarArgs(obj0) ? 1 : 0);
      int num3 = objArray.Length <= 0 || obj0 == null ? 0 : Function.fixedArgs(obj0);
      for (int index = 0; index < objArray.Length; ++index)
      {
        Class @class = obj0 == null ? (Class) null : (num2 == 0 || index < obj1.Length - 1 ? obj1[index] : obj1[obj1.Length - 1].getComponentType());
        objArray[index] = this.convertArgument(objArray, index, obj0, typeMapper, num1 != 0, @class);
      }
      Class class1 = obj2;
      object obj5 = (object) null;
      if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(obj2))
      {
        NativeMappedConverter instance = NativeMappedConverter.getInstance(obj2);
        obj5 = (object) instance;
        class1 = instance.nativeType();
      }
      else if (typeMapper != null)
      {
        obj5 = (object) typeMapper.getFromNativeConverter(obj2);
        if ((FromNativeConverter) obj5 != null)
          class1 = ((FromNativeConverter) obj5).nativeType();
      }
      object obj6 = this.invoke(objArray, class1, num1 != 0, num3);
      if (obj5 != null)
      {
        FunctionResultContext functionResultContext = obj0 == null ? new FunctionResultContext(obj2, this, obj3) : (FunctionResultContext) new MethodResultContext(obj2, this, obj3, obj0);
        object obj7 = obj5;
        object obj8 = obj6;
        FromNativeContext fromNativeContext = (FromNativeContext) functionResultContext;
        object obj9 = obj8;
        FromNativeConverter fromNativeConverter1;
        if (obj7 != null)
          fromNativeConverter1 = obj7 is FromNativeConverter fromNativeConverter5 ? fromNativeConverter5 : throw new IncompatibleClassChangeError();
        else
          fromNativeConverter1 = (FromNativeConverter) null;
        object obj10 = obj9;
        FromNativeContext fnc = fromNativeContext;
        obj6 = fromNativeConverter1.fromNative(obj10, fnc);
      }
      if (obj3 != null)
      {
        for (int index1 = 0; index1 < obj3.Length; ++index1)
        {
          object obj7 = obj3[index1];
          if (obj7 != null)
          {
            if (obj7 is Structure)
            {
              if (!(obj7 is Structure.ByValue))
                ((Structure) obj7).autoRead();
            }
            else if (objArray[index1] is Function.PostCallRead)
            {
              ((Function.PostCallRead) objArray[index1]).read();
              if (objArray[index1] is Function.PointerArray)
              {
                Function.PointerArray pointerArray = (Function.PointerArray) objArray[index1];
                if (((Class) ClassLiteral<Structure.ByReference[]>.Value).isAssignableFrom(Object.instancehelper_getClass(obj7)))
                {
                  Class componentType = Object.instancehelper_getClass(obj7).getComponentType();
                  Structure[] structureArray = (Structure[]) obj7;
                  for (int index2 = 0; index2 < structureArray.Length; ++index2)
                  {
                    Pointer pointer = pointerArray.getPointer((long) (Pointer.__\u003C\u003ESIZE * index2));
                    structureArray[index2] = Structure.updateStructureByReference(componentType, structureArray[index2], pointer);
                  }
                }
              }
            }
            else if (((Class) ClassLiteral<Structure[]>.Value).isAssignableFrom(Object.instancehelper_getClass(obj7)))
              Structure.autoRead((Structure[]) obj7);
          }
        }
      }
      return obj6;
    }

    [LineNumberTable(798)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int fixedArgs([In] Method obj0) => Function.IS_VARARGS.fixedArgs(obj0);

    [Signature("([Ljava/lang/Object;ILjava/lang/reflect/Method;Lcom/sun/jna/TypeMapper;ZLjava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {159, 18, 99, 100, 102, 103, 98, 109, 105, 100, 137, 131, 99, 173, 138, 191, 6, 113, 162, 135, 107, 104, 103, 140, 105, 99, 104, 109, 104, 136, 111, 110, 132, 130, 166, 110, 163, 104, 136, 108, 232, 69, 114, 136, 114, 168, 122, 109, 124, 109, 118, 109, 118, 109, 118, 176, 109, 104, 110, 103, 113, 100, 255, 54, 69, 106, 108, 31, 54, 235, 74, 100, 103, 108, 106, 57, 168, 104, 101, 112, 102, 111, 138, 103, 138, 104, 112, 122, 99, 98, 109, 112, 159, 11, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object convertArgument(
      [In] object[] obj0,
      [In] int obj1,
      [In] Method obj2,
      [In] TypeMapper obj3,
      [In] bool obj4,
      [In] Class obj5)
    {
      int num1 = obj4 ? 1 : 0;
      object native = obj0[obj1];
      if (native != null)
      {
        Class @class = Object.instancehelper_getClass(native);
        object obj6 = (object) null;
        if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(@class))
          obj6 = (object) NativeMappedConverter.getInstance(@class);
        else if (obj3 != null)
          obj6 = (object) obj3.getToNativeConverter(@class);
        if (obj6 != null)
        {
          FunctionParameterContext parameterContext = obj2 == null ? new FunctionParameterContext(this, obj0, obj1) : (FunctionParameterContext) new MethodParameterContext(this, obj0, obj1, obj2);
          object obj7 = obj6;
          object obj8 = native;
          ToNativeContext toNativeContext = (ToNativeContext) parameterContext;
          object obj9 = obj8;
          ToNativeConverter toNativeConverter1;
          if (obj7 != null)
            toNativeConverter1 = obj7 is ToNativeConverter toNativeConverter7 ? toNativeConverter7 : throw new IncompatibleClassChangeError();
          else
            toNativeConverter1 = (ToNativeConverter) null;
          object obj10 = obj9;
          ToNativeContext tnc = toNativeContext;
          native = toNativeConverter1.toNative(obj10, tnc);
        }
      }
      if (native == null || this.isPrimitiveArray(Object.instancehelper_getClass(native)))
        return native;
      Class class1 = Object.instancehelper_getClass(native);
      switch (native)
      {
        case Structure _:
          Structure structure = (Structure) native;
          structure.autoWrite();
          if (structure is Structure.ByValue)
          {
            Class class2 = Object.instancehelper_getClass((object) structure);
            if (obj2 != null)
            {
              Class[] parameterTypes = obj2.getParameterTypes();
              if (Function.IS_VARARGS.isVarArgs(obj2))
              {
                if (obj1 < parameterTypes.Length - 1)
                {
                  class2 = parameterTypes[obj1];
                }
                else
                {
                  Class componentType = parameterTypes[parameterTypes.Length - 1].getComponentType();
                  if (!object.ReferenceEquals((object) componentType, (object) ClassLiteral<Object>.Value))
                    class2 = componentType;
                }
              }
              else
                class2 = parameterTypes[obj1];
            }
            if (((Class) ClassLiteral<Structure.ByValue>.Value).isAssignableFrom(class2))
              return (object) structure;
          }
          return (object) structure.getPointer();
        case Callback _:
          return (object) CallbackReference.getFunctionPointer((Callback) native);
        case string _:
          return (object) new NativeString((string) native, false).getPointer();
        case WString _:
          return (object) new NativeString(Object.instancehelper_toString(native), true).getPointer();
        case Boolean _:
          return ((Boolean) Boolean.TRUE).equals(native) ? (object) Function.INTEGER_TRUE : (object) Function.INTEGER_FALSE;
        default:
          if (object.ReferenceEquals((object) ClassLiteral<string[]>.Value, (object) class1))
          {
            StringArray.__\u003Cclinit\u003E();
            return (object) new StringArray((string[]) native, this.encoding);
          }
          if (object.ReferenceEquals((object) ClassLiteral<WString[]>.Value, (object) class1))
          {
            StringArray.__\u003Cclinit\u003E();
            return (object) new StringArray((WString[]) native);
          }
          if (object.ReferenceEquals((object) ClassLiteral<Pointer[]>.Value, (object) class1))
          {
            Function.PointerArray.__\u003Cclinit\u003E();
            return (object) new Function.PointerArray((Pointer[]) native);
          }
          if (((Class) ClassLiteral<NativeMapped[]>.Value).isAssignableFrom(class1))
          {
            Function.NativeMappedArray.__\u003Cclinit\u003E();
            return (object) new Function.NativeMappedArray((NativeMapped[]) native);
          }
          if (((Class) ClassLiteral<Structure[]>.Value).isAssignableFrom(class1))
          {
            Structure[] structureArray = (Structure[]) native;
            Class componentType = class1.getComponentType();
            int num2 = ((Class) ClassLiteral<Structure.ByReference>.Value).isAssignableFrom(componentType) ? 1 : 0;
            if (obj5 != null && !((Class) ClassLiteral<Structure.ByReference[]>.Value).isAssignableFrom(obj5))
            {
              if (num2 != 0)
              {
                string str = new StringBuilder().append("Function ").append(this.getName()).append(" declared Structure[] at parameter ").append(obj1).append(" but array of ").append((object) componentType).append(" was passed").toString();
                Throwable.__\u003CsuppressFillInStackTrace\u003E();
                throw new IllegalArgumentException(str);
              }
              for (int index = 0; index < structureArray.Length; ++index)
              {
                if (structureArray[index] is Structure.ByReference)
                {
                  string str = new StringBuilder().append("Function ").append(this.getName()).append(" declared Structure[] at parameter ").append(obj1).append(" but element ").append(index).append(" is of Structure.ByReference type").toString();
                  Throwable.__\u003CsuppressFillInStackTrace\u003E();
                  throw new IllegalArgumentException(str);
                }
              }
            }
            if (num2 != 0)
            {
              Structure.autoWrite(structureArray);
              Pointer[] pointerArray = new Pointer[structureArray.Length + 1];
              for (int index = 0; index < structureArray.Length; ++index)
                pointerArray[index] = structureArray[index] == null ? (Pointer) null : structureArray[index].getPointer();
              return (object) new Function.PointerArray(pointerArray);
            }
            if (structureArray.Length == 0)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalArgumentException("Structure array must have non-zero length");
            }
            if (structureArray[0] == null)
            {
              Structure.newInstance(componentType).toArray(structureArray);
              return (object) structureArray[0].getPointer();
            }
            Structure.autoWrite(structureArray);
            return (object) structureArray[0].getPointer();
          }
          if (class1.isArray())
          {
            string str = new StringBuilder().append("Unsupported array argument type: ").append((object) class1.getComponentType()).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
          }
          if (num1 != 0 || Native.isSupportedNativeType(Object.instancehelper_getClass(native)))
            return native;
          string str1 = new StringBuilder().append("Unsupported argument type ").append(Object.instancehelper_getClass(native).getName()).append(" at parameter ").append(obj1).append(" of function ").append(this.getName()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str1);
      }
    }

    [Signature("([Ljava/lang/Object;Ljava/lang/Class<*>;ZI)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {159, 41, 98, 98, 110, 125, 110, 103, 122, 127, 0, 122, 122, 122, 122, 122, 122, 122, 121, 122, 121, 122, 122, 122, 122, 109, 111, 109, 106, 99, 135, 114, 105, 112, 109, 138, 37, 135, 103, 99, 101, 105, 107, 115, 103, 99, 133, 109, 105, 107, 151, 109, 106, 100, 144, 114, 106, 100, 107, 106, 106, 47, 168, 131, 114, 106, 100, 138, 104, 111, 104, 108, 159, 1, 186, 159, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object invoke([In] object[] obj0, [In] Class obj1, [In] bool obj2, [In] int obj3)
    {
      int num1 = obj2 ? 1 : 0;
      object obj = (object) null;
      int num2 = this.callFlags | (obj3 & 3) << 7;
      if (obj1 == null || object.ReferenceEquals((object) obj1, (object) Void.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Void>.Value))
      {
        Native.invokeVoid(this, this.peer, num2, obj0);
        obj = (object) null;
      }
      else if (object.ReferenceEquals((object) obj1, (object) Boolean.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Boolean>.Value))
        obj = (object) Function.valueOf(Native.invokeInt(this, this.peer, num2, obj0) != 0);
      else if (object.ReferenceEquals((object) obj1, (object) Byte.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Byte>.Value))
        obj = (object) Byte.valueOf((byte) Native.invokeInt(this, this.peer, num2, obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Short.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Short>.Value))
        obj = (object) Short.valueOf((short) Native.invokeInt(this, this.peer, num2, obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Character.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Character>.Value))
        obj = (object) Character.valueOf((char) Native.invokeInt(this, this.peer, num2, obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Integer.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Integer>.Value))
        obj = (object) Integer.valueOf(Native.invokeInt(this, this.peer, num2, obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Long.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Long>.Value))
        obj = (object) Long.valueOf(Native.invokeLong(this, this.peer, num2, obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Float.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Float>.Value))
        obj = (object) Float.valueOf(Native.invokeFloat(this, this.peer, num2, obj0));
      else if (object.ReferenceEquals((object) obj1, (object) Double.TYPE) || object.ReferenceEquals((object) obj1, (object) ClassLiteral<Double>.Value))
        obj = (object) Double.valueOf(Native.invokeDouble(this, this.peer, num2, obj0));
      else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<String>.Value))
        obj = (object) this.invokeString(num2, obj0, false);
      else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<WString>.Value))
      {
        string s = this.invokeString(num2, obj0, true);
        if (s != null)
          obj = (object) new WString(s);
      }
      else
      {
        if (((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(obj1))
          return (object) this.invokePointer(num2, obj0);
        if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj1))
        {
          if (((Class) ClassLiteral<Structure.ByValue>.Value).isAssignableFrom(obj1))
          {
            Structure structure = Native.invokeStructure(this, this.peer, num2, obj0, Structure.newInstance(obj1));
            structure.autoRead();
            obj = (object) structure;
          }
          else
          {
            obj = (object) this.invokePointer(num2, obj0);
            if ((Pointer) obj != null)
            {
              Structure structure = Structure.newInstance(obj1, (Pointer) obj);
              structure.conditionalAutoRead();
              obj = (object) structure;
            }
          }
        }
        else if (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj1))
        {
          obj = (object) this.invokePointer(num2, obj0);
          if ((Pointer) obj != null)
            obj = (object) CallbackReference.getCallback(obj1, (Pointer) obj);
        }
        else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<string[]>.Value))
        {
          Pointer pointer = this.invokePointer(num2, obj0);
          if (pointer != null)
            obj = (object) pointer.getStringArray(0L, this.encoding);
        }
        else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<WString[]>.Value))
        {
          Pointer pointer = this.invokePointer(num2, obj0);
          if (pointer != null)
          {
            string[] wideStringArray = pointer.getWideStringArray(0L);
            WString[] wstringArray = new WString[wideStringArray.Length];
            for (int index = 0; index < wideStringArray.Length; ++index)
              wstringArray[index] = new WString(wideStringArray[index]);
            obj = (object) wstringArray;
          }
        }
        else if (object.ReferenceEquals((object) obj1, (object) ClassLiteral<Pointer[]>.Value))
        {
          Pointer pointer = this.invokePointer(num2, obj0);
          if (pointer != null)
            obj = (object) pointer.getPointerArray(0L);
        }
        else if (num1 != 0)
        {
          obj = Native.invokeObject(this, this.peer, num2, obj0);
          if (obj != null && !obj1.isAssignableFrom(Object.instancehelper_getClass(obj)))
          {
            string str = new StringBuilder().append("Return type ").append((object) obj1).append(" does not match result ").append((object) Object.instancehelper_getClass(obj)).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ClassCastException(str);
          }
        }
        else
        {
          string str = new StringBuilder().append("Unsupported return type ").append((object) obj1).append(" in function ").append(this.getName()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
      }
      return obj;
    }

    [LineNumberTable(new byte[] {158, 235, 130, 105, 98, 99, 99, 171, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string invokeString([In] int obj0, [In] object[] obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      Pointer pointer = this.invokePointer(obj0, obj1);
      string str = (string) null;
      if (pointer != null)
        str = num == 0 ? pointer.getString(0L, this.encoding) : pointer.getWideString(0L);
      return str;
    }

    [LineNumberTable(new byte[] {161, 120, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Pointer invokePointer([In] int obj0, [In] object[] obj1)
    {
      long peer = Native.invokePointer(this, this.peer, obj0, obj1);
      return peer == 0L ? (Pointer) null : new Pointer(peer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName() => this.functionName;

    [Signature("(Ljava/lang/Class<*>;)Z")]
    [LineNumberTable(new byte[] {162, 2, 105, 48})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isPrimitiveArray([In] Class obj0) => obj0.isArray() && obj0.getComponentType().isPrimitive();

    [Signature("(Ljava/lang/Class<*>;[Ljava/lang/Object;)Ljava/lang/Object;")]
    [LineNumberTable(299)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object invoke(Class returnType, object[] inArgs) => this.invoke(returnType, inArgs, this.options);

    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Function getFunction(string libraryName, string functionName) => NativeLibrary.getInstance(libraryName).getFunction(functionName);

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Function getFunction(
      string libraryName,
      string functionName,
      int callFlags)
    {
      return NativeLibrary.getInstance(libraryName).getFunction(functionName, callFlags, (string) null);
    }

    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Function getFunction(
      string libraryName,
      string functionName,
      int callFlags,
      string encoding)
    {
      return NativeLibrary.getInstance(libraryName).getFunction(functionName, callFlags, encoding);
    }

    [LineNumberTable(155)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Function getFunction(Pointer p) => Function.getFunction(p, 0, (string) null);

    [LineNumberTable(173)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Function getFunction(Pointer p, int callFlags) => Function.getFunction(p, callFlags, (string) null);

    [LineNumberTable(new byte[] {160, 116, 104, 106, 99, 144, 103, 103, 103, 108, 147, 255, 5, 69, 226, 60, 97, 159, 1, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Function([In] NativeLibrary obj0, [In] string obj1, [In] int obj2, [In] string obj3)
    {
      Function function = this;
      this.checkCallingConvention(obj2 & 63);
      if (obj1 == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("Function name must not be null");
      }
      this.library = obj0;
      this.functionName = obj1;
      this.callFlags = obj2;
      this.options = obj0.options;
      this.encoding = obj3 == null ? Native.getDefaultStringEncoding() : obj3;
      UnsatisfiedLinkError unsatisfiedLinkError1;
      try
      {
        this.peer = obj0.getSymbolAddress(obj1);
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
      string str = new StringBuilder().append("Error looking up function '").append(obj1).append("': ").append(Throwable.instancehelper_getMessage((Exception) unsatisfiedLinkError2)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsatisfiedLinkError(str);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCallingConvention() => this.callFlags & 63;

    [Signature("([Ljava/lang/Object;Ljava/lang/Class<*>;Z)Ljava/lang/Object;")]
    [LineNumberTable(400)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object invoke([In] object[] obj0, [In] Class obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      return this.invoke(obj0, obj1, num != 0, 0);
    }

    [LineNumberTable(new byte[] {162, 13, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void invoke(object[] args) => this.invoke((Class) ClassLiteral<Void>.Value, args);

    [LineNumberTable(new byte[] {162, 44, 104, 127, 37, 47, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => this.library != null ? new StringBuilder().append("native function ").append(this.functionName).append("(").append(this.library.getName()).append(")@0x").append(Long.toHexString(this.peer)).toString() : new StringBuilder().append("native function@0x").append(Long.toHexString(this.peer)).toString();

    [LineNumberTable(681)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object invokeObject(object[] args) => this.invoke((Class) ClassLiteral<Object>.Value, args);

    [LineNumberTable(688)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer invokePointer(object[] args) => (Pointer) this.invoke((Class) ClassLiteral<Pointer>.Value, args);

    [LineNumberTable(new byte[] {158, 224, 162, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string invokeString(object[] args, bool wide)
    {
      object obj = this.invoke(!wide ? (Class) ClassLiteral<String>.Value : (Class) ClassLiteral<WString>.Value, args);
      return obj != null ? Object.instancehelper_toString(obj) : (string) null;
    }

    [LineNumberTable(707)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int invokeInt(object[] args) => ((Integer) this.invoke((Class) ClassLiteral<Integer>.Value, args)).intValue();

    [LineNumberTable(713)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long invokeLong(object[] args) => ((Long) this.invoke((Class) ClassLiteral<Long>.Value, args)).longValue();

    [LineNumberTable(719)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float invokeFloat(object[] args) => ((Float) this.invoke((Class) ClassLiteral<Float>.Value, args)).floatValue();

    [LineNumberTable(725)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double invokeDouble(object[] args) => ((Double) this.invoke((Class) ClassLiteral<Double>.Value, args)).doubleValue();

    [LineNumberTable(new byte[] {162, 105, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void invokeVoid(object[] args) => this.invoke((Class) ClassLiteral<Void>.Value, args);

    [LineNumberTable(new byte[] {162, 113, 107, 101, 115, 103, 122, 57, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool equals(object o)
    {
      if (object.ReferenceEquals(o, (object) this))
        return true;
      if (o == null || !object.ReferenceEquals((object) o.GetType(), (object) ((object) this).GetType()))
        return false;
      Function function = (Function) o;
      return function.callFlags == this.callFlags && function.options.equals((object) this.options) && function.peer == this.peer;
    }

    [LineNumberTable(755)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int hashCode() => this.callFlags + this.options.hashCode() + base.hashCode();

    [LineNumberTable(new byte[] {159, 123, 82, 107, 235, 160, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Function()
    {
      Pointer.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.Function"))
        return;
      Function.INTEGER_TRUE = Integer.valueOf(-1);
      Function.INTEGER_FALSE = Integer.valueOf(0);
      Function.IS_VARARGS = VarArgsChecker.create();
    }

    [InnerClass]
    [Implements(new string[] {"com.sun.jna.Function$PostCallRead"})]
    internal class NativeMappedArray : Memory, Function.PostCallRead
    {
      [Modifiers]
      private NativeMapped[] original;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 178, 117, 103, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NativeMappedArray([In] NativeMapped[] obj0)
        : base((long) Native.getNativeSize(Object.instancehelper_getClass((object) obj0), (object) obj0))
      {
        Function.NativeMappedArray nativeMappedArray = this;
        this.original = obj0;
        this.setValue(0L, (object) this.original, Object.instancehelper_getClass((object) this.original));
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {162, 184, 122})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void read() => this.getValue(0L, Object.instancehelper_getClass((object) this.original), (object) this.original);

      [HideFromJava]
      static NativeMappedArray() => Memory.__\u003Cclinit\u003E();
    }

    [InnerClass]
    [Implements(new string[] {"com.sun.jna.Function$PostCallRead"})]
    internal class PointerArray : Memory, Function.PostCallRead
    {
      [Modifiers]
      private Pointer[] original;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 191, 115, 103, 103, 49, 172, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PointerArray([In] Pointer[] obj0)
        : base((long) (Pointer.__\u003C\u003ESIZE * (obj0.Length + 1)))
      {
        Function.PointerArray pointerArray = this;
        this.original = obj0;
        int index = 0;
        while (index < obj0.Length)
        {
          this.setPointer((long) (index * Pointer.__\u003C\u003ESIZE), obj0[index]);
          ++index;
          GC.KeepAlive((object) this);
        }
        this.setPointer((long) (Pointer.__\u003C\u003ESIZE * obj0.Length), (Pointer) null);
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {162, 200, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void read() => this.read(0L, this.original, 0, this.original.Length);

      [HideFromJava]
      static PointerArray() => Memory.__\u003Cclinit\u003E();
    }

    public interface PostCallRead
    {
      void read();
    }
  }
}
