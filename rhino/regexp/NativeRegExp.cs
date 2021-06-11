// Decompiled with JetBrains decompiler
// Type: rhino.regexp.NativeRegExp
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
using System.Threading;

namespace rhino.regexp
{
  [Implements(new string[] {"rhino.Function"})]
  public class NativeRegExp : IdScriptableObject, Function, Scriptable, Callable
  {
    [Modifiers]
    private static object REGEXP_TAG;
    public const int JSREG_GLOB = 1;
    public const int JSREG_FOLD = 2;
    public const int JSREG_MULTILINE = 4;
    public const int TEST = 0;
    public const int MATCH = 1;
    public const int PREFIX = 2;
    private const bool debug = false;
    private const byte REOP_SIMPLE_START = 1;
    private const byte REOP_EMPTY = 1;
    private const byte REOP_BOL = 2;
    private const byte REOP_EOL = 3;
    private const byte REOP_WBDRY = 4;
    private const byte REOP_WNONBDRY = 5;
    private const byte REOP_DOT = 6;
    private const byte REOP_DIGIT = 7;
    private const byte REOP_NONDIGIT = 8;
    private const byte REOP_ALNUM = 9;
    private const byte REOP_NONALNUM = 10;
    private const byte REOP_SPACE = 11;
    private const byte REOP_NONSPACE = 12;
    private const byte REOP_BACKREF = 13;
    private const byte REOP_FLAT = 14;
    private const byte REOP_FLAT1 = 15;
    private const byte REOP_FLATi = 16;
    private const byte REOP_FLAT1i = 17;
    private const byte REOP_UCFLAT1 = 18;
    private const byte REOP_UCFLAT1i = 19;
    private const byte REOP_CLASS = 22;
    private const byte REOP_NCLASS = 23;
    private const byte REOP_SIMPLE_END = 23;
    private const byte REOP_QUANT = 25;
    private const byte REOP_STAR = 26;
    private const byte REOP_PLUS = 27;
    private const byte REOP_OPT = 28;
    private const byte REOP_LPAREN = 29;
    private const byte REOP_RPAREN = 30;
    private const byte REOP_ALT = 31;
    private const byte REOP_JUMP = 32;
    private const byte REOP_ASSERT = 41;
    private const byte REOP_ASSERT_NOT = 42;
    private const byte REOP_ASSERTTEST = 43;
    private const byte REOP_ASSERTNOTTEST = 44;
    private const byte REOP_MINIMALSTAR = 45;
    private const byte REOP_MINIMALPLUS = 46;
    private const byte REOP_MINIMALOPT = 47;
    private const byte REOP_MINIMALQUANT = 48;
    private const byte REOP_ENDCHILD = 49;
    private const byte REOP_REPEAT = 51;
    private const byte REOP_MINIMALREPEAT = 52;
    private const byte REOP_ALTPREREQ = 53;
    private const byte REOP_ALTPREREQi = 54;
    private const byte REOP_ALTPREREQ2 = 55;
    private const byte REOP_END = 57;
    private const int ANCHOR_BOL = -2;
    private const int INDEX_LEN = 2;
    private const int Id_lastIndex = 1;
    private const int Id_source = 2;
    private const int Id_global = 3;
    private const int Id_ignoreCase = 4;
    private const int Id_multiline = 5;
    private const int MAX_INSTANCE_ID = 5;
    private const int Id_compile = 1;
    private const int Id_toString = 2;
    private const int Id_toSource = 3;
    private const int Id_exec = 4;
    private const int Id_test = 5;
    private const int Id_prefix = 6;
    private const int MAX_PROTOTYPE_ID = 6;
    private RECompiled re;
    internal object lastIndex;
    private int lastIndexAttr;
    [Modifiers]
    internal new static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 81, 232, 169, 219, 112, 231, 150, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeRegExp()
    {
      NativeRegExp nativeRegExp = this;
      this.lastIndex = (object) Double.valueOf(0.0);
      this.lastIndexAttr = 6;
    }

    [LineNumberTable(new byte[] {159, 78, 162, 103, 103, 98, 102, 112, 106, 99, 102, 101, 102, 101, 102, 133, 145, 102, 145, 229, 49, 235, 82, 135, 112, 199, 110, 117, 109, 109, 145, 105, 194, 112, 112, 110, 105, 194, 116, 105, 114, 141, 114, 241, 74, 173, 191, 109, 115, 165, 111, 165, 110, 111, 130, 104, 130, 105, 127, 1, 232, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static RECompiled compileRE(
      [In] Context obj0,
      [In] string obj1,
      [In] string obj2,
      [In] bool obj3)
    {
      int num1 = obj3 ? 1 : 0;
      RECompiled reCompiled = new RECompiled(obj1);
      int num2 = String.instancehelper_length(obj1);
      int num3 = 0;
      if (obj2 != null)
      {
        for (int index = 0; index < String.instancehelper_length(obj2); ++index)
        {
          int num4 = (int) String.instancehelper_charAt(obj2, index);
          int num5 = 0;
          switch (num4)
          {
            case 103:
              num5 = 1;
              break;
            case 105:
              num5 = 2;
              break;
            case 109:
              num5 = 4;
              break;
            default:
              NativeRegExp.reportError("msg.invalid.re.flag", String.valueOf((char) num4));
              break;
          }
          if ((num3 & num5) != 0)
            NativeRegExp.reportError("msg.invalid.re.flag", String.valueOf((char) num4));
          num3 |= num5;
        }
      }
      reCompiled.flags = num3;
      CompilerState compilerState = new CompilerState(obj0, reCompiled.source, num2, num3);
      if (num1 != 0 && num2 > 0)
      {
        compilerState.result = new RENode((byte) 14);
        compilerState.result.chr = compilerState.cpbegin[0];
        compilerState.result.length = num2;
        compilerState.result.flatIndex = 0;
        compilerState.progLength += 5;
      }
      else
      {
        if (!NativeRegExp.parseDisjunction(compilerState))
          return (RECompiled) null;
        if (compilerState.maxBackReference > compilerState.parenCount)
        {
          compilerState = new CompilerState(obj0, reCompiled.source, num2, num3);
          compilerState.backReferenceLimit = compilerState.parenCount;
          if (!NativeRegExp.parseDisjunction(compilerState))
            return (RECompiled) null;
        }
      }
      reCompiled.program = new byte[compilerState.progLength + 1];
      if (compilerState.classCount != 0)
      {
        reCompiled.classList = new RECharSet[compilerState.classCount];
        reCompiled.classCount = compilerState.classCount;
      }
      int num6 = NativeRegExp.emitREBytecode(compilerState, reCompiled, 0, compilerState.result);
      byte[] program = reCompiled.program;
      int index1 = num6;
      int num7 = num6 + 1;
      program[index1] = (byte) 57;
      reCompiled.parenCount = compilerState.parenCount;
      switch ((sbyte) reCompiled.program[0])
      {
        case 2:
          reCompiled.anchorCh = -2;
          break;
        case 14:
        case 16:
          int index2 = NativeRegExp.getIndex(reCompiled.program, 1);
          reCompiled.anchorCh = (int) reCompiled.source[index2];
          break;
        case 15:
        case 17:
          reCompiled.anchorCh = (int) (ushort) reCompiled.program[1];
          break;
        case 18:
        case 19:
          reCompiled.anchorCh = (int) (ushort) NativeRegExp.getIndex(reCompiled.program, 1);
          break;
        case 31:
          RENode result = compilerState.result;
          if (result.kid.op == (byte) 2 && result.kid2.op == (byte) 2)
          {
            reCompiled.anchorCh = -2;
            break;
          }
          break;
      }
      return reCompiled;
    }

    [LineNumberTable(new byte[] {160, 114, 135, 100, 103, 99, 173, 137, 102, 111, 206, 114, 112, 132, 113, 111, 111, 223, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object execSub([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2, [In] int obj3)
    {
      RegExpImpl impl = NativeRegExp.getImpl(obj0);
      string str = obj2.Length != 0 ? ScriptRuntime.toString(obj2[0]) : impl.input ?? ScriptRuntime.toString(Undefined.__\u003C\u003Einstance);
      double num = 0.0;
      if ((this.re.flags & 1) != 0)
        num = ScriptRuntime.toInteger(this.lastIndex);
      object objA;
      if (num < 0.0 || (double) String.instancehelper_length(str) < num)
      {
        this.lastIndex = (object) Double.valueOf(0.0);
        objA = (object) null;
      }
      else
      {
        int[] numArray = new int[1]
        {
          ByteCodeHelper.d2i(num)
        };
        objA = this.executeRegExp(obj0, obj1, impl, str, numArray, obj3);
        if ((this.re.flags & 1) != 0)
          this.lastIndex = (object) Double.valueOf(objA == null || object.ReferenceEquals(objA, Undefined.__\u003C\u003Einstance) ? 0.0 : (double) numArray[0]);
      }
      return objA;
    }

    [LineNumberTable(new byte[] {160, 89, 135, 98, 98, 105, 103, 113, 99, 134, 127, 5, 108, 132, 145, 99, 127, 10, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string escapeRegExp([In] object obj0)
    {
      string str1 = ScriptRuntime.toString(obj0);
      StringBuilder stringBuilder1 = (StringBuilder) null;
      int num1 = 0;
      CharSequence charSequence1;
      for (int index = String.instancehelper_indexOf(str1, 47); index > -1; index = String.instancehelper_indexOf(str1, 47, index + 1))
      {
        if (index == num1 || String.instancehelper_charAt(str1, index - 1) != '\\')
        {
          if (stringBuilder1 == null)
            stringBuilder1 = new StringBuilder();
          StringBuilder stringBuilder2 = stringBuilder1;
          string str2 = str1;
          int num2 = num1;
          int num3 = index;
          int num4 = num2;
          object obj = (object) str2;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          int num5 = num4;
          int num6 = num3;
          stringBuilder2.append(charSequence2, num5, num6);
          stringBuilder1.append("\\/");
          num1 = index + 1;
        }
      }
      if (stringBuilder1 != null)
      {
        StringBuilder stringBuilder2 = stringBuilder1;
        string str2 = str1;
        int num2 = num1;
        int num3 = String.instancehelper_length(str1);
        int num4 = num2;
        object obj = (object) str2;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        int num5 = num4;
        int num6 = num3;
        stringBuilder2.append(charSequence2, num5, num6);
        str1 = stringBuilder1.toString();
      }
      return str1;
    }

    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RegExpImpl getImpl([In] Context obj0) => (RegExpImpl) ScriptRuntime.getRegExpProxy(obj0);

    [LineNumberTable(new byte[] {168, 161, 134, 101, 104, 100, 194, 151, 99, 103, 134, 104, 118, 109, 199, 228, 69, 103, 229, 72, 106, 142, 112, 172, 109, 103, 144, 131, 118, 117, 106, 101, 106, 109, 107, 100, 116, 98, 100, 242, 54, 235, 77, 168, 228, 69, 123, 176, 104, 107, 107, 139, 109, 109, 141, 109, 234, 78, 108, 243, 71, 108, 179, 109, 109, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object executeRegExp(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] RegExpImpl obj2,
      [In] string obj3,
      [In] int[] obj4,
      [In] int obj5)
    {
      REGlobalData reGlobalData = new REGlobalData();
      int num1 = obj4[0];
      int num2 = String.instancehelper_length(obj3);
      if (num1 > num2)
        num1 = num2;
      if (!NativeRegExp.matchRegExp(reGlobalData, this.re, obj3, num1, num2, obj2.multiline))
        return obj5 != 2 ? (object) null : Undefined.__\u003C\u003Einstance;
      int cp = reGlobalData.cp;
      int[] numArray1 = obj4;
      int num3 = cp;
      int index1 = 0;
      int[] numArray2 = numArray1;
      int num4 = num3;
      numArray2[index1] = num3;
      int num5 = num4;
      int num6 = num5 - (num1 + reGlobalData.skipped);
      int num7 = cp - num6;
      object obj;
      Scriptable s;
      if (obj5 == 0)
      {
        obj = (object) Boolean.TRUE;
        s = (Scriptable) null;
      }
      else
      {
        obj = (object) obj0.newArray(obj1, 0);
        s = (Scriptable) obj;
        string str = String.instancehelper_substring(obj3, num7, num7 + num6);
        s.put(0, s, (object) str);
      }
      if (this.re.parenCount == 0)
      {
        obj2.parens = (SubString[]) null;
        obj2.lastParen = new SubString();
      }
      else
      {
        SubString subString = (SubString) null;
        obj2.parens = new SubString[this.re.parenCount];
        for (int index2 = 0; index2 < this.re.parenCount; ++index2)
        {
          int start = reGlobalData.parensIndex(index2);
          if (start != -1)
          {
            int len = reGlobalData.parensLength(index2);
            subString = new SubString(obj3, start, len);
            obj2.parens[index2] = subString;
            if (obj5 != 0)
              s.put(index2 + 1, s, (object) subString.toString());
          }
          else if (obj5 != 0)
            s.put(index2 + 1, s, Undefined.__\u003C\u003Einstance);
        }
        obj2.lastParen = subString;
      }
      if (obj5 != 0)
      {
        s.put("index", s, (object) Integer.valueOf(num1 + reGlobalData.skipped));
        s.put("input", s, (object) obj3);
      }
      if (obj2.lastMatch == null)
      {
        obj2.lastMatch = new SubString();
        obj2.leftContext = new SubString();
        obj2.rightContext = new SubString();
      }
      obj2.lastMatch.str = obj3;
      obj2.lastMatch.index = num7;
      obj2.lastMatch.length = num6;
      obj2.leftContext.str = obj3;
      if (obj0.getLanguageVersion() == 120)
      {
        obj2.leftContext.index = num1;
        obj2.leftContext.length = reGlobalData.skipped;
      }
      else
      {
        obj2.leftContext.index = 0;
        obj2.leftContext.length = num1 + reGlobalData.skipped;
      }
      obj2.rightContext.str = obj3;
      obj2.rightContext.index = num5;
      obj2.rightContext.length = num2 - num5;
      return obj;
    }

    [LineNumberTable(new byte[] {169, 35, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void reportError([In] string obj0, [In] string obj1) => throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("SyntaxError", ScriptRuntime.getMessage1(obj0, (object) obj1)));

    [LineNumberTable(new byte[] {161, 66, 104, 98, 103, 103, 146, 110, 104, 108, 104, 98, 108, 231, 69, 127, 1, 150, 113, 177, 116, 159, 32, 104, 113, 177, 116, 159, 32, 104, 113, 177, 177, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool parseDisjunction([In] CompilerState obj0)
    {
      if (!NativeRegExp.parseAlternative(obj0))
        return false;
      char[] cpbegin = obj0.cpbegin;
      int cp = obj0.cp;
      if (cp != cpbegin.Length && cpbegin[cp] == '|')
      {
        ++obj0.cp;
        RENode reNode = new RENode((byte) 31);
        reNode.kid = obj0.result;
        if (!NativeRegExp.parseDisjunction(obj0))
          return false;
        reNode.kid2 = obj0.result;
        obj0.result = reNode;
        if (reNode.kid.op == (byte) 14 && reNode.kid2.op == (byte) 14)
        {
          reNode.op = (obj0.flags & 2) != 0 ? (byte) 54 : (byte) 53;
          reNode.chr = reNode.kid.chr;
          reNode.index = (int) reNode.kid2.chr;
          obj0.progLength += 13;
        }
        else if (reNode.kid.op == (byte) 22 && reNode.kid.index < 256 && (reNode.kid2.op == (byte) 14 && (obj0.flags & 2) == 0))
        {
          reNode.op = (byte) 55;
          reNode.chr = reNode.kid2.chr;
          reNode.index = reNode.kid.index;
          obj0.progLength += 13;
        }
        else if (reNode.kid.op == (byte) 14 && reNode.kid2.op == (byte) 22 && (reNode.kid2.index < 256 && (obj0.flags & 2) == 0))
        {
          reNode.op = (byte) 55;
          reNode.chr = reNode.kid.chr;
          reNode.index = reNode.kid2.index;
          obj0.progLength += 13;
        }
        else
          obj0.progLength += 9;
      }
      return true;
    }

    [LineNumberTable(new byte[] {164, 36, 135, 102, 111, 159, 104, 101, 197, 108, 126, 101, 127, 0, 165, 103, 98, 101, 112, 106, 99, 101, 104, 139, 106, 98, 133, 105, 104, 229, 69, 105, 191, 19, 120, 179, 114, 106, 137, 103, 111, 148, 109, 106, 137, 103, 148, 106, 137, 103, 175, 133, 111, 112, 106, 111, 133, 111, 133, 99, 101, 112, 106, 105, 133, 99, 101, 112, 106, 105, 133, 113, 120, 113, 117, 114, 149, 111, 143, 145, 111, 111, 99, 101, 112, 106, 105, 130, 104, 103, 111, 159, 11, 194, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int emitREBytecode([In] CompilerState obj0, [In] RECompiled obj1, [In] int obj2, [In] RENode obj3)
    {
      byte[] program = obj1.program;
      for (; obj3 != null; obj3 = obj3.next)
      {
        byte[] numArray1 = program;
        int index1 = obj2;
        ++obj2;
        int op = (int) (sbyte) obj3.op;
        numArray1[index1] = (byte) op;
        switch ((sbyte) obj3.op)
        {
          case 1:
            obj2 += -1;
            break;
          case 13:
            obj2 = NativeRegExp.addIndex(program, obj2, obj3.parenIndex);
            break;
          case 14:
            if (obj3.flatIndex != -1)
            {
              for (; obj3.next != null && obj3.next.op == (byte) 14 && obj3.flatIndex + obj3.length == obj3.next.flatIndex; obj3.next = obj3.next.next)
                obj3.length += obj3.next.length;
            }
            if (obj3.flatIndex != -1 && obj3.length > 1)
            {
              program[obj2 - 1] = (obj0.flags & 2) == 0 ? (byte) 14 : (byte) 16;
              obj2 = NativeRegExp.addIndex(program, obj2, obj3.flatIndex);
              obj2 = NativeRegExp.addIndex(program, obj2, obj3.length);
              break;
            }
            if (obj3.chr < 'Ā')
            {
              program[obj2 - 1] = (obj0.flags & 2) == 0 ? (byte) 15 : (byte) 17;
              byte[] numArray2 = program;
              int index2 = obj2;
              ++obj2;
              int chr = (int) (sbyte) obj3.chr;
              numArray2[index2] = (byte) chr;
              break;
            }
            program[obj2 - 1] = (obj0.flags & 2) == 0 ? (byte) 18 : (byte) 19;
            obj2 = NativeRegExp.addIndex(program, obj2, (int) obj3.chr);
            break;
          case 22:
            if (!obj3.sense)
              program[obj2 - 1] = (byte) 23;
            obj2 = NativeRegExp.addIndex(program, obj2, obj3.index);
            obj1.classList[obj3.index] = new RECharSet(obj3.bmsize, obj3.startIndex, obj3.kidlen, obj3.sense);
            break;
          case 25:
            if (obj3.min == 0 && obj3.max == -1)
              program[obj2 - 1] = !obj3.greedy ? (byte) 45 : (byte) 26;
            else if (obj3.min == 0 && obj3.max == 1)
              program[obj2 - 1] = !obj3.greedy ? (byte) 47 : (byte) 28;
            else if (obj3.min == 1 && obj3.max == -1)
            {
              program[obj2 - 1] = !obj3.greedy ? (byte) 46 : (byte) 27;
            }
            else
            {
              if (!obj3.greedy)
                program[obj2 - 1] = (byte) 48;
              obj2 = NativeRegExp.addIndex(program, obj2, obj3.min);
              obj2 = NativeRegExp.addIndex(program, obj2, obj3.max + 1);
            }
            obj2 = NativeRegExp.addIndex(program, obj2, obj3.parenCount);
            obj2 = NativeRegExp.addIndex(program, obj2, obj3.parenIndex);
            int num1 = obj2;
            obj2 += 2;
            obj2 = NativeRegExp.emitREBytecode(obj0, obj1, obj2, obj3.kid);
            byte[] numArray3 = program;
            int index3 = obj2;
            ++obj2;
            numArray3[index3] = (byte) 49;
            NativeRegExp.resolveForwardJump(program, num1, obj2);
            break;
          case 29:
            obj2 = NativeRegExp.addIndex(program, obj2, obj3.parenIndex);
            obj2 = NativeRegExp.emitREBytecode(obj0, obj1, obj2, obj3.kid);
            byte[] numArray4 = program;
            int index4 = obj2;
            ++obj2;
            numArray4[index4] = (byte) 30;
            obj2 = NativeRegExp.addIndex(program, obj2, obj3.parenIndex);
            break;
          case 31:
            RENode kid2 = obj3.kid2;
            int num2 = obj2;
            obj2 += 2;
            obj2 = NativeRegExp.emitREBytecode(obj0, obj1, obj2, obj3.kid);
            byte[] numArray5 = program;
            int index5 = obj2;
            ++obj2;
            numArray5[index5] = (byte) 32;
            int num3 = obj2;
            obj2 += 2;
            NativeRegExp.resolveForwardJump(program, num2, obj2);
            obj2 = NativeRegExp.emitREBytecode(obj0, obj1, obj2, kid2);
            byte[] numArray6 = program;
            int index6 = obj2;
            ++obj2;
            numArray6[index6] = (byte) 32;
            int num4 = obj2;
            obj2 += 2;
            NativeRegExp.resolveForwardJump(program, num3, obj2);
            NativeRegExp.resolveForwardJump(program, num4, obj2);
            break;
          case 41:
            int num5 = obj2;
            obj2 += 2;
            obj2 = NativeRegExp.emitREBytecode(obj0, obj1, obj2, obj3.kid);
            byte[] numArray7 = program;
            int index7 = obj2;
            ++obj2;
            numArray7[index7] = (byte) 43;
            NativeRegExp.resolveForwardJump(program, num5, obj2);
            break;
          case 42:
            int num6 = obj2;
            obj2 += 2;
            obj2 = NativeRegExp.emitREBytecode(obj0, obj1, obj2, obj3.kid);
            byte[] numArray8 = program;
            int index8 = obj2;
            ++obj2;
            numArray8[index8] = (byte) 44;
            NativeRegExp.resolveForwardJump(program, num6, obj2);
            break;
          case 53:
          case 54:
          case 55:
            int num7 = obj3.op == (byte) 54 ? 1 : 0;
            NativeRegExp.addIndex(program, obj2, num7 == 0 ? (int) obj3.chr : (int) NativeRegExp.upcase(obj3.chr));
            obj2 += 2;
            NativeRegExp.addIndex(program, obj2, num7 == 0 ? obj3.index : (int) NativeRegExp.upcase((char) obj3.index));
            obj2 += 2;
            goto case 31;
        }
      }
      return obj2;
    }

    [LineNumberTable(1165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getIndex([In] byte[] obj0, [In] int obj1) => (int) obj0[obj1] << 8 | (int) obj0[obj1 + 1];

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isDigit([In] char obj0)
    {
      int num = (int) obj0;
      return 48 <= num && num <= 57;
    }

    [LineNumberTable(new byte[] {161, 120, 98, 98, 135, 159, 15, 99, 142, 103, 130, 104, 98, 99, 103, 132, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool parseAlternative([In] CompilerState obj0)
    {
      RENode reNode1 = (RENode) null;
      RENode reNode2 = (RENode) null;
      char[] cpbegin = obj0.cpbegin;
label_1:
      while (obj0.cp != obj0.cpend && cpbegin[obj0.cp] != '|' && (obj0.parenNesting == 0 || cpbegin[obj0.cp] != ')'))
      {
        if (!NativeRegExp.parseTerm(obj0))
          return false;
        if (reNode1 == null)
        {
          reNode1 = obj0.result;
          reNode2 = reNode1;
        }
        else
          reNode2.next = obj0.result;
        while (true)
        {
          if (reNode2.next != null)
            reNode2 = reNode2.next;
          else
            goto label_1;
        }
      }
      obj0.result = reNode1 ?? new RENode((byte) 1);
      return true;
    }

    [LineNumberTable(new byte[] {162, 141, 103, 118, 99, 232, 69, 191, 80, 108, 110, 130, 108, 110, 130, 113, 118, 191, 160, 211, 108, 110, 130, 108, 110, 226, 73, 149, 163, 116, 105, 106, 110, 205, 100, 103, 229, 74, 106, 147, 106, 245, 69, 109, 104, 165, 99, 103, 133, 110, 102, 116, 105, 106, 110, 205, 100, 103, 165, 109, 111, 110, 109, 237, 69, 99, 103, 133, 99, 103, 133, 99, 103, 133, 99, 103, 133, 99, 103, 165, 118, 103, 188, 110, 131, 103, 165, 166, 131, 99, 122, 118, 106, 165, 113, 119, 226, 56, 235, 75, 132, 103, 165, 108, 110, 133, 108, 110, 133, 109, 110, 133, 109, 110, 133, 109, 110, 133, 109, 110, 165, 109, 108, 108, 115, 110, 229, 69, 111, 130, 99, 159, 29, 110, 101, 137, 112, 101, 137, 176, 137, 110, 154, 110, 104, 98, 122, 111, 130, 110, 110, 103, 109, 237, 69, 111, 130, 109, 104, 141, 110, 111, 130, 108, 144, 108, 116, 162, 147, 254, 69, 127, 5, 98, 110, 165, 108, 110, 194, 121, 130, 109, 108, 108, 115, 206, 104, 110, 130, 99, 159, 21, 109, 108, 140, 110, 99, 133, 109, 108, 140, 110, 99, 133, 109, 108, 140, 110, 99, 165, 99, 232, 72, 127, 15, 110, 147, 109, 105, 127, 3, 105, 127, 3, 147, 105, 102, 109, 37, 133, 194, 164, 101, 109, 109, 173, 111, 195, 100, 234, 69, 100, 130, 110, 109, 109, 116, 122, 110, 142, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool parseTerm([In] CompilerState obj0)
    {
      char[] cpbegin = obj0.cpbegin;
      char[] chArray1 = cpbegin;
      CompilerState compilerState1 = obj0;
      int cp1 = compilerState1.cp;
      CompilerState compilerState2 = compilerState1;
      int index1 = cp1;
      compilerState2.cp = cp1 + 1;
      int num1 = (int) chArray1[index1];
      int num2 = 2;
      int parenCount1 = obj0.parenCount;
      switch (num1)
      {
        case 36:
          obj0.result = new RENode((byte) 3);
          ++obj0.progLength;
          return true;
        case 40:
          RENode reNode1 = (RENode) null;
          int num3;
          if (obj0.cp + 1 < obj0.cpend && cpbegin[obj0.cp] == '?' && ((num3 = (int) cpbegin[obj0.cp + 1]) == 61 || num3 == 33 || num3 == 58))
          {
            obj0.cp += 2;
            switch (num3)
            {
              case 33:
                reNode1 = new RENode((byte) 42);
                obj0.progLength += 4;
                break;
              case 61:
                reNode1 = new RENode((byte) 41);
                obj0.progLength += 4;
                break;
            }
          }
          else
          {
            reNode1 = new RENode((byte) 29);
            obj0.progLength += 6;
            RENode reNode2 = reNode1;
            CompilerState compilerState3 = obj0;
            int parenCount2 = compilerState3.parenCount;
            CompilerState compilerState4 = compilerState3;
            int num4 = parenCount2;
            compilerState4.parenCount = parenCount2 + 1;
            reNode2.parenIndex = num4;
          }
          ++obj0.parenNesting;
          if (!NativeRegExp.parseDisjunction(obj0))
            return false;
          if (obj0.cp == obj0.cpend || cpbegin[obj0.cp] != ')')
          {
            NativeRegExp.reportError("msg.unterm.paren", "");
            return false;
          }
          ++obj0.cp;
          --obj0.parenNesting;
          if (reNode1 != null)
          {
            reNode1.kid = obj0.result;
            obj0.result = reNode1;
            break;
          }
          break;
        case 41:
          NativeRegExp.reportError("msg.re.unmatched.right.paren", "");
          return false;
        case 42:
        case 43:
        case 63:
          NativeRegExp.reportError("msg.bad.quant", String.valueOf(cpbegin[obj0.cp - 1]));
          return false;
        case 46:
          obj0.result = new RENode((byte) 6);
          ++obj0.progLength;
          break;
        case 91:
          obj0.result = new RENode((byte) 22);
          int cp2 = obj0.cp;
          obj0.result.startIndex = cp2;
          for (; obj0.cp != obj0.cpend; ++obj0.cp)
          {
            if (cpbegin[obj0.cp] == '\\')
              ++obj0.cp;
            else if (cpbegin[obj0.cp] == ']')
            {
              obj0.result.kidlen = obj0.cp - cp2;
              RENode result1 = obj0.result;
              CompilerState compilerState3 = obj0;
              int classCount = compilerState3.classCount;
              CompilerState compilerState4 = compilerState3;
              int num4 = classCount;
              compilerState4.classCount = classCount + 1;
              result1.index = num4;
              CompilerState compilerState5 = obj0;
              RENode result2 = obj0.result;
              char[] chArray2 = cpbegin;
              int num5 = cp2;
              CompilerState compilerState6 = obj0;
              int cp3 = compilerState6.cp;
              CompilerState compilerState7 = compilerState6;
              int num6 = cp3;
              compilerState7.cp = cp3 + 1;
              if (!NativeRegExp.calculateBitmapSize(compilerState5, result2, chArray2, num5, num6))
                return false;
              obj0.progLength += 3;
              goto label_73;
            }
          }
          NativeRegExp.reportError("msg.unterm.class", "");
          return false;
        case 92:
          if (obj0.cp < obj0.cpend)
          {
            char[] chArray2 = cpbegin;
            CompilerState compilerState3 = obj0;
            int cp3 = compilerState3.cp;
            CompilerState compilerState4 = compilerState3;
            int index2 = cp3;
            compilerState4.cp = cp3 + 1;
            int num4 = (int) chArray2[index2];
            switch (num4)
            {
              case 48:
                NativeRegExp.reportWarning(obj0.cx, "msg.bad.backref", "");
                int num5;
                int num6;
                for (num5 = 0; num5 < 32 && obj0.cp < obj0.cpend; num5 = 8 * num5 + (num6 - 48))
                {
                  num6 = (int) cpbegin[obj0.cp];
                  switch (num6)
                  {
                    case 48:
                    case 49:
                    case 50:
                    case 51:
                    case 52:
                    case 53:
                    case 54:
                    case 55:
                      ++obj0.cp;
                      continue;
                    default:
                      goto label_16;
                  }
                }
label_16:
                int num7 = (int) (ushort) num5;
                NativeRegExp.doFlat(obj0, (char) num7);
                break;
              case 49:
              case 50:
              case 51:
              case 52:
              case 53:
              case 54:
              case 55:
              case 56:
              case 57:
                int num8 = obj0.cp - 1;
                int decimalValue = NativeRegExp.getDecimalValue((char) num4, obj0, (int) ushort.MaxValue, "msg.overlarge.backref");
                if (decimalValue > obj0.backReferenceLimit)
                  NativeRegExp.reportWarning(obj0.cx, "msg.bad.backref", "");
                if (decimalValue > obj0.backReferenceLimit)
                {
                  obj0.cp = num8;
                  if (num4 >= 56)
                  {
                    int num9 = 92;
                    NativeRegExp.doFlat(obj0, (char) num9);
                    break;
                  }
                  ++obj0.cp;
                  int num10;
                  int num11;
                  for (num10 = num4 - 48; num10 < 32 && obj0.cp < obj0.cpend; num10 = 8 * num10 + (num11 - 48))
                  {
                    num11 = (int) cpbegin[obj0.cp];
                    switch (num11)
                    {
                      case 48:
                      case 49:
                      case 50:
                      case 51:
                      case 52:
                      case 53:
                      case 54:
                      case 55:
                        ++obj0.cp;
                        continue;
                      default:
                        goto label_26;
                    }
                  }
label_26:
                  int num12 = (int) (ushort) num10;
                  NativeRegExp.doFlat(obj0, (char) num12);
                  break;
                }
                obj0.result = new RENode((byte) 13);
                obj0.result.parenIndex = decimalValue - 1;
                obj0.progLength += 3;
                if (obj0.maxBackReference < decimalValue)
                {
                  obj0.maxBackReference = decimalValue;
                  break;
                }
                break;
              case 66:
                obj0.result = new RENode((byte) 5);
                ++obj0.progLength;
                return true;
              case 68:
                obj0.result = new RENode((byte) 8);
                ++obj0.progLength;
                break;
              case 83:
                obj0.result = new RENode((byte) 12);
                ++obj0.progLength;
                break;
              case 87:
                obj0.result = new RENode((byte) 10);
                ++obj0.progLength;
                break;
              case 98:
                obj0.result = new RENode((byte) 4);
                ++obj0.progLength;
                return true;
              case 99:
                int num13;
                if (obj0.cp < obj0.cpend && NativeRegExp.isControlLetter(cpbegin[obj0.cp]))
                {
                  char[] chArray3 = cpbegin;
                  CompilerState compilerState5 = obj0;
                  int cp4 = compilerState5.cp;
                  CompilerState compilerState6 = compilerState5;
                  int index3 = cp4;
                  compilerState6.cp = cp4 + 1;
                  num13 = (int) (ushort) ((uint) chArray3[index3] & 31U);
                }
                else
                {
                  --obj0.cp;
                  num13 = 92;
                }
                NativeRegExp.doFlat(obj0, (char) num13);
                break;
              case 100:
                obj0.result = new RENode((byte) 7);
                ++obj0.progLength;
                break;
              case 102:
                int num14 = 12;
                NativeRegExp.doFlat(obj0, (char) num14);
                break;
              case 110:
                int num15 = 10;
                NativeRegExp.doFlat(obj0, (char) num15);
                break;
              case 114:
                int num16 = 13;
                NativeRegExp.doFlat(obj0, (char) num16);
                break;
              case 115:
                obj0.result = new RENode((byte) 11);
                ++obj0.progLength;
                break;
              case 116:
                int num17 = 9;
                NativeRegExp.doFlat(obj0, (char) num17);
                break;
              case 117:
                num2 += 2;
                goto case 120;
              case 118:
                int num18 = 11;
                NativeRegExp.doFlat(obj0, (char) num18);
                break;
              case 119:
                obj0.result = new RENode((byte) 9);
                ++obj0.progLength;
                break;
              case 120:
                int accumulator = 0;
                for (int index3 = 0; index3 < num2 && obj0.cp < obj0.cpend; ++index3)
                {
                  char[] chArray3 = cpbegin;
                  CompilerState compilerState5 = obj0;
                  int cp4 = compilerState5.cp;
                  CompilerState compilerState6 = compilerState5;
                  int index4 = cp4;
                  compilerState6.cp = cp4 + 1;
                  accumulator = Kit.xDigitToInt((int) chArray3[index4], accumulator);
                  if (accumulator < 0)
                  {
                    obj0.cp -= index3 + 2;
                    char[] chArray4 = cpbegin;
                    CompilerState compilerState7 = obj0;
                    int cp5 = compilerState7.cp;
                    CompilerState compilerState8 = compilerState7;
                    int index5 = cp5;
                    compilerState8.cp = cp5 + 1;
                    accumulator = (int) chArray4[index5];
                    break;
                  }
                }
                int num19 = (int) (ushort) accumulator;
                NativeRegExp.doFlat(obj0, (char) num19);
                break;
              default:
                obj0.result = new RENode((byte) 14);
                obj0.result.chr = (char) num4;
                obj0.result.length = 1;
                obj0.result.flatIndex = obj0.cp - 1;
                obj0.progLength += 3;
                break;
            }
          }
          else
          {
            NativeRegExp.reportError("msg.trail.backslash", "");
            return false;
          }
          break;
        case 94:
          obj0.result = new RENode((byte) 2);
          ++obj0.progLength;
          return true;
        default:
          obj0.result = new RENode((byte) 14);
          obj0.result.chr = (char) num1;
          obj0.result.length = 1;
          obj0.result.flatIndex = obj0.cp - 1;
          obj0.progLength += 3;
          break;
      }
label_73:
      RENode result = obj0.result;
      if (obj0.cp == obj0.cpend)
        return true;
      int num20 = 0;
      switch (cpbegin[obj0.cp])
      {
        case '*':
          obj0.result = new RENode((byte) 25);
          obj0.result.min = 0;
          obj0.result.max = -1;
          obj0.progLength += 8;
          num20 = 1;
          break;
        case '+':
          obj0.result = new RENode((byte) 25);
          obj0.result.min = 1;
          obj0.result.max = -1;
          obj0.progLength += 8;
          num20 = 1;
          break;
        case '?':
          obj0.result = new RENode((byte) 25);
          obj0.result.min = 0;
          obj0.result.max = 1;
          obj0.progLength += 8;
          num20 = 1;
          break;
        case '{':
          int num21 = -1;
          int cp6 = obj0.cp;
          CompilerState compilerState9 = obj0;
          int num22 = compilerState9.cp + 1;
          CompilerState compilerState10 = compilerState9;
          int num23 = num22;
          compilerState10.cp = num22;
          int length1 = cpbegin.Length;
          int num24;
          if (num23 < length1 && NativeRegExp.isDigit((char) (num24 = (int) cpbegin[obj0.cp])))
          {
            ++obj0.cp;
            int decimalValue = NativeRegExp.getDecimalValue((char) num24, obj0, (int) ushort.MaxValue, "msg.overlarge.min");
            if (obj0.cp < cpbegin.Length)
            {
              int num4 = (int) cpbegin[obj0.cp];
              if (num4 == 44)
              {
                CompilerState compilerState3 = obj0;
                int num5 = compilerState3.cp + 1;
                CompilerState compilerState4 = compilerState3;
                int num6 = num5;
                compilerState4.cp = num5;
                int length2 = cpbegin.Length;
                if (num6 < length2)
                {
                  num4 = (int) cpbegin[obj0.cp];
                  if (NativeRegExp.isDigit((char) num4))
                  {
                    CompilerState compilerState5 = obj0;
                    int num7 = compilerState5.cp + 1;
                    CompilerState compilerState6 = compilerState5;
                    int num8 = num7;
                    compilerState6.cp = num7;
                    int length3 = cpbegin.Length;
                    if (num8 < length3)
                    {
                      num21 = NativeRegExp.getDecimalValue((char) num4, obj0, (int) ushort.MaxValue, "msg.overlarge.max");
                      num4 = (int) cpbegin[obj0.cp];
                      if (decimalValue > num21)
                      {
                        NativeRegExp.reportError("msg.max.lt.min", String.valueOf(cpbegin[obj0.cp]));
                        return false;
                      }
                      goto label_88;
                    }
                    else
                      goto label_88;
                  }
                  else
                    goto label_88;
                }
              }
              num21 = decimalValue;
label_88:
              if (num4 == 125)
              {
                obj0.result = new RENode((byte) 25);
                obj0.result.min = decimalValue;
                obj0.result.max = num21;
                obj0.progLength += 12;
                num20 = 1;
              }
            }
          }
          if (num20 == 0)
          {
            obj0.cp = cp6;
            break;
          }
          break;
      }
      if (num20 == 0)
        return true;
      ++obj0.cp;
      obj0.result.kid = result;
      obj0.result.parenIndex = parenCount1;
      obj0.result.parenCount = obj0.parenCount - parenCount1;
      if (obj0.cp < obj0.cpend && cpbegin[obj0.cp] == '?')
      {
        ++obj0.cp;
        obj0.result.greedy = false;
      }
      else
        obj0.result.greedy = true;
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isControlLetter([In] char obj0)
    {
      int num = (int) obj0;
      return 97 <= num && num <= 122 || 65 <= num && num <= 90;
    }

    [LineNumberTable(new byte[] {159, 45, 162, 104, 106, 134, 130, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static char upcase([In] char obj0)
    {
      int num = (int) obj0;
      if (num < 128)
        return 97 <= num && num <= 122 ? (char) (num - 32) : (char) num;
      int upperCase = (int) Character.toUpperCase((char) num);
      return upperCase < 128 ? (char) num : (char) upperCase;
    }

    [LineNumberTable(new byte[] {159, 42, 130, 104, 106, 134, 130, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static char downcase([In] char obj0)
    {
      int num = (int) obj0;
      if (num < 128)
        return 65 <= num && num <= 90 ? (char) (num + 32) : (char) num;
      int lowerCase = (int) Character.toLowerCase((char) num);
      return lowerCase < 128 ? (char) num : (char) lowerCase;
    }

    [LineNumberTable(new byte[] {169, 28, 106, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void reportWarning([In] Context obj0, [In] string obj1, [In] string obj2)
    {
      if (!obj0.hasFeature(11))
        return;
      Context.reportWarning(ScriptRuntime.getMessage1(obj1, (object) obj2));
    }

    [LineNumberTable(new byte[] {158, 216, 98, 109, 108, 108, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void doFlat([In] CompilerState obj0, [In] char obj1)
    {
      int num = (int) obj1;
      obj0.result = new RENode((byte) 14);
      obj0.result.chr = (char) num;
      obj0.result.length = 1;
      obj0.result.flatIndex = -1;
      obj0.progLength += 3;
    }

    [LineNumberTable(new byte[] {158, 214, 162, 98, 103, 103, 102, 110, 105, 104, 130, 99, 108, 101, 134, 98, 227, 53, 240, 79, 99, 107, 37, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getDecimalValue([In] char obj0, [In] CompilerState obj1, [In] int obj2, [In] string obj3)
    {
      int num1 = (int) obj0;
      int num2 = 0;
      int cp = obj1.cp;
      char[] cpbegin = obj1.cpbegin;
      int num3 = num1 - 48;
      for (; obj1.cp != obj1.cpend; ++obj1.cp)
      {
        int num4 = (int) cpbegin[obj1.cp];
        if (NativeRegExp.isDigit((char) num4))
        {
          if (num2 == 0)
          {
            int num5 = num3 * 10 + (num4 - 48);
            if (num5 < obj2)
            {
              num3 = num5;
            }
            else
            {
              num2 = 1;
              num3 = obj2;
            }
          }
        }
        else
          break;
      }
      if (num2 != 0)
        NativeRegExp.reportError(obj3, String.valueOf(cpbegin, cp, obj1.cp - cp));
      return num3;
    }

    [LineNumberTable(new byte[] {161, 147, 226, 69, 98, 130, 103, 135, 101, 130, 103, 101, 167, 136, 98, 145, 101, 106, 159, 160, 212, 99, 133, 100, 133, 100, 133, 100, 133, 100, 133, 100, 133, 111, 143, 101, 100, 133, 164, 99, 109, 106, 107, 165, 104, 100, 226, 56, 232, 75, 100, 133, 99, 111, 130, 100, 229, 70, 99, 111, 130, 107, 226, 79, 103, 101, 108, 101, 108, 101, 108, 101, 108, 105, 134, 165, 100, 162, 100, 194, 170, 99, 101, 111, 130, 132, 103, 103, 101, 98, 100, 197, 106, 106, 106, 142, 101, 99, 101, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool calculateBitmapSize(
      [In] CompilerState obj0,
      [In] RENode obj1,
      [In] char[] obj2,
      [In] int obj3,
      [In] int obj4)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      obj1.bmsize = 0;
      obj1.sense = true;
      if (obj3 == obj4)
        return true;
      if (obj2[obj3] == '^')
      {
        ++obj3;
        obj1.sense = false;
      }
      while (obj3 != obj4)
      {
        int num4 = 2;
        int num5;
        if (obj2[obj3] == '\\')
        {
          ++obj3;
          char[] chArray1 = obj2;
          int index1 = obj3;
          ++obj3;
          int num6 = (int) chArray1[index1];
          switch (num6)
          {
            case 48:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
              int num7 = num6 - 48;
              int num8 = (int) obj2[obj3];
              if (48 <= num8 && num8 <= 55)
              {
                ++obj3;
                num7 = 8 * num7 + (num8 - 48);
                int num9 = (int) obj2[obj3];
                if (48 <= num9 && num9 <= 55)
                {
                  ++obj3;
                  int num10 = 8 * num7 + (num9 - 48);
                  if (num10 <= (int) byte.MaxValue)
                    num7 = num10;
                  else
                    obj3 += -1;
                }
              }
              num5 = num7;
              break;
            case 68:
            case 83:
            case 87:
            case 115:
            case 119:
              if (num3 != 0)
              {
                NativeRegExp.reportError("msg.bad.range", "");
                return false;
              }
              obj1.bmsize = 65536;
              return true;
            case 98:
              num5 = 8;
              break;
            case 99:
              if (obj3 < obj4 && NativeRegExp.isControlLetter(obj2[obj3]))
              {
                char[] chArray2 = obj2;
                int index2 = obj3;
                ++obj3;
                int num9 = (int) (ushort) ((uint) chArray2[index2] & 31U);
              }
              else
                obj3 += -1;
              num5 = 92;
              break;
            case 100:
              if (num3 != 0)
              {
                NativeRegExp.reportError("msg.bad.range", "");
                return false;
              }
              num5 = 57;
              break;
            case 102:
              num5 = 12;
              break;
            case 110:
              num5 = 10;
              break;
            case 114:
              num5 = 13;
              break;
            case 116:
              num5 = 9;
              break;
            case 117:
              num4 += 2;
              goto case 120;
            case 118:
              num5 = 11;
              break;
            case 120:
              int accumulator = 0;
              for (int index2 = 0; index2 < num4 && obj3 < obj4; ++index2)
              {
                char[] chArray2 = obj2;
                int index3 = obj3;
                ++obj3;
                accumulator = Kit.xDigitToInt((int) chArray2[index3], accumulator);
                if (accumulator < 0)
                {
                  obj3 -= index2 + 1;
                  accumulator = 92;
                  break;
                }
              }
              num5 = accumulator;
              break;
            default:
              num5 = num6;
              break;
          }
        }
        else
        {
          char[] chArray = obj2;
          int index = obj3;
          ++obj3;
          num5 = (int) chArray[index];
        }
        if (num3 != 0)
        {
          if (num1 > num5)
          {
            NativeRegExp.reportError("msg.bad.range", "");
            return false;
          }
          num3 = 0;
        }
        else if (obj3 < obj4 - 1 && obj2[obj3] == '-')
        {
          ++obj3;
          num3 = 1;
          num1 = (int) (ushort) num5;
          continue;
        }
        if ((obj0.flags & 2) != 0)
        {
          int num6 = (int) NativeRegExp.upcase((char) num5);
          int num7 = (int) NativeRegExp.downcase((char) num5);
          num5 = num6 < num7 ? num7 : num6;
        }
        if (num5 > num2)
          num2 = num5;
      }
      obj1.bmsize = num2 + 1;
      return true;
    }

    [LineNumberTable(new byte[] {164, 18, 111, 104, 112, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int addIndex([In] byte[] obj0, [In] int obj1, [In] int obj2)
    {
      if (obj2 < 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      if (obj2 > (int) ushort.MaxValue)
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError("Too complex regexp"));
      obj0[obj1] = (byte) (obj2 >> 8);
      obj0[obj1 + 1] = (byte) obj2;
      return obj1 + 2;
    }

    [LineNumberTable(new byte[] {164, 9, 111, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void resolveForwardJump([In] byte[] obj0, [In] int obj1, [In] int obj2)
    {
      if (obj1 > obj2)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      NativeRegExp.addIndex(obj0, obj1, obj2 - obj1);
    }

    [LineNumberTable(new byte[] {165, 78, 103, 137, 226, 70, 130, 108, 148, 100, 129, 113, 122, 134, 186, 103, 99, 155, 100, 115, 159, 160, 212, 99, 133, 100, 133, 100, 133, 100, 133, 100, 133, 100, 133, 120, 156, 100, 132, 133, 166, 99, 109, 115, 105, 197, 103, 100, 130, 233, 53, 235, 77, 101, 229, 79, 103, 111, 114, 100, 108, 111, 108, 100, 108, 105, 134, 164, 101, 165, 106, 133, 105, 145, 133, 114, 105, 9, 232, 69, 114, 105, 9, 232, 69, 114, 106, 9, 232, 69, 114, 106, 9, 232, 69, 100, 226, 70, 211, 102, 114, 119, 108, 104, 105, 105, 102, 104, 102, 104, 107, 98, 130, 137, 135, 111, 109, 143, 136, 105, 116, 100, 98, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void processCharSetImpl([In] REGlobalData obj0, [In] RECharSet obj1)
    {
      int index1 = obj1.startIndex;
      int num1 = index1 + obj1.strlength;
      int num2 = 0;
      int num3 = 0;
      int length = (obj1.length + 7) / 8;
      obj1.bits = new byte[length];
      Thread.MemoryBarrier();
      if (index1 == num1)
        return;
      if (obj0.regexp.source[index1] == '^')
      {
        if (!NativeRegExp.\u0024assertionsDisabled && obj1.sense)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
        ++index1;
      }
      else if (!NativeRegExp.\u0024assertionsDisabled && !obj1.sense)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
label_8:
      while (index1 != num1)
      {
        int num4 = 2;
        int num5;
        if (obj0.regexp.source[index1] == '\\')
        {
          int num6 = index1 + 1;
          char[] source1 = obj0.regexp.source;
          int index2 = num6;
          index1 = num6 + 1;
          int num7 = (int) source1[index2];
          switch (num7)
          {
            case 48:
            case 49:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            case 55:
              int num8 = num7 - 48;
              int num9 = (int) obj0.regexp.source[index1];
              if (48 <= num9 && num9 <= 55)
              {
                ++index1;
                num8 = 8 * num8 + (num9 - 48);
                int num10 = (int) obj0.regexp.source[index1];
                if (48 <= num10 && num10 <= 55)
                {
                  ++index1;
                  int num11 = 8 * num8 + (num10 - 48);
                  if (num11 <= (int) byte.MaxValue)
                    num8 = num11;
                  else
                    index1 += -1;
                }
              }
              num5 = (int) (ushort) num8;
              break;
            case 68:
              NativeRegExp.addCharacterRangeToCharSet(obj1, char.MinValue, '/');
              NativeRegExp.addCharacterRangeToCharSet(obj1, ':', (char) (obj1.length - 1));
              continue;
            case 83:
              int num12 = obj1.length - 1;
              while (true)
              {
                if (num12 >= 0)
                {
                  if (!NativeRegExp.isREWhiteSpace(num12))
                    NativeRegExp.addCharacterToCharSet(obj1, (char) num12);
                  num12 += -1;
                }
                else
                  goto label_8;
              }
            case 87:
              int num13 = obj1.length - 1;
              while (true)
              {
                if (num13 >= 0)
                {
                  if (!NativeRegExp.isWord((char) num13))
                    NativeRegExp.addCharacterToCharSet(obj1, (char) num13);
                  num13 += -1;
                }
                else
                  goto label_8;
              }
            case 98:
              num5 = 8;
              break;
            case 99:
              if (index1 < num1 && NativeRegExp.isControlLetter(obj0.regexp.source[index1]))
              {
                char[] source2 = obj0.regexp.source;
                int index3 = index1;
                ++index1;
                num5 = (int) (ushort) ((uint) source2[index3] & 31U);
                break;
              }
              index1 += -1;
              num5 = 92;
              break;
            case 100:
              NativeRegExp.addCharacterRangeToCharSet(obj1, '0', '9');
              continue;
            case 102:
              num5 = 12;
              break;
            case 110:
              num5 = 10;
              break;
            case 114:
              num5 = 13;
              break;
            case 115:
              int num14 = obj1.length - 1;
              while (true)
              {
                if (num14 >= 0)
                {
                  if (NativeRegExp.isREWhiteSpace(num14))
                    NativeRegExp.addCharacterToCharSet(obj1, (char) num14);
                  num14 += -1;
                }
                else
                  goto label_8;
              }
            case 116:
              num5 = 9;
              break;
            case 117:
              num4 += 2;
              goto case 120;
            case 118:
              num5 = 11;
              break;
            case 119:
              int num15 = obj1.length - 1;
              while (true)
              {
                if (num15 >= 0)
                {
                  if (NativeRegExp.isWord((char) num15))
                    NativeRegExp.addCharacterToCharSet(obj1, (char) num15);
                  num15 += -1;
                }
                else
                  goto label_8;
              }
            case 120:
              int num16 = 0;
              for (int index3 = 0; index3 < num4 && index1 < num1; ++index3)
              {
                char[] source2 = obj0.regexp.source;
                int index4 = index1;
                ++index1;
                int asciiHexDigit = NativeRegExp.toASCIIHexDigit((int) source2[index4]);
                if (asciiHexDigit < 0)
                {
                  index1 -= index3 + 1;
                  num16 = 92;
                  break;
                }
                num16 = num16 << 4 | asciiHexDigit;
              }
              num5 = (int) (ushort) num16;
              break;
            default:
              num5 = num7;
              break;
          }
        }
        else
        {
          char[] source = obj0.regexp.source;
          int index2 = index1;
          ++index1;
          num5 = (int) source[index2];
        }
        if (num3 != 0)
        {
          if ((obj0.regexp.flags & 2) != 0)
          {
            if (!NativeRegExp.\u0024assertionsDisabled && num2 > num5)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new AssertionError();
            }
            int num6 = num2;
            while (num6 <= num5)
            {
              NativeRegExp.addCharacterToCharSet(obj1, (char) num6);
              int num7 = (int) NativeRegExp.upcase((char) num6);
              int num8 = (int) NativeRegExp.downcase((char) num6);
              if (num6 != num7)
                NativeRegExp.addCharacterToCharSet(obj1, (char) num7);
              if (num6 != num8)
                NativeRegExp.addCharacterToCharSet(obj1, (char) num8);
              num6 = (int) (ushort) (num6 + 1);
              if (num6 == 0)
                break;
            }
          }
          else
            NativeRegExp.addCharacterRangeToCharSet(obj1, (char) num2, (char) num5);
          num3 = 0;
        }
        else
        {
          if ((obj0.regexp.flags & 2) != 0)
          {
            NativeRegExp.addCharacterToCharSet(obj1, NativeRegExp.upcase((char) num5));
            NativeRegExp.addCharacterToCharSet(obj1, NativeRegExp.downcase((char) num5));
          }
          else
            NativeRegExp.addCharacterToCharSet(obj1, (char) num5);
          if (index1 < num1 - 1 && obj0.regexp.source[index1] == '-')
          {
            ++index1;
            num3 = 1;
            num2 = num5;
          }
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int toASCIIHexDigit([In] int obj0)
    {
      if (obj0 < 48)
        return -1;
      if (obj0 <= 57)
        return obj0 - 48;
      obj0 |= 32;
      return 97 <= obj0 && obj0 <= 102 ? obj0 - 97 + 10 : -1;
    }

    [LineNumberTable(new byte[] {158, 39, 100, 100, 132, 109, 213, 101, 133, 100, 159, 18, 127, 4, 106, 44, 136, 159, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void addCharacterRangeToCharSet([In] RECharSet obj0, [In] char obj1, [In] char obj2)
    {
      int num1 = (int) obj1;
      int num2 = (int) obj2;
      int num3 = num1 / 8;
      int num4 = num2 / 8;
      if (num2 >= obj0.length || num1 > num2)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("SyntaxError", "invalid range in character class"));
      int num5 = (int) (ushort) (num1 & 7);
      int num6 = (int) (ushort) (num2 & 7);
      if (num3 == num4)
      {
        byte[] bits = obj0.bits;
        int index = num3;
        byte[] numArray = bits;
        numArray[index] = (byte) ((int) (sbyte) numArray[index] | (int) byte.MaxValue >> 7 - (num6 - num5) << num5);
      }
      else
      {
        byte[] bits1 = obj0.bits;
        int index1 = num3;
        byte[] numArray1 = bits1;
        numArray1[index1] = (byte) ((int) (sbyte) numArray1[index1] | (int) byte.MaxValue << num5);
        for (int index2 = num3 + 1; index2 < num4; ++index2)
          obj0.bits[index2] = byte.MaxValue;
        byte[] bits2 = obj0.bits;
        int index3 = num4;
        byte[] numArray2 = bits2;
        numArray2[index3] = (byte) ((int) (sbyte) numArray2[index3] | (int) byte.MaxValue >> 7 - num6);
      }
    }

    [LineNumberTable(376)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isREWhiteSpace([In] int obj0) => ScriptRuntime.isJSWhitespaceOrLineTerminator(obj0);

    [LineNumberTable(new byte[] {158, 43, 162, 100, 105, 181, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void addCharacterToCharSet([In] RECharSet obj0, [In] char obj1)
    {
      int num1 = (int) obj1;
      int num2 = num1 / 8;
      if (num1 >= obj0.length)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("SyntaxError", "invalid range in character class"));
      byte[] bits = obj0.bits;
      int index = num2;
      byte[] numArray = bits;
      numArray[index] = (byte) ((int) (sbyte) numArray[index] | 1 << (num1 & 7));
    }

    [LineNumberTable(364)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isWord([In] char obj0)
    {
      int num = (int) obj0;
      return 97 <= num && num <= 122 || 65 <= num && num <= 90 || (NativeRegExp.isDigit((char) num) || num == 95);
    }

    [LineNumberTable(new byte[] {165, 67, 104, 106, 103, 142, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void processCharSet([In] REGlobalData obj0, [In] RECharSet obj1)
    {
      lock (obj1)
      {
        if (obj1.converted)
          return;
        NativeRegExp.processCharSetImpl(obj0, obj1);
        obj1.converted = true;
        Thread.MemoryBarrier();
      }
    }

    [LineNumberTable(372)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isLineTerm([In] char obj0) => ScriptRuntime.isJSLineTerminator((int) obj0);

    [LineNumberTable(new byte[] {165, 1, 114, 98, 104, 100, 130, 104, 107, 130, 111, 102, 106, 112, 116, 226, 60, 230, 70, 113, 130, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool backrefMatcher([In] REGlobalData obj0, [In] int obj1, [In] string obj2, [In] int obj3)
    {
      if (obj0.parens == null || obj1 >= obj0.parens.Length)
        return false;
      int num1 = obj0.parensIndex(obj1);
      if (num1 == -1)
        return true;
      int num2 = obj0.parensLength(obj1);
      if (obj0.cp + num2 > obj3)
        return false;
      if ((obj0.regexp.flags & 2) != 0)
      {
        for (int index = 0; index < num2; ++index)
        {
          int num3 = (int) String.instancehelper_charAt(obj2, num1 + index);
          int num4 = (int) String.instancehelper_charAt(obj2, obj0.cp + index);
          if (num3 != num4 && (int) NativeRegExp.upcase((char) num3) != (int) NativeRegExp.upcase((char) num4))
            return false;
        }
      }
      else if (!String.instancehelper_regionMatches(obj2, num1, obj2, obj0.cp, num2))
        return false;
      obj0.cp += num2;
      return true;
    }

    [LineNumberTable(new byte[] {164, 201, 108, 98, 102, 127, 0, 2, 230, 69, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool flatNMatcher(
      [In] REGlobalData obj0,
      [In] int obj1,
      [In] int obj2,
      [In] string obj3,
      [In] int obj4)
    {
      if (obj0.cp + obj2 > obj4)
        return false;
      for (int index = 0; index < obj2; ++index)
      {
        if ((int) obj0.regexp.source[obj1 + index] != (int) String.instancehelper_charAt(obj3, obj0.cp + index))
          return false;
      }
      obj0.cp += obj2;
      return true;
    }

    [LineNumberTable(new byte[] {164, 215, 108, 98, 108, 102, 102, 111, 114, 226, 60, 230, 71, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool flatNIMatcher(
      [In] REGlobalData obj0,
      [In] int obj1,
      [In] int obj2,
      [In] string obj3,
      [In] int obj4)
    {
      if (obj0.cp + obj2 > obj4)
        return false;
      char[] source = obj0.regexp.source;
      for (int index = 0; index < obj2; ++index)
      {
        int num1 = (int) source[obj1 + index];
        int num2 = (int) String.instancehelper_charAt(obj3, obj0.cp + index);
        if (num1 != num2 && (int) NativeRegExp.upcase((char) num1) != (int) NativeRegExp.upcase((char) num2))
          return false;
      }
      obj0.cp += obj2;
      return true;
    }

    [LineNumberTable(new byte[] {157, 238, 66, 106, 167, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool classMatcher([In] REGlobalData obj0, [In] RECharSet obj1, [In] char obj2)
    {
      int num = (int) obj2;
      if (!obj1.converted)
        NativeRegExp.processCharSet(obj0, obj1);
      int index = num >> 3;
      return ((obj1.length == 0 || num >= obj1.length || ((int) (sbyte) obj1.bits[index] & 1 << (num & 7)) == 0 ? 1 : 0) ^ (obj1.sense ? 1 : 0)) != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool reopIsSimple([In] int obj0) => obj0 >= 1 && obj0 <= 23;

    [LineNumberTable(new byte[] {157, 233, 131, 194, 135, 159, 74, 98, 133, 104, 127, 1, 165, 98, 133, 106, 126, 165, 98, 133, 127, 19, 114, 133, 127, 19, 114, 133, 127, 4, 98, 211, 127, 4, 98, 211, 127, 4, 98, 211, 127, 4, 98, 211, 127, 4, 98, 211, 127, 4, 98, 211, 127, 4, 98, 211, 105, 102, 139, 133, 106, 102, 106, 102, 142, 133, 109, 127, 1, 98, 243, 69, 106, 102, 106, 102, 142, 133, 109, 109, 110, 118, 98, 142, 197, 107, 102, 127, 1, 98, 243, 69, 107, 102, 109, 110, 118, 98, 142, 226, 70, 106, 102, 106, 118, 37, 135, 110, 98, 226, 71, 139, 99, 99, 103, 131, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int simpleMatch(
      [In] REGlobalData obj0,
      [In] string obj1,
      [In] int obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5,
      [In] bool obj6)
    {
      int num1 = obj6 ? 1 : 0;
      int num2 = 0;
      int cp = obj0.cp;
      switch (obj2)
      {
        case 1:
          num2 = 1;
          break;
        case 2:
          if (obj0.cp == 0 || obj0.multiline && NativeRegExp.isLineTerm(String.instancehelper_charAt(obj1, obj0.cp - 1)))
          {
            num2 = 1;
            break;
          }
          break;
        case 3:
          if (obj0.cp == obj5 || obj0.multiline && NativeRegExp.isLineTerm(String.instancehelper_charAt(obj1, obj0.cp)))
          {
            num2 = 1;
            break;
          }
          break;
        case 4:
          num2 = (obj0.cp == 0 || !NativeRegExp.isWord(String.instancehelper_charAt(obj1, obj0.cp - 1)) ? 1 : 0) ^ (obj0.cp >= obj5 || !NativeRegExp.isWord(String.instancehelper_charAt(obj1, obj0.cp)) ? 1 : 0);
          break;
        case 5:
          num2 = (obj0.cp == 0 || !NativeRegExp.isWord(String.instancehelper_charAt(obj1, obj0.cp - 1)) ? 1 : 0) ^ (obj0.cp >= obj5 || !NativeRegExp.isWord(String.instancehelper_charAt(obj1, obj0.cp)) ? 0 : 1);
          break;
        case 6:
          if (obj0.cp != obj5 && !NativeRegExp.isLineTerm(String.instancehelper_charAt(obj1, obj0.cp)))
          {
            num2 = 1;
            ++obj0.cp;
            break;
          }
          break;
        case 7:
          if (obj0.cp != obj5 && NativeRegExp.isDigit(String.instancehelper_charAt(obj1, obj0.cp)))
          {
            num2 = 1;
            ++obj0.cp;
            break;
          }
          break;
        case 8:
          if (obj0.cp != obj5 && !NativeRegExp.isDigit(String.instancehelper_charAt(obj1, obj0.cp)))
          {
            num2 = 1;
            ++obj0.cp;
            break;
          }
          break;
        case 9:
          if (obj0.cp != obj5 && NativeRegExp.isWord(String.instancehelper_charAt(obj1, obj0.cp)))
          {
            num2 = 1;
            ++obj0.cp;
            break;
          }
          break;
        case 10:
          if (obj0.cp != obj5 && !NativeRegExp.isWord(String.instancehelper_charAt(obj1, obj0.cp)))
          {
            num2 = 1;
            ++obj0.cp;
            break;
          }
          break;
        case 11:
          if (obj0.cp != obj5 && NativeRegExp.isREWhiteSpace((int) String.instancehelper_charAt(obj1, obj0.cp)))
          {
            num2 = 1;
            ++obj0.cp;
            break;
          }
          break;
        case 12:
          if (obj0.cp != obj5 && !NativeRegExp.isREWhiteSpace((int) String.instancehelper_charAt(obj1, obj0.cp)))
          {
            num2 = 1;
            ++obj0.cp;
            break;
          }
          break;
        case 13:
          int index1 = NativeRegExp.getIndex(obj3, obj4);
          obj4 += 2;
          num2 = NativeRegExp.backrefMatcher(obj0, index1, obj1, obj5) ? 1 : 0;
          break;
        case 14:
          int index2 = NativeRegExp.getIndex(obj3, obj4);
          obj4 += 2;
          int index3 = NativeRegExp.getIndex(obj3, obj4);
          obj4 += 2;
          num2 = NativeRegExp.flatNMatcher(obj0, index2, index3, obj1, obj5) ? 1 : 0;
          break;
        case 15:
          byte[] numArray1 = obj3;
          int index4 = obj4;
          ++obj4;
          int num3 = (int) (ushort) numArray1[index4];
          if (obj0.cp != obj5 && (int) String.instancehelper_charAt(obj1, obj0.cp) == num3)
          {
            num2 = 1;
            ++obj0.cp;
            break;
          }
          break;
        case 16:
          int index5 = NativeRegExp.getIndex(obj3, obj4);
          obj4 += 2;
          int index6 = NativeRegExp.getIndex(obj3, obj4);
          obj4 += 2;
          num2 = NativeRegExp.flatNIMatcher(obj0, index5, index6, obj1, obj5) ? 1 : 0;
          break;
        case 17:
          byte[] numArray2 = obj3;
          int index7 = obj4;
          ++obj4;
          int num4 = (int) (ushort) numArray2[index7];
          if (obj0.cp != obj5)
          {
            int num5 = (int) String.instancehelper_charAt(obj1, obj0.cp);
            if (num4 == num5 || (int) NativeRegExp.upcase((char) num4) == (int) NativeRegExp.upcase((char) num5))
            {
              num2 = 1;
              ++obj0.cp;
              break;
            }
            break;
          }
          break;
        case 18:
          int index8 = (int) (ushort) NativeRegExp.getIndex(obj3, obj4);
          obj4 += 2;
          if (obj0.cp != obj5 && (int) String.instancehelper_charAt(obj1, obj0.cp) == index8)
          {
            num2 = 1;
            ++obj0.cp;
            break;
          }
          break;
        case 19:
          int index9 = (int) (ushort) NativeRegExp.getIndex(obj3, obj4);
          obj4 += 2;
          if (obj0.cp != obj5)
          {
            int num5 = (int) String.instancehelper_charAt(obj1, obj0.cp);
            if (index9 == num5 || (int) NativeRegExp.upcase((char) index9) == (int) NativeRegExp.upcase((char) num5))
            {
              num2 = 1;
              ++obj0.cp;
              break;
            }
            break;
          }
          break;
        case 22:
        case 23:
          int index10 = NativeRegExp.getIndex(obj3, obj4);
          obj4 += 2;
          if (obj0.cp != obj5 && NativeRegExp.classMatcher(obj0, obj0.regexp.classList[index10], String.instancehelper_charAt(obj1, obj0.cp)))
          {
            ++obj0.cp;
            num2 = 1;
            break;
          }
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
      if (num2 != 0)
      {
        if (num1 == 0)
          obj0.cp = cp;
        return obj4;
      }
      obj0.cp = cp;
      return -1;
    }

    [LineNumberTable(1152)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getOffset([In] byte[] obj0, [In] int obj1) => NativeRegExp.getIndex(obj0, obj1);

    [LineNumberTable(new byte[] {158, 66, 99, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void pushBackTrackState(
      [In] REGlobalData obj0,
      [In] byte obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5)
    {
      int num = (int) (sbyte) obj1;
      obj0.backTrackStackTop = new REBackTrackData(obj0, num, obj2, obj3, obj4, obj5);
    }

    [LineNumberTable(new byte[] {164, 169, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void pushProgState(
      [In] REGlobalData obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] REBackTrackData obj4,
      [In] int obj5,
      [In] int obj6)
    {
      obj0.stateStackTop = new REProgState(obj0.stateStackTop, obj1, obj2, obj3, obj4, obj5, obj6);
    }

    [LineNumberTable(new byte[] {158, 68, 99, 103, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void pushBackTrackState([In] REGlobalData obj0, [In] byte obj1, [In] int obj2)
    {
      int num = (int) (sbyte) obj1;
      REProgState stateStackTop = obj0.stateStackTop;
      obj0.backTrackStackTop = new REBackTrackData(obj0, num, obj2, obj0.cp, stateStackTop.continuationOp, stateStackTop.continuationPc);
    }

    [LineNumberTable(new byte[] {164, 176, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static REProgState popProgState([In] REGlobalData obj0)
    {
      REProgState stateStackTop = obj0.stateStackTop;
      obj0.stateStackTop = stateStackTop.previous;
      return stateStackTop;
    }

    [LineNumberTable(new byte[] {166, 205, 98, 108, 99, 98, 131, 233, 70, 125, 99, 105, 111, 101, 99, 99, 105, 130, 110, 110, 98, 100, 226, 69, 105, 111, 106, 100, 99, 133, 223, 116, 106, 100, 106, 132, 105, 99, 133, 110, 102, 119, 103, 99, 165, 102, 105, 108, 99, 229, 71, 107, 100, 105, 104, 105, 111, 101, 108, 99, 133, 99, 99, 137, 108, 174, 165, 105, 101, 137, 197, 105, 100, 111, 137, 133, 105, 100, 106, 147, 137, 165, 107, 100, 105, 121, 99, 133, 150, 138, 133, 107, 100, 105, 105, 111, 109, 99, 165, 150, 138, 197, 104, 109, 109, 104, 104, 102, 170, 229, 75, 99, 255, 77, 69, 163, 99, 99, 162, 99, 99, 162, 99, 99, 162, 105, 132, 107, 100, 130, 139, 147, 100, 105, 99, 130, 100, 142, 100, 99, 130, 100, 139, 105, 103, 100, 106, 201, 229, 69, 131, 98, 99, 229, 69, 104, 132, 105, 99, 104, 104, 100, 106, 133, 152, 99, 104, 104, 100, 106, 133, 114, 106, 107, 100, 99, 104, 104, 100, 106, 133, 101, 102, 104, 108, 102, 112, 101, 106, 104, 104, 100, 106, 133, 99, 132, 99, 98, 155, 100, 153, 105, 107, 105, 45, 200, 139, 99, 137, 165, 104, 199, 119, 159, 10, 99, 98, 105, 100, 105, 100, 105, 45, 168, 105, 165, 104, 104, 133, 152, 99, 104, 104, 133, 114, 106, 107, 159, 0, 103, 99, 98, 105, 100, 105, 100, 105, 45, 168, 105, 101, 104, 104, 105, 103, 100, 106, 137, 197, 162, 240, 72, 103, 104, 100, 109, 109, 109, 109, 104, 104, 104, 105, 133, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool executeREBytecode([In] REGlobalData obj0, [In] string obj1, [In] int obj2)
    {
      int num1 = 0;
      byte[] program = obj0.regexp.program;
      int num2 = 57;
      int num3 = 0;
      int num4 = 0;
      byte[] numArray1 = program;
      int index1 = num1;
      int num5 = num1 + 1;
      int num6 = (int) (sbyte) numArray1[index1];
      if (obj0.regexp.anchorCh < 0 && NativeRegExp.reopIsSimple(num6))
      {
        int num7 = 0;
        for (; obj0.cp <= obj2; ++obj0.cp)
        {
          int num8 = NativeRegExp.simpleMatch(obj0, obj1, num6, program, num5, obj2, true);
          if (num8 >= 0)
          {
            num7 = 1;
            int num9 = num8;
            byte[] numArray2 = program;
            int index2 = num9;
            num5 = num9 + 1;
            num6 = (int) (sbyte) numArray2[index2];
            break;
          }
          ++obj0.skipped;
        }
        if (num7 == 0)
          return false;
      }
      while (true)
      {
        while (!NativeRegExp.reopIsSimple(num6))
        {
          switch (num6)
          {
            case 25:
            case 26:
            case 27:
            case 28:
            case 45:
            case 46:
            case 47:
            case 48:
              int num7 = 0;
              int num8;
              int num9;
              switch (num6 - 25)
              {
                case 0:
                case 1:
                case 2:
                case 3:
                  num7 = 1;
                  goto case 20;
                case 20:
                  num8 = 0;
                  num9 = -1;
                  break;
                case 21:
                  num8 = 1;
                  num9 = -1;
                  break;
                case 22:
                  num8 = 0;
                  num9 = 1;
                  break;
                case 23:
                  num8 = NativeRegExp.getOffset(program, num5);
                  int num10 = num5 + 2;
                  num9 = NativeRegExp.getOffset(program, num10) - 1;
                  num5 = num10 + 2;
                  break;
                default:
                  throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
              }
              NativeRegExp.pushProgState(obj0, num8, num9, obj0.cp, (REBackTrackData) null, num2, num3);
              if (num7 != 0)
              {
                NativeRegExp.pushBackTrackState(obj0, (byte) 51, num5);
                num2 = 51;
                num3 = num5;
                int num11 = num5 + 6;
                byte[] numArray2 = program;
                int index2 = num11;
                num5 = num11 + 1;
                num6 = (int) (sbyte) numArray2[index2];
                continue;
              }
              if (num8 != 0)
              {
                num2 = 52;
                num3 = num5;
                int num11 = num5 + 6;
                byte[] numArray2 = program;
                int index2 = num11;
                num5 = num11 + 1;
                num6 = (int) (sbyte) numArray2[index2];
                continue;
              }
              NativeRegExp.pushBackTrackState(obj0, (byte) 52, num5);
              NativeRegExp.popProgState(obj0);
              int num12 = num5 + 4;
              int num13 = num12 + NativeRegExp.getOffset(program, num12);
              byte[] numArray3 = program;
              int index3 = num13;
              num5 = num13 + 1;
              num6 = (int) (sbyte) numArray3[index3];
              continue;
            case 29:
              int index4 = NativeRegExp.getIndex(program, num5);
              int num14 = num5 + 2;
              obj0.setParens(index4, obj0.cp, 0);
              byte[] numArray4 = program;
              int index5 = num14;
              num5 = num14 + 1;
              num6 = (int) (sbyte) numArray4[index5];
              continue;
            case 30:
              int index6 = NativeRegExp.getIndex(program, num5);
              int num15 = num5 + 2;
              int num16 = obj0.parensIndex(index6);
              obj0.setParens(index6, num16, obj0.cp - num16);
              byte[] numArray5 = program;
              int index7 = num15;
              num5 = num15 + 1;
              num6 = (int) (sbyte) numArray5[index7];
              continue;
            case 31:
label_20:
              int num17 = num5 + NativeRegExp.getOffset(program, num5);
              int num18 = num5 + 2;
              byte[] numArray6 = program;
              int index8 = num18;
              num5 = num18 + 1;
              num6 = (int) (sbyte) numArray6[index8];
              int cp1 = obj0.cp;
              if (NativeRegExp.reopIsSimple(num6))
              {
                int num11 = NativeRegExp.simpleMatch(obj0, obj1, num6, program, num5, obj2, true);
                if (num11 < 0)
                {
                  byte[] numArray2 = program;
                  int index2 = num17;
                  int num19 = num17 + 1;
                  num6 = (int) (sbyte) numArray2[index2];
                  num5 = num19;
                  continue;
                }
                num4 = 1;
                int num20 = num11;
                byte[] numArray7 = program;
                int index9 = num20;
                num5 = num20 + 1;
                num6 = (int) (sbyte) numArray7[index9];
              }
              byte[] numArray8 = program;
              int index10 = num17;
              int num21 = num17 + 1;
              int num22 = (int) (sbyte) numArray8[index10];
              NativeRegExp.pushBackTrackState(obj0, (byte) num22, num21, cp1, num2, num3);
              continue;
            case 32:
              int offset = NativeRegExp.getOffset(program, num5);
              int num23 = num5 + offset;
              byte[] numArray9 = program;
              int index11 = num23;
              num5 = num23 + 1;
              num6 = (int) (sbyte) numArray9[index11];
              continue;
            case 41:
              int num24 = num5 + NativeRegExp.getIndex(program, num5);
              int num25 = num5 + 2;
              byte[] numArray10 = program;
              int index12 = num25;
              num5 = num25 + 1;
              num6 = (int) (sbyte) numArray10[index12];
              if (NativeRegExp.reopIsSimple(num6) && NativeRegExp.simpleMatch(obj0, obj1, num6, program, num5, obj2, false) < 0)
              {
                num4 = 0;
                goto label_93;
              }
              else
              {
                NativeRegExp.pushProgState(obj0, 0, 0, obj0.cp, obj0.backTrackStackTop, num2, num3);
                NativeRegExp.pushBackTrackState(obj0, (byte) 43, num24);
                continue;
              }
            case 42:
              int num26 = num5 + NativeRegExp.getIndex(program, num5);
              int num27 = num5 + 2;
              byte[] numArray11 = program;
              int index13 = num27;
              num5 = num27 + 1;
              num6 = (int) (sbyte) numArray11[index13];
              if (NativeRegExp.reopIsSimple(num6))
              {
                int index2 = NativeRegExp.simpleMatch(obj0, obj1, num6, program, num5, obj2, false);
                if (index2 >= 0 && program[index2] == (byte) 44)
                {
                  num4 = 0;
                  goto label_93;
                }
              }
              NativeRegExp.pushProgState(obj0, 0, 0, obj0.cp, obj0.backTrackStackTop, num2, num3);
              NativeRegExp.pushBackTrackState(obj0, (byte) 44, num26);
              continue;
            case 43:
            case 44:
              REProgState reProgState1 = NativeRegExp.popProgState(obj0);
              obj0.cp = reProgState1.index;
              obj0.backTrackStackTop = reProgState1.backTrack;
              num3 = reProgState1.continuationPc;
              num2 = reProgState1.continuationOp;
              if (num6 == 44)
              {
                num4 = num4 != 0 ? 0 : 1;
                goto label_93;
              }
              else
                goto label_93;
            case 49:
              num4 = 1;
              num5 = num3;
              num6 = num2;
              continue;
            case 51:
              int index14;
              do
              {
                REProgState reProgState2 = NativeRegExp.popProgState(obj0);
                if (num4 == 0)
                {
                  if (reProgState2.min == 0)
                    num4 = 1;
                  num3 = reProgState2.continuationPc;
                  num2 = reProgState2.continuationOp;
                  int num11 = num5 + 4;
                  num5 = num11 + NativeRegExp.getOffset(program, num11);
                  goto label_93;
                }
                else if (reProgState2.min == 0 && obj0.cp == reProgState2.index)
                {
                  num4 = 0;
                  num3 = reProgState2.continuationPc;
                  num2 = reProgState2.continuationOp;
                  int num11 = num5 + 4;
                  num5 = num11 + NativeRegExp.getOffset(program, num11);
                  goto label_93;
                }
                else
                {
                  int min = reProgState2.min;
                  int max = reProgState2.max;
                  if (min != 0)
                    min += -1;
                  if (max != -1)
                    max += -1;
                  if (max == 0)
                  {
                    num4 = 1;
                    num3 = reProgState2.continuationPc;
                    num2 = reProgState2.continuationOp;
                    int num11 = num5 + 4;
                    num5 = num11 + NativeRegExp.getOffset(program, num11);
                    goto label_93;
                  }
                  else
                  {
                    index14 = num5 + 6;
                    int num11 = (int) (sbyte) program[index14];
                    int cp2 = obj0.cp;
                    if (NativeRegExp.reopIsSimple(num11))
                    {
                      int num19 = index14 + 1;
                      int num20 = NativeRegExp.simpleMatch(obj0, obj1, num11, program, num19, obj2, true);
                      if (num20 < 0)
                      {
                        num4 = min != 0 ? 0 : 1;
                        num3 = reProgState2.continuationPc;
                        num2 = reProgState2.continuationOp;
                        int num28 = num5 + 4;
                        num5 = num28 + NativeRegExp.getOffset(program, num28);
                        goto label_93;
                      }
                      else
                      {
                        num4 = 1;
                        index14 = num20;
                      }
                    }
                    num2 = 51;
                    num3 = num5;
                    NativeRegExp.pushProgState(obj0, min, max, cp2, (REBackTrackData) null, reProgState2.continuationOp, reProgState2.continuationPc);
                    if (min == 0)
                    {
                      NativeRegExp.pushBackTrackState(obj0, (byte) 51, num5, cp2, reProgState2.continuationOp, reProgState2.continuationPc);
                      int index2 = NativeRegExp.getIndex(program, num5);
                      int index9 = NativeRegExp.getIndex(program, num5 + 2);
                      for (int index15 = 0; index15 < index2; ++index15)
                        obj0.setParens(index9 + index15, -1, 0);
                    }
                  }
                }
              }
              while (program[index14] == (byte) 49);
              int num29 = index14;
              byte[] numArray12 = program;
              int index16 = num29;
              num5 = num29 + 1;
              num6 = (int) (sbyte) numArray12[index16];
              continue;
            case 52:
              REProgState reProgState3 = NativeRegExp.popProgState(obj0);
              if (num4 == 0)
              {
                if (reProgState3.max == -1 || reProgState3.max > 0)
                {
                  NativeRegExp.pushProgState(obj0, reProgState3.min, reProgState3.max, obj0.cp, (REBackTrackData) null, reProgState3.continuationOp, reProgState3.continuationPc);
                  num2 = 52;
                  num3 = num5;
                  int index2 = NativeRegExp.getIndex(program, num5);
                  int num11 = num5 + 2;
                  int index9 = NativeRegExp.getIndex(program, num11);
                  int num19 = num11 + 4;
                  for (int index15 = 0; index15 < index2; ++index15)
                    obj0.setParens(index9 + index15, -1, 0);
                  byte[] numArray2 = program;
                  int index17 = num19;
                  num5 = num19 + 1;
                  num6 = (int) (sbyte) numArray2[index17];
                  continue;
                }
                num3 = reProgState3.continuationPc;
                num2 = reProgState3.continuationOp;
                goto label_93;
              }
              else if (reProgState3.min == 0 && obj0.cp == reProgState3.index)
              {
                num4 = 0;
                num3 = reProgState3.continuationPc;
                num2 = reProgState3.continuationOp;
                goto label_93;
              }
              else
              {
                int min = reProgState3.min;
                int max = reProgState3.max;
                if (min != 0)
                  min += -1;
                if (max != -1)
                  max += -1;
                NativeRegExp.pushProgState(obj0, min, max, obj0.cp, (REBackTrackData) null, reProgState3.continuationOp, reProgState3.continuationPc);
                if (min != 0)
                {
                  num2 = 52;
                  num3 = num5;
                  int index2 = NativeRegExp.getIndex(program, num5);
                  int num11 = num5 + 2;
                  int index9 = NativeRegExp.getIndex(program, num11);
                  int num19 = num11 + 4;
                  for (int index15 = 0; index15 < index2; ++index15)
                    obj0.setParens(index9 + index15, -1, 0);
                  byte[] numArray2 = program;
                  int index17 = num19;
                  num5 = num19 + 1;
                  num6 = (int) (sbyte) numArray2[index17];
                  continue;
                }
                num3 = reProgState3.continuationPc;
                num2 = reProgState3.continuationOp;
                NativeRegExp.pushBackTrackState(obj0, (byte) 52, num5);
                NativeRegExp.popProgState(obj0);
                int num20 = num5 + 4;
                int num28 = num20 + NativeRegExp.getOffset(program, num20);
                byte[] numArray7 = program;
                int index18 = num28;
                num5 = num28 + 1;
                num6 = (int) (sbyte) numArray7[index18];
                continue;
              }
            case 53:
            case 54:
            case 55:
              int index19 = (int) (ushort) NativeRegExp.getIndex(program, num5);
              int num30 = num5 + 2;
              int index20 = (int) (ushort) NativeRegExp.getIndex(program, num30);
              num5 = num30 + 2;
              if (obj0.cp == obj2)
              {
                num4 = 0;
                goto label_93;
              }
              else
              {
                int num11 = (int) String.instancehelper_charAt(obj1, obj0.cp);
                switch (num6)
                {
                  case 54:
                    num11 = (int) NativeRegExp.upcase((char) num11);
                    break;
                  case 55:
                    if (num11 != index19 && !NativeRegExp.classMatcher(obj0, obj0.regexp.classList[index20], (char) num11))
                    {
                      num4 = 0;
                      goto label_93;
                    }
                    else
                      goto label_20;
                }
                if (num11 != index19 && num11 != index20)
                {
                  num4 = 0;
                  goto label_93;
                }
                else
                  goto case 31;
              }
            case 57:
              return true;
            default:
              throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug("invalid bytecode"));
          }
        }
        int num31 = NativeRegExp.simpleMatch(obj0, obj1, num6, program, num5, obj2, true);
        num4 = num31 >= 0 ? 1 : 0;
        if (num4 != 0)
          num5 = num31;
label_93:
        if (num4 == 0)
        {
          REBackTrackData backTrackStackTop = obj0.backTrackStackTop;
          if (backTrackStackTop != null)
          {
            obj0.backTrackStackTop = backTrackStackTop.previous;
            obj0.parens = backTrackStackTop.parens;
            obj0.cp = backTrackStackTop.cp;
            obj0.stateStackTop = backTrackStackTop.stateStackTop;
            num2 = backTrackStackTop.continuationOp;
            num3 = backTrackStackTop.continuationPc;
            num5 = backTrackStackTop.pc;
            num6 = backTrackStackTop.op;
          }
          else
            break;
        }
        else
        {
          byte[] numArray2 = program;
          int index2 = num5;
          ++num5;
          num6 = (int) (sbyte) numArray2[index2];
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {157, 89, 67, 104, 147, 167, 103, 135, 119, 135, 236, 69, 234, 70, 132, 101, 130, 104, 148, 110, 130, 100, 130, 103, 105, 107, 42, 166, 138, 103, 103, 99, 130, 109, 104, 130, 233, 28, 233, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool matchRegExp(
      [In] REGlobalData obj0,
      [In] RECompiled obj1,
      [In] string obj2,
      [In] int obj3,
      [In] int obj4,
      [In] bool obj5)
    {
      int num1 = obj5 ? 1 : 0;
      obj0.parens = obj1.parenCount == 0 ? (long[]) null : new long[obj1.parenCount];
      obj0.backTrackStackTop = (REBackTrackData) null;
      obj0.stateStackTop = (REProgState) null;
      obj0.multiline = num1 != 0 || (obj1.flags & 4) != 0;
      obj0.regexp = obj1;
      int anchorCh = obj0.regexp.anchorCh;
      for (int index1 = obj3; index1 <= obj4; index1 = obj3 + obj0.skipped + 1)
      {
        if (anchorCh >= 0)
        {
          for (; index1 != obj4; ++index1)
          {
            int num2 = (int) String.instancehelper_charAt(obj2, index1);
            if (num2 == anchorCh || (obj0.regexp.flags & 2) != 0 && (int) NativeRegExp.upcase((char) num2) == (int) NativeRegExp.upcase((char) anchorCh))
              goto label_7;
          }
          return false;
        }
label_7:
        obj0.cp = index1;
        obj0.skipped = index1 - obj3;
        for (int index2 = 0; index2 < obj1.parenCount; ++index2)
          obj0.parens[index2] = -1L;
        int num3 = NativeRegExp.executeREBytecode(obj0, obj2, obj4) ? 1 : 0;
        obj0.backTrackStackTop = (REBackTrackData) null;
        obj0.stateStackTop = (REProgState) null;
        if (num3 != 0)
          return true;
        if (anchorCh == -2 && !obj0.multiline)
        {
          obj0.skipped = obj4;
          return false;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {169, 235, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeRegExp realThis([In] Scriptable obj0, [In] IdFunctionObject obj1) => obj0 is NativeRegExp ? (NativeRegExp) obj0 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));

    [LineNumberTable(new byte[] {106, 111, 148, 144, 105, 108, 108, 130, 126, 119, 137, 111, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Scriptable compile([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      if (obj2.Length > 0 && obj2[0] is NativeRegExp)
      {
        if (obj2.Length > 1 && !object.ReferenceEquals(obj2[1], Undefined.__\u003C\u003Einstance))
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.bad.regexp.compile"));
        NativeRegExp nativeRegExp = (NativeRegExp) obj2[0];
        this.re = nativeRegExp.re;
        this.lastIndex = nativeRegExp.lastIndex;
        return (Scriptable) this;
      }
      string str1 = obj2.Length == 0 || obj2[0] is Undefined ? "" : NativeRegExp.escapeRegExp(obj2[0]);
      string str2 = obj2.Length <= 1 || object.ReferenceEquals(obj2[1], Undefined.__\u003C\u003Einstance) ? (string) null : ScriptRuntime.toString(obj2[1]);
      this.re = NativeRegExp.compileRE(obj0, str1, str2, false);
      this.lastIndex = (object) Double.valueOf(0.0);
      return (Scriptable) this;
    }

    [LineNumberTable(new byte[] {127, 102, 105, 110, 180, 140, 105, 111, 105, 111, 105, 111, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append('/');
      if (this.re.source.Length != 0)
        stringBuilder.append(this.re.source);
      else
        stringBuilder.append("(?:)");
      stringBuilder.append('/');
      if ((this.re.flags & 1) != 0)
        stringBuilder.append('g');
      if ((this.re.flags & 2) != 0)
        stringBuilder.append('i');
      if ((this.re.flags & 4) != 0)
        stringBuilder.append('m');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {159, 119, 98, 102, 115, 103, 103, 140, 166, 141, 135, 135, 99, 102, 166, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      NativeRegExp nativeRegExp = new NativeRegExp();
      nativeRegExp.re = NativeRegExp.compileRE(cx, "", (string) null, false);
      nativeRegExp.activatePrototypeMap(6);
      nativeRegExp.setParentScope(scope);
      nativeRegExp.setPrototype(ScriptableObject.getObjectPrototype(scope));
      NativeRegExpCtor nativeRegExpCtor = new NativeRegExpCtor();
      nativeRegExp.defineProperty("constructor", (object) nativeRegExpCtor, 2);
      ScriptRuntime.setFunctionProtoAndParent((BaseFunction) nativeRegExpCtor, scope);
      nativeRegExpCtor.setImmunePrototypeProperty((object) nativeRegExp);
      if (num != 0)
      {
        nativeRegExp.sealObject();
        nativeRegExpCtor.sealObject();
      }
      ScriptableObject.defineProperty(scope, "RegExp", (object) nativeRegExpCtor, 2);
    }

    [LineNumberTable(new byte[] {66, 232, 170, 42, 112, 231, 149, 214, 103, 112, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeRegExp([In] Scriptable obj0, [In] RECompiled obj1)
    {
      NativeRegExp nativeRegExp = this;
      this.lastIndex = (object) Double.valueOf(0.0);
      this.lastIndexAttr = 6;
      this.re = obj1;
      this.lastIndex = (object) Double.valueOf(0.0);
      ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) this, obj0, TopLevel.Builtins.__\u003C\u003ERegExp);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "RegExp";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getTypeOf() => "object";

    [LineNumberTable(new byte[] {89, 109, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args)
    {
      if (cx.getLanguageVersion() < 200)
        return this.execSub(cx, scope, args, 1);
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError((object) thisObj));
    }

    [LineNumberTable(new byte[] {98, 109, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable construct(Context cx, Scriptable scope, object[] args)
    {
      if (cx.getLanguageVersion() < 200)
        return (Scriptable) this.execSub(cx, scope, args, 1);
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError((object) this));
    }

    [LineNumberTable(2442)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getFlags() => this.re.flags;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getMaxInstanceId() => 5;

    [LineNumberTable(new byte[] {169, 61, 98, 130, 103, 100, 104, 101, 102, 103, 104, 102, 132, 101, 104, 101, 102, 100, 101, 102, 132, 101, 102, 130, 247, 69, 171, 158, 104, 226, 69, 99, 130, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo(string s)
    {
      int id = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 6:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'g':
              str = "global";
              id = 3;
              break;
            case 's':
              str = "source";
              id = 2;
              break;
          }
          break;
        case 9:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'l':
              str = "lastIndex";
              id = 1;
              break;
            case 'm':
              str = "multiline";
              id = 5;
              break;
          }
          break;
        case 10:
          str = "ignoreCase";
          id = 4;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        id = 0;
      int attributes;
      switch (id)
      {
        case 0:
          return base.findInstanceIdInfo(s);
        case 1:
          attributes = this.lastIndexAttr;
          break;
        case 2:
        case 3:
        case 4:
        case 5:
          attributes = 7;
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
      }
      return IdScriptableObject.instanceIdInfo(attributes, id);
    }

    [LineNumberTable(new byte[] {169, 113, 158, 134, 134, 134, 134, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getInstanceIdName(int id)
    {
      switch (id)
      {
        case 1:
          return "lastIndex";
        case 2:
          return "source";
        case 3:
          return "global";
        case 4:
          return "ignoreCase";
        case 5:
          return "multiline";
        default:
          return base.getInstanceIdName(id);
      }
    }

    [LineNumberTable(new byte[] {169, 130, 158, 135, 145, 153, 153, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue(int id)
    {
      switch (id)
      {
        case 1:
          return this.lastIndex;
        case 2:
          return (object) String.newhelper(this.re.source);
        case 3:
          return (object) ScriptRuntime.wrapBoolean((this.re.flags & 1) != 0);
        case 4:
          return (object) ScriptRuntime.wrapBoolean((this.re.flags & 2) != 0);
        case 5:
          return (object) ScriptRuntime.wrapBoolean((this.re.flags & 4) != 0);
        default:
          return base.getInstanceIdValue(id);
      }
    }

    [LineNumberTable(new byte[] {169, 147, 158, 103, 225, 69, 129, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdValue(int id, object value)
    {
      switch (id)
      {
        case 1:
          this.lastIndex = value;
          break;
        case 2:
          break;
        case 3:
          break;
        case 4:
          break;
        case 5:
          break;
        default:
          base.setInstanceIdValue(id, value);
          break;
      }
    }

    [LineNumberTable(new byte[] {169, 162, 139, 103, 129, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdAttributes(int id, int attr)
    {
      if (id == 1)
        this.lastIndexAttr = attr;
      else
        base.setInstanceIdAttributes(id, attr);
    }

    [LineNumberTable(new byte[] {169, 174, 159, 3, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 2;
          name = "compile";
          break;
        case 2:
          arity = 0;
          name = "toString";
          break;
        case 3:
          arity = 0;
          name = "toSource";
          break;
        case 4:
          arity = 1;
          name = "exec";
          break;
        case 5:
          arity = 1;
          name = "test";
          break;
        case 6:
          arity = 1;
          name = "prefix";
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(NativeRegExp.REGEXP_TAG, id, name, arity);
    }

    [LineNumberTable(new byte[] {169, 208, 109, 142, 103, 159, 6, 210, 174, 179, 115, 218, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeRegExp.REGEXP_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      switch (num)
      {
        case 1:
          return (object) NativeRegExp.realThis(thisObj, f).compile(cx, scope, args);
        case 2:
        case 3:
          return (object) NativeRegExp.realThis(thisObj, f).toString();
        case 4:
          return NativeRegExp.realThis(thisObj, f).execSub(cx, scope, args, 1);
        case 5:
          object obj = NativeRegExp.realThis(thisObj, f).execSub(cx, scope, args, 0);
          return ((Boolean) Boolean.TRUE).equals(obj) ? (object) Boolean.TRUE : (object) Boolean.FALSE;
        case 6:
          return NativeRegExp.realThis(thisObj, f).execSub(cx, scope, args, 2);
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {169, 247, 98, 162, 159, 7, 104, 101, 102, 103, 101, 102, 196, 102, 98, 130, 102, 98, 130, 104, 101, 102, 100, 101, 102, 194, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 4:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'e':
              str = "exec";
              num = 4;
              break;
            case 't':
              str = "test";
              num = 5;
              break;
          }
          break;
        case 6:
          str = "prefix";
          num = 6;
          break;
        case 7:
          str = "compile";
          num = 1;
          break;
        case 8:
          switch (String.instancehelper_charAt(s, 3))
          {
            case 'o':
              str = "toSource";
              num = 3;
              break;
            case 't':
              str = "toString";
              num = 2;
              break;
          }
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [LineNumberTable(new byte[] {159, 138, 178, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeRegExp()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.regexp.NativeRegExp"))
        return;
      NativeRegExp.\u0024assertionsDisabled = !((Class) ClassLiteral<NativeRegExp>.Value).desiredAssertionStatus();
      NativeRegExp.REGEXP_TAG = (object) new Object();
    }
  }
}
