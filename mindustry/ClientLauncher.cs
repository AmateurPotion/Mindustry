// Decompiled with JetBrains decompiler
// Type: mindustry.ClientLauncher
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
using arc.assets.loaders;
using arc.audio;
using arc.files;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using arc.util.async;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.ai;
using mindustry.core;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.maps;
using mindustry.mod;
using mindustry.type;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry
{
  [Implements(new string[] {"mindustry.core.Platform"})]
  public abstract class ClientLauncher : ApplicationCore, Platform
  {
    private const int loadingFPS = 20;
    private long lastTime;
    private long beginTime;
    private bool finished;
    private LoadRenderer loader;

    [LineNumberTable(new byte[] {68, 167, 127, 0, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void add(ApplicationListener module)
    {
      base.add(module);
      ApplicationListener applicationListener = module;
      Loadable load;
      if (!(applicationListener is Loadable) || !object.ReferenceEquals((object) (load = (Loadable) applicationListener), (object) (Loadable) applicationListener))
        return;
      Core.assets.load(load);
    }

    [LineNumberTable(new byte[] {159, 179, 107, 99, 181, 101, 133, 107, 138, 101, 102, 171, 125, 127, 3, 127, 7, 157, 239, 69, 106, 106, 153, 106, 121, 153, 117, 106, 116, 106, 138, 133, 144, 165, 255, 33, 69, 159, 0, 101, 133, 255, 10, 72, 113, 113, 113, 113, 113, 145, 112, 144, 127, 10, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setup()
    {
      string path = OS.env("MINDUSTRY_DATA_DIR");
      if (path != null)
        Core.settings.setDataDirectory(Core.files.absolute(path));
      Vars.checkLaunch();
      Vars.loadLogger();
      this.loader = new LoadRenderer();
      Events.fire((object) new EventType.ClientCreateEvent());
      Vars.loadFileLogger();
      Vars.platform = (Platform) this;
      this.beginTime = Time.millis();
      Log.info("[GL] Version: @", (object) Core.graphics.getGLVersion());
      Log.info("[GL] Max texture size: @", (object) Integer.valueOf(Gl.getInt(3379)));
      Log.info("[GL] Using @ context.", Core.gl30 == null ? (object) "OpenGL 2" : (object) "OpenGL 3");
      Log.info("[JAVA] Version: @", (object) java.lang.System.getProperty("java.version"));
      Time.setDeltaProvider((Floatp) new ClientLauncher.__\u003C\u003EAnon0());
      Core.batch = (Batch) new SortedSpriteBatch();
      Core.assets = new AssetManager();
      Core.assets.setLoader((Class) ClassLiteral<Texture>.Value, ".msav", (AssetLoader) new MapPreviewLoader());
      Vars.tree = new FileTree();
      Core.assets.setLoader((Class) ClassLiteral<Sound>.Value, (AssetLoader) new SoundLoader((FileHandleResolver) Vars.tree));
      Core.assets.setLoader((Class) ClassLiteral<Music>.Value, (AssetLoader) new MusicLoader((FileHandleResolver) Vars.tree));
      Core.assets.load("sprites/error.png", (Class) ClassLiteral<Texture>.Value);
      Core.atlas = TextureAtlas.blankAtlas();
      Vars.net = new mindustry.net.Net(Vars.platform.getNet());
      Vars.mods = new Mods();
      Vars.schematics = new Schematics();
      Fonts.loadSystemCursors();
      Core.assets.load((Loadable) new Vars());
      Fonts.loadDefaultFont();
      Core.assets.load(new AssetDescriptor(Gl.getInt(3379) < 4096 ? "sprites/fallback/sprites.atlas" : "sprites/sprites.atlas", (Class) ClassLiteral<TextureAtlas>.Value)).loaded = (Cons) new ClientLauncher.__\u003C\u003EAnon1();
      Core.assets.loadRun("maps", (Class) ClassLiteral<Map>.Value, (Runnable) new ClientLauncher.__\u003C\u003EAnon2());
      Musics.load();
      Sounds.load();
      Core.assets.loadRun("contentcreate", (Class) ClassLiteral<Content>.Value, (Runnable) new ClientLauncher.__\u003C\u003EAnon3(), (Runnable) new ClientLauncher.__\u003C\u003EAnon4());
      this.add((ApplicationListener) (Vars.logic = new Logic()));
      this.add((ApplicationListener) (Vars.control = new Control()));
      this.add((ApplicationListener) (Vars.renderer = new Renderer()));
      this.add((ApplicationListener) (Vars.ui = new UI()));
      this.add((ApplicationListener) (Vars.netServer = new NetServer()));
      this.add((ApplicationListener) (Vars.netClient = new NetClient()));
      Core.assets.load((Loadable) Vars.mods);
      Core.assets.load((Loadable) Vars.schematics);
      Core.assets.loadRun("contentinit", (Class) ClassLiteral<ContentLoader>.Value, (Runnable) new ClientLauncher.__\u003C\u003EAnon5(), (Runnable) new ClientLauncher.__\u003C\u003EAnon6());
      Core.assets.loadRun("baseparts", (Class) ClassLiteral<BaseRegistry>.Value, (Runnable) new ClientLauncher.__\u003C\u003EAnon7(), (Runnable) new ClientLauncher.__\u003C\u003EAnon8());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {9, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024setup\u00240()
    {
      float num = Core.graphics.getDeltaTime() * 60f;
      return Float.isNaN(num) || Float.isInfinite(num) ? 1f : Mathf.clamp(num, 0.0001f, 6f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {35, 107, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00241([In] object obj0)
    {
      Core.atlas = (TextureAtlas) obj0;
      Fonts.mergeFontAtlas(Core.atlas);
    }

    [Modifiers]
    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00242() => Vars.maps.loadPreviews();

    [Modifiers]
    [LineNumberTable(new byte[] {45, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00243()
    {
      Vars.content.createBaseContent();
      Vars.content.loadColors();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {48, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00244()
    {
      Vars.mods.loadScripts();
      Vars.content.createModContent();
    }

    [Modifiers]
    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00245() => Vars.content.init();

    [Modifiers]
    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00246() => Vars.content.load();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00247()
    {
    }

    [Modifiers]
    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00248() => Vars.bases.load();

    [Modifiers]
    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002412() => Core.app.post((Runnable) new ClientLauncher.__\u003C\u003EAnon11(this));

    [Modifiers]
    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002411() => Core.app.post((Runnable) new ClientLauncher.__\u003C\u003EAnon12(this));

    [Modifiers]
    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002410() => Core.app.post((Runnable) new ClientLauncher.__\u003C\u003EAnon13(this));

    [Modifiers]
    [LineNumberTable(new byte[] {105, 186, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u00249()
    {
      base.resize(Core.graphics.getWidth(), Core.graphics.getHeight());
      Vars.finishLaunch();
    }

    [LineNumberTable(new byte[] {159, 169, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClientLauncher()
    {
      ClientLauncher clientLauncher = this;
      this.finished = false;
    }

    [LineNumberTable(new byte[] {78, 136, 104, 155, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resize(int width, int height)
    {
      if (Core.assets == null)
        return;
      if (!this.finished)
        Draw.proj().setOrtho(0.0f, 0.0f, (float) width, (float) height);
      else
        base.resize(width, height);
    }

    [LineNumberTable(new byte[] {89, 107, 104, 139, 113, 107, 103, 127, 4, 116, 38, 166, 116, 103, 106, 122, 247, 72, 138, 134, 170, 147, 113, 115, 109, 102, 223, 10, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update()
    {
      if (!this.finished)
      {
        if (this.loader != null)
          this.loader.draw();
        if (Core.assets.update(50))
        {
          this.loader.dispose();
          this.loader = (LoadRenderer) null;
          Log.info("Total time to load: @ms", (object) Long.valueOf(Time.timeSinceMillis(this.beginTime)));
          ApplicationListener[] modules = this.modules;
          int length = modules.Length;
          for (int index = 0; index < length; ++index)
            modules[index].init();
          Vars.mods.eachClass((Cons) new ClientLauncher.__\u003C\u003EAnon9());
          this.finished = true;
          Events.fire((object) new EventType.ClientLoadEvent());
          base.resize(Core.graphics.getWidth(), Core.graphics.getHeight());
          Core.app.post((Runnable) new ClientLauncher.__\u003C\u003EAnon10(this));
        }
      }
      else
      {
        Vars.asyncCore.begin();
        base.update();
        Vars.asyncCore.end();
      }
      int num1 = Core.settings.getInt("fpscap", 120);
      if (num1 > 0 && num1 <= 240)
      {
        int num2 = 1000000000;
        int num3 = num1;
        long num4 = num3 != -1 ? (long) (num2 / num3) : (long) -num2;
        long num5 = Time.timeSinceNanos(this.lastTime);
        if (num5 < num4)
        {
          long ms = (num4 - num5) / 1000000L;
          long num6 = num4 - num5;
          long num7 = 1000000;
          int ns = num7 != -1L ? (int) (num6 % num7) : 0;
          Threads.sleep(ms, ns);
        }
      }
      this.lastTime = Time.nanos();
    }

    [LineNumberTable(new byte[] {160, 71, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void exit() => Vars.finishLaunch();

    [LineNumberTable(new byte[] {160, 76, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init() => this.setup();

    [LineNumberTable(new byte[] {160, 81, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void resume()
    {
      if (!this.finished)
        return;
      base.resume();
    }

    [LineNumberTable(new byte[] {160, 90, 103, 133, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void pause()
    {
      if (Vars.mobile)
        Vars.finishLaunch();
      if (!this.finished)
        return;
      base.pause();
    }

    [HideFromJava]
    public virtual ClassLoader loadJar([In] Fi obj0, [In] string obj1) => Platform.\u003Cdefault\u003EloadJar((Platform) this, obj0, obj1);

    [HideFromJava]
    public virtual void updateLobby() => Platform.\u003Cdefault\u003EupdateLobby((Platform) this);

    [HideFromJava]
    public virtual void inviteFriends() => Platform.\u003Cdefault\u003EinviteFriends((Platform) this);

    [HideFromJava]
    public virtual void publish([In] Publishable obj0) => Platform.\u003Cdefault\u003Epublish((Platform) this, obj0);

    [HideFromJava]
    public virtual void viewListing([In] Publishable obj0) => Platform.\u003Cdefault\u003EviewListing((Platform) this, obj0);

    [HideFromJava]
    public virtual void viewListingID([In] string obj0) => Platform.\u003Cdefault\u003EviewListingID((Platform) this, obj0);

    [HideFromJava]
    public virtual Seq getWorkshopContent([In] Class obj0) => Platform.\u003Cdefault\u003EgetWorkshopContent((Platform) this, obj0);

    [HideFromJava]
    public virtual void openWorkshop() => Platform.\u003Cdefault\u003EopenWorkshop((Platform) this);

    [HideFromJava]
    public virtual mindustry.net.Net.NetProvider getNet() => Platform.\u003Cdefault\u003EgetNet((Platform) this);

    [HideFromJava]
    public virtual Scripts createScripts() => Platform.\u003Cdefault\u003EcreateScripts((Platform) this);

    [HideFromJava]
    public virtual rhino.Context getScriptContext() => Platform.\u003Cdefault\u003EgetScriptContext((Platform) this);

    [HideFromJava]
    public virtual void updateRPC() => Platform.\u003Cdefault\u003EupdateRPC((Platform) this);

    [HideFromJava]
    public virtual string getUUID() => Platform.\u003Cdefault\u003EgetUUID((Platform) this);

    [HideFromJava]
    public virtual void shareFile([In] Fi obj0) => Platform.\u003Cdefault\u003EshareFile((Platform) this, obj0);

    [HideFromJava]
    public virtual void export([In] string obj0, [In] string obj1, [In] Platform.FileWriter obj2) => Platform.\u003Cdefault\u003Eexport((Platform) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual void showFileChooser([In] bool obj0, [In] string obj1, [In] string obj2, [In] Cons obj3) => Platform.\u003Cdefault\u003EshowFileChooser((Platform) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual void showFileChooser([In] bool obj0, [In] string obj1, [In] Cons obj2) => Platform.\u003Cdefault\u003EshowFileChooser((Platform) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual void showMultiFileChooser([In] Cons obj0, [In] string[] obj1) => Platform.\u003Cdefault\u003EshowMultiFileChooser((Platform) this, obj0, obj1);

    [HideFromJava]
    public virtual void hide() => Platform.\u003Cdefault\u003Ehide((Platform) this);

    [HideFromJava]
    public virtual void beginForceLandscape() => Platform.\u003Cdefault\u003EbeginForceLandscape((Platform) this);

    [HideFromJava]
    public virtual void endForceLandscape() => Platform.\u003Cdefault\u003EendForceLandscape((Platform) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatp
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public float get() => ClientLauncher.lambda\u0024setup\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => ClientLauncher.lambda\u0024setup\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void run() => ClientLauncher.lambda\u0024setup\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void run() => ClientLauncher.lambda\u0024setup\u00243();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void run() => ClientLauncher.lambda\u0024setup\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void run() => ClientLauncher.lambda\u0024setup\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void run() => ClientLauncher.lambda\u0024setup\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void run() => ClientLauncher.lambda\u0024setup\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void run() => ClientLauncher.lambda\u0024setup\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void get([In] object obj0) => ((Mod) obj0).init();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly ClientLauncher arg\u00241;

      internal __\u003C\u003EAnon10([In] ClientLauncher obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024update\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly ClientLauncher arg\u00241;

      internal __\u003C\u003EAnon11([In] ClientLauncher obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024update\u002411();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly ClientLauncher arg\u00241;

      internal __\u003C\u003EAnon12([In] ClientLauncher obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024update\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly ClientLauncher arg\u00241;

      internal __\u003C\u003EAnon13([In] ClientLauncher obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024update\u00249();
    }
  }
}
