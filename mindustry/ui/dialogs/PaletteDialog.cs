// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.PaletteDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class PaletteDialog : Dialog
  {
    [Signature("Larc/func/Cons<Larc/graphics/Color;>;")]
    private Cons cons;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 109, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PaletteDialog()
      : base("")
    {
      PaletteDialog paletteDialog = this;
      this.build();
    }

    [Signature("(Larc/func/Cons<Larc/graphics/Color;>;)V")]
    [LineNumberTable(new byte[] {159, 183, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Cons cons)
    {
      this.cons = cons;
      this.show();
    }

    [LineNumberTable(new byte[] {159, 162, 247, 81, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void build()
    {
      this.__\u003C\u003Econt.table((Cons) new PaletteDialog.__\u003C\u003EAnon0(this));
      this.closeOnBack();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 163, 110, 136, 191, 7, 112, 118, 140, 111, 231, 53, 233, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00241([In] Table obj0)
    {
      for (int index = 0; index < Vars.__\u003C\u003EplayerColors.Length; ++index)
      {
        Color playerColor = Vars.__\u003C\u003EplayerColors[index];
        ImageButton imageButton = (ImageButton) obj0.button((Drawable) Tex.whiteui, Styles.clearTogglei, 34f, (Runnable) new PaletteDialog.__\u003C\u003EAnon1(this, playerColor)).size(48f).get();
        imageButton.setChecked(Vars.player.color().equals((object) playerColor));
        imageButton.getStyle().imageUpColor = playerColor;
        int num1 = index;
        int num2 = 4;
        if ((num2 != -1 ? num1 % num2 : 0) == 3)
          obj0.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 167, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00240([In] Color obj0)
    {
      this.cons.get((object) obj0);
      this.hide();
    }

    [HideFromJava]
    static PaletteDialog() => Dialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly PaletteDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] PaletteDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly PaletteDialog arg\u00241;
      private readonly Color arg\u00242;

      internal __\u003C\u003EAnon1([In] PaletteDialog obj0, [In] Color obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u00240(this.arg\u00242);
    }
  }
}
