// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.CustomGameDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics.g2d;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.maps;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class CustomGameDialog : BaseDialog
  {
    private MapPlayDialog dialog;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 237, 61, 203, 102, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CustomGameDialog()
      : base("@customgame")
    {
      CustomGameDialog customGameDialog = this;
      this.dialog = new MapPlayDialog();
      this.addCloseButton();
      this.shown((Runnable) new CustomGameDialog.__\u003C\u003EAnon0(this));
      this.onResize((Runnable) new CustomGameDialog.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 169, 102, 118, 127, 5, 108, 139, 102, 108, 108, 103, 135, 127, 5, 134, 99, 127, 6, 159, 12, 111, 167, 125, 109, 136, 105, 136, 104, 243, 72, 102, 104, 127, 42, 104, 127, 12, 104, 144, 115, 109, 137, 149, 137, 102, 133, 113, 191, 9, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      this.clearChildren();
      this.add((Element) this.__\u003C\u003EtitleTable).growX().row();
      this.stack((Element) this.__\u003C\u003Econt, (Element) this.__\u003C\u003Ebuttons).grow();
      this.__\u003C\u003Ebuttons.bottom();
      this.__\u003C\u003Econt.clear();
      Table table1 = new Table();
      table1.marginRight(14f);
      table1.marginBottom(55f);
      ScrollPane scrollPane = new ScrollPane((Element) table1);
      scrollPane.setFadeScrollBars(false);
      int num1 = Math.max(ByteCodeHelper.f2i((float) Core.graphics.getWidth() / Scl.scl(210f)), 1);
      float size = 146f;
      int num2 = 0;
      table1.defaults().width(170f).fillY().top().pad(4f);
      Iterator iterator = Vars.maps.all().iterator();
      CharSequence charSequence;
      while (iterator.hasNext())
      {
        Map map = (Map) iterator.next();
        int num3 = num2;
        int num4 = num1;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
          table1.row();
        ImageButton.__\u003Cclinit\u003E();
        ImageButton imageButton1 = new ImageButton(new TextureRegion(map.safeTexture()), Styles.cleari);
        imageButton1.margin(5f);
        imageButton1.top();
        Image image = imageButton1.getImage();
        image.remove();
        imageButton1.row();
        imageButton1.table((Cons) new CustomGameDialog.__\u003C\u003EAnon1(map)).left();
        imageButton1.row();
        ImageButton imageButton2 = imageButton1;
        object obj = (object) map.name();
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        ((Label) imageButton2.add(text).pad(1f).growX().wrap().left().get()).setEllipsis(true);
        imageButton1.row();
        imageButton1.image((Drawable) Tex.whiteui, Pal.gray).growX().pad(3f).height(4f);
        imageButton1.row();
        imageButton1.add((Element) image).size(size);
        BorderImage borderImage = new BorderImage(map.safeTexture(), 3f);
        borderImage.setScaling(Scaling.__\u003C\u003Efit);
        imageButton1.replaceImage((Element) borderImage);
        imageButton1.clicked((Runnable) new CustomGameDialog.__\u003C\u003EAnon2(this, map));
        table1.add((Element) imageButton1);
        ++num2;
      }
      if (Vars.maps.all().size == 0)
      {
        Table table2 = table1;
        object obj = (object) "@maps.none";
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table2.add(text).pad(50f);
      }
      this.__\u003C\u003Econt.add((Element) scrollPane).uniformX();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {9, 103, 118, 127, 27, 124, 253, 61, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00240([In] Map obj0, [In] Table obj1)
    {
      obj1.left();
      Gamemode[] all = Gamemode.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        Gamemode gamemode = all[index];
        TextureRegionDrawable icon = Vars.ui.getIcon(new StringBuilder().append("mode").append(Strings.capitalize(gamemode.name())).append("Small").toString());
        if (gamemode.valid(obj0) && Core.atlas.isFound(icon.getRegion()))
          obj1.image((Drawable) icon).size(16f).pad(4f);
      }
    }

    [Modifiers]
    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00241([In] Map obj0) => this.dialog.show(obj0);

    [HideFromJava]
    static CustomGameDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly CustomGameDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] CustomGameDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Map arg\u00241;

      internal __\u003C\u003EAnon1([In] Map obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => CustomGameDialog.lambda\u0024setup\u00240(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly CustomGameDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon2([In] CustomGameDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00241(this.arg\u00242);
    }
  }
}
