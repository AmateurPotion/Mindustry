// Decompiled with JetBrains decompiler
// Type: com.sun.jna.CallbackResultContext
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang.reflect;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class CallbackResultContext : ToNativeContext
  {
    private Method method;

    [LineNumberTable(new byte[] {159, 171, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal CallbackResultContext([In] Method obj0)
    {
      CallbackResultContext callbackResultContext = this;
      this.method = obj0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Method getMethod() => this.method;
  }
}
