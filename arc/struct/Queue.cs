// Decompiled with JetBrains decompiler
// Type: arc.struct.Queue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.util;
using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.util;
using java.util.function;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.@struct
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TT;>;Larc/util/Eachable<TT;>;")]
  [Implements(new string[] {"java.lang.Iterable", "arc.util.Eachable"})]
  public class Queue : Object, Iterable, IEnumerable, Eachable
  {
    public int size;
    [Signature("[TT;")]
    protected internal object[] values;
    protected internal int head;
    protected internal int tail;
    private arc.@struct.Queue.QueueIterable iterable;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.size == 0;

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {18, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(object @object) => this.addLast(@object);

    [LineNumberTable(new byte[] {160, 221, 105, 103, 103, 135, 132, 102, 36, 232, 69, 103, 36, 166, 102, 36, 198, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      if (this.size == 0)
        return;
      object[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      if (head < tail)
      {
        for (int index = head; index < tail; ++index)
          values[index] = (object) null;
      }
      else
      {
        for (int index = head; index < values.Length; ++index)
          values[index] = (object) null;
        for (int index = 0; index < tail; ++index)
          values[index] = (object) null;
      }
      this.head = 0;
      this.tail = 0;
      this.size = 0;
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {27, 135, 106, 106, 167, 103, 100, 100, 133, 132, 103, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addFirst(object @object)
    {
      object[] values = this.values;
      if (this.size == values.Length)
      {
        this.resize(values.Length << 1);
        values = this.values;
      }
      int index = this.head - 1;
      if (index == -1)
        index = values.Length - 1;
      values[index] = @object;
      this.head = index;
      ++this.size;
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {83, 136, 176, 135, 105, 105, 110, 106, 135, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object removeFirst()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NoSuchElementException("Queue is empty.");
      }
      object[] values = this.values;
      object obj = values[this.head];
      values[this.head] = (object) null;
      ++this.head;
      if (this.head == values.Length)
        this.head = 0;
      --this.size;
      return obj;
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {160, 172, 136, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object first()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NoSuchElementException("Queue is empty.");
      }
      return this.values[this.head];
    }

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {2, 135, 106, 106, 167, 118, 106, 135, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addLast(object @object)
    {
      object[] values = this.values;
      if (this.size == values.Length)
      {
        this.resize(values.Length << 1);
        values = this.values;
      }
      object[] objArray = values;
      arc.@struct.Queue queue1 = this;
      int tail = queue1.tail;
      arc.@struct.Queue queue2 = queue1;
      int index = tail;
      queue2.tail = tail + 1;
      object obj = @object;
      objArray[index] = obj;
      if (this.tail == values.Length)
        this.tail = 0;
      ++this.size;
    }

    [LineNumberTable(new byte[] {159, 172, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Queue()
      : this(16)
    {
    }

    [Signature("()Ljava/util/Iterator<TT;>;")]
    [LineNumberTable(new byte[] {160, 251, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator()
    {
      if (this.iterable == null)
        this.iterable = new arc.@struct.Queue.QueueIterable(this);
      return this.iterable.iterator();
    }

    [Signature("(I)TT;")]
    [LineNumberTable(new byte[] {160, 205, 127, 10, 127, 36, 135, 105, 101, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object get(int index)
    {
      if (index < 0)
      {
        string str = new StringBuilder().append("index can't be < 0: ").append(index).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      object[] values = this.values;
      int index1 = this.head + index;
      if (index1 >= values.Length)
        index1 -= values.Length;
      return values[index1];
    }

    [LineNumberTable(new byte[] {159, 176, 232, 46, 199, 231, 69, 231, 75, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Queue(int initialSize)
    {
      arc.@struct.Queue queue = this;
      this.size = 0;
      this.head = 0;
      this.tail = 0;
      this.values = new object[initialSize];
    }

    [Signature("(Larc/func/Boolf<TT;>;)I")]
    [LineNumberTable(new byte[] {160, 96, 106, 103, 110, 100, 102, 47, 171, 107, 47, 134, 102, 50, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(Boolf value)
    {
      if (this.size == 0)
        return -1;
      object[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      if (head < tail)
      {
        for (int index = head; index < tail; ++index)
        {
          if (value.get(values[index]))
            return index - head;
        }
      }
      else
      {
        int index1 = head;
        for (int length = values.Length; index1 < length; ++index1)
        {
          if (value.get(values[index1]))
            return index1 - head;
        }
        for (int index2 = 0; index2 < tail; ++index2)
        {
          if (value.get(values[index2]))
            return index2 + values.Length - head;
        }
      }
      return -1;
    }

    [Signature("(I)TT;")]
    [LineNumberTable(new byte[] {160, 130, 127, 10, 159, 36, 103, 110, 133, 100, 100, 110, 100, 115, 101, 102, 100, 110, 144, 100, 110, 100, 110, 106, 167, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object removeIndex(int index)
    {
      if (index < 0)
      {
        string str = new StringBuilder().append("index can't be < 0: ").append(index).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      if (index >= this.size)
      {
        string str = new StringBuilder().append("index can't be >= size: ").append(index).append(" >= ").append(this.size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException(str);
      }
      object[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      index += head;
      object obj;
      if (head < tail)
      {
        obj = values[index];
        ByteCodeHelper.arraycopy((object) values, index + 1, (object) values, index, tail - index);
        values[tail] = (object) null;
        --this.tail;
      }
      else if (index >= values.Length)
      {
        index -= values.Length;
        obj = values[index];
        ByteCodeHelper.arraycopy((object) values, index + 1, (object) values, index, tail - index);
        --this.tail;
      }
      else
      {
        obj = values[index];
        ByteCodeHelper.arraycopy((object) values, head, (object) values, head + 1, index - head);
        values[head] = (object) null;
        ++this.head;
        if (this.head == values.Length)
          this.head = 0;
      }
      --this.size;
      return obj;
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(226)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove(object value) => this.remove(value, false);

    [Signature("(TT;Z)Z")]
    [LineNumberTable(new byte[] {159, 83, 66, 105, 102, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove(object value, bool identity)
    {
      int num = identity ? 1 : 0;
      int index = this.indexOf(value, num != 0);
      if (index == -1)
        return false;
      this.removeIndex(index);
      return true;
    }

    [LineNumberTable(new byte[] {50, 105, 106, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void ensureCapacity(int additional)
    {
      int newSize = this.size + additional;
      if (this.values.Length >= newSize)
        return;
      this.resize(newSize);
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {108, 104, 176, 103, 103, 100, 100, 133, 100, 100, 103, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object removeLast()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NoSuchElementException("Queue is empty.");
      }
      object[] values = this.values;
      int index = this.tail - 1;
      if (index == -1)
        index = values.Length - 1;
      object obj = values[index];
      values[index] = (object) null;
      this.tail = index;
      --this.size;
      return obj;
    }

    [LineNumberTable(new byte[] {58, 103, 103, 135, 119, 132, 110, 137, 102, 107, 139, 103, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void resize(int newSize)
    {
      object[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      object[] objArray = (object[]) Array.newInstance(Object.instancehelper_getClass((object) values).getComponentType(), newSize);
      if (head < tail)
        ByteCodeHelper.arraycopy((object) values, head, (object) objArray, 0, tail - head);
      else if (this.size > 0)
      {
        int num = values.Length - head;
        ByteCodeHelper.arraycopy((object) values, head, (object) objArray, 0, num);
        ByteCodeHelper.arraycopy((object) values, 0, (object) objArray, num, tail);
      }
      this.values = objArray;
      this.head = 0;
      this.tail = this.size;
    }

    [Signature("(TT;Z)I")]
    [LineNumberTable(new byte[] {159, 97, 130, 106, 103, 110, 105, 100, 104, 49, 173, 109, 49, 136, 104, 52, 205, 100, 104, 49, 173, 109, 49, 136, 104, 52, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(object value, bool identity)
    {
      int num = identity ? 1 : 0;
      if (this.size == 0)
        return -1;
      object[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      if (num != 0 || value == null)
      {
        if (head < tail)
        {
          for (int index = head; index < tail; ++index)
          {
            if (object.ReferenceEquals(values[index], value))
              return index - head;
          }
        }
        else
        {
          int index1 = head;
          for (int length = values.Length; index1 < length; ++index1)
          {
            if (object.ReferenceEquals(values[index1], value))
              return index1 - head;
          }
          for (int index2 = 0; index2 < tail; ++index2)
          {
            if (object.ReferenceEquals(values[index2], value))
              return index2 + values.Length - head;
          }
        }
      }
      else if (head < tail)
      {
        for (int index = head; index < tail; ++index)
        {
          if (Object.instancehelper_equals(value, values[index]))
            return index - head;
        }
      }
      else
      {
        int index1 = head;
        for (int length = values.Length; index1 < length; ++index1)
        {
          if (Object.instancehelper_equals(value, values[index1]))
            return index1 - head;
        }
        for (int index2 = 0; index2 < tail; ++index2)
        {
          if (Object.instancehelper_equals(value, values[index2]))
            return index2 + values.Length - head;
        }
      }
      return -1;
    }

    [Signature("(ILjava/lang/Class<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 185, 232, 37, 199, 231, 69, 231, 83, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Queue(int initialSize, Class type)
    {
      arc.@struct.Queue queue = this;
      this.size = 0;
      this.head = 0;
      this.tail = 0;
      this.values = (object[]) Array.newInstance(type, initialSize);
    }

    [Signature("()TT;")]
    [LineNumberTable(new byte[] {160, 186, 136, 144, 103, 103, 100, 100, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object last()
    {
      if (this.size == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NoSuchElementException("Queue is empty.");
      }
      object[] values = this.values;
      int index = this.tail - 1;
      if (index == -1)
        index = values.Length - 1;
      return values[index];
    }

    [Signature("(Larc/func/Cons<-TT;>;)V")]
    [LineNumberTable(new byte[] {161, 2, 107, 45, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Cons c)
    {
      for (int index = 0; index < this.size; ++index)
        c.get(this.get(index));
    }

    [LineNumberTable(new byte[] {161, 8, 104, 134, 103, 103, 135, 104, 105, 106, 118, 53, 180, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      if (this.size == 0)
        return "[]";
      object[] values = this.values;
      int head = this.head;
      int tail = this.tail;
      StringBuilder stringBuilder = new StringBuilder(64);
      stringBuilder.append('[');
      stringBuilder.append(values[head]);
      int num1 = head + 1;
      int length1 = values.Length;
      int num2;
      int length2;
      for (int index = length1 != -1 ? num1 % length1 : 0; index != tail; index = length2 != -1 ? num2 % length2 : 0)
      {
        stringBuilder.append(", ").append(values[index]);
        num2 = index + 1;
        length2 = values.Length;
      }
      stringBuilder.append(']');
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {161, 26, 103, 103, 99, 135, 101, 104, 133, 103, 144, 100, 230, 57, 232, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int size = this.size;
      object[] values = this.values;
      int length = values.Length;
      int index1 = this.head;
      int num = size + 1;
      for (int index2 = 0; index2 < size; ++index2)
      {
        object obj = values[index1];
        num *= 31;
        if (obj != null)
          num += Object.instancehelper_hashCode(obj);
        ++index1;
        if (index1 == length)
          index1 = 0;
      }
      return num;
    }

    [LineNumberTable(new byte[] {161, 46, 107, 138, 103, 135, 139, 103, 99, 104, 133, 104, 104, 107, 102, 135, 119, 102, 102, 104, 233, 56, 235, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      if (!(o is arc.@struct.Queue))
        return false;
      arc.@struct.Queue queue = (arc.@struct.Queue) o;
      int size = this.size;
      if (queue.size != size)
        return false;
      object[] values1 = this.values;
      int length1 = values1.Length;
      object[] values2 = queue.values;
      int length2 = values2.Length;
      int index1 = this.head;
      int index2 = queue.head;
      for (int index3 = 0; index3 < size; ++index3)
      {
        object obj1 = values1[index1];
        object obj2 = values2[index2];
        if (obj1 == null)
        {
          if (obj2 == null)
            goto label_12;
        }
        else if (Object.instancehelper_equals(obj1, obj2))
          goto label_12;
        return false;
label_12:
        ++index1;
        ++index2;
        if (index1 == length1)
          index1 = 0;
        if (index2 == length2)
          index2 = 0;
      }
      return true;
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;Ljava/lang/Iterable<TT;>;")]
    [Implements(new string[] {"java.lang.Iterable"})]
    public class QueueIterable : Object, Iterable, IEnumerable
    {
      [Modifiers]
      [Signature("Larc/struct/Queue<TT;>;")]
      internal arc.@struct.Queue queue;
      [Modifiers]
      internal bool allowRemove;
      [Signature("Larc/struct/Queue$QueueIterable<TT;>.QueueIterator;")]
      private arc.@struct.Queue.QueueIterable.QueueIterator iterator1;
      [Signature("Larc/struct/Queue$QueueIterable<TT;>.QueueIterator;")]
      private arc.@struct.Queue.QueueIterable.QueueIterator iterator2;

      [Signature("(Larc/struct/Queue<TT;>;Z)V")]
      [LineNumberTable(new byte[] {159, 29, 98, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public QueueIterable(arc.@struct.Queue queue, bool allowRemove)
      {
        int num = allowRemove ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        arc.@struct.Queue.QueueIterable queueIterable = this;
        this.queue = queue;
        this.allowRemove = num != 0;
      }

      [Signature("(Larc/struct/Queue<TT;>;)V")]
      [LineNumberTable(new byte[] {161, 80, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public QueueIterable(arc.@struct.Queue queue)
        : this(queue, true)
      {
      }

      [Signature("()Ljava/util/Iterator<TT;>;")]
      [LineNumberTable(new byte[] {161, 90, 104, 108, 172, 109, 108, 108, 167, 109, 108, 108, 167})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator()
      {
        if (this.iterator1 == null)
        {
          this.iterator1 = new arc.@struct.Queue.QueueIterable.QueueIterator(this);
          this.iterator2 = new arc.@struct.Queue.QueueIterable.QueueIterator(this);
        }
        if (this.iterator1.done)
        {
          this.iterator1.index = 0;
          this.iterator1.done = false;
          return (Iterator) this.iterator1;
        }
        if (!this.iterator2.done)
          return (Iterator) new arc.@struct.Queue.QueueIterable.QueueIterator(this);
        this.iterator2.index = 0;
        this.iterator2.done = false;
        return (Iterator) this.iterator2;
      }

      [HideFromJava]
      public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

      [HideFromJava]
      public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

      [InnerClass]
      [Signature("Ljava/lang/Object;Ljava/util/Iterator<TT;>;Ljava/lang/Iterable<TT;>;")]
      [Implements(new string[] {"java.util.Iterator", "java.lang.Iterable"})]
      internal class QueueIterator : Object, Iterator, Iterable, IEnumerable
      {
        internal int index;
        internal bool done;
        [Modifiers]
        internal arc.@struct.Queue.QueueIterable this\u00240;

        [LineNumberTable(new byte[] {161, 114, 15, 167})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal QueueIterator([In] arc.@struct.Queue.QueueIterable obj0)
        {
          this.this\u00240 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          arc.@struct.Queue.QueueIterable.QueueIterator queueIterator = this;
          this.done = true;
        }

        [LineNumberTable(new byte[] {161, 119, 127, 0})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool hasNext()
        {
          if (this.index >= this.this\u00240.queue.size)
            this.done = true;
          return this.index < this.this\u00240.queue.size;
        }

        [Signature("()TT;")]
        [LineNumberTable(new byte[] {161, 125, 127, 15})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual object next()
        {
          if (this.index >= this.this\u00240.queue.size)
          {
            string str = String.valueOf(this.index);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new NoSuchElementException(str);
          }
          arc.@struct.Queue queue = this.this\u00240.queue;
          arc.@struct.Queue.QueueIterable.QueueIterator queueIterator1 = this;
          int index1 = queueIterator1.index;
          arc.@struct.Queue.QueueIterable.QueueIterator queueIterator2 = queueIterator1;
          int index2 = index1;
          queueIterator2.index = index1 + 1;
          return queue.get(index2);
        }

        [LineNumberTable(new byte[] {161, 131, 125, 110, 119})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void remove()
        {
          if (!this.this\u00240.allowRemove)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException("Remove not allowed.");
          }
          --this.index;
          this.this\u00240.queue.removeIndex(this.index);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void reset() => this.index = 0;

        [Signature("()Ljava/util/Iterator<TT;>;")]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual Iterator iterator() => (Iterator) this;

        [HideFromJava]
        public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

        [HideFromJava]
        public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

        [HideFromJava]
        public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

        [HideFromJava]
        [SpecialName]
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);
      }
    }
  }
}
