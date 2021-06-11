// Decompiled with JetBrains decompiler
// Type: arc.struct.SnapshotSeq
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Object;>Larc/struct/Seq<TT;>;")]
  public class SnapshotSeq : Seq
  {
    [Signature("[TT;")]
    private object[] snapshot;
    [Signature("[TT;")]
    private object[] recycled;
    private int snapshots;

    [LineNumberTable(new byte[] {159, 133, 130, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SnapshotSeq(bool ordered, int capacity, Class arrayType)
      : base(ordered, capacity, arrayType)
    {
    }

    [Signature("()[TT;")]
    [LineNumberTable(new byte[] {18, 102, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] begin()
    {
      this.modified();
      this.snapshot = this.items;
      ++this.snapshots;
      return this.items;
    }

    [LineNumberTable(new byte[] {26, 116, 105, 155, 108, 110, 41, 166, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void end()
    {
      this.snapshots = Math.max(0, this.snapshots - 1);
      if (this.snapshot == null)
        return;
      if (!object.ReferenceEquals((object) this.snapshot, (object) this.items) && this.snapshots == 0)
      {
        this.recycled = this.snapshot;
        int index = 0;
        for (int length = this.recycled.Length; index < length; ++index)
          this.recycled[index] = (object) null;
      }
      this.snapshot = (object[]) null;
    }

    [Signature("(ITT;)V")]
    [LineNumberTable(new byte[] {54, 102, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void insert(int index, object value)
    {
      this.modified();
      base.insert(index, value);
    }

    [Signature("(TT;Z)Z")]
    [LineNumberTable(new byte[] {159, 114, 130, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool remove(object value, bool identity)
    {
      int num = identity ? 1 : 0;
      this.modified();
      return base.remove(value, num != 0);
    }

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {89, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq clear()
    {
      this.modified();
      base.clear();
      return (Seq) this;
    }

    [LineNumberTable(new byte[] {59, 102, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void swap(int first, int second)
    {
      this.modified();
      base.swap(first, second);
    }

    [LineNumberTable(new byte[] {4, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SnapshotSeq(int capacity)
      : base(capacity)
    {
    }

    [Signature("(I)TT;")]
    [LineNumberTable(new byte[] {69, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object remove(int index)
    {
      this.modified();
      return base.remove(index);
    }

    [Signature("([TT;)V")]
    [LineNumberTable(new byte[] {8, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SnapshotSeq(object[] array)
      : base(array)
    {
    }

    [LineNumberTable(new byte[] {38, 156, 119, 121, 108, 137, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void modified()
    {
      if (this.snapshot == null || !object.ReferenceEquals((object) this.snapshot, (object) this.items))
        return;
      if (this.recycled != null && this.recycled.Length >= this.size)
      {
        ByteCodeHelper.arraycopy((object) this.items, 0, (object) this.recycled, 0, this.size);
        this.items = this.recycled;
        this.recycled = (object[]) null;
      }
      else
        this.resize(this.items.Length);
    }

    [LineNumberTable(new byte[] {159, 172, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SnapshotSeq()
    {
    }

    [Signature("(Larc/struct/Seq<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 176, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SnapshotSeq(Seq array)
      : base(array)
    {
    }

    [LineNumberTable(new byte[] {159, 132, 130, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SnapshotSeq(bool ordered, int capacity)
      : base(ordered, capacity)
    {
    }

    [Signature("(Z[TT;II)V")]
    [LineNumberTable(new byte[] {159, 131, 130, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SnapshotSeq(bool ordered, object[] array, int startIndex, int count)
      : base(ordered, array, startIndex, count)
    {
    }

    [LineNumberTable(new byte[] {0, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SnapshotSeq(Class arrayType)
      : base(arrayType)
    {
    }

    [Signature("<T:Ljava/lang/Object;>([TT;)Larc/struct/SnapshotSeq<TT;>;")]
    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SnapshotSeq with(params object[] array) => new SnapshotSeq(array);

    [Signature("(ITT;)V")]
    [LineNumberTable(new byte[] {49, 102, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void set(int index, object value)
    {
      this.modified();
      base.set(index, value);
    }

    [LineNumberTable(new byte[] {74, 102, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void removeRange(int start, int end)
    {
      this.modified();
      base.removeRange(start, end);
    }

    [Signature("(Larc/struct/Seq<+TT;>;Z)Z")]
    [LineNumberTable(new byte[] {159, 110, 98, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool removeAll(Seq array, bool identity)
    {
      int num = identity ? 1 : 0;
      this.modified();
      return base.removeAll(array, num != 0);
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {84, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object pop()
    {
      this.modified();
      return base.pop();
    }

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {95, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq sort()
    {
      this.modified();
      return base.sort();
    }

    [Signature("(Ljava/util/Comparator<-TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {100, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq sort(Comparator comparator)
    {
      this.modified();
      return base.sort(comparator);
    }

    [LineNumberTable(new byte[] {105, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reverse()
    {
      this.modified();
      base.reverse();
    }

    [LineNumberTable(new byte[] {110, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void shuffle()
    {
      this.modified();
      base.shuffle();
    }

    [LineNumberTable(new byte[] {115, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void truncate(int newSize)
    {
      this.modified();
      base.truncate(newSize);
    }

    [Signature("(I)[TT;")]
    [LineNumberTable(new byte[] {120, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object[] setSize(int newSize)
    {
      this.modified();
      return base.setSize(newSize);
    }
  }
}
