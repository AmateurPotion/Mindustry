// Decompiled with JetBrains decompiler
// Type: arc.assets.loaders.ShaderProgramLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace arc.assets.loaders
{
  [Signature("Larc/assets/loaders/AsynchronousAssetLoader<Larc/graphics/gl/Shader;Larc/assets/loaders/ShaderProgramLoader$ShaderProgramParameter;>;")]
  public class ShaderProgramLoader : AsynchronousAssetLoader
  {
    private string vertexFileSuffix;
    private string fragmentFileSuffix;

    [LineNumberTable(new byte[] {159, 171, 233, 60, 107, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShaderProgramLoader(FileHandleResolver resolver)
      : base(resolver)
    {
      ShaderProgramLoader shaderProgramLoader = this;
      this.vertexFileSuffix = ".vert";
      this.fragmentFileSuffix = ".frag";
    }

    [LineNumberTable(new byte[] {159, 191, 100, 100, 113, 145, 113, 159, 21, 113, 159, 21, 110, 110, 104, 117, 100, 127, 9, 191, 9, 107, 118, 191, 28})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Shader loadSync(
      AssetManager manager,
      string fileName,
      Fi file,
      ShaderProgramLoader.ShaderProgramParameter parameter)
    {
      string fileName1 = (string) null;
      string fileName2 = (string) null;
      if (parameter != null)
      {
        if (parameter.vertexFile != null)
          fileName1 = parameter.vertexFile;
        if (parameter.fragmentFile != null)
          fileName2 = parameter.fragmentFile;
      }
      if (fileName1 == null && String.instancehelper_endsWith(fileName, this.fragmentFileSuffix))
        fileName1 = new StringBuilder().append(String.instancehelper_substring(fileName, 0, String.instancehelper_length(fileName) - String.instancehelper_length(this.fragmentFileSuffix))).append(this.vertexFileSuffix).toString();
      if (fileName2 == null && String.instancehelper_endsWith(fileName, this.vertexFileSuffix))
        fileName2 = new StringBuilder().append(String.instancehelper_substring(fileName, 0, String.instancehelper_length(fileName) - String.instancehelper_length(this.vertexFileSuffix))).append(this.fragmentFileSuffix).toString();
      Fi fi1 = fileName1 != null ? this.resolve(fileName1) : file;
      Fi fi2 = fileName2 != null ? this.resolve(fileName2) : file;
      string vertexShader = fi1.readString();
      string fragmentShader = !fi1.equals((object) fi2) ? fi2.readString() : vertexShader;
      if (parameter != null)
      {
        if (parameter.prependVertexCode != null)
          vertexShader = new StringBuilder().append(parameter.prependVertexCode).append(vertexShader).toString();
        if (parameter.prependFragmentCode != null)
          fragmentShader = new StringBuilder().append(parameter.prependFragmentCode).append(fragmentShader).toString();
      }
      Shader shader = new Shader(vertexShader, fragmentShader);
      if ((parameter == null || parameter.logOnCompileFailure) && !shader.isCompiled())
        Log.err(new StringBuilder().append("Shader ").append(fileName).append(" failed to compile:\n").append(shader.getLog()).toString());
      return shader;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadAsync(
      AssetManager manager,
      string fileName,
      Fi file,
      ShaderProgramLoader.ShaderProgramParameter parameter)
    {
    }

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/loaders/ShaderProgramLoader$ShaderProgramParameter;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(
      string fileName,
      Fi file,
      ShaderProgramLoader.ShaderProgramParameter parameter)
    {
      return (Seq) null;
    }

    [LineNumberTable(new byte[] {159, 175, 233, 56, 107, 235, 72, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ShaderProgramLoader(
      FileHandleResolver resolver,
      string vertexFileSuffix,
      string fragmentFileSuffix)
      : base(resolver)
    {
      ShaderProgramLoader shaderProgramLoader = this;
      this.vertexFileSuffix = ".vert";
      this.fragmentFileSuffix = ".frag";
      this.vertexFileSuffix = vertexFileSuffix;
      this.fragmentFileSuffix = fragmentFileSuffix;
    }

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object loadSync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => (object) this.loadSync(am, str, f, (ShaderProgramLoader.ShaderProgramParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void loadAsync(AssetManager am, string str, Fi f, AssetLoaderParameters alp) => this.loadAsync(am, str, f, (ShaderProgramLoader.ShaderProgramParameter) alp);

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getDependencies(string str, Fi f, AssetLoaderParameters alp) => this.getDependencies(str, f, (ShaderProgramLoader.ShaderProgramParameter) alp);

    [Signature("Larc/assets/AssetLoaderParameters<Larc/graphics/gl/Shader;>;")]
    public class ShaderProgramParameter : AssetLoaderParameters
    {
      public string vertexFile;
      public string fragmentFile;
      public bool logOnCompileFailure;
      public string prependVertexCode;
      public string prependFragmentCode;

      [LineNumberTable(new byte[] {27, 232, 76})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ShaderProgramParameter()
      {
        ShaderProgramLoader.ShaderProgramParameter programParameter = this;
        this.logOnCompileFailure = true;
      }
    }
  }
}
