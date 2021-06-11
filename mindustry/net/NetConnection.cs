// Decompiled with JetBrains decompiler
// Type: mindustry.net.NetConnection
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public abstract class NetConnection : Object
  {
    internal string __\u003C\u003Eaddress;
    public string uuid;
    public string usid;
    public bool mobile;
    public bool modclient;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public Player player;
    public bool kicked;
    public long syncTime;
    public long connectTime;
    public int lastReceivedClientSnapshot;
    public long lastReceivedClientTime;
    [Signature("Larc/struct/Seq<Lmindustry/entities/units/BuildPlan;>;")]
    public Seq rejectedRequests;
    public bool hasConnected;
    public bool hasBegunConnecting;
    public bool hasDisconnected;
    public float viewWidth;
    public float viewHeight;
    public float viewX;
    public float viewY;

    public abstract void close();

    [LineNumberTable(new byte[] {16, 137, 159, 47, 156, 135, 134, 111, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kick(string reason, long kickDuration)
    {
      if (this.kicked)
        return;
      object[] objArray = new object[2]
      {
        (object) this.__\u003C\u003Eaddress,
        null
      };
      string str = reason;
      object obj1 = (object) " ";
      object obj2 = (object) "\n";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      objArray[1] = (object) String.instancehelper_replace(str, charSequence2, charSequence3);
      Log.info("Kicking connection @; Reason: @", objArray);
      Vars.netServer.__\u003C\u003Eadmins.handleKicked(this.uuid, this.__\u003C\u003Eaddress, kickDuration);
      Call.kick(this, reason);
      this.close();
      Vars.netServer.__\u003C\u003Eadmins.save();
      this.kicked = true;
    }

    public abstract void send(object obj, Net.SendMode nsm);

    [LineNumberTable(new byte[] {159, 177, 232, 46, 183, 199, 139, 199, 235, 70, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NetConnection(string address)
    {
      NetConnection netConnection = this;
      this.uuid = "AAAAAAAA";
      this.usid = this.uuid;
      this.kicked = false;
      this.connectTime = Time.millis();
      this.lastReceivedClientSnapshot = -1;
      this.rejectedRequests = new Seq();
      this.__\u003C\u003Eaddress = address;
    }

    [LineNumberTable(new byte[] {159, 183, 137, 159, 3, 127, 8, 118, 110, 189, 135, 134, 111, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kick(Packets.KickReason reason)
    {
      if (this.kicked)
        return;
      Log.info("Kicking connection @; Reason: @", (object) this.__\u003C\u003Eaddress, (object) reason.name());
      if (object.ReferenceEquals((object) reason, (object) Packets.KickReason.__\u003C\u003Ekick) || object.ReferenceEquals((object) reason, (object) Packets.KickReason.__\u003C\u003Ebanned) || object.ReferenceEquals((object) reason, (object) Packets.KickReason.__\u003C\u003Evote))
      {
        Administration.PlayerInfo info = Vars.netServer.__\u003C\u003Eadmins.getInfo(this.uuid);
        ++info.timesKicked;
        info.lastKicked = Math.max(Time.millis() + 30000L, info.lastKicked);
      }
      Call.kick(this, reason);
      this.close();
      Vars.netServer.__\u003C\u003Eadmins.save();
      this.kicked = true;
    }

    [LineNumberTable(new byte[] {11, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void kick(string reason) => this.kick(reason, 30000L);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isConnected() => true;

    [LineNumberTable(new byte[] {37, 102, 113, 114, 108, 135, 110, 123, 141, 102, 103, 103, 108, 180, 2, 98, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void sendStream(Streamable stream)
    {
      IOException ioException1;
      try
      {
        Packets.StreamBegin streamBegin = new Packets.StreamBegin();
        streamBegin.total = stream.stream.available();
        streamBegin.type = Registrator.getID(Object.instancehelper_getClass((object) stream));
        this.send((object) streamBegin, Net.SendMode.__\u003C\u003Etcp);
        int id = streamBegin.id;
        while (stream.stream.available() > 0)
        {
          byte[] numArray = new byte[Math.min(512, stream.stream.available())];
          ((InputStream) stream.stream).read(numArray);
          this.send((object) new Packets.StreamChunk()
          {
            id = id,
            data = numArray
          }, Net.SendMode.__\u003C\u003Etcp);
        }
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [Modifiers]
    public string address
    {
      [HideFromJava] get => this.__\u003C\u003Eaddress;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eaddress = value;
    }
  }
}
