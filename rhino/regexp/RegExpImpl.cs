// Decompiled with JetBrains decompiler
// Type: rhino.regexp.RegExpImpl
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.regexp
{
  public class RegExpImpl : Object, RegExpProxy
  {
    protected internal string input;
    protected internal bool multiline;
    protected internal SubString[] parens;
    protected internal SubString lastMatch;
    protected internal SubString lastParen;
    protected internal SubString leftContext;
    protected internal SubString rightContext;

    [LineNumberTable(new byte[] {160, 165, 114, 105, 99, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual SubString getParenSubString([In] int obj0)
    {
      if (this.parens != null && obj0 < this.parens.Length)
      {
        SubString paren = this.parens[obj0];
        if (paren != null)
          return paren;
      }
      return new SubString();
    }

    [LineNumberTable(new byte[] {159, 110, 163, 103, 115, 114, 104, 108, 139, 138, 101, 101, 140, 131, 109, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeRegExp createRegExp(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] object[] obj2,
      [In] int obj3,
      [In] bool obj4)
    {
      int num = obj4 ? 1 : 0;
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(obj1);
      NativeRegExp nativeRegExp;
      if (obj2.Length == 0 || object.ReferenceEquals(obj2[0], Undefined.__\u003C\u003Einstance))
      {
        RECompiled reCompiled = NativeRegExp.compileRE(obj0, "", "", false);
        nativeRegExp = new NativeRegExp(topLevelScope, reCompiled);
      }
      else if (obj2[0] is NativeRegExp)
      {
        nativeRegExp = (NativeRegExp) obj2[0];
      }
      else
      {
        string str1 = ScriptRuntime.toString(obj2[0]);
        string str2;
        if (obj3 < obj2.Length)
        {
          obj2[0] = (object) str1;
          str2 = ScriptRuntime.toString(obj2[obj3]);
        }
        else
          str2 = (string) null;
        RECompiled reCompiled = NativeRegExp.compileRE(obj0, str1, str2, num != 0);
        nativeRegExp = new NativeRegExp(topLevelScope, reCompiled);
      }
      return nativeRegExp;
    }

    [LineNumberTable(new byte[] {109, 104, 118, 107, 98, 106, 143, 112, 151, 108, 108, 113, 112, 143, 115, 101, 106, 142, 112, 105, 105, 108, 118, 143, 110, 107, 98, 242, 46, 235, 86, 252, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object matchOrReplace(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3,
      [In] RegExpImpl obj4,
      [In] GlobData obj5,
      [In] NativeRegExp obj6)
    {
      string str = obj5.str;
      obj5.global = (obj6.getFlags() & 1) != 0;
      int[] numArray1 = new int[1]{ 0 };
      object obj7 = (object) null;
      if (obj5.mode == 3)
      {
        object obj8 = obj6.executeRegExp(obj0, obj1, obj4, str, numArray1, 0);
        obj7 = obj8 == null || !Object.instancehelper_equals(obj8, (object) Boolean.TRUE) ? (object) Integer.valueOf(-1) : (object) Integer.valueOf(obj4.leftContext.length);
      }
      else if (obj5.global)
      {
        obj6.lastIndex = (object) Double.valueOf(0.0);
        int num1 = 0;
        while (numArray1[0] <= String.instancehelper_length(str))
        {
          obj7 = obj6.executeRegExp(obj0, obj1, obj4, str, numArray1, 0);
          if (obj7 != null && Object.instancehelper_equals(obj7, (object) Boolean.TRUE))
          {
            if (obj5.mode == 1)
            {
              RegExpImpl.match_glob(obj5, obj0, obj1, num1, obj4);
            }
            else
            {
              if (obj5.mode != 2)
                Kit.codeBug();
              SubString lastMatch = obj4.lastMatch;
              int leftIndex = obj5.leftIndex;
              int num2 = lastMatch.index - leftIndex;
              obj5.leftIndex = lastMatch.index + lastMatch.length;
              RegExpImpl.replace_glob(obj5, obj0, obj1, obj4, leftIndex, num2);
            }
            if (obj4.lastMatch.length == 0)
            {
              if (numArray1[0] != String.instancehelper_length(str))
              {
                int[] numArray2 = numArray1;
                int index = 0;
                int[] numArray3 = numArray2;
                numArray3[index] = numArray3[index] + 1;
              }
              else
                break;
            }
            ++num1;
          }
          else
            break;
        }
      }
      else
        obj7 = obj6.executeRegExp(obj0, obj1, obj4, str, numArray1, obj5.mode != 2 ? 1 : 0);
      return obj7;
    }

    [LineNumberTable(new byte[] {160, 196, 171, 103, 105, 105, 110, 102, 101, 100, 142, 234, 59, 230, 72, 117, 235, 69, 116, 103, 109, 109, 136, 104, 115, 141, 103, 35, 98, 98, 105, 101, 99, 109, 108, 104, 135, 146, 100, 113, 137, 132, 111, 196, 115, 104, 100, 105, 138, 181, 127, 21, 104, 140, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void replace_glob(
      [In] GlobData obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] RegExpImpl obj3,
      [In] int obj4,
      [In] int obj5)
    {
      string str1;
      int num1;
      if (obj0.lambda != null)
      {
        SubString[] parens = obj3.parens;
        int num2 = parens != null ? parens.Length : 0;
        object[] objarr = new object[num2 + 3];
        objarr[0] = (object) obj3.lastMatch.toString();
        for (int index = 0; index < num2; ++index)
        {
          SubString subString = parens[index];
          objarr[index + 1] = subString == null ? Undefined.__\u003C\u003Einstance : (object) subString.toString();
        }
        objarr[num2 + 1] = (object) Integer.valueOf(obj3.leftContext.length);
        objarr[num2 + 2] = (object) obj0.str;
        if (!object.ReferenceEquals((object) obj3, (object) ScriptRuntime.getRegExpProxy(obj1)))
          Kit.codeBug();
        ScriptRuntime.setRegExpProxy(obj1, (RegExpProxy) new RegExpImpl()
        {
          multiline = obj3.multiline,
          input = obj3.input
        });
        try
        {
          Scriptable topLevelScope = ScriptableObject.getTopLevelScope(obj2);
          str1 = ScriptRuntime.toString(obj0.lambda.call(obj1, topLevelScope, topLevelScope, objarr));
        }
        finally
        {
          ScriptRuntime.setRegExpProxy(obj1, (RegExpProxy) obj3);
        }
        num1 = String.instancehelper_length(str1);
      }
      else
      {
        str1 = (string) null;
        num1 = String.instancehelper_length(obj0.repstr);
        if (obj0.dollar >= 0)
        {
          int[] numArray = new int[1];
          int num2 = obj0.dollar;
          do
          {
            SubString subString = RegExpImpl.interpretDollar(obj1, obj3, obj0.repstr, num2, numArray);
            int num3;
            if (subString != null)
            {
              num1 += subString.length - numArray[0];
              num3 = num2 + numArray[0];
            }
            else
              num3 = num2 + 1;
            num2 = String.instancehelper_indexOf(obj0.repstr, 36, num3);
          }
          while (num2 >= 0);
        }
      }
      int num4 = obj5 + num1 + obj3.rightContext.length;
      StringBuilder stringBuilder1 = obj0.charBuf;
      if (stringBuilder1 == null)
      {
        stringBuilder1 = new StringBuilder(num4);
        obj0.charBuf = stringBuilder1;
      }
      else
        stringBuilder1.ensureCapacity(obj0.charBuf.length() + num4);
      StringBuilder stringBuilder2 = stringBuilder1;
      string str2 = obj3.leftContext.str;
      int num5 = obj4;
      int num6 = obj4 + obj5;
      int num7 = num5;
      object obj = (object) str2;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      int num8 = num7;
      int num9 = num6;
      stringBuilder2.append(charSequence2, num8, num9);
      if (obj0.lambda != null)
        stringBuilder1.append(str1);
      else
        RegExpImpl.do_replace(obj0, obj1, obj3);
    }

    [LineNumberTable(new byte[] {160, 180, 104, 142, 104, 103, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void match_glob(
      [In] GlobData obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] int obj3,
      [In] RegExpImpl obj4)
    {
      if (obj0.arrayobj == null)
        obj0.arrayobj = obj1.newArray(obj2, 0);
      string str = obj4.lastMatch.toString();
      obj0.arrayobj.put(obj3, obj0.arrayobj, (object) str);
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RegExpImpl()
    {
    }

    [LineNumberTable(new byte[] {161, 16, 177, 103, 144, 113, 130, 103, 102, 130, 106, 139, 147, 101, 130, 98, 99, 127, 3, 107, 101, 101, 165, 116, 101, 101, 98, 101, 102, 106, 104, 107, 102, 102, 195, 165, 100, 104, 168, 101, 159, 13, 139, 135, 135, 229, 72, 108, 150, 135, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static SubString interpretDollar(
      [In] Context obj0,
      [In] RegExpImpl obj1,
      [In] string obj2,
      [In] int obj3,
      [In] int[] obj4)
    {
      if (String.instancehelper_charAt(obj2, obj3) != '$')
        Kit.codeBug();
      int languageVersion = obj0.getLanguageVersion();
      if (languageVersion != 200 && languageVersion <= 140 && (obj3 > 0 && String.instancehelper_charAt(obj2, obj3 - 1) == '\\'))
        return (SubString) null;
      int num1 = String.instancehelper_length(obj2);
      if (obj3 + 1 >= num1)
        return (SubString) null;
      int num2 = (int) String.instancehelper_charAt(obj2, obj3 + 1);
      if (NativeRegExp.isDigit((char) num2))
      {
        int num3;
        int num4;
        if (languageVersion != 200 && languageVersion <= 140)
        {
          if (num2 == 48)
            return (SubString) null;
          num3 = 0;
          num4 = obj3;
          while (true)
          {
            ++num4;
            int num5;
            if (num4 < num1 && NativeRegExp.isDigit((char) (num5 = (int) String.instancehelper_charAt(obj2, num4))))
            {
              int num6 = 10 * num3 + (num5 - 48);
              if (num6 >= num3)
                num3 = num6;
              else
                break;
            }
            else
              break;
          }
        }
        else
        {
          int num5 = obj1.parens != null ? obj1.parens.Length : 0;
          num3 = num2 - 48;
          if (num3 > num5)
            return (SubString) null;
          num4 = obj3 + 2;
          if (obj3 + 2 < num1)
          {
            int num6 = (int) String.instancehelper_charAt(obj2, obj3 + 2);
            if (NativeRegExp.isDigit((char) num6))
            {
              int num7 = 10 * num3 + (num6 - 48);
              if (num7 <= num5)
              {
                ++num4;
                num3 = num7;
              }
            }
          }
          if (num3 == 0)
            return (SubString) null;
        }
        int num8 = num3 - 1;
        obj4[0] = num4 - obj3;
        return obj1.getParenSubString(num8);
      }
      obj4[0] = 2;
      switch (num2)
      {
        case 36:
          return new SubString("$");
        case 38:
          return obj1.lastMatch;
        case 39:
          return obj1.rightContext;
        case 43:
          return obj1.lastParen;
        case 96:
          if (languageVersion == 120)
          {
            obj1.leftContext.index = 0;
            obj1.leftContext.length = obj1.lastMatch.index;
          }
          return obj1.leftContext;
        default:
          return (SubString) null;
      }
    }

    [LineNumberTable(new byte[] {161, 101, 103, 98, 103, 103, 103, 168, 127, 5, 98, 141, 103, 105, 101, 159, 26, 103, 137, 132, 106, 135, 104, 101, 159, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void do_replace([In] GlobData obj0, [In] Context obj1, [In] RegExpImpl obj2)
    {
      StringBuilder charBuf = obj0.charBuf;
      int num1 = 0;
      string repstr = obj0.repstr;
      int num2 = obj0.dollar;
      CharSequence charSequence1;
      if (num2 != -1)
      {
        int[] numArray = new int[1];
        do
        {
          StringBuilder stringBuilder1 = charBuf;
          string str1 = repstr;
          int num3 = num1;
          int num4 = num2;
          int num5 = num3;
          object obj3 = (object) str1;
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence2 = charSequence1;
          int num6 = num5;
          int num7 = num4;
          stringBuilder1.append(charSequence2, num6, num7);
          num1 = num2;
          SubString subString = RegExpImpl.interpretDollar(obj1, obj2, repstr, num2, numArray);
          int num8;
          if (subString != null)
          {
            int length = subString.length;
            if (length > 0)
            {
              StringBuilder stringBuilder2 = charBuf;
              string str2 = subString.str;
              int index = subString.index;
              int num9 = subString.index + length;
              int num10 = index;
              object obj4 = (object) str2;
              charSequence1.__\u003Cref\u003E = (__Null) obj4;
              CharSequence charSequence3 = charSequence1;
              int num11 = num10;
              int num12 = num9;
              stringBuilder2.append(charSequence3, num11, num12);
            }
            num1 += numArray[0];
            num8 = num2 + numArray[0];
          }
          else
            num8 = num2 + 1;
          num2 = String.instancehelper_indexOf(repstr, 36, num8);
        }
        while (num2 >= 0);
      }
      int num13 = String.instancehelper_length(repstr);
      if (num13 <= num1)
        return;
      StringBuilder stringBuilder = charBuf;
      string str = repstr;
      int num14 = num1;
      int num15 = num13;
      int num16 = num14;
      object obj = (object) str;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence4 = charSequence1;
      int num17 = num16;
      int num18 = num15;
      stringBuilder.append(charSequence4, num17, num18);
    }

    [LineNumberTable(new byte[] {161, 249, 101, 231, 71, 113, 153, 99, 114, 102, 197, 100, 162, 102, 108, 166, 98, 114, 166, 103, 226, 77, 100, 226, 71, 100, 246, 73, 149, 226, 76, 104, 102, 100, 101, 130, 132, 235, 70, 103, 130, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int find_split(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] string obj2,
      [In] string obj3,
      [In] int obj4,
      [In] RegExpProxy obj5,
      [In] Scriptable obj6,
      [In] int[] obj7,
      [In] int[] obj8,
      [In] bool[] obj9,
      [In] string[][] obj10)
    {
      int num1 = obj7[0];
      int num2 = String.instancehelper_length(obj2);
      if (obj4 == 120 && obj6 == null && (String.instancehelper_length(obj3) == 1 && String.instancehelper_charAt(obj3, 0) == ' '))
      {
        if (num1 == 0)
        {
          while (num1 < num2 && Character.isWhitespace(String.instancehelper_charAt(obj2, num1)))
            ++num1;
          obj7[0] = num1;
        }
        if (num1 == num2)
          return -1;
        while (num1 < num2 && !Character.isWhitespace(String.instancehelper_charAt(obj2, num1)))
          ++num1;
        int num3 = num1;
        while (num3 < num2 && Character.isWhitespace(String.instancehelper_charAt(obj2, num3)))
          ++num3;
        obj8[0] = num3 - num1;
        return num1;
      }
      if (num1 > num2)
        return -1;
      if (obj6 != null)
        return obj5.find_split(obj0, obj1, obj2, obj3, obj6, obj7, obj8, obj9, obj10);
      if (obj4 != 200 && obj4 < 130 && num2 == 0)
        return -1;
      if (String.instancehelper_length(obj3) == 0)
      {
        if (obj4 == 120)
        {
          if (num1 != num2)
            return num1 + 1;
          obj8[0] = 1;
          return num1;
        }
        return num1 == num2 ? -1 : num1 + 1;
      }
      if (obj7[0] >= num2)
        return num2;
      int num4 = String.instancehelper_indexOf(obj2, obj3, obj7[0]);
      return num4 != -1 ? num4 : num2;
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRegExp(Scriptable obj) => obj is NativeRegExp;

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object compileRegExp(Context cx, string source, string flags) => (object) NativeRegExp.compileRE(cx, source, flags, false);

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable wrapRegExp(Context cx, Scriptable scope, object compiled)
    {
      NativeRegExp.__\u003Cclinit\u003E();
      return (Scriptable) new NativeRegExp(scope, (RECompiled) compiled);
    }

    [LineNumberTable(new byte[] {159, 172, 102, 104, 140, 154, 102, 109, 162, 108, 110, 210, 102, 109, 162, 108, 206, 182, 109, 169, 98, 99, 99, 142, 115, 169, 115, 99, 99, 105, 139, 169, 104, 104, 118, 103, 167, 99, 180, 104, 107, 104, 105, 103, 103, 112, 113, 127, 0, 103, 98, 199, 104, 115, 135, 135, 104, 151, 104, 127, 36, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object action(
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args,
      int actionType)
    {
      GlobData globData = new GlobData();
      globData.mode = actionType;
      globData.str = ScriptRuntime.toString((object) thisObj);
      switch (actionType)
      {
        case 1:
          int num1 = int.MaxValue;
          if (cx.getLanguageVersion() < 160)
            num1 = 1;
          NativeRegExp regExp1 = RegExpImpl.createRegExp(cx, scope, args, num1, false);
          object obj1 = RegExpImpl.matchOrReplace(cx, scope, thisObj, args, this, globData, regExp1);
          return globData.arrayobj == null ? obj1 : (object) globData.arrayobj;
        case 2:
          int num2 = args.Length <= 0 || !(args[0] is NativeRegExp) ? 0 : 1;
          if (cx.getLanguageVersion() < 160)
            num2 |= args.Length > 2 ? 1 : 0;
          NativeRegExp nativeRegExp = (NativeRegExp) null;
          string str1 = (string) null;
          if (num2 != 0)
            nativeRegExp = RegExpImpl.createRegExp(cx, scope, args, 2, true);
          else
            str1 = ScriptRuntime.toString(args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance);
          object val = args.Length >= 2 ? args[1] : Undefined.__\u003C\u003Einstance;
          string str2 = (string) null;
          Function function = (Function) null;
          if (val is Function)
            function = (Function) val;
          else
            str2 = ScriptRuntime.toString(val);
          globData.lambda = function;
          globData.repstr = str2;
          globData.dollar = str2 != null ? String.instancehelper_indexOf(str2, 36) : -1;
          globData.charBuf = (StringBuilder) null;
          globData.leftIndex = 0;
          object obj2;
          if (num2 != 0)
          {
            obj2 = RegExpImpl.matchOrReplace(cx, scope, thisObj, args, this, globData, nativeRegExp);
          }
          else
          {
            string str3 = globData.str;
            int num3 = String.instancehelper_indexOf(str3, str1);
            if (num3 >= 0)
            {
              int len = String.instancehelper_length(str1);
              this.parens = (SubString[]) null;
              this.lastParen = (SubString) null;
              this.leftContext = new SubString(str3, 0, num3);
              this.lastMatch = new SubString(str3, num3, len);
              this.rightContext = new SubString(str3, num3 + len, String.instancehelper_length(str3) - num3 - len);
              obj2 = (object) Boolean.TRUE;
            }
            else
              obj2 = (object) Boolean.FALSE;
          }
          if (globData.charBuf == null)
          {
            if (globData.global || obj2 == null || !Object.instancehelper_equals(obj2, (object) Boolean.TRUE))
              return (object) globData.str;
            SubString leftContext = this.leftContext;
            RegExpImpl.replace_glob(globData, cx, scope, this, leftContext.index, leftContext.length);
          }
          SubString rightContext = this.rightContext;
          StringBuilder charBuf = globData.charBuf;
          string str4 = rightContext.str;
          int index = rightContext.index;
          int num4 = rightContext.index + rightContext.length;
          int num5 = index;
          object obj3 = (object) str4;
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence2 = charSequence1;
          int num6 = num5;
          int num7 = num4;
          charBuf.append(charSequence2, num6, num7);
          return (object) globData.charBuf.toString();
        case 3:
          int num8 = int.MaxValue;
          if (cx.getLanguageVersion() < 160)
            num8 = 1;
          NativeRegExp regExp2 = RegExpImpl.createRegExp(cx, scope, args, num8, false);
          return RegExpImpl.matchOrReplace(cx, scope, thisObj, args, this, globData, regExp2);
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [LineNumberTable(new byte[] {160, 95, 101, 167, 103, 200, 102, 101, 143, 142, 102, 101, 101, 130, 101, 102, 133, 104, 107, 230, 71, 231, 71, 100, 101, 101, 133, 99, 130, 100, 197, 104, 130, 116, 107, 105, 106, 14, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int find_split(
      Context cx,
      Scriptable scope,
      string target,
      string separator,
      Scriptable reObj,
      int[] ip,
      int[] matchlen,
      bool[] matched,
      string[][] parensp)
    {
      int num1 = ip[0];
      int num2 = String.instancehelper_length(target);
      int languageVersion = cx.getLanguageVersion();
      NativeRegExp nativeRegExp = (NativeRegExp) reObj;
      int num3;
      int num4;
      while (true)
      {
        num3 = ip[0];
        ip[0] = num1;
        if (object.ReferenceEquals(nativeRegExp.executeRegExp(cx, scope, this, target, ip, 0), (object) Boolean.TRUE))
        {
          num4 = ip[0];
          ip[0] = num3;
          matched[0] = true;
          SubString lastMatch = this.lastMatch;
          matchlen[0] = lastMatch.length;
          if (matchlen[0] == 0 && num4 == ip[0])
          {
            if (num4 != num2)
              num1 = num4 + 1;
            else
              goto label_5;
          }
          else
            goto label_9;
        }
        else
          break;
      }
      ip[0] = num3;
      matchlen[0] = 1;
      matched[0] = false;
      return num2;
label_5:
      int num5;
      if (languageVersion == 120)
      {
        matchlen[0] = 1;
        num5 = num4;
        goto label_10;
      }
      else
      {
        num5 = -1;
        goto label_10;
      }
label_9:
      num5 = num4 - matchlen[0];
label_10:
      int length = this.parens != null ? this.parens.Length : 0;
      parensp[0] = new string[length];
      for (int index = 0; index < length; ++index)
      {
        SubString parenSubString = this.getParenSubString(index);
        parensp[0][index] = parenSubString.toString();
      }
      return num5;
    }

    [LineNumberTable(new byte[] {161, 141, 169, 123, 99, 131, 106, 101, 130, 106, 234, 69, 118, 105, 162, 98, 104, 99, 99, 107, 104, 100, 107, 107, 196, 100, 106, 202, 140, 99, 108, 108, 104, 191, 1, 118, 165, 104, 133, 142, 107, 230, 70, 109, 103, 105, 105, 98, 112, 230, 60, 232, 70, 133, 139, 242, 70, 111, 130, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object js_split(Context cx, Scriptable scope, string target, object[] args)
    {
      Scriptable s1 = cx.newArray(scope, 0);
      int num1 = args.Length <= 1 || object.ReferenceEquals(args[1], Undefined.__\u003C\u003Einstance) ? 0 : 1;
      long num2 = 0;
      if (num1 != 0)
      {
        num2 = ScriptRuntime.toUint32(args[1]);
        if (num2 == 0L)
          return (object) s1;
        if (num2 > (long) String.instancehelper_length(target))
          num2 = (long) (1 + String.instancehelper_length(target));
      }
      if (args.Length < 1 || object.ReferenceEquals(args[0], Undefined.__\u003C\u003Einstance))
      {
        s1.put(0, s1, (object) target);
        return (object) s1;
      }
      string str1 = (string) null;
      int[] numArray1 = new int[1];
      Scriptable scriptable = (Scriptable) null;
      RegExpProxy regExpProxy = (RegExpProxy) null;
      if (args[0] is Scriptable)
      {
        regExpProxy = ScriptRuntime.getRegExpProxy(cx);
        if (regExpProxy != null)
        {
          Scriptable s2 = (Scriptable) args[0];
          if (regExpProxy.isRegExp(s2))
            scriptable = s2;
        }
      }
      if (scriptable == null)
      {
        str1 = ScriptRuntime.toString(args[0]);
        numArray1[0] = String.instancehelper_length(str1);
      }
      int[] numArray2 = new int[1]{ 0 };
      int i = 0;
      bool[] flagArray = new bool[1]{ false };
      string[][] strArray = new string[1][]
      {
        (string[]) null
      };
      int languageVersion = cx.getLanguageVersion();
      int split;
      while ((split = RegExpImpl.find_split(cx, scope, target, str1, languageVersion, regExpProxy, scriptable, numArray2, numArray1, flagArray, strArray)) >= 0 && (num1 == 0 || (long) i < num2) && split <= String.instancehelper_length(target))
      {
        string str2 = String.instancehelper_length(target) != 0 ? String.instancehelper_substring(target, numArray2[0], split) : target;
        s1.put(i, s1, (object) str2);
        ++i;
        if (scriptable != null && flagArray[0])
        {
          int length = strArray[0].Length;
          for (int index = 0; index < length && (num1 == 0 || (long) i < num2); ++index)
          {
            s1.put(i, s1, (object) strArray[0][index]);
            ++i;
          }
          flagArray[0] = false;
        }
        numArray2[0] = split + numArray1[0];
        if (languageVersion < 130 && languageVersion != 200 && (num1 == 0 && numArray2[0] == String.instancehelper_length(target)))
          break;
      }
      return (object) s1;
    }
  }
}
