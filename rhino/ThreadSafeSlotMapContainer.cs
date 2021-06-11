// Decompiled with JetBrains decompiler
// Type: rhino.ThreadSafeSlotMapContainer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.concurrent.locks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  internal class ThreadSafeSlotMapContainer : SlotMapContainer
  {
    [Modifiers]
    private StampedLock @lock;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 233, 60, 235, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ThreadSafeSlotMapContainer([In] int obj0)
      : base(obj0)
    {
      ThreadSafeSlotMapContainer slotMapContainer = this;
      this.@lock = new StampedLock();
    }

    [LineNumberTable(new byte[] {90, 127, 0, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void checkMapSize()
    {
      if (!ThreadSafeSlotMapContainer.\u0024assertionsDisabled && !this.@lock.isWriteLocked())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      base.checkMapSize();
    }

    [LineNumberTable(new byte[] {159, 166, 108, 108, 110, 162, 140, 144, 108, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int size()
    {
      long num1 = this.@lock.tryOptimisticRead();
      int num2 = this.map.size();
      if (this.@lock.validate(num1))
        return num2;
      long num3 = this.@lock.readLock();
      try
      {
        return this.map.size();
      }
      finally
      {
        this.@lock.unlockRead(num3);
      }
    }

    [LineNumberTable(new byte[] {159, 182, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int dirtySize()
    {
      if (!ThreadSafeSlotMapContainer.\u0024assertionsDisabled && !this.@lock.isReadLocked())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return this.map.size();
    }

    [LineNumberTable(new byte[] {159, 188, 108, 108, 110, 162, 140, 144, 108, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isEmpty()
    {
      long num1 = this.@lock.tryOptimisticRead();
      int num2 = this.map.isEmpty() ? 1 : 0;
      if (this.@lock.validate(num1))
        return num2 != 0;
      long num3 = this.@lock.readLock();
      try
      {
        return this.map.isEmpty();
      }
      finally
      {
        this.@lock.unlockRead(num3);
      }
    }

    [LineNumberTable(new byte[] {12, 140, 109, 134, 147, 108, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ScriptableObject.Slot get(
      [In] object obj0,
      [In] int obj1,
      [In] ScriptableObject.SlotAccess obj2)
    {
      long num = this.@lock.writeLock();
      try
      {
        if (!object.ReferenceEquals((object) obj2, (object) ScriptableObject.SlotAccess.QUERY))
          this.checkMapSize();
        return this.map.get(obj0, obj1, obj2);
      }
      finally
      {
        this.@lock.unlockWrite(num);
      }
    }

    [LineNumberTable(new byte[] {25, 108, 110, 110, 162, 140, 146, 108, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ScriptableObject.Slot query([In] object obj0, [In] int obj1)
    {
      long num1 = this.@lock.tryOptimisticRead();
      ScriptableObject.Slot slot = this.map.query(obj0, obj1);
      if (this.@lock.validate(num1))
        return slot;
      long num2 = this.@lock.readLock();
      try
      {
        return this.map.query(obj0, obj1);
      }
      finally
      {
        this.@lock.unlockRead(num2);
      }
    }

    [LineNumberTable(new byte[] {41, 140, 102, 144, 108, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void addSlot([In] ScriptableObject.Slot obj0)
    {
      long num = this.@lock.writeLock();
      try
      {
        this.checkMapSize();
        this.map.addSlot(obj0);
      }
      finally
      {
        this.@lock.unlockWrite(num);
      }
    }

    [LineNumberTable(new byte[] {52, 140, 145, 108, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void remove([In] object obj0, [In] int obj1)
    {
      long num = this.@lock.writeLock();
      try
      {
        this.map.remove(obj0, obj1);
      }
      finally
      {
        this.@lock.unlockWrite(num);
      }
    }

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long readLock() => this.@lock.readLock();

    [LineNumberTable(new byte[] {75, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void unlockRead([In] long obj0) => this.@lock.unlockRead(obj0);

    [Signature("()Ljava/util/Iterator<Lrhino/ScriptableObject$Slot;>;")]
    [LineNumberTable(new byte[] {80, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Iterator iterator()
    {
      if (!ThreadSafeSlotMapContainer.\u0024assertionsDisabled && !this.@lock.isReadLocked())
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError();
      }
      return ((Iterable) this.map).iterator();
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ThreadSafeSlotMapContainer()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.ThreadSafeSlotMapContainer"))
        return;
      ThreadSafeSlotMapContainer.\u0024assertionsDisabled = !((Class) ClassLiteral<ThreadSafeSlotMapContainer>.Value).desiredAssertionStatus();
    }
  }
}
