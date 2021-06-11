// Decompiled with JetBrains decompiler
// Type: mindustry.logic.LStatement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math;
using arc.scene;
using arc.scene.actions;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.ui;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  public abstract class LStatement : Object
  {
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [NonSerialized]
    public LCanvas.StatementElem elem;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void afterRead()
    {
    }

    [LineNumberTable(new byte[] {97, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(StringBuilder builder) => LogicIO.write((object) this, builder);

    public abstract LExecutor.LInstruction build(LAssembler la);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setupUI()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void saveUI()
    {
    }

    public abstract Color color();

    [LineNumberTable(new byte[] {159, 173, 102, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LStatement copy()
    {
      StringBuilder builder = new StringBuilder();
      this.write(builder);
      Seq seq = LAssembler.read(builder.toString());
      return seq.size == 0 ? (LStatement) null : (LStatement) seq.first();
    }

    public abstract void build(Table t);

    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string name()
    {
      string simpleName = Object.instancehelper_getClass((object) this).getSimpleName();
      object obj1 = (object) "";
      object obj2 = (object) "Statement";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      return Strings.insertSpaces(String.instancehelper_replace(simpleName, charSequence2, charSequence3));
    }

    [Signature("(Larc/scene/ui/layout/Table;Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextField;>;")]
    [LineNumberTable(new byte[] {159, 191, 119, 63, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Cell field(Table table, string value, Cons setter) => table.field(value, Styles.nodeField, setter).size(144f, 40f).pad(2f).color(table.__\u003C\u003Ecolor).maxTextLength(36).addInputDialog();

    [Signature("(Larc/scene/ui/Button;Larc/func/Cons2<Larc/scene/ui/layout/Table;Ljava/lang/Runnable;>;)V")]
    [LineNumberTable(new byte[] {40, 241, 75, 172, 134, 237, 69, 103, 135, 107, 139, 244, 81, 159, 12, 188, 155, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void showSelectTable(Button b, Cons2 hideCons)
    {
      LStatement.\u0031.__\u003Cclinit\u003E();
      LStatement.\u0031 obj = new LStatement.\u0031(this, (Drawable) Tex.paneSolid);
      obj.margin(4f);
      Element actor = new Element();
      Runnable r = (Runnable) new LStatement.__\u003C\u003EAnon3(actor, (Table) obj);
      actor.fillParent = true;
      actor.tapped(r);
      Core.scene.add(actor);
      Core.scene.add((Element) obj);
      obj.update((Runnable) new LStatement.__\u003C\u003EAnon4(b, actor, (Table) obj));
      obj.actions((arc.scene.Action) Actions.alpha(0.0f), (arc.scene.Action) Actions.fadeIn(0.3f, Interp.fade));
      ((ScrollPane) obj.top().pane((Cons) new LStatement.__\u003C\u003EAnon5(hideCons, r)).pad(0.0f).top().get()).setScrollingDisabled(true, false);
      obj.pack();
    }

    [Signature("<T:Ljava/lang/Enum<TT;>;>(Larc/scene/ui/Button;[TT;TT;Larc/func/Cons<TT;>;ILarc/func/Cons<Larc/scene/ui/layout/Cell;>;)V")]
    [LineNumberTable(new byte[] {19, 249, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void showSelect(
      Button b,
      Enum[] values,
      Enum current,
      Cons getter,
      int cols,
      Cons sizer)
    {
      this.showSelectTable(b, (Cons2) new LStatement.__\u003C\u003EAnon1(values, sizer, getter, current, cols));
    }

    [Signature("(Larc/scene/ui/layout/Cell<Larc/scene/ui/Label;>;)V")]
    [LineNumberTable(new byte[] {159, 186, 127, 32, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void param(Cell label)
    {
      string key = new StringBuilder().append(this.name()).append(".").append(String.instancehelper_trim(((Label) label.get()).getText().toString())).toString();
      LCanvas.tooltip(label, key);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {20, 102, 98, 151, 118, 191, 16, 254, 61, 229, 69, 251, 58, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showSelect\u00242(
      [In] Enum[] obj0,
      [In] Cons obj1,
      [In] Cons obj2,
      [In] Enum obj3,
      [In] int obj4,
      [In] Table obj5,
      [In] Runnable obj6)
    {
      ButtonGroup group = new ButtonGroup();
      int num1 = 0;
      obj5.defaults().size(60f, 38f);
      Enum[] enumArray = obj0;
      int length = enumArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Enum @enum = enumArray[index];
        obj1.get((object) obj5.button(@enum.toString(), Styles.logicTogglet, (Runnable) new LStatement.__\u003C\u003EAnon8(obj2, @enum, obj6)).self((Cons) new LStatement.__\u003C\u003EAnon9(@enum)).@checked(object.ReferenceEquals((object) obj3, (object) @enum)).group(group));
        ++num1;
        int num2 = num1;
        int num3 = obj4;
        if ((num3 != -1 ? num2 % num3 : 0) == 0)
          obj5.row();
      }
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showSelect\u00243([In] Cell obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {57, 124, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showSelectTable\u00244([In] Element obj0, [In] Table obj1)
    {
      Application app = Core.app;
      Element element = obj0;
      Objects.requireNonNull((object) element);
      Runnable r = (Runnable) new LStatement.__\u003C\u003EAnon7(element);
      app.post(r);
      obj1.actions((arc.scene.Action) Actions.fadeOut(0.3f, Interp.fade), (arc.scene.Action) Actions.remove());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {68, 122, 214, 161, 127, 14, 123, 127, 6, 127, 6, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showSelectTable\u00246([In] Button obj0, [In] Element obj1, [In] Table obj2)
    {
      if (obj0.parent == null || !obj0.isDescendantOf((Element) Core.scene.__\u003C\u003Eroot))
      {
        Core.app.post((Runnable) new LStatement.__\u003C\u003EAnon6(obj1, obj2));
      }
      else
      {
        obj0.localToStageCoordinates(Tmp.__\u003C\u003Ev1.set(obj0.getWidth() / 2f, obj0.getHeight() / 2f));
        obj2.setPosition(Tmp.__\u003C\u003Ev1.x, Tmp.__\u003C\u003Ev1.y, 1);
        if ((double) obj2.getWidth() > (double) Core.scene.getWidth())
          obj2.setWidth((float) Core.graphics.getWidth());
        if ((double) obj2.getHeight() > (double) Core.scene.getHeight())
          obj2.setHeight((float) Core.graphics.getHeight());
        obj2.keepInStage();
        obj2.invalidateHierarchy();
        obj2.pack();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {87, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showSelectTable\u00247([In] Cons2 obj0, [In] Runnable obj1, [In] Table obj2)
    {
      obj2.top();
      obj0.get((object) obj2, (object) obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {70, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showSelectTable\u00245([In] Element obj0, [In] Table obj1)
    {
      obj0.remove();
      obj1.remove();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {26, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showSelect\u00240([In] Cons obj0, [In] Enum obj1, [In] Runnable obj2)
    {
      obj0.get((object) obj1);
      obj2.run();
    }

    [Modifiers]
    [LineNumberTable(78)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showSelect\u00241([In] Enum obj0, [In] Cell obj1) => LCanvas.tooltip(obj1, obj0);

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LStatement()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hidden() => false;

    [Signature("(Larc/scene/ui/layout/Table;Ljava/lang/String;Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)Larc/scene/ui/layout/Cell<Larc/scene/ui/TextField;>;")]
    [LineNumberTable(new byte[] {4, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Cell fields(
      Table table,
      string desc,
      string value,
      Cons setter)
    {
      Table table1 = table;
      object obj = (object) desc;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table1.add(text).padLeft(10f).left().self((Cons) new LStatement.__\u003C\u003EAnon0(this));
      return this.field(table, value, setter).width(85f).padRight(10f).left();
    }

    [Signature("(Larc/scene/ui/layout/Table;Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {9, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void fields(Table table, string value, Cons setter) => this.field(table, value, setter).width(85f);

    [LineNumberTable(new byte[] {13, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void row(Table table)
    {
      if (!LCanvas.useRows())
        return;
      table.row();
    }

    [Signature("<T:Ljava/lang/Enum<TT;>;>(Larc/scene/ui/Button;[TT;TT;Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {36, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void showSelect(Button b, Enum[] values, Enum current, Cons getter) => this.showSelect(b, values, current, getter, 4, (Cons) new LStatement.__\u003C\u003EAnon2());

    [EnclosingMethod(null, "showSelectTable", "(Larc.scene.ui.Button;Larc.func.Cons2;)V")]
    [SpecialName]
    internal class \u0031 : Table
    {
      [Modifiers]
      internal LStatement this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(90)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] LStatement obj0, [In] Drawable obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
      }

      [LineNumberTable(93)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getPrefHeight() => Math.min(base.getPrefHeight(), (float) Core.graphics.getHeight());

      [LineNumberTable(98)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getPrefWidth() => Math.min(base.getPrefWidth(), (float) Core.graphics.getWidth());

      [HideFromJava]
      static \u0031() => Table.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly LStatement arg\u00241;

      internal __\u003C\u003EAnon0([In] LStatement obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.param((Cell) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons2
    {
      private readonly Enum[] arg\u00241;
      private readonly Cons arg\u00242;
      private readonly Cons arg\u00243;
      private readonly Enum arg\u00244;
      private readonly int arg\u00245;

      internal __\u003C\u003EAnon1([In] Enum[] obj0, [In] Cons obj1, [In] Cons obj2, [In] Enum obj3, [In] int obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] object obj0, [In] object obj1) => LStatement.lambda\u0024showSelect\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, (Table) obj0, (Runnable) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void get([In] object obj0) => LStatement.lambda\u0024showSelect\u00243((Cell) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly Element arg\u00241;
      private readonly Table arg\u00242;

      internal __\u003C\u003EAnon3([In] Element obj0, [In] Table obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => LStatement.lambda\u0024showSelectTable\u00244(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly Button arg\u00241;
      private readonly Element arg\u00242;
      private readonly Table arg\u00243;

      internal __\u003C\u003EAnon4([In] Button obj0, [In] Element obj1, [In] Table obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => LStatement.lambda\u0024showSelectTable\u00246(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly Cons2 arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon5([In] Cons2 obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => LStatement.lambda\u0024showSelectTable\u00247(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly Element arg\u00241;
      private readonly Table arg\u00242;

      internal __\u003C\u003EAnon6([In] Element obj0, [In] Table obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => LStatement.lambda\u0024showSelectTable\u00245(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly Element arg\u00241;

      internal __\u003C\u003EAnon7([In] Element obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.remove();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly Cons arg\u00241;
      private readonly Enum arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon8([In] Cons obj0, [In] Enum obj1, [In] Runnable obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => LStatement.lambda\u0024showSelect\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly Enum arg\u00241;

      internal __\u003C\u003EAnon9([In] Enum obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => LStatement.lambda\u0024showSelect\u00241(this.arg\u00241, (Cell) obj0);
    }
  }
}
