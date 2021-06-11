// Decompiled with JetBrains decompiler
// Type: mindustry.core.FileTree
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets.loaders;
using arc.files;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.core
{
  public class FileTree : Object, FileHandleResolver
  {
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/files/Fi;>;")]
    private ObjectMap files;

    [LineNumberTable(new byte[] {159, 151, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FileTree()
    {
      FileTree fileTree = this;
      this.files = new ObjectMap();
    }

    [LineNumberTable(new byte[] {159, 137, 162, 110, 114, 127, 8, 127, 12, 106, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi get(string path, bool safe)
    {
      int num = safe ? 1 : 0;
      if (this.files.containsKey((object) path))
        return (Fi) this.files.get((object) path);
      if (this.files.containsKey((object) new StringBuilder().append("/").append(path).toString()))
        return (Fi) this.files.get((object) new StringBuilder().append("/").append(path).toString());
      return Core.files == null && num == 0 ? Fi.get(path) : Core.files.@internal(path);
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi get(string path) => this.get(path, false);

    [LineNumberTable(new byte[] {159, 155, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addFile(string path, Fi f) => this.files.put((object) path, (object) f);

    [LineNumberTable(new byte[] {159, 178, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.files.clear();

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi resolve(string fileName) => this.get(fileName);
  }
}
