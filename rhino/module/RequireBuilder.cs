// Decompiled with JetBrains decompiler
// Type: rhino.module.RequireBuilder
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino.module
{
  public class RequireBuilder : Object
  {
    private bool sandboxed;
    private ModuleScriptProvider moduleScriptProvider;
    private Script preExec;
    private Script postExec;

    [LineNumberTable(new byte[] {159, 157, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RequireBuilder()
    {
      RequireBuilder requireBuilder = this;
      this.sandboxed = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual RequireBuilder setModuleScriptProvider(
      ModuleScriptProvider moduleScriptProvider)
    {
      this.moduleScriptProvider = moduleScriptProvider;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual RequireBuilder setSandboxed(bool sandboxed)
    {
      this.sandboxed = sandboxed;
      return this;
    }

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Require createRequire(Context cx, Scriptable globalScope)
    {
      Require.__\u003Cclinit\u003E();
      return new Require(cx, globalScope, this.moduleScriptProvider, this.preExec, this.postExec, this.sandboxed);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual RequireBuilder setPostExec(Script postExec)
    {
      this.postExec = postExec;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual RequireBuilder setPreExec(Script preExec)
    {
      this.preExec = preExec;
      return this;
    }
  }
}
