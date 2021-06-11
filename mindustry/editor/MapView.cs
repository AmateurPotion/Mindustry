// Decompiled with JetBrains decompiler
// Type: mindustry.editor.MapView
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.@event;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.graphics;
using mindustry.input;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  [Implements(new string[] {"arc.input.GestureDetector$GestureListener"})]
  public class MapView : Element, GestureDetector.GestureListener
  {
    private MapEditor editor;
    internal EditorTool tool;
    private float offsetx;
    private float offsety;
    private float zoom;
    private bool grid;
    private GridImage image;
    private Vec2 vec;
    private Rect rect;
    private Vec2[][] brushPolygons;
    internal bool drawing;
    internal int lastx;
    internal int lasty;
    internal int startx;
    internal int starty;
    internal float mousex;
    internal float mousey;
    internal EditorTool lastTool;

    [LineNumberTable(new byte[] {159, 180, 232, 49, 139, 107, 103, 109, 107, 107, 255, 15, 73, 135, 107, 106, 25, 230, 69, 127, 11, 139, 135, 240, 160, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapView(MapEditor editor)
    {
      MapView mapView = this;
      this.tool = EditorTool.__\u003C\u003Epencil;
      this.zoom = 1f;
      this.grid = false;
      this.image = new GridImage(0, 0);
      this.vec = new Vec2();
      this.rect = new Rect();
      int length = MapEditor.__\u003C\u003EbrushSizes.Length;
      int[] numArray = new int[2];
      int num1 = 0;
      numArray[1] = num1;
      int num2 = length;
      numArray[0] = num2;
      // ISSUE: type reference
      this.brushPolygons = (Vec2[][]) ByteCodeHelper.multianewarray(__typeref (Vec2[][]), numArray);
      this.editor = editor;
      for (int index = 0; index < MapEditor.__\u003C\u003EbrushSizes.Length; ++index)
      {
        float brushSiz = (float) MapEditor.__\u003C\u003EbrushSizes[index];
        this.brushPolygons[index] = Geometry.pixelCircle(brushSiz, (Geometry.SolidChecker) new MapView.__\u003C\u003EAnon0());
      }
      Core.input.getInputProcessors().insert(0, (object) new GestureDetector(20f, 0.5f, 2f, 0.15f, (GestureDetector.GestureListener) this));
      this.touchable = Touchable.__\u003C\u003Eenabled;
      Point2 point2 = new Point2();
      this.addListener((EventListener) new MapView.\u0031(this, editor, point2));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual EditorTool getTool() => this.tool;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTool(EditorTool tool) => this.tool = tool;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isGrid() => this.grid;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setGrid(bool grid) => this.grid = grid;

    [LineNumberTable(new byte[] {125, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void center()
    {
      MapView mapView = this;
      float num1 = 0.0f;
      double num2 = (double) num1;
      this.offsety = num1;
      this.offsetx = (float) num2;
    }

    [LineNumberTable(new byte[] {160, 96, 127, 3, 115, 106, 109, 127, 32, 159, 32, 127, 16, 159, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Point2 project([In] float obj0, [In] float obj1)
    {
      float num1 = 1f / ((float) this.editor.width() / (float) this.editor.height());
      float num2 = Math.min(this.width, this.height);
      float num3 = num2 * this.zoom;
      float num4 = num2 * this.zoom * num1;
      obj0 = (obj0 - this.getWidth() / 2f + num3 / 2f - this.offsetx * this.zoom) / num3 * (float) this.editor.width();
      obj1 = (obj1 - this.getHeight() / 2f + num4 / 2f - this.offsety * this.zoom) / num4 * (float) this.editor.height();
      int size = this.editor.drawBlock.size;
      int num5 = 2;
      return (num5 != -1 ? size % num5 : 0) == 0 && !object.ReferenceEquals((object) this.tool, (object) EditorTool.__\u003C\u003Eeraser) ? Tmp.__\u003C\u003Ep1.set(ByteCodeHelper.f2i(obj0 - 0.5f), ByteCodeHelper.f2i(obj1 - 0.5f)) : Tmp.__\u003C\u003Ep1.set(ByteCodeHelper.f2i(obj0), ByteCodeHelper.f2i(obj1));
    }

    [LineNumberTable(new byte[] {160, 92, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void clampZoom() => this.zoom = Mathf.clamp(this.zoom, 0.2f, 20f);

    [LineNumberTable(new byte[] {160, 111, 127, 3, 115, 106, 109, 127, 32, 127, 15, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Vec2 unproject([In] int obj0, [In] int obj1)
    {
      float num1 = 1f / ((float) this.editor.width() / (float) this.editor.height());
      float num2 = Math.min(this.width, this.height);
      float num3 = num2 * this.zoom;
      float num4 = num2 * this.zoom * num1;
      return this.vec.set((float) obj0 / (float) this.editor.width() * num3 + this.offsetx * this.zoom - num3 / 2f + this.getWidth() / 2f, (float) obj1 / (float) this.editor.height() * num4 + this.offsety * this.zoom - num4 / 2f + this.getHeight() / 2f);
    }

    [LineNumberTable(new byte[] {160, 210, 126, 127, 1, 127, 4, 255, 12, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool active() => Core.scene != null && Core.scene.getKeyboardFocus() != null && (Core.scene.getKeyboardFocus().isDescendantOf((Element) Vars.ui.editor) && Vars.ui.editor.isShown()) && (object.ReferenceEquals((object) this.tool, (object) EditorTool.__\u003C\u003Ezoom) && object.ReferenceEquals((object) Core.scene.hit(Core.input.mouse().x, Core.input.mouse().y, true), (object) this));

    [Modifiers]
    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00240([In] float obj0, [In] int obj1, [In] int obj2) => (double) Mathf.dst((float) obj1, (float) obj2, obj0, obj0) <= (double) (obj0 - 0.5f);

    [LineNumberTable(new byte[] {160, 66, 136, 127, 18, 113, 113, 126, 190, 113, 108, 171, 121, 108, 167, 147, 127, 14, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      if (Core.scene.getKeyboardFocus() == null || !(Core.scene.getKeyboardFocus() is TextField) && !Core.input.keyDown(KeyCode.__\u003C\u003EcontrolLeft))
      {
        float num1 = Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_x);
        float num2 = Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_y);
        this.offsetx -= num1 * 15f / this.zoom;
        this.offsety -= num2 * 15f / this.zoom;
      }
      if (Core.input.keyTap(KeyCode.__\u003C\u003EshiftLeft))
      {
        this.lastTool = this.tool;
        this.tool = EditorTool.__\u003C\u003Epick;
      }
      if (Core.input.keyRelease(KeyCode.__\u003C\u003EshiftLeft) && this.lastTool != null)
      {
        this.tool = this.lastTool;
        this.lastTool = (EditorTool) null;
      }
      if (!object.ReferenceEquals((object) Core.scene.getScrollFocus(), (object) this))
        return;
      this.zoom += Core.input.axis(KeyCode.__\u003C\u003Escroll) / 10f * this.zoom;
      this.clampZoom();
    }

    [LineNumberTable(new byte[] {160, 123, 127, 3, 115, 106, 109, 127, 8, 159, 8, 159, 2, 127, 23, 161, 106, 106, 127, 28, 127, 23, 133, 107, 106, 127, 6, 139, 106, 106, 127, 2, 159, 2, 165, 99, 109, 117, 100, 226, 61, 232, 71, 159, 11, 106, 144, 127, 29, 127, 1, 127, 6, 114, 159, 6, 116, 190, 127, 32, 116, 191, 8, 127, 1, 159, 35, 158, 133, 127, 21, 116, 127, 8, 127, 16, 255, 46, 71, 106, 112, 125, 133, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      float num1 = 1f / ((float) this.editor.width() / (float) this.editor.height());
      float num2 = Math.min(this.width, this.height);
      float num3 = num2 * this.zoom;
      float num4 = num2 * this.zoom * num1;
      float num5 = this.x + this.width / 2f + this.offsetx * this.zoom;
      float num6 = this.y + this.height / 2f + this.offsety * this.zoom;
      this.image.setImageSize(this.editor.width(), this.editor.height());
      if (!ScissorStack.push(this.rect.set(this.x, this.y + Core.scene.marginBottom, this.width, this.height)))
        return;
      Draw.color(Pal.remove);
      Lines.stroke(2f);
      Lines.rect(num5 - num3 / 2f - 1f, num6 - num4 / 2f - 1f, num3 + 2f, num4 + 2f);
      this.editor.renderer.draw(num5 - num3 / 2f, num6 - num4 / 2f + Core.scene.marginBottom, num3, num4);
      Draw.reset();
      if (this.grid)
      {
        Draw.color(Color.__\u003C\u003Egray);
        this.image.setBounds(num5 - num3 / 2f, num6 - num4 / 2f, num3, num4);
        this.image.draw();
        Lines.stroke(3f);
        Draw.color(Pal.accent);
        Lines.line(num5 - num3 / 2f, num6, num5 + num3 / 2f, num6);
        Lines.line(num5, num6 - num4 / 2f, num5, num6 + num4 / 2f);
        Draw.reset();
      }
      int index1 = 0;
      for (int index2 = 0; index2 < MapEditor.__\u003C\u003EbrushSizes.Length; ++index2)
      {
        if (this.editor.brushSize == MapEditor.__\u003C\u003EbrushSizes[index2])
        {
          index1 = index2;
          break;
        }
      }
      float scl = this.zoom * Math.min(this.width, this.height) / (float) this.editor.width();
      Draw.color(Pal.accent);
      Lines.stroke(Scl.scl(2f));
      if ((!this.editor.drawBlock.isMultiblock() || object.ReferenceEquals((object) this.tool, (object) EditorTool.__\u003C\u003Eeraser)) && !object.ReferenceEquals((object) this.tool, (object) EditorTool.__\u003C\u003Efill))
      {
        if (object.ReferenceEquals((object) this.tool, (object) EditorTool.__\u003C\u003Eline) && this.drawing)
        {
          Vec2 vec2_1 = this.unproject(this.startx, this.starty).add(this.x, this.y);
          float x = vec2_1.x;
          float y = vec2_1.y;
          Vec2 vec2_2 = this.unproject(this.lastx, this.lasty).add(this.x, this.y);
          Lines.poly(this.brushPolygons[index1], x, y, scl);
          Lines.poly(this.brushPolygons[index1], vec2_2.x, vec2_2.y, scl);
        }
        if ((this.tool.edit || object.ReferenceEquals((object) this.tool, (object) EditorTool.__\u003C\u003Eline) && !this.drawing) && (!Vars.mobile || this.drawing))
        {
          Point2 point2 = this.project(this.mousex, this.mousey);
          Vec2 vec2 = this.unproject(point2.x, point2.y).add(this.x, this.y);
          if (object.ReferenceEquals((object) this.tool, (object) EditorTool.__\u003C\u003Epencil) && this.tool.mode == 1)
            Lines.square(vec2.x + scl / 2f, vec2.y + scl / 2f, scl * ((float) this.editor.brushSize + 0.5f));
          else
            Lines.poly(this.brushPolygons[index1], vec2.x, vec2.y, scl);
        }
      }
      else if ((this.tool.edit || object.ReferenceEquals((object) this.tool, (object) EditorTool.__\u003C\u003Eline)) && (!Vars.mobile || this.drawing))
      {
        Point2 point2 = this.project(this.mousex, this.mousey);
        Vec2 vec2 = this.unproject(point2.x, point2.y).add(this.x, this.y);
        int size = this.editor.drawBlock.size;
        int num7 = 2;
        float num8 = (num7 != -1 ? size % num7 : 0) != 0 ? 0.0f : scl / 2f;
        Lines.square(vec2.x + scl / 2f + num8, vec2.y + scl / 2f + num8, scl * (float) this.editor.drawBlock.size / 2f);
      }
      Draw.color(Pal.accent);
      Lines.stroke(Scl.scl(3f));
      Lines.rect(this.x, this.y, this.width, this.height);
      Draw.reset();
      ScissorStack.pop();
    }

    [LineNumberTable(new byte[] {160, 218, 106, 120, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool pan(float x, float y, float deltaX, float deltaY)
    {
      if (!this.active())
        return false;
      this.offsetx += deltaX / this.zoom;
      this.offsety += deltaY / this.zoom;
      return false;
    }

    [LineNumberTable(new byte[] {160, 226, 106, 103, 127, 12, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool zoom(float initialDistance, float distance)
    {
      if (!this.active())
        return false;
      this.zoom += (distance - initialDistance) / 10000f / Scl.scl(1f) * this.zoom;
      this.clampZoom();
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool pinch(
      Vec2 initialPointer1,
      Vec2 initialPointer2,
      Vec2 pointer1,
      Vec2 pointer2)
    {
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pinchStop()
    {
    }

    [HideFromJava]
    public virtual bool touchDown([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3) => GestureDetector.GestureListener.\u003Cdefault\u003EtouchDown((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual bool tap([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3) => GestureDetector.GestureListener.\u003Cdefault\u003Etap((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [HideFromJava]
    public virtual bool longPress([In] float obj0, [In] float obj1) => GestureDetector.GestureListener.\u003Cdefault\u003ElongPress((GestureDetector.GestureListener) this, obj0, obj1);

    [HideFromJava]
    public virtual bool fling([In] float obj0, [In] float obj1, [In] KeyCode obj2) => GestureDetector.GestureListener.\u003Cdefault\u003Efling((GestureDetector.GestureListener) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual bool panStop([In] float obj0, [In] float obj1, [In] int obj2, [In] KeyCode obj3) => GestureDetector.GestureListener.\u003Cdefault\u003EpanStop((GestureDetector.GestureListener) this, obj0, obj1, obj2, obj3);

    [EnclosingMethod(null, "<init>", "(Lmindustry.editor.MapEditor;)V")]
    [SpecialName]
    internal new class \u0031 : InputListener
    {
      [Modifiers]
      internal MapEditor val\u0024editor;
      [Modifiers]
      internal Point2 val\u0024firstTouch;
      [Modifiers]
      internal MapView this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(139)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024touchDragged\u00240([In] MapEditor obj0, [In] int obj1, [In] int obj2) => this.this\u00240.tool.touched(obj0, obj1, obj2);

      [LineNumberTable(51)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] MapView obj0, [In] MapEditor obj1, [In] Point2 obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024editor = obj1;
        this.val\u0024firstTouch = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {5, 109, 109, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool mouseMoved([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240.mousex = obj1;
        this.this\u00240.mousey = obj2;
        this.this\u00240.requestScroll();
        return false;
      }

      [LineNumberTable(new byte[] {14, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void enter([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] Element obj4) => this.this\u00240.requestScroll();

      [LineNumberTable(new byte[] {19, 100, 162, 127, 18, 162, 110, 118, 176, 110, 118, 176, 109, 141, 112, 113, 113, 113, 113, 127, 3, 141, 114, 175, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (obj3 != 0)
          return false;
        if (!Vars.mobile && !object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseLeft) && (!object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseMiddle) && !object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseRight)))
          return true;
        if (object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseRight))
        {
          this.this\u00240.lastTool = this.this\u00240.tool;
          this.this\u00240.tool = EditorTool.__\u003C\u003Eeraser;
        }
        if (object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseMiddle))
        {
          this.this\u00240.lastTool = this.this\u00240.tool;
          this.this\u00240.tool = EditorTool.__\u003C\u003Ezoom;
        }
        this.this\u00240.mousex = obj1;
        this.this\u00240.mousey = obj2;
        Point2 point = this.this\u00240.project(obj1, obj2);
        this.this\u00240.lastx = point.x;
        this.this\u00240.lasty = point.y;
        this.this\u00240.startx = point.x;
        this.this\u00240.starty = point.y;
        this.this\u00240.tool.touched(this.val\u0024editor, point.x, point.y);
        this.val\u0024firstTouch.set(point);
        if (this.this\u00240.tool.edit)
          Vars.ui.editor.resetSaved();
        this.this\u00240.drawing = true;
        return true;
      }

      [LineNumberTable(new byte[] {58, 127, 18, 161, 140, 144, 119, 111, 191, 25, 139, 127, 10, 118, 172})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (!Vars.mobile && !object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseLeft) && (!object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseMiddle) && !object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseRight)))
          return;
        this.this\u00240.drawing = false;
        Point2 point2 = this.this\u00240.project(obj1, obj2);
        if (object.ReferenceEquals((object) this.this\u00240.tool, (object) EditorTool.__\u003C\u003Eline))
        {
          Vars.ui.editor.resetSaved();
          this.this\u00240.tool.touchedLine(this.val\u0024editor, this.this\u00240.startx, this.this\u00240.starty, point2.x, point2.y);
        }
        this.val\u0024editor.flushOp();
        if (!object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseMiddle) && !object.ReferenceEquals((object) obj4, (object) KeyCode.__\u003C\u003EmouseRight) || this.this\u00240.lastTool == null)
          return;
        this.this\u00240.tool = this.this\u00240.lastTool;
        this.this\u00240.lastTool = (EditorTool) null;
      }

      [LineNumberTable(new byte[] {82, 109, 141, 144, 127, 44, 111, 191, 25, 127, 17, 127, 17, 113, 152, 118, 179, 113, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchDragged([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3)
      {
        this.this\u00240.mousex = obj1;
        this.this\u00240.mousey = obj2;
        Point2 point2 = this.this\u00240.project(obj1, obj2);
        if (this.this\u00240.drawing && this.this\u00240.tool.draggable && (point2.x != this.this\u00240.lastx || point2.y != this.this\u00240.lasty))
        {
          Vars.ui.editor.resetSaved();
          Bresenham2.line(this.this\u00240.lastx, this.this\u00240.lasty, point2.x, point2.y, (Intc2) new MapView.\u0031.__\u003C\u003EAnon0(this, this.val\u0024editor));
        }
        if (object.ReferenceEquals((object) this.this\u00240.tool, (object) EditorTool.__\u003C\u003Eline) && this.this\u00240.tool.mode == 1)
        {
          if (Math.abs(point2.x - this.val\u0024firstTouch.x) > Math.abs(point2.y - this.val\u0024firstTouch.y))
          {
            this.this\u00240.lastx = point2.x;
            this.this\u00240.lasty = this.val\u0024firstTouch.y;
          }
          else
          {
            this.this\u00240.lastx = this.val\u0024firstTouch.x;
            this.this\u00240.lasty = point2.y;
          }
        }
        else
        {
          this.this\u00240.lastx = point2.x;
          this.this\u00240.lasty = point2.y;
        }
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Intc2
      {
        private readonly MapView.\u0031 arg\u00241;
        private readonly MapEditor arg\u00242;

        internal __\u003C\u003EAnon0([In] MapView.\u0031 obj0, [In] MapEditor obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024touchDragged\u00240(this.arg\u00242, obj0, obj1);
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Geometry.SolidChecker
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool solid([In] float obj0, [In] int obj1, [In] int obj2) => (MapView.lambda\u0024new\u00240(obj0, obj1, obj2) ? 1 : 0) != 0;
    }
  }
}
