// Decompiled with JetBrains decompiler
// Type: rhino.InterpreterData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using rhino.debug;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal sealed class InterpreterData : Object, DebuggableScript
  {
    internal const int INITIAL_MAX_ICODE_LENGTH = 1024;
    internal const int INITIAL_STRINGTABLE_SIZE = 64;
    internal const int INITIAL_NUMBERTABLE_SIZE = 64;
    internal string itsName;
    internal string itsSourceFile;
    internal bool itsNeedsActivation;
    internal int itsFunctionType;
    internal string[] itsStringTable;
    internal double[] itsDoubleTable;
    internal InterpreterData[] itsNestedFunctions;
    internal object[] itsRegExpLiterals;
    internal byte[] itsICode;
    internal int[] itsExceptionTable;
    internal int itsMaxVars;
    internal int itsMaxLocals;
    internal int itsMaxStack;
    internal int itsMaxFrameArray;
    internal string[] argNames;
    internal bool[] argIsConst;
    internal int argCount;
    internal int itsMaxCalleeArgs;
    internal string encodedSource;
    internal int encodedSourceStart;
    internal int encodedSourceEnd;
    internal int languageVersion;
    internal bool isStrict;
    internal bool topLevel;
    internal bool isES6Generator;
    internal object[] literalIds;
    internal UintMap longJumps;
    internal int firstLinePC;
    internal InterpreterData parentData;
    internal bool evalScriptFlag;
    private int icodeHashCode;
    internal bool declaredAsVar;
    internal bool declaredAsFunctionExpression;

    [LineNumberTable(new byte[] {159, 139, 99, 232, 126, 231, 70, 231, 159, 189, 103, 103, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal InterpreterData([In] int obj0, [In] string obj1, [In] string obj2, [In] bool obj3)
    {
      int num = obj3 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      InterpreterData interpreterData = this;
      this.firstLinePC = -1;
      this.icodeHashCode = 0;
      this.languageVersion = obj0;
      this.itsSourceFile = obj1;
      this.encodedSource = obj2;
      this.isStrict = num != 0;
      this.init();
    }

    [LineNumberTable(new byte[] {159, 163, 232, 118, 231, 70, 231, 5, 103, 108, 108, 108, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal InterpreterData([In] InterpreterData obj0)
    {
      InterpreterData interpreterData = this;
      this.firstLinePC = -1;
      this.icodeHashCode = 0;
      this.parentData = obj0;
      this.languageVersion = obj0.languageVersion;
      this.itsSourceFile = obj0.itsSourceFile;
      this.encodedSource = obj0.encodedSource;
      this.isStrict = obj0.isStrict;
      this.init();
    }

    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFunctionCount() => this.itsNestedFunctions == null ? 0 : this.itsNestedFunctions.Length;

    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual DebuggableScript getFunction([In] int obj0) => (DebuggableScript) this.itsNestedFunctions[obj0];

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFunctionName() => this.itsName;

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getParamAndVarCount() => this.argNames.Length;

    [LineNumberTable(120)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getParamOrVarConst([In] int obj0) => this.argIsConst[obj0];

    [LineNumberTable(new byte[] {104, 103, 99, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int icodeHashCode()
    {
      int num = this.icodeHashCode;
      if (num == 0)
        this.icodeHashCode = num = Arrays.hashCode(this.itsICode);
      return num;
    }

    [LineNumberTable(new byte[] {159, 173, 112, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void init()
    {
      this.itsICode = new byte[1024];
      this.itsStringTable = new string[64];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTopLevel() => this.topLevel;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isFunction() => this.itsFunctionType != 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getParamCount() => this.argCount;

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getParamOrVarName([In] int obj0) => this.argNames[obj0];

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSourceName() => this.itsSourceFile;

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isGeneratedScript() => ScriptRuntime.isGeneratedScript(this.itsSourceFile);

    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int[] getLineNumbers() => Interpreter.getLineNumbers(this);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual DebuggableScript getParent() => (DebuggableScript) this.parentData;
  }
}
