// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamMatchmakingServerNetAdr
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public class SteamMatchmakingServerNetAdr : Object
  {
    internal short connectionPort;
    internal short queryPort;
    internal int ip;

    [LineNumberTable(new byte[] {159, 151, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamMatchmakingServerNetAdr()
    {
    }

    [LineNumberTable(new byte[] {159, 132, 66, 119, 63, 34})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string toString([In] int obj0, [In] short obj1)
    {
      int num = (int) obj1;
      return String.format("%d.%d.%d.%d:%d", new object[5]
      {
        (object) Integer.valueOf(obj0 >> 24 & (int) byte.MaxValue),
        (object) Integer.valueOf(obj0 >> 16 & (int) byte.MaxValue),
        (object) Integer.valueOf(obj0 >> 8 & (int) byte.MaxValue),
        (object) Integer.valueOf(obj0 & (int) byte.MaxValue),
        (object) Short.valueOf((short) num)
      });
    }

    [LineNumberTable(new byte[] {159, 139, 100, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SteamMatchmakingServerNetAdr(int ip, short queryPort, short connectionPort)
    {
      int num1 = (int) queryPort;
      int num2 = (int) connectionPort;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      SteamMatchmakingServerNetAdr matchmakingServerNetAdr = this;
      this.ip = ip;
      this.queryPort = (short) num1;
      this.connectionPort = (short) num2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short getConnectionPort() => this.connectionPort;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual short getQueryPort() => this.queryPort;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getIP() => this.ip;

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getConnectionAddressString() => SteamMatchmakingServerNetAdr.toString(this.ip, this.connectionPort);

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getQueryAddressString() => SteamMatchmakingServerNetAdr.toString(this.ip, this.queryPort);
  }
}
