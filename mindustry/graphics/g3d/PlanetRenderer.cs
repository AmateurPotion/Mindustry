// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.g3d.PlanetRenderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.g3d;
using arc.graphics.gl;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.game;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics.g3d
{
  public class PlanetRenderer : Object, Disposable
  {
    public const float outlineRad = 1.17f;
    public const float camLength = 4f;
    internal static Color __\u003C\u003EoutlineColor;
    internal static Color __\u003C\u003EhoverColor;
    internal static Color __\u003C\u003EborderColor;
    internal static Color __\u003C\u003EshadowColor;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/math/geom/Vec3;>;")]
    private static Seq points;
    internal Vec3 __\u003C\u003EcamPos;
    internal Planet __\u003C\u003EsolarSystem;
    public Planet planet;
    public Camera3D cam;
    internal VertexBatch3D __\u003C\u003Ebatch;
    public float zoom;
    public float orbitAlpha;
    [Modifiers]
    private Mesh[] outlines;
    internal PlaneBatch3D __\u003C\u003Eprojector;
    internal Mat3D __\u003C\u003Emat;
    internal FrameBuffer __\u003C\u003Ebuffer;
    public PlanetRenderer.PlanetInterfaceRenderer irenderer;
    internal Bloom __\u003C\u003Ebloom;
    internal Mesh __\u003C\u003Eatmosphere;
    internal CubemapMesh __\u003C\u003Eskybox;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {7, 232, 36, 139, 139, 139, 139, 147, 107, 139, 109, 107, 107, 174, 223, 7, 183, 186, 123, 112, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PlanetRenderer()
    {
      PlanetRenderer planetRenderer = this;
      this.__\u003C\u003EcamPos = new Vec3();
      this.__\u003C\u003EsolarSystem = Planets.sun;
      this.planet = Planets.serpulo;
      this.cam = new Camera3D();
      this.__\u003C\u003Ebatch = new VertexBatch3D(20000, false, true, 0);
      this.zoom = 1f;
      this.orbitAlpha = 1f;
      this.outlines = new Mesh[10];
      this.__\u003C\u003Eprojector = new PlaneBatch3D();
      this.__\u003C\u003Emat = new Mat3D();
      this.__\u003C\u003Ebuffer = new FrameBuffer(2, 2, true);
      this.__\u003C\u003Ebloom = (Bloom) new PlanetRenderer.\u0031(this, Core.graphics.getWidth() / 4, Core.graphics.getHeight() / 4, true, false);
      this.__\u003C\u003Eatmosphere = MeshBuilder.buildHex(Color.__\u003C\u003Ewhite, 2, false, 1.5f);
      CubemapMesh.__\u003Cclinit\u003E();
      this.__\u003C\u003Eskybox = new CubemapMesh(new Cubemap("cubemaps/stars/"));
      this.__\u003C\u003EcamPos.set(0.0f, 0.0f, 4f);
      this.__\u003C\u003Eprojector.setScaling(0.006666667f);
      this.cam.fov = 60f;
      this.cam.far = 150f;
    }

    [LineNumberTable(new byte[] {73, 127, 4, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginBloom()
    {
      this.__\u003C\u003Ebloom.resize(Core.graphics.getWidth() / 4, Core.graphics.getHeight() / 4);
      this.__\u003C\u003Ebloom.capture();
    }

    [LineNumberTable(new byte[] {83, 169, 157, 135, 127, 1, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderPlanet(Planet planet)
    {
      if (!planet.visible())
        return;
      planet.draw(this.cam.__\u003C\u003Ecombined, planet.getTransform(this.__\u003C\u003Emat));
      this.renderOrbit(planet);
      Iterator iterator = planet.children.iterator();
      while (iterator.hasNext())
        this.renderPlanet((Planet) iterator.next());
    }

    [LineNumberTable(new byte[] {96, 137, 118, 167, 127, 5, 134, 138, 112, 107, 106, 138, 145, 138, 166, 127, 1, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderTransparent(Planet planet)
    {
      if (!planet.visible())
        return;
      if (planet.isLandable() && object.ReferenceEquals((object) planet, (object) this.planet))
        this.renderSectors(planet);
      if (planet.parent != null && planet.hasAtmosphere && Core.settings.getBool("atmosphere"))
      {
        Gl.depthMask(false);
        Blending.__\u003C\u003Eadditive.apply();
        Shaders.atmosphere.camera = this.cam;
        Shaders.atmosphere.planet = planet;
        Shaders.atmosphere.bind();
        Shaders.atmosphere.apply();
        this.__\u003C\u003Eatmosphere.render((Shader) Shaders.atmosphere, 4);
        Blending.__\u003C\u003Enormal.apply();
        Gl.depthMask(true);
      }
      Iterator iterator = planet.children.iterator();
      while (iterator.hasNext())
        this.renderTransparent((Planet) iterator.next());
    }

    [LineNumberTable(new byte[] {78, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void endBloom() => this.__\u003C\u003Ebloom.render();

    [LineNumberTable(new byte[] {125, 145, 108, 103, 110, 115, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderOrbit(Planet planet)
    {
      if (planet.parent == null || !planet.visible())
        return;
      Vec3 position = planet.parent.position;
      float orbitRadius = planet.orbitRadius;
      Angles.circleVectors(ByteCodeHelper.f2i(orbitRadius * 10f), orbitRadius, (Floatc2) new PlanetRenderer.__\u003C\u003EAnon0(this, position));
      this.__\u003C\u003Ebatch.flush(2);
    }

    [LineNumberTable(new byte[] {160, 72, 157, 172, 114, 102, 119, 159, 29, 102, 123, 124, 102, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderSectors(Planet planet)
    {
      this.__\u003C\u003Ebatch.proj().mul(planet.getTransform(this.__\u003C\u003Emat));
      this.irenderer.renderSectors(planet);
      Mesh mesh = this.outline(planet.grid.size);
      Shaders.PlanetGridShader planetGrid = Shaders.planetGrid;
      Vec3 vec3 = planet.intersect(this.cam.getMouseRay(), 1.17f);
      Shaders.planetGrid.mouse.lerp(vec3 != null ? vec3.sub(planet.position).rotate(Vec3.__\u003C\u003EY, planet.getRotation()) : Vec3.__\u003C\u003EZero, 0.2f);
      planetGrid.bind();
      planetGrid.setUniformMatrix4("u_proj", this.cam.__\u003C\u003Ecombined.__\u003C\u003Eval);
      planetGrid.setUniformMatrix4("u_trans", planet.getTransform(this.__\u003C\u003Emat).__\u003C\u003Eval);
      planetGrid.apply();
      mesh.render((Shader) planetGrid, 1);
    }

    [LineNumberTable(new byte[] {160, 198, 106, 255, 0, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mesh outline(int size)
    {
      if (this.outlines[size] == null)
        this.outlines[size] = MeshBuilder.buildHex((HexMesher) new PlanetRenderer.\u0032(this), size, true, 1.17f, 0.2f);
      return this.outlines[size];
    }

    [LineNumberTable(new byte[] {160, 93, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawArc(
      Planet planet,
      Vec3 a,
      Vec3 b,
      Color from,
      Color to,
      float length)
    {
      this.drawArc(planet, a, b, from, to, length, 80f, 25);
    }

    [LineNumberTable(new byte[] {160, 97, 124, 153, 107, 127, 42, 144, 105, 104, 127, 9, 112, 255, 1, 60, 233, 71, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawArc(
      Planet planet,
      Vec3 a,
      Vec3 b,
      Color from,
      Color to,
      float length,
      float timeScale,
      int pointCount)
    {
      Tmp.__\u003C\u003Ev31.set(b).add(a).scl(0.5f).setLength(planet.radius * (1f + length));
      PlanetRenderer.points.clear();
      PlanetRenderer.points.addAll((object[]) new Vec3[3]
      {
        Tmp.__\u003C\u003Ev33.set(b).setLength(1.17f),
        Tmp.__\u003C\u003Ev31,
        Tmp.__\u003C\u003Ev34.set(a).setLength(1.17f)
      });
      Tmp.__\u003C\u003Ebz3.set(PlanetRenderer.points);
      for (int index = 0; index < pointCount + 1; ++index)
      {
        float t = (float) index / (float) pointCount;
        Tmp.__\u003C\u003Ec1.set(from).lerp(to, (t + Time.globalTime / timeScale) % 1f);
        this.__\u003C\u003Ebatch.color(Tmp.__\u003C\u003Ec1);
        this.__\u003C\u003Ebatch.vertex((Vec3) Tmp.__\u003C\u003Ebz3.valueAt((Vector) Tmp.__\u003C\u003Ev32, t));
      }
      this.__\u003C\u003Ebatch.flush(3);
    }

    [LineNumberTable(new byte[] {160, 175, 139, 116, 127, 7, 142, 109, 109, 146, 127, 50, 159, 50, 125, 156, 121, 116, 244, 48, 233, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawSelection(Sector sector, Color color, float stroke, float length)
    {
      float scalar = 1.17f + length;
      for (int index1 = 0; index1 < sector.__\u003C\u003Etile.corners.Length; ++index1)
      {
        PlanetGrid.Corner[] corners = sector.__\u003C\u003Etile.corners;
        int num = index1 + 1;
        int length1 = sector.__\u003C\u003Etile.corners.Length;
        int index2 = length1 != -1 ? num % length1 : 0;
        PlanetGrid.Corner corner1 = corners[index2];
        PlanetGrid.Corner corner2 = sector.__\u003C\u003Etile.corners[index1];
        corner1.v.scl(scalar);
        corner2.v.scl(scalar);
        sector.__\u003C\u003Etile.v.scl(scalar);
        Tmp.__\u003C\u003Ev31.set(corner2.v).sub(sector.__\u003C\u003Etile.v).setLength(corner2.v.dst(sector.__\u003C\u003Etile.v) - stroke).add(sector.__\u003C\u003Etile.v);
        Tmp.__\u003C\u003Ev32.set(corner1.v).sub(sector.__\u003C\u003Etile.v).setLength(corner1.v.dst(sector.__\u003C\u003Etile.v) - stroke).add(sector.__\u003C\u003Etile.v);
        this.__\u003C\u003Ebatch.tri(corner2.v, corner1.v, Tmp.__\u003C\u003Ev31, color);
        this.__\u003C\u003Ebatch.tri(Tmp.__\u003C\u003Ev31, corner1.v, Tmp.__\u003C\u003Ev32, color);
        sector.__\u003C\u003Etile.v.scl(1f / scalar);
        corner1.v.scl(1f / scalar);
        corner2.v.scl(1f / scalar);
      }
    }

    [LineNumberTable(new byte[] {160, 149, 110, 134, 150, 159, 36, 159, 31, 255, 55, 58, 229, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPlane(Sector sector)
    {
      float degrees = -this.planet.getRotation();
      float num = 0.01f;
      this.__\u003C\u003Eprojector.setPlane(Tmp.__\u003C\u003Ev33.set(sector.__\u003C\u003Etile.v).setLength(1.17f + num).rotate(Vec3.__\u003C\u003EY, degrees).add(this.planet.position), sector.__\u003C\u003Eplane.project(Tmp.__\u003C\u003Ev32.set(sector.__\u003C\u003Etile.v).add(Vec3.__\u003C\u003EY)).sub(sector.__\u003C\u003Etile.v).rotate(Vec3.__\u003C\u003EY, degrees).nor(), Tmp.__\u003C\u003Ev31.set(Tmp.__\u003C\u003Ev32).rotate(Vec3.__\u003C\u003EY, -degrees).add(sector.__\u003C\u003Etile.v).rotate(sector.__\u003C\u003Etile.v, 90f).sub(sector.__\u003C\u003Etile.v).rotate(Vec3.__\u003C\u003EY, degrees).nor());
    }

    [Modifiers]
    [LineNumberTable(180)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024renderOrbit\u00240([In] Vec3 obj0, [In] float obj1, [In] float obj2) => this.__\u003C\u003Ebatch.vertex(Tmp.__\u003C\u003Ev32.set(obj0).add(obj1, 0.0f, obj2), Pal.gray.write(Tmp.__\u003C\u003Ec1).a(this.orbitAlpha));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 143, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawPlane\u00241([In] Sector obj0, [In] Runnable obj1)
    {
      this.setPlane(obj0);
      obj1.run();
    }

    [LineNumberTable(new byte[] {16, 135, 101, 106, 106, 134, 106, 170, 150, 127, 2, 127, 34, 127, 8, 118, 139, 118, 150, 138, 166, 118, 113, 139, 150, 114, 139, 138, 140, 140, 134, 138, 138, 140, 106, 138, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(PlanetRenderer.PlanetInterfaceRenderer irenderer)
    {
      this.irenderer = irenderer;
      Draw.flush();
      Gl.clear(256);
      Gl.enable(2929);
      Gl.depthMask(true);
      Gl.enable(2884);
      Gl.cullFace(1029);
      this.cam.__\u003C\u003Eup.set(Vec3.__\u003C\u003EY);
      this.cam.resize((float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      this.__\u003C\u003EcamPos.setLength(this.planet.radius * 4f + (this.zoom - 1f) * this.planet.radius * 2f);
      this.cam.__\u003C\u003Eposition.set(this.planet.position).add(this.__\u003C\u003EcamPos);
      this.cam.lookAt(this.planet.position);
      this.cam.update();
      this.__\u003C\u003Eprojector.proj(this.cam.__\u003C\u003Ecombined);
      this.__\u003C\u003Ebatch.proj(this.cam.__\u003C\u003Ecombined);
      Events.fire((object) EventType.Trigger.__\u003C\u003EuniverseDrawBegin);
      this.beginBloom();
      Vec3 vector = Tmp.__\u003C\u003Ev31.set(this.cam.__\u003C\u003Eposition);
      this.cam.__\u003C\u003Eposition.setZero();
      this.cam.update();
      this.__\u003C\u003Eskybox.render(this.cam.__\u003C\u003Ecombined);
      this.cam.__\u003C\u003Eposition.set(vector);
      this.cam.update();
      Events.fire((object) EventType.Trigger.__\u003C\u003EuniverseDraw);
      this.renderPlanet(this.__\u003C\u003EsolarSystem);
      this.renderTransparent(this.__\u003C\u003EsolarSystem);
      this.endBloom();
      Events.fire((object) EventType.Trigger.__\u003C\u003EuniverseDrawEnd);
      Gl.enable(3042);
      irenderer.renderProjections(this.planet);
      Gl.disable(2884);
      Gl.disable(2929);
      this.cam.update();
    }

    [LineNumberTable(new byte[] {160, 90, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawArc(Planet planet, Vec3 a, Vec3 b) => this.drawArc(planet, a, b, Pal.accent, Color.__\u003C\u003Eclear, 1f);

    [LineNumberTable(new byte[] {160, 115, 159, 22, 102, 134, 116, 159, 23, 120, 120, 152, 155, 120, 120, 152, 251, 51, 233, 80, 123, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBorders(Sector sector, Color @base)
    {
      Color color = Tmp.__\u003C\u003Ec1.set(@base).a(@base.a + 0.3f + Mathf.absin(Time.globalTime, 5f, 0.3f));
      float len1 = 1f;
      float len2 = 1.171f;
      for (int index1 = 0; index1 < sector.__\u003C\u003Etile.corners.Length; ++index1)
      {
        PlanetGrid.Corner corner1 = sector.__\u003C\u003Etile.corners[index1];
        PlanetGrid.Corner[] corners = sector.__\u003C\u003Etile.corners;
        int num = index1 + 1;
        int length = sector.__\u003C\u003Etile.corners.Length;
        int index2 = length != -1 ? num % length : 0;
        PlanetGrid.Corner corner2 = corners[index2];
        Tmp.__\u003C\u003Ev31.set(corner1.v).setLength(len2);
        Tmp.__\u003C\u003Ev32.set(corner2.v).setLength(len2);
        Tmp.__\u003C\u003Ev33.set(corner1.v).setLength(len1);
        this.__\u003C\u003Ebatch.tri2(Tmp.__\u003C\u003Ev31, Tmp.__\u003C\u003Ev32, Tmp.__\u003C\u003Ev33, color);
        Tmp.__\u003C\u003Ev31.set(corner2.v).setLength(len2);
        Tmp.__\u003C\u003Ev32.set(corner2.v).setLength(len1);
        Tmp.__\u003C\u003Ev33.set(corner1.v).setLength(len1);
        this.__\u003C\u003Ebatch.tri2(Tmp.__\u003C\u003Ev31, Tmp.__\u003C\u003Ev32, Tmp.__\u003C\u003Ev33, color);
      }
      if (this.__\u003C\u003Ebatch.getNumVertices() < this.__\u003C\u003Ebatch.getMaxVertices() - 36)
        return;
      this.__\u003C\u003Ebatch.flush(4);
    }

    [LineNumberTable(new byte[] {160, 142, 216})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPlane(Sector sector, Runnable run) => Draw.batch((Batch) this.__\u003C\u003Eprojector, (Runnable) new PlanetRenderer.__\u003C\u003EAnon1(this, sector, run));

    [LineNumberTable(new byte[] {160, 163, 106, 116, 127, 21, 31, 52, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fill(Sector sector, Color color, float offset)
    {
      float len = 1.17f + offset;
      for (int index1 = 0; index1 < sector.__\u003C\u003Etile.corners.Length; ++index1)
      {
        PlanetGrid.Corner corner1 = sector.__\u003C\u003Etile.corners[index1];
        PlanetGrid.Corner[] corners = sector.__\u003C\u003Etile.corners;
        int num = index1 + 1;
        int length = sector.__\u003C\u003Etile.corners.Length;
        int index2 = length != -1 ? num % length : 0;
        PlanetGrid.Corner corner2 = corners[index2];
        this.__\u003C\u003Ebatch.tri(Tmp.__\u003C\u003Ev31.set(corner1.v).setLength(len), Tmp.__\u003C\u003Ev32.set(corner2.v).setLength(len), Tmp.__\u003C\u003Ev33.set(sector.__\u003C\u003Etile.v).setLength(len), color);
      }
    }

    [LineNumberTable(new byte[] {160, 171, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawSelection(Sector sector) => this.drawSelection(sector, Pal.accent, 0.04f, 1f / 1000f);

    [LineNumberTable(new byte[] {160, 216, 107, 107, 107, 107, 107, 107, 116, 99, 6, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.__\u003C\u003Eskybox.dispose();
      this.__\u003C\u003Ebatch.dispose();
      this.__\u003C\u003Eprojector.dispose();
      this.__\u003C\u003Eatmosphere.dispose();
      this.__\u003C\u003Ebuffer.dispose();
      this.__\u003C\u003Ebloom.dispose();
      Mesh[] outlines = this.outlines;
      int length = outlines.Length;
      for (int index = 0; index < length; ++index)
        outlines[index]?.dispose();
    }

    [LineNumberTable(new byte[] {159, 137, 109, 121, 121, 121, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static PlanetRenderer()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.g3d.PlanetRenderer"))
        return;
      PlanetRenderer.__\u003C\u003EoutlineColor = Pal.accent.cpy().a(1f);
      PlanetRenderer.__\u003C\u003EhoverColor = Pal.accent.cpy().a(0.5f);
      PlanetRenderer.__\u003C\u003EborderColor = Pal.accent.cpy().a(0.3f);
      PlanetRenderer.__\u003C\u003EshadowColor = new Color(0.0f, 0.0f, 0.0f, 0.7f);
      PlanetRenderer.points = new Seq();
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [Modifiers]
    public static Color outlineColor
    {
      [HideFromJava] get => PlanetRenderer.__\u003C\u003EoutlineColor;
    }

    [Modifiers]
    public static Color hoverColor
    {
      [HideFromJava] get => PlanetRenderer.__\u003C\u003EhoverColor;
    }

    [Modifiers]
    public static Color borderColor
    {
      [HideFromJava] get => PlanetRenderer.__\u003C\u003EborderColor;
    }

    [Modifiers]
    public static Color shadowColor
    {
      [HideFromJava] get => PlanetRenderer.__\u003C\u003EshadowColor;
    }

    [Modifiers]
    public Vec3 camPos
    {
      [HideFromJava] get => this.__\u003C\u003EcamPos;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EcamPos = value;
    }

    [Modifiers]
    public Planet solarSystem
    {
      [HideFromJava] get => this.__\u003C\u003EsolarSystem;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EsolarSystem = value;
    }

    [Modifiers]
    public VertexBatch3D batch
    {
      [HideFromJava] get => this.__\u003C\u003Ebatch;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebatch = value;
    }

    [Modifiers]
    public PlaneBatch3D projector
    {
      [HideFromJava] get => this.__\u003C\u003Eprojector;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eprojector = value;
    }

    [Modifiers]
    public Mat3D mat
    {
      [HideFromJava] get => this.__\u003C\u003Emat;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emat = value;
    }

    [Modifiers]
    public FrameBuffer buffer
    {
      [HideFromJava] get => this.__\u003C\u003Ebuffer;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebuffer = value;
    }

    [Modifiers]
    public Bloom bloom
    {
      [HideFromJava] get => this.__\u003C\u003Ebloom;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebloom = value;
    }

    [Modifiers]
    public Mesh atmosphere
    {
      [HideFromJava] get => this.__\u003C\u003Eatmosphere;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eatmosphere = value;
    }

    [Modifiers]
    public CubemapMesh skybox
    {
      [HideFromJava] get => this.__\u003C\u003Eskybox;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eskybox = value;
    }

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0031 : Bloom
    {
      [Modifiers]
      internal PlanetRenderer this\u00240;

      [LineNumberTable(new byte[] {159, 130, 70, 115, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] PlanetRenderer obj0, [In] int obj1, [In] int obj2, [In] bool obj3, [In] bool obj4)
      {
        int num1 = obj3 ? 1 : 0;
        int num2 = obj4 ? 1 : 0;
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, num1 != 0, num2 != 0);
        PlanetRenderer.\u0031 obj = this;
        this.setThreshold(0.8f);
        this.blurPasses = 6;
      }
    }

    [EnclosingMethod(null, "outline", "(I)Larc.graphics.Mesh;")]
    [SpecialName]
    internal class \u0032 : Object, HexMesher
    {
      [Modifiers]
      internal PlanetRenderer this\u00240;

      [LineNumberTable(313)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] PlanetRenderer obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float getHeight([In] Vec3 obj0) => 0.0f;

      [LineNumberTable(321)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Color getColor([In] Vec3 obj0) => PlanetRenderer.__\u003C\u003EoutlineColor;
    }

    public interface PlanetInterfaceRenderer
    {
      void renderProjections(Planet p);

      void renderSectors(Planet p);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatc2
    {
      private readonly PlanetRenderer arg\u00241;
      private readonly Vec3 arg\u00242;

      internal __\u003C\u003EAnon0([In] PlanetRenderer obj0, [In] Vec3 obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] float obj0, [In] float obj1) => this.arg\u00241.lambda\u0024renderOrbit\u00240(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly PlanetRenderer arg\u00241;
      private readonly Sector arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon1([In] PlanetRenderer obj0, [In] Sector obj1, [In] Runnable obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024drawPlane\u00241(this.arg\u00242, this.arg\u00243);
    }
  }
}
