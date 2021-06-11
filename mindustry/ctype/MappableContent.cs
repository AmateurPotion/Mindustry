// Decompiled with JetBrains decompiler
// Type: mindustry.ctype.MappableContent
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ctype
{
  public abstract class MappableContent : Content
  {
    internal string __\u003C\u003Ename;

    [LineNumberTable(new byte[] {159, 150, 104, 113, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MappableContent(string name)
    {
      MappableContent mappableContent = this;
      this.__\u003C\u003Ename = Vars.content.transformName(name);
      Vars.content.handleMappableContent(this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => this.__\u003C\u003Ename;

    [Modifiers]
    public string name
    {
      [HideFromJava] get => this.__\u003C\u003Ename;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ename = value;
    }
  }
}
