// Decompiled with JetBrains decompiler
// Type: mindustry.entities.units.StatusEntry
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.entities.units
{
  public class StatusEntry : Object
  {
    internal static StatusEntry __\u003C\u003Etmp;
    public StatusEffect effect;
    public float time;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual StatusEntry set(StatusEffect effect, float time)
    {
      this.effect = effect;
      this.time = time;
      return this;
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StatusEntry()
    {
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static StatusEntry()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.units.StatusEntry"))
        return;
      StatusEntry.__\u003C\u003Etmp = new StatusEntry();
    }

    [Modifiers]
    public static StatusEntry tmp
    {
      [HideFromJava] get => StatusEntry.__\u003C\u003Etmp;
    }
  }
}
