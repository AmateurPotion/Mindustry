// Decompiled with JetBrains decompiler
// Type: mindustry.maps.MapPreviewLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.assets;
using arc.assets.loaders;
using arc.assets.loaders.resolvers;
using arc.files;
using arc.graphics;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.ctype;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace mindustry.maps
{
  public class MapPreviewLoader : TextureLoader
  {
    [LineNumberTable(new byte[] {159, 158, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapPreviewLoader()
      : base((FileHandleResolver) new AbsoluteFileHandleResolver())
    {
    }

    [LineNumberTable(new byte[] {159, 175, 127, 2, 97, 134, 126, 98, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Texture loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      TextureLoader.TextureParameter parameter)
    {
      Texture texture1;
      Exception th1;
      try
      {
        texture1 = base.loadSync(manager, fileName, file, parameter);
      }
      catch (Exception ex)
      {
        th1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_3;
      }
      return texture1;
label_3:
      Log.err(th1);
      Texture texture2;
      Exception th2;
      try
      {
        texture2 = new Texture(file);
      }
      catch (Exception ex)
      {
        th2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_7;
      }
      return texture2;
label_7:
      Log.err(th2);
      return new Texture("sprites/error.png");
    }

    [LineNumberTable(new byte[] {159, 164, 255, 14, 69, 226, 60, 97, 102, 104, 144})]
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
      Log.err((Exception) exception);
      MapPreviewLoader.MapPreviewParameter previewParameter = (MapPreviewLoader.MapPreviewParameter) parameter;
      Vars.maps.queueNewPreview(previewParameter.map);
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/TextureLoader$TextureParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(
      string fileName,
      Fi file,
      TextureLoader.TextureParameter parameter)
    {
      return Seq.with((object[]) new AssetDescriptor[1]
      {
        new AssetDescriptor("contentcreate", (Class) ClassLiteral<Content>.Value)
      });
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (TextureLoader.TextureParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (TextureLoader.TextureParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (TextureLoader.TextureParameter) alp);

    public class MapPreviewParameter : TextureLoader.TextureParameter
    {
      public Map map;

      [LineNumberTable(new byte[] {3, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public MapPreviewParameter(Map map)
      {
        MapPreviewLoader.MapPreviewParameter previewParameter = this;
        this.map = map;
      }
    }
  }
}
