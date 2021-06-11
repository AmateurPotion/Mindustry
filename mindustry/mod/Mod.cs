// Decompiled with JetBrains decompiler
// Type: mindustry.mod.Mod
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.mod
{
  public class Mod : Object
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void registerClientCommands(CommandHandler handler)
    {
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Mod()
    {
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi getConfig() => Vars.mods.getConfig(this);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loadContent()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void registerServerCommands(CommandHandler handler)
    {
    }
  }
}
