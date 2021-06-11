// Decompiled with JetBrains decompiler
// Type: arc.scene.utils.Selection
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene.@event;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using ikvm.lang;
using java.lang;
using java.util;
using java.util.function;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.utils
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;Larc/scene/utils/Disableable;Ljava/lang/Iterable<TT;>;")]
  [Implements(new string[] {"arc.scene.utils.Disableable", "java.lang.Iterable"})]
  public class Selection : Object, Disableable, Iterable, IEnumerable
  {
    [Modifiers]
    [Signature("Larc/struct/OrderedSet<TT;>;")]
    internal OrderedSet selected;
    [Modifiers]
    [Signature("Larc/struct/OrderedSet<TT;>;")]
    private OrderedSet old;
    internal bool isDisabled;
    internal bool multiple;
    internal bool required;
    [Signature("TT;")]
    internal object lastSelected;
    private Element element;
    private bool toggle;
    private bool programmaticChangeEvents;

    [LineNumberTable(new byte[] {37, 107, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void snapshot()
    {
      this.old.clear();
      this.old.addAll((ObjectSet) this.selected);
    }

    [LineNumberTable(new byte[] {47, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void cleanup() => this.old.clear(32);

    [LineNumberTable(new byte[] {160, 107, 106, 154, 145, 102, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool fireChangeEvent()
    {
      if (this.element == null)
        return false;
      ChangeListener.ChangeEvent changeEvent = (ChangeListener.ChangeEvent) Pools.obtain((Class) ClassLiteral<ChangeListener.ChangeEvent>.Value, (Prov) new Selection.__\u003C\u003EAnon0());
      try
      {
        return this.element.fire((SceneEvent) changeEvent);
      }
      finally
      {
        Pools.free((object) changeEvent);
      }
    }

    [LineNumberTable(new byte[] {42, 107, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void revert()
    {
      this.selected.clear();
      this.selected.addAll((ObjectSet) this.old);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void changed()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 104, 107, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Selection()
    {
      Selection selection = this;
      this.selected = new OrderedSet();
      this.old = new OrderedSet();
      this.programmaticChangeEvents = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setActor(Element element) => this.element = element;

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {159, 180, 115, 105, 134, 127, 25, 254, 82, 102, 39, 230, 46, 97, 109, 235, 80, 102, 230, 49, 98, 124, 255, 5, 76, 102, 39, 230, 52, 97, 111, 239, 74, 102, 227, 55, 247, 72, 102, 37, 230, 56, 97, 235, 71, 102, 227, 58, 104, 136, 138, 102, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void choose(object item)
    {
      if (item == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("item cannot be null.");
      }
      if (this.isDisabled)
        return;
      this.snapshot();
      // ISSUE: fault handler
      try
      {
        if (!this.toggle && (this.required || this.selected.size != 1))
        {
          if (!Core.input.ctrl())
            goto label_13;
        }
        if (this.selected.contains(item))
        {
          if (this.required)
          {
            if (this.selected.size != 1)
              goto label_11;
          }
          else
            goto label_11;
        }
        else
          goto label_13;
      }
      __fault
      {
        this.cleanup();
      }
      this.cleanup();
      return;
label_11:
      // ISSUE: fault handler
      try
      {
        this.selected.remove(item);
        this.lastSelected = (object) null;
        goto label_28;
      }
      __fault
      {
        this.cleanup();
      }
label_13:
      int num;
      // ISSUE: fault handler
      try
      {
        num = 0;
        if (this.multiple)
        {
          if (!this.toggle)
          {
            if (Core.input.ctrl())
              goto label_22;
          }
          else
            goto label_22;
        }
        if (this.selected.size == 1)
        {
          if (!this.selected.contains(item))
            goto label_20;
        }
        else
          goto label_20;
      }
      __fault
      {
        this.cleanup();
      }
      this.cleanup();
      return;
label_20:
      // ISSUE: fault handler
      try
      {
        num = this.selected.size > 0 ? 1 : 0;
        this.selected.clear();
      }
      __fault
      {
        this.cleanup();
      }
label_22:
      // ISSUE: fault handler
      try
      {
        if (!this.selected.add(item))
        {
          if (num != 0)
            goto label_26;
        }
        else
          goto label_26;
      }
      __fault
      {
        this.cleanup();
      }
      this.cleanup();
      return;
label_26:
      // ISSUE: fault handler
      try
      {
        this.lastSelected = item;
      }
      __fault
      {
        this.cleanup();
      }
label_28:
      try
      {
        if (this.fireChangeEvent())
          this.revert();
        else
          this.changed();
      }
      finally
      {
        this.cleanup();
      }
    }

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasItems() => this.selected.size > 0;

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.selected.size == 0;

    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.selected.size;

    [Signature("()Larc/struct/OrderedSet<TT;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual OrderedSet items() => this.selected;

    [Signature("()TT;")]
    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object first() => this.selected.size == 0 ? (object) null : this.selected.first();

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {52, 115, 127, 3, 102, 107, 109, 112, 136, 103, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(object item)
    {
      if (item == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("item cannot be null.");
      }
      if (this.selected.size == 1 && object.ReferenceEquals(this.selected.first(), item))
        return;
      this.snapshot();
      this.selected.clear();
      this.selected.add(item);
      if (this.programmaticChangeEvents && this.fireChangeEvent())
      {
        this.revert();
      }
      else
      {
        this.lastSelected = item;
        this.changed();
      }
      this.cleanup();
    }

    [Signature("(Larc/struct/Seq<TT;>;)V")]
    [LineNumberTable(new byte[] {67, 98, 102, 103, 107, 109, 104, 115, 240, 61, 230, 69, 99, 112, 104, 105, 108, 166, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAll(Seq items)
    {
      int num = 0;
      this.snapshot();
      this.lastSelected = (object) null;
      this.selected.clear();
      int index = 0;
      for (int size = items.size; index < size; ++index)
      {
        object key = items.get(index);
        if (key == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("item cannot be null.");
        }
        if (this.selected.add(key))
          num = 1;
      }
      if (num != 0)
      {
        if (this.programmaticChangeEvents && this.fireChangeEvent())
          this.revert();
        else if (items.size > 0)
        {
          this.lastSelected = items.peek();
          this.changed();
        }
      }
      this.cleanup();
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {89, 115, 111, 112, 143, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(object item)
    {
      if (item == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("item cannot be null.");
      }
      if (!this.selected.add(item))
        return;
      if (this.programmaticChangeEvents && this.fireChangeEvent())
      {
        this.selected.remove(item);
      }
      else
      {
        this.lastSelected = item;
        this.changed();
      }
    }

    [Signature("(Larc/struct/Seq<TT;>;)V")]
    [LineNumberTable(new byte[] {100, 98, 102, 109, 104, 115, 240, 61, 230, 69, 99, 112, 136, 108, 166, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addAll(Seq items)
    {
      int num = 0;
      this.snapshot();
      int index = 0;
      for (int size = items.size; index < size; ++index)
      {
        object key = items.get(index);
        if (key == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("item cannot be null.");
        }
        if (this.selected.add(key))
          num = 1;
      }
      if (num != 0)
      {
        if (this.programmaticChangeEvents && this.fireChangeEvent())
        {
          this.revert();
        }
        else
        {
          this.lastSelected = items.peek();
          this.changed();
        }
      }
      this.cleanup();
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {119, 115, 111, 112, 143, 103, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(object item)
    {
      if (item == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("item cannot be null.");
      }
      if (!this.selected.remove(item))
        return;
      if (this.programmaticChangeEvents && this.fireChangeEvent())
      {
        this.selected.add(item);
      }
      else
      {
        this.lastSelected = (object) null;
        this.changed();
      }
    }

    [Signature("(Larc/struct/Seq<TT;>;)V")]
    [LineNumberTable(new byte[] {160, 66, 98, 102, 109, 104, 115, 240, 61, 230, 69, 99, 112, 136, 103, 166, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeAll(Seq items)
    {
      int num = 0;
      this.snapshot();
      int index = 0;
      for (int size = items.size; index < size; ++index)
      {
        object key = items.get(index);
        if (key == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("item cannot be null.");
        }
        if (this.selected.remove(key))
          num = 1;
      }
      if (num != 0)
      {
        if (this.programmaticChangeEvents && this.fireChangeEvent())
        {
          this.revert();
        }
        else
        {
          this.lastSelected = (object) null;
          this.changed();
        }
      }
      this.cleanup();
    }

    [LineNumberTable(new byte[] {160, 85, 110, 102, 107, 112, 136, 103, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      if (this.selected.size == 0)
        return;
      this.snapshot();
      this.selected.clear();
      if (this.programmaticChangeEvents && this.fireChangeEvent())
      {
        this.revert();
      }
      else
      {
        this.lastSelected = (object) null;
        this.changed();
      }
      this.cleanup();
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(object item) => item != null && this.selected.contains(item);

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {160, 122, 104, 103, 110, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getLastSelected()
    {
      if (this.lastSelected != null)
        return this.lastSelected;
      return this.selected.size > 0 ? this.selected.first() : (object) null;
    }

    [Signature("()Ljava/util/Iterator<TT;>;")]
    [LineNumberTable(246)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) this.selected.iterator();

    [Signature("()Larc/struct/Seq<TT;>;")]
    [LineNumberTable(250)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq toArray() => this.selected.iterator().toSeq();

    [Signature("(Larc/struct/Seq<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(254)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq toArray(Seq array) => this.selected.iterator().toSeq(array);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDisabled() => this.isDisabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDisabled(bool isDisabled) => this.isDisabled = isDisabled;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getToggle() => this.toggle;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setToggle(bool toggle) => this.toggle = toggle;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getMultiple() => this.multiple;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMultiple(bool multiple) => this.multiple = multiple;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getRequired() => this.required;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setRequired(bool required) => this.required = required;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProgrammaticChangeEvents(bool programmaticChangeEvents) => this.programmaticChangeEvents = programmaticChangeEvents;

    [LineNumberTable(301)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.selected.toString();

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new ChangeListener.ChangeEvent();
    }
  }
}
