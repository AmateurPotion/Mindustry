// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.resolvers.PrefixFileHandleResolver
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders.resolvers
{
  public class PrefixFileHandleResolver : Object, FileHandleResolver
  {
    private string prefix;
    private FileHandleResolver baseResolver;

    [LineNumberTable(new byte[] {159, 157, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PrefixFileHandleResolver(FileHandleResolver baseResolver, string prefix)
    {
      PrefixFileHandleResolver fileHandleResolver = this;
      this.baseResolver = baseResolver;
      this.prefix = prefix;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FileHandleResolver getBaseResolver() => this.baseResolver;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBaseResolver(FileHandleResolver baseResolver) => this.baseResolver = baseResolver;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getPrefix() => this.prefix;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPrefix(string prefix) => this.prefix = prefix;

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi resolve(string fileName) => this.baseResolver.resolve(new StringBuilder().append(this.prefix).append(fileName).toString());
  }
}
