// Decompiled with JetBrains decompiler
// Type: com.sun.jna.FromNativeContext
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class FromNativeContext : Object
  {
    [Signature("Ljava/lang/Class<*>;")]
    private Class type;

    [Signature("(Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {159, 171, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal FromNativeContext([In] Class obj0)
    {
      FromNativeContext fromNativeContext = this;
      this.type = obj0;
    }

    [Signature("()Ljava/lang/Class<*>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class getTargetType() => this.type;
  }
}
