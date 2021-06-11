// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamMatchmakingCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamMatchmakingCallback;>;")]
  internal class SteamMatchmakingCallbackAdapter : SteamCallbackAdapter
  {
    [Modifiers]
    private static SteamMatchmaking.ChatMemberStateChange[] stateChangeValues;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 152, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamMatchmakingCallbackAdapter([In] SteamMatchmakingCallback obj0)
      : base((object) obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 139, 131, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onFavoritesListChanged(
      [In] int obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] bool obj5,
      [In] int obj6)
    {
      int num = obj5 ? 1 : 0;
      ((SteamMatchmakingCallback) this.callback).onFavoritesListChanged(obj0, obj1, obj2, obj3, obj4, num != 0, obj6);
    }

    [LineNumberTable(new byte[] {159, 160, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLobbyInvite([In] long obj0, [In] long obj1, [In] long obj2) => ((SteamMatchmakingCallback) this.callback).onLobbyInvite(new SteamID(obj0), new SteamID(obj1), obj2);

    [LineNumberTable(new byte[] {159, 137, 130, 117, 37, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLobbyEnter([In] long obj0, [In] int obj1, [In] bool obj2, [In] int obj3)
    {
      int num = obj2 ? 1 : 0;
      ((SteamMatchmakingCallback) this.callback).onLobbyEnter(new SteamID(obj0), obj1, num != 0, SteamMatchmaking.ChatRoomEnterResponse.byValue(obj3));
    }

    [LineNumberTable(new byte[] {159, 136, 162, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLobbyDataUpdate([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      ((SteamMatchmakingCallback) this.callback).onLobbyDataUpdate(new SteamID(obj0), new SteamID(obj1), num != 0);
    }

    [LineNumberTable(new byte[] {159, 173, 103, 103, 103, 121, 107, 21, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLobbyChatUpdate([In] long obj0, [In] long obj1, [In] long obj2, [In] int obj3)
    {
      SteamID sid1 = new SteamID(obj0);
      SteamID sid2 = new SteamID(obj1);
      SteamID sid3 = new SteamID(obj2);
      SteamMatchmaking.ChatMemberStateChange[] stateChangeValues = SteamMatchmakingCallbackAdapter.stateChangeValues;
      int length = stateChangeValues.Length;
      for (int index = 0; index < length; ++index)
      {
        SteamMatchmaking.ChatMemberStateChange smcmsc = stateChangeValues[index];
        if (SteamMatchmaking.ChatMemberStateChange.isSet(smcmsc, obj3))
          ((SteamMatchmakingCallback) this.callback).onLobbyChatUpdate(sid1, sid2, sid3, smcmsc);
      }
    }

    [LineNumberTable(new byte[] {159, 184, 120, 39, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLobbyChatMessage([In] long obj0, [In] long obj1, [In] int obj2, [In] int obj3) => ((SteamMatchmakingCallback) this.callback).onLobbyChatMessage(new SteamID(obj0), new SteamID(obj1), SteamMatchmaking.ChatEntryType.byValue(obj2), obj3);

    [LineNumberTable(new byte[] {159, 131, 163, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLobbyGameCreated([In] long obj0, [In] long obj1, [In] int obj2, [In] short obj3)
    {
      int num = (int) obj3;
      ((SteamMatchmakingCallback) this.callback).onLobbyGameCreated(new SteamID(obj0), new SteamID(obj1), obj2, (short) num);
    }

    [LineNumberTable(new byte[] {1, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLobbyMatchList([In] int obj0) => ((SteamMatchmakingCallback) this.callback).onLobbyMatchList(obj0);

    [LineNumberTable(new byte[] {159, 129, 162, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLobbyKicked([In] long obj0, [In] long obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      ((SteamMatchmakingCallback) this.callback).onLobbyKicked(new SteamID(obj0), new SteamID(obj1), num != 0);
    }

    [LineNumberTable(new byte[] {9, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onLobbyCreated([In] int obj0, [In] long obj1) => ((SteamMatchmakingCallback) this.callback).onLobbyCreated(SteamResult.byValue(obj0), new SteamID(obj1));

    [LineNumberTable(new byte[] {13, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onFavoritesListAccountsUpdated([In] int obj0) => ((SteamMatchmakingCallback) this.callback).onFavoritesListAccountsUpdated(SteamResult.byValue(obj0));

    [LineNumberTable(new byte[] {159, 141, 173, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SteamMatchmakingCallbackAdapter()
    {
      if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamMatchmakingCallbackAdapter"))
        return;
      SteamMatchmakingCallbackAdapter.stateChangeValues = SteamMatchmaking.ChatMemberStateChange.values();
    }
  }
}
