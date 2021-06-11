// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.I18NBundleLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.util;
using IKVM.Attributes;
using java.util;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.assets.loaders
{
  [Signature("Larc/assets/loaders/AsynchronousAssetLoader<Larc/util/I18NBundle;Larc/assets/loaders/I18NBundleLoader$I18NBundleParameter;>;")]
  public class I18NBundleLoader : AsynchronousAssetLoader
  {
    internal I18NBundle bundle;

    [LineNumberTable(new byte[] {159, 178, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public I18NBundleLoader(FileHandleResolver resolver)
      : base(resolver)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual I18NBundle loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      I18NBundleLoader.I18NBundleParameter parameter)
    {
      I18NBundle bundle = this.bundle;
      this.bundle = (I18NBundle) null;
      return bundle;
    }

    [LineNumberTable(new byte[] {159, 183, 167, 100, 102, 132, 120, 136, 99, 143, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      I18NBundleLoader.I18NBundleParameter parameter)
    {
      this.bundle = (I18NBundle) null;
      Locale locale;
      string encoding;
      if (parameter == null)
      {
        locale = Locale.getDefault();
        encoding = (string) null;
      }
      else
      {
        locale = parameter.__\u003C\u003Elocale != null ? parameter.__\u003C\u003Elocale : Locale.getDefault();
        encoding = parameter.__\u003C\u003Eencoding;
      }
      if (encoding == null)
        this.bundle = I18NBundle.createBundle(file, locale);
      else
        this.bundle = I18NBundle.createBundle(file, locale, encoding);
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/I18NBundleLoader$I18NBundleParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      I18NBundleLoader.I18NBundleParameter parameter)
    {
      return (Seq) null;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (I18NBundleLoader.I18NBundleParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (I18NBundleLoader.I18NBundleParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (I18NBundleLoader.I18NBundleParameter) alp);

    [Signature("Larc/assets/AssetLoaderParameters<Larc/util/I18NBundle;>;")]
    public class I18NBundleParameter : AssetLoaderParameters
    {
      internal Locale __\u003C\u003Elocale;
      internal string __\u003C\u003Eencoding;

      [LineNumberTable(new byte[] {32, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public I18NBundleParameter(Locale locale, string encoding)
      {
        I18NBundleLoader.I18NBundleParameter nbundleParameter = this;
        this.__\u003C\u003Elocale = locale;
        this.__\u003C\u003Eencoding = encoding;
      }

      [LineNumberTable(new byte[] {25, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public I18NBundleParameter()
        : this((Locale) null, (string) null)
      {
      }

      [LineNumberTable(new byte[] {29, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public I18NBundleParameter(Locale locale)
        : this(locale, (string) null)
      {
      }

      [Modifiers]
      public Locale locale
      {
        [HideFromJava] get => this.__\u003C\u003Elocale;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Elocale = value;
      }

      [Modifiers]
      public string encoding
      {
        [HideFromJava] get => this.__\u003C\u003Eencoding;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eencoding = value;
      }
    }
  }
}
