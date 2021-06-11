// Decompiled with JetBrains decompiler
// Type: mindustry.maps.Map
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.graphics;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.game;
using mindustry.io;
using mindustry.maps.filters;
using mindustry.mod;
using mindustry.type;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps
{
  [Signature("Ljava/lang/Object;Ljava/lang/Comparable<Lmindustry/maps/Map;>;Lmindustry/type/Publishable;")]
  [Implements(new string[] {"java.lang.Comparable", "mindustry.type.Publishable"})]
  public class Map : Object, Comparable, Publishable
  {
    internal bool __\u003C\u003Ecustom;
    internal StringMap __\u003C\u003Etags;
    internal Fi __\u003C\u003Efile;
    internal int __\u003C\u003Eversion;
    public bool workshop;
    public int width;
    public int height;
    public Texture texture;
    public int build;
    public IntSet teams;
    public int spawns;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Mods.LoadedMod mod;

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string name() => this.tag(nameof (name));

    [LineNumberTable(new byte[] {11, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Map(StringMap tags)
      : this(Vars.customMapDirectory.child((string) tags.get((object) "name", (object) "unknown")), 0, 0, tags, true)
    {
    }

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHightScore() => Core.settings.getInt(new StringBuilder().append("hiscore").append(this.__\u003C\u003Efile.nameWithoutExtension()).append((string) this.__\u003C\u003Etags.get((object) "steamid", (object) "")).toString(), 0);

    [LineNumberTable(new byte[] {31, 127, 52})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setHighScore(int score) => Core.settings.put(new StringBuilder().append("hiscore").append(this.__\u003C\u003Efile.nameWithoutExtension()).append((string) this.__\u003C\u003Etags.get((object) "steamid", (object) "")).toString(), (object) Integer.valueOf(score));

    [Signature("()Larc/struct/Seq<Lmindustry/maps/filters/GenerateFilter;>;")]
    [LineNumberTable(new byte[] {65, 127, 43, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq filters() => this.__\u003C\u003Etags.getInt("build", -1) < 83 && this.__\u003C\u003Etags.getInt("build", -1) != -1 && String.instancehelper_isEmpty((string) this.__\u003C\u003Etags.get((object) "genfilters", (object) "")) ? Seq.with((object[]) new GenerateFilter[0]) : Vars.maps.readFilters((string) this.__\u003C\u003Etags.get((object) "genfilters", (object) ""));

    [LineNumberTable(new byte[] {159, 128, 99, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Map(Fi file, int width, int height, StringMap tags, bool custom)
    {
      int num = custom ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(file, width, height, tags, num != 0, -1);
    }

    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture safeTexture() => this.texture == null ? (Texture) Core.assets.get("sprites/error.png") : this.texture;

    [LineNumberTable(new byte[] {159, 132, 131, 232, 58, 139, 231, 69, 103, 104, 103, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Map(
      Fi file,
      int width,
      int height,
      StringMap tags,
      bool custom,
      int version,
      int build)
    {
      int num = custom ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Map map = this;
      this.teams = new IntSet();
      this.spawns = 0;
      this.__\u003C\u003Ecustom = num != 0;
      this.__\u003C\u003Etags = tags;
      this.__\u003C\u003Efile = file;
      this.width = width;
      this.height = height;
      this.__\u003C\u003Eversion = version;
      this.build = build;
    }

    [LineNumberTable(new byte[] {159, 129, 99, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Map(Fi file, int width, int height, StringMap tags, bool custom, int version)
    {
      int num = custom ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(file, width, height, tags, num != 0, version, -1);
    }

    [LineNumberTable(new byte[] {53, 127, 61, 125, 127, 2, 130, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rules rules(Rules @base)
    {
      Rules rules1;
      Exception exception;
      try
      {
        // ISSUE: variable of the null type
        __Null local = ClassLiteral<Rules>.Value;
        Rules rules2 = @base;
        string str = (string) this.__\u003C\u003Etags.get((object) nameof (rules), (object) "{}");
        object obj1 = (object) "";
        object obj2 = (object) "teams:{2:{infiniteAmmo:true}},";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        string @string = String.instancehelper_replace(str, charSequence2, charSequence3);
        Rules rules3 = (Rules) JsonIO.read((Class) local, (object) rules2, @string);
        if (rules3.spawns.isEmpty())
          rules3.spawns = Vars.waves.get();
        rules1 = rules3;
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
          exception = (Exception) m0;
          goto label_7;
        }
      }
      return rules1;
label_7:
      Throwable.instancehelper_printStackTrace((Exception) exception);
      return new Rules();
    }

    [LineNumberTable(134)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string tag(string name) => this.__\u003C\u003Etags.containsKey((object) name) && !String.instancehelper_isEmpty(String.instancehelper_trim((string) this.__\u003C\u003Etags.get((object) name))) ? (string) this.__\u003C\u003Etags.get((object) name) : Core.bundle.get("unknown", "unknown");

    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string description() => this.tag(nameof (description));

    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi previewFile() => Vars.mapPreviewDirectory.child(new StringBuilder().append(!this.workshop ? this.__\u003C\u003Efile.nameWithoutExtension() : this.__\u003C\u003Efile.parent().name()).append("_v2.png").toString());

    [LineNumberTable(new byte[] {160, 101, 115, 101, 115, 101, 124, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(Map map)
    {
      int num1 = -Boolean.compare(this.workshop, map.workshop);
      if (num1 != 0)
        return num1;
      int num2 = -Boolean.compare(this.__\u003C\u003Ecustom, map.__\u003C\u003Ecustom);
      if (num2 != 0)
        return num2;
      int num3 = Boolean.compare(Gamemode.__\u003C\u003Epvp.valid(this), Gamemode.__\u003C\u003Epvp.valid(map));
      return num3 != 0 ? num3 : String.instancehelper_compareTo(this.name(), map.name());
    }

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi cacheFile() => Vars.mapPreviewDirectory.child(!this.workshop ? new StringBuilder().append(this.__\u003C\u003Efile.nameWithoutExtension()).append("-cache_v2.dat").toString() : new StringBuilder().append(this.__\u003C\u003Efile.parent().name()).append("-workshop-cache.dat").toString());

    [LineNumberTable(new byte[] {37, 102, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rules applyRules(Gamemode mode)
    {
      Rules rules = new Rules();
      mode.apply(rules);
      return this.rules(rules);
    }

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rules rules() => this.rules(new Rules());

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string author() => this.tag(nameof (author));

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasTag(string name) => this.__\u003C\u003Etags.containsKey((object) name);

    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSteamID() => (string) this.__\u003C\u003Etags.get((object) "steamid");

    [LineNumberTable(new byte[] {98, 146, 159, 1, 191, 8, 2, 97, 134, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addSteamID(string id)
    {
      this.__\u003C\u003Etags.put((object) "steamid", (object) id);
      Vars.ui.editor.__\u003C\u003Eeditor.tags.put((object) "steamid", (object) id);
      Exception exception;
      try
      {
        Vars.ui.editor.save();
        goto label_6;
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
label_6:
      Events.fire((object) new EventType.MapPublishEvent());
    }

    [LineNumberTable(new byte[] {111, 145, 159, 0, 191, 8, 2, 97, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeSteamID()
    {
      this.__\u003C\u003Etags.remove((object) "steamid");
      Vars.ui.editor.__\u003C\u003Eeditor.tags.remove((object) "steamid");
      Exception exception;
      try
      {
        Vars.ui.editor.save();
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
      Log.err((Exception) exception);
    }

    [LineNumberTable(173)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string steamTitle() => this.name();

    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string steamDescription() => this.description();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string steamTag() => "map";

    [LineNumberTable(new byte[] {160, 74, 127, 16, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi createSteamFolder(string id)
    {
      Fi dest = Vars.tmpDirectory.child(new StringBuilder().append("map_").append(id).toString()).child("map.msav");
      this.__\u003C\u003Efile.copyTo(dest);
      return dest.parent();
    }

    [LineNumberTable(195)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi createSteamPreview(string id) => this.previewFile();

    [Signature("()Larc/struct/Seq<Ljava/lang/String;>;")]
    [LineNumberTable(new byte[] {160, 86, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq extraTags() => Seq.with((object[]) new string[1]
    {
      (!Gamemode.__\u003C\u003Eattack.valid(this) ? Gamemode.__\u003C\u003Esurvival : Gamemode.__\u003C\u003Eattack).name()
    });

    [LineNumberTable(new byte[] {160, 92, 123, 127, 21, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool prePublish()
    {
      this.__\u003C\u003Etags.put((object) "author", (object) Vars.player.name);
      Vars.ui.editor.__\u003C\u003Eeditor.tags.put((object) "author", (object) (string) this.__\u003C\u003Etags.get((object) "author"));
      Vars.ui.editor.save();
      return true;
    }

    [LineNumberTable(227)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("Map{file='").append((object) this.__\u003C\u003Efile).append('\'').append(", custom=").append(this.__\u003C\u003Ecustom).append(", tags=").append((object) this.__\u003C\u003Etags).append('}').toString();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(object obj) => this.compareTo((Map) obj);

    [HideFromJava]
    public virtual bool hasSteamID() => Publishable.\u003Cdefault\u003EhasSteamID((Publishable) this);

    int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
      [In] object obj0)
    {
      return this.compareTo(obj0);
    }

    [Modifiers]
    public bool custom
    {
      [HideFromJava] get => this.__\u003C\u003Ecustom;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecustom = value;
    }

    [Modifiers]
    public StringMap tags
    {
      [HideFromJava] get => this.__\u003C\u003Etags;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etags = value;
    }

    [Modifiers]
    public Fi file
    {
      [HideFromJava] get => this.__\u003C\u003Efile;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efile = value;
    }

    [Modifiers]
    public int version
    {
      [HideFromJava] get => this.__\u003C\u003Eversion;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eversion = value;
    }
  }
}
