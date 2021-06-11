// Decompiled with JetBrains decompiler
// Type: mindustry.Vars
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
using arc.files;
using arc.func;
using arc.graphics;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio.charset;
using java.util;
using mindustry.ai;
using mindustry.async;
using mindustry.core;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.input;
using mindustry.io;
using mindustry.logic;
using mindustry.maps;
using mindustry.mod;
using mindustry.net;
using mindustry.type;
using mindustry.ui.fragments;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry
{
  public class Vars : Object, Loadable
  {
    public static bool failedToLaunch;
    public static bool loadLocales;
    public static bool loadedLogger;
    public static bool loadedFileLogger;
    public static bool experimental;
    public static string steamPlayerName;
    public const int maxLoadoutSchematicPad = 5;
    public const int maxSchematicSize = 32;
    public const string schematicBaseStart = "bXNjaA";
    public const int bufferSize = 8192;
    internal static Charset __\u003C\u003Echarset;
    public const string appName = "Mindustry";
    public const string ghApi = "https://api.github.com";
    public const string discordURL = "https://discord.gg/mindustry";
    public const string crashReportURL = "http://192.99.169.18/report";
    public const string modGuideURL = "https://mindustrygame.github.io/wiki/modding/1-modding/";
    public const string serverJsonBeURL = "https://raw.githubusercontent.com/Anuken/Mindustry/master/servers_be.json";
    public const string serverJsonURL = "https://raw.githubusercontent.com/Anuken/Mindustry/master/servers_v6.json";
    public const string reportIssueURL = "https://github.com/Anuken/Mindustry/issues/new?labels=bug&template=bug_report.md";
    [Signature("Larc/struct/Seq<Lmindustry/net/ServerGroup;>;")]
    internal static Seq __\u003C\u003EdefaultServers;
    public const int maxBlockSize = 16;
    public const float mineTransferRange = 220f;
    public const int maxTextLength = 150;
    public const int maxNameLength = 40;
    public const float itemSize = 5f;
    public const float finalWorldBounds = 500f;
    public const float miningRange = 70f;
    public const float buildingRange = 220f;
    public const float itemTransferRange = 220f;
    public const float logicItemTransferRange = 45f;
    public const float turnDuration = 7200f;
    public const float baseInvasionChance = 0.01f;
    public const float invasionGracePeriod = 20f;
    public const float minArmorDamage = 0.1f;
    public const float launchDuration = 140f;
    public const int tilesize = 8;
    public const float tilePayload = 64f;
    public static Tile emptyTile;
    public static bool updateEditorOnChange;
    internal static Color[] __\u003C\u003EplayerColors;
    public const int port = 6567;
    public const int multicastPort = 20151;
    public const string multicastGroup = "227.2.7.7";
    public static bool disableUI;
    public static bool testMobile;
    public static bool mobile;
    public static bool ios;
    public static bool android;
    public static bool headless;
    public static bool steam;
    public static bool enableConsole;
    public static bool clearSectors;
    public static bool enableLight;
    public static bool enableDarkness;
    public static Fi dataDirectory;
    public static Fi screenshotDirectory;
    public static Fi customMapDirectory;
    public static Fi mapPreviewDirectory;
    public static Fi tmpDirectory;
    public static Fi saveDirectory;
    public static Fi modDirectory;
    public static Fi schematicDirectory;
    public static Fi bebuildDirectory;
    public static Fi launchIDFile;
    public static Map emptyMap;
    public const string mapExtension = "msav";
    public const string saveExtension = "msav";
    public const string schematicExtension = "msch";
    public static Locale[] locales;
    public static FileTree tree;
    public static mindustry.net.Net net;
    public static ContentLoader content;
    public static GameState state;
    public static EntityCollisions collisions;
    public static Waves waves;
    public static Platform platform;
    public static Mods mods;
    public static Schematics schematics;
    public static BeControl becontrol;
    public static AsyncCore asyncCore;
    public static BaseRegistry bases;
    public static GlobalConstants constants;
    public static Universe universe;
    public static World world;
    public static Maps maps;
    public static WaveSpawner spawner;
    public static BlockIndexer indexer;
    public static Pathfinder pathfinder;
    public static Control control;
    public static Logic logic;
    public static Renderer renderer;
    public static UI ui;
    public static NetServer netServer;
    public static NetClient netClient;
    public static Player player;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 180, 111, 153, 108, 136, 102, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void checkLaunch()
    {
      Core.settings.setAppName("Mindustry");
      Vars.launchIDFile = Core.settings.getDataDirectory().child("launchid.dat");
      if (Vars.launchIDFile.exists())
      {
        Vars.failedToLaunch = true;
      }
      else
      {
        Vars.failedToLaunch = false;
        Vars.launchIDFile.writeString("go away");
      }
    }

    [LineNumberTable(new byte[] {160, 199, 136, 127, 16, 159, 16, 102, 242, 84, 149, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadLogger()
    {
      if (Vars.loadedLogger)
        return;
      string[] strArray1 = new string[5]
      {
        "[green][D][]",
        "[royal][I][]",
        "[yellow][W][]",
        "[scarlet][E][]",
        ""
      };
      string[] strArray2 = new string[5]
      {
        "&lc&fb[D]",
        "&lb&fb[I]",
        "&ly&fb[W]",
        "&lr&fb[E]",
        ""
      };
      Seq seq = new Seq();
      Log.logger = (Log.LogHandler) new Vars.__\u003C\u003EAnon1(strArray2, strArray1, seq);
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new Vars.__\u003C\u003EAnon2(seq));
      Vars.loadedLogger = true;
    }

    [LineNumberTable(new byte[] {160, 231, 136, 175, 123, 134, 255, 9, 78, 226, 61, 129, 166, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadFileLogger()
    {
      if (Vars.loadedFileLogger)
        return;
      Core.settings.setAppName("Mindustry");
      Exception exception;
      try
      {
        Writer writer = Core.settings.getDataDirectory().child("last_log.txt").writer(false);
        Log.logger = (Log.LogHandler) new Vars.__\u003C\u003EAnon3(Log.logger, writer);
        goto label_8;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception = (Exception) m0;
      }
      Log.err((Exception) exception);
label_8:
      Vars.loadedFileLogger = true;
    }

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Vars()
    {
    }

    [LineNumberTable(new byte[] {160, 193, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void finishLaunch()
    {
      if (Vars.launchIDFile == null)
        return;
      Vars.launchIDFile.delete();
    }

    [LineNumberTable(new byte[] {161, 3, 111, 143, 127, 16, 185, 127, 18, 117, 107, 138, 158, 200, 144, 102, 140, 138, 103, 255, 6, 93, 229, 37, 161, 145, 113, 110, 169, 126, 110, 116, 98, 169, 164, 103, 174, 115, 175})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadSettings()
    {
      Core.settings.setJson(JsonIO.__\u003C\u003Ejson);
      Core.settings.setAppName("Mindustry");
      CharSequence charSequence1;
      if (!Vars.steam)
      {
        if (mindustry.core.Version.modifier != null)
        {
          string modifier = mindustry.core.Version.modifier;
          object obj = (object) "steam";
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          if (!String.instancehelper_contains(modifier, charSequence2))
            goto label_4;
        }
        else
          goto label_4;
      }
      Core.settings.setDataDirectory(Core.files.local("saves/"));
label_4:
      Core.settings.defaults((object) "locale", (object) "default", (object) "blocksync", (object) Boolean.valueOf(true));
      Core.keybinds.setDefaults((KeyBinds.KeyBind[]) Binding.values());
      Core.settings.setAutosave(false);
      Core.settings.load();
      Scl.setProduct((float) Core.settings.getInt("uiscale", 100) / 100f);
      if (!Vars.loadLocales)
        return;
      try
      {
        Core.bundle = I18NBundle.createBundle(Core.files.local("bundle"), (Locale) Locale.ENGLISH);
        Log.info((object) "NOTE: external translation bundle has been loaded.");
        if (Vars.headless)
          return;
        Time.run(10f, (Runnable) new Vars.__\u003C\u003EAnon4());
        return;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
      Fi baseFileHandle = Core.files.@internal("bundles/bundle");
      string str1 = Core.settings.getString("locale");
      Locale locale1;
      if (String.instancehelper_equals(str1, (object) "default"))
      {
        locale1 = Locale.getDefault();
      }
      else
      {
        string str2 = str1;
        object obj = (object) "_";
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        Locale locale2;
        if (String.instancehelper_contains(str2, charSequence2))
        {
          string[] strArray = String.instancehelper_split(str1, "_");
          Locale.__\u003Cclinit\u003E();
          locale2 = new Locale(strArray[0], strArray[1]);
        }
        else
          locale2 = new Locale(str1);
        locale1 = locale2;
      }
      Locale.setDefault(locale1);
      Core.bundle = I18NBundle.createBundle(baseFileHandle, locale1);
      if (!String.instancehelper_equals(locale1.getDisplayName(), (object) "router"))
        return;
      Core.bundle.debug("router");
    }

    [LineNumberTable(new byte[] {160, 114, 133, 138, 127, 0, 108, 110, 100, 125, 159, 14, 237, 59, 233, 73, 126, 191, 14, 133, 111, 116, 116, 116, 116, 116, 116, 116, 116, 111, 134, 113, 145, 106, 106, 106, 106, 106, 106, 138, 106, 106, 106, 106, 106, 138, 138, 124, 111, 143, 139, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init()
    {
      Groups.init();
      if (Vars.loadLocales)
      {
        string[] strArray = String.instancehelper_split(Core.files.@internal("locales").readString(), "\n");
        Vars.locales = new Locale[strArray.Length];
        for (int index1 = 0; index1 < Vars.locales.Length; ++index1)
        {
          string str1 = strArray[index1];
          string str2 = str1;
          object obj = (object) "_";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          if (String.instancehelper_contains(str2, charSequence2))
          {
            Locale[] locales = Vars.locales;
            int index2 = index1;
            Locale.__\u003Cclinit\u003E();
            Locale locale = new Locale(String.instancehelper_split(str1, "_")[0], String.instancehelper_split(str1, "_")[1]);
            locales[index2] = locale;
          }
          else
            Vars.locales[index1] = new Locale(str1);
        }
        Arrays.sort((object[]) Vars.locales, Structs.comparing((Func) new Vars.__\u003C\u003EAnon0(), (Comparator) String.CASE_INSENSITIVE_ORDER));
        Vars.locales = (Locale[]) Seq.with((object[]) Vars.locales).and((object) new Locale("router")).toArray((Class) ClassLiteral<Locale>.Value);
      }
      mindustry.core.Version.init();
      Vars.dataDirectory = Core.settings.getDataDirectory();
      Vars.screenshotDirectory = Vars.dataDirectory.child("screenshots/");
      Vars.customMapDirectory = Vars.dataDirectory.child("maps/");
      Vars.mapPreviewDirectory = Vars.dataDirectory.child("previews/");
      Vars.saveDirectory = Vars.dataDirectory.child("saves/");
      Vars.tmpDirectory = Vars.dataDirectory.child("tmp/");
      Vars.modDirectory = Vars.dataDirectory.child("mods/");
      Vars.schematicDirectory = Vars.dataDirectory.child("schematics/");
      Vars.bebuildDirectory = Vars.dataDirectory.child("be_builds/");
      Vars.emptyMap = new Map(new StringMap());
      Vars.emptyTile = (Tile) null;
      if (Vars.tree == null)
        Vars.tree = new FileTree();
      if (Vars.mods == null)
        Vars.mods = new Mods();
      Vars.content = new ContentLoader();
      Vars.waves = new Waves();
      Vars.collisions = new EntityCollisions();
      Vars.world = new World();
      Vars.universe = new Universe();
      Vars.becontrol = new BeControl();
      Vars.asyncCore = new AsyncCore();
      Vars.maps = new Maps();
      Vars.spawner = new WaveSpawner();
      Vars.indexer = new BlockIndexer();
      Vars.pathfinder = new Pathfinder();
      Vars.bases = new BaseRegistry();
      Vars.constants = new GlobalConstants();
      Vars.state = new GameState();
      Vars.mobile = Core.app.isMobile() || Vars.testMobile;
      Vars.ios = Core.app.isIOS();
      Vars.android = Core.app.isAndroid();
      Vars.modDirectory.mkdirs();
      Vars.mods.load();
      Vars.maps.load();
    }

    [Modifiers]
    [LineNumberTable(243)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024init\u00240([In] Locale obj0) => obj0.getDisplayName(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 206, 99, 127, 21, 139, 159, 9, 122, 108, 106, 106, 119, 63, 23, 232, 69, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadLogger\u00241(
      [In] string[] obj0,
      [In] string[] obj1,
      [In] Seq obj2,
      [In] Log.LogLevel obj3,
      [In] string obj4)
    {
      string str1 = obj4;
      java.lang.System.@out.println(Log.format(new StringBuilder().append(obj0[obj3.ordinal()]).append("&fr ").append(obj4).toString()));
      string text = new StringBuilder().append(obj1[obj3.ordinal()]).append(" ").append(str1).toString();
      if (!Vars.headless && (Vars.ui == null || Vars.ui.scriptfrag == null))
      {
        obj2.add((object) text);
      }
      else
      {
        if (Vars.headless)
          return;
        if (!OS.isWindows)
        {
          string[] values = ColorCodes.__\u003C\u003Evalues;
          int length = values.Length;
          for (int index = 0; index < length; ++index)
          {
            string str2 = values[index];
            string str3 = text;
            string str4 = str2;
            object obj5 = (object) "";
            object obj6 = (object) str4;
            CharSequence charSequence1;
            charSequence1.__\u003Cref\u003E = (__Null) obj6;
            CharSequence charSequence2 = charSequence1;
            object obj7 = obj5;
            charSequence1.__\u003Cref\u003E = (__Null) obj7;
            CharSequence charSequence3 = charSequence1;
            text = String.instancehelper_replace(str3, charSequence2, charSequence3);
          }
        }
        Vars.ui.scriptfrag.addMessage(Log.removeColors(text));
      }
    }

    [Modifiers]
    [LineNumberTable(339)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadLogger\u00242([In] Seq obj0, [In] EventType.ClientLoadEvent obj1)
    {
      Seq seq = obj0;
      ScriptConsoleFragment scriptfrag = Vars.ui.scriptfrag;
      Objects.requireNonNull((object) scriptfrag);
      Cons consumer = (Cons) new Vars.__\u003C\u003EAnon5(scriptfrag);
      seq.each(consumer);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 240, 168, 127, 48, 216, 226, 61, 97, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadFileLogger\u00243(
      [In] Log.LogHandler obj0,
      [In] Writer obj1,
      [In] Log.LogLevel obj2,
      [In] string obj3)
    {
      obj0.log(obj2, obj3);
      IOException ioException;
      try
      {
        obj1.write(new StringBuilder().append("[").append(Character.toUpperCase(String.instancehelper_charAt(obj2.name(), 0))).append("] ").append(Log.removeColors(obj3)).append("\n").toString());
        obj1.flush();
        return;
      }
      catch (IOException ex)
      {
        ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      Throwable.instancehelper_printStackTrace((Exception) ioException);
    }

    [Modifiers]
    [LineNumberTable(399)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadSettings\u00244() => Vars.ui.showInfo("Note: You have successfully loaded an external translation bundle.");

    [LineNumberTable(new byte[] {160, 109, 101, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync()
    {
      Vars.loadSettings();
      Vars.init();
    }

    [LineNumberTable(new byte[] {159, 133, 77, 134, 134, 140, 134, 234, 74, 239, 82, 240, 102, 134, 110, 109, 109, 109, 109, 109, 109, 109, 109, 110, 110, 110, 110, 110, 110, 110, 235, 87, 134, 134, 166, 230, 97, 234, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Vars()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.Vars"))
        return;
      Vars.failedToLaunch = false;
      Vars.loadLocales = true;
      Vars.loadedLogger = false;
      Vars.loadedFileLogger = false;
      Vars.experimental = false;
      Vars.steamPlayerName = "";
      Vars.__\u003C\u003Echarset = Charset.forName("UTF-8");
      Vars.__\u003C\u003EdefaultServers = Seq.with((object[]) new ServerGroup[0]);
      Vars.updateEditorOnChange = false;
      Vars.__\u003C\u003EplayerColors = new Color[16]
      {
        Color.valueOf("82759a"),
        Color.valueOf("c0c1c5"),
        Color.valueOf("ffffff"),
        Color.valueOf("7d2953"),
        Color.valueOf("ff074e"),
        Color.valueOf("ff072a"),
        Color.valueOf("ff76a6"),
        Color.valueOf("a95238"),
        Color.valueOf("ffa108"),
        Color.valueOf("feeb2c"),
        Color.valueOf("ffcaa8"),
        Color.valueOf("008551"),
        Color.valueOf("00e339"),
        Color.valueOf("423c7b"),
        Color.valueOf("4b5ef1"),
        Color.valueOf("2cabfe")
      };
      Vars.enableConsole = false;
      Vars.clearSectors = false;
      Vars.enableLight = true;
      Vars.enableDarkness = true;
      Vars.tree = new FileTree();
      Vars.platform = (Platform) new Vars.\u0031();
    }

    [HideFromJava]
    public virtual void loadSync() => Loadable.\u003Cdefault\u003EloadSync((Loadable) this);

    [HideFromJava]
    public virtual string getName() => Loadable.\u003Cdefault\u003EgetName((Loadable) this);

    [HideFromJava]
    public virtual Seq getDependencies() => Loadable.\u003Cdefault\u003EgetDependencies((Loadable) this);

    [Modifiers]
    public static Charset charset
    {
      [HideFromJava] get => Vars.__\u003C\u003Echarset;
    }

    [Modifiers]
    public static Seq defaultServers
    {
      [HideFromJava] get => Vars.__\u003C\u003EdefaultServers;
    }

    [Modifiers]
    public static Color[] playerColors
    {
      [HideFromJava] get => Vars.__\u003C\u003EplayerColors;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0031 : Object, Platform
    {
      [LineNumberTable(197)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
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
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) Vars.lambda\u0024init\u00240((Locale) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Log.LogHandler
    {
      private readonly string[] arg\u00241;
      private readonly string[] arg\u00242;
      private readonly Seq arg\u00243;

      internal __\u003C\u003EAnon1([In] string[] obj0, [In] string[] obj1, [In] Seq obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void log([In] Log.LogLevel obj0, [In] string obj1) => Vars.lambda\u0024loadLogger\u00241(this.arg\u00241, this.arg\u00242, this.arg\u00243, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon2([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Vars.lambda\u0024loadLogger\u00242(this.arg\u00241, (EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Log.LogHandler
    {
      private readonly Log.LogHandler arg\u00241;
      private readonly Writer arg\u00242;

      internal __\u003C\u003EAnon3([In] Log.LogHandler obj0, [In] Writer obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void log([In] Log.LogLevel obj0, [In] string obj1) => Vars.lambda\u0024loadFileLogger\u00243(this.arg\u00241, this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void run() => Vars.lambda\u0024loadSettings\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly ScriptConsoleFragment arg\u00241;

      internal __\u003C\u003EAnon5([In] ScriptConsoleFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.addMessage((string) obj0);
    }
  }
}
