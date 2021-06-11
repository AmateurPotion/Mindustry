// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamControllerMotionData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.codedisaster.steamworks
{
  public class SteamControllerMotionData : Object
  {
    internal float[] data;

    [LineNumberTable(new byte[] {159, 145, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamControllerMotionData()
    {
      SteamControllerMotionData controllerMotionData = this;
      this.data = new float[10];
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotQuatX() => this.data[0];

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotQuatY() => this.data[1];

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotQuatZ() => this.data[2];

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotQuatW() => this.data[3];

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPosAccelX() => this.data[4];

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPosAccelY() => this.data[5];

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPosAccelZ() => this.data[6];

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotVelX() => this.data[7];

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotVelY() => this.data[8];

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getRotVelZ() => this.data[9];
  }
}
