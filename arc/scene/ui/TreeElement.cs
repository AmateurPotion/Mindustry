// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.TreeElement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics;
using arc.graphics.g2d;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.scene.utils;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class TreeElement : WidgetGroup
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;")]
    internal Seq rootNodes;
    [Modifiers]
    [Signature("Larc/scene/utils/Selection<Larc/scene/ui/TreeElement$TreeElementNode;>;")]
    internal Selection selection;
    internal TreeElement.TreeStyle style;
    internal float ySpacing;
    internal float iconSpacingLeft;
    internal float iconSpacingRight;
    internal float padding;
    internal float indentSpacing;
    internal TreeElement.TreeElementNode overNode;
    internal TreeElement.TreeElementNode rangeStart;
    private float leftColumnWidth;
    private float prefWidth;
    private float prefHeight;
    private bool sizeInvalid;
    private TreeElement.TreeElementNode foundNode;
    private ClickListener clickListener;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 183, 232, 50, 171, 191, 13, 231, 73, 236, 77, 108, 108, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TreeElement(TreeElement.TreeStyle style)
    {
      TreeElement treeElement = this;
      this.rootNodes = new Seq();
      this.ySpacing = 4f;
      this.iconSpacingLeft = 2f;
      this.iconSpacingRight = 2f;
      this.padding = 0.0f;
      this.sizeInvalid = true;
      this.selection = (Selection) new TreeElement.\u0031(this);
      this.selection.setActor((Element) this);
      this.selection.setMultiple(true);
      this.setStyle(style);
      this.initialize();
    }

    [LineNumberTable(new byte[] {160, 225, 103, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStyle(TreeElement.TreeStyle style)
    {
      this.style = style;
      this.indentSpacing = Math.max(style.plus.getMinWidth(), style.minus.getMinWidth()) + this.iconSpacingLeft;
    }

    [LineNumberTable(new byte[] {47, 248, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initialize()
    {
      TreeElement treeElement = this;
      TreeElement.\u0032 obj1 = new TreeElement.\u0032(this);
      TreeElement.\u0032 obj2 = obj1;
      this.clickListener = (ClickListener) obj1;
      this.addListener((EventListener) obj2);
    }

    [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;Larc/struct/Seq<Ljava/lang/Object;>;)Z")]
    [LineNumberTable(new byte[] {12, 98, 109, 109, 31, 3, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool findExpandedObjects([In] Seq obj0, [In] Seq obj1)
    {
      int num = 0;
      int index = 0;
      for (int size = obj0.size; index < size; ++index)
      {
        TreeElement.TreeElementNode treeElementNode = (TreeElement.TreeElementNode) obj0.get(index);
        if (treeElementNode.expanded && !TreeElement.findExpandedObjects(treeElementNode.children, obj1))
          obj1.add(treeElementNode.@object);
      }
      return num != 0;
    }

    [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;Ljava/lang/Object;)Larc/scene/ui/TreeElement$TreeElementNode;")]
    [LineNumberTable(new byte[] {21, 109, 109, 16, 198, 109, 109, 109, 229, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static TreeElement.TreeElementNode findNode([In] Seq obj0, [In] object obj1)
    {
      int index1 = 0;
      for (int size = obj0.size; index1 < size; ++index1)
      {
        TreeElement.TreeElementNode treeElementNode = (TreeElement.TreeElementNode) obj0.get(index1);
        if (Object.instancehelper_equals(obj1, treeElementNode.@object))
          return treeElementNode;
      }
      int index2 = 0;
      for (int size = obj0.size; index2 < size; ++index2)
      {
        TreeElement.TreeElementNode node = TreeElement.findNode(((TreeElement.TreeElementNode) obj0.get(index2)).children, obj1);
        if (node != null)
          return node;
      }
      return (TreeElement.TreeElementNode) null;
    }

    [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;)V")]
    [LineNumberTable(new byte[] {34, 109, 109, 103, 235, 61, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void collapseAll([In] Seq obj0)
    {
      int index = 0;
      for (int size = obj0.size; index < size; ++index)
      {
        TreeElement.TreeElementNode treeElementNode = (TreeElement.TreeElementNode) obj0.get(index);
        treeElementNode.setExpanded(false);
        TreeElement.collapseAll(treeElementNode.children);
      }
    }

    [LineNumberTable(new byte[] {103, 103, 103, 109, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void insert(int index, TreeElement.TreeElementNode node)
    {
      this.remove(node);
      node.parent = (TreeElement.TreeElementNode) null;
      this.rootNodes.insert(index, (object) node);
      node.addToTree(this);
      this.invalidateHierarchy();
    }

    [LineNumberTable(new byte[] {111, 104, 108, 129, 110, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(TreeElement.TreeElementNode node)
    {
      if (node.parent != null)
      {
        node.parent.remove(node);
      }
      else
      {
        this.rootNodes.remove((object) node, true);
        node.removeFromTree(this);
        this.invalidateHierarchy();
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOverNode(TreeElement.TreeElementNode overNode) => this.overNode = overNode;

    [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;F)V")]
    [LineNumberTable(new byte[] {160, 88, 103, 111, 112, 110, 108, 105, 100, 110, 111, 137, 110, 143, 105, 118, 159, 2, 116, 120, 255, 1, 46, 233, 84})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computeSize([In] Seq obj0, [In] float obj1)
    {
      float ySpacing = this.ySpacing;
      float num1 = this.iconSpacingLeft + this.iconSpacingRight;
      int index = 0;
      for (int size = obj0.size; index < size; ++index)
      {
        TreeElement.TreeElementNode treeElementNode = (TreeElement.TreeElementNode) obj0.get(index);
        float num2 = obj1 + this.iconSpacingRight;
        Element element = treeElementNode.element;
        float num3;
        if (element != null)
        {
          num3 = num2 + element.getPrefWidth();
          treeElementNode.height = element.getPrefHeight();
          element.pack();
        }
        else
        {
          num3 = num2 + element.getWidth();
          treeElementNode.height = element.getHeight();
        }
        if (treeElementNode.icon != null)
        {
          num3 += num1 + treeElementNode.icon.getMinWidth();
          treeElementNode.height = Math.max(treeElementNode.height, treeElementNode.icon.getMinHeight());
        }
        this.prefWidth = Math.max(this.prefWidth, num3);
        this.prefHeight -= treeElementNode.height + ySpacing;
        if (treeElementNode.expanded)
          this.computeSize(treeElementNode.children, obj1 + this.indentSpacing);
      }
    }

    [LineNumberTable(new byte[] {160, 76, 103, 119, 127, 4, 109, 107, 114, 124, 124, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void computeSize()
    {
      this.sizeInvalid = false;
      this.prefWidth = this.style.plus.getMinWidth();
      this.prefWidth = Math.max(this.prefWidth, this.style.minus.getMinWidth());
      this.prefHeight = this.getHeight();
      this.leftColumnWidth = 0.0f;
      this.computeSize(this.rootNodes, this.indentSpacing);
      this.leftColumnWidth += this.iconSpacingLeft + this.padding;
      this.prefWidth += this.leftColumnWidth + this.padding;
      this.prefHeight = this.getHeight() - this.prefHeight;
    }

    [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;FF)F")]
    [LineNumberTable(new byte[] {160, 119, 103, 112, 109, 100, 122, 109, 111, 103, 255, 4, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float layout([In] Seq obj0, [In] float obj1, [In] float obj2)
    {
      float ySpacing = this.ySpacing;
      int index = 0;
      for (int size = obj0.size; index < size; ++index)
      {
        TreeElement.TreeElementNode treeElementNode = (TreeElement.TreeElementNode) obj0.get(index);
        float x = obj1;
        if (treeElementNode.icon != null)
          x += treeElementNode.icon.getMinWidth();
        obj2 -= treeElementNode.getHeight();
        treeElementNode.element.setPosition(x, obj2);
        obj2 -= ySpacing;
        if (treeElementNode.expanded)
          obj2 = this.layout(treeElementNode.children, obj1 + this.indentSpacing, obj2);
      }
      return obj2;
    }

    [LineNumberTable(new byte[] {160, 143, 109, 103, 127, 6, 159, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawBackground()
    {
      if (this.style.background == null)
        return;
      Color color = this.__\u003C\u003Ecolor;
      Draw.color(color.r, color.g, color.b, color.a * this.parentAlpha);
      this.style.background.draw(this.x, this.y, this.getWidth(), this.getHeight());
    }

    [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;F)V")]
    [LineNumberTable(new byte[] {160, 152, 120, 110, 116, 111, 137, 124, 127, 35, 124, 191, 33, 108, 127, 15, 108, 127, 26, 51, 133, 170, 147, 111, 127, 10, 127, 10, 255, 1, 41, 235, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void draw([In] Seq obj0, [In] float obj1)
    {
      Drawable plus = this.style.plus;
      Drawable minus = this.style.minus;
      float x = this.x;
      float y = this.y;
      int index = 0;
      for (int size = obj0.size; index < size; ++index)
      {
        TreeElement.TreeElementNode treeElementNode = (TreeElement.TreeElementNode) obj0.get(index);
        Element element = treeElementNode.element;
        if (this.selection.contains((object) treeElementNode) && this.style.selection != null)
          this.style.selection.draw(x, y + element.y - this.ySpacing / 2f, this.getWidth(), treeElementNode.height + this.ySpacing);
        else if (object.ReferenceEquals((object) treeElementNode, (object) this.overNode) && this.style.over != null)
          this.style.over.draw(x, y + element.y - this.ySpacing / 2f, this.getWidth(), treeElementNode.height + this.ySpacing);
        if (treeElementNode.icon != null)
        {
          float num = element.y + (float) Math.round((treeElementNode.height - treeElementNode.icon.getMinHeight()) / 2f);
          Draw.color(element.__\u003C\u003Ecolor);
          treeElementNode.icon.draw(x + treeElementNode.element.x - this.iconSpacingRight - treeElementNode.icon.getMinWidth(), y + num, treeElementNode.icon.getMinWidth(), treeElementNode.icon.getMinHeight());
          Draw.color(Color.__\u003C\u003Ewhite);
        }
        if (treeElementNode.children.size != 0)
        {
          Drawable drawable = !treeElementNode.expanded ? plus : minus;
          float num = element.y + (float) Math.round((treeElementNode.height - drawable.getMinHeight()) / 2f);
          drawable.draw(x + obj1 - this.iconSpacingLeft, y + num, drawable.getMinWidth(), drawable.getMinHeight());
          if (treeElementNode.expanded)
            this.draw(treeElementNode.children, obj1 + this.indentSpacing);
        }
      }
    }

    [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;FF)F")]
    [LineNumberTable(new byte[] {160, 189, 112, 109, 103, 112, 119, 103, 134, 111, 104, 115, 239, 53, 233, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float getNodeAt([In] Seq obj0, [In] float obj1, [In] float obj2)
    {
      int index = 0;
      for (int size = obj0.size; index < size; ++index)
      {
        TreeElement.TreeElementNode treeElementNode = (TreeElement.TreeElementNode) obj0.get(index);
        float height = treeElementNode.height;
        obj2 -= treeElementNode.getHeight() - height;
        if ((double) obj1 >= (double) (obj2 - height - this.ySpacing) && (double) obj1 < (double) obj2)
        {
          this.foundNode = treeElementNode;
          return -1f;
        }
        obj2 -= height + this.ySpacing;
        if (treeElementNode.expanded)
        {
          obj2 = this.getNodeAt(treeElementNode.children, obj1, obj2);
          if ((double) obj2 == -1.0)
            return -1f;
        }
      }
      return obj2;
    }

    [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;FF)V")]
    [LineNumberTable(new byte[] {160, 207, 112, 109, 113, 106, 123, 248, 59, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void selectNodes([In] Seq obj0, [In] float obj1, [In] float obj2)
    {
      int index = 0;
      for (int size = obj0.size; index < size; ++index)
      {
        TreeElement.TreeElementNode treeElementNode = (TreeElement.TreeElementNode) obj0.get(index);
        if ((double) treeElementNode.element.y < (double) obj1)
          break;
        if (treeElementNode.isSelectable())
        {
          if ((double) treeElementNode.element.y <= (double) obj2)
            this.selection.add((object) treeElementNode);
          if (treeElementNode.expanded)
            this.selectNodes(treeElementNode.children, obj1, obj2);
        }
      }
    }

    [LineNumberTable(new byte[] {161, 46, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TreeElement.TreeElementNode findNode(object @object)
    {
      if (@object == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("object cannot be null.");
      }
      return TreeElement.findNode(this.rootNodes, @object);
    }

    [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;)V")]
    [LineNumberTable(new byte[] {42, 109, 49, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void expandAll([In] Seq obj0)
    {
      int index = 0;
      for (int size = obj0.size; index < size; ++index)
        ((TreeElement.TreeElementNode) obj0.get(index)).expandAll();
    }

    [LineNumberTable(new byte[] {159, 180, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TreeElement()
      : this((TreeElement.TreeStyle) Core.scene.getStyle((Class) ClassLiteral<TreeElement.TreeStyle>.Value))
    {
    }

    [LineNumberTable(new byte[] {99, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(TreeElement.TreeElementNode node) => this.insert(this.rootNodes.size, node);

    [LineNumberTable(new byte[] {123, 102, 103, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clearChildren()
    {
      base.clearChildren();
      this.setOverNode((TreeElement.TreeElementNode) null);
      this.rootNodes.clear();
      this.selection.clear();
    }

    [Signature("()Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getNodes() => this.rootNodes;

    [LineNumberTable(new byte[] {160, 71, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void invalidate()
    {
      base.invalidate();
      this.sizeInvalid = true;
    }

    [LineNumberTable(new byte[] {160, 114, 110, 127, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void layout()
    {
      if (this.sizeInvalid)
        this.computeSize();
      double num = (double) this.layout(this.rootNodes, this.leftColumnWidth + this.indentSpacing + this.iconSpacingRight, this.getHeight() - this.ySpacing / 2f);
    }

    [LineNumberTable(new byte[] {160, 134, 102, 103, 127, 6, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.drawBackground();
      Color color = this.__\u003C\u003Ecolor;
      Draw.color(color.r, color.g, color.b, color.a * this.parentAlpha);
      this.draw(this.rootNodes, this.leftColumnWidth);
      base.draw();
    }

    [LineNumberTable(new byte[] {160, 183, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TreeElement.TreeElementNode getNodeAt(float y)
    {
      this.foundNode = (TreeElement.TreeElementNode) null;
      double nodeAt = (double) this.getNodeAt(this.rootNodes, y, this.getHeight());
      return this.foundNode;
    }

    [Signature("()Larc/scene/utils/Selection<Larc/scene/ui/TreeElement$TreeElementNode;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Selection getSelection() => this.selection;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TreeElement.TreeStyle getStyle() => this.style;

    [Signature("()Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getRootNodes() => this.rootNodes;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TreeElement.TreeElementNode getOverNode() => this.overNode;

    [LineNumberTable(new byte[] {160, 245, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getOverObject() => this.overNode == null ? (object) null : this.overNode.getObject();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPadding(float padding) => this.padding = padding;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getIndentSpacing() => this.indentSpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getYSpacing() => this.ySpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setYSpacing(float ySpacing) => this.ySpacing = ySpacing;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIconSpacing(float left, float right)
    {
      this.iconSpacingLeft = left;
      this.iconSpacingRight = right;
    }

    [LineNumberTable(new byte[] {161, 20, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefWidth()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.prefWidth;
    }

    [LineNumberTable(new byte[] {161, 26, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPrefHeight()
    {
      if (this.sizeInvalid)
        this.computeSize();
      return this.prefHeight;
    }

    [LineNumberTable(new byte[] {161, 31, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void findExpandedObjects(Seq objects) => TreeElement.findExpandedObjects(this.rootNodes, objects);

    [LineNumberTable(new byte[] {161, 35, 109, 110, 99, 103, 230, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void restoreExpandedObjects(Seq objects)
    {
      int index = 0;
      for (int size = objects.size; index < size; ++index)
      {
        TreeElement.TreeElementNode node = this.findNode(objects.get(index));
        if (node != null)
        {
          node.setExpanded(true);
          node.expandTo();
        }
      }
    }

    [LineNumberTable(new byte[] {161, 51, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void collapseAll() => TreeElement.collapseAll(this.rootNodes);

    [LineNumberTable(new byte[] {161, 55, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void expandAll() => TreeElement.expandAll(this.rootNodes);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ClickListener getClickListener() => this.clickListener;

    [HideFromJava]
    static TreeElement() => WidgetGroup.__\u003Cclinit\u003E();

    [Signature("Larc/scene/utils/Selection<Larc/scene/ui/TreeElement$TreeElementNode;>;")]
    [EnclosingMethod(null, "<init>", "(Larc.scene.ui.TreeElement$TreeStyle;)V")]
    [SpecialName]
    internal new class \u0031 : Selection
    {
      [Modifiers]
      internal TreeElement this\u00240;

      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] TreeElement obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 187, 151, 108, 130, 182})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void changed()
      {
        switch (this.size())
        {
          case 0:
            this.this\u00240.rangeStart = (TreeElement.TreeElementNode) null;
            break;
          case 1:
            this.this\u00240.rangeStart = (TreeElement.TreeElementNode) this.first();
            break;
        }
      }
    }

    [EnclosingMethod(null, "initialize", "()V")]
    [SpecialName]
    internal new class \u0032 : ClickListener
    {
      [Modifiers]
      internal TreeElement this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(97)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] TreeElement obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {50, 110, 100, 123, 159, 26, 121, 108, 124, 120, 100, 154, 120, 186, 113, 108, 129, 159, 16, 109, 127, 8, 102, 114, 161, 105, 113, 126})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void clicked([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        TreeElement.TreeElementNode nodeAt = this.this\u00240.getNodeAt(obj2);
        if (nodeAt == null || !object.ReferenceEquals((object) nodeAt, (object) this.this\u00240.getNodeAt(this.getTouchDownY())))
          return;
        if (this.this\u00240.selection.getMultiple() && this.this\u00240.selection.hasItems() && Core.input.shift())
        {
          if (this.this\u00240.rangeStart == null)
            this.this\u00240.rangeStart = nodeAt;
          TreeElement.TreeElementNode rangeStart = this.this\u00240.rangeStart;
          if (!Core.input.ctrl())
            this.this\u00240.selection.clear();
          float y1 = rangeStart.element.y;
          float y2 = nodeAt.element.y;
          if ((double) y1 > (double) y2)
          {
            this.this\u00240.selectNodes(this.this\u00240.rootNodes, y2, y1);
          }
          else
          {
            this.this\u00240.selectNodes(this.this\u00240.rootNodes, y1, y2);
            this.this\u00240.selection.items().orderedItems().reverse();
          }
          this.this\u00240.selection.fireChangeEvent();
          this.this\u00240.rangeStart = rangeStart;
        }
        else
        {
          if (nodeAt.children.size > 0 && (!this.this\u00240.selection.getMultiple() || !Core.input.ctrl()))
          {
            float x = nodeAt.element.x;
            if (nodeAt.icon != null)
              x -= this.this\u00240.iconSpacingRight + nodeAt.icon.getMinWidth();
            if ((double) obj1 < (double) x)
            {
              nodeAt.setExpanded(!nodeAt.expanded);
              return;
            }
          }
          if (!nodeAt.isSelectable())
            return;
          this.this\u00240.selection.choose((object) nodeAt);
          if (this.this\u00240.selection.isEmpty())
            return;
          this.this\u00240.rangeStart = nodeAt;
        }
      }

      [LineNumberTable(new byte[] {86, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool mouseMoved([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240.setOverNode(this.this\u00240.getNodeAt(obj2));
        return false;
      }

      [LineNumberTable(new byte[] {92, 111, 127, 0})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void exit([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] int obj3, [In] Element obj4)
      {
        base.exit(obj0, obj1, obj2, obj3, obj4);
        if (obj4 != null && obj4.isDescendantOf((Element) this.this\u00240))
          return;
        this.this\u00240.setOverNode((TreeElement.TreeElementNode) null);
      }

      [HideFromJava]
      static \u0032() => ClickListener.__\u003Cclinit\u003E();
    }

    public class TreeElementNode : Object
    {
      [Modifiers]
      internal Element element;
      [Modifiers]
      [Signature("Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;")]
      internal Seq children;
      internal TreeElement.TreeElementNode parent;
      internal bool selectable;
      internal bool expanded;
      internal Drawable icon;
      internal float height;
      internal object @object;

      [LineNumberTable(new byte[] {159, 12, 130, 106, 103, 110, 103, 100, 99, 114, 55, 168, 114, 55, 166, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setExpanded(bool expanded)
      {
        int num = expanded ? 1 : 0;
        if (num == (this.expanded ? 1 : 0))
          return;
        this.expanded = num != 0;
        if (this.children.size == 0)
          return;
        TreeElement tree = this.getTree();
        if (tree == null)
          return;
        if (num != 0)
        {
          int index = 0;
          for (int size = this.children.size; index < size; ++index)
            ((TreeElement.TreeElementNode) this.children.get(index)).addToTree(tree);
        }
        else
        {
          int index = 0;
          for (int size = this.children.size; index < size; ++index)
            ((TreeElement.TreeElementNode) this.children.get(index)).removeFromTree(tree);
        }
        tree.invalidateHierarchy();
      }

      [LineNumberTable(new byte[] {161, 228, 103, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void expandAll()
      {
        this.setExpanded(true);
        if (this.children.size <= 0)
          return;
        TreeElement.expandAll(this.children);
      }

      [LineNumberTable(new byte[] {161, 80, 108, 105, 114, 55, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void addToTree(TreeElement tree)
      {
        tree.addChild(this.element);
        if (!this.expanded)
          return;
        int index = 0;
        for (int size = this.children.size; index < size; ++index)
          ((TreeElement.TreeElementNode) this.children.get(index)).addToTree(tree);
      }

      [LineNumberTable(new byte[] {161, 119, 110, 105, 103, 100, 103, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove(TreeElement.TreeElementNode node)
      {
        this.children.remove((object) node, true);
        if (!this.expanded)
          return;
        TreeElement tree = this.getTree();
        if (tree == null)
          return;
        node.removeFromTree(tree);
        if (this.children.size != 0)
          return;
        this.expanded = false;
      }

      [LineNumberTable(new byte[] {161, 88, 109, 105, 108, 114, 46, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void removeFromTree(TreeElement tree)
      {
        tree.removeChild(this.element);
        if (!this.expanded)
          return;
        object[] items = this.children.items;
        int index = 0;
        for (int size = this.children.size; index < size; ++index)
          ((TreeElement.TreeElementNode) items[index]).removeFromTree(tree);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float getHeight() => this.height;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isSelectable() => this.selectable;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object getObject() => this.@object;

      [LineNumberTable(new byte[] {161, 234, 103, 99, 103, 137})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void expandTo()
      {
        for (TreeElement.TreeElementNode parent = this.parent; parent != null; parent = parent.parent)
          parent.setExpanded(true);
      }

      [LineNumberTable(new byte[] {161, 105, 103, 109, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void insert(int index, TreeElement.TreeElementNode node)
      {
        node.parent = this;
        this.children.insert(index, (object) node);
        this.updateChildren();
      }

      [LineNumberTable(new byte[] {161, 173, 105, 103, 100, 114, 55, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void updateChildren()
      {
        if (!this.expanded)
          return;
        TreeElement tree = this.getTree();
        if (tree == null)
          return;
        int index = 0;
        for (int size = this.children.size; index < size; ++index)
          ((TreeElement.TreeElementNode) this.children.get(index)).addToTree(tree);
      }

      [LineNumberTable(new byte[] {161, 138, 108, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual TreeElement getTree()
      {
        Group parent = this.element.parent;
        return !(parent is TreeElement) ? (TreeElement) null : (TreeElement) parent;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual TreeElement.TreeElementNode getParent() => this.parent;

      [LineNumberTable(new byte[] {161, 215, 115, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual TreeElement.TreeElementNode findNode(object @object)
      {
        if (@object == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("object cannot be null.");
        }
        return Object.instancehelper_equals(@object, this.@object) ? this : TreeElement.findNode(this.children, @object);
      }

      [LineNumberTable(new byte[] {161, 73, 232, 56, 140, 231, 71, 115, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TreeElementNode(Element element)
      {
        TreeElement.TreeElementNode treeElementNode = this;
        this.children = new Seq(0);
        this.selectable = true;
        if (element == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("element cannot be null.");
        }
        this.element = element;
      }

      [LineNumberTable(new byte[] {161, 96, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void add(TreeElement.TreeElementNode node) => this.insert(this.children.size, node);

      [Signature("(Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;)V")]
      [LineNumberTable(new byte[] {161, 100, 109, 61, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void addAll(Seq nodes)
      {
        int index = 0;
        for (int size = nodes.size; index < size; ++index)
          this.insert(this.children.size, (TreeElement.TreeElementNode) nodes.get(index));
      }

      [LineNumberTable(new byte[] {161, 111, 103, 99, 105, 104, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        TreeElement tree = this.getTree();
        if (tree != null)
        {
          tree.remove(this);
        }
        else
        {
          if (this.parent == null)
            return;
          this.parent.remove(this);
        }
      }

      [LineNumberTable(new byte[] {161, 128, 103, 99, 114, 55, 166, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void removeAll()
      {
        TreeElement tree = this.getTree();
        if (tree != null)
        {
          int index = 0;
          for (int size = this.children.size; index < size; ++index)
            ((TreeElement.TreeElementNode) this.children.get(index)).removeFromTree(tree);
        }
        this.children.clear();
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Element getActor() => this.element;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isExpanded() => this.expanded;

      [Signature("()Larc/struct/Seq<Larc/scene/ui/TreeElement$TreeElementNode;>;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Seq getChildren() => this.children;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setObject(object @object) => this.@object = @object;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Drawable getIcon() => this.icon;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setIcon(Drawable icon) => this.icon = icon;

      [LineNumberTable(new byte[] {161, 204, 98, 130, 100, 103, 99})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getLevel()
      {
        int num = 0;
        TreeElement.TreeElementNode treeElementNode = this;
        do
        {
          ++num;
          treeElementNode = treeElementNode.getParent();
        }
        while (treeElementNode != null);
        return num;
      }

      [LineNumberTable(new byte[] {161, 222, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void collapseAll()
      {
        this.setExpanded(false);
        TreeElement.collapseAll(this.children);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void setSelectable(bool selectable) => this.selectable = selectable;

      [Signature("(Larc/struct/Seq<Ljava/lang/Object;>;)V")]
      [LineNumberTable(new byte[] {161, 250, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void findExpandedObjects(Seq objects)
      {
        if (!this.expanded || TreeElement.findExpandedObjects(this.children, objects))
          return;
        objects.add(this.@object);
      }

      [LineNumberTable(new byte[] {161, 254, 109, 110, 99, 103, 230, 60, 230, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void restoreExpandedObjects(Seq objects)
      {
        int index = 0;
        for (int size = objects.size; index < size; ++index)
        {
          TreeElement.TreeElementNode node = this.findNode(objects.get(index));
          if (node != null)
          {
            node.setExpanded(true);
            node.expandTo();
          }
        }
      }
    }

    public class TreeStyle : Object
    {
      public Drawable plus;
      public Drawable minus;
      public Drawable over;
      public Drawable selection;
      public Drawable background;

      [LineNumberTable(new byte[] {162, 25, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TreeStyle()
      {
      }

      [LineNumberTable(new byte[] {162, 28, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TreeStyle(Drawable plus, Drawable minus, Drawable selection)
      {
        TreeElement.TreeStyle treeStyle = this;
        this.plus = plus;
        this.minus = minus;
        this.selection = selection;
      }

      [LineNumberTable(new byte[] {162, 34, 104, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TreeStyle(TreeElement.TreeStyle style)
      {
        TreeElement.TreeStyle treeStyle = this;
        this.plus = style.plus;
        this.minus = style.minus;
        this.selection = style.selection;
      }
    }
  }
}
