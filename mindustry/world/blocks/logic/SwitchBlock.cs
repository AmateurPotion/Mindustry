// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.logic.SwitchBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.math.geom;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.world.meta;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.logic
{
  public class SwitchBlock : Block
  {
    public TextureRegion onRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] SwitchBlock.SwitchBuild obj0, [In] Boolean obj1) => obj0.enabled = obj1.booleanValue();

    [LineNumberTable(new byte[] {159, 156, 105, 103, 103, 103, 103, 139, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SwitchBlock(string name)
      : base(name)
    {
      SwitchBlock switchBlock = this;
      this.configurable = true;
      this.update = true;
      this.drawDisabled = false;
      this.autoResetEnabled = false;
      this.group = BlockGroup.__\u003C\u003Elogic;
      this.config((Class) ClassLiteral<Boolean>.Value, (Cons2) new SwitchBlock.__\u003C\u003EAnon0());
    }

    [HideFromJava]
    static SwitchBlock() => Block.__\u003Cclinit\u003E();

    public class SwitchBuild : Building
    {
      [Modifiers]
      internal SwitchBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Boolean config() => Boolean.valueOf(this.enabled);

      [LineNumberTable(24)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SwitchBuild(SwitchBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 170, 119, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool configTapped()
      {
        this.configure((object) Boolean.valueOf(!this.enabled));
        Sounds.click.at((Position) this);
        return false;
      }

      [LineNumberTable(new byte[] {159, 177, 134, 104, 156})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        if (!this.enabled)
          return;
        Draw.rect(this.this\u00240.onRegion, this.x, this.y);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 1;

      [LineNumberTable(new byte[] {159, 129, 131, 136, 100, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void readAll(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.readAll(read, (byte) num);
        if (num != 1)
          return;
        this.enabled = read.@bool();
      }

      [LineNumberTable(new byte[] {13, 135, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        write.@bool(this.enabled);
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(24)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      static SwitchBuild() => Building.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => SwitchBlock.lambda\u0024new\u00240((SwitchBlock.SwitchBuild) obj0, (Boolean) obj1);
    }
  }
}
