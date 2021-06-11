// Decompiled with JetBrains decompiler
// Type: arc.struct.AtomicQueue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using java.util.concurrent.atomic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public class AtomicQueue : Object
  {
    [Modifiers]
    private AtomicInteger writeIndex;
    [Modifiers]
    private AtomicInteger readIndex;
    [Modifiers]
    [Signature("Ljava/util/concurrent/atomic/AtomicReferenceArray<TT;>;")]
    private AtomicReferenceArray queue;

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int next([In] int obj0)
    {
      int num1 = obj0 + 1;
      int num2 = this.queue.length();
      return num2 == -1 ? 0 : num1 % num2;
    }

    [LineNumberTable(new byte[] {159, 180, 232, 60, 107, 203, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AtomicQueue(int capacity)
    {
      AtomicQueue atomicQueue = this;
      this.writeIndex = new AtomicInteger();
      this.readIndex = new AtomicInteger();
      this.queue = new AtomicReferenceArray(capacity);
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(new byte[] {159, 189, 108, 108, 104, 102, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool put(object value)
    {
      int num1 = this.writeIndex.get();
      int num2 = this.readIndex.get();
      int num3 = this.next(num1);
      if (num3 == num2)
        return false;
      this.queue.set(num1, value);
      this.writeIndex.set(num3);
      return true;
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {7, 108, 108, 102, 109, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object poll()
    {
      int num1 = this.readIndex.get();
      int num2 = this.writeIndex.get();
      if (num1 == num2)
        return (object) null;
      object obj = this.queue.get(num1);
      this.readIndex.set(this.next(num1));
      return obj;
    }
  }
}
