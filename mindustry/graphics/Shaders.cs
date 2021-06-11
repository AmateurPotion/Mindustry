// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.Shaders
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.files;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.g3d;
using arc.graphics.gl;
using arc.math.geom;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class Shaders : Object
  {
    public static Shaders.BlockBuildShader blockbuild;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public static Shaders.ShieldShader shield;
    public static Shaders.BuildBeamShader buildBeam;
    public static Shaders.UnitBuildShader build;
    public static Shaders.DarknessShader darkness;
    public static Shaders.LightShader light;
    public static Shaders.SurfaceShader water;
    public static Shaders.SurfaceShader mud;
    public static Shaders.SurfaceShader tar;
    public static Shaders.SurfaceShader slag;
    public static Shaders.SurfaceShader space;
    public static Shaders.PlanetShader planet;
    public static Shaders.PlanetGridShader planetGrid;
    public static Shaders.AtmosphereShader atmosphere;
    public static Shaders.MeshShader mesh;
    public static Shader unlit;
    public static Shader screenspace;

    [LineNumberTable(new byte[] {159, 175, 106, 138, 252, 69, 226, 60, 129, 102, 134, 106, 106, 106, 106, 111, 111, 111, 111, 111, 106, 106, 106, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init()
    {
      Shaders.mesh = new Shaders.MeshShader();
      Shaders.blockbuild = new Shaders.BlockBuildShader();
      Exception exception1;
      try
      {
        Shaders.shield = new Shaders.ShieldShader();
        goto label_4;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      Shaders.shield = (Shaders.ShieldShader) null;
      Throwable.instancehelper_printStackTrace(exception2);
label_4:
      Shaders.buildBeam = new Shaders.BuildBeamShader();
      Shaders.build = new Shaders.UnitBuildShader();
      Shaders.darkness = new Shaders.DarknessShader();
      Shaders.light = new Shaders.LightShader();
      Shaders.water = new Shaders.SurfaceShader("water");
      Shaders.mud = new Shaders.SurfaceShader("mud");
      Shaders.tar = new Shaders.SurfaceShader("tar");
      Shaders.slag = new Shaders.SurfaceShader("slag");
      Shaders.space = (Shaders.SurfaceShader) new Shaders.SpaceShader("space");
      Shaders.planet = new Shaders.PlanetShader();
      Shaders.planetGrid = new Shaders.PlanetGridShader();
      Shaders.atmosphere = new Shaders.AtmosphereShader();
      Shaders.unlit = (Shader) new Shaders.LoadShader("planet", "unlit");
      Shaders.screenspace = (Shader) new Shaders.LoadShader("screenspace", "screenspace");
    }

    [LineNumberTable(291)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Fi getShaderFi(string file) => Core.files.@internal(new StringBuilder().append("shaders/").append(file).toString());

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Shaders()
    {
    }

    public class AtmosphereShader : Shaders.LoadShader
    {
      public Camera3D camera;
      public Planet planet;
      internal Mat3D mat;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {15, 242, 61, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AtmosphereShader()
        : base("atmosphere", "atmosphere")
      {
        Shaders.AtmosphereShader atmosphereShader = this;
        this.mat = new Mat3D();
      }

      [LineNumberTable(new byte[] {20, 159, 2, 119, 118, 127, 17, 118, 127, 28, 127, 4, 159, 4, 127, 2, 123, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply()
      {
        this.setUniformf("u_resolution", (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
        this.setUniformf("u_time", Time.globalTime / 10f);
        this.setUniformf("u_campos", this.camera.__\u003C\u003Eposition);
        this.setUniformf("u_rcampos", Tmp.__\u003C\u003Ev31.set(this.camera.__\u003C\u003Eposition).sub(this.planet.position));
        this.setUniformf("u_light", this.planet.getLightNormal());
        this.setUniformf("u_color", this.planet.atmosphereColor.r, this.planet.atmosphereColor.g, this.planet.atmosphereColor.b);
        this.setUniformf("u_innerRadius", this.planet.radius + this.planet.atmosphereRadIn);
        this.setUniformf("u_outerRadius", this.planet.radius + this.planet.atmosphereRadOut);
        this.setUniformMatrix4("u_model", this.planet.getTransform(this.mat).__\u003C\u003Eval);
        this.setUniformMatrix4("u_projection", this.camera.__\u003C\u003Ecombined.__\u003C\u003Eval);
        this.setUniformMatrix4("u_invproj", this.camera.__\u003C\u003EinvProjectionView.__\u003C\u003Eval);
      }

      [HideFromJava]
      static AtmosphereShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }

    public class BlockBuildShader : Shaders.LoadShader
    {
      public float progress;
      public TextureRegion region;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {124, 242, 61, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BlockBuildShader()
        : base("blockbuild", "default")
      {
        Shaders.BlockBuildShader blockBuildShader = this;
        this.region = new TextureRegion();
      }

      [LineNumberTable(new byte[] {160, 65, 113, 127, 2, 127, 2, 112, 127, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply()
      {
        this.setUniformf("u_progress", this.progress);
        this.setUniformf("u_uv", this.region.u, this.region.v);
        this.setUniformf("u_uv2", this.region.u2, this.region.v2);
        this.setUniformf("u_time", Time.time);
        this.setUniformf("u_texsize", (float) this.region.texture.width, (float) this.region.texture.height);
      }

      [HideFromJava]
      static BlockBuildShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }

    public class BuildBeamShader : Shaders.LoadShader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 94, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BuildBeamShader()
        : base("buildbeam", "screenspace")
      {
      }

      [LineNumberTable(new byte[] {160, 99, 118, 125, 191, 48, 127, 0, 127, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply()
      {
        this.setUniformf("u_dp", Scl.scl(1f));
        this.setUniformf("u_time", Time.time / Scl.scl(1f));
        this.setUniformf("u_offset", Core.camera.__\u003C\u003Eposition.x - Core.camera.width / 2f, Core.camera.__\u003C\u003Eposition.y - Core.camera.height / 2f);
        this.setUniformf("u_texsize", Core.camera.width, Core.camera.height);
        this.setUniformf("u_invsize", 1f / Core.camera.width, 1f / Core.camera.height);
      }

      [HideFromJava]
      static BuildBeamShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }

    public class DarknessShader : Shaders.LoadShader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {91, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DarknessShader()
        : base("darkness", "default")
      {
      }

      [HideFromJava]
      static DarknessShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }

    public class LightShader : Shaders.LoadShader
    {
      public Color ambient;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {79, 242, 61, 223, 0})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LightShader()
        : base("light", "screenspace")
      {
        Shaders.LightShader lightShader = this;
        this.ambient = new Color(0.01f, 0.01f, 0.04f, 0.99f);
      }

      [LineNumberTable(new byte[] {84, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply() => this.setUniformf("u_ambient", this.ambient);

      [HideFromJava]
      static LightShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }

    public class LoadShader : Shader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 172, 127, 37})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LoadShader(string frag, string vert)
        : base(Shaders.getShaderFi(new StringBuilder().append(vert).append(".vert").toString()), Shaders.getShaderFi(new StringBuilder().append(frag).append(".frag").toString()))
      {
      }

      [HideFromJava]
      static LoadShader() => Shader.__\u003Cclinit\u003E();
    }

    public class MeshShader : Shaders.LoadShader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {58, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MeshShader()
        : base("planet", "mesh")
      {
      }

      [HideFromJava]
      static MeshShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }

    public class PlanetGridShader : Shaders.LoadShader
    {
      public Vec3 mouse;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {66, 242, 61, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlanetGridShader()
        : base("planetgrid", "planetgrid")
      {
        Shaders.PlanetGridShader planetGridShader = this;
        this.mouse = new Vec3();
      }

      [LineNumberTable(new byte[] {71, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply() => this.setUniformf("u_mouse", this.mouse);

      [HideFromJava]
      static PlanetGridShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }

    public class PlanetShader : Shaders.LoadShader
    {
      public Vec3 lightDir;
      public Color ambientColor;
      public Vec3 camDir;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {42, 242, 59, 127, 0, 112, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PlanetShader()
        : base("planet", "planet")
      {
        Shaders.PlanetShader planetShader = this;
        this.lightDir = new Vec3(1f, 1f, 1f).nor();
        this.ambientColor = Color.__\u003C\u003Ewhite.cpy();
        this.camDir = new Vec3();
      }

      [LineNumberTable(new byte[] {47, 159, 32, 113, 127, 13, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply()
      {
        this.camDir.set(Vars.renderer.planets.cam.__\u003C\u003Edirection).rotate(Vec3.__\u003C\u003EY, Vars.renderer.planets.planet.getRotation());
        this.setUniformf("u_lightdir", this.lightDir);
        this.setUniformf("u_ambientColor", this.ambientColor.r, this.ambientColor.g, this.ambientColor.b);
        this.setUniformf("u_camdir", this.camDir);
      }

      [HideFromJava]
      static PlanetShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }

    public class ShieldShader : Shaders.LoadShader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 76, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ShieldShader()
        : base("shield", "screenspace")
      {
      }

      [LineNumberTable(new byte[] {160, 81, 118, 125, 191, 48, 127, 0, 127, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply()
      {
        this.setUniformf("u_dp", Scl.scl(1f));
        this.setUniformf("u_time", Time.time / Scl.scl(1f));
        this.setUniformf("u_offset", Core.camera.__\u003C\u003Eposition.x - Core.camera.width / 2f, Core.camera.__\u003C\u003Eposition.y - Core.camera.height / 2f);
        this.setUniformf("u_texsize", Core.camera.width, Core.camera.height);
        this.setUniformf("u_invsize", 1f / Core.camera.width, 1f / Core.camera.height);
      }

      [HideFromJava]
      static ShieldShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }

    public class SpaceShader : Shaders.SurfaceShader
    {
      internal Texture texture;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 114, 137, 255, 5, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SpaceShader(string frag)
        : base(frag)
      {
        Shaders.SpaceShader spaceShader = this;
        Core.assets.load("sprites/space.png", (Class) ClassLiteral<Texture>.Value).loaded = (Cons) new Shaders.SpaceShader.__\u003C\u003EAnon0(this);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 117, 108, 112, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] object obj0)
      {
        this.texture = (Texture) obj0;
        this.texture.setFilter(Texture.TextureFilter.__\u003C\u003Elinear);
        this.texture.setWrap(Texture.TextureWrap.__\u003C\u003EmirroredRepeat);
      }

      [LineNumberTable(new byte[] {160, 125, 127, 10, 117, 127, 2, 144, 108, 154, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply()
      {
        this.setUniformf("u_campos", Core.camera.__\u003C\u003Eposition.x, Core.camera.__\u003C\u003Eposition.y);
        this.setUniformf("u_ccampos", Core.camera.__\u003C\u003Eposition);
        this.setUniformf("u_resolution", (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
        this.setUniformf("u_time", Time.time);
        this.texture.bind(1);
        Vars.renderer.effectBuffer.getTexture().bind(0);
        this.setUniformi("u_stars", 1);
      }

      [HideFromJava]
      static SpaceShader() => Shaders.SurfaceShader.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly Shaders.SpaceShader arg\u00241;

        internal __\u003C\u003EAnon0([In] Shaders.SpaceShader obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240(obj0);
      }
    }

    public class SurfaceShader : Shader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 139, 127, 18, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SurfaceShader(string frag)
        : base(Shaders.getShaderFi("screenspace.vert"), Shaders.getShaderFi(new StringBuilder().append(frag).append(".frag").toString()))
      {
        Shaders.SurfaceShader surfaceShader = this;
        this.loadNoise();
      }

      [LineNumberTable(new byte[] {160, 149, 223, 4})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void loadNoise() => Core.assets.load("sprites/noise.png", (Class) ClassLiteral<Texture>.Value).loaded = (Cons) new Shaders.SurfaceShader.__\u003C\u003EAnon0();

      [Modifiers]
      [LineNumberTable(new byte[] {160, 150, 112, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024loadNoise\u00240([In] object obj0)
      {
        ((GLTexture) obj0).setFilter(Texture.TextureFilter.__\u003C\u003Elinear);
        ((GLTexture) obj0).setWrap(Texture.TextureWrap.__\u003C\u003Erepeat);
      }

      [LineNumberTable(new byte[] {160, 144, 106, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SurfaceShader(string vertRaw, string fragRaw)
        : base(vertRaw, fragRaw)
      {
        Shaders.SurfaceShader surfaceShader = this;
        this.loadNoise();
      }

      [LineNumberTable(new byte[] {160, 157, 127, 48, 127, 0, 144, 109, 127, 0, 154, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply()
      {
        this.setUniformf("u_campos", Core.camera.__\u003C\u003Eposition.x - Core.camera.width / 2f, Core.camera.__\u003C\u003Eposition.y - Core.camera.height / 2f);
        this.setUniformf("u_resolution", Core.camera.width, Core.camera.height);
        this.setUniformf("u_time", Time.time);
        if (!this.hasUniform("u_noise"))
          return;
        ((GLTexture) Core.assets.get("sprites/noise.png", (Class) ClassLiteral<Texture>.Value)).bind(1);
        Vars.renderer.effectBuffer.getTexture().bind(0);
        this.setUniformi("u_noise", 1);
      }

      [HideFromJava]
      static SurfaceShader() => Shader.__\u003Cclinit\u003E();

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Cons
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public void get([In] object obj0) => Shaders.SurfaceShader.lambda\u0024loadNoise\u00240(obj0);
      }
    }

    [Obsolete]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    public class UnitBuild : Shaders.UnitBuildShader
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(147)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitBuild()
      {
      }

      [HideFromJava]
      static UnitBuild() => Shaders.UnitBuildShader.__\u003Cclinit\u003E();
    }

    public class UnitBuildShader : Shaders.LoadShader
    {
      public float progress;
      public float time;
      public Color color;
      public TextureRegion region;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {105, 242, 60, 235, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitBuildShader()
        : base("unitbuild", "default")
      {
        Shaders.UnitBuildShader unitBuildShader = this;
        this.color = new Color();
      }

      [LineNumberTable(new byte[] {110, 113, 113, 113, 127, 2, 127, 2, 127, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply()
      {
        this.setUniformf("u_time", this.time);
        this.setUniformf("u_color", this.color);
        this.setUniformf("u_progress", this.progress);
        this.setUniformf("u_uv", this.region.u, this.region.v);
        this.setUniformf("u_uv2", this.region.u2, this.region.v2);
        this.setUniformf("u_texsize", (float) this.region.texture.width, (float) this.region.texture.height);
      }

      [HideFromJava]
      static UnitBuildShader() => Shaders.LoadShader.__\u003Cclinit\u003E();
    }
  }
}
