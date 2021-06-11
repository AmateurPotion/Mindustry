// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.layout.WidgetGroup
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui.layout
{
  public class WidgetGroup : Group
  {
    private bool needsLayout;
    private bool layoutEnabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setFillParent(bool fillParent) => this.fillParent = fillParent;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight() => 0.0f;

    [LineNumberTable(new byte[] {159, 128, 162, 103, 109, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setLayoutEnabled([In] Group obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      SnapshotSeq children = obj0.getChildren();
      int index = 0;
      for (int size = children.size; index < size; ++index)
        ((Element) children.get(index)).setLayoutEnabled(num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void invalidate() => this.needsLayout = true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
    }

    [LineNumberTable(new byte[] {49, 102, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void invalidateHierarchy()
    {
      this.invalidate();
      this.parent?.invalidateHierarchy();
    }

    [LineNumberTable(new byte[] {17, 137, 103, 107, 104, 136, 116, 103, 103, 198, 105, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void validate()
    {
      if (!this.layoutEnabled)
        return;
      Group parent = this.parent;
      if (this.fillParent && parent != null)
      {
        float width = parent.getWidth();
        float height = parent.getHeight();
        if ((double) this.getWidth() != (double) width || (double) this.getHeight() != (double) height)
        {
          this.setWidth(width);
          this.setHeight(height);
          this.invalidate();
        }
      }
      if (!this.needsLayout)
        return;
      this.needsLayout = false;
      this.layout();
    }

    [LineNumberTable(new byte[] {159, 164, 232, 61, 103, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WidgetGroup()
    {
      WidgetGroup widgetGroup = this;
      this.needsLayout = true;
      this.layoutEnabled = true;
    }

    [LineNumberTable(new byte[] {159, 168, 232, 57, 103, 231, 71, 112, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WidgetGroup(params Element[] actors)
    {
      WidgetGroup widgetGroup = this;
      this.needsLayout = true;
      this.layoutEnabled = true;
      Element[] elementArray = actors;
      int length = elementArray.Length;
      for (int index = 0; index < length; ++index)
        this.addChild(elementArray[index]);
    }

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinWidth() => this.getPrefWidth();

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinHeight() => this.getPrefHeight();

    [LineNumberTable(new byte[] {159, 129, 98, 106, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setLayoutEnabled(bool enabled)
    {
      int num = enabled ? 1 : 0;
      if ((this.layoutEnabled ? 1 : 0) == num)
        return;
      this.layoutEnabled = num != 0;
      this.setLayoutEnabled((Group) this, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool needsLayout() => this.needsLayout;

    [LineNumberTable(new byte[] {56, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void childrenChanged() => this.invalidateHierarchy();

    [LineNumberTable(new byte[] {61, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void sizeChanged() => this.invalidate();

    [LineNumberTable(new byte[] {66, 116, 166, 104, 116, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void pack()
    {
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
      this.validate();
      if (!this.needsLayout)
        return;
      this.setSize(this.getPrefWidth(), this.getPrefHeight());
      this.validate();
    }

    [LineNumberTable(new byte[] {91, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.validate();
      base.draw();
    }

    [HideFromJava]
    static WidgetGroup() => Group.__\u003Cclinit\u003E();
  }
}
