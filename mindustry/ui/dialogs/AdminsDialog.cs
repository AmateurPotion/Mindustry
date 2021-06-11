// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.AdminsDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
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
  public class AdminsDialog : BaseDialog
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 141, 134, 102, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AdminsDialog()
      : base("@server.admins")
    {
      AdminsDialog adminsDialog = this;
      this.addCloseButton();
      this.setup();
      this.shown((Runnable) new AdminsDialog.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 164, 139, 140, 134, 103, 135, 118, 190, 127, 17, 113, 141, 127, 25, 109, 250, 74, 144, 117, 103, 133, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setup()
    {
      this.__\u003C\u003Econt.clear();
      float width = 400f;
      float num = 80f;
      Table table1 = new Table();
      ScrollPane scrollPane = new ScrollPane((Element) table1);
      scrollPane.setFadeScrollBars(false);
      if (Vars.netServer.__\u003C\u003Eadmins.getAdmins().size == 0)
      {
        Table table2 = table1;
        object obj = (object) "@server.admins.none";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table2.add(text);
      }
      Iterator iterator = Vars.netServer.__\u003C\u003Eadmins.getAdmins().iterator();
      while (iterator.hasNext())
      {
        Administration.PlayerInfo playerInfo = (Administration.PlayerInfo) iterator.next();
        Table.__\u003Cclinit\u003E();
        Table table2 = new Table((Drawable) Tex.button);
        table2.margin(14f);
        table2.labelWrap(new StringBuilder().append("[lightgray]").append(playerInfo.lastName).toString()).width(width - num - 24f);
        table2.add().growX();
        table2.button((Drawable) Icon.cancel, (Runnable) new AdminsDialog.__\u003C\u003EAnon1(this, playerInfo)).size(num).pad(-14f);
        table1.add((Element) table2).width(width).height(num);
        table1.row();
      }
      this.__\u003C\u003Econt.add((Element) scrollPane);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 184, 255, 1, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00242([In] Administration.PlayerInfo obj0) => Vars.ui.showConfirm("@confirm", "@confirmunadmin", (Runnable) new AdminsDialog.__\u003C\u003EAnon2(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {159, 185, 118, 245, 69, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00241([In] Administration.PlayerInfo obj0)
    {
      Vars.netServer.__\u003C\u003Eadmins.unAdminPlayer(obj0.id);
      Groups.player.each((Cons) new AdminsDialog.__\u003C\u003EAnon3(obj0));
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 187, 126, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00240([In] Administration.PlayerInfo obj0, [In] Player obj1)
    {
      if (obj1 == null || obj1.isLocal() || !String.instancehelper_equals(obj1.uuid(), (object) obj0.id))
        return;
      obj1.admin(false);
    }

    [HideFromJava]
    static AdminsDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly AdminsDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] AdminsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly AdminsDialog arg\u00241;
      private readonly Administration.PlayerInfo arg\u00242;

      internal __\u003C\u003EAnon1([In] AdminsDialog obj0, [In] Administration.PlayerInfo obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00242(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly AdminsDialog arg\u00241;
      private readonly Administration.PlayerInfo arg\u00242;

      internal __\u003C\u003EAnon2([In] AdminsDialog obj0, [In] Administration.PlayerInfo obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00241(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Administration.PlayerInfo arg\u00241;

      internal __\u003C\u003EAnon3([In] Administration.PlayerInfo obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => AdminsDialog.lambda\u0024setup\u00240(this.arg\u00241, (Player) obj0);
    }
  }
}
