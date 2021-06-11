// Decompiled with JetBrains decompiler
// Type: mindustry.io.SaveVersion
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.maps;
using mindustry.type;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.io
{
  public abstract class SaveVersion : SaveFileReader
  {
    public int version;
    protected internal int lastReadBuild;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 90, 103, 135, 135, 169, 168, 107, 123, 104, 104, 104, 159, 5, 144, 111, 125, 16, 232, 69, 229, 50, 233, 82, 239, 115, 236, 14, 114, 105, 107, 99, 105, 108, 140, 100, 200, 100, 169, 100, 100, 137, 255, 6, 70, 245, 87, 252, 39, 98, 255, 18, 88, 225, 44, 245, 84, 227, 47, 243, 81, 230, 49, 100, 105, 144, 136, 111, 47, 200, 242, 69, 227, 13, 241, 115, 38, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readMap(DataInput stream, WorldContext context)
    {
      int i1_1 = stream.readUnsignedShort();
      int i2_1 = stream.readUnsignedShort();
      int num1 = context.isGenerating() ? 1 : 0;
      if (num1 == 0)
        context.begin();
      int i1;
      int num2;
      // ISSUE: fault handler
      try
      {
        context.resize(i1_1, i2_1);
        for (i1 = 0; i1 < i1_1 * i2_1; ++i1)
        {
          int num3 = i1;
          int num4 = i1_1;
          int i1_2 = num4 != -1 ? num3 % num4 : 0;
          int num5 = i1;
          int num6 = i1_1;
          int i2_2 = num6 != -1 ? num5 / num6 : -num5;
          int num7 = (int) stream.readShort();
          int i4 = (int) stream.readShort();
          int num8 = stream.readUnsignedByte();
          if (object.ReferenceEquals((object) Vars.content.block(num7), (object) Blocks.air))
            num7 = (int) Blocks.stone.__\u003C\u003Eid;
          context.create(i1_2, i2_2, num7, i4, 0);
          for (num2 = i1 + 1; num2 < i1 + 1 + num8; ++num2)
          {
            int num9 = num2;
            int num10 = i1_1;
            int i1_3 = num10 != -1 ? num9 % num10 : 0;
            int num11 = num2;
            int num12 = i1_1;
            int i2_3 = num12 != -1 ? num11 / num12 : -num11;
            context.create(i1_3, i2_3, num7, i4, 0);
          }
          i1 += num8;
        }
        i1 = 0;
      }
      __fault
      {
        if (num1 == 0)
          context.end();
      }
      Block type;
      Exception exception1;
      while (true)
      {
        Tile tile;
        // ISSUE: fault handler
        try
        {
          if (i1 < i1_1 * i2_1)
          {
            type = Vars.content.block((int) stream.readShort());
            tile = context.tile(i1);
            if (type == null)
              type = Blocks.air;
            int num3 = 1;
            int num4 = (int) (sbyte) stream.readByte();
            int num5 = (num4 & 1) == 0 ? 0 : 1;
            num2 = (num4 & 2) == 0 ? 0 : 1;
            if (num5 != 0)
              num3 = stream.readBoolean() ? 1 : 0;
            if (num3 != 0)
              tile.setBlock(type);
            if (num5 != 0)
            {
              if (num3 != 0)
              {
                if (type.hasBuilding())
                {
                  try
                  {
                    this.readChunk(stream, true, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon9(tile));
                    goto label_38;
                  }
                  catch (Exception ex)
                  {
                    exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                    break;
                  }
                }
              }
              else
                goto label_51;
            }
            else
              goto label_42;
          }
          else
            goto label_56;
        }
        __fault
        {
          if (num1 == 0)
            context.end();
        }
        // ISSUE: fault handler
        try
        {
          this.skipChunk(stream, true);
        }
        __fault
        {
          if (num1 == 0)
            context.end();
        }
label_38:
        // ISSUE: fault handler
        try
        {
          context.onReadBuilding();
          goto label_51;
        }
        __fault
        {
          if (num1 == 0)
            context.end();
        }
label_42:
        // ISSUE: fault handler
        try
        {
          if (num2 != 0)
          {
            tile.setBlock(type);
            tile.data = stream.readByte();
          }
          else
          {
            int num3 = stream.readUnsignedByte();
            for (int i2 = i1 + 1; i2 < i1 + 1 + num3; ++i2)
              context.tile(i2).setBlock(type);
            i1 += num3;
          }
        }
        __fault
        {
          if (num1 == 0)
            context.end();
        }
label_51:
        // ISSUE: fault handler
        try
        {
          ++i1;
        }
        __fault
        {
          if (num1 == 0)
            context.end();
        }
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string str = new StringBuilder().append("Failed to read tile entity of block: ").append((object) type).toString();
        Exception exception4 = exception3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str, exception4);
      }
      __fault
      {
        if (num1 == 0)
          context.end();
      }
label_56:
      if (num1 != 0)
        return;
      context.end();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 240, 136, 159, 10, 107, 111, 104, 144, 105, 104, 31, 12, 232, 59, 235, 75, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readContentHeader(DataInput stream)
    {
      int num1 = (int) (sbyte) stream.readByte();
      int length1 = ContentType.__\u003C\u003Eall.Length;
      int[] numArray = new int[2];
      int num2 = 0;
      numArray[1] = num2;
      int num3 = length1;
      numArray[0] = num3;
      // ISSUE: type reference
      MappableContent[][] temporaryMapper = (MappableContent[][]) ByteCodeHelper.multianewarray(__typeref (MappableContent[][]), numArray);
      for (int index1 = 0; index1 < num1; ++index1)
      {
        ContentType type = ContentType.__\u003C\u003Eall[(int) (sbyte) stream.readByte()];
        int length2 = (int) stream.readShort();
        temporaryMapper[type.ordinal()] = new MappableContent[length2];
        for (int index2 = 0; index2 < length2; ++index2)
        {
          string str = stream.readUTF();
          temporaryMapper[type.ordinal()][index2] = Vars.content.getByName(type, (string) SaveFileReader.__\u003C\u003Efallback.get((object) str, (object) str));
        }
      }
      Vars.content.setTemporaryMapper(temporaryMapper);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 175, 103, 104, 102, 107, 107, 107, 107, 112, 117, 250, 57})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SaveMeta getMeta(DataInput stream)
    {
      stream.readInt();
      StringMap tags = this.readStringMap(stream);
      return new SaveMeta(tags.getInt("version"), tags.getLong("saved"), tags.getLong("playtime"), tags.getInt("build"), (string) tags.get((object) "mapname"), tags.getInt("wave"), (Rules) JsonIO.read((Class) ClassLiteral<Rules>.Value, (string) tags.get((object) "rules", (object) "{}")), tags);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 191, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void write(DataOutputStream stream) => this.write(stream, new StringMap());

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {16, 120, 119, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void write(DataOutputStream stream, StringMap extraTags)
    {
      this.region("meta", (DataOutput) stream, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon4(this, extraTags));
      this.region("content", (DataOutput) stream, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon5(this));
      this.region("map", (DataOutput) stream, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon6(this));
      this.region("entities", (DataOutput) stream, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon7(this));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {4, 120, 184, 121, 156, 107, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void read(
      DataInputStream stream,
      CounterInputStream counter,
      WorldContext context)
    {
      this.region("meta", (DataInput) stream, counter, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon0(this));
      this.region("content", (DataInput) stream, counter, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon1(this));
      try
      {
        this.region("map", (DataInput) stream, counter, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon2(this, context));
        this.region("entities", (DataInput) stream, counter, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon3(this));
      }
      finally
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {24, 108, 121, 212, 127, 0, 102, 130, 115, 117, 127, 16, 122, 123, 124, 124, 124, 119, 127, 7, 124, 124, 127, 30, 127, 48, 124, 255, 19, 49, 230, 80, 229, 48, 229, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeMeta(DataOutput stream, StringMap tags)
    {
      if (Vars.state.isCampaign())
      {
        Vars.state.rules.sector.info.prepare();
        Vars.state.rules.sector.saveInfo();
      }
      Iterator iterator = TechTree.all.iterator();
      while (iterator.hasNext())
        ((TechTree.TechNode) iterator.next()).save();
      DataOutput stream1 = stream;
      object[] objArray = new object[30]
      {
        (object) "saved",
        (object) Long.valueOf(Time.millis()),
        (object) "playtime",
        (object) Long.valueOf(!Vars.headless ? Vars.control.saves.getTotalPlaytime() : 0L),
        (object) "build",
        (object) Integer.valueOf(mindustry.core.Version.build),
        (object) "mapname",
        (object) Vars.state.map.name(),
        (object) "wave",
        (object) Integer.valueOf(Vars.state.wave),
        (object) "wavetime",
        (object) Float.valueOf(Vars.state.wavetime),
        (object) "stats",
        (object) JsonIO.write((object) Vars.state.stats),
        (object) "rules",
        (object) JsonIO.write((object) Vars.state.rules),
        (object) "mods",
        (object) JsonIO.write((object) Vars.mods.getModStrings().toArray((Class) ClassLiteral<String>.Value)),
        (object) "width",
        (object) Integer.valueOf(Vars.world.width()),
        (object) "height",
        (object) Integer.valueOf(Vars.world.height()),
        (object) "viewpos",
        null,
        null,
        null,
        null,
        null,
        null,
        null
      };
      Vec2 v1 = Tmp.__\u003C\u003Ev1;
      Object @object = Vars.player != null ? (Object) Vars.player : (Object) Vec2.__\u003C\u003EZERO;
      Position v;
      if (@object != null)
        v = @object is Position position2 ? position2 : throw new IncompatibleClassChangeError();
      else
        v = (Position) null;
      objArray[23] = (object) v1.set(v).toString();
      objArray[24] = (object) "controlledType";
      objArray[25] = Vars.headless || Vars.control.input.controlledType == null ? (object) "null" : (object) Vars.control.input.controlledType.__\u003C\u003Ename;
      objArray[26] = (object) "nocores";
      objArray[27] = (object) Boolean.valueOf(Vars.state.rules.defaultTeam.cores().isEmpty());
      objArray[28] = (object) "playerteam";
      objArray[29] = (object) Integer.valueOf(Vars.player != null ? Vars.player.team().__\u003C\u003Eid : Vars.state.rules.defaultTeam.__\u003C\u003Eid);
      ObjectMap map = StringMap.of(objArray).merge((ObjectMap) tags);
      this.writeStringMap(stream1, map);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {54, 136, 117, 127, 6, 127, 15, 127, 15, 127, 16, 146, 106, 123, 117, 143, 127, 25, 127, 6, 121, 203, 127, 1, 127, 4, 113, 113, 230, 61, 204, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readMeta(DataInput stream)
    {
      StringMap stringMap = this.readStringMap(stream);
      Vars.state.wave = stringMap.getInt("wave");
      Vars.state.wavetime = stringMap.getFloat("wavetime", Vars.state.rules.waveSpacing);
      Vars.state.stats = (GameStats) JsonIO.read((Class) ClassLiteral<GameStats>.Value, (string) stringMap.get((object) "stats", (object) "{}"));
      Vars.state.rules = (Rules) JsonIO.read((Class) ClassLiteral<Rules>.Value, (string) stringMap.get((object) "rules", (object) "{}"));
      if (Vars.state.rules.spawns.isEmpty())
        Vars.state.rules.spawns = Vars.waves.get();
      this.lastReadBuild = stringMap.getInt("build", -1);
      if (!Vars.headless)
      {
        Tmp.__\u003C\u003Ev1.tryFromString((string) stringMap.get((object) "viewpos"));
        Core.camera.__\u003C\u003Eposition.set(Tmp.__\u003C\u003Ev1);
        Vars.player.set((Position) Tmp.__\u003C\u003Ev1);
        Vars.control.input.controlledType = (UnitType) Vars.content.getByName(ContentType.__\u003C\u003Eunit, (string) stringMap.get((object) "controlledType", (object) "<none>"));
        Team team = Team.get(stringMap.getInt("playerteam", Vars.state.rules.defaultTeam.__\u003C\u003Eid));
        if (!Vars.net.client() && !object.ReferenceEquals((object) team, (object) Team.__\u003C\u003Ederelict))
          Vars.player.team(team);
      }
      Map map1 = Vars.maps.byName((string) stringMap.get((object) "mapname", (object) "\\\\\\"));
      GameState state = Vars.state;
      Map map2;
      if (map1 == null)
        map2 = new Map(StringMap.of(new object[6]
        {
          (object) "name",
          stringMap.get((object) "mapname", (object) "Unknown"),
          (object) "width",
          (object) Integer.valueOf(1),
          (object) "height",
          (object) Integer.valueOf(1)
        }));
      else
        map2 = map1;
      state.map = map2;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024read\u00240([In] WorldContext obj0, [In] DataInput obj1) => this.readMap(obj1, obj0);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 202, 135, 105, 108, 103, 104, 107, 119, 104, 135, 108, 127, 1, 137, 114, 255, 10, 59, 235, 55, 233, 83, 103, 104, 52, 232, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readEntities(DataInput stream)
    {
      int num1 = stream.readInt();
      for (int index1 = 0; index1 < num1; ++index1)
      {
        Teams.TeamData teamData = Team.get(stream.readInt()).data();
        int num2 = stream.readInt();
        teamData.blocks.clear();
        teamData.blocks.ensureCapacity(Math.min(num2, 1000));
        Reads read = Reads.get(stream);
        IntSet intSet = new IntSet();
        for (int index2 = 0; index2 < num2; ++index2)
        {
          int x = (int) stream.readShort();
          int y = (int) stream.readShort();
          int num3 = (int) stream.readShort();
          int id = (int) stream.readShort();
          object config = TypeIO.readObject(read);
          if (intSet.add(Point2.pack(x, y)))
            teamData.blocks.addLast((object) new Teams.BlockPlan(x, y, (short) num3, Vars.content.block(id).__\u003C\u003Eid, config));
        }
      }
      int num4 = stream.readInt();
      for (int index = 0; index < num4; ++index)
        this.readChunk(stream, true, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon12(this));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024write\u00241([In] StringMap obj0, [In] DataOutput obj1) => this.writeMeta(obj1, obj0);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 3, 139, 98, 115, 120, 4, 232, 70, 103, 118, 123, 124, 109, 127, 1, 114, 226, 58, 235, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeContentHeader(DataOutput stream)
    {
      Seq[] contentMap = Vars.content.getContentMap();
      int num = 0;
      Seq[] seqArray1 = contentMap;
      int length1 = seqArray1.Length;
      for (int index = 0; index < length1; ++index)
      {
        Seq seq = seqArray1[index];
        if (seq.size > 0 && seq.first() is MappableContent)
          ++num;
      }
      stream.writeByte(num);
      Seq[] seqArray2 = contentMap;
      int length2 = seqArray2.Length;
      for (int index = 0; index < length2; ++index)
      {
        Seq seq = seqArray2[index];
        if (seq.size > 0 && seq.first() is MappableContent)
        {
          stream.writeByte(((Content) seq.first()).getContentType().ordinal());
          stream.writeShort(seq.size);
          Iterator iterator = seq.iterator();
          while (iterator.hasNext())
          {
            Content content = (Content) iterator.next();
            stream.writeUTF(((MappableContent) content).__\u003C\u003Ename);
          }
        }
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {85, 112, 176, 125, 127, 21, 108, 108, 130, 127, 11, 159, 22, 126, 162, 228, 57, 233, 74, 103, 228, 47, 233, 85, 125, 127, 21, 140, 108, 182, 167, 104, 104, 103, 248, 69, 140, 99, 178, 131, 127, 14, 159, 24, 111, 162, 230, 57, 235, 74, 104, 229, 26, 233, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeMap(DataOutput stream)
    {
      stream.writeShort(Vars.world.width());
      stream.writeShort(Vars.world.height());
      int num1;
      for (int index1 = 0; index1 < Vars.world.width() * Vars.world.height(); index1 = index1 + num1 + 1)
      {
        World world1 = Vars.world;
        int num2 = index1;
        int num3 = Vars.world.width();
        int x1 = num3 != -1 ? num2 % num3 : 0;
        int num4 = index1;
        int num5 = Vars.world.width();
        int y1 = num5 != -1 ? num4 / num5 : -num4;
        Tile tile1 = world1.rawTile(x1, y1);
        stream.writeShort((int) tile1.floorID());
        stream.writeShort((int) tile1.overlayID());
        num1 = 0;
        for (int index2 = index1 + 1; index2 < Vars.world.width() * Vars.world.height() && num1 < (int) byte.MaxValue; ++index2)
        {
          World world2 = Vars.world;
          int num6 = index2;
          int num7 = Vars.world.width();
          int x2 = num7 != -1 ? num6 % num7 : 0;
          int num8 = index2;
          int num9 = Vars.world.width();
          int y2 = num9 != -1 ? num8 / num9 : -num8;
          Tile tile2 = world2.rawTile(x2, y2);
          if ((int) tile2.floorID() == (int) tile1.floorID() && (int) tile2.overlayID() == (int) tile1.overlayID())
            ++num1;
          else
            break;
        }
        stream.writeByte(num1);
      }
      for (int index1 = 0; index1 < Vars.world.width() * Vars.world.height(); ++index1)
      {
        World world1 = Vars.world;
        int num2 = index1;
        int num3 = Vars.world.width();
        int x1 = num3 != -1 ? num2 % num3 : 0;
        int num4 = index1;
        int num5 = Vars.world.width();
        int y1 = num5 != -1 ? num4 / num5 : -num4;
        Tile tile = world1.rawTile(x1, y1);
        stream.writeShort((int) tile.blockID());
        int num6 = tile.block().saveData ? 1 : 0;
        int num7 = (int) (sbyte) ((tile.build == null ? 0 : 1) | (num6 == 0 ? 0 : 2));
        stream.writeByte(num7);
        if (tile.build != null)
        {
          if (tile.isCenter())
          {
            stream.writeBoolean(true);
            this.writeChunk(stream, true, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon8(tile));
          }
          else
            stream.writeBoolean(false);
        }
        else if (num6 != 0)
        {
          stream.writeByte((int) (sbyte) tile.data);
        }
        else
        {
          int num8 = 0;
          for (int index2 = index1 + 1; index2 < Vars.world.width() * Vars.world.height() && num8 < (int) byte.MaxValue; ++index2)
          {
            World world2 = Vars.world;
            int num9 = index2;
            int num10 = Vars.world.width();
            int x2 = num10 != -1 ? num9 % num10 : 0;
            int num11 = index2;
            int num12 = Vars.world.width();
            int y2 = num12 != -1 ? num11 / num12 : -num11;
            if ((int) world2.rawTile(x2, y2).blockID() == (int) tile.blockID())
              ++num8;
            else
              break;
          }
          stream.writeByte(num8);
          index1 += num8;
        }
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 175, 117, 127, 3, 108, 126, 113, 113, 127, 2, 109, 109, 109, 109, 114, 98, 133, 122, 127, 1, 139, 212, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeEntities(DataOutput stream)
    {
      Seq seq = Vars.state.teams.getActive().copy();
      if (!seq.contains((object) Team.__\u003C\u003Esharded.data()))
        seq.add((object) Team.__\u003C\u003Esharded.data());
      stream.writeInt(seq.size);
      Iterator iterator1 = seq.iterator();
label_3:
      while (iterator1.hasNext())
      {
        Teams.TeamData teamData = (Teams.TeamData) iterator1.next();
        stream.writeInt(teamData.__\u003C\u003Eteam.__\u003C\u003Eid);
        stream.writeInt(teamData.blocks.size);
        Iterator iterator2 = teamData.blocks.iterator();
        while (true)
        {
          if (iterator2.hasNext())
          {
            Teams.BlockPlan blockPlan = (Teams.BlockPlan) iterator2.next();
            stream.writeShort((int) blockPlan.__\u003C\u003Ex);
            stream.writeShort((int) blockPlan.__\u003C\u003Ey);
            stream.writeShort((int) blockPlan.__\u003C\u003Erotation);
            stream.writeShort((int) blockPlan.__\u003C\u003Eblock);
            TypeIO.writeObject(Writes.get(stream), blockPlan.__\u003C\u003Econfig);
          }
          else
            goto label_3;
        }
      }
      stream.writeInt(Groups.all.count((Boolf) new SaveVersion.__\u003C\u003EAnon10()));
      Iterator iterator3 = Groups.all.iterator();
      while (iterator3.hasNext())
      {
        Entityc entityc = (Entityc) iterator3.next();
        if (entityc.serialize())
          this.writeChunk(stream, true, (SaveFileReader.IORunner) new SaveVersion.__\u003C\u003EAnon11(entityc));
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(new byte[] {125, 114, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024writeMap\u00242([In] Tile obj0, [In] DataOutput obj1)
    {
      obj1.writeByte((int) (sbyte) obj0.build.version());
      obj0.build.writeAll(Writes.get(obj1));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(new byte[] {160, 142, 104, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024readMap\u00243([In] Tile obj0, [In] DataInput obj1)
    {
      int num = (int) (sbyte) obj1.readByte();
      obj0.build.readAll(Reads.get(obj1), (byte) num);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(new byte[] {160, 195, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024writeEntities\u00244([In] Entityc obj0, [In] DataOutput obj1)
    {
      obj1.writeByte(obj0.classId());
      obj0.write(Writes.get(obj1));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(new byte[] {160, 226, 104, 104, 111, 161, 113, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024readEntities\u00245([In] DataInput obj0)
    {
      int id = (int) (sbyte) obj0.readByte();
      if (EntityMapping.map(id) == null)
      {
        obj0.skipBytes(this.lastRegionLength - 1);
      }
      else
      {
        Entityc entityc = (Entityc) EntityMapping.map(id).get();
        entityc.read(Reads.get(obj0));
        entityc.add();
      }
    }

    [LineNumberTable(new byte[] {159, 170, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SaveVersion(int version)
    {
      SaveVersion saveVersion = this;
      this.version = version;
    }

    [HideFromJava]
    static SaveVersion() => SaveFileReader.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;

      internal __\u003C\u003EAnon0([In] SaveVersion obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => this.arg\u00241.readMeta((DataInput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;

      internal __\u003C\u003EAnon1([In] SaveVersion obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => this.arg\u00241.readContentHeader((DataInput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;
      private readonly WorldContext arg\u00242;

      internal __\u003C\u003EAnon2([In] SaveVersion obj0, [In] WorldContext obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void accept([In] object obj0) => this.arg\u00241.lambda\u0024read\u00240(this.arg\u00242, (DataInput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;

      internal __\u003C\u003EAnon3([In] SaveVersion obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => this.arg\u00241.readEntities((DataInput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;
      private readonly StringMap arg\u00242;

      internal __\u003C\u003EAnon4([In] SaveVersion obj0, [In] StringMap obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void accept([In] object obj0) => this.arg\u00241.lambda\u0024write\u00241(this.arg\u00242, (DataOutput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;

      internal __\u003C\u003EAnon5([In] SaveVersion obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => this.arg\u00241.writeContentHeader((DataOutput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;

      internal __\u003C\u003EAnon6([In] SaveVersion obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => this.arg\u00241.writeMap((DataOutput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;

      internal __\u003C\u003EAnon7([In] SaveVersion obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => this.arg\u00241.writeEntities((DataOutput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : SaveFileReader.IORunner
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon8([In] Tile obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => SaveVersion.lambda\u0024writeMap\u00242(this.arg\u00241, (DataOutput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : SaveFileReader.IORunner
    {
      private readonly Tile arg\u00241;

      internal __\u003C\u003EAnon9([In] Tile obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => SaveVersion.lambda\u0024readMap\u00243(this.arg\u00241, (DataInput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Boolf
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public bool get([In] object obj0) => (((Entityc) obj0).serialize() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : SaveFileReader.IORunner
    {
      private readonly Entityc arg\u00241;

      internal __\u003C\u003EAnon11([In] Entityc obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => SaveVersion.lambda\u0024writeEntities\u00244(this.arg\u00241, (DataOutput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;

      internal __\u003C\u003EAnon12([In] SaveVersion obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => this.arg\u00241.lambda\u0024readEntities\u00245((DataInput) obj0);
    }
  }
}
