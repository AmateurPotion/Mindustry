// Decompiled with JetBrains decompiler
// Type: rhino.CodeGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using rhino.ast;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal class CodeGenerator : Icode
  {
    private const int MIN_LABEL_TABLE_SIZE = 32;
    private const int MIN_FIXUP_TABLE_SIZE = 40;
    private CompilerEnvirons compilerEnv;
    private bool itsInFunctionFlag;
    private bool itsInTryFlag;
    private InterpreterData itsData;
    private ScriptNode scriptOrFn;
    private int iCodeTop;
    private int stackDepth;
    private int lineNumber;
    private int doubleTableTop;
    [Modifiers]
    private ObjToIntMap strings;
    private int localTop;
    private int[] labelTable;
    private int labelTableTop;
    private long[] fixupTable;
    private int fixupTableTop;
    [Modifiers]
    private ObjArray literalIds;
    private int exceptionTableTop;
    private const int ECF_TAIL = 1;

    [LineNumberTable(new byte[] {30, 135, 140, 113, 113, 104, 145, 104, 104, 146, 104, 140, 104, 172, 153, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateFunctionICode()
    {
      this.itsInFunctionFlag = true;
      FunctionNode scriptOrFn = (FunctionNode) this.scriptOrFn;
      this.itsData.itsFunctionType = scriptOrFn.getFunctionType();
      this.itsData.itsNeedsActivation = scriptOrFn.requiresActivation();
      if (scriptOrFn.getFunctionName() != null)
        this.itsData.itsName = scriptOrFn.getName();
      if (scriptOrFn.isGenerator())
      {
        this.addIcode(-62);
        this.addUint16(scriptOrFn.getBaseLineno() & (int) ushort.MaxValue);
      }
      if (scriptOrFn.isInStrictMode())
        this.itsData.isStrict = true;
      if (scriptOrFn.isES6Generator())
        this.itsData.isES6Generator = true;
      this.itsData.declaredAsVar = scriptOrFn.getParent() is VariableInitializer;
      this.generateICodeFromTree(scriptOrFn.getLastChild());
    }

    [LineNumberTable(new byte[] {56, 134, 134, 104, 134, 109, 168, 180, 108, 121, 140, 109, 145, 123, 108, 110, 108, 103, 117, 238, 60, 232, 71, 104, 110, 116, 109, 154, 141, 156, 109, 154, 173, 182, 223, 15, 118, 118, 150, 118, 150, 109, 214})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateICodeFromTree([In] Node obj0)
    {
      this.generateNestedFunctions();
      this.generateRegExpLiterals();
      this.visitStatement(obj0, 0);
      this.fixLabelGotos();
      if (this.itsData.itsFunctionType == 0)
        this.addToken(65);
      if (this.itsData.itsICode.Length != this.iCodeTop)
      {
        byte[] numArray = new byte[this.iCodeTop];
        ByteCodeHelper.arraycopy_primitive_1((Array) this.itsData.itsICode, 0, (Array) numArray, 0, this.iCodeTop);
        this.itsData.itsICode = numArray;
      }
      if (this.strings.size() == 0)
      {
        this.itsData.itsStringTable = (string[]) null;
      }
      else
      {
        this.itsData.itsStringTable = new string[this.strings.size()];
        ObjToIntMap.Iterator iterator = this.strings.newIterator();
        iterator.start();
        while (!iterator.done())
        {
          string key = (string) iterator.getKey();
          int index = iterator.getValue();
          if (this.itsData.itsStringTable[index] != null)
            Kit.codeBug();
          this.itsData.itsStringTable[index] = key;
          iterator.next();
        }
      }
      if (this.doubleTableTop == 0)
        this.itsData.itsDoubleTable = (double[]) null;
      else if (this.itsData.itsDoubleTable.Length != this.doubleTableTop)
      {
        double[] numArray = new double[this.doubleTableTop];
        ByteCodeHelper.arraycopy_primitive_8((Array) this.itsData.itsDoubleTable, 0, (Array) numArray, 0, this.doubleTableTop);
        this.itsData.itsDoubleTable = numArray;
      }
      if (this.exceptionTableTop != 0 && this.itsData.itsExceptionTable.Length != this.exceptionTableTop)
      {
        int[] numArray = new int[this.exceptionTableTop];
        ByteCodeHelper.arraycopy_primitive_4((Array) this.itsData.itsExceptionTable, 0, (Array) numArray, 0, this.exceptionTableTop);
        this.itsData.itsExceptionTable = numArray;
      }
      this.itsData.itsMaxVars = this.scriptOrFn.getParamAndVarCount();
      this.itsData.itsMaxFrameArray = this.itsData.itsMaxVars + this.itsData.itsMaxLocals + this.itsData.itsMaxStack;
      this.itsData.argNames = this.scriptOrFn.getParamAndVarNames();
      this.itsData.argIsConst = this.scriptOrFn.getParamAndVarConst();
      this.itsData.argCount = this.scriptOrFn.getParamCount();
      this.itsData.encodedSourceStart = this.scriptOrFn.getEncodedSourceStart();
      this.itsData.encodedSourceEnd = this.scriptOrFn.getEncodedSourceEnd();
      if (this.literalIds.size() == 0)
        return;
      this.itsData.literalIds = this.literalIds.toArray();
    }

    [LineNumberTable(new byte[] {164, 51, 147, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addIcode([In] int obj0)
    {
      if (!Icode.validIcode(obj0))
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      this.addUint8(obj0 & (int) byte.MaxValue);
    }

    [LineNumberTable(new byte[] {164, 68, 116, 108, 103, 103, 136, 103, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addUint16([In] int obj0)
    {
      if ((obj0 & -65536) != 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      byte[] numArray = this.itsData.itsICode;
      int iCodeTop = this.iCodeTop;
      if (iCodeTop + 2 > numArray.Length)
        numArray = this.increaseICodeCapacity(2);
      numArray[iCodeTop] = (byte) ((uint) obj0 >> 8);
      numArray[iCodeTop + 1] = (byte) obj0;
      this.iCodeTop = iCodeTop + 2;
    }

    [LineNumberTable(new byte[] {124, 108, 132, 103, 105, 109, 103, 109, 104, 114, 103, 138, 104, 187, 237, 51, 233, 80, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateNestedFunctions()
    {
      int functionCount = this.scriptOrFn.getFunctionCount();
      if (functionCount == 0)
        return;
      InterpreterData[] interpreterDataArray = new InterpreterData[functionCount];
      for (int i = 0; i != functionCount; ++i)
      {
        FunctionNode functionNode = this.scriptOrFn.getFunctionNode(i);
        CodeGenerator codeGenerator = new CodeGenerator();
        codeGenerator.compilerEnv = this.compilerEnv;
        codeGenerator.scriptOrFn = (ScriptNode) functionNode;
        codeGenerator.itsData = new InterpreterData(this.itsData);
        codeGenerator.generateFunctionICode();
        interpreterDataArray[i] = codeGenerator.itsData;
        switch (functionNode.getParent())
        {
          case AstRoot _:
          case Scope _:
          case Block _:
            continue;
          default:
            codeGenerator.itsData.declaredAsFunctionExpression = true;
            continue;
        }
      }
      this.itsData.itsNestedFunctions = interpreterDataArray;
    }

    [LineNumberTable(new byte[] {160, 84, 108, 132, 102, 103, 103, 104, 111, 111, 239, 61, 232, 69, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateRegExpLiterals()
    {
      int regexpCount = this.scriptOrFn.getRegexpCount();
      if (regexpCount == 0)
        return;
      Context context = Context.getContext();
      RegExpProxy regExpProxy = ScriptRuntime.checkRegExpProxy(context);
      object[] objArray = new object[regexpCount];
      for (int index = 0; index != regexpCount; ++index)
      {
        string regexpString = this.scriptOrFn.getRegexpString(index);
        string regexpFlags = this.scriptOrFn.getRegexpFlags(index);
        objArray[index] = regExpProxy.compileRegExp(context, regexpString, regexpFlags);
      }
      this.itsData.itsRegExpLiterals = objArray;
    }

    [LineNumberTable(new byte[] {160, 115, 103, 103, 191, 161, 24, 104, 108, 230, 71, 100, 139, 100, 235, 72, 104, 105, 103, 104, 167, 229, 71, 167, 102, 104, 233, 69, 104, 103, 103, 165, 103, 165, 103, 104, 103, 99, 104, 137, 105, 135, 165, 104, 165, 199, 104, 109, 135, 107, 110, 105, 103, 103, 105, 104, 167, 111, 231, 52, 243, 78, 104, 135, 165, 103, 197, 109, 104, 105, 135, 165, 109, 137, 165, 109, 138, 197, 103, 104, 105, 103, 99, 104, 137, 137, 197, 103, 104, 116, 103, 165, 104, 105, 136, 138, 104, 104, 103, 99, 104, 137, 136, 105, 100, 105, 104, 208, 105, 100, 105, 104, 240, 69, 106, 136, 165, 104, 105, 104, 103, 104, 104, 103, 104, 109, 135, 165, 103, 104, 104, 114, 103, 165, 103, 111, 165, 103, 107, 105, 172, 104, 151, 104, 104, 114, 204, 99, 138, 104, 103, 167, 162, 103, 104, 226, 70, 104, 110, 103, 162, 162, 173, 105, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitStatement([In] Node obj0, [In] int obj1)
    {
      int type = obj0.getType();
      Node node1 = obj0.getFirstChild();
      switch (type)
      {
        case -62:
label_53:
          if (this.stackDepth == obj1)
            break;
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        case 2:
          this.visitExpression(node1, 0);
          this.addToken(2);
          this.stackChange(-1);
          goto case -62;
        case 3:
          this.addToken(3);
          goto case -62;
        case 4:
          this.updateLineNumber(obj0);
          if (obj0.getIntProp(20, 0) != 0)
          {
            if (node1 == null || this.compilerEnv.getLanguageVersion() < 200)
            {
              this.addIcode(-63);
              this.addUint16(this.lineNumber & (int) ushort.MaxValue);
              goto case -62;
            }
            else
            {
              this.visitExpression(node1, 1);
              this.addIcode(-65);
              this.addUint16(this.lineNumber & (int) ushort.MaxValue);
              this.stackChange(-1);
              goto case -62;
            }
          }
          else if (node1 == null)
          {
            this.addIcode(-22);
            goto case -62;
          }
          else
          {
            this.visitExpression(node1, 1);
            this.addToken(4);
            this.stackChange(-1);
            goto case -62;
          }
        case 5:
          this.addGoto(((Jump) obj0).target, type);
          goto case -62;
        case 6:
        case 7:
          Node target1 = ((Jump) obj0).target;
          this.visitExpression(node1, 0);
          this.addGoto(target1, type);
          this.stackChange(-1);
          goto case -62;
        case 50:
          this.updateLineNumber(obj0);
          this.visitExpression(node1, 0);
          this.addToken(50);
          this.addUint16(this.lineNumber & (int) ushort.MaxValue);
          this.stackChange(-1);
          goto case -62;
        case 51:
          this.updateLineNumber(obj0);
          this.addIndexOp(51, this.getLocalBlockRef(obj0));
          goto case -62;
        case 57:
          int localBlockRef1 = this.getLocalBlockRef(obj0);
          int existingIntProp1 = obj0.getExistingIntProp(14);
          string str = node1.getString();
          this.visitExpression(node1.getNext(), 0);
          this.addStringPrefix(str);
          this.addIndexPrefix(localBlockRef1);
          this.addToken(57);
          this.addUint8(existingIntProp1 == 0 ? 0 : 1);
          this.stackChange(-1);
          goto case -62;
        case 58:
        case 59:
        case 60:
        case 61:
          this.visitExpression(node1, 0);
          this.addIndexOp(type, this.getLocalBlockRef(obj0));
          this.stackChange(-1);
          goto case -62;
        case 65:
          this.updateLineNumber(obj0);
          this.addToken(65);
          goto case -62;
        case 82:
          Jump jump = (Jump) obj0;
          int localBlockRef2 = this.getLocalBlockRef((Node) jump);
          int num1 = this.allocLocal();
          this.addIndexOp(-13, num1);
          int iCodeTop = this.iCodeTop;
          int num2 = this.itsInTryFlag ? 1 : 0;
          this.itsInTryFlag = true;
          for (; node1 != null; node1 = node1.getNext())
            this.visitStatement(node1, obj1);
          this.itsInTryFlag = num2 != 0;
          Node target2 = jump.target;
          if (target2 != null)
          {
            int num3 = this.labelTable[this.getTargetLabel(target2)];
            this.addExceptionHandler(iCodeTop, num3, num3, false, localBlockRef2, num1);
          }
          Node node2 = jump.getFinally();
          if (node2 != null)
          {
            int num3 = this.labelTable[this.getTargetLabel(node2)];
            this.addExceptionHandler(iCodeTop, num3, num3, true, localBlockRef2, num1);
          }
          this.addIndexOp(-56, num1);
          this.releaseLocal(num1);
          goto case -62;
        case 110:
          int existingIntProp2 = obj0.getExistingIntProp(1);
          switch (this.scriptOrFn.getFunctionNode(existingIntProp2).getFunctionType())
          {
            case 1:
              if (!this.itsInFunctionFlag)
              {
                this.addIndexOp(-19, existingIntProp2);
                this.stackChange(1);
                this.addIcode(-5);
                this.stackChange(-1);
                goto label_53;
              }
              else
                goto label_53;
            case 3:
              this.addIndexOp(-20, existingIntProp2);
              goto case 1;
            default:
              throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
          }
        case 115:
          this.updateLineNumber(obj0);
          this.visitExpression(node1, 0);
          for (Jump next = (Jump) node1.getNext(); next != null; next = (Jump) next.getNext())
          {
            Node node3 = next.getType() == 116 ? next.getFirstChild() : throw Throwable.__\u003Cunmap\u003E((Exception) this.badTree((Node) next));
            this.addIcode(-1);
            this.stackChange(1);
            this.visitExpression(node3, 0);
            this.addToken(46);
            this.stackChange(-1);
            this.addGoto(next.target, -6);
            this.stackChange(-1);
          }
          this.addIcode(-4);
          this.stackChange(-1);
          goto case -62;
        case 124:
        case 129:
        case 130:
        case 131:
        case 133:
          this.updateLineNumber(obj0);
          goto case 137;
        case 126:
          this.stackChange(1);
          int localBlockRef3 = this.getLocalBlockRef(obj0);
          this.addIndexOp(-24, localBlockRef3);
          this.stackChange(-1);
          for (; node1 != null; node1 = node1.getNext())
            this.visitStatement(node1, obj1);
          this.addIndexOp(-25, localBlockRef3);
          goto case -62;
        case 132:
          this.markTargetLabel(obj0);
          goto case -62;
        case 134:
        case 135:
          this.updateLineNumber(obj0);
          this.visitExpression(node1, 0);
          this.addIcode(type != 134 ? -5 : -4);
          this.stackChange(-1);
          goto case -62;
        case 136:
          this.addGoto(((Jump) obj0).target, -23);
          goto case -62;
        case 137:
          for (; node1 != null; node1 = node1.getNext())
            this.visitStatement(node1, obj1);
          goto case -62;
        case 142:
          int prop = this.allocLocal();
          obj0.putIntProp(2, prop);
          this.updateLineNumber(obj0);
          for (; node1 != null; node1 = node1.getNext())
            this.visitStatement(node1, obj1);
          this.addIndexOp(-56, prop);
          this.releaseLocal(prop);
          goto case -62;
        case 161:
          this.addIcode(-64);
          goto case -62;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.badTree(obj0));
      }
    }

    [LineNumberTable(new byte[] {164, 0, 107, 105, 102, 99, 106, 133, 139, 233, 55, 230, 75, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void fixLabelGotos()
    {
      for (int index1 = 0; index1 < this.fixupTableTop; ++index1)
      {
        long num1 = this.fixupTable[index1];
        int index2 = (int) (num1 >> 32);
        int num2 = (int) num1;
        int num3 = this.labelTable[index2];
        if (num3 == -1)
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        this.resolveGoto(num2, num3);
      }
      this.fixupTableTop = 0;
    }

    [LineNumberTable(new byte[] {164, 46, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addToken([In] int obj0)
    {
      if (!Icode.validTokenCode(obj0))
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      this.addUint8(obj0);
    }

    [LineNumberTable(new byte[] {159, 150, 232, 82, 237, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal CodeGenerator()
    {
      CodeGenerator codeGenerator = this;
      this.strings = new ObjToIntMap(20);
      this.literalIds = new ObjArray();
    }

    [LineNumberTable(new byte[] {164, 152, 103, 104, 137, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addIndexOp([In] int obj0, [In] int obj1)
    {
      this.addIndexPrefix(obj1);
      if (Icode.validIcode(obj0))
        this.addIcode(obj0);
      else
        this.addToken(obj0);
    }

    [LineNumberTable(new byte[] {164, 235, 100, 144, 105, 110, 140, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void stackChange([In] int obj0)
    {
      if (obj0 <= 0)
      {
        this.stackDepth += obj0;
      }
      else
      {
        int num = this.stackDepth + obj0;
        if (num > this.itsData.itsMaxStack)
          this.itsData.itsMaxStack = num;
        this.stackDepth = num;
      }
    }

    [LineNumberTable(new byte[] {160, 99, 103, 109, 110, 140, 103, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateLineNumber([In] Node obj0)
    {
      int lineno = obj0.getLineno();
      if (lineno == this.lineNumber || lineno < 0)
        return;
      if (this.itsData.firstLinePC < 0)
        this.itsData.firstLinePC = lineno;
      this.lineNumber = lineno;
      this.addIcode(-26);
      this.addUint16(lineno & (int) ushort.MaxValue);
    }

    [LineNumberTable(new byte[] {161, 128, 103, 103, 103, 191, 162, 42, 104, 142, 108, 104, 139, 105, 135, 165, 104, 105, 135, 165, 104, 106, 104, 104, 103, 169, 138, 229, 69, 103, 229, 69, 101, 138, 135, 98, 106, 104, 134, 139, 137, 105, 104, 107, 244, 69, 112, 111, 131, 168, 133, 202, 137, 110, 172, 197, 104, 103, 103, 103, 107, 104, 103, 104, 103, 135, 106, 135, 165, 104, 105, 104, 104, 103, 135, 107, 104, 103, 104, 135, 107, 136, 197, 104, 103, 109, 165, 107, 104, 103, 104, 131, 137, 136, 103, 229, 88, 104, 103, 104, 103, 103, 229, 72, 104, 101, 104, 141, 135, 197, 104, 103, 197, 104, 103, 104, 103, 104, 103, 103, 138, 135, 104, 106, 135, 197, 104, 103, 104, 103, 104, 104, 103, 104, 135, 135, 104, 104, 104, 197, 104, 103, 104, 103, 103, 136, 135, 104, 104, 103, 197, 104, 104, 103, 104, 105, 135, 165, 104, 104, 103, 104, 106, 135, 165, 163, 117, 110, 101, 110, 137, 106, 103, 168, 229, 69, 109, 103, 197, 104, 165, 106, 105, 106, 100, 136, 115, 138, 101, 106, 103, 136, 144, 104, 170, 106, 138, 135, 165, 115, 110, 106, 135, 165, 115, 110, 103, 104, 138, 165, 115, 110, 103, 104, 141, 229, 71, 103, 103, 197, 110, 103, 165, 105, 106, 135, 197, 104, 165, 110, 165, 104, 116, 197, 99, 138, 104, 135, 101, 138, 136, 114, 162, 104, 105, 110, 103, 103, 110, 103, 194, 141, 107, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitExpression([In] Node obj0, [In] int obj1)
    {
      int num1 = obj0.getType();
      Node nameNode = obj0.getFirstChild();
      int stackDepth = this.stackDepth;
      switch (num1)
      {
        case 8:
        case 74:
          string str1 = nameNode.getString();
          this.visitExpression(nameNode, 0);
          this.visitExpression(nameNode.getNext(), 0);
          this.addStringOp(num1, str1);
          this.stackChange(-1);
          break;
        case 9:
        case 10:
        case 11:
        case 12:
        case 13:
        case 14:
        case 15:
        case 16:
        case 17:
        case 18:
        case 19:
        case 20:
        case 21:
        case 22:
        case 23:
        case 24:
        case 25:
        case 36:
        case 46:
        case 47:
        case 52:
        case 53:
          this.visitExpression(nameNode, 0);
          this.visitExpression(nameNode.getNext(), 0);
          this.addToken(num1);
          this.stackChange(-1);
          break;
        case 26:
        case 27:
        case 28:
        case 29:
        case 32:
        case (int) sbyte.MaxValue:
          this.visitExpression(nameNode, 0);
          if (num1 == (int) sbyte.MaxValue)
          {
            this.addIcode(-4);
            this.addIcode(-50);
            break;
          }
          this.addToken(num1);
          break;
        case 30:
        case 38:
        case 71:
          if (num1 == 30)
            this.visitExpression(nameNode, 0);
          else
            this.generateCallFunAndThis(nameNode);
          int num2 = 0;
          while ((nameNode = nameNode.getNext()) != null)
          {
            this.visitExpression(nameNode, 0);
            ++num2;
          }
          int intProp = obj0.getIntProp(10, 0);
          if (num1 != 71 && intProp != 0)
          {
            this.addIndexOp(-21, num2);
            this.addUint8(intProp);
            this.addUint8(num1 == 30 ? 1 : 0);
            this.addUint16(this.lineNumber & (int) ushort.MaxValue);
          }
          else
          {
            if (num1 == 38 && (obj1 & 1) != 0 && (!this.compilerEnv.isGenerateDebugInfo() && !this.itsInTryFlag))
              num1 = -55;
            this.addIndexOp(num1, num2);
          }
          if (num1 == 30)
            this.stackChange(-num2);
          else
            this.stackChange(-1 - num2);
          if (num2 > this.itsData.itsMaxCalleeArgs)
          {
            this.itsData.itsMaxCalleeArgs = num2;
            break;
          }
          break;
        case 31:
          int num3 = nameNode.getType() == 49 ? 1 : 0;
          this.visitExpression(nameNode, 0);
          this.visitExpression(nameNode.getNext(), 0);
          if (num3 != 0)
            this.addIcode(0);
          else
            this.addToken(31);
          this.stackChange(-1);
          break;
        case 33:
        case 34:
          this.visitExpression(nameNode, 0);
          Node next1 = nameNode.getNext();
          this.addStringOp(num1, next1.getString());
          break;
        case 35:
        case 140:
          this.visitExpression(nameNode, 0);
          Node next2 = nameNode.getNext();
          string str2 = next2.getString();
          Node next3 = next2.getNext();
          if (num1 == 140)
          {
            this.addIcode(-1);
            this.stackChange(1);
            this.addStringOp(33, str2);
            this.stackChange(-1);
          }
          this.visitExpression(next3, 0);
          this.addStringOp(35, str2);
          this.stackChange(-1);
          break;
        case 37:
        case 141:
          this.visitExpression(nameNode, 0);
          Node next4 = nameNode.getNext();
          this.visitExpression(next4, 0);
          Node next5 = next4.getNext();
          if (num1 == 141)
          {
            this.addIcode(-2);
            this.stackChange(2);
            this.addToken(36);
            this.stackChange(-1);
            this.stackChange(-1);
          }
          this.visitExpression(next5, 0);
          this.addToken(37);
          this.stackChange(-2);
          break;
        case 39:
        case 41:
        case 49:
          this.addStringOp(num1, obj0.getString());
          this.stackChange(1);
          break;
        case 40:
          double num4 = obj0.getDouble();
          int num5 = ByteCodeHelper.d2i(num4);
          if ((double) num5 == num4)
          {
            switch (num5)
            {
              case 0:
                this.addIcode(-51);
                if (1.0 / num4 < 0.0)
                {
                  this.addToken(29);
                  break;
                }
                break;
              case 1:
                this.addIcode(-52);
                break;
              default:
                if ((int) (short) num5 == num5)
                {
                  this.addIcode(-27);
                  this.addUint16(num5 & (int) ushort.MaxValue);
                  break;
                }
                this.addIcode(-28);
                this.addInt(num5);
                break;
            }
          }
          else
            this.addIndexOp(40, this.getDoubleIndex(num4));
          this.stackChange(1);
          break;
        case 42:
        case 43:
        case 44:
        case 45:
        case 64:
          this.addToken(num1);
          this.stackChange(1);
          break;
        case 48:
          this.addIndexOp(48, obj0.getExistingIntProp(4));
          this.stackChange(1);
          break;
        case 54:
          this.addIndexOp(54, this.getLocalBlockRef(obj0));
          this.stackChange(1);
          break;
        case 55:
          if (this.itsData.itsNeedsActivation)
            Kit.codeBug();
          this.addVarOp(55, this.scriptOrFn.getIndexForNameNode(obj0));
          this.stackChange(1);
          break;
        case 56:
          if (this.itsData.itsNeedsActivation)
            Kit.codeBug();
          int indexForNameNode1 = this.scriptOrFn.getIndexForNameNode(nameNode);
          this.visitExpression(nameNode.getNext(), 0);
          this.addVarOp(56, indexForNameNode1);
          break;
        case 62:
        case 63:
          this.addIndexOp(num1, this.getLocalBlockRef(obj0));
          this.stackChange(1);
          break;
        case 66:
        case 67:
          this.visitLiteral(obj0, nameNode);
          break;
        case 68:
        case 70:
          this.visitExpression(nameNode, 0);
          this.addToken(num1);
          break;
        case 69:
        case 143:
          this.visitExpression(nameNode, 0);
          Node next6 = nameNode.getNext();
          if (num1 == 143)
          {
            this.addIcode(-1);
            this.stackChange(1);
            this.addToken(68);
            this.stackChange(-1);
          }
          this.visitExpression(next6, 0);
          this.addToken(69);
          this.stackChange(-1);
          break;
        case 72:
          this.visitExpression(nameNode, 0);
          this.addStringOp(num1, (string) obj0.getProp(17));
          break;
        case 73:
        case 166:
          if (nameNode != null)
          {
            this.visitExpression(nameNode, 0);
          }
          else
          {
            this.addIcode(-50);
            this.stackChange(1);
          }
          if (num1 == 73)
            this.addToken(73);
          else
            this.addIcode(-66);
          this.addUint16(obj0.getLineno() & (int) ushort.MaxValue);
          break;
        case 90:
          for (Node lastChild = obj0.getLastChild(); !object.ReferenceEquals((object) nameNode, (object) lastChild); nameNode = nameNode.getNext())
          {
            this.visitExpression(nameNode, 0);
            this.addIcode(-4);
            this.stackChange(-1);
          }
          this.visitExpression(nameNode, obj1 & 1);
          break;
        case 103:
          Node next7 = nameNode.getNext();
          Node next8 = next7.getNext();
          this.visitExpression(nameNode, 0);
          int iCodeTop1 = this.iCodeTop;
          this.addGotoOp(7);
          this.stackChange(-1);
          this.visitExpression(next7, obj1 & 1);
          int iCodeTop2 = this.iCodeTop;
          this.addGotoOp(5);
          this.resolveForwardGoto(iCodeTop1);
          this.stackDepth = stackDepth;
          this.visitExpression(next8, obj1 & 1);
          this.resolveForwardGoto(iCodeTop2);
          break;
        case 105:
        case 106:
          this.visitExpression(nameNode, 0);
          this.addIcode(-1);
          this.stackChange(1);
          int iCodeTop3 = this.iCodeTop;
          this.addGotoOp(num1 != 106 ? 6 : 7);
          this.stackChange(-1);
          this.addIcode(-4);
          this.stackChange(-1);
          this.visitExpression(nameNode.getNext(), obj1 & 1);
          this.resolveForwardGoto(iCodeTop3);
          break;
        case 107:
        case 108:
          this.visitIncDec(obj0, nameNode);
          break;
        case 110:
          int existingIntProp = obj0.getExistingIntProp(1);
          FunctionNode functionNode = this.scriptOrFn.getFunctionNode(existingIntProp);
          if (functionNode.getFunctionType() != 2 && functionNode.getFunctionType() != 4)
            throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
          this.addIndexOp(-19, existingIntProp);
          this.stackChange(1);
          break;
        case 138:
          int num6 = -1;
          if (this.itsInFunctionFlag && !this.itsData.itsNeedsActivation)
            num6 = this.scriptOrFn.getIndexForNameNode(obj0);
          if (num6 == -1)
          {
            this.addStringOp(-14, obj0.getString());
            this.stackChange(1);
            break;
          }
          this.addVarOp(55, num6);
          this.stackChange(1);
          this.addToken(32);
          break;
        case 139:
          this.stackChange(1);
          break;
        case 156:
          string str3 = nameNode.getString();
          this.visitExpression(nameNode, 0);
          this.visitExpression(nameNode.getNext(), 0);
          this.addStringOp(-59, str3);
          this.stackChange(-1);
          break;
        case 157:
          if (this.itsData.itsNeedsActivation)
            Kit.codeBug();
          int indexForNameNode2 = this.scriptOrFn.getIndexForNameNode(nameNode);
          this.visitExpression(nameNode.getNext(), 0);
          this.addVarOp(157, indexForNameNode2);
          break;
        case 158:
          this.visitArrayComprehension(obj0, nameNode, nameNode.getNext());
          break;
        case 160:
          Node firstChild = obj0.getFirstChild();
          Node next9 = firstChild.getNext();
          this.visitExpression(firstChild.getFirstChild(), 0);
          this.addToken(2);
          this.stackChange(-1);
          this.visitExpression(next9.getFirstChild(), 0);
          this.addToken(3);
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.badTree(obj0));
      }
      if (stackDepth + 1 == this.stackDepth)
        return;
      Kit.codeBug();
    }

    [LineNumberTable(new byte[] {164, 247, 103, 110, 115, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int allocLocal()
    {
      int localTop = this.localTop;
      ++this.localTop;
      if (this.localTop > this.itsData.itsMaxLocals)
        this.itsData.itsMaxLocals = this.localTop;
      return localTop;
    }

    [LineNumberTable(new byte[] {165, 0, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void releaseLocal([In] int obj0)
    {
      --this.localTop;
      if (obj0 == this.localTop)
        return;
      Kit.codeBug();
    }

    [LineNumberTable(225)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private RuntimeException badTree([In] Node obj0)
    {
      string str = obj0.toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(str);
    }

    [LineNumberTable(new byte[] {163, 231, 104, 111, 137, 100, 141, 103, 103, 103, 114, 104, 143, 112, 112, 168, 105, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addGoto([In] Node obj0, [In] int obj1)
    {
      int targetLabel = this.getTargetLabel(obj0);
      if (targetLabel >= this.labelTableTop)
        Kit.codeBug();
      int num = this.labelTable[targetLabel];
      if (num != -1)
      {
        this.addBackwardGoto(obj1, num);
      }
      else
      {
        int iCodeTop = this.iCodeTop;
        this.addGotoOp(obj1);
        int fixupTableTop = this.fixupTableTop;
        if (this.fixupTable == null || fixupTableTop == this.fixupTable.Length)
        {
          if (this.fixupTable == null)
          {
            this.fixupTable = new long[40];
          }
          else
          {
            long[] numArray = new long[this.fixupTable.Length * 2];
            ByteCodeHelper.arraycopy_primitive_8((Array) this.fixupTable, 0, (Array) numArray, 0, fixupTableTop);
            this.fixupTable = numArray;
          }
        }
        this.fixupTableTop = fixupTableTop + 1;
        this.fixupTable[fixupTableTop] = (long) targetLabel << 32 | (long) iCodeTop;
      }
    }

    [LineNumberTable(new byte[] {163, 222, 104, 139, 134, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void markTargetLabel([In] Node obj0)
    {
      int targetLabel = this.getTargetLabel(obj0);
      if (this.labelTable[targetLabel] != -1)
        Kit.codeBug();
      this.labelTable[targetLabel] = this.iCodeTop;
    }

    [LineNumberTable(new byte[] {163, 195, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getLocalBlockRef([In] Node obj0) => ((Node) obj0.getProp(3)).getExistingIntProp(2);

    [LineNumberTable(new byte[] {163, 200, 103, 100, 130, 103, 114, 104, 143, 111, 111, 167, 105, 137, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getTargetLabel([In] Node obj0)
    {
      int num = obj0.labelId();
      if (num != -1)
        return num;
      int labelTableTop = this.labelTableTop;
      if (this.labelTable == null || labelTableTop == this.labelTable.Length)
      {
        if (this.labelTable == null)
        {
          this.labelTable = new int[32];
        }
        else
        {
          int[] numArray = new int[this.labelTable.Length * 2];
          ByteCodeHelper.arraycopy_primitive_4((Array) this.labelTable, 0, (Array) numArray, 0, labelTableTop);
          this.labelTable = numArray;
        }
      }
      this.labelTableTop = labelTableTop + 1;
      this.labelTable[labelTableTop] = -1;
      obj0.labelId(labelTableTop);
      return labelTableTop;
    }

    [LineNumberTable(new byte[] {158, 64, 99, 103, 108, 99, 105, 104, 110, 101, 106, 116, 140, 102, 102, 102, 108, 103, 135, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addExceptionHandler(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] bool obj3,
      [In] int obj4,
      [In] int obj5)
    {
      int num = obj3 ? 1 : 0;
      int exceptionTableTop = this.exceptionTableTop;
      int[] numArray = this.itsData.itsExceptionTable;
      if (numArray == null)
      {
        if (exceptionTableTop != 0)
          Kit.codeBug();
        numArray = new int[12];
        this.itsData.itsExceptionTable = numArray;
      }
      else if (numArray.Length == exceptionTableTop)
      {
        numArray = new int[numArray.Length * 2];
        ByteCodeHelper.arraycopy_primitive_4((Array) this.itsData.itsExceptionTable, 0, (Array) numArray, 0, exceptionTableTop);
        this.itsData.itsExceptionTable = numArray;
      }
      numArray[exceptionTableTop + 0] = obj0;
      numArray[exceptionTableTop + 1] = obj1;
      numArray[exceptionTableTop + 2] = obj2;
      numArray[exceptionTableTop + 3] = num == 0 ? 0 : 1;
      numArray[exceptionTableTop + 4] = obj4;
      numArray[exceptionTableTop + 5] = obj5;
      this.exceptionTableTop = exceptionTableTop + 6;
    }

    [LineNumberTable(new byte[] {164, 161, 110, 100, 108, 141, 100, 108, 104, 104, 105, 104, 104, 137, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addStringPrefix([In] string obj0)
    {
      int num = this.strings.get((object) obj0, -1);
      if (num == -1)
      {
        num = this.strings.size();
        this.strings.put((object) obj0, num);
      }
      if (num < 4)
        this.addIcode(-41 - num);
      else if (num <= (int) byte.MaxValue)
      {
        this.addIcode(-45);
        this.addUint8(num);
      }
      else if (num <= (int) ushort.MaxValue)
      {
        this.addIcode(-46);
        this.addUint16(num);
      }
      else
      {
        this.addIcode(-47);
        this.addInt(num);
      }
    }

    [LineNumberTable(new byte[] {164, 181, 106, 100, 108, 104, 104, 105, 104, 104, 137, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addIndexPrefix([In] int obj0)
    {
      if (obj0 < 0)
        Kit.codeBug();
      if (obj0 < 6)
        this.addIcode(-32 - obj0);
      else if (obj0 <= (int) byte.MaxValue)
      {
        this.addIcode(-38);
        this.addUint8(obj0);
      }
      else if (obj0 <= (int) ushort.MaxValue)
      {
        this.addIcode(-39);
        this.addUint16(obj0);
      }
      else
      {
        this.addIcode(-40);
        this.addInt(obj0);
      }
    }

    [LineNumberTable(new byte[] {164, 57, 116, 108, 103, 101, 136, 101, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addUint8([In] int obj0)
    {
      if ((obj0 & -256) != 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      byte[] numArray = this.itsData.itsICode;
      int iCodeTop = this.iCodeTop;
      if (iCodeTop == numArray.Length)
        numArray = this.increaseICodeCapacity(1);
      numArray[iCodeTop] = (byte) obj0;
      this.iCodeTop = iCodeTop + 1;
    }

    [LineNumberTable(new byte[] {163, 45, 103, 159, 0, 135, 105, 103, 197, 103, 104, 103, 101, 136, 106, 103, 98, 136, 136, 194, 136, 104, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generateCallFunAndThis([In] Node obj0)
    {
      int type = obj0.getType();
      switch (type)
      {
        case 33:
        case 36:
          Node firstChild = obj0.getFirstChild();
          this.visitExpression(firstChild, 0);
          Node next = firstChild.getNext();
          if (type == 33)
          {
            this.addStringOp(-16, next.getString());
            this.stackChange(1);
            break;
          }
          this.visitExpression(next, 0);
          this.addIcode(-17);
          break;
        case 39:
          this.addStringOp(-15, obj0.getString());
          this.stackChange(2);
          break;
        default:
          this.visitExpression(obj0, 0);
          this.addIcode(-18);
          this.stackChange(1);
          break;
      }
    }

    [LineNumberTable(new byte[] {164, 107, 108, 103, 103, 136, 133, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addGotoOp([In] int obj0)
    {
      byte[] numArray = this.itsData.itsICode;
      int iCodeTop = this.iCodeTop;
      if (iCodeTop + 3 > numArray.Length)
        numArray = this.increaseICodeCapacity(3);
      numArray[iCodeTop] = (byte) obj0;
      this.iCodeTop = iCodeTop + 1 + 2;
    }

    [LineNumberTable(new byte[] {164, 24, 118, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void resolveForwardGoto([In] int obj0)
    {
      if (this.iCodeTop < obj0 + 3)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      this.resolveGoto(obj0, this.iCodeTop);
    }

    [LineNumberTable(new byte[] {164, 143, 103, 104, 137, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addStringOp([In] int obj0, [In] string obj1)
    {
      this.addStringPrefix(obj1);
      if (Icode.validIcode(obj0))
        this.addIcode(obj0);
      else
        this.addToken(obj0);
    }

    [LineNumberTable(new byte[] {164, 118, 159, 11, 104, 104, 103, 129, 105, 161, 104, 113, 103, 193, 104, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addVarOp([In] int obj0, [In] int obj1)
    {
      switch (obj0)
      {
        case -7:
          this.addIndexOp(obj0, obj1);
          break;
        case 55:
        case 56:
          if (obj1 < 128)
          {
            this.addIcode(obj0 != 55 ? -49 : -48);
            this.addUint8(obj1);
            break;
          }
          goto case -7;
        case 157:
          if (obj1 < 128)
          {
            this.addIcode(-61);
            this.addUint8(obj1);
            break;
          }
          this.addIndexOp(-60, obj1);
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [LineNumberTable(new byte[] {163, 83, 105, 103, 159, 25, 115, 109, 105, 103, 103, 165, 103, 105, 103, 103, 165, 104, 105, 110, 106, 103, 165, 104, 105, 105, 105, 104, 103, 103, 162, 104, 105, 104, 103, 162, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitIncDec([In] Node obj0, [In] Node obj1)
    {
      int existingIntProp = obj0.getExistingIntProp(13);
      switch (obj1.getType())
      {
        case 33:
          Node firstChild1 = obj1.getFirstChild();
          this.visitExpression(firstChild1, 0);
          this.addStringOp(-9, firstChild1.getNext().getString());
          this.addUint8(existingIntProp);
          break;
        case 36:
          Node firstChild2 = obj1.getFirstChild();
          this.visitExpression(firstChild2, 0);
          this.visitExpression(firstChild2.getNext(), 0);
          this.addIcode(-10);
          this.addUint8(existingIntProp);
          this.stackChange(-1);
          break;
        case 39:
          this.addStringOp(-8, obj1.getString());
          this.addUint8(existingIntProp);
          this.stackChange(1);
          break;
        case 55:
          if (this.itsData.itsNeedsActivation)
            Kit.codeBug();
          this.addVarOp(-7, this.scriptOrFn.getIndexForNameNode(obj1));
          this.addUint8(existingIntProp);
          this.stackChange(1);
          break;
        case 68:
          this.visitExpression(obj1.getFirstChild(), 0);
          this.addIcode(-11);
          this.addUint8(existingIntProp);
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.badTree(obj0));
      }
    }

    [LineNumberTable(new byte[] {164, 80, 108, 103, 103, 136, 104, 106, 105, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addInt([In] int obj0)
    {
      byte[] numArray = this.itsData.itsICode;
      int iCodeTop = this.iCodeTop;
      if (iCodeTop + 4 > numArray.Length)
        numArray = this.increaseICodeCapacity(4);
      numArray[iCodeTop] = (byte) ((uint) obj0 >> 24);
      numArray[iCodeTop + 1] = (byte) ((uint) obj0 >> 16);
      numArray[iCodeTop + 2] = (byte) ((uint) obj0 >> 8);
      numArray[iCodeTop + 3] = (byte) obj0;
      this.iCodeTop = iCodeTop + 4;
    }

    [LineNumberTable(new byte[] {164, 93, 103, 99, 116, 111, 105, 116, 140, 111, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getDoubleIndex([In] double obj0)
    {
      int doubleTableTop = this.doubleTableTop;
      if (doubleTableTop == 0)
        this.itsData.itsDoubleTable = new double[64];
      else if (this.itsData.itsDoubleTable.Length == doubleTableTop)
      {
        double[] numArray = new double[doubleTableTop * 2];
        ByteCodeHelper.arraycopy_primitive_8((Array) this.itsData.itsDoubleTable, 0, (Array) numArray, 0, doubleTableTop);
        this.itsData.itsDoubleTable = numArray;
      }
      this.itsData.itsDoubleTable[doubleTableTop] = obj0;
      this.doubleTableTop = doubleTableTop + 1;
      return doubleTableTop;
    }

    [LineNumberTable(new byte[] {163, 133, 135, 98, 101, 98, 101, 36, 171, 101, 115, 133, 141, 105, 103, 102, 104, 105, 109, 106, 105, 109, 106, 105, 109, 138, 104, 136, 103, 104, 101, 101, 116, 100, 138, 109, 109, 138, 98, 109, 108, 138, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitLiteral([In] Node obj0, [In] Node obj1)
    {
      int type = obj0.getType();
      object[] objArray = (object[]) null;
      int num1;
      if (type == 66)
      {
        num1 = 0;
        for (Node node = obj1; node != null; node = node.getNext())
          ++num1;
      }
      else
      {
        if (type != 67)
          throw Throwable.__\u003Cunmap\u003E((Exception) this.badTree(obj0));
        objArray = (object[]) obj0.getProp(12);
        num1 = objArray.Length;
      }
      this.addIndexOp(-29, num1);
      this.stackChange(2);
      for (; obj1 != null; obj1 = obj1.getNext())
      {
        switch (obj1.getType())
        {
          case 152:
            this.visitExpression(obj1.getFirstChild(), 0);
            this.addIcode(-57);
            break;
          case 153:
            this.visitExpression(obj1.getFirstChild(), 0);
            this.addIcode(-58);
            break;
          case 164:
            this.visitExpression(obj1.getFirstChild(), 0);
            this.addIcode(-30);
            break;
          default:
            this.visitExpression(obj1, 0);
            this.addIcode(-30);
            break;
        }
        this.stackChange(-1);
      }
      if (type == 66)
      {
        int[] prop = (int[]) obj0.getProp(11);
        if (prop == null)
        {
          this.addToken(66);
        }
        else
        {
          int num2 = this.literalIds.size();
          this.literalIds.add((object) prop);
          this.addIndexOp(-31, num2);
        }
      }
      else
      {
        int num2 = this.literalIds.size();
        this.literalIds.add((object) objArray);
        this.addIndexOp(67, num2);
      }
      this.stackChange(-1);
    }

    [LineNumberTable(new byte[] {163, 190, 109, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void visitArrayComprehension([In] Node obj0, [In] Node obj1, [In] Node obj2)
    {
      this.visitStatement(obj1, this.stackDepth);
      this.visitExpression(obj2, 0);
    }

    [LineNumberTable(new byte[] {164, 15, 135, 111, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addBackwardGoto([In] int obj0, [In] int obj1)
    {
      int iCodeTop = this.iCodeTop;
      if (iCodeTop <= obj1)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      this.addGotoOp(obj0);
      this.resolveGoto(iCodeTop, obj1);
    }

    [LineNumberTable(new byte[] {164, 29, 132, 115, 100, 101, 109, 144, 114, 130, 108, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void resolveGoto([In] int obj0, [In] int obj1)
    {
      int num = obj1 - obj0;
      if (0 <= num && num <= 2)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      int key = obj0 + 1;
      if (num != (int) (short) num)
      {
        if (this.itsData.longJumps == null)
          this.itsData.longJumps = new UintMap();
        this.itsData.longJumps.put(key, obj1);
        num = 0;
      }
      byte[] itsIcode = this.itsData.itsICode;
      itsIcode[key] = (byte) (num >> 8);
      itsIcode[key + 1] = (byte) num;
    }

    [LineNumberTable(new byte[] {164, 221, 109, 103, 113, 100, 102, 132, 103, 116, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private byte[] increaseICodeCapacity([In] int obj0)
    {
      int length1 = this.itsData.itsICode.Length;
      int iCodeTop = this.iCodeTop;
      if (iCodeTop + obj0 <= length1)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      int length2 = length1 * 2;
      if (iCodeTop + obj0 > length2)
        length2 = iCodeTop + obj0;
      byte[] numArray = new byte[length2];
      ByteCodeHelper.arraycopy_primitive_1((Array) this.itsData.itsICode, 0, (Array) numArray, 0, iCodeTop);
      this.itsData.itsICode = numArray;
      return numArray;
    }

    [LineNumberTable(new byte[] {159, 131, 99, 231, 71, 236, 71, 99, 143, 167, 109, 140, 111, 140, 99, 136, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual InterpreterData compile(
      [In] CompilerEnvirons obj0,
      [In] ScriptNode obj1,
      [In] string obj2,
      [In] bool obj3)
    {
      int num = obj3 ? 1 : 0;
      this.compilerEnv = obj0;
      new NodeTransformer().transform(obj1, obj0);
      this.scriptOrFn = num == 0 ? obj1 : (ScriptNode) obj1.getFunctionNode(0);
      this.itsData = new InterpreterData(obj0.getLanguageVersion(), this.scriptOrFn.getSourceName(), obj2, this.scriptOrFn.isInStrictMode());
      this.itsData.topLevel = true;
      if (num != 0)
        this.generateFunctionICode();
      else
        this.generateICodeFromTree((Node) this.scriptOrFn);
      return this.itsData;
    }
  }
}
