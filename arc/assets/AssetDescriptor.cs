// Decompiled with JetBrains decompiler
// Type: arc.assets.AssetDescriptor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.func;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.assets
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public class AssetDescriptor : Object
  {
    internal string __\u003C\u003EfileName;
    [Signature("Ljava/lang/Class<TT;>;")]
    internal Class __\u003C\u003Etype;
    internal AssetLoaderParameters __\u003C\u003Eparams;
    public Fi file;
    [Signature("Larc/func/Cons<TT;>;")]
    public Cons loaded;
    [Signature("Larc/func/Cons<Ljava/lang/Throwable;>;")]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Cons errored;

    [Signature("(Ljava/lang/String;Ljava/lang/Class<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 170, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetDescriptor(string fileName, Class assetType)
      : this(fileName, assetType, (AssetLoaderParameters) null)
    {
    }

    [Signature("(Ljava/lang/Class<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 166, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetDescriptor(Class assetType)
      : this(assetType.getSimpleName(), assetType, (AssetLoaderParameters) null)
    {
    }

    [Signature("(Larc/files/Fi;Ljava/lang/Class<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 175, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetDescriptor(Fi file, Class assetType)
      : this(file, assetType, (AssetLoaderParameters) null)
    {
    }

    [Signature("(Ljava/lang/String;Ljava/lang/Class<TT;>;Larc/assets/AssetLoaderParameters<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 178, 232, 47, 144, 231, 80, 118, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetDescriptor(string fileName, Class assetType, AssetLoaderParameters @params)
    {
      AssetDescriptor assetDescriptor = this;
      this.loaded = (Cons) new AssetDescriptor.__\u003C\u003EAnon0();
      this.errored = (Cons) null;
      this.__\u003C\u003EfileName = String.instancehelper_replaceAll(fileName, "\\\\", "/");
      this.__\u003C\u003Etype = assetType;
      this.__\u003C\u003Eparams = @params;
    }

    [Signature("(Larc/files/Fi;Ljava/lang/Class<TT;>;Larc/assets/AssetLoaderParameters<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 185, 232, 40, 144, 231, 87, 123, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetDescriptor(Fi file, Class assetType, AssetLoaderParameters @params)
    {
      AssetDescriptor assetDescriptor = this;
      this.loaded = (Cons) new AssetDescriptor.__\u003C\u003EAnon0();
      this.errored = (Cons) null;
      this.__\u003C\u003EfileName = String.instancehelper_replaceAll(file.path(), "\\\\", "/");
      this.file = file;
      this.__\u003C\u003Etype = assetType;
      this.__\u003C\u003Eparams = @params;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] object obj0)
    {
    }

    [LineNumberTable(new byte[] {2, 159, 1, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(this.__\u003C\u003EfileName).append(", ").append(this.__\u003C\u003Etype.getName()).toString();

    [Modifiers]
    public string fileName
    {
      [HideFromJava] get => this.__\u003C\u003EfileName;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EfileName = value;
    }

    [Modifiers]
    public Class type
    {
      [HideFromJava] get => this.__\u003C\u003Etype;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etype = value;
    }

    [Modifiers]
    public AssetLoaderParameters @params
    {
      [HideFromJava] get => this.__\u003C\u003Eparams;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eparams = value;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => AssetDescriptor.lambda\u0024new\u00240(obj0);
    }
  }
}
