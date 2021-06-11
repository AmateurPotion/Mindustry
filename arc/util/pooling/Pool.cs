// Decompiled with JetBrains decompiler
// Type: arc.util.pooling.Pool
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.pooling
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public abstract class Pool : Object
  {
    internal int __\u003C\u003Emax;
    [Modifiers]
    [Signature("Larc/struct/Seq<TT;>;")]
    private Seq freeObjects;
    public int peak;

    [Signature("()TT;")]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object obtain() => this.freeObjects.size == 0 ? this.newObject() : this.freeObjects.pop();

    [Signature("(Larc/struct/Seq<TT;>;)V")]
    [LineNumberTable(new byte[] {23, 115, 103, 103, 107, 104, 101, 112, 231, 60, 230, 70, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void freeAll(Seq objects)
    {
      if (objects == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("objects cannot be null.");
      }
      Seq freeObjects = this.freeObjects;
      int max = this.__\u003C\u003Emax;
      for (int index = 0; index < objects.size; ++index)
      {
        object @object = objects.get(index);
        if (@object != null)
        {
          if (freeObjects.size < max)
            freeObjects.add(@object);
          this.reset(@object);
        }
      }
      this.peak = Math.max(this.peak, freeObjects.size);
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {0, 115, 115, 108, 156, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void free(object @object)
    {
      if (@object == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("object cannot be null.");
      }
      if (this.freeObjects.size < this.__\u003C\u003Emax)
      {
        this.freeObjects.add(@object);
        this.peak = Math.max(this.peak, this.freeObjects.size);
      }
      this.reset(@object);
    }

    [LineNumberTable(new byte[] {159, 170, 104, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pool(int initialCapacity, int max)
    {
      Pool pool = this;
      this.freeObjects = new Seq(false, initialCapacity);
      this.__\u003C\u003Emax = max;
    }

    [Signature("()TT;")]
    protected internal abstract object newObject();

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {13, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void reset(object @object)
    {
      if (!(@object is Pool.Poolable))
        return;
      ((Pool.Poolable) @object).reset();
    }

    [LineNumberTable(new byte[] {159, 161, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pool()
      : this(16, int.MaxValue)
    {
    }

    [LineNumberTable(new byte[] {159, 166, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pool(int initialCapacity)
      : this(initialCapacity, int.MaxValue)
    {
    }

    [LineNumberTable(new byte[] {37, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.freeObjects.clear();

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFree() => this.freeObjects.size;

    [Modifiers]
    public int max
    {
      [HideFromJava] get => this.__\u003C\u003Emax;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emax = value;
    }

    public interface Poolable
    {
      void reset();
    }
  }
}
