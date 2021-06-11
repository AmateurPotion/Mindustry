// Decompiled with JetBrains decompiler
// Type: mindustry.maps.filters.MirrorFilter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.graphics;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.filters
{
  public class MirrorFilter : GenerateFilter
  {
    [Modifiers]
    private Vec2 v1;
    [Modifiers]
    private Vec2 v2;
    [Modifiers]
    private Vec2 v3;
    internal int angle;

    [LineNumberTable(new byte[] {159, 155, 104, 159, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MirrorFilter()
    {
      MirrorFilter mirrorFilter = this;
      this.v1 = new Vec2();
      this.v2 = new Vec2();
      this.v3 = new Vec2();
      this.angle = 45;
    }

    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool left([In] Vec2 obj0, [In] Vec2 obj1, [In] Vec2 obj2) => (double) ((obj1.x - obj0.x) * (obj2.y - obj0.y) - (obj1.y - obj0.y) * (obj2.x - obj0.x)) > 0.0;

    [LineNumberTable(new byte[] {20, 127, 13, 127, 2, 159, 7, 104, 136, 119, 152, 159, 40})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void mirror([In] Vec2 obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
    {
      if (this.@in.width != this.@in.height)
      {
        int angle = this.angle;
        int num = 90;
        if ((num != -1 ? angle % num : 0) != 0)
        {
          obj0.x = (float) this.@in.width - obj0.x - 1f;
          obj0.y = (float) this.@in.height - obj0.y - 1f;
          return;
        }
      }
      float num1 = obj3 - obj1;
      float num2 = obj4 - obj2;
      float num3 = (num1 * num1 - num2 * num2) / (num1 * num1 + num2 * num2);
      float num4 = 2f * num1 * num2 / (num1 * num1 + num2 * num2);
      obj0.set(num3 * (obj0.x - obj1) + num4 * (obj0.y - obj2) + obj1, num4 * (obj0.x - obj1) - num3 * (obj0.y - obj2) + obj2);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024options\u00240() => (float) this.angle;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024options\u00241([In] float obj0) => this.angle = ByteCodeHelper.f2i(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {5, 104, 127, 2, 31, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024draw\u00242([In] Image obj0, [In] float obj1, [In] float obj2, [In] Vec2 obj3) => obj3.clamp(obj0.x + obj0.getWidth() / 2f - obj1 / 2f, obj0.y + obj0.getHeight() / 2f - obj2 / 2f, obj0.y + obj0.getHeight() / 2f + obj2 / 2f, obj0.x + obj0.getWidth() / 2f + obj1 / 2f);

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override FilterOption[] options()
    {
      FilterOption.SliderOption[] sliderOptionArray = new FilterOption.SliderOption[1];
      FilterOption.SliderOption.__\u003Cclinit\u003E();
      sliderOptionArray[0] = new FilterOption.SliderOption("angle", (Floatp) new MirrorFilter.__\u003C\u003EAnon0(this), (Floatc) new MirrorFilter.__\u003C\u003EAnon1(this), 0.0f, 360f, 45f);
      return (FilterOption[]) Structs.arr((object[]) sliderOptionArray);
    }

    [LineNumberTable(new byte[] {159, 169, 123, 156, 127, 33, 159, 33, 159, 5, 125, 127, 25, 127, 3, 113, 109, 145, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void apply()
    {
      this.v1.trnsExact((float) (this.angle - 90), 1f);
      this.v2.set(this.v1).scl(-1f);
      this.v1.add((float) this.@in.width / 2f - 0.5f, (float) this.@in.height / 2f - 0.5f);
      this.v2.add((float) this.@in.width / 2f - 0.5f, (float) this.@in.height / 2f - 0.5f);
      this.v3.set((float) this.@in.x, (float) this.@in.y);
      if (this.left(this.v1, this.v2, this.v3))
        return;
      this.mirror(this.v3, this.v1.x, this.v1.y, this.v2.x, this.v2.y);
      Tile tile = this.@in.tile(this.v3.x, this.v3.y);
      this.@in.floor = (Block) tile.floor();
      if (!tile.block().synthetic())
        this.@in.block = tile.block();
      this.@in.overlay = (Block) tile.overlay();
    }

    [LineNumberTable(new byte[] {159, 190, 135, 127, 18, 115, 147, 127, 4, 239, 69, 127, 46, 159, 99, 117, 127, 14, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw(Image image)
    {
      base.draw(image);
      Vec2 vec2 = Scaling.__\u003C\u003Efit.apply(image.getDrawable().getMinWidth(), image.getDrawable().getMinHeight(), image.getWidth(), image.getHeight());
      float num1 = Math.max(vec2.x, vec2.y);
      float num2 = Math.max(vec2.y, vec2.x);
      float amount = Math.max(image.getWidth() * 2f, image.getHeight() * 2f);
      Cons cons = (Cons) new MirrorFilter.__\u003C\u003EAnon2(image, num1, num2);
      cons.get((object) Tmp.__\u003C\u003Ev1.trns((float) (this.angle - 90), amount).add(image.getWidth() / 2f + image.x, image.getHeight() / 2f + image.y));
      cons.get((object) Tmp.__\u003C\u003Ev2.set(Tmp.__\u003C\u003Ev1).sub(image.getWidth() / 2f + image.x, image.getHeight() / 2f + image.y).rotate(180f).add(image.getWidth() / 2f + image.x, image.getHeight() / 2f + image.y));
      Lines.stroke(Scl.scl(3f), Pal.accent);
      Lines.line(Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y, Tmp.__\u003C\u003Ev2.x, Tmp.__\u003C\u003Ev2.y);
      Draw.reset();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      private readonly MirrorFilter arg\u00241;

      internal __\u003C\u003EAnon0([In] MirrorFilter obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.lambda\u0024options\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc
    {
      private readonly MirrorFilter arg\u00241;

      internal __\u003C\u003EAnon1([In] MirrorFilter obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.lambda\u0024options\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Image arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon2([In] Image obj0, [In] float obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => MirrorFilter.lambda\u0024draw\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Vec2) obj0);
    }
  }
}
