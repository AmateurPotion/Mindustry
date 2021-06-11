// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamNetworkingCallback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace com.codedisaster.steamworks
{
  public interface SteamNetworkingCallback
  {
    void onP2PSessionConnectFail(SteamID sid, SteamNetworking.P2PSessionError snppse);

    void onP2PSessionRequest(SteamID sid);
  }
}
