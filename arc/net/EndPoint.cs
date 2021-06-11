// Decompiled with JetBrains decompiler
// Type: arc.net.EndPoint
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;

namespace arc.net
{
  [Implements(new string[] {"java.lang.Runnable"})]
  public interface EndPoint : Runnable
  {
    void addListener(NetListener nl);

    void removeListener(NetListener nl);

    void run();

    void start();

    void stop();

    void close();

    [Throws(new string[] {"java.io.IOException"})]
    void update(int i);

    Thread getUpdateThread();
  }
}
