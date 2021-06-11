// Decompiled with JetBrains decompiler
// Type: mindustry.maps.Maps
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
using arc.assets.loaders;
using arc.files;
using arc.func;
using arc.graphics;
using arc.util;
using arc.util.async;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.game;
using mindustry.io;
using mindustry.maps.filters;
using mindustry.mod;
using mindustry.world;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps
{
  public class Maps : Object
  {
    private static string[] defaultMapNames;
    [Modifiers]
    internal static string[] pvpMaps;
    [Signature("Larc/struct/Seq<Lmindustry/maps/Map;>;")]
    private Seq maps;
    private Json json;
    private Maps.ShuffleMode shuffleMode;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Maps.MapProvider shuffler;
    private AsyncExecutor executor;
    [Signature("Larc/struct/ObjectSet<Lmindustry/maps/Map;>;")]
    private ObjectSet previewList;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {161, 3, 159, 4, 144, 191, 57, 222, 226, 61, 97, 102, 103, 130, 135, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadPreviews()
    {
      Iterator iterator = this.maps.iterator();
      while (iterator.hasNext())
      {
        Map map = (Map) iterator.next();
        if (map.previewFile().exists())
        {
          Core.assets.load(new AssetDescriptor(new StringBuilder().append(map.previewFile().path()).append(".").append("msav").toString(), (Class) ClassLiteral<Texture>.Value, (AssetLoaderParameters) new MapPreviewLoader.MapPreviewParameter(map))).loaded = (Cons) new Maps.__\u003C\u003EAnon10(map);
          Exception exception;
          try
          {
            this.readCache(map);
            continue;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception = (Exception) m0;
          }
          Throwable.instancehelper_printStackTrace((Exception) exception);
          this.queueNewPreview(map);
        }
        else
          this.queueNewPreview(map);
      }
    }

    [LineNumberTable(new byte[] {34, 232, 16, 139, 139, 171, 108, 235, 105, 149, 103, 159, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Maps()
    {
      Maps maps = this;
      this.maps = new Seq();
      this.json = new Json();
      this.shuffleMode = Maps.ShuffleMode.__\u003C\u003Eall;
      this.executor = new AsyncExecutor(2);
      this.previewList = new ObjectSet();
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new Maps.__\u003C\u003EAnon3(this));
      if (Core.assets == null)
        return;
      ((CustomLoader) Core.assets.getLoader((Class) ClassLiteral<ContentLoader>.Value)).loaded = (Runnable) new Maps.__\u003C\u003EAnon4(this);
    }

    [LineNumberTable(new byte[] {60, 115, 127, 27, 10, 248, 70, 2, 98, 205, 159, 0, 115, 255, 4, 69, 226, 61, 98, 117, 231, 57, 233, 76, 159, 17, 107, 104, 223, 24, 226, 61, 98, 117, 135, 165, 250, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      IOException ioException1;
      try
      {
        string[] defaultMapNames = Maps.defaultMapNames;
        int length = defaultMapNames.Length;
        for (int index = 0; index < length; ++index)
        {
          string str = defaultMapNames[index];
          this.loadMap(Core.files.@internal(new StringBuilder().append("maps/").append(str).append(".").append("msav").toString()), false);
        }
        goto label_5;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
label_5:
      Fi[] fiArray = Vars.customMapDirectory.list();
      int length1 = fiArray.Length;
      for (int index = 0; index < length1; ++index)
      {
        Fi fi = fiArray[index];
        Exception exception1;
        try
        {
          if (String.instancehelper_equalsIgnoreCase(fi.extension(), "msav"))
          {
            this.loadMap(fi, true);
            continue;
          }
          continue;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception1 = (Exception) m0;
        }
        Exception exception2 = exception1;
        Log.err("Failed to load custom map file '@'!", (object) fi);
        Log.err((Exception) exception2);
      }
      Iterator iterator = Vars.platform.getWorkshopContent((Class) ClassLiteral<Map>.Value).iterator();
      while (iterator.hasNext())
      {
        Fi fi = (Fi) iterator.next();
        Exception exception1;
        try
        {
          Map map = this.loadMap(fi, false);
          map.workshop = true;
          map.__\u003C\u003Etags.put((object) "steamid", (object) fi.parent().name());
          continue;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception1 = (Exception) m0;
        }
        Exception exception2 = exception1;
        Log.err("Failed to load workshop map file '@'!", (object) fi);
        Log.err((Exception) exception2);
      }
      Vars.mods.listFiles("maps", (Cons2) new Maps.__\u003C\u003EAnon5(this));
    }

    [Signature("()Larc/struct/Seq<Lmindustry/maps/Map;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq all() => this.maps;

    [Signature("(Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;)Lmindustry/maps/Map;")]
    [LineNumberTable(new byte[] {122, 103, 113, 211, 156, 131, 104, 107, 135, 109, 137, 199, 126, 136, 138, 108, 136, 113, 110, 144, 110, 180, 115, 239, 56, 43, 235, 78, 127, 28, 191, 26, 113, 122, 136, 142, 109, 140, 157, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Map saveMap(ObjectMap baseTags)
    {
      Map map1;
      IOException ioException1;
      try
      {
        StringMap tags = new StringMap(baseTags);
        string str = (string) tags.get((object) "name");
        if (str == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Can't save a map with no name. How did this happen?");
        }
        Map map2 = (Map) this.maps.find((Boolf) new Maps.__\u003C\u003EAnon6(str));
        Fi file;
        if (map2 != null)
        {
          if (map2.texture != null)
          {
            map2.texture.dispose();
            map2.texture = (Texture) null;
          }
          this.maps.remove((object) map2);
          file = map2.__\u003C\u003Efile;
        }
        else
          file = this.findFile();
        Map map3 = new Map(file, Vars.world.width(), Vars.world.height(), tags, true);
        MapIO.writeMap(file, map3);
        if (!Vars.headless)
        {
          map3.teams.clear();
          map3.spawns = 0;
          for (int x = 0; x < map3.width; ++x)
          {
            for (int y = 0; y < map3.height; ++y)
            {
              Tile tile = Vars.world.rawTile(x, y);
              if (tile.block() is CoreBlock)
                map3.teams.add(tile.getTeamID());
              if (object.ReferenceEquals((object) tile.overlay(), (object) Blocks.spawn))
                ++map3.spawns;
            }
          }
          if (Core.assets.isLoaded(new StringBuilder().append(map3.previewFile().path()).append(".").append("msav").toString()))
            Core.assets.unload(new StringBuilder().append(map3.previewFile().path()).append(".").append("msav").toString());
          Pixmap preview = MapIO.generatePreview(Vars.world.tiles);
          this.executor.submit((Runnable) new Maps.__\u003C\u003EAnon7(map3, preview));
          this.writeCache(map3);
          map3.texture = new Texture(preview);
        }
        this.maps.add((object) map3);
        this.maps.sort();
        map1 = map3;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_24;
      }
      return map1;
label_24:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {160, 148, 248, 75, 229, 54, 97, 134, 114, 113, 127, 11, 145, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tryCatchMapError(UnsafeRunnable run)
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
      Log.err(exception2);
      if (String.instancehelper_equals("Outdated legacy map format", (object) Throwable.instancehelper_getMessage(exception2)))
      {
        Vars.ui.showErrorMessage("@editor.errornot");
      }
      else
      {
        if (Throwable.instancehelper_getMessage(exception2) != null)
        {
          string message = Throwable.instancehelper_getMessage(exception2);
          object obj = (object) "Incorrect header!";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence2 = charSequence1;
          if (String.instancehelper_contains(message, charSequence2))
          {
            Vars.ui.showErrorMessage("@editor.errorheader");
            return;
          }
        }
        Vars.ui.showException("@editor.errorload", exception2);
      }
    }

    [Signature("(Larc/struct/Seq<Lmindustry/maps/filters/GenerateFilter;>;)V")]
    [LineNumberTable(new byte[] {160, 227, 122, 123, 102, 113, 113, 103, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addDefaultOres(Seq filters)
    {
      Iterator iterator = Vars.content.blocks().select((Boolf) new Maps.__\u003C\u003EAnon9()).iterator();
      while (iterator.hasNext())
      {
        Block block = (Block) iterator.next();
        filters.add((object) new OreFilter()
        {
          threshold = block.asFloor().oreThreshold,
          scl = block.asFloor().oreScale,
          ore = block
        });
      }
    }

    [Signature("(Ljava/lang/String;)Larc/struct/Seq<Lmindustry/maps/filters/GenerateFilter;>;")]
    [LineNumberTable(new byte[] {160, 176, 139, 255, 53, 99, 135, 162, 127, 7, 97, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq readFilters(string str)
    {
      if (str != null)
      {
        if (!String.instancehelper_isEmpty(str))
        {
          Seq seq;
          Exception exception;
          try
          {
            seq = (Seq) JsonIO.read((Class) ClassLiteral<Seq>.Value, str);
          }
          catch (Exception ex)
          {
            exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_6;
          }
          return seq;
label_6:
          Throwable.instancehelper_printStackTrace(exception);
          return this.readFilters("");
        }
      }
      Seq filters = Seq.with((object[]) new GenerateFilter[8]
      {
        (GenerateFilter) new Maps.\u0031(this),
        (GenerateFilter) new Maps.\u0032(this),
        (GenerateFilter) new Maps.\u0033(this),
        (GenerateFilter) new Maps.\u0034(this),
        (GenerateFilter) new Maps.\u0035(this),
        (GenerateFilter) new Maps.\u0036(this),
        (GenerateFilter) new Maps.\u0037(this),
        (GenerateFilter) new Maps.\u0038(this)
      });
      this.addDefaultOres(filters);
      return filters;
    }

    [Signature("(Ljava/lang/String;)Larc/struct/Seq<Lmindustry/game/SpawnGroup;>;")]
    [LineNumberTable(368)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq readWaves(string str)
    {
      if (str == null)
        return (Seq) null;
      return String.instancehelper_equals(str, (object) "[]") ? new Seq() : Seq.with((object[]) this.json.fromJson((Class) ClassLiteral<SpawnGroup[]>.Value, str));
    }

    [Signature("(Larc/struct/Seq<Lmindustry/game/SpawnGroup;>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {160, 238, 137, 102, 145, 107, 107, 117, 119, 235, 61, 230, 69, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string writeWaves(Seq groups)
    {
      if (groups == null)
        return "[]";
      StringWriter stringWriter = new StringWriter();
      this.json.setWriter((BaseJsonWriter) new JsonWriter((Writer) stringWriter));
      this.json.writeArrayStart();
      for (int index = 0; index < groups.size; ++index)
      {
        this.json.writeObjectStart((Class) ClassLiteral<SpawnGroup>.Value, (Class) ClassLiteral<SpawnGroup>.Value);
        ((SpawnGroup) groups.get(index)).write(this.json);
        this.json.writeObjectEnd();
      }
      this.json.writeArrayEnd();
      return stringWriter.toString();
    }

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Map byName(string name) => (Map) this.maps.find((Boolf) new Maps.__\u003C\u003EAnon2(name));

    [LineNumberTable(new byte[] {161, 31, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void queueNewPreview(Map map) => Core.app.post((Runnable) new Maps.__\u003C\u003EAnon12(this, map));

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 28, 130, 136, 104, 191, 6, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Map loadMap([In] Fi obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      Map map = MapIO.createMap(obj0, num != 0);
      if (map.name() == null)
      {
        string str = new StringBuilder().append("Map name cannot be empty! File: ").append((object) obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str);
      }
      this.maps.add((object) map);
      this.maps.sort();
      return map;
    }

    [LineNumberTable(new byte[] {161, 80, 108, 127, 32, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Fi findFile()
    {
      int size = this.maps.size;
      while (Vars.customMapDirectory.child(new StringBuilder().append("map_").append(size).append(".").append("msav").toString()).exists())
        ++size;
      return Vars.customMapDirectory.child(new StringBuilder().append("map_").append(size).append(".").append("msav").toString());
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 55, 119, 103, 108, 113, 108, 104, 158, 232, 56, 255, 15, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeCache([In] Map obj0)
    {
      DataOutputStream dataOutputStream = new DataOutputStream(obj0.cacheFile().write(false, 4096));
      Exception exception1;
      try
      {
        dataOutputStream.write(0);
        dataOutputStream.writeInt(obj0.spawns);
        dataOutputStream.write(obj0.teams.size);
        IntSet.IntSetIterator intSetIterator = obj0.teams.iterator();
        while (intSetIterator.hasNext)
          dataOutputStream.write(intSetIterator.next());
        goto label_6;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      Exception exception3;
      try
      {
        ((FilterOutputStream) dataOutputStream).close();
        goto label_10;
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception4 = exception3;
      Throwable.instancehelper_addSuppressed(exception2, exception4);
label_10:
      throw Throwable.__\u003Cunmap\u003E(exception2);
label_6:
      ((FilterOutputStream) dataOutputStream).close();
    }

    [Signature("(Lmindustry/maps/Map;Larc/func/Cons<Ljava/lang/Exception;>;)V")]
    [LineNumberTable(new byte[] {161, 38, 103, 108, 255, 17, 75, 226, 61, 97, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void createNewPreview([In] Map obj0, [In] Cons obj1)
    {
      Exception exception1;
      try
      {
        Pixmap preview = MapIO.generatePreview(obj0);
        obj0.texture = new Texture(preview);
        this.executor.submit((Runnable) new Maps.__\u003C\u003EAnon13(this, obj0, preview));
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      obj1.get((object) exception2);
      Log.err("Failed to generate preview!", (Exception) exception2);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 67, 118, 103, 108, 104, 102, 50, 182, 232, 57, 255, 18, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readCache([In] Map obj0)
    {
      DataInputStream dataInputStream = new DataInputStream((InputStream) obj0.cacheFile().read(4096));
      Exception exception1;
      try
      {
        ((FilterInputStream) dataInputStream).read();
        obj0.spawns = dataInputStream.readInt();
        int num = (int) (sbyte) dataInputStream.readByte();
        for (int index = 0; index < num; ++index)
          obj0.teams.add(((FilterInputStream) dataInputStream).read());
        goto label_6;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      Exception exception3;
      try
      {
        ((FilterInputStream) dataInputStream).close();
        goto label_10;
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception4 = exception3;
      Throwable.instancehelper_addSuppressed(exception2, exception4);
label_10:
      throw Throwable.__\u003Cunmap\u003E(exception2);
label_6:
      ((FilterInputStream) dataInputStream).close();
    }

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024customMaps\u00240([In] Map obj0) => obj0.__\u003C\u003Ecustom;

    [Modifiers]
    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024defaultMaps\u00241([In] Map obj0) => !obj0.__\u003C\u003Ecustom;

    [Modifiers]
    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024byName\u00242([In] string obj0, [In] Map obj1) => String.instancehelper_equals(obj1.name(), (object) obj0);

    [Modifiers]
    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] EventType.ClientLoadEvent obj0) => this.maps.sort();

    [LineNumberTable(new byte[] {161, 22, 245, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void createAllPreviews() => Core.app.post((Runnable) new Maps.__\u003C\u003EAnon11(this));

    [Modifiers]
    [LineNumberTable(new byte[] {95, 105, 222, 226, 61, 97, 116, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024load\u00244([In] Mods.LoadedMod obj0, [In] Fi obj1)
    {
      Exception exception1;
      try
      {
        this.loadMap(obj1, false).mod = obj0;
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Log.err("Failed to load mod map file '@'!", (object) obj1);
      Log.err((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024saveMap\u00245([In] string obj0, [In] Map obj1) => String.instancehelper_equals(obj1.name(), (object) obj0);

    [Modifiers]
    [LineNumberTable(220)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024saveMap\u00246([In] Map obj0, [In] Pixmap obj1) => obj0.previewFile().writePNG(obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 130, 141, 189, 2, 161, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024importMap\u00247([In] Map obj0, [In] Exception[] obj1, [In] Exception obj2)
    {
      this.maps.remove((object) obj0);
      try
      {
        obj0.__\u003C\u003Efile.delete();
        goto label_4;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
label_4:
      obj1[0] = obj2;
    }

    [Modifiers]
    [LineNumberTable(341)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024addDefaultOres\u00248([In] Block obj0) => obj0.isOverlay() && obj0.asFloor().oreDefault;

    [Modifiers]
    [LineNumberTable(377)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadPreviews\u00249([In] Map obj0, [In] object obj1) => obj0.texture = (Texture) obj1;

    [Modifiers]
    [LineNumberTable(new byte[] {161, 23, 127, 1, 114, 98, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024createAllPreviews\u002412()
    {
      ObjectSet.ObjectSetIterator objectSetIterator = this.previewList.iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        Map map = (Map) ((Iterator) objectSetIterator).next();
        this.createNewPreview(map, (Cons) new Maps.__\u003C\u003EAnon14(map));
      }
      this.previewList.clear();
    }

    [Modifiers]
    [LineNumberTable(401)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024queueNewPreview\u002413([In] Map obj0) => this.previewList.add((object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 42, 108, 190, 2, 97, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024createNewPreview\u002414([In] Map obj0, [In] Pixmap obj1)
    {
      Exception exception;
      try
      {
        obj0.previewFile().writePNG(obj1);
        this.writeCache(obj0);
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception = (Exception) m0;
      }
      Throwable.instancehelper_printStackTrace((Exception) exception);
    }

    [Modifiers]
    [LineNumberTable(394)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024createAllPreviews\u002411([In] Map obj0, [In] Exception obj1) => Core.app.post((Runnable) new Maps.__\u003C\u003EAnon15(obj0));

    [Modifiers]
    [LineNumberTable(394)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024createAllPreviews\u002410([In] Map obj0) => obj0.texture = (Texture) Core.assets.get("sprites/error.png");

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Maps.ShuffleMode getShuffleMode() => this.shuffleMode;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setShuffleMode(Maps.ShuffleMode mode) => this.shuffleMode = mode;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMapProvider(Maps.MapProvider provider) => this.shuffler = provider;

    [LineNumberTable(new byte[] {11, 118})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Map getNextMap(Gamemode mode, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Map previous) => this.shuffler != null ? this.shuffler.next(mode, previous) : this.shuffleMode.next(mode, previous);

    [Signature("()Larc/struct/Seq<Lmindustry/maps/Map;>;")]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq customMaps() => this.maps.select((Boolf) new Maps.__\u003C\u003EAnon0());

    [Signature("()Larc/struct/Seq<Lmindustry/maps/Map;>;")]
    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq defaultMaps() => this.maps.select((Boolf) new Maps.__\u003C\u003EAnon1());

    [LineNumberTable(new byte[] {47, 191, 26, 125, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Map loadInternalMap(string name)
    {
      Fi file = Vars.tree.get(new StringBuilder().append("maps/").append(name).append(".").append("msav").toString());
      Map map;
      IOException ioException1;
      try
      {
        map = MapIO.createMap(file, false);
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_4;
      }
      return map;
label_4:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {105, 127, 1, 104, 107, 135, 98, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reload()
    {
      Iterator iterator = this.maps.iterator();
      while (iterator.hasNext())
      {
        Map map = (Map) iterator.next();
        if (map.texture != null)
        {
          map.texture.dispose();
          map.texture = (Texture) null;
        }
      }
      this.maps.clear();
      this.load();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 123, 103, 135, 105, 139, 244, 74, 101, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void importMap(Fi file)
    {
      Fi file1 = this.findFile();
      file.copyTo(file1);
      Map map = this.loadMap(file1, true);
      Exception[] exceptionArray = new Exception[1]
      {
        (Exception) null
      };
      this.createNewPreview(map, (Cons) new Maps.__\u003C\u003EAnon8(this, map, exceptionArray));
      if (exceptionArray[0] != null)
      {
        Exception exception = exceptionArray[0];
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException((Exception) exception);
      }
    }

    [LineNumberTable(new byte[] {160, 164, 104, 107, 167, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeMap(Map map)
    {
      if (map.texture != null)
      {
        map.texture.dispose();
        map.texture = (Texture) null;
      }
      this.maps.remove((object) map);
      map.__\u003C\u003Efile.delete();
    }

    [LineNumberTable(new byte[] {159, 134, 77, 159, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Maps()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.maps.Maps"))
        return;
      Maps.defaultMapNames = new string[16]
      {
        "maze",
        "fortress",
        "labyrinth",
        "islands",
        "tendrils",
        "caldera",
        "wasteland",
        "shattered",
        "fork",
        "triad",
        "mudFlats",
        "moltenLake",
        "archipelago",
        "debrisField",
        "veins",
        "glacier"
      };
      Maps.pvpMaps = new string[2]{ "veins", "glacier" };
    }

    [EnclosingMethod(null, "readFilters", "(Ljava.lang.String;)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0031 : ScatterFilter
    {
      [Modifiers]
      internal Maps this\u00240;

      [LineNumberTable(new byte[] {160, 179, 111, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Maps obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Maps.\u0031 obj = this;
        this.flooronto = Blocks.snow;
        this.block = Blocks.snowBoulder;
      }
    }

    [EnclosingMethod(null, "readFilters", "(Ljava.lang.String;)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0032 : ScatterFilter
    {
      [Modifiers]
      internal Maps this\u00240;

      [LineNumberTable(new byte[] {160, 183, 111, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Maps obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Maps.\u0032 obj = this;
        this.flooronto = Blocks.ice;
        this.block = Blocks.snowBoulder;
      }
    }

    [EnclosingMethod(null, "readFilters", "(Ljava.lang.String;)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0033 : ScatterFilter
    {
      [Modifiers]
      internal Maps this\u00240;

      [LineNumberTable(new byte[] {160, 187, 111, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Maps obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Maps.\u0033 obj = this;
        this.flooronto = Blocks.sand;
        this.block = Blocks.sandBoulder;
      }
    }

    [EnclosingMethod(null, "readFilters", "(Ljava.lang.String;)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0034 : ScatterFilter
    {
      [Modifiers]
      internal Maps this\u00240;

      [LineNumberTable(new byte[] {160, 191, 111, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] Maps obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Maps.\u0034 obj = this;
        this.flooronto = Blocks.darksand;
        this.block = Blocks.basaltBoulder;
      }
    }

    [EnclosingMethod(null, "readFilters", "(Ljava.lang.String;)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0035 : ScatterFilter
    {
      [Modifiers]
      internal Maps this\u00240;

      [LineNumberTable(new byte[] {160, 195, 111, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] Maps obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Maps.\u0035 obj = this;
        this.flooronto = Blocks.basalt;
        this.block = Blocks.basaltBoulder;
      }
    }

    [EnclosingMethod(null, "readFilters", "(Ljava.lang.String;)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0036 : ScatterFilter
    {
      [Modifiers]
      internal Maps this\u00240;

      [LineNumberTable(new byte[] {160, 199, 111, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] Maps obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Maps.\u0036 obj = this;
        this.flooronto = Blocks.dacite;
        this.block = Blocks.daciteBoulder;
      }
    }

    [EnclosingMethod(null, "readFilters", "(Ljava.lang.String;)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0037 : ScatterFilter
    {
      [Modifiers]
      internal Maps this\u00240;

      [LineNumberTable(new byte[] {160, 203, 111, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037([In] Maps obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Maps.\u0037 obj = this;
        this.flooronto = Blocks.stone;
        this.block = Blocks.boulder;
      }
    }

    [EnclosingMethod(null, "readFilters", "(Ljava.lang.String;)Larc.struct.Seq;")]
    [SpecialName]
    internal class \u0038 : ScatterFilter
    {
      [Modifiers]
      internal Maps this\u00240;

      [LineNumberTable(new byte[] {160, 207, 111, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038([In] Maps obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Maps.\u0038 obj = this;
        this.flooronto = Blocks.shale;
        this.block = Blocks.shaleBoulder;
      }
    }

    public interface MapProvider
    {
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      Map next(Gamemode g, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Map m);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/maps/Maps$ShuffleMode;>;Lmindustry/maps/Maps$MapProvider;")]
    [Modifiers]
    [Implements(new string[] {"mindustry.maps.Maps$MapProvider"})]
    [Serializable]
    public sealed class ShuffleMode : Enum, Maps.MapProvider
    {
      [Modifiers]
      internal static Maps.ShuffleMode __\u003C\u003Enone;
      [Modifiers]
      internal static Maps.ShuffleMode __\u003C\u003Eall;
      [Modifiers]
      internal static Maps.ShuffleMode __\u003C\u003Ecustom;
      [Modifiers]
      internal static Maps.ShuffleMode __\u003C\u003Ebuiltin;
      [Modifiers]
      private Maps.MapProvider provider;
      [Modifiers]
      private static Maps.ShuffleMode[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(502)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Map next(Gamemode mode, [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Map previous) => this.provider.next(mode, previous);

      [LineNumberTable(new byte[] {161, 124, 127, 5, 127, 16, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool valid([In] Gamemode obj0, [In] Map obj1)
      {
        int num = obj1.__\u003C\u003Ecustom || !Structs.contains((object[]) Maps.pvpMaps, (object) obj1.__\u003C\u003Efile.nameWithoutExtension()) ? 0 : 1;
        return object.ReferenceEquals((object) obj0, (object) Gamemode.__\u003C\u003Esurvival) || object.ReferenceEquals((object) obj0, (object) Gamemode.__\u003C\u003Eattack) || object.ReferenceEquals((object) obj0, (object) Gamemode.__\u003C\u003Esandbox) ? num == 0 : !object.ReferenceEquals((object) obj0, (object) Gamemode.__\u003C\u003Epvp) || (obj1.__\u003C\u003Ecustom || num != 0);
      }

      [Signature("(Lmindustry/game/Gamemode;Lmindustry/maps/Map;[Larc/struct/Seq<Lmindustry/maps/Map;>;)Lmindustry/maps/Map;")]
      [LineNumberTable(new byte[] {161, 117, 108, 134})]
      [SafeVarargs(new object[] {64, "Ljava/lang/SafeVarargs;"})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static Map next(Gamemode _param0, Map _param1, params Seq[] _param2)
      {
        Seq seq = Seq.withArrays((object[]) _param2);
        seq.shuffle();
        return (Map) seq.find((Boolf) new Maps.ShuffleMode.__\u003C\u003EAnon0(_param1, seq, _param0));
      }

      [Signature("(Lmindustry/maps/Maps$MapProvider;)V")]
      [LineNumberTable(new byte[] {161, 111, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ShuffleMode([In] string obj0, [In] int obj1, [In] Maps.MapProvider obj2)
        : base(obj0, obj1)
      {
        Maps.ShuffleMode shuffleMode = this;
        this.provider = obj2;
        GC.KeepAlive((object) this);
      }

      [Modifiers]
      [LineNumberTable(490)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024next\u00244([In] Map obj0, [In] Seq obj1, [In] Gamemode obj2, [In] Map obj3) => (!object.ReferenceEquals((object) obj3, (object) obj0) || obj1.size == 1) && Maps.ShuffleMode.valid(obj2, obj3);

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static Map lambda\u0024static\u00240([In] Gamemode obj0, [In] Map obj1) => (Map) null;

      [Modifiers]
      [LineNumberTable(475)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static Map lambda\u0024static\u00241([In] Gamemode obj0, [In] Map obj1) => Maps.ShuffleMode.next(obj0, obj1, Vars.maps.defaultMaps(), Vars.maps.customMaps());

      [Modifiers]
      [LineNumberTable(476)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static Map lambda\u0024static\u00242([In] Gamemode obj0, [In] Map obj1) => Maps.ShuffleMode.next(obj0, obj1, !Vars.maps.customMaps().isEmpty() ? Vars.maps.customMaps() : Vars.maps.defaultMaps());

      [Modifiers]
      [LineNumberTable(477)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static Map lambda\u0024static\u00243([In] Gamemode obj0, [In] Map obj1) => Maps.ShuffleMode.next(obj0, obj1, Vars.maps.defaultMaps());

      [LineNumberTable(473)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Maps.ShuffleMode[] values() => (Maps.ShuffleMode[]) Maps.ShuffleMode.\u0024VALUES.Clone();

      [LineNumberTable(473)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Maps.ShuffleMode valueOf(string name) => (Maps.ShuffleMode) Enum.valueOf((Class) ClassLiteral<Maps.ShuffleMode>.Value, name);

      [LineNumberTable(new byte[] {159, 24, 141, 122, 122, 122, 250, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ShuffleMode()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.maps.Maps$ShuffleMode"))
          return;
        Maps.ShuffleMode.__\u003C\u003Enone = new Maps.ShuffleMode(nameof (none), 0, (Maps.MapProvider) new Maps.ShuffleMode.__\u003C\u003EAnon1());
        Maps.ShuffleMode.__\u003C\u003Eall = new Maps.ShuffleMode(nameof (all), 1, (Maps.MapProvider) new Maps.ShuffleMode.__\u003C\u003EAnon2());
        Maps.ShuffleMode.__\u003C\u003Ecustom = new Maps.ShuffleMode(nameof (custom), 2, (Maps.MapProvider) new Maps.ShuffleMode.__\u003C\u003EAnon3());
        Maps.ShuffleMode.__\u003C\u003Ebuiltin = new Maps.ShuffleMode(nameof (builtin), 3, (Maps.MapProvider) new Maps.ShuffleMode.__\u003C\u003EAnon4());
        Maps.ShuffleMode.\u0024VALUES = new Maps.ShuffleMode[4]
        {
          Maps.ShuffleMode.__\u003C\u003Enone,
          Maps.ShuffleMode.__\u003C\u003Eall,
          Maps.ShuffleMode.__\u003C\u003Ecustom,
          Maps.ShuffleMode.__\u003C\u003Ebuiltin
        };
      }

      [Modifiers]
      public static Maps.ShuffleMode none
      {
        [HideFromJava] get => Maps.ShuffleMode.__\u003C\u003Enone;
      }

      [Modifiers]
      public static Maps.ShuffleMode all
      {
        [HideFromJava] get => Maps.ShuffleMode.__\u003C\u003Eall;
      }

      [Modifiers]
      public static Maps.ShuffleMode custom
      {
        [HideFromJava] get => Maps.ShuffleMode.__\u003C\u003Ecustom;
      }

      [Modifiers]
      public static Maps.ShuffleMode builtin
      {
        [HideFromJava] get => Maps.ShuffleMode.__\u003C\u003Ebuiltin;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        none,
        all,
        custom,
        builtin,
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Boolf
      {
        private readonly Map arg\u00241;
        private readonly Seq arg\u00242;
        private readonly Gamemode arg\u00243;

        internal __\u003C\u003EAnon0([In] Map obj0, [In] Seq obj1, [In] Gamemode obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public bool get([In] object obj0) => (Maps.ShuffleMode.lambda\u0024next\u00244(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Map) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Maps.MapProvider
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public Map next([In] Gamemode obj0, [In] Map obj1) => Maps.ShuffleMode.lambda\u0024static\u00240(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Maps.MapProvider
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public Map next([In] Gamemode obj0, [In] Map obj1) => Maps.ShuffleMode.lambda\u0024static\u00241(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon3 : Maps.MapProvider
      {
        internal __\u003C\u003EAnon3()
        {
        }

        public Map next([In] Gamemode obj0, [In] Map obj1) => Maps.ShuffleMode.lambda\u0024static\u00242(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon4 : Maps.MapProvider
      {
        internal __\u003C\u003EAnon4()
        {
        }

        public Map next([In] Gamemode obj0, [In] Map obj1) => Maps.ShuffleMode.lambda\u0024static\u00243(obj0, obj1);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (Maps.lambda\u0024customMaps\u00240((Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (Maps.lambda\u0024defaultMaps\u00241((Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon2([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Maps.lambda\u0024byName\u00242(this.arg\u00241, (Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Maps arg\u00241;

      internal __\u003C\u003EAnon3([In] Maps obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly Maps arg\u00241;

      internal __\u003C\u003EAnon4([In] Maps obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.createAllPreviews();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons2
    {
      private readonly Maps arg\u00241;

      internal __\u003C\u003EAnon5([In] Maps obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024load\u00244((Mods.LoadedMod) obj0, (Fi) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon6([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Maps.lambda\u0024saveMap\u00245(this.arg\u00241, (Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly Map arg\u00241;
      private readonly Pixmap arg\u00242;

      internal __\u003C\u003EAnon7([In] Map obj0, [In] Pixmap obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Maps.lambda\u0024saveMap\u00246(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly Maps arg\u00241;
      private readonly Map arg\u00242;
      private readonly Exception[] arg\u00243;

      internal __\u003C\u003EAnon8([In] Maps obj0, [In] Map obj1, [In] Exception[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024importMap\u00247(this.arg\u00242, this.arg\u00243, (Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Boolf
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public bool get([In] object obj0) => (Maps.lambda\u0024addDefaultOres\u00248((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly Map arg\u00241;

      internal __\u003C\u003EAnon10([In] Map obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Maps.lambda\u0024loadPreviews\u00249(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly Maps arg\u00241;

      internal __\u003C\u003EAnon11([In] Maps obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024createAllPreviews\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly Maps arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon12([In] Maps obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024queueNewPreview\u002413(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly Maps arg\u00241;
      private readonly Map arg\u00242;
      private readonly Pixmap arg\u00243;

      internal __\u003C\u003EAnon13([In] Maps obj0, [In] Map obj1, [In] Pixmap obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024createNewPreview\u002414(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly Map arg\u00241;

      internal __\u003C\u003EAnon14([In] Map obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Maps.lambda\u0024createAllPreviews\u002411(this.arg\u00241, (Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly Map arg\u00241;

      internal __\u003C\u003EAnon15([In] Map obj0) => this.arg\u00241 = obj0;

      public void run() => Maps.lambda\u0024createAllPreviews\u002410(this.arg\u00241);
    }
  }
}
