// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SdlFiles
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.backend.sdl
{
  public sealed class SdlFiles : Object, Files
  {
    internal static string __\u003C\u003EexternalPath;
    internal static string __\u003C\u003ElocalPath;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SdlFiles()
    {
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi get(string fileName, Files.FileType type) => (Fi) new SdlFiles.SdlFi(fileName, type);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getExternalStoragePath() => SdlFiles.__\u003C\u003EexternalPath;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isExternalStorageAvailable() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getLocalStoragePath() => SdlFiles.__\u003C\u003ElocalPath;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocalStorageAvailable() => true;

    [LineNumberTable(new byte[] {159, 140, 141, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SdlFiles()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.backend.sdl.SdlFiles"))
        return;
      SdlFiles.__\u003C\u003EexternalPath = new StringBuilder().append(java.lang.System.getProperty("user.home")).append((string) File.separator).toString();
      SdlFiles.__\u003C\u003ElocalPath = new StringBuilder().append(new File("").getAbsolutePath()).append((string) File.separator).toString();
    }

    [HideFromJava]
    public virtual Fi classpath([In] string obj0) => Files.\u003Cdefault\u003Eclasspath((Files) this, obj0);

    [HideFromJava]
    public virtual Fi @internal([In] string obj0) => Files.\u003Cdefault\u003Einternal((Files) this, obj0);

    [HideFromJava]
    public virtual Fi external([In] string obj0) => Files.\u003Cdefault\u003Eexternal((Files) this, obj0);

    [HideFromJava]
    public virtual Fi absolute([In] string obj0) => Files.\u003Cdefault\u003Eabsolute((Files) this, obj0);

    [HideFromJava]
    public virtual Fi local([In] string obj0) => Files.\u003Cdefault\u003Elocal((Files) this, obj0);

    [HideFromJava]
    public virtual Fi cache([In] string obj0) => Files.\u003Cdefault\u003Ecache((Files) this, obj0);

    [HideFromJava]
    public virtual string getCachePath() => Files.\u003Cdefault\u003EgetCachePath((Files) this);

    [Modifiers]
    public static string externalPath
    {
      [HideFromJava] get => SdlFiles.__\u003C\u003EexternalPath;
    }

    [Modifiers]
    public static string localPath
    {
      [HideFromJava] get => SdlFiles.__\u003C\u003ElocalPath;
    }

    public sealed class SdlFi : Fi
    {
      [LineNumberTable(new byte[] {159, 186, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SdlFi(File file, Files.FileType type)
        : base(file, type)
      {
      }

      [LineNumberTable(new byte[] {159, 182, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SdlFi(string fileName, Files.FileType type)
        : base(fileName, type)
      {
      }

      [LineNumberTable(new byte[] {159, 190, 127, 5})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Fi child(string name)
      {
        if (String.instancehelper_length(this.file.getPath()) == 0)
          return (Fi) new SdlFiles.SdlFi(new File(name), this.type);
        File.__\u003Cclinit\u003E();
        return (Fi) new SdlFiles.SdlFi(new File(this.file, name), this.type);
      }

      [LineNumberTable(new byte[] {3, 127, 3})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Fi sibling(string name)
      {
        if (String.instancehelper_length(this.file.getPath()) == 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Cannot get the sibling of the root.");
        }
        File.__\u003Cclinit\u003E();
        return (Fi) new SdlFiles.SdlFi(new File(this.file.getParent(), name), this.type);
      }

      [LineNumberTable(new byte[] {8, 127, 14, 127, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override File file()
      {
        if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eexternal))
        {
          File.__\u003Cclinit\u003E();
          return new File(SdlFiles.__\u003C\u003EexternalPath, this.file.getPath());
        }
        if (!object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Elocal))
          return this.file;
        File.__\u003Cclinit\u003E();
        return new File(SdlFiles.__\u003C\u003ElocalPath, this.file.getPath());
      }
    }
  }
}
