// Decompiled with JetBrains decompiler
// Type: rhino.ScriptRuntimeES6
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class ScriptRuntimeES6 : Object
  {
    [LineNumberTable(new byte[] {159, 148, 107, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable requireObjectCoercible(
      Context cx,
      Scriptable val,
      IdFunctionObject idFuncObj)
    {
      return val != null && !Undefined.isUndefined((object) val) ? val : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError2("msg.called.null.or.undefined", idFuncObj.getTag(), (object) idFuncObj.getFunctionName()));
    }

    [LineNumberTable(3)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScriptRuntimeES6()
    {
    }
  }
}
