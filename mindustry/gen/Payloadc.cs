// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Payloadc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math.geom;
using arc.scene.ui.layout;
using IKVM.Attributes;
using mindustry.entities.comp;
using mindustry.logic;
using mindustry.ui;
using mindustry.world.blocks.payloads;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Rotc", "mindustry.gen.Teamc", "mindustry.gen.Healthc", "mindustry.gen.Drawc", "mindustry.gen.Shieldc", "mindustry.gen.Minerc", "mindustry.gen.Posc", "mindustry.gen.Weaponsc", "mindustry.gen.Statusc", "mindustry.gen.Hitboxc", "mindustry.gen.Unitc", "mindustry.gen.Commanderc", "mindustry.gen.Physicsc", "mindustry.gen.Syncc", "mindustry.gen.Entityc", "mindustry.gen.Builderc", "mindustry.gen.Flyingc", "mindustry.gen.Velc", "mindustry.gen.Itemsc", "mindustry.gen.Boundedc"})]
  public interface Payloadc : 
    Rotc,
    Entityc,
    Teamc,
    Posc,
    Position,
    Healthc,
    Drawc,
    Shieldc,
    Minerc,
    Itemsc,
    Weaponsc,
    Flyingc,
    Hitboxc,
    Sized,
    QuadTree.QuadTreeObject,
    Velc,
    Statusc,
    Unitc,
    Displayable,
    Senseable,
    Ranged,
    Commanderc,
    Physicsc,
    Syncc,
    Builderc,
    Boundedc
  {
    bool hasPayload();

    [Signature("()Larc/struct/Seq<Lmindustry/world/blocks/payloads/Payload;>;")]
    Seq payloads();

    float payloadUsed();

    void contentInfo(Table t, float f1, float f2);

    bool canPickup(Unit u);

    bool canPickup(Building b);

    bool canPickupPayload(Payload p);

    void addPayload(Payload p);

    void pickup(Unit u);

    void pickup(Building b);

    bool dropLastPayload();

    bool tryDropPayload(Payload p);

    bool dropUnit(UnitPayload up);

    bool dropBlock(BuildPayload bp);

    [Signature("(Larc/struct/Seq<Lmindustry/world/blocks/payloads/Payload;>;)V")]
    void payloads(Seq s);
  }
}
