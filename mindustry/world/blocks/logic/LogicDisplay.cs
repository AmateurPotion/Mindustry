// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.logic.LogicDisplay
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.gen;
using mindustry.graphics;
using mindustry.ui;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.logic
{
  public class LogicDisplay : Block
  {
    public const byte commandClear = 0;
    public const byte commandColor = 1;
    public const byte commandStroke = 2;
    public const byte commandLine = 3;
    public const byte commandRect = 4;
    public const byte commandLineRect = 5;
    public const byte commandPoly = 6;
    public const byte commandLinePoly = 7;
    public const byte commandTriangle = 8;
    public const byte commandImage = 9;
    public int maxSides;
    public int displaySize;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 176, 233, 59, 136, 200, 103, 103, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LogicDisplay(string name)
      : base(name)
    {
      LogicDisplay logicDisplay = this;
      this.maxSides = 25;
      this.displaySize = 64;
      this.update = true;
      this.solid = true;
      this.group = BlockGroup.__\u003C\u003Elogic;
      this.drawDisabled = false;
    }

    [LineNumberTable(new byte[] {159, 185, 134, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setStats()
    {
      base.setStats();
      this.stats.add(Stat.__\u003C\u003EdisplaySize, "@x@", (object) Integer.valueOf(this.displaySize), (object) Integer.valueOf(this.displaySize));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int unpackSign([In] int obj0) => (obj0 & 511) * ((obj0 & 512) == 0 ? 1 : -1);

    [HideFromJava]
    static LogicDisplay() => Block.__\u003Cclinit\u003E();

    internal class DisplayCmdStruct : Object
    {
      public byte type;
      public int x;
      public int y;
      public int p1;
      public int p2;
      public int p3;
      public int p4;

      [LineNumberTable(129)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal DisplayCmdStruct()
      {
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/world/blocks/logic/LogicDisplay$GraphicsType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class GraphicsType : Enum
    {
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003Eclear;
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003Ecolor;
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003Estroke;
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003Eline;
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003Erect;
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003ElineRect;
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003Epoly;
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003ElinePoly;
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003Etriangle;
      [Modifiers]
      internal static LogicDisplay.GraphicsType __\u003C\u003Eimage;
      internal static LogicDisplay.GraphicsType[] __\u003C\u003Eall;
      [Modifiers]
      private static LogicDisplay.GraphicsType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(113)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static LogicDisplay.GraphicsType valueOf(string name) => (LogicDisplay.GraphicsType) Enum.valueOf((Class) ClassLiteral<LogicDisplay.GraphicsType>.Value, name);

      [LineNumberTable(113)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static LogicDisplay.GraphicsType[] values() => (LogicDisplay.GraphicsType[]) LogicDisplay.GraphicsType.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(113)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private GraphicsType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {159, 114, 141, 112, 112, 112, 112, 112, 112, 112, 112, 112, 241, 54, 255, 62, 76})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static GraphicsType()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.world.blocks.logic.LogicDisplay$GraphicsType"))
          return;
        LogicDisplay.GraphicsType.__\u003C\u003Eclear = new LogicDisplay.GraphicsType(nameof (clear), 0);
        LogicDisplay.GraphicsType.__\u003C\u003Ecolor = new LogicDisplay.GraphicsType(nameof (color), 1);
        LogicDisplay.GraphicsType.__\u003C\u003Estroke = new LogicDisplay.GraphicsType(nameof (stroke), 2);
        LogicDisplay.GraphicsType.__\u003C\u003Eline = new LogicDisplay.GraphicsType(nameof (line), 3);
        LogicDisplay.GraphicsType.__\u003C\u003Erect = new LogicDisplay.GraphicsType(nameof (rect), 4);
        LogicDisplay.GraphicsType.__\u003C\u003ElineRect = new LogicDisplay.GraphicsType(nameof (lineRect), 5);
        LogicDisplay.GraphicsType.__\u003C\u003Epoly = new LogicDisplay.GraphicsType(nameof (poly), 6);
        LogicDisplay.GraphicsType.__\u003C\u003ElinePoly = new LogicDisplay.GraphicsType(nameof (linePoly), 7);
        LogicDisplay.GraphicsType.__\u003C\u003Etriangle = new LogicDisplay.GraphicsType(nameof (triangle), 8);
        LogicDisplay.GraphicsType.__\u003C\u003Eimage = new LogicDisplay.GraphicsType(nameof (image), 9);
        LogicDisplay.GraphicsType.\u0024VALUES = new LogicDisplay.GraphicsType[10]
        {
          LogicDisplay.GraphicsType.__\u003C\u003Eclear,
          LogicDisplay.GraphicsType.__\u003C\u003Ecolor,
          LogicDisplay.GraphicsType.__\u003C\u003Estroke,
          LogicDisplay.GraphicsType.__\u003C\u003Eline,
          LogicDisplay.GraphicsType.__\u003C\u003Erect,
          LogicDisplay.GraphicsType.__\u003C\u003ElineRect,
          LogicDisplay.GraphicsType.__\u003C\u003Epoly,
          LogicDisplay.GraphicsType.__\u003C\u003ElinePoly,
          LogicDisplay.GraphicsType.__\u003C\u003Etriangle,
          LogicDisplay.GraphicsType.__\u003C\u003Eimage
        };
        LogicDisplay.GraphicsType.__\u003C\u003Eall = LogicDisplay.GraphicsType.values();
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType clear
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003Eclear;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType color
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003Ecolor;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType stroke
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003Estroke;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType line
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003Eline;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType rect
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003Erect;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType lineRect
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003ElineRect;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType poly
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003Epoly;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType linePoly
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003ElinePoly;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType triangle
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003Etriangle;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType image
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003Eimage;
      }

      [Modifiers]
      public static LogicDisplay.GraphicsType[] all
      {
        [HideFromJava] get => LogicDisplay.GraphicsType.__\u003C\u003Eall;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        clear,
        color,
        stroke,
        line,
        rect,
        lineRect,
        poly,
        linePoly,
        triangle,
        image,
      }
    }

    public class LogicDisplayBuild : Building
    {
      public FrameBuffer buffer;
      public float color;
      public float stroke;
      public LongQueue commands;
      [Modifiers]
      internal LogicDisplay this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {9, 104, 159, 2, 112, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00240()
      {
        if (this.buffer != null)
          return;
        this.buffer = new FrameBuffer(this.this\u00240.displaySize, this.this\u00240.displaySize);
        this.buffer.begin(Pal.darkerMetal);
        this.buffer.end();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {19, 112, 127, 8, 107, 107, 139, 112, 108, 104, 120, 159, 21, 127, 20, 127, 17, 116, 116, 116, 127, 7, 127, 7, 122, 127, 2, 119, 153, 133, 107, 106, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00241()
      {
        Tmp.__\u003C\u003Em1.set(Draw.proj());
        Draw.proj(0.0f, 0.0f, (float) this.this\u00240.displaySize, (float) this.this\u00240.displaySize);
        this.buffer.begin();
        Draw.color(this.color);
        Lines.stroke(this.stroke);
        while (!this.commands.isEmpty())
        {
          long displaycmd = this.commands.removeFirst();
          int num1 = (int) (sbyte) DisplayCmd.type(displaycmd);
          int r = LogicDisplay.unpackSign(DisplayCmd.x(displaycmd));
          int g = LogicDisplay.unpackSign(DisplayCmd.y(displaycmd));
          int num2 = LogicDisplay.unpackSign(DisplayCmd.p1(displaycmd));
          int a = LogicDisplay.unpackSign(DisplayCmd.p2(displaycmd));
          int num3 = LogicDisplay.unpackSign(DisplayCmd.p3(displaycmd));
          int num4 = LogicDisplay.unpackSign(DisplayCmd.p4(displaycmd));
          switch (num1)
          {
            case 0:
              Core.graphics.clear((float) r / (float) byte.MaxValue, (float) g / (float) byte.MaxValue, (float) num2 / (float) byte.MaxValue, 1f);
              continue;
            case 1:
              LogicDisplay.LogicDisplayBuild logicDisplayBuild1 = this;
              float floatBits = Color.toFloatBits(r, g, num2, a);
              double num5 = (double) floatBits;
              this.color = floatBits;
              Draw.color((float) num5);
              continue;
            case 2:
              LogicDisplay.LogicDisplayBuild logicDisplayBuild2 = this;
              float num6 = (float) r;
              double num7 = (double) num6;
              this.stroke = num6;
              Lines.stroke((float) num7);
              continue;
            case 3:
              Lines.line((float) r, (float) g, (float) num2, (float) a);
              continue;
            case 4:
              Fill.crect((float) r, (float) g, (float) num2, (float) a);
              continue;
            case 5:
              Lines.rect((float) r, (float) g, (float) num2, (float) a);
              continue;
            case 6:
              Fill.poly((float) r, (float) g, Math.min(num2, this.this\u00240.maxSides), (float) a, (float) num3);
              continue;
            case 7:
              Lines.poly((float) r, (float) g, Math.min(num2, this.this\u00240.maxSides), (float) a, (float) num3);
              continue;
            case 8:
              Fill.tri((float) r, (float) g, (float) num2, (float) a, (float) num3, (float) num4);
              continue;
            case 9:
              Draw.rect(Fonts.logicIcon(num2), (float) r, (float) g, (float) a, (float) a, (float) num3);
              continue;
            default:
              continue;
          }
        }
        this.buffer.end();
        Draw.proj(Tmp.__\u003C\u003Em1);
        Draw.reset();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {52, 104, 159, 46})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024draw\u00242()
      {
        if (this.buffer == null)
          return;
        Draw.rect(Draw.wrap((Texture) this.buffer.getTexture()), this.x, this.y, (float) this.buffer.getWidth() * Draw.scl, (float) -this.buffer.getHeight() * Draw.scl);
      }

      [LineNumberTable(new byte[] {159, 190, 143, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LogicDisplayBuild(LogicDisplay _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LogicDisplay.LogicDisplayBuild logicDisplayBuild = this;
        this.color = Color.__\u003C\u003EwhiteFloatBits;
        this.stroke = 1f;
        this.commands = new LongQueue(256);
      }

      [LineNumberTable(new byte[] {6, 134, 246, 73, 109, 246, 97, 246, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Draw.draw(Draw.z(), (Runnable) new LogicDisplay.LogicDisplayBuild.__\u003C\u003EAnon0(this));
        if (!this.commands.isEmpty())
          Draw.draw(Draw.z(), (Runnable) new LogicDisplay.LogicDisplayBuild.__\u003C\u003EAnon1(this));
        Draw.draw(Draw.z(), (Runnable) new LogicDisplay.LogicDisplayBuild.__\u003C\u003EAnon2(this));
      }

      [HideFromJava]
      static LogicDisplayBuild() => Building.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly LogicDisplay.LogicDisplayBuild arg\u00241;

        internal __\u003C\u003EAnon0([In] LogicDisplay.LogicDisplayBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024draw\u00240();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly LogicDisplay.LogicDisplayBuild arg\u00241;

        internal __\u003C\u003EAnon1([In] LogicDisplay.LogicDisplayBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024draw\u00241();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly LogicDisplay.LogicDisplayBuild arg\u00241;

        internal __\u003C\u003EAnon2([In] LogicDisplay.LogicDisplayBuild obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024draw\u00242();
      }
    }
  }
}
