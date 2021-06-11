// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.defense.Thruster
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.util;
using IKVM.Attributes;
using mindustry.entities.units;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.defense
{
  public class Thruster : Wall
  {
    public TextureRegion topRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 105, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Thruster(string name)
      : base(name)
    {
      Thruster thruster = this;
      this.rotate = true;
      this.quickRotate = false;
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {159, 161, 121, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawRequestRegion(BuildPlan req, Eachable list)
    {
      Draw.rect(this.region, req.drawx(), req.drawy());
      Draw.rect(this.topRegion, req.drawx(), req.drawy(), (float) (req.rotation * 90));
    }

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[2]
    {
      this.region,
      this.topRegion
    };

    [HideFromJava]
    static Thruster() => Wall.__\u003Cclinit\u003E();

    public class ThrusterBuild : Wall.WallBuild
    {
      [Modifiers]
      internal Thruster this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(28)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ThrusterBuild(Thruster _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((Wall) _param1);
      }

      [LineNumberTable(new byte[] {159, 174, 134, 127, 4})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Draw.rect(this.this\u00240.topRegion, this.x, this.y, this.rotdeg());
      }

      [HideFromJava]
      static ThrusterBuild() => Wall.WallBuild.__\u003Cclinit\u003E();
    }
  }
}
