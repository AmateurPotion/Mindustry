// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.ColorPicker
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class ColorPicker : BaseDialog
  {
    [Signature("Larc/func/Cons<Larc/graphics/Color;>;")]
    private Cons cons;
    internal Color current;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 237, 60, 112, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ColorPicker()
      : base("@pickcolor")
    {
      ColorPicker colorPicker = this;
      this.cons = (Cons) new ColorPicker.__\u003C\u003EAnon0();
      this.current = new Color();
    }

    [Signature("(Larc/graphics/Color;ZLarc/func/Cons<Larc/graphics/Color;>;)V")]
    [LineNumberTable(new byte[] {159, 137, 130, 109, 103, 135, 107, 248, 93, 107, 102, 223, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Color color, bool alpha, Cons consumer)
    {
      int num = alpha ? 1 : 0;
      this.current.set(color);
      this.cons = consumer;
      this.show();
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Econt.pane((Cons) new ColorPicker.__\u003C\u003EAnon1(this, num != 0));
      this.__\u003C\u003Ebuttons.clear();
      this.addCloseButton();
      this.__\u003C\u003Ebuttons.button("@ok", (Drawable) Icon.ok, (Runnable) new ColorPicker.__\u003C\u003EAnon2(this));
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] Color obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 135, 66, 247, 69, 144, 134, 135, 113, 127, 7, 127, 31, 103, 127, 7, 127, 31, 103, 127, 7, 127, 31, 103, 99, 124, 127, 31, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00242([In] bool obj0, [In] Table obj1)
    {
      int num = obj0 ? 1 : 0;
      obj1.table((Drawable) Tex.pane, (Cons) new ColorPicker.__\u003C\u003EAnon3(this)).colspan(2).padBottom(5f);
      float width = 150f;
      obj1.row();
      obj1.defaults().padBottom(4f);
      Table table1 = obj1;
      object obj2 = (object) "R";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text1 = charSequence;
      table1.add(text1).color(Pal.remove);
      Table table2 = obj1;
      double r = (double) this.current.r;
      Color current1 = this.current;
      Objects.requireNonNull((object) current1);
      Floatc listener1 = (Floatc) new ColorPicker.__\u003C\u003EAnon4(current1);
      table2.slider(0.0f, 1f, 0.01f, (float) r, listener1).width(width);
      obj1.row();
      Table table3 = obj1;
      object obj3 = (object) "G";
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text2 = charSequence;
      table3.add(text2).color(Color.__\u003C\u003Elime);
      Table table4 = obj1;
      double g = (double) this.current.g;
      Color current2 = this.current;
      Objects.requireNonNull((object) current2);
      Floatc listener2 = (Floatc) new ColorPicker.__\u003C\u003EAnon5(current2);
      table4.slider(0.0f, 1f, 0.01f, (float) g, listener2).width(width);
      obj1.row();
      Table table5 = obj1;
      object obj4 = (object) "B";
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence text3 = charSequence;
      table5.add(text3).color(Color.__\u003C\u003Eroyal);
      Table table6 = obj1;
      double b = (double) this.current.b;
      Color current3 = this.current;
      Objects.requireNonNull((object) current3);
      Floatc listener3 = (Floatc) new ColorPicker.__\u003C\u003EAnon6(current3);
      table6.slider(0.0f, 1f, 0.01f, (float) b, listener3).width(width);
      obj1.row();
      if (num == 0)
        return;
      Table table7 = obj1;
      object obj5 = (object) "A";
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      CharSequence text4 = charSequence;
      table7.add(text4);
      Table table8 = obj1;
      double a = (double) this.current.a;
      Color current4 = this.current;
      Objects.requireNonNull((object) current4);
      Floatc listener4 = (Floatc) new ColorPicker.__\u003C\u003EAnon7(current4);
      table8.slider(0.0f, 1f, 0.01f, (float) a, listener4).width(width);
      obj1.row();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {9, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00243()
    {
      this.cons.get((object) this.current);
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 171, 191, 8, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024show\u00241([In] Table obj0) => obj0.stack((Element) new Image((Drawable) Tex.alphaBg), (Element) new ColorPicker.\u0031(this)).size(200f);

    [Signature("(Larc/graphics/Color;Larc/func/Cons<Larc/graphics/Color;>;)V")]
    [LineNumberTable(new byte[] {159, 160, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Color color, Cons consumer) => this.show(color, true, consumer);

    [HideFromJava]
    static ColorPicker() => BaseDialog.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "show", "(Larc.graphics.Color;ZLarc.func.Cons;)V")]
    [SpecialName]
    internal new class \u0031 : Image
    {
      [Modifiers]
      internal ColorPicker this\u00240;

      [Modifiers]
      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240() => this.setColor(this.this\u00240.current);

      [LineNumberTable(new byte[] {159, 171, 111, 113, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ColorPicker obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ColorPicker.\u0031 obj = this;
        this.setColor(this.this\u00240.current);
        this.update((Runnable) new ColorPicker.\u0031.__\u003C\u003EAnon0(this));
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly ColorPicker.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] ColorPicker.\u0031 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00240();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => ColorPicker.lambda\u0024new\u00240((Color) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly ColorPicker arg\u00241;
      private readonly bool arg\u00242;

      internal __\u003C\u003EAnon1([In] ColorPicker obj0, [In] bool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024show\u00242(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly ColorPicker arg\u00241;

      internal __\u003C\u003EAnon2([In] ColorPicker obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024show\u00243();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly ColorPicker arg\u00241;

      internal __\u003C\u003EAnon3([In] ColorPicker obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024show\u00241((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Floatc
    {
      private readonly Color arg\u00241;

      internal __\u003C\u003EAnon4([In] Color obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.r(obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Floatc
    {
      private readonly Color arg\u00241;

      internal __\u003C\u003EAnon5([In] Color obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.g(obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Floatc
    {
      private readonly Color arg\u00241;

      internal __\u003C\u003EAnon6([In] Color obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.b(obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Floatc
    {
      private readonly Color arg\u00241;

      internal __\u003C\u003EAnon7([In] Color obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => this.arg\u00241.a(obj0);
    }
  }
}
