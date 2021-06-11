// Decompiled with JetBrains decompiler
// Type: mindustry.core.Renderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.files;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.math;
using arc.math.geom;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using java.util;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.graphics.g3d;
using mindustry.ui;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  public class Renderer : Object, ApplicationListener
  {
    public static float laserOpacity;
    public static float bridgeOpacity;
    internal BlockRenderer __\u003C\u003Eblocks;
    internal MinimapRenderer __\u003C\u003Eminimap;
    internal OverlayRenderer __\u003C\u003Eoverlays;
    internal LightRenderer __\u003C\u003Elights;
    internal Pixelator __\u003C\u003Epixelator;
    public PlanetRenderer planets;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Bloom bloom;
    public FrameBuffer effectBuffer;
    public bool animateShields;
    public bool drawWeather;
    public bool drawStatus;
    public float minZoom;
    public float maxZoom;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private CoreBlock.CoreBuild landCore;
    private Color clearColor;
    private float targetscale;
    private float camerascale;
    private float landscale;
    private float landTime;
    private float weatherAlpha;
    private float minZoomScl;
    private float shakeIntensity;
    private float shaketime;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 186, 232, 46, 107, 107, 107, 107, 203, 107, 135, 182, 127, 0, 223, 15, 106, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Renderer()
    {
      Renderer renderer = this;
      this.__\u003C\u003Eblocks = new BlockRenderer();
      this.__\u003C\u003Eminimap = new MinimapRenderer();
      this.__\u003C\u003Eoverlays = new OverlayRenderer();
      this.__\u003C\u003Elights = new LightRenderer();
      this.__\u003C\u003Epixelator = new Pixelator();
      this.effectBuffer = new FrameBuffer();
      this.drawWeather = true;
      this.minZoom = 1.5f;
      this.maxZoom = 6f;
      this.clearColor = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.targetscale = Scl.scl(4f);
      this.camerascale = this.targetscale;
      this.minZoomScl = Scl.scl(0.01f);
      Core.camera = new Camera();
      Shaders.init();
    }

    [LineNumberTable(292)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float minScale() => Scl.scl(this.minZoom);

    [LineNumberTable(new byte[] {160, 200, 122, 146, 112, 111, 161, 136, 103, 127, 27, 102, 108, 108, 127, 0, 127, 0, 102, 102, 102, 102, 108, 108, 116, 102, 108, 106, 40, 168, 102, 110, 114, 127, 21, 105, 103, 127, 10, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void takeMapScreenshot()
    {
      int num1 = Vars.world.width() * 8;
      int num2 = Vars.world.height() * 8;
      if (num1 * num2 * 4 / 1024 / 1024 >= (!Vars.mobile ? 120 : 65))
      {
        Vars.ui.showInfo("@screenshot.invalid");
      }
      else
      {
        FrameBuffer frameBuffer = new FrameBuffer(num1, num2);
        this.drawWeather = false;
        float width = Core.camera.width;
        float height = Core.camera.height;
        float x = Core.camera.__\u003C\u003Eposition.x;
        float y = Core.camera.__\u003C\u003Eposition.y;
        Vars.disableUI = true;
        Core.camera.width = (float) num1;
        Core.camera.height = (float) num2;
        Core.camera.__\u003C\u003Eposition.x = (float) num1 / 2f + 4f;
        Core.camera.__\u003C\u003Eposition.y = (float) num2 / 2f + 4f;
        frameBuffer.begin();
        this.draw();
        frameBuffer.end();
        Vars.disableUI = false;
        Core.camera.width = width;
        Core.camera.height = height;
        Core.camera.__\u003C\u003Eposition.set(x, y);
        frameBuffer.begin();
        byte[] frameBufferPixels = ScreenUtils.getFrameBufferPixels(0, 0, num1, num2, true);
        for (int index = 0; index < frameBufferPixels.Length; index += 4)
          frameBufferPixels[index + 3] = byte.MaxValue;
        frameBuffer.end();
        Pixmap pixmap = new Pixmap(num1, num2, Pixmap.Format.__\u003C\u003Ergba8888);
        Buffers.copy(frameBufferPixels, 0, (Buffer) pixmap.getPixels(), frameBufferPixels.Length);
        Fi file = Vars.screenshotDirectory.child(new StringBuilder().append("screenshot-").append(Time.millis()).append(".png").toString());
        PixmapIO.writePNG(file, pixmap);
        pixmap.dispose();
        Vars.ui.showInfoFade(Core.bundle.format("screenshot", (object) file.toString()));
        this.drawWeather = true;
        frameBuffer.dispose();
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void zoomIn(float duration)
    {
      this.landscale = this.minZoomScl;
      this.landTime = duration;
    }

    [LineNumberTable(new byte[] {80, 104, 107, 135, 254, 69, 226, 60, 97, 117, 111, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setupBloom()
    {
      Exception exception;
      try
      {
        if (this.bloom != null)
        {
          this.bloom.dispose();
          this.bloom = (Bloom) null;
        }
        this.bloom = new Bloom(true);
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception th = exception;
      Core.settings.put("bloom", (object) Boolean.valueOf(false));
      Vars.ui.showErrorMessage("@error.bloom");
      Log.err(th);
    }

    [LineNumberTable(new byte[] {106, 112, 127, 6, 126, 122, 115, 124, 98, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void updateShake([In] float obj0)
    {
      if ((double) this.shaketime > 0.0)
      {
        float range = this.shakeIntensity * ((float) Core.settings.getInt("screenshake", 4) / 4f) * obj0;
        Core.camera.__\u003C\u003Eposition.add(Mathf.range(range), Mathf.range(range));
        this.shakeIntensity -= 0.25f * Time.delta;
        this.shaketime -= Time.delta;
        this.shakeIntensity = Mathf.clamp(this.shakeIntensity, 0.0f, 100f);
      }
      else
        this.shakeIntensity = 0.0f;
    }

    [LineNumberTable(new byte[] {118, 138, 138, 127, 13, 181, 112, 133, 121, 191, 0, 138, 112, 139, 134, 138, 109, 171, 117, 127, 7, 127, 2, 245, 70, 158, 113, 191, 2, 103, 191, 2, 104, 127, 4, 127, 2, 191, 2, 159, 2, 111, 255, 6, 69, 255, 6, 70, 127, 2, 149, 139, 148, 101, 101, 134, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      Events.fire((object) EventType.Trigger.__\u003C\u003EpreDraw);
      Core.camera.update();
      if (Float.isNaN(Core.camera.__\u003C\u003Eposition.x) || Float.isNaN(Core.camera.__\u003C\u003Eposition.y))
        Core.camera.__\u003C\u003Eposition.set((Position) Vars.player);
      Core.graphics.clear(this.clearColor);
      Draw.reset();
      if (Core.settings.getBool("animatedwater") || this.animateShields)
        this.effectBuffer.resize(Core.graphics.getWidth(), Core.graphics.getHeight());
      Draw.proj(Core.camera);
      this.__\u003C\u003Eblocks.__\u003C\u003Efloor.checkChanges();
      this.__\u003C\u003Eblocks.processBlocks();
      Draw.sort(true);
      Events.fire((object) EventType.Trigger.__\u003C\u003Edraw);
      if (this.__\u003C\u003Epixelator.enabled())
        this.__\u003C\u003Epixelator.register();
      Draw.draw(-10f, (Runnable) new Renderer.__\u003C\u003EAnon1(this));
      FloorRenderer floor = this.__\u003C\u003Eblocks.__\u003C\u003Efloor;
      Objects.requireNonNull((object) floor);
      Draw.draw(0.0f, (Runnable) new Renderer.__\u003C\u003EAnon2(floor));
      BlockRenderer blocks1 = this.__\u003C\u003Eblocks;
      Objects.requireNonNull((object) blocks1);
      Draw.draw(29f, (Runnable) new Renderer.__\u003C\u003EAnon3(blocks1));
      Draw.draw(29.91f, (Runnable) new Renderer.__\u003C\u003EAnon4(this));
      Draw.drawRange(40f, (Runnable) new Renderer.__\u003C\u003EAnon5(), (Runnable) new Renderer.__\u003C\u003EAnon6());
      if (Vars.state.rules.lighting)
      {
        LightRenderer lights = this.__\u003C\u003Elights;
        Objects.requireNonNull((object) lights);
        Draw.draw(140f, (Runnable) new Renderer.__\u003C\u003EAnon7(lights));
      }
      if (Vars.enableDarkness)
      {
        BlockRenderer blocks2 = this.__\u003C\u003Eblocks;
        Objects.requireNonNull((object) blocks2);
        Draw.draw(80f, (Runnable) new Renderer.__\u003C\u003EAnon8(blocks2));
      }
      if (this.bloom != null)
      {
        this.bloom.resize(Core.graphics.getWidth() / 4, Core.graphics.getHeight() / 4);
        Bloom bloom1 = this.bloom;
        Objects.requireNonNull((object) bloom1);
        Draw.draw(99.99f, (Runnable) new Renderer.__\u003C\u003EAnon9(bloom1));
        Bloom bloom2 = this.bloom;
        Objects.requireNonNull((object) bloom2);
        Draw.draw(110.01f, (Runnable) new Renderer.__\u003C\u003EAnon10(bloom2));
      }
      OverlayRenderer overlays1 = this.__\u003C\u003Eoverlays;
      Objects.requireNonNull((object) overlays1);
      Draw.draw(85f, (Runnable) new Renderer.__\u003C\u003EAnon11(overlays1));
      if (this.animateShields && Shaders.shield != null)
      {
        Draw.drawRange(125f, 1f, (Runnable) new Renderer.__\u003C\u003EAnon12(this), (Runnable) new Renderer.__\u003C\u003EAnon13(this));
        Draw.drawRange(122f, 1f, (Runnable) new Renderer.__\u003C\u003EAnon14(this), (Runnable) new Renderer.__\u003C\u003EAnon15(this));
      }
      OverlayRenderer overlays2 = this.__\u003C\u003Eoverlays;
      Objects.requireNonNull((object) overlays2);
      Draw.draw(120f, (Runnable) new Renderer.__\u003C\u003EAnon16(overlays2));
      Draw.draw(160f, (Runnable) new Renderer.__\u003C\u003EAnon17(this));
      this.__\u003C\u003Eblocks.drawBlocks();
      Groups.draw.draw((Cons) new Renderer.__\u003C\u003EAnon18());
      Draw.reset();
      Draw.flush();
      Draw.sort(false);
      Events.fire((object) EventType.Trigger.__\u003C\u003EpostDraw);
    }

    [LineNumberTable(new byte[] {160, 170, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clampScale() => this.targetscale = Mathf.clamp(this.targetscale, this.minScale(), this.maxScale());

    [LineNumberTable(296)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float maxScale() => (float) Mathf.round(Scl.scl(this.maxZoom));

    [Modifiers]
    [LineNumberTable(new byte[] {13, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024init\u00240([In] EventType.WorldLoadEvent obj0) => this.landCore = Vars.player.bestCore();

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void drawBackground()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 86, 112, 117, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00241()
    {
      this.__\u003C\u003Eblocks.__\u003C\u003Efloor.beginDraw();
      this.__\u003C\u003Eblocks.__\u003C\u003Efloor.drawLayer(CacheLayer.__\u003C\u003Ewalls);
      this.__\u003C\u003Eblocks.__\u003C\u003Efloor.endDraw();
    }

    [Modifiers]
    [LineNumberTable(205)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024draw\u00242() => Draw.shader((Shader) Shaders.blockbuild, true);

    [Modifiers]
    [LineNumberTable(224)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00243() => this.effectBuffer.begin(Color.__\u003C\u003Eclear);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 111, 107, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00244()
    {
      this.effectBuffer.end();
      this.effectBuffer.blit((Shader) Shaders.shield);
    }

    [Modifiers]
    [LineNumberTable(229)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00245() => this.effectBuffer.begin(Color.__\u003C\u003Eclear);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 116, 107, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024draw\u00246()
    {
      this.effectBuffer.end();
      this.effectBuffer.blit((Shader) Shaders.buildBeam);
    }

    [LineNumberTable(new byte[] {160, 140, 123, 118, 147, 113, 116, 157, 106, 154, 255, 16, 69, 101, 107, 159, 29, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void drawLanding()
    {
      CoreBlock.CoreBuild coreBuild = this.landCore != null ? this.landCore : Vars.player.bestCore();
      if ((double) this.landTime <= 0.0 || coreBuild == null)
        return;
      float a = this.landTime / Fx.__\u003C\u003EcoreLand.lifetime;
      TextureRegion region = coreBuild.block.icon(Cicon.__\u003C\u003Efull);
      float num1 = Scl.scl(4f) / this.camerascale;
      float num2 = (float) region.width * Draw.scl * num1 * 4f * a;
      Draw.color(Pal.lightTrail);
      Draw.rect("circle-shadow", coreBuild.x, coreBuild.y, num2, num2);
      Angles.randLenVectors(1L, 1f - a, 100, 1000f * num1 * (1f - a), (Angles.ParticleConsumer) new Renderer.__\u003C\u003EAnon19(num1, coreBuild));
      Draw.color();
      Draw.mixcol(Color.__\u003C\u003Ewhite, a);
      Draw.rect(region, coreBuild.x, coreBuild.y, (float) region.width * Draw.scl * num1, (float) region.height * Draw.scl * num1, a * 135f);
      Draw.reset();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 152, 108, 127, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024drawLanding\u00247(
      [In] float obj0,
      [In] CoreBlock.CoreBuild obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] float obj5)
    {
      Lines.stroke(obj0 * obj4);
      Lines.lineAngle(obj1.x + obj2, obj1.y + obj3, Mathf.angle(obj2, obj3), (obj4 * 20f + 1f) * obj0);
    }

    [LineNumberTable(new byte[] {0, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void shake(float intensity, float duration)
    {
      this.shakeIntensity = Math.max(this.shakeIntensity, intensity);
      this.shaketime = Math.max(this.shaketime, duration);
    }

    [LineNumberTable(new byte[] {6, 139, 124, 166, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
      this.planets = new PlanetRenderer();
      if (Core.settings.getBool("bloom", !Vars.ios))
        this.setupBloom();
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new Renderer.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {19, 159, 0, 114, 120, 122, 124, 124, 117, 149, 109, 115, 127, 28, 108, 141, 188, 125, 157, 108, 107, 145, 107, 109, 141, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      Color.__\u003C\u003Ewhite.set(1f, 1f, 1f, 1f);
      float num = Mathf.round(this.targetscale, 0.5f);
      this.camerascale = Mathf.lerpDelta(this.camerascale, num, 0.1f);
      if (Mathf.equal(this.camerascale, num, 1f / 1000f))
        this.camerascale = num;
      Renderer.laserOpacity = (float) Core.settings.getInt("lasersopacity") / 100f;
      Renderer.bridgeOpacity = (float) Core.settings.getInt("bridgeopacity") / 100f;
      this.animateShields = Core.settings.getBool("animatedshields");
      this.drawStatus = Core.settings.getBool("blockstatus");
      if ((double) this.landTime > 0.0)
      {
        this.landTime -= Time.delta;
        this.landscale = Interp.pow5In.apply(this.minZoomScl, Scl.scl(4f), 1f - this.landTime / Fx.__\u003C\u003EcoreLand.lifetime);
        this.camerascale = this.landscale;
        this.weatherAlpha = 0.0f;
      }
      else
        this.weatherAlpha = Mathf.lerpDelta(this.weatherAlpha, 1f, 0.08f);
      Core.camera.width = (float) Core.graphics.getWidth() / this.camerascale;
      Core.camera.height = (float) Core.graphics.getHeight() / this.camerascale;
      if (Vars.state.isMenu())
      {
        this.landTime = 0.0f;
        Core.graphics.clear(Color.__\u003C\u003Eblack);
      }
      else
      {
        this.updateShake(0.75f);
        if (this.__\u003C\u003Epixelator.enabled())
          this.__\u003C\u003Epixelator.drawPixelate();
        else
          this.draw();
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLanding() => (double) this.landTime > 0.0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float weatherAlpha() => this.weatherAlpha;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float landScale() => (double) this.landTime > 0.0 ? this.landscale : 1f;

    [LineNumberTable(new byte[] {68, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => Events.fire((object) new EventType.DisposeEvent());

    [LineNumberTable(new byte[] {73, 121, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resume()
    {
      if (!Core.settings.getBool("bloom") || this.bloom == null)
        return;
      this.bloom.resume();
    }

    [LineNumberTable(new byte[] {159, 107, 162, 99, 104, 168, 104, 107, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggleBloom(bool enabled)
    {
      if (enabled)
      {
        if (this.bloom != null)
          return;
        this.setupBloom();
      }
      else
      {
        if (this.bloom == null)
          return;
        this.bloom.dispose();
        this.bloom = (Bloom) null;
      }
    }

    [LineNumberTable(new byte[] {160, 165, 126, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scaleCamera(float amount)
    {
      this.targetscale *= amount / 4f + 1f;
      this.clampScale();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getDisplayScale() => this.camerascale;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getScale() => this.targetscale;

    [LineNumberTable(new byte[] {160, 190, 104, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScale(float scl)
    {
      this.targetscale = scl;
      this.clampScale();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static Renderer()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.core.Renderer"))
        return;
      Renderer.laserOpacity = 0.5f;
      Renderer.bridgeOpacity = 0.75f;
    }

    [HideFromJava]
    public virtual void resize([In] int obj0, [In] int obj1) => ApplicationListener.\u003Cdefault\u003Eresize((ApplicationListener) this, obj0, obj1);

    [HideFromJava]
    public virtual void pause() => ApplicationListener.\u003Cdefault\u003Epause((ApplicationListener) this);

    [HideFromJava]
    public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);

    [HideFromJava]
    public virtual void fileDropped([In] Fi obj0) => ApplicationListener.\u003Cdefault\u003EfileDropped((ApplicationListener) this, obj0);

    [Modifiers]
    public BlockRenderer blocks
    {
      [HideFromJava] get => this.__\u003C\u003Eblocks;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eblocks = value;
    }

    [Modifiers]
    public MinimapRenderer minimap
    {
      [HideFromJava] get => this.__\u003C\u003Eminimap;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eminimap = value;
    }

    [Modifiers]
    public OverlayRenderer overlays
    {
      [HideFromJava] get => this.__\u003C\u003Eoverlays;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eoverlays = value;
    }

    [Modifiers]
    public LightRenderer lights
    {
      [HideFromJava] get => this.__\u003C\u003Elights;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Elights = value;
    }

    [Modifiers]
    public Pixelator pixelator
    {
      [HideFromJava] get => this.__\u003C\u003Epixelator;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Epixelator = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Renderer arg\u00241;

      internal __\u003C\u003EAnon0([In] Renderer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024init\u00240((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly Renderer arg\u00241;

      internal __\u003C\u003EAnon1([In] Renderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.drawBackground();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly FloorRenderer arg\u00241;

      internal __\u003C\u003EAnon2([In] FloorRenderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.drawFloor();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly BlockRenderer arg\u00241;

      internal __\u003C\u003EAnon3([In] BlockRenderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.drawShadows();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly Renderer arg\u00241;

      internal __\u003C\u003EAnon4([In] Renderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024draw\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void run() => Renderer.lambda\u0024draw\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void run() => Draw.shader();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly LightRenderer arg\u00241;

      internal __\u003C\u003EAnon7([In] LightRenderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.draw();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly BlockRenderer arg\u00241;

      internal __\u003C\u003EAnon8([In] BlockRenderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.drawDarkness();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly Bloom arg\u00241;

      internal __\u003C\u003EAnon9([In] Bloom obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.capture();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly Bloom arg\u00241;

      internal __\u003C\u003EAnon10([In] Bloom obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.render();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly OverlayRenderer arg\u00241;

      internal __\u003C\u003EAnon11([In] OverlayRenderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.drawBottom();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly Renderer arg\u00241;

      internal __\u003C\u003EAnon12([In] Renderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024draw\u00243();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly Renderer arg\u00241;

      internal __\u003C\u003EAnon13([In] Renderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024draw\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly Renderer arg\u00241;

      internal __\u003C\u003EAnon14([In] Renderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024draw\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly Renderer arg\u00241;

      internal __\u003C\u003EAnon15([In] Renderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024draw\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly OverlayRenderer arg\u00241;

      internal __\u003C\u003EAnon16([In] OverlayRenderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.drawTop();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly Renderer arg\u00241;

      internal __\u003C\u003EAnon17([In] Renderer obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.drawLanding();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Cons
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public void get([In] object obj0) => ((Drawc) obj0).draw();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Angles.ParticleConsumer
    {
      private readonly float arg\u00241;
      private readonly CoreBlock.CoreBuild arg\u00242;

      internal __\u003C\u003EAnon19([In] float obj0, [In] CoreBlock.CoreBuild obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void accept([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => Renderer.lambda\u0024drawLanding\u00247(this.arg\u00241, this.arg\u00242, obj0, obj1, obj2, obj3);
    }
  }
}
