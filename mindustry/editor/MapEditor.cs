// Decompiled with JetBrains decompiler
// Type: mindustry.editor.MapEditor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.func;
using arc.graphics;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.io;
using mindustry.maps;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class MapEditor : Object
  {
    internal static int[] __\u003C\u003EbrushSizes;
    public StringMap tags;
    public MapRenderer renderer;
    [Modifiers]
    private MapEditor.Context context;
    private OperationStack stack;
    private DrawOperation currentOp;
    private bool loading;
    public int brushSize;
    public int rotation;
    public Block drawBlock;
    public Team drawTeam;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tile tile(int x, int y) => Vars.world.rawTile(x, y);

    [LineNumberTable(new byte[] {21, 103, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(Runnable r)
    {
      this.loading = true;
      r.run();
      this.loading = false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLoading() => this.loading;

    [LineNumberTable(new byte[] {160, 217, 137, 116, 140, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addTileOp(long data)
    {
      if (this.loading)
        return;
      if (this.currentOp == null)
        this.currentOp = new DrawOperation(this);
      this.currentOp.addOperation(data);
      this.renderer.updatePoint((int) TileOp.x(data), (int) TileOp.y(data));
    }

    [LineNumberTable(107)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int width() => Vars.world.width();

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int height() => Vars.world.height();

    [LineNumberTable(new byte[] {65, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBlocksReplace(int x, int y) => this.drawBlocks(x, y, (Boolf) new MapEditor.__\u003C\u003EAnon2(this));

    [LineNumberTable(new byte[] {69, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBlocks(int x, int y) => this.drawBlocks(x, y, false, (Boolf) new MapEditor.__\u003C\u003EAnon3());

    [Signature("(IIZLarc/func/Boolf<Lmindustry/world/Tile;>;)V")]
    [LineNumberTable(new byte[] {159, 111, 162, 112, 127, 14, 127, 14, 109, 191, 2, 159, 5, 239, 78, 99, 139, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBlocks(int x, int y, bool square, Boolf tester)
    {
      int num1 = square ? 1 : 0;
      if (this.drawBlock.isMultiblock())
      {
        x = Mathf.clamp(x, (this.drawBlock.size - 1) / 2, this.width() - this.drawBlock.size / 2 - 1);
        y = Mathf.clamp(y, (this.drawBlock.size - 1) / 2, this.height() - this.drawBlock.size / 2 - 1);
        if (this.hasOverlap(x, y))
          return;
        this.tile(x, y).setBlock(this.drawBlock, this.drawTeam, this.rotation);
      }
      else
      {
        int num2 = !this.drawBlock.isFloor() || object.ReferenceEquals((object) this.drawBlock, (object) Blocks.air) ? 0 : 1;
        Cons drawer = (Cons) new MapEditor.__\u003C\u003EAnon4(this, tester, num2 != 0);
        if (num1 != 0)
          this.drawSquare(x, y, drawer);
        else
          this.drawCircle(x, y, drawer);
      }
    }

    [Signature("(IILarc/func/Cons<Lmindustry/world/Tile;>;)V")]
    [LineNumberTable(new byte[] {160, 116, 116, 116, 127, 1, 136, 122, 162, 238, 56, 41, 233, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawCircle(int x, int y, Cons drawer)
    {
      for (int index1 = -this.brushSize; index1 <= this.brushSize; ++index1)
      {
        for (int index2 = -this.brushSize; index2 <= this.brushSize; ++index2)
        {
          if (Mathf.within((float) index1, (float) index2, (float) this.brushSize - 0.5f + 0.0001f))
          {
            int x1 = x + index1;
            int y1 = y + index2;
            if (x1 >= 0 && y1 >= 0 && (x1 < this.width() && y1 < this.height()))
              drawer.get((object) this.tile(x1, y1));
          }
        }
      }
    }

    [Signature("(IILarc/func/Boolf<Lmindustry/world/Tile;>;)V")]
    [LineNumberTable(new byte[] {73, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawBlocks(int x, int y, Boolf tester) => this.drawBlocks(x, y, false, tester);

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tiles tiles() => Vars.world.tiles;

    [LineNumberTable(new byte[] {42, 102, 103, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void reset()
    {
      this.clearOp();
      this.brushSize = 1;
      this.drawBlock = Blocks.stone;
      this.tags = new StringMap();
    }

    [LineNumberTable(new byte[] {28, 141, 102, 102, 63, 1, 38, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void createTiles([In] int obj0, [In] int obj1)
    {
      Tiles tiles1 = Vars.world.resize(obj0, obj1);
      for (int x1 = 0; x1 < obj0; ++x1)
      {
        for (int y1 = 0; y1 < obj1; ++y1)
        {
          Tiles tiles2 = tiles1;
          int x2 = x1;
          int y2 = y1;
          EditorTile.__\u003Cclinit\u003E();
          EditorTile editorTile = new EditorTile(x1, y1, (int) Blocks.stone.__\u003C\u003Eid, 0, 0);
          tiles2.set(x2, y2, (Tile) editorTile);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 187, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearOp() => this.stack.clear();

    [LineNumberTable(new byte[] {109, 141, 127, 41, 194, 113, 113, 115, 114, 103, 104, 144, 114, 226, 58, 40, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool hasOverlap([In] int obj0, [In] int obj1)
    {
      Tile tile1 = Vars.world.tile(obj0, obj1);
      if (tile1 != null && tile1.isCenter() && (!object.ReferenceEquals((object) tile1.block(), (object) this.drawBlock) && tile1.block().size == this.drawBlock.size) && ((int) tile1.x == obj0 && (int) tile1.y == obj1))
        return false;
      int num1 = -(this.drawBlock.size - 1) / 2;
      int num2 = -(this.drawBlock.size - 1) / 2;
      for (int index1 = 0; index1 < this.drawBlock.size; ++index1)
      {
        for (int index2 = 0; index2 < this.drawBlock.size; ++index2)
        {
          int x = index1 + num1 + obj0;
          int y = index2 + num2 + obj1;
          Tile tile2 = Vars.world.tile(x, y);
          if (tile2 != null && tile2.block().isMultiblock())
            return true;
        }
      }
      return false;
    }

    [Signature("(IILarc/func/Cons<Lmindustry/world/Tile;>;)V")]
    [LineNumberTable(new byte[] {160, 132, 116, 113, 136, 122, 162, 238, 57, 38, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawSquare(int x, int y, Cons drawer)
    {
      for (int index1 = -this.brushSize; index1 <= this.brushSize; ++index1)
      {
        for (int index2 = -this.brushSize; index2 <= this.brushSize; ++index2)
        {
          int x1 = x + index1;
          int y1 = y + index2;
          if (x1 >= 0 && y1 >= 0 && (x1 < this.width() && y1 < this.height()))
            drawer.get((object) this.tile(x1, y1));
        }
      }
    }

    [Modifiers]
    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024beginEdit\u00240([In] Map obj0) => MapIO.loadMap(obj0, (WorldContext) this.context);

    [Modifiers]
    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024beginEdit\u00241([In] Pixmap obj0) => MapIO.readImage(obj0, this.tiles());

    [Modifiers]
    [LineNumberTable(115)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024drawBlocksReplace\u00242([In] Tile obj0) => !object.ReferenceEquals((object) obj0.block(), (object) Blocks.air) || this.drawBlock.isFloor();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024drawBlocks\u00243([In] Tile obj0) => true;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 108, 98, 138, 99, 118, 122, 127, 9, 191, 11, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024drawBlocks\u00244([In] Boolf obj0, [In] bool obj1, [In] Tile obj2)
    {
      int num = obj1 ? 1 : 0;
      if (!obj0.get((object) obj2))
        return;
      if (num != 0)
      {
        obj2.setFloor(this.drawBlock.asFloor());
      }
      else
      {
        if (obj2.block().isMultiblock() && !this.drawBlock.isMultiblock())
          return;
        if (this.drawBlock.rotate && obj2.build != null && obj2.build.rotation != this.rotation)
          this.addTileOp(TileOp.get(obj2.x, obj2.y, (byte) DrawOperation.OpType.__\u003C\u003Erotation.ordinal(), (short) (sbyte) this.rotation));
        obj2.setBlock(this.drawBlock, this.drawTeam, this.rotation);
      }
    }

    [Modifiers]
    [LineNumberTable(283)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024resize\u00245([In] int obj0, [In] int obj1, [In] Point2 obj2) => obj2.sub(obj0, obj1);

    [LineNumberTable(new byte[] {159, 162, 168, 107, 140, 108, 203, 135, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapEditor()
    {
      MapEditor mapEditor = this;
      this.tags = new StringMap();
      this.renderer = new MapRenderer(this);
      this.context = new MapEditor.Context(this);
      this.stack = new OperationStack();
      this.brushSize = 1;
      this.drawBlock = Blocks.stone;
      this.drawTeam = Team.__\u003C\u003Esharded;
    }

    [LineNumberTable(new byte[] {159, 183, 134, 103, 104, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginEdit(int width, int height)
    {
      this.reset();
      this.loading = true;
      this.createTiles(width, height);
      this.renderer.resize(width, height);
      this.loading = false;
    }

    [LineNumberTable(new byte[] {0, 134, 103, 113, 127, 9, 159, 2, 114, 119, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginEdit(Map map)
    {
      this.reset();
      this.loading = true;
      this.tags.putAll((ObjectMap) map.__\u003C\u003Etags);
      if (String.instancehelper_equals(map.__\u003C\u003Efile.parent().parent().name(), (object) "1127400") && Vars.steam)
        this.tags.put((object) "steamid", (object) map.__\u003C\u003Efile.parent().name());
      this.load((Runnable) new MapEditor.__\u003C\u003EAnon0(this, map));
      this.renderer.resize(this.width(), this.height());
      this.loading = false;
    }

    [LineNumberTable(new byte[] {13, 134, 114, 114, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void beginEdit(Pixmap pixmap)
    {
      this.reset();
      this.createTiles(pixmap.getWidth(), pixmap.getHeight());
      this.load((Runnable) new MapEditor.__\u003C\u003EAnon1(this, pixmap));
      this.renderer.resize(this.width(), this.height());
    }

    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Map createMap(Fi file) => new Map(file, this.width(), this.height(), new StringMap((ObjectMap) this.tags), true);

    [LineNumberTable(new byte[] {160, 70, 127, 8, 159, 2, 98, 105, 127, 24, 114, 233, 61, 233, 71, 99, 171, 104, 133, 127, 5, 127, 0, 139, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addCliffs()
    {
      Iterator iterator1 = Vars.world.tiles.iterator();
      while (iterator1.hasNext())
      {
        Tile tile1 = (Tile) iterator1.next();
        if (tile1.block().isStatic() && !object.ReferenceEquals((object) tile1.block(), (object) Blocks.cliff))
        {
          int num = 0;
          for (int index = 0; index < 8; ++index)
          {
            Tile tile2 = Vars.world.tiles.get((int) tile1.x + Geometry.__\u003C\u003Ed8[index].x, (int) tile1.y + Geometry.__\u003C\u003Ed8[index].y);
            if (tile2 != null && !tile2.block().isStatic())
              num |= 1 << index;
          }
          if (num != 0)
            tile1.setBlock(Blocks.cliff);
          tile1.data = (byte) num;
        }
      }
      Iterator iterator2 = Vars.world.tiles.iterator();
      while (iterator2.hasNext())
      {
        Tile tile = (Tile) iterator2.next();
        if (!object.ReferenceEquals((object) tile.block(), (object) Blocks.cliff) && tile.block().isStatic())
          tile.setBlock(Blocks.air);
      }
    }

    [LineNumberTable(new byte[] {160, 96, 127, 8, 159, 2, 98, 105, 127, 24, 114, 233, 61, 233, 71, 99, 171, 104, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addFloorCliffs()
    {
      Iterator iterator = Vars.world.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile1 = (Tile) iterator.next();
        if (tile1.floor().hasSurface() && !object.ReferenceEquals((object) tile1.block(), (object) Blocks.cliff))
        {
          int num = 0;
          for (int index = 0; index < 8; ++index)
          {
            Tile tile2 = Vars.world.tiles.get((int) tile1.x + Geometry.__\u003C\u003Ed8[index].x, (int) tile1.y + Geometry.__\u003C\u003Ed8[index].y);
            if (tile2 != null && !tile2.floor().hasSurface())
              num |= 1 << index;
          }
          if (num != 0)
            tile1.setBlock(Blocks.cliff);
          tile1.data = (byte) num;
        }
      }
    }

    [LineNumberTable(new byte[] {160, 146, 134, 107, 118, 135, 109, 107, 107, 108, 111, 116, 108, 106, 138, 120, 127, 0, 191, 0, 110, 100, 124, 107, 238, 69, 98, 255, 5, 41, 43, 235, 93, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
      this.clearOp();
      Tiles tiles1 = Vars.world.tiles;
      int num1 = (this.width() - width) / 2;
      int num2 = (this.height() - height) / 2;
      this.loading = true;
      Tiles tiles2 = Vars.world.resize(width, height);
      for (int x1 = 0; x1 < width; ++x1)
      {
        for (int y1 = 0; y1 < height; ++y1)
        {
          int x2 = num1 + x1;
          int y2 = num2 + y1;
          if (tiles1.@in(x2, y2))
          {
            tiles2.set(x1, y1, tiles1.getn(x2, y2));
            Tile tile = tiles2.getn(x1, y1);
            tile.x = (short) x1;
            tile.y = (short) y1;
            if (tile.build != null && tile.isCenter())
            {
              tile.build.x = (float) (x1 * 8) + tile.block().offset;
              tile.build.y = (float) (y1 * 8) + tile.block().offset;
              object obj = tile.build.config();
              if (obj != null)
              {
                object objA = BuildPlan.pointConfig(tile.block(), obj, (Cons) new MapEditor.__\u003C\u003EAnon5(num1, num2));
                if (!object.ReferenceEquals(objA, obj))
                  tile.build.configureAny(objA);
              }
            }
          }
          else
          {
            Tiles tiles3 = tiles2;
            int x3 = x1;
            int y3 = y1;
            EditorTile.__\u003Cclinit\u003E();
            EditorTile editorTile = new EditorTile(x1, y1, (int) Blocks.stone.__\u003C\u003Eid, 0, 0);
            tiles3.set(x3, y3, (Tile) editorTile);
          }
        }
      }
      this.renderer.resize(width, height);
      this.loading = false;
    }

    [LineNumberTable(new byte[] {160, 191, 109, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void undo()
    {
      if (!this.stack.canUndo())
        return;
      this.stack.undo();
    }

    [LineNumberTable(new byte[] {160, 197, 109, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void redo()
    {
      if (!this.stack.canRedo())
        return;
      this.stack.redo();
    }

    [LineNumberTable(317)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canUndo() => this.stack.canUndo();

    [LineNumberTable(321)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canRedo() => this.stack.canRedo();

    [LineNumberTable(new byte[] {160, 211, 118, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flushOp()
    {
      if (this.currentOp == null || this.currentOp.isEmpty())
        return;
      this.stack.add(this.currentOp);
      this.currentOp = (DrawOperation) null;
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static MapEditor()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.editor.MapEditor"))
        return;
      MapEditor.__\u003C\u003EbrushSizes = new int[8]
      {
        1,
        2,
        3,
        4,
        5,
        9,
        15,
        20
      };
    }

    [Modifiers]
    public static int[] brushSizes
    {
      [HideFromJava] get => MapEditor.__\u003C\u003EbrushSizes;
    }

    internal class Context : Object, WorldContext
    {
      [Modifiers]
      internal MapEditor this\u00240;

      [LineNumberTable(339)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Context([In] MapEditor obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(342)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tile tile([In] int obj0) => Vars.world.tiles.geti(obj0);

      [LineNumberTable(new byte[] {160, 233, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void resize([In] int obj0, [In] int obj1) => Vars.world.resize(obj0, obj1);

      [LineNumberTable(new byte[] {160, 238, 109, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tile create([In] int obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
      {
        EditorTile editorTile = new EditorTile(obj0, obj1, obj2, obj3, obj4);
        this.this\u00240.tiles().set(obj0, obj1, (Tile) editorTile);
        return (Tile) editorTile;
      }

      [LineNumberTable(359)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isGenerating() => Vars.world.isGenerating();

      [LineNumberTable(new byte[] {160, 250, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void begin() => Vars.world.beginMapLoad();

      [LineNumberTable(new byte[] {160, 255, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void end() => Vars.world.endMapLoad();

      [HideFromJava]
      public virtual void onReadBuilding() => WorldContext.\u003Cdefault\u003EonReadBuilding((WorldContext) this);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly MapEditor arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon0([In] MapEditor obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024beginEdit\u00240(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly MapEditor arg\u00241;
      private readonly Pixmap arg\u00242;

      internal __\u003C\u003EAnon1([In] MapEditor obj0, [In] Pixmap obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024beginEdit\u00241(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      private readonly MapEditor arg\u00241;

      internal __\u003C\u003EAnon2([In] MapEditor obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024drawBlocksReplace\u00242((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolf
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get([In] object obj0) => (MapEditor.lambda\u0024drawBlocks\u00243((Tile) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly MapEditor arg\u00241;
      private readonly Boolf arg\u00242;
      private readonly bool arg\u00243;

      internal __\u003C\u003EAnon4([In] MapEditor obj0, [In] Boolf obj1, [In] bool obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024drawBlocks\u00244(this.arg\u00242, this.arg\u00243, (Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly int arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon5([In] int obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => MapEditor.lambda\u0024resize\u00245(this.arg\u00241, this.arg\u00242, (Point2) obj0);
    }
  }
}
