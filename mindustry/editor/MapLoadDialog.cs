// Decompiled with JetBrains decompiler
// Type: mindustry.editor.MapLoadDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.scene;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.maps;
using mindustry.ui;
using mindustry.ui.dialogs;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class MapLoadDialog : BaseDialog
  {
    private Map selected;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Larc/func/Cons<Lmindustry/maps/Map;>;)V")]
    [LineNumberTable(new byte[] {159, 159, 237, 61, 231, 69, 145, 107, 113, 243, 71, 123, 124, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapLoadDialog(Cons loader)
      : base("@editor.loadmap")
    {
      MapLoadDialog mapLoadDialog = this;
      this.selected = (Map) null;
      this.shown((Runnable) new MapLoadDialog.__\u003C\u003EAnon0(this));
      TextButton textButton = new TextButton("@load");
      textButton.setDisabled((Boolp) new MapLoadDialog.__\u003C\u003EAnon1(this));
      textButton.clicked((Runnable) new MapLoadDialog.__\u003C\u003EAnon2(this, loader));
      this.__\u003C\u003Ebuttons.defaults().size(200f, 50f);
      this.__\u003C\u003Ebuttons.button("@cancel", (Runnable) new MapLoadDialog.__\u003C\u003EAnon3(this));
      this.__\u003C\u003Ebuttons.add((Element) textButton);
    }

    [LineNumberTable(new byte[] {159, 178, 107, 114, 186, 134, 130, 130, 102, 127, 1, 140, 114, 136, 159, 12, 120, 127, 14, 108, 117, 124, 104, 105, 121, 133, 113, 159, 6, 191, 4, 108, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebuild()
    {
      this.__\u003C\u003Econt.clear();
      if (Vars.maps.all().size > 0)
        this.selected = (Map) Vars.maps.all().first();
      ButtonGroup buttonGroup = new ButtonGroup();
      int num1 = 3;
      int num2 = 0;
      Table table1 = new Table();
      table1.defaults().size(200f, 90f).pad(4f);
      table1.margin(10f);
      ScrollPane.__\u003Cclinit\u003E();
      ScrollPane scrollPane = new ScrollPane((Element) table1, Styles.horizontalPane);
      scrollPane.setFadeScrollBars(false);
      Iterator iterator = Vars.maps.all().iterator();
      while (iterator.hasNext())
      {
        Map map = (Map) iterator.next();
        TextButton.__\u003Cclinit\u003E();
        TextButton textButton = new TextButton(map.name(), Styles.togglet);
        textButton.add((Element) new BorderImage(map.safeTexture(), 2f).setScaling(Scaling.__\u003C\u003Efit)).size(64f);
        textButton.getCells().reverse();
        textButton.clicked((Runnable) new MapLoadDialog.__\u003C\u003EAnon4(this, map));
        textButton.getLabelCell().grow().left().padLeft(5f);
        buttonGroup.add((Button) textButton);
        table1.add((Element) textButton);
        ++num2;
        int num3 = num2;
        int num4 = num1;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
          table1.row();
      }
      if (Vars.maps.all().size == 0)
      {
        Table table2 = table1;
        object obj = (object) "@maps.none";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table2.add(text).center();
      }
      else
      {
        Table cont = this.__\u003C\u003Econt;
        object obj = (object) "@editor.loadmap";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        cont.add(text);
      }
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.add((Element) scrollPane);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024new\u00240() => this.selected == null;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 166, 104, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] Cons obj0)
    {
      if (this.selected == null)
        return;
      obj0.get((object) this.selected);
      this.hide();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00242([In] Map obj0) => this.selected = obj0;

    [HideFromJava]
    static MapLoadDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly MapLoadDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] MapLoadDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.rebuild();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Boolp
    {
      private readonly MapLoadDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] MapLoadDialog obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024new\u00240() ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly MapLoadDialog arg\u00241;
      private readonly Cons arg\u00242;

      internal __\u003C\u003EAnon2([In] MapLoadDialog obj0, [In] Cons obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00241(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly MapLoadDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] MapLoadDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly MapLoadDialog arg\u00241;
      private readonly Map arg\u00242;

      internal __\u003C\u003EAnon4([In] MapLoadDialog obj0, [In] Map obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00242(this.arg\u00242);
    }
  }
}
