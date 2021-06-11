// Decompiled with JetBrains decompiler
// Type: mindustry.content.StatusEffects
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.math;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class StatusEffects : Object, ContentList
  {
    public static StatusEffect none;
    public static StatusEffect burning;
    public static StatusEffect freezing;
    public static StatusEffect unmoving;
    public static StatusEffect slow;
    public static StatusEffect wet;
    public static StatusEffect muddy;
    public static StatusEffect melting;
    public static StatusEffect sapped;
    public static StatusEffect tarred;
    public static StatusEffect overdrive;
    public static StatusEffect overclock;
    public static StatusEffect shielded;
    public static StatusEffect shocked;
    public static StatusEffect blasted;
    public static StatusEffect corroded;
    public static StatusEffect boss;
    public static StatusEffect sporeSlowed;
    public static StatusEffect disarmed;

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StatusEffects()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 143, 240, 80, 240, 81, 240, 69, 240, 69, 240, 83, 240, 71, 240, 81, 240, 72, 240, 71, 240, 75, 240, 74, 240, 73, 240, 69, 240, 71, 240, 69, 240, 69, 240, 69, 208})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      StatusEffects.none = new StatusEffect("none");
      StatusEffects.burning = (StatusEffect) new StatusEffects.\u0031(this, "burning");
      StatusEffects.freezing = (StatusEffect) new StatusEffects.\u0032(this, "freezing");
      StatusEffects.unmoving = (StatusEffect) new StatusEffects.\u0033(this, "unmoving");
      StatusEffects.slow = (StatusEffect) new StatusEffects.\u0034(this, "slow");
      StatusEffects.wet = (StatusEffect) new StatusEffects.\u0035(this, "wet");
      StatusEffects.muddy = (StatusEffect) new StatusEffects.\u0036(this, "muddy");
      StatusEffects.melting = (StatusEffect) new StatusEffects.\u0037(this, "melting");
      StatusEffects.sapped = (StatusEffect) new StatusEffects.\u0038(this, "sapped");
      StatusEffects.sporeSlowed = (StatusEffect) new StatusEffects.\u0039(this, "spore-slowed");
      StatusEffects.tarred = (StatusEffect) new StatusEffects.\u00310(this, "tarred");
      StatusEffects.overdrive = (StatusEffect) new StatusEffects.\u00311(this, "overdrive");
      StatusEffects.overclock = (StatusEffect) new StatusEffects.\u00312(this, "overclock");
      StatusEffects.shielded = (StatusEffect) new StatusEffects.\u00313(this, "shielded");
      StatusEffects.boss = (StatusEffect) new StatusEffects.\u00314(this, "boss");
      StatusEffects.shocked = (StatusEffect) new StatusEffects.\u00315(this, "shocked");
      StatusEffects.blasted = (StatusEffect) new StatusEffects.\u00316(this, "blasted");
      StatusEffects.corroded = (StatusEffect) new StatusEffects.\u00317(this, "corroded");
      StatusEffects.disarmed = (StatusEffect) new StatusEffects.\u00318(this, "disarmed");
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [Modifiers]
      [LineNumberTable(new byte[] {159, 171, 124, 246, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241()
      {
        this.opposite(StatusEffects.wet, StatusEffects.freezing);
        this.affinity(StatusEffects.tarred, (StatusEffect.TransitionHandler) new StatusEffects.\u0031.__\u003C\u003EAnon1(this));
      }

      [Modifiers]
      [LineNumberTable(new byte[] {159, 173, 108, 127, 35, 126})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3)
      {
        obj0.damagePierce(this.transitionDamage);
        Fx.__\u003C\u003Eburning.at(obj0.x + Mathf.range(obj0.bounds() / 2f), obj0.y + Mathf.range(obj0.bounds() / 2f));
        obj3.set(StatusEffects.burning, Math.min(obj1 + obj2, 300f));
      }

      [LineNumberTable(new byte[] {159, 164, 112, 112, 107, 107, 139, 241, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u0031 obj = this;
        this.color = Color.valueOf("ffc455");
        this.damage = 0.12f;
        this.effect = Fx.__\u003C\u003Eburning;
        this.transitionDamage = 8f;
        this.init((Runnable) new StatusEffects.\u0031.__\u003C\u003EAnon0(this));
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly StatusEffects.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] StatusEffects.\u0031 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00241();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : StatusEffect.TransitionHandler
      {
        private readonly StatusEffects.\u0031 arg\u00241;

        internal __\u003C\u003EAnon1([In] StatusEffects.\u0031 obj0) => this.arg\u00241 = obj0;

        public void handle([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3) => this.arg\u00241.lambda\u0024new\u00240(obj0, obj1, obj2, obj3);
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00310 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {73, 112, 112, 107, 139, 209})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u00310 obj = this;
        this.color = Color.valueOf("313131");
        this.speedMultiplier = 0.6f;
        this.effect = Fx.__\u003C\u003Eoily;
        this.init((Runnable) new StatusEffects.\u00310.__\u003C\u003EAnon0(this));
      }

      [Modifiers]
      [LineNumberTable(new byte[] {79, 117, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00242()
      {
        this.affinity(StatusEffects.melting, (StatusEffect.TransitionHandler) new StatusEffects.\u00310.__\u003C\u003EAnon1());
        this.affinity(StatusEffects.burning, (StatusEffect.TransitionHandler) new StatusEffects.\u00310.__\u003C\u003EAnon2());
      }

      [Modifiers]
      [LineNumberTable(129)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00240(
        [In] Unit obj0,
        [In] float obj1,
        [In] float obj2,
        [In] StatusEntry obj3)
      {
        obj3.set(StatusEffects.melting, obj2 + obj1);
      }

      [Modifiers]
      [LineNumberTable(130)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00241(
        [In] Unit obj0,
        [In] float obj1,
        [In] float obj2,
        [In] StatusEntry obj3)
      {
        obj3.set(StatusEffects.burning, obj2 + obj1);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly StatusEffects.\u00310 arg\u00241;

        internal __\u003C\u003EAnon0([In] StatusEffects.\u00310 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00242();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : StatusEffect.TransitionHandler
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void handle([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3) => StatusEffects.\u00310.lambda\u0024new\u00240(obj0, obj1, obj2, obj3);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : StatusEffect.TransitionHandler
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public void handle([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3) => StatusEffects.\u00310.lambda\u0024new\u00241(obj0, obj1, obj2, obj3);
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00311 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {84, 112, 107, 107, 107, 107, 107, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00311([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u00311 obj = this;
        this.color = Pal.accent;
        this.healthMultiplier = 0.95f;
        this.speedMultiplier = 1.15f;
        this.damageMultiplier = 1.4f;
        this.damage = -0.01f;
        this.effect = Fx.__\u003C\u003Eoverdriven;
        this.permanent = true;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00312 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {94, 112, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00312([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u00312 obj = this;
        this.color = Pal.accent;
        this.speedMultiplier = 1.15f;
        this.damageMultiplier = 1.15f;
        this.reloadMultiplier = 1.25f;
        this.effectChance = 0.07f;
        this.effect = Fx.__\u003C\u003Eoverclocked;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00313 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {103, 112, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00313([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u00313 obj = this;
        this.color = Pal.accent;
        this.healthMultiplier = 3f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00314 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {108, 112, 107, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00314([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u00314 obj = this;
        this.color = Pal.health;
        this.permanent = true;
        this.damageMultiplier = 1.3f;
        this.healthMultiplier = 1.5f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00315 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {115, 112, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00315([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u00315 obj = this;
        this.color = Pal.lancerLaser;
        this.reactive = true;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00316 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {120, 112, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00316([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u00316 obj = this;
        this.color = Color.valueOf("ff795e");
        this.reactive = true;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00317 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {125, 112, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00317([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u00317 obj = this;
        this.color = Pal.plastanium;
        this.damage = 0.1f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00318 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {160, 66, 112, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00318([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u00318 obj = this;
        this.color = Color.valueOf("e9ead3");
        this.disarm = true;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {159, 180, 112, 112, 107, 107, 107, 139, 241, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u0032 obj = this;
        this.color = Color.valueOf("6ecdec");
        this.speedMultiplier = 0.6f;
        this.healthMultiplier = 0.8f;
        this.effect = Fx.__\u003C\u003Efreezing;
        this.transitionDamage = 18f;
        this.init((Runnable) new StatusEffects.\u0032.__\u003C\u003EAnon0(this));
      }

      [Modifiers]
      [LineNumberTable(new byte[] {159, 188, 156, 214})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241()
      {
        this.opposite(StatusEffects.melting, StatusEffects.burning);
        this.affinity(StatusEffects.blasted, (StatusEffect.TransitionHandler) new StatusEffects.\u0032.__\u003C\u003EAnon1(this));
      }

      [Modifiers]
      [LineNumberTable(new byte[] {159, 191, 108, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3)
      {
        obj0.damagePierce(this.transitionDamage);
        obj3.set(StatusEffects.freezing, obj1);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly StatusEffects.\u0032 arg\u00241;

        internal __\u003C\u003EAnon0([In] StatusEffects.\u0032 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00241();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : StatusEffect.TransitionHandler
      {
        private readonly StatusEffects.\u0032 arg\u00241;

        internal __\u003C\u003EAnon1([In] StatusEffects.\u0032 obj0) => this.arg\u00241 = obj0;

        public void handle([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3) => this.arg\u00241.lambda\u0024new\u00240(obj0, obj1, obj2, obj3);
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0033 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {5, 112, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u0033 obj = this;
        this.color = Pal.gray;
        this.speedMultiplier = 1f / 1000f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0034 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {10, 112, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u0034 obj = this;
        this.color = Pal.lightishGray;
        this.speedMultiplier = 0.4f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0035 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {15, 112, 107, 107, 107, 107, 139, 241, 74})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u0035 obj = this;
        this.color = Color.__\u003C\u003Eroyal;
        this.speedMultiplier = 0.94f;
        this.effect = Fx.__\u003C\u003Ewet;
        this.effectChance = 0.09f;
        this.transitionDamage = 14f;
        this.init((Runnable) new StatusEffects.\u0035.__\u003C\u003EAnon0(this));
      }

      [Modifiers]
      [LineNumberTable(new byte[] {23, 246, 71, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241()
      {
        this.affinity(StatusEffects.shocked, (StatusEffect.TransitionHandler) new StatusEffects.\u0035.__\u003C\u003EAnon1(this));
        this.opposite(StatusEffects.burning);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {24, 108, 124, 138, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3)
      {
        obj0.damagePierce(this.transitionDamage);
        if (object.ReferenceEquals((object) obj0.team, (object) Vars.state.rules.waveTeam))
          Events.fire((object) EventType.Trigger.__\u003C\u003Eshock);
        obj3.set(StatusEffects.wet, obj1);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly StatusEffects.\u0035 arg\u00241;

        internal __\u003C\u003EAnon0([In] StatusEffects.\u0035 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00241();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : StatusEffect.TransitionHandler
      {
        private readonly StatusEffects.\u0035 arg\u00241;

        internal __\u003C\u003EAnon1([In] StatusEffects.\u0035 obj0) => this.arg\u00241 = obj0;

        public void handle([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3) => this.arg\u00241.lambda\u0024new\u00240(obj0, obj1, obj2, obj3);
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0036 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {34, 112, 112, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u0036 obj = this;
        this.color = Color.valueOf("46382a");
        this.speedMultiplier = 0.94f;
        this.effect = Fx.__\u003C\u003Emuddy;
        this.effectChance = 0.09f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0037 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {41, 112, 112, 107, 107, 107, 139, 241, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u0037 obj = this;
        this.color = Color.valueOf("ffa166");
        this.speedMultiplier = 0.8f;
        this.healthMultiplier = 0.8f;
        this.damage = 0.3f;
        this.effect = Fx.__\u003C\u003Emelting;
        this.init((Runnable) new StatusEffects.\u0037.__\u003C\u003EAnon0(this));
      }

      [Modifiers]
      [LineNumberTable(new byte[] {49, 124, 245, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241()
      {
        this.opposite(StatusEffects.wet, StatusEffects.freezing);
        this.affinity(StatusEffects.tarred, (StatusEffect.TransitionHandler) new StatusEffects.\u0037.__\u003C\u003EAnon1());
      }

      [Modifiers]
      [LineNumberTable(new byte[] {51, 107, 127, 35, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00240(
        [In] Unit obj0,
        [In] float obj1,
        [In] float obj2,
        [In] StatusEntry obj3)
      {
        obj0.damagePierce(8f);
        Fx.__\u003C\u003Eburning.at(obj0.x + Mathf.range(obj0.bounds() / 2f), obj0.y + Mathf.range(obj0.bounds() / 2f));
        obj3.set(StatusEffects.melting, Math.min(obj1 + obj2, 200f));
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly StatusEffects.\u0037 arg\u00241;

        internal __\u003C\u003EAnon0([In] StatusEffects.\u0037 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00241();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : StatusEffect.TransitionHandler
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void handle([In] Unit obj0, [In] float obj1, [In] float obj2, [In] StatusEntry obj3) => StatusEffects.\u0037.lambda\u0024new\u00240(obj0, obj1, obj2, obj3);
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0038 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {58, 112, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u0038 obj = this;
        this.color = Pal.sap;
        this.speedMultiplier = 0.7f;
        this.healthMultiplier = 0.8f;
        this.effect = Fx.__\u003C\u003Esapped;
        this.effectChance = 0.1f;
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0039 : StatusEffect
    {
      [Modifiers]
      internal StatusEffects this\u00240;

      [LineNumberTable(new byte[] {66, 112, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039([In] StatusEffects obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        StatusEffects.\u0039 obj = this;
        this.color = Pal.spore;
        this.speedMultiplier = 0.8f;
        this.effect = Fx.__\u003C\u003Esapped;
        this.effectChance = 0.04f;
      }
    }
  }
}
