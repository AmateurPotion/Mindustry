// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamNativeHandle
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public abstract class SteamNativeHandle : Object
  {
    internal long handle;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long handle() => this.handle;

    [LineNumberTable(new byte[] {159, 173, 104, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object other) => other is SteamNativeHandle && this.handle == ((SteamNativeHandle) other).handle;

    [LineNumberTable(new byte[] {159, 148, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamNativeHandle([In] long obj0)
    {
      SteamNativeHandle steamNativeHandle = this;
      this.handle = obj0;
    }

    [Signature("<T:Lcom/codedisaster/steamworks/SteamNativeHandle;>(TT;)J")]
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long getNativeHandle(SteamNativeHandle handle) => handle.handle;

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => Long.valueOf(this.handle).hashCode();

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Long.toHexString(this.handle);
  }
}
