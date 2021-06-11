// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.MinimapDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
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

namespace mindustry.ui.dialogs
{
  public class MinimapDialog : BaseDialog
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 139, 255, 1, 75, 159, 35, 242, 72, 242, 81, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Econt.table((Drawable) Tex.pane, (Cons) new MinimapDialog.__\u003C\u003EAnon1(this)).size(Math.min((float) Core.graphics.getWidth() / 1.1f, (float) Core.graphics.getHeight() / 1.3f) / Scl.scl(1f)).padTop(-20f);
      this.__\u003C\u003Econt.addListener((EventListener) new MinimapDialog.\u0031(this));
      this.__\u003C\u003Econt.addListener((EventListener) new MinimapDialog.\u0032(this));
      Core.app.post((Runnable) new MinimapDialog.__\u003C\u003EAnon2(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 173, 241, 73, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00241([In] Table obj0) => obj0.rect((Table.DrawRect) new MinimapDialog.__\u003C\u003EAnon3(this)).grow();

    [Modifiers]
    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00242() => Core.scene.setScrollFocus((Element) this.__\u003C\u003Econt);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 114, 106, 107, 159, 21, 113, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00240([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      if (Vars.renderer.__\u003C\u003Eminimap.getRegion() == null)
        return;
      Draw.color(Color.__\u003C\u003Ewhite);
      Draw.alpha(this.parentAlpha);
      Draw.rect(Vars.renderer.__\u003C\u003Eminimap.getRegion(), obj0 + obj2 / 2f, obj1 + obj3 / 2f, obj2, obj3);
      if (Vars.renderer.__\u003C\u003Eminimap.getTexture() == null)
        return;
      Vars.renderer.__\u003C\u003Eminimap.drawEntities(obj0, obj1, obj2, obj3);
    }

    [LineNumberTable(new byte[] {159, 158, 109, 135, 145, 102, 103, 108, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MinimapDialog()
      : base("@minimap")
    {
      MinimapDialog minimapDialog = this;
      this.setFillParent(true);
      this.shown((Runnable) new MinimapDialog.__\u003C\u003EAnon0(this));
      this.addCloseButton();
      this.shouldPause = true;
      this.__\u003C\u003EtitleTable.remove();
      this.onResize((Runnable) new MinimapDialog.__\u003C\u003EAnon0(this));
    }

    [HideFromJava]
    static MinimapDialog() => BaseDialog.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "setup", "()V")]
    [SpecialName]
    internal new class \u0031 : InputListener
    {
      [Modifiers]
      internal MinimapDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(43)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] MinimapDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 188, 114})]
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
      static \u0031() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "setup", "()V")]
    [SpecialName]
    internal new class \u0032 : ElementGestureListener
    {
      internal float lzoom;
      [Modifiers]
      internal MinimapDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {1, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] MinimapDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        MinimapDialog.\u0032 obj = this;
        this.lzoom = -1f;
      }

      [LineNumberTable(new byte[] {6, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.lzoom = Vars.renderer.__\u003C\u003Eminimap.getZoom();
      }

      [LineNumberTable(new byte[] {11, 109, 150, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void zoom([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        if ((double) this.lzoom < 0.0)
          this.lzoom = Vars.renderer.__\u003C\u003Eminimap.getZoom();
        Vars.renderer.__\u003C\u003Eminimap.setZoom(obj1 / obj2 * this.lzoom);
      }

      [HideFromJava]
      static \u0032() => ElementGestureListener.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly MinimapDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] MinimapDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly MinimapDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] MinimapDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00241((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly MinimapDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] MinimapDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u00242();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Table.DrawRect
    {
      private readonly MinimapDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] MinimapDialog obj0) => this.arg\u00241 = obj0;

      public void draw([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => this.arg\u00241.lambda\u0024setup\u00240(obj0, obj1, obj2, obj3);
    }
  }
}
