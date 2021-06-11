// Decompiled with JetBrains decompiler
// Type: mindustry.io.TypeIO
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math.geom;
using arc.util;
using arc.util.io;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using mindustry.ai.formations;
using mindustry.ai.types;
using mindustry.content;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.bullet;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.logic;
using mindustry.net;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.payloads;
using System.Runtime.CompilerServices;

namespace mindustry.io
{
  public class TypeIO : Object
  {
    [Modifiers]
    internal static WeaponMount[] noMounts;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(105)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readObject(Reads read) => TypeIO.readObjectBoxed(read, false);

    [LineNumberTable(new byte[] {159, 180, 99, 108, 127, 0, 103, 113, 127, 0, 103, 113, 127, 0, 103, 114, 127, 1, 103, 109, 127, 1, 103, 115, 114, 127, 1, 103, 110, 110, 48, 173, 127, 1, 103, 109, 114, 127, 4, 103, 105, 121, 45, 173, 127, 1, 104, 120, 119, 127, 1, 104, 114, 127, 1, 104, 115, 127, 1, 104, 114, 127, 1, 104, 114, 127, 1, 104, 105, 109, 127, 1, 104, 111, 127, 1, 104, 143, 159, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeObject(Writes write, object @object)
    {
      if (@object == null)
      {
        write.b(0);
      }
      else
      {
        object obj1 = @object;
        Integer integer;
        if (obj1 is Integer && object.ReferenceEquals((object) (integer = (Integer) obj1), (object) (Integer) obj1))
        {
          write.b(1);
          write.i(integer.intValue());
        }
        else
        {
          object obj2 = @object;
          Long @long;
          if (obj2 is Long && object.ReferenceEquals((object) (@long = (Long) obj2), (object) (Long) obj2))
          {
            write.b(2);
            write.l(@long.longValue());
          }
          else
          {
            object obj3 = @object;
            Float @float;
            if (obj3 is Float && object.ReferenceEquals((object) (@float = (Float) obj3), (object) (Float) obj3))
            {
              write.b(3);
              write.f(@float.floatValue());
            }
            else
            {
              object obj4 = @object;
              string @string;
              if (obj4 is string && object.ReferenceEquals((object) (@string = (string) obj4), (object) (string) obj4))
              {
                write.b(4);
                TypeIO.writeString(write, @string);
              }
              else
              {
                object obj5 = @object;
                Content content;
                if (obj5 is Content && object.ReferenceEquals((object) (content = (Content) obj5), (object) (Content) obj5))
                {
                  write.b(5);
                  write.b((int) (sbyte) content.getContentType().ordinal());
                  write.s((int) content.__\u003C\u003Eid);
                }
                else
                {
                  object obj6 = @object;
                  IntSeq intSeq;
                  if (obj6 is IntSeq && object.ReferenceEquals((object) (intSeq = (IntSeq) obj6), (object) (IntSeq) obj6))
                  {
                    write.b(6);
                    write.s((int) (short) intSeq.size);
                    for (int index = 0; index < intSeq.size; ++index)
                      write.i(intSeq.items[index]);
                  }
                  else
                  {
                    object obj7 = @object;
                    Point2 point2_1;
                    if (obj7 is Point2 && object.ReferenceEquals((object) (point2_1 = (Point2) obj7), (object) (Point2) obj7))
                    {
                      write.b(7);
                      write.i(point2_1.x);
                      write.i(point2_1.y);
                    }
                    else
                    {
                      object obj8 = @object;
                      Point2[] point2Array1;
                      if (obj8 is Point2[] && object.ReferenceEquals((object) (point2Array1 = (Point2[]) obj8), (object) (Point2[]) obj8))
                      {
                        write.b(8);
                        write.b(point2Array1.Length);
                        Point2[] point2Array2 = point2Array1;
                        int length = point2Array2.Length;
                        for (int index = 0; index < length; ++index)
                        {
                          Point2 point2_2 = point2Array2[index];
                          write.i(point2_2.pack());
                        }
                      }
                      else
                      {
                        object obj9 = @object;
                        TechTree.TechNode techNode;
                        if (obj9 is TechTree.TechNode && object.ReferenceEquals((object) (techNode = (TechTree.TechNode) obj9), (object) (TechTree.TechNode) obj9))
                        {
                          write.b(9);
                          write.b((int) (sbyte) techNode.content.getContentType().ordinal());
                          write.s((int) techNode.content.__\u003C\u003Eid);
                        }
                        else
                        {
                          object obj10 = @object;
                          Boolean boolean;
                          if (obj10 is Boolean && object.ReferenceEquals((object) (boolean = (Boolean) obj10), (object) (Boolean) obj10))
                          {
                            write.b(10);
                            write.@bool(boolean.booleanValue());
                          }
                          else
                          {
                            object obj11 = @object;
                            Double @double;
                            if (obj11 is Double && object.ReferenceEquals((object) (@double = (Double) obj11), (object) (Double) obj11))
                            {
                              write.b(11);
                              write.d(@double.doubleValue());
                            }
                            else
                            {
                              object obj12 = @object;
                              Building building;
                              if (obj12 is Building && object.ReferenceEquals((object) (building = (Building) obj12), (object) (Building) obj12))
                              {
                                write.b(12);
                                write.i(building.pos());
                              }
                              else
                              {
                                object obj13 = @object;
                                LAccess laccess;
                                if (obj13 is LAccess && object.ReferenceEquals((object) (laccess = (LAccess) obj13), (object) (LAccess) obj13))
                                {
                                  write.b(13);
                                  write.s(laccess.ordinal());
                                }
                                else
                                {
                                  object obj14 = @object;
                                  byte[] array;
                                  if (obj14 is byte[] && object.ReferenceEquals((object) (array = (byte[]) obj14), (object) (byte[]) obj14))
                                  {
                                    write.b(14);
                                    write.i(array.Length);
                                    write.b(array);
                                  }
                                  else
                                  {
                                    object obj15 = @object;
                                    UnitCommand unitCommand;
                                    if (obj15 is UnitCommand && object.ReferenceEquals((object) (unitCommand = (UnitCommand) obj15), (object) (UnitCommand) obj15))
                                    {
                                      write.b(15);
                                      write.b(unitCommand.ordinal());
                                    }
                                    else
                                    {
                                      object obj16 = @object;
                                      TypeIO.BuildingBox buildingBox;
                                      if (obj16 is TypeIO.BuildingBox && object.ReferenceEquals((object) (buildingBox = (TypeIO.BuildingBox) obj16), (object) (TypeIO.BuildingBox) obj16))
                                      {
                                        write.b(12);
                                        write.i(buildingBox.pos);
                                      }
                                      else
                                      {
                                        string str = new StringBuilder().append("Unknown object type: ").append((object) Object.instancehelper_getClass(@object)).toString();
                                        Throwable.__\u003CsuppressFillInStackTrace\u003E();
                                        throw new IllegalArgumentException(str);
                                      }
                                    }
                                  }
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    }

    [LineNumberTable(new byte[] {160, 191, 127, 0, 103, 113, 127, 8, 103, 115, 127, 8, 103, 147, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeController(Writes write, UnitController control)
    {
      UnitController unitController1 = control;
      Player player;
      if (unitController1 is Player && object.ReferenceEquals((object) (player = (Player) unitController1), (object) (Player) unitController1))
      {
        write.b(0);
        write.i(player.id);
      }
      else
      {
        UnitController unitController2 = control;
        FormationAI formationAi;
        if (unitController2 is FormationAI && object.ReferenceEquals((object) (formationAi = (FormationAI) unitController2), (object) (FormationAI) unitController2) && formationAi.leader != null)
        {
          write.b(1);
          write.i(formationAi.leader.id);
        }
        else
        {
          UnitController unitController3 = control;
          LogicAI logicAi;
          if (unitController3 is LogicAI && object.ReferenceEquals((object) (logicAi = (LogicAI) unitController3), (object) (LogicAI) unitController3) && logicAi.controller != null)
          {
            write.b(3);
            write.i(logicAi.controller.pos());
          }
          else
            write.b(2);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 108, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeTile(Writes write, Tile tile) => write.i(tile != null ? tile.pos() : Point2.pack(-1, -1));

    [LineNumberTable(new byte[] {92, 104, 111, 127, 0, 108, 236, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeMounts(Writes writes, WeaponMount[] mounts)
    {
      writes.b(mounts.Length);
      WeaponMount[] weaponMountArray = mounts;
      int length = weaponMountArray.Length;
      for (int index = 0; index < length; ++index)
      {
        WeaponMount weaponMount = weaponMountArray[index];
        writes.b((!weaponMount.shoot ? 0 : 1) | (!weaponMount.rotate ? 0 : 2));
        writes.f(weaponMount.aimX);
        writes.f(weaponMount.aimY);
      }
    }

    [LineNumberTable(new byte[] {84, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writePayload(Writes writes, Payload payload) => Payload.write(payload, writes);

    [LineNumberTable(new byte[] {160, 124, 114, 119, 104, 113, 109, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeRequest(Writes write, BuildPlan request)
    {
      write.b(!request.breaking ? 0 : 1);
      write.i(Point2.pack(request.x, request.y));
      if (request.breaking)
        return;
      write.s((int) request.block.__\u003C\u003Eid);
      write.b((int) (sbyte) request.rotation);
      write.b(1);
      TypeIO.writeObject(write, request.config);
    }

    [LineNumberTable(new byte[] {161, 35, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeItems(Writes write, ItemStack stack)
    {
      TypeIO.writeItem(write, stack.item);
      write.i(stack.amount);
    }

    [LineNumberTable(new byte[] {161, 26, 113, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeStatuse(Writes write, StatusEntry entry)
    {
      write.s((int) entry.effect.__\u003C\u003Eid);
      write.f(entry.time);
    }

    [LineNumberTable(new byte[] {161, 48, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeTeam(Writes write, Team reason) => write.b(reason.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {160, 206, 104, 99, 103, 145, 101, 98, 103, 103, 127, 1, 119, 131, 124, 103, 103, 127, 1, 114, 163, 135, 108, 114, 227, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static UnitController readController(Reads read, UnitController prev)
    {
      switch ((sbyte) read.b())
      {
        case 0:
          int id1 = read.i();
          return (UnitController) Groups.player.getByID(id1) ?? prev;
        case 1:
          int id2 = read.i();
          UnitController unitController1 = prev;
          FormationAI formationAi;
          if (unitController1 is FormationAI && object.ReferenceEquals((object) (formationAi = (FormationAI) unitController1), (object) (FormationAI) unitController1))
          {
            formationAi.leader = (Unit) Groups.unit.getByID(id2);
            return (UnitController) formationAi;
          }
          FormationAI.__\u003Cclinit\u003E();
          return (UnitController) new FormationAI((Unit) Groups.unit.getByID(id2), (Formation) null);
        case 3:
          int pos = read.i();
          UnitController unitController2 = prev;
          LogicAI logicAi;
          if (unitController2 is LogicAI && object.ReferenceEquals((object) (logicAi = (LogicAI) unitController2), (object) (LogicAI) unitController2))
          {
            logicAi.controller = Vars.world.build(pos);
            return (UnitController) logicAi;
          }
          return (UnitController) new LogicAI()
          {
            controlTimer = 600f,
            controller = Vars.world.build(pos)
          };
        default:
          UnitController unitController3 = !(prev is AIController) || prev is FormationAI || prev is LogicAI ? (UnitController) new GroundAI() : prev;
          if (unitController3 == null)
            return (UnitController) null;
          return unitController3 is UnitController unitController5 ? unitController5 : throw new IncompatibleClassChangeError();
      }
    }

    [LineNumberTable(new byte[] {101, 104, 105, 104, 145, 103, 101, 104, 105, 112, 240, 55, 233, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static WeaponMount[] readMounts(Reads read, WeaponMount[] mounts)
    {
      int num1 = (int) (sbyte) read.b();
      for (int index = 0; index < num1; ++index)
      {
        int num2 = (int) (sbyte) read.b();
        float num3 = read.f();
        float num4 = read.f();
        if (index <= mounts.Length - 1)
        {
          WeaponMount mount = mounts[index];
          mount.aimX = num3;
          mount.aimY = num4;
          mount.shoot = (num2 & 1) != 0;
          mount.rotate = (num2 & 2) != 0;
        }
      }
      return mounts;
    }

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Payload readPayload(Reads read) => Payload.read(read);

    [LineNumberTable(new byte[] {160, 137, 104, 135, 109, 162, 100, 148, 103, 105, 108, 104, 159, 0, 100, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BuildPlan readRequest(Reads read)
    {
      int num1 = (int) (sbyte) read.b();
      int pos = read.i();
      if (Vars.world.tile(pos) == null)
        return (BuildPlan) null;
      BuildPlan buildPlan;
      if (num1 == 1)
      {
        buildPlan = new BuildPlan((int) Point2.x(pos), (int) Point2.y(pos));
      }
      else
      {
        int id = (int) read.s();
        int rotation = (int) (sbyte) read.b();
        int num2 = read.b() == (byte) 1 ? 1 : 0;
        object obj = TypeIO.readObject(read);
        buildPlan = new BuildPlan((int) Point2.x(pos), (int) Point2.y(pos), rotation, Vars.content.block(id));
        if (num2 != 0)
          buildPlan.config = obj;
      }
      return buildPlan;
    }

    [LineNumberTable(410)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ItemStack readItems(Reads read, ItemStack stack) => stack.set(TypeIO.readItem(read), read.i());

    [LineNumberTable(401)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StatusEntry readStatuse(Reads read) => ((StatusEntry) Pools.obtain((Class) ClassLiteral<StatusEntry>.Value, (Prov) new TypeIO.__\u003C\u003EAnon0())).set((StatusEffect) Vars.content.getByID(ContentType.__\u003C\u003Estatus, (int) read.s()), read.f());

    [LineNumberTable(422)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Team readTeam(Reads read) => Team.get((int) (sbyte) read.b());

    [LineNumberTable(226)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Tile readTile(Reads read) => Vars.world.tile(read.i());

    [LineNumberTable(new byte[] {122, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static WeaponMount[] readMounts(Reads read)
    {
      read.skip((int) (sbyte) read.b() * 9);
      return TypeIO.noMounts;
    }

    [LineNumberTable(new byte[] {161, 145, 99, 103, 137, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeString(Writes write, string @string)
    {
      if (@string != null)
      {
        write.b(1);
        write.str(@string);
      }
      else
        write.b(0);
    }

    [LineNumberTable(new byte[] {160, 64, 191, 1, 104, 120, 99, 137, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeUnit(Writes write, Unit unit)
    {
      write.b(unit == null || unit.isNull() ? 0 : (!(unit is BlockUnitc) ? 2 : 1));
      if (unit is BlockUnitc)
        write.i(((BlockUnitc) unit).tile().pos());
      else if (unit == null)
        write.i(0);
      else
        write.i(unit.id);
    }

    [LineNumberTable(new byte[] {160, 92, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeEntity(Writes write, Entityc entity) => write.i(entity != null ? entity.id() : -1);

    [LineNumberTable(new byte[] {161, 127, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeItem(Writes write, Item item) => write.s(item != null ? (int) item.__\u003C\u003Eid : -1);

    [LineNumberTable(new byte[] {160, 100, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeBuilding(Writes write, Building tile) => write.i(tile != null ? tile.pos() : -1);

    [LineNumberTable(new byte[] {161, 210, 108, 108, 114, 114, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeTraceInfo(Writes write, Administration.TraceInfo trace)
    {
      TypeIO.writeString(write, trace.ip);
      TypeIO.writeString(write, trace.uuid);
      write.b(!trace.modded ? 0 : 1);
      write.b(!trace.mobile ? 0 : 1);
      write.i(trace.timesJoined);
      write.i(trace.timesKicked);
    }

    [LineNumberTable(new byte[] {161, 184, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeBytes(Writes write, byte[] bytes)
    {
      write.s((int) (short) bytes.Length);
      write.b(bytes);
    }

    [LineNumberTable(new byte[] {161, 72, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeUnitType(Writes write, UnitType effect) => write.s((int) effect.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {160, 116, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeBlock(Writes write, Block block) => write.s((int) block.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {160, 251, 103, 108, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeRules(Writes write, Rules rules)
    {
      byte[] bytes = String.instancehelper_getBytes(JsonIO.write((object) rules), Vars.__\u003C\u003Echarset);
      write.i(bytes.Length);
      write.b(bytes);
    }

    [LineNumberTable(new byte[] {161, 194, 105, 111, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeInts(Writes write, int[] ints)
    {
      write.s((int) (short) ints.Length);
      int[] numArray = ints;
      int length = numArray.Length;
      for (int index = 0; index < length; ++index)
      {
        int i = numArray[index];
        write.i(i);
      }
    }

    [LineNumberTable(new byte[] {161, 100, 113, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeContent(Writes write, Content cont)
    {
      write.b(cont.getContentType().ordinal());
      write.s((int) cont.__\u003C\u003Eid);
    }

    [LineNumberTable(new byte[] {160, 243, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeKick(Writes write, Packets.KickReason reason) => write.b((int) (sbyte) reason.ordinal());

    [LineNumberTable(new byte[] {161, 80, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeEffect(Writes write, Effect effect) => write.s(effect.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {161, 88, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeColor(Writes write, Color color) => write.i(color.rgba());

    [LineNumberTable(new byte[] {161, 136, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeWeather(Writes write, Weather item) => write.s(item != null ? (int) item.__\u003C\u003Eid : -1);

    [LineNumberTable(new byte[] {161, 119, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeBulletType(Writes write, BulletType type) => write.s((int) type.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {160, 162, 99, 103, 129, 105, 111, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeRequests(Writes write, BuildPlan[] requests)
    {
      if (requests == null)
      {
        write.s(-1);
      }
      else
      {
        write.s((int) (short) requests.Length);
        BuildPlan[] buildPlanArray = requests;
        int length = buildPlanArray.Length;
        for (int index = 0; index < length; ++index)
        {
          BuildPlan request = buildPlanArray[index];
          TypeIO.writeRequest(write, request);
        }
      }
    }

    [LineNumberTable(new byte[] {161, 64, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeAction(Writes write, Packets.AdminAction reason) => write.b((int) (sbyte) reason.ordinal());

    [LineNumberTable(414)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ItemStack readItems(Reads read)
    {
      ItemStack.__\u003Cclinit\u003E();
      return new ItemStack(TypeIO.readItem(read), read.i());
    }

    [LineNumberTable(466)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color readColor(Reads read, Color color) => color.set(read.i());

    [LineNumberTable(new byte[] {161, 154, 104, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string readString(Reads read) => read.b() != (byte) 0 ? read.str() : (string) null;

    [LineNumberTable(new byte[] {160, 77, 104, 135, 105, 100, 113, 108, 100, 108, 159, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Unit readUnit(Reads read)
    {
      int num1 = (int) (sbyte) read.b();
      int num2 = read.i();
      switch (num1)
      {
        case 0:
          return Nulls.__\u003C\u003Eunit;
        case 1:
          Building building = Vars.world.build(num2);
          ControlBlock controlBlock;
          return building is ControlBlock && object.ReferenceEquals((object) (controlBlock = (ControlBlock) building), (object) (ControlBlock) building) ? controlBlock.unit() : Nulls.__\u003C\u003Eunit;
        case 2:
          return (Unit) Groups.unit.getByID(num2) ?? Nulls.__\u003C\u003Eunit;
        default:
          return Nulls.__\u003C\u003Eunit;
      }
    }

    [LineNumberTable(388)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 readVec2(Reads read, Vec2 @base) => @base.set(read.f(), read.f());

    [LineNumberTable(new byte[] {161, 8, 99, 107, 141, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeVec2(Writes write, Vec2 v)
    {
      if (v == null)
      {
        write.f(0.0f);
        write.f(0.0f);
      }
      else
      {
        write.f(v.x);
        write.f(v.y);
      }
    }

    [Signature("<T::Lmindustry/gen/Entityc;>(Larc/util/io/Reads;)TT;")]
    [LineNumberTable(210)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Entityc readEntity(Reads read) => Groups.sync.getByID(read.i());

    [LineNumberTable(new byte[] {161, 131, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Item readItem(Reads read)
    {
      int id = (int) read.s();
      return id == -1 ? (Item) null : Vars.content.item(id);
    }

    [LineNumberTable(218)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Building readBuilding(Reads read) => Vars.world.build(read.i());

    [LineNumberTable(589)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Administration.TraceInfo readTraceInfo(Reads read) => new Administration.TraceInfo(TypeIO.readString(read), TypeIO.readString(read), read.b() == (byte) 1, read.b() == (byte) 1, read.i(), read.i());

    [LineNumberTable(new byte[] {161, 189, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] readBytes(Reads read)
    {
      int length = (int) read.s();
      return read.b(new byte[length]);
    }

    [LineNumberTable(446)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static UnitType readUnitType(Reads read) => (UnitType) Vars.content.getByID(ContentType.__\u003C\u003Eunit, (int) read.s());

    [LineNumberTable(234)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Block readBlock(Reads read) => Vars.content.block((int) read.s());

    [LineNumberTable(new byte[] {161, 2, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Rules readRules(Reads read)
    {
      int length = read.i();
      string @string = String.newhelper(read.b(new byte[length]), Vars.__\u003C\u003Echarset);
      return (Rules) JsonIO.read((Class) ClassLiteral<Rules>.Value, @string);
    }

    [LineNumberTable(new byte[] {161, 201, 103, 103, 102, 41, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int[] readInts(Reads read)
    {
      int length = (int) read.s();
      int[] numArray = new int[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = read.i();
      return numArray;
    }

    [LineNumberTable(new byte[] {161, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Content readContent(Reads read)
    {
      int index = (int) (sbyte) read.b();
      return Vars.content.getByID(ContentType.__\u003C\u003Eall[index], (int) read.s());
    }

    [LineNumberTable(361)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Packets.KickReason readKick(Reads read) => Packets.KickReason.values()[(int) (sbyte) read.b()];

    [LineNumberTable(454)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Effect readEffect(Reads read) => Effect.get(read.us());

    [LineNumberTable(462)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color readColor(Reads read)
    {
      Color.__\u003Cclinit\u003E();
      return new Color(read.i());
    }

    [LineNumberTable(new byte[] {161, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Weather readWeather(Reads read)
    {
      int id = (int) read.s();
      return id == -1 ? (Weather) null : (Weather) Vars.content.getByID(ContentType.__\u003C\u003Eweather, id);
    }

    [LineNumberTable(493)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BulletType readBulletType(Reads read) => (BulletType) Vars.content.getByID(ContentType.__\u003C\u003Ebullet, (int) read.s());

    [LineNumberTable(new byte[] {160, 173, 103, 100, 162, 103, 102, 103, 99, 228, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static BuildPlan[] readRequests(Reads read)
    {
      int length = (int) read.s();
      if (length == -1)
        return (BuildPlan[]) null;
      BuildPlan[] buildPlanArray = new BuildPlan[length];
      for (int index = 0; index < length; ++index)
      {
        BuildPlan buildPlan = TypeIO.readRequest(read);
        if (buildPlan != null)
          buildPlanArray[index] = buildPlan;
      }
      return buildPlanArray;
    }

    [LineNumberTable(438)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Packets.AdminAction readAction(Reads read) => Packets.AdminAction.values()[(int) (sbyte) read.b()];

    [LineNumberTable(new byte[] {159, 115, 162, 104, 127, 44, 98, 108, 108, 109, 103, 126, 127, 12, 114, 127, 23, 127, 9, 108, 109, 127, 2, 109, 125, 110})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object readObjectBoxed(Reads read, bool box)
    {
      int num1 = box ? 1 : 0;
      int num2 = (int) (sbyte) read.b();
      switch (num2)
      {
        case 0:
          return (object) null;
        case 1:
          return (object) Integer.valueOf(read.i());
        case 2:
          return (object) Long.valueOf(read.l());
        case 3:
          return (object) Float.valueOf(read.f());
        case 4:
          return (object) TypeIO.readString(read);
        case 5:
          return (object) Vars.content.getByID(ContentType.__\u003C\u003Eall[(int) (sbyte) read.b()], (int) read.s());
        case 6:
          int num3 = (int) read.s();
          IntSeq intSeq = new IntSeq();
          for (int index = 0; index < num3; ++index)
            intSeq.add(read.i());
          return (object) intSeq;
        case 7:
          return (object) new Point2(read.i(), read.i());
        case 8:
          int length = (int) (sbyte) read.b();
          Point2[] point2Array = new Point2[length];
          for (int index = 0; index < length; ++index)
            point2Array[index] = Point2.unpack(read.i());
          return (object) point2Array;
        case 9:
          return (object) TechTree.getNotNull((UnlockableContent) Vars.content.getByID(ContentType.__\u003C\u003Eall[(int) (sbyte) read.b()], (int) read.s()));
        case 10:
          return (object) Boolean.valueOf(read.@bool());
        case 11:
          return (object) Double.valueOf(read.d());
        case 12:
          return num1 == 0 ? (object) Vars.world.build(read.i()) : (object) new TypeIO.BuildingBox(read.i());
        case 13:
          return (object) LAccess.__\u003C\u003Eall[(int) read.s()];
        case 14:
          byte[] array = new byte[read.i()];
          read.b(array);
          return (object) array;
        case 15:
          return (object) UnitCommand.__\u003C\u003Eall[(int) (sbyte) read.b()];
        default:
          string str = new StringBuilder().append("Unknown object type: ").append(num2).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TypeIO()
    {
    }

    [LineNumberTable(392)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Vec2 readVec2(Reads read)
    {
      Vec2.__\u003Cclinit\u003E();
      return new Vec2(read.f(), read.f());
    }

    [LineNumberTable(new byte[] {161, 56, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeUnitCommand(Writes write, UnitCommand reason) => write.b((int) (sbyte) reason.ordinal());

    [LineNumberTable(430)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static UnitCommand readUnitCommand(Reads read) => UnitCommand.__\u003C\u003Eall[(int) (sbyte) read.b()];

    [LineNumberTable(new byte[] {161, 110, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeLiquid(Writes write, Liquid liquid) => write.s(liquid != null ? (int) liquid.__\u003C\u003Eid : -1);

    [LineNumberTable(new byte[] {161, 114, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Liquid readLiquid(Reads read)
    {
      int id = (int) read.s();
      return id == -1 ? (Liquid) null : Vars.content.liquid(id);
    }

    [LineNumberTable(new byte[] {161, 163, 99, 108, 106, 104, 98, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeString(ByteBuffer write, string @string)
    {
      if (@string != null)
      {
        byte[] bytes = String.instancehelper_getBytes(@string, Vars.__\u003C\u003Echarset);
        write.putShort((short) bytes.Length);
        write.put(bytes);
      }
      else
        write.putShort((short) -1);
    }

    [LineNumberTable(new byte[] {161, 173, 103, 100, 103, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string readString(ByteBuffer read)
    {
      int length = (int) read.getShort();
      if (length == -1)
        return (string) null;
      byte[] numArray = new byte[length];
      read.get(numArray);
      return String.newhelper(numArray, Vars.__\u003C\u003Echarset);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 223, 99, 108, 105, 103, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void writeStringData(DataOutput buffer, string @string)
    {
      if (@string != null)
      {
        byte[] bytes = String.instancehelper_getBytes(@string, Vars.__\u003C\u003Echarset);
        buffer.writeShort((int) (short) bytes.Length);
        buffer.write(bytes);
      }
      else
        buffer.writeShort(-1);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 233, 103, 100, 103, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string readStringData(DataInput buffer)
    {
      int length = (int) buffer.readShort();
      if (length == -1)
        return (string) null;
      byte[] numArray = new byte[length];
      buffer.readFully(numArray);
      return String.newhelper(numArray, Vars.__\u003C\u003Echarset);
    }

    [LineNumberTable(169)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TypeIO()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.io.TypeIO"))
        return;
      TypeIO.noMounts = new WeaponMount[0];
    }

    public class BuildingBox : Object
    {
      public int pos;

      [LineNumberTable(new byte[] {161, 247, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BuildingBox(int pos)
      {
        TypeIO.BuildingBox buildingBox = this;
        this.pos = pos;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new StatusEntry();
    }
  }
}
