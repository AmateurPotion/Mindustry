// Decompiled with JetBrains decompiler
// Type: com.sun.jna.FunctionResultContext
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class FunctionResultContext : FromNativeContext
  {
    private Function function;
    private object[] args;

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/Function;[Ljava/lang/Object;)V")]
    [LineNumberTable(new byte[] {159, 174, 105, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal FunctionResultContext([In] Class obj0, [In] Function obj1, [In] object[] obj2)
      : base(obj0)
    {
      FunctionResultContext functionResultContext = this;
      this.function = obj1;
      this.args = obj2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Function getFunction() => this.function;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getArguments() => this.args;
  }
}
