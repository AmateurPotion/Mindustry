// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.ResearchDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.@event;
using arc.scene.actions;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.core;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.input;
using mindustry.type;
using mindustry.ui.layout;
using mindustry.world.modules;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class ResearchDialog : BaseDialog
  {
    internal float __\u003C\u003EnodeSize;
    [Signature("Larc/struct/ObjectSet<Lmindustry/ui/dialogs/ResearchDialog$TechTreeNode;>;")]
    public ObjectSet nodes;
    public ResearchDialog.TechTreeNode root;
    public Rect bounds;
    public ItemsDisplay itemDisplay;
    public ResearchDialog.View view;
    public ItemSeq items;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 187, 237, 54, 113, 107, 114, 235, 73, 108, 118, 159, 31, 135, 241, 125, 159, 2, 134, 241, 70, 191, 11, 176, 237, 80, 139, 237, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ResearchDialog()
      : base("")
    {
      ResearchDialog researchDialog1 = this;
      this.__\u003C\u003EnodeSize = Scl.scl(60f);
      this.nodes = new ObjectSet();
      this.root = new ResearchDialog.TechTreeNode(this, TechTree.root, (ResearchDialog.TechTreeNode) null);
      this.bounds = new Rect();
      this.__\u003C\u003EtitleTable.remove();
      this.margin(0.0f).marginBottom(8f);
      Table cont = this.__\u003C\u003Econt;
      Element[] elementArray = new Element[2];
      ResearchDialog researchDialog2 = this;
      ResearchDialog.View view1 = new ResearchDialog.View(this);
      ResearchDialog.View view2 = view1;
      this.view = view1;
      elementArray[0] = (Element) view2;
      ResearchDialog researchDialog3 = this;
      ItemsDisplay itemsDisplay1 = new ItemsDisplay();
      ItemsDisplay itemsDisplay2 = itemsDisplay1;
      this.itemDisplay = itemsDisplay1;
      elementArray[1] = (Element) itemsDisplay2;
      cont.stack(elementArray).grow();
      this.shouldPause = true;
      this.shown((Runnable) new ResearchDialog.__\u003C\u003EAnon0(this));
      PlanetDialog planet = Vars.ui.planet;
      Objects.requireNonNull((object) planet);
      this.hidden((Runnable) new ResearchDialog.__\u003C\u003EAnon1(planet));
      this.addCloseButton();
      this.keyDown((Cons) new ResearchDialog.__\u003C\u003EAnon2(this));
      this.__\u003C\u003Ebuttons.button("@database", (Drawable) Icon.book, (Runnable) new ResearchDialog.__\u003C\u003EAnon3(this)).size(210f, 64f).name("database");
      this.addListener((EventListener) new ResearchDialog.\u0032(this));
      this.touchable = Touchable.__\u003C\u003Eenabled;
      this.addCaptureListener((EventListener) new ResearchDialog.\u0033(this));
    }

    [LineNumberTable(new byte[] {160, 104, 111, 112, 31, 11, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void shift([In] ResearchDialog.LayoutNode[] obj0, [In] float obj1)
    {
      ResearchDialog.LayoutNode[] layoutNodeArray = obj0;
      int length = layoutNodeArray.Length;
      for (int index = 0; index < length; ++index)
      {
        ResearchDialog.LayoutNode layoutNode = layoutNodeArray[index];
        layoutNode.y += obj1;
        if (layoutNode.children != null && ((ResearchDialog.LayoutNode[]) layoutNode.children).Length > 0)
          this.shift((ResearchDialog.LayoutNode[]) layoutNode.children, obj1);
      }
    }

    [LineNumberTable(new byte[] {160, 111, 113, 113, 104, 121, 39, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void copyInfo([In] ResearchDialog.LayoutNode obj0)
    {
      obj0.node.x = obj0.x;
      obj0.node.y = obj0.y;
      if (obj0.children == null)
        return;
      ResearchDialog.LayoutNode[] children = (ResearchDialog.LayoutNode[]) obj0.children;
      int length = children.Length;
      for (int index = 0; index < length; ++index)
        this.copyInfo(children[index]);
    }

    [LineNumberTable(251)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool locked([In] TechTree.TechNode obj0) => obj0.content.locked();

    [LineNumberTable(247)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool selectable([In] TechTree.TechNode obj0) => obj0.content.unlocked() || !obj0.objectives.contains((Boolf) new ResearchDialog.__\u003C\u003EAnon4());

    [LineNumberTable(new byte[] {160, 121, 109, 106, 114, 122, 110, 8, 230, 69, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void checkNodes([In] ResearchDialog.TechTreeNode obj0)
    {
      int num = this.locked(obj0.__\u003C\u003Enode) ? 1 : 0;
      if (num == 0)
        obj0.visible = true;
      obj0.selectable = this.selectable(obj0.__\u003C\u003Enode);
      ResearchDialog.TechTreeNode[] children = (ResearchDialog.TechTreeNode[]) obj0.children;
      int length = children.Length;
      for (int index = 0; index < length; ++index)
      {
        ResearchDialog.TechTreeNode techTreeNode = children[index];
        techTreeNode.visible = num == 0;
        this.checkNodes(techTreeNode);
      }
      this.itemDisplay.rebuild(this.items);
    }

    [LineNumberTable(new byte[] {126, 102, 110, 108, 127, 17, 159, 29, 103, 168, 133, 136, 134, 104, 168, 133, 177, 135, 124, 135, 127, 8, 107, 127, 2, 127, 2, 127, 2, 127, 2, 101, 123, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void treeLayout()
    {
      float num1 = 20f;
      ResearchDialog.LayoutNode layoutNode = new ResearchDialog.LayoutNode(this, this.root, (ResearchDialog.LayoutNode) null);
      ResearchDialog.LayoutNode[] children = (ResearchDialog.LayoutNode[]) layoutNode.children;
      ResearchDialog.LayoutNode[] layoutNodeArray1 = (ResearchDialog.LayoutNode[]) Arrays.copyOfRange((object[]) layoutNode.children, 0, Mathf.ceil((float) ((ResearchDialog.LayoutNode[]) layoutNode.children).Length / 2f));
      ResearchDialog.LayoutNode[] layoutNodeArray2 = (ResearchDialog.LayoutNode[]) Arrays.copyOfRange((object[]) layoutNode.children, Mathf.ceil((float) ((ResearchDialog.LayoutNode[]) layoutNode.children).Length / 2f), ((ResearchDialog.LayoutNode[]) layoutNode.children).Length);
      layoutNode.children = (TreeLayout.TreeNode[]) layoutNodeArray1;
      new ResearchDialog.\u0034(this, num1).layout((TreeLayout.TreeNode) layoutNode);
      float y1 = layoutNode.y;
      if (layoutNodeArray2.Length > 0)
      {
        layoutNode.children = (TreeLayout.TreeNode[]) layoutNodeArray2;
        new ResearchDialog.\u0035(this, num1).layout((TreeLayout.TreeNode) layoutNode);
        this.shift(layoutNodeArray1, layoutNode.y - y1);
      }
      layoutNode.children = (TreeLayout.TreeNode[]) children;
      float x = 0.0f;
      float y2 = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      this.copyInfo(layoutNode);
      ObjectSet.ObjectSetIterator objectSetIterator = this.nodes.iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        ResearchDialog.TechTreeNode techTreeNode = (ResearchDialog.TechTreeNode) ((Iterator) objectSetIterator).next();
        if (techTreeNode.visible)
        {
          x = Math.min(techTreeNode.x - techTreeNode.width / 2f, x);
          num2 = Math.max(techTreeNode.x + techTreeNode.width / 2f, num2);
          y2 = Math.min(techTreeNode.y - techTreeNode.height / 2f, y2);
          num3 = Math.max(techTreeNode.y + techTreeNode.height / 2f, num3);
        }
      }
      this.bounds = new Rect(x, y2, num2 - x, num3 - y2);
      this.bounds.y += this.__\u003C\u003EnodeSize * 1.5f;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {5, 236, 118, 108, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      this.items = (ItemSeq) new ResearchDialog.\u0031(this);
      this.checkNodes(this.root);
      this.treeLayout();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {69, 124, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] KeyCode obj0)
    {
      if (!object.ReferenceEquals((object) obj0, (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Eresearch).key))
        return;
      Core.app.post((Runnable) new ResearchDialog.__\u003C\u003EAnon5(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {75, 102, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242()
    {
      this.hide();
      Vars.ui.database.show();
    }

    [Modifiers]
    [LineNumberTable(247)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024selectable\u00243([In] Objectives.Objective obj0) => !obj0.complete();

    [HideFromJava]
    static ResearchDialog() => BaseDialog.__\u003Cclinit\u003E();

    [Modifiers]
    public float nodeSize
    {
      [HideFromJava] get => this.__\u003C\u003EnodeSize;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EnodeSize = value;
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal new class \u0031 : ItemSeq
    {
      [Signature("Larc/struct/ObjectMap<Lmindustry/type/Sector;Lmindustry/type/ItemSeq;>;")]
      internal ObjectMap cache;
      [Modifiers]
      internal ResearchDialog this\u00240;

      [Modifiers]
      [LineNumberTable(new byte[] {17, 124, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00240([In] Item obj0, [In] int obj1)
      {
        int[] values = this.__\u003C\u003Evalues;
        int id = (int) obj0.__\u003C\u003Eid;
        int[] numArray = values;
        numArray[id] = numArray[id] + Math.max(obj1, 0);
        this.total += Math.max(obj1, 0);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {39, 166, 191, 2, 104, 137, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024add\u00241(
        [In] int[] obj0,
        [In] double obj1,
        [In] Item obj2,
        [In] Sector obj3,
        [In] ItemSeq obj4)
      {
        if (obj0[0] == 0)
          return;
        int amount = Math.min(ByteCodeHelper.d2i(Math.ceil(obj1 * (double) obj4.get(obj2))), obj0[0]);
        obj3.removeItem(obj2, amount);
        obj4.remove(obj2, amount);
        int[] numArray1 = obj0;
        int index = 0;
        int[] numArray2 = numArray1;
        numArray2[index] = numArray2[index] - amount;
      }

      [LineNumberTable(new byte[] {5, 143, 203, 127, 8, 127, 2, 114, 105, 112, 242, 69, 98, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ResearchDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ResearchDialog.\u0031 obj = this;
        this.cache = new ObjectMap();
        Iterator iterator1 = Vars.content.planets().iterator();
label_1:
        while (iterator1.hasNext())
        {
          Iterator iterator2 = ((Planet) iterator1.next()).sectors.iterator();
          while (true)
          {
            Sector sector;
            do
            {
              if (iterator2.hasNext())
                sector = (Sector) iterator2.next();
              else
                goto label_1;
            }
            while (!sector.hasSave() || !sector.hasBase());
            ItemSeq itemSeq = sector.items();
            this.cache.put((object) sector, (object) itemSeq);
            itemSeq.each((ItemModule.ItemConsumer) new ResearchDialog.\u0031.__\u003C\u003EAnon0(this));
          }
        }
      }

      [LineNumberTable(new byte[] {29, 196, 164, 110, 107, 248, 78, 164, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void add([In] Item obj0, [In] int obj1)
      {
        if (obj1 < 0)
        {
          obj1 = -obj1;
          double num = (double) obj1 / (double) this.get(obj0);
          this.cache.each((Cons2) new ResearchDialog.\u0031.__\u003C\u003EAnon1(new int[1]
          {
            obj1
          }, num, obj0));
          obj1 = -obj1;
        }
        base.add(obj0, obj1);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : ItemModule.ItemConsumer
      {
        private readonly ResearchDialog.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] ResearchDialog.\u0031 obj0) => this.arg\u00241 = obj0;

        public void accept([In] Item obj0, [In] int obj1) => this.arg\u00241.lambda\u0024new\u00240(obj0, obj1);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Cons2
      {
        private readonly int[] arg\u00241;
        private readonly double arg\u00242;
        private readonly Item arg\u00243;

        internal __\u003C\u003EAnon1([In] int[] obj0, [In] double obj1, [In] Item obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void get([In] object obj0, [In] object obj1) => ResearchDialog.\u0031.lambda\u0024add\u00241(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Sector) obj0, (ItemSeq) obj1);
      }
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal new class \u0032 : InputListener
    {
      [Modifiers]
      internal ResearchDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(130)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] ResearchDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {83, 127, 47, 113, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool scrolled(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4)
      {
        this.this\u00240.view.setScale(Mathf.clamp(this.this\u00240.view.scaleX - obj4 / 10f * this.this\u00240.view.scaleX, 0.25f, 1f));
        this.this\u00240.view.setOrigin(1);
        this.this\u00240.view.setTransform(true);
        return true;
      }

      [LineNumberTable(new byte[] {91, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool mouseMoved([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        this.this\u00240.view.requestScroll();
        return base.mouseMoved(obj0, obj1, obj2);
      }

      [HideFromJava]
      static \u0032() => InputListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal new class \u0033 : ElementGestureListener
    {
      [Modifiers]
      internal ResearchDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(148)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] ResearchDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {101, 119, 191, 1, 127, 25, 113, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void zoom([In] InputEvent obj0, [In] float obj1, [In] float obj2)
      {
        if ((double) this.this\u00240.view.lastZoom < 0.0)
          this.this\u00240.view.lastZoom = this.this\u00240.view.scaleX;
        this.this\u00240.view.setScale(Mathf.clamp(obj2 / obj1 * this.this\u00240.view.lastZoom, 0.25f, 1f));
        this.this\u00240.view.setOrigin(1);
        this.this\u00240.view.setTransform(true);
      }

      [LineNumberTable(new byte[] {112, 127, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.this\u00240.view.lastZoom = this.this\u00240.view.scaleX;
      }

      [LineNumberTable(new byte[] {117, 127, 14, 127, 14, 113, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void pan([In] InputEvent obj0, [In] float obj1, [In] float obj2, [In] float obj3, [In] float obj4)
      {
        this.this\u00240.view.panX += obj3 / this.this\u00240.view.scaleX;
        this.this\u00240.view.panY += obj4 / this.this\u00240.view.scaleY;
        this.this\u00240.view.moved = true;
        this.this\u00240.view.clamp();
      }

      [HideFromJava]
      static \u0033() => ElementGestureListener.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "treeLayout", "()V")]
    [SpecialName]
    internal new class \u0034 : BranchTreeLayout
    {
      [Modifiers]
      internal float val\u0024spacing;
      [Modifiers]
      internal ResearchDialog this\u00240;

      [LineNumberTable(new byte[] {160, 69, 119, 119, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034([In] ResearchDialog obj0, [In] float obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024spacing = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ResearchDialog.\u0034 obj2 = this;
        ResearchDialog.\u0034 obj3 = this;
        float valSpacing = this.val\u0024spacing;
        double num = (double) valSpacing;
        this.gapBetweenNodes = valSpacing;
        this.gapBetweenLevels = (float) num;
        this.rootLocation = BranchTreeLayout.TreeLocation.__\u003C\u003Etop;
      }
    }

    [EnclosingMethod(null, "treeLayout", "()V")]
    [SpecialName]
    internal new class \u0035 : BranchTreeLayout
    {
      [Modifiers]
      internal float val\u0024spacing;
      [Modifiers]
      internal ResearchDialog this\u00240;

      [LineNumberTable(new byte[] {160, 79, 119, 119, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035([In] ResearchDialog obj0, [In] float obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024spacing = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ResearchDialog.\u0035 obj2 = this;
        ResearchDialog.\u0035 obj3 = this;
        float valSpacing = this.val\u0024spacing;
        double num = (double) valSpacing;
        this.gapBetweenNodes = valSpacing;
        this.gapBetweenLevels = (float) num;
        this.rootLocation = BranchTreeLayout.TreeLocation.__\u003C\u003Ebottom;
      }
    }

    [Signature("Lmindustry/ui/layout/TreeLayout$TreeNode<Lmindustry/ui/dialogs/ResearchDialog$LayoutNode;>;")]
    internal class LayoutNode : TreeLayout.TreeNode
    {
      [Modifiers]
      internal ResearchDialog.TechTreeNode node;
      [Modifiers]
      internal ResearchDialog this\u00240;

      [LineNumberTable(new byte[] {160, 143, 111, 103, 103, 119, 104, 159, 22})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal LayoutNode(
        [In] ResearchDialog obj0,
        [In] ResearchDialog.TechTreeNode obj1,
        [In] ResearchDialog.LayoutNode obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ResearchDialog.LayoutNode layoutNode1 = this;
        this.node = obj1;
        this.parent = (TreeLayout.TreeNode) obj2;
        ResearchDialog.LayoutNode layoutNode2 = this;
        float nodeSize = obj0.__\u003C\u003EnodeSize;
        double num = (double) nodeSize;
        this.height = nodeSize;
        this.width = (float) num;
        if (obj1.children == null)
          return;
        this.children = (TreeLayout.TreeNode[]) Seq.with((object[]) obj1.children).map((Func) new ResearchDialog.LayoutNode.__\u003C\u003EAnon0(this)).toArray((Class) ClassLiteral<ResearchDialog.LayoutNode>.Value);
      }

      [Modifiers]
      [LineNumberTable(262)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ResearchDialog.LayoutNode lambda\u0024new\u00240(
        [In] ResearchDialog.TechTreeNode obj0)
      {
        return new ResearchDialog.LayoutNode(this.this\u00240, obj0, this);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Func
      {
        private readonly ResearchDialog.LayoutNode arg\u00241;

        internal __\u003C\u003EAnon0([In] ResearchDialog.LayoutNode obj0) => this.arg\u00241 = obj0;

        public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024new\u00240((ResearchDialog.TechTreeNode) obj0);
      }
    }

    [Signature("Lmindustry/ui/layout/TreeLayout$TreeNode<Lmindustry/ui/dialogs/ResearchDialog$TechTreeNode;>;")]
    public class TechTreeNode : TreeLayout.TreeNode
    {
      internal TechTree.TechNode __\u003C\u003Enode;
      public bool visible;
      public bool selectable;
      [Modifiers]
      internal ResearchDialog this\u00240;

      [LineNumberTable(new byte[] {160, 157, 15, 174, 103, 103, 119, 109, 104, 118, 113, 63, 6, 198})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TechTreeNode(
        ResearchDialog _param1,
        TechTree.TechNode node,
        ResearchDialog.TechTreeNode parent)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ResearchDialog.TechTreeNode techTreeNode1 = this;
        this.visible = true;
        this.selectable = true;
        this.__\u003C\u003Enode = node;
        this.parent = (TreeLayout.TreeNode) parent;
        ResearchDialog.TechTreeNode techTreeNode2 = this;
        float nodeSize = _param1.__\u003C\u003EnodeSize;
        double num = (double) nodeSize;
        this.height = nodeSize;
        this.width = (float) num;
        _param1.nodes.add((object) this);
        if (node.__\u003C\u003Echildren == null)
          return;
        this.children = (TreeLayout.TreeNode[]) new ResearchDialog.TechTreeNode[node.__\u003C\u003Echildren.size];
        for (int index = 0; index < ((ResearchDialog.TechTreeNode[]) this.children).Length; ++index)
          ((ResearchDialog.TechTreeNode[]) this.children)[index] = new ResearchDialog.TechTreeNode(_param1, (TechTree.TechNode) node.__\u003C\u003Echildren.get(index), this);
      }

      [Modifiers]
      public TechTree.TechNode node
      {
        [HideFromJava] get => this.__\u003C\u003Enode;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Enode = value;
      }
    }

    public class View : Group
    {
      public float panX;
      public float panY;
      public float lastZoom;
      public bool moved;
      public ImageButton hoverNode;
      public Table infoTable;
      [Modifiers]
      internal ResearchDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 171, 111, 127, 2, 135, 171, 144, 127, 9, 127, 6, 114, 244, 89, 243, 70, 242, 70, 113, 108, 113, 244, 73, 103, 133, 103, 241, 73, 103, 103, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public View(ResearchDialog _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ResearchDialog.View view = this;
        this.panX = 0.0f;
        this.panY = -200f;
        this.lastZoom = -1f;
        this.moved = false;
        this.infoTable = new Table();
        this.infoTable.touchable = Touchable.__\u003C\u003Eenabled;
        ObjectSet.ObjectSetIterator objectSetIterator = this.this\u00240.nodes.iterator();
        while (((Iterator) objectSetIterator).hasNext())
        {
          ResearchDialog.TechTreeNode techTreeNode = (ResearchDialog.TechTreeNode) ((Iterator) objectSetIterator).next();
          ImageButton.__\u003Cclinit\u003E();
          ImageButton imageButton = new ImageButton(techTreeNode.__\u003C\u003Enode.content.icon(Cicon.__\u003C\u003Emedium), Styles.nodei);
          imageButton.visible((Boolp) new ResearchDialog.View.__\u003C\u003EAnon0(techTreeNode));
          imageButton.clicked((Runnable) new ResearchDialog.View.__\u003C\u003EAnon1(this, imageButton, techTreeNode));
          imageButton.hovered((Runnable) new ResearchDialog.View.__\u003C\u003EAnon2(this, imageButton, techTreeNode));
          imageButton.exited((Runnable) new ResearchDialog.View.__\u003C\u003EAnon3(this, imageButton));
          imageButton.touchable((Prov) new ResearchDialog.View.__\u003C\u003EAnon4(techTreeNode));
          imageButton.userObject = (object) techTreeNode.__\u003C\u003Enode;
          imageButton.setSize(this.this\u00240.__\u003C\u003EnodeSize);
          imageButton.update((Runnable) new ResearchDialog.View.__\u003C\u003EAnon5(this, imageButton, techTreeNode));
          this.addChild((Element) imageButton);
        }
        if (Vars.mobile)
          this.tapped((Runnable) new ResearchDialog.View.__\u003C\u003EAnon6(this));
        this.setOrigin(1);
        this.setTransform(true);
        this.released((Runnable) new ResearchDialog.View.__\u003C\u003EAnon7(this));
      }

      [LineNumberTable(new byte[] {160, 251, 140, 124, 127, 26, 127, 5, 124, 126, 124, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void clamp()
      {
        float nodeSize = this.this\u00240.__\u003C\u003EnodeSize;
        float num1 = this.width / 2f;
        float num2 = this.height / 2f;
        float num3 = this.this\u00240.bounds.x + this.panX + num1;
        float num4 = this.panY + num2 + this.this\u00240.bounds.y;
        float width = this.this\u00240.bounds.width;
        float height = this.this\u00240.bounds.height;
        float num5 = Mathf.clamp(num3, -width + nodeSize, (float) Core.graphics.getWidth() - nodeSize);
        float num6 = Mathf.clamp(num4, -height + nodeSize, (float) Core.graphics.getHeight() - nodeSize);
        this.panX = num5 - this.this\u00240.bounds.x - num1;
        this.panY = num6 - this.this\u00240.bounds.y - num2;
      }

      [LineNumberTable(new byte[] {161, 61, 171, 103, 99, 107, 169, 118, 103, 107, 102, 106, 107, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void unlock([In] TechTree.TechNode obj0)
      {
        obj0.content.unlock();
        for (TechTree.TechNode parent = obj0.parent; parent != null; parent = parent.parent)
          parent.content.unlock();
        this.this\u00240.checkNodes(this.this\u00240.root);
        this.hoverNode = (ImageButton) null;
        this.this\u00240.treeLayout();
        this.rebuild();
        Core.scene.act();
        Sounds.unlock.play();
        Events.fire((object) new EventType.ResearchEvent(obj0.content));
      }

      [LineNumberTable(new byte[] {161, 85, 135, 108, 107, 141, 132, 140, 247, 71, 152, 108, 155, 141, 250, 160, 97, 108, 125, 188, 108, 107, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void rebuild([Nullable(new object[] {64, "Larc/util/Nullable;"})] bool[] _param1)
      {
        ImageButton hoverNode = this.hoverNode;
        this.infoTable.remove();
        this.infoTable.clear();
        this.infoTable.update((Runnable) null);
        if (hoverNode == null)
          return;
        TechTree.TechNode userObject = (TechTree.TechNode) hoverNode.userObject;
        this.infoTable.exited((Runnable) new ResearchDialog.View.__\u003C\u003EAnon8(this, hoverNode));
        this.infoTable.update((Runnable) new ResearchDialog.View.__\u003C\u003EAnon9(this, hoverNode));
        this.infoTable.left();
        this.infoTable.background((Drawable) Tex.button).margin(8f);
        int num = this.this\u00240.selectable(userObject) ? 1 : 0;
        this.infoTable.table((Cons) new ResearchDialog.View.__\u003C\u003EAnon10(this, num != 0, userObject, _param1));
        this.infoTable.row();
        if (userObject.content.description != null && userObject.content.inlineDescription && num != 0)
          this.infoTable.table((Cons) new ResearchDialog.View.__\u003C\u003EAnon11(userObject)).fillX();
        this.addChild((Element) this.infoTable);
        this.infoTable.pack();
        this.infoTable.act(Core.graphics.getDeltaTime());
      }

      [LineNumberTable(new byte[] {161, 80, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void rebuild() => this.rebuild((bool[]) null);

      [LineNumberTable(new byte[] {161, 7, 144, 171, 108, 127, 28, 2, 230, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool canSpend([In] TechTree.TechNode obj0)
      {
        if (!this.this\u00240.selectable(obj0))
          return false;
        if (obj0.requirements.Length == 0)
          return true;
        for (int index = 0; index < obj0.requirements.Length; ++index)
        {
          if (obj0.__\u003C\u003EfinishedRequirements[index].amount < obj0.requirements[index].amount && this.this\u00240.items.has(obj0.requirements[index].item))
            return true;
        }
        return obj0.content.locked();
      }

      [LineNumberTable(new byte[] {161, 23, 130, 109, 149, 111, 106, 170, 127, 20, 121, 144, 101, 100, 207, 112, 226, 48, 233, 84, 99, 167, 166, 106, 103, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void spend([In] TechTree.TechNode obj0)
      {
        int num = 1;
        bool[] flagArray = new bool[obj0.requirements.Length];
        bool[] shine = new bool[Vars.content.items().size];
        for (int index = 0; index < obj0.requirements.Length; ++index)
        {
          ItemStack requirement = obj0.requirements[index];
          ItemStack finishedRequirement = obj0.__\u003C\u003EfinishedRequirements[index];
          int amount = Math.max(Math.min(requirement.amount - finishedRequirement.amount, this.this\u00240.items.get(requirement.item)), 0);
          this.this\u00240.items.remove(requirement.item, amount);
          finishedRequirement.amount += amount;
          if (amount > 0)
          {
            flagArray[index] = true;
            shine[(int) requirement.item.__\u003C\u003Eid] = true;
          }
          if (finishedRequirement.amount < requirement.amount)
            num = 0;
        }
        if (num != 0)
          this.unlock(obj0);
        obj0.save();
        Core.scene.act();
        this.rebuild(flagArray);
        this.this\u00240.itemDisplay.rebuild(this.this\u00240.items, shine);
      }

      [Modifiers]
      [LineNumberTable(296)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00240([In] ResearchDialog.TechTreeNode obj0) => obj0.visible;

      [Modifiers]
      [LineNumberTable(new byte[] {160, 184, 137, 103, 103, 102, 109, 110, 111, 237, 76, 127, 4, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241([In] ImageButton obj0, [In] ResearchDialog.TechTreeNode obj1)
      {
        if (this.moved)
          return;
        if (Vars.mobile)
        {
          this.hoverNode = obj0;
          this.rebuild();
          float right = this.infoTable.getRight();
          if ((double) right <= (double) Core.graphics.getWidth())
            return;
          this.addAction((Action) new ResearchDialog.View.\u0031(this, right - (float) Core.graphics.getWidth()));
        }
        else
        {
          if (!this.canSpend(obj1.__\u003C\u003Enode) || !this.this\u00240.locked(obj1.__\u003C\u003Enode))
            return;
          this.spend(obj1.__\u003C\u003Enode);
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 209, 125, 103, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00242([In] ImageButton obj0, [In] ResearchDialog.TechTreeNode obj1)
      {
        if (Vars.mobile || object.ReferenceEquals((object) this.hoverNode, (object) obj0) || !obj1.visible)
          return;
        this.hoverNode = obj0;
        this.rebuild();
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 215, 127, 16, 103, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00243([In] ImageButton obj0)
      {
        if (Vars.mobile || !object.ReferenceEquals((object) this.hoverNode, (object) obj0) || (this.infoTable.hasMouse() || this.hoverNode.hasMouse()))
          return;
        this.hoverNode = (ImageButton) null;
        this.rebuild();
      }

      [Modifiers]
      [LineNumberTable(334)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static Touchable lambda\u0024new\u00244([In] ResearchDialog.TechTreeNode obj0) => !obj0.visible ? Touchable.__\u003C\u003Edisabled : Touchable.__\u003C\u003Eenabled;

      [Modifiers]
      [LineNumberTable(new byte[] {160, 224, 126, 127, 37, 159, 51, 127, 31, 127, 26, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00245([In] ImageButton obj0, [In] ResearchDialog.TechTreeNode obj1)
      {
        int height = Core.graphics.getHeight();
        int num1 = 2;
        float num2 = (num1 != -1 ? (float) (height % num1) : 0.0f) / 2f;
        obj0.setPosition(obj1.x + this.panX + this.width / 2f, obj1.y + this.panY + this.height / 2f + num2, 1);
        obj0.getStyle().up = this.this\u00240.locked(obj1.__\u003C\u003Enode) ? (!this.this\u00240.selectable(obj1.__\u003C\u003Enode) || !this.canSpend(obj1.__\u003C\u003Enode) ? (Drawable) Tex.buttonRed : (Drawable) Tex.button) : (Drawable) Tex.buttonOver;
        ((TextureRegionDrawable) obj0.getStyle().imageUp).setRegion(!obj1.selectable ? Icon.@lock.getRegion() : obj1.__\u003C\u003Enode.content.icon(Cicon.__\u003C\u003Emedium));
        obj0.getImage().setColor(this.this\u00240.locked(obj1.__\u003C\u003Enode) ? (!obj1.selectable ? Pal.gray : Color.__\u003C\u003Egray) : Color.__\u003C\u003Ewhite);
        obj0.getImage().setScaling(Scaling.__\u003C\u003Ebounded);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {160, 237, 127, 3, 105, 103, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00246()
      {
        if (!object.ReferenceEquals((object) Core.scene.hit((float) Core.input.mouseX(), (float) Core.input.mouseY(), true), (object) this))
          return;
        this.hoverNode = (ImageButton) null;
        this.rebuild();
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00247() => this.moved = false;

      [Modifiers]
      [LineNumberTable(new byte[] {161, 96, 127, 9, 103, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00248([In] ImageButton obj0)
      {
        if (!object.ReferenceEquals((object) this.hoverNode, (object) obj0) || this.infoTable.hasMouse() || this.hoverNode.hasMouse())
          return;
        this.hoverNode = (ImageButton) null;
        this.rebuild();
      }

      [Modifiers]
      [LineNumberTable(472)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u00249([In] ImageButton obj0) => this.infoTable.setPosition(obj0.x + obj0.getWidth(), obj0.y + obj0.getHeight(), 10);

      [Modifiers]
      [LineNumberTable(new byte[] {159, 22, 66, 156, 127, 9, 159, 13, 109, 250, 160, 81, 134, 117, 104, 127, 15, 155})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002419(
        [In] bool obj0,
        [In] TechTree.TechNode obj1,
        [In] bool[] obj2,
        [In] Table obj3)
      {
        int num = obj0 ? 1 : 0;
        obj3.margin(0.0f).left().defaults().left();
        if (num != 0 && (obj1.content.description != null || obj1.content.stats.toMap().size > 0))
          obj3.button((Drawable) Icon.info, Styles.cleari, (Runnable) new ResearchDialog.View.__\u003C\u003EAnon12(obj1)).growY().width(50f);
        obj3.add().grow();
        obj3.table((Cons) new ResearchDialog.View.__\u003C\u003EAnon13(this, num != 0, obj1, obj2)).pad(9f);
        if (!Vars.mobile || !this.this\u00240.locked(obj1))
          return;
        obj3.row();
        obj3.button("@research", (Drawable) Icon.ok, Styles.nodet, (Runnable) new ResearchDialog.View.__\u003C\u003EAnon14(this, obj1)).disabled((Boolf) new ResearchDialog.View.__\u003C\u003EAnon15(this, obj1)).growX().height(44f).colspan(3);
      }

      [Modifiers]
      [LineNumberTable(578)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u002420([In] TechTree.TechNode obj0, [In] Table obj1) => obj1.margin(3f).left().labelWrap(obj0.content.displayDescription()).color(Color.__\u003C\u003ElightGray).growX();

      [Modifiers]
      [LineNumberTable(483)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u002410([In] TechTree.TechNode obj0) => Vars.ui.content.show(obj0.content);

      [Modifiers]
      [LineNumberTable(new byte[] {159, 21, 162, 114, 127, 14, 104, 142, 248, 160, 73, 157})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002416(
        [In] bool obj0,
        [In] TechTree.TechNode obj1,
        [In] bool[] obj2,
        [In] Table obj3)
      {
        int num = obj0 ? 1 : 0;
        obj3.left().defaults().left();
        Table table1 = obj3;
        object obj4 = num == 0 ? (object) "[accent]???" : (object) obj1.content.localizedName;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        CharSequence text1 = charSequence;
        table1.add(text1);
        obj3.row();
        if (this.this\u00240.locked(obj1))
        {
          obj3.table((Cons) new ResearchDialog.View.__\u003C\u003EAnon16(this, num != 0, obj1, obj2));
        }
        else
        {
          Table table2 = obj3;
          object obj5 = (object) "@completed";
          charSequence.__\u003Cref\u003E = (__Null) obj5;
          CharSequence text2 = charSequence;
          table2.add(text2);
        }
      }

      [Modifiers]
      [LineNumberTable(571)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002417([In] TechTree.TechNode obj0) => this.spend(obj0);

      [Modifiers]
      [LineNumberTable(572)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024rebuild\u002418([In] TechTree.TechNode obj0, [In] TextButton obj1) => !this.canSpend(obj0);

      [Modifiers]
      [LineNumberTable(new byte[] {159, 19, 98, 104, 166, 122, 108, 130, 113, 127, 9, 127, 9, 234, 61, 235, 70, 159, 63, 99, 108, 159, 7, 172, 168, 113, 107, 171, 114, 143, 248, 83, 107, 232, 36, 237, 94, 110, 243, 75, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002415(
        [In] bool obj0,
        [In] TechTree.TechNode obj1,
        [In] bool[] obj2,
        [In] Table obj3)
      {
        int num1 = obj0 ? 1 : 0;
        obj3.left();
        if (num1 != 0)
        {
          if (Structs.contains((object[]) obj1.__\u003C\u003EfinishedRequirements, (Boolf) new ResearchDialog.View.__\u003C\u003EAnon17()))
          {
            float num2 = 0.0f;
            float num3 = 0.0f;
            int num4 = 0;
            for (int index = 0; index < obj1.requirements.Length; ++index)
            {
              num2 += obj1.requirements[index].item.cost * (float) obj1.requirements[index].amount;
              num3 += obj1.__\u003C\u003EfinishedRequirements[index].item.cost * (float) obj1.__\u003C\u003EfinishedRequirements[index].amount;
              if (obj2 != null)
                num4 |= obj2[index] ? 1 : 0;
            }
            Table table = obj3;
            object obj = (object) Core.bundle.format("research.progress", (object) Integer.valueOf(Math.min(ByteCodeHelper.f2i(num3 / num2 * 100f), 99)));
            CharSequence charSequence;
            charSequence.__\u003Cref\u003E = (__Null) obj;
            CharSequence text = charSequence;
            Label label = (Label) table.add(text).left().get();
            if (num4 != 0)
            {
              label.setColor(Pal.accent);
              label.actions((Action) Actions.color(Color.__\u003C\u003ElightGray, 0.75f, Interp.fade));
            }
            else
              label.setColor(Color.__\u003C\u003ElightGray);
            obj3.row();
          }
          for (int index = 0; index < obj1.requirements.Length; ++index)
          {
            ItemStack requirement = obj1.requirements[index];
            ItemStack finishedRequirement = obj1.__\u003C\u003EfinishedRequirements[index];
            if (requirement.amount > finishedRequirement.amount)
            {
              int num2 = obj2 == null || !obj2[index] ? 0 : 1;
              obj3.table((Cons) new ResearchDialog.View.__\u003C\u003EAnon18(this, requirement, finishedRequirement, num2 != 0)).fillX().left();
              obj3.row();
            }
          }
        }
        else
        {
          if (obj1.objectives.size <= 0)
            return;
          obj3.table((Cons) new ResearchDialog.View.__\u003C\u003EAnon19(obj1));
          obj3.row();
        }
      }

      [Modifiers]
      [LineNumberTable(497)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024rebuild\u002411([In] ItemStack obj0) => obj0.amount > 0;

      [Modifiers]
      [LineNumberTable(new byte[] {159, 10, 66, 142, 104, 127, 13, 127, 14, 148, 140, 159, 7, 99, 108, 159, 4, 169})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024rebuild\u002413(
        [In] ItemStack obj0,
        [In] ItemStack obj1,
        [In] bool obj2,
        [In] Table obj3)
      {
        int num1 = obj2 ? 1 : 0;
        int num2 = obj0.amount - obj1.amount;
        obj3.left();
        obj3.image(obj0.item.icon(Cicon.__\u003C\u003Esmall)).size(24f).padRight(3f);
        Table table = obj3;
        object localizedName = (object) obj0.item.localizedName;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) localizedName;
        CharSequence text = charSequence;
        table.add(text).color(Color.__\u003C\u003ElightGray);
        Label label = (Label) obj3.label((Prov) new ResearchDialog.View.__\u003C\u003EAnon20(this, obj0, num2)).get();
        Color color = !this.this\u00240.items.has(obj0.item) ? Color.__\u003C\u003Escarlet : Color.__\u003C\u003ElightGray;
        if (num1 != 0)
        {
          label.setColor(Pal.accent);
          label.actions((Action) Actions.color(color, 0.75f, Interp.fade));
        }
        else
          label.setColor(color);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 181, 127, 8, 103, 127, 4, 138, 127, 38, 127, 26, 103, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024rebuild\u002414([In] TechTree.TechNode obj0, [In] Table obj1)
      {
        Table table1 = obj1;
        object obj2 = (object) "@complete";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj2;
        CharSequence text1 = charSequence;
        table1.add(text1).colspan(2).left();
        obj1.row();
        Iterator iterator = obj0.objectives.iterator();
        while (iterator.hasNext())
        {
          Objectives.Objective objective = (Objectives.Objective) iterator.next();
          if (!objective.complete())
          {
            Table table2 = obj1;
            object obj3 = (object) new StringBuilder().append("> ").append(objective.display()).toString();
            charSequence.__\u003Cref\u003E = (__Null) obj3;
            CharSequence text2 = charSequence;
            table2.add(text2).color(Color.__\u003C\u003ElightGray).left();
            obj1.image(!objective.complete() ? (Drawable) Icon.cancel : (Drawable) Icon.ok, !objective.complete() ? Color.__\u003C\u003Escarlet : Color.__\u003C\u003ElightGray).padLeft(3f);
            obj1.row();
          }
        }
      }

      [Modifiers]
      [LineNumberTable(new byte[] {161, 163, 127, 1, 127, 1, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CharSequence lambda\u0024rebuild\u002412([In] ItemStack obj0, [In] int obj1)
      {
        object obj = (object) new StringBuilder().append(" ").append(UI.formatAmount(Math.min(this.this\u00240.items.get(obj0.item), obj1))).append(" / ").append(UI.formatAmount(obj1)).toString();
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }

      [LineNumberTable(new byte[] {161, 218, 102, 127, 13, 134, 127, 9, 106, 127, 6, 110, 127, 14, 149, 127, 1, 107, 127, 73, 159, 17, 127, 11, 255, 13, 53, 235, 78, 133, 102, 101, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void drawChildren()
      {
        this.clamp();
        float num1 = this.panX + this.width / 2f;
        float num2 = this.panY + this.height / 2f;
        Draw.sort(true);
        ObjectSet.ObjectSetIterator objectSetIterator = this.this\u00240.nodes.iterator();
label_1:
        while (((Iterator) objectSetIterator).hasNext())
        {
          ResearchDialog.TechTreeNode techTreeNode1 = (ResearchDialog.TechTreeNode) ((Iterator) objectSetIterator).next();
          if (techTreeNode1.visible)
          {
            ResearchDialog.TechTreeNode[] children = (ResearchDialog.TechTreeNode[]) techTreeNode1.children;
            int length = children.Length;
            int index = 0;
            while (true)
            {
              if (index < length)
              {
                ResearchDialog.TechTreeNode techTreeNode2 = children[index];
                if (techTreeNode2.visible)
                {
                  int num3 = this.this\u00240.locked(techTreeNode1.__\u003C\u003Enode) || this.this\u00240.locked(techTreeNode2.__\u003C\u003Enode) ? 1 : 0;
                  Draw.z(num3 == 0 ? 2f : 1f);
                  Lines.stroke(Scl.scl(4f), num3 == 0 ? Pal.accent : Pal.gray);
                  Draw.alpha(this.parentAlpha);
                  if (Mathf.equal(Math.abs(techTreeNode1.y - techTreeNode2.y), Math.abs(techTreeNode1.x - techTreeNode2.x), 1f) && (double) Mathf.dstm(techTreeNode1.x, techTreeNode1.y, techTreeNode2.x, techTreeNode2.y) <= (double) (techTreeNode1.width * 3f))
                  {
                    Lines.line(techTreeNode1.x + num1, techTreeNode1.y + num2, techTreeNode2.x + num1, techTreeNode2.y + num2);
                  }
                  else
                  {
                    Lines.line(techTreeNode1.x + num1, techTreeNode1.y + num2, techTreeNode2.x + num1, techTreeNode1.y + num2);
                    Lines.line(techTreeNode2.x + num1, techTreeNode1.y + num2, techTreeNode2.x + num1, techTreeNode2.y + num2);
                  }
                }
                ++index;
              }
              else
                goto label_1;
            }
          }
        }
        Draw.sort(false);
        Draw.reset();
        base.drawChildren();
      }

      [HideFromJava]
      static View() => Group.__\u003Cclinit\u003E();

      [InnerClass]
      [EnclosingMethod(null, "<init>", "(Lmindustry.ui.dialogs.ResearchDialog;)V")]
      [SpecialName]
      internal new class \u0031 : RelativeTemporalAction
      {
        [Modifiers]
        internal float val\u0024moveBy;
        [Modifiers]
        internal ResearchDialog.View this\u00241;

        [LineNumberTable(new byte[] {160, 192, 151, 107, 107})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] ResearchDialog.View obj0, [In] float obj1)
        {
          this.this\u00241 = obj0;
          this.val\u0024moveBy = obj1;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          ResearchDialog.View.\u0031 obj = this;
          this.setDuration(0.1f);
          this.setInterpolation(Interp.fade);
        }

        [LineNumberTable(new byte[] {160, 200, 125})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override void updateRelative([In] float obj0) => this.this\u00241.panX -= this.val\u0024moveBy * obj0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolp
      {
        private readonly ResearchDialog.TechTreeNode arg\u00241;

        internal __\u003C\u003EAnon0([In] ResearchDialog.TechTreeNode obj0) => this.arg\u00241 = obj0;

        public bool get() => (ResearchDialog.View.lambda\u0024new\u00240(this.arg\u00241) ? 1 : 0) != 0;
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly ImageButton arg\u00242;
        private readonly ResearchDialog.TechTreeNode arg\u00243;

        internal __\u003C\u003EAnon1(
          [In] ResearchDialog.View obj0,
          [In] ImageButton obj1,
          [In] ResearchDialog.TechTreeNode obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00241(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly ImageButton arg\u00242;
        private readonly ResearchDialog.TechTreeNode arg\u00243;

        internal __\u003C\u003EAnon2(
          [In] ResearchDialog.View obj0,
          [In] ImageButton obj1,
          [In] ResearchDialog.TechTreeNode obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00242(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon3 : Runnable
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly ImageButton arg\u00242;

        internal __\u003C\u003EAnon3([In] ResearchDialog.View obj0, [In] ImageButton obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00243(this.arg\u00242);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon4 : Prov
      {
        private readonly ResearchDialog.TechTreeNode arg\u00241;

        internal __\u003C\u003EAnon4([In] ResearchDialog.TechTreeNode obj0) => this.arg\u00241 = obj0;

        public object get() => (object) ResearchDialog.View.lambda\u0024new\u00244(this.arg\u00241);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon5 : Runnable
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly ImageButton arg\u00242;
        private readonly ResearchDialog.TechTreeNode arg\u00243;

        internal __\u003C\u003EAnon5(
          [In] ResearchDialog.View obj0,
          [In] ImageButton obj1,
          [In] ResearchDialog.TechTreeNode obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00245(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon6 : Runnable
      {
        private readonly ResearchDialog.View arg\u00241;

        internal __\u003C\u003EAnon6([In] ResearchDialog.View obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00246();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon7 : Runnable
      {
        private readonly ResearchDialog.View arg\u00241;

        internal __\u003C\u003EAnon7([In] ResearchDialog.View obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.lambda\u0024new\u00247();
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon8 : Runnable
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly ImageButton arg\u00242;

        internal __\u003C\u003EAnon8([In] ResearchDialog.View obj0, [In] ImageButton obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u00248(this.arg\u00242);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon9 : Runnable
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly ImageButton arg\u00242;

        internal __\u003C\u003EAnon9([In] ResearchDialog.View obj0, [In] ImageButton obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u00249(this.arg\u00242);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : Cons
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly bool arg\u00242;
        private readonly TechTree.TechNode arg\u00243;
        private readonly bool[] arg\u00244;

        internal __\u003C\u003EAnon10(
          [In] ResearchDialog.View obj0,
          [In] bool obj1,
          [In] TechTree.TechNode obj2,
          [In] bool[] obj3)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002419(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Table) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon11 : Cons
      {
        private readonly TechTree.TechNode arg\u00241;

        internal __\u003C\u003EAnon11([In] TechTree.TechNode obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => ResearchDialog.View.lambda\u0024rebuild\u002420(this.arg\u00241, (Table) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon12 : Runnable
      {
        private readonly TechTree.TechNode arg\u00241;

        internal __\u003C\u003EAnon12([In] TechTree.TechNode obj0) => this.arg\u00241 = obj0;

        public void run() => ResearchDialog.View.lambda\u0024rebuild\u002410(this.arg\u00241);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon13 : Cons
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly bool arg\u00242;
        private readonly TechTree.TechNode arg\u00243;
        private readonly bool[] arg\u00244;

        internal __\u003C\u003EAnon13(
          [In] ResearchDialog.View obj0,
          [In] bool obj1,
          [In] TechTree.TechNode obj2,
          [In] bool[] obj3)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002416(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Table) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon14 : Runnable
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly TechTree.TechNode arg\u00242;

        internal __\u003C\u003EAnon14([In] ResearchDialog.View obj0, [In] TechTree.TechNode obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => this.arg\u00241.lambda\u0024rebuild\u002417(this.arg\u00242);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon15 : Boolf
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly TechTree.TechNode arg\u00242;

        internal __\u003C\u003EAnon15([In] ResearchDialog.View obj0, [In] TechTree.TechNode obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024rebuild\u002418(this.arg\u00242, (TextButton) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon16 : Cons
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly bool arg\u00242;
        private readonly TechTree.TechNode arg\u00243;
        private readonly bool[] arg\u00244;

        internal __\u003C\u003EAnon16(
          [In] ResearchDialog.View obj0,
          [In] bool obj1,
          [In] TechTree.TechNode obj2,
          [In] bool[] obj3)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002415(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Table) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon17 : Boolf
      {
        internal __\u003C\u003EAnon17()
        {
        }

        public bool get([In] object obj0) => (ResearchDialog.View.lambda\u0024rebuild\u002411((ItemStack) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon18 : Cons
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly ItemStack arg\u00242;
        private readonly ItemStack arg\u00243;
        private readonly bool arg\u00244;

        internal __\u003C\u003EAnon18(
          [In] ResearchDialog.View obj0,
          [In] ItemStack obj1,
          [In] ItemStack obj2,
          [In] bool obj3)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
        }

        public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002413(this.arg\u00242, this.arg\u00243, this.arg\u00244, (Table) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon19 : Cons
      {
        private readonly TechTree.TechNode arg\u00241;

        internal __\u003C\u003EAnon19([In] TechTree.TechNode obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => ResearchDialog.View.lambda\u0024rebuild\u002414(this.arg\u00241, (Table) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon20 : Prov
      {
        private readonly ResearchDialog.View arg\u00241;
        private readonly ItemStack arg\u00242;
        private readonly int arg\u00243;

        internal __\u003C\u003EAnon20([In] ResearchDialog.View obj0, [In] ItemStack obj1, [In] int obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public object get() => (object) this.arg\u00241.lambda\u0024rebuild\u002412(this.arg\u00242, this.arg\u00243).__\u003Cref\u003E;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly ResearchDialog arg\u00241;

      internal __\u003C\u003EAnon0([In] ResearchDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly PlanetDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] PlanetDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly ResearchDialog arg\u00241;

      internal __\u003C\u003EAnon2([In] ResearchDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((KeyCode) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly ResearchDialog arg\u00241;

      internal __\u003C\u003EAnon3([In] ResearchDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00242();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (ResearchDialog.lambda\u0024selectable\u00243((Objectives.Objective) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly ResearchDialog arg\u00241;

      internal __\u003C\u003EAnon5([In] ResearchDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }
  }
}
