// Decompiled with JetBrains decompiler
// Type: mindustry.type.Publishable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  public interface Publishable
  {
    [Modifiers]
    bool prePublish();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EprePublish([In] Publishable obj0) => true;

    string steamTitle();

    [Modifiers]
    bool hasSteamID();

    [LineNumberTable(34)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EhasSteamID([In] Publishable obj0) => obj0.getSteamID() != null && Vars.steam;

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    string getSteamID();

    void addSteamID(string str);

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    string steamDescription();

    [Modifiers]
    [Signature("()Larc/struct/Seq<Ljava/lang/String;>;")]
    Seq extraTags();

    [LineNumberTable(30)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Seq \u003Cdefault\u003EextraTags([In] Publishable obj0) => new Seq(0);

    string steamTag();

    Fi createSteamPreview(string str);

    Fi createSteamFolder(string str);

    void removeSteamID();

    [HideFromJava]
    static class __DefaultMethods
    {
      public static Seq extraTags([In] Publishable obj0)
      {
        Publishable publishable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(publishable, ToString);
        return Publishable.\u003Cdefault\u003EextraTags(publishable);
      }

      public static bool hasSteamID([In] Publishable obj0)
      {
        Publishable publishable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(publishable, ToString);
        return Publishable.\u003Cdefault\u003EhasSteamID(publishable);
      }

      public static bool prePublish([In] Publishable obj0)
      {
        Publishable publishable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(publishable, ToString);
        return Publishable.\u003Cdefault\u003EprePublish(publishable);
      }
    }
  }
}
