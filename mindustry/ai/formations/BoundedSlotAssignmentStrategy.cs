// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.BoundedSlotAssignmentStrategy
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.ai.formations
{
  public abstract class BoundedSlotAssignmentStrategy : Object, SlotAssignmentStrategy
  {
    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoundedSlotAssignmentStrategy()
    {
    }

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;)V")]
    public abstract void updateSlotAssignments(Seq s);

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;)I")]
    [LineNumberTable(new byte[] {159, 166, 98, 107, 109, 16, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int calculateNumberOfSlots(Seq assignments)
    {
      int num = -1;
      for (int index = 0; index < assignments.size; ++index)
      {
        SlotAssignment slotAssignment = (SlotAssignment) assignments.get(index);
        if (slotAssignment.slotNumber >= num)
          num = slotAssignment.slotNumber;
      }
      return num + 1;
    }

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;I)V")]
    [LineNumberTable(new byte[] {159, 178, 114, 107, 109, 23, 198, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeSlotAssignment(Seq assignments, int index)
    {
      int slotNumber = ((SlotAssignment) assignments.get(index)).slotNumber;
      for (int index1 = 0; index1 < assignments.size; ++index1)
      {
        SlotAssignment slotAssignment = (SlotAssignment) assignments.get(index1);
        if (slotAssignment.slotNumber >= slotNumber)
          --slotAssignment.slotNumber;
      }
      assignments.remove(index);
    }
  }
}
