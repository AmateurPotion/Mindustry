// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4Utils
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/lz4/LZ4Utils;>;")]
  [Modifiers]
  [Serializable]
  internal sealed class LZ4Utils : Enum
  {
    private const int MAX_INPUT_SIZE = 2113929216;
    [Modifiers]
    private static LZ4Utils[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int hash([In] int obj0) => (int) ((uint) (obj0 * -1640531535) >> 20);

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int hash64k([In] int obj0) => (int) ((uint) (obj0 * -1640531535) >> 19);

    [LineNumberTable(new byte[] {159, 175, 100, 127, 6, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int maxCompressedLength([In] int obj0)
    {
      if (obj0 < 0)
      {
        string str = new StringBuilder().append("length must be >= 0, got ").append(obj0).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (obj0 >= 2113929216)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("length must be < 2113929216");
      }
      return obj0 + obj0 / (int) byte.MaxValue + 16;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int hashHC([In] int obj0) => (int) ((uint) (obj0 * -1640531535) >> 17);

    [LineNumberTable(new byte[] {18, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void copyTo([In] LZ4Utils.Match obj0, [In] LZ4Utils.Match obj1)
    {
      obj1.len = obj0.len;
      obj1.start = obj0.start;
      obj1.@ref = obj0.@ref;
    }

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4Utils[] values() => (LZ4Utils[]) LZ4Utils.\u0024VALUES.Clone();

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LZ4Utils valueOf([In] string obj0) => (LZ4Utils) Enum.valueOf((Class) ClassLiteral<LZ4Utils>.Value, obj0);

    [Signature("()V")]
    [LineNumberTable(new byte[] {159, 169, 232, 90})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private LZ4Utils([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4Utils()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4Utils"))
        return;
      LZ4Utils.\u0024VALUES = new LZ4Utils[0];
    }

    internal class Match : Object
    {
      internal int start;
      internal int @ref;
      internal int len;

      [LineNumberTable(53)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Match()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual int end() => this.start + this.len;

      [LineNumberTable(new byte[] {7, 110, 110, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void fix([In] int obj0)
      {
        this.start += obj0;
        this.@ref += obj0;
        this.len -= obj0;
      }
    }
  }
}
