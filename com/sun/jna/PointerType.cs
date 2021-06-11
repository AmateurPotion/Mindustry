// Decompiled with JetBrains decompiler
// Type: com.sun.jna.PointerType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.sun.jna
{
  public abstract class PointerType : Object, NativeMapped
  {
    private Pointer pointer;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer getPointer() => this.pointer;

    [LineNumberTable(new byte[] {159, 177, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal PointerType()
    {
      PointerType pointerType = this;
      this.pointer = Pointer.__\u003C\u003ENULL;
    }

    [LineNumberTable(new byte[] {159, 184, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal PointerType(Pointer p)
    {
      PointerType pointerType = this;
      this.pointer = p;
    }

    [Signature("()Ljava/lang/Class<*>;")]
    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class nativeType() => (Class) ClassLiteral<Pointer>.Value;

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object toNative() => (object) this.getPointer();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPointer(Pointer p) => this.pointer = p;

    [LineNumberTable(new byte[] {28, 99, 162, 118, 108, 149, 97, 159, 11, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromNative(object nativeValue, FromNativeContext context)
    {
      if (nativeValue == null)
        return (object) null;
      PointerType pointerType1;
      try
      {
        try
        {
          PointerType pointerType2 = (PointerType) Object.instancehelper_getClass((object) this).newInstance(PointerType.__\u003CGetCallerID\u003E());
          pointerType2.pointer = (Pointer) nativeValue;
          pointerType1 = pointerType2;
        }
        catch (InstantiationException ex)
        {
          goto label_6;
        }
      }
      catch (IllegalAccessException ex)
      {
        goto label_7;
      }
      return (object) pointerType1;
label_6:
      string str1 = new StringBuilder().append("Can't instantiate ").append((object) Object.instancehelper_getClass((object) this)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str1);
label_7:
      string str2 = new StringBuilder().append("Not allowed to instantiate ").append((object) Object.instancehelper_getClass((object) this)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str2);
    }

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => this.pointer != null ? this.pointer.hashCode() : 0;

    [LineNumberTable(new byte[] {57, 105, 130, 104, 108, 104, 136, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals(o, (object) this))
        return true;
      if (!(o is PointerType))
        return false;
      Pointer pointer = ((PointerType) o).getPointer();
      if (this.pointer != null)
        return this.pointer.equals((object) pointer);
      return pointer == null;
    }

    [LineNumberTable(122)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.pointer == null ? "NULL" : new StringBuilder().append(this.pointer.toString()).append(" (").append(base.toString()).append(")").toString();

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (PointerType.__\u003CcallerID\u003E == null)
        PointerType.__\u003CcallerID\u003E = (CallerID) new PointerType.__\u003CCallerID\u003E();
      return PointerType.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
