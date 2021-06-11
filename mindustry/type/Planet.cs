// Decompiled with JetBrains decompiler
// Type: mindustry.type.Planet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.noise;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.ctype;
using mindustry.graphics;
using mindustry.graphics.g3d;
using mindustry.maps.generators;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  public class Planet : UnlockableContent
  {
    private const float orbitSpacing = 9f;
    [Modifiers]
    private static Vec3 intersectResult;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public PlanetMesh mesh;
    public Vec3 position;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public PlanetGrid grid;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public PlanetGenerator generator;
    [Signature("Larc/struct/Seq<Lmindustry/type/Sector;>;")]
    public Seq sectors;
    public float radius;
    public float atmosphereRadIn;
    public float atmosphereRadOut;
    public float orbitRadius;
    public float totalRadius;
    public float orbitTime;
    public float rotateTime;
    public float sectorApproxRadius;
    public bool tidalLock;
    public bool accessible;
    public int startSector;
    public bool bloom;
    public bool visible;
    public Color lightColor;
    public Color atmosphereColor;
    public bool hasAtmosphere;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Planet parent;
    public Planet solarSystem;
    [Signature("Larc/struct/Seq<Lmindustry/type/Planet;>;")]
    public Seq children;
    [Signature("Larc/struct/Seq<Lmindustry/type/Satellite;>;")]
    public Seq satellites;
    [Signature("Larc/func/Prov<Lmindustry/graphics/g3d/PlanetMesh;>;")]
    protected internal Prov meshLoader;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {80, 108, 159, 1, 127, 1, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTotalRadius()
    {
      this.totalRadius = this.radius;
      Iterator iterator = this.children.iterator();
      while (iterator.hasNext())
      {
        Planet planet = (Planet) iterator.next();
        this.totalRadius = Math.max(this.totalRadius, planet.orbitRadius + planet.totalRadius);
      }
    }

    [LineNumberTable(new byte[] {94, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getOrbitAngle() => (Mathf.randomSeed((long) this.__\u003C\u003Eid, 360f) + Vars.universe.secondsf() / (this.orbitTime / 360f)) % 360f;

    [LineNumberTable(new byte[] {112, 117, 162, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 addParentOffset(Vec3 @in)
    {
      if (this.parent == null || Mathf.zero(this.orbitRadius))
        return @in;
      float orbitAngle = this.getOrbitAngle();
      return @in.add(Angles.trnsx(orbitAngle, this.orbitRadius), 0.0f, Angles.trnsy(orbitAngle, this.orbitRadius));
    }

    [LineNumberTable(new byte[] {101, 104, 168, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotation() => this.tidalLock ? this.getOrbitAngle() : (Mathf.randomSeed((long) ((int) this.__\u003C\u003Eid + 1), 360f) + Vars.universe.secondsf() / (this.rotateTime / 360f)) % 360f;

    [LineNumberTable(new byte[] {160, 67, 127, 4, 102, 127, 2, 105, 137, 130, 104, 169, 127, 28, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateBaseCoverage()
    {
      Iterator iterator1 = this.sectors.iterator();
      while (iterator1.hasNext())
      {
        Sector sector = (Sector) iterator1.next();
        float num = 1f;
        Iterator iterator2 = sector.near().iterator();
        while (iterator2.hasNext())
        {
          if (((Sector) iterator2.next()).generateEnemyBase)
            num += 0.9f;
        }
        if (sector.hasEnemyBase())
          num += 0.88f;
        sector.threat = sector.preset != null ? Mathf.clamp(sector.preset.difficulty / 10f) : Math.min(num / 5f, 1.2f);
      }
    }

    [LineNumberTable(new byte[] {160, 132, 106, 101, 126})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Sector getSector(Ray ray, float radius)
    {
      Vec3 vec3 = this.intersect(ray, radius);
      if (vec3 == null)
        return (Sector) null;
      vec3.sub(this.position).rotate(Vec3.__\u003C\u003EY, this.getRotation());
      return (Sector) this.sectors.min((Floatf) new Planet.__\u003C\u003EAnon1(vec3));
    }

    [LineNumberTable(new byte[] {160, 140, 116, 101})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 intersect(Ray ray, float radius) => !Intersector3D.intersectRaySphere(ray, this.position, radius, Planet.intersectResult) ? (Vec3) null : Planet.intersectResult;

    [Modifiers]
    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private PlanetMesh lambda\u0024new\u00240() => (PlanetMesh) new ShaderSphereMesh(this, Shaders.unlit, 2);

    [Modifiers]
    [LineNumberTable(249)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024getSector\u00241([In] Vec3 obj0, [In] Sector obj1) => obj1.__\u003C\u003Etile.v.dst2(obj0);

    [LineNumberTable(new byte[] {26, 233, 15, 235, 74, 246, 72, 203, 135, 135, 135, 135, 135, 144, 154, 231, 70, 139, 139, 241, 69, 105, 135, 103, 140, 119, 113, 63, 4, 198, 159, 42, 203, 177, 191, 6, 190, 99, 108, 198, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Planet(string name, Planet parent, int sectorSize, float radius)
      : base(name)
    {
      Planet planet = this;
      this.position = new Vec3();
      this.atmosphereRadIn = 0.0f;
      this.atmosphereRadOut = 0.3f;
      this.rotateTime = 1440f;
      this.tidalLock = false;
      this.accessible = true;
      this.startSector = 0;
      this.bloom = false;
      this.visible = true;
      this.lightColor = Color.__\u003C\u003Ewhite.cpy();
      this.atmosphereColor = new Color(0.3f, 0.7f, 1f);
      this.hasAtmosphere = true;
      this.children = new Seq();
      this.satellites = new Seq();
      this.meshLoader = (Prov) new Planet.__\u003C\u003EAnon0(this);
      this.radius = radius;
      this.parent = parent;
      if (sectorSize > 0)
      {
        this.grid = PlanetGrid.create(sectorSize);
        this.sectors = new Seq(this.grid.tiles.Length);
        for (int index = 0; index < this.grid.tiles.Length; ++index)
        {
          Seq sectors = this.sectors;
          Sector.__\u003Cclinit\u003E();
          Sector sector = new Sector(this, this.grid.tiles[index]);
          sectors.add((object) sector);
        }
        this.sectorApproxRadius = ((Sector) this.sectors.first()).__\u003C\u003Etile.v.dst(((Sector) this.sectors.first()).__\u003C\u003Etile.corners[0].v);
      }
      else
        this.sectors = new Seq();
      this.totalRadius += radius;
      this.orbitRadius = parent != null ? parent.totalRadius + 9f + this.totalRadius : 0.0f;
      this.orbitTime = Mathf.pow(this.orbitRadius, 1.5f) * 1000f;
      if (parent != null)
      {
        parent.children.add((object) this);
        parent.updateTotalRadius();
      }
      this.solarSystem = this;
      while (this.solarSystem.parent != null)
        this.solarSystem = this.solarSystem.parent;
    }

    [LineNumberTable(114)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Sector getLastSector() => (Sector) this.sectors.get(Math.min(Core.settings.getInt(new StringBuilder().append(this.__\u003C\u003Ename).append("-last-sector").toString(), this.startSector), this.sectors.size - 1));

    [LineNumberTable(new byte[] {68, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLastSector(Sector sector) => Core.settings.put(new StringBuilder().append(this.__\u003C\u003Ename).append("-last-sector").toString(), (object) Integer.valueOf(sector.__\u003C\u003Eid));

    [LineNumberTable(new byte[] {72, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void preset(int index, SectorPreset preset) => ((Sector) this.sectors.get(index)).preset = preset;

    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLandable() => this.grid != null && this.generator != null && this.sectors.size > 0;

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getLightNormal() => Tmp.__\u003C\u003Ev31.set(this.solarSystem.position).sub(this.position).nor();

    [LineNumberTable(new byte[] {122, 103, 101, 40, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getWorldPosition(Vec3 @in)
    {
      @in.setZero();
      for (Planet planet = this; planet != null; planet = planet.parent)
        planet.addParentOffset(@in);
      return @in;
    }

    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D getTransform(Mat3D mat) => mat.setToTranslation(this.position).rotate(Vec3.__\u003C\u003EY, this.getRotation());

    [LineNumberTable(new byte[] {160, 90, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void load() => this.mesh = (PlanetMesh) this.meshLoader.get();

    [LineNumberTable(new byte[] {160, 96, 127, 1, 102, 130, 104, 141, 127, 1, 108, 130, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      Iterator iterator1 = this.sectors.iterator();
      while (iterator1.hasNext())
        ((Sector) iterator1.next()).loadInfo();
      if (this.generator == null)
        return;
      Noise.setSeed((int) this.__\u003C\u003Eid + 1);
      Iterator iterator2 = this.sectors.iterator();
      while (iterator2.hasNext())
        this.generator.generateSector((Sector) iterator2.next());
      this.updateBaseCoverage();
    }

    [LineNumberTable(new byte[] {160, 114, 104, 107, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      if (this.mesh == null)
        return;
      this.mesh.dispose();
      this.mesh = (PlanetMesh) null;
    }

    [LineNumberTable(236)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Sector getSector(PlanetGrid.Ptile tile) => (Sector) this.sectors.get(tile.id);

    [LineNumberTable(241)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Sector getSector(Ray ray) => this.getSector(ray, this.radius);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isHidden() => true;

    [LineNumberTable(267)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Eplanet;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool visible() => this.visible;

    [LineNumberTable(new byte[] {160, 161, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Mat3D projection, Mat3D transform) => this.mesh.render(projection, transform);

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Planet()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.type.Planet"))
        return;
      Planet.intersectResult = new Vec3();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      private readonly Planet arg\u00241;

      internal __\u003C\u003EAnon0([In] Planet obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatf
    {
      private readonly Vec3 arg\u00241;

      internal __\u003C\u003EAnon1([In] Vec3 obj0) => this.arg\u00241 = obj0;

      public float get([In] object obj0) => Planet.lambda\u0024getSector\u00241(this.arg\u00241, (Sector) obj0);
    }
  }
}
