// Decompiled with JetBrains decompiler
// Type: rhino.optimizer.Block
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using rhino.ast;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.optimizer
{
  internal class Block : Object
  {
    private Block[] itsSuccessors;
    private Block[] itsPredecessors;
    [Modifiers]
    private int itsStartNodeIndex;
    [Modifiers]
    private int itsEndNodeIndex;
    private int itsBlockID;
    private BitSet itsLiveOnEntrySet;
    private BitSet itsLiveOnExitSet;
    private BitSet itsUseBeforeDefSet;
    private BitSet itsNotDefSet;
    internal const bool DEBUG = false;
    private static int debug_blockCount;

    [LineNumberTable(new byte[] {53, 102, 166, 130, 106, 159, 21, 103, 107, 111, 140, 136, 98, 226, 70, 105, 111, 140, 136, 228, 41, 233, 93, 101, 108, 111, 140, 232, 69, 110, 147, 112, 137, 112, 117, 105, 201, 175, 110, 111, 111, 105, 233, 44, 233, 88, 141, 109, 116, 105, 110, 110, 105, 231, 58, 235, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Block[] buildBlocks([In] Node[] obj0)
    {
      HashMap hashMap = new HashMap();
      ObjArray objArray = new ObjArray();
      int index1 = 0;
      for (int index2 = 0; index2 < obj0.Length; ++index2)
      {
        switch (obj0[index2].getType())
        {
          case 5:
          case 6:
          case 7:
            Block.FatBlock fatBlock1 = Block.newFatBlock(index1, index2);
            if (obj0[index1].getType() == 132)
              ((Map) hashMap).put((object) obj0[index1], (object) fatBlock1);
            objArray.add((object) fatBlock1);
            index1 = index2 + 1;
            break;
          case 132:
            if (index2 != index1)
            {
              Block.FatBlock fatBlock2 = Block.newFatBlock(index1, index2 - 1);
              if (obj0[index1].getType() == 132)
                ((Map) hashMap).put((object) obj0[index1], (object) fatBlock2);
              objArray.add((object) fatBlock2);
              index1 = index2;
              break;
            }
            break;
        }
      }
      if (index1 != obj0.Length)
      {
        Block.FatBlock fatBlock = Block.newFatBlock(index1, obj0.Length - 1);
        if (obj0[index1].getType() == 132)
          ((Map) hashMap).put((object) obj0[index1], (object) fatBlock);
        objArray.add((object) fatBlock);
      }
      for (int index2 = 0; index2 < objArray.size(); ++index2)
      {
        Block.FatBlock fatBlock1 = (Block.FatBlock) objArray.get(index2);
        Node node = obj0[fatBlock1.realBlock.itsEndNodeIndex];
        int type = node.getType();
        if (type != 5 && index2 < objArray.size() - 1)
        {
          Block.FatBlock fatBlock2 = (Block.FatBlock) objArray.get(index2 + 1);
          fatBlock1.addSuccessor(fatBlock2);
          fatBlock2.addPredecessor(fatBlock1);
        }
        if (type == 7 || type == 6 || type == 5)
        {
          Node target = ((Jump) node).target;
          Block.FatBlock fatBlock2 = (Block.FatBlock) ((Map) hashMap).get((object) target);
          target.putProp(6, (object) fatBlock2.realBlock);
          fatBlock1.addSuccessor(fatBlock2);
          fatBlock2.addPredecessor(fatBlock1);
        }
      }
      Block[] blockArray = new Block[objArray.size()];
      for (int index2 = 0; index2 < objArray.size(); ++index2)
      {
        Block.FatBlock fatBlock = (Block.FatBlock) objArray.get(index2);
        Block realBlock = fatBlock.realBlock;
        realBlock.itsSuccessors = fatBlock.getSuccessors();
        realBlock.itsPredecessors = fatBlock.getPredecessors();
        realBlock.itsBlockID = index2;
        blockArray[index2] = realBlock;
      }
      return blockArray;
    }

    [LineNumberTable(new byte[] {160, 122, 111, 40, 230, 72, 105, 105, 101, 99, 133, 111, 101, 101, 109, 106, 100, 121, 105, 102, 234, 61, 232, 72, 99, 100, 101, 232, 69, 233, 73, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void reachingDefDataFlow(
      [In] OptFunctionNode obj0,
      [In] Node[] obj1,
      [In] Block[] obj2,
      [In] int[] obj3)
    {
      Block[] blockArray1 = obj2;
      int length1 = blockArray1.Length;
      for (int index = 0; index < length1; ++index)
        blockArray1[index].initLiveOnEntrySets(obj0, obj1);
      bool[] flagArray1 = new bool[obj2.Length];
      bool[] flagArray2 = new bool[obj2.Length];
      int index1 = obj2.Length - 1;
      int num = 0;
      flagArray1[index1] = true;
      while (true)
      {
        if (flagArray1[index1] || !flagArray2[index1])
        {
          flagArray2[index1] = true;
          flagArray1[index1] = false;
          if (obj2[index1].doReachedUseDataFlow())
          {
            Block[] itsPredecessors = obj2[index1].itsPredecessors;
            if (itsPredecessors != null)
            {
              Block[] blockArray2 = itsPredecessors;
              int length2 = blockArray2.Length;
              for (int index2 = 0; index2 < length2; ++index2)
              {
                int itsBlockId = blockArray2[index2].itsBlockID;
                flagArray1[itsBlockId] = true;
                num |= itsBlockId > index1 ? 1 : 0;
              }
            }
          }
        }
        if (index1 == 0)
        {
          if (num != 0)
          {
            index1 = obj2.Length - 1;
            num = 0;
          }
          else
            break;
        }
        else
          index1 += -1;
      }
      obj2[0].markAnyTypeVariables(obj3);
    }

    [LineNumberTable(new byte[] {160, 172, 104, 104, 98, 98, 132, 109, 100, 100, 112, 106, 100, 121, 105, 101, 232, 61, 232, 72, 103, 99, 98, 231, 69, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void typeFlow([In] OptFunctionNode obj0, [In] Node[] obj1, [In] Block[] obj2, [In] int[] obj3)
    {
      bool[] flagArray1 = new bool[obj2.Length];
      bool[] flagArray2 = new bool[obj2.Length];
      int index1 = 0;
      int num = 0;
      flagArray1[index1] = true;
      while (true)
      {
        if (flagArray1[index1] || !flagArray2[index1])
        {
          flagArray2[index1] = true;
          flagArray1[index1] = false;
          if (obj2[index1].doTypeFlow(obj0, obj1, obj3))
          {
            Block[] itsSuccessors = obj2[index1].itsSuccessors;
            if (itsSuccessors != null)
            {
              Block[] blockArray = itsSuccessors;
              int length = blockArray.Length;
              for (int index2 = 0; index2 < length; ++index2)
              {
                int itsBlockId = blockArray[index2].itsBlockID;
                flagArray1[itsBlockId] = true;
                num |= itsBlockId < index1 ? 1 : 0;
              }
            }
          }
        }
        if (index1 == obj2.Length - 1)
        {
          if (num != 0)
          {
            index1 = 0;
            num = 0;
          }
          else
            break;
        }
        else
          ++index1;
      }
    }

    [LineNumberTable(new byte[] {160, 73, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Block.FatBlock newFatBlock([In] int obj0, [In] int obj1) => new Block.FatBlock((Block.\u0031) null)
    {
      realBlock = new Block(obj0, obj1)
    };

    [LineNumberTable(new byte[] {1, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Block([In] int obj0, [In] int obj1)
    {
      Block block = this;
      this.itsStartNodeIndex = obj0;
      this.itsEndNodeIndex = obj1;
    }

    [LineNumberTable(new byte[] {161, 24, 103, 108, 108, 108, 108, 112, 100, 8, 198, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initLiveOnEntrySets([In] OptFunctionNode obj0, [In] Node[] obj1)
    {
      int varCount = obj0.getVarCount();
      this.itsUseBeforeDefSet = new BitSet(varCount);
      this.itsNotDefSet = new BitSet(varCount);
      this.itsLiveOnEntrySet = new BitSet(varCount);
      this.itsLiveOnExitSet = new BitSet(varCount);
      for (int itsStartNodeIndex = this.itsStartNodeIndex; itsStartNodeIndex <= this.itsEndNodeIndex; ++itsStartNodeIndex)
      {
        Node node = obj1[itsStartNodeIndex];
        this.lookForVariableAccess(obj0, node);
      }
      this.itsNotDefSet.flip(0, varCount);
    }

    [LineNumberTable(new byte[] {161, 43, 107, 104, 116, 49, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool doReachedUseDataFlow()
    {
      this.itsLiveOnExitSet.clear();
      if (this.itsSuccessors != null)
      {
        Block[] itsSuccessors = this.itsSuccessors;
        int length = itsSuccessors.Length;
        for (int index = 0; index < length; ++index)
          this.itsLiveOnExitSet.or(itsSuccessors[index].itsLiveOnEntrySet);
      }
      return Block.updateEntrySet(this.itsLiveOnEntrySet, this.itsLiveOnExitSet, this.itsUseBeforeDefSet, this.itsNotDefSet);
    }

    [LineNumberTable(new byte[] {160, 211, 103, 110, 9, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void markAnyTypeVariables([In] int[] obj0)
    {
      for (int index = 0; index != obj0.Length; ++index)
      {
        if (this.itsLiveOnEntrySet.get(index))
          Block.assignType(obj0, index, 3);
      }
    }

    [LineNumberTable(new byte[] {161, 202, 130, 112, 100, 99, 235, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool doTypeFlow([In] OptFunctionNode obj0, [In] Node[] obj1, [In] int[] obj2)
    {
      int num = 0;
      for (int itsStartNodeIndex = this.itsStartNodeIndex; itsStartNodeIndex <= this.itsEndNodeIndex; ++itsStartNodeIndex)
      {
        Node node = obj1[itsStartNodeIndex];
        if (node != null)
          num |= Block.findDefPoints(obj0, node, obj2) ? 1 : 0;
      }
      return num != 0;
    }

    [LineNumberTable(new byte[] {160, 206, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool assignType([In] int[] obj0, [In] int obj1, [In] int obj2)
    {
      int num1 = obj0[obj1];
      int[] numArray1 = obj0;
      int index1 = obj1;
      int[] numArray2 = numArray1;
      int[] numArray3 = numArray2;
      int num2 = index1;
      int num3 = numArray2[index1] | obj2;
      int index2 = num2;
      int[] numArray4 = numArray3;
      int num4 = num3;
      numArray4[index2] = num3;
      return num1 != num4;
    }

    [LineNumberTable(new byte[] {160, 228, 223, 44, 109, 114, 140, 165, 103, 106, 104, 110, 108, 108, 98, 168, 165, 103, 103, 104, 146, 130, 104, 110, 140, 130, 103, 99, 104, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lookForVariableAccess([In] OptFunctionNode obj0, [In] Node obj1)
    {
      switch (obj1.getType())
      {
        case 55:
          int varIndex1 = obj0.getVarIndex(obj1);
          if (this.itsNotDefSet.get(varIndex1))
            break;
          this.itsUseBeforeDefSet.set(varIndex1);
          break;
        case 56:
        case 157:
          Node next = obj1.getFirstChild().getNext();
          this.lookForVariableAccess(obj0, next);
          this.itsNotDefSet.set(obj0.getVarIndex(obj1));
          break;
        case 107:
        case 108:
          Node firstChild = obj1.getFirstChild();
          if (firstChild.getType() == 55)
          {
            int varIndex2 = obj0.getVarIndex(firstChild);
            if (!this.itsNotDefSet.get(varIndex2))
              this.itsUseBeforeDefSet.set(varIndex2);
            this.itsNotDefSet.set(varIndex2);
            break;
          }
          this.lookForVariableAccess(obj0, firstChild);
          break;
        case 138:
          int indexForNameNode = obj0.__\u003C\u003Efnode.getIndexForNameNode(obj1);
          if (indexForNameNode <= -1 || this.itsNotDefSet.get(indexForNameNode))
            break;
          this.itsUseBeforeDefSet.set(indexForNameNode);
          break;
        default:
          for (Node node = obj1.getFirstChild(); node != null; node = node.getNext())
            this.lookForVariableAccess(obj0, node);
          break;
      }
    }

    [LineNumberTable(new byte[] {161, 55, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool updateEntrySet([In] BitSet obj0, [In] BitSet obj1, [In] BitSet obj2, [In] BitSet obj3)
    {
      int num = obj0.cardinality();
      obj0.or(obj1);
      obj0.and(obj3);
      obj0.or(obj2);
      return obj0.cardinality() != num;
    }

    [LineNumberTable(new byte[] {161, 70, 255, 162, 15, 82, 226, 105, 162, 234, 73, 103, 105, 110, 196, 108, 103, 105, 106, 229, 73, 174})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int findExpressionType([In] OptFunctionNode obj0, [In] Node obj1, [In] int[] obj2)
    {
      switch (obj1.getType())
      {
        case 8:
        case 35:
        case 37:
        case 56:
        case 90:
        case 157:
          return Block.findExpressionType(obj0, obj1.getLastChild(), obj2);
        case 9:
        case 10:
        case 11:
        case 18:
        case 19:
        case 20:
        case 22:
        case 23:
        case 24:
        case 25:
        case 27:
        case 28:
        case 29:
        case 40:
        case 107:
        case 108:
          return 1;
        case 12:
        case 13:
        case 14:
        case 15:
        case 16:
        case 17:
        case 26:
        case 30:
        case 31:
        case 32:
        case 33:
        case 36:
        case 38:
        case 39:
        case 41:
        case 42:
        case 43:
        case 44:
        case 45:
        case 46:
        case 47:
        case 48:
        case 52:
        case 53:
        case 66:
        case 67:
        case 70:
        case 71:
        case (int) sbyte.MaxValue:
        case 138:
        case 158:
          return 3;
        case 21:
        case 105:
        case 106:
          Node firstChild = obj1.getFirstChild();
          return Block.findExpressionType(obj0, firstChild, obj2) | Block.findExpressionType(obj0, firstChild.getNext(), obj2);
        case 55:
          return obj2[obj0.getVarIndex(obj1)];
        case 103:
          Node next1 = obj1.getFirstChild().getNext();
          Node next2 = next1.getNext();
          return Block.findExpressionType(obj0, next1, obj2) | Block.findExpressionType(obj0, next2, obj2);
        default:
          return 3;
      }
    }

    [LineNumberTable(new byte[] {161, 169, 98, 103, 101, 43, 169, 191, 19, 141, 104, 111, 139, 194, 103, 106, 105, 112, 106, 239, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool findDefPoints([In] OptFunctionNode obj0, [In] Node obj1, [In] int[] obj2)
    {
      int num = 0;
      Node firstChild = obj1.getFirstChild();
      for (Node node = firstChild; node != null; node = node.getNext())
        num |= Block.findDefPoints(obj0, node, obj2) ? 1 : 0;
      switch (obj1.getType())
      {
        case 56:
        case 157:
          Node next = firstChild.getNext();
          int expressionType = Block.findExpressionType(obj0, next, obj2);
          int varIndex1 = obj0.getVarIndex(obj1);
          if (obj1.getType() != 56 || !obj0.__\u003C\u003Efnode.getParamAndVarConst()[varIndex1])
          {
            num |= Block.assignType(obj2, varIndex1, expressionType) ? 1 : 0;
            break;
          }
          break;
        case 107:
        case 108:
          if (firstChild.getType() == 55)
          {
            int varIndex2 = obj0.getVarIndex(firstChild);
            if (!obj0.__\u003C\u003Efnode.getParamAndVarConst()[varIndex2])
            {
              num |= Block.assignType(obj2, varIndex2, 1) ? 1 : 0;
              break;
            }
            break;
          }
          break;
      }
      return num != 0;
    }

    [LineNumberTable(new byte[] {7, 108, 108, 135, 102, 36, 230, 69, 102, 36, 198, 232, 73, 106, 234, 77, 104, 103, 8, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void runFlowAnalyzes([In] OptFunctionNode obj0, [In] Node[] obj1)
    {
      int paramCount = obj0.__\u003C\u003Efnode.getParamCount();
      int paramAndVarCount = obj0.__\u003C\u003Efnode.getParamAndVarCount();
      int[] numArray = new int[paramAndVarCount];
      for (int index = 0; index != paramCount; ++index)
        numArray[index] = 3;
      for (int index = paramCount; index != paramAndVarCount; ++index)
        numArray[index] = 0;
      Block[] blockArray = Block.buildBlocks(obj1);
      Block.reachingDefDataFlow(obj0, obj1, blockArray, numArray);
      Block.typeFlow(obj0, obj1, blockArray, numArray);
      for (int index = paramCount; index != paramAndVarCount; ++index)
      {
        if (numArray[index] == 1)
          obj0.setIsNumberVar(index);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string toString([In] Block[] obj0, [In] Node[] obj1) => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void printLiveOnEntrySet([In] OptFunctionNode obj0)
    {
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      \u0031() => throw null;
    }

    [InnerClass]
    internal class FatBlock : Object
    {
      [Modifiers]
      private ObjToIntMap successors;
      [Modifiers]
      private ObjToIntMap predecessors;
      internal Block realBlock;

      [LineNumberTable(new byte[] {159, 170, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void addSuccessor([In] Block.FatBlock obj0) => this.successors.put((object) obj0, 0);

      [LineNumberTable(new byte[] {159, 174, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void addPredecessor([In] Block.FatBlock obj0) => this.predecessors.put((object) obj0, 0);

      [LineNumberTable(36)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual Block[] getSuccessors() => Block.FatBlock.reduceToArray(this.successors);

      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual Block[] getPredecessors() => Block.FatBlock.reduceToArray(this.predecessors);

      [Modifiers]
      [LineNumberTable(11)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal FatBlock([In] Block.\u0031 obj0)
        : this()
      {
      }

      [LineNumberTable(new byte[] {159, 153, 232, 97, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private FatBlock()
      {
        Block.FatBlock fatBlock = this;
        this.successors = new ObjToIntMap();
        this.predecessors = new ObjToIntMap();
      }

      [LineNumberTable(new byte[] {159, 156, 98, 104, 108, 98, 103, 110, 113, 13, 232, 69})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static Block[] reduceToArray([In] ObjToIntMap obj0)
      {
        Block[] blockArray1 = (Block[]) null;
        if (!obj0.isEmpty())
        {
          blockArray1 = new Block[obj0.size()];
          int num = 0;
          ObjToIntMap.Iterator iterator = obj0.newIterator();
          iterator.start();
          while (!iterator.done())
          {
            Block.FatBlock key = (Block.FatBlock) iterator.getKey();
            Block[] blockArray2 = blockArray1;
            int index = num;
            ++num;
            Block realBlock = key.realBlock;
            blockArray2[index] = realBlock;
            iterator.next();
          }
        }
        return blockArray1;
      }
    }
  }
}
