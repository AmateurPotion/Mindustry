// Decompiled with JetBrains decompiler
// Type: rhino.module.ModuleScope
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.net;
using System.Runtime.CompilerServices;

namespace rhino.module
{
  public class ModuleScope : TopLevel
  {
    [Modifiers]
    private URI uri;
    [Modifiers]
    private URI @base;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 104, 103, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ModuleScope(Scriptable prototype, URI uri, URI @base)
    {
      ModuleScope moduleScope = this;
      this.uri = uri;
      this.@base = @base;
      this.setPrototype(prototype);
      this.cacheBuiltins(prototype, false);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual URI getUri() => this.uri;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual URI getBase() => this.@base;

    [HideFromJava]
    static ModuleScope() => TopLevel.__\u003Cclinit\u003E();
  }
}
