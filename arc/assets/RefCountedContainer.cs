// Decompiled with JetBrains decompiler
// Type: arc.assets.RefCountedContainer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.assets
{
  public class RefCountedContainer : Object
  {
    internal object @object;
    internal int refCount;

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;)TT;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getObject(Class type) => this.@object;

    [LineNumberTable(new byte[] {159, 159, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void decRefCount() => --this.refCount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRefCount() => this.refCount;

    [LineNumberTable(new byte[] {159, 155, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void incRefCount() => ++this.refCount;

    [LineNumberTable(new byte[] {159, 149, 8, 167, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RefCountedContainer(object @object)
    {
      RefCountedContainer countedContainer = this;
      this.refCount = 1;
      if (@object == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Object must not be null");
      }
      this.@object = @object;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRefCount(int refCount) => this.refCount = refCount;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setObject(object asset) => this.@object = asset;
  }
}
