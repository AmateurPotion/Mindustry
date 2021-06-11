// Decompiled with JetBrains decompiler
// Type: mindustry.core.World
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.noise;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.io;
using mindustry.maps;
using mindustry.maps.filters;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.legacy;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  public class World : Object
  {
    internal World.Context __\u003C\u003Econtext;
    public Tiles tiles;
    private bool generating;
    private bool invalidMap;
    [Signature("Larc/struct/ObjectMap<Lmindustry/maps/Map;Ljava/lang/Runnable;>;")]
    private ObjectMap customMapLoaders;

    [LineNumberTable(new byte[] {159, 181, 232, 57, 140, 173, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public World()
    {
      World world = this;
      this.__\u003C\u003Econtext = new World.Context(this);
      this.tiles = new Tiles(0, 0);
      this.customMapLoaders = new ObjectMap();
    }

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int width() => this.tiles.__\u003C\u003Ewidth;

    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int height() => this.tiles.__\u003C\u003Eheight;

    [LineNumberTable(111)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tile(int x, int y) => this.tiles.get(x, y);

    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toTile(float coord) => Math.round(coord / 8f);

    [LineNumberTable(new byte[] {76, 105, 101})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building build(int x, int y) => this.tile(x, y)?.build;

    [LineNumberTable(139)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile rawTile(int x, int y) => this.tiles.getn(x, y);

    [LineNumberTable(106)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tile(int pos) => this.tile((int) Point2.x(pos), (int) Point2.y(pos));

    [LineNumberTable(new byte[] {3, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool solid(int x, int y)
    {
      Tile tile = this.tile(x, y);
      return tile == null || tile.solid();
    }

    [LineNumberTable(new byte[] {161, 66, 98, 98, 105, 138, 106, 139, 165, 109, 139, 102, 102, 102, 165, 101, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool raycast(int x0f, int y0f, int x1, int y1, Geometry.Raycaster cons)
    {
      int i1 = x0f;
      int i2 = y0f;
      int num1 = Math.abs(x1 - i1);
      int num2 = Math.abs(y1 - i2);
      int num3 = i1 >= x1 ? -1 : 1;
      int num4 = i2 >= y1 ? -1 : 1;
      int num5 = num1 - num2;
      while (!cons.accept(i1, i2))
      {
        if (i1 == x1 && i2 == y1)
          return false;
        int num6 = 2 * num5;
        if (num6 > -num2)
        {
          num5 -= num2;
          i1 += num3;
        }
        if (num6 < num1)
        {
          num5 += num1;
          i2 += num4;
        }
      }
      return true;
    }

    [LineNumberTable(223)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect getQuadBounds(Rect @in) => @in.set(-500f, -500f, (float) (Vars.world.width() * 8) + 1000f, (float) (Vars.world.height() * 8) + 1000f);

    [LineNumberTable(new byte[] {83, 104, 101})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building build(int pos) => this.tile(pos)?.build;

    [LineNumberTable(144)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileWorld(float x, float y) => this.tile(Math.round(x / 8f), Math.round(y / 8f));

    [LineNumberTable(149)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building buildWorld(float x, float y) => this.build(Math.round(x / 8f), Math.round(y / 8f));

    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int unitWidth() => this.width() * 8;

    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int unitHeight() => this.height() * 8;

    [LineNumberTable(new byte[] {160, 130, 135, 103, 243, 76, 104, 214, 135, 118, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadSector(Sector sector)
    {
      this.setSectorRules(sector);
      int size = sector.getSize();
      this.loadGenerator(size, size, (Cons) new World.__\u003C\u003EAnon0(sector));
      if (sector.preset == null)
        sector.__\u003C\u003Eplanet.generator.postGenerate(this.tiles);
      this.setSectorRules(sector);
      if (Vars.state.rules.defaultTeam.core() == null)
        return;
      sector.info.spawnPosition = Vars.state.rules.defaultTeam.core().pos();
    }

    [LineNumberTable(new byte[] {160, 234, 110, 118, 193, 255, 5, 74, 226, 55, 97, 102, 103, 111, 116, 135, 103, 161, 139, 135, 106, 126, 111, 108, 104, 127, 5, 103, 148, 107, 127, 10, 104, 209, 159, 11, 104, 209, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadMap(Map map, Rules checkRules)
    {
      if (this.customMapLoaders.containsKey((object) map))
      {
        ((Runnable) this.customMapLoaders.get((object) map)).run();
      }
      else
      {
        Exception th;
        try
        {
          SaveIO.load(map.__\u003C\u003Efile, (WorldContext) new World.FilterContext(this, map));
          goto label_8;
        }
        catch (Exception ex)
        {
          th = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Log.err(th);
        if (!Vars.headless)
        {
          Vars.ui.showErrorMessage("@map.invalid");
          Core.app.post((Runnable) new World.__\u003C\u003EAnon5());
          this.invalidMap = true;
        }
        this.generating = false;
        return;
label_8:
        Vars.state.map = map;
        this.invalidMap = false;
        if (!Vars.headless)
        {
          if (Vars.state.teams.playerCores().size == 0 && !checkRules.pvp)
          {
            Vars.ui.showErrorMessage("@map.nospawn");
            this.invalidMap = true;
          }
          else if (checkRules.pvp)
          {
            if (Vars.state.teams.getActive().count((Boolf) new World.__\u003C\u003EAnon6()) < 2)
            {
              this.invalidMap = true;
              Vars.ui.showErrorMessage("@map.nospawn.pvp");
            }
          }
          else if (checkRules.attackMode)
          {
            this.invalidMap = Vars.state.teams.get(Vars.state.rules.waveTeam).noCores();
            if (this.invalidMap)
              Vars.ui.showErrorMessage("@map.nospawn.attack");
          }
        }
        else
        {
          this.invalidMap = !Vars.state.teams.getActive().contains((Boolf) new World.__\u003C\u003EAnon6());
          if (this.invalidMap)
          {
            Map map1 = map;
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new MapException(map1, "Map has no cores!");
          }
        }
        if (!this.invalidMap)
          return;
        Core.app.post((Runnable) new World.__\u003C\u003EAnon7());
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isInvalidMap() => this.invalidMap;

    [LineNumberTable(new byte[] {160, 65, 134, 124, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tiles resize(int width, int height)
    {
      this.clearTileEntities();
      if (this.tiles.__\u003C\u003Ewidth != width || this.tiles.__\u003C\u003Eheight != height)
        this.tiles = new Tiles(width, height);
      return this.tiles;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isGenerating() => this.generating;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginMapLoad() => this.generating = true;

    [LineNumberTable(new byte[] {160, 88, 159, 4, 127, 5, 103, 162, 104, 139, 133, 140, 159, 26, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void endMapLoad()
    {
      Iterator iterator = this.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        Block block = tile.block();
        LegacyBlock legacyBlock;
        if (block is LegacyBlock && object.ReferenceEquals((object) (legacyBlock = (LegacyBlock) block), (object) (LegacyBlock) block))
          legacyBlock.removeSelf(tile);
        else if (tile.build != null)
          tile.build.updateProximity();
      }
      this.addDarkness(this.tiles);
      Groups.resize(-500f, -500f, (float) (this.tiles.__\u003C\u003Ewidth * 8) + 1000f, (float) (this.tiles.__\u003C\u003Eheight * 8) + 1000f);
      this.generating = false;
      Events.fire((object) new EventType.WorldLoadEvent());
    }

    [LineNumberTable(new byte[] {15, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool wallSolid(int x, int y)
    {
      Tile tile = this.tile(x, y);
      return tile == null || tile.block().solid;
    }

    [LineNumberTable(new byte[] {117, 127, 1, 107, 139, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void clearTileEntities()
    {
      Iterator iterator = this.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if (tile != null && tile.build != null)
          tile.build.remove();
      }
    }

    [LineNumberTable(new byte[] {161, 94, 115, 147, 130, 103, 105, 105, 228, 61, 230, 71, 105, 127, 3, 120, 99, 127, 0, 127, 3, 110, 118, 99, 226, 59, 235, 72, 119, 133, 235, 49, 233, 82, 127, 3, 152, 105, 171, 106, 99, 127, 0, 127, 3, 110, 124, 99, 226, 59, 235, 73, 140, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addDarkness(Tiles tiles)
    {
      byte[] numArray1 = new byte[tiles.__\u003C\u003Ewidth * tiles.__\u003C\u003Eheight];
      byte[] numArray2 = new byte[tiles.__\u003C\u003Ewidth * tiles.__\u003C\u003Eheight];
      int num1 = 4;
      for (int idx = 0; idx < numArray1.Length; ++idx)
      {
        if (tiles.geti(idx).isDarkened())
          numArray1[idx] = (byte) num1;
      }
      for (int index1 = 0; index1 < num1; ++index1)
      {
        Iterator iterator = tiles.iterator();
        while (iterator.hasNext())
        {
          Tile tile = (Tile) iterator.next();
          int index2 = (int) tile.y * tiles.__\u003C\u003Ewidth + (int) tile.x;
          int num2 = 0;
          Point2[] d4 = Geometry.__\u003C\u003Ed4;
          int length = d4.Length;
          for (int index3 = 0; index3 < length; ++index3)
          {
            Point2 point2 = d4[index3];
            int x = (int) tile.x + point2.x;
            int y = (int) tile.y + point2.y;
            int index4 = y * tiles.__\u003C\u003Ewidth + x;
            if (tiles.@in(x, y) && (int) (sbyte) numArray1[index4] < (int) (sbyte) numArray1[index2])
            {
              num2 = 1;
              break;
            }
          }
          numArray2[index2] = (byte) Math.max(0, (int) (sbyte) numArray1[index2] - Mathf.num(num2 != 0));
        }
        ByteCodeHelper.arraycopy_primitive_1((Array) numArray2, 0, (Array) numArray1, 0, numArray2.Length);
      }
      Iterator iterator1 = tiles.iterator();
      while (iterator1.hasNext())
      {
        Tile tile = (Tile) iterator1.next();
        int index1 = (int) tile.y * tiles.__\u003C\u003Ewidth + (int) tile.x;
        if (tile.isDarkened())
          tile.data = numArray1[index1];
        if (numArray1[index1] == (byte) 4)
        {
          int num2 = 1;
          Point2[] d4 = Geometry.__\u003C\u003Ed4;
          int length = d4.Length;
          for (int index2 = 0; index2 < length; ++index2)
          {
            Point2 point2 = d4[index2];
            int x = point2.x + (int) tile.x;
            int y = point2.y + (int) tile.y;
            int index3 = y * tiles.__\u003C\u003Ewidth + x;
            if (tiles.@in(x, y) && (!tile.isDarkened() || numArray1[index3] != (byte) 4))
            {
              num2 = 0;
              break;
            }
          }
          if (num2 != 0)
            tile.data = (byte) 5;
        }
      }
    }

    [LineNumberTable(new byte[] {160, 158, 127, 74, 144, 181, 102, 134, 127, 8, 126, 162, 109, 127, 0, 127, 0, 141, 109, 109, 114, 173, 165, 109, 146, 146, 110, 110, 61, 232, 69, 127, 53, 127, 31, 126, 159, 92, 100, 190, 100, 126, 190, 100, 190, 100, 190, 113, 127, 21, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setSectorRules([In] Sector obj0)
    {
      Vars.state.map = new Map(StringMap.of(new object[2]
      {
        (object) "name",
        obj0.preset != null ? (object) obj0.preset.localizedName : (object) new StringBuilder().append(obj0.__\u003C\u003Eplanet.localizedName).append("; Sector ").append(obj0.__\u003C\u003Eid).toString()
      }));
      Vars.state.rules.sector = obj0;
      Vars.state.rules.weather.clear();
      ObjectIntMap objectIntMap = new ObjectIntMap();
      ObjectSet objectSet = new ObjectSet();
      Iterator iterator = Vars.world.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        if ((double) Vars.world.getDarkness((int) tile.x, (int) tile.y) < 3.0)
        {
          Liquid liquidDrop = tile.floor().liquidDrop;
          if (tile.floor().itemDrop != null)
            objectSet.add((object) tile.floor().itemDrop);
          if (tile.overlay().itemDrop != null)
            objectSet.add((object) tile.overlay().itemDrop);
          if (liquidDrop != null)
            objectSet.add((object) liquidDrop);
          if (!tile.block().isStatic())
          {
            objectIntMap.increment((object) tile.floor());
            if (!object.ReferenceEquals((object) tile.overlay(), (object) Blocks.air))
              objectIntMap.increment((object) tile.overlay());
          }
        }
      }
      Seq array = objectIntMap.entries().toArray();
      array.sort((Floatf) new World.__\u003C\u003EAnon1());
      array.removeAll((Boolf) new World.__\u003C\u003EAnon2());
      Block[] blockArray = new Block[array.size];
      for (int index = 0; index < array.size; ++index)
        blockArray[index] = (Block) ((ObjectIntMap.Entry) array.get(index)).key;
      string name1 = blockArray[0].__\u003C\u003Ename;
      object obj1 = (object) "ice";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence charSequence2 = charSequence1;
      int num1;
      if (!String.instancehelper_contains(name1, charSequence2))
      {
        string name2 = blockArray[0].__\u003C\u003Ename;
        object obj2 = (object) "snow";
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence3 = charSequence1;
        if (!String.instancehelper_contains(name2, charSequence3))
        {
          num1 = 0;
          goto label_19;
        }
      }
      num1 = 1;
label_19:
      int num2 = num1;
      int num3;
      if (num2 == 0 && objectSet.contains((object) Liquids.water))
      {
        string name2 = blockArray[0].__\u003C\u003Ename;
        object obj2 = (object) "sand";
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence3 = charSequence1;
        if (!String.instancehelper_contains(name2, charSequence3))
        {
          num3 = 1;
          goto label_23;
        }
      }
      num3 = 0;
label_23:
      int num4 = num3;
      int num5 = num2 != 0 || num4 != 0 || !object.ReferenceEquals((object) blockArray[0], (object) Blocks.sand) ? 0 : 1;
      string name3 = blockArray[0].__\u003C\u003Ename;
      object obj3 = (object) "spore";
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence4 = charSequence1;
      int num6;
      if (!String.instancehelper_contains(name3, charSequence4))
      {
        string name2 = blockArray[0].__\u003C\u003Ename;
        object obj2 = (object) "moss";
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence3 = charSequence1;
        if (!String.instancehelper_contains(name2, charSequence3))
        {
          string name4 = blockArray[0].__\u003C\u003Ename;
          object obj4 = (object) "tainted";
          charSequence1.__\u003Cref\u003E = (__Null) obj4;
          CharSequence charSequence5 = charSequence1;
          if (!String.instancehelper_contains(name4, charSequence5))
          {
            num6 = 0;
            goto label_28;
          }
        }
      }
      num6 = 1;
label_28:
      int num7 = num6;
      if (num2 != 0)
        Vars.state.rules.weather.add((object) new Weather.WeatherEntry(Weathers.snow));
      if (num4 != 0)
      {
        Vars.state.rules.weather.add((object) new Weather.WeatherEntry(Weathers.rain));
        Vars.state.rules.weather.add((object) new Weather.WeatherEntry(Weathers.fog));
      }
      if (num5 != 0)
        Vars.state.rules.weather.add((object) new Weather.WeatherEntry(Weathers.sandstorm));
      if (num7 != 0)
        Vars.state.rules.weather.add((object) new Weather.WeatherEntry(Weathers.sporestorm));
      obj0.info.resources = objectSet.asArray();
      obj0.info.resources.sort(Structs.comps(Structs.comparing((Func) new World.__\u003C\u003EAnon3()), Structs.comparingInt((Intf) new World.__\u003C\u003EAnon4())));
      obj0.saveInfo();
    }

    [Signature("(IILarc/func/Cons<Lmindustry/world/Tiles;>;)V")]
    [LineNumberTable(new byte[] {160, 121, 134, 105, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadGenerator(int width, int height, Cons generator)
    {
      this.beginMapLoad();
      this.resize(width, height);
      generator.get((object) this.tiles);
      this.endMapLoad();
    }

    [LineNumberTable(new byte[] {161, 148, 130, 102, 127, 27, 100, 183, 127, 4, 131, 125, 159, 13, 119, 140, 108, 136, 121, 191, 68, 159, 17, 113, 101, 203, 110, 127, 15, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDarkness(int x, int y)
    {
      int num1 = 2;
      float num2 = 0.0f;
      int num3 = Math.min(x, Math.min(y, Math.min(Math.abs(x - (this.tiles.__\u003C\u003Ewidth - 1)), Math.abs(y - (this.tiles.__\u003C\u003Eheight - 1)))));
      if (num3 <= num1)
        num2 = Math.max((float) (num1 - num3) * (4f / (float) num1), num2);
      if (Vars.state.hasSector() && Vars.state.getSector().preset == null)
      {
        int num4 = 14;
        float degrees = Vars.state.getSector().__\u003C\u003Erect.__\u003C\u003Erotation + 90f;
        float num5 = Angles.angle((float) x, (float) y, (float) (this.tiles.__\u003C\u003Ewidth / 2), (float) (this.tiles.__\u003C\u003Eheight / 2)) + degrees;
        float step = 360f / (float) Vars.state.getSector().__\u003C\u003Etile.corners.Length;
        float angle1 = Mathf.round(num5, step);
        float angle2 = angle1 + step;
        float amount = (float) Vars.state.getSector().getSize() / 2f;
        int num6 = ByteCodeHelper.f2i(Intersector.distanceLinePoint(Tmp.__\u003C\u003Ev1.trns(angle1, amount), Tmp.__\u003C\u003Ev2.trns(angle2, amount), Tmp.__\u003C\u003Ev3.set((float) (x - this.tiles.__\u003C\u003Ewidth / 2), (float) (y - this.tiles.__\u003C\u003Eheight / 2)).rotate(degrees)) / Mathf.__\u003C\u003Esqrt3 - 1f + (Noise.noise((float) x, (float) y, 11f, 7f) + Noise.noise((float) x, (float) y, 22f, 15f)) - (amount - (float) num4));
        if (num6 > 0)
          num2 = Math.max((float) num6, num2);
      }
      Tile tile = Vars.world.tile(x, y);
      if (tile != null && tile.block().solid && (tile.block().fillsTile && !tile.block().synthetic()))
        num2 = Math.max(num2, (float) (sbyte) tile.data);
      return num2;
    }

    [LineNumberTable(new byte[] {161, 37, 98, 98, 105, 138, 106, 139, 197, 109, 139, 102, 102, 102, 165, 101, 102, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void raycastEach(int x0f, int y0f, int x1, int y1, Geometry.Raycaster cons)
    {
      int i1 = x0f;
      int i2 = y0f;
      int num1 = Math.abs(x1 - i1);
      int num2 = Math.abs(y1 - i2);
      int num3 = i1 >= x1 ? -1 : 1;
      int num4 = i2 >= y1 ? -1 : 1;
      int num5 = num1 - num2;
      while (!cons.accept(i1, i2) && (i1 != x1 || i2 != y1))
      {
        int num6 = 2 * num5;
        if (num6 > -num2)
        {
          num5 -= num2;
          i1 += num3;
        }
        if (num6 < num1)
        {
          num5 += num1;
          i2 += num4;
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 134, 104, 113, 156, 178, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadSector\u00240([In] Sector obj0, [In] Tiles obj1)
    {
      if (obj0.preset != null)
      {
        obj0.preset.generator.generate(obj1);
        obj0.preset.rules.get((object) Vars.state.rules);
      }
      else
        obj0.__\u003C\u003Eplanet.generator.generate(obj1, obj0);
      Vars.state.rules.sector = obj0;
    }

    [Modifiers]
    [LineNumberTable(301)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setSectorRules\u00241([In] ObjectIntMap.Entry obj0) => (float) -obj0.value;

    [Modifiers]
    [LineNumberTable(303)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024setSectorRules\u00242([In] ObjectIntMap.Entry obj0) => obj0.value < 30;

    [Modifiers]
    [LineNumberTable(334)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024setSectorRules\u00243([In] UnlockableContent obj0) => (int) obj0.__\u003C\u003Eid;

    [Modifiers]
    [LineNumberTable(359)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadMap\u00244() => Vars.state.set(GameState.State.__\u003C\u003Emenu);

    [Modifiers]
    [LineNumberTable(393)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadMap\u00245() => Vars.state.set(GameState.State.__\u003C\u003Emenu);

    [Modifiers]
    [LineNumberTable(398)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024notifyChanged\u00246([In] Tile obj0) => Events.fire((object) new EventType.TileChangeEvent(obj0));

    [LineNumberTable(new byte[] {159, 187, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addMapLoader(Map map, Runnable loader) => this.customMapLoaders.put((object) map, (object) loader);

    [LineNumberTable(new byte[] {9, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool passable(int x, int y)
    {
      Tile tile = this.tile(x, y);
      return tile != null && tile.passable();
    }

    [LineNumberTable(new byte[] {20, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool wallSolidFull(int x, int y)
    {
      Tile tile = this.tile(x, y);
      return tile == null || tile.block().solid && tile.block().fillsTile;
    }

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAccessible(int x, int y) => !this.wallSolid(x, y - 1) || !this.wallSolid(x, y + 1) || (!this.wallSolid(x - 1, y) || !this.wallSolid(x + 1, y));

    [LineNumberTable(new byte[] {45, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floor(int x, int y)
    {
      Tile tile = this.tile(x, y);
      return tile == null ? Blocks.air.asFloor() : tile.floor();
    }

    [LineNumberTable(new byte[] {50, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Floor floorWorld(float x, float y)
    {
      Tile tile = this.tileWorld(x, y);
      return tile == null ? Blocks.air.asFloor() : tile.floor();
    }

    [LineNumberTable(new byte[] {66, 110, 101, 104, 140})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tileBuilding(int x, int y)
    {
      Tile tile = this.tiles.get(x, y);
      if (tile == null)
        return (Tile) null;
      return tile.build != null ? tile.build.tile() : tile;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float conv(float coord) => coord / 8f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float unconv(float coord) => coord * 8f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setGenerating(bool gen) => this.generating = gen;

    [LineNumberTable(339)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual World.Context filterContext(Map map) => (World.Context) new World.FilterContext(this, map);

    [LineNumberTable(new byte[] {160, 229, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadMap(Map map) => this.loadMap(map, new Rules());

    [LineNumberTable(new byte[] {161, 27, 104, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void notifyChanged(Tile tile)
    {
      if (this.generating)
        return;
      Core.app.post((Runnable) new World.__\u003C\u003EAnon8(tile));
    }

    [LineNumberTable(new byte[] {161, 33, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void raycastEachWorld(
      float x0,
      float y0,
      float x1,
      float y1,
      Geometry.Raycaster cons)
    {
      this.raycastEach(World.toTile(x0), World.toTile(y0), World.toTile(x1), World.toTile(y1), cons);
    }

    [Modifiers]
    public object context
    {
      [HideFromJava] get => (object) this.__\u003C\u003Econtext;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Econtext = (World.Context) value;
    }

    [HideFromJava]
    [NameSig("filterContext", "(Lmindustry.maps.Map;)Lmindustry.core.World$Context;")]
    public object filterContext([In] Map obj0) => (object) this.filterContext(obj0);

    [HideFromJava]
    [NameSig("filterContext", "(Lmindustry.maps.Map;)Lmindustry.core.World$Context;")]
    protected internal object \u003Cnonvirtual\u003E0([In] Map obj0) => (object) this.filterContext(obj0);

    [InnerClass]
    internal class Context : Object, WorldContext
    {
      [Modifiers]
      internal World this\u00240;

      [LineNumberTable(new byte[] {161, 190, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Context([In] World obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(565)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tile tile([In] int obj0) => this.this\u00240.tiles.geti(obj0);

      [LineNumberTable(new byte[] {161, 200, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void resize([In] int obj0, [In] int obj1) => this.this\u00240.resize(obj0, obj1);

      [LineNumberTable(new byte[] {161, 205, 109, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tile create([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
      {
        Tile tile = new Tile(obj0, obj1, obj2, obj3, obj4);
        this.this\u00240.tiles.set(obj0, obj1, tile);
        return tile;
      }

      [LineNumberTable(582)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isGenerating() => this.this\u00240.isGenerating();

      [LineNumberTable(new byte[] {161, 217, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void begin() => this.this\u00240.beginMapLoad();

      [LineNumberTable(new byte[] {161, 222, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void end() => this.this\u00240.endMapLoad();

      [HideFromJava]
      public virtual void onReadBuilding() => WorldContext.\u003Cdefault\u003EonReadBuilding((WorldContext) this);
    }

    [InnerClass]
    internal class FilterContext : World.Context
    {
      [Modifiers]
      internal Map map;
      [Modifiers]
      internal new World this\u00240;

      [LineNumberTable(new byte[] {161, 230, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal FilterContext([In] World obj0, [In] Map obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0);
        World.FilterContext filterContext = this;
        this.map = obj1;
      }

      [Modifiers]
      [LineNumberTable(614)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Tile lambda\u0024end\u00240([In] int obj0, [In] int obj1) => this.this\u00240.tiles.getn(obj0, obj1);

      [LineNumberTable(new byte[] {161, 236, 140, 139, 134, 123, 102, 127, 9, 114, 162, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void end()
      {
        Seq seq = this.map.filters();
        if (!seq.isEmpty())
        {
          GenerateFilter.GenerateInput @in = new GenerateFilter.GenerateInput();
          Iterator iterator = seq.iterator();
          while (iterator.hasNext())
          {
            GenerateFilter filter = (GenerateFilter) iterator.next();
            filter.randomize();
            @in.begin(filter, this.this\u00240.width(), this.this\u00240.height(), (GenerateFilter.GenerateInput.TileProvider) new World.FilterContext.__\u003C\u003EAnon0(this));
            filter.apply(this.this\u00240.tiles, @in);
          }
        }
        base.end();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : GenerateFilter.GenerateInput.TileProvider
      {
        private readonly World.FilterContext arg\u00241;

        internal __\u003C\u003EAnon0([In] World.FilterContext obj0) => this.arg\u00241 = obj0;

        public Tile get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024end\u00240(obj0, obj1);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Sector arg\u00241;

      internal __\u003C\u003EAnon0([In] Sector obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => World.lambda\u0024loadSector\u00240(this.arg\u00241, (Tiles) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float get([In] object obj0) => World.lambda\u0024setSectorRules\u00241((ObjectIntMap.Entry) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (World.lambda\u0024setSectorRules\u00242((ObjectIntMap.Entry) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Func
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get([In] object obj0) => (object) ((Content) obj0).getContentType();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Intf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public int get([In] object obj0) => World.lambda\u0024setSectorRules\u00243((UnlockableContent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void run() => World.lambda\u0024loadMap\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] object obj0) => (((Teams.TeamData) obj0).hasCore() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void run() => World.lambda\u0024loadMap\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon8([In] Tile obj0) => this.arg\u00241 = obj0;

      public void run() => World.lambda\u0024notifyChanged\u00246(this.arg\u00241);
    }
  }
}
