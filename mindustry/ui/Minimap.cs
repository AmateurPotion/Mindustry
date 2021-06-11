// Decompiled with JetBrains decompiler
// Type: mindustry.ui.Minimap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using arc.input;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class Minimap : Table
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {45, 127, 3, 108, 104, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      Element element = Core.scene.hit((float) Core.input.mouseX(), (float) Core.input.mouseY(), true);
      if (element != null && element.isDescendantOf((Element) this))
      {
        this.requestScroll();
      }
      else
      {
        if (!this.hasScroll())
          return;
        Core.scene.setScrollFocus((Element) null);
      }
    }

    [LineNumberTable(new byte[] {159, 157, 104, 108, 102, 139, 242, 89, 134, 136, 237, 72, 237, 100, 242, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Minimap()
    {
      Minimap minimap = this;
      this.background((Drawable) Tex.pane);
      float pad = 5f;
      this.touchable = Touchable.__\u003C\u003Eenabled;
      this.add((Element) new Minimap.\u0031(this, pad)).size(140f);
      this.margin(pad);
      this.addListener((EventListener) new Minimap.\u0032(this));
      this.addListener((EventListener) new Minimap.\u0033(this));
      this.update((Runnable) new Minimap.__\u003C\u003EAnon0(this));
    }

    [Modifiers]
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static float access\u0024000([In] Minimap obj0) => obj0.height;

    [HideFromJava]
    static Minimap() => Table.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal new class \u0031 : Element
    {
      [Modifiers]
      internal float val\u0024margin;
      [Modifiers]
      internal Minimap this\u00240;

      [LineNumberTable(new byte[] {159, 162, 151, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Minimap obj0, [In] float obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024margin = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Minimap.\u0031 obj = this;
        this.setSize(Scl.scl(140f));
      }

      [LineNumberTable(new byte[] {159, 169, 158, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void act([In] float obj0)
      {
        this.setPosition(Scl.scl(this.val\u0024margin), Scl.scl(this.val\u0024margin));
        base.act(obj0);
      }

      [LineNumberTable(new byte[] {159, 176, 114, 137, 159, 43, 113, 191, 14, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        if (Vars.renderer.__\u003C\u003Eminimap.getRegion() == null || !this.clipBegin())
          return;
        Draw.rect(Vars.renderer.__\u003C\u003Eminimap.getRegion(), this.x + this.width / 2f, this.y + this.height / 2f, this.width, this.height);
        if (Vars.renderer.__\u003C\u003Eminimap.getTexture() != null)
          Vars.renderer.__\u003C\u003Eminimap.drawEntities(this.x, this.y, this.width, this.height, 0.75f, false);
        this.clipEnd();
      }
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal new class \u0032 : InputListener
    {
      [Modifiers]
      internal Minimap this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(49)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Minimap obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {2, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool scrolled(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4)
      {
        Vars.renderer.__\u003C\u003Eminimap.zoomBy(obj4);
        return true;
      }

      [HideFromJava]
      static \u0032() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal new class \u0033 : ClickListener
    {
      [Modifiers]
      internal Minimap this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {7, 143, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Minimap obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Minimap.\u0033 obj = this;
        this.tapSquareSize = Scl.scl(11f);
      }

      [LineNumberTable(new byte[] {14, 104, 145, 103, 103, 103, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (this.inTapSquare())
        {
          base.touchUp(obj0, obj1, obj2, obj3, obj4);
        }
        else
        {
          this.pressed = false;
          this.pressedPointer = -1;
          this.pressedButton = (KeyCode) null;
          this.cancelled = false;
        }
      }

      [LineNumberTable(new byte[] {26, 108, 134, 141, 103, 127, 10, 159, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchDragged([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3)
      {
        if (!this.inTapSquare(obj1, obj2))
          this.invalidateTapSquare();
        base.touchDragged(obj0, obj1, obj2, obj3);
        if (!Vars.mobile)
          return;
        float num = (float) Math.min(Vars.world.width(), Vars.world.height()) / 16f / 2f;
        Vars.renderer.__\u003C\u003Eminimap.setZoom(1f + obj2 / Minimap.access\u0024000(this.this\u00240) * (num - 1f));
      }

      [LineNumberTable(new byte[] {39, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void clicked([In] InputEvent obj0, [In] float obj1, [In] float obj2) => Vars.ui.minimapfrag.toggle();

      [HideFromJava]
      static \u0033() => ClickListener.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Minimap arg\u00241;

      internal __\u003C\u003EAnon0([In] Minimap obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }
  }
}
