// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LExecutor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.util;
using arc.util.noise;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.ai.types;
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks.logic;
using mindustry.world.blocks.payloads;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  public class LExecutor : Object
  {
    public const int maxInstructions = 1000;
    internal static Simplex __\u003C\u003Enoise;
    public const int varCounter = 0;
    public const int varTime = 1;
    public const int varUnit = 2;
    public const int varThis = 3;
    public const int varTick = 4;
    public const int maxGraphicsBuffer = 256;
    public const int maxDisplayBuffer = 1024;
    public const int maxTextBuffer = 256;
    public LExecutor.LInstruction[] instructions;
    public LExecutor.Var[] vars;
    public int[] binds;
    public LongSeq graphicsBuffer;
    public StringBuilder textBuffer;
    public Building[] links;
    public IntSet linkIds;
    public Team team;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool invalid([In] double obj0) => Double.isNaN(obj0) || Double.isInfinite(obj0);

    [LineNumberTable(new byte[] {33, 118, 140, 246, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(LAssembler builder)
    {
      this.vars = new LExecutor.Var[builder.vars.size];
      this.instructions = builder.instructions;
      builder.vars.each((Cons2) new LExecutor.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LExecutor.Var var(int index) => index < 0 ? Vars.constants.get(-index) : this.vars[index];

    [LineNumberTable(new byte[] {79, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double num(int index)
    {
      LExecutor.Var var = this.var(index);
      return var.isobj ? (var.objval != null ? 1.0 : 0.0) : (LExecutor.invalid(var.numval) ? 0.0 : var.numval);
    }

    [LineNumberTable(new byte[] {97, 104, 105, 105, 103, 137, 105, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setnum(int index, double value)
    {
      LExecutor.Var var = this.var(index);
      if (var.constant)
        return;
      if (LExecutor.invalid(value))
      {
        var.objval = (object) null;
        var.isobj = true;
      }
      else
      {
        var.numval = value;
        var.objval = (object) null;
        var.isobj = false;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {37, 103, 142, 140, 127, 5, 103, 144, 103, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024load\u00240([In] string obj0, [In] LAssembler.BVar obj1)
    {
      LExecutor.Var var = new LExecutor.Var(obj0);
      this.vars[obj1.id] = var;
      var.constant = obj1.constant;
      object obj = obj1.value;
      Number number;
      if (obj is Number && object.ReferenceEquals((object) (number = (Number) obj), (object) (Number) obj))
      {
        var.isobj = false;
        var.numval = number.doubleValue();
      }
      else
      {
        var.isobj = true;
        var.objval = obj1.value;
      }
    }

    [LineNumberTable(new byte[] {159, 170, 232, 83, 108, 172, 107, 107, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LExecutor()
    {
      LExecutor lexecutor = this;
      this.instructions = new LExecutor.LInstruction[0];
      this.vars = new LExecutor.Var[0];
      this.graphicsBuffer = new LongSeq();
      this.textBuffer = new StringBuilder();
      this.links = new Building[0];
      this.linkIds = new IntSet();
      this.team = Team.__\u003C\u003Ederelict;
    }

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool initialized() => this.instructions != null && this.vars != null && this.instructions.Length > 0;

    [LineNumberTable(new byte[] {14, 116, 180, 127, 12, 179, 119, 159, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void runOnce()
    {
      this.vars[1].numval = (double) Time.millis();
      this.vars[4].numval = (double) Time.time;
      if (this.vars[0].numval >= (double) this.instructions.Length || this.vars[0].numval < 0.0)
        this.vars[0].numval = 0.0;
      if (this.vars[0].numval >= (double) this.instructions.Length)
        return;
      LExecutor.LInstruction[] instructions = this.instructions;
      LExecutor.Var var1 = this.vars[0];
      double numval = var1.numval;
      LExecutor.Var var2 = var1;
      double num = numval;
      var2.numval = numval + 1.0;
      int index = ByteCodeHelper.d2i(num);
      instructions[index].run(this);
    }

    [LineNumberTable(new byte[] {28, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(string data) => this.load(LAssembler.assemble(data));

    [LineNumberTable(new byte[] {64, 109})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building building(int index)
    {
      object objval = this.var(index).objval;
      if (this.var(index).isobj)
      {
        object obj = objval;
        Building building;
        if (obj is Building && object.ReferenceEquals((object) (building = (Building) obj), (object) (Building) obj))
          return building;
      }
      return (Building) null;
    }

    [LineNumberTable(new byte[] {69, 109})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object obj(int index)
    {
      object objval = this.var(index).objval;
      return this.var(index).isobj ? objval : (object) null;
    }

    [LineNumberTable(new byte[] {74, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool @bool(int index)
    {
      LExecutor.Var var = this.var(index);
      return var.isobj ? var.objval != null : Math.abs(var.numval) >= 1E-05;
    }

    [LineNumberTable(new byte[] {84, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float numf(int index)
    {
      LExecutor.Var var = this.var(index);
      return var.isobj ? (var.objval != null ? 1f : 0.0f) : (LExecutor.invalid(var.numval) ? 0.0f : (float) var.numval);
    }

    [LineNumberTable(139)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int numi(int index) => ByteCodeHelper.d2i(this.num(index));

    [LineNumberTable(new byte[] {159, 107, 162, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setbool(int index, bool value)
    {
      int num = value ? 1 : 0;
      this.setnum(index, num == 0 ? 0.0 : 1.0);
    }

    [LineNumberTable(new byte[] {110, 104, 105, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setobj(int index, object value)
    {
      LExecutor.Var var = this.var(index);
      if (var.constant)
        return;
      var.objval = value;
      var.isobj = true;
    }

    [LineNumberTable(new byte[] {117, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setconst(int index, object value)
    {
      LExecutor.Var var = this.var(index);
      var.objval = value;
      var.isobj = true;
    }

    [Modifiers]
    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool access\u0024000([In] double obj0) => LExecutor.invalid(obj0);

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LExecutor()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LExecutor"))
        return;
      LExecutor.__\u003C\u003Enoise = new Simplex();
    }

    [Modifiers]
    public static Simplex noise
    {
      [HideFromJava] get => LExecutor.__\u003C\u003Enoise;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate;
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 50, 77, 255, 162, 73, 159, 159})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LExecutor$1"))
          return;
        LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl = new int[LUnitControl.values().Length];
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Emove.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Estop.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Eapproach.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Ewithin.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Epathfind.ordinal()] = 5;
          goto label_22;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_22:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Etarget.ordinal()] = 6;
          goto label_26;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_26:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Etargetp.ordinal()] = 7;
          goto label_30;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_30:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Eboost.ordinal()] = 8;
          goto label_34;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_34:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Eflag.ordinal()] = 9;
          goto label_38;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_38:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Emine.ordinal()] = 10;
          goto label_42;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_42:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003EpayDrop.ordinal()] = 11;
          goto label_46;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_46:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003EpayTake.ordinal()] = 12;
          goto label_50;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_50:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003Ebuild.ordinal()] = 13;
          goto label_54;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_54:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003EgetBlock.ordinal()] = 14;
          goto label_58;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_58:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003EitemDrop.ordinal()] = 15;
          goto label_62;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_62:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[LUnitControl.__\u003C\u003EitemTake.ordinal()] = 16;
          goto label_66;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_66:
        LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate = new int[LLocate.values().Length];
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[LLocate.__\u003C\u003Eore.ordinal()] = 1;
          goto label_71;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_71:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[LLocate.__\u003C\u003Ebuilding.ordinal()] = 2;
          goto label_75;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_75:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[LLocate.__\u003C\u003Espawn.ordinal()] = 3;
          goto label_79;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_79:
        try
        {
          LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[LLocate.__\u003C\u003Edamaged.ordinal()] = 4;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    public class ControlI : Object, LExecutor.LInstruction
    {
      public int target;
      public LAccess type;
      public int p1;
      public int p2;
      public int p3;
      public int p4;

      [LineNumberTable(new byte[] {161, 158, 232, 61, 203, 103, 103, 103, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ControlI(LAccess type, int target, int p1, int p2, int p3, int p4)
      {
        LExecutor.ControlI controlI = this;
        this.type = LAccess.__\u003C\u003Eenabled;
        this.type = type;
        this.target = target;
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.p4 = p4;
      }

      [LineNumberTable(new byte[] {161, 167, 232, 52, 235, 76})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ControlI()
      {
        LExecutor.ControlI controlI = this;
        this.type = LAccess.__\u003C\u003Eenabled;
      }

      [LineNumberTable(new byte[] {161, 171, 109, 127, 50, 109, 159, 34, 191, 33})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        object obj = exec.obj(this.target);
        Building building;
        if (!(obj is Building) || !object.ReferenceEquals((object) (building = (Building) obj), (object) (Building) obj) || (!object.ReferenceEquals((object) building.team, (object) exec.team) || !exec.linkIds.contains(building.id)))
          return;
        if (this.type.__\u003C\u003EisObj)
          building.control(this.type, exec.obj(this.p1), exec.num(this.p2), exec.num(this.p3), exec.num(this.p4));
        else
          building.control(this.type, exec.num(this.p1), exec.num(this.p2), exec.num(this.p3), exec.num(this.p4));
      }
    }

    public class DrawFlushI : Object, LExecutor.LInstruction
    {
      public int target;

      [LineNumberTable(new byte[] {162, 250, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DrawFlushI(int target)
      {
        LExecutor.DrawFlushI drawFlushI = this;
        this.target = target;
      }

      [LineNumberTable(new byte[] {162, 254, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DrawFlushI()
      {
      }

      [LineNumberTable(new byte[] {163, 4, 136, 127, 36, 126, 112, 56, 198, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        if (Vars.headless)
          return;
        Building building = exec.building(this.target);
        LogicDisplay.LogicDisplayBuild logicDisplayBuild;
        if (!(building is LogicDisplay.LogicDisplayBuild) || !object.ReferenceEquals((object) (logicDisplayBuild = (LogicDisplay.LogicDisplayBuild) building), (object) (LogicDisplay.LogicDisplayBuild) building) || !object.ReferenceEquals((object) logicDisplayBuild.team, (object) exec.team))
          return;
        if (logicDisplayBuild.commands.size + exec.graphicsBuffer.size < 1024)
        {
          for (int index = 0; index < exec.graphicsBuffer.size; ++index)
            logicDisplayBuild.commands.addLast(exec.graphicsBuffer.items[index]);
        }
        exec.graphicsBuffer.clear();
      }
    }

    public class DrawI : Object, LExecutor.LInstruction
    {
      public byte type;
      public int target;
      public int x;
      public int y;
      public int p1;
      public int p2;
      public int p3;
      public int p4;

      [LineNumberTable(869)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int packSign([In] int obj0) => Math.abs(obj0) & (int) byte.MaxValue | (obj0 >= 0 ? 0 : 512);

      [LineNumberTable(new byte[] {158, 189, 99, 104, 103, 103, 103, 104, 104, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DrawI(byte type, int target, int x, int y, int p1, int p2, int p3, int p4)
      {
        int num = (int) (sbyte) type;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LExecutor.DrawI drawI = this;
        this.type = (byte) num;
        this.target = target;
        this.x = x;
        this.y = y;
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.p4 = p4;
      }

      [LineNumberTable(new byte[] {162, 222, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DrawI()
      {
      }

      [LineNumberTable(new byte[] {162, 228, 136, 141, 107, 223, 21, 114, 159, 83})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        if (Vars.headless)
          return;
        int num = exec.numi(this.p1);
        if (this.type == (byte) 9)
        {
          object obj = exec.obj(this.p1);
          UnlockableContent unlockableContent;
          num = !(obj is UnlockableContent) || !object.ReferenceEquals((object) (unlockableContent = (UnlockableContent) obj), (object) (UnlockableContent) obj) ? 0 : unlockableContent.iconId;
        }
        if (exec.graphicsBuffer.size >= 256)
          return;
        exec.graphicsBuffer.add(DisplayCmd.get(this.type, LExecutor.DrawI.packSign(exec.numi(this.x)), LExecutor.DrawI.packSign(exec.numi(this.y)), LExecutor.DrawI.packSign(num), LExecutor.DrawI.packSign(exec.numi(this.p2)), LExecutor.DrawI.packSign(exec.numi(this.p3)), LExecutor.DrawI.packSign(exec.numi(this.p4))));
      }
    }

    public class EndI : Object, LExecutor.LInstruction
    {
      [LineNumberTable(819)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public EndI()
      {
      }

      [LineNumberTable(new byte[] {162, 197, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec) => exec.var(0).numval = (double) exec.instructions.Length;
    }

    public class GetLinkI : Object, LExecutor.LInstruction
    {
      public int output;
      public int index;

      [LineNumberTable(new byte[] {161, 185, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GetLinkI(int output, int index)
      {
        LExecutor.GetLinkI getLinkI = this;
        this.index = index;
        this.output = output;
      }

      [LineNumberTable(new byte[] {161, 190, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GetLinkI()
      {
      }

      [LineNumberTable(new byte[] {161, 195, 141, 127, 6})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        int index = exec.numi(this.index);
        exec.setobj(this.output, index < 0 || index >= exec.links.Length ? (object) (Building) null : (object) exec.links[index]);
      }
    }

    public class JumpI : Object, LExecutor.LInstruction
    {
      public ConditionOp op;
      public int value;
      public int compare;
      public int address;

      [LineNumberTable(new byte[] {163, 83, 232, 61, 203, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JumpI(ConditionOp op, int value, int compare, int address)
      {
        LExecutor.JumpI jumpI = this;
        this.op = ConditionOp.__\u003C\u003EnotEqual;
        this.op = op;
        this.value = value;
        this.compare = compare;
        this.address = address;
      }

      [LineNumberTable(new byte[] {163, 90, 232, 54, 235, 75})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JumpI()
      {
        LExecutor.JumpI jumpI = this;
        this.op = ConditionOp.__\u003C\u003EnotEqual;
      }

      [LineNumberTable(new byte[] {163, 95, 108, 109, 173, 114, 127, 42, 157, 159, 12, 191, 12, 99, 180})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        if (this.address == -1)
          return;
        LExecutor.Var var1 = exec.var(this.value);
        LExecutor.Var var2 = exec.var(this.compare);
        if ((!object.ReferenceEquals((object) this.op, (object) ConditionOp.__\u003C\u003EstrictEqual) ? (this.op.__\u003C\u003EobjFunction == null || !var1.isobj || !var2.isobj ? (this.op.__\u003C\u003Efunction.get(exec.num(this.value), exec.num(this.compare)) ? 1 : 0) : (this.op.__\u003C\u003EobjFunction.get(exec.obj(this.value), exec.obj(this.compare)) ? 1 : 0)) : (var1.isobj != var2.isobj || (!var1.isobj || !object.ReferenceEquals(var1.objval, var2.objval)) && (var1.isobj || var1.numval != var2.numval) ? 0 : 1)) == 0)
          return;
        exec.var(0).numval = (double) this.address;
      }
    }

    public interface LInstruction
    {
      void run(LExecutor le);
    }

    public class NoopI : Object, LExecutor.LInstruction
    {
      [LineNumberTable(827)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NoopI()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
      }
    }

    public class OpI : Object, LExecutor.LInstruction
    {
      public LogicOp op;
      public int a;
      public int b;
      public int dest;

      [LineNumberTable(new byte[] {162, 161, 232, 61, 203, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public OpI(LogicOp op, int a, int b, int dest)
      {
        LExecutor.OpI opI = this;
        this.op = LogicOp.__\u003C\u003Eadd;
        this.op = op;
        this.a = a;
        this.b = b;
        this.dest = dest;
      }

      [LineNumberTable(new byte[] {162, 168, 232, 54, 235, 74})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal OpI()
      {
        LExecutor.OpI opI = this;
        this.op = LogicOp.__\u003C\u003Eadd;
      }

      [LineNumberTable(new byte[] {162, 172, 117, 122, 127, 56, 114, 159, 16, 109, 141, 157, 191, 24, 223, 24})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        if (object.ReferenceEquals((object) this.op, (object) LogicOp.__\u003C\u003EstrictEqual))
        {
          LExecutor.Var var1 = exec.var(this.a);
          LExecutor.Var var2 = exec.var(this.b);
          exec.setnum(this.dest, var1.isobj != var2.isobj || (!var1.isobj || !object.ReferenceEquals(var1.objval, var2.objval)) && (var1.isobj || var1.numval != var2.numval) ? 0.0 : 1.0);
        }
        else if (this.op.__\u003C\u003Eunary)
        {
          exec.setnum(this.dest, this.op.__\u003C\u003Efunction1.get(exec.num(this.a)));
        }
        else
        {
          LExecutor.Var var1 = exec.var(this.a);
          LExecutor.Var var2 = exec.var(this.b);
          if (this.op.__\u003C\u003EobjFunction2 != null && var1.isobj && var2.isobj)
            exec.setnum(this.dest, this.op.__\u003C\u003EobjFunction2.get(exec.obj(this.a), exec.obj(this.b)));
          else
            exec.setnum(this.dest, this.op.__\u003C\u003Efunction2.get(exec.num(this.a), exec.num(this.b)));
        }
      }
    }

    public class PrintFlushI : Object, LExecutor.LInstruction
    {
      public int target;

      [LineNumberTable(new byte[] {163, 59, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PrintFlushI(int target)
      {
        LExecutor.PrintFlushI printFlushI = this;
        this.target = target;
      }

      [LineNumberTable(new byte[] {163, 63, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PrintFlushI()
      {
      }

      [LineNumberTable(new byte[] {163, 69, 159, 36, 108, 159, 31, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        Building building = exec.building(this.target);
        MessageBlock.MessageBuild messageBuild;
        if (!(building is MessageBlock.MessageBuild) || !object.ReferenceEquals((object) (messageBuild = (MessageBlock.MessageBuild) building), (object) (MessageBlock.MessageBuild) building) || !object.ReferenceEquals((object) messageBuild.team, (object) exec.team))
          return;
        messageBuild.message.setLength(0);
        StringBuilder message = messageBuild.message;
        StringBuilder textBuffer = exec.textBuffer;
        int num1 = Math.min(exec.textBuffer.length(), 256);
        int num2 = 0;
        object obj = (object) textBuffer;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        int num3 = num2;
        int num4 = num1;
        message.append(charSequence2, num3, num4);
        exec.textBuffer.setLength(0);
      }
    }

    public class PrintI : Object, LExecutor.LInstruction
    {
      public int value;

      [LineNumberTable(new byte[] {163, 20, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PrintI(int value)
      {
        LExecutor.PrintI printI = this;
        this.value = value;
      }

      [LineNumberTable(906)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal PrintI()
      {
      }

      [LineNumberTable(new byte[] {163, 29, 179, 109, 150, 114, 127, 11, 124, 127, 16, 119, 127, 20, 127, 20, 135, 110, 130, 127, 6, 153, 178})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        if (exec.textBuffer.length() >= 256)
          return;
        LExecutor.Var var = exec.var(this.value);
        if (var.isobj && this.value != 0)
        {
          string str1;
          if (var.objval == null)
          {
            str1 = "null";
          }
          else
          {
            object objval1 = var.objval;
            string str2;
            if (objval1 is string && object.ReferenceEquals((object) (str2 = (string) objval1), (object) (string) objval1))
              str1 = str2;
            else if (object.ReferenceEquals(var.objval, (object) Blocks.stoneWall))
            {
              str1 = "solid";
            }
            else
            {
              object objval2 = var.objval;
              MappableContent mappableContent;
              if (objval2 is MappableContent && object.ReferenceEquals((object) (mappableContent = (MappableContent) objval2), (object) (MappableContent) objval2))
                str1 = mappableContent.__\u003C\u003Ename;
              else if (var.objval is Content)
              {
                str1 = "[content]";
              }
              else
              {
                object objval3 = var.objval;
                Building building;
                if (objval3 is Building && object.ReferenceEquals((object) (building = (Building) objval3), (object) (Building) objval3))
                {
                  str1 = building.block.__\u003C\u003Ename;
                }
                else
                {
                  object objval4 = var.objval;
                  Unit unit;
                  str1 = !(objval4 is Unit) || !object.ReferenceEquals((object) (unit = (Unit) objval4), (object) (Unit) objval4) ? "[object]" : unit.type.__\u003C\u003Ename;
                }
              }
            }
          }
          string str3 = str1;
          exec.textBuffer.append(str3);
        }
        else if (Math.abs(var.numval - (double) ByteCodeHelper.d2l(var.numval)) < 1E-06)
          exec.textBuffer.append(ByteCodeHelper.d2l(var.numval));
        else
          exec.textBuffer.append(var.numval);
      }
    }

    public class RadarI : Object, LExecutor.LInstruction
    {
      public RadarTarget target1;
      public RadarTarget target2;
      public RadarTarget target3;
      public RadarSort sort;
      public int radar;
      public int sortOrder;
      public int output;
      public Healthc lastTarget;
      public Interval timer;
      internal static float bestValue;
      internal static Unit best;

      [LineNumberTable(new byte[] {162, 110, 255, 7, 80})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void find([In] Ranged obj0, [In] float obj1, [In] int obj2, [In] Team obj3) => Units.nearby(obj3, obj0.x(), obj0.y(), obj1, (Cons) new LExecutor.RadarI.__\u003C\u003EAnon0(this, obj0, obj1, obj2));

      [Modifiers]
      [LineNumberTable(new byte[] {162, 111, 141, 108, 122, 122, 147, 132, 121, 111, 102, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024find\u00240([In] Ranged obj0, [In] float obj1, [In] int obj2, [In] Unit obj3)
      {
        if (!obj3.within((Position) obj0, obj1) || (!this.target1.__\u003C\u003Efunc.get(obj0.team(), obj3) || !this.target2.__\u003C\u003Efunc.get(obj0.team(), obj3) || !this.target3.__\u003C\u003Efunc.get(obj0.team(), obj3) ? 0 : 1) == 0)
          return;
        float num = this.sort.__\u003C\u003Efunc.get((Position) obj0, obj3) * (float) obj2;
        if ((double) num <= (double) LExecutor.RadarI.bestValue && LExecutor.RadarI.best != null)
          return;
        LExecutor.RadarI.bestValue = num;
        LExecutor.RadarI.best = obj3;
      }

      [LineNumberTable(new byte[] {162, 52, 232, 52, 127, 2, 235, 70, 235, 70, 103, 103, 103, 104, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RadarI(
        RadarTarget target1,
        RadarTarget target2,
        RadarTarget target3,
        RadarSort sort,
        int radar,
        int sortOrder,
        int output)
      {
        LExecutor.RadarI radarI = this;
        this.target1 = RadarTarget.__\u003C\u003Eenemy;
        this.target2 = RadarTarget.__\u003C\u003Eany;
        this.target3 = RadarTarget.__\u003C\u003Eany;
        this.sort = RadarSort.__\u003C\u003Edistance;
        this.timer = new Interval();
        this.target1 = target1;
        this.target2 = target2;
        this.target3 = target3;
        this.sort = sort;
        this.radar = radar;
        this.sortOrder = sortOrder;
        this.output = output;
      }

      [LineNumberTable(new byte[] {162, 62, 232, 42, 127, 2, 235, 70, 235, 80})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RadarI()
      {
        LExecutor.RadarI radarI = this;
        this.target1 = RadarTarget.__\u003C\u003Eenemy;
        this.target2 = RadarTarget.__\u003C\u003Eany;
        this.target3 = RadarTarget.__\u003C\u003Eany;
        this.sort = RadarSort.__\u003C\u003Edistance;
        this.timer = new Interval();
      }

      [LineNumberTable(new byte[] {162, 67, 141, 115, 130, 127, 40, 108, 234, 70, 159, 13, 159, 29, 102, 138, 103, 113, 110, 127, 3, 31, 0, 232, 69, 98, 178, 110, 98, 168, 110, 98, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        object unitObj = exec.obj(this.radar);
        int num1 = !exec.@bool(this.sortOrder) ? -1 : 1;
        LogicAI logicAi = (LogicAI) null;
        object obj1 = unitObj;
        Ranged ranged;
        if (obj1 is Ranged && object.ReferenceEquals((object) (ranged = (Ranged) obj1), (object) (Ranged) obj1) && object.ReferenceEquals((object) ranged.team(), (object) exec.team) && (unitObj is Building || (logicAi = LExecutor.UnitControlI.checkLogicAI(exec, unitObj)) != null))
        {
          float num2 = ranged.range();
          object obj2;
          if (unitObj is Building && this.timer.get(30f) || logicAi != null && logicAi.checkTargetTimer((object) this))
          {
            int num3 = object.ReferenceEquals((object) this.target1, (object) RadarTarget.__\u003C\u003Eenemy) || object.ReferenceEquals((object) this.target2, (object) RadarTarget.__\u003C\u003Eenemy) || object.ReferenceEquals((object) this.target3, (object) RadarTarget.__\u003C\u003Eenemy) ? 1 : 0;
            LExecutor.RadarI.best = (Unit) null;
            LExecutor.RadarI.bestValue = 0.0f;
            if (num3 != 0)
            {
              Seq present = Vars.state.teams.present;
              for (int index = 0; index < present.size; ++index)
              {
                if (!object.ReferenceEquals((object) ((Teams.TeamData[]) present.items)[index].__\u003C\u003Eteam, (object) ranged.team()))
                  this.find(ranged, num2, num1, ((Teams.TeamData[]) present.items)[index].__\u003C\u003Eteam);
              }
            }
            else
              this.find(ranged, num2, num1, ranged.team());
            this.lastTarget = (Healthc) (obj2 = (object) LExecutor.RadarI.best);
          }
          else
            obj2 = (object) this.lastTarget;
          exec.setobj(this.output, obj2);
        }
        else
          exec.setobj(this.output, (object) null);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      static RadarI()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LExecutor$RadarI"))
          return;
        LExecutor.RadarI.bestValue = 0.0f;
        LExecutor.RadarI.best = (Unit) null;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LExecutor.RadarI arg\u00241;
        private readonly Ranged arg\u00242;
        private readonly float arg\u00243;
        private readonly int arg\u00244;

        internal __\u003C\u003EAnon0([In] LExecutor.RadarI obj0, [In] Ranged obj1, [In] float obj2, [In] int obj3)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024find\u00240(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Unit) obj0);
      }
    }

    public class ReadI : Object, LExecutor.LInstruction
    {
      public int target;
      public int position;
      public int output;

      [LineNumberTable(new byte[] {161, 204, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ReadI(int target, int position, int output)
      {
        LExecutor.ReadI readI = this;
        this.target = target;
        this.position = position;
        this.output = output;
      }

      [LineNumberTable(new byte[] {161, 210, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ReadI()
      {
      }

      [LineNumberTable(new byte[] {161, 215, 109, 141, 159, 19, 159, 10})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        int index = exec.numi(this.position);
        Building building1 = exec.building(this.target);
        Building building2 = building1;
        MemoryBlock.MemoryBuild memoryBuild;
        if (!(building2 is MemoryBlock.MemoryBuild) || !object.ReferenceEquals((object) (memoryBuild = (MemoryBlock.MemoryBuild) building2), (object) (MemoryBlock.MemoryBuild) building2) || !object.ReferenceEquals((object) building1.team, (object) exec.team))
          return;
        exec.setnum(this.output, index < 0 || index >= memoryBuild.memory.Length ? 0.0 : memoryBuild.memory[index]);
      }
    }

    public class SenseI : Object, LExecutor.LInstruction
    {
      public int from;
      public int to;
      public int type;

      [LineNumberTable(new byte[] {161, 255, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SenseI(int from, int to, int type)
      {
        LExecutor.SenseI senseI = this;
        this.from = from;
        this.to = to;
        this.type = type;
      }

      [LineNumberTable(new byte[] {162, 5, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SenseI()
      {
      }

      [LineNumberTable(new byte[] {162, 10, 109, 141, 112, 113, 193, 127, 6, 127, 5, 122, 127, 5, 138, 142, 183, 142, 130, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        object obj1 = exec.obj(this.from);
        object objA1 = exec.obj(this.type);
        if (obj1 == null && object.ReferenceEquals(objA1, (object) LAccess.__\u003C\u003Edead))
        {
          exec.setnum(this.to, 1.0);
        }
        else
        {
          object obj2 = obj1;
          Senseable senseable;
          if (obj2 is Senseable && object.ReferenceEquals((object) (senseable = (Senseable) obj2), (object) (Senseable) obj2))
          {
            object obj3 = objA1;
            Content c;
            if (obj3 is Content && object.ReferenceEquals((object) (c = (Content) obj3), (object) (Content) obj3))
            {
              exec.setnum(this.to, senseable.sense(c));
            }
            else
            {
              object obj4 = objA1;
              LAccess laccess;
              if (!(obj4 is LAccess) || !object.ReferenceEquals((object) (laccess = (LAccess) obj4), (object) (LAccess) obj4))
                return;
              object objA2 = senseable.senseObject(laccess);
              if (object.ReferenceEquals(objA2, Senseable.noSensed))
                exec.setnum(this.to, senseable.sense(laccess));
              else
                exec.setobj(this.to, objA2);
            }
          }
          else
            exec.setobj(this.to, (object) null);
        }
      }
    }

    public class SetI : Object, LExecutor.LInstruction
    {
      public int from;
      public int to;

      [LineNumberTable(new byte[] {162, 132, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SetI(int from, int to)
      {
        LExecutor.SetI setI = this;
        this.from = from;
        this.to = to;
      }

      [LineNumberTable(763)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal SetI()
      {
      }

      [LineNumberTable(new byte[] {162, 141, 109, 173, 104, 104, 108, 137, 127, 2, 167})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        LExecutor.Var var1 = exec.var(this.to);
        LExecutor.Var var2 = exec.var(this.from);
        if (var1.constant)
          return;
        if (var2.isobj)
        {
          var1.objval = var2.objval;
          var1.isobj = true;
        }
        else
        {
          var1.numval = !LExecutor.access\u0024000(var2.numval) ? var2.numval : 0.0;
          var1.isobj = false;
        }
      }
    }

    public class UnitBindI : Object, LExecutor.LInstruction
    {
      public int type;

      [LineNumberTable(new byte[] {160, 84, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitBindI(int type)
      {
        LExecutor.UnitBindI unitBindI = this;
        this.type = type;
      }

      [LineNumberTable(new byte[] {160, 88, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitBindI()
      {
      }

      [LineNumberTable(new byte[] {160, 94, 127, 1, 218, 127, 17, 146, 113, 127, 8, 149, 154, 187, 136, 159, 34, 139, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        if (exec.binds == null || exec.binds.Length != Vars.content.units().size)
          exec.binds = new int[Vars.content.units().size];
        object obj1 = exec.obj(this.type);
        UnitType type;
        if (obj1 is UnitType && object.ReferenceEquals((object) (type = (UnitType) obj1), (object) (UnitType) obj1))
        {
          Seq seq = exec.team.data().unitCache(type);
          if (seq != null && seq.any())
          {
            int[] binds1 = exec.binds;
            int id1 = (int) type.__\u003C\u003Eid;
            int[] numArray1 = binds1;
            int[] numArray2 = numArray1;
            int index = id1;
            int num1 = numArray1[id1];
            int size = seq.size;
            int num2 = size != -1 ? num1 % size : 0;
            numArray2[index] = num2;
            if (exec.binds[(int) type.__\u003C\u003Eid] < seq.size)
              exec.setconst(2, seq.get(exec.binds[(int) type.__\u003C\u003Eid]));
            int[] binds2 = exec.binds;
            int id2 = (int) type.__\u003C\u003Eid;
            int[] numArray3 = binds2;
            numArray3[id2] = numArray3[id2] + 1;
          }
          else
            exec.setconst(2, (object) null);
        }
        else
        {
          object obj2 = exec.obj(this.type);
          Unit unit;
          if (obj2 is Unit && object.ReferenceEquals((object) (unit = (Unit) obj2), (object) (Unit) obj2) && object.ReferenceEquals((object) unit.team, (object) exec.team))
            exec.setconst(2, (object) unit);
          else
            exec.setconst(2, (object) null);
        }
      }
    }

    public class UnitControlI : Object, LExecutor.LInstruction
    {
      public LUnitControl type;
      public int p1;
      public int p2;
      public int p3;
      public int p4;
      public int p5;

      [LineNumberTable(new byte[] {160, 226, 127, 73, 127, 5, 130, 103, 142, 136, 103, 134, 163})]
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static LogicAI checkLogicAI(LExecutor exec, object unitObj)
      {
        object obj = unitObj;
        Unit unit;
        if (!(obj is Unit) || !object.ReferenceEquals((object) (unit = (Unit) obj), (object) (Unit) obj) || (!object.ReferenceEquals(exec.obj(2), (object) unit) || !object.ReferenceEquals((object) unit.team, (object) exec.team)) || (unit.isPlayer() || unit.controller() is FormationAI))
          return (LogicAI) null;
        UnitController unitController = unit.controller();
        LogicAI logicAi1;
        if (unitController is LogicAI && object.ReferenceEquals((object) (logicAi1 = (LogicAI) unitController), (object) (LogicAI) unitController))
          return logicAi1;
        LogicAI logicAi2 = new LogicAI();
        logicAi2.controller = exec.building(3);
        unit.controller((UnitController) logicAi2);
        unit.mineTile = (Tile) null;
        unit.clearBuilding();
        return logicAi2;
      }

      [Modifiers]
      [LineNumberTable(426)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024run\u00240([In] Payloadc obj0, [In] Unit obj1, [In] Unit obj2) => obj2.isAI() && obj2.isGrounded() && (obj0.canPickup(obj2) && obj2.within((Position) obj1, obj2.hitSize + obj1.hitSize * 1.2f));

      [LineNumberTable(new byte[] {160, 211, 232, 61, 203, 103, 103, 103, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitControlI(LUnitControl type, int p1, int p2, int p3, int p4, int p5)
      {
        LExecutor.UnitControlI unitControlI = this;
        this.type = LUnitControl.__\u003C\u003Emove;
        this.type = type;
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.p4 = p4;
        this.p5 = p5;
      }

      [LineNumberTable(new byte[] {160, 220, 232, 52, 235, 77})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitControlI()
      {
        LExecutor.UnitControlI unitControlI = this;
        this.type = LUnitControl.__\u003C\u003Emove;
      }

      [LineNumberTable(new byte[] {160, 246, 104, 168, 127, 12, 107, 159, 32, 159, 62, 108, 104, 104, 114, 200, 117, 103, 203, 63, 7, 197, 44, 197, 111, 108, 103, 242, 60, 229, 71, 108, 127, 27, 242, 61, 229, 70, 50, 197, 52, 197, 112, 104, 245, 61, 229, 71, 142, 127, 14, 114, 235, 59, 229, 73, 142, 159, 11, 110, 159, 25, 100, 136, 101, 184, 126, 127, 13, 139, 105, 111, 233, 69, 235, 38, 229, 94, 127, 53, 127, 19, 174, 127, 32, 112, 108, 172, 110, 116, 159, 63, 102, 141, 127, 14, 103, 236, 43, 229, 90, 116, 110, 109, 146, 144, 127, 17, 110, 255, 4, 54, 229, 78, 142, 110, 126, 127, 58, 114, 101, 124, 235, 55, 229, 78, 142, 110, 142, 127, 23, 127, 61, 159, 5, 101, 108, 235, 52, 226, 83})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        object unitObj = exec.obj(2);
        LogicAI logicAi1 = LExecutor.UnitControlI.checkLogicAI(exec, unitObj);
        object obj1 = unitObj;
        Unit unit1;
        if (!(obj1 is Unit) || !object.ReferenceEquals((object) (unit1 = (Unit) obj1), (object) (Unit) obj1) || logicAi1 == null)
          return;
        logicAi1.controlTimer = 600f;
        float x = World.unconv(exec.numf(this.p1));
        float y = World.unconv(exec.numf(this.p2));
        float num1 = World.unconv(exec.numf(this.p3));
        switch (LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LUnitControl[this.type.ordinal()])
        {
          case 1:
          case 2:
          case 3:
            logicAi1.control = this.type;
            logicAi1.moveX = x;
            logicAi1.moveY = y;
            if (object.ReferenceEquals((object) this.type, (object) LUnitControl.__\u003C\u003Eapproach))
              logicAi1.moveRad = num1;
            if (!object.ReferenceEquals((object) this.type, (object) LUnitControl.__\u003C\u003Estop))
              break;
            unit1.mineTile = (Tile) null;
            unit1.clearBuilding();
            break;
          case 4:
            exec.setnum(this.p4, !unit1.within(x, y, num1) ? 0.0 : 1.0);
            break;
          case 5:
            logicAi1.control = this.type;
            break;
          case 6:
            logicAi1.posTarget.set(x, y);
            logicAi1.aimControl = this.type;
            logicAi1.mainTarget = (Teamc) null;
            logicAi1.shoot = exec.@bool(this.p3);
            break;
          case 7:
            logicAi1.aimControl = this.type;
            LogicAI logicAi2 = logicAi1;
            object obj2 = exec.obj(this.p1);
            Teamc teamc1;
            Teamc teamc2 = !(obj2 is Teamc) || !object.ReferenceEquals((object) (teamc1 = (Teamc) obj2), (object) (Teamc) obj2) ? (Teamc) null : teamc1;
            logicAi2.mainTarget = teamc2;
            logicAi1.shoot = exec.@bool(this.p2);
            break;
          case 8:
            logicAi1.boost = exec.@bool(this.p1);
            break;
          case 9:
            unit1.flag = exec.num(this.p1);
            break;
          case 10:
            Tile tile1 = Vars.world.tileWorld(x, y);
            if (!unit1.canMine())
              break;
            unit1.mineTile = !unit1.validMine(tile1) ? (Tile) null : tile1;
            break;
          case 11:
            if ((double) logicAi1.payTimer > 0.0)
              break;
            Unit unit2 = unit1;
            Payloadc payloadc1;
            if (!(unit2 is Payloadc) || !object.ReferenceEquals((object) (payloadc1 = (Payloadc) unit2), (object) (Payloadc) unit2) || !payloadc1.hasPayload())
              break;
            Call.payloadDropped(unit1, unit1.x, unit1.y);
            logicAi1.payTimer = 120f;
            break;
          case 12:
            if ((double) logicAi1.payTimer > 0.0)
              break;
            Unit unit3 = unit1;
            Payloadc payloadc2;
            if (!(unit3 is Payloadc) || !object.ReferenceEquals((object) (payloadc2 = (Payloadc) unit3), (object) (Payloadc) unit3))
              break;
            if (exec.@bool(this.p1))
            {
              Unit target = Units.closest(unit1.team, unit1.x, unit1.y, unit1.type.hitSize * 2f, (Boolf) new LExecutor.UnitControlI.__\u003C\u003EAnon0(payloadc2, unit1));
              if (target != null)
                Call.pickedUnitPayload(unit1, target);
            }
            else
            {
              Building building = Vars.world.buildWorld(unit1.x, unit1.y);
              if (building != null && object.ReferenceEquals((object) building.team, (object) unit1.team))
              {
                if (!object.ReferenceEquals((object) building.block.buildVisibility, (object) BuildVisibility.__\u003C\u003Ehidden) && building.canPickup() && payloadc2.canPickup(building))
                {
                  Call.pickedBuildPayload(unit1, building, true);
                }
                else
                {
                  Payload payload = building.getPayload();
                  if (payload != null && payloadc2.canPickupPayload(payload))
                    Call.pickedBuildPayload(unit1, building, false);
                }
              }
            }
            logicAi1.payTimer = 120f;
            break;
          case 13:
            if (!Vars.state.rules.logicUnitBuild || !unit1.canBuild())
              break;
            object obj3 = exec.obj(this.p3);
            Block block1;
            if (!(obj3 is Block) || !object.ReferenceEquals((object) (block1 = (Block) obj3), (object) (Block) obj3))
              break;
            int tile2 = World.toTile(x - block1.offset / 8f);
            int tile3 = World.toTile(y - block1.offset / 8f);
            int rotation = exec.numi(this.p4);
            if (logicAi1.plan.x != tile2 || logicAi1.plan.y != tile3 || (!object.ReferenceEquals((object) logicAi1.plan.block, (object) block1) || unit1.plans.isEmpty()))
            {
              logicAi1.plan.progress = 0.0f;
              logicAi1.plan.initialized = false;
              logicAi1.plan.stuck = false;
            }
            object obj4 = exec.obj(this.p5);
            logicAi1.plan.set(tile2, tile3, rotation, block1);
            BuildPlan plan = logicAi1.plan;
            object obj5 = obj4;
            Content content;
            Object @object;
            if (obj5 is Content && object.ReferenceEquals((object) (content = (Content) obj5), (object) (Content) obj5))
            {
              @object = (Object) content;
            }
            else
            {
              object obj6 = obj4;
              Building building;
              @object = !(obj6 is Building) || !object.ReferenceEquals((object) (building = (Building) obj6), (object) (Building) obj6) ? (Object) null : (Object) building;
            }
            plan.config = (object) @object;
            unit1.clearBuilding();
            Tile tile4 = logicAi1.plan.tile();
            if (tile4 == null || object.ReferenceEquals((object) tile4.block(), (object) block1) && tile4.build != null && tile4.build.rotation == rotation)
              break;
            unit1.updateBuilding = true;
            unit1.addBuild(logicAi1.plan);
            break;
          case 14:
            float num2 = Math.max(unit1.range(), 220f);
            if (!unit1.within(x, y, num2))
            {
              exec.setobj(this.p3, (object) null);
              exec.setobj(this.p4, (object) null);
              break;
            }
            Tile tile5 = Vars.world.tileWorld(x, y);
            Block block2 = tile5 != null ? (tile5.synthetic() ? tile5.block() : (!tile5.solid() ? Blocks.air : Blocks.stoneWall)) : (Block) null;
            exec.setobj(this.p3, (object) block2);
            exec.setobj(this.p4, tile5 == null || tile5.build == null ? (object) (Building) null : (object) tile5.build);
            break;
          case 15:
            if ((double) logicAi1.itemTimer > 0.0)
              break;
            Building build1 = exec.building(this.p1);
            int amount1 = Math.min(unit1.stack.amount, exec.numi(this.p2));
            if (build1 == null || !object.ReferenceEquals((object) build1.team, (object) unit1.team) || (!build1.isValid() || amount1 <= 0) || !unit1.within((Position) build1, 45f + (float) (build1.block.size * 8) / 2f))
              break;
            int amount2 = build1.acceptStack(unit1.item(), amount1, (Teamc) unit1);
            if (amount2 <= 0)
              break;
            Call.transferItemTo(unit1, unit1.item(), amount2, unit1.x, unit1.y, build1);
            logicAi1.itemTimer = 120f;
            break;
          case 16:
            if ((double) logicAi1.itemTimer > 0.0)
              break;
            Building build2 = exec.building(this.p1);
            int num3 = exec.numi(this.p3);
            if (build2 == null || !object.ReferenceEquals((object) build2.team, (object) unit1.team) || (!build2.isValid() || build2.items == null))
              break;
            object obj7 = exec.obj(this.p2);
            Item obj8;
            if (!(obj7 is Item) || !object.ReferenceEquals((object) (obj8 = (Item) obj7), (object) (Item) obj7) || !unit1.within((Position) build2, 45f + (float) (build2.block.size * 8) / 2f))
              break;
            int amount3 = Math.min(build2.items.get(obj8), Math.min(num3, unit1.maxAccepted(obj8)));
            if (amount3 <= 0)
              break;
            Call.takeItems(build2, obj8, amount3, unit1);
            logicAi1.itemTimer = 120f;
            break;
        }
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Boolf
      {
        private readonly Payloadc arg\u00241;
        private readonly Unit arg\u00242;

        internal __\u003C\u003EAnon0([In] Payloadc obj0, [In] Unit obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public bool get([In] object obj0) => (LExecutor.UnitControlI.lambda\u0024run\u00240(this.arg\u00241, this.arg\u00242, (Unit) obj0) ? 1 : 0) != 0;
      }
    }

    public class UnitLocateI : Object, LExecutor.LInstruction
    {
      public LLocate locate;
      public BlockFlag flag;
      public int enemy;
      public int ore;
      public int outX;
      public int outY;
      public int outFound;
      public int outBuild;

      [LineNumberTable(new byte[] {160, 129, 232, 59, 107, 235, 69, 103, 103, 103, 104, 104, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitLocateI(
        LLocate locate,
        BlockFlag flag,
        int enemy,
        int ore,
        int outX,
        int outY,
        int outFound,
        int outBuild)
      {
        LExecutor.UnitLocateI unitLocateI = this;
        this.locate = LLocate.__\u003C\u003Ebuilding;
        this.flag = BlockFlag.__\u003C\u003Ecore;
        this.locate = locate;
        this.flag = flag;
        this.enemy = enemy;
        this.ore = ore;
        this.outX = outX;
        this.outY = outY;
        this.outFound = outFound;
        this.outBuild = outBuild;
      }

      [LineNumberTable(new byte[] {160, 140, 232, 48, 107, 235, 80})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitLocateI()
      {
        LExecutor.UnitLocateI unitLocateI = this;
        this.locate = LLocate.__\u003C\u003Ebuilding;
        this.flag = BlockFlag.__\u003C\u003Ecore;
      }

      [LineNumberTable(new byte[] {160, 145, 104, 136, 127, 12, 139, 157, 108, 99, 131, 159, 14, 127, 16, 15, 229, 70, 127, 72, 3, 226, 69, 63, 3, 194, 121, 112, 195, 119, 136, 127, 31, 127, 31, 147, 104, 145, 127, 46, 98, 115, 115, 116, 148, 98, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        object unitObj = exec.obj(2);
        LogicAI logicAi = LExecutor.UnitControlI.checkLogicAI(exec, unitObj);
        object obj1 = unitObj;
        Unit unit;
        if (obj1 is Unit && object.ReferenceEquals((object) (unit = (Unit) obj1), (object) (Unit) obj1) && logicAi != null)
        {
          logicAi.controlTimer = 600f;
          LExecutor.UnitLocateI.Cache cache1 = (LExecutor.UnitLocateI.Cache) logicAi.execCache.get((object) this, (Prov) new LExecutor.UnitLocateI.__\u003C\u003EAnon0());
          if (logicAi.checkTargetTimer((object) this))
          {
            Tile tile = (Tile) null;
            int num1 = 0;
            switch (LExecutor.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[this.locate.ordinal()])
            {
              case 1:
                object obj2 = exec.obj(this.ore);
                Item obj3;
                if (obj2 is Item && object.ReferenceEquals((object) (obj3 = (Item) obj2), (object) (Item) obj2))
                {
                  tile = Vars.indexer.findClosestOre(unit, obj3);
                  break;
                }
                break;
              case 2:
                double x = (double) unit.x;
                double y = (double) unit.y;
                Object @object = !exec.@bool(this.enemy) ? (Object) Vars.indexer.getAllied(unit.team, this.flag) : (Object) Vars.indexer.getEnemy(unit.team, this.flag);
                Iterable list;
                if (@object != null)
                  list = @object is Iterable iterable7 ? iterable7 : throw new IncompatibleClassChangeError();
                else
                  list = (Iterable) null;
                tile = (Tile) Geometry.findClosest((float) x, (float) y, list);
                num1 = 1;
                break;
              case 3:
                tile = (Tile) Geometry.findClosest(unit.x, unit.y, (Iterable) Vars.spawner.getSpawns());
                break;
              case 4:
                tile = Units.findDamagedTile(unit.team, unit.x, unit.y)?.tile;
                num1 = 1;
                break;
            }
            if (tile != null && (num1 == 0 || tile.build != null))
            {
              cache1.found = true;
              LExecutor lexecutor1 = exec;
              int outX = this.outX;
              LExecutor.UnitLocateI.Cache cache2 = cache1;
              float num2 = World.conv(num1 == 0 ? tile.worldx() : tile.build.x);
              LExecutor.UnitLocateI.Cache cache3 = cache2;
              double num3 = (double) num2;
              cache3.x = num2;
              double num4 = num3;
              lexecutor1.setnum(outX, num4);
              LExecutor lexecutor2 = exec;
              int outY = this.outY;
              LExecutor.UnitLocateI.Cache cache4 = cache1;
              float num5 = World.conv(num1 == 0 ? tile.worldy() : tile.build.y);
              LExecutor.UnitLocateI.Cache cache5 = cache4;
              double num6 = (double) num5;
              cache5.y = num5;
              double num7 = num6;
              lexecutor2.setnum(outY, num7);
              exec.setnum(this.outFound, 1.0);
            }
            else
            {
              cache1.found = false;
              exec.setnum(this.outFound, 0.0);
            }
            LExecutor lexecutor = exec;
            int outBuild = this.outBuild;
            Building building1;
            if (tile != null && tile.build != null && object.ReferenceEquals((object) tile.build.team, (object) exec.team))
            {
              LExecutor.UnitLocateI.Cache cache2 = cache1;
              Building build = tile.build;
              LExecutor.UnitLocateI.Cache cache3 = cache2;
              Building building2 = build;
              cache3.build = build;
              building1 = building2;
            }
            else
              building1 = (Building) null;
            lexecutor.setobj(outBuild, (object) building1);
          }
          else
          {
            exec.setobj(this.outBuild, (object) cache1.build);
            exec.setbool(this.outFound, cache1.found);
            exec.setnum(this.outX, (double) cache1.x);
            exec.setnum(this.outY, (double) cache1.y);
          }
        }
        else
          exec.setbool(this.outFound, false);
      }

      internal class Cache : Object
      {
        internal float x;
        internal float y;
        internal bool found;
        internal Building build;

        [LineNumberTable(313)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal Cache()
        {
        }
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Prov
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get() => (object) new LExecutor.UnitLocateI.Cache();
      }
    }

    public class Var : Object
    {
      internal string __\u003C\u003Ename;
      public bool isobj;
      public bool constant;
      public object objval;
      public double numval;

      [LineNumberTable(new byte[] {160, 69, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Var(string name)
      {
        LExecutor.Var var = this;
        this.__\u003C\u003Ename = name;
      }

      [Modifiers]
      public string name
      {
        [HideFromJava] get => this.__\u003C\u003Ename;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ename = value;
      }
    }

    public class WaitI : Object, LExecutor.LInstruction
    {
      public int value;
      public float curTime;
      public double wait;
      public long frameId;

      [LineNumberTable(new byte[] {163, 123, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WaitI(int value)
      {
        LExecutor.WaitI waitI = this;
        this.value = value;
      }

      [LineNumberTable(new byte[] {163, 127, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WaitI()
      {
      }

      [LineNumberTable(new byte[] {163, 133, 118, 173, 186, 114, 122, 144})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        if ((double) this.curTime >= exec.num(this.value))
          this.curTime = 0.0f;
        else
          --exec.var(0).numval;
        if (Core.graphics.getFrameId() == this.frameId)
          return;
        this.curTime += Time.delta / 60f;
        this.frameId = Core.graphics.getFrameId();
      }
    }

    public class WriteI : Object, LExecutor.LInstruction
    {
      public int target;
      public int position;
      public int value;

      [LineNumberTable(new byte[] {161, 228, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WriteI(int target, int position, int value)
      {
        LExecutor.WriteI writeI = this;
        this.target = target;
        this.position = position;
        this.value = value;
      }

      [LineNumberTable(new byte[] {161, 234, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WriteI()
      {
      }

      [LineNumberTable(new byte[] {161, 239, 109, 141, 159, 19, 110, 214})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run(LExecutor exec)
      {
        int index = exec.numi(this.position);
        Building building1 = exec.building(this.target);
        Building building2 = building1;
        MemoryBlock.MemoryBuild memoryBuild;
        if (!(building2 is MemoryBlock.MemoryBuild) || !object.ReferenceEquals((object) (memoryBuild = (MemoryBlock.MemoryBuild) building2), (object) (MemoryBlock.MemoryBuild) building2) || (!object.ReferenceEquals((object) building1.team, (object) exec.team) || index < 0) || index >= memoryBuild.memory.Length)
          return;
        memoryBuild.memory[index] = exec.num(this.value);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons2
    {
      private readonly LExecutor arg\u00241;

      internal __\u003C\u003EAnon0([In] LExecutor obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024load\u00240((string) obj0, (LAssembler.BVar) obj1);
    }
  }
}
