// Decompiled with JetBrains decompiler
// Type: mindustry.gen.LaunchPayloadc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Teamc", "mindustry.gen.Entityc", "mindustry.gen.Timedc"})]
  public interface LaunchPayloadc : Drawc, Posc, Position, Entityc, Teamc, Timedc, Scaled
  {
    new void draw();

    float cx();

    float cy();

    new void update();

    new void remove();

    [Signature("()Larc/struct/Seq<Lmindustry/type/ItemStack;>;")]
    Seq stacks();

    [Signature("(Larc/struct/Seq<Lmindustry/type/ItemStack;>;)V")]
    void stacks(Seq s);

    Interval @in();

    void @in(Interval i);
  }
}
