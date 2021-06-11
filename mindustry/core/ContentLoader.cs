// Decompiled with JetBrains decompiler
// Type: mindustry.core.ContentLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.graphics;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.entities.bullet;
using mindustry.game;
using mindustry.mod;
using mindustry.type;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  public class ContentLoader : Object
  {
    [Signature("[Larc/struct/ObjectMap<Ljava/lang/String;Lmindustry/ctype/MappableContent;>;")]
    private ObjectMap[] contentNameMap;
    [Signature("[Larc/struct/Seq<Lmindustry/ctype/Content;>;")]
    private Seq[] contentMap;
    private MappableContent[][] temporaryMapper;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Mods.LoadedMod currentMod;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Content lastAdded;
    [Signature("Larc/struct/ObjectSet<Larc/func/Cons<Lmindustry/ctype/Content;>;>;")]
    private ObjectSet initialization;
    private ContentList[] content;

    [LineNumberTable(new byte[] {57, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load() => this.initialize((Cons) new ContentLoader.__\u003C\u003EAnon2());

    [LineNumberTable(new byte[] {50, 112, 113, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
      this.initialize((Cons) new ContentLoader.__\u003C\u003EAnon1());
      if (Vars.constants != null)
        Vars.constants.init();
      Events.fire((object) new EventType.ContentInitEvent());
    }

    [LineNumberTable(new byte[] {23, 103, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void createModContent()
    {
      if (Vars.mods == null)
        return;
      Vars.mods.loadContent();
    }

    [LineNumberTable(new byte[] {16, 116, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void createBaseContent()
    {
      ContentList[] content = this.content;
      int length = content.Length;
      for (int index = 0; index < length; ++index)
        content[index].load();
    }

    [LineNumberTable(new byte[] {84, 117, 110, 113, 137, 141, 104, 141, 120, 112, 231, 53, 233, 78, 102, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadColors()
    {
      Pixmap pixmap = new Pixmap(Core.files.@internal("sprites/block_colors.png"));
      for (int index = 0; index < pixmap.getWidth(); ++index)
      {
        if (this.blocks().size > index)
        {
          int pixel = pixmap.getPixel(index, 0);
          switch (pixel)
          {
            case 0:
            case (int) byte.MaxValue:
              continue;
            default:
              Block block = this.block(index);
              block.mapColor.rgba8888(pixel);
              block.squareSprite = (double) block.mapColor.a > 0.5;
              block.mapColor.a = 1f;
              block.hasColor = true;
              continue;
          }
        }
      }
      pixmap.dispose();
      ColorMapper.load();
    }

    [Signature("()Larc/struct/Seq<Lmindustry/type/Item;>;")]
    [LineNumberTable(258)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq items() => this.getBy(ContentType.__\u003C\u003Eitem);

    [Signature("()Larc/struct/Seq<Lmindustry/type/SectorPreset;>;")]
    [LineNumberTable(286)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq sectors() => this.getBy(ContentType.__\u003C\u003Esector);

    [Signature("()Larc/struct/Seq<Lmindustry/type/UnitType;>;")]
    [LineNumberTable(290)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq units() => this.getBy(ContentType.__\u003C\u003Eunit);

    [Signature("()Larc/struct/Seq<Lmindustry/type/Planet;>;")]
    [LineNumberTable(294)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq planets() => this.getBy(ContentType.__\u003C\u003Eplanet);

    [LineNumberTable(new byte[] {159, 189, 232, 43, 113, 209, 107, 255, 81, 80, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContentLoader()
    {
      ContentLoader contentLoader = this;
      this.contentNameMap = new ObjectMap[ContentType.__\u003C\u003Eall.Length];
      this.contentMap = new Seq[ContentType.__\u003C\u003Eall.Length];
      this.initialization = new ObjectSet();
      this.content = new ContentList[12]
      {
        (ContentList) new Items(),
        (ContentList) new StatusEffects(),
        (ContentList) new Liquids(),
        (ContentList) new Bullets(),
        (ContentList) new AmmoTypes(),
        (ContentList) new UnitTypes(),
        (ContentList) new Blocks(),
        (ContentList) new Loadouts(),
        (ContentList) new Weathers(),
        (ContentList) new Planets(),
        (ContentList) new SectorPresets(),
        (ContentList) new TechTree()
      };
      this.clear();
    }

    [Signature("()Larc/struct/Seq<Lmindustry/world/Block;>;")]
    [LineNumberTable(246)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq blocks() => this.getBy(ContentType.__\u003C\u003Eblock);

    [LineNumberTable(250)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block block(int id) => (Block) this.getByID(ContentType.__\u003C\u003Eblock, id);

    [Signature("<T:Lmindustry/ctype/Content;>(Lmindustry/ctype/ContentType;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(240)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getBy(ContentType type) => this.contentMap[type.ordinal()];

    [LineNumberTable(new byte[] {124, 103, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleContent(Content content)
    {
      this.lastAdded = content;
      this.contentMap[content.getContentType().ordinal()].add((object) content);
    }

    [LineNumberTable(183)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string transformName(string name) => this.currentMod == null ? name : new StringBuilder().append(this.currentMod.__\u003C\u003Ename).append("-").append(name).toString();

    [LineNumberTable(new byte[] {160, 73, 127, 0, 159, 21, 104, 113, 109, 182, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleMappableContent(MappableContent content)
    {
      if (this.contentNameMap[content.getContentType().ordinal()].containsKey((object) content.__\u003C\u003Ename))
      {
        string str = new StringBuilder().append("Two content objects cannot have the same name! (issue: '").append(content.__\u003C\u003Ename).append("')").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (this.currentMod != null)
      {
        content.minfo.mod = this.currentMod;
        if (content.minfo.sourceFile == null)
          content.minfo.sourceFile = new Fi(content.__\u003C\u003Ename);
      }
      this.contentNameMap[content.getContentType().ordinal()].put((object) content.__\u003C\u003Ename, (object) content);
    }

    [LineNumberTable(254)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Block block(string name) => (Block) this.getByName(ContentType.__\u003C\u003Eblock, name);

    [Signature("()Larc/struct/Seq<Lmindustry/type/StatusEffect;>;")]
    [LineNumberTable(282)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq statusEffects() => this.getBy(ContentType.__\u003C\u003Estatus);

    [LineNumberTable(new byte[] {3, 113, 113, 139, 115, 114, 18, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.contentNameMap = new ObjectMap[ContentType.__\u003C\u003Eall.Length];
      this.contentMap = new Seq[ContentType.__\u003C\u003Eall.Length];
      this.initialization = new ObjectSet();
      ContentType[] all = ContentType.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        ContentType contentType = all[index];
        this.contentMap[contentType.ordinal()] = new Seq();
        this.contentNameMap[contentType.ordinal()] = new ObjectMap();
      }
    }

    [Signature("(Larc/func/Cons<Lmindustry/ctype/Content;>;)V")]
    [LineNumberTable(new byte[] {62, 143, 118, 159, 15, 252, 72, 226, 57, 98, 110, 103, 144, 173, 229, 52, 233, 79, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initialize([In] Cons obj0)
    {
      if (this.initialization.contains((object) obj0))
        return;
      ContentType[] all = ContentType.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        Iterator iterator = this.contentMap[all[index].ordinal()].iterator();
        while (iterator.hasNext())
        {
          Content content = (Content) iterator.next();
          Exception exception1;
          try
          {
            obj0.get((object) content);
            continue;
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          Exception exception2 = exception1;
          if (content.minfo.mod != null)
          {
            Log.err(exception2);
            Vars.mods.handleContentError(content, exception2);
          }
          else
          {
            Exception exception3 = exception2;
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException(exception3);
          }
        }
      }
      this.initialization.add((object) obj0);
    }

    [Signature("<T:Lmindustry/ctype/Content;>(Lmindustry/ctype/ContentType;I)TT;")]
    [LineNumberTable(new byte[] {160, 108, 159, 11, 100, 130, 127, 3, 153, 176, 121, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Content getByID(ContentType type, int id)
    {
      if (this.temporaryMapper != null && this.temporaryMapper[type.ordinal()] != null && this.temporaryMapper[type.ordinal()].Length != 0)
      {
        if (id < 0)
          return (Content) null;
        return this.temporaryMapper[type.ordinal()].Length <= id || this.temporaryMapper[type.ordinal()][id] == null ? (Content) this.contentMap[type.ordinal()].get(0) : (Content) this.temporaryMapper[type.ordinal()][id];
      }
      return id >= this.contentMap[type.ordinal()].size || id < 0 ? (Content) null : (Content) this.contentMap[type.ordinal()].get(id);
    }

    [Signature("<T:Lmindustry/ctype/MappableContent;>(Lmindustry/ctype/ContentType;Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {160, 100, 111, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual MappableContent getByName(ContentType type, string name) => this.contentNameMap[type.ordinal()] == null ? (MappableContent) null : (MappableContent) this.contentNameMap[type.ordinal()].get((object) name);

    [Modifiers]
    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024logContent\u00240([In] ContentType obj0) => this.contentMap[obj0.ordinal()].size;

    [LineNumberTable(new byte[] {31, 119, 112, 116, 102, 255, 57, 61, 43, 233, 73, 106, 110, 63, 23, 168, 127, 24, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void logContent()
    {
      Seq[] contentMap = this.contentMap;
      int length = contentMap.Length;
      for (int index1 = 0; index1 < length; ++index1)
      {
        Seq seq = contentMap[index1];
        for (int index2 = 0; index2 < seq.size; ++index2)
        {
          int id = (int) ((Content) seq.get(index2)).__\u003C\u003Eid;
          if (id != index2)
          {
            string str = new StringBuilder().append("Out-of-order IDs for content '").append(seq.get(index2)).append("' (expected ").append(index2).append(" but got ").append(id).append(")").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
          }
        }
      }
      Log.debug((object) "--- CONTENT INFO ---");
      for (int index = 0; index < this.contentMap.Length; ++index)
        Log.debug("[@]: loaded @", (object) ContentType.__\u003C\u003Eall[index].name(), (object) Integer.valueOf(this.contentMap[index].size));
      Log.debug("Total content loaded: @", (object) Integer.valueOf(Seq.with((object[]) ContentType.__\u003C\u003Eall).mapInt((Intf) new ContentLoader.__\u003C\u003EAnon0(this)).sum()));
      Log.debug((object) "-------------------");
    }

    [LineNumberTable(new byte[] {104, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.initialize((Cons) new ContentLoader.__\u003C\u003EAnon3());
      this.clear();
    }

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Content getLastAdded() => this.lastAdded;

    [LineNumberTable(new byte[] {115, 127, 21, 125, 127, 5, 191, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeLast()
    {
      if (this.lastAdded == null || !object.ReferenceEquals(this.contentMap[this.lastAdded.getContentType().ordinal()].peek(), (object) this.lastAdded))
        return;
      this.contentMap[this.lastAdded.getContentType().ordinal()].pop();
      Content lastAdded = this.lastAdded;
      MappableContent mappableContent;
      if (!(lastAdded is MappableContent) || !object.ReferenceEquals((object) (mappableContent = (MappableContent) lastAdded), (object) (MappableContent) lastAdded))
        return;
      this.contentNameMap[this.lastAdded.getContentType().ordinal()].remove((object) mappableContent.__\u003C\u003Ename);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCurrentMod([arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Mods.LoadedMod mod) => this.currentMod = mod;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTemporaryMapper(MappableContent[][] temporaryMapper) => this.temporaryMapper = temporaryMapper;

    [Signature("()[Larc/struct/Seq<Lmindustry/ctype/Content;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq[] getContentMap() => this.contentMap;

    [Signature("(Larc/func/Cons<Lmindustry/ctype/Content;>;)V")]
    [LineNumberTable(new byte[] {160, 94, 116, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Cons cons)
    {
      Seq[] contentMap = this.contentMap;
      int length = contentMap.Length;
      for (int index = 0; index < length; ++index)
        contentMap[index].each(cons);
    }

    [LineNumberTable(262)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Item item(int id) => (Item) this.getByID(ContentType.__\u003C\u003Eitem, id);

    [Signature("()Larc/struct/Seq<Lmindustry/type/Liquid;>;")]
    [LineNumberTable(266)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq liquids() => this.getBy(ContentType.__\u003C\u003Eliquid);

    [LineNumberTable(270)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Liquid liquid(int id) => (Liquid) this.getByID(ContentType.__\u003C\u003Eliquid, id);

    [Signature("()Larc/struct/Seq<Lmindustry/entities/bullet/BulletType;>;")]
    [LineNumberTable(274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq bullets() => this.getBy(ContentType.__\u003C\u003Ebullet);

    [LineNumberTable(278)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BulletType bullet(int id) => (BulletType) this.getByID(ContentType.__\u003C\u003Ebullet, id);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Intf
    {
      private readonly ContentLoader arg\u00241;

      internal __\u003C\u003EAnon0([In] ContentLoader obj0) => this.arg\u00241 = obj0;

      public int get([In] object obj0) => this.arg\u00241.lambda\u0024logContent\u00240((ContentType) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => ((Content) obj0).init();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void get([In] object obj0) => ((Content) obj0).load();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => ((Content) obj0).dispose();
    }
  }
}
