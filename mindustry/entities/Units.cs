// Decompiled with JetBrains decompiler
// Type: mindustry.entities.Units
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities.comp;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities
{
  public class Units : Object
  {
    [Modifiers]
    private static Rect hitrect;
    private static Unit result;
    private static float cdist;
    private static bool boolResult;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool invalidateTarget(Posc target, Team team, float x, float y) => Units.invalidateTarget(target, team, x, y, float.MaxValue);

    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool invalidateTarget(Posc target, Team team, float x, float y, float range)
    {
      if (target != null)
      {
        if ((double) range != 3.40282346638529E+38)
        {
          Posc posc1 = target;
          double num1 = (double) x;
          double num2 = (double) y;
          double num3 = (double) range;
          Posc posc2 = target;
          Sized sized;
          double num4 = !(posc2 is Sized) || !object.ReferenceEquals((object) (sized = (Sized) posc2), (object) (Sized) posc2) ? 0.0 : (double) (sized.hitSize() / 2f);
          double num5 = num3 + num4;
          if (!posc1.within((float) num1, (float) num2, (float) num5))
            goto label_5;
        }
        Posc posc3 = target;
        Teamc teamc;
        if (!(posc3 is Teamc) || !object.ReferenceEquals((object) (teamc = (Teamc) posc3), (object) (Teamc) posc3) || !object.ReferenceEquals((object) teamc.team(), (object) team))
        {
          Posc posc1 = target;
          Healthc healthc;
          if (!(posc1 is Healthc) || !object.ReferenceEquals((object) (healthc = (Healthc) posc1), (object) (Healthc) posc1) || healthc.isValid())
            return false;
        }
      }
label_5:
      return true;
    }

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Unit;>;Larc/func/Boolf<Lmindustry/gen/Building;>;)Lmindustry/gen/Teamc;")]
    [LineNumberTable(new byte[] {121, 143, 111, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Teamc closestTarget(
      Team team,
      float x,
      float y,
      float range,
      Boolf unitPred,
      Boolf tilePred)
    {
      return object.ReferenceEquals((object) team, (object) Team.__\u003C\u003Ederelict) ? (Teamc) null : (Teamc) Units.closestEnemy(team, x, y, range, unitPred) ?? (Teamc) Units.findEnemyTile(team, x, y, range, tilePred);
    }

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {160, 199, 255, 23, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void nearby(Team team, float x, float y, float radius, Cons cons) => Units.nearby(team, x - radius, y - radius, radius * 2f, radius * 2f, (Cons) new Units.__\u003C\u003EAnon9(x, y, radius, cons));

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Unit;>;Lmindustry/entities/Units$Sortf;)Lmindustry/gen/Unit;")]
    [LineNumberTable(new byte[] {160, 157, 102, 138, 254, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Unit closest(
      Team team,
      float x,
      float y,
      float range,
      Boolf predicate,
      Units.Sortf sort)
    {
      Units.result = (Unit) null;
      Units.cdist = 0.0f;
      Units.nearby(team, x, y, range, (Cons) new Units.__\u003C\u003EAnon7(predicate, sort, x, y));
      return Units.result;
    }

    [LineNumberTable(107)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool invalidateTarget(Teamc target, Unit targeter, float range) => Units.invalidateTarget((Posc) target, targeter.team(), targeter.x(), targeter.y(), range);

    [LineNumberTable(144)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Building findDamagedTile(Team team, float x, float y) => (Building) Geometry.findClosest(x, y, (Iterable) Vars.indexer.getDamaged(team));

    [Signature("(Lmindustry/game/Team;FFFFLarc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {160, 218, 112, 107, 122, 31, 3, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void nearbyEnemies(
      Team team,
      float x,
      float y,
      float width,
      float height,
      Cons cons)
    {
      Seq present = Vars.state.teams.present;
      for (int index = 0; index < present.size; ++index)
      {
        if (!object.ReferenceEquals((object) ((Teams.TeamData[]) present.items)[index].__\u003C\u003Eteam, (object) team))
          Units.nearby(((Teams.TeamData[]) present.items)[index].__\u003C\u003Eteam, x, y, width, height, cons);
      }
    }

    [LineNumberTable(new byte[] {26, 127, 44, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getCap(Team team) => object.ReferenceEquals((object) team, (object) Vars.state.rules.waveTeam) && !Vars.state.rules.pvp || Vars.state.isCampaign() && object.ReferenceEquals((object) team, (object) Vars.state.rules.waveTeam) ? int.MaxValue : Math.max(0, !Vars.state.rules.unitCapVariable ? Vars.state.rules.unitCap : Vars.state.rules.unitCap + Vars.indexer.getExtraUnits(team));

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Unit;>;)Lmindustry/gen/Unit;")]
    [LineNumberTable(new byte[] {160, 139, 102, 138, 252, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Unit closest(Team team, float x, float y, float range, Boolf predicate)
    {
      Units.result = (Unit) null;
      Units.cdist = 0.0f;
      Units.nearby(team, x, y, range, (Cons) new Units.__\u003C\u003EAnon6(predicate, x, y));
      return Units.result;
    }

    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool anyEntities(Tile tile) => Units.anyEntities(tile, true);

    [Signature("(Lmindustry/game/Team;Larc/math/geom/Rect;Larc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {160, 228, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void nearbyEnemies(Team team, Rect rect, Cons cons) => Units.nearbyEnemies(team, rect.x, rect.y, rect.width, rect.height, cons);

    [Signature("(Larc/math/geom/Rect;Larc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {160, 213, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void nearby(Rect rect, Cons cons) => Units.nearby(rect.x, rect.y, rect.width, rect.height, cons);

    [LineNumberTable(new byte[] {159, 111, 131, 134, 255, 1, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool anyEntities(float x, float y, float width, float height, bool ground)
    {
      int num = ground ? 1 : 0;
      Units.boolResult = false;
      Units.nearby(x, y, width, height, (Cons) new Units.__\u003C\u003EAnon1(num != 0, x, y, width, height));
      return Units.boolResult;
    }

    [LineNumberTable(new byte[] {159, 114, 66, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool anyEntities(Tile tile, bool ground)
    {
      int num1 = ground ? 1 : 0;
      float num2 = (float) (tile.block().size * 8);
      return Units.anyEntities(tile.drawx() - num2 / 2f, tile.drawy() - num2 / 2f, num2, num2, num1 != 0);
    }

    [Signature("(FFFFLarc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {160, 208, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void nearby(float x, float y, float width, float height, Cons cons) => Groups.unit.intersect(x, y, width, height, cons);

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Unit;>;)Lmindustry/gen/Teamc;")]
    [LineNumberTable(166)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Teamc closestTarget(
      Team team,
      float x,
      float y,
      float range,
      Boolf unitPred)
    {
      return Units.closestTarget(team, x, y, range, unitPred, (Boolf) new Units.__\u003C\u003EAnon3());
    }

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Unit;>;)Lmindustry/gen/Unit;")]
    [LineNumberTable(new byte[] {160, 81, 143, 102, 138, 255, 23, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Unit closestEnemy(
      Team team,
      float x,
      float y,
      float range,
      Boolf predicate)
    {
      if (object.ReferenceEquals((object) team, (object) Team.__\u003C\u003Ederelict))
        return (Unit) null;
      Units.result = (Unit) null;
      Units.cdist = 0.0f;
      Units.nearbyEnemies(team, x - range, y - range, range * 2f, range * 2f, (Cons) new Units.__\u003C\u003EAnon4(predicate, x, y, range));
      return Units.result;
    }

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Building;>;)Lmindustry/gen/Building;")]
    [LineNumberTable(new byte[] {104, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Building findEnemyTile(
      Team team,
      float x,
      float y,
      float range,
      Boolf pred)
    {
      return object.ReferenceEquals((object) team, (object) Team.__\u003C\u003Ederelict) ? (Building) null : Vars.indexer.findEnemyTile(team, x, y, range, pred);
    }

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Unit;>;Lmindustry/entities/Units$Sortf;)Lmindustry/gen/Unit;")]
    [LineNumberTable(new byte[] {160, 101, 143, 102, 138, 255, 25, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Unit bestEnemy(
      Team team,
      float x,
      float y,
      float range,
      Boolf predicate,
      Units.Sortf sort)
    {
      if (object.ReferenceEquals((object) team, (object) Team.__\u003C\u003Ederelict))
        return (Unit) null;
      Units.result = (Unit) null;
      Units.cdist = 0.0f;
      Units.nearbyEnemies(team, x - range, y - range, range * 2f, range * 2f, (Cons) new Units.__\u003C\u003EAnon5(predicate, x, y, range, sort));
      return Units.result;
    }

    [Signature("(Lmindustry/game/Team;FFFFLarc/func/Cons<Lmindustry/gen/Unit;>;)V")]
    [LineNumberTable(new byte[] {160, 194, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void nearby(Team team, float x, float y, float width, float height, Cons cons) => team.data().tree().intersect(x, y, width, height, cons);

    [Modifiers]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024unitCapDeath\u00240([In] Unit obj0) => Call.unitDestroy(obj0.id);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 110, 98, 104, 126, 140, 117, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024anyEntities\u00241(
      [In] bool obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4,
      [In] Unit obj5)
    {
      int num = obj0 ? 1 : 0;
      if (Units.boolResult || (!obj5.isGrounded() || obj5.type.hovering ? 0 : 1) != num)
        return;
      obj5.hitboxTile(Units.hitrect);
      if (!Units.hitrect.overlaps(obj1, obj2, obj3, obj4))
        return;
      Units.boolResult = true;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024closestTarget\u00242([In] Building obj0) => true;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 87, 159, 8, 109, 120, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024closestEnemy\u00243(
      [In] Boolf obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] Unit obj4)
    {
      if (obj4.dead() || !obj0.get((object) obj4) || object.ReferenceEquals((object) obj4.team, (object) Team.__\u003C\u003Ederelict))
        return;
      float num = obj4.dst2(obj1, obj2);
      if ((double) num >= (double) (obj3 * obj3) || Units.result != null && (double) num >= (double) Units.cdist)
        return;
      Units.result = obj4;
      Units.cdist = num;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 107, 159, 39, 111, 111, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024bestEnemy\u00244(
      [In] Boolf obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] Units.Sortf obj4,
      [In] Unit obj5)
    {
      if (obj5.dead() || !obj0.get((object) obj5) || (object.ReferenceEquals((object) obj5.team, (object) Team.__\u003C\u003Ederelict) || !obj5.within(obj1, obj2, obj3 + obj5.hitSize / 2f)))
        return;
      float num = obj4.cost(obj5, obj1, obj2);
      if (Units.result != null && (double) num >= (double) Units.cdist)
        return;
      Units.result = obj5;
      Units.cdist = num;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 143, 138, 108, 111, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024closest\u00245([In] Boolf obj0, [In] float obj1, [In] float obj2, [In] Unit obj3)
    {
      if (!obj0.get((object) obj3))
        return;
      float num = obj3.dst2(obj1, obj2);
      if (Units.result != null && (double) num >= (double) Units.cdist)
        return;
      Units.result = obj3;
      Units.cdist = num;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 161, 139, 110, 111, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024closest\u00246(
      [In] Boolf obj0,
      [In] Units.Sortf obj1,
      [In] float obj2,
      [In] float obj3,
      [In] Unit obj4)
    {
      if (!obj0.get((object) obj4))
        return;
      float num = obj1.cost(obj4, obj2, obj3);
      if (Units.result != null && (double) num >= (double) Units.cdist)
        return;
      Units.result = obj4;
      Units.cdist = num;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 180, 138, 108, 111, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024closestOverlap\u00247(
      [In] Boolf obj0,
      [In] float obj1,
      [In] float obj2,
      [In] Unit obj3)
    {
      if (!obj0.get((object) obj3))
        return;
      float num = obj3.dst2(obj1, obj2);
      if (Units.result != null && (double) num >= (double) Units.cdist)
        return;
      Units.result = obj3;
      Units.cdist = num;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 200, 127, 0, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024nearby\u00248(
      [In] float obj0,
      [In] float obj1,
      [In] float obj2,
      [In] Cons obj3,
      [In] Unit obj4)
    {
      if (!obj4.within(obj0, obj1, obj2 + obj4.hitSize / 2f))
        return;
      obj3.get((object) obj4);
    }

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Units()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 99, 103, 107, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitCapDeath(Unit unit)
    {
      if (unit == null)
        return;
      unit.dead = true;
      Fx.__\u003C\u003EunitCapKill.at((Position) unit);
      Core.app.post((Runnable) new Units.__\u003C\u003EAnon0(unit));
    }

    [LineNumberTable(new byte[] {159, 178, 177, 103, 171, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitDeath(int uid)
    {
      Unit byId = (Unit) Groups.unit.getByID(uid);
      if (Vars.netClient != null)
        Vars.netClient.addRemovedEntity(uid);
      byId?.killed();
    }

    [LineNumberTable(new byte[] {1, 177, 103, 171, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitDestroy(int uid)
    {
      Unit byId = (Unit) Groups.unit.getByID(uid);
      if (Vars.netClient != null)
        Vars.netClient.addRemovedEntity(uid);
      byId?.destroy();
    }

    [LineNumberTable(new byte[] {15, 124, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void unitDespawn(Unit unit)
    {
      Fx.__\u003C\u003EunitDespawn.at(unit.x, unit.y, 0.0f, (object) unit);
      unit.remove();
    }

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool canCreate(Team team, UnitType type) => team.data().countType(type) < Units.getCap(team);

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool canInteract(Player player, Building tile) => player == null || tile == null || tile.interactable(player.team());

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool anyEntities(float x, float y, float width, float height) => Units.anyEntities(x, y, width, height, true);

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Building;>;)Lmindustry/gen/Building;")]
    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Building findAllyTile(
      Team team,
      float x,
      float y,
      float range,
      Boolf pred)
    {
      return Vars.indexer.findTile(team, x, y, range, pred);
    }

    [LineNumberTable(161)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Teamc closestTarget(Team team, float x, float y, float range) => Units.closestTarget(team, x, y, range, (Boolf) new Units.__\u003C\u003EAnon2());

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Unit;>;Larc/func/Boolf<Lmindustry/gen/Building;>;Lmindustry/entities/Units$Sortf;)Lmindustry/gen/Teamc;")]
    [LineNumberTable(new byte[] {160, 69, 143, 113, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Teamc bestTarget(
      Team team,
      float x,
      float y,
      float range,
      Boolf unitPred,
      Boolf tilePred,
      Units.Sortf sort)
    {
      return object.ReferenceEquals((object) team, (object) Team.__\u003C\u003Ederelict) ? (Teamc) null : (Teamc) Units.bestEnemy(team, x, y, range, unitPred, sort) ?? (Teamc) Units.findEnemyTile(team, x, y, range, tilePred);
    }

    [Signature("(Lmindustry/game/Team;FFLarc/func/Boolf<Lmindustry/gen/Unit;>;)Lmindustry/gen/Unit;")]
    [LineNumberTable(new byte[] {160, 121, 102, 138, 127, 0, 153, 108, 111, 102, 134, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Unit closest(Team team, float x, float y, Boolf predicate)
    {
      Units.result = (Unit) null;
      Units.cdist = 0.0f;
      Iterator iterator = Groups.unit.iterator();
      while (iterator.hasNext())
      {
        Unit unit = (Unit) iterator.next();
        if (predicate.get((object) unit) && object.ReferenceEquals((object) unit.team(), (object) team))
        {
          float num = unit.dst2(x, y);
          if (Units.result == null || (double) num < (double) Units.cdist)
          {
            Units.result = unit;
            Units.cdist = num;
          }
        }
      }
      return Units.result;
    }

    [Signature("(Lmindustry/game/Team;FFFLarc/func/Boolf<Lmindustry/gen/Unit;>;)Lmindustry/gen/Unit;")]
    [LineNumberTable(new byte[] {160, 176, 102, 138, 255, 21, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Unit closestOverlap(
      Team team,
      float x,
      float y,
      float range,
      Boolf predicate)
    {
      Units.result = (Unit) null;
      Units.cdist = 0.0f;
      Units.nearby(team, x - range, y - range, range * 2f, range * 2f, (Cons) new Units.__\u003C\u003EAnon8(predicate, x, y));
      return Units.result;
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Units()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.Units"))
        return;
      Units.hitrect = new Rect();
    }

    public interface Sortf
    {
      float cost(Unit u, float f1, float f2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Unit arg\u00241;

      internal __\u003C\u003EAnon0([In] Unit obj0) => this.arg\u00241 = obj0;

      public void run() => Units.lambda\u0024unitCapDeath\u00240(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly bool arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly float arg\u00245;

      internal __\u003C\u003EAnon1([In] bool obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] object obj0) => Units.lambda\u0024anyEntities\u00241(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (((Healthc) obj0).isValid() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get([In] object obj0) => (Units.lambda\u0024closestTarget\u00242((Building) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly Boolf arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;

      internal __\u003C\u003EAnon4([In] Boolf obj0, [In] float obj1, [In] float obj2, [In] float obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => Units.lambda\u0024closestEnemy\u00243(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly Boolf arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;
      private readonly Units.Sortf arg\u00245;

      internal __\u003C\u003EAnon5(
        [In] Boolf obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] Units.Sortf obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] object obj0) => Units.lambda\u0024bestEnemy\u00244(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly Boolf arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon6([In] Boolf obj0, [In] float obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => Units.lambda\u0024closest\u00245(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly Boolf arg\u00241;
      private readonly Units.Sortf arg\u00242;
      private readonly float arg\u00243;
      private readonly float arg\u00244;

      internal __\u003C\u003EAnon7([In] Boolf obj0, [In] Units.Sortf obj1, [In] float obj2, [In] float obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => Units.lambda\u0024closest\u00246(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly Boolf arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon8([In] Boolf obj0, [In] float obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => Units.lambda\u0024closestOverlap\u00247(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;
      private readonly Cons arg\u00244;

      internal __\u003C\u003EAnon9([In] float obj0, [In] float obj1, [In] float obj2, [In] Cons obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => Units.lambda\u0024nearby\u00248(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, (Unit) obj0);
    }
  }
}
