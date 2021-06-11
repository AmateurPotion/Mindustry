// Decompiled with JetBrains decompiler
// Type: rhino.Evaluator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.util;
using rhino.ast;

namespace rhino
{
  public interface Evaluator
  {
    object compile(CompilerEnvirons ce, ScriptNode sn, string str, bool b);

    Function createFunctionObject(Context c, Scriptable s, object obj1, object obj2);

    Script createScriptObject(object obj1, object obj2);

    string getSourcePositionFromStack(Context c, int[] iarr);

    void captureStackInfo(RhinoException re);

    string getPatchedStack(RhinoException re, string str);

    [Signature("(Lrhino/RhinoException;)Ljava/util/List<Ljava/lang/String;>;")]
    List getScriptStack(RhinoException re);

    void setEvalScriptFlag(Script s);
  }
}
