// Decompiled with JetBrains decompiler
// Type: rhino.IteratorLikeIterable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using ikvm.lang;
using java.io;
using java.lang;
using java.util;
using java.util.function;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Signature("Ljava/lang/Object;Ljava/lang/Iterable<Ljava/lang/Object;>;Ljava/io/Closeable;")]
  [Implements(new string[] {"java.lang.Iterable", "java.io.Closeable"})]
  public class IteratorLikeIterable : Object, Iterable, IEnumerable, Closeable, AutoCloseable
  {
    [Modifiers]
    private Context cx;
    [Modifiers]
    private Scriptable scope;
    [Modifiers]
    private Callable next;
    [Modifiers]
    private Callable returnFunc;
    [Modifiers]
    private Scriptable iterator;
    private bool closed;

    [Modifiers]
    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Callable access\u0024300([In] IteratorLikeIterable obj0) => obj0.next;

    [Modifiers]
    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Context access\u0024000([In] IteratorLikeIterable obj0) => obj0.cx;

    [Modifiers]
    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Scriptable access\u0024100([In] IteratorLikeIterable obj0) => obj0.scope;

    [Modifiers]
    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Scriptable access\u0024200([In] IteratorLikeIterable obj0) => obj0.iterator;

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual IteratorLikeIterable.Itr iterator() => new IteratorLikeIterable.Itr(this);

    [LineNumberTable(new byte[] {159, 170, 104, 103, 135, 115, 108, 142, 107, 104, 146, 142, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IteratorLikeIterable(Context cx, Scriptable scope, object target)
    {
      IteratorLikeIterable iteratorLikeIterable = this;
      this.cx = cx;
      this.scope = scope;
      this.next = ScriptRuntime.getPropFunctionAndThis(target, nameof (next), cx, scope);
      this.iterator = ScriptRuntime.lastStoredScriptable(cx);
      object objectPropNoWarn = ScriptRuntime.getObjectPropNoWarn(target, "return", cx, scope);
      if (objectPropNoWarn != null && !Undefined.isUndefined(objectPropNoWarn))
        this.returnFunc = objectPropNoWarn is Callable ? (Callable) objectPropNoWarn : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(target, objectPropNoWarn, "return"));
      else
        this.returnFunc = (Callable) null;
    }

    [LineNumberTable(new byte[] {159, 190, 104, 103, 104, 191, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void close()
    {
      if (this.closed)
        return;
      this.closed = true;
      if (this.returnFunc == null)
        return;
      this.returnFunc.call(this.cx, this.scope, this.iterator, ScriptRuntime.__\u003C\u003EemptyArgs);
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator \u003Cbridge\u003Eiterator() => (Iterator) this.iterator();

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    Iterator Iterable.__\u003Coverridestub\u003Ejava\u002Elang\u002EIterable\u003A\u003Aiterator() => this.\u003Cbridge\u003Eiterator();

    void IDisposable.__\u003Coverridestub\u003Ejava\u002Elang\u002EAutoCloseable\u003A\u003Aclose() => this.close();

    [Signature("Ljava/lang/Object;Ljava/util/Iterator<Ljava/lang/Object;>;")]
    public sealed class Itr : Object, Iterator
    {
      private object nextVal;
      private bool isDone;
      [Modifiers]
      internal IteratorLikeIterable this\u00240;

      [LineNumberTable(61)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Itr(IteratorLikeIterable _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {18, 191, 24, 97, 42, 134, 109, 166, 104, 103, 130, 127, 8})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext()
      {
        object obj1 = IteratorLikeIterable.access\u0024300(this.this\u00240).call(IteratorLikeIterable.access\u0024000(this.this\u00240), IteratorLikeIterable.access\u0024100(this.this\u00240), IteratorLikeIterable.access\u0024200(this.this\u00240), ScriptRuntime.__\u003C\u003EemptyArgs);
        object obj2 = ScriptableObject.getProperty(ScriptableObject.ensureScriptable(obj1), "done");
        if (object.ReferenceEquals(obj2, Scriptable.NOT_FOUND))
          obj2 = Undefined.__\u003C\u003Einstance;
        if (ScriptRuntime.toBoolean(obj2))
        {
          this.isDone = true;
          return false;
        }
        this.nextVal = ScriptRuntime.getObjectPropNoWarn(obj1, "value", IteratorLikeIterable.access\u0024000(this.this\u00240), IteratorLikeIterable.access\u0024100(this.this\u00240));
        return true;
      }

      [LineNumberTable(new byte[] {37, 104, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next()
      {
        if (this.isDone)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        return this.nextVal;
      }

      [HideFromJava]
      public virtual void remove() => Iterator.\u003Cdefault\u003Eremove((Iterator) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
    }
  }
}
