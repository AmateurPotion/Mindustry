// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4UnknownSizeDecompressor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using java.lang;
using System;

namespace net.jpountz.lz4
{
  [Obsolete]
  [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
  public interface LZ4UnknownSizeDecompressor
  {
    int decompress(byte[] barr1, int i1, int i2, byte[] barr2, int i3, int i4);

    int decompress(byte[] barr1, int i1, int i2, byte[] barr2, int i3);
  }
}
