// Decompiled with JetBrains decompiler
// Type: mindustry.net.NetworkIO
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.io;
using mindustry.maps;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class NetworkIO : Object
  {
    [LineNumberTable(new byte[] {6, 103, 101, 127, 0, 154, 112, 145, 101, 103, 106, 112, 107, 138, 107, 127, 24, 179, 107, 247, 43, 255, 7, 84, 107, 63, 16, 107, 57, 107, 37, 107, 230, 60, 98, 141, 107, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadWorld(InputStream @is)
    {
      DataInputStream dataInputStream1;
      Exception exception1;
      IOException ioException1;
      // ISSUE: fault handler
      try
      {
        dataInputStream1 = new DataInputStream(@is);
        try
        {
          Time.clear();
          Vars.state.rules = (Rules) JsonIO.read((Class) ClassLiteral<Rules>.Value, dataInputStream1.readUTF());
          Vars.state.map = new Map(SaveIO.getSaveWriter().readStringMap((DataInput) dataInputStream1));
          Vars.state.wave = dataInputStream1.readInt();
          Vars.state.wavetime = dataInputStream1.readFloat();
          Groups.clear();
          int num = dataInputStream1.readInt();
          Vars.player.reset();
          Vars.player.read(Reads.get((DataInput) dataInputStream1));
          Vars.player.id = num;
          Vars.player.add();
          SaveIO.getSaveWriter().readContentHeader((DataInput) dataInputStream1);
          SaveVersion saveWriter = SaveIO.getSaveWriter();
          DataInputStream dataInputStream2 = dataInputStream1;
          World.Context context1 = Vars.world.__\u003C\u003Econtext;
          WorldContext context2;
          if (context1 != null)
            context2 = context1 is WorldContext worldContext6 ? worldContext6 : throw new IncompatibleClassChangeError();
          else
            context2 = (WorldContext) null;
          saveWriter.readMap((DataInput) dataInputStream2, context2);
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_10;
        }
        ((FilterInputStream) dataInputStream1).close();
        goto label_30;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_11;
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
label_10:
      Exception exception2 = exception1;
      Exception exception3;
      Exception exception4;
      IOException ioException2;
      // ISSUE: fault handler
      try
      {
        exception3 = exception2;
        try
        {
          exception4 = exception3;
          try
          {
            ((FilterInputStream) dataInputStream1).close();
            goto label_26;
          }
          catch (Exception ex)
          {
            exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
        }
        catch (IOException ex)
        {
          ioException2 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_20;
        }
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      Exception exception5 = exception3;
      IOException ioException3;
      // ISSUE: fault handler
      try
      {
        Exception exception6 = exception5;
        try
        {
          Exception exception7 = exception6;
          Throwable.instancehelper_addSuppressed(exception4, exception7);
          goto label_26;
        }
        catch (IOException ex)
        {
          ioException3 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      IOException ioException4 = ioException3;
      goto label_31;
label_20:
      ioException4 = ioException2;
      goto label_31;
label_26:
      IOException ioException5;
      // ISSUE: fault handler
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception4);
      }
      catch (IOException ex)
      {
        ioException5 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      ioException4 = ioException5;
      goto label_31;
label_11:
      ioException4 = ioException1;
      goto label_31;
label_30:
      Vars.content.setTemporaryMapper((MappableContent[][]) null);
      return;
label_31:
      IOException ioException6 = ioException4;
      // ISSUE: fault handler
      try
      {
        IOException ioException7 = ioException6;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException((Exception) ioException7);
      }
      __fault
      {
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
    }

    [LineNumberTable(new byte[] {159, 167, 135, 111, 116, 119, 127, 14, 127, 24, 156, 229, 59, 233, 73, 117, 154, 112, 144, 108, 140, 107, 123, 255, 9, 40, 255, 74, 90, 2, 98, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeWorld(Player player, OutputStream os)
    {
      DataOutputStream dataOutputStream;
      Exception exception1;
      IOException ioException1;
      try
      {
        dataOutputStream = new DataOutputStream(os);
        try
        {
          if (Vars.state.isCampaign())
          {
            Vars.state.rules.researched.clear();
            ContentType[] all = ContentType.__\u003C\u003Eall;
            int length = all.Length;
            for (int index = 0; index < length; ++index)
            {
              ContentType type = all[index];
              Iterator iterator = Vars.content.getBy(type).iterator();
              while (iterator.hasNext())
              {
                Content content1 = (Content) iterator.next();
                UnlockableContent content2;
                if (content1 is UnlockableContent && object.ReferenceEquals((object) (content2 = (UnlockableContent) content1), (object) (UnlockableContent) content1) && (content2.unlocked() && TechTree.get(content2) != null))
                  Vars.state.rules.researched.add((object) content2.__\u003C\u003Ename);
              }
            }
          }
          dataOutputStream.writeUTF(JsonIO.write((object) Vars.state.rules));
          SaveIO.getSaveWriter().writeStringMap((DataOutput) dataOutputStream, (ObjectMap) Vars.state.map.__\u003C\u003Etags);
          dataOutputStream.writeInt(Vars.state.wave);
          dataOutputStream.writeFloat(Vars.state.wavetime);
          dataOutputStream.writeInt(player.id);
          player.write(Writes.get((DataOutput) dataOutputStream));
          SaveIO.getSaveWriter().writeContentHeader((DataOutput) dataOutputStream);
          SaveIO.getSaveWriter().writeMap((DataOutput) dataOutputStream);
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_13;
        }
        ((FilterOutputStream) dataOutputStream).close();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_14;
      }
label_13:
      Exception exception2 = exception1;
      Exception exception3;
      Exception exception4;
      IOException ioException2;
      try
      {
        exception3 = exception2;
        try
        {
          ((FilterOutputStream) dataOutputStream).close();
          goto label_24;
        }
        catch (Exception ex)
        {
          exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (IOException ex)
      {
        ioException2 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_20;
      }
      Exception exception5 = exception4;
      IOException ioException3;
      try
      {
        Exception exception6 = exception5;
        Throwable.instancehelper_addSuppressed(exception3, exception6);
        goto label_24;
      }
      catch (IOException ex)
      {
        ioException3 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException4 = ioException3;
      goto label_27;
label_20:
      ioException4 = ioException2;
      goto label_27;
label_24:
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
      goto label_27;
label_14:
      ioException4 = ioException1;
label_27:
      IOException ioException6 = ioException4;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException6);
    }

    [LineNumberTable(new byte[] {56, 103, 103, 103, 103, 104, 104, 111, 104, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Host readServerData(int ping, string hostAddress, ByteBuffer buffer)
    {
      string name = NetworkIO.readString(buffer);
      string mapname = NetworkIO.readString(buffer);
      int players = buffer.getInt();
      int wave = buffer.getInt();
      int version = buffer.getInt();
      string versionType = NetworkIO.readString(buffer);
      Gamemode mode = Gamemode.__\u003C\u003Eall[(int) (sbyte) buffer.get()];
      int playerLimit = buffer.getInt();
      string description = NetworkIO.readString(buffer);
      string str = NetworkIO.readString(buffer);
      return new Host(ping, name, hostAddress, mapname, wave, players, version, versionType, mode, playerLimit, description, !String.instancehelper_isEmpty(str) ? str : (string) null);
    }

    [LineNumberTable(new byte[] {31, 126, 127, 16, 144, 139, 105, 137, 127, 1, 113, 108, 139, 124, 150, 105, 113, 151})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ByteBuffer writeServerData()
    {
      string str1 = !Vars.headless ? Vars.player.name : Administration.Config.__\u003C\u003Ename.@string();
      string str2 = !Vars.headless || String.instancehelper_equals(Administration.Config.__\u003C\u003Edesc.@string(), (object) "off") ? "" : Administration.Config.__\u003C\u003Edesc.@string();
      string str3 = Vars.state.map.name();
      ByteBuffer byteBuffer = ByteBuffer.allocate(500);
      NetworkIO.writeString(byteBuffer, str1, 100);
      NetworkIO.writeString(byteBuffer, str3, 64);
      byteBuffer.putInt(Core.settings.getInt("totalPlayers", Groups.player.size()));
      byteBuffer.putInt(Vars.state.wave);
      byteBuffer.putInt(mindustry.core.Version.build);
      NetworkIO.writeString(byteBuffer, mindustry.core.Version.type);
      byteBuffer.put((byte) Vars.state.rules.mode().ordinal());
      byteBuffer.putInt(Vars.netServer.__\u003C\u003Eadmins.getPlayerLimit());
      NetworkIO.writeString(byteBuffer, str2, 100);
      if (Vars.state.rules.modeName != null)
        NetworkIO.writeString(byteBuffer, Vars.state.rules.modeName, 50);
      return byteBuffer;
    }

    [LineNumberTable(new byte[] {71, 140, 101, 169, 106, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void writeString([In] ByteBuffer obj0, [In] string obj1, [In] int obj2)
    {
      byte[] numArray = String.instancehelper_getBytes(obj1, Vars.__\u003C\u003Echarset);
      if (numArray.Length > obj2)
        numArray = Arrays.copyOfRange(numArray, 0, obj2);
      obj0.put((byte) numArray.Length);
      obj0.put(numArray);
    }

    [LineNumberTable(new byte[] {82, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void writeString([In] ByteBuffer obj0, [In] string obj1) => NetworkIO.writeString(obj0, obj1, 32);

    [LineNumberTable(new byte[] {86, 111, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string readString([In] ByteBuffer obj0)
    {
      byte[] numArray = new byte[(int) (short) ((int) (sbyte) obj0.get() & (int) byte.MaxValue)];
      obj0.get(numArray);
      return String.newhelper(numArray, Vars.__\u003C\u003Echarset);
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NetworkIO()
    {
    }
  }
}
