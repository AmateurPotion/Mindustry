// Decompiled with JetBrains decompiler
// Type: rhino.ast.Scope
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class Scope : Jump
  {
    [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/ast/Symbol;>;")]
    protected internal Map symbolTable;
    protected internal Scope parentScope;
    protected internal ScriptNode top;
    [Signature("Ljava/util/List<Lrhino/ast/Scope;>;")]
    private List childScopes;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scope getParentScope() => this.parentScope;

    [LineNumberTable(new byte[] {20, 104, 139, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildScope(Scope child)
    {
      if (this.childScopes == null)
        this.childScopes = (List) new ArrayList();
      this.childScopes.add((object) child);
      child.setParentScope(this);
    }

    [LineNumberTable(new byte[] {159, 186, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParentScope(Scope parentScope)
    {
      this.parentScope = parentScope;
      this.top = parentScope != null ? parentScope.top : (ScriptNode) this;
    }

    [LineNumberTable(new byte[] {159, 166, 232, 61, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Scope()
    {
      Scope scope = this;
      this.type = 130;
    }

    [LineNumberTable(new byte[] {36, 104, 127, 1, 103, 98, 107, 135, 117, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void replaceWith(Scope newScope)
    {
      if (this.childScopes != null)
      {
        Iterator iterator = this.childScopes.iterator();
        while (iterator.hasNext())
        {
          Scope child = (Scope) iterator.next();
          newScope.addChildScope(child);
        }
        this.childScopes.clear();
        this.childScopes = (List) null;
      }
      if (this.symbolTable == null || this.symbolTable.isEmpty())
        return;
      Scope.joinScopes(this, newScope);
    }

    [LineNumberTable(new byte[] {159, 169, 232, 58, 235, 71, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Scope(int pos)
    {
      Scope scope = this;
      this.type = 130;
      this.position = pos;
    }

    [LineNumberTable(new byte[] {103, 101, 103, 108, 226, 61, 233, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scope getDefiningScope(string name)
    {
      for (Scope scope = this; scope != null; scope = scope.parentScope)
      {
        Map symbolTable = scope.getSymbolTable();
        if (symbolTable != null && symbolTable.containsKey((object) name))
          return scope;
      }
      return (Scope) null;
    }

    [LineNumberTable(168)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Symbol getSymbol(string name) => this.symbolTable == null ? (Symbol) null : (Symbol) this.symbolTable.get((object) name);

    [LineNumberTable(new byte[] {125, 104, 112, 103, 115, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putSymbol(Symbol symbol)
    {
      if (symbol.getName() == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("null symbol name");
      }
      this.ensureSymbolTable();
      this.symbolTable.put((object) symbol.getName(), (object) symbol);
      symbol.setContainingTable(this);
      this.top.addSymbol(symbol);
    }

    [LineNumberTable(new byte[] {69, 108, 108, 103, 108, 108, 103, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scope splitScope(Scope scope)
    {
      Scope parentScope = new Scope(scope.getType());
      parentScope.symbolTable = scope.symbolTable;
      scope.symbolTable = (Map) null;
      parentScope.parent = scope.parent;
      parentScope.setParentScope(scope.getParentScope());
      parentScope.setParentScope(parentScope);
      scope.parent = (AstNode) parentScope;
      parentScope.top = scope.top;
      return parentScope;
    }

    [Signature("()Ljava/util/Map<Ljava/lang/String;Lrhino/ast/Symbol;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Map getSymbolTable() => this.symbolTable;

    [Signature("(Ljava/util/Map<Ljava/lang/String;Lrhino/ast/Symbol;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSymbolTable(Map table) => this.symbolTable = table;

    [LineNumberTable(new byte[] {84, 103, 103, 115, 134, 127, 1, 109, 104, 111, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void joinScopes(Scope source, Scope dest)
    {
      Map map1 = source.ensureSymbolTable();
      Map map2 = dest.ensureSymbolTable();
      if (!Collections.disjoint((Collection) map1.keySet(), (Collection) map2.keySet()))
        AstNode.codeBug();
      Iterator iterator = map1.entrySet().iterator();
      while (iterator.hasNext())
      {
        Map.Entry entry = (Map.Entry) iterator.next();
        Symbol symbol = (Symbol) entry.getValue();
        symbol.setContainingTable(dest);
        map2.put(entry.getKey(), (object) symbol);
      }
    }

    [Signature("()Ljava/util/Map<Ljava/lang/String;Lrhino/ast/Symbol;>;")]
    [LineNumberTable(new byte[] {160, 85, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Map ensureSymbolTable()
    {
      if (this.symbolTable == null)
        this.symbolTable = (Map) new LinkedHashMap(5);
      return this.symbolTable;
    }

    [LineNumberTable(new byte[] {159, 174, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Scope(int pos, int len)
      : this(pos)
    {
      Scope scope = this;
      this.length = len;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearParentScope() => this.parentScope = (Scope) null;

    [Signature("()Ljava/util/List<Lrhino/ast/Scope;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getChildScopes() => this.childScopes;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptNode getTop() => this.top;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTop(ScriptNode top) => this.top = top;

    [Signature("()Ljava/util/List<Lrhino/ast/AstNode;>;")]
    [LineNumberTable(new byte[] {160, 99, 102, 103, 99, 109, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getStatements()
    {
      ArrayList arrayList = new ArrayList();
      for (Node node = this.getFirstChild(); node != null; node = node.getNext())
        ((List) arrayList).add((object) (AstNode) node);
      return (List) arrayList;
    }

    [LineNumberTable(new byte[] {160, 110, 102, 110, 108, 123, 103, 112, 109, 140, 98, 110, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("{\n");
      Iterator iterator = this.iterator();
      while (iterator.hasNext())
      {
        AstNode astNode = (AstNode) iterator.next();
        stringBuilder.append(astNode.toSource(depth + 1));
        if (astNode.getType() == 162)
          stringBuilder.append("\n");
      }
      stringBuilder.append(this.makeIndent(depth));
      stringBuilder.append("}\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 127, 105, 123, 116, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      Iterator iterator = this.iterator();
      while (iterator.hasNext())
      {
        Node node = (Node) iterator.next();
        if (node is AstNode)
          ((AstNode) node).visit(v);
      }
    }

    [HideFromJava]
    static Scope() => Jump.__\u003Cclinit\u003E();
  }
}
