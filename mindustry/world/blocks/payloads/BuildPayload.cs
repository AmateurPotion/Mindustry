// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.payloads.BuildPayload
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.payloads
{
  public class BuildPayload : Object, Payload
  {
    public Building build;

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block block() => this.build.block;

    [LineNumberTable(new byte[] {159, 162, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BuildPayload(Building build)
    {
      BuildPayload buildPayload = this;
      this.build = build;
    }

    [LineNumberTable(new byte[] {159, 175, 127, 9, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void place(Tile tile, int rotation)
    {
      tile.setBlock(this.build.block, this.build.team, rotation, (Prov) new BuildPayload.__\u003C\u003EAnon0(this));
      this.build.dropped();
    }

    [LineNumberTable(new byte[] {159, 158, 104, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BuildPayload(Block block, Team team)
    {
      BuildPayload buildPayload = this;
      this.build = block.newBuilding().create(block, team);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Building lambda\u0024place\u00240() => this.build;

    [LineNumberTable(new byte[] {159, 171, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void place(Tile tile) => this.place(tile, 0);

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float size() => (float) (this.build.block.size * 8);

    [LineNumberTable(new byte[] {159, 186, 103, 118, 114, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Writes write)
    {
      write.b(1);
      write.s((int) this.build.block.__\u003C\u003Eid);
      write.b((int) (sbyte) this.build.version());
      this.build.writeAll(write);
    }

    [LineNumberTable(new byte[] {2, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(float x, float y, float rotation) => this.build.set(x, y);

    [LineNumberTable(new byte[] {7, 127, 22, 127, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Drawf.shadow(this.build.x, this.build.y, (float) (this.build.block.size * 8) * 2f);
      Draw.rect(this.build.block.icon(Cicon.__\u003C\u003Efull), this.build.x, this.build.y);
    }

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion icon(Cicon icon) => this.block().icon(icon);

    [HideFromJava]
    public virtual bool dump() => Payload.\u003Cdefault\u003Edump((Payload) this);

    [HideFromJava]
    public virtual bool fits([In] float obj0) => Payload.\u003Cdefault\u003Efits((Payload) this, obj0);

    [HideFromJava]
    public virtual float rotation() => Payload.\u003Cdefault\u003Erotation((Payload) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      private readonly BuildPayload arg\u00241;

      internal __\u003C\u003EAnon0([In] BuildPayload obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024place\u00240();
    }
  }
}
