// Decompiled with JetBrains decompiler
// Type: arc.util.Tmp
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class Tmp : Object
  {
    internal static Vec2 __\u003C\u003Ev1;
    internal static Vec2 __\u003C\u003Ev2;
    internal static Vec2 __\u003C\u003Ev3;
    internal static Vec2 __\u003C\u003Ev4;
    internal static Vec2 __\u003C\u003Ev5;
    internal static Vec2 __\u003C\u003Ev6;
    internal static Vec3 __\u003C\u003Ev31;
    internal static Vec3 __\u003C\u003Ev32;
    internal static Vec3 __\u003C\u003Ev33;
    internal static Vec3 __\u003C\u003Ev34;
    internal static Rect __\u003C\u003Er1;
    internal static Rect __\u003C\u003Er2;
    internal static Rect __\u003C\u003Er3;
    internal static Circle __\u003C\u003Ecr1;
    internal static Circle __\u003C\u003Ecr2;
    internal static Circle __\u003C\u003Ecr3;
    internal static Vec2 __\u003C\u003Et1;
    internal static Color __\u003C\u003Ec1;
    internal static Color __\u003C\u003Ec2;
    internal static Color __\u003C\u003Ec3;
    internal static Color __\u003C\u003Ec4;
    internal static Point2 __\u003C\u003Ep1;
    internal static Point2 __\u003C\u003Ep2;
    internal static Point2 __\u003C\u003Ep3;
    internal static TextureRegion __\u003C\u003Etr1;
    internal static TextureRegion __\u003C\u003Etr2;
    internal static Mat __\u003C\u003Em1;
    internal static Mat __\u003C\u003Em2;
    internal static Mat __\u003C\u003Em3;
    [Signature("Larc/math/geom/Bezier<Larc/math/geom/Vec2;>;")]
    internal static Bezier __\u003C\u003Ebz2;
    [Signature("Larc/math/geom/Bezier<Larc/math/geom/Vec3;>;")]
    internal static Bezier __\u003C\u003Ebz3;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tmp()
    {
    }

    [LineNumberTable(new byte[] {159, 139, 109, 106, 106, 106, 106, 106, 138, 106, 106, 106, 138, 106, 106, 138, 106, 106, 138, 138, 106, 106, 106, 138, 106, 106, 138, 106, 138, 106, 106, 138, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Tmp()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.Tmp"))
        return;
      Tmp.__\u003C\u003Ev1 = new Vec2();
      Tmp.__\u003C\u003Ev2 = new Vec2();
      Tmp.__\u003C\u003Ev3 = new Vec2();
      Tmp.__\u003C\u003Ev4 = new Vec2();
      Tmp.__\u003C\u003Ev5 = new Vec2();
      Tmp.__\u003C\u003Ev6 = new Vec2();
      Tmp.__\u003C\u003Ev31 = new Vec3();
      Tmp.__\u003C\u003Ev32 = new Vec3();
      Tmp.__\u003C\u003Ev33 = new Vec3();
      Tmp.__\u003C\u003Ev34 = new Vec3();
      Tmp.__\u003C\u003Er1 = new Rect();
      Tmp.__\u003C\u003Er2 = new Rect();
      Tmp.__\u003C\u003Er3 = new Rect();
      Tmp.__\u003C\u003Ecr1 = new Circle();
      Tmp.__\u003C\u003Ecr2 = new Circle();
      Tmp.__\u003C\u003Ecr3 = new Circle();
      Tmp.__\u003C\u003Et1 = new Vec2();
      Tmp.__\u003C\u003Ec1 = new Color();
      Tmp.__\u003C\u003Ec2 = new Color();
      Tmp.__\u003C\u003Ec3 = new Color();
      Tmp.__\u003C\u003Ec4 = new Color();
      Tmp.__\u003C\u003Ep1 = new Point2();
      Tmp.__\u003C\u003Ep2 = new Point2();
      Tmp.__\u003C\u003Ep3 = new Point2();
      Tmp.__\u003C\u003Etr1 = new TextureRegion();
      Tmp.__\u003C\u003Etr2 = new TextureRegion();
      Tmp.__\u003C\u003Em1 = new Mat();
      Tmp.__\u003C\u003Em2 = new Mat();
      Tmp.__\u003C\u003Em3 = new Mat();
      Tmp.__\u003C\u003Ebz2 = new Bezier();
      Tmp.__\u003C\u003Ebz3 = new Bezier();
    }

    [Modifiers]
    public static Vec2 v1
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev1;
    }

    [Modifiers]
    public static Vec2 v2
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev2;
    }

    [Modifiers]
    public static Vec2 v3
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev3;
    }

    [Modifiers]
    public static Vec2 v4
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev4;
    }

    [Modifiers]
    public static Vec2 v5
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev5;
    }

    [Modifiers]
    public static Vec2 v6
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev6;
    }

    [Modifiers]
    public static Vec3 v31
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev31;
    }

    [Modifiers]
    public static Vec3 v32
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev32;
    }

    [Modifiers]
    public static Vec3 v33
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev33;
    }

    [Modifiers]
    public static Vec3 v34
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ev34;
    }

    [Modifiers]
    public static Rect r1
    {
      [HideFromJava] get => Tmp.__\u003C\u003Er1;
    }

    [Modifiers]
    public static Rect r2
    {
      [HideFromJava] get => Tmp.__\u003C\u003Er2;
    }

    [Modifiers]
    public static Rect r3
    {
      [HideFromJava] get => Tmp.__\u003C\u003Er3;
    }

    [Modifiers]
    public static Circle cr1
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ecr1;
    }

    [Modifiers]
    public static Circle cr2
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ecr2;
    }

    [Modifiers]
    public static Circle cr3
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ecr3;
    }

    [Modifiers]
    public static Vec2 t1
    {
      [HideFromJava] get => Tmp.__\u003C\u003Et1;
    }

    [Modifiers]
    public static Color c1
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ec1;
    }

    [Modifiers]
    public static Color c2
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ec2;
    }

    [Modifiers]
    public static Color c3
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ec3;
    }

    [Modifiers]
    public static Color c4
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ec4;
    }

    [Modifiers]
    public static Point2 p1
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ep1;
    }

    [Modifiers]
    public static Point2 p2
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ep2;
    }

    [Modifiers]
    public static Point2 p3
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ep3;
    }

    [Modifiers]
    public static TextureRegion tr1
    {
      [HideFromJava] get => Tmp.__\u003C\u003Etr1;
    }

    [Modifiers]
    public static TextureRegion tr2
    {
      [HideFromJava] get => Tmp.__\u003C\u003Etr2;
    }

    [Modifiers]
    public static Mat m1
    {
      [HideFromJava] get => Tmp.__\u003C\u003Em1;
    }

    [Modifiers]
    public static Mat m2
    {
      [HideFromJava] get => Tmp.__\u003C\u003Em2;
    }

    [Modifiers]
    public static Mat m3
    {
      [HideFromJava] get => Tmp.__\u003C\u003Em3;
    }

    [Modifiers]
    public static Bezier bz2
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ebz2;
    }

    [Modifiers]
    public static Bezier bz3
    {
      [HideFromJava] get => Tmp.__\u003C\u003Ebz3;
    }
  }
}
