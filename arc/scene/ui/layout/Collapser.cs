// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.layout.Collapser
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.scene.@event;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui.layout
{
  public class Collapser : WidgetGroup
  {
    internal Table table;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal Boolp collapsedFunc;
    private Collapser.CollapseAction collapseAction;
    internal bool collapsed;
    internal bool autoAnimate;
    internal bool actionRunning;
    internal float currentHeight;
    internal float seconds;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;Z)V")]
    [LineNumberTable(new byte[] {159, 138, 162, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Collapser(Cons cons, bool collapsed)
      : this(new Table(), collapsed)
    {
      Collapser collapser = this;
      cons.get((object) this.table);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Collapser setCollapsed(bool autoAnimate, Boolp collapsed)
    {
      int num = autoAnimate ? 1 : 0;
      this.collapsedFunc = collapsed;
      this.autoAnimate = num != 0;
      return this;
    }

    [LineNumberTable(new byte[] {159, 137, 162, 232, 53, 204, 235, 72, 103, 103, 135, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Collapser(Table table, bool collapsed)
    {
      int num = collapsed ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Collapser collapser = this;
      this.collapseAction = new Collapser.CollapseAction(this);
      this.seconds = 0.4f;
      this.table = table;
      this.collapsed = num != 0;
      this.setTransform(true);
      this.updateTouchable();
      this.addChild((Element) table);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCollapsed() => this.collapsed;

    [LineNumberTable(new byte[] {159, 191, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggle() => this.setCollapsed(!this.isCollapsed());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Collapser setDuration(float seconds)
    {
      this.seconds = seconds;
      return this;
    }

    [LineNumberTable(new byte[] {159, 129, 98, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggle(bool animated)
    {
      int num = animated ? 1 : 0;
      this.setCollapsed(!this.isCollapsed(), num != 0);
    }

    [LineNumberTable(new byte[] {39, 117, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateTouchable() => this.touchable = !this.collapsed ? Touchable.__\u003C\u003Eenabled : Touchable.__\u003C\u003Edisabled;

    [LineNumberTable(new byte[] {159, 122, 98, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCollapsed(bool collapse) => this.setCollapsed(collapse, true);

    [LineNumberTable(new byte[] {159, 128, 100, 103, 134, 137, 135, 99, 142, 99, 107, 137, 114, 167, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCollapsed(bool collapse, bool withAnimation)
    {
      int num1 = collapse ? 1 : 0;
      int num2 = withAnimation ? 1 : 0;
      this.collapsed = num1 != 0;
      this.updateTouchable();
      if (this.table == null)
        return;
      this.actionRunning = true;
      if (num2 != 0)
      {
        this.addAction((Action) this.collapseAction);
      }
      else
      {
        if (num1 != 0)
        {
          this.currentHeight = 0.0f;
          this.collapsed = true;
        }
        else
        {
          this.currentHeight = this.table.getPrefHeight();
          this.collapsed = false;
        }
        this.actionRunning = false;
        this.invalidateHierarchy();
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Collapser setCollapsed(Boolp collapsed)
    {
      this.collapsedFunc = collapsed;
      return this;
    }

    [LineNumberTable(new byte[] {45, 109, 101, 127, 2, 102, 101, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      if ((double) this.currentHeight <= 1.0)
        return;
      Draw.flush();
      if (!this.clipBegin(this.x, this.y, this.getWidth(), this.currentHeight))
        return;
      base.draw();
      Draw.flush();
      this.clipEnd();
    }

    [LineNumberTable(new byte[] {57, 136, 104, 108, 105, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      if (this.collapsedFunc == null)
        return;
      int num = this.collapsedFunc.get() ? 1 : 0;
      if (num == (this.collapsed ? 1 : 0))
        return;
      this.setCollapsed(num != 0, this.autoAnimate);
    }

    [LineNumberTable(new byte[] {69, 137, 159, 4, 104, 104, 141, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
      if (this.table == null)
        return;
      this.table.setBounds(0.0f, 0.0f, this.getWidth(), this.getHeight());
      if (this.actionRunning)
        return;
      if (this.collapsed)
        this.currentHeight = 0.0f;
      else
        this.currentHeight = this.table.getPrefHeight();
    }

    [LineNumberTable(133)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth() => this.table == null ? 0.0f : this.table.getPrefWidth();

    [LineNumberTable(new byte[] {88, 142, 104, 104, 134, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      if (this.table == null)
        return 0.0f;
      if (this.actionRunning)
        return this.currentHeight;
      return this.collapsed ? 0.0f : this.table.getPrefHeight();
    }

    [LineNumberTable(new byte[] {101, 103, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTable(Table table)
    {
      this.table = table;
      this.clearChildren();
      this.addChild((Element) table);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinWidth() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinHeight() => 0.0f;

    [LineNumberTable(new byte[] {118, 102, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void childrenChanged()
    {
      base.childrenChanged();
      if (this.getChildren().size > 1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Only one actor can be added to CollapsibleWidget");
      }
    }

    [HideFromJava]
    static Collapser() => WidgetGroup.__\u003Cclinit\u003E();

    [InnerClass]
    internal class CollapseAction : Action
    {
      [Modifiers]
      internal Collapser this\u00240;

      [LineNumberTable(new byte[] {123, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal CollapseAction([In] Collapser obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 64, 109, 127, 22, 117, 112, 177, 127, 22, 126, 124, 204, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool act([In] float obj0)
      {
        if (this.this\u00240.collapsed)
        {
          this.this\u00240.currentHeight -= obj0 * this.this\u00240.table.getPrefHeight() / this.this\u00240.seconds;
          if ((double) this.this\u00240.currentHeight <= 0.0)
          {
            this.this\u00240.currentHeight = 0.0f;
            this.this\u00240.actionRunning = false;
          }
        }
        else
        {
          this.this\u00240.currentHeight += obj0 * this.this\u00240.table.getPrefHeight() / this.this\u00240.seconds;
          if ((double) this.this\u00240.currentHeight > (double) this.this\u00240.table.getPrefHeight())
          {
            this.this\u00240.currentHeight = this.this\u00240.table.getPrefHeight();
            this.this\u00240.actionRunning = false;
          }
        }
        this.this\u00240.invalidateHierarchy();
        return !this.this\u00240.actionRunning;
      }
    }
  }
}
