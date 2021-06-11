// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.Door
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.audio;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.defense
{
  public class Door : Wall
  {
    internal static Rect __\u003C\u003Erect;
    [Signature("Larc/struct/Queue<Lmindustry/world/blocks/defense/Door$DoorBuild;>;")]
    internal static Queue __\u003C\u003EdoorQueue;
    internal int __\u003C\u003EtimerToggle;
    public Effect openfx;
    public Effect closefx;
    public Sound doorSound;
    public TextureRegion openRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 180, 141, 159, 1, 127, 4, 162, 108, 112, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] Door.DoorBuild obj0, [In] Boolean obj1)
    {
      this.doorSound.at((Position) obj0);
      Iterator iterator = obj0.chained.iterator();
      while (iterator.hasNext())
      {
        Door.DoorBuild doorBuild = (Door.DoorBuild) iterator.next();
        if ((!Units.anyEntities(doorBuild.tile) || obj1.booleanValue()) && doorBuild.open != obj1.booleanValue())
        {
          doorBuild.open = obj1.booleanValue();
          Vars.pathfinder.updateTile(doorBuild.tile());
          doorBuild.effect();
        }
      }
    }

    [LineNumberTable(new byte[] {159, 174, 233, 57, 121, 107, 107, 235, 69, 103, 103, 135, 246, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Door(string name)
      : base(name)
    {
      Door door1 = this;
      Door door2 = this;
      int timers = door2.timers;
      Door door3 = door2;
      int num = timers;
      door3.timers = timers + 1;
      this.__\u003C\u003EtimerToggle = num;
      this.openfx = Fx.__\u003C\u003Edooropen;
      this.closefx = Fx.__\u003C\u003Edoorclose;
      this.doorSound = Sounds.door;
      this.solid = false;
      this.solidifes = true;
      this.consumesTap = true;
      this.config((Class) ClassLiteral<Boolean>.Value, (Cons2) new Door.__\u003C\u003EAnon0(this));
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)Larc/graphics/g2d/TextureRegion;")]
    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion getRequestRegion(BuildPlan req, Eachable list) => object.ReferenceEquals(req.config, (object) Boolean.TRUE) ? this.openRegion : this.region;

    [LineNumberTable(new byte[] {159, 137, 146, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Door()
    {
      Wall.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.defense.Door"))
        return;
      Door.__\u003C\u003Erect = new Rect();
      Door.__\u003C\u003EdoorQueue = new Queue();
    }

    [Modifiers]
    protected internal static Rect rect
    {
      [HideFromJava] get => Door.__\u003C\u003Erect;
    }

    [Modifiers]
    protected internal static Queue doorQueue
    {
      [HideFromJava] get => Door.__\u003C\u003EdoorQueue;
    }

    [Modifiers]
    public int timerToggle
    {
      [HideFromJava] get => this.__\u003C\u003EtimerToggle;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerToggle = value;
    }

    public class DoorBuild : Building
    {
      public bool open;
      [Signature("Larc/struct/Seq<Lmindustry/world/blocks/defense/Door$DoorBuild;>;")]
      public Seq chained;
      [Modifiers]
      internal Door this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {53, 127, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void effect() => (!this.open ? this.this\u00240.openfx : this.this\u00240.closefx).at((Position) this);

      [LineNumberTable(new byte[] {57, 107, 106, 139, 111, 112, 140, 127, 4, 127, 21, 109, 140, 101, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void updateChained()
      {
        this.chained = new Seq();
        Door.__\u003C\u003EdoorQueue.clear();
        Door.__\u003C\u003EdoorQueue.add((object) this);
label_1:
        while (!Door.__\u003C\u003EdoorQueue.isEmpty())
        {
          Door.DoorBuild doorBuild1 = (Door.DoorBuild) Door.__\u003C\u003EdoorQueue.removeLast();
          this.chained.add((object) doorBuild1);
          Iterator iterator = doorBuild1.proximity.iterator();
          while (true)
          {
            Building building;
            Door.DoorBuild doorBuild2;
            do
            {
              if (iterator.hasNext())
                building = (Building) iterator.next();
              else
                goto label_1;
            }
            while (!(building is Door.DoorBuild) || !object.ReferenceEquals((object) (doorBuild2 = (Door.DoorBuild) building), (object) (Door.DoorBuild) building) || object.ReferenceEquals((object) doorBuild2.chained, (object) this.chained));
            doorBuild2.chained = this.chained;
            Door.__\u003C\u003EdoorQueue.addFirst((object) doorBuild2);
          }
        }
      }

      [LineNumberTable(99)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Door.DoorBuild origin() => this.chained.isEmpty() ? this : (Door.DoorBuild) this.chained.first();

      [LineNumberTable(150)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Boolean config() => Boolean.valueOf(this.open);

      [LineNumberTable(new byte[] {8, 111, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DoorBuild(Door _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Door.DoorBuild doorBuild = this;
        this.open = false;
        this.chained = new Seq();
      }

      [LineNumberTable(new byte[] {14, 102, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityAdded()
      {
        base.onProximityAdded();
        this.updateChained();
      }

      [LineNumberTable(new byte[] {20, 134, 127, 1, 127, 0, 134, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityRemoved()
      {
        base.onProximityRemoved();
        Iterator iterator = this.proximity.iterator();
        while (iterator.hasNext())
        {
          Building building = (Building) iterator.next();
          Door.DoorBuild doorBuild;
          if (building is Door.DoorBuild && object.ReferenceEquals((object) (doorBuild = (Door.DoorBuild) building), (object) (Door.DoorBuild) building))
            doorBuild.updateChained();
        }
      }

      [LineNumberTable(new byte[] {31, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override double sense(LAccess sensor)
      {
        if (!object.ReferenceEquals((object) sensor, (object) LAccess.__\u003C\u003Eenabled))
          return base.sense(sensor);
        return this.open ? 1.0 : 0.0;
      }

      [LineNumberTable(new byte[] {37, 112, 142, 127, 35, 161, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void control(LAccess type, double p1, double p2, double p3, double p4)
      {
        if (!object.ReferenceEquals((object) type, (object) LAccess.__\u003C\u003Eenabled))
          return;
        int num = Mathf.zero(p1) ? 0 : 1;
        if (Vars.net.client() || (this.open ? 1 : 0) == num || Units.anyEntities(this.tile) && num == 0 || !this.origin().timer(this.this\u00240.__\u003C\u003EtimerToggle, 80f))
          return;
        this.configureAny((object) Boolean.valueOf(num != 0));
      }

      [LineNumberTable(new byte[] {76, 127, 18})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw() => Draw.rect(!this.open ? this.this\u00240.region : this.this\u00240.openRegion, this.x, this.y);

      [LineNumberTable(131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Graphics.Cursor getCursor() => this.interactable(Vars.player.team()) ? (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Ehand : (Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool checkSolid() => !this.open;

      [LineNumberTable(new byte[] {91, 127, 19, 161, 119})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void tapped()
      {
        if (Units.anyEntities(this.tile) && this.open || !this.origin().timer(this.this\u00240.__\u003C\u003EtimerToggle, 60f))
          return;
        this.configure((object) Boolean.valueOf(!this.open));
      }

      [LineNumberTable(new byte[] {105, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.@bool(this.open);
      }

      [LineNumberTable(new byte[] {159, 102, 99, 104, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.open = read.@bool();
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(58)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static DoorBuild() => Building.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      private readonly Door arg\u00241;

      internal __\u003C\u003EAnon0([In] Door obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024new\u00240((Door.DoorBuild) obj0, (Boolean) obj1);
    }
  }
}
