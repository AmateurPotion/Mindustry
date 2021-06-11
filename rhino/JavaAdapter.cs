// Decompiled with JetBrains decompiler
// Type: rhino.JavaAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.lang.reflect;
using java.security;
using java.util;
using rhino.classfile;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public sealed class JavaAdapter : Object, IdFunctionCall
  {
    [Modifiers]
    private static object FTAG;
    private const int Id_JavaAdapter = 1;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JavaAdapter()
    {
    }

    [LineNumberTable(new byte[] {55, 99, 99, 240, 74, 107, 228, 69, 104, 165, 127, 3, 191, 1, 104, 102, 102, 5, 235, 49, 233, 84, 98, 104, 99, 107, 112, 105, 99, 102, 44, 171, 133, 237, 55, 235, 77, 99, 166, 105, 141, 138, 173, 135, 200, 107, 102, 106, 142, 139, 110, 108, 101, 104, 103, 39, 235, 69, 115, 98, 216, 118, 188, 139, 105, 110, 105, 105, 173, 166, 127, 6, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object js_createAdapter([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      int length1 = obj2.Length;
      if (length1 == 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.adapter.zero.args"));
      int length2;
      for (length2 = 0; length2 < length1 - 1; ++length2)
      {
        object val = obj2[length2];
        switch (val)
        {
          case NativeObject _:
            goto label_10;
          case NativeJavaObject _:
            if (((NativeJavaObject) val).unwrap() is Class)
            {
              object[] objArray = obj2;
              int index = length2;
              NativeJavaClass.__\u003Cclinit\u003E();
              NativeJavaClass nativeJavaClass;
              val = (object) (nativeJavaClass = new NativeJavaClass(obj1, (Class) ((NativeJavaObject) val).unwrap()));
              objArray[index] = (object) nativeJavaClass;
              break;
            }
            break;
        }
        if (!(val is NativeJavaClass))
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError2("msg.not.java.class.arg", (object) String.valueOf(length2), (object) ScriptRuntime.toString(val)));
      }
label_10:
      Class class1 = (Class) null;
      Class[] classArray1 = new Class[length2];
      int length3 = 0;
      for (int index1 = 0; index1 < length2; ++index1)
      {
        Class classObject = ((NativeJavaClass) obj2[index1]).getClassObject();
        if (!classObject.isInterface())
        {
          class1 = class1 == null ? classObject : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError2("msg.only.one.super", (object) class1.getName(), (object) classObject.getName()));
        }
        else
        {
          Class[] classArray2 = classArray1;
          int index2 = length3;
          ++length3;
          Class class2 = classObject;
          classArray2[index2] = class2;
        }
      }
      if (class1 == null)
        class1 = ScriptRuntime.__\u003C\u003EObjectClass;
      Class[] classArray3 = new Class[length3];
      ByteCodeHelper.arraycopy_fast((Array) classArray1, 0, (Array) classArray3, 0, length3);
      Scriptable scriptable = ScriptableObject.ensureScriptable(obj2[length2]);
      Class adapterClass = JavaAdapter.getAdapterClass(obj1, class1, classArray3, scriptable);
      int num = length1 - length2 - 1;
      object obj3;
      Exception exception;
      try
      {
        object adapter;
        if (num > 0)
        {
          object[] objArray = new object[num + 2];
          objArray[0] = (object) scriptable;
          objArray[1] = (object) obj0.getFactory();
          ByteCodeHelper.arraycopy((object) obj2, length2 + 1, (object) objArray, 2, num);
          NativeJavaMethod ctors = new NativeJavaClass(obj1, adapterClass, true).__\u003C\u003Emembers.ctors;
          int cachedFunction = ctors.findCachedFunction(obj0, objArray);
          if (cachedFunction < 0)
          {
            string str = NativeJavaMethod.scriptSignature(obj2);
            throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.no.java.ctor", (object) adapterClass.getName(), (object) str));
          }
          adapter = NativeJavaClass.constructInternal(objArray, ctors.methods[cachedFunction]);
        }
        else
        {
          Class[] classArray2 = new Class[2]
          {
            ScriptRuntime.__\u003C\u003EScriptableClass,
            ScriptRuntime.__\u003C\u003EContextFactoryClass
          };
          object[] objArray = new object[2]
          {
            (object) scriptable,
            (object) obj0.getFactory()
          };
          adapter = adapterClass.getConstructor(classArray2, JavaAdapter.__\u003CGetCallerID\u003E()).newInstance(objArray, JavaAdapter.__\u003CGetCallerID\u003E());
        }
        object adapterSelf = JavaAdapter.getAdapterSelf(adapterClass, adapter);
        if (adapterSelf is Wrapper)
        {
          object obj4 = ((Wrapper) adapterSelf).unwrap();
          if (obj4 is Scriptable)
          {
            if (obj4 is ScriptableObject)
              ScriptRuntime.setObjectProtoAndParent((ScriptableObject) obj4, obj1);
            return obj4;
          }
        }
        obj3 = adapterSelf;
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
          exception = (Exception) m0;
          goto label_36;
        }
      }
      return obj3;
label_36:
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.throwAsScriptRuntimeEx((Exception) exception));
    }

    [Signature("(Lrhino/Scriptable;Ljava/lang/Class<*>;[Ljava/lang/Class<*>;Lrhino/Scriptable;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {160, 187, 103, 97, 134, 135, 105, 110, 100, 127, 2, 173, 107, 104, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Class getAdapterClass(
      [In] Scriptable obj0,
      [In] Class obj1,
      [In] Class[] obj2,
      [In] Scriptable obj3)
    {
      ClassCache classCache = ClassCache.get(obj0);
      Map interfaceAdapterCacheMap = classCache.getInterfaceAdapterCacheMap();
      ObjToIntMap objectFunctionNames = JavaAdapter.getObjectFunctionNames(obj3);
      JavaAdapter.JavaAdapterSignature adapterSignature = new JavaAdapter.JavaAdapterSignature(obj1, obj2, objectFunctionNames);
      Class @class = (Class) interfaceAdapterCacheMap.get((object) adapterSignature);
      if (@class == null)
      {
        string adapterName = new StringBuilder().append("adapter").append(classCache.newClassSerialNumber()).toString();
        byte[] adapterCode = JavaAdapter.createAdapterCode(objectFunctionNames, adapterName, obj1, obj2, (string) null);
        @class = JavaAdapter.loadAdapterClass(adapterName, adapterCode);
        if (classCache.isCachingEnabled())
          interfaceAdapterCacheMap.put((object) adapterSignature, (object) @class);
      }
      return @class;
    }

    [Throws(new string[] {"java.lang.NoSuchFieldException", "java.lang.IllegalAccessException"})]
    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {50, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getAdapterSelf(Class adapterClass, object adapter) => adapterClass.getDeclaredField("self", JavaAdapter.__\u003CGetCallerID\u003E()).get(adapter, JavaAdapter.__\u003CGetCallerID\u003E());

    [LineNumberTable(new byte[] {160, 165, 103, 109, 106, 106, 98, 105, 105, 105, 105, 103, 37, 135, 101, 131, 233, 52, 233, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ObjToIntMap getObjectFunctionNames([In] Scriptable obj0)
    {
      object[] propertyIds = ScriptableObject.getPropertyIds(obj0);
      ObjToIntMap.__\u003Cclinit\u003E();
      ObjToIntMap objToIntMap = new ObjToIntMap(propertyIds.Length);
      for (int index = 0; index != propertyIds.Length; ++index)
      {
        if (propertyIds[index] is string)
        {
          string name = (string) propertyIds[index];
          object property = ScriptableObject.getProperty(obj0, name);
          if (property is Function)
          {
            int num = ScriptRuntime.toInt32(ScriptableObject.getProperty((Scriptable) property, "length"));
            if (num < 0)
              num = 0;
            objToIntMap.put((object) name, num);
          }
        }
      }
      return objToIntMap;
    }

    [Signature("(Lrhino/ObjToIntMap;Ljava/lang/String;Ljava/lang/Class<*>;[Ljava/lang/Class<*>;Ljava/lang/String;)[B")]
    [LineNumberTable(new byte[] {160, 213, 103, 144, 178, 178, 178, 105, 102, 101, 14, 230, 69, 112, 109, 121, 105, 114, 234, 61, 232, 70, 104, 100, 170, 103, 167, 107, 112, 109, 103, 105, 127, 2, 133, 105, 105, 138, 219, 98, 225, 70, 107, 122, 107, 104, 38, 133, 106, 234, 37, 11, 235, 102, 104, 109, 103, 201, 105, 105, 177, 105, 107, 122, 107, 104, 38, 133, 106, 202, 100, 139, 5, 229, 41, 235, 97, 104, 115, 110, 107, 98, 105, 105, 105, 42, 136, 241, 56, 236, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] createAdapterCode(
      ObjToIntMap functionNames,
      string adapterName,
      Class superClass,
      Class[] interfaces,
      string scriptClassName)
    {
      ClassFileWriter.__\u003Cclinit\u003E();
      ClassFileWriter classFileWriter = new ClassFileWriter(adapterName, superClass.getName(), "<adapter>");
      classFileWriter.addField("factory", "Lrhino/ContextFactory;", (short) 17);
      classFileWriter.addField("delegee", "Lrhino/Scriptable;", (short) 17);
      classFileWriter.addField("self", "Lrhino/Scriptable;", (short) 17);
      int num1 = interfaces != null ? interfaces.Length : 0;
      for (int index = 0; index < num1; ++index)
      {
        if (interfaces[index] != null)
          classFileWriter.addInterface(interfaces[index].getName());
      }
      string str1 = String.instancehelper_replace(superClass.getName(), '.', '/');
      Constructor[] declaredConstructors = superClass.getDeclaredConstructors(JavaAdapter.__\u003CGetCallerID\u003E());
      int length1 = declaredConstructors.Length;
      for (int index = 0; index < length1; ++index)
      {
        Constructor constructor = declaredConstructors[index];
        int modifiers = constructor.getModifiers();
        if (Modifier.isPublic(modifiers) || Modifier.isProtected(modifiers))
          JavaAdapter.generateCtor(classFileWriter, adapterName, str1, constructor);
      }
      JavaAdapter.generateSerialCtor(classFileWriter, adapterName, str1);
      if (scriptClassName != null)
        JavaAdapter.generateEmptyCtor(classFileWriter, adapterName, str1, scriptClassName);
      ObjToIntMap objToIntMap1 = new ObjToIntMap();
      ObjToIntMap objToIntMap2 = new ObjToIntMap();
      for (int index = 0; index < num1; ++index)
      {
        foreach (Method method in interfaces[index].getMethods(JavaAdapter.__\u003CGetCallerID\u003E()))
        {
          int modifiers = method.getModifiers();
          if (!Modifier.isStatic(modifiers) && !Modifier.isFinal(modifiers) && !method.isDefault())
          {
            string name = method.getName();
            Class[] parameterTypes = method.getParameterTypes();
            if (!functionNames.has((object) name))
            {
              try
              {
                superClass.getMethod(name, parameterTypes, JavaAdapter.__\u003CGetCallerID\u003E());
                continue;
              }
              catch (NoSuchMethodException ex)
              {
              }
            }
            string methodSignature = JavaAdapter.getMethodSignature(method, parameterTypes);
            string str2 = new StringBuilder().append(name).append(methodSignature).toString();
            if (!objToIntMap1.has((object) str2))
            {
              JavaAdapter.generateMethod(classFileWriter, adapterName, name, parameterTypes, method.getReturnType(), true);
              objToIntMap1.put((object) str2, 0);
              objToIntMap2.put((object) name, 0);
            }
          }
        }
      }
      foreach (Method overridableMethod in JavaAdapter.getOverridableMethods(superClass))
      {
        int num2 = Modifier.isAbstract(overridableMethod.getModifiers()) ? 1 : 0;
        string name = overridableMethod.getName();
        if (num2 != 0 || functionNames.has((object) name))
        {
          Class[] parameterTypes = overridableMethod.getParameterTypes();
          string methodSignature = JavaAdapter.getMethodSignature(overridableMethod, parameterTypes);
          string str2 = new StringBuilder().append(name).append(methodSignature).toString();
          if (!objToIntMap1.has((object) str2))
          {
            JavaAdapter.generateMethod(classFileWriter, adapterName, name, parameterTypes, overridableMethod.getReturnType(), true);
            objToIntMap1.put((object) str2, 0);
            objToIntMap2.put((object) name, 0);
            if (num2 == 0)
              JavaAdapter.generateSuper(classFileWriter, adapterName, str1, name, methodSignature, parameterTypes, overridableMethod.getReturnType());
          }
        }
      }
      ObjToIntMap.Iterator iterator = new ObjToIntMap.Iterator(functionNames);
      iterator.start();
      while (!iterator.done())
      {
        string key = (string) iterator.getKey();
        if (!objToIntMap2.has((object) key))
        {
          int length2 = iterator.getValue();
          Class[] classArray = new Class[length2];
          for (int index = 0; index < length2; ++index)
            classArray[index] = ScriptRuntime.__\u003C\u003EObjectClass;
          JavaAdapter.generateMethod(classFileWriter, adapterName, key, classArray, ScriptRuntime.__\u003C\u003EObjectClass, false);
        }
        iterator.next();
      }
      return classFileWriter.toByteArray();
    }

    [Signature("(Ljava/lang/String;[B)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {161, 123, 102, 154, 102, 99, 139, 109, 143, 130, 98, 130, 136, 106, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Class loadAdapterClass([In] string obj0, [In] byte[] obj1)
    {
      Class securityDomainClass = SecurityController.getStaticSecurityDomainClass();
      object staticDomain;
      if (object.ReferenceEquals((object) securityDomainClass, (object) ClassLiteral<CodeSource>.Value) || object.ReferenceEquals((object) securityDomainClass, (object) ClassLiteral<ProtectionDomain>.Value))
      {
        ProtectionDomain protectionDomain = SecurityUtilities.getScriptProtectionDomain() ?? ((Class) ClassLiteral<JavaAdapter>.Value).getProtectionDomain();
        staticDomain = !object.ReferenceEquals((object) securityDomainClass, (object) ClassLiteral<CodeSource>.Value) ? (object) protectionDomain : (object) protectionDomain?.getCodeSource();
      }
      else
        staticDomain = (object) null;
      GeneratedClassLoader loader = SecurityController.createLoader((ClassLoader) null, staticDomain);
      Class c = loader.defineClass(obj0, obj1);
      loader.linkClass(c);
      return c;
    }

    [Signature("(Lrhino/classfile/ClassFileWriter;Ljava/lang/String;Ljava/lang/String;Ljava/lang/reflect/Constructor<*>;)V")]
    [LineNumberTable(new byte[] {161, 215, 98, 199, 100, 241, 70, 104, 155, 171, 103, 120, 41, 168, 108, 178, 104, 99, 120, 48, 168, 99, 105, 215, 104, 104, 214, 104, 104, 182, 136, 104, 104, 250, 70, 182, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generateCtor(
      [In] ClassFileWriter obj0,
      [In] string obj1,
      [In] string obj2,
      [In] Constructor obj3)
    {
      int num1 = 3;
      Class[] parameterTypes = obj3.getParameterTypes();
      if (parameterTypes.Length == 0)
      {
        obj0.startMethod("<init>", "(Lrhino/Scriptable;Lrhino/ContextFactory;)V", (short) 1);
        obj0.add(42);
        obj0.addInvoke(183, obj2, "<init>", "()V");
      }
      else
      {
        StringBuilder stringBuilder = new StringBuilder("(Lrhino/Scriptable;Lrhino/ContextFactory;");
        int num2 = stringBuilder.length();
        Class[] classArray1 = parameterTypes;
        int length1 = classArray1.Length;
        for (int index = 0; index < length1; ++index)
        {
          Class @class = classArray1[index];
          JavaAdapter.appendTypeString(stringBuilder, @class);
        }
        stringBuilder.append(")V");
        obj0.startMethod("<init>", stringBuilder.toString(), (short) 1);
        obj0.add(42);
        int num3 = 3;
        Class[] classArray2 = parameterTypes;
        int length2 = classArray2.Length;
        for (int index = 0; index < length2; ++index)
        {
          Class @class = classArray2[index];
          num3 = (int) (short) (num3 + JavaAdapter.generatePushParam(obj0, num3, @class));
        }
        num1 = num3;
        stringBuilder.delete(1, num2);
        obj0.addInvoke(183, obj2, "<init>", stringBuilder.toString());
      }
      obj0.add(42);
      obj0.add(43);
      obj0.add(181, obj1, "delegee", "Lrhino/Scriptable;");
      obj0.add(42);
      obj0.add(44);
      obj0.add(181, obj1, "factory", "Lrhino/ContextFactory;");
      obj0.add(42);
      obj0.add(43);
      obj0.add(42);
      obj0.addInvoke(184, "rhino/JavaAdapter", "createAdapterWrapper", "(Lrhino/Scriptable;Ljava/lang/Object;)Lrhino/Scriptable;");
      obj0.add(181, obj1, "self", "Lrhino/Scriptable;");
      obj0.add(177);
      obj0.stopMethod((short) num1);
    }

    [LineNumberTable(new byte[] {162, 27, 241, 72, 104, 182, 104, 104, 214, 104, 104, 182, 104, 104, 182, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generateSerialCtor([In] ClassFileWriter obj0, [In] string obj1, [In] string obj2)
    {
      obj0.startMethod("<init>", "(Lrhino/ContextFactory;Lrhino/Scriptable;Lrhino/Scriptable;)V", (short) 1);
      obj0.add(42);
      obj0.addInvoke(183, obj2, "<init>", "()V");
      obj0.add(42);
      obj0.add(43);
      obj0.add(181, obj1, "factory", "Lrhino/ContextFactory;");
      obj0.add(42);
      obj0.add(44);
      obj0.add(181, obj1, "delegee", "Lrhino/Scriptable;");
      obj0.add(42);
      obj0.add(45);
      obj0.add(181, obj1, "self", "Lrhino/Scriptable;");
      obj0.add(177);
      obj0.stopMethod((short) 4);
    }

    [LineNumberTable(new byte[] {162, 63, 177, 104, 182, 104, 103, 214, 108, 104, 182, 250, 69, 168, 104, 104, 182, 136, 104, 104, 250, 70, 182, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generateEmptyCtor(
      [In] ClassFileWriter obj0,
      [In] string obj1,
      [In] string obj2,
      [In] string obj3)
    {
      obj0.startMethod("<init>", "()V", (short) 1);
      obj0.add(42);
      obj0.addInvoke(183, obj2, "<init>", "()V");
      obj0.add(42);
      obj0.add(1);
      obj0.add(181, obj1, "factory", "Lrhino/ContextFactory;");
      obj0.add(187, obj3);
      obj0.add(89);
      obj0.addInvoke(183, obj3, "<init>", "()V");
      obj0.addInvoke(184, "rhino/JavaAdapter", "runScript", "(Lrhino/Script;)Lrhino/Scriptable;");
      obj0.add(76);
      obj0.add(42);
      obj0.add(43);
      obj0.add(181, obj1, "delegee", "Lrhino/Scriptable;");
      obj0.add(42);
      obj0.add(43);
      obj0.add(42);
      obj0.addInvoke(184, "rhino/JavaAdapter", "createAdapterWrapper", "(Lrhino/Scriptable;Ljava/lang/Object;)Lrhino/Scriptable;");
      obj0.add(181, obj1, "self", "Lrhino/Scriptable;");
      obj0.add(177);
      obj0.stopMethod((short) 2);
    }

    [Signature("(Ljava/lang/reflect/Method;[Ljava/lang/Class<*>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {163, 194, 102, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string getMethodSignature([In] Method obj0, [In] Class[] obj1)
    {
      StringBuilder stringBuilder = new StringBuilder();
      JavaAdapter.appendMethodSignature(obj1, obj0.getReturnType(), stringBuilder);
      return stringBuilder.toString();
    }

    [Signature("(Lrhino/classfile/ClassFileWriter;Ljava/lang/String;Ljava/lang/String;[Ljava/lang/Class<*>;Ljava/lang/Class<*>;Z)V")]
    [LineNumberTable(new byte[] {158, 173, 131, 102, 106, 103, 233, 70, 104, 214, 104, 214, 104, 150, 103, 250, 72, 169, 166, 208, 100, 105, 107, 13, 232, 69, 200, 250, 74, 137, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generateMethod(
      [In] ClassFileWriter obj0,
      [In] string obj1,
      [In] string obj2,
      [In] Class[] obj3,
      [In] Class obj4,
      [In] bool obj5)
    {
      int num1 = obj5 ? 1 : 0;
      StringBuilder stringBuilder = new StringBuilder();
      int num2 = JavaAdapter.appendMethodSignature(obj3, obj4, stringBuilder);
      string type = stringBuilder.toString();
      obj0.startMethod(obj2, type, (short) 1);
      obj0.add(42);
      obj0.add(180, obj1, "factory", "Lrhino/ContextFactory;");
      obj0.add(42);
      obj0.add(180, obj1, "self", "Lrhino/Scriptable;");
      obj0.add(42);
      obj0.add(180, obj1, "delegee", "Lrhino/Scriptable;");
      obj0.addPush(obj2);
      obj0.addInvoke(184, "rhino/JavaAdapter", "getFunction", "(Lrhino/Scriptable;Ljava/lang/String;)Lrhino/Function;");
      JavaAdapter.generatePushWrappedArgs(obj0, obj3, obj3.Length);
      if (obj3.Length > 64)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("JavaAdapter can not subclass methods with more then 64 arguments."));
      long k = 0;
      for (int index = 0; index != obj3.Length; ++index)
      {
        if (!obj3[index].isPrimitive())
          k |= (long) (1 << index);
      }
      obj0.addPush(k);
      obj0.addInvoke(184, "rhino/JavaAdapter", "callMethod", "(Lrhino/ContextFactory;Lrhino/Scriptable;Lrhino/Function;[Ljava/lang/Object;J)Ljava/lang/Object;");
      JavaAdapter.generateReturnResult(obj0, obj4, num1 != 0);
      obj0.stopMethod((short) num2);
    }

    [Signature("(Ljava/lang/Class<*>;)[Ljava/lang/reflect/Method;")]
    [LineNumberTable(new byte[] {161, 80, 102, 230, 69, 101, 40, 169, 101, 122, 41, 40, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Method[] getOverridableMethods([In] Class obj0)
    {
      ArrayList arrayList = new ArrayList();
      HashSet hashSet = new HashSet();
      for (Class @class = obj0; @class != null; @class = @class.getSuperclass())
        JavaAdapter.appendOverridableMethods(@class, arrayList, hashSet);
      for (Class @class = obj0; @class != null; @class = @class.getSuperclass())
      {
        Class[] interfaces = @class.getInterfaces();
        int length = interfaces.Length;
        for (int index = 0; index < length; ++index)
          JavaAdapter.appendOverridableMethods(interfaces[index], arrayList, hashSet);
      }
      return (Method[]) arrayList.toArray((object[]) new Method[0]);
    }

    [Signature("(Lrhino/classfile/ClassFileWriter;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;[Ljava/lang/Class<*>;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {163, 162, 223, 4, 169, 98, 113, 44, 230, 69, 239, 70, 100, 110, 138, 139, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generateSuper(
      [In] ClassFileWriter obj0,
      [In] string obj1,
      [In] string obj2,
      [In] string obj3,
      [In] string obj4,
      [In] Class[] obj5,
      [In] Class obj6)
    {
      obj0.startMethod(new StringBuilder().append("super$").append(obj3).toString(), obj4, (short) 1);
      obj0.add(25, 0);
      int num = 1;
      Class[] classArray = obj5;
      int length = classArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Class @class = classArray[index];
        num += JavaAdapter.generatePushParam(obj0, num, @class);
      }
      obj0.addInvoke(183, obj2, obj3, obj4);
      Class class1 = obj6;
      if (!Object.instancehelper_equals((object) class1, (object) Void.TYPE))
        JavaAdapter.generatePopResult(obj0, class1);
      else
        obj0.add(177);
      obj0.stopMethod((short) (num + 1));
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/util/ArrayList<Ljava/lang/reflect/Method;>;Ljava/util/HashSet<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {161, 98, 108, 106, 152, 37, 144, 105, 98, 105, 104, 98, 168, 104, 130, 112, 106, 232, 47, 233, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void appendOverridableMethods([In] Class obj0, [In] ArrayList obj1, [In] HashSet obj2)
    {
      Method[] declaredMethods = obj0.getDeclaredMethods(JavaAdapter.__\u003CGetCallerID\u003E());
      for (int index = 0; index < declaredMethods.Length; ++index)
      {
        string str = new StringBuilder().append(declaredMethods[index].getName()).append(JavaAdapter.getMethodSignature(declaredMethods[index], declaredMethods[index].getParameterTypes())).toString();
        if (!obj2.contains((object) str))
        {
          int modifiers = declaredMethods[index].getModifiers();
          if (!Modifier.isStatic(modifiers))
          {
            if (Modifier.isFinal(modifiers))
              obj2.add((object) str);
            else if (Modifier.isPublic(modifiers) || Modifier.isProtected(modifiers))
            {
              obj1.add((object) declaredMethods[index]);
              obj2.add((object) str);
            }
          }
        }
      }
    }

    [LineNumberTable(new byte[] {161, 193, 104, 110, 101, 104, 243, 60, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object doCall(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] Function obj3,
      [In] object[] obj4,
      [In] long obj5)
    {
      for (int index = 0; index != obj4.Length; ++index)
      {
        if (0L != (obj5 & (long) (1 << index)))
        {
          object obj = obj4[index];
          if (!(obj is Scriptable))
            obj4[index] = obj0.getWrapFactory().wrap(obj0, obj1, obj, (Class) null);
        }
      }
      return obj3.call(obj0, obj1, obj2, obj4);
    }

    [Signature("(Ljava/lang/StringBuilder;Ljava/lang/Class<*>;)Ljava/lang/StringBuilder;")]
    [LineNumberTable(new byte[] {163, 217, 104, 105, 138, 136, 109, 101, 109, 133, 103, 141, 104, 98, 105, 118, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static StringBuilder appendTypeString([In] StringBuilder obj0, [In] Class obj1)
    {
      for (; obj1.isArray(); obj1 = obj1.getComponentType())
        obj0.append('[');
      if (obj1.isPrimitive())
      {
        int num = !object.ReferenceEquals((object) obj1, (object) Boolean.TYPE) ? (!object.ReferenceEquals((object) obj1, (object) Long.TYPE) ? (int) Character.toUpperCase(String.instancehelper_charAt(obj1.getName(), 0)) : 74) : 90;
        obj0.append((char) num);
      }
      else
      {
        obj0.append('L');
        obj0.append(String.instancehelper_replace(obj1.getName(), '.', '/'));
        obj0.append(';');
      }
      return obj0;
    }

    [Signature("(Lrhino/classfile/ClassFileWriter;ILjava/lang/Class<*>;)I")]
    [LineNumberTable(new byte[] {163, 92, 104, 103, 130, 103, 255, 86, 71, 103, 162, 103, 162, 103, 130, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int generatePushParam([In] ClassFileWriter obj0, [In] int obj1, [In] Class obj2)
    {
      if (!obj2.isPrimitive())
      {
        obj0.addALoad(obj1);
        return 1;
      }
      switch (String.instancehelper_charAt(obj2.getName(), 0))
      {
        case 'b':
        case 'c':
        case 'i':
        case 's':
        case 'z':
          obj0.addILoad(obj1);
          return 1;
        case 'd':
          obj0.addDLoad(obj1);
          return 2;
        case 'f':
          obj0.addFLoad(obj1);
          return 1;
        case 'l':
          obj0.addLLoad(obj1);
          return 2;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [Signature("(Lrhino/classfile/ClassFileWriter;ILjava/lang/Class<*>;)I")]
    [LineNumberTable(new byte[] {162, 138, 98, 104, 142, 141, 112, 104, 105, 191, 0, 141, 105, 255, 0, 69, 112, 104, 103, 255, 58, 69, 105, 107, 162, 105, 107, 98, 162, 105, 107, 130, 105, 162, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int generateWrapArg([In] ClassFileWriter obj0, [In] int obj1, [In] Class obj2)
    {
      int num = 1;
      if (!obj2.isPrimitive())
        obj0.add(25, obj1);
      else if (object.ReferenceEquals((object) obj2, (object) Boolean.TYPE))
      {
        obj0.add(187, "java/lang/Boolean");
        obj0.add(89);
        obj0.add(21, obj1);
        obj0.addInvoke(183, "java/lang/Boolean", "<init>", "(Z)V");
      }
      else if (object.ReferenceEquals((object) obj2, (object) Character.TYPE))
      {
        obj0.add(21, obj1);
        obj0.addInvoke(184, "java/lang/String", "valueOf", "(C)Ljava/lang/String;");
      }
      else
      {
        obj0.add(187, "java/lang/Double");
        obj0.add(89);
        switch (String.instancehelper_charAt(obj2.getName(), 0))
        {
          case 'b':
          case 'i':
          case 's':
            obj0.add(21, obj1);
            obj0.add(135);
            break;
          case 'd':
            obj0.add(24, obj1);
            num = 2;
            break;
          case 'f':
            obj0.add(23, obj1);
            obj0.add(141);
            break;
          case 'l':
            obj0.add(22, obj1);
            obj0.add(138);
            num = 2;
            break;
        }
        obj0.addInvoke(183, "java/lang/Double", "<init>", "(D)V");
      }
      return num;
    }

    [Signature("([Ljava/lang/Class<*>;Ljava/lang/Class<*>;Ljava/lang/StringBuilder;)I")]
    [LineNumberTable(new byte[] {163, 202, 105, 101, 112, 105, 156, 228, 60, 230, 71, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int appendMethodSignature([In] Class[] obj0, [In] Class obj1, [In] StringBuilder obj2)
    {
      obj2.append('(');
      int num = 1 + obj0.Length;
      Class[] classArray = obj0;
      int length = classArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Class @class = classArray[index];
        JavaAdapter.appendTypeString(obj2, @class);
        if (object.ReferenceEquals((object) @class, (object) Long.TYPE) || object.ReferenceEquals((object) @class, (object) Double.TYPE))
          ++num;
      }
      obj2.append(')');
      JavaAdapter.appendTypeString(obj2, obj1);
      return num;
    }

    [Signature("(Lrhino/classfile/ClassFileWriter;[Ljava/lang/Class<*>;I)V")]
    [LineNumberTable(new byte[] {162, 120, 103, 112, 98, 103, 104, 103, 109, 232, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void generatePushWrappedArgs([In] ClassFileWriter obj0, [In] Class[] obj1, [In] int obj2)
    {
      obj0.addPush(obj2);
      obj0.add(189, "java/lang/Object");
      int num = 1;
      for (int k = 0; k != obj1.Length; ++k)
      {
        obj0.add(89);
        obj0.addPush(k);
        num += JavaAdapter.generateWrapArg(obj0, num, obj1[k]);
        obj0.add(83);
      }
    }

    [Signature("(Lrhino/classfile/ClassFileWriter;Ljava/lang/Class<*>;Z)V")]
    [LineNumberTable(new byte[] {158, 192, 130, 109, 104, 144, 109, 186, 144, 205, 218, 103, 154, 144, 107, 186, 103, 223, 58, 107, 107, 130, 107, 107, 130, 107, 107, 130, 107, 130, 112, 186, 98, 103, 99, 103, 250, 69, 250, 72, 108, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void generateReturnResult([In] ClassFileWriter obj0, [In] Class obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      if (object.ReferenceEquals((object) obj1, (object) Void.TYPE))
      {
        obj0.add(87);
        obj0.add(177);
      }
      else if (object.ReferenceEquals((object) obj1, (object) Boolean.TYPE))
      {
        obj0.addInvoke(184, "rhino/Context", "toBoolean", "(Ljava/lang/Object;)Z");
        obj0.add(172);
      }
      else if (object.ReferenceEquals((object) obj1, (object) Character.TYPE))
      {
        obj0.addInvoke(184, "rhino/Context", "toString", "(Ljava/lang/Object;)Ljava/lang/String;");
        obj0.add(3);
        obj0.addInvoke(182, "java/lang/String", "charAt", "(I)C");
        obj0.add(172);
      }
      else if (obj1.isPrimitive())
      {
        obj0.addInvoke(184, "rhino/Context", "toNumber", "(Ljava/lang/Object;)D");
        switch (String.instancehelper_charAt(obj1.getName(), 0))
        {
          case 'b':
          case 'i':
          case 's':
            obj0.add(142);
            obj0.add(172);
            break;
          case 'd':
            obj0.add(175);
            break;
          case 'f':
            obj0.add(144);
            obj0.add(174);
            break;
          case 'l':
            obj0.add(143);
            obj0.add(173);
            break;
          default:
            string str = new StringBuilder().append("Unexpected return type ").append(obj1.toString()).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException(str);
        }
      }
      else
      {
        string name = obj1.getName();
        if (num != 0)
        {
          obj0.addLoadConstant(name);
          obj0.addInvoke(184, "java/lang/Class", "forName", "(Ljava/lang/String;)Ljava/lang/Class;");
          obj0.addInvoke(184, "rhino/JavaAdapter", "convertResult", "(Ljava/lang/Object;Ljava/lang/Class;)Ljava/lang/Object;");
        }
        obj0.add(192, name);
        obj0.add(176);
      }
    }

    [Signature("(Lrhino/classfile/ClassFileWriter;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {163, 128, 107, 103, 255, 86, 70, 107, 130, 107, 130, 107, 130, 171, 98, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generatePopResult([In] ClassFileWriter obj0, [In] Class obj1)
    {
      if (obj1.isPrimitive())
      {
        switch (String.instancehelper_charAt(obj1.getName(), 0))
        {
          case 'b':
          case 'c':
          case 'i':
          case 's':
          case 'z':
            obj0.add(172);
            break;
          case 'd':
            obj0.add(175);
            break;
          case 'f':
            obj0.add(174);
            break;
          case 'l':
            obj0.add(173);
            break;
        }
      }
      else
        obj0.add(176);
    }

    [Modifiers]
    [LineNumberTable(556)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024callMethod\u00240(
      [In] Scriptable obj0,
      [In] Scriptable obj1,
      [In] Function obj2,
      [In] object[] obj3,
      [In] long obj4,
      [In] Context obj5)
    {
      return JavaAdapter.doCall(obj5, obj0, obj1, obj2, obj3, obj4);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 207, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ScriptableObject lambda\u0024runScript\u00241(
      [In] Script obj0,
      [In] Context obj1)
    {
      ScriptableObject global = ScriptRuntime.getGlobal(obj1);
      obj0.exec(obj1, (Scriptable) global);
      return global;
    }

    [LineNumberTable(new byte[] {159, 127, 66, 102, 153, 103, 99, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      JavaAdapter javaAdapter = new JavaAdapter();
      IdFunctionObject.__\u003Cclinit\u003E();
      IdFunctionObject idFunctionObject = new IdFunctionObject((IdFunctionCall) javaAdapter, JavaAdapter.FTAG, 1, nameof (JavaAdapter), 1, scope);
      idFunctionObject.markAsConstructor((Scriptable) null);
      if (num != 0)
        idFunctionObject.sealObject();
      idFunctionObject.exportAsScopeProperty();
    }

    [LineNumberTable(new byte[] {23, 109, 105, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (f.hasTag(JavaAdapter.FTAG) && f.methodId() == 1)
        return JavaAdapter.js_createAdapter(cx, scope, args);
      throw Throwable.__\u003Cunmap\u003E((Exception) f.unknown());
    }

    [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {32, 223, 8, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object convertResult(object result, Class c) => object.ReferenceEquals(result, Undefined.__\u003C\u003Einstance) && !object.ReferenceEquals((object) c, (object) ScriptRuntime.__\u003C\u003EObjectClass) && !object.ReferenceEquals((object) c, (object) ScriptRuntime.__\u003C\u003EStringClass) ? (object) null : Context.jsToJava(result, c);

    [LineNumberTable(new byte[] {42, 103, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable createAdapterWrapper(Scriptable obj, object adapter)
    {
      NativeJavaObject nativeJavaObject = new NativeJavaObject(ScriptableObject.getTopLevelScope(obj), adapter, (Class) null, true);
      nativeJavaObject.setPrototype(obj);
      return (Scriptable) nativeJavaObject;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 105, 103, 145, 103, 136, 103, 43, 166, 167, 125, 120, 97, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeAdapterObject(object javaObject, ObjectOutputStream @out)
    {
      Class @class = Object.instancehelper_getClass(javaObject);
      @out.writeObject((object) @class.getSuperclass().getName());
      Class[] interfaces = @class.getInterfaces();
      string[] strArray = new string[interfaces.Length];
      for (int index = 0; index < interfaces.Length; ++index)
        strArray[index] = interfaces[index].getName();
      @out.writeObject((object) strArray);
      try
      {
        try
        {
          object obj = @class.getField("delegee", JavaAdapter.__\u003CGetCallerID\u003E()).get(javaObject, JavaAdapter.__\u003CGetCallerID\u003E());
          @out.writeObject(obj);
          return;
        }
        catch (IllegalAccessException ex)
        {
        }
      }
      catch (NoSuchFieldException ex)
      {
        goto label_8;
      }
      goto label_9;
label_8:
      null = null;
label_9:
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException();
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {160, 130, 102, 99, 137, 162, 150, 113, 137, 105, 51, 168, 141, 173, 255, 1, 69, 149, 127, 28, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readAdapterObject(Scriptable self, ObjectInputStream @in)
    {
      Context currentContext = Context.getCurrentContext();
      ContextFactory contextFactory = currentContext == null ? (ContextFactory) null : currentContext.getFactory();
      Class @class = Class.forName((string) @in.readObject(), JavaAdapter.__\u003CGetCallerID\u003E());
      string[] strArray = (string[]) @in.readObject();
      Class[] classArray1 = new Class[strArray.Length];
      for (int index = 0; index < strArray.Length; ++index)
        classArray1[index] = Class.forName(strArray[index], JavaAdapter.__\u003CGetCallerID\u003E());
      Scriptable scriptable = (Scriptable) @in.readObject();
      Class adapterClass = JavaAdapter.getAdapterClass(self, @class, classArray1, scriptable);
      Class[] classArray2 = new Class[3]
      {
        ScriptRuntime.__\u003C\u003EContextFactoryClass,
        ScriptRuntime.__\u003C\u003EScriptableClass,
        ScriptRuntime.__\u003C\u003EScriptableClass
      };
      object[] objArray = new object[3]
      {
        (object) contextFactory,
        (object) scriptable,
        (object) self
      };
      object obj;
      try
      {
        try
        {
          try
          {
            try
            {
              obj = adapterClass.getConstructor(classArray2, JavaAdapter.__\u003CGetCallerID\u003E()).newInstance(objArray, JavaAdapter.__\u003CGetCallerID\u003E());
            }
            catch (InstantiationException ex)
            {
              goto label_10;
            }
          }
          catch (NoSuchMethodException ex)
          {
            goto label_11;
          }
        }
        catch (InvocationTargetException ex)
        {
          goto label_12;
        }
      }
      catch (IllegalAccessException ex)
      {
        goto label_13;
      }
      return obj;
label_10:
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_14;
label_11:
      local = null;
      goto label_14;
label_12:
      local = null;
      goto label_14;
label_13:
      local = null;
label_14:
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ClassNotFoundException("adapter");
    }

    [LineNumberTable(new byte[] {161, 146, 104, 237, 70, 130, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Function getFunction(Scriptable obj, string functionName)
    {
      object property = ScriptableObject.getProperty(obj, functionName);
      if (object.ReferenceEquals(property, Scriptable.NOT_FOUND))
        return (Function) null;
      return property is Function ? (Function) property : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(property, (object) functionName));
    }

    [LineNumberTable(new byte[] {161, 169, 131, 130, 99, 167, 103, 105, 171, 102, 99, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object callMethod(
      ContextFactory factory,
      Scriptable thisObj,
      Function f,
      object[] args,
      long argsToWrap)
    {
      if (f == null)
        return (object) null;
      if (factory == null)
        factory = ContextFactory.getGlobal();
      Scriptable parentScope = f.getParentScope();
      if (argsToWrap == 0L)
        return Context.call(factory, (Callable) f, parentScope, thisObj, args);
      Context currentContext = Context.getCurrentContext();
      return currentContext != null ? JavaAdapter.doCall(currentContext, parentScope, thisObj, f, args, argsToWrap) : factory.call((ContextAction) new JavaAdapter.__\u003C\u003EAnon1(parentScope, thisObj, f, args, argsToWrap));
    }

    [LineNumberTable(576)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable runScript(Script script) => (Scriptable) ContextFactory.getGlobal().call((ContextAction) new JavaAdapter.__\u003C\u003EAnon2(script));

    [Signature("([Ljava/lang/Class<*>;)[I")]
    [LineNumberTable(new byte[] {163, 241, 98, 103, 106, 4, 198, 99, 98, 103, 98, 103, 106, 8, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int[] getArgsToConvert([In] Class[] obj0)
    {
      int length = 0;
      for (int index = 0; index != obj0.Length; ++index)
      {
        if (!obj0[index].isPrimitive())
          ++length;
      }
      if (length == 0)
        return (int[]) null;
      int[] numArray1 = new int[length];
      int num1 = 0;
      for (int index1 = 0; index1 != obj0.Length; ++index1)
      {
        if (!obj0[index1].isPrimitive())
        {
          int[] numArray2 = numArray1;
          int index2 = num1;
          ++num1;
          int num2 = index1;
          numArray2[index2] = num2;
        }
      }
      return numArray1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static JavaAdapter()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.JavaAdapter"))
        return;
      JavaAdapter.FTAG = (object) nameof (JavaAdapter);
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (JavaAdapter.__\u003CcallerID\u003E == null)
        JavaAdapter.__\u003CcallerID\u003E = (CallerID) new JavaAdapter.__\u003CCallerID\u003E();
      return JavaAdapter.__\u003CcallerID\u003E;
    }

    internal class JavaAdapterSignature : Object
    {
      [Signature("Ljava/lang/Class<*>;")]
      internal Class superClass;
      [Signature("[Ljava/lang/Class<*>;")]
      internal Class[] interfaces;
      internal ObjToIntMap names;

      [Signature("(Ljava/lang/Class<*>;[Ljava/lang/Class<*>;Lrhino/ObjToIntMap;)V")]
      [LineNumberTable(new byte[] {159, 163, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal JavaAdapterSignature([In] Class obj0, [In] Class[] obj1, [In] ObjToIntMap obj2)
      {
        JavaAdapter.JavaAdapterSignature adapterSignature = this;
        this.superClass = obj0;
        this.interfaces = obj1;
        this.names = obj2;
      }

      [LineNumberTable(new byte[] {159, 171, 104, 98, 103, 115, 98, 115, 112, 98, 108, 119, 2, 198, 120, 98, 108, 110, 108, 104, 116, 226, 60, 232, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool equals([In] object obj0)
      {
        if (!(obj0 is JavaAdapter.JavaAdapterSignature))
          return false;
        JavaAdapter.JavaAdapterSignature adapterSignature = (JavaAdapter.JavaAdapterSignature) obj0;
        if (!object.ReferenceEquals((object) this.superClass, (object) adapterSignature.superClass))
          return false;
        if (!object.ReferenceEquals((object) this.interfaces, (object) adapterSignature.interfaces))
        {
          if (this.interfaces.Length != adapterSignature.interfaces.Length)
            return false;
          for (int index = 0; index < this.interfaces.Length; ++index)
          {
            if (!object.ReferenceEquals((object) this.interfaces[index], (object) adapterSignature.interfaces[index]))
              return false;
          }
        }
        if (this.names.size() != adapterSignature.names.size())
          return false;
        ObjToIntMap.Iterator iterator = new ObjToIntMap.Iterator(this.names);
        iterator.start();
        while (!iterator.done())
        {
          string key = (string) iterator.getKey();
          int num = iterator.getValue();
          if (num != adapterSignature.names.get((object) key, num + 1))
            return false;
          iterator.next();
        }
        return true;
      }

      [LineNumberTable(55)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int hashCode() => Object.instancehelper_hashCode((object) this.superClass) + Arrays.hashCode((object[]) this.interfaces) ^ this.names.size();
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : ContextAction
    {
      private readonly Scriptable arg\u00241;
      private readonly Scriptable arg\u00242;
      private readonly Function arg\u00243;
      private readonly object[] arg\u00244;
      private readonly long arg\u00245;

      internal __\u003C\u003EAnon1(
        [In] Scriptable obj0,
        [In] Scriptable obj1,
        [In] Function obj2,
        [In] object[] obj3,
        [In] long obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public object run([In] Context obj0) => JavaAdapter.lambda\u0024callMethod\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : ContextAction
    {
      private readonly Script arg\u00241;

      internal __\u003C\u003EAnon2([In] Script obj0) => this.arg\u00241 = obj0;

      public object run([In] Context obj0) => (object) JavaAdapter.lambda\u0024runScript\u00241(this.arg\u00241, obj0);
    }
  }
}
