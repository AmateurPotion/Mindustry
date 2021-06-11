// Decompiled with JetBrains decompiler
// Type: mindustry.ui.layout.RadialTreeLayout
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.layout
{
  public class RadialTreeLayout : Object, TreeLayout
  {
    [Signature("Larc/struct/ObjectSet<Lmindustry/ui/layout/TreeLayout$TreeNode;>;")]
    private static ObjectSet visited;
    [Signature("Larc/struct/Queue<Lmindustry/ui/layout/TreeLayout$TreeNode;>;")]
    private static Queue queue;
    public float startRadius;
    public float delta;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 131, 98, 106, 106, 106, 130, 108, 139, 111, 112, 141, 122, 114, 110, 236, 61, 232, 70, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int bfs([In] TreeLayout.TreeNode obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      RadialTreeLayout.visited.clear();
      RadialTreeLayout.queue.clear();
      if (num1 != 0)
        obj0.number = 0;
      int num2 = 0;
      RadialTreeLayout.visited.add((object) obj0);
      RadialTreeLayout.queue.addFirst((object) obj0);
label_3:
      while (!RadialTreeLayout.queue.isEmpty())
      {
        TreeLayout.TreeNode treeNode1 = (TreeLayout.TreeNode) RadialTreeLayout.queue.removeFirst();
        if (treeNode1.children.Length == 0)
          ++num2;
        TreeLayout.TreeNode[] children = treeNode1.children;
        int length = children.Length;
        int index = 0;
        while (true)
        {
          if (index < length)
          {
            TreeLayout.TreeNode treeNode2 = children[index];
            if (num1 != 0)
              treeNode2.number = treeNode1.number + 1;
            if (RadialTreeLayout.visited.add((object) treeNode2))
              RadialTreeLayout.queue.addLast((object) treeNode2);
            ++index;
          }
          else
            goto label_3;
        }
      }
      return num2;
    }

    [LineNumberTable(new byte[] {159, 170, 131, 120, 159, 0, 127, 0, 159, 0, 105, 137, 127, 1, 227, 54, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void radialize([In] TreeLayout.TreeNode obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      float num1 = obj2;
      TreeLayout.TreeNode[] children = obj0.children;
      int length = children.Length;
      for (int index = 0; index < length; ++index)
      {
        TreeLayout.TreeNode treeNode = children[index];
        float num2 = num1 + (float) treeNode.leaves / (float) obj0.leaves * (obj3 - obj2);
        float num3 = obj1 * Mathf.cos((num1 + num2) / 2f * ((float) Math.PI / 180f));
        float num4 = obj1 * Mathf.sin((num1 + num2) / 2f * ((float) Math.PI / 180f));
        treeNode.x = num3;
        treeNode.y = num4;
        if (treeNode.children.Length > 0)
          this.radialize(treeNode, obj1 + this.delta, num1, num2);
        num1 = num2;
      }
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RadialTreeLayout()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 115, 147, 137, 107, 123, 110, 130, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void layout(TreeLayout.TreeNode root)
    {
      this.startRadius = root.height * 2.4f;
      this.delta = root.height * 20.4f;
      this.bfs(root, true);
      ObjectSet.ObjectSetIterator objectSetIterator = new ObjectSet(RadialTreeLayout.visited).iterator();
      while (((Iterator) objectSetIterator).hasNext())
      {
        TreeLayout.TreeNode treeNode = (TreeLayout.TreeNode) ((Iterator) objectSetIterator).next();
        treeNode.leaves = this.bfs(treeNode, false);
      }
      this.radialize(root, this.startRadius, 0.0f, 360f);
    }

    [LineNumberTable(new byte[] {159, 141, 173, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static RadialTreeLayout()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ui.layout.RadialTreeLayout"))
        return;
      RadialTreeLayout.visited = new ObjectSet();
      RadialTreeLayout.queue = new Queue();
    }
  }
}
