// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.resolvers.ExternalFileHandleResolver
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders.resolvers
{
  public class ExternalFileHandleResolver : Object, FileHandleResolver
  {
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExternalFileHandleResolver()
    {
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi resolve(string fileName) => Core.files.external(fileName);
  }
}
