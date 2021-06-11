// Decompiled with JetBrains decompiler
// Type: rhino.TopLevel
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

namespace rhino
{
  public class TopLevel : IdScriptableObject
  {
    [Signature("Ljava/util/EnumMap<Lrhino/TopLevel$Builtins;Lrhino/BaseFunction;>;")]
    private EnumMap ctors;
    [Signature("Ljava/util/EnumMap<Lrhino/TopLevel$NativeErrors;Lrhino/BaseFunction;>;")]
    private EnumMap errors;
    [Modifiers]
    internal new static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {160, 77, 122, 104, 103, 102, 99, 226, 69, 205, 136, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Scriptable getBuiltinPrototype(Scriptable scope, TopLevel.Builtins type)
    {
      if (!TopLevel.\u0024assertionsDisabled && scope.getParentScope() != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (scope is TopLevel)
      {
        Scriptable builtinPrototype = ((TopLevel) scope).getBuiltinPrototype(type);
        if (builtinPrototype != null)
          return builtinPrototype;
      }
      string className = !object.ReferenceEquals((object) type, (object) TopLevel.Builtins.__\u003C\u003EGeneratorFunction) ? type.name() : "__GeneratorFunction";
      return ScriptableObject.getClassPrototype(scope, className);
    }

    [LineNumberTable(220)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseFunction getBuiltinCtor(TopLevel.Builtins type) => this.ctors != null ? (BaseFunction) this.ctors.get((object) type) : (BaseFunction) null;

    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual BaseFunction getNativeErrorCtor([In] TopLevel.NativeErrors obj0) => this.errors != null ? (BaseFunction) this.errors.get((object) obj0) : (BaseFunction) null;

    [LineNumberTable(new byte[] {160, 128, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable getBuiltinPrototype(TopLevel.Builtins type)
    {
      BaseFunction builtinCtor = this.getBuiltinCtor(type);
      object obj = builtinCtor == null ? (object) null : builtinCtor.getPrototypeProperty();
      return obj is Scriptable ? (Scriptable) obj : (Scriptable) null;
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TopLevel()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "global";

    [LineNumberTable(new byte[] {159, 117, 98, 117, 119, 111, 105, 119, 174, 250, 57, 233, 74, 117, 119, 111, 105, 245, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cacheBuiltins(Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      EnumMap.__\u003Cclinit\u003E();
      this.ctors = new EnumMap((Class) ClassLiteral<TopLevel.Builtins>.Value);
      TopLevel.Builtins[] builtinsArray = TopLevel.Builtins.values();
      int length1 = builtinsArray.Length;
      for (int index = 0; index < length1; ++index)
      {
        TopLevel.Builtins builtins = builtinsArray[index];
        object property = ScriptableObject.getProperty((Scriptable) this, builtins.name());
        if (property is BaseFunction)
          this.ctors.put((Enum) builtins, (object) (BaseFunction) property);
        else if (object.ReferenceEquals((object) builtins, (object) TopLevel.Builtins.__\u003C\u003EGeneratorFunction))
          this.ctors.put((Enum) builtins, (object) (BaseFunction) BaseFunction.initAsGeneratorFunction(scope, num != 0));
      }
      EnumMap.__\u003Cclinit\u003E();
      this.errors = new EnumMap((Class) ClassLiteral<TopLevel.NativeErrors>.Value);
      TopLevel.NativeErrors[] nativeErrorsArray = TopLevel.NativeErrors.values();
      int length2 = nativeErrorsArray.Length;
      for (int index = 0; index < length2; ++index)
      {
        TopLevel.NativeErrors nativeErrors = nativeErrorsArray[index];
        object property = ScriptableObject.getProperty((Scriptable) this, nativeErrors.name());
        if (property is BaseFunction)
          this.errors.put((Enum) nativeErrors, (object) (BaseFunction) property);
      }
    }

    [LineNumberTable(new byte[] {85, 122, 104, 109, 99, 226, 69, 205, 136, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Function getBuiltinCtor(
      Context cx,
      Scriptable scope,
      TopLevel.Builtins type)
    {
      if (!TopLevel.\u0024assertionsDisabled && scope.getParentScope() != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (scope is TopLevel)
      {
        BaseFunction builtinCtor = ((TopLevel) scope).getBuiltinCtor(type);
        if (builtinCtor != null)
          return (Function) builtinCtor;
      }
      string str = !object.ReferenceEquals((object) type, (object) TopLevel.Builtins.__\u003C\u003EGeneratorFunction) ? type.name() : "__GeneratorFunction";
      return ScriptRuntime.getExistingCtor(cx, scope, str);
    }

    [LineNumberTable(new byte[] {118, 122, 104, 109, 99, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Function getNativeErrorCtor(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] TopLevel.NativeErrors obj2)
    {
      if (!TopLevel.\u0024assertionsDisabled && obj1.getParentScope() != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      if (obj1 is TopLevel)
      {
        BaseFunction nativeErrorCtor = ((TopLevel) obj1).getNativeErrorCtor(obj2);
        if (nativeErrorCtor != null)
          return (Function) nativeErrorCtor;
      }
      return ScriptRuntime.getExistingCtor(obj0, obj1, obj2.name());
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TopLevel()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.TopLevel"))
        return;
      TopLevel.\u0024assertionsDisabled = !((Class) ClassLiteral<TopLevel>.Value).desiredAssertionStatus();
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lrhino/TopLevel$Builtins;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Builtins : Enum
    {
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003EObject;
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003EArray;
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003EFunction;
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003EString;
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003ENumber;
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003EBoolean;
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003ERegExp;
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003EError;
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003ESymbol;
      [Modifiers]
      internal static TopLevel.Builtins __\u003C\u003EGeneratorFunction;
      [Modifiers]
      private static TopLevel.Builtins[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(37)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static TopLevel.Builtins[] values() => (TopLevel.Builtins[]) TopLevel.Builtins.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(37)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Builtins([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(37)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static TopLevel.Builtins valueOf(string name) => (TopLevel.Builtins) Enum.valueOf((Class) ClassLiteral<TopLevel.Builtins>.Value, name);

      [LineNumberTable(new byte[] {159, 133, 173, 144, 144, 144, 144, 144, 144, 144, 144, 144, 241, 44})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Builtins()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.TopLevel$Builtins"))
          return;
        TopLevel.Builtins.__\u003C\u003EObject = new TopLevel.Builtins(nameof (Object), 0);
        TopLevel.Builtins.__\u003C\u003EArray = new TopLevel.Builtins(nameof (Array), 1);
        TopLevel.Builtins.__\u003C\u003EFunction = new TopLevel.Builtins(nameof (Function), 2);
        TopLevel.Builtins.__\u003C\u003EString = new TopLevel.Builtins(nameof (String), 3);
        TopLevel.Builtins.__\u003C\u003ENumber = new TopLevel.Builtins(nameof (Number), 4);
        TopLevel.Builtins.__\u003C\u003EBoolean = new TopLevel.Builtins(nameof (Boolean), 5);
        TopLevel.Builtins.__\u003C\u003ERegExp = new TopLevel.Builtins(nameof (RegExp), 6);
        TopLevel.Builtins.__\u003C\u003EError = new TopLevel.Builtins(nameof (Error), 7);
        TopLevel.Builtins.__\u003C\u003ESymbol = new TopLevel.Builtins(nameof (Symbol), 8);
        TopLevel.Builtins.__\u003C\u003EGeneratorFunction = new TopLevel.Builtins(nameof (GeneratorFunction), 9);
        TopLevel.Builtins.\u0024VALUES = new TopLevel.Builtins[10]
        {
          TopLevel.Builtins.__\u003C\u003EObject,
          TopLevel.Builtins.__\u003C\u003EArray,
          TopLevel.Builtins.__\u003C\u003EFunction,
          TopLevel.Builtins.__\u003C\u003EString,
          TopLevel.Builtins.__\u003C\u003ENumber,
          TopLevel.Builtins.__\u003C\u003EBoolean,
          TopLevel.Builtins.__\u003C\u003ERegExp,
          TopLevel.Builtins.__\u003C\u003EError,
          TopLevel.Builtins.__\u003C\u003ESymbol,
          TopLevel.Builtins.__\u003C\u003EGeneratorFunction
        };
      }

      [Modifiers]
      public static TopLevel.Builtins Object
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003EObject;
      }

      [Modifiers]
      public static TopLevel.Builtins Array
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003EArray;
      }

      [Modifiers]
      public static TopLevel.Builtins Function
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003EFunction;
      }

      [Modifiers]
      public static TopLevel.Builtins String
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003EString;
      }

      [Modifiers]
      public static TopLevel.Builtins Number
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003ENumber;
      }

      [Modifiers]
      public static TopLevel.Builtins Boolean
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003EBoolean;
      }

      [Modifiers]
      public static TopLevel.Builtins RegExp
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003ERegExp;
      }

      [Modifiers]
      public static TopLevel.Builtins Error
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003EError;
      }

      [Modifiers]
      public static TopLevel.Builtins Symbol
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003ESymbol;
      }

      [Modifiers]
      public static TopLevel.Builtins GeneratorFunction
      {
        [HideFromJava] get => TopLevel.Builtins.__\u003C\u003EGeneratorFunction;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Object,
        Array,
        Function,
        String,
        Number,
        Boolean,
        RegExp,
        Error,
        Symbol,
        GeneratorFunction,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lrhino/TopLevel$NativeErrors;>;")]
    [Modifiers]
    [Serializable]
    internal sealed class NativeErrors : Enum
    {
      [Modifiers]
      public static TopLevel.NativeErrors Error;
      [Modifiers]
      public static TopLevel.NativeErrors EvalError;
      [Modifiers]
      public static TopLevel.NativeErrors RangeError;
      [Modifiers]
      public static TopLevel.NativeErrors ReferenceError;
      [Modifiers]
      public static TopLevel.NativeErrors SyntaxError;
      [Modifiers]
      public static TopLevel.NativeErrors TypeError;
      [Modifiers]
      public static TopLevel.NativeErrors URIError;
      [Modifiers]
      public static TopLevel.NativeErrors InternalError;
      [Modifiers]
      public static TopLevel.NativeErrors JavaException;
      [Modifiers]
      private static TopLevel.NativeErrors[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(63)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static TopLevel.NativeErrors[] values() => (TopLevel.NativeErrors[]) TopLevel.NativeErrors.\u0024VALUES.Clone();

      [LineNumberTable(63)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static TopLevel.NativeErrors valueOf([In] string obj0) => (TopLevel.NativeErrors) Enum.valueOf((Class) ClassLiteral<TopLevel.NativeErrors>.Value, obj0);

      [Signature("()V")]
      [LineNumberTable(63)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private NativeErrors([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {159, 126, 109, 144, 144, 144, 144, 144, 144, 144, 144, 240, 46})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static NativeErrors()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.TopLevel$NativeErrors"))
          return;
        TopLevel.NativeErrors.Error = new TopLevel.NativeErrors(nameof (Error), 0);
        TopLevel.NativeErrors.EvalError = new TopLevel.NativeErrors(nameof (EvalError), 1);
        TopLevel.NativeErrors.RangeError = new TopLevel.NativeErrors(nameof (RangeError), 2);
        TopLevel.NativeErrors.ReferenceError = new TopLevel.NativeErrors(nameof (ReferenceError), 3);
        TopLevel.NativeErrors.SyntaxError = new TopLevel.NativeErrors(nameof (SyntaxError), 4);
        TopLevel.NativeErrors.TypeError = new TopLevel.NativeErrors(nameof (TypeError), 5);
        TopLevel.NativeErrors.URIError = new TopLevel.NativeErrors(nameof (URIError), 6);
        TopLevel.NativeErrors.InternalError = new TopLevel.NativeErrors(nameof (InternalError), 7);
        TopLevel.NativeErrors.JavaException = new TopLevel.NativeErrors(nameof (JavaException), 8);
        TopLevel.NativeErrors.\u0024VALUES = new TopLevel.NativeErrors[9]
        {
          TopLevel.NativeErrors.Error,
          TopLevel.NativeErrors.EvalError,
          TopLevel.NativeErrors.RangeError,
          TopLevel.NativeErrors.ReferenceError,
          TopLevel.NativeErrors.SyntaxError,
          TopLevel.NativeErrors.TypeError,
          TopLevel.NativeErrors.URIError,
          TopLevel.NativeErrors.InternalError,
          TopLevel.NativeErrors.JavaException
        };
      }
    }
  }
}
