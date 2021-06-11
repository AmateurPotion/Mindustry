// Decompiled with JetBrains decompiler
// Type: com.sun.jna.VarArgsChecker
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.lang.reflect;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  internal abstract class VarArgsChecker : Object
  {
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    internal abstract bool isVarArgs([In] Method obj0);

    internal abstract int fixedArgs([In] Method obj0);

    [LineNumberTable(new byte[] {29, 123, 131, 137, 156, 97, 103, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static VarArgsChecker create()
    {
      VarArgsChecker.NoVarArgsChecker noVarArgsChecker;
      try
      {
        try
        {
          if (((Class) ClassLiteral<Method>.Value).getMethod("isVarArgs", new Class[0], VarArgsChecker.__\u003CGetCallerID\u003E()) != null)
            return (VarArgsChecker) new VarArgsChecker.RealVarArgsChecker((VarArgsChecker.\u0031) null);
          noVarArgsChecker = new VarArgsChecker.NoVarArgsChecker((VarArgsChecker.\u0031) null);
        }
        catch (NoSuchMethodException ex)
        {
          goto label_6;
        }
      }
      catch (SecurityException ex)
      {
        goto label_7;
      }
      return (VarArgsChecker) noVarArgsChecker;
label_6:
      return (VarArgsChecker) new VarArgsChecker.NoVarArgsChecker((VarArgsChecker.\u0031) null);
label_7:
      return (VarArgsChecker) new VarArgsChecker.NoVarArgsChecker((VarArgsChecker.\u0031) null);
    }

    [LineNumberTable(new byte[] {159, 180, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private VarArgsChecker()
    {
    }

    [Modifiers]
    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal VarArgsChecker([In] VarArgsChecker.\u0031 obj0)
      : this()
    {
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (VarArgsChecker.__\u003CcallerID\u003E == null)
        VarArgsChecker.__\u003CcallerID\u003E = (CallerID) new VarArgsChecker.__\u003CCallerID\u003E();
      return VarArgsChecker.__\u003CcallerID\u003E;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      \u0031() => throw null;
    }

    [InnerClass]
    internal sealed class NoVarArgsChecker : VarArgsChecker
    {
      [Modifiers]
      [LineNumberTable(60)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal NoVarArgsChecker([In] VarArgsChecker.\u0031 obj0)
        : this()
      {
      }

      [LineNumberTable(60)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private NoVarArgsChecker()
        : base((VarArgsChecker.\u0031) null)
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal override bool isVarArgs([In] Method obj0) => false;

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal override int fixedArgs([In] Method obj0) => 0;
    }

    [InnerClass]
    internal sealed class RealVarArgsChecker : VarArgsChecker
    {
      [Modifiers]
      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal RealVarArgsChecker([In] VarArgsChecker.\u0031 obj0)
        : this()
      {
      }

      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private RealVarArgsChecker()
        : base((VarArgsChecker.\u0031) null)
      {
      }

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal override bool isVarArgs([In] Method obj0) => obj0.isVarArgs();

      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal override int fixedArgs([In] Method obj0) => obj0.isVarArgs() ? obj0.getParameterTypes().Length - 1 : 0;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
