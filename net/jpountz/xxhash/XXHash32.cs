// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.XXHash32
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;

namespace net.jpountz.xxhash
{
  public abstract class XXHash32 : Object
  {
    public abstract int hash(byte[] barr, int i1, int i2, int i3);

    public abstract int hash(ByteBuffer bb, int i1, int i2, int i3);

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public XXHash32()
    {
    }

    [LineNumberTable(new byte[] {11, 117, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int hash(ByteBuffer buf, int seed)
    {
      int num = this.hash(buf, ((Buffer) buf).position(), ((Buffer) buf).remaining(), seed);
      ((Buffer) buf).position(((Buffer) buf).limit());
      return num;
    }

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Object.instancehelper_getClass((object) this).getSimpleName();
  }
}
