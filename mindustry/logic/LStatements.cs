// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LStatements
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.blocks.logic;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  public class LStatements : Object
  {
    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LStatements()
    {
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType;
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {158, 169, 141, 255, 160, 85, 157, 16})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LStatements$1"))
          return;
        LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate = new int[LLocate.values().Length];
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[LLocate.__\u003C\u003Ebuilding.ordinal()] = 1;
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
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[LLocate.__\u003C\u003Eore.ordinal()] = 2;
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
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[LLocate.__\u003C\u003Espawn.ordinal()] = 3;
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
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[LLocate.__\u003C\u003Edamaged.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType = new int[LogicDisplay.GraphicsType.values().Length];
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003Eclear.ordinal()] = 1;
          goto label_23;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_23:
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003Ecolor.ordinal()] = 2;
          goto label_27;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_27:
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003Estroke.ordinal()] = 3;
          goto label_31;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_31:
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003Eline.ordinal()] = 4;
          goto label_35;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_35:
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003Erect.ordinal()] = 5;
          goto label_39;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_39:
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003ElineRect.ordinal()] = 6;
          goto label_43;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_43:
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003Epoly.ordinal()] = 7;
          goto label_47;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_47:
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003ElinePoly.ordinal()] = 8;
          goto label_51;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_51:
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003Etriangle.ordinal()] = 9;
          goto label_55;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_55:
        try
        {
          LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[LogicDisplay.GraphicsType.__\u003C\u003Eimage.ordinal()] = 10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    public class CommentStatement : LStatement
    {
      public string comment;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.comment = obj0;

      [LineNumberTable(new byte[] {159, 167, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CommentStatement()
      {
        LStatements.CommentStatement commentStatement = this;
        this.comment = "";
      }

      [LineNumberTable(new byte[] {159, 172, 127, 44})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table) => table.area(this.comment, Styles.nodeArea, (Cons) new LStatements.CommentStatement.__\u003C\u003EAnon0(this)).growX().height(90f).padLeft(2f).padRight(6f).color(table.__\u003C\u003Ecolor);

      [LineNumberTable(35)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicControl;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) null;

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.CommentStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.CommentStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }
    }

    public class ControlStatement : LStatement
    {
      public LAccess type;
      public string target;
      public string p1;
      public string p2;
      public string p3;
      public string p4;

      [LineNumberTable(new byte[] {160, 221, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ControlStatement()
      {
        LStatements.ControlStatement controlStatement = this;
        this.type = LAccess.__\u003C\u003Eenabled;
        this.target = "block1";
        this.p1 = "0";
        this.p2 = "0";
        this.p3 = "0";
        this.p4 = "0";
      }

      [LineNumberTable(new byte[] {160, 231, 134, 135, 156, 255, 12, 70, 159, 1, 159, 13, 153, 199, 98, 148, 159, 92, 249, 60, 233, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void rebuild([In] Table obj0)
      {
        obj0.clearChildren();
        obj0.left();
        Table table1 = obj0;
        object obj1 = (object) " set ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence text1 = charSequence;
        table1.add(text1);
        obj0.button((Cons) new LStatements.ControlStatement.__\u003C\u003EAnon0(this, obj0), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.ControlStatement.__\u003C\u003EAnon1()).size(90f, 40f).color(obj0.__\u003C\u003Ecolor).left().padLeft(2f);
        Table table2 = obj0;
        object obj2 = (object) " of ";
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text2 = charSequence;
        table2.add(text2).self((Cons) new LStatements.ControlStatement.__\u003C\u003EAnon2(this));
        this.field(obj0, this.target, (Cons) new LStatements.ControlStatement.__\u003C\u003EAnon3(this));
        this.row(obj0);
        int num1 = 0;
        for (int index = 0; index < this.type.__\u003C\u003Eparams.Length; ++index)
        {
          Table table3 = obj0;
          string desc = this.type.__\u003C\u003Eparams[index];
          string str;
          switch (index)
          {
            case 0:
              str = this.p1;
              break;
            case 1:
              str = this.p2;
              break;
            case 2:
              str = this.p3;
              break;
            default:
              str = this.p4;
              break;
          }
          Cons setter;
          switch (index)
          {
            case 0:
              setter = (Cons) new LStatements.ControlStatement.__\u003C\u003EAnon4(this);
              break;
            case 1:
              setter = (Cons) new LStatements.ControlStatement.__\u003C\u003EAnon5(this);
              break;
            case 2:
              setter = (Cons) new LStatements.ControlStatement.__\u003C\u003EAnon6(this);
              break;
            default:
              setter = (Cons) new LStatements.ControlStatement.__\u003C\u003EAnon7(this);
              break;
          }
          this.fields(table3, desc, str, setter);
          ++num1;
          int num2 = num1;
          int num3 = 2;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            this.row(obj0);
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 238, 114, 212})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00244([In] Table obj0, [In] Button obj1)
      {
        obj1.label((Prov) new LStatements.ControlStatement.__\u003C\u003EAnon8(this));
        obj1.clicked((Runnable) new LStatements.ControlStatement.__\u003C\u003EAnon9(this, obj1, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00245()
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00246([In] string obj0) => this.target = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00247([In] string obj0) => this.p1 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00248([In] string obj0) => this.p2 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00249([In] string obj0) => this.p3 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002410([In] string obj0) => this.p4 = obj0;

      [Modifiers]
      [LineNumberTable(352)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024rebuild\u00240()
      {
        object obj = (object) this.type.name();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(353)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00243([In] Button obj0, [In] Table obj1) => this.showSelect(obj0, (Enum[]) LAccess.__\u003C\u003Econtrols, (Enum) this.type, (Cons) new LStatements.ControlStatement.__\u003C\u003EAnon10(this, obj1), 2, (Cons) new LStatements.ControlStatement.__\u003C\u003EAnon11());

      [Modifiers]
      [LineNumberTable(new byte[] {160, 240, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00241([In] Table obj0, [In] LAccess obj1)
      {
        this.type = obj1;
        this.rebuild(obj0);
      }

      [Modifiers]
      [LineNumberTable(356)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00242([In] Cell obj0) => obj0.size(100f, 50f);

      [LineNumberTable(new byte[] {160, 227, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table) => this.rebuild(table);

      [LineNumberTable(378)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicBlocks;

      [LineNumberTable(383)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.ControlI(this.type, builder.var(this.target), builder.var(this.p1), builder.var(this.p2), builder.var(this.p3), builder.var(this.p4));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.ControlStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon0([In] LStatements.ControlStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00244(this.arg\u00242, (Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void run() => LStatements.ControlStatement.lambda\u0024rebuild\u00245();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly LStatements.ControlStatement arg\u00241;

        internal __\u003C\u003EAnon2([In] LStatements.ControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.param((Cell) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly LStatements.ControlStatement arg\u00241;

        internal __\u003C\u003EAnon3([In] LStatements.ControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00246((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        private readonly LStatements.ControlStatement arg\u00241;

        internal __\u003C\u003EAnon4([In] LStatements.ControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00247((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly LStatements.ControlStatement arg\u00241;

        internal __\u003C\u003EAnon5([In] LStatements.ControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00248((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Cons
      {
        private readonly LStatements.ControlStatement arg\u00241;

        internal __\u003C\u003EAnon6([In] LStatements.ControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00249((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Cons
      {
        private readonly LStatements.ControlStatement arg\u00241;

        internal __\u003C\u003EAnon7([In] LStatements.ControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002410((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Prov
      {
        private readonly LStatements.ControlStatement arg\u00241;

        internal __\u003C\u003EAnon8([In] LStatements.ControlStatement obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024rebuild\u00240().__\u003Cref\u003E;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Runnable
      {
        private readonly LStatements.ControlStatement arg\u00241;
        private readonly Button arg\u00242;
        private readonly Table arg\u00243;

        internal __\u003C\u003EAnon9([In] LStatements.ControlStatement obj0, [In] Button obj1, [In] Table obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u00243(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : Cons
      {
        private readonly LStatements.ControlStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon10([In] LStatements.ControlStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00241(this.arg\u00242, (LAccess) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon11 : Cons
      {
        internal __\u003C\u003EAnon11()
        {
        }

        public void get([In] object obj0) => LStatements.ControlStatement.lambda\u0024rebuild\u00242((Cell) obj0);
      }
    }

    public class DrawFlushStatement : LStatement
    {
      public string target;

      [LineNumberTable(new byte[] {160, 155, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DrawFlushStatement()
      {
        LStatements.DrawFlushStatement drawFlushStatement = this;
        this.target = "display1";
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.target = obj0;

      [LineNumberTable(new byte[] {160, 160, 124, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        Table table1 = table;
        object obj = (object) " to ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text);
        this.field(table, this.target, (Cons) new LStatements.DrawFlushStatement.__\u003C\u003EAnon0(this));
      }

      [LineNumberTable(280)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicBlocks;

      [LineNumberTable(285)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.DrawFlushI(builder.var(this.target));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.DrawFlushStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.DrawFlushStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }
    }

    public class DrawStatement : LStatement
    {
      public LogicDisplay.GraphicsType type;
      public string x;
      public string y;
      public string p1;
      public string p2;
      public string p3;
      public string p4;

      [LineNumberTable(new byte[] {77, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DrawStatement()
      {
        LStatements.DrawStatement drawStatement = this;
        this.type = LogicDisplay.GraphicsType.__\u003C\u003Eclear;
        this.x = "0";
        this.y = "0";
        this.p1 = "0";
        this.p2 = "0";
        this.p3 = "0";
        this.p4 = "0";
      }

      [LineNumberTable(new byte[] {160, 118, 127, 5, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void afterRead()
      {
        if (!object.ReferenceEquals((object) this.type, (object) LogicDisplay.GraphicsType.__\u003C\u003Ecolor) || !String.instancehelper_equals(this.p2, (object) "0"))
          return;
        this.p2 = "255";
      }

      [LineNumberTable(new byte[] {87, 134, 135, 255, 12, 79, 159, 1, 114, 167, 242, 160, 64, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void rebuild([In] Table obj0)
      {
        obj0.clearChildren();
        obj0.left();
        obj0.button((Cons) new LStatements.DrawStatement.__\u003C\u003EAnon0(this, obj0), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.DrawStatement.__\u003C\u003EAnon1()).size(90f, 40f).color(obj0.__\u003C\u003Ecolor).left().padLeft(2f);
        if (!object.ReferenceEquals((object) this.type, (object) LogicDisplay.GraphicsType.__\u003C\u003Estroke))
          this.row(obj0);
        obj0.table((Cons) new LStatements.DrawStatement.__\u003C\u003EAnon2(this, obj0)).expand().left();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {92, 114, 244, 77})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00244([In] Table obj0, [In] Button obj1)
      {
        obj1.label((Prov) new LStatements.DrawStatement.__\u003C\u003EAnon35(this));
        obj1.clicked((Runnable) new LStatements.DrawStatement.__\u003C\u003EAnon36(this, obj1, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00245()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {113, 103, 140, 159, 38, 126, 126, 254, 61, 229, 70, 126, 126, 126, 103, 254, 59, 229, 72, 113, 24, 229, 69, 126, 126, 103, 126, 254, 59, 229, 72, 126, 126, 103, 126, 254, 59, 229, 72, 126, 126, 103, 126, 126, 103, 254, 57, 229, 74, 126, 126, 103, 126, 126, 103, 126, 254, 56, 229, 75, 126, 126, 103, 126, 126, 103, 190})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002438([In] Table obj0, [In] Table obj1)
      {
        obj1.left();
        obj1.setColor(obj0.__\u003C\u003Ecolor);
        switch (LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024world\u0024blocks\u0024logic\u0024LogicDisplay\u0024GraphicsType[this.type.ordinal()])
        {
          case 1:
            this.fields(obj1, "r", this.x, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon3(this));
            this.fields(obj1, "g", this.y, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon4(this));
            this.fields(obj1, "b", this.p1, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon5(this));
            break;
          case 2:
            this.fields(obj1, "r", this.x, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon6(this));
            this.fields(obj1, "g", this.y, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon7(this));
            this.fields(obj1, "b", this.p1, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon8(this));
            this.row(obj1);
            this.fields(obj1, "a", this.p2, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon9(this));
            break;
          case 3:
            obj1.add().width(4f);
            this.fields(obj1, this.x, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon10(this));
            break;
          case 4:
            this.fields(obj1, "x", this.x, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon11(this));
            this.fields(obj1, "y", this.y, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon12(this));
            this.row(obj1);
            this.fields(obj1, "x2", this.p1, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon13(this));
            this.fields(obj1, "y2", this.p2, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon14(this));
            break;
          case 5:
          case 6:
            this.fields(obj1, "x", this.x, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon15(this));
            this.fields(obj1, "y", this.y, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon16(this));
            this.row(obj1);
            this.fields(obj1, "width", this.p1, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon17(this));
            this.fields(obj1, "height", this.p2, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon18(this));
            break;
          case 7:
          case 8:
            this.fields(obj1, "x", this.x, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon19(this));
            this.fields(obj1, "y", this.y, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon20(this));
            this.row(obj1);
            this.fields(obj1, "sides", this.p1, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon21(this));
            this.fields(obj1, "radius", this.p2, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon22(this));
            this.row(obj1);
            this.fields(obj1, "rotation", this.p3, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon23(this));
            break;
          case 9:
            this.fields(obj1, "x", this.x, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon24(this));
            this.fields(obj1, "y", this.y, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon25(this));
            this.row(obj1);
            this.fields(obj1, "x2", this.p1, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon26(this));
            this.fields(obj1, "y2", this.p2, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon27(this));
            this.row(obj1);
            this.fields(obj1, "x3", this.p3, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon28(this));
            this.fields(obj1, "y3", this.p4, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon29(this));
            break;
          case 10:
            this.fields(obj1, "x", this.x, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon30(this));
            this.fields(obj1, "y", this.y, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon31(this));
            this.row(obj1);
            this.fields(obj1, "image", this.p1, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon32(this));
            this.fields(obj1, "size", this.p2, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon33(this));
            this.row(obj1);
            this.fields(obj1, "rotation", this.p3, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon34(this));
            break;
        }
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00246([In] string obj0) => this.x = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00247([In] string obj0) => this.y = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00248([In] string obj0) => this.p1 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00249([In] string obj0) => this.x = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002410([In] string obj0) => this.y = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002411([In] string obj0) => this.p1 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002412([In] string obj0) => this.p2 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002413([In] string obj0) => this.x = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002414([In] string obj0) => this.x = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002415([In] string obj0) => this.y = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002416([In] string obj0) => this.p1 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002417([In] string obj0) => this.p2 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002418([In] string obj0) => this.x = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002419([In] string obj0) => this.y = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002420([In] string obj0) => this.p1 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002421([In] string obj0) => this.p2 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002422([In] string obj0) => this.x = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002423([In] string obj0) => this.y = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002424([In] string obj0) => this.p1 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002425([In] string obj0) => this.p2 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002426([In] string obj0) => this.p3 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002427([In] string obj0) => this.x = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002428([In] string obj0) => this.y = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002429([In] string obj0) => this.p1 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002430([In] string obj0) => this.p2 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002431([In] string obj0) => this.p3 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002432([In] string obj0) => this.p4 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002433([In] string obj0) => this.x = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002434([In] string obj0) => this.y = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002435([In] string obj0) => this.p1 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002436([In] string obj0) => this.p2 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002437([In] string obj0) => this.p3 = obj0;

      [Modifiers]
      [LineNumberTable(142)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024rebuild\u00240()
      {
        object obj = (object) this.type.name();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(143)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00243([In] Button obj0, [In] Table obj1) => this.showSelect(obj0, (Enum[]) LogicDisplay.GraphicsType.__\u003C\u003Eall, (Enum) this.type, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon37(this, obj1), 2, (Cons) new LStatements.DrawStatement.__\u003C\u003EAnon38());

      [Modifiers]
      [LineNumberTable(new byte[] {94, 103, 114, 171, 114, 107, 107, 139, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00241([In] Table obj0, [In] LogicDisplay.GraphicsType obj1)
      {
        this.type = obj1;
        if (object.ReferenceEquals((object) this.type, (object) LogicDisplay.GraphicsType.__\u003C\u003Ecolor))
          this.p2 = "255";
        if (object.ReferenceEquals((object) this.type, (object) LogicDisplay.GraphicsType.__\u003C\u003Eimage))
        {
          this.p1 = "@copper";
          this.p2 = "32";
          this.p3 = "0";
        }
        this.rebuild(obj0);
      }

      [Modifiers]
      [LineNumberTable(155)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00242([In] Cell obj0) => obj0.size(100f, 50f);

      [LineNumberTable(new byte[] {83, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table) => this.rebuild(table);

      [LineNumberTable(239)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicIo;

      [LineNumberTable(244)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.DrawI((byte) this.type.ordinal(), 0, builder.var(this.x), builder.var(this.y), builder.var(this.p1), builder.var(this.p2), builder.var(this.p3), builder.var(this.p4));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon0([In] LStatements.DrawStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00244(this.arg\u00242, (Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void run() => LStatements.DrawStatement.lambda\u0024rebuild\u00245();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon2([In] LStatements.DrawStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002438(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon3([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00246((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon4([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00247((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon5([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00248((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon6([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00249((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon7([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002410((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon8([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002411((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon9([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002412((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon10([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002413((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon11 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon11([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002414((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon12 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon12([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002415((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon13 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon13([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002416((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon14 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon14([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002417((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon15 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon15([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002418((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon16 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon16([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002419((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon17 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon17([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002420((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon18 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon18([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002421((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon19 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon19([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002422((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon20 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon20([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002423((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon21 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon21([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002424((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon22 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon22([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002425((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon23 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon23([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002426((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon24 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon24([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002427((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon25 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon25([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002428((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon26 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon26([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002429((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon27 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon27([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002430((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon28 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon28([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002431((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon29 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon29([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002432((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon30 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon30([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002433((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon31 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon31([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002434((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon32 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon32([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002435((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon33 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon33([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002436((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon34 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon34([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002437((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon35 : Prov
      {
        private readonly LStatements.DrawStatement arg\u00241;

        internal __\u003C\u003EAnon35([In] LStatements.DrawStatement obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024rebuild\u00240().__\u003Cref\u003E;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon36 : Runnable
      {
        private readonly LStatements.DrawStatement arg\u00241;
        private readonly Button arg\u00242;
        private readonly Table arg\u00243;

        internal __\u003C\u003EAnon36([In] LStatements.DrawStatement obj0, [In] Button obj1, [In] Table obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u00243(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon37 : Cons
      {
        private readonly LStatements.DrawStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon37([In] LStatements.DrawStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00241(this.arg\u00242, (LogicDisplay.GraphicsType) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon38 : Cons
      {
        internal __\u003C\u003EAnon38()
        {
        }

        public void get([In] object obj0) => LStatements.DrawStatement.lambda\u0024rebuild\u00242((Cell) obj0);
      }
    }

    public class EndStatement : LStatement
    {
      [LineNumberTable(687)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public EndStatement()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
      }

      [LineNumberTable(695)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.EndI();

      [LineNumberTable(700)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicControl;
    }

    public class GetLinkStatement : LStatement
    {
      public string output;
      public string address;

      [LineNumberTable(new byte[] {160, 197, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public GetLinkStatement()
      {
        LStatements.GetLinkStatement getLinkStatement = this;
        this.output = "result";
        this.address = "0";
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.output = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00241([In] string obj0) => this.address = obj0;

      [LineNumberTable(new byte[] {160, 202, 153, 156, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        this.field(table, this.output, (Cons) new LStatements.GetLinkStatement.__\u003C\u003EAnon0(this));
        Table table1 = table;
        object obj = (object) " = link# ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text);
        this.field(table, this.address, (Cons) new LStatements.GetLinkStatement.__\u003C\u003EAnon1(this));
      }

      [LineNumberTable(325)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicBlocks;

      [LineNumberTable(330)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.GetLinkI(builder.var(this.output), builder.var(this.address));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.GetLinkStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.GetLinkStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LStatements.GetLinkStatement arg\u00241;

        internal __\u003C\u003EAnon1([In] LStatements.GetLinkStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241((string) obj0);
      }
    }

    public class InvalidStatement : LStatement
    {
      [LineNumberTable(45)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public InvalidStatement()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
      }

      [LineNumberTable(53)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicOperations;

      [LineNumberTable(58)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.NoopI();
    }

    public class JumpStatement : LStatement
    {
      private static Color last;
      [NonSerialized]
      public LCanvas.StatementElem dest;
      public int destIndex;
      public ConditionOp op;
      public string value;
      public string compare;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {162, 79, 232, 71, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public JumpStatement()
      {
        LStatements.JumpStatement jumpStatement = this;
        this.op = ConditionOp.__\u003C\u003EnotEqual;
        this.value = "x";
        this.compare = "false";
      }

      [LineNumberTable(new byte[] {162, 101, 102, 139, 159, 12, 255, 2, 70, 159, 31, 127, 12})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void rebuild([In] Table obj0)
      {
        obj0.clearChildren();
        obj0.setColor(LStatements.JumpStatement.last);
        if (!object.ReferenceEquals((object) this.op, (object) ConditionOp.__\u003C\u003Ealways))
          this.field(obj0, this.value, (Cons) new LStatements.JumpStatement.__\u003C\u003EAnon3(this));
        obj0.button((Cons) new LStatements.JumpStatement.__\u003C\u003EAnon4(this, obj0), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.JumpStatement.__\u003C\u003EAnon5()).size(!object.ReferenceEquals((object) this.op, (object) ConditionOp.__\u003C\u003Ealways) ? 48f : 80f, 40f).pad(4f).color(obj0.__\u003C\u003Ecolor);
        if (object.ReferenceEquals((object) this.op, (object) ConditionOp.__\u003C\u003Ealways))
          return;
        this.field(obj0, this.compare, (Cons) new LStatements.JumpStatement.__\u003C\u003EAnon6(this));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LCanvas.StatementElem lambda\u0024build\u00240() => this.dest;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00241([In] LCanvas.StatementElem obj0) => this.dest = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00242([In] string obj0) => this.value = obj0;

      [Modifiers]
      [LineNumberTable(new byte[] {162, 107, 114, 212})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00246([In] Table obj0, [In] Button obj1)
      {
        obj1.label((Prov) new LStatements.JumpStatement.__\u003C\u003EAnon7(this));
        obj1.clicked((Runnable) new LStatements.JumpStatement.__\u003C\u003EAnon8(this, obj1, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00247()
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00248([In] string obj0) => this.compare = obj0;

      [Modifiers]
      [LineNumberTable(733)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024rebuild\u00243()
      {
        object symbol = (object) this.op.__\u003C\u003Esymbol;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) symbol;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(734)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00245([In] Button obj0, [In] Table obj1) => this.showSelect(obj0, (Enum[]) ConditionOp.__\u003C\u003Eall, (Enum) this.op, (Cons) new LStatements.JumpStatement.__\u003C\u003EAnon9(this, obj1));

      [Modifiers]
      [LineNumberTable(new byte[] {162, 109, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00244([In] Table obj0, [In] ConditionOp obj1)
      {
        this.op = obj1;
        this.rebuild(obj0);
      }

      [LineNumberTable(new byte[] {162, 91, 159, 7, 107, 146, 108, 127, 33})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        Table table1 = table;
        object obj = (object) "if ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text).padLeft(4f);
        LStatements.JumpStatement.last = table.__\u003C\u003Ecolor;
        table.table((Cons) new LStatements.JumpStatement.__\u003C\u003EAnon0(this));
        table.add().growX();
        Table table2 = table;
        LCanvas.JumpButton.__\u003Cclinit\u003E();
        LCanvas.JumpButton jumpButton = new LCanvas.JumpButton((Prov) new LStatements.JumpStatement.__\u003C\u003EAnon1(this), (Cons) new LStatements.JumpStatement.__\u003C\u003EAnon2(this));
        table2.add((Element) jumpButton).size(30f).right().padLeft(-8f);
      }

      [LineNumberTable(new byte[] {162, 120, 127, 15, 159, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setupUI()
      {
        if (this.elem == null || this.destIndex < 0 || this.destIndex >= this.elem.parent.getChildren().size)
          return;
        this.dest = (LCanvas.StatementElem) this.elem.parent.getChildren().get(this.destIndex);
      }

      [LineNumberTable(new byte[] {162, 127, 104, 159, 13})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void saveUI()
      {
        if (this.elem == null)
          return;
        this.destIndex = this.dest != null ? this.dest.parent.getChildren().indexOf((object) this.dest) : -1;
      }

      [LineNumberTable(760)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.JumpI(this.op, builder.var(this.value), builder.var(this.compare), this.destIndex);

      [LineNumberTable(765)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicControl;

      [LineNumberTable(706)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static JumpStatement()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.logic.LStatements$JumpStatement"))
          return;
        LStatements.JumpStatement.last = new Color();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.JumpStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.JumpStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.rebuild((Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Prov
      {
        private readonly LStatements.JumpStatement arg\u00241;

        internal __\u003C\u003EAnon1([In] LStatements.JumpStatement obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024build\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly LStatements.JumpStatement arg\u00241;

        internal __\u003C\u003EAnon2([In] LStatements.JumpStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241((LCanvas.StatementElem) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly LStatements.JumpStatement arg\u00241;

        internal __\u003C\u003EAnon3([In] LStatements.JumpStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00242((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        private readonly LStatements.JumpStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon4([In] LStatements.JumpStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00246(this.arg\u00242, (Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Runnable
      {
        internal __\u003C\u003EAnon5()
        {
        }

        public void run() => LStatements.JumpStatement.lambda\u0024rebuild\u00247();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Cons
      {
        private readonly LStatements.JumpStatement arg\u00241;

        internal __\u003C\u003EAnon6([In] LStatements.JumpStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00248((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Prov
      {
        private readonly LStatements.JumpStatement arg\u00241;

        internal __\u003C\u003EAnon7([In] LStatements.JumpStatement obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024rebuild\u00243().__\u003Cref\u003E;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Runnable
      {
        private readonly LStatements.JumpStatement arg\u00241;
        private readonly Button arg\u00242;
        private readonly Table arg\u00243;

        internal __\u003C\u003EAnon8([In] LStatements.JumpStatement obj0, [In] Button obj1, [In] Table obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u00245(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Cons
      {
        private readonly LStatements.JumpStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon9([In] LStatements.JumpStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00244(this.arg\u00242, (ConditionOp) obj0);
      }
    }

    public class OperationStatement : LStatement
    {
      public LogicOp op;
      public string dest;
      public string a;
      public string b;

      [LineNumberTable(new byte[] {161, 219, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public OperationStatement()
      {
        LStatements.OperationStatement operationStatement = this;
        this.op = LogicOp.__\u003C\u003Eadd;
        this.dest = "result";
        this.a = nameof (a);
        this.b = nameof (b);
      }

      [LineNumberTable(new byte[] {161, 229, 134, 153, 156, 109, 136, 158, 167, 109, 103, 103, 103, 211, 141, 170, 153, 136, 185})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void rebuild([In] Table obj0)
      {
        obj0.clearChildren();
        this.field(obj0, this.dest, (Cons) new LStatements.OperationStatement.__\u003C\u003EAnon0(this));
        Table table = obj0;
        object obj = (object) " = ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text);
        if (this.op.__\u003C\u003Eunary)
        {
          this.opButton(obj0, obj0);
          this.field(obj0, this.a, (Cons) new LStatements.OperationStatement.__\u003C\u003EAnon1(this));
        }
        else
        {
          this.row(obj0);
          if (this.op.__\u003C\u003Efunc)
          {
            if (LCanvas.useRows())
            {
              obj0.left();
              obj0.row();
              obj0.table((Cons) new LStatements.OperationStatement.__\u003C\u003EAnon2(this, obj0)).colspan(2).left();
            }
            else
              this.funcs(obj0, obj0);
          }
          else
          {
            this.field(obj0, this.a, (Cons) new LStatements.OperationStatement.__\u003C\u003EAnon3(this));
            this.opButton(obj0, obj0);
            this.field(obj0, this.b, (Cons) new LStatements.OperationStatement.__\u003C\u003EAnon4(this));
          }
        }
      }

      [LineNumberTable(new byte[] {162, 18, 255, 12, 70, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void opButton([In] Table obj0, [In] Table obj1) => obj0.button((Cons) new LStatements.OperationStatement.__\u003C\u003EAnon7(this, obj1), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.OperationStatement.__\u003C\u003EAnon8()).size(64f, 40f).pad(4f).color(obj0.__\u003C\u003Ecolor);

      [LineNumberTable(new byte[] {162, 10, 136, 153, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void funcs([In] Table obj0, [In] Table obj1)
      {
        this.opButton(obj0, obj1);
        this.field(obj0, this.a, (Cons) new LStatements.OperationStatement.__\u003C\u003EAnon5(this));
        this.field(obj0, this.b, (Cons) new LStatements.OperationStatement.__\u003C\u003EAnon6(this));
      }

      [LineNumberTable(660)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicOperations;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00240([In] string obj0) => this.dest = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00241([In] string obj0) => this.a = obj0;

      [Modifiers]
      [LineNumberTable(new byte[] {161, 248, 114, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00242([In] Table obj0, [In] Table obj1)
      {
        obj1.__\u003C\u003Ecolor.set(this.color());
        obj1.left();
        this.funcs(obj1, obj0);
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00243([In] string obj0) => this.a = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00244([In] string obj0) => this.b = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024funcs\u00245([In] string obj0) => this.a = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024funcs\u00246([In] string obj0) => this.b = obj0;

      [Modifiers]
      [LineNumberTable(new byte[] {162, 19, 114, 212})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024opButton\u002410([In] Table obj0, [In] Button obj1)
      {
        obj1.label((Prov) new LStatements.OperationStatement.__\u003C\u003EAnon9(this));
        obj1.clicked((Runnable) new LStatements.OperationStatement.__\u003C\u003EAnon10(this, obj1, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024opButton\u002411()
      {
      }

      [Modifiers]
      [LineNumberTable(645)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024opButton\u00247()
      {
        object symbol = (object) this.op.__\u003C\u003Esymbol;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) symbol;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(646)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024opButton\u00249([In] Button obj0, [In] Table obj1) => this.showSelect(obj0, (Enum[]) LogicOp.__\u003C\u003Eall, (Enum) this.op, (Cons) new LStatements.OperationStatement.__\u003C\u003EAnon11(this, obj1));

      [Modifiers]
      [LineNumberTable(new byte[] {162, 21, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024opButton\u00248([In] Table obj0, [In] LogicOp obj1)
      {
        this.op = obj1;
        this.rebuild(obj0);
      }

      [LineNumberTable(new byte[] {161, 225, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table) => this.rebuild(table);

      [LineNumberTable(655)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.OpI(this.op, builder.var(this.a), builder.var(this.b), builder.var(this.dest));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.OperationStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.OperationStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LStatements.OperationStatement arg\u00241;

        internal __\u003C\u003EAnon1([In] LStatements.OperationStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00241((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly LStatements.OperationStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon2([In] LStatements.OperationStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00242(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly LStatements.OperationStatement arg\u00241;

        internal __\u003C\u003EAnon3([In] LStatements.OperationStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00243((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        private readonly LStatements.OperationStatement arg\u00241;

        internal __\u003C\u003EAnon4([In] LStatements.OperationStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00244((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly LStatements.OperationStatement arg\u00241;

        internal __\u003C\u003EAnon5([In] LStatements.OperationStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024funcs\u00245((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Cons
      {
        private readonly LStatements.OperationStatement arg\u00241;

        internal __\u003C\u003EAnon6([In] LStatements.OperationStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024funcs\u00246((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Cons
      {
        private readonly LStatements.OperationStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon7([In] LStatements.OperationStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024opButton\u002410(this.arg\u00242, (Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Runnable
      {
        internal __\u003C\u003EAnon8()
        {
        }

        public void run() => LStatements.OperationStatement.lambda\u0024opButton\u002411();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Prov
      {
        private readonly LStatements.OperationStatement arg\u00241;

        internal __\u003C\u003EAnon9([In] LStatements.OperationStatement obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024opButton\u00247().__\u003Cref\u003E;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : Runnable
      {
        private readonly LStatements.OperationStatement arg\u00241;
        private readonly Button arg\u00242;
        private readonly Table arg\u00243;

        internal __\u003C\u003EAnon10([In] LStatements.OperationStatement obj0, [In] Button obj1, [In] Table obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024opButton\u00249(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon11 : Cons
      {
        private readonly LStatements.OperationStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon11([In] LStatements.OperationStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024opButton\u00248(this.arg\u00242, (LogicOp) obj0);
      }
    }

    public class PrintFlushStatement : LStatement
    {
      public string target;

      [LineNumberTable(new byte[] {160, 176, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PrintFlushStatement()
      {
        LStatements.PrintFlushStatement printFlushStatement = this;
        this.target = "message1";
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.target = obj0;

      [LineNumberTable(new byte[] {160, 181, 124, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        Table table1 = table;
        object obj = (object) " to ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text);
        this.field(table, this.target, (Cons) new LStatements.PrintFlushStatement.__\u003C\u003EAnon0(this));
      }

      [LineNumberTable(301)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicBlocks;

      [LineNumberTable(306)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.PrintFlushI(builder.var(this.target));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.PrintFlushStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.PrintFlushStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }
    }

    public class PrintStatement : LStatement
    {
      public string value;

      [LineNumberTable(new byte[] {160, 135, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PrintStatement()
      {
        LStatements.PrintStatement printStatement = this;
        this.value = "\"frog\"";
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.value = obj0;

      [LineNumberTable(new byte[] {160, 140, 127, 19})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table) => this.field(table, this.value, (Cons) new LStatements.PrintStatement.__\u003C\u003EAnon0(this)).width(0.0f).growX().padRight(3f);

      [LineNumberTable(259)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.PrintI(builder.var(this.value));

      [LineNumberTable(264)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicIo;

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.PrintStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.PrintStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }
    }

    public class RadarStatement : LStatement
    {
      public RadarTarget target1;
      public RadarTarget target2;
      public RadarTarget target3;
      public RadarSort sort;
      public string radar;
      public string sortOrder;
      public string output;

      [LineNumberTable(new byte[] {161, 18, 104, 127, 2, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RadarStatement()
      {
        LStatements.RadarStatement radarStatement = this;
        this.target1 = RadarTarget.__\u003C\u003Eenemy;
        this.target2 = RadarTarget.__\u003C\u003Eany;
        this.target3 = RadarTarget.__\u003C\u003Eany;
        this.sort = RadarSort.__\u003C\u003Edistance;
        this.radar = "turret1";
        this.sortOrder = "1";
        this.output = "result";
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool buildFrom() => true;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.radar = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private RadarTarget lambda\u0024build\u00241([In] int obj0)
      {
        if (obj0 == 0)
          return this.target1;
        return obj0 == 1 ? this.target2 : this.target3;
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 42, 114, 181})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00246([In] Prov obj0, [In] int obj1, [In] Button obj2)
      {
        obj2.label((Prov) new LStatements.RadarStatement.__\u003C\u003EAnon13(obj0));
        obj2.clicked((Runnable) new LStatements.RadarStatement.__\u003C\u003EAnon14(this, obj2, obj0, obj1));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024build\u00247()
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00248([In] string obj0) => this.sortOrder = obj0;

      [Modifiers]
      [LineNumberTable(new byte[] {161, 62, 114, 179})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u002413([In] Button obj0)
      {
        obj0.label((Prov) new LStatements.RadarStatement.__\u003C\u003EAnon9(this));
        obj0.clicked((Runnable) new LStatements.RadarStatement.__\u003C\u003EAnon10(this, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024build\u002414()
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u002415([In] string obj0) => this.output = obj0;

      [Modifiers]
      [LineNumberTable(432)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024build\u00249()
      {
        object obj = (object) this.sort.name();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(433)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u002412([In] Button obj0) => this.showSelect(obj0, (Enum[]) RadarSort.__\u003C\u003Eall, (Enum) this.sort, (Cons) new LStatements.RadarStatement.__\u003C\u003EAnon11(this), 2, (Cons) new LStatements.RadarStatement.__\u003C\u003EAnon12());

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u002410([In] RadarSort obj0) => this.sort = obj0;

      [Modifiers]
      [LineNumberTable(435)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024build\u002411([In] Cell obj0) => obj0.size(100f, 50f);

      [Modifiers]
      [LineNumberTable(412)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static CharSequence lambda\u0024build\u00242([In] Prov obj0)
      {
        object obj = (object) ((Enum) obj0.get()).name();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(413)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00245([In] Button obj0, [In] Prov obj1, [In] int obj2) => this.showSelect(obj0, (Enum[]) RadarTarget.__\u003C\u003Eall, (Enum) obj1.get(), (Cons) new LStatements.RadarStatement.__\u003C\u003EAnon15(this, obj2), 2, (Cons) new LStatements.RadarStatement.__\u003C\u003EAnon16());

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00243([In] int obj0, [In] RadarTarget obj1)
      {
        if (obj0 == 0)
          this.target1 = obj1;
        else if (obj0 == 1)
          this.target2 = obj1;
        else
          this.target3 = obj1;
      }

      [Modifiers]
      [LineNumberTable(415)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024build\u00244([In] Cell obj0) => obj0.size(100f, 50f);

      [LineNumberTable(new byte[] {161, 25, 140, 104, 159, 13, 152, 167, 105, 98, 142, 159, 23, 255, 14, 69, 159, 1, 100, 231, 50, 233, 82, 159, 13, 152, 135, 159, 13, 255, 11, 69, 159, 1, 159, 13, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        table.defaults().left();
        CharSequence charSequence;
        if (this.buildFrom())
        {
          Table table1 = table;
          object obj = (object) " from ";
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table1.add(text).self((Cons) new LStatements.RadarStatement.__\u003C\u003EAnon0(this));
          this.fields(table, this.radar, (Cons) new LStatements.RadarStatement.__\u003C\u003EAnon1(this));
          this.row(table);
        }
        for (int index = 0; index < 3; ++index)
        {
          int num = index;
          Prov prov = (Prov) new LStatements.RadarStatement.__\u003C\u003EAnon2(this, num);
          Table table1 = table;
          object obj = index != 0 ? (object) " and " : (object) " target ";
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table1.add(text).self((Cons) new LStatements.RadarStatement.__\u003C\u003EAnon0(this));
          table.button((Cons) new LStatements.RadarStatement.__\u003C\u003EAnon3(this, prov, num), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.RadarStatement.__\u003C\u003EAnon4()).size(90f, 40f).color(table.__\u003C\u003Ecolor).left().padLeft(2f);
          if (index == 1)
            this.row(table);
        }
        Table table2 = table;
        object obj1 = (object) " order ";
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence text1 = charSequence;
        table2.add(text1).self((Cons) new LStatements.RadarStatement.__\u003C\u003EAnon0(this));
        this.fields(table, this.sortOrder, (Cons) new LStatements.RadarStatement.__\u003C\u003EAnon5(this));
        table.row();
        Table table3 = table;
        object obj2 = (object) " sort ";
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text2 = charSequence;
        table3.add(text2).self((Cons) new LStatements.RadarStatement.__\u003C\u003EAnon0(this));
        table.button((Cons) new LStatements.RadarStatement.__\u003C\u003EAnon6(this), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.RadarStatement.__\u003C\u003EAnon7()).size(90f, 40f).color(table.__\u003C\u003Ecolor).left().padLeft(2f);
        Table table4 = table;
        object obj3 = (object) " output ";
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence text3 = charSequence;
        table4.add(text3).self((Cons) new LStatements.RadarStatement.__\u003C\u003EAnon0(this));
        this.fields(table, this.output, (Cons) new LStatements.RadarStatement.__\u003C\u003EAnon8(this));
      }

      [LineNumberTable(449)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicBlocks;

      [LineNumberTable(454)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.RadarI(this.target1, this.target2, this.target3, this.sort, builder.var(this.radar), builder.var(this.sortOrder), builder.var(this.output));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.RadarStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.RadarStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.param((Cell) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LStatements.RadarStatement arg\u00241;

        internal __\u003C\u003EAnon1([In] LStatements.RadarStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Prov
      {
        private readonly LStatements.RadarStatement arg\u00241;
        private readonly int arg\u00242;

        internal __\u003C\u003EAnon2([In] LStatements.RadarStatement obj0, [In] int obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public object get() => (object) this.arg\u00241.lambda\u0024build\u00241(this.arg\u00242);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly LStatements.RadarStatement arg\u00241;
        private readonly Prov arg\u00242;
        private readonly int arg\u00243;

        internal __\u003C\u003EAnon3([In] LStatements.RadarStatement obj0, [In] Prov obj1, [In] int obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00246(this.arg\u00242, this.arg\u00243, (Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Runnable
      {
        internal __\u003C\u003EAnon4()
        {
        }

        public void run() => LStatements.RadarStatement.lambda\u0024build\u00247();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly LStatements.RadarStatement arg\u00241;

        internal __\u003C\u003EAnon5([In] LStatements.RadarStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00248((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Cons
      {
        private readonly LStatements.RadarStatement arg\u00241;

        internal __\u003C\u003EAnon6([In] LStatements.RadarStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002413((Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Runnable
      {
        internal __\u003C\u003EAnon7()
        {
        }

        public void run() => LStatements.RadarStatement.lambda\u0024build\u002414();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Cons
      {
        private readonly LStatements.RadarStatement arg\u00241;

        internal __\u003C\u003EAnon8([In] LStatements.RadarStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002415((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Prov
      {
        private readonly LStatements.RadarStatement arg\u00241;

        internal __\u003C\u003EAnon9([In] LStatements.RadarStatement obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024build\u00249().__\u003Cref\u003E;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : Runnable
      {
        private readonly LStatements.RadarStatement arg\u00241;
        private readonly Button arg\u00242;

        internal __\u003C\u003EAnon10([In] LStatements.RadarStatement obj0, [In] Button obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u002412(this.arg\u00242);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon11 : Cons
      {
        private readonly LStatements.RadarStatement arg\u00241;

        internal __\u003C\u003EAnon11([In] LStatements.RadarStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002410((RadarSort) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon12 : Cons
      {
        internal __\u003C\u003EAnon12()
        {
        }

        public void get([In] object obj0) => LStatements.RadarStatement.lambda\u0024build\u002411((Cell) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon13 : Prov
      {
        private readonly Prov arg\u00241;

        internal __\u003C\u003EAnon13([In] Prov obj0) => this.arg\u00241 = obj0;

        public object get() => (object) LStatements.RadarStatement.lambda\u0024build\u00242(this.arg\u00241).__\u003Cref\u003E;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon14 : Runnable
      {
        private readonly LStatements.RadarStatement arg\u00241;
        private readonly Button arg\u00242;
        private readonly Prov arg\u00243;
        private readonly int arg\u00244;

        internal __\u003C\u003EAnon14(
          [In] LStatements.RadarStatement obj0,
          [In] Button obj1,
          [In] Prov obj2,
          [In] int obj3)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u00245(this.arg\u00242, this.arg\u00243, this.arg\u00244);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon15 : Cons
      {
        private readonly LStatements.RadarStatement arg\u00241;
        private readonly int arg\u00242;

        internal __\u003C\u003EAnon15([In] LStatements.RadarStatement obj0, [In] int obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00243(this.arg\u00242, (RadarTarget) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon16 : Cons
      {
        internal __\u003C\u003EAnon16()
        {
        }

        public void get([In] object obj0) => LStatements.RadarStatement.lambda\u0024build\u00244((Cell) obj0);
      }
    }

    public class ReadStatement : LStatement
    {
      public string output;
      public string target;
      public string address;

      [LineNumberTable(new byte[] {13, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ReadStatement()
      {
        LStatements.ReadStatement readStatement = this;
        this.output = "result";
        this.target = "cell1";
        this.address = "0";
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.output = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00241([In] string obj0) => this.target = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00242([In] string obj0) => this.address = obj0;

      [LineNumberTable(new byte[] {18, 156, 153, 156, 152, 135, 156, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        Table table1 = table;
        object obj1 = (object) " read ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence text1 = charSequence;
        table1.add(text1);
        this.field(table, this.output, (Cons) new LStatements.ReadStatement.__\u003C\u003EAnon0(this));
        Table table2 = table;
        object obj2 = (object) " = ";
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text2 = charSequence;
        table2.add(text2);
        this.fields(table, this.target, (Cons) new LStatements.ReadStatement.__\u003C\u003EAnon1(this));
        this.row(table);
        Table table3 = table;
        object obj3 = (object) " at ";
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence text3 = charSequence;
        table3.add(text3);
        this.field(table, this.address, (Cons) new LStatements.ReadStatement.__\u003C\u003EAnon2(this));
      }

      [LineNumberTable(85)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicIo;

      [LineNumberTable(90)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.ReadI(builder.var(this.target), builder.var(this.address), builder.var(this.output));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.ReadStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.ReadStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LStatements.ReadStatement arg\u00241;

        internal __\u003C\u003EAnon1([In] LStatements.ReadStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly LStatements.ReadStatement arg\u00241;

        internal __\u003C\u003EAnon2([In] LStatements.ReadStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00242((string) obj0);
      }
    }

    public class SensorStatement : LStatement
    {
      public string to;
      public string from;
      public string type;
      [NonSerialized]
      private int selected;
      [NonSerialized]
      private TextField tfield;

      [LineNumberTable(new byte[] {161, 89, 104, 107, 150})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SensorStatement()
      {
        LStatements.SensorStatement sensorStatement = this;
        this.to = "result";
        this.from = "block1";
        this.type = "@copper";
        this.selected = 0;
      }

      [LineNumberTable(new byte[] {161, 178, 108, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void stype([In] string obj0)
      {
        this.tfield.setText(obj0);
        this.type = obj0;
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.to = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00241([In] string obj0) => this.type = obj0;

      [Modifiers]
      [LineNumberTable(new byte[] {161, 107, 140, 243, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u002412([In] Button obj0)
      {
        obj0.image((Drawable) Icon.pencilSmall);
        obj0.clicked((Runnable) new LStatements.SensorStatement.__\u003C\u003EAnon6(this, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024build\u002413()
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u002414([In] string obj0) => this.from = obj0;

      [Modifiers]
      [LineNumberTable(479)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u002411([In] Button obj0) => this.showSelectTable(obj0, (Cons2) new LStatements.SensorStatement.__\u003C\u003EAnon7(this));

      [Modifiers]
      [LineNumberTable(new byte[] {161, 110, 255, 51, 104, 127, 0, 124, 134, 105, 132, 255, 5, 72, 255, 1, 53, 232, 77, 103, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u002410([In] Table obj0, [In] Runnable obj1)
      {
        Table[] tableArray1 = new Table[3];
        Table.__\u003Cclinit\u003E();
        tableArray1[0] = new Table((Cons) new LStatements.SensorStatement.__\u003C\u003EAnon8(this, obj1));
        Table.__\u003Cclinit\u003E();
        tableArray1[1] = new Table((Cons) new LStatements.SensorStatement.__\u003C\u003EAnon9(this, obj1));
        Table.__\u003Cclinit\u003E();
        tableArray1[2] = new Table((Cons) new LStatements.SensorStatement.__\u003C\u003EAnon10(this, obj1));
        Table[] tableArray2 = tableArray1;
        Drawable[] drawableArray = new Drawable[3]
        {
          (Drawable) Icon.box,
          (Drawable) Icon.liquid,
          (Drawable) Icon.tree
        };
        Stack.__\u003Cclinit\u003E();
        Stack stack = new Stack(new Element[1]
        {
          (Element) tableArray2[this.selected]
        });
        ButtonGroup group = new ButtonGroup();
        for (int index = 0; index < tableArray2.Length; ++index)
        {
          int num = index;
          obj0.button(drawableArray[index], Styles.clearTogglei, (Runnable) new LStatements.SensorStatement.__\u003C\u003EAnon11(this, num, stack, tableArray2, obj0)).height(50f).growX().@checked(this.selected == num).group(group);
        }
        obj0.row();
        obj0.add((Element) stack).colspan(3).width(240f).left();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 113, 103, 98, 127, 8, 106, 191, 14, 134, 121, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00243([In] Runnable obj0, [In] Table obj1)
      {
        obj1.left();
        int num1 = 0;
        Iterator iterator = Vars.content.items().iterator();
        while (iterator.hasNext())
        {
          Item obj = (Item) iterator.next();
          if (obj.unlockedNow())
          {
            obj1.button((Drawable) new TextureRegionDrawable(obj.icon(Cicon.__\u003C\u003Esmall)), Styles.cleari, (Runnable) new LStatements.SensorStatement.__\u003C\u003EAnon15(this, obj, obj0)).size(40f);
            ++num1;
            int num2 = num1;
            int num3 = 6;
            if ((num3 != -1 ? num2 % num3 : 0) == 0)
              obj1.row();
          }
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 127, 103, 98, 127, 8, 106, 191, 14, 134, 121, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00245([In] Runnable obj0, [In] Table obj1)
      {
        obj1.left();
        int num1 = 0;
        Iterator iterator = Vars.content.liquids().iterator();
        while (iterator.hasNext())
        {
          Liquid liquid = (Liquid) iterator.next();
          if (liquid.unlockedNow())
          {
            obj1.button((Drawable) new TextureRegionDrawable(liquid.icon(Cicon.__\u003C\u003Esmall)), Styles.cleari, (Runnable) new LStatements.SensorStatement.__\u003C\u003EAnon14(this, liquid, obj0)).size(40f);
            ++num1;
            int num2 = num1;
            int num3 = 6;
            if ((num3 != -1 ? num2 % num3 : 0) == 0)
              obj1.row();
          }
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 141, 115, 191, 9, 250, 60, 230, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00248([In] Runnable obj0, [In] Table obj1)
      {
        LAccess[] senseable = LAccess.__\u003C\u003Esenseable;
        int length = senseable.Length;
        for (int index = 0; index < length; ++index)
        {
          LAccess laccess = senseable[index];
          obj1.button(laccess.name(), Styles.cleart, (Runnable) new LStatements.SensorStatement.__\u003C\u003EAnon12(this, laccess, obj0)).size(240f, 40f).self((Cons) new LStatements.SensorStatement.__\u003C\u003EAnon13(laccess)).row();
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 158, 135, 102, 142, 113, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00249([In] int obj0, [In] Stack obj1, [In] Table[] obj2, [In] Table obj3)
      {
        this.selected = obj0;
        obj1.clearChildren();
        obj1.addChild((Element) obj2[this.selected]);
        obj3.parent.parent.pack();
        obj3.parent.parent.invalidateHierarchy();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 143, 127, 6, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00246([In] LAccess obj0, [In] Runnable obj1)
      {
        this.stype(new StringBuilder().append("@").append(obj0.name()).toString());
        obj1.run();
      }

      [Modifiers]
      [LineNumberTable(515)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024build\u00247([In] LAccess obj0, [In] Cell obj1) => LCanvas.tooltip(obj1, (Enum) obj0);

      [Modifiers]
      [LineNumberTable(new byte[] {161, 132, 127, 6, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00244([In] Liquid obj0, [In] Runnable obj1)
      {
        this.stype(new StringBuilder().append("@").append(obj0.__\u003C\u003Ename).toString());
        obj1.run();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 118, 127, 6, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00242([In] Item obj0, [In] Runnable obj1)
      {
        this.stype(new StringBuilder().append("@").append(obj0.__\u003C\u003Ename).toString());
        obj1.run();
      }

      [LineNumberTable(new byte[] {161, 98, 153, 156, 135, 159, 19, 255, 6, 160, 64, 155, 159, 13, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        this.field(table, this.to, (Cons) new LStatements.SensorStatement.__\u003C\u003EAnon0(this));
        Table table1 = table;
        object obj1 = (object) " = ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence text1 = charSequence;
        table1.add(text1);
        this.row(table);
        this.tfield = (TextField) this.field(table, this.type, (Cons) new LStatements.SensorStatement.__\u003C\u003EAnon1(this)).padRight(0.0f).get();
        table.button((Cons) new LStatements.SensorStatement.__\u003C\u003EAnon2(this), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.SensorStatement.__\u003C\u003EAnon3()).size(40f).padLeft(-1f).color(table.__\u003C\u003Ecolor);
        Table table2 = table;
        object obj2 = (object) " in ";
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text2 = charSequence;
        table2.add(text2).self((Cons) new LStatements.SensorStatement.__\u003C\u003EAnon4(this));
        this.field(table, this.from, (Cons) new LStatements.SensorStatement.__\u003C\u003EAnon5(this));
      }

      [LineNumberTable(554)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicBlocks;

      [LineNumberTable(559)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.SenseI(builder.var(this.from), builder.var(this.to), builder.var(this.type));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.SensorStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.SensorStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LStatements.SensorStatement arg\u00241;

        internal __\u003C\u003EAnon1([In] LStatements.SensorStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly LStatements.SensorStatement arg\u00241;

        internal __\u003C\u003EAnon2([In] LStatements.SensorStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002412((Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        internal __\u003C\u003EAnon3()
        {
        }

        public void run() => LStatements.SensorStatement.lambda\u0024build\u002413();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        private readonly LStatements.SensorStatement arg\u00241;

        internal __\u003C\u003EAnon4([In] LStatements.SensorStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.param((Cell) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly LStatements.SensorStatement arg\u00241;

        internal __\u003C\u003EAnon5([In] LStatements.SensorStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002414((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Runnable
      {
        private readonly LStatements.SensorStatement arg\u00241;
        private readonly Button arg\u00242;

        internal __\u003C\u003EAnon6([In] LStatements.SensorStatement obj0, [In] Button obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u002411(this.arg\u00242);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Cons2
      {
        private readonly LStatements.SensorStatement arg\u00241;

        internal __\u003C\u003EAnon7([In] LStatements.SensorStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024build\u002410((Table) obj0, (Runnable) obj1);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Cons
      {
        private readonly LStatements.SensorStatement arg\u00241;
        private readonly Runnable arg\u00242;

        internal __\u003C\u003EAnon8([In] LStatements.SensorStatement obj0, [In] Runnable obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00243(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Cons
      {
        private readonly LStatements.SensorStatement arg\u00241;
        private readonly Runnable arg\u00242;

        internal __\u003C\u003EAnon9([In] LStatements.SensorStatement obj0, [In] Runnable obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00245(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : Cons
      {
        private readonly LStatements.SensorStatement arg\u00241;
        private readonly Runnable arg\u00242;

        internal __\u003C\u003EAnon10([In] LStatements.SensorStatement obj0, [In] Runnable obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00248(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon11 : Runnable
      {
        private readonly LStatements.SensorStatement arg\u00241;
        private readonly int arg\u00242;
        private readonly Stack arg\u00243;
        private readonly Table[] arg\u00244;
        private readonly Table arg\u00245;

        internal __\u003C\u003EAnon11(
          [In] LStatements.SensorStatement obj0,
          [In] int obj1,
          [In] Stack obj2,
          [In] Table[] obj3,
          [In] Table obj4)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
          this.arg\u00245 = obj4;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u00249(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon12 : Runnable
      {
        private readonly LStatements.SensorStatement arg\u00241;
        private readonly LAccess arg\u00242;
        private readonly Runnable arg\u00243;

        internal __\u003C\u003EAnon12(
          [In] LStatements.SensorStatement obj0,
          [In] LAccess obj1,
          [In] Runnable obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u00246(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon13 : Cons
      {
        private readonly LAccess arg\u00241;

        internal __\u003C\u003EAnon13([In] LAccess obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => LStatements.SensorStatement.lambda\u0024build\u00247(this.arg\u00241, (Cell) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon14 : Runnable
      {
        private readonly LStatements.SensorStatement arg\u00241;
        private readonly Liquid arg\u00242;
        private readonly Runnable arg\u00243;

        internal __\u003C\u003EAnon14([In] LStatements.SensorStatement obj0, [In] Liquid obj1, [In] Runnable obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u00244(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon15 : Runnable
      {
        private readonly LStatements.SensorStatement arg\u00241;
        private readonly Item arg\u00242;
        private readonly Runnable arg\u00243;

        internal __\u003C\u003EAnon15([In] LStatements.SensorStatement obj0, [In] Item obj1, [In] Runnable obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u00242(this.arg\u00242, this.arg\u00243);
      }
    }

    public class SetStatement : LStatement
    {
      public string to;
      public string from;

      [LineNumberTable(new byte[] {161, 194, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SetStatement()
      {
        LStatements.SetStatement setStatement = this;
        this.to = "result";
        this.from = "0";
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.to = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00241([In] string obj0) => this.from = obj0;

      [LineNumberTable(new byte[] {161, 200, 153, 156, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        this.field(table, this.to, (Cons) new LStatements.SetStatement.__\u003C\u003EAnon0(this));
        Table table1 = table;
        object obj = (object) " = ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text);
        this.field(table, this.from, (Cons) new LStatements.SetStatement.__\u003C\u003EAnon1(this));
      }

      [LineNumberTable(579)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicOperations;

      [LineNumberTable(584)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.SetI(builder.var(this.from), builder.var(this.to));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.SetStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.SetStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LStatements.SetStatement arg\u00241;

        internal __\u003C\u003EAnon1([In] LStatements.SetStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241((string) obj0);
      }
    }

    public class UnitBindStatement : LStatement
    {
      public string type;

      [LineNumberTable(new byte[] {162, 144, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitBindStatement()
      {
        LStatements.UnitBindStatement unitBindStatement = this;
        this.type = "@poly";
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.type = obj0;

      [Modifiers]
      [LineNumberTable(new byte[] {162, 154, 108, 244, 81})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00245([In] TextField obj0, [In] Button obj1)
      {
        obj1.image((Drawable) Icon.pencilSmall);
        obj1.clicked((Runnable) new LStatements.UnitBindStatement.__\u003C\u003EAnon3(this, obj1, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024build\u00246()
      {
      }

      [Modifiers]
      [LineNumberTable(781)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00244([In] Button obj0, [In] TextField obj1) => this.showSelectTable(obj0, (Cons2) new LStatements.UnitBindStatement.__\u003C\u003EAnon4(this, obj1));

      [Modifiers]
      [LineNumberTable(new byte[] {162, 156, 103, 244, 77, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00243([In] TextField obj0, [In] Table obj1, [In] Runnable obj2)
      {
        obj1.row();
        obj1.table((Cons) new LStatements.UnitBindStatement.__\u003C\u003EAnon5(this, obj0, obj2)).colspan(3).width(240f).left();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {162, 158, 103, 98, 127, 8, 114, 223, 15, 159, 0, 121, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00242([In] TextField obj0, [In] Runnable obj1, [In] Table obj2)
      {
        obj2.left();
        int num1 = 0;
        Iterator iterator = Vars.content.units().iterator();
        while (iterator.hasNext())
        {
          UnitType unitType = (UnitType) iterator.next();
          if (unitType.unlockedNow() && !unitType.isHidden())
          {
            ((ImageButton) obj2.button((Drawable) new TextureRegionDrawable(unitType.icon(Cicon.__\u003C\u003Esmall)), Styles.cleari, (Runnable) new LStatements.UnitBindStatement.__\u003C\u003EAnon6(this, unitType, obj0, obj1)).size(40f).get()).resizeImage((float) Cicon.__\u003C\u003Esmall.__\u003C\u003Esize);
            ++num1;
            int num2 = num1;
            int num3 = 6;
            if ((num3 != -1 ? num2 % num3 : 0) == 0)
              obj2.row();
          }
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {162, 163, 127, 6, 108, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00241([In] UnitType obj0, [In] TextField obj1, [In] Runnable obj2)
      {
        this.type = new StringBuilder().append("@").append(obj0.__\u003C\u003Ename).toString();
        obj1.setText(this.type);
        obj2.run();
      }

      [LineNumberTable(new byte[] {162, 149, 156, 159, 4, 255, 7, 83, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        Table table1 = table;
        object obj = (object) " type ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text);
        TextField textField = (TextField) this.field(table, this.type, (Cons) new LStatements.UnitBindStatement.__\u003C\u003EAnon0(this)).get();
        table.button((Cons) new LStatements.UnitBindStatement.__\u003C\u003EAnon1(this, textField), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.UnitBindStatement.__\u003C\u003EAnon2()).size(40f).padLeft(-2f).color(table.__\u003C\u003Ecolor);
      }

      [LineNumberTable(803)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicUnits;

      [LineNumberTable(808)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.UnitBindI(builder.var(this.type));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.UnitBindStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.UnitBindStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LStatements.UnitBindStatement arg\u00241;
        private readonly TextField arg\u00242;

        internal __\u003C\u003EAnon1([In] LStatements.UnitBindStatement obj0, [In] TextField obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00245(this.arg\u00242, (Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public void run() => LStatements.UnitBindStatement.lambda\u0024build\u00246();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly LStatements.UnitBindStatement arg\u00241;
        private readonly Button arg\u00242;
        private readonly TextField arg\u00243;

        internal __\u003C\u003EAnon3(
          [In] LStatements.UnitBindStatement obj0,
          [In] Button obj1,
          [In] TextField obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u00244(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons2
      {
        private readonly LStatements.UnitBindStatement arg\u00241;
        private readonly TextField arg\u00242;

        internal __\u003C\u003EAnon4([In] LStatements.UnitBindStatement obj0, [In] TextField obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024build\u00243(this.arg\u00242, (Table) obj0, (Runnable) obj1);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly LStatements.UnitBindStatement arg\u00241;
        private readonly TextField arg\u00242;
        private readonly Runnable arg\u00243;

        internal __\u003C\u003EAnon5(
          [In] LStatements.UnitBindStatement obj0,
          [In] TextField obj1,
          [In] Runnable obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00242(this.arg\u00242, this.arg\u00243, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Runnable
      {
        private readonly LStatements.UnitBindStatement arg\u00241;
        private readonly UnitType arg\u00242;
        private readonly TextField arg\u00243;
        private readonly Runnable arg\u00244;

        internal __\u003C\u003EAnon6(
          [In] LStatements.UnitBindStatement obj0,
          [In] UnitType obj1,
          [In] TextField obj2,
          [In] Runnable obj3)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
        }

        public void run() => this.arg\u00241.lambda\u0024build\u00241(this.arg\u00242, this.arg\u00243, this.arg\u00244);
      }
    }

    public class UnitControlStatement : LStatement
    {
      public LUnitControl type;
      public string p1;
      public string p2;
      public string p3;
      public string p4;
      public string p5;

      [LineNumberTable(new byte[] {162, 187, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitControlStatement()
      {
        LStatements.UnitControlStatement controlStatement = this;
        this.type = LUnitControl.__\u003C\u003Emove;
        this.p1 = "0";
        this.p2 = "0";
        this.p3 = "0";
        this.p4 = "0";
        this.p5 = "0";
      }

      [LineNumberTable(new byte[] {162, 197, 134, 135, 156, 255, 12, 74, 159, 1, 199, 98, 148, 159, 160, 67, 153, 100, 231, 57, 233, 74})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void rebuild([In] Table obj0)
      {
        obj0.clearChildren();
        obj0.left();
        Table table1 = obj0;
        object obj = (object) " ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text);
        obj0.button((Cons) new LStatements.UnitControlStatement.__\u003C\u003EAnon0(this, obj0), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.UnitControlStatement.__\u003C\u003EAnon1()).size(120f, 40f).color(obj0.__\u003C\u003Ecolor).left().padLeft(2f);
        this.row(obj0);
        int num1 = 0;
        for (int index = 0; index < this.type.__\u003C\u003Eparams.Length; ++index)
        {
          Table table2 = obj0;
          string desc = this.type.__\u003C\u003Eparams[index];
          string str;
          switch (index)
          {
            case 0:
              str = this.p1;
              break;
            case 1:
              str = this.p2;
              break;
            case 2:
              str = this.p3;
              break;
            case 3:
              str = this.p4;
              break;
            default:
              str = this.p5;
              break;
          }
          Cons setter;
          switch (index)
          {
            case 0:
              setter = (Cons) new LStatements.UnitControlStatement.__\u003C\u003EAnon2(this);
              break;
            case 1:
              setter = (Cons) new LStatements.UnitControlStatement.__\u003C\u003EAnon3(this);
              break;
            case 2:
              setter = (Cons) new LStatements.UnitControlStatement.__\u003C\u003EAnon4(this);
              break;
            case 3:
              setter = (Cons) new LStatements.UnitControlStatement.__\u003C\u003EAnon5(this);
              break;
            default:
              setter = (Cons) new LStatements.UnitControlStatement.__\u003C\u003EAnon6(this);
              break;
          }
          this.fields(table2, desc, str, setter).width(100f);
          ++num1;
          int num2 = num1;
          int num3 = 2;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            this.row(obj0);
          if (index == 3)
            obj0.row();
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {162, 204, 114, 244, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00244([In] Table obj0, [In] Button obj1)
      {
        obj1.label((Prov) new LStatements.UnitControlStatement.__\u003C\u003EAnon7(this));
        obj1.clicked((Runnable) new LStatements.UnitControlStatement.__\u003C\u003EAnon8(this, obj1, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00245()
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00246([In] string obj0) => this.p1 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00247([In] string obj0) => this.p2 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00248([In] string obj0) => this.p3 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00249([In] string obj0) => this.p4 = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002410([In] string obj0) => this.p5 = obj0;

      [Modifiers]
      [LineNumberTable(830)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024rebuild\u00240()
      {
        object obj = (object) this.type.name();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(831)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00243([In] Button obj0, [In] Table obj1) => this.showSelect(obj0, (Enum[]) LUnitControl.__\u003C\u003Eall, (Enum) this.type, (Cons) new LStatements.UnitControlStatement.__\u003C\u003EAnon9(this, obj1), 2, (Cons) new LStatements.UnitControlStatement.__\u003C\u003EAnon10());

      [Modifiers]
      [LineNumberTable(new byte[] {162, 206, 126, 145, 135, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00241([In] Table obj0, [In] LUnitControl obj1)
      {
        if (object.ReferenceEquals((object) obj1, (object) LUnitControl.__\u003C\u003Ebuild) && !Vars.state.rules.logicUnitBuild)
          Vars.ui.showInfo("@logic.nounitbuild");
        else
          this.type = obj1;
        this.rebuild(obj0);
      }

      [Modifiers]
      [LineNumberTable(838)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00242([In] Cell obj0) => obj0.size(120f, 50f);

      [LineNumberTable(new byte[] {162, 193, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table) => this.rebuild(table);

      [LineNumberTable(860)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicUnits;

      [LineNumberTable(865)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.UnitControlI(this.type, builder.var(this.p1), builder.var(this.p2), builder.var(this.p3), builder.var(this.p4), builder.var(this.p5));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.UnitControlStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon0([In] LStatements.UnitControlStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00244(this.arg\u00242, (Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void run() => LStatements.UnitControlStatement.lambda\u0024rebuild\u00245();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly LStatements.UnitControlStatement arg\u00241;

        internal __\u003C\u003EAnon2([In] LStatements.UnitControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00246((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly LStatements.UnitControlStatement arg\u00241;

        internal __\u003C\u003EAnon3([In] LStatements.UnitControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00247((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Cons
      {
        private readonly LStatements.UnitControlStatement arg\u00241;

        internal __\u003C\u003EAnon4([In] LStatements.UnitControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00248((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly LStatements.UnitControlStatement arg\u00241;

        internal __\u003C\u003EAnon5([In] LStatements.UnitControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00249((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Cons
      {
        private readonly LStatements.UnitControlStatement arg\u00241;

        internal __\u003C\u003EAnon6([In] LStatements.UnitControlStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002410((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Prov
      {
        private readonly LStatements.UnitControlStatement arg\u00241;

        internal __\u003C\u003EAnon7([In] LStatements.UnitControlStatement obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024rebuild\u00240().__\u003Cref\u003E;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Runnable
      {
        private readonly LStatements.UnitControlStatement arg\u00241;
        private readonly Button arg\u00242;
        private readonly Table arg\u00243;

        internal __\u003C\u003EAnon8(
          [In] LStatements.UnitControlStatement obj0,
          [In] Button obj1,
          [In] Table obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u00243(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Cons
      {
        private readonly LStatements.UnitControlStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon9([In] LStatements.UnitControlStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00241(this.arg\u00242, (LUnitControl) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : Cons
      {
        internal __\u003C\u003EAnon10()
        {
        }

        public void get([In] object obj0) => LStatements.UnitControlStatement.lambda\u0024rebuild\u00242((Cell) obj0);
      }
    }

    public class UnitLocateStatement : LStatement
    {
      public LLocate locate;
      public BlockFlag flag;
      public string enemy;
      public string ore;
      public string outX;
      public string outY;
      public string outFound;
      public string outBuild;

      [LineNumberTable(new byte[] {163, 12, 104, 107, 107, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitLocateStatement()
      {
        LStatements.UnitLocateStatement unitLocateStatement = this;
        this.locate = LLocate.__\u003C\u003Ebuilding;
        this.flag = BlockFlag.__\u003C\u003Ecore;
        this.enemy = "true";
        this.ore = "@copper";
        this.outX = "outx";
        this.outY = "outy";
        this.outFound = "found";
        this.outBuild = "building";
      }

      [LineNumberTable(new byte[] {163, 24, 134, 159, 18, 255, 12, 70, 159, 1, 159, 14, 103, 127, 18, 191, 11, 127, 1, 135, 159, 18, 152, 231, 51, 226, 81, 127, 18, 243, 92, 231, 34, 226, 98, 199, 127, 18, 152, 127, 18, 152, 135, 127, 18, 152, 114, 127, 18, 184})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void rebuild([In] Table obj0)
      {
        obj0.clearChildren();
        Table table1 = obj0;
        object obj1 = (object) " find ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence text1 = charSequence;
        table1.add(text1).left().self((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon0(this));
        obj0.button((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon1(this, obj0), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.UnitLocateStatement.__\u003C\u003EAnon2()).size(110f, 40f).color(obj0.__\u003C\u003Ecolor).left().padLeft(2f);
        switch (LStatements.\u0031.\u0024SwitchMap\u0024mindustry\u0024logic\u0024LLocate[this.locate.ordinal()])
        {
          case 1:
            this.row(obj0);
            Table table2 = obj0;
            object obj2 = (object) " group ";
            charSequence.__\u003Cref\u003E = (__Null) obj2;
            CharSequence text2 = charSequence;
            table2.add(text2).left().self((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon0(this));
            obj0.button((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon3(this), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.UnitLocateStatement.__\u003C\u003EAnon4()).size(110f, 40f).color(obj0.__\u003C\u003Ecolor).left().padLeft(2f);
            this.row(obj0);
            Table table3 = obj0;
            object obj3 = (object) " enemy ";
            charSequence.__\u003Cref\u003E = (__Null) obj3;
            CharSequence text3 = charSequence;
            table3.add(text3).left().self((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon0(this));
            this.fields(obj0, this.enemy, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon5(this));
            obj0.row();
            break;
          case 2:
            Table table4 = obj0;
            object obj4 = (object) " ore ";
            charSequence.__\u003Cref\u003E = (__Null) obj4;
            CharSequence text4 = charSequence;
            table4.add(text4).left().self((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon0(this));
            obj0.table((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon6(this, obj0));
            obj0.row();
            break;
          case 3:
          case 4:
            obj0.row();
            break;
        }
        Table table5 = obj0;
        object obj5 = (object) " outX ";
        charSequence.__\u003Cref\u003E = (__Null) obj5;
        CharSequence text5 = charSequence;
        table5.add(text5).left().self((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon0(this));
        this.fields(obj0, this.outX, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon7(this));
        Table table6 = obj0;
        object obj6 = (object) " outY ";
        charSequence.__\u003Cref\u003E = (__Null) obj6;
        CharSequence text6 = charSequence;
        table6.add(text6).left().self((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon0(this));
        this.fields(obj0, this.outY, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon8(this));
        this.row(obj0);
        Table table7 = obj0;
        object obj7 = (object) " found ";
        charSequence.__\u003Cref\u003E = (__Null) obj7;
        CharSequence text7 = charSequence;
        table7.add(text7).left().self((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon0(this));
        this.fields(obj0, this.outFound, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon9(this));
        if (object.ReferenceEquals((object) this.locate, (object) LLocate.__\u003C\u003Eore))
          return;
        Table table8 = obj0;
        object obj8 = (object) " building ";
        charSequence.__\u003Cref\u003E = (__Null) obj8;
        CharSequence text8 = charSequence;
        table8.add(text8).left().self((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon0(this));
        this.fields(obj0, this.outBuild, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon10(this));
      }

      [Modifiers]
      [LineNumberTable(new byte[] {163, 29, 114, 212})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00244([In] Table obj0, [In] Button obj1)
      {
        obj1.label((Prov) new LStatements.UnitLocateStatement.__\u003C\u003EAnon22(this));
        obj1.clicked((Runnable) new LStatements.UnitLocateStatement.__\u003C\u003EAnon23(this, obj1, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00245()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {163, 41, 114, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002410([In] Button obj0)
      {
        obj0.label((Prov) new LStatements.UnitLocateStatement.__\u003C\u003EAnon18(this));
        obj0.clicked((Runnable) new LStatements.UnitLocateStatement.__\u003C\u003EAnon19(this, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u002411()
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002412([In] string obj0) => this.enemy = obj0;

      [Modifiers]
      [LineNumberTable(new byte[] {163, 56, 146, 152, 255, 7, 83, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002420([In] Table obj0, [In] Table obj1)
      {
        obj1.__\u003C\u003Ecolor.set(obj0.__\u003C\u003Ecolor);
        this.fields(obj1, this.ore, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon11(this));
        obj1.button((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon12(this, obj0), (Button.ButtonStyle) Styles.logict, (Runnable) new LStatements.UnitLocateStatement.__\u003C\u003EAnon13()).size(40f).padLeft(-2f).color(obj0.__\u003C\u003Ecolor);
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002421([In] string obj0) => this.outX = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002422([In] string obj0) => this.outY = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002423([In] string obj0) => this.outFound = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002424([In] string obj0) => this.outBuild = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002413([In] string obj0) => this.ore = obj0;

      [Modifiers]
      [LineNumberTable(new byte[] {163, 61, 108, 244, 81})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002418([In] Table obj0, [In] Button obj1)
      {
        obj1.image((Drawable) Icon.pencilSmall);
        obj1.clicked((Runnable) new LStatements.UnitLocateStatement.__\u003C\u003EAnon14(this, obj1, obj0));
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u002419()
      {
      }

      [Modifiers]
      [LineNumberTable(944)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002417([In] Button obj0, [In] Table obj1) => this.showSelectTable(obj0, (Cons2) new LStatements.UnitLocateStatement.__\u003C\u003EAnon15(this, obj1));

      [Modifiers]
      [LineNumberTable(new byte[] {163, 63, 103, 244, 77, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002416([In] Table obj0, [In] Table obj1, [In] Runnable obj2)
      {
        obj1.row();
        obj1.table((Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon16(this, obj0, obj2)).colspan(3).width(240f).left();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {163, 65, 103, 98, 127, 8, 106, 223, 15, 159, 0, 121, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002415([In] Table obj0, [In] Runnable obj1, [In] Table obj2)
      {
        obj2.left();
        int num1 = 0;
        Iterator iterator = Vars.content.items().iterator();
        while (iterator.hasNext())
        {
          Item obj = (Item) iterator.next();
          if (obj.unlockedNow())
          {
            ((ImageButton) obj2.button((Drawable) new TextureRegionDrawable(obj.icon(Cicon.__\u003C\u003Esmall)), Styles.cleari, (Runnable) new LStatements.UnitLocateStatement.__\u003C\u003EAnon17(this, obj, obj0, obj1)).size(40f).get()).resizeImage((float) Cicon.__\u003C\u003Esmall.__\u003C\u003Esize);
            ++num1;
            int num2 = num1;
            int num3 = 6;
            if ((num3 != -1 ? num2 % num3 : 0) == 0)
              obj2.row();
          }
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {163, 70, 127, 6, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002414([In] Item obj0, [In] Table obj1, [In] Runnable obj2)
      {
        this.ore = new StringBuilder().append("@").append(obj0.__\u003C\u003Ename).toString();
        this.rebuild(obj1);
        obj2.run();
      }

      [Modifiers]
      [LineNumberTable(923)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024rebuild\u00246()
      {
        object obj = (object) this.flag.name();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(924)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00249([In] Button obj0) => this.showSelect(obj0, (Enum[]) BlockFlag.__\u003C\u003EallLogic, (Enum) this.flag, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon20(this), 2, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon21());

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00247([In] BlockFlag obj0) => this.flag = obj0;

      [Modifiers]
      [LineNumberTable(924)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00248([In] Cell obj0) => obj0.size(110f, 50f);

      [Modifiers]
      [LineNumberTable(911)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024rebuild\u00240()
      {
        object obj = (object) this.locate.name();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [Modifiers]
      [LineNumberTable(912)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00243([In] Button obj0, [In] Table obj1) => this.showSelect(obj0, (Enum[]) LLocate.__\u003C\u003Eall, (Enum) this.locate, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon24(this, obj1), 2, (Cons) new LStatements.UnitLocateStatement.__\u003C\u003EAnon25());

      [Modifiers]
      [LineNumberTable(new byte[] {163, 31, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00241([In] Table obj0, [In] LLocate obj1)
      {
        this.locate = obj1;
        this.rebuild(obj0);
      }

      [Modifiers]
      [LineNumberTable(915)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u00242([In] Cell obj0) => obj0.size(110f, 50f);

      [LineNumberTable(new byte[] {163, 20, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table) => this.rebuild(table);

      [LineNumberTable(993)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicUnits;

      [LineNumberTable(998)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.UnitLocateI(this.locate, this.flag, builder.var(this.enemy), builder.var(this.ore), builder.var(this.outX), builder.var(this.outY), builder.var(this.outFound), builder.var(this.outBuild));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.param((Cell) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon1([In] LStatements.UnitLocateStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00244(this.arg\u00242, (Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public void run() => LStatements.UnitLocateStatement.lambda\u0024rebuild\u00245();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon3([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002410((Button) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Runnable
      {
        internal __\u003C\u003EAnon4()
        {
        }

        public void run() => LStatements.UnitLocateStatement.lambda\u0024rebuild\u002411();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon5([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002412((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon6([In] LStatements.UnitLocateStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002420(this.arg\u00242, (Table) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon7([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002421((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon8 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon8([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002422((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon9 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon9([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002423((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon10([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002424((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon11 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon11([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002413((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon12 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon12([In] LStatements.UnitLocateStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002418(this.arg\u00242, (Button) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon13 : Runnable
      {
        internal __\u003C\u003EAnon13()
        {
        }

        public void run() => LStatements.UnitLocateStatement.lambda\u0024rebuild\u002419();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon14 : Runnable
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Button arg\u00242;
        private readonly Table arg\u00243;

        internal __\u003C\u003EAnon14(
          [In] LStatements.UnitLocateStatement obj0,
          [In] Button obj1,
          [In] Table obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u002417(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon15 : Cons2
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon15([In] LStatements.UnitLocateStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024rebuild\u002416(this.arg\u00242, (Table) obj0, (Runnable) obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon16 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Table arg\u00242;
        private readonly Runnable arg\u00243;

        internal __\u003C\u003EAnon16(
          [In] LStatements.UnitLocateStatement obj0,
          [In] Table obj1,
          [In] Runnable obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002415(this.arg\u00242, this.arg\u00243, (Table) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon17 : Runnable
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Item arg\u00242;
        private readonly Table arg\u00243;
        private readonly Runnable arg\u00244;

        internal __\u003C\u003EAnon17(
          [In] LStatements.UnitLocateStatement obj0,
          [In] Item obj1,
          [In] Table obj2,
          [In] Runnable obj3)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u002414(this.arg\u00242, this.arg\u00243, this.arg\u00244);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon18 : Prov
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon18([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024rebuild\u00246().__\u003Cref\u003E;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon19 : Runnable
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Button arg\u00242;

        internal __\u003C\u003EAnon19([In] LStatements.UnitLocateStatement obj0, [In] Button obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u00249(this.arg\u00242);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon20 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon20([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00247((BlockFlag) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon21 : Cons
      {
        internal __\u003C\u003EAnon21()
        {
        }

        public void get([In] object obj0) => LStatements.UnitLocateStatement.lambda\u0024rebuild\u00248((Cell) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon22 : Prov
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;

        internal __\u003C\u003EAnon22([In] LStatements.UnitLocateStatement obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024rebuild\u00240().__\u003Cref\u003E;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon23 : Runnable
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Button arg\u00242;
        private readonly Table arg\u00243;

        internal __\u003C\u003EAnon23(
          [In] LStatements.UnitLocateStatement obj0,
          [In] Button obj1,
          [In] Table obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u00243(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon24 : Cons
      {
        private readonly LStatements.UnitLocateStatement arg\u00241;
        private readonly Table arg\u00242;

        internal __\u003C\u003EAnon24([In] LStatements.UnitLocateStatement obj0, [In] Table obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00241(this.arg\u00242, (LLocate) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon25 : Cons
      {
        internal __\u003C\u003EAnon25()
        {
        }

        public void get([In] object obj0) => LStatements.UnitLocateStatement.lambda\u0024rebuild\u00242((Cell) obj0);
      }
    }

    public class UnitRadarStatement : LStatements.RadarStatement
    {
      [LineNumberTable(new byte[] {162, 246, 104, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public UnitRadarStatement()
      {
        LStatements.UnitRadarStatement unitRadarStatement = this;
        this.radar = "0";
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool buildFrom() => false;

      [LineNumberTable(884)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicUnits;

      [LineNumberTable(889)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.RadarI(this.target1, this.target2, this.target3, this.sort, 2, builder.var(this.sortOrder), builder.var(this.output));
    }

    public class WaitStatement : LStatement
    {
      public string value;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.value = obj0;

      [LineNumberTable(new byte[] {162, 40, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WaitStatement()
      {
        LStatements.WaitStatement waitStatement = this;
        this.value = "0.5";
      }

      [LineNumberTable(new byte[] {162, 45, 121, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        this.field(table, this.value, (Cons) new LStatements.WaitStatement.__\u003C\u003EAnon0(this));
        Table table1 = table;
        object obj = (object) " sec";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table1.add(text);
      }

      [LineNumberTable(677)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicOperations;

      [LineNumberTable(682)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.WaitI(builder.var(this.value));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.WaitStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.WaitStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }
    }

    public class WriteStatement : LStatement
    {
      public string input;
      public string target;
      public string address;

      [LineNumberTable(new byte[] {45, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WriteStatement()
      {
        LStatements.WriteStatement writeStatement = this;
        this.input = "result";
        this.target = "cell1";
        this.address = "0";
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00240([In] string obj0) => this.input = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00241([In] string obj0) => this.target = obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024build\u00242([In] string obj0) => this.address = obj0;

      [LineNumberTable(new byte[] {50, 156, 153, 156, 152, 135, 156, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void build(Table table)
      {
        Table table1 = table;
        object obj1 = (object) " write ";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence text1 = charSequence;
        table1.add(text1);
        this.field(table, this.input, (Cons) new LStatements.WriteStatement.__\u003C\u003EAnon0(this));
        Table table2 = table;
        object obj2 = (object) " to ";
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text2 = charSequence;
        table2.add(text2);
        this.fields(table, this.target, (Cons) new LStatements.WriteStatement.__\u003C\u003EAnon1(this));
        this.row(table);
        Table table3 = table;
        object obj3 = (object) " at ";
        charSequence.__\u003Cref\u003E = (__Null) obj3;
        CharSequence text3 = charSequence;
        table3.add(text3);
        this.field(table, this.address, (Cons) new LStatements.WriteStatement.__\u003C\u003EAnon2(this));
      }

      [LineNumberTable(117)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Color color() => Pal.logicIo;

      [LineNumberTable(122)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override LExecutor.LInstruction build(LAssembler builder) => (LExecutor.LInstruction) new LExecutor.WriteI(builder.var(this.target), builder.var(this.address), builder.var(this.input));

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly LStatements.WriteStatement arg\u00241;

        internal __\u003C\u003EAnon0([In] LStatements.WriteStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly LStatements.WriteStatement arg\u00241;

        internal __\u003C\u003EAnon1([In] LStatements.WriteStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Cons
      {
        private readonly LStatements.WriteStatement arg\u00241;

        internal __\u003C\u003EAnon2([In] LStatements.WriteStatement obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00242((string) obj0);
      }
    }
  }
}
