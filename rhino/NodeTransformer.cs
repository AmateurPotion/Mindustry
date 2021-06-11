// Decompiled with JetBrains decompiler
// Type: rhino.NodeTransformer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using rhino.ast;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class NodeTransformer : Object
  {
    private ObjArray loops;
    private ObjArray loopEnds;
    private bool hasFinally;

    [LineNumberTable(new byte[] {159, 157, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NodeTransformer()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void transform(ScriptNode tree, CompilerEnvirons env) => this.transform(tree, false, env);

    [LineNumberTable(new byte[] {159, 137, 162, 194, 117, 130, 104, 107, 104, 9, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void transform(ScriptNode tree, bool inStrictMode, CompilerEnvirons env)
    {
      int num = inStrictMode ? 1 : 0;
      if (env.getLanguageVersion() >= 200 && tree.isInStrictMode())
        num = 1;
      this.transformCompilationUnit(tree, num != 0);
      for (int i = 0; i != tree.getFunctionCount(); ++i)
        this.transform((ScriptNode) tree.getFunctionNode(i), num != 0, env);
    }

    [LineNumberTable(new byte[] {159, 133, 130, 107, 171, 167, 112, 108, 205, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void transformCompilationUnit([In] ScriptNode obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      this.loops = new ObjArray();
      this.loopEnds = new ObjArray();
      this.hasFinally = false;
      int num2 = obj0.getType() != 110 || ((FunctionNode) obj0).requiresActivation() ? 1 : 0;
      obj0.flattenSymbolTable(num2 == 0);
      this.transformCompilationUnit_r(obj0, (Node) obj0, (Scope) obj0, num2 != 0, num1 != 0);
    }

    [LineNumberTable(new byte[] {159, 127, 70, 162, 98, 99, 137, 98, 135, 99, 165, 104, 223, 16, 104, 172, 159, 2, 108, 105, 127, 11, 112, 98, 104, 99, 107, 104, 201, 255, 160, 208, 69, 108, 118, 165, 108, 104, 106, 134, 109, 197, 104, 105, 103, 103, 108, 242, 71, 127, 7, 108, 241, 70, 108, 165, 112, 109, 100, 233, 73, 104, 101, 99, 119, 116, 105, 143, 102, 108, 110, 105, 100, 98, 136, 100, 107, 140, 233, 47, 235, 84, 103, 99, 105, 107, 104, 142, 110, 105, 105, 137, 236, 69, 229, 71, 104, 105, 138, 109, 196, 139, 102, 116, 107, 165, 105, 102, 104, 139, 104, 105, 108, 110, 171, 133, 102, 144, 142, 137, 197, 104, 165, 104, 197, 104, 174, 112, 109, 108, 229, 71, 108, 175, 100, 105, 107, 105, 98, 105, 105, 106, 223, 2, 162, 110, 139, 121, 105, 101, 107, 197, 110, 100, 168, 229, 72, 104, 104, 107, 139, 109, 108, 105, 105, 109, 113, 102, 109, 113, 196, 110, 239, 70, 99, 233, 71, 99, 165, 102, 133, 104, 107, 102, 133, 171, 105, 133, 105, 106, 103, 105, 102, 110, 139, 105, 108, 105, 108, 108, 134, 105, 107, 98, 235, 71, 187, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void transformCompilationUnit_r(
      [In] ScriptNode obj0,
      [In] Node obj1,
      [In] Scope obj2,
      [In] bool obj3,
      [In] bool obj4)
    {
      int num1 = obj3 ? 1 : 0;
      int num2 = obj4 ? 1 : 0;
      Node node1 = (Node) null;
      while (true)
      {
        Node previous = (Node) null;
        if (node1 == null)
        {
          node1 = obj1.getFirstChild();
        }
        else
        {
          previous = node1;
          node1 = node1.getNext();
        }
        if (node1 != null)
        {
          int type1 = node1.getType();
          if (num1 != 0 && (type1 == 130 || type1 == 133 || type1 == 158) && node1 is Scope)
          {
            Scope scope = (Scope) node1;
            if (scope.getSymbolTable() != null)
            {
              Node.__\u003Cclinit\u003E();
              Node node2 = new Node(type1 != 158 ? 154 : 159);
              Node child1 = new Node(154);
              node2.addChildToBack(child1);
              Iterator iterator = scope.getSymbolTable().keySet().iterator();
              while (iterator.hasNext())
              {
                string str = (string) iterator.next();
                child1.addChildToBack(Node.newString(39, str));
              }
              scope.setSymbolTable((Map) null);
              Node child2 = node1;
              node1 = NodeTransformer.replaceCurrent(obj1, previous, node1, node2);
              type1 = node1.getType();
              node2.addChildToBack(child2);
            }
          }
          switch (type1)
          {
            case 3:
            case 132:
              if (!this.loopEnds.isEmpty() && object.ReferenceEquals(this.loopEnds.peek(), (object) node1))
              {
                this.loopEnds.pop();
                this.loops.pop();
                break;
              }
              break;
            case 4:
              int num3 = obj0.getType() != 110 || !((FunctionNode) obj0).isGenerator() ? 0 : 1;
              if (num3 != 0)
                node1.putIntProp(20, 1);
              if (this.hasFinally)
              {
                Node node2 = (Node) null;
                for (int index = this.loops.size() - 1; index >= 0; index += -1)
                {
                  Node node3 = (Node) this.loops.get(index);
                  int type2 = node3.getType();
                  switch (type2)
                  {
                    case 82:
                    case 124:
                      Node child;
                      if (type2 == 82)
                        child = (Node) new Jump(136)
                        {
                          target = ((Jump) node3).getFinally()
                        };
                      else
                        child = new Node(3);
                      if (node2 == null)
                      {
                        Node.__\u003Cclinit\u003E();
                        node2 = new Node(130, node1.getLineno());
                      }
                      node2.addChildToBack(child);
                      break;
                  }
                }
                if (node2 != null)
                {
                  Node child1 = node1;
                  Node firstChild = child1.getFirstChild();
                  node1 = NodeTransformer.replaceCurrent(obj1, previous, node1, node2);
                  if (firstChild == null || num3 != 0)
                  {
                    node2.addChildToBack(child1);
                    continue;
                  }
                  Node child2 = new Node(135, firstChild);
                  node2.addChildToFront(child2);
                  Node child3 = new Node(65);
                  node2.addChildToBack(child3);
                  this.transformCompilationUnit_r(obj0, child2, obj2, num1 != 0, num2 != 0);
                  continue;
                }
                break;
              }
              break;
            case 7:
            case 32:
              Node node4 = node1.getFirstChild();
              if (type1 == 7)
              {
                while (node4.getType() == 26)
                  node4 = node4.getFirstChild();
                if (node4.getType() == 12 || node4.getType() == 13)
                {
                  Node firstChild = node4.getFirstChild();
                  Node lastChild = node4.getLastChild();
                  if (firstChild.getType() == 39 && String.instancehelper_equals(firstChild.getString(), (object) "undefined"))
                    node4 = lastChild;
                  else if (lastChild.getType() == 39 && String.instancehelper_equals(lastChild.getString(), (object) "undefined"))
                    node4 = firstChild;
                }
              }
              if (node4.getType() == 33)
              {
                node4.setType(34);
                break;
              }
              break;
            case 8:
              if (num2 != 0)
              {
                node1.setType(74);
                goto case 31;
              }
              else
                goto case 31;
            case 30:
              this.visitNew(node1, obj0);
              break;
            case 31:
            case 39:
            case 156:
              if (num1 == 0)
              {
                Node node2;
                if (type1 == 39)
                {
                  node2 = node1;
                }
                else
                {
                  node2 = node1.getFirstChild();
                  if (node2.getType() != 49)
                  {
                    if (type1 != 31)
                      goto label_80;
                    else
                      break;
                  }
                }
                if (node2.getScope() == null)
                {
                  string name = node2.getString();
                  Scope definingScope = obj2.getDefiningScope(name);
                  if (definingScope != null)
                  {
                    node2.setScope(definingScope);
                    switch (type1)
                    {
                      case 8:
                      case 74:
                        node1.setType(56);
                        node2.setType(41);
                        break;
                      case 31:
                        Node node3 = new Node(44);
                        node1 = NodeTransformer.replaceCurrent(obj1, previous, node1, node3);
                        break;
                      case 39:
                        node1.setType(55);
                        break;
                      case 156:
                        node1.setType(157);
                        node2.setType(41);
                        break;
                      default:
                        goto label_89;
                    }
                  }
                  else
                    break;
                }
                else
                  break;
              }
              else
                break;
              break;
            case 38:
              this.visitCall(node1, obj0);
              break;
            case 73:
            case 166:
              ((FunctionNode) obj0).addResumptionPoint(node1);
              break;
            case 82:
              Node node5 = ((Jump) node1).getFinally();
              if (node5 != null)
              {
                this.hasFinally = true;
                this.loops.push((object) node1);
                this.loopEnds.push((object) node5);
                break;
              }
              break;
            case 115:
            case 131:
            case 133:
              this.loops.push((object) node1);
              this.loopEnds.push((object) ((Jump) node1).target);
              break;
            case 121:
            case 122:
              Jump jump1 = (Jump) node1;
              Jump jumpStatement = jump1.getJumpStatement();
              if (jumpStatement == null)
                Kit.codeBug();
              int index1 = this.loops.size();
              while (index1 != 0)
              {
                index1 += -1;
                Node node2 = (Node) this.loops.get(index1);
                if (!object.ReferenceEquals((object) node2, (object) jumpStatement))
                {
                  switch (node2.getType())
                  {
                    case 82:
                      Jump jump2 = (Jump) node2;
                      previous = NodeTransformer.addBeforeCurrent(obj1, previous, node1, (Node) new Jump(136)
                      {
                        target = jump2.getFinally()
                      });
                      continue;
                    case 124:
                      Node node3 = new Node(3);
                      previous = NodeTransformer.addBeforeCurrent(obj1, previous, node1, node3);
                      continue;
                    default:
                      continue;
                  }
                }
                else
                {
                  jump1.target = type1 != 121 ? jumpStatement.getContinue() : jumpStatement.target;
                  jump1.setType(5);
                  goto label_90;
                }
              }
              goto label_46;
            case 123:
            case 155:
              Node node6 = new Node(130);
              Node node7 = node1.getFirstChild();
              while (node7 != null)
              {
                Node node2 = node7;
                node7 = node7.getNext();
                if (node2.getType() == 39)
                {
                  if (node2.hasChildren())
                  {
                    Node firstChild = node2.getFirstChild();
                    node2.removeChild(firstChild);
                    node2.setType(49);
                    Node.__\u003Cclinit\u003E();
                    node2 = new Node(type1 != 155 ? 8 : 156, node2, firstChild);
                  }
                  else
                    continue;
                }
                else if (node2.getType() != 159)
                  throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
                Node.__\u003Cclinit\u003E();
                Node child = new Node(134, node2, node1.getLineno());
                node6.addChildToBack(child);
              }
              node1 = NodeTransformer.replaceCurrent(obj1, previous, node1, node6);
              break;
            case 124:
              this.loops.push((object) node1);
              Node next = node1.getNext();
              if (next.getType() != 3)
                Kit.codeBug();
              this.loopEnds.push((object) next);
              break;
            case 138:
              Scope definingScope1 = obj2.getDefiningScope(node1.getString());
              if (definingScope1 != null)
              {
                node1.setScope(definingScope1);
                break;
              }
              break;
            case 154:
            case 159:
              if (node1.getFirstChild().getType() == 154)
              {
                node1 = this.visitLet(obj0.getType() != 110 || ((FunctionNode) obj0).requiresActivation(), obj1, previous, node1);
                break;
              }
              goto case 123;
          }
label_90:
          this.transformCompilationUnit_r(obj0, node1, !(node1 is Scope) ? obj2 : (Scope) node1, num1 != 0, num2 != 0);
        }
        else
          break;
      }
      return;
label_46:
      throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
label_80:
      throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
label_89:
      throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
    }

    [LineNumberTable(new byte[] {161, 152, 99, 116, 106, 174, 138, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Node replaceCurrent([In] Node obj0, [In] Node obj1, [In] Node obj2, [In] Node obj3)
    {
      if (obj1 == null)
      {
        if (!object.ReferenceEquals((object) obj2, (object) obj0.getFirstChild()))
          Kit.codeBug();
        obj0.replaceChild(obj2, obj3);
      }
      else if (object.ReferenceEquals((object) obj1.next, (object) obj2))
        obj0.replaceChildAfter(obj1, obj3);
      else
        obj0.replaceChild(obj2, obj3);
      return obj3;
    }

    [LineNumberTable(new byte[] {161, 140, 99, 116, 137, 116, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Node addBeforeCurrent([In] Node obj0, [In] Node obj1, [In] Node obj2, [In] Node obj3)
    {
      if (obj1 == null)
      {
        if (!object.ReferenceEquals((object) obj2, (object) obj0.getFirstChild()))
          Kit.codeBug();
        obj0.addChildToFront(obj3);
      }
      else
      {
        if (!object.ReferenceEquals((object) obj2, (object) obj1.getNext()))
          Kit.codeBug();
        obj0.addChildAfter(obj3, obj1);
      }
      return obj3;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void visitCall(Node node, ScriptNode tree)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void visitNew(Node node, ScriptNode tree)
    {
    }

    [LineNumberTable(new byte[] {159, 43, 162, 104, 103, 104, 104, 175, 102, 123, 109, 103, 105, 111, 100, 145, 100, 108, 105, 153, 99, 151, 118, 241, 69, 100, 106, 110, 110, 42, 37, 232, 69, 137, 118, 116, 105, 100, 152, 233, 31, 238, 99, 112, 106, 105, 111, 109, 101, 120, 109, 105, 111, 100, 145, 105, 153, 99, 151, 118, 209, 147, 137, 118, 110, 110, 105, 100, 152, 242, 38, 238, 92, 99, 105, 106, 105, 104, 107, 109, 114, 110, 133, 115, 109, 105, 104, 104, 109, 114, 206})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Node visitLet(
      bool createWith,
      Node parent,
      Node previous,
      Node scopeNode)
    {
      int num1 = createWith ? 1 : 0;
      Node firstChild1 = scopeNode.getFirstChild();
      Node node1 = firstChild1.getNext();
      scopeNode.removeChild(firstChild1);
      scopeNode.removeChild(node1);
      int num2 = scopeNode.getType() == 159 ? 1 : 0;
      Node node2;
      if (num1 != 0)
      {
        Node.__\u003Cclinit\u003E();
        Node node3 = new Node(num2 == 0 ? 130 : 160);
        node2 = NodeTransformer.replaceCurrent(parent, previous, scopeNode, node3);
        ArrayList arrayList = new ArrayList();
        Node child1 = new Node(67);
        for (Node node4 = firstChild1.getFirstChild(); node4 != null; node4 = node4.getNext())
        {
          Node node5 = node4;
          if (node5.getType() == 159)
          {
            List prop = (List) node5.getProp(22);
            Node firstChild2 = node5.getFirstChild();
            if (firstChild2.getType() != 154)
              throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
            if (num2 != 0)
            {
              Node.__\u003Cclinit\u003E();
              node1 = new Node(90, firstChild2.getNext(), node1);
            }
            else
            {
              Node.__\u003Cclinit\u003E();
              Node.__\u003Cclinit\u003E();
              node1 = new Node(130, new Node(134, firstChild2.getNext()), node1);
            }
            if (prop != null)
            {
              arrayList.addAll((Collection) prop);
              for (int index = 0; index < prop.size(); ++index)
              {
                Node node6 = child1;
                Node.__\u003Cclinit\u003E();
                Node child2 = new Node((int) sbyte.MaxValue, Node.newNumber(0.0));
                node6.addChildToBack(child2);
              }
            }
            node5 = firstChild2.getFirstChild();
          }
          if (node5.getType() != 39)
            throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
          arrayList.add(ScriptRuntime.getIndexObject(node5.getString()));
          Node child3 = node5.getFirstChild();
          if (child3 == null)
          {
            Node.__\u003Cclinit\u003E();
            child3 = new Node((int) sbyte.MaxValue, Node.newNumber(0.0));
          }
          child1.addChildToBack(child3);
        }
        child1.putProp(12, (object) arrayList.toArray());
        Node child4 = new Node(2, child1);
        node2.addChildToBack(child4);
        node2.addChildToBack(new Node(124, node1));
        node2.addChildToBack(new Node(3));
      }
      else
      {
        Node.__\u003Cclinit\u003E();
        Node node3 = new Node(num2 == 0 ? 130 : 90);
        node2 = NodeTransformer.replaceCurrent(parent, previous, scopeNode, node3);
        Node child = new Node(90);
        for (Node node4 = firstChild1.getFirstChild(); node4 != null; node4 = node4.getNext())
        {
          Node node5 = node4;
          if (node5.getType() == 159)
          {
            Node firstChild2 = node5.getFirstChild();
            if (firstChild2.getType() != 154)
              throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
            if (num2 != 0)
            {
              Node.__\u003Cclinit\u003E();
              node1 = new Node(90, firstChild2.getNext(), node1);
            }
            else
            {
              Node.__\u003Cclinit\u003E();
              Node.__\u003Cclinit\u003E();
              node1 = new Node(130, new Node(134, firstChild2.getNext()), node1);
            }
            Scope.joinScopes((Scope) node5, (Scope) scopeNode);
            node5 = firstChild2.getFirstChild();
          }
          Node left = node5.getType() == 39 ? Node.newString(node5.getString()) : throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
          left.setScope((Scope) scopeNode);
          Node right = node5.getFirstChild();
          if (right == null)
          {
            Node.__\u003Cclinit\u003E();
            right = new Node((int) sbyte.MaxValue, Node.newNumber(0.0));
          }
          child.addChildToBack(new Node(56, left, right));
        }
        if (num2 != 0)
        {
          node2.addChildToBack(child);
          scopeNode.setType(90);
          node2.addChildToBack(scopeNode);
          scopeNode.addChildToBack(node1);
          if (node1 is Scope)
          {
            Scope parentScope = ((Scope) node1).getParentScope();
            ((Scope) node1).setParentScope((Scope) scopeNode);
            ((Scope) scopeNode).setParentScope(parentScope);
          }
        }
        else
        {
          node2.addChildToBack(new Node(134, child));
          scopeNode.setType(130);
          node2.addChildToBack(scopeNode);
          scopeNode.addChildrenToBack(node1);
          if (node1 is Scope)
          {
            Scope parentScope = ((Scope) node1).getParentScope();
            ((Scope) node1).setParentScope((Scope) scopeNode);
            ((Scope) scopeNode).setParentScope(parentScope);
          }
        }
      }
      return node2;
    }
  }
}
