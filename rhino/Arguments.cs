// Decompiled with JetBrains decompiler
// Type: rhino.Arguments
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
  internal sealed class Arguments : IdScriptableObject
  {
    private const string FTAG = "Arguments";
    private const int Id_callee = 1;
    private const int Id_length = 2;
    private const int Id_caller = 3;
    private const int MAX_INSTANCE_ID = 3;
    [Modifiers]
    private static BaseFunction iteratorMethod;
    private object callerObj;
    private object calleeObj;
    private object lengthObj;
    private int callerAttr;
    private int calleeAttr;
    private int lengthAttr;
    [Modifiers]
    private NativeCall activation;
    private object[] args;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {57, 102, 104, 130, 108, 103, 164, 102, 104, 106, 112, 2, 232, 70, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool sharedWithActivation([In] int obj0)
    {
      if (Context.getContext().isStrictMode())
        return false;
      NativeFunction function = this.activation.function;
      int paramCount = function.getParamCount();
      if (obj0 >= paramCount)
        return false;
      if (obj0 < paramCount - 1)
      {
        string paramOrVarName = function.getParamOrVarName(obj0);
        for (int i = obj0 + 1; i < paramCount; ++i)
        {
          if (String.instancehelper_equals(paramOrVarName, (object) function.getParamOrVarName(i)))
            return false;
        }
      }
      return true;
    }

    [LineNumberTable(new byte[] {2, 114, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void putIntoActivation([In] int obj0, [In] object obj1) => this.activation.put(this.activation.function.getParamOrVarName(obj0), (Scriptable) this.activation, obj1);

    [LineNumberTable(new byte[] {159, 187, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object arg([In] int obj0) => obj0 < 0 || this.args.Length <= obj0 ? Scriptable.NOT_FOUND : this.args[obj0];

    [LineNumberTable(new byte[] {7, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getFromActivation([In] int obj0) => this.activation.get(this.activation.function.getParamOrVarName(obj0), (Scriptable) this.activation);

    [LineNumberTable(new byte[] {12, 105, 136, 104, 120, 150, 105, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void replaceArg([In] int obj0, [In] object obj1)
    {
      if (this.sharedWithActivation(obj0))
        this.putIntoActivation(obj0, obj1);
      lock (this)
      {
        if (object.ReferenceEquals((object) this.args, (object) this.activation.originalArgs))
          this.args = (object[]) this.args.Clone();
        this.args[obj0] = obj1;
      }
    }

    [LineNumberTable(new byte[] {24, 104, 116, 120, 150, 141, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void removeArg([In] int obj0)
    {
      lock (this)
      {
        if (object.ReferenceEquals(this.args[obj0], Scriptable.NOT_FOUND))
          return;
        if (object.ReferenceEquals((object) this.args, (object) this.activation.originalArgs))
          this.args = (object[]) this.args.Clone();
        this.args[obj0] = Scriptable.NOT_FOUND;
      }
    }

    [LineNumberTable(new byte[] {159, 157, 232, 161, 174, 103, 103, 231, 158, 81, 135, 103, 103, 140, 108, 146, 103, 135, 103, 144, 137, 171, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Arguments([In] NativeCall obj0)
    {
      Arguments arguments = this;
      this.callerAttr = 2;
      this.calleeAttr = 2;
      this.lengthAttr = 2;
      this.activation = obj0;
      Scriptable parentScope = obj0.getParentScope();
      this.setParentScope(parentScope);
      this.setPrototype(ScriptableObject.getObjectPrototype(parentScope));
      this.args = obj0.originalArgs;
      this.lengthObj = (object) Integer.valueOf(this.args.Length);
      NativeFunction function = obj0.function;
      this.calleeObj = (object) function;
      int languageVersion = function.getLanguageVersion();
      this.callerObj = languageVersion > 130 || languageVersion == 200 ? Scriptable.NOT_FOUND : (object) null;
      this.defineProperty((Symbol) SymbolKey.__\u003C\u003EITERATOR, (object) Arguments.iteratorMethod, 2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => nameof (Arguments);

    [LineNumberTable(new byte[] {38, 115, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has([In] int obj0, [In] Scriptable obj1) => !object.ReferenceEquals(this.arg(obj0), Scriptable.NOT_FOUND) || base.has(obj0, obj1);

    [LineNumberTable(new byte[] {46, 104, 109, 137, 105, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get([In] int obj0, [In] Scriptable obj1)
    {
      object objA = this.arg(obj0);
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        return base.get(obj0, obj1);
      return this.sharedWithActivation(obj0) ? this.getFromActivation(obj0) : objA;
    }

    [LineNumberTable(new byte[] {81, 115, 139, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put([In] int obj0, [In] Scriptable obj1, [In] object obj2)
    {
      if (object.ReferenceEquals(this.arg(obj0), Scriptable.NOT_FOUND))
        base.put(obj0, obj1, obj2);
      else
        this.replaceArg(obj0, obj2);
    }

    [LineNumberTable(new byte[] {90, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put([In] string obj0, [In] Scriptable obj1, [In] object obj2) => base.put(obj0, obj1, obj2);

    [LineNumberTable(new byte[] {95, 110, 135, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void delete([In] int obj0)
    {
      if (0 <= obj0 && obj0 < this.args.Length)
        this.removeArg(obj0);
      base.delete(obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getMaxInstanceId() => 3;

    [LineNumberTable(new byte[] {121, 98, 130, 103, 100, 104, 101, 102, 100, 101, 102, 100, 101, 102, 162, 183, 103, 105, 104, 232, 69, 171, 150, 103, 130, 103, 130, 103, 130, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo([In] string obj0)
    {
      int id = 0;
      string str = (string) null;
      if (String.instancehelper_length(obj0) == 6)
      {
        switch (String.instancehelper_charAt(obj0, 5))
        {
          case 'e':
            str = "callee";
            id = 1;
            break;
          case 'h':
            str = "length";
            id = 2;
            break;
          case 'r':
            str = "caller";
            id = 3;
            break;
        }
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) obj0) && !String.instancehelper_equals(str, (object) obj0))
        id = 0;
      if (Context.getContext().isStrictMode() && (id == 1 || id == 3))
        return base.findInstanceIdInfo(obj0);
      int attributes;
      switch (id)
      {
        case 0:
          return base.findInstanceIdInfo(obj0);
        case 1:
          attributes = this.calleeAttr;
          break;
        case 2:
          attributes = this.lengthAttr;
          break;
        case 3:
          attributes = this.callerAttr;
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
      }
      return IdScriptableObject.instanceIdInfo(attributes, id);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getInstanceIdName([In] int obj0)
    {
      switch (obj0)
      {
        case 1:
          return "callee";
        case 2:
          return "length";
        case 3:
          return "caller";
        default:
          return (string) null;
      }
    }

    [LineNumberTable(new byte[] {160, 121, 150, 135, 135, 103, 109, 100, 99, 108, 99, 173, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue([In] int obj0)
    {
      switch (obj0)
      {
        case 1:
          return this.calleeObj;
        case 2:
          return this.lengthObj;
        case 3:
          object objA = this.callerObj;
          if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003ENULL_VALUE))
            objA = (object) null;
          else if (objA == null)
          {
            NativeCall parentActivationCall = this.activation.parentActivationCall;
            if (parentActivationCall != null)
              objA = parentActivationCall.get("arguments", (Scriptable) parentActivationCall);
          }
          return objA;
        default:
          return base.getInstanceIdValue(obj0);
      }
    }

    [LineNumberTable(new byte[] {160, 144, 150, 103, 129, 103, 129, 113, 129, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdValue([In] int obj0, [In] object obj1)
    {
      switch (obj0)
      {
        case 1:
          this.calleeObj = obj1;
          break;
        case 2:
          this.lengthObj = obj1;
          break;
        case 3:
          this.callerObj = obj1 == null ? (object) UniqueTag.__\u003C\u003ENULL_VALUE : (object) (UniqueTag) obj1;
          break;
        default:
          base.setInstanceIdValue(obj0, obj1);
          break;
      }
    }

    [LineNumberTable(new byte[] {160, 160, 150, 103, 129, 103, 129, 103, 129, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setInstanceIdAttributes([In] int obj0, [In] int obj1)
    {
      switch (obj0)
      {
        case 1:
          this.calleeAttr = obj1;
          break;
        case 2:
          this.lengthAttr = obj1;
          break;
        case 3:
          this.callerAttr = obj1;
          break;
        default:
          base.setInstanceIdAttributes(obj0, obj1);
          break;
      }
    }

    [LineNumberTable(new byte[] {159, 70, 132, 105, 108, 109, 105, 105, 102, 105, 110, 112, 102, 101, 230, 57, 235, 76, 99, 105, 113, 101, 230, 61, 232, 71, 103, 108, 109, 99, 99, 110, 102, 107, 230, 61, 232, 70, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal override object[] getIds([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      object[] objArray1 = base.getIds(num1 != 0, num2 != 0);
      if (this.args.Length != 0)
      {
        bool[] flagArray = new bool[this.args.Length];
        int length = this.args.Length;
        for (int index1 = 0; index1 != objArray1.Length; ++index1)
        {
          object obj = objArray1[index1];
          if (obj is Integer)
          {
            int index2 = ((Integer) obj).intValue();
            if (0 <= index2 && index2 < this.args.Length && !flagArray[index2])
            {
              flagArray[index2] = true;
              length += -1;
            }
          }
        }
        if (num1 == 0)
        {
          for (int index = 0; index < flagArray.Length; ++index)
          {
            if (!flagArray[index] && base.has(index, (Scriptable) this))
            {
              flagArray[index] = true;
              length += -1;
            }
          }
        }
        if (length != 0)
        {
          object[] objArray2 = new object[length + objArray1.Length];
          ByteCodeHelper.arraycopy((object) objArray1, 0, (object) objArray2, length, objArray1.Length);
          objArray1 = objArray2;
          int index1 = 0;
          for (int index2 = 0; index2 != this.args.Length; ++index2)
          {
            if (!flagArray[index2])
            {
              objArray1[index1] = (object) Integer.valueOf(index2);
              ++index1;
            }
          }
          if (index1 != length)
            Kit.codeBug();
        }
      }
      return objArray1;
    }

    [LineNumberTable(new byte[] {160, 219, 112, 169, 105, 103, 101, 137, 104, 109, 137, 105, 136, 106, 105, 109, 130, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override ScriptableObject getOwnPropertyDescriptor(
      [In] Context obj0,
      [In] object obj1)
    {
      if (ScriptRuntime.isSymbol(obj1) || obj1 is Scriptable)
        return base.getOwnPropertyDescriptor(obj0, obj1);
      double number = ScriptRuntime.toNumber(obj1);
      int index = ByteCodeHelper.d2i(number);
      if (number != (double) index)
        return base.getOwnPropertyDescriptor(obj0, obj1);
      object objA = this.arg(index);
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        return base.getOwnPropertyDescriptor(obj0, obj1);
      if (this.sharedWithActivation(index))
        objA = this.getFromActivation(index);
      if (base.has(index, (Scriptable) this))
      {
        ScriptableObject propertyDescriptor = base.getOwnPropertyDescriptor(obj0, obj1);
        propertyDescriptor.put("value", (Scriptable) propertyDescriptor, objA);
        return propertyDescriptor;
      }
      object obj2 = (object) this.getParentScope();
      if ((Scriptable) obj2 == null)
        obj2 = (object) this;
      object obj3 = obj2;
      object obj4 = objA;
      int num = 0;
      object obj5 = obj4;
      Scriptable scope;
      if (obj3 != null)
        scope = obj3 is Scriptable scriptable2 ? scriptable2 : throw new IncompatibleClassChangeError();
      else
        scope = (Scriptable) null;
      object obj6 = obj5;
      int attributes = num;
      return ScriptableObject.buildDataDescriptor(scope, obj6, attributes);
    }

    [LineNumberTable(new byte[] {159, 52, 163, 106, 104, 161, 105, 103, 134, 104, 142, 105, 103, 161, 109, 143, 137, 114, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void defineOwnProperty(
      [In] Context obj0,
      [In] object obj1,
      [In] ScriptableObject obj2,
      [In] bool obj3)
    {
      int num1 = obj3 ? 1 : 0;
      base.defineOwnProperty(obj0, obj1, obj2, num1 != 0);
      if (ScriptRuntime.isSymbol(obj1))
        return;
      double number = ScriptRuntime.toNumber(obj1);
      int num2 = ByteCodeHelper.d2i(number);
      if (number != (double) num2 || object.ReferenceEquals(this.arg(num2), Scriptable.NOT_FOUND))
        return;
      if (this.isAccessorDescriptor(obj2))
      {
        this.removeArg(num2);
      }
      else
      {
        object property = ScriptableObject.getProperty((Scriptable) obj2, "value");
        if (object.ReferenceEquals(property, Scriptable.NOT_FOUND))
          return;
        this.replaceArg(num2, property);
        if (!ScriptableObject.isFalse(ScriptableObject.getProperty((Scriptable) obj2, "writable")))
          return;
        this.removeArg(num2);
      }
    }

    [LineNumberTable(new byte[] {161, 27, 102, 104, 129, 119, 119, 119, 119, 108, 108, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void defineAttributesForStrictMode()
    {
      if (!Context.getContext().isStrictMode())
        return;
      this.setGetterOrSetter("caller", 0, (Callable) new Arguments.ThrowTypeError("caller"), true);
      this.setGetterOrSetter("caller", 0, (Callable) new Arguments.ThrowTypeError("caller"), false);
      this.setGetterOrSetter("callee", 0, (Callable) new Arguments.ThrowTypeError("callee"), true);
      this.setGetterOrSetter("callee", 0, (Callable) new Arguments.ThrowTypeError("callee"), false);
      this.setAttributes("caller", 6);
      this.setAttributes("callee", 6);
      this.callerObj = (object) null;
      this.calleeObj = (object) null;
    }

    [LineNumberTable(411)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Arguments()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.Arguments"))
        return;
      Arguments.iteratorMethod = (BaseFunction) new Arguments.\u0031();
    }

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal sealed class \u0031 : BaseFunction
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(411)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
      }

      [LineNumberTable(419)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object call([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3)
      {
        NativeArrayIterator.__\u003Cclinit\u003E();
        return (object) new NativeArrayIterator(obj1, obj2, NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EVALUES);
      }

      [HideFromJava]
      static \u0031() => BaseFunction.__\u003Cclinit\u003E();
    }

    [InnerClass]
    internal class ThrowTypeError : BaseFunction
    {
      [Modifiers]
      private string propertyName;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {161, 56, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ThrowTypeError([In] string obj0)
      {
        Arguments.ThrowTypeError throwTypeError = this;
        this.propertyName = obj0;
      }

      [LineNumberTable(432)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object call([In] Context obj0, [In] Scriptable obj1, [In] Scriptable obj2, [In] object[] obj3) => throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.arguments.not.access.strict", (object) this.propertyName));

      [HideFromJava]
      static ThrowTypeError() => BaseFunction.__\u003Cclinit\u003E();
    }
  }
}
