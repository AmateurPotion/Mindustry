// Decompiled with JetBrains decompiler
// Type: mindustry.type.Sector
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.game;
using mindustry.graphics.g3d;
using mindustry.ui;
using mindustry.world.modules;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  public class Sector : Object
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/type/Sector;>;")]
    private static Seq tmpSeq1;
    internal Sector.SectorRect __\u003C\u003Erect;
    internal Plane __\u003C\u003Eplane;
    internal Planet __\u003C\u003Eplanet;
    internal PlanetGrid.Ptile __\u003C\u003Etile;
    internal int __\u003C\u003Eid;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Saves.SaveSlot save;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public SectorPreset preset;
    public SectorInfo info;
    public float threat;
    public bool generateEnemyBase;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBeingPlayed() => Vars.state.isGame() && object.ReferenceEquals((object) Vars.state.rules.sector, (object) this) && (!Vars.state.gameOver && !Vars.net.client());

    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasBase() => this.save != null && this.info.hasCore && (!Vars.state.isGame() || !object.ReferenceEquals((object) Vars.state.rules.sector, (object) this) || !Vars.state.gameOver);

    [LineNumberTable(new byte[] {159, 180, 232, 58, 235, 71, 103, 103, 107, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Sector(Planet planet, PlanetGrid.Ptile tile)
    {
      Sector sector = this;
      this.info = new SectorInfo();
      this.__\u003C\u003Eplanet = planet;
      this.__\u003C\u003Etile = tile;
      this.__\u003C\u003Eplane = new Plane();
      this.__\u003C\u003Erect = this.makeRect();
      this.__\u003C\u003Eid = tile.id;
    }

    [Signature("()Larc/struct/Seq<Lmindustry/type/Sector;>;")]
    [LineNumberTable(new byte[] {159, 189, 107, 121, 54, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq near()
    {
      Sector.tmpSeq1.clear();
      PlanetGrid.Ptile[] tiles = this.__\u003C\u003Etile.tiles;
      int length = tiles.Length;
      for (int index = 0; index < length; ++index)
      {
        PlanetGrid.Ptile tile = tiles[index];
        Sector.tmpSeq1.add((object) this.__\u003C\u003Eplanet.getSector(tile));
      }
      return Sector.tmpSeq1;
    }

    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasEnemyBase() => (this.generateEnemyBase && this.preset == null || this.preset != null && this.preset.captureWave == 0) && (this.save == null || this.info.attack);

    [LineNumberTable(new byte[] {31, 127, 62})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadInfo() => this.info = (SectorInfo) Core.settings.getJson(new StringBuilder().append(this.__\u003C\u003Eplanet.__\u003C\u003Ename).append("-s-").append(this.__\u003C\u003Eid).append("-info").toString(), (Class) ClassLiteral<SectorInfo>.Value, (Prov) new Sector.__\u003C\u003EAnon0());

    [LineNumberTable(new byte[] {65, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string name()
    {
      if (this.preset != null && this.info.name == null)
        return this.preset.localizedName;
      return this.info.name == null ? new StringBuilder().append(this.__\u003C\u003Eid).append("").toString() : this.info.name;
    }

    [LineNumberTable(new byte[] {27, 127, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void saveInfo() => Core.settings.putJson(new StringBuilder().append(this.__\u003C\u003Eplanet.__\u003C\u003Ename).append("-s-").append(this.__\u003C\u003Eid).append("-info").toString(), (object) this.info);

    [LineNumberTable(new byte[] {101, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSize()
    {
      int num1 = ByteCodeHelper.f2i(this.__\u003C\u003Erect.__\u003C\u003Eradius * 3200f);
      int num2 = num1;
      int num3 = 2;
      return (num3 != -1 ? num2 % num3 : 0) == 0 ? num1 : num1 + 1;
    }

    [LineNumberTable(new byte[] {45, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isAttacked()
    {
      if (this.isBeingPlayed())
        return Vars.state.rules.waves;
      return this.save != null && this.info.waves && this.info.hasCore;
    }

    [LineNumberTable(new byte[] {93, 127, 19, 159, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getLight() => (Tmp.__\u003C\u003Ev31.set(this.__\u003C\u003Etile.v).rotate(Vec3.__\u003C\u003EY, -this.__\u003C\u003Eplanet.getRotation()).nor().dot(Tmp.__\u003C\u003Ev32.set(this.__\u003C\u003Eplanet.solarSystem.position).sub(this.__\u003C\u003Eplanet.position).nor()) + 1f) / 2f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasSave() => this.save != null;

    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getProductionScale() => Math.max(1f - this.info.damage, 0.0f);

    [LineNumberTable(new byte[] {119, 104, 121, 117, 122, 114, 98, 104, 113, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addItems(ItemSeq items)
    {
      if (this.isBeingPlayed())
      {
        if (Vars.state.rules.defaultTeam.core() == null)
          return;
        ItemModule itemModule = Vars.state.rules.defaultTeam.items();
        int storageCapacity = Vars.state.rules.defaultTeam.core().storageCapacity;
        items.each((ItemModule.ItemConsumer) new Sector.__\u003C\u003EAnon2(itemModule, storageCapacity));
      }
      else
      {
        if (!this.hasBase())
          return;
        items.each((ItemModule.ItemConsumer) new Sector.__\u003C\u003EAnon3(this));
        this.info.items.checkNegative();
        this.saveInfo();
      }
    }

    [LineNumberTable(new byte[] {160, 70, 166, 104, 191, 19, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemSeq items()
    {
      ItemSeq itemSeq = new ItemSeq();
      if (this.isBeingPlayed())
      {
        if (Vars.state.rules.defaultTeam.core() != null)
          itemSeq.add(Vars.state.rules.defaultTeam.items());
      }
      else
        itemSeq.add(this.info.items);
      return itemSeq;
    }

    [LineNumberTable(new byte[] {160, 90, 114, 103, 63, 11, 198, 107, 115, 45, 200, 155, 183, 180, 127, 23, 191, 18, 113, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Sector.SectorRect makeRect()
    {
      Vec3[] vec3Array1 = new Vec3[this.__\u003C\u003Etile.corners.Length];
      for (int index = 0; index < vec3Array1.Length; ++index)
        vec3Array1[index] = this.__\u003C\u003Etile.corners[index].v.cpy().setLength(this.__\u003C\u003Eplanet.radius);
      Tmp.__\u003C\u003Ev33.setZero();
      Vec3[] vec3Array2 = vec3Array1;
      int length = vec3Array2.Length;
      for (int index = 0; index < length; ++index)
      {
        Vec3 vector = vec3Array2[index];
        Tmp.__\u003C\u003Ev33.add(vector);
      }
      Vec3 vec3_1 = Tmp.__\u003C\u003Ev33.scl(1f / (float) vec3Array1.Length).cpy();
      float num = Tmp.__\u003C\u003Ev33.dst(vec3Array1[0]) * 0.98f;
      this.__\u003C\u003Eplane.set(vec3Array1[0], vec3Array1[2], vec3Array1[4]);
      Vec3 vec3_2 = this.__\u003C\u003Eplane.project(vec3_1.cpy().add(0.0f, 1f, 0.0f)).sub(vec3_1).setLength(num);
      Vec3 right = this.__\u003C\u003Eplane.project(vec3_1.cpy().rotate(Vec3.__\u003C\u003EY, -4f)).sub(vec3_1).setLength(num);
      float rotation = vec3Array1[1].cpy().sub(vec3_1).angle(vec3_2);
      return new Sector.SectorRect(num, vec3_1, vec3_2, right, rotation);
    }

    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool unlocked() => this.hasBase() || this.preset != null && this.preset.alwaysUnlocked;

    [Modifiers]
    [LineNumberTable(157)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024removeItems\u00240([In] ItemSeq obj0, [In] Item obj1, [In] int obj2) => obj0.set(obj1, -obj2);

    [Modifiers]
    [LineNumberTable(173)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024addItems\u00241(
      [In] ItemModule obj0,
      [In] int obj1,
      [In] Item obj2,
      [In] int obj3)
    {
      obj0.add(obj2, Math.min(obj1 - obj0.get(obj2), obj3));
    }

    [Modifiers]
    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addItems\u00242([In] Item obj0, [In] int obj1) => this.info.items.add(obj0, Math.min(this.info.storageCapacity - this.info.items.get(obj0), obj1));

    [Signature("(Larc/func/Cons<Lmindustry/type/Sector;>;)V")]
    [LineNumberTable(new byte[] {6, 121, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void near(Cons cons)
    {
      PlanetGrid.Ptile[] tiles = this.__\u003C\u003Etile.tiles;
      int length = tiles.Length;
      for (int index = 0; index < length; ++index)
      {
        PlanetGrid.Ptile tile = tiles[index];
        cons.get((object) this.__\u003C\u003Eplanet.getSector(tile));
      }
    }

    [LineNumberTable(new byte[] {13, 102, 127, 13, 127, 16, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string displayThreat()
    {
      float step = 0.25f;
      string str = Tmp.__\u003C\u003Ec1.set(Color.__\u003C\u003Ewhite).lerp(Color.__\u003C\u003Escarlet, Mathf.round(this.threat, step)).toString();
      string[] strArray = new string[5]
      {
        "low",
        "medium",
        "high",
        "extreme",
        "eradication"
      };
      int index = Math.min(ByteCodeHelper.f2i(this.threat / step), strArray.Length - 1);
      return new StringBuilder().append("[#").append(str).append("]").append(Core.bundle.get(new StringBuilder().append("threat.").append(strArray[index]).toString())).toString();
    }

    [LineNumberTable(new byte[] {36, 107, 127, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearInfo()
    {
      this.info = new SectorInfo();
      Core.settings.remove(new StringBuilder().append(this.__\u003C\u003Eplanet.__\u003C\u003Ename).append("-s-").append(this.__\u003C\u003Eid).append("-info").toString());
    }

    [LineNumberTable(new byte[] {70, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setName(string name)
    {
      this.info.name = name;
      this.saveInfo();
    }

    [LineNumberTable(126)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion icon() => this.info.icon == null ? (TextureRegion) null : Fonts.getLargeIcon(this.info.icon);

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCaptured() => this.save != null && !this.info.waves;

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool locked() => !this.unlocked();

    [LineNumberTable(new byte[] {106, 103, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeItems(ItemSeq items)
    {
      ItemSeq items1 = items.copy();
      items1.each((ItemModule.ItemConsumer) new Sector.__\u003C\u003EAnon1(items1));
      this.addItems(items1);
    }

    [LineNumberTable(new byte[] {112, 102, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeItem(Item item, int amount)
    {
      ItemSeq items = new ItemSeq();
      items.add(item, -amount);
      this.addItems(items);
    }

    [LineNumberTable(198)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(this.__\u003C\u003Eplanet.__\u003C\u003Ename).append("#").append(this.__\u003C\u003Eid).append(" (").append(this.name()).append(")").toString();

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Sector()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.type.Sector"))
        return;
      Sector.tmpSeq1 = new Seq();
    }

    [Modifiers]
    public Sector.SectorRect rect
    {
      [HideFromJava] get => this.__\u003C\u003Erect;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Erect = value;
    }

    [Modifiers]
    public Plane plane
    {
      [HideFromJava] get => this.__\u003C\u003Eplane;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eplane = value;
    }

    [Modifiers]
    public Planet planet
    {
      [HideFromJava] get => this.__\u003C\u003Eplanet;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eplanet = value;
    }

    [Modifiers]
    public PlanetGrid.Ptile tile
    {
      [HideFromJava] get => this.__\u003C\u003Etile;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etile = value;
    }

    [Modifiers]
    public int id
    {
      [HideFromJava] get => this.__\u003C\u003Eid;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eid = value;
    }

    public class SectorRect : Object
    {
      internal Vec3 __\u003C\u003Ecenter;
      internal Vec3 __\u003C\u003Etop;
      internal Vec3 __\u003C\u003Eright;
      internal Vec3 __\u003C\u003Eresult;
      internal float __\u003C\u003Eradius;
      internal float __\u003C\u003Erotation;

      [LineNumberTable(new byte[] {160, 134, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Vec3 project(float x, float y)
      {
        float scale1 = (x - 0.5f) * 2f;
        float scale2 = (y - 0.5f) * 2f;
        return this.__\u003C\u003Eresult.set(this.__\u003C\u003Ecenter).add(this.__\u003C\u003Eright, scale1).add(this.__\u003C\u003Etop, scale2);
      }

      [LineNumberTable(new byte[] {160, 123, 232, 61, 203, 103, 103, 104, 104, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SectorRect(float radius, Vec3 center, Vec3 top, Vec3 right, float rotation)
      {
        Sector.SectorRect sectorRect = this;
        this.__\u003C\u003Eresult = new Vec3();
        this.__\u003C\u003Ecenter = center;
        this.__\u003C\u003Etop = top;
        this.__\u003C\u003Eright = right;
        this.__\u003C\u003Eradius = radius;
        this.__\u003C\u003Erotation = rotation;
      }

      [Modifiers]
      public Vec3 center
      {
        [HideFromJava] get => this.__\u003C\u003Ecenter;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ecenter = value;
      }

      [Modifiers]
      public Vec3 top
      {
        [HideFromJava] get => this.__\u003C\u003Etop;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etop = value;
      }

      [Modifiers]
      public Vec3 right
      {
        [HideFromJava] get => this.__\u003C\u003Eright;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eright = value;
      }

      [Modifiers]
      public Vec3 result
      {
        [HideFromJava] get => this.__\u003C\u003Eresult;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eresult = value;
      }

      [Modifiers]
      public float radius
      {
        [HideFromJava] get => this.__\u003C\u003Eradius;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eradius = value;
      }

      [Modifiers]
      public float rotation
      {
        [HideFromJava] get => this.__\u003C\u003Erotation;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Erotation = value;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new SectorInfo();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : ItemModule.ItemConsumer
    {
      private readonly ItemSeq arg\u00241;

      internal __\u003C\u003EAnon1([In] ItemSeq obj0) => this.arg\u00241 = obj0;

      public void accept([In] Item obj0, [In] int obj1) => Sector.lambda\u0024removeItems\u00240(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : ItemModule.ItemConsumer
    {
      private readonly ItemModule arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon2([In] ItemModule obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void accept([In] Item obj0, [In] int obj1) => Sector.lambda\u0024addItems\u00241(this.arg\u00241, this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : ItemModule.ItemConsumer
    {
      private readonly Sector arg\u00241;

      internal __\u003C\u003EAnon3([In] Sector obj0) => this.arg\u00241 = obj0;

      public void accept([In] Item obj0, [In] int obj1) => this.arg\u00241.lambda\u0024addItems\u00242(obj0, obj1);
    }
  }
}
