// Decompiled with JetBrains decompiler
// Type: rhino.json.JsonParser
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.json
{
  public class JsonParser : Object
  {
    [Modifiers]
    private Context cx;
    [Modifiers]
    private Scriptable scope;
    private int pos;
    private int length;
    private string src;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 171, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonParser(Context cx, Scriptable scope)
    {
      JsonParser jsonParser = this;
      this.cx = cx;
      this.scope = scope;
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {159, 177, 99, 144, 103, 108, 103, 103, 102, 110, 159, 11})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual object parseValue(string json)
    {
      if (json == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JsonParser.ParseException("Input string may not be null");
      }
      this.pos = 0;
      this.length = String.instancehelper_length(json);
      this.src = json;
      object obj = this.readValue();
      this.consumeWhitespace();
      if (this.pos < this.length)
      {
        string str = new StringBuilder().append("Expected end of stream at char ").append(this.pos).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JsonParser.ParseException(str);
      }
      return obj;
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {0, 102, 113, 127, 0, 159, 160, 78, 135, 135, 135, 135, 135, 231, 76, 136, 191, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object readValue()
    {
      this.consumeWhitespace();
      if (this.pos < this.length)
      {
        string src = this.src;
        JsonParser jsonParser1 = this;
        int pos = jsonParser1.pos;
        JsonParser jsonParser2 = jsonParser1;
        int num1 = pos;
        jsonParser2.pos = pos + 1;
        int num2 = (int) String.instancehelper_charAt(src, num1);
        switch (num2)
        {
          case 34:
            return (object) this.readString();
          case 45:
          case 48:
          case 49:
          case 50:
          case 51:
          case 52:
          case 53:
          case 54:
          case 55:
          case 56:
          case 57:
            return (object) this.readNumber((char) num2);
          case 91:
            return this.readArray();
          case 102:
            return (object) this.readFalse();
          case 110:
            return this.readNull();
          case 116:
            return (object) this.readTrue();
          case 123:
            return this.readObject();
          default:
            string str = new StringBuilder().append("Unexpected token: ").append((char) num2).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new JsonParser.ParseException(str);
        }
      }
      else
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JsonParser.ParseException("Empty JSON string");
      }
    }

    [LineNumberTable(new byte[] {161, 0, 110, 114, 255, 5, 69, 110, 130, 129, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void consumeWhitespace()
    {
      for (; this.pos < this.length; ++this.pos)
      {
        switch (String.instancehelper_charAt(this.src, this.pos))
        {
          case '\t':
          case '\n':
          case '\r':
          case ' ':
            continue;
          default:
            return;
        }
      }
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {36, 102, 146, 127, 4, 110, 194, 98, 113, 127, 1, 159, 1, 99, 144, 130, 99, 144, 98, 133, 99, 144, 104, 104, 136, 105, 102, 141, 172, 98, 130, 144, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object readObject()
    {
      this.consumeWhitespace();
      Scriptable s = this.cx.newObject(this.scope);
      if (this.pos < this.length && String.instancehelper_charAt(this.src, this.pos) == '}')
      {
        ++this.pos;
        return (object) s;
      }
      int num1 = 0;
      while (this.pos < this.length)
      {
        string src = this.src;
        JsonParser jsonParser1 = this;
        int pos = jsonParser1.pos;
        JsonParser jsonParser2 = jsonParser1;
        int num2 = pos;
        jsonParser2.pos = pos + 1;
        switch (String.instancehelper_charAt(src, num2))
        {
          case '"':
            if (num1 != 0)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new JsonParser.ParseException("Missing comma in object literal");
            }
            string str = this.readString();
            this.consume(':');
            object obj = this.readValue();
            long num3 = ScriptRuntime.indexFromString(str);
            if (num3 < 0L)
              s.put(str, s, obj);
            else
              s.put((int) num3, s, obj);
            num1 = 1;
            break;
          case ',':
            if (num1 == 0)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new JsonParser.ParseException("Unexpected comma in object literal");
            }
            num1 = 0;
            break;
          case '}':
            if (num1 == 0)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new JsonParser.ParseException("Unexpected comma in object literal");
            }
            return (object) s;
          default:
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new JsonParser.ParseException("Unexpected token in object literal");
        }
        this.consumeWhitespace();
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new JsonParser.ParseException("Unterminated object literal");
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {86, 134, 127, 4, 110, 147, 102, 98, 113, 114, 148, 99, 144, 110, 152, 99, 144, 98, 110, 130, 99, 144, 109, 130, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object readArray()
    {
      this.consumeWhitespace();
      if (this.pos < this.length && String.instancehelper_charAt(this.src, this.pos) == ']')
      {
        ++this.pos;
        return (object) this.cx.newArray(this.scope, 0);
      }
      ArrayList arrayList = new ArrayList();
      int num = 0;
      while (this.pos < this.length)
      {
        switch (String.instancehelper_charAt(this.src, this.pos))
        {
          case ',':
            if (num == 0)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new JsonParser.ParseException("Unexpected comma in array literal");
            }
            num = 0;
            ++this.pos;
            break;
          case ']':
            if (num == 0)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new JsonParser.ParseException("Unexpected comma in array literal");
            }
            ++this.pos;
            return (object) this.cx.newArray(this.scope, ((List) arrayList).toArray());
          default:
            if (num != 0)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new JsonParser.ParseException("Missing comma in array literal");
            }
            ((List) arrayList).add(this.readValue());
            num = 1;
            break;
        }
        this.consumeWhitespace();
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new JsonParser.ParseException("Unterminated array literal");
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {160, 222, 124, 119, 119, 105, 144, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Boolean readTrue()
    {
      if (this.length - this.pos < 3 || String.instancehelper_charAt(this.src, this.pos) != 'r' || (String.instancehelper_charAt(this.src, this.pos + 1) != 'u' || String.instancehelper_charAt(this.src, this.pos + 2) != 'e'))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JsonParser.ParseException("Unexpected token: t");
      }
      this.pos += 3;
      return (Boolean) Boolean.TRUE;
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {160, 233, 124, 119, 119, 119, 105, 144, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Boolean readFalse()
    {
      if (this.length - this.pos < 4 || String.instancehelper_charAt(this.src, this.pos) != 'a' || (String.instancehelper_charAt(this.src, this.pos + 1) != 'l' || String.instancehelper_charAt(this.src, this.pos + 2) != 's') || String.instancehelper_charAt(this.src, this.pos + 3) != 'e')
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JsonParser.ParseException("Unexpected token: f");
      }
      this.pos += 4;
      return (Boolean) Boolean.FALSE;
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {127, 103, 113, 127, 0, 101, 112, 101, 98, 101, 149, 229, 71, 103, 113, 127, 10, 127, 16, 110, 144, 127, 1, 159, 70, 106, 133, 106, 133, 106, 133, 105, 133, 106, 133, 106, 133, 106, 133, 106, 133, 112, 159, 22, 127, 12, 124, 124, 109, 101, 159, 30, 110, 107, 130, 159, 17, 103, 113, 127, 1, 102, 112, 102, 98, 102, 127, 16, 168, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string readString()
    {
      int pos1 = this.pos;
      while (this.pos < this.length)
      {
        string src = this.src;
        JsonParser jsonParser1 = this;
        int pos2 = jsonParser1.pos;
        JsonParser jsonParser2 = jsonParser1;
        int num1 = pos2;
        jsonParser2.pos = pos2 + 1;
        int num2 = (int) String.instancehelper_charAt(src, num1);
        if (num2 <= 31)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new JsonParser.ParseException("String contains control character");
        }
        if (num2 != 92)
        {
          if (num2 == 34)
            return String.instancehelper_substring(this.src, pos1, this.pos - 1);
        }
        else
          break;
      }
      StringBuilder stringBuilder1 = new StringBuilder();
label_8:
      while (this.pos < this.length)
      {
        if (!JsonParser.\u0024assertionsDisabled && String.instancehelper_charAt(this.src, this.pos - 1) != '\\')
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
        StringBuilder stringBuilder2 = stringBuilder1;
        string src1 = this.src;
        int num1 = pos1;
        int num2 = this.pos - 1;
        int num3 = num1;
        object obj1 = (object) src1;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj1;
        CharSequence charSequence2 = charSequence1;
        int num4 = num3;
        int num5 = num2;
        stringBuilder2.append(charSequence2, num4, num5);
        if (this.pos >= this.length)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new JsonParser.ParseException("Unterminated string");
        }
        string src2 = this.src;
        JsonParser jsonParser1 = this;
        int pos2 = jsonParser1.pos;
        JsonParser jsonParser2 = jsonParser1;
        int num6 = pos2;
        jsonParser2.pos = pos2 + 1;
        int num7 = (int) String.instancehelper_charAt(src2, num6);
        switch (num7)
        {
          case 34:
            stringBuilder1.append('"');
            break;
          case 47:
            stringBuilder1.append('/');
            break;
          case 92:
            stringBuilder1.append('\\');
            break;
          case 98:
            stringBuilder1.append('\b');
            break;
          case 102:
            stringBuilder1.append('\f');
            break;
          case 110:
            stringBuilder1.append('\n');
            break;
          case 114:
            stringBuilder1.append('\r');
            break;
          case 116:
            stringBuilder1.append('\t');
            break;
          case 117:
            if (this.length - this.pos < 5)
            {
              string str = new StringBuilder().append("Invalid character code: \\u").append(String.instancehelper_substring(this.src, this.pos)).toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new JsonParser.ParseException(str);
            }
            int num8 = this.fromHex(String.instancehelper_charAt(this.src, this.pos + 0)) << 12 | this.fromHex(String.instancehelper_charAt(this.src, this.pos + 1)) << 8 | this.fromHex(String.instancehelper_charAt(this.src, this.pos + 2)) << 4 | this.fromHex(String.instancehelper_charAt(this.src, this.pos + 3));
            if (num8 < 0)
            {
              string str = new StringBuilder().append("Invalid character code: ").append(String.instancehelper_substring(this.src, this.pos, this.pos + 4)).toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new JsonParser.ParseException(str);
            }
            this.pos += 4;
            stringBuilder1.append((char) num8);
            break;
          default:
            string str1 = new StringBuilder().append("Unexpected character in string: '\\").append((char) num7).append("'").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new JsonParser.ParseException(str1);
        }
        pos1 = this.pos;
        int num9;
        do
        {
          if (this.pos < this.length)
          {
            string src3 = this.src;
            JsonParser jsonParser3 = this;
            int pos3 = jsonParser3.pos;
            JsonParser jsonParser4 = jsonParser3;
            int num10 = pos3;
            jsonParser4.pos = pos3 + 1;
            num9 = (int) String.instancehelper_charAt(src3, num10);
            if (num9 <= 31)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new JsonParser.ParseException("String contains control character");
            }
            if (num9 == 92)
              goto label_8;
          }
          else
            goto label_8;
        }
        while (num9 != 34);
        StringBuilder stringBuilder3 = stringBuilder1;
        string src4 = this.src;
        int num11 = pos1;
        int num12 = this.pos - 1;
        int num13 = num11;
        object obj2 = (object) src4;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence3 = charSequence1;
        int num14 = num13;
        int num15 = num12;
        stringBuilder3.append(charSequence3, num14, num15);
        return stringBuilder1.toString();
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new JsonParser.ParseException("Unterminated string literal");
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {160, 245, 124, 119, 119, 105, 144, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object readNull()
    {
      if (this.length - this.pos < 3 || String.instancehelper_charAt(this.src, this.pos) != 'u' || (String.instancehelper_charAt(this.src, this.pos + 1) != 'l' || String.instancehelper_charAt(this.src, this.pos + 2) != 'l'))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JsonParser.ParseException("Unexpected token: n");
      }
      this.pos += 3;
      return (object) null;
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {159, 75, 66, 127, 2, 105, 101, 104, 106, 179, 101, 166, 110, 114, 101, 110, 104, 106, 147, 198, 113, 114, 106, 110, 104, 106, 136, 106, 147, 166, 115, 105, 104, 102, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Number readNumber([In] char obj0)
    {
      int num1 = (int) obj0;
      if (!JsonParser.\u0024assertionsDisabled && num1 != 45 && (num1 < 48 || num1 > 57))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      int num2 = this.pos - 1;
      if (num1 == 45)
      {
        num1 = (int) this.nextOrNumberError(num2);
        if (num1 < 48 || num1 > 57)
          throw Throwable.__\u003Cunmap\u003E((Exception) this.numberError(num2, this.pos));
      }
      if (num1 != 48)
        this.readDigits();
      if (this.pos < this.length && String.instancehelper_charAt(this.src, this.pos) == '.')
      {
        ++this.pos;
        int num3 = (int) this.nextOrNumberError(num2);
        if (num3 < 48 || num3 > 57)
          throw Throwable.__\u003Cunmap\u003E((Exception) this.numberError(num2, this.pos));
        this.readDigits();
      }
      if (this.pos < this.length)
      {
        switch (String.instancehelper_charAt(this.src, this.pos))
        {
          case 'E':
          case 'e':
            ++this.pos;
            int num4 = (int) this.nextOrNumberError(num2);
            if (num4 == 45 || num4 == 43)
              num4 = (int) this.nextOrNumberError(num2);
            if (num4 < 48 || num4 > 57)
              throw Throwable.__\u003Cunmap\u003E((Exception) this.numberError(num2, this.pos));
            this.readDigits();
            break;
        }
      }
      double num5 = Double.parseDouble(String.instancehelper_substring(this.src, num2, this.pos));
      int num6 = ByteCodeHelper.d2i(num5);
      return (double) num6 == num5 ? (Number) Integer.valueOf(num6) : (Number) Double.valueOf(num5);
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {159, 46, 130, 102, 110, 159, 16, 127, 0, 100, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void consume([In] char obj0)
    {
      int num1 = (int) obj0;
      this.consumeWhitespace();
      if (this.pos >= this.length)
      {
        string str = new StringBuilder().append("Expected ").append((char) num1).append(" but reached end of stream").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JsonParser.ParseException(str);
      }
      string src = this.src;
      JsonParser jsonParser1 = this;
      int pos = jsonParser1.pos;
      JsonParser jsonParser2 = jsonParser1;
      int num2 = pos;
      jsonParser2.pos = pos + 1;
      int num3 = (int) String.instancehelper_charAt(src, num2);
      if (num3 != num1)
      {
        string str = new StringBuilder().append("Expected ").append((char) num1).append(" found ").append((char) num3).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JsonParser.ParseException(str);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int fromHex([In] char obj0)
    {
      int num = (int) obj0;
      if (num >= 48 && num <= 57)
        return num - 48;
      if (num >= 65 && num <= 70)
        return num - 65 + 10;
      return num >= 97 && num <= 102 ? num - 97 + 10 : -1;
    }

    [Throws(new string[] {"rhino.json.JsonParser$ParseException"})]
    [LineNumberTable(new byte[] {160, 206, 110, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private char nextOrNumberError([In] int obj0)
    {
      if (this.pos >= this.length)
        throw Throwable.__\u003Cunmap\u003E((Exception) this.numberError(obj0, this.length));
      string src = this.src;
      JsonParser jsonParser1 = this;
      int pos = jsonParser1.pos;
      JsonParser jsonParser2 = jsonParser1;
      int num = pos;
      jsonParser2.pos = pos + 1;
      return String.instancehelper_charAt(src, num);
    }

    [LineNumberTable(316)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private JsonParser.ParseException numberError([In] int obj0, [In] int obj1) => new JsonParser.ParseException(new StringBuilder().append("Unsupported number format: ").append(String.instancehelper_substring(this.src, obj0, obj1)).toString());

    [LineNumberTable(new byte[] {160, 213, 110, 114, 106, 226, 61, 240, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readDigits()
    {
      for (; this.pos < this.length; ++this.pos)
      {
        int num = (int) String.instancehelper_charAt(this.src, this.pos);
        if (num < 48 || num > 57)
          break;
      }
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static JsonParser()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.json.JsonParser"))
        return;
      JsonParser.\u0024assertionsDisabled = !((Class) ClassLiteral<JsonParser>.Value).desiredAssertionStatus();
    }

    public class ParseException : Exception
    {
      [LineNumberTable(new byte[] {161, 30, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ParseException([In] string obj0)
        : base(obj0)
      {
      }

      [LineNumberTable(new byte[] {161, 34, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ParseException([In] Exception obj0)
        : base((Exception) obj0)
      {
      }
    }
  }
}
