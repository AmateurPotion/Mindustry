// Decompiled with JetBrains decompiler
// Type: rhino.ClassCache
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.concurrent;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino
{
  public class ClassCache : Object
  {
    [Modifiers]
    private static object AKEY;
    private volatile bool cachingIsEnabled;
    [Signature("Ljava/util/Map<Ljava/lang/Class<*>;Lrhino/JavaMembers;>;")]
    [NonSerialized]
    private Map classTable;
    [Signature("Ljava/util/Map<Lrhino/JavaAdapter$JavaAdapterSignature;Ljava/lang/Class<*>;>;")]
    [NonSerialized]
    private Map classAdapterCache;
    [Signature("Ljava/util/Map<Ljava/lang/Class<*>;Ljava/lang/Object;>;")]
    [NonSerialized]
    private Map interfaceAdapterCache;
    private int generatedClassSerial;
    private Scriptable associatedScope;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void clearCaches()
    {
      this.classTable = (Map) null;
      this.classAdapterCache = (Map) null;
      this.interfaceAdapterCache = (Map) null;
    }

    [LineNumberTable(new byte[] {159, 154, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ClassCache()
    {
      ClassCache classCache = this;
      this.cachingIsEnabled = true;
      Thread.MemoryBarrier();
    }

    [LineNumberTable(new byte[] {159, 175, 102, 107, 99, 176})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ClassCache get(Scriptable scope)
    {
      ClassCache topScopeValue = (ClassCache) ScriptableObject.getTopScopeValue(scope, ClassCache.AKEY);
      if (topScopeValue == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Can't find top level scope for ClassCache.get");
      }
      return topScopeValue;
    }

    [LineNumberTable(new byte[] {2, 136, 139, 116, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool associate(ScriptableObject topScope)
    {
      if (topScope.getParentScope() != null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (!object.ReferenceEquals((object) this, topScope.associateValue(ClassCache.AKEY, (object) this)))
        return false;
      this.associatedScope = (Scriptable) topScope;
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool isCachingEnabled() => this.cachingIsEnabled;

    [LineNumberTable(new byte[] {159, 118, 98, 107, 97, 99, 102, 110})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void setCachingEnabled(bool enabled)
    {
      int num = enabled ? 1 : 0;
      if (num == (this.cachingIsEnabled ? 1 : 0))
        return;
      if (num == 0)
        this.clearCaches();
      this.cachingIsEnabled = num != 0;
      Thread.MemoryBarrier();
    }

    [Signature("()Ljava/util/Map<Ljava/lang/Class<*>;Lrhino/JavaMembers;>;")]
    [LineNumberTable(new byte[] {58, 168, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Map getClassCacheMap()
    {
      if (this.classTable == null)
        this.classTable = (Map) new ConcurrentHashMap(16, 0.75f, 1);
      return this.classTable;
    }

    [Signature("()Ljava/util/Map<Lrhino/JavaAdapter$JavaAdapterSignature;Ljava/lang/Class<*>;>;")]
    [LineNumberTable(new byte[] {67, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Map getInterfaceAdapterCacheMap()
    {
      if (this.classAdapterCache == null)
        this.classAdapterCache = (Map) new ConcurrentHashMap(16, 0.75f, 1);
      return this.classAdapterCache;
    }

    [Obsolete]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isInvokerOptimizationEnabled() => false;

    [Obsolete]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void setInvokerOptimizationEnabled(bool enabled)
    {
    }

    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public int newClassSerialNumber()
    {
      ClassCache classCache1 = this;
      int num1 = classCache1.generatedClassSerial + 1;
      ClassCache classCache2 = classCache1;
      int num2 = num1;
      classCache2.generatedClassSerial = num1;
      return num2;
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {103, 146, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object getInterfaceAdapter([In] Class obj0) => this.interfaceAdapterCache == null ? (object) null : this.interfaceAdapterCache.get((object) obj0);

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;)V")]
    [LineNumberTable(new byte[] {109, 106, 104, 147, 142})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    internal virtual void cacheInterfaceAdapter([In] Class obj0, [In] object obj1)
    {
      if (!this.cachingIsEnabled)
        return;
      if (this.interfaceAdapterCache == null)
        this.interfaceAdapterCache = (Map) new ConcurrentHashMap(16, 0.75f, 1);
      this.interfaceAdapterCache.put((object) obj0, obj1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Scriptable getAssociatedScope() => this.associatedScope;

    [MethodImpl(MethodImplOptions.NoInlining)]
    static ClassCache()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.ClassCache"))
        return;
      ClassCache.AKEY = (object) nameof (ClassCache);
    }
  }
}
