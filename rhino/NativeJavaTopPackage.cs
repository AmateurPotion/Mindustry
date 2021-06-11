// Decompiled with JetBrains decompiler
// Type: rhino.NativeJavaTopPackage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Function", "rhino.IdFunctionCall"})]
  public class NativeJavaTopPackage : 
    NativeJavaPackage,
    Function,
    Scriptable,
    Callable,
    IdFunctionCall
  {
    [Modifiers]
    private static string[][] commonPackages;
    [Modifiers]
    private static object FTAG;
    private const int Id_getClass = 1;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 184, 98, 100, 100, 104, 140, 104, 167, 99, 107, 130, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable construct(Context cx, Scriptable scope, object[] args)
    {
      ClassLoader classLoader = (ClassLoader) null;
      if (args.Length != 0)
      {
        object obj = args[0];
        if (obj is Wrapper)
          obj = ((Wrapper) obj).unwrap();
        if (obj is ClassLoader)
          classLoader = (ClassLoader) obj;
      }
      if (classLoader == null)
      {
        Context.reportRuntimeError0("msg.not.classloader");
        return (Scriptable) null;
      }
      NativeJavaPackage nativeJavaPackage = new NativeJavaPackage(true, "", classLoader);
      ScriptRuntime.setObjectProtoAndParent((ScriptableObject) nativeJavaPackage, scope);
      return (Scriptable) nativeJavaPackage;
    }

    [LineNumberTable(new byte[] {159, 173, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeJavaTopPackage([In] ClassLoader obj0)
      : base(true, "", obj0)
    {
    }

    [LineNumberTable(new byte[] {64, 117, 98, 179, 103, 130, 107, 103, 107, 103, 127, 26, 105, 98, 104, 101, 103, 101, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scriptable js_getClass([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      if (obj2.Length > 0 && obj2[0] is Wrapper)
      {
        object obj3 = (object) this;
        string name = Object.instancehelper_getClass(((Wrapper) obj2[0]).unwrap()).getName();
        int num1 = 0;
        while (true)
        {
          int num2 = String.instancehelper_indexOf(name, 46, num1);
          string str1 = num2 != -1 ? String.instancehelper_substring(name, num1, num2) : String.instancehelper_substring(name, num1);
          object obj4 = obj3;
          string str2 = str1;
          object obj5 = obj3;
          Scriptable scriptable1;
          if (obj5 != null)
          {
            if (obj5 is Scriptable scriptable14)
              scriptable1 = scriptable14;
            else
              break;
          }
          else
            scriptable1 = (Scriptable) null;
          Scriptable scriptable4 = scriptable1;
          string str3 = str2;
          Scriptable scriptable5;
          if (obj4 != null)
          {
            if (obj4 is Scriptable scriptable15)
              scriptable5 = scriptable15;
            else
              goto label_8;
          }
          else
            scriptable5 = (Scriptable) null;
          string str4 = str3;
          Scriptable s = scriptable4;
          object obj6 = scriptable5.get(str4, s);
          if (obj6 is Scriptable)
          {
            obj3 = (object) (Scriptable) obj6;
            if (num2 != -1)
              num1 = num2 + 1;
            else
              goto label_12;
          }
          else
            goto label_14;
        }
        throw new IncompatibleClassChangeError();
label_8:
        throw new IncompatibleClassChangeError();
label_12:
        return (Scriptable) obj3;
      }
label_14:
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.not.java.obj"));
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args) => (object) this.construct(cx, scope, args);

    [LineNumberTable(new byte[] {159, 127, 130, 103, 103, 108, 135, 107, 99, 111, 52, 8, 230, 72, 250, 70, 103, 106, 106, 54, 232, 70, 136, 99, 135, 103, 110, 106, 50, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      NativeJavaTopPackage nativeJavaTopPackage = new NativeJavaTopPackage(cx.getApplicationClassLoader());
      nativeJavaTopPackage.setPrototype(ScriptableObject.getObjectPrototype(scope));
      nativeJavaTopPackage.setParentScope(scope);
      for (int index1 = 0; index1 != NativeJavaTopPackage.commonPackages.Length; ++index1)
      {
        NativeJavaPackage nativeJavaPackage = (NativeJavaPackage) nativeJavaTopPackage;
        for (int index2 = 0; index2 != NativeJavaTopPackage.commonPackages[index1].Length; ++index2)
          nativeJavaPackage = nativeJavaPackage.forcePackage(NativeJavaTopPackage.commonPackages[index1][index2], scope);
      }
      IdFunctionObject.__\u003Cclinit\u003E();
      IdFunctionObject idFunctionObject = new IdFunctionObject((IdFunctionCall) nativeJavaTopPackage, NativeJavaTopPackage.FTAG, 1, "getClass", 1, scope);
      string[] topPackageNames = ScriptRuntime.getTopPackageNames();
      NativeJavaPackage[] nativeJavaPackageArray = new NativeJavaPackage[topPackageNames.Length];
      for (int index = 0; index < topPackageNames.Length; ++index)
        nativeJavaPackageArray[index] = (NativeJavaPackage) nativeJavaTopPackage.get(topPackageNames[index], (Scriptable) nativeJavaTopPackage);
      ScriptableObject scriptableObject = (ScriptableObject) scope;
      if (num != 0)
        idFunctionObject.sealObject();
      idFunctionObject.exportAsScopeProperty();
      scriptableObject.defineProperty("Packages", (object) nativeJavaTopPackage, 2);
      for (int index = 0; index < topPackageNames.Length; ++index)
        scriptableObject.defineProperty(topPackageNames[index], (object) nativeJavaPackageArray[index], 2);
    }

    [LineNumberTable(new byte[] {55, 109, 105, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (f.hasTag(NativeJavaTopPackage.FTAG) && f.methodId() == 1)
        return (object) this.js_getClass(cx, scope, args);
      throw Throwable.__\u003Cunmap\u003E((Exception) f.unknown());
    }

    [LineNumberTable(new byte[] {159, 138, 178, 255, 160, 140, 160, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeJavaTopPackage()
    {
      NativeJavaPackage.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeJavaTopPackage"))
        return;
      NativeJavaTopPackage.commonPackages = new string[8][]
      {
        new string[3]{ "java", "lang", "reflect" },
        new string[2]{ "java", "io" },
        new string[2]{ "java", "math" },
        new string[2]{ "java", "net" },
        new string[3]{ "java", "util", "zip" },
        new string[3]{ "java", "text", "resources" },
        new string[2]{ "java", "applet" },
        new string[2]{ "javax", "swing" }
      };
      NativeJavaTopPackage.FTAG = (object) "JavaTopPackage";
    }
  }
}
