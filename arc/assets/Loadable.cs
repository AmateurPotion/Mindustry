// Decompiled with JetBrains decompiler
// Type: arc.assets.Loadable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.assets
{
  public interface Loadable
  {
    [Modifiers]
    void loadAsync();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EloadAsync([In] Loadable obj0)
    {
    }

    [Modifiers]
    void loadSync();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EloadSync([In] Loadable obj0)
    {
    }

    [Modifiers]
    string getName();

    [LineNumberTable(15)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static string \u003Cdefault\u003EgetName([In] Loadable obj0) => Object.instancehelper_getClass((object) obj0).getSimpleName();

    [Modifiers]
    [Signature("()Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    Seq getDependencies();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Seq \u003Cdefault\u003EgetDependencies([In] Loadable obj0) => (Seq) null;

    [HideFromJava]
    static class __DefaultMethods
    {
      public static void loadAsync([In] Loadable obj0)
      {
        Loadable loadable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(loadable, ToString);
        Loadable.\u003Cdefault\u003EloadAsync(loadable);
      }

      public static void loadSync([In] Loadable obj0)
      {
        Loadable loadable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(loadable, ToString);
        Loadable.\u003Cdefault\u003EloadSync(loadable);
      }

      public static string getName([In] Loadable obj0)
      {
        Loadable loadable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(loadable, ToString);
        return Loadable.\u003Cdefault\u003EgetName(loadable);
      }

      public static Seq getDependencies([In] Loadable obj0)
      {
        Loadable loadable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(loadable, ToString);
        return Loadable.\u003Cdefault\u003EgetDependencies(loadable);
      }
    }
  }
}
