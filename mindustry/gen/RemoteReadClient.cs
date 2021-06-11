// Decompiled with JetBrains decompiler
// Type: mindustry.gen.RemoteReadClient
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.ai;
using mindustry.core;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.input;
using mindustry.io;
using mindustry.type;
using mindustry.ui.fragments;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.storage;
using mindustry.world.blocks.units;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public class RemoteReadClient : Object
  {
    [LineNumberTable(new byte[] {159, 152, 131, 188, 5, 97, 145, 132, 103, 103, 191, 1, 5, 97, 145, 132, 104, 191, 1, 5, 97, 145, 132, 103, 191, 0, 5, 97, 145, 132, 104, 191, 1, 5, 97, 145, 132, 103, 191, 0, 5, 97, 145, 132, 109, 104, 191, 3, 5, 97, 145, 132, 109, 191, 1, 5, 97, 145, 132, 109, 191, 1, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 136, 104, 105, 105, 109, 191, 7, 5, 97, 145, 136, 104, 104, 104, 105, 105, 104, 191, 11, 5, 97, 145, 136, 104, 105, 105, 109, 191, 7, 5, 97, 145, 133, 109, 104, 191, 3, 5, 97, 145, 133, 109, 104, 191, 3, 5, 97, 145, 133, 109, 104, 191, 3, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 104, 105, 191, 3, 5, 97, 145, 136, 109, 104, 104, 191, 5, 5, 97, 145, 136, 104, 104, 104, 104, 191, 7, 5, 97, 145, 136, 105, 104, 104, 104, 104, 104, 104, 104, 191, 15, 5, 97, 145, 136, 105, 105, 105, 104, 191, 7, 5, 97, 145, 136, 104, 104, 104, 104, 191, 7, 5, 97, 145, 133, 104, 104, 191, 3, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 105, 105, 191, 3, 5, 97, 145, 133, 109, 104, 191, 3, 5, 97, 145, 133, 104, 104, 104, 191, 5, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 104, 104, 104, 191, 5, 5, 97, 145, 136, 104, 103, 109, 191, 4, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 190, 5, 97, 145, 136, 109, 104, 104, 191, 5, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 109, 104, 191, 3, 5, 97, 145, 136, 109, 104, 104, 104, 191, 7, 5, 97, 145, 136, 109, 105, 105, 191, 5, 5, 97, 145, 133, 109, 104, 191, 3, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 103, 104, 104, 191, 4, 5, 97, 145, 133, 104, 109, 191, 3, 5, 97, 145, 133, 103, 191, 0, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 104, 104, 191, 3, 5, 97, 145, 133, 104, 104, 104, 191, 5, 5, 97, 145, 136, 104, 105, 105, 191, 5, 5, 97, 145, 136, 104, 105, 105, 105, 191, 7, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 104, 105, 191, 3, 5, 97, 145, 136, 104, 105, 104, 104, 104, 104, 104, 191, 13, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 190, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 103, 104, 104, 191, 4, 5, 97, 145, 136, 104, 105, 105, 105, 104, 191, 9, 5, 97, 145, 136, 104, 105, 105, 105, 104, 191, 9, 5, 97, 145, 133, 104, 104, 104, 191, 5, 5, 97, 145, 136, 104, 105, 105, 105, 105, 191, 9, 5, 97, 145, 136, 104, 104, 105, 105, 105, 105, 105, 105, 191, 15, 5, 97, 145, 136, 104, 104, 104, 105, 104, 104, 191, 11, 5, 97, 145, 133, 104, 104, 191, 3, 5, 97, 145, 133, 104, 103, 191, 2, 5, 97, 145, 133, 104, 103, 191, 2, 5, 97, 145, 133, 104, 191, 1, 5, 97, 145, 133, 103, 104, 104, 191, 4, 5, 97, 145, 136, 104, 104, 104, 104, 104, 104, 191, 11, 5, 97, 145, 136, 104, 104, 104, 104, 191, 7, 5, 97, 145, 133, 104, 191, 1, 2, 97, 177, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void readPacket(Reads read, int id)
    {
      switch (id)
      {
        case 0:
          Exception exception1;
          try
          {
            NetClient.worldDataBegin();
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
          throw new RuntimeException("Failed to read remote method 'worldDataBegin'!", (Exception) exception2);
        case 1:
          Exception exception3;
          try
          {
            NetClient.warningToast(read.i(), TypeIO.readString(read));
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
          throw new RuntimeException("Failed to read remote method 'warningToast'!", (Exception) exception4);
        case 2:
          Exception exception5;
          try
          {
            Logic.updateGameOver(TypeIO.readTeam(read));
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
          throw new RuntimeException("Failed to read remote method 'updateGameOver'!", (Exception) exception6);
        case 3:
          Exception exception7;
          try
          {
            Units.unitDestroy(read.i());
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
          throw new RuntimeException("Failed to read remote method 'unitDestroy'!", (Exception) exception8);
        case 4:
          Exception exception9;
          try
          {
            Units.unitDespawn(TypeIO.readUnit(read));
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
          throw new RuntimeException("Failed to read remote method 'unitDespawn'!", (Exception) exception10);
        case 5:
          Exception exception11;
          try
          {
            Units.unitDeath(read.i());
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
          throw new RuntimeException("Failed to read remote method 'unitDeath'!", (Exception) exception12);
        case 6:
          Exception exception13;
          try
          {
            InputHandler.unitControl((Player) TypeIO.readEntity(read), TypeIO.readUnit(read));
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
          throw new RuntimeException("Failed to read remote method 'unitControl'!", (Exception) exception14);
        case 7:
          Exception exception15;
          try
          {
            InputHandler.unitCommand((Player) TypeIO.readEntity(read));
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
          throw new RuntimeException("Failed to read remote method 'unitCommand'!", (Exception) exception16);
        case 8:
          Exception exception17;
          try
          {
            InputHandler.unitClear((Player) TypeIO.readEntity(read));
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
          throw new RuntimeException("Failed to read remote method 'unitClear'!", (Exception) exception18);
        case 9:
          Exception exception19;
          try
          {
            Units.unitCapDeath(TypeIO.readUnit(read));
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
          throw new RuntimeException("Failed to read remote method 'unitCapDeath'!", (Exception) exception20);
        case 10:
          Exception exception21;
          try
          {
            UnitBlock.unitBlockSpawn(TypeIO.readTile(read));
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
          throw new RuntimeException("Failed to read remote method 'unitBlockSpawn'!", (Exception) exception22);
        case 11:
          Exception exception23;
          try
          {
            InputHandler.transferItemToUnit(TypeIO.readItem(read), read.f(), read.f(), (Itemsc) TypeIO.readEntity(read));
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
          throw new RuntimeException("Failed to read remote method 'transferItemToUnit'!", (Exception) exception24);
        case 12:
          Exception exception25;
          try
          {
            InputHandler.transferItemTo(TypeIO.readUnit(read), TypeIO.readItem(read), read.i(), read.f(), read.f(), TypeIO.readBuilding(read));
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
          throw new RuntimeException("Failed to read remote method 'transferItemTo'!", (Exception) exception26);
        case 13:
          Exception exception27;
          try
          {
            InputHandler.transferItemEffect(TypeIO.readItem(read), read.f(), read.f(), (Itemsc) TypeIO.readEntity(read));
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
          throw new RuntimeException("Failed to read remote method 'transferItemEffect'!", (Exception) exception28);
        case 14:
          Exception exception29;
          try
          {
            InputHandler.transferInventory((Player) TypeIO.readEntity(read), TypeIO.readBuilding(read));
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
          throw new RuntimeException("Failed to read remote method 'transferInventory'!", (Exception) exception30);
        case 15:
          Exception exception31;
          try
          {
            NetClient.traceInfo((Player) TypeIO.readEntity(read), TypeIO.readTraceInfo(read));
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
          throw new RuntimeException("Failed to read remote method 'traceInfo'!", (Exception) exception32);
        case 16:
          Exception exception33;
          try
          {
            InputHandler.tileTap((Player) TypeIO.readEntity(read), TypeIO.readTile(read));
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
          throw new RuntimeException("Failed to read remote method 'tileTap'!", (Exception) exception34);
        case 17:
          Exception exception35;
          try
          {
            Tile.tileDestroyed(TypeIO.readBuilding(read));
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
          throw new RuntimeException("Failed to read remote method 'tileDestroyed'!", (Exception) exception36);
        case 18:
          Exception exception37;
          try
          {
            Tile.tileDamage(TypeIO.readBuilding(read), read.f());
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
          throw new RuntimeException("Failed to read remote method 'tileDamage'!", (Exception) exception38);
        case 19:
          Exception exception39;
          try
          {
            InputHandler.tileConfig((Player) TypeIO.readEntity(read), TypeIO.readBuilding(read), TypeIO.readObject(read));
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
          throw new RuntimeException("Failed to read remote method 'tileConfig'!", (Exception) exception40);
        case 20:
          Exception exception41;
          try
          {
            InputHandler.takeItems(TypeIO.readBuilding(read), TypeIO.readItem(read), read.i(), TypeIO.readUnit(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception41 = (Exception) m0;
          }
          Exception exception42 = exception41;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'takeItems'!", (Exception) exception42);
        case 21:
          Exception exception43;
          try
          {
            NetClient.stateSnapshot(read.f(), read.i(), read.i(), read.@bool(), read.@bool(), read.i(), read.s(), TypeIO.readBytes(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception43 = (Exception) m0;
          }
          Exception exception44 = exception43;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'stateSnapshot'!", (Exception) exception44);
        case 22:
          Exception exception45;
          try
          {
            WaveSpawner.spawnEffect(read.f(), read.f(), read.f(), TypeIO.readUnitType(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception45 = (Exception) m0;
          }
          Exception exception46 = exception45;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'spawnEffect'!", (Exception) exception46);
        case 23:
          Exception exception47;
          try
          {
            Tile.setTile(TypeIO.readTile(read), TypeIO.readBlock(read), TypeIO.readTeam(read), read.i());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception47 = (Exception) m0;
          }
          Exception exception48 = exception47;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setTile'!", (Exception) exception48);
        case 24:
          Exception exception49;
          try
          {
            Tile.setTeam(TypeIO.readBuilding(read), TypeIO.readTeam(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception49 = (Exception) m0;
          }
          Exception exception50 = exception49;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setTeam'!", (Exception) exception50);
        case 25:
          Exception exception51;
          try
          {
            NetClient.setRules(TypeIO.readRules(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception51 = (Exception) m0;
          }
          Exception exception52 = exception51;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setRules'!", (Exception) exception52);
        case 26:
          Exception exception53;
          try
          {
            NetClient.setPosition(read.f(), read.f());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception53 = (Exception) m0;
          }
          Exception exception54 = exception53;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setPosition'!", (Exception) exception54);
        case 27:
          Exception exception55;
          try
          {
            HudFragment.setPlayerTeamEditor((Player) TypeIO.readEntity(read), TypeIO.readTeam(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception55 = (Exception) m0;
          }
          Exception exception56 = exception55;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setPlayerTeamEditor'!", (Exception) exception56);
        case 28:
          Exception exception57;
          try
          {
            InputHandler.setItem(TypeIO.readBuilding(read), TypeIO.readItem(read), read.i());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception57 = (Exception) m0;
          }
          Exception exception58 = exception57;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setItem'!", (Exception) exception58);
        case 29:
          Exception exception59;
          try
          {
            NetClient.setHudTextReliable(TypeIO.readString(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception59 = (Exception) m0;
          }
          Exception exception60 = exception59;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setHudTextReliable'!", (Exception) exception60);
        case 30:
          Exception exception61;
          try
          {
            NetClient.setHudText(TypeIO.readString(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception61 = (Exception) m0;
          }
          Exception exception62 = exception61;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setHudText'!", (Exception) exception62);
        case 31:
          Exception exception63;
          try
          {
            Tile.setFloor(TypeIO.readTile(read), TypeIO.readBlock(read), TypeIO.readBlock(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception63 = (Exception) m0;
          }
          Exception exception64 = exception63;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'setFloor'!", (Exception) exception64);
        case 34:
          Exception exception65;
          try
          {
            NetClient.sendMessage(TypeIO.readString(read), TypeIO.readString(read), (Player) TypeIO.readEntity(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception65 = (Exception) m0;
          }
          Exception exception66 = exception65;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'sendMessage'!", (Exception) exception66);
        case 35:
          Exception exception67;
          try
          {
            NetClient.sendMessage(TypeIO.readString(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception67 = (Exception) m0;
          }
          Exception exception68 = exception67;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'sendMessage'!", (Exception) exception68);
        case 37:
          Exception exception69;
          try
          {
            Logic.sectorProduced(TypeIO.readInts(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception69 = (Exception) m0;
          }
          Exception exception70 = exception69;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'sectorProduced'!", (Exception) exception70);
        case 38:
          Exception exception71;
          try
          {
            Logic.sectorCapture();
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception71 = (Exception) m0;
          }
          Exception exception72 = exception71;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'sectorCapture'!", (Exception) exception72);
        case 39:
          Exception exception73;
          try
          {
            InputHandler.rotateBlock((Player) TypeIO.readEntity(read), TypeIO.readBuilding(read), read.@bool());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception73 = (Exception) m0;
          }
          Exception exception74 = exception73;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'rotateBlock'!", (Exception) exception74);
        case 40:
          Exception exception75;
          try
          {
            Logic.researched(TypeIO.readContent(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception75 = (Exception) m0;
          }
          Exception exception76 = exception75;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'researched'!", (Exception) exception76);
        case 41:
          Exception exception77;
          try
          {
            InputHandler.requestUnitPayload((Player) TypeIO.readEntity(read), TypeIO.readUnit(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception77 = (Exception) m0;
          }
          Exception exception78 = exception77;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'requestUnitPayload'!", (Exception) exception78);
        case 42:
          Exception exception79;
          try
          {
            InputHandler.requestItem((Player) TypeIO.readEntity(read), TypeIO.readBuilding(read), TypeIO.readItem(read), read.i());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception79 = (Exception) m0;
          }
          Exception exception80 = exception79;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'requestItem'!", (Exception) exception80);
        case 43:
          Exception exception81;
          try
          {
            InputHandler.requestDropPayload((Player) TypeIO.readEntity(read), read.f(), read.f());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception81 = (Exception) m0;
          }
          Exception exception82 = exception81;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'requestDropPayload'!", (Exception) exception82);
        case 44:
          Exception exception83;
          try
          {
            InputHandler.requestBuildPayload((Player) TypeIO.readEntity(read), TypeIO.readBuilding(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception83 = (Exception) m0;
          }
          Exception exception84 = exception83;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'requestBuildPayload'!", (Exception) exception84);
        case 45:
          Exception exception85;
          try
          {
            Tile.removeTile(TypeIO.readTile(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception85 = (Exception) m0;
          }
          Exception exception86 = exception85;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'removeTile'!", (Exception) exception86);
        case 46:
          Exception exception87;
          try
          {
            InputHandler.removeQueueBlock(read.i(), read.i(), read.@bool());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception87 = (Exception) m0;
          }
          Exception exception88 = exception87;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'removeQueueBlock'!", (Exception) exception88);
        case 47:
          Exception exception89;
          try
          {
            CoreBlock.playerSpawn(TypeIO.readTile(read), (Player) TypeIO.readEntity(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception89 = (Exception) m0;
          }
          Exception exception90 = exception89;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'playerSpawn'!", (Exception) exception90);
        case 48:
          Exception exception91;
          try
          {
            NetClient.playerDisconnect(read.i());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception91 = (Exception) m0;
          }
          Exception exception92 = exception91;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'playerDisconnect'!", (Exception) exception92);
        case 49:
          Exception exception93;
          try
          {
            NetClient.pingResponse(read.l());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception93 = (Exception) m0;
          }
          Exception exception94 = exception93;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'pingResponse'!", (Exception) exception94);
        case 51:
          Exception exception95;
          try
          {
            InputHandler.pickedUnitPayload(TypeIO.readUnit(read), TypeIO.readUnit(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception95 = (Exception) m0;
          }
          Exception exception96 = exception95;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'pickedUnitPayload'!", (Exception) exception96);
        case 52:
          Exception exception97;
          try
          {
            InputHandler.pickedBuildPayload(TypeIO.readUnit(read), TypeIO.readBuilding(read), read.@bool());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception97 = (Exception) m0;
          }
          Exception exception98 = exception97;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'pickedBuildPayload'!", (Exception) exception98);
        case 53:
          Exception exception99;
          try
          {
            InputHandler.payloadDropped(TypeIO.readUnit(read), read.f(), read.f());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception99 = (Exception) m0;
          }
          Exception exception100 = exception99;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'payloadDropped'!", (Exception) exception100);
        case 54:
          Exception exception101;
          try
          {
            NetClient.label(TypeIO.readString(read), read.f(), read.f(), read.f());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception101 = (Exception) m0;
          }
          Exception exception102 = exception101;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'label'!", (Exception) exception102);
        case 55:
          Exception exception103;
          try
          {
            NetClient.kick(TypeIO.readKick(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception103 = (Exception) m0;
          }
          Exception exception104 = exception103;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'kick'!", (Exception) exception104);
        case 56:
          Exception exception105;
          try
          {
            NetClient.kick(TypeIO.readString(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception105 = (Exception) m0;
          }
          Exception exception106 = exception105;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'kick'!", (Exception) exception106);
        case 57:
          Exception exception107;
          try
          {
            NetClient.infoToast(TypeIO.readString(read), read.f());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception107 = (Exception) m0;
          }
          Exception exception108 = exception107;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'infoToast'!", (Exception) exception108);
        case 58:
          Exception exception109;
          try
          {
            NetClient.infoPopup(TypeIO.readString(read), read.f(), read.i(), read.i(), read.i(), read.i(), read.i());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception109 = (Exception) m0;
          }
          Exception exception110 = exception109;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'infoPopup'!", (Exception) exception110);
        case 59:
          Exception exception111;
          try
          {
            NetClient.infoMessage(TypeIO.readString(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception111 = (Exception) m0;
          }
          Exception exception112 = exception111;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'infoMessage'!", (Exception) exception112);
        case 60:
          Exception exception113;
          try
          {
            NetClient.hideHudText();
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception113 = (Exception) m0;
          }
          Exception exception114 = exception113;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'hideHudText'!", (Exception) exception114);
        case 61:
          Exception exception115;
          try
          {
            Logic.gameOver(TypeIO.readTeam(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception115 = (Exception) m0;
          }
          Exception exception116 = exception115;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'gameOver'!", (Exception) exception116);
        case 62:
          Exception exception117;
          try
          {
            NetClient.entitySnapshot(read.s(), read.s(), TypeIO.readBytes(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception117 = (Exception) m0;
          }
          Exception exception118 = exception117;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'entitySnapshot'!", (Exception) exception118);
        case 63:
          Exception exception119;
          try
          {
            NetClient.effectReliable(TypeIO.readEffect(read), read.f(), read.f(), read.f(), TypeIO.readColor(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception119 = (Exception) m0;
          }
          Exception exception120 = exception119;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'effectReliable'!", (Exception) exception120);
        case 64:
          Exception exception121;
          try
          {
            NetClient.effect(TypeIO.readEffect(read), read.f(), read.f(), read.f(), TypeIO.readColor(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception121 = (Exception) m0;
          }
          Exception exception122 = exception121;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'effect'!", (Exception) exception122);
        case 66:
          Exception exception123;
          try
          {
            ConstructBlock.deconstructFinish(TypeIO.readTile(read), TypeIO.readBlock(read), TypeIO.readUnit(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception123 = (Exception) m0;
          }
          Exception exception124 = exception123;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'deconstructFinish'!", (Exception) exception124);
        case 67:
          Exception exception125;
          try
          {
            Weather.createWeather(TypeIO.readWeather(read), read.f(), read.f(), read.f(), read.f());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception125 = (Exception) m0;
          }
          Exception exception126 = exception125;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'createWeather'!", (Exception) exception126);
        case 68:
          Exception exception127;
          try
          {
            BulletType.createBullet(TypeIO.readBulletType(read), TypeIO.readTeam(read), read.f(), read.f(), read.f(), read.f(), read.f(), read.f());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception127 = (Exception) m0;
          }
          Exception exception128 = exception127;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'createBullet'!", (Exception) exception128);
        case 69:
          Exception exception129;
          try
          {
            ConstructBlock.constructFinish(TypeIO.readTile(read), TypeIO.readBlock(read), TypeIO.readUnit(read), read.b(), TypeIO.readTeam(read), TypeIO.readObject(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception129 = (Exception) m0;
          }
          Exception exception130 = exception129;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'constructFinish'!", (Exception) exception130);
        case 71:
          Exception exception131;
          try
          {
            NetClient.connect(TypeIO.readString(read), read.i());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception131 = (Exception) m0;
          }
          Exception exception132 = exception131;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'connect'!", (Exception) exception132);
        case 73:
          Exception exception133;
          try
          {
            NetClient.clientPacketUnreliable(TypeIO.readString(read), TypeIO.readString(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception133 = (Exception) m0;
          }
          Exception exception134 = exception133;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'clientPacketUnreliable'!", (Exception) exception134);
        case 74:
          Exception exception135;
          try
          {
            NetClient.clientPacketReliable(TypeIO.readString(read), TypeIO.readString(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception135 = (Exception) m0;
          }
          Exception exception136 = exception135;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'clientPacketReliable'!", (Exception) exception136);
        case 75:
          Exception exception137;
          try
          {
            InputHandler.clearItems(TypeIO.readBuilding(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception137 = (Exception) m0;
          }
          Exception exception138 = exception137;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'clearItems'!", (Exception) exception138);
        case 76:
          Exception exception139;
          try
          {
            NetClient.blockSnapshot(read.s(), read.s(), TypeIO.readBytes(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception139 = (Exception) m0;
          }
          Exception exception140 = exception139;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'blockSnapshot'!", (Exception) exception140);
        case 77:
          Exception exception141;
          try
          {
            Build.beginPlace(TypeIO.readUnit(read), TypeIO.readBlock(read), TypeIO.readTeam(read), read.i(), read.i(), read.i());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception141 = (Exception) m0;
          }
          Exception exception142 = exception141;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'beginPlace'!", (Exception) exception142);
        case 78:
          Exception exception143;
          try
          {
            Build.beginBreak(TypeIO.readUnit(read), TypeIO.readTeam(read), read.i(), read.i());
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception143 = (Exception) m0;
          }
          Exception exception144 = exception143;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'beginBreak'!", (Exception) exception144);
        case 79:
          Exception exception145;
          try
          {
            NetClient.announce(TypeIO.readString(read));
            break;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception145 = (Exception) m0;
          }
          Exception exception146 = exception145;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Failed to read remote method 'announce'!", (Exception) exception146);
        default:
          string str = new StringBuilder().append("Invalid read method ID: ").append(id).append("").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException(str);
      }
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RemoteReadClient()
    {
    }
  }
}
