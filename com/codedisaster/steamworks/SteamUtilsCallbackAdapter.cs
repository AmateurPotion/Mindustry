// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamUtilsCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamUtilsCallback;>;")]
  internal class SteamUtilsCallbackAdapter : SteamCallbackAdapter
  {
    private SteamAPIWarningMessageHook messageHook;

    [LineNumberTable(new byte[] {159, 151, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamUtilsCallbackAdapter([In] SteamUtilsCallback obj0)
      : base((object) obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setWarningMessageHook([In] SteamAPIWarningMessageHook obj0) => this.messageHook = obj0;

    [LineNumberTable(new byte[] {159, 159, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onWarningMessage([In] int obj0, [In] string obj1)
    {
      if (this.messageHook == null)
        return;
      this.messageHook.onWarningMessage(obj0, obj1);
    }

    [LineNumberTable(new byte[] {159, 165, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onSteamShutdown() => ((SteamUtilsCallback) this.callback).onSteamShutdown();
  }
}
