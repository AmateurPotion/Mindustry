// Decompiled with JetBrains decompiler
// Type: rhino.optimizer.ClassCompiler
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using rhino.ast;
using System.Runtime.CompilerServices;

namespace rhino.optimizer
{
  public class ClassCompiler : Object
  {
    private string mainMethodClassName;
    [Modifiers]
    private CompilerEnvirons compilerEnv;
    [Signature("Ljava/lang/Class<*>;")]
    private Class targetExtends;
    [Signature("[Ljava/lang/Class<*>;")]
    private Class[] targetImplements;

    [Signature("()Ljava/lang/Class<*>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class getTargetExtends() => this.targetExtends;

    [Signature("()[Ljava/lang/Class<*>;")]
    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class[] getTargetImplements() => this.targetImplements == null ? (Class[]) null : (Class[]) this.targetImplements.Clone();

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string makeAuxiliaryClassName(string mainClassName, string auxMarker) => new StringBuilder().append(mainClassName).append(auxMarker).toString();

    [LineNumberTable(new byte[] {159, 160, 104, 110, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClassCompiler(CompilerEnvirons compilerEnv)
    {
      ClassCompiler classCompiler = this;
      if (compilerEnv == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      this.compilerEnv = compilerEnv;
      this.mainMethodClassName = "rhino.optimizer.OptRuntime";
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMainMethodClass(string className) => this.mainMethodClassName = className;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getMainMethodClass() => this.mainMethodClassName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CompilerEnvirons getCompilerEnv() => this.compilerEnv;

    [Signature("(Ljava/lang/Class<*>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTargetExtends(Class extendsClass) => this.targetExtends = extendsClass;

    [Signature("([Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {30, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTargetImplements(Class[] implementsClasses) => this.targetImplements = implementsClasses != null ? (Class[]) implementsClasses.Clone() : (Class[]) null;

    [LineNumberTable(new byte[] {61, 108, 106, 108, 200, 104, 136, 110, 100, 134, 175, 103, 109, 140, 38, 199, 100, 145, 104, 105, 105, 106, 105, 109, 240, 60, 232, 71, 100, 135, 106, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] compileToClassFiles(
      string source,
      string sourceLocation,
      int lineno,
      string mainClassName)
    {
      ScriptNode scriptOrFn = new IRFactory(this.compilerEnv).transformTree(new Parser(this.compilerEnv).parse(source, sourceLocation, lineno));
      Class superClass = this.getTargetExtends();
      Class[] targetImplements = this.getTargetImplements();
      int num = targetImplements != null || superClass != null ? 0 : 1;
      string str = num == 0 ? this.makeAuxiliaryClassName(mainClassName, "1") : mainClassName;
      Codegen codegen = new Codegen();
      codegen.setMainMethodClass(this.mainMethodClassName);
      byte[] classFile = codegen.compileToClassFile(this.compilerEnv, str, scriptOrFn, scriptOrFn.getEncodedSource(), false);
      if (num != 0)
        return new object[2]
        {
          (object) str,
          (object) classFile
        };
      int functionCount = scriptOrFn.getFunctionCount();
      ObjToIntMap functionNames = new ObjToIntMap(functionCount);
      for (int i = 0; i != functionCount; ++i)
      {
        FunctionNode functionNode = scriptOrFn.getFunctionNode(i);
        string name = functionNode.getName();
        if (name != null && String.instancehelper_length(name) != 0)
          functionNames.put((object) name, functionNode.getParamCount());
      }
      if (superClass == null)
        superClass = ScriptRuntime.__\u003C\u003EObjectClass;
      byte[] adapterCode = JavaAdapter.createAdapterCode(functionNames, mainClassName, superClass, targetImplements, str);
      return new object[4]
      {
        (object) mainClassName,
        (object) adapterCode,
        (object) str,
        (object) classFile
      };
    }
  }
}
