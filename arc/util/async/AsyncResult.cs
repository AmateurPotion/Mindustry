// Decompiled with JetBrains decompiler
// Type: arc.util.async.AsyncResult
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util.concurrent;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.async
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public class AsyncResult : Object
  {
    [Modifiers]
    [Signature("Ljava/util/concurrent/Future<TT;>;")]
    private Future future;

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {159, 172, 127, 7, 97, 98, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get()
    {
      object obj;
      ExecutionException executionException;
      try
      {
        try
        {
          obj = this.future.get();
        }
        catch (InterruptedException ex)
        {
          goto label_4;
        }
      }
      catch (ExecutionException ex)
      {
        executionException = (ExecutionException) ByteCodeHelper.MapException<ExecutionException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_5;
      }
      return obj;
label_4:
      return (object) null;
label_5:
      Exception cause = Throwable.instancehelper_getCause((Exception) executionException);
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(cause);
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDone() => this.future.isDone();

    [Signature("(Ljava/util/concurrent/Future<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 157, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal AsyncResult([In] Future obj0)
    {
      AsyncResult asyncResult = this;
      this.future = obj0;
    }
  }
}
