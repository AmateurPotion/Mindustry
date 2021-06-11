// Decompiled with JetBrains decompiler
// Type: rhino.IRFactory
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
  public sealed class IRFactory : Parser
  {
    private const int LOOP_DO_WHILE = 0;
    private const int LOOP_WHILE = 1;
    private const int LOOP_FOR = 2;
    private const int ALWAYS_TRUE_BOOLEAN = 1;
    private const int ALWAYS_FALSE_BOOLEAN = -1;
    private Decompiler decompiler;

    [LineNumberTable(new byte[] {159, 175, 234, 53, 235, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IRFactory(CompilerEnvirons env, ErrorReporter errorReporter)
      : base(env, errorReporter)
    {
      IRFactory irFactory = this;
      this.decompiler = new Decompiler();
    }

    [LineNumberTable(new byte[] {159, 183, 103, 108, 236, 70, 141, 108, 168, 109, 177, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptNode transformTree(AstRoot root)
    {
      this.currentScriptOrFn = (ScriptNode) root;
      this.inUseStrictDirective = root.isInStrictMode();
      int currentOffset1 = this.decompiler.getCurrentOffset();
      ScriptNode scriptNode = (ScriptNode) this.transform((AstNode) root);
      int currentOffset2 = this.decompiler.getCurrentOffset();
      scriptNode.setEncodedSourceBounds(currentOffset1, currentOffset2);
      if (this.compilerEnv.isGeneratingSource())
        scriptNode.setEncodedSource(this.decompiler.getEncodedSource());
      this.decompiler = (Decompiler) null;
      return scriptNode;
    }

    [LineNumberTable(new byte[] {18, 159, 162, 63, 141, 141, 136, 141, 141, 141, 141, 130, 104, 141, 141, 141, 141, 141, 141, 141, 237, 71, 168, 141, 141, 141, 141, 141, 141, 141, 141, 141, 141, 141, 141, 173, 141, 104, 141, 104, 141, 104, 141, 104, 141, 104, 141, 104, 141, 104, 141, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Node transform(AstNode node)
    {
      switch (node.getType())
      {
        case 4:
          return this.transformReturn((ReturnStatement) node);
        case 30:
          return this.transformNewExpr((NewExpression) node);
        case 33:
          return this.transformPropertyGet((PropertyGet) node);
        case 36:
          return this.transformElementGet((ElementGet) node);
        case 38:
          return this.transformFunctionCall((FunctionCall) node);
        case 39:
          return this.transformName((Name) node);
        case 40:
          return this.transformNumber((NumberLiteral) node);
        case 41:
          return this.transformString((StringLiteral) node);
        case 42:
        case 43:
        case 44:
        case 45:
        case 161:
          return this.transformLiteral(node);
        case 48:
          return this.transformRegExp((RegExpLiteral) node);
        case 50:
          return this.transformThrow((ThrowStatement) node);
        case 66:
          return this.transformArrayLiteral((ArrayLiteral) node);
        case 67:
          return this.transformObjectLiteral((ObjectLiteral) node);
        case 73:
        case 166:
          return this.transformYield((Yield) node);
        case 82:
          return this.transformTry((TryStatement) node);
        case 103:
          return this.transformCondExpr((ConditionalExpression) node);
        case 110:
          return this.transformFunction((FunctionNode) node);
        case 113:
          return this.transformIf((IfStatement) node);
        case 115:
          return this.transformSwitch((SwitchStatement) node);
        case 118:
          return this.transformWhileLoop((WhileLoop) node);
        case 119:
          return this.transformDoLoop((DoLoop) node);
        case 120:
          return node is ForInLoop ? this.transformForInLoop((ForInLoop) node) : this.transformForLoop((ForLoop) node);
        case 121:
          return this.transformBreak((BreakStatement) node);
        case 122:
          return this.transformContinue((ContinueStatement) node);
        case 124:
          return this.transformWith((WithStatement) node);
        case 129:
          return (Node) node;
        case 130:
          return this.transformBlock(node);
        case 137:
          return this.transformScript((ScriptNode) node);
        case 158:
          return this.transformArrayComp((ArrayComprehension) node);
        case 163:
          return this.transformGenExpr((GeneratorExpression) node);
        default:
          switch (node)
          {
            case ExpressionStatement _:
              return this.transformExprStmt((ExpressionStatement) node);
            case Assignment _:
              return this.transformAssignment((Assignment) node);
            case UnaryExpression _:
              return this.transformUnary((UnaryExpression) node);
            case InfixExpression _:
              return this.transformInfix((InfixExpression) node);
            case VariableDeclaration _:
              return this.transformVariables((VariableDeclaration) node);
            case ParenthesizedExpression _:
              return this.transformParenExpr((ParenthesizedExpression) node);
            case LabeledStatement _:
              return this.transformLabeledStatement((LabeledStatement) node);
            case LetNode _:
              return this.transformLetNode((LetNode) node);
            default:
              string str = new StringBuilder().append("Can't transform: ").append((object) node).toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalArgumentException(str);
          }
      }
    }

    [LineNumberTable(new byte[] {160, 75, 103, 109, 108, 135, 109, 108, 117, 143, 39, 205, 104, 110, 103, 109, 135, 102, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformArrayComp([In] ArrayComprehension obj0)
    {
      int lineno = obj0.getLineno();
      Scope scopeNode = this.createScopeNode(158, lineno);
      string nextTempName = this.currentScriptOrFn.getNextTempName();
      this.pushScope(scopeNode);
      try
      {
        this.defineSymbol(154, nextTempName, false);
        Node child1 = new Node(130, lineno);
        Node callOrNew = this.createCallOrNew(30, this.createName("Array"));
        Node.__\u003Cclinit\u003E();
        Node child2 = new Node(134, this.createAssignment(91, this.createName(nextTempName), callOrNew), lineno);
        child1.addChildToBack(child2);
        child1.addChildToBack(this.arrayCompTransformHelper(obj0, nextTempName));
        scopeNode.addChildToBack(child1);
        scopeNode.addChildToBack(this.createName(nextTempName));
        return (Node) scopeNode;
      }
      finally
      {
        this.popScope();
      }
    }

    [LineNumberTable(new byte[] {160, 199, 104, 130, 109, 103, 104, 98, 110, 110, 110, 144, 99, 134, 141, 107, 237, 53, 233, 77, 109, 100, 37, 133, 99, 109, 109, 55, 136, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformArrayLiteral([In] ArrayLiteral obj0)
    {
      if (obj0.isDestructuring())
        return (Node) obj0;
      this.decompiler.addToken(84);
      List elements = obj0.getElements();
      Node node1 = new Node(66);
      ArrayList arrayList = (ArrayList) null;
      for (int index = 0; index < elements.size(); ++index)
      {
        AstNode node2 = (AstNode) elements.get(index);
        if (node2.getType() != 129)
        {
          node1.addChildToBack(this.transform(node2));
        }
        else
        {
          if (arrayList == null)
            arrayList = new ArrayList();
          ((List) arrayList).add((object) Integer.valueOf(index));
        }
        if (index < elements.size() - 1)
          this.decompiler.addToken(90);
      }
      this.decompiler.addToken(85);
      node1.putIntProp(21, obj0.getDestructuringLength());
      if (arrayList != null)
      {
        int[] numArray = new int[((List) arrayList).size()];
        for (int index = 0; index < ((List) arrayList).size(); ++index)
          numArray[index] = ((Integer) ((List) arrayList).get(index)).intValue();
        node1.putProp(11, (object) numArray);
      }
      return node1;
    }

    [LineNumberTable(new byte[] {160, 247, 104, 172, 102, 123, 115, 98, 102, 123, 103, 98, 134, 104, 134, 227, 61, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformBlock([In] AstNode obj0)
    {
      if (obj0 is Scope)
        this.pushScope((Scope) obj0);
      try
      {
        ArrayList arrayList = new ArrayList();
        Iterator iterator1 = obj0.iterator();
        while (iterator1.hasNext())
        {
          Node node = (Node) iterator1.next();
          ((List) arrayList).add((object) this.transform((AstNode) node));
        }
        obj0.removeChildren();
        Iterator iterator2 = ((List) arrayList).iterator();
        while (iterator2.hasNext())
        {
          Node child = (Node) iterator2.next();
          obj0.addChildToBack(child);
        }
        return (Node) obj0;
      }
      finally
      {
        if (obj0 is Scope)
          this.popScope();
      }
    }

    [LineNumberTable(new byte[] {161, 12, 109, 104, 150, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformBreak([In] BreakStatement obj0)
    {
      this.decompiler.addToken(121);
      if (obj0.getBreakLabel() != null)
        this.decompiler.addName(obj0.getBreakLabel().getIdentifier());
      this.decompiler.addEOL(83);
      return (Node) obj0;
    }

    [LineNumberTable(new byte[] {161, 180, 117, 108, 109, 103, 107, 109, 109, 107, 237, 60, 230, 71, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformFunctionCall([In] FunctionCall obj0)
    {
      Node callOrNew = this.createCallOrNew(38, this.transform(obj0.getTarget()));
      callOrNew.setLineno(obj0.getLineno());
      this.decompiler.addToken(88);
      List arguments = obj0.getArguments();
      for (int index = 0; index < arguments.size(); ++index)
      {
        AstNode node = (AstNode) arguments.get(index);
        callOrNew.addChildToBack(this.transform(node));
        if (index < arguments.size() - 1)
          this.decompiler.addToken(90);
      }
      this.decompiler.addToken(89);
      return callOrNew;
    }

    [LineNumberTable(new byte[] {161, 30, 109, 104, 150, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformContinue([In] ContinueStatement obj0)
    {
      this.decompiler.addToken(122);
      if (obj0.getLabel() != null)
        this.decompiler.addName(obj0.getLabel().getIdentifier());
      this.decompiler.addEOL(83);
      return (Node) obj0;
    }

    [LineNumberTable(new byte[] {161, 39, 108, 135, 109, 109, 109, 109, 109, 109, 109, 109, 109, 177, 102, 35, 226, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformDoLoop([In] DoLoop obj0)
    {
      obj0.setType(133);
      this.pushScope((Scope) obj0);
      try
      {
        this.decompiler.addToken(119);
        this.decompiler.addEOL(86);
        Node node1 = this.transform(obj0.getBody());
        this.decompiler.addToken(87);
        this.decompiler.addToken(118);
        this.decompiler.addToken(88);
        Node node2 = this.transform(obj0.getCondition());
        this.decompiler.addToken(89);
        this.decompiler.addEOL(83);
        return this.createLoop((Jump) obj0, 0, node1, node2, (Node) null, (Node) null);
      }
      finally
      {
        this.popScope();
      }
    }

    [LineNumberTable(new byte[] {161, 75, 109, 104, 112, 141, 108, 135, 98, 103, 104, 135, 104, 104, 146, 141, 109, 109, 109, 110, 109, 104, 43, 171, 102, 35, 226, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformForInLoop([In] ForInLoop obj0)
    {
      this.decompiler.addToken(120);
      if (obj0.isForEach())
        this.decompiler.addName("each ");
      this.decompiler.addToken(88);
      obj0.setType(133);
      this.pushScope((Scope) obj0);
      try
      {
        int num = -1;
        AstNode iterator = obj0.getIterator();
        if (iterator is VariableDeclaration)
          num = iterator.getType();
        Node node1 = this.transform(iterator);
        if (obj0.isForOf())
          this.decompiler.addName("of ");
        else
          this.decompiler.addToken(52);
        Node node2 = this.transform(obj0.getIteratedObject());
        this.decompiler.addToken(89);
        this.decompiler.addEOL(86);
        Node node3 = this.transform(obj0.getBody());
        this.decompiler.addEOL(87);
        return this.createForIn(num, (Node) obj0, node1, node2, node3, obj0.isForEach(), obj0.isForOf());
      }
      finally
      {
        this.popScope();
      }
    }

    [LineNumberTable(new byte[] {161, 107, 109, 109, 172, 103, 135, 109, 109, 109, 109, 109, 109, 109, 110, 109, 146, 103, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformForLoop([In] ForLoop obj0)
    {
      this.decompiler.addToken(120);
      this.decompiler.addToken(88);
      obj0.setType(133);
      Scope currentScope = this.currentScope;
      this.currentScope = (Scope) obj0;
      try
      {
        Node node1 = this.transform(obj0.getInitializer());
        this.decompiler.addToken(83);
        Node node2 = this.transform(obj0.getCondition());
        this.decompiler.addToken(83);
        Node node3 = this.transform(obj0.getIncrement());
        this.decompiler.addToken(89);
        this.decompiler.addEOL(86);
        Node node4 = this.transform(obj0.getBody());
        this.decompiler.addEOL(87);
        return this.createFor((Scope) obj0, node1, node2, node3, node4);
      }
      finally
      {
        this.currentScope = currentScope;
      }
    }

    [LineNumberTable(new byte[] {161, 131, 103, 109, 104, 141, 201, 111, 136, 109, 110, 142, 104, 141, 147, 172, 172, 100, 213, 104, 110, 99, 109, 101, 176, 168, 110, 103, 3, 226, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformFunction([In] FunctionNode obj0)
    {
      int functionType1 = obj0.getFunctionType();
      int start = this.decompiler.markFunctionStart(functionType1);
      Node node1 = this.decompileFunctionHeader(obj0);
      int num = this.currentScriptOrFn.addFunction(obj0);
      Parser.PerFunctionVariables functionVariables = new Parser.PerFunctionVariables((Parser) this, obj0);
      try
      {
        Node prop = (Node) obj0.getProp(23);
        obj0.removeProp(23);
        int lineno = obj0.getBody().getLineno();
        ++this.nestingOfFunction;
        Node node2 = this.transform(obj0.getBody());
        if (!obj0.isExpressionClosure())
          this.decompiler.addToken(87);
        obj0.setEncodedSourceBounds(start, this.decompiler.markFunctionEnd(start));
        if (functionType1 != 2 && !obj0.isExpressionClosure())
          this.decompiler.addToken(1);
        if (prop != null)
          node2.addChildToFront(new Node(134, prop, lineno));
        int functionType2 = obj0.getFunctionType();
        Node node3 = this.initFunction(obj0, num, node2, functionType2);
        if (node1 != null)
        {
          node3 = this.createAssignment(91, node1, node3);
          if (functionType2 != 2)
            node3 = this.createExprStatementNoReturn(node3, obj0.getLineno());
        }
        return node3;
      }
      finally
      {
        --this.nestingOfFunction;
        functionVariables.restore();
      }
    }

    [LineNumberTable(new byte[] {161, 198, 102, 113, 102, 103, 134, 103, 109, 104, 142, 201, 111, 136, 104, 110, 137, 104, 141, 147, 172, 172, 100, 213, 104, 111, 99, 109, 101, 212, 110, 103, 3, 130, 130, 108, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformGenExpr([In] GeneratorExpression obj0)
    {
      FunctionNode fnNode = new FunctionNode();
      fnNode.setSourceName(this.currentScriptOrFn.getNextTempName());
      fnNode.setIsGenerator();
      fnNode.setFunctionType(2);
      fnNode.setRequiresActivation();
      int functionType1 = fnNode.getFunctionType();
      int start = this.decompiler.markFunctionStart(functionType1);
      Node node1 = this.decompileFunctionHeader(fnNode);
      int num = this.currentScriptOrFn.addFunction(fnNode);
      Parser.PerFunctionVariables functionVariables = new Parser.PerFunctionVariables((Parser) this, fnNode);
      Node node2;
      try
      {
        Node prop = (Node) fnNode.getProp(23);
        fnNode.removeProp(23);
        int lineno = obj0.lineno;
        ++this.nestingOfFunction;
        Node node3 = this.genExprTransformHelper(obj0);
        if (!fnNode.isExpressionClosure())
          this.decompiler.addToken(87);
        fnNode.setEncodedSourceBounds(start, this.decompiler.markFunctionEnd(start));
        if (functionType1 != 2 && !fnNode.isExpressionClosure())
          this.decompiler.addToken(1);
        if (prop != null)
          node3.addChildToFront(new Node(134, prop, lineno));
        int functionType2 = fnNode.getFunctionType();
        node2 = this.initFunction(fnNode, num, node3, functionType2);
        if (node1 != null)
        {
          node2 = this.createAssignment(91, node1, node2);
          if (functionType2 != 2)
            node2 = this.createExprStatementNoReturn(node2, fnNode.getLineno());
        }
      }
      finally
      {
        --this.nestingOfFunction;
        functionVariables.restore();
      }
      Node callOrNew = this.createCallOrNew(38, node2);
      callOrNew.setLineno(obj0.getLineno());
      this.decompiler.addToken(88);
      this.decompiler.addToken(89);
      return callOrNew;
    }

    [LineNumberTable(new byte[] {161, 61, 109, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformElementGet([In] ElementGet obj0)
    {
      Node left = this.transform(obj0.getTarget());
      this.decompiler.addToken(84);
      Node right = this.transform(obj0.getElement());
      this.decompiler.addToken(85);
      return new Node(36, left, right);
    }

    [LineNumberTable(new byte[] {163, 43, 109, 108, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformPropertyGet([In] PropertyGet obj0)
    {
      Node node = this.transform(obj0.getTarget());
      string identifier = obj0.getProperty().getIdentifier();
      this.decompiler.addToken(109);
      this.decompiler.addName(identifier);
      return this.createPropertyGet(node, (string) null, identifier, 0);
    }

    [LineNumberTable(new byte[] {161, 21, 109, 109, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformCondExpr([In] ConditionalExpression obj0)
    {
      Node node1 = this.transform(obj0.getTestExpression());
      this.decompiler.addToken(103);
      Node node2 = this.transform(obj0.getTrueExpression());
      this.decompiler.addToken(104);
      Node node3 = this.transform(obj0.getFalseExpression());
      return this.createCondExpr(node1, node2, node3);
    }

    [LineNumberTable(new byte[] {162, 91, 109, 109, 109, 109, 109, 109, 98, 104, 109, 109, 109, 141, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformIf([In] IfStatement obj0)
    {
      this.decompiler.addToken(113);
      this.decompiler.addToken(88);
      Node node1 = this.transform(obj0.getCondition());
      this.decompiler.addToken(89);
      this.decompiler.addEOL(86);
      Node node2 = this.transform(obj0.getThenPart());
      Node node3 = (Node) null;
      if (obj0.getElsePart() != null)
      {
        this.decompiler.addToken(87);
        this.decompiler.addToken(114);
        this.decompiler.addEOL(86);
        node3 = this.transform(obj0.getElsePart());
      }
      this.decompiler.addEOL(87);
      return this.createIf(node1, node2, node3, obj0.getLineno());
    }

    [LineNumberTable(new byte[] {162, 174, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformLiteral([In] AstNode obj0)
    {
      this.decompiler.addToken(obj0.getType());
      return (Node) obj0;
    }

    [LineNumberTable(new byte[] {162, 179, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformName([In] Name obj0)
    {
      this.decompiler.addName(obj0.getIdentifier());
      return (Node) obj0;
    }

    [LineNumberTable(new byte[] {162, 204, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformNumber([In] NumberLiteral obj0)
    {
      this.decompiler.addNumber(obj0.getNumber());
      return (Node) obj0;
    }

    [LineNumberTable(new byte[] {162, 184, 109, 117, 108, 103, 109, 107, 109, 109, 107, 237, 60, 230, 71, 109, 104, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformNewExpr([In] NewExpression obj0)
    {
      this.decompiler.addToken(30);
      Node callOrNew = this.createCallOrNew(30, this.transform(obj0.getTarget()));
      callOrNew.setLineno(obj0.getLineno());
      List arguments = obj0.getArguments();
      this.decompiler.addToken(88);
      for (int index = 0; index < arguments.size(); ++index)
      {
        AstNode node = (AstNode) arguments.get(index);
        callOrNew.addChildToBack(this.transform(node));
        if (index < arguments.size() - 1)
          this.decompiler.addToken(90);
      }
      this.decompiler.addToken(89);
      if (obj0.getInitializer() != null)
        callOrNew.addChildToBack(this.transformObjectLiteral(obj0.getInitializer()));
      return callOrNew;
    }

    [LineNumberTable(new byte[] {162, 209, 104, 226, 69, 109, 103, 136, 104, 139, 106, 103, 127, 3, 105, 114, 105, 114, 105, 176, 215, 105, 173, 111, 105, 113, 105, 113, 105, 143, 136, 101, 141, 133, 109, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformObjectLiteral([In] ObjectLiteral obj0)
    {
      if (obj0.isDestructuring())
        return (Node) obj0;
      this.decompiler.addToken(86);
      List elements = obj0.getElements();
      Node node = new Node(67);
      object[] objArray1;
      if (elements.isEmpty())
      {
        objArray1 = ScriptRuntime.__\u003C\u003EemptyArgs;
      }
      else
      {
        int length = elements.size();
        int num = 0;
        objArray1 = new object[length];
        Iterator iterator = elements.iterator();
        while (iterator.hasNext())
        {
          ObjectProperty objectProperty = (ObjectProperty) iterator.next();
          if (objectProperty.isGetterMethod())
            this.decompiler.addToken(152);
          else if (objectProperty.isSetterMethod())
            this.decompiler.addToken(153);
          else if (objectProperty.isNormalMethod())
            this.decompiler.addToken(164);
          object[] objArray2 = objArray1;
          int index = num;
          ++num;
          object propKey = this.getPropKey((Node) objectProperty.getLeft());
          objArray2[index] = propKey;
          if (!objectProperty.isMethod())
            this.decompiler.addToken(67);
          Node child = this.transform(objectProperty.getRight());
          if (objectProperty.isGetterMethod())
            child = this.createUnary(152, child);
          else if (objectProperty.isSetterMethod())
            child = this.createUnary(153, child);
          else if (objectProperty.isNormalMethod())
            child = this.createUnary(164, child);
          node.addChildToBack(child);
          if (num < length)
            this.decompiler.addToken(90);
        }
      }
      this.decompiler.addToken(87);
      node.putProp(12, (object) objArray1);
      return node;
    }

    [LineNumberTable(new byte[] {163, 51, 119, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformRegExp([In] RegExpLiteral obj0)
    {
      this.decompiler.addRegexp(obj0.getValue(), obj0.getFlags());
      this.currentScriptOrFn.addRegExp(obj0);
      return (Node) obj0;
    }

    [LineNumberTable(new byte[] {163, 57, 115, 115, 99, 99, 178, 140, 103, 110, 112, 106, 116, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformReturn([In] ReturnStatement obj0)
    {
      int num1 = ((Boolean) Boolean.TRUE).equals(obj0.getProp(25)) ? 1 : 0;
      int num2 = ((Boolean) Boolean.TRUE).equals(obj0.getProp(27)) ? 1 : 0;
      if (num1 != 0)
      {
        if (num2 == 0)
          this.decompiler.addName(" ");
      }
      else
        this.decompiler.addToken(4);
      AstNode returnValue = obj0.getReturnValue();
      Node child = returnValue != null ? this.transform(returnValue) : (Node) null;
      if (num1 == 0)
        this.decompiler.addEOL(83);
      if (returnValue == null)
      {
        Node.__\u003Cclinit\u003E();
        return new Node(4, obj0.getLineno());
      }
      Node.__\u003Cclinit\u003E();
      return new Node(4, child, obj0.getLineno());
    }

    [LineNumberTable(new byte[] {163, 75, 112, 110, 103, 107, 123, 114, 98, 102, 103, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformScript([In] ScriptNode obj0)
    {
      this.decompiler.addToken(137);
      if (this.currentScope != null)
        Kit.codeBug();
      this.currentScope = (Scope) obj0;
      Node node1 = new Node(130);
      Iterator iterator = obj0.iterator();
      while (iterator.hasNext())
      {
        Node node2 = (Node) iterator.next();
        node1.addChildToBack(this.transform((AstNode) node2));
      }
      obj0.removeChildren();
      Node firstChild = node1.getFirstChild();
      if (firstChild != null)
        obj0.addChildrenToBack(firstChild);
      return (Node) obj0;
    }

    [LineNumberTable(new byte[] {163, 91, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformString([In] StringLiteral obj0)
    {
      this.decompiler.addString(obj0.getValue());
      return Node.newString(obj0.getValue());
    }

    [LineNumberTable(new byte[] {163, 135, 109, 109, 109, 109, 135, 119, 141, 127, 4, 104, 131, 100, 109, 140, 141, 141, 104, 103, 100, 127, 1, 111, 130, 107, 101, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformSwitch([In] SwitchStatement obj0)
    {
      this.decompiler.addToken(115);
      this.decompiler.addToken(88);
      Node child = this.transform(obj0.getExpression());
      this.decompiler.addToken(89);
      obj0.addChildToBack(child);
      Node.__\u003Cclinit\u003E();
      Node node1 = new Node(130, (Node) obj0, obj0.getLineno());
      this.decompiler.addEOL(86);
      Iterator iterator1 = obj0.getCases().iterator();
      while (iterator1.hasNext())
      {
        SwitchCase switchCase = (SwitchCase) iterator1.next();
        AstNode expression = switchCase.getExpression();
        Node node2 = (Node) null;
        if (expression != null)
        {
          this.decompiler.addToken(116);
          node2 = this.transform(expression);
        }
        else
          this.decompiler.addToken(117);
        this.decompiler.addEOL(104);
        List statements = switchCase.getStatements();
        Block block = new Block();
        if (statements != null)
        {
          Iterator iterator2 = statements.iterator();
          while (iterator2.hasNext())
          {
            AstNode node3 = (AstNode) iterator2.next();
            block.addChildToBack(this.transform(node3));
          }
        }
        this.addSwitchCase(node1, node2, (Node) block);
      }
      this.decompiler.addEOL(87);
      this.closeSwitch(node1);
      return node1;
    }

    [LineNumberTable(new byte[] {163, 171, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformThrow([In] ThrowStatement obj0)
    {
      this.decompiler.addToken(50);
      Node child = this.transform(obj0.getExpression());
      this.decompiler.addEOL(83);
      Node.__\u003Cclinit\u003E();
      return new Node(50, child, obj0.getLineno());
    }

    [LineNumberTable(new byte[] {163, 178, 109, 109, 109, 141, 102, 127, 4, 109, 141, 109, 173, 104, 100, 112, 109, 140, 135, 109, 141, 110, 141, 105, 37, 138, 101, 99, 104, 109, 109, 110, 141, 102, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformTry([In] TryStatement obj0)
    {
      this.decompiler.addToken(82);
      this.decompiler.addEOL(86);
      Node node1 = this.transform(obj0.getTryBlock());
      this.decompiler.addEOL(87);
      Block block = new Block();
      Iterator iterator = obj0.getCatchClauses().iterator();
      while (iterator.hasNext())
      {
        CatchClause catchClause = (CatchClause) iterator.next();
        this.decompiler.addToken(125);
        this.decompiler.addToken(88);
        string identifier = catchClause.getVarName().getIdentifier();
        this.decompiler.addName(identifier);
        AstNode catchCondition = catchClause.getCatchCondition();
        Node node2;
        if (catchCondition != null)
        {
          this.decompiler.addName(" ");
          this.decompiler.addToken(113);
          node2 = this.transform(catchCondition);
        }
        else
          node2 = (Node) new EmptyExpression();
        this.decompiler.addToken(89);
        this.decompiler.addEOL(86);
        Node node3 = this.transform((AstNode) catchClause.getBody());
        this.decompiler.addEOL(87);
        block.addChildToBack(this.createCatch(identifier, node2, node3, catchClause.getLineno()));
      }
      Node node4 = (Node) null;
      if (obj0.getFinallyBlock() != null)
      {
        this.decompiler.addToken(126);
        this.decompiler.addEOL(86);
        node4 = this.transform(obj0.getFinallyBlock());
        this.decompiler.addEOL(87);
      }
      return this.createTryCatchFinally(node1, (Node) block, node4, obj0.getLineno());
    }

    [LineNumberTable(new byte[] {164, 36, 109, 108, 135, 109, 109, 109, 109, 109, 109, 145, 102, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformWhileLoop([In] WhileLoop obj0)
    {
      this.decompiler.addToken(118);
      obj0.setType(133);
      this.pushScope((Scope) obj0);
      try
      {
        this.decompiler.addToken(88);
        Node node1 = this.transform(obj0.getCondition());
        this.decompiler.addToken(89);
        this.decompiler.addEOL(86);
        Node node2 = this.transform(obj0.getBody());
        this.decompiler.addEOL(87);
        return this.createLoop((Jump) obj0, 1, node2, node1, (Node) null, (Node) null);
      }
      finally
      {
        this.popScope();
      }
    }

    [LineNumberTable(new byte[] {164, 53, 109, 109, 109, 109, 109, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformWith([In] WithStatement obj0)
    {
      this.decompiler.addToken(124);
      this.decompiler.addToken(88);
      Node node1 = this.transform(obj0.getExpression());
      this.decompiler.addToken(89);
      this.decompiler.addEOL(86);
      Node node2 = this.transform(obj0.getStatement());
      this.decompiler.addEOL(87);
      return this.createWith(node1, node2, obj0.getLineno());
    }

    [LineNumberTable(new byte[] {164, 64, 113, 120, 99, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformYield([In] Yield obj0)
    {
      this.decompiler.addToken(obj0.getType());
      Node child = obj0.getValue() != null ? this.transform(obj0.getValue()) : (Node) null;
      if (child != null)
      {
        Node.__\u003Cclinit\u003E();
        return new Node(obj0.getType(), child, obj0.getLineno());
      }
      Node.__\u003Cclinit\u003E();
      return new Node(obj0.getType(), obj0.getLineno());
    }

    [LineNumberTable(new byte[] {161, 69, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformExprStmt([In] ExpressionStatement obj0)
    {
      Node child = this.transform(obj0.getExpression());
      this.decompiler.addEOL(83);
      Node.__\u003Cclinit\u003E();
      return new Node(obj0.getType(), child, obj0.getLineno());
    }

    [LineNumberTable(new byte[] {160, 232, 141, 105, 103, 132, 136, 113, 138, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformAssignment([In] Assignment obj0)
    {
      AstNode node1 = this.removeParens(obj0.getLeft());
      Node node2;
      if (this.isDestructuring((Node) node1))
      {
        this.decompile(node1);
        node2 = (Node) node1;
      }
      else
        node2 = this.transform(node1);
      this.decompiler.addToken(obj0.getType());
      return this.createAssignment(obj0.getType(), node2, this.transform(obj0.getRight()));
    }

    [LineNumberTable(new byte[] {163, 221, 103, 104, 140, 109, 104, 140, 106, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformUnary([In] UnaryExpression obj0)
    {
      int type = obj0.getType();
      if (obj0.isPrefix())
        this.decompiler.addToken(type);
      Node node = this.transform(obj0.getOperand());
      if (obj0.isPostfix())
        this.decompiler.addToken(type);
      return type == 107 || type == 108 ? this.createIncDec(type, obj0.isPostfix(), node) : this.createUnary(type, node);
    }

    [LineNumberTable(new byte[] {162, 109, 109, 113, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformInfix([In] InfixExpression obj0)
    {
      Node node1 = this.transform(obj0.getLeft());
      this.decompiler.addToken(obj0.getType());
      Node node2 = this.transform(obj0.getRight());
      return this.createBinary(obj0.getType(), node1, node2);
    }

    [LineNumberTable(new byte[] {163, 236, 113, 200, 103, 144, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformVariables([In] VariableDeclaration obj0)
    {
      this.decompiler.addToken(obj0.getType());
      this.transformVariableInitializers(obj0);
      switch (obj0.getParent())
      {
        case Loop _:
        case LetNode _:
label_2:
          return (Node) obj0;
        default:
          this.decompiler.addEOL(83);
          goto label_2;
      }
    }

    [LineNumberTable(new byte[] {163, 26, 103, 109, 98, 104, 109, 100, 142, 104, 102, 45, 166, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformParenExpr([In] ParenthesizedExpression obj0)
    {
      AstNode expression = obj0.getExpression();
      this.decompiler.addToken(88);
      int num = 1;
      for (; expression is ParenthesizedExpression; expression = ((ParenthesizedExpression) expression).getExpression())
      {
        this.decompiler.addToken(88);
        ++num;
      }
      Node node = this.transform(expression);
      for (int index = 0; index < num; ++index)
        this.decompiler.addToken(89);
      node.putProp(19, (object) Boolean.TRUE);
      return node;
    }

    [LineNumberTable(new byte[] {162, 116, 103, 103, 113, 137, 127, 8, 109, 113, 130, 146, 109, 143, 141, 110, 114, 237, 69, 103, 113, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformLabeledStatement([In] LabeledStatement obj0)
    {
      Label firstLabel = obj0.getFirstLabel();
      List labels = obj0.getLabels();
      this.decompiler.addName(firstLabel.getName());
      if (labels.size() > 1)
      {
        Iterator iterator = labels.subList(1, labels.size()).iterator();
        while (iterator.hasNext())
        {
          Label label = (Label) iterator.next();
          this.decompiler.addEOL(104);
          this.decompiler.addName(label.getName());
        }
      }
      if (obj0.getStatement().getType() == 130)
      {
        this.decompiler.addToken(67);
        this.decompiler.addEOL(86);
      }
      else
        this.decompiler.addEOL(104);
      Node mid = this.transform(obj0.getStatement());
      if (obj0.getStatement().getType() == 130)
        this.decompiler.addEOL(87);
      Node right = Node.newTarget();
      Node node = new Node(130, (Node) firstLabel, mid, right);
      firstLabel.target = right;
      return node;
    }

    [LineNumberTable(new byte[] {162, 148, 135, 112, 109, 109, 109, 103, 110, 104, 99, 146, 141, 114, 99, 173, 134, 102, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformLetNode([In] LetNode obj0)
    {
      this.pushScope((Scope) obj0);
      try
      {
        this.decompiler.addToken(154);
        this.decompiler.addToken(88);
        Node child = this.transformVariableInitializers(obj0.getVariables());
        this.decompiler.addToken(89);
        obj0.addChildToBack(child);
        int num = obj0.getType() == 159 ? 1 : 0;
        if (obj0.getBody() != null)
        {
          if (num != 0)
            this.decompiler.addName(" ");
          else
            this.decompiler.addEOL(86);
          obj0.addChildToBack(this.transform(obj0.getBody()));
          if (num == 0)
            this.decompiler.addEOL(87);
        }
        return (Node) obj0;
      }
      finally
      {
        this.popScope();
      }
    }

    [LineNumberTable(new byte[] {166, 128, 98, 106, 103, 109, 100, 109, 130, 108, 108, 109, 162, 104, 131, 102, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createCallOrNew([In] int obj0, [In] Node obj1)
    {
      int prop = 0;
      if (obj1.getType() == 39)
      {
        string str = obj1.getString();
        if (String.instancehelper_equals(str, (object) "eval"))
          prop = 1;
        else if (String.instancehelper_equals(str, (object) "With"))
          prop = 2;
      }
      else if (obj1.getType() == 33 && String.instancehelper_equals(obj1.getLastChild().getString(), (object) "eval"))
        prop = 1;
      Node node = new Node(obj0, obj1);
      if (prop != 0)
      {
        this.setRequiresActivation();
        node.putIntProp(10, prop);
      }
      return node;
    }

    [LineNumberTable(new byte[] {167, 118, 104, 99, 107, 105, 101, 107, 130, 138, 107, 130, 163, 159, 31, 137, 99, 130, 99, 130, 99, 130, 99, 130, 99, 130, 99, 130, 99, 130, 99, 130, 99, 130, 99, 130, 99, 130, 171, 103, 159, 11, 105, 111, 202, 103, 136, 211, 108, 107, 173, 103, 103, 107, 106, 206})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createAssignment([In] int obj0, [In] Node obj1, [In] Node obj2)
    {
      Node node = this.makeReference(obj1);
      if (node == null)
      {
        if (obj1.getType() == 66 || obj1.getType() == 67)
        {
          if (obj0 == 91)
            return this.createDestructuringAssignment(-1, obj1, obj2);
          this.reportError("msg.bad.destruct.op");
          return obj2;
        }
        this.reportError("msg.bad.assign.left");
        return obj2;
      }
      obj1 = node;
      int nodeType1;
      switch (obj0)
      {
        case 91:
          return this.simpleAssignment(obj1, obj2);
        case 92:
          nodeType1 = 9;
          break;
        case 93:
          nodeType1 = 10;
          break;
        case 94:
          nodeType1 = 11;
          break;
        case 95:
          nodeType1 = 18;
          break;
        case 96:
          nodeType1 = 19;
          break;
        case 97:
          nodeType1 = 20;
          break;
        case 98:
          nodeType1 = 21;
          break;
        case 99:
          nodeType1 = 22;
          break;
        case 100:
          nodeType1 = 23;
          break;
        case 101:
          nodeType1 = 24;
          break;
        case 102:
          nodeType1 = 25;
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
      int type = obj1.getType();
      switch (type)
      {
        case 33:
        case 36:
          Node firstChild1 = obj1.getFirstChild();
          Node lastChild = obj1.getLastChild();
          int nodeType2 = type != 33 ? 141 : 140;
          Node left1 = new Node(139);
          Node right1 = new Node(nodeType1, left1, obj2);
          return new Node(nodeType2, firstChild1, lastChild, right1);
        case 39:
          Node right2 = new Node(nodeType1, obj1, obj2);
          return new Node(8, Node.newString(49, obj1.getString()), right2);
        case 68:
          Node firstChild2 = obj1.getFirstChild();
          this.checkMutableReference(firstChild2);
          Node left2 = new Node(139);
          Node right3 = new Node(nodeType1, left2, obj2);
          return new Node(143, firstChild2, right3);
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [LineNumberTable(new byte[] {160, 100, 109, 103, 141, 103, 167, 104, 136, 107, 111, 112, 109, 105, 144, 141, 137, 107, 105, 175, 104, 109, 107, 171, 5, 38, 230, 70, 170, 110, 135, 105, 146, 141, 114, 237, 27, 235, 105, 102, 49, 231, 69, 143, 104, 112, 109, 109, 120, 205, 131, 109, 111, 100, 37, 135, 104, 102, 246, 69, 103, 229, 58, 231, 58, 237, 79, 105, 38, 168, 227, 61, 105, 38, 168, 130, 205, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node arrayCompTransformHelper([In] ArrayComprehension obj0, [In] string obj1)
    {
      this.decompiler.addToken(84);
      int lineno = obj0.getLineno();
      Node child = this.transform(obj0.getResult());
      List loops = obj0.getLoops();
      int length = loops.size();
      Node[] nodeArray1 = new Node[length];
      Node[] nodeArray2 = new Node[length];
      for (int index = 0; index < length; ++index)
      {
        ArrayComprehensionLoop comprehensionLoop = (ArrayComprehensionLoop) loops.get(index);
        this.decompiler.addName(" ");
        this.decompiler.addToken(120);
        if (comprehensionLoop.isForEach())
          this.decompiler.addName("each ");
        this.decompiler.addToken(88);
        AstNode iterator = comprehensionLoop.getIterator();
        string nextTempName;
        if (iterator.getType() == 39)
        {
          nextTempName = iterator.getString();
          this.decompiler.addName(nextTempName);
        }
        else
        {
          this.decompile(iterator);
          nextTempName = this.currentScriptOrFn.getNextTempName();
          this.defineSymbol(88, nextTempName, false);
          child = this.createBinary(90, this.createAssignment(91, (Node) iterator, this.createName(nextTempName)), child);
        }
        Node name = this.createName(nextTempName);
        this.defineSymbol(154, nextTempName, false);
        nodeArray1[index] = name;
        if (comprehensionLoop.isForOf())
          this.decompiler.addName("of ");
        else
          this.decompiler.addToken(52);
        nodeArray2[index] = this.transform(comprehensionLoop.getIteratedObject());
        this.decompiler.addToken(89);
      }
      Node callOrNew = this.createCallOrNew(38, this.createPropertyGet(this.createName(obj1), (string) null, "push", 0));
      Node node = new Node(134, callOrNew, lineno);
      if (obj0.getFilter() != null)
      {
        this.decompiler.addName(" ");
        this.decompiler.addToken(113);
        this.decompiler.addToken(88);
        node = this.createIf(this.transform(obj0.getFilter()), node, (Node) null, lineno);
        this.decompiler.addToken(89);
      }
      int num = 0;
      // ISSUE: fault handler
      try
      {
        for (int index = length - 1; index >= 0; index += -1)
        {
          ArrayComprehensionLoop comprehensionLoop = (ArrayComprehensionLoop) loops.get(index);
          Scope loopNode = this.createLoopNode((Node) null, comprehensionLoop.getLineno());
          this.pushScope(loopNode);
          ++num;
          node = this.createForIn(154, (Node) loopNode, nodeArray1[index], nodeArray2[index], node, comprehensionLoop.isForEach(), comprehensionLoop.isForOf());
        }
      }
      __fault
      {
        for (int index = 0; index < num; ++index)
          this.popScope();
      }
      for (int index = 0; index < num; ++index)
        this.popScope();
      this.decompiler.addToken(85);
      callOrNew.addChildToBack(child);
      return node;
    }

    [LineNumberTable(new byte[] {168, 36, 159, 74, 108, 133, 108, 133, 118, 133, 118, 133, 119, 130, 108, 130, 130, 108, 130, 113, 130, 112, 52, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void decompile([In] AstNode obj0)
    {
      switch (obj0.getType())
      {
        case 33:
          this.decompilePropertyGet((PropertyGet) obj0);
          break;
        case 36:
          this.decompileElementGet((ElementGet) obj0);
          break;
        case 39:
          this.decompiler.addName(((Name) obj0).getIdentifier());
          break;
        case 40:
          this.decompiler.addNumber(((NumberLiteral) obj0).getNumber());
          break;
        case 41:
          this.decompiler.addString(((StringLiteral) obj0).getValue());
          break;
        case 43:
          this.decompiler.addToken(obj0.getType());
          break;
        case 66:
          this.decompileArrayLiteral((ArrayLiteral) obj0);
          break;
        case 67:
          this.decompileObjectLiteral((ObjectLiteral) obj0);
          break;
        case 129:
          break;
        default:
          Kit.codeBug(new StringBuilder().append("unexpected token: ").append(Token.typeToName(obj0.getType())).toString());
          break;
      }
    }

    [LineNumberTable(new byte[] {166, 245, 223, 39, 138, 106, 105, 109, 207, 103, 109, 98, 109, 106, 118, 98, 141, 111, 103, 109, 226, 74, 106, 105, 138, 112, 98, 136, 137, 114, 177, 233, 71, 106, 105, 138, 112, 98, 136, 137, 114, 177, 233, 72, 109, 105, 138, 112, 98, 168, 137, 226, 72, 103, 132, 98, 132, 226, 74, 103, 132, 98, 132, 226, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createBinary([In] int obj0, [In] Node obj1, [In] Node obj2)
    {
      switch (obj0)
      {
        case 21:
          if (obj1.type == 41)
          {
            string str1;
            if (obj2.type == 41)
              str1 = obj2.getString();
            else if (obj2.type == 40)
              str1 = ScriptRuntime.numberToString(obj2.getDouble(), 10);
            else
              break;
            string str2 = obj1.getString();
            obj1.setString(String.instancehelper_concat(str2, str1));
            return obj1;
          }
          if (obj1.type == 40)
          {
            if (obj2.type == 40)
            {
              obj1.setDouble(obj1.getDouble() + obj2.getDouble());
              return obj1;
            }
            if (obj2.type == 41)
            {
              string str1 = ScriptRuntime.numberToString(obj1.getDouble(), 10);
              string str2 = obj2.getString();
              obj2.setString(String.instancehelper_concat(str1, str2));
              return obj2;
            }
            break;
          }
          break;
        case 22:
          if (obj1.type == 40)
          {
            double num = obj1.getDouble();
            if (obj2.type == 40)
            {
              obj1.setDouble(num - obj2.getDouble());
              return obj1;
            }
            if (num == 0.0)
              return new Node(29, obj2);
            break;
          }
          if (obj2.type == 40 && obj2.getDouble() == 0.0)
            return new Node(28, obj1);
          break;
        case 23:
          if (obj1.type == 40)
          {
            double num = obj1.getDouble();
            if (obj2.type == 40)
            {
              obj1.setDouble(num * obj2.getDouble());
              return obj1;
            }
            if (num == 1.0)
              return new Node(28, obj2);
            break;
          }
          if (obj2.type == 40 && obj2.getDouble() == 1.0)
            return new Node(28, obj1);
          break;
        case 24:
          if (obj2.type == 40)
          {
            double num = obj2.getDouble();
            if (obj1.type == 40)
            {
              obj1.setDouble(obj1.getDouble() / num);
              return obj1;
            }
            if (num == 1.0)
              return new Node(28, obj1);
            break;
          }
          break;
        case 105:
          switch (IRFactory.isAlwaysDefinedBoolean(obj1))
          {
            case -1:
              return obj2;
            case 1:
              return obj1;
          }
          break;
        case 106:
          switch (IRFactory.isAlwaysDefinedBoolean(obj1))
          {
            case -1:
              return obj1;
            case 1:
              return obj2;
          }
          break;
      }
      return new Node(obj0, obj1, obj2);
    }

    [LineNumberTable(new byte[] {166, 177, 103, 99, 136, 105, 104, 105, 105, 137, 148, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createPropertyGet([In] Node obj0, [In] string obj1, [In] string obj2, [In] int obj3)
    {
      if (obj1 == null && obj3 == 0)
      {
        if (obj0 == null)
          return this.createName(obj2);
        this.checkActivationName(obj2, 33);
        if (ScriptRuntime.isSpecialProperty(obj2))
        {
          Node child = new Node(72, obj0);
          child.putProp(17, (object) obj2);
          return new Node(68, child);
        }
        Node.__\u003Cclinit\u003E();
        return new Node(33, obj0, Node.newString(obj2));
      }
      Node node = Node.newString(obj2);
      obj3 |= 1;
      return this.createMemberRefGet(obj0, obj1, node, obj3);
    }

    [LineNumberTable(new byte[] {166, 16, 103, 100, 98, 100, 99, 162, 173, 109, 102, 104, 135, 103, 135, 99, 103, 111, 103, 103, 104, 98, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createIf([In] Node obj0, [In] Node obj1, [In] Node obj2, [In] int obj3)
    {
      switch (IRFactory.isAlwaysDefinedBoolean(obj0))
      {
        case -1:
          return obj2 != null ? obj2 : new Node(130, obj3);
        case 1:
          return obj1;
        default:
          Node node = new Node(130, obj3);
          Node child1 = Node.newTarget();
          node.addChildToBack((Node) new Jump(7, obj0)
          {
            target = child1
          });
          node.addChildrenToBack(obj1);
          if (obj2 != null)
          {
            Node child2 = Node.newTarget();
            node.addChildToBack((Node) this.makeJump(5, child2));
            node.addChildToBack(child1);
            node.addChildrenToBack(obj2);
            node.addChildToBack(child2);
          }
          else
            node.addChildToBack(child1);
          return node;
      }
    }

    [LineNumberTable(new byte[] {164, 186, 109, 99, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Scope createLoopNode([In] Node obj0, [In] int obj1)
    {
      Scope scopeNode = this.createScopeNode(133, obj1);
      ((Jump) obj0)?.setLoop((Jump) scopeNode);
      return scopeNode;
    }

    [LineNumberTable(new byte[] {158, 48, 134, 98, 130, 104, 114, 104, 105, 108, 102, 100, 98, 105, 111, 102, 146, 107, 130, 110, 99, 99, 98, 104, 142, 105, 100, 107, 194, 108, 250, 69, 107, 106, 105, 106, 105, 138, 140, 100, 109, 239, 69, 173, 140, 115, 137, 117, 104, 111, 103, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createForIn(
      [In] int obj0,
      [In] Node obj1,
      [In] Node obj2,
      [In] Node obj3,
      [In] Node obj4,
      [In] bool obj5,
      [In] bool obj6)
    {
      int num1 = obj5 ? 1 : 0;
      int num2 = obj6 ? 1 : 0;
      int num3 = -1;
      int num4 = 0;
      int num5 = obj2.getType();
      Node left;
      switch (num5)
      {
        case 66:
        case 67:
          num3 = num5;
          left = obj2;
          num4 = 0;
          if (obj2 is ArrayLiteral)
          {
            num4 = ((ArrayLiteral) obj2).getDestructuringLength();
            break;
          }
          break;
        case 123:
        case 154:
          Node lastChild = obj2.getLastChild();
          int type = lastChild.getType();
          switch (type)
          {
            case 39:
              left = Node.newString(39, lastChild.getString());
              break;
            case 66:
            case 67:
              num5 = num3 = type;
              left = lastChild;
              num4 = 0;
              if (lastChild is ArrayLiteral)
              {
                num4 = ((ArrayLiteral) lastChild).getDestructuringLength();
                break;
              }
              break;
            default:
              this.reportError("msg.bad.for.in.lhs");
              return (Node) null;
          }
          break;
        default:
          left = this.makeReference(obj2);
          if (left == null)
          {
            this.reportError("msg.bad.for.in.lhs");
            return (Node) null;
          }
          break;
      }
      Node node1 = new Node(142);
      Node child1 = new Node(num1 == 0 ? (num2 == 0 ? (num3 == -1 ? 58 : 60) : 61) : 59, obj3);
      child1.putProp(3, (object) node1);
      Node node2 = new Node(62);
      node2.putProp(3, (object) node1);
      Node right = new Node(63);
      right.putProp(3, (object) node1);
      Node node3 = new Node(130);
      Node child2;
      if (num3 != -1)
      {
        child2 = this.createDestructuringAssignment(obj0, left, right);
        if (num1 == 0 && num2 == 0 && (num3 == 67 || num4 != 2))
          this.reportError("msg.bad.for.in.destruct");
      }
      else
        child2 = this.simpleAssignment(left, right);
      node3.addChildToBack(new Node(134, child2));
      node3.addChildToBack(obj4);
      obj1 = this.createLoop((Jump) obj1, 1, node3, node2, (Node) null, (Node) null);
      obj1.addChildToFront(child1);
      if (num5 == 123 || num5 == 154)
        obj1.addChildToFront(obj2);
      node1.addChildToBack(obj1);
      return node1;
    }

    [LineNumberTable(new byte[] {168, 0, 110, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool isDestructuring([In] Node obj0) => obj0 is DestructuringForm && ((DestructuringForm) obj0).isDestructuring();

    [LineNumberTable(new byte[] {166, 49, 103, 100, 98, 100, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createCondExpr([In] Node obj0, [In] Node obj1, [In] Node obj2)
    {
      switch (IRFactory.isAlwaysDefinedBoolean(obj0))
      {
        case -1:
          return obj2;
        case 1:
          return obj1;
        default:
          return new Node(103, obj0, obj1, obj2);
      }
    }

    [LineNumberTable(new byte[] {164, 211, 102, 102, 114, 137, 105, 103, 134, 103, 103, 136, 155, 103, 103, 135, 103, 131, 139, 142, 103, 105, 105, 111, 142, 136, 103, 105, 110, 110, 138, 196, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createLoop([In] Jump obj0, [In] int obj1, [In] Node obj2, [In] Node obj3, [In] Node obj4, [In] Node obj5)
    {
      Node child1 = Node.newTarget();
      Node child2 = Node.newTarget();
      if (obj1 == 2 && obj3.getType() == 129)
        obj3 = new Node(45);
      Jump jump1 = new Jump(6, obj3);
      jump1.target = child1;
      Node child3 = Node.newTarget();
      obj0.addChildToBack(child1);
      obj0.addChildrenToBack(obj2);
      if (obj1 == 1 || obj1 == 2)
      {
        Jump jump2 = obj0;
        Node.__\u003Cclinit\u003E();
        Node children = new Node(129, obj0.getLineno());
        jump2.addChildrenToBack(children);
      }
      obj0.addChildToBack(child2);
      obj0.addChildToBack((Node) jump1);
      obj0.addChildToBack(child3);
      obj0.target = child3;
      Node continueTarget = child2;
      if (obj1 == 1 || obj1 == 2)
      {
        obj0.addChildToFront((Node) this.makeJump(5, child2));
        if (obj1 == 2)
        {
          switch (obj4.getType())
          {
            case 123:
            case 154:
              obj0.addChildToFront(obj4);
              goto case 129;
            case 129:
              Node node = Node.newTarget();
              obj0.addChildAfter(node, obj2);
              if (obj5.getType() != 129)
              {
                obj5 = new Node(134, obj5);
                obj0.addChildAfter(obj5, node);
              }
              continueTarget = node;
              break;
            default:
              obj4 = new Node(134, obj4);
              goto case 123;
          }
        }
      }
      obj0.setContinue(continueTarget);
      return (Node) obj0;
    }

    [LineNumberTable(new byte[] {164, 195, 205, 103, 108, 103, 157, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createFor([In] Scope obj0, [In] Node obj1, [In] Node obj2, [In] Node obj3, [In] Node obj4)
    {
      if (obj1.getType() != 154)
        return this.createLoop((Jump) obj0, 2, obj4, obj2, obj1, obj3);
      Scope scope = Scope.splitScope(obj0);
      scope.setType(154);
      scope.addChildrenToBack(obj1);
      scope.addChildToBack(this.createLoop((Jump) obj0, 2, obj4, obj2, new Node(129), obj3));
      return (Node) scope;
    }

    [LineNumberTable(new byte[] {168, 5, 98, 104, 115, 104, 141, 106, 113, 99, 141, 103, 109, 115, 108, 237, 61, 232, 70, 99, 141, 99, 144, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Node decompileFunctionHeader([In] FunctionNode obj0)
    {
      Node node = (Node) null;
      if (obj0.getFunctionName() != null)
        this.decompiler.addName(obj0.getName());
      else if (obj0.getMemberExprNode() != null)
        node = this.transform(obj0.getMemberExprNode());
      int num1 = obj0.getFunctionType() == 4 ? 1 : 0;
      int num2 = num1 == 0 || obj0.getLp() != -1 ? 0 : 1;
      if (num2 == 0)
        this.decompiler.addToken(88);
      List list = obj0.getParams();
      for (int index = 0; index < list.size(); ++index)
      {
        this.decompile((AstNode) list.get(index));
        if (index < list.size() - 1)
          this.decompiler.addToken(90);
      }
      if (num2 == 0)
        this.decompiler.addToken(89);
      if (num1 != 0)
        this.decompiler.addToken(165);
      if (!obj0.isExpressionClosure())
        this.decompiler.addEOL(86);
      return node;
    }

    [LineNumberTable(new byte[] {164, 139, 104, 135, 103, 131, 166, 104, 103, 109, 236, 72, 115, 179, 37, 183, 231, 69, 103, 108, 172, 110, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node initFunction([In] FunctionNode obj0, [In] int obj1, [In] Node obj2, [In] int obj3)
    {
      obj0.setFunctionType(obj3);
      obj0.addChildToBack(obj2);
      if (obj0.getFunctionCount() != 0)
        obj0.setRequiresActivation();
      if (obj3 == 2)
      {
        Name functionName = obj0.getFunctionName();
        if (functionName != null && functionName.length() != 0 && obj0.getSymbol(functionName.getIdentifier()) == null)
        {
          obj0.putSymbol(new rhino.ast.Symbol(110, functionName.getIdentifier()));
          Node.__\u003Cclinit\u003E();
          Node.__\u003Cclinit\u003E();
          Node children = new Node(134, new Node(8, Node.newString(49, functionName.getIdentifier()), new Node(64)));
          obj2.addChildrenToFront(children);
        }
      }
      Node lastChild = obj2.getLastChild();
      if (lastChild == null || lastChild.getType() != 4)
        obj2.addChildToBack(new Node(4));
      Node node = Node.newString(110, obj0.getName());
      node.putIntProp(1, obj1);
      return node;
    }

    [LineNumberTable(1251)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createExprStatementNoReturn([In] Node obj0, [In] int obj1) => new Node(134, obj0, obj1);

    [LineNumberTable(new byte[] {162, 1, 109, 103, 141, 103, 167, 104, 136, 107, 111, 112, 109, 141, 137, 107, 105, 175, 104, 109, 107, 171, 5, 38, 230, 70, 170, 110, 135, 105, 146, 141, 114, 237, 30, 235, 102, 149, 143, 104, 112, 109, 109, 120, 205, 131, 109, 111, 100, 37, 135, 104, 102, 246, 69, 103, 229, 58, 231, 58, 237, 79, 105, 38, 168, 227, 61, 105, 38, 168, 130, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node genExprTransformHelper([In] GeneratorExpression obj0)
    {
      this.decompiler.addToken(88);
      int lineno = obj0.getLineno();
      Node child = this.transform(obj0.getResult());
      List loops = obj0.getLoops();
      int length = loops.size();
      Node[] nodeArray1 = new Node[length];
      Node[] nodeArray2 = new Node[length];
      for (int index = 0; index < length; ++index)
      {
        GeneratorExpressionLoop generatorExpressionLoop = (GeneratorExpressionLoop) loops.get(index);
        this.decompiler.addName(" ");
        this.decompiler.addToken(120);
        this.decompiler.addToken(88);
        AstNode iterator = generatorExpressionLoop.getIterator();
        string nextTempName;
        if (iterator.getType() == 39)
        {
          nextTempName = iterator.getString();
          this.decompiler.addName(nextTempName);
        }
        else
        {
          this.decompile(iterator);
          nextTempName = this.currentScriptOrFn.getNextTempName();
          this.defineSymbol(88, nextTempName, false);
          child = this.createBinary(90, this.createAssignment(91, (Node) iterator, this.createName(nextTempName)), child);
        }
        Node name = this.createName(nextTempName);
        this.defineSymbol(154, nextTempName, false);
        nodeArray1[index] = name;
        if (generatorExpressionLoop.isForOf())
          this.decompiler.addName("of ");
        else
          this.decompiler.addToken(52);
        nodeArray2[index] = this.transform(generatorExpressionLoop.getIteratedObject());
        this.decompiler.addToken(89);
      }
      Node.__\u003Cclinit\u003E();
      Node node = new Node(134, new Node(73, child, obj0.getLineno()), lineno);
      if (obj0.getFilter() != null)
      {
        this.decompiler.addName(" ");
        this.decompiler.addToken(113);
        this.decompiler.addToken(88);
        node = this.createIf(this.transform(obj0.getFilter()), node, (Node) null, lineno);
        this.decompiler.addToken(89);
      }
      int num = 0;
      // ISSUE: fault handler
      try
      {
        for (int index = length - 1; index >= 0; index += -1)
        {
          GeneratorExpressionLoop generatorExpressionLoop = (GeneratorExpressionLoop) loops.get(index);
          Scope loopNode = this.createLoopNode((Node) null, generatorExpressionLoop.getLineno());
          this.pushScope(loopNode);
          ++num;
          node = this.createForIn(154, (Node) loopNode, nodeArray1[index], nodeArray2[index], node, generatorExpressionLoop.isForEach(), generatorExpressionLoop.isForOf());
        }
      }
      __fault
      {
        for (int index = 0; index < num; ++index)
          this.popScope();
      }
      for (int index = 0; index < num; ++index)
        this.popScope();
      this.decompiler.addToken(89);
      return node;
    }

    [LineNumberTable(new byte[] {163, 250, 103, 105, 127, 0, 105, 169, 105, 104, 134, 170, 99, 100, 109, 170, 105, 100, 138, 146, 104, 130, 100, 137, 136, 106, 141, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node transformVariableInitializers([In] VariableDeclaration obj0)
    {
      List variables = obj0.getVariables();
      int num1 = variables.size();
      int num2 = 0;
      Iterator iterator = variables.iterator();
      while (iterator.hasNext())
      {
        VariableInitializer variableInitializer = (VariableInitializer) iterator.next();
        AstNode target = variableInitializer.getTarget();
        AstNode initializer = variableInitializer.getInitializer();
        Node child1;
        if (variableInitializer.isDestructuring())
        {
          this.decompile(target);
          child1 = (Node) target;
        }
        else
          child1 = this.transform(target);
        Node child2 = (Node) null;
        if (initializer != null)
        {
          this.decompiler.addToken(91);
          child2 = this.transform(initializer);
        }
        if (variableInitializer.isDestructuring())
        {
          if (child2 == null)
          {
            obj0.addChildToBack(child1);
          }
          else
          {
            Node destructuringAssignment = this.createDestructuringAssignment(obj0.getType(), child1, child2);
            obj0.addChildToBack(destructuringAssignment);
          }
        }
        else
        {
          if (child2 != null)
            child1.addChildToBack(child2);
          obj0.addChildToBack(child1);
        }
        int num3 = num2;
        ++num2;
        int num4 = num1 - 1;
        if (num3 < num4)
          this.decompiler.addToken(90);
      }
      return (Node) obj0;
    }

    [LineNumberTable(new byte[] {163, 7, 104, 108, 108, 103, 109, 108, 108, 103, 106, 110, 108, 103, 98, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getPropKey([In] Node obj0)
    {
      switch (obj0)
      {
        case Name _:
          string identifier = ((Name) obj0).getIdentifier();
          this.decompiler.addName(identifier);
          return ScriptRuntime.getIndexObject(identifier);
        case StringLiteral _:
          string str = ((StringLiteral) obj0).getValue();
          this.decompiler.addString(str);
          return ScriptRuntime.getIndexObject(str);
        case NumberLiteral _:
          double number = ((NumberLiteral) obj0).getNumber();
          this.decompiler.addNumber(number);
          return ScriptRuntime.getIndexObject(number);
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [LineNumberTable(new byte[] {166, 59, 103, 191, 11, 165, 105, 98, 108, 105, 143, 103, 103, 103, 103, 105, 103, 103, 103, 105, 130, 148, 162, 104, 108, 194, 104, 110, 107, 194, 101, 110, 194, 104, 132, 101, 134, 132, 106, 105, 130, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createUnary([In] int obj0, [In] Node obj1)
    {
      int type = obj1.getType();
      switch (obj0)
      {
        case 26:
          int num;
          switch (IRFactory.isAlwaysDefinedBoolean(obj1))
          {
            case 0:
              goto label_19;
            case 1:
              num = 44;
              break;
            default:
              num = 45;
              break;
          }
          if (type != 45 && type != 44)
            return new Node(num);
          obj1.setType(num);
          return obj1;
        case 27:
          if (type == 40)
          {
            int int32 = ScriptRuntime.toInt32(obj1.getDouble());
            obj1.setDouble((double) (int32 ^ -1));
            return obj1;
          }
          break;
        case 29:
          if (type == 40)
          {
            obj1.setDouble(-obj1.getDouble());
            return obj1;
          }
          break;
        case 31:
          Node node;
          switch (type)
          {
            case 33:
            case 36:
              Node firstChild1 = obj1.getFirstChild();
              Node lastChild = obj1.getLastChild();
              obj1.removeChild(firstChild1);
              obj1.removeChild(lastChild);
              node = new Node(obj0, firstChild1, lastChild);
              break;
            case 39:
              obj1.setType(49);
              Node left = obj1;
              Node right = Node.newString(obj1.getString());
              node = new Node(obj0, left, right);
              break;
            case 68:
              Node firstChild2 = obj1.getFirstChild();
              obj1.removeChild(firstChild2);
              node = new Node(70, firstChild2);
              break;
            default:
              Node.__\u003Cclinit\u003E();
              node = new Node(obj0, new Node(45), obj1);
              break;
          }
          return node;
        case 32:
          if (type == 39)
          {
            obj1.setType(138);
            return obj1;
          }
          break;
      }
label_19:
      return new Node(obj0, obj1);
    }

    [LineNumberTable(new byte[] {164, 76, 120, 108, 149, 102, 99, 105, 103, 103, 98, 135, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addSwitchCase([In] Node obj0, [In] Node obj1, [In] Node obj2)
    {
      Jump jump = obj0.getType() == 130 ? (Jump) obj0.getFirstChild() : throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      if (jump.getType() != 115)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      Node node = Node.newTarget();
      if (obj1 != null)
        jump.addChildToBack((Node) new Jump(116, obj1)
        {
          target = node
        });
      else
        jump.setDefault(node);
      obj0.addChildToBack(node);
      obj0.addChildToBack(obj2);
    }

    [LineNumberTable(new byte[] {164, 93, 120, 108, 149, 166, 135, 103, 99, 162, 143, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void closeSwitch([In] Node obj0)
    {
      Jump jump = obj0.getType() == 130 ? (Jump) obj0.getFirstChild() : throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      if (jump.getType() != 115)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      Node child = Node.newTarget();
      jump.target = child;
      Node node = jump.getDefault() ?? child;
      obj0.addChildAfter((Node) this.makeJump(5, node), (Node) jump);
      obj0.addChildToBack(child);
    }

    [LineNumberTable(new byte[] {164, 130, 99, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createCatch([In] string obj0, [In] Node obj1, [In] Node obj2, [In] int obj3)
    {
      if (obj1 == null)
        obj1 = new Node(129);
      Node.__\u003Cclinit\u003E();
      return new Node(125, this.createName(obj0), obj1, obj2, obj3);
    }

    [LineNumberTable(new byte[] {165, 97, 100, 109, 172, 152, 162, 167, 134, 162, 107, 107, 136, 134, 103, 175, 103, 136, 232, 114, 172, 104, 99, 99, 103, 137, 105, 105, 105, 105, 105, 233, 70, 109, 208, 110, 100, 133, 239, 70, 107, 108, 106, 107, 169, 102, 46, 229, 69, 105, 102, 101, 104, 132, 105, 105, 168, 168, 102, 103, 168, 179, 103, 143, 104, 106, 105, 136, 136, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createTryCatchFinally([In] Node obj0, [In] Node obj1, [In] Node obj2, [In] int obj3)
    {
      int num1 = obj2 == null || obj2.getType() == 130 && !obj2.hasChildren() ? 0 : 1;
      if (obj0.getType() == 130 && !obj0.hasChildren() && num1 == 0)
        return obj0;
      int num2 = obj1.hasChildren() ? 1 : 0;
      if (num1 == 0 && num2 == 0)
        return obj0;
      Node node1 = new Node(142);
      Jump jump = new Jump(82, obj0, obj3);
      jump.putProp(3, (object) node1);
      if (num2 != 0)
      {
        Node child1 = Node.newTarget();
        jump.addChildToBack((Node) this.makeJump(5, child1));
        Node child2 = Node.newTarget();
        jump.target = child2;
        jump.addChildToBack(child2);
        Node child3 = new Node(142);
        Node node2 = obj1.getFirstChild();
        int num3 = 0;
        int prop = 0;
        while (node2 != null)
        {
          int lineno = node2.getLineno();
          Node firstChild = node2.getFirstChild();
          Node next1 = firstChild.getNext();
          Node next2 = next1.getNext();
          node2.removeChild(firstChild);
          node2.removeChild(next1);
          node2.removeChild(next2);
          next2.addChildToBack(new Node(3));
          next2.addChildToBack((Node) this.makeJump(5, child1));
          Node node3;
          if (next1.getType() == 129)
          {
            node3 = next2;
            num3 = 1;
          }
          else
            node3 = this.createIf(next1, next2, (Node) null, lineno);
          Node.__\u003Cclinit\u003E();
          Node child4 = new Node(57, firstChild, this.createUseLocal(node1));
          child4.putProp(3, (object) child3);
          child4.putIntProp(14, prop);
          child3.addChildToBack(child4);
          child3.addChildToBack(this.createWith(this.createUseLocal(child3), node3, lineno));
          node2 = node2.getNext();
          ++prop;
        }
        jump.addChildToBack(child3);
        if (num3 == 0)
        {
          Node child4 = new Node(51);
          child4.putProp(3, (object) node1);
          jump.addChildToBack(child4);
        }
        jump.addChildToBack(child1);
      }
      if (num1 != 0)
      {
        Node node2 = Node.newTarget();
        jump.setFinally(node2);
        jump.addChildToBack((Node) this.makeJump(136, node2));
        Node child1 = Node.newTarget();
        jump.addChildToBack((Node) this.makeJump(5, child1));
        jump.addChildToBack(node2);
        Node child2 = new Node(126, obj2);
        child2.putProp(3, (object) node1);
        jump.addChildToBack(child2);
        jump.addChildToBack(child1);
      }
      node1.addChildToBack((Node) jump);
      return node1;
    }

    [LineNumberTable(new byte[] {157, 204, 130, 105, 135, 255, 5, 69, 104, 98, 101, 132, 99, 132, 105, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createIncDec([In] int obj0, [In] bool obj1, [In] Node obj2)
    {
      int num = obj1 ? 1 : 0;
      obj2 = this.makeReference(obj2);
      switch (obj2.getType())
      {
        case 33:
        case 36:
        case 39:
        case 68:
          Node node = new Node(obj0, obj2);
          int prop = 0;
          if (obj0 == 108)
            prop |= 1;
          if (num != 0)
            prop |= 2;
          node.putIntProp(13, prop);
          return node;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
    }

    [LineNumberTable(new byte[] {166, 6, 102, 108, 109, 106, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createWith([In] Node obj0, [In] Node obj1, [In] int obj2)
    {
      this.setRequiresActivation();
      Node node = new Node(130, obj2);
      node.addChildToBack(new Node(2, obj0));
      Node children = new Node(124, obj1, obj2);
      node.addChildrenToBack(children);
      node.addChildToBack(new Node(3));
      return node;
    }

    [LineNumberTable(new byte[] {167, 214, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Jump makeJump([In] int obj0, [In] Node obj1) => new Jump(obj0)
    {
      target = obj1
    };

    [LineNumberTable(new byte[] {167, 220, 103, 255, 13, 69, 130, 105, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node makeReference([In] Node obj0)
    {
      switch (obj0.getType())
      {
        case 33:
        case 36:
        case 39:
        case 68:
          return obj0;
        case 38:
          obj0.setType(71);
          return new Node(68, obj0);
        default:
          return (Node) null;
      }
    }

    [LineNumberTable(new byte[] {167, 207, 120, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createUseLocal([In] Node obj0)
    {
      if (142 != obj0.getType())
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      Node node = new Node(54);
      node.putProp(3, (object) obj0);
      return node;
    }

    [LineNumberTable(new byte[] {167, 237, 191, 9, 130, 130, 105, 112, 130, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int isAlwaysDefinedBoolean([In] Node obj0)
    {
      switch (obj0.getType())
      {
        case 40:
          double num = obj0.getDouble();
          return !Double.isNaN(num) && num != 0.0 ? 1 : -1;
        case 42:
        case 44:
          return -1;
        case 45:
          return 1;
        default:
          return 0;
      }
    }

    [LineNumberTable(new byte[] {166, 215, 98, 131, 109, 138, 200, 99, 99, 139, 172, 99, 140, 171, 100, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createMemberRefGet([In] Node obj0, [In] string obj1, [In] Node obj2, [In] int obj3)
    {
      Node node = (Node) null;
      if (obj1 != null)
        node = !String.instancehelper_equals(obj1, (object) "*") ? this.createName(obj1) : new Node(42);
      Node child = obj0 != null ? (obj1 != null ? new Node(79, obj0, node, obj2) : new Node(78, obj0, obj2)) : (obj1 != null ? new Node(81, node, obj2) : new Node(80, obj2));
      if (obj3 != 0)
        child.putIntProp(16, obj3);
      return new Node(68, child);
    }

    [LineNumberTable(new byte[] {168, 71, 109, 103, 103, 102, 109, 103, 102, 237, 60, 230, 71, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void decompileArrayLiteral([In] ArrayLiteral obj0)
    {
      this.decompiler.addToken(84);
      List elements = obj0.getElements();
      int num = elements.size();
      for (int index = 0; index < num; ++index)
      {
        this.decompile((AstNode) elements.get(index));
        if (index < num - 1)
          this.decompiler.addToken(90);
      }
      this.decompiler.addToken(85);
    }

    [LineNumberTable(new byte[] {168, 86, 109, 103, 103, 105, 109, 104, 108, 108, 100, 109, 140, 102, 237, 54, 233, 77, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void decompileObjectLiteral([In] ObjectLiteral obj0)
    {
      this.decompiler.addToken(86);
      List elements = obj0.getElements();
      int num1 = elements.size();
      for (int index = 0; index < num1; ++index)
      {
        ObjectProperty objectProperty = (ObjectProperty) elements.get(index);
        int num2 = ((Boolean) Boolean.TRUE).equals(objectProperty.getProp(26)) ? 1 : 0;
        this.decompile(objectProperty.getLeft());
        if (num2 == 0)
        {
          this.decompiler.addToken(104);
          this.decompile(objectProperty.getRight());
        }
        if (index < num1 - 1)
          this.decompiler.addToken(90);
      }
      this.decompiler.addToken(87);
    }

    [LineNumberTable(new byte[] {168, 107, 108, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void decompilePropertyGet([In] PropertyGet obj0)
    {
      this.decompile(obj0.getTarget());
      this.decompiler.addToken(109);
      this.decompile((AstNode) obj0.getProperty());
    }

    [LineNumberTable(new byte[] {168, 114, 108, 109, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void decompileElementGet([In] ElementGet obj0)
    {
      this.decompile(obj0.getTarget());
      this.decompiler.addToken(84);
      this.decompile(obj0.getElement());
      this.decompiler.addToken(85);
    }

    [LineNumberTable(new byte[] {159, 167, 232, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IRFactory()
    {
      IRFactory irFactory = this;
      this.decompiler = new Decompiler();
    }

    [LineNumberTable(new byte[] {159, 171, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IRFactory(CompilerEnvirons env)
      : this(env, env.getErrorReporter())
    {
    }

    [LineNumberTable(1255)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createString([In] string obj0) => Node.newString(obj0);

    [LineNumberTable(new byte[] {166, 204, 167, 110, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Node createElementGet([In] Node obj0, [In] string obj1, [In] Node obj2, [In] int obj3)
    {
      if (obj1 != null || obj3 != 0)
        return this.createMemberRefGet(obj0, obj1, obj2, obj3);
      return obj0 != null ? new Node(36, obj0, obj2) : throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
    }
  }
}
