// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LogicOp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.util;
using arc.util.noise;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  [Signature("Ljava/lang/Enum<Lmindustry/logic/LogicOp;>;")]
  [Modifiers]
  [Serializable]
  public sealed class LogicOp : Enum
  {
    [Modifiers]
    internal static LogicOp __\u003C\u003Eadd;
    [Modifiers]
    internal static LogicOp __\u003C\u003Esub;
    [Modifiers]
    internal static LogicOp __\u003C\u003Emul;
    [Modifiers]
    internal static LogicOp __\u003C\u003Ediv;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eidiv;
    [Modifiers]
    internal static LogicOp __\u003C\u003Emod;
    [Modifiers]
    internal static LogicOp __\u003C\u003Epow;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eequal;
    [Modifiers]
    internal static LogicOp __\u003C\u003EnotEqual;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eland;
    [Modifiers]
    internal static LogicOp __\u003C\u003ElessThan;
    [Modifiers]
    internal static LogicOp __\u003C\u003ElessThanEq;
    [Modifiers]
    internal static LogicOp __\u003C\u003EgreaterThan;
    [Modifiers]
    internal static LogicOp __\u003C\u003EgreaterThanEq;
    [Modifiers]
    internal static LogicOp __\u003C\u003EstrictEqual;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eshl;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eshr;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eor;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eand;
    [Modifiers]
    internal static LogicOp __\u003C\u003Exor;
    [Modifiers]
    internal static LogicOp __\u003C\u003Enot;
    [Modifiers]
    internal static LogicOp __\u003C\u003Emax;
    [Modifiers]
    internal static LogicOp __\u003C\u003Emin;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eangle;
    [Modifiers]
    internal static LogicOp __\u003C\u003Elen;
    [Modifiers]
    internal static LogicOp __\u003C\u003Enoise;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eabs;
    [Modifiers]
    internal static LogicOp __\u003C\u003Elog;
    [Modifiers]
    internal static LogicOp __\u003C\u003Elog10;
    [Modifiers]
    internal static LogicOp __\u003C\u003Esin;
    [Modifiers]
    internal static LogicOp __\u003C\u003Ecos;
    [Modifiers]
    internal static LogicOp __\u003C\u003Etan;
    [Modifiers]
    internal static LogicOp __\u003C\u003Efloor;
    [Modifiers]
    internal static LogicOp __\u003C\u003Eceil;
    [Modifiers]
    internal static LogicOp __\u003C\u003Esqrt;
    [Modifiers]
    internal static LogicOp __\u003C\u003Erand;
    internal static LogicOp[] __\u003C\u003Eall;
    internal LogicOp.OpObjLambda2 __\u003C\u003EobjFunction2;
    internal LogicOp.OpLambda2 __\u003C\u003Efunction2;
    internal LogicOp.OpLambda1 __\u003C\u003Efunction1;
    internal bool __\u003C\u003Eunary;
    internal bool __\u003C\u003Efunc;
    internal string __\u003C\u003Esymbol;
    [Modifiers]
    private static LogicOp[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LogicOp valueOf(string name) => (LogicOp) Enum.valueOf((Class) ClassLiteral<LogicOp>.Value, name);

    [Signature("(Ljava/lang/String;Lmindustry/logic/LogicOp$OpLambda2;Lmindustry/logic/LogicOp$OpObjLambda2;)V")]
    [LineNumberTable(new byte[] {18, 106, 103, 104, 103, 103, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LogicOp(
      [In] string obj0,
      [In] int obj1,
      [In] string obj2,
      [In] LogicOp.OpLambda2 obj3,
      [In] LogicOp.OpObjLambda2 obj4)
      : base(obj0, obj1)
    {
      LogicOp logicOp = this;
      this.__\u003C\u003Esymbol = obj2;
      this.__\u003C\u003Efunction2 = obj3;
      this.__\u003C\u003Efunction1 = (LogicOp.OpLambda1) null;
      this.__\u003C\u003Eunary = false;
      this.__\u003C\u003EobjFunction2 = obj4;
      this.__\u003C\u003Efunc = false;
      GC.KeepAlive((object) this);
    }

    [Signature("(Ljava/lang/String;Lmindustry/logic/LogicOp$OpLambda2;)V")]
    [LineNumberTable(new byte[] {6, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LogicOp([In] string obj0, [In] int obj1, [In] string obj2, [In] LogicOp.OpLambda2 obj3)
      : this(obj0, obj1, obj2, obj3, (LogicOp.OpObjLambda2) null)
    {
      GC.KeepAlive((object) this);
    }

    [Signature("(Ljava/lang/String;Lmindustry/logic/LogicOp$OpLambda1;)V")]
    [LineNumberTable(new byte[] {27, 106, 103, 104, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LogicOp([In] string obj0, [In] int obj1, [In] string obj2, [In] LogicOp.OpLambda1 obj3)
      : base(obj0, obj1)
    {
      LogicOp logicOp = this;
      this.__\u003C\u003Esymbol = obj2;
      this.__\u003C\u003Efunction1 = obj3;
      this.__\u003C\u003Efunction2 = (LogicOp.OpLambda2) null;
      this.__\u003C\u003Eunary = true;
      this.__\u003C\u003EobjFunction2 = (LogicOp.OpObjLambda2) null;
      this.__\u003C\u003Efunc = false;
      GC.KeepAlive((object) this);
    }

    [Signature("(Ljava/lang/String;ZLmindustry/logic/LogicOp$OpLambda2;)V")]
    [LineNumberTable(new byte[] {159, 128, 163, 106, 103, 104, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LogicOp([In] string obj0, [In] int obj1, [In] string obj2, [In] bool obj3, [In] LogicOp.OpLambda2 obj4)
    {
      int num = obj3 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(obj0, obj1);
      LogicOp logicOp = this;
      this.__\u003C\u003Esymbol = obj2;
      this.__\u003C\u003Efunction2 = obj4;
      this.__\u003C\u003Efunction1 = (LogicOp.OpLambda1) null;
      this.__\u003C\u003Eunary = false;
      this.__\u003C\u003EobjFunction2 = (LogicOp.OpObjLambda2) null;
      this.__\u003C\u003Efunc = num != 0;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LogicOp[] values() => (LogicOp[]) LogicOp.\u0024VALUES.Clone();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00240([In] double obj0, [In] double obj1) => obj0 + obj1;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00241([In] double obj0, [In] double obj1) => obj0 - obj1;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00242([In] double obj0, [In] double obj1) => obj0 * obj1;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00243([In] double obj0, [In] double obj1) => obj0 / obj1;

    [Modifiers]
    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00244([In] double obj0, [In] double obj1) => Math.floor(obj0 / obj1);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00245([In] double obj0, [In] double obj1) => obj0 % obj1;

    [Modifiers]
    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00246([In] double obj0, [In] double obj1) => Math.abs(obj0 - obj1) < 1E-06 ? 1.0 : 0.0;

    [Modifiers]
    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00247([In] object obj0, [In] object obj1) => Structs.eq(obj0, obj1) ? 1.0 : 0.0;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00248([In] double obj0, [In] double obj1) => Math.abs(obj0 - obj1) < 1E-06 ? 0.0 : 1.0;

    [Modifiers]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u00249([In] object obj0, [In] object obj1) => !Structs.eq(obj0, obj1) ? 1.0 : 0.0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002410([In] double obj0, [In] double obj1) => obj0 != 0.0 && obj1 != 0.0 ? 1.0 : 0.0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002411([In] double obj0, [In] double obj1) => obj0 < obj1 ? 1.0 : 0.0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002412([In] double obj0, [In] double obj1) => obj0 <= obj1 ? 1.0 : 0.0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002413([In] double obj0, [In] double obj1) => obj0 > obj1 ? 1.0 : 0.0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002414([In] double obj0, [In] double obj1) => obj0 >= obj1 ? 1.0 : 0.0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002415([In] double obj0, [In] double obj1) => 0.0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002416([In] double obj0, [In] double obj1) => (double) (ByteCodeHelper.d2l(obj0) << (int) ByteCodeHelper.d2l(obj1));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002417([In] double obj0, [In] double obj1) => (double) (ByteCodeHelper.d2l(obj0) >> (int) ByteCodeHelper.d2l(obj1));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002418([In] double obj0, [In] double obj1) => (double) (ByteCodeHelper.d2l(obj0) | ByteCodeHelper.d2l(obj1));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002419([In] double obj0, [In] double obj1) => (double) (ByteCodeHelper.d2l(obj0) & ByteCodeHelper.d2l(obj1));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002420([In] double obj0, [In] double obj1) => (double) (ByteCodeHelper.d2l(obj0) ^ ByteCodeHelper.d2l(obj1));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002421([In] double obj0) => (double) (ByteCodeHelper.d2l(obj0) ^ -1L);

    [Modifiers]
    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002422([In] double obj0, [In] double obj1) => (double) Angles.angle((float) obj0, (float) obj1);

    [Modifiers]
    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002423([In] double obj0, [In] double obj1) => (double) Mathf.dst((float) obj0, (float) obj1);

    [Modifiers]
    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002424([In] double obj0) => Math.abs(obj0);

    [Modifiers]
    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002425([In] double obj0) => Math.sin(obj0 * (Math.PI / 180.0));

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002426([In] double obj0) => Math.cos(obj0 * (Math.PI / 180.0));

    [Modifiers]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002427([In] double obj0) => Math.tan(obj0 * (Math.PI / 180.0));

    [Modifiers]
    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double lambda\u0024static\u002428([In] double obj0) => Mathf.rand.nextDouble() * obj0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.__\u003C\u003Esymbol;

    [LineNumberTable(new byte[] {159, 141, 173, 127, 0, 127, 0, 127, 0, 127, 0, 127, 0, 127, 0, 159, 0, 127, 10, 127, 10, 127, 1, 127, 1, 127, 1, 127, 1, 127, 1, 159, 1, 127, 1, 127, 1, 127, 1, 127, 1, 127, 1, 159, 1, 127, 2, 127, 2, 127, 2, 127, 2, 127, 14, 127, 1, 127, 1, 127, 1, 127, 1, 127, 1, 127, 1, 127, 1, 127, 1, 127, 1, 255, 1, 25, 255, 160, 232, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LogicOp()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LogicOp"))
        return;
      LogicOp.__\u003C\u003Eadd = new LogicOp(nameof (add), 0, "+", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon0());
      LogicOp.__\u003C\u003Esub = new LogicOp(nameof (sub), 1, "-", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon1());
      LogicOp.__\u003C\u003Emul = new LogicOp(nameof (mul), 2, "*", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon2());
      LogicOp.__\u003C\u003Ediv = new LogicOp(nameof (div), 3, "/", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon3());
      LogicOp.__\u003C\u003Eidiv = new LogicOp(nameof (idiv), 4, "//", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon4());
      LogicOp.__\u003C\u003Emod = new LogicOp(nameof (mod), 5, "%", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon5());
      LogicOp.__\u003C\u003Epow = new LogicOp(nameof (pow), 6, "^", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon6());
      LogicOp.__\u003C\u003Eequal = new LogicOp(nameof (equal), 7, "==", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon7(), (LogicOp.OpObjLambda2) new LogicOp.__\u003C\u003EAnon8());
      LogicOp.__\u003C\u003EnotEqual = new LogicOp(nameof (notEqual), 8, nameof (not), (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon9(), (LogicOp.OpObjLambda2) new LogicOp.__\u003C\u003EAnon10());
      LogicOp.__\u003C\u003Eland = new LogicOp(nameof (land), 9, nameof (and), (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon11());
      LogicOp.__\u003C\u003ElessThan = new LogicOp(nameof (lessThan), 10, "<", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon12());
      LogicOp.__\u003C\u003ElessThanEq = new LogicOp(nameof (lessThanEq), 11, "<=", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon13());
      LogicOp.__\u003C\u003EgreaterThan = new LogicOp(nameof (greaterThan), 12, ">", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon14());
      LogicOp.__\u003C\u003EgreaterThanEq = new LogicOp(nameof (greaterThanEq), 13, ">=", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon15());
      LogicOp.__\u003C\u003EstrictEqual = new LogicOp(nameof (strictEqual), 14, "===", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon16());
      LogicOp.__\u003C\u003Eshl = new LogicOp(nameof (shl), 15, "<<", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon17());
      LogicOp.__\u003C\u003Eshr = new LogicOp(nameof (shr), 16, ">>", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon18());
      LogicOp.__\u003C\u003Eor = new LogicOp(nameof (or), 17, nameof (or), (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon19());
      LogicOp.__\u003C\u003Eand = new LogicOp(nameof (and), 18, "b-and", (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon20());
      LogicOp.__\u003C\u003Exor = new LogicOp(nameof (xor), 19, nameof (xor), (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon21());
      LogicOp.__\u003C\u003Enot = new LogicOp(nameof (not), 20, "flip", (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon22());
      LogicOp.__\u003C\u003Emax = new LogicOp(nameof (max), 21, nameof (max), true, (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon23());
      LogicOp.__\u003C\u003Emin = new LogicOp(nameof (min), 22, nameof (min), true, (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon24());
      LogicOp.__\u003C\u003Eangle = new LogicOp(nameof (angle), 23, nameof (angle), true, (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon25());
      LogicOp.__\u003C\u003Elen = new LogicOp(nameof (len), 24, nameof (len), true, (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon26());
      Simplex noise = LExecutor.__\u003C\u003Enoise;
      Objects.requireNonNull((object) noise);
      LogicOp.__\u003C\u003Enoise = new LogicOp(nameof (noise), 25, nameof (noise), true, (LogicOp.OpLambda2) new LogicOp.__\u003C\u003EAnon27(noise));
      LogicOp.__\u003C\u003Eabs = new LogicOp(nameof (abs), 26, nameof (abs), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon28());
      LogicOp.__\u003C\u003Elog = new LogicOp(nameof (log), 27, nameof (log), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon29());
      LogicOp.__\u003C\u003Elog10 = new LogicOp(nameof (log10), 28, nameof (log10), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon30());
      LogicOp.__\u003C\u003Esin = new LogicOp(nameof (sin), 29, nameof (sin), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon31());
      LogicOp.__\u003C\u003Ecos = new LogicOp(nameof (cos), 30, nameof (cos), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon32());
      LogicOp.__\u003C\u003Etan = new LogicOp(nameof (tan), 31, nameof (tan), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon33());
      LogicOp.__\u003C\u003Efloor = new LogicOp(nameof (floor), 32, nameof (floor), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon34());
      LogicOp.__\u003C\u003Eceil = new LogicOp(nameof (ceil), 33, nameof (ceil), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon35());
      LogicOp.__\u003C\u003Esqrt = new LogicOp(nameof (sqrt), 34, nameof (sqrt), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon36());
      LogicOp.__\u003C\u003Erand = new LogicOp(nameof (rand), 35, nameof (rand), (LogicOp.OpLambda1) new LogicOp.__\u003C\u003EAnon37());
      LogicOp.\u0024VALUES = new LogicOp[36]
      {
        LogicOp.__\u003C\u003Eadd,
        LogicOp.__\u003C\u003Esub,
        LogicOp.__\u003C\u003Emul,
        LogicOp.__\u003C\u003Ediv,
        LogicOp.__\u003C\u003Eidiv,
        LogicOp.__\u003C\u003Emod,
        LogicOp.__\u003C\u003Epow,
        LogicOp.__\u003C\u003Eequal,
        LogicOp.__\u003C\u003EnotEqual,
        LogicOp.__\u003C\u003Eland,
        LogicOp.__\u003C\u003ElessThan,
        LogicOp.__\u003C\u003ElessThanEq,
        LogicOp.__\u003C\u003EgreaterThan,
        LogicOp.__\u003C\u003EgreaterThanEq,
        LogicOp.__\u003C\u003EstrictEqual,
        LogicOp.__\u003C\u003Eshl,
        LogicOp.__\u003C\u003Eshr,
        LogicOp.__\u003C\u003Eor,
        LogicOp.__\u003C\u003Eand,
        LogicOp.__\u003C\u003Exor,
        LogicOp.__\u003C\u003Enot,
        LogicOp.__\u003C\u003Emax,
        LogicOp.__\u003C\u003Emin,
        LogicOp.__\u003C\u003Eangle,
        LogicOp.__\u003C\u003Elen,
        LogicOp.__\u003C\u003Enoise,
        LogicOp.__\u003C\u003Eabs,
        LogicOp.__\u003C\u003Elog,
        LogicOp.__\u003C\u003Elog10,
        LogicOp.__\u003C\u003Esin,
        LogicOp.__\u003C\u003Ecos,
        LogicOp.__\u003C\u003Etan,
        LogicOp.__\u003C\u003Efloor,
        LogicOp.__\u003C\u003Eceil,
        LogicOp.__\u003C\u003Esqrt,
        LogicOp.__\u003C\u003Erand
      };
      LogicOp.__\u003C\u003Eall = LogicOp.values();
    }

    [Modifiers]
    public static LogicOp add
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eadd;
    }

    [Modifiers]
    public static LogicOp sub
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Esub;
    }

    [Modifiers]
    public static LogicOp mul
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Emul;
    }

    [Modifiers]
    public static LogicOp div
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Ediv;
    }

    [Modifiers]
    public static LogicOp idiv
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eidiv;
    }

    [Modifiers]
    public static LogicOp mod
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Emod;
    }

    [Modifiers]
    public static LogicOp pow
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Epow;
    }

    [Modifiers]
    public static LogicOp equal
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eequal;
    }

    [Modifiers]
    public static LogicOp notEqual
    {
      [HideFromJava] get => LogicOp.__\u003C\u003EnotEqual;
    }

    [Modifiers]
    public static LogicOp land
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eland;
    }

    [Modifiers]
    public static LogicOp lessThan
    {
      [HideFromJava] get => LogicOp.__\u003C\u003ElessThan;
    }

    [Modifiers]
    public static LogicOp lessThanEq
    {
      [HideFromJava] get => LogicOp.__\u003C\u003ElessThanEq;
    }

    [Modifiers]
    public static LogicOp greaterThan
    {
      [HideFromJava] get => LogicOp.__\u003C\u003EgreaterThan;
    }

    [Modifiers]
    public static LogicOp greaterThanEq
    {
      [HideFromJava] get => LogicOp.__\u003C\u003EgreaterThanEq;
    }

    [Modifiers]
    public static LogicOp strictEqual
    {
      [HideFromJava] get => LogicOp.__\u003C\u003EstrictEqual;
    }

    [Modifiers]
    public static LogicOp shl
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eshl;
    }

    [Modifiers]
    public static LogicOp shr
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eshr;
    }

    [Modifiers]
    public static LogicOp or
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eor;
    }

    [Modifiers]
    public static LogicOp and
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eand;
    }

    [Modifiers]
    public static LogicOp xor
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Exor;
    }

    [Modifiers]
    public static LogicOp not
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Enot;
    }

    [Modifiers]
    public static LogicOp max
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Emax;
    }

    [Modifiers]
    public static LogicOp min
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Emin;
    }

    [Modifiers]
    public static LogicOp angle
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eangle;
    }

    [Modifiers]
    public static LogicOp len
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Elen;
    }

    [Modifiers]
    public static LogicOp noise
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Enoise;
    }

    [Modifiers]
    public static LogicOp abs
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eabs;
    }

    [Modifiers]
    public static LogicOp log
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Elog;
    }

    [Modifiers]
    public static LogicOp log10
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Elog10;
    }

    [Modifiers]
    public static LogicOp sin
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Esin;
    }

    [Modifiers]
    public static LogicOp cos
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Ecos;
    }

    [Modifiers]
    public static LogicOp tan
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Etan;
    }

    [Modifiers]
    public static LogicOp floor
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Efloor;
    }

    [Modifiers]
    public static LogicOp ceil
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eceil;
    }

    [Modifiers]
    public static LogicOp sqrt
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Esqrt;
    }

    [Modifiers]
    public static LogicOp rand
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Erand;
    }

    [Modifiers]
    public static LogicOp[] all
    {
      [HideFromJava] get => LogicOp.__\u003C\u003Eall;
    }

    [Modifiers]
    public object objFunction2
    {
      [HideFromJava] get => (object) this.__\u003C\u003EobjFunction2;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EobjFunction2 = (LogicOp.OpObjLambda2) value;
    }

    [Modifiers]
    public object function2
    {
      [HideFromJava] get => (object) this.__\u003C\u003Efunction2;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efunction2 = (LogicOp.OpLambda2) value;
    }

    [Modifiers]
    public object function1
    {
      [HideFromJava] get => (object) this.__\u003C\u003Efunction1;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efunction1 = (LogicOp.OpLambda1) value;
    }

    [Modifiers]
    public bool unary
    {
      [HideFromJava] get => this.__\u003C\u003Eunary;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eunary = value;
    }

    [Modifiers]
    public bool func
    {
      [HideFromJava] get => this.__\u003C\u003Efunc;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efunc = value;
    }

    [Modifiers]
    public string symbol
    {
      [HideFromJava] get => this.__\u003C\u003Esymbol;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Esymbol = value;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      add,
      sub,
      mul,
      div,
      idiv,
      mod,
      pow,
      equal,
      notEqual,
      land,
      lessThan,
      lessThanEq,
      greaterThan,
      greaterThanEq,
      strictEqual,
      shl,
      shr,
      or,
      and,
      xor,
      not,
      max,
      min,
      angle,
      len,
      noise,
      abs,
      log,
      log10,
      sin,
      cos,
      tan,
      floor,
      ceil,
      sqrt,
      rand,
    }

    internal interface OpLambda1
    {
      double get([In] double obj0);
    }

    internal interface OpLambda2
    {
      double get([In] double obj0, [In] double obj1);
    }

    internal interface OpObjLambda2
    {
      double get([In] object obj0, [In] object obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u00240(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u00241(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u00242(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u00243(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u00244(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u00245(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public double get([In] double obj0, [In] double obj1) => Math.pow(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u00246(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : LogicOp.OpObjLambda2
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public double get([In] object obj0, [In] object obj1) => LogicOp.lambda\u0024static\u00247(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u00248(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : LogicOp.OpObjLambda2
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public double get([In] object obj0, [In] object obj1) => LogicOp.lambda\u0024static\u00249(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002410(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002411(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002412(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002413(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002414(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002415(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002416(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002417(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002418(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon20()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002419(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon21()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002420(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public double get([In] double obj0) => LogicOp.lambda\u0024static\u002421(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public double get([In] double obj0, [In] double obj1) => Math.max(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon24()
      {
      }

      public double get([In] double obj0, [In] double obj1) => Math.min(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002422(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : LogicOp.OpLambda2
    {
      internal __\u003C\u003EAnon26()
      {
      }

      public double get([In] double obj0, [In] double obj1) => LogicOp.lambda\u0024static\u002423(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : LogicOp.OpLambda2
    {
      private readonly Simplex arg\u00241;

      internal __\u003C\u003EAnon27([In] Simplex obj0) => this.arg\u00241 = obj0;

      public double get([In] double obj0, [In] double obj1) => this.arg\u00241.rawNoise2D(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon28()
      {
      }

      public double get([In] double obj0) => LogicOp.lambda\u0024static\u002424(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon29()
      {
      }

      public double get([In] double obj0) => Math.log(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon30()
      {
      }

      public double get([In] double obj0) => Math.log10(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon31()
      {
      }

      public double get([In] double obj0) => LogicOp.lambda\u0024static\u002425(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon32()
      {
      }

      public double get([In] double obj0) => LogicOp.lambda\u0024static\u002426(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon33()
      {
      }

      public double get([In] double obj0) => LogicOp.lambda\u0024static\u002427(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon34()
      {
      }

      public double get([In] double obj0) => Math.floor(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon35()
      {
      }

      public double get([In] double obj0) => Math.ceil(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon36()
      {
      }

      public double get([In] double obj0) => Math.sqrt(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : LogicOp.OpLambda1
    {
      internal __\u003C\u003EAnon37()
      {
      }

      public double get([In] double obj0) => LogicOp.lambda\u0024static\u002428(obj0);
    }
  }
}
