// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.ScorchGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.math;
using arc.util.noise;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class ScorchGenerator : Object
  {
    [Modifiers]
    private static Simplex sim;
    public int size;
    public int seed;
    public int color;
    public double scale;
    public double pow;
    public double octaves;
    public double pers;
    public double add;
    public double nscl;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private double noise([In] float obj0) => Math.pow(ScorchGenerator.sim.octaveNoise2D(this.octaves, this.pers, 1.0 / this.scale, (double) (Angles.trnsx(obj0, (float) this.size / 2f) + (float) this.size / 2f), (double) (Angles.trnsy(obj0, (float) this.size / 2f) + (float) this.size / 2f)), this.pow);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 161, 127, 15, 127, 8, 127, 17, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024generate\u00240([In] Pixmap obj0, [In] int obj1, [In] int obj2)
    {
      if (Math.abs((double) (Mathf.dst((float) obj1, (float) obj2, (float) (this.size / 2), (float) (this.size / 2)) / ((float) this.size / 2f)) - 0.5) * 5.0 + this.add - this.noise(Angles.angle((float) obj1, (float) obj2, (float) (this.size / 2), (float) (this.size / 2))) * this.nscl >= 1.5)
        return;
      obj0.draw(obj1, obj2, this.color);
    }

    [LineNumberTable(new byte[] {159, 150, 168, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScorchGenerator()
    {
      ScorchGenerator scorchGenerator = this;
      this.size = 80;
      this.seed = 0;
      this.color = Color.__\u003C\u003Ewhite.rgba();
      this.scale = 18.0;
      this.pow = 2.0;
      this.octaves = 4.0;
      this.pers = 0.4;
      this.add = 2.0;
      this.nscl = 4.5;
    }

    [LineNumberTable(new byte[] {159, 157, 114, 145, 242, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap generate()
    {
      Pixmap pixmap = new Pixmap(this.size, this.size);
      ScorchGenerator.sim.setSeed((long) this.seed);
      pixmap.each((Intc2) new ScorchGenerator.__\u003C\u003EAnon0(this, pixmap));
      return pixmap;
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ScorchGenerator()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.ScorchGenerator"))
        return;
      ScorchGenerator.sim = new Simplex();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Intc2
    {
      private readonly ScorchGenerator arg\u00241;
      private readonly Pixmap arg\u00242;

      internal __\u003C\u003EAnon0([In] ScorchGenerator obj0, [In] Pixmap obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024generate\u00240(this.arg\u00242, obj0, obj1);
    }
  }
}
