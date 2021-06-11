// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LParser
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  public class LParser : Object
  {
    [Modifiers]
    private static string[] tokens;
    private const int maxJumps = 500;
    [Modifiers]
    private static StringMap opNameChanges;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/logic/LParser$JumpIndex;>;")]
    private static Seq jumps;
    [Modifiers]
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/String;>;")]
    private static ObjectIntMap jumpLocations;
    [Signature("Larc/struct/Seq<Lmindustry/logic/LStatement;>;")]
    internal Seq statements;
    internal char[] chars;
    internal int pos;
    internal int line;
    internal int tok;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Ljava/lang/String;)Larc/struct/Seq<Lmindustry/logic/LStatement;>;")]
    [LineNumberTable(new byte[] {159, 172, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Seq parse(string text) => text == null || String.instancehelper_isEmpty(text) ? new Seq() : new LParser(text).parse();

    [LineNumberTable(new byte[] {159, 165, 232, 60, 235, 69, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LParser([In] string obj0)
    {
      LParser lparser = this;
      this.statements = new Seq();
      this.chars = String.instancehelper_toCharArray(obj0);
    }

    [Signature("()Larc/struct/Seq<Lmindustry/logic/LStatement;>;")]
    [LineNumberTable(new byte[] {113, 107, 138, 127, 0, 127, 9, 112, 115, 235, 69, 127, 3, 114, 159, 16, 124, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Seq parse()
    {
      LParser.jumps.clear();
      LParser.jumpLocations.clear();
      while (this.pos < this.chars.Length && this.line < 1000)
      {
        switch (this.chars[this.pos])
        {
          case '\n':
          case ' ':
            ++this.pos;
            continue;
          case '\r':
            this.pos += 2;
            continue;
          default:
            this.statement();
            continue;
        }
      }
      Iterator iterator = LParser.jumps.iterator();
      while (iterator.hasNext())
      {
        LParser.JumpIndex jumpIndex = (LParser.JumpIndex) iterator.next();
        if (!LParser.jumpLocations.containsKey((object) jumpIndex.location))
          this.error(new StringBuilder().append("Undefined jump location: \"").append(jumpIndex.location).append("\". Make sure the jump label exists and is typed correctly.").toString());
        jumpIndex.jump.destIndex = LParser.jumpLocations.get((object) jumpIndex.location, -1);
      }
      return this.statements;
    }

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void error([In] string obj0)
    {
      string str = new StringBuilder().append("Invalid code. ").append(obj0).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(str);
    }

    [LineNumberTable(new byte[] {159, 178, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void comment()
    {
      while (this.pos < this.chars.Length)
      {
        char[] chars = this.chars;
        LParser lparser1 = this;
        int pos = lparser1.pos;
        LParser lparser2 = lparser1;
        int index = pos;
        lparser2.pos = pos + 1;
        if (chars[index] == '\n')
          break;
      }
    }

    [LineNumberTable(new byte[] {159, 186, 135, 124, 110, 101, 109, 101, 130, 130, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string @string()
    {
      int pos1 = this.pos;
      while (true)
      {
        LParser lparser1 = this;
        int pos2 = lparser1.pos;
        LParser lparser2 = lparser1;
        int num = pos2;
        lparser2.pos = pos2 + 1;
        int length = this.chars.Length;
        if (num < length)
        {
          switch (this.chars[this.pos])
          {
            case '\n':
              this.error("Missing closing quote \" before end of line.");
              continue;
            case '"':
              goto label_4;
            default:
              continue;
          }
        }
        else
          break;
      }
label_4:
      if (this.chars[this.pos] != '"')
        this.error("Missing closing quote \" before end of file.");
      char[] chars = this.chars;
      int num1 = pos1;
      LParser lparser3 = this;
      int num2 = lparser3.pos + 1;
      LParser lparser4 = lparser3;
      int num3 = num2;
      lparser4.pos = num2;
      int num4 = pos1;
      int num5 = num3 - num4;
      return String.newhelper(chars, num1, num5);
    }

    [LineNumberTable(new byte[] {11, 135, 111, 110, 123, 110, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string token()
    {
      int pos = this.pos;
      for (; this.pos < this.chars.Length; ++this.pos)
      {
        switch (this.chars[this.pos])
        {
          case '\t':
          case '\n':
          case ' ':
          case '#':
          case ';':
            goto label_4;
          default:
            continue;
        }
      }
label_4:
      return String.newhelper(this.chars, pos, this.pos - pos);
    }

    [LineNumberTable(new byte[] {24, 147, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void checkRead()
    {
      if (!String.instancehelper_equals(LParser.tokens[0], (object) "op"))
        return;
      LParser.tokens[1] = (string) LParser.opNameChanges.get((object) LParser.tokens[1], (object) LParser.tokens[1]);
    }

    [LineNumberTable(new byte[] {32, 98, 135, 114, 110, 191, 30, 146, 114, 171, 130, 101, 102, 101, 101, 127, 0, 100, 106, 127, 0, 132, 142, 165, 108, 166, 127, 8, 113, 139, 191, 17, 131, 127, 19, 105, 236, 70, 255, 12, 69, 226, 60, 130, 103, 199, 127, 9, 179, 100, 175, 115, 191, 19, 176, 174})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void statement()
    {
      int num1 = 0;
      this.tok = 0;
      while (this.pos < this.chars.Length)
      {
        int num2 = (int) this.chars[this.pos];
        if (this.tok >= LParser.tokens.Length)
          this.error(new StringBuilder().append("Line too long; may only contain ").append(LParser.tokens.Length).append(" tokens").toString());
        if (num2 != 10 && num2 != 59)
        {
          if (num1 != 0 && num2 != 32 && (num2 != 35 && num2 != 9))
            this.error("Expected space after string/token.");
          num1 = 0;
          switch (num2)
          {
            case 34:
              string[] tokens1 = LParser.tokens;
              LParser lparser1 = this;
              int tok1 = lparser1.tok;
              LParser lparser2 = lparser1;
              int index1 = tok1;
              lparser2.tok = tok1 + 1;
              string str1 = this.@string();
              tokens1[index1] = str1;
              num1 = 1;
              continue;
            case 35:
              this.comment();
              goto label_13;
            default:
              if (num2 != 32 && num2 != 9)
              {
                string[] tokens2 = LParser.tokens;
                LParser lparser3 = this;
                int tok2 = lparser3.tok;
                LParser lparser4 = lparser3;
                int index2 = tok2;
                lparser4.tok = tok2 + 1;
                string str2 = this.token();
                tokens2[index2] = str2;
                num1 = 1;
                continue;
              }
              ++this.pos;
              continue;
          }
        }
        else
          break;
      }
label_13:
      if (this.tok <= 0)
        return;
      this.checkRead();
      if (this.tok == 1 && String.instancehelper_charAt(LParser.tokens[0], String.instancehelper_length(LParser.tokens[0]) - 1) == ':')
      {
        if (LParser.jumpLocations.size >= 500)
          this.error("Too many jump locations. Max jumps: 500");
        LParser.jumpLocations.put((object) String.instancehelper_substring(LParser.tokens[0], 0, String.instancehelper_length(LParser.tokens[0]) - 1), this.line);
      }
      else
      {
        string str = (string) null;
        int num2;
        if ((num2 = !String.instancehelper_equals(LParser.tokens[0], (object) "jump") || this.tok <= 1 || Strings.canParseInt(LParser.tokens[1]) ? 0 : 1) != 0)
        {
          str = LParser.tokens[1];
          LParser.tokens[1] = "-1";
        }
        LStatement lstatement1;
        Exception exception;
        try
        {
          lstatement1 = LogicIO.read(LParser.tokens, this.tok);
          goto label_26;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception = (Exception) m0;
        }
        Log.err((Exception) exception);
        lstatement1 = (LStatement) new LStatements.InvalidStatement();
label_26:
        LStatement lstatement2 = lstatement1;
        LStatements.JumpStatement jumpStatement;
        if (lstatement2 is LStatements.JumpStatement && object.ReferenceEquals((object) (jumpStatement = (LStatements.JumpStatement) lstatement2), (object) (LStatements.JumpStatement) lstatement2) && num2 != 0)
          LParser.jumps.add((object) new LParser.JumpIndex(jumpStatement, str));
        if (lstatement1 != null)
          this.statements.add((object) lstatement1);
        else if (LAssembler.customParsers.containsKey((object) LParser.tokens[0]))
          this.statements.add((object) (LStatement) ((Func) LAssembler.customParsers.get((object) LParser.tokens[0])).get((object) LParser.tokens));
        else
          this.statements.add((object) new LStatements.InvalidStatement());
        ++this.line;
      }
    }

    [LineNumberTable(new byte[] {159, 140, 109, 140, 255, 17, 69, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LParser()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LParser"))
        return;
      LParser.tokens = new string[16];
      LParser.opNameChanges = StringMap.of(new object[4]
      {
        (object) "atan2",
        (object) "angle",
        (object) "dst",
        (object) "len"
      });
      LParser.jumps = new Seq();
      LParser.jumpLocations = new ObjectIntMap();
    }

    internal class JumpIndex : Object
    {
      internal LStatements.JumpStatement jump;
      internal string location;

      [LineNumberTable(new byte[] {160, 75, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JumpIndex([In] LStatements.JumpStatement obj0, [In] string obj1)
      {
        LParser.JumpIndex jumpIndex = this;
        this.jump = obj0;
        this.location = obj1;
      }
    }
  }
}
