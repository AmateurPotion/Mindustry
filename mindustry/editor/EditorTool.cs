// Decompiled with JetBrains decompiler
// Type: mindustry.editor.EditorTool
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  [Signature("Ljava/lang/Enum<Lmindustry/editor/EditorTool;>;")]
  [Modifiers]
  [Serializable]
  public class EditorTool : Enum
  {
    [Modifiers]
    internal static EditorTool __\u003C\u003Ezoom;
    [Modifiers]
    internal static EditorTool __\u003C\u003Epick;
    [Modifiers]
    internal static EditorTool __\u003C\u003Eline;
    [Modifiers]
    internal static EditorTool __\u003C\u003Epencil;
    [Modifiers]
    internal static EditorTool __\u003C\u003Eeraser;
    [Modifiers]
    internal static EditorTool __\u003C\u003Efill;
    [Modifiers]
    internal static EditorTool __\u003C\u003Espray;
    internal static EditorTool[] __\u003C\u003Eall;
    internal string[] __\u003C\u003EaltModes;
    public KeyCode key;
    public int mode;
    public bool edit;
    public bool draggable;
    [Modifiers]
    private static EditorTool[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Larc/input/KeyCode;[Ljava/lang/String;)V")]
    [LineNumberTable(new byte[] {160, 147, 234, 43, 139, 231, 84, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private EditorTool(string _param1, int _param2, KeyCode _param3, params string[] _param4)
      : base(_param1, _param2)
    {
      EditorTool editorTool = this;
      this.key = KeyCode.__\u003C\u003Eunset;
      this.mode = -1;
      this.__\u003C\u003EaltModes = _param4;
      this.key = _param3;
      GC.KeepAlive((object) this);
    }

    [Signature("(Larc/input/KeyCode;)V")]
    [LineNumberTable(new byte[] {160, 139, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private EditorTool([In] string obj0, [In] int obj1, [In] KeyCode obj2)
      : this(obj0, obj1, new string[0])
    {
      EditorTool editorTool = this;
      this.key = obj2;
      GC.KeepAlive((object) this);
    }

    [Signature("([Ljava/lang/String;)V")]
    [LineNumberTable(new byte[] {160, 143, 234, 47, 139, 231, 80, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private EditorTool(string _param1, int _param2, params string[] _param3)
      : base(_param1, _param2)
    {
      EditorTool editorTool = this;
      this.key = KeyCode.__\u003C\u003Eunset;
      this.mode = -1;
      this.__\u003C\u003EaltModes = _param3;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EditorTool[] values() => (EditorTool[]) EditorTool.\u0024VALUES.Clone();

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static EditorTool valueOf(string name) => (EditorTool) Enum.valueOf((Class) ClassLiteral<EditorTool>.Value, name);

    [Signature("()V")]
    [LineNumberTable(new byte[] {160, 135, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private EditorTool([In] string obj0, [In] int obj1)
      : this(obj0, obj1, new string[0])
    {
      GC.KeepAlive((object) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void touched(MapEditor editor, int x, int y)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void touchedLine(MapEditor editor, int x1, int y1, int x2, int y2)
    {
    }

    [Modifiers]
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal EditorTool([In] string obj0, [In] int obj1, [In] KeyCode obj2, [In] EditorTool.\u0031 obj3)
      : this(obj0, obj1, obj2)
    {
      GC.KeepAlive((object) this);
    }

    [Modifiers]
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal EditorTool(
      [In] string obj0,
      [In] int obj1,
      [In] KeyCode obj2,
      [In] string[] obj3,
      [In] EditorTool.\u0031 obj4)
      : this(obj0, obj1, obj2, obj3)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 139, 141, 117, 250, 72, 255, 17, 88, 255, 25, 88, 255, 9, 83, 255, 17, 160, 119, 255, 9, 159, 60, 255, 36, 160, 222})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static EditorTool()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.editor.EditorTool"))
        return;
      EditorTool.__\u003C\u003Ezoom = new EditorTool(nameof (zoom), 0, KeyCode.__\u003C\u003Ev);
      EditorTool.\u0031.__\u003Cclinit\u003E();
      EditorTool.__\u003C\u003Epick = (EditorTool) new EditorTool.\u0031(nameof (pick), 1, KeyCode.__\u003C\u003Ei);
      EditorTool.\u0032.__\u003Cclinit\u003E();
      EditorTool.__\u003C\u003Eline = (EditorTool) new EditorTool.\u0032(nameof (line), 2, KeyCode.__\u003C\u003El, new string[2]
      {
        "replace",
        "orthogonal"
      });
      EditorTool.\u0033.__\u003Cclinit\u003E();
      EditorTool.__\u003C\u003Epencil = (EditorTool) new EditorTool.\u0033(nameof (pencil), 3, KeyCode.__\u003C\u003Eb, new string[3]
      {
        "replace",
        "square",
        "drawteams"
      });
      EditorTool.\u0034.__\u003Cclinit\u003E();
      EditorTool.__\u003C\u003Eeraser = (EditorTool) new EditorTool.\u0034(nameof (eraser), 4, KeyCode.__\u003C\u003Ee, new string[1]
      {
        "eraseores"
      });
      EditorTool.\u0035.__\u003Cclinit\u003E();
      EditorTool.__\u003C\u003Efill = (EditorTool) new EditorTool.\u0035(nameof (fill), 5, KeyCode.__\u003C\u003Eg, new string[2]
      {
        "replaceall",
        "fillteams"
      });
      EditorTool.\u0036.__\u003Cclinit\u003E();
      EditorTool.__\u003C\u003Espray = (EditorTool) new EditorTool.\u0036(nameof (spray), 6, KeyCode.__\u003C\u003Er, new string[1]
      {
        "replace"
      });
      EditorTool.\u0024VALUES = new EditorTool[7]
      {
        EditorTool.__\u003C\u003Ezoom,
        EditorTool.__\u003C\u003Epick,
        EditorTool.__\u003C\u003Eline,
        EditorTool.__\u003C\u003Epencil,
        EditorTool.__\u003C\u003Eeraser,
        EditorTool.__\u003C\u003Efill,
        EditorTool.__\u003C\u003Espray
      };
      EditorTool.__\u003C\u003Eall = EditorTool.values();
    }

    [Modifiers]
    public static EditorTool zoom
    {
      [HideFromJava] get => EditorTool.__\u003C\u003Ezoom;
    }

    [Modifiers]
    public static EditorTool pick
    {
      [HideFromJava] get => EditorTool.__\u003C\u003Epick;
    }

    [Modifiers]
    public static EditorTool line
    {
      [HideFromJava] get => EditorTool.__\u003C\u003Eline;
    }

    [Modifiers]
    public static EditorTool pencil
    {
      [HideFromJava] get => EditorTool.__\u003C\u003Epencil;
    }

    [Modifiers]
    public static EditorTool eraser
    {
      [HideFromJava] get => EditorTool.__\u003C\u003Eeraser;
    }

    [Modifiers]
    public static EditorTool fill
    {
      [HideFromJava] get => EditorTool.__\u003C\u003Efill;
    }

    [Modifiers]
    public static EditorTool spray
    {
      [HideFromJava] get => EditorTool.__\u003C\u003Espray;
    }

    [Modifiers]
    public static EditorTool[] all
    {
      [HideFromJava] get => EditorTool.__\u003C\u003Eall;
    }

    [Modifiers]
    public string[] altModes
    {
      [HideFromJava] get => this.__\u003C\u003EaltModes;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EaltModes = value;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      zoom,
      pick,
      line,
      pencil,
      eraser,
      fill,
      spray,
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0031 : EditorTool
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(15)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] string obj0, [In] int obj1, [In] KeyCode obj2)
        : base(obj0, obj1, obj2, (EditorTool.\u0031) null)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {159, 159, 150, 105, 127, 46})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touched([In] MapEditor obj0, [In] int obj1, [In] int obj2)
      {
        if (!Structs.inBounds(obj1, obj2, obj0.width(), obj0.height()))
          return;
        Tile tile = obj0.tile(obj1, obj2);
        obj0.drawBlock = object.ReferenceEquals((object) tile.block(), (object) Blocks.air) || !tile.block().inEditor ? (!object.ReferenceEquals((object) tile.overlay(), (object) Blocks.air) ? (Block) tile.overlay() : (Block) tile.floor()) : tile.block();
      }

      [HideFromJava]
      static \u0031() => EditorTool.__\u003Cclinit\u003E();
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0032 : EditorTool
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(23)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032(string _param1, int _param2, KeyCode _param3, params string[] _param4)
        : base(_param1, _param2, _param3, _param4, (EditorTool.\u0031) null)
      {
        GC.KeepAlive((object) this);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {159, 179, 136, 170, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024touchedLine\u00240([In] MapEditor obj0, [In] int obj1, [In] int obj2)
      {
        if (this.mode == 0)
          obj0.drawBlocksReplace(obj1, obj2);
        else
          obj0.drawBlocks(obj1, obj2);
      }

      [LineNumberTable(new byte[] {159, 170, 105, 116, 133, 195, 247, 73})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchedLine([In] MapEditor obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
      {
        if (this.mode == 1)
        {
          if (Math.abs(obj3 - obj1) > Math.abs(obj4 - obj2))
            obj4 = obj2;
          else
            obj3 = obj1;
        }
        Bresenham2.line(obj1, obj2, obj3, obj4, (Intc2) new EditorTool.\u0032.__\u003C\u003EAnon0(this, obj0));
      }

      [HideFromJava]
      static \u0032() => EditorTool.__\u003Cclinit\u003E();

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Intc2
      {
        private readonly EditorTool.\u0032 arg\u00241;
        private readonly MapEditor arg\u00242;

        internal __\u003C\u003EAnon0([In] EditorTool.\u0032 obj0, [In] MapEditor obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024touchedLine\u00240(this.arg\u00242, obj0, obj1);
      }
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0033 : EditorTool
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 189, 142, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033(string _param1, int _param2, KeyCode _param3, params string[] _param4)
        : base(_param1, _param2, _param3, _param4, (EditorTool.\u0031) null)
      {
        EditorTool.\u0033 obj = this;
        this.edit = true;
        this.draggable = true;
        GC.KeepAlive((object) this);
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024touched\u00240([In] Tile obj0) => true;

      [Modifiers]
      [LineNumberTable(66)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024touched\u00241([In] MapEditor obj0, [In] Tile obj1) => obj1.setTeam(obj0.drawTeam);

      [LineNumberTable(new byte[] {5, 137, 106, 136, 106, 137, 117, 137, 179})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touched([In] MapEditor obj0, [In] int obj1, [In] int obj2)
      {
        if (this.mode == -1)
          obj0.drawBlocks(obj1, obj2);
        else if (this.mode == 0)
          obj0.drawBlocksReplace(obj1, obj2);
        else if (this.mode == 1)
        {
          obj0.drawBlocks(obj1, obj2, true, (Boolf) new EditorTool.\u0033.__\u003C\u003EAnon0());
        }
        else
        {
          if (this.mode != 2)
            return;
          obj0.drawCircle(obj1, obj2, (Cons) new EditorTool.\u0033.__\u003C\u003EAnon1(obj0));
        }
      }

      [HideFromJava]
      static \u0033() => EditorTool.__\u003Cclinit\u003E();

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Boolf
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get([In] object obj0) => (EditorTool.\u0033.lambda\u0024touched\u00240((Tile) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly MapEditor arg\u00241;

        internal __\u003C\u003EAnon1([In] MapEditor obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => EditorTool.\u0033.lambda\u0024touched\u00241(this.arg\u00241, (Tile) obj0);
      }
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0034 : EditorTool
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {21, 142, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034(string _param1, int _param2, KeyCode _param3, params string[] _param4)
        : base(_param1, _param2, _param3, _param4, (EditorTool.\u0031) null)
      {
        EditorTool.\u0034 obj = this;
        this.edit = true;
        this.draggable = true;
        GC.KeepAlive((object) this);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {30, 137, 104, 136, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024touched\u00240([In] Tile obj0)
      {
        if (this.mode == -1)
        {
          obj0.remove();
        }
        else
        {
          if (this.mode != 0)
            return;
          obj0.clearOverlay();
        }
      }

      [LineNumberTable(new byte[] {29, 243, 73})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touched([In] MapEditor obj0, [In] int obj1, [In] int obj2) => obj0.drawCircle(obj1, obj2, (Cons) new EditorTool.\u0034.__\u003C\u003EAnon0(this));

      [HideFromJava]
      static \u0034() => EditorTool.__\u003Cclinit\u003E();

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly EditorTool.\u0034 arg\u00241;

        internal __\u003C\u003EAnon0([In] EditorTool.\u0034 obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024touched\u00240((Tile) obj0);
      }
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0035 : EditorTool
    {
      internal IntSeq stack;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {40, 142, 167})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035(string _param1, int _param2, KeyCode _param3, params string[] _param4)
        : base(_param1, _param2, _param3, _param4, (EditorTool.\u0031) null)
      {
        EditorTool.\u0035 obj = this;
        this.edit = true;
        this.stack = new IntSeq();
        GC.KeepAlive((object) this);
      }

      [Signature("(Lmindustry/editor/MapEditor;IIZLarc/func/Boolf<Lmindustry/world/Tile;>;Larc/func/Cons<Lmindustry/world/Tile;>;)V")]
      [LineNumberTable(new byte[] {159, 105, 99, 142, 131, 102, 104, 107, 107, 233, 61, 40, 235, 77, 107, 178, 127, 5, 109, 105, 137, 98, 123, 100, 102, 123, 143, 123, 116, 101, 119, 163, 125, 116, 101, 125, 131, 137, 101, 255, 5, 71, 226, 58, 130, 103, 101, 103, 171})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void fill(
        [In] MapEditor obj0,
        [In] int obj1,
        [In] int obj2,
        [In] bool obj3,
        [In] Boolf obj4,
        [In] Cons obj5)
      {
        int num1 = obj3 ? 1 : 0;
        int num2 = obj0.width();
        int num3 = obj0.height();
        if (num1 != 0)
        {
          for (int x = 0; x < num2; ++x)
          {
            for (int y = 0; y < num3; ++y)
            {
              Tile tile = obj0.tile(x, y);
              if (obj4.get((object) tile))
                obj5.get((object) tile);
            }
          }
        }
        else
        {
          this.stack.clear();
          this.stack.add(Point2.pack(obj1, obj2));
label_10:
          OutOfMemoryError outOfMemoryError1;
          try
          {
            while (this.stack.size > 0 && this.stack.size < num2 * num3)
            {
              int pos = this.stack.pop();
              obj1 = (int) Point2.x(pos);
              obj2 = (int) Point2.y(pos);
              int x1 = obj1;
              while (x1 >= 0 && obj4.get((object) obj0.tile(x1, obj2)))
                x1 += -1;
              int x2 = x1 + 1;
              int num4 = 0;
              int num5 = 0;
              while (true)
              {
                if (x2 < num2 && obj4.get((object) obj0.tile(x2, obj2)))
                {
                  obj5.get((object) obj0.tile(x2, obj2));
                  if (num4 == 0 && obj2 > 0 && obj4.get((object) obj0.tile(x2, obj2 - 1)))
                  {
                    this.stack.add(Point2.pack(x2, obj2 - 1));
                    num4 = 1;
                  }
                  else if (num4 != 0 && !obj4.get((object) obj0.tile(x2, obj2 - 1)))
                    num4 = 0;
                  if (num5 == 0 && obj2 < num3 - 1 && obj4.get((object) obj0.tile(x2, obj2 + 1)))
                  {
                    this.stack.add(Point2.pack(x2, obj2 + 1));
                    num5 = 1;
                  }
                  else if (num5 != 0 && obj2 < num3 - 1 && !obj4.get((object) obj0.tile(x2, obj2 + 1)))
                    num5 = 0;
                  ++x2;
                }
                else
                  goto label_10;
              }
            }
            this.stack.clear();
            return;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<OutOfMemoryError>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              outOfMemoryError1 = (OutOfMemoryError) m0;
          }
          OutOfMemoryError outOfMemoryError2 = outOfMemoryError1;
          this.stack = (IntSeq) null;
          java.lang.System.gc();
          Throwable.instancehelper_printStackTrace((Exception) outOfMemoryError2);
          this.stack = new IntSeq();
        }
      }

      [Modifiers]
      [LineNumberTable(121)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024touched\u00240([In] Block obj0, [In] Tile obj1) => object.ReferenceEquals((object) obj1.overlay(), (object) obj0) && (obj1.floor().hasSurface() || !obj1.floor().needsSurface);

      [Modifiers]
      [LineNumberTable(122)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024touched\u00241([In] MapEditor obj0, [In] Tile obj1) => obj1.setOverlay(obj0.drawBlock);

      [Modifiers]
      [LineNumberTable(126)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024touched\u00242([In] Block obj0, [In] Tile obj1) => object.ReferenceEquals((object) obj1.floor(), (object) obj0);

      [Modifiers]
      [LineNumberTable(127)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024touched\u00243([In] MapEditor obj0, [In] Tile obj1) => obj1.setFloorUnder(obj0.drawBlock.asFloor());

      [Modifiers]
      [LineNumberTable(131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024touched\u00244([In] Block obj0, [In] Tile obj1) => object.ReferenceEquals((object) obj1.block(), (object) obj0);

      [Modifiers]
      [LineNumberTable(132)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024touched\u00245([In] MapEditor obj0, [In] Tile obj1) => obj1.setBlock(obj0.drawBlock, obj0.drawTeam);

      [Modifiers]
      [LineNumberTable(143)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024touched\u00246([In] Team obj0, [In] Tile obj1) => obj1.getTeamID() == obj0.__\u003C\u003Eid && obj1.synthetic();

      [Modifiers]
      [LineNumberTable(143)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024touched\u00247([In] MapEditor obj0, [In] Tile obj1) => obj1.setTeam(obj0.drawTeam);

      [LineNumberTable(new byte[] {49, 118, 137, 141, 109, 193, 148, 109, 225, 70, 109, 103, 111, 108, 108, 114, 103, 111, 108, 108, 98, 104, 112, 109, 204, 119, 171, 104, 104, 112, 191, 2})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touched([In] MapEditor obj0, [In] int obj1, [In] int obj2)
      {
        if (!Structs.inBounds(obj1, obj2, obj0.width(), obj0.height()))
          return;
        Tile tile = obj0.tile(obj1, obj2);
        if (obj0.drawBlock.isMultiblock())
          EditorTool.__\u003C\u003Epencil.touched(obj0, obj1, obj2);
        else if (this.mode == 0 || this.mode == -1)
        {
          if (tile.block().isMultiblock())
            return;
          Boolf boolf;
          Cons cons;
          if (obj0.drawBlock.isOverlay())
          {
            Floor floor = tile.overlay();
            if (object.ReferenceEquals((object) floor, (object) obj0.drawBlock))
              return;
            boolf = (Boolf) new EditorTool.\u0035.__\u003C\u003EAnon0((Block) floor);
            cons = (Cons) new EditorTool.\u0035.__\u003C\u003EAnon1(obj0);
          }
          else if (obj0.drawBlock.isFloor())
          {
            Floor floor = tile.floor();
            if (object.ReferenceEquals((object) floor, (object) obj0.drawBlock))
              return;
            boolf = (Boolf) new EditorTool.\u0035.__\u003C\u003EAnon2((Block) floor);
            cons = (Cons) new EditorTool.\u0035.__\u003C\u003EAnon3(obj0);
          }
          else
          {
            Block block = tile.block();
            if (object.ReferenceEquals((object) block, (object) obj0.drawBlock))
              return;
            boolf = (Boolf) new EditorTool.\u0035.__\u003C\u003EAnon4(block);
            cons = (Cons) new EditorTool.\u0035.__\u003C\u003EAnon5(obj0);
          }
          this.fill(obj0, obj1, obj2, this.mode == 0, boolf, cons);
        }
        else
        {
          if (this.mode != 1 || !tile.synthetic())
            return;
          Team team = tile.team();
          if (object.ReferenceEquals((object) team, (object) obj0.drawTeam))
            return;
          this.fill(obj0, obj1, obj2, false, (Boolf) new EditorTool.\u0035.__\u003C\u003EAnon6(team), (Cons) new EditorTool.\u0035.__\u003C\u003EAnon7(obj0));
        }
      }

      [HideFromJava]
      static \u0035() => EditorTool.__\u003Cclinit\u003E();

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Boolf
      {
        private readonly Block arg\u00241;

        internal __\u003C\u003EAnon0([In] Block obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (EditorTool.\u0035.lambda\u0024touched\u00240(this.arg\u00241, (Tile) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly MapEditor arg\u00241;

        internal __\u003C\u003EAnon1([In] MapEditor obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => EditorTool.\u0035.lambda\u0024touched\u00241(this.arg\u00241, (Tile) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Boolf
      {
        private readonly Block arg\u00241;

        internal __\u003C\u003EAnon2([In] Block obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (EditorTool.\u0035.lambda\u0024touched\u00242(this.arg\u00241, (Tile) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon3 : Cons
      {
        private readonly MapEditor arg\u00241;

        internal __\u003C\u003EAnon3([In] MapEditor obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => EditorTool.\u0035.lambda\u0024touched\u00243(this.arg\u00241, (Tile) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon4 : Boolf
      {
        private readonly Block arg\u00241;

        internal __\u003C\u003EAnon4([In] Block obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (EditorTool.\u0035.lambda\u0024touched\u00244(this.arg\u00241, (Tile) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon5 : Cons
      {
        private readonly MapEditor arg\u00241;

        internal __\u003C\u003EAnon5([In] MapEditor obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => EditorTool.\u0035.lambda\u0024touched\u00245(this.arg\u00241, (Tile) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon6 : Boolf
      {
        private readonly Team arg\u00241;

        internal __\u003C\u003EAnon6([In] Team obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (EditorTool.\u0035.lambda\u0024touched\u00246(this.arg\u00241, (Tile) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon7 : Cons
      {
        private readonly MapEditor arg\u00241;

        internal __\u003C\u003EAnon7([In] MapEditor obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => EditorTool.\u0035.lambda\u0024touched\u00247(this.arg\u00241, (Tile) obj0);
      }
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0036 : EditorTool
    {
      [Modifiers]
      internal double chance;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 95, 110, 176, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036(string _param1, int _param2, KeyCode _param3, params string[] _param4)
        : base(_param1, _param2, _param3, _param4, (EditorTool.\u0031) null)
      {
        EditorTool.\u0036 obj = this;
        this.chance = 0.012;
        this.edit = true;
        this.draggable = true;
        GC.KeepAlive((object) this);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 109, 112, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024touched\u00240([In] MapEditor obj0, [In] Tile obj1)
      {
        if (!Mathf.chance(0.012))
          return;
        obj1.setFloor(obj0.drawBlock.asFloor());
      }

      [Modifiers]
      [LineNumberTable(228)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024touched\u00241([In] Tile obj0) => Mathf.chance(0.012) && !object.ReferenceEquals((object) obj0.block(), (object) Blocks.air);

      [Modifiers]
      [LineNumberTable(230)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024touched\u00242([In] Tile obj0) => Mathf.chance(0.012);

      [LineNumberTable(new byte[] {160, 107, 109, 246, 69, 104, 149, 147})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touched([In] MapEditor obj0, [In] int obj1, [In] int obj2)
      {
        if (obj0.drawBlock.isFloor())
          obj0.drawCircle(obj1, obj2, (Cons) new EditorTool.\u0036.__\u003C\u003EAnon0(this, obj0));
        else if (this.mode == 0)
          obj0.drawBlocks(obj1, obj2, (Boolf) new EditorTool.\u0036.__\u003C\u003EAnon1(this));
        else
          obj0.drawBlocks(obj1, obj2, (Boolf) new EditorTool.\u0036.__\u003C\u003EAnon2(this));
      }

      [HideFromJava]
      static \u0036() => EditorTool.__\u003Cclinit\u003E();

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Cons
      {
        private readonly EditorTool.\u0036 arg\u00241;
        private readonly MapEditor arg\u00242;

        internal __\u003C\u003EAnon0([In] EditorTool.\u0036 obj0, [In] MapEditor obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024touched\u00240(this.arg\u00242, (Tile) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Boolf
      {
        private readonly EditorTool.\u0036 arg\u00241;

        internal __\u003C\u003EAnon1([In] EditorTool.\u0036 obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024touched\u00241((Tile) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Boolf
      {
        private readonly EditorTool.\u0036 arg\u00241;

        internal __\u003C\u003EAnon2([In] EditorTool.\u0036 obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024touched\u00242((Tile) obj0) ? 1 : 0) != 0;
      }
    }
  }
}
