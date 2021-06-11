// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.WeaponListValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using mindustry.type;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.meta.values
{
  public class WeaponListValue : Object, StatValue
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/type/Weapon;>;")]
    private Seq weapons;
    [Modifiers]
    private UnitType unit;

    [Signature("(Lmindustry/type/UnitType;Larc/struct/Seq<Lmindustry/type/Weapon;>;)V")]
    [LineNumberTable(new byte[] {159, 158, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WeaponListValue(UnitType unit, Seq weapons)
    {
      WeaponListValue weaponListValue = this;
      this.weapons = weapons;
      this.unit = unit;
    }

    [LineNumberTable(new byte[] {2, 103, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void sep([In] Table obj0, [In] string obj1)
    {
      obj0.row();
      Table table = obj0;
      object obj = (object) obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 179, 155, 109, 159, 62, 159, 89, 127, 4, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00240([In] Weapon obj0, [In] Table obj1)
    {
      obj1.left().defaults().padRight(3f).left();
      if ((double) obj0.inaccuracy > 0.0)
        this.sep(obj1, new StringBuilder().append("[lightgray]").append(Stat.__\u003C\u003Einaccuracy.localized()).append(": [white]").append(ByteCodeHelper.f2i(obj0.inaccuracy)).append(" ").append(StatUnit.__\u003C\u003Edegrees.localized()).toString());
      this.sep(obj1, new StringBuilder().append("[lightgray]").append(Stat.__\u003C\u003Ereload.localized()).append(": ").append(!obj0.mirror ? "" : "2x ").append("[white]").append(Strings.autoFixed(60f / obj0.reload * (float) obj0.shots, 2)).toString());
      new AmmoListValue((ObjectMap) OrderedMap.of(new object[2]
      {
        (object) this.unit,
        (object) obj0.bullet
      })).display(obj1);
    }

    [LineNumberTable(new byte[] {159, 165, 103, 115, 146, 136, 165, 159, 25, 159, 7, 252, 74, 107, 231, 41, 233, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      table.row();
      for (int index = 0; index < this.weapons.size; ++index)
      {
        Weapon weapon = (Weapon) this.weapons.get(index);
        if (!weapon.flipSprite)
        {
          TextureRegion region = String.instancehelper_equals(weapon.name, (object) "") || !weapon.outlineRegion.found() ? this.unit.icon(Cicon.__\u003C\u003Efull) : weapon.outlineRegion;
          table.image(region).size(60f).scaling(Scaling.__\u003C\u003Ebounded).right().top();
          table.table((Drawable) Tex.underline, (Cons) new WeaponListValue.__\u003C\u003EAnon0(this, weapon)).padTop(-9f).left();
          table.row();
        }
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly WeaponListValue arg\u00241;
      private readonly Weapon arg\u00242;

      internal __\u003C\u003EAnon0([In] WeaponListValue obj0, [In] Weapon obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00240(this.arg\u00242, (Table) obj0);
    }
  }
}
