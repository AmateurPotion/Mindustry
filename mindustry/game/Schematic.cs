// Decompiled with JetBrains decompiler
// Type: mindustry.game.Schematic
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.func;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.mod;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.power;
using mindustry.world.blocks.storage;
using mindustry.world.consumers;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  [Signature("Ljava/lang/Object;Lmindustry/type/Publishable;Ljava/lang/Comparable<Lmindustry/game/Schematic;>;")]
  [Implements(new string[] {"mindustry.type.Publishable", "java.lang.Comparable"})]
  public class Schematic : Object, Publishable, Comparable
  {
    [Signature("Larc/struct/Seq<Lmindustry/game/Schematic$Stile;>;")]
    internal Seq __\u003C\u003Etiles;
    public StringMap tags;
    public int width;
    public int height;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Fi file;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Mods.LoadedMod mod;

    [LineNumberTable(new byte[] {20, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void save() => Vars.schematics.saveChanges(this);

    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string name() => (string) this.tags.get((object) nameof (name), (object) "unknown");

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string description() => (string) this.tags.get((object) nameof (description), (object) "");

    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(Schematic schematic) => String.instancehelper_compareTo(this.name(), schematic.name());

    [Modifiers]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024powerProduction\u00240([In] Schematic.Stile obj0) => obj0.block is PowerGenerator ? ((PowerGenerator) obj0.block).powerProduction : 0.0f;

    [Modifiers]
    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024powerConsumption\u00241([In] Schematic.Stile obj0) => obj0.block.__\u003C\u003Econsumes.has(ConsumeType.__\u003C\u003Epower) ? obj0.block.__\u003C\u003Econsumes.getPower().__\u003C\u003Eusage : 0.0f;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 185, 121, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024requirements\u00242([In] ItemSeq obj0, [In] Schematic.Stile obj1)
    {
      ItemStack[] requirements = obj1.block.requirements;
      int length = requirements.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = requirements[index];
        obj0.add(itemStack.item, itemStack.amount);
      }
    }

    [Modifiers]
    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024hasCore\u00243([In] Schematic.Stile obj0) => obj0.block is CoreBlock;

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024findCore\u00244([In] Schematic.Stile obj0) => obj0.block is CoreBlock;

    [Signature("(Larc/struct/Seq<Lmindustry/game/Schematic$Stile;>;Larc/struct/StringMap;II)V")]
    [LineNumberTable(new byte[] {159, 166, 104, 103, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Schematic(Seq tiles, StringMap tags, int width, int height)
    {
      Schematic schematic = this;
      this.__\u003C\u003Etiles = tiles;
      this.tags = tags;
      this.width = width;
      this.height = height;
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float powerProduction() => this.__\u003C\u003Etiles.sumf((Floatf) new Schematic.__\u003C\u003EAnon0());

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float powerConsumption() => this.__\u003C\u003Etiles.sumf((Floatf) new Schematic.__\u003C\u003EAnon1());

    [LineNumberTable(new byte[] {159, 182, 134, 246, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemSeq requirements()
    {
      ItemSeq itemSeq = new ItemSeq();
      this.__\u003C\u003Etiles.each((Cons) new Schematic.__\u003C\u003EAnon2(itemSeq));
      return itemSeq;
    }

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasCore() => this.__\u003C\u003Etiles.contains((Boolf) new Schematic.__\u003C\u003EAnon3());

    [LineNumberTable(new byte[] {6, 123, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CoreBlock findCore()
    {
      Schematic.Stile stile = (Schematic.Stile) this.__\u003C\u003Etiles.find((Boolf) new Schematic.__\u003C\u003EAnon4());
      if (stile == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Schematic is missing a core!");
      }
      return (CoreBlock) stile.block;
    }

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSteamID() => (string) this.tags.get((object) "steamid");

    [LineNumberTable(new byte[] {30, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addSteamID(string id)
    {
      this.tags.put((object) "steamid", (object) id);
      this.save();
    }

    [LineNumberTable(new byte[] {36, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeSteamID()
    {
      this.tags.remove((object) "steamid");
      this.save();
    }

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string steamTitle() => this.name();

    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string steamDescription() => this.description();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string steamTag() => "schematic";

    [LineNumberTable(new byte[] {57, 127, 16, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi createSteamFolder(string id)
    {
      Fi dest = Vars.tmpDirectory.child(new StringBuilder().append("schematic_").append(id).toString()).child("schematic.msch");
      this.file.copyTo(dest);
      return dest;
    }

    [LineNumberTable(new byte[] {64, 127, 16, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi createSteamPreview(string id)
    {
      Fi file = Vars.tmpDirectory.child(new StringBuilder().append("schematic_preview_").append(id).append(".png").toString());
      Vars.schematics.savePreview(this, file);
      return file;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(object obj) => this.compareTo((Schematic) obj);

    [HideFromJava]
    public virtual Seq extraTags() => Publishable.\u003Cdefault\u003EextraTags((Publishable) this);

    [HideFromJava]
    public virtual bool hasSteamID() => Publishable.\u003Cdefault\u003EhasSteamID((Publishable) this);

    [HideFromJava]
    public virtual bool prePublish() => Publishable.\u003Cdefault\u003EprePublish((Publishable) this);

    int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
      [In] object obj0)
    {
      return this.compareTo(obj0);
    }

    [Modifiers]
    public Seq tiles
    {
      [HideFromJava] get => this.__\u003C\u003Etiles;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etiles = value;
    }

    public class Stile : Object
    {
      public Block block;
      public short x;
      public short y;
      public object config;
      public byte rotation;

      [LineNumberTable(new byte[] {159, 110, 132, 104, 103, 104, 104, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Stile(Block block, int x, int y, object config, byte rotation)
      {
        int num = (int) (sbyte) rotation;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Schematic.Stile stile = this;
        this.block = block;
        this.x = (short) x;
        this.y = (short) y;
        this.config = config;
        this.rotation = (byte) num;
      }

      [LineNumberTable(new byte[] {89, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Stile()
      {
        Schematic.Stile stile = this;
        this.block = Blocks.air;
      }

      [LineNumberTable(new byte[] {94, 108, 108, 108, 108, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Schematic.Stile set(Schematic.Stile other)
      {
        this.block = other.block;
        this.x = other.x;
        this.y = other.y;
        this.config = other.config;
        this.rotation = other.rotation;
        return this;
      }

      [LineNumberTable(153)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Schematic.Stile copy() => new Schematic.Stile(this.block, (int) this.x, (int) this.y, this.config, this.rotation);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Floatf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public float get([In] object obj0) => Schematic.lambda\u0024powerProduction\u00240((Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float get([In] object obj0) => Schematic.lambda\u0024powerConsumption\u00241((Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly ItemSeq arg\u00241;

      internal __\u003C\u003EAnon2([In] ItemSeq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Schematic.lambda\u0024requirements\u00242(this.arg\u00241, (Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get([In] object obj0) => (Schematic.lambda\u0024hasCore\u00243((Schematic.Stile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (Schematic.lambda\u0024findCore\u00244((Schematic.Stile) obj0) ? 1 : 0) != 0;
    }
  }
}
