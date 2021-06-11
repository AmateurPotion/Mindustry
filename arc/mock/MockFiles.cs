// Decompiled with JetBrains decompiler
// Type: arc.mock.MockFiles
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using java.io;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.mock
{
  public class MockFiles : Object, Files
  {
    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MockFiles()
    {
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi get(string fileName, Files.FileType type) => new Fi(fileName, type);

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getExternalStoragePath() => new StringBuilder().append(java.lang.System.getProperty("user.home")).append((string) File.separator).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isExternalStorageAvailable() => true;

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getLocalStoragePath() => new StringBuilder().append(new File("").getAbsolutePath()).append((string) File.separator).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLocalStorageAvailable() => true;

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
  }
}
