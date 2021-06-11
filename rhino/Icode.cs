// Decompiled with JetBrains decompiler
// Type: rhino.Icode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal abstract class Icode : Object
  {
    internal const int Icode_DELNAME = 0;
    internal const int Icode_DUP = -1;
    internal const int Icode_DUP2 = -2;
    internal const int Icode_SWAP = -3;
    internal const int Icode_POP = -4;
    internal const int Icode_POP_RESULT = -5;
    internal const int Icode_IFEQ_POP = -6;
    internal const int Icode_VAR_INC_DEC = -7;
    internal const int Icode_NAME_INC_DEC = -8;
    internal const int Icode_PROP_INC_DEC = -9;
    internal const int Icode_ELEM_INC_DEC = -10;
    internal const int Icode_REF_INC_DEC = -11;
    internal const int Icode_SCOPE_LOAD = -12;
    internal const int Icode_SCOPE_SAVE = -13;
    internal const int Icode_TYPEOFNAME = -14;
    internal const int Icode_NAME_AND_THIS = -15;
    internal const int Icode_PROP_AND_THIS = -16;
    internal const int Icode_ELEM_AND_THIS = -17;
    internal const int Icode_VALUE_AND_THIS = -18;
    internal const int Icode_CLOSURE_EXPR = -19;
    internal const int Icode_CLOSURE_STMT = -20;
    internal const int Icode_CALLSPECIAL = -21;
    internal const int Icode_RETUNDEF = -22;
    internal const int Icode_GOSUB = -23;
    internal const int Icode_STARTSUB = -24;
    internal const int Icode_RETSUB = -25;
    internal const int Icode_LINE = -26;
    internal const int Icode_SHORTNUMBER = -27;
    internal const int Icode_INTNUMBER = -28;
    internal const int Icode_LITERAL_NEW = -29;
    internal const int Icode_LITERAL_SET = -30;
    internal const int Icode_SPARE_ARRAYLIT = -31;
    internal const int Icode_REG_IND_C0 = -32;
    internal const int Icode_REG_IND_C1 = -33;
    internal const int Icode_REG_IND_C2 = -34;
    internal const int Icode_REG_IND_C3 = -35;
    internal const int Icode_REG_IND_C4 = -36;
    internal const int Icode_REG_IND_C5 = -37;
    internal const int Icode_REG_IND1 = -38;
    internal const int Icode_REG_IND2 = -39;
    internal const int Icode_REG_IND4 = -40;
    internal const int Icode_REG_STR_C0 = -41;
    internal const int Icode_REG_STR_C1 = -42;
    internal const int Icode_REG_STR_C2 = -43;
    internal const int Icode_REG_STR_C3 = -44;
    internal const int Icode_REG_STR1 = -45;
    internal const int Icode_REG_STR2 = -46;
    internal const int Icode_REG_STR4 = -47;
    internal const int Icode_GETVAR1 = -48;
    internal const int Icode_SETVAR1 = -49;
    internal const int Icode_UNDEF = -50;
    internal const int Icode_ZERO = -51;
    internal const int Icode_ONE = -52;
    internal const int Icode_ENTERDQ = -53;
    internal const int Icode_LEAVEDQ = -54;
    internal const int Icode_TAIL_CALL = -55;
    internal const int Icode_LOCAL_CLEAR = -56;
    internal const int Icode_LITERAL_GETTER = -57;
    internal const int Icode_LITERAL_SETTER = -58;
    internal const int Icode_SETCONST = -59;
    internal const int Icode_SETCONSTVAR = -60;
    internal const int Icode_SETCONSTVAR1 = -61;
    internal const int Icode_GENERATOR = -62;
    internal const int Icode_GENERATOR_END = -63;
    internal const int Icode_DEBUGGER = -64;
    internal const int Icode_GENERATOR_RETURN = -65;
    internal const int Icode_YIELD_STAR = -66;
    internal const int MIN_ICODE = -66;

    [LineNumberTable(300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool validBytecode([In] int obj0) => Icode.validIcode(obj0) || Icode.validTokenCode(obj0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool validIcode([In] int obj0) => -66 <= obj0 && obj0 <= 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool validTokenCode([In] int obj0) => 2 <= obj0 && obj0 <= 81;

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Icode()
    {
    }

    [LineNumberTable(new byte[] {89, 104, 209})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string bytecodeName([In] int obj0)
    {
      if (!Icode.validBytecode(obj0))
      {
        string str = String.valueOf(obj0);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return String.valueOf(obj0);
    }
  }
}
