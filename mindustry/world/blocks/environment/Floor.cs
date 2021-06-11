// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.Floor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.audio;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.entities;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.environment
{
  public class Floor : Block
  {
    public int variants;
    public string edge;
    public float speedMultiplier;
    public float dragMultiplier;
    public float damageTaken;
    public float drownTime;
    public Effect walkEffect;
    public Sound walkSound;
    public float walkSoundVolume;
    public float walkSoundPitchMin;
    public float walkSoundPitchMax;
    public Effect drownUpdateEffect;
    public StatusEffect status;
    public float statusDuration;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Liquid liquidDrop;
    public float liquidMultiplier;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Item itemDrop;
    public bool isLiquid;
    public bool playerUnmineable;
    public Block blendGroup;
    public Effect updateEffect;
    public mindustry.world.blocks.Attributes attributes;
    public bool oreDefault;
    public float oreScale;
    public float oreThreshold;
    public Block wall;
    public Block decoration;
    public bool needsSurface;
    protected internal TextureRegion[][] edges;
    [Signature("Larc/struct/Seq<Lmindustry/world/Block;>;")]
    protected internal Seq blenders;
    protected internal Bits blended;
    protected internal TextureRegion edgeRegion;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDeep() => (double) this.drownTime > 0.0;

    [LineNumberTable(new byte[] {32, 233, 8, 135, 139, 139, 139, 139, 139, 139, 139, 159, 2, 139, 139, 139, 135, 139, 199, 135, 135, 139, 139, 135, 150, 139, 139, 167, 107, 240, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Floor(string name)
      : base(name)
    {
      Floor floor = this;
      this.variants = 3;
      this.edge = "stone";
      this.speedMultiplier = 1f;
      this.dragMultiplier = 1f;
      this.damageTaken = 0.0f;
      this.drownTime = 0.0f;
      this.walkEffect = Fx.__\u003C\u003Enone;
      this.walkSound = Sounds.none;
      this.walkSoundVolume = 0.1f;
      this.walkSoundPitchMin = 0.8f;
      this.walkSoundPitchMax = 1.2f;
      this.drownUpdateEffect = Fx.__\u003C\u003Ebubble;
      this.status = StatusEffects.none;
      this.statusDuration = 60f;
      this.liquidDrop = (Liquid) null;
      this.liquidMultiplier = 1f;
      this.itemDrop = (Item) null;
      this.playerUnmineable = false;
      this.blendGroup = (Block) this;
      this.updateEffect = Fx.__\u003C\u003Enone;
      this.attributes = new mindustry.world.blocks.Attributes();
      this.oreDefault = false;
      this.oreScale = 24f;
      this.oreThreshold = 0.828f;
      this.wall = Blocks.air;
      this.decoration = Blocks.air;
      this.needsSurface = true;
      this.blenders = new Seq();
      this.blended = new Bits(256);
    }

    [LineNumberTable(182)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion[] icons() => new TextureRegion[1]
    {
      (TextureRegion) Core.atlas.find(!Core.atlas.has(this.__\u003C\u003Ename) ? new StringBuilder().append(this.__\u003C\u003Ename).append("1").toString() : this.__\u003C\u003Ename)
    };

    [LineNumberTable(new byte[] {160, 100, 108, 139, 105, 104, 104, 127, 23, 120, 241, 59, 233, 74, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawEdges(Tile tile)
    {
      this.blenders.clear();
      this.blended.clear();
      for (int index = 0; index < 8; ++index)
      {
        Point2 relative = Geometry.__\u003C\u003Ed8[index];
        Tile tile1 = tile.nearby(relative);
        if (tile1 != null && this.doEdge(tile1.floor()) && (object.ReferenceEquals((object) tile1.floor().cacheLayer, (object) this.cacheLayer) && tile1.floor().edges() != null) && !this.blended.getAndSet((int) tile1.floor().__\u003C\u003Eid))
          this.blenders.add((object) tile1.floor());
      }
      this.drawBlended(tile);
    }

    [LineNumberTable(new byte[] {118, 145, 159, 23, 135, 103, 118, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBase(Tile tile)
    {
      Mathf.rand.setSeed((long) tile.pos());
      Draw.rect(this.variantRegions[Mathf.randomSeed((long) tile.pos(), 0, Math.max(0, this.variantRegions.Length - 1))], tile.worldx(), tile.worldy());
      this.drawEdges(tile);
      Floor floor = tile.overlay();
      if (object.ReferenceEquals((object) floor, (object) Blocks.air) || object.ReferenceEquals((object) floor, (object) this))
        return;
      floor.drawBase(tile);
    }

    [LineNumberTable(260)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual TextureRegion[][] edges() => ((Floor) this.blendGroup).edges;

    [LineNumberTable(new byte[] {160, 117, 150, 127, 4, 105, 104, 105, 115, 126, 245, 59, 233, 72, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawBlended(Tile tile)
    {
      this.blenders.sort((Floatf) new Floor.__\u003C\u003EAnon1());
      Iterator iterator = this.blenders.iterator();
label_1:
      while (iterator.hasNext())
      {
        Block block = (Block) iterator.next();
        int index = 0;
        while (true)
        {
          if (index < 8)
          {
            Point2 relative = Geometry.__\u003C\u003Ed8[index];
            Tile tile1 = tile.nearby(relative);
            if (tile1 != null && object.ReferenceEquals((object) tile1.floor(), (object) block))
              Draw.rect(this.edge((Floor) block, 1 - relative.x, 1 - relative.y), tile.worldx(), tile.worldy());
            ++index;
          }
          else
            goto label_1;
        }
      }
    }

    [LineNumberTable(264)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool doEdge(Floor other) => (int) other.blendGroup.__\u003C\u003Eid > (int) this.blendGroup.__\u003C\u003Eid || this.edges() == null;

    [LineNumberTable(268)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual TextureRegion edge([In] Floor obj0, [In] int obj1, [In] int obj2) => obj0.edges()[obj1][2 - obj2];

    [Modifiers]
    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024init\u00240([In] Block obj0) => obj0 is Boulder && obj0.minfo.mod == null && obj0.breakable ? this.mapColor.diff(obj0.mapColor) : float.PositiveInfinity;

    [Modifiers]
    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024drawBlended\u00241([In] Block obj0) => (float) obj0.__\u003C\u003Eid;

    [LineNumberTable(new byte[] {37, 166, 105, 145, 107, 63, 16, 200, 108, 184, 114, 127, 12, 159, 23, 110, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      base.load();
      if (this.variants > 0)
      {
        this.variantRegions = new TextureRegion[this.variants];
        for (int index = 0; index < this.variants; ++index)
          this.variantRegions[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append(index + 1).toString());
      }
      else
      {
        this.variantRegions = new TextureRegion[1];
        this.variantRegions[0] = (TextureRegion) Core.atlas.find(this.__\u003C\u003Ename);
      }
      int num = ByteCodeHelper.f2i(8f / Draw.scl);
      if (Core.atlas.has(new StringBuilder().append(this.__\u003C\u003Ename).append("-edge").toString()))
        this.edges = Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-edge").toString()).split(num, num);
      this.region = this.variantRegions[0];
      this.edgeRegion = (TextureRegion) Core.atlas.find("edge");
    }

    [LineNumberTable(new byte[] {61, 134, 117, 127, 16, 223, 73, 147, 114, 191, 6, 122, 171, 122, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      base.init();
      if (object.ReferenceEquals((object) this.wall, (object) Blocks.air))
      {
        this.wall = Vars.content.block(new StringBuilder().append(this.__\u003C\u003Ename).append("-wall").toString());
        if (this.wall == null)
        {
          ContentLoader content = Vars.content;
          StringBuilder stringBuilder = new StringBuilder();
          string name1 = this.__\u003C\u003Ename;
          object obj1 = (object) "dune";
          object obj2 = (object) "darksand";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj2;
          CharSequence charSequence2 = charSequence1;
          object obj3 = obj1;
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence3 = charSequence1;
          string str = String.instancehelper_replace(name1, charSequence2, charSequence3);
          string name2 = stringBuilder.append(str).append("-wall").toString();
          this.wall = content.block(name2);
        }
      }
      if (this.wall == null)
        this.wall = Blocks.air;
      if (object.ReferenceEquals((object) this.decoration, (object) Blocks.air))
        this.decoration = (Block) Vars.content.blocks().min((Floatf) new Floor.__\u003C\u003EAnon0(this));
      if (this.isLiquid && object.ReferenceEquals((object) this.walkEffect, (object) Fx.__\u003C\u003Enone))
        this.walkEffect = Fx.__\u003C\u003Eripple;
      if (!this.isLiquid || !object.ReferenceEquals((object) this.walkSound, (object) Sounds.none))
        return;
      this.walkSound = Sounds.splash;
    }

    [LineNumberTable(new byte[] {86, 103, 159, 42, 110, 161, 108, 107, 126, 31, 22, 230, 70, 102, 102, 121, 113, 149, 113, 113, 109, 31, 37, 43, 235, 71, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void createIcons(MultiPacker packer)
    {
      base.createIcons(packer);
      packer.add(MultiPacker.PageType.__\u003C\u003Eeditor, new StringBuilder().append("editor-").append(this.__\u003C\u003Ename).toString(), Core.atlas.getPixmap((TextureAtlas.AtlasRegion) this.icon(Cicon.__\u003C\u003Efull)).crop());
      if (!object.ReferenceEquals((object) this.blendGroup, (object) this))
        return;
      if (this.variants > 0)
      {
        for (int index = 0; index < this.variants; ++index)
        {
          string name = new StringBuilder().append(this.__\u003C\u003Ename).append(index + 1).toString();
          packer.add(MultiPacker.PageType.__\u003C\u003Eeditor, new StringBuilder().append("editor-").append(name).toString(), Core.atlas.getPixmap(name).crop());
        }
      }
      Color color1 = new Color();
      Color color2 = new Color();
      PixmapRegion pixmap1 = Core.atlas.getPixmap((TextureAtlas.AtlasRegion) this.icons()[0]);
      PixmapRegion pixmap2 = Core.atlas.getPixmap("edge-stencil");
      Pixmap pix = new Pixmap(pixmap2.width, pixmap2.height);
      for (int x1 = 0; x1 < pixmap2.width; ++x1)
      {
        for (int y1 = 0; y1 < pixmap2.height; ++y1)
        {
          pixmap2.getPixel(x1, y1, color1);
          Pixmap pixmap3 = pix;
          int x2 = x1;
          int y2 = y1;
          Color color3 = color1;
          Color color4 = color2;
          PixmapRegion pixmapRegion = pixmap1;
          int num1 = x1;
          int width = pixmap1.width;
          int x3 = width != -1 ? num1 % width : 0;
          int num2 = y1;
          int height = pixmap1.height;
          int y3 = height != -1 ? num2 % height : 0;
          int pixel = pixmapRegion.getPixel(x3, y3);
          Color color5 = color4.set(pixel);
          Color color6 = color3.mul(color5);
          pixmap3.draw(x2, y2, color6);
        }
      }
      packer.add(MultiPacker.PageType.__\u003C\u003Eenvironment, new StringBuilder().append(this.__\u003C\u003Ename).append("-edge").toString(), pix);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasSurface() => !this.isLiquid && !this.solid;

    [LineNumberTable(new byte[] {160, 81, 145, 108, 139, 105, 104, 104, 127, 4, 120, 241, 59, 233, 74, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawNonLayer(Tile tile, CacheLayer layer)
    {
      Mathf.rand.setSeed((long) tile.pos());
      this.blenders.clear();
      this.blended.clear();
      for (int index = 0; index < 8; ++index)
      {
        Point2 relative = Geometry.__\u003C\u003Ed8[index];
        Tile tile1 = tile.nearby(relative);
        if (tile1 != null && object.ReferenceEquals((object) tile1.floor().cacheLayer, (object) layer) && (tile1.floor().edges() != null && !this.blended.getAndSet((int) tile1.floor().__\u003C\u003Eid)))
          this.blenders.add((object) tile1.floor());
      }
      this.drawBlended(tile);
    }

    [LineNumberTable(new byte[] {160, 133, 105, 104, 113, 108, 124, 254, 59, 233, 72, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawEdgesFlat(Tile tile, bool sameLayer)
    {
      for (int rotation = 0; rotation < 4; ++rotation)
      {
        Tile tile1 = tile.nearby(rotation);
        if (tile1 != null && this.doEdge(tile1.floor()))
        {
          Color mapColor = tile1.floor().mapColor;
          Draw.color(mapColor.r, mapColor.g, mapColor.b, 1f);
          Draw.rect(this.edgeRegion, tile.worldx(), tile.worldy(), (float) (rotation * 90));
        }
      }
      Draw.color();
    }

    [HideFromJava]
    static Floor() => Block.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Floatf
    {
      private readonly Floor arg\u00241;

      internal __\u003C\u003EAnon0([In] Floor obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024init\u00240((Block) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Floatf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float get([In] object obj0) => Floor.lambda\u0024drawBlended\u00241((Block) obj0);
    }
  }
}
