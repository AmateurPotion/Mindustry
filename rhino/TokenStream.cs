// Decompiled with JetBrains decompiler
// Type: rhino.TokenStream
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal class TokenStream : Object
  {
    private const int EOF_CHAR = -1;
    private const char BYTE_ORDER_MARK = '\uFEFF';
    private bool dirtyLine;
    internal string regExpFlags;
    private string @string;
    private double number;
    private bool isBinary;
    private bool isOldOctal;
    private bool isOctal;
    private bool isHex;
    private int quoteChar;
    private char[] stringBuffer;
    private int stringBufferTop;
    [Modifiers]
    private ObjToIntMap allStrings;
    [Modifiers]
    private int[] ungetBuffer;
    private int ungetCursor;
    private bool hitEOF;
    private int lineStart;
    private int lineEndChar;
    internal int lineno;
    private string sourceString;
    private Reader sourceReader;
    private char[] sourceBuffer;
    private int sourceEnd;
    internal int sourceCursor;
    internal int cursor;
    internal int tokenBeg;
    internal int tokenEnd;
    internal Token.CommentType commentType;
    private bool xmlIsAttribute;
    private bool xmlIsTagContent;
    private int xmlOpenTagsCount;
    [Modifiers]
    private Parser parser;
    private string commentPrefix;
    private int commentCursor;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal int getLineno() => this.lineno;

    [LineNumberTable(new byte[] {167, 118, 103, 137, 100, 122, 198, 137, 111, 108, 226, 61, 230, 70, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal string getLine()
    {
      int sourceCursor = this.sourceCursor;
      int num1;
      if (this.lineEndChar >= 0)
      {
        num1 = sourceCursor - 1;
        if (this.lineEndChar == 10 && this.charAt(num1 - 1) == 13)
          num1 += -1;
      }
      else
      {
        int num2 = sourceCursor - this.lineStart;
        while (true)
        {
          int c = this.charAt(this.lineStart + num2);
          if (c != -1 && !ScriptRuntime.isJSLineTerminator(c))
            ++num2;
          else
            break;
        }
        num1 = this.lineStart + num2;
      }
      return this.substring(this.lineStart, num1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal int getOffset()
    {
      int num = this.sourceCursor - this.lineStart;
      if (this.lineEndChar >= 0)
        num += -1;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTokenLength() => this.tokenEnd - this.tokenBeg;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {162, 254, 103, 100, 110, 108, 98, 101, 103, 110, 108, 98, 104, 101, 233, 71, 110, 236, 69, 98, 101, 103, 101, 98, 98, 137, 98, 103, 165, 104, 99, 103, 199, 102, 130, 230, 71, 99, 104, 103, 138, 101, 226, 59, 232, 72, 101, 112, 130, 104, 98, 101, 103, 101, 103, 101, 98, 135, 113, 162, 110, 103, 130, 204, 135, 104, 230, 69, 127, 5, 103, 159, 7, 123, 196, 120, 105, 99, 119, 99, 114, 163, 191, 7, 138, 120, 195, 127, 1, 103, 99, 127, 18, 156, 104, 103, 106, 99, 103, 108, 110, 98, 103, 105, 110, 98, 103, 105, 104, 98, 137, 200, 99, 101, 109, 103, 103, 165, 112, 105, 232, 71, 159, 2, 133, 112, 130, 105, 112, 130, 103, 103, 168, 124, 112, 162, 131, 122, 99, 133, 103, 103, 136, 109, 103, 103, 106, 103, 135, 104, 112, 162, 103, 103, 168, 103, 104, 168, 169, 214, 226, 61, 97, 112, 162, 173, 105, 195, 242, 70, 103, 135, 136, 108, 105, 103, 108, 112, 162, 200, 103, 159, 54, 98, 133, 99, 133, 99, 133, 99, 133, 99, 229, 69, 99, 229, 70, 104, 104, 98, 104, 103, 104, 100, 133, 231, 58, 232, 74, 104, 98, 197, 103, 104, 100, 104, 133, 99, 103, 104, 100, 104, 104, 165, 98, 229, 69, 103, 165, 112, 102, 103, 106, 107, 103, 176, 107, 167, 103, 195, 103, 173, 104, 120, 163, 159, 161, 39, 131, 131, 131, 131, 131, 131, 131, 131, 131, 131, 131, 106, 99, 106, 131, 195, 106, 131, 163, 106, 99, 106, 131, 195, 106, 106, 131, 99, 106, 134, 195, 106, 106, 131, 131, 195, 106, 106, 106, 110, 102, 107, 134, 136, 136, 106, 106, 131, 131, 106, 131, 163, 106, 106, 106, 131, 131, 106, 131, 131, 106, 131, 163, 106, 131, 163, 134, 106, 110, 102, 107, 166, 109, 98, 110, 106, 98, 141, 171, 103, 100, 110, 112, 102, 101, 100, 101, 99, 108, 166, 98, 241, 69, 106, 131, 163, 106, 131, 163, 163, 106, 99, 106, 131, 195, 106, 101, 106, 168, 106, 107, 102, 107, 166, 133, 131, 103, 162, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal int getToken()
    {
      int c1;
      do
      {
        c1 = this.getChar();
        switch (c1)
        {
          case -1:
            this.tokenBeg = this.cursor - 1;
            this.tokenEnd = this.cursor;
            return 0;
          case 10:
            this.dirtyLine = false;
            this.tokenBeg = this.cursor - 1;
            this.tokenEnd = this.cursor;
            return 1;
          default:
            continue;
        }
      }
      while (TokenStream.isJSSpace(c1));
      if (c1 != 45)
        this.dirtyLine = true;
      this.tokenBeg = this.cursor - 1;
      this.tokenEnd = this.cursor;
      int num1 = 0;
      int num2;
      if (c1 == 92)
      {
        c1 = this.getChar();
        if (c1 == 117)
        {
          num2 = 1;
          num1 = 1;
          this.stringBufferTop = 0;
        }
        else
        {
          num2 = 0;
          this.ungetChar(c1);
          c1 = 92;
        }
      }
      else
      {
        num2 = Character.isJavaIdentifierStart((char) c1) ? 1 : 0;
        if (num2 != 0)
        {
          this.stringBufferTop = 0;
          this.addToString(c1);
        }
      }
      if (num2 != 0)
      {
        int num3 = num1;
        while (true)
        {
          while (num1 == 0)
          {
            int num4 = this.getChar();
            switch (num4)
            {
              case -1:
              case 65279:
                this.ungetChar(num4);
                string str = this.getStringFromBuffer();
                if (num3 == 0)
                {
                  int num5 = TokenStream.stringToKeyword(str, this.parser.compilerEnv.getLanguageVersion(), this.parser.inUseStrictDirective());
                  switch (num5)
                  {
                    case 0:
                      goto label_36;
                    case 73:
                    case 154:
                      if (this.parser.compilerEnv.getLanguageVersion() < 170)
                      {
                        this.@string = num5 != 154 ? "yield" : "let";
                        num5 = 39;
                        break;
                      }
                      break;
                  }
                  this.@string = (string) this.allStrings.intern((object) str);
                  if (num5 != 128 || this.parser.compilerEnv.getLanguageVersion() >= 200 || !this.parser.compilerEnv.isReservedKeywordAsIdentifier())
                    return num5;
                }
                else if (TokenStream.isKeyword(str, this.parser.compilerEnv.getLanguageVersion(), this.parser.inUseStrictDirective()))
                  str = this.convertLastCharToHex(str);
label_36:
                this.@string = (string) this.allStrings.intern((object) str);
                return 39;
              case 92:
                int num6 = this.getChar();
                if (num6 == 117)
                {
                  num1 = 1;
                  num3 = 1;
                  continue;
                }
                this.parser.addError("msg.illegal.character", num6);
                return -1;
              default:
                if (Character.isJavaIdentifierPart((char) num4))
                {
                  this.addToString(num4);
                  continue;
                }
                goto case -1;
            }
          }
          int accumulator = 0;
          for (int index = 0; index != 4; ++index)
          {
            accumulator = Kit.xDigitToInt(this.getChar(), accumulator);
            if (accumulator < 0)
              break;
          }
          if (accumulator >= 0)
          {
            this.addToString(accumulator);
            num1 = 0;
          }
          else
            break;
        }
        this.parser.addError("msg.invalid.escape");
        return -1;
      }
      if (TokenStream.isDigit(c1) || c1 == 46 && TokenStream.isDigit(this.peekChar()))
      {
        this.stringBufferTop = 0;
        int num3 = 10;
        TokenStream tokenStream1 = this;
        TokenStream tokenStream2 = this;
        TokenStream tokenStream3 = this;
        int num4 = 0;
        int num5 = num4;
        this.isBinary = num4 != 0;
        int num6 = num5;
        int num7 = num6;
        this.isOctal = num6 != 0;
        int num8 = num7;
        int num9 = num8;
        this.isOldOctal = num8 != 0;
        this.isHex = num9 != 0;
        int num10 = this.parser.compilerEnv.getLanguageVersion() >= 200 ? 1 : 0;
        if (c1 == 48)
        {
          c1 = this.getChar();
          if (c1 == 120 || c1 == 88)
          {
            num3 = 16;
            this.isHex = true;
            c1 = this.getChar();
          }
          else if (num10 != 0 && (c1 == 111 || c1 == 79))
          {
            num3 = 8;
            this.isOctal = true;
            c1 = this.getChar();
          }
          else if (num10 != 0 && (c1 == 98 || c1 == 66))
          {
            num3 = 2;
            this.isBinary = true;
            c1 = this.getChar();
          }
          else if (TokenStream.isDigit(c1))
          {
            num3 = 8;
            this.isOldOctal = true;
          }
          else
            this.addToString(48);
        }
        int num11 = 1;
        if (num3 == 16)
        {
          while (0 <= Kit.xDigitToInt(c1, 0))
          {
            this.addToString(c1);
            c1 = this.getChar();
            num11 = 0;
          }
        }
        else
        {
          while (48 <= c1 && c1 <= 57)
          {
            if (num3 == 8 && c1 >= 56)
            {
              if (this.isOldOctal)
              {
                this.parser.addWarning("msg.bad.octal.literal", c1 != 56 ? "9" : "8");
                num3 = 10;
              }
              else
              {
                this.parser.addError("msg.caught.nfe");
                return -1;
              }
            }
            else if (num3 == 2 && c1 >= 50)
            {
              this.parser.addError("msg.caught.nfe");
              return -1;
            }
            this.addToString(c1);
            c1 = this.getChar();
            num11 = 0;
          }
        }
        if (num11 != 0 && (this.isBinary || this.isOctal || this.isHex))
        {
          this.parser.addError("msg.caught.nfe");
          return -1;
        }
        int num12 = 1;
        if (num3 == 10 && (c1 == 46 || c1 == 101 || c1 == 69))
        {
          num12 = 0;
          if (c1 == 46)
          {
            do
            {
              this.addToString(c1);
              c1 = this.getChar();
            }
            while (TokenStream.isDigit(c1));
          }
          if (c1 == 101 || c1 == 69)
          {
            this.addToString(c1);
            c1 = this.getChar();
            if (c1 == 43 || c1 == 45)
            {
              this.addToString(c1);
              c1 = this.getChar();
            }
            if (!TokenStream.isDigit(c1))
            {
              this.parser.addError("msg.missing.exponent");
              return -1;
            }
            do
            {
              this.addToString(c1);
              c1 = this.getChar();
            }
            while (TokenStream.isDigit(c1));
          }
        }
        this.ungetChar(c1);
        string stringFromBuffer = this.getStringFromBuffer();
        this.@string = stringFromBuffer;
        double number;
        if (num3 == 10)
        {
          if (num12 == 0)
          {
            try
            {
              number = Double.parseDouble(stringFromBuffer);
              goto label_76;
            }
            catch (NumberFormatException ex)
            {
            }
            this.parser.addError("msg.caught.nfe");
            return -1;
          }
        }
        number = ScriptRuntime.stringPrefixToNumber(stringFromBuffer, 0, num3);
label_76:
        this.number = number;
        return 40;
      }
      if (c1 == 34 || c1 == 39 || c1 == 96)
      {
        this.quoteChar = c1;
        this.stringBufferTop = 0;
        int c2 = this.getChar(false);
label_79:
        while (c2 != this.quoteChar)
        {
          switch (c2)
          {
            case -1:
            case 10:
              this.ungetChar(c2);
              this.tokenEnd = this.cursor;
              this.parser.addError("msg.unterminated.string.lit");
              return -1;
            case 92:
              c2 = this.getChar();
              switch (c2)
              {
                case 10:
                  c2 = this.getChar();
                  continue;
                case 98:
                  c2 = 8;
                  break;
                case 102:
                  c2 = 12;
                  break;
                case 110:
                  c2 = 10;
                  break;
                case 114:
                  c2 = 13;
                  break;
                case 116:
                  c2 = 9;
                  break;
                case 117:
                  int stringBufferTop = this.stringBufferTop;
                  this.addToString(117);
                  int accumulator1 = 0;
                  for (int index = 0; index != 4; ++index)
                  {
                    c2 = this.getChar();
                    accumulator1 = Kit.xDigitToInt(c2, accumulator1);
                    if (accumulator1 >= 0)
                      this.addToString(c2);
                    else
                      goto label_79;
                  }
                  this.stringBufferTop = stringBufferTop;
                  c2 = accumulator1;
                  break;
                case 118:
                  c2 = 11;
                  break;
                case 120:
                  c2 = this.getChar();
                  int accumulator2 = Kit.xDigitToInt(c2, 0);
                  if (accumulator2 < 0)
                  {
                    this.addToString(120);
                    continue;
                  }
                  int num3 = c2;
                  c2 = this.getChar();
                  int num4 = Kit.xDigitToInt(c2, accumulator2);
                  if (num4 < 0)
                  {
                    this.addToString(120);
                    this.addToString(num3);
                    continue;
                  }
                  c2 = num4;
                  break;
                default:
                  if (48 <= c2 && c2 < 56)
                  {
                    int num5 = c2 - 48;
                    int num6 = this.getChar();
                    if (48 <= num6 && num6 < 56)
                    {
                      num5 = 8 * num5 + num6 - 48;
                      num6 = this.getChar();
                      if (48 <= num6 && num6 < 56 && num5 <= 31)
                      {
                        num5 = 8 * num5 + num6 - 48;
                        num6 = this.getChar();
                      }
                    }
                    this.ungetChar(num6);
                    c2 = num5;
                    break;
                  }
                  break;
              }
              break;
          }
          this.addToString(c2);
          c2 = this.getChar(false);
        }
        this.@string = (string) this.allStrings.intern((object) this.getStringFromBuffer());
        return 41;
      }
      switch (c1)
      {
        case 33:
          if (!this.matchChar(61))
            return 26;
          return this.matchChar(61) ? 47 : 13;
        case 37:
          return this.matchChar(61) ? 102 : 25;
        case 38:
          if (this.matchChar(38))
            return 106;
          return this.matchChar(61) ? 94 : 11;
        case 40:
          return 88;
        case 41:
          return 89;
        case 42:
          return this.matchChar(61) ? 100 : 23;
        case 43:
          if (this.matchChar(61))
            return 98;
          return this.matchChar(43) ? 107 : 21;
        case 44:
          return 90;
        case 45:
          int num13;
          if (this.matchChar(61))
            num13 = 99;
          else if (this.matchChar(45))
          {
            if (!this.dirtyLine && this.matchChar(62))
            {
              this.markCommentStart("--");
              this.skipLine();
              this.commentType = Token.CommentType.__\u003C\u003EHTML;
              return 162;
            }
            num13 = 108;
          }
          else
            num13 = 22;
          this.dirtyLine = true;
          return num13;
        case 46:
          return 109;
        case 47:
          this.markCommentStart();
          if (this.matchChar(47))
          {
            this.tokenBeg = this.cursor - 2;
            this.skipLine();
            this.commentType = Token.CommentType.__\u003C\u003ELINE;
            return 162;
          }
          if (this.matchChar(42))
          {
            int num3 = 0;
            this.tokenBeg = this.cursor - 2;
            if (this.matchChar(42))
            {
              num3 = 1;
              this.commentType = Token.CommentType.__\u003C\u003EJSDOC;
            }
            else
              this.commentType = Token.CommentType.__\u003C\u003EBLOCK_COMMENT;
            while (true)
            {
              do
              {
                switch (this.getChar())
                {
                  case -1:
                    this.tokenEnd = this.cursor - 1;
                    this.parser.addError("msg.unterminated.comment");
                    return 162;
                  case 42:
                    num3 = 1;
                    continue;
                  case 47:
                    continue;
                  default:
                    goto label_182;
                }
              }
              while (num3 == 0);
              break;
label_182:
              num3 = 0;
              this.tokenEnd = this.cursor;
            }
            this.tokenEnd = this.cursor;
            return 162;
          }
          return this.matchChar(61) ? 101 : 24;
        case 58:
          return 104;
        case 59:
          return 83;
        case 60:
          if (this.matchChar(33))
          {
            if (this.matchChar(45))
            {
              if (this.matchChar(45))
              {
                this.tokenBeg = this.cursor - 4;
                this.skipLine();
                this.commentType = Token.CommentType.__\u003C\u003EHTML;
                return 162;
              }
              this.ungetCharIgnoreLineEnd(45);
            }
            this.ungetCharIgnoreLineEnd(33);
          }
          return this.matchChar(60) ? (this.matchChar(61) ? 95 : 18) : (this.matchChar(61) ? 15 : 14);
        case 61:
          return this.matchChar(61) ? (this.matchChar(61) ? 46 : 12) : (this.matchChar(62) ? 165 : 91);
        case 62:
          return this.matchChar(62) ? (this.matchChar(62) ? (this.matchChar(61) ? 97 : 20) : (this.matchChar(61) ? 96 : 19)) : (this.matchChar(61) ? 17 : 16);
        case 63:
          return 103;
        case 91:
          return 84;
        case 93:
          return 85;
        case 94:
          return this.matchChar(61) ? 93 : 10;
        case 123:
          return 86;
        case 124:
          if (this.matchChar(124))
            return 105;
          return this.matchChar(61) ? 92 : 9;
        case 125:
          return 87;
        case 126:
          return 27;
        default:
          this.parser.addError("msg.illegal.character", c1);
          return -1;
      }
    }

    [LineNumberTable(new byte[] {168, 0, 104, 110, 152, 110, 103, 125, 49, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal string getAndResetCurrentComment()
    {
      if (this.sourceString != null)
      {
        if (this.isMarkingComment())
          Kit.codeBug();
        return String.instancehelper_substring(this.sourceString, this.tokenBeg, this.tokenEnd);
      }
      if (!this.isMarkingComment())
        Kit.codeBug();
      this.commentCursor = -1;
      return new StringBuilder().append(this.commentPrefix).append(String.valueOf(this.sourceBuffer, this.commentCursor, this.getTokenLength() - String.instancehelper_length(this.commentPrefix))).toString();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal bool eof() => this.hitEOF;

    [LineNumberTable(new byte[] {159, 169, 232, 168, 120, 235, 74, 144, 173, 172, 135, 103, 231, 95, 107, 231, 151, 84, 103, 104, 99, 105, 103, 112, 137, 105, 103, 140, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal TokenStream([In] Parser obj0, [In] Reader obj1, [In] string obj2, [In] int obj3)
    {
      TokenStream tokenStream1 = this;
      this.@string = "";
      this.stringBuffer = new char[128];
      this.allStrings = new ObjToIntMap(50);
      this.ungetBuffer = new int[3];
      this.hitEOF = false;
      this.lineStart = 0;
      this.lineEndChar = -1;
      this.commentPrefix = "";
      this.commentCursor = -1;
      this.parser = obj0;
      this.lineno = obj3;
      if (obj1 != null)
      {
        if (obj2 != null)
          Kit.codeBug();
        this.sourceReader = obj1;
        this.sourceBuffer = new char[512];
        this.sourceEnd = 0;
      }
      else
      {
        if (obj2 == null)
          Kit.codeBug();
        this.sourceString = obj2;
        this.sourceEnd = String.instancehelper_length(obj2);
      }
      TokenStream tokenStream2 = this;
      int num1 = 0;
      int num2 = num1;
      this.cursor = num1;
      this.sourceCursor = num2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal string getString() => this.@string;

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isKeyword([In] string obj0, [In] int obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      return 0 != TokenStream.stringToKeyword(obj0, obj1, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal bool isNumberOldOctal() => this.isOldOctal;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal bool isNumberBinary() => this.isBinary;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal bool isNumberOctal() => this.isOctal;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal bool isNumberHex() => this.isHex;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal double getNumber() => this.number;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {165, 89, 103, 103, 133, 138, 107, 106, 110, 120, 112, 193, 130, 114, 105, 103, 110, 120, 112, 129, 101, 103, 103, 105, 103, 110, 120, 112, 129, 101, 100, 101, 130, 140, 167, 106, 106, 106, 106, 106, 106, 106, 202, 144, 109, 176, 115, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void readRegExp([In] int obj0)
    {
      int tokenBeg = this.tokenBeg;
      this.stringBufferTop = 0;
      switch (obj0)
      {
        case 24:
          if (this.peekChar() == 42)
          {
            this.tokenEnd = this.cursor - 1;
            this.@string = String.newhelper(this.stringBuffer, 0, this.stringBufferTop);
            this.parser.reportError("msg.unterminated.re.lit");
            return;
          }
          break;
        case 101:
          this.addToString(61);
          break;
        default:
          Kit.codeBug();
          goto case 24;
      }
      int num1 = 0;
      int num2;
      while ((num2 = this.getChar()) != 47 || num1 != 0)
      {
        switch (num2)
        {
          case -1:
          case 10:
            this.ungetChar(num2);
            this.tokenEnd = this.cursor - 1;
            this.@string = String.newhelper(this.stringBuffer, 0, this.stringBufferTop);
            this.parser.reportError("msg.unterminated.re.lit");
            return;
          case 91:
            num1 = 1;
            break;
          case 92:
            this.addToString(num2);
            num2 = this.getChar();
            if (num2 == 10 || num2 == -1)
            {
              this.ungetChar(num2);
              this.tokenEnd = this.cursor - 1;
              this.@string = String.newhelper(this.stringBuffer, 0, this.stringBufferTop);
              this.parser.reportError("msg.unterminated.re.lit");
              return;
            }
            break;
          case 93:
            num1 = 0;
            break;
        }
        this.addToString(num2);
      }
      int stringBufferTop = this.stringBufferTop;
      while (true)
      {
        while (!this.matchChar(103))
        {
          if (this.matchChar(105))
            this.addToString(105);
          else if (this.matchChar(109))
            this.addToString(109);
          else if (this.matchChar(121))
          {
            this.addToString(121);
          }
          else
          {
            this.tokenEnd = tokenBeg + this.stringBufferTop + 2;
            if (TokenStream.isAlpha(this.peekChar()))
              this.parser.reportError("msg.invalid.re.flag");
            this.@string = String.newhelper(this.stringBuffer, 0, stringBufferTop);
            this.regExpFlags = String.newhelper(this.stringBuffer, stringBufferTop, this.stringBufferTop - stringBufferTop);
            return;
          }
        }
        this.addToString(103);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string readAndClearRegExpFlags()
    {
      string regExpFlags = this.regExpFlags;
      this.regExpFlags = (string) null;
      return regExpFlags;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal char getQuoteChar() => (char) this.quoteChar;

    [LineNumberTable(new byte[] {167, 140, 127, 0, 119, 112, 103, 132, 162, 100, 103, 118, 107, 105, 147, 100, 132, 100, 228, 54, 237, 78, 102, 100, 107, 105, 99, 226, 60, 236, 71, 120, 101, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal string getLine([In] int obj0, [In] int[] obj1)
    {
      if (!TokenStream.\u0024assertionsDisabled && (obj0 < 0 || obj0 > this.cursor))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (!TokenStream.\u0024assertionsDisabled && obj1.Length != 2)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      int num1 = this.cursor + this.ungetCursor - obj0;
      int sourceCursor = this.sourceCursor;
      if (num1 > sourceCursor)
        return (string) null;
      int num2 = 0;
      int num3 = 0;
      while (num1 > 0)
      {
        if (!TokenStream.\u0024assertionsDisabled && sourceCursor <= 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
        int c = this.charAt(sourceCursor - 1);
        if (ScriptRuntime.isJSLineTerminator(c))
        {
          if (c == 10 && this.charAt(sourceCursor - 2) == 13)
          {
            num1 += -1;
            sourceCursor += -1;
          }
          ++num3;
          num2 = sourceCursor - 1;
        }
        num1 += -1;
        sourceCursor += -1;
      }
      int num4 = 0;
      int num5 = 0;
      while (sourceCursor > 0)
      {
        if (ScriptRuntime.isJSLineTerminator(this.charAt(sourceCursor - 1)))
        {
          num4 = sourceCursor;
          break;
        }
        sourceCursor += -1;
        ++num5;
      }
      obj1[0] = this.lineno - num3 + (this.lineEndChar >= 0 ? 1 : 0);
      obj1[1] = num5;
      return num3 == 0 ? this.getLine() : this.substring(num4, num2);
    }

    [LineNumberTable(new byte[] {159, 125, 162, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int stringToKeyword([In] string obj0, [In] int obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      return obj1 < 200 ? TokenStream.stringToKeywordForJS(obj0) : TokenStream.stringToKeywordForES(obj0, num != 0);
    }

    [LineNumberTable(new byte[] {34, 99, 99, 99, 99, 99, 99, 99, 102, 99, 99, 99, 99, 99, 102, 99, 99, 98, 99, 99, 99, 99, 99, 99, 99, 99, 163, 102, 102, 102, 99, 102, 102, 102, 102, 102, 102, 102, 102, 99, 102, 102, 102, 102, 99, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 99, 102, 102, 99, 166, 194, 98, 162, 159, 31, 104, 101, 110, 99, 133, 101, 110, 99, 133, 104, 110, 99, 229, 69, 159, 57, 124, 99, 197, 124, 102, 197, 124, 102, 197, 124, 99, 197, 124, 99, 197, 124, 99, 197, 133, 159, 77, 102, 102, 133, 104, 101, 124, 99, 133, 104, 124, 102, 229, 69, 104, 101, 124, 99, 133, 104, 124, 102, 229, 69, 102, 102, 133, 102, 102, 133, 102, 99, 133, 104, 101, 124, 99, 133, 104, 124, 99, 229, 69, 102, 99, 133, 102, 99, 133, 133, 159, 69, 102, 102, 133, 104, 101, 102, 104, 104, 102, 200, 102, 99, 133, 102, 99, 133, 104, 101, 102, 107, 104, 102, 203, 104, 101, 102, 107, 104, 102, 203, 102, 102, 133, 102, 99, 133, 102, 99, 133, 133, 159, 89, 102, 102, 133, 104, 101, 102, 104, 104, 102, 199, 102, 102, 133, 102, 102, 133, 102, 102, 133, 102, 102, 133, 102, 102, 133, 102, 99, 133, 102, 102, 133, 102, 99, 133, 133, 159, 30, 102, 102, 133, 102, 99, 133, 102, 99, 133, 102, 102, 133, 102, 102, 133, 102, 102, 133, 133, 159, 19, 102, 102, 133, 102, 99, 133, 102, 102, 133, 102, 99, 133, 102, 102, 133, 133, 104, 101, 102, 107, 101, 102, 107, 101, 102, 200, 104, 101, 102, 104, 101, 102, 197, 102, 166, 215, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int stringToKeywordForJS([In] string obj0)
    {
      string str1 = obj0;
      int num = 0;
      string str2 = (string) null;
      switch (String.instancehelper_length(str1))
      {
        case 2:
          switch (String.instancehelper_charAt(str1, 1))
          {
            case 'f':
              if (String.instancehelper_charAt(str1, 0) == 'i')
              {
                num = 113;
                break;
              }
              goto label_93;
            case 'n':
              if (String.instancehelper_charAt(str1, 0) == 'i')
              {
                num = 52;
                break;
              }
              goto label_93;
            case 'o':
              if (String.instancehelper_charAt(str1, 0) == 'd')
              {
                num = 119;
                break;
              }
              goto label_93;
            default:
              goto label_93;
          }
          break;
        case 3:
          switch (String.instancehelper_charAt(str1, 0))
          {
            case 'f':
              if (String.instancehelper_charAt(str1, 2) == 'r' && String.instancehelper_charAt(str1, 1) == 'o')
              {
                num = 120;
                break;
              }
              goto label_93;
            case 'i':
              if (String.instancehelper_charAt(str1, 2) == 't' && String.instancehelper_charAt(str1, 1) == 'n')
              {
                num = 128;
                break;
              }
              goto label_93;
            case 'l':
              if (String.instancehelper_charAt(str1, 2) == 't' && String.instancehelper_charAt(str1, 1) == 'e')
              {
                num = 154;
                break;
              }
              goto label_93;
            case 'n':
              if (String.instancehelper_charAt(str1, 2) == 'w' && String.instancehelper_charAt(str1, 1) == 'e')
              {
                num = 30;
                break;
              }
              goto label_93;
            case 't':
              if (String.instancehelper_charAt(str1, 2) == 'y' && String.instancehelper_charAt(str1, 1) == 'r')
              {
                num = 82;
                break;
              }
              goto label_93;
            case 'v':
              if (String.instancehelper_charAt(str1, 2) == 'r' && String.instancehelper_charAt(str1, 1) == 'a')
              {
                num = 123;
                break;
              }
              goto label_93;
            default:
              goto label_93;
          }
          break;
        case 4:
          switch (String.instancehelper_charAt(str1, 0))
          {
            case 'b':
              str2 = "byte";
              num = 128;
              goto label_93;
            case 'c':
              switch (String.instancehelper_charAt(str1, 3))
              {
                case 'e':
                  if (String.instancehelper_charAt(str1, 2) == 's' && String.instancehelper_charAt(str1, 1) == 'a')
                  {
                    num = 116;
                    break;
                  }
                  goto label_93;
                case 'r':
                  if (String.instancehelper_charAt(str1, 2) == 'a' && String.instancehelper_charAt(str1, 1) == 'h')
                  {
                    num = 128;
                    break;
                  }
                  goto label_93;
                default:
                  goto label_93;
              }
              break;
            case 'e':
              switch (String.instancehelper_charAt(str1, 3))
              {
                case 'e':
                  if (String.instancehelper_charAt(str1, 2) == 's' && String.instancehelper_charAt(str1, 1) == 'l')
                  {
                    num = 114;
                    break;
                  }
                  goto label_93;
                case 'm':
                  if (String.instancehelper_charAt(str1, 2) == 'u' && String.instancehelper_charAt(str1, 1) == 'n')
                  {
                    num = 128;
                    break;
                  }
                  goto label_93;
                default:
                  goto label_93;
              }
              break;
            case 'g':
              str2 = "goto";
              num = 128;
              goto label_93;
            case 'l':
              str2 = "long";
              num = 128;
              goto label_93;
            case 'n':
              str2 = "null";
              num = 42;
              goto label_93;
            case 't':
              switch (String.instancehelper_charAt(str1, 3))
              {
                case 'e':
                  if (String.instancehelper_charAt(str1, 2) == 'u' && String.instancehelper_charAt(str1, 1) == 'r')
                  {
                    num = 45;
                    break;
                  }
                  goto label_93;
                case 's':
                  if (String.instancehelper_charAt(str1, 2) == 'i' && String.instancehelper_charAt(str1, 1) == 'h')
                  {
                    num = 43;
                    break;
                  }
                  goto label_93;
                default:
                  goto label_93;
              }
              break;
            case 'v':
              str2 = "void";
              num = (int) sbyte.MaxValue;
              goto label_93;
            case 'w':
              str2 = "with";
              num = 124;
              goto label_93;
            default:
              goto label_93;
          }
        case 5:
          switch (String.instancehelper_charAt(str1, 2))
          {
            case 'a':
              str2 = "class";
              num = 128;
              goto label_93;
            case 'e':
              switch (String.instancehelper_charAt(str1, 0))
              {
                case 'b':
                  str2 = "break";
                  num = 121;
                  goto label_93;
                case 'y':
                  str2 = "yield";
                  num = 73;
                  goto label_93;
                default:
                  goto label_93;
              }
            case 'i':
              str2 = "while";
              num = 118;
              goto label_93;
            case 'l':
              str2 = "false";
              num = 44;
              goto label_93;
            case 'n':
              switch (String.instancehelper_charAt(str1, 0))
              {
                case 'c':
                  str2 = "const";
                  num = 155;
                  goto label_93;
                case 'f':
                  str2 = "final";
                  num = 128;
                  goto label_93;
                default:
                  goto label_93;
              }
            case 'o':
              switch (String.instancehelper_charAt(str1, 0))
              {
                case 'f':
                  str2 = "float";
                  num = 128;
                  goto label_93;
                case 's':
                  str2 = "short";
                  num = 128;
                  goto label_93;
                default:
                  goto label_93;
              }
            case 'p':
              str2 = "super";
              num = 128;
              goto label_93;
            case 'r':
              str2 = "throw";
              num = 50;
              goto label_93;
            case 't':
              str2 = "catch";
              num = 125;
              goto label_93;
            default:
              goto label_93;
          }
        case 6:
          switch (String.instancehelper_charAt(str1, 1))
          {
            case 'a':
              str2 = "native";
              num = 128;
              goto label_93;
            case 'e':
              switch (String.instancehelper_charAt(str1, 0))
              {
                case 'd':
                  str2 = "delete";
                  num = 31;
                  goto label_93;
                case 'r':
                  str2 = "return";
                  num = 4;
                  goto label_93;
                default:
                  goto label_93;
              }
            case 'h':
              str2 = "throws";
              num = 128;
              goto label_93;
            case 'm':
              str2 = "import";
              num = 128;
              goto label_93;
            case 'o':
              str2 = "double";
              num = 128;
              goto label_93;
            case 't':
              str2 = "static";
              num = 128;
              goto label_93;
            case 'u':
              str2 = "public";
              num = 128;
              goto label_93;
            case 'w':
              str2 = "switch";
              num = 115;
              goto label_93;
            case 'x':
              str2 = "export";
              num = 128;
              goto label_93;
            case 'y':
              str2 = "typeof";
              num = 32;
              goto label_93;
            default:
              goto label_93;
          }
        case 7:
          switch (String.instancehelper_charAt(str1, 1))
          {
            case 'a':
              str2 = "package";
              num = 128;
              goto label_93;
            case 'e':
              str2 = "default";
              num = 117;
              goto label_93;
            case 'i':
              str2 = "finally";
              num = 126;
              goto label_93;
            case 'o':
              str2 = "boolean";
              num = 128;
              goto label_93;
            case 'r':
              str2 = "private";
              num = 128;
              goto label_93;
            case 'x':
              str2 = "extends";
              num = 128;
              goto label_93;
            default:
              goto label_93;
          }
        case 8:
          switch (String.instancehelper_charAt(str1, 0))
          {
            case 'a':
              str2 = "abstract";
              num = 128;
              goto label_93;
            case 'c':
              str2 = "continue";
              num = 122;
              goto label_93;
            case 'd':
              str2 = "debugger";
              num = 161;
              goto label_93;
            case 'f':
              str2 = "function";
              num = 110;
              goto label_93;
            case 'v':
              str2 = "volatile";
              num = 128;
              goto label_93;
            default:
              goto label_93;
          }
        case 9:
          switch (String.instancehelper_charAt(str1, 0))
          {
            case 'i':
              str2 = "interface";
              num = 128;
              goto label_93;
            case 'p':
              str2 = "protected";
              num = 128;
              goto label_93;
            case 't':
              str2 = "transient";
              num = 128;
              goto label_93;
            default:
              goto label_93;
          }
        case 10:
          switch (String.instancehelper_charAt(str1, 1))
          {
            case 'm':
              str2 = "implements";
              num = 128;
              goto label_93;
            case 'n':
              str2 = "instanceof";
              num = 53;
              goto label_93;
            default:
              goto label_93;
          }
        case 12:
          str2 = "synchronized";
          num = 128;
          goto default;
        default:
label_93:
          if (str2 != null && !object.ReferenceEquals((object) str2, (object) str1) && !String.instancehelper_equals(str2, (object) str1))
          {
            num = 0;
            break;
          }
          break;
      }
      return num == 0 ? 0 : num & (int) byte.MaxValue;
    }

    [LineNumberTable(new byte[] {159, 19, 98, 99, 99, 99, 102, 102, 99, 102, 99, 99, 99, 99, 102, 102, 99, 99, 99, 99, 102, 99, 99, 99, 98, 102, 99, 99, 99, 99, 99, 99, 99, 99, 99, 163, 102, 166, 102, 102, 102, 102, 102, 166, 99, 99, 195, 102, 166, 194, 98, 162, 159, 23, 105, 102, 110, 99, 133, 102, 110, 99, 133, 105, 110, 99, 229, 69, 159, 31, 124, 99, 197, 124, 102, 197, 124, 99, 197, 124, 99, 197, 124, 99, 197, 133, 159, 45, 105, 105, 124, 99, 229, 69, 105, 102, 124, 99, 133, 105, 124, 102, 229, 69, 102, 99, 133, 105, 102, 124, 99, 133, 105, 124, 99, 229, 69, 102, 99, 133, 102, 99, 133, 133, 159, 69, 105, 102, 102, 107, 105, 102, 203, 105, 102, 102, 104, 105, 102, 200, 102, 99, 133, 102, 99, 133, 102, 102, 133, 102, 102, 133, 102, 99, 133, 102, 99, 133, 133, 159, 73, 105, 102, 102, 104, 105, 102, 199, 102, 102, 133, 99, 102, 102, 197, 99, 102, 102, 197, 102, 99, 133, 102, 102, 133, 102, 99, 133, 133, 159, 22, 99, 102, 102, 197, 102, 99, 133, 102, 99, 133, 99, 102, 102, 197, 102, 102, 133, 133, 159, 2, 102, 99, 133, 102, 102, 133, 102, 99, 133, 133, 105, 105, 102, 107, 105, 102, 200, 105, 105, 102, 104, 102, 102, 195, 215, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int stringToKeywordForES([In] string obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      string str1 = obj0;
      int num2 = 0;
      string str2 = (string) null;
      switch (String.instancehelper_length(str1))
      {
        case 2:
          switch (String.instancehelper_charAt(str1, 1))
          {
            case 'f':
              if (String.instancehelper_charAt(str1, 0) == 'i')
              {
                num2 = 113;
                break;
              }
              goto label_80;
            case 'n':
              if (String.instancehelper_charAt(str1, 0) == 'i')
              {
                num2 = 52;
                break;
              }
              goto label_80;
            case 'o':
              if (String.instancehelper_charAt(str1, 0) == 'd')
              {
                num2 = 119;
                break;
              }
              goto label_80;
            default:
              goto label_80;
          }
          break;
        case 3:
          switch (String.instancehelper_charAt(str1, 0))
          {
            case 'f':
              if (String.instancehelper_charAt(str1, 2) == 'r' && String.instancehelper_charAt(str1, 1) == 'o')
              {
                num2 = 120;
                break;
              }
              goto label_80;
            case 'l':
              if (String.instancehelper_charAt(str1, 2) == 't' && String.instancehelper_charAt(str1, 1) == 'e')
              {
                num2 = 154;
                break;
              }
              goto label_80;
            case 'n':
              if (String.instancehelper_charAt(str1, 2) == 'w' && String.instancehelper_charAt(str1, 1) == 'e')
              {
                num2 = 30;
                break;
              }
              goto label_80;
            case 't':
              if (String.instancehelper_charAt(str1, 2) == 'y' && String.instancehelper_charAt(str1, 1) == 'r')
              {
                num2 = 82;
                break;
              }
              goto label_80;
            case 'v':
              if (String.instancehelper_charAt(str1, 2) == 'r' && String.instancehelper_charAt(str1, 1) == 'a')
              {
                num2 = 123;
                break;
              }
              goto label_80;
            default:
              goto label_80;
          }
          break;
        case 4:
          switch (String.instancehelper_charAt(str1, 0))
          {
            case 'c':
              if (String.instancehelper_charAt(str1, 3) == 'e' && String.instancehelper_charAt(str1, 2) == 's' && String.instancehelper_charAt(str1, 1) == 'a')
              {
                num2 = 116;
                break;
              }
              goto label_80;
            case 'e':
              switch (String.instancehelper_charAt(str1, 3))
              {
                case 'e':
                  if (String.instancehelper_charAt(str1, 2) == 's' && String.instancehelper_charAt(str1, 1) == 'l')
                  {
                    num2 = 114;
                    break;
                  }
                  goto label_80;
                case 'm':
                  if (String.instancehelper_charAt(str1, 2) == 'u' && String.instancehelper_charAt(str1, 1) == 'n')
                  {
                    num2 = 128;
                    break;
                  }
                  goto label_80;
                default:
                  goto label_80;
              }
              break;
            case 'n':
              str2 = "null";
              num2 = 42;
              goto label_80;
            case 't':
              switch (String.instancehelper_charAt(str1, 3))
              {
                case 'e':
                  if (String.instancehelper_charAt(str1, 2) == 'u' && String.instancehelper_charAt(str1, 1) == 'r')
                  {
                    num2 = 45;
                    break;
                  }
                  goto label_80;
                case 's':
                  if (String.instancehelper_charAt(str1, 2) == 'i' && String.instancehelper_charAt(str1, 1) == 'h')
                  {
                    num2 = 43;
                    break;
                  }
                  goto label_80;
                default:
                  goto label_80;
              }
              break;
            case 'v':
              str2 = "void";
              num2 = (int) sbyte.MaxValue;
              goto label_80;
            case 'w':
              str2 = "with";
              num2 = 124;
              goto label_80;
            default:
              goto label_80;
          }
          break;
        case 5:
          switch (String.instancehelper_charAt(str1, 2))
          {
            case 'a':
              switch (String.instancehelper_charAt(str1, 0))
              {
                case 'a':
                  str2 = "await";
                  num2 = 128;
                  goto label_80;
                case 'c':
                  str2 = "class";
                  num2 = 128;
                  goto label_80;
                default:
                  goto label_80;
              }
            case 'e':
              switch (String.instancehelper_charAt(str1, 0))
              {
                case 'b':
                  str2 = "break";
                  num2 = 121;
                  goto label_80;
                case 'y':
                  str2 = "yield";
                  num2 = 73;
                  goto label_80;
                default:
                  goto label_80;
              }
            case 'i':
              str2 = "while";
              num2 = 118;
              goto label_80;
            case 'l':
              str2 = "false";
              num2 = 44;
              goto label_80;
            case 'n':
              str2 = "const";
              num2 = 155;
              goto label_80;
            case 'p':
              str2 = "super";
              num2 = 128;
              goto label_80;
            case 'r':
              str2 = "throw";
              num2 = 50;
              goto label_80;
            case 't':
              str2 = "catch";
              num2 = 125;
              goto label_80;
            default:
              goto label_80;
          }
        case 6:
          switch (String.instancehelper_charAt(str1, 1))
          {
            case 'e':
              switch (String.instancehelper_charAt(str1, 0))
              {
                case 'd':
                  str2 = "delete";
                  num2 = 31;
                  goto label_80;
                case 'r':
                  str2 = "return";
                  num2 = 4;
                  goto label_80;
                default:
                  goto label_80;
              }
            case 'm':
              str2 = "import";
              num2 = 128;
              goto label_80;
            case 't':
              if (num1 != 0)
              {
                str2 = "static";
                num2 = 128;
                goto label_80;
              }
              else
                goto case 'u';
            case 'u':
              if (num1 != 0)
              {
                str2 = "public";
                num2 = 128;
                goto label_80;
              }
              else
                goto case 'w';
            case 'w':
              str2 = "switch";
              num2 = 115;
              goto label_80;
            case 'x':
              str2 = "export";
              num2 = 128;
              goto label_80;
            case 'y':
              str2 = "typeof";
              num2 = 32;
              goto label_80;
            default:
              goto label_80;
          }
        case 7:
          switch (String.instancehelper_charAt(str1, 1))
          {
            case 'a':
              if (num1 != 0)
              {
                str2 = "package";
                num2 = 128;
                goto label_80;
              }
              else
                goto case 'e';
            case 'e':
              str2 = "default";
              num2 = 117;
              goto label_80;
            case 'i':
              str2 = "finally";
              num2 = 126;
              goto label_80;
            case 'r':
              if (num1 != 0)
              {
                str2 = "private";
                num2 = 128;
                goto label_80;
              }
              else
                goto case 'x';
            case 'x':
              str2 = "extends";
              num2 = 128;
              goto label_80;
            default:
              goto label_80;
          }
        case 8:
          switch (String.instancehelper_charAt(str1, 0))
          {
            case 'c':
              str2 = "continue";
              num2 = 122;
              goto label_80;
            case 'd':
              str2 = "debugger";
              num2 = 161;
              goto label_80;
            case 'f':
              str2 = "function";
              num2 = 110;
              goto label_80;
            default:
              goto label_80;
          }
        case 9:
          int num3 = (int) String.instancehelper_charAt(str1, 0);
          if (num3 == 105 && num1 != 0)
          {
            str2 = "interface";
            num2 = 128;
            goto default;
          }
          else if (num3 == 112 && num1 != 0)
          {
            str2 = "protected";
            num2 = 128;
            goto default;
          }
          else
            goto default;
        case 10:
          int num4 = (int) String.instancehelper_charAt(str1, 1);
          if (num4 == 109 && num1 != 0)
          {
            str2 = "implements";
            num2 = 128;
            goto default;
          }
          else if (num4 == 110)
          {
            str2 = "instanceof";
            num2 = 53;
            goto default;
          }
          else
            goto default;
        default:
label_80:
          if (str2 != null && !object.ReferenceEquals((object) str2, (object) str1) && !String.instancehelper_equals(str2, (object) str1))
          {
            num2 = 0;
            break;
          }
          break;
      }
      return num2 == 0 ? 0 : num2 & (int) byte.MaxValue;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(1860)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getChar() => this.getChar(true);

    [LineNumberTable(new byte[] {165, 73, 101, 153, 114, 45})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isJSSpace([In] int obj0) => obj0 <= (int) sbyte.MaxValue ? obj0 == 32 || obj0 == 9 || (obj0 == 12 || obj0 == 11) : obj0 == 160 || obj0 == 65279 || Character.getType((char) obj0) == 12;

    [LineNumberTable(new byte[] {166, 187, 123, 102, 123, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void ungetChar([In] int obj0)
    {
      if (this.ungetCursor != 0 && this.ungetBuffer[this.ungetCursor - 1] == 10)
        Kit.codeBug();
      int[] ungetBuffer = this.ungetBuffer;
      TokenStream tokenStream1 = this;
      int ungetCursor = tokenStream1.ungetCursor;
      TokenStream tokenStream2 = tokenStream1;
      int index = ungetCursor;
      tokenStream2.ungetCursor = ungetCursor + 1;
      int num = obj0;
      ungetBuffer[index] = num;
      --this.cursor;
    }

    [LineNumberTable(new byte[] {166, 171, 103, 106, 111, 111, 135, 106, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addToString([In] int obj0)
    {
      int stringBufferTop = this.stringBufferTop;
      if (stringBufferTop == this.stringBuffer.Length)
      {
        char[] chArray = new char[this.stringBuffer.Length * 2];
        ByteCodeHelper.arraycopy_primitive_2((Array) this.stringBuffer, 0, (Array) chArray, 0, stringBufferTop);
        this.stringBuffer = chArray;
      }
      this.stringBuffer[stringBufferTop] = (char) obj0;
      this.stringBufferTop = stringBufferTop + 1;
    }

    [LineNumberTable(new byte[] {166, 166, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string getStringFromBuffer()
    {
      this.tokenEnd = this.cursor;
      return String.newhelper(this.stringBuffer, 0, this.stringBufferTop);
    }

    [LineNumberTable(new byte[] {168, 12, 105, 99, 107, 108, 109, 109, 41, 166, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string convertLastCharToHex([In] string obj0)
    {
      int num = String.instancehelper_length(obj0) - 1;
      StringBuilder stringBuilder = new StringBuilder(String.instancehelper_substring(obj0, 0, num));
      stringBuilder.append("\\u");
      string hexString = Integer.toHexString((int) String.instancehelper_charAt(obj0, num));
      for (int index = 0; index < 4 - String.instancehelper_length(hexString); ++index)
        stringBuilder.append('0');
      stringBuilder.append(hexString);
      return stringBuilder.toString();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isDigit([In] int obj0) => 48 <= obj0 && obj0 <= 57;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 204, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int peekChar()
    {
      int num = this.getChar();
      this.ungetChar(num);
      return num;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {157, 188, 66, 104, 110, 251, 69, 104, 110, 103, 130, 110, 159, 2, 110, 104, 103, 162, 110, 187, 105, 111, 104, 133, 103, 110, 174, 101, 106, 103, 165, 106, 107, 133, 104, 103, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getChar([In] bool obj0)
    {
      int num1 = obj0 ? 1 : 0;
      if (this.ungetCursor != 0)
      {
        ++this.cursor;
        int[] ungetBuffer = this.ungetBuffer;
        TokenStream tokenStream1 = this;
        int num2 = tokenStream1.ungetCursor - 1;
        TokenStream tokenStream2 = tokenStream1;
        int index = num2;
        tokenStream2.ungetCursor = num2;
        return ungetBuffer[index];
      }
      int c;
      do
      {
        if (this.sourceString != null)
        {
          if (this.sourceCursor == this.sourceEnd)
          {
            this.hitEOF = true;
            return -1;
          }
          ++this.cursor;
          string sourceString = this.sourceString;
          TokenStream tokenStream1 = this;
          int sourceCursor = tokenStream1.sourceCursor;
          TokenStream tokenStream2 = tokenStream1;
          int num2 = sourceCursor;
          tokenStream2.sourceCursor = sourceCursor + 1;
          c = (int) String.instancehelper_charAt(sourceString, num2);
        }
        else
        {
          if (this.sourceCursor == this.sourceEnd && !this.fillSourceBuffer())
          {
            this.hitEOF = true;
            return -1;
          }
          ++this.cursor;
          char[] sourceBuffer = this.sourceBuffer;
          TokenStream tokenStream1 = this;
          int sourceCursor = tokenStream1.sourceCursor;
          TokenStream tokenStream2 = tokenStream1;
          int index = sourceCursor;
          tokenStream2.sourceCursor = sourceCursor + 1;
          c = (int) sourceBuffer[index];
        }
        if (this.lineEndChar >= 0)
        {
          if (this.lineEndChar == 13 && c == 10)
          {
            this.lineEndChar = 10;
            continue;
          }
          this.lineEndChar = -1;
          this.lineStart = this.sourceCursor - 1;
          ++this.lineno;
        }
        if (c <= (int) sbyte.MaxValue)
        {
          if (c == 10 || c == 13)
          {
            this.lineEndChar = c;
            c = 10;
            goto label_21;
          }
          else
            goto label_21;
        }
        else if (c == 65279)
          return c;
      }
      while (num1 != 0 && TokenStream.isJSFormatChar(c));
      if (ScriptRuntime.isJSLineTerminator(c))
      {
        this.lineEndChar = c;
        c = 10;
      }
label_21:
      return c;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 194, 103, 100, 108, 130, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool matchChar([In] int obj0)
    {
      int charIgnoreLineEnd = this.getCharIgnoreLineEnd();
      if (charIgnoreLineEnd == obj0)
      {
        this.tokenEnd = this.cursor;
        return true;
      }
      this.ungetCharIgnoreLineEnd(charIgnoreLineEnd);
      return false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {167, 65, 146, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void skipLine()
    {
      int num;
      do
        ;
      while ((num = this.getChar()) != -1 && num != 10);
      this.ungetChar(num);
      this.tokenEnd = this.cursor;
    }

    [LineNumberTable(new byte[] {167, 58, 123, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void ungetCharIgnoreLineEnd([In] int obj0)
    {
      int[] ungetBuffer = this.ungetBuffer;
      TokenStream tokenStream1 = this;
      int ungetCursor = tokenStream1.ungetCursor;
      TokenStream tokenStream2 = tokenStream1;
      int index = ungetCursor;
      tokenStream2.ungetCursor = ungetCursor + 1;
      int num = obj0;
      ungetBuffer[index] = num;
      --this.cursor;
    }

    [LineNumberTable(new byte[] {167, 241, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void markCommentStart() => this.markCommentStart("");

    [LineNumberTable(new byte[] {167, 245, 122, 103, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void markCommentStart([In] string obj0)
    {
      if (!this.parser.compilerEnv.isRecordingComments() || this.sourceReader == null)
        return;
      this.commentPrefix = obj0;
      this.commentCursor = this.sourceCursor - 1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isAlpha([In] int obj0)
    {
      if (obj0 <= 90)
        return 65 <= obj0;
      return 97 <= obj0 && obj0 <= 122;
    }

    [LineNumberTable(1832)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool canUngetChar() => this.ungetCursor == 0 || this.ungetBuffer[this.ungetCursor - 1] != 10;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {165, 177, 108, 135, 110, 107, 159, 69, 103, 103, 103, 133, 103, 109, 103, 103, 103, 243, 69, 103, 174, 103, 103, 229, 69, 103, 133, 103, 103, 165, 143, 103, 103, 159, 6, 103, 103, 103, 151, 103, 103, 103, 101, 103, 173, 103, 103, 112, 194, 103, 103, 110, 106, 106, 106, 106, 105, 104, 104, 104, 104, 104, 104, 205, 103, 103, 112, 194, 237, 69, 103, 103, 205, 103, 103, 136, 103, 103, 112, 130, 103, 110, 162, 103, 110, 194, 231, 159, 136, 236, 160, 126, 108, 103, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getNextXMLToken()
    {
      this.tokenBeg = this.cursor;
      this.stringBufferTop = 0;
      for (int index = this.getChar(); index != -1; index = this.getChar())
      {
        if (this.xmlIsTagContent)
        {
          switch (index)
          {
            case 9:
            case 10:
            case 13:
            case 32:
              this.addToString(index);
              continue;
            case 34:
            case 39:
              this.addToString(index);
              if (!this.readQuotedString(index))
                return -1;
              continue;
            case 47:
              this.addToString(index);
              if (this.peekChar() == 62)
              {
                this.addToString(this.getChar());
                this.xmlIsTagContent = false;
                --this.xmlOpenTagsCount;
                continue;
              }
              continue;
            case 61:
              this.addToString(index);
              this.xmlIsAttribute = true;
              continue;
            case 62:
              this.addToString(index);
              this.xmlIsTagContent = false;
              this.xmlIsAttribute = false;
              continue;
            default:
              this.addToString(index);
              this.xmlIsAttribute = false;
              continue;
          }
        }
        else if (index == 60)
        {
          this.addToString(index);
          switch (this.peekChar())
          {
            case 33:
              this.addToString(this.getChar());
              switch (this.peekChar())
              {
                case 45:
                  this.addToString(this.getChar());
                  int num = this.getChar();
                  if (num == 45)
                  {
                    this.addToString(num);
                    if (!this.readXmlComment())
                      return -1;
                    continue;
                  }
                  this.stringBufferTop = 0;
                  this.@string = (string) null;
                  this.parser.addError("msg.XML.bad.form");
                  return -1;
                case 91:
                  this.addToString(this.getChar());
                  if (this.getChar() == 67 && this.getChar() == 68 && (this.getChar() == 65 && this.getChar() == 84) && (this.getChar() == 65 && this.getChar() == 91))
                  {
                    this.addToString(67);
                    this.addToString(68);
                    this.addToString(65);
                    this.addToString(84);
                    this.addToString(65);
                    this.addToString(91);
                    if (!this.readCDATA())
                      return -1;
                    continue;
                  }
                  this.stringBufferTop = 0;
                  this.@string = (string) null;
                  this.parser.addError("msg.XML.bad.form");
                  return -1;
                default:
                  if (!this.readEntity())
                    return -1;
                  continue;
              }
            case 47:
              this.addToString(this.getChar());
              if (this.xmlOpenTagsCount == 0)
              {
                this.stringBufferTop = 0;
                this.@string = (string) null;
                this.parser.addError("msg.XML.bad.form");
                return -1;
              }
              this.xmlIsTagContent = true;
              --this.xmlOpenTagsCount;
              continue;
            case 63:
              this.addToString(this.getChar());
              if (!this.readPI())
                return -1;
              continue;
            default:
              this.xmlIsTagContent = true;
              ++this.xmlOpenTagsCount;
              continue;
          }
        }
        else
          this.addToString(index);
      }
      this.tokenEnd = this.cursor;
      this.stringBufferTop = 0;
      this.@string = (string) null;
      this.parser.addError("msg.XML.bad.form");
      return -1;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 61, 107, 103, 6, 233, 69, 103, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool readQuotedString([In] int obj0)
    {
      for (int index = this.getChar(); index != -1; index = this.getChar())
      {
        this.addToString(index);
        if (index == obj0)
          return true;
      }
      this.stringBufferTop = 0;
      this.@string = (string) null;
      this.parser.addError("msg.XML.bad.form");
      return false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 76, 107, 103, 111, 103, 103, 106, 103, 103, 194, 169, 103, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool readXmlComment()
    {
      int num = this.getChar();
      while (num != -1)
      {
        this.addToString(num);
        if (num == 45 && this.peekChar() == 45)
        {
          num = this.getChar();
          this.addToString(num);
          if (this.peekChar() == 62)
          {
            this.addToString(this.getChar());
            return true;
          }
        }
        else
          num = this.getChar();
      }
      this.stringBufferTop = 0;
      this.@string = (string) null;
      this.parser.addError("msg.XML.bad.form");
      return false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 101, 107, 103, 111, 103, 103, 106, 103, 103, 194, 169, 103, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool readCDATA()
    {
      int num = this.getChar();
      while (num != -1)
      {
        this.addToString(num);
        if (num == 93 && this.peekChar() == 93)
        {
          num = this.getChar();
          this.addToString(num);
          if (this.peekChar() == 62)
          {
            this.addToString(this.getChar());
            return true;
          }
        }
        else
          num = this.getChar();
      }
      this.stringBufferTop = 0;
      this.@string = (string) null;
      this.parser.addError("msg.XML.bad.form");
      return false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 126, 98, 107, 103, 148, 100, 130, 100, 229, 56, 233, 77, 103, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool readEntity()
    {
      int num = 1;
      for (int index = this.getChar(); index != -1; index = this.getChar())
      {
        this.addToString(index);
        switch (index)
        {
          case 60:
            ++num;
            break;
          case 62:
            num += -1;
            if (num == 0)
              return true;
            break;
        }
      }
      this.stringBufferTop = 0;
      this.@string = (string) null;
      this.parser.addError("msg.XML.bad.form");
      return false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 150, 107, 103, 111, 103, 103, 226, 59, 233, 73, 103, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool readPI()
    {
      for (int index = this.getChar(); index != -1; index = this.getChar())
      {
        this.addToString(index);
        if (index == 63 && this.peekChar() == 62)
        {
          this.addToString(this.getChar());
          return true;
        }
      }
      this.stringBufferTop = 0;
      this.@string = (string) null;
      this.parser.addError("msg.XML.bad.form");
      return false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {167, 13, 104, 110, 251, 69, 104, 110, 103, 130, 110, 159, 2, 110, 104, 103, 162, 110, 187, 101, 106, 103, 165, 106, 104, 133, 104, 103, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getCharIgnoreLineEnd()
    {
      if (this.ungetCursor != 0)
      {
        ++this.cursor;
        int[] ungetBuffer = this.ungetBuffer;
        TokenStream tokenStream1 = this;
        int num = tokenStream1.ungetCursor - 1;
        TokenStream tokenStream2 = tokenStream1;
        int index = num;
        tokenStream2.ungetCursor = num;
        return ungetBuffer[index];
      }
      int c;
      do
      {
        if (this.sourceString != null)
        {
          if (this.sourceCursor == this.sourceEnd)
          {
            this.hitEOF = true;
            return -1;
          }
          ++this.cursor;
          string sourceString = this.sourceString;
          TokenStream tokenStream1 = this;
          int sourceCursor = tokenStream1.sourceCursor;
          TokenStream tokenStream2 = tokenStream1;
          int num = sourceCursor;
          tokenStream2.sourceCursor = sourceCursor + 1;
          c = (int) String.instancehelper_charAt(sourceString, num);
        }
        else
        {
          if (this.sourceCursor == this.sourceEnd && !this.fillSourceBuffer())
          {
            this.hitEOF = true;
            return -1;
          }
          ++this.cursor;
          char[] sourceBuffer = this.sourceBuffer;
          TokenStream tokenStream1 = this;
          int sourceCursor = tokenStream1.sourceCursor;
          TokenStream tokenStream2 = tokenStream1;
          int index = sourceCursor;
          tokenStream2.sourceCursor = sourceCursor + 1;
          c = (int) sourceBuffer[index];
        }
        if (c <= (int) sbyte.MaxValue)
        {
          if (c == 10 || c == 13)
          {
            this.lineEndChar = c;
            c = 10;
            goto label_17;
          }
          else
            goto label_17;
        }
        else if (c == 65279)
          return c;
      }
      while (TokenStream.isJSFormatChar(c));
      if (ScriptRuntime.isJSLineTerminator(c))
      {
        this.lineEndChar = c;
        c = 10;
      }
label_17:
      return c;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {167, 181, 110, 114, 112, 159, 6, 115, 115, 137, 111, 116, 167, 159, 7, 100, 130, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool fillSourceBuffer()
    {
      if (this.sourceString != null)
        Kit.codeBug();
      if (this.sourceEnd == this.sourceBuffer.Length)
      {
        if (this.lineStart != 0 && !this.isMarkingComment())
        {
          ByteCodeHelper.arraycopy_primitive_2((Array) this.sourceBuffer, this.lineStart, (Array) this.sourceBuffer, 0, this.sourceEnd - this.lineStart);
          this.sourceEnd -= this.lineStart;
          this.sourceCursor -= this.lineStart;
          this.lineStart = 0;
        }
        else
        {
          char[] chArray = new char[this.sourceBuffer.Length * 2];
          ByteCodeHelper.arraycopy_primitive_2((Array) this.sourceBuffer, 0, (Array) chArray, 0, this.sourceEnd);
          this.sourceBuffer = chArray;
        }
      }
      int num = this.sourceReader.read(this.sourceBuffer, this.sourceEnd, this.sourceBuffer.Length - this.sourceEnd);
      if (num < 0)
        return false;
      this.sourceEnd += num;
      return true;
    }

    [LineNumberTable(1475)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isJSFormatChar([In] int obj0) => obj0 > (int) sbyte.MaxValue && Character.getType((char) obj0) == 16;

    [LineNumberTable(new byte[] {167, 83, 100, 130, 104, 105, 130, 141, 105, 135, 104, 244, 69, 226, 61, 129, 194, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int charAt([In] int obj0)
    {
      if (obj0 < 0)
        return -1;
      if (this.sourceString != null)
        return obj0 >= this.sourceEnd ? -1 : (int) String.instancehelper_charAt(this.sourceString, obj0);
      if (obj0 >= this.sourceEnd)
      {
        int sourceCursor = this.sourceCursor;
        int num;
        try
        {
          if (!this.fillSourceBuffer())
            num = -1;
          else
            goto label_13;
        }
        catch (IOException ex)
        {
          goto label_12;
        }
        return num;
label_12:
        return -1;
label_13:
        obj0 -= sourceCursor - this.sourceCursor;
      }
      return (int) this.sourceBuffer[obj0];
    }

    [LineNumberTable(new byte[] {167, 110, 104, 142, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string substring([In] int obj0, [In] int obj1)
    {
      if (this.sourceString != null)
        return String.instancehelper_substring(this.sourceString, obj0, obj1);
      int num = obj1 - obj0;
      return String.newhelper(this.sourceBuffer, obj0, num);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isMarkingComment() => this.commentCursor != -1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string tokenToString([In] int obj0) => "";

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal string getSourceString() => this.sourceString;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isXMLAttribute() => this.xmlIsAttribute;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {165, 167, 103, 103, 103, 104, 98, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getFirstXMLToken()
    {
      this.xmlOpenTagsCount = 0;
      this.xmlIsAttribute = false;
      this.xmlIsTagContent = false;
      if (!this.canUngetChar())
        return -1;
      this.ungetChar(60);
      return this.getNextXMLToken();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getCursor() => this.cursor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTokenBeg() => this.tokenBeg;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTokenEnd() => this.tokenEnd;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Token.CommentType getCommentType() => this.commentType;

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TokenStream()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.TokenStream"))
        return;
      TokenStream.\u0024assertionsDisabled = !((Class) ClassLiteral<TokenStream>.Value).desiredAssertionStatus();
    }
  }
}
