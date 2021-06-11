// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.ItemBridge
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.core;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.graphics;
using mindustry.input;
using mindustry.type;
using mindustry.world.meta;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.distribution
{
  public class ItemBridge : Block
  {
    private static BuildPlan otherReq;
    internal int __\u003C\u003EtimerTransport;
    public int range;
    public float transportTime;
    public TextureRegion endRegion;
    public TextureRegion bridgeRegion;
    public TextureRegion arrowRegion;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public ItemBridge.ItemBridgeBuild lastBuild;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {21, 109, 138, 138, 159, 13, 135, 115, 255, 16, 61, 229, 72, 127, 12, 60, 165, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBridge(BuildPlan req, float ox, float oy, float flip)
    {
      if (Mathf.zero(Renderer.bridgeOpacity))
        return;
      Draw.alpha(Renderer.bridgeOpacity);
      Lines.stroke(8f);
      Tmp.__\u003C\u003Ev1.set(ox, oy).sub(req.drawx(), req.drawy()).setLength(4f);
      Lines.line(this.bridgeRegion, req.drawx() + Tmp.__\u003C\u003Ev1.x, req.drawy() + Tmp.__\u003C\u003Ev1.y, ox - Tmp.__\u003C\u003Ev1.x, oy - Tmp.__\u003C\u003Ev1.y, false);
      Draw.rect(this.arrowRegion, (req.drawx() + ox) / 2f, (req.drawy() + oy) / 2f, Angles.angle(req.drawx(), req.drawy(), ox, oy) + flip);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {95, 109, 127, 33, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile findLink(int x, int y)
    {
      Tile tile = Vars.world.tile(x, y);
      return tile != null && this.lastBuild != null && (this.linkValid(tile, this.lastBuild.tile) && !object.ReferenceEquals((object) this.lastBuild.tile, (object) tile)) && this.lastBuild.link == -1 ? this.lastBuild.tile : (Tile) null;
    }

    [LineNumberTable(new byte[] {159, 111, 162, 159, 9, 127, 30, 127, 21, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool linkValid(Tile tile, Tile other, bool checkDouble)
    {
      int num = checkDouble ? 1 : 0;
      return other != null && tile != null && this.positionsValid((int) tile.x, (int) tile.y, (int) other.x, (int) other.y) && ((object.ReferenceEquals((object) other.block(), (object) tile.block()) && object.ReferenceEquals((object) tile.block(), (object) this) || !(tile.block() is ItemBridge) && object.ReferenceEquals((object) other.block(), (object) this)) && ((object.ReferenceEquals((object) other.team(), (object) tile.team()) || !object.ReferenceEquals((object) tile.block(), (object) this)) && (num == 0 || ((ItemBridge.ItemBridgeBuild) other.build).link != tile.pos())));
    }

    [LineNumberTable(new byte[] {85, 100, 117, 101, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool positionsValid(int x1, int y1, int x2, int y2)
    {
      if (x1 == x2)
        return Math.abs(y1 - y2) <= this.range;
      return y1 == y2 && Math.abs(x1 - x2) <= this.range;
    }

    [LineNumberTable(123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool linkValid(Tile tile, Tile other) => this.linkValid(tile, other, true);

    [Modifiers]
    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] ItemBridge.ItemBridgeBuild obj0, [In] Point2 obj1) => obj0.link = Point2.pack(obj1.x + obj0.tileX(), obj1.y + obj0.tileY());

    [Modifiers]
    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] ItemBridge.ItemBridgeBuild obj0, [In] Integer obj1) => obj0.link = obj1.intValue();

    [Modifiers]
    [LineNumberTable(new byte[] {10, 127, 62, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawRequestConfigTop\u00242([In] BuildPlan obj0, [In] BuildPlan obj1)
    {
      if (!object.ReferenceEquals((object) obj1.block, (object) this) || object.ReferenceEquals((object) obj0, (object) obj1))
        return;
      object config = obj0.config;
      Point2 point2;
      if (!(config is Point2) || !object.ReferenceEquals((object) (point2 = (Point2) config), (object) (Point2) config) || !point2.equals(obj1.x - obj0.x, obj1.y - obj0.y))
        return;
      ItemBridge.otherReq = obj1;
    }

    [Modifiers]
    [LineNumberTable(165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024changePlacementPath\u00243([In] Point2 obj0, [In] Point2 obj1) => Math.max(Math.abs(obj0.x - obj1.x), Math.abs(obj0.y - obj1.y)) <= this.range;

    [LineNumberTable(new byte[] {159, 179, 233, 53, 153, 235, 74, 103, 103, 103, 103, 104, 103, 103, 103, 107, 103, 167, 149, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ItemBridge(string name)
      : base(name)
    {
      ItemBridge itemBridge1 = this;
      ItemBridge itemBridge2 = this;
      int timers = itemBridge2.timers;
      ItemBridge itemBridge3 = itemBridge2;
      int num = timers;
      itemBridge3.timers = timers + 1;
      this.__\u003C\u003EtimerTransport = num;
      this.transportTime = 2f;
      this.update = true;
      this.solid = true;
      this.hasPower = true;
      this.expanded = true;
      this.itemCapacity = 10;
      this.configurable = true;
      this.hasItems = true;
      this.unloadable = false;
      this.group = BlockGroup.__\u003C\u003Etransportation;
      this.noUpdateDisabled = true;
      this.copyConfig = false;
      this.config((Class) ClassLiteral<Point2>.Value, (Cons2) new ItemBridge.__\u003C\u003EAnon0());
      this.config((Class) ClassLiteral<Integer>.Value, (Cons2) new ItemBridge.__\u003C\u003EAnon1());
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {8, 102, 242, 70, 103, 159, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestConfigTop(BuildPlan req, Eachable list)
    {
      ItemBridge.otherReq = (BuildPlan) null;
      list.each((Cons) new ItemBridge.__\u003C\u003EAnon2(this, req));
      if (ItemBridge.otherReq == null)
        return;
      this.drawBridge(req, ItemBridge.otherReq.drawx(), ItemBridge.otherReq.drawy(), 0.0f);
    }

    [LineNumberTable(new byte[] {159, 119, 131, 138, 137, 111, 105, 63, 116, 233, 73, 101, 106, 106, 127, 8, 106, 127, 0, 127, 1, 159, 44, 159, 38, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid)
    {
      int num = valid ? 1 : 0;
      base.drawPlace(x, y, rotation, num != 0);
      Tile link = this.findLink(x, y);
      Lines.stroke(2f, Pal.placing);
      for (int index = 0; index < 4; ++index)
        Lines.dashLine((float) (x * 8) + (float) Geometry.__\u003C\u003Ed4[index].x * 6f, (float) (y * 8) + (float) Geometry.__\u003C\u003Ed4[index].y * 6f, (float) (x * 8) + (float) Geometry.__\u003C\u003Ed4[index].x * ((float) this.range + 0.5f) * 8f, (float) (y * 8) + (float) Geometry.__\u003C\u003Ed4[index].y * ((float) this.range + 0.5f) * 8f, this.range);
      Draw.reset();
      Draw.color(Pal.placing);
      Lines.stroke(1f);
      if (link != null && Math.abs((int) link.x - x) + Math.abs((int) link.y - y) > 1)
      {
        int i = (int) (sbyte) link.absoluteRelativeTo(x, y);
        float width = (int) link.x != x ? (float) (Math.abs((int) link.x - x) * 8 - 8) : 8f;
        float height = (int) link.y != y ? (float) (Math.abs((int) link.y - y) * 8 - 8) : 8f;
        Lines.rect((float) (x + (int) link.x) / 2f * 8f - width / 2f, (float) (y + (int) link.y) / 2f * 8f - height / 2f, width, height);
        Draw.rect("bridge-arrow", (float) ((int) link.x * 8 + Geometry.d4(i).x * 8), (float) ((int) link.y * 8 + Geometry.d4(i).y * 8), (float) ((int) (sbyte) link.absoluteRelativeTo(x, y) * 90));
      }
      Draw.reset();
    }

    [Signature("(Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {104, 112, 109, 111, 127, 1, 255, 6, 60, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void handlePlacementLine(Seq plans)
    {
      for (int index = 0; index < plans.size - 1; ++index)
      {
        BuildPlan buildPlan1 = (BuildPlan) plans.get(index);
        BuildPlan buildPlan2 = (BuildPlan) plans.get(index + 1);
        if (this.positionsValid(buildPlan1.x, buildPlan1.y, buildPlan2.x, buildPlan2.y))
          buildPlan1.config = (object) new Point2(buildPlan2.x - buildPlan1.x, buildPlan2.y - buildPlan1.y);
      }
    }

    [Signature("(Larc/struct/Seq<Larc/math/geom/Point2;>;I)V")]
    [LineNumberTable(new byte[] {115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void changePlacementPath(Seq points, int rotation) => Placement.calculateNodes(points, (Block) this, rotation, (Boolf2) new ItemBridge.__\u003C\u003EAnon3(this));

    [HideFromJava]
    static ItemBridge() => Block.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerTransport
    {
      [HideFromJava] get => this.__\u003C\u003EtimerTransport;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerTransport = value;
    }

    public class ItemBridgeBuild : Building
    {
      public int link;
      public IntSet incoming;
      public float uptime;
      public float time;
      public float time2;
      public float cycleSpeed;
      [Modifiers]
      internal ItemBridge this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 86, 118, 143, 125, 122, 113, 127, 14, 108, 141, 110, 191, 3, 106, 106, 114, 106, 191, 27, 116, 106, 159, 27, 114, 111, 101, 122, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void drawInput([In] Tile obj0)
      {
        if (!this.this\u00240.linkValid(this.tile, obj0, false))
          return;
        int num1 = obj0.pos() == this.link ? 1 : 0;
        Tmp.__\u003C\u003Ev2.trns(this.tile.angleTo((Position) obj0), 2f);
        float toValue1 = this.tile.drawx();
        float toValue2 = this.tile.drawy();
        float num2 = obj0.drawx();
        float num3 = obj0.drawy();
        float progress = Math.abs((num1 == 0 ? 0.0f : 100f) - Time.time * 2f % 100f) / 100f;
        float x = Mathf.lerp(num2, toValue1, progress);
        float y = Mathf.lerp(num3, toValue2, progress);
        Tile tile = num1 == 0 ? this.tile : obj0;
        int num4 = (int) (sbyte) (num1 == 0 ? obj0 : this.tile).absoluteRelativeTo((int) tile.x, (int) tile.y);
        Draw.color(Pal.gray);
        Lines.stroke(2.5f);
        Lines.square(num2, num3, 2f, 45f);
        Lines.stroke(2.5f);
        Lines.line(toValue1 + Tmp.__\u003C\u003Ev2.x, toValue2 + Tmp.__\u003C\u003Ev2.y, num2 - Tmp.__\u003C\u003Ev2.x, num3 - Tmp.__\u003C\u003Ev2.y);
        Draw.color(num1 == 0 ? Pal.accent : Pal.place);
        Lines.stroke(1f);
        Lines.line(toValue1 + Tmp.__\u003C\u003Ev2.x, toValue2 + Tmp.__\u003C\u003Ev2.y, num2 - Tmp.__\u003C\u003Ev2.x, num3 - Tmp.__\u003C\u003Ev2.y);
        Lines.square(num2, num3, 2f, 45f);
        Draw.mixcol(Draw.getColor(), 1f);
        Draw.color();
        Draw.rect(this.this\u00240.arrowRegion, x, y, (float) (num4 * 90));
        Draw.mixcol();
      }

      [LineNumberTable(new byte[] {160, 156, 108, 104, 103, 108, 127, 19, 134, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void checkIncoming()
      {
        IntSet.IntSetIterator intSetIterator = this.incoming.iterator();
        while (intSetIterator.hasNext)
        {
          int pos = intSetIterator.next();
          Tile other = Vars.world.tile(pos);
          if (!this.this\u00240.linkValid(this.tile, other, false) || ((ItemBridge.ItemBridgeBuild) other.build).link != this.tile.pos())
            intSetIterator.remove();
        }
      }

      [LineNumberTable(new byte[] {160, 191, 127, 18, 108, 109, 104, 158, 124, 99, 109, 204})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void updateTransport(Building other)
      {
        if ((double) this.uptime < 0.5 || !this.timer(this.this\u00240.__\u003C\u003EtimerTransport, this.this\u00240.transportTime))
          return;
        Item obj = this.items.take();
        if (obj != null && other.acceptItem((Building) this, obj))
        {
          other.handleItem((Building) this, obj);
          this.cycleSpeed = Mathf.lerpDelta(this.cycleSpeed, 4f, 0.05f);
        }
        else
        {
          this.cycleSpeed = Mathf.lerpDelta(this.cycleSpeed, 1f, 0.01f);
          if (obj == null)
            return;
          this.items.add(obj, 1);
          this.items.undoFlow(obj);
        }
      }

      [LineNumberTable(411)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual bool linked(Building source) => source is ItemBridge.ItemBridgeBuild && this.this\u00240.linkValid(source.tile, this.tile) && ((ItemBridge.ItemBridgeBuild) source).link == this.pos();

      [LineNumberTable(new byte[] {161, 50, 113, 119, 114, 148, 140, 104, 104, 120, 130, 98, 162, 117, 148})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual bool checkDump(Building to)
      {
        Tile other = Vars.world.tile(this.link);
        if (this.this\u00240.linkValid(this.tile, other))
          return (int) (sbyte) this.relativeTo((int) other.x, (int) other.y) != (int) (sbyte) this.relativeTo(to.tileX(), to.tileY());
        Tile facingEdge = Edges.getFacingEdge(to.tile, this.tile);
        int num = (int) (sbyte) this.relativeTo((int) facingEdge.x, (int) facingEdge.y);
        IntSet.IntSetIterator intSetIterator = this.incoming.iterator();
        while (intSetIterator.hasNext)
        {
          int pos = intSetIterator.next();
          if ((int) (sbyte) this.relativeTo((int) Point2.x(pos), (int) Point2.y(pos)) == num)
            return false;
        }
        return true;
      }

      [LineNumberTable(449)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Point2 config() => Point2.unpack(this.link).sub((int) this.tile.x, (int) this.tile.y);

      [Modifiers]
      [LineNumberTable(194)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024drawSelect\u00240([In] int obj0) => this.drawInput(Vars.world.tile(obj0));

      [LineNumberTable(new byte[] {118, 111, 103, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ItemBridgeBuild(ItemBridge _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ItemBridge.ItemBridgeBuild itemBridgeBuild = this;
        this.link = -1;
        this.incoming = new IntSet();
        this.cycleSpeed = 1f;
      }

      [LineNumberTable(new byte[] {160, 64, 135, 127, 3, 127, 8, 187, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void playerPlaced(object config)
      {
        base.playerPlaced(config);
        Tile link = this.this\u00240.findLink((int) this.tile.x, (int) this.tile.y);
        if (this.this\u00240.linkValid(this.tile, link) && !this.proximity.contains((object) link.build))
          link.build.configure((object) Integer.valueOf(this.tile.pos()));
        this.this\u00240.lastBuild = this;
      }

      [LineNumberTable(new byte[] {160, 76, 127, 4, 182, 150, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect()
      {
        if (this.this\u00240.linkValid(this.tile, Vars.world.tile(this.link)))
          this.drawInput(Vars.world.tile(this.link));
        this.incoming.each((Intc) new ItemBridge.ItemBridgeBuild.__\u003C\u003EAnon0(this));
        Draw.reset();
      }

      [LineNumberTable(new byte[] {160, 120, 159, 24, 115, 105, 127, 9, 119, 143, 111, 63, 44, 229, 59, 41, 233, 75})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawConfigure()
      {
        Drawf.select(this.x, this.y, (float) (this.tile.block().size * 8) / 2f + 2f, Pal.accent);
        for (int index1 = 1; index1 <= this.this\u00240.range; ++index1)
        {
          for (int index2 = 0; index2 < 4; ++index2)
          {
            Tile other = this.tile.nearby(Geometry.__\u003C\u003Ed4[index2].x * index1, Geometry.__\u003C\u003Ed4[index2].y * index1);
            if (this.this\u00240.linkValid(this.tile, other))
            {
              int num = other.pos() == this.link ? 1 : 0;
              Drawf.select(other.drawx(), other.drawy(), (float) (other.block().size * 8) / 2f + 2f + (num == 0 ? Mathf.absin(Time.time, 4f, 1f) : 0.0f), num == 0 ? Pal.breakInvalid : Pal.place);
            }
          }
        }
      }

      [LineNumberTable(new byte[] {160, 138, 127, 14, 113, 108, 162, 121, 110, 142, 145, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool onConfigureTileTapped(Building other)
      {
        Building building = other;
        ItemBridge.ItemBridgeBuild itemBridgeBuild;
        if (building is ItemBridge.ItemBridgeBuild && object.ReferenceEquals((object) (itemBridgeBuild = (ItemBridge.ItemBridgeBuild) building), (object) (ItemBridge.ItemBridgeBuild) building) && itemBridgeBuild.link == this.pos())
        {
          this.configure((object) Integer.valueOf(other.pos()));
          other.configure((object) Integer.valueOf(-1));
          return true;
        }
        if (!this.this\u00240.linkValid(this.tile, other.tile))
          return true;
        if (this.link == other.pos())
          this.configure((object) Integer.valueOf(-1));
        else
          this.configure((object) Integer.valueOf(other.pos()));
        return false;
      }

      [LineNumberTable(new byte[] {160, 168, 125, 159, 5, 134, 113, 116, 103, 144, 159, 2, 125, 158, 188, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.time += this.cycleSpeed * this.delta();
        this.time2 += (this.cycleSpeed - 1f) * this.delta();
        this.checkIncoming();
        Tile other = Vars.world.tile(this.link);
        if (!this.this\u00240.linkValid(this.tile, other))
        {
          this.dump();
          this.uptime = 0.0f;
        }
        else
        {
          ((ItemBridge.ItemBridgeBuild) other.build).incoming.add(this.tile.pos());
          this.uptime = !this.consValid() || !Mathf.zero(1f - this.efficiency()) ? Mathf.lerpDelta(this.uptime, 0.0f, 0.02f) : Mathf.lerpDelta(this.uptime, 1f, 0.04f);
          this.updateTransport(other.build);
        }
      }

      [LineNumberTable(new byte[] {160, 208, 134, 138, 113, 149, 141, 148, 127, 5, 157, 127, 5, 159, 10, 138, 159, 31, 191, 17, 115, 243, 60, 229, 70, 159, 21, 110, 137, 133, 108, 127, 23, 114, 127, 18, 31, 20, 5, 235, 70, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Draw.z(70f);
        Tile other = Vars.world.tile(this.link);
        if (!this.this\u00240.linkValid(this.tile, other) || Mathf.zero(Renderer.bridgeOpacity))
          return;
        int i = (int) (sbyte) this.relativeTo((int) other.x, (int) other.y);
        Draw.color(Color.__\u003C\u003Ewhite, Color.__\u003C\u003Eblack, Mathf.absin(Time.time, 6f, 0.07f));
        Draw.alpha(Math.max(this.uptime, 0.25f) * Renderer.bridgeOpacity);
        Draw.rect(this.this\u00240.endRegion, this.x, this.y, (float) (i * 90 + 90));
        Draw.rect(this.this\u00240.endRegion, other.drawx(), other.drawy(), (float) (i * 90 + 270));
        Lines.stroke(8f);
        Tmp.__\u003C\u003Ev1.set(this.x, this.y).sub(other.worldx(), other.worldy()).setLength(4f).scl(-1f);
        Lines.line(this.this\u00240.bridgeRegion, this.x + Tmp.__\u003C\u003Ev1.x, this.y + Tmp.__\u003C\u003Ev1.y, other.worldx() - Tmp.__\u003C\u003Ev1.x, other.worldy() - Tmp.__\u003C\u003Ev1.y, false);
        int num1 = Math.max(Math.abs((int) other.x - (int) this.tile.x), Math.abs((int) other.y - (int) this.tile.y));
        float num2 = this.time2 / 1.7f;
        int num3 = num1 * 8 / 4 - 2;
        Draw.color();
        for (int index = 0; index < num3; ++index)
        {
          Draw.alpha(Mathf.absin((float) index / (float) num3 - num2 / 100f, 0.1f, 1f) * this.uptime * Renderer.bridgeOpacity);
          Draw.rect(this.this\u00240.arrowRegion, this.x + (float) Geometry.d4(i).x * (4f + (float) index * 4f + num2 % 4f), this.y + (float) Geometry.d4(i).y * (4f + (float) index * 4f + num2 % 4f), (float) i * 90f);
        }
        Draw.reset();
      }

      [LineNumberTable(new byte[] {160, 253, 149, 145, 154, 139, 116, 105, 143, 168})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item)
      {
        if (!object.ReferenceEquals((object) this.team, (object) source.team))
          return false;
        Tile tile = Vars.world.tile(this.link);
        if (this.items.total() >= this.this\u00240.itemCapacity)
          return false;
        if (this.linked(source))
          return true;
        return this.this\u00240.linkValid(this.tile, tile) && (int) (sbyte) this.relativeTo(tile) != (int) (sbyte) this.relativeTo(Edges.getFacingEdge(source, (Building) this));
      }

      [LineNumberTable(387)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool canDumpLiquid(Building to, Liquid liquid) => this.checkDump(to);

      [LineNumberTable(new byte[] {161, 22, 159, 3, 145, 159, 20, 139, 116, 116, 143, 168})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptLiquid(Building source, Liquid liquid)
      {
        if (!object.ReferenceEquals((object) this.team, (object) source.team) || !this.this\u00240.hasLiquids)
          return false;
        Tile other = Vars.world.tile(this.link);
        if (!object.ReferenceEquals((object) this.liquids.current(), (object) liquid) && (double) this.liquids.get(this.liquids.current()) >= 0.200000002980232)
          return false;
        if (this.linked(source))
          return true;
        return this.this\u00240.linkValid(this.tile, other) && (int) (sbyte) this.relativeTo((int) other.x, (int) other.y) != (int) (sbyte) this.relativeTo(Edges.getFacingEdge(source, (Building) this));
      }

      [LineNumberTable(416)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool canDump(Building to, Item item) => this.checkDump(to);

      [LineNumberTable(444)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldConsume() => this.this\u00240.linkValid(this.tile, Vars.world.tile(this.link)) && this.enabled;

      [LineNumberTable(new byte[] {161, 84, 103, 108, 108, 145, 140, 104, 142})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.i(this.link);
        write.f(this.uptime);
        write.b(this.incoming.size);
        IntSet.IntSetIterator intSetIterator = this.incoming.iterator();
        while (intSetIterator.hasNext)
          write.i(intSetIterator.next());
      }

      [LineNumberTable(new byte[] {159, 25, 67, 104, 108, 109, 104, 102, 50, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num1 = (int) (sbyte) revision;
        base.read(read, (byte) num1);
        this.link = read.i();
        this.uptime = read.f();
        int num2 = (int) (sbyte) read.b();
        for (int index = 0; index < num2; ++index)
          this.incoming.add(read.i());
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(168)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static ItemBridgeBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Intc
      {
        private readonly ItemBridge.ItemBridgeBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] ItemBridge.ItemBridgeBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] int obj0) => this.arg\u00241.lambda\u0024drawSelect\u00240(obj0);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => ItemBridge.lambda\u0024new\u00240((ItemBridge.ItemBridgeBuild) obj0, (Point2) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons2
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0, [In] object obj1) => ItemBridge.lambda\u0024new\u00241((ItemBridge.ItemBridgeBuild) obj0, (Integer) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly ItemBridge arg\u00241;
      private readonly BuildPlan arg\u00242;

      internal __\u003C\u003EAnon2([In] ItemBridge obj0, [In] BuildPlan obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawRequestConfigTop\u00242(this.arg\u00242, (BuildPlan) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Boolf2
    {
      private readonly ItemBridge arg\u00241;

      internal __\u003C\u003EAnon3([In] ItemBridge obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0, [In] object obj1) => (this.arg\u00241.lambda\u0024changePlacementPath\u00243((Point2) obj0, (Point2) obj1) ? 1 : 0) != 0;
    }
  }
}
