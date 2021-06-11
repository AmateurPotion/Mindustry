// Decompiled with JetBrains decompiler
// Type: rhino.WrapFactory
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class WrapFactory : Object
  {
    private bool javaPrimitiveWrap;

    [LineNumberTable(new byte[] {159, 106, 130, 102, 107, 133, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void setJavaPrimitiveWrap(bool value)
    {
      int num = value ? 1 : 0;
      Context currentContext = Context.getCurrentContext();
      if (currentContext != null && currentContext.isSealed())
        Context.onSealedMutation();
      this.javaPrimitiveWrap = num != 0;
    }

    [Signature("(Lrhino/Context;Lrhino/Scriptable;Ljava/lang/Object;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {159, 180, 152, 130, 109, 110, 102, 110, 113, 130, 104, 255, 25, 71, 98, 104, 177, 103, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object wrap(Context cx, Scriptable scope, object obj, Class staticType)
    {
      if (obj == null || object.ReferenceEquals(obj, Undefined.__\u003C\u003Einstance) || obj is Scriptable)
        return obj;
      if (staticType != null && staticType.isPrimitive())
      {
        if (object.ReferenceEquals((object) staticType, (object) Void.TYPE))
          return Undefined.__\u003C\u003Einstance;
        return object.ReferenceEquals((object) staticType, (object) Character.TYPE) ? (object) Integer.valueOf((int) ((Character) obj).charValue()) : obj;
      }
      if (!this.isJavaPrimitiveWrap())
      {
        switch (obj)
        {
          case string _:
          case Boolean _:
          case Integer _:
          case Short _:
          case Long _:
          case Float _:
          case Double _:
            return obj;
          case Character _:
            return (object) String.valueOf(((Character) obj).charValue());
        }
      }
      return Object.instancehelper_getClass(obj).isArray() ? (object) NativeJavaArray.wrap(scope, obj) : (object) this.wrapAsJavaObject(cx, scope, obj, staticType);
    }

    [LineNumberTable(new byte[] {159, 158, 232, 160, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WrapFactory()
    {
      WrapFactory wrapFactory = this;
      this.javaPrimitiveWrap = true;
    }

    [Signature("(Lrhino/Context;Lrhino/Scriptable;Ljava/lang/Object;Ljava/lang/Class<*>;)Lrhino/Scriptable;")]
    [LineNumberTable(107)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable wrapAsJavaObject(
      Context cx,
      Scriptable scope,
      object javaObject,
      Class staticType)
    {
      return (Scriptable) new NativeJavaObject(scope, javaObject, staticType);
    }

    [Signature("(Lrhino/Context;Lrhino/Scriptable;Ljava/lang/Class<*>;)Lrhino/Scriptable;")]
    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable wrapJavaClass(
      Context cx,
      Scriptable scope,
      Class javaClass)
    {
      return (Scriptable) new NativeJavaClass(scope, javaClass);
    }

    [LineNumberTable(new byte[] {27, 104, 135, 103, 104, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Scriptable wrapNewObject(Context cx, Scriptable scope, object obj)
    {
      if (obj is Scriptable)
        return (Scriptable) obj;
      return Object.instancehelper_getClass(obj).isArray() ? (Scriptable) NativeJavaArray.wrap(scope, obj) : this.wrapAsJavaObject(cx, scope, obj, (Class) null);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isJavaPrimitiveWrap() => this.javaPrimitiveWrap;
  }
}
