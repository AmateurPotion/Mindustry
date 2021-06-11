// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.layout.Stack
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.scene.@event;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.ui.layout
{
  public class Stack : WidgetGroup
  {
    private float prefWidth;
    private float prefHeight;
    private float minWidth;
    private float minHeight;
    private float maxWidth;
    private float maxHeight;
    private bool sizeInvalid;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 188, 8, 167, 103, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Stack()
    {
      Stack stack = this;
      this.sizeInvalid = true;
      this.setTransform(false);
      this.setWidth(150f);
      this.setHeight(150f);
      this.touchable = Touchable.__\u003C\u003EchildrenOnly;
    }

    [LineNumberTable(new byte[] {16, 103, 107, 107, 107, 107, 107, 107, 103, 112, 141, 102, 121, 121, 121, 121, 105, 142, 121, 121, 121, 121, 103, 135, 127, 15, 255, 15, 45, 233, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computeSize()
    {
      this.sizeInvalid = false;
      this.prefWidth = 0.0f;
      this.prefHeight = 0.0f;
      this.minWidth = 0.0f;
      this.minHeight = 0.0f;
      this.maxWidth = 0.0f;
      this.maxHeight = 0.0f;
      SnapshotSeq children = this.getChildren();
      int index = 0;
      for (int size = children.size; index < size; ++index)
      {
        Element element = (Element) children.get(index);
        float num1;
        float num2;
        if (element != null)
        {
          this.prefWidth = Math.max(this.prefWidth, element.getPrefWidth());
          this.prefHeight = Math.max(this.prefHeight, element.getPrefHeight());
          this.minWidth = Math.max(this.minWidth, element.getMinWidth());
          this.minHeight = Math.max(this.minHeight, element.getMinHeight());
          num1 = element.getMaxWidth();
          num2 = element.getMaxHeight();
        }
        else
        {
          this.prefWidth = Math.max(this.prefWidth, element.getWidth());
          this.prefHeight = Math.max(this.prefHeight, element.getHeight());
          this.minWidth = Math.max(this.minWidth, element.getWidth());
          this.minHeight = Math.max(this.minHeight, element.getHeight());
          num1 = 0.0f;
          num2 = 0.0f;
        }
        if ((double) num1 > 0.0)
          this.maxWidth = (double) this.maxWidth != 0.0 ? Math.min(this.maxWidth, num1) : num1;
        if ((double) num2 > 0.0)
          this.maxHeight = (double) this.maxHeight != 0.0 ? Math.min(this.maxHeight, num2) : num2;
      }
    }

    [LineNumberTable(new byte[] {4, 104, 112, 40, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Stack(params Element[] actors)
      : this()
    {
      Stack stack = this;
      Element[] elementArray = actors;
      int length = elementArray.Length;
      for (int index = 0; index < length; ++index)
        this.addChild(elementArray[index]);
    }

    [LineNumberTable(new byte[] {11, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void invalidate()
    {
      base.invalidate();
      this.sizeInvalid = true;
    }

    [LineNumberTable(new byte[] {48, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(Element actor) => this.addChild(actor);

    [LineNumberTable(new byte[] {53, 110, 112, 103, 111, 110, 115, 235, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
      if (this.sizeInvalid)
        this.computeSize();
      float width = this.getWidth();
      float height = this.getHeight();
      SnapshotSeq children = this.getChildren();
      int index = 0;
      for (int size = children.size; index < size; ++index)
      {
        Element element = (Element) children.get(index);
        element.setBounds(0.0f, 0.0f, width, height);
        element?.validate();
      }
    }

    [LineNumberTable(new byte[] {65, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.prefWidth;
    }

    [LineNumberTable(new byte[] {71, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.prefHeight;
    }

    [LineNumberTable(new byte[] {77, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinWidth()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.minWidth;
    }

    [LineNumberTable(new byte[] {83, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getMinHeight()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.minHeight;
    }

    [HideFromJava]
    static Stack() => WidgetGroup.__\u003Cclinit\u003E();
  }
}
