// Decompiled with JetBrains decompiler
// Type: mindustry.entities.units.WeaponMount
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.audio;
using mindustry.gen;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.units
{
  public class WeaponMount : Object
  {
    internal Weapon __\u003C\u003Eweapon;
    public float reload;
    public float rotation;
    public float targetRotation;
    public float heat;
    public float aimX;
    public float aimY;
    public bool shoot;
    public bool rotate;
    public bool side;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Bullet bullet;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public SoundLoop sound;

    [LineNumberTable(new byte[] {159, 174, 232, 54, 135, 231, 73, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WeaponMount(Weapon weapon)
    {
      WeaponMount weaponMount = this;
      this.shoot = false;
      this.rotate = false;
      this.__\u003C\u003Eweapon = weapon;
    }

    [Modifiers]
    public Weapon weapon
    {
      [HideFromJava] get => this.__\u003C\u003Eweapon;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eweapon = value;
    }
  }
}
