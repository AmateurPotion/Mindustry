// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUserCallback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace com.codedisaster.steamworks
{
  public interface SteamUserCallback
  {
    void onValidateAuthTicket(SteamID sid1, SteamAuth.AuthSessionResponse saasr, SteamID sid2);

    void onMicroTxnAuthorization(int i, long l, bool b);

    void onEncryptedAppTicket(SteamResult sr);
  }
}
