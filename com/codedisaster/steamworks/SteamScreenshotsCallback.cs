// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamScreenshotsCallback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace com.codedisaster.steamworks
{
  public interface SteamScreenshotsCallback
  {
    void onScreenshotReady(SteamScreenshotHandle ssh, SteamResult sr);

    void onScreenshotRequested();
  }
}
