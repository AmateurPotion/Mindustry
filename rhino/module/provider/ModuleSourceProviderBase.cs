// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.ModuleSourceProviderBase
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.module.provider
{
  public abstract class ModuleSourceProviderBase : Object, ModuleSourceProvider
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool entityNeedsRevalidation(object validator) => true;

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual ModuleSource loadFromPrivilegedLocations(
      string moduleId,
      object validator)
    {
      return (ModuleSource) null;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 190, 102, 37, 166, 179, 105, 103, 42, 166, 104, 105, 151, 100, 40, 135, 100, 223, 2, 2, 98, 242, 50, 233, 81})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ModuleSource loadFromPathArray([In] string obj0, [In] Scriptable obj1, [In] object obj2)
    {
      long uint32 = ScriptRuntime.toUint32(ScriptableObject.getProperty(obj1, "length"));
      int num = uint32 <= (long) int.MaxValue ? (int) uint32 : int.MaxValue;
      for (int index = 0; index < num; ++index)
      {
        string str = ModuleSourceProviderBase.ensureTrailingSlash((string) ScriptableObject.getTypedProperty(obj1, index, (Class) ClassLiteral<String>.Value));
        ModuleSource moduleSource1;
        URISyntaxException uriSyntaxException;
        try
        {
          URI uri2 = new URI(str);
          if (!uri2.isAbsolute())
            uri2 = new File(str).toURI().resolve("");
          ModuleSource moduleSource2 = this.loadFromUri(uri2.resolve(obj0), uri2, obj2);
          if (moduleSource2 != null)
            moduleSource1 = moduleSource2;
          else
            continue;
        }
        catch (URISyntaxException ex)
        {
          uriSyntaxException = (URISyntaxException) ByteCodeHelper.MapException<URISyntaxException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_9;
        }
        return moduleSource1;
label_9:
        string message = uriSyntaxException.getMessage();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new MalformedURLException(message);
      }
      return (ModuleSource) null;
    }

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual ModuleSource loadFromFallbackLocations(
      string moduleId,
      object validator)
    {
      return (ModuleSource) null;
    }

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    protected internal abstract ModuleSource loadFromUri(
      URI uri1,
      URI uri2,
      object obj);

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string ensureTrailingSlash([In] string obj0) => String.instancehelper_endsWith(obj0, "/") ? obj0 : String.instancehelper_concat(obj0, "/");

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ModuleSourceProviderBase()
    {
    }

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    [LineNumberTable(new byte[] {159, 165, 105, 166, 105, 99, 130, 99, 106, 99, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ModuleSource loadSource(
      string moduleId,
      Scriptable paths,
      object validator)
    {
      if (!this.entityNeedsRevalidation(validator))
        return ModuleSourceProvider.NOT_MODIFIED;
      ModuleSource moduleSource1 = this.loadFromPrivilegedLocations(moduleId, validator);
      if (moduleSource1 != null)
        return moduleSource1;
      if (paths != null)
      {
        ModuleSource moduleSource2 = this.loadFromPathArray(moduleId, paths, validator);
        if (moduleSource2 != null)
          return moduleSource2;
      }
      return this.loadFromFallbackLocations(moduleId, validator);
    }

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ModuleSource loadSource(URI uri, URI @base, object validator) => this.loadFromUri(uri, @base, validator);
  }
}
