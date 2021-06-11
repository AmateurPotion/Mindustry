// Decompiled with JetBrains decompiler
// Type: rhino.ast.FunctionNode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.ast
{
  public class FunctionNode : ScriptNode
  {
    public const int FUNCTION_STATEMENT = 1;
    public const int FUNCTION_EXPRESSION = 2;
    public const int FUNCTION_EXPRESSION_STATEMENT = 3;
    public const int ARROW_FUNCTION = 4;
    [Modifiers]
    [Signature("Ljava/util/List<Lrhino/ast/AstNode;>;")]
    private static List NO_PARAMS;
    private Name functionName;
    [Signature("Ljava/util/List<Lrhino/ast/AstNode;>;")]
    private List @params;
    private AstNode body;
    private bool isExpressionClosure;
    private FunctionNode.Form functionForm;
    private int lp;
    private int rp;
    private int functionType;
    private bool needsActivation;
    private bool isGenerator;
    private bool isES6Generator;
    [Signature("Ljava/util/List<Lrhino/Node;>;")]
    private List generatorResumePoints;
    [Signature("Ljava/util/Map<Lrhino/Node;[I>;")]
    private Map liveLocals;
    private AstNode memberExprNode;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFunctionType() => this.functionType;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool requiresActivation() => this.needsActivation;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Name getFunctionName() => this.functionName;

    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName() => this.functionName != null ? this.functionName.getIdentifier() : "";

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isGenerator() => this.isGenerator;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isES6Generator() => this.isES6Generator;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRp(int rp) => this.rp = rp;

    [LineNumberTable(new byte[] {103, 103, 104, 139, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addParam(AstNode param)
    {
      this.assertNotNull((object) param);
      if (this.@params == null)
        this.@params = (List) new ArrayList();
      this.@params.add((object) param);
      param.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {41, 233, 39, 107, 103, 231, 76, 232, 76, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FunctionNode(int pos, Name name)
      : base(pos)
    {
      FunctionNode functionNode = this;
      this.functionForm = FunctionNode.Form.__\u003C\u003EFUNCTION;
      this.lp = -1;
      this.rp = -1;
      this.type = 110;
      this.setFunctionName(name);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFunctionType(int type) => this.functionType = type;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsES6Generator()
    {
      this.isES6Generator = true;
      this.isGenerator = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLp(int lp) => this.lp = lp;

    [LineNumberTable(new byte[] {160, 75, 103, 103, 116, 135, 110, 103, 110, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBody(AstNode body)
    {
      this.assertNotNull((object) body);
      this.body = body;
      if (((Boolean) Boolean.TRUE).equals(body.getProp(25)))
        this.setIsExpressionClosure(true);
      int end = body.getPosition() + body.getLength();
      body.setParent((AstNode) this);
      this.setLength(end - this.position);
      this.setEncodedSourceBounds(this.position, end);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getBody() => this.body;

    [LineNumberTable(new byte[] {160, 249, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMemberExprNode(AstNode node)
    {
      this.memberExprNode = node;
      node?.setParent((AstNode) this);
    }

    [LineNumberTable(new byte[] {37, 233, 43, 107, 103, 231, 76, 232, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FunctionNode(int pos)
      : base(pos)
    {
      FunctionNode functionNode = this;
      this.functionForm = FunctionNode.Form.__\u003C\u003EFUNCTION;
      this.lp = -1;
      this.rp = -1;
      this.type = 110;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParens(int lp, int rp)
    {
      this.lp = lp;
      this.rp = rp;
    }

    [LineNumberTable(new byte[] {160, 227, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFunctionIsGetterMethod() => this.functionForm = FunctionNode.Form.__\u003C\u003EGETTER;

    [LineNumberTable(new byte[] {160, 231, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFunctionIsSetterMethod() => this.functionForm = FunctionNode.Form.__\u003C\u003ESETTER;

    [LineNumberTable(new byte[] {160, 235, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFunctionIsNormalMethod() => this.functionForm = FunctionNode.Form.__\u003C\u003EMETHOD;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRequiresActivation() => this.needsActivation = true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsGenerator() => this.isGenerator = true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isExpressionClosure() => this.isExpressionClosure;

    [LineNumberTable(new byte[] {33, 232, 47, 107, 103, 231, 76, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FunctionNode()
    {
      FunctionNode functionNode = this;
      this.functionForm = FunctionNode.Form.__\u003C\u003EFUNCTION;
      this.lp = -1;
      this.rp = -1;
      this.type = 110;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstNode getMemberExprNode() => this.memberExprNode;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLp() => this.lp;

    [Signature("()Ljava/util/List<Lrhino/ast/AstNode;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getParams() => this.@params != null ? this.@params : FunctionNode.NO_PARAMS;

    [LineNumberTable(new byte[] {160, 171, 104, 107, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addResumptionPoint(Node target)
    {
      if (this.generatorResumePoints == null)
        this.generatorResumePoints = (List) new ArrayList();
      this.generatorResumePoints.add((object) target);
    }

    [LineNumberTable(new byte[] {58, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFunctionName(Name name)
    {
      this.functionName = name;
      name?.setParent((AstNode) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIsExpressionClosure(bool isExpressionClosure) => this.isExpressionClosure = isExpressionClosure;

    [LineNumberTable(325)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isMethod() => object.ReferenceEquals((object) this.functionForm, (object) FunctionNode.Form.__\u003C\u003EGETTER) || object.ReferenceEquals((object) this.functionForm, (object) FunctionNode.Form.__\u003C\u003ESETTER) || object.ReferenceEquals((object) this.functionForm, (object) FunctionNode.Form.__\u003C\u003EMETHOD);

    [Signature("(Ljava/util/List<Lrhino/ast/AstNode;>;)V")]
    [LineNumberTable(new byte[] {86, 99, 137, 104, 107, 123, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setParams(List @params)
    {
      if (@params == null)
      {
        this.@params = (List) null;
      }
      else
      {
        if (this.@params != null)
          this.@params.clear();
        Iterator iterator = @params.iterator();
        while (iterator.hasNext())
          this.addParam((AstNode) iterator.next());
      }
    }

    [LineNumberTable(167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isParam(AstNode node) => this.@params != null && this.@params.contains((object) node);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRp() => this.rp;

    [Signature("()Ljava/util/List<Lrhino/Node;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List getResumptionPoints() => this.generatorResumePoints;

    [Signature("()Ljava/util/Map<Lrhino/Node;[I>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Map getLiveLocals() => this.liveLocals;

    [LineNumberTable(new byte[] {160, 185, 104, 107, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLiveLocals(Node node, int[] locals)
    {
      if (this.liveLocals == null)
        this.liveLocals = (Map) new HashMap();
      this.liveLocals.put((object) node, (object) locals);
    }

    [LineNumberTable(new byte[] {160, 192, 104, 105, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int addFunction(FunctionNode fnNode)
    {
      int num = base.addFunction(fnNode);
      if (this.getFunctionCount() > 0)
        this.needsActivation = true;
      return num;
    }

    [LineNumberTable(329)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isGetterMethod() => object.ReferenceEquals((object) this.functionForm, (object) FunctionNode.Form.__\u003C\u003EGETTER);

    [LineNumberTable(333)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSetterMethod() => object.ReferenceEquals((object) this.functionForm, (object) FunctionNode.Form.__\u003C\u003ESETTER);

    [LineNumberTable(337)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNormalMethod() => object.ReferenceEquals((object) this.functionForm, (object) FunctionNode.Form.__\u003C\u003EMETHOD);

    [LineNumberTable(new byte[] {161, 4, 102, 106, 104, 110, 99, 172, 104, 108, 147, 104, 110, 140, 109, 142, 108, 109, 140, 99, 140, 107, 103, 141, 113, 110, 105, 206, 108, 142, 98, 152, 113, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toSource(int depth)
    {
      StringBuilder sb = new StringBuilder();
      int num = this.functionType == 4 ? 1 : 0;
      if (!this.isMethod())
      {
        sb.append(this.makeIndent(depth));
        if (num == 0)
          sb.append("function");
      }
      if (this.functionName != null)
      {
        sb.append(" ");
        sb.append(this.functionName.toSource(0));
      }
      if (this.@params == null)
        sb.append("() ");
      else if (num != 0 && this.lp == -1)
      {
        this.printList(this.@params, sb);
        sb.append(" ");
      }
      else
      {
        sb.append("(");
        this.printList(this.@params, sb);
        sb.append(") ");
      }
      if (num != 0)
        sb.append("=> ");
      if (this.isExpressionClosure)
      {
        AstNode body = this.getBody();
        if (body.getLastChild() is ReturnStatement)
        {
          AstNode returnValue = ((ReturnStatement) body.getLastChild()).getReturnValue();
          sb.append(returnValue.toSource(0));
          if (this.functionType == 1)
            sb.append(";");
        }
        else
        {
          sb.append(" ");
          sb.append(body.toSource(0));
        }
      }
      else
        sb.append(String.instancehelper_trim(this.getBody().toSource(depth)));
      if (this.functionType == 1 || this.isMethod())
        sb.append("\n");
      return sb.toString();
    }

    [LineNumberTable(new byte[] {161, 60, 108, 104, 140, 127, 1, 103, 98, 108, 104, 104, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void visit(NodeVisitor v)
    {
      if (!v.visit((AstNode) this))
        return;
      if (this.functionName != null)
        this.functionName.visit(v);
      Iterator iterator = this.getParams().iterator();
      while (iterator.hasNext())
        ((AstNode) iterator.next()).visit(v);
      this.getBody().visit(v);
      if (this.isExpressionClosure || this.memberExprNode == null)
        return;
      this.memberExprNode.visit(v);
    }

    [LineNumberTable(new byte[] {159, 128, 178, 101, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FunctionNode()
    {
      ScriptNode.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.ast.FunctionNode"))
        return;
      FunctionNode.NO_PARAMS = Collections.unmodifiableList((List) new ArrayList());
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lrhino/ast/FunctionNode$Form;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Form : Enum
    {
      [Modifiers]
      internal static FunctionNode.Form __\u003C\u003EFUNCTION;
      [Modifiers]
      internal static FunctionNode.Form __\u003C\u003EGETTER;
      [Modifiers]
      internal static FunctionNode.Form __\u003C\u003ESETTER;
      [Modifiers]
      internal static FunctionNode.Form __\u003C\u003EMETHOD;
      [Modifiers]
      private static FunctionNode.Form[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(57)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Form([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(57)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static FunctionNode.Form[] values() => (FunctionNode.Form[]) FunctionNode.Form.\u0024VALUES.Clone();

      [LineNumberTable(57)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static FunctionNode.Form valueOf(string name) => (FunctionNode.Form) Enum.valueOf((Class) ClassLiteral<FunctionNode.Form>.Value, name);

      [LineNumberTable(57)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Form()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.ast.FunctionNode$Form"))
          return;
        FunctionNode.Form.__\u003C\u003EFUNCTION = new FunctionNode.Form(nameof (FUNCTION), 0);
        FunctionNode.Form.__\u003C\u003EGETTER = new FunctionNode.Form(nameof (GETTER), 1);
        FunctionNode.Form.__\u003C\u003ESETTER = new FunctionNode.Form(nameof (SETTER), 2);
        FunctionNode.Form.__\u003C\u003EMETHOD = new FunctionNode.Form(nameof (METHOD), 3);
        FunctionNode.Form.\u0024VALUES = new FunctionNode.Form[4]
        {
          FunctionNode.Form.__\u003C\u003EFUNCTION,
          FunctionNode.Form.__\u003C\u003EGETTER,
          FunctionNode.Form.__\u003C\u003ESETTER,
          FunctionNode.Form.__\u003C\u003EMETHOD
        };
      }

      [Modifiers]
      public static FunctionNode.Form FUNCTION
      {
        [HideFromJava] get => FunctionNode.Form.__\u003C\u003EFUNCTION;
      }

      [Modifiers]
      public static FunctionNode.Form GETTER
      {
        [HideFromJava] get => FunctionNode.Form.__\u003C\u003EGETTER;
      }

      [Modifiers]
      public static FunctionNode.Form SETTER
      {
        [HideFromJava] get => FunctionNode.Form.__\u003C\u003ESETTER;
      }

      [Modifiers]
      public static FunctionNode.Form METHOD
      {
        [HideFromJava] get => FunctionNode.Form.__\u003C\u003EMETHOD;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        FUNCTION,
        GETTER,
        SETTER,
        METHOD,
      }
    }
  }
}
