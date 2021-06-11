// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.StrongCachingModuleScriptProvider
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.util;
using java.util.concurrent;
using System.Runtime.CompilerServices;

namespace rhino.module.provider
{
  public class StrongCachingModuleScriptProvider : CachingModuleScriptProviderBase
  {
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/module/provider/CachingModuleScriptProviderBase$CachedModuleScript;>;")]
    private Map modules;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 168, 233, 56, 252, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StrongCachingModuleScriptProvider(ModuleSourceProvider moduleSourceProvider)
      : base(moduleSourceProvider)
    {
      StrongCachingModuleScriptProvider moduleScriptProvider = this;
      ConcurrentHashMap.__\u003Cclinit\u003E();
      this.modules = (Map) new ConcurrentHashMap(16, 0.75f, CachingModuleScriptProviderBase.getConcurrencyLevel());
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override CachingModuleScriptProviderBase.CachedModuleScript getLoadedModule(
      string moduleId)
    {
      return (CachingModuleScriptProviderBase.CachedModuleScript) this.modules.get((object) moduleId);
    }

    [LineNumberTable(new byte[] {159, 179, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void putLoadedModule(
      string moduleId,
      ModuleScript moduleScript,
      object validator)
    {
      this.modules.put((object) moduleId, (object) new CachingModuleScriptProviderBase.CachedModuleScript(moduleScript, validator));
    }

    [HideFromJava]
    static StrongCachingModuleScriptProvider() => CachingModuleScriptProviderBase.__\u003Cclinit\u003E();
  }
}
