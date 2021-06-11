// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.LoadingFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.scene;
using arc.scene.@event;
using arc.scene.actions;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class LoadingFragment : Fragment
  {
    private Table table;
    private TextButton button;
    private mindustry.ui.Bar bar;
    private Label nameLabel;

    [LineNumberTable(new byte[] {20, 112, 108, 107, 112, 103, 108, 117, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(string text)
    {
      this.nameLabel.setColor(Color.__\u003C\u003Ewhite);
      this.bar.visible = false;
      this.table.clearActions();
      this.table.touchable = Touchable.__\u003C\u003Eenabled;
      this.text(text);
      this.table.visible = true;
      this.table.__\u003C\u003Ecolor.a = 1f;
      this.table.toFront();
    }

    [LineNumberTable(new byte[] {16, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show() => this.show("@loading");

    [LineNumberTable(new byte[] {159, 191, 112, 108, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProgress(Floatp progress)
    {
      this.bar.reset(0.0f);
      this.bar.visible = true;
      this.bar.set((Prov) new LoadingFragment.__\u003C\u003EAnon1(progress), progress, Pal.accent);
    }

    [LineNumberTable(new byte[] {31, 107, 107, 112, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hide()
    {
      this.table.clearActions();
      this.table.toFront();
      this.table.touchable = Touchable.__\u003C\u003Edisabled;
      this.table.actions((Action) Actions.fadeOut(0.5f), (Action) Actions.visible(false));
    }

    [LineNumberTable(new byte[] {11, 103, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setText(string text)
    {
      this.text(text);
      this.nameLabel.setColor(Pal.accent);
    }

    [LineNumberTable(new byte[] {5, 108, 127, 4, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setButton(Runnable listener)
    {
      this.button.visible = true;
      this.button.getListeners().remove(this.button.getListeners().size - 1);
      this.button.clicked(listener);
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LoadingFragment()
    {
    }

    [LineNumberTable(new byte[] {159, 165, 241, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent) => parent.fill((Cons) new LoadingFragment.__\u003C\u003EAnon0(this));

    [LineNumberTable(new byte[] {38, 156, 204, 118, 127, 8, 112, 225, 61, 233, 70, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void text([In] string obj0)
    {
      Label nameLabel = this.nameLabel;
      object obj1 = (object) obj0;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence newText = charSequence;
      nameLabel.setText(newText);
      StringBuilder text = this.nameLabel.getText();
      int num1 = 0;
      while (true)
      {
        int num2 = num1;
        object obj2 = (object) text;
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        int num3 = ((CharSequence) ref charSequence).length();
        if (num2 < num3)
        {
          Font.FontData data = Fonts.tech.getData();
          StringBuilder stringBuilder = text;
          int num4 = num1;
          object obj3 = (object) stringBuilder;
          charSequence.__\u003Cref\u003E = (__Null) obj3;
          int num5 = (int) ((CharSequence) ref charSequence).charAt(num4);
          if (data.getGlyph((char) num5) != null)
            ++num1;
          else
            break;
        }
        else
          goto label_5;
      }
      this.nameLabel.setStyle(Styles.defaultLabel);
      return;
label_5:
      this.nameLabel.setStyle(Styles.techLabel);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 167, 210, 103, 107, 117, 123, 103, 127, 32, 103, 123, 135, 139, 127, 27, 103, 127, 37, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00242([In] Table obj0)
    {
      obj0.rect((Table.DrawRect) new LoadingFragment.__\u003C\u003EAnon2(obj0));
      obj0.visible = false;
      obj0.touchable = Touchable.__\u003C\u003Eenabled;
      obj0.add().height(133f).row();
      obj0.add((Element) new WarningBar()).growX().height(24f);
      obj0.row();
      Table table = obj0;
      object obj = (object) "@loading";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      this.nameLabel = (Label) table.add(text).pad(10f).style((Style) Styles.techLabel).get();
      obj0.row();
      obj0.add((Element) new WarningBar()).growX().height(24f);
      obj0.row();
      this.text("@loading");
      this.bar = (mindustry.ui.Bar) obj0.add((Element) new mindustry.ui.Bar()).pad(3f).size(500f, 40f).visible(false).get();
      obj0.row();
      this.button = (TextButton) obj0.button("@cancel", (Runnable) new LoadingFragment.__\u003C\u003EAnon3()).pad(20f).size(250f, 70f).visible(false).get();
      this.table = obj0;
    }

    [Modifiers]
    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024setProgress\u00243([In] Floatp obj0) => new StringBuilder().append(ByteCodeHelper.f2i(obj0.get() * 100f)).append("%").toString();

    [Modifiers]
    [LineNumberTable(new byte[] {159, 168, 112, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00240(
      [In] Table obj0,
      [In] float obj1,
      [In] float obj2,
      [In] float obj3,
      [In] float obj4)
    {
      Draw.alpha(obj0.__\u003C\u003Ecolor.a);
      Styles.black8.draw(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00241()
    {
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly LoadingFragment arg\u00241;

      internal __\u003C\u003EAnon0([In] LoadingFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00242((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      private readonly Floatp arg\u00241;

      internal __\u003C\u003EAnon1([In] Floatp obj0) => this.arg\u00241 = obj0;

      public object get() => (object) LoadingFragment.lambda\u0024setProgress\u00243(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Table.DrawRect
    {
      private readonly Table arg\u00241;

      internal __\u003C\u003EAnon2([In] Table obj0) => this.arg\u00241 = obj0;

      public void draw([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => LoadingFragment.lambda\u0024build\u00240(this.arg\u00241, obj0, obj1, obj2, obj3);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void run() => LoadingFragment.lambda\u0024build\u00241();
    }
  }
}
