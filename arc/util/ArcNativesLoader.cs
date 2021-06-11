// Decompiled with JetBrains decompiler
// Type: arc.util.ArcNativesLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class ArcNativesLoader : Object
  {
    public static bool disableNativesLoading;
    private static bool nativesLoaded;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 140, 140, 105, 134, 137, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load()
    {
      lock ((object) ClassLiteral<ArcNativesLoader>.Value)
      {
        if (ArcNativesLoader.nativesLoaded)
          return;
        ArcNativesLoader.nativesLoaded = true;
        if (ArcNativesLoader.disableNativesLoading)
          return;
        new SharedLibraryLoader().load("arc");
      }
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcNativesLoader()
    {
    }
  }
}
