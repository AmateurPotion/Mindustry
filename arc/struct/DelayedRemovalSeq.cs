// Decompiled with JetBrains decompiler
// Type: arc.struct.DelayedRemovalSeq
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Object;>Larc/struct/Seq<TT;>;")]
  public class DelayedRemovalSeq : Seq
  {
    private int iterating;
    private IntSeq remove;
    private int clear;

    [LineNumberTable(new byte[] {159, 188, 233, 36, 236, 93})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayedRemovalSeq(int capacity)
      : base(capacity)
    {
      DelayedRemovalSeq delayedRemovalSeq = this;
      this.remove = new IntSeq(0);
    }

    [LineNumberTable(new byte[] {9, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void begin() => ++this.iterating;

    [LineNumberTable(new byte[] {13, 120, 110, 107, 119, 107, 140, 114, 108, 17, 198, 109, 40, 166, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void end()
    {
      if (this.iterating == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("begin must be called before end.");
      }
      --this.iterating;
      if (this.iterating != 0)
        return;
      if (this.clear > 0 && this.clear == this.size)
      {
        this.remove.clear();
        this.clear();
      }
      else
      {
        int num = 0;
        for (int size = this.remove.size; num < size; ++num)
        {
          int index = this.remove.pop();
          if (index >= this.clear)
            this.remove(index);
        }
        for (int index = this.clear - 1; index >= 0; index += -1)
          this.remove(index);
      }
      this.clear = 0;
    }

    [Signature("(TT;Z)Z")]
    [LineNumberTable(new byte[] {159, 119, 162, 105, 105, 102, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool remove(object value, bool identity)
    {
      int num1 = identity ? 1 : 0;
      if (this.iterating <= 0)
        return base.remove(value, num1 != 0);
      int num2 = this.indexOf(value, num1 != 0);
      if (num2 == -1)
        return false;
      this.removeIntern(num2);
      return true;
    }

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {71, 105, 108, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq clear()
    {
      if (this.iterating <= 0)
        return base.clear();
      this.clear = this.size;
      return (Seq) this;
    }

    [Signature("([TT;)V")]
    [LineNumberTable(new byte[] {0, 233, 32, 236, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayedRemovalSeq(object[] array)
      : base(array)
    {
      DelayedRemovalSeq delayedRemovalSeq = this;
      this.remove = new IntSeq(0);
    }

    [Signature("(I)TT;")]
    [LineNumberTable(new byte[] {55, 105, 103, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object remove(int index)
    {
      if (this.iterating <= 0)
        return base.remove(index);
      this.removeIntern(index);
      return this.get(index);
    }

    [LineNumberTable(new byte[] {32, 106, 114, 109, 101, 100, 109, 225, 59, 230, 72, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void removeIntern([In] int obj0)
    {
      if (obj0 < this.clear)
        return;
      int index = 0;
      for (int size = this.remove.size; index < size; ++index)
      {
        int num = this.remove.get(index);
        if (obj0 == num)
          return;
        if (obj0 < num)
        {
          this.remove.insert(index, obj0);
          return;
        }
      }
      this.remove.add(obj0);
    }

    [LineNumberTable(new byte[] {159, 164, 232, 60, 236, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayedRemovalSeq()
    {
      DelayedRemovalSeq delayedRemovalSeq = this;
      this.remove = new IntSeq(0);
    }

    [LineNumberTable(new byte[] {159, 168, 233, 56, 236, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayedRemovalSeq(Seq array)
      : base(array)
    {
      DelayedRemovalSeq delayedRemovalSeq = this;
      this.remove = new IntSeq(0);
    }

    [LineNumberTable(new byte[] {159, 135, 130, 235, 52, 236, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayedRemovalSeq(bool ordered, int capacity, Class arrayType)
      : base(ordered, capacity, arrayType)
    {
      DelayedRemovalSeq delayedRemovalSeq = this;
      this.remove = new IntSeq(0);
    }

    [LineNumberTable(new byte[] {159, 134, 130, 234, 48, 236, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayedRemovalSeq(bool ordered, int capacity)
      : base(ordered, capacity)
    {
      DelayedRemovalSeq delayedRemovalSeq = this;
      this.remove = new IntSeq(0);
    }

    [Signature("(Z[TT;II)V")]
    [LineNumberTable(new byte[] {159, 133, 130, 237, 44, 236, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayedRemovalSeq(bool ordered, object[] array, int startIndex, int count)
      : base(ordered, array, startIndex, count)
    {
      DelayedRemovalSeq delayedRemovalSeq = this;
      this.remove = new IntSeq(0);
    }

    [LineNumberTable(new byte[] {159, 184, 233, 40, 236, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DelayedRemovalSeq(Class arrayType)
      : base(arrayType)
    {
      DelayedRemovalSeq delayedRemovalSeq = this;
      this.remove = new IntSeq(0);
    }

    [Signature("<T:Ljava/lang/Object;>([TT;)Larc/struct/DelayedRemovalSeq<TT;>;")]
    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static DelayedRemovalSeq with(params object[] array) => new DelayedRemovalSeq(array);

    [LineNumberTable(new byte[] {63, 105, 102, 39, 168, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void removeRange(int start, int end)
    {
      if (this.iterating > 0)
      {
        for (int index = end; index >= start; index += -1)
          this.removeIntern(index);
      }
      else
        base.removeRange(start, end);
    }

    [Signature("(ITT;)V")]
    [LineNumberTable(new byte[] {79, 121, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void set(int index, object value)
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      base.set(index, value);
    }

    [Signature("(ITT;)V")]
    [LineNumberTable(new byte[] {84, 121, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void insert(int index, object value)
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      base.insert(index, value);
    }

    [LineNumberTable(new byte[] {89, 121, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void swap(int first, int second)
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      base.swap(first, second);
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {94, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object pop()
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      return base.pop();
    }

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {99, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq sort()
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      return base.sort();
    }

    [Signature("(Ljava/util/Comparator<-TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {104, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq sort(Comparator comparator)
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      return base.sort(comparator);
    }

    [LineNumberTable(new byte[] {109, 121, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reverse()
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      base.reverse();
    }

    [LineNumberTable(new byte[] {114, 121, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void shuffle()
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      base.shuffle();
    }

    [LineNumberTable(new byte[] {119, 121, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void truncate(int newSize)
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      base.truncate(newSize);
    }

    [Signature("(I)[TT;")]
    [LineNumberTable(new byte[] {124, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object[] setSize(int newSize)
    {
      if (this.iterating > 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("Invalid between begin/end.");
      }
      return base.setSize(newSize);
    }
  }
}
