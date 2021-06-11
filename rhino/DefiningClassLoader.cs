// Decompiled with JetBrains decompiler
// Type: rhino.DefiningClassLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino
{
  [Implements(new string[] {"rhino.GeneratedClassLoader"})]
  public class DefiningClassLoader : ClassLoader, GeneratedClassLoader
  {
    [Modifiers]
    private ClassLoader parentLoader;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DefiningClassLoader(ClassLoader parentLoader)
    {
      DefiningClassLoader definingClassLoader = this;
      this.parentLoader = parentLoader;
    }

    [LineNumberTable(new byte[] {159, 151, 104, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DefiningClassLoader()
    {
      DefiningClassLoader definingClassLoader = this;
      this.parentLoader = Object.instancehelper_getClass((object) this).getClassLoader(DefiningClassLoader.__\u003CGetCallerID\u003E());
    }

    [Signature("(Ljava/lang/String;[B)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {159, 164, 103, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class defineClass(string name, byte[] data) => this.defineClass(name, data, 0, data.Length, SecurityUtilities.getProtectionDomain(Object.instancehelper_getClass((object) this)));

    [Signature("(Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {159, 170, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void linkClass(Class cl) => this.resolveClass(cl);

    [Throws(new string[] {"java.lang.ClassNotFoundException"})]
    [Signature("(Ljava/lang/String;Z)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {159, 134, 130, 104, 99, 104, 143, 168, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class loadClass(string name, bool resolve)
    {
      int num = resolve ? 1 : 0;
      Class @class = this.findLoadedClass(name) ?? (this.parentLoader == null ? this.findSystemClass(name) : this.parentLoader.loadClass(name));
      if (num != 0)
        this.resolveClass(@class);
      return @class;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (DefiningClassLoader.__\u003CcallerID\u003E == null)
        DefiningClassLoader.__\u003CcallerID\u003E = (CallerID) new DefiningClassLoader.__\u003CCallerID\u003E();
      return DefiningClassLoader.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    static DefiningClassLoader() => ClassLoader.__\u003Cclinit\u003E();

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
