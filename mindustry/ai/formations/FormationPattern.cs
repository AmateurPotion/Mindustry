// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.FormationPattern
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.ai.formations
{
  public abstract class FormationPattern : Object
  {
    public int slots;
    public float spacing;

    public abstract Vec3 calculateSlotLocation(Vec3 v, int i);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool supportsSlots(int slotCount) => true;

    [LineNumberTable(new byte[] {159, 155, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FormationPattern()
    {
      FormationPattern formationPattern = this;
      this.spacing = 20f;
    }
  }
}
