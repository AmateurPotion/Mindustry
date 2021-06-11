// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.XXHash64JNI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.nio;
using net.jpountz.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.xxhash
{
  internal sealed class XXHash64JNI : XXHash64
  {
    [Modifiers]
    public static XXHash64 INSTANCE;
    private static XXHash64 SAFE_INSTANCE;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 171, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long hash([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] long obj3)
    {
      SafeUtils.checkRange(obj0, obj1, obj2);
      return XXHashJNI.XXH64(obj0, obj1, obj2, obj3);
    }

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal XXHash64JNI()
    {
    }

    [LineNumberTable(new byte[] {159, 177, 104, 104, 107, 104, 152, 102, 99, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long hash([In] ByteBuffer obj0, [In] int obj1, [In] int obj2, [In] long obj3)
    {
      if (obj0.isDirect())
      {
        ByteBufferUtils.checkRange(obj0, obj1, obj2);
        return XXHashJNI.XXH64BB(obj0, obj1, obj2, obj3);
      }
      return obj0.hasArray() ? this.hash(obj0.array(), obj1 + obj0.arrayOffset(), obj2, obj3) : (XXHash64JNI.SAFE_INSTANCE ?? (XXHash64JNI.SAFE_INSTANCE = XXHashFactory.safeInstance().hash64())).hash(obj0, obj1, obj2, obj3);
    }

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static XXHash64JNI()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.xxhash.XXHash64JNI"))
        return;
      XXHash64JNI.INSTANCE = (XXHash64) new XXHash64JNI();
    }
  }
}
