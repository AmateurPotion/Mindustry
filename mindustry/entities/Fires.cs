// Decompiled with JetBrains decompiler
// Type: mindustry.entities.Fires
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using System.Runtime.CompilerServices;

namespace mindustry.entities
{
  public class Fires : Object
  {
    private const float baseLifetime = 1000f;
    [Modifiers]
    [Signature("Larc/struct/IntMap<Lmindustry/gen/Fire;>;")]
    private static IntMap map;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 159, 2, 150, 99, 102, 103, 107, 116, 102, 148, 107, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void create(Tile tile)
    {
      if (Vars.net.client() || tile == null || !Vars.state.rules.fire)
        return;
      Fire fire1 = (Fire) Fires.map.get(tile.pos());
      if (fire1 == null)
      {
        Fire fire2 = Fire.create();
        fire2.tile = tile;
        fire2.lifetime = 1000f;
        fire2.set(tile.worldx(), tile.worldy());
        fire2.add();
        Fires.map.put(tile.pos(), (object) fire2);
      }
      else
      {
        fire1.lifetime = 1000f;
        fire1.time = 0.0f;
      }
    }

    [LineNumberTable(new byte[] {159, 184, 127, 17, 130, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool has(int x, int y)
    {
      if (!Structs.inBounds(x, y, Vars.world.width(), Vars.world.height()) || !Fires.map.containsKey(Point2.pack(x, y)))
        return false;
      Fire fire = (Fire) Fires.map.get(Point2.pack(x, y));
      return fire.isAdded() && (double) fire.fin() < 1.0 && (fire.tile() != null && (int) fire.tile().x == x) && (int) fire.tile().y == y;
    }

    [LineNumberTable(new byte[] {3, 117, 118, 119, 107, 110, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void extinguish(Tile tile, float intensity)
    {
      if (tile == null || !Fires.map.containsKey(tile.pos()))
        return;
      Fire fire = (Fire) Fires.map.get(tile.pos());
      fire.time(fire.time + intensity * Time.delta);
      Fx.__\u003C\u003Esteam.at((Position) fire);
      if ((double) fire.time < (double) fire.lifetime)
        return;
      Events.fire((object) EventType.Trigger.__\u003C\u003EfireExtinguish);
    }

    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Fires()
    {
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Fire get(int x, int y) => (Fire) Fires.map.get(Point2.pack(x, y));

    [LineNumberTable(new byte[] {14, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void remove(Tile tile) => Fires.map.remove(tile.pos());

    [LineNumberTable(new byte[] {18, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void register(Fire fire) => Fires.map.put(fire.tile.pos(), (object) fire);

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fires()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.Fires"))
        return;
      Fires.map = new IntMap();
    }
  }
}
