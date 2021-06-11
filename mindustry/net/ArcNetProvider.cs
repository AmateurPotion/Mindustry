// Decompiled with JetBrains decompiler
// Type: mindustry.net.ArcNetProvider
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.net;
using arc.util;
using arc.util.async;
using arc.util.pooling;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.nio;
using java.nio.channels;
using java.util;
using java.util.concurrent;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class ArcNetProvider : Object, Net.NetProvider
  {
    [Modifiers]
    internal Client client;
    [Modifiers]
    [Signature("Larc/func/Prov<Ljava/net/DatagramPacket;>;")]
    internal Prov packetSupplier;
    [Modifiers]
    internal AsyncExecutor executor;
    [Modifiers]
    internal Server server;
    [Modifiers]
    [Signature("Ljava/util/concurrent/CopyOnWriteArrayList<Lmindustry/net/ArcNetProvider$ArcConnection;>;")]
    internal CopyOnWriteArrayList connections;
    internal Thread serverThread;

    [LineNumberTable(new byte[] {159, 173, 232, 57, 112, 187, 203, 143, 122, 113, 241, 100, 122, 117, 245, 70, 241, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ArcNetProvider()
    {
      ArcNetProvider arcNetProvider = this;
      this.packetSupplier = (Prov) new ArcNetProvider.__\u003C\u003EAnon0();
      this.executor = new AsyncExecutor(Math.max(java.lang.Runtime.getRuntime().availableProcessors(), 6));
      this.connections = new CopyOnWriteArrayList();
      ArcNet.errorHandler = (Cons) new ArcNetProvider.__\u003C\u003EAnon1();
      this.client = new Client(8192, 8192, (NetSerializer) new ArcNetProvider.PacketSerializer());
      this.client.setDiscoveryPacket(this.packetSupplier);
      this.client.addListener((NetListener) new ArcNetProvider.\u0031(this));
      this.server = new Server(32768, 8192, (NetSerializer) new ArcNetProvider.PacketSerializer());
      this.server.setMulticast("227.2.7.7", 20151);
      this.server.setDiscoveryHandler((ServerDiscoveryHandler) new ArcNetProvider.__\u003C\u003EAnon2());
      this.server.addListener((NetListener) new ArcNetProvider.\u0032(this));
    }

    [LineNumberTable(new byte[] {112, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disconnectClient() => this.client.close();

    [LineNumberTable(new byte[] {160, 144, 107, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void closeServer()
    {
      this.connections.clear();
      AsyncExecutor executor = this.executor;
      Server server = this.server;
      Objects.requireNonNull((object) server);
      Runnable run = (Runnable) new ArcNetProvider.__\u003C\u003EAnon8(server);
      executor.submit(run);
    }

    [LineNumberTable(new byte[] {78, 178, 127, 6, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isLocal([In] InetAddress obj0)
    {
      if (!obj0.isAnyLocalAddress())
      {
        if (!obj0.isLoopbackAddress())
        {
          int num;
          try
          {
            num = NetworkInterface.getByInetAddress(obj0) == null ? 0 : 1;
          }
          catch (Exception ex)
          {
            if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
              throw;
            else
              goto label_7;
          }
          return num != 0;
label_7:
          return false;
        }
      }
      return true;
    }

    [Modifiers]
    [LineNumberTable(24)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static DatagramPacket lambda\u0024new\u00240()
    {
      DatagramPacket.__\u003Cclinit\u003E();
      return new DatagramPacket(new byte[512], 512);
    }

    [Modifiers]
    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00241([In] Exception obj0) => Log.debug((object) Strings.getStackTrace(obj0));

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(new byte[] {25, 102, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00242(
      [In] InetAddress obj0,
      [In] ServerDiscoveryHandler.ReponseHandler obj1)
    {
      ByteBuffer bb = NetworkIO.writeServerData();
      ((Buffer) bb).position(0);
      obj1.respond(bb);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {92, 139, 246, 72, 115, 189, 2, 97, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024connectClient\u00244([In] string obj0, [In] int obj1, [In] Runnable obj2)
    {
      Exception exception1;
      try
      {
        this.client.stop();
        Threads.daemon("Net Client", (Runnable) new ArcNetProvider.__\u003C\u003EAnon13(this));
        this.client.connect(5000, obj0, obj1, obj1);
        obj2.run();
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Vars.net.handleException((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 71, 102, 102, 127, 8, 139, 113, 135, 108, 154, 191, 17, 2, 98, 152})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024pingHost\u00247([In] string obj0, [In] int obj1, [In] Cons obj2, [In] Cons obj3)
    {
      Exception exception1;
      try
      {
        DatagramSocket datagramSocket1 = new DatagramSocket();
        long prevTime = Time.millis();
        DatagramSocket datagramSocket2 = datagramSocket1;
        DatagramPacket.__\u003Cclinit\u003E();
        DatagramPacket datagramPacket1 = new DatagramPacket(new byte[2]
        {
          (byte) 254,
          (byte) 1
        }, 2, InetAddress.getByName(obj0), obj1);
        datagramSocket2.send(datagramPacket1);
        datagramSocket1.setSoTimeout(2000);
        DatagramPacket datagramPacket2 = (DatagramPacket) this.packetSupplier.get();
        datagramSocket1.receive(datagramPacket2);
        ByteBuffer buffer = ByteBuffer.wrap(datagramPacket2.getData());
        Host host = NetworkIO.readServerData((int) Time.timeSinceMillis(prevTime), datagramPacket2.getAddress().getHostAddress(), buffer);
        Core.app.post((Runnable) new ArcNetProvider.__\u003C\u003EAnon11(obj2, host));
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Core.app.post((Runnable) new ArcNetProvider.__\u003C\u003EAnon12(obj3, exception2));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 94, 248, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024discoverServers\u002410(
      [In] Seq obj0,
      [In] long obj1,
      [In] Cons obj2,
      [In] DatagramPacket obj3)
    {
      Core.app.post((Runnable) new ArcNetProvider.__\u003C\u003EAnon9(obj0, obj3, obj1, obj2));
    }

    [Modifiers]
    [LineNumberTable(222)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024discoverServers\u002411([In] Runnable obj0) => Core.app.post(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 133, 189, 2, 97, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024hostServer\u002412()
    {
      Exception exception;
      try
      {
        this.server.run();
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception t = exception;
      if (t is ClosedSelectorException)
        return;
      Threads.throwAppException(t);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 96, 115, 130, 108, 121, 103, 223, 5, 226, 61, 129, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024discoverServers\u00249(
      [In] Seq obj0,
      [In] DatagramPacket obj1,
      [In] long obj2,
      [In] Cons obj3)
    {
      Exception exception;
      try
      {
        if (obj0.contains((Boolf) new ArcNetProvider.__\u003C\u003EAnon10(obj1)))
          return;
        ByteBuffer buffer = ByteBuffer.wrap(obj1.getData());
        Host host = NetworkIO.readServerData((int) Time.timeSinceMillis(obj2), obj1.getAddress().getHostAddress(), buffer);
        obj3.get((object) host);
        obj0.add((object) obj1.getAddress());
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception = (Exception) m0;
      }
      Throwable.instancehelper_printStackTrace((Exception) exception);
    }

    [Modifiers]
    [LineNumberTable(210)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024discoverServers\u00248([In] DatagramPacket obj0, [In] InetAddress obj1) => obj1.equals((object) obj0.getAddress()) || ArcNetProvider.isLocal(obj1) && ArcNetProvider.isLocal(obj0.getAddress());

    [Modifiers]
    [LineNumberTable(196)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024pingHost\u00245([In] Cons obj0, [In] Host obj1) => obj0.get((object) obj1);

    [Modifiers]
    [LineNumberTable(198)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024pingHost\u00246([In] Cons obj0, [In] Exception obj1) => obj0.get((object) obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {96, 191, 3, 2, 97, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024connectClient\u00243()
    {
      Exception exception1;
      try
      {
        this.client.run();
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      if (exception2 is ClosedSelectorException)
        return;
      Vars.net.handleException((Exception) exception2);
    }

    [LineNumberTable(new byte[] {89, 244, 83})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connectClient(string ip, int port, Runnable success) => Threads.daemon((Runnable) new ArcNetProvider.__\u003C\u003EAnon3(this, ip, port, success));

    [LineNumberTable(new byte[] {118, 109, 143, 255, 12, 69, 2, 97, 171, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendClient(object @object, Net.SendMode mode)
    {
      BufferOverflowException overflowException1;
      BufferUnderflowException underflowException;
      try
      {
        try
        {
          if (object.ReferenceEquals((object) mode, (object) Net.SendMode.__\u003C\u003Etcp))
          {
            this.client.sendTCP(@object);
            goto label_8;
          }
          else
          {
            this.client.sendUDP(@object);
            goto label_8;
          }
        }
        catch (BufferOverflowException ex)
        {
          overflowException1 = (BufferOverflowException) ByteCodeHelper.MapException<BufferOverflowException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
      }
      catch (BufferUnderflowException ex)
      {
        underflowException = (BufferUnderflowException) ByteCodeHelper.MapException<BufferUnderflowException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_6;
      }
      BufferOverflowException overflowException2 = overflowException1;
      goto label_7;
label_6:
      overflowException2 = (BufferOverflowException) underflowException;
label_7:
      RuntimeException runtimeException = (RuntimeException) overflowException2;
      Vars.net.showError((Exception) runtimeException);
label_8:
      Pools.free(@object);
    }

    [Signature("(Ljava/lang/String;ILarc/func/Cons<Lmindustry/net/Host;>;Larc/func/Cons<Ljava/lang/Exception;>;)V")]
    [LineNumberTable(new byte[] {160, 69, 252, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pingHost(string address, int port, Cons valid, Cons invalid) => this.executor.submit((Runnable) new ArcNetProvider.__\u003C\u003EAnon4(this, address, port, valid, invalid));

    [Signature("(Larc/func/Cons<Lmindustry/net/Host;>;Ljava/lang/Runnable;)V")]
    [LineNumberTable(new byte[] {160, 91, 102, 102, 255, 24, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void discoverServers(Cons callback, Runnable done) => this.client.discoverHosts(6567, "227.2.7.7", 20151, 3000, (Cons) new ArcNetProvider.__\u003C\u003EAnon5(new Seq(), Time.millis(), callback), (Runnable) new ArcNetProvider.__\u003C\u003EAnon6(done));

    [LineNumberTable(new byte[] {160, 113, 102, 134, 150, 34, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.disconnectClient();
      this.closeServer();
      try
      {
        this.client.dispose();
      }
      catch (IOException ex)
      {
      }
    }

    [Signature("()Ljava/lang/Iterable<Lmindustry/net/ArcNetProvider$ArcConnection;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterable getConnections() => (Iterable) this.connections;

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 128, 107, 141, 255, 1, 71, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hostServer(int port)
    {
      this.connections.clear();
      this.server.bind(port, port);
      Thread.__\u003Cclinit\u003E();
      this.serverThread = new Thread((Runnable) new ArcNetProvider.__\u003C\u003EAnon7(this), "Net Server");
      this.serverThread.setDaemon(true);
      this.serverThread.start();
    }

    [LineNumberTable(new byte[] {160, 149, 112, 114, 118, 226, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual ArcNetProvider.ArcConnection getByArcID([In] int obj0)
    {
      for (int index = 0; index < this.connections.size(); ++index)
      {
        ArcNetProvider.ArcConnection arcConnection = (ArcNetProvider.ArcConnection) this.connections.get(index);
        if (arcConnection.connection != null && arcConnection.connection.getID() == obj0)
          return arcConnection;
      }
      return (ArcNetProvider.ArcConnection) null;
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal class \u0031 : Object, NetListener
    {
      [Modifiers]
      internal ArcNetProvider this\u00240;

      [Modifiers]
      [LineNumberTable(43)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024connected\u00240([In] Packets.Connect obj0) => Vars.net.handleClientReceived((object) obj0);

      [Modifiers]
      [LineNumberTable(54)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024disconnected\u00241([In] Packets.Disconnect obj0) => Vars.net.handleClientReceived((object) obj0);

      [Modifiers]
      [LineNumberTable(new byte[] {13, 189, 2, 97, 139})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024received\u00242([In] object obj0)
      {
        Exception exception;
        try
        {
          Vars.net.handleClientReceived(obj0);
          return;
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception e = exception;
        Vars.net.handleException(e);
      }

      [LineNumberTable(36)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ArcNetProvider obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 181, 102, 118, 153, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void connected([In] Connection obj0)
      {
        Packets.Connect connect = new Packets.Connect();
        connect.addressTCP = obj0.getRemoteAddressTCP().getAddress().getHostAddress();
        if (obj0.getRemoteAddressTCP() != null)
          connect.addressTCP = obj0.getRemoteAddressTCP().toString();
        Core.app.post((Runnable) new ArcNetProvider.\u0031.__\u003C\u003EAnon0(connect));
      }

      [LineNumberTable(new byte[] {159, 190, 104, 170, 102, 108, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void disconnected([In] Connection obj0, [In] DcReason obj1)
      {
        if (obj0.getLastProtocolError() != null)
          Vars.netClient.setQuiet();
        Core.app.post((Runnable) new ArcNetProvider.\u0031.__\u003C\u003EAnon1(new Packets.Disconnect()
        {
          reason = obj1.toString()
        }));
      }

      [LineNumberTable(new byte[] {9, 137, 245, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void received([In] Connection obj0, [In] object obj1)
      {
        if (obj1 is FrameworkMessage)
          return;
        Core.app.post((Runnable) new ArcNetProvider.\u0031.__\u003C\u003EAnon2(obj1));
      }

      [HideFromJava]
      public virtual void idle([In] Connection obj0) => NetListener.\u003Cdefault\u003Eidle((NetListener) this, obj0);

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly Packets.Connect arg\u00241;

        internal __\u003C\u003EAnon0([In] Packets.Connect obj0) => this.arg\u00241 = obj0;

        public void run() => ArcNetProvider.\u0031.lambda\u0024connected\u00240(this.arg\u00241);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly Packets.Disconnect arg\u00241;

        internal __\u003C\u003EAnon1([In] Packets.Disconnect obj0) => this.arg\u00241 = obj0;

        public void run() => ArcNetProvider.\u0031.lambda\u0024disconnected\u00241(this.arg\u00241);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly object arg\u00241;

        internal __\u003C\u003EAnon2([In] object obj0) => this.arg\u00241 = obj0;

        public void run() => ArcNetProvider.\u0031.lambda\u0024received\u00242(this.arg\u00241);
      }
    }

    [EnclosingMethod(null, "<init>", "()V")]
    [SpecialName]
    internal class \u0032 : Object, NetListener
    {
      [Modifiers]
      internal ArcNetProvider this\u00240;

      [LineNumberTable(80)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] ArcNetProvider obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [Modifiers]
      [LineNumberTable(94)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024connected\u00240(
        [In] ArcNetProvider.ArcConnection obj0,
        [In] Packets.Connect obj1)
      {
        Vars.net.handleServerReceived((NetConnection) obj0, (object) obj1);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {56, 108, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024disconnected\u00241(
        [In] ArcNetProvider.ArcConnection obj0,
        [In] Packets.Disconnect obj1)
      {
        Vars.net.handleServerReceived((NetConnection) obj0, (object) obj1);
        this.this\u00240.connections.remove((object) obj0);
      }

      [Modifiers]
      [LineNumberTable(new byte[] {68, 190, 2, 97, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024received\u00242(
        [In] ArcNetProvider.ArcConnection obj0,
        [In] object obj1)
      {
        Exception exception;
        try
        {
          Vars.net.handleServerReceived((NetConnection) obj0, obj1);
          return;
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Throwable.instancehelper_printStackTrace(exception);
      }

      [LineNumberTable(new byte[] {34, 145, 142, 102, 135, 153, 114, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void connected([In] Connection obj0)
      {
        string hostAddress = obj0.getRemoteAddressTCP().getAddress().getHostAddress();
        ArcNetProvider.ArcConnection arcConnection = new ArcNetProvider.ArcConnection(this.this\u00240, hostAddress, obj0);
        Packets.Connect connect = new Packets.Connect();
        connect.addressTCP = hostAddress;
        Log.debug("&bReceived connection: @", (object) connect.addressTCP);
        this.this\u00240.connections.add((object) arcConnection);
        Core.app.post((Runnable) new ArcNetProvider.\u0032.__\u003C\u003EAnon0(arcConnection, connect));
      }

      [LineNumberTable(new byte[] {49, 114, 132, 102, 140, 215})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void disconnected([In] Connection obj0, [In] DcReason obj1)
      {
        ArcNetProvider.ArcConnection byArcId = this.this\u00240.getByArcID(obj0.getID());
        if (byArcId == null)
          return;
        Core.app.post((Runnable) new ArcNetProvider.\u0032.__\u003C\u003EAnon1(this, byArcId, new Packets.Disconnect()
        {
          reason = obj1.toString()
        }));
      }

      [LineNumberTable(new byte[] {63, 114, 140, 246, 71})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void received([In] Connection obj0, [In] object obj1)
      {
        ArcNetProvider.ArcConnection byArcId = this.this\u00240.getByArcID(obj0.getID());
        if (obj1 is FrameworkMessage || byArcId == null)
          return;
        Core.app.post((Runnable) new ArcNetProvider.\u0032.__\u003C\u003EAnon2(byArcId, obj1));
      }

      [HideFromJava]
      public virtual void idle([In] Connection obj0) => NetListener.\u003Cdefault\u003Eidle((NetListener) this, obj0);

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Runnable
      {
        private readonly ArcNetProvider.ArcConnection arg\u00241;
        private readonly Packets.Connect arg\u00242;

        internal __\u003C\u003EAnon0([In] ArcNetProvider.ArcConnection obj0, [In] Packets.Connect obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => ArcNetProvider.\u0032.lambda\u0024connected\u00240(this.arg\u00241, this.arg\u00242);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly ArcNetProvider.\u0032 arg\u00241;
        private readonly ArcNetProvider.ArcConnection arg\u00242;
        private readonly Packets.Disconnect arg\u00243;

        internal __\u003C\u003EAnon1(
          [In] ArcNetProvider.\u0032 obj0,
          [In] ArcNetProvider.ArcConnection obj1,
          [In] Packets.Disconnect obj2)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
        }

        public void run() => this.arg\u00241.lambda\u0024disconnected\u00241(this.arg\u00242, this.arg\u00243);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly ArcNetProvider.ArcConnection arg\u00241;
        private readonly object arg\u00242;

        internal __\u003C\u003EAnon2([In] ArcNetProvider.ArcConnection obj0, [In] object obj1)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
        }

        public void run() => ArcNetProvider.\u0032.lambda\u0024received\u00242(this.arg\u00241, this.arg\u00242);
      }
    }

    internal class ArcConnection : NetConnection
    {
      [Modifiers]
      public Connection connection;
      [Modifiers]
      internal ArcNetProvider this\u00240;

      [LineNumberTable(new byte[] {160, 162, 103, 105, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ArcConnection([In] ArcNetProvider obj0, [In] string obj1, [In] Connection obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        ArcNetProvider.ArcConnection arcConnection = this;
        this.connection = obj2;
      }

      [LineNumberTable(283)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool isConnected() => this.connection.isConnected();

      [LineNumberTable(new byte[] {160, 174, 253, 85})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void sendStream([In] Streamable obj0) => this.connection.addListener((NetListener) new ArcNetProvider.ArcConnection.\u0031(this, (InputStream) obj0.stream, 512, obj0));

      [LineNumberTable(new byte[] {160, 200, 109, 143, 255, 5, 73, 226, 57, 97, 102, 106, 144, 119, 149})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void send([In] object obj0, [In] Net.SendMode obj1)
      {
        Exception exception;
        try
        {
          if (object.ReferenceEquals((object) obj1, (object) Net.SendMode.__\u003C\u003Etcp))
          {
            this.connection.sendTCP(obj0);
            return;
          }
          this.connection.sendUDP(obj0);
          return;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception = (Exception) m0;
        }
        Log.err((Exception) exception);
        Log.info((object) "Error sending packet. Disconnecting invalid client!");
        this.connection.close(DcReason.__\u003C\u003Eerror);
        ArcNetProvider.ArcConnection byArcId = this.this\u00240.getByArcID(this.connection.getID());
        if (byArcId == null)
          return;
        this.this\u00240.connections.remove((object) byArcId);
      }

      [LineNumberTable(new byte[] {160, 217, 125})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void close()
      {
        if (!this.connection.isConnected())
          return;
        this.connection.close(DcReason.__\u003C\u003Eclosed);
      }

      [InnerClass]
      [EnclosingMethod(null, "sendStream", "(Lmindustry.net.Streamable;)V")]
      [SpecialName]
      internal class \u0031 : InputStreamSender
      {
        internal int id;
        [Modifiers]
        internal Streamable val\u0024stream;
        [Modifiers]
        internal ArcNetProvider.ArcConnection this\u00241;

        [LineNumberTable(288)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031(
          [In] ArcNetProvider.ArcConnection obj0,
          [In] InputStream obj1,
          [In] int obj2,
          [In] Streamable obj3)
        {
          this.this\u00241 = obj0;
          this.val\u0024stream = obj3;
          // ISSUE: explicit constructor call
          base.\u002Ector(obj1, obj2);
        }

        [LineNumberTable(new byte[] {160, 180, 102, 118, 119, 114, 108})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override void start()
        {
          Packets.StreamBegin streamBegin = new Packets.StreamBegin();
          streamBegin.total = this.val\u0024stream.stream.available();
          streamBegin.type = Registrator.getID(Object.instancehelper_getClass((object) this.val\u0024stream));
          this.this\u00241.connection.sendTCP((object) streamBegin);
          this.id = streamBegin.id;
        }

        [LineNumberTable(new byte[] {160, 189, 102, 108, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        protected internal override object next([In] byte[] obj0) => (object) new Packets.StreamChunk()
        {
          id = this.id,
          data = obj0
        };
      }
    }

    public class PacketSerializer : Object, NetSerializer
    {
      [LineNumberTable(new byte[] {160, 226, 104, 101, 136, 127, 2, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read(ByteBuffer byteBuffer)
      {
        int num = (int) (sbyte) byteBuffer.get();
        if (num == -2)
          return (object) this.readFramework(byteBuffer);
        Packet packet = (Packet) Pools.obtain(Registrator.getByID((byte) num).__\u003C\u003Etype, Registrator.getByID((byte) num).__\u003C\u003Econstructor);
        packet.read(byteBuffer);
        return (object) packet;
      }

      [LineNumberTable(336)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PacketSerializer()
      {
      }

      [LineNumberTable(new byte[] {160, 238, 104, 105, 146, 127, 19, 109, 127, 15, 104, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write(ByteBuffer byteBuffer, object o)
      {
        switch (o)
        {
          case FrameworkMessage _:
            byteBuffer.put((byte) 254);
            this.writeFramework(byteBuffer, (FrameworkMessage) o);
            break;
          case Packet _:
            int id = (int) (sbyte) Registrator.getID(Object.instancehelper_getClass(o));
            if (id == -1)
            {
              string str = new StringBuilder().append("Unregistered class: ").append((object) Object.instancehelper_getClass(o)).toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new RuntimeException(str);
            }
            byteBuffer.put((byte) id);
            ((Packet) o).write(byteBuffer);
            break;
          default:
            string str1 = new StringBuilder().append("All sent objects must implement be Packets! Class: ").append((object) Object.instancehelper_getClass(o)).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException(str1);
        }
      }

      [LineNumberTable(new byte[] {161, 13, 136, 99, 102, 108, 112, 98, 100, 102, 100, 102, 100, 102, 108, 98, 100, 102, 108, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FrameworkMessage readFramework(ByteBuffer buffer)
      {
        switch ((sbyte) buffer.get())
        {
          case 0:
            return (FrameworkMessage) new FrameworkMessage.Ping()
            {
              id = buffer.getInt(),
              isReply = (buffer.get() == (byte) 1)
            };
          case 1:
            return (FrameworkMessage) new FrameworkMessage.DiscoverHost();
          case 2:
            return (FrameworkMessage) new FrameworkMessage.KeepAlive();
          case 3:
            return (FrameworkMessage) new FrameworkMessage.RegisterUDP()
            {
              connectionID = buffer.getInt()
            };
          case 4:
            return (FrameworkMessage) new FrameworkMessage.RegisterTCP()
            {
              connectionID = buffer.getInt()
            };
          default:
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException("Unknown framework message!");
        }
      }

      [LineNumberTable(new byte[] {160, 251, 127, 0, 104, 109, 120, 104, 109, 104, 109, 127, 0, 104, 111, 127, 0, 104, 141})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void writeFramework(ByteBuffer buffer, FrameworkMessage message)
      {
        FrameworkMessage frameworkMessage1 = message;
        FrameworkMessage.Ping ping;
        if (frameworkMessage1 is FrameworkMessage.Ping && object.ReferenceEquals((object) (ping = (FrameworkMessage.Ping) frameworkMessage1), (object) (FrameworkMessage.Ping) frameworkMessage1))
        {
          buffer.put((byte) 0);
          buffer.putInt(ping.id);
          buffer.put(!ping.isReply ? (byte) 0 : (byte) 1);
        }
        else
        {
          switch (message)
          {
            case FrameworkMessage.DiscoverHost _:
              buffer.put((byte) 1);
              break;
            case FrameworkMessage.KeepAlive _:
              buffer.put((byte) 2);
              break;
            default:
              FrameworkMessage frameworkMessage2 = message;
              FrameworkMessage.RegisterUDP registerUdp;
              if (frameworkMessage2 is FrameworkMessage.RegisterUDP && object.ReferenceEquals((object) (registerUdp = (FrameworkMessage.RegisterUDP) frameworkMessage2), (object) (FrameworkMessage.RegisterUDP) frameworkMessage2))
              {
                buffer.put((byte) 3);
                buffer.putInt(registerUdp.connectionID);
                break;
              }
              FrameworkMessage frameworkMessage3 = message;
              FrameworkMessage.RegisterTCP registerTcp;
              if (!(frameworkMessage3 is FrameworkMessage.RegisterTCP) || !object.ReferenceEquals((object) (registerTcp = (FrameworkMessage.RegisterTCP) frameworkMessage3), (object) (FrameworkMessage.RegisterTCP) frameworkMessage3))
                break;
              buffer.put((byte) 4);
              buffer.putInt(registerTcp.connectionID);
              break;
          }
        }
      }

      [HideFromJava]
      public virtual int getLengthLength() => NetSerializer.\u003Cdefault\u003EgetLengthLength((NetSerializer) this);

      [HideFromJava]
      public virtual void writeLength([In] ByteBuffer obj0, [In] int obj1) => NetSerializer.\u003Cdefault\u003EwriteLength((NetSerializer) this, obj0, obj1);

      [HideFromJava]
      public virtual int readLength([In] ByteBuffer obj0) => NetSerializer.\u003Cdefault\u003EreadLength((NetSerializer) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) ArcNetProvider.lambda\u0024new\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => ArcNetProvider.lambda\u0024new\u00241((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : ServerDiscoveryHandler
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void onDiscoverReceived([In] InetAddress obj0, [In] ServerDiscoveryHandler.ReponseHandler obj1) => ArcNetProvider.lambda\u0024new\u00242(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly ArcNetProvider arg\u00241;
      private readonly string arg\u00242;
      private readonly int arg\u00243;
      private readonly Runnable arg\u00244;

      internal __\u003C\u003EAnon3([In] ArcNetProvider obj0, [In] string obj1, [In] int obj2, [In] Runnable obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024connectClient\u00244(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly ArcNetProvider arg\u00241;
      private readonly string arg\u00242;
      private readonly int arg\u00243;
      private readonly Cons arg\u00244;
      private readonly Cons arg\u00245;

      internal __\u003C\u003EAnon4(
        [In] ArcNetProvider obj0,
        [In] string obj1,
        [In] int obj2,
        [In] Cons obj3,
        [In] Cons obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void run() => this.arg\u00241.lambda\u0024pingHost\u00247(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly Seq arg\u00241;
      private readonly long arg\u00242;
      private readonly Cons arg\u00243;

      internal __\u003C\u003EAnon5([In] Seq obj0, [In] long obj1, [In] Cons obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => ArcNetProvider.lambda\u0024discoverServers\u002410(this.arg\u00241, this.arg\u00242, this.arg\u00243, (DatagramPacket) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly Runnable arg\u00241;

      internal __\u003C\u003EAnon6([In] Runnable obj0) => this.arg\u00241 = obj0;

      public void run() => ArcNetProvider.lambda\u0024discoverServers\u002411(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly ArcNetProvider arg\u00241;

      internal __\u003C\u003EAnon7([In] ArcNetProvider obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024hostServer\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly Server arg\u00241;

      internal __\u003C\u003EAnon8([In] Server obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.stop();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly Seq arg\u00241;
      private readonly DatagramPacket arg\u00242;
      private readonly long arg\u00243;
      private readonly Cons arg\u00244;

      internal __\u003C\u003EAnon9([In] Seq obj0, [In] DatagramPacket obj1, [In] long obj2, [In] Cons obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => ArcNetProvider.lambda\u0024discoverServers\u00249(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Boolf
    {
      private readonly DatagramPacket arg\u00241;

      internal __\u003C\u003EAnon10([In] DatagramPacket obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (ArcNetProvider.lambda\u0024discoverServers\u00248(this.arg\u00241, (InetAddress) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly Cons arg\u00241;
      private readonly Host arg\u00242;

      internal __\u003C\u003EAnon11([In] Cons obj0, [In] Host obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => ArcNetProvider.lambda\u0024pingHost\u00245(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly Cons arg\u00241;
      private readonly Exception arg\u00242;

      internal __\u003C\u003EAnon12([In] Cons obj0, [In] Exception obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => ArcNetProvider.lambda\u0024pingHost\u00246(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly ArcNetProvider arg\u00241;

      internal __\u003C\u003EAnon13([In] ArcNetProvider obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024connectClient\u00243();
    }
  }
}
