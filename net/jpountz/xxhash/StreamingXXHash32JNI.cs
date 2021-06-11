// Decompiled with JetBrains decompiler
// Type: net.jpountz.xxhash.StreamingXXHash32JNI
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.xxhash
{
  internal sealed class StreamingXXHash32JNI : StreamingXXHash32
  {
    private long state;

    [LineNumberTable(new byte[] {159, 176, 105, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal StreamingXXHash32JNI([In] int obj0)
      : base(obj0)
    {
      StreamingXXHash32JNI streamingXxHash32Jni = this;
      this.state = XXHashJNI.XXH32_init(obj0);
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 181, 106, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkState()
    {
      if (this.state == 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new AssertionError((object) "Already finalized");
      }
    }

    [LineNumberTable(new byte[] {159, 188, 102, 107, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void reset()
    {
      this.checkState();
      XXHashJNI.XXH32_free(this.state);
      this.state = XXHashJNI.XXH32_init(this.seed);
    }

    [LineNumberTable(new byte[] {3, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getValue()
    {
      this.checkState();
      return XXHashJNI.XXH32_digest(this.state);
    }

    [LineNumberTable(new byte[] {9, 102, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void update([In] byte[] obj0, [In] int obj1, [In] int obj2)
    {
      this.checkState();
      XXHashJNI.XXH32_update(this.state, obj0, obj1, obj2);
    }

    [Throws(new string[] {"java.lang.Throwable"})]
    [LineNumberTable(new byte[] {15, 134, 107, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void finalize()
    {
      base.finalize();
      XXHashJNI.XXH32_free(this.state);
      this.state = 0L;
    }

    [HideFromJava]
    ~StreamingXXHash32JNI()
    {
      if (ByteCodeHelper.SkipFinalizer())
        return;
      try
      {
        this.finalize();
      }
      catch
      {
      }
    }

    internal new class Factory : Object, StreamingXXHash32.Factory
    {
      [Modifiers]
      public static StreamingXXHash32.Factory INSTANCE;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(20)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Factory()
      {
      }

      [LineNumberTable(26)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual StreamingXXHash32 newStreamingHash([In] int obj0) => (StreamingXXHash32) new StreamingXXHash32JNI(obj0);

      [LineNumberTable(22)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Factory()
      {
        if (ByteCodeHelper.isAlreadyInited("net.jpountz.xxhash.StreamingXXHash32JNI$Factory"))
          return;
        StreamingXXHash32JNI.Factory.INSTANCE = (StreamingXXHash32.Factory) new StreamingXXHash32JNI.Factory();
      }
    }
  }
}
