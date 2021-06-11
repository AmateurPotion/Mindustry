// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.experimental.BlockUnloader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using mindustry.world.blocks.payloads;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.experimental
{
  public class BlockUnloader : BlockLoader
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 153, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockUnloader(string name)
      : base(name)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool outputsItems() => true;

    [HideFromJava]
    static BlockUnloader() => BlockLoader.__\u003Cclinit\u003E();

    public class BlockUnloaderBuild : BlockLoader.BlockLoaderBuild
    {
      [Modifiers]
      internal BlockUnloader this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(59)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool shouldExport() => this.payload != null && ((BuildPayload) this.payload).block().hasItems && ((BuildPayload) this.payload).build.items.empty();

      [LineNumberTable(54)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool full() => this.items.total() >= this.this\u00240.itemCapacity;

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BlockUnloaderBuild(BlockUnloader _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((BlockLoader) _param1);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool acceptItem(Building source, Item item) => false;

      [LineNumberTable(new byte[] {159, 170, 104, 107, 171, 127, 6, 159, 28, 126, 112, 126, 108, 124, 109, 226, 59, 41, 233, 78, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        if (this.shouldExport())
          this.moveOutPayload();
        else if (this.moveInPayload() && ((BuildPayload) this.payload).block().hasItems && (!this.full() && (double) this.efficiency() > 0.00999999977648258) && this.timer(this.this\u00240.__\u003C\u003EtimerLoad, this.this\u00240.loadTime / this.efficiency()))
        {
          for (int index = 0; index < this.this\u00240.itemsLoaded && !this.full(); ++index)
          {
            for (int id = 0; id < this.items.length(); ++id)
            {
              if (((BuildPayload) this.payload).build.items.get(id) > 0)
              {
                Item obj = Vars.content.item(id);
                ((BuildPayload) this.payload).build.items.remove(obj, 1);
                this.items.add(obj, 1);
                break;
              }
            }
          }
        }
        this.dump();
      }

      [HideFromJava]
      static BlockUnloaderBuild() => BlockLoader.BlockLoaderBuild.__\u003Cclinit\u003E();
    }
  }
}
