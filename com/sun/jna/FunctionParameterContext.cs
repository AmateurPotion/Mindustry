// Decompiled with JetBrains decompiler
// Type: com.sun.jna.FunctionParameterContext
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class FunctionParameterContext : ToNativeContext
  {
    private Function function;
    private object[] args;
    private int index;

    [LineNumberTable(new byte[] {159, 175, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal FunctionParameterContext([In] Function obj0, [In] object[] obj1, [In] int obj2)
    {
      FunctionParameterContext parameterContext = this;
      this.function = obj0;
      this.args = obj1;
      this.index = obj2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Function getFunction() => this.function;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getParameters() => this.args;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getParameterIndex() => this.index;
  }
}
