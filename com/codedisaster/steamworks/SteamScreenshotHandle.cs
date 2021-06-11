// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamScreenshotHandle
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public class SteamScreenshotHandle : SteamNativeIntHandle
  {
    internal static SteamScreenshotHandle __\u003C\u003EINVALID;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 150, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamScreenshotHandle([In] int obj0)
      : base(obj0)
    {
    }

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SteamScreenshotHandle()
    {
      if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamScreenshotHandle"))
        return;
      SteamScreenshotHandle.__\u003C\u003EINVALID = new SteamScreenshotHandle(0);
    }

    [Modifiers]
    public static SteamScreenshotHandle INVALID
    {
      [HideFromJava] get => SteamScreenshotHandle.__\u003C\u003EINVALID;
    }
  }
}
