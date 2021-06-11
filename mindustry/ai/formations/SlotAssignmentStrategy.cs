// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.SlotAssignmentStrategy
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;

namespace mindustry.ai.formations
{
  public interface SlotAssignmentStrategy
  {
    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;)V")]
    void updateSlotAssignments(Seq s);

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;)I")]
    int calculateNumberOfSlots(Seq s);

    [Signature("(Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;I)V")]
    void removeSlotAssignment(Seq s, int i);
  }
}
