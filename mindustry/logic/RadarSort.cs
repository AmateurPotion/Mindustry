// Decompiled with JetBrains decompiler
// Type: mindustry.logic.RadarSort
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  [Signature("Ljava/lang/Enum<Lmindustry/logic/RadarSort;>;")]
  [Modifiers]
  [Serializable]
  public sealed class RadarSort : Enum
  {
    [Modifiers]
    internal static RadarSort __\u003C\u003Edistance;
    [Modifiers]
    internal static RadarSort __\u003C\u003Ehealth;
    [Modifiers]
    internal static RadarSort __\u003C\u003Eshield;
    [Modifiers]
    internal static RadarSort __\u003C\u003Earmor;
    [Modifiers]
    internal static RadarSort __\u003C\u003EmaxHealth;
    internal RadarSort.RadarSortFunc __\u003C\u003Efunc;
    internal static RadarSort[] __\u003C\u003Eall;
    [Modifiers]
    private static RadarSort[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RadarSort valueOf(string name) => (RadarSort) Enum.valueOf((Class) ClassLiteral<RadarSort>.Value, name);

    [Signature("(Lmindustry/logic/RadarSort$RadarSortFunc;)V")]
    [LineNumberTable(new byte[] {159, 159, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private RadarSort([In] string obj0, [In] int obj1, [In] RadarSort.RadarSortFunc obj2)
      : base(obj0, obj1)
    {
      RadarSort radarSort = this;
      this.__\u003C\u003Efunc = obj2;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RadarSort[] values() => (RadarSort[]) RadarSort.\u0024VALUES.Clone();

    [Modifiers]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024static\u00240([In] Position obj0, [In] Unit obj1) => -obj0.dst2((Position) obj1);

    [Modifiers]
    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024static\u00241([In] Position obj0, [In] Unit obj1) => obj1.health();

    [Modifiers]
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024static\u00242([In] Position obj0, [In] Unit obj1) => obj1.shield();

    [Modifiers]
    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024static\u00243([In] Position obj0, [In] Unit obj1) => obj1.armor();

    [Modifiers]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024static\u00244([In] Position obj0, [In] Unit obj1) => obj1.maxHealth();

    [LineNumberTable(new byte[] {159, 141, 173, 122, 122, 122, 122, 250, 59, 255, 20, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static RadarSort()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.RadarSort"))
        return;
      RadarSort.__\u003C\u003Edistance = new RadarSort(nameof (distance), 0, (RadarSort.RadarSortFunc) new RadarSort.__\u003C\u003EAnon0());
      RadarSort.__\u003C\u003Ehealth = new RadarSort(nameof (health), 1, (RadarSort.RadarSortFunc) new RadarSort.__\u003C\u003EAnon1());
      RadarSort.__\u003C\u003Eshield = new RadarSort(nameof (shield), 2, (RadarSort.RadarSortFunc) new RadarSort.__\u003C\u003EAnon2());
      RadarSort.__\u003C\u003Earmor = new RadarSort(nameof (armor), 3, (RadarSort.RadarSortFunc) new RadarSort.__\u003C\u003EAnon3());
      RadarSort.__\u003C\u003EmaxHealth = new RadarSort(nameof (maxHealth), 4, (RadarSort.RadarSortFunc) new RadarSort.__\u003C\u003EAnon4());
      RadarSort.\u0024VALUES = new RadarSort[5]
      {
        RadarSort.__\u003C\u003Edistance,
        RadarSort.__\u003C\u003Ehealth,
        RadarSort.__\u003C\u003Eshield,
        RadarSort.__\u003C\u003Earmor,
        RadarSort.__\u003C\u003EmaxHealth
      };
      RadarSort.__\u003C\u003Eall = RadarSort.values();
    }

    [Modifiers]
    public static RadarSort distance
    {
      [HideFromJava] get => RadarSort.__\u003C\u003Edistance;
    }

    [Modifiers]
    public static RadarSort health
    {
      [HideFromJava] get => RadarSort.__\u003C\u003Ehealth;
    }

    [Modifiers]
    public static RadarSort shield
    {
      [HideFromJava] get => RadarSort.__\u003C\u003Eshield;
    }

    [Modifiers]
    public static RadarSort armor
    {
      [HideFromJava] get => RadarSort.__\u003C\u003Earmor;
    }

    [Modifiers]
    public static RadarSort maxHealth
    {
      [HideFromJava] get => RadarSort.__\u003C\u003EmaxHealth;
    }

    [Modifiers]
    public RadarSort.RadarSortFunc func
    {
      [HideFromJava] get => this.__\u003C\u003Efunc;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efunc = value;
    }

    [Modifiers]
    public static RadarSort[] all
    {
      [HideFromJava] get => RadarSort.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      distance,
      health,
      shield,
      armor,
      maxHealth,
    }

    public interface RadarSortFunc
    {
      float get(Position p, Unit u);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : RadarSort.RadarSortFunc
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public float get([In] Position obj0, [In] Unit obj1) => RadarSort.lambda\u0024static\u00240(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : RadarSort.RadarSortFunc
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float get([In] Position obj0, [In] Unit obj1) => RadarSort.lambda\u0024static\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : RadarSort.RadarSortFunc
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public float get([In] Position obj0, [In] Unit obj1) => RadarSort.lambda\u0024static\u00242(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : RadarSort.RadarSortFunc
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public float get([In] Position obj0, [In] Unit obj1) => RadarSort.lambda\u0024static\u00243(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : RadarSort.RadarSortFunc
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public float get([In] Position obj0, [In] Unit obj1) => RadarSort.lambda\u0024static\u00244(obj0, obj1);
    }
  }
}
