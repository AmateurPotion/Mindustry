// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.HostDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class HostDialog : BaseDialog
  {
    internal float w;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 237, 61, 235, 69, 134, 251, 79, 159, 1, 140, 150, 255, 2, 71, 144, 159, 21, 240, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HostDialog()
      : base("@hostserver")
    {
      HostDialog hostDialog = this;
      this.w = 300f;
      this.addCloseButton();
      this.__\u003C\u003Econt.table((Cons) new HostDialog.__\u003C\u003EAnon0()).width(this.w).height(70f).pad(4f).colspan(3);
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.add().width(65f);
      this.__\u003C\u003Econt.button("@host", (Runnable) new HostDialog.__\u003C\u003EAnon1(this)).width(this.w).height(70f);
      this.__\u003C\u003Econt.button("?", (Runnable) new HostDialog.__\u003C\u003EAnon2()).size(65f, 70f).padLeft(6f);
      this.shown((Runnable) new HostDialog.__\u003C\u003EAnon3());
    }

    [LineNumberTable(new byte[] {13, 116, 246, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void runHost()
    {
      Vars.ui.loadfrag.show("@hosting");
      Time.runTask(5f, (Runnable) new HostDialog.__\u003C\u003EAnon4(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 166, 127, 7, 223, 0, 159, 1, 255, 5, 69, 112, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00244([In] Table obj0)
    {
      Table table = obj0;
      object obj = (object) "@name";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).padRight(10f);
      ((TextField) obj0.field(Core.settings.getString("name"), (Cons) new HostDialog.__\u003C\u003EAnon14()).grow().pad(8f).get()).setMaxLength(40);
      ImageButton imageButton = (ImageButton) obj0.button((Drawable) Tex.whiteui, Styles.clearFulli, 40f, (Runnable) new HostDialog.__\u003C\u003EAnon15()).size(54f).get();
      imageButton.update((Runnable) new HostDialog.__\u003C\u003EAnon16(imageButton));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 187, 123, 111, 161, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00245()
    {
      if (String.instancehelper_isEmpty(String.instancehelper_trim(Core.settings.getString("name"))))
        Vars.ui.showInfo("@noname");
      else
        this.runHost();
    }

    [Modifiers]
    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00246() => Vars.ui.showInfo("@host.info");

    [Modifiers]
    [LineNumberTable(new byte[] {6, 103, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00249()
    {
      if (Vars.steam)
        return;
      Core.app.post((Runnable) new HostDialog.__\u003C\u003EAnon12());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {16, 111, 139, 106, 244, 79, 127, 35, 117, 106, 255, 12, 71, 2, 97, 144, 111, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024runHost\u002417()
    {
      IOException ioException1;
      try
      {
        Vars.net.host(6567);
        Vars.player.admin(true);
        if (Vars.steam)
        {
          Core.app.post((Runnable) new HostDialog.__\u003C\u003EAnon5());
          string modifier1 = mindustry.core.Version.modifier;
          object obj1 = (object) "beta";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj1;
          CharSequence charSequence2 = charSequence1;
          if (!String.instancehelper_contains(modifier1, charSequence2))
          {
            string modifier2 = mindustry.core.Version.modifier;
            object obj2 = (object) "alpha";
            charSequence1.__\u003Cref\u003E = (__Null) obj2;
            CharSequence charSequence3 = charSequence1;
            if (!String.instancehelper_contains(modifier2, charSequence3))
              goto label_6;
          }
          Core.settings.put("publichost", (object) Boolean.valueOf(false));
          Vars.platform.updateLobby();
          Core.settings.getBoolOnce("betapublic", (Runnable) new HostDialog.__\u003C\u003EAnon6());
          goto label_6;
        }
        else
          goto label_6;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Vars.ui.showException("@server.error", (Exception) ioException2);
label_6:
      Vars.ui.loadfrag.hide();
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runHost\u002415() => Core.settings.getBoolOnce("steampublic3", (Runnable) new HostDialog.__\u003C\u003EAnon7());

    [Modifiers]
    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runHost\u002416() => Vars.ui.showInfo("@public.beta");

    [Modifiers]
    [LineNumberTable(new byte[] {21, 255, 19, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runHost\u002414() => Vars.ui.showCustomConfirm("@setting.publichost.name", "@public.confirm", "@yes", "@no", (Runnable) new HostDialog.__\u003C\u003EAnon8(), (Runnable) new HostDialog.__\u003C\u003EAnon9());

    [Modifiers]
    [LineNumberTable(new byte[] {22, 255, 19, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runHost\u002412() => Vars.ui.showCustomConfirm("@setting.publichost.name", "@public.confirm.really", "@no", "@yes", (Runnable) new HostDialog.__\u003C\u003EAnon10(), (Runnable) new HostDialog.__\u003C\u003EAnon11());

    [Modifiers]
    [LineNumberTable(new byte[] {30, 117, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runHost\u002413()
    {
      Core.settings.put("publichost", (object) Boolean.valueOf(false));
      Vars.platform.updateLobby();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {23, 117, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runHost\u002410()
    {
      Core.settings.put("publichost", (object) Boolean.valueOf(true));
      Vars.platform.updateLobby();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {26, 117, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runHost\u002411()
    {
      Core.settings.put("publichost", (object) Boolean.valueOf(false));
      Vars.platform.updateLobby();
    }

    [Modifiers]
    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00248() => Core.settings.getBoolOnce("hostinfo", (Runnable) new HostDialog.__\u003C\u003EAnon13());

    [Modifiers]
    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00247() => Vars.ui.showInfo("@host.info");

    [Modifiers]
    [LineNumberTable(new byte[] {159, 168, 107, 112, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] string obj0)
    {
      Vars.player.name(obj0);
      Core.settings.put("name", (object) obj0);
      Vars.ui.listfrag.rebuild();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 212})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00242() => new PaletteDialog().show((Cons) new HostDialog.__\u003C\u003EAnon17());

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00243([In] ImageButton obj0) => obj0.getStyle().imageUpColor = Vars.player.color();

    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 113, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] Color obj0)
    {
      Vars.player.color().set(obj0);
      Core.settings.put("color-0", (object) Integer.valueOf(obj0.rgba()));
    }

    [HideFromJava]
    static HostDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => HostDialog.lambda\u0024new\u00244((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly HostDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] HostDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00245();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void run() => HostDialog.lambda\u0024new\u00246();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void run() => HostDialog.lambda\u0024new\u00249();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly HostDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] HostDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024runHost\u002417();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void run() => HostDialog.lambda\u0024runHost\u002415();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void run() => HostDialog.lambda\u0024runHost\u002416();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void run() => HostDialog.lambda\u0024runHost\u002414();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void run() => HostDialog.lambda\u0024runHost\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void run() => HostDialog.lambda\u0024runHost\u002413();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public void run() => HostDialog.lambda\u0024runHost\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public void run() => HostDialog.lambda\u0024runHost\u002411();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public void run() => HostDialog.lambda\u0024new\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public void run() => HostDialog.lambda\u0024new\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void get([In] object obj0) => HostDialog.lambda\u0024new\u00240((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void run() => HostDialog.lambda\u0024new\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly ImageButton arg\u00241;

      internal __\u003C\u003EAnon16([In] ImageButton obj0) => this.arg\u00241 = obj0;

      public void run() => HostDialog.lambda\u0024new\u00243(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public void get([In] object obj0) => HostDialog.lambda\u0024new\u00241((Color) obj0);
    }
  }
}
