// Decompiled with JetBrains decompiler
// Type: mindustry.net.ValidateException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class ValidateException : RuntimeException
  {
    internal Player __\u003C\u003Eplayer;

    [LineNumberTable(new byte[] {159, 154, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ValidateException(Player player, string s)
      : base(s)
    {
      ValidateException validateException = this;
      this.__\u003C\u003Eplayer = player;
    }

    [Modifiers]
    public Player player
    {
      [HideFromJava] get => this.__\u003C\u003Eplayer;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eplayer = value;
    }
  }
}
