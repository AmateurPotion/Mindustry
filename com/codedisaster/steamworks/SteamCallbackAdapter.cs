// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamCallbackAdapter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  internal abstract class SteamCallbackAdapter : Object
  {
    [Modifiers]
    [Signature("TT;")]
    protected internal object callback;

    [Signature("(TT;)V")]
    [LineNumberTable(new byte[] {159, 149, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamCallbackAdapter([In] object obj0)
    {
      SteamCallbackAdapter steamCallbackAdapter = this;
      this.callback = obj0;
    }
  }
}
