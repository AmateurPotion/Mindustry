// Decompiled with JetBrains decompiler
// Type: rhino.Token
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class Token : Object
  {
    public const bool printTrees = false;
    internal const bool printICode = false;
    internal const bool printNames = false;
    public const int ERROR = -1;
    public const int EOF = 0;
    public const int EOL = 1;
    public const int FIRST_BYTECODE_TOKEN = 2;
    public const int ENTERWITH = 2;
    public const int LEAVEWITH = 3;
    public const int RETURN = 4;
    public const int GOTO = 5;
    public const int IFEQ = 6;
    public const int IFNE = 7;
    public const int SETNAME = 8;
    public const int BITOR = 9;
    public const int BITXOR = 10;
    public const int BITAND = 11;
    public const int EQ = 12;
    public const int NE = 13;
    public const int LT = 14;
    public const int LE = 15;
    public const int GT = 16;
    public const int GE = 17;
    public const int LSH = 18;
    public const int RSH = 19;
    public const int URSH = 20;
    public const int ADD = 21;
    public const int SUB = 22;
    public const int MUL = 23;
    public const int DIV = 24;
    public const int MOD = 25;
    public const int NOT = 26;
    public const int BITNOT = 27;
    public const int POS = 28;
    public const int NEG = 29;
    public const int NEW = 30;
    public const int DELPROP = 31;
    public const int TYPEOF = 32;
    public const int GETPROP = 33;
    public const int GETPROPNOWARN = 34;
    public const int SETPROP = 35;
    public const int GETELEM = 36;
    public const int SETELEM = 37;
    public const int CALL = 38;
    public const int NAME = 39;
    public const int NUMBER = 40;
    public const int STRING = 41;
    public const int NULL = 42;
    public const int THIS = 43;
    public const int FALSE = 44;
    public const int TRUE = 45;
    public const int SHEQ = 46;
    public const int SHNE = 47;
    public const int REGEXP = 48;
    public const int BINDNAME = 49;
    public const int THROW = 50;
    public const int RETHROW = 51;
    public const int IN = 52;
    public const int INSTANCEOF = 53;
    public const int LOCAL_LOAD = 54;
    public const int GETVAR = 55;
    public const int SETVAR = 56;
    public const int CATCH_SCOPE = 57;
    public const int ENUM_INIT_KEYS = 58;
    public const int ENUM_INIT_VALUES = 59;
    public const int ENUM_INIT_ARRAY = 60;
    public const int ENUM_INIT_VALUES_IN_ORDER = 61;
    public const int ENUM_NEXT = 62;
    public const int ENUM_ID = 63;
    public const int THISFN = 64;
    public const int RETURN_RESULT = 65;
    public const int ARRAYLIT = 66;
    public const int OBJECTLIT = 67;
    public const int GET_REF = 68;
    public const int SET_REF = 69;
    public const int DEL_REF = 70;
    public const int REF_CALL = 71;
    public const int REF_SPECIAL = 72;
    public const int YIELD = 73;
    public const int STRICT_SETNAME = 74;
    public const int REF_MEMBER = 78;
    public const int REF_NS_MEMBER = 79;
    public const int REF_NAME = 80;
    public const int REF_NS_NAME = 81;
    public const int LAST_BYTECODE_TOKEN = 81;
    public const int TRY = 82;
    public const int SEMI = 83;
    public const int LB = 84;
    public const int RB = 85;
    public const int LC = 86;
    public const int RC = 87;
    public const int LP = 88;
    public const int RP = 89;
    public const int COMMA = 90;
    public const int ASSIGN = 91;
    public const int ASSIGN_BITOR = 92;
    public const int ASSIGN_BITXOR = 93;
    public const int ASSIGN_BITAND = 94;
    public const int ASSIGN_LSH = 95;
    public const int ASSIGN_RSH = 96;
    public const int ASSIGN_URSH = 97;
    public const int ASSIGN_ADD = 98;
    public const int ASSIGN_SUB = 99;
    public const int ASSIGN_MUL = 100;
    public const int ASSIGN_DIV = 101;
    public const int ASSIGN_MOD = 102;
    public const int FIRST_ASSIGN = 91;
    public const int LAST_ASSIGN = 102;
    public const int HOOK = 103;
    public const int COLON = 104;
    public const int OR = 105;
    public const int AND = 106;
    public const int INC = 107;
    public const int DEC = 108;
    public const int DOT = 109;
    public const int FUNCTION = 110;
    public const int EXPORT = 111;
    public const int IMPORT = 112;
    public const int IF = 113;
    public const int ELSE = 114;
    public const int SWITCH = 115;
    public const int CASE = 116;
    public const int DEFAULT = 117;
    public const int WHILE = 118;
    public const int DO = 119;
    public const int FOR = 120;
    public const int BREAK = 121;
    public const int CONTINUE = 122;
    public const int VAR = 123;
    public const int WITH = 124;
    public const int CATCH = 125;
    public const int FINALLY = 126;
    public const int VOID = 127;
    public const int RESERVED = 128;
    public const int EMPTY = 129;
    public const int BLOCK = 130;
    public const int LABEL = 131;
    public const int TARGET = 132;
    public const int LOOP = 133;
    public const int EXPR_VOID = 134;
    public const int EXPR_RESULT = 135;
    public const int JSR = 136;
    public const int SCRIPT = 137;
    public const int TYPEOFNAME = 138;
    public const int USE_STACK = 139;
    public const int SETPROP_OP = 140;
    public const int SETELEM_OP = 141;
    public const int LOCAL_BLOCK = 142;
    public const int SET_REF_OP = 143;
    public const int TO_OBJECT = 150;
    public const int TO_DOUBLE = 151;
    public const int GET = 152;
    public const int SET = 153;
    public const int LET = 154;
    public const int CONST = 155;
    public const int SETCONST = 156;
    public const int SETCONSTVAR = 157;
    public const int ARRAYCOMP = 158;
    public const int LETEXPR = 159;
    public const int WITHEXPR = 160;
    public const int DEBUGGER = 161;
    public const int COMMENT = 162;
    public const int GENEXPR = 163;
    public const int METHOD = 164;
    public const int ARROW = 165;
    public const int YIELD_STAR = 166;
    public const int LAST_TOKEN = 167;

    [LineNumberTable(224)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string name(int token) => String.valueOf(token);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string keywordToName(int token)
    {
      switch (token)
      {
        case 4:
          return "return";
        case 30:
          return "new";
        case 31:
          return "delete";
        case 32:
          return "typeof";
        case 42:
          return "null";
        case 43:
          return "this";
        case 44:
          return "false";
        case 45:
          return "true";
        case 50:
          return "throw";
        case 52:
          return "in";
        case 53:
          return "instanceof";
        case 73:
          return "yield";
        case 82:
          return "try";
        case 110:
          return "function";
        case 113:
          return "if";
        case 114:
          return "else";
        case 115:
          return "switch";
        case 116:
          return "case";
        case 117:
          return "default";
        case 118:
          return "while";
        case 119:
          return "do";
        case 120:
          return "for";
        case 121:
          return "break";
        case 122:
          return "continue";
        case 123:
          return "var";
        case 124:
          return "with";
        case 125:
          return "catch";
        case 126:
          return "finally";
        case (int) sbyte.MaxValue:
          return "void";
        case 154:
          return "let";
        case 155:
          return "const";
        case 161:
          return "debugger";
        default:
          return (string) null;
      }
    }

    [LineNumberTable(new byte[] {160, 122, 159, 162, 78, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 230, 73, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string typeToName(int token)
    {
      switch (token)
      {
        case -1:
          return "ERROR";
        case 0:
          return "EOF";
        case 1:
          return "EOL";
        case 2:
          return "ENTERWITH";
        case 3:
          return "LEAVEWITH";
        case 4:
          return "RETURN";
        case 5:
          return "GOTO";
        case 6:
          return "IFEQ";
        case 7:
          return "IFNE";
        case 8:
          return "SETNAME";
        case 9:
          return "BITOR";
        case 10:
          return "BITXOR";
        case 11:
          return "BITAND";
        case 12:
          return "EQ";
        case 13:
          return "NE";
        case 14:
          return "LT";
        case 15:
          return "LE";
        case 16:
          return "GT";
        case 17:
          return "GE";
        case 18:
          return "LSH";
        case 19:
          return "RSH";
        case 20:
          return "URSH";
        case 21:
          return "ADD";
        case 22:
          return "SUB";
        case 23:
          return "MUL";
        case 24:
          return "DIV";
        case 25:
          return "MOD";
        case 26:
          return "NOT";
        case 27:
          return "BITNOT";
        case 28:
          return "POS";
        case 29:
          return "NEG";
        case 30:
          return "NEW";
        case 31:
          return "DELPROP";
        case 32:
          return "TYPEOF";
        case 33:
          return "GETPROP";
        case 34:
          return "GETPROPNOWARN";
        case 35:
          return "SETPROP";
        case 36:
          return "GETELEM";
        case 37:
          return "SETELEM";
        case 38:
          return "CALL";
        case 39:
          return "NAME";
        case 40:
          return "NUMBER";
        case 41:
          return "STRING";
        case 42:
          return "NULL";
        case 43:
          return "THIS";
        case 44:
          return "FALSE";
        case 45:
          return "TRUE";
        case 46:
          return "SHEQ";
        case 47:
          return "SHNE";
        case 48:
          return "REGEXP";
        case 49:
          return "BINDNAME";
        case 50:
          return "THROW";
        case 51:
          return "RETHROW";
        case 52:
          return "IN";
        case 53:
          return "INSTANCEOF";
        case 54:
          return "LOCAL_LOAD";
        case 55:
          return "GETVAR";
        case 56:
          return "SETVAR";
        case 57:
          return "CATCH_SCOPE";
        case 58:
          return "ENUM_INIT_KEYS";
        case 59:
          return "ENUM_INIT_VALUES";
        case 60:
          return "ENUM_INIT_ARRAY";
        case 61:
          return "ENUM_INIT_VALUES_IN_ORDER";
        case 62:
          return "ENUM_NEXT";
        case 63:
          return "ENUM_ID";
        case 64:
          return "THISFN";
        case 65:
          return "RETURN_RESULT";
        case 66:
          return "ARRAYLIT";
        case 67:
          return "OBJECTLIT";
        case 68:
          return "GET_REF";
        case 69:
          return "SET_REF";
        case 70:
          return "DEL_REF";
        case 71:
          return "REF_CALL";
        case 72:
          return "REF_SPECIAL";
        case 73:
          return "YIELD";
        case 82:
          return "TRY";
        case 83:
          return "SEMI";
        case 84:
          return "LB";
        case 85:
          return "RB";
        case 86:
          return "LC";
        case 87:
          return "RC";
        case 88:
          return "LP";
        case 89:
          return "RP";
        case 90:
          return "COMMA";
        case 91:
          return "ASSIGN";
        case 92:
          return "ASSIGN_BITOR";
        case 93:
          return "ASSIGN_BITXOR";
        case 94:
          return "ASSIGN_BITAND";
        case 95:
          return "ASSIGN_LSH";
        case 96:
          return "ASSIGN_RSH";
        case 97:
          return "ASSIGN_URSH";
        case 98:
          return "ASSIGN_ADD";
        case 99:
          return "ASSIGN_SUB";
        case 100:
          return "ASSIGN_MUL";
        case 101:
          return "ASSIGN_DIV";
        case 102:
          return "ASSIGN_MOD";
        case 103:
          return "HOOK";
        case 104:
          return "COLON";
        case 105:
          return "OR";
        case 106:
          return "AND";
        case 107:
          return "INC";
        case 108:
          return "DEC";
        case 109:
          return "DOT";
        case 110:
          return "FUNCTION";
        case 111:
          return "EXPORT";
        case 112:
          return "IMPORT";
        case 113:
          return "IF";
        case 114:
          return "ELSE";
        case 115:
          return "SWITCH";
        case 116:
          return "CASE";
        case 117:
          return "DEFAULT";
        case 118:
          return "WHILE";
        case 119:
          return "DO";
        case 120:
          return "FOR";
        case 121:
          return "BREAK";
        case 122:
          return "CONTINUE";
        case 123:
          return "VAR";
        case 124:
          return "WITH";
        case 125:
          return "CATCH";
        case 126:
          return "FINALLY";
        case (int) sbyte.MaxValue:
          return "VOID";
        case 128:
          return "RESERVED";
        case 129:
          return "EMPTY";
        case 130:
          return "BLOCK";
        case 131:
          return "LABEL";
        case 132:
          return "TARGET";
        case 133:
          return "LOOP";
        case 134:
          return "EXPR_VOID";
        case 135:
          return "EXPR_RESULT";
        case 136:
          return "JSR";
        case 137:
          return "SCRIPT";
        case 138:
          return "TYPEOFNAME";
        case 139:
          return "USE_STACK";
        case 140:
          return "SETPROP_OP";
        case 141:
          return "SETELEM_OP";
        case 142:
          return "LOCAL_BLOCK";
        case 143:
          return "SET_REF_OP";
        case 150:
          return "TO_OBJECT";
        case 151:
          return "TO_DOUBLE";
        case 152:
          return "GET";
        case 153:
          return "SET";
        case 154:
          return "LET";
        case 155:
          return "CONST";
        case 156:
          return "SETCONST";
        case 158:
          return "ARRAYCOMP";
        case 159:
          return "LETEXPR";
        case 160:
          return "WITHEXPR";
        case 161:
          return "DEBUGGER";
        case 162:
          return "COMMENT";
        case 163:
          return "GENEXPR";
        case 164:
          return "METHOD";
        case 165:
          return "ARROW";
        case 166:
          return "YIELD_STAR";
        default:
          string str = String.valueOf(token);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
      }
    }

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Token()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isValidToken(int code) => code >= -1 && code <= 167;

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lrhino/Token$CommentType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class CommentType : Enum
    {
      [Modifiers]
      internal static Token.CommentType __\u003C\u003ELINE;
      [Modifiers]
      internal static Token.CommentType __\u003C\u003EBLOCK_COMMENT;
      [Modifiers]
      internal static Token.CommentType __\u003C\u003EJSDOC;
      [Modifiers]
      internal static Token.CommentType __\u003C\u003EHTML;
      [Modifiers]
      private static Token.CommentType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CommentType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Token.CommentType[] values() => (Token.CommentType[]) Token.CommentType.\u0024VALUES.Clone();

      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Token.CommentType valueOf(string name) => (Token.CommentType) Enum.valueOf((Class) ClassLiteral<Token.CommentType>.Value, name);

      [LineNumberTable(new byte[] {159, 139, 173, 63, 33})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static CommentType()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.Token$CommentType"))
          return;
        Token.CommentType.__\u003C\u003ELINE = new Token.CommentType(nameof (LINE), 0);
        Token.CommentType.__\u003C\u003EBLOCK_COMMENT = new Token.CommentType(nameof (BLOCK_COMMENT), 1);
        Token.CommentType.__\u003C\u003EJSDOC = new Token.CommentType(nameof (JSDOC), 2);
        Token.CommentType.__\u003C\u003EHTML = new Token.CommentType(nameof (HTML), 3);
        Token.CommentType.\u0024VALUES = new Token.CommentType[4]
        {
          Token.CommentType.__\u003C\u003ELINE,
          Token.CommentType.__\u003C\u003EBLOCK_COMMENT,
          Token.CommentType.__\u003C\u003EJSDOC,
          Token.CommentType.__\u003C\u003EHTML
        };
      }

      [Modifiers]
      public static Token.CommentType LINE
      {
        [HideFromJava] get => Token.CommentType.__\u003C\u003ELINE;
      }

      [Modifiers]
      public static Token.CommentType BLOCK_COMMENT
      {
        [HideFromJava] get => Token.CommentType.__\u003C\u003EBLOCK_COMMENT;
      }

      [Modifiers]
      public static Token.CommentType JSDOC
      {
        [HideFromJava] get => Token.CommentType.__\u003C\u003EJSDOC;
      }

      [Modifiers]
      public static Token.CommentType HTML
      {
        [HideFromJava] get => Token.CommentType.__\u003C\u003EHTML;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        LINE,
        BLOCK_COMMENT,
        JSDOC,
        HTML,
      }
    }
  }
}
