// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.SaveDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.scene.style;
using arc.scene.ui;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.game;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class SaveDialog : LoadDialog
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 141, 242, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SaveDialog()
      : base("@savegame")
    {
      SaveDialog saveDialog = this;
      this.update((Runnable) new SaveDialog.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 187, 148, 247, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void save([In] Saves.SaveSlot obj0)
    {
      Vars.ui.loadfrag.show("@saving");
      Time.runTask(5f, (Runnable) new SaveDialog.__\u003C\u003EAnon3(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 159, 116, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      if (!Vars.state.isMenu() || !this.isShown())
        return;
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addSetup\u00244() => Vars.ui.showTextInput("@save", "@save.newslot", 30, "", (Cons) new SaveDialog.__\u003C\u003EAnon5(this));

    [Modifiers]
    [LineNumberTable(new byte[] {159, 179, 137, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024modifyButton\u00246([In] TextButton obj0, [In] Saves.SaveSlot obj1)
    {
      if (obj0.childrenPressed())
        return;
      Vars.ui.showConfirm("@overwrite", "@save.overwrite", (Runnable) new SaveDialog.__\u003C\u003EAnon4(this, obj1));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 190, 102, 143, 248, 69, 226, 60, 97, 134, 159, 20})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024save\u00247([In] Saves.SaveSlot obj0)
    {
      this.hide();
      Vars.ui.loadfrag.hide();
      Exception exception;
      try
      {
        obj0.save();
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exc = exception;
      Throwable.instancehelper_printStackTrace(exc);
      Vars.ui.showException(new StringBuilder().append("[accent]").append(Core.bundle.get("savefail")).toString(), exc);
    }

    [Modifiers]
    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024modifyButton\u00245([In] Saves.SaveSlot obj0) => this.save(obj0);

    [Modifiers]
    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addSetup\u00243([In] string obj0) => Vars.ui.loadAnd("@saving", (Runnable) new SaveDialog.__\u003C\u003EAnon6(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {159, 171, 113, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addSetup\u00242([In] string obj0)
    {
      Vars.control.saves.addSave(obj0);
      Core.app.post((Runnable) new SaveDialog.__\u003C\u003EAnon7(this));
    }

    [Modifiers]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addSetup\u00241() => Core.app.post((Runnable) new SaveDialog.__\u003C\u003EAnon8(this));

    [LineNumberTable(new byte[] {159, 168, 255, 1, 69, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void addSetup() => this.__\u003C\u003Ebuttons.button("@save.new", (Drawable) Icon.add, (Runnable) new SaveDialog.__\u003C\u003EAnon1(this)).fillX().margin(10f);

    [LineNumberTable(new byte[] {159, 178, 244, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void modifyButton(TextButton button, Saves.SaveSlot slot) => button.clicked((Runnable) new SaveDialog.__\u003C\u003EAnon2(this, button, slot));

    [HideFromJava]
    static SaveDialog() => LoadDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly SaveDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] SaveDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly SaveDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] SaveDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024addSetup\u00244();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly SaveDialog arg\u00241;
      private readonly TextButton arg\u00242;
      private readonly Saves.SaveSlot arg\u00243;

      internal __\u003C\u003EAnon2([In] SaveDialog obj0, [In] TextButton obj1, [In] Saves.SaveSlot obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024modifyButton\u00246(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly SaveDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon3([In] SaveDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024save\u00247(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly SaveDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon4([In] SaveDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024modifyButton\u00245(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly SaveDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] SaveDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024addSetup\u00243((string) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly SaveDialog arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon6([In] SaveDialog obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024addSetup\u00242(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly SaveDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] SaveDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024addSetup\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly SaveDialog arg\u00241;

      internal __\u003C\u003EAnon8([In] SaveDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }
  }
}
