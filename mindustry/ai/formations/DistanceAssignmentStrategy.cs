// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.DistanceAssignmentStrategy
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai.formations
{
  public class DistanceAssignmentStrategy : Object, SlotAssignmentStrategy
  {
    [Modifiers]
    private Vec3 vec;
    [Modifiers]
    private FormationPattern form;

    [LineNumberTable(new byte[] {159, 190, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual float cost([In] FormationMember obj0, [In] int obj1)
    {
      this.form.calculateSlotLocation(this.vec, obj1);
      return Mathf.dst2(obj0.formationPos().x, obj0.formationPos().y, this.vec.x, this.vec.y);
    }

    [LineNumberTable(new byte[] {159, 153, 232, 61, 203, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DistanceAssignmentStrategy(FormationPattern form)
    {
      DistanceAssignmentStrategy assignmentStrategy = this;
      this.vec = new Vec3();
      this.form = form;
    }

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;)V")]
    [LineNumberTable(new byte[] {159, 159, 141, 126, 98, 135, 109, 119, 102, 100, 227, 60, 232, 72, 109, 136, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateSlotAssignments(Seq assignments)
    {
      IntSeq intSeq = IntSeq.range(0, assignments.size);
      Iterator iterator = assignments.iterator();
      while (iterator.hasNext())
      {
        SlotAssignment slotAssignment = (SlotAssignment) iterator.next();
        int index1 = 0;
        float num1 = float.MaxValue;
        for (int index2 = 0; index2 < intSeq.size; ++index2)
        {
          float num2 = this.cost(slotAssignment.member, intSeq.get(index2));
          if ((double) num2 < (double) num1)
          {
            num1 = num2;
            index1 = index2;
          }
        }
        slotAssignment.slotNumber = intSeq.get(index1);
        intSeq.removeIndex(index1);
      }
    }

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;)I")]
    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int calculateNumberOfSlots(Seq assignments) => assignments.size;

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;I)V")]
    [LineNumberTable(new byte[] {159, 186, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeSlotAssignment(Seq assignments, int index) => assignments.remove(index);
  }
}
