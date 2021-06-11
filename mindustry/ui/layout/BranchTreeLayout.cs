// Decompiled with JetBrains decompiler
// Type: mindustry.ui.layout.BranchTreeLayout
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math.geom;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.layout
{
  public class BranchTreeLayout : Object, TreeLayout
  {
    public BranchTreeLayout.TreeLocation rootLocation;
    public BranchTreeLayout.TreeAlignment alignment;
    public float gapBetweenLevels;
    public float gapBetweenNodes;
    [Modifiers]
    private FloatSeq sizeOfLevel;
    private float boundsLeft;
    private float boundsRight;
    private float boundsTop;
    private float boundsBottom;

    [LineNumberTable(new byte[] {159, 165, 104, 104, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void layout(TreeLayout.TreeNode root)
    {
      this.firstWalk(root, (TreeLayout.TreeNode) null);
      this.calcSizeOfLevels(root, 0);
      this.secondWalk(root, -root.prelim, 0, 0.0f);
    }

    [LineNumberTable(new byte[] {160, 108, 104, 102, 220, 105, 98, 120, 105, 108, 227, 61, 232, 69, 103, 127, 14, 99, 119, 146, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void firstWalk([In] TreeLayout.TreeNode obj0, [In] TreeLayout.TreeNode obj1)
    {
      if (obj0.isLeaf())
      {
        if (obj1 == null)
          return;
        obj0.prelim = obj1.prelim + this.getDistance(obj0, obj1);
      }
      else
      {
        TreeLayout.TreeNode treeNode1 = obj0.children[0];
        TreeLayout.TreeNode treeNode2 = (TreeLayout.TreeNode) null;
        TreeLayout.TreeNode[] children = obj0.children;
        int length = children.Length;
        for (int index = 0; index < length; ++index)
        {
          TreeLayout.TreeNode treeNode3 = children[index];
          this.firstWalk(treeNode3, treeNode2);
          treeNode1 = this.apportion(treeNode3, treeNode1, treeNode2, obj0);
          treeNode2 = treeNode3;
        }
        this.executeShifts(obj0);
        float num = (obj0.children[0].prelim + obj0.children[obj0.children.Length - 1].prelim) / 2f;
        if (obj1 != null)
        {
          obj0.prelim = obj1.prelim + this.getDistance(obj0, obj1);
          obj0.mode = obj0.prelim - num;
        }
        else
          obj0.prelim = num;
      }
    }

    [LineNumberTable(new byte[] {25, 110, 112, 136, 174, 105, 100, 173, 104, 120, 43, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void calcSizeOfLevels([In] TreeLayout.TreeNode obj0, [In] int obj1)
    {
      float num;
      if (this.sizeOfLevel.size <= obj1)
      {
        this.sizeOfLevel.add(0.0f);
        num = 0.0f;
      }
      else
        num = this.sizeOfLevel.get(obj1);
      float nodeThickness = this.getNodeThickness(obj0);
      if ((double) num < (double) nodeThickness)
        this.sizeOfLevel.set(obj1, nodeThickness);
      if (obj0.isLeaf())
        return;
      TreeLayout.TreeNode[] children = obj0.children;
      int length = children.Length;
      for (int index = 0; index < length; ++index)
        this.calcSizeOfLevels(children[index], obj1 + 1);
    }

    [LineNumberTable(new byte[] {160, 133, 104, 103, 137, 171, 114, 116, 114, 155, 188, 99, 99, 99, 164, 103, 104, 138, 104, 179, 125, 55, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void secondWalk([In] TreeLayout.TreeNode obj0, [In] float obj1, [In] int obj2, [In] float obj3)
    {
      float levelChangeSign = (float) this.getLevelChangeSign();
      int num1 = this.isLevelChangeInYAxis() ? 1 : 0;
      float sizeOfLevel = this.getSizeOfLevel(obj2);
      float num2 = obj0.prelim + obj1;
      float num3 = !object.ReferenceEquals((object) this.alignment, (object) BranchTreeLayout.TreeAlignment.__\u003C\u003Ecenter) ? (!object.ReferenceEquals((object) this.alignment, (object) BranchTreeLayout.TreeAlignment.__\u003C\u003EtowardsRoot) ? obj3 + sizeOfLevel - levelChangeSign * (this.getNodeThickness(obj0) / 2f) : obj3 + levelChangeSign * (this.getNodeThickness(obj0) / 2f)) : obj3 + levelChangeSign * (sizeOfLevel / 2f);
      if (num1 == 0)
      {
        float num4 = num2;
        num2 = num3;
        num3 = num4;
      }
      obj0.x = num2;
      obj0.y = num3;
      this.updateBounds(obj0, num2, num3);
      if (obj0.isLeaf())
        return;
      float num5 = obj3 + (sizeOfLevel + this.gapBetweenLevels) * levelChangeSign;
      TreeLayout.TreeNode[] children = obj0.children;
      int length = children.Length;
      for (int index = 0; index < length; ++index)
        this.secondWalk(children[index], obj1 + obj0.mode, obj2 + 1, num5);
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isLevelChangeInYAxis() => object.ReferenceEquals((object) this.rootLocation, (object) BranchTreeLayout.TreeLocation.__\u003C\u003Etop) || object.ReferenceEquals((object) this.rootLocation, (object) BranchTreeLayout.TreeLocation.__\u003C\u003Ebottom);

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float getWidthOrHeightOfNode([In] TreeLayout.TreeNode obj0, [In] bool obj1) => obj1 ? obj0.width : obj0.height;

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float getNodeThickness([In] TreeLayout.TreeNode obj0) => this.getWidthOrHeightOfNode(obj0, !this.isLevelChangeInYAxis());

    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLevelCount() => this.sizeOfLevel.size;

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float getNodeSize([In] TreeLayout.TreeNode obj0) => this.getWidthOrHeightOfNode(obj0, this.isLevelChangeInYAxis());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getGapBetweenNodes(TreeLayout.TreeNode a, TreeLayout.TreeNode b) => this.gapBetweenNodes;

    [LineNumberTable(110)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TreeLayout.TreeNode getAncestor([In] TreeLayout.TreeNode obj0) => obj0.ancestor != null ? obj0.ancestor : obj0;

    [LineNumberTable(new byte[] {78, 105, 98, 117, 44, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getNumber([In] TreeLayout.TreeNode obj0, [In] TreeLayout.TreeNode obj1)
    {
      if (obj0.number == -1)
      {
        int num1 = 1;
        TreeLayout.TreeNode[] children = obj1.children;
        int length = children.Length;
        for (int index = 0; index < length; ++index)
        {
          TreeLayout.TreeNode treeNode = children[index];
          int num2 = num1;
          ++num1;
          treeNode.number = num2;
        }
      }
      return obj0.number;
    }

    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TreeLayout.TreeNode nextRight([In] TreeLayout.TreeNode obj0) => obj0.isLeaf() ? obj0.thread : obj0.children[obj0.children.Length - 1];

    [LineNumberTable(120)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TreeLayout.TreeNode nextLeft([In] TreeLayout.TreeNode obj0) => obj0.isLeaf() ? obj0.thread : obj0.children[0];

    [LineNumberTable(new byte[] {64, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float getDistance([In] TreeLayout.TreeNode obj0, [In] TreeLayout.TreeNode obj1) => (this.getNodeSize(obj0) + this.getNodeSize(obj1)) / 2f + this.getGapBetweenNodes(obj0, obj1);

    [LineNumberTable(new byte[] {88, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TreeLayout.TreeNode ancestor(
      [In] TreeLayout.TreeNode obj0,
      [In] TreeLayout.TreeNode obj1,
      [In] TreeLayout.TreeNode obj2)
    {
      TreeLayout.TreeNode ancestor = this.getAncestor(obj0);
      return object.ReferenceEquals((object) ancestor.parent, (object) obj1) ? ancestor : obj2;
    }

    [LineNumberTable(new byte[] {93, 114, 117, 113, 117, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void moveSubtree(
      [In] TreeLayout.TreeNode obj0,
      [In] TreeLayout.TreeNode obj1,
      [In] TreeLayout.TreeNode obj2,
      [In] float obj3)
    {
      int num = this.getNumber(obj1, obj2) - this.getNumber(obj0, obj2);
      obj1.change -= obj3 / (float) num;
      obj1.shift += obj3;
      obj0.change += obj3 / (float) num;
      obj1.prelim += obj3;
      obj1.mode += obj3;
    }

    [LineNumberTable(new byte[] {102, 99, 162, 98, 98, 130, 138, 104, 104, 104, 136, 105, 137, 110, 99, 99, 104, 104, 103, 153, 138, 105, 149, 104, 136, 108, 108, 108, 140, 105, 105, 133, 109, 104, 180, 109, 104, 116, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TreeLayout.TreeNode apportion(
      [In] TreeLayout.TreeNode obj0,
      [In] TreeLayout.TreeNode obj1,
      [In] TreeLayout.TreeNode obj2,
      [In] TreeLayout.TreeNode obj3)
    {
      if (obj2 == null)
        return obj1;
      TreeLayout.TreeNode treeNode1 = obj0;
      TreeLayout.TreeNode treeNode2 = obj0;
      TreeLayout.TreeNode treeNode3 = obj2;
      TreeLayout.TreeNode treeNode4 = obj3.children[0];
      float mode1 = treeNode2.mode;
      float mode2 = treeNode1.mode;
      float mode3 = treeNode3.mode;
      float mode4 = treeNode4.mode;
      TreeLayout.TreeNode treeNode5 = this.nextRight(treeNode3);
      TreeLayout.TreeNode treeNode6;
      TreeLayout.TreeNode treeNode7;
      for (treeNode6 = this.nextLeft(treeNode2); treeNode5 != null && treeNode6 != null; treeNode6 = this.nextLeft(treeNode7))
      {
        TreeLayout.TreeNode treeNode8 = treeNode5;
        treeNode7 = treeNode6;
        treeNode4 = this.nextLeft(treeNode4);
        treeNode1 = this.nextRight(treeNode1);
        treeNode1.ancestor = obj0;
        float num = treeNode8.prelim + mode3 - (treeNode7.prelim + mode1) + this.getDistance(treeNode8, treeNode7);
        if ((double) num > 0.0)
        {
          this.moveSubtree(this.ancestor(treeNode8, obj3, obj1), obj0, obj3, num);
          mode1 += num;
          mode2 += num;
        }
        mode3 += treeNode8.mode;
        mode1 += treeNode7.mode;
        mode4 += treeNode4.mode;
        mode2 += treeNode1.mode;
        treeNode5 = this.nextRight(treeNode8);
      }
      if (treeNode5 != null && this.nextRight(treeNode1) == null)
      {
        treeNode1.thread = treeNode5;
        treeNode1.mode += mode3 - mode2;
      }
      if (treeNode6 != null && this.nextLeft(treeNode4) == null)
      {
        treeNode4.thread = treeNode6;
        treeNode4.mode += mode1 - mode4;
        obj1 = obj0;
      }
      return obj1;
    }

    [LineNumberTable(new byte[] {160, 95, 102, 134, 110, 105, 106, 111, 111, 237, 59, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void executeShifts([In] TreeLayout.TreeNode obj0)
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      for (int index = obj0.children.Length - 1; index >= 0; index += -1)
      {
        TreeLayout.TreeNode child = obj0.children[index];
        num2 += child.change;
        child.prelim += num1;
        child.mode += num1;
        num1 += child.shift + num2;
      }
    }

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getLevelChangeSign() => object.ReferenceEquals((object) this.rootLocation, (object) BranchTreeLayout.TreeLocation.__\u003C\u003Ebottom) || object.ReferenceEquals((object) this.rootLocation, (object) BranchTreeLayout.TreeLocation.__\u003C\u003Eright) ? -1 : 1;

    [LineNumberTable(new byte[] {53, 116, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getSizeOfLevel(int level)
    {
      if (level < 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("level must be >= 0");
      }
      if (level >= this.getLevelCount())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("level must be < levelCount");
      }
      return this.sizeOfLevel.get(level);
    }

    [LineNumberTable(new byte[] {159, 191, 103, 103, 109, 109, 110, 110, 105, 135, 105, 135, 106, 136, 106, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateBounds([In] TreeLayout.TreeNode obj0, [In] float obj1, [In] float obj2)
    {
      float width = obj0.width;
      float height = obj0.height;
      float num1 = obj1 - width / 2f;
      float num2 = obj1 + width / 2f;
      float num3 = obj2 - height / 2f;
      float num4 = obj2 + height / 2f;
      if ((double) this.boundsLeft > (double) num1)
        this.boundsLeft = num1;
      if ((double) this.boundsRight < (double) num2)
        this.boundsRight = num2;
      if ((double) this.boundsTop > (double) num3)
        this.boundsTop = num3;
      if ((double) this.boundsBottom >= (double) num4)
        return;
      this.boundsBottom = num4;
    }

    [LineNumberTable(new byte[] {159, 151, 104, 107, 107, 107, 139, 107, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BranchTreeLayout()
    {
      BranchTreeLayout branchTreeLayout = this;
      this.rootLocation = BranchTreeLayout.TreeLocation.__\u003C\u003Etop;
      this.alignment = BranchTreeLayout.TreeAlignment.__\u003C\u003EawayFromRoot;
      this.gapBetweenLevels = 10f;
      this.gapBetweenNodes = 10f;
      this.sizeOfLevel = new FloatSeq();
      this.boundsLeft = float.MaxValue;
      this.boundsRight = float.Epsilon;
      this.boundsTop = float.MaxValue;
      this.boundsBottom = float.Epsilon;
    }

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect getBounds()
    {
      Rect.__\u003Cclinit\u003E();
      return new Rect(this.boundsLeft, this.boundsBottom, this.boundsRight - this.boundsLeft, this.boundsTop - this.boundsBottom);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/ui/layout/BranchTreeLayout$TreeAlignment;>;")]
    [Modifiers]
    [Serializable]
    public sealed class TreeAlignment : Enum
    {
      [Modifiers]
      internal static BranchTreeLayout.TreeAlignment __\u003C\u003Ecenter;
      [Modifiers]
      internal static BranchTreeLayout.TreeAlignment __\u003C\u003EtowardsRoot;
      [Modifiers]
      internal static BranchTreeLayout.TreeAlignment __\u003C\u003EawayFromRoot;
      [Modifiers]
      private static BranchTreeLayout.TreeAlignment[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(286)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private TreeAlignment([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(286)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static BranchTreeLayout.TreeAlignment[] values() => (BranchTreeLayout.TreeAlignment[]) BranchTreeLayout.TreeAlignment.\u0024VALUES.Clone();

      [LineNumberTable(286)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static BranchTreeLayout.TreeAlignment valueOf(string name) => (BranchTreeLayout.TreeAlignment) Enum.valueOf((Class) ClassLiteral<BranchTreeLayout.TreeAlignment>.Value, name);

      [LineNumberTable(new byte[] {159, 71, 173, 63, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static TreeAlignment()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.ui.layout.BranchTreeLayout$TreeAlignment"))
          return;
        BranchTreeLayout.TreeAlignment.__\u003C\u003Ecenter = new BranchTreeLayout.TreeAlignment(nameof (center), 0);
        BranchTreeLayout.TreeAlignment.__\u003C\u003EtowardsRoot = new BranchTreeLayout.TreeAlignment(nameof (towardsRoot), 1);
        BranchTreeLayout.TreeAlignment.__\u003C\u003EawayFromRoot = new BranchTreeLayout.TreeAlignment(nameof (awayFromRoot), 2);
        BranchTreeLayout.TreeAlignment.\u0024VALUES = new BranchTreeLayout.TreeAlignment[3]
        {
          BranchTreeLayout.TreeAlignment.__\u003C\u003Ecenter,
          BranchTreeLayout.TreeAlignment.__\u003C\u003EtowardsRoot,
          BranchTreeLayout.TreeAlignment.__\u003C\u003EawayFromRoot
        };
      }

      [Modifiers]
      public static BranchTreeLayout.TreeAlignment center
      {
        [HideFromJava] get => BranchTreeLayout.TreeAlignment.__\u003C\u003Ecenter;
      }

      [Modifiers]
      public static BranchTreeLayout.TreeAlignment towardsRoot
      {
        [HideFromJava] get => BranchTreeLayout.TreeAlignment.__\u003C\u003EtowardsRoot;
      }

      [Modifiers]
      public static BranchTreeLayout.TreeAlignment awayFromRoot
      {
        [HideFromJava] get => BranchTreeLayout.TreeAlignment.__\u003C\u003EawayFromRoot;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        center,
        towardsRoot,
        awayFromRoot,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/ui/layout/BranchTreeLayout$TreeLocation;>;")]
    [Modifiers]
    [Serializable]
    public sealed class TreeLocation : Enum
    {
      [Modifiers]
      internal static BranchTreeLayout.TreeLocation __\u003C\u003Etop;
      [Modifiers]
      internal static BranchTreeLayout.TreeLocation __\u003C\u003Eleft;
      [Modifiers]
      internal static BranchTreeLayout.TreeLocation __\u003C\u003Ebottom;
      [Modifiers]
      internal static BranchTreeLayout.TreeLocation __\u003C\u003Eright;
      [Modifiers]
      private static BranchTreeLayout.TreeLocation[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(282)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private TreeLocation([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(282)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static BranchTreeLayout.TreeLocation[] values() => (BranchTreeLayout.TreeLocation[]) BranchTreeLayout.TreeLocation.\u0024VALUES.Clone();

      [LineNumberTable(282)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static BranchTreeLayout.TreeLocation valueOf(string name) => (BranchTreeLayout.TreeLocation) Enum.valueOf((Class) ClassLiteral<BranchTreeLayout.TreeLocation>.Value, name);

      [LineNumberTable(new byte[] {159, 72, 173, 63, 33})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static TreeLocation()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.ui.layout.BranchTreeLayout$TreeLocation"))
          return;
        BranchTreeLayout.TreeLocation.__\u003C\u003Etop = new BranchTreeLayout.TreeLocation(nameof (top), 0);
        BranchTreeLayout.TreeLocation.__\u003C\u003Eleft = new BranchTreeLayout.TreeLocation(nameof (left), 1);
        BranchTreeLayout.TreeLocation.__\u003C\u003Ebottom = new BranchTreeLayout.TreeLocation(nameof (bottom), 2);
        BranchTreeLayout.TreeLocation.__\u003C\u003Eright = new BranchTreeLayout.TreeLocation(nameof (right), 3);
        BranchTreeLayout.TreeLocation.\u0024VALUES = new BranchTreeLayout.TreeLocation[4]
        {
          BranchTreeLayout.TreeLocation.__\u003C\u003Etop,
          BranchTreeLayout.TreeLocation.__\u003C\u003Eleft,
          BranchTreeLayout.TreeLocation.__\u003C\u003Ebottom,
          BranchTreeLayout.TreeLocation.__\u003C\u003Eright
        };
      }

      [Modifiers]
      public static BranchTreeLayout.TreeLocation top
      {
        [HideFromJava] get => BranchTreeLayout.TreeLocation.__\u003C\u003Etop;
      }

      [Modifiers]
      public static BranchTreeLayout.TreeLocation left
      {
        [HideFromJava] get => BranchTreeLayout.TreeLocation.__\u003C\u003Eleft;
      }

      [Modifiers]
      public static BranchTreeLayout.TreeLocation bottom
      {
        [HideFromJava] get => BranchTreeLayout.TreeLocation.__\u003C\u003Ebottom;
      }

      [Modifiers]
      public static BranchTreeLayout.TreeLocation right
      {
        [HideFromJava] get => BranchTreeLayout.TreeLocation.__\u003C\u003Eright;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        top,
        left,
        bottom,
        right,
      }
    }
  }
}
