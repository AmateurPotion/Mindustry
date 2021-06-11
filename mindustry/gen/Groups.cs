// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Groups
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.entities;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public class Groups : Object
  {
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Entityc;>;")]
    public static EntityGroup all;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Player;>;")]
    public static EntityGroup player;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Bullet;>;")]
    public static EntityGroup bullet;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Unit;>;")]
    public static EntityGroup unit;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Building;>;")]
    public static EntityGroup build;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Syncc;>;")]
    public static EntityGroup sync;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Drawc;>;")]
    public static EntityGroup draw;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Fire;>;")]
    public static EntityGroup fire;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Puddle;>;")]
    public static EntityGroup puddle;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/WeatherState;>;")]
    public static EntityGroup weather;
    [Signature("Larc/struct/Seq<Larc/util/pooling/Pool$Poolable;>;")]
    private static Seq freeQueue;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 174, 113, 113, 113, 113, 113, 113, 113, 113, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init()
    {
      Groups.all = new EntityGroup((Class) ClassLiteral<Entityc>.Value, false, false);
      Groups.player = new EntityGroup((Class) ClassLiteral<Player>.Value, false, true);
      Groups.bullet = new EntityGroup((Class) ClassLiteral<Bullet>.Value, true, false);
      Groups.unit = new EntityGroup((Class) ClassLiteral<Unit>.Value, true, true);
      Groups.build = new EntityGroup((Class) ClassLiteral<Building>.Value, false, false);
      Groups.sync = new EntityGroup((Class) ClassLiteral<Syncc>.Value, false, true);
      Groups.draw = new EntityGroup((Class) ClassLiteral<Drawc>.Value, false, false);
      Groups.fire = new EntityGroup((Class) ClassLiteral<Fire>.Value, false, false);
      Groups.puddle = new EntityGroup((Class) ClassLiteral<Puddle>.Value, false, false);
      Groups.weather = new EntityGroup((Class) ClassLiteral<WeatherState>.Value, false, false);
    }

    [LineNumberTable(new byte[] {159, 187, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clear()
    {
      Groups.all.clear();
      Groups.player.clear();
      Groups.bullet.clear();
      Groups.unit.clear();
      Groups.build.clear();
      Groups.sync.clear();
      Groups.draw.clear();
      Groups.fire.clear();
      Groups.puddle.clear();
      Groups.weather.clear();
    }

    [LineNumberTable(new byte[] {17, 127, 8, 107, 106, 106, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void update()
    {
      Iterator iterator = Groups.freeQueue.iterator();
      while (iterator.hasNext())
        Pools.free((object) (Pool.Poolable) iterator.next());
      Groups.freeQueue.clear();
      Groups.bullet.updatePhysics();
      Groups.unit.updatePhysics();
      Groups.all.update();
      Groups.bullet.collide();
    }

    [LineNumberTable(new byte[] {12, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void resize(float x, float y, float w, float h)
    {
      Groups.bullet.resize(x, y, w, h);
      Groups.unit.resize(x, y, w, h);
    }

    [LineNumberTable(new byte[] {8, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void queueFree(Pool.Poolable obj) => Groups.freeQueue.add((object) obj);

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Groups()
    {
    }

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Groups()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.gen.Groups"))
        return;
      Groups.freeQueue = new Seq();
    }
  }
}
