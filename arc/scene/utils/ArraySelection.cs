// Decompiled with JetBrains decompiler
// Type: arc.scene.utils.ArraySelection
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace arc.scene.utils
{
  [Signature("<T:Ljava/lang/Object;>Larc/scene/utils/Selection<TT;>;")]
  public class ArraySelection : Selection
  {
    [Signature("Larc/struct/Seq<TT;>;")]
    private Seq array;
    private bool rangeSelect;
    private int rangeStart;

    [Signature("(Larc/struct/Seq<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 159, 232, 61, 199, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArraySelection(Seq array)
    {
      ArraySelection arraySelection = this;
      this.rangeSelect = true;
      this.array = array;
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {159, 165, 115, 105, 110, 127, 23, 103, 134, 105, 100, 99, 98, 131, 119, 104, 57, 136, 104, 103, 134, 102, 129, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void choose(object item)
    {
      if (item == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("item cannot be null.");
      }
      if (this.isDisabled)
        return;
      int num1 = this.array.indexOf(item, false);
      if (this.selected.size > 0 && this.rangeSelect && (this.multiple && Core.input.shift()))
      {
        int rangeStart = this.rangeStart;
        this.snapshot();
        int num2 = this.rangeStart;
        int num3 = num1;
        if (num2 > num3)
        {
          int num4 = num3;
          num3 = num2;
          num2 = num4;
        }
        if (!Core.input.ctrl())
          this.selected.clear();
        for (int index = num2; index <= num3; ++index)
          this.selected.add(this.array.get(index));
        if (this.fireChangeEvent())
        {
          this.rangeStart = rangeStart;
          this.revert();
        }
        this.cleanup();
      }
      else
      {
        this.rangeStart = num1;
        base.choose(item);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getRangeSelect() => this.rangeSelect;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRangeSelect(bool rangeSelect) => this.rangeSelect = rangeSelect;

    [LineNumberTable(new byte[] {13, 103, 104, 102, 129, 116, 103, 112, 98, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void validate()
    {
      Seq array = this.array;
      if (array.size == 0)
      {
        this.clear();
      }
      else
      {
        OrderedSet.OrderedSetIterator orderedSetIterator = this.items().iterator();
        while (((Iterator) orderedSetIterator).hasNext())
        {
          object obj = ((Iterator) orderedSetIterator).next();
          if (!array.contains(obj, false))
            ((Iterator) orderedSetIterator).remove();
        }
        if (!this.required || this.selected.size != 0)
          return;
        this.set(array.first());
      }
    }
  }
}
