// Decompiled with JetBrains decompiler
// Type: arc.net.ServerDiscoveryHandler
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.net;
using java.nio;

namespace arc.net
{
  public interface ServerDiscoveryHandler
  {
    [Throws(new string[] {"java.io.IOException"})]
    void onDiscoverReceived(InetAddress ia, ServerDiscoveryHandler.ReponseHandler sdhrh);

    interface ReponseHandler
    {
      [Throws(new string[] {"java.io.IOException"})]
      void respond(ByteBuffer bb);
    }
  }
}
