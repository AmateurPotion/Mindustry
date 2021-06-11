// Decompiled with JetBrains decompiler
// Type: mindustry.maps.generators.FileMapGenerator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.func;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.game;
using mindustry.io;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps.generators
{
  public class FileMapGenerator : Object, WorldGenerator
  {
    internal Map __\u003C\u003Emap;
    internal SectorPreset __\u003C\u003Epreset;

    [LineNumberTable(new byte[] {159, 161, 104, 123, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FileMapGenerator(string mapName, SectorPreset preset)
    {
      FileMapGenerator fileMapGenerator = this;
      this.__\u003C\u003Emap = Vars.maps == null ? (Map) null : Vars.maps.loadInternalMap(mapName);
      this.__\u003C\u003Epreset = preset;
    }

    [LineNumberTable(new byte[] {159, 168, 152, 107, 127, 20, 139, 107, 159, 24, 126, 127, 16, 120, 112, 31, 13, 232, 70, 133, 131, 159, 3, 115, 100, 255, 14, 71, 127, 28, 115, 131, 109, 191, 1, 133, 100, 176, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void generate(Tiles tiles)
    {
      if (this.__\u003C\u003Emap == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Generator has null map, cannot be used.");
      }
      Vars.world.setGenerating(false);
      Fi file = this.__\u003C\u003Emap.__\u003C\u003Efile;
      World.Context context1 = Vars.world.filterContext(this.__\u003C\u003Emap);
      WorldContext context2;
      if (context1 != null)
        context2 = context1 is WorldContext worldContext2 ? worldContext2 : throw new IncompatibleClassChangeError();
      else
        context2 = (WorldContext) null;
      SaveIO.load(file, context2);
      Vars.world.setGenerating(true);
      Tiles tiles1 = Vars.world.tiles;
      Item[] objArray1 = new Item[6]
      {
        Items.blastCompound,
        Items.pyratite,
        Items.copper,
        Items.thorium,
        Items.copper,
        Items.lead
      };
      Iterator iterator1 = tiles1.iterator();
label_7:
      while (iterator1.hasNext())
      {
        Tile tile = (Tile) iterator1.next();
        if (tile.block() is StorageBlock && !(tile.block() is CoreBlock) && Vars.state.hasSector())
        {
          Item[] objArray2 = objArray1;
          int length = objArray2.Length;
          int index = 0;
          while (true)
          {
            if (index < length)
            {
              Item obj = objArray2[index];
              if (Mathf.chance(0.2))
                tile.build.items.add(obj, Math.min(Mathf.random(500), tile.block().itemCapacity));
              ++index;
            }
            else
              goto label_7;
          }
        }
      }
      int num = 0;
      Iterator iterator2 = tiles1.iterator();
      while (iterator2.hasNext())
      {
        Tile tile = (Tile) iterator2.next();
        if (object.ReferenceEquals((object) tile.overlay(), (object) Blocks.spawn))
        {
          int radius = 10;
          Geometry.circle((int) tile.x, (int) tile.y, tiles1.__\u003C\u003Ewidth, tiles1.__\u003C\u003Eheight, radius, (Intc2) new FileMapGenerator.__\u003C\u003EAnon0(tile));
        }
        if (tile.isCenter() && tile.block() is CoreBlock && (object.ReferenceEquals((object) tile.team(), (object) Vars.state.rules.defaultTeam) && num == 0))
        {
          Schematics.placeLaunchLoadout((int) tile.x, (int) tile.y);
          num = 1;
          if (this.__\u003C\u003Epreset.addStartingItems)
            tile.build.items.add((Iterable) Vars.state.rules.loadout);
        }
      }
      if (num == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("All maps must have a core.");
      }
      Vars.state.map = this.__\u003C\u003Emap;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {2, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024generate\u00240([In] Tile obj0, [In] int obj1, [In] int obj2)
    {
      if (obj0.overlay().itemDrop == null)
        return;
      obj0.clearOverlay();
    }

    [HideFromJava]
    public virtual void postGenerate([In] Tiles obj0) => WorldGenerator.\u003Cdefault\u003EpostGenerate((WorldGenerator) this, obj0);

    [Modifiers]
    public Map map
    {
      [HideFromJava] get => this.__\u003C\u003Emap;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emap = value;
    }

    [Modifiers]
    public SectorPreset preset
    {
      [HideFromJava] get => this.__\u003C\u003Epreset;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Epreset = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Intc2
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon0([In] Tile obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0, [In] int obj1) => FileMapGenerator.lambda\u0024generate\u00240(this.arg\u00241, obj0, obj1);
    }
  }
}
