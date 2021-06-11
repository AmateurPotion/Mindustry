// Decompiled with JetBrains decompiler
// Type: mindustry.io.SavePreviewLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.assets;
using arc.assets.loaders;
using arc.assets.loaders.resolvers;
using arc.files;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace mindustry.io
{
  public class SavePreviewLoader : TextureLoader
  {
    [LineNumberTable(new byte[] {159, 153, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SavePreviewLoader()
      : base((FileHandleResolver) new AbsoluteFileHandleResolver())
    {
    }

    [LineNumberTable(new byte[] {159, 159, 223, 14, 226, 61, 97, 102, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      TextureLoader.TextureParameter parameter)
    {
      Exception exception;
      try
      {
        base.loadAsync(manager, fileName, file.sibling(file.nameWithoutExtension()), parameter);
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception = (Exception) m0;
      }
      Throwable.instancehelper_printStackTrace((Exception) exception);
      file.sibling(file.nameWithoutExtension()).delete();
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (TextureLoader.TextureParameter) alp);
  }
}
