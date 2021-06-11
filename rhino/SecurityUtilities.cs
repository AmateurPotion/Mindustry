// Decompiled with JetBrains decompiler
// Type: rhino.SecurityUtilities
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class SecurityUtilities : Object
  {
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [Signature("(Ljava/lang/Class<*>;)Ljava/security/ProtectionDomain;")]
    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ProtectionDomain getProtectionDomain(Class clazz) => (ProtectionDomain) AccessController.doPrivileged((PrivilegedAction) new SecurityUtilities.__\u003C\u003EAnon2(clazz), SecurityUtilities.__\u003CGetCallerID\u003E());

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getSystemProperty(string name) => (string) AccessController.doPrivileged((PrivilegedAction) new SecurityUtilities.__\u003C\u003EAnon0(name), SecurityUtilities.__\u003CGetCallerID\u003E());

    [LineNumberTable(new byte[] {159, 175, 102, 104, 251, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ProtectionDomain getScriptProtectionDomain()
    {
      SecurityManager securityManager = java.lang.System.getSecurityManager();
      return securityManager is RhinoSecurityManager ? (ProtectionDomain) AccessController.doPrivileged((PrivilegedAction) new SecurityUtilities.__\u003C\u003EAnon3(securityManager), SecurityUtilities.__\u003CGetCallerID\u003E()) : (ProtectionDomain) null;
    }

    [Modifiers]
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024getSystemProperty\u00240([In] string obj0) => java.lang.System.getProperty(obj0);

    [Modifiers]
    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ProtectionDomain lambda\u0024getProtectionDomain\u00241(
      [In] Class obj0)
    {
      return obj0.getProtectionDomain();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 179, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ProtectionDomain lambda\u0024getScriptProtectionDomain\u00242(
      [In] SecurityManager obj0)
    {
      return ((RhinoSecurityManager) obj0).getCurrentScriptClass()?.getProtectionDomain();
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SecurityUtilities()
    {
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SecurityUtilities.__\u003CcallerID\u003E == null)
        SecurityUtilities.__\u003CcallerID\u003E = (CallerID) new SecurityUtilities.__\u003CCallerID\u003E();
      return SecurityUtilities.__\u003CcallerID\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : PrivilegedAction
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon0([In] string obj0) => this.arg\u00241 = obj0;

      public object run() => (object) SecurityUtilities.lambda\u0024getSystemProperty\u00240(this.arg\u00241);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : PrivilegedAction
    {
      private readonly Class arg\u00241;

      internal __\u003C\u003EAnon2([In] Class obj0) => this.arg\u00241 = obj0;

      public object run() => (object) SecurityUtilities.lambda\u0024getProtectionDomain\u00241(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : PrivilegedAction
    {
      private readonly SecurityManager arg\u00241;

      internal __\u003C\u003EAnon3([In] SecurityManager obj0) => this.arg\u00241 = obj0;

      public object run() => (object) SecurityUtilities.lambda\u0024getScriptProtectionDomain\u00242(this.arg\u00241);
    }
  }
}
