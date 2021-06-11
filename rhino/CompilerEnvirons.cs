// Decompiled with JetBrains decompiler
// Type: rhino.CompilerEnvirons
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using rhino.ast;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class CompilerEnvirons : Object
  {
    private ErrorReporter errorReporter;
    private int languageVersion;
    private bool generateDebugInfo;
    private bool reservedKeywordAsIdentifier;
    private bool allowMemberExprAsFunctionName;
    private bool xmlAvailable;
    private int optimizationLevel;
    private bool generatingSource;
    private bool strictMode;
    private bool warningAsError;
    private bool generateObserverCount;
    private bool recordingComments;
    private bool recordingLocalJsDocComments;
    private bool recoverFromErrors;
    private bool warnTrailingComma;
    private bool ideMode;
    private bool allowSharpComments;
    [Signature("Ljava/util/Set<Ljava/lang/String;>;")]
    internal Set activationNames;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int getLanguageVersion() => this.languageVersion;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isGenerateDebugInfo() => this.generateDebugInfo;

    [LineNumberTable(new byte[] {2, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setErrorReporter(ErrorReporter errorReporter)
    {
      if (errorReporter == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.errorReporter = errorReporter;
    }

    [LineNumberTable(new byte[] {159, 150, 104, 107, 107, 103, 103, 103, 103, 103, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CompilerEnvirons()
    {
      CompilerEnvirons compilerEnvirons = this;
      this.errorReporter = (ErrorReporter) DefaultErrorReporter.instance;
      this.languageVersion = 200;
      this.generateDebugInfo = true;
      this.reservedKeywordAsIdentifier = true;
      this.allowMemberExprAsFunctionName = false;
      this.xmlAvailable = true;
      this.optimizationLevel = 0;
      this.generatingSource = true;
      this.strictMode = false;
      this.warningAsError = false;
      this.generateObserverCount = false;
      this.allowSharpComments = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRecoverFromErrors(bool recover) => this.recoverFromErrors = recover;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRecordingComments(bool record) => this.recordingComments = record;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStrictMode(bool strict) => this.strictMode = strict;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWarnTrailingComma(bool warn) => this.warnTrailingComma = warn;

    [LineNumberTable(new byte[] {11, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLanguageVersion(int languageVersion)
    {
      Context.checkLanguageVersion(languageVersion);
      this.languageVersion = languageVersion;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setReservedKeywordAsIdentifier(bool flag) => this.reservedKeywordAsIdentifier = flag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIdeMode(bool ide) => this.ideMode = ide;

    [LineNumberTable(new byte[] {159, 166, 108, 108, 106, 112, 99, 106, 99, 106, 100, 106, 110, 99, 138, 140, 108, 172, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void initFromContext(Context cx)
    {
      this.setErrorReporter(cx.getErrorReporter());
      this.languageVersion = cx.getLanguageVersion();
      this.generateDebugInfo = !cx.isGeneratingDebugChanged() || cx.isGeneratingDebug();
      this.reservedKeywordAsIdentifier = cx.hasFeature(3);
      this.allowMemberExprAsFunctionName = cx.hasFeature(2);
      this.strictMode = cx.hasFeature(11);
      this.warningAsError = cx.hasFeature(12);
      this.xmlAvailable = cx.hasFeature(6);
      this.optimizationLevel = cx.getOptimizationLevel();
      this.generatingSource = cx.isGeneratingSource();
      this.activationNames = cx.activationNames;
      this.generateObserverCount = cx.generateObserverCount;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public ErrorReporter getErrorReporter() => this.errorReporter;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setGenerateDebugInfo(bool flag) => this.generateDebugInfo = flag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isReservedKeywordAsIdentifier() => this.reservedKeywordAsIdentifier;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isAllowMemberExprAsFunctionName() => this.allowMemberExprAsFunctionName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAllowMemberExprAsFunctionName(bool flag) => this.allowMemberExprAsFunctionName = flag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isXmlAvailable() => this.xmlAvailable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setXmlAvailable(bool flag) => this.xmlAvailable = flag;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int getOptimizationLevel() => this.optimizationLevel;

    [LineNumberTable(new byte[] {56, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOptimizationLevel(int level)
    {
      Context.checkOptimizationLevel(level);
      this.optimizationLevel = level;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isGeneratingSource() => this.generatingSource;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getWarnTrailingComma() => this.warnTrailingComma;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isStrictMode() => this.strictMode;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool reportWarningAsError() => this.warningAsError;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setGeneratingSource(bool generatingSource) => this.generatingSource = generatingSource;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isGenerateObserverCount() => this.generateObserverCount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setGenerateObserverCount(bool generateObserverCount) => this.generateObserverCount = generateObserverCount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRecordingComments() => this.recordingComments;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isRecordingLocalJsDocComments() => this.recordingLocalJsDocComments;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRecordingLocalJsDocComments(bool record) => this.recordingLocalJsDocComments = record;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool recoverFromErrors() => this.recoverFromErrors;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isIdeMode() => this.ideMode;

    [Signature("()Ljava/util/Set<Ljava/lang/String;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Set getActivationNames() => this.activationNames;

    [Signature("(Ljava/util/Set<Ljava/lang/String;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setActivationNames(Set activationNames) => this.activationNames = activationNames;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAllowSharpComments(bool allow) => this.allowSharpComments = allow;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getAllowSharpComments() => this.allowSharpComments;

    [LineNumberTable(new byte[] {160, 122, 102, 103, 103, 103, 103, 107, 103, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static CompilerEnvirons ideEnvirons()
    {
      CompilerEnvirons compilerEnvirons = new CompilerEnvirons();
      compilerEnvirons.setRecoverFromErrors(true);
      compilerEnvirons.setRecordingComments(true);
      compilerEnvirons.setStrictMode(true);
      compilerEnvirons.setWarnTrailingComma(true);
      compilerEnvirons.setLanguageVersion(170);
      compilerEnvirons.setReservedKeywordAsIdentifier(true);
      compilerEnvirons.setIdeMode(true);
      compilerEnvirons.setErrorReporter((ErrorReporter) new ErrorCollector());
      return compilerEnvirons;
    }
  }
}
