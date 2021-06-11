// Decompiled with JetBrains decompiler
// Type: mindustry.logic.ConditionOp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  [Signature("Ljava/lang/Enum<Lmindustry/logic/ConditionOp;>;")]
  [Modifiers]
  [Serializable]
  public sealed class ConditionOp : Enum
  {
    [Modifiers]
    internal static ConditionOp __\u003C\u003Eequal;
    [Modifiers]
    internal static ConditionOp __\u003C\u003EnotEqual;
    [Modifiers]
    internal static ConditionOp __\u003C\u003ElessThan;
    [Modifiers]
    internal static ConditionOp __\u003C\u003ElessThanEq;
    [Modifiers]
    internal static ConditionOp __\u003C\u003EgreaterThan;
    [Modifiers]
    internal static ConditionOp __\u003C\u003EgreaterThanEq;
    [Modifiers]
    internal static ConditionOp __\u003C\u003EstrictEqual;
    [Modifiers]
    internal static ConditionOp __\u003C\u003Ealways;
    internal static ConditionOp[] __\u003C\u003Eall;
    internal ConditionOp.CondObjOpLambda __\u003C\u003EobjFunction;
    internal ConditionOp.CondOpLambda __\u003C\u003Efunction;
    internal string __\u003C\u003Esymbol;
    [Modifiers]
    private static ConditionOp[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ConditionOp valueOf(string name) => (ConditionOp) Enum.valueOf((Class) ClassLiteral<ConditionOp>.Value, name);

    [Signature("(Ljava/lang/String;Lmindustry/logic/ConditionOp$CondOpLambda;Lmindustry/logic/ConditionOp$CondObjOpLambda;)V")]
    [LineNumberTable(new byte[] {159, 167, 106, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ConditionOp(
      [In] string obj0,
      [In] int obj1,
      [In] string obj2,
      [In] ConditionOp.CondOpLambda obj3,
      [In] ConditionOp.CondObjOpLambda obj4)
      : base(obj0, obj1)
    {
      ConditionOp conditionOp = this;
      this.__\u003C\u003Esymbol = obj2;
      this.__\u003C\u003Efunction = obj3;
      this.__\u003C\u003EobjFunction = obj4;
      GC.KeepAlive((object) this);
    }

    [Signature("(Ljava/lang/String;Lmindustry/logic/ConditionOp$CondOpLambda;)V")]
    [LineNumberTable(new byte[] {159, 164, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ConditionOp([In] string obj0, [In] int obj1, [In] string obj2, [In] ConditionOp.CondOpLambda obj3)
      : this(obj0, obj1, obj2, obj3, (ConditionOp.CondObjOpLambda) null)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ConditionOp[] values() => (ConditionOp[]) ConditionOp.\u0024VALUES.Clone();

    [Modifiers]
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00240([In] double obj0, [In] double obj1) => Math.abs(obj0 - obj1) < 1E-06;

    [Modifiers]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00241([In] double obj0, [In] double obj1) => Math.abs(obj0 - obj1) >= 1E-06;

    [Modifiers]
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00242([In] object obj0, [In] object obj1) => !Structs.eq(obj0, obj1);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00243([In] double obj0, [In] double obj1) => obj0 < obj1;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00244([In] double obj0, [In] double obj1) => obj0 <= obj1;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00245([In] double obj0, [In] double obj1) => obj0 > obj1;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00246([In] double obj0, [In] double obj1) => obj0 >= obj1;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00247([In] double obj0, [In] double obj1) => false;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00248([In] double obj0, [In] double obj1) => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.__\u003C\u003Esymbol;

    [LineNumberTable(new byte[] {159, 141, 141, 127, 10, 127, 10, 127, 0, 127, 0, 127, 0, 127, 0, 127, 0, 255, 0, 56, 255, 44, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ConditionOp()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.ConditionOp"))
        return;
      ConditionOp.__\u003C\u003Eequal = new ConditionOp(nameof (equal), 0, "==", (ConditionOp.CondOpLambda) new ConditionOp.__\u003C\u003EAnon0(), (ConditionOp.CondObjOpLambda) new ConditionOp.__\u003C\u003EAnon1());
      ConditionOp.__\u003C\u003EnotEqual = new ConditionOp(nameof (notEqual), 1, "not", (ConditionOp.CondOpLambda) new ConditionOp.__\u003C\u003EAnon2(), (ConditionOp.CondObjOpLambda) new ConditionOp.__\u003C\u003EAnon3());
      ConditionOp.__\u003C\u003ElessThan = new ConditionOp(nameof (lessThan), 2, "<", (ConditionOp.CondOpLambda) new ConditionOp.__\u003C\u003EAnon4());
      ConditionOp.__\u003C\u003ElessThanEq = new ConditionOp(nameof (lessThanEq), 3, "<=", (ConditionOp.CondOpLambda) new ConditionOp.__\u003C\u003EAnon5());
      ConditionOp.__\u003C\u003EgreaterThan = new ConditionOp(nameof (greaterThan), 4, ">", (ConditionOp.CondOpLambda) new ConditionOp.__\u003C\u003EAnon6());
      ConditionOp.__\u003C\u003EgreaterThanEq = new ConditionOp(nameof (greaterThanEq), 5, ">=", (ConditionOp.CondOpLambda) new ConditionOp.__\u003C\u003EAnon7());
      ConditionOp.__\u003C\u003EstrictEqual = new ConditionOp(nameof (strictEqual), 6, "===", (ConditionOp.CondOpLambda) new ConditionOp.__\u003C\u003EAnon8());
      ConditionOp.__\u003C\u003Ealways = new ConditionOp(nameof (always), 7, nameof (always), (ConditionOp.CondOpLambda) new ConditionOp.__\u003C\u003EAnon9());
      ConditionOp.\u0024VALUES = new ConditionOp[8]
      {
        ConditionOp.__\u003C\u003Eequal,
        ConditionOp.__\u003C\u003EnotEqual,
        ConditionOp.__\u003C\u003ElessThan,
        ConditionOp.__\u003C\u003ElessThanEq,
        ConditionOp.__\u003C\u003EgreaterThan,
        ConditionOp.__\u003C\u003EgreaterThanEq,
        ConditionOp.__\u003C\u003EstrictEqual,
        ConditionOp.__\u003C\u003Ealways
      };
      ConditionOp.__\u003C\u003Eall = ConditionOp.values();
    }

    [Modifiers]
    public static ConditionOp equal
    {
      [HideFromJava] get => ConditionOp.__\u003C\u003Eequal;
    }

    [Modifiers]
    public static ConditionOp notEqual
    {
      [HideFromJava] get => ConditionOp.__\u003C\u003EnotEqual;
    }

    [Modifiers]
    public static ConditionOp lessThan
    {
      [HideFromJava] get => ConditionOp.__\u003C\u003ElessThan;
    }

    [Modifiers]
    public static ConditionOp lessThanEq
    {
      [HideFromJava] get => ConditionOp.__\u003C\u003ElessThanEq;
    }

    [Modifiers]
    public static ConditionOp greaterThan
    {
      [HideFromJava] get => ConditionOp.__\u003C\u003EgreaterThan;
    }

    [Modifiers]
    public static ConditionOp greaterThanEq
    {
      [HideFromJava] get => ConditionOp.__\u003C\u003EgreaterThanEq;
    }

    [Modifiers]
    public static ConditionOp strictEqual
    {
      [HideFromJava] get => ConditionOp.__\u003C\u003EstrictEqual;
    }

    [Modifiers]
    public static ConditionOp always
    {
      [HideFromJava] get => ConditionOp.__\u003C\u003Ealways;
    }

    [Modifiers]
    public static ConditionOp[] all
    {
      [HideFromJava] get => ConditionOp.__\u003C\u003Eall;
    }

    [Modifiers]
    public object objFunction
    {
      [HideFromJava] get => (object) this.__\u003C\u003EobjFunction;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EobjFunction = (ConditionOp.CondObjOpLambda) value;
    }

    [Modifiers]
    public object function
    {
      [HideFromJava] get => (object) this.__\u003C\u003Efunction;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efunction = (ConditionOp.CondOpLambda) value;
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
      equal,
      notEqual,
      lessThan,
      lessThanEq,
      greaterThan,
      greaterThanEq,
      strictEqual,
      always,
    }

    internal interface CondObjOpLambda
    {
      bool get([In] object obj0, [In] object obj1);
    }

    internal interface CondOpLambda
    {
      bool get([In] double obj0, [In] double obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : ConditionOp.CondOpLambda
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] double obj0, [In] double obj1) => (ConditionOp.lambda\u0024static\u00240(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : ConditionOp.CondObjOpLambda
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0, [In] object obj1) => (Structs.eq(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : ConditionOp.CondOpLambda
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] double obj0, [In] double obj1) => (ConditionOp.lambda\u0024static\u00241(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : ConditionOp.CondObjOpLambda
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get([In] object obj0, [In] object obj1) => (ConditionOp.lambda\u0024static\u00242(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : ConditionOp.CondOpLambda
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] double obj0, [In] double obj1) => (ConditionOp.lambda\u0024static\u00243(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : ConditionOp.CondOpLambda
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public bool get([In] double obj0, [In] double obj1) => (ConditionOp.lambda\u0024static\u00244(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : ConditionOp.CondOpLambda
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] double obj0, [In] double obj1) => (ConditionOp.lambda\u0024static\u00245(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : ConditionOp.CondOpLambda
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public bool get([In] double obj0, [In] double obj1) => (ConditionOp.lambda\u0024static\u00246(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : ConditionOp.CondOpLambda
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public bool get([In] double obj0, [In] double obj1) => (ConditionOp.lambda\u0024static\u00247(obj0, obj1) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : ConditionOp.CondOpLambda
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public bool get([In] double obj0, [In] double obj1) => (ConditionOp.lambda\u0024static\u00248(obj0, obj1) ? 1 : 0) != 0;
    }
  }
}
