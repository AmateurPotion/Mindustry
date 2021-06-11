// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.FreeSlotAssignmentStrategy
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.ai.formations
{
  public class FreeSlotAssignmentStrategy : Object, SlotAssignmentStrategy
  {
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FreeSlotAssignmentStrategy()
    {
    }

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;)V")]
    [LineNumberTable(new byte[] {159, 161, 107, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateSlotAssignments(Seq assignments)
    {
      for (int index = 0; index < assignments.size; ++index)
        ((SlotAssignment) assignments.get(index)).slotNumber = index;
    }

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;)I")]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int calculateNumberOfSlots(Seq assignments) => assignments.size;

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;I)V")]
    [LineNumberTable(new byte[] {159, 173, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeSlotAssignment(Seq assignments, int index) => assignments.remove(index);
  }
}
