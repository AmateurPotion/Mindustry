// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.SoftRoleSlotAssignmentStrategy
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai.formations
{
  public class SoftRoleSlotAssignmentStrategy : BoundedSlotAssignmentStrategy
  {
    protected internal SoftRoleSlotAssignmentStrategy.SlotCostProvider slotCostProvider;
    protected internal float costThreshold;
    private BoolSeq filledSlots;

    [LineNumberTable(new byte[] {159, 187, 104, 103, 136, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SoftRoleSlotAssignmentStrategy(
      SoftRoleSlotAssignmentStrategy.SlotCostProvider slotCostProvider,
      float costThreshold)
    {
      SoftRoleSlotAssignmentStrategy assignmentStrategy = this;
      this.slotCostProvider = slotCostProvider;
      this.costThreshold = costThreshold;
      this.filledSlots = new BoolSeq();
    }

    [LineNumberTable(new byte[] {159, 179, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SoftRoleSlotAssignmentStrategy(
      SoftRoleSlotAssignmentStrategy.SlotCostProvider slotCostProvider)
      : this(slotCostProvider, float.PositiveInfinity)
    {
    }

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;)V")]
    [LineNumberTable(new byte[] {5, 166, 103, 105, 173, 173, 171, 182, 140, 175, 112, 174, 255, 0, 49, 235, 83, 232, 38, 233, 94, 127, 8, 108, 102, 45, 198, 135, 110, 174, 109, 110, 108, 186, 143, 111, 110, 169, 174, 226, 50, 235, 86, 255, 12, 36, 233, 94})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateSlotAssignments(Seq assignments)
    {
      Seq seq = new Seq();
      int size1 = assignments.size;
      for (int index1 = 0; index1 < size1; ++index1)
      {
        SlotAssignment slotAssignment1 = (SlotAssignment) assignments.get(index1);
        SoftRoleSlotAssignmentStrategy.MemberAndSlots memberAndSlots = new SoftRoleSlotAssignmentStrategy.MemberAndSlots(slotAssignment1.member);
        for (int index2 = 0; index2 < size1; ++index2)
        {
          float cost = this.slotCostProvider.getCost(slotAssignment1.member, index2);
          if ((double) cost < (double) this.costThreshold)
          {
            SlotAssignment slotAssignment2 = (SlotAssignment) assignments.get(index2);
            SoftRoleSlotAssignmentStrategy.CostAndSlot costAndSlot = new SoftRoleSlotAssignmentStrategy.CostAndSlot(cost, slotAssignment2.slotNumber);
            memberAndSlots.costAndSlots.add((object) costAndSlot);
            memberAndSlots.assignmentEase += 1f / (1f + cost);
          }
        }
        seq.add((object) memberAndSlots);
      }
      if (size1 > this.filledSlots.size)
        this.filledSlots.ensureCapacity(size1 - this.filledSlots.size);
      this.filledSlots.size = size1;
      for (int index = 0; index < size1; ++index)
        this.filledSlots.set(index, false);
      seq.sort();
      int index3 = 0;
label_15:
      if (index3 < seq.size)
      {
        SoftRoleSlotAssignmentStrategy.MemberAndSlots memberAndSlots = (SoftRoleSlotAssignmentStrategy.MemberAndSlots) seq.get(index3);
        memberAndSlots.costAndSlots.sort();
        int size2 = memberAndSlots.costAndSlots.size;
        for (int index1 = 0; index1 < size2; ++index1)
        {
          int slotNumber = ((SoftRoleSlotAssignmentStrategy.CostAndSlot) memberAndSlots.costAndSlots.get(index1)).slotNumber;
          if (!this.filledSlots.get(slotNumber))
          {
            SlotAssignment slotAssignment = (SlotAssignment) assignments.get(slotNumber);
            slotAssignment.member = memberAndSlots.member;
            slotAssignment.slotNumber = slotNumber;
            this.filledSlots.set(slotNumber, true);
            ++index3;
            goto label_15;
          }
        }
        string message = new StringBuilder().append("SoftRoleSlotAssignmentStrategy cannot find valid slot assignment for member ").append((object) memberAndSlots.member).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
    }

    [Signature("Ljava/lang/Object;Ljava/lang/Comparable<Lmindustry/ai/formations/SoftRoleSlotAssignmentStrategy$CostAndSlot;>;")]
    [Implements(new string[] {"java.lang.Comparable"})]
    internal class CostAndSlot : Object, Comparable
    {
      internal float cost;
      internal int slotNumber;

      [LineNumberTable(140)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compareTo([In] SoftRoleSlotAssignmentStrategy.CostAndSlot obj0) => Float.compare(this.cost, obj0.cost);

      [LineNumberTable(new byte[] {83, 104, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CostAndSlot([In] float obj0, [In] int obj1)
      {
        SoftRoleSlotAssignmentStrategy.CostAndSlot costAndSlot = this;
        this.cost = obj0;
        this.slotNumber = obj1;
      }

      [Modifiers]
      [LineNumberTable(129)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compareTo([In] object obj0) => this.compareTo((SoftRoleSlotAssignmentStrategy.CostAndSlot) obj0);

      int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
        [In] object obj0)
      {
        return this.compareTo(obj0);
      }
    }

    [Signature("Ljava/lang/Object;Ljava/lang/Comparable<Lmindustry/ai/formations/SoftRoleSlotAssignmentStrategy$MemberAndSlots;>;")]
    [Implements(new string[] {"java.lang.Comparable"})]
    internal class MemberAndSlots : Object, Comparable
    {
      internal FormationMember member;
      internal float assignmentEase;
      [Signature("Larc/struct/Seq<Lmindustry/ai/formations/SoftRoleSlotAssignmentStrategy$CostAndSlot;>;")]
      internal Seq costAndSlots;

      [LineNumberTable(new byte[] {99, 104, 103, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MemberAndSlots([In] FormationMember obj0)
      {
        SoftRoleSlotAssignmentStrategy.MemberAndSlots memberAndSlots = this;
        this.member = obj0;
        this.assignmentEase = 0.0f;
        this.costAndSlots = new Seq();
      }

      [LineNumberTable(157)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compareTo([In] SoftRoleSlotAssignmentStrategy.MemberAndSlots obj0) => Float.compare(this.assignmentEase, obj0.assignmentEase);

      [Modifiers]
      [LineNumberTable(144)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compareTo([In] object obj0) => this.compareTo((SoftRoleSlotAssignmentStrategy.MemberAndSlots) obj0);

      int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
        [In] object obj0)
      {
        return this.compareTo(obj0);
      }
    }

    public interface SlotCostProvider
    {
      float getCost(FormationMember fm, int i);
    }
  }
}
