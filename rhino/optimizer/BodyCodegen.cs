// Decompiled with JetBrains decompiler
// Type: rhino.optimizer.BodyCodegen
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
  [SourceFile("Codegen.java")]
  internal class BodyCodegen : Object
  {
    private const int JAVASCRIPT_EXCEPTION = 0;
    private const int EVALUATOR_EXCEPTION = 1;
    private const int ECMAERROR_EXCEPTION = 2;
    private const int THROWABLE_EXCEPTION = 3;
    private const int FINALLY_EXCEPTION = 4;
    private const int EXCEPTION_MAX = 5;
    [Modifiers]
    private BodyCodegen.ExceptionManager exceptionManager;
    internal const int GENERATOR_TERMINATE = -1;
    internal const int GENERATOR_START = 0;
    internal const int GENERATOR_YIELD_START = 1;
    internal ClassFileWriter cfw;
    internal Codegen codegen;
    internal CompilerEnvirons compilerEnv;
    internal ScriptNode scriptOrFn;
    public int scriptOrFnIndex;
    private int savedCodeOffset;
    private OptFunctionNode fnCurrent;
    private const int MAX_LOCALS = 1024;
    private int[] locals;
    private short firstFreeLocal;
    private short localsMax;
    private int itsLineNumber;
    private bool hasVarsInRegs;
    private short[] varRegisters;
    private bool inDirectCallFunction;
    private bool itsForcedObjectParameters;
    private int enterAreaStartLabel;
    private int epilogueLabel;
    private bool inLocalBlock;
    private short variableObjectLocal;
    private short popvLocal;
    private short contextLocal;
    private short argsLocal;
    private short operationLocal;
    private short thisObjLocal;
    private short funObjLocal;
    private short itsZeroArgArray;
    private short itsOneArgArray;
    private short generatorStateLocal;
    private bool isGenerator;
    private int generatorSwitch;
    private int maxLocals;
    private int maxStack;
    [Signature("Ljava/util/Map<Lrhino/Node;Lrhino/optimizer/BodyCodegen$FinallyReturnPoint;>;")]
    private Map finallys;
    [Signature("Ljava/util/List<Lrhino/Node;>;")]
    private List literals;
    private int unnestedYieldCount;
    [Modifiers]
    [Signature("Ljava/util/IdentityHashMap<Lrhino/Node;Ljava/lang/String;>;")]
    private IdentityHashMap unnestedYields;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(1205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Node access\u0024000([In] BodyCodegen obj0, [In] Node obj1) => obj0.getFinallyAtTarget(obj1);

    [Modifiers]
    [LineNumberTable(1205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string access\u0024100([In] BodyCodegen obj0, [In] int obj1) => obj0.exceptionTypeToName(obj1);

    [LineNumberTable(new byte[] {174, 188, 99, 102, 100, 102, 100, 102, 100, 102, 100, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string exceptionTypeToName([In] int obj0)
    {
      switch (obj0)
      {
        case 0:
          return "rhino/JavaScriptException";
        case 1:
          return "rhino/EvaluatorException";
        case 2:
          return "rhino/EcmaError";
        case 3:
          return "java/lang/Throwable";
        case 4:
          return (string) null;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [LineNumberTable(new byte[] {175, 210, 99, 130, 106, 130, 109, 103, 109, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node getFinallyAtTarget([In] Node obj0)
    {
      if (obj0 == null)
        return (Node) null;
      if (obj0.getType() == 126)
        return obj0;
      Node node = obj0.getType() == 132 ? obj0.getNext() : throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug("bad finally target"));
      if (node != null && node.getType() == 126)
        return node;
    }

    [LineNumberTable(new byte[] {164, 205, 103, 114, 113, 124, 104, 113, 99, 172, 113, 152, 103, 103, 167, 144, 103, 103, 103, 103, 103, 135, 103, 103, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initBodyGeneration()
    {
      this.varRegisters = (short[]) null;
      if (this.scriptOrFn.getType() == 110)
      {
        this.fnCurrent = OptFunctionNode.get(this.scriptOrFn);
        this.hasVarsInRegs = !this.fnCurrent.__\u003C\u003Efnode.requiresActivation();
        if (this.hasVarsInRegs)
        {
          int paramAndVarCount = this.fnCurrent.__\u003C\u003Efnode.getParamAndVarCount();
          if (paramAndVarCount != 0)
            this.varRegisters = new short[paramAndVarCount];
        }
        this.inDirectCallFunction = this.fnCurrent.isTargetOfDirectCall();
        if (this.inDirectCallFunction && !this.hasVarsInRegs)
          Codegen.badTree();
      }
      else
      {
        this.fnCurrent = (OptFunctionNode) null;
        this.hasVarsInRegs = false;
        this.inDirectCallFunction = false;
      }
      this.locals = new int[1024];
      this.funObjLocal = (short) 0;
      this.contextLocal = (short) 1;
      this.variableObjectLocal = (short) 2;
      this.thisObjLocal = (short) 3;
      this.localsMax = (short) 4;
      this.firstFreeLocal = (short) 4;
      this.popvLocal = (short) -1;
      this.argsLocal = (short) -1;
      this.itsZeroArgArray = (short) -1;
      this.itsOneArgArray = (short) -1;
      this.epilogueLabel = -1;
      this.enterAreaStartLabel = -1;
      this.generatorStateLocal = (short) -1;
    }

    [LineNumberTable(new byte[] {164, 245, 107, 236, 69, 111, 102, 142, 239, 61, 230, 69, 144, 103, 105, 105, 108, 223, 0, 108, 113, 110, 102, 108, 236, 52, 233, 81, 136, 113, 223, 0, 209, 127, 0, 172, 171, 127, 0, 236, 70, 113, 127, 0, 108, 117, 109, 113, 223, 0, 145, 105, 177, 114, 132, 166, 106, 39, 138, 233, 70, 117, 113, 255, 6, 69, 109, 230, 69, 104, 129, 139, 108, 178, 113, 112, 108, 108, 113, 113, 108, 176, 113, 172, 113, 113, 210, 99, 107, 99, 101, 107, 104, 113, 109, 109, 146, 111, 109, 112, 143, 109, 101, 107, 134, 141, 141, 101, 103, 108, 159, 2, 203, 112, 116, 157, 109, 101, 139, 243, 23, 235, 110, 193, 98, 109, 148, 107, 103, 113, 113, 113, 113, 118, 237, 70, 113, 113, 113, 208, 98, 103, 113, 113, 113, 113, 108, 240, 73, 113, 113, 145, 166, 109, 147, 11, 229, 69, 136, 108, 107, 145, 108, 100, 141, 101, 109, 108, 191, 0, 145, 109, 108, 108, 117, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generatePrologue()
    {
      if (this.inDirectCallFunction)
      {
        int paramCount = this.scriptOrFn.getParamCount();
        if (this.firstFreeLocal != (short) 4)
          Kit.codeBug();
        for (int index = 0; index != paramCount; ++index)
        {
          this.varRegisters[index] = this.firstFreeLocal;
          this.firstFreeLocal += (short) 3;
        }
        if (!this.fnCurrent.getParameterNumberContext())
        {
          this.itsForcedObjectParameters = true;
          for (int index = 0; index != paramCount; ++index)
          {
            int varRegister = (int) this.varRegisters[index];
            this.cfw.addALoad(varRegister);
            this.cfw.add(178, "java/lang/Void", "TYPE", "Ljava/lang/Class;");
            int num = this.cfw.acquireLabel();
            this.cfw.add(166, num);
            this.cfw.addDLoad(varRegister + 1);
            this.addDoubleWrap();
            this.cfw.addAStore(varRegister);
            this.cfw.markLabel(num);
          }
        }
      }
      if (this.fnCurrent != null)
      {
        this.cfw.addALoad((int) this.funObjLocal);
        this.cfw.addInvoke(185, "rhino/Scriptable", "getParentScope", "()Lrhino/Scriptable;");
        this.cfw.addAStore((int) this.variableObjectLocal);
      }
      BodyCodegen bodyCodegen1 = this;
      int firstFreeLocal1 = (int) bodyCodegen1.firstFreeLocal;
      BodyCodegen bodyCodegen2 = bodyCodegen1;
      int num1 = firstFreeLocal1;
      bodyCodegen2.firstFreeLocal = (short) (firstFreeLocal1 + 1);
      this.argsLocal = (short) num1;
      this.localsMax = this.firstFreeLocal;
      if (this.isGenerator)
      {
        BodyCodegen bodyCodegen3 = this;
        int firstFreeLocal2 = (int) bodyCodegen3.firstFreeLocal;
        BodyCodegen bodyCodegen4 = bodyCodegen3;
        int num2 = firstFreeLocal2;
        bodyCodegen4.firstFreeLocal = (short) (firstFreeLocal2 + 1);
        this.operationLocal = (short) num2;
        this.localsMax = this.firstFreeLocal;
        this.cfw.addALoad((int) this.thisObjLocal);
        BodyCodegen bodyCodegen5 = this;
        int firstFreeLocal3 = (int) bodyCodegen5.firstFreeLocal;
        BodyCodegen bodyCodegen6 = bodyCodegen5;
        int num3 = firstFreeLocal3;
        bodyCodegen6.firstFreeLocal = (short) (firstFreeLocal3 + 1);
        this.generatorStateLocal = (short) num3;
        this.localsMax = this.firstFreeLocal;
        this.cfw.add(192, "rhino/optimizer/OptRuntime$GeneratorState");
        this.cfw.add(89);
        this.cfw.addAStore((int) this.generatorStateLocal);
        this.cfw.add(180, "rhino/optimizer/OptRuntime$GeneratorState", "thisObj", "Lrhino/Scriptable;");
        this.cfw.addAStore((int) this.thisObjLocal);
        if (this.epilogueLabel == -1)
          this.epilogueLabel = this.cfw.acquireLabel();
        List resumptionPoints = ((FunctionNode) this.scriptOrFn).getResumptionPoints();
        if (resumptionPoints != null)
        {
          this.generateGetGeneratorResumptionPoint();
          this.generatorSwitch = this.cfw.addTableSwitch(0, resumptionPoints.size() + 0);
          this.generateCheckForThrowOrClose(-1, false, 0);
        }
      }
      if (this.fnCurrent == null && this.scriptOrFn.getRegexpCount() != 0)
      {
        this.cfw.addALoad((int) this.contextLocal);
        this.cfw.addInvoke(184, this.codegen.mainClassName, "_reInit", "(Lrhino/Context;)V");
      }
      if (this.compilerEnv.isGenerateObserverCount())
        this.saveCurrentCodeOffset();
      if (this.isGenerator)
        return;
      if (this.hasVarsInRegs)
      {
        int paramCount1 = this.scriptOrFn.getParamCount();
        if (paramCount1 > 0 && !this.inDirectCallFunction)
        {
          this.cfw.addALoad((int) this.argsLocal);
          this.cfw.add(190);
          this.cfw.addPush(paramCount1);
          int num2 = this.cfw.acquireLabel();
          this.cfw.add(162, num2);
          this.cfw.addALoad((int) this.argsLocal);
          this.cfw.addPush(paramCount1);
          this.addScriptRuntimeInvoke("padArguments", "([Ljava/lang/Object;I)[Ljava/lang/Object;");
          this.cfw.addAStore((int) this.argsLocal);
          this.cfw.markLabel(num2);
        }
        int paramCount2 = this.fnCurrent.__\u003C\u003Efnode.getParamCount();
        int paramAndVarCount = this.fnCurrent.__\u003C\u003Efnode.getParamAndVarCount();
        bool[] paramAndVarConst = this.fnCurrent.__\u003C\u003Efnode.getParamAndVarConst();
        int local = -1;
        for (int index = 0; index != paramAndVarCount; ++index)
        {
          int num2 = -1;
          if (index < paramCount2)
          {
            if (!this.inDirectCallFunction)
            {
              num2 = (int) this.getNewWordLocal();
              this.cfw.addALoad((int) this.argsLocal);
              this.cfw.addPush(index);
              this.cfw.add(50);
              this.cfw.addAStore(num2);
            }
          }
          else if (this.fnCurrent.isNumberVar(index))
          {
            num2 = (int) this.getNewWordPairLocal(paramAndVarConst[index]);
            this.cfw.addPush(0.0);
            this.cfw.addDStore(num2);
          }
          else
          {
            num2 = (int) this.getNewWordLocal(paramAndVarConst[index]);
            if (local == -1)
            {
              Codegen.pushUndefined(this.cfw);
              local = num2;
            }
            else
              this.cfw.addALoad(local);
            this.cfw.addAStore(num2);
          }
          if (num2 >= 0)
          {
            if (paramAndVarConst[index])
            {
              this.cfw.addPush(0);
              this.cfw.addIStore(num2 + (!this.fnCurrent.isNumberVar(index) ? 1 : 2));
            }
            this.varRegisters[index] = (short) num2;
          }
          if (this.compilerEnv.isGenerateDebugInfo())
          {
            string paramOrVarName = this.fnCurrent.__\u003C\u003Efnode.getParamOrVarName(index);
            string type = !this.fnCurrent.isNumberVar(index) ? "Ljava/lang/Object;" : "D";
            int currentCodeOffset = this.cfw.getCurrentCodeOffset();
            if (num2 < 0)
              num2 = (int) this.varRegisters[index];
            this.cfw.addVariableDescriptor(paramOrVarName, type, currentCodeOffset, num2);
          }
        }
      }
      else
      {
        int num2 = 0;
        if (this.scriptOrFn is FunctionNode)
          num2 = ((FunctionNode) this.scriptOrFn).getFunctionType() == 4 ? 1 : 0;
        string name;
        if (this.fnCurrent != null)
        {
          name = "activation";
          this.cfw.addALoad((int) this.funObjLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.addALoad((int) this.argsLocal);
          string str = num2 == 0 ? "createFunctionActivation" : "createArrowFunctionActivation";
          this.cfw.addPush(this.scriptOrFn.isInStrictMode());
          this.addScriptRuntimeInvoke(str, "(Lrhino/NativeFunction;Lrhino/Scriptable;[Ljava/lang/Object;Z)Lrhino/Scriptable;");
          this.cfw.addAStore((int) this.variableObjectLocal);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("enterActivationFunction", "(Lrhino/Context;Lrhino/Scriptable;)V");
        }
        else
        {
          name = "global";
          this.cfw.addALoad((int) this.funObjLocal);
          this.cfw.addALoad((int) this.thisObjLocal);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.addPush(0);
          this.addScriptRuntimeInvoke("initScript", "(Lrhino/NativeFunction;Lrhino/Scriptable;Lrhino/Context;Lrhino/Scriptable;Z)V");
        }
        this.enterAreaStartLabel = this.cfw.acquireLabel();
        this.epilogueLabel = this.cfw.acquireLabel();
        this.cfw.markLabel(this.enterAreaStartLabel);
        this.generateNestedFunctionInits();
        if (this.compilerEnv.isGenerateDebugInfo())
          this.cfw.addVariableDescriptor(name, "Lrhino/Scriptable;", this.cfw.getCurrentCodeOffset(), (int) this.variableObjectLocal);
        if (this.fnCurrent == null)
        {
          this.popvLocal = this.getNewWordLocal();
          Codegen.pushUndefined(this.cfw);
          this.cfw.addAStore((int) this.popvLocal);
          int endLineno = this.scriptOrFn.getEndLineno();
          if (endLineno == -1)
            return;
          this.cfw.addLineNumberEntry((short) endLineno);
        }
        else
        {
          if (this.fnCurrent.itsContainsCalls0)
          {
            this.itsZeroArgArray = this.getNewWordLocal();
            this.cfw.add(178, "rhino/ScriptRuntime", "emptyArgs", "[Ljava/lang/Object;");
            this.cfw.addAStore((int) this.itsZeroArgArray);
          }
          if (!this.fnCurrent.itsContainsCalls1)
            return;
          this.itsOneArgArray = this.getNewWordLocal();
          this.cfw.addPush(1);
          this.cfw.add(189, "java/lang/Object");
          this.cfw.addAStore((int) this.itsOneArgArray);
        }
      }
    }

    [LineNumberTable(new byte[] {166, 144, 103, 103, 103, 255, 161, 4, 72, 173, 135, 102, 103, 233, 69, 103, 103, 103, 104, 108, 140, 104, 99, 103, 137, 104, 103, 103, 197, 104, 110, 110, 101, 143, 104, 235, 71, 109, 197, 140, 104, 99, 134, 104, 103, 104, 99, 174, 140, 109, 113, 145, 240, 72, 140, 165, 104, 109, 102, 102, 165, 109, 102, 114, 112, 197, 99, 106, 100, 141, 116, 145, 136, 166, 109, 102, 105, 115, 145, 118, 165, 109, 102, 109, 165, 104, 113, 113, 240, 70, 113, 108, 165, 113, 208, 113, 108, 229, 70, 104, 113, 113, 250, 71, 108, 240, 70, 114, 165, 170, 115, 173, 115, 119, 141, 104, 107, 146, 141, 165, 104, 105, 140, 113, 165, 109, 102, 104, 108, 109, 134, 229, 70, 109, 102, 110, 229, 72, 104, 165, 109, 166, 172, 135, 109, 109, 141, 102, 140, 99, 103, 169, 108, 117, 102, 115, 114, 183, 140, 104, 141, 162, 162, 171})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateStatement([In] Node obj0)
    {
      this.updateLineNumber(obj0);
      int type = obj0.getType();
      Node node = obj0.getFirstChild();
      switch (type)
      {
        case 2:
          this.generateExpression(node, obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("enterWith", "(Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Lrhino/Scriptable;");
          this.cfw.addAStore((int) this.variableObjectLocal);
          this.incReferenceWordLocal(this.variableObjectLocal);
          break;
        case 3:
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("leaveWith", "(Lrhino/Scriptable;)Lrhino/Scriptable;");
          this.cfw.addAStore((int) this.variableObjectLocal);
          this.decReferenceWordLocal(this.variableObjectLocal);
          break;
        case 4:
        case 65:
          if (node != null)
            this.generateExpression(node, obj0);
          else if (type == 4)
          {
            Codegen.pushUndefined(this.cfw);
          }
          else
          {
            if (this.popvLocal < (short) 0)
              throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
            this.cfw.addALoad((int) this.popvLocal);
          }
          if (this.isGenerator)
            this.generateSetGeneratorReturnValue();
          if (this.compilerEnv.isGenerateObserverCount())
            this.addInstructionCount();
          if (this.epilogueLabel == -1)
          {
            if (!this.hasVarsInRegs)
              throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
            this.epilogueLabel = this.cfw.acquireLabel();
          }
          this.cfw.add(167, this.epilogueLabel);
          break;
        case 5:
        case 6:
        case 7:
        case 136:
          if (this.compilerEnv.isGenerateObserverCount())
            this.addInstructionCount();
          this.visitGoto((Jump) obj0, type, node);
          break;
        case 50:
          this.generateExpression(node, obj0);
          if (this.compilerEnv.isGenerateObserverCount())
            this.addInstructionCount();
          this.generateThrowJavaScriptException();
          break;
        case 51:
          if (this.compilerEnv.isGenerateObserverCount())
            this.addInstructionCount();
          this.cfw.addALoad(this.getLocalBlockRegister(obj0));
          this.cfw.add(191);
          break;
        case 57:
          this.cfw.setStackTop((short) 0);
          int localBlockRegister = this.getLocalBlockRegister(obj0);
          int existingIntProp = obj0.getExistingIntProp(14);
          string k1 = node.getString();
          this.generateExpression(node.getNext(), obj0);
          if (existingIntProp == 0)
            this.cfw.add(1);
          else
            this.cfw.addALoad(localBlockRegister);
          this.cfw.addPush(k1);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("newCatchScope", "(Ljava/lang/Throwable;Lrhino/Scriptable;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Lrhino/Scriptable;");
          this.cfw.addAStore(localBlockRegister);
          break;
        case 58:
        case 59:
        case 60:
        case 61:
          this.generateExpression(node, obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          int k2;
          switch (type)
          {
            case 58:
              k2 = 0;
              break;
            case 59:
              k2 = 1;
              break;
            case 61:
              k2 = 6;
              break;
            default:
              k2 = 2;
              break;
          }
          this.cfw.addPush(k2);
          this.addScriptRuntimeInvoke("enumInit", "(Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;I)Ljava/lang/Object;");
          this.cfw.addAStore(this.getLocalBlockRegister(obj0));
          break;
        case 82:
          this.visitTryCatchFinally((Jump) obj0, node);
          break;
        case 110:
          OptFunctionNode optFunctionNode = OptFunctionNode.get(this.scriptOrFn, obj0.getExistingIntProp(1));
          int functionType = optFunctionNode.__\u003C\u003Efnode.getFunctionType();
          switch (functionType)
          {
            case 1:
              return;
            case 3:
              this.visitFunction(optFunctionNode, functionType);
              return;
            default:
              throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
          }
        case 115:
          if (this.compilerEnv.isGenerateObserverCount())
            this.addInstructionCount();
          this.visitSwitch((Jump) obj0, node);
          break;
        case 124:
        case 129:
        case 130:
        case 131:
        case 133:
        case 137:
          if (this.compilerEnv.isGenerateObserverCount())
            this.addInstructionCount(1);
          for (; node != null; node = node.getNext())
            this.generateStatement(node);
          break;
        case 126:
          if (!this.isGenerator)
            break;
          if (this.compilerEnv.isGenerateObserverCount())
            this.saveCurrentCodeOffset();
          this.cfw.setStackTop((short) 1);
          int newWordLocal1 = (int) this.getNewWordLocal();
          int label1 = this.cfw.acquireLabel();
          int label2 = this.cfw.acquireLabel();
          this.cfw.markLabel(label1);
          this.generateIntegerWrap();
          this.cfw.addAStore(newWordLocal1);
          for (; node != null; node = node.getNext())
            this.generateStatement(node);
          this.cfw.addALoad(newWordLocal1);
          this.cfw.add(192, "java/lang/Integer");
          this.generateIntegerUnwrap();
          BodyCodegen.FinallyReturnPoint finallyReturnPoint = (BodyCodegen.FinallyReturnPoint) this.finallys.get((object) obj0);
          finallyReturnPoint.tableLabel = this.cfw.acquireLabel();
          this.cfw.add(167, finallyReturnPoint.tableLabel);
          this.cfw.setStackTop((short) 0);
          this.releaseWordLocal((short) newWordLocal1);
          this.cfw.markLabel(label2);
          break;
        case 132:
          if (this.compilerEnv.isGenerateObserverCount())
            this.addInstructionCount();
          this.cfw.markLabel(this.getTargetLabel(obj0));
          if (!this.compilerEnv.isGenerateObserverCount())
            break;
          this.saveCurrentCodeOffset();
          break;
        case 134:
          if (node.getType() == 56)
          {
            this.visitSetVar(node, node.getFirstChild(), false);
            break;
          }
          if (node.getType() == 157)
          {
            this.visitSetConstVar(node, node.getFirstChild(), false);
            break;
          }
          if (node.getType() == 73 || node.getType() == 166)
          {
            this.generateYieldPoint(node, false);
            break;
          }
          this.generateExpression(node, obj0);
          if (obj0.getIntProp(8, -1) != -1)
          {
            this.cfw.add(88);
            break;
          }
          this.cfw.add(87);
          break;
        case 135:
          this.generateExpression(node, obj0);
          if (this.popvLocal < (short) 0)
            this.popvLocal = this.getNewWordLocal();
          this.cfw.addAStore((int) this.popvLocal);
          break;
        case 142:
          int num = this.inLocalBlock ? 1 : 0;
          this.inLocalBlock = true;
          int newWordLocal2 = (int) this.getNewWordLocal();
          if (this.isGenerator)
          {
            this.cfw.add(1);
            this.cfw.addAStore(newWordLocal2);
          }
          obj0.putIntProp(2, newWordLocal2);
          for (; node != null; node = node.getNext())
            this.generateStatement(node);
          this.releaseWordLocal((short) newWordLocal2);
          obj0.removeProp(2);
          this.inLocalBlock = num != 0;
          break;
        case 161:
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
      }
    }

    [LineNumberTable(new byte[] {166, 17, 109, 102, 139, 113, 102, 113, 110, 109, 110, 103, 110, 37, 133, 102, 106, 109, 109, 109, 240, 60, 232, 70, 109, 247, 50, 233, 84, 107, 127, 13, 120, 142, 179, 110, 39, 135, 99, 109, 147, 111, 116, 47, 133, 230, 59, 232, 72, 197, 105, 177, 107, 114, 209, 167, 113, 113, 176, 107, 149, 104, 149, 104, 113, 181, 102, 240, 69, 109, 109, 104, 205, 134, 109, 136, 176, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateEpilogue()
    {
      if (this.compilerEnv.isGenerateObserverCount())
        this.addInstructionCount();
      if (this.isGenerator)
      {
        Map liveLocals = ((FunctionNode) this.scriptOrFn).getLiveLocals();
        if (liveLocals != null)
        {
          List resumptionPoints = ((FunctionNode) this.scriptOrFn).getResumptionPoints();
          for (int index = 0; index < resumptionPoints.size(); ++index)
          {
            Node node = (Node) resumptionPoints.get(index);
            int[] numArray = (int[]) liveLocals.get((object) node);
            if (numArray != null)
            {
              this.cfw.markTableSwitchCase(this.generatorSwitch, this.getNextGeneratorState(node));
              this.generateGetGeneratorLocalsState();
              for (int k = 0; k < numArray.Length; ++k)
              {
                this.cfw.add(89);
                this.cfw.addLoadConstant(k);
                this.cfw.add(50);
                this.cfw.addAStore(numArray[k]);
              }
              this.cfw.add(87);
              this.cfw.add(167, this.getTargetLabel(node));
            }
          }
        }
        if (this.finallys != null)
        {
          Iterator iterator = this.finallys.entrySet().iterator();
label_14:
          while (iterator.hasNext())
          {
            Map.Entry entry = (Map.Entry) iterator.next();
            if (((Node) entry.getKey()).getType() == 126)
            {
              BodyCodegen.FinallyReturnPoint finallyReturnPoint = (BodyCodegen.FinallyReturnPoint) entry.getValue();
              this.cfw.markLabel(finallyReturnPoint.tableLabel, (short) 1);
              int switchStart = this.cfw.addTableSwitch(0, finallyReturnPoint.jsrPoints.size() - 1);
              int caseIndex = 0;
              this.cfw.markTableSwitchDefault(switchStart);
              int num = 0;
              while (true)
              {
                if (num < finallyReturnPoint.jsrPoints.size())
                {
                  this.cfw.markTableSwitchCase(switchStart, caseIndex);
                  this.cfw.add(167, ((Integer) finallyReturnPoint.jsrPoints.get(num)).intValue());
                  ++caseIndex;
                  ++num;
                }
                else
                  goto label_14;
              }
            }
          }
        }
      }
      if (this.epilogueLabel != -1)
        this.cfw.markLabel(this.epilogueLabel);
      if (this.isGenerator)
      {
        if (((FunctionNode) this.scriptOrFn).getResumptionPoints() != null)
          this.cfw.markTableSwitchDefault(this.generatorSwitch);
        this.generateSetGeneratorResumptionPoint(-1);
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.cfw.addALoad((int) this.generatorStateLocal);
        this.addOptRuntimeInvoke("throwStopIteration", "(Ljava/lang/Object;Ljava/lang/Object;)V");
        Codegen.pushUndefined(this.cfw);
        this.cfw.add(176);
      }
      else if (this.hasVarsInRegs)
        this.cfw.add(176);
      else if (this.fnCurrent == null)
      {
        this.cfw.addALoad((int) this.popvLocal);
        this.cfw.add(176);
      }
      else
      {
        this.generateActivationExit();
        this.cfw.add(176);
        int num = this.cfw.acquireLabel();
        this.cfw.markHandler(num);
        int newWordLocal = (int) this.getNewWordLocal();
        this.cfw.addAStore(newWordLocal);
        this.generateActivationExit();
        this.cfw.addALoad(newWordLocal);
        this.releaseWordLocal((short) newWordLocal);
        this.cfw.add(191);
        this.cfw.addExceptionHandler(this.enterAreaStartLabel, this.epilogueLabel, num, (string) null);
      }
    }

    [LineNumberTable(new byte[] {164, 133, 127, 4, 39, 197, 102, 122, 172, 168, 113, 223, 0, 209, 113, 113, 113, 118, 240, 70, 177, 155, 109, 113, 113, 113, 191, 6, 166, 113, 113, 113, 113, 240, 70, 112, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateGenerator()
    {
      this.cfw.startMethod(this.codegen.getBodyMethodName(this.scriptOrFn), this.codegen.getBodyMethodSignature(this.scriptOrFn), (short) 10);
      this.initBodyGeneration();
      BodyCodegen bodyCodegen1 = this;
      int firstFreeLocal = (int) bodyCodegen1.firstFreeLocal;
      BodyCodegen bodyCodegen2 = bodyCodegen1;
      int num = firstFreeLocal;
      bodyCodegen2.firstFreeLocal = (short) (firstFreeLocal + 1);
      this.argsLocal = (short) num;
      this.localsMax = this.firstFreeLocal;
      if (this.fnCurrent != null)
      {
        this.cfw.addALoad((int) this.funObjLocal);
        this.cfw.addInvoke(185, "rhino/Scriptable", "getParentScope", "()Lrhino/Scriptable;");
        this.cfw.addAStore((int) this.variableObjectLocal);
      }
      this.cfw.addALoad((int) this.funObjLocal);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.cfw.addALoad((int) this.argsLocal);
      this.cfw.addPush(this.scriptOrFn.isInStrictMode());
      this.addScriptRuntimeInvoke("createFunctionActivation", "(Lrhino/NativeFunction;Lrhino/Scriptable;[Ljava/lang/Object;Z)Lrhino/Scriptable;");
      this.cfw.addAStore((int) this.variableObjectLocal);
      this.cfw.add(187, this.codegen.mainClassName);
      this.cfw.add(89);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addPush(this.scriptOrFnIndex);
      this.cfw.addInvoke(183, this.codegen.mainClassName, "<init>", "(Lrhino/Scriptable;Lrhino/Context;I)V");
      this.generateNestedFunctionInits();
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.cfw.addALoad((int) this.thisObjLocal);
      this.cfw.addLoadConstant(this.maxLocals);
      this.cfw.addLoadConstant(this.maxStack);
      this.addOptRuntimeInvoke("createNativeGenerator", "(Lrhino/NativeFunction;Lrhino/Scriptable;Lrhino/Scriptable;II)Lrhino/Scriptable;");
      this.cfw.add(176);
      this.cfw.stopMethod((short) ((int) this.localsMax + 1));
    }

    [LineNumberTable(new byte[] {171, 107, 127, 18, 102, 122, 108, 242, 70, 110, 112, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateObjectLiteralFactory([In] Node obj0, [In] int obj1)
    {
      string methodName = new StringBuilder().append(this.codegen.getBodyMethodName(this.scriptOrFn)).append("_literal").append(obj1).toString();
      this.initBodyGeneration();
      BodyCodegen bodyCodegen1 = this;
      int firstFreeLocal = (int) bodyCodegen1.firstFreeLocal;
      BodyCodegen bodyCodegen2 = bodyCodegen1;
      int num = firstFreeLocal;
      bodyCodegen2.firstFreeLocal = (short) (firstFreeLocal + 1);
      this.argsLocal = (short) num;
      this.localsMax = this.firstFreeLocal;
      this.cfw.startMethod(methodName, "(Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;[Ljava/lang/Object;)Lrhino/Scriptable;", (short) 2);
      this.visitObjectLiteral(obj0, obj0.getFirstChild(), true);
      this.cfw.add(176);
      this.cfw.stopMethod((short) ((int) this.localsMax + 1));
    }

    [LineNumberTable(new byte[] {171, 91, 127, 18, 102, 122, 108, 242, 70, 110, 112, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateArrayLiteralFactory([In] Node obj0, [In] int obj1)
    {
      string methodName = new StringBuilder().append(this.codegen.getBodyMethodName(this.scriptOrFn)).append("_literal").append(obj1).toString();
      this.initBodyGeneration();
      BodyCodegen bodyCodegen1 = this;
      int firstFreeLocal = (int) bodyCodegen1.firstFreeLocal;
      BodyCodegen bodyCodegen2 = bodyCodegen1;
      int num = firstFreeLocal;
      bodyCodegen2.firstFreeLocal = (short) (firstFreeLocal + 1);
      this.argsLocal = (short) num;
      this.localsMax = this.firstFreeLocal;
      this.cfw.startMethod(methodName, "(Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;[Ljava/lang/Object;)Lrhino/Scriptable;", (short) 2);
      this.visitArrayLiteral(obj0, obj0.getFirstChild(), true);
      this.cfw.add(176);
      this.cfw.stopMethod((short) ((int) this.localsMax + 1));
    }

    [LineNumberTable(new byte[] {180, 11, 215})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addScriptRuntimeInvoke([In] string obj0, [In] string obj1) => this.cfw.addInvoke(184, "rhino.ScriptRuntime", obj0, obj1);

    [LineNumberTable(new byte[] {164, 194, 108, 102, 109, 142, 232, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateNestedFunctionInits()
    {
      int functionCount = this.scriptOrFn.getFunctionCount();
      for (int i = 0; i != functionCount; ++i)
      {
        OptFunctionNode optFunctionNode = OptFunctionNode.get(this.scriptOrFn, i);
        if (optFunctionNode.__\u003C\u003Efnode.getFunctionType() == 1)
          this.visitFunction(optFunctionNode, 1);
      }
    }

    [LineNumberTable(new byte[] {180, 19, 215})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addOptRuntimeInvoke([In] string obj0, [In] string obj1) => this.cfw.addInvoke(184, "rhino/optimizer/OptRuntime", obj0, obj1);

    [LineNumberTable(new byte[] {171, 6, 114, 155, 109, 113, 113, 108, 191, 6, 100, 113, 113, 113, 240, 72, 200, 129, 108, 113, 113, 240, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitFunction([In] OptFunctionNode obj0, [In] int obj1)
    {
      int index = this.codegen.getIndex((ScriptNode) obj0.__\u003C\u003Efnode);
      this.cfw.add(187, this.codegen.mainClassName);
      this.cfw.add(89);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addPush(index);
      this.cfw.addInvoke(183, this.codegen.mainClassName, "<init>", "(Lrhino/Scriptable;Lrhino/Context;I)V");
      if (obj1 == 4)
      {
        this.cfw.addALoad((int) this.contextLocal);
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.cfw.addALoad((int) this.thisObjLocal);
        this.addOptRuntimeInvoke("bindThis", "(Lrhino/NativeFunction;Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;)Lrhino/Function;");
      }
      if (obj1 == 2 || obj1 == 4)
        return;
      this.cfw.addPush(obj1);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.cfw.addALoad((int) this.contextLocal);
      this.addOptRuntimeInvoke("initFunction", "(Lrhino/NativeFunction;ILrhino/Scriptable;Lrhino/Context;)V");
    }

    [LineNumberTable(new byte[] {180, 39, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addDoubleWrap() => this.addOptRuntimeInvoke("wrapDouble", "(D)Ljava/lang/Double;");

    [LineNumberTable(new byte[] {165, 250, 113, 223, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateGetGeneratorResumptionPoint()
    {
      this.cfw.addALoad((int) this.generatorStateLocal);
      this.cfw.add(180, "rhino/optimizer/OptRuntime$GeneratorState", "resumptionPoint", "I");
    }

    [LineNumberTable(new byte[] {156, 197, 130, 108, 172, 108, 113, 166, 108, 113, 117, 208, 100, 108, 131, 210, 113, 108, 113, 113, 108, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateCheckForThrowOrClose([In] int obj0, [In] bool obj1, [In] int obj2)
    {
      int num1 = obj1 ? 1 : 0;
      int num2 = this.cfw.acquireLabel();
      int num3 = this.cfw.acquireLabel();
      this.cfw.markLabel(num2);
      this.cfw.addALoad((int) this.argsLocal);
      this.generateThrowJavaScriptException();
      this.cfw.markLabel(num3);
      this.cfw.addALoad((int) this.argsLocal);
      this.cfw.add(192, "java/lang/Throwable");
      this.cfw.add(191);
      if (obj0 != -1)
        this.cfw.markLabel(obj0);
      if (num1 == 0)
        this.cfw.markTableSwitchCase(this.generatorSwitch, obj2);
      this.cfw.addILoad((int) this.operationLocal);
      this.cfw.addLoadConstant(2);
      this.cfw.add(159, num3);
      this.cfw.addILoad((int) this.operationLocal);
      this.cfw.addLoadConstant(1);
      this.cfw.add(159, num2);
    }

    [LineNumberTable(new byte[] {176, 83, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void saveCurrentCodeOffset() => this.savedCodeOffset = this.cfw.getCurrentCodeOffset();

    [LineNumberTable(5291)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private short getNewWordLocal() => this.getNewWordIntern(1);

    [LineNumberTable(5283)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private short getNewWordPairLocal([In] bool obj0) => this.getNewWordIntern(!obj0 ? 2 : 3);

    [LineNumberTable(5287)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private short getNewWordLocal([In] bool obj0) => this.getNewWordIntern(!obj0 ? 1 : 2);

    [LineNumberTable(new byte[] {176, 93, 211, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addInstructionCount() => this.addInstructionCount(Math.max(this.cfw.getCurrentCodeOffset() - this.savedCodeOffset, 1));

    [LineNumberTable(new byte[] {167, 202, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getNextGeneratorState([In] Node obj0) => ((FunctionNode) this.scriptOrFn).getResumptionPoints().indexOf((object) obj0) + 1;

    [LineNumberTable(new byte[] {166, 124, 113, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateGetGeneratorLocalsState()
    {
      this.cfw.addALoad((int) this.generatorStateLocal);
      this.addOptRuntimeInvoke("getGeneratorLocalsState", "(Ljava/lang/Object;)[Ljava/lang/Object;");
    }

    [LineNumberTable(new byte[] {171, 46, 103, 100, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getTargetLabel([In] Node obj0)
    {
      int labelId = obj0.labelId();
      if (labelId == -1)
      {
        labelId = this.cfw.acquireLabel();
        obj0.labelId(labelId);
      }
      return labelId;
    }

    [LineNumberTable(new byte[] {166, 2, 113, 108, 223, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateSetGeneratorResumptionPoint([In] int obj0)
    {
      this.cfw.addALoad((int) this.generatorStateLocal);
      this.cfw.addLoadConstant(obj0);
      this.cfw.add(181, "rhino/optimizer/OptRuntime$GeneratorState", "resumptionPoint", "I");
    }

    [LineNumberTable(new byte[] {166, 137, 123, 113, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateActivationExit()
    {
      if (this.fnCurrent == null || this.hasVarsInRegs)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      this.cfw.addALoad((int) this.contextLocal);
      this.addScriptRuntimeInvoke("exitActivationFunction", "(Lrhino/Context;)V");
    }

    [LineNumberTable(new byte[] {154, 85, 162, 105, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void releaseWordLocal([In] short obj0)
    {
      int index = (int) obj0;
      if (index < (int) this.firstFreeLocal)
        this.firstFreeLocal = (short) index;
      this.locals[index] = 0;
    }

    [LineNumberTable(new byte[] {173, 245, 108, 105, 97, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateLineNumber([In] Node obj0)
    {
      this.itsLineNumber = obj0.getLineno();
      if (this.itsLineNumber == -1)
        return;
      this.cfw.addLineNumberEntry((short) this.itsLineNumber);
    }

    [LineNumberTable(new byte[] {176, 109, 113, 108, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addInstructionCount([In] int obj0)
    {
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addPush(obj0);
      this.addScriptRuntimeInvoke(nameof (addInstructionCount), "(Lrhino/Context;I)V");
    }

    [LineNumberTable(new byte[] {174, 8, 103, 113, 236, 71, 108, 141, 103, 103, 136, 108, 99, 111, 111, 111, 103, 104, 103, 175, 99, 143, 174, 107, 103, 104, 171, 143, 180, 99, 105, 105, 143, 143, 143, 175, 103, 202, 109, 146, 169, 134, 232, 71, 240, 71, 240, 72, 208, 103, 104, 103, 240, 72, 102, 109, 109, 109, 104, 143, 173, 108, 177, 104, 104, 137, 237, 69, 109, 104, 117, 144, 141, 104, 209, 103, 141, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitTryCatchFinally([In] Jump obj0, [In] Node obj1)
    {
      int newWordLocal = (int) this.getNewWordLocal();
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.cfw.addAStore(newWordLocal);
      int num1 = this.cfw.acquireLabel();
      this.cfw.markLabel(num1, (short) 0);
      Node target = obj0.target;
      Node node = obj0.getFinally();
      int[] numArray = new int[5];
      this.exceptionManager.pushExceptionInfo(obj0);
      if (target != null)
      {
        numArray[0] = this.cfw.acquireLabel();
        numArray[1] = this.cfw.acquireLabel();
        numArray[2] = this.cfw.acquireLabel();
        Context currentContext = Context.getCurrentContext();
        if (currentContext != null && currentContext.hasFeature(13))
          numArray[3] = this.cfw.acquireLabel();
      }
      if (node != null)
        numArray[4] = this.cfw.acquireLabel();
      this.exceptionManager.setHandlers(numArray, num1);
      if (this.isGenerator && node != null)
      {
        BodyCodegen.FinallyReturnPoint finallyReturnPoint = new BodyCodegen.FinallyReturnPoint();
        if (this.finallys == null)
          this.finallys = (Map) new HashMap();
        this.finallys.put((object) node, (object) finallyReturnPoint);
        this.finallys.put((object) node.getNext(), (object) finallyReturnPoint);
      }
      for (; obj1 != null; obj1 = obj1.getNext())
      {
        if (object.ReferenceEquals((object) obj1, (object) target))
        {
          int targetLabel = this.getTargetLabel(target);
          this.exceptionManager.removeHandler(0, targetLabel);
          this.exceptionManager.removeHandler(1, targetLabel);
          this.exceptionManager.removeHandler(2, targetLabel);
          this.exceptionManager.removeHandler(3, targetLabel);
        }
        this.generateStatement(obj1);
      }
      int num2 = this.cfw.acquireLabel();
      this.cfw.add(167, num2);
      int localBlockRegister = this.getLocalBlockRegister((Node) obj0);
      if (target != null)
      {
        int num3 = target.labelId();
        this.generateCatchBlock(0, (short) newWordLocal, num3, localBlockRegister, numArray[0]);
        this.generateCatchBlock(1, (short) newWordLocal, num3, localBlockRegister, numArray[1]);
        this.generateCatchBlock(2, (short) newWordLocal, num3, localBlockRegister, numArray[2]);
        Context currentContext = Context.getCurrentContext();
        if (currentContext != null && currentContext.hasFeature(13))
          this.generateCatchBlock(3, (short) newWordLocal, num3, localBlockRegister, numArray[3]);
      }
      if (node != null)
      {
        int num3 = this.cfw.acquireLabel();
        int label = this.cfw.acquireLabel();
        this.cfw.markHandler(num3);
        if (!this.isGenerator)
          this.cfw.markLabel(numArray[4]);
        this.cfw.addAStore(localBlockRegister);
        this.cfw.addALoad(newWordLocal);
        this.cfw.addAStore((int) this.variableObjectLocal);
        int endLabel = node.labelId();
        if (this.isGenerator)
          this.addGotoWithReturn(node);
        else
          this.inlineFinally(node, numArray[4], label);
        this.cfw.addALoad(localBlockRegister);
        if (this.isGenerator)
          this.cfw.add(192, "java/lang/Throwable");
        this.cfw.add(191);
        this.cfw.markLabel(label);
        if (this.isGenerator)
          this.cfw.addExceptionHandler(num1, endLabel, num3, (string) null);
      }
      this.releaseWordLocal((short) newWordLocal);
      this.cfw.markLabel(num2);
      if (this.isGenerator)
        return;
      this.exceptionManager.popExceptionInfo();
    }

    [LineNumberTable(new byte[] {179, 200, 109, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getLocalBlockRegister([In] Node obj0) => ((Node) obj0.getProp(3)).getExistingIntProp(2);

    [LineNumberTable(new byte[] {167, 208, 103, 103, 159, 162, 42, 165, 120, 104, 141, 109, 138, 139, 105, 197, 113, 113, 113, 240, 71, 197, 138, 131, 174, 99, 108, 101, 138, 136, 98, 170, 165, 136, 103, 105, 113, 240, 71, 165, 106, 107, 143, 179, 165, 113, 165, 113, 165, 109, 165, 108, 165, 159, 0, 165, 159, 0, 197, 113, 113, 104, 127, 4, 42, 165, 255, 0, 72, 165, 104, 100, 104, 109, 99, 139, 104, 229, 69, 104, 108, 101, 181, 113, 240, 69, 197, 105, 165, 105, 165, 108, 109, 109, 139, 108, 159, 0, 114, 109, 159, 0, 109, 108, 197, 104, 112, 108, 112, 112, 102, 165, 104, 109, 107, 165, 104, 176, 165, 103, 197, 103, 197, 104, 109, 144, 108, 101, 147, 113, 109, 109, 140, 165, 104, 105, 104, 144, 109, 114, 109, 105, 109, 114, 111, 105, 141, 165, 104, 109, 155, 109, 133, 144, 133, 144, 133, 106, 213, 111, 245, 69, 113, 240, 72, 165, 107, 165, 107, 197, 180, 229, 72, 105, 197, 104, 102, 101, 141, 102, 197, 104, 102, 197, 98, 106, 137, 100, 103, 104, 141, 104, 134, 229, 73, 108, 109, 107, 105, 229, 71, 108, 109, 107, 105, 229, 69, 104, 165, 104, 109, 113, 107, 245, 70, 113, 240, 72, 165, 104, 113, 240, 69, 165, 103, 165, 105, 165, 104, 165, 104, 165, 104, 165, 105, 197, 105, 197, 105, 197, 104, 103, 104, 109, 113, 240, 70, 104, 113, 113, 240, 72, 165, 104, 113, 208, 165, 107, 104, 103, 104, 113, 108, 240, 69, 165, 99, 104, 169, 113, 113, 113, 240, 71, 165, 114, 165, 111, 104, 109, 113, 113, 240, 72, 229, 70, 100, 167, 104, 103, 99, 145, 158, 103, 231, 69, 130, 103, 231, 70, 130, 103, 231, 69, 113, 130, 103, 231, 70, 113, 130, 139, 109, 138, 197, 104, 165, 99, 105, 105, 104, 111, 104, 194, 99, 104, 104, 105, 194, 191, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateExpression([In] Node obj0, [In] Node obj1)
    {
      int type = obj0.getType();
      Node node1 = obj0.getFirstChild();
      switch (type)
      {
        case 8:
          this.visitSetName(obj0, node1);
          break;
        case 9:
        case 10:
        case 11:
        case 18:
        case 19:
        case 20:
          this.visitBitOp(obj0, type, node1);
          break;
        case 12:
        case 13:
        case 46:
        case 47:
          int num1 = this.cfw.acquireLabel();
          int num2 = this.cfw.acquireLabel();
          this.visitIfJumpEqOp(obj0, node1, num1, num2);
          this.addJumpedBooleanWrap(num1, num2);
          break;
        case 14:
        case 15:
        case 16:
        case 17:
        case 52:
        case 53:
          int num3 = this.cfw.acquireLabel();
          int num4 = this.cfw.acquireLabel();
          this.visitIfJumpRelOp(obj0, node1, num3, num4);
          this.addJumpedBooleanWrap(num3, num4);
          break;
        case 21:
          this.generateExpression(node1, obj0);
          this.generateExpression(node1.getNext(), obj0);
          switch (obj0.getIntProp(8, -1))
          {
            case 0:
              this.cfw.add(99);
              return;
            case 1:
              this.addOptRuntimeInvoke("add", "(DLjava/lang/Object;)Ljava/lang/Object;");
              return;
            case 2:
              this.addOptRuntimeInvoke("add", "(Ljava/lang/Object;D)Ljava/lang/Object;");
              return;
            default:
              if (node1.getType() == 41)
              {
                this.addScriptRuntimeInvoke("add", "(Ljava/lang/CharSequence;Ljava/lang/Object;)Ljava/lang/CharSequence;");
                return;
              }
              if (node1.getNext().getType() == 41)
              {
                this.addScriptRuntimeInvoke("add", "(Ljava/lang/Object;Ljava/lang/CharSequence;)Ljava/lang/CharSequence;");
                return;
              }
              this.cfw.addALoad((int) this.contextLocal);
              this.addScriptRuntimeInvoke("add", "(Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;)Ljava/lang/Object;");
              return;
          }
        case 22:
          this.visitArithmetic(obj0, 103, node1, obj1);
          break;
        case 23:
          this.visitArithmetic(obj0, 107, node1, obj1);
          break;
        case 24:
        case 25:
          this.visitArithmetic(obj0, type != 24 ? 115 : 111, node1, obj1);
          break;
        case 26:
          int label1 = this.cfw.acquireLabel();
          int label2 = this.cfw.acquireLabel();
          int num5 = this.cfw.acquireLabel();
          this.generateIfJump(node1, obj0, label1, label2);
          this.cfw.markLabel(label1);
          this.cfw.add(178, "java/lang/Boolean", "FALSE", "Ljava/lang/Boolean;");
          this.cfw.add(167, num5);
          this.cfw.markLabel(label2);
          this.cfw.add(178, "java/lang/Boolean", "TRUE", "Ljava/lang/Boolean;");
          this.cfw.markLabel(num5);
          this.cfw.adjustStackTop(-1);
          break;
        case 27:
          this.generateExpression(node1, obj0);
          this.addScriptRuntimeInvoke("toInt32", "(Ljava/lang/Object;)I");
          this.cfw.addPush(-1);
          this.cfw.add(130);
          this.cfw.add(135);
          this.addDoubleWrap();
          break;
        case 28:
        case 29:
          this.generateExpression(node1, obj0);
          this.addObjectToDouble();
          if (type == 29)
            this.cfw.add(119);
          this.addDoubleWrap();
          break;
        case 30:
        case 38:
          int intProp1 = obj0.getIntProp(10, 0);
          if (intProp1 == 0)
          {
            OptFunctionNode prop = (OptFunctionNode) obj0.getProp(9);
            if (prop != null)
            {
              this.visitOptimizedCall(obj0, prop, type, node1);
              break;
            }
            if (type == 38)
            {
              this.visitStandardCall(obj0, node1);
              break;
            }
            this.visitStandardNew(obj0, node1);
            break;
          }
          this.visitSpecialCall(obj0, type, intProp1, node1);
          break;
        case 31:
          int num6 = node1.getType() == 49 ? 1 : 0;
          this.generateExpression(node1, obj0);
          this.generateExpression(node1.getNext(), obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addPush(num6 != 0);
          this.addScriptRuntimeInvoke("delete", "(Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;Z)Ljava/lang/Object;");
          break;
        case 32:
          this.generateExpression(node1, obj0);
          this.addScriptRuntimeInvoke("typeof", "(Ljava/lang/Object;)Ljava/lang/String;");
          break;
        case 33:
        case 34:
          this.visitGetProp(obj0, node1);
          break;
        case 35:
        case 140:
          this.visitSetProp(type, obj0, node1);
          break;
        case 36:
          this.generateExpression(node1, obj0);
          this.generateExpression(node1.getNext(), obj0);
          this.cfw.addALoad((int) this.contextLocal);
          if (obj0.getIntProp(8, -1) != -1)
          {
            this.addScriptRuntimeInvoke("getObjectIndex", "(Ljava/lang/Object;DLrhino/Context;)Ljava/lang/Object;");
            break;
          }
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("getObjectElem", "(Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
          break;
        case 37:
        case 141:
          this.visitSetElem(type, obj0, node1);
          break;
        case 39:
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.addPush(obj0.getString());
          this.addScriptRuntimeInvoke("name", "(Lrhino/Context;Lrhino/Scriptable;Ljava/lang/String;)Ljava/lang/Object;");
          break;
        case 40:
          double k = obj0.getDouble();
          if (obj0.getIntProp(8, -1) != -1)
          {
            this.cfw.addPush(k);
            break;
          }
          this.codegen.pushNumberAsObject(this.cfw, k);
          break;
        case 41:
          this.cfw.addPush(obj0.getString());
          break;
        case 42:
          this.cfw.add(1);
          break;
        case 43:
          this.cfw.addALoad((int) this.thisObjLocal);
          break;
        case 44:
          this.cfw.add(178, "java/lang/Boolean", "FALSE", "Ljava/lang/Boolean;");
          break;
        case 45:
          this.cfw.add(178, "java/lang/Boolean", "TRUE", "Ljava/lang/Boolean;");
          break;
        case 48:
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.add(178, this.codegen.mainClassName, this.codegen.getCompiledRegexpName(this.scriptOrFn, obj0.getExistingIntProp(4)), "Ljava/lang/Object;");
          this.cfw.addInvoke(184, "rhino/ScriptRuntime", "wrapRegExp", "(Lrhino/Context;Lrhino/Scriptable;Ljava/lang/Object;)Lrhino/Scriptable;");
          break;
        case 49:
          for (; node1 != null; node1 = node1.getNext())
            this.generateExpression(node1, obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.addPush(obj0.getString());
          this.addScriptRuntimeInvoke("bind", "(Lrhino/Context;Lrhino/Scriptable;Ljava/lang/String;)Lrhino/Scriptable;");
          break;
        case 54:
          this.cfw.addALoad(this.getLocalBlockRegister(obj0));
          break;
        case 55:
          this.visitGetVar(obj0);
          break;
        case 56:
          this.visitSetVar(obj0, node1, true);
          break;
        case 62:
        case 63:
          this.cfw.addALoad(this.getLocalBlockRegister(obj0));
          if (type == 62)
          {
            this.addScriptRuntimeInvoke("enumNext", "(Ljava/lang/Object;)Ljava/lang/Boolean;");
            break;
          }
          this.cfw.addALoad((int) this.contextLocal);
          this.addScriptRuntimeInvoke("enumId", "(Ljava/lang/Object;Lrhino/Context;)Ljava/lang/Object;");
          break;
        case 64:
          this.cfw.add(42);
          break;
        case 66:
          this.visitArrayLiteral(obj0, node1, false);
          break;
        case 67:
          this.visitObjectLiteral(obj0, node1, false);
          break;
        case 68:
          this.generateExpression(node1, obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.addScriptRuntimeInvoke("refGet", "(Lrhino/Ref;Lrhino/Context;)Ljava/lang/Object;");
          break;
        case 69:
        case 143:
          this.generateExpression(node1, obj0);
          Node next1 = node1.getNext();
          if (type == 143)
          {
            this.cfw.add(89);
            this.cfw.addALoad((int) this.contextLocal);
            this.addScriptRuntimeInvoke("refGet", "(Lrhino/Ref;Lrhino/Context;)Ljava/lang/Object;");
          }
          this.generateExpression(next1, obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("refSet", "(Lrhino/Ref;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
          break;
        case 70:
          this.generateExpression(node1, obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.addScriptRuntimeInvoke("refDel", "(Lrhino/Ref;Lrhino/Context;)Ljava/lang/Object;");
          break;
        case 71:
          this.generateFunctionAndThisObj(node1, obj0);
          Node next2 = node1.getNext();
          this.generateCallArgArray(obj0, next2, false);
          this.cfw.addALoad((int) this.contextLocal);
          this.addScriptRuntimeInvoke("callRef", "(Lrhino/Callable;Lrhino/Scriptable;[Ljava/lang/Object;Lrhino/Context;)Lrhino/Ref;");
          break;
        case 72:
          string prop1 = (string) obj0.getProp(17);
          this.generateExpression(node1, obj0);
          this.cfw.addPush(prop1);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("specialRef", "(Ljava/lang/Object;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Lrhino/Ref;");
          break;
        case 73:
        case 166:
          this.generateYieldPoint(obj0, true);
          break;
        case 74:
          this.visitStrictSetName(obj0, node1);
          break;
        case 78:
        case 79:
        case 80:
        case 81:
          int intProp2 = obj0.getIntProp(16, 0);
          do
          {
            this.generateExpression(node1, obj0);
            node1 = node1.getNext();
          }
          while (node1 != null);
          this.cfw.addALoad((int) this.contextLocal);
          string str1;
          string str2;
          switch (type)
          {
            case 78:
              str1 = "memberRef";
              str2 = "(Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;I)Lrhino/Ref;";
              break;
            case 79:
              str1 = "memberRef";
              str2 = "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;I)Lrhino/Ref;";
              break;
            case 80:
              str1 = "nameRef";
              str2 = "(Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;I)Lrhino/Ref;";
              this.cfw.addALoad((int) this.variableObjectLocal);
              break;
            case 81:
              str1 = "nameRef";
              str2 = "(Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;I)Lrhino/Ref;";
              this.cfw.addALoad((int) this.variableObjectLocal);
              break;
            default:
              throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
          }
          this.cfw.addPush(intProp2);
          this.addScriptRuntimeInvoke(str1, str2);
          break;
        case 90:
          for (Node next3 = node1.getNext(); next3 != null; next3 = next3.getNext())
          {
            this.generateExpression(node1, obj0);
            this.cfw.add(87);
            node1 = next3;
          }
          this.generateExpression(node1, obj0);
          break;
        case 103:
          Node next4 = node1.getNext();
          Node next5 = next4.getNext();
          this.generateExpression(node1, obj0);
          this.addScriptRuntimeInvoke("toBoolean", "(Ljava/lang/Object;)Z");
          int num7 = this.cfw.acquireLabel();
          this.cfw.add(153, num7);
          int stackTop = (int) this.cfw.getStackTop();
          this.generateExpression(next4, obj0);
          int num8 = this.cfw.acquireLabel();
          this.cfw.add(167, num8);
          this.cfw.markLabel(num7, (short) stackTop);
          this.generateExpression(next5, obj0);
          this.cfw.markLabel(num8);
          break;
        case 105:
        case 106:
          this.generateExpression(node1, obj0);
          this.cfw.add(89);
          this.addScriptRuntimeInvoke("toBoolean", "(Ljava/lang/Object;)Z");
          int num9 = this.cfw.acquireLabel();
          if (type == 106)
            this.cfw.add(153, num9);
          else
            this.cfw.add(154, num9);
          this.cfw.add(87);
          this.generateExpression(node1.getNext(), obj0);
          this.cfw.markLabel(num9);
          break;
        case 107:
        case 108:
          this.visitIncDec(obj0);
          break;
        case 110:
          if (this.fnCurrent == null && obj1.getType() == 137)
            break;
          OptFunctionNode optFunctionNode = OptFunctionNode.get(this.scriptOrFn, obj0.getExistingIntProp(1));
          int functionType = optFunctionNode.__\u003C\u003Efnode.getFunctionType();
          switch (functionType)
          {
            case 2:
            case 4:
              this.visitFunction(optFunctionNode, functionType);
              return;
            default:
              throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
          }
        case (int) sbyte.MaxValue:
          this.generateExpression(node1, obj0);
          this.cfw.add(87);
          Codegen.pushUndefined(this.cfw);
          break;
        case 138:
          this.visitTypeofname(obj0);
          break;
        case 139:
          break;
        case 150:
          int prop2 = -1;
          if (node1.getType() == 40)
            prop2 = node1.getIntProp(8, -1);
          if (prop2 != -1)
          {
            node1.removeProp(8);
            this.generateExpression(node1, obj0);
            node1.putIntProp(8, prop2);
            break;
          }
          this.generateExpression(node1, obj0);
          this.addDoubleWrap();
          break;
        case 151:
          this.generateExpression(node1, obj0);
          this.addObjectToDouble();
          break;
        case 156:
          this.visitSetConst(obj0, node1);
          break;
        case 157:
          this.visitSetConstVar(obj0, node1, true);
          break;
        case 158:
          Node node2 = node1;
          Node next6 = node1.getNext();
          this.generateStatement(node2);
          this.generateExpression(next6, obj0);
          break;
        case 160:
          Node node3 = node1;
          Node next7 = node3.getNext();
          Node next8 = next7.getNext();
          this.generateStatement(node3);
          this.generateExpression(next7.getFirstChild(), next7);
          this.generateStatement(next8);
          break;
        default:
          string str3 = new StringBuilder().append("Unexpected node type ").append(type).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException(str3);
      }
    }

    [LineNumberTable(new byte[] {167, 187, 149, 109, 109, 118, 113, 255, 0, 69, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateThrowJavaScriptException()
    {
      this.cfw.add(187, "rhino/JavaScriptException");
      this.cfw.add(90);
      this.cfw.add(95);
      this.cfw.addPush(this.scriptOrFn.getSourceName());
      this.cfw.addPush(this.itsLineNumber);
      this.cfw.addInvoke(183, "rhino/JavaScriptException", "<init>", "(Ljava/lang/Object;Ljava/lang/String;I)V");
      this.cfw.add(191);
    }

    [LineNumberTable(new byte[] {166, 130, 113, 109, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateSetGeneratorReturnValue()
    {
      this.cfw.addALoad((int) this.generatorStateLocal);
      this.cfw.add(95);
      this.addOptRuntimeInvoke("setGeneratorReturnValue", "(Ljava/lang/Object;Ljava/lang/Object;)V");
    }

    [LineNumberTable(new byte[] {176, 15, 136, 103, 140, 108, 134, 106, 107, 103, 104, 108, 208, 241, 54, 241, 76, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitSwitch([In] Jump obj0, [In] Node obj1)
    {
      this.generateExpression(obj1, (Node) obj0);
      int newWordLocal = (int) this.getNewWordLocal();
      this.cfw.addAStore(newWordLocal);
      for (Jump next = (Jump) obj1.getNext(); next != null; next = (Jump) next.getNext())
      {
        if (next.getType() != 116)
          throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
        this.generateExpression(next.getFirstChild(), (Node) next);
        this.cfw.addALoad(newWordLocal);
        this.addScriptRuntimeInvoke("shallowEq", "(Ljava/lang/Object;Ljava/lang/Object;)Z");
        this.addGoto(next.target, 154);
      }
      this.releaseWordLocal((short) newWordLocal);
    }

    [LineNumberTable(new byte[] {154, 87, 130, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void incReferenceWordLocal([In] short obj0)
    {
      int num = (int) obj0;
      int[] locals = this.locals;
      int index = num;
      int[] numArray = locals;
      numArray[index] = numArray[index] + 1;
    }

    [LineNumberTable(new byte[] {154, 86, 162, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void decReferenceWordLocal([In] short obj0)
    {
      int num = (int) obj0;
      int[] locals = this.locals;
      int index = num;
      int[] numArray = locals;
      numArray[index] = numArray[index] - 1;
    }

    [LineNumberTable(new byte[] {154, 199, 66, 110, 109, 109, 111, 105, 114, 102, 102, 99, 146, 146, 108, 102, 112, 108, 223, 0, 109, 109, 114, 109, 102, 108, 114, 111, 110, 109, 101, 112, 177, 110, 99, 100, 108, 145, 176, 102, 174, 106, 108, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitSetVar([In] Node obj0, [In] Node obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      if (!this.hasVarsInRegs)
        Kit.codeBug();
      int varIndex = this.fnCurrent.getVarIndex(obj0);
      this.generateExpression(obj1.getNext(), obj0);
      int num2 = obj0.getIntProp(8, -1) != -1 ? 1 : 0;
      int varRegister = (int) this.varRegisters[varIndex];
      if (this.fnCurrent.__\u003C\u003Efnode.getParamAndVarConst()[varIndex])
      {
        if (num1 != 0)
          return;
        if (num2 != 0)
          this.cfw.add(88);
        else
          this.cfw.add(87);
      }
      else if (this.varIsDirectCallParameter(varIndex))
      {
        if (num2 != 0)
        {
          if (num1 != 0)
            this.cfw.add(92);
          this.cfw.addALoad(varRegister);
          this.cfw.add(178, "java/lang/Void", "TYPE", "Ljava/lang/Class;");
          int num3 = this.cfw.acquireLabel();
          int num4 = this.cfw.acquireLabel();
          this.cfw.add(165, num3);
          int stackTop = (int) this.cfw.getStackTop();
          this.addDoubleWrap();
          this.cfw.addAStore(varRegister);
          this.cfw.add(167, num4);
          this.cfw.markLabel(num3, (short) stackTop);
          this.cfw.addDStore(varRegister + 1);
          this.cfw.markLabel(num4);
        }
        else
        {
          if (num1 != 0)
            this.cfw.add(89);
          this.cfw.addAStore(varRegister);
        }
      }
      else
      {
        int num3 = this.fnCurrent.isNumberVar(varIndex) ? 1 : 0;
        if (num2 != 0)
        {
          if (num3 != 0)
          {
            this.cfw.addDStore(varRegister);
            if (num1 == 0)
              return;
            this.cfw.addDLoad(varRegister);
          }
          else
          {
            if (num1 != 0)
              this.cfw.add(92);
            this.addDoubleWrap();
            this.cfw.addAStore(varRegister);
          }
        }
        else
        {
          if (num3 != 0)
            Kit.codeBug();
          this.cfw.addAStore(varRegister);
          if (num1 == 0)
            return;
          this.cfw.addALoad(varRegister);
        }
      }
    }

    [LineNumberTable(new byte[] {154, 185, 98, 110, 109, 109, 111, 105, 109, 109, 102, 110, 114, 109, 108, 110, 108, 99, 108, 145, 114, 111, 141, 101, 110, 114, 109, 108, 110, 108, 99, 108, 145, 114, 111, 173, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitSetConstVar([In] Node obj0, [In] Node obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      if (!this.hasVarsInRegs)
        Kit.codeBug();
      int varIndex = this.fnCurrent.getVarIndex(obj0);
      this.generateExpression(obj1.getNext(), obj0);
      int num2 = obj0.getIntProp(8, -1) != -1 ? 1 : 0;
      int varRegister = (int) this.varRegisters[varIndex];
      int num3 = this.cfw.acquireLabel();
      int num4 = this.cfw.acquireLabel();
      if (num2 != 0)
      {
        this.cfw.addILoad(varRegister + 2);
        this.cfw.add(154, num4);
        int stackTop = (int) this.cfw.getStackTop();
        this.cfw.addPush(1);
        this.cfw.addIStore(varRegister + 2);
        this.cfw.addDStore(varRegister);
        if (num1 != 0)
        {
          this.cfw.addDLoad(varRegister);
          this.cfw.markLabel(num4, (short) stackTop);
        }
        else
        {
          this.cfw.add(167, num3);
          this.cfw.markLabel(num4, (short) stackTop);
          this.cfw.add(88);
        }
      }
      else
      {
        this.cfw.addILoad(varRegister + 1);
        this.cfw.add(154, num4);
        int stackTop = (int) this.cfw.getStackTop();
        this.cfw.addPush(1);
        this.cfw.addIStore(varRegister + 1);
        this.cfw.addAStore(varRegister);
        if (num1 != 0)
        {
          this.cfw.addALoad(varRegister);
          this.cfw.markLabel(num4, (short) stackTop);
        }
        else
        {
          this.cfw.add(167, num3);
          this.cfw.markLabel(num4, (short) stackTop);
          this.cfw.add(87);
        }
      }
      this.cfw.markLabel(num3);
    }

    [LineNumberTable(new byte[] {156, 225, 98, 142, 99, 113, 124, 113, 113, 208, 161, 104, 230, 70, 136, 127, 1, 110, 113, 109, 108, 109, 145, 176, 141, 238, 69, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateYieldPoint([In] Node obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      if (this.unnestedYields.containsKey((object) obj0))
      {
        if (num == 0)
          return;
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.cfw.addLoadConstant((string) this.unnestedYields.get((object) obj0));
        this.cfw.addALoad((int) this.contextLocal);
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.addScriptRuntimeInvoke("getObjectPropNoWarn", "(Ljava/lang/Object;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
      }
      else
      {
        Node nestedYield = this.findNestedYield(obj0);
        if (nestedYield != null)
        {
          this.generateYieldPoint(nestedYield, true);
          string k = new StringBuilder().append("__nested__yield__").append(this.unnestedYieldCount).toString();
          ++this.unnestedYieldCount;
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.add(95);
          this.cfw.addLoadConstant(k);
          this.cfw.add(95);
          this.cfw.addALoad((int) this.contextLocal);
          this.addScriptRuntimeInvoke("setObjectProp", "(Lrhino/Scriptable;Ljava/lang/String;Ljava/lang/Object;Lrhino/Context;)Ljava/lang/Object;");
          this.cfw.add(87);
          this.unnestedYields.put((object) nestedYield, (object) k);
        }
        this.generateLocalYieldPoint(obj0, num != 0);
      }
    }

    [LineNumberTable(new byte[] {171, 55, 103, 104, 110, 104, 108, 100, 140, 106, 108, 98, 104, 104, 169, 169, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitGoto([In] Jump obj0, [In] int obj1, [In] Node obj2)
    {
      Node target = obj0.target;
      switch (obj1)
      {
        case 6:
        case 7:
          if (obj2 == null)
            throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
          int targetLabel = this.getTargetLabel(target);
          int label = this.cfw.acquireLabel();
          if (obj1 == 6)
            this.generateIfJump(obj2, (Node) obj0, targetLabel, label);
          else
            this.generateIfJump(obj2, (Node) obj0, label, targetLabel);
          this.cfw.markLabel(label);
          break;
        case 136:
          if (this.isGenerator)
          {
            this.addGotoWithReturn(target);
            break;
          }
          this.inlineFinally(target);
          break;
        default:
          this.addGoto(target, 167);
          break;
      }
    }

    [LineNumberTable(new byte[] {167, 175, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateIntegerWrap() => this.cfw.addInvoke(184, "java/lang/Integer", "valueOf", "(I)Ljava/lang/Integer;");

    [LineNumberTable(new byte[] {167, 181, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateIntegerUnwrap() => this.cfw.addInvoke(182, "java/lang/Integer", "intValue", "()I");

    [LineNumberTable(new byte[] {172, 255, 104, 140, 98, 101, 139, 105, 103, 204, 108, 141, 109, 113, 114, 113, 109, 123, 124, 178, 113, 177, 101, 142, 236, 74, 99, 103, 106, 101, 109, 113, 139, 223, 0, 139, 105, 144, 105, 133, 191, 0, 191, 8, 115, 113, 229, 59, 229, 71, 145, 141, 113, 145, 101, 108, 231, 69, 137, 101, 242, 72, 255, 0, 74, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitOptimizedCall([In] Node obj0, [In] OptFunctionNode obj1, [In] int obj2, [In] Node obj3)
    {
      Node next = obj3.getNext();
      string mainClassName = this.codegen.mainClassName;
      int local1 = 0;
      if (obj2 == 30)
      {
        this.generateExpression(obj3, obj0);
      }
      else
      {
        this.generateFunctionAndThisObj(obj3, obj0);
        local1 = (int) this.getNewWordLocal();
        this.cfw.addAStore(local1);
      }
      int num1 = this.cfw.acquireLabel();
      int num2 = this.cfw.acquireLabel();
      this.cfw.add(89);
      this.cfw.add(193, mainClassName);
      this.cfw.add(153, num2);
      this.cfw.add(192, mainClassName);
      this.cfw.add(89);
      this.cfw.add(180, mainClassName, "_id", "I");
      this.cfw.addPush(this.codegen.getIndex((ScriptNode) obj1.__\u003C\u003Efnode));
      this.cfw.add(160, num2);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addALoad((int) this.variableObjectLocal);
      if (obj2 == 30)
        this.cfw.add(1);
      else
        this.cfw.addALoad(local1);
      for (Node node = next; node != null; node = node.getNext())
      {
        int local2 = this.nodeIsDirectCallParameter(node);
        if (local2 >= 0)
        {
          this.cfw.addALoad(local2);
          this.cfw.addDLoad(local2 + 1);
        }
        else if (node.getIntProp(8, -1) == 0)
        {
          this.cfw.add(178, "java/lang/Void", "TYPE", "Ljava/lang/Class;");
          this.generateExpression(node, obj0);
        }
        else
        {
          this.generateExpression(node, obj0);
          this.cfw.addPush(0.0);
        }
      }
      this.cfw.add(178, "rhino/ScriptRuntime", "emptyArgs", "[Ljava/lang/Object;");
      this.cfw.addInvoke(184, this.codegen.mainClassName, obj2 != 30 ? this.codegen.getBodyMethodName((ScriptNode) obj1.__\u003C\u003Efnode) : this.codegen.getDirectCtorName((ScriptNode) obj1.__\u003C\u003Efnode), this.codegen.getBodyMethodSignature((ScriptNode) obj1.__\u003C\u003Efnode));
      this.cfw.add(167, num1);
      this.cfw.markLabel(num2);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addALoad((int) this.variableObjectLocal);
      if (obj2 != 30)
      {
        this.cfw.addALoad(local1);
        this.releaseWordLocal((short) local1);
      }
      this.generateCallArgArray(obj0, next, true);
      if (obj2 == 30)
        this.addScriptRuntimeInvoke("newObject", "(Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;[Ljava/lang/Object;)Lrhino/Scriptable;");
      else
        this.cfw.addInvoke(185, "rhino/Callable", "call", "(Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;[Ljava/lang/Object;)Ljava/lang/Object;");
      this.cfw.markLabel(num1);
    }

    [LineNumberTable(new byte[] {172, 132, 149, 103, 231, 69, 102, 133, 103, 108, 102, 199, 138, 104, 105, 105, 105, 109, 102, 231, 69, 106, 139, 104, 102, 236, 71, 229, 69, 103, 105, 108, 102, 231, 69, 101, 99, 103, 38, 171, 136, 101, 104, 102, 233, 70, 101, 104, 109, 102, 233, 72, 105, 102, 231, 73, 113, 113, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitStandardCall([In] Node obj0, [In] Node obj1)
    {
      if (obj0.getType() != 38)
        throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
      Node next = obj1.getNext();
      int type = obj1.getType();
      string str1;
      string str2;
      if (next == null)
      {
        switch (type)
        {
          case 33:
            Node firstChild = obj1.getFirstChild();
            this.generateExpression(firstChild, obj0);
            this.cfw.addPush(firstChild.getNext().getString());
            str1 = "callProp0";
            str2 = "(Ljava/lang/Object;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;";
            break;
          case 34:
            throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
          case 39:
            this.cfw.addPush(obj1.getString());
            str1 = "callName0";
            str2 = "(Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;";
            break;
          default:
            this.generateFunctionAndThisObj(obj1, obj0);
            str1 = "call0";
            str2 = "(Lrhino/Callable;Lrhino/Scriptable;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;";
            break;
        }
      }
      else if (type == 39)
      {
        string k = obj1.getString();
        this.generateCallArgArray(obj0, next, false);
        this.cfw.addPush(k);
        str1 = "callName";
        str2 = "([Ljava/lang/Object;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;";
      }
      else
      {
        int num = 0;
        for (Node node = next; node != null; node = node.getNext())
          ++num;
        this.generateFunctionAndThisObj(obj1, obj0);
        switch (num)
        {
          case 1:
            this.generateExpression(next, obj0);
            str1 = "call1";
            str2 = "(Lrhino/Callable;Lrhino/Scriptable;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;";
            break;
          case 2:
            this.generateExpression(next, obj0);
            this.generateExpression(next.getNext(), obj0);
            str1 = "call2";
            str2 = "(Lrhino/Callable;Lrhino/Scriptable;Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;";
            break;
          default:
            this.generateCallArgArray(obj0, next, false);
            str1 = "callN";
            str2 = "(Lrhino/Callable;Lrhino/Scriptable;[Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;";
            break;
        }
      }
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.addOptRuntimeInvoke(str1, str2);
    }

    [LineNumberTable(new byte[] {172, 234, 149, 135, 136, 113, 145, 105, 240, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitStandardNew([In] Node obj0, [In] Node obj1)
    {
      if (obj0.getType() != 30)
        throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
      Node next = obj1.getNext();
      this.generateExpression(obj1, obj0);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.generateCallArgArray(obj0, next, false);
      this.addScriptRuntimeInvoke("newObject", "(Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;[Ljava/lang/Object;)Lrhino/Scriptable;");
    }

    [LineNumberTable(new byte[] {172, 81, 145, 101, 171, 169, 137, 234, 69, 101, 102, 230, 71, 113, 113, 145, 102, 230, 73, 113, 113, 108, 108, 118, 177, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitSpecialCall([In] Node obj0, [In] int obj1, [In] int obj2, [In] Node obj3)
    {
      this.cfw.addALoad((int) this.contextLocal);
      if (obj1 == 30)
        this.generateExpression(obj3, obj0);
      else
        this.generateFunctionAndThisObj(obj3, obj0);
      obj3 = obj3.getNext();
      this.generateCallArgArray(obj0, obj3, false);
      string str1;
      string str2;
      if (obj1 == 30)
      {
        str1 = "newObjectSpecial";
        str2 = "(Lrhino/Context;Ljava/lang/Object;[Ljava/lang/Object;Lrhino/Scriptable;Lrhino/Scriptable;I)Ljava/lang/Object;";
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.cfw.addALoad((int) this.thisObjLocal);
        this.cfw.addPush(obj2);
      }
      else
      {
        str1 = "callSpecial";
        str2 = "(Lrhino/Context;Lrhino/Callable;Lrhino/Scriptable;[Ljava/lang/Object;Lrhino/Scriptable;Lrhino/Scriptable;ILjava/lang/String;I)Ljava/lang/Object;";
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.cfw.addALoad((int) this.thisObjLocal);
        this.cfw.addPush(obj2);
        this.cfw.addPush(this.scriptOrFn.getSourceName() ?? "");
        this.cfw.addPush(this.itsLineNumber);
      }
      this.addOptRuntimeInvoke(str1, str2);
    }

    [LineNumberTable(new byte[] {173, 173, 103, 159, 16, 203, 103, 104, 103, 101, 103, 108, 113, 113, 240, 71, 101, 104, 107, 102, 113, 113, 240, 72, 194, 104, 109, 113, 113, 240, 70, 194, 104, 113, 240, 72, 113, 208})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateFunctionAndThisObj([In] Node obj0, [In] Node obj1)
    {
      int type = obj0.getType();
      switch (obj0.getType())
      {
        case 33:
        case 36:
          Node firstChild = obj0.getFirstChild();
          this.generateExpression(firstChild, obj0);
          Node next = firstChild.getNext();
          if (type == 33)
          {
            this.cfw.addPush(next.getString());
            this.cfw.addALoad((int) this.contextLocal);
            this.cfw.addALoad((int) this.variableObjectLocal);
            this.addScriptRuntimeInvoke("getPropFunctionAndThis", "(Ljava/lang/Object;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Lrhino/Callable;");
            break;
          }
          this.generateExpression(next, obj0);
          if (obj0.getIntProp(8, -1) != -1)
            this.addDoubleWrap();
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("getElemFunctionAndThis", "(Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Lrhino/Callable;");
          break;
        case 34:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        case 39:
          this.cfw.addPush(obj0.getString());
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("getNameFunctionAndThis", "(Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Lrhino/Callable;");
          break;
        default:
          this.generateExpression(obj0, obj1);
          this.cfw.addALoad((int) this.contextLocal);
          this.addScriptRuntimeInvoke("getValueFunctionAndThis", "(Ljava/lang/Object;Lrhino/Context;)Lrhino/Callable;");
          break;
      }
      this.cfw.addALoad((int) this.contextLocal);
      this.addScriptRuntimeInvoke("lastStoredScriptable", "(Lrhino/Context;)Lrhino/Scriptable;");
    }

    [LineNumberTable(new byte[] {156, 22, 98, 98, 101, 36, 201, 109, 147, 167, 201, 104, 109, 172, 99, 234, 71, 105, 101, 138, 104, 99, 103, 100, 230, 72, 104, 104, 109, 117, 109, 108, 109, 168, 141, 232, 19, 233, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateCallArgArray([In] Node obj0, [In] Node obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      int num2 = 0;
      for (Node node = obj1; node != null; node = node.getNext())
        ++num2;
      if (num2 == 1 && this.itsOneArgArray >= (short) 0)
        this.cfw.addALoad((int) this.itsOneArgArray);
      else
        this.addNewObjectArray(num2);
      for (int k = 0; k != num2; ++k)
      {
        if (!this.isGenerator)
        {
          this.cfw.add(89);
          this.cfw.addPush(k);
        }
        if (num1 == 0)
        {
          this.generateExpression(obj1, obj0);
        }
        else
        {
          int num3 = this.nodeIsDirectCallParameter(obj1);
          if (num3 >= 0)
          {
            this.dcpLoadAsObject(num3);
          }
          else
          {
            this.generateExpression(obj1, obj0);
            if (obj1.getIntProp(8, -1) == 0)
              this.addDoubleWrap();
          }
        }
        if (this.isGenerator)
        {
          int newWordLocal = (int) this.getNewWordLocal();
          this.cfw.addAStore(newWordLocal);
          this.cfw.add(192, "[Ljava/lang/Object;");
          this.cfw.add(89);
          this.cfw.addPush(k);
          this.cfw.addALoad(newWordLocal);
          this.releaseWordLocal((short) newWordLocal);
        }
        this.cfw.add(83);
        obj1 = obj1.getNext();
      }
    }

    [LineNumberTable(new byte[] {156, 147, 130, 98, 101, 36, 233, 69, 159, 34, 104, 139, 109, 127, 28, 113, 113, 113, 113, 113, 255, 2, 70, 193, 171, 104, 104, 8, 200, 103, 104, 109, 109, 113, 109, 237, 59, 234, 72, 103, 104, 109, 109, 104, 109, 232, 59, 232, 72, 116, 100, 108, 142, 114, 142, 113, 113, 240, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitArrayLiteral([In] Node obj0, [In] Node obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      int num2 = 0;
      for (Node node = obj1; node != null; node = node.getNext())
        ++num2;
      if (num1 == 0 && (num2 > 10 || this.cfw.getCurrentCodeOffset() > 30000) && (!this.hasVarsInRegs && !this.isGenerator && !this.inLocalBlock))
      {
        if (this.literals == null)
          this.literals = (List) new LinkedList();
        this.literals.add((object) obj0);
        string methodName = new StringBuilder().append(this.codegen.getBodyMethodName(this.scriptOrFn)).append("_literal").append(this.literals.size()).toString();
        this.cfw.addALoad((int) this.funObjLocal);
        this.cfw.addALoad((int) this.contextLocal);
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.cfw.addALoad((int) this.thisObjLocal);
        this.cfw.addALoad((int) this.argsLocal);
        this.cfw.addInvoke(182, this.codegen.mainClassName, methodName, "(Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;[Ljava/lang/Object;)Lrhino/Scriptable;");
      }
      else
      {
        if (this.isGenerator)
        {
          for (int index = 0; index != num2; ++index)
          {
            this.generateExpression(obj1, obj0);
            obj1 = obj1.getNext();
          }
          this.addNewObjectArray(num2);
          for (int index = 0; index != num2; ++index)
          {
            this.cfw.add(90);
            this.cfw.add(95);
            this.cfw.addPush(num2 - index - 1);
            this.cfw.add(95);
            this.cfw.add(83);
          }
        }
        else
        {
          this.addNewObjectArray(num2);
          for (int k = 0; k != num2; ++k)
          {
            this.cfw.add(89);
            this.cfw.addPush(k);
            this.generateExpression(obj1, obj0);
            this.cfw.add(83);
            obj1 = obj1.getNext();
          }
        }
        int[] prop = (int[]) obj0.getProp(11);
        if (prop == null)
        {
          this.cfw.add(1);
          this.cfw.add(3);
        }
        else
        {
          this.cfw.addPush(OptRuntime.encodeIntArray(prop));
          this.cfw.addPush(prop.Length);
        }
        this.cfw.addALoad((int) this.contextLocal);
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.addOptRuntimeInvoke("newArrayLiteral", "([Ljava/lang/Object;Ljava/lang/String;ILrhino/Context;Lrhino/Scriptable;)Lrhino/Scriptable;");
      }
    }

    [LineNumberTable(new byte[] {156, 115, 162, 115, 163, 159, 34, 104, 139, 109, 127, 28, 113, 113, 113, 113, 113, 255, 2, 70, 161, 168, 105, 136, 143, 104, 201, 99, 99, 104, 105, 114, 99, 130, 233, 58, 232, 73, 103, 108, 114, 99, 107, 109, 109, 105, 105, 110, 105, 142, 140, 109, 233, 52, 237, 79, 172, 113, 113, 240, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitObjectLiteral([In] Node obj0, [In] Node obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      object[] prop = (object[]) obj0.getProp(12);
      int length = prop.Length;
      if (num1 == 0 && (length > 10 || this.cfw.getCurrentCodeOffset() > 30000) && (!this.hasVarsInRegs && !this.isGenerator && !this.inLocalBlock))
      {
        if (this.literals == null)
          this.literals = (List) new LinkedList();
        this.literals.add((object) obj0);
        string methodName = new StringBuilder().append(this.codegen.getBodyMethodName(this.scriptOrFn)).append("_literal").append(this.literals.size()).toString();
        this.cfw.addALoad((int) this.funObjLocal);
        this.cfw.addALoad((int) this.contextLocal);
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.cfw.addALoad((int) this.thisObjLocal);
        this.cfw.addALoad((int) this.argsLocal);
        this.cfw.addInvoke(182, this.codegen.mainClassName, methodName, "(Lrhino/Context;Lrhino/Scriptable;Lrhino/Scriptable;[Ljava/lang/Object;)Lrhino/Scriptable;");
      }
      else
      {
        if (this.isGenerator)
        {
          this.addLoadPropertyValues(obj0, obj1, length);
          this.addLoadPropertyIds(prop, length);
          this.cfw.add(95);
        }
        else
        {
          this.addLoadPropertyIds(prop, length);
          this.addLoadPropertyValues(obj0, obj1, length);
        }
        int num2 = 0;
        Node node1 = obj1;
        for (int index = 0; index != length; ++index)
        {
          switch (node1.getType())
          {
            case 152:
            case 153:
              num2 = 1;
              goto label_12;
            default:
              node1 = node1.getNext();
              continue;
          }
        }
label_12:
        if (num2 != 0)
        {
          this.cfw.addPush(length);
          this.cfw.add(188, 10);
          Node node2 = obj1;
          for (int k = 0; k != length; ++k)
          {
            this.cfw.add(89);
            this.cfw.addPush(k);
            switch (node2.getType())
            {
              case 152:
                this.cfw.add(2);
                break;
              case 153:
                this.cfw.add(4);
                break;
              default:
                this.cfw.add(3);
                break;
            }
            this.cfw.add(79);
            node2 = node2.getNext();
          }
        }
        else
          this.cfw.add(1);
        this.cfw.addALoad((int) this.contextLocal);
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.addScriptRuntimeInvoke("newObjectLiteral", "([Ljava/lang/Object;[Ljava/lang/Object;[ILrhino/Context;Lrhino/Scriptable;)Lrhino/Scriptable;");
      }
    }

    [LineNumberTable(new byte[] {170, 214, 103, 135, 159, 110, 107, 197, 108, 101, 141, 138, 108, 103, 107, 226, 73, 107, 226, 70, 107, 194, 104, 112, 113, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateIfJump([In] Node obj0, [In] Node obj1, [In] int obj2, [In] int obj3)
    {
      int type = obj0.getType();
      Node firstChild = obj0.getFirstChild();
      switch (type)
      {
        case 12:
        case 13:
        case 46:
        case 47:
          this.visitIfJumpEqOp(obj0, firstChild, obj2, obj3);
          break;
        case 14:
        case 15:
        case 16:
        case 17:
        case 52:
        case 53:
          this.visitIfJumpRelOp(obj0, firstChild, obj2, obj3);
          break;
        case 26:
          this.generateIfJump(firstChild, obj0, obj3, obj2);
          break;
        case 105:
        case 106:
          int label = this.cfw.acquireLabel();
          if (type == 106)
            this.generateIfJump(firstChild, obj0, label, obj3);
          else
            this.generateIfJump(firstChild, obj0, obj2, label);
          this.cfw.markLabel(label);
          this.generateIfJump(firstChild.getNext(), obj0, obj2, obj3);
          break;
        default:
          this.generateExpression(obj0, obj1);
          this.addScriptRuntimeInvoke("toBoolean", "(Ljava/lang/Object;)Z");
          this.cfw.add(154, obj2);
          this.cfw.add(167, obj3);
          break;
      }
    }

    [LineNumberTable(new byte[] {176, 38, 107, 114, 103, 110, 117, 108, 105, 108, 159, 0, 108, 113, 108, 108, 176, 109, 114, 109, 112, 109, 98, 115, 208, 161, 113, 113, 208})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitTypeofname([In] Node obj0)
    {
      if (this.hasVarsInRegs)
      {
        int indexForNameNode = this.fnCurrent.__\u003C\u003Efnode.getIndexForNameNode(obj0);
        if (indexForNameNode >= 0)
        {
          if (this.fnCurrent.isNumberVar(indexForNameNode))
          {
            this.cfw.addPush("number");
            return;
          }
          if (this.varIsDirectCallParameter(indexForNameNode))
          {
            int varRegister = (int) this.varRegisters[indexForNameNode];
            this.cfw.addALoad(varRegister);
            this.cfw.add(178, "java/lang/Void", "TYPE", "Ljava/lang/Class;");
            int num1 = this.cfw.acquireLabel();
            this.cfw.add(165, num1);
            int stackTop = (int) this.cfw.getStackTop();
            this.cfw.addALoad(varRegister);
            this.addScriptRuntimeInvoke("typeof", "(Ljava/lang/Object;)Ljava/lang/String;");
            int num2 = this.cfw.acquireLabel();
            this.cfw.add(167, num2);
            this.cfw.markLabel(num1, (short) stackTop);
            this.cfw.addPush("number");
            this.cfw.markLabel(num2);
            return;
          }
          this.cfw.addALoad((int) this.varRegisters[indexForNameNode]);
          this.addScriptRuntimeInvoke("typeof", "(Ljava/lang/Object;)Ljava/lang/String;");
          return;
        }
      }
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.cfw.addPush(obj0.getString());
      this.addScriptRuntimeInvoke("typeofName", "(Lrhino/Scriptable;Ljava/lang/String;)Ljava/lang/String;");
    }

    [LineNumberTable(new byte[] {176, 117, 105, 103, 159, 44, 110, 106, 109, 106, 114, 105, 107, 111, 112, 99, 112, 101, 143, 173, 101, 105, 138, 141, 99, 109, 102, 146, 102, 112, 101, 143, 141, 166, 133, 110, 111, 112, 99, 141, 112, 101, 143, 141, 99, 141, 112, 101, 105, 138, 141, 102, 99, 141, 112, 101, 143, 141, 102, 99, 141, 109, 102, 235, 69, 113, 113, 113, 108, 240, 69, 133, 139, 104, 105, 110, 113, 113, 108, 240, 70, 165, 104, 105, 110, 113, 113, 108, 113, 242, 72, 240, 72, 162, 104, 105, 113, 113, 108, 240, 70, 162, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitIncDec([In] Node obj0)
    {
      int existingIntProp = obj0.getExistingIntProp(13);
      Node firstChild1 = obj0.getFirstChild();
      switch (firstChild1.getType())
      {
        case 33:
          Node firstChild2 = firstChild1.getFirstChild();
          this.generateExpression(firstChild2, obj0);
          this.generateExpression(firstChild2.getNext(), obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.addPush(existingIntProp);
          this.addScriptRuntimeInvoke("propIncrDecr", "(Ljava/lang/Object;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;I)Ljava/lang/Object;");
          break;
        case 34:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        case 36:
          Node firstChild3 = firstChild1.getFirstChild();
          this.generateExpression(firstChild3, obj0);
          this.generateExpression(firstChild3.getNext(), obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.addPush(existingIntProp);
          if (firstChild3.getNext().getIntProp(8, -1) != -1)
          {
            this.addOptRuntimeInvoke("elemIncrDecr", "(Ljava/lang/Object;DLrhino/Context;Lrhino/Scriptable;I)Ljava/lang/Object;");
            break;
          }
          this.addScriptRuntimeInvoke("elemIncrDecr", "(Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;I)Ljava/lang/Object;");
          break;
        case 39:
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.addPush(firstChild1.getString());
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addPush(existingIntProp);
          this.addScriptRuntimeInvoke("nameIncrDecr", "(Lrhino/Scriptable;Ljava/lang/String;Lrhino/Context;I)Ljava/lang/Object;");
          break;
        case 55:
          if (!this.hasVarsInRegs)
            Kit.codeBug();
          int num1 = (existingIntProp & 2) == 0 ? 0 : 1;
          int varIndex = this.fnCurrent.getVarIndex(firstChild1);
          int varRegister = (int) this.varRegisters[varIndex];
          if (this.fnCurrent.__\u003C\u003Efnode.getParamAndVarConst()[varIndex])
          {
            if (obj0.getIntProp(8, -1) != -1)
            {
              int num2 = !this.varIsDirectCallParameter(varIndex) ? 0 : 1;
              this.cfw.addDLoad(varRegister + num2);
              if (num1 != 0)
                break;
              this.cfw.addPush(1.0);
              if ((existingIntProp & 1) == 0)
              {
                this.cfw.add(99);
                break;
              }
              this.cfw.add(103);
              break;
            }
            if (this.varIsDirectCallParameter(varIndex))
              this.dcpLoadAsObject(varRegister);
            else
              this.cfw.addALoad(varRegister);
            if (num1 != 0)
            {
              this.cfw.add(89);
              this.addObjectToDouble();
              this.cfw.add(88);
              break;
            }
            this.addObjectToDouble();
            this.cfw.addPush(1.0);
            if ((existingIntProp & 1) == 0)
              this.cfw.add(99);
            else
              this.cfw.add(103);
            this.addDoubleWrap();
            break;
          }
          if (obj0.getIntProp(8, -1) != -1)
          {
            int num2 = !this.varIsDirectCallParameter(varIndex) ? 0 : 1;
            this.cfw.addDLoad(varRegister + num2);
            if (num1 != 0)
              this.cfw.add(92);
            this.cfw.addPush(1.0);
            if ((existingIntProp & 1) == 0)
              this.cfw.add(99);
            else
              this.cfw.add(103);
            if (num1 == 0)
              this.cfw.add(92);
            this.cfw.addDStore(varRegister + num2);
            break;
          }
          if (this.varIsDirectCallParameter(varIndex))
            this.dcpLoadAsObject(varRegister);
          else
            this.cfw.addALoad(varRegister);
          this.addObjectToDouble();
          if (num1 != 0)
            this.cfw.add(92);
          this.cfw.addPush(1.0);
          if ((existingIntProp & 1) == 0)
            this.cfw.add(99);
          else
            this.cfw.add(103);
          this.addDoubleWrap();
          if (num1 == 0)
            this.cfw.add(89);
          this.cfw.addAStore(varRegister);
          if (num1 == 0)
            break;
          this.addDoubleWrap();
          break;
        case 68:
          this.generateExpression(firstChild1.getFirstChild(), obj0);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.cfw.addPush(existingIntProp);
          this.addScriptRuntimeInvoke("refIncrDecr", "(Lrhino/Ref;Lrhino/Context;Lrhino/Scriptable;I)Ljava/lang/Object;");
          break;
        default:
          Codegen.badTree();
          break;
      }
    }

    [LineNumberTable(new byte[] {177, 30, 105, 100, 104, 109, 142, 104, 104, 104, 102, 109, 109, 102, 108, 99, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitArithmetic([In] Node obj0, [In] int obj1, [In] Node obj2, [In] Node obj3)
    {
      if (obj0.getIntProp(8, -1) != -1)
      {
        this.generateExpression(obj2, obj0);
        this.generateExpression(obj2.getNext(), obj0);
        this.cfw.add(obj1);
      }
      else
      {
        int num = BodyCodegen.isArithmeticNode(obj3) ? 1 : 0;
        this.generateExpression(obj2, obj0);
        if (!BodyCodegen.isArithmeticNode(obj2))
          this.addObjectToDouble();
        this.generateExpression(obj2.getNext(), obj0);
        if (!BodyCodegen.isArithmeticNode(obj2.getNext()))
          this.addObjectToDouble();
        this.cfw.add(obj1);
        if (num != 0)
          return;
        this.addDoubleWrap();
      }
    }

    [LineNumberTable(new byte[] {177, 51, 105, 232, 69, 101, 112, 109, 176, 109, 109, 109, 112, 102, 129, 100, 112, 109, 146, 112, 109, 144, 159, 24, 112, 130, 112, 130, 109, 130, 109, 130, 109, 130, 139, 112, 100, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitBitOp([In] Node obj0, [In] int obj1, [In] Node obj2)
    {
      int intProp = obj0.getIntProp(8, -1);
      this.generateExpression(obj2, obj0);
      if (obj1 == 20)
      {
        this.addScriptRuntimeInvoke("toUint32", "(Ljava/lang/Object;)J");
        this.generateExpression(obj2.getNext(), obj0);
        this.addScriptRuntimeInvoke("toInt32", "(Ljava/lang/Object;)I");
        this.cfw.addPush(31);
        this.cfw.add(126);
        this.cfw.add(125);
        this.cfw.add(138);
        this.addDoubleWrap();
      }
      else
      {
        if (intProp == -1)
        {
          this.addScriptRuntimeInvoke("toInt32", "(Ljava/lang/Object;)I");
          this.generateExpression(obj2.getNext(), obj0);
          this.addScriptRuntimeInvoke("toInt32", "(Ljava/lang/Object;)I");
        }
        else
        {
          this.addScriptRuntimeInvoke("toInt32", "(D)I");
          this.generateExpression(obj2.getNext(), obj0);
          this.addScriptRuntimeInvoke("toInt32", "(D)I");
        }
        switch (obj1)
        {
          case 9:
            this.cfw.add(128);
            break;
          case 10:
            this.cfw.add(130);
            break;
          case 11:
            this.cfw.add(126);
            break;
          case 18:
            this.cfw.add(120);
            break;
          case 19:
            this.cfw.add(122);
            break;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
        }
        this.cfw.add(135);
        if (intProp != -1)
          return;
        this.addDoubleWrap();
      }
    }

    [LineNumberTable(new byte[] {179, 247, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addObjectToDouble() => this.addScriptRuntimeInvoke("toNumber", "(Ljava/lang/Object;)D");

    [LineNumberTable(new byte[] {177, 149, 116, 103, 103, 106, 104, 104, 113, 252, 70, 113, 114, 129, 105, 104, 105, 199, 132, 106, 100, 137, 104, 166, 132, 106, 101, 138, 104, 166, 175, 175, 109, 109, 108, 223, 0, 114, 110, 104, 106, 154, 109, 109, 109, 223, 0, 114, 108, 102, 111, 106, 154, 141, 108, 141, 98, 104, 168, 106, 141, 152, 205, 113, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitIfJumpRelOp([In] Node obj0, [In] Node obj1, [In] int obj2, [In] int obj3)
    {
      if (obj2 == -1 || obj3 == -1)
        throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
      int type = obj0.getType();
      Node next = obj1.getNext();
      if (type == 53 || type == 52)
      {
        this.generateExpression(obj1, obj0);
        this.generateExpression(next, obj0);
        this.cfw.addALoad((int) this.contextLocal);
        this.addScriptRuntimeInvoke(type != 53 ? "in" : "instanceOf", "(Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;)Z");
        this.cfw.add(154, obj2);
        this.cfw.add(167, obj3);
      }
      else
      {
        int intProp = obj0.getIntProp(8, -1);
        int local1 = this.nodeIsDirectCallParameter(obj1);
        int local2 = this.nodeIsDirectCallParameter(next);
        switch (intProp)
        {
          case -1:
            if (local1 != -1 && local2 != -1)
            {
              int stackTop = (int) this.cfw.getStackTop();
              int num1 = this.cfw.acquireLabel();
              this.cfw.addALoad(local1);
              this.cfw.add(178, "java/lang/Void", "TYPE", "Ljava/lang/Class;");
              this.cfw.add(166, num1);
              this.cfw.addDLoad(local1 + 1);
              this.dcpLoadAsNumber(local2);
              this.genSimpleCompare(type, obj2, obj3);
              if (stackTop != (int) this.cfw.getStackTop())
                throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
              this.cfw.markLabel(num1);
              int num2 = this.cfw.acquireLabel();
              this.cfw.addALoad(local2);
              this.cfw.add(178, "java/lang/Void", "TYPE", "Ljava/lang/Class;");
              this.cfw.add(166, num2);
              this.cfw.addALoad(local1);
              this.addObjectToDouble();
              this.cfw.addDLoad(local2 + 1);
              this.genSimpleCompare(type, obj2, obj3);
              if (stackTop != (int) this.cfw.getStackTop())
                throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
              this.cfw.markLabel(num2);
              this.cfw.addALoad(local1);
              this.cfw.addALoad(local2);
            }
            else
            {
              this.generateExpression(obj1, obj0);
              this.generateExpression(next, obj0);
            }
            if (type == 17 || type == 16)
              this.cfw.add(95);
            this.addScriptRuntimeInvoke(type == 14 || type == 16 ? "cmp_LT" : "cmp_LE", "(Ljava/lang/Object;Ljava/lang/Object;)Z");
            this.cfw.add(154, obj2);
            this.cfw.add(167, obj3);
            return;
          case 2:
            if (local1 != -1)
            {
              this.dcpLoadAsNumber(local1);
              break;
            }
            this.generateExpression(obj1, obj0);
            this.addObjectToDouble();
            break;
          default:
            this.generateExpression(obj1, obj0);
            break;
        }
        if (intProp != 1)
          this.generateExpression(next, obj0);
        else if (local2 != -1)
        {
          this.dcpLoadAsNumber(local2);
        }
        else
        {
          this.generateExpression(next, obj0);
          this.addObjectToDouble();
        }
        this.genSimpleCompare(type, obj2, obj3);
      }
    }

    [LineNumberTable(new byte[] {180, 26, 108, 108, 159, 0, 113, 108, 159, 0, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addJumpedBooleanWrap([In] int obj0, [In] int obj1)
    {
      this.cfw.markLabel(obj1);
      int num = this.cfw.acquireLabel();
      this.cfw.add(178, "java/lang/Boolean", "FALSE", "Ljava/lang/Boolean;");
      this.cfw.add(167, num);
      this.cfw.markLabel(obj0);
      this.cfw.add(178, "java/lang/Boolean", "TRUE", "Ljava/lang/Boolean;");
      this.cfw.markLabel(num);
      this.cfw.adjustStackTop(-1);
    }

    [LineNumberTable(new byte[] {177, 252, 148, 108, 103, 167, 151, 106, 131, 104, 106, 146, 109, 101, 133, 112, 98, 100, 131, 109, 108, 113, 109, 109, 113, 110, 107, 145, 151, 104, 104, 111, 104, 110, 108, 223, 0, 109, 114, 110, 115, 112, 101, 147, 113, 114, 237, 69, 104, 200, 159, 5, 103, 103, 130, 103, 103, 130, 103, 103, 130, 103, 103, 130, 139, 205, 110, 146, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitIfJumpEqOp([In] Node obj0, [In] Node obj1, [In] int obj2, [In] int obj3)
    {
      if (obj2 == -1 || obj3 == -1)
        throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
      int stackTop1 = (int) this.cfw.getStackTop();
      int type = obj0.getType();
      Node next = obj1.getNext();
      if (obj1.getType() == 42 || next.getType() == 42)
      {
        if (obj1.getType() == 42)
          obj1 = next;
        this.generateExpression(obj1, obj0);
        switch (type)
        {
          case 12:
            this.cfw.add(89);
            int num1 = this.cfw.acquireLabel();
            this.cfw.add(199, num1);
            int stackTop2 = (int) this.cfw.getStackTop();
            this.cfw.add(87);
            this.cfw.add(167, obj2);
            this.cfw.markLabel(num1, (short) stackTop2);
            Codegen.pushUndefined(this.cfw);
            this.cfw.add(165, obj2);
            break;
          case 13:
            int num2 = obj2;
            obj2 = obj3;
            obj3 = num2;
            goto case 12;
          case 46:
          case 47:
            this.cfw.add(type != 46 ? 199 : 198, obj2);
            break;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
        }
        this.cfw.add(167, obj3);
      }
      else
      {
        int local = this.nodeIsDirectCallParameter(obj1);
        if (local != -1 && next.getType() == 150)
        {
          Node firstChild = next.getFirstChild();
          if (firstChild.getType() == 40)
          {
            this.cfw.addALoad(local);
            this.cfw.add(178, "java/lang/Void", "TYPE", "Ljava/lang/Class;");
            int num = this.cfw.acquireLabel();
            this.cfw.add(166, num);
            this.cfw.addDLoad(local + 1);
            this.cfw.addPush(firstChild.getDouble());
            this.cfw.add(151);
            if (type == 12)
              this.cfw.add(153, obj2);
            else
              this.cfw.add(154, obj2);
            this.cfw.add(167, obj3);
            this.cfw.markLabel(num);
          }
        }
        this.generateExpression(obj1, obj0);
        this.generateExpression(next, obj0);
        string str;
        int theOpCode;
        switch (type)
        {
          case 12:
            str = "eq";
            theOpCode = 154;
            break;
          case 13:
            str = "eq";
            theOpCode = 153;
            break;
          case 46:
            str = "shallowEq";
            theOpCode = 154;
            break;
          case 47:
            str = "shallowEq";
            theOpCode = 153;
            break;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
        }
        this.addScriptRuntimeInvoke(str, "(Ljava/lang/Object;Ljava/lang/Object;)Z");
        this.cfw.add(theOpCode, obj2);
        this.cfw.add(167, obj3);
      }
      if (stackTop1 != (int) this.cfw.getStackTop())
        throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
    }

    [LineNumberTable(new byte[] {179, 13, 104, 103, 104, 106, 113, 113, 240, 71, 225, 70, 103, 111, 113, 242, 71, 113, 113, 240, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitGetProp([In] Node obj0, [In] Node obj1)
    {
      this.generateExpression(obj1, obj0);
      Node next = obj1.getNext();
      this.generateExpression(next, obj0);
      if (obj0.getType() == 34)
      {
        this.cfw.addALoad((int) this.contextLocal);
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.addScriptRuntimeInvoke("getObjectPropNoWarn", "(Ljava/lang/Object;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
      }
      else if (obj1.getType() == 43 && next.getType() == 41)
      {
        this.cfw.addALoad((int) this.contextLocal);
        this.addScriptRuntimeInvoke("getObjectProp", "(Lrhino/Scriptable;Ljava/lang/String;Lrhino/Context;)Ljava/lang/Object;");
      }
      else
      {
        this.cfw.addALoad((int) this.contextLocal);
        this.cfw.addALoad((int) this.variableObjectLocal);
        this.addScriptRuntimeInvoke("getObjectProp", "(Ljava/lang/Object;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
      }
    }

    [LineNumberTable(new byte[] {178, 149, 110, 109, 105, 233, 69, 107, 137, 137, 110, 142, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitGetVar([In] Node obj0)
    {
      if (!this.hasVarsInRegs)
        Kit.codeBug();
      int varIndex = this.fnCurrent.getVarIndex(obj0);
      int varRegister = (int) this.varRegisters[varIndex];
      if (this.varIsDirectCallParameter(varIndex))
      {
        if (obj0.getIntProp(8, -1) != -1)
          this.dcpLoadAsNumber(varRegister);
        else
          this.dcpLoadAsObject(varRegister);
      }
      else if (this.fnCurrent.isNumberVar(varIndex))
        this.cfw.addDLoad(varRegister);
      else
        this.cfw.addALoad(varRegister);
    }

    [LineNumberTable(new byte[] {178, 94, 108, 99, 104, 138, 113, 113, 108, 240, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitSetName([In] Node obj0, [In] Node obj1)
    {
      string k = obj0.getFirstChild().getString();
      for (; obj1 != null; obj1 = obj1.getNext())
        this.generateExpression(obj1, obj0);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.cfw.addPush(k);
      this.addScriptRuntimeInvoke("setName", "(Lrhino/Scriptable;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;Ljava/lang/String;)Ljava/lang/Object;");
    }

    [LineNumberTable(new byte[] {178, 113, 108, 99, 104, 138, 113, 113, 108, 240, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitStrictSetName([In] Node obj0, [In] Node obj1)
    {
      string k = obj0.getFirstChild().getString();
      for (; obj1 != null; obj1 = obj1.getNext())
        this.generateExpression(obj1, obj0);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.cfw.addPush(k);
      this.addScriptRuntimeInvoke("strictSetName", "(Lrhino/Scriptable;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;Ljava/lang/String;)Ljava/lang/Object;");
    }

    [LineNumberTable(new byte[] {178, 132, 108, 99, 104, 138, 113, 108, 240, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitSetConst([In] Node obj0, [In] Node obj1)
    {
      string k = obj0.getFirstChild().getString();
      for (; obj1 != null; obj1 = obj1.getNext())
        this.generateExpression(obj1, obj0);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addPush(k);
      this.addScriptRuntimeInvoke("setConst", "(Lrhino/Scriptable;Ljava/lang/Object;Lrhino/Context;Ljava/lang/String;)Ljava/lang/Object;");
    }

    [LineNumberTable(new byte[] {179, 55, 98, 104, 104, 104, 141, 98, 104, 104, 139, 173, 107, 105, 113, 242, 71, 113, 113, 240, 73, 104, 113, 113, 240, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitSetProp([In] int obj0, [In] Node obj1, [In] Node obj2)
    {
      Node node1 = obj2;
      this.generateExpression(obj2, obj1);
      obj2 = obj2.getNext();
      if (obj0 == 140)
        this.cfw.add(89);
      Node node2 = obj2;
      this.generateExpression(obj2, obj1);
      obj2 = obj2.getNext();
      if (obj0 == 140)
      {
        this.cfw.add(90);
        if (node1.getType() == 43 && node2.getType() == 41)
        {
          this.cfw.addALoad((int) this.contextLocal);
          this.addScriptRuntimeInvoke("getObjectProp", "(Lrhino/Scriptable;Ljava/lang/String;Lrhino/Context;)Ljava/lang/Object;");
        }
        else
        {
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("getObjectProp", "(Ljava/lang/Object;Ljava/lang/String;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
        }
      }
      this.generateExpression(obj2, obj1);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.addScriptRuntimeInvoke("setObjectProp", "(Ljava/lang/Object;Ljava/lang/String;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
    }

    [LineNumberTable(new byte[] {179, 104, 104, 104, 104, 141, 104, 104, 111, 107, 163, 109, 113, 113, 242, 73, 109, 113, 113, 240, 73, 104, 113, 113, 99, 242, 73, 240, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitSetElem([In] int obj0, [In] Node obj1, [In] Node obj2)
    {
      this.generateExpression(obj2, obj1);
      obj2 = obj2.getNext();
      if (obj0 == 141)
        this.cfw.add(89);
      this.generateExpression(obj2, obj1);
      obj2 = obj2.getNext();
      int num = obj1.getIntProp(8, -1) != -1 ? 1 : 0;
      if (obj0 == 141)
      {
        if (num != 0)
        {
          this.cfw.add(93);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("getObjectIndex", "(Ljava/lang/Object;DLrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
        }
        else
        {
          this.cfw.add(90);
          this.cfw.addALoad((int) this.contextLocal);
          this.cfw.addALoad((int) this.variableObjectLocal);
          this.addScriptRuntimeInvoke("getObjectElem", "(Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
        }
      }
      this.generateExpression(obj2, obj1);
      this.cfw.addALoad((int) this.contextLocal);
      this.cfw.addALoad((int) this.variableObjectLocal);
      if (num != 0)
        this.addScriptRuntimeInvoke("setObjectIndex", "(Ljava/lang/Object;DLjava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
      else
        this.addScriptRuntimeInvoke("setObjectElem", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/lang/Object;Lrhino/Context;Lrhino/Scriptable;)Ljava/lang/Object;");
    }

    [LineNumberTable(new byte[] {170, 52, 103, 99, 119, 130, 104, 99, 130, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node findNestedYield([In] Node obj0)
    {
      for (Node node = obj0.getFirstChild(); node != null; node = node.getNext())
      {
        if (node.getType() == 73 || node.getType() == 166)
          return node;
        Node nestedYield = this.findNestedYield(node);
        if (nestedYield != null)
          return nestedYield;
      }
      return (Node) null;
    }

    [LineNumberTable(new byte[] {156, 213, 98, 108, 114, 99, 102, 102, 109, 109, 108, 109, 237, 59, 230, 72, 205, 103, 99, 138, 139, 141, 117, 109, 109, 255, 0, 69, 105, 136, 137, 208, 209, 99, 102, 106, 109, 109, 109, 237, 60, 232, 70, 205, 99, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateLocalYieldPoint([In] Node obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      int stackTop = (int) this.cfw.getStackTop();
      this.maxStack = Math.max(this.maxStack, stackTop);
      if (stackTop != 0)
      {
        this.generateGetGeneratorStackState();
        for (int k = 0; k < stackTop; ++k)
        {
          this.cfw.add(90);
          this.cfw.add(95);
          this.cfw.addLoadConstant(k);
          this.cfw.add(95);
          this.cfw.add(83);
        }
        this.cfw.add(87);
      }
      Node firstChild = obj0.getFirstChild();
      if (firstChild != null)
        this.generateExpression(firstChild, obj0);
      else
        Codegen.pushUndefined(this.cfw);
      if (obj0.getType() == 166)
      {
        this.cfw.add(187, "rhino/ES6Generator$YieldStarResult");
        this.cfw.add(90);
        this.cfw.add(95);
        this.cfw.addInvoke(183, "rhino/ES6Generator$YieldStarResult", "<init>", "(Ljava/lang/Object;)V");
      }
      int nextGeneratorState = this.getNextGeneratorState(obj0);
      this.generateSetGeneratorResumptionPoint(nextGeneratorState);
      int num2 = this.generateSaveLocals(obj0) ? 1 : 0;
      this.cfw.add(176);
      this.generateCheckForThrowOrClose(this.getTargetLabel(obj0), num2 != 0, nextGeneratorState);
      if (stackTop != 0)
      {
        this.generateGetGeneratorStackState();
        for (int k = stackTop - 1; k >= 0; k += -1)
        {
          this.cfw.add(89);
          this.cfw.addLoadConstant(k);
          this.cfw.add(50);
          this.cfw.add(95);
        }
        this.cfw.add(87);
      }
      if (num1 == 0)
        return;
      this.cfw.addALoad((int) this.argsLocal);
    }

    [LineNumberTable(new byte[] {166, 11, 113, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateGetGeneratorStackState()
    {
      this.cfw.addALoad((int) this.generatorStateLocal);
      this.addOptRuntimeInvoke("getGeneratorStackState", "(Ljava/lang/Object;)[Ljava/lang/Object;");
    }

    [LineNumberTable(new byte[] {175, 226, 98, 107, 106, 4, 230, 69, 99, 114, 194, 178, 103, 98, 109, 107, 101, 228, 61, 232, 72, 178, 102, 104, 109, 109, 111, 237, 60, 232, 71, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool generateSaveLocals([In] Node obj0)
    {
      int length = 0;
      for (int index = 0; index < (int) this.firstFreeLocal; ++index)
      {
        if (this.locals[index] != 0)
          ++length;
      }
      if (length == 0)
      {
        ((FunctionNode) this.scriptOrFn).addLiveLocals(obj0, (int[]) null);
        return false;
      }
      this.maxLocals = Math.max(this.maxLocals, length);
      int[] locals = new int[length];
      int index1 = 0;
      for (int index2 = 0; index2 < (int) this.firstFreeLocal; ++index2)
      {
        if (this.locals[index2] != 0)
        {
          locals[index1] = index2;
          ++index1;
        }
      }
      ((FunctionNode) this.scriptOrFn).addLiveLocals(obj0, locals);
      this.generateGetGeneratorLocalsState();
      for (int k = 0; k < length; ++k)
      {
        this.cfw.add(89);
        this.cfw.addLoadConstant(k);
        this.cfw.addALoad(locals[k]);
        this.cfw.add(83);
      }
      this.cfw.add(87);
      return true;
    }

    [LineNumberTable(new byte[] {171, 80, 114, 118, 140, 109, 108, 108, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addGotoWithReturn([In] Node obj0)
    {
      BodyCodegen.FinallyReturnPoint finallyReturnPoint = (BodyCodegen.FinallyReturnPoint) this.finallys.get((object) obj0);
      this.cfw.addLoadConstant(finallyReturnPoint.jsrPoints.size());
      this.addGoto(obj0, 167);
      this.cfw.add(87);
      int label = this.cfw.acquireLabel();
      this.cfw.markLabel(label);
      finallyReturnPoint.jsrPoints.add((object) Integer.valueOf(label));
    }

    [LineNumberTable(new byte[] {175, 196, 108, 108, 108, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void inlineFinally([In] Node obj0)
    {
      int label1 = this.cfw.acquireLabel();
      int label2 = this.cfw.acquireLabel();
      this.cfw.markLabel(label1);
      this.inlineFinally(obj0, label1, label2);
      this.cfw.markLabel(label2);
    }

    [LineNumberTable(new byte[] {179, 242, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addGoto([In] Node obj0, [In] int obj1)
    {
      int targetLabel = this.getTargetLabel(obj0);
      this.cfw.add(obj1, targetLabel);
    }

    [LineNumberTable(new byte[] {179, 251, 99, 105, 147, 255, 2, 69, 108, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addNewObjectArray([In] int obj0)
    {
      if (obj0 == 0)
      {
        if (this.itsZeroArgArray >= (short) 0)
          this.cfw.addALoad((int) this.itsZeroArgArray);
        else
          this.cfw.add(178, "rhino/ScriptRuntime", "emptyArgs", "[Ljava/lang/Object;");
      }
      else
      {
        this.cfw.addPush(obj0);
        this.cfw.add(189, "java/lang/Object");
      }
    }

    [LineNumberTable(new byte[] {171, 215, 139, 102, 103, 120, 143, 136, 232, 57, 230, 73, 103, 102, 109, 109, 112, 109, 237, 59, 235, 72, 103, 98, 105, 109, 108, 103, 120, 143, 136, 109, 231, 54, 233, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addLoadPropertyValues([In] Node obj0, [In] Node obj1, [In] int obj2)
    {
      if (this.isGenerator)
      {
        for (int index = 0; index != obj2; ++index)
        {
          switch (obj1.getType())
          {
            case 152:
            case 153:
            case 164:
              this.generateExpression(obj1.getFirstChild(), obj0);
              break;
            default:
              this.generateExpression(obj1, obj0);
              break;
          }
          obj1 = obj1.getNext();
        }
        this.addNewObjectArray(obj2);
        for (int index = 0; index != obj2; ++index)
        {
          this.cfw.add(90);
          this.cfw.add(95);
          this.cfw.addPush(obj2 - index - 1);
          this.cfw.add(95);
          this.cfw.add(83);
        }
      }
      else
      {
        this.addNewObjectArray(obj2);
        Node node = obj1;
        for (int k = 0; k != obj2; ++k)
        {
          this.cfw.add(89);
          this.cfw.addPush(k);
          switch (node.getType())
          {
            case 152:
            case 153:
            case 164:
              this.generateExpression(node.getFirstChild(), obj0);
              break;
            default:
              this.generateExpression(node, obj0);
              break;
          }
          this.cfw.add(83);
          node = node.getNext();
        }
      }
    }

    [LineNumberTable(new byte[] {171, 198, 103, 105, 109, 108, 100, 104, 147, 118, 144, 237, 54, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addLoadPropertyIds([In] object[] obj0, [In] int obj1)
    {
      this.addNewObjectArray(obj1);
      for (int k = 0; k != obj1; ++k)
      {
        this.cfw.add(89);
        this.cfw.addPush(k);
        object obj = obj0[k];
        if (obj is string)
        {
          this.cfw.addPush((string) obj);
        }
        else
        {
          this.cfw.addPush(((Integer) obj).intValue());
          this.addScriptRuntimeInvoke("wrapInt", "(I)Ljava/lang/Integer;");
        }
        this.cfw.add(83);
      }
    }

    [LineNumberTable(new byte[] {177, 105, 154, 109, 110, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int nodeIsDirectCallParameter([In] Node obj0)
    {
      if (obj0.getType() == 55 && this.inDirectCallFunction && !this.itsForcedObjectParameters)
      {
        int varIndex = this.fnCurrent.getVarIndex(obj0);
        if (this.fnCurrent.isParameter(varIndex))
          return (int) this.varRegisters[varIndex];
      }
      return -1;
    }

    [LineNumberTable(new byte[] {179, 224, 108, 223, 0, 108, 113, 108, 108, 108, 113, 109, 110, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void dcpLoadAsObject([In] int obj0)
    {
      this.cfw.addALoad(obj0);
      this.cfw.add(178, "java/lang/Void", "TYPE", "Ljava/lang/Class;");
      int num1 = this.cfw.acquireLabel();
      this.cfw.add(165, num1);
      int stackTop = (int) this.cfw.getStackTop();
      this.cfw.addALoad(obj0);
      int num2 = this.cfw.acquireLabel();
      this.cfw.add(167, num2);
      this.cfw.markLabel(num1, (short) stackTop);
      this.cfw.addDLoad(obj0 + 1);
      this.addDoubleWrap();
      this.cfw.markLabel(num2);
    }

    [LineNumberTable(new byte[] {155, 199, 130, 100, 141, 173, 173, 108, 145, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateCatchBlock([In] int obj0, [In] short obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      int local = (int) obj1;
      if (obj4 == 0)
        obj4 = this.cfw.acquireLabel();
      this.cfw.markHandler(obj4);
      this.cfw.addAStore(obj3);
      this.cfw.addALoad(local);
      this.cfw.addAStore((int) this.variableObjectLocal);
      this.cfw.add(167, obj2);
    }

    [LineNumberTable(new byte[] {175, 184, 104, 102, 103, 109, 99, 103, 137, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void inlineFinally([In] Node obj0, [In] int obj1, [In] int obj2)
    {
      Node finallyAtTarget = this.getFinallyAtTarget(obj0);
      finallyAtTarget.resetTargets();
      Node node = finallyAtTarget.getFirstChild();
      this.exceptionManager.markInlineFinallyStart(finallyAtTarget, obj1);
      for (; node != null; node = node.getNext())
        this.generateStatement(node);
      this.exceptionManager.markInlineFinallyEnd(finallyAtTarget, obj2);
    }

    [LineNumberTable(4582)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool varIsDirectCallParameter([In] int obj0) => this.fnCurrent.isParameter(obj0) && this.inDirectCallFunction && !this.itsForcedObjectParameters;

    [LineNumberTable(new byte[] {177, 21, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isArithmeticNode([In] Node obj0)
    {
      switch (obj0.getType())
      {
        case 22:
        case 23:
        case 24:
        case 25:
          return true;
        default:
          return false;
      }
    }

    [LineNumberTable(new byte[] {179, 206, 108, 223, 0, 108, 113, 108, 108, 102, 108, 113, 109, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void dcpLoadAsNumber([In] int obj0)
    {
      this.cfw.addALoad(obj0);
      this.cfw.add(178, "java/lang/Void", "TYPE", "Ljava/lang/Class;");
      int num1 = this.cfw.acquireLabel();
      this.cfw.add(165, num1);
      int stackTop = (int) this.cfw.getStackTop();
      this.cfw.addALoad(obj0);
      this.addObjectToDouble();
      int num2 = this.cfw.acquireLabel();
      this.cfw.add(167, num2);
      this.cfw.markLabel(num1, (short) stackTop);
      this.cfw.addDLoad(obj0 + 1);
      this.cfw.markLabel(num2);
    }

    [LineNumberTable(new byte[] {177, 121, 111, 158, 112, 113, 133, 112, 113, 130, 112, 113, 130, 112, 113, 130, 171, 100, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void genSimpleCompare([In] int obj0, [In] int obj1, [In] int obj2)
    {
      if (obj1 == -1)
        throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
      switch (obj0)
      {
        case 14:
          this.cfw.add(152);
          this.cfw.add(155, obj1);
          break;
        case 15:
          this.cfw.add(152);
          this.cfw.add(158, obj1);
          break;
        case 16:
          this.cfw.add(151);
          this.cfw.add(157, obj1);
          break;
        case 17:
          this.cfw.add(151);
          this.cfw.add(156, obj1);
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Codegen.badTree());
      }
      if (obj2 == -1)
        return;
      this.cfw.add(167, obj2);
    }

    [LineNumberTable(new byte[] {180, 61, 154, 103, 98, 164, 113, 102, 103, 102, 226, 61, 230, 70, 98, 164, 167, 103, 100, 100, 102, 100, 134, 105, 108, 101, 104, 110, 108, 227, 59, 232, 73, 195})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private short getNewWordIntern([In] int obj0)
    {
      if (!BodyCodegen.\u0024assertionsDisabled && (obj0 < 1 || obj0 > 3))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      int[] locals = this.locals;
      int index1 = -1;
      if (obj0 > 1)
      {
        int firstFreeLocal = (int) this.firstFreeLocal;
label_4:
        if (firstFreeLocal + obj0 <= 1024)
        {
          for (int index2 = 0; index2 < obj0; ++index2)
          {
            if (locals[firstFreeLocal + index2] != 0)
            {
              firstFreeLocal += index2 + 1;
              goto label_4;
            }
          }
          index1 = firstFreeLocal;
        }
      }
      else
        index1 = (int) this.firstFreeLocal;
      if (index1 != -1)
      {
        locals[index1] = 1;
        if (obj0 > 1)
          locals[index1 + 1] = 1;
        if (obj0 > 2)
          locals[index1 + 2] = 1;
        if (index1 != (int) this.firstFreeLocal)
          return (short) index1;
        for (int index2 = index1 + obj0; index2 < 1024; ++index2)
        {
          if (locals[index2] == 0)
          {
            this.firstFreeLocal = (short) index2;
            if ((int) this.localsMax < (int) this.firstFreeLocal)
              this.localsMax = this.firstFreeLocal;
            return (short) index1;
          }
        }
      }
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError("Program too complex (out of locals)"));
    }

    [LineNumberTable(new byte[] {164, 67, 232, 171, 90, 236, 165, 9, 103, 231, 74, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal BodyCodegen()
    {
      BodyCodegen bodyCodegen = this;
      this.exceptionManager = new BodyCodegen.ExceptionManager(this);
      this.maxLocals = 0;
      this.maxStack = 0;
      this.unnestedYieldCount = 0;
      this.unnestedYields = new IdentityHashMap();
    }

    [LineNumberTable(new byte[] {164, 69, 177, 134, 168, 255, 16, 70, 191, 25, 98, 127, 4, 39, 229, 69, 134, 104, 142, 135, 103, 134, 148, 168, 166, 139, 115, 114, 104, 149, 106, 130, 106, 130, 237, 53, 233, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void generateBodyCode()
    {
      this.isGenerator = Codegen.isGenerator(this.scriptOrFn);
      this.initBodyGeneration();
      if (this.isGenerator)
      {
        string type = new StringBuilder().append("(").append(this.codegen.mainClassSignature).append("Lrhino/Context;Lrhino/Scriptable;Ljava/lang/Object;Ljava/lang/Object;I)Ljava/lang/Object;").toString();
        this.cfw.startMethod(new StringBuilder().append(this.codegen.getBodyMethodName(this.scriptOrFn)).append("_gen").toString(), type, (short) 10);
      }
      else
        this.cfw.startMethod(this.codegen.getBodyMethodName(this.scriptOrFn), this.codegen.getBodyMethodSignature(this.scriptOrFn), (short) 10);
      this.generatePrologue();
      this.generateStatement(this.fnCurrent == null ? (Node) this.scriptOrFn : this.scriptOrFn.getLastChild());
      this.generateEpilogue();
      this.cfw.stopMethod((short) ((int) this.localsMax + 1));
      if (this.isGenerator)
        this.generateGenerator();
      if (this.literals == null)
        return;
      for (int index = 0; index < this.literals.size(); ++index)
      {
        Node node = (Node) this.literals.get(index);
        int type = node.getType();
        switch (type)
        {
          case 66:
            this.generateArrayLiteralFactory(node, index + 1);
            break;
          case 67:
            this.generateObjectLiteralFactory(node, index + 1);
            break;
          default:
            Kit.codeBug(Token.typeToName(type));
            break;
        }
      }
    }

    [LineNumberTable(new byte[] {179, 165, 103, 104, 113, 208, 241, 69, 108, 108, 108, 141, 109, 112, 113, 208, 109, 145, 113, 176, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitDotQuery([In] Node obj0, [In] Node obj1)
    {
      this.updateLineNumber(obj0);
      this.generateExpression(obj1, obj0);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.addScriptRuntimeInvoke("enterDotQuery", "(Ljava/lang/Object;Lrhino/Scriptable;)Lrhino/Scriptable;");
      this.cfw.addAStore((int) this.variableObjectLocal);
      this.cfw.add(1);
      int num = this.cfw.acquireLabel();
      this.cfw.markLabel(num);
      this.cfw.add(87);
      this.generateExpression(obj1.getNext(), obj0);
      this.addScriptRuntimeInvoke("toBoolean", "(Ljava/lang/Object;)Z");
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.addScriptRuntimeInvoke("updateDotQuery", "(ZLrhino/Scriptable;)Ljava/lang/Object;");
      this.cfw.add(89);
      this.cfw.add(198, num);
      this.cfw.addALoad((int) this.variableObjectLocal);
      this.addScriptRuntimeInvoke("leaveDotQuery", "(Lrhino/Scriptable;)Lrhino/Scriptable;");
      this.cfw.addAStore((int) this.variableObjectLocal);
    }

    [LineNumberTable(1205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BodyCodegen()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.optimizer.BodyCodegen"))
        return;
      BodyCodegen.\u0024assertionsDisabled = !((Class) ClassLiteral<BodyCodegen>.Value).desiredAssertionStatus();
    }

    [InnerClass]
    internal class ExceptionManager : Object
    {
      [Modifiers]
      [Signature("Ljava/util/LinkedList<Lrhino/optimizer/BodyCodegen$ExceptionManager$ExceptionInfo;>;")]
      private LinkedList exceptionInfo;
      [Modifiers]
      internal BodyCodegen this\u00240;

      [LineNumberTable(4088)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private BodyCodegen.ExceptionManager.ExceptionInfo getTop() => (BodyCodegen.ExceptionManager.ExceptionInfo) this.exceptionInfo.getLast();

      [LineNumberTable(new byte[] {174, 251, 103, 105, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void addHandler([In] int obj0, [In] int obj1, [In] int obj2)
      {
        BodyCodegen.ExceptionManager.ExceptionInfo top = this.getTop();
        top.handlerLabels[obj0] = obj1;
        top.exceptionStarts[obj0] = obj2;
      }

      [LineNumberTable(new byte[] {175, 118, 106, 176, 105, 114, 114, 100, 191, 4, 229, 61, 229, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void endCatch([In] BodyCodegen.ExceptionManager.ExceptionInfo obj0, [In] int obj1, [In] int obj2)
      {
        if (obj0.exceptionStarts[obj1] == 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("bad exception start");
        }
        if (this.this\u00240.cfw.getLabelPC(obj0.exceptionStarts[obj1]) == this.this\u00240.cfw.getLabelPC(obj2))
          return;
        this.this\u00240.cfw.addExceptionHandler(obj0.exceptionStarts[obj1], obj2, obj0.handlerLabels[obj1], BodyCodegen.access\u0024100(this.this\u00240, obj1));
      }

      [LineNumberTable(new byte[] {174, 227, 111, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ExceptionManager([In] BodyCodegen obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        BodyCodegen.ExceptionManager exceptionManager = this;
        this.exceptionInfo = new LinkedList();
      }

      [LineNumberTable(new byte[] {174, 237, 114, 105, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void pushExceptionInfo([In] Jump obj0)
      {
        Node node = BodyCodegen.access\u0024000(this.this\u00240, obj0.getFinally());
        this.exceptionInfo.add((object) new BodyCodegen.ExceptionManager.ExceptionInfo(this, obj0, node));
      }

      [LineNumberTable(new byte[] {175, 10, 103, 101, 11, 230, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void setHandlers([In] int[] obj0, [In] int obj1)
      {
        for (int index = 0; index < obj0.Length; ++index)
        {
          if (obj0[index] != 0)
            this.addHandler(index, obj0[index], obj1);
        }
      }

      [LineNumberTable(new byte[] {175, 27, 103, 106, 105, 105, 105, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual int removeHandler([In] int obj0, [In] int obj1)
      {
        BodyCodegen.ExceptionManager.ExceptionInfo top = this.getTop();
        if (top.handlerLabels[obj0] == 0)
          return 0;
        int handlerLabel = top.handlerLabels[obj0];
        this.endCatch(top, obj0, obj1);
        top.handlerLabels[obj0] = 0;
        return handlerLabel;
      }

      [LineNumberTable(new byte[] {175, 41, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void popExceptionInfo() => this.exceptionInfo.removeLast();

      [LineNumberTable(new byte[] {175, 66, 108, 107, 107, 108, 102, 114, 105, 105, 231, 60, 230, 71, 110, 130, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void markInlineFinallyStart([In] Node obj0, [In] int obj1)
      {
        ListIterator listIterator = this.exceptionInfo.listIterator(this.exceptionInfo.size());
        while (listIterator.hasPrevious())
        {
          BodyCodegen.ExceptionManager.ExceptionInfo exceptionInfo = (BodyCodegen.ExceptionManager.ExceptionInfo) listIterator.previous();
          for (int index = 0; index < 5; ++index)
          {
            if (exceptionInfo.handlerLabels[index] != 0 && exceptionInfo.currentFinally == null)
            {
              this.endCatch(exceptionInfo, index, obj1);
              exceptionInfo.exceptionStarts[index] = 0;
              exceptionInfo.currentFinally = obj0;
            }
          }
          if (object.ReferenceEquals((object) exceptionInfo.finallyBlock, (object) obj0))
            break;
        }
      }

      [LineNumberTable(new byte[] {175, 93, 108, 107, 107, 108, 102, 152, 105, 231, 60, 230, 71, 110, 130, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void markInlineFinallyEnd([In] Node obj0, [In] int obj1)
      {
        ListIterator listIterator = this.exceptionInfo.listIterator(this.exceptionInfo.size());
        while (listIterator.hasPrevious())
        {
          BodyCodegen.ExceptionManager.ExceptionInfo exceptionInfo = (BodyCodegen.ExceptionManager.ExceptionInfo) listIterator.previous();
          for (int index = 0; index < 5; ++index)
          {
            if (exceptionInfo.handlerLabels[index] != 0 && object.ReferenceEquals((object) exceptionInfo.currentFinally, (object) obj0))
            {
              exceptionInfo.exceptionStarts[index] = obj1;
              exceptionInfo.currentFinally = (Node) null;
            }
          }
          if (object.ReferenceEquals((object) exceptionInfo.finallyBlock, (object) obj0))
            break;
        }
      }

      [InnerClass]
      internal class ExceptionInfo : Object
      {
        internal Node finallyBlock;
        internal int[] handlerLabels;
        internal int[] exceptionStarts;
        internal Node currentFinally;
        [Modifiers]
        internal BodyCodegen.ExceptionManager this\u00241;

        [LineNumberTable(new byte[] {175, 138, 111, 103, 108, 108, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal ExceptionInfo([In] BodyCodegen.ExceptionManager obj0, [In] Jump obj1, [In] Node obj2)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          BodyCodegen.ExceptionManager.ExceptionInfo exceptionInfo = this;
          this.finallyBlock = obj2;
          this.handlerLabels = new int[5];
          this.exceptionStarts = new int[5];
          this.currentFinally = (Node) null;
        }
      }
    }

    internal class FinallyReturnPoint : Object
    {
      [Signature("Ljava/util/List<Ljava/lang/Integer;>;")]
      public List jsrPoints;
      public int tableLabel;

      [LineNumberTable(new byte[] {180, 172, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal FinallyReturnPoint()
      {
        BodyCodegen.FinallyReturnPoint finallyReturnPoint = this;
        this.jsrPoints = (List) new ArrayList();
        this.tableLabel = 0;
      }
    }
  }
}
