// Decompiled with JetBrains decompiler
// Type: com.sun.jna.MethodResultContext
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
  public class MethodResultContext : FunctionResultContext
  {
    [Modifiers]
    private Method method;

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/Function;[Ljava/lang/Object;Ljava/lang/reflect/Method;)V")]
    [LineNumberTable(new byte[] {159, 177, 107, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal MethodResultContext([In] Class obj0, [In] Function obj1, [In] object[] obj2, [In] Method obj3)
      : base(obj0, obj1, obj2)
    {
      MethodResultContext methodResultContext = this;
      this.method = obj3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Method getMethod() => this.method;
  }
}
