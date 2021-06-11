// Decompiled with JetBrains decompiler
// Type: mindustry.maps.generators.WorldGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.generators
{
  public interface WorldGenerator
  {
    [Modifiers]
    void postGenerate(Tiles tiles);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EpostGenerate([In] WorldGenerator obj0, [In] Tiles obj1)
    {
    }

    void generate(Tiles t);

    [HideFromJava]
    static class __DefaultMethods
    {
      public static void postGenerate([In] WorldGenerator obj0, [In] Tiles obj1)
      {
        WorldGenerator worldGenerator = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(worldGenerator, ToString);
        WorldGenerator.\u003Cdefault\u003EpostGenerate(worldGenerator, obj1);
      }
    }
  }
}
