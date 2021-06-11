// Decompiled with JetBrains decompiler
// Type: rhino.Decompiler
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class Decompiler : Object
  {
    public const int ONLY_BODY_FLAG = 1;
    public const int TO_SOURCE_FLAG = 2;
    public const int INITIAL_INDENT_PROP = 1;
    public const int INDENT_GAP_PROP = 2;
    public const int CASE_GAP_PROP = 3;
    private const int FUNCTION_END = 168;
    private char[] sourceBuffer;
    private int sourceTop;
    private const bool printSource = false;

    [LineNumberTable(new byte[] {160, 101, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string sourceToString([In] int obj0)
    {
      if (obj0 < 0 || this.sourceTop < obj0)
        Kit.codeBug();
      return String.newhelper(this.sourceBuffer, obj0, this.sourceTop - obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getCurrentOffset() => this.sourceTop;

    [LineNumberTable(new byte[] {43, 108, 139, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addToken([In] int obj0)
    {
      if (0 > obj0 || obj0 > 167)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.append((char) obj0);
    }

    [LineNumberTable(new byte[] {159, 94, 162, 111, 142, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void append([In] char obj0)
    {
      int num = (int) obj0;
      if (this.sourceTop == this.sourceBuffer.Length)
        this.increaseSourceCapacity(this.sourceTop + 1);
      this.sourceBuffer[this.sourceTop] = (char) num;
      ++this.sourceTop;
    }

    [LineNumberTable(new byte[] {123, 103, 98, 104, 130, 107, 106, 135, 168, 120, 142, 111, 110, 116, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void appendString([In] string obj0)
    {
      int num1 = String.instancehelper_length(obj0);
      int num2 = 1;
      if (num1 >= 32768)
        num2 = 2;
      int num3 = this.sourceTop + num2 + num1;
      if (num3 > this.sourceBuffer.Length)
        this.increaseSourceCapacity(num3);
      if (num1 >= 32768)
      {
        this.sourceBuffer[this.sourceTop] = (char) (32768U | (uint) num1 >> 16);
        ++this.sourceTop;
      }
      this.sourceBuffer[this.sourceTop] = (char) num1;
      ++this.sourceTop;
      String.instancehelper_getChars(obj0, 0, num1, this.sourceBuffer, this.sourceTop);
      this.sourceTop = num3;
    }

    [LineNumberTable(new byte[] {160, 90, 112, 106, 100, 130, 103, 116, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void increaseSourceCapacity([In] int obj0)
    {
      if (obj0 <= this.sourceBuffer.Length)
        Kit.codeBug();
      int length = this.sourceBuffer.Length * 2;
      if (length < obj0)
        length = obj0;
      char[] chArray = new char[length];
      ByteCodeHelper.arraycopy_primitive_2((Array) this.sourceBuffer, 0, (Array) chArray, 0, this.sourceTop);
      this.sourceBuffer = chArray;
    }

    [LineNumberTable(new byte[] {158, 200, 130, 104, 101, 105, 115, 133, 99, 107, 99, 138, 105, 109, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int printSourceString([In] string obj0, [In] int obj1, [In] bool obj2, [In] StringBuilder obj3)
    {
      int num1 = obj2 ? 1 : 0;
      int num2 = (int) String.instancehelper_charAt(obj0, obj1);
      ++obj1;
      if ((32768 & num2) != 0)
      {
        num2 = ((int) short.MaxValue & num2) << 16 | (int) String.instancehelper_charAt(obj0, obj1);
        ++obj1;
      }
      if (obj3 != null)
      {
        string s = String.instancehelper_substring(obj0, obj1, obj1 + num2);
        if (num1 == 0)
        {
          obj3.append(s);
        }
        else
        {
          obj3.append('"');
          obj3.append(ScriptRuntime.escapeString(s));
          obj3.append('"');
        }
      }
      return obj1 + num2;
    }

    [LineNumberTable(new byte[] {162, 189, 102, 104, 101, 101, 99, 104, 131, 106, 109, 131, 108, 112, 112, 109, 101, 133, 170, 167, 139, 99, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int printSourceNumber([In] string obj0, [In] int obj1, [In] StringBuilder obj2)
    {
      double d = 0.0;
      int num1 = (int) String.instancehelper_charAt(obj0, obj1);
      ++obj1;
      switch (num1)
      {
        case 68:
        case 74:
          if (obj2 != null)
          {
            long num2 = (long) String.instancehelper_charAt(obj0, obj1) << 48 | (long) String.instancehelper_charAt(obj0, obj1 + 1) << 32 | (long) String.instancehelper_charAt(obj0, obj1 + 2) << 16 | (long) String.instancehelper_charAt(obj0, obj1 + 3);
            DoubleConverter doubleConverter;
            d = num1 != 74 ? DoubleConverter.ToDouble(num2, ref doubleConverter) : (double) num2;
          }
          obj1 += 4;
          break;
        case 83:
          if (obj2 != null)
            d = (double) String.instancehelper_charAt(obj0, obj1);
          ++obj1;
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException();
      }
      obj2?.append(ScriptRuntime.numberToString(d, 10));
      return obj1;
    }

    [LineNumberTable(784)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getNext([In] string obj0, [In] int obj1, [In] int obj2) => obj2 + 1 < obj1 ? (int) String.instancehelper_charAt(obj0, obj2 + 1) : 0;

    [LineNumberTable(788)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getSourceStringEnd([In] string obj0, [In] int obj1) => Decompiler.printSourceString(obj0, obj1, false, (StringBuilder) null);

    [LineNumberTable(new byte[] {159, 180, 232, 163, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Decompiler()
    {
      Decompiler decompiler = this;
      this.sourceBuffer = new char[128];
    }

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getEncodedSource() => this.sourceToString(0);

    [LineNumberTable(new byte[] {28, 103, 100, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int markFunctionStart([In] int obj0)
    {
      int currentOffset = this.getCurrentOffset();
      if (obj0 != 4)
      {
        this.addToken(110);
        this.append((char) obj0);
      }
      return currentOffset;
    }

    [LineNumberTable(new byte[] {37, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int markFunctionEnd([In] int obj0)
    {
      int currentOffset = this.getCurrentOffset();
      this.append('¨');
      return currentOffset;
    }

    [LineNumberTable(new byte[] {50, 108, 139, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addEOL([In] int obj0)
    {
      if (0 > obj0 || obj0 > 167)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.append((char) obj0);
      this.append('\u0001');
    }

    [LineNumberTable(new byte[] {58, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addName([In] string obj0)
    {
      this.addToken(39);
      this.appendString(obj0);
    }

    [LineNumberTable(new byte[] {63, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addString([In] string obj0)
    {
      this.addToken(41);
      this.appendString(obj0);
    }

    [LineNumberTable(new byte[] {68, 104, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addRegexp([In] string obj0, [In] string obj1)
    {
      this.addToken(48);
      this.appendString(new StringBuilder().append('/').append(obj0).append('/').append(obj1).toString());
    }

    [LineNumberTable(new byte[] {73, 232, 83, 104, 166, 104, 104, 108, 108, 108, 203, 203, 105, 104, 139, 104, 108, 108, 108, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addNumber([In] double obj0)
    {
      this.addToken(40);
      long num = ByteCodeHelper.d2l(obj0);
      if ((double) num != obj0)
      {
        long longBits = Double.doubleToLongBits(obj0);
        this.append('D');
        this.append((char) (longBits >> 48));
        this.append((char) (longBits >> 32));
        this.append((char) (longBits >> 16));
        this.append((char) longBits);
      }
      else
      {
        if (num < 0L)
          Kit.codeBug();
        if (num <= (long) ushort.MaxValue)
        {
          this.append('S');
          this.append((char) num);
        }
        else
        {
          this.append('J');
          this.append((char) (num >> 48));
          this.append((char) (num >> 32));
          this.append((char) (num >> 16));
          this.append((char) num);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 119, 103, 99, 166, 105, 111, 105, 111, 105, 143, 103, 107, 235, 93, 99, 99, 131, 111, 102, 133, 172, 132, 106, 104, 42, 170, 101, 202, 104, 223, 162, 85, 111, 111, 111, 141, 102, 143, 102, 197, 111, 165, 111, 165, 110, 165, 109, 165, 109, 165, 109, 165, 109, 165, 102, 109, 197, 165, 109, 165, 102, 108, 100, 106, 165, 230, 69, 104, 133, 106, 191, 15, 100, 162, 100, 170, 165, 106, 165, 106, 112, 207, 106, 165, 106, 165, 105, 99, 100, 99, 196, 104, 100, 163, 100, 234, 71, 106, 99, 108, 140, 103, 102, 229, 70, 102, 108, 108, 163, 101, 42, 136, 197, 106, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 112, 207, 109, 112, 207, 109, 165, 109, 165, 109, 112, 207, 109, 165, 109, 165, 106, 143, 239, 69, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 229, 72, 109, 165, 140, 175, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 106, 165, 106, 165, 106, 165, 106, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 165, 109, 162, 109, 162, 109, 162, 109, 194, 114, 159, 0, 171, 132, 100, 140, 101, 202})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string decompile(string source, int flags, UintMap properties)
    {
      int num1 = String.instancehelper_length(source);
      if (num1 == 0)
        return "";
      int num2 = properties.getInt(1, 0);
      if (num2 < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      int num3 = properties.getInt(2, 4);
      if (num3 < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      int num4 = properties.getInt(3, 2);
      if (num4 < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      StringBuilder stringBuilder = new StringBuilder();
      int num5 = 0 != (flags & 1) ? 1 : 0;
      int num6 = 0 != (flags & 2) ? 1 : 0;
      int num7 = 0;
      int num8 = 0;
      int num9 = 0;
      int num10;
      if (String.instancehelper_charAt(source, num9) == '\u0089')
      {
        ++num9;
        num10 = -1;
      }
      else
        num10 = (int) String.instancehelper_charAt(source, num9 + 1);
      if (num6 == 0)
      {
        stringBuilder.append('\n');
        for (int index = 0; index < num2; ++index)
          stringBuilder.append(' ');
      }
      else if (num10 == 2)
        stringBuilder.append('(');
      while (num9 < num1)
      {
        switch (String.instancehelper_charAt(source, num9))
        {
          case '\u0001':
            if (num6 == 0)
            {
              int num11 = 1;
              if (num8 == 0)
              {
                num8 = 1;
                if (num5 != 0)
                {
                  stringBuilder.setLength(0);
                  num2 -= num3;
                  num11 = 0;
                }
              }
              if (num11 != 0)
                stringBuilder.append('\n');
              if (num9 + 1 < num1)
              {
                int num12 = 0;
                switch (String.instancehelper_charAt(source, num9 + 1))
                {
                  case '\'':
                    int sourceStringEnd = Decompiler.getSourceStringEnd(source, num9 + 2);
                    if (String.instancehelper_charAt(source, sourceStringEnd) == 'h')
                    {
                      num12 = num3;
                      break;
                    }
                    break;
                  case 'W':
                    num12 = num3;
                    break;
                  case 't':
                  case 'u':
                    num12 = num3 - num4;
                    break;
                }
                for (; num12 < num2; ++num12)
                  stringBuilder.append(' ');
                goto case '¨';
              }
              else
                goto case '¨';
            }
            else
              goto case '¨';
          case '\u0004':
            stringBuilder.append("return");
            if (83 != Decompiler.getNext(source, num1, num9))
            {
              stringBuilder.append(' ');
              goto case '¨';
            }
            else
              goto case '¨';
          case '\t':
            stringBuilder.append(" | ");
            goto case '¨';
          case '\n':
            stringBuilder.append(" ^ ");
            goto case '¨';
          case '\v':
            stringBuilder.append(" & ");
            goto case '¨';
          case '\f':
            stringBuilder.append(" == ");
            goto case '¨';
          case '\r':
            stringBuilder.append(" != ");
            goto case '¨';
          case '\u000E':
            stringBuilder.append(" < ");
            goto case '¨';
          case '\u000F':
            stringBuilder.append(" <= ");
            goto case '¨';
          case '\u0010':
            stringBuilder.append(" > ");
            goto case '¨';
          case '\u0011':
            stringBuilder.append(" >= ");
            goto case '¨';
          case '\u0012':
            stringBuilder.append(" << ");
            goto case '¨';
          case '\u0013':
            stringBuilder.append(" >> ");
            goto case '¨';
          case '\u0014':
            stringBuilder.append(" >>> ");
            goto case '¨';
          case '\u0015':
            stringBuilder.append(" + ");
            goto case '¨';
          case '\u0016':
            stringBuilder.append(" - ");
            goto case '¨';
          case '\u0017':
            stringBuilder.append(" * ");
            goto case '¨';
          case '\u0018':
            stringBuilder.append(" / ");
            goto case '¨';
          case '\u0019':
            stringBuilder.append(" % ");
            goto case '¨';
          case '\u001A':
            stringBuilder.append('!');
            goto case '¨';
          case '\u001B':
            stringBuilder.append('~');
            goto case '¨';
          case '\u001C':
            stringBuilder.append('+');
            goto case '¨';
          case '\u001D':
            stringBuilder.append('-');
            goto case '¨';
          case '\u001E':
            stringBuilder.append("new ");
            goto case '¨';
          case '\u001F':
            stringBuilder.append("delete ");
            goto case '¨';
          case ' ':
            stringBuilder.append("typeof ");
            goto case '¨';
          case '\'':
          case '0':
            num9 = Decompiler.printSourceString(source, num9 + 1, false, stringBuilder);
            continue;
          case '(':
            num9 = Decompiler.printSourceNumber(source, num9 + 1, stringBuilder);
            continue;
          case ')':
            num9 = Decompiler.printSourceString(source, num9 + 1, true, stringBuilder);
            continue;
          case '*':
            stringBuilder.append("null");
            goto case '¨';
          case '+':
            stringBuilder.append("this");
            goto case '¨';
          case ',':
            stringBuilder.append("false");
            goto case '¨';
          case '-':
            stringBuilder.append("true");
            goto case '¨';
          case '.':
            stringBuilder.append(" === ");
            goto case '¨';
          case '/':
            stringBuilder.append(" !== ");
            goto case '¨';
          case '2':
            stringBuilder.append("throw ");
            goto case '¨';
          case '4':
            stringBuilder.append(" in ");
            goto case '¨';
          case '5':
            stringBuilder.append(" instanceof ");
            goto case '¨';
          case 'C':
            stringBuilder.append(": ");
            goto case '¨';
          case 'I':
            stringBuilder.append("yield ");
            goto case '¨';
          case 'R':
            stringBuilder.append("try ");
            goto case '¨';
          case 'S':
            stringBuilder.append(';');
            if (1 != Decompiler.getNext(source, num1, num9))
            {
              stringBuilder.append(' ');
              goto case '¨';
            }
            else
              goto case '¨';
          case 'T':
            stringBuilder.append('[');
            goto case '¨';
          case 'U':
            stringBuilder.append(']');
            goto case '¨';
          case 'V':
            ++num7;
            if (1 == Decompiler.getNext(source, num1, num9))
              num2 += num3;
            stringBuilder.append('{');
            goto case '¨';
          case 'W':
            num7 += -1;
            if (num5 == 0 || num7 != 0)
            {
              stringBuilder.append('}');
              switch (Decompiler.getNext(source, num1, num9))
              {
                case 1:
                case 168:
                  num2 -= num3;
                  goto label_139;
                case 114:
                case 118:
                  num2 -= num3;
                  stringBuilder.append(' ');
                  goto label_139;
                default:
                  goto label_139;
              }
            }
            else
              goto case '¨';
          case 'X':
            stringBuilder.append('(');
            goto case '¨';
          case 'Y':
            stringBuilder.append(')');
            if (86 == Decompiler.getNext(source, num1, num9))
            {
              stringBuilder.append(' ');
              goto case '¨';
            }
            else
              goto case '¨';
          case 'Z':
            stringBuilder.append(", ");
            goto case '¨';
          case '[':
            stringBuilder.append(" = ");
            goto case '¨';
          case '\\':
            stringBuilder.append(" |= ");
            goto case '¨';
          case ']':
            stringBuilder.append(" ^= ");
            goto case '¨';
          case '^':
            stringBuilder.append(" &= ");
            goto case '¨';
          case '_':
            stringBuilder.append(" <<= ");
            goto case '¨';
          case '`':
            stringBuilder.append(" >>= ");
            goto case '¨';
          case 'a':
            stringBuilder.append(" >>>= ");
            goto case '¨';
          case 'b':
            stringBuilder.append(" += ");
            goto case '¨';
          case 'c':
            stringBuilder.append(" -= ");
            goto case '¨';
          case 'd':
            stringBuilder.append(" *= ");
            goto case '¨';
          case 'e':
            stringBuilder.append(" /= ");
            goto case '¨';
          case 'f':
            stringBuilder.append(" %= ");
            goto case '¨';
          case 'g':
            stringBuilder.append(" ? ");
            goto case '¨';
          case 'h':
            if (1 == Decompiler.getNext(source, num1, num9))
            {
              stringBuilder.append(':');
              goto case '¨';
            }
            else
            {
              stringBuilder.append(" : ");
              goto case '¨';
            }
          case 'i':
            stringBuilder.append(" || ");
            goto case '¨';
          case 'j':
            stringBuilder.append(" && ");
            goto case '¨';
          case 'k':
            stringBuilder.append("++");
            goto case '¨';
          case 'l':
            stringBuilder.append("--");
            goto case '¨';
          case 'm':
            stringBuilder.append('.');
            goto case '¨';
          case 'n':
            ++num9;
            stringBuilder.append("function ");
            goto case '¨';
          case 'q':
            stringBuilder.append("if ");
            goto case '¨';
          case 'r':
            stringBuilder.append("else ");
            goto case '¨';
          case 's':
            stringBuilder.append("switch ");
            goto case '¨';
          case 't':
            stringBuilder.append("case ");
            goto case '¨';
          case 'u':
            stringBuilder.append("default");
            goto case '¨';
          case 'v':
            stringBuilder.append("while ");
            goto case '¨';
          case 'w':
            stringBuilder.append("do ");
            goto case '¨';
          case 'x':
            stringBuilder.append("for ");
            goto case '¨';
          case 'y':
            stringBuilder.append("break");
            if (39 == Decompiler.getNext(source, num1, num9))
            {
              stringBuilder.append(' ');
              goto case '¨';
            }
            else
              goto case '¨';
          case 'z':
            stringBuilder.append("continue");
            if (39 == Decompiler.getNext(source, num1, num9))
            {
              stringBuilder.append(' ');
              goto case '¨';
            }
            else
              goto case '¨';
          case '{':
            stringBuilder.append("var ");
            goto case '¨';
          case '|':
            stringBuilder.append("with ");
            goto case '¨';
          case '}':
            stringBuilder.append("catch ");
            goto case '¨';
          case '~':
            stringBuilder.append("finally ");
            goto case '¨';
          case '\u007F':
            stringBuilder.append("void ");
            goto case '¨';
          case '\u0098':
          case '\u0099':
          case '¤':
            if (String.instancehelper_charAt(source, num9) == '\u0098')
              stringBuilder.append("get ");
            else if (String.instancehelper_charAt(source, num9) == '\u0099')
              stringBuilder.append("set ");
            int num13 = num9 + 1;
            num9 = Decompiler.printSourceString(source, num13 + 1, false, stringBuilder) + 1;
            goto case '¨';
          case '\u009A':
            stringBuilder.append("let ");
            goto case '¨';
          case '\u009B':
            stringBuilder.append("const ");
            goto case '¨';
          case '¡':
            stringBuilder.append("debugger;\n");
            goto case '¨';
          case '¥':
            stringBuilder.append(" => ");
            goto case '¨';
          case '¦':
            stringBuilder.append("yield *");
            goto case '¨';
          case '¨':
label_139:
            ++num9;
            continue;
          default:
            string str = new StringBuilder().append("Token: ").append(Token.name((int) String.instancehelper_charAt(source, num9))).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException(str);
        }
      }
      if (num6 == 0)
      {
        if (num5 == 0)
          stringBuilder.append('\n');
      }
      else if (num10 == 2)
        stringBuilder.append(')');
      return stringBuilder.toString();
    }
  }
}
