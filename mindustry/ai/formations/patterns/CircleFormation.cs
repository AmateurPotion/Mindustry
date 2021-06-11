// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.patterns.CircleFormation
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.ai.formations.patterns
{
  public class CircleFormation : FormationPattern
  {
    public float angleOffset;

    [LineNumberTable(new byte[] {159, 149, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CircleFormation()
    {
      CircleFormation circleFormation = this;
      this.angleOffset = 0.0f;
    }

    [LineNumberTable(new byte[] {159, 155, 105, 115, 127, 7, 120, 98, 191, 3, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Vec3 calculateSlotLocation(Vec3 outLocation, int slotNumber)
    {
      if (this.slots > 1)
      {
        float num = 360f * (float) slotNumber / (float) this.slots;
        float len = this.spacing / (float) Math.sin((double) (180f / (float) this.slots * ((float) Math.PI / 180f)));
        outLocation.set(Angles.trnsx(num, len), Angles.trnsy(num, len), num);
      }
      else
        outLocation.set(0.0f, this.spacing * 1.1f, 360f * (float) slotNumber);
      outLocation.z += this.angleOffset;
      return outLocation;
    }
  }
}
