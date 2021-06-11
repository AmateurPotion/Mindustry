// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.MultiModuleScriptProvider
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.net;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.module.provider
{
  public class MultiModuleScriptProvider : Object, ModuleScriptProvider
  {
    [Modifiers]
    private ModuleScriptProvider[] providers;

    [Signature("(Ljava/lang/Iterable<+Lrhino/module/ModuleScriptProvider;>;)V")]
    [LineNumberTable(new byte[] {159, 164, 104, 102, 123, 104, 98, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MultiModuleScriptProvider(Iterable providers)
    {
      MultiModuleScriptProvider moduleScriptProvider1 = this;
      LinkedList linkedList = new LinkedList();
      Iterator iterator = providers.iterator();
      while (iterator.hasNext())
      {
        ModuleScriptProvider moduleScriptProvider2 = (ModuleScriptProvider) iterator.next();
        ((List) linkedList).add((object) moduleScriptProvider2);
      }
      this.providers = (ModuleScriptProvider[]) ((List) linkedList).toArray((object[]) new ModuleScriptProvider[0]);
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [LineNumberTable(new byte[] {159, 175, 116, 143, 100, 227, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ModuleScript getModuleScript(
      Context cx,
      string moduleId,
      URI uri,
      URI @base,
      Scriptable paths)
    {
      ModuleScriptProvider[] providers = this.providers;
      int length = providers.Length;
      for (int index = 0; index < length; ++index)
      {
        ModuleScript moduleScript = providers[index].getModuleScript(cx, moduleId, uri, @base, paths);
        if (moduleScript != null)
          return moduleScript;
      }
      return (ModuleScript) null;
    }
  }
}
