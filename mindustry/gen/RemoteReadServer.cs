// Decompiled with JetBrains decompiler
// Type: mindustry.gen.RemoteReadServer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.core;
using mindustry.entities.units;
using mindustry.game;
using mindustry.input;
using mindustry.io;
using mindustry.net;
using mindustry.type;
using mindustry.ui.fragments;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public class RemoteReadServer : Object
  {
    [LineNumberTable(new byte[] {159, 152, 132, 103, 103, 191, 5, 5, 97, 145, 132, 102, 191, 4, 5, 97, 145, 132, 102, 191, 6, 5, 97, 145, 133, 104, 104, 191, 8, 5, 97, 145, 133, 104, 191, 2, 5, 97, 145, 136, 104, 104, 106, 191, 10, 5, 97, 145, 133, 104, 104, 191, 8, 5, 97, 145, 133, 104, 104, 191, 4, 5, 97, 145, 133, 104, 104, 191, 4, 5, 97, 145, 133, 104, 191, 2, 5, 97, 145, 136, 104, 104, 106, 191, 10, 5, 97, 145, 133, 103, 191, 1, 5, 97, 145, 136, 104, 104, 104, 108, 191, 12, 5, 97, 145, 133, 105, 105, 191, 4, 5, 97, 145, 133, 104, 191, 2, 5, 97, 145, 133, 104, 191, 2, 5, 97, 145, 133, 105, 191, 2, 5, 97, 145, 133, 191, 0, 5, 97, 145, 136, 104, 104, 104, 105, 105, 105, 105, 105, 105, 105, 105, 104, 104, 104, 104, 104, 104, 105, 105, 105, 105, 191, 42, 5, 97, 145, 133, 109, 104, 191, 4, 2, 97, 177, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void readPacket(Reads read, int id, Player player)
    {
      switch (id)
      {
        case 6:
          Exception exception1;
          try
          {
            Unit unit = TypeIO.readUnit(read);
            InputHandler.unitControl(player, unit);
            Call.unitControl__forward(player.con, player, unit);
            break;
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
          throw new RuntimeException("Failed to read remote method 'unitControl'!", (Exception) exception2);
        case 7:
          Exception exception3;
          try
          {
            InputHandler.unitCommand(player);
            Call.unitCommand__forward(player.con, player);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception3 = (Exception) m0;
          }
          Exception exception4 = exception3;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'unitCommand'!", (Exception) exception4);
        case 8:
          Exception exception5;
          try
          {
            InputHandler.unitClear(player);
            Call.unitClear__forward(player.con, player);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception5 = (Exception) m0;
          }
          Exception exception6 = exception5;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'unitClear'!", (Exception) exception6);
        case 14:
          Exception exception7;
          try
          {
            Building build = TypeIO.readBuilding(read);
            InputHandler.transferInventory(player, build);
            Call.transferInventory__forward(player.con, player, build);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception7 = (Exception) m0;
          }
          Exception exception8 = exception7;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'transferInventory'!", (Exception) exception8);
        case 16:
          Exception exception9;
          try
          {
            Tile tile = TypeIO.readTile(read);
            InputHandler.tileTap(player, tile);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception9 = (Exception) m0;
          }
          Exception exception10 = exception9;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'tileTap'!", (Exception) exception10);
        case 19:
          Exception exception11;
          try
          {
            Building build = TypeIO.readBuilding(read);
            object obj = TypeIO.readObject(read);
            InputHandler.tileConfig(player, build, obj);
            Call.tileConfig__forward(player.con, player, build, obj);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception11 = (Exception) m0;
          }
          Exception exception12 = exception11;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'tileConfig'!", (Exception) exception12);
        case 27:
          Exception exception13;
          try
          {
            Team team = TypeIO.readTeam(read);
            HudFragment.setPlayerTeamEditor(player, team);
            Call.setPlayerTeamEditor__forward(player.con, player, team);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception13 = (Exception) m0;
          }
          Exception exception14 = exception13;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setPlayerTeamEditor'!", (Exception) exception14);
        case 32:
          Exception exception15;
          try
          {
            string type = TypeIO.readString(read);
            string contents = TypeIO.readString(read);
            NetServer.serverPacketUnreliable(player, type, contents);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception15 = (Exception) m0;
          }
          Exception exception16 = exception15;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'serverPacketUnreliable'!", (Exception) exception16);
        case 33:
          Exception exception17;
          try
          {
            string type = TypeIO.readString(read);
            string contents = TypeIO.readString(read);
            NetServer.serverPacketReliable(player, type, contents);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception17 = (Exception) m0;
          }
          Exception exception18 = exception17;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'serverPacketReliable'!", (Exception) exception18);
        case 36:
          Exception exception19;
          try
          {
            string message = TypeIO.readString(read);
            NetClient.sendChatMessage(player, message);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception19 = (Exception) m0;
          }
          Exception exception20 = exception19;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'sendChatMessage'!", (Exception) exception20);
        case 39:
          Exception exception21;
          try
          {
            Building build = TypeIO.readBuilding(read);
            int num = read.@bool() ? 1 : 0;
            InputHandler.rotateBlock(player, build, num != 0);
            Call.rotateBlock__forward(player.con, player, build, num != 0);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception21 = (Exception) m0;
          }
          Exception exception22 = exception21;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'rotateBlock'!", (Exception) exception22);
        case 41:
          Exception exception23;
          try
          {
            Unit target = TypeIO.readUnit(read);
            InputHandler.requestUnitPayload(player, target);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception23 = (Exception) m0;
          }
          Exception exception24 = exception23;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'requestUnitPayload'!", (Exception) exception24);
        case 42:
          Exception exception25;
          try
          {
            Building build = TypeIO.readBuilding(read);
            Item obj = TypeIO.readItem(read);
            int amount = read.i();
            InputHandler.requestItem(player, build, obj, amount);
            Call.requestItem__forward(player.con, player, build, obj, amount);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception25 = (Exception) m0;
          }
          Exception exception26 = exception25;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'requestItem'!", (Exception) exception26);
        case 43:
          Exception exception27;
          try
          {
            float x = read.f();
            float y = read.f();
            InputHandler.requestDropPayload(player, x, y);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception27 = (Exception) m0;
          }
          Exception exception28 = exception27;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'requestDropPayload'!", (Exception) exception28);
        case 44:
          Exception exception29;
          try
          {
            Building build = TypeIO.readBuilding(read);
            InputHandler.requestBuildPayload(player, build);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception29 = (Exception) m0;
          }
          Exception exception30 = exception29;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'requestBuildPayload'!", (Exception) exception30);
        case 50:
          Exception exception31;
          try
          {
            long time = read.l();
            NetClient.ping(player, time);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception31 = (Exception) m0;
          }
          Exception exception32 = exception31;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'ping'!", (Exception) exception32);
        case 65:
          Exception exception33;
          try
          {
            float angle = read.f();
            InputHandler.dropItem(player, angle);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception33 = (Exception) m0;
          }
          Exception exception34 = exception33;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'dropItem'!", (Exception) exception34);
        case 70:
          Exception exception35;
          try
          {
            NetServer.connectConfirm(player);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception35 = (Exception) m0;
          }
          Exception exception36 = exception35;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'connectConfirm'!", (Exception) exception36);
        case 72:
          Exception exception37;
          try
          {
            int snapshotID = read.i();
            int unitID = read.i();
            int num1 = read.@bool() ? 1 : 0;
            float x = read.f();
            float y = read.f();
            float pointerX = read.f();
            float pointerY = read.f();
            float rotation = read.f();
            float baseRotation = read.f();
            float xVelocity = read.f();
            float yVelocity = read.f();
            Tile mining = TypeIO.readTile(read);
            int num2 = read.@bool() ? 1 : 0;
            int num3 = read.@bool() ? 1 : 0;
            int num4 = read.@bool() ? 1 : 0;
            int num5 = read.@bool() ? 1 : 0;
            BuildPlan[] requests = TypeIO.readRequests(read);
            float viewX = read.f();
            float viewY = read.f();
            float viewWidth = read.f();
            float viewHeight = read.f();
            NetServer.clientSnapshot(player, snapshotID, unitID, num1 != 0, x, y, pointerX, pointerY, rotation, baseRotation, xVelocity, yVelocity, mining, num2 != 0, num3 != 0, num4 != 0, num5 != 0, requests, viewX, viewY, viewWidth, viewHeight);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception37 = (Exception) m0;
          }
          Exception exception38 = exception37;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'clientSnapshot'!", (Exception) exception38);
        case 80:
          Exception exception39;
          try
          {
            Player other = (Player) TypeIO.readEntity(read);
            Packets.AdminAction action = TypeIO.readAction(read);
            NetServer.adminRequest(player, other, action);
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception39 = (Exception) m0;
          }
          Exception exception40 = exception39;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'adminRequest'!", (Exception) exception40);
        default:
          string str = new StringBuilder().append("Invalid read method ID: ").append(id).append("").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException(str);
      }
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RemoteReadServer()
    {
    }
  }
}
