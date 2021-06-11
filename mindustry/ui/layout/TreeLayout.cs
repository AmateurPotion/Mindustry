// Decompiled with JetBrains decompiler
// Type: mindustry.ui.layout.TreeLayout
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.ui.layout
{
  public interface TreeLayout
  {
    void layout(TreeLayout.TreeNode tltn);

    [Signature("<T:Lmindustry/ui/layout/TreeLayout$TreeNode;>Ljava/lang/Object;")]
    class TreeNode : Object
    {
      public float width;
      public float height;
      public float x;
      public float y;
      [Signature("[TT;")]
      public TreeLayout.TreeNode[] children;
      [Signature("TT;")]
      public TreeLayout.TreeNode parent;
      public float mode;
      public float prelim;
      public float change;
      public float shift;
      public int number;
      public int leaves;
      public TreeLayout.TreeNode thread;
      public TreeLayout.TreeNode ancestor;

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isLeaf() => this.children == null || this.children.Length == 0;

      [LineNumberTable(new byte[] {159, 148, 232, 73})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TreeNode()
      {
        TreeLayout.TreeNode treeNode = this;
        this.number = -1;
      }
    }
  }
}
