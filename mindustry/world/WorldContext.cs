// Decompiled with JetBrains decompiler
// Type: mindustry.world.WorldContext
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world
{
  public interface WorldContext
  {
    Tile tile(int i);

    void resize(int i1, int i2);

    Tile create(int i1, int i2, int i3, int i4, int i5);

    bool isGenerating();

    void begin();

    void end();

    [Modifiers]
    void onReadBuilding();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EonReadBuilding([In] WorldContext obj0)
    {
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static void onReadBuilding([In] WorldContext obj0)
      {
        WorldContext worldContext = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(worldContext, ToString);
        WorldContext.\u003Cdefault\u003EonReadBuilding(worldContext);
      }
    }
  }
}
