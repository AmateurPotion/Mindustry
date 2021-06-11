// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamFriendsCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("Lcom/codedisaster/steamworks/SteamCallbackAdapter<Lcom/codedisaster/steamworks/SteamFriendsCallback;>;")]
  internal class SteamFriendsCallbackAdapter : SteamCallbackAdapter
  {
    [Modifiers]
    private static SteamFriends.PersonaChange[] personaChangeValues;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamFriendsCallbackAdapter([In] SteamFriendsCallback obj0)
      : base((object) obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 139, 100, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onSetPersonaNameResponse([In] bool obj0, [In] bool obj1, [In] int obj2) => ((SteamFriendsCallback) this.callback).onSetPersonaNameResponse(obj0, obj1, SteamResult.byValue(obj2));

    [LineNumberTable(new byte[] {159, 159, 103, 116, 106, 19, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onPersonaStateChange([In] long obj0, [In] int obj1)
    {
      SteamID sid = new SteamID(obj0);
      SteamFriends.PersonaChange[] personaChangeValues = SteamFriendsCallbackAdapter.personaChangeValues;
      int length = personaChangeValues.Length;
      for (int index = 0; index < length; ++index)
      {
        SteamFriends.PersonaChange sfpc = personaChangeValues[index];
        if (SteamFriends.PersonaChange.isSet(sfpc, obj1))
          ((SteamFriendsCallback) this.callback).onPersonaStateChange(sid, sfpc);
      }
    }

    [LineNumberTable(new byte[] {159, 136, 130, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onGameOverlayActivated([In] bool obj0) => ((SteamFriendsCallback) this.callback).onGameOverlayActivated(obj0);

    [LineNumberTable(new byte[] {159, 172, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onGameLobbyJoinRequested([In] long obj0, [In] long obj1) => ((SteamFriendsCallback) this.callback).onGameLobbyJoinRequested(new SteamID(obj0), new SteamID(obj1));

    [LineNumberTable(new byte[] {159, 176, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onAvatarImageLoaded([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3) => ((SteamFriendsCallback) this.callback).onAvatarImageLoaded(new SteamID(obj0), obj1, obj2, obj3);

    [LineNumberTable(new byte[] {159, 180, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onFriendRichPresenceUpdate([In] long obj0, [In] int obj1) => ((SteamFriendsCallback) this.callback).onFriendRichPresenceUpdate(new SteamID(obj0), obj1);

    [LineNumberTable(new byte[] {159, 184, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onGameRichPresenceJoinRequested([In] long obj0, [In] string obj1) => ((SteamFriendsCallback) this.callback).onGameRichPresenceJoinRequested(new SteamID(obj0), obj1);

    [LineNumberTable(new byte[] {159, 188, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void onGameServerChangeRequested([In] string obj0, [In] string obj1) => ((SteamFriendsCallback) this.callback).onGameServerChangeRequested(obj0, obj1);

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SteamFriendsCallbackAdapter()
    {
      if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamFriendsCallbackAdapter"))
        return;
      SteamFriendsCallbackAdapter.personaChangeValues = SteamFriends.PersonaChange.values();
    }
  }
}
