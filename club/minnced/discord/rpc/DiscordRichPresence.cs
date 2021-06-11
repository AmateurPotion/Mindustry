// Decompiled with JetBrains decompiler
// Type: club.minnced.discord.rpc.DiscordRichPresence
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using com.sun.jna;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace club.minnced.discord.rpc
{
  public class DiscordRichPresence : Structure
  {
    [Modifiers]
    [Signature("Ljava/util/List<Ljava/lang/String;>;")]
    private static List FIELD_ORDER;
    public string state;
    public string details;
    public long startTimestamp;
    public long endTimestamp;
    public string largeImageKey;
    public string largeImageText;
    public string smallImageKey;
    public string smallImageText;
    public string partyId;
    public int partySize;
    public int partyMax;
    public string matchSecret;
    public string joinSecret;
    public string spectateSecret;
    public byte instance;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {25, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DiscordRichPresence()
      : this("UTF-8")
    {
    }

    [LineNumberTable(new byte[] {20, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DiscordRichPresence(string encoding)
    {
      DiscordRichPresence discordRichPresence = this;
      this.setStringEncoding(encoding);
    }

    [LineNumberTable(new byte[] {160, 81, 105, 98, 104, 98, 103, 255, 68, 69, 118, 118, 118, 118, 118, 115, 115, 115, 115, 235, 50})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      if (!(o is DiscordRichPresence))
        return false;
      DiscordRichPresence discordRichPresence = (DiscordRichPresence) o;
      return this.startTimestamp == discordRichPresence.startTimestamp && this.endTimestamp == discordRichPresence.endTimestamp && (this.partySize == discordRichPresence.partySize && this.partyMax == discordRichPresence.partyMax) && ((int) (sbyte) this.instance == (int) (sbyte) discordRichPresence.instance && Objects.equals((object) this.state, (object) discordRichPresence.state) && (Objects.equals((object) this.details, (object) discordRichPresence.details) && Objects.equals((object) this.largeImageKey, (object) discordRichPresence.largeImageKey))) && (Objects.equals((object) this.largeImageText, (object) discordRichPresence.largeImageText) && Objects.equals((object) this.smallImageKey, (object) discordRichPresence.smallImageKey) && (Objects.equals((object) this.smallImageText, (object) discordRichPresence.smallImageText) && Objects.equals((object) this.partyId, (object) discordRichPresence.partyId)) && (Objects.equals((object) this.matchSecret, (object) discordRichPresence.matchSecret) && Objects.equals((object) this.joinSecret, (object) discordRichPresence.joinSecret) && Objects.equals((object) this.spectateSecret, (object) discordRichPresence.spectateSecret)));
    }

    [LineNumberTable(new byte[] {160, 106, 127, 76, 63, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int hashCode() => Objects.hash(new object[15]
    {
      (object) this.state,
      (object) this.details,
      (object) Long.valueOf(this.startTimestamp),
      (object) Long.valueOf(this.endTimestamp),
      (object) this.largeImageKey,
      (object) this.largeImageText,
      (object) this.smallImageKey,
      (object) this.smallImageText,
      (object) this.partyId,
      (object) Integer.valueOf(this.partySize),
      (object) Integer.valueOf(this.partyMax),
      (object) this.matchSecret,
      (object) this.joinSecret,
      (object) this.spectateSecret,
      (object) Byte.valueOf(this.instance)
    });

    [Signature("()Ljava/util/List<Ljava/lang/String;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override List getFieldOrder() => DiscordRichPresence.FIELD_ORDER;

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static DiscordRichPresence()
    {
      Structure.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("club.minnced.discord.rpc.DiscordRichPresence"))
        return;
      DiscordRichPresence.FIELD_ORDER = Collections.unmodifiableList(Arrays.asList((object[]) new string[15]
      {
        nameof (state),
        nameof (details),
        nameof (startTimestamp),
        nameof (endTimestamp),
        nameof (largeImageKey),
        nameof (largeImageText),
        nameof (smallImageKey),
        nameof (smallImageText),
        nameof (partyId),
        nameof (partySize),
        nameof (partyMax),
        nameof (matchSecret),
        nameof (joinSecret),
        nameof (spectateSecret),
        nameof (instance)
      }));
    }
  }
}
