// Decompiled with JetBrains decompiler
// Type: club.minnced.discord.rpc.DiscordRPC
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using com.sun.jna;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace club.minnced.discord.rpc
{
  [Implements(new string[] {"com.sun.jna.Library"})]
  public interface DiscordRPC : Library
  {
    static readonly DiscordRPC INSTANCE;
    const int DISCORD_REPLY_NO = 0;
    const int DISCORD_REPLY_YES = 1;
    const int DISCORD_REPLY_IGNORE = 2;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void __\u003Cclinit\u003E()
    {
    }

    void Discord_Initialize([DynamicAnnotation(new object[] {64, "Ljavax/annotation/Nonnull;"})] string str1, [DynamicAnnotation(new object[] {64, "Ljavax/annotation/Nullable;"})] DiscordEventHandlers deh, bool b, [DynamicAnnotation(new object[] {64, "Ljavax/annotation/Nullable;"})] string str2);

    void Discord_UpdatePresence([DynamicAnnotation(new object[] {64, "Ljavax/annotation/Nullable;"})] DiscordRichPresence drp);

    void Discord_Shutdown();

    void Discord_RunCallbacks();

    void Discord_UpdateConnection();

    void Discord_ClearPresence();

    void Discord_Respond([DynamicAnnotation(new object[] {64, "Ljavax/annotation/Nonnull;"})] string str, int i);

    void Discord_UpdateHandlers([DynamicAnnotation(new object[] {64, "Ljavax/annotation/Nullable;"})] DiscordEventHandlers deh);

    void Discord_Register(string str1, string str2);

    void Discord_RegisterSteamGame(string str1, string str2);

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static DiscordRPC()
    {
      if (ByteCodeHelper.isAlreadyInited("club.minnced.discord.rpc.DiscordRPC"))
        return;
      DiscordRPC.INSTANCE = (DiscordRPC) Native.loadLibrary("discord-rpc", (Class) ClassLiteral<DiscordRPC>.Value);
    }

    [HideFromJava]
    new static class __Fields
    {
      public static readonly DiscordRPC INSTANCE = DiscordRPC.INSTANCE;
      public const int DISCORD_REPLY_NO = 0;
      public const int DISCORD_REPLY_YES = 1;
      public const int DISCORD_REPLY_IGNORE = 2;
    }
  }
}
