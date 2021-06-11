// Decompiled with JetBrains decompiler
// Type: rhino.ContinuationPending
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class ContinuationPending : RuntimeException
  {
    private NativeContinuation continuationState;
    private object applicationState;

    [LineNumberTable(new byte[] {159, 167, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal ContinuationPending(NativeContinuation continuationState)
    {
      ContinuationPending continuationPending = this;
      this.continuationState = continuationState;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getContinuation() => (object) this.continuationState;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setContinuation(NativeContinuation continuation) => this.continuationState = continuation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual NativeContinuation getContinuationState() => this.continuationState;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setApplicationState(object applicationState) => this.applicationState = applicationState;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getApplicationState() => this.applicationState;
  }
}
