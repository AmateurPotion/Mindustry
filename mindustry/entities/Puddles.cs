// Decompiled with JetBrains decompiler
// Type: mindustry.entities.Puddles
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities
{
  public class Puddles : Object
  {
    [Modifiers]
    [Signature("Larc/struct/IntMap<Lmindustry/gen/Puddle;>;")]
    private static IntMap map;
    public const float maxLiquid = 70f;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deposit(Tile tile, Liquid liquid, float amount) => Puddles.deposit(tile, tile, liquid, amount, 0);

    [LineNumberTable(new byte[] {159, 175, 132, 127, 7, 112, 63, 14, 167, 150, 126, 127, 46, 139, 161, 109, 161, 118, 102, 102, 103, 103, 104, 104, 127, 21, 102, 114, 118, 149, 127, 16, 127, 41, 173, 159, 51})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deposit(
      Tile tile,
      Tile source,
      Liquid liquid,
      float amount,
      int generation)
    {
      if (tile == null)
        return;
      if (tile.floor().isLiquid && !Puddles.canStayOn(liquid, tile.floor().liquidDrop))
      {
        double num = (double) Puddles.reactPuddle(tile.floor().liquidDrop, liquid, amount, tile, (tile.worldx() + source.worldx()) / 2f, (tile.worldy() + source.worldy()) / 2f);
        Puddle puddle = (Puddle) Puddles.map.get(tile.pos());
        if (generation != 0 || puddle == null || (double) puddle.lastRipple > (double) (Time.time - 40f))
          return;
        Fx.__\u003C\u003Eripple.at((tile.worldx() + source.worldx()) / 2f, (tile.worldy() + source.worldy()) / 2f, 1f, tile.floor().liquidDrop.color);
        puddle.lastRipple = Time.time;
      }
      else
      {
        if (tile.floor().solid)
          return;
        Puddle puddle1 = (Puddle) Puddles.map.get(tile.pos());
        if (puddle1 == null)
        {
          Puddle puddle2 = Puddle.create();
          puddle2.tile(tile);
          puddle2.liquid(liquid);
          puddle2.amount(amount);
          puddle2.generation(generation);
          puddle2.set((tile.worldx() + source.worldx()) / 2f, (tile.worldy() + source.worldy()) / 2f);
          puddle2.add();
          Puddles.map.put(tile.pos(), (object) puddle2);
        }
        else if (object.ReferenceEquals((object) puddle1.liquid(), (object) liquid))
        {
          puddle1.accepting(Math.max(amount, puddle1.accepting()));
          if (generation != 0 || (double) puddle1.lastRipple > (double) (Time.time - 40f) || (double) puddle1.amount() < 35.0)
            return;
          Fx.__\u003C\u003Eripple.at((tile.worldx() + source.worldx()) / 2f, (tile.worldy() + source.worldy()) / 2f, 1f, puddle1.liquid().color);
          puddle1.lastRipple = Time.time;
        }
        else
          puddle1.amount(puddle1.amount() + Puddles.reactPuddle(puddle1.liquid(), liquid, amount, puddle1.tile(), (puddle1.x() + source.worldx()) / 2f, (puddle1.y() + source.worldy()) / 2f));
      }
    }

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool canStayOn([In] Liquid obj0, [In] Liquid obj1) => object.ReferenceEquals((object) obj0, (object) Liquids.oil) && object.ReferenceEquals((object) obj1, (object) Liquids.water);

    [LineNumberTable(new byte[] {36, 159, 21, 102, 120, 159, 21, 122, 113, 144, 106, 122, 113, 144, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float reactPuddle(
      [In] Liquid obj0,
      [In] Liquid obj1,
      [In] float obj2,
      [In] Tile obj3,
      [In] float obj4,
      [In] float obj5)
    {
      if ((double) obj0.flammability > 0.300000011920929 && (double) obj1.temperature > 0.699999988079071 || (double) obj1.flammability > 0.300000011920929 && (double) obj0.temperature > 0.699999988079071)
      {
        Fires.create(obj3);
        if (Mathf.chance(0.006 * (double) obj2))
          Bullets.fireball.createNet(Team.__\u003C\u003Ederelict, obj4, obj5, Mathf.random(360f), -1f, 1f, 1f);
      }
      else
      {
        if ((double) obj0.temperature > 0.699999988079071 && (double) obj1.temperature < 0.550000011920929)
        {
          if (Mathf.chance((double) (0.5f * obj2)))
            Fx.__\u003C\u003Esteam.at(obj4, obj5);
          return -0.1f * obj2;
        }
        if ((double) obj1.temperature > 0.699999988079071 && (double) obj0.temperature < 0.550000011920929)
        {
          if (Mathf.chance((double) (0.8f * obj2)))
            Fx.__\u003C\u003Esteam.at(obj4, obj5);
          return -0.4f * obj2;
        }
      }
      return 0.0f;
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Puddles()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deposit(Tile tile, Tile source, Liquid liquid, float amount) => Puddles.deposit(tile, source, liquid, amount, 0);

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Puddle get(Tile tile) => (Puddle) Puddles.map.get(tile.pos());

    [LineNumberTable(new byte[] {25, 132, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void remove(Tile tile)
    {
      if (tile == null)
        return;
      Puddles.map.remove(tile.pos());
    }

    [LineNumberTable(new byte[] {31, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void register(Puddle puddle) => Puddles.map.put(puddle.tile().pos(), (object) puddle);

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Puddles()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.Puddles"))
        return;
      Puddles.map = new IntMap();
    }
  }
}
