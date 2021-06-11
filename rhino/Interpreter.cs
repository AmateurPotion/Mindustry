// Decompiled with JetBrains decompiler
// Type: rhino.Interpreter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using rhino.ast;
using rhino.debug;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Evaluator"})]
  public sealed class Interpreter : Icode, Evaluator
  {
    internal InterpreterData itsData;
    internal const int EXCEPTION_TRY_START_SLOT = 0;
    internal const int EXCEPTION_TRY_END_SLOT = 1;
    internal const int EXCEPTION_HANDLER_SLOT = 2;
    internal const int EXCEPTION_TYPE_SLOT = 3;
    internal const int EXCEPTION_LOCAL_SLOT = 4;
    internal const int EXCEPTION_SCOPE_SLOT = 5;
    internal const int EXCEPTION_SLOT_SIZE = 6;

    [LineNumberTable(new byte[] {170, 226, 149, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static NativeContinuation captureContinuation(Context cx)
    {
      if (cx.lastInterpreterFrame == null || !(cx.lastInterpreterFrame is Interpreter.CallFrame))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Interpreter frames not found");
      }
      return Interpreter.captureContinuation(cx, (Interpreter.CallFrame) cx.lastInterpreterFrame, true);
    }

    [LineNumberTable(new byte[] {163, 115, 104, 209, 100, 136, 164, 108, 131, 162, 136, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object restartContinuation(
      NativeContinuation c,
      Context cx,
      Scriptable scope,
      object[] args)
    {
      if (!ScriptRuntime.hasTopCall(cx))
        return ScriptRuntime.doTopCall((Callable) c, cx, scope, (Scriptable) null, args, cx.isTopLevelStrict);
      object obj = args.Length != 0 ? args[0] : Undefined.__\u003C\u003Einstance;
      if ((Interpreter.CallFrame) c.getImplementation() == null)
        return obj;
      return Interpreter.interpretLoop(cx, (Interpreter.CallFrame) null, (object) new Interpreter.ContinuationJump(c, (Interpreter.CallFrame) null)
      {
        result = obj
      });
    }

    [LineNumberTable(new byte[] {163, 3, 104, 167, 134, 113, 103, 99, 100, 102, 100, 101, 103, 103, 106, 102, 105, 105, 99, 99, 102, 101, 144, 119, 137, 105, 115, 101, 116, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptStackElement[][] getScriptStackElements(RhinoException ex)
    {
      if (ex.interpreterStackInfo == null)
        return (ScriptStackElement[][]) null;
      ArrayList arrayList1 = new ArrayList();
      Interpreter.CallFrame[] interpreterStackInfo = (Interpreter.CallFrame[]) ex.interpreterStackInfo;
      int[] interpreterLineData = ex.interpreterLineData;
      int length1 = interpreterStackInfo.Length;
      int length2 = interpreterLineData.Length;
      while (length1 != 0)
      {
        length1 += -1;
        Interpreter.CallFrame parentFrame = interpreterStackInfo[length1];
        ArrayList arrayList2 = new ArrayList();
        while (parentFrame != null)
        {
          if (length2 == 0)
            Kit.codeBug();
          length2 += -1;
          InterpreterData idata = parentFrame.idata;
          string itsSourceFile = idata.itsSourceFile;
          string functionName = (string) null;
          int lineNumber = -1;
          int num = interpreterLineData[length2];
          if (num >= 0)
            lineNumber = Interpreter.getIndex(idata.itsICode, num);
          if (idata.itsName != null && String.instancehelper_length(idata.itsName) != 0)
            functionName = idata.itsName;
          parentFrame = parentFrame.parentFrame;
          ((List) arrayList2).add((object) new ScriptStackElement(itsSourceFile, functionName, lineNumber));
        }
        ((List) arrayList1).add((object) ((List) arrayList2).toArray((object[]) new ScriptStackElement[0]));
      }
      return (ScriptStackElement[][]) ((List) arrayList1).toArray((object[]) new ScriptStackElement[((List) arrayList1).size()][]);
    }

    [LineNumberTable(new byte[] {163, 58, 142, 115, 103, 140, 188, 103, 35, 226, 61, 226, 71, 146, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object interpret(
      [In] InterpretedFunction obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      if (!ScriptRuntime.hasTopCall(obj1))
        Kit.codeBug();
      if (!object.ReferenceEquals(obj1.interpreterSecurityDomain, obj0.securityDomain))
      {
        object interpreterSecurityDomain = obj1.interpreterSecurityDomain;
        obj1.interpreterSecurityDomain = obj0.securityDomain;
        try
        {
          return obj0.securityController.callWithDomain(obj0.securityDomain, obj1, (Callable) obj0, obj2, obj3, obj4);
        }
        finally
        {
          obj1.interpreterSecurityDomain = interpreterSecurityDomain;
        }
      }
      else
      {
        Interpreter.CallFrame callFrame = Interpreter.initFrame(obj1, obj2, obj3, obj4, (double[]) null, 0, obj4.Length, obj0, (Interpreter.CallFrame) null);
        callFrame.isContinuationsTopFrame = obj1.isContinuationsTopCall;
        obj1.isContinuationsTopCall = false;
        return Interpreter.interpretLoop(obj1, callFrame, (object) null);
      }
    }

    [LineNumberTable(new byte[] {163, 40, 104, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getEncodedSource([In] InterpreterData obj0) => obj0.encodedSource == null ? (string) null : String.instancehelper_substring(obj0.encodedSource, obj0.encodedSourceStart, obj0.encodedSourceEnd);

    [LineNumberTable(new byte[] {163, 95, 103, 105, 132, 127, 4, 130, 107, 136, 134, 106, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object resumeGenerator(
      Context cx,
      Scriptable scope,
      int operation,
      object savedState,
      object value)
    {
      Interpreter.CallFrame callFrame = (Interpreter.CallFrame) savedState;
      Interpreter.GeneratorState generatorState = new Interpreter.GeneratorState(operation, value);
      if (operation == 2)
      {
        object obj;
        RuntimeException runtimeException1;
        try
        {
          obj = Interpreter.interpretLoop(cx, callFrame, (object) generatorState);
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException1 = (RuntimeException) m0;
            goto label_6;
          }
        }
        return obj;
label_6:
        RuntimeException runtimeException2 = runtimeException1;
        if (!object.ReferenceEquals((object) runtimeException2, value))
          throw Throwable.__\u003Cunmap\u003E((Exception) runtimeException2);
        return Undefined.__\u003C\u003Einstance;
      }
      object obj1 = Interpreter.interpretLoop(cx, callFrame, (object) generatorState);
      if (generatorState.returnedException != null)
        throw Throwable.__\u003Cunmap\u003E((Exception) generatorState.returnedException);
      return obj1;
    }

    [Modifiers]
    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object[] access\u0024000([In] object[] obj0, [In] double[] obj1, [In] int obj2, [In] int obj3) => Interpreter.getArgsArray(obj0, obj1, obj2, obj3);

    [Modifiers]
    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void access\u0024100(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] InterpretedFunction obj2,
      [In] int obj3)
    {
      Interpreter.initFunction(obj0, obj1, obj2, obj3);
    }

    [Modifiers]
    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool access\u0024200([In] InterpreterData obj0, [In] InterpreterData obj1) => Interpreter.compareIdata(obj0, obj1);

    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool compareIdata([In] InterpreterData obj0, [In] InterpreterData obj1) => object.ReferenceEquals((object) obj0, (object) obj1) || Objects.equals((object) Interpreter.getEncodedSource(obj0), (object) Interpreter.getEncodedSource(obj1));

    [LineNumberTable(new byte[] {163, 50, 106, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void initFunction(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] InterpretedFunction obj2,
      [In] int obj3)
    {
      InterpretedFunction function = InterpretedFunction.createFunction(obj0, obj1, obj2, obj3);
      ScriptRuntime.initFunction(obj0, obj1, (NativeFunction) function, function.idata.itsFunctionType, obj2.idata.evalScriptFlag);
    }

    [LineNumberTable(new byte[] {171, 148, 99, 134, 103, 102, 100, 109, 137, 228, 59, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object[] getArgsArray([In] object[] obj0, [In] double[] obj1, [In] int obj2, [In] int obj3)
    {
      if (obj3 == 0)
        return ScriptRuntime.__\u003C\u003EemptyArgs;
      object[] objArray = new object[obj3];
      int index = 0;
      while (index != obj3)
      {
        object objA = obj0[obj2];
        if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
          objA = (object) ScriptRuntime.wrapNumber(obj1[obj2]);
        objArray[index] = objA;
        ++index;
        ++obj2;
      }
      return objArray;
    }

    [LineNumberTable(new byte[] {162, 26, 255, 161, 220, 92, 226, 70, 226, 86, 226, 74, 130, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int bytecodeSpan([In] int obj0)
    {
      switch (obj0)
      {
        case -66:
        case -65:
        case -63:
        case -62:
        case -54:
        case -46:
        case -39:
        case -27:
        case -26:
        case -23:
        case -6:
        case 5:
        case 6:
        case 7:
        case 50:
        case 73:
          return 3;
        case -61:
        case -49:
        case -48:
        case -45:
        case -38:
        case -11:
        case -10:
        case -9:
        case -8:
        case -7:
        case 57:
          return 2;
        case -47:
        case -40:
        case -28:
          return 5;
        case -21:
          return 5;
        default:
          if (!Icode.validBytecode(obj0))
            throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
          return 1;
      }
    }

    [LineNumberTable(398)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getIndex([In] byte[] obj0, [In] int obj1) => (int) obj0[obj1] << 8 | (int) obj0[obj1 + 1];

    [LineNumberTable(new byte[] {170, 117, 108, 111, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Interpreter.CallFrame initFrame(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] Scriptable obj2,
      [In] object[] obj3,
      [In] double[] obj4,
      [In] int obj5,
      [In] int obj6,
      [In] InterpretedFunction obj7,
      [In] Interpreter.CallFrame obj8)
    {
      Interpreter.CallFrame callFrame = new Interpreter.CallFrame(obj0, obj2, obj7, obj8);
      callFrame.initializeArgs(obj0, obj1, obj3, obj4, obj5, obj6);
      Interpreter.enterFrame(obj0, callFrame, obj3, false);
      return callFrame;
    }

    [LineNumberTable(new byte[] {163, 144, 102, 134, 173, 131, 131, 98, 131, 168, 104, 139, 241, 74, 99, 99, 104, 168, 109, 101, 136, 198, 99, 231, 71, 195, 141, 104, 137, 242, 69, 104, 104, 109, 109, 109, 109, 237, 70, 168, 254, 72, 253, 69, 159, 163, 48, 171, 110, 104, 104, 109, 159, 5, 191, 0, 229, 71, 104, 152, 110, 113, 127, 164, 40, 229, 70, 103, 111, 109, 156, 218, 103, 107, 108, 134, 125, 148, 111, 159, 1, 186, 103, 118, 134, 111, 191, 19, 165, 107, 126, 229, 70, 112, 218, 112, 218, 102, 109, 107, 108, 218, 102, 109, 107, 108, 186, 112, 110, 223, 2, 112, 110, 223, 2, 112, 110, 130, 108, 159, 2, 133, 102, 102, 110, 154, 140, 107, 106, 106, 200, 255, 11, 69, 99, 136, 107, 103, 138, 127, 0, 165, 112, 99, 255, 7, 69, 102, 102, 154, 107, 108, 102, 102, 154, 108, 108, 102, 154, 110, 110, 108, 108, 102, 154, 103, 108, 105, 103, 108, 105, 186, 107, 108, 102, 154, 133, 103, 154, 106, 102, 106, 250, 71, 112, 186, 110, 109, 108, 115, 218, 108, 102, 102, 133, 103, 186, 102, 108, 250, 69, 112, 186, 103, 43, 134, 154, 120, 186, 103, 118, 102, 108, 117, 147, 134, 186, 103, 118, 102, 108, 112, 218, 113, 186, 103, 118, 148, 186, 103, 118, 148, 186, 103, 118, 102, 103, 118, 150, 186, 103, 118, 189, 110, 186, 111, 186, 111, 186, 113, 186, 108, 109, 186, 103, 118, 102, 108, 117, 186, 108, 109, 186, 108, 156, 110, 186, 102, 107, 106, 106, 154, 107, 102, 186, 102, 146, 102, 107, 154, 103, 150, 148, 102, 107, 186, 105, 120, 103, 118, 151, 107, 186, 103, 118, 109, 102, 107, 186, 99, 143, 115, 250, 69, 99, 207, 201, 108, 110, 102, 145, 145, 133, 104, 104, 141, 108, 105, 124, 99, 230, 80, 168, 136, 154, 102, 104, 136, 127, 7, 197, 169, 207, 100, 138, 110, 207, 127, 0, 165, 108, 105, 105, 150, 197, 105, 105, 105, 105, 121, 191, 28, 229, 72, 140, 105, 137, 105, 105, 121, 191, 23, 229, 69, 103, 104, 104, 117, 37, 166, 186, 99, 207, 135, 103, 108, 105, 121, 112, 189, 103, 104, 104, 127, 0, 165, 105, 118, 141, 137, 105, 105, 105, 112, 102, 194, 113, 117, 186, 103, 118, 108, 186, 119, 154, 108, 154, 102, 102, 115, 110, 154, 102, 102, 115, 110, 154, 102, 102, 115, 154, 120, 154, 159, 2, 110, 218, 191, 21, 150, 186, 150, 186, 116, 154, 151, 186, 102, 102, 106, 154, 102, 102, 106, 154, 108, 154, 113, 154, 113, 154, 112, 154, 112, 154, 108, 154, 103, 118, 102, 116, 186, 113, 250, 69, 102, 139, 122, 142, 100, 133, 140, 182, 110, 250, 70, 103, 118, 102, 107, 254, 71, 117, 218, 107, 103, 102, 108, 106, 102, 218, 103, 118, 148, 186, 107, 112, 154, 107, 107, 154, 182, 111, 159, 7, 141, 154, 116, 154, 112, 121, 186, 102, 108, 102, 108, 106, 154, 103, 118, 102, 108, 116, 106, 186, 103, 102, 108, 116, 117, 106, 186, 103, 102, 108, 116, 117, 106, 250, 69, 113, 102, 145, 102, 122, 148, 98, 99, 102, 154, 178, 103, 186, 106, 111, 100, 103, 113, 110, 162, 102, 191, 2, 104, 223, 7, 108, 104, 111, 142, 110, 154, 99, 154, 99, 154, 99, 154, 99, 154, 99, 154, 99, 154, 113, 110, 154, 111, 110, 154, 111, 110, 154, 101, 154, 101, 154, 101, 154, 101, 154, 115, 110, 154, 113, 110, 154, 113, 110, 154, 107, 255, 47, 72, 99, 136, 111, 132, 147, 114, 138, 99, 172, 154, 104, 104, 104, 104, 104, 104, 136, 138, 123, 133, 165, 98, 131, 108, 139, 228, 70, 169, 98, 98, 162, 131, 189, 104, 104, 104, 136, 104, 104, 104, 104, 104, 104, 178, 104, 178, 136, 99, 138, 240, 69, 134, 255, 22, 74, 226, 55, 98, 100, 227, 71, 226, 58, 162, 100, 99, 163, 176, 136, 255, 3, 71, 226, 58, 162, 100, 99, 227, 69, 100, 106, 106, 197, 229, 70, 136, 104, 99, 130, 179, 99, 229, 69, 100, 137, 134, 137, 99, 165, 105, 105, 229, 72, 110, 103, 103, 172, 135, 167, 99, 104, 172, 172, 144, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object interpretLoop([In] Context obj0, [In] Interpreter.CallFrame obj1, [In] object obj2)
    {
      UniqueTag doubleMark = UniqueTag.__\u003C\u003EDOUBLE_MARK;
      object instance = Undefined.__\u003C\u003Einstance;
      int num1 = obj0.instructionThreshold == 0 ? 0 : 1;
      string str1 = (string) null;
      int length = -1;
      if (obj0.lastInterpreterFrame != null)
      {
        if (obj0.previousInterpreterInvocations == null)
          obj0.previousInterpreterInvocations = new ObjArray();
        obj0.previousInterpreterInvocations.push(obj0.lastInterpreterFrame);
      }
      Interpreter.GeneratorState generatorState1 = (Interpreter.GeneratorState) null;
      switch (obj2)
      {
        case null:
        case Interpreter.ContinuationJump _:
          object objA1 = (object) null;
          double x = 0.0;
label_8:
          Exception exception1;
          Interpreter.ContinuationJump continuationJump1;
          while (true)
          {
            object[] stack1;
            double[] sDbl1;
            object[] stack2;
            double[] sDbl2;
            int[] stackAttributes;
            byte[] itsIcode;
            string[] itsStringTable;
            int index1;
            Exception exception2;
            try
            {
              if (obj2 != null)
              {
                obj1 = Interpreter.processThrowable(obj0, obj2, obj1, length, num1 != 0);
                obj2 = obj1.throwable;
                obj1.throwable = (object) null;
              }
              else if (generatorState1 == null && obj1.frozen)
                Kit.codeBug();
              stack1 = obj1.stack;
              sDbl1 = obj1.sDbl;
              stack2 = obj1.varSource.stack;
              sDbl2 = obj1.varSource.sDbl;
              stackAttributes = obj1.varSource.stackAttributes;
              itsIcode = obj1.idata.itsICode;
              itsStringTable = obj1.idata.itsStringTable;
              index1 = obj1.savedStackTop;
              obj0.lastInterpreterFrame = (object) obj1;
              goto label_15;
            }
            catch (Exception ex)
            {
              exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exception3 = exception2;
            goto label_489;
label_15:
            int num2;
            Exception exception4;
            Exception exception5;
            Exception exception6;
            Exception exception7;
            Exception exception8;
            Exception exception9;
            Exception exception10;
            Exception exception11;
            Exception exception12;
            Exception exception13;
            Exception exception14;
            Exception exception15;
            Exception exception16;
            Exception exception17;
            Exception exception18;
            Exception exception19;
            Exception exception20;
            Exception exception21;
            Exception exception22;
            Exception exception23;
            Exception exception24;
            Exception exception25;
            Exception exception26;
            Exception exception27;
            Exception exception28;
            Exception exception29;
            Exception exception30;
            Exception exception31;
            Exception exception32;
            Exception exception33;
            Exception exception34;
            Exception exception35;
            Exception exception36;
            Exception exception37;
            Exception exception38;
            Exception exception39;
            Exception exception40;
            Exception exception41;
            Exception exception42;
            Exception exception43;
            Exception exception44;
            Exception exception45;
            Exception exception46;
            Exception exception47;
            Exception exception48;
            Exception exception49;
            Exception exception50;
            Exception exception51;
            Exception exception52;
            Exception exception53;
            Exception exception54;
            Exception exception55;
            Exception exception56;
            Exception exception57;
            Exception exception58;
            Exception exception59;
            Exception exception60;
            Exception exception61;
            Exception exception62;
            Exception exception63;
            Exception exception64;
            Exception exception65;
            Exception exception66;
            Exception exception67;
            Exception exception68;
            Exception exception69;
            Exception exception70;
            Exception exception71;
            Exception exception72;
            Exception exception73;
            Exception exception74;
            Exception exception75;
            Exception exception76;
            Exception exception77;
            Exception exception78;
            Exception exception79;
            Exception exception80;
            Exception exception81;
            Exception exception82;
            Exception exception83;
            Exception exception84;
            Exception exception85;
            Exception exception86;
            Exception exception87;
            Exception exception88;
            Exception exception89;
            Exception exception90;
            Exception exception91;
            Exception exception92;
            Exception exception93;
            Exception exception94;
            Exception exception95;
            Exception exception96;
            Exception exception97;
            Exception exception98;
            Exception exception99;
            Exception exception100;
            Exception exception101;
            Exception exception102;
            Exception exception103;
            Exception exception104;
            Exception exception105;
            Exception exception106;
            Exception exception107;
            Exception exception108;
            Exception exception109;
            Exception exception110;
            Exception exception111;
            Exception exception112;
            Exception exception113;
            while (true)
            {
              try
              {
                object objA2;
                do
                {
                  byte[] numArray = itsIcode;
                  Interpreter.CallFrame callFrame1 = obj1;
                  int pc = callFrame1.pc;
                  Interpreter.CallFrame callFrame2 = callFrame1;
                  int index2 = pc;
                  callFrame2.pc = pc + 1;
                  num2 = (int) (sbyte) numArray[index2];
                  switch (num2)
                  {
                    case -66:
                    case 73:
                      if (!obj1.frozen)
                        return Interpreter.freezeGenerator(obj0, obj1, index1, generatorState1, num2 == -66);
                      objA2 = Interpreter.thawGenerator(obj1, index1, generatorState1, num2);
                      continue;
                    case -65:
                      goto label_29;
                    case -64:
                      goto label_414;
                    case -63:
                      goto label_26;
                    case -62:
                      if (!obj1.frozen)
                      {
                        --obj1.pc;
                        Interpreter.CallFrame callFrame3 = Interpreter.captureFrameForGenerator(obj1);
                        callFrame3.frozen = true;
                        if (obj0.getLanguageVersion() >= 200)
                        {
                          Interpreter.CallFrame callFrame4 = obj1;
                          ES6Generator.__\u003Cclinit\u003E();
                          ES6Generator es6Generator = new ES6Generator(obj1.scope, (NativeFunction) callFrame3.fnOrScript, (object) callFrame3);
                          callFrame4.result = (object) es6Generator;
                          goto label_483;
                        }
                        else
                        {
                          Interpreter.CallFrame callFrame4 = obj1;
                          NativeGenerator.__\u003Cclinit\u003E();
                          NativeGenerator nativeGenerator = new NativeGenerator(obj1.scope, (NativeFunction) callFrame3.fnOrScript, (object) callFrame3);
                          callFrame4.result = (object) nativeGenerator;
                          goto label_483;
                        }
                      }
                      else
                        goto case -66;
                    case -61:
                    case -49:
                    case -48:
                      goto label_302;
                    case -59:
                      goto label_136;
                    case -58:
                      goto label_398;
                    case -57:
                      goto label_395;
                    case -56:
                      goto label_192;
                    case -55:
                    case 38:
                    case 71:
                      goto label_220;
                    case -54:
                      goto label_409;
                    case -52:
                      goto label_320;
                    case -51:
                      goto label_317;
                    case -50:
                      goto label_338;
                    case -47:
                      goto label_468;
                    case -46:
                      goto label_465;
                    case -45:
                      goto label_462;
                    case -44:
                      goto label_459;
                    case -43:
                      goto label_456;
                    case -42:
                      goto label_453;
                    case -41:
                      goto label_450;
                    case -40:
                      goto label_447;
                    case -39:
                      goto label_444;
                    case -38:
                      goto label_441;
                    case -37:
                      goto label_438;
                    case -36:
                      goto label_435;
                    case -35:
                      goto label_432;
                    case -34:
                      goto label_429;
                    case -33:
                      goto label_426;
                    case -32:
                      goto label_423;
                    case -31:
                    case 66:
                    case 67:
                      goto label_401;
                    case -30:
                      goto label_390;
                    case -29:
                      goto label_387;
                    case -28:
                      goto label_290;
                    case -27:
                      goto label_287;
                    case -26:
                      goto label_418;
                    case -25:
                      goto label_74;
                    case -24:
                      goto label_68;
                    case -23:
                      goto label_65;
                    case -22:
                      goto label_102;
                    case -21:
                      goto label_215;
                    case -20:
                      goto label_381;
                    case -19:
                      goto label_376;
                    case -18:
                      goto label_210;
                    case -17:
                      goto label_203;
                    case -16:
                      goto label_198;
                    case -15:
                      goto label_195;
                    case -14:
                      goto label_281;
                    case -13:
                      goto label_373;
                    case -12:
                      goto label_370;
                    case -11:
                      goto label_186;
                    case -10:
                      goto label_172;
                    case -9:
                      goto label_161;
                    case -8:
                      goto label_299;
                    case -7:
                      goto label_314;
                    case -6:
                      goto label_60;
                    case -5:
                      goto label_87;
                    case -4:
                      goto label_84;
                    case -3:
                      goto label_96;
                    case -2:
                      goto label_93;
                    case -1:
                      goto label_90;
                    case 0:
                    case 31:
                      goto label_141;
                    case 2:
                      goto label_341;
                    case 3:
                      goto label_346;
                    case 4:
                      goto label_99;
                    case 5:
                      goto label_474;
                    case 6:
                      goto label_56;
                    case 7:
                      goto label_52;
                    case 8:
                    case 74:
                      goto label_131;
                    case 9:
                    case 10:
                    case 11:
                    case 18:
                    case 19:
                      goto label_108;
                    case 12:
                    case 13:
                      goto label_46;
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                      goto label_40;
                    case 20:
                      goto label_111;
                    case 21:
                      goto label_119;
                    case 22:
                    case 23:
                    case 24:
                    case 25:
                      goto label_122;
                    case 26:
                      goto label_125;
                    case 27:
                      goto label_105;
                    case 28:
                    case 29:
                      goto label_114;
                    case 30:
                      goto label_260;
                    case 32:
                      goto label_276;
                    case 33:
                      goto label_149;
                    case 34:
                      goto label_144;
                    case 35:
                      goto label_154;
                    case 36:
                      goto label_166;
                    case 37:
                      goto label_169;
                    case 39:
                      goto label_296;
                    case 40:
                      goto label_293;
                    case 41:
                      goto label_284;
                    case 42:
                      goto label_323;
                    case 43:
                      goto label_326;
                    case 44:
                      goto label_332;
                    case 45:
                      goto label_335;
                    case 46:
                    case 47:
                      goto label_49;
                    case 48:
                      goto label_384;
                    case 49:
                      goto label_128;
                    case 50:
                      goto label_32;
                    case 51:
                      goto label_37;
                    case 52:
                    case 53:
                      goto label_43;
                    case 54:
                      goto label_189;
                    case 55:
                      goto label_311;
                    case 56:
                      goto label_308;
                    case 57:
                      goto label_349;
                    case 58:
                    case 59:
                    case 60:
                    case 61:
                      goto label_352;
                    case 62:
                    case 63:
                      goto label_362;
                    case 64:
                      goto label_329;
                    case 65:
                      goto label_483;
                    case 68:
                      goto label_175;
                    case 69:
                      goto label_178;
                    case 70:
                      goto label_183;
                    case 72:
                      goto label_365;
                    case 157:
                      goto label_305;
                    default:
                      goto label_471;
                  }
                }
                while (object.ReferenceEquals(objA2, Scriptable.NOT_FOUND));
                obj2 = objA2;
                goto label_492;
              }
              catch (Exception ex)
              {
                exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                break;
              }
label_40:
              try
              {
                index1 = Interpreter.doCompare(obj1, num2, stack1, sDbl1, index1);
                continue;
              }
              catch (Exception ex)
              {
                exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_42;
              }
label_43:
              try
              {
                index1 = Interpreter.doInOrInstanceof(obj0, num2, stack1, sDbl1, index1);
                continue;
              }
              catch (Exception ex)
              {
                exception6 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_45;
              }
label_46:
              try
              {
                index1 += -1;
                int num3 = Interpreter.doEquals(stack1, sDbl1, index1) ^ num2 == 13 ? 1 : 0;
                stack1[index1] = (object) ScriptRuntime.wrapBoolean(num3 != 0);
                continue;
              }
              catch (Exception ex)
              {
                exception7 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_48;
              }
label_49:
              try
              {
                index1 += -1;
                int num3 = Interpreter.doShallowEquals(stack1, sDbl1, index1) ^ num2 == 47 ? 1 : 0;
                stack1[index1] = (object) ScriptRuntime.wrapBoolean(num3 != 0);
                continue;
              }
              catch (Exception ex)
              {
                exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_51;
              }
label_52:
              try
              {
                Interpreter.CallFrame callFrame = obj1;
                int num3 = index1;
                index1 += -1;
                if (Interpreter.stack_boolean(callFrame, num3))
                {
                  obj1.pc += 2;
                  continue;
                }
                goto label_474;
              }
              catch (Exception ex)
              {
                exception9 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_55;
              }
label_56:
              try
              {
                Interpreter.CallFrame callFrame = obj1;
                int num3 = index1;
                index1 += -1;
                if (!Interpreter.stack_boolean(callFrame, num3))
                {
                  obj1.pc += 2;
                  continue;
                }
                goto label_474;
              }
              catch (Exception ex)
              {
                exception10 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_59;
              }
label_60:
              try
              {
                Interpreter.CallFrame callFrame = obj1;
                int num3 = index1;
                index1 += -1;
                if (!Interpreter.stack_boolean(callFrame, num3))
                {
                  obj1.pc += 2;
                  continue;
                }
                object[] objArray = stack1;
                int index2 = index1;
                index1 += -1;
                objArray[index2] = (object) null;
                goto label_474;
              }
              catch (Exception ex)
              {
                exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_64;
              }
label_65:
              try
              {
                ++index1;
                stack1[index1] = (object) doubleMark;
                sDbl1[index1] = (double) (obj1.pc + 2);
                goto label_474;
              }
              catch (Exception ex)
              {
                exception12 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_67;
              }
label_68:
              try
              {
                if (index1 == obj1.emptyStackTop + 1)
                {
                  length += obj1.localShift;
                  stack1[length] = stack1[index1];
                  sDbl1[length] = sDbl1[index1];
                  index1 += -1;
                  continue;
                }
                if (index1 != obj1.emptyStackTop)
                {
                  Kit.codeBug();
                  continue;
                }
                continue;
              }
              catch (Exception ex)
              {
                exception13 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_73;
              }
label_74:
              try
              {
                if (num1 != 0)
                  Interpreter.addInstructionCount(obj0, obj1, 0);
                length += obj1.localShift;
                object objA2 = stack1[length];
                if (!object.ReferenceEquals(objA2, (object) doubleMark))
                {
                  obj2 = objA2;
                  goto label_492;
                }
              }
              catch (Exception ex)
              {
                exception14 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_79;
              }
              try
              {
                obj1.pc = ByteCodeHelper.d2i(sDbl1[length]);
                if (num1 != 0)
                {
                  obj1.pcPrevBranch = obj1.pc;
                  continue;
                }
                continue;
              }
              catch (Exception ex)
              {
                exception15 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_83;
              }
label_84:
              try
              {
                stack1[index1] = (object) null;
                index1 += -1;
                continue;
              }
              catch (Exception ex)
              {
                exception16 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_86;
              }
label_87:
              try
              {
                obj1.result = stack1[index1];
                obj1.resultDbl = sDbl1[index1];
                stack1[index1] = (object) null;
                index1 += -1;
                continue;
              }
              catch (Exception ex)
              {
                exception17 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_89;
              }
label_90:
              try
              {
                stack1[index1 + 1] = stack1[index1];
                sDbl1[index1 + 1] = sDbl1[index1];
                ++index1;
                continue;
              }
              catch (Exception ex)
              {
                exception18 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_92;
              }
label_93:
              try
              {
                stack1[index1 + 1] = stack1[index1 - 1];
                sDbl1[index1 + 1] = sDbl1[index1 - 1];
                stack1[index1 + 2] = stack1[index1];
                sDbl1[index1 + 2] = sDbl1[index1];
                index1 += 2;
                continue;
              }
              catch (Exception ex)
              {
                exception19 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_95;
              }
label_96:
              try
              {
                object obj = stack1[index1];
                stack1[index1] = stack1[index1 - 1];
                stack1[index1 - 1] = obj;
                double num3 = sDbl1[index1];
                sDbl1[index1] = sDbl1[index1 - 1];
                sDbl1[index1 - 1] = num3;
                continue;
              }
              catch (Exception ex)
              {
                exception20 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_98;
              }
label_105:
              try
              {
                int num3 = Interpreter.stack_int32(obj1, index1);
                stack1[index1] = (object) doubleMark;
                sDbl1[index1] = (double) (num3 ^ -1);
                continue;
              }
              catch (Exception ex)
              {
                exception21 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_107;
              }
label_108:
              try
              {
                index1 = Interpreter.doBitOp(obj1, num2, stack1, sDbl1, index1);
                continue;
              }
              catch (Exception ex)
              {
                exception22 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_110;
              }
label_111:
              try
              {
                double d = Interpreter.stack_double(obj1, index1 - 1);
                int num3 = Interpreter.stack_int32(obj1, index1) & 31;
                object[] objArray = stack1;
                index1 += -1;
                int index2 = index1;
                UniqueTag uniqueTag = doubleMark;
                objArray[index2] = (object) uniqueTag;
                sDbl1[index1] = (double) (long) ((ulong) ScriptRuntime.toUint32(d) >> num3);
                continue;
              }
              catch (Exception ex)
              {
                exception23 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_113;
              }
label_114:
              try
              {
                double num3 = Interpreter.stack_double(obj1, index1);
                stack1[index1] = (object) doubleMark;
                if (num2 == 29)
                  num3 = -num3;
                sDbl1[index1] = num3;
                continue;
              }
              catch (Exception ex)
              {
                exception24 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_118;
              }
label_119:
              try
              {
                index1 += -1;
                Interpreter.doAdd(stack1, sDbl1, index1, obj0);
                continue;
              }
              catch (Exception ex)
              {
                exception25 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_121;
              }
label_122:
              try
              {
                index1 = Interpreter.doArithmetic(obj1, num2, stack1, sDbl1, index1);
                continue;
              }
              catch (Exception ex)
              {
                exception26 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_124;
              }
label_125:
              try
              {
                stack1[index1] = (object) ScriptRuntime.wrapBoolean(!Interpreter.stack_boolean(obj1, index1));
                continue;
              }
              catch (Exception ex)
              {
                exception27 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_127;
              }
label_128:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                Scriptable scriptable = ScriptRuntime.bind(obj0, obj1.scope, str1);
                objArray[index2] = (object) scriptable;
                continue;
              }
              catch (Exception ex)
              {
                exception28 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_130;
              }
label_131:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                index1 += -1;
                Scriptable bound = (Scriptable) stack1[index1];
                stack1[index1] = num2 != 8 ? ScriptRuntime.strictSetName(bound, objA2, obj0, obj1.scope, str1) : ScriptRuntime.setName(bound, objA2, obj0, obj1.scope, str1);
                continue;
              }
              catch (Exception ex)
              {
                exception29 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_135;
              }
label_136:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                index1 += -1;
                Scriptable bound = (Scriptable) stack1[index1];
                stack1[index1] = ScriptRuntime.setConst(bound, objA2, obj0, str1);
                continue;
              }
              catch (Exception ex)
              {
                exception30 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_140;
              }
label_141:
              try
              {
                index1 = Interpreter.doDelName(obj0, obj1, num2, stack1, sDbl1, index1);
                continue;
              }
              catch (Exception ex)
              {
                exception31 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_143;
              }
label_144:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                stack1[index1] = ScriptRuntime.getObjectPropNoWarn(objA2, str1, obj0, obj1.scope);
                continue;
              }
              catch (Exception ex)
              {
                exception32 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_148;
              }
label_149:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                stack1[index1] = ScriptRuntime.getObjectProp(objA2, str1, obj0, obj1.scope);
                continue;
              }
              catch (Exception ex)
              {
                exception33 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_153;
              }
label_154:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                index1 += -1;
                object objA3 = stack1[index1];
                if (object.ReferenceEquals(objA3, (object) doubleMark))
                  objA3 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                stack1[index1] = ScriptRuntime.setObjectProp(objA3, str1, objA2, obj0, obj1.scope);
                continue;
              }
              catch (Exception ex)
              {
                exception34 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_160;
              }
label_161:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                stack1[index1] = ScriptRuntime.propIncrDecr(objA2, str1, obj0, obj1.scope, (int) (sbyte) itsIcode[obj1.pc]);
                ++obj1.pc;
                continue;
              }
              catch (Exception ex)
              {
                exception35 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_165;
              }
label_166:
              try
              {
                index1 = Interpreter.doGetElem(obj0, obj1, stack1, sDbl1, index1);
                continue;
              }
              catch (Exception ex)
              {
                exception36 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_168;
              }
label_169:
              try
              {
                index1 = Interpreter.doSetElem(obj0, obj1, stack1, sDbl1, index1);
                continue;
              }
              catch (Exception ex)
              {
                exception37 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_171;
              }
label_172:
              try
              {
                index1 = Interpreter.doElemIncDec(obj0, obj1, itsIcode, stack1, sDbl1, index1);
                continue;
              }
              catch (Exception ex)
              {
                exception38 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_174;
              }
label_175:
              try
              {
                Ref @ref = (Ref) stack1[index1];
                stack1[index1] = ScriptRuntime.refGet(@ref, obj0);
                continue;
              }
              catch (Exception ex)
              {
                exception39 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_177;
              }
label_178:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                index1 += -1;
                Ref @ref = (Ref) stack1[index1];
                stack1[index1] = ScriptRuntime.refSet(@ref, objA2, obj0, obj1.scope);
                continue;
              }
              catch (Exception ex)
              {
                exception40 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_182;
              }
label_183:
              try
              {
                Ref @ref = (Ref) stack1[index1];
                stack1[index1] = ScriptRuntime.refDel(@ref, obj0);
                continue;
              }
              catch (Exception ex)
              {
                exception41 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_185;
              }
label_186:
              try
              {
                Ref @ref = (Ref) stack1[index1];
                stack1[index1] = ScriptRuntime.refIncrDecr(@ref, obj0, obj1.scope, (int) (sbyte) itsIcode[obj1.pc]);
                ++obj1.pc;
                continue;
              }
              catch (Exception ex)
              {
                exception42 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_188;
              }
label_189:
              try
              {
                ++index1;
                length += obj1.localShift;
                stack1[index1] = stack1[length];
                sDbl1[index1] = sDbl1[length];
                continue;
              }
              catch (Exception ex)
              {
                exception43 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_191;
              }
label_192:
              try
              {
                length += obj1.localShift;
                stack1[length] = (object) null;
                continue;
              }
              catch (Exception ex)
              {
                exception44 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_194;
              }
label_195:
              try
              {
                int index2 = index1 + 1;
                stack1[index2] = (object) ScriptRuntime.getNameFunctionAndThis(str1, obj0, obj1.scope);
                index1 = index2 + 1;
                stack1[index1] = (object) ScriptRuntime.lastStoredScriptable(obj0);
                continue;
              }
              catch (Exception ex)
              {
                exception45 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_197;
              }
label_198:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                stack1[index1] = (object) ScriptRuntime.getPropFunctionAndThis(objA2, str1, obj0, obj1.scope);
                ++index1;
                stack1[index1] = (object) ScriptRuntime.lastStoredScriptable(obj0);
                continue;
              }
              catch (Exception ex)
              {
                exception46 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_202;
              }
label_203:
              try
              {
                object objA2 = stack1[index1 - 1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1 - 1]);
                object obj = stack1[index1];
                if (object.ReferenceEquals(obj, (object) doubleMark))
                  obj = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                stack1[index1 - 1] = (object) ScriptRuntime.getElemFunctionAndThis(objA2, obj, obj0, obj1.scope);
                stack1[index1] = (object) ScriptRuntime.lastStoredScriptable(obj0);
                continue;
              }
              catch (Exception ex)
              {
                exception47 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_209;
              }
label_210:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                stack1[index1] = (object) ScriptRuntime.getValueFunctionAndThis(objA2, obj0);
                ++index1;
                stack1[index1] = (object) ScriptRuntime.lastStoredScriptable(obj0);
                continue;
              }
              catch (Exception ex)
              {
                exception48 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_214;
              }
label_215:
              try
              {
                if (num1 != 0)
                  obj0.instructionCount += 100;
                index1 = Interpreter.doCallSpecial(obj0, obj1, stack1, sDbl1, index1, itsIcode, length);
                continue;
              }
              catch (Exception ex)
              {
                exception49 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_219;
              }
label_220:
              Callable function1;
              Scriptable scriptable1;
              Scriptable s1;
              try
              {
                if (num1 != 0)
                  obj0.instructionCount += 100;
                index1 -= 1 + length;
                function1 = (Callable) stack1[index1];
                scriptable1 = (Scriptable) stack1[index1 + 1];
                if (num2 == 71)
                {
                  object[] argsArray = Interpreter.getArgsArray(stack1, sDbl1, index1 + 2, length);
                  stack1[index1] = (object) ScriptRuntime.callRef(function1, scriptable1, argsArray, obj0);
                  continue;
                }
                s1 = obj1.scope;
                if (obj1.useActivation)
                  s1 = ScriptableObject.getTopLevelScope(obj1.scope);
                if (function1 is InterpretedFunction)
                {
                  InterpretedFunction interpretedFunction = (InterpretedFunction) function1;
                  if (object.ReferenceEquals(obj1.fnOrScript.securityDomain, interpretedFunction.securityDomain))
                  {
                    Interpreter.CallFrame callFrame1 = obj1;
                    if (num2 == -55)
                    {
                      callFrame1 = obj1.parentFrame;
                      Interpreter.exitFrame(obj0, obj1, (object) null);
                    }
                    Interpreter.CallFrame callFrame2 = Interpreter.initFrame(obj0, s1, scriptable1, stack1, sDbl1, index1 + 2, length, interpretedFunction, callFrame1);
                    if (num2 != -55)
                    {
                      obj1.savedStackTop = index1;
                      obj1.savedCallOp = num2;
                    }
                    obj1 = callFrame2;
                    goto label_8;
                  }
                }
              }
              catch (Exception ex)
              {
                exception50 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_234;
              }
              try
              {
                if (function1 is NativeContinuation)
                {
                  Interpreter.ContinuationJump continuationJump2 = new Interpreter.ContinuationJump((NativeContinuation) function1, obj1);
                  if (length == 0)
                  {
                    continuationJump2.result = instance;
                  }
                  else
                  {
                    continuationJump2.result = stack1[index1 + 2];
                    continuationJump2.resultDbl = sDbl1[index1 + 2];
                  }
                  obj2 = (object) continuationJump2;
                  goto label_492;
                }
              }
              catch (Exception ex)
              {
                exception51 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_241;
              }
              try
              {
                if (function1 is IdFunctionObject)
                {
                  IdFunctionObject f = (IdFunctionObject) function1;
                  if (NativeContinuation.isContinuationConstructor(f))
                  {
                    obj1.stack[index1] = (object) Interpreter.captureContinuation(obj0, obj1.parentFrame, false);
                    continue;
                  }
                  if (BaseFunction.isApplyOrCall(f))
                  {
                    Callable callable = ScriptRuntime.getCallable(scriptable1);
                    if (callable is InterpretedFunction)
                    {
                      InterpretedFunction interpretedFunction = (InterpretedFunction) callable;
                      if (object.ReferenceEquals(obj1.fnOrScript.securityDomain, interpretedFunction.securityDomain))
                      {
                        obj1 = Interpreter.initFrameForApplyOrCall(obj0, obj1, length, stack1, sDbl1, index1, num2, s1, f, interpretedFunction);
                        goto label_8;
                      }
                    }
                  }
                }
              }
              catch (Exception ex)
              {
                exception52 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_250;
              }
              try
              {
                if (function1 is ScriptRuntime.NoSuchMethodShim)
                {
                  ScriptRuntime.NoSuchMethodShim noSuchMethodShim = (ScriptRuntime.NoSuchMethodShim) function1;
                  Callable suchMethodMethod = noSuchMethodShim.noSuchMethodMethod;
                  if (suchMethodMethod is InterpretedFunction)
                  {
                    InterpretedFunction interpretedFunction = (InterpretedFunction) suchMethodMethod;
                    if (object.ReferenceEquals(obj1.fnOrScript.securityDomain, interpretedFunction.securityDomain))
                    {
                      obj1 = Interpreter.initFrameForNoSuchMethod(obj0, obj1, length, stack1, sDbl1, index1, num2, scriptable1, s1, noSuchMethodShim, interpretedFunction);
                      goto label_8;
                    }
                  }
                }
              }
              catch (Exception ex)
              {
                exception53 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_256;
              }
              try
              {
                obj0.lastInterpreterFrame = (object) obj1;
                obj1.savedCallOp = num2;
                obj1.savedStackTop = index1;
                stack1[index1] = function1.call(obj0, s1, scriptable1, Interpreter.getArgsArray(stack1, sDbl1, index1 + 2, length));
                continue;
              }
              catch (Exception ex)
              {
                exception54 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_259;
              }
label_260:
              object objA4;
              try
              {
                if (num1 != 0)
                  obj0.instructionCount += 100;
                index1 -= length;
                objA4 = stack1[index1];
                if (objA4 is InterpretedFunction)
                {
                  InterpretedFunction interpretedFunction = (InterpretedFunction) objA4;
                  if (object.ReferenceEquals(obj1.fnOrScript.securityDomain, interpretedFunction.securityDomain))
                  {
                    Scriptable scriptable2 = interpretedFunction.createObject(obj0, obj1.scope);
                    Interpreter.CallFrame callFrame = Interpreter.initFrame(obj0, obj1.scope, scriptable2, stack1, sDbl1, index1 + 1, length, interpretedFunction, obj1);
                    stack1[index1] = (object) scriptable2;
                    obj1.savedStackTop = index1;
                    obj1.savedCallOp = num2;
                    obj1 = callFrame;
                    goto label_8;
                  }
                }
              }
              catch (Exception ex)
              {
                exception55 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_266;
              }
              try
              {
                if (!(objA4 is Function))
                {
                  objA4 = object.ReferenceEquals(objA4, (object) doubleMark) ? (object) ScriptRuntime.wrapNumber(sDbl1[index1]) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(objA4));
                }
                else
                {
                  Function function2 = (Function) objA4;
                  if (function2 is IdFunctionObject && NativeContinuation.isContinuationConstructor((IdFunctionObject) function2))
                  {
                    obj1.stack[index1] = (object) Interpreter.captureContinuation(obj0, obj1.parentFrame, false);
                    continue;
                  }
                  object[] argsArray = Interpreter.getArgsArray(stack1, sDbl1, index1 + 1, length);
                  stack1[index1] = (object) function2.construct(obj0, obj1.scope, argsArray);
                  continue;
                }
              }
              catch (Exception ex)
              {
                exception56 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_275;
              }
label_276:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                stack1[index1] = (object) ScriptRuntime.@typeof(objA2);
                continue;
              }
              catch (Exception ex)
              {
                exception57 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_280;
              }
label_281:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                string str2 = ScriptRuntime.typeofName(obj1.scope, str1);
                objArray[index2] = (object) str2;
                continue;
              }
              catch (Exception ex)
              {
                exception58 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_283;
              }
label_284:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                string str2 = str1;
                objArray[index2] = (object) str2;
                continue;
              }
              catch (Exception ex)
              {
                exception59 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_286;
              }
label_287:
              try
              {
                ++index1;
                stack1[index1] = (object) doubleMark;
                sDbl1[index1] = (double) Interpreter.getShort(itsIcode, obj1.pc);
                obj1.pc += 2;
                continue;
              }
              catch (Exception ex)
              {
                exception60 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_289;
              }
label_290:
              try
              {
                ++index1;
                stack1[index1] = (object) doubleMark;
                sDbl1[index1] = (double) Interpreter.getInt(itsIcode, obj1.pc);
                obj1.pc += 4;
                continue;
              }
              catch (Exception ex)
              {
                exception61 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_292;
              }
label_293:
              try
              {
                ++index1;
                stack1[index1] = (object) doubleMark;
                sDbl1[index1] = obj1.idata.itsDoubleTable[length];
                continue;
              }
              catch (Exception ex)
              {
                exception62 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_295;
              }
label_296:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                object obj = ScriptRuntime.name(obj0, obj1.scope, str1);
                objArray[index2] = obj;
                continue;
              }
              catch (Exception ex)
              {
                exception63 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_298;
              }
label_299:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                object obj = ScriptRuntime.nameIncrDecr(obj1.scope, str1, obj0, (int) (sbyte) itsIcode[obj1.pc]);
                objArray[index2] = obj;
                ++obj1.pc;
                continue;
              }
              catch (Exception ex)
              {
                exception64 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_301;
              }
label_302:
              try
              {
                byte[] numArray = itsIcode;
                Interpreter.CallFrame callFrame1 = obj1;
                int pc = callFrame1.pc;
                Interpreter.CallFrame callFrame2 = callFrame1;
                int index2 = pc;
                callFrame2.pc = pc + 1;
                length = (int) (sbyte) numArray[index2];
              }
              catch (Exception ex)
              {
                exception65 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_304;
              }
label_305:
              try
              {
                index1 = Interpreter.doSetConstVar(obj1, stack1, sDbl1, index1, stack2, sDbl2, stackAttributes, length);
                continue;
              }
              catch (Exception ex)
              {
                exception66 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_307;
              }
label_308:
              try
              {
                index1 = Interpreter.doSetVar(obj1, stack1, sDbl1, index1, stack2, sDbl2, stackAttributes, length);
                continue;
              }
              catch (Exception ex)
              {
                exception67 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_310;
              }
label_311:
              try
              {
                index1 = Interpreter.doGetVar(obj1, stack1, sDbl1, index1, stack2, sDbl2, length);
                continue;
              }
              catch (Exception ex)
              {
                exception68 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_313;
              }
label_314:
              try
              {
                index1 = Interpreter.doVarIncDec(obj0, obj1, stack1, sDbl1, index1, stack2, sDbl2, stackAttributes, length);
                continue;
              }
              catch (Exception ex)
              {
                exception69 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_316;
              }
label_317:
              try
              {
                ++index1;
                stack1[index1] = (object) doubleMark;
                sDbl1[index1] = 0.0;
                continue;
              }
              catch (Exception ex)
              {
                exception70 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_319;
              }
label_320:
              try
              {
                ++index1;
                stack1[index1] = (object) doubleMark;
                sDbl1[index1] = 1.0;
                continue;
              }
              catch (Exception ex)
              {
                exception71 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_322;
              }
label_323:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                objArray[index2] = (object) null;
                continue;
              }
              catch (Exception ex)
              {
                exception72 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_325;
              }
label_326:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                Scriptable thisObj = obj1.thisObj;
                objArray[index2] = (object) thisObj;
                continue;
              }
              catch (Exception ex)
              {
                exception73 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_328;
              }
label_329:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                InterpretedFunction fnOrScript = obj1.fnOrScript;
                objArray[index2] = (object) fnOrScript;
                continue;
              }
              catch (Exception ex)
              {
                exception74 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_331;
              }
label_332:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                // ISSUE: variable of the null type
                __Null local = Boolean.FALSE;
                objArray[index2] = (object) local;
                continue;
              }
              catch (Exception ex)
              {
                exception75 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_334;
              }
label_335:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                // ISSUE: variable of the null type
                __Null local = Boolean.TRUE;
                objArray[index2] = (object) local;
                continue;
              }
              catch (Exception ex)
              {
                exception76 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_337;
              }
label_338:
              try
              {
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                object obj = instance;
                objArray[index2] = obj;
                continue;
              }
              catch (Exception ex)
              {
                exception77 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_340;
              }
label_341:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                index1 += -1;
                obj1.scope = ScriptRuntime.enterWith(objA2, obj0, obj1.scope);
                continue;
              }
              catch (Exception ex)
              {
                exception78 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_345;
              }
label_346:
              try
              {
                obj1.scope = ScriptRuntime.leaveWith(obj1.scope);
                continue;
              }
              catch (Exception ex)
              {
                exception79 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_348;
              }
label_349:
              try
              {
                index1 += -1;
                length += obj1.localShift;
                int num3 = obj1.idata.itsICode[obj1.pc] == (byte) 0 ? 0 : 1;
                Exception t = (Exception) stack1[index1 + 1];
                Scriptable lastCatchScope = num3 != 0 ? (Scriptable) stack1[length] : (Scriptable) null;
                stack1[length] = (object) ScriptRuntime.newCatchScope(t, lastCatchScope, str1, obj0, obj1.scope);
                ++obj1.pc;
                continue;
              }
              catch (Exception ex)
              {
                exception80 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_351;
              }
label_352:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                index1 += -1;
                length += obj1.localShift;
                int num3;
                switch (num2)
                {
                  case 58:
                    num3 = 0;
                    break;
                  case 59:
                    num3 = 1;
                    break;
                  case 61:
                    num3 = 6;
                    break;
                  default:
                    num3 = 2;
                    break;
                }
                int enumType = num3;
                stack1[length] = ScriptRuntime.enumInit(objA2, obj0, obj1.scope, enumType);
                continue;
              }
              catch (Exception ex)
              {
                exception81 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_361;
              }
label_362:
              try
              {
                length += obj1.localShift;
                object enumObj = stack1[length];
                ++index1;
                stack1[index1] = num2 != 62 ? ScriptRuntime.enumId(enumObj, obj0) : (object) ScriptRuntime.enumNext(enumObj);
                continue;
              }
              catch (Exception ex)
              {
                exception82 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_364;
              }
label_365:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                stack1[index1] = (object) ScriptRuntime.specialRef(objA2, str1, obj0, obj1.scope);
                continue;
              }
              catch (Exception ex)
              {
                exception83 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_369;
              }
label_370:
              try
              {
                length += obj1.localShift;
                obj1.scope = (Scriptable) stack1[length];
                continue;
              }
              catch (Exception ex)
              {
                exception84 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_372;
              }
label_373:
              try
              {
                length += obj1.localShift;
                stack1[length] = (object) obj1.scope;
                continue;
              }
              catch (Exception ex)
              {
                exception85 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_375;
              }
label_376:
              try
              {
                InterpretedFunction function2 = InterpretedFunction.createFunction(obj0, obj1.scope, obj1.fnOrScript, length);
                if (function2.idata.itsFunctionType == 4)
                {
                  object[] objArray = stack1;
                  ++index1;
                  int index2 = index1;
                  ArrowFunction.__\u003Cclinit\u003E();
                  ArrowFunction arrowFunction = new ArrowFunction(obj0, obj1.scope, (Callable) function2, obj1.thisObj);
                  objArray[index2] = (object) arrowFunction;
                  continue;
                }
                object[] objArray1 = stack1;
                ++index1;
                int index3 = index1;
                InterpretedFunction interpretedFunction = function2;
                objArray1[index3] = (object) interpretedFunction;
                continue;
              }
              catch (Exception ex)
              {
                exception86 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_380;
              }
label_381:
              try
              {
                Interpreter.initFunction(obj0, obj1.scope, obj1.fnOrScript, length);
                continue;
              }
              catch (Exception ex)
              {
                exception87 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_383;
              }
label_384:
              try
              {
                object itsRegExpLiteral = obj1.idata.itsRegExpLiterals[length];
                object[] objArray = stack1;
                ++index1;
                int index2 = index1;
                Scriptable scriptable2 = ScriptRuntime.wrapRegExp(obj0, obj1.scope, itsRegExpLiteral);
                objArray[index2] = (object) scriptable2;
                continue;
              }
              catch (Exception ex)
              {
                exception88 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_386;
              }
label_387:
              try
              {
                int index2 = index1 + 1;
                stack1[index2] = (object) new int[length];
                index1 = index2 + 1;
                stack1[index1] = (object) new object[length];
                sDbl1[index1] = 0.0;
                continue;
              }
              catch (Exception ex)
              {
                exception89 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_389;
              }
label_390:
              try
              {
                object objA2 = stack1[index1];
                if (object.ReferenceEquals(objA2, (object) doubleMark))
                  objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
                index1 += -1;
                int index2 = ByteCodeHelper.d2i(sDbl1[index1]);
                ((object[]) stack1[index1])[index2] = objA2;
                sDbl1[index1] = (double) (index2 + 1);
                continue;
              }
              catch (Exception ex)
              {
                exception90 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_394;
              }
label_395:
              try
              {
                object obj = stack1[index1];
                index1 += -1;
                int index2 = ByteCodeHelper.d2i(sDbl1[index1]);
                ((object[]) stack1[index1])[index2] = obj;
                ((int[]) stack1[index1 - 1])[index2] = -1;
                sDbl1[index1] = (double) (index2 + 1);
                continue;
              }
              catch (Exception ex)
              {
                exception91 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_397;
              }
label_398:
              try
              {
                object obj = stack1[index1];
                index1 += -1;
                int index2 = ByteCodeHelper.d2i(sDbl1[index1]);
                ((object[]) stack1[index1])[index2] = obj;
                ((int[]) stack1[index1 - 1])[index2] = 1;
                sDbl1[index1] = (double) (index2 + 1);
                continue;
              }
              catch (Exception ex)
              {
                exception92 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_400;
              }
label_401:
              try
              {
                object[] objArray = (object[]) stack1[index1];
                index1 += -1;
                int[] getterSetters = (int[]) stack1[index1];
                Scriptable scriptable2;
                if (num2 == 67)
                {
                  scriptable2 = ScriptRuntime.newObjectLiteral((object[]) obj1.idata.literalIds[length], objArray, getterSetters, obj0, obj1.scope);
                }
                else
                {
                  int[] skipIndices = (int[]) null;
                  if (num2 == -31)
                    skipIndices = (int[]) obj1.idata.literalIds[length];
                  scriptable2 = ScriptRuntime.newArrayLiteral(objArray, skipIndices, obj0, obj1.scope);
                }
                stack1[index1] = (object) scriptable2;
                continue;
              }
              catch (Exception ex)
              {
                exception93 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_408;
              }
label_409:
              try
              {
                object obj = ScriptRuntime.updateDotQuery(Interpreter.stack_boolean(obj1, index1), obj1.scope);
                if (obj != null)
                {
                  stack1[index1] = obj;
                  obj1.scope = ScriptRuntime.leaveDotQuery(obj1.scope);
                  obj1.pc += 2;
                  continue;
                }
                index1 += -1;
                goto label_474;
              }
              catch (Exception ex)
              {
                exception94 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_413;
              }
label_414:
              try
              {
                if (obj1.debuggerFrame != null)
                {
                  obj1.debuggerFrame.onDebuggerStatement(obj0);
                  continue;
                }
                continue;
              }
              catch (Exception ex)
              {
                exception95 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_417;
              }
label_418:
              try
              {
                obj1.pcSourceLineStart = obj1.pc;
                if (obj1.debuggerFrame != null)
                {
                  int index2 = Interpreter.getIndex(itsIcode, obj1.pc);
                  obj1.debuggerFrame.onLineChange(obj0, index2);
                }
                obj1.pc += 2;
                continue;
              }
              catch (Exception ex)
              {
                exception96 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_422;
              }
label_423:
              try
              {
                length = 0;
                continue;
              }
              catch (Exception ex)
              {
                exception97 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_425;
              }
label_426:
              try
              {
                length = 1;
                continue;
              }
              catch (Exception ex)
              {
                exception98 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_428;
              }
label_429:
              try
              {
                length = 2;
                continue;
              }
              catch (Exception ex)
              {
                exception99 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_431;
              }
label_432:
              try
              {
                length = 3;
                continue;
              }
              catch (Exception ex)
              {
                exception100 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_434;
              }
label_435:
              try
              {
                length = 4;
                continue;
              }
              catch (Exception ex)
              {
                exception101 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_437;
              }
label_438:
              try
              {
                length = 5;
                continue;
              }
              catch (Exception ex)
              {
                exception102 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_440;
              }
label_441:
              try
              {
                length = (int) byte.MaxValue & (int) (sbyte) itsIcode[obj1.pc];
                ++obj1.pc;
                continue;
              }
              catch (Exception ex)
              {
                exception103 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_443;
              }
label_444:
              try
              {
                length = Interpreter.getIndex(itsIcode, obj1.pc);
                obj1.pc += 2;
                continue;
              }
              catch (Exception ex)
              {
                exception104 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_446;
              }
label_447:
              try
              {
                length = Interpreter.getInt(itsIcode, obj1.pc);
                obj1.pc += 4;
                continue;
              }
              catch (Exception ex)
              {
                exception105 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_449;
              }
label_450:
              try
              {
                str1 = itsStringTable[0];
                continue;
              }
              catch (Exception ex)
              {
                exception106 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_452;
              }
label_453:
              try
              {
                str1 = itsStringTable[1];
                continue;
              }
              catch (Exception ex)
              {
                exception107 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_455;
              }
label_456:
              try
              {
                str1 = itsStringTable[2];
                continue;
              }
              catch (Exception ex)
              {
                exception108 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_458;
              }
label_459:
              try
              {
                str1 = itsStringTable[3];
                continue;
              }
              catch (Exception ex)
              {
                exception109 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_461;
              }
label_462:
              try
              {
                str1 = itsStringTable[(int) byte.MaxValue & (int) (sbyte) itsIcode[obj1.pc]];
                ++obj1.pc;
                continue;
              }
              catch (Exception ex)
              {
                exception110 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_464;
              }
label_465:
              try
              {
                str1 = itsStringTable[Interpreter.getIndex(itsIcode, obj1.pc)];
                obj1.pc += 2;
                continue;
              }
              catch (Exception ex)
              {
                exception111 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_467;
              }
label_468:
              try
              {
                str1 = itsStringTable[Interpreter.getInt(itsIcode, obj1.pc)];
                obj1.pc += 4;
                continue;
              }
              catch (Exception ex)
              {
                exception112 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_470;
              }
label_474:
              try
              {
                if (num1 != 0)
                  Interpreter.addInstructionCount(obj0, obj1, 2);
                int num3 = Interpreter.getShort(itsIcode, obj1.pc);
                if (num3 != 0)
                  obj1.pc += num3 - 1;
                else
                  obj1.pc = obj1.idata.longJumps.getExistingInt(obj1.pc);
                if (num1 != 0)
                  obj1.pcPrevBranch = obj1.pc;
              }
              catch (Exception ex)
              {
                exception113 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_482;
              }
            }
            exception3 = exception4;
            goto label_489;
label_26:
            Exception exception114;
            try
            {
              obj1.frozen = true;
              int index2 = Interpreter.getIndex(itsIcode, obj1.pc);
              Interpreter.GeneratorState generatorState2 = generatorState1;
              JavaScriptException.__\u003Cclinit\u003E();
              JavaScriptException javaScriptException = new JavaScriptException(NativeIterator.getStopIterationObject(obj1.scope), obj1.idata.itsSourceFile, index2);
              generatorState2.returnedException = (RuntimeException) javaScriptException;
              goto label_483;
            }
            catch (Exception ex)
            {
              exception114 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            exception3 = exception114;
            goto label_489;
label_29:
            int num4;
            Exception exception115;
            try
            {
              obj1.frozen = true;
              obj1.result = stack1[index1];
              obj1.resultDbl = sDbl1[index1];
              num4 = index1 - 1;
              NativeIterator.StopIteration.__\u003Cclinit\u003E();
              NativeIterator.StopIteration stopIteration = new NativeIterator.StopIteration(!object.ReferenceEquals(obj1.result, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK) ? obj1.result : (object) Double.valueOf(obj1.resultDbl));
              int index2 = Interpreter.getIndex(itsIcode, obj1.pc);
              Interpreter.GeneratorState generatorState2 = generatorState1;
              JavaScriptException.__\u003Cclinit\u003E();
              JavaScriptException javaScriptException = new JavaScriptException((object) stopIteration, obj1.idata.itsSourceFile, index2);
              generatorState2.returnedException = (RuntimeException) javaScriptException;
              goto label_483;
            }
            catch (Exception ex)
            {
              exception115 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            exception3 = exception115;
            goto label_489;
label_32:
            Exception exception116;
            try
            {
              object objA2 = stack1[index1];
              if (object.ReferenceEquals(objA2, (object) doubleMark))
                objA2 = (object) ScriptRuntime.wrapNumber(sDbl1[index1]);
              num4 = index1 - 1;
              int index2 = Interpreter.getIndex(itsIcode, obj1.pc);
              JavaScriptException.__\u003Cclinit\u003E();
              obj2 = (object) new JavaScriptException(objA2, obj1.idata.itsSourceFile, index2);
              goto label_492;
            }
            catch (Exception ex)
            {
              exception116 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            exception3 = exception116;
            goto label_489;
label_37:
            Exception exception117;
            try
            {
              int index2 = length + obj1.localShift;
              obj2 = stack1[index2];
              goto label_492;
            }
            catch (Exception ex)
            {
              exception117 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            exception3 = exception117;
            goto label_489;
label_42:
            exception3 = exception5;
            goto label_489;
label_45:
            exception3 = exception6;
            goto label_489;
label_48:
            exception3 = exception7;
            goto label_489;
label_51:
            exception3 = exception8;
            goto label_489;
label_55:
            exception3 = exception9;
            goto label_489;
label_59:
            exception3 = exception10;
            goto label_489;
label_64:
            exception3 = exception11;
            goto label_489;
label_67:
            exception3 = exception12;
            goto label_489;
label_73:
            exception3 = exception13;
            goto label_489;
label_79:
            exception3 = exception14;
            goto label_489;
label_83:
            exception3 = exception15;
            goto label_489;
label_86:
            exception3 = exception16;
            goto label_489;
label_89:
            exception3 = exception17;
            goto label_489;
label_92:
            exception3 = exception18;
            goto label_489;
label_95:
            exception3 = exception19;
            goto label_489;
label_98:
            exception3 = exception20;
            goto label_489;
label_99:
            Exception exception118;
            try
            {
              obj1.result = stack1[index1];
              obj1.resultDbl = sDbl1[index1];
              num4 = index1 - 1;
              goto label_483;
            }
            catch (Exception ex)
            {
              exception118 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            exception3 = exception118;
            goto label_489;
label_102:
            Exception exception119;
            try
            {
              obj1.result = instance;
              goto label_483;
            }
            catch (Exception ex)
            {
              exception119 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            exception3 = exception119;
            goto label_489;
label_107:
            exception3 = exception21;
            goto label_489;
label_110:
            exception3 = exception22;
            goto label_489;
label_113:
            exception3 = exception23;
            goto label_489;
label_118:
            exception3 = exception24;
            goto label_489;
label_121:
            exception3 = exception25;
            goto label_489;
label_124:
            exception3 = exception26;
            goto label_489;
label_127:
            exception3 = exception27;
            goto label_489;
label_130:
            exception3 = exception28;
            goto label_489;
label_135:
            exception3 = exception29;
            goto label_489;
label_140:
            exception3 = exception30;
            goto label_489;
label_143:
            exception3 = exception31;
            goto label_489;
label_148:
            exception3 = exception32;
            goto label_489;
label_153:
            exception3 = exception33;
            goto label_489;
label_160:
            exception3 = exception34;
            goto label_489;
label_165:
            exception3 = exception35;
            goto label_489;
label_168:
            exception3 = exception36;
            goto label_489;
label_171:
            exception3 = exception37;
            goto label_489;
label_174:
            exception3 = exception38;
            goto label_489;
label_177:
            exception3 = exception39;
            goto label_489;
label_182:
            exception3 = exception40;
            goto label_489;
label_185:
            exception3 = exception41;
            goto label_489;
label_188:
            exception3 = exception42;
            goto label_489;
label_191:
            exception3 = exception43;
            goto label_489;
label_194:
            exception3 = exception44;
            goto label_489;
label_197:
            exception3 = exception45;
            goto label_489;
label_202:
            exception3 = exception46;
            goto label_489;
label_209:
            exception3 = exception47;
            goto label_489;
label_214:
            exception3 = exception48;
            goto label_489;
label_219:
            exception3 = exception49;
            goto label_489;
label_234:
            exception3 = exception50;
            goto label_489;
label_241:
            exception3 = exception51;
            goto label_489;
label_250:
            exception3 = exception52;
            goto label_489;
label_256:
            exception3 = exception53;
            goto label_489;
label_259:
            exception3 = exception54;
            goto label_489;
label_266:
            exception3 = exception55;
            goto label_489;
label_275:
            exception3 = exception56;
            goto label_489;
label_280:
            exception3 = exception57;
            goto label_489;
label_283:
            exception3 = exception58;
            goto label_489;
label_286:
            exception3 = exception59;
            goto label_489;
label_289:
            exception3 = exception60;
            goto label_489;
label_292:
            exception3 = exception61;
            goto label_489;
label_295:
            exception3 = exception62;
            goto label_489;
label_298:
            exception3 = exception63;
            goto label_489;
label_301:
            exception3 = exception64;
            goto label_489;
label_304:
            exception3 = exception65;
            goto label_489;
label_307:
            exception3 = exception66;
            goto label_489;
label_310:
            exception3 = exception67;
            goto label_489;
label_313:
            exception3 = exception68;
            goto label_489;
label_316:
            exception3 = exception69;
            goto label_489;
label_319:
            exception3 = exception70;
            goto label_489;
label_322:
            exception3 = exception71;
            goto label_489;
label_325:
            exception3 = exception72;
            goto label_489;
label_328:
            exception3 = exception73;
            goto label_489;
label_331:
            exception3 = exception74;
            goto label_489;
label_334:
            exception3 = exception75;
            goto label_489;
label_337:
            exception3 = exception76;
            goto label_489;
label_340:
            exception3 = exception77;
            goto label_489;
label_345:
            exception3 = exception78;
            goto label_489;
label_348:
            exception3 = exception79;
            goto label_489;
label_351:
            exception3 = exception80;
            goto label_489;
label_361:
            exception3 = exception81;
            goto label_489;
label_364:
            exception3 = exception82;
            goto label_489;
label_369:
            exception3 = exception83;
            goto label_489;
label_372:
            exception3 = exception84;
            goto label_489;
label_375:
            exception3 = exception85;
            goto label_489;
label_380:
            exception3 = exception86;
            goto label_489;
label_383:
            exception3 = exception87;
            goto label_489;
label_386:
            exception3 = exception88;
            goto label_489;
label_389:
            exception3 = exception89;
            goto label_489;
label_394:
            exception3 = exception90;
            goto label_489;
label_397:
            exception3 = exception91;
            goto label_489;
label_400:
            exception3 = exception92;
            goto label_489;
label_408:
            exception3 = exception93;
            goto label_489;
label_413:
            exception3 = exception94;
            goto label_489;
label_417:
            exception3 = exception95;
            goto label_489;
label_422:
            exception3 = exception96;
            goto label_489;
label_425:
            exception3 = exception97;
            goto label_489;
label_428:
            exception3 = exception98;
            goto label_489;
label_431:
            exception3 = exception99;
            goto label_489;
label_434:
            exception3 = exception100;
            goto label_489;
label_437:
            exception3 = exception101;
            goto label_489;
label_440:
            exception3 = exception102;
            goto label_489;
label_443:
            exception3 = exception103;
            goto label_489;
label_446:
            exception3 = exception104;
            goto label_489;
label_449:
            exception3 = exception105;
            goto label_489;
label_452:
            exception3 = exception106;
            goto label_489;
label_455:
            exception3 = exception107;
            goto label_489;
label_458:
            exception3 = exception108;
            goto label_489;
label_461:
            exception3 = exception109;
            goto label_489;
label_464:
            exception3 = exception110;
            goto label_489;
label_467:
            exception3 = exception111;
            goto label_489;
label_470:
            exception3 = exception112;
            goto label_489;
label_471:
            Exception exception120;
            try
            {
              Interpreter.dumpICode(obj1.idata);
              string str2 = new StringBuilder().append("Unknown icode : ").append(num2).append(" @ pc : ").append(obj1.pc - 1).toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new RuntimeException(str2);
            }
            catch (Exception ex)
            {
              exception120 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            exception3 = exception120;
            goto label_489;
label_482:
            exception3 = exception113;
            goto label_489;
label_483:
            Exception exception121;
            try
            {
              Interpreter.exitFrame(obj0, obj1, (object) null);
              objA1 = obj1.result;
              x = obj1.resultDbl;
              if (obj1.parentFrame != null)
              {
                obj1 = obj1.parentFrame;
                if (obj1.frozen)
                  obj1 = obj1.cloneFrozen();
                Interpreter.setCallResult(obj1, objA1, x);
                objA1 = (object) null;
                continue;
              }
              goto label_531;
            }
            catch (Exception ex)
            {
              exception121 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            exception3 = exception121;
label_489:
            exception1 = exception3;
            if (obj2 == null)
              obj2 = (object) exception1;
            else
              break;
label_492:
            if (obj2 == null)
              Kit.codeBug();
            continuationJump1 = (Interpreter.ContinuationJump) null;
            int num5;
            if (generatorState1 != null && generatorState1.operation == 2 && object.ReferenceEquals(obj2, generatorState1.value))
            {
              num5 = 1;
            }
            else
            {
              switch (obj2)
              {
                case JavaScriptException _:
                  num5 = 2;
                  break;
                case EcmaError _:
                  num5 = 2;
                  break;
                case EvaluatorException _:
                  num5 = 2;
                  break;
                case ContinuationPending _:
                  num5 = 0;
                  break;
                case RuntimeException _:
                  num5 = !obj0.hasFeature(13) ? 1 : 2;
                  break;
                case Error _:
                  num5 = !obj0.hasFeature(13) ? 0 : 2;
                  break;
                case Interpreter.ContinuationJump _:
                  num5 = 1;
                  continuationJump1 = (Interpreter.ContinuationJump) obj2;
                  break;
                default:
                  num5 = !obj0.hasFeature(13) ? 1 : 2;
                  break;
              }
            }
            if (num1 != 0)
            {
              RuntimeException runtimeException;
              Error error;
              try
              {
                try
                {
                  Interpreter.addInstructionCount(obj0, obj1, 100);
                  goto label_515;
                }
                catch (Exception ex)
                {
                  M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
                  if (m0 == null)
                    throw;
                  else
                    runtimeException = (RuntimeException) m0;
                }
              }
              catch (Exception ex)
              {
                M0 m0 = ByteCodeHelper.MapException<Error>(ex, (ByteCodeHelper.MapFlags) 0);
                if (m0 == null)
                {
                  throw;
                }
                else
                {
                  error = (Error) m0;
                  goto label_514;
                }
              }
              obj2 = (object) runtimeException;
              num5 = 1;
              goto label_515;
label_514:
              obj2 = (object) error;
              continuationJump1 = (Interpreter.ContinuationJump) null;
              num5 = 0;
            }
label_515:
            if (obj1.debuggerFrame != null && obj2 is RuntimeException)
            {
              RuntimeException runtimeException = (RuntimeException) obj2;
              Exception exception122;
              try
              {
                obj1.debuggerFrame.onExceptionThrown(obj0, (Exception) runtimeException);
                goto label_520;
              }
              catch (Exception ex)
              {
                exception122 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
              }
              obj2 = (object) exception122;
              continuationJump1 = (Interpreter.ContinuationJump) null;
              num5 = 0;
            }
label_520:
            do
            {
              if (num5 != 0)
              {
                int num3 = num5 != 2 ? 1 : 0;
                length = Interpreter.getExceptionHandler(obj1, num3 != 0);
                if (length >= 0)
                  goto label_8;
              }
              Interpreter.exitFrame(obj0, obj1, obj2);
              obj1 = obj1.parentFrame;
              if (obj1 == null)
                goto label_525;
            }
            while (continuationJump1 == null || !object.ReferenceEquals((object) continuationJump1.branchFrame, (object) obj1));
            length = -1;
            continue;
label_525:
            if (continuationJump1 != null)
            {
              if (continuationJump1.branchFrame != null)
                Kit.codeBug();
              if (continuationJump1.capturedFrame != null)
                length = -1;
              else
                goto label_530;
            }
            else
              goto label_531;
          }
          Throwable.instancehelper_printStackTrace(exception1, java.lang.System.err);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
label_530:
          objA1 = continuationJump1.result;
          x = continuationJump1.resultDbl;
          obj2 = (object) null;
label_531:
          if (obj0.previousInterpreterInvocations != null && obj0.previousInterpreterInvocations.size() != 0)
          {
            obj0.lastInterpreterFrame = obj0.previousInterpreterInvocations.pop();
          }
          else
          {
            obj0.lastInterpreterFrame = (object) null;
            obj0.previousInterpreterInvocations = (ObjArray) null;
          }
          if (obj2 != null)
          {
            if (obj2 is RuntimeException)
              throw Throwable.__\u003Cunmap\u003E((Exception) obj2);
            throw Throwable.__\u003Cunmap\u003E((Exception) obj2);
          }
          return !object.ReferenceEquals(objA1, (object) doubleMark) ? objA1 : (object) ScriptRuntime.wrapNumber(x);
        case Interpreter.GeneratorState _:
          generatorState1 = (Interpreter.GeneratorState) obj2;
          Interpreter.enterFrame(obj0, obj1, ScriptRuntime.__\u003C\u003EemptyArgs, true);
          obj2 = (object) null;
          goto case null;
        default:
          Kit.codeBug();
          goto case null;
      }
    }

    [LineNumberTable(new byte[] {156, 211, 162, 108, 109, 105, 103, 99, 104, 227, 74, 104, 103, 254, 69, 102, 226, 72, 99, 244, 69, 99, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void enterFrame(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] object[] obj2,
      [In] bool obj3)
    {
      int num1 = obj3 ? 1 : 0;
      int num2 = obj1.idata.itsNeedsActivation ? 1 : 0;
      int num3 = obj1.debuggerFrame == null ? 0 : 1;
      if (num2 == 0 && num3 == 0)
        return;
      Scriptable scriptable = obj1.scope;
      if (scriptable == null)
        Kit.codeBug();
      else if (num1 != 0)
      {
        while (scriptable is NativeWith)
        {
          scriptable = scriptable.getParentScope();
          if (scriptable == null || obj1.parentFrame != null && object.ReferenceEquals((object) obj1.parentFrame.scope, (object) scriptable))
          {
            Kit.codeBug();
            break;
          }
        }
      }
      if (num3 != 0)
        obj1.debuggerFrame.onEnter(obj0, scriptable, obj1.thisObj, obj2);
      if (num2 == 0)
        return;
      ScriptRuntime.enterActivationFunction(obj0, scriptable);
    }

    [LineNumberTable(new byte[] {157, 3, 67, 199, 136, 168, 140, 107, 99, 172, 108, 173, 173, 115, 137, 98, 133, 168, 130, 245, 69, 207, 111, 105, 175, 98, 131, 105, 104, 111, 105, 196, 171, 102, 132, 233, 51, 232, 80, 195, 100, 102, 240, 71, 110, 180, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Interpreter.CallFrame processThrowable(
      [In] Context obj0,
      [In] object obj1,
      [In] Interpreter.CallFrame obj2,
      [In] int obj3,
      [In] bool obj4)
    {
      int num1 = obj4 ? 1 : 0;
      if (obj3 >= 0)
      {
        if (obj2.frozen)
          obj2 = obj2.cloneFrozen();
        int[] itsExceptionTable = obj2.idata.itsExceptionTable;
        obj2.pc = itsExceptionTable[obj3 + 2];
        if (num1 != 0)
          obj2.pcPrevBranch = obj2.pc;
        obj2.savedStackTop = obj2.emptyStackTop;
        int index1 = obj2.localShift + itsExceptionTable[obj3 + 5];
        int index2 = obj2.localShift + itsExceptionTable[obj3 + 4];
        obj2.scope = (Scriptable) obj2.stack[index1];
        obj2.stack[index2] = obj1;
      }
      else
      {
        Interpreter.ContinuationJump continuationJump = (Interpreter.ContinuationJump) obj1;
        if (!object.ReferenceEquals((object) continuationJump.branchFrame, (object) obj2))
          Kit.codeBug();
        if (continuationJump.capturedFrame == null)
          Kit.codeBug();
        int num2 = continuationJump.capturedFrame.frameIndex + 1;
        if (continuationJump.branchFrame != null)
          num2 -= continuationJump.branchFrame.frameIndex;
        int index1 = 0;
        Interpreter.CallFrame[] callFrameArray = (Interpreter.CallFrame[]) null;
        Interpreter.CallFrame callFrame1 = continuationJump.capturedFrame;
        for (int index2 = 0; index2 != num2; ++index2)
        {
          if (!callFrame1.frozen)
            Kit.codeBug();
          if (callFrame1.useActivation)
          {
            if (callFrameArray == null)
              callFrameArray = new Interpreter.CallFrame[num2 - index2];
            callFrameArray[index1] = callFrame1;
            ++index1;
          }
          callFrame1 = callFrame1.parentFrame;
        }
        while (index1 != 0)
        {
          index1 += -1;
          Interpreter.CallFrame callFrame2 = callFrameArray[index1];
          Interpreter.enterFrame(obj0, callFrame2, ScriptRuntime.__\u003C\u003EemptyArgs, true);
        }
        obj2 = continuationJump.capturedFrame.cloneFrozen();
        Interpreter.setCallResult(obj2, continuationJump.result, continuationJump.resultDbl);
      }
      obj2.throwable = (object) null;
      return obj2;
    }

    [LineNumberTable(new byte[] {160, 219, 103, 103, 167, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Interpreter.CallFrame captureFrameForGenerator(
      [In] Interpreter.CallFrame obj0)
    {
      obj0.frozen = true;
      Interpreter.CallFrame callFrame = obj0.cloneFrozen();
      obj0.frozen = false;
      callFrame.parentFrame = (Interpreter.CallFrame) null;
      callFrame.frameIndex = 0;
      return callFrame;
    }

    [LineNumberTable(new byte[] {156, 236, 99, 137, 176, 103, 110, 111, 103, 110, 102, 159, 1, 102, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object freezeGenerator(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] int obj2,
      [In] Interpreter.GeneratorState obj3,
      [In] bool obj4)
    {
      int num = obj4 ? 1 : 0;
      if (obj3.operation == 2)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.yield.closing"));
      obj1.frozen = true;
      obj1.result = obj1.stack[obj2];
      obj1.resultDbl = obj1.sDbl[obj2];
      obj1.savedStackTop = obj2;
      --obj1.pc;
      ScriptRuntime.exitActivationFunction(obj0);
      object result = object.ReferenceEquals(obj1.result, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK) ? (object) ScriptRuntime.wrapNumber(obj1.resultDbl) : (object) (Number) obj1.result;
      return num != 0 ? (object) new ES6Generator.YieldStarResult(result) : result;
    }

    [LineNumberTable(new byte[] {170, 46, 103, 119, 110, 169, 221, 105, 135, 104, 107, 106, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object thawGenerator(
      [In] Interpreter.CallFrame obj0,
      [In] int obj1,
      [In] Interpreter.GeneratorState obj2,
      [In] int obj3)
    {
      obj0.frozen = false;
      int index = Interpreter.getIndex(obj0.idata.itsICode, obj0.pc);
      obj0.pc += 2;
      if (obj2.operation == 1)
      {
        JavaScriptException.__\u003Cclinit\u003E();
        return (object) new JavaScriptException(obj2.value, obj0.idata.itsSourceFile, index);
      }
      if (obj2.operation == 2)
        return obj2.value;
      if (obj2.operation != 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      if (obj3 == 73 || obj3 == -66)
        obj0.stack[obj1] = obj2.value;
      return Scriptable.NOT_FOUND;
    }

    [LineNumberTable(new byte[] {168, 59, 102, 103, 229, 71, 109, 103, 109, 112, 105, 197, 155, 105, 133, 105, 133, 102, 133, 102, 133, 171, 155, 105, 130, 105, 130, 105, 130, 105, 130, 171, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doCompare(
      [In] Interpreter.CallFrame obj0,
      [In] int obj1,
      [In] object[] obj2,
      [In] double[] obj3,
      [In] int obj4)
    {
      obj4 += -1;
      object obj5 = obj2[obj4 + 1];
      object obj6 = obj2[obj4];
      double number;
      double num1;
      int num2;
      if (object.ReferenceEquals(obj5, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
      {
        number = obj3[obj4 + 1];
        num1 = Interpreter.stack_double(obj0, obj4);
      }
      else if (object.ReferenceEquals(obj6, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
      {
        number = ScriptRuntime.toNumber(obj5);
        num1 = obj3[obj4];
      }
      else
      {
        switch (obj1)
        {
          case 14:
            num2 = ScriptRuntime.cmp_LT(obj6, obj5) ? 1 : 0;
            goto label_16;
          case 15:
            num2 = ScriptRuntime.cmp_LE(obj6, obj5) ? 1 : 0;
            goto label_16;
          case 16:
            num2 = ScriptRuntime.cmp_LT(obj5, obj6) ? 1 : 0;
            goto label_16;
          case 17:
            num2 = ScriptRuntime.cmp_LE(obj5, obj6) ? 1 : 0;
            goto label_16;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        }
      }
      switch (obj1)
      {
        case 14:
          num2 = num1 < number ? 1 : 0;
          break;
        case 15:
          num2 = num1 <= number ? 1 : 0;
          break;
        case 16:
          num2 = num1 > number ? 1 : 0;
          break;
        case 17:
          num2 = num1 >= number ? 1 : 0;
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
label_16:
      obj2[obj4] = (object) ScriptRuntime.wrapBoolean(num2 != 0);
      return obj4;
    }

    [LineNumberTable(new byte[] {168, 42, 101, 119, 102, 101, 151, 101, 139, 137, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doInOrInstanceof(
      [In] Context obj0,
      [In] int obj1,
      [In] object[] obj2,
      [In] double[] obj3,
      [In] int obj4)
    {
      object obj5 = obj2[obj4];
      if (object.ReferenceEquals(obj5, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        obj5 = (object) ScriptRuntime.wrapNumber(obj3[obj4]);
      obj4 += -1;
      object obj6 = obj2[obj4];
      if (object.ReferenceEquals(obj6, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        obj6 = (object) ScriptRuntime.wrapNumber(obj3[obj4]);
      int num = obj1 != 52 ? (ScriptRuntime.instanceOf(obj6, obj5, obj0) ? 1 : 0) : (ScriptRuntime.@in(obj6, obj5, obj0) ? 1 : 0);
      obj2[obj4] = (object) ScriptRuntime.wrapBoolean(num != 0);
      return obj4;
    }

    [LineNumberTable(new byte[] {169, 138, 102, 100, 109, 109, 139, 140, 109, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool doEquals([In] object[] obj0, [In] double[] obj1, [In] int obj2)
    {
      object obj3 = obj0[obj2 + 1];
      object obj4 = obj0[obj2];
      return object.ReferenceEquals(obj3, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK) ? (object.ReferenceEquals(obj4, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK) ? obj1[obj2] == obj1[obj2 + 1] : ScriptRuntime.eqNumber(obj1[obj2 + 1], obj4)) : (object.ReferenceEquals(obj4, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK) ? ScriptRuntime.eqNumber(obj1[obj2], obj3) : ScriptRuntime.eq(obj4, obj3));
    }

    [LineNumberTable(new byte[] {169, 154, 102, 100, 134, 105, 102, 105, 103, 104, 145, 130, 105, 101, 104, 144, 162, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool doShallowEquals([In] object[] obj0, [In] double[] obj1, [In] int obj2)
    {
      object obj3 = obj0[obj2 + 1];
      object obj4 = obj0[obj2];
      UniqueTag doubleMark = UniqueTag.__\u003C\u003EDOUBLE_MARK;
      double num1;
      double num2;
      if (object.ReferenceEquals(obj3, (object) doubleMark))
      {
        num1 = obj1[obj2 + 1];
        if (object.ReferenceEquals(obj4, (object) doubleMark))
        {
          num2 = obj1[obj2];
        }
        else
        {
          if (!(obj4 is Number))
            return false;
          num2 = ((Number) obj4).doubleValue();
        }
      }
      else
      {
        if (!object.ReferenceEquals(obj4, (object) doubleMark))
          return ScriptRuntime.shallowEq(obj4, obj3);
        num2 = obj1[obj2];
        if (!(obj3 is Number))
          return false;
        num1 = ((Number) obj3).doubleValue();
      }
      return num2 == num1;
    }

    [LineNumberTable(new byte[] {171, 40, 105, 109, 98, 109, 98, 109, 105, 117, 112, 98, 104, 110, 117, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool stack_boolean([In] Interpreter.CallFrame obj0, [In] int obj1)
    {
      object obj = obj0.stack[obj1];
      if (object.ReferenceEquals(obj, (object) Boolean.TRUE))
        return true;
      if (object.ReferenceEquals(obj, (object) Boolean.FALSE))
        return false;
      if (object.ReferenceEquals(obj, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
      {
        double num = obj0.sDbl[obj1];
        return !Double.isNaN(num) && num != 0.0;
      }
      if (obj == null || object.ReferenceEquals(obj, Undefined.__\u003C\u003Einstance))
        return false;
      switch (obj)
      {
        case Number _:
          double num1 = ((Number) obj).doubleValue();
          return !Double.isNaN(num1) && num1 != 0.0;
        case Boolean _:
          return ((Boolean) obj).booleanValue();
        default:
          return ScriptRuntime.toBoolean(obj);
      }
    }

    [LineNumberTable(new byte[] {171, 164, 124, 110, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void addInstructionCount([In] Context obj0, [In] Interpreter.CallFrame obj1, [In] int obj2)
    {
      obj0.instructionCount += obj1.pc - obj1.pcPrevBranch + obj2;
      if (obj0.instructionCount <= obj0.instructionThreshold)
        return;
      obj0.observeInstructionCount(obj0.instructionCount);
      obj0.instructionCount = 0;
    }

    [LineNumberTable(new byte[] {171, 24, 105, 109, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int stack_int32([In] Interpreter.CallFrame obj0, [In] int obj1)
    {
      object obj = obj0.stack[obj1];
      return object.ReferenceEquals(obj, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK) ? ScriptRuntime.toInt32(obj0.sDbl[obj1]) : ScriptRuntime.toInt32(obj);
    }

    [LineNumberTable(new byte[] {168, 117, 107, 105, 111, 159, 24, 100, 130, 100, 130, 100, 130, 103, 130, 167, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doBitOp(
      [In] Interpreter.CallFrame obj0,
      [In] int obj1,
      [In] object[] obj2,
      [In] double[] obj3,
      [In] int obj4)
    {
      int num1 = Interpreter.stack_int32(obj0, obj4 - 1);
      int num2 = Interpreter.stack_int32(obj0, obj4);
      object[] objArray = obj2;
      obj4 += -1;
      int index = obj4;
      UniqueTag doubleMark = UniqueTag.__\u003C\u003EDOUBLE_MARK;
      objArray[index] = (object) doubleMark;
      switch (obj1)
      {
        case 9:
          num1 |= num2;
          break;
        case 10:
          num1 ^= num2;
          break;
        case 11:
          num1 &= num2;
          break;
        case 18:
          num1 <<= num2;
          break;
        case 19:
          num1 >>= num2;
          break;
      }
      obj3[obj4] = (double) num1;
      return obj4;
    }

    [LineNumberTable(new byte[] {171, 32, 105, 109, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static double stack_double([In] Interpreter.CallFrame obj0, [In] int obj1)
    {
      object obj = obj0.stack[obj1];
      return !object.ReferenceEquals(obj, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK) ? ScriptRuntime.toNumber(obj) : obj0.sDbl[obj1];
    }

    [LineNumberTable(new byte[] {171, 62, 102, 164, 109, 102, 109, 113, 129, 136, 109, 100, 98, 168, 112, 112, 115, 113, 113, 127, 21, 98, 110, 114, 110, 114, 104, 138, 193, 104, 103, 100, 99, 103, 131, 112, 107, 106, 118, 100, 159, 23, 159, 21, 98, 110, 114, 104, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void doAdd([In] object[] obj0, [In] double[] obj1, [In] int obj2, [In] Context obj3)
    {
      object obj4 = obj0[obj2 + 1];
      object obj5 = obj0[obj2];
      double x;
      int num1;
      if (object.ReferenceEquals(obj4, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
      {
        x = obj1[obj2 + 1];
        if (object.ReferenceEquals(obj5, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        {
          double[] numArray1 = obj1;
          int index = obj2;
          double[] numArray2 = numArray1;
          numArray2[index] = numArray2[index] + x;
          return;
        }
        num1 = 1;
      }
      else if (object.ReferenceEquals(obj5, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
      {
        x = obj1[obj2];
        obj5 = obj4;
        num1 = 0;
      }
      else
      {
        if (obj5 is Scriptable || obj4 is Scriptable)
        {
          obj0[obj2] = ScriptRuntime.add(obj5, obj4, obj3);
          return;
        }
        if (CharSequence.IsInstance(obj5) || CharSequence.IsInstance(obj4))
        {
          object obj6 = (object) ScriptRuntime.toCharSequence(obj5).__\u003Cref\u003E;
          object obj7 = (object) ScriptRuntime.toCharSequence(obj4).__\u003Cref\u003E;
          object[] objArray = obj0;
          int index = obj2;
          object obj8 = obj6;
          object obj9 = obj7;
          object obj10 = obj8;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj10;
          CharSequence str1 = charSequence;
          object obj11 = obj9;
          charSequence.__\u003Cref\u003E = (__Null) obj11;
          CharSequence str2 = charSequence;
          ConsString consString = new ConsString(str1, str2);
          objArray[index] = (object) consString;
          return;
        }
        double num2 = !(obj5 is Number) ? ScriptRuntime.toNumber(obj5) : ((Number) obj5).doubleValue();
        double num3 = !(obj4 is Number) ? ScriptRuntime.toNumber(obj4) : ((Number) obj4).doubleValue();
        obj0[obj2] = (object) UniqueTag.__\u003C\u003EDOUBLE_MARK;
        obj1[obj2] = num2 + num3;
        return;
      }
      if (obj5 is Scriptable)
      {
        object val2 = (object) ScriptRuntime.wrapNumber(x);
        if (num1 == 0)
        {
          object obj6 = obj5;
          obj5 = (object) (Number) val2;
          val2 = obj6;
        }
        obj0[obj2] = ScriptRuntime.add(obj5, val2, obj3);
      }
      else if (CharSequence.IsInstance(obj5))
      {
        object obj6 = obj5;
        CharSequence.Cast(obj6);
        object obj7 = obj6;
        object obj8 = (object) ScriptRuntime.toCharSequence((object) Double.valueOf(x)).__\u003Cref\u003E;
        if (num1 != 0)
        {
          object[] objArray = obj0;
          int index = obj2;
          object obj9 = obj7;
          object obj10 = obj8;
          object obj11 = obj9;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj11;
          CharSequence str1 = charSequence;
          object obj12 = obj10;
          charSequence.__\u003Cref\u003E = (__Null) obj12;
          CharSequence str2 = charSequence;
          ConsString consString = new ConsString(str1, str2);
          objArray[index] = (object) consString;
        }
        else
        {
          object[] objArray = obj0;
          int index = obj2;
          object obj9 = obj8;
          object obj10 = obj7;
          object obj11 = obj9;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj11;
          CharSequence str1 = charSequence;
          object obj12 = obj10;
          charSequence.__\u003Cref\u003E = (__Null) obj12;
          CharSequence str2 = charSequence;
          ConsString consString = new ConsString(str1, str2);
          objArray[index] = (object) consString;
        }
      }
      else
      {
        double num2 = !(obj5 is Number) ? ScriptRuntime.toNumber(obj5) : ((Number) obj5).doubleValue();
        obj0[obj2] = (object) UniqueTag.__\u003C\u003EDOUBLE_MARK;
        obj1[obj2] = num2 + x;
      }
    }

    [LineNumberTable(new byte[] {171, 124, 107, 102, 107, 105, 155, 102, 130, 102, 130, 102, 130, 166, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doArithmetic(
      [In] Interpreter.CallFrame obj0,
      [In] int obj1,
      [In] object[] obj2,
      [In] double[] obj3,
      [In] int obj4)
    {
      double num1 = Interpreter.stack_double(obj0, obj4);
      obj4 += -1;
      double num2 = Interpreter.stack_double(obj0, obj4);
      obj2[obj4] = (object) UniqueTag.__\u003C\u003EDOUBLE_MARK;
      switch (obj1)
      {
        case 22:
          num2 -= num1;
          break;
        case 23:
          num2 *= num1;
          break;
        case 24:
          num2 /= num1;
          break;
        case 25:
          num2 %= num1;
          break;
      }
      obj3[obj4] = num2;
      return obj4;
    }

    [LineNumberTable(new byte[] {168, 143, 101, 120, 102, 101, 120, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doDelName(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] int obj2,
      [In] object[] obj3,
      [In] double[] obj4,
      [In] int obj5)
    {
      object obj = obj3[obj5];
      if (object.ReferenceEquals(obj, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        obj = (object) ScriptRuntime.wrapNumber(obj4[obj5]);
      obj5 += -1;
      object objA = obj3[obj5];
      if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        objA = (object) ScriptRuntime.wrapNumber(obj4[obj5]);
      obj3[obj5] = ScriptRuntime.delete(objA, obj, obj0, obj1.scope, obj2 == 0);
      return obj5;
    }

    [LineNumberTable(new byte[] {168, 155, 102, 101, 109, 170, 103, 109, 145, 103, 143, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doGetElem(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] object[] obj2,
      [In] double[] obj3,
      [In] int obj4)
    {
      obj4 += -1;
      object objA = obj2[obj4];
      if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        objA = (object) ScriptRuntime.wrapNumber(obj3[obj4]);
      object obj5 = obj2[obj4 + 1];
      object obj6;
      if (!object.ReferenceEquals(obj5, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
      {
        obj6 = ScriptRuntime.getObjectElem(objA, obj5, obj0, obj1.scope);
      }
      else
      {
        double dblIndex = obj3[obj4 + 1];
        obj6 = ScriptRuntime.getObjectIndex(objA, dblIndex, obj0, obj1.scope);
      }
      obj2[obj4] = obj6;
      return obj4;
    }

    [LineNumberTable(new byte[] {168, 174, 103, 103, 109, 140, 101, 109, 170, 103, 109, 146, 104, 145, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doSetElem(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] object[] obj2,
      [In] double[] obj3,
      [In] int obj4)
    {
      obj4 += -2;
      object objA1 = obj2[obj4 + 2];
      if (object.ReferenceEquals(objA1, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        objA1 = (object) ScriptRuntime.wrapNumber(obj3[obj4 + 2]);
      object objA2 = obj2[obj4];
      if (object.ReferenceEquals(objA2, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        objA2 = (object) ScriptRuntime.wrapNumber(obj3[obj4]);
      object obj5 = obj2[obj4 + 1];
      object obj6;
      if (!object.ReferenceEquals(obj5, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
      {
        obj6 = ScriptRuntime.setObjectElem(objA2, obj5, objA1, obj0, obj1.scope);
      }
      else
      {
        double dblIndex = obj3[obj4 + 1];
        obj6 = ScriptRuntime.setObjectIndex(objA2, dblIndex, objA1, obj0, obj1.scope);
      }
      obj2[obj4] = obj6;
      return obj4;
    }

    [LineNumberTable(new byte[] {168, 197, 101, 120, 102, 101, 120, 154, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doElemIncDec(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] byte[] obj2,
      [In] object[] obj3,
      [In] double[] obj4,
      [In] int obj5)
    {
      object obj = obj3[obj5];
      if (object.ReferenceEquals(obj, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        obj = (object) ScriptRuntime.wrapNumber(obj4[obj5]);
      obj5 += -1;
      object objA = obj3[obj5];
      if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        objA = (object) ScriptRuntime.wrapNumber(obj4[obj5]);
      obj3[obj5] = ScriptRuntime.elemIncrDecr(objA, obj, obj0, obj1.scope, (int) (sbyte) obj2[obj1.pc]);
      ++obj1.pc;
      return obj5;
    }

    [LineNumberTable(new byte[] {168, 212, 106, 114, 176, 131, 135, 101, 109, 106, 143, 148, 130, 201, 109, 107, 143, 255, 10, 69, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doCallSpecial(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] object[] obj2,
      [In] double[] obj3,
      [In] int obj4,
      [In] byte[] obj5,
      [In] int obj6)
    {
      int callType = (int) obj5[obj1.pc];
      int num = obj5[obj1.pc + 1] == (byte) 0 ? 0 : 1;
      int index = Interpreter.getIndex(obj5, obj1.pc + 2);
      if (num != 0)
      {
        obj4 -= obj6;
        object obj = obj2[obj4];
        if (object.ReferenceEquals(obj, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
          obj = (object) ScriptRuntime.wrapNumber(obj3[obj4]);
        object[] argsArray = Interpreter.getArgsArray(obj2, obj3, obj4 + 1, obj6);
        obj2[obj4] = ScriptRuntime.newSpecial(obj0, obj, argsArray, obj1.scope, callType);
      }
      else
      {
        obj4 -= 1 + obj6;
        Scriptable thisObj = (Scriptable) obj2[obj4 + 1];
        Callable fun = (Callable) obj2[obj4];
        object[] argsArray = Interpreter.getArgsArray(obj2, obj3, obj4 + 2, obj6);
        obj2[obj4] = ScriptRuntime.callSpecial(obj0, fun, thisObj, argsArray, obj1.scope, obj1.thisObj, callType, obj1.idata.itsSourceFile, index);
      }
      obj1.pc += 4;
      return obj4;
    }

    [LineNumberTable(new byte[] {170, 171, 109, 166, 139, 104, 179, 103, 99, 137, 135, 141, 99, 137, 135, 135, 255, 1, 70, 226, 60, 98, 143, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void exitFrame([In] Context obj0, [In] Interpreter.CallFrame obj1, [In] object obj2)
    {
      if (obj1.idata.itsNeedsActivation)
        ScriptRuntime.exitActivationFunction(obj0);
      if (obj1.debuggerFrame == null)
        return;
      Exception exception1;
      try
      {
        if (obj2 is Exception)
        {
          obj1.debuggerFrame.onExit(obj0, true, obj2);
          return;
        }
        Interpreter.ContinuationJump continuationJump = (Interpreter.ContinuationJump) obj2;
        object objA = continuationJump != null ? continuationJump.result : obj1.result;
        if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
          objA = (object) ScriptRuntime.wrapNumber(continuationJump != null ? continuationJump.resultDbl : obj1.resultDbl);
        obj1.debuggerFrame.onExit(obj0, false, objA);
        return;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      java.lang.System.err.println("RHINO USAGE WARNING: onExit terminated with exception");
      Throwable.instancehelper_printStackTrace(exception2, java.lang.System.err);
    }

    [LineNumberTable(new byte[] {156, 183, 98, 102, 98, 37, 197, 98, 98, 113, 135, 149, 106, 234, 61, 232, 69, 138, 144, 240, 69, 98, 172, 99, 104, 137, 104, 240, 71, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeContinuation captureContinuation(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      NativeContinuation nativeContinuation = new NativeContinuation();
      ScriptRuntime.setObjectProtoAndParent((ScriptableObject) nativeContinuation, ScriptRuntime.getTopCallScope(obj0));
      Interpreter.CallFrame callFrame1 = obj1;
      Interpreter.CallFrame callFrame2 = obj1;
      for (; callFrame1 != null && !callFrame1.frozen; callFrame1 = callFrame1.parentFrame)
      {
        callFrame1.frozen = true;
        for (int index = callFrame1.savedStackTop + 1; index != callFrame1.stack.Length; ++index)
        {
          callFrame1.stack[index] = (object) null;
          callFrame1.stackAttributes[index] = 0;
        }
        if (callFrame1.savedCallOp == 38)
          callFrame1.stack[callFrame1.savedStackTop] = (object) null;
        else if (callFrame1.savedCallOp != 30)
          Kit.codeBug();
        callFrame2 = callFrame1;
      }
      if (num != 0)
      {
        while (callFrame2.parentFrame != null)
          callFrame2 = callFrame2.parentFrame;
        if (!callFrame2.isContinuationsTopFrame)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Cannot capture continuation from JavaScript code not called directly by executeScriptWithContinuations or callFunctionWithContinuations");
        }
      }
      nativeContinuation.initImplementation((object) obj1);
      return nativeContinuation;
    }

    [LineNumberTable(new byte[] {170, 72, 99, 103, 109, 109, 110, 98, 130, 131, 135, 102, 104, 138, 104, 168, 105, 114, 102, 146, 133, 104, 114, 20, 200, 108, 214})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Interpreter.CallFrame initFrameForApplyOrCall(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] int obj2,
      [In] object[] obj3,
      [In] double[] obj4,
      [In] int obj5,
      [In] int obj6,
      [In] Scriptable obj7,
      [In] IdFunctionObject obj8,
      [In] InterpretedFunction obj9)
    {
      Scriptable scriptable;
      if (obj2 != 0)
      {
        object objA = obj3[obj5 + 2];
        if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
          objA = (object) ScriptRuntime.wrapNumber(obj4[obj5 + 2]);
        scriptable = ScriptRuntime.toObjectOrNull(obj0, objA, obj1.scope);
      }
      else
        scriptable = (Scriptable) null;
      if (scriptable == null)
        scriptable = ScriptRuntime.getTopCallScope(obj0);
      if (obj6 == -55)
      {
        Interpreter.exitFrame(obj0, obj1, (object) null);
        obj1 = obj1.parentFrame;
      }
      else
      {
        obj1.savedStackTop = obj5;
        obj1.savedCallOp = obj6;
      }
      Interpreter.CallFrame callFrame;
      if (BaseFunction.isApply(obj8))
      {
        object[] objArray = obj2 >= 2 ? ScriptRuntime.getApplyArguments(obj0, obj3[obj5 + 3]) : ScriptRuntime.__\u003C\u003EemptyArgs;
        callFrame = Interpreter.initFrame(obj0, obj7, scriptable, objArray, (double[]) null, 0, objArray.Length, obj9, obj1);
      }
      else
      {
        for (int index = 1; index < obj2; ++index)
        {
          obj3[obj5 + 1 + index] = obj3[obj5 + 2 + index];
          obj4[obj5 + 1 + index] = obj4[obj5 + 2 + index];
        }
        int num = obj2 >= 2 ? obj2 - 1 : 0;
        callFrame = Interpreter.initFrame(obj0, obj7, scriptable, obj3, obj4, obj5 + 2, num, obj9, obj1);
      }
      return callFrame;
    }

    [LineNumberTable(new byte[] {169, 106, 101, 103, 102, 100, 109, 138, 228, 59, 234, 71, 104, 107, 173, 99, 102, 104, 200, 149, 102, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Interpreter.CallFrame initFrameForNoSuchMethod(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] int obj2,
      [In] object[] obj3,
      [In] double[] obj4,
      [In] int obj5,
      [In] int obj6,
      [In] Scriptable obj7,
      [In] Scriptable obj8,
      [In] ScriptRuntime.NoSuchMethodShim obj9,
      [In] InterpretedFunction obj10)
    {
      int index1 = obj5 + 2;
      object[] elements = new object[obj2];
      int index2 = 0;
      while (index2 < obj2)
      {
        object objA = obj3[index1];
        if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
          objA = (object) ScriptRuntime.wrapNumber(obj4[index1]);
        elements[index2] = objA;
        ++index2;
        ++index1;
      }
      object[] objArray = new object[2]
      {
        (object) obj9.methodName,
        (object) obj0.newArray(obj8, elements)
      };
      Interpreter.CallFrame callFrame1 = obj1;
      if (obj6 == -55)
      {
        callFrame1 = obj1.parentFrame;
        Interpreter.exitFrame(obj0, obj1, (object) null);
      }
      Interpreter.CallFrame callFrame2 = Interpreter.initFrame(obj0, obj8, obj7, objArray, (double[]) null, 0, 2, obj10, callFrame1);
      if (obj6 != -55)
      {
        obj1.savedStackTop = obj5;
        obj1.savedCallOp = obj6;
      }
      return callFrame2;
    }

    [LineNumberTable(394)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getShort([In] byte[] obj0, [In] int obj1) => (int) (sbyte) obj0[obj1] << 8 | (int) obj0[obj1 + 1];

    [LineNumberTable(402)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getInt([In] byte[] obj0, [In] int obj1) => (int) (sbyte) obj0[obj1] << 24 | (int) obj0[obj1 + 1] << 16 | (int) obj0[obj1 + 2] << 8 | (int) obj0[obj1 + 3];

    [LineNumberTable(new byte[] {168, 251, 104, 105, 190, 140, 104, 111, 173, 100, 118, 111, 109, 109, 111, 98, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doSetConstVar(
      [In] Interpreter.CallFrame obj0,
      [In] object[] obj1,
      [In] double[] obj2,
      [In] int obj3,
      [In] object[] obj4,
      [In] double[] obj5,
      [In] int[] obj6,
      [In] int obj7)
    {
      if (!obj0.useActivation)
      {
        if ((obj6[obj7] & 1) == 0)
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.var.redecl", (object) obj0.idata.argNames[obj7]));
        if ((obj6[obj7] & 8) != 0)
        {
          obj4[obj7] = obj1[obj3];
          int[] numArray1 = obj6;
          int index = obj7;
          int[] numArray2 = numArray1;
          numArray2[index] = numArray2[index] & -9;
          obj5[obj7] = obj2[obj3];
        }
      }
      else
      {
        object objA = obj1[obj3];
        if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
          objA = (object) ScriptRuntime.wrapNumber(obj2[obj3]);
        string argName = obj0.idata.argNames[obj7];
        if (!(obj0.scope is ConstProperties))
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        ((ConstProperties) obj0.scope).putConst(argName, obj0.scope, objA);
      }
      return obj3;
    }

    [LineNumberTable(new byte[] {169, 23, 104, 105, 104, 170, 100, 118, 111, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doSetVar(
      [In] Interpreter.CallFrame obj0,
      [In] object[] obj1,
      [In] double[] obj2,
      [In] int obj3,
      [In] object[] obj4,
      [In] double[] obj5,
      [In] int[] obj6,
      [In] int obj7)
    {
      if (!obj0.useActivation)
      {
        if ((obj6[obj7] & 1) == 0)
        {
          obj4[obj7] = obj1[obj3];
          obj5[obj7] = obj2[obj3];
        }
      }
      else
      {
        object objA = obj1[obj3];
        if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
          objA = (object) ScriptRuntime.wrapNumber(obj2[obj3]);
        string argName = obj0.idata.argNames[obj7];
        obj0.scope.put(argName, obj0.scope, objA);
      }
      return obj3;
    }

    [LineNumberTable(new byte[] {169, 41, 101, 104, 104, 138, 111, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doGetVar(
      [In] Interpreter.CallFrame obj0,
      [In] object[] obj1,
      [In] double[] obj2,
      [In] int obj3,
      [In] object[] obj4,
      [In] double[] obj5,
      [In] int obj6)
    {
      ++obj3;
      if (!obj0.useActivation)
      {
        obj1[obj3] = obj4[obj6];
        obj2[obj3] = obj5[obj6];
      }
      else
      {
        string argName = obj0.idata.argNames[obj6];
        obj1[obj3] = obj0.scope.get(argName, obj0.scope);
      }
      return obj3;
    }

    [LineNumberTable(new byte[] {169, 58, 102, 115, 107, 134, 109, 136, 137, 153, 107, 105, 109, 138, 102, 105, 142, 113, 135, 105, 172, 98, 112, 179, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int doVarIncDec(
      [In] Context obj0,
      [In] Interpreter.CallFrame obj1,
      [In] object[] obj2,
      [In] double[] obj3,
      [In] int obj4,
      [In] object[] obj5,
      [In] double[] obj6,
      [In] int[] obj7,
      [In] int obj8)
    {
      ++obj4;
      int incrDecrMask = (int) (sbyte) obj1.idata.itsICode[obj1.pc];
      if (!obj1.useActivation)
      {
        object obj = obj5[obj8];
        double num1 = !object.ReferenceEquals(obj, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK) ? ScriptRuntime.toNumber(obj) : obj6[obj8];
        double num2 = (incrDecrMask & 1) != 0 ? num1 - 1.0 : num1 + 1.0;
        int num3 = (incrDecrMask & 2) == 0 ? 0 : 1;
        if ((obj7[obj8] & 1) == 0)
        {
          if (!object.ReferenceEquals(obj, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
            obj5[obj8] = (object) UniqueTag.__\u003C\u003EDOUBLE_MARK;
          obj6[obj8] = num2;
          obj2[obj4] = (object) UniqueTag.__\u003C\u003EDOUBLE_MARK;
          obj3[obj4] = num3 == 0 ? num2 : num1;
        }
        else if (num3 != 0 && !object.ReferenceEquals(obj, (object) UniqueTag.__\u003C\u003EDOUBLE_MARK))
        {
          obj2[obj4] = obj;
        }
        else
        {
          obj2[obj4] = (object) UniqueTag.__\u003C\u003EDOUBLE_MARK;
          obj3[obj4] = num3 == 0 ? num2 : num1;
        }
      }
      else
      {
        string argName = obj1.idata.argNames[obj8];
        obj2[obj4] = ScriptRuntime.nameIncrDecr(obj1.scope, argName, obj0, incrDecrMask);
      }
      ++obj1.pc;
      return obj4;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void dumpICode([In] InterpreterData obj0)
    {
    }

    [LineNumberTable(new byte[] {170, 209, 106, 110, 113, 202, 104, 176, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void setCallResult([In] Interpreter.CallFrame obj0, [In] object obj1, [In] double obj2)
    {
      if (obj0.savedCallOp == 38)
      {
        obj0.stack[obj0.savedStackTop] = obj1;
        obj0.sDbl[obj0.savedStackTop] = obj2;
      }
      else if (obj0.savedCallOp == 30)
      {
        if (obj1 is Scriptable)
          obj0.stack[obj0.savedStackTop] = obj1;
      }
      else
        Kit.codeBug();
      obj0.savedCallOp = 0;
    }

    [LineNumberTable(new byte[] {159, 40, 66, 108, 131, 226, 70, 169, 104, 108, 104, 104, 109, 130, 108, 130, 196, 102, 162, 108, 140, 99, 100, 228, 42, 235, 88})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getExceptionHandler([In] Interpreter.CallFrame obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      int[] itsExceptionTable = obj0.idata.itsExceptionTable;
      if (itsExceptionTable == null)
        return -1;
      int num2 = obj0.pc - 1;
      int num3 = -1;
      int num4 = 0;
      int num5 = 0;
      for (int index = 0; index != itsExceptionTable.Length; index += 6)
      {
        int num6 = itsExceptionTable[index + 0];
        int num7 = itsExceptionTable[index + 1];
        if (num6 <= num2 && num2 < num7 && (num1 == 0 || itsExceptionTable[index + 3] == 1))
        {
          if (num3 >= 0)
          {
            if (num5 >= num7)
            {
              if (num4 > num6)
                Kit.codeBug();
              if (num5 == num7)
                Kit.codeBug();
            }
            else
              continue;
          }
          num3 = index;
          num4 = num6;
          num5 = num7;
        }
      }
      return num3;
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Interpreter()
    {
    }

    [LineNumberTable(new byte[] {159, 51, 67, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object compile(
      CompilerEnvirons compilerEnv,
      ScriptNode tree,
      string encodedSource,
      bool returnFunction)
    {
      int num = returnFunction ? 1 : 0;
      this.itsData = new CodeGenerator().compile(compilerEnv, tree, encodedSource, num != 0);
      return (object) this.itsData;
    }

    [LineNumberTable(new byte[] {161, 1, 110, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Script createScriptObject(object bytecode, object staticSecurityDomain)
    {
      if (!object.ReferenceEquals(bytecode, (object) this.itsData))
        Kit.codeBug();
      return (Script) InterpretedFunction.createScript(this.itsData, staticSecurityDomain);
    }

    [LineNumberTable(new byte[] {161, 10, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEvalScriptFlag(Script script) => ((InterpretedFunction) script).idata.evalScriptFlag = true;

    [LineNumberTable(new byte[] {161, 16, 110, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Function createFunctionObject(
      Context cx,
      Scriptable scope,
      object bytecode,
      object staticSecurityDomain)
    {
      if (!object.ReferenceEquals(bytecode, (object) this.itsData))
        Kit.codeBug();
      return (Function) InterpretedFunction.createFunction(cx, scope, this.itsData, staticSecurityDomain);
    }

    [LineNumberTable(new byte[] {162, 99, 134, 103, 99, 102, 101, 105, 102, 107, 107, 137, 101, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int[] getLineNumbers([In] InterpreterData obj0)
    {
      UintMap uintMap = new UintMap();
      byte[] itsIcode = obj0.itsICode;
      int length = itsIcode.Length;
      int num1;
      for (int index1 = 0; index1 != length; index1 += num1)
      {
        int num2 = (int) (sbyte) itsIcode[index1];
        num1 = Interpreter.bytecodeSpan(num2);
        if (num2 == -26)
        {
          if (num1 != 3)
            Kit.codeBug();
          int index2 = Interpreter.getIndex(itsIcode, index1 + 1);
          uintMap.put(index2, 0);
        }
      }
      return uintMap.getKeys();
    }

    [LineNumberTable(new byte[] {162, 119, 102, 139, 103, 103, 193, 110, 103, 137, 108, 248, 70, 132, 105, 140, 145, 98, 103, 45, 198, 168, 99, 104, 102, 102, 100, 102, 108, 139, 98, 138, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void captureStackInfo(RhinoException ex)
    {
      Context currentContext = Context.getCurrentContext();
      if (currentContext == null || currentContext.lastInterpreterFrame == null)
      {
        ex.interpreterStackInfo = (object) null;
        ex.interpreterLineData = (int[]) null;
      }
      else
      {
        Interpreter.CallFrame[] callFrameArray;
        if (currentContext.previousInterpreterInvocations == null || currentContext.previousInterpreterInvocations.size() == 0)
        {
          callFrameArray = new Interpreter.CallFrame[1];
        }
        else
        {
          int num = currentContext.previousInterpreterInvocations.size();
          if (object.ReferenceEquals(currentContext.previousInterpreterInvocations.peek(), currentContext.lastInterpreterFrame))
            num += -1;
          callFrameArray = new Interpreter.CallFrame[num + 1];
          currentContext.previousInterpreterInvocations.toArray((object[]) callFrameArray);
        }
        callFrameArray[callFrameArray.Length - 1] = (Interpreter.CallFrame) currentContext.lastInterpreterFrame;
        int length1 = 0;
        for (int index = 0; index != callFrameArray.Length; ++index)
          length1 += 1 + callFrameArray[index].frameIndex;
        int[] numArray = new int[length1];
        int index1 = length1;
        int length2 = callFrameArray.Length;
label_11:
        while (length2 != 0)
        {
          length2 += -1;
          Interpreter.CallFrame parentFrame = callFrameArray[length2];
          while (true)
          {
            if (parentFrame != null)
            {
              index1 += -1;
              numArray[index1] = parentFrame.pcSourceLineStart;
              parentFrame = parentFrame.parentFrame;
            }
            else
              goto label_11;
          }
        }
        if (index1 != 0)
          Kit.codeBug();
        ex.interpreterStackInfo = (object) callFrameArray;
        ex.interpreterLineData = numArray;
      }
    }

    [LineNumberTable(new byte[] {162, 172, 108, 103, 105, 150, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSourcePositionFromStack(Context cx, int[] linep)
    {
      Interpreter.CallFrame interpreterFrame = (Interpreter.CallFrame) cx.lastInterpreterFrame;
      InterpreterData idata = interpreterFrame.idata;
      linep[0] = interpreterFrame.pcSourceLineStart < 0 ? 0 : Interpreter.getIndex(idata.itsICode, interpreterFrame.pcSourceLineStart);
      return idata.itsSourceFile;
    }

    [LineNumberTable(new byte[] {162, 185, 102, 114, 139, 113, 104, 100, 101, 99, 103, 102, 107, 101, 197, 139, 106, 106, 108, 226, 61, 232, 70, 127, 7, 132, 102, 103, 106, 102, 105, 104, 108, 119, 105, 142, 105, 110, 103, 133, 105, 149, 105, 105, 101, 101, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getPatchedStack(RhinoException ex, string nativeStackTrace)
    {
      string str1 = "rhino.Interpreter.interpretLoop";
      StringBuilder stringBuilder1 = new StringBuilder(String.instancehelper_length(nativeStackTrace) + 1000);
      string systemProperty = SecurityUtilities.getSystemProperty("line.separator");
      Interpreter.CallFrame[] interpreterStackInfo = (Interpreter.CallFrame[]) ex.interpreterStackInfo;
      int[] interpreterLineData = ex.interpreterLineData;
      int length1 = interpreterStackInfo.Length;
      int length2 = interpreterLineData.Length;
      int num1 = 0;
label_1:
      while (length1 != 0)
      {
        length1 += -1;
        int num2 = String.instancehelper_indexOf(nativeStackTrace, str1, num1);
        if (num2 >= 0)
        {
          int num3;
          for (num3 = num2 + String.instancehelper_length(str1); num3 != String.instancehelper_length(nativeStackTrace); ++num3)
          {
            switch (String.instancehelper_charAt(nativeStackTrace, num3))
            {
              case '\n':
              case '\r':
                goto label_7;
              default:
                continue;
            }
          }
label_7:
          StringBuilder stringBuilder2 = stringBuilder1;
          string str2 = nativeStackTrace;
          int num4 = num1;
          int num5 = num3;
          int num6 = num4;
          object obj = (object) str2;
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          int num7 = num6;
          int num8 = num5;
          stringBuilder2.append(charSequence2, num7, num8);
          num1 = num3;
          Interpreter.CallFrame parentFrame = interpreterStackInfo[length1];
          while (true)
          {
            if (parentFrame != null)
            {
              if (length2 == 0)
                Kit.codeBug();
              length2 += -1;
              InterpreterData idata = parentFrame.idata;
              stringBuilder1.append(systemProperty);
              stringBuilder1.append("\tat script");
              if (idata.itsName != null && String.instancehelper_length(idata.itsName) != 0)
              {
                stringBuilder1.append('.');
                stringBuilder1.append(idata.itsName);
              }
              stringBuilder1.append('(');
              stringBuilder1.append(idata.itsSourceFile);
              int num9 = interpreterLineData[length2];
              if (num9 >= 0)
              {
                stringBuilder1.append(':');
                stringBuilder1.append(Interpreter.getIndex(idata.itsICode, num9));
              }
              stringBuilder1.append(')');
              parentFrame = parentFrame.parentFrame;
            }
            else
              goto label_1;
          }
        }
        else
          break;
      }
      stringBuilder1.append(String.instancehelper_substring(nativeStackTrace, num1));
      return stringBuilder1.toString();
    }

    [Signature("(Lrhino/RhinoException;)Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(new byte[] {162, 243, 104, 109, 101, 102, 120, 103, 121, 105, 9, 200, 238, 58, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getScriptStack(RhinoException ex)
    {
      ScriptStackElement[][] scriptStackElements = this.getScriptStackElements(ex);
      ArrayList.__\u003Cclinit\u003E();
      ArrayList arrayList = new ArrayList(scriptStackElements.Length);
      string systemProperty = SecurityUtilities.getSystemProperty("line.separator");
      ScriptStackElement[][] scriptStackElementArray1 = scriptStackElements;
      int length1 = scriptStackElementArray1.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        ScriptStackElement[] scriptStackElementArray2 = scriptStackElementArray1[index1];
        StringBuilder sb = new StringBuilder();
        ScriptStackElement[] scriptStackElementArray3 = scriptStackElementArray2;
        int length2 = scriptStackElementArray3.Length;
        for (int index2 = 0; index2 < length2; ++index2)
        {
          scriptStackElementArray3[index2].renderJavaStyle(sb);
          sb.append(systemProperty);
        }
        ((List) arrayList).add((object) sb.toString());
      }
      return (List) arrayList;
    }

    [InnerClass]
    internal class CallFrame : Object, Cloneable.__Interface
    {
      internal Interpreter.CallFrame parentFrame;
      internal int frameIndex;
      internal bool frozen;
      [Modifiers]
      internal InterpretedFunction fnOrScript;
      [Modifiers]
      internal InterpreterData idata;
      internal object[] stack;
      internal int[] stackAttributes;
      internal double[] sDbl;
      [Modifiers]
      internal Interpreter.CallFrame varSource;
      [Modifiers]
      internal int localShift;
      [Modifiers]
      internal int emptyStackTop;
      [Modifiers]
      internal DebugFrame debuggerFrame;
      [Modifiers]
      internal bool useActivation;
      internal bool isContinuationsTopFrame;
      [Modifiers]
      internal Scriptable thisObj;
      internal object result;
      internal double resultDbl;
      internal int pc;
      internal int pcPrevBranch;
      internal int pcSourceLineStart;
      internal Scriptable scope;
      internal int savedStackTop;
      internal int savedCallOp;
      internal object throwable;

      [LineNumberTable(235)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool equalsInTopScope([In] object obj0) => ((Boolean) EqualObjectGraphs.withThreadLocal((EqualObjectGraphs\u0024Func) new Interpreter.CallFrame.__\u003C\u003EAnon1(this, obj0))).booleanValue();

      [LineNumberTable(new byte[] {160, 125, 130, 103, 99, 140, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool isStrictTopFrame()
      {
        Interpreter.CallFrame callFrame = this;
        while (true)
        {
          Interpreter.CallFrame parentFrame = callFrame.parentFrame;
          if (parentFrame != null)
            callFrame = parentFrame;
          else
            break;
        }
        return callFrame.idata.isStrict;
      }

      [LineNumberTable(new byte[] {160, 153, 159, 15, 127, 2, 125, 116, 116, 116, 235, 57})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool fieldsEqual([In] Interpreter.CallFrame obj0, [In] EqualObjectGraphs obj1) => this.frameIndex == obj0.frameIndex && this.pc == obj0.pc && (Interpreter.access\u0024200(this.idata, obj0.idata) && obj1.equalGraphs((object) this.varSource.stack, (object) obj0.varSource.stack)) && (Arrays.equals(this.varSource.sDbl, obj0.varSource.sDbl) && obj1.equalGraphs((object) this.thisObj, (object) obj0.thisObj) && (obj1.equalGraphs((object) this.fnOrScript, (object) obj0.fnOrScript) && obj1.equalGraphs((object) this.scope, (object) obj0.scope)));

      [LineNumberTable(new byte[] {160, 139, 105, 98, 102, 98, 106, 130, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool equals(
        [In] Interpreter.CallFrame obj0,
        [In] Interpreter.CallFrame obj1,
        [In] EqualObjectGraphs obj2)
      {
        for (; !object.ReferenceEquals((object) obj0, (object) obj1); obj1 = obj1.parentFrame)
        {
          if (obj0 == null || obj1 == null || !obj0.fieldsEqual(obj1, obj2))
            return false;
          obj0 = obj0.parentFrame;
        }
        return true;
      }

      [Modifiers]
      [LineNumberTable(209)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024equals\u00240(
        [In] object obj0,
        [In] Context obj1,
        [In] Scriptable obj2,
        [In] Scriptable obj3,
        [In] object[] obj4)
      {
        return (object) Boolean.valueOf(this.equalsInTopScope(obj0));
      }

      [Modifiers]
      [LineNumberTable(235)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Boolean lambda\u0024equalsInTopScope\u00241(
        [In] object obj0,
        [In] EqualObjectGraphs obj1)
      {
        return Boolean.valueOf(Interpreter.CallFrame.equals(this, (Interpreter.CallFrame) obj0, obj1));
      }

      [LineNumberTable(new byte[] {24, 104, 140, 127, 4, 159, 0, 127, 0, 103, 103, 113, 135, 104, 118, 110, 240, 69, 107, 145, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal CallFrame(
        [In] Context obj0,
        [In] Scriptable obj1,
        [In] InterpretedFunction obj2,
        [In] Interpreter.CallFrame obj3)
      {
        Interpreter.CallFrame callFrame = this;
        this.idata = obj2.idata;
        this.debuggerFrame = obj0.debugger == null ? (DebugFrame) null : obj0.debugger.getFrame(obj0, (DebuggableScript) this.idata);
        this.useActivation = this.debuggerFrame != null || this.idata.itsNeedsActivation;
        this.emptyStackTop = this.idata.itsMaxVars + this.idata.itsMaxLocals - 1;
        this.fnOrScript = obj2;
        this.varSource = this;
        this.localShift = this.idata.itsMaxVars;
        this.thisObj = obj1;
        this.parentFrame = obj3;
        this.frameIndex = obj3 != null ? obj3.frameIndex + 1 : 0;
        if (this.frameIndex > obj0.getMaximumInterpreterStackDepth())
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError("Exceeded maximum stack depth"));
        this.result = Undefined.__\u003C\u003Einstance;
        this.pcSourceLineStart = this.idata.firstLinePC;
        this.savedStackTop = this.emptyStackTop;
      }

      [LineNumberTable(new byte[] {51, 168, 100, 142, 99, 163, 112, 145, 107, 110, 159, 6, 223, 6, 103, 223, 9, 112, 122, 102, 113, 110, 105, 243, 61, 230, 72, 140, 119, 198, 108, 108, 140, 108, 102, 110, 10, 198, 108, 101, 227, 69, 112, 100, 145, 114, 46, 168})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void initializeArgs(
        [In] Context obj0,
        [In] Scriptable obj1,
        [In] object[] obj2,
        [In] double[] obj3,
        [In] int obj4,
        [In] int obj5)
      {
        if (this.useActivation)
        {
          if (obj3 != null)
            obj2 = Interpreter.access\u0024000(obj2, obj3, obj4, obj5);
          obj4 = 0;
          obj3 = (double[]) null;
        }
        if (this.idata.itsFunctionType != 0)
        {
          this.scope = this.fnOrScript.getParentScope();
          if (this.useActivation)
            this.scope = this.idata.itsFunctionType != 4 ? ScriptRuntime.createFunctionActivation((NativeFunction) this.fnOrScript, this.scope, obj2, this.idata.isStrict) : ScriptRuntime.createArrowFunctionActivation((NativeFunction) this.fnOrScript, this.scope, obj2, this.idata.isStrict);
        }
        else
        {
          this.scope = obj1;
          ScriptRuntime.initScript((NativeFunction) this.fnOrScript, this.thisObj, obj0, this.scope, this.fnOrScript.idata.evalScriptFlag);
        }
        if (this.idata.itsNestedFunctions != null)
        {
          if (this.idata.itsFunctionType != 0 && !this.idata.itsNeedsActivation)
            Kit.codeBug();
          for (int index = 0; index < this.idata.itsNestedFunctions.Length; ++index)
          {
            if (this.idata.itsNestedFunctions[index].itsFunctionType == 1)
              Interpreter.access\u0024100(obj0, this.scope, this.fnOrScript, index);
          }
        }
        int itsMaxFrameArray = this.idata.itsMaxFrameArray;
        if (itsMaxFrameArray != this.emptyStackTop + this.idata.itsMaxStack + 1)
          Kit.codeBug();
        this.stack = new object[itsMaxFrameArray];
        this.stackAttributes = new int[itsMaxFrameArray];
        this.sDbl = new double[itsMaxFrameArray];
        int paramAndVarCount = this.idata.getParamAndVarCount();
        for (int index = 0; index < paramAndVarCount; ++index)
        {
          if (this.idata.getParamOrVarConst(index))
            this.stackAttributes[index] = 13;
        }
        int num = this.idata.argCount;
        if (num > obj5)
          num = obj5;
        ByteCodeHelper.arraycopy((object) obj2, obj4, (object) this.stack, 0, num);
        if (obj3 != null)
          ByteCodeHelper.arraycopy_primitive_8((Array) obj3, obj4, (Array) this.sDbl, 0, num);
        for (int index = num; index != this.idata.itsMaxVars; ++index)
          this.stack[index] = Undefined.__\u003C\u003Einstance;
      }

      [LineNumberTable(new byte[] {121, 206, 183, 2, 97, 235, 70, 118, 118, 150, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual Interpreter.CallFrame cloneFrozen()
      {
        if (!this.frozen)
          Kit.codeBug();
        Interpreter.CallFrame callFrame;
        try
        {
          callFrame = (Interpreter.CallFrame) this.clone();
          goto label_5;
        }
        catch (CloneNotSupportedException ex)
        {
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
label_5:
        callFrame.stack = (object[]) this.stack.Clone();
        callFrame.stackAttributes = (int[]) this.stackAttributes.Clone();
        callFrame.sDbl = (double[]) this.sDbl.Clone();
        callFrame.frozen = false;
        return callFrame;
      }

      [LineNumberTable(new byte[] {160, 83, 235, 69, 134, 104, 238, 71, 101, 37, 229, 57, 130, 108, 149, 5, 212, 101, 35, 226, 60, 226, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool equals([In] object obj0)
      {
        if (!(obj0 is Interpreter.CallFrame))
          return false;
        Context cx = Context.enter();
        int num;
        // ISSUE: fault handler
        try
        {
          if (ScriptRuntime.hasTopCall(cx))
            num = this.equalsInTopScope(obj0) ? 1 : 0;
          else
            goto label_6;
        }
        __fault
        {
          Context.exit();
        }
        Context.exit();
        return num != 0;
label_6:
        try
        {
          Scriptable topLevelScope = ScriptableObject.getTopLevelScope(this.scope);
          return ((Boolean) ScriptRuntime.doTopCall((Callable) new Interpreter.CallFrame.__\u003C\u003EAnon0(this, obj0), cx, topLevelScope, topLevelScope, ScriptRuntime.__\u003C\u003EemptyArgs, this.isStrictTopFrame())).booleanValue();
        }
        finally
        {
          Context.exit();
        }
      }

      [LineNumberTable(new byte[] {160, 110, 98, 98, 130, 123, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int hashCode()
      {
        int num1 = 0;
        Interpreter.CallFrame callFrame = this;
        int num2 = 0;
        int num3;
        do
        {
          num2 = 31 * (31 * num2 + callFrame.pc) + callFrame.idata.icodeHashCode();
          callFrame = callFrame.parentFrame;
          if (callFrame != null)
          {
            num3 = num1;
            ++num1;
          }
          else
            break;
        }
        while (num3 < 8);
        return num2;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Callable
      {
        private readonly Interpreter.CallFrame arg\u00241;
        private readonly object arg\u00242;

        internal __\u003C\u003EAnon0([In] Interpreter.CallFrame obj0, [In] object obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public object call([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3) => this.arg\u00241.lambda\u0024equals\u00240(this.arg\u00242, obj0, obj1, obj2, obj3);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : EqualObjectGraphs\u0024Func
      {
        private readonly Interpreter.CallFrame arg\u00241;
        private readonly object arg\u00242;

        internal __\u003C\u003EAnon1([In] Interpreter.CallFrame obj0, [In] object obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public object apply([In] object obj0) => (object) this.arg\u00241.lambda\u0024equalsInTopScope\u00241(this.arg\u00242, (EqualObjectGraphs) obj0);
      }
    }

    [InnerClass]
    internal sealed class ContinuationJump : Object
    {
      internal Interpreter.CallFrame capturedFrame;
      internal Interpreter.CallFrame branchFrame;
      internal object result;
      internal double resultDbl;

      [LineNumberTable(new byte[] {160, 174, 104, 113, 203, 204, 103, 194, 110, 99, 164, 98, 103, 163, 103, 103, 244, 69, 108, 103, 169, 103, 117, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ContinuationJump([In] NativeContinuation obj0, [In] Interpreter.CallFrame obj1)
      {
        Interpreter.ContinuationJump continuationJump = this;
        this.capturedFrame = (Interpreter.CallFrame) obj0.getImplementation();
        if (this.capturedFrame == null || obj1 == null)
        {
          this.branchFrame = (Interpreter.CallFrame) null;
        }
        else
        {
          Interpreter.CallFrame callFrame1 = this.capturedFrame;
          Interpreter.CallFrame callFrame2 = obj1;
          int num = callFrame1.frameIndex - callFrame2.frameIndex;
          if (num != 0)
          {
            if (num < 0)
            {
              callFrame1 = obj1;
              callFrame2 = this.capturedFrame;
              num = -num;
            }
            do
            {
              callFrame1 = callFrame1.parentFrame;
              num += -1;
            }
            while (num != 0);
            if (callFrame1.frameIndex != callFrame2.frameIndex)
              Kit.codeBug();
          }
          for (; !object.ReferenceEquals((object) callFrame1, (object) callFrame2) && callFrame1 != null; callFrame2 = callFrame2.parentFrame)
            callFrame1 = callFrame1.parentFrame;
          this.branchFrame = callFrame1;
          if (this.branchFrame == null || this.branchFrame.frozen)
            return;
          Kit.codeBug();
        }
      }
    }

    internal class GeneratorState : Object
    {
      internal int operation;
      internal object value;
      internal RuntimeException returnedException;

      [LineNumberTable(new byte[] {163, 80, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal GeneratorState([In] int obj0, [In] object obj1)
      {
        Interpreter.GeneratorState generatorState = this;
        this.operation = obj0;
        this.value = obj1;
      }
    }
  }
}
