// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.AmmoListValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.entities.bullet;
using mindustry.gen;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.defense.turrets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.meta.values
{
  [Signature("<T:Lmindustry/ctype/UnlockableContent;>Ljava/lang/Object;Lmindustry/world/meta/StatValue;")]
  public class AmmoListValue : Object, StatValue
  {
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<TT;Lmindustry/entities/bullet/BulletType;>;")]
    private ObjectMap map;

    [Signature("(Larc/struct/ObjectMap<TT;Lmindustry/entities/bullet/BulletType;>;)V")]
    [LineNumberTable(new byte[] {159, 165, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AmmoListValue(ObjectMap map)
    {
      AmmoListValue ammoListValue = this;
      this.map = map;
    }

    [Signature("(TT;)Larc/graphics/g2d/TextureRegion;")]
    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual TextureRegion icon([In] UnlockableContent obj0) => obj0.icon(Cicon.__\u003C\u003Emedium);

    [LineNumberTable(new byte[] {58, 103, 120})]
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
    [LineNumberTable(new byte[] {159, 131, 66, 155, 127, 9, 110, 159, 70, 223, 27, 109, 191, 23, 109, 191, 38, 125, 191, 16, 114, 191, 12, 109, 191, 12, 109, 191, 16, 113, 191, 27, 105, 172, 114, 191, 48, 109, 172, 105, 191, 46, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00240([In] BulletType obj0, [In] bool obj1, [In] Table obj2)
    {
      int num = obj1 ? 1 : 0;
      obj2.left().defaults().padRight(3f).left();
      if ((double) obj0.damage > 0.0 && (obj0.collides || (double) obj0.splashDamage <= 0.0))
      {
        if ((double) obj0.continuousDamage() > 0.0)
        {
          Table table = obj2;
          object obj = (object) new StringBuilder().append(Core.bundle.format("bullet.damage", (object) Float.valueOf(obj0.continuousDamage()))).append(" ").append(StatUnit.__\u003C\u003EperSecond.localized()).toString();
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table.add(text);
        }
        else
        {
          Table table = obj2;
          object obj = (object) Core.bundle.format("bullet.damage", (object) Float.valueOf(obj0.damage));
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table.add(text);
        }
      }
      if ((double) obj0.buildingDamageMultiplier != 1.0)
        this.sep(obj2, Core.bundle.format("bullet.buildingdamage", (object) Integer.valueOf(ByteCodeHelper.f2i(obj0.buildingDamageMultiplier * 100f))));
      if ((double) obj0.splashDamage > 0.0)
        this.sep(obj2, Core.bundle.format("bullet.splashdamage", (object) Integer.valueOf(ByteCodeHelper.f2i(obj0.splashDamage)), (object) Strings.@fixed(obj0.splashDamageRadius / 8f, 1)));
      if (num == 0 && !Mathf.equal(obj0.ammoMultiplier, 1f) && !(obj0 is LiquidBulletType))
        this.sep(obj2, Core.bundle.format("bullet.multiplier", (object) Integer.valueOf(ByteCodeHelper.f2i(obj0.ammoMultiplier))));
      if (!Mathf.equal(obj0.reloadMultiplier, 1f))
        this.sep(obj2, Core.bundle.format("bullet.reload", (object) Strings.autoFixed(obj0.reloadMultiplier, 2)));
      if ((double) obj0.knockback > 0.0)
        this.sep(obj2, Core.bundle.format("bullet.knockback", (object) Strings.autoFixed(obj0.knockback, 2)));
      if ((double) obj0.healPercent > 0.0)
        this.sep(obj2, Core.bundle.format("bullet.healpercent", (object) Integer.valueOf(ByteCodeHelper.f2i(obj0.healPercent))));
      if (obj0.pierce || obj0.pierceCap != -1)
      {
        Table table = obj2;
        string str;
        if (obj0.pierceCap == -1)
          str = "@bullet.infinitepierce";
        else
          str = Core.bundle.format("bullet.pierce", (object) Integer.valueOf(obj0.pierceCap));
        this.sep(table, str);
      }
      if (obj0.incendAmount > 0)
        this.sep(obj2, "@bullet.incendiary");
      if (!object.ReferenceEquals((object) obj0.status, (object) StatusEffects.none))
        this.sep(obj2, new StringBuilder().append(obj0.minfo.mod != null ? "" : obj0.status.emoji()).append("[stat]").append(obj0.status.localizedName).toString());
      if ((double) obj0.homingPower > 0.00999999977648258)
        this.sep(obj2, "@bullet.homing");
      if (obj0.lightning > 0)
        this.sep(obj2, Core.bundle.format("bullet.lightning", (object) Integer.valueOf(obj0.lightning), (object) Float.valueOf((double) obj0.lightningDamage >= 0.0 ? obj0.lightningDamage : obj0.damage)));
      if (obj0.fragBullet == null)
        return;
      this.sep(obj2, "@bullet.frag");
    }

    [LineNumberTable(new byte[] {159, 172, 135, 127, 9, 138, 178, 118, 127, 13, 191, 20, 243, 122, 159, 21, 103, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      table.row();
      ObjectMap.Keys keys = this.map.keys().iterator();
      while (((Iterator) keys).hasNext())
      {
        UnlockableContent unlockableContent = (UnlockableContent) ((Iterator) keys).next();
        int num = unlockableContent is UnitType ? 1 : 0;
        BulletType bulletType = (BulletType) this.map.get((object) unlockableContent);
        if (((num != 0 ? 0 : 1) & (unlockableContent is PowerTurret ? 0 : 1)) != 0)
        {
          table.image(this.icon(unlockableContent)).size(24f).padRight(4f).right().top();
          Table table1 = table;
          object localizedName = (object) unlockableContent.localizedName;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) localizedName;
          CharSequence text = charSequence;
          table1.add(text).padRight(10f).left().top();
        }
        ((Table) table.table((Cons) new AmmoListValue.__\u003C\u003EAnon0(this, bulletType, num != 0)).padTop(num == 0 ? -9f : 0.0f).left().get()).background(num == 0 ? (Drawable) Tex.underline : (Drawable) null);
        table.row();
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly AmmoListValue arg\u00241;
      private readonly BulletType arg\u00242;
      private readonly bool arg\u00243;

      internal __\u003C\u003EAnon0([In] AmmoListValue obj0, [In] BulletType obj1, [In] bool obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00240(this.arg\u00242, this.arg\u00243, (Table) obj0);
    }
  }
}
