// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamControllerAnalogActionData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.codedisaster.steamworks
{
  public class SteamControllerAnalogActionData : Object
  {
    internal int mode;
    internal float x;
    internal float y;
    internal bool active;

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamControllerAnalogActionData()
    {
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SteamController.SourceMode getMode() => SteamController.SourceMode.byOrdinal(this.mode);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getActive() => this.active;
  }
}
