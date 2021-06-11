// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.ModuleSourceProvider
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.net;
using System.Runtime.CompilerServices;

namespace rhino.module.provider
{
  public interface ModuleSourceProvider
  {
    static readonly ModuleSource NOT_MODIFIED;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void __\u003Cclinit\u003E()
    {
    }

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    ModuleSource loadSource(string str, Scriptable s, object obj);

    [Throws(new string[] {"java.io.IOException", "java.net.URISyntaxException"})]
    ModuleSource loadSource(URI uri1, URI uri2, object obj);

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ModuleSourceProvider()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.module.provider.ModuleSourceProvider"))
        return;
      ModuleSourceProvider.NOT_MODIFIED = new ModuleSource((Reader) null, (object) null, (URI) null, (URI) null, (object) null);
    }

    [HideFromJava]
    static class __Fields
    {
      public static readonly ModuleSource NOT_MODIFIED = ModuleSourceProvider.NOT_MODIFIED;
    }
  }
}
