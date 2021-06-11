// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.BaseDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.scene.style;
using arc.scene.ui;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.core;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class BaseDialog : Dialog
  {
    private bool wasPaused;
    protected internal bool shouldPause;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 106, 103, 108, 108, 117, 154, 241, 73, 241, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseDialog(string title, Dialog.DialogStyle style)
      : base(title, style)
    {
      BaseDialog baseDialog = this;
      this.setFillParent(true);
      this.__\u003C\u003Etitle.setAlignment(1);
      this.__\u003C\u003EtitleTable.row();
      this.__\u003C\u003EtitleTable.image((Drawable) Tex.whiteui, Pal.accent).growX().height(3f).pad(4f);
      this.hidden((Runnable) new BaseDialog.__\u003C\u003EAnon0(this));
      this.shown((Runnable) new BaseDialog.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {6, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addCloseListener() => this.closeOnBack();

    [Modifiers]
    [LineNumberTable(new byte[] {159, 168, 116, 116, 175, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      if (this.shouldPause && Vars.state.isGame() && (!this.wasPaused || Vars.net.active()))
        Vars.state.set(GameState.State.__\u003C\u003Eplaying);
      Sounds.back.play();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 177, 116, 117, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241()
    {
      if (!this.shouldPause || !Vars.state.isGame())
        return;
      this.wasPaused = Vars.state.@is(GameState.State.__\u003C\u003Epaused);
      Vars.state.set(GameState.State.__\u003C\u003Epaused);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 190, 122, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024onResize\u00242([In] Runnable obj0, [In] EventType.ResizeEvent obj1)
    {
      if (!this.isShown() || !object.ReferenceEquals((object) Core.scene.getDialog(), (object) this))
        return;
      obj0.run();
      this.updateScrollFocus();
    }

    [LineNumberTable(new byte[] {159, 185, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseDialog(string title)
      : this(title, (Dialog.DialogStyle) Core.scene.getStyle((Class) ClassLiteral<Dialog.DialogStyle>.Value))
    {
    }

    [LineNumberTable(new byte[] {159, 189, 246, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void onResize(Runnable run) => Events.on((Class) ClassLiteral<EventType.ResizeEvent>.Value, (Cons) new BaseDialog.__\u003C\u003EAnon2(this, run));

    [LineNumberTable(new byte[] {11, 123, 159, 17, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void addCloseButton()
    {
      this.__\u003C\u003Ebuttons.defaults().size(210f, 64f);
      this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new BaseDialog.__\u003C\u003EAnon3(this)).size(210f, 64f);
      this.addCloseListener();
    }

    [HideFromJava]
    static BaseDialog() => Dialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly BaseDialog arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon2([In] BaseDialog obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024onResize\u00242(this.arg\u00242, (EventType.ResizeEvent) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }
  }
}
