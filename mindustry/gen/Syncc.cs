// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Syncc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.io;
using IKVM.Attributes;
using java.nio;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Entityc"})]
  public interface Syncc : Entityc
  {
    void readSync(Reads r);

    void snapSync();

    void readSyncManual(FloatBuffer fb);

    void writeSync(Writes w);

    void snapInterpolation();

    void writeSyncManual(FloatBuffer fb);

    void afterSync();

    void interpolate();

    new void update();

    new void remove();

    long lastUpdated();

    void lastUpdated(long l);

    long updateSpacing();

    void updateSpacing(long l);
  }
}
