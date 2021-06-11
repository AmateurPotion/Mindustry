// Decompiled with JetBrains decompiler
// Type: rhino.optimizer.Optimizer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using rhino.ast;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.optimizer
{
  internal class Optimizer : Object
  {
    internal const int NoType = 0;
    internal const int NumberType = 1;
    internal const int AnyType = 3;
    private bool inDirectCallFunction;
    internal OptFunctionNode theFunction;
    private bool parameterUsedInNumberContext;

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Optimizer()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 103, 102, 104, 7, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void optimize([In] ScriptNode obj0)
    {
      int functionCount = obj0.getFunctionCount();
      for (int i = 0; i != functionCount; ++i)
        this.optimizeFunction(OptFunctionNode.get(obj0, i));
    }

    [LineNumberTable(new byte[] {159, 166, 142, 108, 135, 102, 108, 108, 135, 135, 237, 72, 103, 115, 42, 168, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void optimizeFunction([In] OptFunctionNode obj0)
    {
      if (obj0.__\u003C\u003Efnode.requiresActivation())
        return;
      this.inDirectCallFunction = obj0.isTargetOfDirectCall();
      this.theFunction = obj0;
      ObjArray objArray = new ObjArray();
      Optimizer.buildStatementList_r((Node) obj0.__\u003C\u003Efnode, objArray);
      Node[] nodeArray1 = new Node[objArray.size()];
      objArray.toArray((object[]) nodeArray1);
      Block.runFlowAnalyzes(obj0, nodeArray1);
      if (obj0.__\u003C\u003Efnode.requiresActivation())
        return;
      this.parameterUsedInNumberContext = false;
      Node[] nodeArray2 = nodeArray1;
      int length = nodeArray2.Length;
      for (int index = 0; index < length; ++index)
        this.rewriteForNumberVariables(nodeArray2[index], 1);
      obj0.setParameterNumberContext(this.parameterUsedInNumberContext);
    }

    [LineNumberTable(new byte[] {161, 47, 103, 221, 103, 99, 103, 137, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void buildStatementList_r([In] Node obj0, [In] ObjArray obj1)
    {
      switch (obj0.getType())
      {
        case 110:
        case 130:
        case 133:
        case 142:
          for (Node node = obj0.getFirstChild(); node != null; node = node.getNext())
            Optimizer.buildStatementList_r(node, obj1);
          break;
        default:
          obj1.add((object) obj0);
          break;
      }
    }

    [LineNumberTable(new byte[] {56, 159, 160, 198, 103, 105, 100, 104, 162, 104, 162, 109, 111, 139, 104, 98, 110, 104, 130, 226, 69, 103, 105, 106, 109, 104, 103, 130, 98, 107, 105, 130, 194, 103, 103, 106, 110, 112, 103, 101, 105, 104, 130, 103, 130, 99, 111, 101, 103, 177, 104, 103, 130, 101, 105, 103, 209, 226, 71, 103, 103, 106, 106, 103, 135, 105, 105, 98, 101, 138, 105, 101, 170, 101, 101, 138, 170, 101, 232, 69, 194, 103, 103, 106, 170, 105, 105, 130, 101, 170, 105, 101, 170, 101, 101, 104, 130, 138, 101, 232, 70, 226, 76, 103, 103, 106, 106, 103, 103, 101, 101, 104, 130, 105, 103, 145, 136, 130, 101, 105, 103, 145, 136, 130, 105, 103, 177, 105, 103, 177, 104, 194, 103, 103, 104, 106, 101, 105, 103, 209, 106, 101, 201, 168, 107, 101, 106, 104, 210, 162, 103, 103, 106, 101, 105, 103, 209, 106, 101, 201, 168, 162, 135, 109, 135, 99, 108, 228, 69, 99, 106, 101, 135, 103, 130, 136, 162, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int rewriteForNumberVariables([In] Node obj0, [In] int obj1)
    {
      switch (obj0.getType())
      {
        case 9:
        case 10:
        case 11:
        case 18:
        case 19:
        case 22:
        case 23:
        case 24:
        case 25:
          Node firstChild1 = obj0.getFirstChild();
          Node next1 = firstChild1.getNext();
          int num1 = this.rewriteForNumberVariables(firstChild1, 1);
          int num2 = this.rewriteForNumberVariables(next1, 1);
          this.markDCPNumberContext(firstChild1);
          this.markDCPNumberContext(next1);
          if (num1 == 1)
          {
            if (num2 == 1)
            {
              obj0.putIntProp(8, 0);
              return 1;
            }
            if (!this.convertParameter(next1))
            {
              obj0.removeChild(next1);
              obj0.addChildToBack(new Node(151, next1));
              obj0.putIntProp(8, 0);
            }
            return 1;
          }
          if (num2 == 1)
          {
            if (!this.convertParameter(firstChild1))
            {
              obj0.removeChild(firstChild1);
              obj0.addChildToFront(new Node(151, firstChild1));
              obj0.putIntProp(8, 0);
            }
            return 1;
          }
          if (!this.convertParameter(firstChild1))
          {
            obj0.removeChild(firstChild1);
            obj0.addChildToFront(new Node(151, firstChild1));
          }
          if (!this.convertParameter(next1))
          {
            obj0.removeChild(next1);
            obj0.addChildToBack(new Node(151, next1));
          }
          obj0.putIntProp(8, 0);
          return 1;
        case 14:
        case 15:
        case 16:
        case 17:
          Node firstChild2 = obj0.getFirstChild();
          Node next2 = firstChild2.getNext();
          int num3 = this.rewriteForNumberVariables(firstChild2, 1);
          int num4 = this.rewriteForNumberVariables(next2, 1);
          this.markDCPNumberContext(firstChild2);
          this.markDCPNumberContext(next2);
          if (this.convertParameter(firstChild2))
          {
            if (this.convertParameter(next2) || num4 != 1)
              return 0;
            obj0.putIntProp(8, 2);
          }
          else if (this.convertParameter(next2))
          {
            if (num3 == 1)
              obj0.putIntProp(8, 1);
          }
          else if (num3 == 1)
          {
            if (num4 == 1)
              obj0.putIntProp(8, 0);
            else
              obj0.putIntProp(8, 1);
          }
          else if (num4 == 1)
            obj0.putIntProp(8, 2);
          return 0;
        case 21:
          Node firstChild3 = obj0.getFirstChild();
          Node next3 = firstChild3.getNext();
          int num5 = this.rewriteForNumberVariables(firstChild3, 1);
          int num6 = this.rewriteForNumberVariables(next3, 1);
          if (this.convertParameter(firstChild3))
          {
            if (this.convertParameter(next3) || num6 != 1)
              return 0;
            obj0.putIntProp(8, 2);
          }
          else if (this.convertParameter(next3))
          {
            if (num5 == 1)
              obj0.putIntProp(8, 1);
          }
          else if (num5 == 1)
          {
            if (num6 == 1)
            {
              obj0.putIntProp(8, 0);
              return 1;
            }
            obj0.putIntProp(8, 1);
          }
          else if (num6 == 1)
            obj0.putIntProp(8, 2);
          return 0;
        case 36:
          Node firstChild4 = obj0.getFirstChild();
          Node next4 = firstChild4.getNext();
          if (this.rewriteForNumberVariables(firstChild4, 1) == 1 && !this.convertParameter(firstChild4))
          {
            obj0.removeChild(firstChild4);
            obj0.addChildToFront(new Node(150, firstChild4));
          }
          if (this.rewriteForNumberVariables(next4, 1) == 1 && !this.convertParameter(next4))
            obj0.putIntProp(8, 2);
          return 0;
        case 37:
        case 141:
          Node firstChild5 = obj0.getFirstChild();
          Node next5 = firstChild5.getNext();
          Node next6 = next5.getNext();
          if (this.rewriteForNumberVariables(firstChild5, 1) == 1 && !this.convertParameter(firstChild5))
          {
            obj0.removeChild(firstChild5);
            obj0.addChildToFront(new Node(150, firstChild5));
          }
          if (this.rewriteForNumberVariables(next5, 1) == 1 && !this.convertParameter(next5))
            obj0.putIntProp(8, 1);
          if (this.rewriteForNumberVariables(next6, 1) == 1 && !this.convertParameter(next6))
          {
            obj0.removeChild(next6);
            obj0.addChildToBack(new Node(150, next6));
          }
          return 0;
        case 38:
          Node firstChild6 = obj0.getFirstChild();
          this.rewriteAsObjectChildren(firstChild6, firstChild6.getFirstChild());
          Node next7 = firstChild6.getNext();
          if ((OptFunctionNode) obj0.getProp(9) != null)
          {
            for (; next7 != null; next7 = next7.getNext())
            {
              if (this.rewriteForNumberVariables(next7, 1) == 1)
                this.markDCPNumberContext(next7);
            }
          }
          else
            this.rewriteAsObjectChildren(obj0, next7);
          return 0;
        case 40:
          obj0.putIntProp(8, 0);
          return 1;
        case 55:
          int varIndex1 = this.theFunction.getVarIndex(obj0);
          if (this.inDirectCallFunction && this.theFunction.isParameter(varIndex1) && obj1 == 1)
          {
            obj0.putIntProp(8, 0);
            return 1;
          }
          if (!this.theFunction.isNumberVar(varIndex1))
            return 0;
          obj0.putIntProp(8, 0);
          return 1;
        case 56:
        case 157:
          Node next8 = obj0.getFirstChild().getNext();
          int num7 = this.rewriteForNumberVariables(next8, 1);
          int varIndex2 = this.theFunction.getVarIndex(obj0);
          if (this.inDirectCallFunction && this.theFunction.isParameter(varIndex2))
          {
            if (num7 != 1)
              return num7;
            if (!this.convertParameter(next8))
            {
              obj0.putIntProp(8, 0);
              return 1;
            }
            this.markDCPNumberContext(next8);
            return 0;
          }
          if (this.theFunction.isNumberVar(varIndex2))
          {
            if (num7 != 1)
            {
              obj0.removeChild(next8);
              obj0.addChildToBack(new Node(151, next8));
            }
            obj0.putIntProp(8, 0);
            this.markDCPNumberContext(next8);
            return 1;
          }
          if (num7 == 1 && !this.convertParameter(next8))
          {
            obj0.removeChild(next8);
            obj0.addChildToBack(new Node(150, next8));
          }
          return 0;
        case 107:
        case 108:
          Node firstChild7 = obj0.getFirstChild();
          int num8 = this.rewriteForNumberVariables(firstChild7, 1);
          if (firstChild7.getType() == 55)
          {
            if (num8 != 1 || this.convertParameter(firstChild7))
              return 0;
            obj0.putIntProp(8, 0);
            this.markDCPNumberContext(firstChild7);
            return 1;
          }
          return firstChild7.getType() == 36 || firstChild7.getType() == 33 ? num8 : 0;
        case 134:
          if (this.rewriteForNumberVariables(obj0.getFirstChild(), 1) == 1)
            obj0.putIntProp(8, 0);
          return 0;
        default:
          this.rewriteAsObjectChildren(obj0, obj0.getFirstChild());
          return 0;
      }
    }

    [LineNumberTable(new byte[] {45, 114, 109, 110, 103, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool convertParameter([In] Node obj0)
    {
      if (!this.inDirectCallFunction || obj0.getType() != 55 || !this.theFunction.isParameter(this.theFunction.getVarIndex(obj0)))
        return false;
      obj0.removeProp(8);
      return true;
    }

    [LineNumberTable(new byte[] {36, 114, 109, 110, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void markDCPNumberContext([In] Node obj0)
    {
      if (!this.inDirectCallFunction || obj0.getType() != 55 || !this.theFunction.isParameter(this.theFunction.getVarIndex(obj0)))
        return;
      this.parameterUsedInNumberContext = true;
    }

    [LineNumberTable(new byte[] {161, 29, 99, 103, 105, 100, 105, 103, 108, 99, 137, 168, 99, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rewriteAsObjectChildren([In] Node obj0, [In] Node obj1)
    {
      Node next;
      for (; obj1 != null; obj1 = next)
      {
        next = obj1.getNext();
        if (this.rewriteForNumberVariables(obj1, 0) == 1 && !this.convertParameter(obj1))
        {
          obj0.removeChild(obj1);
          Node node = new Node(150, obj1);
          if (next == null)
            obj0.addChildToBack(node);
          else
            obj0.addChildBefore(node, next);
        }
      }
    }
  }
}
