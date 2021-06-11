// Decompiled with JetBrains decompiler
// Type: mindustry.gen.LogicIO
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.logic;
using mindustry.world.blocks.logic;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public class LogicIO : Object
  {
    [Signature("Larc/struct/Seq<Larc/func/Prov<Lmindustry/logic/LStatement;>;>;")]
    public static Seq allStatements;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LogicIO()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 120, 113, 120, 108, 108, 114, 108, 114, 108, 119, 120, 108, 108, 114, 108, 114, 108, 119, 123, 108, 108, 119, 108, 114, 108, 114, 108, 114, 108, 114, 108, 114, 108, 119, 120, 108, 108, 119, 120, 108, 108, 119, 120, 108, 108, 119, 120, 108, 108, 114, 108, 119, 123, 108, 108, 119, 108, 114, 108, 114, 108, 114, 108, 114, 108, 119, 123, 108, 108, 119, 108, 119, 108, 119, 108, 119, 108, 114, 108, 114, 108, 119, 120, 108, 108, 114, 108, 114, 108, 119, 120, 108, 108, 114, 108, 119, 123, 108, 108, 119, 108, 114, 108, 114, 108, 119, 120, 113, 123, 108, 108, 114, 108, 119, 108, 114, 108, 119, 120, 108, 108, 119, 123, 108, 108, 119, 108, 114, 108, 114, 108, 114, 108, 114, 108, 119, 123, 108, 108, 119, 108, 119, 108, 119, 108, 119, 108, 114, 108, 114, 108, 119, 123, 108, 108, 119, 108, 119, 108, 114, 108, 114, 108, 114, 108, 114, 108, 114, 108, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void write(object obj, StringBuilder @out)
    {
      if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.InvalidStatement)))
        @out.append("noop");
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.ReadStatement)))
      {
        @out.append("read");
        @out.append(" ");
        @out.append(((LStatements.ReadStatement) obj).output);
        @out.append(" ");
        @out.append(((LStatements.ReadStatement) obj).target);
        @out.append(" ");
        @out.append(((LStatements.ReadStatement) obj).address);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.WriteStatement)))
      {
        @out.append(nameof (write));
        @out.append(" ");
        @out.append(((LStatements.WriteStatement) obj).input);
        @out.append(" ");
        @out.append(((LStatements.WriteStatement) obj).target);
        @out.append(" ");
        @out.append(((LStatements.WriteStatement) obj).address);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.DrawStatement)))
      {
        @out.append("draw");
        @out.append(" ");
        @out.append(((LStatements.DrawStatement) obj).type.name());
        @out.append(" ");
        @out.append(((LStatements.DrawStatement) obj).x);
        @out.append(" ");
        @out.append(((LStatements.DrawStatement) obj).y);
        @out.append(" ");
        @out.append(((LStatements.DrawStatement) obj).p1);
        @out.append(" ");
        @out.append(((LStatements.DrawStatement) obj).p2);
        @out.append(" ");
        @out.append(((LStatements.DrawStatement) obj).p3);
        @out.append(" ");
        @out.append(((LStatements.DrawStatement) obj).p4);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.PrintStatement)))
      {
        @out.append("print");
        @out.append(" ");
        @out.append(((LStatements.PrintStatement) obj).value);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.DrawFlushStatement)))
      {
        @out.append("drawflush");
        @out.append(" ");
        @out.append(((LStatements.DrawFlushStatement) obj).target);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.PrintFlushStatement)))
      {
        @out.append("printflush");
        @out.append(" ");
        @out.append(((LStatements.PrintFlushStatement) obj).target);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.GetLinkStatement)))
      {
        @out.append("getlink");
        @out.append(" ");
        @out.append(((LStatements.GetLinkStatement) obj).output);
        @out.append(" ");
        @out.append(((LStatements.GetLinkStatement) obj).address);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.ControlStatement)))
      {
        @out.append("control");
        @out.append(" ");
        @out.append(((LStatements.ControlStatement) obj).type.name());
        @out.append(" ");
        @out.append(((LStatements.ControlStatement) obj).target);
        @out.append(" ");
        @out.append(((LStatements.ControlStatement) obj).p1);
        @out.append(" ");
        @out.append(((LStatements.ControlStatement) obj).p2);
        @out.append(" ");
        @out.append(((LStatements.ControlStatement) obj).p3);
        @out.append(" ");
        @out.append(((LStatements.ControlStatement) obj).p4);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.RadarStatement)))
      {
        @out.append("radar");
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).target1.name());
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).target2.name());
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).target3.name());
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).sort.name());
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).radar);
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).sortOrder);
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).output);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.SensorStatement)))
      {
        @out.append("sensor");
        @out.append(" ");
        @out.append(((LStatements.SensorStatement) obj).to);
        @out.append(" ");
        @out.append(((LStatements.SensorStatement) obj).from);
        @out.append(" ");
        @out.append(((LStatements.SensorStatement) obj).type);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.SetStatement)))
      {
        @out.append("set");
        @out.append(" ");
        @out.append(((LStatements.SetStatement) obj).to);
        @out.append(" ");
        @out.append(((LStatements.SetStatement) obj).from);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.OperationStatement)))
      {
        @out.append("op");
        @out.append(" ");
        @out.append(((LStatements.OperationStatement) obj).op.name());
        @out.append(" ");
        @out.append(((LStatements.OperationStatement) obj).dest);
        @out.append(" ");
        @out.append(((LStatements.OperationStatement) obj).a);
        @out.append(" ");
        @out.append(((LStatements.OperationStatement) obj).b);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.EndStatement)))
        @out.append("end");
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.JumpStatement)))
      {
        @out.append("jump");
        @out.append(" ");
        @out.append(((LStatements.JumpStatement) obj).destIndex);
        @out.append(" ");
        @out.append(((LStatements.JumpStatement) obj).op.name());
        @out.append(" ");
        @out.append(((LStatements.JumpStatement) obj).value);
        @out.append(" ");
        @out.append(((LStatements.JumpStatement) obj).compare);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.UnitBindStatement)))
      {
        @out.append("ubind");
        @out.append(" ");
        @out.append(((LStatements.UnitBindStatement) obj).type);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.UnitControlStatement)))
      {
        @out.append("ucontrol");
        @out.append(" ");
        @out.append(((LStatements.UnitControlStatement) obj).type.name());
        @out.append(" ");
        @out.append(((LStatements.UnitControlStatement) obj).p1);
        @out.append(" ");
        @out.append(((LStatements.UnitControlStatement) obj).p2);
        @out.append(" ");
        @out.append(((LStatements.UnitControlStatement) obj).p3);
        @out.append(" ");
        @out.append(((LStatements.UnitControlStatement) obj).p4);
        @out.append(" ");
        @out.append(((LStatements.UnitControlStatement) obj).p5);
      }
      else if (object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.UnitRadarStatement)))
      {
        @out.append("uradar");
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).target1.name());
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).target2.name());
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).target3.name());
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).sort.name());
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).radar);
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).sortOrder);
        @out.append(" ");
        @out.append(((LStatements.RadarStatement) obj).output);
      }
      else
      {
        if (!object.ReferenceEquals((object) obj.GetType(), (object) typeof (LStatements.UnitLocateStatement)))
          return;
        @out.append("ulocate");
        @out.append(" ");
        @out.append(((LStatements.UnitLocateStatement) obj).locate.name());
        @out.append(" ");
        @out.append(((LStatements.UnitLocateStatement) obj).flag.name());
        @out.append(" ");
        @out.append(((LStatements.UnitLocateStatement) obj).enemy);
        @out.append(" ");
        @out.append(((LStatements.UnitLocateStatement) obj).ore);
        @out.append(" ");
        @out.append(((LStatements.UnitLocateStatement) obj).outX);
        @out.append(" ");
        @out.append(((LStatements.UnitLocateStatement) obj).outY);
        @out.append(" ");
        @out.append(((LStatements.UnitLocateStatement) obj).outFound);
        @out.append(" ");
        @out.append(((LStatements.UnitLocateStatement) obj).outBuild);
      }
    }

    [LineNumberTable(new byte[] {160, 72, 111, 102, 102, 98, 111, 102, 109, 109, 109, 102, 98, 111, 102, 109, 109, 109, 102, 98, 114, 102, 114, 109, 109, 109, 109, 109, 109, 102, 98, 111, 103, 110, 103, 99, 111, 103, 110, 103, 99, 111, 103, 110, 103, 99, 111, 103, 110, 110, 103, 99, 114, 103, 115, 110, 110, 110, 110, 110, 103, 99, 114, 103, 115, 115, 115, 115, 110, 110, 110, 103, 99, 111, 103, 110, 110, 110, 103, 99, 111, 103, 110, 110, 103, 99, 111, 103, 115, 110, 110, 110, 103, 99, 111, 103, 103, 99, 111, 103, 120, 115, 110, 110, 103, 99, 111, 103, 110, 103, 99, 114, 103, 115, 110, 110, 110, 110, 110, 103, 99, 114, 103, 115, 115, 115, 115, 110, 110, 110, 103, 99, 114, 103, 115, 115, 110, 110, 110, 110, 110, 110, 103, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LStatement read(string[] tokens, int length)
    {
      if (String.instancehelper_equals(tokens[0], (object) "noop"))
      {
        LStatements.InvalidStatement invalidStatement = new LStatements.InvalidStatement();
        invalidStatement.afterRead();
        return (LStatement) invalidStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) nameof (read)))
      {
        LStatements.ReadStatement readStatement = new LStatements.ReadStatement();
        if (length > 1)
          readStatement.output = tokens[1];
        if (length > 2)
          readStatement.target = tokens[2];
        if (length > 3)
          readStatement.address = tokens[3];
        readStatement.afterRead();
        return (LStatement) readStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "write"))
      {
        LStatements.WriteStatement writeStatement = new LStatements.WriteStatement();
        if (length > 1)
          writeStatement.input = tokens[1];
        if (length > 2)
          writeStatement.target = tokens[2];
        if (length > 3)
          writeStatement.address = tokens[3];
        writeStatement.afterRead();
        return (LStatement) writeStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "draw"))
      {
        LStatements.DrawStatement drawStatement = new LStatements.DrawStatement();
        if (length > 1)
          drawStatement.type = LogicDisplay.GraphicsType.valueOf(tokens[1]);
        if (length > 2)
          drawStatement.x = tokens[2];
        if (length > 3)
          drawStatement.y = tokens[3];
        if (length > 4)
          drawStatement.p1 = tokens[4];
        if (length > 5)
          drawStatement.p2 = tokens[5];
        if (length > 6)
          drawStatement.p3 = tokens[6];
        if (length > 7)
          drawStatement.p4 = tokens[7];
        drawStatement.afterRead();
        return (LStatement) drawStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "print"))
      {
        LStatements.PrintStatement printStatement = new LStatements.PrintStatement();
        if (length > 1)
          printStatement.value = tokens[1];
        printStatement.afterRead();
        return (LStatement) printStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "drawflush"))
      {
        LStatements.DrawFlushStatement drawFlushStatement = new LStatements.DrawFlushStatement();
        if (length > 1)
          drawFlushStatement.target = tokens[1];
        drawFlushStatement.afterRead();
        return (LStatement) drawFlushStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "printflush"))
      {
        LStatements.PrintFlushStatement printFlushStatement = new LStatements.PrintFlushStatement();
        if (length > 1)
          printFlushStatement.target = tokens[1];
        printFlushStatement.afterRead();
        return (LStatement) printFlushStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "getlink"))
      {
        LStatements.GetLinkStatement getLinkStatement = new LStatements.GetLinkStatement();
        if (length > 1)
          getLinkStatement.output = tokens[1];
        if (length > 2)
          getLinkStatement.address = tokens[2];
        getLinkStatement.afterRead();
        return (LStatement) getLinkStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "control"))
      {
        LStatements.ControlStatement controlStatement = new LStatements.ControlStatement();
        if (length > 1)
          controlStatement.type = LAccess.valueOf(tokens[1]);
        if (length > 2)
          controlStatement.target = tokens[2];
        if (length > 3)
          controlStatement.p1 = tokens[3];
        if (length > 4)
          controlStatement.p2 = tokens[4];
        if (length > 5)
          controlStatement.p3 = tokens[5];
        if (length > 6)
          controlStatement.p4 = tokens[6];
        controlStatement.afterRead();
        return (LStatement) controlStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "radar"))
      {
        LStatements.RadarStatement radarStatement = new LStatements.RadarStatement();
        if (length > 1)
          radarStatement.target1 = RadarTarget.valueOf(tokens[1]);
        if (length > 2)
          radarStatement.target2 = RadarTarget.valueOf(tokens[2]);
        if (length > 3)
          radarStatement.target3 = RadarTarget.valueOf(tokens[3]);
        if (length > 4)
          radarStatement.sort = RadarSort.valueOf(tokens[4]);
        if (length > 5)
          radarStatement.radar = tokens[5];
        if (length > 6)
          radarStatement.sortOrder = tokens[6];
        if (length > 7)
          radarStatement.output = tokens[7];
        radarStatement.afterRead();
        return (LStatement) radarStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "sensor"))
      {
        LStatements.SensorStatement sensorStatement = new LStatements.SensorStatement();
        if (length > 1)
          sensorStatement.to = tokens[1];
        if (length > 2)
          sensorStatement.from = tokens[2];
        if (length > 3)
          sensorStatement.type = tokens[3];
        sensorStatement.afterRead();
        return (LStatement) sensorStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "set"))
      {
        LStatements.SetStatement setStatement = new LStatements.SetStatement();
        if (length > 1)
          setStatement.to = tokens[1];
        if (length > 2)
          setStatement.from = tokens[2];
        setStatement.afterRead();
        return (LStatement) setStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "op"))
      {
        LStatements.OperationStatement operationStatement = new LStatements.OperationStatement();
        if (length > 1)
          operationStatement.op = LogicOp.valueOf(tokens[1]);
        if (length > 2)
          operationStatement.dest = tokens[2];
        if (length > 3)
          operationStatement.a = tokens[3];
        if (length > 4)
          operationStatement.b = tokens[4];
        operationStatement.afterRead();
        return (LStatement) operationStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "end"))
      {
        LStatements.EndStatement endStatement = new LStatements.EndStatement();
        endStatement.afterRead();
        return (LStatement) endStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "jump"))
      {
        LStatements.JumpStatement jumpStatement = new LStatements.JumpStatement();
        if (length > 1)
          jumpStatement.destIndex = Integer.valueOf(tokens[1]).intValue();
        if (length > 2)
          jumpStatement.op = ConditionOp.valueOf(tokens[2]);
        if (length > 3)
          jumpStatement.value = tokens[3];
        if (length > 4)
          jumpStatement.compare = tokens[4];
        jumpStatement.afterRead();
        return (LStatement) jumpStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "ubind"))
      {
        LStatements.UnitBindStatement unitBindStatement = new LStatements.UnitBindStatement();
        if (length > 1)
          unitBindStatement.type = tokens[1];
        unitBindStatement.afterRead();
        return (LStatement) unitBindStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "ucontrol"))
      {
        LStatements.UnitControlStatement controlStatement = new LStatements.UnitControlStatement();
        if (length > 1)
          controlStatement.type = LUnitControl.valueOf(tokens[1]);
        if (length > 2)
          controlStatement.p1 = tokens[2];
        if (length > 3)
          controlStatement.p2 = tokens[3];
        if (length > 4)
          controlStatement.p3 = tokens[4];
        if (length > 5)
          controlStatement.p4 = tokens[5];
        if (length > 6)
          controlStatement.p5 = tokens[6];
        controlStatement.afterRead();
        return (LStatement) controlStatement;
      }
      if (String.instancehelper_equals(tokens[0], (object) "uradar"))
      {
        LStatements.UnitRadarStatement unitRadarStatement = new LStatements.UnitRadarStatement();
        if (length > 1)
          unitRadarStatement.target1 = RadarTarget.valueOf(tokens[1]);
        if (length > 2)
          unitRadarStatement.target2 = RadarTarget.valueOf(tokens[2]);
        if (length > 3)
          unitRadarStatement.target3 = RadarTarget.valueOf(tokens[3]);
        if (length > 4)
          unitRadarStatement.sort = RadarSort.valueOf(tokens[4]);
        if (length > 5)
          unitRadarStatement.radar = tokens[5];
        if (length > 6)
          unitRadarStatement.sortOrder = tokens[6];
        if (length > 7)
          unitRadarStatement.output = tokens[7];
        unitRadarStatement.afterRead();
        return (LStatement) unitRadarStatement;
      }
      if (!String.instancehelper_equals(tokens[0], (object) "ulocate"))
        return (LStatement) null;
      LStatements.UnitLocateStatement unitLocateStatement = new LStatements.UnitLocateStatement();
      if (length > 1)
        unitLocateStatement.locate = LLocate.valueOf(tokens[1]);
      if (length > 2)
        unitLocateStatement.flag = BlockFlag.valueOf(tokens[2]);
      if (length > 3)
        unitLocateStatement.enemy = tokens[3];
      if (length > 4)
        unitLocateStatement.ore = tokens[4];
      if (length > 5)
        unitLocateStatement.outX = tokens[5];
      if (length > 6)
        unitLocateStatement.outY = tokens[6];
      if (length > 7)
        unitLocateStatement.outFound = tokens[7];
      if (length > 8)
        unitLocateStatement.outBuild = tokens[8];
      unitLocateStatement.afterRead();
      return (LStatement) unitLocateStatement;
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LogicIO()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.gen.LogicIO"))
        return;
      LogicIO.allStatements = Seq.with((object[]) new Prov[19]
      {
        (Prov) new LogicIO.__\u003C\u003EAnon0(),
        (Prov) new LogicIO.__\u003C\u003EAnon1(),
        (Prov) new LogicIO.__\u003C\u003EAnon2(),
        (Prov) new LogicIO.__\u003C\u003EAnon3(),
        (Prov) new LogicIO.__\u003C\u003EAnon4(),
        (Prov) new LogicIO.__\u003C\u003EAnon5(),
        (Prov) new LogicIO.__\u003C\u003EAnon6(),
        (Prov) new LogicIO.__\u003C\u003EAnon7(),
        (Prov) new LogicIO.__\u003C\u003EAnon8(),
        (Prov) new LogicIO.__\u003C\u003EAnon9(),
        (Prov) new LogicIO.__\u003C\u003EAnon10(),
        (Prov) new LogicIO.__\u003C\u003EAnon11(),
        (Prov) new LogicIO.__\u003C\u003EAnon12(),
        (Prov) new LogicIO.__\u003C\u003EAnon13(),
        (Prov) new LogicIO.__\u003C\u003EAnon14(),
        (Prov) new LogicIO.__\u003C\u003EAnon15(),
        (Prov) new LogicIO.__\u003C\u003EAnon16(),
        (Prov) new LogicIO.__\u003C\u003EAnon17(),
        (Prov) new LogicIO.__\u003C\u003EAnon18()
      });
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new LStatements.InvalidStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new LStatements.ReadStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new LStatements.WriteStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Prov
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get() => (object) new LStatements.DrawStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Prov
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get() => (object) new LStatements.PrintStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Prov
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public object get() => (object) new LStatements.DrawFlushStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Prov
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public object get() => (object) new LStatements.PrintFlushStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Prov
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public object get() => (object) new LStatements.GetLinkStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Prov
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public object get() => (object) new LStatements.ControlStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) new LStatements.RadarStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Prov
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public object get() => (object) new LStatements.SensorStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Prov
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public object get() => (object) new LStatements.SetStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public object get() => (object) new LStatements.OperationStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Prov
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public object get() => (object) new LStatements.EndStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Prov
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public object get() => (object) new LStatements.JumpStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Prov
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public object get() => (object) new LStatements.UnitBindStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Prov
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public object get() => (object) new LStatements.UnitControlStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Prov
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public object get() => (object) new LStatements.UnitRadarStatement();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Prov
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public object get() => (object) new LStatements.UnitLocateStatement();
    }
  }
}
