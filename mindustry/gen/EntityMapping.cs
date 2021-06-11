// Decompiled with JetBrains decompiler
// Type: mindustry.gen.EntityMapping
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public class EntityMapping : Object
  {
    public static Prov[] idMap;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/func/Prov;>;")]
    public static ObjectMap nameMap;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Prov map(string name) => (Prov) EntityMapping.nameMap.get((object) name);

    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Prov map(int id) => EntityMapping.idMap[id];

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EntityMapping()
    {
    }

    [LineNumberTable(new byte[] {159, 141, 173, 143, 170, 113, 122, 122, 122, 114, 122, 122, 122, 114, 122, 122, 122, 113, 122, 122, 122, 114, 122, 122, 122, 122, 113, 122, 122, 122, 122, 122, 122, 122, 114, 122, 122, 122, 113, 122, 122, 122, 122, 122, 122, 122, 122, 122, 113, 122, 122, 122, 113, 122, 122, 113, 122, 122, 113, 122, 122, 114, 122, 122, 114, 122, 122, 114, 122, 122, 114, 122, 122, 114, 122, 122, 114, 122, 122, 114, 122, 122, 114, 122, 122, 114, 122, 122, 114, 122, 122, 122, 114, 122, 122, 122, 114, 122, 122, 122, 114, 122, 122, 122, 114, 122, 122, 122, 114, 122, 122, 122, 114, 122, 122, 122, 114, 122, 122, 122, 122, 122, 122, 122, 114, 122, 122, 122, 114, 122, 122, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static EntityMapping()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.gen.EntityMapping"))
        return;
      EntityMapping.idMap = new Prov[256];
      EntityMapping.nameMap = new ObjectMap();
      EntityMapping.idMap[0] = (Prov) new EntityMapping.__\u003C\u003EAnon0();
      EntityMapping.nameMap.put((object) "alpha", (object) new EntityMapping.__\u003C\u003EAnon0());
      EntityMapping.nameMap.put((object) "UnitEntityLegacyAlpha", (object) new EntityMapping.__\u003C\u003EAnon0());
      EntityMapping.nameMap.put((object) "unit-entity-legacy-alpha", (object) new EntityMapping.__\u003C\u003EAnon0());
      EntityMapping.idMap[29] = (Prov) new EntityMapping.__\u003C\u003EAnon1();
      EntityMapping.nameMap.put((object) "LegsUnitLegacyArkyid", (object) new EntityMapping.__\u003C\u003EAnon1());
      EntityMapping.nameMap.put((object) "legs-unit-legacy-arkyid", (object) new EntityMapping.__\u003C\u003EAnon1());
      EntityMapping.nameMap.put((object) "arkyid", (object) new EntityMapping.__\u003C\u003EAnon1());
      EntityMapping.idMap[30] = (Prov) new EntityMapping.__\u003C\u003EAnon2();
      EntityMapping.nameMap.put((object) "UnitEntityLegacyBeta", (object) new EntityMapping.__\u003C\u003EAnon2());
      EntityMapping.nameMap.put((object) "unit-entity-legacy-beta", (object) new EntityMapping.__\u003C\u003EAnon2());
      EntityMapping.nameMap.put((object) "beta", (object) new EntityMapping.__\u003C\u003EAnon2());
      EntityMapping.idMap[2] = (Prov) new EntityMapping.__\u003C\u003EAnon3();
      EntityMapping.nameMap.put((object) "block", (object) new EntityMapping.__\u003C\u003EAnon3());
      EntityMapping.nameMap.put((object) "BlockUnitUnit", (object) new EntityMapping.__\u003C\u003EAnon3());
      EntityMapping.nameMap.put((object) "block-unit-unit", (object) new EntityMapping.__\u003C\u003EAnon3());
      EntityMapping.idMap[24] = (Prov) new EntityMapping.__\u003C\u003EAnon4();
      EntityMapping.nameMap.put((object) "corvus", (object) new EntityMapping.__\u003C\u003EAnon4());
      EntityMapping.nameMap.put((object) "atrax", (object) new EntityMapping.__\u003C\u003EAnon4());
      EntityMapping.nameMap.put((object) "LegsUnit", (object) new EntityMapping.__\u003C\u003EAnon4());
      EntityMapping.nameMap.put((object) "legs-unit", (object) new EntityMapping.__\u003C\u003EAnon4());
      EntityMapping.idMap[3] = (Prov) new EntityMapping.__\u003C\u003EAnon5();
      EntityMapping.nameMap.put((object) "eclipse", (object) new EntityMapping.__\u003C\u003EAnon5());
      EntityMapping.nameMap.put((object) "flare", (object) new EntityMapping.__\u003C\u003EAnon5());
      EntityMapping.nameMap.put((object) "zenith", (object) new EntityMapping.__\u003C\u003EAnon5());
      EntityMapping.nameMap.put((object) "horizon", (object) new EntityMapping.__\u003C\u003EAnon5());
      EntityMapping.nameMap.put((object) "UnitEntity", (object) new EntityMapping.__\u003C\u003EAnon5());
      EntityMapping.nameMap.put((object) "unit-entity", (object) new EntityMapping.__\u003C\u003EAnon5());
      EntityMapping.nameMap.put((object) "antumbra", (object) new EntityMapping.__\u003C\u003EAnon5());
      EntityMapping.idMap[31] = (Prov) new EntityMapping.__\u003C\u003EAnon6();
      EntityMapping.nameMap.put((object) "gamma", (object) new EntityMapping.__\u003C\u003EAnon6());
      EntityMapping.nameMap.put((object) "UnitEntityLegacyGamma", (object) new EntityMapping.__\u003C\u003EAnon6());
      EntityMapping.nameMap.put((object) "unit-entity-legacy-gamma", (object) new EntityMapping.__\u003C\u003EAnon6());
      EntityMapping.idMap[4] = (Prov) new EntityMapping.__\u003C\u003EAnon7();
      EntityMapping.nameMap.put((object) "MechUnit", (object) new EntityMapping.__\u003C\u003EAnon7());
      EntityMapping.nameMap.put((object) "mech-unit", (object) new EntityMapping.__\u003C\u003EAnon7());
      EntityMapping.nameMap.put((object) "scepter", (object) new EntityMapping.__\u003C\u003EAnon7());
      EntityMapping.nameMap.put((object) "dagger", (object) new EntityMapping.__\u003C\u003EAnon7());
      EntityMapping.nameMap.put((object) "crawler", (object) new EntityMapping.__\u003C\u003EAnon7());
      EntityMapping.nameMap.put((object) "fortress", (object) new EntityMapping.__\u003C\u003EAnon7());
      EntityMapping.nameMap.put((object) "vela", (object) new EntityMapping.__\u003C\u003EAnon7());
      EntityMapping.nameMap.put((object) "mace", (object) new EntityMapping.__\u003C\u003EAnon7());
      EntityMapping.nameMap.put((object) "reign", (object) new EntityMapping.__\u003C\u003EAnon7());
      EntityMapping.idMap[5] = (Prov) new EntityMapping.__\u003C\u003EAnon8();
      EntityMapping.nameMap.put((object) "PayloadUnit", (object) new EntityMapping.__\u003C\u003EAnon8());
      EntityMapping.nameMap.put((object) "payload-unit", (object) new EntityMapping.__\u003C\u003EAnon8());
      EntityMapping.nameMap.put((object) "mega", (object) new EntityMapping.__\u003C\u003EAnon8());
      EntityMapping.idMap[6] = (Prov) new EntityMapping.__\u003C\u003EAnon9();
      EntityMapping.nameMap.put((object) "Building", (object) new EntityMapping.__\u003C\u003EAnon9());
      EntityMapping.nameMap.put((object) "building", (object) new EntityMapping.__\u003C\u003EAnon9());
      EntityMapping.idMap[7] = (Prov) new EntityMapping.__\u003C\u003EAnon10();
      EntityMapping.nameMap.put((object) "Bullet", (object) new EntityMapping.__\u003C\u003EAnon10());
      EntityMapping.nameMap.put((object) "bullet", (object) new EntityMapping.__\u003C\u003EAnon10());
      EntityMapping.idMap[8] = (Prov) new EntityMapping.__\u003C\u003EAnon11();
      EntityMapping.nameMap.put((object) "Decal", (object) new EntityMapping.__\u003C\u003EAnon11());
      EntityMapping.nameMap.put((object) "decal", (object) new EntityMapping.__\u003C\u003EAnon11());
      EntityMapping.idMap[9] = (Prov) new EntityMapping.__\u003C\u003EAnon12();
      EntityMapping.nameMap.put((object) "EffectState", (object) new EntityMapping.__\u003C\u003EAnon12());
      EntityMapping.nameMap.put((object) "effect-state", (object) new EntityMapping.__\u003C\u003EAnon12());
      EntityMapping.idMap[10] = (Prov) new EntityMapping.__\u003C\u003EAnon13();
      EntityMapping.nameMap.put((object) "Fire", (object) new EntityMapping.__\u003C\u003EAnon13());
      EntityMapping.nameMap.put((object) "fire", (object) new EntityMapping.__\u003C\u003EAnon13());
      EntityMapping.idMap[11] = (Prov) new EntityMapping.__\u003C\u003EAnon14();
      EntityMapping.nameMap.put((object) "LaunchCore", (object) new EntityMapping.__\u003C\u003EAnon14());
      EntityMapping.nameMap.put((object) "launch-core", (object) new EntityMapping.__\u003C\u003EAnon14());
      EntityMapping.idMap[12] = (Prov) new EntityMapping.__\u003C\u003EAnon15();
      EntityMapping.nameMap.put((object) "Player", (object) new EntityMapping.__\u003C\u003EAnon15());
      EntityMapping.nameMap.put((object) "player", (object) new EntityMapping.__\u003C\u003EAnon15());
      EntityMapping.idMap[28] = (Prov) new EntityMapping.__\u003C\u003EAnon16();
      EntityMapping.nameMap.put((object) "PosTeam", (object) new EntityMapping.__\u003C\u003EAnon16());
      EntityMapping.nameMap.put((object) "pos-team", (object) new EntityMapping.__\u003C\u003EAnon16());
      EntityMapping.idMap[13] = (Prov) new EntityMapping.__\u003C\u003EAnon17();
      EntityMapping.nameMap.put((object) "Puddle", (object) new EntityMapping.__\u003C\u003EAnon17());
      EntityMapping.nameMap.put((object) "puddle", (object) new EntityMapping.__\u003C\u003EAnon17());
      EntityMapping.idMap[14] = (Prov) new EntityMapping.__\u003C\u003EAnon18();
      EntityMapping.nameMap.put((object) "WeatherState", (object) new EntityMapping.__\u003C\u003EAnon18());
      EntityMapping.nameMap.put((object) "weather-state", (object) new EntityMapping.__\u003C\u003EAnon18());
      EntityMapping.idMap[15] = (Prov) new EntityMapping.__\u003C\u003EAnon19();
      EntityMapping.nameMap.put((object) "LaunchPayload", (object) new EntityMapping.__\u003C\u003EAnon19());
      EntityMapping.nameMap.put((object) "launch-payload", (object) new EntityMapping.__\u003C\u003EAnon19());
      EntityMapping.idMap[22] = (Prov) new EntityMapping.__\u003C\u003EAnon20();
      EntityMapping.nameMap.put((object) "ForceDraw", (object) new EntityMapping.__\u003C\u003EAnon20());
      EntityMapping.nameMap.put((object) "force-draw", (object) new EntityMapping.__\u003C\u003EAnon20());
      EntityMapping.idMap[16] = (Prov) new EntityMapping.__\u003C\u003EAnon21();
      EntityMapping.nameMap.put((object) "UnitEntityLegacyMono", (object) new EntityMapping.__\u003C\u003EAnon21());
      EntityMapping.nameMap.put((object) "unit-entity-legacy-mono", (object) new EntityMapping.__\u003C\u003EAnon21());
      EntityMapping.nameMap.put((object) "mono", (object) new EntityMapping.__\u003C\u003EAnon21());
      EntityMapping.idMap[17] = (Prov) new EntityMapping.__\u003C\u003EAnon22();
      EntityMapping.nameMap.put((object) "nova", (object) new EntityMapping.__\u003C\u003EAnon22());
      EntityMapping.nameMap.put((object) "MechUnitLegacyNova", (object) new EntityMapping.__\u003C\u003EAnon22());
      EntityMapping.nameMap.put((object) "mech-unit-legacy-nova", (object) new EntityMapping.__\u003C\u003EAnon22());
      EntityMapping.idMap[26] = (Prov) new EntityMapping.__\u003C\u003EAnon23();
      EntityMapping.nameMap.put((object) "AmmoDistributePayloadUnit", (object) new EntityMapping.__\u003C\u003EAnon23());
      EntityMapping.nameMap.put((object) "ammo-distribute-payload-unit", (object) new EntityMapping.__\u003C\u003EAnon23());
      EntityMapping.nameMap.put((object) "oct", (object) new EntityMapping.__\u003C\u003EAnon23());
      EntityMapping.idMap[18] = (Prov) new EntityMapping.__\u003C\u003EAnon24();
      EntityMapping.nameMap.put((object) "poly", (object) new EntityMapping.__\u003C\u003EAnon24());
      EntityMapping.nameMap.put((object) "UnitEntityLegacyPoly", (object) new EntityMapping.__\u003C\u003EAnon24());
      EntityMapping.nameMap.put((object) "unit-entity-legacy-poly", (object) new EntityMapping.__\u003C\u003EAnon24());
      EntityMapping.idMap[19] = (Prov) new EntityMapping.__\u003C\u003EAnon25();
      EntityMapping.nameMap.put((object) "MechUnitLegacyPulsar", (object) new EntityMapping.__\u003C\u003EAnon25());
      EntityMapping.nameMap.put((object) "mech-unit-legacy-pulsar", (object) new EntityMapping.__\u003C\u003EAnon25());
      EntityMapping.nameMap.put((object) "pulsar", (object) new EntityMapping.__\u003C\u003EAnon25());
      EntityMapping.idMap[23] = (Prov) new EntityMapping.__\u003C\u003EAnon26();
      EntityMapping.nameMap.put((object) "quad", (object) new EntityMapping.__\u003C\u003EAnon26());
      EntityMapping.nameMap.put((object) "PayloadUnitLegacyQuad", (object) new EntityMapping.__\u003C\u003EAnon26());
      EntityMapping.nameMap.put((object) "payload-unit-legacy-quad", (object) new EntityMapping.__\u003C\u003EAnon26());
      EntityMapping.idMap[32] = (Prov) new EntityMapping.__\u003C\u003EAnon27();
      EntityMapping.nameMap.put((object) "quasar", (object) new EntityMapping.__\u003C\u003EAnon27());
      EntityMapping.nameMap.put((object) "MechUnitLegacyQuasar", (object) new EntityMapping.__\u003C\u003EAnon27());
      EntityMapping.nameMap.put((object) "mech-unit-legacy-quasar", (object) new EntityMapping.__\u003C\u003EAnon27());
      EntityMapping.idMap[20] = (Prov) new EntityMapping.__\u003C\u003EAnon28();
      EntityMapping.nameMap.put((object) "UnitWaterMove", (object) new EntityMapping.__\u003C\u003EAnon28());
      EntityMapping.nameMap.put((object) "unit-water-move", (object) new EntityMapping.__\u003C\u003EAnon28());
      EntityMapping.nameMap.put((object) "omura", (object) new EntityMapping.__\u003C\u003EAnon28());
      EntityMapping.nameMap.put((object) "sei", (object) new EntityMapping.__\u003C\u003EAnon28());
      EntityMapping.nameMap.put((object) "bryde", (object) new EntityMapping.__\u003C\u003EAnon28());
      EntityMapping.nameMap.put((object) "minke", (object) new EntityMapping.__\u003C\u003EAnon28());
      EntityMapping.nameMap.put((object) "risso", (object) new EntityMapping.__\u003C\u003EAnon28());
      EntityMapping.idMap[21] = (Prov) new EntityMapping.__\u003C\u003EAnon29();
      EntityMapping.nameMap.put((object) "spiroct", (object) new EntityMapping.__\u003C\u003EAnon29());
      EntityMapping.nameMap.put((object) "LegsUnitLegacySpiroct", (object) new EntityMapping.__\u003C\u003EAnon29());
      EntityMapping.nameMap.put((object) "legs-unit-legacy-spiroct", (object) new EntityMapping.__\u003C\u003EAnon29());
      EntityMapping.idMap[33] = (Prov) new EntityMapping.__\u003C\u003EAnon30();
      EntityMapping.nameMap.put((object) "toxopid", (object) new EntityMapping.__\u003C\u003EAnon30());
      EntityMapping.nameMap.put((object) "LegsUnitLegacyToxopid", (object) new EntityMapping.__\u003C\u003EAnon30());
      EntityMapping.nameMap.put((object) "legs-unit-legacy-toxopid", (object) new EntityMapping.__\u003C\u003EAnon30());
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new UnitEntityLegacyAlpha();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new LegsUnitLegacyArkyid();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new UnitEntityLegacyBeta();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Prov
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get() => (object) new BlockUnitUnit();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Prov
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get() => (object) new LegsUnit();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Prov
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public object get() => (object) new UnitEntity();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Prov
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public object get() => (object) new UnitEntityLegacyGamma();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Prov
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public object get() => (object) new MechUnit();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Prov
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public object get() => (object) new PayloadUnit();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) new Building();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Prov
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public object get() => (object) new Bullet();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Prov
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public object get() => (object) new Decal();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public object get() => (object) new EffectState();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Prov
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public object get() => (object) new Fire();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Prov
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public object get() => (object) new LaunchCore();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Prov
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public object get() => (object) new Player();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Prov
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public object get() => (object) new PosTeam();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Prov
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public object get() => (object) new Puddle();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Prov
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public object get() => (object) new WeatherState();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Prov
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public object get() => (object) new LaunchPayload();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Prov
    {
      internal __\u003C\u003EAnon20()
      {
      }

      public object get() => (object) new ForceDraw();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Prov
    {
      internal __\u003C\u003EAnon21()
      {
      }

      public object get() => (object) new UnitEntityLegacyMono();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Prov
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public object get() => (object) new MechUnitLegacyNova();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Prov
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public object get() => (object) new AmmoDistributePayloadUnit();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Prov
    {
      internal __\u003C\u003EAnon24()
      {
      }

      public object get() => (object) new UnitEntityLegacyPoly();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Prov
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public object get() => (object) new MechUnitLegacyPulsar();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Prov
    {
      internal __\u003C\u003EAnon26()
      {
      }

      public object get() => (object) new PayloadUnitLegacyQuad();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Prov
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public object get() => (object) new MechUnitLegacyQuasar();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Prov
    {
      internal __\u003C\u003EAnon28()
      {
      }

      public object get() => (object) new UnitWaterMove();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Prov
    {
      internal __\u003C\u003EAnon29()
      {
      }

      public object get() => (object) new LegsUnitLegacySpiroct();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Prov
    {
      internal __\u003C\u003EAnon30()
      {
      }

      public object get() => (object) new LegsUnitLegacyToxopid();
    }
  }
}
