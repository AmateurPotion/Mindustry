// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.units.UnitBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using mindustry.world.blocks.payloads;
using mindustry.world.blocks.production;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.units
{
  public class UnitBlock : PayloadAcceptor
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 105, 107, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnitBlock(string name)
      : base(name)
    {
      UnitBlock unitBlock = this;
      this.group = BlockGroup.__\u003C\u003Eunits;
      this.outputsPayload = true;
      this.rotate = true;
      this.update = true;
      this.solid = true;
    }

    [LineNumberTable(new byte[] {159, 172, 127, 9, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitBlockSpawn(Tile tile)
    {
      if (tile == null)
        return;
      Building build = tile.build;
      UnitBlock.UnitBuild unitBuild;
      if (!(build is UnitBlock.UnitBuild) || !object.ReferenceEquals((object) (unitBuild = (UnitBlock.UnitBuild) build), (object) (UnitBlock.UnitBuild) build))
        return;
      unitBuild.spawned();
    }

    [HideFromJava]
    static UnitBlock() => PayloadAcceptor.__\u003Cclinit\u003E();

    [Signature("Lmindustry/world/blocks/production/PayloadAcceptor$PayloadAcceptorBuild<Lmindustry/world/blocks/payloads/UnitPayload;>;")]
    public class UnitBuild : PayloadAcceptor.PayloadAcceptorBuild
    {
      public float progress;
      public float time;
      public float speedScl;
      [Modifiers]
      internal UnitBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void spawned()
      {
        this.progress = 0.0f;
        this.payload = (Payload) null;
      }

      [LineNumberTable(34)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitBuild(UnitBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((PayloadAcceptor) _param1);
      }

      [LineNumberTable(new byte[] {159, 186, 114, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void dumpPayload()
      {
        if (!((UnitPayload) this.payload).dump())
          return;
        Call.unitBlockSpawn(this.tile);
      }

      [HideFromJava]
      static UnitBuild() => PayloadAcceptor.PayloadAcceptorBuild.__\u003Cclinit\u003E();
    }
  }
}
