// Decompiled with JetBrains decompiler
// Type: com.sun.jna.MethodParameterContext
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang.reflect;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class MethodParameterContext : FunctionParameterContext
  {
    private Method method;

    [LineNumberTable(new byte[] {159, 175, 107, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal MethodParameterContext([In] Function obj0, [In] object[] obj1, [In] int obj2, [In] Method obj3)
      : base(obj0, obj1, obj2)
    {
      MethodParameterContext parameterContext = this;
      this.method = obj3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Method getMethod() => this.method;
  }
}
