// Decompiled with JetBrains decompiler
// Type: mindustry.type.StatusEffect
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.ui;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  public class StatusEffect : UnlockableContent
  {
    public float damageMultiplier;
    public float healthMultiplier;
    public float speedMultiplier;
    public float reloadMultiplier;
    public float buildSpeedMultiplier;
    public float dragMultiplier;
    public float transitionDamage;
    public bool disarm;
    public float damage;
    public float effectChance;
    public bool permanent;
    public bool reactive;
    public Color color;
    public Effect effect;
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/StatusEffect;Lmindustry/type/StatusEffect$TransitionHandler;>;")]
    protected internal ObjectMap transitions;
    protected internal Runnable initblock;
    [Signature("Larc/struct/ObjectSet<Lmindustry/type/StatusEffect;>;")]
    public ObjectSet affinities;
    [Signature("Larc/struct/ObjectSet<Lmindustry/type/StatusEffect;>;")]
    public ObjectSet opposites;

    [LineNumberTable(new byte[] {82, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void trans(
      StatusEffect effect,
      StatusEffect.TransitionHandler handler)
    {
      this.transitions.put((object) effect, (object) handler);
      effect.transitions.put((object) this, (object) handler);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240()
    {
    }

    [Modifiers]
    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setStats\u00241([In] StatusEffect obj0) => obj0.affinities.contains((object) this);

    [Modifiers]
    [LineNumberTable(new byte[] {97, 112, 105, 107, 129, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024opposite\u00242(
      [In] StatusEffect obj0,
      [In] Unit obj1,
      [In] float obj2,
      [In] float obj3,
      [In] StatusEntry obj4)
    {
      obj2 -= obj3 * 0.5f;
      if ((double) obj2 > 0.0)
        obj4.set(this, obj2);
      else
        obj4.set(obj0, obj3);
    }

    [LineNumberTable(new byte[] {4, 233, 28, 139, 139, 139, 139, 139, 139, 139, 199, 235, 70, 144, 139, 139, 144, 107, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StatusEffect(string name)
      : base(name)
    {
      StatusEffect statusEffect = this;
      this.damageMultiplier = 1f;
      this.healthMultiplier = 1f;
      this.speedMultiplier = 1f;
      this.reloadMultiplier = 1f;
      this.buildSpeedMultiplier = 1f;
      this.dragMultiplier = 1f;
      this.transitionDamage = 0.0f;
      this.disarm = false;
      this.effectChance = 0.15f;
      this.color = Color.__\u003C\u003Ewhite.cpy();
      this.effect = Fx.__\u003C\u003Enone;
      this.transitions = new ObjectMap();
      this.initblock = (Runnable) new StatusEffect.__\u003C\u003EAnon0();
      this.affinities = new ObjectSet();
      this.opposites = new ObjectSet();
    }

    [LineNumberTable(new byte[] {9, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init() => this.initblock.run();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init(Runnable run) => this.initblock = run;

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isHidden() => String.instancehelper_equals(this.localizedName, (object) this.__\u003C\u003Ename);

    [LineNumberTable(new byte[] {23, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 159, 16, 130, 127, 11, 127, 28, 130, 107, 127, 1, 115, 127, 69, 226, 69, 102, 127, 11, 127, 28, 130, 123, 223, 52})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      if ((double) this.damageMultiplier != 1.0)
        this.stats.addPercent(Stat.__\u003C\u003EdamageMultiplier, this.damageMultiplier);
      if ((double) this.healthMultiplier != 1.0)
        this.stats.addPercent(Stat.__\u003C\u003EhealthMultiplier, this.healthMultiplier);
      if ((double) this.speedMultiplier != 1.0)
        this.stats.addPercent(Stat.__\u003C\u003EspeedMultiplier, this.speedMultiplier);
      if ((double) this.reloadMultiplier != 1.0)
        this.stats.addPercent(Stat.__\u003C\u003EreloadMultiplier, this.reloadMultiplier);
      if ((double) this.buildSpeedMultiplier != 1.0)
        this.stats.addPercent(Stat.__\u003C\u003EbuildSpeedMultiplier, this.buildSpeedMultiplier);
      if ((double) this.damage > 0.0)
        this.stats.add(Stat.__\u003C\u003Edamage, this.damage * 60f, StatUnit.__\u003C\u003EperSecond);
      int num = 0;
      Iterator iterator1 = this.opposites.asArray().sort().iterator();
      while (iterator1.hasNext())
      {
        StatusEffect statusEffect = (StatusEffect) iterator1.next();
        this.stats.add(Stat.__\u003C\u003Eopposites, new StringBuilder().append(statusEffect.emoji()).append("").append((object) statusEffect).toString());
      }
      if (this.reactive)
      {
        StatusEffect statusEffect = (StatusEffect) Vars.content.statusEffects().find((Boolf) new StatusEffect.__\u003C\u003EAnon1(this));
        if (statusEffect != null && (double) statusEffect.transitionDamage > 0.0)
        {
          this.stats.add(Stat.__\u003C\u003Ereactive, new StringBuilder().append(statusEffect.emoji()).append((object) statusEffect).append(" / [accent]").append(ByteCodeHelper.f2i(statusEffect.transitionDamage)).append("[lightgray] ").append(Stat.__\u003C\u003Edamage.localized()).toString());
          num = 1;
        }
      }
      if (num != 0)
        return;
      Iterator iterator2 = this.affinities.asArray().sort().iterator();
      while (iterator2.hasNext())
      {
        StatusEffect statusEffect = (StatusEffect) iterator2.next();
        this.stats.add(Stat.__\u003C\u003Eaffinities, new StringBuilder().append(statusEffect.emoji()).append("").append((object) statusEffect).toString());
      }
      if (this.affinities.size <= 0 || (double) this.transitionDamage == 0.0)
        return;
      this.stats.add(Stat.__\u003C\u003Eaffinities, new StringBuilder().append("/ [accent]").append(ByteCodeHelper.f2i(this.transitionDamage)).append(" ").append(Stat.__\u003C\u003Edamage.localized()).toString());
    }

    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Cicon prefDatabaseIcon() => Cicon.__\u003C\u003Elarge;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool showUnlock() => false;

    [LineNumberTable(new byte[] {69, 109, 110, 109, 186, 127, 1, 125, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(Unit unit, float time)
    {
      if ((double) this.damage > 0.0)
        unit.damageContinuousPierce(this.damage);
      else if ((double) this.damage < 0.0)
        unit.heal(-1f * this.damage * Time.delta);
      if (object.ReferenceEquals((object) this.effect, (object) Fx.__\u003C\u003Enone) || !Mathf.chanceDelta((double) this.effectChance))
        return;
      Tmp.__\u003C\u003Ev1.rnd(unit.type.hitSize / 2f);
      this.effect.at(unit.x + Tmp.__\u003C\u003Ev1.x, unit.y + Tmp.__\u003C\u003Ev1.y);
    }

    [LineNumberTable(new byte[] {87, 109, 109, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void affinity(
      StatusEffect effect,
      StatusEffect.TransitionHandler handler)
    {
      this.affinities.add((object) effect);
      effect.affinities.add((object) this);
      this.trans(effect, handler);
    }

    [LineNumberTable(new byte[] {93, 108, 111, 109, 19, 230, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void opposite(params StatusEffect[] effect)
    {
      this.opposites.addAll((object[]) effect);
      StatusEffect[] statusEffectArray = effect;
      int length = statusEffectArray.Length;
      for (int index = 0; index < length; ++index)
      {
        StatusEffect effect1 = statusEffectArray[index];
        effect1.opposites.add((object) this);
        this.trans(effect1, (StatusEffect.TransitionHandler) new StatusEffect.__\u003C\u003EAnon2(this, effect1));
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Unit unit)
    {
    }

    [LineNumberTable(162)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool reactsWith(StatusEffect effect) => this.transitions.containsKey((object) effect);

    [LineNumberTable(new byte[] {122, 110, 126, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual StatusEntry getTransition(
      Unit unit,
      StatusEffect to,
      float time,
      float newTime,
      StatusEntry result)
    {
      if (!this.transitions.containsKey((object) to))
        return result.set(to, newTime);
      ((StatusEffect.TransitionHandler) this.transitions.get((object) to)).handle(unit, time, newTime, result);
      return result;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => this.localizedName;

    [LineNumberTable(187)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Estatus;

    public interface TransitionHandler
    {
      void handle(Unit u, float f1, float f2, StatusEntry se);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void run() => StatusEffect.lambda\u0024new\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly StatusEffect arg\u00241;

      internal __\u003C\u003EAnon1([In] StatusEffect obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024setStats\u00241((StatusEffect) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : StatusEffect.TransitionHandler
    {
      private readonly StatusEffect arg\u00241;
      private readonly StatusEffect arg\u00242;

      internal __\u003C\u003EAnon2([In] StatusEffect obj0, [In] StatusEffect obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void handle([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3) => this.arg\u00241.lambda\u0024opposite\u00242(this.arg\u00242, obj0, obj1, obj2, obj3);
    }
  }
}
