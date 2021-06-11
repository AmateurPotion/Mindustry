// Decompiled with JetBrains decompiler
// Type: mindustry.net.Net
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.net;
using arc.util;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using java.nio.channels;
using java.util;
using mindustry.core;
using mindustry.gen;
using net.jpountz.lz4;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class Net : Object
  {
    private bool server;
    private bool active;
    private bool clientLoaded;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private Streamable.StreamBuilder currentStream;
    [Modifiers]
    [Signature("Larc/struct/Seq<Ljava/lang/Object;>;")]
    private Seq packetQueue;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class<*>;Larc/func/Cons;>;")]
    private ObjectMap clientListeners;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class<*>;Larc/func/Cons2<Lmindustry/net/NetConnection;Ljava/lang/Object;>;>;")]
    private ObjectMap serverListeners;
    [Modifiers]
    [Signature("Larc/struct/IntMap<Lmindustry/net/Streamable$StreamBuilder;>;")]
    private IntMap streams;
    [Modifiers]
    private Net.NetProvider provider;
    [Modifiers]
    private LZ4FastDecompressor decompressor;
    [Modifiers]
    private LZ4Compressor compressor;

    [LineNumberTable(new byte[] {159, 178, 232, 55, 107, 107, 107, 171, 112, 176, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Net(Net.NetProvider provider)
    {
      Net net = this;
      this.packetQueue = new Seq();
      this.clientListeners = new ObjectMap();
      this.serverListeners = new ObjectMap();
      this.streams = new IntMap();
      this.decompressor = LZ4Factory.fastestInstance().fastDecompressor();
      this.compressor = LZ4Factory.fastestInstance().fastCompressor();
      this.provider = provider;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool active() => this.active;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool client() => !this.server && this.active;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool server() => this.server && this.active;

    [LineNumberTable(new byte[] {160, 162, 115, 125, 136, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleServerReceived(NetConnection connection, object @object)
    {
      if (this.serverListeners.get((object) Object.instancehelper_getClass(@object)) != null)
      {
        ((Cons2) this.serverListeners.get((object) Object.instancehelper_getClass(@object))).get((object) connection, @object);
        Pools.free(@object);
      }
      else
        Log.err("Unhandled packet type: '@'!", (object) Object.instancehelper_getClass(@object));
    }

    [LineNumberTable(new byte[] {160, 126, 127, 0, 159, 9, 127, 6, 120, 100, 144, 109, 105, 115, 109, 135, 155, 125, 115, 156, 104, 117, 142, 168, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleClientReceived(object @object)
    {
      object obj1 = @object;
      Packets.StreamBegin begin;
      if (obj1 is Packets.StreamBegin && object.ReferenceEquals((object) (begin = (Packets.StreamBegin) obj1), (object) (Packets.StreamBegin) obj1))
      {
        IntMap streams = this.streams;
        int id = begin.id;
        Net net = this;
        Streamable.StreamBuilder streamBuilder1 = new Streamable.StreamBuilder(begin);
        Streamable.StreamBuilder streamBuilder2 = streamBuilder1;
        this.currentStream = streamBuilder1;
        streams.put(id, (object) streamBuilder2);
      }
      else
      {
        object obj2 = @object;
        Packets.StreamChunk streamChunk;
        if (obj2 is Packets.StreamChunk && object.ReferenceEquals((object) (streamChunk = (Packets.StreamChunk) obj2), (object) (Packets.StreamChunk) obj2))
        {
          Streamable.StreamBuilder streamBuilder = (Streamable.StreamBuilder) this.streams.get(streamChunk.id);
          if (streamBuilder == null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException("Received stream chunk without a StreamBegin beforehand!");
          }
          streamBuilder.add(streamChunk.data);
          if (!streamBuilder.isDone())
            return;
          this.streams.remove(streamBuilder.__\u003C\u003Eid);
          this.handleClientReceived((object) streamBuilder.build());
          this.currentStream = (Streamable.StreamBuilder) null;
        }
        else if (this.clientListeners.get((object) Object.instancehelper_getClass(@object)) != null)
        {
          if (this.clientLoaded || @object is Packet && ((Packet) @object).isImportant())
          {
            if (this.clientListeners.get((object) Object.instancehelper_getClass(@object)) != null)
              ((Cons) this.clientListeners.get((object) Object.instancehelper_getClass(@object))).get(@object);
            Pools.free(@object);
          }
          else if (!(@object is Packet) || !((Packet) @object).isUnimportant())
            this.packetQueue.add(@object);
          else
            Pools.free(@object);
        }
        else
          Log.err("Unhandled packet type: '@'!", @object);
      }
    }

    [LineNumberTable(new byte[] {159, 183, 104, 119, 104, 151, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleException(Exception e)
    {
      switch (e)
      {
        case ArcNetException _:
          Core.app.post((Runnable) new Net.__\u003C\u003EAnon0(this));
          break;
        case ClosedChannelException _:
          Core.app.post((Runnable) new Net.__\u003C\u003EAnon1(this));
          break;
        default:
          Core.app.post((Runnable) new Net.__\u003C\u003EAnon2(this, e));
          break;
      }
    }

    [LineNumberTable(new byte[] {3, 138, 98, 104, 169, 135, 113, 113, 131, 112, 117, 109, 117, 127, 160, 71, 117, 127, 62, 117, 127, 0, 117, 127, 13, 114, 104, 112, 163, 100, 146, 159, 9, 143, 104, 202, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showError(Exception e)
    {
      if (!Vars.headless)
      {
        Exception exception = e;
        while (Throwable.instancehelper_getCause(exception) != null)
          exception = Throwable.instancehelper_getCause(exception);
        string finalMessage = Strings.getFinalMessage(e);
        string str1 = finalMessage != null ? String.instancehelper_toLowerCase(finalMessage) : "";
        string lowerCase = String.instancehelper_toLowerCase(Object.instancehelper_getClass((object) exception).toString());
        int num = 0;
        if (e is BufferUnderflowException || e is BufferOverflowException)
          str1 = Core.bundle.get("error.io");
        else if (String.instancehelper_equals(str1, (object) "mismatch"))
        {
          str1 = Core.bundle.get("error.mismatch");
        }
        else
        {
          string str2 = str1;
          object obj1 = (object) "port out of range";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj1;
          CharSequence charSequence2 = charSequence1;
          if (!String.instancehelper_contains(str2, charSequence2))
          {
            string str3 = str1;
            object obj2 = (object) "invalid argument";
            charSequence1.__\u003Cref\u003E = (__Null) obj2;
            CharSequence charSequence3 = charSequence1;
            if (!String.instancehelper_contains(str3, charSequence3))
            {
              string str4 = str1;
              object obj3 = (object) "invalid";
              charSequence1.__\u003Cref\u003E = (__Null) obj3;
              CharSequence charSequence4 = charSequence1;
              if (String.instancehelper_contains(str4, charSequence4))
              {
                string str5 = str1;
                object obj4 = (object) "address";
                charSequence1.__\u003Cref\u003E = (__Null) obj4;
                CharSequence charSequence5 = charSequence1;
                if (String.instancehelper_contains(str5, charSequence5))
                  goto label_13;
              }
              string str6 = Strings.neatError(e);
              object obj5 = (object) "address associated";
              charSequence1.__\u003Cref\u003E = (__Null) obj5;
              CharSequence charSequence6 = charSequence1;
              if (!String.instancehelper_contains(str6, charSequence6))
              {
                string str5 = str1;
                object obj4 = (object) "connection refused";
                charSequence1.__\u003Cref\u003E = (__Null) obj4;
                CharSequence charSequence5 = charSequence1;
                if (!String.instancehelper_contains(str5, charSequence5))
                {
                  string str7 = str1;
                  object obj6 = (object) "route to host";
                  charSequence1.__\u003Cref\u003E = (__Null) obj6;
                  CharSequence charSequence7 = charSequence1;
                  if (!String.instancehelper_contains(str7, charSequence7))
                  {
                    string str8 = lowerCase;
                    object obj7 = (object) "unknownhost";
                    charSequence1.__\u003Cref\u003E = (__Null) obj7;
                    CharSequence charSequence8 = charSequence1;
                    if (!String.instancehelper_contains(str8, charSequence8))
                    {
                      string str9 = lowerCase;
                      object obj8 = (object) "timeout";
                      charSequence1.__\u003Cref\u003E = (__Null) obj8;
                      CharSequence charSequence9 = charSequence1;
                      if (String.instancehelper_contains(str9, charSequence9))
                      {
                        str1 = Core.bundle.get("error.timedout");
                        goto label_25;
                      }
                      else
                      {
                        if (!String.instancehelper_equals(str1, (object) "alreadyconnected"))
                        {
                          string str10 = str1;
                          object obj9 = (object) "connection is closed";
                          charSequence1.__\u003Cref\u003E = (__Null) obj9;
                          CharSequence charSequence10 = charSequence1;
                          if (!String.instancehelper_contains(str10, charSequence10))
                          {
                            if (!String.instancehelper_isEmpty(str1))
                            {
                              str1 = Core.bundle.get("error.any");
                              num = 1;
                              goto label_25;
                            }
                            else
                              goto label_25;
                          }
                        }
                        str1 = Core.bundle.get("error.alreadyconnected");
                        goto label_25;
                      }
                    }
                  }
                }
                str1 = Core.bundle.get("error.unreachable");
                goto label_25;
              }
            }
          }
label_13:
          str1 = Core.bundle.get("error.invalidaddress");
        }
label_25:
        if (num != 0)
          Vars.ui.showException("@error.any", e);
        else
          Vars.ui.showText("", Core.bundle.format("connectfail", (object) str1));
        Vars.ui.loadfrag.hide();
        if (this.client())
          Vars.netClient.disconnectQuietly();
      }
      Log.err(e);
    }

    [LineNumberTable(new byte[] {111, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.closeServer();
      Vars.netClient.disconnectNoReset();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setClientConnected()
    {
      this.active = true;
      this.server = false;
    }

    [LineNumberTable(new byte[] {116, 112, 138, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disconnect()
    {
      if (this.active && !this.server)
        Log.info((object) "Disconnecting.");
      this.provider.disconnectClient();
      this.server = false;
      this.active = false;
    }

    [LineNumberTable(new byte[] {160, 199, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.provider.dispose();
      this.server = false;
      this.active = false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {90, 108, 103, 135, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void host(int port)
    {
      this.provider.hostServer(port);
      this.active = true;
      this.server = true;
      Platform platform = Vars.platform;
      Objects.requireNonNull((object) platform);
      Time.runTask(60f, (Runnable) new Net.__\u003C\u003EAnon3(platform));
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {160, 111, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleClient(Class type, Cons listener) => this.clientListeners.put((object) type, (object) listener);

    [LineNumberTable(new byte[] {159, 117, 130, 135, 131, 112, 50, 230, 69, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setClientLoaded(bool loaded)
    {
      int num = loaded ? 1 : 0;
      this.clientLoaded = num != 0;
      if (num != 0)
      {
        for (int index = 0; index < this.packetQueue.size; ++index)
          this.handleClientReceived(this.packetQueue.get(index));
      }
      this.packetQueue.clear();
    }

    [LineNumberTable(179)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] decompressSnapshot(byte[] input, int size) => this.decompressor.decompress(input, size);

    [LineNumberTable(new byte[] {160, 85, 104, 127, 6, 104, 132, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void send(object @object, Net.SendMode mode)
    {
      if (this.server)
      {
        Iterator iterator = this.provider.getConnections().iterator();
        while (iterator.hasNext())
          ((NetConnection) iterator.next()).send(@object, mode);
      }
      else
        this.provider.sendClient(@object, mode);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/func/Cons2<Lmindustry/net/NetConnection;TT;>;)V")]
    [LineNumberTable(new byte[] {160, 118, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void handleServer(Class type, Cons2 listener) => this.serverListeners.put((object) type, (object) listener);

    [Signature("()Ljava/lang/Iterable<Lmindustry/net/NetConnection;>;")]
    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterable getConnections() => this.provider.getConnections();

    [LineNumberTable(175)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] compressSnapshot(byte[] input) => this.compressor.compress(input);

    [LineNumberTable(new byte[] {101, 127, 1, 107, 130, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void closeServer()
    {
      Iterator iterator = this.getConnections().iterator();
      while (iterator.hasNext())
        Call.kick((NetConnection) iterator.next(), Packets.KickReason.__\u003C\u003EserverClose);
      this.provider.closeServer();
      this.server = false;
      this.active = false;
    }

    [LineNumberTable(new byte[] {160, 96, 127, 1, 105, 136, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendExcept(NetConnection except, object @object, Net.SendMode mode)
    {
      Iterator iterator = this.getConnections().iterator();
      while (iterator.hasNext())
      {
        NetConnection netConnection = (NetConnection) iterator.next();
        if (!object.ReferenceEquals((object) netConnection, (object) except))
          netConnection.send(@object, mode);
      }
    }

    [Modifiers]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024handleException\u00240() => this.showError((Exception) new IOException("mismatch"));

    [Modifiers]
    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024handleException\u00241() => this.showError((Exception) new IOException("alreadyconnected"));

    [Modifiers]
    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024handleException\u00242([In] Exception obj0) => this.showError(obj0);

    [LineNumberTable(new byte[] {74, 104, 110, 103, 137, 223, 1, 2, 97, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connect(string ip, int port, Runnable success)
    {
      IOException ioException;
      try
      {
        if (!this.active)
        {
          this.provider.connectClient(ip, port, success);
          this.active = true;
          this.server = false;
          return;
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException("alreadyconnected");
      }
      catch (IOException ex)
      {
        ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      this.showError((Exception) ioException);
    }

    [Signature("(Larc/func/Cons<Lmindustry/net/Host;>;Ljava/lang/Runnable;)V")]
    [LineNumberTable(new byte[] {160, 73, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void discoverServers(Cons cons, Runnable done) => this.provider.discoverServers(cons, done);

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Streamable.StreamBuilder getCurrentStream() => this.currentStream;

    [Signature("(Ljava/lang/String;ILarc/func/Cons<Lmindustry/net/Host;>;Larc/func/Cons<Ljava/lang/Exception;>;)V")]
    [LineNumberTable(new byte[] {160, 174, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void pingHost(string address, int port, Cons valid, Cons failed) => this.provider.pingHost(address, port, valid, failed);

    public interface NetProvider
    {
      void disconnectClient();

      void closeServer();

      [Throws(new string[] {"java.io.IOException"})]
      void connectClient(string str, int i, Runnable r);

      void sendClient(object obj, Net.SendMode nsm);

      [Signature("(Larc/func/Cons<Lmindustry/net/Host;>;Ljava/lang/Runnable;)V")]
      void discoverServers(Cons c, Runnable r);

      [Signature("(Ljava/lang/String;ILarc/func/Cons<Lmindustry/net/Host;>;Larc/func/Cons<Ljava/lang/Exception;>;)V")]
      void pingHost(string str, int i, Cons c1, Cons c2);

      [Throws(new string[] {"java.io.IOException"})]
      void hostServer(int i);

      [Signature("()Ljava/lang/Iterable<+Lmindustry/net/NetConnection;>;")]
      Iterable getConnections();

      [Modifiers]
      void dispose();

      [LineNumberTable(new byte[] {160, 240, 102, 102})]
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static void \u003Cdefault\u003Edispose([In] Net.NetProvider obj0)
      {
        obj0.disconnectClient();
        obj0.closeServer();
      }

      [HideFromJava]
      static class __DefaultMethods
      {
        public static void dispose([In] Net.NetProvider obj0)
        {
          Net.NetProvider netProvider = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(netProvider, ToString);
          Net.NetProvider.\u003Cdefault\u003Edispose(netProvider);
        }
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/net/Net$SendMode;>;")]
    [Modifiers]
    [Serializable]
    public sealed class SendMode : Enum
    {
      [Modifiers]
      internal static Net.SendMode __\u003C\u003Etcp;
      [Modifiers]
      internal static Net.SendMode __\u003C\u003Eudp;
      [Modifiers]
      private static Net.SendMode[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(318)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private SendMode([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(318)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Net.SendMode[] values() => (Net.SendMode[]) Net.SendMode.\u0024VALUES.Clone();

      [LineNumberTable(318)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Net.SendMode valueOf(string name) => (Net.SendMode) Enum.valueOf((Class) ClassLiteral<Net.SendMode>.Value, name);

      [LineNumberTable(new byte[] {159, 63, 173, 63, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static SendMode()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.net.Net$SendMode"))
          return;
        Net.SendMode.__\u003C\u003Etcp = new Net.SendMode(nameof (tcp), 0);
        Net.SendMode.__\u003C\u003Eudp = new Net.SendMode(nameof (udp), 1);
        Net.SendMode.\u0024VALUES = new Net.SendMode[2]
        {
          Net.SendMode.__\u003C\u003Etcp,
          Net.SendMode.__\u003C\u003Eudp
        };
      }

      [Modifiers]
      public static Net.SendMode tcp
      {
        [HideFromJava] get => Net.SendMode.__\u003C\u003Etcp;
      }

      [Modifiers]
      public static Net.SendMode udp
      {
        [HideFromJava] get => Net.SendMode.__\u003C\u003Eudp;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        tcp,
        udp,
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Net arg\u00241;

      internal __\u003C\u003EAnon0([In] Net obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024handleException\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly Net arg\u00241;

      internal __\u003C\u003EAnon1([In] Net obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024handleException\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly Net arg\u00241;
      private readonly Exception arg\u00242;

      internal __\u003C\u003EAnon2([In] Net obj0, [In] Exception obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024handleException\u00242(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly Platform arg\u00241;

      internal __\u003C\u003EAnon3([In] Platform obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.updateRPC();
    }
  }
}
