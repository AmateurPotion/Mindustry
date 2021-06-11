// Decompiled with JetBrains decompiler
// Type: club.minnced.discord.rpc.DiscordUser
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
  public class DiscordUser : Structure
  {
    [Modifiers]
    [Signature("Ljava/util/List<Ljava/lang/String;>;")]
    private static List FIELD_ORDER;
    public string userId;
    public string username;
    public string discriminator;
    public string avatar;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 190, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DiscordUser(string encoding)
    {
      DiscordUser discordUser = this;
      this.setStringEncoding(encoding);
    }

    [LineNumberTable(new byte[] {3, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DiscordUser()
      : this("UTF-8")
    {
    }

    [LineNumberTable(new byte[] {29, 105, 98, 104, 98, 103, 127, 0, 115, 115, 235, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      if (!(o is DiscordUser))
        return false;
      DiscordUser discordUser = (DiscordUser) o;
      return Objects.equals((object) this.userId, (object) discordUser.userId) && Objects.equals((object) this.username, (object) discordUser.username) && (Objects.equals((object) this.discriminator, (object) discordUser.discriminator) && Objects.equals((object) this.avatar, (object) discordUser.avatar));
    }

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int hashCode() => Objects.hash(new object[4]
    {
      (object) this.userId,
      (object) this.username,
      (object) this.discriminator,
      (object) this.avatar
    });

    [Signature("()Ljava/util/List<Ljava/lang/String;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override List getFieldOrder() => DiscordUser.FIELD_ORDER;

    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static DiscordUser()
    {
      Structure.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("club.minnced.discord.rpc.DiscordUser"))
        return;
      DiscordUser.FIELD_ORDER = Collections.unmodifiableList(Arrays.asList((object[]) new string[4]
      {
        nameof (userId),
        nameof (username),
        nameof (discriminator),
        nameof (avatar)
      }));
    }
  }
}
