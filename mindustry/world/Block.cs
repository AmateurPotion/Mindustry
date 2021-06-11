// Decompiled with JetBrains decompiler
// Type: mindustry.world.Block
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
using arc.scene.ui.layout;
using arc.util;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.power;
using mindustry.world.consumers;
using mindustry.world.meta;
using mindustry.world.meta.values;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world
{
  public class Block : UnlockableContent
  {
    public bool hasItems;
    public bool hasLiquids;
    public bool hasPower;
    public bool outputsLiquid;
    public bool consumesPower;
    public bool outputsPower;
    public bool outputsPayload;
    public bool outputFacing;
    public bool acceptsItems;
    public int itemCapacity;
    public float liquidCapacity;
    public float liquidPressure;
    internal BlockBars __\u003C\u003Ebars;
    internal Consumers __\u003C\u003Econsumes;
    public bool displayFlow;
    public bool inEditor;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public object lastConfig;
    public bool saveConfig;
    public bool copyConfig;
    public bool update;
    public bool destructible;
    public bool unloadable;
    public bool solid;
    public bool solidifes;
    public bool rotate;
    public bool saveData;
    public bool breakable;
    public bool rebuildable;
    public bool requiresWater;
    public bool placeableLiquid;
    public bool placeableOn;
    public bool insulated;
    public bool squareSprite;
    public bool absorbLasers;
    public bool enableDrawStatus;
    public bool drawDisabled;
    public bool autoResetEnabled;
    public bool noUpdateDisabled;
    public bool useColor;
    public int health;
    public float baseExplosiveness;
    public bool floating;
    public int size;
    public float offset;
    public bool expanded;
    public int timers;
    public CacheLayer cacheLayer;
    public bool fillsTile;
    public bool alwaysReplace;
    public bool replaceable;
    public BlockGroup group;
    [Signature("Larc/struct/EnumSet<Lmindustry/world/meta/BlockFlag;>;")]
    public EnumSet flags;
    public TargetPriority priority;
    public int unitCapModifier;
    public bool configurable;
    public bool logicConfigurable;
    public bool consumesTap;
    public bool drawLiquidLight;
    public bool sync;
    public bool conveyorPlacement;
    public bool swapDiagonalPlacement;
    public int schematicPriority;
    public Color mapColor;
    public bool hasColor;
    public bool targetable;
    public bool canOverdrive;
    public Color outlineColor;
    public bool outlineIcon;
    public int outlinedIcon;
    public bool hasShadow;
    public Sound breakSound;
    public float albedo;
    public Color lightColor;
    public bool emitLight;
    public float lightRadius;
    public Sound loopSound;
    public float loopSoundVolume;
    public Sound ambientSound;
    public float ambientSoundVolume;
    public ItemStack[] requirements;
    public Category category;
    public float buildCost;
    public BuildVisibility buildVisibility;
    public float buildCostMultiplier;
    public float deconstructThreshold;
    public float researchCostMultiplier;
    public bool instantTransfer;
    public bool quickRotate;
    [Signature("Ljava/lang/Class<*>;")]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Class subclass;
    [Signature("Larc/func/Prov<Lmindustry/gen/Building;>;")]
    public Prov buildType;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class<*>;Larc/func/Cons2;>;")]
    public ObjectMap configurations;
    protected internal TextureRegion[] generatedIcons;
    protected internal TextureRegion[] variantRegions;
    protected internal TextureRegion[] editorVariantRegions;
    public TextureRegion region;
    public TextureRegion editorIcon;
    public TextureRegion teamRegion;
    public TextureRegion[] teamRegions;
    [Signature("Larc/struct/Seq<Lmindustry/world/Tile;>;")]
    internal static Seq __\u003C\u003EtempTiles;
    [Signature("Larc/struct/Seq<Lmindustry/gen/Building;>;")]
    internal static Seq __\u003C\u003EtempTileEnts;
    internal int __\u003C\u003EtimerDump;
    internal int __\u003C\u003EdumpTime;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {161, 154, 107, 108, 140, 107, 107, 48, 38, 230, 70, 98, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void iterateTaken(int x, int y, Intc2 placer)
    {
      if (this.isMultiblock())
      {
        int num1 = -(this.size - 1) / 2;
        int num2 = -(this.size - 1) / 2;
        for (int index1 = 0; index1 < this.size; ++index1)
        {
          for (int index2 = 0; index2 < this.size; ++index2)
            placer.get(index1 + num1 + x, index2 + num2 + y);
        }
      }
      else
        placer.get(x, y);
    }

    [LineNumberTable(613)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor asFloor() => (Floor) this;

    [LineNumberTable(605)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isFloor() => this is Floor;

    [LineNumberTable(new byte[] {162, 31, 135, 104, 167, 135, 155, 127, 1, 131, 127, 1, 242, 74, 103, 180, 34, 161, 136, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void initBuilding()
    {
      try
      {
        Class superclass = Object.instancehelper_getClass((object) this);
        if (superclass.isAnonymousClass())
          superclass = superclass.getSuperclass();
        this.subclass = superclass;
        while (this.buildType == null)
        {
          if (((Class) ClassLiteral<Block>.Value).isAssignableFrom(superclass))
          {
            Class @class = (Class) Structs.find((object[]) superclass.getDeclaredClasses(Block.__\u003CGetCallerID\u003E()), (Boolf) new Block.__\u003C\u003EAnon13());
            if (@class != null)
              this.buildType = (Prov) new Block.__\u003C\u003EAnon14(this, @class.getDeclaredConstructor(new Class[1]
              {
                @class.getDeclaringClass(Block.__\u003CGetCallerID\u003E())
              }, Block.__\u003CGetCallerID\u003E()));
            superclass = superclass.getSuperclass();
          }
          else
            break;
        }
        goto label_11;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
label_11:
      if (this.buildType != null)
        return;
      this.buildType = (Prov) new Block.__\u003C\u003EAnon15();
    }

    [LineNumberTable(new byte[] {160, 153, 120, 109, 99, 255, 0, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPotentialLinks(int x, int y)
    {
      if (!this.consumesPower && !this.outputsPower || !this.hasPower)
        return;
      Tile tile = Vars.world.tile(x, y);
      if (tile == null)
        return;
      PowerNode.getNodeLinks(tile, this, Vars.player.team(), (Cons) new Block.__\u003C\u003EAnon1(this, tile, x, y));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool synthetic() => this.update || this.destructible;

    [LineNumberTable(621)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canBeBuilt() => !object.ReferenceEquals((object) this.buildVisibility, (object) BuildVisibility.__\u003C\u003Ehidden) && !object.ReferenceEquals((object) this.buildVisibility, (object) BuildVisibility.__\u003C\u003EdebugOnly);

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;ZF)V")]
    [LineNumberTable(new byte[] {159, 30, 98, 101, 127, 27, 104, 102, 114, 104, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPlan(BuildPlan req, Eachable list, bool valid, float alpha)
    {
      int num = valid ? 1 : 0;
      Draw.reset();
      Draw.mixcol(num != 0 ? Color.__\u003C\u003Ewhite : Pal.breakInvalid, (num != 0 ? 0.24f : 0.4f) + Mathf.absin(Time.globalTime, 6f, 0.28f));
      Draw.alpha(alpha);
      float scl = Draw.scl;
      Draw.scl *= req.animScale;
      this.drawRequestRegion(req, list);
      Draw.scl = scl;
      Draw.reset();
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [LineNumberTable(new byte[] {161, 90, 105, 159, 14, 127, 11, 127, 24, 127, 10, 165, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawRequestRegion(BuildPlan req, Eachable list)
    {
      Draw.rect(this.getRequestRegion(req, list), req.drawx(), req.drawy(), this.rotate ? (float) (req.rotation * 90) : 0.0f);
      if (req.worldContext && Vars.player != null && (this.teamRegion != null && this.teamRegion.found()))
      {
        if (object.ReferenceEquals((object) this.teamRegions[Vars.player.team().__\u003C\u003Eid], (object) this.teamRegion))
          Draw.color(Vars.player.team().__\u003C\u003Ecolor);
        Draw.rect(this.teamRegions[Vars.player.team().__\u003C\u003Eid], req.drawx(), req.drawy());
        Draw.color();
      }
      this.drawRequestConfig(req, list);
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)Larc/graphics/g2d/TextureRegion;")]
    [LineNumberTable(473)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion getRequestRegion(BuildPlan req, Eachable list) => this.icon(Cicon.__\u003C\u003Efull);

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawRequestConfig(BuildPlan req, Eachable list)
    {
    }

    [LineNumberTable(new byte[] {159, 22, 99, 99, 99, 152, 129, 127, 50, 133, 103, 116, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawRequestConfigCenter(
      BuildPlan req,
      object content,
      string region,
      bool cross)
    {
      int num = cross ? 1 : 0;
      if (content == null)
      {
        if (num == 0)
          return;
        Draw.rect(nameof (cross), req.drawx(), req.drawy());
      }
      else
      {
        object obj1 = content;
        Item obj2;
        Color color1;
        if (obj1 is Item && object.ReferenceEquals((object) (obj2 = (Item) obj1), (object) (Item) obj1))
        {
          color1 = obj2.color;
        }
        else
        {
          object obj3 = content;
          Liquid liquid;
          color1 = !(obj3 is Liquid) || !object.ReferenceEquals((object) (liquid = (Liquid) obj3), (object) (Liquid) obj3) ? (Color) null : liquid.color;
        }
        Color color2 = color1;
        if (color2 == null)
          return;
        Draw.color(color2);
        Draw.rect(region, req.drawx(), req.drawy());
        Draw.color();
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isMultiblock() => this.size > 1;

    [LineNumberTable(567)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion[] variantRegions()
    {
      if (this.variantRegions != null)
        return this.variantRegions;
      Block block = this;
      TextureRegion[] textureRegionArray1 = new TextureRegion[1]
      {
        this.icon(Cicon.__\u003C\u003Efull)
      };
      TextureRegion[] textureRegionArray2 = textureRegionArray1;
      this.variantRegions = textureRegionArray1;
      return textureRegionArray2;
    }

    [LineNumberTable(559)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual TextureRegion[] icons() => this.teamRegion.found() && this.minfo.mod == null ? new TextureRegion[2]
    {
      this.region,
      this.teamRegions[Team.__\u003C\u003Esharded.__\u003C\u003Eid]
    } : new TextureRegion[1]{ this.region };

    [LineNumberTable(791)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isHidden() => !this.buildVisibility.visible() && !Vars.state.rules.revealedBlocks.contains((object) this);

    [LineNumberTable(587)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isVisible() => !this.isHidden();

    [LineNumberTable(new byte[] {162, 16, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void requirements(Category cat, ItemStack[] stacks) => this.requirements(cat, BuildVisibility.__\u003C\u003Eshown, stacks);

    [LineNumberTable(new byte[] {162, 21, 103, 103, 135, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void requirements(Category cat, BuildVisibility visible, ItemStack[] stacks)
    {
      this.category = cat;
      this.requirements = stacks;
      this.buildVisibility = visible;
      Arrays.sort((object[]) this.requirements, Structs.comparingInt((Intf) new Block.__\u003C\u003EAnon11()));
    }

    [LineNumberTable(new byte[] {161, 11, 154, 139, 127, 10, 123, 108, 98, 139, 220, 117, 108, 103, 136, 222, 112, 187, 127, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBars()
    {
      this.__\u003C\u003Ebars.add("health", (Func) new Block.__\u003C\u003EAnon4());
      if (this.hasLiquids)
        this.__\u003C\u003Ebars.add("liquid", (Func) new Block.__\u003C\u003EAnon7(this, !this.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eliquid) || !(this.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid) is ConsumeLiquid) ? (Func) new Block.__\u003C\u003EAnon6() : (Func) new Block.__\u003C\u003EAnon5(((ConsumeLiquid) this.__\u003C\u003Econsumes.get(ConsumeType.__\u003C\u003Eliquid)).__\u003C\u003Eliquid)));
      if (this.hasPower && this.__\u003C\u003Econsumes.hasPower())
      {
        ConsumePower power = this.__\u003C\u003Econsumes.getPower();
        this.__\u003C\u003Ebars.add("power", (Func) new Block.__\u003C\u003EAnon8(power.__\u003C\u003Ebuffered, power.__\u003C\u003Ecapacity, power));
      }
      if (this.hasItems && this.configurable)
        this.__\u003C\u003Ebars.add("items", (Func) new Block.__\u003C\u003EAnon9(this));
      if (!this.flags.contains((Enum) BlockFlag.__\u003C\u003EunitModifier))
        return;
      this.stats.add(Stat.__\u003C\u003EmaxUnits, new StringBuilder().append(this.unitCapModifier >= 0 ? "+" : "-").append(Math.abs(this.unitCapModifier)).toString());
    }

    [LineNumberTable(563)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion[] getGeneratedIcons()
    {
      if (this.generatedIcons != null)
        return this.generatedIcons;
      Block block = this;
      TextureRegion[] textureRegionArray1 = this.icons();
      TextureRegion[] textureRegionArray2 = textureRegionArray1;
      this.generatedIcons = textureRegionArray1;
      return textureRegionArray2;
    }

    [Modifiers]
    [LineNumberTable(254)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024percentSolid\u00240([In] Tile obj0) => !obj0.floor().isLiquid ? 1f : 0.0f;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 157, 109, 119, 159, 37, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawPotentialLinks\u00241(
      [In] Tile obj0,
      [In] int obj1,
      [In] int obj2,
      [In] Building obj3)
    {
      PowerNode block = (PowerNode) obj3.block;
      Draw.color(block.laserColor1, Renderer.laserOpacity * 0.5f);
      block.drawLaser(obj0.team(), (float) (obj1 * 8) + this.offset, (float) (obj2 * 8) + this.offset, obj3.x, obj3.y, this.size, obj3.block.size);
      Drawf.square(obj3.x, obj3.y, (float) (obj3.block.size * 8) / 2f + 2f, Pal.place);
    }

    [Modifiers]
    [LineNumberTable(317)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024sumAttribute\u00242([In] mindustry.world.meta.Attribute obj0, [In] Tile obj1) => !this.floating && obj1.floor().isDeep() ? 0.0f : obj1.floor().attributes.get(obj0);

    [Modifiers]
    [LineNumberTable(381)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u00243([In] Building obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      Color health = Pal.health;
      Building building = obj0;
      Objects.requireNonNull((object) building);
      Floatp fraction = (Floatp) new Block.__\u003C\u003EAnon27(building);
      return new mindustry.ui.Bar("stat.health", health, fraction).blink(Color.__\u003C\u003Ewhite);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Liquid lambda\u0024setBars\u00244([In] Liquid obj0, [In] Building obj1) => obj0;

    [Modifiers]
    [LineNumberTable(389)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Liquid lambda\u0024setBars\u00245([In] Building obj0) => obj0.liquids == null ? Liquids.water : obj0.liquids.current();

    [Modifiers]
    [LineNumberTable(391)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u00249([In] Func obj0, [In] Building obj1)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new Block.__\u003C\u003EAnon24(obj1, obj0), (Prov) new Block.__\u003C\u003EAnon25(obj0, obj1), (Floatp) new Block.__\u003C\u003EAnon26(this, obj1, obj0));
    }

    [Modifiers]
    [LineNumberTable(400)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static mindustry.ui.Bar lambda\u0024setBars\u002413(
      [In] bool obj0,
      [In] float obj1,
      [In] ConsumePower obj2,
      [In] Building obj3)
    {
      int num = obj0 ? 1 : 0;
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new Block.__\u003C\u003EAnon21(num != 0, obj3, obj1), (Prov) new Block.__\u003C\u003EAnon22(), (Floatp) new Block.__\u003C\u003EAnon23(obj2, obj3));
    }

    [Modifiers]
    [LineNumberTable(405)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private mindustry.ui.Bar lambda\u0024setBars\u002417([In] Building obj0)
    {
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      return new mindustry.ui.Bar((Prov) new Block.__\u003C\u003EAnon18(obj0), (Prov) new Block.__\u003C\u003EAnon19(), (Floatp) new Block.__\u003C\u003EAnon20(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(510)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024configClear\u002418([In] Cons obj0, [In] object obj1, [In] object obj2) => obj0.get((object) (Building) obj1);

    [Modifiers]
    [LineNumberTable(651)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024requirements\u002419([In] ItemStack obj0) => (int) obj0.item.__\u003C\u003Eid;

    [Modifiers]
    [LineNumberTable(667)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024initBuilding\u002420([In] Class obj0) => ((Class) ClassLiteral<Building>.Value).isAssignableFrom(obj0) && !obj0.isInterface();

    [Modifiers]
    [LineNumberTable(new byte[] {162, 47, 127, 22, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Building lambda\u0024initBuilding\u002421([In] Constructor obj0)
    {
      Building building;
      Exception exception1;
      try
      {
        building = (Building) obj0.newInstance(new object[1]
        {
          (object) this
        }, Block.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return building;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 88, 137, 127, 0, 120, 45, 170, 127, 1, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024getDependencies\u002422([In] Cons obj0, [In] Consume obj1)
    {
      if (obj1.isOptional())
        return;
      Consume consume1 = obj1;
      ConsumeItems consumeItems;
      if (consume1 is ConsumeItems && object.ReferenceEquals((object) (consumeItems = (ConsumeItems) consume1), (object) (ConsumeItems) consume1))
      {
        ItemStack[] items = consumeItems.__\u003C\u003Eitems;
        int length = items.Length;
        for (int index = 0; index < length; ++index)
        {
          ItemStack itemStack = items[index];
          obj0.get((object) itemStack.item);
        }
      }
      else
      {
        Consume consume2 = obj1;
        ConsumeLiquid consumeLiquid;
        if (!(consume2 is ConsumeLiquid) || !object.ReferenceEquals((object) (consumeLiquid = (ConsumeLiquid) consume2), (object) (ConsumeLiquid) consume2))
          return;
        obj0.get((object) consumeLiquid.__\u003C\u003Eliquid);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 138, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024init\u002423([In] Class obj0, [In] Cons2 obj1)
    {
      if (!((Class) ClassLiteral<UnlockableContent>.Value).isAssignableFrom(obj0))
        return;
      this.logicConfigurable = true;
    }

    [Modifiers]
    [LineNumberTable(405)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u002414([In] Building obj0) => Core.bundle.format("bar.items", (object) Integer.valueOf(obj0.items.total()));

    [Modifiers]
    [LineNumberTable(405)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u002415() => Pal.items;

    [Modifiers]
    [LineNumberTable(405)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setBars\u002416([In] Building obj0) => (float) obj0.items.total() / (float) this.itemCapacity;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 42, 66, 127, 52, 47})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u002410([In] bool obj0, [In] Building obj1, [In] float obj2)
    {
      if (!obj0)
        return Core.bundle.get("bar.power");
      return Core.bundle.format("bar.poweramount", !Float.isNaN(obj1.power.status * obj2) ? (object) Integer.valueOf(ByteCodeHelper.f2i(obj1.power.status * obj2)) : (object) (Integer) "<ERROR>");
    }

    [Modifiers]
    [LineNumberTable(401)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u002411() => Pal.powerBar;

    [Modifiers]
    [LineNumberTable(401)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setBars\u002412([In] ConsumePower obj0, [In] Building obj1) => Mathf.zero(obj0.requestedPower(obj1)) && (double) (obj1.power.graph.getPowerProduced() + obj1.power.graph.getBatteryStored()) > 0.0 ? 1f : obj1.power.status;

    [Modifiers]
    [LineNumberTable(391)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setBars\u00246([In] Building obj0, [In] Func obj1) => (double) obj0.liquids.get((Liquid) obj1.get((object) obj0)) <= 1.0 / 1000.0 ? Core.bundle.get("bar.liquid") : ((UnlockableContent) obj1.get((object) obj0)).localizedName;

    [Modifiers]
    [LineNumberTable(392)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024setBars\u00247([In] Func obj0, [In] Building obj1) => ((Liquid) obj0.get((object) obj1)).barColor();

    [Modifiers]
    [LineNumberTable(392)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024setBars\u00248([In] Building obj0, [In] Func obj1) => obj0 == null || obj0.liquids == null ? 0.0f : obj0.liquids.get((Liquid) obj1.get((object) obj0)) / this.liquidCapacity;

    [LineNumberTable(new byte[] {160, 123, 233, 159, 63, 103, 103, 103, 103, 103, 135, 104, 107, 139, 107, 171, 135, 199, 135, 231, 70, 231, 76, 135, 135, 135, 135, 135, 135, 135, 135, 135, 135, 135, 135, 135, 139, 135, 135, 139, 135, 135, 139, 135, 135, 135, 139, 145, 171, 199, 199, 231, 72, 231, 69, 159, 0, 135, 135, 135, 144, 135, 135, 135, 139, 139, 208, 135, 171, 139, 171, 139, 171, 140, 203, 139, 139, 139, 139, 135, 199, 103, 235, 77, 153, 199, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Block(string name)
      : base(name)
    {
      Block block1 = this;
      this.outputsLiquid = false;
      this.consumesPower = true;
      this.outputsPower = false;
      this.outputsPayload = false;
      this.outputFacing = true;
      this.acceptsItems = false;
      this.itemCapacity = 10;
      this.liquidCapacity = 10f;
      this.liquidPressure = 1f;
      this.__\u003C\u003Ebars = new BlockBars();
      this.__\u003C\u003Econsumes = new Consumers();
      this.displayFlow = true;
      this.inEditor = true;
      this.saveConfig = false;
      this.copyConfig = true;
      this.unloadable = true;
      this.rebuildable = true;
      this.requiresWater = false;
      this.placeableLiquid = false;
      this.placeableOn = true;
      this.insulated = false;
      this.squareSprite = true;
      this.absorbLasers = false;
      this.enableDrawStatus = true;
      this.drawDisabled = true;
      this.autoResetEnabled = true;
      this.noUpdateDisabled = false;
      this.useColor = true;
      this.health = -1;
      this.baseExplosiveness = 0.0f;
      this.floating = false;
      this.size = 1;
      this.offset = 0.0f;
      this.expanded = false;
      this.timers = 0;
      this.cacheLayer = CacheLayer.__\u003C\u003Enormal;
      this.fillsTile = true;
      this.alwaysReplace = false;
      this.replaceable = true;
      this.group = BlockGroup.__\u003C\u003Enone;
      this.flags = EnumSet.of((Enum[]) new BlockFlag[0]);
      this.priority = TargetPriority.__\u003C\u003Ebase;
      this.unitCapModifier = 0;
      this.logicConfigurable = false;
      this.drawLiquidLight = true;
      this.schematicPriority = 0;
      this.mapColor = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.hasColor = false;
      this.targetable = true;
      this.canOverdrive = true;
      this.outlineColor = Color.valueOf("404049");
      this.outlineIcon = false;
      this.outlinedIcon = -1;
      this.hasShadow = true;
      this.breakSound = Sounds.boom;
      this.albedo = 0.0f;
      this.lightColor = Color.__\u003C\u003Ewhite.cpy();
      this.emitLight = false;
      this.lightRadius = 60f;
      this.loopSound = Sounds.none;
      this.loopSoundVolume = 0.5f;
      this.ambientSound = Sounds.none;
      this.ambientSoundVolume = 0.05f;
      this.requirements = new ItemStack[0];
      this.category = Category.__\u003C\u003Edistribution;
      this.buildVisibility = BuildVisibility.__\u003C\u003Ehidden;
      this.buildCostMultiplier = 1f;
      this.deconstructThreshold = 0.0f;
      this.researchCostMultiplier = 1f;
      this.instantTransfer = false;
      this.quickRotate = true;
      this.buildType = (Prov) null;
      this.configurations = new ObjectMap();
      Block block2 = this;
      int timers = block2.timers;
      Block block3 = block2;
      int num = timers;
      block3.timers = timers + 1;
      this.__\u003C\u003EtimerDump = num;
      this.__\u003C\u003EdumpTime = 5;
      this.initBuilding();
    }

    [LineNumberTable(new byte[] {160, 129, 104, 141, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBase(Tile tile)
    {
      if (tile.build != null)
        tile.build.draw();
      else
        Draw.rect(this.region, tile.drawx(), tile.drawy());
    }

    [LineNumberTable(new byte[] {160, 137, 109, 105, 118, 56})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float percentSolid(int x, int y)
    {
      Tile tile = Vars.world.tile(x, y);
      return tile == null ? 0.0f : tile.getLinkedTilesAs(this, Block.__\u003C\u003EtempTiles).sumf((Floatf) new Block.__\u003C\u003EAnon0()) / (float) this.size / (float) this.size;
    }

    [LineNumberTable(new byte[] {160, 144, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawEnvironmentLight(Tile tile) => Drawf.light(tile.worldx(), tile.worldy(), this.lightRadius, this.lightColor, this.lightColor.a);

    [LineNumberTable(new byte[] {160, 149, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPlace(int x, int y, int rotation, bool valid) => this.drawPotentialLinks(x, y);

    [LineNumberTable(new byte[] {159, 72, 131, 151, 112, 102, 122, 104, 103, 125, 154, 136, 103, 127, 22, 127, 27, 107, 111, 127, 26, 107, 159, 26, 104, 107, 112, 101, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float drawPlaceText(string text, int x, int y, bool valid)
    {
      int num1 = valid ? 1 : 0;
      if (Vars.renderer.__\u003C\u003Epixelator.enabled())
        return 0.0f;
      Color color = num1 == 0 ? Pal.remove : Pal.accent;
      Font outline = Fonts.outline;
      GlyphLayout glyphLayout1 = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new Block.__\u003C\u003EAnon2());
      int num2 = outline.usesIntegerPositions() ? 1 : 0;
      outline.setUseIntegerPositions(false);
      outline.getData().setScale(0.25f / Scl.scl(1f));
      GlyphLayout glyphLayout2 = glyphLayout1;
      Font font1 = outline;
      object obj1 = (object) text;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence str1 = charSequence;
      glyphLayout2.setText(font1, str1);
      float width = glyphLayout1.width;
      outline.setColor(color);
      float num3 = (float) (x * 8) + this.offset;
      float num4 = (float) (y * 8) + this.offset + (float) (this.size * 8) / 2f + 3f;
      Font font2 = outline;
      string str2 = text;
      double num5 = (double) num3;
      double num6 = (double) (num4 + glyphLayout1.height + 1f);
      int num7 = 1;
      float num8 = (float) num6;
      float num9 = (float) num5;
      object obj2 = (object) str2;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence str3 = charSequence;
      double num10 = (double) num9;
      double num11 = (double) num8;
      int halign = num7;
      font2.draw(str3, (float) num10, (float) num11, halign);
      float num12 = num4 - 1f;
      Lines.stroke(2f, Color.__\u003C\u003EdarkGray);
      Lines.line(num3 - glyphLayout1.width / 2f - 2f, num12, num3 + glyphLayout1.width / 2f + 1.5f, num12);
      Lines.stroke(1f, color);
      Lines.line(num3 - glyphLayout1.width / 2f - 2f, num12, num3 + glyphLayout1.width / 2f + 1.5f, num12);
      outline.setUseIntegerPositions(num2 != 0);
      outline.setColor(Color.__\u003C\u003Ewhite);
      outline.getData().setScale(1f);
      Draw.reset();
      Pools.free((object) glyphLayout1);
      return width;
    }

    [LineNumberTable(new byte[] {160, 199, 105, 109, 105, 120, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float sumAttribute([arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] mindustry.world.meta.Attribute attr, int x, int y)
    {
      if (attr == null)
        return 0.0f;
      Tile tile = Vars.world.tile(x, y);
      return tile == null ? 0.0f : tile.getLinkedTilesAs(this, Block.__\u003C\u003EtempTiles).sumf((Floatf) new Block.__\u003C\u003EAnon3(this, attr));
    }

    [LineNumberTable(321)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion getDisplayIcon(Tile tile) => tile.build == null ? this.icon(Cicon.__\u003C\u003Emedium) : tile.build.getDisplayIcon();

    [LineNumberTable(325)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getDisplayName(Tile tile) => tile.build == null ? this.localizedName : tile.build.getDisplayName();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int minimapColor(Tile tile) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool outputsItems() => this.hasItems;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canPlaceOn(Tile tile, Team team) => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canBreak(Tile tile) => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool rotatedOutput(int x, int y) => this.rotate;

    [LineNumberTable(new byte[] {160, 242, 134, 159, 24, 104, 188, 104, 127, 3, 188, 104, 186, 177, 127, 4, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003Esize, "@x@", (object) Integer.valueOf(this.size), (object) Integer.valueOf(this.size));
      if (this.synthetic())
        this.stats.add(Stat.__\u003C\u003Ehealth, (float) this.health, StatUnit.__\u003C\u003Enone);
      if (this.canBeBuilt())
      {
        this.stats.add(Stat.__\u003C\u003EbuildTime, this.buildCost / 60f, StatUnit.__\u003C\u003Eseconds);
        this.stats.add(Stat.__\u003C\u003EbuildCost, (StatValue) new ItemListValue(false, this.requirements));
      }
      if (this.instantTransfer)
        this.stats.add(Stat.__\u003C\u003EmaxConsecutive, 2f, StatUnit.__\u003C\u003Enone);
      this.__\u003C\u003Econsumes.display(this.stats);
      if (this.hasLiquids)
        this.stats.add(Stat.__\u003C\u003EliquidCapacity, this.liquidCapacity, StatUnit.__\u003C\u003EliquidUnits);
      if (!this.hasItems || this.itemCapacity <= 0)
        return;
      this.stats.add(Stat.__\u003C\u003EitemCapacity, (float) this.itemCapacity, StatUnit.__\u003C\u003Eitems);
    }

    [LineNumberTable(new byte[] {161, 42, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canReplace(Block other) => other.alwaysReplace || other.replaceable && (!object.ReferenceEquals((object) other, (object) this) || this.rotate) && (!object.ReferenceEquals((object) this.group, (object) BlockGroup.__\u003C\u003Enone) && object.ReferenceEquals((object) other.group, (object) this.group)) && (this.size == other.size || this.size >= other.size && (this.subclass != null && object.ReferenceEquals((object) this.subclass, (object) other.subclass) || this.group.__\u003C\u003EanyReplace));

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;)Lmindustry/world/Block;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block getReplacement(BuildPlan req, Seq requests) => this;

    [Signature("(Larc/struct/Seq<Larc/math/geom/Point2;>;I)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void changePlacementPath(Seq points, int rotation)
    {
    }

    [Signature("(Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handlePlacementLine(Seq plans)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object nextConfig() => this.saveConfig && this.lastConfig != null ? this.lastConfig : (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onNewPlan(BuildPlan plan)
    {
    }

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;Z)V")]
    [LineNumberTable(new byte[] {159, 31, 98, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPlan(BuildPlan req, Eachable list, bool valid)
    {
      int num = valid ? 1 : 0;
      this.drawPlan(req, list, num != 0, 1f);
    }

    [LineNumberTable(new byte[] {161, 126, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawRequestConfigCenter(BuildPlan req, object content, string region) => this.drawRequestConfigCenter(req, content, region, false);

    [Signature("(Lmindustry/entities/units/BuildPlan;Larc/util/Eachable<Lmindustry/entities/units/BuildPlan;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawRequestConfigTop(BuildPlan req, Eachable list)
    {
    }

    [Signature("(Ljava/lang/Object;Larc/func/Cons<Larc/math/geom/Point2;>;)Ljava/lang/Object;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object pointConfig(object config, Cons transformer) => config;

    [Signature("<E:Lmindustry/gen/Building;>(Larc/func/Cons<TE;>;)V")]
    [LineNumberTable(new byte[] {161, 140, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void configClear(Cons cons) => this.configurations.put((object) Void.TYPE, (object) new Block.__\u003C\u003EAnon10(cons));

    [Signature("<T:Ljava/lang/Object;E:Lmindustry/gen/Building;>(Ljava/lang/Class<TT;>;Larc/func/Cons2<TE;TT;>;)V")]
    [LineNumberTable(new byte[] {161, 145, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void config(Class type, Cons2 config) => this.configurations.put((object) type, (object) config);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAccessible() => this.hasItems && this.itemCapacity > 0;

    [LineNumberTable(541)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion editorIcon()
    {
      if (this.editorIcon != null)
        return this.editorIcon;
      Block block = this;
      TextureAtlas.AtlasRegion atlasRegion1 = Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-icon-editor").toString());
      TextureAtlas.AtlasRegion atlasRegion2 = atlasRegion1;
      this.editorIcon = (TextureRegion) atlasRegion1;
      return (TextureRegion) atlasRegion2;
    }

    [LineNumberTable(new byte[] {161, 176, 107, 103, 114, 108, 110, 31, 18, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion[] editorVariantRegions()
    {
      if (this.editorVariantRegions == null)
      {
        this.variantRegions();
        this.editorVariantRegions = new TextureRegion[this.variantRegions.Length];
        for (int index = 0; index < this.variantRegions.Length; ++index)
        {
          TextureAtlas.AtlasRegion variantRegion = (TextureAtlas.AtlasRegion) this.variantRegions[index];
          this.editorVariantRegions[index] = (TextureRegion) Core.atlas.find(new StringBuilder().append("editor-").append(variantRegion.name).toString());
        }
      }
      return this.editorVariantRegions;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasBuilding() => this.destructible || this.update;

    [LineNumberTable(575)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Building newBuilding() => (Building) this.buildType.get();

    [LineNumberTable(579)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect bounds(int x, int y, Rect rect) => rect.setSize((float) (this.size * 8)).setCenter((float) (x * 8) + this.offset, (float) (y * 8) + this.offset);

    [LineNumberTable(591)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPlaceable() => this.isVisible() && !Vars.state.rules.bannedBlocks.contains((object) this);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void placeBegan(Tile tile, Block previous)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beforePlaceBegan(Tile tile, Block previous)
    {
    }

    [LineNumberTable(609)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isOverlay() => this is OverlayFloor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAir() => this.__\u003C\u003Eid == (short) 0;

    [LineNumberTable(625)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isStatic() => object.ReferenceEquals((object) this.cacheLayer, (object) CacheLayer.__\u003C\u003Ewalls);

    [LineNumberTable(new byte[] {162, 3, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setupRequirements(Category cat, ItemStack[] stacks) => this.requirements(cat, stacks);

    [LineNumberTable(new byte[] {162, 7, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setupRequirements(
      Category cat,
      BuildVisibility visible,
      ItemStack[] stacks)
    {
      this.requirements(cat, visible, stacks);
    }

    [LineNumberTable(new byte[] {158, 239, 98, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void requirements(Category cat, ItemStack[] stacks, bool unlocked)
    {
      int num = unlocked ? 1 : 0;
      this.requirements(cat, BuildVisibility.__\u003C\u003Eshown, stacks);
      this.alwaysUnlocked = num != 0;
    }

    [LineNumberTable(new byte[] {162, 69, 109, 103, 159, 20, 255, 1, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ItemStack[] researchRequirements()
    {
      ItemStack[] itemStackArray1 = new ItemStack[this.requirements.Length];
      for (int index1 = 0; index1 < itemStackArray1.Length; ++index1)
      {
        int number = 60 + Mathf.round(Mathf.pow((float) this.requirements[index1].amount, 1.1f) * 20f * this.researchCostMultiplier, 10);
        ItemStack[] itemStackArray2 = itemStackArray1;
        int index2 = index1;
        ItemStack.__\u003Cclinit\u003E();
        ItemStack itemStack = new ItemStack(this.requirements[index1].item, UI.roundAmount(number));
        itemStackArray2[index2] = itemStack;
      }
      return itemStackArray1;
    }

    [Signature("(Larc/func/Cons<Lmindustry/ctype/UnlockableContent;>;)V")]
    [LineNumberTable(new byte[] {162, 82, 116, 44, 230, 69, 246, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void getDependencies(Cons cons)
    {
      ItemStack[] requirements = this.requirements;
      int length = requirements.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = requirements[index];
        cons.get((object) itemStack.item);
      }
      this.__\u003C\u003Econsumes.each((Cons) new Block.__\u003C\u003EAnon16(cons));
    }

    [LineNumberTable(728)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Eblock;

    [LineNumberTable(new byte[] {162, 110, 105, 182, 127, 23, 167, 159, 4, 107, 116, 63, 3, 166, 148, 121, 121, 153, 134, 140, 139, 104, 246, 71, 127, 8, 159, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      if (this.health == -1)
        this.health = this.size * this.size * 40;
      if (object.ReferenceEquals((object) this.group, (object) BlockGroup.__\u003C\u003Etransportation) || this.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eitem) || object.ReferenceEquals((object) this.category, (object) Category.__\u003C\u003Edistribution))
        this.acceptsItems = true;
      int num1 = this.size + 1;
      int num2 = 2;
      this.offset = (float) ((num2 != -1 ? num1 % num2 : 0) * 8) / 2f;
      this.buildCost = 0.0f;
      ItemStack[] requirements = this.requirements;
      int length = requirements.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = requirements[index];
        this.buildCost += (float) itemStack.amount * itemStack.item.cost;
      }
      this.buildCost *= this.buildCostMultiplier;
      if (this.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Epower))
        this.hasPower = true;
      if (this.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eitem))
        this.hasItems = true;
      if (this.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Eliquid))
        this.hasLiquids = true;
      this.setBars();
      this.stats.useCategories = true;
      this.__\u003C\u003Econsumes.init();
      if (!this.logicConfigurable)
        this.configurations.each((Cons2) new Block.__\u003C\u003EAnon17(this));
      if (!this.outputsPower && this.__\u003C\u003Econsumes.hasPower() && this.__\u003C\u003Econsumes.getPower().__\u003C\u003Ebuffered)
      {
        string str = new StringBuilder().append("Consumer using buffered power: ").append(this.__\u003C\u003Ename).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {162, 152, 150, 166, 113, 118, 63, 61, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load()
    {
      this.region = (TextureRegion) Core.atlas.find(this.__\u003C\u003Ename);
      ContentRegions.loadRegions((MappableContent) this);
      this.teamRegions = new TextureRegion[Team.__\u003C\u003Eall.Length];
      Team[] all = Team.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        Team team = all[index];
        this.teamRegions[team.__\u003C\u003Eid] = !this.teamRegion.found() ? this.teamRegion : Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-team-").append(team.name).toString(), this.teamRegion);
      }
    }

    [LineNumberTable(new byte[] {162, 170, 135, 159, 37, 104, 123, 191, 3, 135, 130, 107, 98, 127, 13, 114, 103, 112, 144, 109, 108, 113, 131, 108, 108, 127, 51, 99, 226, 61, 43, 235, 72, 100, 240, 48, 43, 235, 86, 130, 178, 109, 121, 110, 112, 138, 250, 60, 232, 71, 127, 23, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void createIcons(MultiPacker packer)
    {
      base.createIcons(packer);
      packer.add(MultiPacker.PageType.__\u003C\u003Eeditor, new StringBuilder().append(this.__\u003C\u003Ename).append("-icon-editor").toString(), Core.atlas.getPixmap((TextureAtlas.AtlasRegion) this.icon(Cicon.__\u003C\u003Efull)));
      if (!this.synthetic())
      {
        PixmapRegion pixmap = Core.atlas.getPixmap((TextureAtlas.AtlasRegion) this.icon(Cicon.__\u003C\u003Efull));
        this.mapColor.set(pixmap.getPixel(pixmap.width / 2, pixmap.height / 2));
      }
      this.getGeneratedIcons();
      Pixmap pixmap1 = (Pixmap) null;
      if (this.outlineIcon)
      {
        PixmapRegion pixmap2 = Core.atlas.getPixmap(this.getGeneratedIcons()[this.outlinedIcon < 0 ? this.getGeneratedIcons().Length - 1 : this.outlinedIcon]);
        Pixmap pix = new Pixmap(pixmap2.width, pixmap2.height);
        Color color = new Color();
        for (int x = 0; x < pixmap2.width; ++x)
        {
          for (int y = 0; y < pixmap2.height; ++y)
          {
            pixmap2.getPixel(x, y, color);
            pix.draw(x, y, color);
            if ((double) color.a < 1.0)
            {
              int num = 0;
              for (int index1 = -4; index1 <= 4; ++index1)
              {
                for (int index2 = -4; index2 <= 4; ++index2)
                {
                  if (Structs.inBounds(index1 + x, index2 + y, pixmap2.width, pixmap2.height) && Mathf.within((float) index1, (float) index2, 4f) && (double) color.set(pixmap2.getPixel(index1 + x, index2 + y)).a > 0.00999999977648258)
                  {
                    num = 1;
                    goto label_16;
                  }
                }
              }
label_16:
              if (num != 0)
                pix.draw(x, y, this.outlineColor);
            }
          }
        }
        pixmap1 = pix;
        packer.add(MultiPacker.PageType.__\u003C\u003Emain, this.__\u003C\u003Ename, pix);
      }
      if (this.generatedIcons.Length <= 1)
        return;
      Pixmap pix1 = Core.atlas.getPixmap(this.generatedIcons[0]).crop();
      for (int index = 1; index < this.generatedIcons.Length; ++index)
      {
        if (index == this.generatedIcons.Length - 1 && pixmap1 != null)
          pix1.drawPixmap(pixmap1);
        else
          pix1.draw(Core.atlas.getPixmap(this.generatedIcons[index]));
      }
      packer.add(MultiPacker.PageType.__\u003C\u003Emain, new StringBuilder().append("block-").append(this.__\u003C\u003Ename).append("-full").toString(), pix1);
      this.generatedIcons = (TextureRegion[]) null;
      Arrays.fill((object[]) this.cicons, (object) null);
    }

    [LineNumberTable(new byte[] {159, 85, 77, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Block()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.Block"))
        return;
      Block.__\u003C\u003EtempTiles = new Seq();
      Block.__\u003C\u003EtempTileEnts = new Seq();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Block.__\u003CcallerID\u003E == null)
        Block.__\u003CcallerID\u003E = (CallerID) new Block.__\u003CCallerID\u003E();
      return Block.__\u003CcallerID\u003E;
    }

    [Modifiers]
    public BlockBars bars
    {
      [HideFromJava] get => this.__\u003C\u003Ebars;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebars = value;
    }

    [Modifiers]
    public Consumers consumes
    {
      [HideFromJava] get => this.__\u003C\u003Econsumes;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Econsumes = value;
    }

    [Modifiers]
    protected internal static Seq tempTiles
    {
      [HideFromJava] get => Block.__\u003C\u003EtempTiles;
    }

    [Modifiers]
    protected internal static Seq tempTileEnts
    {
      [HideFromJava] get => Block.__\u003C\u003EtempTileEnts;
    }

    [Modifiers]
    protected internal int timerDump
    {
      [HideFromJava] get => this.__\u003C\u003EtimerDump;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerDump = value;
    }

    [Modifiers]
    protected internal int dumpTime
    {
      [HideFromJava] get => this.__\u003C\u003EdumpTime;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EdumpTime = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public float get([In] object obj0) => Block.lambda\u0024percentSolid\u00240((Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Block arg\u00241;
      private readonly Tile arg\u00242;
      private readonly int arg\u00243;
      private readonly int arg\u00244;

      internal __\u003C\u003EAnon1([In] Block obj0, [In] Tile obj1, [In] int obj2, [In] int obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawPotentialLinks\u00241(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new GlyphLayout();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatf
    {
      private readonly Block arg\u00241;
      private readonly mindustry.world.meta.Attribute arg\u00242;

      internal __\u003C\u003EAnon3([In] Block obj0, [In] mindustry.world.meta.Attribute obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get([In] object obj0) => this.arg\u00241.lambda\u0024sumAttribute\u00242(this.arg\u00242, (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Func
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get([In] object obj0) => (object) Block.lambda\u0024setBars\u00243((Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Func
    {
      private readonly Liquid arg\u00241;

      internal __\u003C\u003EAnon5([In] Liquid obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) Block.lambda\u0024setBars\u00244(this.arg\u00241, (Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Func
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public object get([In] object obj0) => (object) Block.lambda\u0024setBars\u00245((Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Func
    {
      private readonly Block arg\u00241;
      private readonly Func arg\u00242;

      internal __\u003C\u003EAnon7([In] Block obj0, [In] Func obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u00249(this.arg\u00242, (Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Func
    {
      private readonly bool arg\u00241;
      private readonly float arg\u00242;
      private readonly ConsumePower arg\u00243;

      internal __\u003C\u003EAnon8([In] bool obj0, [In] float obj1, [In] ConsumePower obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public object get([In] object obj0) => (object) Block.lambda\u0024setBars\u002413(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Func
    {
      private readonly Block arg\u00241;

      internal __\u003C\u003EAnon9([In] Block obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024setBars\u002417((Building) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons2
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon10([In] Cons obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => Block.lambda\u0024configClear\u002418(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Intf
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public int get([In] object obj0) => Block.lambda\u0024requirements\u002419((ItemStack) obj0);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Boolf
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public bool get([In] object obj0) => (Block.lambda\u0024initBuilding\u002420((Class) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Prov
    {
      private readonly Block arg\u00241;
      private readonly Constructor arg\u00242;

      internal __\u003C\u003EAnon14([In] Block obj0, [In] Constructor obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024initBuilding\u002421(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Prov
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public object get() => (object) Building.create();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Cons
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon16([In] Cons obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Block.lambda\u0024getDependencies\u002422(this.arg\u00241, (Consume) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons2
    {
      private readonly Block arg\u00241;

      internal __\u003C\u003EAnon17([In] Block obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024init\u002423((Class) obj0, (Cons2) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Prov
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon18([In] Building obj0) => this.arg\u00241 = obj0;

      public object get() => (object) Block.lambda\u0024setBars\u002414(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Prov
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public object get() => (object) Block.lambda\u0024setBars\u002415();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Floatp
    {
      private readonly Block arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon20([In] Block obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => this.arg\u00241.lambda\u0024setBars\u002416(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Prov
    {
      private readonly bool arg\u00241;
      private readonly Building arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon21([In] bool obj0, [In] Building obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public object get() => (object) Block.lambda\u0024setBars\u002410(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Prov
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public object get() => (object) Block.lambda\u0024setBars\u002411();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Floatp
    {
      private readonly ConsumePower arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon23([In] ConsumePower obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public float get() => Block.lambda\u0024setBars\u002412(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Prov
    {
      private readonly Building arg\u00241;
      private readonly Func arg\u00242;

      internal __\u003C\u003EAnon24([In] Building obj0, [In] Func obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) Block.lambda\u0024setBars\u00246(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Prov
    {
      private readonly Func arg\u00241;
      private readonly Building arg\u00242;

      internal __\u003C\u003EAnon25([In] Func obj0, [In] Building obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) Block.lambda\u0024setBars\u00247(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Floatp
    {
      private readonly Block arg\u00241;
      private readonly Building arg\u00242;
      private readonly Func arg\u00243;

      internal __\u003C\u003EAnon26([In] Block obj0, [In] Building obj1, [In] Func obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public float get() => this.arg\u00241.lambda\u0024setBars\u00248(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Floatp
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon27([In] Building obj0) => this.arg\u00241 = obj0;

      public float get() => this.arg\u00241.healthf();
    }
  }
}
