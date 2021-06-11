// Decompiled with JetBrains decompiler
// Type: rhino.classfile.TypeInfo
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.classfile
{
  internal sealed class TypeInfo : Object
  {
    internal const int TOP = 0;
    internal const int INTEGER = 1;
    internal const int FLOAT = 2;
    internal const int DOUBLE = 3;
    internal const int LONG = 4;
    internal const int NULL = 5;
    internal const int UNINITIALIZED_THIS = 6;
    internal const int OBJECT_TAG = 7;
    internal const int UNINITIALIZED_VAR_TAG = 8;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int OBJECT([In] int obj0) => (obj0 & (int) ushort.MaxValue) << 8 | 7;

    [LineNumberTable(new byte[] {11, 108, 255, 86, 70, 130, 130, 130, 130, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int fromType([In] string obj0, [In] ConstantPool obj1)
    {
      if (String.instancehelper_length(obj0) != 1)
        return TypeInfo.OBJECT(obj0, obj1);
      switch (String.instancehelper_charAt(obj0, 0))
      {
        case 'B':
        case 'C':
        case 'I':
        case 'S':
        case 'Z':
          return 1;
        case 'D':
          return 3;
        case 'F':
          return 2;
        case 'J':
          return 4;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("bad type");
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isTwoWords([In] int obj0) => obj0 == 3 || obj0 == 4;

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int OBJECT([In] string obj0, [In] ConstantPool obj1) => TypeInfo.OBJECT((int) obj1.addClass(obj0));

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int UNINITIALIZED_VARIABLE([In] int obj0) => (obj0 & (int) ushort.MaxValue) << 8 | 8;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int getTag([In] int obj0) => obj0 & (int) byte.MaxValue;

    [LineNumberTable(new byte[] {55, 103, 103, 101, 133, 107, 98, 134, 98, 103, 98, 108, 105, 201, 110, 98, 236, 70, 107, 132, 107, 164, 105, 137, 107, 98, 107, 98, 107, 231, 69, 140, 105, 100, 107, 105, 105, 137, 203, 113, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int merge([In] int obj0, [In] int obj1, [In] ConstantPool obj2)
    {
      int tag1 = TypeInfo.getTag(obj0);
      int tag2 = TypeInfo.getTag(obj1);
      int num1 = tag1 == 7 ? 1 : 0;
      int num2 = tag2 == 7 ? 1 : 0;
      if (obj0 == obj1 || num1 != 0 && obj1 == 5)
        return obj0;
      if (tag1 == 0 || tag2 == 0)
        return 0;
      if (obj0 == 5 && num2 != 0)
        return obj1;
      if (num1 != 0 && num2 != 0)
      {
        string str1 = TypeInfo.getPayloadAsType(obj0, obj2);
        string str2 = TypeInfo.getPayloadAsType(obj1, obj2);
        string constantData1 = (string) obj2.getConstantData(2);
        string constantData2 = (string) obj2.getConstantData(4);
        if (String.instancehelper_equals(str1, (object) constantData1))
          str1 = constantData2;
        if (String.instancehelper_equals(str2, (object) constantData1))
          str2 = constantData2;
        Class fromInternalName1 = TypeInfo.getClassFromInternalName(str1);
        Class fromInternalName2 = TypeInfo.getClassFromInternalName(str2);
        if (fromInternalName1.isAssignableFrom(fromInternalName2))
          return obj0;
        if (fromInternalName2.isAssignableFrom(fromInternalName1))
          return obj1;
        if (fromInternalName2.isInterface() || fromInternalName1.isInterface())
          return TypeInfo.OBJECT("java/lang/Object", obj2);
        for (Class superclass = fromInternalName2.getSuperclass(); superclass != null; superclass = superclass.getSuperclass())
        {
          if (superclass.isAssignableFrom(fromInternalName1))
            return TypeInfo.OBJECT(ClassFileWriter.getSlashedForm(superclass.getName()), obj2);
        }
      }
      string str = new StringBuilder().append("bad merge attempt between ").append(TypeInfo.toString(obj0, obj2)).append(" and ").append(TypeInfo.toString(obj1, obj2)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int getPayload([In] int obj0) => (int) ((uint) obj0 >> 8);

    [LineNumberTable(new byte[] {1, 105, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getPayloadAsType([In] int obj0, [In] ConstantPool obj1)
    {
      if (TypeInfo.getTag(obj0) == 7)
        return (string) obj1.getConstantData(TypeInfo.getPayload(obj0));
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException("expecting object type");
    }

    [Signature("(Ljava/lang/String;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {160, 92, 127, 11, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Class getClassFromInternalName([In] string obj0)
    {
      Class @class;
      ClassNotFoundException notFoundException1;
      try
      {
        @class = Class.forName(String.instancehelper_replace(obj0, '/', '.'), TypeInfo.__\u003CGetCallerID\u003E());
      }
      catch (ClassNotFoundException ex)
      {
        notFoundException1 = (ClassNotFoundException) ByteCodeHelper.MapException<ClassNotFoundException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return @class;
label_3:
      ClassNotFoundException notFoundException2 = notFoundException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) notFoundException2);
    }

    [LineNumberTable(new byte[] {120, 103, 159, 5, 134, 134, 134, 134, 134, 134, 134, 100, 104, 100, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string toString([In] int obj0, [In] ConstantPool obj1)
    {
      switch (TypeInfo.getTag(obj0))
      {
        case 0:
          return "top";
        case 1:
          return "int";
        case 2:
          return "float";
        case 3:
          return "double";
        case 4:
          return "long";
        case 5:
          return "null";
        case 6:
          return "uninitialized_this";
        case 7:
          return TypeInfo.getPayloadAsType(obj0, obj1);
        case 8:
          return "uninitialized";
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("bad type");
      }
    }

    [LineNumberTable(new byte[] {160, 117, 111, 115, 111, 115, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void print([In] int[] obj0, [In] int obj1, [In] int[] obj2, [In] int obj3, [In] ConstantPool obj4)
    {
      java.lang.System.@out.print("locals: ");
      java.lang.System.@out.println(TypeInfo.toString(obj0, obj1, obj4));
      java.lang.System.@out.print("stack: ");
      java.lang.System.@out.println(TypeInfo.toString(obj2, obj3, obj4));
      java.lang.System.@out.println();
    }

    [LineNumberTable(new byte[] {160, 99, 102, 108, 102, 100, 140, 240, 60, 230, 70, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string toString([In] int[] obj0, [In] int obj1, [In] ConstantPool obj2)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append("[");
      for (int index = 0; index < obj1; ++index)
      {
        if (index > 0)
          stringBuilder.append(", ");
        stringBuilder.append(TypeInfo.toString(obj0[index], obj2));
      }
      stringBuilder.append("]");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {159, 153, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TypeInfo()
    {
    }

    [LineNumberTable(new byte[] {160, 112, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void print([In] int[] obj0, [In] int[] obj1, [In] ConstantPool obj2) => TypeInfo.print(obj0, obj0.Length, obj1, obj1.Length, obj2);

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (TypeInfo.__\u003CcallerID\u003E == null)
        TypeInfo.__\u003CcallerID\u003E = (CallerID) new TypeInfo.__\u003CCallerID\u003E();
      return TypeInfo.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
