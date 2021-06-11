// Decompiled with JetBrains decompiler
// Type: mindustry.io.MapIO
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.graphics;
using arc.math.geom;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.zip;
using mindustry.content;
using mindustry.ctype;
using mindustry.game;
using mindustry.maps;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.storage;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.io
{
  public class MapIO : Object
  {
    [Modifiers]
    private static int[] pngHeader;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 70, 126, 124, 135, 104, 110, 104, 143, 135, 165, 126, 127, 11, 127, 0, 127, 5, 119, 109, 226, 60, 235, 74, 114, 144, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void readImage(Pixmap pixmap, Tiles tiles)
    {
      Iterator iterator1 = tiles.iterator();
      while (iterator1.hasNext())
      {
        Tile tile = (Tile) iterator1.next();
        Block type = ColorMapper.get(pixmap.getPixel((int) tile.x, pixmap.getHeight() - 1 - (int) tile.y));
        if (type.isFloor())
          tile.setFloor(type.asFloor());
        else if (type.isMultiblock())
          tile.setBlock(type, Team.__\u003C\u003Ederelict, 0);
        else
          tile.setBlock(type);
      }
      Iterator iterator2 = tiles.iterator();
      while (iterator2.hasNext())
      {
        Tile tile1 = (Tile) iterator2.next();
        if (object.ReferenceEquals((object) tile1.floor(), (object) Blocks.air) && !object.ReferenceEquals((object) tile1.block(), (object) Blocks.air))
        {
          Point2[] d4 = Geometry.__\u003C\u003Ed4;
          int length = d4.Length;
          for (int index = 0; index < length; ++index)
          {
            Point2 point2 = d4[index];
            Tile tile2 = tiles.get((int) tile1.x + point2.x, (int) tile1.y + point2.y);
            if (tile2 != null && !object.ReferenceEquals((object) tile2.floor(), (object) Blocks.air))
            {
              tile1.setFloorUnder(tile2.floor());
              break;
            }
          }
        }
        if (object.ReferenceEquals((object) tile1.floor(), (object) Blocks.air))
          tile1.setFloorUnder((Floor) Blocks.stone);
      }
    }

    [LineNumberTable(new byte[] {13, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadMap(Map map, WorldContext cons) => SaveIO.load(map.__\u003C\u003Efile, cons);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 132, 66, 127, 0, 102, 104, 105, 103, 124, 127, 27, 63, 37, 235, 58})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Map createMap(Fi file, bool custom)
    {
      int num = custom ? 1 : 0;
      InflaterInputStream inflaterInputStream = new InflaterInputStream((InputStream) file.read(8192));
      CounterInputStream counter;
      DataInputStream dataInputStream;
      Map map;
      Exception exception1;
      Exception exception2;
      Exception exception3;
      try
      {
        counter = new CounterInputStream((InputStream) inflaterInputStream);
        try
        {
          dataInputStream = new DataInputStream((InputStream) counter);
          try
          {
            SaveIO.readHeader((DataInput) dataInputStream);
            int version = dataInputStream.readInt();
            SaveVersion saveWriter = SaveIO.getSaveWriter(version);
            StringMap tags = new StringMap();
            saveWriter.region("meta", (DataInput) dataInputStream, counter, (SaveFileReader.IORunner) new MapIO.__\u003C\u003EAnon0(tags, saveWriter));
            map = new Map(file, tags.getInt("width"), tags.getInt("height"), tags, num != 0, version, mindustry.core.Version.build);
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_9;
          }
          ((FilterInputStream) dataInputStream).close();
        }
        catch (Exception ex)
        {
          exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_10;
        }
        counter.close();
        goto label_12;
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_11;
      }
label_9:
      Exception exception4 = exception1;
      Exception exception5;
      Exception exception6;
      Exception exception7;
      Exception exception8;
      try
      {
        Exception exception9 = exception4;
        try
        {
          exception5 = exception9;
          try
          {
            ((FilterInputStream) dataInputStream).close();
            goto label_28;
          }
          catch (Exception ex)
          {
            exception6 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
        }
        catch (Exception ex)
        {
          exception7 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_20;
        }
      }
      catch (Exception ex)
      {
        exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_21;
      }
      Exception exception10 = exception6;
      Exception exception11;
      Exception exception12;
      try
      {
        Exception exception9 = exception10;
        try
        {
          Exception exception13 = exception9;
          Throwable.instancehelper_addSuppressed(exception5, exception13);
          goto label_28;
        }
        catch (Exception ex)
        {
          exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception12 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_27;
      }
      Exception exception14 = exception11;
      goto label_33;
label_27:
      Exception exception15 = exception12;
      goto label_46;
label_20:
      exception14 = exception7;
      goto label_33;
label_21:
      exception15 = exception8;
      goto label_46;
label_28:
      Exception exception16;
      Exception exception17;
      try
      {
        try
        {
          throw Throwable.__\u003Cunmap\u003E(exception5);
        }
        catch (Exception ex)
        {
          exception16 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception17 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_32;
      }
      exception14 = exception16;
      goto label_33;
label_32:
      exception15 = exception17;
      goto label_46;
label_10:
      exception14 = exception2;
      goto label_33;
label_11:
      exception15 = exception3;
      goto label_46;
label_12:
      ((InputStream) inflaterInputStream).close();
      return map;
label_33:
      Exception exception18 = exception14;
      Exception exception19;
      Exception exception20;
      Exception exception21;
      try
      {
        exception19 = exception18;
        try
        {
          counter.close();
          goto label_43;
        }
        catch (Exception ex)
        {
          exception20 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception21 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_39;
      }
      Exception exception22 = exception20;
      Exception exception23;
      try
      {
        Exception exception9 = exception22;
        Throwable.instancehelper_addSuppressed(exception19, exception9);
        goto label_43;
      }
      catch (Exception ex)
      {
        exception23 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception15 = exception23;
      goto label_46;
label_39:
      exception15 = exception21;
      goto label_46;
label_43:
      Exception exception24;
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception19);
      }
      catch (Exception ex)
      {
        exception24 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception15 = exception24;
label_46:
      Exception exception25 = exception15;
      Exception exception26;
      try
      {
        ((InputStream) inflaterInputStream).close();
        goto label_50;
      }
      catch (Exception ex)
      {
        exception26 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception27 = exception26;
      Throwable.instancehelper_addSuppressed(exception25, exception27);
label_50:
      throw Throwable.__\u003Cunmap\u003E(exception25);
    }

    [LineNumberTable(new byte[] {123, 114, 190, 127, 30, 124, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap writeImage(Tiles tiles)
    {
      Pixmap pixmap = new Pixmap(tiles.__\u003C\u003Ewidth, tiles.__\u003C\u003Eheight);
      Iterator iterator = tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        int color = !tile.block().hasColor || tile.block().synthetic() ? tile.floor().mapColor.rgba() : tile.block().mapColor.rgba();
        pixmap.draw((int) tile.x, tiles.__\u003C\u003Eheight - 1 - (int) tile.y, color);
      }
      return pixmap;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {2, 191, 4, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeMap(Fi file, Map map)
    {
      Exception exception1;
      try
      {
        SaveIO.write(file, map.__\u003C\u003Etags);
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
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException((Exception) exception2);
    }

    [LineNumberTable(new byte[] {159, 169, 105, 127, 20, 106, 215, 255, 3, 60, 3, 251, 69, 119, 55, 231, 58, 255, 50, 71, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isImage(Fi file)
    {
      BufferedInputStream bufferedInputStream;
      int[] pngHeader;
      int length;
      int index;
      Exception exception1;
      try
      {
        bufferedInputStream = file.read(32);
        try
        {
          pngHeader = MapIO.pngHeader;
          length = pngHeader.Length;
          index = 0;
          goto label_6;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (IOException ex)
      {
        goto label_5;
      }
      Exception exception2 = exception1;
      goto label_27;
label_5:
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_40;
label_6:
      int num1;
      Exception exception3;
      Exception exception4;
      while (true)
      {
        try
        {
          try
          {
            if (index < length)
            {
              int num2 = pngHeader[index];
              if (((InputStream) bufferedInputStream).read() != num2)
                num1 = 0;
              else
                goto label_16;
            }
            else
              goto label_19;
          }
          catch (Exception ex)
          {
            exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            break;
          }
          if (bufferedInputStream != null)
          {
            ((InputStream) bufferedInputStream).close();
            goto label_15;
          }
          else
            goto label_15;
        }
        catch (IOException ex)
        {
          goto label_14;
        }
label_16:
        try
        {
          ++index;
        }
        catch (Exception ex)
        {
          exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_18;
        }
      }
      exception2 = exception3;
      goto label_27;
label_14:
      local = null;
      goto label_40;
label_15:
      return num1 != 0;
label_18:
      exception2 = exception4;
      goto label_27;
label_19:
      int num3;
      Exception exception5;
      try
      {
        num3 = 1;
        goto label_22;
      }
      catch (Exception ex)
      {
        exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception2 = exception5;
      goto label_27;
label_22:
      try
      {
        if (bufferedInputStream != null)
        {
          ((InputStream) bufferedInputStream).close();
          goto label_26;
        }
        else
          goto label_26;
      }
      catch (IOException ex)
      {
      }
      local = null;
      goto label_40;
label_26:
      return num3 != 0;
label_27:
      Exception exception6 = exception2;
      Exception exception7;
      Exception exception8;
      try
      {
        exception7 = exception6;
        if (bufferedInputStream != null)
        {
          try
          {
            ((InputStream) bufferedInputStream).close();
            goto label_37;
          }
          catch (Exception ex)
          {
            exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
        }
        else
          goto label_37;
      }
      catch (IOException ex)
      {
        goto label_33;
      }
      Exception exception9 = exception8;
      try
      {
        Exception exception10 = exception9;
        Throwable.instancehelper_addSuppressed(exception7, exception10);
        goto label_37;
      }
      catch (IOException ex)
      {
      }
      local = null;
      goto label_40;
label_33:
      local = null;
      goto label_40;
label_37:
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception7);
      }
      catch (IOException ex)
      {
      }
      local = null;
label_40:
      return false;
    }

    [LineNumberTable(new byte[] {116, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int colorFor(Block wall, Block floor, Block overlay, Team team) => wall.synthetic() ? team.__\u003C\u003Ecolor.rgba() : (!wall.solid ? (overlay.useColor ? overlay.mapColor : floor.mapColor) : wall.mapColor).rgba();

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024createMap\u00240(
      [In] StringMap obj0,
      [In] SaveVersion obj1,
      [In] DataInput obj2)
    {
      obj0.putAll((ObjectMap) obj1.readStringMap(obj2));
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024generatePreview\u00241(
      [In] SaveVersion obj0,
      [In] CachedTile obj1,
      [In] Pixmap obj2,
      [In] Pixmap obj3,
      [In] Map obj4,
      [In] DataInput obj5)
    {
      obj0.readMap(obj5, (WorldContext) new MapIO.\u0032(obj1, obj2, obj3, obj4));
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapIO()
    {
    }

    [LineNumberTable(new byte[] {9, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadMap(Map map) => SaveIO.load(map.__\u003C\u003Efile);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {17, 103, 139, 127, 5, 102, 103, 104, 159, 2, 115, 115, 103, 123, 239, 77, 127, 2, 255, 2, 116, 107, 103, 116, 127, 23, 107, 53, 11, 239, 159, 178, 255, 17, 160, 80, 107, 63, 40, 107, 63, 11, 107, 63, 27, 107, 63, 16, 107, 57, 107, 63, 6, 107, 58, 107, 43, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap generatePreview(Map map)
    {
      map.spawns = 0;
      map.teams.clear();
      InflaterInputStream inflaterInputStream;
      CounterInputStream counter1;
      DataInputStream dataInputStream1;
      Pixmap pixmap1;
      Exception exception1;
      Exception exception2;
      Exception exception3;
      // ISSUE: fault handler
      try
      {
        inflaterInputStream = new InflaterInputStream((InputStream) map.__\u003C\u003Efile.read(8192));
        try
        {
          counter1 = new CounterInputStream((InputStream) inflaterInputStream);
          try
          {
            dataInputStream1 = new DataInputStream((InputStream) counter1);
            try
            {
              SaveIO.readHeader((DataInput) dataInputStream1);
              SaveVersion saveWriter = SaveIO.getSaveWriter(dataInputStream1.readInt());
              SaveVersion saveVersion1 = saveWriter;
              DataInputStream dataInputStream2 = dataInputStream1;
              CounterInputStream counter2 = counter1;
              SaveVersion saveVersion2 = saveWriter;
              Objects.requireNonNull((object) saveVersion2);
              SaveFileReader.IORunner cons1 = (SaveFileReader.IORunner) new MapIO.__\u003C\u003EAnon1(saveVersion2);
              saveVersion1.region("meta", (DataInput) dataInputStream2, counter2, cons1);
              Pixmap pixmap2 = new Pixmap(map.width, map.height);
              Pixmap pixmap3 = new Pixmap(map.width, map.height);
              int maxValue = (int) byte.MaxValue;
              int num = Color.rgba8888(0.0f, 0.0f, 0.0f, 0.5f);
              MapIO.\u0031 obj = new MapIO.\u0031(maxValue, pixmap3, pixmap2, num);
              SaveVersion saveVersion3 = saveWriter;
              DataInputStream dataInputStream3 = dataInputStream1;
              CounterInputStream counter3 = counter1;
              SaveVersion saveVersion4 = saveWriter;
              Objects.requireNonNull((object) saveVersion4);
              SaveFileReader.IORunner cons2 = (SaveFileReader.IORunner) new MapIO.__\u003C\u003EAnon2(saveVersion4);
              saveVersion3.region("content", (DataInput) dataInputStream3, counter3, cons2);
              saveWriter.region("preview_map", (DataInput) dataInputStream1, counter1, (SaveFileReader.IORunner) new MapIO.__\u003C\u003EAnon3(saveWriter, (CachedTile) obj, pixmap3, pixmap2, map));
              pixmap2.drawPixmap(pixmap3, 0, 0);
              pixmap3.dispose();
              pixmap1 = pixmap2;
            }
            catch (Exception ex)
            {
              exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
              goto label_12;
            }
            ((FilterInputStream) dataInputStream1).close();
          }
          catch (Exception ex)
          {
            exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_13;
          }
          counter1.close();
        }
        catch (Exception ex)
        {
          exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_14;
        }
        ((InputStream) inflaterInputStream).close();
        goto label_15;
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
label_12:
      Exception exception4 = exception1;
      Exception exception5;
      Exception exception6;
      Exception exception7;
      Exception exception8;
      // ISSUE: fault handler
      try
      {
        Exception exception9 = exception4;
        try
        {
          exception5 = exception9;
          try
          {
            exception6 = exception5;
            try
            {
              ((FilterInputStream) dataInputStream1).close();
              goto label_35;
            }
            catch (Exception ex)
            {
              exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
          }
          catch (Exception ex)
          {
            exception7 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_25;
          }
        }
        catch (Exception ex)
        {
          exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_26;
        }
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      Exception exception10 = exception5;
      Exception exception11;
      Exception exception12;
      // ISSUE: fault handler
      try
      {
        Exception exception9 = exception10;
        try
        {
          exception11 = exception9;
          try
          {
            Exception exception13 = exception11;
            Throwable.instancehelper_addSuppressed(exception6, exception13);
            goto label_35;
          }
          catch (Exception ex)
          {
            exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
        }
        catch (Exception ex)
        {
          exception12 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_34;
        }
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      Exception exception14 = exception11;
      goto label_41;
label_34:
      Exception exception15 = exception12;
      goto label_59;
label_25:
      exception14 = exception7;
      goto label_41;
label_26:
      exception15 = exception8;
      goto label_59;
label_35:
      Exception exception16;
      Exception exception17;
      // ISSUE: fault handler
      try
      {
        try
        {
          throw Throwable.__\u003Cunmap\u003E(exception6);
        }
        catch (Exception ex)
        {
          exception16 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception17 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_40;
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      exception14 = exception16;
      goto label_41;
label_40:
      exception15 = exception17;
      goto label_59;
label_13:
      exception14 = exception2;
      goto label_41;
label_14:
      exception15 = exception3;
      goto label_59;
label_15:
      Vars.content.setTemporaryMapper((MappableContent[][]) null);
      return pixmap1;
label_41:
      Exception exception18 = exception14;
      Exception exception19;
      Exception exception20;
      Exception exception21;
      // ISSUE: fault handler
      try
      {
        exception19 = exception18;
        try
        {
          exception20 = exception19;
          try
          {
            counter1.close();
            goto label_55;
          }
          catch (Exception ex)
          {
            exception19 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
        }
        catch (Exception ex)
        {
          exception21 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_49;
        }
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      Exception exception22 = exception19;
      Exception exception23;
      // ISSUE: fault handler
      try
      {
        exception23 = exception22;
        try
        {
          Exception exception9 = exception23;
          Throwable.instancehelper_addSuppressed(exception20, exception9);
          goto label_55;
        }
        catch (Exception ex)
        {
          exception23 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      exception15 = exception23;
      goto label_59;
label_49:
      exception15 = exception21;
      goto label_59;
label_55:
      Exception exception24;
      // ISSUE: fault handler
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception20);
      }
      catch (Exception ex)
      {
        exception24 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      exception15 = exception24;
label_59:
      Exception exception25 = exception15;
      Exception exception26;
      // ISSUE: fault handler
      try
      {
        exception26 = exception25;
        try
        {
          ((InputStream) inflaterInputStream).close();
          goto label_67;
        }
        catch (Exception ex)
        {
          exception25 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      Exception exception27 = exception25;
      // ISSUE: fault handler
      try
      {
        Exception exception9 = exception27;
        Throwable.instancehelper_addSuppressed(exception26, exception9);
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
label_67:
      // ISSUE: fault handler
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception26);
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
    }

    [LineNumberTable(new byte[] {105, 119, 110, 107, 105, 31, 15, 38, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Pixmap generatePreview(Tiles tiles)
    {
      Pixmap pixmap = new Pixmap(tiles.__\u003C\u003Ewidth, tiles.__\u003C\u003Eheight, Pixmap.Format.__\u003C\u003Ergba8888);
      for (int x = 0; x < pixmap.getWidth(); ++x)
      {
        for (int y = 0; y < pixmap.getHeight(); ++y)
        {
          Tile tile = tiles.getn(x, y);
          pixmap.draw(x, pixmap.getHeight() - 1 - y, MapIO.colorFor(tile.block(), (Block) tile.floor(), (Block) tile.overlay(), tile.team()));
        }
      }
      return pixmap;
    }

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static MapIO()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.io.MapIO"))
        return;
      MapIO.pngHeader = new int[8]
      {
        137,
        80,
        78,
        71,
        13,
        10,
        26,
        10
      };
    }

    [InnerClass]
    [EnclosingMethod(null, "generatePreview", "(Lmindustry.maps.Map;)Larc.graphics.Pixmap;")]
    [SpecialName]
    internal class \u0031 : CachedTile
    {
      [Modifiers]
      internal int val\u0024black;
      [Modifiers]
      internal Pixmap val\u0024walls;
      [Modifiers]
      internal Pixmap val\u0024floors;
      [Modifiers]
      internal int val\u0024shade;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(80)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] int obj0, [In] Pixmap obj1, [In] Pixmap obj2, [In] int obj3)
      {
        this.val\u0024black = obj0;
        this.val\u0024walls = obj1;
        this.val\u0024floors = obj2;
        this.val\u0024shade = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {33, 135, 124, 105, 127, 7, 159, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setBlock([In] Block obj0)
      {
        base.setBlock(obj0);
        int color = MapIO.colorFor(this.block(), Blocks.air, Blocks.air, this.team());
        if (color == this.val\u0024black)
          return;
        this.val\u0024walls.draw((int) this.x, this.val\u0024floors.getHeight() - 1 - (int) this.y, color);
        this.val\u0024floors.draw((int) this.x, this.val\u0024floors.getHeight() - 1 - (int) this.y + 1, this.val\u0024shade);
      }

      [HideFromJava]
      static \u0031() => CachedTile.__\u003Cclinit\u003E();
    }

    [InnerClass]
    [EnclosingMethod(null, "generatePreview", "(Lmindustry.maps.Map;)Larc.graphics.Pixmap;")]
    [SpecialName]
    internal class \u0032 : Object, WorldContext
    {
      [Modifiers]
      internal CachedTile val\u0024tile;
      [Modifiers]
      internal Pixmap val\u0024walls;
      [Modifiers]
      internal Pixmap val\u0024floors;
      [Modifiers]
      internal Map val\u0024map;

      [Signature("()V")]
      [LineNumberTable(94)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] CachedTile obj0, [In] Pixmap obj1, [In] Pixmap obj2, [In] Map obj3)
      {
        this.val\u0024tile = obj0;
        this.val\u0024walls = obj1;
        this.val\u0024floors = obj2;
        this.val\u0024map = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void resize([In] int obj0, [In] int obj1)
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isGenerating() => false;

      [LineNumberTable(new byte[] {48, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void begin() => Vars.world.setGenerating(true);

      [LineNumberTable(new byte[] {51, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void end() => Vars.world.setGenerating(false);

      [LineNumberTable(new byte[] {57, 112, 123, 113, 103, 103, 107, 104, 127, 5, 30, 40, 235, 71, 119, 191, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void onReadBuilding()
      {
        if (this.val\u0024tile.build == null)
          return;
        int color = this.val\u0024tile.build.team.__\u003C\u003Ecolor.rgba8888();
        int size = this.val\u0024tile.block().size;
        int num1 = -(size - 1) / 2;
        int num2 = -(size - 1) / 2;
        for (int index1 = 0; index1 < size; ++index1)
        {
          for (int index2 = 0; index2 < size; ++index2)
          {
            int x = (int) this.val\u0024tile.x + index1 + num1;
            int num3 = (int) this.val\u0024tile.y + index2 + num2;
            this.val\u0024walls.draw(x, this.val\u0024floors.getHeight() - 1 - num3, color);
          }
        }
        if (!(this.val\u0024tile.build.block is CoreBlock))
          return;
        this.val\u0024map.teams.add(this.val\u0024tile.build.team.__\u003C\u003Eid);
      }

      [LineNumberTable(new byte[] {77, 127, 3, 127, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tile tile([In] int obj0)
      {
        CachedTile valTile1 = this.val\u0024tile;
        int num1 = obj0;
        int width1 = this.val\u0024map.width;
        int num2 = width1 != -1 ? (int) (short) (num1 % width1) : 0;
        valTile1.x = (short) num2;
        CachedTile valTile2 = this.val\u0024tile;
        int num3 = obj0;
        int width2 = this.val\u0024map.width;
        int num4 = width2 != -1 ? (int) (short) (num3 / width2) : (int) (short) -num3;
        valTile2.y = (short) num4;
        return (Tile) this.val\u0024tile;
      }

      [LineNumberTable(new byte[] {84, 100, 159, 30, 159, 27, 120, 147})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tile create([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
      {
        if (obj3 != 0)
          this.val\u0024floors.draw(obj0, this.val\u0024floors.getHeight() - 1 - obj1, MapIO.colorFor(Blocks.air, Blocks.air, Vars.content.block(obj3), Team.__\u003C\u003Ederelict));
        else
          this.val\u0024floors.draw(obj0, this.val\u0024floors.getHeight() - 1 - obj1, MapIO.colorFor(Blocks.air, Vars.content.block(obj2), Blocks.air, Team.__\u003C\u003Ederelict));
        if (object.ReferenceEquals((object) Vars.content.block(obj3), (object) Blocks.spawn))
          ++this.val\u0024map.spawns;
        return (Tile) this.val\u0024tile;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : SaveFileReader.IORunner
    {
      private readonly StringMap arg\u00241;
      private readonly SaveVersion arg\u00242;

      internal __\u003C\u003EAnon0([In] StringMap obj0, [In] SaveVersion obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void accept([In] object obj0) => MapIO.lambda\u0024createMap\u00240(this.arg\u00241, this.arg\u00242, (DataInput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;

      internal __\u003C\u003EAnon1([In] SaveVersion obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => this.arg\u00241.readStringMap((DataInput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;

      internal __\u003C\u003EAnon2([In] SaveVersion obj0) => this.arg\u00241 = obj0;

      public void accept([In] object obj0) => this.arg\u00241.readContentHeader((DataInput) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : SaveFileReader.IORunner
    {
      private readonly SaveVersion arg\u00241;
      private readonly CachedTile arg\u00242;
      private readonly Pixmap arg\u00243;
      private readonly Pixmap arg\u00244;
      private readonly Map arg\u00245;

      internal __\u003C\u003EAnon3(
        [In] SaveVersion obj0,
        [In] CachedTile obj1,
        [In] Pixmap obj2,
        [In] Pixmap obj3,
        [In] Map obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void accept([In] object obj0) => MapIO.lambda\u0024generatePreview\u00241(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, (DataInput) obj0);
    }
  }
}
