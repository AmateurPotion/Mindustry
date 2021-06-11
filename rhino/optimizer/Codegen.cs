// Decompiled with JetBrains decompiler
// Type: rhino.optimizer.Codegen
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using rhino.ast;
using rhino.classfile;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.optimizer
{
  public class Codegen : Object, Evaluator
  {
    internal const string DEFAULT_MAIN_METHOD_CLASS = "rhino.optimizer.OptRuntime";
    private const string SUPER_CLASS_NAME = "rhino.NativeFunction";
    internal const string ID_FIELD_NAME = "_id";
    internal const string REGEXP_INIT_METHOD_NAME = "_reInit";
    internal const string REGEXP_INIT_METHOD_SIGNATURE = "(Lrhino/Context;)V";
    internal const string FUNCTION_INIT_SIGNATURE = "(Lrhino/Context;Lrhino/Scriptable;)V";
    internal const string FUNCTION_CONSTRUCTOR_SIGNATURE = "(Lrhino/Scriptable;Lrhino/Context;I)V";
    [Modifiers]
    private static object globalLock;
    private static int globalSerialClassCounter;
    private CompilerEnvirons compilerEnv;
    private ObjArray directCallTargets;
    internal ScriptNode[] scriptOrFnNodes;
    private ObjToIntMap scriptOrFnIndexes;
    private string mainMethodClass;
    internal string mainClassName;
    internal string mainClassSignature;
    private double[] itsConstantList;
    private int itsConstantListSize;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 231, 112, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isGenerator([In] ScriptNode obj0) => obj0.getType() == 110 && ((FunctionNode) obj0).isGenerator();

    [LineNumberTable(1108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getBodyMethodName([In] ScriptNode obj0) => new StringBuilder().append("_c_").append(this.cleanName(obj0)).append("_").append(this.getIndex(obj0)).toString();

    [LineNumberTable(new byte[] {163, 248, 102, 105, 109, 172, 106, 103, 104, 108, 102, 44, 230, 69, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getBodyMethodSignature([In] ScriptNode obj0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append('(');
      stringBuilder.append(this.mainClassSignature);
      stringBuilder.append("Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;");
      if (obj0.getType() == 110)
      {
        OptFunctionNode optFunctionNode = OptFunctionNode.get(obj0);
        if (optFunctionNode.isTargetOfDirectCall())
        {
          int paramCount = optFunctionNode.__\u003C\u003Efnode.getParamCount();
          for (int index = 0; index != paramCount; ++index)
            stringBuilder.append("Ljava/lang/Object;D");
        }
      }
      stringBuilder.append("[Ljava/lang/Object;)Ljava/lang/Object;");
      return stringBuilder.toString();
    }

    [LineNumberTable(1158)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static RuntimeException badTree()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException("Bad tree in codegen");
    }

    [LineNumberTable(new byte[] {163, 213, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void pushUndefined([In] ClassFileWriter obj0) => obj0.add(178, "rhino/Undefined", "instance", "Ljava/lang/Object;");

    [LineNumberTable(new byte[] {163, 137, 105, 144, 223, 0, 104, 171, 105, 223, 0, 109, 223, 0, 105, 223, 0, 237, 69, 104, 171, 103, 98, 99, 143, 103, 107, 134, 101, 105, 111, 167, 100, 106, 137, 123, 105, 180})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void pushNumberAsObject([In] ClassFileWriter obj0, [In] double obj1)
    {
      if (obj1 == 0.0)
      {
        if (1.0 / obj1 > 0.0)
        {
          obj0.add(178, "rhino/optimizer/OptRuntime", "zeroObj", "Ljava/lang/Double;");
        }
        else
        {
          obj0.addPush(obj1);
          Codegen.addDoubleWrap(obj0);
        }
      }
      else if (obj1 == 1.0)
        obj0.add(178, "rhino/optimizer/OptRuntime", "oneObj", "Ljava/lang/Double;");
      else if (obj1 == -1.0)
        obj0.add(178, "rhino/optimizer/OptRuntime", "minusOneObj", "Ljava/lang/Double;");
      else if (Double.isNaN(obj1))
        obj0.add(178, "rhino/ScriptRuntime", "NaNobj", "Ljava/lang/Double;");
      else if (this.itsConstantListSize >= 2000)
      {
        obj0.addPush(obj1);
        Codegen.addDoubleWrap(obj0);
      }
      else
      {
        int constantListSize = this.itsConstantListSize;
        int index = 0;
        if (constantListSize == 0)
        {
          this.itsConstantList = new double[64];
        }
        else
        {
          double[] itsConstantList = this.itsConstantList;
          while (index != constantListSize && itsConstantList[index] != obj1)
            ++index;
          if (constantListSize == itsConstantList.Length)
          {
            double[] numArray = new double[constantListSize * 2];
            ByteCodeHelper.arraycopy_primitive_8((Array) this.itsConstantList, 0, (Array) numArray, 0, constantListSize);
            this.itsConstantList = numArray;
          }
        }
        if (index == constantListSize)
        {
          this.itsConstantList[constantListSize] = obj1;
          this.itsConstantListSize = constantListSize + 1;
        }
        string fieldName = new StringBuilder().append("_k").append(index).toString();
        string constantWrapperType = Codegen.getStaticConstantWrapperType(obj1);
        obj0.add(178, this.mainClassName, fieldName, constantWrapperType);
      }
    }

    [LineNumberTable(1154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getCompiledRegexpName([In] ScriptNode obj0, [In] int obj1) => new StringBuilder().append("_re").append(this.getIndex(obj0)).append("_").append(obj1).toString();

    [LineNumberTable(1100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int getIndex([In] ScriptNode obj0) => this.scriptOrFnIndexes.getExisting((object) obj0);

    [LineNumberTable(1104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getDirectCtorName([In] ScriptNode obj0) => new StringBuilder().append("_n").append(this.getIndex(obj0)).toString();

    [LineNumberTable(new byte[] {159, 160, 232, 164, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Codegen()
    {
      Codegen codegen = this;
      this.mainMethodClass = "rhino.optimizer.OptRuntime";
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMainMethodClass(string className) => this.mainMethodClass = className;

    [LineNumberTable(new byte[] {159, 109, 67, 135, 231, 70, 99, 169, 135, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] compileToClassFile(
      CompilerEnvirons compilerEnv,
      string mainClassName,
      ScriptNode scriptOrFn,
      string encodedSource,
      bool returnFunction)
    {
      int num = returnFunction ? 1 : 0;
      this.compilerEnv = compilerEnv;
      this.transform(scriptOrFn);
      if (num != 0)
        scriptOrFn = (ScriptNode) scriptOrFn.getFunctionNode(0);
      this.initScriptNodesData(scriptOrFn);
      this.mainClassName = mainClassName;
      this.mainClassSignature = ClassFileWriter.classNameToSignature(mainClassName);
      return this.generateCode(encodedSource);
    }

    [Signature("(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {56, 108, 105, 206, 145, 201, 107, 105, 127, 12, 98, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Class defineClass([In] object obj0, [In] object obj1)
    {
      object[] objArray = (object[]) obj0;
      string str1 = (string) objArray[0];
      byte[] barr = (byte[]) objArray[1];
      GeneratedClassLoader loader = SecurityController.createLoader(Object.instancehelper_getClass((object) this).getClassLoader(Codegen.__\u003CGetCallerID\u003E()), obj1);
      Class @class;
      SecurityException securityException1;
      IllegalArgumentException argumentException;
      try
      {
        try
        {
          Class c = loader.defineClass(str1, barr);
          loader.linkClass(c);
          @class = c;
        }
        catch (SecurityException ex)
        {
          securityException1 = (SecurityException) ByteCodeHelper.MapException<SecurityException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_5;
        }
      }
      catch (IllegalArgumentException ex)
      {
        argumentException = (IllegalArgumentException) ByteCodeHelper.MapException<IllegalArgumentException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_6;
      }
      return @class;
label_5:
      SecurityException securityException2 = securityException1;
      goto label_7;
label_6:
      securityException2 = (SecurityException) argumentException;
label_7:
      RuntimeException runtimeException = (RuntimeException) securityException2;
      string str2 = new StringBuilder().append("Malformed optimizer package ").append((object) runtimeException).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(str2);
    }

    [LineNumberTable(new byte[] {103, 134, 140, 98, 231, 70, 112, 103, 102, 105, 143, 110, 105, 99, 134, 235, 55, 230, 80, 99, 171, 142, 142, 100, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void transform([In] ScriptNode obj0)
    {
      Codegen.initOptFunctions_r(obj0);
      int optimizationLevel = this.compilerEnv.getOptimizationLevel();
      HashMap hashMap = (HashMap) null;
      if (optimizationLevel > 0 && obj0.getType() == 137)
      {
        int functionCount = obj0.getFunctionCount();
        for (int i = 0; i != functionCount; ++i)
        {
          OptFunctionNode optFunctionNode = OptFunctionNode.get(obj0, i);
          if (optFunctionNode.__\u003C\u003Efnode.getFunctionType() == 1)
          {
            string name = optFunctionNode.__\u003C\u003Efnode.getName();
            if (String.instancehelper_length(name) != 0)
            {
              if (hashMap == null)
                hashMap = new HashMap();
              ((Map) hashMap).put((object) name, (object) optFunctionNode);
            }
          }
        }
      }
      if (hashMap != null)
        this.directCallTargets = new ObjArray();
      new OptTransformer((Map) hashMap, this.directCallTargets).transform(obj0, this.compilerEnv);
      if (optimizationLevel <= 0)
        return;
      new Optimizer().optimize(obj0);
    }

    [LineNumberTable(new byte[] {160, 90, 102, 135, 103, 108, 140, 108, 102, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initScriptNodesData([In] ScriptNode obj0)
    {
      ObjArray objArray = new ObjArray();
      Codegen.collectScriptNodes_r(obj0, objArray);
      int keyCountHint = objArray.size();
      this.scriptOrFnNodes = new ScriptNode[keyCountHint];
      objArray.toArray((object[]) this.scriptOrFnNodes);
      this.scriptOrFnIndexes = new ObjToIntMap(keyCountHint);
      for (int index = 0; index != keyCountHint; ++index)
        this.scriptOrFnIndexes.put((object) this.scriptOrFnNodes[index], index);
    }

    [LineNumberTable(new byte[] {160, 113, 117, 114, 142, 98, 109, 174, 184, 146, 99, 168, 99, 108, 104, 104, 168, 105, 136, 137, 105, 108, 139, 103, 105, 104, 109, 105, 137, 135, 107, 105, 106, 105, 234, 48, 235, 85, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private byte[] generateCode([In] string obj0)
    {
      int num1 = this.scriptOrFnNodes[0].getType() == 137 ? 1 : 0;
      int num2 = this.scriptOrFnNodes.Length > 1 || num1 == 0 ? 1 : 0;
      int num3 = this.scriptOrFnNodes[0].isInStrictMode() ? 1 : 0;
      string sourceFileName = (string) null;
      if (this.compilerEnv.isGenerateDebugInfo())
        sourceFileName = this.scriptOrFnNodes[0].getSourceName();
      ClassFileWriter.__\u003Cclinit\u003E();
      ClassFileWriter classFileWriter = new ClassFileWriter(this.mainClassName, "rhino.NativeFunction", sourceFileName);
      classFileWriter.addField("_id", "I", (short) 2);
      if (num2 != 0)
        this.generateFunctionConstructor(classFileWriter);
      if (num1 != 0)
      {
        classFileWriter.addInterface("rhino/Script");
        this.generateScriptCtor(classFileWriter);
        this.generateMain(classFileWriter);
        this.generateExecute(classFileWriter);
      }
      this.generateCallMethod(classFileWriter, num3 != 0);
      this.generateResumeGenerator(classFileWriter);
      this.generateNativeFunctionOverrides(classFileWriter, obj0);
      int length = this.scriptOrFnNodes.Length;
      for (int index = 0; index != length; ++index)
      {
        ScriptNode scriptOrFnNode = this.scriptOrFnNodes[index];
        new BodyCodegen()
        {
          cfw = classFileWriter,
          codegen = this,
          compilerEnv = this.compilerEnv,
          scriptOrFn = scriptOrFnNode,
          scriptOrFnIndex = index
        }.generateBodyCode();
        if (scriptOrFnNode.getType() == 110)
        {
          OptFunctionNode optFunctionNode = OptFunctionNode.get(scriptOrFnNode);
          this.generateFunctionInit(classFileWriter, optFunctionNode);
          if (optFunctionNode.isTargetOfDirectCall())
            this.emitDirectConstructor(classFileWriter, optFunctionNode);
        }
      }
      this.emitRegExpInit(classFileWriter);
      this.emitConstantDudeInitializers(classFileWriter);
      return classFileWriter.toByteArray();
    }

    [LineNumberTable(new byte[] {160, 82, 109, 104, 103, 230, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void initOptFunctions_r([In] ScriptNode obj0)
    {
      int i = 0;
      for (int functionCount = obj0.getFunctionCount(); i != functionCount; ++i)
      {
        FunctionNode functionNode = obj0.getFunctionNode(i);
        OptFunctionNode optFunctionNode = new OptFunctionNode(functionNode);
        Codegen.initOptFunctions_r((ScriptNode) functionNode);
      }
    }

    [LineNumberTable(new byte[] {160, 105, 103, 103, 102, 45, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void collectScriptNodes_r([In] ScriptNode obj0, [In] ObjArray obj1)
    {
      obj1.add((object) obj0);
      int functionCount = obj0.getFunctionCount();
      for (int i = 0; i != functionCount; ++i)
        Codegen.collectScriptNodes_r((ScriptNode) obj0.getFunctionNode(i), obj1);
    }

    [LineNumberTable(new byte[] {161, 232, 98, 98, 130, 113, 103, 186, 102, 103, 155, 102, 103, 135, 117, 104, 111, 138, 98, 99, 99, 167, 173, 107, 99, 101, 103, 138, 207, 112, 143, 10, 197, 235, 49, 235, 83, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateFunctionConstructor([In] ClassFileWriter obj0)
    {
      obj0.startMethod("<init>", "(Lrhino/Scriptable;Lrhino/Context;I)V", (short) 1);
      obj0.addALoad(0);
      obj0.addInvoke(183, "rhino.NativeFunction", "<init>", "()V");
      obj0.addLoadThis();
      obj0.addILoad(3);
      obj0.add(181, obj0.getClassName(), "_id", "I");
      obj0.addLoadThis();
      obj0.addALoad(2);
      obj0.addALoad(1);
      int num1 = this.scriptOrFnNodes[0].getType() == 137 ? 1 : 0;
      int length = this.scriptOrFnNodes.Length;
      if (num1 == length)
        throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
      int num2 = 2 <= length - num1 ? 1 : 0;
      int switchStart = 0;
      int stackTop = 0;
      if (num2 != 0)
      {
        obj0.addILoad(3);
        switchStart = obj0.addTableSwitch(num1 + 1, length - 1);
      }
      for (int index = num1; index != length; ++index)
      {
        if (num2 != 0)
        {
          if (index == num1)
          {
            obj0.markTableSwitchDefault(switchStart);
            stackTop = (int) obj0.getStackTop();
          }
          else
            obj0.markTableSwitchCase(switchStart, index - 1 - num1, stackTop);
        }
        OptFunctionNode optFunctionNode = OptFunctionNode.get(this.scriptOrFnNodes[index]);
        obj0.addInvoke(183, this.mainClassName, this.getFunctionInitMethodName(optFunctionNode), "(Lrhino/Context;Lrhino/Scriptable;)V");
        obj0.add(177);
      }
      obj0.stopMethod((short) 4);
    }

    [LineNumberTable(new byte[] {161, 216, 145, 102, 186, 102, 103, 155, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateScriptCtor([In] ClassFileWriter obj0)
    {
      obj0.startMethod("<init>", "()V", (short) 1);
      obj0.addLoadThis();
      obj0.addInvoke(183, "rhino.NativeFunction", "<init>", "()V");
      obj0.addLoadThis();
      obj0.addPush(0);
      obj0.add(181, obj0.getClassName(), "_id", "I");
      obj0.add(177);
      obj0.stopMethod((short) 1);
    }

    [LineNumberTable(new byte[] {161, 166, 210, 113, 104, 187, 136, 219, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateMain([In] ClassFileWriter obj0)
    {
      obj0.startMethod("main", "([Ljava/lang/String;)V", (short) 9);
      obj0.add(187, obj0.getClassName());
      obj0.add(89);
      obj0.addInvoke(183, obj0.getClassName(), "<init>", "()V");
      obj0.add(42);
      obj0.addInvoke(184, this.mainMethodClass, "main", "(Lrhino/Script;[Ljava/lang/String;)V");
      obj0.add(177);
      obj0.stopMethod((short) 1);
    }

    [LineNumberTable(new byte[] {161, 187, 242, 70, 98, 130, 102, 103, 103, 104, 103, 103, 47, 229, 73, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateExecute([In] ClassFileWriter obj0)
    {
      obj0.startMethod("exec", "(Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;", (short) 17);
      obj0.addLoadThis();
      obj0.addALoad(1);
      obj0.addALoad(2);
      obj0.add(89);
      obj0.add(1);
      obj0.addInvoke(182, obj0.getClassName(), "call", "(Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;[Ljava/lang/Object;)Ljava/lang/Object;");
      obj0.add(176);
      obj0.stopMethod((short) 3);
    }

    [LineNumberTable(new byte[] {159, 36, 98, 242, 76, 103, 103, 250, 69, 108, 103, 103, 103, 103, 103, 103, 250, 74, 107, 167, 103, 103, 103, 103, 135, 104, 136, 99, 99, 99, 102, 187, 172, 107, 107, 99, 100, 104, 138, 206, 110, 105, 108, 110, 167, 108, 107, 104, 104, 104, 141, 103, 104, 104, 109, 104, 102, 136, 103, 139, 231, 46, 235, 87, 143, 104, 229, 61, 197, 235, 19, 235, 111, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateCallMethod([In] ClassFileWriter obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      obj0.startMethod("call", "(Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;[Ljava/lang/Object;)Ljava/lang/Object;", (short) 17);
      int num2 = obj0.acquireLabel();
      obj0.addALoad(1);
      obj0.addInvoke(184, "rhino/ScriptRuntime", "hasTopCall", "(Lrhino/Context;)Z");
      obj0.add(154, num2);
      obj0.addALoad(0);
      obj0.addALoad(1);
      obj0.addALoad(2);
      obj0.addALoad(3);
      obj0.addALoad(4);
      obj0.addPush(num1 != 0);
      obj0.addInvoke(184, "rhino/ScriptRuntime", "doTopCall", "(Lrhino/Callable;Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;[Ljava/lang/Object;Z)Ljava/lang/Object;");
      obj0.add(176);
      obj0.markLabel(num2);
      obj0.addALoad(0);
      obj0.addALoad(1);
      obj0.addALoad(2);
      obj0.addALoad(3);
      obj0.addALoad(4);
      int length = this.scriptOrFnNodes.Length;
      int num3 = 2 <= length ? 1 : 0;
      int switchStart = 0;
      int stackTop = 0;
      if (num3 != 0)
      {
        obj0.addLoadThis();
        obj0.add(180, obj0.getClassName(), "_id", "I");
        switchStart = obj0.addTableSwitch(1, length - 1);
      }
      for (int index = 0; index != length; ++index)
      {
        ScriptNode scriptOrFnNode = this.scriptOrFnNodes[index];
        if (num3 != 0)
        {
          if (index == 0)
          {
            obj0.markTableSwitchDefault(switchStart);
            stackTop = (int) obj0.getStackTop();
          }
          else
            obj0.markTableSwitchCase(switchStart, index - 1, stackTop);
        }
        if (scriptOrFnNode.getType() == 110)
        {
          OptFunctionNode optFunctionNode = OptFunctionNode.get(scriptOrFnNode);
          if (optFunctionNode.isTargetOfDirectCall())
          {
            int paramCount = optFunctionNode.__\u003C\u003Efnode.getParamCount();
            if (paramCount != 0)
            {
              for (int k = 0; k != paramCount; ++k)
              {
                obj0.add(190);
                obj0.addPush(k);
                int num4 = obj0.acquireLabel();
                int num5 = obj0.acquireLabel();
                obj0.add(164, num4);
                obj0.addALoad(4);
                obj0.addPush(k);
                obj0.add(50);
                obj0.add(167, num5);
                obj0.markLabel(num4);
                Codegen.pushUndefined(obj0);
                obj0.markLabel(num5);
                obj0.adjustStackTop(-1);
                obj0.addPush(0.0);
                obj0.addALoad(4);
              }
            }
          }
        }
        obj0.addInvoke(184, this.mainClassName, this.getBodyMethodName(scriptOrFnNode), this.getBodyMethodSignature(scriptOrFnNode));
        obj0.add(176);
      }
      obj0.stopMethod((short) 5);
    }

    [LineNumberTable(new byte[] {160, 248, 98, 108, 111, 2, 230, 71, 99, 129, 242, 72, 103, 103, 103, 103, 103, 135, 102, 155, 113, 103, 135, 111, 106, 105, 105, 255, 12, 70, 148, 27, 197, 107, 98, 236, 48, 233, 84, 103, 102, 203, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateResumeGenerator([In] ClassFileWriter obj0)
    {
      int num1 = 0;
      for (int index = 0; index < this.scriptOrFnNodes.Length; ++index)
      {
        if (Codegen.isGenerator(this.scriptOrFnNodes[index]))
          num1 = 1;
      }
      if (num1 == 0)
        return;
      obj0.startMethod("resumeGenerator", "(Lrhino/Context;Lrhino/Scriptable;ILjava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;", (short) 17);
      obj0.addALoad(0);
      obj0.addALoad(1);
      obj0.addALoad(2);
      obj0.addALoad(4);
      obj0.addALoad(5);
      obj0.addILoad(3);
      obj0.addLoadThis();
      obj0.add(180, obj0.getClassName(), "_id", "I");
      int switchStart = obj0.addTableSwitch(0, this.scriptOrFnNodes.Length - 1);
      obj0.markTableSwitchDefault(switchStart);
      int num2 = obj0.acquireLabel();
      for (int caseIndex = 0; caseIndex < this.scriptOrFnNodes.Length; ++caseIndex)
      {
        ScriptNode scriptOrFnNode = this.scriptOrFnNodes[caseIndex];
        obj0.markTableSwitchCase(switchStart, caseIndex, 6);
        if (Codegen.isGenerator(scriptOrFnNode))
        {
          string methodType = new StringBuilder().append("(").append(this.mainClassSignature).append("Lrhino/Context;Lrhino/Scriptable;Ljava/lang/Object;Ljava/lang/Object;I)Ljava/lang/Object;").toString();
          obj0.addInvoke(184, this.mainClassName, new StringBuilder().append(this.getBodyMethodName(scriptOrFnNode)).append("_gen").toString(), methodType);
          obj0.add(176);
        }
        else
          obj0.add(167, num2);
      }
      obj0.markLabel(num2);
      Codegen.pushUndefined(obj0);
      obj0.add(176);
      obj0.stopMethod((short) 6);
    }

    [LineNumberTable(new byte[] {162, 65, 145, 113, 171, 231, 69, 98, 98, 98, 98, 98, 98, 98, 130, 105, 103, 229, 73, 159, 8, 98, 145, 133, 98, 145, 133, 98, 145, 133, 98, 145, 130, 98, 145, 130, 98, 145, 103, 130, 98, 145, 130, 171, 136, 98, 99, 164, 102, 219, 171, 107, 107, 100, 100, 103, 170, 237, 69, 191, 8, 110, 141, 110, 136, 107, 197, 109, 107, 197, 109, 107, 229, 69, 105, 196, 103, 112, 165, 110, 176, 167, 141, 105, 110, 107, 100, 138, 173, 104, 235, 54, 232, 77, 229, 69, 105, 105, 196, 103, 112, 165, 106, 176, 167, 141, 105, 110, 100, 138, 173, 107, 235, 55, 232, 76, 197, 105, 148, 135, 107, 226, 69, 109, 109, 218, 107, 162, 235, 159, 122, 235, 160, 138, 231, 159, 51, 233, 160, 207})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateNativeFunctionOverrides([In] ClassFileWriter obj0, [In] string obj1)
    {
      obj0.startMethod("getLanguageVersion", "()I", (short) 1);
      obj0.addPush(this.compilerEnv.getLanguageVersion());
      obj0.add(172);
      obj0.stopMethod((short) 1);
      for (int index1 = 0; index1 != 7; ++index1)
      {
        if (index1 != 4 || obj1 != null)
        {
          int num;
          switch (index1)
          {
            case 0:
              num = 1;
              obj0.startMethod("getFunctionName", "()Ljava/lang/String;", (short) 1);
              break;
            case 1:
              num = 1;
              obj0.startMethod("getParamCount", "()I", (short) 1);
              break;
            case 2:
              num = 1;
              obj0.startMethod("getParamAndVarCount", "()I", (short) 1);
              break;
            case 3:
              num = 2;
              obj0.startMethod("getParamOrVarName", "(I)Ljava/lang/String;", (short) 1);
              break;
            case 4:
              num = 1;
              obj0.startMethod("getEncodedSource", "()Ljava/lang/String;", (short) 1);
              obj0.addPush(obj1);
              break;
            case 5:
              num = 3;
              obj0.startMethod("getParamOrVarConst", "(I)Z", (short) 1);
              break;
            case 6:
              num = 1;
              obj0.startMethod("isGeneratorFunction", "()Z", (short) 4);
              break;
            default:
              throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
          }
          int length = this.scriptOrFnNodes.Length;
          int switchStart1 = 0;
          int stackTop = 0;
          if (length > 1)
          {
            obj0.addLoadThis();
            obj0.add(180, obj0.getClassName(), "_id", "I");
            switchStart1 = obj0.addTableSwitch(1, length - 1);
          }
          for (int index2 = 0; index2 != length; ++index2)
          {
            ScriptNode scriptOrFnNode = this.scriptOrFnNodes[index2];
            if (index2 == 0)
            {
              if (length > 1)
              {
                obj0.markTableSwitchDefault(switchStart1);
                stackTop = (int) obj0.getStackTop();
              }
            }
            else
              obj0.markTableSwitchCase(switchStart1, index2 - 1, stackTop);
            switch (index1)
            {
              case 0:
                if (scriptOrFnNode.getType() == 137)
                {
                  obj0.addPush("");
                }
                else
                {
                  string name = ((FunctionNode) scriptOrFnNode).getName();
                  obj0.addPush(name);
                }
                obj0.add(176);
                break;
              case 1:
                obj0.addPush(scriptOrFnNode.getParamCount());
                obj0.add(172);
                break;
              case 2:
                obj0.addPush(scriptOrFnNode.getParamAndVarCount());
                obj0.add(172);
                break;
              case 3:
                int paramAndVarCount1 = scriptOrFnNode.getParamAndVarCount();
                switch (paramAndVarCount1)
                {
                  case 0:
                    obj0.add(1);
                    obj0.add(176);
                    continue;
                  case 1:
                    obj0.addPush(scriptOrFnNode.getParamOrVarName(0));
                    obj0.add(176);
                    continue;
                  default:
                    obj0.addILoad(1);
                    int switchStart2 = obj0.addTableSwitch(1, paramAndVarCount1 - 1);
                    for (int index3 = 0; index3 != paramAndVarCount1; ++index3)
                    {
                      if (obj0.getStackTop() != (short) 0)
                        Kit.codeBug();
                      string paramOrVarName = scriptOrFnNode.getParamOrVarName(index3);
                      if (index3 == 0)
                        obj0.markTableSwitchDefault(switchStart2);
                      else
                        obj0.markTableSwitchCase(switchStart2, index3 - 1, 0);
                      obj0.addPush(paramOrVarName);
                      obj0.add(176);
                    }
                    continue;
                }
              case 4:
                obj0.addPush(scriptOrFnNode.getEncodedSourceStart());
                obj0.addPush(scriptOrFnNode.getEncodedSourceEnd());
                obj0.addInvoke(182, "java/lang/String", "substring", "(II)Ljava/lang/String;");
                obj0.add(176);
                break;
              case 5:
                int paramAndVarCount2 = scriptOrFnNode.getParamAndVarCount();
                bool[] paramAndVarConst = scriptOrFnNode.getParamAndVarConst();
                switch (paramAndVarCount2)
                {
                  case 0:
                    obj0.add(3);
                    obj0.add(172);
                    continue;
                  case 1:
                    obj0.addPush(paramAndVarConst[0]);
                    obj0.add(172);
                    continue;
                  default:
                    obj0.addILoad(1);
                    int switchStart3 = obj0.addTableSwitch(1, paramAndVarCount2 - 1);
                    for (int index3 = 0; index3 != paramAndVarCount2; ++index3)
                    {
                      if (obj0.getStackTop() != (short) 0)
                        Kit.codeBug();
                      if (index3 == 0)
                        obj0.markTableSwitchDefault(switchStart3);
                      else
                        obj0.markTableSwitchCase(switchStart3, index3 - 1, 0);
                      obj0.addPush(paramAndVarConst[index3]);
                      obj0.add(172);
                    }
                    continue;
                }
              case 6:
                if (scriptOrFnNode is FunctionNode)
                  obj0.addPush(((FunctionNode) scriptOrFnNode).isES6Generator());
                else
                  obj0.addPush(false);
                obj0.add(172);
                break;
              default:
                throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
            }
          }
          obj0.stopMethod((short) num);
        }
      }
    }

    [LineNumberTable(new byte[] {162, 31, 98, 98, 244, 69, 102, 103, 103, 250, 72, 109, 103, 219, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateFunctionInit([In] ClassFileWriter obj0, [In] OptFunctionNode obj1)
    {
      obj0.startMethod(this.getFunctionInitMethodName(obj1), "(Lrhino/Context;Lrhino/Scriptable;)V", (short) 18);
      obj0.addLoadThis();
      obj0.addALoad(1);
      obj0.addALoad(2);
      obj0.addInvoke(182, "rhino/NativeFunction", "initScriptFunction", "(Lrhino/Context;Lrhino/Scriptable;)V");
      if (obj1.__\u003C\u003Efnode.getRegexpCount() != 0)
      {
        obj0.addALoad(1);
        obj0.addInvoke(184, this.mainClassName, "_reInit", "(Lrhino/Context;)V");
      }
      obj0.add(177);
      obj0.stopMethod((short) 3);
    }

    [LineNumberTable(new byte[] {160, 184, 116, 39, 197, 108, 136, 103, 103, 103, 250, 70, 135, 103, 103, 103, 103, 102, 107, 11, 198, 107, 147, 108, 229, 61, 197, 103, 104, 112, 140, 112, 107, 135, 103, 139, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void emitDirectConstructor([In] ClassFileWriter obj0, [In] OptFunctionNode obj1)
    {
      obj0.startMethod(this.getDirectCtorName((ScriptNode) obj1.__\u003C\u003Efnode), this.getBodyMethodSignature((ScriptNode) obj1.__\u003C\u003Efnode), (short) 10);
      int paramCount = obj1.__\u003C\u003Efnode.getParamCount();
      int local = 4 + paramCount * 3 + 1;
      obj0.addALoad(0);
      obj0.addALoad(1);
      obj0.addALoad(2);
      obj0.addInvoke(182, "rhino/BaseFunction", "createObject", "(Lrhino/Context;Lrhino/Scriptable;)Lrhino/Scriptable;");
      obj0.addAStore(local);
      obj0.addALoad(0);
      obj0.addALoad(1);
      obj0.addALoad(2);
      obj0.addALoad(local);
      for (int index = 0; index < paramCount; ++index)
      {
        obj0.addALoad(4 + index * 3);
        obj0.addDLoad(5 + index * 3);
      }
      obj0.addALoad(4 + paramCount * 3);
      obj0.addInvoke(184, this.mainClassName, this.getBodyMethodName((ScriptNode) obj1.__\u003C\u003Efnode), this.getBodyMethodSignature((ScriptNode) obj1.__\u003C\u003Efnode));
      int num = obj0.acquireLabel();
      obj0.add(89);
      obj0.add(193, "rhino/Scriptable");
      obj0.add(153, num);
      obj0.add(192, "rhino/Scriptable");
      obj0.add(176);
      obj0.markLabel(num);
      obj0.addALoad(local);
      obj0.add(176);
      obj0.stopMethod((short) (local + 1));
    }

    [LineNumberTable(new byte[] {163, 41, 98, 108, 48, 166, 99, 161, 146, 146, 123, 103, 108, 107, 167, 103, 250, 69, 199, 111, 105, 104, 108, 107, 103, 106, 106, 140, 103, 103, 104, 100, 137, 136, 250, 70, 245, 43, 235, 61, 233, 93, 103, 123, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void emitRegExpInit([In] ClassFileWriter obj0)
    {
      int num1 = 0;
      for (int index = 0; index != this.scriptOrFnNodes.Length; ++index)
        num1 += this.scriptOrFnNodes[index].getRegexpCount();
      if (num1 == 0)
        return;
      obj0.startMethod("_reInit", "(Lrhino/Context;)V", (short) 10);
      obj0.addField("_reInitDone", "Z", (short) 74);
      obj0.add(178, this.mainClassName, "_reInitDone", "Z");
      int num2 = obj0.acquireLabel();
      obj0.add(153, num2);
      obj0.add(177);
      obj0.markLabel(num2);
      obj0.addALoad(0);
      obj0.addInvoke(184, "rhino/ScriptRuntime", "checkRegExpProxy", "(Lrhino/Context;)Lrhino/RegExpProxy;");
      obj0.addAStore(1);
      for (int index1 = 0; index1 != this.scriptOrFnNodes.Length; ++index1)
      {
        ScriptNode scriptOrFnNode = this.scriptOrFnNodes[index1];
        int regexpCount = scriptOrFnNode.getRegexpCount();
        for (int index2 = 0; index2 != regexpCount; ++index2)
        {
          string compiledRegexpName = this.getCompiledRegexpName(scriptOrFnNode, index2);
          string str = "Ljava/lang/Object;";
          string regexpString = scriptOrFnNode.getRegexpString(index2);
          string regexpFlags = scriptOrFnNode.getRegexpFlags(index2);
          obj0.addField(compiledRegexpName, str, (short) 10);
          obj0.addALoad(1);
          obj0.addALoad(0);
          obj0.addPush(regexpString);
          if (regexpFlags == null)
            obj0.add(1);
          else
            obj0.addPush(regexpFlags);
          obj0.addInvoke(185, "rhino/RegExpProxy", "compileRegExp", "(Lrhino/Context;Ljava/lang/String;Ljava/lang/String;)Ljava/lang/Object;");
          obj0.add(179, this.mainClassName, compiledRegexpName, str);
        }
      }
      obj0.addPush(1);
      obj0.add(179, this.mainClassName, "_reInitDone", "Z");
      obj0.add(177);
      obj0.stopMethod((short) 2);
    }

    [LineNumberTable(new byte[] {163, 106, 103, 99, 129, 146, 103, 105, 100, 124, 104, 140, 104, 102, 104, 188, 103, 134, 245, 49, 233, 83, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void emitConstantDudeInitializers([In] ClassFileWriter obj0)
    {
      int constantListSize = this.itsConstantListSize;
      if (constantListSize == 0)
        return;
      obj0.startMethod("<clinit>", "()V", (short) 24);
      double[] itsConstantList = this.itsConstantList;
      for (int index = 0; index != constantListSize; ++index)
      {
        double k1 = itsConstantList[index];
        string fieldName = new StringBuilder().append("_k").append(index).toString();
        string constantWrapperType = Codegen.getStaticConstantWrapperType(k1);
        obj0.addField(fieldName, constantWrapperType, (short) 10);
        int k2 = ByteCodeHelper.d2i(k1);
        if ((double) k2 == k1)
        {
          obj0.addPush(k2);
          obj0.addInvoke(184, "java/lang/Integer", "valueOf", "(I)Ljava/lang/Integer;");
        }
        else
        {
          obj0.addPush(k1);
          Codegen.addDoubleWrap(obj0);
        }
        obj0.add(179, this.mainClassName, fieldName, constantWrapperType);
      }
      obj0.add(177);
      obj0.stopMethod((short) 0);
    }

    [LineNumberTable(1150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string getFunctionInitMethodName([In] OptFunctionNode obj0) => new StringBuilder().append("_i").append(this.getIndex((ScriptNode) obj0.__\u003C\u003Efnode)).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string getStaticConstantWrapperType([In] double obj0) => (double) ByteCodeHelper.d2i(obj0) == obj0 ? "Ljava/lang/Integer;" : "Ljava/lang/Double;";

    [LineNumberTable(new byte[] {163, 199, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void addDoubleWrap([In] ClassFileWriter obj0) => obj0.addInvoke(184, "rhino/optimizer/OptRuntime", "wrapDouble", "(D)Ljava/lang/Double;");

    [LineNumberTable(new byte[] {163, 234, 104, 108, 99, 136, 135, 98, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string cleanName([In] ScriptNode obj0)
    {
      string str;
      if (obj0 is FunctionNode)
      {
        Name functionName = ((FunctionNode) obj0).getFunctionName();
        str = functionName != null ? functionName.getIdentifier() : "anonymous";
      }
      else
        str = "script";
      return str;
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void captureStackInfo(RhinoException ex)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSourcePositionFromStack(Context cx, int[] linep)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getPatchedStack(RhinoException ex, string nativeStackTrace)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("(Lrhino/RhinoException;)Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getScriptStack(RhinoException ex)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEvalScriptFlag(Script script)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(new byte[] {159, 130, 131, 108, 110, 143, 102, 110, 118, 110, 219, 159, 13, 206})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object compile(
      CompilerEnvirons compilerEnv,
      ScriptNode tree,
      string encodedSource,
      bool returnFunction)
    {
      int num1 = returnFunction ? 1 : 0;
      int num2;
      lock (Codegen.globalLock)
        num2 = ++Codegen.globalSerialClassCounter;
      string str = "c";
      if (String.instancehelper_length(tree.getSourceName()) > 0)
      {
        str = String.instancehelper_replaceAll(tree.getSourceName(), "\\W", "_");
        if (!Character.isJavaIdentifierStart(String.instancehelper_charAt(str, 0)))
          str = new StringBuilder().append("_").append(str).toString();
      }
      string mainClassName = new StringBuilder().append("rhino.gen.").append(str).append("_").append(num2).toString();
      byte[] classFile = this.compileToClassFile(compilerEnv, mainClassName, tree, encodedSource, num1 != 0);
      return (object) new object[2]
      {
        (object) mainClassName,
        (object) classFile
      };
    }

    [LineNumberTable(new byte[] {24, 201, 223, 9, 226, 61, 97, 112, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Script createScriptObject(object bytecode, object staticSecurityDomain)
    {
      Class @class = this.defineClass(bytecode, staticSecurityDomain);
      Exception exception1;
      try
      {
        return (Script) @class.newInstance(Codegen.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      string str = new StringBuilder().append("Unable to instantiate compiled class:").append(Throwable.instancehelper_toString((Exception) exception2)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(str);
    }

    [LineNumberTable(new byte[] {40, 202, 110, 120, 223, 12, 226, 61, 98, 113, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Function createFunctionObject(
      Context cx,
      Scriptable scope,
      object bytecode,
      object staticSecurityDomain)
    {
      Class @class = this.defineClass(bytecode, staticSecurityDomain);
      Exception exception1;
      try
      {
        return (Function) @class.getConstructors(Codegen.__\u003CGetCallerID\u003E())[0].newInstance(new object[3]
        {
          (object) scope,
          (object) cx,
          (object) Integer.valueOf(0)
        }, Codegen.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      string str = new StringBuilder().append("Unable to instantiate compiled class:").append(Throwable.instancehelper_toString((Exception) exception2)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(str);
    }

    [LineNumberTable(1186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Codegen()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.optimizer.Codegen"))
        return;
      Codegen.globalLock = (object) new Object();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Codegen.__\u003CcallerID\u003E == null)
        Codegen.__\u003CcallerID\u003E = (CallerID) new Codegen.__\u003CCallerID\u003E();
      return Codegen.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
