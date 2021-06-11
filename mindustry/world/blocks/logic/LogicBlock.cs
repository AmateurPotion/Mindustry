// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.logic.LogicBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math.geom;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.zip;
using mindustry.ai.types;
using mindustry.core;
using mindustry.entities.units;
using mindustry.gen;
using mindustry.graphics;
using mindustry.io;
using mindustry.logic;
using mindustry.ui;
using mindustry.world.meta;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.logic
{
  public class LogicBlock : Block
  {
    private const int maxByteLen = 512000;
    public int maxInstructionScale;
    public int instructionsPerTick;
    public float range;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("([BLarc/struct/Seq<Lmindustry/world/blocks/logic/LogicBlock$LogicLink;>;)[B")]
    [LineNumberTable(new byte[] {42, 102, 172, 167, 104, 135, 145, 103, 124, 139, 109, 109, 109, 130, 134, 127, 2, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] compress(byte[] bytes, Seq links)
    {
      byte[] byteArray;
      IOException ioException1;
      try
      {
        ByteArrayOutputStream arrayOutputStream = new ByteArrayOutputStream();
        DataOutputStream dataOutputStream = new DataOutputStream((OutputStream) new DeflaterOutputStream((OutputStream) arrayOutputStream));
        dataOutputStream.write(1);
        dataOutputStream.writeInt(bytes.Length);
        ((FilterOutputStream) dataOutputStream).write(bytes);
        int num = links.count((Boolf) new LogicBlock.__\u003C\u003EAnon2());
        dataOutputStream.writeInt(num);
        Iterator iterator = links.iterator();
        while (iterator.hasNext())
        {
          LogicBlock.LogicLink logicLink = (LogicBlock.LogicLink) iterator.next();
          if (logicLink.active)
          {
            dataOutputStream.writeUTF(logicLink.name);
            dataOutputStream.writeShort(logicLink.x);
            dataOutputStream.writeShort(logicLink.y);
          }
        }
        ((FilterOutputStream) dataOutputStream).close();
        byteArray = arrayOutputStream.toByteArray();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_7;
      }
      return byteArray;
label_7:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {23, 103, 125, 140, 127, 5, 137, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getLinkName(Block block)
    {
      string str1 = block.__\u003C\u003Ename;
      string str2 = str1;
      object obj = (object) "-";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      if (String.instancehelper_contains(str2, charSequence2))
      {
        string[] strArray = String.instancehelper_split(str1, "-");
        str1 = strArray.Length < 2 || !String.instancehelper_equals(strArray[strArray.Length - 1], (object) "large") && !Strings.canParseFloat(strArray[strArray.Length - 1]) ? strArray[strArray.Length - 1] : strArray[strArray.Length - 2];
      }
      return str1;
    }

    [Modifiers]
    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] LogicBlock.LogicBuild obj0, [In] byte[] obj1) => obj0.readCompressed(obj1, true);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 191, 121, 113, 142, 125, 141, 99, 146, 111, 107, 180, 119, 191, 0, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00243([In] LogicBlock.LogicBuild obj0, [In] Integer obj1)
    {
      if (!obj0.validLink(Vars.world.build(obj1.intValue())))
        return;
      Building building = Vars.world.build(obj1.intValue());
      int x = building.tileX();
      int y = building.tileY();
      LogicBlock.LogicLink logicLink = (LogicBlock.LogicLink) obj0.links.find((Boolf) new LogicBlock.__\u003C\u003EAnon3(x, y));
      string linkName = LogicBlock.getLinkName(building.block);
      if (logicLink != null)
      {
        logicLink.active = !logicLink.active;
        if (!String.instancehelper_startsWith(logicLink.name, linkName))
        {
          logicLink.name = "";
          logicLink.name = obj0.findLinkName(building.block);
        }
      }
      else
      {
        obj0.links.remove((Boolf) new LogicBlock.__\u003C\u003EAnon4(building));
        obj0.links.add((object) new LogicBlock.LogicLink(x, y, obj0.findLinkName(building.block), true));
      }
      obj0.updateCode(obj0.code, true, (Cons) null);
    }

    [Modifiers]
    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024compress\u00244([In] LogicBlock.LogicLink obj0) => obj0.active;

    [Modifiers]
    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00241([In] int obj0, [In] int obj1, [In] LogicBlock.LogicLink obj2) => obj2.x == obj0 && obj2.y == obj1;

    [Modifiers]
    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00242([In] Building obj0, [In] LogicBlock.LogicLink obj1) => object.ReferenceEquals((object) Vars.world.build(obj1.x, obj1.y), (object) obj0);

    [LineNumberTable(new byte[] {159, 180, 233, 59, 103, 103, 203, 103, 103, 103, 107, 135, 149, 245, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LogicBlock(string name)
      : base(name)
    {
      LogicBlock logicBlock = this;
      this.maxInstructionScale = 5;
      this.instructionsPerTick = 1;
      this.range = 80f;
      this.update = true;
      this.solid = true;
      this.configurable = true;
      this.group = BlockGroup.__\u003C\u003Elogic;
      this.schematicPriority = 5;
      this.config((Class) ClassLiteral<byte[]>.Value, (Cons2) new LogicBlock.__\u003C\u003EAnon0());
      this.config((Class) ClassLiteral<Integer>.Value, (Cons2) new LogicBlock.__\u003C\u003EAnon1());
    }

    [Signature("(Ljava/lang/String;Larc/struct/Seq<Lmindustry/world/blocks/logic/LogicBlock$LogicLink;>;)[B")]
    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] compress(string code, Seq links) => LogicBlock.compress(String.instancehelper_getBytes(code, Vars.__\u003C\u003Echarset), links);

    [LineNumberTable(new byte[] {73, 134, 127, 3, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003ElinkRange, this.range / 8f, StatUnit.__\u003C\u003Eblocks);
      this.stats.add(Stat.__\u003C\u003Einstructions, (float) (this.instructionsPerTick * 60), StatUnit.__\u003C\u003EperSecond);
    }

    [LineNumberTable(new byte[] {81, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawPlace(int x, int y, int rotation, bool valid) => Drawf.circles((float) (x * 8) + this.offset, (float) (y * 8) + this.offset, this.range);

    [Signature("(Ljava/lang/Object;Larc/func/Cons<Larc/math/geom/Point2;>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {86, 159, 6, 145, 135, 135, 159, 14, 104, 136, 136, 135, 108, 104, 144, 127, 16, 127, 3, 112, 114, 114, 255, 4, 55, 235, 76, 123, 63, 2, 231, 37, 255, 74, 92, 98, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object pointConfig(object config, Cons transformer)
    {
      object obj = config;
      if (obj is byte[])
      {
        byte[] numArray1;
        if (object.ReferenceEquals((object) (numArray1 = (byte[]) obj), (object) (byte[]) obj))
        {
          DataInputStream dataInputStream;
          byte[] numArray2;
          Exception exception1;
          IOException ioException1;
          try
          {
            dataInputStream = new DataInputStream((InputStream) new InflaterInputStream((InputStream) new ByteArrayInputStream(numArray1)));
            try
            {
              ((FilterInputStream) dataInputStream).read();
              int length = dataInputStream.readInt();
              if (length > 512000)
              {
                string str = new StringBuilder().append("Malformed logic data! Length: ").append(length).toString();
                Throwable.__\u003CsuppressFillInStackTrace\u003E();
                throw new RuntimeException(str);
              }
              byte[] bytes = new byte[length];
              dataInputStream.readFully(bytes);
              int num1 = dataInputStream.readInt();
              Seq links = new Seq();
              for (int index = 0; index < num1; ++index)
              {
                string name = dataInputStream.readUTF();
                int num2 = (int) dataInputStream.readShort();
                int num3 = (int) dataInputStream.readShort();
                Tmp.__\u003C\u003Ep2.set(ByteCodeHelper.f2i(this.offset / 4f), ByteCodeHelper.f2i(this.offset / 4f));
                transformer.get((object) Tmp.__\u003C\u003Ep1.set(num2 * 2, num3 * 2).sub(Tmp.__\u003C\u003Ep2));
                Tmp.__\u003C\u003Ep1.add(Tmp.__\u003C\u003Ep2);
                Tmp.__\u003C\u003Ep1.x /= 2;
                Tmp.__\u003C\u003Ep1.y /= 2;
                links.add((object) new LogicBlock.LogicLink(Tmp.__\u003C\u003Ep1.x, Tmp.__\u003C\u003Ep1.y, name, true));
              }
              numArray2 = LogicBlock.compress(bytes, links);
            }
            catch (Exception ex)
            {
              exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
              goto label_12;
            }
            ((FilterInputStream) dataInputStream).close();
            goto label_14;
          }
          catch (IOException ex)
          {
            ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_13;
          }
label_12:
          Exception exception2 = exception1;
          Exception exception3;
          Exception exception4;
          IOException ioException2;
          try
          {
            exception3 = exception2;
            try
            {
              ((FilterInputStream) dataInputStream).close();
              goto label_24;
            }
            catch (Exception ex)
            {
              exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
          }
          catch (IOException ex)
          {
            ioException2 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_20;
          }
          Exception exception5 = exception4;
          IOException ioException3;
          try
          {
            Exception exception6 = exception5;
            Throwable.instancehelper_addSuppressed(exception3, exception6);
            goto label_24;
          }
          catch (IOException ex)
          {
            ioException3 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          IOException ioException4 = ioException3;
          goto label_27;
label_20:
          ioException4 = ioException2;
          goto label_27;
label_24:
          IOException ioException5;
          try
          {
            throw Throwable.__\u003Cunmap\u003E(exception3);
          }
          catch (IOException ex)
          {
            ioException5 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          ioException4 = ioException5;
          goto label_27;
label_13:
          ioException4 = ioException1;
          goto label_27;
label_14:
          return (object) numArray2;
label_27:
          Log.err((Exception) ioException4);
        }
      }
      return config;
    }

    [HideFromJava]
    static LogicBlock() => Block.__\u003Cclinit\u003E();

    [Implements(new string[] {"mindustry.logic.Ranged"})]
    public class LogicBuild : Building, Ranged, Posc, Position, Entityc, Teamc
    {
      public string code;
      public LExecutor executor;
      public float accumulator;
      [Signature("Larc/struct/Seq<Lmindustry/world/blocks/logic/LogicBlock$LogicLink;>;")]
      public Seq links;
      public bool checkedDuplicates;
      [Modifiers]
      internal LogicBlock this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(491)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool validLink(Building other) => other != null && other.isValid() && (object.ReferenceEquals((object) other.team, (object) this.team) && other.within((Position) this, this.this\u00240.range + (float) (other.block.size * 8) / 2f)) && !(other is ConstructBlock.ConstructBuild);

      [LineNumberTable(new byte[] {160, 149, 103, 113, 130, 127, 5, 143, 148, 105, 104, 180, 2, 193, 133, 131, 106, 106, 100, 226, 61, 232, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string findLinkName(Block block)
      {
        string linkName = LogicBlock.getLinkName(block);
        Bits bits = new Bits(this.links.size);
        int num1 = 1;
        Iterator iterator = this.links.iterator();
        while (iterator.hasNext())
        {
          LogicBlock.LogicLink logicLink = (LogicBlock.LogicLink) iterator.next();
          if (String.instancehelper_startsWith(logicLink.name, linkName))
          {
            string str = String.instancehelper_substring(logicLink.name, String.instancehelper_length(linkName));
            try
            {
              int index = Integer.parseInt(str);
              bits.set(index);
              num1 = Math.max(index, num1);
            }
            catch (NumberFormatException ex)
            {
            }
          }
        }
        int num2 = 0;
        for (int index = 1; index < num1 + 2; ++index)
        {
          if (!bits.get(index))
          {
            num2 = index;
            break;
          }
        }
        return new StringBuilder().append(linkName).append(num2).toString();
      }

      [Signature("(Ljava/lang/String;ZLarc/func/Cons<Lmindustry/logic/LAssembler;>;)V")]
      [LineNumberTable(new byte[] {159, 68, 130, 102, 199, 167, 127, 4, 127, 23, 159, 4, 165, 127, 6, 144, 99, 127, 8, 114, 122, 118, 156, 133, 123, 123, 125, 156, 134, 127, 6, 115, 109, 111, 113, 255, 6, 59, 235, 76, 99, 167, 113, 125, 157, 255, 6, 71, 226, 58, 98, 121, 167, 176})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void updateCode(string str, bool keep, Cons assemble)
      {
        int num1 = keep ? 1 : 0;
        if (str == null)
          return;
        this.code = str;
        Exception exception1;
        try
        {
          LAssembler builder = LAssembler.assemble(str);
          Iterator iterator1 = this.links.iterator();
          while (iterator1.hasNext())
          {
            LogicBlock.LogicLink logicLink1 = (LogicBlock.LogicLink) iterator1.next();
            if (logicLink1.active)
            {
              LogicBlock.LogicLink logicLink2 = logicLink1;
              int num2 = this.validLink(Vars.world.build(logicLink1.x, logicLink1.y)) ? 1 : 0;
              LogicBlock.LogicLink logicLink3 = logicLink2;
              int num3 = num2;
              logicLink3.valid = num2 != 0;
              if (num3 != 0)
                builder.putConst(logicLink1.name, (object) Vars.world.build(logicLink1.x, logicLink1.y));
            }
          }
          this.executor.links = new Building[this.links.count((Boolf) new LogicBlock.LogicBuild.__\u003C\u003EAnon0())];
          this.executor.linkIds.clear();
          int num4 = 0;
          Iterator iterator2 = this.links.iterator();
          while (iterator2.hasNext())
          {
            LogicBlock.LogicLink logicLink = (LogicBlock.LogicLink) iterator2.next();
            if (logicLink.active && logicLink.valid)
            {
              Building building1 = Vars.world.build(logicLink.x, logicLink.y);
              Building[] links = this.executor.links;
              int index = num4;
              ++num4;
              Building building2 = building1;
              links[index] = building2;
              if (building1 != null)
                this.executor.linkIds.add(building1.id);
            }
          }
          builder.putConst("@mapw", (object) Integer.valueOf(Vars.world.width()));
          builder.putConst("@maph", (object) Integer.valueOf(Vars.world.height()));
          builder.putConst("@links", (object) Integer.valueOf(this.executor.links.Length));
          builder.putConst("@ipt", (object) Integer.valueOf(this.this\u00240.instructionsPerTick));
          if (num1 != 0)
          {
            LExecutor.Var[] vars = this.executor.vars;
            int length = vars.Length;
            for (int index = 0; index < length; ++index)
            {
              LExecutor.Var var1 = vars[index];
              int num2 = String.instancehelper_equals(var1.__\u003C\u003Ename, (object) "@unit") ? 1 : 0;
              if (!var1.constant || num2 != 0)
              {
                LAssembler.BVar var2 = builder.getVar(var1.__\u003C\u003Ename);
                if (var2 != null && (!var2.constant || num2 != 0))
                  var2.value = !var1.isobj ? (object) Double.valueOf(var1.numval) : (object) (Double) var1.objval;
              }
            }
          }
          assemble?.get((object) builder);
          builder.getVar("@this").value = (object) this;
          builder.putConst("@thisx", (object) Float.valueOf(World.conv(this.x)));
          builder.putConst("@thisy", (object) Float.valueOf(World.conv(this.y)));
          this.executor.load(builder);
          return;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception1 = (Exception) m0;
        }
        Exception exception2 = exception1;
        Log.err("Failed to compile logic program @", (object) this.code);
        Log.err((Exception) exception2);
        this.executor.load("");
      }

      [LineNumberTable(new byte[] {159, 92, 98, 177, 135, 103, 127, 14, 104, 136, 140, 136, 163, 105, 39, 205, 108, 104, 144, 99, 108, 172, 144, 100, 110, 107, 207, 247, 46, 235, 86, 191, 7, 2, 98, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void readCompressed(byte[] data, bool relative)
      {
        int num1 = relative ? 1 : 0;
        DataInputStream dataInputStream = new DataInputStream((InputStream) new InflaterInputStream((InputStream) new ByteArrayInputStream(data)));
        IOException ioException;
        try
        {
          int num2 = ((FilterInputStream) dataInputStream).read();
          int length = dataInputStream.readInt();
          if (length > 512000)
          {
            string str = new StringBuilder().append("Malformed logic data! Length: ").append(length).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException(str);
          }
          byte[] numArray = new byte[length];
          dataInputStream.readFully(numArray);
          this.links.clear();
          int num3 = dataInputStream.readInt();
          if (num2 == 0)
          {
            for (int index = 0; index < num3; ++index)
              dataInputStream.readInt();
          }
          else
          {
            for (int index = 0; index < num3; ++index)
            {
              string name = dataInputStream.readUTF();
              int x = (int) dataInputStream.readShort();
              int y = (int) dataInputStream.readShort();
              if (num1 != 0)
              {
                x = (int) (short) (x + this.tileX());
                y = (int) (short) (y + this.tileY());
              }
              Building building = Vars.world.build(x, y);
              if (building != null)
              {
                string linkName = LogicBlock.getLinkName(building.block);
                if (!String.instancehelper_startsWith(name, linkName))
                  name = this.findLinkName(building.block);
              }
              this.links.add((object) new LogicBlock.LogicLink(x, y, name, false));
            }
          }
          this.updateCode(String.newhelper(numArray, Vars.__\u003C\u003Echarset));
          return;
        }
        catch (IOException ex)
        {
          ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        Log.err((Exception) ioException);
      }

      [LineNumberTable(new byte[] {160, 180, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void updateCode(string str) => this.updateCode(str, false, (Cons) null);

      [Signature("()Larc/struct/Seq<Lmindustry/world/blocks/logic/LogicBlock$LogicLink;>;")]
      [LineNumberTable(new byte[] {161, 81, 113, 127, 1, 103, 115, 115, 103, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq relativeConnections()
      {
        Seq seq = new Seq(this.links.size);
        Iterator iterator = this.links.iterator();
        while (iterator.hasNext())
        {
          LogicBlock.LogicLink logicLink = ((LogicBlock.LogicLink) iterator.next()).copy();
          logicLink.x -= this.tileX();
          logicLink.y -= this.tileY();
          seq.add((object) logicLink);
        }
        return seq;
      }

      [LineNumberTable(447)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual byte[] config() => LogicBlock.compress(this.code, this.relativeConnections());

      [Modifiers]
      [LineNumberTable(313)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024updateCode\u00240([In] LogicBlock.LogicLink obj0) => obj0.valid && obj0.active;

      [Modifiers]
      [LineNumberTable(417)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024updateTile\u00241(
        [In] Building obj0,
        [In] LogicBlock.LogicLink obj1,
        [In] LogicBlock.LogicLink obj2)
      {
        return object.ReferenceEquals((object) Vars.world.build(obj2.x, obj2.y), (object) obj0) && !object.ReferenceEquals((object) obj2, (object) obj1);
      }

      [Modifiers]
      [LineNumberTable(485)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024drawSelect\u00242([In] Unit obj0)
      {
        UnitController unitController = obj0.controller();
        LogicAI logicAi;
        return unitController is LogicAI && object.ReferenceEquals((object) (logicAi = (LogicAI) unitController), (object) (LogicAI) unitController) && object.ReferenceEquals((object) logicAi.controller, (object) this);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 116, 127, 5})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024drawSelect\u00243([In] Unit obj0) => Drawf.square(obj0.x, obj0.y, obj0.hitSize, obj0.rotation + 45f);

      [Modifiers]
      [LineNumberTable(new byte[] {161, 127, 127, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00245() => Vars.ui.logic.show(this.code, (Cons) new LogicBlock.LogicBuild.__\u003C\u003EAnon7(this));

      [Modifiers]
      [LineNumberTable(530)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024write\u00246([In] LExecutor.Var obj0) => !obj0.constant;

      [Modifiers]
      [LineNumberTable(new byte[] {161, 219, 102, 106, 107, 233, 61, 230, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024read\u00247(
        [In] int obj0,
        [In] string[] obj1,
        [In] object[] obj2,
        [In] LAssembler obj3)
      {
        for (int index = 0; index < obj0; ++index)
        {
          LAssembler.BVar var = obj3.getVar(obj1[index]);
          if (var != null && !var.constant)
            var.value = obj2[index];
        }
      }

      [Modifiers]
      [LineNumberTable(497)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024buildConfiguration\u00244([In] string obj0) => this.configure((object) LogicBlock.compress(obj0, this.relativeConnections()));

      [LineNumberTable(new byte[] {160, 78, 143, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LogicBuild(LogicBlock _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LogicBlock.LogicBuild logicBuild = this;
        this.code = "";
        this.executor = new LExecutor();
        this.accumulator = 0.0f;
        this.links = new Seq();
        this.checkedDuplicates = false;
      }

      [LineNumberTable(new byte[] {160, 138, 166, 121, 127, 10, 23, 230, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void onProximityAdded()
      {
        base.onProximityAdded();
        LExecutor.Var[] vars = this.executor.vars;
        int length = vars.Length;
        for (int index = 0; index < length; ++index)
        {
          LExecutor.Var var = vars[index];
          object objval = var.objval;
          TypeIO.BuildingBox buildingBox;
          if (objval is TypeIO.BuildingBox && object.ReferenceEquals((object) (buildingBox = (TypeIO.BuildingBox) objval), (object) (TypeIO.BuildingBox) objval))
            var.objval = (object) Vars.world.build(buildingBox.pos);
        }
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool canPickup() => false;

      [LineNumberTable(371)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float range() => this.this\u00240.range;

      [LineNumberTable(new byte[] {161, 6, 145, 107, 103, 102, 102, 127, 1, 120, 100, 111, 167, 98, 205, 134, 103, 131, 117, 147, 141, 126, 109, 99, 104, 100, 184, 139, 179, 185, 99, 226, 42, 240, 92, 100, 174, 107, 159, 19, 159, 31, 114, 109, 139, 243, 60, 232, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTile()
      {
        this.executor.team = this.team;
        if (!this.checkedDuplicates)
        {
          this.checkedDuplicates = true;
          IntSet intSet = new IntSet();
          Seq array = new Seq();
          Iterator iterator = this.links.iterator();
          while (iterator.hasNext())
          {
            LogicBlock.LogicLink logicLink = (LogicBlock.LogicLink) iterator.next();
            Building building = Vars.world.build(logicLink.x, logicLink.y);
            if (building != null && !intSet.add(building.id))
              array.add((object) logicLink);
          }
          this.links.removeAll(array);
        }
        int num1 = 0;
        int num2 = 1;
label_7:
        while (num2 != 0)
        {
          num2 = 0;
          int index = 0;
          LogicBlock.LogicLink logicLink;
          while (true)
          {
            if (index < this.links.size)
            {
              logicLink = (LogicBlock.LogicLink) this.links.get(index);
              if (logicLink.active)
              {
                int num3 = this.validLink(Vars.world.build(logicLink.x, logicLink.y)) ? 1 : 0;
                if (num3 != (logicLink.valid ? 1 : 0))
                {
                  num1 = 1;
                  logicLink.valid = num3 != 0;
                  if (num3 != 0)
                    break;
                }
              }
              ++index;
            }
            else
              goto label_7;
          }
          Building building = Vars.world.build(logicLink.x, logicLink.y);
          logicLink.name = "";
          logicLink.name = this.findLinkName(building.block);
          this.links.removeAll((Boolf) new LogicBlock.LogicBuild.__\u003C\u003EAnon1(building, logicLink));
          num2 = 1;
        }
        if (num1 != 0)
          this.updateCode(this.code, true, (Cons) null);
        if (!this.enabled)
          return;
        this.accumulator += this.edelta() * (float) this.this\u00240.instructionsPerTick * (!this.consValid() ? 0.0f : 1f);
        if ((double) this.accumulator > (double) (this.this\u00240.maxInstructionScale * this.this\u00240.instructionsPerTick))
          this.accumulator = (float) (this.this\u00240.maxInstructionScale * this.this\u00240.instructionsPerTick);
        for (int index = 0; index < ByteCodeHelper.f2i(this.accumulator); ++index)
        {
          if (this.executor.initialized())
            this.executor.runOnce();
          --this.accumulator;
        }
      }

      [LineNumberTable(new byte[] {161, 93, 134, 156, 127, 4, 119, 113, 159, 19, 165, 127, 4, 119, 113, 159, 1, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawConfigure()
      {
        base.drawConfigure();
        Drawf.circles(this.x, this.y, this.this\u00240.range);
        Iterator iterator1 = this.links.iterator();
        while (iterator1.hasNext())
        {
          LogicBlock.LogicLink logicLink = (LogicBlock.LogicLink) iterator1.next();
          Building other = Vars.world.build(logicLink.x, logicLink.y);
          if (logicLink.active && this.validLink(other))
            Drawf.square(other.x, other.y, (float) (other.block.size * 8) / 2f + 1f, Pal.place);
        }
        Iterator iterator2 = this.links.iterator();
        while (iterator2.hasNext())
        {
          LogicBlock.LogicLink logicLink = (LogicBlock.LogicLink) iterator2.next();
          Building other = Vars.world.build(logicLink.x, logicLink.y);
          if (logicLink.active && this.validLink(other))
          {
            double num = (double) other.block.drawPlaceText(logicLink.name, other.tileX(), other.tileY(), true);
          }
        }
      }

      [LineNumberTable(new byte[] {161, 115, 191, 0})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawSelect() => Groups.unit.each((Boolf) new LogicBlock.LogicBuild.__\u003C\u003EAnon2(this), (Cons) new LogicBlock.LogicBuild.__\u003C\u003EAnon3());

      [LineNumberTable(new byte[] {161, 126, 159, 1, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void buildConfiguration(Table table) => table.button((Drawable) Icon.pencil, Styles.clearTransi, (Runnable) new LogicBlock.LogicBuild.__\u003C\u003EAnon4(this)).size(40f);

      [LineNumberTable(new byte[] {161, 133, 105, 102, 162, 105, 113, 162})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool onConfigureTileTapped(Building other)
      {
        if (object.ReferenceEquals((object) this, (object) other))
        {
          this.deselect();
          return false;
        }
        if (!this.validLink(other))
          return base.onConfigureTileTapped(other);
        this.configure((object) Integer.valueOf(other.pos()));
        return false;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override byte version() => 1;

      [LineNumberTable(new byte[] {161, 153, 135, 114, 104, 167, 155, 103, 116, 142, 170, 140, 125, 108, 232, 54, 233, 78, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        byte[] array = LogicBlock.compress(this.code, this.links);
        write.i(array.Length);
        write.b(array);
        int i = Structs.count((object[]) this.executor.vars, (Boolf) new LogicBlock.LogicBuild.__\u003C\u003EAnon5());
        write.i(i);
        for (int index = 0; index < this.executor.vars.Length; ++index)
        {
          LExecutor.Var var = this.executor.vars[index];
          if (!var.constant)
          {
            write.str(var.__\u003C\u003Ename);
            object @object = !var.isobj ? (object) Double.valueOf(var.numval) : (object) (Double) var.objval;
            if (@object is Unit)
              @object = (object) null;
            TypeIO.writeObject(write, @object);
          }
        }
        write.i(0);
      }

      [LineNumberTable(new byte[] {159, 4, 67, 136, 100, 103, 103, 104, 104, 98, 108, 108, 103, 102, 39, 230, 69, 167, 104, 136, 104, 104, 137, 103, 231, 59, 232, 72, 136, 138, 252, 74})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num1 = (int) (sbyte) revision;
        base.read(read, (byte) num1);
        if (num1 == 1)
        {
          byte[] numArray = new byte[read.i()];
          read.b(numArray);
          this.readCompressed(numArray, false);
        }
        else
        {
          this.code = read.str();
          this.links.clear();
          int num2 = (int) read.s();
          for (int index = 0; index < num2; ++index)
            read.i();
        }
        int length = read.i();
        string[] strArray = new string[length];
        object[] objArray = new object[length];
        for (int index = 0; index < length; ++index)
        {
          string str = read.str();
          object obj = TypeIO.readObjectBoxed(read, true);
          strArray[index] = str;
          objArray[index] = obj;
        }
        int num3 = read.i();
        read.skip(num3 * 8);
        this.updateCode(this.code, false, (Cons) new LogicBlock.LogicBuild.__\u003C\u003EAnon6(length, strArray, objArray));
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(192)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Econfig() => (object) this.config();

      [HideFromJava]
      public override float angleTo([In] Position obj0) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0);

      [HideFromJava]
      public override float angleTo([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003EangleTo((Position) this, obj0, obj1);

      [HideFromJava]
      public override float dst2([In] Position obj0) => Position.\u003Cdefault\u003Edst2((Position) this, obj0);

      [HideFromJava]
      public override float dst([In] Position obj0) => Position.\u003Cdefault\u003Edst((Position) this, obj0);

      [HideFromJava]
      public override float dst([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst((Position) this, obj0, obj1);

      [HideFromJava]
      public override float dst2([In] float obj0, [In] float obj1) => Position.\u003Cdefault\u003Edst2((Position) this, obj0, obj1);

      [HideFromJava]
      public override bool within([In] Position obj0, [In] float obj1) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1);

      [HideFromJava]
      public override bool within([In] float obj0, [In] float obj1, [In] float obj2) => Position.\u003Cdefault\u003Ewithin((Position) this, obj0, obj1, obj2);

      [HideFromJava]
      static LogicBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get([In] object obj0) => (LogicBlock.LogicBuild.lambda\u0024updateCode\u00240((LogicBlock.LogicLink) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Boolf
      {
        private readonly Building arg\u00241;
        private readonly LogicBlock.LogicLink arg\u00242;

        internal __\u003C\u003EAnon1([In] Building obj0, [In] LogicBlock.LogicLink obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public bool get([In] object obj0) => (LogicBlock.LogicBuild.lambda\u0024updateTile\u00241(this.arg\u00241, this.arg\u00242, (LogicBlock.LogicLink) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Boolf
      {
        private readonly LogicBlock.LogicBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] LogicBlock.LogicBuild obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024drawSelect\u00242((Unit) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Cons
      {
        internal __\u003C\u003EAnon3()
        {
        }

        public void get([In] object obj0) => LogicBlock.LogicBuild.lambda\u0024drawSelect\u00243((Unit) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Runnable
      {
        private readonly LogicBlock.LogicBuild arg\u00241;

        internal __\u003C\u003EAnon4([In] LogicBlock.LogicBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024buildConfiguration\u00245();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon5 : Boolf
      {
        internal __\u003C\u003EAnon5()
        {
        }

        public bool get([In] object obj0) => (LogicBlock.LogicBuild.lambda\u0024write\u00246((LExecutor.Var) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon6 : Cons
      {
        private readonly int arg\u00241;
        private readonly string[] arg\u00242;
        private readonly object[] arg\u00243;

        internal __\u003C\u003EAnon6([In] int obj0, [In] string[] obj1, [In] object[] obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void get([In] object obj0) => LogicBlock.LogicBuild.lambda\u0024read\u00247(this.arg\u00241, this.arg\u00242, this.arg\u00243, (LAssembler) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon7 : Cons
      {
        private readonly LogicBlock.LogicBuild arg\u00241;

        internal __\u003C\u003EAnon7([In] LogicBlock.LogicBuild obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024buildConfiguration\u00244((string) obj0);
      }
    }

    public class LogicLink : Object
    {
      public bool active;
      public bool valid;
      public int x;
      public int y;
      public string name;

      [LineNumberTable(new byte[] {159, 98, 131, 232, 60, 231, 69, 103, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LogicLink(int x, int y, string name, bool valid)
      {
        int num = valid ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LogicBlock.LogicLink logicLink = this;
        this.active = true;
        this.x = x;
        this.y = y;
        this.name = name;
        this.valid = num != 0;
      }

      [LineNumberTable(new byte[] {160, 72, 126, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual LogicBlock.LogicLink copy() => new LogicBlock.LogicLink(this.x, this.y, this.name, this.valid)
      {
        active = this.active
      };
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => LogicBlock.lambda\u0024new\u00240((LogicBlock.LogicBuild) obj0, (byte[]) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons2
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0, [In] object obj1) => LogicBlock.lambda\u0024new\u00243((LogicBlock.LogicBuild) obj0, (Integer) obj1);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (LogicBlock.lambda\u0024compress\u00244((LogicBlock.LogicLink) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Boolf
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon3([In] int obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (LogicBlock.lambda\u0024new\u00241(this.arg\u00241, this.arg\u00242, (LogicBlock.LogicLink) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Boolf
    {
      private readonly Building arg\u00241;

      internal __\u003C\u003EAnon4([In] Building obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (LogicBlock.lambda\u0024new\u00242(this.arg\u00241, (LogicBlock.LogicLink) obj0) ? 1 : 0) != 0;
    }
  }
}
