// Decompiled with JetBrains decompiler
// Type: mindustry.type.Satellite
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.type
{
  public class Satellite : Object
  {
    public Planet planet;

    [LineNumberTable(new byte[] {159, 149, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Satellite(Planet orbiting)
    {
      Satellite satellite = this;
      this.planet = orbiting;
    }
  }
}
