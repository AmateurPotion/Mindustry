// Decompiled with JetBrains decompiler
// Type: rhino.FieldAndMethods
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.lang.reflect;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [SourceFile("JavaMembers.java")]
  internal class FieldAndMethods : NativeJavaMethod
  {
    internal Field field;
    internal object javaObject;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {162, 210, 105, 103, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal FieldAndMethods([In] Scriptable obj0, [In] MemberBox[] obj1, [In] Field obj2)
      : base(obj1)
    {
      FieldAndMethods fieldAndMethods = this;
      this.field = obj2;
      this.setParentScope(obj0);
      this.setPrototype(ScriptableObject.getFunctionPrototype(obj0));
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {162, 218, 207, 119, 215, 226, 61, 97, 107, 37, 171, 102, 112, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object getDefaultValue([In] Class obj0)
    {
      if (object.ReferenceEquals((object) obj0, (object) ScriptRuntime.__\u003C\u003EFunctionClass))
        return (object) this;
      object obj1;
      Class type;
      try
      {
        obj1 = this.field.get(this.javaObject, FieldAndMethods.__\u003CGetCallerID\u003E());
        type = this.field.getType();
        goto label_5;
      }
      catch (IllegalAccessException ex)
      {
      }
      throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.java.internal.private", (object) this.field.getName()));
label_5:
      Context context = Context.getContext();
      object obj2 = context.getWrapFactory().wrap(context, (Scriptable) this, obj1, type);
      if (obj2 is Scriptable)
        obj2 = ((Scriptable) obj2).getDefaultValue(obj0);
      return obj2;
    }

    new static CallerID __\u003CGetCallerID\u003E()
    {
      if (FieldAndMethods.__\u003CcallerID\u003E == null)
        FieldAndMethods.__\u003CcallerID\u003E = (CallerID) new FieldAndMethods.__\u003CCallerID\u003E();
      return FieldAndMethods.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    static FieldAndMethods() => NativeJavaMethod.__\u003Cclinit\u003E();

    private new sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
