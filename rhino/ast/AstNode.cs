// Decompiled with JetBrains decompiler
// Type: rhino.ast.AstNode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.ast
{
  [Signature("Lrhino/Node;Ljava/lang/Comparable<Lrhino/ast/AstNode;>;")]
  [Implements(new string[] {"java.lang.Comparable"})]
  public abstract class AstNode : Node, Comparable
  {
    protected internal int position;
    protected internal int length;
    protected internal AstNode parent;
    protected internal AstNode inlineComment;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Integer;Ljava/lang/String;>;")]
    private static Map operatorNames;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getParent() => this.parent;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPosition() => this.position;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLength() => this.length;

    [LineNumberTable(new byte[] {160, 105, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRelative(int parentPosition) => this.position -= parentPosition;

    [LineNumberTable(new byte[] {160, 121, 110, 193, 104, 178, 103, 99, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParent(AstNode parent)
    {
      if (object.ReferenceEquals((object) parent, (object) this.parent))
        return;
      if (this.parent != null)
        this.setRelative(-this.parent.getAbsolutePosition());
      this.parent = parent;
      if (parent == null)
        return;
      this.setRelative(parent.getAbsolutePosition());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLength(int length) => this.length = length;

    [LineNumberTable(new byte[] {160, 145, 103, 110, 110, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChild(AstNode kid)
    {
      this.assertNotNull((object) kid);
      this.setLength(kid.getPosition() + kid.getLength() - this.getPosition());
      this.addChildToBack((Node) kid);
      kid.setParent(this);
    }

    [LineNumberTable(new byte[] {160, 242, 255, 162, 80, 160, 69, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasSideEffects()
    {
      switch (this.getType())
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
        case 110:
        case 111:
        case 112:
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
        default:
          return false;
      }
    }

    [LineNumberTable(new byte[] {161, 219, 105, 103, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getLineno()
    {
      if (this.lineno != -1)
        return this.lineno;
      return this.parent != null ? this.parent.getLineno() : -1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInlineComment(AstNode inlineComment) => this.inlineComment = inlineComment;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getInlineComment() => this.inlineComment;

    [LineNumberTable(new byte[] {160, 65, 103, 103, 99, 105, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAbsolutePosition()
    {
      int position = this.position;
      for (AstNode parent = this.parent; parent != null; parent = parent.getParent())
        position += parent.getPosition();
      return position;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPosition(int position) => this.position = position;

    [LineNumberTable(new byte[] {85, 233, 159, 175, 103, 231, 160, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AstNode()
      : base(-1)
    {
      AstNode astNode = this;
      this.position = -1;
      this.length = 1;
    }

    [LineNumberTable(new byte[] {161, 68, 99, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void assertNotNull(object arg)
    {
      if (arg == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("arg cannot be null");
      }
    }

    public abstract string toSource(int i);

    [LineNumberTable(539)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int depth() => this.parent == null ? 0 : 1 + this.parent.depth();

    public abstract void visit(NodeVisitor nv);

    [LineNumberTable(new byte[] {161, 151, 107, 103, 103, 102, 102, 103, 103, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(AstNode other)
    {
      if (Object.instancehelper_equals((object) this, (object) other))
        return 0;
      int absolutePosition1 = this.getAbsolutePosition();
      int absolutePosition2 = other.getAbsolutePosition();
      if (absolutePosition1 < absolutePosition2)
        return -1;
      if (absolutePosition2 < absolutePosition1)
        return 1;
      int length1 = this.getLength();
      int length2 = other.getLength();
      if (length1 < length2)
        return -1;
      return length2 < length1 ? 1 : Object.instancehelper_hashCode((object) this) - Object.instancehelper_hashCode((object) other);
    }

    [LineNumberTable(new byte[] {93, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AstNode(int pos)
      : this()
    {
      AstNode astNode = this;
      this.position = pos;
    }

    [LineNumberTable(new byte[] {104, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AstNode(int pos, int len)
      : this()
    {
      AstNode astNode = this;
      this.position = pos;
      this.length = len;
    }

    [LineNumberTable(new byte[] {160, 93, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBounds(int position, int end)
    {
      this.setPosition(position);
      this.setLength(end - position);
    }

    [LineNumberTable(new byte[] {160, 158, 98, 107, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstRoot getAstRoot()
    {
      AstNode astNode = this;
      while (true)
      {
        switch (astNode)
        {
          case null:
          case AstRoot _:
            goto label_3;
          default:
            astNode = astNode.getParent();
            continue;
        }
      }
label_3:
      return (AstRoot) astNode;
    }

    [LineNumberTable(298)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toSource() => this.toSource(0);

    [LineNumberTable(new byte[] {160, 192, 102, 102, 44, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string makeIndent(int indent)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < indent; ++index)
        stringBuilder.append("  ");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 204, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string shortName()
    {
      string name = Object.instancehelper_getClass((object) this).getName();
      int num = String.instancehelper_lastIndexOf(name, ".");
      return String.instancehelper_substring(name, num + 1);
    }

    [LineNumberTable(new byte[] {160, 215, 118, 99, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string operatorToString(int op)
    {
      string str1 = (string) AstNode.operatorNames.get((object) Integer.valueOf(op));
      if (str1 == null)
      {
        string str2 = new StringBuilder().append("Invalid operator: ").append(op).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str2);
      }
      return str1;
    }

    [Signature("<T:Lrhino/ast/AstNode;>(Ljava/util/List<TT;>;Ljava/lang/StringBuilder;)V")]
    [LineNumberTable(new byte[] {161, 79, 103, 98, 123, 110, 106, 110, 104, 140, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void printList(List items, StringBuilder sb)
    {
      int num1 = items.size();
      int num2 = 0;
      Iterator iterator = items.iterator();
      while (iterator.hasNext())
      {
        AstNode astNode = (AstNode) iterator.next();
        sb.append(astNode.toSource(0));
        int num3 = num2;
        ++num2;
        int num4 = num1 - 1;
        if (num3 < num4)
          sb.append(", ");
        else if (astNode is EmptyExpression)
          sb.append(",");
      }
    }

    [Throws(new string[] {"java.lang.RuntimeException"})]
    [LineNumberTable(466)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException codeBug() => throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());

    [LineNumberTable(new byte[] {161, 117, 103, 107, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FunctionNode getEnclosingFunction()
    {
      AstNode parent = this.getParent();
      while (true)
      {
        switch (parent)
        {
          case null:
          case FunctionNode _:
            goto label_3;
          default:
            parent = parent.getParent();
            continue;
        }
      }
label_3:
      return (FunctionNode) parent;
    }

    [LineNumberTable(new byte[] {161, 131, 103, 107, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scope getEnclosingScope()
    {
      AstNode parent = this.getParent();
      while (true)
      {
        switch (parent)
        {
          case null:
          case Scope _:
            goto label_3;
          default:
            parent = parent.getParent();
            continue;
        }
      }
label_3:
      return (Scope) parent;
    }

    [LineNumberTable(new byte[] {161, 233, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string debugPrint()
    {
      AstNode.DebugPrintVisitor debugPrintVisitor = new AstNode.DebugPrintVisitor(new StringBuilder(1000));
      this.visit((NodeVisitor) debugPrintVisitor);
      return debugPrintVisitor.toString();
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(object obj) => this.compareTo((AstNode) obj);

    [LineNumberTable(new byte[] {159, 125, 178, 170, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static AstNode()
    {
      Node.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.ast.AstNode"))
        return;
      AstNode.operatorNames = (Map) new HashMap();
      AstNode.operatorNames.put((object) Integer.valueOf(52), (object) "in");
      AstNode.operatorNames.put((object) Integer.valueOf(32), (object) "typeof");
      AstNode.operatorNames.put((object) Integer.valueOf(53), (object) "instanceof");
      AstNode.operatorNames.put((object) Integer.valueOf(31), (object) "delete");
      AstNode.operatorNames.put((object) Integer.valueOf(90), (object) ",");
      AstNode.operatorNames.put((object) Integer.valueOf(104), (object) ":");
      AstNode.operatorNames.put((object) Integer.valueOf(105), (object) "||");
      AstNode.operatorNames.put((object) Integer.valueOf(106), (object) "&&");
      AstNode.operatorNames.put((object) Integer.valueOf(107), (object) "++");
      AstNode.operatorNames.put((object) Integer.valueOf(108), (object) "--");
      AstNode.operatorNames.put((object) Integer.valueOf(9), (object) "|");
      AstNode.operatorNames.put((object) Integer.valueOf(10), (object) "^");
      AstNode.operatorNames.put((object) Integer.valueOf(11), (object) "&");
      AstNode.operatorNames.put((object) Integer.valueOf(12), (object) "==");
      AstNode.operatorNames.put((object) Integer.valueOf(13), (object) "!=");
      AstNode.operatorNames.put((object) Integer.valueOf(14), (object) "<");
      AstNode.operatorNames.put((object) Integer.valueOf(16), (object) ">");
      AstNode.operatorNames.put((object) Integer.valueOf(15), (object) "<=");
      AstNode.operatorNames.put((object) Integer.valueOf(17), (object) ">=");
      AstNode.operatorNames.put((object) Integer.valueOf(18), (object) "<<");
      AstNode.operatorNames.put((object) Integer.valueOf(19), (object) ">>");
      AstNode.operatorNames.put((object) Integer.valueOf(20), (object) ">>>");
      AstNode.operatorNames.put((object) Integer.valueOf(21), (object) "+");
      AstNode.operatorNames.put((object) Integer.valueOf(22), (object) "-");
      AstNode.operatorNames.put((object) Integer.valueOf(23), (object) "*");
      AstNode.operatorNames.put((object) Integer.valueOf(24), (object) "/");
      AstNode.operatorNames.put((object) Integer.valueOf(25), (object) "%");
      AstNode.operatorNames.put((object) Integer.valueOf(26), (object) "!");
      AstNode.operatorNames.put((object) Integer.valueOf(27), (object) "~");
      AstNode.operatorNames.put((object) Integer.valueOf(28), (object) "+");
      AstNode.operatorNames.put((object) Integer.valueOf(29), (object) "-");
      AstNode.operatorNames.put((object) Integer.valueOf(46), (object) "===");
      AstNode.operatorNames.put((object) Integer.valueOf(47), (object) "!==");
      AstNode.operatorNames.put((object) Integer.valueOf(91), (object) "=");
      AstNode.operatorNames.put((object) Integer.valueOf(92), (object) "|=");
      AstNode.operatorNames.put((object) Integer.valueOf(94), (object) "&=");
      AstNode.operatorNames.put((object) Integer.valueOf(95), (object) "<<=");
      AstNode.operatorNames.put((object) Integer.valueOf(96), (object) ">>=");
      AstNode.operatorNames.put((object) Integer.valueOf(97), (object) ">>>=");
      AstNode.operatorNames.put((object) Integer.valueOf(98), (object) "+=");
      AstNode.operatorNames.put((object) Integer.valueOf(99), (object) "-=");
      AstNode.operatorNames.put((object) Integer.valueOf(100), (object) "*=");
      AstNode.operatorNames.put((object) Integer.valueOf(101), (object) "/=");
      AstNode.operatorNames.put((object) Integer.valueOf(102), (object) "%=");
      AstNode.operatorNames.put((object) Integer.valueOf(93), (object) "^=");
      AstNode.operatorNames.put((object) Integer.valueOf((int) sbyte.MaxValue), (object) "void");
    }

    int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
      [In] object obj0)
    {
      return this.compareTo(obj0);
    }

    [InnerClass]
    public class DebugPrintVisitor : Object, NodeVisitor
    {
      [Modifiers]
      private StringBuilder buffer;
      private const int DEBUG_INDENT = 2;

      [LineNumberTable(new byte[] {161, 176, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DebugPrintVisitor(StringBuilder buf)
      {
        AstNode.DebugPrintVisitor debugPrintVisitor = this;
        this.buffer = buf;
      }

      [LineNumberTable(552)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => this.buffer.toString();

      [LineNumberTable(new byte[] {161, 186, 105, 104, 44, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private string makeIndent([In] int obj0)
      {
        StringBuilder stringBuilder = new StringBuilder(2 * obj0);
        for (int index = 0; index < 2 * obj0; ++index)
          stringBuilder.append(" ");
        return stringBuilder.toString();
      }

      [LineNumberTable(new byte[] {161, 195, 103, 103, 124, 120, 119, 124, 114, 101, 127, 4, 101, 159, 3, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool visit(AstNode node)
      {
        int type = node.getType();
        string name = Token.typeToName(type);
        this.buffer.append(node.getAbsolutePosition()).append("\t");
        this.buffer.append(this.makeIndent(node.depth()));
        this.buffer.append(name).append(" ");
        this.buffer.append(node.getPosition()).append(" ");
        this.buffer.append(node.getLength());
        switch (type)
        {
          case 39:
            this.buffer.append(" ").append(((Name) node).getIdentifier());
            break;
          case 41:
            this.buffer.append(" ").append(((StringLiteral) node).getValue(true));
            break;
        }
        this.buffer.append("\n");
        return true;
      }
    }

    [Signature("Ljava/lang/Object;Ljava/util/Comparator<Lrhino/ast/AstNode;>;")]
    public class PositionComparator : Object, Comparator
    {
      [LineNumberTable(130)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compare(AstNode n1, AstNode n2) => n1.position - n2.position;

      [LineNumberTable(122)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PositionComparator()
      {
      }

      [Modifiers]
      [EditorBrowsable(EditorBrowsableState.Never)]
      [LineNumberTable(122)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int compare(object obj1, object obj2) => this.compare((AstNode) obj1, (AstNode) obj2);

      [HideFromJava]
      public virtual Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [HideFromJava]
      public virtual Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [HideFromJava]
      public virtual Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [HideFromJava]
      public virtual Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);

      bool Comparator.__\u003Coverridestub\u003Ejava\u002Eutil\u002EComparator\u003A\u003Aequals(
        [In] object obj0)
      {
        return Object.instancehelper_equals((object) this, obj0);
      }
    }
  }
}
