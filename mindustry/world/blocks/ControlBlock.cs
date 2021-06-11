// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.ControlBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks
{
  public interface ControlBlock
  {
    [Modifiers]
    bool isControlled();

    [LineNumberTable(11)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisControlled([In] ControlBlock obj0) => obj0.unit().isPlayer();

    [Modifiers]
    bool canControl();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EcanControl([In] ControlBlock obj0) => true;

    Unit unit();

    [Modifiers]
    bool shouldAutoTarget();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EshouldAutoTarget([In] ControlBlock obj0) => true;

    [HideFromJava]
    static class __DefaultMethods
    {
      public static bool isControlled([In] ControlBlock obj0)
      {
        ControlBlock controlBlock = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(controlBlock, ToString);
        return ControlBlock.\u003Cdefault\u003EisControlled(controlBlock);
      }

      public static bool canControl([In] ControlBlock obj0)
      {
        ControlBlock controlBlock = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(controlBlock, ToString);
        return ControlBlock.\u003Cdefault\u003EcanControl(controlBlock);
      }

      public static bool shouldAutoTarget([In] ControlBlock obj0)
      {
        ControlBlock controlBlock = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(controlBlock, ToString);
        return ControlBlock.\u003Cdefault\u003EshouldAutoTarget(controlBlock);
      }
    }
  }
}
