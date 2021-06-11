// Decompiled with JetBrains decompiler
// Type: rhino.NativeJavaPackage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class NativeJavaPackage : ScriptableObject
  {
    [Modifiers]
    private string packageName;
    [NonSerialized]
    private ClassLoader classLoader;
    [Signature("Ljava/util/Set<Ljava/lang/String;>;")]
    private Set negativeCache;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 118, 98, 105, 109, 98, 150, 162, 159, 20, 102, 104, 99, 142, 104, 144, 136, 100, 104, 114, 178, 105, 131, 111, 109, 100, 130, 104, 107, 173, 164, 138})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    internal virtual object getPkgProperty([In] string obj0, [In] Scriptable obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      object objA = base.get(obj0, obj1);
      if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        return objA;
      if (this.negativeCache != null && this.negativeCache.contains((object) obj0))
        return (object) null;
      string str = String.instancehelper_length(this.packageName) != 0 ? new StringBuilder().append(this.packageName).append('.').append(obj0).toString() : obj0;
      Context context = Context.getContext();
      ClassShutter classShutter = context.getClassShutter();
      object obj = (object) null;
      if (classShutter == null || classShutter.visibleToScripts(str))
      {
        Class javaClass = this.classLoader == null ? Kit.classOrNull(str) : Kit.classOrNull(this.classLoader, str);
        if (javaClass != null)
        {
          obj = (object) context.getWrapFactory().wrapJavaClass(context, ScriptableObject.getTopLevelScope((Scriptable) this), javaClass);
          ((Scriptable) obj).setPrototype(this.getPrototype());
        }
      }
      if ((Scriptable) obj == null)
      {
        if (num != 0)
        {
          NativeJavaPackage nativeJavaPackage = new NativeJavaPackage(true, str, this.classLoader);
          ScriptRuntime.setObjectProtoAndParent((ScriptableObject) nativeJavaPackage, this.getParentScope());
          obj = (object) nativeJavaPackage;
        }
        else
        {
          if (this.negativeCache == null)
            this.negativeCache = (Set) new HashSet();
          this.negativeCache.add((object) obj0);
        }
      }
      if (obj != null)
        base.put(obj0, obj1, obj);
      return obj;
    }

    [LineNumberTable(new byte[] {111, 104, 103, 191, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (!(obj is NativeJavaPackage))
        return false;
      NativeJavaPackage nativeJavaPackage = (NativeJavaPackage) obj;
      return String.instancehelper_equals(this.packageName, (object) nativeJavaPackage.packageName) && object.ReferenceEquals((object) this.classLoader, (object) nativeJavaPackage.classLoader);
    }

    [LineNumberTable(new byte[] {159, 162, 232, 160, 157, 231, 159, 100, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeJavaPackage([In] bool obj0, [In] string obj1, [In] ClassLoader obj2)
    {
      NativeJavaPackage nativeJavaPackage = this;
      this.negativeCache = (Set) null;
      this.packageName = obj1;
      this.classLoader = obj2;
    }

    [LineNumberTable(156)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[JavaPackage ").append(this.packageName).append("]").toString();

    [Obsolete]
    [LineNumberTable(new byte[] {159, 173, 105})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaPackage(string packageName, ClassLoader classLoader)
      : this(false, packageName, classLoader)
    {
    }

    [Obsolete]
    [LineNumberTable(new byte[] {159, 182, 99, 42, 133})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaPackage(string packageName)
      : this(false, packageName, Context.getCurrentContext().getApplicationClassLoader())
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "JavaPackage";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(string id, Scriptable start) => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(int index, Scriptable start) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(string id, Scriptable start, object value)
    {
    }

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(int index, Scriptable start, object value) => throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.pkg.int"));

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(string id, Scriptable start) => this.getPkgProperty(id, start, true);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(int index, Scriptable start) => Scriptable.NOT_FOUND;

    [LineNumberTable(new byte[] {32, 105, 107, 135, 191, 23, 110, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual NativeJavaPackage forcePackage([In] string obj0, [In] Scriptable obj1)
    {
      object obj = base.get(obj0, (Scriptable) this);
      if (obj != null && obj is NativeJavaPackage)
        return (NativeJavaPackage) obj;
      NativeJavaPackage nativeJavaPackage = new NativeJavaPackage(true, String.instancehelper_length(this.packageName) != 0 ? new StringBuilder().append(this.packageName).append(".").append(obj0).toString() : obj0, this.classLoader);
      ScriptRuntime.setObjectProtoAndParent((ScriptableObject) nativeJavaPackage, obj1);
      base.put(obj0, (Scriptable) this, (object) nativeJavaPackage);
      return nativeJavaPackage;
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object getDefaultValue(Class ignored) => (object) this.toString();

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {100, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      this.classLoader = Context.getCurrentContext().getApplicationClassLoader();
    }

    [LineNumberTable(new byte[] {121, 124, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => String.instancehelper_hashCode(this.packageName) ^ (this.classLoader != null ? Object.instancehelper_hashCode((object) this.classLoader) : 0);

    [HideFromJava]
    static NativeJavaPackage() => ScriptableObject.__\u003Cclinit\u003E();
  }
}
