// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.XXHash32JNI
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
  internal sealed class XXHash32JNI : XXHash32
  {
    [Modifiers]
    public static XXHash32 INSTANCE;
    private static XXHash32 SAFE_INSTANCE;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 171, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int hash([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      SafeUtils.checkRange(obj0, obj1, obj2);
      return XXHashJNI.XXH32(obj0, obj1, obj2, obj3);
    }

    [LineNumberTable(22)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal XXHash32JNI()
    {
    }

    [LineNumberTable(new byte[] {159, 177, 104, 104, 107, 104, 152, 102, 99, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int hash([In] ByteBuffer obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      if (obj0.isDirect())
      {
        ByteBufferUtils.checkRange(obj0, obj1, obj2);
        return XXHashJNI.XXH32BB(obj0, obj1, obj2, obj3);
      }
      return obj0.hasArray() ? this.hash(obj0.array(), obj1 + obj0.arrayOffset(), obj2, obj3) : (XXHash32JNI.SAFE_INSTANCE ?? (XXHash32JNI.SAFE_INSTANCE = XXHashFactory.safeInstance().hash32())).hash(obj0, obj1, obj2, obj3);
    }

    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static XXHash32JNI()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.xxhash.XXHash32JNI"))
        return;
      XXHash32JNI.INSTANCE = (XXHash32) new XXHash32JNI();
    }
  }
}
