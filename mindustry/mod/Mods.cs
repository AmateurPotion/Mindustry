// Decompiled with JetBrains decompiler
// Type: mindustry.mod.Mods
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
using arc.files;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.mod
{
  public class Mods : Object, Loadable
  {
    private Json json;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Scripts scripts;
    private ContentParser parser;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/struct/Seq<Larc/files/Fi;>;>;")]
    private ObjectMap bundles;
    [Signature("Larc/struct/ObjectSet<Ljava/lang/String;>;")]
    private ObjectSet specialFolders;
    private int totalSprites;
    private MultiPacker packer;
    [Signature("Larc/struct/Seq<Lmindustry/mod/Mods$LoadedMod;>;")]
    internal Seq mods;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class<*>;Lmindustry/mod/Mods$ModMeta;>;")]
    private ObjectMap metas;
    private bool requiresReload;
    private bool createdAtlas;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [LineNumberTable(new byte[] {159, 187, 232, 51, 139, 107, 107, 255, 10, 69, 107, 203, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mods()
    {
      Mods mods = this;
      this.json = new Json();
      this.parser = new ContentParser();
      this.bundles = new ObjectMap();
      this.specialFolders = ObjectSet.with((object[]) new string[3]
      {
        nameof (bundles),
        "sprites",
        "sprites-override"
      });
      this.mods = new Seq();
      this.metas = new ObjectMap();
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new Mods.__\u003C\u003EAnon0(this));
    }

    [Signature("(Larc/func/Cons<Lmindustry/mod/Mod;>;)V")]
    [LineNumberTable(new byte[] {161, 231, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void eachClass(Cons cons) => this.mods.each((Boolf) new Mods.__\u003C\u003EAnon24(), (Cons) new Mods.__\u003C\u003EAnon25(this, cons));

    [LineNumberTable(new byte[] {161, 84, 101, 171, 246, 89, 107, 35, 98, 130, 101, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadScripts()
    {
      Time.mark();
      bool[] flagArray = new bool[1]{ false };
      try
      {
        this.eachEnabled((Cons) new Mods.__\u003C\u003EAnon20(this, flagArray));
      }
      finally
      {
        Vars.content.setCurrentMod((Mods.LoadedMod) null);
      }
      if (!flagArray[0])
        return;
      Log.info("Time to initialize modded scripts: @", (object) Float.valueOf(Time.elapsed()));
    }

    [LineNumberTable(new byte[] {160, 156, 123, 159, 57, 148, 105, 255, 2, 72, 226, 57, 98, 127, 15, 140, 116, 231, 52, 233, 82, 159, 17, 106, 109, 223, 3, 226, 61, 98, 117, 135, 133, 102, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      Fi[] fiArray = Vars.modDirectory.list();
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Fi fi = fiArray[index];
        if (String.instancehelper_equals(fi.extension(), (object) "jar") || String.instancehelper_equals(fi.extension(), (object) "zip") || fi.isDirectory() && (fi.child("mod.json").exists() || fi.child("mod.hjson").exists()))
        {
          Log.debug("[Mods] Loading mod @", (object) fi);
          Exception exception;
          try
          {
            this.mods.add((object) this.loadMod(fi));
            continue;
          }
          catch (Exception ex)
          {
            exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          Exception th = exception;
          if (th is ClassNotFoundException)
          {
            string message = Throwable.instancehelper_getMessage(th);
            object obj = (object) "mindustry.plugin.Plugin";
            CharSequence charSequence1;
            charSequence1.__\u003Cref\u003E = (__Null) obj;
            CharSequence charSequence2 = charSequence1;
            if (String.instancehelper_contains(message, charSequence2))
            {
              Log.info((object) "Plugin @ is outdated and needs to be ported to 6.0! Update its main class to inherit from 'mindustry.mod.Plugin'. See https://mindustrygame.github.io/wiki/modding/6-migrationv6/");
              continue;
            }
          }
          Log.err("Failed to load mod file @. Skipping.", (object) fi);
          Log.err(th);
        }
      }
      Iterator iterator = Vars.platform.getWorkshopContent((Class) ClassLiteral<Mods.LoadedMod>.Value).iterator();
      while (iterator.hasNext())
      {
        Fi fi = (Fi) iterator.next();
        Exception exception;
        try
        {
          Mods.LoadedMod loadedMod = this.loadMod(fi);
          this.mods.add((object) loadedMod);
          loadedMod.addSteamID(fi.name());
          continue;
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception th = exception;
        Log.err("Failed to load mod workshop file @. Skipping.", (object) fi);
        Log.err(th);
      }
      this.resolveModState();
      this.sortMods();
      this.buildFiles();
    }

    [LineNumberTable(new byte[] {161, 125, 159, 1, 117, 107, 139, 130, 235, 85, 134, 127, 5, 123, 115, 127, 0, 127, 20, 105, 127, 16, 114, 226, 59, 235, 73, 165, 103, 127, 0, 172, 127, 32, 255, 53, 72, 229, 57, 98, 127, 0, 159, 8, 103, 189, 165, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadContent()
    {
      Iterator iterator1 = this.orderedMods().iterator();
      while (iterator1.hasNext())
      {
        Mods.LoadedMod mod = (Mods.LoadedMod) iterator1.next();
        if (mod.__\u003C\u003Emain != null && !mod.__\u003C\u003Emeta.hidden)
        {
          Vars.content.setCurrentMod(mod);
          mod.__\u003C\u003Emain.loadContent();
        }
      }
      Vars.content.setCurrentMod((Mods.LoadedMod) null);
      Seq seq = new Seq();
      Iterator iterator2 = this.orderedMods().iterator();
label_5:
      while (iterator2.hasNext())
      {
        Mods.LoadedMod loadedMod = (Mods.LoadedMod) iterator2.next();
        if (loadedMod.__\u003C\u003Eroot.child("content").exists())
        {
          Fi fi1 = loadedMod.__\u003C\u003Eroot.child("content");
          ContentType[] all = ContentType.__\u003C\u003Eall;
          int length = all.Length;
          int index = 0;
          while (true)
          {
            if (index < length)
            {
              ContentType contentType = all[index];
              Fi fi2 = fi1.child(new StringBuilder().append(String.instancehelper_toLowerCase(contentType.name(), (Locale) Locale.ROOT)).append("s").toString());
              if (fi2.exists())
              {
                Iterator iterator3 = fi2.findAll((Boolf) new Mods.__\u003C\u003EAnon21()).iterator();
                while (iterator3.hasNext())
                {
                  Fi fi3 = (Fi) iterator3.next();
                  seq.add((object) new Mods.\u0031LoadRun(this, contentType, fi3, loadedMod));
                }
              }
              ++index;
            }
            else
              goto label_5;
          }
        }
      }
      seq.sort();
      Iterator iterator4 = seq.iterator();
      while (iterator4.hasNext())
      {
        Mods.\u0031LoadRun obj = (Mods.\u0031LoadRun) iterator4.next();
        Content lastAdded = Vars.content.getLastAdded();
        Exception exception;
        try
        {
          Content content = this.parser.parse(obj.mod, obj.file.nameWithoutExtension(), obj.file.readString("UTF-8"), obj.file, obj.type);
          Log.debug("[@] Loaded '@'.", (object) obj.mod.__\u003C\u003Emeta.name, !(content is UnlockableContent) ? (object) content : (object) (Content) ((UnlockableContent) content).localizedName);
          continue;
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception error = exception;
        if (!object.ReferenceEquals((object) lastAdded, (object) Vars.content.getLastAdded()) && Vars.content.getLastAdded() != null)
          this.parser.markError(Vars.content.getLastAdded(), obj.mod, obj.file, error);
        else
          this.parser.markError((Content) new ErrorContent(), obj.mod, obj.file, error);
      }
      this.parser.finishParsing();
    }

    [LineNumberTable(new byte[] {161, 193, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleContentError(Content content, Exception error) => this.parser.markError(content, error);

    [LineNumberTable(265)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool skipModLoading() => Vars.failedToLaunch && Core.settings.getBool("modcrashdisable", true);

    [Signature("()Larc/struct/Seq<Lmindustry/mod/Mods$LoadedMod;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq list() => this.mods;

    [Signature("()Larc/struct/Seq<Ljava/lang/String;>;")]
    [LineNumberTable(568)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getModStrings() => this.mods.select((Boolf) new Mods.__\u003C\u003EAnon22()).map((Func) new Mods.__\u003C\u003EAnon23());

    [Signature("(Larc/struct/Seq<Ljava/lang/String;>;)Larc/struct/Seq<Ljava/lang/String;>;")]
    [LineNumberTable(new byte[] {161, 215, 103, 103, 123, 105, 136, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getIncompatibility(Seq @out)
    {
      Seq modStrings = this.getModStrings();
      Seq seq = modStrings.copy();
      Iterator iterator = modStrings.iterator();
      while (iterator.hasNext())
      {
        string str = (string) iterator.next();
        if (@out.remove((object) str))
          seq.remove((object) str);
      }
      return seq;
    }

    [Signature("(Ljava/lang/String;Larc/func/Cons2<Lmindustry/mod/Mods$LoadedMod;Larc/files/Fi;>;)V")]
    [LineNumberTable(new byte[] {9, 242, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void listFiles(string directory, Cons2 cons) => this.eachEnabled((Cons) new Mods.__\u003C\u003EAnon1(directory, cons));

    [LineNumberTable(new byte[] {2, 119, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi getConfig(Mod mod)
    {
      Mods.ModMeta modMeta = (Mods.ModMeta) this.metas.get((object) Object.instancehelper_getClass((object) mod));
      if (modMeta == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Mod is not loaded yet (or missing)!");
      }
      return Vars.modDirectory.child(modMeta.name).child("config.json");
    }

    [Signature("(Larc/func/Cons<Lmindustry/mod/Mods$LoadedMod;>;)V")]
    [LineNumberTable(new byte[] {161, 236, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void eachEnabled(Cons cons) => this.mods.each((Boolf) new Mods.__\u003C\u003EAnon5(), cons);

    [Throws(new string[] {"java.lang.Exception"})]
    [LineNumberTable(new byte[] {158, 242, 130, 133, 162, 116, 121, 201, 127, 0, 127, 0, 127, 0, 140, 104, 116, 176, 127, 13, 103, 127, 33, 127, 43, 159, 43, 158, 135, 140, 110, 173, 110, 143, 173, 144, 223, 17, 131, 131, 103, 147, 127, 17, 121, 105, 11, 232, 73, 98, 116, 127, 22, 113, 108, 179, 103, 176, 111, 113, 112, 127, 10, 98, 195, 105, 200, 105, 112, 101, 246, 69, 104, 191, 22, 103, 191, 9, 127, 14, 130, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Mods.LoadedMod loadMod([In] Fi obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      Time.mark();
      ZipFi zipFi = (ZipFi) null;
      Mods.LoadedMod loadedMod1;
      Exception exception1;
      try
      {
        Fi fi1;
        if (obj0.isDirectory())
          fi1 = obj0;
        else
          zipFi = (ZipFi) (fi1 = (Fi) new ZipFi(obj0));
        Fi root = fi1;
        if (root.list().Length == 1 && root.list()[0].isDirectory())
          root = root.list()[0];
        Fi fi2 = !root.child("mod.json").exists() ? (!root.child("mod.hjson").exists() ? (!root.child("plugin.json").exists() ? root.child("plugin.hjson") : root.child("plugin.json")) : root.child("mod.hjson")) : root.child("mod.json");
        if (!fi2.exists())
        {
          Log.warn("Mod @ doesn't have a '[mod/plugin].[h]json' file, skipping.", (object) obj0);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Invalid file: No mod.json found.");
        }
        Mods.ModMeta meta = (Mods.ModMeta) this.json.fromJson((Class) ClassLiteral<Mods.ModMeta>.Value, Jval.read(fi2.readString()).toString(Jval.Jformat.__\u003C\u003Eplain));
        meta.cleanup();
        string name1 = meta.name;
        object obj2 = (object) "";
        object obj3 = (object) " ";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence2 = charSequence1;
        object obj4 = obj2;
        charSequence1.__\u003Cref\u003E = (__Null) obj4;
        CharSequence charSequence3 = charSequence1;
        string str1 = String.instancehelper_replace(name1, charSequence2, charSequence3);
        string mainClass = meta.main != null ? meta.main : new StringBuilder().append(String.instancehelper_toLowerCase(str1, (Locale) Locale.ROOT)).append(".").append(str1).append("Mod").toString();
        string lowerCase = String.instancehelper_toLowerCase(meta.name, (Locale) Locale.ROOT);
        object obj5 = (object) "-";
        object obj6 = (object) " ";
        charSequence1.__\u003Cref\u003E = (__Null) obj6;
        CharSequence charSequence4 = charSequence1;
        object obj7 = obj5;
        charSequence1.__\u003Cref\u003E = (__Null) obj7;
        CharSequence charSequence5 = charSequence1;
        string str2 = String.instancehelper_replace(lowerCase, charSequence4, charSequence5);
        Mods.LoadedMod loadedMod2 = (Mods.LoadedMod) this.mods.find((Boolf) new Mods.__\u003C\u003EAnon26(str2));
        if (loadedMod2 != null)
        {
          if (num1 != 0 && !loadedMod2.hasSteamID())
          {
            if (loadedMod2.__\u003C\u003Eroot is ZipFi)
              loadedMod2.__\u003C\u003Eroot.delete();
            if (loadedMod2.__\u003C\u003Efile.isDirectory())
              loadedMod2.__\u003C\u003Efile.deleteDirectory();
            else
              loadedMod2.__\u003C\u003Efile.delete();
            this.mods.remove((object) loadedMod2);
          }
          else
          {
            string str3 = new StringBuilder().append("A mod with the name '").append(str2).append("' is already imported.").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str3);
          }
        }
        ClassLoader loader = (ClassLoader) null;
        Fi fi3 = root;
        if (Vars.android)
        {
          fi3 = fi3.child("classes.dex");
        }
        else
        {
          string[] strArray = String.instancehelper_split(new StringBuilder().append(String.instancehelper_replace(mainClass, '.', '/')).append(".class").toString(), "/");
          int length = strArray.Length;
          for (int index = 0; index < length; ++index)
          {
            string name2 = strArray[index];
            if (!String.instancehelper_isEmpty(name2))
              fi3 = fi3.child(name2);
          }
        }
        Mod main;
        if ((fi3.exists() || meta.java) && (!this.skipModLoading() && Core.settings.getBool(new StringBuilder().append("mod-").append(str2).append("-enabled").toString(), true)) && (mindustry.core.Version.isAtLeast(meta.minGameVersion) && (meta.getMinMajor() >= 105 || Vars.headless)))
        {
          if (Vars.ios)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("Java class mods are not supported on iOS.");
          }
          loader = Vars.platform.loadJar(obj0, mainClass);
          Class @class = Class.forName(mainClass, true, loader, Mods.__\u003CGetCallerID\u003E());
          this.metas.put((object) @class, (object) meta);
          main = (Mod) @class.getDeclaredConstructor(new Class[0], Mods.__\u003CGetCallerID\u003E()).newInstance(new object[0], Mods.__\u003CGetCallerID\u003E());
        }
        else
          main = (Mod) null;
        if (main is Plugin)
          meta.hidden = true;
        if (meta.version != null)
        {
          int num2 = String.instancehelper_indexOf(meta.version, 10);
          if (num2 != -1)
            meta.version = String.instancehelper_substring(meta.version, 0, num2);
        }
        if (this.skipModLoading())
          Core.settings.put(new StringBuilder().append("mod-").append(str2).append("-enabled").toString(), (object) Boolean.valueOf(false));
        if (!Vars.headless)
          Log.info("Loaded mod '@' in @ms", (object) meta.name, (object) Float.valueOf(Time.elapsed()));
        loadedMod1 = new Mods.LoadedMod(obj0, root, main, loader, meta);
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
          goto label_43;
        }
      }
      return loadedMod1;
label_43:
      Exception exception2 = exception1;
      zipFi?.delete();
      throw Throwable.__\u003Cunmap\u003E((Exception) exception2);
    }

    [LineNumberTable(new byte[] {160, 193, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void sortMods() => this.mods.sort(Structs.comps(Structs.comparingInt((Intf) new Mods.__\u003C\u003EAnon9()), Structs.comparing((Func) new Mods.__\u003C\u003EAnon10())));

    [LineNumberTable(new byte[] {91, 154, 123, 191, 3, 2, 97, 191, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void loadIcon([In] Mods.LoadedMod obj0)
    {
      if (!obj0.__\u003C\u003Eroot.child("icon.png").exists())
        return;
      Exception exception;
      try
      {
        obj0.iconTexture = new Texture(obj0.__\u003C\u003Eroot.child("icon.png"));
        obj0.iconTexture.setFilter(Texture.TextureFilter.__\u003C\u003Elinear);
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception th = exception;
      Log.err(new StringBuilder().append("Failed to load icon for mod '").append(obj0.__\u003C\u003Ename).append("'.").toString(), th);
    }

    [LineNumberTable(new byte[] {160, 110, 140, 116, 116, 127, 17, 229, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private MultiPacker.PageType getPage([In] Fi obj0)
    {
      string str = obj0.parent().name();
      if (String.instancehelper_equals(str, (object) "environment"))
        return MultiPacker.PageType.__\u003C\u003Eenvironment;
      if (String.instancehelper_equals(str, (object) "editor"))
        return MultiPacker.PageType.__\u003C\u003Eeditor;
      return String.instancehelper_equals(str, (object) "ui") || String.instancehelper_equals(obj0.parent().parent().name(), (object) "ui") ? MultiPacker.PageType.__\u003C\u003Eui : MultiPacker.PageType.__\u003C\u003Emain;
    }

    [LineNumberTable(new byte[] {84, 127, 1, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void loadIcons()
    {
      Iterator iterator = this.mods.iterator();
      while (iterator.hasNext())
        this.loadIcon((Mods.LoadedMod) iterator.next());
    }

    [LineNumberTable(new byte[] {160, 102, 127, 12, 127, 9, 127, 9, 127, 9, 229, 59})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private MultiPacker.PageType getPage([In] TextureAtlas.AtlasRegion obj0)
    {
      if (object.ReferenceEquals((object) obj0.texture, (object) Core.atlas.find("white").texture))
        return MultiPacker.PageType.__\u003C\u003Emain;
      if (object.ReferenceEquals((object) obj0.texture, (object) Core.atlas.find("stone1").texture))
        return MultiPacker.PageType.__\u003C\u003Eenvironment;
      if (object.ReferenceEquals((object) obj0.texture, (object) Core.atlas.find("clear-editor").texture))
        return MultiPacker.PageType.__\u003C\u003Eeditor;
      return object.ReferenceEquals((object) obj0.texture, (object) Core.atlas.find("whiteui").texture) ? MultiPacker.PageType.__\u003C\u003Eui : MultiPacker.PageType.__\u003C\u003Emain;
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [LineNumberTable(620)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Mods.LoadedMod loadMod([In] Fi obj0) => this.loadMod(obj0, false);

    [LineNumberTable(new byte[] {160, 197, 150, 127, 1, 97, 111, 111, 111, 106, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void resolveModState()
    {
      this.mods.each((Cons) new Mods.__\u003C\u003EAnon11(this));
      Iterator iterator = this.mods.iterator();
      while (iterator.hasNext())
      {
        Mods.LoadedMod loadedMod = (Mods.LoadedMod) iterator.next();
        loadedMod.state = loadedMod.isSupported() ? (!loadedMod.hasUnmetDependencies() ? (loadedMod.shouldBeEnabled() ? Mods.ModState.__\u003C\u003Eenabled : Mods.ModState.__\u003C\u003Edisabled) : Mods.ModState.__\u003C\u003EmissingDependencies) : Mods.ModState.__\u003C\u003Eunsupported;
      }
    }

    [LineNumberTable(new byte[] {160, 243, 127, 4, 127, 0, 114, 159, 3, 125, 244, 61, 232, 73, 114, 108, 127, 2, 127, 7, 105, 255, 4, 61, 235, 71, 101, 170, 103, 103, 110, 127, 39, 159, 30, 191, 8, 2, 98, 159, 20, 101, 105, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void buildFiles()
    {
      Iterator iterator1 = this.orderedMods().iterator();
label_1:
      while (iterator1.hasNext())
      {
        Mods.LoadedMod loadedMod = (Mods.LoadedMod) iterator1.next();
        int num = loadedMod.__\u003C\u003Efile.isDirectory() || loadedMod.__\u003C\u003Eroot.parent() == null ? 0 : 1;
        string str = num == 0 ? (string) null : loadedMod.__\u003C\u003Eroot.name();
        Fi[] fiArray1 = loadedMod.__\u003C\u003Eroot.list();
        int length1 = fiArray1.Length;
        for (int index = 0; index < length1; ++index)
        {
          Fi fi = fiArray1[index];
          if (fi.isDirectory() && !this.specialFolders.contains((object) fi.name()))
            fi.walk((Cons) new Mods.__\u003C\u003EAnon17(loadedMod, num != 0, str));
        }
        Fi fi1 = loadedMod.__\u003C\u003Eroot.child("bundles");
        if (fi1.exists())
        {
          Fi[] fiArray2 = fi1.list();
          int length2 = fiArray2.Length;
          int index = 0;
          while (true)
          {
            if (index < length2)
            {
              Fi fi2 = fiArray2[index];
              if (String.instancehelper_startsWith(fi2.name(), "bundle") && String.instancehelper_equals(fi2.extension(), (object) "properties"))
                ((Seq) this.bundles.get((object) fi2.nameWithoutExtension(), (Prov) new Mods.__\u003C\u003EAnon18())).add((object) fi2);
              ++index;
            }
            else
              goto label_1;
          }
        }
      }
      Events.fire((object) new EventType.FileTreeInitEvent());
      for (I18NBundle i18Nbundle = Core.bundle; i18Nbundle != null; i18Nbundle = i18Nbundle.getParent())
      {
        string str1 = i18Nbundle.getLocale().toString();
        string str2 = new StringBuilder().append("bundle").append(!String.instancehelper_isEmpty(str1) ? new StringBuilder().append("_").append(str1).toString() : "").toString();
        Iterator iterator2 = ((Seq) this.bundles.get((object) str2, (Prov) new Mods.__\u003C\u003EAnon18())).iterator();
        while (iterator2.hasNext())
        {
          Fi fi = (Fi) iterator2.next();
          Exception exception;
          try
          {
            PropertiesUtils.load(i18Nbundle.getProperties(), fi.reader());
            continue;
          }
          catch (Exception ex)
          {
            exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          Exception th = exception;
          Log.err(new StringBuilder().append("Error loading bundle: ").append((object) fi).append("/").append(str2).toString(), th);
        }
      }
    }

    [Signature("()Larc/struct/Seq<Lmindustry/mod/Mods$LoadedMod;>;")]
    [LineNumberTable(new byte[] {160, 228, 102, 102, 243, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Seq orderedMods()
    {
      ObjectSet objectSet = new ObjectSet();
      Seq seq = new Seq();
      this.eachEnabled((Cons) new Mods.__\u003C\u003EAnon15(this, objectSet, seq));
      return seq;
    }

    [LineNumberTable(new byte[] {161, 241, 184, 2, 97, 159, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void contextRun(Mods.LoadedMod mod, Runnable run)
    {
      Exception exception1;
      try
      {
        run.run();
        return;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      string str = new StringBuilder().append("Error loading mod ").append(mod.__\u003C\u003Emeta.name).toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(str, exception3);
    }

    [Signature("(Lmindustry/mod/Mods$LoadedMod;Larc/struct/Seq<Lmindustry/mod/Mods$LoadedMod;>;Larc/struct/ObjectSet<Lmindustry/mod/Mods$LoadedMod;>;)V")]
    [LineNumberTable(new byte[] {160, 221, 104, 127, 4, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void topoSort([In] Mods.LoadedMod obj0, [In] Seq obj1, [In] ObjectSet obj2)
    {
      obj2.add((object) obj0);
      obj0.dependencies.each((Boolf) new Mods.__\u003C\u003EAnon13(obj2), (Cons) new Mods.__\u003C\u003EAnon14(this, obj1, obj2));
      obj1.add((object) obj0);
    }

    [Signature("(Larc/struct/Seq<Larc/files/Fi;>;Lmindustry/mod/Mods$LoadedMod;Z)V")]
    [LineNumberTable(new byte[] {159, 104, 66, 126, 103, 121, 109, 127, 61, 119, 255, 12, 59, 255, 77, 76, 226, 57, 98, 247, 69, 130, 101, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void packSprites([In] Seq obj0, [In] Mods.LoadedMod obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      Iterator iterator = obj0.iterator();
      while (iterator.hasNext())
      {
        Fi fi = (Fi) iterator.next();
        InputStream input;
        Exception exception1;
        IOException ioException1;
        try
        {
          input = fi.read();
          try
          {
            byte[] encodedData = Streams.copyBytes(input, Math.max((int) fi.length(), 512));
            Pixmap pixmap = new Pixmap(encodedData, 0, encodedData.Length);
            this.packer.add(this.getPage(fi), new StringBuilder().append(num == 0 ? "" : new StringBuilder().append(obj1.__\u003C\u003Ename).append("-").toString()).append(fi.nameWithoutExtension()).toString(), new PixmapRegion(pixmap));
            pixmap.dispose();
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_9;
          }
          if (input != null)
          {
            input.close();
            continue;
          }
          continue;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_10;
        }
label_9:
        Exception exception2 = exception1;
        Exception exception3;
        Exception exception4;
        IOException ioException2;
        try
        {
          exception3 = exception2;
          if (input != null)
          {
            try
            {
              input.close();
              goto label_20;
            }
            catch (Exception ex)
            {
              exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
          }
          else
            goto label_20;
        }
        catch (IOException ex)
        {
          ioException2 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_16;
        }
        Exception exception5 = exception4;
        IOException ioException3;
        try
        {
          Exception exception6 = exception5;
          Throwable.instancehelper_addSuppressed(exception3, exception6);
          goto label_20;
        }
        catch (IOException ex)
        {
          ioException3 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        IOException ioException4 = ioException3;
        goto label_23;
label_16:
        ioException4 = ioException2;
        goto label_23;
label_20:
        IOException ioException5;
        try
        {
          throw Throwable.__\u003Cunmap\u003E(exception3);
        }
        catch (IOException ex)
        {
          ioException5 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        ioException4 = ioException5;
        goto label_23;
label_10:
        ioException4 = ioException1;
label_23:
        IOException ioException6 = ioException4;
        Core.app.post((Runnable) new Mods.__\u003C\u003EAnon7(obj1, ioException6));
        break;
      }
      this.totalSprites += obj0.size;
    }

    [Modifiers]
    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.ClientLoadEvent obj0) => Core.app.post((Runnable) new Mods.__\u003C\u003EAnon34(this));

    [Modifiers]
    [LineNumberTable(new byte[] {10, 109, 104, 117, 41, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024listFiles\u00241([In] string obj0, [In] Cons2 obj1, [In] Mods.LoadedMod obj2)
    {
      Fi fi1 = obj2.__\u003C\u003Eroot.child(obj0);
      if (!fi1.exists())
        return;
      Fi[] fiArray = fi1.list();
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Fi fi2 = fiArray[index];
        obj1.get((object) obj2, (object) fi2);
      }
    }

    [Modifiers]
    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getMod\u00242([In] string obj0, [In] Mods.LoadedMod obj1) => String.instancehelper_equals(obj1.__\u003C\u003Ename, (object) obj0);

    [Modifiers]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getMod\u00243([In] Class obj0, [In] Mods.LoadedMod obj1) => obj1.enabled() && obj1.__\u003C\u003Emain != null && object.ReferenceEquals((object) Object.instancehelper_getClass((object) obj1.__\u003C\u003Emain), (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {51, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024importMod\u00244([In] Mods.LoadedMod obj0) => this.loadIcon(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {72, 127, 1, 127, 1, 105, 105, 127, 20, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024loadAsync\u00247([In] Mods.LoadedMod obj0)
    {
      Seq all1 = obj0.__\u003C\u003Eroot.child("sprites").findAll((Boolf) new Mods.__\u003C\u003EAnon32());
      Seq all2 = obj0.__\u003C\u003Eroot.child("sprites-override").findAll((Boolf) new Mods.__\u003C\u003EAnon33());
      this.packSprites(all1, obj0, true);
      this.packSprites(all2, obj0, false);
      Log.debug("Packed @ images for mod '@'.", (object) Integer.valueOf(all1.size + all2.size), (object) obj0.__\u003C\u003Emeta.name);
      this.totalSprites += all1.size + all2.size;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {110, 126, 102, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024packSprites\u00248([In] Mods.LoadedMod obj0, [In] IOException obj1)
    {
      Log.err("Error packing images for mod: @", (object) obj0.__\u003C\u003Emeta.name);
      Log.err((Exception) obj1);
      if (Vars.headless)
        return;
      Vars.ui.showException((Exception) obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 83, 127, 13, 102, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024loadSync\u00249([In] Content obj0)
    {
      Content content = obj0;
      UnlockableContent unlockableContent;
      if (!(content is UnlockableContent) || !object.ReferenceEquals((object) (unlockableContent = (UnlockableContent) content), (object) (UnlockableContent) content) || obj0.minfo.mod == null)
        return;
      unlockableContent.load();
      unlockableContent.createIcons(this.packer);
    }

    [Modifiers]
    [LineNumberTable(307)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024sortMods\u002410([In] Mods.LoadedMod obj0) => obj0.state.ordinal();

    [Modifiers]
    [LineNumberTable(307)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024sortMods\u002411([In] Mods.LoadedMod obj0) => obj0.__\u003C\u003Ename;

    [LineNumberTable(new byte[] {160, 209, 108, 108, 159, 2, 112, 110, 31, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateDependencies([In] Mods.LoadedMod obj0)
    {
      obj0.dependencies.clear();
      obj0.missingDependencies.clear();
      obj0.dependencies = obj0.__\u003C\u003Emeta.dependencies.map((Func) new Mods.__\u003C\u003EAnon12(this));
      for (int index = 0; index < obj0.dependencies.size; ++index)
      {
        if (obj0.dependencies.get(index) == null)
          obj0.missingDependencies.add((object) (string) obj0.__\u003C\u003Emeta.dependencies.get(index));
      }
    }

    [LineNumberTable(353)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mods.LoadedMod locateMod(string name) => (Mods.LoadedMod) this.mods.find((Boolf) new Mods.__\u003C\u003EAnon16(name));

    [Modifiers]
    [LineNumberTable(336)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024topoSort\u002412([In] ObjectSet obj0, [In] Mods.LoadedMod obj1) => !obj0.contains((object) obj1);

    [Modifiers]
    [LineNumberTable(336)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024topoSort\u002413([In] Seq obj0, [In] ObjectSet obj1, [In] Mods.LoadedMod obj2) => this.topoSort(obj2, obj0, obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 231, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024orderedMods\u002414([In] ObjectSet obj0, [In] Seq obj1, [In] Mods.LoadedMod obj2)
    {
      if (obj0.contains((object) obj2))
        return;
      this.topoSort(obj2, obj1, obj0);
    }

    [Modifiers]
    [LineNumberTable(353)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024locateMod\u002415([In] string obj0, [In] Mods.LoadedMod obj1) => obj1.enabled() && String.instancehelper_equals(obj1.__\u003C\u003Ename, (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 52, 162, 127, 18, 63, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024buildFiles\u002416(
      [In] Mods.LoadedMod obj0,
      [In] bool obj1,
      [In] string obj2,
      [In] Fi obj3)
    {
      int num = obj1 ? 1 : 0;
      Vars.tree.addFile(!obj0.__\u003C\u003Efile.isDirectory() ? (num == 0 ? obj3.path() : String.instancehelper_substring(obj3.path(), String.instancehelper_length(obj2) + 1)) : String.instancehelper_substring(obj3.path(), 1 + String.instancehelper_length(obj0.__\u003C\u003Efile.path())), obj3);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 89, 122, 139, 127, 1, 127, 18, 150, 104, 144, 100, 255, 0, 70, 226, 59, 97, 215, 130, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024loadScripts\u002420([In] bool[] obj0, [In] Mods.LoadedMod obj1)
    {
      if (!obj1.__\u003C\u003Eroot.child("scripts").exists())
        return;
      Vars.content.setCurrentMod(obj1);
      Seq all = obj1.__\u003C\u003Eroot.child("scripts").findAll((Boolf) new Mods.__\u003C\u003EAnon29());
      Fi file = all.size != 1 ? obj1.__\u003C\u003Eroot.child("scripts").child("main.js") : (Fi) all.first();
      if (file.exists())
      {
        if (!file.isDirectory())
        {
          Exception exception1;
          try
          {
            if (this.scripts == null)
              this.scripts = Vars.platform.createScripts();
            obj0[0] = true;
            this.scripts.run(obj1, file);
            return;
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          Exception exception2 = exception1;
          Core.app.post((Runnable) new Mods.__\u003C\u003EAnon30(file, obj1, exception2));
          return;
        }
      }
      Core.app.post((Runnable) new Mods.__\u003C\u003EAnon31(obj1));
    }

    [Modifiers]
    [LineNumberTable(532)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024loadContent\u002421([In] Fi obj0) => String.instancehelper_equals(obj0.extension(), (object) "json") || String.instancehelper_equals(obj0.extension(), (object) "hjson");

    [Modifiers]
    [LineNumberTable(568)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getModStrings\u002422([In] Mods.LoadedMod obj0) => !obj0.__\u003C\u003Emeta.hidden && obj0.enabled();

    [Modifiers]
    [LineNumberTable(568)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024getModStrings\u002423([In] Mods.LoadedMod obj0) => new StringBuilder().append(obj0.__\u003C\u003Ename).append(":").append(obj0.__\u003C\u003Emeta.version).toString();

    [Modifiers]
    [LineNumberTable(601)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024eachClass\u002424([In] Mods.LoadedMod obj0) => obj0.__\u003C\u003Emain != null;

    [Modifiers]
    [LineNumberTable(601)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024eachClass\u002426([In] Cons obj0, [In] Mods.LoadedMod obj1) => this.contextRun(obj1, (Runnable) new Mods.__\u003C\u003EAnon28(obj0, obj1));

    [Modifiers]
    [LineNumberTable(653)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024loadMod\u002427([In] string obj0, [In] Mods.LoadedMod obj1) => String.instancehelper_equals(obj1.__\u003C\u003Ename, (object) obj0);

    [Modifiers]
    [LineNumberTable(601)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024eachClass\u002425([In] Cons obj0, [In] Mods.LoadedMod obj1) => obj0.get((object) obj1.__\u003C\u003Emain);

    [Modifiers]
    [LineNumberTable(462)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024loadScripts\u002417([In] Fi obj0) => obj0.extEquals("js");

    [Modifiers]
    [LineNumberTable(new byte[] {161, 103, 127, 8, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadScripts\u002418(
      [In] Fi obj0,
      [In] Mods.LoadedMod obj1,
      [In] Exception obj2)
    {
      Log.err("Error loading main script @ for mod @.", (object) obj0.name(), (object) obj1.__\u003C\u003Emeta.name);
      Log.err(obj2);
    }

    [Modifiers]
    [LineNumberTable(478)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadScripts\u002419([In] Mods.LoadedMod obj0) => Log.err("No main.js found for mod @.", (object) obj0.__\u003C\u003Emeta.name);

    [Modifiers]
    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024loadAsync\u00245([In] Fi obj0) => String.instancehelper_equals(obj0.extension(), (object) "png");

    [Modifiers]
    [LineNumberTable(123)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024loadAsync\u00246([In] Fi obj0) => String.instancehelper_equals(obj0.extension(), (object) "png");

    [LineNumberTable(new byte[] {161, 30, 117, 207, 119, 111, 235, 101, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkWarnings()
    {
      if (this.scripts != null && this.scripts.hasErrored())
        Vars.ui.showErrorMessage("@mod.scripts.disable");
      if (!this.mods.contains((Boolf) new Mods.__\u003C\u003EAnon19()))
        return;
      Vars.ui.loadfrag.hide();
      new Mods.\u0031(this, "").show();
    }

    [LineNumberTable(71)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mods.LoadedMod getMod(string name) => (Mods.LoadedMod) this.mods.find((Boolf) new Mods.__\u003C\u003EAnon2(name));

    [Signature("(Ljava/lang/Class<+Lmindustry/mod/Mod;>;)Lmindustry/mod/Mods$LoadedMod;")]
    [LineNumberTable(76)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mods.LoadedMod getMod(Class type) => (Mods.LoadedMod) this.mods.find((Boolf) new Mods.__\u003C\u003EAnon3(type));

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {31, 103, 130, 98, 127, 12, 191, 8, 159, 6, 135, 106, 109, 135, 127, 27, 134, 183, 127, 12, 98, 103, 104, 98, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mods.LoadedMod importMod(Fi file)
    {
      string str1 = file.nameWithoutExtension();
      string str2 = str1;
      int num1 = 1;
      StringBuilder stringBuilder;
      int num2;
      for (; Vars.modDirectory.child(new StringBuilder().append(str2).append(".zip").toString()).exists(); str2 = stringBuilder.append(num2).toString())
      {
        stringBuilder = new StringBuilder().append(str1).append("");
        num2 = num1;
        ++num1;
      }
      Fi dest = Vars.modDirectory.child(new StringBuilder().append(str2).append(".zip").toString());
      file.copyTo(dest);
      Mods.LoadedMod loadedMod1;
      IOException ioException1;
      Exception exception1;
      try
      {
        try
        {
          Mods.LoadedMod loadedMod2 = this.loadMod(dest, true);
          this.mods.add((object) loadedMod2);
          this.requiresReload = true;
          Core.settings.put(new StringBuilder().append("mod-").append(loadedMod2.__\u003C\u003Ename).append("-enabled").toString(), (object) Boolean.valueOf(true));
          this.sortMods();
          Core.app.post((Runnable) new Mods.__\u003C\u003EAnon4(this, loadedMod2));
          loadedMod1 = loadedMod2;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_8;
        }
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_9;
      }
      return loadedMod1;
label_8:
      IOException ioException2 = ioException1;
      dest.delete();
      throw Throwable.__\u003Cunmap\u003E((Exception) ioException2);
label_9:
      Exception exception2 = exception1;
      dest.delete();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException(exception3);
    }

    [LineNumberTable(new byte[] {66, 120, 133, 139, 241, 73, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync()
    {
      if (!this.mods.contains((Boolf) new Mods.__\u003C\u003EAnon5()))
        return;
      Time.mark();
      this.packer = new MultiPacker();
      this.eachEnabled((Cons) new Mods.__\u003C\u003EAnon6(this));
      Log.debug("Time to pack textures: @", (object) Float.valueOf(Time.elapsed()));
    }

    [LineNumberTable(new byte[] {122, 134, 105, 165, 108, 127, 7, 135, 127, 5, 104, 116, 157, 130, 190, 178, 127, 2, 50, 232, 73, 118, 112, 191, 8, 107, 103, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadSync()
    {
      this.loadIcons();
      if (this.packer == null)
        return;
      Time.mark();
      if (this.totalSprites > 0)
      {
        if (!this.createdAtlas)
        {
          TextureAtlas.__\u003Cclinit\u003E();
          Core.atlas = new TextureAtlas(Core.files.@internal("sprites/sprites.atlas"));
        }
        this.createdAtlas = true;
        Iterator iterator = Core.atlas.getRegions().iterator();
        while (iterator.hasNext())
        {
          TextureAtlas.AtlasRegion region = (TextureAtlas.AtlasRegion) iterator.next();
          MultiPacker.PageType page = this.getPage(region);
          if (!this.packer.has(page, region.name))
            this.packer.add(page, region.name, Core.atlas.getPixmap(region));
        }
        Texture.TextureFilter filter = !Core.settings.getBool("linear") ? Texture.TextureFilter.__\u003C\u003Enearest : Texture.TextureFilter.__\u003C\u003Elinear;
        this.packer.flush(filter, Core.atlas);
        Seq[] contentMap = Vars.content.getContentMap();
        int length = contentMap.Length;
        for (int index = 0; index < length; ++index)
          contentMap[index].each((Cons) new Mods.__\u003C\u003EAnon8(this));
        Core.atlas = this.packer.flush(filter, new TextureAtlas());
        Core.atlas.setErrorRegion("error");
        Log.debug("Total pages: @", (object) Integer.valueOf(Core.atlas.getTextures().size));
      }
      this.packer.dispose();
      this.packer = (MultiPacker) null;
      Log.debug("Time to update textures: @", (object) Float.valueOf(Time.elapsed()));
    }

    [LineNumberTable(new byte[] {160, 120, 109, 172, 159, 7, 99, 111, 129, 109, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeMod(Mods.LoadedMod mod)
    {
      if (mod.__\u003C\u003Eroot is ZipFi)
        mod.__\u003C\u003Eroot.delete();
      if ((!mod.__\u003C\u003Efile.isDirectory() ? (mod.__\u003C\u003Efile.delete() ? 1 : 0) : (mod.__\u003C\u003Efile.deleteDirectory() ? 1 : 0)) == 0)
      {
        Vars.ui.showErrorMessage("@mod.delete.error");
      }
      else
      {
        this.mods.remove((object) mod);
        mod.dispose();
        this.requiresReload = true;
      }
    }

    [LineNumberTable(new byte[] {160, 136, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scripts getScripts()
    {
      if (this.scripts == null)
        this.scripts = Vars.platform.createScripts();
      return this.scripts;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasScripts() => this.scripts != null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool requiresReload() => this.requiresReload;

    [LineNumberTable(449)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasContentErrors() => this.mods.contains((Boolf) new Mods.__\u003C\u003EAnon19()) || this.scripts != null && this.scripts.hasErrored();

    [LineNumberTable(new byte[] {158, 255, 98, 108, 127, 26, 103, 117, 118, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEnabled(Mods.LoadedMod mod, bool enabled)
    {
      int num = enabled ? 1 : 0;
      if ((mod.enabled() ? 1 : 0) == num)
        return;
      Core.settings.put(new StringBuilder().append("mod-").append(mod.__\u003C\u003Ename).append("-enabled").toString(), (object) Boolean.valueOf(num != 0));
      this.requiresReload = true;
      mod.state = num == 0 ? Mods.ModState.__\u003C\u003Edisabled : Mods.ModState.__\u003C\u003Eenabled;
      this.mods.each((Cons) new Mods.__\u003C\u003EAnon11(this));
      this.sortMods();
    }

    [HideFromJava]
    public virtual string getName() => Loadable.\u003Cdefault\u003EgetName((Loadable) this);

    [HideFromJava]
    public virtual Seq getDependencies() => Loadable.\u003Cdefault\u003EgetDependencies((Loadable) this);

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Mods.__\u003CcallerID\u003E == null)
        Mods.__\u003CcallerID\u003E = (CallerID) new Mods.__\u003CCallerID\u003E();
      return Mods.__\u003CcallerID\u003E;
    }

    [EnclosingMethod(null, "checkWarnings", "()V")]
    [SpecialName]
    internal class \u0031 : Dialog
    {
      [Modifiers]
      internal Mods this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 48, 255, 7, 86})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00244([In] Table obj0) => this.this\u00240.mods.each((Boolf) new Mods.\u0031.__\u003C\u003EAnon2(), (Cons) new Mods.\u0031.__\u003C\u003EAnon3(this, obj0));

      [Modifiers]
      [LineNumberTable(418)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00240([In] Mods.LoadedMod obj0) => obj0.enabled() && obj0.hasContentErrors();

      [Modifiers]
      [LineNumberTable(new byte[] {161, 49, 127, 13, 103, 127, 1, 103, 242, 78, 102, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00243([In] Table obj0, [In] Mods.LoadedMod obj1)
      {
        Table table = obj0;
        object name = (object) obj1.__\u003C\u003Ename;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) name;
        CharSequence text = charSequence;
        table.add(text).color(Pal.accent).left();
        obj0.row();
        obj0.image().fillX().pad(4f).color(Pal.accent);
        obj0.row();
        obj0.table((Cons) new Mods.\u0031.__\u003C\u003EAnon4(this, obj1)).left();
        obj0.row();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 54, 113, 127, 4, 127, 23, 255, 12, 71, 117, 103, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00242([In] Mods.LoadedMod obj0, [In] Table obj1)
      {
        obj1.left().marginLeft(15f);
        ObjectSet.ObjectSetIterator objectSetIterator = obj0.erroredContent.iterator();
        while (((Iterator) objectSetIterator).hasNext())
        {
          Content content = (Content) ((Iterator) objectSetIterator).next();
          Table table = obj1;
          object obj = (object) content.minfo.sourceFile.nameWithoutExtension();
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table.add(text).left().padRight(10f);
          obj1.button("@details", (Drawable) Icon.downOpen, Styles.transt, (Runnable) new Mods.\u0031.__\u003C\u003EAnon5(this, content)).size(190f, 50f).left().marginLeft(6f);
          obj1.row();
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 58, 236, 69, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241([In] Content obj0) => new Mods.\u0031.\u0031(this, "", obj0).show();

      [LineNumberTable(new byte[] {161, 37, 144, 103, 113, 127, 2, 108, 127, 27, 108, 127, 32, 108, 247, 89, 108, 127, 12})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Mods obj0, [In] string obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        Mods.\u0031 obj2 = this;
        this.setFillParent(true);
        this.__\u003C\u003Econt.margin(15f);
        Table cont1 = this.__\u003C\u003Econt;
        object obj3 = (object) "@error.title";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence text1 = charSequence;
        cont1.add(text1);
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.image().width(300f).pad(2f).colspan(2).height(4f).color(Color.__\u003C\u003Escarlet);
        this.__\u003C\u003Econt.row();
        Table cont2 = this.__\u003C\u003Econt;
        object obj4 = (object) "@mod.errors";
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        CharSequence text2 = charSequence;
        ((Label) cont2.add(text2).wrap().growX().center().get()).setAlignment(1);
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.pane((Cons) new Mods.\u0031.__\u003C\u003EAnon0(this));
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.button("@ok", (Runnable) new Mods.\u0031.__\u003C\u003EAnon1(this)).size(300f, 50f);
      }

      [HideFromJava]
      static \u0031() => Dialog.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, "<init>", "(Lmindustry.mod.Mods;Ljava.lang.String;)V")]
      [SpecialName]
      internal new class \u0031 : Dialog
      {
        [Modifiers]
        internal Content val\u0024c;
        [Modifiers]
        internal Mods.\u0031 this\u00241;

        [SpecialName]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public new static void __\u003Cclinit\u003E()
        {
        }

        [Modifiers]
        [LineNumberTable(430)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void lambda\u0024new\u00240([In] Content obj0, [In] Table obj1)
        {
          Table table = obj1;
          object error = (object) obj0.minfo.error;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) error;
          CharSequence text = charSequence;
          table.add(text).wrap().grow().labelAlign(1, 8);
        }

        [LineNumberTable(new byte[] {161, 58, 119, 103, 127, 2, 108, 127, 17})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] Mods.\u0031 obj0, [In] string obj1, [In] Content obj2)
        {
          this.this\u00241 = obj0;
          this.val\u0024c = obj2;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1);
          Mods.\u0031.\u0031 obj = this;
          this.setFillParent(true);
          this.__\u003C\u003Econt.pane((Cons) new Mods.\u0031.\u0031.__\u003C\u003EAnon0(this.val\u0024c)).grow();
          this.__\u003C\u003Econt.row();
          this.__\u003C\u003Econt.button("@ok", (Drawable) Icon.left, (Runnable) new Mods.\u0031.\u0031.__\u003C\u003EAnon1(this)).size(240f, 60f);
        }

        [HideFromJava]
        static \u0031() => Dialog.__\u003Cclinit\u003E();

        [SpecialName]
        private new sealed class __\u003C\u003EAnon0 : Cons
        {
          private readonly Content arg\u00241;

          internal __\u003C\u003EAnon0([In] Content obj0) => this.arg\u00241 = obj0;

          public void get([In] object obj0) => Mods.\u0031.\u0031.lambda\u0024new\u00240(this.arg\u00241, (Table) obj0);
        }

        [SpecialName]
        private new sealed class __\u003C\u003EAnon1 : Runnable
        {
          private readonly Mods.\u0031.\u0031 arg\u00241;

          internal __\u003C\u003EAnon1([In] Mods.\u0031.\u0031 obj0) => this.arg\u00241 = obj0;

          public void run() => this.arg\u00241.hide();
        }
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly Mods.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] Mods.\u0031 obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00244((Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly Mods.\u0031 arg\u00241;

        internal __\u003C\u003EAnon1([In] Mods.\u0031 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Boolf
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public bool get([In] object obj0) => (Mods.\u0031.lambda\u0024new\u00240((Mods.LoadedMod) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly Mods.\u0031 arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon3([In] Mods.\u0031 obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243(this.arg\u00242, (Mods.LoadedMod) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        private readonly Mods.\u0031 arg\u00241;
        private readonly Mods.LoadedMod arg\u00242;

        internal __\u003C\u003EAnon4([In] Mods.\u0031 obj0, [In] Mods.LoadedMod obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00242(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Runnable
      {
        private readonly Mods.\u0031 arg\u00241;
        private readonly Content arg\u00242;

        internal __\u003C\u003EAnon5([In] Mods.\u0031 obj0, [In] Content obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00241(this.arg\u00242);
      }
    }

    [Signature("Ljava/lang/Object;Ljava/lang/Comparable<Lmindustry/mod/Mods$1LoadRun;>;")]
    [EnclosingMethod(null, "loadContent", "()V")]
    [Implements(new string[] {"java.lang.Comparable"})]
    [SpecialName]
    internal class \u0031LoadRun : Object, Comparable
    {
      [Modifiers]
      internal ContentType type;
      [Modifiers]
      internal Fi file;
      [Modifiers]
      internal Mods.LoadedMod mod;
      [Modifiers]
      internal Mods this\u00240;

      [LineNumberTable(new byte[] {161, 140, 111, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public \u0031LoadRun([In] Mods obj0, [In] ContentType obj1, [In] Fi obj2, [In] Mods.LoadedMod obj3)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Mods.\u0031LoadRun obj = this;
        this.type = obj1;
        this.file = obj2;
        this.mod = obj3;
      }

      [LineNumberTable(new byte[] {161, 148, 124, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compareTo([In] Mods.\u0031LoadRun obj0)
      {
        int num = String.instancehelper_compareTo(this.mod.__\u003C\u003Ename, obj0.mod.__\u003C\u003Ename);
        return num != 0 ? num : String.instancehelper_compareTo(this.file.name(), obj0.file.name());
      }

      [Modifiers]
      [LineNumberTable(505)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compareTo([In] object obj0) => this.compareTo((Mods.\u0031LoadRun) obj0);

      int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
        [In] object obj0)
      {
        return this.compareTo(obj0);
      }
    }

    [Implements(new string[] {"mindustry.type.Publishable", "arc.util.Disposable"})]
    public class LoadedMod : Object, Publishable, Disposable
    {
      internal Fi __\u003C\u003Efile;
      internal Fi __\u003C\u003Eroot;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal Mod __\u003C\u003Emain;
      internal string __\u003C\u003Ename;
      internal Mods.ModMeta __\u003C\u003Emeta;
      [Signature("Larc/struct/Seq<Lmindustry/mod/Mods$LoadedMod;>;")]
      public Seq dependencies;
      [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
      public Seq missingDependencies;
      [Signature("Larc/struct/Seq<Larc/files/Fi;>;")]
      public Seq scripts;
      [Signature("Larc/struct/ObjectSet<Lmindustry/ctype/Content;>;")]
      public ObjectSet erroredContent;
      public Mods.ModState state;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Texture iconTexture;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public ClassLoader loader;

      [LineNumberTable(793)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool enabled() => object.ReferenceEquals((object) this.state, (object) Mods.ModState.__\u003C\u003Eenabled) || object.ReferenceEquals((object) this.state, (object) Mods.ModState.__\u003C\u003EcontentErrors);

      [LineNumberTable(805)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasContentErrors() => !this.erroredContent.isEmpty();

      [LineNumberTable(new byte[] {162, 201, 104, 107, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dispose()
      {
        if (this.iconTexture == null)
          return;
        this.iconTexture.dispose();
        this.iconTexture = (Texture) null;
      }

      [LineNumberTable(new byte[] {162, 214, 127, 11})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void addSteamID(string id) => Core.settings.put(new StringBuilder().append(this.__\u003C\u003Ename).append("-steamid").toString(), (object) id);

      [LineNumberTable(new byte[] {162, 184, 138})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isSupported() => !this.isOutdated() && mindustry.core.Version.isAtLeast(this.__\u003C\u003Emeta.minGameVersion);

      [LineNumberTable(801)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasUnmetDependencies() => !this.missingDependencies.isEmpty();

      [LineNumberTable(797)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool shouldBeEnabled() => Core.settings.getBool(new StringBuilder().append("mod-").append(this.__\u003C\u003Ename).append("-enabled").toString(), true);

      [HideFromJava]
      public virtual bool hasSteamID() => Publishable.\u003Cdefault\u003EhasSteamID((Publishable) this);

      [LineNumberTable(new byte[] {162, 143, 232, 50, 139, 139, 139, 139, 235, 71, 103, 103, 104, 103, 104, 127, 41})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LoadedMod(Fi file, Fi root, Mod main, ClassLoader loader, Mods.ModMeta meta)
      {
        Mods.LoadedMod loadedMod = this;
        this.dependencies = new Seq();
        this.missingDependencies = new Seq();
        this.scripts = new Seq();
        this.erroredContent = new ObjectSet();
        this.state = Mods.ModState.__\u003C\u003Eenabled;
        this.__\u003C\u003Eroot = root;
        this.__\u003C\u003Efile = file;
        this.loader = loader;
        this.__\u003C\u003Emain = main;
        this.__\u003C\u003Emeta = meta;
        string lowerCase = String.instancehelper_toLowerCase(meta.name, (Locale) Locale.ROOT);
        object obj1 = (object) "-";
        object obj2 = (object) " ";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        this.__\u003C\u003Ename = String.instancehelper_replace(lowerCase, charSequence2, charSequence3);
      }

      [LineNumberTable(818)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isOutdated() => this.getMinMajor() < 105;

      [LineNumberTable(822)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getMinMajor() => this.__\u003C\u003Emeta.getMinMajor();

      [LineNumberTable(780)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isJava() => this.__\u003C\u003Emeta.java || this.__\u003C\u003Emain != null;

      [LineNumberTable(785)]
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getRepo() => Core.settings.getString(new StringBuilder().append("mod-").append(this.__\u003C\u003Ename).append("-repo").toString(), this.__\u003C\u003Emeta.repo);

      [LineNumberTable(new byte[] {162, 163, 127, 21})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setRepo(string repo) => Core.settings.put(new StringBuilder().append("mod-").append(this.__\u003C\u003Ename).append("-repo").toString(), (object) repo);

      [LineNumberTable(835)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string getSteamID() => Core.settings.getString(new StringBuilder().append(this.__\u003C\u003Ename).append("-steamid").toString(), (string) null);

      [LineNumberTable(new byte[] {162, 219, 127, 10})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void removeSteamID() => Core.settings.remove(new StringBuilder().append(this.__\u003C\u003Ename).append("-steamid").toString());

      [LineNumberTable(850)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string steamTitle() => this.__\u003C\u003Emeta.name;

      [LineNumberTable(855)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string steamDescription() => this.__\u003C\u003Emeta.description;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string steamTag() => "mod";

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Fi createSteamFolder(string id) => this.__\u003C\u003Efile;

      [LineNumberTable(870)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Fi createSteamPreview(string id) => this.__\u003C\u003Efile.child("preview.png");

      [LineNumberTable(new byte[] {162, 249, 109, 111, 162, 119, 111, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool prePublish()
      {
        if (!this.__\u003C\u003Efile.isDirectory())
        {
          Vars.ui.showErrorMessage("@mod.folder.missing");
          return false;
        }
        if (this.__\u003C\u003Efile.child("preview.png").exists())
          return true;
        Vars.ui.showErrorMessage("@mod.preview.missing");
        return false;
      }

      [LineNumberTable(890)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append("LoadedMod{file=").append((object) this.__\u003C\u003Efile).append(", root=").append((object) this.__\u003C\u003Eroot).append(", name='").append(this.__\u003C\u003Ename).append('\'').append('}').toString();

      [HideFromJava]
      public virtual Seq extraTags() => Publishable.\u003Cdefault\u003EextraTags((Publishable) this);

      [HideFromJava]
      public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

      [Modifiers]
      public Fi file
      {
        [HideFromJava] get => this.__\u003C\u003Efile;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Efile = value;
      }

      [Modifiers]
      public Fi root
      {
        [HideFromJava] get => this.__\u003C\u003Eroot;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eroot = value;
      }

      [Modifiers]
      public Mod main
      {
        [HideFromJava] get => this.__\u003C\u003Emain;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Emain = value;
      }

      [Modifiers]
      public string name
      {
        [HideFromJava] get => this.__\u003C\u003Ename;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ename = value;
      }

      [Modifiers]
      public Mods.ModMeta meta
      {
        [HideFromJava] get => this.__\u003C\u003Emeta;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Emeta = value;
      }
    }

    public class ModMeta : Object
    {
      public string name;
      public string displayName;
      public string author;
      public string description;
      public string version;
      public string main;
      public string minGameVersion;
      public string repo;
      [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
      public Seq dependencies;
      public bool hidden;
      public bool java;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string displayName() => this.displayName == null ? this.name : this.displayName;

      [LineNumberTable(new byte[] {163, 31, 127, 10, 127, 10, 127, 10})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void cleanup()
      {
        CharSequence str;
        if (this.displayName != null)
        {
          object displayName = (object) this.displayName;
          str.__\u003Cref\u003E = (__Null) displayName;
          this.displayName = Strings.stripColors(str);
        }
        if (this.author != null)
        {
          object author = (object) this.author;
          str.__\u003Cref\u003E = (__Null) author;
          this.author = Strings.stripColors(str);
        }
        if (this.description == null)
          return;
        object description = (object) this.description;
        str.__\u003Cref\u003E = (__Null) description;
        this.description = Strings.stripColors(str);
      }

      [LineNumberTable(new byte[] {163, 37, 118, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getMinMajor()
      {
        string s = this.minGameVersion != null ? this.minGameVersion : "0";
        int num = String.instancehelper_indexOf(s, ".");
        return num != -1 ? Strings.parseInt(String.instancehelper_substring(s, 0, num), 0) : Strings.parseInt(s, 0);
      }

      [LineNumberTable(new byte[] {163, 17, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ModMeta()
      {
        Mods.ModMeta modMeta = this;
        this.minGameVersion = "0";
        this.dependencies = Seq.with((object[]) new string[0]);
      }

      [LineNumberTable(926)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append("ModMeta{name='").append(this.name).append('\'').append(", author='").append(this.author).append('\'').append(", version='").append(this.version).append('\'').append(", main='").append(this.main).append('\'').append(", minGameVersion='").append(this.minGameVersion).append('\'').append(", hidden=").append(this.hidden).append(", repo=").append(this.repo).append('}').toString();
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/mod/Mods$ModState;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ModState : Enum
    {
      [Modifiers]
      internal static Mods.ModState __\u003C\u003Eenabled;
      [Modifiers]
      internal static Mods.ModState __\u003C\u003EcontentErrors;
      [Modifiers]
      internal static Mods.ModState __\u003C\u003EmissingDependencies;
      [Modifiers]
      internal static Mods.ModState __\u003C\u003Eunsupported;
      [Modifiers]
      internal static Mods.ModState __\u003C\u003Edisabled;
      [Modifiers]
      private static Mods.ModState[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(938)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ModState([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(938)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Mods.ModState[] values() => (Mods.ModState[]) Mods.ModState.\u0024VALUES.Clone();

      [LineNumberTable(938)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Mods.ModState valueOf(string name) => (Mods.ModState) Enum.valueOf((Class) ClassLiteral<Mods.ModState>.Value, name);

      [LineNumberTable(new byte[] {158, 164, 173, 112, 112, 112, 112, 240, 59})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ModState()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.mod.Mods$ModState"))
          return;
        Mods.ModState.__\u003C\u003Eenabled = new Mods.ModState(nameof (enabled), 0);
        Mods.ModState.__\u003C\u003EcontentErrors = new Mods.ModState(nameof (contentErrors), 1);
        Mods.ModState.__\u003C\u003EmissingDependencies = new Mods.ModState(nameof (missingDependencies), 2);
        Mods.ModState.__\u003C\u003Eunsupported = new Mods.ModState(nameof (unsupported), 3);
        Mods.ModState.__\u003C\u003Edisabled = new Mods.ModState(nameof (disabled), 4);
        Mods.ModState.\u0024VALUES = new Mods.ModState[5]
        {
          Mods.ModState.__\u003C\u003Eenabled,
          Mods.ModState.__\u003C\u003EcontentErrors,
          Mods.ModState.__\u003C\u003EmissingDependencies,
          Mods.ModState.__\u003C\u003Eunsupported,
          Mods.ModState.__\u003C\u003Edisabled
        };
      }

      [Modifiers]
      public static Mods.ModState enabled
      {
        [HideFromJava] get => Mods.ModState.__\u003C\u003Eenabled;
      }

      [Modifiers]
      public static Mods.ModState contentErrors
      {
        [HideFromJava] get => Mods.ModState.__\u003C\u003EcontentErrors;
      }

      [Modifiers]
      public static Mods.ModState missingDependencies
      {
        [HideFromJava] get => Mods.ModState.__\u003C\u003EmissingDependencies;
      }

      [Modifiers]
      public static Mods.ModState unsupported
      {
        [HideFromJava] get => Mods.ModState.__\u003C\u003Eunsupported;
      }

      [Modifiers]
      public static Mods.ModState disabled
      {
        [HideFromJava] get => Mods.ModState.__\u003C\u003Edisabled;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        enabled,
        contentErrors,
        missingDependencies,
        unsupported,
        disabled,
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Mods arg\u00241;

      internal __\u003C\u003EAnon0([In] Mods obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly string arg\u00241;
      private readonly Cons2 arg\u00242;

      internal __\u003C\u003EAnon1([In] string obj0, [In] Cons2 obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => Mods.lambda\u0024listFiles\u00241(this.arg\u00241, this.arg\u00242, (Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon2([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Mods.lambda\u0024getMod\u00242(this.arg\u00241, (Mods.LoadedMod) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      private readonly Class arg\u00241;

      internal __\u003C\u003EAnon3([In] Class obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Mods.lambda\u0024getMod\u00243(this.arg\u00241, (Mods.LoadedMod) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly Mods arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;

      internal __\u003C\u003EAnon4([In] Mods obj0, [In] Mods.LoadedMod obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024importMod\u00244(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public bool get([In] object obj0) => (((Mods.LoadedMod) obj0).enabled() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly Mods arg\u00241;

      internal __\u003C\u003EAnon6([In] Mods obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024loadAsync\u00247((Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly Mods.LoadedMod arg\u00241;
      private readonly IOException arg\u00242;

      internal __\u003C\u003EAnon7([In] Mods.LoadedMod obj0, [In] IOException obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Mods.lambda\u0024packSprites\u00248(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly Mods arg\u00241;

      internal __\u003C\u003EAnon8([In] Mods obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024loadSync\u00249((Content) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Intf
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public int get([In] object obj0) => Mods.lambda\u0024sortMods\u002410((Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Func
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public object get([In] object obj0) => (object) Mods.lambda\u0024sortMods\u002411((Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly Mods arg\u00241;

      internal __\u003C\u003EAnon11([In] Mods obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.updateDependencies((Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Func
    {
      private readonly Mods arg\u00241;

      internal __\u003C\u003EAnon12([In] Mods obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.locateMod((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Boolf
    {
      private readonly ObjectSet arg\u00241;

      internal __\u003C\u003EAnon13([In] ObjectSet obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Mods.lambda\u0024topoSort\u002412(this.arg\u00241, (Mods.LoadedMod) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly Mods arg\u00241;
      private readonly Seq arg\u00242;
      private readonly ObjectSet arg\u00243;

      internal __\u003C\u003EAnon14([In] Mods obj0, [In] Seq obj1, [In] ObjectSet obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024topoSort\u002413(this.arg\u00242, this.arg\u00243, (Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly Mods arg\u00241;
      private readonly ObjectSet arg\u00242;
      private readonly Seq arg\u00243;

      internal __\u003C\u003EAnon15([In] Mods obj0, [In] ObjectSet obj1, [In] Seq obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024orderedMods\u002414(this.arg\u00242, this.arg\u00243, (Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon16([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Mods.lambda\u0024locateMod\u002415(this.arg\u00241, (Mods.LoadedMod) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly Mods.LoadedMod arg\u00241;
      private readonly bool arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon17([In] Mods.LoadedMod obj0, [In] bool obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => Mods.lambda\u0024buildFiles\u002416(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Prov
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public object get() => (object) new Seq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Boolf
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public bool get([In] object obj0) => (((Mods.LoadedMod) obj0).hasContentErrors() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly Mods arg\u00241;
      private readonly bool[] arg\u00242;

      internal __\u003C\u003EAnon20([In] Mods obj0, [In] bool[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024loadScripts\u002420(this.arg\u00242, (Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Boolf
    {
      internal __\u003C\u003EAnon21()
      {
      }

      public bool get([In] object obj0) => (Mods.lambda\u0024loadContent\u002421((Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Boolf
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public bool get([In] object obj0) => (Mods.lambda\u0024getModStrings\u002422((Mods.LoadedMod) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Func
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public object get([In] object obj0) => (object) Mods.lambda\u0024getModStrings\u002423((Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Boolf
    {
      internal __\u003C\u003EAnon24()
      {
      }

      public bool get([In] object obj0) => (Mods.lambda\u0024eachClass\u002424((Mods.LoadedMod) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Cons
    {
      private readonly Mods arg\u00241;
      private readonly Cons arg\u00242;

      internal __\u003C\u003EAnon25([In] Mods obj0, [In] Cons obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024eachClass\u002426(this.arg\u00242, (Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon26([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Mods.lambda\u0024loadMod\u002427(this.arg\u00241, (Mods.LoadedMod) obj0) ? 1 : 0) != 0;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Runnable
    {
      private readonly Cons arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;

      internal __\u003C\u003EAnon28([In] Cons obj0, [In] Mods.LoadedMod obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Mods.lambda\u0024eachClass\u002425(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Boolf
    {
      internal __\u003C\u003EAnon29()
      {
      }

      public bool get([In] object obj0) => (Mods.lambda\u0024loadScripts\u002417((Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Runnable
    {
      private readonly Fi arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;
      private readonly Exception arg\u00243;

      internal __\u003C\u003EAnon30([In] Fi obj0, [In] Mods.LoadedMod obj1, [In] Exception obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => Mods.lambda\u0024loadScripts\u002418(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      private readonly Mods.LoadedMod arg\u00241;

      internal __\u003C\u003EAnon31([In] Mods.LoadedMod obj0) => this.arg\u00241 = obj0;

      public void run() => Mods.lambda\u0024loadScripts\u002419(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Boolf
    {
      internal __\u003C\u003EAnon32()
      {
      }

      public bool get([In] object obj0) => (Mods.lambda\u0024loadAsync\u00245((Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Boolf
    {
      internal __\u003C\u003EAnon33()
      {
      }

      public bool get([In] object obj0) => (Mods.lambda\u0024loadAsync\u00246((Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      private readonly Mods arg\u00241;

      internal __\u003C\u003EAnon34([In] Mods obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.checkWarnings();
    }
  }
}
