// Decompiled with JetBrains decompiler
// Type: rhino.JavaMembers
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

namespace rhino
{
  internal class JavaMembers : Object
  {
    [Modifiers]
    [Signature("Ljava/lang/Class<*>;")]
    private Class cl;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;")]
    private Map members;
    [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/FieldAndMethods;>;")]
    private Map fieldAndMethods;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;")]
    private Map staticMembers;
    [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/FieldAndMethods;>;")]
    private Map staticFieldAndMethods;
    internal NativeJavaMethod ctors;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {106, 104, 135, 130, 100, 104, 104, 103, 102, 100, 136, 112, 104, 105, 99, 100, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string javaSignature([In] Class obj0)
    {
      if (!obj0.isArray())
        return obj0.getName();
      int num = 0;
      do
      {
        ++num;
        obj0 = obj0.getComponentType();
      }
      while (obj0.isArray());
      string name = obj0.getName();
      string str = "[]";
      if (num == 1)
        return String.instancehelper_concat(name, str);
      StringBuilder stringBuilder = new StringBuilder(String.instancehelper_length(name) + num * String.instancehelper_length(str));
      stringBuilder.append(name);
      while (num != 0)
      {
        num += -1;
        stringBuilder.append(str);
      }
      return stringBuilder.toString();
    }

    [Signature("([Ljava/lang/Class<*>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {160, 66, 99, 99, 134, 102, 105, 102, 99, 137, 239, 60, 230, 70, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string liveConnectSignature([In] Class[] obj0)
    {
      int length = obj0.Length;
      if (length == 0)
        return "()";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append('(');
      for (int index = 0; index != length; ++index)
      {
        if (index != 0)
          stringBuilder.append(',');
        stringBuilder.append(JavaMembers.javaSignature(obj0[index]));
      }
      stringBuilder.append(')');
      return stringBuilder.toString();
    }

    [Signature("(Lrhino/Scriptable;Ljava/lang/Class<*>;Z)V")]
    [LineNumberTable(new byte[] {159, 138, 162, 136, 107, 103, 113, 102, 37, 171, 107, 107, 103, 138, 142, 101, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal JavaMembers([In] Scriptable obj0, [In] Class obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      JavaMembers javaMembers = this;
      try
      {
        Context context = ContextFactory.getGlobal().enterContext();
        ClassShutter classShutter = context.getClassShutter();
        if (classShutter != null && !classShutter.visibleToScripts(obj1.getName()))
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.access.prohibited", (object) obj1.getName()));
        this.members = (Map) new HashMap();
        this.staticMembers = (Map) new HashMap();
        this.cl = obj1;
        int num2 = context.hasFeature(13) ? 1 : 0;
        this.reflect(obj0, num1 != 0, num2 != 0);
      }
      finally
      {
        Context.exit();
      }
    }

    [LineNumberTable(new byte[] {159, 42, 68, 142, 120, 105, 105, 116, 105, 107, 100, 174, 105, 139, 175, 103, 105, 140, 233, 44, 235, 90, 107, 106, 116, 159, 9, 105, 105, 104, 154, 105, 105, 107, 105, 105, 112, 12, 232, 69, 105, 99, 136, 113, 229, 40, 235, 92, 106, 124, 105, 137, 105, 116, 107, 118, 113, 108, 105, 118, 116, 105, 103, 100, 143, 173, 127, 8, 108, 107, 233, 71, 117, 140, 130, 241, 71, 226, 59, 129, 127, 7, 57, 229, 24, 235, 112, 107, 106, 148, 167, 159, 9, 110, 110, 110, 175, 106, 103, 105, 165, 100, 106, 105, 106, 144, 106, 105, 116, 241, 71, 107, 101, 107, 132, 121, 108, 229, 71, 147, 100, 211, 99, 99, 142, 142, 107, 105, 105, 164, 110, 146, 130, 176, 107, 228, 69, 109, 140, 165, 233, 159, 166, 235, 160, 94, 105, 106, 106, 52, 168, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void reflect([In] Scriptable obj0, [In] bool obj1, [In] bool obj2)
    {
      int num1 = obj1 ? 1 : 0;
      int num2 = obj2 ? 1 : 0;
      Method[] methodArray = JavaMembers.discoverAccessibleMethods(this.cl, num1 != 0, num2 != 0);
      int length1 = methodArray.Length;
      for (int index = 0; index < length1; ++index)
      {
        Method method = methodArray[index];
        Map map = !Modifier.isStatic(method.getModifiers()) ? this.members : this.staticMembers;
        string name = method.getName();
        object obj = map.get((object) name);
        ObjArray objArray;
        switch (obj)
        {
          case null:
            map.put((object) name, (object) method);
            continue;
          case ObjArray _:
            objArray = (ObjArray) obj;
            break;
          case Method _:
label_6:
            objArray = new ObjArray();
            objArray.add(obj);
            map.put((object) name, (object) objArray);
            break;
          default:
            Kit.codeBug();
            goto label_6;
        }
        objArray.add((object) method);
      }
      int num3 = 0;
      while (true)
      {
        int num4;
        switch (num3)
        {
          case 0:
            num4 = 1;
            break;
          case 2:
            goto label_26;
          default:
            num4 = 0;
            break;
        }
        Map map = num4 == 0 ? this.members : this.staticMembers;
        Iterator iterator = map.entrySet().iterator();
        while (iterator.hasNext())
        {
          Map.Entry entry = (Map.Entry) iterator.next();
          object obj = entry.getValue();
          MemberBox[] memberBoxArray1;
          if (obj is Method)
          {
            memberBoxArray1 = new MemberBox[1];
            MemberBox[] memberBoxArray2 = memberBoxArray1;
            MemberBox.__\u003Cclinit\u003E();
            MemberBox memberBox = new MemberBox((Method) obj);
            memberBoxArray2[0] = memberBox;
          }
          else
          {
            ObjArray objArray = (ObjArray) obj;
            int length2 = objArray.size();
            if (length2 < 2)
              Kit.codeBug();
            memberBoxArray1 = new MemberBox[length2];
            for (int index = 0; index != length2; ++index)
            {
              Method method = (Method) objArray.get(index);
              memberBoxArray1[index] = new MemberBox(method);
            }
          }
          NativeJavaMethod nativeJavaMethod = new NativeJavaMethod(memberBoxArray1);
          if (obj0 != null)
            ScriptRuntime.setFunctionProtoAndParent((BaseFunction) nativeJavaMethod, obj0);
          map.put(entry.getKey(), (object) nativeJavaMethod);
        }
        ++num3;
      }
label_26:
      Field[] accessibleFields = this.getAccessibleFields(num1 != 0, num2 != 0);
      int length3 = accessibleFields.Length;
      for (int index = 0; index < length3; ++index)
      {
        Field field = accessibleFields[index];
        string name = field.getName();
        int modifiers = field.getModifiers();
        try
        {
          int num4 = Modifier.isStatic(modifiers) ? 1 : 0;
          Map map1 = num4 == 0 ? this.members : this.staticMembers;
          object obj3 = map1.get((object) name);
          if (obj3 == null || obj3 is NativeJavaMethod && !Modifier.isPrivate(modifiers))
          {
            map1.put((object) name, (object) field);
            continue;
          }
          switch (obj3)
          {
            case NativeJavaMethod _:
              NativeJavaMethod nativeJavaMethod = (NativeJavaMethod) obj3;
              FieldAndMethods.__\u003Cclinit\u003E();
              FieldAndMethods fieldAndMethods = new FieldAndMethods(obj0, nativeJavaMethod.methods, field);
              object obj4 = num4 == 0 ? (object) this.fieldAndMethods : (object) this.staticFieldAndMethods;
              if ((Map) obj4 == null)
              {
                obj4 = (object) new HashMap();
                if (num4 != 0)
                  this.staticFieldAndMethods = (Map) obj4;
                else
                  this.fieldAndMethods = (Map) obj4;
              }
              object obj5 = obj4;
              string str = name;
              object obj6 = (object) fieldAndMethods;
              object obj7 = (object) str;
              Map map2;
              if (obj5 != null)
                map2 = obj5 is Map map8 ? map8 : throw new IncompatibleClassChangeError();
              else
                map2 = (Map) null;
              object obj8 = obj7;
              object obj9 = obj6;
              map2.put(obj8, obj9);
              map1.put((object) name, (object) fieldAndMethods);
              continue;
            case Field _:
              if (((Field) obj3).getDeclaringClass().isAssignableFrom(field.getDeclaringClass()))
              {
                map1.put((object) name, (object) field);
                continue;
              }
              continue;
            default:
              Kit.codeBug();
              continue;
          }
        }
        catch (SecurityException ex)
        {
        }
        Context.reportWarning(new StringBuilder().append("Could not access field ").append(name).append(" of class ").append(this.cl.getName()).append(" due to lack of privileges.").toString());
      }
      int num5 = 0;
      while (true)
      {
        int num4;
        switch (num5)
        {
          case 0:
            num4 = 1;
            break;
          case 2:
            goto label_68;
          default:
            num4 = 0;
            break;
        }
        int num6 = num4;
        Map map1 = num6 == 0 ? this.members : this.staticMembers;
        HashMap hashMap = new HashMap();
        Iterator iterator = map1.keySet().iterator();
        while (iterator.hasNext())
        {
          string str1 = (string) iterator.next();
          int num7 = String.instancehelper_startsWith(str1, "get") ? 1 : 0;
          int num8 = String.instancehelper_startsWith(str1, "set") ? 1 : 0;
          int num9 = String.instancehelper_startsWith(str1, "is") ? 1 : 0;
          if (num7 != 0 || num9 != 0 || num8 != 0)
          {
            string str2 = String.instancehelper_substring(str1, num9 == 0 ? 3 : 2);
            if (String.instancehelper_length(str2) != 0)
            {
              string str3 = str2;
              int num10 = (int) String.instancehelper_charAt(str2, 0);
              if (Character.isUpperCase((char) num10))
              {
                if (String.instancehelper_length(str2) == 1)
                  str3 = String.instancehelper_toLowerCase(str2, (Locale) Locale.ROOT);
                else if (!Character.isUpperCase(String.instancehelper_charAt(str2, 1)))
                  str3 = new StringBuilder().append(Character.toLowerCase((char) num10)).append(String.instancehelper_substring(str2, 1)).toString();
              }
              if (!((Map) hashMap).containsKey((object) str3))
              {
                object obj3 = map1.get((object) str3);
                if (obj3 == null || num2 != 0 && obj3 is Member && Modifier.isPrivate(((Member) obj3).getModifiers()))
                {
                  MemberBox memberBox1 = this.findGetter(num6 != 0, map1, "get", str2) ?? this.findGetter(num6 != 0, map1, "is", str2);
                  MemberBox memberBox2 = (MemberBox) null;
                  NativeJavaMethod nativeJavaMethod1 = (NativeJavaMethod) null;
                  string str4 = String.instancehelper_concat("set", str2);
                  if (map1.containsKey((object) str4))
                  {
                    object obj4 = map1.get((object) str4);
                    if (obj4 is NativeJavaMethod)
                    {
                      NativeJavaMethod nativeJavaMethod2 = (NativeJavaMethod) obj4;
                      memberBox2 = memberBox1 == null ? JavaMembers.extractSetMethod(nativeJavaMethod2.methods, num6 != 0) : JavaMembers.extractSetMethod(memberBox1.method().getReturnType(), nativeJavaMethod2.methods, num6 != 0);
                      if (nativeJavaMethod2.methods.Length > 1)
                        nativeJavaMethod1 = nativeJavaMethod2;
                    }
                  }
                  BeanProperty beanProperty = new BeanProperty(memberBox1, memberBox2, nativeJavaMethod1);
                  ((Map) hashMap).put((object) str3, (object) beanProperty);
                }
              }
            }
          }
        }
        map1.putAll((Map) hashMap);
        ++num5;
      }
label_68:
      Constructor[] accessibleConstructors = this.getAccessibleConstructors(num2 != 0);
      MemberBox[] memberBoxArray3 = new MemberBox[accessibleConstructors.Length];
      for (int index1 = 0; index1 != accessibleConstructors.Length; ++index1)
      {
        MemberBox[] memberBoxArray1 = memberBoxArray3;
        int index2 = index1;
        MemberBox.__\u003Cclinit\u003E();
        MemberBox memberBox = new MemberBox(accessibleConstructors[index1]);
        memberBoxArray1[index2] = memberBox;
      }
      NativeJavaMethod.__\u003Cclinit\u003E();
      this.ctors = new NativeJavaMethod(memberBoxArray3, this.cl.getSimpleName());
    }

    [LineNumberTable(new byte[] {159, 93, 98, 105, 100, 162, 114, 98, 140, 132, 174, 106, 106, 135, 143, 105, 105, 200, 102, 120, 105, 105, 120, 108, 227, 59, 232, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private MemberBox findExplicitFunction([In] string obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      int num2 = String.instancehelper_indexOf(obj0, 40);
      if (num2 < 0)
        return (MemberBox) null;
      Map map = num1 == 0 ? this.members : this.staticMembers;
      MemberBox[] memberBoxArray1 = (MemberBox[]) null;
      if ((num1 == 0 || num2 != 0 ? 0 : 1) != 0)
      {
        memberBoxArray1 = this.ctors.methods;
      }
      else
      {
        string str = String.instancehelper_substring(obj0, 0, num2);
        object obj = map.get((object) str);
        if (num1 == 0 && obj == null)
          obj = this.staticMembers.get((object) str);
        if (obj is NativeJavaMethod)
          memberBoxArray1 = ((NativeJavaMethod) obj).methods;
      }
      if (memberBoxArray1 != null)
      {
        MemberBox[] memberBoxArray2 = memberBoxArray1;
        int length = memberBoxArray2.Length;
        for (int index = 0; index < length; ++index)
        {
          MemberBox memberBox = memberBoxArray2[index];
          string str = JavaMembers.liveConnectSignature(memberBox.argTypes);
          if (num2 + String.instancehelper_length(str) == String.instancehelper_length(obj0) && String.instancehelper_regionMatches(obj0, num2, str, 0, String.instancehelper_length(str)))
            return memberBox;
        }
      }
      return (MemberBox) null;
    }

    [LineNumberTable(new byte[] {159, 83, 163, 114, 98, 137, 102, 97, 135, 104, 136, 105, 99, 106, 98, 104, 137, 151, 137, 105, 106, 227, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getExplicitFunction([In] Scriptable obj0, [In] string obj1, [In] object obj2, [In] bool obj3)
    {
      int num = obj3 ? 1 : 0;
      Map map = num == 0 ? this.members : this.staticMembers;
      object obj = (object) null;
      MemberBox explicitFunction = this.findExplicitFunction(obj1, num != 0);
      if (explicitFunction != null)
      {
        Scriptable functionPrototype = ScriptableObject.getFunctionPrototype(obj0);
        if (explicitFunction.isCtor())
        {
          NativeJavaConstructor nativeJavaConstructor = new NativeJavaConstructor(explicitFunction);
          nativeJavaConstructor.setPrototype(functionPrototype);
          obj = (object) nativeJavaConstructor;
          map.put((object) obj1, (object) nativeJavaConstructor);
        }
        else
        {
          string name = explicitFunction.getName();
          obj = map.get((object) name);
          if (obj is NativeJavaMethod && ((NativeJavaMethod) obj).methods.Length > 1)
          {
            NativeJavaMethod nativeJavaMethod = new NativeJavaMethod(explicitFunction, obj1);
            nativeJavaMethod.setPrototype(functionPrototype);
            map.put((object) obj1, (object) nativeJavaMethod);
            obj = (object) nativeJavaMethod;
          }
        }
      }
      return obj;
    }

    [LineNumberTable(new byte[] {162, 183, 107, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual RuntimeException reportMemberNotFound([In] string obj0) => (RuntimeException) Context.reportRuntimeError2("msg.java.member.not.found", (object) this.cl.getName(), (object) obj0);

    [Signature("(Ljava/lang/Class<*>;Ljava/util/Map<Lrhino/JavaMembers$MethodSignature;Ljava/lang/reflect/Method;>;ZZ)V")]
    [LineNumberTable(new byte[] {159, 70, 100, 147, 105, 134, 108, 120, 137, 107, 138, 105, 106, 108, 104, 235, 54, 235, 78, 104, 121, 42, 200, 240, 77, 255, 9, 52, 193, 108, 120, 105, 106, 235, 61, 232, 69, 247, 69, 108, 159, 10, 137, 106, 185, 24, 225, 58, 250, 75, 97, 97, 144, 25, 229, 73, 104, 121, 42, 200, 104, 100, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void discoverAccessibleMethods([In] Class obj0, [In] Map obj1, [In] bool obj2, [In] bool obj3)
    {
      int num1 = obj3 ? 1 : 0;
      int num2 = obj2 ? 1 : 0;
      if (!Modifier.isPublic(obj0.getModifiers()))
      {
        if (num1 == 0)
          goto label_47;
      }
      try
      {
        if (num2 == 0)
        {
          if (num1 == 0)
            goto label_28;
        }
        while (true)
        {
          if (obj0 != null)
          {
            try
            {
              Method[] declaredMethods = obj0.getDeclaredMethods(JavaMembers.__\u003CGetCallerID\u003E());
              int length1 = declaredMethods.Length;
              for (int index = 0; index < length1; ++index)
              {
                Method method = declaredMethods[index];
                int modifiers = method.getModifiers();
                if (Modifier.isPublic(modifiers) || Modifier.isProtected(modifiers) || num1 != 0)
                {
                  JavaMembers.MethodSignature methodSignature = new JavaMembers.MethodSignature(method);
                  if (!obj1.containsKey((object) methodSignature))
                  {
                    if (num1 != 0 && !((AccessibleObject) method).isAccessible())
                      ((AccessibleObject) method).setAccessible(true);
                    obj1.put((object) methodSignature, (object) method);
                  }
                }
              }
              Class[] interfaces = obj0.getInterfaces();
              int length2 = interfaces.Length;
              for (int index = 0; index < length2; ++index)
                JavaMembers.discoverAccessibleMethods(interfaces[index], obj1, num2 != 0, num1 != 0);
              obj0 = obj0.getSuperclass();
            }
            catch (SecurityException ex)
            {
              goto label_19;
            }
          }
          else
            break;
        }
        return;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_20;
      }
label_19:
      try
      {
        Method[] methods = obj0.getMethods(JavaMembers.__\u003CGetCallerID\u003E());
        int length = methods.Length;
        for (int index = 0; index < length; ++index)
        {
          Method method = methods[index];
          JavaMembers.MethodSignature methodSignature = new JavaMembers.MethodSignature(method);
          if (!obj1.containsKey((object) methodSignature))
            obj1.put((object) methodSignature, (object) method);
        }
        return;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_46;
label_20:
      local = null;
      goto label_46;
label_28:
      Method[] methods1;
      int length3;
      int index1;
      try
      {
        methods1 = obj0.getMethods(JavaMembers.__\u003CGetCallerID\u003E());
        length3 = methods1.Length;
        index1 = 0;
        goto label_31;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
      local = null;
      goto label_46;
label_31:
      while (true)
      {
        try
        {
          if (index1 >= length3)
            return;
          Method method = methods1[index1];
          try
          {
            JavaMembers.MethodSignature methodSignature = new JavaMembers.MethodSignature(method);
            if (!obj1.containsKey((object) methodSignature))
            {
              obj1.put((object) methodSignature, (object) method);
              goto label_40;
            }
            else
              goto label_40;
          }
          catch (Exception ex)
          {
            ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
          }
        }
        catch (Exception ex)
        {
          ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
          break;
        }
label_40:
        try
        {
          ++index1;
        }
        catch (Exception ex)
        {
          ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
          goto label_44;
        }
      }
      local = null;
      goto label_46;
label_44:
      local = null;
label_46:
      Context.reportWarning(new StringBuilder().append("Could not discover accessible methods of class ").append(obj0.getName()).append(" due to lack of privileges, attemping superclasses/interfaces.").toString());
label_47:
      Class[] interfaces1 = obj0.getInterfaces();
      int length4 = interfaces1.Length;
      for (int index2 = 0; index2 < length4; ++index2)
        JavaMembers.discoverAccessibleMethods(interfaces1[index2], obj1, num2 != 0, num1 != 0);
      Class superclass = obj0.getSuperclass();
      if (superclass == null)
        return;
      JavaMembers.discoverAccessibleMethods(superclass, obj1, num2 != 0, num1 != 0);
    }

    [Signature("(Ljava/lang/Class<*>;ZZ)[Ljava/lang/reflect/Method;")]
    [LineNumberTable(new byte[] {159, 72, 100, 102, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Method[] discoverAccessibleMethods([In] Class obj0, [In] bool obj1, [In] bool obj2)
    {
      int num1 = obj1 ? 1 : 0;
      int num2 = obj2 ? 1 : 0;
      HashMap hashMap = new HashMap();
      JavaMembers.discoverAccessibleMethods(obj0, (Map) hashMap, num1 != 0, num2 != 0);
      return (Method[]) ((Map) hashMap).values().toArray((object[]) new Method[0]);
    }

    [LineNumberTable(new byte[] {158, 241, 68, 137, 102, 135, 166, 109, 121, 105, 117, 105, 104, 233, 59, 232, 74, 103, 133, 127, 4, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Field[] getAccessibleFields([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      int num2 = obj0 ? 1 : 0;
      if (num1 == 0)
      {
        if (num2 == 0)
          goto label_16;
      }
      Field[] array;
      try
      {
        ArrayList arrayList = new ArrayList();
        for (Class @class = this.cl; @class != null; @class = @class.getSuperclass())
        {
          Field[] declaredFields = @class.getDeclaredFields(JavaMembers.__\u003CGetCallerID\u003E());
          int length = declaredFields.Length;
          for (int index = 0; index < length; ++index)
          {
            Field field = declaredFields[index];
            int modifiers = field.getModifiers();
            if (num1 != 0 || Modifier.isPublic(modifiers) || Modifier.isProtected(modifiers))
            {
              if (!((AccessibleObject) field).isAccessible())
                ((AccessibleObject) field).setAccessible(true);
              ((List) arrayList).add((object) field);
            }
          }
        }
        array = (Field[]) ((List) arrayList).toArray((object[]) new Field[0]);
      }
      catch (SecurityException ex)
      {
        goto label_15;
      }
      return array;
label_15:
label_16:
      return this.cl.getFields(JavaMembers.__\u003CGetCallerID\u003E());
    }

    [Signature("(ZLjava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;Ljava/lang/String;Ljava/lang/String;)Lrhino/MemberBox;")]
    [LineNumberTable(new byte[] {158, 233, 66, 105, 137, 104, 104, 103, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private MemberBox findGetter([In] bool obj0, [In] Map obj1, [In] string obj2, [In] string obj3)
    {
      int num = obj0 ? 1 : 0;
      string str = String.instancehelper_concat(obj2, obj3);
      if (obj1.containsKey((object) str))
      {
        object obj = obj1.get((object) str);
        if (obj is NativeJavaMethod)
          return JavaMembers.extractGetMethod(((NativeJavaMethod) obj).methods, num != 0);
      }
      return (MemberBox) null;
    }

    [Signature("(Ljava/lang/Class<*>;[Lrhino/MemberBox;Z)Lrhino/MemberBox;")]
    [LineNumberTable(new byte[] {158, 223, 66, 105, 118, 108, 105, 102, 100, 108, 163, 106, 108, 227, 53, 43, 233, 83})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static MemberBox extractSetMethod([In] Class obj0, [In] MemberBox[] obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      for (int index1 = 1; index1 <= 2; ++index1)
      {
        MemberBox[] memberBoxArray = obj1;
        int length = memberBoxArray.Length;
        for (int index2 = 0; index2 < length; ++index2)
        {
          MemberBox memberBox = memberBoxArray[index2];
          if (num == 0 || memberBox.isStatic())
          {
            Class[] argTypes = memberBox.argTypes;
            if (argTypes.Length == 1)
            {
              switch (index1)
              {
                case 1:
                  if (object.ReferenceEquals((object) argTypes[0], (object) obj0))
                    return memberBox;
                  continue;
                case 2:
                  if (argTypes[0].isAssignableFrom(obj0))
                    return memberBox;
                  continue;
                default:
                  Kit.codeBug();
                  goto case 2;
              }
            }
          }
        }
      }
      return (MemberBox) null;
    }

    [LineNumberTable(new byte[] {158, 217, 98, 112, 108, 120, 107, 227, 60, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static MemberBox extractSetMethod([In] MemberBox[] obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      MemberBox[] memberBoxArray = obj0;
      int length = memberBoxArray.Length;
      for (int index = 0; index < length; ++index)
      {
        MemberBox memberBox = memberBoxArray[index];
        if ((num == 0 || memberBox.isStatic()) && (object.ReferenceEquals((object) memberBox.method().getReturnType(), (object) Void.TYPE) && memberBox.argTypes.Length == 1))
          return memberBox;
      }
      return (MemberBox) null;
    }

    [Signature("(Z)[Ljava/lang/reflect/Constructor<*>;")]
    [LineNumberTable(new byte[] {158, 246, 130, 155, 113, 135, 112, 129, 117, 57, 229, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Constructor[] getAccessibleConstructors([In] bool obj0)
    {
      if (obj0)
      {
        if (!object.ReferenceEquals((object) this.cl, (object) ScriptRuntime.__\u003C\u003EClassClass))
        {
          Constructor[] constructorArray;
          try
          {
            Constructor[] declaredConstructors = this.cl.getDeclaredConstructors(JavaMembers.__\u003CGetCallerID\u003E());
            AccessibleObject.setAccessible((AccessibleObject[]) declaredConstructors, true);
            constructorArray = declaredConstructors;
          }
          catch (SecurityException ex)
          {
            goto label_5;
          }
          return constructorArray;
label_5:
          Context.reportWarning(new StringBuilder().append("Could not access constructor  of class ").append(this.cl.getName()).append(" due to lack of privileges.").toString());
        }
      }
      return this.cl.getConstructors(JavaMembers.__\u003CGetCallerID\u003E());
    }

    [LineNumberTable(new byte[] {158, 229, 66, 176, 118, 110, 110, 227, 58, 230, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static MemberBox extractGetMethod([In] MemberBox[] obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      MemberBox[] memberBoxArray = obj0;
      int length = memberBoxArray.Length;
      for (int index = 0; index < length; ++index)
      {
        MemberBox memberBox = memberBoxArray[index];
        if (memberBox.argTypes.Length == 0 && (num == 0 || memberBox.isStatic()))
        {
          if (!object.ReferenceEquals((object) memberBox.method().getReturnType(), (object) Void.TYPE))
            return memberBox;
          break;
        }
      }
      return (MemberBox) null;
    }

    [Signature("(Lrhino/Scriptable;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {159, 158, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal JavaMembers([In] Scriptable obj0, [In] Class obj1)
      : this(obj0, obj1, false)
    {
    }

    [LineNumberTable(new byte[] {159, 133, 162, 114, 104, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool has([In] string obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      return (num == 0 ? this.members : this.staticMembers).get((object) obj0) != null || this.findExplicitFunction(obj0, num != 0) != null;
    }

    [LineNumberTable(new byte[] {159, 130, 99, 114, 104, 134, 141, 99, 139, 99, 134, 104, 130, 198, 104, 104, 105, 108, 116, 115, 98, 104, 117, 223, 6, 2, 98, 173, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object get([In] Scriptable obj0, [In] string obj1, [In] object obj2, [In] bool obj3)
    {
      int num = obj3 ? 1 : 0;
      object explicitFunction = (num == 0 ? this.members : this.staticMembers).get((object) obj1);
      if (num == 0 && explicitFunction == null)
        explicitFunction = this.staticMembers.get((object) obj1);
      if (explicitFunction == null)
      {
        explicitFunction = this.getExplicitFunction(obj0, obj1, obj2, num != 0);
        if (explicitFunction == null)
          return Scriptable.NOT_FOUND;
      }
      if (explicitFunction is Scriptable)
        return explicitFunction;
      Context context = Context.getContext();
      object obj;
      Class staticType;
      Exception exception;
      try
      {
        if (explicitFunction is BeanProperty)
        {
          BeanProperty beanProperty = (BeanProperty) explicitFunction;
          if (beanProperty.getter == null)
            return Scriptable.NOT_FOUND;
          obj = beanProperty.getter.invoke(obj2, Context.__\u003C\u003EemptyArgs);
          staticType = beanProperty.getter.method().getReturnType();
          goto label_17;
        }
        else
        {
          Field field = (Field) explicitFunction;
          obj = field.get(num == 0 ? obj2 : (object) null, JavaMembers.__\u003CGetCallerID\u003E());
          staticType = field.getType();
          goto label_17;
        }
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
label_17:
      obj0 = ScriptableObject.getTopLevelScope(obj0);
      return context.getWrapFactory().wrap(context, obj0, obj, staticType);
    }

    [LineNumberTable(new byte[] {159, 120, 99, 114, 104, 134, 141, 99, 109, 104, 109, 199, 107, 104, 105, 237, 69, 112, 112, 148, 191, 10, 2, 98, 141, 98, 109, 109, 40, 198, 101, 104, 145, 142, 104, 144, 255, 9, 76, 226, 53, 98, 140, 129, 109, 97, 135, 109, 234, 61, 235, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void put([In] Scriptable obj0, [In] string obj1, [In] object obj2, [In] object obj3, [In] bool obj4)
    {
      int num = obj4 ? 1 : 0;
      Map map = num == 0 ? this.members : this.staticMembers;
      object field1 = map.get((object) obj1);
      if (num == 0 && field1 == null)
        field1 = this.staticMembers.get((object) obj1);
      if (field1 == null)
        throw Throwable.__\u003Cunmap\u003E((Exception) this.reportMemberNotFound(obj1));
      if (field1 is FieldAndMethods)
        field1 = (object) ((FieldAndMethods) map.get((object) obj1)).field;
      if (field1 is BeanProperty)
      {
        BeanProperty beanProperty = (BeanProperty) field1;
        if (beanProperty.setter == null)
          throw Throwable.__\u003Cunmap\u003E((Exception) this.reportMemberNotFound(obj1));
        if (beanProperty.setters == null || obj3 == null)
        {
          Class argType = beanProperty.setter.argTypes[0];
          object[] objArray = new object[1]
          {
            Context.jsToJava(obj3, argType)
          };
          Exception exception;
          try
          {
            beanProperty.setter.invoke(obj2, objArray);
            return;
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
        }
        object[] args = new object[1]{ obj3 };
        beanProperty.setters.call(Context.getContext(), ScriptableObject.getTopLevelScope(obj0), obj0, args);
      }
      else
      {
        Field field2 = field1 is Field ? (Field) field1 : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1(field1 != null ? "msg.java.method.assign" : "msg.java.internal.private", (object) obj1));
        object java = Context.jsToJava(obj3, field2.getType());
        IllegalAccessException illegalAccessException1;
        try
        {
          try
          {
            field2.set(obj2, java, JavaMembers.__\u003CGetCallerID\u003E());
            return;
          }
          catch (IllegalAccessException ex)
          {
            illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
        }
        catch (IllegalArgumentException ex)
        {
          goto label_24;
        }
        IllegalAccessException illegalAccessException2 = illegalAccessException1;
        if ((field2.getModifiers() & 16) != 0)
          return;
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) illegalAccessException2));
label_24:
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError3("msg.java.internal.field.type", (object) Object.instancehelper_getClass(obj3).getName(), (object) field2, (object) Object.instancehelper_getClass(obj2).getName()));
      }
    }

    [LineNumberTable(new byte[] {159, 105, 162, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object[] getIds([In] bool obj0) => (!obj0 ? this.members : this.staticMembers).keySet().toArray(new object[0]);

    [Signature("(Lrhino/Scriptable;Ljava/lang/Object;Z)Ljava/util/Map<Ljava/lang/String;Lrhino/FieldAndMethods;>;")]
    [LineNumberTable(new byte[] {158, 214, 162, 114, 99, 98, 103, 103, 127, 5, 155, 104, 117, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Map getFieldAndMethodsObjects([In] Scriptable obj0, [In] object obj1, [In] bool obj2)
    {
      Map map = !obj2 ? this.fieldAndMethods : this.staticFieldAndMethods;
      if (map == null)
        return (Map) null;
      HashMap hashMap = new HashMap(map.size());
      Iterator iterator = map.values().iterator();
      while (iterator.hasNext())
      {
        FieldAndMethods fieldAndMethods = (FieldAndMethods) iterator.next();
        FieldAndMethods.__\u003Cclinit\u003E();
        ((Map) hashMap).put((object) fieldAndMethods.field.getName(), (object) new FieldAndMethods(obj0, fieldAndMethods.methods, fieldAndMethods.field)
        {
          javaObject = obj1
        });
      }
      return (Map) hashMap;
    }

    [Signature("(Lrhino/Scriptable;Ljava/lang/Class<*>;Ljava/lang/Class<*>;Z)Lrhino/JavaMembers;")]
    [LineNumberTable(new byte[] {158, 209, 66, 103, 135, 130, 110, 100, 169, 138, 163, 159, 4, 98, 226, 69, 107, 98, 133, 104, 100, 136, 137, 168, 131, 165, 104, 106, 169, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static JavaMembers lookupClass(
      [In] Scriptable obj0,
      [In] Class obj1,
      [In] Class obj2,
      [In] bool obj3)
    {
      int num = obj3 ? 1 : 0;
      ClassCache classCache = ClassCache.get(obj0);
      Map classCacheMap = classCache.getClassCacheMap();
      Class class1 = obj1;
      JavaMembers javaMembers1;
      JavaMembers javaMembers2;
      SecurityException securityException1;
      while (true)
      {
        javaMembers1 = (JavaMembers) classCacheMap.get((object) class1);
        if (javaMembers1 == null)
        {
          SecurityException securityException2;
          try
          {
            javaMembers2 = new JavaMembers(classCache.getAssociatedScope(), class1, num != 0);
            goto label_14;
          }
          catch (SecurityException ex)
          {
            securityException2 = (SecurityException) ByteCodeHelper.MapException<SecurityException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          securityException1 = securityException2;
          if (obj2 != null && obj2.isInterface())
          {
            class1 = obj2;
            obj2 = (Class) null;
          }
          else
          {
            Class class2 = class1.getSuperclass();
            if (class2 == null)
            {
              if (class1.isInterface())
                class2 = ScriptRuntime.__\u003C\u003EObjectClass;
              else
                goto label_12;
            }
            class1 = class2;
          }
        }
        else
          break;
      }
      if (!object.ReferenceEquals((object) class1, (object) obj1))
        classCacheMap.put((object) obj1, (object) javaMembers1);
      return javaMembers1;
label_12:
      throw Throwable.__\u003Cunmap\u003E((Exception) securityException1);
label_14:
      if (classCache.isCachingEnabled())
      {
        classCacheMap.put((object) class1, (object) javaMembers2);
        if (!object.ReferenceEquals((object) class1, (object) obj1))
          classCacheMap.put((object) obj1, (object) javaMembers2);
      }
      return javaMembers2;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (JavaMembers.__\u003CcallerID\u003E == null)
        JavaMembers.__\u003CcallerID\u003E = (CallerID) new JavaMembers.__\u003CCallerID\u003E();
      return JavaMembers.__\u003CcallerID\u003E;
    }

    [InnerClass]
    internal sealed class MethodSignature : Object
    {
      [Modifiers]
      private string name;
      [Modifiers]
      [Signature("[Ljava/lang/Class<*>;")]
      private Class[] args;

      [Signature("(Ljava/lang/String;[Ljava/lang/Class<*>;)V")]
      [LineNumberTable(new byte[] {160, 255, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private MethodSignature([In] string obj0, [In] Class[] obj1)
      {
        JavaMembers.MethodSignature methodSignature = this;
        this.name = obj0;
        this.args = obj1;
      }

      [LineNumberTable(new byte[] {161, 5, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal MethodSignature([In] Method obj0)
        : this(obj0.getName(), obj0.getParameterTypes())
      {
      }

      [LineNumberTable(new byte[] {161, 10, 104, 103, 159, 12})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool equals([In] object obj0)
      {
        if (!(obj0 is JavaMembers.MethodSignature))
          return false;
        JavaMembers.MethodSignature methodSignature = (JavaMembers.MethodSignature) obj0;
        return String.instancehelper_equals(methodSignature.name, (object) this.name) && Arrays.equals((object[]) this.args, (object[]) methodSignature.args);
      }

      [LineNumberTable(389)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int hashCode() => String.instancehelper_hashCode(this.name) ^ this.args.Length;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
