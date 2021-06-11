// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.MenuRenderer
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
using arc.scene.ui.layout;
using arc.util;
using arc.util.noise;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.type;
using mindustry.ui;
using mindustry.world;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class MenuRenderer : Object, Disposable
  {
    private const float darkness = 0.3f;
    [Modifiers]
    private int width;
    [Modifiers]
    private int height;
    private int cacheFloor;
    private int cacheWall;
    private Camera camera;
    private Mat mat;
    private FrameBuffer shadows;
    private CacheBatch batch;
    private float time;
    private float flyerRot;
    private int flyers;
    private UnitType flyerType;

    [LineNumberTable(new byte[] {159, 185, 106, 119, 122, 119, 107, 104, 107, 107, 107, 255, 160, 98, 73, 255, 160, 73, 73, 109, 105, 141, 115, 115, 112, 112, 112, 132, 108, 140, 112, 112, 100, 103, 135, 127, 20, 164, 127, 21, 100, 110, 196, 127, 14, 164, 127, 20, 164, 103, 127, 19, 139, 102, 103, 103, 135, 113, 135, 113, 231, 70, 103, 127, 1, 126, 127, 47, 103, 127, 10, 199, 126, 231, 69, 100, 122, 158, 110, 231, 70, 114, 106, 106, 110, 105, 233, 159, 181, 43, 235, 160, 80, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void generate()
    {
      Vars.world.beginMapLoad();
      Tiles tiles = Vars.world.resize(this.width, this.height);
      Seq seq = Vars.content.blocks().select((Boolf) new MenuRenderer.__\u003C\u003EAnon0());
      this.shadows = new FrameBuffer(this.width, this.height);
      int num1 = Mathf.random(100000);
      Simplex simplex1 = new Simplex((long) num1);
      Simplex simplex2 = new Simplex((long) (num1 + 1));
      Simplex simplex3 = new Simplex((long) (num1 + 2));
      RidgedPerlin ridgedPerlin = new RidgedPerlin(1 + num1, 1);
      Block[] blockArray1 = (Block[]) Structs.select((object[]) new Block[7][]
      {
        new Block[2]{ Blocks.sand, Blocks.sandWall },
        new Block[2]{ Blocks.shale, Blocks.shaleWall },
        new Block[2]{ Blocks.ice, Blocks.iceWall },
        new Block[2]{ Blocks.sand, Blocks.sandWall },
        new Block[2]{ Blocks.shale, Blocks.shaleWall },
        new Block[2]{ Blocks.ice, Blocks.iceWall },
        new Block[2]{ Blocks.moss, Blocks.sporePine }
      });
      Block[] blockArray2 = (Block[]) Structs.select((object[]) new Block[6][]
      {
        new Block[2]{ Blocks.basalt, Blocks.duneWall },
        new Block[2]{ Blocks.basalt, Blocks.duneWall },
        new Block[2]{ Blocks.stone, Blocks.stoneWall },
        new Block[2]{ Blocks.stone, Blocks.stoneWall },
        new Block[2]{ Blocks.moss, Blocks.sporeWall },
        new Block[2]{ Blocks.salt, Blocks.saltWall }
      });
      Block block1 = (Block) seq.random();
      seq.remove((object) block1);
      Block block2 = (Block) seq.random();
      double num2 = (double) Mathf.random(0.65f, 0.85f);
      double num3 = (double) Mathf.random(0.65f, 0.85f);
      int num4 = Mathf.chance(0.25) ? 1 : 0;
      int num5 = Mathf.chance(0.25) ? 1 : 0;
      int num6 = Mathf.chance(0.25) ? 1 : 0;
      int num7 = 10;
      Block block3 = blockArray1[0];
      Block block4 = blockArray1[1];
      Block block5 = blockArray2[0];
      Block block6 = blockArray2[1];
      for (int x = 0; x < this.width; ++x)
      {
        for (int y = 0; y < this.height; ++y)
        {
          Block block7 = block3;
          Block block8 = Blocks.air;
          Block type = Blocks.air;
          if (simplex1.octaveNoise2D(3.0, 0.5, 0.05, (double) x, (double) y) > 0.5)
            type = block4;
          if (simplex3.octaveNoise2D(3.0, 0.5, 0.05, (double) x, (double) y) > 0.5)
          {
            block7 = block5;
            if (!object.ReferenceEquals((object) type, (object) Blocks.air))
              type = block6;
          }
          if (simplex2.octaveNoise2D(3.0, 0.3, 1.0 / 30.0, (double) x, (double) y) > num2)
            block8 = block1;
          if (simplex2.octaveNoise2D(2.0, 0.2, 1.0 / 15.0, (double) x, (double) (y + 99999)) > num3)
            block8 = block2;
          if (num4 != 0)
          {
            double num8 = simplex3.octaveNoise2D(4.0, 0.6, 0.02, (double) x, (double) (y + 9999));
            double num9 = 0.65;
            if (num8 > num9)
            {
              block8 = Blocks.air;
              type = Blocks.air;
              block7 = Blocks.basalt;
              if (num8 > num9 + 0.1)
              {
                block7 = Blocks.hotrock;
                if (num8 > num9 + 0.15)
                  block7 = Blocks.magmarock;
              }
            }
          }
          if (num6 != 0)
          {
            int num8 = x;
            int num9 = num7;
            int num10 = num9 != -1 ? num8 % num9 : 0;
            int num11 = y;
            int num12 = num7;
            int num13 = num12 != -1 ? num11 % num12 : 0;
            int num14 = x;
            int num15 = num7;
            int num16 = num15 != -1 ? num14 / num15 : -num14;
            int num17 = y;
            int num18 = num7;
            int num19 = num18 != -1 ? num17 / num18 : -num17;
            if (simplex1.octaveNoise2D(2.0, 0.100000001490116, 0.5, (double) num16, (double) num19) > 0.400000005960464 && (num10 == 0 || num13 == 0 || (num10 == num7 - 1 || num13 == num7 - 1)))
            {
              block7 = Blocks.darkPanel3;
              if ((double) Mathf.dst((float) num10, (float) num13, (float) (num7 / 2), (float) (num7 / 2)) > (double) ((float) num7 / 2f + 1f))
                block7 = Blocks.darkPanel4;
              if (!object.ReferenceEquals((object) type, (object) Blocks.air) && Mathf.chance(0.7))
                type = Blocks.darkMetal;
            }
          }
          if (num5 != 0 && (double) ridgedPerlin.getValue((double) x, (double) y, 0.05882353f) > 0.0)
          {
            block7 = !Mathf.chance(0.2) ? Blocks.moss : Blocks.sporeMoss;
            if (!object.ReferenceEquals((object) type, (object) Blocks.air))
              type = Blocks.sporeWall;
          }
          CachedTile cachedTile;
          tiles.set(x, y, (Tile) (cachedTile = new CachedTile()));
          cachedTile.x = (short) x;
          cachedTile.y = (short) y;
          cachedTile.setFloor(block7.asFloor());
          cachedTile.setBlock(type);
          cachedTile.setOverlay(block8);
        }
      }
      Vars.world.endMapLoad();
    }

    [LineNumberTable(new byte[] {120, 127, 14, 112, 138, 127, 5, 114, 159, 12, 130, 101, 139, 134, 127, 16, 139, 127, 9, 110, 130, 127, 9, 110, 130, 113, 139, 127, 9, 110, 130, 145, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void cache()
    {
      Draw.proj().setOrtho(0.0f, 0.0f, (float) this.shadows.getWidth(), (float) this.shadows.getHeight());
      this.shadows.begin(Color.__\u003C\u003Eclear);
      Draw.color(Color.__\u003C\u003Eblack);
      Iterator iterator1 = Vars.world.tiles.iterator();
      while (iterator1.hasNext())
      {
        Tile tile = (Tile) iterator1.next();
        if (!object.ReferenceEquals((object) tile.block(), (object) Blocks.air))
          Fill.rect((float) tile.x + 0.5f, (float) tile.y + 0.5f, 1f, 1f);
      }
      Draw.color();
      this.shadows.end();
      Batch batch = Core.batch;
      MenuRenderer menuRenderer = this;
      SpriteCache.__\u003Cclinit\u003E();
      CacheBatch cacheBatch1 = new CacheBatch(new SpriteCache(this.width * this.height * 6, false));
      CacheBatch cacheBatch2 = cacheBatch1;
      this.batch = cacheBatch1;
      Core.batch = (Batch) cacheBatch2;
      this.batch.beginCache();
      Iterator iterator2 = Vars.world.tiles.iterator();
      while (iterator2.hasNext())
      {
        Tile tile = (Tile) iterator2.next();
        tile.floor().drawBase(tile);
      }
      Iterator iterator3 = Vars.world.tiles.iterator();
      while (iterator3.hasNext())
      {
        Tile tile = (Tile) iterator3.next();
        tile.overlay().drawBase(tile);
      }
      this.cacheFloor = this.batch.endCache();
      this.batch.beginCache();
      Iterator iterator4 = Vars.world.tiles.iterator();
      while (iterator4.hasNext())
      {
        Tile tile = (Tile) iterator4.next();
        tile.block().drawBase(tile);
      }
      this.cacheWall = this.batch.endCache();
      Core.batch = batch;
    }

    [LineNumberTable(new byte[] {160, 126, 153, 145, 159, 2, 210, 177, 133, 242, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void drawFlyers()
    {
      Draw.color(0.0f, 0.0f, 0.0f, 0.4f);
      TextureRegion textureRegion = this.flyerType.icon(Cicon.__\u003C\u003Efull);
      float num = (float) Math.max(textureRegion.width, textureRegion.height) * Draw.scl * 1.6f;
      this.flyers((Floatc2) new MenuRenderer.__\u003C\u003EAnon1(this, textureRegion));
      this.flyers((Floatc2) new MenuRenderer.__\u003C\u003EAnon2(num));
      Draw.color();
      this.flyers((Floatc2) new MenuRenderer.__\u003C\u003EAnon3(this, textureRegion));
    }

    [LineNumberTable(new byte[] {160, 158, 120, 120, 102, 134, 112, 159, 12, 127, 65, 63, 35, 229, 61, 235, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void flyers([In] Floatc2 obj0)
    {
      float num1 = (float) (this.width * 8) * 1f + 8f;
      float num2 = (float) (this.height * 8) * 1f + 8f;
      float range = 500f;
      float num3 = -100f;
      for (int index = 0; index < this.flyers; ++index)
      {
        Tmp.__\u003C\u003Ev1.trns(this.flyerRot, this.time * (2f + this.flyerType.speed));
        obj0.get((Mathf.randomSeedRange((long) index, range) + Tmp.__\u003C\u003Ev1.x + Mathf.absin(this.time + Mathf.randomSeedRange((long) (index + 2), 500f), 10f, 3.4f) + num3) % (num1 + (float) Mathf.randomSeed((long) (index + 5), 0, 500)), (Mathf.randomSeedRange((long) (index + 1), range) + Tmp.__\u003C\u003Ev1.y + Mathf.absin(this.time + Mathf.randomSeedRange((long) (index + 3), 500f), 10f, 3.4f) + num3) % num2);
      }
    }

    [Modifiers]
    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024generate\u00240([In] Block obj0) => obj0 is OreBlock;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 133, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawFlyers\u00241([In] TextureRegion obj0, [In] float obj1, [In] float obj2) => Draw.rect(obj0, obj1 - 12f, obj2 - 13f, this.flyerRot - 90f);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 137, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024drawFlyers\u00242([In] float obj0, [In] float obj1, [In] float obj2) => Draw.rect("circle-shadow", obj1, obj2, obj0, obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 142, 159, 0, 106, 127, 26, 40, 165, 106, 127, 40, 47, 133, 133, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawFlyers\u00243([In] TextureRegion obj0, [In] float obj1, [In] float obj2)
    {
      float engineOffset = this.flyerType.engineOffset;
      float engineSize = this.flyerType.engineSize;
      float flyerRot = this.flyerRot;
      Draw.color(Pal.engine);
      Fill.circle(obj1 + Angles.trnsx(flyerRot + 180f, engineOffset), obj2 + Angles.trnsy(flyerRot + 180f, engineOffset), engineSize + Mathf.absin(Time.time, 2f, engineSize / 4f));
      Draw.color(Color.__\u003C\u003Ewhite);
      Fill.circle(obj1 + Angles.trnsx(flyerRot + 180f, engineOffset - 1f), obj2 + Angles.trnsy(flyerRot + 180f, engineOffset - 1f), (engineSize + Mathf.absin(Time.time, 2f, engineSize / 4f)) / 2f);
      Draw.color();
      Draw.rect(obj0, obj1, obj2, this.flyerRot - 90f);
    }

    [LineNumberTable(new byte[] {159, 177, 232, 52, 191, 7, 107, 171, 107, 107, 127, 7, 191, 47, 101, 102, 102, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MenuRenderer()
    {
      MenuRenderer menuRenderer = this;
      this.width = Vars.mobile ? 60 : 100;
      this.height = Vars.mobile ? 40 : 50;
      this.camera = new Camera();
      this.mat = new Mat();
      this.time = 0.0f;
      this.flyerRot = 45f;
      this.flyers = !Mathf.chance(0.2) ? Mathf.random(15) : Mathf.random(35);
      this.flyerType = (UnitType) Structs.select((object[]) new UnitType[7]
      {
        UnitTypes.flare,
        UnitTypes.flare,
        UnitTypes.horizon,
        UnitTypes.mono,
        UnitTypes.poly,
        UnitTypes.mega,
        UnitTypes.zenith
      });
      Time.mark();
      this.generate();
      this.cache();
      Log.debug("Time to generate menu: @", (object) Float.valueOf(Time.elapsed()));
    }

    [LineNumberTable(new byte[] {160, 95, 115, 127, 61, 127, 18, 121, 41, 165, 113, 101, 107, 118, 107, 113, 107, 101, 191, 60, 101, 107, 113, 139, 134, 107, 121, 127, 6, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render()
    {
      this.time += Time.delta;
      float num = Math.max(Scl.scl(4f), Math.max((float) Core.graphics.getWidth() / (((float) this.width - 1f) * 8f), (float) Core.graphics.getHeight() / (((float) this.height - 1f) * 8f)));
      this.camera.__\u003C\u003Eposition.set((float) (this.width * 8) / 2f, (float) (this.height * 8) / 2f);
      this.camera.resize((float) Core.graphics.getWidth() / num, (float) Core.graphics.getHeight() / num);
      this.mat.set(Draw.proj());
      Draw.flush();
      Draw.proj(this.camera);
      this.batch.setProjection(this.camera.__\u003C\u003Emat);
      this.batch.beginDraw();
      this.batch.drawCache(this.cacheFloor);
      this.batch.endDraw();
      Draw.color();
      Draw.rect(Draw.wrap((Texture) this.shadows.getTexture()), (float) (this.width * 8) / 2f - 4f, (float) (this.height * 8) / 2f - 4f, (float) (this.width * 8), (float) (-this.height * 8));
      Draw.flush();
      this.batch.beginDraw();
      this.batch.drawCache(this.cacheWall);
      this.batch.endDraw();
      this.drawFlyers();
      Draw.proj(this.mat);
      Draw.color(0.0f, 0.0f, 0.0f, 0.3f);
      Fill.crect(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      Draw.color();
    }

    [LineNumberTable(new byte[] {160, 173, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.batch.dispose();
      this.shadows.dispose();
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (MenuRenderer.lambda\u0024generate\u00240((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatc2
    {
      private readonly MenuRenderer arg\u00241;
      private readonly TextureRegion arg\u00242;

      internal __\u003C\u003EAnon1([In] MenuRenderer obj0, [In] TextureRegion obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] float obj0, [In] float obj1) => this.arg\u00241.lambda\u0024drawFlyers\u00241(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatc2
    {
      private readonly float arg\u00241;

      internal __\u003C\u003EAnon2([In] float obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0, [In] float obj1) => MenuRenderer.lambda\u0024drawFlyers\u00242(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatc2
    {
      private readonly MenuRenderer arg\u00241;
      private readonly TextureRegion arg\u00242;

      internal __\u003C\u003EAnon3([In] MenuRenderer obj0, [In] TextureRegion obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] float obj0, [In] float obj1) => this.arg\u00241.lambda\u0024drawFlyers\u00243(this.arg\u00242, obj0, obj1);
    }
  }
}
