// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamScreenshotsCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamScreenshotsCallback;>;")]
  public class SteamScreenshotsCallbackAdapter : SteamCallbackAdapter
  {
    [LineNumberTable(new byte[] {159, 149, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamScreenshotsCallbackAdapter([In] SteamScreenshotsCallback obj0)
      : base((object) obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 153, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onScreenshotReady([In] int obj0, [In] int obj1) => ((SteamScreenshotsCallback) this.callback).onScreenshotReady(new SteamScreenshotHandle(obj0), SteamResult.byValue(obj1));

    [LineNumberTable(new byte[] {159, 157, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onScreenshotRequested() => ((SteamScreenshotsCallback) this.callback).onScreenshotRequested();

    [HideFromJava]
    protected internal object callback
    {
      [HideFromJava] get => this.callback;
    }
  }
}
