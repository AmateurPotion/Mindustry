// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.LoadDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.function;
using mindustry.core;
using mindustry.game;
using mindustry.gen;
using mindustry.io;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class LoadDialog : BaseDialog
  {
    internal ScrollPane pane;
    internal Table slots;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LoadDialog()
      : this("@loadgame")
    {
    }

    [LineNumberTable(new byte[] {159, 173, 105, 134, 113, 145, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LoadDialog(string title)
      : base(title)
    {
      LoadDialog loadDialog = this;
      this.setup();
      this.shown((Runnable) new LoadDialog.__\u003C\u003EAnon0(this));
      this.onResize((Runnable) new LoadDialog.__\u003C\u003EAnon0(this));
      this.addCloseButton();
      this.addSetup();
    }

    [LineNumberTable(new byte[] {159, 184, 139, 107, 118, 108, 141, 155, 150, 112, 145, 127, 5, 98, 130, 127, 3, 139, 130, 118, 109, 135, 141, 244, 92, 108, 136, 103, 145, 255, 12, 75, 154, 245, 78, 149, 138, 159, 23, 114, 140, 133, 99, 191, 47, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setup()
    {
      this.__\u003C\u003Econt.clear();
      this.slots = new Table();
      ScrollPane.__\u003Cclinit\u003E();
      this.pane = new ScrollPane((Element) this.slots);
      this.pane.setFadeScrollBars(false);
      this.pane.setScrollingDisabled(true, false);
      this.slots.marginRight(24f).marginLeft(20f);
      Time.runTask(2f, (Runnable) new LoadDialog.__\u003C\u003EAnon1(this));
      Seq saveSlots = Vars.control.saves.getSaveSlots();
      saveSlots.sort((Comparator) new LoadDialog.__\u003C\u003EAnon2());
      int num1 = Math.max(ByteCodeHelper.f2i((float) Core.graphics.getWidth() / Scl.scl(470f)), 1);
      int num2 = 0;
      int num3 = 0;
      Iterator iterator = saveSlots.iterator();
      while (iterator.hasNext())
      {
        Saves.SaveSlot slot = (Saves.SaveSlot) iterator.next();
        if (!slot.isHidden())
        {
          num3 = 1;
          TextButton.__\u003Cclinit\u003E();
          TextButton button = new TextButton("", Styles.cleart);
          button.getLabel().remove();
          button.clearChildren();
          button.defaults().left();
          button.table((Cons) new LoadDialog.__\u003C\u003EAnon3(this, slot)).growX().colspan(2);
          button.row();
          string str = "[lightgray]";
          TextureAtlas.AtlasRegion atlasRegion = Core.atlas.find("nomap");
          button.left().add((Element) new BorderImage((TextureRegion) atlasRegion, 4f)).update((Cons) new LoadDialog.__\u003C\u003EAnon4((TextureRegion) atlasRegion, slot)).left().size(160f).padRight(6f);
          button.table((Cons) new LoadDialog.__\u003C\u003EAnon5(str, slot)).left().growX().width(250f);
          this.modifyButton(button, slot);
          this.slots.add((Element) button).uniformX().fillX().pad(4f).padRight(8f).margin(10f);
          ++num2;
          int num4 = num2;
          int num5 = num1;
          if ((num5 != -1 ? num4 % num5 : 0) == 0)
            this.slots.row();
        }
      }
      if (num3 == 0)
        this.slots.button("@save.none", (Runnable) new LoadDialog.__\u003C\u003EAnon6()).disabled(true).fillX().margin(20f).minWidth(340f).height(80f).pad(4f);
      this.__\u003C\u003Econt.add((Element) this.pane);
    }

    [LineNumberTable(new byte[] {102, 255, 1, 78, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addSetup() => this.__\u003C\u003Ebuttons.button("@save.import", (Drawable) Icon.add, (Runnable) new LoadDialog.__\u003C\u003EAnon7(this)).fillX().margin(10f);

    [LineNumberTable(new byte[] {160, 76, 244, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void modifyButton(TextButton button, Saves.SaveSlot slot) => button.clicked((Runnable) new LoadDialog.__\u003C\u003EAnon9(this, button, slot));

    [LineNumberTable(new byte[] {120, 242, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void runLoadSave(Saves.SaveSlot slot) => slot.cautiousLoad((Runnable) new LoadDialog.__\u003C\u003EAnon8(this, slot));

    [Modifiers]
    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00240() => Core.scene.setScrollFocus((Element) this.pane);

    [Modifiers]
    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024setup\u00241([In] Saves.SaveSlot obj0, [In] Saves.SaveSlot obj1) => -Long.compare(obj0.getTimestamp(), obj1.getTimestamp());

    [Modifiers]
    [LineNumberTable(new byte[] {22, 159, 48, 247, 88, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00249([In] Saves.SaveSlot obj0, [In] Table obj1)
    {
      Table table = obj1;
      object obj = (object) new StringBuilder().append("[accent]").append(obj0.getName()).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).left().growX().width(230f).wrap();
      obj1.table((Cons) new LoadDialog.__\u003C\u003EAnon14(this, obj0)).padRight(-10f).growX();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {56, 108, 114, 167, 103, 113, 140, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002410(
      [In] TextureRegion obj0,
      [In] Saves.SaveSlot obj1,
      [In] BorderImage obj2)
    {
      TextureRegionDrawable drawable = (TextureRegionDrawable) obj2.getDrawable();
      if (drawable.getRegion().texture.isDisposed())
        drawable.setRegion(obj0);
      Texture texture = obj1.previewTexture();
      if (object.ReferenceEquals((object) drawable.getRegion(), (object) obj0) && texture != null)
        drawable.setRegion(new TextureRegion(texture));
      obj2.setScaling(Scaling.__\u003C\u003Efit);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {69, 108, 127, 1, 103, 127, 57, 103, 127, 84, 103, 115, 103, 115, 103, 127, 3, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002413([In] string obj0, [In] Saves.SaveSlot obj1, [In] Table obj2)
    {
      obj2.left().top();
      obj2.defaults().padBottom(-2f).left().width(290f);
      obj2.row();
      obj2.labelWrap(Core.bundle.format("save.map", (object) new StringBuilder().append(obj0).append(obj1.getMap() != null ? obj1.getMap().name() : Core.bundle.get("unknown")).toString()));
      obj2.row();
      obj2.labelWrap(new StringBuilder().append(obj1.mode().toString()).append(" /").append(obj0).append(" ").append(Core.bundle.format("save.wave", (object) new StringBuilder().append(obj0).append(obj1.getWave()).toString())).toString());
      obj2.row();
      obj2.labelWrap((Prov) new LoadDialog.__\u003C\u003EAnon12(obj0, obj1));
      obj2.row();
      obj2.labelWrap((Prov) new LoadDialog.__\u003C\u003EAnon13(obj0, obj1));
      obj2.row();
      obj2.labelWrap(new StringBuilder().append(obj0).append(obj1.getDate()).toString());
      obj2.row();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u002414()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {103, 251, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addSetup\u002416() => Vars.platform.showFileChooser(true, "msav", (Cons) new LoadDialog.__\u003C\u003EAnon11(this));

    [Modifiers]
    [LineNumberTable(new byte[] {121, 246, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024runLoadSave\u002418([In] Saves.SaveSlot obj0) => Vars.ui.loadAnd((Runnable) new LoadDialog.__\u003C\u003EAnon10(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {160, 77, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024modifyButton\u002419([In] TextButton obj0, [In] Saves.SaveSlot obj1)
    {
      if (obj0.childrenPressed())
        return;
      this.runLoadSave(obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {122, 102, 143, 106, 102, 112, 112, 255, 2, 69, 226, 60, 97, 102, 106, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024runLoadSave\u002417([In] Saves.SaveSlot obj0)
    {
      this.hide();
      Vars.ui.paused.hide();
      SaveIO.SaveException saveException;
      try
      {
        Vars.net.reset();
        obj0.load();
        Vars.state.rules.editor = false;
        Vars.state.rules.sector = (Sector) null;
        Vars.state.set(GameState.State.__\u003C\u003Eplaying);
        return;
      }
      catch (SaveIO.SaveException ex)
      {
        saveException = (SaveIO.SaveException) ByteCodeHelper.MapException<SaveIO.SaveException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      Log.err((Exception) saveException);
      Vars.logic.reset();
      Vars.ui.showErrorMessage("@save.corrupted");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {104, 136, 113, 216, 226, 61, 97, 102, 112, 130, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024addSetup\u002415([In] Fi obj0)
    {
      if (SaveIO.isSaveValid(obj0))
      {
        IOException ioException1;
        try
        {
          Vars.control.saves.importSave(obj0);
          this.setup();
          return;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        IOException ioException2 = ioException1;
        Throwable.instancehelper_printStackTrace((Exception) ioException2);
        Vars.ui.showException("@save.import.fail", (Exception) ioException2);
      }
      else
        Vars.ui.showErrorMessage("@save.import.invalid");
    }

    [Modifiers]
    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024setup\u002411(
      [In] string obj0,
      [In] Saves.SaveSlot obj1)
    {
      object obj = (object) Core.bundle.format("save.autosave", (object) new StringBuilder().append(obj0).append(Core.bundle.get(!obj1.isAutosave() ? "off" : "on")).toString());
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024setup\u002412(
      [In] string obj0,
      [In] Saves.SaveSlot obj1)
    {
      object obj = (object) Core.bundle.format("save.playtime", (object) new StringBuilder().append(obj0).append(obj1.getPlayTime()).toString());
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {25, 103, 145, 156, 144, 252, 69, 134, 252, 69, 134, 159, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00248([In] Saves.SaveSlot obj0, [In] Table obj1)
    {
      obj1.right();
      obj1.defaults().size(40f);
      obj1.button((Drawable) Icon.save, Styles.emptytogglei, (Runnable) new LoadDialog.__\u003C\u003EAnon15(obj0)).@checked(obj0.isAutosave()).right();
      obj1.button((Drawable) Icon.trash, Styles.emptyi, (Runnable) new LoadDialog.__\u003C\u003EAnon16(this, obj0)).right();
      obj1.button((Drawable) Icon.pencil, Styles.emptyi, (Runnable) new LoadDialog.__\u003C\u003EAnon17(this, obj0)).right();
      obj1.button((Drawable) Icon.export, Styles.emptyi, (Runnable) new LoadDialog.__\u003C\u003EAnon18(obj0)).right();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {29, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00242([In] Saves.SaveSlot obj0) => obj0.setAutosave(!obj0.isAutosave());

    [Modifiers]
    [LineNumberTable(new byte[] {33, 223, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00244([In] Saves.SaveSlot obj0) => Vars.ui.showConfirm("@confirm", "@save.delete.confirm", (Runnable) new LoadDialog.__\u003C\u003EAnon21(this, obj0));

    [Modifiers]
    [LineNumberTable(new byte[] {40, 223, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00246([In] Saves.SaveSlot obj0) => Vars.ui.showTextInput("@save.rename", "@save.rename.text", obj0.getName(), (Cons) new LoadDialog.__\u003C\u003EAnon20(this, obj0));

    [Modifiers]
    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024setup\u00247([In] Saves.SaveSlot obj0)
    {
      Platform platform = Vars.platform;
      string name = new StringBuilder().append("save-").append(obj0.getName()).toString();
      Saves.SaveSlot saveSlot = obj0;
      Objects.requireNonNull((object) saveSlot);
      Platform.FileWriter writer = (Platform.FileWriter) new LoadDialog.__\u003C\u003EAnon19(saveSlot);
      platform.export(name, "msav", writer);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {41, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00245([In] Saves.SaveSlot obj0, [In] string obj1)
    {
      obj0.setName(obj1);
      this.setup();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {34, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00243([In] Saves.SaveSlot obj0)
    {
      obj0.delete();
      this.setup();
    }

    [HideFromJava]
    static LoadDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly LoadDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] LoadDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly LoadDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] LoadDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setup\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Comparator
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public int compare([In] object obj0, [In] object obj1) => LoadDialog.lambda\u0024setup\u00241((Saves.SaveSlot) obj0, (Saves.SaveSlot) obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly LoadDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon3([In] LoadDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00249(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly TextureRegion arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon4([In] TextureRegion obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => LoadDialog.lambda\u0024setup\u002410(this.arg\u00241, this.arg\u00242, (BorderImage) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly string arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon5([In] string obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => LoadDialog.lambda\u0024setup\u002413(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void run() => LoadDialog.lambda\u0024setup\u002414();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly LoadDialog arg\u00241;

      internal __\u003C\u003EAnon7([In] LoadDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024addSetup\u002416();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly LoadDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon8([In] LoadDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024runLoadSave\u002418(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly LoadDialog arg\u00241;
      private readonly TextButton arg\u00242;
      private readonly Saves.SaveSlot arg\u00243;

      internal __\u003C\u003EAnon9([In] LoadDialog obj0, [In] TextButton obj1, [In] Saves.SaveSlot obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024modifyButton\u002419(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly LoadDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon10([In] LoadDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024runLoadSave\u002417(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly LoadDialog arg\u00241;

      internal __\u003C\u003EAnon11([In] LoadDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024addSetup\u002415((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      private readonly string arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon12([In] string obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) LoadDialog.lambda\u0024setup\u002411(this.arg\u00241, this.arg\u00242).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Prov
    {
      private readonly string arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon13([In] string obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) LoadDialog.lambda\u0024setup\u002412(this.arg\u00241, this.arg\u00242).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly LoadDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon14([In] LoadDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00248(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly Saves.SaveSlot arg\u00241;

      internal __\u003C\u003EAnon15([In] Saves.SaveSlot obj0) => this.arg\u00241 = obj0;

      public void run() => LoadDialog.lambda\u0024setup\u00242(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly LoadDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon16([In] LoadDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00244(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly LoadDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon17([In] LoadDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00246(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly Saves.SaveSlot arg\u00241;

      internal __\u003C\u003EAnon18([In] Saves.SaveSlot obj0) => this.arg\u00241 = obj0;

      public void run() => LoadDialog.lambda\u0024setup\u00247(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Platform.FileWriter
    {
      private readonly Saves.SaveSlot arg\u00241;

      internal __\u003C\u003EAnon19([In] Saves.SaveSlot obj0) => this.arg\u00241 = obj0;

      public void write([In] Fi obj0) => this.arg\u00241.exportFile(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly LoadDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon20([In] LoadDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00245(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Runnable
    {
      private readonly LoadDialog arg\u00241;
      private readonly Saves.SaveSlot arg\u00242;

      internal __\u003C\u003EAnon21([In] LoadDialog obj0, [In] Saves.SaveSlot obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00243(this.arg\u00242);
    }
  }
}
