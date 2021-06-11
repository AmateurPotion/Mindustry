// Decompiled with JetBrains decompiler
// Type: rhino.BaseFunction
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Function"})]
  public class BaseFunction : IdScriptableObject, Function, Scriptable, Callable
  {
    [Modifiers]
    private static object FUNCTION_TAG;
    private const string FUNCTION_CLASS = "Function";
    internal const string GENERATOR_FUNCTION_CLASS = "__GeneratorFunction";
    private const int Id_length = 1;
    private const int Id_arity = 2;
    private const int Id_name = 3;
    private const int Id_prototype = 4;
    private const int Id_arguments = 5;
    private const int MAX_INSTANCE_ID = 5;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_toSource = 3;
    private const int Id_apply = 4;
    private const int Id_call = 5;
    private const int Id_bind = 6;
    private const int MAX_PROTOTYPE_ID = 6;
    private object prototypeProperty;
    private object argumentsObj;
    private bool isGeneratorFunction;
    private int prototypePropertyAttributes;
    private int argumentsAttributes;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {161, 13, 103, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Scriptable getClassPrototype()
    {
      object prototypeProperty = this.getPrototypeProperty();
      return prototypeProperty is Scriptable ? (Scriptable) prototypeProperty : ScriptableObject.getObjectPrototype((Scriptable) this);
    }

    [LineNumberTable(new byte[] {161, 120, 103, 163, 104, 137, 136, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual object getPrototypeProperty()
    {
      object objA = this.prototypeProperty;
      if (objA == null)
        objA = !(this is NativeFunction) ? Undefined.__\u003C\u003Einstance : this.setupDefaultPrototype();
      else if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003ENULL_VALUE))
        objA = (object) null;
      return objA;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFunctionName() => "";

    [LineNumberTable(new byte[] {159, 175, 232, 162, 121, 107, 231, 69, 103, 231, 157, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseFunction()
    {
      BaseFunction baseFunction = this;
      this.argumentsObj = Scriptable.NOT_FOUND;
      this.isGeneratorFunction = false;
      this.prototypePropertyAttributes = 6;
      this.argumentsAttributes = 6;
    }

    [LineNumberTable(new byte[] {159, 133, 66, 232, 162, 118, 107, 231, 69, 103, 231, 157, 132, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseFunction(bool isGenerator)
    {
      int num = isGenerator ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      BaseFunction baseFunction = this;
      this.argumentsObj = Scriptable.NOT_FOUND;
      this.isGeneratorFunction = false;
      this.prototypePropertyAttributes = 6;
      this.argumentsAttributes = 6;
      this.isGeneratorFunction = num != 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool isGeneratorFunction() => this.isGeneratorFunction;

    [LineNumberTable(486)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool hasPrototypeProperty() => this.prototypeProperty != null || this is NativeFunction;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLength() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getArity() => 0;

    [LineNumberTable(new byte[] {161, 158, 127, 2, 237, 70, 130, 102, 104, 141, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getArguments()
    {
      object objA = !this.defaultHas("arguments") ? this.argumentsObj : this.defaultGet("arguments");
      if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        return objA;
      NativeCall functionActivation = ScriptRuntime.findFunctionActivation(Context.getContext(), (Function) this);
      return functionActivation?.get("arguments", (Scriptable) functionActivation);
    }

    [LineNumberTable(new byte[] {161, 175, 99, 134, 108, 104, 236, 72, 106, 140, 169, 104, 100, 137, 239, 60, 230, 70, 108, 131, 107, 136, 108, 135, 104, 105, 100, 103, 165, 103, 135, 168, 141, 103, 100, 251, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object jsConstructor([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      int length = obj2.Length;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.append("function ");
      if (this.isGeneratorFunction())
        stringBuilder.append("* ");
      if (obj0.getLanguageVersion() != 120)
        stringBuilder.append("anonymous");
      stringBuilder.append('(');
      for (int index = 0; index < length - 1; ++index)
      {
        if (index > 0)
          stringBuilder.append(',');
        stringBuilder.append(ScriptRuntime.toString(obj2[index]));
      }
      stringBuilder.append(") {");
      if (length != 0)
      {
        string str = ScriptRuntime.toString(obj2[length - 1]);
        stringBuilder.append(str);
      }
      stringBuilder.append("\n}");
      string str1 = stringBuilder.toString();
      int[] numArray = new int[1];
      string str2 = Context.getSourcePositionFromStack(numArray);
      if (str2 == null)
      {
        str2 = "<eval'ed string>";
        numArray[0] = 1;
      }
      string str3 = ScriptRuntime.makeUrlForGeneratedScript(false, str2, numArray[0]);
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(obj1);
      ErrorReporter errorReporter = DefaultErrorReporter.forEval(obj0.getErrorReporter());
      Evaluator interpreter = Context.createInterpreter();
      if (interpreter == null)
      {
        JavaScriptException.__\u003Cclinit\u003E();
        string sourceName = str2;
        int lineNumber = numArray[0];
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new JavaScriptException((object) "Interpreter not present", sourceName, lineNumber);
      }
      return (object) obj0.compileFunction(topLevelScope, str1, interpreter, errorReporter, str3, 1, (object) null);
    }

    [LineNumberTable(new byte[] {160, 245, 108, 104, 140, 104, 135, 102, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private BaseFunction realFunction([In] Scriptable obj0, [In] IdFunctionObject obj1)
    {
      object obj = obj0.getDefaultValue(ScriptRuntime.__\u003C\u003EFunctionClass);
      if (obj is Delegator)
        obj = (object) ((Delegator) obj).getDelegee();
      return obj is BaseFunction ? (BaseFunction) obj : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.incompat.call", (object) obj1.getFunctionName()));
    }

    [LineNumberTable(new byte[] {161, 87, 102, 106, 99, 108, 109, 140, 108, 109, 108, 99, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual string decompile([In] int obj0, [In] int obj1)
    {
      StringBuilder stringBuilder = new StringBuilder();
      int num = 0 != (obj1 & 1) ? 1 : 0;
      if (num == 0)
      {
        stringBuilder.append("function ");
        stringBuilder.append(this.getFunctionName());
        stringBuilder.append("() {\n\t");
      }
      stringBuilder.append("[native code, arity=");
      stringBuilder.append(this.getArity());
      stringBuilder.append("]\n");
      if (num == 0)
        stringBuilder.append("}\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 74, 102, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable createObject(Context cx, Scriptable scope)
    {
      NativeObject nativeObject = new NativeObject();
      nativeObject.setPrototype(this.getClassPrototype());
      nativeObject.setParentScope(this.getParentScope());
      return (Scriptable) nativeObject;
    }

    [LineNumberTable(396)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args) => Undefined.__\u003C\u003Einstance;

    [LineNumberTable(new byte[] {161, 136, 104, 135, 102, 98, 205, 103, 103, 137, 135})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    private object setupDefaultPrototype()
    {
      if (this.prototypeProperty != null)
        return this.prototypeProperty;
      NativeObject nativeObject = new NativeObject();
      nativeObject.defineProperty("constructor", (object) this, 2);
      this.prototypeProperty = (object) nativeObject;
      Scriptable objectPrototype = ScriptableObject.getObjectPrototype((Scriptable) this);
      if (!object.ReferenceEquals((object) objectPrototype, (object) nativeObject))
        nativeObject.setPrototype(objectPrototype);
      return (object) nativeObject;
    }

    [LineNumberTable(new byte[] {159, 138, 98, 134, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new BaseFunction() { prototypePropertyAttributes = 7 }.exportAsJSClass(6, obj0, num != 0);
    }

    [LineNumberTable(new byte[] {159, 136, 66, 135, 103, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object initAsGeneratorFunction([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new BaseFunction(true) { prototypePropertyAttributes = 5 }.exportAsJSClass(6, obj0, num != 0);
      return ScriptableObject.getProperty(obj0, "__GeneratorFunction");
    }

    [LineNumberTable(new byte[] {159, 183, 234, 162, 113, 107, 231, 69, 103, 231, 157, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BaseFunction(Scriptable scope, Scriptable prototype)
      : base(scope, prototype)
    {
      BaseFunction baseFunction = this;
      this.argumentsObj = Scriptable.NOT_FOUND;
      this.isGeneratorFunction = false;
      this.prototypePropertyAttributes = 6;
      this.argumentsAttributes = 6;
    }

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => this.isGeneratorFunction() ? "__GeneratorFunction" : "Function";

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getTypeOf() => this.avoidObjectDetection() ? "undefined" : "function";

    [LineNumberTable(new byte[] {28, 108, 104, 141, 102, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool hasInstance(Scriptable instance)
    {
      object property = ScriptableObject.getProperty((Scriptable) this, "prototype");
      return property is Scriptable ? ScriptRuntime.jsDelegatesTo(instance, (Scriptable) property) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.instanceof.bad.prototype", (object) this.getFunctionName()));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getMaxInstanceId() => 5;

    [LineNumberTable(new byte[] {58, 98, 162, 159, 8, 102, 98, 130, 102, 98, 130, 102, 98, 130, 104, 101, 102, 100, 101, 102, 194, 247, 69, 171, 222, 98, 162, 104, 130, 103, 130, 103, 130, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo(string s)
    {
      int id = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 4:
          str = "name";
          id = 3;
          break;
        case 5:
          str = "arity";
          id = 2;
          break;
        case 6:
          str = "length";
          id = 1;
          break;
        case 9:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'a':
              str = "arguments";
              id = 5;
              break;
            case 'p':
              str = "prototype";
              id = 4;
              break;
          }
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        id = 0;
      int attributes;
      switch (id)
      {
        case 0:
          return base.findInstanceIdInfo(s);
        case 1:
        case 2:
        case 3:
          attributes = 7;
          break;
        case 4:
          if (!this.hasPrototypeProperty())
            return 0;
          attributes = this.prototypePropertyAttributes;
          break;
        case 5:
          attributes = this.argumentsAttributes;
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
      }
      return IdScriptableObject.instanceIdInfo(attributes, id);
    }

    [LineNumberTable(new byte[] {118, 158, 134, 134, 134, 134, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getInstanceIdName(int id)
    {
      switch (id)
      {
        case 1:
          return "length";
        case 2:
          return "arity";
        case 3:
          return "name";
        case 4:
          return "prototype";
        case 5:
          return "arguments";
        default:
          return base.getInstanceIdName(id);
      }
    }

    [LineNumberTable(new byte[] {160, 71, 158, 140, 140, 135, 135, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue(int id)
    {
      switch (id)
      {
        case 1:
          return (object) ScriptRuntime.wrapInt(this.getLength());
        case 2:
          return (object) ScriptRuntime.wrapInt(this.getArity());
        case 3:
          return (object) this.getFunctionName();
        case 4:
          return this.getPrototypeProperty();
        case 5:
          return this.getArguments();
        default:
          return base.getInstanceIdValue(id);
      }
    }

    [LineNumberTable(new byte[] {160, 88, 158, 106, 177, 129, 141, 134, 109, 110, 106, 135, 193, 129, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdValue(int id, object value)
    {
      switch (id)
      {
        case 1:
          break;
        case 2:
          break;
        case 3:
          break;
        case 4:
          if ((this.prototypePropertyAttributes & 1) != 0)
            break;
          this.prototypeProperty = value == null ? (object) UniqueTag.__\u003C\u003ENULL_VALUE : (object) (UniqueTag) value;
          break;
        case 5:
          if (object.ReferenceEquals(value, Scriptable.NOT_FOUND))
            Kit.codeBug();
          if (this.defaultHas("arguments"))
          {
            this.defaultPut("arguments", value);
            break;
          }
          if ((this.argumentsAttributes & 1) != 0)
            break;
          this.argumentsObj = value;
          break;
        default:
          base.setInstanceIdValue(id, value);
          break;
      }
    }

    [LineNumberTable(new byte[] {160, 116, 146, 103, 129, 103, 129, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdAttributes(int id, int attr)
    {
      switch (id)
      {
        case 4:
          this.prototypePropertyAttributes = attr;
          break;
        case 5:
          this.argumentsAttributes = attr;
          break;
        default:
          base.setInstanceIdAttributes(id, attr);
          break;
      }
    }

    [LineNumberTable(new byte[] {160, 132, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties(IdFunctionObject ctor)
    {
      ctor.setPrototype((Scriptable) this);
      base.fillConstructorProperties(ctor);
    }

    [LineNumberTable(new byte[] {160, 140, 159, 3, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 1;
          name = "constructor";
          break;
        case 2:
          arity = 0;
          name = "toString";
          break;
        case 3:
          arity = 1;
          name = "toSource";
          break;
        case 4:
          arity = 2;
          name = "apply";
          break;
        case 5:
          arity = 1;
          name = "call";
          break;
        case 6:
          arity = 1;
          name = "bind";
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(BaseFunction.FUNCTION_TAG, id, name, arity);
    }

    [LineNumberTable(286)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isApply([In] IdFunctionObject obj0) => obj0.hasTag(BaseFunction.FUNCTION_TAG) && obj0.methodId() == 4;

    [LineNumberTable(new byte[] {160, 176, 109, 183, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isApplyOrCall([In] IdFunctionObject obj0)
    {
      if (obj0.hasTag(BaseFunction.FUNCTION_TAG))
      {
        switch (obj0.methodId())
        {
          case 4:
          case 5:
            return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 189, 109, 142, 103, 159, 6, 171, 106, 105, 201, 106, 98, 98, 101, 106, 100, 132, 162, 233, 69, 208, 105, 141, 105, 164, 100, 109, 106, 144, 99, 135, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(BaseFunction.FUNCTION_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num1 = f.methodId();
      switch (num1)
      {
        case 1:
          return this.jsConstructor(cx, scope, args);
        case 2:
          return (object) this.realFunction(thisObj, f).decompile(ScriptRuntime.toInt32(args, 0), 0);
        case 3:
          BaseFunction baseFunction = this.realFunction(thisObj, f);
          int num2 = 0;
          int num3 = 2;
          if (args.Length != 0)
          {
            num2 = ScriptRuntime.toInt32(args[0]);
            if (num2 >= 0)
              num3 = 0;
            else
              num2 = 0;
          }
          return (object) baseFunction.decompile(num2, num3);
        case 4:
        case 5:
          return ScriptRuntime.applyOrCall(num1 == 4, cx, scope, thisObj, args);
        case 6:
          Callable targetFunction = thisObj is Callable ? (Callable) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError((object) thisObj));
          int length = args.Length;
          Scriptable boundThis;
          object[] boundArgs;
          if (length > 0)
          {
            boundThis = ScriptRuntime.toObjectOrNull(cx, args[0], scope);
            boundArgs = new object[length - 1];
            ByteCodeHelper.arraycopy((object) args, 1, (object) boundArgs, 0, length - 1);
          }
          else
          {
            boundThis = (Scriptable) null;
            boundArgs = ScriptRuntime.__\u003C\u003EemptyArgs;
          }
          return (object) new BoundFunction(cx, scope, targetFunction, boundThis, boundArgs);
        default:
          string str = String.valueOf(num1);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {161, 5, 106, 139, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setImmunePrototypeProperty(object value)
    {
      if ((this.prototypePropertyAttributes & 1) != 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      this.prototypeProperty = value == null ? (object) UniqueTag.__\u003C\u003ENULL_VALUE : (object) (UniqueTag) value;
      this.prototypePropertyAttributes = 7;
    }

    [LineNumberTable(new byte[] {161, 31, 105, 99, 107, 104, 135, 101, 107, 168, 144, 159, 21, 103, 104, 103, 105, 167, 104, 103, 105, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable construct(Context cx, Scriptable scope, object[] args)
    {
      Scriptable thisObj = this.createObject(cx, scope);
      if (thisObj != null)
      {
        object obj = this.call(cx, scope, thisObj, args);
        if (obj is Scriptable)
          thisObj = (Scriptable) obj;
      }
      else
      {
        object obj = this.call(cx, scope, (Scriptable) null, args);
        if (!(obj is Scriptable))
        {
          string str = new StringBuilder().append("Bad implementaion of call as constructor, name=").append(this.getFunctionName()).append(" in ").append(Object.instancehelper_getClass((object) this).getName()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
        }
        thisObj = (Scriptable) obj;
        if (thisObj.getPrototype() == null)
        {
          Scriptable classPrototype = this.getClassPrototype();
          if (!object.ReferenceEquals((object) thisObj, (object) classPrototype))
            thisObj.setPrototype(classPrototype);
        }
        if (thisObj.getParentScope() == null)
        {
          Scriptable parentScope = this.getParentScope();
          if (!object.ReferenceEquals((object) thisObj, (object) parentScope))
            thisObj.setParentScope(parentScope);
        }
      }
      return thisObj;
    }

    [LineNumberTable(new byte[] {161, 243, 98, 162, 159, 19, 104, 101, 102, 103, 101, 102, 196, 102, 98, 130, 104, 101, 102, 100, 101, 102, 196, 102, 162, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 4:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'b':
              str = "bind";
              num = 6;
              break;
            case 'c':
              str = "call";
              num = 5;
              break;
          }
          break;
        case 5:
          str = "apply";
          num = 4;
          break;
        case 8:
          switch (String.instancehelper_charAt(s, 3))
          {
            case 'o':
              str = "toSource";
              num = 3;
              break;
            case 't':
              str = "toString";
              num = 2;
              break;
          }
          break;
        case 11:
          str = "constructor";
          num = 1;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static BaseFunction()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.BaseFunction"))
        return;
      BaseFunction.FUNCTION_TAG = (object) "Function";
    }
  }
}
