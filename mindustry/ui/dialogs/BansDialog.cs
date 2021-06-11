// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.BansDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class BansDialog : BaseDialog
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 141, 134, 134, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BansDialog()
      : base("@server.bans")
    {
      BansDialog bansDialog = this;
      this.addCloseButton();
      this.setup();
      this.shown((Runnable) new BansDialog.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 165, 139, 140, 134, 103, 135, 118, 190, 127, 17, 113, 141, 127, 47, 109, 250, 69, 144, 117, 103, 133, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setup()
    {
      this.__\u003C\u003Econt.clear();
      float width = 400f;
      float num = 80f;
      Table table1 = new Table();
      ScrollPane scrollPane = new ScrollPane((Element) table1);
      scrollPane.setFadeScrollBars(false);
      if (Vars.netServer.__\u003C\u003Eadmins.getBanned().size == 0)
      {
        Table table2 = table1;
        object obj = (object) "@server.bans.none";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table2.add(text);
      }
      Iterator iterator = Vars.netServer.__\u003C\u003Eadmins.getBanned().iterator();
      while (iterator.hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) iterator.next();
        Table.__\u003Cclinit\u003E();
        Table table2 = new Table((Drawable) Tex.button);
        table2.margin(14f);
        table2.labelWrap(new StringBuilder().append("IP: [lightgray]").append(playerInfo.lastIP).append("\n[]Name: [lightgray]").append(playerInfo.lastName).toString()).width(width - num - 24f);
        table2.add().growX();
        table2.button((Drawable) Icon.cancel, (Runnable) new BansDialog.__\u003C\u003EAnon1(this, playerInfo)).size(num).pad(-14f);
        table1.add((Element) table2).width(width).height(num);
        table1.row();
      }
      this.__\u003C\u003Econt.add((Element) scrollPane);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 185, 223, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00241([In] Administration.PlayerInfo obj0) => Vars.ui.showConfirm("@confirm", "@confirmunban", (Runnable) new BansDialog.__\u003C\u003EAnon2(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {159, 186, 118, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00240([In] Administration.PlayerInfo obj0)
    {
      Vars.netServer.__\u003C\u003Eadmins.unbanPlayerID(obj0.id);
      this.setup();
    }

    [HideFromJava]
    static BansDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly BansDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] BansDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly BansDialog arg\u00241;
      private readonly Administration.PlayerInfo arg\u00242;

      internal __\u003C\u003EAnon1([In] BansDialog obj0, [In] Administration.PlayerInfo obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00241(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly BansDialog arg\u00241;
      private readonly Administration.PlayerInfo arg\u00242;

      internal __\u003C\u003EAnon2([In] BansDialog obj0, [In] Administration.PlayerInfo obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00240(this.arg\u00242);
    }
  }
}
