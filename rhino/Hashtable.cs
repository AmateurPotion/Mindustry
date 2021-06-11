// Decompiled with JetBrains decompiler
// Type: rhino.Hashtable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Signature("Ljava/lang/Object;Ljava/lang/Iterable<Lrhino/Hashtable$Entry;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public class Hashtable : Object, Iterable, IEnumerable
  {
    [Modifiers]
    [Signature("Ljava/util/HashMap<Ljava/lang/Object;Lrhino/Hashtable$Entry;>;")]
    private HashMap map;
    private Hashtable.Entry first;
    private Hashtable.Entry last;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {53, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Hashtable.Entry makeDummy()
    {
      Hashtable.Entry entry = new Hashtable.Entry();
      entry.clear();
      return entry;
    }

    [Signature("()Ljava/util/Iterator<Lrhino/Hashtable$Entry;>;")]
    [LineNumberTable(208)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) new Hashtable.Iter(this, this.first);

    [LineNumberTable(new byte[] {159, 162, 136, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Hashtable()
    {
      Hashtable hashtable = this;
      this.map = new HashMap();
      this.first = (Hashtable.Entry) null;
      this.last = (Hashtable.Entry) null;
    }

    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.map.size();

    [LineNumberTable(new byte[] {63, 104, 115, 131, 104, 148, 108, 108, 201, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void put(object key, object value)
    {
      Hashtable.Entry entry1 = new Hashtable.Entry(key, value);
      Hashtable.Entry entry2 = (Hashtable.Entry) this.map.putIfAbsent((object) entry1, (object) entry1);
      if (entry2 == null)
      {
        if (this.first == null)
        {
          Hashtable hashtable = this;
          Hashtable.Entry entry3 = entry1;
          Hashtable.Entry entry4 = entry3;
          this.last = entry3;
          this.first = entry4;
        }
        else
        {
          this.last.next = entry1;
          entry1.prev = this.last;
          this.last = entry1;
        }
      }
      else
        entry2.value = value;
    }

    [LineNumberTable(new byte[] {81, 104, 114, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(object key) => ((Hashtable.Entry) this.map.get((object) new Hashtable.Entry(key, (object) null)))?.value;

    [LineNumberTable(new byte[] {90, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(object key) => this.map.containsKey((object) new Hashtable.Entry(key, (object) null));

    [LineNumberTable(new byte[] {95, 104, 114, 99, 226, 75, 110, 174, 103, 140, 108, 108, 112, 219, 103, 108, 103, 104, 142, 127, 1, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object delete(object key)
    {
      Hashtable.Entry entry = (Hashtable.Entry) this.map.remove((object) new Hashtable.Entry(key, (object) null));
      if (entry == null)
        return (object) null;
      if (object.ReferenceEquals((object) entry, (object) this.first))
      {
        if (object.ReferenceEquals((object) entry, (object) this.last))
        {
          entry.clear();
          entry.prev = (Hashtable.Entry) null;
        }
        else
        {
          this.first = entry.next;
          this.first.prev = (Hashtable.Entry) null;
          if (this.first.next != null)
            this.first.next.prev = this.first;
        }
      }
      else
      {
        Hashtable.Entry prev = entry.prev;
        prev.next = entry.next;
        entry.prev = (Hashtable.Entry) null;
        if (entry.next != null)
        {
          entry.next.prev = prev;
        }
        else
        {
          if (!Hashtable.\u0024assertionsDisabled && !object.ReferenceEquals((object) entry, (object) this.last))
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new AssertionError();
          }
          this.last = prev;
        }
      }
      return entry.clear();
    }

    [LineNumberTable(new byte[] {160, 75, 103, 240, 70, 104, 102, 103, 108, 210, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.iterator().forEachRemaining((Consumer) new Hashtable.__\u003C\u003EAnon0());
      if (this.first != null)
      {
        Hashtable.Entry entry1 = new Hashtable.Entry();
        entry1.clear();
        this.last.next = entry1;
        Hashtable hashtable = this;
        Hashtable.Entry entry2 = entry1;
        Hashtable.Entry entry3 = entry2;
        this.last = entry2;
        this.first = entry3;
      }
      this.map.clear();
    }

    [Modifiers]
    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Hashtable.Entry access\u0024000([In] Hashtable obj0) => obj0.makeDummy();

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Hashtable()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.Hashtable"))
        return;
      Hashtable.\u0024assertionsDisabled = !((Class) ClassLiteral<Hashtable>.Value).desiredAssertionStatus();
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    public sealed class Entry : Object
    {
      protected internal object key;
      protected internal object value;
      protected internal bool deleted;
      protected internal Hashtable.Entry next;
      protected internal Hashtable.Entry prev;
      [Modifiers]
      private int hashCode;

      [LineNumberTable(new byte[] {159, 182, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Entry()
      {
        Hashtable.Entry entry = this;
        this.hashCode = 0;
      }

      [LineNumberTable(new byte[] {159, 186, 104, 144, 121, 104, 142, 167, 104, 105, 114, 137, 177, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Entry([In] object obj0, [In] object obj1)
      {
        Hashtable.Entry entry = this;
        this.key = !(obj0 is Number) || obj0 is Double ? (!(obj0 is ConsString) ? obj0 : (object) Object.instancehelper_toString(obj0)) : (object) Double.valueOf(((Number) obj0).doubleValue());
        this.hashCode = this.key != null ? (!Object.instancehelper_equals(obj0, (object) Double.valueOf(ScriptRuntime.__\u003C\u003EnegativeZero)) ? Object.instancehelper_hashCode(this.key) : 0) : 0;
        this.value = obj1;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object key() => this.key;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object value() => this.value;

      [LineNumberTable(new byte[] {27, 103, 107, 107, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual object clear()
      {
        object obj = this.value;
        this.key = Undefined.__\u003C\u003Einstance;
        this.value = Undefined.__\u003C\u003Einstance;
        this.deleted = true;
        return obj;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int hashCode() => this.hashCode;

      [LineNumberTable(new byte[] {41, 99, 162, 127, 16, 97})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool equals(object o)
      {
        if (o == null)
          return false;
        int num;
        try
        {
          num = ScriptRuntime.sameZero(this.key, ((Hashtable.Entry) o).key) ? 1 : 0;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<ClassCastException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
          else
            goto label_6;
        }
        return num != 0;
label_6:
        return false;
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Ljava/util/Iterator<Lrhino/Hashtable$Entry;>;")]
    internal sealed class Iter : Object, Iterator
    {
      private Hashtable.Entry pos;
      [Modifiers]
      internal Hashtable this\u00240;

      [LineNumberTable(new byte[] {160, 103, 143, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Iter([In] Hashtable obj0, [In] Hashtable.Entry obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Hashtable.Iter iter = this;
        Hashtable.Entry entry = Hashtable.access\u0024000(obj0);
        entry.next = obj1;
        this.pos = entry;
      }

      [LineNumberTable(new byte[] {160, 114, 127, 0, 147})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void skipDeleted()
      {
        while (this.pos.next != null && this.pos.next.deleted)
          this.pos = this.pos.next;
      }

      [LineNumberTable(new byte[] {160, 127, 102, 117, 139, 108, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Hashtable.Entry next()
      {
        this.skipDeleted();
        if (this.pos == null || this.pos.next == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        Hashtable.Entry next = this.pos.next;
        this.pos = this.pos.next;
        return next;
      }

      [LineNumberTable(new byte[] {160, 121, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext()
      {
        this.skipDeleted();
        return this.pos != null && this.pos.next != null;
      }

      [Modifiers]
      [LineNumberTable(213)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next() => (object) this.next();

      [HideFromJava]
      public virtual void remove() => Iterator.\u003Cdefault\u003Eremove((Iterator) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Consumer
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void accept([In] object obj0) => ((Hashtable.Entry) obj0).clear();

      [SpecialName]
      public Consumer andThen([In] Consumer obj0) => Consumer.\u003Cdefault\u003EandThen((Consumer) this, obj0);
    }
  }
}
