// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.BlockRenderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.math;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.power;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class BlockRenderer : Object
  {
    public const int crackRegions = 8;
    public const int maxCrackSize = 9;
    private const int initialRequests = 1024;
    private const int expandr = 10;
    [Modifiers]
    private static Color shadowColor;
    internal FloorRenderer __\u003C\u003Efloor;
    public TextureRegion[][] cracks;
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    private Seq tileview;
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    private Seq lightview;
    private int lastCamX;
    private int lastCamY;
    private int lastRangeX;
    private int lastRangeY;
    private float brokenFade;
    private FrameBuffer shadows;
    private FrameBuffer dark;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    private Seq outArray2;
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    private Seq shadowEvents;
    private IntSet procEntities;
    private IntSet procLinks;
    private IntSet procLights;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 185, 232, 50, 171, 118, 182, 107, 107, 107, 107, 107, 223, 2, 245, 73, 245, 106, 245, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockRenderer()
    {
      BlockRenderer blockRenderer = this;
      this.__\u003C\u003Efloor = new FloorRenderer();
      this.tileview = new Seq(false, 1024, (Class) ClassLiteral<Tile>.Value);
      this.lightview = new Seq(false, 1024, (Class) ClassLiteral<Tile>.Value);
      this.brokenFade = 0.0f;
      this.shadows = new FrameBuffer();
      this.dark = new FrameBuffer();
      this.outArray2 = new Seq();
      this.shadowEvents = new Seq();
      this.procEntities = new IntSet();
      this.procLinks = new IntSet();
      this.procLights = new IntSet();
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new BlockRenderer.__\u003C\u003EAnon0(this));
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new BlockRenderer.__\u003C\u003EAnon1(this));
      Events.on((Class) ClassLiteral<EventType.TileChangeEvent>.Value, (Cons) new BlockRenderer.__\u003C\u003EAnon2(this));
    }

    [LineNumberTable(new byte[] {160, 66, 124, 156, 127, 1, 159, 1, 127, 5, 161, 108, 108, 107, 107, 139, 110, 110, 121, 153, 109, 109, 126, 112, 137, 105, 174, 127, 45, 112, 127, 3, 109, 105, 120, 248, 70, 127, 17, 173, 127, 26, 127, 17, 127, 3, 146, 226, 69, 127, 17, 237, 28, 43, 235, 106, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void processBlocks()
    {
      int num1 = ByteCodeHelper.f2i(Core.camera.__\u003C\u003Eposition.x / 8f);
      int num2 = ByteCodeHelper.f2i(Core.camera.__\u003C\u003Eposition.y / 8f);
      int num3 = ByteCodeHelper.f2i(Core.camera.width / 8f / 2f) + 3;
      int num4 = ByteCodeHelper.f2i(Core.camera.height / 8f / 2f) + 3;
      if (num1 == this.lastCamX && num2 == this.lastCamY && (this.lastRangeX == num3 && this.lastRangeY == num4))
        return;
      this.tileview.clear();
      this.lightview.clear();
      this.procEntities.clear();
      this.procLinks.clear();
      this.procLights.clear();
      int num5 = Math.max(num1 - num3 - 10, 0);
      int num6 = Math.max(num2 - num4 - 10, 0);
      int num7 = Math.min(Vars.world.width() - 1, num1 + num3 + 10);
      int num8 = Math.min(Vars.world.height() - 1, num2 + num4 + 10);
      for (int x = num5; x <= num7; ++x)
      {
        for (int y = num6; y <= num8; ++y)
        {
          int num9 = Math.abs(x - num1) > num3 || Math.abs(y - num2) > num4 ? 1 : 0;
          Tile tile = Vars.world.rawTile(x, y);
          Block block = tile.block();
          if (tile.build != null)
            tile = tile.build.tile;
          if (!object.ReferenceEquals((object) block, (object) Blocks.air) && object.ReferenceEquals((object) block.cacheLayer, (object) CacheLayer.__\u003C\u003Enormal) && (tile.build == null || !this.procEntities.contains(tile.build.id)))
          {
            if ((block.expanded || num9 == 0) && (tile.build == null || this.procLinks.add(tile.build.id)))
            {
              this.tileview.add((object) tile);
              if (tile.build != null)
              {
                this.procEntities.add(tile.build.id);
                this.procLinks.add(tile.build.id);
              }
            }
            if (tile.build != null && this.procLights.add(tile.build.pos()) || tile.block().emitLight)
              this.lightview.add((object) tile);
            if (tile.build != null && tile.build.power != null && tile.build.power.links.size > 0)
            {
              Iterator iterator = tile.build.getPowerConnections(this.outArray2).iterator();
              while (iterator.hasNext())
              {
                Building building = (Building) iterator.next();
                if (building.block is PowerNode && this.procLinks.add(building.id))
                  this.tileview.add((object) building.tile);
              }
            }
          }
          if (object.ReferenceEquals((object) block, (object) Blocks.air) && tile.floor().emitLight && this.procLights.add(tile.pos()))
            this.lightview.add((object) tile);
        }
      }
      this.lastCamX = num1;
      this.lastCamY = num2;
      this.lastRangeX = num3;
      this.lastRangeY = num4;
    }

    [LineNumberTable(new byte[] {160, 136, 166, 115, 115, 103, 135, 138, 112, 103, 101, 138, 99, 104, 102, 170, 119, 102, 170, 121, 166, 229, 37, 233, 95, 148, 115, 115, 136, 100, 108, 109, 110, 127, 25, 236, 55, 233, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBlocks()
    {
      this.drawDestroyed();
      for (int index = 0; index < this.tileview.size; ++index)
      {
        Tile tile = ((Tile[]) this.tileview.items)[index];
        Block block = tile.block();
        Building build = tile.build;
        Draw.z(30f);
        if (!object.ReferenceEquals((object) block, (object) Blocks.air))
        {
          block.drawBase(tile);
          Draw.reset();
          Draw.z(30f);
          if (build != null)
          {
            if (build.damaged())
            {
              build.drawCracks();
              Draw.z(30f);
            }
            if (!object.ReferenceEquals((object) build.team, (object) Vars.player.team()))
            {
              build.drawTeam();
              Draw.z(30f);
            }
            if (Vars.renderer.drawStatus && block.__\u003C\u003Econsumes.any())
              build.drawStatus();
          }
          Draw.reset();
        }
      }
      if (!Vars.renderer.__\u003C\u003Elights.enabled())
        return;
      for (int index = 0; index < this.lightview.size; ++index)
      {
        Tile tile = ((Tile[]) this.lightview.items)[index];
        Building build = tile.build;
        if (build != null)
          build.drawLight();
        else if (tile.block().emitLight)
          tile.block().drawEnvironmentLight(tile);
        else if (tile.floor().emitLight && !tile.block().solid && (double) Vars.world.getDarkness((int) tile.x, (int) tile.y) < 3.0)
          tile.floor().drawEnvironmentLight(tile);
      }
    }

    [LineNumberTable(new byte[] {89, 112, 133, 107, 159, 14, 159, 4, 106, 159, 12, 126, 127, 12, 133, 101, 101, 107, 140, 170, 124, 127, 17, 122, 122, 122, 154, 122, 146, 106, 127, 29, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawShadows()
    {
      if (!this.shadowEvents.isEmpty())
      {
        Draw.flush();
        this.shadows.begin();
        Draw.proj().setOrtho(0.0f, 0.0f, (float) this.shadows.getWidth(), (float) this.shadows.getHeight());
        Iterator iterator = this.shadowEvents.iterator();
        while (iterator.hasNext())
        {
          Tile tile = (Tile) iterator.next();
          Draw.color(Color.__\u003C\u003Ewhite);
          Fill.rect((float) tile.x + 0.5f, (float) tile.y + 0.5f, 1f, 1f);
          Draw.color(tile.block().hasShadow ? BlockRenderer.shadowColor : Color.__\u003C\u003Ewhite);
          Fill.rect((float) tile.x + 0.5f, (float) tile.y + 0.5f, 1f, 1f);
        }
        Draw.flush();
        Draw.color();
        this.shadows.end();
        this.shadowEvents.clear();
        Draw.proj(Core.camera);
      }
      float num1 = (float) (Vars.world.width() * 8);
      float num2 = (float) (Vars.world.height() * 8);
      float num3 = Core.camera.__\u003C\u003Eposition.x + 4f;
      float num4 = Core.camera.__\u003C\u003Eposition.y + 4f;
      float u = (num3 - Core.camera.width / 2f) / num1;
      float v2 = (num4 - Core.camera.height / 2f) / num2;
      float u2 = (num3 + Core.camera.width / 2f) / num1;
      float v = (num4 + Core.camera.height / 2f) / num2;
      Tmp.__\u003C\u003Etr1.set((Texture) this.shadows.getTexture());
      Tmp.__\u003C\u003Etr1.set(u, v, u2, v2);
      Draw.shader((Shader) Shaders.darkness);
      Draw.rect(Tmp.__\u003C\u003Etr1, Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y, Core.camera.width, Core.camera.height);
      Draw.shader();
    }

    [LineNumberTable(new byte[] {61, 106, 127, 1, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawDarkness()
    {
      Draw.shader((Shader) Shaders.darkness);
      Draw.fbo(this.dark, Vars.world.width(), Vars.world.height(), 8);
      Draw.shader();
    }

    [LineNumberTable(new byte[] {67, 146, 127, 3, 158, 188, 112, 127, 28, 113, 159, 64, 114, 127, 7, 127, 44, 101, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawDestroyed()
    {
      if (!Core.settings.getBool("destroyedblocks"))
        return;
      this.brokenFade = Vars.control.input.isPlacing() || Vars.control.input.isBreaking() ? Mathf.lerpDelta(this.brokenFade, 1f, 0.1f) : Mathf.lerpDelta(this.brokenFade, 0.0f, 0.1f);
      if ((double) this.brokenFade <= 1.0 / 1000.0)
        return;
      Iterator iterator = Vars.state.teams.get(Vars.player.team()).blocks.iterator();
      while (iterator.hasNext())
      {
        Teams.BlockPlan blockPlan = (Teams.BlockPlan) iterator.next();
        Block block = Vars.content.block((int) blockPlan.__\u003C\u003Eblock);
        if (Core.camera.bounds(Tmp.__\u003C\u003Er1).grow(16f).overlaps(Tmp.__\u003C\u003Er2.setSize((float) (block.size * 8)).setCenter((float) ((int) blockPlan.__\u003C\u003Ex * 8) + block.offset, (float) ((int) blockPlan.__\u003C\u003Ey * 8) + block.offset)))
        {
          Draw.alpha(0.33f * this.brokenFade);
          Draw.mixcol(Color.__\u003C\u003Ewhite, 0.2f + Mathf.absin(Time.globalTime, 6f, 0.2f));
          Draw.rect(block.icon(Cicon.__\u003C\u003Efull), (float) ((int) blockPlan.__\u003C\u003Ex * 8) + block.offset, (float) ((int) blockPlan.__\u003C\u003Ey * 8) + block.offset, !block.rotate ? 0.0f : (float) ((int) blockPlan.__\u003C\u003Erotation * 90));
        }
      }
      Draw.reset();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 188, 127, 11, 103, 102, 63, 33, 38, 233, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.ClientLoadEvent obj0)
    {
      int[] numArray = new int[2];
      int num1 = 8;
      numArray[1] = num1;
      int num2 = 9;
      numArray[0] = num2;
      // ISSUE: type reference
      this.cracks = (TextureRegion[][]) ByteCodeHelper.multianewarray(__typeref (TextureRegion[][]), numArray);
      for (int index1 = 1; index1 <= 9; ++index1)
      {
        for (int index2 = 0; index2 < 8; ++index2)
          this.cracks[index1 - 1][index2] = (TextureRegion) Core.atlas.find(new StringBuilder().append("cracks-").append(index1).append("-").append(index2).toString());
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {5, 108, 147, 127, 0, 127, 0, 107, 111, 159, 14, 138, 127, 5, 109, 159, 12, 130, 101, 101, 139, 127, 0, 127, 0, 107, 111, 159, 14, 127, 8, 152, 104, 127, 15, 159, 12, 133, 101, 101, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] EventType.WorldLoadEvent obj0)
    {
      this.shadowEvents.clear();
      BlockRenderer blockRenderer = this;
      int num1 = -99;
      int num2 = num1;
      this.lastCamX = num1;
      this.lastCamY = num2;
      this.shadows.getTexture().setFilter(Texture.TextureFilter.__\u003C\u003Elinear, Texture.TextureFilter.__\u003C\u003Elinear);
      this.shadows.resize(Vars.world.width(), Vars.world.height());
      this.shadows.begin();
      Core.graphics.clear(Color.__\u003C\u003Ewhite);
      Draw.proj().setOrtho(0.0f, 0.0f, (float) this.shadows.getWidth(), (float) this.shadows.getHeight());
      Draw.color(BlockRenderer.shadowColor);
      Iterator iterator1 = Vars.world.tiles.iterator();
      while (iterator1.hasNext())
      {
        Tile tile = (Tile) iterator1.next();
        if (tile.block().hasShadow)
          Fill.rect((float) tile.x + 0.5f, (float) tile.y + 0.5f, 1f, 1f);
      }
      Draw.flush();
      Draw.color();
      this.shadows.end();
      this.dark.getTexture().setFilter(Texture.TextureFilter.__\u003C\u003Elinear, Texture.TextureFilter.__\u003C\u003Elinear);
      this.dark.resize(Vars.world.width(), Vars.world.height());
      this.dark.begin();
      Core.graphics.clear(Color.__\u003C\u003Ewhite);
      Draw.proj().setOrtho(0.0f, 0.0f, (float) this.dark.getWidth(), (float) this.dark.getHeight());
      Iterator iterator2 = Vars.world.tiles.iterator();
      while (iterator2.hasNext())
      {
        Tile tile = (Tile) iterator2.next();
        float darkness = Vars.world.getDarkness((int) tile.x, (int) tile.y);
        if ((double) darkness > 0.0)
        {
          Draw.color(0.0f, 0.0f, 0.0f, Math.min((darkness + 0.5f) / 4f, 1f));
          Fill.rect((float) tile.x + 0.5f, (float) tile.y + 0.5f, 1f, 1f);
        }
      }
      Draw.flush();
      Draw.color();
      this.dark.end();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {47, 145, 124, 124, 127, 1, 159, 1, 127, 11, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] EventType.TileChangeEvent obj0)
    {
      this.shadowEvents.add((object) obj0.__\u003C\u003Etile);
      int num1 = ByteCodeHelper.f2i(Core.camera.__\u003C\u003Eposition.x / 8f);
      int num2 = ByteCodeHelper.f2i(Core.camera.__\u003C\u003Eposition.y / 8f);
      int num3 = ByteCodeHelper.f2i(Core.camera.width / 8f / 2f) + 2;
      int num4 = ByteCodeHelper.f2i(Core.camera.height / 8f / 2f) + 2;
      if (Math.abs(num1 - (int) obj0.__\u003C\u003Etile.x) > num3 || Math.abs(num2 - (int) obj0.__\u003C\u003Etile.y) > num4)
        return;
      BlockRenderer blockRenderer = this;
      int num5 = -99;
      int num6 = num5;
      this.lastCamX = num5;
      this.lastCamY = num6;
    }

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static BlockRenderer()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.BlockRenderer"))
        return;
      BlockRenderer.shadowColor = new Color(0.0f, 0.0f, 0.0f, 0.71f);
    }

    [Modifiers]
    public FloorRenderer floor
    {
      [HideFromJava] get => this.__\u003C\u003Efloor;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efloor = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly BlockRenderer arg\u00241;

      internal __\u003C\u003EAnon0([In] BlockRenderer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly BlockRenderer arg\u00241;

      internal __\u003C\u003EAnon1([In] BlockRenderer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly BlockRenderer arg\u00241;

      internal __\u003C\u003EAnon2([In] BlockRenderer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00242((EventType.TileChangeEvent) obj0);
    }
  }
}
