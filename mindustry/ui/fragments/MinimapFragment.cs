// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.MinimapFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.input;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class MinimapFragment : Fragment
  {
    private bool shown;
    internal float panx;
    internal float pany;
    internal float zoom;
    internal float lastZoom;
    private float baseSize;
    public Element elem;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shown() => this.shown;

    [LineNumberTable(new byte[] {159, 159, 136, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MinimapFragment()
    {
      MinimapFragment minimapFragment = this;
      this.zoom = 1f;
      this.lastZoom = -1f;
      this.baseSize = Scl.scl(5f);
    }

    [LineNumberTable(new byte[] {159, 167, 247, 83, 119, 247, 76, 144, 242, 92, 242, 73, 241, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent)
    {
      this.elem = parent.fill((Table.DrawRect) new MinimapFragment.__\u003C\u003EAnon0(this));
      this.elem.visible((Boolp) new MinimapFragment.__\u003C\u003EAnon1(this));
      this.elem.update((Runnable) new MinimapFragment.__\u003C\u003EAnon2(this));
      this.elem.touchable = Touchable.__\u003C\u003Eenabled;
      this.elem.addListener((EventListener) new MinimapFragment.\u0031(this));
      this.elem.addListener((EventListener) new MinimapFragment.\u0032(this));
      parent.fill((Cons) new MinimapFragment.__\u003C\u003EAnon3(this));
    }

    [LineNumberTable(new byte[] {68, 124, 127, 14, 127, 49, 127, 12, 127, 18, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggle()
    {
      float num1 = this.baseSize * this.zoom * (float) Vars.world.width();
      float num2 = (float) Vars.renderer.__\u003C\u003Eminimap.getTexture().height / (float) Vars.renderer.__\u003C\u003Eminimap.getTexture().width;
      float num3 = !Vars.player.dead() ? Vars.player.x : Core.camera.__\u003C\u003Eposition.x;
      float num4 = !Vars.player.dead() ? Vars.player.y : Core.camera.__\u003C\u003Eposition.y;
      this.panx = (num1 / 2f - num3 / (float) (Vars.world.width() * 8) * num1) / this.zoom;
      this.pany = (num1 * num2 / 2f - num4 / (float) (Vars.world.height() * 8) * num1 * num2) / this.zoom;
      this.shown = !this.shown;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hide() => this.shown = false;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 168, 108, 108, 156, 106, 145, 116, 101, 127, 14, 118, 127, 29, 191, 67, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00240([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      float width = (float) Core.graphics.getWidth();
      float height = (float) Core.graphics.getHeight();
      float w = this.baseSize * this.zoom * (float) Vars.world.width();
      Draw.color(Color.__\u003C\u003Eblack);
      Fill.crect(0.0f, 0.0f, width, height);
      if (Vars.renderer.__\u003C\u003Eminimap.getTexture() != null)
      {
        Draw.color();
        float num = (float) Vars.renderer.__\u003C\u003Eminimap.getTexture().height / (float) Vars.renderer.__\u003C\u003Eminimap.getTexture().width;
        Draw.rect(Draw.wrap(Vars.renderer.__\u003C\u003Eminimap.getTexture()), width / 2f + this.panx * this.zoom, height / 2f + this.pany * this.zoom, w, w * num);
        Vars.renderer.__\u003C\u003Eminimap.drawEntities(width / 2f + this.panx * this.zoom - w / 2f, height / 2f + this.pany * this.zoom - w / 2f * num, w, w * num, this.zoom, true);
      }
      Draw.reset();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u00241() => this.shown;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 188, 113, 107, 139, 108, 159, 12, 113, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00242()
    {
      if (!Vars.ui.chatfrag.shown())
      {
        this.elem.requestKeyboard();
        this.elem.requestScroll();
      }
      this.elem.setFillParent(true);
      this.elem.setBounds(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      if (!Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Emenu))
        return;
      this.shown = false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {47, 103, 114, 146, 127, 17, 103, 108, 103, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00246([In] Table obj0)
    {
      obj0.setFillParent(true);
      obj0.visible((Boolp) new MinimapFragment.__\u003C\u003EAnon4(this));
      obj0.update((Runnable) new MinimapFragment.__\u003C\u003EAnon5(obj0));
      Table table = obj0;
      object obj = (object) "@minimap";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).style((Style) Styles.outlineLabel).pad(10f);
      obj0.row();
      obj0.add().growY();
      obj0.row();
      obj0.button("@back", (Drawable) Icon.leftOpen, (Runnable) new MinimapFragment.__\u003C\u003EAnon6(this)).size(220f, 60f).pad(10f);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u00243() => this.shown;

    [Modifiers]
    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00244([In] Table obj0) => obj0.setBounds(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00245() => this.shown = false;

    [EnclosingMethod(null, "build", "(Larc.scene.Group;)V")]
    [SpecialName]
    internal class \u0031 : ElementGestureListener
    {
      [Modifiers]
      internal MinimapFragment this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(59)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] MinimapFragment obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {13, 114, 182, 127, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void zoom([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        if ((double) this.this\u00240.lastZoom < 0.0)
          this.this\u00240.lastZoom = this.this\u00240.zoom;
        this.this\u00240.zoom = Mathf.clamp(obj2 / obj1 * this.this\u00240.lastZoom, 0.25f, 10f);
      }

      [LineNumberTable(new byte[] {22, 127, 4, 127, 4})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void pan([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
      {
        this.this\u00240.panx += obj3 / this.this\u00240.zoom;
        this.this\u00240.pany += obj4 / this.this\u00240.zoom;
      }

      [LineNumberTable(new byte[] {28, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        base.touchDown(obj0, obj1, obj2, obj3, obj4);
      }

      [LineNumberTable(new byte[] {33, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.this\u00240.lastZoom = this.this\u00240.zoom;
      }

      [HideFromJava]
      static \u0031() => ElementGestureListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "build", "(Larc.scene.Group;)V")]
    [SpecialName]
    internal class \u0032 : InputListener
    {
      [Modifiers]
      internal MinimapFragment this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(87)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] MinimapFragment obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {41, 127, 32})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool scrolled(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4)
      {
        this.this\u00240.zoom = Mathf.clamp(this.this\u00240.zoom - obj4 / 10f * this.this\u00240.zoom, 0.25f, 10f);
        return true;
      }

      [HideFromJava]
      static \u0032() => InputListener.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Table.DrawRect
    {
      private readonly MinimapFragment arg\u00241;

      internal __\u003C\u003EAnon0([In] MinimapFragment obj0) => this.arg\u00241 = obj0;

      public void draw([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => this.arg\u00241.lambda\u0024build\u00240(obj0, obj1, obj2, obj3);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolp
    {
      private readonly MinimapFragment arg\u00241;

      internal __\u003C\u003EAnon1([In] MinimapFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u00241() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly MinimapFragment arg\u00241;

      internal __\u003C\u003EAnon2([In] MinimapFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024build\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly MinimapFragment arg\u00241;

      internal __\u003C\u003EAnon3([In] MinimapFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00246((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolp
    {
      private readonly MinimapFragment arg\u00241;

      internal __\u003C\u003EAnon4([In] MinimapFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u00243() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly Table arg\u00241;

      internal __\u003C\u003EAnon5([In] Table obj0) => this.arg\u00241 = obj0;

      public void run() => MinimapFragment.lambda\u0024build\u00244(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly MinimapFragment arg\u00241;

      internal __\u003C\u003EAnon6([In] MinimapFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024build\u00245();
    }
  }
}
