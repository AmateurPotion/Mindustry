// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamNativeIntHandle
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  public abstract class SteamNativeIntHandle : Object
  {
    internal int handle;

    [LineNumberTable(new byte[] {159, 149, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamNativeIntHandle([In] int obj0)
    {
      SteamNativeIntHandle steamNativeIntHandle = this;
      this.handle = obj0;
    }

    [Signature("<T:Lcom/codedisaster/steamworks/SteamNativeIntHandle;>(TT;)I")]
    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getNativeHandle(SteamNativeIntHandle handle) => handle.handle;

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => Integer.valueOf(this.handle).hashCode();

    [LineNumberTable(new byte[] {159, 167, 104, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object other) => other is SteamNativeIntHandle && this.handle == ((SteamNativeIntHandle) other).handle;

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Integer.toHexString(this.handle);
  }
}
