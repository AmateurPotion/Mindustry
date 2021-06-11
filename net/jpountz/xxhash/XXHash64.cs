// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.XXHash64
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;

namespace net.jpountz.xxhash
{
  public abstract class XXHash64 : Object
  {
    public abstract long hash(ByteBuffer bb, int i1, int i2, long l);

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public XXHash64()
    {
    }

    public abstract long hash(byte[] barr, int i1, int i2, long l);

    [LineNumberTable(new byte[] {11, 117, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public long hash(ByteBuffer buf, long seed)
    {
      long num = this.hash(buf, ((Buffer) buf).position(), ((Buffer) buf).remaining(), seed);
      ((Buffer) buf).position(((Buffer) buf).limit());
      return num;
    }

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Object.instancehelper_getClass((object) this).getSimpleName();
  }
}
