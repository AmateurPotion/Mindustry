// Decompiled with JetBrains decompiler
// Type: mindustry.ai.BaseRegistry
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using mindustry.ctype;
using mindustry.game;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.production;
using mindustry.world.blocks.sandbox;
using mindustry.world.blocks.storage;
using mindustry.world.meta;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ai
{
  public class BaseRegistry : Object
  {
    [Signature("Larc/struct/Seq<Lmindustry/ai/BaseRegistry$BasePart;>;")]
    public Seq cores;
    [Signature("Larc/struct/Seq<Lmindustry/ai/BaseRegistry$BasePart;>;")]
    public Seq parts;
    [Signature("Larc/struct/ObjectMap<Lmindustry/ctype/Content;Larc/struct/Seq<Lmindustry/ai/BaseRegistry$BasePart;>;>;")]
    public ObjectMap reqParts;
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/Item;Lmindustry/world/blocks/environment/OreBlock;>;")]
    public ObjectMap ores;
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/Item;Lmindustry/world/blocks/environment/Floor;>;")]
    public ObjectMap oreFloors;

    [LineNumberTable(new byte[] {159, 178, 108, 108, 171, 127, 8, 117, 127, 0, 127, 14, 157, 133, 159, 0, 152, 159, 13, 105, 107, 131, 159, 9, 110, 206, 110, 110, 205, 110, 110, 205, 124, 127, 28, 134, 101, 151, 158, 105, 111, 105, 173, 101, 127, 0, 118, 152, 117, 181, 114, 255, 29, 69, 2, 98, 237, 8, 235, 124, 118, 108, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      this.cores.clear();
      this.parts.clear();
      this.reqParts.clear();
      Iterator iterator1 = Vars.content.blocks().iterator();
      while (iterator1.hasNext())
      {
        Block block = (Block) iterator1.next();
        if (block is OreBlock && block.asFloor().itemDrop != null)
          this.ores.put((object) block.asFloor().itemDrop, (object) (OreBlock) block);
        else if (block.isFloor() && block.asFloor().itemDrop != null && !this.oreFloors.containsKey((object) block.asFloor().itemDrop))
          this.oreFloors.put((object) block.asFloor().itemDrop, (object) block.asFloor());
      }
      string[] strArray = String.instancehelper_split(Core.files.@internal("basepartnames").readString(), "\n");
      int length = strArray.Length;
      for (int index = 0; index < length; ++index)
      {
        string str = strArray[index];
        IOException ioException1;
        try
        {
          Schematic schematic = Schematics.read(Core.files.@internal(new StringBuilder().append("baseparts/").append(str).toString()));
          BaseRegistry.BasePart basePart = new BaseRegistry.BasePart(schematic);
          Tmp.__\u003C\u003Ev1.setZero();
          int num = 0;
          Iterator iterator2 = schematic.__\u003C\u003Etiles.iterator();
          while (iterator2.hasNext())
          {
            Schematic.Stile stile = (Schematic.Stile) iterator2.next();
            if (stile.block is CoreBlock)
              basePart.core = stile.block;
            if (stile.block is ItemSource)
            {
              Item config = (Item) stile.config;
              if (config != null)
                basePart.required = (Content) config;
            }
            if (stile.block is LiquidSource)
            {
              Liquid config = (Liquid) stile.config;
              if (config != null)
                basePart.required = (Content) config;
            }
            if (stile.block is Drill || stile.block is Pump)
            {
              Tmp.__\u003C\u003Ev1.add((float) ((int) stile.x * 8) + stile.block.offset, (float) ((int) stile.y * 8) + stile.block.offset);
              ++num;
            }
          }
          schematic.__\u003C\u003Etiles.removeAll((Boolf) new BaseRegistry.__\u003C\u003EAnon1());
          basePart.tier = schematic.__\u003C\u003Etiles.sumf((Floatf) new BaseRegistry.__\u003C\u003EAnon2());
          if (basePart.core != null)
            this.cores.add((object) basePart);
          else if (basePart.required == null)
            this.parts.add((object) basePart);
          if (num > 0)
          {
            Tmp.__\u003C\u003Ev1.scl(1f / (float) num).scl(0.125f);
            basePart.centerX = ByteCodeHelper.f2i(Tmp.__\u003C\u003Ev1.x);
            basePart.centerY = ByteCodeHelper.f2i(Tmp.__\u003C\u003Ev1.y);
          }
          else
          {
            basePart.centerX = basePart.__\u003C\u003Eschematic.width / 2;
            basePart.centerY = basePart.__\u003C\u003Eschematic.height / 2;
          }
          if (basePart.required != null)
          {
            if (basePart.core == null)
            {
              ((Seq) this.reqParts.get((object) basePart.required, (Prov) new BaseRegistry.__\u003C\u003EAnon0())).add((object) basePart);
              continue;
            }
            continue;
          }
          continue;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        IOException ioException2 = ioException1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException((Exception) ioException2);
      }
      this.cores.sort((Floatf) new BaseRegistry.__\u003C\u003EAnon3());
      this.parts.sort();
      this.reqParts.each((Cons2) new BaseRegistry.__\u003C\u003EAnon4());
    }

    [LineNumberTable(new byte[] {159, 164, 136, 139, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseRegistry()
    {
      BaseRegistry baseRegistry = this;
      this.cores = new Seq();
      this.parts = new Seq();
      this.reqParts = new ObjectMap();
      this.ores = new ObjectMap();
      this.oreFloors = new ObjectMap();
    }

    [Signature("(Lmindustry/ctype/Content;)Larc/struct/Seq<Lmindustry/ai/BaseRegistry$BasePart;>;")]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq forResource(Content item) => (Seq) this.reqParts.get((object) item, (Prov) new BaseRegistry.__\u003C\u003EAnon0());

    [Modifiers]
    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024load\u00240([In] Schematic.Stile obj0) => object.ReferenceEquals((object) obj0.block.buildVisibility, (object) BuildVisibility.__\u003C\u003EsandboxOnly);

    [Modifiers]
    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024load\u00241([In] Schematic.Stile obj0) => Mathf.pow(obj0.block.buildCost / obj0.block.buildCostMultiplier, 1.4f);

    [Modifiers]
    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024load\u00242([In] BaseRegistry.BasePart obj0) => obj0.tier;

    [Modifiers]
    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00243([In] Content obj0, [In] Seq obj1) => obj1.sort();

    [Signature("Ljava/lang/Object;Ljava/lang/Comparable<Lmindustry/ai/BaseRegistry$BasePart;>;")]
    [Implements(new string[] {"java.lang.Comparable"})]
    public class BasePart : Object, Comparable
    {
      internal Schematic __\u003C\u003Eschematic;
      public int centerX;
      public int centerY;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Content required;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Block core;
      public float tier;

      [LineNumberTable(134)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compareTo(BaseRegistry.BasePart other) => Float.compare(this.tier, other.tier);

      [LineNumberTable(new byte[] {78, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BasePart(Schematic schematic)
      {
        BaseRegistry.BasePart basePart = this;
        this.__\u003C\u003Eschematic = schematic;
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(116)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compareTo(object obj) => this.compareTo((BaseRegistry.BasePart) obj);

      int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
        [In] object obj0)
      {
        return this.compareTo(obj0);
      }

      [Modifiers]
      public Schematic schematic
      {
        [HideFromJava] get => this.__\u003C\u003Eschematic;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eschematic = value;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Seq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (BaseRegistry.lambda\u0024load\u00240((Schematic.Stile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Floatf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public float get([In] object obj0) => BaseRegistry.lambda\u0024load\u00241((Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Floatf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public float get([In] object obj0) => BaseRegistry.lambda\u0024load\u00242((BaseRegistry.BasePart) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons2
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void get([In] object obj0, [In] object obj1) => BaseRegistry.lambda\u0024load\u00243((Content) obj0, (Seq) obj1);
    }
  }
}
