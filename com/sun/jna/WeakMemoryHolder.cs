// Decompiled with JetBrains decompiler
// Type: com.sun.jna.WeakMemoryHolder
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.lang.@ref;
using java.util;
using System.Runtime.CompilerServices;

namespace com.sun.jna
{
  public class WeakMemoryHolder : Object
  {
    [Signature("Ljava/lang/ref/ReferenceQueue<Ljava/lang/Object;>;")]
    internal ReferenceQueue referenceQueue;
    [Signature("Ljava/util/IdentityHashMap<Ljava/lang/ref/Reference<Ljava/lang/Object;>;Lcom/sun/jna/Memory;>;")]
    internal IdentityHashMap backingMap;

    [LineNumberTable(new byte[] {0, 111, 45, 174})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void clean()
    {
      for (Reference reference = this.referenceQueue.poll(); reference != null; reference = this.referenceQueue.poll())
        this.backingMap.remove((object) reference);
    }

    [LineNumberTable(new byte[] {159, 186, 102, 109, 110})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void put(object o, Memory m)
    {
      this.clean();
      this.backingMap.put((object) new WeakReference(o, this.referenceQueue), (object) m);
    }

    [LineNumberTable(new byte[] {159, 181, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WeakMemoryHolder()
    {
      WeakMemoryHolder weakMemoryHolder = this;
      this.referenceQueue = new ReferenceQueue();
      this.backingMap = new IdentityHashMap();
    }
  }
}
