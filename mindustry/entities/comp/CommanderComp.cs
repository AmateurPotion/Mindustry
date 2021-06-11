// Decompiled with JetBrains decompiler
// Type: mindustry.entities.comp.CommanderComp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.ai.formations;
using mindustry.ai.types;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.comp
{
  [Implements(new string[] {"mindustry.gen.Entityc", "mindustry.gen.Posc"})]
  internal abstract class CommanderComp : Object, Entityc, Posc, Position
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/ai/formations/FormationMember;>;")]
    private static Seq members;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
    private static Seq units;
    internal float x;
    internal float y;
    internal float rotation;
    internal float hitSize;
    internal Team team;
    internal UnitType type;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [NonSerialized]
    internal Formation formation;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
    [NonSerialized]
    internal Seq controlling;
    [NonSerialized]
    internal float minFormationSpeed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {66, 127, 1, 120, 145, 130, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void clearCommand()
    {
      Iterator iterator = this.controlling.iterator();
      while (iterator.hasNext())
      {
        Unit unit = (Unit) iterator.next();
        if (unit.controller().isBeingControlled((Unit) this.self()))
          unit.controller(unit.type.createController());
      }
      this.controlling.clear();
      this.formation = (Formation) null;
    }

    [Signature("(Lmindustry/ai/formations/FormationPattern;Larc/func/Boolf<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {12, 127, 4, 140, 139, 255, 9, 70, 173, 127, 16, 149, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void commandNearby([In] FormationPattern obj0, [In] Boolf obj1)
    {
      Vec3.__\u003Cclinit\u003E();
      Formation formation = new Formation(new Vec3(this.x, this.y, this.rotation), obj0);
      formation.slotAssignmentStrategy = (SlotAssignmentStrategy) new DistanceAssignmentStrategy(obj0);
      CommanderComp.units.clear();
      Units.nearby(this.team, this.x, this.y, 150f, (Cons) new CommanderComp.__\u003C\u003EAnon2(this, obj1));
      if (CommanderComp.units.isEmpty())
        return;
      CommanderComp.units.sort(Structs.comps(Structs.comparingFloat((Floatf) new CommanderComp.__\u003C\u003EAnon3()), Structs.comparingFloat((Floatf) new CommanderComp.__\u003C\u003EAnon4(this))));
      CommanderComp.units.truncate(this.type.commandLimit);
      this.command(formation, CommanderComp.units);
    }

    [Signature("(Lmindustry/ai/formations/Formation;Larc/struct/Seq<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {33, 102, 134, 110, 145, 109, 155, 126, 111, 125, 98, 167, 140, 107, 124, 118, 162, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void command([In] Formation obj0, [In] Seq obj1)
    {
      this.clearCommand();
      obj1.shuffle();
      float num = this.hitSize * 0.8f;
      this.minFormationSpeed = this.type.speed;
      this.controlling.addAll(obj1);
      Iterator iterator1 = obj1.iterator();
      while (iterator1.hasNext())
      {
        Unit unit1 = (Unit) iterator1.next();
        Unit unit2 = unit1;
        FormationAI.__\u003Cclinit\u003E();
        FormationAI formationAi1;
        FormationAI formationAi2 = formationAi1 = new FormationAI((Unit) this.self(), obj0);
        unit2.controller((UnitController) formationAi1);
        num = Math.max(num, formationAi2.formationSize());
        this.minFormationSpeed = Math.min(this.minFormationSpeed, unit1.type.speed);
      }
      this.formation = obj0;
      obj0.pattern.spacing = num;
      CommanderComp.members.clear();
      Iterator iterator2 = obj1.iterator();
      while (iterator2.hasNext())
      {
        Unitc unitc = (Unitc) iterator2.next();
        CommanderComp.members.add((object) (FormationAI) unitc.controller());
      }
      obj0.addMembers((Iterable) CommanderComp.members);
    }

    [HideFromJava]
    public abstract Entityc self();

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024update\u00240([In] Unit obj0)
    {
      if (!obj0.dead)
      {
        UnitController unitController = obj0.controller();
        FormationAI formationAi;
        if (unitController is FormationAI && object.ReferenceEquals((object) (formationAi = (FormationAI) unitController), (object) (FormationAI) unitController) && object.ReferenceEquals((object) formationAi.leader, (object) this.self()))
          return false;
      }
      return true;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024commandNearby\u00241([In] Unit obj0) => true;

    [Modifiers]
    [LineNumberTable(new byte[] {18, 127, 45, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024commandNearby\u00242([In] Boolf obj0, [In] Unit obj1)
    {
      if (!obj1.isAI() || !obj0.get((object) obj1) || (object.ReferenceEquals((object) obj1, (object) this.self()) || obj1.type.flying != this.type.flying) || (double) obj1.hitSize > (double) (this.hitSize * 1.1f))
        return;
      CommanderComp.units.add((object) obj1);
    }

    [Modifiers]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024commandNearby\u00243([In] Unit obj0) => -obj0.hitSize;

    [Modifiers]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024commandNearby\u00244([In] Unit obj0) => obj0.dst2((Position) this);

    [LineNumberTable(new byte[] {159, 161, 232, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal CommanderComp()
    {
      CommanderComp commanderComp = this;
      this.controlling = new Seq(10);
    }

    [LineNumberTable(new byte[] {159, 175, 121, 167, 104, 127, 3, 107, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (this.controlling.isEmpty() && !Vars.net.client())
        this.formation = (Formation) null;
      if (this.formation == null)
        return;
      this.formation.anchor.set(this.x, this.y, 0.0f);
      this.formation.updateSlots();
      this.controlling.removeAll((Boolf) new CommanderComp.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 187, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove() => this.clearCommand();

    [LineNumberTable(new byte[] {159, 191, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void killed() => this.clearCommand();

    [LineNumberTable(new byte[] {4, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void controller([In] UnitController obj0) => this.clearCommand();

    [LineNumberTable(new byte[] {8, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void commandNearby([In] FormationPattern obj0) => this.commandNearby(obj0, (Boolf) new CommanderComp.__\u003C\u003EAnon1());

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isCommanding() => this.formation != null;

    [LineNumberTable(new byte[] {159, 137, 77, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static CommanderComp()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.comp.CommanderComp"))
        return;
      CommanderComp.members = new Seq();
      CommanderComp.units = new Seq();
    }

    [HideFromJava]
    public abstract bool isAdded();

    [HideFromJava]
    public abstract void add();

    [HideFromJava]
    public abstract bool isLocal();

    [HideFromJava]
    public abstract bool isRemote();

    [HideFromJava]
    public abstract bool isNull();

    [HideFromJava]
    public abstract object @as();

    [HideFromJava]
    public abstract object with([In] Cons obj0);

    [HideFromJava]
    public abstract int classId();

    [HideFromJava]
    public abstract bool serialize();

    [HideFromJava]
    public abstract void read([In] Reads obj0);

    [HideFromJava]
    public abstract void write([In] Writes obj0);

    [HideFromJava]
    public abstract void afterRead();

    [HideFromJava]
    public abstract int id();

    [HideFromJava]
    public abstract void id([In] int obj0);

    [HideFromJava]
    public abstract float getX();

    [HideFromJava]
    public abstract float getY();

    [HideFromJava]
    public virtual float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

    [HideFromJava]
    public virtual float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

    [HideFromJava]
    public virtual float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

    [HideFromJava]
    public virtual bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

    [HideFromJava]
    public abstract void set([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void set([In] Position obj0);

    [HideFromJava]
    public abstract void trns([In] float obj0, [In] float obj1);

    [HideFromJava]
    public abstract void trns([In] Position obj0);

    [HideFromJava]
    public abstract int tileX();

    [HideFromJava]
    public abstract int tileY();

    [HideFromJava]
    public abstract Floor floorOn();

    [HideFromJava]
    public abstract Block blockOn();

    [HideFromJava]
    public abstract bool onSolid();

    [HideFromJava]
    public abstract Tile tileOn();

    [HideFromJava]
    public abstract float x();

    [HideFromJava]
    public abstract void x([In] float obj0);

    [HideFromJava]
    public abstract float y();

    [HideFromJava]
    public abstract void y([In] float obj0);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly CommanderComp arg\u00241;

      internal __\u003C\u003EAnon0([In] CommanderComp obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024update\u00240((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (CommanderComp.lambda\u0024commandNearby\u00241((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly CommanderComp arg\u00241;
      private readonly Boolf arg\u00242;

      internal __\u003C\u003EAnon2([In] CommanderComp obj0, [In] Boolf obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024commandNearby\u00242(this.arg\u00242, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public float get([In] object obj0) => CommanderComp.lambda\u0024commandNearby\u00243((Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Floatf
    {
      private readonly CommanderComp arg\u00241;

      internal __\u003C\u003EAnon4([In] CommanderComp obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024commandNearby\u00244((Unit) obj0);
    }
  }
}
