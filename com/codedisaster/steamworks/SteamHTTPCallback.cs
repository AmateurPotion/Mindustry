// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamHTTPCallback
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

namespace com.codedisaster.steamworks
{
  public interface SteamHTTPCallback
  {
    void onHTTPRequestCompleted(
      SteamHTTPRequestHandle shttprh,
      long l,
      bool b,
      SteamHTTP.HTTPStatusCode shttphttpsc,
      int i);

    void onHTTPRequestHeadersReceived(SteamHTTPRequestHandle shttprh, long l);

    void onHTTPRequestDataReceived(SteamHTTPRequestHandle shttprh, long l, int i1, int i2);
  }
}
