// Decompiled with JetBrains decompiler
// Type: mindustry.gen.NullPlayer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using java.nio;
using mindustry.entities.units;
using mindustry.game;
using mindustry.net;
using mindustry.world;
using mindustry.world.blocks.environment;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Playerc"})]
  internal sealed class NullPlayer : 
    Player,
    Playerc,
    UnitController,
    Syncc,
    Entityc,
    Drawc,
    Posc,
    Position,
    Timerc
  {
    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NullPlayer()
    {
    }

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object @as() => (object) null;

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Entityc self() => (Entityc) null;

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed object with([In] Cons obj0) => (object) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void add()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool admin() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void admin([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void afterRead()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void afterSync()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float angleTo([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed CoreBlock.CoreBuild bestCore() => (CoreBlock.CoreBuild) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Block blockOn() => (Block) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool boosting() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void boosting([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int classId() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void clearUnit()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float clipSize() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed CoreBlock.CoreBuild closestCore() => (CoreBlock.CoreBuild) null;

    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Color color() => new Color();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void color([In] Color obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void command([In] UnitCommand obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed NetConnection con() => (NetConnection) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void con([In] NetConnection obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed CoreBlock.CoreBuild core() => (CoreBlock.CoreBuild) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool dead() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float deathTimer() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void deathTimer([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool displayAmmo() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void draw()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst2([In] Position obj0) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float dst2([In] float obj0, [In] float obj1) => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Floor floorOn() => (Floor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Administration.PlayerInfo getInfo() => (Administration.PlayerInfo) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float getY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed TextureRegion icon() => (TextureRegion) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int id() => -1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void id([In] int obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void interpolate()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed string ip() => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isAdded() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isBeingControlled([In] Unit obj0) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isBuilder() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isLocal() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isNull() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isRemote() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool isValidController() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void kick([In] string obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void kick([In] string obj0, [In] long obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void kick([In] Packets.KickReason obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed string lastText() => "";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lastText([In] string obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed long lastUpdated() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void lastUpdated([In] long obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed string locale() => "en";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void locale([In] string obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float mouseX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void mouseX([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float mouseY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void mouseY([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed string name() => "noname";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void name([In] string obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool onSolid() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void read([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void readSync([In] Reads obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void readSyncManual([In] FloatBuffer obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void remove()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void removed([In] Unit obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void reset()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void sendMessage([In] string obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void sendMessage([In] string obj0, [In] Player obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void sendMessage([In] string obj0, [In] Player obj1, [In] string obj2)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool serialize() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void set([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void set([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool shooting() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void shooting([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void snapInterpolation()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void snapSync()
    {
    }

    [LineNumberTable(476)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Team team() => Team.__\u003C\u003Esharded;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void team([In] Team obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float textFadeTime() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void textFadeTime([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Tile tileOn() => (Tile) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileX() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed int tileY() => 0;

    [LineNumberTable(516)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Interval timer() => new Interval(6);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void timer([In] Interval obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool timer([In] int obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] Position obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void trns([In] float obj0, [In] float obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool typing() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void typing([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed Unit unit() => (Unit) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void unit([In] Unit obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void update()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed long updateSpacing() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateSpacing([In] long obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void updateUnit()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed string usid() => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed string uuid() => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] Position obj0, [In] float obj1) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed bool within([In] float obj0, [In] float obj1, [In] float obj2) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void write([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void writeSync([In] Writes obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void writeSyncManual([In] FloatBuffer obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float x() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void x([In] float obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed float y() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override sealed void y([In] float obj0)
    {
    }
  }
}
