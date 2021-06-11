// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.SlotAssignment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.ai.formations
{
  public class SlotAssignment : Object
  {
    public FormationMember member;
    public int slotNumber;

    [LineNumberTable(new byte[] {159, 167, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SlotAssignment(FormationMember member, int slotNumber)
    {
      SlotAssignment slotAssignment = this;
      this.member = member;
      this.slotNumber = slotNumber;
    }

    [LineNumberTable(new byte[] {159, 160, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SlotAssignment(FormationMember member)
      : this(member, 0)
    {
    }
  }
}
