// Decompiled with JetBrains decompiler
// Type: mindustry.maps.planet.TantrosPlanetGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using mindustry.content;
using mindustry.game;
using mindustry.maps.generators;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.planet
{
  public class TantrosPlanetGenerator : PlanetGenerator
  {
    internal Color c1;
    internal Color c2;
    internal Color @out;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 169, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024generate\u00240([In] int obj0, [In] int obj1) => this.floor = Blocks.deepwater;

    [LineNumberTable(new byte[] {159, 152, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TantrosPlanetGenerator()
    {
      TantrosPlanetGenerator tantrosPlanetGenerator = this;
      this.c1 = Color.valueOf("5057a6");
      this.c2 = Color.valueOf("272766");
      this.@out = new Color();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getHeight(Vec3 position) => 0.0f;

    [LineNumberTable(new byte[] {159, 162, 127, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Color getColor(Vec3 position)
    {
      float num = (float) this.noise.octaveNoise3D(2.0, 0.56, 1.70000004768372, (double) position.x, (double) position.y, (double) position.z) / 2f;
      return this.c1.write(this.@out).lerp(this.c2, Mathf.clamp(Mathf.round(num, 0.15f))).a(0.6f);
    }

    [LineNumberTable(new byte[] {159, 168, 209, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void generate()
    {
      this.pass((Intc2) new TantrosPlanetGenerator.__\u003C\u003EAnon0(this));
      Schematics.placeLaunchLoadout(this.width / 2, this.height / 2);
    }

    [HideFromJava]
    static TantrosPlanetGenerator() => PlanetGenerator.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Intc2
    {
      private readonly TantrosPlanetGenerator arg\u00241;

      internal __\u003C\u003EAnon0([In] TantrosPlanetGenerator obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024generate\u00240(obj0, obj1);
    }
  }
}
