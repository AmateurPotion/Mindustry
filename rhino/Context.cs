// Decompiled with JetBrains decompiler
// Type: rhino.Context
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.lang.reflect;
using java.net;
using java.util;
using java.util.jar;
using rhino.ast;
using rhino.classfile;
using rhino.debug;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class Context : Object
  {
    public const int VERSION_UNKNOWN = -1;
    public const int VERSION_DEFAULT = 200;
    public const int VERSION_1_0 = 100;
    public const int VERSION_1_1 = 110;
    public const int VERSION_1_2 = 120;
    public const int VERSION_1_3 = 130;
    public const int VERSION_1_4 = 140;
    public const int VERSION_1_5 = 150;
    public const int VERSION_1_6 = 160;
    public const int VERSION_1_7 = 170;
    public const int VERSION_1_8 = 180;
    public const int VERSION_ES6 = 200;
    public const int FEATURE_NON_ECMA_GET_YEAR = 1;
    public const int FEATURE_MEMBER_EXPR_AS_FUNCTION_NAME = 2;
    public const int FEATURE_RESERVED_KEYWORD_AS_IDENTIFIER = 3;
    public const int FEATURE_TO_STRING_AS_SOURCE = 4;
    public const int FEATURE_PARENT_PROTO_PROPERTIES = 5;
    [Obsolete]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    public const int FEATURE_PARENT_PROTO_PROPRTIES = 5;
    public const int FEATURE_E4X = 6;
    public const int FEATURE_DYNAMIC_SCOPE = 7;
    public const int FEATURE_STRICT_VARS = 8;
    public const int FEATURE_STRICT_EVAL = 9;
    public const int FEATURE_LOCATION_INFORMATION_IN_ERROR = 10;
    public const int FEATURE_STRICT_MODE = 11;
    public const int FEATURE_WARNING_AS_ERROR = 12;
    public const int FEATURE_ENHANCED_JAVA_ACCESS = 13;
    public const int FEATURE_V8_EXTENSIONS = 14;
    public const int FEATURE_OLD_UNDEF_NULL_THIS = 15;
    public const int FEATURE_ENUMERATE_IDS_FIRST = 16;
    public const int FEATURE_THREAD_SAFE_OBJECTS = 17;
    public const int FEATURE_INTEGER_WITHOUT_DECIMAL_PLACE = 18;
    public const int FEATURE_LITTLE_ENDIAN = 19;
    public const int FEATURE_ENABLE_XML_SECURE_PARSING = 20;
    public const string languageVersionProperty = "language version";
    public const string errorReporterProperty = "error reporter";
    internal static object[] __\u003C\u003EemptyArgs;
    [Modifiers]
    [Signature("Ljava/lang/Class<*>;")]
    private static Class codegenClass;
    [Modifiers]
    [Signature("Ljava/lang/Class<*>;")]
    private static Class interpreterClass;
    private static string implementationVersion;
    [Modifiers]
    private ContextFactory factory;
    private bool @sealed;
    private object sealKey;
    internal Scriptable topCallScope;
    internal bool isContinuationsTopCall;
    internal NativeCall currentActivationCall;
    internal BaseFunction typeErrorThrower;
    internal ObjToIntMap iterating;
    internal object interpreterSecurityDomain;
    internal int version;
    private SecurityController securityController;
    private bool hasClassShutter;
    private ClassShutter classShutter;
    private ErrorReporter errorReporter;
    internal RegExpProxy regExpProxy;
    private Locale locale;
    private bool generatingDebug;
    private bool generatingDebugChanged;
    private bool generatingSource;
    internal bool useDynamicScope;
    private int optimizationLevel;
    private int maximumInterpreterStackDepth;
    private WrapFactory wrapFactory;
    internal Debugger debugger;
    private object debuggerData;
    private int enterCount;
    [Signature("Ljava/util/Map<Ljava/lang/Object;Ljava/lang/Object;>;")]
    private Map threadLocalMap;
    private ClassLoader applicationClassLoader;
    [Signature("Ljava/util/Set<Ljava/lang/String;>;")]
    internal Set activationNames;
    internal object lastInterpreterFrame;
    internal ObjArray previousInterpreterInvocations;
    internal int instructionCount;
    internal int instructionThreshold;
    internal long scratchUint32;
    internal Scriptable scratchScriptable;
    public bool generateObserverCount;
    internal bool isTopLevelStrict;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(402)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Context enter() => Context.enter((Context) null, ContextFactory.getGlobal());

    [LineNumberTable(new byte[] {166, 95, 109, 133, 131, 102, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setOptimizationLevel(int optimizationLevel)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (optimizationLevel == -2)
        optimizationLevel = -1;
      Context.checkOptimizationLevel(optimizationLevel);
      if (Context.codegenClass == null)
        optimizationLevel = -1;
      this.optimizationLevel = optimizationLevel;
    }

    [LineNumberTable(new byte[] {166, 194, 109, 110, 104, 176, 103, 103})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public void setClassShutter(ClassShutter shutter)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (shutter == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (this.hasClassShutter)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SecurityException("Cannot overwrite existing ClassShutter object");
      }
      this.classShutter = shutter;
      this.hasClassShutter = true;
    }

    [LineNumberTable(new byte[] {167, 51, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WrapFactory getWrapFactory()
    {
      if (this.wrapFactory == null)
        this.wrapFactory = new WrapFactory();
      return this.wrapFactory;
    }

    [LineNumberTable(new byte[] {161, 235, 109, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLanguageVersion(int version)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      Context.checkLanguageVersion(version);
      this.version = version;
    }

    [LineNumberTable(new byte[] {163, 185, 141, 99, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object evaluateString(
      Scriptable scope,
      string source,
      string sourceName,
      int lineno,
      object securityDomain)
    {
      return this.compileString(source, sourceName, lineno, securityDomain)?.exec(this, scope);
    }

    [LineNumberTable(new byte[] {161, 93, 107, 108, 99, 176, 111, 117, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void exit()
    {
      object threadContextHelper = VMBridge.instance.getThreadContextHelper();
      Context context1 = VMBridge.instance.getContext(threadContextHelper);
      if (context1 == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Calling Context.exit without previous Context.enter");
      }
      if (context1.enterCount < 1)
        Kit.codeBug();
      Context context2 = context1;
      int num1 = context2.enterCount - 1;
      Context context3 = context2;
      int num2 = num1;
      context3.enterCount = num1;
      if (num2 != 0)
        return;
      VMBridge.instance.setContext(threadContextHelper, (Context) null);
      context1.factory.onContextReleased(context1);
    }

    [LineNumberTable(new byte[] {161, 19, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Context getCurrentContext()
    {
      object threadContextHelper = VMBridge.instance.getThreadContextHelper();
      return VMBridge.instance.getContext(threadContextHelper);
    }

    [LineNumberTable(new byte[] {167, 124, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasFeature(int featureIndex) => this.getFactory().hasFeature(this, featureIndex);

    [LineNumberTable(new byte[] {162, 217, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static EvaluatorException reportRuntimeError1(
      [In] string obj0,
      [In] object obj1)
    {
      return Context.reportRuntimeError(ScriptRuntime.getMessage1(obj0, obj1));
    }

    [LineNumberTable(new byte[] {168, 3, 102, 99, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Context getContext()
    {
      Context currentContext = Context.getCurrentContext();
      if (currentContext == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("No Context associated with current Thread");
      }
      return currentContext;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int getLanguageVersion() => this.version;

    [LineNumberTable(new byte[] {162, 223, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static EvaluatorException reportRuntimeError2(
      [In] string obj0,
      [In] object obj1,
      [In] object obj2)
    {
      return Context.reportRuntimeError(ScriptRuntime.getMessage2(obj0, obj1, obj2));
    }

    [LineNumberTable(new byte[] {162, 248, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EvaluatorException reportRuntimeError(string message)
    {
      int[] numArray = new int[1]{ 0 };
      string positionFromStack = Context.getSourcePositionFromStack(numArray);
      return Context.reportRuntimeError(message, positionFromStack, numArray[0], (string) null, 0);
    }

    [Throws(new string[] {"rhino.EvaluatorException"})]
    [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(1618)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object jsToJava(object value, Class desiredType) => NativeJavaObject.coerceTypeImpl(desiredType, value);

    [LineNumberTable(new byte[] {161, 142, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object call(
      ContextFactory factory,
      Callable callable,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (factory == null)
        factory = ContextFactory.getGlobal();
      return Context.call(factory, (ContextAction) new Context.__\u003C\u003EAnon0(callable, scope, thisObj, args));
    }

    [LineNumberTable(2383)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isStrictMode() => this.isTopLevelStrict || this.currentActivationCall != null && this.currentActivationCall.isStrict;

    [LineNumberTable(new byte[] {162, 211, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static EvaluatorException reportRuntimeError0([In] string obj0) => Context.reportRuntimeError(ScriptRuntime.getMessage0(obj0));

    [LineNumberTable(new byte[] {168, 132, 102, 99, 98, 104, 102, 99, 233, 70, 107, 117, 105, 114, 105, 101, 101, 227, 58, 232, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getSourcePositionFromStack([In] int[] obj0)
    {
      Context currentContext = Context.getCurrentContext();
      if (currentContext == null)
        return (string) null;
      if (currentContext.lastInterpreterFrame != null)
      {
        Evaluator interpreter = Context.createInterpreter();
        if (interpreter != null)
          return interpreter.getSourcePositionFromStack(currentContext, obj0);
      }
      StackTraceElement[] stackTrace = Throwable.instancehelper_getStackTrace((Exception) new Throwable());
      int length = stackTrace.Length;
      for (int index = 0; index < length; ++index)
      {
        StackTraceElement stackTraceElement = stackTrace[index];
        string fileName = stackTraceElement.getFileName();
        if (fileName != null && !String.instancehelper_endsWith(fileName, ".java"))
        {
          int lineNumber = stackTraceElement.getLineNumber();
          if (lineNumber >= 0)
          {
            obj0[0] = lineNumber;
            return fileName;
          }
        }
      }
      return (string) null;
    }

    [LineNumberTable(new byte[] {162, 65, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ErrorReporter getErrorReporter() => this.errorReporter == null ? (ErrorReporter) DefaultErrorReporter.instance : this.errorReporter;

    [LineNumberTable(2290)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Evaluator createInterpreter() => (Evaluator) Kit.newInstanceOrNull(Context.interpreterClass);

    [LineNumberTable(new byte[] {164, 191, 191, 14, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Function compileFunction(
      [In] Scriptable obj0,
      [In] string obj1,
      [In] Evaluator obj2,
      [In] ErrorReporter obj3,
      [In] string obj4,
      [In] int obj5,
      [In] object obj6)
    {
      Function function;
      IOException ioException1;
      try
      {
        function = (Function) this.compileImpl(obj0, obj1, obj4, obj5, obj6, true, obj2, obj3);
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return function;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isGeneratingDebugChanged() => this.generatingDebugChanged;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isGeneratingDebug() => this.generatingDebug;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int getOptimizationLevel() => this.optimizationLevel;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isGeneratingSource() => this.generatingSource;

    [LineNumberTable(new byte[] {162, 2, 104, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkLanguageVersion(int version)
    {
      if (!Context.isValidLanguageVersion(version))
      {
        string str = new StringBuilder().append("Bad language version: ").append(version).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {166, 111, 104, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkOptimizationLevel(int optimizationLevel)
    {
      if (!Context.isValidOptimizationLevel(optimizationLevel))
      {
        string str = new StringBuilder().append("Optimization level outside [-1..9]: ").append(optimizationLevel).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ClassShutter access\u0024002([In] Context obj0, [In] ClassShutter obj1)
    {
      Context context1 = obj0;
      ClassShutter classShutter1 = obj1;
      Context context2 = context1;
      ClassShutter classShutter2 = classShutter1;
      context2.classShutter = classShutter1;
      return classShutter2;
    }

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ClassShutter access\u0024000([In] Context obj0) => obj0.classShutter;

    [LineNumberTable(new byte[] {160, 253, 232, 167, 255, 231, 99, 231, 151, 223, 99, 144, 103, 107, 113, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Context(ContextFactory factory)
    {
      Context context = this;
      this.generatingSource = true;
      this.generateObserverCount = false;
      if (factory == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("factory == null");
      }
      this.factory = factory;
      this.version = 200;
      this.optimizationLevel = Context.codegenClass == null ? -1 : 0;
      this.maximumInterpreterStackDepth = int.MaxValue;
    }

    [LineNumberTable(new byte[] {161, 56, 107, 108, 99, 133, 99, 104, 104, 144, 103, 112, 169, 104, 176, 140, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Context enter([In] Context obj0, [In] ContextFactory obj1)
    {
      object threadContextHelper = VMBridge.instance.getThreadContextHelper();
      Context context = VMBridge.instance.getContext(threadContextHelper);
      if (context != null)
      {
        obj0 = context;
      }
      else
      {
        if (obj0 == null)
        {
          obj0 = obj1.makeContext();
          if (obj0.enterCount != 0)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException("factory.makeContext() returned Context instance already associated with some thread");
          }
          obj1.onContextCreated(obj0);
          if (obj1.isSealed() && !obj0.isSealed())
            obj0.seal((object) null);
        }
        else if (obj0.enterCount != 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("can not use Context instance already associated with some thread");
        }
        VMBridge.instance.setContext(threadContextHelper, obj0);
      }
      ++obj0.enterCount;
      return obj0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isSealed() => this.@sealed;

    [LineNumberTable(new byte[] {161, 189, 109, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void seal(object sealKey)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      this.@sealed = true;
      this.sealKey = sealKey;
    }

    [Signature("<T:Ljava/lang/Object;>(Lrhino/ContextFactory;Lrhino/ContextAction<TT;>;)TT;")]
    [LineNumberTable(new byte[] {161, 152, 136, 140, 101, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object call([In] ContextFactory obj0, [In] ContextAction obj1)
    {
      Context c = Context.enter((Context) null, obj0);
      try
      {
        return obj1.run(c);
      }
      finally
      {
        Context.exit();
      }
    }

    [LineNumberTable(581)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void onSealedMutation()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isValidLanguageVersion(int version)
    {
      switch (version)
      {
        case 100:
        case 110:
        case 120:
        case 130:
        case 140:
        case 150:
        case 160:
        case 170:
        case 180:
        case 200:
          return true;
        default:
          return false;
      }
    }

    [LineNumberTable(new byte[] {162, 164, 102, 99, 179, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void reportError(
      string message,
      string sourceName,
      int lineno,
      string lineSource,
      int lineOffset)
    {
      Context currentContext = Context.getCurrentContext();
      if (currentContext != null)
      {
        currentContext.getErrorReporter().error(message, sourceName, lineno, lineSource, lineOffset);
      }
      else
      {
        string detail = message;
        string sourceName1 = sourceName;
        int lineNumber = lineno;
        string lineSource1 = lineSource;
        int columnNumber = lineOffset;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new EvaluatorException(detail, sourceName1, lineNumber, lineSource1, columnNumber);
      }
    }

    [LineNumberTable(new byte[] {162, 122, 102, 106, 141, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void reportWarning(
      string message,
      string sourceName,
      int lineno,
      string lineSource,
      int lineOffset)
    {
      Context context = Context.getContext();
      if (context.hasFeature(12))
        Context.reportError(message, sourceName, lineno, lineSource, lineOffset);
      else
        context.getErrorReporter().warning(message, sourceName, lineno, lineSource, lineOffset);
    }

    [LineNumberTable(new byte[] {162, 201, 102, 99, 108, 37, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EvaluatorException reportRuntimeError(
      string message,
      string sourceName,
      int lineno,
      string lineSource,
      int lineOffset)
    {
      Context currentContext = Context.getCurrentContext();
      if (currentContext != null)
        return currentContext.getErrorReporter().runtimeError(message, sourceName, lineno, lineSource, lineOffset);
      string detail = message;
      string sourceName1 = sourceName;
      int lineNumber = lineno;
      string lineSource1 = lineSource;
      int columnNumber = lineOffset;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new EvaluatorException(detail, sourceName1, lineNumber, lineSource1, columnNumber);
    }

    [LineNumberTable(999)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptableObject initStandardObjects(
      ScriptableObject scope,
      bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      return ScriptRuntime.initStandardObjects(this, scope, num != 0);
    }

    [LineNumberTable(1038)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptableObject initSafeStandardObjects(
      ScriptableObject scope,
      bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      return ScriptRuntime.initSafeStandardObjects(this, scope, num != 0);
    }

    [LineNumberTable(new byte[] {164, 139, 132, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Script compileString(
      string source,
      string sourceName,
      int lineno,
      object securityDomain)
    {
      if (lineno < 0)
        lineno = 0;
      return this.compileString(source, (Evaluator) null, (ErrorReporter) null, sourceName, lineno, securityDomain);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 112, 132, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Script compileReader(
      Reader @in,
      string sourceName,
      int lineno,
      object securityDomain)
    {
      if (lineno < 0)
        lineno = 0;
      return (Script) this.compileImpl((Scriptable) null, Kit.readReader(@in), sourceName, lineno, securityDomain, false, (Evaluator) null, (ErrorReporter) null);
    }

    [Throws(new string[] {"rhino.ContinuationPending"})]
    [LineNumberTable(new byte[] {164, 1, 136, 176, 104, 240, 69, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object callFunctionWithContinuations(
      Callable function,
      Scriptable scope,
      object[] args)
    {
      if (!(function is InterpretedFunction))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Function argument was not created by interpreted mode ");
      }
      if (ScriptRuntime.hasTopCall(this))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Cannot have any pending top calls when executing a script with continuations");
      }
      this.isContinuationsTopCall = true;
      return ScriptRuntime.doTopCall(function, this, scope, scope, args, this.isTopLevelStrict);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {157, 110, 169, 99, 135, 108, 240, 69, 144, 102, 103, 100, 168, 239, 69, 100, 168, 252, 73, 226, 56, 193, 143, 103, 177, 104, 105, 104, 104, 105, 98, 240, 69, 99, 144, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object compileImpl(
      [In] Scriptable obj0,
      [In] string obj1,
      [In] string obj2,
      [In] int obj3,
      [In] object obj4,
      [In] bool obj5,
      [In] Evaluator obj6,
      [In] ErrorReporter obj7)
    {
      int num = obj5 ? 1 : 0;
      ref Evaluator local1 = ref obj6;
      ref ErrorReporter local2 = ref obj7;
      if (obj2 == null)
        obj2 = "unnamed script";
      if (obj4 != null && this.getSecurityController() == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("securityDomain should be null if setSecurityController() was never called");
      }
      if ((obj0 != null ? 0 : 1) == num)
        Kit.codeBug();
      CompilerEnvirons ce = new CompilerEnvirons();
      ce.initFromContext(this);
      if (obj7 == null)
        obj7 = ce.getErrorReporter();
      ScriptNode sn1 = this.parse(obj1, obj2, obj3, ce, obj7, num != 0);
      object obj;
      try
      {
        if (obj6 == null)
          obj6 = this.createCompiler();
        obj = obj6.compile(ce, sn1, sn1.getEncodedSource(), num != 0);
        goto label_14;
      }
      catch (ClassFileWriter.ClassFileFormatException ex)
      {
      }
      ScriptNode sn2 = this.parse(obj1, obj2, obj3, ce, obj7, num != 0);
      obj6 = Context.createInterpreter();
      obj = obj6.compile(ce, sn2, sn2.getEncodedSource(), num != 0);
label_14:
      if (this.debugger != null)
      {
        if (obj1 == null)
          Kit.codeBug();
        if (obj is DebuggableScript)
        {
          Context.notifyDebugger_r(this, (DebuggableScript) obj, obj1);
        }
        else
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("NOT SUPPORTED");
        }
      }
      return num == 0 ? (object) obj6.createScriptObject(obj, obj4) : (object) obj6.createFunctionObject(this, obj0, obj, obj4);
    }

    [LineNumberTable(new byte[] {164, 153, 191, 13, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Script compileString(
      [In] string obj0,
      [In] Evaluator obj1,
      [In] ErrorReporter obj2,
      [In] string obj3,
      [In] int obj4,
      [In] object obj5)
    {
      Script script;
      IOException ioException1;
      try
      {
        script = (Script) this.compileImpl((Scriptable) null, obj0, obj3, obj4, obj5, false, obj1, obj2);
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return script;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(1440)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable newObject(
      Scriptable scope,
      string constructorName,
      object[] args)
    {
      return ScriptRuntime.newObject(this, scope, constructorName, args);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isValidOptimizationLevel(int optimizationLevel) => -1 <= optimizationLevel && optimizationLevel <= 9;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContextFactory getFactory() => this.factory;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setGenerateObserverCount(bool generateObserverCount) => this.generateObserverCount = generateObserverCount;

    [LineNumberTable(new byte[] {168, 176, 102, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual SecurityController getSecurityController() => SecurityController.global() ?? this.securityController;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {157, 95, 163, 106, 99, 135, 104, 167, 106, 131, 105, 206, 255, 6, 69, 106, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ScriptNode parse(
      [In] string obj0,
      [In] string obj1,
      [In] int obj2,
      [In] CompilerEnvirons obj3,
      [In] ErrorReporter obj4,
      [In] bool obj5)
    {
      int num = obj5 ? 1 : 0;
      Parser parser = new Parser(obj3, obj4);
      if (num != 0)
        parser.calledByCompileFunction = true;
      if (this.isStrictMode())
        parser.setDefaultUseStrictDirective(true);
      AstRoot root = parser.parse(obj0, obj1, obj2);
      if (num != 0 && (root.getFirstChild() == null || root.getFirstChild().getType() != 110))
      {
        string str = new StringBuilder().append("compileFunction only accepts source with single JS function: ").append(obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return new IRFactory(obj3, obj4).transformTree(root);
    }

    [LineNumberTable(new byte[] {168, 117, 98, 112, 144, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Evaluator createCompiler()
    {
      Evaluator evaluator = (Evaluator) null;
      if (this.optimizationLevel >= 0 && Context.codegenClass != null)
        evaluator = (Evaluator) Kit.newInstanceOrNull(Context.codegenClass);
      if (evaluator == null)
        evaluator = Context.createInterpreter();
      return evaluator;
    }

    [LineNumberTable(new byte[] {168, 105, 110, 107, 46, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void notifyDebugger_r([In] Context obj0, [In] DebuggableScript obj1, [In] string obj2)
    {
      obj0.debugger.handleCompilationDone(obj0, obj1, obj2);
      for (int i = 0; i != obj1.getFunctionCount(); ++i)
        Context.notifyDebugger_r(obj0, obj1.getFunction(i), obj2);
    }

    [Modifiers]
    [LineNumberTable(515)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024call\u00240(
      [In] Callable obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3,
      [In] Context obj4)
    {
      return obj0.call(obj4, obj1, obj2, obj3);
    }

    [Obsolete]
    [LineNumberTable(new byte[] {160, 241, 107})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Context()
      : this(ContextFactory.getGlobal())
    {
    }

    [Obsolete]
    [LineNumberTable(422)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Context enter(Context cx) => Context.enter(cx, ContextFactory.getGlobal());

    [Obsolete]
    [Signature("<T:Ljava/lang/Object;>(Lrhino/ContextAction<TT;>;)TT;")]
    [LineNumberTable(491)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object call(ContextAction action) => Context.call(ContextFactory.getGlobal(), action);

    [LineNumberTable(new byte[] {161, 203, 110, 121, 115, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void unseal(object sealKey)
    {
      if (sealKey == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (!object.ReferenceEquals(this.sealKey, sealKey))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (!this.@sealed)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      this.@sealed = false;
      this.sealKey = (object) null;
    }

    [LineNumberTable(new byte[] {162, 24, 170, 191, 6, 2, 97, 194, 107, 108, 130, 103, 103, 104, 120, 118, 127, 31, 239, 70, 180, 2, 161, 232, 60, 180, 2, 225, 57, 227, 70, 180, 2, 161, 226, 56, 193, 180, 2, 161, 98, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public string getImplementationVersion()
    {
      if (Context.implementationVersion == null)
      {
        Enumeration resources;
        try
        {
          resources = ((Class) ClassLiteral<Context>.Value).getClassLoader(Context.__\u003CGetCallerID\u003E()).getResources("META-INF/MANIFEST.MF");
          goto label_4;
        }
        catch (IOException ex)
        {
        }
        return (string) null;
label_4:
        while (resources.hasMoreElements())
        {
          URL url = (URL) resources.nextElement();
          InputStream inputStream = (InputStream) null;
          string implementationVersion;
          // ISSUE: fault handler
          try
          {
            inputStream = url.openStream();
            java.util.jar.Attributes mainAttributes = new Manifest(inputStream).getMainAttributes();
            if (String.instancehelper_equals("Mozilla Rhino", (object) mainAttributes.getValue("Implementation-Title")))
            {
              Context.implementationVersion = new StringBuilder().append("Rhino ").append(mainAttributes.getValue("Implementation-Version")).append(" ").append(String.instancehelper_replaceAll(mainAttributes.getValue("Built-Date"), "-", " ")).toString();
              implementationVersion = Context.implementationVersion;
              goto label_15;
            }
            else
              goto label_20;
          }
          catch (IOException ex)
          {
          }
          __fault
          {
            try
            {
              if (inputStream != null)
              {
                inputStream.close();
                goto label_13;
              }
              else
                goto label_13;
            }
            catch (IOException ex)
            {
            }
label_13:;
          }
          try
          {
            inputStream?.close();
          }
          catch (IOException ex)
          {
          }
          continue;
label_15:
          try
          {
            if (inputStream != null)
            {
              inputStream.close();
              goto label_19;
            }
            else
              goto label_19;
          }
          catch (IOException ex)
          {
          }
label_19:
          return implementationVersion;
label_20:
          try
          {
            inputStream?.close();
          }
          catch (IOException ex)
          {
          }
        }
      }
      return Context.implementationVersion;
    }

    [LineNumberTable(new byte[] {162, 77, 109, 110, 103, 105, 130, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ErrorReporter setErrorReporter(ErrorReporter reporter)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (reporter == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      ErrorReporter errorReporter = this.getErrorReporter();
      if (object.ReferenceEquals((object) reporter, (object) errorReporter))
        return errorReporter;
      this.errorReporter = reporter;
      return errorReporter;
    }

    [LineNumberTable(new byte[] {162, 94, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Locale getLocale()
    {
      if (this.locale == null)
        this.locale = Locale.getDefault();
      return this.locale;
    }

    [LineNumberTable(new byte[] {162, 104, 109, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Locale setLocale(Locale loc)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      Locale locale = this.locale;
      this.locale = loc;
      return locale;
    }

    [LineNumberTable(new byte[] {162, 136, 107, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void reportWarning(string message)
    {
      int[] numArray = new int[1]{ 0 };
      string positionFromStack = Context.getSourcePositionFromStack(numArray);
      Context.reportWarning(message, positionFromStack, numArray[0], (string) null, 0);
    }

    [LineNumberTable(new byte[] {162, 142, 107, 103, 102, 103, 103, 103, 102, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void reportWarning(string message, Exception t)
    {
      int[] numArray = new int[1]{ 0 };
      string positionFromStack = Context.getSourcePositionFromStack(numArray);
      StringWriter stringWriter = new StringWriter();
      PrintWriter printWriter = new PrintWriter((Writer) stringWriter);
      printWriter.println(message);
      Throwable.instancehelper_printStackTrace(t, printWriter);
      printWriter.flush();
      Context.reportWarning(Object.instancehelper_toString((object) stringWriter), positionFromStack, numArray[0], (string) null, 0);
    }

    [LineNumberTable(new byte[] {162, 180, 107, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void reportError(string message)
    {
      int[] numArray = new int[1]{ 0 };
      string positionFromStack = Context.getSourcePositionFromStack(numArray);
      Context.reportError(message, positionFromStack, numArray[0], (string) null, 0);
    }

    [LineNumberTable(new byte[] {162, 230, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static EvaluatorException reportRuntimeError3(
      [In] string obj0,
      [In] object obj1,
      [In] object obj2,
      [In] object obj3)
    {
      return Context.reportRuntimeError(ScriptRuntime.getMessage3(obj0, obj1, obj2, obj3));
    }

    [LineNumberTable(new byte[] {162, 237, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static EvaluatorException reportRuntimeError4(
      [In] string obj0,
      [In] object obj1,
      [In] object obj2,
      [In] object obj3,
      [In] object obj4)
    {
      return Context.reportRuntimeError(ScriptRuntime.getMessage4(obj0, obj1, obj2, obj3, obj4));
    }

    [LineNumberTable(893)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScriptableObject initStandardObjects() => this.initStandardObjects((ScriptableObject) null, false);

    [LineNumberTable(918)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScriptableObject initSafeStandardObjects() => this.initSafeStandardObjects((ScriptableObject) null, false);

    [LineNumberTable(939)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Scriptable initStandardObjects(ScriptableObject scope) => (Scriptable) this.initStandardObjects(scope, false);

    [LineNumberTable(968)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Scriptable initSafeStandardObjects(ScriptableObject scope) => (Scriptable) this.initSafeStandardObjects(scope, false);

    [LineNumberTable(1045)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getUndefinedValue() => Undefined.__\u003C\u003Einstance;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {163, 209, 109, 99, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object evaluateReader(
      Scriptable scope,
      Reader @in,
      string sourceName,
      int lineno,
      object securityDomain)
    {
      return this.compileReader(@in, sourceName, lineno, securityDomain)?.exec(this, scope);
    }

    [Throws(new string[] {"rhino.ContinuationPending"})]
    [LineNumberTable(new byte[] {163, 231, 110, 135, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object executeScriptWithContinuations(Script script, Scriptable scope)
    {
      if (!(script is InterpretedFunction) || !((InterpretedFunction) script).isScript())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Script argument was not a script or was not created by interpreted mode ");
      }
      return this.callFunctionWithContinuations((Callable) script, scope, ScriptRuntime.__\u003C\u003EemptyArgs);
    }

    [LineNumberTable(new byte[] {164, 30, 97, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ContinuationPending captureContinuation() => new ContinuationPending(Interpreter.captureContinuation(this));

    [Throws(new string[] {"rhino.ContinuationPending"})]
    [LineNumberTable(new byte[] {164, 53, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object resumeContinuation(
      object continuation,
      Scriptable scope,
      object functionResult)
    {
      object[] args = new object[1]{ functionResult };
      return Interpreter.restartContinuation((NativeContinuation) continuation, this, scope, args);
    }

    [LineNumberTable(new byte[] {164, 75, 98, 102, 167, 103, 140, 181, 2, 97, 226, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool stringIsCompilableUnit(string source)
    {
      int num = 0;
      CompilerEnvirons compilerEnv = new CompilerEnvirons();
      compilerEnv.initFromContext(this);
      compilerEnv.setGeneratingSource(false);
      Parser parser = new Parser(compilerEnv, (ErrorReporter) DefaultErrorReporter.instance);
      try
      {
        parser.parse(source, (string) null, 1);
        goto label_4;
      }
      catch (EvaluatorException ex)
      {
      }
      num = 1;
label_4:
      return num == 0 || !parser.eof();
    }

    [LineNumberTable(1319)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Function compileFunction(
      Scriptable scope,
      string source,
      string sourceName,
      int lineno,
      object securityDomain)
    {
      return this.compileFunction(scope, source, (Evaluator) null, (ErrorReporter) null, sourceName, lineno, securityDomain);
    }

    [LineNumberTable(new byte[] {164, 210, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public string decompileScript(Script script, int indent) => ((NativeFunction) script).decompile(indent, 0);

    [LineNumberTable(new byte[] {164, 227, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public string decompileFunction(Function fun, int indent) => fun is BaseFunction ? ((BaseFunction) fun).decompile(indent, 0) : new StringBuilder().append("function ").append(fun.getClassName()).append("() {\n\t[native code]\n}\n").toString();

    [LineNumberTable(new byte[] {164, 246, 104, 103, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public string decompileFunctionBody(Function fun, int indent) => fun is BaseFunction ? ((BaseFunction) fun).decompile(indent, 1) : "[native code]\n";

    [LineNumberTable(new byte[] {165, 7, 102, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable newObject(Scriptable scope)
    {
      NativeObject nativeObject = new NativeObject();
      ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeObject, scope, TopLevel.Builtins.__\u003C\u003EObject);
      return (Scriptable) nativeObject;
    }

    [LineNumberTable(1417)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable newObject(Scriptable scope, string constructorName) => this.newObject(scope, constructorName, ScriptRuntime.__\u003C\u003EemptyArgs);

    [LineNumberTable(new byte[] {165, 58, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable newArray(Scriptable scope, int length)
    {
      NativeArray nativeArray = new NativeArray((long) length);
      ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeArray, scope, TopLevel.Builtins.__\u003C\u003EArray);
      return (Scriptable) nativeArray;
    }

    [LineNumberTable(new byte[] {165, 74, 119, 107, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable newArray(Scriptable scope, object[] elements)
    {
      if (!object.ReferenceEquals((object) Object.instancehelper_getClass((object) elements).getComponentType(), (object) ScriptRuntime.__\u003C\u003EObjectClass))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      NativeArray nativeArray = new NativeArray(elements);
      ScriptRuntime.setBuiltinProtoAndParent((ScriptableObject) nativeArray, scope, TopLevel.Builtins.__\u003C\u003EArray);
      return (Scriptable) nativeArray;
    }

    [LineNumberTable(1494)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object[] getElements(Scriptable @object) => ScriptRuntime.getArrayElements(@object);

    [LineNumberTable(1506)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool toBoolean(object value) => ScriptRuntime.toBoolean(value);

    [LineNumberTable(1520)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static double toNumber(object value) => ScriptRuntime.toNumber(value);

    [LineNumberTable(1533)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string toString(object value) => ScriptRuntime.toString(value);

    [LineNumberTable(1553)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable toObject(object value, Scriptable scope) => ScriptRuntime.toObject(scope, value);

    [Obsolete]
    [Signature("(Ljava/lang/Object;Lrhino/Scriptable;Ljava/lang/Class<*>;)Lrhino/Scriptable;")]
    [LineNumberTable(1563)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable toObject(object value, Scriptable scope, Class staticType) => ScriptRuntime.toObject(scope, value);

    [LineNumberTable(new byte[] {165, 200, 159, 1, 98, 104, 145, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object javaToJS(object value, Scriptable scope)
    {
      switch (value)
      {
        case string _:
        case Number _:
        case Boolean _:
        case Scriptable _:
          return value;
        case Character _:
          return (object) String.valueOf(((Character) value).charValue());
        default:
          Context context = Context.getContext();
          return context.getWrapFactory().wrap(context, scope, value, (Class) null);
      }
    }

    [Throws(new string[] {"java.lang.IllegalArgumentException"})]
    [Obsolete]
    [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {165, 238, 125, 97})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object toType(object value, Class desiredType)
    {
      object java;
      EvaluatorException evaluatorException1;
      try
      {
        java = Context.jsToJava(value, desiredType);
      }
      catch (EvaluatorException ex)
      {
        evaluatorException1 = (EvaluatorException) ByteCodeHelper.MapException<EvaluatorException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return java;
label_3:
      EvaluatorException evaluatorException2 = evaluatorException1;
      string message = evaluatorException2.getMessage();
      EvaluatorException evaluatorException3 = evaluatorException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(message, (Exception) evaluatorException3);
    }

    [LineNumberTable(new byte[] {166, 4, 104, 175, 104, 102, 102, 103, 172, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException throwAsScriptRuntimeEx(Exception e)
    {
      while (e is InvocationTargetException)
        e = ((InvocationTargetException) e).getTargetException();
      if (e is Error)
      {
        Context context = Context.getContext();
        if (context == null || !context.hasFeature(13))
          throw Throwable.__\u003Cunmap\u003E(e);
      }
      Exception exception = !(e is RhinoException) ? e : throw Throwable.__\u003Cunmap\u003E(e);
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new WrappedException(exception);
    }

    [LineNumberTable(new byte[] {157, 233, 162, 109, 103, 108, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setGeneratingDebug(bool generatingDebug)
    {
      int num = generatingDebug ? 1 : 0;
      if (this.@sealed)
        Context.onSealedMutation();
      this.generatingDebugChanged = true;
      if (num != 0 && this.getOptimizationLevel() > 0)
        this.setOptimizationLevel(0);
      this.generatingDebug = num != 0;
    }

    [LineNumberTable(new byte[] {157, 226, 98, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setGeneratingSource(bool generatingSource)
    {
      int num = generatingSource ? 1 : 0;
      if (this.@sealed)
        Context.onSealedMutation();
      this.generatingSource = num != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int getMaximumInterpreterStackDepth() => this.maximumInterpreterStackDepth;

    [LineNumberTable(new byte[] {166, 152, 109, 105, 144, 100, 144, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setMaximumInterpreterStackDepth(int max)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (this.optimizationLevel != -1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Cannot set maximumInterpreterStackDepth when optimizationLevel != -1");
      }
      if (max < 1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Cannot set maximumInterpreterStackDepth to less than 1");
      }
      this.maximumInterpreterStackDepth = max;
    }

    [LineNumberTable(new byte[] {166, 174, 109, 110, 104, 144, 103, 144, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setSecurityController(SecurityController controller)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (controller == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (this.securityController != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SecurityException("Can not overwrite existing SecurityController object");
      }
      if (SecurityController.hasGlobal())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SecurityException("Can not overwrite existing global SecurityController object");
      }
      this.securityController = controller;
    }

    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    internal ClassShutter getClassShutter() => this.classShutter;

    [LineNumberTable(new byte[] {166, 215, 104, 98, 103})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public Context.ClassShutterSetter getClassShutterSetter()
    {
      if (this.hasClassShutter)
        return (Context.ClassShutterSetter) null;
      this.hasClassShutter = true;
      return (Context.ClassShutterSetter) new Context.\u0031(this);
    }

    [LineNumberTable(new byte[] {166, 248, 104, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public object getThreadLocal(object key) => this.threadLocalMap == null ? (object) null : this.threadLocalMap.get(key);

    [LineNumberTable(new byte[] {167, 4, 109, 104, 107, 110})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public void putThreadLocal(object key, object value)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (this.threadLocalMap == null)
        this.threadLocalMap = (Map) new HashMap();
      this.threadLocalMap.put(key, value);
    }

    [LineNumberTable(new byte[] {167, 16, 109, 104, 97, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void removeThreadLocal(object key)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (this.threadLocalMap == null)
        return;
      this.threadLocalMap.remove(key);
    }

    [Obsolete]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setCachingEnabled(bool cachingEnabled)
    {
    }

    [LineNumberTable(new byte[] {167, 40, 109, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setWrapFactory(WrapFactory wrapFactory)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (wrapFactory == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.wrapFactory = wrapFactory;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public Debugger getDebugger() => this.debugger;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public object getDebuggerContextData() => this.debuggerData;

    [LineNumberTable(new byte[] {167, 81, 109, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setDebugger(Debugger debugger, object contextData)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      this.debugger = debugger;
      this.debuggerData = contextData;
    }

    [LineNumberTable(new byte[] {167, 92, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static DebuggableScript getDebuggableView(Script script) => script is NativeFunction ? ((NativeFunction) script).getDebuggableView() : (DebuggableScript) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int getInstructionObserverThreshold() => this.instructionThreshold;

    [LineNumberTable(new byte[] {167, 156, 109, 111, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setInstructionObserverThreshold(int threshold)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (threshold < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.instructionThreshold = threshold;
      this.setGenerateObserverCount(threshold > 0);
    }

    [LineNumberTable(new byte[] {167, 196, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void observeInstructionCount(int instructionCount) => this.getFactory().observeInstructionCount(this, instructionCount);

    [LineNumberTable(new byte[] {167, 206, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GeneratedClassLoader createClassLoader(ClassLoader parent) => this.getFactory().createClassLoader(parent);

    [LineNumberTable(new byte[] {167, 211, 107, 103, 103, 131, 107, 100, 231, 69, 226, 69, 103, 109, 142, 177, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClassLoader getApplicationClassLoader()
    {
      if (this.applicationClassLoader == null)
      {
        ContextFactory factory = this.getFactory();
        ClassLoader classLoader = factory.getApplicationClassLoader();
        if (classLoader == null)
        {
          ClassLoader contextClassLoader = Thread.currentThread().getContextClassLoader();
          if (contextClassLoader != null && Kit.testIfCanLoadRhinoClasses(contextClassLoader))
            return contextClassLoader;
          Class @class = Object.instancehelper_getClass((object) factory);
          classLoader = object.ReferenceEquals((object) @class, (object) ScriptRuntime.__\u003C\u003EContextFactoryClass) ? Object.instancehelper_getClass((object) this).getClassLoader(Context.__\u003CGetCallerID\u003E()) : @class.getClassLoader(Context.__\u003CGetCallerID\u003E());
        }
        this.applicationClassLoader = classLoader;
      }
      return this.applicationClassLoader;
    }

    [LineNumberTable(new byte[] {167, 241, 109, 131, 103, 129, 104, 176, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setApplicationClassLoader(ClassLoader loader)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (loader == null)
      {
        this.applicationClassLoader = (ClassLoader) null;
      }
      else
      {
        if (!Kit.testIfCanLoadRhinoClasses(loader))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Loader can not resolve Rhino classes");
        }
        this.applicationClassLoader = loader;
      }
    }

    [LineNumberTable(new byte[] {168, 160, 104, 139, 99, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual RegExpProxy getRegExpProxy()
    {
      if (this.regExpProxy == null)
      {
        Class @class = Kit.classOrNull("rhino.regexp.RegExpImpl");
        if (@class != null)
          this.regExpProxy = (RegExpProxy) Kit.newInstanceOrNull(@class);
      }
      return this.regExpProxy;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal bool isVersionECMA1() => this.version == 200 || this.version >= 130;

    [LineNumberTable(new byte[] {168, 193, 109, 104, 107, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addActivationName(string name)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (this.activationNames == null)
        this.activationNames = (Set) new HashSet();
      this.activationNames.add((object) name);
    }

    [LineNumberTable(2368)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isActivationNeeded(string name) => this.activationNames != null && this.activationNames.contains((object) name);

    [LineNumberTable(new byte[] {168, 215, 109, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeActivationName(string name)
    {
      if (this.@sealed)
        Context.onSealedMutation();
      if (this.activationNames == null)
        return;
      this.activationNames.remove((object) name);
    }

    [LineNumberTable(new byte[] {159, 58, 141, 234, 167, 143, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Context()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.Context"))
        return;
      Context.__\u003C\u003EemptyArgs = ScriptRuntime.__\u003C\u003EemptyArgs;
      Context.codegenClass = Kit.classOrNull("rhino.optimizer.Codegen");
      Context.interpreterClass = Kit.classOrNull("rhino.Interpreter");
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Context.__\u003CcallerID\u003E == null)
        Context.__\u003CcallerID\u003E = (CallerID) new Context.__\u003CCallerID\u003E();
      return Context.__\u003CcallerID\u003E;
    }

    [Modifiers]
    public static object[] emptyArgs
    {
      [HideFromJava] get => Context.__\u003C\u003EemptyArgs;
    }

    [EnclosingMethod(null, "getClassShutterSetter", "()Lrhino.Context$ClassShutterSetter;")]
    [SpecialName]
    internal class \u0031 : Object, Context.ClassShutterSetter
    {
      [Modifiers]
      internal Context this\u00240;

      [LineNumberTable(1868)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Context obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {166, 222, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setClassShutter([In] ClassShutter obj0) => Context.access\u0024002(this.this\u00240, obj0);

      [LineNumberTable(1877)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ClassShutter getClassShutter() => Context.access\u0024000(this.this\u00240);
    }

    public interface ClassShutterSetter
    {
      void setClassShutter(ClassShutter cs);

      ClassShutter getClassShutter();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : ContextAction
    {
      private readonly Callable arg\u00241;
      private readonly Scriptable arg\u00242;
      private readonly Scriptable arg\u00243;
      private readonly object[] arg\u00244;

      internal __\u003C\u003EAnon0([In] Callable obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public object run([In] Context obj0) => Context.lambda\u0024call\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, obj0);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
