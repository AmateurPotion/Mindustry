// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.FileChooser
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.graphics.g2d;
using arc.input;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.function;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class FileChooser : BaseDialog
  {
    [Modifiers]
    private static Fi homeDirectory;
    internal static Fi lastDirectory;
    private Table files;
    internal Fi directory;
    private ScrollPane pane;
    private TextField navigation;
    private TextField filefield;
    private TextButton ok;
    private FileChooser.FileHistory stack;
    [Signature("Larc/func/Boolf<Larc/files/Fi;>;")]
    private Boolf filter;
    [Signature("Larc/func/Cons<Larc/files/Fi;>;")]
    private Cons selectListener;
    private bool open;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Ljava/lang/String;Larc/func/Boolf<Larc/files/Fi;>;ZLarc/func/Cons<Larc/files/Fi;>;)V")]
    [LineNumberTable(new byte[] {159, 134, 130, 233, 54, 203, 236, 71, 103, 103, 103, 136, 241, 69, 241, 69, 214, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FileChooser(string title, Boolf filter, bool open, Cons result)
    {
      int num = open ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(title);
      FileChooser fileChooser = this;
      this.directory = FileChooser.lastDirectory;
      this.stack = new FileChooser.FileHistory(this);
      this.setFillParent(true);
      this.open = num != 0;
      this.filter = filter;
      this.selectListener = result;
      this.onResize((Runnable) new FileChooser.__\u003C\u003EAnon0(this));
      this.shown((Runnable) new FileChooser.__\u003C\u003EAnon1(this));
      this.keyDown(KeyCode.__\u003C\u003Eenter, (Runnable) new FileChooser.__\u003C\u003EAnon2(this));
      this.addCloseListener();
    }

    [LineNumberTable(new byte[] {160, 139, 102, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setLastDirectory(Fi directory)
    {
      FileChooser.lastDirectory = directory;
      Core.settings.put("lastDirectory", (object) directory.absolutePath());
    }

    [LineNumberTable(new byte[] {159, 99, 130, 116, 150, 154, 159, 7, 116, 142, 187, 134, 107, 113, 136, 108, 127, 22, 243, 70, 127, 4, 109, 140, 127, 26, 140, 103, 136, 124, 157, 137, 115, 109, 109, 137, 247, 75, 218, 156, 126, 108, 127, 14, 127, 11, 109, 236, 32, 235, 99, 112, 134, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void updateFiles([In] bool obj0)
    {
      if (obj0)
        this.stack.push(this.directory);
      this.navigation.setText(this.directory.toString());
      GlyphLayout glyphLayout1 = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new FileChooser.__\u003C\u003EAnon14());
      GlyphLayout glyphLayout2 = glyphLayout1;
      Font def = Fonts.def;
      object text1 = (object) this.navigation.getText();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) text1;
      CharSequence str = charSequence;
      glyphLayout2.setText(def, str);
      if ((double) glyphLayout1.width < (double) this.navigation.getWidth())
        this.navigation.setCursorPosition(0);
      else
        this.navigation.setCursorPosition(String.instancehelper_length(this.navigation.getText()));
      Pools.free((object) glyphLayout1);
      this.files.clearChildren();
      this.files.top().left();
      Fi[] fileNames = this.getFileNames();
      Image image1 = new Image((Drawable) Icon.upOpen);
      TextButton.__\u003Cclinit\u003E();
      TextButton textButton1 = new TextButton(new StringBuilder().append("..").append(this.directory.toString()).toString(), Styles.clearTogglet);
      textButton1.clicked((Runnable) new FileChooser.__\u003C\u003EAnon15(this));
      textButton1.left().add((Element) image1).padRight(4f).padLeft(4f);
      textButton1.getLabel().setAlignment(8);
      textButton1.getCells().reverse();
      this.files.add((Element) textButton1).align(10).fillX().expandX().height(50f).pad(2f).colspan(2);
      this.files.row();
      ButtonGroup buttonGroup = new ButtonGroup();
      buttonGroup.setMinCheckCount(0);
      Fi[] fiArray = fileNames;
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Fi fi = fiArray[index];
        if (fi.isDirectory() || this.filter.get((object) fi))
        {
          string text2 = fi.name();
          TextButton.__\u003Cclinit\u003E();
          TextButton textButton2 = new TextButton(text2, Styles.clearTogglet);
          textButton2.getLabel().setWrap(false);
          textButton2.getLabel().setEllipsis(true);
          buttonGroup.add((Button) textButton2);
          textButton2.clicked((Runnable) new FileChooser.__\u003C\u003EAnon16(this, fi, text2));
          this.filefield.changed((Runnable) new FileChooser.__\u003C\u003EAnon17(this, textButton2, text2));
          Image image2 = new Image(!fi.isDirectory() ? (Drawable) Icon.fileText : (Drawable) Icon.folder);
          textButton2.add((Element) image2).padRight(4f).padLeft(4f);
          textButton2.getCells().reverse();
          this.files.top().left().add((Element) textButton2).align(10).fillX().expandX().height(50f).pad(2f).padTop(0.0f).padBottom(0.0f).colspan(2);
          textButton2.getLabel().setAlignment(8);
          this.files.row();
        }
      }
      this.pane.setScrollY(0.0f);
      this.updateFileFieldStatus();
      if (!this.open)
        return;
      this.filefield.clearText();
    }

    [LineNumberTable(new byte[] {113, 150, 240, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Fi[] getFileNames()
    {
      Fi[] fiArray = this.directory.list((FileFilter) new FileChooser.__\u003C\u003EAnon12());
      Arrays.sort((object[]) fiArray, (Comparator) new FileChooser.__\u003C\u003EAnon13());
      return fiArray;
    }

    [LineNumberTable(new byte[] {105, 104, 159, 47, 159, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateFileFieldStatus()
    {
      if (!this.open)
      {
        TextButton ok = this.ok;
        string text = this.filefield.getText();
        object obj1 = (object) "";
        object obj2 = (object) " ";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        int num = String.instancehelper_isEmpty(String.instancehelper_replace(text, charSequence2, charSequence3)) ? 1 : 0;
        ok.setDisabled(num != 0);
      }
      else
        this.ok.setDisabled(!this.directory.child(this.filefield.getText()).exists() || this.directory.child(this.filefield.getText()).isDirectory());
    }

    [LineNumberTable(new byte[] {8, 145, 134, 107, 108, 115, 145, 159, 5, 247, 71, 214, 139, 107, 146, 112, 144, 107, 113, 145, 118, 109, 140, 135, 134, 112, 242, 70, 113, 145, 115, 115, 114, 146, 113, 243, 70, 127, 6, 105, 105, 105, 136, 103, 127, 15, 159, 13, 103, 119, 105, 142, 108, 114, 135, 125, 135, 104, 127, 19, 167, 142, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setupWidgets()
    {
      this.__\u003C\u003Econt.margin(-10f);
      Table table1 = new Table();
      this.filefield = new TextField();
      this.filefield.setOnlyFontChars(false);
      if (!this.open)
        this.filefield.addInputDialog();
      this.filefield.setDisabled(this.open);
      TextButton.__\u003Cclinit\u003E();
      this.ok = new TextButton(!this.open ? "@save" : "@load");
      this.ok.clicked((Runnable) new FileChooser.__\u003C\u003EAnon3(this));
      this.filefield.changed((Runnable) new FileChooser.__\u003C\u003EAnon4(this));
      this.filefield.change();
      TextButton textButton = new TextButton("@cancel");
      textButton.clicked((Runnable) new FileChooser.__\u003C\u003EAnon5(this));
      this.navigation = new TextField("");
      this.navigation.touchable = Touchable.__\u003C\u003Edisabled;
      this.files = new Table();
      this.files.marginRight(10f);
      this.files.marginLeft(3f);
      ScrollPane.__\u003Cclinit\u003E();
      this.pane = new ScrollPane((Element) this.files);
      this.pane.setOverscroll(false, false);
      this.pane.setFadeScrollBars(false);
      this.updateFiles(true);
      Table table2 = new Table();
      ImageButton.__\u003Cclinit\u003E();
      ImageButton imageButton1 = new ImageButton((Drawable) Icon.upOpen);
      imageButton1.clicked((Runnable) new FileChooser.__\u003C\u003EAnon6(this));
      ImageButton.__\u003Cclinit\u003E();
      ImageButton imageButton2 = new ImageButton((Drawable) Icon.left);
      ImageButton.__\u003Cclinit\u003E();
      ImageButton imageButton3 = new ImageButton((Drawable) Icon.right);
      imageButton3.clicked((Runnable) new FileChooser.__\u003C\u003EAnon7(this));
      imageButton2.clicked((Runnable) new FileChooser.__\u003C\u003EAnon8(this));
      imageButton3.setDisabled((Boolp) new FileChooser.__\u003C\u003EAnon9(this));
      imageButton2.setDisabled((Boolp) new FileChooser.__\u003C\u003EAnon10(this));
      ImageButton.__\u003Cclinit\u003E();
      ImageButton imageButton4 = new ImageButton((Drawable) Icon.home);
      imageButton4.clicked((Runnable) new FileChooser.__\u003C\u003EAnon11(this));
      table2.defaults().height(60f).growX().padTop(5f).uniform();
      table2.add((Element) imageButton4);
      table2.add((Element) imageButton2);
      table2.add((Element) imageButton3);
      table2.add((Element) imageButton1);
      Table table3 = new Table();
      Table table4 = table3.bottom().left();
      object obj = (object) "@filename";
      CharSequence text;
      text.__\u003Cref\u003E = (__Null) obj;
      Label label = new Label(text);
      table4.add((Element) label);
      table3.add((Element) this.filefield).height(40f).fillX().expandX().padLeft(10f);
      Table table5 = new Table();
      table5.defaults().growX().height(60f);
      table5.add((Element) textButton);
      table5.add((Element) this.ok);
      table1.top().left();
      table1.add((Element) table2).expandX().fillX();
      table1.row();
      table1.center().add((Element) this.pane).colspan(3).grow();
      table1.row();
      if (!this.open)
      {
        table1.bottom().left().add((Element) table3).colspan(3).grow().padTop(-2f).padBottom(2f);
        table1.row();
      }
      table1.add((Element) table5).growX();
      this.__\u003C\u003Econt.add((Element) table1).grow();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 183, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      this.__\u003C\u003Econt.clear();
      this.setupWidgets();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 188, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241()
    {
      this.__\u003C\u003Econt.clear();
      this.setupWidgets();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {1, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242() => this.ok.fireClick();

    [Modifiers]
    [LineNumberTable(new byte[] {20, 110, 104, 127, 2, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupWidgets\u00243()
    {
      if (this.ok.isDisabled())
        return;
      if (this.selectListener != null)
        this.selectListener.get((object) this.directory.child(this.filefield.getText()));
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {27, 127, 45})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupWidgets\u00244()
    {
      TextButton ok = this.ok;
      string text = this.filefield.getText();
      object obj1 = (object) "";
      object obj2 = (object) " ";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      int num = String.instancehelper_isEmpty(String.instancehelper_replace(text, charSequence2, charSequence3)) ? 1 : 0;
      ok.setDisabled(num != 0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {52, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupWidgets\u00245()
    {
      this.directory = this.directory.parent();
      this.updateFiles(true);
    }

    [Modifiers]
    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupWidgets\u00246() => this.stack.forward();

    [Modifiers]
    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupWidgets\u00247() => this.stack.back();

    [Modifiers]
    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setupWidgets\u00248() => !this.stack.canForward();

    [Modifiers]
    [LineNumberTable(113)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024setupWidgets\u00249() => !this.stack.canBack();

    [Modifiers]
    [LineNumberTable(new byte[] {67, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setupWidgets\u002410()
    {
      this.directory = FileChooser.homeDirectory;
      FileChooser.setLastDirectory(this.directory);
      this.updateFiles(true);
    }

    [Modifiers]
    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getFileNames\u002411([In] File obj0) => !String.instancehelper_startsWith(obj0.getName(), ".");

    [Modifiers]
    [LineNumberTable(new byte[] {116, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024getFileNames\u002412([In] Fi obj0, [In] Fi obj1)
    {
      if (obj0.isDirectory() && !obj1.isDirectory())
        return -1;
      return !obj0.isDirectory() && obj1.isDirectory() ? 1 : ((Comparator) String.CASE_INSENSITIVE_ORDER).compare((object) obj0.name(), (object) obj1.name());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 82, 113, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateFiles\u002413()
    {
      this.directory = this.directory.parent();
      FileChooser.setLastDirectory(this.directory);
      this.updateFiles(true);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 108, 104, 108, 136, 114, 107, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateFiles\u002414([In] Fi obj0, [In] string obj1)
    {
      if (!obj0.isDirectory())
      {
        this.filefield.setText(obj1);
        this.updateFileFieldStatus();
      }
      else
      {
        this.directory = this.directory.child(obj1);
        FileChooser.setLastDirectory(this.directory);
        this.updateFiles(true);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024updateFiles\u002415([In] TextButton obj0, [In] string obj1) => obj0.setChecked(String.instancehelper_equals(obj1, (object) this.filefield.getText()));

    [LineNumberTable(new byte[] {160, 144, 99, 105, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string shorten([In] string obj0)
    {
      int num = 30;
      return String.instancehelper_length(obj0) <= num ? obj0 : String.instancehelper_concat(String.instancehelper_substring(obj0, 0, num - 3), "...");
    }

    [LineNumberTable(new byte[] {159, 137, 82, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FileChooser()
    {
      BaseDialog.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.ui.dialogs.FileChooser"))
        return;
      FileChooser.homeDirectory = Core.files.absolute(Core.files.getExternalStoragePath());
      FileChooser.lastDirectory = Core.files.absolute(Core.settings.getString(nameof (lastDirectory), FileChooser.homeDirectory.absolutePath()));
    }

    public class FileHistory : Object
    {
      [Signature("Larc/struct/Seq<Larc/files/Fi;>;")]
      private Seq history;
      private int index;
      [Modifiers]
      internal FileChooser this\u00240;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool canBack() => this.index != 1 && this.index > 0;

      [LineNumberTable(297)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool canForward() => this.index < this.history.size;

      [LineNumberTable(new byte[] {160, 156, 239, 61, 235, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FileHistory(FileChooser _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        FileChooser.FileHistory fileHistory = this;
        this.history = new Seq();
      }

      [LineNumberTable(new byte[] {160, 161, 127, 5, 108, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void push(Fi file)
      {
        if (this.index != this.history.size)
          this.history.truncate(this.index);
        this.history.add((object) file);
        ++this.index;
      }

      [LineNumberTable(new byte[] {160, 167, 105, 110, 127, 4, 112, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void back()
      {
        if (!this.canBack())
          return;
        --this.index;
        this.this\u00240.directory = (Fi) this.history.get(this.index - 1);
        FileChooser.setLastDirectory(this.this\u00240.directory);
        this.this\u00240.updateFiles(false);
      }

      [LineNumberTable(new byte[] {160, 175, 105, 127, 2, 112, 110, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void forward()
      {
        if (!this.canForward())
          return;
        this.this\u00240.directory = (Fi) this.history.get(this.index);
        FileChooser.setLastDirectory(this.this\u00240.directory);
        ++this.index;
        this.this\u00240.updateFiles(false);
      }

      [LineNumberTable(new byte[] {160, 192, 111, 98, 127, 4, 100, 105, 159, 22, 159, 20, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void print()
      {
        java.lang.System.@out.println("\n\n\n\n\n\n");
        int num = 0;
        Iterator iterator = this.history.iterator();
        while (iterator.hasNext())
        {
          Fi fi = (Fi) iterator.next();
          ++num;
          if (this.index == num)
            java.lang.System.@out.println(new StringBuilder().append("[[").append(fi.toString()).append("]]").toString());
          else
            java.lang.System.@out.println(new StringBuilder().append("--").append(fi.toString()).append("--").toString());
        }
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon0([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon1([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon2([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00242();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon3([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setupWidgets\u00243();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon4([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setupWidgets\u00244();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon5([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon6([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setupWidgets\u00245();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon7([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setupWidgets\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon8([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setupWidgets\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Boolp
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon9([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setupWidgets\u00248() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Boolp
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon10([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024setupWidgets\u00249() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon11([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024setupWidgets\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : FileFilter
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public bool accept([In] File obj0) => (FileChooser.lambda\u0024getFileNames\u002411(obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Comparator
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public int compare([In] object obj0, [In] object obj1) => FileChooser.lambda\u0024getFileNames\u002412((Fi) obj0, (Fi) obj1);

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
    private sealed class __\u003C\u003EAnon14 : Prov
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public object get() => (object) new GlyphLayout();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly FileChooser arg\u00241;

      internal __\u003C\u003EAnon15([In] FileChooser obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024updateFiles\u002413();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly FileChooser arg\u00241;
      private readonly Fi arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon16([In] FileChooser obj0, [In] Fi obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024updateFiles\u002414(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly FileChooser arg\u00241;
      private readonly TextButton arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon17([In] FileChooser obj0, [In] TextButton obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024updateFiles\u002415(this.arg\u00242, this.arg\u00243);
    }
  }
}
