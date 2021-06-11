// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.ControlsDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.input;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class ControlsDialog : KeybindDialog
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 153, 104, 103, 108, 108, 127, 30})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ControlsDialog()
    {
      ControlsDialog controlsDialog = this;
      this.setFillParent(true);
      this.__\u003C\u003Etitle.setAlignment(1);
      this.__\u003C\u003EtitleTable.row();
      this.__\u003C\u003EtitleTable.add((Element) new Image()).growX().height(3f).pad(4f).get().setColor(Pal.accent);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 165, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addCloseButton\u00240([In] KeyCode obj0)
    {
      if (!object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eescape) && !object.ReferenceEquals((object) obj0, (object) KeyCode.__\u003C\u003Eback))
        return;
      this.hide();
    }

    [LineNumberTable(new byte[] {159, 162, 159, 17, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void addCloseButton()
    {
      this.__\u003C\u003Ebuttons.button("@back", (Drawable) Icon.left, (Runnable) new ControlsDialog.__\u003C\u003EAnon0(this)).size(210f, 64f);
      this.keyDown((Cons) new ControlsDialog.__\u003C\u003EAnon1(this));
    }

    [HideFromJava]
    static ControlsDialog() => KeybindDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly ControlsDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] ControlsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly ControlsDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] ControlsDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024addCloseButton\u00240((KeyCode) obj0);
    }
  }
}
