// Decompiled with JetBrains decompiler
// Type: rhino.v8dtoa.CachedPowers
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.v8dtoa
{
  public class CachedPowers : Object
  {
    internal const double kD_1_LOG2_10 = 0.301029995663981;
    internal const int CACHED_POWERS_SPACING = 8;
    [Modifiers]
    internal static CachedPowers.CachedPower[] CACHED_POWERS;
    internal const int GRISU_CACHE_MAX_DISTANCE = 27;
    internal const int GRISU_CACHE_OFFSET = 308;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CachedPowers()
    {
    }

    [LineNumberTable(new byte[] {2, 99, 123, 115, 136, 108, 108, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int getCachedPower([In] int obj0, [In] int obj1, [In] int obj2, [In] DiyFp obj3)
    {
      int num = 64;
      int index = (308 + ByteCodeHelper.d2i(Math.ceil((double) (obj1 - obj0 + num - 1) * 0.301029995663981)) - 1) / 8 + 1;
      CachedPowers.CachedPower cachedPower = CachedPowers.CACHED_POWERS[index];
      obj3.setF(cachedPower.significand);
      obj3.setE((int) cachedPower.binaryExponent);
      if (!CachedPowers.\u0024assertionsDisabled && (obj1 > obj3.e() + obj0 || obj3.e() + obj0 > obj2))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return (int) cachedPower.decimalExponent;
    }

    [LineNumberTable(new byte[] {159, 134, 109, 245, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static CachedPowers()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.v8dtoa.CachedPowers"))
        return;
      CachedPowers.\u0024assertionsDisabled = !((Class) ClassLiteral<CachedPowers>.Value).desiredAssertionStatus();
      CachedPowers.CACHED_POWERS = new CachedPowers.CachedPower[82]
      {
        new CachedPowers.CachedPower(-1865951482774665761L, (short) -1087, (short) -308),
        new CachedPowers.CachedPower(-6093090917745768758L, (short) -1060, (short) -300),
        new CachedPowers.CachedPower(-38366372719436721L, (short) -1034, (short) -292),
        new CachedPowers.CachedPower(-4731433901725329908L, (short) -1007, (short) -284),
        new CachedPowers.CachedPower(-8228041688891786180L, (short) -980, (short) -276),
        new CachedPowers.CachedPower(-3219690930897053053L, (short) -954, (short) -268),
        new CachedPowers.CachedPower(-7101705404292871755L, (short) -927, (short) -260),
        new CachedPowers.CachedPower(-1541319077368263733L, (short) -901, (short) -252),
        new CachedPowers.CachedPower(-5851220927660403859L, (short) -874, (short) -244),
        new CachedPowers.CachedPower(-9062348037703676329L, (short) -847, (short) -236),
        new CachedPowers.CachedPower(-4462904269766699465L, (short) -821, (short) -228),
        new CachedPowers.CachedPower(-8027971522334779313L, (short) -794, (short) -220),
        new CachedPowers.CachedPower(-2921563150702462265L, (short) -768, (short) -212),
        new CachedPowers.CachedPower(-6879582898840692748L, (short) -741, (short) -204),
        new CachedPowers.CachedPower(-1210330751515841307L, (short) -715, (short) -196),
        new CachedPowers.CachedPower(-5604615407819967858L, (short) -688, (short) -188),
        new CachedPowers.CachedPower(-8878612607581929669L, (short) -661, (short) -180),
        new CachedPowers.CachedPower(-4189117143640191558L, (short) -635, (short) -172),
        new CachedPowers.CachedPower(-7823984217374209642L, (short) -608, (short) -164),
        new CachedPowers.CachedPower(-2617598379430861436L, (short) -582, (short) -156),
        new CachedPowers.CachedPower(-6653111496142234890L, (short) -555, (short) -148),
        new CachedPowers.CachedPower(-872862063775190746L, (short) -529, (short) -140),
        new CachedPowers.CachedPower(-5353181642124984136L, (short) -502, (short) -132),
        new CachedPowers.CachedPower(-8691279853972075893L, (short) -475, (short) -124),
        new CachedPowers.CachedPower(-3909969587797413805L, (short) -449, (short) -116),
        new CachedPowers.CachedPower(-7616003081050118571L, (short) -422, (short) -108),
        new CachedPowers.CachedPower(-2307682335666372931L, (short) -396, (short) -100),
        new CachedPowers.CachedPower(-6422206049907525489L, (short) -369, (short) -92),
        new CachedPowers.CachedPower(-528786136287117932L, (short) -343, (short) -84),
        new CachedPowers.CachedPower(-5096825099203863601L, (short) -316, (short) -76),
        new CachedPowers.CachedPower(-8500279345513818773L, (short) -289, (short) -68),
        new CachedPowers.CachedPower(-3625356651333078602L, (short) -263, (short) -60),
        new CachedPowers.CachedPower(-7403949918844649556L, (short) -236, (short) -52),
        new CachedPowers.CachedPower(-1991698500497491194L, (short) -210, (short) -44),
        new CachedPowers.CachedPower(-6186779746782440749L, (short) -183, (short) -36),
        new CachedPowers.CachedPower(-177973607073265138L, (short) -157, (short) -28),
        new CachedPowers.CachedPower(-4835449396872013077L, (short) -130, (short) -20),
        new CachedPowers.CachedPower(-8305539271883716404L, (short) -103, (short) -12),
        new CachedPowers.CachedPower(-3335171328526686932L, (short) -77, (short) -4),
        new CachedPowers.CachedPower(-7187745005283311616L, (short) -50, (short) 4),
        new CachedPowers.CachedPower(-1669528073709551616L, (short) -24, (short) 12),
        new CachedPowers.CachedPower(-5946744073709551616L, (short) 3, (short) 20),
        new CachedPowers.CachedPower(-9133518327554766460L, (short) 30, (short) 28),
        new CachedPowers.CachedPower(-4568956265895094861L, (short) 56, (short) 36),
        new CachedPowers.CachedPower(-8106986416796705680L, (short) 83, (short) 44),
        new CachedPowers.CachedPower(-3039304518611664792L, (short) 109, (short) 52),
        new CachedPowers.CachedPower(-6967307053960650171L, (short) 136, (short) 60),
        new CachedPowers.CachedPower(-1341049929119499481L, (short) 162, (short) 68),
        new CachedPowers.CachedPower(-5702008784649933400L, (short) 189, (short) 76),
        new CachedPowers.CachedPower(-8951176327949752869L, (short) 216, (short) 84),
        new CachedPowers.CachedPower(-4297245513042813542L, (short) 242, (short) 92),
        new CachedPowers.CachedPower(-7904546130479028392L, (short) 269, (short) 100),
        new CachedPowers.CachedPower(-2737644984756826646L, (short) 295, (short) 108),
        new CachedPowers.CachedPower(-6742553186979055798L, (short) 322, (short) 116),
        new CachedPowers.CachedPower(-1006140569036166267L, (short) 348, (short) 124),
        new CachedPowers.CachedPower(-5452481866653427593L, (short) 375, (short) 132),
        new CachedPowers.CachedPower(-8765264286586255934L, (short) 402, (short) 140),
        new CachedPowers.CachedPower(-4020214983419339459L, (short) 428, (short) 148),
        new CachedPowers.CachedPower(-7698142301602209613L, (short) 455, (short) 156),
        new CachedPowers.CachedPower(-2430079312244744221L, (short) 481, (short) 164),
        new CachedPowers.CachedPower(-6513398903789220827L, (short) 508, (short) 172),
        new CachedPowers.CachedPower(-664674077828931748L, (short) 534, (short) 180),
        new CachedPowers.CachedPower(-5198069505264599346L, (short) 561, (short) 188),
        new CachedPowers.CachedPower(-8575712306248138270L, (short) 588, (short) 196),
        new CachedPowers.CachedPower(-3737760522056206171L, (short) 614, (short) 204),
        new CachedPowers.CachedPower(-7487697328667536417L, (short) 641, (short) 212),
        new CachedPowers.CachedPower(-2116491865831296966L, (short) 667, (short) 220),
        new CachedPowers.CachedPower(-6279758049420528746L, (short) 694, (short) 228),
        new CachedPowers.CachedPower(-316522074587315140L, (short) 720, (short) 236),
        new CachedPowers.CachedPower(-4938676049251384304L, (short) 747, (short) 244),
        new CachedPowers.CachedPower(-8382449121214030822L, (short) 774, (short) 252),
        new CachedPowers.CachedPower(-3449775934753242068L, (short) 800, (short) 260),
        new CachedPowers.CachedPower(-7273132090830278359L, (short) 827, (short) 268),
        new CachedPowers.CachedPower(-1796764746270372707L, (short) 853, (short) 276),
        new CachedPowers.CachedPower(-6041542782089432023L, (short) 880, (short) 284),
        new CachedPowers.CachedPower(-9204148869281624187L, (short) 907, (short) 292),
        new CachedPowers.CachedPower(-4674203974643163859L, (short) 933, (short) 300),
        new CachedPowers.CachedPower(-8185402070463610993L, (short) 960, (short) 308),
        new CachedPowers.CachedPower(-3156152948152813503L, (short) 986, (short) 316),
        new CachedPowers.CachedPower(-7054365918152680535L, (short) 1013, (short) 324),
        new CachedPowers.CachedPower(-1470777745987373095L, (short) 1039, (short) 332),
        new CachedPowers.CachedPower(-5798663540173640085L, (short) 1066, (short) 340)
      };
    }

    internal class CachedPower : Object
    {
      internal long significand;
      internal short binaryExponent;
      internal short decimalExponent;

      [LineNumberTable(new byte[] {159, 132, 164, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal CachedPower([In] long obj0, [In] short obj1, [In] short obj2)
      {
        int num1 = (int) obj1;
        int num2 = (int) obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        CachedPowers.CachedPower cachedPower = this;
        this.significand = obj0;
        this.binaryExponent = (short) num1;
        this.decimalExponent = (short) num2;
      }
    }
  }
}
