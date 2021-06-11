// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.power.LightBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.graphics;
using mindustry.logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.power
{
  public class LightBlock : Block
  {
    public float brightness;
    public float radius;
    public TextureRegion topRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] LightBlock.LightBuild obj0, [In] Integer obj1) => obj0.color = obj1.intValue();

    [LineNumberTable(new byte[] {159, 165, 233, 59, 107, 235, 69, 103, 103, 103, 135, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LightBlock(string name)
      : base(name)
    {
      LightBlock lightBlock = this;
      this.brightness = 0.9f;
      this.radius = 200f;
      this.hasPower = true;
      this.update = true;
      this.configurable = true;
      this.saveConfig = true;
      this.config((Class) ClassLiteral<Integer>.Value, (Cons2) new LightBlock.__\u003C\u003EAnon0());
    }

    [HideFromJava]
    static LightBlock() => Block.__\u003Cclinit\u003E();

    public class LightBuild : Building
    {
      public int color;
      public float smoothTime;
      [Modifiers]
      internal LightBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(75)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Integer config() => Integer.valueOf(this.color);

      [Modifiers]
      [LineNumberTable(new byte[] {13, 127, 22, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00241()
      {
        Vars.ui.picker.show(Tmp.__\u003C\u003Ec1.set(this.color).a(0.5f), false, (Cons) new LightBlock.LightBuild.__\u003C\u003EAnon1(this));
        this.deselect();
      }

      [Modifiers]
      [LineNumberTable(63)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00240([In] Color obj0) => this.configure((object) Integer.valueOf(obj0.rgba()));

      [LineNumberTable(new byte[] {159, 174, 111, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LightBuild(LightBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LightBlock.LightBuild lightBuild = this;
        this.color = Pal.accent.rgba();
        this.smoothTime = 1f;
      }

      [LineNumberTable(new byte[] {159, 180, 109, 186, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void control(LAccess type, double p1, double p2, double p3, double p4)
      {
        if (object.ReferenceEquals((object) type, (object) LAccess.__\u003C\u003Ecolor))
          this.color = Color.rgba8888((float) p1, (float) p2, (float) p3, 1f);
        base.control(type, p1, p2, p3, p4);
      }

      [LineNumberTable(new byte[] {159, 189, 102, 106, 127, 4, 124, 101, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Draw.blend(Blending.__\u003C\u003Eadditive);
        Draw.color(Tmp.__\u003C\u003Ec1.set(this.color), this.efficiency() * 0.3f);
        Draw.rect(this.this\u00240.topRegion, this.x, this.y);
        Draw.color();
        Draw.blend();
      }

      [LineNumberTable(new byte[] {7, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile() => this.smoothTime = Mathf.lerpDelta(this.smoothTime, this.timeScale, 0.1f);

      [LineNumberTable(new byte[] {12, 187, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table) => table.button((Drawable) Icon.pencil, (Runnable) new LightBlock.LightBuild.__\u003C\u003EAnon0(this)).size(40f);

      [LineNumberTable(new byte[] {20, 127, 58})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawLight() => Drawf.light(this.team, this.x, this.y, this.this\u00240.radius * Math.min(this.smoothTime, 2f), Tmp.__\u003C\u003Ec1.set(this.color), this.this\u00240.brightness * this.efficiency());

      [LineNumberTable(new byte[] {30, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.i(this.color);
      }

      [LineNumberTable(new byte[] {159, 121, 131, 104, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.color = read.i();
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(32)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static LightBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly LightBlock.LightBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] LightBlock.LightBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024buildConfiguration\u00241();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LightBlock.LightBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] LightBlock.LightBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildConfiguration\u00240((Color) obj0);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => LightBlock.lambda\u0024new\u00240((LightBlock.LightBuild) obj0, (Integer) obj1);
    }
  }
}
