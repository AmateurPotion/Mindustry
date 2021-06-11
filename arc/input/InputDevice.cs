// Decompiled with JetBrains decompiler
// Type: arc.input.InputDevice
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.input
{
  public abstract class InputDevice : Object
  {
    public abstract string name();

    public abstract InputDevice.DeviceType type();

    public abstract bool isPressed(KeyCode kc);

    public abstract bool isTapped(KeyCode kc);

    public abstract bool isReleased(KeyCode kc);

    public abstract float getAxis(KeyCode kc);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void preUpdate()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void postUpdate()
    {
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InputDevice()
    {
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/input/InputDevice$DeviceType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class DeviceType : Enum
    {
      [Modifiers]
      internal static InputDevice.DeviceType __\u003C\u003Ekeyboard;
      [Modifiers]
      internal static InputDevice.DeviceType __\u003C\u003Econtroller;
      [Modifiers]
      private static InputDevice.DeviceType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static InputDevice.DeviceType[] values() => (InputDevice.DeviceType[]) InputDevice.DeviceType.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private DeviceType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static InputDevice.DeviceType valueOf(string name) => (InputDevice.DeviceType) Enum.valueOf((Class) ClassLiteral<InputDevice.DeviceType>.Value, name);

      [LineNumberTable(new byte[] {159, 134, 77, 63, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static DeviceType()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.input.InputDevice$DeviceType"))
          return;
        InputDevice.DeviceType.__\u003C\u003Ekeyboard = new InputDevice.DeviceType(nameof (keyboard), 0);
        InputDevice.DeviceType.__\u003C\u003Econtroller = new InputDevice.DeviceType(nameof (controller), 1);
        InputDevice.DeviceType.\u0024VALUES = new InputDevice.DeviceType[2]
        {
          InputDevice.DeviceType.__\u003C\u003Ekeyboard,
          InputDevice.DeviceType.__\u003C\u003Econtroller
        };
      }

      [Modifiers]
      public static InputDevice.DeviceType keyboard
      {
        [HideFromJava] get => InputDevice.DeviceType.__\u003C\u003Ekeyboard;
      }

      [Modifiers]
      public static InputDevice.DeviceType controller
      {
        [HideFromJava] get => InputDevice.DeviceType.__\u003C\u003Econtroller;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        keyboard,
        controller,
      }
    }
  }
}
