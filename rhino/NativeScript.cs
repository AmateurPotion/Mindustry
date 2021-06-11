// Decompiled with JetBrains decompiler
// Type: rhino.NativeScript
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal class NativeScript : BaseFunction
  {
    [Modifiers]
    private static object SCRIPT_TAG;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_compile = 3;
    private const int Id_exec = 4;
    private const int MAX_PROTOTYPE_ID = 4;
    private Script script;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeScript([In] Script obj0)
    {
      NativeScript nativeScript = this;
      this.script = obj0;
    }

    [LineNumberTable(new byte[] {94, 107, 103, 99, 102, 164, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Script compile([In] Context obj0, [In] string obj1)
    {
      int[] numArray = new int[1]{ 0 };
      string str = Context.getSourcePositionFromStack(numArray);
      if (str == null)
      {
        str = "<Script object>";
        numArray[0] = 1;
      }
      ErrorReporter errorReporter = DefaultErrorReporter.forEval(obj0.getErrorReporter());
      return obj0.compileString(obj1, (Evaluator) null, errorReporter, str, numArray[0], (object) null);
    }

    [LineNumberTable(new byte[] {88, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeScript realThis([In] Scriptable obj0, [In] IdFunctionObject obj1) => obj0 is NativeScript ? (NativeScript) obj0 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));

    [LineNumberTable(new byte[] {159, 137, 66, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal new static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeScript((Script) null).exportAsJSClass(4, obj0, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Script";

    [LineNumberTable(new byte[] {159, 181, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3) => this.script != null ? this.script.exec(obj0, obj1) : Undefined.__\u003C\u003Einstance;

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Scriptable construct([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2) => throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.script.is.not.constructor"));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getLength() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getArity() => 0;

    [LineNumberTable(new byte[] {12, 109, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal override string decompile([In] int obj0, [In] int obj1) => this.script is NativeFunction ? ((NativeFunction) this.script).decompile(obj0, obj1) : base.decompile(obj0, obj1);

    [LineNumberTable(new byte[] {22, 154, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId([In] int obj0)
    {
      int arity;
      string name;
      switch (obj0)
      {
        case 1:
          arity = 1;
          name = "constructor";
          break;
        case 2:
          arity = 0;
          name = "toString";
          break;
        case 3:
          arity = 1;
          name = "compile";
          break;
        case 4:
          arity = 0;
          name = "exec";
          break;
        default:
          string str = String.valueOf(obj0);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(NativeScript.SCRIPT_TAG, obj0, name, arity);
    }

    [LineNumberTable(new byte[] {48, 109, 142, 103, 157, 144, 102, 104, 103, 103, 194, 106, 104, 99, 134, 201, 245, 69, 106, 106, 111, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      [In] IdFunctionObject obj0,
      [In] Context obj1,
      [In] Scriptable obj2,
      [In] Scriptable obj3,
      [In] object[] obj4)
    {
      if (!obj0.hasTag(NativeScript.SCRIPT_TAG))
        return base.execIdCall(obj0, obj1, obj2, obj3, obj4);
      int num = obj0.methodId();
      switch (num)
      {
        case 1:
          string str1 = obj4.Length != 0 ? ScriptRuntime.toString(obj4[0]) : "";
          NativeScript nativeScript1 = new NativeScript(NativeScript.compile(obj1, str1));
          ScriptRuntime.setObjectProtoAndParent((ScriptableObject) nativeScript1, obj2);
          return (object) nativeScript1;
        case 2:
          Script script = NativeScript.realThis(obj3, obj0).script;
          return script == null ? (object) "" : (object) obj1.decompileScript(script, 0);
        case 3:
          NativeScript nativeScript2 = NativeScript.realThis(obj3, obj0);
          string str2 = ScriptRuntime.toString(obj4, 0);
          nativeScript2.script = NativeScript.compile(obj1, str2);
          return (object) nativeScript2;
        case 4:
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.cant.call.indirect", (object) "exec"));
        default:
          string str3 = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str3);
      }
    }

    [LineNumberTable(new byte[] {114, 98, 130, 159, 16, 102, 98, 130, 102, 98, 130, 102, 98, 130, 102, 162, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId([In] string obj0)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(obj0))
      {
        case 4:
          str = "exec";
          num = 4;
          break;
        case 7:
          str = "compile";
          num = 3;
          break;
        case 8:
          str = "toString";
          num = 2;
          break;
        case 11:
          str = "constructor";
          num = 1;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) obj0) && !String.instancehelper_equals(str, (object) obj0))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeScript()
    {
      BaseFunction.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeScript"))
        return;
      NativeScript.SCRIPT_TAG = (object) "Script";
    }
  }
}
