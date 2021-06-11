// Decompiled with JetBrains decompiler
// Type: rhino.SlotMapContainer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using ikvm.lang;
using java.lang;
using java.util;
using java.util.function;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.SlotMap"})]
  internal class SlotMapContainer : Object, SlotMap, Iterable, IEnumerable
  {
    private const int LARGE_HASH_SIZE = 2000;
    protected internal SlotMap map;

    [LineNumberTable(new byte[] {159, 165, 104, 104, 141, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SlotMapContainer([In] int obj0)
    {
      SlotMapContainer slotMapContainer = this;
      if (obj0 > 2000)
        this.map = (SlotMap) new HashSlotMap();
      else
        this.map = (SlotMap) new EmbeddedSlotMap();
    }

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptableObject.Slot query([In] object obj0, [In] int obj1) => this.map.query(obj0, obj1);

    [LineNumberTable(new byte[] {16, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove([In] object obj0, [In] int obj1) => this.map.remove(obj0, obj1);

    [LineNumberTable(new byte[] {159, 189, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptableObject.Slot get(
      [In] object obj0,
      [In] int obj1,
      [In] ScriptableObject.SlotAccess obj2)
    {
      if (!object.ReferenceEquals((object) obj2, (object) ScriptableObject.SlotAccess.QUERY))
        this.checkMapSize();
      return this.map.get(obj0, obj1, obj2);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long readLock() => 0;

    [Signature("()Ljava/util/Iterator<Lrhino/ScriptableObject$Slot;>;")]
    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => ((Iterable) this.map).iterator();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unlockRead([In] long obj0)
    {
    }

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.map.isEmpty();

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int dirtySize() => this.map.size();

    [LineNumberTable(new byte[] {10, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addSlot([In] ScriptableObject.Slot obj0)
    {
      this.checkMapSize();
      this.map.addSlot(obj0);
    }

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.map.size();

    [LineNumberTable(new byte[] {38, 127, 0, 102, 127, 1, 103, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void checkMapSize()
    {
      if (!(this.map is EmbeddedSlotMap) || this.map.size() < 2000)
        return;
      HashSlotMap hashSlotMap = new HashSlotMap();
      Iterator iterator = ((Iterable) this.map).iterator();
      while (iterator.hasNext())
      {
        ScriptableObject.Slot sos = (ScriptableObject.Slot) iterator.next();
        hashSlotMap.addSlot(sos);
      }
      this.map = (SlotMap) hashSlotMap;
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);
  }
}
