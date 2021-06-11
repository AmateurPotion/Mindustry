// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamControllerDigitalActionData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.codedisaster.steamworks
{
  public class SteamControllerDigitalActionData : Object
  {
    internal bool state;
    internal bool active;

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamControllerDigitalActionData()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getState() => this.state;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getActive() => this.active;
  }
}
