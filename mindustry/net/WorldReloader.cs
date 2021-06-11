// Decompiled with JetBrains decompiler
// Type: mindustry.net.WorldReloader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using System.Runtime.CompilerServices;

namespace mindustry.net
{
  public class WorldReloader : Object
  {
    [Signature("Larc/struct/Seq<Lmindustry/gen/Player;>;")]
    internal Seq players;
    internal bool wasServer;
    internal bool began;

    [LineNumberTable(new byte[] {159, 152, 104, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WorldReloader()
    {
      WorldReloader worldReloader = this;
      this.players = new Seq();
      this.wasServer = false;
      this.began = false;
    }

    [LineNumberTable(new byte[] {159, 161, 137, 122, 140, 127, 0, 138, 108, 102, 130, 138, 135, 106, 170, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void begin()
    {
      if (this.began)
        return;
      WorldReloader worldReloader = this;
      int num1 = Vars.net.server() ? 1 : 0;
      int num2 = num1;
      this.wasServer = num1 != 0;
      if (num2 != 0)
      {
        this.players.clear();
        Iterator iterator = Groups.player.iterator();
        while (iterator.hasNext())
        {
          Player player = (Player) iterator.next();
          if (!player.isLocal())
          {
            this.players.add((object) player);
            player.clearUnit();
          }
        }
        Vars.logic.reset();
        Call.worldDataBegin();
      }
      else
      {
        Vars.net.reset();
        Vars.logic.reset();
      }
      this.began = true;
    }

    [LineNumberTable(new byte[] {159, 187, 107, 127, 4, 138, 103, 102, 103, 113, 156, 107, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void end()
    {
      if (!this.wasServer)
        return;
      Iterator iterator = this.players.iterator();
      while (iterator.hasNext())
      {
        Player player = (Player) iterator.next();
        if (player.con != null)
        {
          int num = player.admin ? 1 : 0;
          player.reset();
          player.admin = num != 0;
          if (Vars.state.rules.pvp)
            player.team(Vars.netServer.assignTeam(player, (Iterable) new Seq.SeqIterable(this.players)));
          Vars.netServer.sendWorldData(player);
        }
      }
    }
  }
}
