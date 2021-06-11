// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.FormationMotionModerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.ai.formations
{
  public abstract class FormationMotionModerator : Object
  {
    private Vec3 tempLocation;

    [Signature("(Larc/math/geom/Vec3;Larc/struct/Seq<Lmindustry/ai/formations/SlotAssignment;>;Lmindustry/ai/formations/FormationPattern;)Larc/math/geom/Vec3;")]
    [LineNumberTable(new byte[] {159, 172, 118, 166, 179, 104, 105, 127, 0, 109, 239, 61, 232, 71, 111, 101, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 calculateDriftOffset(
      Vec3 centerOfMass,
      Seq slotAssignments,
      FormationPattern pattern)
    {
      Vec3 vec3_1 = centerOfMass;
      Vec3 vec3_2 = centerOfMass;
      float num1 = 0.0f;
      Vec3 vec3_3 = vec3_2;
      double num2 = (double) num1;
      vec3_3.y = num1;
      vec3_1.x = (float) num2;
      float num3 = 0.0f;
      if (this.tempLocation == null)
        this.tempLocation = new Vec3();
      float size = (float) slotAssignments.size;
      for (int index = 0; (double) index < (double) size; ++index)
      {
        pattern.calculateSlotLocation(this.tempLocation, ((SlotAssignment) slotAssignments.get(index)).slotNumber);
        centerOfMass.add(this.tempLocation);
        num3 += this.tempLocation.z;
      }
      centerOfMass.scl(1f / size);
      float num4 = num3 / size;
      centerOfMass.z = num4;
      return centerOfMass;
    }

    public abstract void updateAnchorPoint(Vec3 v);

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FormationMotionModerator()
    {
    }
  }
}
