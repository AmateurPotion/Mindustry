// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.Formation
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
  public class Formation : Object
  {
    [Signature("Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;")]
    public Seq slotAssignments;
    public Vec3 anchor;
    public FormationPattern pattern;
    public SlotAssignmentStrategy slotAssignmentStrategy;
    public FormationMotionModerator motionModerator;
    [Modifiers]
    private Vec2 positionOffset;
    [Modifiers]
    private Mat orientationMatrix;
    [Modifiers]
    private Vec3 driftOffset;

    [LineNumberTable(new byte[] {18, 232, 28, 235, 101, 115, 103, 103, 103, 136, 107, 107, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Formation(
      Vec3 anchor,
      FormationPattern pattern,
      SlotAssignmentStrategy slotAssignmentStrategy,
      FormationMotionModerator motionModerator)
    {
      Formation formation = this;
      this.orientationMatrix = new Mat();
      if (anchor == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("The anchor point cannot be null");
      }
      this.anchor = anchor;
      this.pattern = pattern;
      this.slotAssignmentStrategy = slotAssignmentStrategy;
      this.motionModerator = motionModerator;
      this.slotAssignments = new Seq();
      this.driftOffset = new Vec3();
      Vec2.__\u003Cclinit\u003E();
      this.positionOffset = new Vec2(anchor.x, anchor.y).cpy();
    }

    [LineNumberTable(new byte[] {32, 182, 177, 188, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateSlotAssignments()
    {
      this.pattern.slots = this.slotAssignments.size;
      this.slotAssignmentStrategy.updateSlotAssignments(this.slotAssignments);
      this.pattern.slots = this.slotAssignmentStrategy.calculateNumberOfSlots(this.slotAssignments);
      if (this.motionModerator == null)
        return;
      this.motionModerator.calculateDriftOffset(this.driftOffset, this.slotAssignments, this.pattern);
    }

    [LineNumberTable(new byte[] {122, 112, 63, 1, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int findMemberSlot([In] FormationMember obj0)
    {
      for (int index = 0; index < this.slotAssignments.size; ++index)
      {
        if (object.ReferenceEquals((object) ((SlotAssignment) this.slotAssignments.get(index)).member, (object) obj0))
          return index;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {159, 187, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Formation(Vec3 anchor, FormationPattern pattern)
      : this(anchor, pattern, (SlotAssignmentStrategy) new FreeSlotAssignmentStrategy(), (FormationMotionModerator) null)
    {
    }

    [LineNumberTable(new byte[] {6, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Formation(
      Vec3 anchor,
      FormationPattern pattern,
      SlotAssignmentStrategy slotAssignmentStrategy)
      : this(anchor, pattern, slotAssignmentStrategy, (FormationMotionModerator) null)
    {
    }

    [LineNumberTable(new byte[] {52, 172, 105, 167, 134, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool changePattern(FormationPattern pattern)
    {
      int size = this.slotAssignments.size;
      if (!pattern.supportsSlots(size))
        return false;
      this.pattern = pattern;
      this.updateSlotAssignments();
      return true;
    }

    [Signature("(Ljava/lang/Iterable<+Lmindustry/ai/formations/FormationMember;>;)I")]
    [LineNumberTable(new byte[] {70, 98, 123, 122, 124, 132, 130, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int addMembers(Iterable members)
    {
      int num = 0;
      Iterator iterator = members.iterator();
      while (iterator.hasNext())
      {
        FormationMember member = (FormationMember) iterator.next();
        if (this.pattern.supportsSlots(this.slotAssignments.size + 1))
        {
          this.slotAssignments.add((object) new SlotAssignment(member, this.slotAssignments.size));
          ++num;
        }
      }
      this.updateSlotAssignments();
      return num;
    }

    [LineNumberTable(new byte[] {90, 154, 188, 102, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addMember(FormationMember member)
    {
      if (!this.pattern.supportsSlots(this.slotAssignments.size + 1))
        return false;
      this.slotAssignments.add((object) new SlotAssignment(member, this.slotAssignments.size));
      this.updateSlotAssignments();
      return true;
    }

    [LineNumberTable(new byte[] {108, 168, 164, 178, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeMember(FormationMember member)
    {
      int memberSlot = this.findMemberSlot(member);
      if (memberSlot < 0)
        return;
      this.slotAssignmentStrategy.removeSlotAssignment(this.slotAssignments, memberSlot);
      this.updateSlotAssignments();
    }

    [LineNumberTable(180)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SlotAssignment getSlotAssignmentAt(int index) => (SlotAssignment) this.slotAssignments.get(index);

    [LineNumberTable(185)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSlotAssignmentCount() => this.slotAssignments.size;

    [LineNumberTable(new byte[] {160, 76, 114, 108, 104, 114, 207, 188, 115, 178, 108, 168, 179, 173, 127, 3, 235, 49, 233, 83, 104, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateSlots()
    {
      this.positionOffset.set(this.anchor);
      float z1 = this.anchor.z;
      if (this.motionModerator != null)
      {
        this.positionOffset.sub(this.driftOffset);
        z1 -= this.driftOffset.z;
      }
      this.orientationMatrix.idt().rotate(this.anchor.z);
      for (int index = 0; index < this.slotAssignments.size; ++index)
      {
        SlotAssignment slotAssignment = (SlotAssignment) this.slotAssignments.get(index);
        Vec3 v = slotAssignment.member.formationPos();
        float z2 = v.z;
        this.pattern.calculateSlotLocation(v, slotAssignment.slotNumber);
        v.mul(this.orientationMatrix);
        v.add(this.positionOffset.x, this.positionOffset.y, 0.0f);
        v.z = z2 + z1;
      }
      if (this.motionModerator == null)
        return;
      this.motionModerator.updateAnchorPoint(this.anchor);
    }
  }
}
