// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Playerc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using mindustry.entities.units;
using mindustry.game;
using mindustry.net;
using mindustry.world.blocks.storage;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.entities.units.UnitController", "mindustry.gen.Syncc", "mindustry.gen.Drawc", "mindustry.gen.Posc", "mindustry.gen.Timerc", "mindustry.gen.Entityc"})]
  public interface Playerc : UnitController, Syncc, Entityc, Drawc, Posc, Position, Timerc
  {
    bool isBuilder();

    CoreBlock.CoreBuild closestCore();

    CoreBlock.CoreBuild core();

    CoreBlock.CoreBuild bestCore();

    TextureRegion icon();

    bool displayAmmo();

    void reset();

    new bool isValidController();

    new float clipSize();

    new void afterSync();

    new void update();

    new void remove();

    void team(Team t);

    void clearUnit();

    new Unit unit();

    new void unit(Unit u);

    bool dead();

    string ip();

    string uuid();

    string usid();

    void kick(Packets.KickReason pkr);

    void kick(string str);

    void kick(string str, long l);

    new void draw();

    void sendMessage(string str);

    void sendMessage(string str, Player p);

    void sendMessage(string str1, Player p, string str2);

    Administration.PlayerInfo getInfo();

    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    NetConnection con();

    void con([Nullable(new object[] {64, "Larc/util/Nullable;"})] NetConnection nc);

    Team team();

    bool typing();

    void typing(bool b);

    bool shooting();

    void shooting(bool b);

    bool boosting();

    void boosting(bool b);

    bool admin();

    void admin(bool b);

    float mouseX();

    void mouseX(float f);

    float mouseY();

    void mouseY(float f);

    string name();

    void name(string str);

    Color color();

    void color(Color c);

    string locale();

    void locale(string str);

    float deathTimer();

    void deathTimer(float f);

    string lastText();

    void lastText(string str);

    float textFadeTime();

    void textFadeTime(float f);
  }
}
