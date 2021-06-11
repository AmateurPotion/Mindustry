// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.g3d.SunMesh
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.noise;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics.g3d
{
  public class SunMesh : HexMesh
  {
    [LineNumberTable(new byte[] {159, 156, 255, 6, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SunMesh(
      Planet planet,
      int divisions,
      double octaves,
      double persistence,
      double scl,
      double pow,
      double mag,
      float colorScale,
      params Color[] colors)
      : base(planet, (HexMesher) new SunMesh.\u0031(octaves, persistence, scl, pow, mag, colors, colorScale), divisions, Shaders.unlit)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void preRender()
    {
    }

    [InnerClass]
    [EnclosingMethod(null, "<init>", "(Lmindustry.type.Planet;IDDDDDF[Larc.graphics.Color;)V")]
    [SpecialName]
    internal class \u0031 : Object, HexMesher
    {
      internal Simplex sim;
      [Modifiers]
      internal double val\u0024octaves;
      [Modifiers]
      internal double val\u0024persistence;
      [Modifiers]
      internal double val\u0024scl;
      [Modifiers]
      internal double val\u0024pow;
      [Modifiers]
      internal double val\u0024mag;
      [Modifiers]
      internal Color[] val\u0024colors;
      [Modifiers]
      internal float val\u0024colorScale;

      [Signature("()V")]
      [LineNumberTable(new byte[] {159, 156, 127, 41})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031(
        [In] double obj0,
        [In] double obj1,
        [In] double obj2,
        [In] double obj3,
        [In] double obj4,
        [In] Color[] obj5,
        [In] float obj6)
      {
        this.val\u0024octaves = obj0;
        this.val\u0024persistence = obj1;
        this.val\u0024scl = obj2;
        this.val\u0024pow = obj3;
        this.val\u0024mag = obj4;
        this.val\u0024colors = obj5;
        this.val\u0024colorScale = obj6;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        SunMesh.\u0031 obj = this;
        this.sim = new Simplex();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float getHeight([In] Vec3 obj0) => 0.0f;

      [LineNumberTable(new byte[] {159, 166, 127, 42})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Color getColor([In] Vec3 obj0)
      {
        double num = Math.pow(this.sim.octaveNoise3D(this.val\u0024octaves, this.val\u0024persistence, this.val\u0024scl, (double) obj0.x, (double) obj0.y, (double) obj0.z), this.val\u0024pow) * this.val\u0024mag;
        return Tmp.__\u003C\u003Ec1.set(this.val\u0024colors[Mathf.clamp(ByteCodeHelper.d2i(num * (double) this.val\u0024colors.Length), 0, this.val\u0024colors.Length - 1)]).mul(this.val\u0024colorScale);
      }
    }
  }
}
