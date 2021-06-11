// Decompiled with JetBrains decompiler
// Type: mindustry.entities.Leg
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities
{
  public class Leg : Object
  {
    internal Vec2 __\u003C\u003Ejoint;
    internal Vec2 __\u003C\u003Ebase;
    public int group;
    public bool moving;
    public float stage;

    [LineNumberTable(new byte[] {159, 147, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Leg()
    {
      Leg leg = this;
      this.__\u003C\u003Ejoint = new Vec2();
      this.__\u003C\u003Ebase = new Vec2();
    }

    [Modifiers]
    public Vec2 joint
    {
      [HideFromJava] get => this.__\u003C\u003Ejoint;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ejoint = value;
    }

    [Modifiers]
    public Vec2 @base
    {
      [HideFromJava] get => this.__\u003C\u003Ebase;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ebase = value;
    }
  }
}
