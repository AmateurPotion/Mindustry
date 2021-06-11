// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SdlKeymap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.input;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.backend.sdl
{
  public class SdlKeymap : Object
  {
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SdlKeymap()
    {
    }

    [LineNumberTable(new byte[] {159, 150, 127, 163, 156, 102, 102, 134, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static KeyCode getCode(int code)
    {
      switch (code)
      {
        case 0:
          return KeyCode.__\u003C\u003Eunknown;
        case 8:
          return KeyCode.__\u003C\u003Ebackspace;
        case 9:
          return KeyCode.__\u003C\u003Etab;
        case 13:
        case 1073741982:
          return KeyCode.__\u003C\u003Eenter;
        case 27:
          return KeyCode.__\u003C\u003Eescape;
        case 32:
          return KeyCode.__\u003C\u003Espace;
        case 43:
          return KeyCode.__\u003C\u003Eplus;
        case 44:
          return KeyCode.__\u003C\u003Ecomma;
        case 45:
          return KeyCode.__\u003C\u003Eminus;
        case 46:
          return KeyCode.__\u003C\u003Eperiod;
        case 47:
          return KeyCode.__\u003C\u003Eslash;
        case 48:
          return KeyCode.__\u003C\u003Enum0;
        case 49:
          return KeyCode.__\u003C\u003Enum1;
        case 50:
          return KeyCode.__\u003C\u003Enum2;
        case 51:
          return KeyCode.__\u003C\u003Enum3;
        case 52:
          return KeyCode.__\u003C\u003Enum4;
        case 53:
          return KeyCode.__\u003C\u003Enum5;
        case 54:
          return KeyCode.__\u003C\u003Enum6;
        case 55:
          return KeyCode.__\u003C\u003Enum7;
        case 56:
          return KeyCode.__\u003C\u003Enum8;
        case 57:
          return KeyCode.__\u003C\u003Enum9;
        case 58:
          return KeyCode.__\u003C\u003Ecolon;
        case 59:
          return KeyCode.__\u003C\u003Esemicolon;
        case 61:
          return KeyCode.__\u003C\u003Eequals;
        case 64:
          return KeyCode.__\u003C\u003Eat;
        case 92:
          return KeyCode.__\u003C\u003Ebackslash;
        case 96:
          return KeyCode.__\u003C\u003Ebacktick;
        case 97:
          return KeyCode.__\u003C\u003Ea;
        case 98:
          return KeyCode.__\u003C\u003Eb;
        case 99:
          return KeyCode.__\u003C\u003Ec;
        case 100:
          return KeyCode.__\u003C\u003Ed;
        case 101:
          return KeyCode.__\u003C\u003Ee;
        case 102:
          return KeyCode.__\u003C\u003Ef;
        case 103:
          return KeyCode.__\u003C\u003Eg;
        case 104:
          return KeyCode.__\u003C\u003Eh;
        case 105:
          return KeyCode.__\u003C\u003Ei;
        case 106:
          return KeyCode.__\u003C\u003Ej;
        case 107:
          return KeyCode.__\u003C\u003Ek;
        case 108:
          return KeyCode.__\u003C\u003El;
        case 109:
          return KeyCode.__\u003C\u003Em;
        case 110:
          return KeyCode.__\u003C\u003En;
        case 111:
          return KeyCode.__\u003C\u003Eo;
        case 112:
          return KeyCode.__\u003C\u003Ep;
        case 113:
          return KeyCode.__\u003C\u003Eq;
        case 114:
          return KeyCode.__\u003C\u003Er;
        case 115:
          return KeyCode.__\u003C\u003Es;
        case 116:
          return KeyCode.__\u003C\u003Et;
        case 117:
          return KeyCode.__\u003C\u003Eu;
        case 118:
          return KeyCode.__\u003C\u003Ev;
        case 119:
          return KeyCode.__\u003C\u003Ew;
        case 120:
          return KeyCode.__\u003C\u003Ex;
        case 121:
          return KeyCode.__\u003C\u003Ey;
        case 122:
          return KeyCode.__\u003C\u003Ez;
        case (int) sbyte.MaxValue:
          return KeyCode.__\u003C\u003EforwardDel;
        case 1073741882:
          return KeyCode.__\u003C\u003Ef1;
        case 1073741883:
          return KeyCode.__\u003C\u003Ef2;
        case 1073741884:
          return KeyCode.__\u003C\u003Ef3;
        case 1073741885:
          return KeyCode.__\u003C\u003Ef4;
        case 1073741886:
          return KeyCode.__\u003C\u003Ef5;
        case 1073741887:
          return KeyCode.__\u003C\u003Ef6;
        case 1073741888:
          return KeyCode.__\u003C\u003Ef7;
        case 1073741889:
          return KeyCode.__\u003C\u003Ef8;
        case 1073741890:
          return KeyCode.__\u003C\u003Ef9;
        case 1073741891:
          return KeyCode.__\u003C\u003Ef10;
        case 1073741892:
          return KeyCode.__\u003C\u003Ef11;
        case 1073741893:
          return KeyCode.__\u003C\u003Ef12;
        case 1073741897:
          return KeyCode.__\u003C\u003Einsert;
        case 1073741898:
          return KeyCode.__\u003C\u003Ehome;
        case 1073741901:
          return KeyCode.__\u003C\u003Eend;
        case 1073741903:
          return KeyCode.__\u003C\u003Eright;
        case 1073741904:
          return KeyCode.__\u003C\u003Eleft;
        case 1073741905:
          return KeyCode.__\u003C\u003Edown;
        case 1073741906:
          return KeyCode.__\u003C\u003Eup;
        case 1073741926:
          return KeyCode.__\u003C\u003Epower;
        case 1073741942:
          return KeyCode.__\u003C\u003Emenu;
        case 1073741951:
          return KeyCode.__\u003C\u003Emute;
        case 1073741980:
          return KeyCode.__\u003C\u003Eclear;
        case 1073742048:
          return KeyCode.__\u003C\u003EcontrolLeft;
        case 1073742049:
          return KeyCode.__\u003C\u003EshiftLeft;
        case 1073742050:
          return KeyCode.__\u003C\u003EaltLeft;
        case 1073742052:
          return KeyCode.__\u003C\u003EcontrolRight;
        case 1073742053:
          return KeyCode.__\u003C\u003EshiftRight;
        case 1073742054:
          return KeyCode.__\u003C\u003EaltRight;
        default:
          return KeyCode.__\u003C\u003Eunknown;
      }
    }
  }
}
