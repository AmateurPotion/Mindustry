// Decompiled with JetBrains decompiler
// Type: rhino.Node
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using rhino.ast;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Signature("Ljava/lang/Object;Ljava/lang/Iterable<Lrhino/Node;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class Node : Object, Iterable, IEnumerable
  {
    public const int FUNCTION_PROP = 1;
    public const int LOCAL_PROP = 2;
    public const int LOCAL_BLOCK_PROP = 3;
    public const int REGEXP_PROP = 4;
    public const int CASEARRAY_PROP = 5;
    public const int TARGETBLOCK_PROP = 6;
    public const int VARIABLE_PROP = 7;
    public const int ISNUMBER_PROP = 8;
    public const int DIRECTCALL_PROP = 9;
    public const int SPECIALCALL_PROP = 10;
    public const int SKIP_INDEXES_PROP = 11;
    public const int OBJECT_IDS_PROP = 12;
    public const int INCRDECR_PROP = 13;
    public const int CATCH_SCOPE_PROP = 14;
    public const int LABEL_ID_PROP = 15;
    public const int MEMBER_TYPE_PROP = 16;
    public const int NAME_PROP = 17;
    public const int CONTROL_BLOCK_PROP = 18;
    public const int PARENTHESIZED_PROP = 19;
    public const int GENERATOR_END_PROP = 20;
    public const int DESTRUCTURING_ARRAY_LENGTH = 21;
    public const int DESTRUCTURING_NAMES = 22;
    public const int DESTRUCTURING_PARAMS = 23;
    public const int JSDOC_PROP = 24;
    public const int EXPRESSION_CLOSURE_PROP = 25;
    public const int DESTRUCTURING_SHORTHAND = 26;
    public const int ARROW_FUNCTION_PROP = 27;
    public const int LAST_PROP = 27;
    public const int BOTH = 0;
    public const int LEFT = 1;
    public const int RIGHT = 2;
    public const int NON_SPECIALCALL = 0;
    public const int SPECIALCALL_EVAL = 1;
    public const int SPECIALCALL_WITH = 2;
    public const int DECR_FLAG = 1;
    public const int POST_FLAG = 2;
    public const int PROPERTY_FLAG = 1;
    public const int ATTRIBUTE_FLAG = 2;
    public const int DESCENDANTS_FLAG = 4;
    [Modifiers]
    private static Node NOT_SET;
    public const int END_UNREACHED = 0;
    public const int END_DROPS_OFF = 1;
    public const int END_RETURNS = 2;
    public const int END_RETURNS_VALUE = 4;
    public const int END_YIELDS = 8;
    protected internal int type;
    protected internal Node next;
    protected internal Node first;
    protected internal Node last;
    protected internal int lineno;
    internal Node.PropListItem __\u003C\u003EpropListHead;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node getLastChild() => this.last;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLineno() => this.lineno;

    [LineNumberTable(1048)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => String.valueOf(this.type);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getType() => this.type;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node getFirstChild() => this.first;

    [LineNumberTable(new byte[] {161, 133, 104, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getExistingIntProp(int propType)
    {
      Node.PropListItem propListItem = this.lookupProperty(propType);
      if (propListItem == null)
        Kit.codeBug();
      return propListItem.intValue;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node getNext() => this.next;

    [LineNumberTable(new byte[] {161, 150, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putIntProp(int propType, int prop) => this.ensureProperty(propType).intValue = prop;

    [LineNumberTable(547)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public string getString() => ((Name) this).getIdentifier();

    [LineNumberTable(new byte[] {161, 125, 104, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getIntProp(int propType, int defaultValue)
    {
      Node.PropListItem propListItem = this.lookupProperty(propType);
      return propListItem == null ? defaultValue : propListItem.intValue;
    }

    [LineNumberTable(538)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public double getDouble() => ((NumberLiteral) this).getNumber();

    [LineNumberTable(new byte[] {161, 117, 104, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getProp(int propType) => this.lookupProperty(propType)?.objectValue;

    [LineNumberTable(new byte[] {161, 205, 127, 5, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int labelId()
    {
      if (this.type != 132 && this.type != 73 && this.type != 166)
        Kit.codeBug();
      return this.getIntProp(15, -1);
    }

    [LineNumberTable(new byte[] {161, 212, 127, 5, 134, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void labelId(int labelId)
    {
      if (this.type != 132 && this.type != 73 && this.type != 166)
        Kit.codeBug();
      this.putIntProp(15, labelId);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLineno(int lineno) => this.lineno = lineno;

    [LineNumberTable(new byte[] {160, 118, 103, 104, 114, 129, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildToBack(Node child)
    {
      child.next = (Node) null;
      if (this.last == null)
      {
        Node node1 = this;
        Node node2 = child;
        Node node3 = node2;
        this.last = node2;
        this.first = node3;
      }
      else
      {
        this.last.next = child;
        this.last = child;
      }
    }

    [LineNumberTable(new byte[] {161, 141, 99, 137, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putProp(int propType, object prop)
    {
      if (prop == null)
        this.removeProp(propType);
      else
        this.ensureProperty(propType).objectValue = prop;
    }

    [LineNumberTable(new byte[] {160, 70, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setJsDocNode(Comment jsdocNode) => this.putProp(24, (object) jsdocNode);

    [LineNumberTable(new byte[] {32, 232, 164, 163, 231, 155, 94, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Node(int nodeType)
    {
      Node node = this;
      this.lineno = -1;
      this.type = nodeType;
    }

    [LineNumberTable(new byte[] {162, 28, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasConsistentReturnUsage()
    {
      int num = this.endCheck();
      return (num & 4) == 0 || (num & 11) == 0;
    }

    [LineNumberTable(new byte[] {163, 36, 191, 162, 83, 104, 108, 162, 191, 8, 102, 127, 3, 43, 225, 69, 112, 102, 255, 0, 160, 67, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasSideEffects()
    {
      switch (this.type)
      {
        case -1:
        case 2:
        case 3:
        case 4:
        case 5:
        case 6:
        case 7:
        case 8:
        case 30:
        case 31:
        case 35:
        case 37:
        case 38:
        case 50:
        case 51:
        case 56:
        case 57:
        case 65:
        case 69:
        case 70:
        case 71:
        case 73:
        case 82:
        case 83:
        case 91:
        case 92:
        case 93:
        case 94:
        case 95:
        case 96:
        case 97:
        case 98:
        case 99:
        case 100:
        case 101:
        case 102:
        case 107:
        case 108:
        case 113:
        case 114:
        case 115:
        case 118:
        case 119:
        case 120:
        case 121:
        case 122:
        case 123:
        case 124:
        case 125:
        case 126:
        case 130:
        case 131:
        case 132:
        case 133:
        case 135:
        case 136:
        case 140:
        case 141:
        case 142:
        case 143:
        case 154:
        case 155:
        case 159:
        case 160:
        case 166:
          return true;
        case 90:
        case 134:
          return this.last == null || this.last.hasSideEffects();
        case 103:
          if (this.first == null || this.first.next == null || this.first.next.next == null)
            Kit.codeBug();
          return this.first.next.hasSideEffects() && this.first.next.next.hasSideEffects();
        case 105:
        case 106:
          if (this.first == null || this.last == null)
            Kit.codeBug();
          return this.first.hasSideEffects() || this.last.hasSideEffects();
        default:
          return false;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node setType(int type)
    {
      this.type = type;
      return this;
    }

    [LineNumberTable(new byte[] {36, 232, 164, 159, 231, 155, 98, 103, 114, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Node(int nodeType, Node child)
    {
      Node node1 = this;
      this.lineno = -1;
      this.type = nodeType;
      Node node2 = this;
      Node node3 = child;
      Node node4 = node3;
      this.last = node3;
      this.first = node4;
      child.next = (Node) null;
    }

    [LineNumberTable(new byte[] {160, 110, 108, 103, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildToFront(Node child)
    {
      child.next = this.first;
      this.first = child;
      if (this.last != null)
        return;
      this.last = child;
    }

    [LineNumberTable(new byte[] {42, 232, 164, 153, 231, 155, 104, 103, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Node(int nodeType, Node left, Node right)
    {
      Node node = this;
      this.lineno = -1;
      this.type = nodeType;
      this.first = left;
      this.last = right;
      left.next = right;
      right.next = (Node) null;
    }

    [LineNumberTable(136)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Node newString(string str) => Node.newString(41, str);

    [LineNumberTable(new byte[] {90, 102, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Node newString(int type, string str)
    {
      Name name = new Name();
      name.setIdentifier(str);
      name.setType(type);
      return (Node) name;
    }

    [LineNumberTable(new byte[] {80, 102, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Node newNumber(double number)
    {
      NumberLiteral numberLiteral = new NumberLiteral();
      numberLiteral.setNumber(number);
      return (Node) numberLiteral;
    }

    [LineNumberTable(new byte[] {50, 232, 164, 145, 231, 155, 112, 103, 103, 104, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Node(int nodeType, Node left, Node mid, Node right)
    {
      Node node = this;
      this.lineno = -1;
      this.type = nodeType;
      this.first = left;
      this.last = right;
      left.next = mid;
      mid.next = right;
      right.next = (Node) null;
    }

    [LineNumberTable(new byte[] {59, 232, 164, 136, 231, 155, 121, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Node(int nodeType, int line)
    {
      Node node = this;
      this.lineno = -1;
      this.type = nodeType;
      this.lineno = line;
    }

    [LineNumberTable(new byte[] {65, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Node(int nodeType, Node child, int line)
      : this(nodeType, child)
    {
      Node node = this;
      this.lineno = line;
    }

    [Signature("()Ljava/util/Iterator<Lrhino/Node;>;")]
    [LineNumberTable(384)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) new Node.NodeIterator(this);

    [LineNumberTable(new byte[] {160, 208, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeChildren()
    {
      Node node = this;
      this.last = (Node) null;
      this.first = (Node) null;
    }

    [LineNumberTable(new byte[] {161, 98, 103, 99, 98, 105, 98, 103, 99, 161, 99, 142, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeProp(int propType)
    {
      Node.PropListItem propListItem1 = this.__\u003C\u003EpropListHead;
      if (propListItem1 == null)
        return;
      Node.PropListItem propListItem2 = (Node.PropListItem) null;
      while (propListItem1.type != propType)
      {
        propListItem2 = propListItem1;
        propListItem1 = propListItem1.next;
        if (propListItem1 == null)
          return;
      }
      if (propListItem2 == null)
        this.__\u003C\u003EpropListHead = propListItem1.next;
      else
        propListItem2.next = propListItem1.next;
    }

    [LineNumberTable(571)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Node newTarget() => new Node(132);

    [LineNumberTable(new byte[] {160, 137, 104, 140, 108, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildrenToBack(Node children)
    {
      if (this.last != null)
        this.last.next = children;
      this.last = children.getLastSibling();
      if (this.first != null)
        return;
      this.first = children;
    }

    [LineNumberTable(new byte[] {160, 166, 104, 144, 108, 103, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildAfter(Node newChild, Node node)
    {
      if (newChild.next != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("newChild had siblings in addChildAfter");
      }
      newChild.next = node.next;
      node.next = newChild;
      if (!object.ReferenceEquals((object) this.last, (object) node))
        return;
      this.last = newChild;
    }

    [LineNumberTable(new byte[] {75, 109, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Node(int nodeType, Node left, Node mid, Node right, int line)
      : this(nodeType, left, mid, right)
    {
      Node node = this;
      this.lineno = line;
    }

    [LineNumberTable(new byte[] {160, 128, 103, 108, 103, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildrenToFront(Node children)
    {
      Node lastSibling = children.getLastSibling();
      lastSibling.next = this.first;
      this.first = children;
      if (this.last != null)
        return;
      this.last = lastSibling;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasChildren() => this.first != null;

    [LineNumberTable(new byte[] {160, 176, 104, 99, 147, 108, 117, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeChild(Node child)
    {
      Node childBefore = this.getChildBefore(child);
      if (childBefore == null)
        this.first = this.first.next;
      else
        childBefore.next = child.next;
      if (object.ReferenceEquals((object) child, (object) this.last))
        this.last = childBefore;
      child.next = (Node) null;
    }

    [LineNumberTable(new byte[] {161, 172, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setDouble(double number) => ((NumberLiteral) this).setNumber(number);

    [LineNumberTable(new byte[] {161, 182, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setString(string s)
    {
      if (s == null)
        Kit.codeBug();
      ((Name) this).setIdentifier(s);
    }

    [LineNumberTable(177)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Comment getJsDocNode() => (Comment) this.getProp(24);

    [LineNumberTable(new byte[] {160, 102, 98, 104, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node getLastSibling()
    {
      Node node = this;
      while (node.next != null)
        node = node.next;
      return node;
    }

    [LineNumberTable(new byte[] {160, 90, 110, 98, 103, 110, 103, 99, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node getChildBefore(Node child)
    {
      if (object.ReferenceEquals((object) child, (object) this.first))
        return (Node) null;
      Node node = this.first;
      while (!object.ReferenceEquals((object) node.next, (object) child))
      {
        node = node.next;
        if (node == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("node is not a child");
        }
      }
      return node;
    }

    [LineNumberTable(new byte[] {161, 79, 103, 108, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node.PropListItem lookupProperty([In] int obj0)
    {
      Node.PropListItem propListItem = this.__\u003C\u003EpropListHead;
      while (propListItem != null && obj0 != propListItem.type)
        propListItem = propListItem.next;
      return propListItem;
    }

    [LineNumberTable(new byte[] {161, 87, 104, 99, 103, 103, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node.PropListItem ensureProperty([In] int obj0)
    {
      Node.PropListItem propListItem = this.lookupProperty(obj0);
      if (propListItem == null)
      {
        propListItem = new Node.PropListItem((Node.\u0031) null);
        propListItem.type = obj0;
        propListItem.next = this.__\u003C\u003EpropListHead;
        this.__\u003C\u003EpropListHead = propListItem;
      }
      return propListItem;
    }

    [LineNumberTable(558)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scope getScope() => this.getScope();

    [LineNumberTable(new byte[] {161, 193, 105, 104, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setScope(Scope s)
    {
      if (s == null)
        Kit.codeBug();
      if (!(this is Name))
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      this.setScope(s);
    }

    [LineNumberTable(new byte[] {162, 233, 159, 107, 167, 104, 108, 194, 194, 162, 104, 98, 162, 104, 108, 162, 231, 69, 104, 130, 159, 17, 172, 172, 172, 172, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int endCheck()
    {
      switch (this.type)
      {
        case 4:
          return this.first != null ? 4 : 2;
        case 50:
        case 122:
          return 0;
        case 73:
        case 166:
          return 8;
        case 121:
          return this.endCheckBreak();
        case 130:
        case 142:
          if (this.first == null)
            return 1;
          switch (this.first.type)
          {
            case 7:
              return this.first.endCheckIf();
            case 82:
              return this.first.endCheckTry();
            case 115:
              return this.first.endCheckSwitch();
            case 131:
              return this.first.endCheckLabel();
            default:
              return this.endCheckBlock();
          }
        case 132:
          return this.next != null ? this.next.endCheck() : 1;
        case 133:
          return this.endCheckLoop();
        case 134:
          return this.first != null ? this.first.endCheck() : 1;
        default:
          return 1;
      }
    }

    [LineNumberTable(new byte[] {162, 218, 108, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int endCheckBreak()
    {
      ((Jump) this).getJumpStatement().putIntProp(18, 1);
      return 0;
    }

    [LineNumberTable(new byte[] {162, 158, 191, 4, 105, 162, 182, 111, 165, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int endCheckLoop()
    {
      Node node = this.first;
      while (!object.ReferenceEquals((object) node.next, (object) this.last))
        node = node.next;
      if (node.type != 6)
        return 1;
      int num = ((Jump) node).target.next.endCheck();
      if (node.first.type == 45)
        num &= -2;
      return num | this.getIntProp(18, 0);
    }

    [LineNumberTable(new byte[] {162, 206, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int endCheckLabel() => this.next.endCheck() | this.getIntProp(18, 0);

    [LineNumberTable(new byte[] {162, 42, 103, 140, 135, 99, 139, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int endCheckIf()
    {
      Node next = this.next;
      Node target = ((Jump) this).target;
      int num = next.endCheck();
      return target == null ? num | 1 : num | target.endCheck();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int endCheckSwitch() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int endCheckTry() => 0;

    [LineNumberTable(new byte[] {162, 185, 194, 111, 101, 9, 201})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int endCheckBlock()
    {
      int num = 1;
      for (Node node = this.first; (num & 1) != 0 && node != null; node = node.next)
        num = num & -2 | node.endCheck();
      return num;
    }

    [LineNumberTable(new byte[] {163, 149, 127, 5, 135, 103, 99, 102, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void resetTargets_r()
    {
      if (this.type == 132 || this.type == 73 || this.type == 166)
        this.labelId(-1);
      for (Node node = this.first; node != null; node = node.next)
        node.resetTargets_r();
    }

    [LineNumberTable(new byte[] {70, 107, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Node(int nodeType, Node left, Node right, int line)
      : this(nodeType, left, right)
    {
      Node node = this;
      this.lineno = line;
    }

    [LineNumberTable(new byte[] {114, 103, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getJsDoc() => this.getJsDocNode()?.getValue();

    [LineNumberTable(new byte[] {160, 150, 104, 144, 110, 108, 103, 129, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildBefore(Node newChild, Node node)
    {
      if (newChild.next != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("newChild had siblings in addChildBefore");
      }
      if (object.ReferenceEquals((object) this.first, (object) node))
      {
        newChild.next = this.first;
        this.first = newChild;
      }
      else
      {
        Node childBefore = this.getChildBefore(node);
        this.addChildAfter(newChild, childBefore);
      }
    }

    [LineNumberTable(new byte[] {160, 186, 108, 110, 137, 104, 135, 110, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void replaceChild(Node child, Node newChild)
    {
      newChild.next = child.next;
      if (object.ReferenceEquals((object) child, (object) this.first))
        this.first = newChild;
      else
        this.getChildBefore(child).next = newChild;
      if (object.ReferenceEquals((object) child, (object) this.last))
        this.last = newChild;
      child.next = (Node) null;
    }

    [LineNumberTable(new byte[] {160, 199, 103, 108, 103, 110, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void replaceChildAfter(Node prevChild, Node newChild)
    {
      Node next = prevChild.next;
      newChild.next = next.next;
      prevChild.next = newChild;
      if (object.ReferenceEquals((object) next, (object) this.last))
        this.last = newChild;
      next.next = (Node) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string propToString([In] int obj0) => (string) null;

    [LineNumberTable(new byte[] {163, 141, 106, 136, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resetTargets()
    {
      if (this.type == 126)
        this.resetTargets_r();
      else
        Kit.codeBug();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void toString([In] ObjToIntMap obj0, [In] StringBuilder obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toStringTree(ScriptNode treeTop) => (string) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void toStringTreeHelper(
      [In] ScriptNode obj0,
      [In] Node obj1,
      [In] ObjToIntMap obj2,
      [In] int obj3,
      [In] StringBuilder obj4)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void generatePrintIds([In] Node obj0, [In] ObjToIntMap obj1)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void appendPrintId([In] Node obj0, [In] ObjToIntMap obj1, [In] StringBuilder obj2)
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Node access\u0024000() => Node.NOT_SET;

    [LineNumberTable(325)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Node()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.Node"))
        return;
      Node.NOT_SET = new Node(-1);
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Modifiers]
    protected internal object propListHead
    {
      [HideFromJava] get => (object) this.__\u003C\u003EpropListHead;
      [HideFromJava] [param: In] set => this.__\u003C\u003EpropListHead = (Node.PropListItem) value;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      \u0031() => throw null;
    }

    [Signature("Ljava/lang/Object;Ljava/util/Iterator<Lrhino/Node;>;")]
    public class NodeIterator : Object, Iterator
    {
      private Node cursor;
      private Node prev;
      private Node prev2;
      private bool removed;
      [Modifiers]
      internal Node this\u00240;

      [LineNumberTable(new byte[] {160, 224, 239, 60, 139, 167, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NodeIterator(Node _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Node.NodeIterator nodeIterator = this;
        this.prev = Node.access\u0024000();
        this.removed = false;
        this.cursor = _param1.first;
      }

      [LineNumberTable(new byte[] {160, 235, 104, 139, 103, 108, 108, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Node next()
      {
        if (this.cursor == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        this.removed = false;
        this.prev2 = this.prev;
        this.prev = this.cursor;
        this.cursor = this.cursor.next;
        return this.prev;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext() => this.cursor != null;

      [LineNumberTable(new byte[] {160, 247, 114, 144, 104, 176, 120, 120, 120, 108, 147, 145})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove()
      {
        if (object.ReferenceEquals((object) this.prev, (object) Node.access\u0024000()))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("next() has not been called");
        }
        if (this.removed)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("remove() already called for current element");
        }
        if (object.ReferenceEquals((object) this.prev, (object) this.this\u00240.first))
          this.this\u00240.first = this.prev.next;
        else if (object.ReferenceEquals((object) this.prev, (object) this.this\u00240.last))
        {
          this.prev2.next = (Node) null;
          this.this\u00240.last = this.prev2;
        }
        else
          this.prev2.next = this.cursor;
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(332)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object \u003Cbridge\u003Enext() => (object) this.next();

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

      object Iterator.__\u003Coverridestub\u003Ejava\u002Eutil\u002EIterator\u003A\u003Anext() => this.\u003Cbridge\u003Enext();
    }

    [InnerClass]
    internal class PropListItem : Object
    {
      internal Node.PropListItem next;
      internal int type;
      internal int intValue;
      internal object objectValue;

      [Modifiers]
      [LineNumberTable(75)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal PropListItem([In] Node.\u0031 obj0)
        : this()
      {
      }

      [LineNumberTable(75)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PropListItem()
      {
      }
    }
  }
}
