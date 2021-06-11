// Decompiled with JetBrains decompiler
// Type: mindustry.maps.generators.BaseGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.ai;
using mindustry.content;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.defense;
using mindustry.world.blocks.distribution;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.power;
using mindustry.world.blocks.production;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.generators
{
  public class BaseGenerator : Object
  {
    [Modifiers]
    private static Vec2 axis;
    [Modifiers]
    private static Vec2 rotator;
    private const int range = 160;
    private Tiles tiles;
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    private Seq cores;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Larc/func/Cons<Lmindustry/world/Tile;>;)V")]
    [LineNumberTable(new byte[] {160, 65, 113, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void pass([In] Cons obj0) => ((Tile) this.cores.first()).circle(160, (Intc2) new BaseGenerator.__\u003C\u003EAnon10(this, obj0));

    [LineNumberTable(new byte[] {160, 82, 103, 127, 30, 109, 133, 159, 6, 114, 147, 127, 5, 119, 114, 162, 100, 139, 130, 127, 16, 127, 5, 142, 255, 12, 77, 162, 188, 127, 16, 127, 8, 142, 159, 5, 100, 186, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool tryPlace(BaseRegistry.BasePart part, int x, int y, Team team, [Nullable(new object[] {64, "Larc/util/Nullable;"})] Intc2 posc)
    {
      int times = Mathf.range(2);
      BaseGenerator.axis.set((float) ByteCodeHelper.f2i((float) part.__\u003C\u003Eschematic.width / 2f), (float) ByteCodeHelper.f2i((float) part.__\u003C\u003Eschematic.height / 2f));
      Schematic schem = Schematics.rotate(part.__\u003C\u003Eschematic, times);
      int num1 = times * 90;
      BaseGenerator.rotator.set((float) part.centerX, (float) part.centerY).rotateAround(BaseGenerator.axis, (float) num1);
      int num2 = x - ByteCodeHelper.f2i(BaseGenerator.rotator.x);
      int num3 = y - ByteCodeHelper.f2i(BaseGenerator.rotator.y);
      Iterator iterator1 = schem.__\u003C\u003Etiles.iterator();
      while (iterator1.hasNext())
      {
        Schematic.Stile stile = (Schematic.Stile) iterator1.next();
        int i1 = (int) stile.x + num2;
        int i2 = (int) stile.y + num3;
        if (BaseGenerator.isTaken(stile.block, i1, i2))
          return false;
        posc?.get(i1, i2);
      }
      Content required1 = part.required;
      Item obj1;
      if (required1 is Item && object.ReferenceEquals((object) (obj1 = (Item) required1), (object) (Item) required1))
      {
        Iterator iterator2 = schem.__\u003C\u003Etiles.iterator();
        while (iterator2.hasNext())
        {
          Schematic.Stile stile = (Schematic.Stile) iterator2.next();
          if (stile.block is Drill)
            stile.block.iterateTaken((int) stile.x + num2, (int) stile.y + num3, (Intc2) new BaseGenerator.__\u003C\u003EAnon11(obj1));
        }
      }
      Schematics.place(schem, num2 + schem.width / 2, num3 + schem.height / 2, team);
      Content required2 = part.required;
      Item obj2;
      if (required2 is Item && object.ReferenceEquals((object) (obj2 = (Item) required2), (object) (Item) required2))
      {
        Iterator iterator2 = schem.__\u003C\u003Etiles.iterator();
        while (iterator2.hasNext())
        {
          Schematic.Stile stile = (Schematic.Stile) iterator2.next();
          if (stile.block is Drill)
          {
            Building build = Vars.world.tile((int) stile.x + num2, (int) stile.y + num3).build;
            build?.items.add(obj2, build.block.itemCapacity);
          }
        }
      }
      return true;
    }

    [LineNumberTable(new byte[] {160, 151, 108, 108, 130, 110, 112, 114, 2, 40, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isTaken([In] Block obj0, [In] int obj1, [In] int obj2)
    {
      int num1 = -(obj0.size - 1) / 2;
      int num2 = -(obj0.size - 1) / 2;
      int num3 = 1;
      for (int index1 = -num3; index1 < obj0.size + num3; ++index1)
      {
        for (int index2 = -num3; index2 < obj0.size + num3; ++index2)
        {
          if (BaseGenerator.overlaps(index1 + num1 + obj1, index2 + num2 + obj2))
            return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 167, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool overlaps([In] int obj0, [In] int obj1)
    {
      Tile tile = Vars.world.tiles.get(obj0, obj1);
      return tile == null || !tile.block().alwaysReplace || (double) Vars.world.getDarkness(obj0, obj1) > 0.0;
    }

    [LineNumberTable(new byte[] {160, 143, 114, 125, 114, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void set([In] Tile obj0, [In] Item obj1)
    {
      if (Vars.bases.ores.containsKey((object) obj1))
      {
        obj0.setOverlay((Block) Vars.bases.ores.get((object) obj1));
      }
      else
      {
        if (!Vars.bases.oreFloors.containsKey((object) obj1))
          return;
        obj0.setFloor((Floor) Vars.bases.oreFloors.get((object) obj1));
      }
    }

    [LineNumberTable(188)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool tryPlace(BaseRegistry.BasePart part, int x, int y, Team team) => BaseGenerator.tryPlace(part, x, y, team, (Intc2) null);

    [Modifiers]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024generate\u00240([In] Block obj0) => obj0 is Wall && obj0.size == 1 && (!obj0.insulated && object.ReferenceEquals((object) obj0.buildVisibility, (object) BuildVisibility.__\u003C\u003Eshown)) && !(obj0 is Door);

    [Modifiers]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024generate\u00241([In] Block obj0) => obj0 is Wall && obj0.size == 2 && (!obj0.insulated && object.ReferenceEquals((object) obj0.buildVisibility, (object) BuildVisibility.__\u003C\u003Eshown)) && !(obj0 is Door);

    [Modifiers]
    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024generate\u00242([In] Block obj0) => obj0.buildCost;

    [Modifiers]
    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024generate\u00243([In] Block obj0) => obj0.buildCost;

    [Modifiers]
    [LineNumberTable(new byte[] {22, 143, 127, 8, 127, 16, 127, 10, 104, 159, 14, 107, 159, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024generate\u00244(
      [In] double obj0,
      [In] double obj1,
      [In] float obj2,
      [In] float obj3,
      [In] Team obj4,
      [In] Tile obj5)
    {
      if (!obj5.block().alwaysReplace)
        return;
      if ((obj5.overlay().asFloor().itemDrop != null || obj5.drop() != null && Mathf.chance(obj0) || obj5.floor().liquidDrop != null && Mathf.chance(obj0 * 2.0)) && Mathf.chance(obj1))
      {
        Seq seq = Vars.bases.forResource(obj5.drop() == null ? (Content) obj5.floor().liquidDrop : (Content) obj5.drop());
        if (seq.isEmpty())
          return;
        BaseGenerator.tryPlace((BaseRegistry.BasePart) seq.getFrac(obj2 + Mathf.range(obj3)), (int) obj5.x, (int) obj5.y, obj4);
      }
      else
      {
        if (!Mathf.chance(obj0))
          return;
        BaseGenerator.tryPlace((BaseRegistry.BasePart) Vars.bases.parts.getFrac(obj2 + Mathf.range(obj3)), (int) obj5.x, (int) obj5.y, obj4);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {49, 113, 130, 116, 191, 7, 127, 1, 225, 59, 233, 73, 119, 127, 10, 162, 127, 7, 127, 2, 98, 226, 56, 233, 76, 99, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024generate\u00246(
      [In] Tiles obj0,
      [In] Tile obj1,
      [In] int obj2,
      [In] Team obj3,
      [In] Block obj4,
      [In] Tile obj5)
    {
      if (!obj5.block().alwaysReplace)
        return;
      int num = 0;
      Point2[] d4 = Geometry.__\u003C\u003Ed4;
      int length1 = d4.Length;
      for (int index = 0; index < length1; ++index)
      {
        Point2 point2 = d4[index];
        Tile tile = obj0.get((int) obj5.x + point2.x, (int) obj5.y + point2.y);
        if (tile != null && (tile.block() is PayloadConveyor || tile.block() is PayloadAcceptor))
          return;
      }
      Point2[] d8 = Geometry.__\u003C\u003Ed8;
      int length2 = d8.Length;
      for (int index = 0; index < length2; ++index)
      {
        Point2 point2 = d8[index];
        if ((double) Angles.angleDist(Angles.angle((float) point2.x, (float) point2.y), obj1.angleTo((Position) obj5)) <= (double) obj2)
        {
          Tile tile = obj0.get((int) obj5.x + point2.x, (int) obj5.y + point2.y);
          if (tile != null && object.ReferenceEquals((object) tile.team(), (object) obj3) && !(tile.block() is Wall))
          {
            num = 1;
            break;
          }
        }
      }
      if (num == 0)
        return;
      obj5.setBlock(obj4, obj3);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {81, 98, 105, 105, 121, 159, 14, 110, 228, 59, 41, 233, 75, 100, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024generate\u00247(
      [In] Tiles obj0,
      [In] Block obj1,
      [In] Block obj2,
      [In] Team obj3,
      [In] Tile obj4)
    {
      int num = 0;
      for (int index1 = 0; index1 < 2; ++index1)
      {
        for (int index2 = 0; index2 < 2; ++index2)
        {
          Tile tile = obj0.get((int) obj4.x + index1, (int) obj4.y + index2);
          if (tile == null || tile.block().size != 1 || !object.ReferenceEquals((object) tile.block(), (object) obj1) && !tile.block().alwaysReplace)
            return;
          if (object.ReferenceEquals((object) tile.block(), (object) obj1))
            ++num;
        }
      }
      if (num < 3)
        return;
      obj4.setBlock(obj2, obj3);
    }

    [Modifiers]
    [LineNumberTable(151)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024generate\u00248([In] Tile obj0, [In] Tile obj1)
    {
      if (object.ReferenceEquals((object) obj1.team(), (object) Vars.state.rules.waveTeam) && !obj1.within((Position) obj0, 200f))
        return 100000f;
      return obj1.floor().hasSurface() ? 1f : 10f;
    }

    [Modifiers]
    [LineNumberTable(151)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024generate\u00249([In] Tile obj0) => !obj0.block().isStatic();

    [Modifiers]
    [LineNumberTable(new byte[] {102, 113, 124, 171, 115, 105, 127, 2, 236, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024generate\u002410([In] Tile obj0, [In] Tile obj1)
    {
      if (obj1.within((Position) obj0, 200f))
        return;
      if (object.ReferenceEquals((object) obj1.team(), (object) Vars.state.rules.waveTeam))
        obj1.setBlock(Blocks.air);
      Point2[] d8 = Geometry.__\u003C\u003Ed8;
      int length = d8.Length;
      for (int index = 0; index < length; ++index)
      {
        Point2 relative = d8[index];
        Tile tile = obj1.nearby(relative);
        if (tile != null && object.ReferenceEquals((object) tile.team(), (object) Vars.state.rules.waveTeam))
          tile.setBlock(Blocks.air);
      }
    }

    [Modifiers]
    [LineNumberTable(180)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024pass\u002411([In] Cons obj0, [In] int obj1, [In] int obj2) => obj0.get((object) this.tiles.getn(obj1, obj2));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 109, 125, 183, 127, 1, 141, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024tryPlace\u002412([In] Item obj0, [In] int obj1, [In] int obj2)
    {
      if (Vars.world.tiles.getn(obj1, obj2).floor().hasSurface())
        BaseGenerator.set(Vars.world.tiles.getn(obj1, obj2), obj0);
      Tile tile = Vars.world.tiles.getc(obj1 + Mathf.range(1), obj2 + Mathf.range(1));
      if (!tile.floor().hasSurface())
        return;
      BaseGenerator.set(tile, obj0);
    }

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseGenerator()
    {
    }

    [Signature("(Lmindustry/world/Tiles;Larc/struct/Seq<Lmindustry/world/Tile;>;Lmindustry/world/Tile;Lmindustry/game/Team;Lmindustry/type/Sector;F)V")]
    [LineNumberTable(new byte[] {159, 175, 103, 167, 146, 146, 122, 186, 113, 145, 102, 116, 100, 112, 112, 121, 159, 8, 159, 15, 127, 3, 103, 191, 51, 105, 127, 9, 122, 98, 133, 137, 26, 232, 89, 165, 248, 97, 247, 84, 127, 0, 255, 16, 78, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void generate(
      Tiles tiles,
      Seq cores,
      Tile spawn,
      Team team,
      Sector sector,
      float difficulty)
    {
      this.tiles = tiles;
      this.cores = cores;
      if (Vars.bases.cores.isEmpty())
        return;
      Mathf.rand.setSeed((long) sector.__\u003C\u003Eid);
      Seq seq1 = Vars.content.blocks().select((Boolf) new BaseGenerator.__\u003C\u003EAnon0());
      Seq seq2 = Vars.content.blocks().select((Boolf) new BaseGenerator.__\u003C\u003EAnon1());
      seq1.sort((Floatf) new BaseGenerator.__\u003C\u003EAnon2());
      seq2.sort((Floatf) new BaseGenerator.__\u003C\u003EAnon3());
      float num1 = 0.2f;
      float num2 = Mathf.lerp(0.7f, 1.9f, difficulty);
      int num3 = 70;
      double num4 = 0.5 * (double) num2;
      double num5 = 0.0005 * (double) num2;
      BaseRegistry.BasePart frac1 = (BaseRegistry.BasePart) Vars.bases.cores.getFrac(difficulty);
      int num6 = (double) difficulty >= 0.4 ? ((double) difficulty >= 0.8 ? 3 : 2) : 1;
      Block frac2 = (Block) seq1.getFrac(difficulty * 0.91f);
      Block frac3 = (Block) seq2.getFrac(difficulty * 0.91f);
      Iterator iterator1 = cores.iterator();
label_3:
      while (iterator1.hasNext())
      {
        Tile tile = (Tile) iterator1.next();
        tile.clearOverlay();
        Schematics.placeLoadout(frac1.__\u003C\u003Eschematic, (int) tile.x, (int) tile.y, team, !(frac1.required is Item) ? Blocks.oreCopper : (Block) Vars.bases.ores.get((object) (Item) frac1.required), false);
        Building build = tile.build;
        Iterator iterator2 = Vars.content.items().iterator();
        while (true)
        {
          if (iterator2.hasNext())
          {
            Item obj = (Item) iterator2.next();
            build.items.add(obj, build.block.itemCapacity);
          }
          else
            goto label_3;
        }
      }
      for (int index = 0; index < num6; ++index)
        this.pass((Cons) new BaseGenerator.__\u003C\u003EAnon4(num5, num4, difficulty, num1, team));
      if (num3 > 0)
      {
        this.pass((Cons) new BaseGenerator.__\u003C\u003EAnon5(tiles, spawn, num3, team, frac2));
        this.pass((Cons) new BaseGenerator.__\u003C\u003EAnon6(tiles, frac2, frac3, team));
      }
      Iterator iterator3 = cores.iterator();
      while (iterator3.hasNext())
      {
        Tile from = (Tile) iterator3.next();
        Astar.pathfind(from, spawn, (Astar.TileHueristic) new BaseGenerator.__\u003C\u003EAnon7(from), (Boolf) new BaseGenerator.__\u003C\u003EAnon8()).each((Cons) new BaseGenerator.__\u003C\u003EAnon9(from));
      }
    }

    [LineNumberTable(new byte[] {119, 137, 127, 1, 127, 18, 139, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void postGenerate()
    {
      if (this.tiles == null)
        return;
      Iterator iterator = this.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if (tile.isCenter() && tile.block() is PowerNode && object.ReferenceEquals((object) tile.team(), (object) Vars.state.rules.waveTeam))
          tile.build.placed();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {39, 127, 24, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024generate\u00245([In] Team obj0, [In] Block obj1, [In] Block obj2, [In] Tile obj3)
    {
      if (!(obj3.block() is Wall) || !object.ReferenceEquals((object) obj3.team(), (object) obj0) || (object.ReferenceEquals((object) obj3.block(), (object) obj1) || object.ReferenceEquals((object) obj3.block(), (object) obj2)))
        return;
      obj3.setBlock(obj3.block().size != 2 ? obj1 : obj2, obj0);
    }

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BaseGenerator()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.maps.generators.BaseGenerator"))
        return;
      BaseGenerator.axis = new Vec2();
      BaseGenerator.rotator = new Vec2();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (BaseGenerator.lambda\u0024generate\u00240((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (BaseGenerator.lambda\u0024generate\u00241((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public float get([In] object obj0) => BaseGenerator.lambda\u0024generate\u00242((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public float get([In] object obj0) => BaseGenerator.lambda\u0024generate\u00243((Block) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly double arg\u00241;
      private readonly double arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly Team arg\u00245;

      internal __\u003C\u003EAnon4([In] double obj0, [In] double obj1, [In] float obj2, [In] float obj3, [In] Team obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] object obj0) => BaseGenerator.lambda\u0024generate\u00244(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly Tiles arg\u00241;
      private readonly Tile arg\u00242;
      private readonly int arg\u00243;
      private readonly Team arg\u00244;
      private readonly Block arg\u00245;

      internal __\u003C\u003EAnon5([In] Tiles obj0, [In] Tile obj1, [In] int obj2, [In] Team obj3, [In] Block obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] object obj0) => BaseGenerator.lambda\u0024generate\u00246(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly Tiles arg\u00241;
      private readonly Block arg\u00242;
      private readonly Block arg\u00243;
      private readonly Team arg\u00244;

      internal __\u003C\u003EAnon6([In] Tiles obj0, [In] Block obj1, [In] Block obj2, [In] Team obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => BaseGenerator.lambda\u0024generate\u00247(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Astar.TileHueristic
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon7([In] Tile obj0) => this.arg\u00241 = obj0;

      public float cost([In] Tile obj0) => BaseGenerator.lambda\u0024generate\u00248(this.arg\u00241, obj0);

      [SpecialName]
      public float cost([In] Tile obj0, [In] Tile obj1) => Astar.TileHueristic.\u003Cdefault\u003Ecost((Astar.TileHueristic) this, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolf
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public bool get([In] object obj0) => (BaseGenerator.lambda\u0024generate\u00249((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon9([In] Tile obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => BaseGenerator.lambda\u0024generate\u002410(this.arg\u00241, (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Intc2
    {
      private readonly BaseGenerator arg\u00241;
      private readonly Cons arg\u00242;

      internal __\u003C\u003EAnon10([In] BaseGenerator obj0, [In] Cons obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024pass\u002411(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Intc2
    {
      private readonly Item arg\u00241;

      internal __\u003C\u003EAnon11([In] Item obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => BaseGenerator.lambda\u0024tryPlace\u002412(this.arg\u00241, obj0, obj1);
    }
  }
}
