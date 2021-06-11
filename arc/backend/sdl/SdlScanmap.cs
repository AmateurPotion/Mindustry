// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SdlScanmap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.input;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.backend.sdl
{
  public class SdlScanmap : Object
  {
    [LineNumberTable(new byte[] {159, 150, 127, 163, 76, 102, 102, 134, 102, 102, 102, 134, 134, 134, 134, 102, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 134, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static KeyCode getCode(int code)
    {
      switch (code)
      {
        case 0:
          return KeyCode.__\u003C\u003Eunknown;
        case 4:
          return KeyCode.__\u003C\u003Ea;
        case 5:
          return KeyCode.__\u003C\u003Eb;
        case 6:
          return KeyCode.__\u003C\u003Ec;
        case 7:
          return KeyCode.__\u003C\u003Ed;
        case 8:
          return KeyCode.__\u003C\u003Ee;
        case 9:
          return KeyCode.__\u003C\u003Ef;
        case 10:
          return KeyCode.__\u003C\u003Eg;
        case 11:
          return KeyCode.__\u003C\u003Eh;
        case 12:
          return KeyCode.__\u003C\u003Ei;
        case 13:
          return KeyCode.__\u003C\u003Ej;
        case 14:
          return KeyCode.__\u003C\u003Ek;
        case 15:
          return KeyCode.__\u003C\u003El;
        case 16:
          return KeyCode.__\u003C\u003Em;
        case 17:
          return KeyCode.__\u003C\u003En;
        case 18:
          return KeyCode.__\u003C\u003Eo;
        case 19:
          return KeyCode.__\u003C\u003Ep;
        case 20:
          return KeyCode.__\u003C\u003Eq;
        case 21:
          return KeyCode.__\u003C\u003Er;
        case 22:
          return KeyCode.__\u003C\u003Es;
        case 23:
          return KeyCode.__\u003C\u003Et;
        case 24:
          return KeyCode.__\u003C\u003Eu;
        case 25:
          return KeyCode.__\u003C\u003Ev;
        case 26:
          return KeyCode.__\u003C\u003Ew;
        case 27:
          return KeyCode.__\u003C\u003Ex;
        case 28:
          return KeyCode.__\u003C\u003Ey;
        case 29:
          return KeyCode.__\u003C\u003Ez;
        case 30:
        case 89:
          return KeyCode.__\u003C\u003Enum1;
        case 31:
        case 90:
          return KeyCode.__\u003C\u003Enum2;
        case 32:
        case 91:
          return KeyCode.__\u003C\u003Enum3;
        case 33:
        case 92:
          return KeyCode.__\u003C\u003Enum4;
        case 34:
        case 93:
          return KeyCode.__\u003C\u003Enum5;
        case 35:
        case 94:
          return KeyCode.__\u003C\u003Enum6;
        case 36:
        case 95:
          return KeyCode.__\u003C\u003Enum7;
        case 37:
        case 96:
          return KeyCode.__\u003C\u003Enum8;
        case 38:
        case 97:
          return KeyCode.__\u003C\u003Enum9;
        case 39:
        case 98:
          return KeyCode.__\u003C\u003Enum0;
        case 40:
        case 88:
          return KeyCode.__\u003C\u003Eenter;
        case 41:
          return KeyCode.__\u003C\u003Eescape;
        case 42:
          return KeyCode.__\u003C\u003Ebackspace;
        case 43:
          return KeyCode.__\u003C\u003Etab;
        case 44:
          return KeyCode.__\u003C\u003Espace;
        case 45:
        case 86:
          return KeyCode.__\u003C\u003Eminus;
        case 46:
          return KeyCode.__\u003C\u003Eequals;
        case 47:
          return KeyCode.__\u003C\u003EleftBracket;
        case 48:
          return KeyCode.__\u003C\u003ErightBracket;
        case 49:
          return KeyCode.__\u003C\u003Ebackslash;
        case 51:
          return KeyCode.__\u003C\u003Esemicolon;
        case 52:
          return KeyCode.__\u003C\u003Eapostrophe;
        case 53:
          return KeyCode.__\u003C\u003Ebacktick;
        case 54:
        case 133:
          return KeyCode.__\u003C\u003Ecomma;
        case 55:
        case 99:
          return KeyCode.__\u003C\u003Eperiod;
        case 56:
        case 84:
          return KeyCode.__\u003C\u003Eslash;
        case 57:
          return KeyCode.__\u003C\u003EcapsLock;
        case 58:
          return KeyCode.__\u003C\u003Ef1;
        case 59:
          return KeyCode.__\u003C\u003Ef2;
        case 60:
          return KeyCode.__\u003C\u003Ef3;
        case 61:
          return KeyCode.__\u003C\u003Ef4;
        case 62:
          return KeyCode.__\u003C\u003Ef5;
        case 63:
          return KeyCode.__\u003C\u003Ef6;
        case 64:
          return KeyCode.__\u003C\u003Ef7;
        case 65:
          return KeyCode.__\u003C\u003Ef8;
        case 66:
          return KeyCode.__\u003C\u003Ef9;
        case 67:
          return KeyCode.__\u003C\u003Ef10;
        case 68:
          return KeyCode.__\u003C\u003Ef11;
        case 69:
          return KeyCode.__\u003C\u003Ef12;
        case 70:
          return KeyCode.__\u003C\u003EprintScreen;
        case 71:
          return KeyCode.__\u003C\u003EscrollLock;
        case 72:
          return KeyCode.__\u003C\u003Epause;
        case 73:
          return KeyCode.__\u003C\u003Einsert;
        case 74:
          return KeyCode.__\u003C\u003Ehome;
        case 75:
          return KeyCode.__\u003C\u003EpageUp;
        case 76:
          return KeyCode.__\u003C\u003Edel;
        case 77:
          return KeyCode.__\u003C\u003Eend;
        case 78:
          return KeyCode.__\u003C\u003EpageDown;
        case 79:
          return KeyCode.__\u003C\u003Eright;
        case 80:
          return KeyCode.__\u003C\u003Eleft;
        case 81:
          return KeyCode.__\u003C\u003Edown;
        case 82:
          return KeyCode.__\u003C\u003Eup;
        case 85:
          return KeyCode.__\u003C\u003Easterisk;
        case 87:
          return KeyCode.__\u003C\u003Eplus;
        case 101:
          return KeyCode.__\u003C\u003Eapplication;
        case 102:
          return KeyCode.__\u003C\u003Epower;
        case 118:
          return KeyCode.__\u003C\u003Emenu;
        case (int) sbyte.MaxValue:
          return KeyCode.__\u003C\u003Emute;
        case 156:
          return KeyCode.__\u003C\u003Eclear;
        case 203:
          return KeyCode.__\u003C\u003Ecolon;
        case 206:
          return KeyCode.__\u003C\u003Eat;
        case 224:
          return KeyCode.__\u003C\u003EcontrolLeft;
        case 225:
          return KeyCode.__\u003C\u003EshiftLeft;
        case 226:
          return KeyCode.__\u003C\u003EaltLeft;
        case 227:
        case 231:
          return KeyCode.__\u003C\u003Esym;
        case 228:
          return KeyCode.__\u003C\u003EcontrolRight;
        case 229:
          return KeyCode.__\u003C\u003EshiftRight;
        case 230:
          return KeyCode.__\u003C\u003EaltRight;
        default:
          return KeyCode.__\u003C\u003Eunknown;
      }
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SdlScanmap()
    {
    }
  }
}
