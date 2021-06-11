// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.StreamingXXHash32
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util.zip;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.xxhash
{
  public abstract class StreamingXXHash32 : Object
  {
    [Modifiers]
    internal int seed;

    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Checksum asChecksum() => (Checksum) new StreamingXXHash32.\u0031(this);

    public abstract void update(byte[] barr, int i1, int i2);

    public abstract int getValue();

    [LineNumberTable(new byte[] {1, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal StreamingXXHash32([In] int obj0)
    {
      StreamingXXHash32 streamingXxHash32 = this;
      this.seed = obj0;
    }

    public abstract void reset();

    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(Object.instancehelper_getClass((object) this).getSimpleName()).append("(seed=").append(this.seed).append(")").toString();

    [EnclosingMethod(null, "asChecksum", "()Ljava.util.zip.Checksum;")]
    [SpecialName]
    internal class \u0031 : Object, Checksum
    {
      [Modifiers]
      internal StreamingXXHash32 this\u00240;

      [LineNumberTable(89)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] StreamingXXHash32 obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(93)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual long getValue() => (long) this.this\u00240.getValue() & 268435455L;

      [LineNumberTable(new byte[] {48, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset() => this.this\u00240.reset();

      [LineNumberTable(new byte[] {53, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void update([In] int obj0) => this.this\u00240.update(new byte[1]
      {
        (byte) obj0
      }, 0, 1);

      [LineNumberTable(new byte[] {58, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void update([In] byte[] obj0, [In] int obj1, [In] int obj2) => this.this\u00240.update(obj0, obj1, obj2);

      [LineNumberTable(113)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => this.this\u00240.toString();
    }

    internal interface Factory
    {
      StreamingXXHash32 newStreamingHash([In] int obj0);
    }
  }
}
