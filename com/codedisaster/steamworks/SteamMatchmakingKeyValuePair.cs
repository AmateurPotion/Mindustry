// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamMatchmakingKeyValuePair
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.codedisaster.steamworks
{
  public class SteamMatchmakingKeyValuePair : Object
  {
    private string key;
    private string value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getKey() => this.key;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getValue() => this.value;

    [LineNumberTable(new byte[] {159, 150, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamMatchmakingKeyValuePair()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamMatchmakingKeyValuePair(string key, string value)
    {
      SteamMatchmakingKeyValuePair matchmakingKeyValuePair = this;
      this.key = key;
      this.value = value;
    }
  }
}
