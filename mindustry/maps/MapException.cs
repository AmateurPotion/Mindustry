// Decompiled with JetBrains decompiler
// Type: mindustry.maps.MapException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.maps
{
  public class MapException : RuntimeException
  {
    internal Map __\u003C\u003Emap;

    [LineNumberTable(new byte[] {159, 149, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapException(Map map, string s)
      : base(s)
    {
      MapException mapException = this;
      this.__\u003C\u003Emap = map;
    }

    [Modifiers]
    public Map map
    {
      [HideFromJava] get => this.__\u003C\u003Emap;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emap = value;
    }
  }
}
