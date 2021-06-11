// Decompiled with JetBrains decompiler
// Type: mindustry.ui.layout.RowTreeLayout
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.layout
{
  public class RowTreeLayout : Object, TreeLayout
  {
    [LineNumberTable(new byte[] {159, 164, 142, 107, 106, 169, 113, 107, 104, 117, 44, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void layout([In] TreeLayout.TreeNode obj0, [In] int obj1, [In] IntSeq obj2)
    {
      float num = obj0.height * 5f;
      if (obj2.size < obj1 + 1)
      {
        obj2.ensureCapacity(obj1 + 1);
        obj2.size = obj1 + 1;
      }
      obj0.x = num * (float) obj2.get(obj1);
      obj0.y = num * (float) obj1;
      obj2.incr(obj1, 1);
      TreeLayout.TreeNode[] children = obj0.children;
      int length = children.Length;
      for (int index = 0; index < length; ++index)
        this.layout(children[index], obj1 + 1, obj2);
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RowTreeLayout()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 237, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void layout(TreeLayout.TreeNode root) => this.layout(root, 0, new IntSeq());
  }
}
