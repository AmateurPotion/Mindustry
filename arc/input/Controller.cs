// Decompiled with JetBrains decompiler
// Type: arc.input.Controller
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.input
{
  public abstract class Controller : InputDevice
  {
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Controller()
    {
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 accelerometer() => Vec3.__\u003C\u003EZero;

    public abstract int index();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void postUpdate()
    {
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override InputDevice.DeviceType type() => InputDevice.DeviceType.__\u003C\u003Econtroller;
  }
}
