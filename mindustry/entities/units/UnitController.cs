// Decompiled with JetBrains decompiler
// Type: mindustry.entities.units.UnitController
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.units
{
  public interface UnitController
  {
    void unit(Unit u);

    Unit unit();

    [Modifiers]
    bool isValidController();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisValidController([In] UnitController obj0) => true;

    [Modifiers]
    void command(UnitCommand command);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Ecommand([In] UnitController obj0, [In] UnitCommand obj1)
    {
    }

    [Modifiers]
    void updateUnit();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EupdateUnit([In] UnitController obj0)
    {
    }

    [Modifiers]
    void removed(Unit unit);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eremoved([In] UnitController obj0, [In] Unit obj1)
    {
    }

    [Modifiers]
    bool isBeingControlled(Unit player);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisBeingControlled([In] UnitController obj0, [In] Unit obj1) => false;

    [HideFromJava]
    static class __DefaultMethods
    {
      public static bool isValidController([In] UnitController obj0)
      {
        UnitController unitController = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(unitController, ToString);
        return UnitController.\u003Cdefault\u003EisValidController(unitController);
      }

      public static void command([In] UnitController obj0, [In] UnitCommand obj1)
      {
        UnitController unitController = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(unitController, ToString);
        UnitController.\u003Cdefault\u003Ecommand(unitController, obj1);
      }

      public static void updateUnit([In] UnitController obj0)
      {
        UnitController unitController = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(unitController, ToString);
        UnitController.\u003Cdefault\u003EupdateUnit(unitController);
      }

      public static void removed([In] UnitController obj0, [In] Unit obj1)
      {
        UnitController unitController = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(unitController, ToString);
        UnitController.\u003Cdefault\u003Eremoved(unitController, obj1);
      }

      public static bool isBeingControlled([In] UnitController obj0, [In] Unit obj1)
      {
        UnitController unitController = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(unitController, ToString);
        return UnitController.\u003Cdefault\u003EisBeingControlled(unitController, obj1);
      }
    }
  }
}
