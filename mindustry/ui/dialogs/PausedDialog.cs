// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.PausedDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class PausedDialog : BaseDialog
  {
    private SaveDialog save;
    private LoadDialog load;
    private bool wasClient;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 237, 59, 107, 107, 199, 135, 145, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PausedDialog()
      : base("@menu")
    {
      PausedDialog pausedDialog = this;
      this.save = new SaveDialog();
      this.load = new LoadDialog();
      this.wasClient = false;
      this.shouldPause = true;
      this.shown((Runnable) new PausedDialog.__\u003C\u003EAnon0(this));
      this.addCloseListener();
    }

    [LineNumberTable(new byte[] {55, 116, 111, 161, 127, 16, 106, 161, 249, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void runExitSave()
    {
      if (Vars.state.isEditor() && !this.wasClient)
        Vars.ui.editor.resumeEditing();
      else if (Vars.control.saves.getCurrent() == null || !Vars.control.saves.getCurrent().isAutosave() || this.wasClient)
        Vars.logic.reset();
      else
        Vars.ui.loadAnd("@saving", (Runnable) new PausedDialog.__\u003C\u003EAnon19());
    }

    [LineNumberTable(new byte[] {159, 165, 139, 242, 70, 106, 102, 159, 7, 127, 12, 159, 28, 123, 108, 127, 14, 191, 29, 140, 255, 10, 74, 159, 16, 140, 159, 36, 101, 127, 1, 127, 2, 159, 18, 123, 159, 14, 140, 127, 34, 108, 159, 18, 140, 255, 4, 69, 172, 159, 33, 255, 17, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void rebuild()
    {
      this.__\u003C\u003Econt.clear();
      this.update((Runnable) new PausedDialog.__\u003C\u003EAnon1(this));
      if (!Vars.mobile)
      {
        float width = 220f;
        this.__\u003C\u003Econt.defaults().width(width).height(55f).pad(5f);
        this.__\u003C\u003Econt.button("@back", (Drawable) Icon.left, (Runnable) new PausedDialog.__\u003C\u003EAnon2(this)).name("back");
        Table cont1 = this.__\u003C\u003Econt;
        TextureRegionDrawable settings1 = Icon.settings;
        SettingsMenuDialog settings2 = Vars.ui.settings;
        Objects.requireNonNull((object) settings2);
        Runnable clicked1 = (Runnable) new PausedDialog.__\u003C\u003EAnon3(settings2);
        cont1.button("@settings", (Drawable) settings1, clicked1).name("settings");
        if (!Vars.state.isCampaign() && !Vars.state.isEditor())
        {
          this.__\u003C\u003Econt.row();
          Table cont2 = this.__\u003C\u003Econt;
          TextureRegionDrawable save1 = Icon.save;
          SaveDialog save2 = this.save;
          Objects.requireNonNull((object) save2);
          Runnable clicked2 = (Runnable) new PausedDialog.__\u003C\u003EAnon4(save2);
          cont2.button("@savegame", (Drawable) save1, clicked2);
          Table cont3 = this.__\u003C\u003Econt;
          TextureRegionDrawable upload = Icon.upload;
          LoadDialog load = this.load;
          Objects.requireNonNull((object) load);
          Runnable clicked3 = (Runnable) new PausedDialog.__\u003C\u003EAnon5(load);
          cont3.button("@loadgame", (Drawable) upload, clicked3).disabled((Boolf) new PausedDialog.__\u003C\u003EAnon6());
        }
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.button("@hostserver", (Drawable) Icon.host, (Runnable) new PausedDialog.__\u003C\u003EAnon7()).disabled((Boolf) new PausedDialog.__\u003C\u003EAnon8()).colspan(2).width(width * 2f + 20f).update((Cons) new PausedDialog.__\u003C\u003EAnon9());
        this.__\u003C\u003Econt.row();
        this.__\u003C\u003Econt.button("@quit", (Drawable) Icon.exit, (Runnable) new PausedDialog.__\u003C\u003EAnon10(this)).colspan(2).width(width + 20f).update((Cons) new PausedDialog.__\u003C\u003EAnon11());
      }
      else
      {
        this.__\u003C\u003Econt.defaults().size(130f).pad(5f);
        this.__\u003C\u003Econt.buttonRow("@back", (Drawable) Icon.play, (Runnable) new PausedDialog.__\u003C\u003EAnon2(this));
        Table cont1 = this.__\u003C\u003Econt;
        TextureRegionDrawable settings1 = Icon.settings;
        SettingsMenuDialog settings2 = Vars.ui.settings;
        Objects.requireNonNull((object) settings2);
        Runnable clicked1 = (Runnable) new PausedDialog.__\u003C\u003EAnon3(settings2);
        cont1.buttonRow("@settings", (Drawable) settings1, clicked1);
        if (!Vars.state.isCampaign() && !Vars.state.isEditor())
        {
          Table cont2 = this.__\u003C\u003Econt;
          TextureRegionDrawable save1 = Icon.save;
          SaveDialog save2 = this.save;
          Objects.requireNonNull((object) save2);
          Runnable clicked2 = (Runnable) new PausedDialog.__\u003C\u003EAnon4(save2);
          cont2.buttonRow("@save", (Drawable) save1, clicked2);
          this.__\u003C\u003Econt.row();
          Table cont3 = this.__\u003C\u003Econt;
          TextureRegionDrawable download = Icon.download;
          LoadDialog load = this.load;
          Objects.requireNonNull((object) load);
          Runnable clicked3 = (Runnable) new PausedDialog.__\u003C\u003EAnon5(load);
          cont3.buttonRow("@load", (Drawable) download, clicked3).disabled((Boolf) new PausedDialog.__\u003C\u003EAnon12());
        }
        else if (Vars.state.isCampaign())
        {
          Table cont2 = this.__\u003C\u003Econt;
          TextureRegionDrawable tree = Icon.tree;
          ResearchDialog research = Vars.ui.research;
          Objects.requireNonNull((object) research);
          Runnable clicked2 = (Runnable) new PausedDialog.__\u003C\u003EAnon13(research);
          cont2.buttonRow("@research", (Drawable) tree, clicked2);
          this.__\u003C\u003Econt.row();
          this.__\u003C\u003Econt.buttonRow("@planetmap", (Drawable) Icon.map, (Runnable) new PausedDialog.__\u003C\u003EAnon14(this));
        }
        else
          this.__\u003C\u003Econt.row();
        Table cont4 = this.__\u003C\u003Econt;
        TextureRegionDrawable host1 = Icon.host;
        HostDialog host2 = Vars.ui.host;
        Objects.requireNonNull((object) host2);
        Runnable clicked4 = (Runnable) new PausedDialog.__\u003C\u003EAnon15(host2);
        cont4.buttonRow("@hostserver.mobile", (Drawable) host1, clicked4).disabled((Boolf) new PausedDialog.__\u003C\u003EAnon16());
        this.__\u003C\u003Econt.buttonRow("@quit", (Drawable) Icon.exit, (Runnable) new PausedDialog.__\u003C\u003EAnon10(this)).update((Cons) new PausedDialog.__\u003C\u003EAnon17());
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 168, 116, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00240()
    {
      if (!Vars.state.isMenu() || !this.isShown())
        return;
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuild\u00241([In] TextButton obj0) => Vars.net.active();

    [Modifiers]
    [LineNumberTable(new byte[] {159, 189, 115, 140, 103, 145, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00242()
    {
      if (Vars.net.server() && Vars.steam)
        Vars.platform.inviteFriends();
      else if (Vars.steam)
        Vars.ui.host.runHost();
      else
        Vars.ui.host.show();
    }

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuild\u00243([In] TextButton obj0) => (!Vars.steam || !Vars.net.server()) && Vars.net.active();

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00244([In] TextButton obj0) => obj0.setText(!Vars.net.server() || !Vars.steam ? "@hostserver" : "@invitefriends");

    [LineNumberTable(new byte[] {46, 255, 0, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void showQuitConfirm() => Vars.ui.showConfirm("@confirm", "@quit.confirm", (Runnable) new PausedDialog.__\u003C\u003EAnon18(this));

    [Modifiers]
    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00245([In] TextButton obj0) => obj0.setText(Vars.control.saves.getCurrent() == null || !Vars.control.saves.getCurrent().isAutosave() ? "@quit" : "@save.quit");

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuild\u00246([In] TextButton obj0) => Vars.net.active();

    [Modifiers]
    [LineNumberTable(new byte[] {29, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00247()
    {
      this.hide();
      Vars.ui.planet.show();
    }

    [Modifiers]
    [LineNumberTable(86)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024rebuild\u00248([In] TextButton obj0) => Vars.net.active();

    [Modifiers]
    [LineNumberTable(new byte[] {39, 127, 26, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00249([In] TextButton obj0)
    {
      obj0.setText(Vars.control.saves.getCurrent() == null || !Vars.control.saves.getCurrent().isAutosave() ? "@quit" : "@save.quit");
      obj0.getLabelCell().growX().wrap();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {47, 112, 118, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showQuitConfirm\u002410()
    {
      this.wasClient = Vars.net.client();
      if (Vars.net.client())
        Vars.netClient.disconnectQuietly();
      this.runExitSave();
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {67, 223, 7, 226, 61, 97, 102, 159, 20, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024runExitSave\u002411()
    {
      Exception exception;
      try
      {
        Vars.control.saves.getCurrent().save();
        goto label_3;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exc = exception;
      Throwable.instancehelper_printStackTrace(exc);
      Vars.ui.showException(new StringBuilder().append("[accent]").append(Core.bundle.get("savefail")).toString(), exc);
label_3:
      Vars.logic.reset();
    }

    [HideFromJava]
    static PausedDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly PausedDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] PausedDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.rebuild();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly PausedDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] PausedDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly PausedDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] PausedDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly SettingsMenuDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] SettingsMenuDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly SaveDialog arg\u00241;

      internal __\u003C\u003EAnon4([In] SaveDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly LoadDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] LoadDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Boolf
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] object obj0) => (PausedDialog.lambda\u0024rebuild\u00241((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void run() => PausedDialog.lambda\u0024rebuild\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolf
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public bool get([In] object obj0) => (PausedDialog.lambda\u0024rebuild\u00243((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void get([In] object obj0) => PausedDialog.lambda\u0024rebuild\u00244((TextButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly PausedDialog arg\u00241;

      internal __\u003C\u003EAnon10([In] PausedDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.showQuitConfirm();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public void get([In] object obj0) => PausedDialog.lambda\u0024rebuild\u00245((TextButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Boolf
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public bool get([In] object obj0) => (PausedDialog.lambda\u0024rebuild\u00246((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly ResearchDialog arg\u00241;

      internal __\u003C\u003EAnon13([In] ResearchDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly PausedDialog arg\u00241;

      internal __\u003C\u003EAnon14([In] PausedDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly HostDialog arg\u00241;

      internal __\u003C\u003EAnon15([In] HostDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Boolf
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public bool get([In] object obj0) => (PausedDialog.lambda\u0024rebuild\u00248((TextButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public void get([In] object obj0) => PausedDialog.lambda\u0024rebuild\u00249((TextButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly PausedDialog arg\u00241;

      internal __\u003C\u003EAnon18([In] PausedDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024showQuitConfirm\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public void run() => PausedDialog.lambda\u0024runExitSave\u002411();
    }
  }
}
