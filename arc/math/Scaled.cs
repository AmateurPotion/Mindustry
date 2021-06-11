// Decompiled with JetBrains decompiler
// Type: arc.math.Scaled
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math
{
  public interface Scaled
  {
    [Modifiers]
    float fout();

    [LineNumberTable(9)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Efout([In] Scaled obj0) => 1f - obj0.fin();

    [Modifiers]
    float fslope();

    [LineNumberTable(39)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Efslope([In] Scaled obj0) => (0.5f - Math.abs(obj0.fin() - 0.5f)) * 2f;

    [Modifiers]
    float finpow();

    [LineNumberTable(34)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Efinpow([In] Scaled obj0) => Interp.pow3Out.apply(obj0.fin());

    [Modifiers]
    float fout(float margin);

    [LineNumberTable(new byte[] {159, 161, 104, 108, 152})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Efout([In] Scaled obj0, [In] float obj1)
    {
      float num = obj0.fin();
      return (double) num >= (double) (1f - obj1) ? 1f - (num - (1f - obj1)) / obj1 : 1f;
    }

    [Modifiers]
    float fin(Interp i);

    [LineNumberTable(29)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Efin([In] Scaled obj0, [In] Interp obj1) => obj1.apply(obj0.fin());

    [Modifiers]
    float fout(Interp i);

    [LineNumberTable(14)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Efout([In] Scaled obj0, [In] Interp obj1) => obj1.apply(obj0.fout());

    float fin();

    [HideFromJava]
    static class __DefaultMethods
    {
      public static float fout([In] Scaled obj0)
      {
        Scaled scaled = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(scaled, ToString);
        return Scaled.\u003Cdefault\u003Efout(scaled);
      }

      public static float fout([In] Scaled obj0, [In] Interp obj1)
      {
        Scaled scaled = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(scaled, ToString);
        return Scaled.\u003Cdefault\u003Efout(scaled, obj1);
      }

      public static float fout([In] Scaled obj0, [In] float obj1)
      {
        Scaled scaled = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(scaled, ToString);
        return Scaled.\u003Cdefault\u003Efout(scaled, obj1);
      }

      public static float fin([In] Scaled obj0, [In] Interp obj1)
      {
        Scaled scaled = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(scaled, ToString);
        return Scaled.\u003Cdefault\u003Efin(scaled, obj1);
      }

      public static float finpow([In] Scaled obj0)
      {
        Scaled scaled = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(scaled, ToString);
        return Scaled.\u003Cdefault\u003Efinpow(scaled);
      }

      public static float fslope([In] Scaled obj0)
      {
        Scaled scaled = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(scaled, ToString);
        return Scaled.\u003Cdefault\u003Efslope(scaled);
      }
    }
  }
}
