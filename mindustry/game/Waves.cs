// Decompiled with JetBrains decompiler
// Type: mindustry.game.Waves
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  public class Waves : Object
  {
    public const int waveVersion = 5;
    [Signature("Larc/struct/Seq<Lmindustry/game/SpawnGroup;>;")]
    private Seq spawns;

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Waves()
    {
    }

    [Signature("()Larc/struct/Seq<Lmindustry/game/SpawnGroup;>;")]
    [LineNumberTable(new byte[] {159, 160, 117, 255, 161, 78, 160, 236})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq get()
    {
      if (this.spawns == null && UnitTypes.dagger != null)
        this.spawns = Seq.with((object[]) new SpawnGroup[28]
        {
          (SpawnGroup) new Waves.\u0031(this, UnitTypes.dagger),
          (SpawnGroup) new Waves.\u0032(this, UnitTypes.crawler),
          (SpawnGroup) new Waves.\u0033(this, UnitTypes.flare),
          (SpawnGroup) new Waves.\u0034(this, UnitTypes.dagger),
          (SpawnGroup) new Waves.\u0035(this, UnitTypes.pulsar),
          (SpawnGroup) new Waves.\u0036(this, UnitTypes.mace),
          (SpawnGroup) new Waves.\u0037(this, UnitTypes.dagger),
          (SpawnGroup) new Waves.\u0038(this, UnitTypes.mace),
          (SpawnGroup) new Waves.\u0039(this, UnitTypes.spiroct),
          (SpawnGroup) new Waves.\u00310(this, UnitTypes.pulsar),
          (SpawnGroup) new Waves.\u00311(this, UnitTypes.flare),
          (SpawnGroup) new Waves.\u00312(this, UnitTypes.quasar),
          (SpawnGroup) new Waves.\u00313(this, UnitTypes.pulsar),
          (SpawnGroup) new Waves.\u00314(this, UnitTypes.fortress),
          (SpawnGroup) new Waves.\u00315(this, UnitTypes.nova),
          (SpawnGroup) new Waves.\u00316(this, UnitTypes.dagger),
          (SpawnGroup) new Waves.\u00317(this, UnitTypes.horizon),
          (SpawnGroup) new Waves.\u00318(this, UnitTypes.flare),
          (SpawnGroup) new Waves.\u00319(this, UnitTypes.zenith),
          (SpawnGroup) new Waves.\u00320(this, UnitTypes.nova),
          (SpawnGroup) new Waves.\u00321(this, UnitTypes.atrax),
          (SpawnGroup) new Waves.\u00322(this, UnitTypes.scepter),
          (SpawnGroup) new Waves.\u00323(this, UnitTypes.reign),
          (SpawnGroup) new Waves.\u00324(this, UnitTypes.antumbra),
          (SpawnGroup) new Waves.\u00325(this, UnitTypes.vela),
          (SpawnGroup) new Waves.\u00326(this, UnitTypes.corvus),
          (SpawnGroup) new Waves.\u00327(this, UnitTypes.horizon),
          (SpawnGroup) new Waves.\u00328(this, UnitTypes.toxopid)
        });
      return this.spawns == null ? new Seq() : this.spawns;
    }

    [Signature("(F)Larc/struct/Seq<Lmindustry/game/SpawnGroup;>;")]
    [LineNumberTable(260)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq generate(float difficulty) => Waves.generate(Mathf.pow(difficulty, 1.12f), new Rand(), false);

    [Signature("(FLarc/math/Rand;Z)Larc/struct/Seq<Lmindustry/game/SpawnGroup;>;")]
    [LineNumberTable(new byte[] {159, 76, 66, 223, 160, 92, 255, 33, 70, 166, 134, 121, 159, 17, 248, 116, 136, 139, 101, 105, 191, 12, 127, 7, 159, 7, 180, 255, 0, 76, 255, 1, 75, 173, 255, 0, 76, 255, 0, 76, 113, 152, 105, 106, 18, 232, 76, 157, 127, 0, 112, 112, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq generate(float difficulty, Rand rand, bool attack)
    {
      int num1 = attack ? 1 : 0;
      UnitType[][] unitTypeArray = new UnitType[4][]
      {
        new UnitType[5]
        {
          UnitTypes.dagger,
          UnitTypes.mace,
          UnitTypes.fortress,
          UnitTypes.scepter,
          UnitTypes.reign
        },
        new UnitType[5]
        {
          UnitTypes.nova,
          UnitTypes.pulsar,
          UnitTypes.quasar,
          UnitTypes.vela,
          UnitTypes.corvus
        },
        new UnitType[5]
        {
          UnitTypes.crawler,
          UnitTypes.atrax,
          UnitTypes.spiroct,
          UnitTypes.arkyid,
          UnitTypes.toxopid
        },
        new UnitType[5]
        {
          UnitTypes.flare,
          UnitTypes.horizon,
          UnitTypes.zenith,
          !rand.chance(0.5) ? UnitTypes.antumbra : UnitTypes.quad,
          !rand.chance(0.1) ? UnitTypes.eclipse : UnitTypes.quad
        }
      };
      Seq seq = new Seq();
      int num2 = 150;
      float num3 = 30f;
      float num4 = 20f + difficulty * 30f;
      float[] numArray = new float[5]{ 1f, 2f, 3f, 4f, 5f };
      Intc ntc = (Intc) new Waves.__\u003C\u003EAnon0(unitTypeArray, num2, rand, difficulty, num3, num4, seq, numArray);
      ntc.get(0);
      for (int i = 5 + rand.random(5); i <= num2; i += ByteCodeHelper.f2i((float) rand.random(15, 30) * Mathf.lerp(1f, 0.5f, difficulty)))
        ntc.get(i);
      int num5 = ByteCodeHelper.f2i((float) rand.random(50, 70) * Mathf.lerp(1f, 0.7f, difficulty));
      int num6 = ByteCodeHelper.f2i((float) rand.random(25, 40) * Mathf.lerp(1f, 0.6f, difficulty));
      int index1 = (double) difficulty >= 0.6 ? 4 : 3;
      seq.add((object) new Waves.\u00331(((UnitType[]) Structs.random((object[]) unitTypeArray))[index1], num5, num6, num4));
      seq.add((object) new Waves.\u00332(((UnitType[]) Structs.random((object[]) unitTypeArray))[index1], num5, rand, num6, num4));
      int num7 = 120 + rand.random(30);
      seq.add((object) new Waves.\u00333(((UnitType[]) Structs.random((object[]) unitTypeArray))[index1], num7, num6, num4));
      seq.add((object) new Waves.\u00334(((UnitType[]) Structs.random((object[]) unitTypeArray))[index1], num7, num6, num4));
      if (num1 != 0 && (double) difficulty >= 0.5)
      {
        int num8 = Mathf.random(1, 3 + ByteCodeHelper.f2i(difficulty * 2f));
        for (int index2 = 0; index2 < num8; ++index2)
        {
          int num9 = Mathf.random(3, 20);
          seq.add((object) new Waves.\u00335(UnitTypes.mega, num9));
        }
      }
      int num10 = Math.max(ByteCodeHelper.f2i(difficulty * 14f - 5f), 0);
      Iterator iterator = seq.iterator();
      while (iterator.hasNext())
      {
        SpawnGroup spawnGroup = (SpawnGroup) iterator.next();
        spawnGroup.begin -= num10;
        spawnGroup.end -= num10;
      }
      return seq;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 170, 108, 130, 106, 98, 159, 8, 121, 113, 163, 255, 13, 76, 255, 6, 75, 103, 127, 4, 196, 168, 113, 140, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024generate\u00240(
      [In] UnitType[][] obj0,
      [In] int obj1,
      [In] Rand obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5,
      [In] Seq obj6,
      [In] float[] obj7,
      [In] int obj8)
    {
      UnitType[] unitTypeArray = (UnitType[]) Structs.random((object[]) obj0);
      int num1 = 0;
      int num2 = obj8;
      while (num2 < obj1)
      {
        int num3 = num2;
        int num4 = obj2.random(8, 16) + ByteCodeHelper.f2i(Mathf.lerp(5f, 0.0f, obj3)) + num1 * 4;
        float num5 = Math.max(((float) num2 - obj4) * obj5, 0.0f);
        int num6 = obj8 != 0 ? obj2.random(1, 2) : 1;
        int num7 = num1;
        obj6.add((object) new Waves.\u00329(unitTypeArray[Math.min(num1, unitTypeArray.Length - 1)], num3, obj8, obj7, num7, num4, obj1, obj3, obj2, num5, obj5, num6));
        obj6.add((object) new Waves.\u00330(unitTypeArray[Math.min(num1, unitTypeArray.Length - 1)], obj7, num7, num3, num4, obj2, num5, obj5));
        num2 += num4 + 1;
        if (num1 < 3 || obj2.chance(0.05) && (double) obj3 > 0.8)
          ++num1;
        num1 = Math.min(num1, 3);
        if (obj2.chance(0.3))
          unitTypeArray = (UnitType[]) Structs.random((object[]) obj0);
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0031 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {159, 162, 112, 104, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u0031 obj = this;
        this.end = 10;
        this.unitScaling = 2f;
        this.max = 30;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00310 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {39, 112, 104, 103, 107, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00310 obj = this;
        this.begin = 120;
        this.spacing = 2;
        this.unitScaling = 3f;
        this.unitAmount = 5;
        this.effect = StatusEffects.overdrive;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00311 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {47, 112, 104, 107, 103, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00311([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00311 obj = this;
        this.begin = 16;
        this.unitScaling = 1f;
        this.spacing = 2;
        this.shieldScaling = 20f;
        this.max = 20;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00312 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {55, 112, 104, 103, 103, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00312([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00312 obj = this;
        this.begin = 82;
        this.spacing = 3;
        this.unitAmount = 4;
        this.unitScaling = 3f;
        this.shieldScaling = 30f;
        this.effect = StatusEffects.overdrive;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00313 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {64, 112, 104, 103, 103, 107, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00313([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00313 obj = this;
        this.begin = 41;
        this.spacing = 5;
        this.unitAmount = 1;
        this.unitScaling = 3f;
        this.effect = StatusEffects.shielded;
        this.max = 25;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00314 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {73, 112, 104, 103, 103, 107, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00314([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00314 obj = this;
        this.begin = 40;
        this.spacing = 5;
        this.unitAmount = 2;
        this.unitScaling = 2f;
        this.max = 20;
        this.shieldScaling = 30f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00315 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {82, 112, 104, 103, 103, 107, 119, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00315([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00315 obj = this;
        this.begin = 35;
        this.spacing = 3;
        this.unitAmount = 4;
        this.effect = StatusEffects.overdrive;
        ItemStack.__\u003Cclinit\u003E();
        this.items = new ItemStack(Items.blastCompound, 60);
        this.end = 60;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00316 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {91, 112, 104, 103, 103, 107, 119, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00316([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00316 obj = this;
        this.begin = 42;
        this.spacing = 3;
        this.unitAmount = 4;
        this.effect = StatusEffects.overdrive;
        ItemStack.__\u003Cclinit\u003E();
        this.items = new ItemStack(Items.pyratite, 100);
        this.end = 130;
        this.max = 30;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00317 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {101, 112, 104, 103, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00317([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00317 obj = this;
        this.begin = 40;
        this.unitAmount = 2;
        this.spacing = 2;
        this.unitScaling = 2f;
        this.shieldScaling = 20f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00318 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {109, 112, 104, 103, 107, 103, 107, 107, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00318([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00318 obj = this;
        this.begin = 50;
        this.unitAmount = 4;
        this.unitScaling = 3f;
        this.spacing = 5;
        this.shields = 100f;
        this.shieldScaling = 10f;
        this.effect = StatusEffects.overdrive;
        this.max = 20;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00319 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {120, 112, 104, 103, 107, 103, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00319([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00319 obj = this;
        this.begin = 50;
        this.unitAmount = 2;
        this.unitScaling = 3f;
        this.spacing = 5;
        this.max = 16;
        this.shieldScaling = 30f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0032 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {159, 168, 112, 103, 104, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u0032 obj = this;
        this.begin = 4;
        this.end = 13;
        this.unitAmount = 2;
        this.unitScaling = 1.5f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00320 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {160, 65, 112, 104, 103, 107, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00320([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00320 obj = this;
        this.begin = 53;
        this.unitAmount = 2;
        this.unitScaling = 3f;
        this.spacing = 4;
        this.shieldScaling = 30f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00321 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {160, 73, 112, 104, 103, 107, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00321([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00321 obj = this;
        this.begin = 31;
        this.unitAmount = 4;
        this.unitScaling = 1f;
        this.spacing = 3;
        this.shieldScaling = 10f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00322 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {160, 81, 112, 104, 103, 107, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00322([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00322 obj = this;
        this.begin = 41;
        this.unitAmount = 1;
        this.unitScaling = 1f;
        this.spacing = 30;
        this.shieldScaling = 30f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00323 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {160, 89, 112, 104, 103, 107, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00323([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00323 obj = this;
        this.begin = 81;
        this.unitAmount = 1;
        this.unitScaling = 1f;
        this.spacing = 40;
        this.shieldScaling = 30f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00324 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {160, 97, 112, 104, 103, 107, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00324([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00324 obj = this;
        this.begin = 120;
        this.unitAmount = 1;
        this.unitScaling = 1f;
        this.spacing = 40;
        this.shieldScaling = 30f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00325 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {160, 105, 112, 104, 103, 107, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00325([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00325 obj = this;
        this.begin = 100;
        this.unitAmount = 1;
        this.unitScaling = 1f;
        this.spacing = 30;
        this.shieldScaling = 30f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00326 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {160, 113, 112, 107, 103, 107, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00326([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00326 obj = this;
        this.begin = 145;
        this.unitAmount = 1;
        this.unitScaling = 1f;
        this.spacing = 35;
        this.shieldScaling = 30f;
        this.shields = 100f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00327 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {160, 122, 112, 104, 103, 107, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00327([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00327 obj = this;
        this.begin = 90;
        this.unitAmount = 2;
        this.unitScaling = 3f;
        this.spacing = 4;
        this.shields = 40f;
        this.shieldScaling = 30f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00328 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {160, 131, 112, 107, 103, 107, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00328([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u00328 obj = this;
        this.begin = 210;
        this.unitAmount = 1;
        this.unitScaling = 1f;
        this.spacing = 35;
        this.shields = 1000f;
        this.shieldScaling = 35f;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "generate", "(FLarc.math.Rand;Z)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00329 : SpawnGroup
    {
      [Modifiers]
      internal int val\u0024f;
      [Modifiers]
      internal int val\u0024start;
      [Modifiers]
      internal float[] val\u0024scaling;
      [Modifiers]
      internal int val\u0024ctier;
      [Modifiers]
      internal int val\u0024next;
      [Modifiers]
      internal int val\u0024cap;
      [Modifiers]
      internal float val\u0024difficulty;
      [Modifiers]
      internal Rand val\u0024rand;
      [Modifiers]
      internal float val\u0024shieldAmount;
      [Modifiers]
      internal float val\u0024shieldsPerWave;
      [Modifiers]
      internal int val\u0024space;

      [LineNumberTable(new byte[] {160, 182, 127, 67, 127, 20, 108, 127, 16, 104, 127, 49, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00329(
        [In] UnitType obj0,
        [In] int obj1,
        [In] int obj2,
        [In] float[] obj3,
        [In] int obj4,
        [In] int obj5,
        [In] int obj6,
        [In] float obj7,
        [In] Rand obj8,
        [In] float obj9,
        [In] float obj10,
        [In] int obj11)
      {
        this.val\u0024f = obj1;
        this.val\u0024start = obj2;
        this.val\u0024scaling = obj3;
        this.val\u0024ctier = obj4;
        this.val\u0024next = obj5;
        this.val\u0024cap = obj6;
        this.val\u0024difficulty = obj7;
        this.val\u0024rand = obj8;
        this.val\u0024shieldAmount = obj9;
        this.val\u0024shieldsPerWave = obj10;
        this.val\u0024space = obj11;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0);
        Waves.\u00329 obj = this;
        int num1;
        if (this.val\u0024f == this.val\u0024start)
        {
          num1 = 1;
        }
        else
        {
          int num2 = 6;
          int num3 = ByteCodeHelper.f2i(this.val\u0024scaling[this.val\u0024ctier]);
          num1 = num3 != -1 ? num2 / num3 : -num2;
        }
        this.unitAmount = num1;
        this.begin = this.val\u0024f;
        this.end = this.val\u0024f + this.val\u0024next < this.val\u0024cap ? this.val\u0024f + this.val\u0024next : int.MaxValue;
        this.max = 13;
        this.unitScaling = ((double) this.val\u0024difficulty >= 0.400000005960464 ? this.val\u0024rand.random(1f, 4f) : this.val\u0024rand.random(2.5f, 5f)) * this.val\u0024scaling[this.val\u0024ctier];
        this.shields = this.val\u0024shieldAmount;
        this.shieldScaling = this.val\u0024shieldsPerWave;
        this.spacing = this.val\u0024space;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0033 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {159, 175, 112, 104, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u0033 obj = this;
        this.begin = 12;
        this.end = 16;
        this.unitScaling = 1f;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "generate", "(FLarc.math.Rand;Z)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00330 : SpawnGroup
    {
      [Modifiers]
      internal float[] val\u0024scaling;
      [Modifiers]
      internal int val\u0024ctier;
      [Modifiers]
      internal int val\u0024f;
      [Modifiers]
      internal int val\u0024next;
      [Modifiers]
      internal Rand val\u0024rand;
      [Modifiers]
      internal float val\u0024shieldAmount;
      [Modifiers]
      internal float val\u0024shieldsPerWave;

      [LineNumberTable(new byte[] {160, 194, 127, 34, 127, 3, 117, 127, 3, 103, 124, 115, 115, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00330(
        [In] UnitType obj0,
        [In] float[] obj1,
        [In] int obj2,
        [In] int obj3,
        [In] int obj4,
        [In] Rand obj5,
        [In] float obj6,
        [In] float obj7)
      {
        this.val\u0024scaling = obj1;
        this.val\u0024ctier = obj2;
        this.val\u0024f = obj3;
        this.val\u0024next = obj4;
        this.val\u0024rand = obj5;
        this.val\u0024shieldAmount = obj6;
        this.val\u0024shieldsPerWave = obj7;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0);
        Waves.\u00330 obj = this;
        int num1 = 3;
        int num2 = ByteCodeHelper.f2i(this.val\u0024scaling[this.val\u0024ctier]);
        this.unitAmount = num2 != -1 ? num1 / num2 : -num1;
        this.begin = this.val\u0024f + this.val\u0024next - 1;
        this.end = this.val\u0024f + this.val\u0024next + this.val\u0024rand.random(6, 10);
        this.max = 6;
        this.unitScaling = this.val\u0024rand.random(2f, 4f);
        this.spacing = this.val\u0024rand.random(2, 4);
        this.shields = this.val\u0024shieldAmount / 2f;
        this.shieldScaling = this.val\u0024shieldsPerWave;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "generate", "(FLarc.math.Rand;Z)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00331 : SpawnGroup
    {
      [Modifiers]
      internal int val\u0024bossWave;
      [Modifiers]
      internal int val\u0024bossSpacing;
      [Modifiers]
      internal float val\u0024shieldsPerWave;

      [LineNumberTable(new byte[] {160, 235, 127, 1, 103, 108, 108, 107, 104, 109, 108, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00331([In] UnitType obj0, [In] int obj1, [In] int obj2, [In] float obj3)
      {
        this.val\u0024bossWave = obj1;
        this.val\u0024bossSpacing = obj2;
        this.val\u0024shieldsPerWave = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0);
        Waves.\u00331 obj = this;
        this.unitAmount = 1;
        this.begin = this.val\u0024bossWave;
        this.spacing = this.val\u0024bossSpacing;
        this.end = int.MaxValue;
        this.max = 16;
        this.unitScaling = (float) this.val\u0024bossSpacing;
        this.shieldScaling = this.val\u0024shieldsPerWave;
        this.effect = StatusEffects.boss;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "generate", "(FLarc.math.Rand;Z)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00332 : SpawnGroup
    {
      [Modifiers]
      internal int val\u0024bossWave;
      [Modifiers]
      internal Rand val\u0024rand;
      [Modifiers]
      internal int val\u0024bossSpacing;
      [Modifiers]
      internal float val\u0024shieldsPerWave;

      [LineNumberTable(new byte[] {160, 247, 127, 9, 103, 127, 2, 108, 107, 104, 109, 108, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00332([In] UnitType obj0, [In] int obj1, [In] Rand obj2, [In] int obj3, [In] float obj4)
      {
        this.val\u0024bossWave = obj1;
        this.val\u0024rand = obj2;
        this.val\u0024bossSpacing = obj3;
        this.val\u0024shieldsPerWave = obj4;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0);
        Waves.\u00332 obj = this;
        this.unitAmount = 1;
        this.begin = this.val\u0024bossWave + this.val\u0024rand.random(3, 5) * this.val\u0024bossSpacing;
        this.spacing = this.val\u0024bossSpacing;
        this.end = int.MaxValue;
        this.max = 16;
        this.unitScaling = (float) this.val\u0024bossSpacing;
        this.shieldScaling = this.val\u0024shieldsPerWave;
        this.effect = StatusEffects.boss;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "generate", "(FLarc.math.Rand;Z)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00333 : SpawnGroup
    {
      [Modifiers]
      internal int val\u0024finalBossStart;
      [Modifiers]
      internal int val\u0024bossSpacing;
      [Modifiers]
      internal float val\u0024shieldsPerWave;

      [LineNumberTable(new byte[] {161, 5, 127, 1, 103, 108, 110, 107, 109, 107, 115, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00333([In] UnitType obj0, [In] int obj1, [In] int obj2, [In] float obj3)
      {
        this.val\u0024finalBossStart = obj1;
        this.val\u0024bossSpacing = obj2;
        this.val\u0024shieldsPerWave = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0);
        Waves.\u00333 obj = this;
        this.unitAmount = 1;
        this.begin = this.val\u0024finalBossStart;
        this.spacing = this.val\u0024bossSpacing / 2;
        this.end = int.MaxValue;
        this.unitScaling = (float) this.val\u0024bossSpacing;
        this.shields = 500f;
        this.shieldScaling = this.val\u0024shieldsPerWave * 4f;
        this.effect = StatusEffects.boss;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "generate", "(FLarc.math.Rand;Z)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00334 : SpawnGroup
    {
      [Modifiers]
      internal int val\u0024finalBossStart;
      [Modifiers]
      internal int val\u0024bossSpacing;
      [Modifiers]
      internal float val\u0024shieldsPerWave;

      [LineNumberTable(new byte[] {161, 17, 127, 1, 103, 111, 110, 107, 109, 107, 115, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00334([In] UnitType obj0, [In] int obj1, [In] int obj2, [In] float obj3)
      {
        this.val\u0024finalBossStart = obj1;
        this.val\u0024bossSpacing = obj2;
        this.val\u0024shieldsPerWave = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0);
        Waves.\u00334 obj = this;
        this.unitAmount = 1;
        this.begin = this.val\u0024finalBossStart + 15;
        this.spacing = this.val\u0024bossSpacing / 2;
        this.end = int.MaxValue;
        this.unitScaling = (float) this.val\u0024bossSpacing;
        this.shields = 500f;
        this.shieldScaling = this.val\u0024shieldsPerWave * 4f;
        this.effect = StatusEffects.boss;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "generate", "(FLarc.math.Rand;Z)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u00335 : SpawnGroup
    {
      [Modifiers]
      internal int val\u0024wave;

      [LineNumberTable(new byte[] {161, 34, 112, 103, 108, 108, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00335([In] UnitType obj0, [In] int obj1)
      {
        this.val\u0024wave = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0);
        Waves.\u00335 obj = this;
        this.unitAmount = 1;
        this.begin = this.val\u0024wave;
        this.end = this.val\u0024wave;
        this.max = 16;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0034 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {159, 181, 112, 104, 107, 103, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u0034 obj = this;
        this.begin = 11;
        this.unitScaling = 1.7f;
        this.spacing = 2;
        this.max = 4;
        this.shieldScaling = 25f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0035 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {159, 189, 112, 104, 103, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u0035 obj = this;
        this.begin = 13;
        this.spacing = 3;
        this.unitScaling = 0.5f;
        this.max = 25;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0036 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {4, 112, 103, 103, 139, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u0036 obj = this;
        this.begin = 7;
        this.spacing = 3;
        this.unitScaling = 2f;
        this.end = 30;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0037 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {12, 112, 104, 107, 103, 103, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u0037 obj = this;
        this.begin = 12;
        this.unitScaling = 1f;
        this.unitAmount = 4;
        this.spacing = 2;
        this.shieldScaling = 20f;
        this.max = 14;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0038 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {21, 112, 104, 103, 107, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u0038 obj = this;
        this.begin = 28;
        this.spacing = 3;
        this.unitScaling = 1f;
        this.end = 40;
        this.shieldScaling = 20f;
      }
    }

    [EnclosingMethod(null, "get", "()Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0039 : SpawnGroup
    {
      [Modifiers]
      internal Waves this\u00240;

      [LineNumberTable(new byte[] {29, 112, 104, 103, 107, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039([In] Waves obj0, [In] UnitType obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Waves.\u0039 obj = this;
        this.begin = 45;
        this.spacing = 3;
        this.unitScaling = 1f;
        this.max = 10;
        this.shieldScaling = 30f;
        this.shields = 100f;
        this.effect = StatusEffects.overdrive;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Intc
    {
      private readonly UnitType[][] arg\u00241;
      private readonly int arg\u00242;
      private readonly Rand arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;
      private readonly float arg\u00246;
      private readonly Seq arg\u00247;
      private readonly float[] arg\u00248;

      internal __\u003C\u003EAnon0(
        [In] UnitType[][] obj0,
        [In] int obj1,
        [In] Rand obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5,
        [In] Seq obj6,
        [In] float[] obj7)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
        this.arg\u00248 = obj7;
      }

      public void get([In] int obj0) => Waves.lambda\u0024generate\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248, obj0);
    }
  }
}
