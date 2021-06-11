// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.ModuleSource
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using java.lang;
using java.net;
using System.Runtime.CompilerServices;

namespace rhino.module.provider
{
  public class ModuleSource : Object
  {
    [Modifiers]
    private Reader reader;
    [Modifiers]
    private object securityDomain;
    [Modifiers]
    private URI uri;
    [Modifiers]
    private URI @base;
    [Modifiers]
    private object validator;

    [LineNumberTable(new byte[] {159, 187, 104, 103, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ModuleSource(
      Reader reader,
      object securityDomain,
      URI uri,
      URI @base,
      object validator)
    {
      ModuleSource moduleSource = this;
      this.reader = reader;
      this.securityDomain = securityDomain;
      this.uri = uri;
      this.@base = @base;
      this.validator = validator;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Reader getReader() => this.reader;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual URI getUri() => this.uri;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getSecurityDomain() => this.securityDomain;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual URI getBase() => this.@base;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getValidator() => this.validator;
  }
}
