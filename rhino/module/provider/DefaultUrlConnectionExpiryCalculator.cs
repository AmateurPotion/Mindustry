// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.DefaultUrlConnectionExpiryCalculator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.net;
using System.Runtime.CompilerServices;

namespace rhino.module.provider
{
  public class DefaultUrlConnectionExpiryCalculator : Object, UrlConnectionExpiryCalculator
  {
    [Modifiers]
    private long relativeExpiry;

    [LineNumberTable(new byte[] {159, 162, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DefaultUrlConnectionExpiryCalculator()
      : this(60000L)
    {
    }

    [LineNumberTable(new byte[] {159, 170, 104, 101, 144, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DefaultUrlConnectionExpiryCalculator(long relativeExpiry)
    {
      DefaultUrlConnectionExpiryCalculator expiryCalculator = this;
      if (relativeExpiry < 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("relativeExpiry < 0");
      }
      this.relativeExpiry = relativeExpiry;
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long calculateExpiry(URLConnection urlConnection) => java.lang.System.currentTimeMillis() + this.relativeExpiry;
  }
}
