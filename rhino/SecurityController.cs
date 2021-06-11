// Decompiled with JetBrains decompiler
// Type: rhino.SecurityController
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino
{
  public abstract class SecurityController : Object
  {
    private static SecurityController global;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasGlobal() => SecurityController.global != null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static SecurityController global() => SecurityController.global;

    public abstract object getDynamicSecurityDomain(object obj);

    public abstract object callWithDomain(
      object obj,
      Context c1,
      Callable c2,
      Scriptable s1,
      Scriptable s2,
      object[] objarr);

    [Signature("()Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {56, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Class getStaticSecurityDomainClass() => Context.getContext().getSecurityController()?.getStaticSecurityDomainClassInternal();

    [LineNumberTable(new byte[] {40, 102, 99, 136, 135, 99, 138, 104, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static GeneratedClassLoader createLoader(
      ClassLoader parent,
      object staticDomain)
    {
      Context context = Context.getContext();
      if (parent == null)
        parent = context.getApplicationClassLoader();
      SecurityController securityController = context.getSecurityController();
      GeneratedClassLoader classLoader;
      if (securityController == null)
      {
        classLoader = context.createClassLoader(parent);
      }
      else
      {
        object dynamicSecurityDomain = securityController.getDynamicSecurityDomain(staticDomain);
        classLoader = securityController.createClassLoader(parent, dynamicSecurityDomain);
      }
      return classLoader;
    }

    public abstract GeneratedClassLoader createClassLoader(
      ClassLoader cl,
      object obj);

    [Signature("()Ljava/lang/Class<*>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class getStaticSecurityDomainClassInternal() => (Class) null;

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SecurityController()
    {
    }

    [LineNumberTable(new byte[] {6, 110, 103, 144, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void initGlobal(SecurityController controller)
    {
      if (controller == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (SecurityController.global != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SecurityException("Cannot overwrite already installed global SecurityController");
      }
      SecurityController.global = controller;
    }
  }
}
