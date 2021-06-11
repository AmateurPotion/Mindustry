// Decompiled with JetBrains decompiler
// Type: rhino.Parser
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using rhino.ast;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class Parser : Object
  {
    public const int ARGC_LIMIT = 65536;
    internal const int CLEAR_TI_MASK = 65535;
    internal const int TI_AFTER_EOL = 65536;
    internal const int TI_CHECK_LABEL = 131072;
    internal CompilerEnvirons compilerEnv;
    [Modifiers]
    private ErrorReporter errorReporter;
    private IdeErrorReporter errorCollector;
    private string sourceURI;
    private char[] sourceChars;
    internal bool calledByCompileFunction;
    private bool parseFinished;
    private TokenStream ts;
    private int currentFlaggedToken;
    private int currentToken;
    private int syntaxErrorCount;
    [Signature("Ljava/util/List<Lrhino/ast/Comment;>;")]
    private List scannedComments;
    private Comment currentJsDocComment;
    protected internal int nestingOfFunction;
    private LabeledStatement currentLabel;
    private bool inDestructuringAssignment;
    protected internal bool inUseStrictDirective;
    internal ScriptNode currentScriptOrFn;
    internal Scope currentScope;
    private int endFlags;
    private bool inForInit;
    [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/ast/LabeledStatement;>;")]
    private Map labelSet;
    [Signature("Ljava/util/List<Lrhino/ast/Loop;>;")]
    private List loopSet;
    [Signature("Ljava/util/List<Lrhino/ast/Jump;>;")]
    private List loopAndSwitchSet;
    private int prevNameTokenStart;
    private string prevNameTokenString;
    private int prevNameTokenLineno;
    private bool defaultUseStrictDirective;
    private const int PROP_ENTRY = 1;
    private const int GET_ENTRY = 2;
    private const int SET_ENTRY = 4;
    private const int METHOD_ENTRY = 8;

    [LineNumberTable(new byte[] {44, 232, 20, 231, 91, 235, 82, 103, 103, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Parser(CompilerEnvirons compilerEnv, ErrorReporter errorReporter)
    {
      Parser parser = this;
      this.currentFlaggedToken = 0;
      this.prevNameTokenString = "";
      this.compilerEnv = compilerEnv;
      this.errorReporter = errorReporter;
      if (!(errorReporter is IdeErrorReporter))
        return;
      this.errorCollector = (IdeErrorReporter) errorReporter;
    }

    [LineNumberTable(new byte[] {161, 108, 120, 103, 109, 140, 143, 237, 69, 103, 38, 231, 59, 100, 129, 139, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstRoot parse(string sourceString, string sourceURI, int lineno)
    {
      if (this.parseFinished)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("parser reused");
      }
      this.sourceURI = sourceURI;
      if (this.compilerEnv.isIdeMode())
        this.sourceChars = String.instancehelper_toCharArray(sourceString);
      this.ts = new TokenStream(this, (Reader) null, sourceString, lineno);
      AstRoot astRoot;
      // ISSUE: fault handler
      try
      {
        astRoot = this.parse();
        goto label_9;
      }
      catch (IOException ex)
      {
      }
      __fault
      {
        this.parseFinished = true;
      }
      // ISSUE: fault handler
      try
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      __fault
      {
        this.parseFinished = true;
      }
label_9:
      this.parseFinished = true;
      return astRoot;
    }

    [LineNumberTable(408)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool eof() => this.ts.eof();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDefaultUseStrictDirective(bool useStrict) => this.defaultUseStrictDirective = useStrict;

    [LineNumberTable(new byte[] {41, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Parser(CompilerEnvirons compilerEnv)
      : this(compilerEnv, compilerEnv.getErrorReporter())
    {
    }

    [LineNumberTable(new byte[] {64, 109, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addStrictWarning([In] string obj0, [In] string obj1, [In] int obj2, [In] int obj3)
    {
      if (!this.compilerEnv.isStrictMode())
        return;
      this.addWarning(obj0, obj1, obj2, obj3);
    }

    [LineNumberTable(new byte[] {83, 105, 109, 109, 104, 151, 126, 48, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addWarning([In] string obj0, [In] string obj1, [In] int obj2, [In] int obj3)
    {
      string str1 = this.lookupMessage(obj0, obj1);
      if (this.compilerEnv.reportWarningAsError())
        this.addError(obj0, obj1, obj2, obj3);
      else if (this.errorCollector != null)
        this.errorCollector.warning(str1, this.sourceURI, obj2, obj3);
      else
        this.errorReporter.warning(str1, this.sourceURI, this.ts.getLineno(), this.ts.getLine(), this.ts.getOffset());
    }

    [LineNumberTable(new byte[] {160, 104, 100, 105, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string lookupMessage([In] string obj0, [In] string obj1) => obj1 == null ? ScriptRuntime.getMessage0(obj0) : ScriptRuntime.getMessage1(obj0, (object) obj1);

    [LineNumberTable(new byte[] {114, 110, 105, 104, 151, 100, 102, 104, 108, 108, 140, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addError([In] string obj0, [In] string obj1, [In] int obj2, [In] int obj3)
    {
      ++this.syntaxErrorCount;
      string str1 = this.lookupMessage(obj0, obj1);
      if (this.errorCollector != null)
      {
        this.errorCollector.error(str1, this.sourceURI, obj2, obj3);
      }
      else
      {
        int i1 = 1;
        int i2 = 1;
        string str3 = "";
        if (this.ts != null)
        {
          i1 = this.ts.getLineno();
          str3 = this.ts.getLine();
          i2 = this.ts.getOffset();
        }
        this.errorReporter.error(str1, this.sourceURI, i1, str3, i2);
      }
    }

    [LineNumberTable(new byte[] {99, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addError([In] string obj0, [In] int obj1, [In] int obj2) => this.addError(obj0, (string) null, obj1, obj2);

    [LineNumberTable(new byte[] {160, 77, 105, 109, 115, 104, 151, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addWarning(
      [In] string obj0,
      [In] string obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] string obj5,
      [In] int obj6)
    {
      string str1 = this.lookupMessage(obj0, obj1);
      if (this.compilerEnv.reportWarningAsError())
        this.addError(obj0, obj1, obj2, obj3, obj4, obj5, obj6);
      else if (this.errorCollector != null)
        this.errorCollector.warning(str1, this.sourceURI, obj2, obj3);
      else
        this.errorReporter.warning(str1, this.sourceURI, obj4, obj5, obj6);
    }

    [LineNumberTable(new byte[] {160, 90, 110, 105, 104, 151, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addError(
      [In] string obj0,
      [In] string obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] string obj5,
      [In] int obj6)
    {
      ++this.syntaxErrorCount;
      string str1 = this.lookupMessage(obj0, obj1);
      if (this.errorCollector != null)
        this.errorCollector.error(str1, this.sourceURI, obj2, obj3);
      else
        this.errorReporter.error(str1, this.sourceURI, obj4, obj5, obj6);
    }

    [LineNumberTable(new byte[] {160, 114, 104, 140, 191, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void reportError([In] string obj0, [In] string obj1)
    {
      if (this.ts == null)
        this.reportError(obj0, obj1, 1, 1);
      else
        this.reportError(obj0, obj1, this.ts.tokenBeg, this.ts.tokenEnd - this.ts.tokenBeg);
    }

    [LineNumberTable(new byte[] {160, 128, 139, 109, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void reportError([In] string obj0, [In] string obj1, [In] int obj2, [In] int obj3)
    {
      this.addError(obj0, obj1, obj2, obj3);
      if (!this.compilerEnv.recoverFromErrors())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new Parser.ParserException((Parser.\u0031) null);
      }
    }

    [LineNumberTable(new byte[] {160, 143, 104, 139, 118, 183, 125, 103, 118, 183, 103, 140, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void recordComment([In] int obj0, [In] string obj1)
    {
      if (this.scannedComments == null)
        this.scannedComments = (List) new ArrayList();
      Comment.__\u003Cclinit\u003E();
      Comment comment = new Comment(this.ts.tokenBeg, this.ts.getTokenLength(), this.ts.commentType, obj1);
      if (object.ReferenceEquals((object) this.ts.commentType, (object) Token.CommentType.__\u003C\u003EJSDOC) && this.compilerEnv.isRecordingLocalJsDocComments())
      {
        Comment.__\u003Cclinit\u003E();
        this.currentJsDocComment = new Comment(this.ts.tokenBeg, this.ts.getTokenLength(), this.ts.commentType, obj1);
        this.currentJsDocComment.setLineno(obj0);
      }
      comment.setLineno(obj0);
      this.scannedComments.add((object) comment);
    }

    [LineNumberTable(new byte[] {160, 171, 98, 109, 107, 4, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getNumberOfEols([In] string obj0)
    {
      int num = 0;
      for (int index = String.instancehelper_length(obj0) - 1; index >= 0; index += -1)
      {
        if (String.instancehelper_charAt(obj0, index) == '\n')
          ++num;
      }
      return num;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 200, 104, 167, 108, 108, 162, 111, 100, 100, 98, 142, 109, 108, 168, 106, 130, 209, 103, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int peekToken()
    {
      if (this.currentFlaggedToken != 0)
        return this.currentToken;
      int lineno = this.ts.getLineno();
      int token = this.ts.getToken();
      int num1 = 0;
      while (token == 1 || token == 162)
      {
        if (token == 1)
        {
          ++lineno;
          num1 = 1;
          token = this.ts.getToken();
        }
        else
        {
          if (this.compilerEnv.isRecordingComments())
          {
            string resetCurrentComment = this.ts.getAndResetCurrentComment();
            this.recordComment(lineno, resetCurrentComment);
            int num2 = lineno + this.getNumberOfEols(resetCurrentComment);
            break;
          }
          token = this.ts.getToken();
        }
      }
      this.currentToken = token;
      this.currentFlaggedToken = token | (num1 == 0 ? 0 : 65536);
      return this.currentToken;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void consumeToken() => this.currentFlaggedToken = 0;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 42, 67, 106, 130, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool mustMatchToken([In] int obj0, [In] string obj1, [In] int obj2, [In] int obj3, [In] bool obj4)
    {
      int num = obj4 ? 1 : 0;
      if (this.matchToken(obj0, num != 0))
        return true;
      this.reportError(obj1, obj2, obj3);
      return false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 51, 98, 103, 107, 102, 137, 100, 130, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool matchToken([In] int obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      int num2;
      for (num2 = this.peekToken(); num2 == 162 && num1 != 0; num2 = this.peekToken())
        this.consumeToken();
      if (num2 != obj0)
        return false;
      this.consumeToken();
      return true;
    }

    [LineNumberTable(new byte[] {160, 123, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void reportError([In] string obj0, [In] int obj1, [In] int obj2) => this.reportError(obj0, (string) null, obj1, obj2);

    [Throws(new string[] {"java.lang.RuntimeException"})]
    [LineNumberTable(3914)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private RuntimeException codeBug() => throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug(new StringBuilder().append("ts.cursor=").append(this.ts.cursor).append(", ts.tokenBeg=").append(this.ts.tokenBeg).append(", currentToken=").append(this.currentToken).toString()));

    [LineNumberTable(new byte[] {161, 46, 167, 99, 110, 137, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void pushScope([In] Scope obj0)
    {
      Scope parentScope = obj0.getParentScope();
      if (parentScope != null)
      {
        if (!object.ReferenceEquals((object) parentScope, (object) this.currentScope))
          this.codeBug();
      }
      else
        this.currentScope.addChildScope(obj0);
      this.currentScope = obj0;
    }

    [LineNumberTable(new byte[] {161, 59, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void popScope() => this.currentScope = this.currentScope.getParentScope();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 147, 98, 103, 146, 108, 131, 99, 136, 108, 104, 231, 69, 104, 101, 194, 102, 134, 252, 69, 244, 90, 104, 246, 35, 97, 133, 105, 127, 0, 136, 104, 100, 106, 100, 101, 110, 103, 247, 78, 104, 230, 53, 106, 104, 104, 240, 71, 104, 41, 104, 230, 57, 97, 109, 109, 191, 3, 104, 35, 98, 130, 104, 109, 111, 109, 252, 69, 168, 111, 127, 2, 127, 5, 104, 162, 106, 108, 103, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstRoot parse()
    {
      int pos = 0;
      AstRoot astRoot1 = new AstRoot(pos);
      Parser parser = this;
      AstRoot astRoot2 = astRoot1;
      AstRoot astRoot3 = astRoot2;
      this.currentScriptOrFn = (ScriptNode) astRoot2;
      this.currentScope = (Scope) astRoot3;
      int lineno = this.ts.lineno;
      int num1 = pos;
      int num2 = 1;
      int num3 = this.inUseStrictDirective ? 1 : 0;
      this.inUseStrictDirective = this.defaultUseStrictDirective;
      if (this.inUseStrictDirective)
        astRoot1.setInStrictMode(true);
      while (true)
      {
        int num4;
        AstNode astNode;
        // ISSUE: fault handler
        try
        {
          num4 = this.peekToken();
          if (num4 > 0)
          {
            if (num4 == 110)
            {
              this.consumeToken();
              try
              {
                astNode = (AstNode) this.function(!this.calledByCompileFunction ? 1 : 2);
                goto label_23;
              }
              catch (Parser.ParserException ex)
              {
                break;
              }
            }
          }
          else
            goto label_28;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<StackOverflowError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
          else
            goto label_11;
        }
        __fault
        {
          this.inUseStrictDirective = num3 != 0;
        }
        // ISSUE: fault handler
        try
        {
          if (num4 == 162)
          {
            astNode = (AstNode) this.scannedComments.get(this.scannedComments.size() - 1);
            this.consumeToken();
          }
          else
          {
            astNode = this.statement();
            if (num2 != 0)
            {
              string directive = this.getDirective(astNode);
              if (directive == null)
                num2 = 0;
              else if (String.instancehelper_equals(directive, (object) "use strict"))
              {
                this.inUseStrictDirective = true;
                astRoot1.setInStrictMode(true);
              }
            }
          }
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<StackOverflowError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
          else
            goto label_22;
        }
        __fault
        {
          this.inUseStrictDirective = num3 != 0;
        }
label_23:
        // ISSUE: fault handler
        try
        {
          num1 = this.getNodeEnd(astNode);
          astRoot1.addChildToBack((Node) astNode);
          astNode.setParent((AstNode) astRoot1);
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<StackOverflowError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
          else
            goto label_27;
        }
        __fault
        {
          this.inUseStrictDirective = num3 != 0;
        }
      }
      goto label_28;
label_11:
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_29;
label_22:
      local = null;
      goto label_29;
label_27:
      local = null;
      goto label_29;
label_28:
      this.inUseStrictDirective = num3 != 0;
      goto label_33;
label_29:
      try
      {
        string message = this.lookupMessage("msg.too.deep.parser.recursion");
        if (!this.compilerEnv.isIdeMode())
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError(message, this.sourceURI, this.ts.lineno, (string) null, 0));
      }
      finally
      {
        this.inUseStrictDirective = num3 != 0;
      }
label_33:
      if (this.syntaxErrorCount != 0)
      {
        string str1 = this.lookupMessage("msg.got.syntax.errors", String.valueOf(this.syntaxErrorCount));
        if (!this.compilerEnv.isIdeMode())
          throw Throwable.__\u003Cunmap\u003E((Exception) this.errorReporter.runtimeError(str1, this.sourceURI, lineno, (string) null, 0));
      }
      if (this.scannedComments != null)
      {
        int num4 = this.scannedComments.size() - 1;
        num1 = Math.max(num1, this.getNodeEnd((AstNode) this.scannedComments.get(num4)));
        Iterator iterator = this.scannedComments.iterator();
        while (iterator.hasNext())
        {
          Comment comment = (Comment) iterator.next();
          astRoot1.addComment(comment);
        }
      }
      astRoot1.setLength(num1 - pos);
      astRoot1.setSourceName(this.sourceURI);
      astRoot1.setBaseLineno(lineno);
      astRoot1.setEndLineno(this.ts.lineno);
      return astRoot1;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(765)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private FunctionNode function([In] int obj0) => this.function(obj0, false);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {163, 138, 140, 103, 102, 117, 103, 110, 189, 231, 61, 229, 69, 103, 127, 19, 127, 4, 134, 212, 2, 225, 71, 104, 102, 255, 3, 69, 130, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode statement()
    {
      int tokenBeg = this.ts.tokenBeg;
      AstNode astNode1;
      try
      {
        AstNode astNode2 = this.statementHelper();
        if (astNode2 != null)
        {
          if (this.compilerEnv.isStrictMode() && !astNode2.hasSideEffects())
          {
            int position = astNode2.getPosition();
            int num = Math.max(position, this.lineBeginningFor(position));
            this.addStrictWarning(!(astNode2 is EmptyStatement) ? "msg.no.side.effects" : "msg.extra.trailing.semi", "", num, this.nodeEnd(astNode2) - num);
          }
          if (this.peekToken() == 162 && astNode2.getLineno() == ((AstNode) this.scannedComments.get(this.scannedComments.size() - 1)).getLineno())
          {
            astNode2.setInlineComment((AstNode) this.scannedComments.get(this.scannedComments.size() - 1));
            this.consumeToken();
          }
          astNode1 = astNode2;
        }
        else
          goto label_10;
      }
      catch (Parser.ParserException ex)
      {
        goto label_9;
      }
      return astNode1;
label_9:
label_10:
      int num1;
      do
      {
        int num2 = this.peekTokenOrEOL();
        this.consumeToken();
        num1 = num2;
      }
      while (num1 != -1 && num1 != 0 && (num1 != 1 && num1 != 83));
      EmptyStatement.__\u003Cclinit\u003E();
      return (AstNode) new EmptyStatement(tokenBeg, this.ts.tokenBeg - tokenBeg);
    }

    [LineNumberTable(new byte[] {162, 61, 104, 108, 104, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string getDirective([In] AstNode obj0)
    {
      if (obj0 is ExpressionStatement)
      {
        AstNode expression = ((ExpressionStatement) obj0).getExpression();
        if (expression is StringLiteral)
          return ((StringLiteral) expression).getValue();
      }
      return (string) null;
    }

    [LineNumberTable(253)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int getNodeEnd([In] AstNode obj0) => obj0.getPosition() + obj0.getLength();

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string lookupMessage([In] string obj0) => this.lookupMessage(obj0, (string) null);

    [LineNumberTable(new byte[] {160, 110, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void reportError([In] string obj0) => this.reportError(obj0, (string) null);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 26, 103, 101, 137, 103, 98, 103, 100, 98, 135, 112, 200, 171, 166, 135, 103, 141, 149, 99, 140, 167, 104, 142, 107, 102, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode assignExpr()
    {
      int num1 = this.peekToken();
      if (num1 == 73)
        return this.returnOrYield(num1, true);
      AstNode left = this.condExpr();
      int num2 = 0;
      int @operator = this.peekTokenOrEOL();
      if (@operator == 1)
      {
        num2 = 1;
        @operator = this.peekToken();
      }
      if (91 <= @operator && @operator <= 102)
      {
        if (this.inDestructuringAssignment)
          this.reportError("msg.destruct.default.vals");
        this.consumeToken();
        Comment andResetJsDoc = this.getAndResetJsDoc();
        this.markDestructuring(left);
        int tokenBeg = this.ts.tokenBeg;
        Assignment.__\u003Cclinit\u003E();
        left = (AstNode) new Assignment(@operator, left, this.assignExpr(), tokenBeg);
        if (andResetJsDoc != null)
          left.setJsDocNode(andResetJsDoc);
      }
      else if (@operator == 83)
      {
        if (this.currentJsDocComment != null)
          left.setJsDocNode(this.getAndResetJsDoc());
      }
      else if (num2 == 0 && @operator == 165)
      {
        this.consumeToken();
        left = this.arrowFunction(left);
      }
      return left;
    }

    [LineNumberTable(new byte[] {173, 19, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setRequiresActivation()
    {
      if (!this.insideFunction())
        return;
      ((FunctionNode) this.currentScriptOrFn).setRequiresActivation();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private Comment getAndResetJsDoc()
    {
      Comment currentJsDocComment = this.currentJsDocComment;
      this.currentJsDocComment = (Comment) null;
      return currentJsDocComment;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(394)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool mustMatchToken([In] int obj0, [In] string obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      return this.mustMatchToken(obj0, obj1, this.ts.tokenBeg, this.ts.tokenEnd - this.ts.tokenBeg, num != 0);
    }

    [Throws(new string[] {"java.io.IOException", "rhino.Parser$ParserException"})]
    [LineNumberTable(new byte[] {170, 81, 103, 139, 103, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode destructuringPrimaryExpr()
    {
      try
      {
        this.inDestructuringAssignment = true;
        return this.primaryExpr();
      }
      finally
      {
        this.inDestructuringAssignment = false;
      }
    }

    [LineNumberTable(new byte[] {174, 206, 104, 110, 104, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void markDestructuring([In] AstNode obj0)
    {
      switch (obj0)
      {
        case DestructuringForm _:
          ((DestructuringForm) obj0).setIsDestructuring(true);
          break;
        case ParenthesizedExpression _:
          this.markDestructuring(((ParenthesizedExpression) obj0).getExpression());
          break;
      }
    }

    [LineNumberTable(new byte[] {157, 127, 98, 99, 109, 129, 135, 109, 101, 137, 109, 223, 13, 255, 35, 69, 129, 191, 28, 105, 150, 107, 129, 114, 193, 99, 101, 110, 101, 174, 146, 161, 163, 140, 114, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void defineSymbol([In] int obj0, [In] string obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      if (obj1 == null)
      {
        if (this.compilerEnv.isIdeMode())
          return;
        this.codeBug();
      }
      Scope definingScope = this.currentScope.getDefiningScope(obj1);
      rhino.ast.Symbol symbol = definingScope == null ? (rhino.ast.Symbol) null : definingScope.getSymbol(obj1);
      int num2 = symbol == null ? -1 : symbol.getDeclType();
      if (symbol != null && (num2 == 155 || obj0 == 155 || object.ReferenceEquals((object) definingScope, (object) this.currentScope) && num2 == 154))
      {
        string str1;
        switch (num2)
        {
          case 110:
            str1 = "msg.fn.redecl";
            break;
          case 123:
            str1 = "msg.var.redecl";
            break;
          case 154:
            str1 = "msg.let.redecl";
            break;
          case 155:
            str1 = "msg.const.redecl";
            break;
          default:
            str1 = "msg.parm.redecl";
            break;
        }
        string str2 = obj1;
        this.addError(str1, str2);
      }
      else
      {
        switch (obj0)
        {
          case 88:
            if (symbol != null)
              this.addWarning("msg.dup.parms", obj1);
            this.currentScriptOrFn.putSymbol(new rhino.ast.Symbol(obj0, obj1));
            break;
          case 110:
          case 123:
            if (symbol != null)
            {
              if (num2 == 123)
              {
                this.addStrictWarning("msg.var.redecl", obj1);
                break;
              }
              if (num2 != 88)
                break;
              this.addStrictWarning("msg.var.hides.arg", obj1);
              break;
            }
            this.currentScriptOrFn.putSymbol(new rhino.ast.Symbol(obj0, obj1));
            break;
          case 154:
          case 155:
            if (num1 == 0 && (this.currentScope.getType() == 113 || this.currentScope is Loop))
            {
              this.addError("msg.let.decl.not.in.block");
              break;
            }
            this.currentScope.putSymbol(new rhino.ast.Symbol(obj0, obj1));
            break;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) this.codeBug());
        }
      }
    }

    [LineNumberTable(3390)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Name createNameNode() => this.createNameNode(false, 39);

    [LineNumberTable(new byte[] {167, 199, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void defineSymbol([In] int obj0, [In] string obj1) => this.defineSymbol(obj0, obj1, false);

    [LineNumberTable(new byte[] {103, 159, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addError([In] string obj0, [In] string obj1) => this.addError(obj0, obj1, this.ts.tokenBeg, this.ts.tokenEnd - this.ts.tokenBeg);

    [LineNumberTable(new byte[] {173, 52, 127, 14, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ErrorNode makeErrorNode()
    {
      ErrorNode.__\u003Cclinit\u003E();
      ErrorNode errorNode = new ErrorNode(this.ts.tokenBeg, this.ts.tokenEnd - this.ts.tokenBeg);
      errorNode.setLineno(this.ts.lineno);
      return errorNode;
    }

    [LineNumberTable(new byte[] {174, 84, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Node createName(string name)
    {
      this.checkActivationName(name, 39);
      return Node.newString(39, name);
    }

    [LineNumberTable(new byte[] {173, 190, 108, 139, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Node createDestructuringAssignment([In] int obj0, [In] Node obj1, [In] Node obj2)
    {
      string nextTempName = this.currentScriptOrFn.getNextTempName();
      Node node = this.destructuringAssignmentHelper(obj0, obj1, obj2, nextTempName);
      node.getLastChild().addChildToBack(this.createName(nextTempName));
      return node;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {158, 206, 130, 98, 108, 108, 99, 131, 110, 107, 104, 105, 124, 173, 110, 109, 100, 99, 139, 145, 141, 113, 140, 137, 205, 137, 143, 154, 100, 162, 106, 136, 175, 106, 104, 99, 135, 101, 139, 141, 138, 104, 112, 115, 148, 111, 108, 188, 190, 103, 35, 98, 130, 132, 102, 233, 76, 109, 104, 242, 70, 109, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private FunctionNode function([In] int obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      int num2 = obj0;
      int lineno = this.ts.lineno;
      int tokenBeg = this.ts.tokenBeg;
      Name name1 = (Name) null;
      AstNode node = (AstNode) null;
      if (this.matchToken(39, true))
      {
        name1 = this.createNameNode(true, 39);
        if (this.inUseStrictDirective)
        {
          string identifier = name1.getIdentifier();
          if (String.instancehelper_equals("eval", (object) identifier) || String.instancehelper_equals("arguments", (object) identifier))
            this.reportError("msg.bad.id.strict", identifier);
        }
        if (!this.matchToken(88, true))
        {
          if (this.compilerEnv.isAllowMemberExprAsFunctionName())
          {
            Name name2 = name1;
            name1 = (Name) null;
            node = this.memberExprTail(false, (AstNode) name2);
          }
          this.mustMatchToken(88, "msg.no.paren.parms", true);
        }
      }
      else if (!this.matchToken(88, true))
      {
        if (this.matchToken(23, true) && this.compilerEnv.getLanguageVersion() >= 200)
          return this.function(obj0, true);
        if (this.compilerEnv.isAllowMemberExprAsFunctionName())
          node = this.memberExpr(false);
        this.mustMatchToken(88, "msg.no.paren.parms", true);
      }
      int num3 = this.currentToken != 88 ? -1 : this.ts.tokenBeg;
      if (node != null)
        num2 = 2;
      if (num2 != 2 && name1 != null && name1.length() > 0)
        this.defineSymbol(110, name1.getIdentifier());
      FunctionNode functionNode = new FunctionNode(tokenBeg, name1);
      functionNode.setFunctionType(obj0);
      if (num1 != 0)
        functionNode.setIsES6Generator();
      if (num3 != -1)
        functionNode.setLp(num3 - tokenBeg);
      functionNode.setJsDocNode(this.getAndResetJsDoc());
      Parser.PerFunctionVariables functionVariables = new Parser.PerFunctionVariables(this, functionNode);
      try
      {
        this.parseFunctionParams(functionNode);
        functionNode.setBody(this.parseFunctionBody(obj0, functionNode));
        functionNode.setEncodedSourceBounds(tokenBeg, this.ts.tokenEnd);
        functionNode.setLength(this.ts.tokenEnd - tokenBeg);
        if (this.compilerEnv.isStrictMode())
        {
          if (!functionNode.getBody().hasConsistentReturnUsage())
            this.addStrictWarning(name1 == null || name1.length() <= 0 ? "msg.anon.no.return.value" : "msg.no.return.value", name1 != null ? name1.getIdentifier() : "");
        }
      }
      finally
      {
        functionVariables.restore();
      }
      if (node != null)
      {
        Kit.codeBug();
        functionNode.setMemberExprNode(node);
      }
      functionNode.setSourceName(this.sourceURI);
      functionNode.setBaseLineno(lineno);
      functionNode.setEndLineno(this.ts.lineno);
      if (this.compilerEnv.isIdeMode())
        functionNode.setParentScope(this.currentScope);
      return functionNode;
    }

    [LineNumberTable(new byte[] {156, 60, 98, 108, 108, 108, 114, 103, 103, 103, 103, 107, 135, 99, 109, 136, 167, 105, 104, 99, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Name createNameNode([In] bool obj0, [In] int obj1)
    {
      int num = obj0 ? 1 : 0;
      int pos = this.ts.tokenBeg;
      string name1 = this.ts.getString();
      int lineno = this.ts.lineno;
      if (!String.instancehelper_equals("", (object) this.prevNameTokenString))
      {
        pos = this.prevNameTokenStart;
        name1 = this.prevNameTokenString;
        lineno = this.prevNameTokenLineno;
        this.prevNameTokenStart = 0;
        this.prevNameTokenString = "";
        this.prevNameTokenLineno = 0;
      }
      if (name1 == null)
      {
        if (this.compilerEnv.isIdeMode())
          name1 = "";
        else
          this.codeBug();
      }
      Name name2 = new Name(pos, name1);
      name2.setLineno(lineno);
      if (num != 0)
        this.checkActivationName(name1, obj1);
      return name2;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {157, 8, 130, 106, 199, 103, 159, 17, 108, 106, 103, 165, 102, 112, 108, 104, 106, 112, 109, 141, 108, 104, 105, 107, 104, 100, 165, 99, 133, 108, 102, 103, 104, 168, 104, 116, 104, 114, 107, 105, 116, 116, 100, 162, 104, 104, 126, 130, 130, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode memberExprTail([In] bool obj0, [In] AstNode obj1)
    {
      int num1 = obj0 ? 1 : 0;
      if (obj1 == null)
        this.codeBug();
      int position = obj1.getPosition();
      while (true)
      {
        int num2 = this.peekToken();
        switch (num2)
        {
          case 84:
            this.consumeToken();
            int tokenBeg = this.ts.tokenBeg;
            int rb = -1;
            int lineno1 = this.ts.lineno;
            AstNode element = this.expr();
            int num3 = this.getNodeEnd(element);
            if (this.mustMatchToken(85, "msg.no.bracket.index", true))
            {
              rb = this.ts.tokenBeg;
              num3 = this.ts.tokenEnd;
            }
            ElementGet elementGet = new ElementGet(position, num3 - position);
            elementGet.setTarget(obj1);
            elementGet.setElement(element);
            elementGet.setParens(tokenBeg, rb);
            elementGet.setLineno(lineno1);
            obj1 = (AstNode) elementGet;
            continue;
          case 88:
            if (num1 != 0)
            {
              int lineno2 = this.ts.lineno;
              this.consumeToken();
              this.checkCallRequiresActivation(obj1);
              FunctionCall functionCall = new FunctionCall(position);
              functionCall.setTarget(obj1);
              functionCall.setLineno(lineno2);
              functionCall.setLp(this.ts.tokenBeg - position);
              List arguments = this.argumentList();
              if (arguments != null && arguments.size() > 65536)
                this.reportError("msg.too.many.function.args");
              functionCall.setArguments(arguments);
              functionCall.setRp(this.ts.tokenBeg - position);
              functionCall.setLength(this.ts.tokenEnd - position);
              obj1 = (AstNode) functionCall;
              continue;
            }
            goto label_13;
          case 109:
            int lineno3 = this.ts.lineno;
            obj1 = this.propertyAccess(num2, obj1);
            obj1.setLineno(lineno3);
            continue;
          case 162:
            int currentFlaggedToken = this.currentFlaggedToken;
            this.peekUntilNonComment(num2);
            this.currentFlaggedToken = (this.currentFlaggedToken & 65536) == 0 ? currentFlaggedToken : this.currentFlaggedToken;
            continue;
          default:
            goto label_13;
        }
      }
label_13:
      return obj1;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {157, 21, 66, 179, 101, 140, 102, 109, 137, 105, 106, 169, 110, 109, 104, 114, 107, 109, 109, 100, 105, 241, 71, 107, 104, 106, 137, 108, 131, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode memberExpr([In] bool obj0)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = this.peekToken();
      int lineno = this.ts.lineno;
      AstNode astNode;
      if (num2 != 30)
      {
        astNode = this.primaryExpr();
      }
      else
      {
        this.consumeToken();
        int tokenBeg1 = this.ts.tokenBeg;
        NewExpression newExpression = new NewExpression(tokenBeg1);
        AstNode target = this.memberExpr(false);
        int num3 = this.getNodeEnd(target);
        newExpression.setTarget(target);
        if (this.matchToken(88, true))
        {
          int tokenBeg2 = this.ts.tokenBeg;
          List arguments = this.argumentList();
          if (arguments != null && arguments.size() > 65536)
            this.reportError("msg.too.many.constructor.args");
          int tokenBeg3 = this.ts.tokenBeg;
          num3 = this.ts.tokenEnd;
          if (arguments != null)
            newExpression.setArguments(arguments);
          newExpression.setParens(tokenBeg2 - tokenBeg1, tokenBeg3 - tokenBeg1);
        }
        if (this.matchToken(86, true))
        {
          ObjectLiteral initializer = this.objectLiteral();
          num3 = this.getNodeEnd((AstNode) initializer);
          newExpression.setInitializer(initializer);
        }
        newExpression.setLength(num3 - tokenBeg1);
        astNode = (AstNode) newExpression;
      }
      astNode.setLineno(lineno);
      return this.memberExprTail(num1 != 0, astNode);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {162, 72, 107, 120, 193, 98, 134, 103, 106, 103, 103, 199, 99, 134, 109, 107, 106, 101, 115, 104, 104, 100, 137, 104, 109, 106, 104, 117, 103, 141, 106, 109, 137, 98, 172, 142, 102, 137, 127, 5, 101, 60, 135, 137, 98, 170, 112, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void parseFunctionParams([In] FunctionNode obj0)
    {
      if (this.matchToken(89, true))
      {
        obj0.setRp(this.ts.tokenBeg - obj0.getPosition());
      }
      else
      {
        HashMap hashMap = (HashMap) null;
        HashSet hashSet = new HashSet();
        do
        {
          switch (this.peekToken())
          {
            case 84:
            case 86:
              AstNode astNode = this.destructuringPrimaryExpr();
              this.markDestructuring(astNode);
              obj0.addParam(astNode);
              if (hashMap == null)
                hashMap = new HashMap();
              string nextTempName = this.currentScriptOrFn.getNextTempName();
              this.defineSymbol(88, nextTempName, false);
              ((Map) hashMap).put((object) nextTempName, (object) astNode);
              break;
            default:
              if (this.mustMatchToken(39, "msg.no.parm", true))
              {
                Name nameNode = this.createNameNode();
                Comment andResetJsDoc = this.getAndResetJsDoc();
                if (andResetJsDoc != null)
                  nameNode.setJsDocNode(andResetJsDoc);
                obj0.addParam((AstNode) nameNode);
                string str = this.ts.getString();
                this.defineSymbol(88, str);
                if (this.inUseStrictDirective)
                {
                  if (String.instancehelper_equals("eval", (object) str) || String.instancehelper_equals("arguments", (object) str))
                    this.reportError("msg.bad.id.strict", str);
                  if (((Set) hashSet).contains((object) str))
                    this.addError("msg.dup.param.strict", str);
                  ((Set) hashSet).add((object) str);
                  break;
                }
                break;
              }
              obj0.addParam((AstNode) this.makeErrorNode());
              break;
          }
        }
        while (this.matchToken(90, true));
        if (hashMap != null)
        {
          Node node = new Node(90);
          Iterator iterator = ((Map) hashMap).entrySet().iterator();
          while (iterator.hasNext())
          {
            Map.Entry entry = (Map.Entry) iterator.next();
            Node destructuringAssignment = this.createDestructuringAssignment(123, (Node) entry.getValue(), this.createName((string) entry.getKey()));
            node.addChildToBack(destructuringAssignment);
          }
          obj0.putProp(23, (object) node);
        }
        if (!this.mustMatchToken(89, "msg.no.paren.after.parms", true))
          return;
        obj0.setRp(this.ts.tokenBeg - obj0.getPosition());
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 235, 98, 107, 118, 141, 162, 101, 110, 108, 135, 99, 168, 145, 99, 104, 156, 110, 109, 99, 142, 104, 197, 104, 223, 15, 133, 102, 127, 0, 130, 102, 105, 130, 104, 100, 106, 100, 101, 110, 103, 103, 100, 230, 70, 104, 233, 69, 110, 104, 6, 110, 104, 226, 59, 161, 110, 104, 130, 109, 103, 115, 109, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode parseFunctionBody([In] int obj0, [In] FunctionNode obj1)
    {
      int num1 = 0;
      if (!this.matchToken(86, true))
      {
        if (this.compilerEnv.getLanguageVersion() < 180 && obj0 != 4)
          this.reportError("msg.no.brace.body");
        else
          num1 = 1;
      }
      int num2 = obj0 == 4 ? 1 : 0;
      ++this.nestingOfFunction;
      int tokenBeg = this.ts.tokenBeg;
      Block block = new Block(tokenBeg);
      int num3 = 1;
      int num4 = this.inUseStrictDirective ? 1 : 0;
      block.setLineno(this.ts.lineno);
      // ISSUE: fault handler
      try
      {
        if (num1 != 0)
        {
          AstNode returnValue = this.assignExpr();
          ReturnStatement.__\u003Cclinit\u003E();
          ReturnStatement returnStatement = new ReturnStatement(returnValue.getPosition(), returnValue.getLength(), returnValue);
          returnStatement.putProp(25, (object) Boolean.TRUE);
          block.putProp(25, (object) Boolean.TRUE);
          if (num2 != 0)
            returnStatement.putProp(27, (object) Boolean.TRUE);
          block.addStatement((AstNode) returnStatement);
          goto label_22;
        }
        else
        {
          while (true)
          {
            AstNode statement;
            switch (this.peekToken())
            {
              case -1:
              case 0:
              case 87:
                goto label_22;
              case 110:
                this.consumeToken();
                statement = (AstNode) this.function(1);
                break;
              case 162:
                this.consumeToken();
                statement = (AstNode) this.scannedComments.get(this.scannedComments.size() - 1);
                break;
              default:
                statement = this.statement();
                if (num3 != 0)
                {
                  string directive = this.getDirective(statement);
                  if (directive == null)
                  {
                    num3 = 0;
                    break;
                  }
                  if (String.instancehelper_equals(directive, (object) "use strict"))
                  {
                    this.inUseStrictDirective = true;
                    obj1.setInStrictMode(true);
                    if (num4 == 0)
                    {
                      this.setRequiresActivation();
                      break;
                    }
                    break;
                  }
                  break;
                }
                break;
            }
            block.addStatement(statement);
          }
        }
      }
      catch (Parser.ParserException ex)
      {
      }
      __fault
      {
        --this.nestingOfFunction;
        this.inUseStrictDirective = num4 != 0;
      }
      --this.nestingOfFunction;
      this.inUseStrictDirective = num4 != 0;
      goto label_23;
label_22:
      --this.nestingOfFunction;
      this.inUseStrictDirective = num4 != 0;
label_23:
      int tokenEnd = this.ts.tokenEnd;
      this.getAndResetJsDoc();
      if (num1 == 0 && this.mustMatchToken(87, "msg.no.brace.after.body", true))
        tokenEnd = this.ts.tokenEnd;
      block.setLength(tokenEnd - tokenBeg);
      return (AstNode) block;
    }

    [LineNumberTable(new byte[] {54, 100, 104, 108, 152, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addStrictWarning([In] string obj0, [In] string obj1)
    {
      int num1 = -1;
      int num2 = -1;
      if (this.ts != null)
      {
        num1 = this.ts.tokenBeg;
        num2 = this.ts.tokenEnd - this.ts.tokenBeg;
      }
      this.addStrictWarning(obj0, obj1, num1, num2);
    }

    [Signature("(Lrhino/ast/FunctionNode;Lrhino/ast/AstNode;Ljava/util/Map<Ljava/lang/String;Lrhino/Node;>;Ljava/util/Set<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {163, 51, 112, 103, 103, 108, 106, 105, 119, 117, 122, 107, 103, 108, 137, 104, 115, 103, 140, 106, 108, 137, 98, 119, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void arrowFunctionParams([In] FunctionNode obj0, [In] AstNode obj1, [In] Map obj2, [In] Set obj3)
    {
      switch (obj1)
      {
        case ArrayLiteral _:
        case ObjectLiteral _:
          this.markDestructuring(obj1);
          obj0.addParam(obj1);
          string nextTempName = this.currentScriptOrFn.getNextTempName();
          this.defineSymbol(88, nextTempName, false);
          obj2.put((object) nextTempName, (object) obj1);
          break;
        case InfixExpression _ when obj1.getType() == 90:
          this.arrowFunctionParams(obj0, ((InfixExpression) obj1).getLeft(), obj2, obj3);
          this.arrowFunctionParams(obj0, ((InfixExpression) obj1).getRight(), obj2, obj3);
          break;
        case Name _:
          obj0.addParam(obj1);
          string identifier = ((Name) obj1).getIdentifier();
          this.defineSymbol(88, identifier);
          if (!this.inUseStrictDirective)
            break;
          if (String.instancehelper_equals("eval", (object) identifier) || String.instancehelper_equals("arguments", (object) identifier))
            this.reportError("msg.bad.id.strict", identifier);
          if (obj3.contains((object) identifier))
            this.addError("msg.dup.param.strict", identifier);
          obj3.add((object) identifier);
          break;
        default:
          this.reportError("msg.no.parm", obj1.getPosition(), obj1.getLength());
          obj0.addParam((AstNode) this.makeErrorNode());
          break;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {163, 89, 112, 110, 108, 109, 177, 112, 142, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode statements([In] AstNode obj0)
    {
      if (this.currentToken != 86 && !this.compilerEnv.isIdeMode())
        this.codeBug();
      int tokenBeg = this.ts.tokenBeg;
      AstNode astNode = obj0 == null ? (AstNode) new Block(tokenBeg) : obj0;
      astNode.setLineno(this.ts.lineno);
      int num;
      while ((num = this.peekToken()) > 0 && num != 87)
        astNode.addChild(this.statement());
      astNode.setLength(this.ts.tokenBeg - tokenBeg);
      return astNode;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 10, 103, 103, 110, 108, 117, 110, 39, 133, 106, 107, 117, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode expr()
    {
      AstNode left = this.assignExpr();
      int position = left.getPosition();
      while (this.matchToken(90, true))
      {
        int tokenBeg = this.ts.tokenBeg;
        if (this.compilerEnv.isStrictMode() && !left.hasSideEffects())
          this.addStrictWarning("msg.no.side.effects", "", position, this.nodeEnd(left) - position);
        if (this.peekToken() == 73)
          this.reportError("msg.yield.parenthesized");
        InfixExpression.__\u003Cclinit\u003E();
        left = (AstNode) new InfixExpression(90, left, this.assignExpr(), tokenBeg);
      }
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {163, 182, 117, 167, 135, 159, 160, 164, 167, 167, 167, 167, 167, 167, 103, 165, 103, 165, 103, 165, 104, 139, 199, 102, 108, 121, 108, 165, 103, 114, 101, 194, 105, 165, 102, 159, 15, 118, 165, 167, 102, 167, 102, 108, 122, 114, 163, 102, 168, 103, 104, 98, 162, 126, 130, 108, 125, 204, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode statementHelper()
    {
      if (this.currentLabel != null && this.currentLabel.getStatement() != null)
        this.currentLabel = (LabeledStatement) null;
      int nodeType = this.peekToken();
      AstNode astNode;
      switch (nodeType)
      {
        case -1:
          this.consumeToken();
          return (AstNode) this.makeErrorNode();
        case 4:
        case 73:
          astNode = this.returnOrYield(nodeType, false);
          break;
        case 39:
          astNode = this.nameOrLabel();
          if (!(astNode is ExpressionStatement))
            return astNode;
          break;
        case 50:
          astNode = (AstNode) this.throwStatement();
          break;
        case 82:
          return (AstNode) this.tryStatement();
        case 83:
          this.consumeToken();
          int tokenBeg = this.ts.tokenBeg;
          EmptyStatement.__\u003Cclinit\u003E();
          EmptyStatement emptyStatement = new EmptyStatement(tokenBeg, this.ts.tokenEnd - tokenBeg);
          emptyStatement.setLineno(this.ts.lineno);
          return (AstNode) emptyStatement;
        case 86:
          return this.block();
        case 110:
          this.consumeToken();
          return (AstNode) this.function(3);
        case 113:
          return (AstNode) this.ifStatement();
        case 115:
          return (AstNode) this.switchStatement();
        case 118:
          return (AstNode) this.whileLoop();
        case 119:
          return (AstNode) this.doLoop();
        case 120:
          return (AstNode) this.forLoop();
        case 121:
          astNode = (AstNode) this.breakStatement();
          break;
        case 122:
          astNode = (AstNode) this.continueStatement();
          break;
        case 123:
        case 155:
          this.consumeToken();
          int lineno1 = this.ts.lineno;
          astNode = (AstNode) this.variables(this.currentToken, this.ts.tokenBeg, true);
          astNode.setLineno(lineno1);
          break;
        case 124:
          if (this.inUseStrictDirective)
            this.reportError("msg.no.with.strict");
          return (AstNode) this.withStatement();
        case 154:
          astNode = this.letStatement();
          if (!(astNode is VariableDeclaration) || this.peekToken() != 83)
            return astNode;
          break;
        case 161:
          this.consumeToken();
          KeywordLiteral.__\u003Cclinit\u003E();
          astNode = (AstNode) new KeywordLiteral(this.ts.tokenBeg, this.ts.tokenEnd - this.ts.tokenBeg, nodeType);
          astNode.setLineno(this.ts.lineno);
          break;
        case 162:
          return (AstNode) this.scannedComments.get(this.scannedComments.size() - 1);
        default:
          int lineno2 = this.ts.lineno;
          ExpressionStatement.__\u003Cclinit\u003E();
          astNode = (AstNode) new ExpressionStatement(this.expr(), !this.insideFunction());
          astNode.setLineno(lineno2);
          break;
      }
      this.autoInsertSemicolon(astNode);
      return astNode;
    }

    [LineNumberTable(new byte[] {173, 80, 104, 130, 100, 130, 103, 101, 134, 105, 100, 104, 132, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lineBeginningFor([In] int obj0)
    {
      if (this.sourceChars == null)
        return -1;
      if (obj0 <= 0)
        return 0;
      char[] sourceChars = this.sourceChars;
      if (obj0 >= sourceChars.Length)
        obj0 = sourceChars.Length - 1;
      do
      {
        obj0 += -1;
        if (obj0 < 0)
          goto label_9;
      }
      while (!ScriptRuntime.isJSLineTerminator((int) sourceChars[obj0]));
      return obj0 + 1;
label_9:
      return 0;
    }

    [LineNumberTable(3501)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int nodeEnd([In] AstNode obj0) => obj0.getPosition() + obj0.getLength();

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {161, 14, 135, 110, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int peekTokenOrEOL()
    {
      int num = this.peekToken();
      if ((this.currentFlaggedToken & 65536) != 0)
        num = 1;
      return num;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 64, 113, 102, 122, 103, 104, 108, 107, 104, 105, 127, 4, 134, 110, 136, 114, 106, 109, 120, 104, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private IfStatement ifStatement()
    {
      if (this.currentToken != 113)
        this.codeBug();
      this.consumeToken();
      int tokenBeg = this.ts.tokenBeg;
      int lineno = this.ts.lineno;
      int elsePosition = -1;
      IfStatement ifStatement = new IfStatement(tokenBeg);
      Parser.ConditionData conditionData = this.condition();
      AstNode afterInlineComments = this.getNextStatementAfterInlineComments((AstNode) ifStatement);
      AstNode elsePart = (AstNode) null;
      if (this.matchToken(114, true))
      {
        if (this.peekToken() == 162)
        {
          ifStatement.setElseKeyWordInlineComment((AstNode) this.scannedComments.get(this.scannedComments.size() - 1));
          this.consumeToken();
        }
        elsePosition = this.ts.tokenBeg - tokenBeg;
        elsePart = this.statement();
      }
      int nodeEnd = this.getNodeEnd(elsePart == null ? afterInlineComments : elsePart);
      ifStatement.setLength(nodeEnd - tokenBeg);
      ifStatement.setCondition(conditionData.condition);
      ifStatement.setParens(conditionData.lp - tokenBeg, conditionData.rp - tokenBeg);
      ifStatement.setThenPart(afterInlineComments);
      ifStatement.setElsePart(elsePart);
      ifStatement.setElsePosition(elsePosition);
      ifStatement.setLineno(lineno);
      return ifStatement;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 92, 113, 102, 140, 103, 112, 115, 145, 103, 103, 167, 112, 147, 143, 194, 104, 109, 109, 99, 159, 12, 115, 165, 104, 111, 162, 99, 139, 98, 111, 130, 127, 0, 104, 133, 107, 165, 105, 105, 116, 137, 223, 10, 105, 127, 0, 121, 139, 137, 102, 133, 104, 105, 101, 104, 135, 102, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private SwitchStatement switchStatement()
    {
      if (this.currentToken != 115)
        this.codeBug();
      this.consumeToken();
      int tokenBeg1 = this.ts.tokenBeg;
      SwitchStatement switchStatement = new SwitchStatement(tokenBeg1);
      if (this.mustMatchToken(88, "msg.no.paren.switch", true))
        switchStatement.setLp(this.ts.tokenBeg - tokenBeg1);
      switchStatement.setLineno(this.ts.lineno);
      AstNode expression1 = this.expr();
      switchStatement.setExpression(expression1);
      this.enterSwitch(switchStatement);
      try
      {
        if (this.mustMatchToken(89, "msg.no.paren.after.switch", true))
          switchStatement.setRp(this.ts.tokenBeg - tokenBeg1);
        this.mustMatchToken(86, "msg.no.brace.switch", true);
        int num1 = 0;
        while (true)
        {
          int num2 = this.nextToken();
          int tokenBeg2 = this.ts.tokenBeg;
          int lineno = this.ts.lineno;
          AstNode expression2 = (AstNode) null;
          switch (num2)
          {
            case 87:
              goto label_9;
            case 116:
              expression2 = this.expr();
              this.mustMatchToken(104, "msg.no.colon.case", true);
              break;
            case 117:
              if (num1 != 0)
                this.reportError("msg.double.switch.default");
              num1 = 1;
              this.mustMatchToken(104, "msg.no.colon.case", true);
              break;
            case 162:
              AstNode kid = (AstNode) this.scannedComments.get(this.scannedComments.size() - 1);
              switchStatement.addChild(kid);
              continue;
            default:
              goto label_13;
          }
          SwitchCase switchCase = new SwitchCase(tokenBeg2);
          switchCase.setExpression(expression2);
          switchCase.setLength(this.ts.tokenEnd - tokenBeg1);
          switchCase.setLineno(lineno);
          int num3;
          while ((num3 = this.peekToken()) != 87)
          {
            switch (num3)
            {
              case 0:
              case 116:
              case 117:
                goto label_24;
              case 162:
                Comment comment = (Comment) this.scannedComments.get(this.scannedComments.size() - 1);
                if (switchCase.getInlineComment() == null && comment.getLineno() == switchCase.getLineno())
                  switchCase.setInlineComment((AstNode) comment);
                else
                  switchCase.addStatement((AstNode) comment);
                this.consumeToken();
                continue;
              default:
                AstNode statement = this.statement();
                switchCase.addStatement(statement);
                continue;
            }
          }
label_24:
          switchStatement.addCase(switchCase);
        }
label_9:
        switchStatement.setLength(this.ts.tokenEnd - tokenBeg1);
        goto label_26;
label_13:
        this.reportError("msg.bad.switch");
      }
      finally
      {
        this.exitSwitch();
      }
label_26:
      return switchStatement;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 177, 113, 102, 108, 103, 113, 135, 103, 108, 118, 104, 111, 139, 102, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private WhileLoop whileLoop()
    {
      if (this.currentToken != 118)
        this.codeBug();
      this.consumeToken();
      int tokenBeg = this.ts.tokenBeg;
      WhileLoop whileLoop = new WhileLoop(tokenBeg);
      whileLoop.setLineno(this.ts.lineno);
      this.enterLoop((Loop) whileLoop);
      try
      {
        Parser.ConditionData conditionData = this.condition();
        whileLoop.setCondition(conditionData.condition);
        whileLoop.setParens(conditionData.lp - tokenBeg, conditionData.rp - tokenBeg);
        AstNode afterInlineComments = this.getNextStatementAfterInlineComments((AstNode) whileLoop);
        whileLoop.setLength(this.getNodeEnd(afterInlineComments) - tokenBeg);
        whileLoop.setBody(afterInlineComments);
      }
      finally
      {
        this.exitLoop();
      }
      return whileLoop;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 198, 113, 102, 108, 103, 113, 135, 104, 111, 115, 103, 108, 118, 105, 139, 102, 35, 98, 194, 107, 141, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private DoLoop doLoop()
    {
      if (this.currentToken != 119)
        this.codeBug();
      this.consumeToken();
      int tokenBeg = this.ts.tokenBeg;
      DoLoop doLoop = new DoLoop(tokenBeg);
      doLoop.setLineno(this.ts.lineno);
      this.enterLoop((Loop) doLoop);
      int num;
      try
      {
        AstNode afterInlineComments = this.getNextStatementAfterInlineComments((AstNode) doLoop);
        this.mustMatchToken(118, "msg.no.while.do", true);
        doLoop.setWhilePosition(this.ts.tokenBeg - tokenBeg);
        Parser.ConditionData conditionData = this.condition();
        doLoop.setCondition(conditionData.condition);
        doLoop.setParens(conditionData.lp - tokenBeg, conditionData.rp - tokenBeg);
        num = this.getNodeEnd(afterInlineComments);
        doLoop.setBody(afterInlineComments);
      }
      finally
      {
        this.exitLoop();
      }
      if (this.matchToken(83, true))
        num = this.ts.tokenEnd;
      doLoop.setLength(num - tokenBeg);
      return doLoop;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 250, 113, 102, 120, 103, 172, 163, 103, 168, 107, 119, 98, 145, 203, 112, 111, 136, 106, 107, 98, 111, 109, 118, 126, 99, 111, 141, 111, 138, 120, 153, 168, 111, 109, 106, 106, 153, 200, 112, 143, 106, 104, 137, 116, 171, 103, 139, 105, 105, 105, 104, 105, 105, 100, 98, 104, 105, 105, 105, 196, 109, 230, 69, 136, 106, 113, 153, 102, 164, 111, 134, 235, 57, 104, 168, 111, 134, 225, 61, 111, 168, 107, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Loop forLoop()
    {
      if (this.currentToken != 120)
        this.codeBug();
      this.consumeToken();
      int tokenBeg = this.ts.tokenBeg;
      int lineno = this.ts.lineno;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int eachPosition = -1;
      int inPosition = -1;
      int lp = -1;
      int rp = -1;
      AstNode increment = (AstNode) null;
      Scope scope = new Scope();
      this.pushScope(scope);
      Loop loop;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        if (this.matchToken(39, true))
        {
          if (String.instancehelper_equals("each", (object) this.ts.getString()))
          {
            num1 = 1;
            eachPosition = this.ts.tokenBeg - tokenBeg;
          }
          else
            this.reportError("msg.no.paren.for");
        }
        if (this.mustMatchToken(88, "msg.no.paren.for", true))
          lp = this.ts.tokenBeg - tokenBeg;
        AstNode astNode1 = this.forLoopInit(this.peekToken());
        AstNode astNode2;
        if (this.matchToken(52, true))
        {
          num2 = 1;
          inPosition = this.ts.tokenBeg - tokenBeg;
          astNode2 = this.expr();
        }
        else if (this.compilerEnv.getLanguageVersion() >= 200 && this.matchToken(39, true) && String.instancehelper_equals("of", (object) this.ts.getString()))
        {
          num3 = 1;
          inPosition = this.ts.tokenBeg - tokenBeg;
          astNode2 = this.expr();
        }
        else
        {
          this.mustMatchToken(83, "msg.no.semi.for", true);
          if (this.peekToken() == 83)
          {
            EmptyExpression.__\u003Cclinit\u003E();
            astNode2 = (AstNode) new EmptyExpression(this.ts.tokenBeg, 1);
            astNode2.setLineno(this.ts.lineno);
          }
          else
            astNode2 = this.expr();
          this.mustMatchToken(83, "msg.no.semi.for.cond", true);
          int tokenEnd = this.ts.tokenEnd;
          if (this.peekToken() == 89)
          {
            increment = (AstNode) new EmptyExpression(tokenEnd, 1);
            increment.setLineno(this.ts.lineno);
          }
          else
            increment = this.expr();
        }
        if (this.mustMatchToken(89, "msg.no.paren.for.ctrl", true))
          rp = this.ts.tokenBeg - tokenBeg;
        if (num2 != 0 || num3 != 0)
        {
          ForInLoop forInLoop = new ForInLoop(tokenBeg);
          if (astNode1 is VariableDeclaration && ((VariableDeclaration) astNode1).getVariables().size() > 1)
            this.reportError("msg.mult.index");
          if (num3 != 0 && num1 != 0)
            this.reportError("msg.invalid.for.each");
          forInLoop.setIterator(astNode1);
          forInLoop.setIteratedObject(astNode2);
          forInLoop.setInPosition(inPosition);
          forInLoop.setIsForEach(num1 != 0);
          forInLoop.setEachPosition(eachPosition);
          forInLoop.setIsForOf(num3 != 0);
          loop = (Loop) forInLoop;
        }
        else
        {
          ForLoop forLoop = new ForLoop(tokenBeg);
          forLoop.setInitializer(astNode1);
          forLoop.setCondition(astNode2);
          forLoop.setIncrement(increment);
          loop = (Loop) forLoop;
        }
        this.currentScope.replaceWith((Scope) loop);
        this.popScope();
        this.enterLoop(loop);
        try
        {
          AstNode afterInlineComments = this.getNextStatementAfterInlineComments((AstNode) loop);
          loop.setLength(this.getNodeEnd(afterInlineComments) - tokenBeg);
          loop.setBody(afterInlineComments);
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_35;
        }
        this.exitLoop();
        goto label_40;
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.currentScope, (object) scope))
          this.popScope();
      }
label_35:
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        this.exitLoop();
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      __fault
      {
        if (object.ReferenceEquals((object) this.currentScope, (object) scope))
          this.popScope();
      }
label_40:
      if (object.ReferenceEquals((object) this.currentScope, (object) scope))
        this.popScope();
      loop.setParens(lp, rp);
      loop.setLineno(lineno);
      return loop;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {165, 128, 113, 166, 135, 154, 136, 104, 105, 127, 0, 105, 102, 136, 102, 139, 106, 138, 131, 99, 104, 105, 110, 109, 100, 139, 118, 112, 141, 143, 104, 104, 100, 137, 105, 104, 117, 103, 205, 99, 107, 109, 138, 163, 112, 109, 143, 109, 106, 105, 105, 105, 105, 101, 140, 107, 137, 112, 109, 108, 100, 103, 106, 101, 102, 175, 99, 107, 108, 104, 170, 107, 105, 105, 105, 100, 138, 136, 99, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private TryStatement tryStatement()
    {
      if (this.currentToken != 82)
        this.codeBug();
      this.consumeToken();
      Comment andResetJsDoc1 = this.getAndResetJsDoc();
      int tokenBeg1 = this.ts.tokenBeg;
      int lineno1 = this.ts.lineno;
      int num1 = -1;
      TryStatement tryStatement = new TryStatement(tokenBeg1);
      int num2 = this.peekToken();
      if (num2 == 162)
      {
        Comment comment = (Comment) this.scannedComments.get(this.scannedComments.size() - 1);
        tryStatement.setInlineComment((AstNode) comment);
        this.consumeToken();
        num2 = this.peekToken();
      }
      if (num2 != 86)
        this.reportError("msg.no.brace.try");
      AstNode afterInlineComments = this.getNextStatementAfterInlineComments((AstNode) tryStatement);
      int num3 = this.getNodeEnd(afterInlineComments);
      ArrayList arrayList = (ArrayList) null;
      int num4 = 0;
      switch (this.peekToken())
      {
        case 125:
          while (this.matchToken(125, true))
          {
            int lineno2 = this.ts.lineno;
            if (num4 != 0)
              this.reportError("msg.catch.unreachable");
            int tokenBeg2 = this.ts.tokenBeg;
            int lp = -1;
            int rp = -1;
            int num5 = -1;
            if (this.mustMatchToken(88, "msg.no.paren.catch", true))
              lp = this.ts.tokenBeg;
            this.mustMatchToken(39, "msg.bad.catchcond", true);
            Name nameNode = this.createNameNode();
            Comment andResetJsDoc2 = this.getAndResetJsDoc();
            if (andResetJsDoc2 != null)
              nameNode.setJsDocNode(andResetJsDoc2);
            string identifier = nameNode.getIdentifier();
            if (this.inUseStrictDirective && (String.instancehelper_equals("eval", (object) identifier) || String.instancehelper_equals("arguments", (object) identifier)))
              this.reportError("msg.bad.id.strict", identifier);
            AstNode catchCondition = (AstNode) null;
            if (this.matchToken(113, true))
            {
              num5 = this.ts.tokenBeg;
              catchCondition = this.expr();
            }
            else
              num4 = 1;
            if (this.mustMatchToken(89, "msg.bad.catchcond", true))
              rp = this.ts.tokenBeg;
            this.mustMatchToken(86, "msg.no.brace.catchblock", true);
            Block body = (Block) this.statements();
            num3 = this.getNodeEnd((AstNode) body);
            CatchClause catchClause = new CatchClause(tokenBeg2);
            catchClause.setVarName(nameNode);
            catchClause.setCatchCondition(catchCondition);
            catchClause.setBody(body);
            if (num5 != -1)
              catchClause.setIfPosition(num5 - tokenBeg2);
            catchClause.setParens(lp, rp);
            catchClause.setLineno(lineno2);
            if (this.mustMatchToken(87, "msg.no.brace.after.body", true))
              num3 = this.ts.tokenEnd;
            catchClause.setLength(num3 - tokenBeg2);
            if (arrayList == null)
              arrayList = new ArrayList();
            ((List) arrayList).add((object) catchClause);
          }
          goto case 126;
        case 126:
          AstNode finallyBlock = (AstNode) null;
          if (this.matchToken(126, true))
          {
            num1 = this.ts.tokenBeg;
            finallyBlock = this.statement();
            num3 = this.getNodeEnd(finallyBlock);
          }
          tryStatement.setLength(num3 - tokenBeg1);
          tryStatement.setTryBlock(afterInlineComments);
          tryStatement.setCatchClauses((List) arrayList);
          tryStatement.setFinallyBlock(finallyBlock);
          if (num1 != -1)
            tryStatement.setFinallyPosition(num1 - tokenBeg1);
          tryStatement.setLineno(lineno1);
          if (andResetJsDoc1 != null)
            tryStatement.setJsDocNode(andResetJsDoc1);
          return tryStatement;
        default:
          this.mustMatchToken(126, "msg.try.no.catchfinally", true);
          goto case 126;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {165, 240, 113, 102, 120, 169, 139, 103, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ThrowStatement throwStatement()
    {
      if (this.currentToken != 50)
        this.codeBug();
      this.consumeToken();
      int tokenBeg = this.ts.tokenBeg;
      int lineno = this.ts.lineno;
      if (this.peekTokenOrEOL() == 1)
        this.reportError("msg.bad.throw.eol");
      AstNode expr = this.expr();
      ThrowStatement throwStatement = new ThrowStatement(tokenBeg, expr);
      throwStatement.setLineno(lineno);
      return throwStatement;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 23, 113, 102, 127, 5, 98, 106, 103, 200, 136, 144, 108, 117, 145, 223, 0, 107, 136, 100, 105, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private BreakStatement breakStatement()
    {
      if (this.currentToken != 121)
        this.codeBug();
      this.consumeToken();
      int lineno = this.ts.lineno;
      int tokenBeg = this.ts.tokenBeg;
      int num = this.ts.tokenEnd;
      Name label = (Name) null;
      if (this.peekTokenOrEOL() == 39)
      {
        label = this.createNameNode();
        num = this.getNodeEnd((AstNode) label);
      }
      Jump firstLabel = (Jump) this.matchJumpLabelName()?.getFirstLabel();
      if ((Label) firstLabel == null && label == null)
      {
        if (this.loopAndSwitchSet == null || this.loopAndSwitchSet.size() == 0)
          this.reportError("msg.bad.break", tokenBeg, num - tokenBeg);
        else
          firstLabel = (Jump) this.loopAndSwitchSet.get(this.loopAndSwitchSet.size() - 1);
      }
      BreakStatement breakStatement = new BreakStatement(tokenBeg, num - tokenBeg);
      breakStatement.setBreakLabel(label);
      if (firstLabel != null)
        breakStatement.setBreakTarget(firstLabel);
      breakStatement.setLineno(lineno);
      return breakStatement;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 56, 113, 102, 127, 5, 98, 106, 103, 200, 104, 99, 103, 117, 141, 191, 2, 114, 143, 181, 107, 100, 105, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ContinueStatement continueStatement()
    {
      if (this.currentToken != 122)
        this.codeBug();
      this.consumeToken();
      int lineno = this.ts.lineno;
      int tokenBeg = this.ts.tokenBeg;
      int num = this.ts.tokenEnd;
      Name label = (Name) null;
      if (this.peekTokenOrEOL() == 39)
      {
        label = this.createNameNode();
        num = this.getNodeEnd((AstNode) label);
      }
      LabeledStatement labeledStatement = this.matchJumpLabelName();
      Loop target = (Loop) null;
      if (labeledStatement == null && label == null)
      {
        if (this.loopSet == null || this.loopSet.size() == 0)
          this.reportError("msg.continue.outside");
        else
          target = (Loop) this.loopSet.get(this.loopSet.size() - 1);
      }
      else
      {
        if (labeledStatement == null || !(labeledStatement.getStatement() is Loop))
          this.reportError("msg.continue.nonloop", tokenBeg, num - tokenBeg);
        target = labeledStatement != null ? (Loop) labeledStatement.getStatement() : (Loop) null;
      }
      ContinueStatement continueStatement = new ContinueStatement(tokenBeg, num - tokenBeg);
      if (target != null)
        continueStatement.setTarget(target);
      continueStatement.setLabel(label);
      continueStatement.setLineno(lineno);
      return continueStatement;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 91, 113, 134, 135, 125, 112, 140, 136, 112, 141, 104, 106, 113, 104, 105, 105, 106, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private WithStatement withStatement()
    {
      if (this.currentToken != 124)
        this.codeBug();
      this.consumeToken();
      Comment andResetJsDoc = this.getAndResetJsDoc();
      int lineno = this.ts.lineno;
      int tokenBeg = this.ts.tokenBeg;
      int lp = -1;
      int rp = -1;
      if (this.mustMatchToken(88, "msg.no.paren.with", true))
        lp = this.ts.tokenBeg;
      AstNode expression = this.expr();
      if (this.mustMatchToken(89, "msg.no.paren.after.with", true))
        rp = this.ts.tokenBeg;
      WithStatement withStatement = new WithStatement(tokenBeg);
      AstNode afterInlineComments = this.getNextStatementAfterInlineComments((AstNode) withStatement);
      withStatement.setLength(this.getNodeEnd(afterInlineComments) - tokenBeg);
      withStatement.setJsDocNode(andResetJsDoc);
      withStatement.setExpression(expression);
      withStatement.setStatement(afterInlineComments);
      withStatement.setParens(lp, rp);
      withStatement.setLineno(lineno);
      return withStatement;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {157, 156, 66, 103, 104, 113, 103, 99, 231, 70, 98, 99, 117, 141, 140, 103, 105, 104, 114, 172, 111, 104, 114, 104, 109, 127, 6, 173, 184, 141, 136, 99, 107, 104, 170, 110, 99, 108, 139, 138, 137, 105, 105, 105, 105, 136, 109, 101, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private VariableDeclaration variables([In] int obj0, [In] int obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      VariableDeclaration variableDeclaration = new VariableDeclaration(obj1);
      variableDeclaration.setType(obj0);
      variableDeclaration.setLineno(this.ts.lineno);
      Comment andResetJsDoc1 = this.getAndResetJsDoc();
      if (andResetJsDoc1 != null)
        variableDeclaration.setJsDocNode(andResetJsDoc1);
      int num2;
      do
      {
        AstNode target = (AstNode) null;
        Name name = (Name) null;
        int num3 = this.peekToken();
        int tokenBeg = this.ts.tokenBeg;
        num2 = this.ts.tokenEnd;
        if (num3 == 84 || num3 == 86)
        {
          target = this.destructuringPrimaryExpr();
          num2 = this.getNodeEnd(target);
          if (!(target is DestructuringForm))
            this.reportError("msg.bad.assign.left", tokenBeg, num2 - tokenBeg);
          this.markDestructuring(target);
        }
        else
        {
          this.mustMatchToken(39, "msg.bad.var", true);
          name = this.createNameNode();
          name.setLineno(this.ts.getLineno());
          if (this.inUseStrictDirective)
          {
            string str = this.ts.getString();
            if (String.instancehelper_equals("eval", (object) str) || String.instancehelper_equals("arguments", (object) this.ts.getString()))
              this.reportError("msg.bad.id.strict", str);
          }
          this.defineSymbol(obj0, this.ts.getString(), this.inForInit);
        }
        int lineno = this.ts.lineno;
        Comment andResetJsDoc2 = this.getAndResetJsDoc();
        AstNode initializer = (AstNode) null;
        if (this.matchToken(91, true))
        {
          initializer = this.assignExpr();
          num2 = this.getNodeEnd(initializer);
        }
        VariableInitializer v = new VariableInitializer(tokenBeg, num2 - tokenBeg);
        if (target != null)
        {
          if (initializer == null && !this.inForInit)
            this.reportError("msg.destruct.assign.no.init");
          v.setTarget(target);
        }
        else
          v.setTarget((AstNode) name);
        v.setInitializer(initializer);
        v.setType(obj0);
        v.setJsDocNode(andResetJsDoc2);
        v.setLineno(lineno);
        variableDeclaration.addVariable(v);
      }
      while (this.matchToken(90, true));
      variableDeclaration.setLength(num2 - obj1);
      variableDeclaration.setIsStatement(num1 != 0);
      return variableDeclaration;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 117, 116, 102, 152, 106, 139, 142, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode letStatement()
    {
      if (this.currentToken != 154)
        this.codeBug();
      this.consumeToken();
      int lineno = this.ts.lineno;
      int tokenBeg = this.ts.tokenBeg;
      AstNode astNode = this.peekToken() != 88 ? (AstNode) this.variables(154, tokenBeg, true) : this.let(true, tokenBeg);
      astNode.setLineno(lineno);
      return astNode;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {157, 206, 130, 104, 182, 102, 159, 5, 99, 107, 109, 105, 99, 166, 131, 255, 39, 72, 130, 146, 194, 104, 169, 168, 100, 117, 173, 147, 150, 104, 107, 110, 111, 102, 102, 99, 238, 69, 117, 135, 109, 105, 114, 109, 146, 242, 69, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode returnOrYield([In] int obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      if (!this.insideFunction())
        this.reportError(obj0 != 4 ? "msg.bad.yield" : "msg.bad.return");
      this.consumeToken();
      int lineno = this.ts.lineno;
      int tokenBeg = this.ts.tokenBeg;
      int num2 = this.ts.tokenEnd;
      int num3 = 0;
      if (obj0 == 73 && this.compilerEnv.getLanguageVersion() >= 200 && this.peekToken() == 23)
      {
        num3 = 1;
        this.consumeToken();
      }
      AstNode returnValue = (AstNode) null;
      switch (this.peekTokenOrEOL())
      {
        case -1:
        case 0:
        case 1:
        case 83:
        case 85:
        case 87:
        case 89:
          int endFlags = this.endFlags;
          AstNode expr;
          if (obj0 == 4)
          {
            this.endFlags |= returnValue != null ? 4 : 2;
            expr = (AstNode) new ReturnStatement(tokenBeg, num2 - tokenBeg, returnValue);
            if (Parser.nowAllSet(endFlags, this.endFlags, 6))
              this.addStrictWarning("msg.return.inconsistent", "", tokenBeg, num2 - tokenBeg);
          }
          else
          {
            if (!this.insideFunction())
              this.reportError("msg.bad.yield");
            this.endFlags |= 8;
            expr = (AstNode) new Yield(tokenBeg, num2 - tokenBeg, returnValue, num3 != 0);
            this.setRequiresActivation();
            this.setIsGenerator();
            if (num1 == 0)
              expr = (AstNode) new ExpressionStatement(expr);
          }
          if (this.insideFunction() && Parser.nowAllSet(endFlags, this.endFlags, 12) && !((FunctionNode) this.currentScriptOrFn).isES6Generator())
          {
            Name functionName = ((FunctionNode) this.currentScriptOrFn).getFunctionName();
            if (functionName == null || functionName.length() == 0)
              this.addError("msg.anon.generator.returns", "");
            else
              this.addError("msg.generator.returns", functionName.getIdentifier());
          }
          expr.setLineno(lineno);
          return expr;
        case 73:
          if (this.compilerEnv.getLanguageVersion() >= 200)
            goto default;
          else
            goto case -1;
        default:
          returnValue = this.expr();
          num2 = this.getNodeEnd(returnValue);
          goto case -1;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 225, 113, 102, 108, 103, 113, 135, 104, 111, 115, 134, 102, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode block()
    {
      if (this.currentToken != 86)
        this.codeBug();
      this.consumeToken();
      int tokenBeg = this.ts.tokenBeg;
      Scope scope = new Scope(tokenBeg);
      scope.setLineno(this.ts.lineno);
      this.pushScope(scope);
      try
      {
        this.statements((AstNode) scope);
        this.mustMatchToken(87, "msg.no.brace.block", true);
        scope.setLength(this.ts.tokenEnd - tokenBeg);
        return (AstNode) scope;
      }
      finally
      {
        this.popScope();
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {167, 17, 118, 172, 114, 135, 109, 120, 108, 162, 103, 109, 145, 99, 109, 114, 103, 109, 121, 109, 130, 242, 69, 103, 108, 104, 104, 127, 21, 127, 5, 202, 135, 127, 5, 115, 98, 227, 59, 135, 127, 5, 115, 98, 194, 109, 108, 5, 165, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode nameOrLabel()
    {
      if (this.currentToken != 39)
        throw Throwable.__\u003Cunmap\u003E((Exception) this.codeBug());
      int tokenBeg = this.ts.tokenBeg;
      this.currentFlaggedToken |= 131072;
      AstNode expr1 = this.expr();
      if (expr1.getType() != 131)
      {
        ExpressionStatement.__\u003Cclinit\u003E();
        ExpressionStatement expressionStatement = new ExpressionStatement(expr1, !this.insideFunction());
        expressionStatement.lineno = expr1.lineno;
        return (AstNode) expressionStatement;
      }
      LabeledStatement labeledStatement = new LabeledStatement(tokenBeg);
      this.recordLabel((Label) expr1, labeledStatement);
      labeledStatement.setLineno(this.ts.lineno);
      AstNode statement = (AstNode) null;
      while (this.peekToken() == 39)
      {
        this.currentFlaggedToken |= 131072;
        AstNode expr2 = this.expr();
        if (expr2.getType() != 131)
        {
          ExpressionStatement.__\u003Cclinit\u003E();
          statement = (AstNode) new ExpressionStatement(expr2, !this.insideFunction());
          this.autoInsertSemicolon(statement);
          break;
        }
        this.recordLabel((Label) expr2, labeledStatement);
      }
      // ISSUE: fault handler
      try
      {
        this.currentLabel = labeledStatement;
        if ((ExpressionStatement) statement == null)
        {
          statement = this.statementHelper();
          if (this.peekToken() == 162)
          {
            if (statement.getLineno() == ((AstNode) this.scannedComments.get(this.scannedComments.size() - 1)).getLineno())
            {
              statement.setInlineComment((AstNode) this.scannedComments.get(this.scannedComments.size() - 1));
              this.consumeToken();
            }
          }
        }
      }
      __fault
      {
        this.currentLabel = (LabeledStatement) null;
        Iterator iterator = labeledStatement.getLabels().iterator();
        while (iterator.hasNext())
          this.labelSet.remove((object) ((Label) iterator.next()).getName());
      }
      this.currentLabel = (LabeledStatement) null;
      Iterator iterator1 = labeledStatement.getLabels().iterator();
      while (iterator1.hasNext())
        this.labelSet.remove((object) ((Label) iterator1.next()).getName());
      labeledStatement.setLength(statement.getParent() != null ? this.getNodeEnd(statement) : this.getNodeEnd(statement) - tokenBeg);
      labeledStatement.setStatement(statement);
      return (AstNode) labeledStatement;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool insideFunction() => this.nestingOfFunction != 0;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 34, 103, 103, 191, 9, 134, 115, 226, 71, 118, 130, 137, 141, 206})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void autoInsertSemicolon([In] AstNode obj0)
    {
      int num = this.peekFlaggedToken();
      int position = obj0.getPosition();
      switch (num & (int) ushort.MaxValue)
      {
        case -1:
        case 0:
        case 87:
          this.warnMissingSemi(position, Math.max(position + 1, this.nodeEnd(obj0)));
          break;
        case 83:
          this.consumeToken();
          obj0.setLength(this.ts.tokenEnd - position);
          break;
        default:
          if ((num & 65536) == 0)
          {
            this.reportError("msg.no.semi.stmt");
            break;
          }
          this.warnMissingSemi(position, this.nodeEnd(obj0));
          break;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 234, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int peekFlaggedToken()
    {
      this.peekToken();
      return this.currentFlaggedToken;
    }

    [LineNumberTable(new byte[] {173, 103, 112, 103, 206, 115, 137, 99, 221, 180})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void warnMissingSemi([In] int obj0, [In] int obj1)
    {
      if (!this.compilerEnv.isStrictMode())
        return;
      int[] numArray = new int[2];
      string line = this.ts.getLine(obj1, numArray);
      int num = !this.compilerEnv.isIdeMode() ? obj0 : Math.max(obj0, obj1 - numArray[1]);
      if (line != null)
        this.addStrictWarning("msg.missing.semi", "", num, obj1 - num, numArray[0], line, numArray[1]);
      else
        this.addStrictWarning("msg.missing.semi", "", num, obj1 - num);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {163, 116, 135, 112, 145, 140, 112, 209, 109, 113, 107, 5, 197})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Parser.ConditionData condition()
    {
      Parser.ConditionData conditionData = new Parser.ConditionData((Parser.\u0031) null);
      if (this.mustMatchToken(88, "msg.no.paren.cond", true))
        conditionData.lp = this.ts.tokenBeg;
      conditionData.condition = this.expr();
      if (this.mustMatchToken(89, "msg.no.paren.after.cond", true))
        conditionData.rp = this.ts.tokenBeg;
      if (conditionData.condition is Assignment)
        this.addStrictWarning("msg.equal.as.assign", "", conditionData.condition.getPosition(), conditionData.condition.getLength());
      return conditionData;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 235, 103, 109, 98, 103, 99, 137, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode getNextStatementAfterInlineComments([In] AstNode obj0)
    {
      AstNode astNode = this.statement();
      if (162 == astNode.getType())
      {
        AstNode inlineComment = astNode;
        astNode = this.statement();
        if (obj0 != null)
          obj0.setInlineComment(inlineComment);
        else
          astNode.setInlineComment(inlineComment);
      }
      return astNode;
    }

    [LineNumberTable(new byte[] {161, 91, 104, 107, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void enterSwitch([In] SwitchStatement obj0)
    {
      if (this.loopAndSwitchSet == null)
        this.loopAndSwitchSet = (List) new ArrayList();
      this.loopAndSwitchSet.add((object) obj0);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 244, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int nextToken()
    {
      int num = this.peekToken();
      this.consumeToken();
      return num;
    }

    [LineNumberTable(new byte[] {161, 97, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void exitSwitch() => this.loopAndSwitchSet.remove(this.loopAndSwitchSet.size() - 1);

    [LineNumberTable(new byte[] {161, 63, 104, 107, 109, 104, 107, 109, 103, 104, 108, 241, 69, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void enterLoop([In] Loop obj0)
    {
      if (this.loopSet == null)
        this.loopSet = (List) new ArrayList();
      this.loopSet.add((object) obj0);
      if (this.loopAndSwitchSet == null)
        this.loopAndSwitchSet = (List) new ArrayList();
      this.loopAndSwitchSet.add((object) obj0);
      this.pushScope((Scope) obj0);
      if (this.currentLabel == null)
        return;
      this.currentLabel.setStatement((AstNode) obj0);
      this.currentLabel.getFirstLabel().setLoop((Jump) obj0);
      obj0.setRelative(-this.currentLabel.getPosition());
    }

    [LineNumberTable(new byte[] {161, 82, 126, 121, 104, 145, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void exitLoop()
    {
      Loop loop = (Loop) this.loopSet.remove(this.loopSet.size() - 1);
      this.loopAndSwitchSet.remove(this.loopAndSwitchSet.size() - 1);
      if (loop.getParent() != null)
        loop.setRelative(loop.getParent().getPosition());
      this.popScope();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {165, 108, 135, 101, 119, 120, 109, 102, 150, 103, 135, 134, 103, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode forLoopInit([In] int obj0)
    {
      try
      {
        this.inForInit = true;
        AstNode astNode;
        switch (obj0)
        {
          case 83:
            EmptyExpression.__\u003Cclinit\u003E();
            astNode = (AstNode) new EmptyExpression(this.ts.tokenBeg, 1);
            astNode.setLineno(this.ts.lineno);
            break;
          case 123:
          case 154:
            this.consumeToken();
            astNode = (AstNode) this.variables(obj0, this.ts.tokenBeg, false);
            break;
          default:
            astNode = this.expr();
            this.markDestructuring(astNode);
            break;
        }
        return astNode;
      }
      finally
      {
        this.inForInit = false;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(986)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode statements() => this.statements((AstNode) null);

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 6, 130, 106, 102, 104, 156, 99, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LabeledStatement matchJumpLabelName()
    {
      LabeledStatement labeledStatement = (LabeledStatement) null;
      if (this.peekTokenOrEOL() == 39)
      {
        this.consumeToken();
        if (this.labelSet != null)
          labeledStatement = (LabeledStatement) this.labelSet.get((object) this.ts.getString());
        if (labeledStatement == null)
          this.reportError("msg.undef.label");
      }
      return labeledStatement;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {157, 138, 66, 103, 113, 112, 115, 135, 120, 103, 112, 147, 147, 102, 108, 104, 111, 116, 115, 104, 108, 130, 104, 112, 104, 131, 103, 114, 109, 202, 102, 37, 230, 60, 195, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode let([In] bool obj0, [In] int obj1)
    {
      int num = obj0 ? 1 : 0;
      LetNode letNode = new LetNode(obj1);
      letNode.setLineno(this.ts.lineno);
      if (this.mustMatchToken(88, "msg.no.paren.after.let", true))
        letNode.setLp(this.ts.tokenBeg - obj1);
      this.pushScope((Scope) letNode);
      ExpressionStatement expressionStatement1;
      // ISSUE: fault handler
      try
      {
        VariableDeclaration variables = this.variables(154, this.ts.tokenBeg, num != 0);
        letNode.setVariables(variables);
        if (this.mustMatchToken(89, "msg.no.paren.let", true))
          letNode.setRp(this.ts.tokenBeg - obj1);
        if (num != 0 && this.peekToken() == 86)
        {
          this.consumeToken();
          int tokenBeg = this.ts.tokenBeg;
          AstNode body = this.statements();
          this.mustMatchToken(87, "msg.no.curly.let", true);
          body.setLength(this.ts.tokenEnd - tokenBeg);
          letNode.setLength(this.ts.tokenEnd - obj1);
          letNode.setBody(body);
          letNode.setType(154);
          goto label_11;
        }
        else
        {
          AstNode body = this.expr();
          letNode.setLength(this.getNodeEnd(body) - obj1);
          letNode.setBody(body);
          if (num != 0)
          {
            ExpressionStatement.__\u003Cclinit\u003E();
            ExpressionStatement expressionStatement2 = new ExpressionStatement((AstNode) letNode, !this.insideFunction());
            expressionStatement2.setLineno(letNode.getLineno());
            expressionStatement1 = expressionStatement2;
          }
          else
            goto label_11;
        }
      }
      __fault
      {
        this.popScope();
      }
      this.popScope();
      return (AstNode) expressionStatement1;
label_11:
      this.popScope();
      return (AstNode) letNode;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool nowAllSet([In] int obj0, [In] int obj1, [In] int obj2) => (obj0 & obj2) != obj2 && (obj1 & obj2) == obj2;

    [LineNumberTable(new byte[] {173, 33, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setIsGenerator()
    {
      if (!this.insideFunction())
        return;
      ((FunctionNode) this.currentScriptOrFn).setIsGenerator();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {166, 244, 113, 102, 103, 104, 141, 114, 99, 109, 104, 103, 43, 165, 103, 43, 197, 103, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void recordLabel([In] Label obj0, [In] LabeledStatement obj1)
    {
      if (this.peekToken() != 104)
        this.codeBug();
      this.consumeToken();
      string name = obj0.getName();
      if (this.labelSet == null)
      {
        this.labelSet = (Map) new HashMap();
      }
      else
      {
        LabeledStatement labeledStatement = (LabeledStatement) this.labelSet.get((object) name);
        if (labeledStatement != null)
        {
          if (this.compilerEnv.isIdeMode())
          {
            Label labelByName = labeledStatement.getLabelByName(name);
            this.reportError("msg.dup.label", labelByName.getAbsolutePosition(), labelByName.getLength());
          }
          this.reportError("msg.dup.label", obj0.getPosition(), obj0.getLength());
        }
      }
      obj1.addLabel(obj0);
      this.labelSet.put((object) name, (object) obj1);
    }

    [LineNumberTable(new byte[] {95, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addError([In] string obj0) => this.addError(obj0, this.ts.tokenBeg, this.ts.tokenEnd - this.ts.tokenBeg);

    [LineNumberTable(new byte[] {69, 100, 104, 108, 152, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addWarning([In] string obj0, [In] string obj1)
    {
      int num1 = -1;
      int num2 = -1;
      if (this.ts != null)
      {
        num1 = this.ts.tokenBeg;
        num2 = this.ts.tokenEnd - this.ts.tokenBeg;
      }
      this.addWarning(obj0, obj1, num1, num2);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 73, 103, 110, 108, 238, 70, 104, 167, 140, 104, 35, 98, 98, 112, 108, 104, 117, 107, 104, 104, 105, 105, 107, 107, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode condExpr()
    {
      AstNode testExpression = this.orExpr();
      if (this.matchToken(103, true))
      {
        int lineno = this.ts.lineno;
        int tokenBeg = this.ts.tokenBeg;
        int num1 = -1;
        int num2 = this.inForInit ? 1 : 0;
        this.inForInit = false;
        AstNode trueExpression;
        try
        {
          trueExpression = this.assignExpr();
        }
        finally
        {
          this.inForInit = num2 != 0;
        }
        if (this.mustMatchToken(104, "msg.no.colon.cond", true))
          num1 = this.ts.tokenBeg;
        AstNode falseExpression = this.assignExpr();
        int position = testExpression.getPosition();
        int len = this.getNodeEnd(falseExpression) - position;
        ConditionalExpression conditionalExpression = new ConditionalExpression(position, len);
        conditionalExpression.setLineno(lineno);
        conditionalExpression.setTestExpression(testExpression);
        conditionalExpression.setTrueExpression(trueExpression);
        conditionalExpression.setFalseExpression(falseExpression);
        conditionalExpression.setQuestionMarkPosition(tokenBeg - position);
        conditionalExpression.setColonPosition(num1 - position);
        testExpression = (AstNode) conditionalExpression;
      }
      return testExpression;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {162, 251, 108, 141, 103, 103, 204, 102, 135, 137, 104, 109, 109, 105, 140, 98, 171, 107, 137, 127, 5, 101, 60, 135, 137, 98, 170, 110, 114, 151, 103, 35, 98, 130, 104, 107, 167, 108, 103, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode arrowFunction([In] AstNode obj0)
    {
      int lineno = this.ts.lineno;
      int num = obj0 == null ? -1 : obj0.getPosition();
      FunctionNode functionNode = new FunctionNode(num);
      functionNode.setFunctionType(4);
      functionNode.setJsDocNode(this.getAndResetJsDoc());
      HashMap hashMap = new HashMap();
      HashSet hashSet = new HashSet();
      Parser.PerFunctionVariables functionVariables = new Parser.PerFunctionVariables(this, functionNode);
      try
      {
        if (obj0 is ParenthesizedExpression)
        {
          functionNode.setParens(0, obj0.getLength());
          AstNode expression = ((ParenthesizedExpression) obj0).getExpression();
          if (!(expression is EmptyExpression))
            this.arrowFunctionParams(functionNode, expression, (Map) hashMap, (Set) hashSet);
        }
        else
          this.arrowFunctionParams(functionNode, obj0, (Map) hashMap, (Set) hashSet);
        if (!((Map) hashMap).isEmpty())
        {
          Node node = new Node(90);
          Iterator iterator = ((Map) hashMap).entrySet().iterator();
          while (iterator.hasNext())
          {
            Map.Entry entry = (Map.Entry) iterator.next();
            Node destructuringAssignment = this.createDestructuringAssignment(123, (Node) entry.getValue(), this.createName((string) entry.getKey()));
            node.addChildToBack(destructuringAssignment);
          }
          functionNode.putProp(23, (object) node);
        }
        functionNode.setBody(this.parseFunctionBody(4, functionNode));
        functionNode.setEncodedSourceBounds(num, this.ts.tokenEnd);
        functionNode.setLength(this.ts.tokenEnd - num);
      }
      finally
      {
        functionVariables.restore();
      }
      if (functionNode.isGenerator())
      {
        this.reportError("msg.arrowfunction.generator");
        return (AstNode) this.makeErrorNode();
      }
      functionNode.setSourceName(this.sourceURI);
      functionNode.setBaseLineno(lineno);
      functionNode.setEndLineno(this.ts.lineno);
      return (AstNode) functionNode;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 108, 103, 107, 108, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode orExpr()
    {
      AstNode left = this.andExpr();
      if (this.matchToken(105, true))
      {
        int tokenBeg = this.ts.tokenBeg;
        InfixExpression.__\u003Cclinit\u003E();
        left = (AstNode) new InfixExpression(105, left, this.orExpr(), tokenBeg);
      }
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 118, 103, 107, 108, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode andExpr()
    {
      AstNode left = this.bitOrExpr();
      if (this.matchToken(106, true))
      {
        int tokenBeg = this.ts.tokenBeg;
        InfixExpression.__\u003Cclinit\u003E();
        left = (AstNode) new InfixExpression(106, left, this.andExpr(), tokenBeg);
      }
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 128, 103, 107, 108, 117, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode bitOrExpr()
    {
      AstNode left = this.bitXorExpr();
      while (this.matchToken(9, true))
      {
        int tokenBeg = this.ts.tokenBeg;
        InfixExpression.__\u003Cclinit\u003E();
        left = (AstNode) new InfixExpression(9, left, this.bitXorExpr(), tokenBeg);
      }
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 138, 103, 107, 108, 117, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode bitXorExpr()
    {
      AstNode left = this.bitAndExpr();
      while (this.matchToken(10, true))
      {
        int tokenBeg = this.ts.tokenBeg;
        InfixExpression.__\u003Cclinit\u003E();
        left = (AstNode) new InfixExpression(10, left, this.bitAndExpr(), tokenBeg);
      }
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 148, 103, 107, 108, 117, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode bitAndExpr()
    {
      AstNode left = this.eqExpr();
      while (this.matchToken(11, true))
      {
        int tokenBeg = this.ts.tokenBeg;
        InfixExpression.__\u003Cclinit\u003E();
        left = (AstNode) new InfixExpression(11, left, this.eqExpr(), tokenBeg);
      }
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 158, 135, 115, 255, 5, 69, 102, 98, 143, 101, 101, 101, 131, 116, 133, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode eqExpr()
    {
      AstNode left = this.relExpr();
      while (true)
      {
        int num = this.peekToken();
        int tokenBeg = this.ts.tokenBeg;
        switch (num)
        {
          case 12:
          case 13:
          case 46:
          case 47:
            this.consumeToken();
            int @operator = num;
            if (this.compilerEnv.getLanguageVersion() == 120)
            {
              switch (num)
              {
                case 12:
                  @operator = 46;
                  break;
                case 13:
                  @operator = 47;
                  break;
              }
            }
            InfixExpression.__\u003Cclinit\u003E();
            left = (AstNode) new InfixExpression(@operator, left, this.relExpr(), tokenBeg);
            continue;
          default:
            goto label_2;
        }
      }
label_2:
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 185, 135, 115, 159, 21, 104, 226, 71, 102, 116, 133, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode relExpr()
    {
      AstNode left = this.shiftExpr();
      while (true)
      {
        int @operator = this.peekToken();
        int tokenBeg = this.ts.tokenBeg;
        switch (@operator)
        {
          case 14:
          case 15:
          case 16:
          case 17:
          case 53:
            this.consumeToken();
            InfixExpression.__\u003Cclinit\u003E();
            left = (AstNode) new InfixExpression(@operator, left, this.shiftExpr(), tokenBeg);
            continue;
          case 52:
            if (!this.inForInit)
              goto case 14;
            else
              goto label_4;
          default:
            goto label_4;
        }
      }
label_4:
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 209, 135, 115, 215, 102, 116, 130, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode shiftExpr()
    {
      AstNode left = this.addExpr();
      while (true)
      {
        int @operator = this.peekToken();
        int tokenBeg = this.ts.tokenBeg;
        switch (@operator)
        {
          case 18:
          case 19:
          case 20:
            this.consumeToken();
            InfixExpression.__\u003Cclinit\u003E();
            left = (AstNode) new InfixExpression(@operator, left, this.addExpr(), tokenBeg);
            continue;
          default:
            goto label_3;
        }
      }
label_3:
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 227, 135, 115, 106, 102, 116, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode addExpr()
    {
      AstNode left = this.mulExpr();
      while (true)
      {
        int @operator = this.peekToken();
        int tokenBeg = this.ts.tokenBeg;
        if (@operator == 21 || @operator == 22)
        {
          this.consumeToken();
          InfixExpression.__\u003Cclinit\u003E();
          left = (AstNode) new InfixExpression(@operator, left, this.mulExpr(), tokenBeg);
        }
        else
          break;
      }
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {168, 242, 135, 115, 215, 102, 116, 130, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode mulExpr()
    {
      AstNode left = this.unaryExpr();
      while (true)
      {
        int @operator = this.peekToken();
        int tokenBeg = this.ts.tokenBeg;
        switch (@operator)
        {
          case 23:
          case 24:
          case 25:
            this.consumeToken();
            InfixExpression.__\u003Cclinit\u003E();
            left = (AstNode) new InfixExpression(@operator, left, this.unaryExpr(), tokenBeg);
            continue;
          default:
            goto label_3;
        }
      }
label_3:
      return left;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {169, 5, 103, 104, 102, 136, 140, 255, 81, 71, 102, 125, 103, 162, 134, 126, 103, 162, 134, 126, 103, 194, 102, 115, 107, 103, 103, 162, 102, 231, 71, 137, 103, 106, 131, 102, 155, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode unaryExpr()
    {
      int operator1 = this.peekToken();
      if (operator1 == 162)
      {
        this.consumeToken();
        operator1 = this.peekUntilNonComment(operator1);
      }
      int lineno = this.ts.lineno;
      switch (operator1)
      {
        case -1:
          this.consumeToken();
          return (AstNode) this.makeErrorNode();
        case 21:
          this.consumeToken();
          UnaryExpression.__\u003Cclinit\u003E();
          UnaryExpression unaryExpression1 = new UnaryExpression(28, this.ts.tokenBeg, this.unaryExpr());
          unaryExpression1.setLineno(lineno);
          return (AstNode) unaryExpression1;
        case 22:
          this.consumeToken();
          UnaryExpression.__\u003Cclinit\u003E();
          UnaryExpression unaryExpression2 = new UnaryExpression(29, this.ts.tokenBeg, this.unaryExpr());
          unaryExpression2.setLineno(lineno);
          return (AstNode) unaryExpression2;
        case 26:
        case 27:
        case 31:
        case 32:
        case (int) sbyte.MaxValue:
          this.consumeToken();
          UnaryExpression.__\u003Cclinit\u003E();
          UnaryExpression unaryExpression3 = new UnaryExpression(operator1, this.ts.tokenBeg, this.unaryExpr());
          unaryExpression3.setLineno(lineno);
          return (AstNode) unaryExpression3;
        case 107:
        case 108:
          this.consumeToken();
          UnaryExpression.__\u003Cclinit\u003E();
          UnaryExpression unaryExpression4 = new UnaryExpression(operator1, this.ts.tokenBeg, this.memberExpr(true));
          unaryExpression4.setLineno(lineno);
          this.checkBadIncDec(unaryExpression4);
          return (AstNode) unaryExpression4;
        default:
          AstNode operand = this.memberExpr(true);
          int operator2 = this.peekTokenOrEOL();
          switch (operator2)
          {
            case 107:
            case 108:
              this.consumeToken();
              UnaryExpression.__\u003Cclinit\u003E();
              UnaryExpression unaryExpression5 = new UnaryExpression(operator2, this.ts.tokenBeg, operand, true);
              unaryExpression5.setLineno(lineno);
              this.checkBadIncDec(unaryExpression5);
              return (AstNode) unaryExpression5;
            default:
              return operand;
          }
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {164, 227, 104, 102, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int peekUntilNonComment([In] int obj0)
    {
      for (; obj0 == 162; obj0 = this.peekToken())
        this.consumeToken();
      return obj0;
    }

    [LineNumberTable(new byte[] {173, 39, 109, 103, 249, 69, 188})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkBadIncDec([In] UnaryExpression obj0)
    {
      switch (this.removeParens(obj0.getOperand()).getType())
      {
        case 33:
          break;
        case 36:
          break;
        case 38:
          break;
        case 39:
          break;
        case 68:
          break;
        default:
          this.reportError(obj0.getType() != 107 ? "msg.bad.decr" : "msg.bad.incr");
          break;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {156, 136, 98, 134, 106, 143, 98, 98, 106, 102, 110, 135, 99, 143, 122, 104, 104, 99, 104, 109, 111, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode generatorExpression([In] AstNode obj0, [In] int obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      ArrayList arrayList = new ArrayList();
      while (this.peekToken() == 120)
        ((List) arrayList).add((object) this.generatorExpressionLoop());
      int ifPosition = -1;
      Parser.ConditionData conditionData = (Parser.ConditionData) null;
      if (this.peekToken() == 113)
      {
        this.consumeToken();
        ifPosition = this.ts.tokenBeg - obj1;
        conditionData = this.condition();
      }
      if (num == 0)
        this.mustMatchToken(89, "msg.no.paren.let", true);
      GeneratorExpression.__\u003Cclinit\u003E();
      GeneratorExpression generatorExpression = new GeneratorExpression(obj1, this.ts.tokenEnd - obj1);
      generatorExpression.setResult(obj0);
      generatorExpression.setLoops((List) arrayList);
      if (conditionData != null)
      {
        generatorExpression.setIfPosition(ifPosition);
        generatorExpression.setFilter(conditionData.condition);
        generatorExpression.setFilterLp(conditionData.lp - obj1);
        generatorExpression.setFilterRp(conditionData.rp - obj1);
      }
      return (AstNode) generatorExpression;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {170, 90, 103, 136, 159, 160, 91, 102, 168, 102, 167, 102, 167, 102, 179, 102, 167, 102, 169, 102, 108, 117, 139, 109, 155, 109, 155, 109, 155, 109, 155, 151, 11, 225, 70, 102, 199, 134, 108, 121, 108, 114, 114, 227, 70, 102, 108, 109, 172, 102, 118, 162, 134, 162, 102, 107, 162, 102, 203, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode primaryExpr()
    {
      int num = this.peekFlaggedToken();
      int nodeType = num & (int) ushort.MaxValue;
      switch (nodeType)
      {
        case -1:
          this.consumeToken();
          break;
        case 0:
          this.consumeToken();
          this.reportError("msg.unexpected.eof");
          break;
        case 24:
        case 101:
          this.consumeToken();
          this.ts.readRegExp(nodeType);
          int tokenBeg1 = this.ts.tokenBeg;
          int tokenEnd1 = this.ts.tokenEnd;
          RegExpLiteral regExpLiteral = new RegExpLiteral(tokenBeg1, tokenEnd1 - tokenBeg1);
          regExpLiteral.setValue(this.ts.getString());
          regExpLiteral.setFlags(this.ts.readAndClearRegExpFlags());
          return (AstNode) regExpLiteral;
        case 39:
          this.consumeToken();
          return this.name(num, nodeType);
        case 40:
          this.consumeToken();
          string str = this.ts.getString();
          if (this.inUseStrictDirective && this.ts.isNumberOldOctal())
            this.reportError("msg.no.old.octal.strict");
          if (this.ts.isNumberBinary())
            str = new StringBuilder().append("0b").append(str).toString();
          if (this.ts.isNumberOldOctal())
            str = new StringBuilder().append("0").append(str).toString();
          if (this.ts.isNumberOctal())
            str = new StringBuilder().append("0o").append(str).toString();
          if (this.ts.isNumberHex())
            str = new StringBuilder().append("0x").append(str).toString();
          NumberLiteral.__\u003Cclinit\u003E();
          return (AstNode) new NumberLiteral(this.ts.tokenBeg, str, this.ts.getNumber());
        case 41:
          this.consumeToken();
          return (AstNode) this.createStringLiteral();
        case 42:
        case 43:
        case 44:
        case 45:
          this.consumeToken();
          int tokenBeg2 = this.ts.tokenBeg;
          int tokenEnd2 = this.ts.tokenEnd;
          return (AstNode) new KeywordLiteral(tokenBeg2, tokenEnd2 - tokenBeg2, nodeType);
        case 84:
          this.consumeToken();
          return this.arrayLiteral();
        case 86:
          this.consumeToken();
          return (AstNode) this.objectLiteral();
        case 88:
          this.consumeToken();
          return this.parenExpr();
        case 110:
          this.consumeToken();
          return (AstNode) this.function(2);
        case 128:
          this.consumeToken();
          this.reportError("msg.reserved.id", this.ts.getString());
          break;
        case 154:
          this.consumeToken();
          return this.let(false, this.ts.tokenBeg);
        default:
          this.consumeToken();
          this.reportError("msg.syntax");
          break;
      }
      this.consumeToken();
      return (AstNode) this.makeErrorNode();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("()Ljava/util/List<Lrhino/ast/AstNode;>;")]
    [LineNumberTable(new byte[] {169, 73, 107, 130, 102, 103, 167, 138, 130, 106, 139, 103, 138, 184, 232, 70, 103, 234, 55, 129, 130, 204, 103, 227, 61, 145, 103, 40, 103, 130, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private List argumentList()
    {
      if (this.matchToken(89, true))
        return (List) null;
      ArrayList arrayList = new ArrayList();
      int num = this.inForInit ? 1 : 0;
      this.inForInit = false;
label_3:
      AstNode astNode;
      // ISSUE: fault handler
      try
      {
        if (this.peekToken() != 89)
        {
          if (this.peekToken() == 73)
            this.reportError("msg.yield.parenthesized");
          astNode = this.assignExpr();
          if (this.peekToken() == 120)
          {
            try
            {
              ((List) arrayList).add((object) this.generatorExpression(astNode, 0, true));
              goto label_13;
            }
            catch (IOException ex)
            {
            }
          }
          else
            goto label_11;
        }
        else
          goto label_15;
      }
      __fault
      {
        this.inForInit = num != 0;
      }
      goto label_13;
label_11:
      // ISSUE: fault handler
      try
      {
        ((List) arrayList).add((object) astNode);
      }
      __fault
      {
        this.inForInit = num != 0;
      }
label_13:
      // ISSUE: fault handler
      try
      {
        if (this.matchToken(90, true))
          goto label_3;
      }
      __fault
      {
        this.inForInit = num != 0;
      }
label_15:
      this.inForInit = num != 0;
      this.mustMatchToken(89, "msg.no.paren.arg", true);
      return (List) arrayList;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {171, 253, 120, 98, 102, 99, 99, 104, 103, 135, 200, 99, 99, 104, 104, 105, 102, 138, 102, 103, 174, 104, 100, 144, 109, 109, 230, 74, 104, 187, 102, 101, 107, 110, 101, 110, 163, 106, 104, 100, 139, 134, 100, 133, 109, 142, 105, 105, 130, 105, 209, 114, 191, 15, 111, 103, 141, 106, 106, 130, 107, 141, 106, 130, 107, 141, 234, 70, 135, 107, 204, 133, 111, 122, 100, 137, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ObjectLiteral objectLiteral()
    {
      int tokenBeg1 = this.ts.tokenBeg;
      int lineno = this.ts.lineno;
      int num1 = -1;
      ArrayList arrayList = new ArrayList();
      HashSet hashSet1 = (HashSet) null;
      HashSet hashSet2 = (HashSet) null;
      if (this.inUseStrictDirective)
      {
        hashSet1 = new HashSet();
        hashSet2 = new HashSet();
      }
      Comment andResetJsDoc1 = this.getAndResetJsDoc();
      while (true)
      {
        string str = (string) null;
        int num2 = 1;
        int num3 = this.peekToken();
        Comment andResetJsDoc2 = this.getAndResetJsDoc();
        if (num3 == 162)
        {
          this.consumeToken();
          num3 = this.peekUntilNonComment(num3);
        }
        if (num3 != 87)
        {
          AstNode astNode = this.objliteralProperty();
          if (astNode == null)
          {
            this.reportError("msg.bad.prop");
          }
          else
          {
            str = this.ts.getString();
            int tokenBeg2 = this.ts.tokenBeg;
            this.consumeToken();
            switch (this.peekToken())
            {
              case 87:
              case 90:
              case 104:
                astNode.setJsDocNode(andResetJsDoc2);
                ((List) arrayList).add((object) this.plainProperty(astNode, num3));
                goto label_25;
              case 88:
                num2 = 8;
                break;
              default:
                if (astNode.getType() == 39)
                {
                  if (String.instancehelper_equals("get", (object) str))
                  {
                    num2 = 2;
                    break;
                  }
                  if (String.instancehelper_equals("set", (object) str))
                  {
                    num2 = 4;
                    break;
                  }
                  break;
                }
                break;
            }
            if (num2 == 2 || num2 == 4)
            {
              astNode = this.objliteralProperty();
              if (astNode == null)
                this.reportError("msg.bad.prop");
              this.consumeToken();
            }
            if (astNode == null)
            {
              str = (string) null;
            }
            else
            {
              str = this.ts.getString();
              ObjectProperty objectProperty = this.methodDefinition(tokenBeg2, astNode, num2);
              astNode.setJsDocNode(andResetJsDoc2);
              ((List) arrayList).add((object) objectProperty);
            }
          }
label_25:
          if (this.inUseStrictDirective && str != null)
          {
            switch (num2)
            {
              case 1:
              case 8:
                if (((Set) hashSet1).contains((object) str) || ((Set) hashSet2).contains((object) str))
                  this.addError("msg.dup.obj.lit.prop.strict", str);
                ((Set) hashSet1).add((object) str);
                ((Set) hashSet2).add((object) str);
                break;
              case 2:
                if (((Set) hashSet1).contains((object) str))
                  this.addError("msg.dup.obj.lit.prop.strict", str);
                ((Set) hashSet1).add((object) str);
                break;
              case 4:
                if (((Set) hashSet2).contains((object) str))
                  this.addError("msg.dup.obj.lit.prop.strict", str);
                ((Set) hashSet2).add((object) str);
                break;
            }
          }
          this.getAndResetJsDoc();
          if (this.matchToken(90, true))
            num1 = this.ts.tokenEnd;
          else
            goto label_38;
        }
        else
          break;
      }
      if (num1 != -1)
        this.warnTrailingComma(tokenBeg1, (List) arrayList, num1);
label_38:
      this.mustMatchToken(87, "msg.no.brace.prop", true);
      ObjectLiteral.__\u003Cclinit\u003E();
      ObjectLiteral objectLiteral = new ObjectLiteral(tokenBeg1, this.ts.tokenEnd - tokenBeg1);
      if (andResetJsDoc1 != null)
        objectLiteral.setJsDocNode(andResetJsDoc1);
      objectLiteral.setElements((List) arrayList);
      objectLiteral.setLineno(lineno);
      return objectLiteral;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {169, 240, 106, 122, 134, 112, 103, 107, 109, 125, 171, 107, 107, 104, 227, 69, 104, 191, 15, 127, 2, 106, 197, 106, 197, 127, 2, 106, 165, 109, 126, 106, 194, 141, 105, 100, 126, 106, 162, 107, 167, 103, 104, 105, 114, 107, 109, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode propertyAccess([In] int obj0, [In] AstNode obj1)
    {
      if (obj1 == null)
        this.codeBug();
      int num = 0;
      int lineno = this.ts.lineno;
      int tokenBeg = this.ts.tokenBeg;
      this.consumeToken();
      if (!this.compilerEnv.isXmlAvailable())
      {
        if (this.nextToken() != 39 && (!this.compilerEnv.isReservedKeywordAsIdentifier() || !TokenStream.isKeyword(this.ts.getString(), this.compilerEnv.getLanguageVersion(), this.inUseStrictDirective)))
          this.reportError("msg.no.name.after.dot");
        Name nameNode = this.createNameNode(true, 33);
        PropertyGet propertyGet = new PropertyGet(obj1, nameNode, tokenBeg);
        propertyGet.setLineno(lineno);
        return (AstNode) propertyGet;
      }
      int token = this.nextToken();
      AstNode right;
      switch (token)
      {
        case 23:
          this.saveNameTokenData(this.ts.tokenBeg, "*", this.ts.lineno);
          right = this.propertyName(-1, num);
          break;
        case 39:
          right = this.propertyName(-1, num);
          break;
        case 50:
          this.saveNameTokenData(this.ts.tokenBeg, "throw", this.ts.lineno);
          right = this.propertyName(-1, num);
          break;
        case 128:
          this.saveNameTokenData(this.ts.tokenBeg, this.ts.getString(), this.ts.lineno);
          right = this.propertyName(-1, num);
          break;
        default:
          if (this.compilerEnv.isReservedKeywordAsIdentifier())
          {
            string name = Token.keywordToName(token);
            if (name != null)
            {
              this.saveNameTokenData(this.ts.tokenBeg, name, this.ts.lineno);
              right = this.propertyName(-1, num);
              break;
            }
          }
          this.reportError("msg.no.name.after.dot");
          return (AstNode) this.makeErrorNode();
      }
      PropertyGet propertyGet1 = new PropertyGet();
      int position = obj1.getPosition();
      propertyGet1.setPosition(position);
      propertyGet1.setLength(this.getNodeEnd(right) - position);
      propertyGet1.setOperatorPosition(tokenBeg - position);
      propertyGet1.setLineno(obj1.getLineno());
      propertyGet1.setLeft(obj1);
      propertyGet1.setRight(right);
      return (AstNode) propertyGet1;
    }

    [LineNumberTable(new byte[] {173, 25, 117, 109, 116, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkCallRequiresActivation([In] AstNode obj0)
    {
      if ((obj0.getType() != 39 || !String.instancehelper_equals("eval", (object) ((Name) obj0).getIdentifier())) && (obj0.getType() != 33 || !String.instancehelper_equals("eval", (object) ((PropertyGet) obj0).getProperty().getIdentifier())))
        return;
      this.setRequiresActivation();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private void saveNameTokenData([In] int obj0, [In] string obj1, [In] int obj2)
    {
      this.prevNameTokenStart = obj0;
      this.prevNameTokenString = obj1;
      this.prevNameTokenLineno = obj2;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {170, 66, 127, 0, 98, 110, 130, 106, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode propertyName([In] int obj0, [In] int obj1)
    {
      int num = obj0 == -1 ? this.ts.tokenBeg : obj0;
      int lineno = this.ts.lineno;
      Name nameNode = this.createNameNode(true, this.currentToken);
      if (null == null && obj1 == 0 && obj0 == -1)
        return (AstNode) nameNode;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException("one of us has done something horribly wrong ");
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {170, 248, 113, 120, 102, 103, 99, 99, 131, 104, 102, 102, 109, 100, 136, 125, 139, 105, 107, 102, 230, 70, 108, 149, 104, 104, 143, 107, 104, 116, 100, 107, 130, 100, 139, 109, 99, 131, 101, 127, 0, 104, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode arrayLiteral()
    {
      if (this.currentToken != 84)
        this.codeBug();
      int tokenBeg = this.ts.tokenBeg;
      int tokenEnd = this.ts.tokenEnd;
      ArrayList arrayList1 = new ArrayList();
      ArrayLiteral arrayLiteral = new ArrayLiteral(tokenBeg);
      int num1 = 1;
      int num2 = -1;
      int count = 0;
      while (true)
      {
        int num3 = this.peekToken();
        switch (num3)
        {
          case 85:
            goto label_8;
          case 90:
            this.consumeToken();
            num2 = this.ts.tokenEnd;
            if (num1 == 0)
            {
              num1 = 1;
              continue;
            }
            ArrayList arrayList2 = arrayList1;
            EmptyExpression.__\u003Cclinit\u003E();
            EmptyExpression emptyExpression = new EmptyExpression(this.ts.tokenBeg, 1);
            ((List) arrayList2).add((object) emptyExpression);
            ++count;
            continue;
          case 162:
            this.consumeToken();
            continue;
          default:
            if (num3 != 120 || num1 != 0 || ((List) arrayList1).size() != 1)
            {
              if (num3 != 0)
              {
                if (num1 == 0)
                  this.reportError("msg.no.bracket.arg");
                ((List) arrayList1).add((object) this.assignExpr());
                num1 = 0;
                num2 = -1;
                continue;
              }
              goto label_13;
            }
            else
              goto label_11;
        }
      }
label_8:
      this.consumeToken();
      tokenEnd = this.ts.tokenEnd;
      arrayLiteral.setDestructuringLength(((List) arrayList1).size() + (num1 == 0 ? 0 : 1));
      arrayLiteral.setSkipCount(count);
      if (num2 != -1)
      {
        this.warnTrailingComma(tokenBeg, (List) arrayList1, num2);
        goto label_17;
      }
      else
        goto label_17;
label_11:
      return this.arrayComprehension((AstNode) ((List) arrayList1).get(0), tokenBeg);
label_13:
      this.reportError("msg.no.bracket.arg");
label_17:
      Iterator iterator = ((List) arrayList1).iterator();
      while (iterator.hasNext())
      {
        AstNode element = (AstNode) iterator.next();
        arrayLiteral.addElement(element);
      }
      arrayLiteral.setLength(tokenEnd - tokenBeg);
      return (AstNode) arrayLiteral;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {170, 191, 103, 135, 103, 108, 108, 122, 106, 241, 82, 103, 37, 231, 46, 131, 111, 123, 107, 238, 77, 103, 37, 231, 51, 131, 111, 108, 104, 99, 135, 99, 136, 136, 103, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode parenExpr()
    {
      int num = this.inForInit ? 1 : 0;
      this.inForInit = false;
      Comment andResetJsDoc;
      int lineno;
      int tokenBeg;
      AstNode expr;
      AstNode astNode;
      // ISSUE: fault handler
      try
      {
        andResetJsDoc = this.getAndResetJsDoc();
        lineno = this.ts.lineno;
        tokenBeg = this.ts.tokenBeg;
        expr = this.peekToken() != 89 ? this.expr() : (AstNode) new EmptyExpression(tokenBeg);
        if (this.peekToken() == 120)
          astNode = this.generatorExpression(expr, tokenBeg);
        else
          goto label_5;
      }
      __fault
      {
        this.inForInit = num != 0;
      }
      this.inForInit = num != 0;
      return astNode;
label_5:
      ErrorNode errorNode;
      // ISSUE: fault handler
      try
      {
        this.mustMatchToken(89, "msg.no.paren", true);
        if (expr.getType() == 129)
        {
          if (this.peekToken() != 165)
          {
            this.reportError("msg.syntax");
            errorNode = this.makeErrorNode();
          }
          else
            goto label_10;
        }
        else
          goto label_10;
      }
      __fault
      {
        this.inForInit = num != 0;
      }
      this.inForInit = num != 0;
      return (AstNode) errorNode;
label_10:
      try
      {
        int len = this.ts.tokenEnd - tokenBeg;
        ParenthesizedExpression parenthesizedExpression = new ParenthesizedExpression(tokenBeg, len, expr);
        parenthesizedExpression.setLineno(lineno);
        if (andResetJsDoc == null)
          andResetJsDoc = this.getAndResetJsDoc();
        if (andResetJsDoc != null)
          parenthesizedExpression.setJsDocNode(andResetJsDoc);
        return (AstNode) parenthesizedExpression;
      }
      finally
      {
        this.inForInit = num != 0;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {170, 222, 108, 120, 180, 121, 103, 113, 226, 69, 137, 109, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode name([In] int obj0, [In] int obj1)
    {
      string name = this.ts.getString();
      int tokenBeg = this.ts.tokenBeg;
      int lineno = this.ts.lineno;
      if (0 != (obj0 & 131072) && this.peekToken() == 104)
      {
        Label.__\u003Cclinit\u003E();
        Label label = new Label(tokenBeg, this.ts.tokenEnd - tokenBeg);
        label.setName(name);
        label.setLineno(this.ts.lineno);
        return (AstNode) label;
      }
      this.saveNameTokenData(tokenBeg, name, lineno);
      return this.compilerEnv.isXmlAvailable() ? this.propertyName(-1, 0) : (AstNode) this.createNameNode(true, 39);
    }

    [LineNumberTable(new byte[] {172, 242, 120, 106, 113, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private StringLiteral createStringLiteral()
    {
      int tokenBeg = this.ts.tokenBeg;
      int tokenEnd = this.ts.tokenEnd;
      StringLiteral stringLiteral = new StringLiteral(tokenBeg, tokenEnd - tokenBeg);
      stringLiteral.setLineno(this.ts.lineno);
      stringLiteral.setValue(this.ts.getString());
      stringLiteral.setQuoteCharacter(this.ts.getQuoteChar());
      return stringLiteral;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(3091)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode generatorExpression([In] AstNode obj0, [In] int obj1) => this.generatorExpression(obj0, obj1, false);

    [Signature("(ILjava/util/List<*>;I)V")]
    [LineNumberTable(new byte[] {173, 123, 141, 104, 147, 111, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void warnTrailingComma([In] int obj0, [In] List obj1, [In] int obj2)
    {
      if (!this.compilerEnv.getWarnTrailingComma())
        return;
      if (!obj1.isEmpty())
        obj0 = ((AstNode) obj1.get(0)).getPosition();
      obj0 = Math.max(obj0, this.lineBeginningFor(obj2));
      this.addWarning("msg.extra.trailing.comma", obj0, obj2 - obj0);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {171, 56, 134, 106, 143, 98, 98, 106, 102, 110, 135, 111, 121, 103, 103, 99, 103, 108, 110, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode arrayComprehension([In] AstNode obj0, [In] int obj1)
    {
      ArrayList arrayList = new ArrayList();
      while (this.peekToken() == 120)
        ((List) arrayList).add((object) this.arrayComprehensionLoop());
      int ifPosition = -1;
      Parser.ConditionData conditionData = (Parser.ConditionData) null;
      if (this.peekToken() == 113)
      {
        this.consumeToken();
        ifPosition = this.ts.tokenBeg - obj1;
        conditionData = this.condition();
      }
      this.mustMatchToken(85, "msg.no.bracket.arg", true);
      ArrayComprehension.__\u003Cclinit\u003E();
      ArrayComprehension arrayComprehension = new ArrayComprehension(obj1, this.ts.tokenEnd - obj1);
      arrayComprehension.setResult(obj0);
      arrayComprehension.setLoops((List) arrayList);
      if (conditionData != null)
      {
        arrayComprehension.setIfPosition(ifPosition);
        arrayComprehension.setFilter(conditionData.condition);
        arrayComprehension.setFilterLp(conditionData.lp - obj1);
        arrayComprehension.setFilterRp(conditionData.rp - obj1);
      }
      return (AstNode) arrayComprehension;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {171, 83, 113, 108, 105, 99, 136, 136, 107, 119, 144, 171, 112, 174, 99, 223, 2, 104, 104, 130, 102, 104, 130, 235, 69, 107, 183, 153, 111, 130, 119, 100, 139, 111, 99, 194, 139, 104, 112, 142, 116, 105, 105, 105, 104, 110, 105, 105, 136, 102, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ArrayComprehensionLoop arrayComprehensionLoop()
    {
      if (this.nextToken() != 120)
        this.codeBug();
      int tokenBeg = this.ts.tokenBeg;
      int eachPosition = -1;
      int lp = -1;
      int rp = -1;
      int inPosition = -1;
      int num = 0;
      ArrayComprehensionLoop comprehensionLoop = new ArrayComprehensionLoop(tokenBeg);
      this.pushScope((Scope) comprehensionLoop);
      try
      {
        if (this.matchToken(39, true))
        {
          if (String.instancehelper_equals(this.ts.getString(), (object) "each"))
            eachPosition = this.ts.tokenBeg - tokenBeg;
          else
            this.reportError("msg.no.paren.for");
        }
        if (this.mustMatchToken(88, "msg.no.paren.for", true))
          lp = this.ts.tokenBeg - tokenBeg;
        AstNode iterator = (AstNode) null;
        switch (this.peekToken())
        {
          case 39:
            this.consumeToken();
            iterator = (AstNode) this.createNameNode();
            break;
          case 84:
          case 86:
            iterator = this.destructuringPrimaryExpr();
            this.markDestructuring(iterator);
            break;
          default:
            this.reportError("msg.bad.var");
            break;
        }
        if (iterator.getType() == 39)
          this.defineSymbol(154, this.ts.getString(), true);
        switch (this.nextToken())
        {
          case 39:
            if (String.instancehelper_equals("of", (object) this.ts.getString()))
            {
              if (eachPosition != -1)
                this.reportError("msg.invalid.for.each");
              inPosition = this.ts.tokenBeg - tokenBeg;
              num = 1;
              break;
            }
            goto default;
          case 52:
            inPosition = this.ts.tokenBeg - tokenBeg;
            break;
          default:
            this.reportError("msg.in.after.for.name");
            break;
        }
        AstNode @object = this.expr();
        if (this.mustMatchToken(89, "msg.no.paren.for.ctrl", true))
          rp = this.ts.tokenBeg - tokenBeg;
        comprehensionLoop.setLength(this.ts.tokenEnd - tokenBeg);
        comprehensionLoop.setIterator(iterator);
        comprehensionLoop.setIteratedObject(@object);
        comprehensionLoop.setInPosition(inPosition);
        comprehensionLoop.setEachPosition(eachPosition);
        comprehensionLoop.setIsForEach(eachPosition != -1);
        comprehensionLoop.setParens(lp, rp);
        comprehensionLoop.setIsForOf(num != 0);
        return comprehensionLoop;
      }
      finally
      {
        this.popScope();
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {171, 196, 113, 108, 102, 136, 136, 112, 174, 99, 223, 2, 104, 104, 130, 102, 104, 130, 235, 69, 107, 183, 112, 110, 104, 112, 142, 116, 105, 105, 104, 105, 136, 102, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private GeneratorExpressionLoop generatorExpressionLoop()
    {
      if (this.nextToken() != 120)
        this.codeBug();
      int tokenBeg = this.ts.tokenBeg;
      int lp = -1;
      int rp = -1;
      int inPosition = -1;
      GeneratorExpressionLoop generatorExpressionLoop = new GeneratorExpressionLoop(tokenBeg);
      this.pushScope((Scope) generatorExpressionLoop);
      try
      {
        if (this.mustMatchToken(88, "msg.no.paren.for", true))
          lp = this.ts.tokenBeg - tokenBeg;
        AstNode iterator = (AstNode) null;
        switch (this.peekToken())
        {
          case 39:
            this.consumeToken();
            iterator = (AstNode) this.createNameNode();
            break;
          case 84:
          case 86:
            iterator = this.destructuringPrimaryExpr();
            this.markDestructuring(iterator);
            break;
          default:
            this.reportError("msg.bad.var");
            break;
        }
        if (iterator.getType() == 39)
          this.defineSymbol(154, this.ts.getString(), true);
        if (this.mustMatchToken(52, "msg.in.after.for.name", true))
          inPosition = this.ts.tokenBeg - tokenBeg;
        AstNode @object = this.expr();
        if (this.mustMatchToken(89, "msg.no.paren.for.ctrl", true))
          rp = this.ts.tokenBeg - tokenBeg;
        generatorExpressionLoop.setLength(this.ts.tokenEnd - tokenBeg);
        generatorExpressionLoop.setIterator(iterator);
        generatorExpressionLoop.setIteratedObject(@object);
        generatorExpressionLoop.setInPosition(inPosition);
        generatorExpressionLoop.setParens(lp, rp);
        return generatorExpressionLoop;
      }
      finally
      {
        this.popScope();
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {172, 122, 103, 151, 103, 165, 103, 162, 118, 119, 162, 115, 157, 103, 130, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private AstNode objliteralProperty()
    {
      switch (this.peekToken())
      {
        case 39:
          return (AstNode) this.createNameNode();
        case 40:
          NumberLiteral.__\u003Cclinit\u003E();
          return (AstNode) new NumberLiteral(this.ts.tokenBeg, this.ts.getString(), this.ts.getNumber());
        case 41:
          return (AstNode) this.createStringLiteral();
        default:
          return this.compilerEnv.isReservedKeywordAsIdentifier() && TokenStream.isKeyword(this.ts.getString(), this.compilerEnv.getLanguageVersion(), this.inUseStrictDirective) ? (AstNode) this.createNameNode() : (AstNode) null;
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {172, 175, 136, 103, 107, 139, 103, 153, 102, 102, 130, 102, 102, 130, 102, 166, 104, 103, 103, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ObjectProperty methodDefinition([In] int obj0, [In] AstNode obj1, [In] int obj2)
    {
      FunctionNode functionNode = this.function(2);
      Name functionName = functionNode.getFunctionName();
      if (functionName != null && functionName.length() != 0)
        this.reportError("msg.bad.prop");
      ObjectProperty objectProperty = new ObjectProperty(obj0);
      switch (obj2)
      {
        case 2:
          objectProperty.setIsGetterMethod();
          functionNode.setFunctionIsGetterMethod();
          break;
        case 4:
          objectProperty.setIsSetterMethod();
          functionNode.setFunctionIsSetterMethod();
          break;
        case 8:
          objectProperty.setIsNormalMethod();
          functionNode.setFunctionIsNormalMethod();
          break;
      }
      int nodeEnd = this.getNodeEnd((AstNode) functionNode);
      objectProperty.setLeft(obj1);
      objectProperty.setRight((AstNode) functionNode);
      objectProperty.setLength(nodeEnd - obj0);
      return objectProperty;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {172, 154, 103, 117, 108, 104, 139, 119, 102, 109, 104, 130, 111, 102, 113, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ObjectProperty plainProperty([In] AstNode obj0, [In] int obj1)
    {
      switch (this.peekToken())
      {
        case 87:
        case 90:
          if (obj1 == 39 && this.compilerEnv.getLanguageVersion() >= 180)
          {
            if (!this.inDestructuringAssignment)
              this.reportError("msg.bad.object.init");
            Name.__\u003Cclinit\u003E();
            Name name = new Name(obj0.getPosition(), obj0.getString());
            ObjectProperty objectProperty = new ObjectProperty();
            objectProperty.putProp(26, (object) Boolean.TRUE);
            objectProperty.setLeftAndRight(obj0, (AstNode) name);
            return objectProperty;
          }
          break;
      }
      this.mustMatchToken(104, "msg.no.colon.prop", true);
      ObjectProperty objectProperty1 = new ObjectProperty();
      objectProperty1.setOperatorPosition(this.ts.tokenBeg);
      objectProperty1.setLeftAndRight(obj0, this.assignExpr());
      return objectProperty1;
    }

    [LineNumberTable(new byte[] {172, 251, 104, 129, 98, 152, 104, 100, 115, 109, 100, 109, 107, 137, 162, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void checkActivationName(string name, int token)
    {
      if (!this.insideFunction())
        return;
      int num = 0;
      if (String.instancehelper_equals("arguments", (object) name) && ((FunctionNode) this.currentScriptOrFn).getFunctionType() != 4)
        num = 1;
      else if (this.compilerEnv.getActivationNames() != null && this.compilerEnv.getActivationNames().contains((object) name))
        num = 1;
      else if (String.instancehelper_equals("length", (object) name) && token == 33 && this.compilerEnv.getLanguageVersion() == 120)
        num = 1;
      if (num == 0)
        return;
      this.setRequiresActivation();
    }

    [LineNumberTable(new byte[] {174, 199, 104, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual AstNode removeParens(AstNode node)
    {
      while (node is ParenthesizedExpression)
        node = ((ParenthesizedExpression) node).getExpression();
      return node;
    }

    [LineNumberTable(new byte[] {160, 69, 109, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addStrictWarning(
      [In] string obj0,
      [In] string obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] string obj5,
      [In] int obj6)
    {
      if (!this.compilerEnv.isStrictMode())
        return;
      this.addWarning(obj0, obj1, obj2, obj3, obj4, obj5, obj6);
    }

    [LineNumberTable(new byte[] {78, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addWarning([In] string obj0, [In] int obj1, [In] int obj2) => this.addWarning(obj0, (string) null, obj1, obj2);

    [LineNumberTable(new byte[] {173, 200, 114, 113, 42, 165, 103, 146, 102, 35, 98, 98, 104, 103, 102, 98, 159, 13, 178, 133, 178, 162, 223, 3, 139, 117, 130, 139, 131, 145, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Node destructuringAssignmentHelper(
      [In] int obj0,
      [In] Node obj1,
      [In] Node obj2,
      [In] string obj3)
    {
      Scope scopeNode = this.createScopeNode(159, obj1.getLineno());
      Scope scope = scopeNode;
      Node.__\u003Cclinit\u003E();
      Node child1 = new Node(154, this.createName(39, obj3, obj2));
      scope.addChildToFront(child1);
      try
      {
        this.pushScope(scopeNode);
        this.defineSymbol(154, obj3, true);
      }
      finally
      {
        this.popScope();
      }
      Node child2 = new Node(90);
      scopeNode.addChildToBack(child2);
      ArrayList arrayList = new ArrayList();
      int num = 1;
      switch (obj1.getType())
      {
        case 33:
        case 36:
          switch (obj0)
          {
            case 123:
            case 154:
            case 155:
              this.reportError("msg.bad.assign.left");
              break;
          }
          child2.addChildToBack(this.simpleAssignment(obj1, this.createName(obj3)));
          break;
        case 66:
          num = this.destructuringArray((ArrayLiteral) obj1, obj0, obj3, child2, (List) arrayList) ? 1 : 0;
          break;
        case 67:
          num = this.destructuringObject((ObjectLiteral) obj1, obj0, obj3, child2, (List) arrayList) ? 1 : 0;
          break;
        default:
          this.reportError("msg.bad.assign.left");
          break;
      }
      if (num != 0)
        child2.addChildToBack(this.createNumber(0.0));
      scopeNode.putProp(22, (object) arrayList);
      return (Node) scopeNode;
    }

    [LineNumberTable(new byte[] {174, 108, 102, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Scope createScopeNode(int token, int lineno)
    {
      Scope scope = new Scope();
      scope.setType(token);
      scope.setLineno(lineno);
      return scope;
    }

    [LineNumberTable(new byte[] {174, 89, 104, 104, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Node createName(int type, string name, Node child)
    {
      Node name1 = this.createName(name);
      name1.setType(type);
      if (child != null)
        name1.addChildToBack(child);
      return name1;
    }

    [Signature("(Lrhino/ast/ArrayLiteral;ILjava/lang/String;Lrhino/Node;Ljava/util/List<Ljava/lang/String;>;)Z")]
    [LineNumberTable(new byte[] {173, 250, 98, 145, 98, 127, 5, 110, 100, 130, 105, 104, 108, 107, 105, 110, 44, 197, 100, 106, 138, 98, 206, 5, 37, 229, 69, 100, 98, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool destructuringArray(
      [In] ArrayLiteral obj0,
      [In] int obj1,
      [In] string obj2,
      [In] Node obj3,
      [In] List obj4)
    {
      int num1 = 1;
      int nodeType = obj1 != 155 ? 8 : 156;
      int num2 = 0;
      Iterator iterator = obj0.getElements().iterator();
      while (iterator.hasNext())
      {
        AstNode astNode = (AstNode) iterator.next();
        if (astNode.getType() == 129)
        {
          ++num2;
        }
        else
        {
          Node.__\u003Cclinit\u003E();
          Node right = new Node(36, this.createName(obj2), this.createNumber((double) num2));
          if (astNode.getType() == 39)
          {
            string name = astNode.getString();
            Node node = obj3;
            Node.__\u003Cclinit\u003E();
            Node child = new Node(nodeType, this.createName(49, name, (Node) null), right);
            node.addChildToBack(child);
            if (obj1 != -1)
            {
              this.defineSymbol(obj1, name, true);
              obj4.add((object) name);
            }
          }
          else
            obj3.addChildToBack(this.destructuringAssignmentHelper(obj1, (Node) astNode, right, this.currentScriptOrFn.getNextTempName()));
          ++num2;
          num1 = 0;
        }
      }
      return num1 != 0;
    }

    [Signature("(Lrhino/ast/ObjectLiteral;ILjava/lang/String;Lrhino/Node;Ljava/util/List<Ljava/lang/String;>;)Z")]
    [LineNumberTable(new byte[] {174, 34, 98, 177, 127, 4, 195, 104, 141, 136, 105, 115, 119, 110, 115, 119, 107, 123, 119, 98, 140, 105, 104, 107, 110, 110, 44, 197, 100, 106, 138, 98, 174, 37, 37, 197, 98, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool destructuringObject(
      [In] ObjectLiteral obj0,
      [In] int obj1,
      [In] string obj2,
      [In] Node obj3,
      [In] List obj4)
    {
      int num = 1;
      int nodeType = obj1 != 155 ? 8 : 156;
      Iterator iterator = obj0.getElements().iterator();
      while (iterator.hasNext())
      {
        ObjectProperty objectProperty = (ObjectProperty) iterator.next();
        int lineno = 0;
        if (this.ts != null)
          lineno = this.ts.lineno;
        AstNode left = objectProperty.getLeft();
        Node right1;
        switch (left)
        {
          case Name _:
            Node right2 = Node.newString(((Name) left).getIdentifier());
            Node.__\u003Cclinit\u003E();
            right1 = new Node(33, this.createName(obj2), right2);
            break;
          case StringLiteral _:
            Node right3 = Node.newString(((StringLiteral) left).getValue());
            Node.__\u003Cclinit\u003E();
            right1 = new Node(33, this.createName(obj2), right3);
            break;
          case NumberLiteral _:
            Node number = this.createNumber((double) ByteCodeHelper.d2i(((NumberLiteral) left).getNumber()));
            Node.__\u003Cclinit\u003E();
            right1 = new Node(36, this.createName(obj2), number);
            break;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) this.codeBug());
        }
        right1.setLineno(lineno);
        AstNode right4 = objectProperty.getRight();
        if (right4.getType() == 39)
        {
          string identifier = ((Name) right4).getIdentifier();
          Node node = obj3;
          Node.__\u003Cclinit\u003E();
          Node child = new Node(nodeType, this.createName(49, identifier, (Node) null), right1);
          node.addChildToBack(child);
          if (obj1 != -1)
          {
            this.defineSymbol(obj1, identifier, true);
            obj4.add((object) identifier);
          }
        }
        else
          obj3.addChildToBack(this.destructuringAssignmentHelper(obj1, (Node) right4, right1, this.currentScriptOrFn.getNextTempName()));
        num = 0;
      }
      return num != 0;
    }

    [LineNumberTable(new byte[] {174, 137, 103, 159, 17, 108, 110, 116, 140, 105, 233, 73, 104, 108, 110, 104, 108, 174, 103, 167, 101, 228, 70, 139, 132, 171, 103, 103, 202})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Node simpleAssignment(Node left, Node right)
    {
      int type = left.getType();
      switch (type)
      {
        case 33:
        case 36:
          Node left1;
          Node mid;
          switch (left)
          {
            case PropertyGet _:
              left1 = (Node) ((PropertyGet) left).getTarget();
              mid = (Node) ((PropertyGet) left).getProperty();
              break;
            case ElementGet _:
              left1 = (Node) ((ElementGet) left).getTarget();
              mid = (Node) ((ElementGet) left).getElement();
              break;
            default:
              left1 = left.getFirstChild();
              mid = left.getLastChild();
              break;
          }
          int nodeType;
          if (type == 33)
          {
            nodeType = 35;
            mid.setType(41);
          }
          else
            nodeType = 37;
          return new Node(nodeType, left1, mid, right);
        case 39:
          string identifier = ((Name) left).getIdentifier();
          if (this.inUseStrictDirective && (String.instancehelper_equals("eval", (object) identifier) || String.instancehelper_equals("arguments", (object) identifier)))
            this.reportError("msg.bad.id.strict", identifier);
          left.setType(49);
          return new Node(8, left, right);
        case 68:
          Node firstChild = left.getFirstChild();
          this.checkMutableReference(firstChild);
          return new Node(69, firstChild, right);
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) this.codeBug());
      }
    }

    [LineNumberTable(3795)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Node createNumber(double number) => Node.newNumber(number);

    [LineNumberTable(new byte[] {174, 191, 106, 101, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void checkMutableReference(Node n)
    {
      if ((n.getIntProp(16, 0) & 4) == 0)
        return;
      this.reportError("msg.bad.assign.left");
    }

    [LineNumberTable(new byte[] {37, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Parser()
      : this(new CompilerEnvirons())
    {
    }

    [LineNumberTable(new byte[] {108, 104, 159, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void addError([In] string obj0, [In] int obj1)
    {
      string str = Character.toString((char) obj1);
      this.addError(obj0, str, this.ts.tokenBeg, this.ts.tokenEnd - this.ts.tokenBeg);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Obsolete]
    [LineNumberTable(new byte[] {161, 133, 120, 109, 175, 103, 111, 139, 103, 35, 2})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AstRoot parse(Reader sourceReader, string sourceURI, int lineno)
    {
      if (this.parseFinished)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException("parser reused");
      }
      if (this.compilerEnv.isIdeMode())
        return this.parse(Kit.readReader(sourceReader), sourceURI, lineno);
      try
      {
        this.sourceURI = sourceURI;
        this.ts = new TokenStream(this, sourceReader, (string) null, lineno);
        return this.parse();
      }
      finally
      {
        this.parseFinished = true;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool inUseStrictDirective() => this.inUseStrictDirective;

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Map access\u0024200([In] Parser obj0) => obj0.labelSet;

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Map access\u0024202([In] Parser obj0, [In] Map obj1)
    {
      Parser parser1 = obj0;
      Map map1 = obj1;
      Parser parser2 = parser1;
      Map map2 = map1;
      parser2.labelSet = map1;
      return map2;
    }

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static List access\u0024300([In] Parser obj0) => obj0.loopSet;

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static List access\u0024302([In] Parser obj0, [In] List obj1)
    {
      Parser parser1 = obj0;
      List list1 = obj1;
      Parser parser2 = parser1;
      List list2 = list1;
      parser2.loopSet = list1;
      return list2;
    }

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static List access\u0024400([In] Parser obj0) => obj0.loopAndSwitchSet;

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static List access\u0024402([In] Parser obj0, [In] List obj1)
    {
      Parser parser1 = obj0;
      List list1 = obj1;
      Parser parser2 = parser1;
      List list2 = list1;
      parser2.loopAndSwitchSet = list1;
      return list2;
    }

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024500([In] Parser obj0) => obj0.endFlags;

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024502([In] Parser obj0, [In] int obj1)
    {
      Parser parser1 = obj0;
      int num1 = obj1;
      Parser parser2 = parser1;
      int num2 = num1;
      parser2.endFlags = num1;
      return num2;
    }

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool access\u0024600([In] Parser obj0) => obj0.inForInit;

    [Modifiers]
    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool access\u0024602([In] Parser obj0, [In] bool obj1)
    {
      int num1 = obj1 ? 1 : 0;
      Parser parser1 = obj0;
      int num2 = num1;
      Parser parser2 = parser1;
      int num3 = num2;
      parser2.inForInit = num2 != 0;
      return num3 != 0;
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
    internal class ConditionData : Object
    {
      internal AstNode condition;
      internal int lp;
      internal int rp;

      [Modifiers]
      [LineNumberTable(989)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ConditionData([In] Parser.\u0031 obj0)
        : this()
      {
      }

      [LineNumberTable(new byte[] {163, 107, 136, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ConditionData()
      {
        Parser.ConditionData conditionData = this;
        this.lp = -1;
        this.rp = -1;
      }
    }

    [InnerClass]
    internal class ParserException : RuntimeException
    {
      [Modifiers]
      [LineNumberTable(83)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ParserException([In] Parser.\u0031 obj0)
        : this()
      {
      }

      [LineNumberTable(83)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ParserException()
      {
      }
    }

    [InnerClass]
    public class PerFunctionVariables : Object
    {
      [Modifiers]
      private ScriptNode savedCurrentScriptOrFn;
      [Modifiers]
      private Scope savedCurrentScope;
      [Modifiers]
      private int savedEndFlags;
      [Modifiers]
      private bool savedInForInit;
      [Modifiers]
      [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/ast/LabeledStatement;>;")]
      private Map savedLabelSet;
      [Modifiers]
      [Signature("Ljava/util/List<Lrhino/ast/Loop;>;")]
      private List savedLoopSet;
      [Modifiers]
      [Signature("Ljava/util/List<Lrhino/ast/Jump;>;")]
      private List savedLoopAndSwitchSet;
      [Modifiers]
      internal Parser this\u00240;

      [LineNumberTable(new byte[] {173, 143, 111, 108, 135, 108, 135, 108, 136, 108, 136, 108, 136, 108, 136, 108, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal PerFunctionVariables([In] Parser obj0, [In] FunctionNode obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Parser.PerFunctionVariables functionVariables = this;
        this.savedCurrentScriptOrFn = obj0.currentScriptOrFn;
        obj0.currentScriptOrFn = (ScriptNode) obj1;
        this.savedCurrentScope = obj0.currentScope;
        obj0.currentScope = (Scope) obj1;
        this.savedLabelSet = Parser.access\u0024200(obj0);
        Parser.access\u0024202(obj0, (Map) null);
        this.savedLoopSet = Parser.access\u0024300(obj0);
        Parser.access\u0024302(obj0, (List) null);
        this.savedLoopAndSwitchSet = Parser.access\u0024400(obj0);
        Parser.access\u0024402(obj0, (List) null);
        this.savedEndFlags = Parser.access\u0024500(obj0);
        Parser.access\u0024502(obj0, 0);
        this.savedInForInit = Parser.access\u0024600(obj0);
        Parser.access\u0024602(obj0, false);
      }

      [LineNumberTable(new byte[] {173, 167, 113, 113, 114, 114, 114, 114, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void restore()
      {
        this.this\u00240.currentScriptOrFn = this.savedCurrentScriptOrFn;
        this.this\u00240.currentScope = this.savedCurrentScope;
        Parser.access\u0024202(this.this\u00240, this.savedLabelSet);
        Parser.access\u0024302(this.this\u00240, this.savedLoopSet);
        Parser.access\u0024402(this.this\u00240, this.savedLoopAndSwitchSet);
        Parser.access\u0024502(this.this\u00240, this.savedEndFlags);
        Parser.access\u0024602(this.this\u00240, this.savedInForInit);
      }
    }
  }
}
