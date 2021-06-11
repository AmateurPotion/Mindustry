// Decompiled with JetBrains decompiler
// Type: mindustry.ai.formations.patterns.SquareFormation
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace mindustry.ai.formations.patterns
{
  public class SquareFormation : FormationPattern
  {
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SquareFormation()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 117, 185, 123, 136, 109, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Vec3 calculateSlotLocation(Vec3 @out, int slot)
    {
      int num1 = Mathf.ceil(Mathf.sqrt((float) (this.slots + 1)));
      int num2 = slot;
      int num3 = num1;
      int num4 = num3 != -1 ? num2 % num3 : 0;
      int num5 = slot;
      int num6 = num1;
      int num7 = num6 != -1 ? num5 / num6 : -num5;
      if (num4 == num1 / 2 && num7 == num1 / 2)
      {
        int num8 = num1;
        int num9 = 2;
        if ((num9 != -1 ? num8 % num9 : 0) == 1)
        {
          slot = this.slots;
          int num10 = slot;
          int num11 = num1;
          num4 = num11 != -1 ? num10 % num11 : 0;
          int num12 = slot;
          int num13 = num1;
          num7 = num13 != -1 ? num12 / num13 : -num12;
        }
      }
      return @out.set((float) num4 - ((float) num1 / 2f - 0.5f), (float) num7 - ((float) num1 / 2f - 0.5f), 0.0f).scl(this.spacing);
    }
  }
}
