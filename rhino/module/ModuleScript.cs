// Decompiled with JetBrains decompiler
// Type: rhino.module.ModuleScript
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.net;
using System.Runtime.CompilerServices;

namespace rhino.module
{
  public class ModuleScript : Object
  {
    [Modifiers]
    private Script script;
    [Modifiers]
    private URI uri;
    [Modifiers]
    private URI @base;

    [LineNumberTable(new byte[] {159, 167, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ModuleScript(Script script, URI uri, URI @base)
    {
      ModuleScript moduleScript = this;
      this.script = script;
      this.uri = uri;
      this.@base = @base;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Script getScript() => this.script;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual URI getUri() => this.uri;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual URI getBase() => this.@base;

    [LineNumberTable(new byte[] {12, 156, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSandboxed() => this.@base != null && this.uri != null && !this.@base.relativize(this.uri).isAbsolute();
  }
}
