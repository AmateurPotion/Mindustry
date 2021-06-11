// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.IndexData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using java.nio;

namespace arc.graphics.gl
{
  [Implements(new string[] {"arc.util.Disposable"})]
  public interface IndexData : Disposable
  {
    void set(short[] sarr, int i1, int i2);

    int size();

    int max();

    void bind();

    void unbind();

    new void dispose();

    ShortBuffer buffer();

    void set(ShortBuffer sb);

    void update(int i1, short[] sarr, int i2, int i3);
  }
}
