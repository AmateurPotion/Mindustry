// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.SoftCachingModuleScriptProvider
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using java.lang.@ref;
using java.net;
using java.util;
using java.util.concurrent;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.module.provider
{
  public class SoftCachingModuleScriptProvider : CachingModuleScriptProviderBase
  {
    [Signature("Ljava/lang/ref/ReferenceQueue<Lrhino/Script;>;")]
    [NonSerialized]
    private ReferenceQueue scriptRefQueue;
    [Signature("Ljava/util/concurrent/ConcurrentMap<Ljava/lang/String;Lrhino/module/provider/SoftCachingModuleScriptProvider$ScriptReference;>;")]
    [NonSerialized]
    private ConcurrentMap scripts;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 173, 233, 55, 107, 252, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SoftCachingModuleScriptProvider(ModuleSourceProvider moduleSourceProvider)
      : base(moduleSourceProvider)
    {
      SoftCachingModuleScriptProvider moduleScriptProvider = this;
      this.scriptRefQueue = new ReferenceQueue();
      ConcurrentHashMap.__\u003Cclinit\u003E();
      this.scripts = (ConcurrentMap) new ConcurrentHashMap(16, 0.75f, CachingModuleScriptProviderBase.getConcurrencyLevel());
    }

    [LineNumberTable(new byte[] {9, 111, 55, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void putLoadedModule(
      string moduleId,
      ModuleScript moduleScript,
      object validator)
    {
      ((Map) this.scripts).put((object) moduleId, (object) new SoftCachingModuleScriptProvider.ScriptReference(moduleScript.getScript(), moduleId, moduleScript.getUri(), moduleScript.getBase(), validator, this.scriptRefQueue));
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [LineNumberTable(new byte[] {159, 183, 113, 99, 130, 115, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ModuleScript getModuleScript(
      Context cx,
      string moduleId,
      URI uri,
      URI @base,
      Scriptable paths)
    {
      while (true)
      {
        SoftCachingModuleScriptProvider.ScriptReference scriptReference = (SoftCachingModuleScriptProvider.ScriptReference) this.scriptRefQueue.poll();
        if (scriptReference != null)
          this.scripts.remove((object) scriptReference.getModuleId(), (object) scriptReference);
        else
          break;
      }
      return base.getModuleScript(cx, moduleId, uri, @base, paths);
    }

    [LineNumberTable(new byte[] {2, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override CachingModuleScriptProviderBase.CachedModuleScript getLoadedModule(
      string moduleId)
    {
      return ((SoftCachingModuleScriptProvider.ScriptReference) ((Map) this.scripts).get((object) moduleId))?.getCachedModuleScript();
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {45, 107, 107, 108, 127, 1, 108, 115, 37, 133, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      this.scriptRefQueue = new ReferenceQueue();
      this.scripts = (ConcurrentMap) new ConcurrentHashMap();
      Iterator iterator = ((Map) obj0.readObject()).entrySet().iterator();
      while (iterator.hasNext())
      {
        Map.Entry entry = (Map.Entry) iterator.next();
        CachingModuleScriptProviderBase.CachedModuleScript cachedModuleScript = (CachingModuleScriptProviderBase.CachedModuleScript) entry.getValue();
        this.putLoadedModule((string) entry.getKey(), cachedModuleScript.getModule(), cachedModuleScript.getValidator());
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {56, 134, 127, 6, 97, 112, 99, 142, 98, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeObject([In] ObjectOutputStream obj0)
    {
      HashMap hashMap = new HashMap();
      Iterator iterator = ((Map) this.scripts).entrySet().iterator();
      while (iterator.hasNext())
      {
        Map.Entry entry = (Map.Entry) iterator.next();
        CachingModuleScriptProviderBase.CachedModuleScript cachedModuleScript = ((SoftCachingModuleScriptProvider.ScriptReference) entry.getValue()).getCachedModuleScript();
        if (cachedModuleScript != null)
          ((Map) hashMap).put(entry.getKey(), (object) cachedModuleScript);
      }
      obj0.writeObject((object) hashMap);
    }

    [HideFromJava]
    static SoftCachingModuleScriptProvider() => CachingModuleScriptProviderBase.__\u003Cclinit\u003E();

    [InnerClass]
    [Signature("Ljava/lang/ref/SoftReference<Lrhino/Script;>;")]
    internal class ScriptReference : SoftReference
    {
      [Modifiers]
      private string moduleId;
      [Modifiers]
      private URI uri;
      [Modifiers]
      private URI @base;
      [Modifiers]
      private object validator;

      [Signature("(Lrhino/Script;Ljava/lang/String;Ljava/net/URI;Ljava/net/URI;Ljava/lang/Object;Ljava/lang/ref/ReferenceQueue<Lrhino/Script;>;)V")]
      [LineNumberTable(new byte[] {22, 107, 103, 103, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ScriptReference(
        [In] Script obj0,
        [In] string obj1,
        [In] URI obj2,
        [In] URI obj3,
        [In] object obj4,
        [In] ReferenceQueue obj5)
        : base((object) obj0, obj5)
      {
        SoftCachingModuleScriptProvider.ScriptReference scriptReference = this;
        this.moduleId = obj1;
        this.uri = obj2;
        this.@base = obj3;
        this.validator = obj4;
      }

      [LineNumberTable(new byte[] {30, 108, 99, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual CachingModuleScriptProviderBase.CachedModuleScript getCachedModuleScript()
      {
        Script script = (Script) ((Reference) this).get();
        return script == null ? (CachingModuleScriptProviderBase.CachedModuleScript) null : new CachingModuleScriptProviderBase.CachedModuleScript(new ModuleScript(script, this.uri, this.@base), this.validator);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual string getModuleId() => this.moduleId;
    }
  }
}
