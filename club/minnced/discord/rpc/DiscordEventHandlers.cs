// Decompiled with JetBrains decompiler
// Type: club.minnced.discord.rpc.DiscordEventHandlers
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using com.sun.jna;
using IKVM.Attributes;
using IKVM.Runtime;
using java.util;
using System.Runtime.CompilerServices;

namespace club.minnced.discord.rpc
{
  public class DiscordEventHandlers : Structure
  {
    [Modifiers]
    [Signature("Ljava/util/List<Ljava/lang/String;>;")]
    private static List FIELD_ORDER;
    public DiscordEventHandlers.OnReady ready;
    public DiscordEventHandlers.OnStatus disconnected;
    public DiscordEventHandlers.OnStatus errored;
    public DiscordEventHandlers.OnGameUpdate joinGame;
    public DiscordEventHandlers.OnGameUpdate spectateGame;
    public DiscordEventHandlers.OnJoinRequest joinRequest;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DiscordEventHandlers()
    {
    }

    [LineNumberTable(new byte[] {62, 105, 98, 104, 98, 103, 127, 3, 115, 115, 115, 115, 235, 59})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      if (!(o is DiscordEventHandlers))
        return false;
      DiscordEventHandlers discordEventHandlers = (DiscordEventHandlers) o;
      return Objects.equals((object) this.ready, (object) discordEventHandlers.ready) && Objects.equals((object) this.disconnected, (object) discordEventHandlers.disconnected) && (Objects.equals((object) this.errored, (object) discordEventHandlers.errored) && Objects.equals((object) this.joinGame, (object) discordEventHandlers.joinGame)) && (Objects.equals((object) this.spectateGame, (object) discordEventHandlers.spectateGame) && Objects.equals((object) this.joinRequest, (object) discordEventHandlers.joinRequest));
    }

    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int hashCode() => Objects.hash(new object[6]
    {
      (object) this.ready,
      (object) this.disconnected,
      (object) this.errored,
      (object) this.joinGame,
      (object) this.spectateGame,
      (object) this.joinRequest
    });

    [Signature("()Ljava/util/List<Ljava/lang/String;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override List getFieldOrder() => DiscordEventHandlers.FIELD_ORDER;

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static DiscordEventHandlers()
    {
      Structure.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("club.minnced.discord.rpc.DiscordEventHandlers"))
        return;
      DiscordEventHandlers.FIELD_ORDER = Collections.unmodifiableList(Arrays.asList((object[]) new string[6]
      {
        nameof (ready),
        nameof (disconnected),
        nameof (errored),
        nameof (joinGame),
        nameof (spectateGame),
        nameof (joinRequest)
      }));
    }

    [Implements(new string[] {"com.sun.jna.Callback"})]
    public interface OnGameUpdate : Callback
    {
      void accept(string str);
    }

    [Implements(new string[] {"com.sun.jna.Callback"})]
    public interface OnJoinRequest : Callback
    {
      void accept(DiscordUser du);
    }

    [Implements(new string[] {"com.sun.jna.Callback"})]
    public interface OnReady : Callback
    {
      void accept(DiscordUser du);
    }

    [Implements(new string[] {"com.sun.jna.Callback"})]
    public interface OnStatus : Callback
    {
      void accept(int i, string str);
    }
  }
}
