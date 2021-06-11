// Decompiled with JetBrains decompiler
// Type: mindustry.game.Schematics
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
using arc.graphics.gl;
using arc.math;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.zip;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.input;
using mindustry.io;
using mindustry.mod;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.distribution;
using mindustry.world.blocks.legacy;
using mindustry.world.blocks.power;
using mindustry.world.blocks.production;
using mindustry.world.blocks.sandbox;
using mindustry.world.blocks.storage;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  public class Schematics : Object, Loadable
  {
    [Modifiers]
    private static Schematic tmpSchem;
    [Modifiers]
    private static Schematic tmpSchem2;
    [Modifiers]
    private static byte[] header;
    private const byte version = 1;
    private const int padding = 2;
    private const int maxPreviewsMobile = 32;
    private const int resolution = 32;
    private Streams.OptimizedByteArrayOutputStream @out;
    [Signature("Larc/struct/Seq<Lmindustry/game/Schematic;>;")]
    private Seq all;
    [Signature("Larc/struct/OrderedMap<Lmindustry/game/Schematic;Larc/graphics/gl/FrameBuffer;>;")]
    private OrderedMap previews;
    [Signature("Larc/struct/ObjectSet<Lmindustry/game/Schematic;>;")]
    private ObjectSet errored;
    [Signature("Larc/struct/ObjectMap<Lmindustry/world/blocks/storage/CoreBlock;Larc/struct/Seq<Lmindustry/game/Schematic;>;>;")]
    private ObjectMap loadouts;
    private FrameBuffer shadowBuffer;
    private Texture errorTexture;
    private long lastClearTime;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {15, 232, 55, 112, 107, 107, 107, 235, 71, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Schematics()
    {
      Schematics schematics = this;
      this.@out = new Streams.OptimizedByteArrayOutputStream(1024);
      this.all = new Seq();
      this.previews = new OrderedMap();
      this.errored = new ObjectSet();
      this.loadouts = new ObjectMap();
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new Schematics.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {161, 214, 133, 101, 107, 41, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Schematic rotate(Schematic input, int times)
    {
      if (times == 0)
        return input;
      int num = times > 0 ? 1 : 0;
      for (int index = 0; index < Math.abs(times); ++index)
        input = Schematics.rotated(input, num != 0);
      return input;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 110, 118, 114, 151, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Schematic read(Fi file)
    {
      Schematic schematic = Schematics.read((InputStream) new DataInputStream((InputStream) file.read(1024)));
      if (!schematic.tags.containsKey((object) "name"))
        schematic.tags.put((object) "name", (object) file.nameWithoutExtension());
      schematic.file = file;
      return schematic;
    }

    [LineNumberTable(new byte[] {161, 103, 127, 12, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Schematic readBase64(string schematic)
    {
      Schematic schematic1;
      IOException ioException1;
      try
      {
        schematic1 = Schematics.read((InputStream) new ByteArrayInputStream(Base64Coder.decode(String.instancehelper_trim(schematic))));
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return schematic1;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {161, 39, 113, 127, 4, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void placeLaunchLoadout(int x, int y)
    {
      Schematics.placeLoadout(Vars.universe.getLastLoadout(), x, y);
      if (Vars.world.tile(x, y).build == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("No core at loadout coordinates!");
      }
      Vars.world.tile(x, y).build.items.add(Vars.universe.getLaunchResources());
    }

    [LineNumberTable(new byte[] {111, 136, 191, 4, 2, 97, 171, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void saveChanges(Schematic s)
    {
      if (s.file != null)
      {
        Exception exception1;
        try
        {
          Schematics.write(s, s.file);
          goto label_6;
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
        Vars.ui.showException((Exception) exception2);
      }
label_6:
      this.all.sort();
    }

    [LineNumberTable(new byte[] {122, 104, 101, 102, 116, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void savePreview(Schematic schematic, Fi file)
    {
      FrameBuffer buffer = this.getBuffer(schematic);
      Draw.flush();
      buffer.begin();
      Pixmap frameBufferPixmap = ScreenUtils.getFrameBufferPixmap(0, 0, buffer.getWidth(), buffer.getHeight());
      file.writePNG(frameBufferPixmap);
      buffer.end();
    }

    [LineNumberTable(new byte[] {29, 140, 134, 120, 40, 198, 191, 0, 250, 71, 140, 104, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      this.all.clear();
      this.loadLoadouts();
      Fi[] fiArray = Vars.schematicDirectory.list();
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
        this.loadFile(fiArray[index]);
      Vars.platform.getWorkshopContent((Class) ClassLiteral<Schematic>.Value).each((Cons) new Schematics.__\u003C\u003EAnon1(this));
      Vars.mods.listFiles("schematics", (Cons2) new Schematics.__\u003C\u003EAnon2(this));
      this.all.sort();
      if (this.shadowBuffer != null)
        return;
      Core.app.post((Runnable) new Schematics.__\u003C\u003EAnon3(this));
    }

    [LineNumberTable(new byte[] {55, 127, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void loadLoadouts() => Seq.with((object[]) new Schematic[3]
    {
      Loadouts.basicShard,
      Loadouts.basicFoundation,
      Loadouts.basicNucleus
    }).each((Cons) new Schematics.__\u003C\u003EAnon4(this));

    [LineNumberTable(new byte[] {86, 180, 103, 108, 168, 119, 191, 2, 119, 97, 116, 134})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Schematic loadFile([In] Fi obj0)
    {
      if (!String.instancehelper_equals(obj0.extension(), (object) "msch"))
        return (Schematic) null;
      Schematic schematic1;
      Exception exception;
      try
      {
        Schematic schematic2 = Schematics.read(obj0);
        this.all.add((object) schematic2);
        this.checkLoadout(schematic2, true);
        if (!schematic2.file.parent().equals((object) Vars.schematicDirectory))
          schematic2.tags.put((object) "steamid", (object) schematic2.file.parent().name());
        schematic1 = schematic2;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_7;
      }
      return schematic1;
label_7:
      Exception th = exception;
      Log.err("Failed to read schematic from file '@'", (object) obj0);
      Log.err(th);
      return (Schematic) null;
    }

    [LineNumberTable(new byte[] {159, 69, 130, 123, 182, 127, 35, 172, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkLoadout([In] Schematic obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      Schematic.Stile stile = (Schematic.Stile) obj0.__\u003C\u003Etiles.find((Boolf) new Schematics.__\u003C\u003EAnon14());
      int num2 = obj0.__\u003C\u003Etiles.count((Boolf) new Schematics.__\u003C\u003EAnon15());
      if (stile == null || num1 != 0 && (obj0.width > stile.block.size + 10 || obj0.height > stile.block.size + 10 || (obj0.__\u003C\u003Etiles.contains((Boolf) new Schematics.__\u003C\u003EAnon16()) || num2 > 1)))
        return;
      ((Seq) this.loadouts.get((object) (CoreBlock) stile.block, (Prov) new Schematics.__\u003C\u003EAnon13())).add((object) obj0);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 161, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void write(Schematic schematic, Fi file) => Schematics.write(schematic, file.write(false, 1024));

    [LineNumberTable(new byte[] {160, 86, 127, 19, 113, 147, 127, 2, 248, 61, 230, 70, 171, 113, 101, 101, 112, 112, 156, 144, 107, 159, 14, 101, 245, 77, 139, 139, 159, 7, 127, 13, 121, 127, 22, 133, 150, 133, 191, 5, 241, 70, 145, 101, 139, 134, 106, 138, 174})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FrameBuffer getBuffer(Schematic schematic)
    {
      if (Vars.mobile && Time.timeSinceMillis(this.lastClearTime) > 2000L && this.previews.size > 32)
      {
        Seq seq = this.previews.orderedKeys().copy();
        for (int index = 0; index < this.previews.size - 32; ++index)
        {
          ((GLFrameBuffer) this.previews.get((object) (Schematic) seq.get(index))).dispose();
          this.previews.remove((object) (Schematic) seq.get(index));
        }
        this.lastClearTime = Time.millis();
      }
      if (!this.previews.containsKey((object) schematic))
      {
        Draw.blend();
        Draw.reset();
        Tmp.__\u003C\u003Em1.set(Draw.proj());
        Tmp.__\u003C\u003Em2.set(Draw.trans());
        FrameBuffer frameBuffer = new FrameBuffer((schematic.width + 2) * 32, (schematic.height + 2) * 32);
        this.shadowBuffer.begin(Color.__\u003C\u003Eclear);
        Draw.trans().idt();
        Draw.proj().setOrtho(0.0f, 0.0f, (float) this.shadowBuffer.getWidth(), (float) this.shadowBuffer.getHeight());
        Draw.color();
        schematic.__\u003C\u003Etiles.each((Cons) new Schematics.__\u003C\u003EAnon6());
        this.shadowBuffer.end();
        frameBuffer.begin(Color.__\u003C\u003Eclear);
        Draw.proj().setOrtho(0.0f, (float) frameBuffer.getHeight(), (float) frameBuffer.getWidth(), (float) -frameBuffer.getHeight());
        Tmp.__\u003C\u003Etr1.set((Texture) this.shadowBuffer.getTexture(), 0, 0, schematic.width + 2, schematic.height + 2);
        Draw.color(0.0f, 0.0f, 0.0f, 1f);
        Draw.rect(Tmp.__\u003C\u003Etr1, (float) frameBuffer.getWidth() / 2f, (float) frameBuffer.getHeight() / 2f, (float) frameBuffer.getWidth(), (float) -frameBuffer.getHeight());
        Draw.color();
        Seq seq = schematic.__\u003C\u003Etiles.map((Func) new Schematics.__\u003C\u003EAnon7());
        Draw.flush();
        Draw.trans().scale(4f, 4f).translate(12f, 12f);
        seq.each((Cons) new Schematics.__\u003C\u003EAnon8(seq));
        seq.each((Cons) new Schematics.__\u003C\u003EAnon9(seq));
        Draw.flush();
        Draw.trans().idt();
        frameBuffer.end();
        Draw.proj(Tmp.__\u003C\u003Em1);
        Draw.trans(Tmp.__\u003C\u003Em2);
        this.previews.put((object) schematic, (object) frameBuffer);
      }
      return (FrameBuffer) this.previews.get((object) schematic);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 165, 107, 135, 140, 108, 140, 113, 127, 6, 113, 113, 130, 102, 182, 108, 109, 61, 200, 145, 127, 8, 120, 121, 114, 110, 119, 232, 36, 255, 18, 93})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void write(Schematic schematic, OutputStream output)
    {
      output.write(Schematics.header);
      output.write(1);
      DataOutputStream dataOutputStream = new DataOutputStream((OutputStream) new DeflaterOutputStream(output));
      Exception exception1;
      try
      {
        dataOutputStream.writeShort(schematic.width);
        dataOutputStream.writeShort(schematic.height);
        dataOutputStream.writeByte(schematic.tags.size);
        ObjectMap.Entries entries = schematic.tags.entries().iterator();
        while (((Iterator) entries).hasNext())
        {
          ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
          dataOutputStream.writeUTF((string) entry.key);
          dataOutputStream.writeUTF((string) entry.value);
        }
        OrderedSet orderedSet = new OrderedSet();
        schematic.__\u003C\u003Etiles.each((Cons) new Schematics.__\u003C\u003EAnon21(orderedSet));
        dataOutputStream.writeByte(orderedSet.size);
        for (int index = 0; index < orderedSet.size; ++index)
          dataOutputStream.writeUTF(((MappableContent) orderedSet.orderedItems().get(index)).__\u003C\u003Ename);
        dataOutputStream.writeInt(schematic.__\u003C\u003Etiles.size);
        Iterator iterator = schematic.__\u003C\u003Etiles.iterator();
        while (iterator.hasNext())
        {
          Schematic.Stile stile = (Schematic.Stile) iterator.next();
          dataOutputStream.writeByte(orderedSet.orderedItems().indexOf((object) stile.block));
          dataOutputStream.writeInt(Point2.pack((int) stile.x, (int) stile.y));
          TypeIO.writeObject(Writes.get((DataOutput) dataOutputStream), stile.config);
          dataOutputStream.writeByte((int) (sbyte) stile.rotation);
        }
        goto label_12;
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
        goto label_16;
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception4 = exception3;
      Throwable.instancehelper_addSuppressed(exception2, exception4);
label_16:
      throw Throwable.__\u003Cunmap\u003E(exception2);
label_12:
      ((FilterOutputStream) dataOutputStream).close();
    }

    [LineNumberTable(new byte[] {161, 45, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void placeLoadout(Schematic schem, int x, int y) => Schematics.placeLoadout(schem, x, y, Vars.state.rules.defaultTeam, Blocks.oreCopper);

    [LineNumberTable(new byte[] {161, 49, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void placeLoadout(Schematic schem, int x, int y, Team team, Block resource) => Schematics.placeLoadout(schem, x, y, team, resource, true);

    [LineNumberTable(new byte[] {159, 37, 163, 123, 102, 115, 115, 253, 88})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void placeLoadout(
      Schematic schem,
      int x,
      int y,
      Team team,
      Block resource,
      bool check)
    {
      int num1 = check ? 1 : 0;
      Schematic.Stile stile = (Schematic.Stile) schem.__\u003C\u003Etiles.find((Boolf) new Schematics.__\u003C\u003EAnon18());
      Seq seq = new Seq();
      if (stile == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Loadout schematic has no core tile!");
      }
      int num2 = x - (int) stile.x;
      int num3 = y - (int) stile.y;
      schem.__\u003C\u003Etiles.each((Cons) new Schematics.__\u003C\u003EAnon19(num2, num3, num1 != 0, seq, team, resource));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 119, 115, 105, 16, 230, 70, 136, 109, 144, 103, 106, 105, 54, 200, 103, 106, 108, 105, 127, 10, 255, 1, 61, 235, 70, 105, 105, 108, 118, 105, 127, 5, 106, 110, 255, 1, 58, 235, 74, 127, 2, 39, 227, 35})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Schematic read(InputStream input)
    {
      byte[] header = Schematics.header;
      int length = header.Length;
      for (int index = 0; index < length; ++index)
      {
        int num = (int) (sbyte) header[index];
        if (input.read() != num)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException("Not a schematic file (missing header).");
        }
      }
      int num1 = input.read();
      DataInputStream dataInputStream = new DataInputStream((InputStream) new InflaterInputStream(input));
      Schematic schematic;
      Exception exception1;
      try
      {
        int width = (int) dataInputStream.readShort();
        int height = (int) dataInputStream.readShort();
        StringMap tags = new StringMap();
        int num2 = (int) (sbyte) dataInputStream.readByte();
        for (int index = 0; index < num2; ++index)
          tags.put((object) dataInputStream.readUTF(), (object) dataInputStream.readUTF());
        IntMap intMap1 = new IntMap();
        int num3 = (int) (sbyte) dataInputStream.readByte();
        for (int index = 0; index < num3; ++index)
        {
          string str = dataInputStream.readUTF();
          Block byName = (Block) Vars.content.getByName(ContentType.__\u003C\u003Eblock, (string) SaveFileReader.__\u003C\u003Efallback.get((object) str, (object) str));
          IntMap intMap2 = intMap1;
          int key = index;
          Block block;
          switch (byName)
          {
            case null:
            case LegacyBlock _:
              block = Blocks.air;
              break;
            default:
              block = byName;
              break;
          }
          intMap2.put(key, (object) block);
        }
        int capacity = dataInputStream.readInt();
        Seq tiles = new Seq(capacity);
        for (int index = 0; index < capacity; ++index)
        {
          Block block = (Block) intMap1.get((int) (sbyte) dataInputStream.readByte());
          int pos = dataInputStream.readInt();
          object config = num1 != 0 ? TypeIO.readObject(Reads.get((DataInput) dataInputStream)) : Schematics.mapConfig(block, dataInputStream.readInt(), pos);
          int num4 = (int) (sbyte) dataInputStream.readByte();
          if (!object.ReferenceEquals((object) block, (object) Blocks.air))
            tiles.add((object) new Schematic.Stile(block, (int) Point2.x(pos), (int) Point2.y(pos), config, (byte) num4));
        }
        schematic = new Schematic(tiles, tags, width, height);
        goto label_23;
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
        goto label_27;
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception4 = exception3;
      Throwable.instancehelper_addSuppressed(exception2, exception4);
label_27:
      throw Throwable.__\u003Cunmap\u003E(exception2);
label_23:
      ((FilterInputStream) dataInputStream).close();
      return schematic;
    }

    [LineNumberTable(new byte[] {161, 201, 127, 5, 116, 127, 9, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object mapConfig([In] Block obj0, [In] int obj1, [In] int obj2)
    {
      switch (obj0)
      {
        case Sorter _:
        case Unloader _:
        case ItemSource _:
          return (object) Vars.content.item(obj1);
        case LiquidSource _:
          return (object) Vars.content.liquid(obj1);
        case MassDriver _:
        case ItemBridge _:
          return (object) Point2.unpack(obj1).sub((int) Point2.x(obj2), (int) Point2.y(obj2));
        case LightBlock _:
          return (object) Integer.valueOf(obj1);
        default:
          return (object) null;
      }
    }

    [LineNumberTable(new byte[] {158, 250, 130, 103, 122, 108, 108, 107, 108, 127, 2, 127, 12, 130, 148, 250, 95, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Schematic rotated([In] Schematic obj0, [In] bool obj1)
    {
      int num1 = Mathf.sign(obj1);
      Schematic schematic = !object.ReferenceEquals((object) obj0, (object) Schematics.tmpSchem) ? Schematics.tmpSchem2 : Schematics.tmpSchem2;
      schematic.width = obj0.width;
      schematic.height = obj0.height;
      Pools.freeAll(schematic.__\u003C\u003Etiles);
      schematic.__\u003C\u003Etiles.clear();
      Iterator iterator = obj0.__\u003C\u003Etiles.iterator();
      while (iterator.hasNext())
      {
        Schematic.Stile other = (Schematic.Stile) iterator.next();
        schematic.__\u003C\u003Etiles.add((object) ((Schematic.Stile) Pools.obtain((Class) ClassLiteral<Schematic.Stile>.Value, (Prov) new Schematics.__\u003C\u003EAnon22())).set(other));
      }
      int num2 = schematic.width / 2;
      int num3 = schematic.height / 2;
      schematic.__\u003C\u003Etiles.each((Cons) new Schematics.__\u003C\u003EAnon23(num1, num2, num3));
      schematic.width = obj0.height;
      schematic.height = obj0.width;
      return schematic;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {18, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.ClientLoadEvent obj0) => this.errorTexture = new Texture("sprites/error.png");

    [Modifiers]
    [LineNumberTable(new byte[] {41, 104, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024load\u00241([In] Mods.LoadedMod obj0, [In] Fi obj1)
    {
      Schematic schematic = this.loadFile(obj1);
      if (schematic == null)
        return;
      schematic.mod = obj0;
    }

    [Modifiers]
    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024load\u00242() => this.shadowBuffer = new FrameBuffer(42, 42);

    [Modifiers]
    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024loadLoadouts\u00243([In] Schematic obj0) => this.checkLoadout(obj0, false);

    [Modifiers]
    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024overwrite\u00244([In] Schematic obj0, [In] CoreBlock obj1, [In] Seq obj2) => obj2.remove((object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 111, 108, 103, 103, 105, 104, 108, 109, 255, 13, 61, 40, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024getBuffer\u00245([In] Schematic.Stile obj0)
    {
      int size = obj0.block.size;
      int num1 = -(size - 1) / 2;
      int num2 = -(size - 1) / 2;
      for (int index1 = 0; index1 < size; ++index1)
      {
        for (int index2 = 0; index2 < size; ++index2)
          Fill.square(1f + (float) ((int) obj0.x + index1 + num1) + 0.5f, 1f + (float) ((int) obj0.y + index2 + num2) + 0.5f, 0.5f);
      }
    }

    [Modifiers]
    [LineNumberTable(248)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static BuildPlan lambda\u0024getBuffer\u00246([In] Schematic.Stile obj0) => new BuildPlan((int) obj0.x, (int) obj0.y, (int) (sbyte) obj0.rotation, obj0.block, obj0.config);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 142, 107, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024getBuffer\u00247([In] Seq obj0, [In] BuildPlan obj1)
    {
      obj1.animScale = 1f;
      obj1.worldContext = false;
      obj1.block.drawRequestRegion(obj1, (Eachable) obj0);
    }

    [Modifiers]
    [LineNumberTable(261)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024getBuffer\u00248([In] Seq obj0, [In] BuildPlan obj1) => obj1.block.drawRequestConfigTop(obj1, (Eachable) obj0);

    [Modifiers]
    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static BuildPlan lambda\u0024toRequests\u00249(
      [In] int obj0,
      [In] Schematic obj1,
      [In] int obj2,
      [In] Schematic.Stile obj3)
    {
      return new BuildPlan((int) obj3.x + obj0 - obj1.width / 2, (int) obj3.y + obj2 - obj1.height / 2, (int) (sbyte) obj3.rotation, obj3.block, obj3.config).original((int) obj3.x, (int) obj3.y, obj1.width, obj1.height);
    }

    [Modifiers]
    [LineNumberTable(280)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024toRequests\u002410([In] BuildPlan obj0) => !obj0.block.isVisible() && !(obj0.block is CoreBlock) || !obj0.block.unlockedNow();

    [Modifiers]
    [LineNumberTable(280)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024toRequests\u002411([In] BuildPlan obj0) => -obj0.block.schematicPriority;

    [Modifiers]
    [LineNumberTable(294)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkLoadout\u002412([In] Schematic.Stile obj0) => obj0.block is CoreBlock;

    [Modifiers]
    [LineNumberTable(295)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkLoadout\u002413([In] Schematic.Stile obj0) => obj0.block is CoreBlock;

    [Modifiers]
    [LineNumberTable(299)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkLoadout\u002414([In] Schematic.Stile obj0) => object.ReferenceEquals((object) obj0.block.buildVisibility, (object) BuildVisibility.__\u003C\u003EsandboxOnly) || !obj0.block.unlocked();

    [Modifiers]
    [LineNumberTable(323)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024remove\u002415([In] Schematic obj0, [In] CoreBlock obj1, [In] Seq obj2) => obj2.remove((object) obj0);

    [Modifiers]
    [LineNumberTable(423)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024placeLoadout\u002416([In] Schematic.Stile obj0) => obj0.block is CoreBlock;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 35, 66, 125, 164, 113, 103, 111, 114, 193, 151, 104, 104, 172, 110, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024placeLoadout\u002419(
      [In] int obj0,
      [In] int obj1,
      [In] bool obj2,
      [In] Seq obj3,
      [In] Team obj4,
      [In] Block obj5,
      [In] Schematic.Stile obj6)
    {
      int num = obj2 ? 1 : 0;
      Tile tile = Vars.world.tile((int) obj6.x + obj0, (int) obj6.y + obj1);
      if (tile == null)
        return;
      if (num != 0 && !(obj6.block is CoreBlock))
      {
        obj3.clear();
        tile.getLinkedTilesAs(obj6.block, obj3);
        if (obj3.contains((Boolf) new Schematics.__\u003C\u003EAnon25()))
          return;
      }
      tile.setBlock(obj6.block, obj4, (int) (sbyte) obj6.rotation);
      object config = obj6.config;
      if (tile.build != null)
        tile.build.configureAny(config);
      if (!(obj6.block is Drill))
        return;
      tile.getLinkedTiles((Cons) new Schematics.__\u003C\u003EAnon26(obj5));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 86, 123, 132, 148, 103, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024place\u002420(
      [In] int obj0,
      [In] int obj1,
      [In] Team obj2,
      [In] Schematic.Stile obj3)
    {
      Tile tile = Vars.world.tile((int) obj3.x + obj0, (int) obj3.y + obj1);
      if (tile == null)
        return;
      tile.setBlock(obj3.block, obj2, (int) (sbyte) obj3.rotation);
      object config = obj3.config;
      if (tile.build == null)
        return;
      tile.build.configureAny(config);
    }

    [Modifiers]
    [LineNumberTable(550)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024write\u002421([In] OrderedSet obj0, [In] Schematic.Stile obj1) => obj0.add((object) obj1.block);

    [Modifiers]
    [LineNumberTable(new byte[] {161, 237, 255, 3, 79, 127, 19, 98, 100, 99, 132, 98, 131, 124, 124, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rotated\u002423(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] Schematic.Stile obj3)
    {
      obj3.config = BuildPlan.pointConfig(obj3.block, obj3.config, (Cons) new Schematics.__\u003C\u003EAnon24(obj0));
      float num1 = (float) (((int) obj3.x - obj1) * 8) + obj3.block.offset;
      float num2 = (float) (((int) obj3.y - obj2) * 8) + obj3.block.offset;
      float num3 = num1;
      float num4;
      float num5;
      if (obj0 >= 0)
      {
        num4 = -num2;
        num5 = num3;
      }
      else
      {
        num4 = num2;
        num5 = -num3;
      }
      obj3.x = (short) (World.toTile(num4 - obj3.block.offset) + obj1);
      obj3.y = (short) (World.toTile(num5 - obj3.block.offset) + obj2);
      obj3.rotation = (byte) Mathf.mod((int) (sbyte) obj3.rotation + obj0, 4);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 238, 110, 130, 100, 99, 132, 98, 131, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rotated\u002422([In] int obj0, [In] Point2 obj1)
    {
      int x1 = obj1.x;
      int y1 = obj1.y;
      int num = x1;
      int x2;
      int y2;
      if (obj0 >= 0)
      {
        x2 = -y1;
        y2 = num;
      }
      else
      {
        x2 = y1;
        y2 = -num;
      }
      obj1.set(x2, y2);
    }

    [Modifiers]
    [LineNumberTable(435)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024placeLoadout\u002417([In] Tile obj0) => !obj0.block().alwaysReplace && !obj0.synthetic();

    [Modifiers]
    [LineNumberTable(448)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024placeLoadout\u002418([In] Block obj0, [In] Tile obj1) => obj1.setOverlay(obj0);

    [LineNumberTable(new byte[] {24, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadSync() => this.load();

    [LineNumberTable(new byte[] {59, 110, 118, 173, 108, 114, 108, 108, 113, 140, 118, 168, 255, 4, 69, 226, 60, 97, 127, 3, 102, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void overwrite(Schematic target, Schematic newSchematic)
    {
      if (this.previews.containsKey((object) target))
      {
        ((GLFrameBuffer) this.previews.get((object) target)).dispose();
        this.previews.remove((object) target);
      }
      target.__\u003C\u003Etiles.clear();
      target.__\u003C\u003Etiles.addAll(newSchematic.__\u003C\u003Etiles);
      target.width = newSchematic.width;
      target.height = newSchematic.height;
      newSchematic.tags.putAll((ObjectMap) target.tags);
      newSchematic.file = target.file;
      this.loadouts.each((Cons2) new Schematics.__\u003C\u003EAnon5(target));
      this.checkLoadout(target, true);
      Exception exception1;
      try
      {
        Schematics.write(newSchematic, target.file);
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
      Log.err("Failed to overwrite schematic '@' (@)", (object) newSchematic.name(), (object) target.file);
      Log.err((Exception) exception2);
      Vars.ui.showException((Exception) exception2);
    }

    [Signature("()Larc/struct/Seq<Lmindustry/game/Schematic;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq all() => this.all;

    [LineNumberTable(new byte[] {160, 67, 181, 127, 8, 97, 127, 3, 102, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture getPreview(Schematic schematic)
    {
      if (this.errored.contains((object) schematic))
        return this.errorTexture;
      Texture texture;
      Exception exception;
      try
      {
        texture = (Texture) this.getBuffer(schematic).getTexture();
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_5;
      }
      return texture;
label_5:
      Exception th = exception;
      Log.err("Failed to get preview for schematic '@' (@)", (object) schematic.name(), (object) schematic.file);
      Log.err(th);
      this.errored.add((object) schematic);
      return this.errorTexture;
    }

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasPreview(Schematic schematic) => this.previews.containsKey((object) schematic);

    [Signature("(Lmindustry/game/Schematic;II)Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;")]
    [LineNumberTable(new byte[] {160, 165, 127, 3, 57})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq toRequests(Schematic schem, int x, int y) => schem.__\u003C\u003Etiles.map((Func) new Schematics.__\u003C\u003EAnon10(x, schem, y)).removeAll((Boolf) new Schematics.__\u003C\u003EAnon11()).sort(Structs.comparingInt((Intf) new Schematics.__\u003C\u003EAnon12()));

    [Signature("(Lmindustry/world/blocks/storage/CoreBlock;)Larc/struct/Seq<Lmindustry/game/Schematic;>;")]
    [LineNumberTable(285)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getLoadouts(CoreBlock block) => (Seq) this.loadouts.get((object) block, (Prov) new Schematics.__\u003C\u003EAnon13());

    [Signature("()Larc/struct/ObjectMap<Lmindustry/world/blocks/storage/CoreBlock;Larc/struct/Seq<Lmindustry/game/Schematic;>;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap getLoadouts() => this.loadouts;

    [LineNumberTable(new byte[] {160, 193, 140, 127, 20, 103, 222, 226, 61, 97, 107, 166, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Schematic schematic)
    {
      this.all.add((object) schematic);
      Exception exception1;
      try
      {
        Fi file = Vars.schematicDirectory.child(new StringBuilder().append(Time.millis()).append(".").append("msch").toString());
        Schematics.write(schematic, file);
        schematic.file = file;
        goto label_6;
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
      Vars.ui.showException((Exception) exception2);
      Log.err((Exception) exception2);
label_6:
      this.checkLoadout(schematic, true);
      this.all.sort();
    }

    [LineNumberTable(new byte[] {160, 208, 109, 118, 104, 172, 110, 118, 141, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(Schematic s)
    {
      this.all.remove((object) s);
      this.loadouts.each((Cons2) new Schematics.__\u003C\u003EAnon17(s));
      if (s.file != null)
        s.file.delete();
      if (this.previews.containsKey((object) s))
      {
        ((GLFrameBuffer) this.previews.get((object) s)).dispose();
        this.previews.remove((object) s);
      }
      this.all.sort();
    }

    [LineNumberTable(new byte[] {160, 223, 111, 104, 104, 104, 136, 138, 135, 109, 99, 107, 108, 112, 159, 31, 124, 107, 127, 16, 115, 115, 115, 115, 227, 53, 43, 235, 81, 100, 100, 100, 100, 134, 178, 111, 104, 103, 107, 108, 112, 159, 31, 124, 115, 159, 24, 127, 13, 239, 55, 43, 235, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Schematic create(int x, int y, int x2, int y2)
    {
      Placement.NormalizeResult normalizeResult = Placement.normalizeArea(x, y, x2, y2, 0, false, 32);
      x = normalizeResult.x;
      y = normalizeResult.y;
      x2 = normalizeResult.x2;
      y2 = normalizeResult.y2;
      int num1 = x;
      int num2 = y;
      int num3 = x2;
      int num4 = y2;
      Seq tiles = new Seq();
      int num5 = x2;
      int num6 = y2;
      int num7 = x;
      int num8 = y;
      int num9 = 0;
      for (int x1 = x; x1 <= x2; ++x1)
      {
        for (int y1 = y; y1 <= y2; ++y1)
        {
          Building building1 = Vars.world.build(x1, y1);
          Block block1;
          if (building1 == null)
          {
            block1 = (Block) null;
          }
          else
          {
            Building building2 = building1;
            ConstructBlock.ConstructBuild constructBuild;
            block1 = !(building2 is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) building2), (object) (ConstructBlock.ConstructBuild) building2) ? building1.block : constructBuild.cblock;
          }
          Block block2 = block1;
          if (building1 != null && (block2.isVisible() || block2 is CoreBlock))
          {
            int num10 = block2.size / 2;
            int size = block2.size;
            int num11 = 2;
            int num12 = (num11 != -1 ? size % num11 : 0) != 1 ? -(block2.size - 1) / 2 : -block2.size / 2;
            num5 = Math.min(building1.tileX() + num12, num5);
            num6 = Math.min(building1.tileY() + num12, num6);
            num7 = Math.max(building1.tileX() + num10, num7);
            num8 = Math.max(building1.tileY() + num10, num8);
            num9 = 1;
          }
        }
      }
      if (num9 == 0)
        return new Schematic(new Seq(), new StringMap(), 1, 1);
      x = num5;
      y = num6;
      x2 = num7;
      y2 = num8;
      int width = x2 - x + 1;
      int height = y2 - y + 1;
      int num13 = -x;
      int num14 = -y;
      IntSet intSet = new IntSet();
      for (int x1 = num1; x1 <= num3; ++x1)
      {
        for (int y1 = num2; y1 <= num4; ++y1)
        {
          Building building1 = Vars.world.build(x1, y1);
          Block block1;
          if (building1 == null)
          {
            block1 = (Block) null;
          }
          else
          {
            Building building2 = building1;
            ConstructBlock.ConstructBuild constructBuild;
            block1 = !(building2 is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) building2), (object) (ConstructBlock.ConstructBuild) building2) ? building1.block : constructBuild.cblock;
          }
          Block block2 = block1;
          if (building1 != null && !intSet.contains(building1.pos()) && (block2.isVisible() || block2 is CoreBlock))
          {
            Building building2 = building1;
            ConstructBlock.ConstructBuild constructBuild;
            object config = !(building2 is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) building2), (object) (ConstructBlock.ConstructBuild) building2) ? building1.config() : constructBuild.lastConfig;
            tiles.add((object) new Schematic.Stile(block2, building1.tileX() + num13, building1.tileY() + num14, config, (byte) building1.rotation));
            intSet.add(building1.pos());
          }
        }
      }
      return new Schematic(tiles, new StringMap(), width, height);
    }

    [LineNumberTable(new byte[] {161, 29, 107, 108, 127, 23, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string writeBase64(Schematic schematic)
    {
      string str;
      IOException ioException1;
      try
      {
        this.@out.reset();
        Schematics.write(schematic, (OutputStream) this.@out);
        str = String.newhelper(Base64Coder.encode(this.@out.getBuffer(), this.@out.size()));
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return str;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {161, 84, 118, 248, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void place(Schematic schem, int x, int y, Team team)
    {
      int num1 = x - schem.width / 2;
      int num2 = y - schem.height / 2;
      schem.__\u003C\u003Etiles.each((Cons) new Schematics.__\u003C\u003EAnon20(num1, num2, team));
    }

    [LineNumberTable(new byte[] {159, 131, 141, 118, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Schematics()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.game.Schematics"))
        return;
      Schematics.tmpSchem = new Schematic(new Seq(), new StringMap(), 0, 0);
      Schematics.tmpSchem2 = new Schematic(new Seq(), new StringMap(), 0, 0);
      Schematics.header = new byte[4]
      {
        (byte) 109,
        (byte) 115,
        (byte) 99,
        (byte) 104
      };
    }

    [HideFromJava]
    public virtual void loadAsync() => Loadable.\u003Cdefault\u003EloadAsync((Loadable) this);

    [HideFromJava]
    public virtual string getName() => Loadable.\u003Cdefault\u003EgetName((Loadable) this);

    [HideFromJava]
    public virtual Seq getDependencies() => Loadable.\u003Cdefault\u003EgetDependencies((Loadable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Schematics arg\u00241;

      internal __\u003C\u003EAnon0([In] Schematics obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Schematics arg\u00241;

      internal __\u003C\u003EAnon1([In] Schematics obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.loadFile((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons2
    {
      private readonly Schematics arg\u00241;

      internal __\u003C\u003EAnon2([In] Schematics obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024load\u00241((Mods.LoadedMod) obj0, (Fi) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly Schematics arg\u00241;

      internal __\u003C\u003EAnon3([In] Schematics obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024load\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly Schematics arg\u00241;

      internal __\u003C\u003EAnon4([In] Schematics obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024loadLoadouts\u00243((Schematic) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons2
    {
      private readonly Schematic arg\u00241;

      internal __\u003C\u003EAnon5([In] Schematic obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => Schematics.lambda\u0024overwrite\u00244(this.arg\u00241, (CoreBlock) obj0, (Seq) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void get([In] object obj0) => Schematics.lambda\u0024getBuffer\u00245((Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Func
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public object get([In] object obj0) => (object) Schematics.lambda\u0024getBuffer\u00246((Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon8([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Schematics.lambda\u0024getBuffer\u00247(this.arg\u00241, (BuildPlan) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon9([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Schematics.lambda\u0024getBuffer\u00248(this.arg\u00241, (BuildPlan) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Func
    {
      private readonly int arg\u00241;
      private readonly Schematic arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon10([In] int obj0, [In] Schematic obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public object get([In] object obj0) => (object) Schematics.lambda\u0024toRequests\u00249(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Boolf
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public bool get([In] object obj0) => (Schematics.lambda\u0024toRequests\u002410((BuildPlan) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Intf
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public int get([In] object obj0) => Schematics.lambda\u0024toRequests\u002411((BuildPlan) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Prov
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public object get() => (object) new Seq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Boolf
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public bool get([In] object obj0) => (Schematics.lambda\u0024checkLoadout\u002412((Schematic.Stile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Boolf
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public bool get([In] object obj0) => (Schematics.lambda\u0024checkLoadout\u002413((Schematic.Stile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Boolf
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public bool get([In] object obj0) => (Schematics.lambda\u0024checkLoadout\u002414((Schematic.Stile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons2
    {
      private readonly Schematic arg\u00241;

      internal __\u003C\u003EAnon17([In] Schematic obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => Schematics.lambda\u0024remove\u002415(this.arg\u00241, (CoreBlock) obj0, (Seq) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Boolf
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public bool get([In] object obj0) => (Schematics.lambda\u0024placeLoadout\u002416((Schematic.Stile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Cons
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;
      private readonly bool arg\u00243;
      private readonly Seq arg\u00244;
      private readonly Team arg\u00245;
      private readonly Block arg\u00246;

      internal __\u003C\u003EAnon19(
        [In] int obj0,
        [In] int obj1,
        [In] bool obj2,
        [In] Seq obj3,
        [In] Team obj4,
        [In] Block obj5)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
      }

      public void get([In] object obj0) => Schematics.lambda\u0024placeLoadout\u002419(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, (Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;
      private readonly Team arg\u00243;

      internal __\u003C\u003EAnon20([In] int obj0, [In] int obj1, [In] Team obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => Schematics.lambda\u0024place\u002420(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Cons
    {
      private readonly OrderedSet arg\u00241;

      internal __\u003C\u003EAnon21([In] OrderedSet obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Schematics.lambda\u0024write\u002421(this.arg\u00241, (Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Prov
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public object get() => (object) new Schematic.Stile();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Cons
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;
      private readonly int arg\u00243;

      internal __\u003C\u003EAnon23([In] int obj0, [In] int obj1, [In] int obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => Schematics.lambda\u0024rotated\u002423(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Schematic.Stile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      private readonly int arg\u00241;

      internal __\u003C\u003EAnon24([In] int obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Schematics.lambda\u0024rotated\u002422(this.arg\u00241, (Point2) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Boolf
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public bool get([In] object obj0) => (Schematics.lambda\u0024placeLoadout\u002417((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Cons
    {
      private readonly Block arg\u00241;

      internal __\u003C\u003EAnon26([In] Block obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Schematics.lambda\u0024placeLoadout\u002418(this.arg\u00241, (Tile) obj0);
    }
  }
}
