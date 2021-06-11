// Decompiled with JetBrains decompiler
// Type: rhino.MemberBox
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
  internal sealed class MemberBox : Object
  {
    [NonSerialized]
    private Member memberObject;
    [Signature("[Ljava/lang/Class<*>;")]
    [NonSerialized]
    internal Class[] argTypes;
    [NonSerialized]
    internal object delegateTo;
    [NonSerialized]
    internal bool vararg;
    [Modifiers]
    [Signature("[Ljava/lang/Class<*>;")]
    private static Class[] primitives;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal MemberBox([In] Method obj0)
    {
      MemberBox memberBox = this;
      this.init(obj0);
    }

    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getName() => this.memberObject.getName();

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isMethod() => this.memberObject is Method;

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Method method() => (Method) this.memberObject;

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isStatic() => Modifier.isStatic(this.memberObject.getModifiers());

    [Signature("()Ljava/lang/Class<*>;")]
    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Class getDeclaringClass() => this.memberObject.getDeclaringClass();

    [LineNumberTable(new byte[] {52, 167, 127, 49, 98, 110, 100, 104, 133, 109, 205, 159, 28, 130, 132, 110, 105, 105, 109, 109, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object invoke([In] object obj0, [In] object[] obj1)
    {
      Method method1 = this.method();
      object obj2;
      IllegalAccessException illegalAccessException1;
      InvocationTargetException invocationTargetException1;
      Exception exception1;
      try
      {
        try
        {
          try
          {
            obj2 = method1.invoke(obj0, obj1, MemberBox.__\u003CGetCallerID\u003E());
          }
          catch (IllegalAccessException ex)
          {
            illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_8;
          }
        }
        catch (InvocationTargetException ex)
        {
          invocationTargetException1 = (InvocationTargetException) ByteCodeHelper.MapException<InvocationTargetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_9;
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
          goto label_10;
        }
      }
      return obj2;
label_8:
      IllegalAccessException illegalAccessException2 = illegalAccessException1;
      object obj3;
      InvocationTargetException invocationTargetException2;
      Exception exception2;
      try
      {
        IllegalAccessException illegalAccessException3 = illegalAccessException2;
        try
        {
          IllegalAccessException illegalAccessException4 = illegalAccessException3;
          Method method2 = MemberBox.searchAccessibleMethod(method1, this.argTypes);
          if (method2 != null)
          {
            this.memberObject = (Member) method2;
            method1 = method2;
          }
          else if (!VMBridge.instance.tryToMakeAccessible((AccessibleObject) method1))
            throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) illegalAccessException4));
          obj3 = method1.invoke(obj0, obj1, MemberBox.__\u003CGetCallerID\u003E());
        }
        catch (InvocationTargetException ex)
        {
          invocationTargetException2 = (InvocationTargetException) ByteCodeHelper.MapException<InvocationTargetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_22;
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
          exception2 = (Exception) m0;
          goto label_23;
        }
      }
      return obj3;
label_22:
      InvocationTargetException invocationTargetException3 = invocationTargetException2;
      goto label_24;
label_23:
      Exception exception3 = exception2;
      goto label_29;
label_9:
      invocationTargetException3 = invocationTargetException1;
      goto label_24;
label_10:
      exception3 = exception1;
      goto label_29;
label_24:
      Exception e = (Exception) invocationTargetException3;
      do
      {
        e = ((InvocationTargetException) e).getTargetException();
      }
      while (e is InvocationTargetException);
      if (e is ContinuationPending)
        throw Throwable.__\u003Cunmap\u003E(e);
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx(e));
label_29:
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) exception3));
    }

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isPublic() => Modifier.isPublic(this.memberObject.getModifiers());

    [LineNumberTable(new byte[] {27, 102, 104, 103, 109, 105, 109, 98, 103, 108, 106, 101, 139, 136, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string toJavaDeclaration()
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (this.isMethod())
      {
        Method method = this.method();
        stringBuilder.append((object) method.getReturnType());
        stringBuilder.append(' ');
        stringBuilder.append(method.getName());
      }
      else
      {
        string str = this.ctor().getDeclaringClass().getName();
        int num = String.instancehelper_lastIndexOf(str, 46);
        if (num >= 0)
          str = String.instancehelper_substring(str, num + 1);
        stringBuilder.append(str);
      }
      stringBuilder.append(JavaMembers.liveConnectSignature(this.argTypes));
      return stringBuilder.toString();
    }

    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isCtor() => this.memberObject is Constructor;

    [Signature("(Ljava/lang/reflect/Constructor<*>;)V")]
    [LineNumberTable(new byte[] {159, 166, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal MemberBox([In] Constructor obj0)
    {
      MemberBox memberBox = this;
      this.init(obj0);
    }

    [Signature("()Ljava/lang/reflect/Constructor<*>;")]
    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Constructor ctor() => (Constructor) this.memberObject;

    [LineNumberTable(new byte[] {84, 167, 127, 24, 98, 109, 173, 127, 13, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object newInstance([In] object[] obj0)
    {
      Constructor constructor = this.ctor();
      object obj1;
      IllegalAccessException illegalAccessException1;
      Exception exception1;
      try
      {
        try
        {
          obj1 = constructor.newInstance(obj0, MemberBox.__\u003CGetCallerID\u003E());
        }
        catch (IllegalAccessException ex)
        {
          illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_7;
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
          goto label_8;
        }
      }
      return obj1;
label_7:
      IllegalAccessException illegalAccessException2 = illegalAccessException1;
      object obj2;
      Exception exception2;
      try
      {
        IllegalAccessException illegalAccessException3 = illegalAccessException2;
        obj2 = VMBridge.instance.tryToMakeAccessible((AccessibleObject) constructor) ? constructor.newInstance(obj0, MemberBox.__\u003CGetCallerID\u003E()) : throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) illegalAccessException3));
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
          exception2 = (Exception) m0;
          goto label_16;
        }
      }
      return obj2;
label_16:
      Exception exception3 = exception2;
      goto label_17;
label_8:
      exception3 = exception1;
label_17:
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) exception3));
    }

    [LineNumberTable(new byte[] {159, 171, 103, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void init([In] Method obj0)
    {
      this.memberObject = (Member) obj0;
      this.argTypes = obj0.getParameterTypes();
      this.vararg = obj0.isVarArgs();
    }

    [Signature("(Ljava/lang/reflect/Constructor<*>;)V")]
    [LineNumberTable(new byte[] {159, 177, 103, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void init([In] Constructor obj0)
    {
      this.memberObject = (Member) obj0;
      this.argTypes = obj0.getParameterTypes();
      this.vararg = obj0.isVarArgs();
    }

    [Signature("(Ljava/lang/reflect/Method;[Ljava/lang/Class<*>;)Ljava/lang/reflect/Method;")]
    [LineNumberTable(new byte[] {100, 103, 118, 103, 112, 103, 103, 109, 102, 142, 127, 6, 225, 59, 232, 74, 103, 99, 133, 141, 111, 105, 107, 103, 189, 37, 97, 229, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Method searchAccessibleMethod([In] Method obj0, [In] Class[] obj1)
    {
      int modifiers1 = obj0.getModifiers();
      if (Modifier.isPublic(modifiers1) && !Modifier.isStatic(modifiers1))
      {
        Class class1 = obj0.getDeclaringClass();
        if (!Modifier.isPublic(class1.getModifiers()))
        {
          string name = obj0.getName();
          Class[] interfaces = class1.getInterfaces();
          int index = 0;
          for (int length = interfaces.Length; index != length; ++index)
          {
            Class class2 = interfaces[index];
            if (Modifier.isPublic(class2.getModifiers()))
            {
              Method method;
              try
              {
                try
                {
                  method = class2.getMethod(name, obj1, MemberBox.__\u003CGetCallerID\u003E());
                }
                catch (NoSuchMethodException ex)
                {
                  goto label_9;
                }
              }
              catch (SecurityException ex)
              {
                goto label_10;
              }
              return method;
label_9:
              goto label_11;
label_10:
              null = null;
label_11:;
            }
          }
          Method method1;
          while (true)
          {
            do
            {
              class1 = class1.getSuperclass();
              if (class1 == null)
                goto label_24;
            }
            while (!Modifier.isPublic(class1.getModifiers()));
            try
            {
              try
              {
                Method method2 = class1.getMethod(name, obj1, MemberBox.__\u003CGetCallerID\u003E());
                int modifiers2 = method2.getModifiers();
                if (Modifier.isPublic(modifiers2))
                {
                  if (!Modifier.isStatic(modifiers2))
                  {
                    method1 = method2;
                    break;
                  }
                  continue;
                }
                continue;
              }
              catch (NoSuchMethodException ex)
              {
              }
            }
            catch (SecurityException ex)
            {
              goto label_22;
            }
            goto label_23;
label_22:
            null = null;
label_23:;
          }
          return method1;
        }
      }
label_24:
      return (Method) null;
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {160, 121, 104, 98, 103, 108, 108, 135, 99, 145, 127, 11, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Member readMember([In] ObjectInputStream obj0)
    {
      if (!obj0.readBoolean())
        return (Member) null;
      int num = obj0.readBoolean() ? 1 : 0;
      string str1 = (string) obj0.readObject();
      Class @class = (Class) obj0.readObject();
      Class[] classArray = MemberBox.readParameters(obj0);
      Constructor constructor;
      NoSuchMethodException suchMethodException1;
      try
      {
        if (num != 0)
          return (Member) @class.getMethod(str1, classArray, MemberBox.__\u003CGetCallerID\u003E());
        constructor = @class.getConstructor(classArray, MemberBox.__\u003CGetCallerID\u003E());
      }
      catch (NoSuchMethodException ex)
      {
        suchMethodException1 = (NoSuchMethodException) ByteCodeHelper.MapException<NoSuchMethodException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_8;
      }
      return (Member) constructor;
label_8:
      NoSuchMethodException suchMethodException2 = suchMethodException1;
      string str2 = new StringBuilder().append("Cannot find member: ").append((object) suchMethodException2).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException(str2);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 99, 99, 103, 129, 103, 112, 112, 111, 108, 108, 104, 147, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void writeMember([In] ObjectOutputStream obj0, [In] Member obj1)
    {
      if (obj1 == null)
      {
        obj0.writeBoolean(false);
      }
      else
      {
        obj0.writeBoolean(true);
        if (!(obj1 is Method) && !(obj1 is Constructor))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("not Method or Constructor");
        }
        obj0.writeBoolean(obj1 is Method);
        obj0.writeObject((object) obj1.getName());
        obj0.writeObject((object) obj1.getDeclaringClass());
        if (obj1 is Method)
          MemberBox.writeParameters(obj0, ((Method) obj1).getParameterTypes());
        else
          MemberBox.writeParameters(obj0, ((Constructor) obj1).getParameterTypes());
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Ljava/io/ObjectOutputStream;[Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {160, 157, 136, 106, 100, 103, 103, 99, 103, 130, 107, 111, 103, 226, 61, 230, 70, 255, 16, 50, 233, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void writeParameters([In] ObjectOutputStream obj0, [In] Class[] obj1)
    {
      obj0.writeShort(obj1.Length);
label_1:
      for (int index1 = 0; index1 < obj1.Length; ++index1)
      {
        Class @class = obj1[index1];
        int num = @class.isPrimitive() ? 1 : 0;
        obj0.writeBoolean(num != 0);
        if (num == 0)
        {
          obj0.writeObject((object) @class);
        }
        else
        {
          for (int index2 = 0; index2 < MemberBox.primitives.Length; ++index2)
          {
            if (Object.instancehelper_equals((object) @class, (object) MemberBox.primitives[index2]))
            {
              obj0.writeByte(index2);
              goto label_1;
            }
          }
          string str = new StringBuilder().append("Primitive ").append((object) @class).append(" not found").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
      }
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [Signature("(Ljava/io/ObjectInputStream;)[Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {160, 183, 108, 103, 104, 110, 130, 240, 59, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Class[] readParameters([In] ObjectInputStream obj0)
    {
      Class[] classArray = new Class[(int) obj0.readShort()];
      for (int index = 0; index < classArray.Length; ++index)
        classArray[index] = obj0.readBoolean() ? MemberBox.primitives[(int) (sbyte) obj0.readByte()] : (Class) obj0.readObject();
      return classArray;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Member member() => this.memberObject;

    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Object.instancehelper_toString((object) this.memberObject);

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {160, 75, 102, 103, 104, 142, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      Member member = MemberBox.readMember(obj0);
      if (member is Method)
        this.init((Method) member);
      else
        this.init((Constructor) member);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 86, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeObject([In] ObjectOutputStream obj0)
    {
      obj0.defaultWriteObject();
      MemberBox.writeMember(obj0, this.memberObject);
    }

    [LineNumberTable(251)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static MemberBox()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.MemberBox"))
        return;
      MemberBox.primitives = new Class[9]
      {
        (Class) Boolean.TYPE,
        (Class) Byte.TYPE,
        (Class) Character.TYPE,
        (Class) Double.TYPE,
        (Class) Float.TYPE,
        (Class) Integer.TYPE,
        (Class) Long.TYPE,
        (Class) Short.TYPE,
        (Class) Void.TYPE
      };
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (MemberBox.__\u003CcallerID\u003E == null)
        MemberBox.__\u003CcallerID\u003E = (CallerID) new MemberBox.__\u003CCallerID\u003E();
      return MemberBox.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
