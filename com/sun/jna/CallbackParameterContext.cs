// Decompiled with JetBrains decompiler
// Type: com.sun.jna.CallbackParameterContext
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.lang.reflect;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class CallbackParameterContext : FromNativeContext
  {
    private Method method;
    private object[] args;
    private int index;

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/reflect/Method;[Ljava/lang/Object;I)V")]
    [LineNumberTable(new byte[] {159, 176, 105, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal CallbackParameterContext([In] Class obj0, [In] Method obj1, [In] object[] obj2, [In] int obj3)
      : base(obj0)
    {
      CallbackParameterContext parameterContext = this;
      this.method = obj1;
      this.args = obj2;
      this.index = obj3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Method getMethod() => this.method;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] getArguments() => this.args;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getIndex() => this.index;
  }
}
