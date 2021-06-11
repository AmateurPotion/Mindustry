// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Call
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using mindustry.ai;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.entities.units;
using mindustry.game;
using mindustry.input;
using mindustry.io;
using mindustry.net;
using mindustry.type;
using mindustry.ui.fragments;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.storage;
using mindustry.world.blocks.units;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  public class Call : Object
  {
    [Modifiers]
    private static ReusableByteOutStream OUT;
    [Modifiers]
    private static Writes WRITE;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {164, 35, 108, 122, 103, 104, 106, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void kick(NetConnection playerConnection, Packets.KickReason reason)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 1;
      invokePacket.type = (byte) 55;
      Call.OUT.reset();
      TypeIO.writeKick(Call.WRITE, reason);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 48, 108, 122, 103, 104, 106, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void kick(NetConnection playerConnection, string reason)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 1;
      invokePacket.type = (byte) 56;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, reason);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 144, 120, 140, 111, 122, 103, 104, 106, 108, 108, 108, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void spawnEffect(float x, float y, float rotation, UnitType u)
    {
      if (Vars.net.server() || !Vars.net.active())
        WaveSpawner.spawnEffect(x, y, rotation, u);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 22;
      Call.OUT.reset();
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      Call.WRITE.f(rotation);
      TypeIO.writeUnitType(Call.WRITE, u);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {160, 182, 120, 143, 111, 122, 103, 104, 106, 107, 107, 107, 108, 109, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void transferItemTo(
      Unit unit,
      Item item,
      int amount,
      float x,
      float y,
      Building build)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.transferItemTo(unit, item, amount, x, y, build);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 12;
      Call.OUT.reset();
      TypeIO.writeUnit(Call.WRITE, unit);
      TypeIO.writeItem(Call.WRITE, item);
      Call.WRITE.i(amount);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      TypeIO.writeBuilding(Call.WRITE, build);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {165, 79, 120, 151, 111, 122, 103, 104, 106, 107, 107, 108, 108, 109, 109, 109, 109, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void createBullet(
      BulletType type,
      Team team,
      float x,
      float y,
      float angle,
      float damage,
      float velocityScl,
      float lifetimeScl)
    {
      if (Vars.net.server() || !Vars.net.active())
        BulletType.createBullet(type, team, x, y, angle, damage, velocityScl, lifetimeScl);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 68;
      Call.OUT.reset();
      TypeIO.writeBulletType(Call.WRITE, type);
      TypeIO.writeTeam(Call.WRITE, team);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      Call.WRITE.f(angle);
      Call.WRITE.f(damage);
      Call.WRITE.f(velocityScl);
      Call.WRITE.f(lifetimeScl);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {164, 179, 102, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void gameOver(Team winner)
    {
      Logic.gameOver(winner);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 61;
      Call.OUT.reset();
      TypeIO.writeTeam(Call.WRITE, winner);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 209, 120, 133, 108, 122, 103, 104, 106, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sectorCapture()
    {
      if (Vars.net.server() || !Vars.net.active())
        Logic.sectorCapture();
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 38;
      Call.OUT.reset();
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {165, 58, 120, 143, 111, 122, 103, 104, 106, 107, 108, 108, 108, 109, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void createWeather(
      Weather weather,
      float intensity,
      float duration,
      float windX,
      float windY)
    {
      if (Vars.net.server() || !Vars.net.active())
        Weather.createWeather(weather, intensity, duration, windX, windY);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 67;
      Call.OUT.reset();
      TypeIO.writeWeather(Call.WRITE, weather);
      Call.WRITE.f(intensity);
      Call.WRITE.f(duration);
      Call.WRITE.f(windX);
      Call.WRITE.f(windY);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 196, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sectorProduced(int[] amounts)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 37;
      Call.OUT.reset();
      TypeIO.writeInts(Call.WRITE, amounts);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 182, 120, 135, 111, 122, 103, 104, 106, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setTeam(Building build, Team team)
    {
      if (Vars.net.server() || !Vars.net.active())
        Tile.setTeam(build, team);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 24;
      Call.OUT.reset();
      TypeIO.writeBuilding(Call.WRITE, build);
      TypeIO.writeTeam(Call.WRITE, team);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 6, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void researched(Content content)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 40;
      Call.OUT.reset();
      TypeIO.writeContent(Call.WRITE, content);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 133, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sendMessage(string message, string sender, Player playersender)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 34;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      TypeIO.writeString(Call.WRITE, sender);
      TypeIO.writeEntity(Call.WRITE, (Entityc) playersender);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 179, 108, 122, 103, 104, 106, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void pingResponse(NetConnection playerConnection, long time)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 49;
      Call.OUT.reset();
      Call.WRITE.l(time);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {158, 11, 175, 111, 123, 104, 105, 106, 107, 107, 107, 108, 109, 109, 109, 109, 109, 109, 109, 108, 107, 107, 107, 108, 108, 109, 109, 109, 109, 113, 113, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clientSnapshot(
      int snapshotID,
      int unitID,
      bool dead,
      float x,
      float y,
      float pointerX,
      float pointerY,
      float rotation,
      float baseRotation,
      float xVelocity,
      float yVelocity,
      Tile mining,
      bool boosting,
      bool shooting,
      bool chatting,
      bool building,
      BuildPlan[] requests,
      float viewX,
      float viewY,
      float viewWidth,
      float viewHeight)
    {
      int num1 = dead ? 1 : 0;
      int num2 = boosting ? 1 : 0;
      int num3 = shooting ? 1 : 0;
      int num4 = chatting ? 1 : 0;
      int num5 = building ? 1 : 0;
      if (!Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 72;
      Call.OUT.reset();
      Call.WRITE.i(snapshotID);
      Call.WRITE.i(unitID);
      Call.WRITE.@bool(num1 != 0);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      Call.WRITE.f(pointerX);
      Call.WRITE.f(pointerY);
      Call.WRITE.f(rotation);
      Call.WRITE.f(baseRotation);
      Call.WRITE.f(xVelocity);
      Call.WRITE.f(yVelocity);
      TypeIO.writeTile(Call.WRITE, mining);
      Call.WRITE.@bool(num2 != 0);
      Call.WRITE.@bool(num3 != 0);
      Call.WRITE.@bool(num4 != 0);
      Call.WRITE.@bool(num5 != 0);
      TypeIO.writeRequests(Call.WRITE, requests);
      Call.WRITE.f(viewX);
      Call.WRITE.f(viewY);
      Call.WRITE.f(viewWidth);
      Call.WRITE.f(viewHeight);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {163, 192, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ping(long time)
    {
      if (!Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 50;
      Call.OUT.reset();
      Call.WRITE.l(time);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {165, 124, 108, 122, 103, 104, 106, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void connectConfirm()
    {
      if (!Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 70;
      Call.OUT.reset();
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 164, 120, 134, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sendMessage(string message)
    {
      if (Vars.net.server() || !Vars.net.active())
        NetClient.sendMessage(message);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 35;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 166, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void playerDisconnect(int playerid)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 48;
      Call.OUT.reset();
      Call.WRITE.i(playerid);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {158, 144, 66, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void removeQueueBlock(
      NetConnection playerConnection,
      int x,
      int y,
      bool breaking)
    {
      int num = breaking ? 1 : 0;
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 46;
      Call.OUT.reset();
      Call.WRITE.i(x);
      Call.WRITE.i(y);
      Call.WRITE.@bool(num != 0);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 225, 111, 122, 103, 104, 106, 108, 108, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setPosition(NetConnection playerConnection, float x, float y)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 26;
      Call.OUT.reset();
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 3, 111, 122, 103, 104, 106, 107, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void traceInfo(
      NetConnection playerConnection,
      Player player,
      Administration.TraceInfo info)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 15;
      Call.OUT.reset();
      TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeTraceInfo(Call.WRITE, info);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {157, 240, 132, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blockSnapshot(short amount, short dataLen, byte[] data)
    {
      int i1 = (int) amount;
      int i2 = (int) dataLen;
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 2;
      invokePacket.type = (byte) 76;
      Call.OUT.reset();
      Call.WRITE.s(i1);
      Call.WRITE.s(i2);
      TypeIO.writeBytes(Call.WRITE, data);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {159, 19, 137, 111, 122, 103, 104, 106, 108, 107, 107, 107, 107, 108, 107, 108, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stateSnapshot(
      NetConnection playerConnection,
      float waveTime,
      int wave,
      int enemies,
      bool paused,
      bool gameOver,
      int timeData,
      short coreDataLen,
      byte[] coreData)
    {
      int num1 = paused ? 1 : 0;
      int num2 = gameOver ? 1 : 0;
      int i = (int) coreDataLen;
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 2;
      invokePacket.type = (byte) 21;
      Call.OUT.reset();
      Call.WRITE.f(waveTime);
      Call.WRITE.i(wave);
      Call.WRITE.i(enemies);
      Call.WRITE.@bool(num1 != 0);
      Call.WRITE.@bool(num2 != 0);
      Call.WRITE.i(timeData);
      Call.WRITE.s(i);
      TypeIO.writeBytes(Call.WRITE, coreData);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {158, 65, 68, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void entitySnapshot(
      NetConnection playerConnection,
      short amount,
      short dataLen,
      byte[] data)
    {
      int i1 = (int) amount;
      int i2 = (int) dataLen;
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 2;
      invokePacket.type = (byte) 62;
      Call.OUT.reset();
      Call.WRITE.s(i1);
      Call.WRITE.s(i2);
      TypeIO.writeBytes(Call.WRITE, data);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {159, 187, 108, 122, 103, 103, 106, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void worldDataBegin(NetConnection playerConnection)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 0;
      Call.OUT.reset();
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 142, 108, 122, 103, 104, 106, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoMessage(NetConnection playerConnection, string message)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 59;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 117, 120, 134, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void removeTile(Tile tile)
    {
      if (Vars.net.server() || !Vars.net.active())
        Tile.removeTile(tile);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 45;
      Call.OUT.reset();
      TypeIO.writeTile(Call.WRITE, tile);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 163, 120, 137, 111, 122, 103, 104, 106, 107, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setTile(Tile tile, Block block, Team team, int rotation)
    {
      if (Vars.net.server() || !Vars.net.active())
        Tile.setTile(tile, block, team, rotation);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 23;
      Call.OUT.reset();
      TypeIO.writeTile(Call.WRITE, tile);
      TypeIO.writeBlock(Call.WRITE, block);
      TypeIO.writeTeam(Call.WRITE, team);
      Call.WRITE.i(rotation);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 87, 120, 136, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setFloor(Tile tile, Block floor, Block overlay)
    {
      if (Vars.net.server() || !Vars.net.active())
        Tile.setFloor(tile, floor, overlay);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 31;
      Call.OUT.reset();
      TypeIO.writeTile(Call.WRITE, tile);
      TypeIO.writeBlock(Call.WRITE, floor);
      TypeIO.writeBlock(Call.WRITE, overlay);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {49, 120, 134, 111, 122, 103, 103, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitDestroy(int uid)
    {
      if (Vars.net.server() || !Vars.net.active())
        Units.unitDestroy(uid);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 3;
      Call.OUT.reset();
      Call.WRITE.i(uid);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {166, 39, 120, 141, 111, 122, 103, 104, 106, 107, 107, 107, 107, 108, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void beginPlace(
      Unit unit,
      Block result,
      Team team,
      int x,
      int y,
      int rotation)
    {
      if (Vars.net.server() || !Vars.net.active())
        Build.beginPlace(unit, result, team, x, y, rotation);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 77;
      Call.OUT.reset();
      TypeIO.writeUnit(Call.WRITE, unit);
      TypeIO.writeBlock(Call.WRITE, result);
      TypeIO.writeTeam(Call.WRITE, team);
      Call.WRITE.i(x);
      Call.WRITE.i(y);
      Call.WRITE.i(rotation);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {166, 60, 120, 137, 111, 122, 103, 104, 106, 107, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void beginBreak(Unit unit, Team team, int x, int y)
    {
      if (Vars.net.server() || !Vars.net.active())
        Build.beginBreak(unit, team, x, y);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 78;
      Call.OUT.reset();
      TypeIO.writeUnit(Call.WRITE, unit);
      TypeIO.writeTeam(Call.WRITE, team);
      Call.WRITE.i(x);
      Call.WRITE.i(y);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 67, 104, 123, 122, 103, 104, 106, 108, 139, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tileConfig(Player player, Building build, object value)
    {
      InputHandler.tileConfig(player, build, value);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 19;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeBuilding(Call.WRITE, build);
      TypeIO.writeObject(Call.WRITE, value);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 34, 120, 134, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tileDestroyed(Building build)
    {
      if (Vars.net.server() || !Vars.net.active())
        Tile.tileDestroyed(build);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 17;
      Call.OUT.reset();
      TypeIO.writeBuilding(Call.WRITE, build);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 50, 120, 136, 111, 122, 103, 104, 106, 107, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tileDamage(Building build, float health)
    {
      if (Vars.net.server() || !Vars.net.active())
        Tile.tileDamage(build, health);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 18;
      Call.OUT.reset();
      TypeIO.writeBuilding(Call.WRITE, build);
      Call.WRITE.f(health);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {162, 149, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sendMessage(
      NetConnection playerConnection,
      string message,
      string sender,
      Player playersender)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 34;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      TypeIO.writeString(Call.WRITE, sender);
      TypeIO.writeEntity(Call.WRITE, (Entityc) playersender);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {160, 130, 120, 134, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitCapDeath(Unit unit)
    {
      if (Vars.net.server() || !Vars.net.active())
        Units.unitCapDeath(unit);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 9;
      Call.OUT.reset();
      TypeIO.writeUnit(Call.WRITE, unit);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {65, 120, 134, 111, 122, 103, 103, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitDespawn(Unit unit)
    {
      if (Vars.net.server() || !Vars.net.active())
        Units.unitDespawn(unit);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 4;
      Call.OUT.reset();
      TypeIO.writeUnit(Call.WRITE, unit);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {81, 120, 134, 111, 122, 103, 103, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitDeath(int uid)
    {
      if (Vars.net.server() || !Vars.net.active())
        Units.unitDeath(uid);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 5;
      Call.OUT.reset();
      Call.WRITE.i(uid);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Call()
    {
    }

    [LineNumberTable(new byte[] {159, 175, 108, 122, 103, 103, 106, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void worldDataBegin()
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 0;
      Call.OUT.reset();
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {7, 111, 122, 103, 103, 106, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void warningToast(int unicode, string text)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 1;
      Call.OUT.reset();
      Call.WRITE.i(unicode);
      TypeIO.writeString(Call.WRITE, text);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {21, 111, 122, 103, 103, 106, 107, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void warningToast(NetConnection playerConnection, int unicode, string text)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 1;
      Call.OUT.reset();
      Call.WRITE.i(unicode);
      TypeIO.writeString(Call.WRITE, text);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {35, 102, 111, 122, 103, 103, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void updateGameOver(Team winner)
    {
      Logic.updateGameOver(winner);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 2;
      Call.OUT.reset();
      TypeIO.writeTeam(Call.WRITE, winner);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {97, 103, 123, 122, 103, 103, 106, 108, 139, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitControl(Player player, Unit unit)
    {
      InputHandler.unitControl(player, unit);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 6;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeUnit(Call.WRITE, unit);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {114, 123, 122, 103, 103, 106, 108, 139, 107, 112, 112, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void unitControl__forward([In] NetConnection obj0, [In] Player obj1, [In] Unit obj2)
    {
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 6;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) obj1);
      TypeIO.writeUnit(Call.WRITE, obj2);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.sendExcept(obj0, (object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {160, 66, 120, 134, 123, 122, 103, 103, 106, 108, 139, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitCommand(Player player)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.unitCommand(player);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 7;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {160, 84, 123, 122, 103, 103, 106, 108, 139, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void unitCommand__forward([In] NetConnection obj0, [In] Player obj1)
    {
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 7;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) obj1);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {160, 99, 102, 123, 122, 103, 103, 106, 108, 139, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitClear(Player player)
    {
      InputHandler.unitClear(player);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 8;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {160, 115, 123, 122, 103, 103, 106, 108, 139, 112, 112, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void unitClear__forward([In] NetConnection obj0, [In] Player obj1)
    {
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 8;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) obj1);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.sendExcept(obj0, (object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {160, 146, 120, 134, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitBlockSpawn(Tile tile)
    {
      if (Vars.net.server() || !Vars.net.active())
        UnitBlock.unitBlockSpawn(tile);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 10;
      Call.OUT.reset();
      TypeIO.writeTile(Call.WRITE, tile);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {160, 162, 120, 139, 111, 122, 103, 104, 106, 107, 108, 108, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void transferItemToUnit(Item item, float x, float y, Itemsc to)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.transferItemToUnit(item, x, y, to);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 11;
      Call.OUT.reset();
      TypeIO.writeItem(Call.WRITE, item);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      TypeIO.writeEntity(Call.WRITE, (Entityc) to);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {160, 203, 120, 139, 111, 122, 103, 104, 106, 107, 108, 108, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void transferItemEffect(Item item, float x, float y, Itemsc to)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.transferItemEffect(item, x, y, to);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 13;
      Call.OUT.reset();
      TypeIO.writeItem(Call.WRITE, item);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      TypeIO.writeEntity(Call.WRITE, (Entityc) to);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {160, 222, 120, 135, 123, 122, 103, 104, 106, 108, 139, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void transferInventory(Player player, Building build)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.transferInventory(player, build);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 14;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeBuilding(Call.WRITE, build);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {160, 242, 123, 122, 103, 104, 106, 108, 139, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void transferInventory__forward([In] NetConnection obj0, [In] Player obj1, [In] Building obj2)
    {
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 14;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) obj1);
      TypeIO.writeBuilding(Call.WRITE, obj2);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 17, 103, 123, 122, 103, 104, 106, 108, 139, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tileTap(Player player, Tile tile)
    {
      InputHandler.tileTap(player, tile);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 16;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeTile(Call.WRITE, tile);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {161, 86, 123, 122, 103, 104, 106, 108, 139, 107, 107, 112, 112, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void tileConfig__forward(
      [In] NetConnection obj0,
      [In] Player obj1,
      [In] Building obj2,
      [In] object obj3)
    {
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 19;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) obj1);
      TypeIO.writeBuilding(Call.WRITE, obj2);
      TypeIO.writeObject(Call.WRITE, obj3);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.sendExcept(obj0, (object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 103, 120, 137, 111, 122, 103, 104, 106, 107, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void takeItems(Building build, Item item, int amount, Unit to)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.takeItems(build, item, amount, to);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 20;
      Call.OUT.reset();
      TypeIO.writeBuilding(Call.WRITE, build);
      TypeIO.writeItem(Call.WRITE, item);
      Call.WRITE.i(amount);
      TypeIO.writeUnit(Call.WRITE, to);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {161, 199, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setRules(Rules rules)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 25;
      Call.OUT.reset();
      TypeIO.writeRules(Call.WRITE, rules);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 212, 108, 122, 103, 104, 106, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setRules(NetConnection playerConnection, Rules rules)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 25;
      Call.OUT.reset();
      TypeIO.writeRules(Call.WRITE, rules);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {161, 239, 103, 123, 122, 103, 104, 106, 108, 139, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setPlayerTeamEditor(Player player, Team team)
    {
      HudFragment.setPlayerTeamEditor(player, team);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 27;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeTeam(Call.WRITE, team);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 1, 123, 122, 103, 104, 106, 108, 139, 107, 112, 112, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void setPlayerTeamEditor__forward([In] NetConnection obj0, [In] Player obj1, [In] Team obj2)
    {
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 27;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) obj1);
      TypeIO.writeTeam(Call.WRITE, obj2);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.sendExcept(obj0, (object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 17, 120, 136, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setItem(Building build, Item item, int amount)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.setItem(build, item, amount);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 28;
      Call.OUT.reset();
      TypeIO.writeBuilding(Call.WRITE, build);
      TypeIO.writeItem(Call.WRITE, item);
      Call.WRITE.i(amount);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {162, 35, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setHudTextReliable(string message)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 29;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 48, 108, 122, 103, 104, 106, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setHudTextReliable(NetConnection playerConnection, string message)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 29;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 61, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setHudText(string message)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 30;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {162, 74, 108, 122, 103, 104, 106, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setHudText(NetConnection playerConnection, string message)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 30;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {162, 105, 111, 122, 103, 104, 106, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void serverPacketUnreliable(string type, string contents)
    {
      if (!Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 32;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, type);
      TypeIO.writeString(Call.WRITE, contents);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {162, 119, 111, 122, 103, 104, 106, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void serverPacketReliable(string type, string contents)
    {
      if (!Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 33;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, type);
      TypeIO.writeString(Call.WRITE, contents);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {162, 180, 120, 139, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sendChatMessage(string message)
    {
      if (Vars.net.server() || !Vars.net.active())
        NetClient.sendChatMessage(Vars.player, message);
      if (!Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 36;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {158, 186, 130, 120, 136, 123, 122, 103, 104, 106, 108, 139, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rotateBlock(Player player, Building build, bool direction)
    {
      int num = direction ? 1 : 0;
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.rotateBlock(player, build, num != 0);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 39;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeBuilding(Call.WRITE, build);
      Call.WRITE.@bool(num != 0);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {158, 181, 162, 123, 122, 103, 104, 106, 108, 139, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void rotateBlock__forward(
      [In] NetConnection obj0,
      [In] Player obj1,
      [In] Building obj2,
      [In] bool obj3)
    {
      int num = obj3 ? 1 : 0;
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 39;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) obj1);
      TypeIO.writeBuilding(Call.WRITE, obj2);
      Call.WRITE.@bool(num != 0);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {163, 19, 120, 135, 123, 122, 103, 104, 106, 108, 139, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void requestUnitPayload(Player player, Unit target)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.requestUnitPayload(player, target);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 41;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeUnit(Call.WRITE, target);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 38, 120, 137, 123, 122, 103, 104, 106, 108, 139, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void requestItem(Player player, Building build, Item item, int amount)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.requestItem(player, build, item, amount);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 42;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeBuilding(Call.WRITE, build);
      TypeIO.writeItem(Call.WRITE, item);
      Call.WRITE.i(amount);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 60, 123, 122, 103, 104, 106, 108, 139, 107, 107, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void requestItem__forward(
      [In] NetConnection obj0,
      [In] Player obj1,
      [In] Building obj2,
      [In] Item obj3,
      [In] int obj4)
    {
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 42;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) obj1);
      TypeIO.writeBuilding(Call.WRITE, obj2);
      TypeIO.writeItem(Call.WRITE, obj3);
      Call.WRITE.i(obj4);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 78, 120, 138, 123, 122, 103, 104, 106, 108, 139, 108, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void requestDropPayload(Player player, float x, float y)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.requestDropPayload(player, x, y);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 43;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 98, 120, 135, 123, 122, 103, 104, 106, 108, 139, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void requestBuildPayload(Player player, Building build)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.requestBuildPayload(player, build);
      if (!Vars.net.server() && !Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 44;
      Call.OUT.reset();
      if (Vars.net.server())
        TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      TypeIO.writeBuilding(Call.WRITE, build);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 149, 120, 135, 111, 122, 103, 104, 106, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void playerSpawn(Tile tile, Player player)
    {
      if (Vars.net.server() || !Vars.net.active())
        CoreBlock.playerSpawn(tile, player);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 47;
      Call.OUT.reset();
      TypeIO.writeTile(Call.WRITE, tile);
      TypeIO.writeEntity(Call.WRITE, (Entityc) player);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 205, 120, 135, 111, 122, 103, 104, 106, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void pickedUnitPayload(Unit unit, Unit target)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.pickedUnitPayload(unit, target);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 51;
      Call.OUT.reset();
      TypeIO.writeUnit(Call.WRITE, unit);
      TypeIO.writeUnit(Call.WRITE, target);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {158, 122, 66, 120, 136, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void pickedBuildPayload(Unit unit, Building build, bool onGround)
    {
      int num = onGround ? 1 : 0;
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.pickedBuildPayload(unit, build, num != 0);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 52;
      Call.OUT.reset();
      TypeIO.writeUnit(Call.WRITE, unit);
      TypeIO.writeBuilding(Call.WRITE, build);
      Call.WRITE.@bool(num != 0);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {163, 240, 120, 138, 111, 122, 103, 104, 106, 107, 108, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void payloadDropped(Unit unit, float x, float y)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.payloadDropped(unit, x, y);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 53;
      Call.OUT.reset();
      TypeIO.writeUnit(Call.WRITE, unit);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 2, 111, 122, 103, 104, 106, 107, 108, 108, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void label(string message, float duration, float worldx, float worldy)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 54;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      Call.WRITE.f(duration);
      Call.WRITE.f(worldx);
      Call.WRITE.f(worldy);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 19, 111, 122, 103, 104, 106, 107, 108, 108, 109, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void label(
      NetConnection playerConnection,
      string message,
      float duration,
      float worldx,
      float worldy)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 54;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      Call.WRITE.f(duration);
      Call.WRITE.f(worldx);
      Call.WRITE.f(worldy);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 61, 111, 122, 103, 104, 106, 107, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoToast(string message, float duration)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 57;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      Call.WRITE.f(duration);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 75, 111, 122, 103, 104, 106, 107, 108, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoToast(NetConnection playerConnection, string message, float duration)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 57;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      Call.WRITE.f(duration);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 90, 111, 122, 103, 104, 106, 107, 108, 107, 107, 108, 108, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoPopup(
      string message,
      float duration,
      int align,
      int top,
      int left,
      int bottom,
      int right)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 58;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      Call.WRITE.f(duration);
      Call.WRITE.i(align);
      Call.WRITE.i(top);
      Call.WRITE.i(left);
      Call.WRITE.i(bottom);
      Call.WRITE.i(right);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 110, 111, 122, 103, 104, 106, 107, 108, 107, 108, 108, 108, 108, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoPopup(
      NetConnection playerConnection,
      string message,
      float duration,
      int align,
      int top,
      int left,
      int bottom,
      int right)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 58;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      Call.WRITE.f(duration);
      Call.WRITE.i(align);
      Call.WRITE.i(top);
      Call.WRITE.i(left);
      Call.WRITE.i(bottom);
      Call.WRITE.i(right);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 129, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void infoMessage(string message)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 59;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 155, 108, 122, 103, 104, 106, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void hideHudText()
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 60;
      Call.OUT.reset();
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 167, 108, 122, 103, 104, 106, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void hideHudText(NetConnection playerConnection)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 60;
      Call.OUT.reset();
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 209, 111, 122, 103, 104, 106, 107, 108, 108, 108, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void effectReliable(
      Effect effect,
      float x,
      float y,
      float rotation,
      Color color)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 63;
      Call.OUT.reset();
      TypeIO.writeEffect(Call.WRITE, effect);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      Call.WRITE.f(rotation);
      TypeIO.writeColor(Call.WRITE, color);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 227, 111, 122, 103, 104, 106, 107, 108, 108, 109, 108, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void effectReliable(
      NetConnection playerConnection,
      Effect effect,
      float x,
      float y,
      float rotation,
      Color color)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 63;
      Call.OUT.reset();
      TypeIO.writeEffect(Call.WRITE, effect);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      Call.WRITE.f(rotation);
      TypeIO.writeColor(Call.WRITE, color);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {164, 244, 111, 122, 103, 104, 106, 107, 108, 108, 108, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void effect(Effect effect, float x, float y, float rotation, Color color)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 64;
      Call.OUT.reset();
      TypeIO.writeEffect(Call.WRITE, effect);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      Call.WRITE.f(rotation);
      TypeIO.writeColor(Call.WRITE, color);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {165, 6, 111, 122, 103, 104, 106, 107, 108, 108, 109, 108, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void effect(
      NetConnection playerConnection,
      Effect effect,
      float x,
      float y,
      float rotation,
      Color color)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 64;
      Call.OUT.reset();
      TypeIO.writeEffect(Call.WRITE, effect);
      Call.WRITE.f(x);
      Call.WRITE.f(y);
      Call.WRITE.f(rotation);
      TypeIO.writeColor(Call.WRITE, color);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {165, 23, 120, 140, 111, 122, 103, 104, 106, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void dropItem(float angle)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.dropItem(Vars.player, angle);
      if (!Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 65;
      Call.OUT.reset();
      Call.WRITE.f(angle);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {165, 39, 120, 136, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deconstructFinish(Tile tile, Block block, Unit builder)
    {
      if (Vars.net.server() || !Vars.net.active())
        ConstructBlock.deconstructFinish(tile, block, builder);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 66;
      Call.OUT.reset();
      TypeIO.writeTile(Call.WRITE, tile);
      TypeIO.writeBlock(Call.WRITE, block);
      TypeIO.writeUnit(Call.WRITE, builder);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {158, 24, 99, 120, 141, 111, 122, 103, 104, 106, 107, 107, 107, 107, 108, 108, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void constructFinish(
      Tile tile,
      Block block,
      Unit builder,
      byte rotation,
      Team team,
      object config)
    {
      int i = (int) (sbyte) rotation;
      if (Vars.net.server() || !Vars.net.active())
        ConstructBlock.constructFinish(tile, block, builder, (byte) i, team, config);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 69;
      Call.OUT.reset();
      TypeIO.writeTile(Call.WRITE, tile);
      TypeIO.writeBlock(Call.WRITE, block);
      TypeIO.writeUnit(Call.WRITE, builder);
      Call.WRITE.b(i);
      TypeIO.writeTeam(Call.WRITE, team);
      TypeIO.writeObject(Call.WRITE, config);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {165, 136, 120, 135, 111, 122, 103, 104, 106, 107, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void connect(NetConnection playerConnection, string ip, int port)
    {
      if (Vars.net.client() || !Vars.net.active())
        NetClient.connect(ip, port);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 71;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, ip);
      Call.WRITE.i(port);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {165, 190, 111, 122, 103, 104, 106, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clientPacketUnreliable(string type, string contents)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 73;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, type);
      TypeIO.writeString(Call.WRITE, contents);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {165, 205, 111, 122, 103, 104, 106, 107, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clientPacketUnreliable(
      NetConnection playerConnection,
      string type,
      string contents)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 73;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, type);
      TypeIO.writeString(Call.WRITE, contents);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {165, 219, 111, 122, 103, 104, 106, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clientPacketReliable(string type, string contents)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 74;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, type);
      TypeIO.writeString(Call.WRITE, contents);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {165, 234, 111, 122, 103, 104, 106, 107, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clientPacketReliable(
      NetConnection playerConnection,
      string type,
      string contents)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 74;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, type);
      TypeIO.writeString(Call.WRITE, contents);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {165, 248, 120, 134, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clearItems(Building build)
    {
      if (Vars.net.server() || !Vars.net.active())
        InputHandler.clearItems(build);
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 75;
      Call.OUT.reset();
      TypeIO.writeBuilding(Call.WRITE, build);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {157, 236, 132, 111, 122, 103, 104, 106, 107, 107, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blockSnapshot(
      NetConnection playerConnection,
      short amount,
      short dataLen,
      byte[] data)
    {
      int i1 = (int) amount;
      int i2 = (int) dataLen;
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 2;
      invokePacket.type = (byte) 76;
      Call.OUT.reset();
      Call.WRITE.s(i1);
      Call.WRITE.s(i2);
      TypeIO.writeBytes(Call.WRITE, data);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Eudp);
    }

    [LineNumberTable(new byte[] {166, 79, 111, 122, 103, 104, 106, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void announce(string message)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 79;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {166, 92, 108, 122, 103, 104, 106, 107, 112, 112, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void announce(NetConnection playerConnection, string message)
    {
      if (!Vars.net.server())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 79;
      Call.OUT.reset();
      TypeIO.writeString(Call.WRITE, message);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      playerConnection.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {166, 105, 120, 140, 111, 122, 103, 104, 106, 107, 107, 112, 112, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void adminRequest(Player other, Packets.AdminAction action)
    {
      if (Vars.net.server() || !Vars.net.active())
        NetServer.adminRequest(Vars.player, other, action);
      if (!Vars.net.client())
        return;
      Packets.InvokePacket invokePacket = (Packets.InvokePacket) Pools.obtain((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Call.__\u003C\u003EAnon0());
      invokePacket.priority = (byte) 0;
      invokePacket.type = (byte) 80;
      Call.OUT.reset();
      TypeIO.writeEntity(Call.WRITE, (Entityc) other);
      TypeIO.writeAction(Call.WRITE, action);
      invokePacket.bytes = Call.OUT.getBytes();
      invokePacket.length = Call.OUT.size();
      Vars.net.send((object) invokePacket, Net.SendMode.__\u003C\u003Etcp);
    }

    [LineNumberTable(new byte[] {159, 135, 77, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Call()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.gen.Call"))
        return;
      Call.OUT = new ReusableByteOutStream(8192);
      Writes.__\u003Cclinit\u003E();
      Call.WRITE = new Writes((DataOutput) new DataOutputStream((OutputStream) Call.OUT));
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Packets.InvokePacket();
    }
  }
}
