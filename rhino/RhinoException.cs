// Decompiled with JetBrains decompiler
// Type: rhino.RhinoException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.regex;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public abstract class RhinoException : RuntimeException
  {
    [Modifiers]
    private static Pattern JAVA_STACK_PATTERN;
    private static StackStyle stackStyle;
    private string sourceName;
    private int lineNumber;
    private string lineSource;
    private int columnNumber;
    internal object interpreterStackInfo;
    internal int[] interpreterLineData;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 103, 113, 130, 103, 108, 104, 141, 105, 105, 141, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getMessage()
    {
      string str = this.details();
      if (this.sourceName == null || this.lineNumber <= 0)
        return str;
      StringBuilder stringBuilder = new StringBuilder(str);
      stringBuilder.append(" (");
      if (this.sourceName != null)
        stringBuilder.append(this.sourceName);
      if (this.lineNumber > 0)
      {
        stringBuilder.append('#');
        stringBuilder.append(this.lineNumber);
      }
      stringBuilder.append(')');
      return stringBuilder.toString();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int lineNumber() => this.lineNumber;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public string lineSource() => this.lineSource;

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string details() => ((Throwable) this).getMessage();

    [LineNumberTable(new byte[] {14, 110, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initSourceName(string sourceName)
    {
      if (sourceName == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (this.sourceName != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      this.sourceName = sourceName;
    }

    [LineNumberTable(new byte[] {34, 117, 116, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initLineNumber(int lineNumber)
    {
      if (lineNumber <= 0)
      {
        string str = String.valueOf(lineNumber);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (this.lineNumber > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      this.lineNumber = lineNumber;
    }

    [LineNumberTable(new byte[] {72, 110, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initLineSource(string lineSource)
    {
      if (lineSource == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (this.lineSource != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      this.lineSource = lineSource;
    }

    [LineNumberTable(new byte[] {53, 117, 116, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initColumnNumber(int columnNumber)
    {
      if (columnNumber <= 0)
      {
        string str = String.valueOf(columnNumber);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (this.columnNumber > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      this.columnNumber = columnNumber;
    }

    [LineNumberTable(new byte[] {160, 71, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getScriptStackTrace(int limit, string functionName) => RhinoException.formatStackTrace(this.getScriptStack(limit, functionName), this.details());

    [LineNumberTable(new byte[] {160, 141, 102, 103, 104, 102, 104, 173, 98, 104, 99, 233, 69, 124, 105, 120, 153, 106, 105, 191, 1, 122, 138, 110, 101, 109, 119, 166, 127, 3, 221, 126, 115, 101, 109, 105, 230, 59, 232, 39, 235, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptStackElement[] getScriptStack(
      int limit,
      string hideFunction)
    {
      ArrayList arrayList = new ArrayList();
      ScriptStackElement[][] scriptStackElementArray1 = (ScriptStackElement[][]) null;
      if (this.interpreterStackInfo != null)
      {
        Evaluator interpreter = Context.createInterpreter();
        if (interpreter is Interpreter)
          scriptStackElementArray1 = ((Interpreter) interpreter).getScriptStackElements(this);
      }
      int num1 = 0;
      StackTraceElement[] stackTrace = Throwable.instancehelper_getStackTrace((Exception) this);
      int num2 = 0;
      int num3 = hideFunction != null ? 0 : 1;
      StackTraceElement[] stackTraceElementArray = stackTrace;
      int length1 = stackTraceElementArray.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        StackTraceElement stackTraceElement = stackTraceElementArray[index1];
        string fileName = stackTraceElement.getFileName();
        if (String.instancehelper_startsWith(stackTraceElement.getMethodName(), "_c_") && stackTraceElement.getLineNumber() > -1 && (fileName != null && !String.instancehelper_endsWith(fileName, ".java")))
        {
          string methodName = stackTraceElement.getMethodName();
          Pattern javaStackPattern = RhinoException.JAVA_STACK_PATTERN;
          object obj = (object) methodName;
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          Matcher matcher = javaStackPattern.matcher(charSequence2);
          string functionName = String.instancehelper_equals("_c_script_0", (object) methodName) || !matcher.find() ? (string) null : matcher.group(1);
          if (num3 == 0 && String.instancehelper_equals(hideFunction, (object) functionName))
            num3 = 1;
          else if (num3 != 0 && (limit < 0 || num2 < limit))
          {
            ((List) arrayList).add((object) new ScriptStackElement(fileName, functionName, stackTraceElement.getLineNumber()));
            ++num2;
          }
        }
        else if (String.instancehelper_equals("rhino.Interpreter", (object) stackTraceElement.getClassName()) && String.instancehelper_equals("interpretLoop", (object) stackTraceElement.getMethodName()) && (scriptStackElementArray1 != null && scriptStackElementArray1.Length > num1))
        {
          ScriptStackElement[][] scriptStackElementArray2 = scriptStackElementArray1;
          int index2 = num1;
          ++num1;
          ScriptStackElement[] scriptStackElementArray3 = scriptStackElementArray2[index2];
          int length2 = scriptStackElementArray3.Length;
          for (int index3 = 0; index3 < length2; ++index3)
          {
            ScriptStackElement scriptStackElement = scriptStackElementArray3[index3];
            if (num3 == 0 && String.instancehelper_equals(hideFunction, (object) scriptStackElement.__\u003C\u003EfunctionName))
              num3 = 1;
            else if (num3 != 0 && (limit < 0 || num2 < limit))
            {
              ((List) arrayList).add((object) scriptStackElement);
              ++num2;
            }
          }
        }
      }
      return (ScriptStackElement[]) ((List) arrayList).toArray((object[]) new ScriptStackElement[0]);
    }

    [LineNumberTable(new byte[] {160, 76, 102, 139, 158, 104, 168, 118, 159, 6, 104, 130, 104, 130, 168, 232, 52, 235, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string formatStackTrace([In] ScriptStackElement[] obj0, [In] string obj1)
    {
      StringBuilder sb = new StringBuilder();
      string systemProperty = SecurityUtilities.getSystemProperty("line.separator");
      if (object.ReferenceEquals((object) RhinoException.stackStyle, (object) StackStyle.__\u003C\u003EV8) && !String.instancehelper_equals("null", (object) obj1))
      {
        sb.append(obj1);
        sb.append(systemProperty);
      }
      ScriptStackElement[] scriptStackElementArray = obj0;
      int length = scriptStackElementArray.Length;
      for (int index = 0; index < length; ++index)
      {
        ScriptStackElement scriptStackElement = scriptStackElementArray[index];
        switch (RhinoException.\u0031.\u0024SwitchMap\u0024rhino\u0024StackStyle[RhinoException.stackStyle.ordinal()])
        {
          case 1:
            scriptStackElement.renderMozillaStyle(sb);
            break;
          case 2:
            scriptStackElement.renderV8Style(sb);
            break;
          case 3:
            scriptStackElement.renderJavaStyle(sb);
            break;
        }
        sb.append(systemProperty);
      }
      return sb.toString();
    }

    [LineNumberTable(168)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getScriptStackTrace() => this.getScriptStackTrace(-1, (string) null);

    [LineNumberTable(new byte[] {100, 102, 108, 103, 102, 99, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string generateStackTrace()
    {
      CharArrayWriter charArrayWriter = new CharArrayWriter();
      ((Throwable) this).printStackTrace(new PrintWriter((Writer) charArrayWriter));
      string str = charArrayWriter.toString();
      return Context.createInterpreter()?.getPatchedStack(this, str);
    }

    [LineNumberTable(new byte[] {159, 155, 104, 102, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal RhinoException()
    {
      RhinoException rhinoException = this;
      Context.createInterpreter()?.captureStackInfo(this);
    }

    [LineNumberTable(new byte[] {159, 162, 105, 102, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal RhinoException([In] string obj0)
      : base(obj0)
    {
      RhinoException rhinoException = this;
      Context.createInterpreter()?.captureStackInfo(this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public string sourceName() => this.sourceName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int columnNumber() => this.columnNumber;

    [LineNumberTable(new byte[] {80, 100, 163, 99, 135, 99, 135, 99, 135, 100, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal void recordErrorOrigin([In] string obj0, [In] int obj1, [In] string obj2, [In] int obj3)
    {
      if (obj1 == -1)
        obj1 = 0;
      if (obj0 != null)
        this.initSourceName(obj0);
      if (obj1 != 0)
        this.initLineNumber(obj1);
      if (obj2 != null)
        this.initLineSource(obj2);
      if (obj3 == 0)
        return;
      this.initColumnNumber(obj3);
    }

    [Obsolete]
    [LineNumberTable(227)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getScriptStackTrace(FilenameFilter filter) => this.getScriptStackTrace();

    [LineNumberTable(240)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptStackElement[] getScriptStack() => this.getScriptStack(-1, (string) null);

    [LineNumberTable(new byte[] {160, 198, 104, 137, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void printStackTrace(PrintWriter s)
    {
      if (this.interpreterStackInfo == null)
        ((Throwable) this).printStackTrace(s);
      else
        s.print(this.generateStackTrace());
    }

    [LineNumberTable(new byte[] {160, 207, 104, 137, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void printStackTrace(PrintStream s)
    {
      if (this.interpreterStackInfo == null)
        ((Throwable) this).printStackTrace(s);
      else
        s.print(this.generateStackTrace());
    }

    [LineNumberTable(339)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool usesMozillaStackStyle() => object.ReferenceEquals((object) RhinoException.stackStyle, (object) StackStyle.__\u003C\u003EMOZILLA);

    [LineNumberTable(new byte[] {159, 54, 130, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void useMozillaStackStyle(bool flag) => RhinoException.stackStyle = !flag ? StackStyle.__\u003C\u003ERHINO : StackStyle.__\u003C\u003EMOZILLA;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setStackStyle(StackStyle style) => RhinoException.stackStyle = style;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StackStyle getStackStyle() => RhinoException.stackStyle;

    [LineNumberTable(new byte[] {159, 140, 173, 239, 161, 110, 234, 76, 107, 99, 109, 108, 109, 108, 109, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static RhinoException()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.RhinoException"))
        return;
      RhinoException.JAVA_STACK_PATTERN = Pattern.compile("_c_(.*)_\\d+");
      RhinoException.stackStyle = StackStyle.__\u003C\u003ERHINO;
      string property = java.lang.System.getProperty("rhino.stack.style");
      if (property == null)
        return;
      if (String.instancehelper_equalsIgnoreCase("Rhino", property))
        RhinoException.stackStyle = StackStyle.__\u003C\u003ERHINO;
      else if (String.instancehelper_equalsIgnoreCase("Mozilla", property))
      {
        RhinoException.stackStyle = StackStyle.__\u003C\u003EMOZILLA;
      }
      else
      {
        if (!String.instancehelper_equalsIgnoreCase("V8", property))
          return;
        RhinoException.stackStyle = StackStyle.__\u003C\u003EV8;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024rhino\u0024StackStyle;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(200)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.RhinoException$1"))
          return;
        RhinoException.\u0031.\u0024SwitchMap\u0024rhino\u0024StackStyle = new int[StackStyle.values().Length];
        try
        {
          RhinoException.\u0031.\u0024SwitchMap\u0024rhino\u0024StackStyle[StackStyle.__\u003C\u003EMOZILLA.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          RhinoException.\u0031.\u0024SwitchMap\u0024rhino\u0024StackStyle[StackStyle.__\u003C\u003EV8.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          RhinoException.\u0031.\u0024SwitchMap\u0024rhino\u0024StackStyle[StackStyle.__\u003C\u003ERHINO.ordinal()] = 3;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }
  }
}
