// Decompiled with JetBrains decompiler
// Type: rhino.NativeJavaMethod
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.lang.reflect;
using java.util;
using java.util.concurrent;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class NativeJavaMethod : BaseFunction
  {
    private const int PREFERENCE_EQUAL = 0;
    private const int PREFERENCE_FIRST_ARG = 1;
    private const int PREFERENCE_SECOND_ARG = 2;
    private const int PREFERENCE_AMBIGUOUS = 3;
    private const bool debug = false;
    internal MemberBox[] methods;
    [Modifiers]
    private string functionName;
    [Modifiers]
    [Signature("Ljava/util/concurrent/CopyOnWriteArrayList<Lrhino/ResolvedOverload;>;")]
    [NonSerialized]
    private CopyOnWriteArrayList overloadCache;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 232, 161, 242, 235, 158, 15, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeJavaMethod([In] MemberBox obj0, [In] string obj1)
    {
      NativeJavaMethod nativeJavaMethod = this;
      this.overloadCache = new CopyOnWriteArrayList();
      this.functionName = obj1;
      this.methods = new MemberBox[1]{ obj0 };
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getFunctionName() => this.functionName;

    [LineNumberTable(new byte[] {45, 102, 145, 111, 110, 114, 105, 109, 98, 148, 121, 233, 53, 233, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      int index = 0;
      for (int length = this.methods.Length; index != length; ++index)
      {
        if (this.methods[index].isMethod())
        {
          Method method = this.methods[index].method();
          stringBuilder.append(JavaMembers.javaSignature(method.getReturnType()));
          stringBuilder.append(' ');
          stringBuilder.append(method.getName());
        }
        else
          stringBuilder.append(this.methods[index].getName());
        stringBuilder.append(JavaMembers.liveConnectSignature(this.methods[index].argTypes));
        stringBuilder.append('\n');
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 118, 109, 127, 1, 105, 135, 98, 174, 118, 104, 141, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int findCachedFunction([In] Context obj0, [In] object[] obj1)
    {
      if (this.methods.Length <= 1)
        return NativeJavaMethod.findFunction(obj0, this.methods, obj1);
      Iterator iterator = this.overloadCache.iterator();
      while (iterator.hasNext())
      {
        ResolvedOverload resolvedOverload = (ResolvedOverload) iterator.next();
        if (resolvedOverload.matches(obj1))
          return resolvedOverload.index;
      }
      int function = NativeJavaMethod.findFunction(obj0, this.methods, obj1);
      if (this.overloadCache.size() < this.methods.Length * 2)
        this.overloadCache.addIfAbsent((object) new ResolvedOverload(obj1, function));
      return function;
    }

    [LineNumberTable(new byte[] {159, 184, 102, 106, 164, 99, 107, 104, 107, 104, 107, 104, 107, 107, 104, 104, 104, 109, 109, 106, 136, 168, 172, 99, 137, 232, 34, 233, 96})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string scriptSignature([In] object[] obj0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index != obj0.Length; ++index)
      {
        object obj = obj0[index];
        string str;
        switch (obj)
        {
          case null:
            str = "null";
            break;
          case Boolean _:
            str = "boolean";
            break;
          case string _:
            str = "string";
            break;
          case Number _:
            str = "number";
            break;
          case Scriptable _:
            str = !(obj is Undefined) ? (!(obj is Wrapper) ? (!(obj is Function) ? "object" : "function") : Object.instancehelper_getClass(((Wrapper) obj).unwrap()).getName()) : "undefined";
            break;
          default:
            str = JavaMembers.javaSignature(Object.instancehelper_getClass(obj));
            break;
        }
        if (index != 0)
          stringBuilder.append(',');
        stringBuilder.append(str);
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 143, 100, 98, 104, 100, 103, 131, 104, 100, 101, 162, 101, 162, 102, 173, 226, 60, 230, 72, 162, 99, 99, 162, 106, 101, 105, 101, 105, 102, 102, 165, 102, 165, 105, 176, 229, 60, 232, 71, 133, 232, 70, 131, 131, 139, 101, 134, 135, 102, 108, 206, 105, 139, 139, 223, 0, 101, 101, 101, 104, 101, 136, 234, 70, 110, 103, 37, 234, 73, 101, 136, 232, 16, 235, 123, 199, 99, 100, 233, 72, 132, 139, 101, 228, 159, 145, 233, 160, 116, 133, 98, 131, 195, 103, 136, 101, 134, 135, 109, 241, 56, 232, 75, 102, 105, 142, 106, 136, 12, 203, 138, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int findFunction([In] Context obj0, [In] MemberBox[] obj1, [In] object[] obj2)
    {
      if (obj1.Length == 0)
        return -1;
      if (obj1.Length == 1)
      {
        MemberBox memberBox = obj1[0];
        Class[] argTypes = memberBox.argTypes;
        int length = argTypes.Length;
        if (memberBox.vararg)
        {
          length += -1;
          if (length > obj2.Length)
            return -1;
        }
        else if (length != obj2.Length)
          return -1;
        for (int index = 0; index != length; ++index)
        {
          if (!NativeJavaObject.canConvert(obj2[index], argTypes[index]))
            return -1;
        }
        return 0;
      }
      int index1 = -1;
      int[] numArray = (int[]) null;
      int index2 = 0;
label_15:
      for (int index3 = 0; index3 < obj1.Length; ++index3)
      {
        MemberBox memberBox1 = obj1[index3];
        Class[] argTypes = memberBox1.argTypes;
        int length = argTypes.Length;
        if (memberBox1.vararg)
        {
          length += -1;
          if (length > obj2.Length)
            continue;
        }
        else if (length != obj2.Length)
          continue;
        for (int index4 = 0; index4 < length; ++index4)
        {
          if (!NativeJavaObject.canConvert(obj2[index4], argTypes[index4]))
            goto label_15;
        }
        if (index1 < 0)
        {
          index1 = index3;
        }
        else
        {
          int num1 = 0;
          int num2 = 0;
          for (int index4 = -1; index4 != index2; ++index4)
          {
            int index5 = index4 != -1 ? numArray[index4] : index1;
            MemberBox memberBox2 = obj1[index5];
            if (obj0.hasFeature(13) && memberBox2.isPublic() != memberBox1.isPublic())
            {
              if (!memberBox2.isPublic())
                ++num1;
              else
                ++num2;
            }
            else
            {
              switch (NativeJavaMethod.preferSignature(obj2, argTypes, memberBox1.vararg, memberBox2.argTypes, memberBox2.vararg))
              {
                case 0:
                  if (memberBox2.isStatic() && memberBox2.getDeclaringClass().isAssignableFrom(memberBox1.getDeclaringClass()))
                  {
                    if (index4 == -1)
                    {
                      index1 = index3;
                      goto label_15;
                    }
                    else
                    {
                      numArray[index4] = index3;
                      goto label_15;
                    }
                  }
                  else
                    goto label_15;
                case 1:
                  ++num1;
                  continue;
                case 2:
                  ++num2;
                  continue;
                case 3:
                  goto label_40;
                default:
                  Kit.codeBug();
                  goto case 0;
              }
            }
          }
label_40:
          if (num1 == 1 + index2)
          {
            index1 = index3;
            index2 = 0;
          }
          else if (num2 != 1 + index2)
          {
            if (numArray == null)
              numArray = new int[obj1.Length - 1];
            numArray[index2] = index3;
            ++index2;
          }
        }
      }
      if (index1 < 0)
        return -1;
      if (index2 == 0)
        return index1;
      StringBuilder stringBuilder = new StringBuilder();
      for (int index3 = -1; index3 != index2; ++index3)
      {
        int index4 = index3 != -1 ? numArray[index3] : index1;
        stringBuilder.append("\n    ");
        stringBuilder.append(obj1[index4].toJavaDeclaration());
      }
      MemberBox memberBox3 = obj1[index1];
      string name1 = memberBox3.getName();
      string name2 = memberBox3.getDeclaringClass().getName();
      if (obj1[0].isCtor())
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError3("msg.constructor.ambiguous", (object) name1, (object) NativeJavaMethod.scriptSignature(obj2), (object) stringBuilder.toString()));
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError4("msg.method.ambiguous", (object) name2, (object) name1, (object) NativeJavaMethod.scriptSignature(obj2), (object) stringBuilder.toString()));
    }

    [Signature("([Ljava/lang/Object;[Ljava/lang/Class<*>;Z[Ljava/lang/Class<*>;Z)I")]
    [LineNumberTable(new byte[] {159, 28, 133, 98, 106, 117, 117, 107, 133, 197, 107, 171, 102, 101, 102, 165, 100, 107, 101, 107, 133, 165, 195, 133, 100, 226, 28, 233, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int preferSignature(
      [In] object[] obj0,
      [In] Class[] obj1,
      [In] bool obj2,
      [In] Class[] obj3,
      [In] bool obj4)
    {
      int num1 = obj2 ? 1 : 0;
      int num2 = obj4 ? 1 : 0;
      int num3 = 0;
      for (int index = 0; index < obj0.Length; ++index)
      {
        Class class1 = num1 == 0 || index < obj1.Length ? obj1[index] : obj1[obj1.Length - 1];
        Class class2 = num2 == 0 || index < obj3.Length ? obj3[index] : obj3[obj3.Length - 1];
        if (!object.ReferenceEquals((object) class1, (object) class2))
        {
          object obj = obj0[index];
          int conversionWeight1 = NativeJavaObject.getConversionWeight(obj, class1);
          int conversionWeight2 = NativeJavaObject.getConversionWeight(obj, class2);
          int num4 = conversionWeight1 >= conversionWeight2 ? (conversionWeight1 <= conversionWeight2 ? (conversionWeight1 != 0 ? 3 : (!class1.isAssignableFrom(class2) ? (!class2.isAssignableFrom(class1) ? 3 : 1) : 2)) : 2) : 1;
          num3 |= num4;
          if (num3 == 3)
            break;
        }
      }
      return num3;
    }

    [LineNumberTable(new byte[] {159, 159, 232, 161, 252, 235, 158, 5, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeJavaMethod([In] MemberBox[] obj0)
    {
      NativeJavaMethod nativeJavaMethod = this;
      this.overloadCache = new CopyOnWriteArrayList();
      this.functionName = obj0[0].getName();
      this.methods = obj0;
    }

    [LineNumberTable(new byte[] {159, 164, 232, 161, 247, 235, 158, 10, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeJavaMethod([In] MemberBox[] obj0, [In] string obj1)
    {
      NativeJavaMethod nativeJavaMethod = this;
      this.overloadCache = new CopyOnWriteArrayList();
      this.functionName = obj1;
      this.methods = obj0;
    }

    [LineNumberTable(new byte[] {159, 175, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaMethod(Method method, string name)
      : this(new MemberBox(method), name)
    {
    }

    [LineNumberTable(new byte[] {30, 102, 106, 99, 108, 109, 140, 108, 109, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal override string decompile([In] int obj0, [In] int obj1)
    {
      StringBuilder stringBuilder = new StringBuilder();
      int num = 0 != (obj1 & 1) ? 1 : 0;
      if (num == 0)
      {
        stringBuilder.append("function ");
        stringBuilder.append(this.getFunctionName());
        stringBuilder.append("() {");
      }
      stringBuilder.append("/*\n");
      stringBuilder.append(this.toString());
      stringBuilder.append(num == 0 ? "*/}\n" : "*/\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {66, 105, 176, 106, 100, 115, 127, 12, 119, 177, 105, 136, 139, 106, 108, 52, 232, 72, 255, 17, 69, 220, 104, 103, 146, 110, 148, 235, 61, 232, 72, 138, 100, 133, 100, 106, 103, 110, 107, 107, 142, 231, 57, 232, 76, 104, 136, 99, 136, 100, 102, 102, 12, 203, 105, 110, 107, 162, 235, 71, 108, 237, 74, 243, 73, 114, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args)
    {
      if (this.methods.Length == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("No methods defined for call");
      }
      int cachedFunction = this.findCachedFunction(cx, args);
      MemberBox memberBox = cachedFunction >= 0 ? this.methods[cachedFunction] : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.java.no_such_method", (object) new StringBuilder().append(this.methods[0].method().getDeclaringClass().getName()).append('.').append(this.getFunctionName()).append('(').append(NativeJavaMethod.scriptSignature(args)).append(')').toString()));
      Class[] argTypes = memberBox.argTypes;
      if (memberBox.vararg)
      {
        object[] objArray = new object[argTypes.Length];
        for (int index = 0; index < argTypes.Length - 1; ++index)
          objArray[index] = Context.jsToJava(args[index], argTypes[index]);
        object obj;
        if (args.Length == argTypes.Length && (args[args.Length - 1] == null || args[args.Length - 1] is NativeArray || args[args.Length - 1] is NativeJavaArray))
        {
          obj = Context.jsToJava(args[args.Length - 1], argTypes[argTypes.Length - 1]);
        }
        else
        {
          Class componentType = argTypes[argTypes.Length - 1].getComponentType();
          obj = Array.newInstance(componentType, args.Length - argTypes.Length + 1);
          for (int index = 0; index < Array.getLength(obj); ++index)
          {
            object java = Context.jsToJava(args[argTypes.Length - 1 + index], componentType);
            Array.set(obj, index, java);
          }
        }
        objArray[argTypes.Length - 1] = obj;
        args = objArray;
      }
      else
      {
        object[] objArray = args;
        for (int index = 0; index < args.Length; ++index)
        {
          object objB = args[index];
          object java = Context.jsToJava(objB, argTypes[index]);
          if (!object.ReferenceEquals(java, objB))
          {
            if (object.ReferenceEquals((object) objArray, (object) args))
              args = (object[]) args.Clone();
            args[index] = java;
          }
        }
      }
      object obj1;
      if (memberBox.isStatic())
      {
        obj1 = (object) null;
      }
      else
      {
        Scriptable scriptable = thisObj;
        Class declaringClass = memberBox.getDeclaringClass();
        for (; scriptable != null; scriptable = scriptable.getPrototype())
        {
          if (scriptable is Wrapper)
          {
            obj1 = ((Wrapper) scriptable).unwrap();
            if (declaringClass.isInstance(obj1))
              goto label_29;
          }
        }
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError3("msg.nonjava.method", (object) this.getFunctionName(), (object) ScriptRuntime.toString((object) thisObj), (object) declaringClass.getName()));
      }
label_29:
      object obj2 = memberBox.invoke(obj1, args);
      Class returnType = memberBox.method().getReturnType();
      object obj3 = cx.getWrapFactory().wrap(cx, scope, obj2, returnType);
      if (obj3 == null && object.ReferenceEquals((object) returnType, (object) Void.TYPE))
        obj3 = Undefined.__\u003C\u003Einstance;
      return obj3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void printDebug([In] string obj0, [In] MemberBox obj1, [In] object[] obj2)
    {
    }

    [HideFromJava]
    static NativeJavaMethod() => BaseFunction.__\u003Cclinit\u003E();
  }
}
