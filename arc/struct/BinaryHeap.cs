// Decompiled with JetBrains decompiler
// Type: arc.struct.BinaryHeap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<T:Larc/struct/BinaryHeap$Node;>Ljava/lang/Object;")]
  public class BinaryHeap : Object
  {
    [Modifiers]
    private bool isMaxHeap;
    public int size;
    private BinaryHeap.Node[] nodes;

    [LineNumberTable(new byte[] {159, 139, 130, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BinaryHeap(int capacity, bool isMaxHeap)
    {
      int num = isMaxHeap ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      BinaryHeap binaryHeap = this;
      this.isMaxHeap = num != 0;
      this.nodes = new BinaryHeap.Node[capacity];
    }

    [LineNumberTable(new byte[] {48, 103, 100, 103, 100, 102, 101, 115, 101, 104, 163, 98, 100, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void up([In] int obj0)
    {
      BinaryHeap.Node[] nodes = this.nodes;
      BinaryHeap.Node node1 = nodes[obj0];
      float num = node1.value;
      int index;
      for (; obj0 > 0; obj0 = index)
      {
        index = obj0 - 1 >> 1;
        BinaryHeap.Node node2 = nodes[index];
        if ((double) num < (double) node2.value ^ this.isMaxHeap)
        {
          nodes[obj0] = node2;
          node2.index = obj0;
        }
        else
          break;
      }
      nodes[obj0] = node1;
      node1.index = obj0;
    }

    [Signature("(TT;)TT;")]
    [LineNumberTable(new byte[] {159, 163, 111, 110, 116, 167, 108, 110, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BinaryHeap.Node add(BinaryHeap.Node node)
    {
      if (this.size == this.nodes.Length)
      {
        BinaryHeap.Node[] nodeArray = new BinaryHeap.Node[this.size << 1];
        ByteCodeHelper.arraycopy((object) this.nodes, 0, (object) nodeArray, 0, this.size);
        this.nodes = nodeArray;
      }
      node.index = this.size;
      this.nodes[this.size] = node;
      BinaryHeap binaryHeap1 = this;
      int size = binaryHeap1.size;
      BinaryHeap binaryHeap2 = binaryHeap1;
      int num = size;
      binaryHeap2.size = size + 1;
      this.up(num);
      return node;
    }

    [Signature("(I)TT;")]
    [LineNumberTable(new byte[] {18, 103, 100, 120, 105, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private BinaryHeap.Node remove([In] int obj0)
    {
      BinaryHeap.Node[] nodes = this.nodes;
      BinaryHeap.Node node1 = nodes[obj0];
      BinaryHeap.Node[] nodeArray1 = nodes;
      int index1 = obj0;
      BinaryHeap.Node[] nodeArray2 = nodes;
      BinaryHeap binaryHeap1 = this;
      int num = binaryHeap1.size - 1;
      BinaryHeap binaryHeap2 = binaryHeap1;
      int index2 = num;
      binaryHeap2.size = num;
      BinaryHeap.Node node2 = nodeArray2[index2];
      nodeArray1[index1] = node2;
      nodes[this.size] = (BinaryHeap.Node) null;
      if (this.size > 0 && obj0 < this.size)
        this.down(obj0);
      return node1;
    }

    [LineNumberTable(new byte[] {66, 103, 135, 100, 167, 103, 106, 166, 102, 233, 69, 101, 99, 152, 102, 201, 111, 120, 101, 104, 134, 117, 101, 104, 132, 133, 100, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void down([In] int obj0)
    {
      BinaryHeap.Node[] nodes = this.nodes;
      int size = this.size;
      BinaryHeap.Node node1 = nodes[obj0];
      float num1 = node1.value;
      while (true)
      {
        int index1 = 1 + (obj0 << 1);
        if (index1 < size)
        {
          int index2 = index1 + 1;
          BinaryHeap.Node node2 = nodes[index1];
          float num2 = node2.value;
          BinaryHeap.Node node3;
          float num3;
          if (index2 >= size)
          {
            node3 = (BinaryHeap.Node) null;
            num3 = !this.isMaxHeap ? float.MaxValue : float.Epsilon;
          }
          else
          {
            node3 = nodes[index2];
            num3 = node3.value;
          }
          if ((double) num2 < (double) num3 ^ this.isMaxHeap)
          {
            if ((double) num2 != (double) num1 && !((double) num2 > (double) num1 ^ this.isMaxHeap))
            {
              nodes[obj0] = node2;
              node2.index = obj0;
              obj0 = index1;
            }
            else
              break;
          }
          else if ((double) num3 != (double) num1 && !((double) num3 > (double) num1 ^ this.isMaxHeap))
          {
            nodes[obj0] = node3;
            node3.index = obj0;
            obj0 = index2;
          }
          else
            break;
        }
        else
          break;
      }
      nodes[obj0] = node1;
      node1.index = obj0;
    }

    [LineNumberTable(new byte[] {159, 153, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BinaryHeap()
      : this(16, false)
    {
    }

    [Signature("(TT;F)TT;")]
    [LineNumberTable(new byte[] {159, 176, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BinaryHeap.Node add(BinaryHeap.Node node, float value)
    {
      node.value = value;
      return this.add(node);
    }

    [Signature("(TT;Z)Z")]
    [LineNumberTable(new byte[] {159, 131, 66, 102, 117, 44, 168, 117, 44, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(BinaryHeap.Node node, bool identity)
    {
      if (identity || node == null)
      {
        BinaryHeap.Node[] nodes = this.nodes;
        int length = nodes.Length;
        for (int index = 0; index < length; ++index)
        {
          if (object.ReferenceEquals((object) nodes[index], (object) node))
            return true;
        }
      }
      else
      {
        BinaryHeap.Node[] nodes = this.nodes;
        int length = nodes.Length;
        for (int index = 0; index < length; ++index)
        {
          if (Object.instancehelper_equals((object) nodes[index], (object) node))
            return true;
        }
      }
      return false;
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {5, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BinaryHeap.Node peek()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("The heap is empty.");
      }
      return this.nodes[0];
    }

    [Signature("()TT;")]
    [LineNumberTable(60)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BinaryHeap.Node pop() => this.remove(0);

    [Signature("(TT;)TT;")]
    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BinaryHeap.Node remove(BinaryHeap.Node node) => this.remove(node.index);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [LineNumberTable(new byte[] {32, 103, 109, 36, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      BinaryHeap.Node[] nodes = this.nodes;
      int index = 0;
      for (int size = this.size; index < size; ++index)
        nodes[index] = (BinaryHeap.Node) null;
      this.size = 0;
    }

    [Signature("(TT;F)V")]
    [LineNumberTable(new byte[] {39, 103, 104, 110, 142, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(BinaryHeap.Node node, float value)
    {
      float num = node.value;
      node.value = value;
      if ((double) value < (double) num ^ this.isMaxHeap)
        this.up(node.index);
      else
        this.down(node.index);
    }

    [LineNumberTable(new byte[] {112, 106, 103, 112, 109, 62, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (!(obj is BinaryHeap))
        return false;
      BinaryHeap binaryHeap = (BinaryHeap) obj;
      if (binaryHeap.size != this.size)
        return false;
      int index = 0;
      for (int size = this.size; index < size; ++index)
      {
        if ((double) binaryHeap.nodes[index].value != (double) this.nodes[index].value)
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {121, 98, 109, 56, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num = 1;
      int index = 0;
      for (int size = this.size; index < size; ++index)
        num = num * 31 + Float.floatToIntBits(this.nodes[index].value);
      return num;
    }

    [LineNumberTable(new byte[] {160, 64, 110, 103, 104, 105, 111, 107, 108, 15, 198, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      BinaryHeap.Node[] nodes = this.nodes;
      StringBuilder stringBuilder = new StringBuilder(32);
      stringBuilder.append('[');
      stringBuilder.append(nodes[0].value);
      for (int index = 1; index < this.size; ++index)
      {
        stringBuilder.append(", ");
        stringBuilder.append(nodes[index].value);
      }
      stringBuilder.append(']');
      return stringBuilder.toString();
    }

    public class Node : Object
    {
      internal float value;
      internal int index;

      [LineNumberTable(new byte[] {160, 82, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Node(float value)
      {
        BinaryHeap.Node node = this;
        this.value = value;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float getValue() => this.value;

      [LineNumberTable(205)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => Float.toString(this.value);
    }
  }
}
