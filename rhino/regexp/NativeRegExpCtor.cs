// Decompiled with JetBrains decompiler
// Type: rhino.regexp.NativeRegExpCtor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.regexp
{
  internal class NativeRegExpCtor : BaseFunction
  {
    private const int Id_multiline = 1;
    private const int Id_STAR = 2;
    private const int Id_input = 3;
    private const int Id_UNDERSCORE = 4;
    private const int Id_lastMatch = 5;
    private const int Id_AMPERSAND = 6;
    private const int Id_lastParen = 7;
    private const int Id_PLUS = 8;
    private const int Id_leftContext = 9;
    private const int Id_BACK_QUOTE = 10;
    private const int Id_rightContext = 11;
    private const int Id_QUOTE = 12;
    private const int DOLLAR_ID_BASE = 12;
    private const int Id_DOLLAR_1 = 13;
    private const int Id_DOLLAR_2 = 14;
    private const int Id_DOLLAR_3 = 15;
    private const int Id_DOLLAR_4 = 16;
    private const int Id_DOLLAR_5 = 17;
    private const int Id_DOLLAR_6 = 18;
    private const int Id_DOLLAR_7 = 19;
    private const int Id_DOLLAR_8 = 20;
    private const int Id_DOLLAR_9 = 21;
    private const int MAX_INSTANCE_ID = 21;
    private int multilineAttr;
    private int starAttr;
    private int inputAttr;
    private int underscoreAttr;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 232, 161, 147, 103, 103, 103, 231, 158, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeRegExpCtor()
    {
      NativeRegExpCtor nativeRegExpCtor = this;
      this.multilineAttr = 4;
      this.starAttr = 4;
      this.inputAttr = 4;
      this.underscoreAttr = 4;
    }

    [LineNumberTable(new byte[] {159, 190, 102, 106, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scriptable construct([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      NativeRegExp nativeRegExp = new NativeRegExp();
      nativeRegExp.compile(obj0, obj1, obj2);
      ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeRegExp, obj1, TopLevel.Builtins.__\u003C\u003ERegExp);
      return (Scriptable) nativeRegExp;
    }

    [LineNumberTable(new byte[] {5, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static RegExpImpl getImpl() => (RegExpImpl) ScriptRuntime.getRegExpProxy(Context.getCurrentContext());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getFunctionName() => "RegExp";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getLength() => 2;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getArity() => 2;

    [LineNumberTable(new byte[] {159, 181, 159, 8, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3) => obj3.Length > 0 && obj3[0] is NativeRegExp && (obj3.Length == 1 || object.ReferenceEquals(obj3[1], Undefined.__\u003C\u003Einstance)) ? obj3[0] : (object) this.construct(obj0, obj1, obj3);

    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getMaxInstanceId() => base.getMaxInstanceId() + 21;

    [LineNumberTable(new byte[] {56, 98, 162, 159, 31, 159, 160, 161, 110, 98, 197, 110, 99, 197, 110, 98, 197, 110, 98, 197, 110, 99, 197, 110, 99, 197, 110, 99, 197, 110, 99, 197, 110, 99, 197, 110, 99, 197, 110, 99, 197, 110, 99, 197, 110, 99, 197, 110, 98, 197, 110, 99, 197, 133, 102, 98, 133, 104, 101, 102, 100, 101, 102, 100, 101, 102, 196, 102, 99, 130, 102, 163, 215, 171, 154, 103, 130, 103, 130, 103, 130, 103, 130, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo([In] string obj0)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(obj0))
      {
        case 2:
          switch (String.instancehelper_charAt(obj0, 1))
          {
            case '&':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 6;
                break;
              }
              goto label_39;
            case '\'':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 12;
                break;
              }
              goto label_39;
            case '*':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 2;
                break;
              }
              goto label_39;
            case '+':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 8;
                break;
              }
              goto label_39;
            case '1':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 13;
                break;
              }
              goto label_39;
            case '2':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 14;
                break;
              }
              goto label_39;
            case '3':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 15;
                break;
              }
              goto label_39;
            case '4':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 16;
                break;
              }
              goto label_39;
            case '5':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 17;
                break;
              }
              goto label_39;
            case '6':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 18;
                break;
              }
              goto label_39;
            case '7':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 19;
                break;
              }
              goto label_39;
            case '8':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 20;
                break;
              }
              goto label_39;
            case '9':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 21;
                break;
              }
              goto label_39;
            case '_':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 4;
                break;
              }
              goto label_39;
            case '`':
              if (String.instancehelper_charAt(obj0, 0) == '$')
              {
                num = 10;
                break;
              }
              goto label_39;
            default:
              goto label_39;
          }
          break;
        case 5:
          str = "input";
          num = 3;
          goto default;
        case 9:
          switch (String.instancehelper_charAt(obj0, 4))
          {
            case 'M':
              str = "lastMatch";
              num = 5;
              goto label_39;
            case 'P':
              str = "lastParen";
              num = 7;
              goto label_39;
            case 'i':
              str = "multiline";
              num = 1;
              goto label_39;
            default:
              goto label_39;
          }
        case 11:
          str = "leftContext";
          num = 9;
          goto default;
        case 12:
          str = "rightContext";
          num = 11;
          goto default;
        default:
label_39:
          if (str != null && !object.ReferenceEquals((object) str, (object) obj0) && !String.instancehelper_equals(str, (object) obj0))
          {
            num = 0;
            break;
          }
          break;
      }
      int attributes;
      switch (num)
      {
        case 0:
          return base.findInstanceIdInfo(obj0);
        case 1:
          attributes = this.multilineAttr;
          break;
        case 2:
          attributes = this.starAttr;
          break;
        case 3:
          attributes = this.inputAttr;
          break;
        case 4:
          attributes = this.underscoreAttr;
          break;
        default:
          attributes = 5;
          break;
      }
      return IdScriptableObject.instanceIdInfo(attributes, base.getMaxInstanceId() + num);
    }

    [LineNumberTable(new byte[] {160, 149, 105, 111, 159, 27, 134, 166, 134, 166, 134, 166, 134, 166, 134, 166, 134, 166, 103, 116, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getInstanceIdName([In] int obj0)
    {
      int num = obj0 - base.getMaxInstanceId();
      if (1 > num || num > 21)
        return base.getInstanceIdName(obj0);
      switch (num)
      {
        case 1:
          return "multiline";
        case 2:
          return "$*";
        case 3:
          return "input";
        case 4:
          return "$_";
        case 5:
          return "lastMatch";
        case 6:
          return "$&";
        case 7:
          return "lastParen";
        case 8:
          return "$+";
        case 9:
          return "leftContext";
        case 10:
          return "$`";
        case 11:
          return "rightContext";
        case 12:
          return "$'";
        default:
          return String.newhelper(new char[2]
          {
            '$',
            (char) (49 + (num - 12 - 1))
          });
      }
    }

    [LineNumberTable(new byte[] {160, 192, 105, 111, 134, 191, 27, 204, 103, 194, 103, 194, 103, 194, 103, 194, 103, 194, 103, 104, 162, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue([In] int obj0)
    {
      int num1 = obj0 - base.getMaxInstanceId();
      if (1 > num1 || num1 > 21)
        return base.getInstanceIdValue(obj0);
      RegExpImpl impl = NativeRegExpCtor.getImpl();
      object obj;
      switch (num1)
      {
        case 1:
        case 2:
          return (object) ScriptRuntime.wrapBoolean(impl.multiline);
        case 3:
        case 4:
          obj = (object) impl.input;
          break;
        case 5:
        case 6:
          obj = (object) impl.lastMatch;
          break;
        case 7:
        case 8:
          obj = (object) impl.lastParen;
          break;
        case 9:
        case 10:
          obj = (object) impl.leftContext;
          break;
        case 11:
        case 12:
          obj = (object) impl.rightContext;
          break;
        default:
          int num2 = num1 - 12 - 1;
          obj = (object) impl.getParenSubString(num2);
          break;
      }
      return obj == null ? (object) "" : (object) Object.instancehelper_toString(obj);
    }

    [LineNumberTable(new byte[] {160, 240, 105, 191, 27, 112, 193, 112, 225, 74, 129, 103, 104, 161, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdValue([In] int obj0, [In] object obj1)
    {
      int num1 = obj0 - base.getMaxInstanceId();
      switch (num1)
      {
        case 1:
        case 2:
          NativeRegExpCtor.getImpl().multiline = ScriptRuntime.toBoolean(obj1);
          break;
        case 3:
        case 4:
          NativeRegExpCtor.getImpl().input = ScriptRuntime.toString(obj1);
          break;
        case 5:
          break;
        case 6:
          break;
        case 7:
          break;
        case 8:
          break;
        case 9:
          break;
        case 10:
          break;
        case 11:
          break;
        case 12:
          break;
        default:
          int num2 = num1 - 12 - 1;
          if (0 <= num2 && num2 <= 8)
            break;
          base.setInstanceIdValue(obj0, obj1);
          break;
      }
    }

    [LineNumberTable(new byte[] {161, 16, 105, 159, 27, 103, 129, 103, 129, 103, 129, 103, 225, 75, 129, 103, 136, 161, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdAttributes([In] int obj0, [In] int obj1)
    {
      int num1 = obj0 - base.getMaxInstanceId();
      switch (num1)
      {
        case 1:
          this.multilineAttr = obj1;
          break;
        case 2:
          this.starAttr = obj1;
          break;
        case 3:
          this.inputAttr = obj1;
          break;
        case 4:
          this.underscoreAttr = obj1;
          break;
        case 5:
          break;
        case 6:
          break;
        case 7:
          break;
        case 8:
          break;
        case 9:
          break;
        case 10:
          break;
        case 11:
          break;
        case 12:
          break;
        default:
          int num2 = num1 - 12 - 1;
          if (0 <= num2 && num2 <= 8)
            break;
          base.setInstanceIdAttributes(obj0, obj1);
          break;
      }
    }

    [HideFromJava]
    static NativeRegExpCtor() => BaseFunction.__\u003Cclinit\u003E();
  }
}
