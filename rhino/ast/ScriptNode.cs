// Decompiled with JetBrains decompiler
// Type: rhino.ast.ScriptNode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.ast
{
  public class ScriptNode : Scope
  {
    private int encodedSourceStart;
    private int encodedSourceEnd;
    private string sourceName;
    private string encodedSource;
    private int endLineno;
    [Signature("Ljava/util/List<Lrhino/ast/FunctionNode;>;")]
    private List functions;
    [Signature("Ljava/util/List<Lrhino/ast/RegExpLiteral;>;")]
    private List regexps;
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/FunctionNode;>;")]
    private List EMPTY_LIST;
    [Signature("Ljava/util/List<Lrhino/ast/Symbol;>;")]
    private List symbols;
    private int paramCount;
    private string[] variableNames;
    private bool[] isConsts;
    private object compilerData;
    private int tempNumber;
    private bool inStrictMode;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(157)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FunctionNode getFunctionNode(int i) => (FunctionNode) this.functions.get(i);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSourceName() => this.sourceName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isInStrictMode() => this.inStrictMode;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getBaseLineno() => this.lineno;

    [LineNumberTable(new byte[] {160, 105, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getParamAndVarCount()
    {
      if (this.variableNames == null)
        AstNode.codeBug();
      return this.symbols.size();
    }

    [LineNumberTable(new byte[] {160, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getParamAndVarNames()
    {
      if (this.variableNames == null)
        AstNode.codeBug();
      return this.variableNames;
    }

    [LineNumberTable(new byte[] {160, 115, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool[] getParamAndVarConst()
    {
      if (this.variableNames == null)
        AstNode.codeBug();
      return this.isConsts;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getParamCount() => this.paramCount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getEncodedSourceStart() => this.encodedSourceStart;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getEncodedSourceEnd() => this.encodedSourceEnd;

    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFunctionCount() => this.functions == null ? 0 : this.functions.size();

    [LineNumberTable(178)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRegexpCount() => this.regexps == null ? 0 : this.regexps.size();

    [LineNumberTable(182)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getRegexpString(int index) => ((RegExpLiteral) this.regexps.get(index)).getValue();

    [LineNumberTable(186)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getRegexpFlags(int index) => ((RegExpLiteral) this.regexps.get(index)).getFlags();

    [LineNumberTable(new byte[] {160, 87, 110, 103, 141, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getIndexForNameNode(Node nameNode)
    {
      if (this.variableNames == null)
        AstNode.codeBug();
      Symbol symbol = nameNode.getScope()?.getSymbol(((Name) nameNode).getIdentifier());
      return symbol == null ? -1 : symbol.getIndex();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getEncodedSource() => this.encodedSource;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInStrictMode(bool inStrictMode) => this.inStrictMode = inStrictMode;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSourceName(string sourceName) => this.sourceName = sourceName;

    [LineNumberTable(new byte[] {88, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBaseLineno(int lineno)
    {
      if (lineno < 0 || this.lineno >= 0)
        AstNode.codeBug();
      this.lineno = lineno;
    }

    [LineNumberTable(new byte[] {98, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEndLineno(int lineno)
    {
      if (lineno < 0 || this.endLineno >= 0)
        AstNode.codeBug();
      this.endLineno = lineno;
    }

    [LineNumberTable(295)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getNextTempName()
    {
      StringBuilder stringBuilder = new StringBuilder().append("$");
      ScriptNode scriptNode1 = this;
      int tempNumber = scriptNode1.tempNumber;
      ScriptNode scriptNode2 = scriptNode1;
      int num = tempNumber;
      scriptNode2.tempNumber = tempNumber + 1;
      return stringBuilder.append(num).toString();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEncodedSourceBounds(int start, int end)
    {
      this.encodedSourceStart = start;
      this.encodedSourceEnd = end;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEncodedSource(string encodedSource) => this.encodedSource = encodedSource;

    [LineNumberTable(new byte[] {120, 105, 104, 107, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int addFunction(FunctionNode fnNode)
    {
      if (fnNode == null)
        AstNode.codeBug();
      if (this.functions == null)
        this.functions = (List) new ArrayList();
      this.functions.add((object) fnNode);
      return this.functions.size() - 1;
    }

    [LineNumberTable(new byte[] {160, 79, 105, 104, 107, 109, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addRegExp(RegExpLiteral re)
    {
      if (re == null)
        AstNode.codeBug();
      if (this.regexps == null)
        this.regexps = (List) new ArrayList();
      this.regexps.add((object) re);
      re.putIntProp(4, this.regexps.size() - 1);
    }

    [LineNumberTable(new byte[] {159, 78, 98, 102, 102, 200, 112, 114, 110, 232, 61, 230, 71, 135, 118, 118, 114, 116, 112, 119, 233, 60, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flattenSymbolTable(bool flattenAllTables)
    {
      if (!flattenAllTables)
      {
        ArrayList arrayList = new ArrayList();
        if (this.symbolTable != null)
        {
          for (int index = 0; index < this.symbols.size(); ++index)
          {
            Symbol symbol = (Symbol) this.symbols.get(index);
            if (object.ReferenceEquals((object) symbol.getContainingTable(), (object) this))
              ((List) arrayList).add((object) symbol);
          }
        }
        this.symbols = (List) arrayList;
      }
      this.variableNames = new string[this.symbols.size()];
      this.isConsts = new bool[this.symbols.size()];
      for (int index = 0; index < this.symbols.size(); ++index)
      {
        Symbol symbol = (Symbol) this.symbols.get(index);
        this.variableNames[index] = symbol.getName();
        this.isConsts[index] = symbol.getDeclType() == 155;
        symbol.setIndex(index);
      }
    }

    [LineNumberTable(new byte[] {160, 120, 110, 106, 142, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addSymbol([In] Symbol obj0)
    {
      if (this.variableNames != null)
        AstNode.codeBug();
      if (obj0.getDeclType() == 88)
        ++this.paramCount;
      this.symbols.add((object) obj0);
    }

    [LineNumberTable(new byte[] {159, 180, 232, 39, 103, 167, 199, 139, 108, 231, 69, 231, 69, 103, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScriptNode()
    {
      ScriptNode scriptNode = this;
      this.encodedSourceStart = -1;
      this.encodedSourceEnd = -1;
      this.endLineno = -1;
      this.EMPTY_LIST = Collections.emptyList();
      this.symbols = (List) new ArrayList(4);
      this.paramCount = 0;
      this.tempNumber = 0;
      this.top = this;
      this.type = 137;
    }

    [LineNumberTable(new byte[] {159, 184, 233, 35, 103, 167, 199, 139, 108, 231, 69, 231, 69, 103, 235, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScriptNode(int pos)
      : base(pos)
    {
      ScriptNode scriptNode = this;
      this.encodedSourceStart = -1;
      this.encodedSourceEnd = -1;
      this.endLineno = -1;
      this.EMPTY_LIST = Collections.emptyList();
      this.symbols = (List) new ArrayList(4);
      this.paramCount = 0;
      this.tempNumber = 0;
      this.top = this;
      this.type = 137;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEncodedSourceStart(int start) => this.encodedSourceStart = start;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEncodedSourceEnd(int end) => this.encodedSourceEnd = end;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getEndLineno() => this.endLineno;

    [Signature("()Ljava/util/List<Lrhino/ast/FunctionNode;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getFunctions() => this.functions == null ? this.EMPTY_LIST : this.functions;

    [LineNumberTable(new byte[] {160, 96, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getParamOrVarName(int index)
    {
      if (this.variableNames == null)
        AstNode.codeBug();
      return this.variableNames[index];
    }

    [Signature("()Ljava/util/List<Lrhino/ast/Symbol;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getSymbols() => this.symbols;

    [Signature("(Ljava/util/List<Lrhino/ast/Symbol;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSymbols(List symbols) => this.symbols = symbols;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getCompilerData() => this.compilerData;

    [LineNumberTable(new byte[] {160, 173, 135, 104, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCompilerData(object data)
    {
      this.assertNotNull(data);
      if (this.compilerData != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      this.compilerData = data;
    }

    [LineNumberTable(new byte[] {160, 194, 105, 123, 116, 130})]
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
    static ScriptNode() => Scope.__\u003Cclinit\u003E();
  }
}
