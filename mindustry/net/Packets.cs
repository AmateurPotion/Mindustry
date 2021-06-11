// Decompiled with JetBrains decompiler
// Type: mindustry.net.Packets
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.util.io;
using arc.util.pooling;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using java.util.zip;
using mindustry.io;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class Packets : Object
  {
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Packets()
    {
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/net/Packets$AdminAction;>;")]
    [Modifiers]
    [Serializable]
    public sealed class AdminAction : Enum
    {
      [Modifiers]
      internal static Packets.AdminAction __\u003C\u003Ekick;
      [Modifiers]
      internal static Packets.AdminAction __\u003C\u003Eban;
      [Modifiers]
      internal static Packets.AdminAction __\u003C\u003Etrace;
      [Modifiers]
      internal static Packets.AdminAction __\u003C\u003Ewave;
      [Modifiers]
      private static Packets.AdminAction[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Packets.AdminAction[] values() => (Packets.AdminAction[]) Packets.AdminAction.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private AdminAction([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Packets.AdminAction valueOf(string name) => (Packets.AdminAction) Enum.valueOf((Class) ClassLiteral<Packets.AdminAction>.Value, name);

      [LineNumberTable(new byte[] {159, 131, 109, 63, 33})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static AdminAction()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.net.Packets$AdminAction"))
          return;
        Packets.AdminAction.__\u003C\u003Ekick = new Packets.AdminAction(nameof (kick), 0);
        Packets.AdminAction.__\u003C\u003Eban = new Packets.AdminAction(nameof (ban), 1);
        Packets.AdminAction.__\u003C\u003Etrace = new Packets.AdminAction(nameof (trace), 2);
        Packets.AdminAction.__\u003C\u003Ewave = new Packets.AdminAction(nameof (wave), 3);
        Packets.AdminAction.\u0024VALUES = new Packets.AdminAction[4]
        {
          Packets.AdminAction.__\u003C\u003Ekick,
          Packets.AdminAction.__\u003C\u003Eban,
          Packets.AdminAction.__\u003C\u003Etrace,
          Packets.AdminAction.__\u003C\u003Ewave
        };
      }

      [Modifiers]
      public static Packets.AdminAction kick
      {
        [HideFromJava] get => Packets.AdminAction.__\u003C\u003Ekick;
      }

      [Modifiers]
      public static Packets.AdminAction ban
      {
        [HideFromJava] get => Packets.AdminAction.__\u003C\u003Eban;
      }

      [Modifiers]
      public static Packets.AdminAction trace
      {
        [HideFromJava] get => Packets.AdminAction.__\u003C\u003Etrace;
      }

      [Modifiers]
      public static Packets.AdminAction wave
      {
        [HideFromJava] get => Packets.AdminAction.__\u003C\u003Ewave;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        kick,
        ban,
        trace,
        wave,
      }
    }

    [Implements(new string[] {"mindustry.net.Packet"})]
    public class Connect : Object, Packet, Pool.Poolable
    {
      public string addressTCP;

      [LineNumberTable(48)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Connect()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isImportant() => true;

      [HideFromJava]
      public virtual void reset() => Packet.\u003Cdefault\u003Ereset((Packet) this);

      [HideFromJava]
      public virtual void read([In] ByteBuffer obj0) => Packet.\u003Cdefault\u003Eread((Packet) this, obj0);

      [HideFromJava]
      public virtual void write([In] ByteBuffer obj0) => Packet.\u003Cdefault\u003Ewrite((Packet) this, obj0);

      [HideFromJava]
      public virtual bool isUnimportant() => Packet.\u003Cdefault\u003EisUnimportant((Packet) this);
    }

    [Implements(new string[] {"mindustry.net.Packet"})]
    public class ConnectPacket : Object, Packet, Pool.Poolable
    {
      public int version;
      public string versionType;
      [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
      public Seq mods;
      public string name;
      public string locale;
      public string uuid;
      public string usid;
      public bool mobile;
      public int color;

      [LineNumberTable(159)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ConnectPacket()
      {
      }

      [LineNumberTable(new byte[] {119, 108, 108, 108, 108, 140, 108, 104, 102, 116, 141, 115, 109, 115, 112, 55, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write(ByteBuffer buffer)
      {
        buffer.putInt(mindustry.core.Version.build);
        TypeIO.writeString(buffer, this.versionType);
        TypeIO.writeString(buffer, this.name);
        TypeIO.writeString(buffer, this.locale);
        TypeIO.writeString(buffer, this.usid);
        byte[] numArray = Base64Coder.decode(this.uuid);
        buffer.put(numArray);
        CRC32 crC32 = new CRC32();
        crC32.update(Base64Coder.decode(this.uuid), 0, numArray.Length);
        buffer.putLong(crC32.getValue());
        buffer.put(!this.mobile ? (byte) 0 : (byte) 1);
        buffer.putInt(this.color);
        buffer.put((byte) this.mods.size);
        for (int index = 0; index < this.mods.size; ++index)
          TypeIO.writeString(buffer, (string) this.mods.get(index));
      }

      [LineNumberTable(new byte[] {160, 77, 108, 108, 108, 108, 108, 104, 104, 113, 112, 108, 104, 108, 102, 49, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void read(ByteBuffer buffer)
      {
        this.version = buffer.getInt();
        this.versionType = TypeIO.readString(buffer);
        this.name = TypeIO.readString(buffer);
        this.locale = TypeIO.readString(buffer);
        this.usid = TypeIO.readString(buffer);
        byte[] @in = new byte[16];
        buffer.get(@in);
        this.uuid = String.newhelper(Base64Coder.encode(@in));
        this.mobile = buffer.get() == (byte) 1;
        this.color = buffer.getInt();
        int capacity = (int) (sbyte) buffer.get();
        this.mods = new Seq(capacity);
        for (int index = 0; index < capacity; ++index)
          this.mods.add((object) TypeIO.readString(buffer));
      }

      [HideFromJava]
      public virtual void reset() => Packet.\u003Cdefault\u003Ereset((Packet) this);

      [HideFromJava]
      public virtual bool isImportant() => Packet.\u003Cdefault\u003EisImportant((Packet) this);

      [HideFromJava]
      public virtual bool isUnimportant() => Packet.\u003Cdefault\u003EisUnimportant((Packet) this);
    }

    [Implements(new string[] {"mindustry.net.Packet"})]
    public class Disconnect : Object, Packet, Pool.Poolable
    {
      public string reason;

      [LineNumberTable(57)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Disconnect()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isImportant() => true;

      [HideFromJava]
      public virtual void reset() => Packet.\u003Cdefault\u003Ereset((Packet) this);

      [HideFromJava]
      public virtual void read([In] ByteBuffer obj0) => Packet.\u003Cdefault\u003Eread((Packet) this, obj0);

      [HideFromJava]
      public virtual void write([In] ByteBuffer obj0) => Packet.\u003Cdefault\u003Ewrite((Packet) this, obj0);

      [HideFromJava]
      public virtual bool isUnimportant() => Packet.\u003Cdefault\u003EisUnimportant((Packet) this);
    }

    [Implements(new string[] {"mindustry.net.Packet"})]
    public class InvokePacket : Object, Packet, Pool.Poolable
    {
      private static ReusableByteInStream bin;
      private static Reads read;
      public byte type;
      public byte priority;
      public byte[] bytes;
      public int length;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {62, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Reads reader()
      {
        Packets.InvokePacket.bin.setBytes(this.bytes);
        return Packets.InvokePacket.read;
      }

      [LineNumberTable(70)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public InvokePacket()
      {
      }

      [LineNumberTable(new byte[] {31, 109, 109, 103, 108, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void read(ByteBuffer buffer)
      {
        this.type = buffer.get();
        this.priority = buffer.get();
        this.bytes = new byte[(int) buffer.getShort()];
        buffer.get(this.bytes);
      }

      [LineNumberTable(new byte[] {40, 110, 110, 110, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write(ByteBuffer buffer)
      {
        buffer.put(this.type);
        buffer.put(this.priority);
        buffer.putShort((short) this.length);
        buffer.put(this.bytes, 0, this.length);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void reset() => this.priority = (byte) 0;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isImportant() => this.priority == (byte) 1;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isUnimportant() => this.priority == (byte) 2;

      [LineNumberTable(72)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static InvokePacket()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.net.Packets$InvokePacket"))
          return;
        Reads.__\u003Cclinit\u003E();
        Packets.InvokePacket.read = new Reads((DataInput) new DataInputStream((InputStream) (Packets.InvokePacket.bin = new ReusableByteInStream())));
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/net/Packets$KickReason;>;")]
    [Modifiers]
    [Serializable]
    public sealed class KickReason : Enum
    {
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003Ekick;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EclientOutdated;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EserverOutdated;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003Ebanned;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003Egameover;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003ErecentKick;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EnameInUse;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EidInUse;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EnameEmpty;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EcustomClient;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EserverClose;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003Evote;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EtypeMismatch;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003Ewhitelist;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EplayerLimit;
      [Modifiers]
      internal static Packets.KickReason __\u003C\u003EserverRestarting;
      internal bool __\u003C\u003Equiet;
      [Modifiers]
      private static Packets.KickReason[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(36)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => Core.bundle.get(new StringBuilder().append("server.kicked.").append(this.name()).toString());

      [LineNumberTable(40)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string extraText() => Core.bundle.getOrNull(new StringBuilder().append("server.kicked.").append(this.name()).append(".text").toString());

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Packets.KickReason[] values() => (Packets.KickReason[]) Packets.KickReason.\u0024VALUES.Clone();

      [Signature("(Z)V")]
      [LineNumberTable(new byte[] {159, 135, 130, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private KickReason([In] string obj0, [In] int obj1, [In] bool obj2)
      {
        int num = obj2 ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0, obj1);
        Packets.KickReason kickReason = this;
        this.__\u003C\u003Equiet = num != 0;
        GC.KeepAlive((object) this);
      }

      [Signature("()V")]
      [LineNumberTable(new byte[] {159, 169, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private KickReason([In] string obj0, [In] int obj1)
        : this(obj0, obj1, false)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Packets.KickReason valueOf(string name) => (Packets.KickReason) Enum.valueOf((Class) ClassLiteral<Packets.KickReason>.Value, name);

      [LineNumberTable(new byte[] {159, 137, 77, 127, 66, 127, 85, 255, 20, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static KickReason()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.net.Packets$KickReason"))
          return;
        Packets.KickReason.__\u003C\u003Ekick = new Packets.KickReason(nameof (kick), 0);
        Packets.KickReason.__\u003C\u003EclientOutdated = new Packets.KickReason(nameof (clientOutdated), 1);
        Packets.KickReason.__\u003C\u003EserverOutdated = new Packets.KickReason(nameof (serverOutdated), 2);
        Packets.KickReason.__\u003C\u003Ebanned = new Packets.KickReason(nameof (banned), 3);
        Packets.KickReason.__\u003C\u003Egameover = new Packets.KickReason(nameof (gameover), 4, true);
        Packets.KickReason.__\u003C\u003ErecentKick = new Packets.KickReason(nameof (recentKick), 5);
        Packets.KickReason.__\u003C\u003EnameInUse = new Packets.KickReason(nameof (nameInUse), 6);
        Packets.KickReason.__\u003C\u003EidInUse = new Packets.KickReason(nameof (idInUse), 7);
        Packets.KickReason.__\u003C\u003EnameEmpty = new Packets.KickReason(nameof (nameEmpty), 8);
        Packets.KickReason.__\u003C\u003EcustomClient = new Packets.KickReason(nameof (customClient), 9);
        Packets.KickReason.__\u003C\u003EserverClose = new Packets.KickReason(nameof (serverClose), 10);
        Packets.KickReason.__\u003C\u003Evote = new Packets.KickReason(nameof (vote), 11);
        Packets.KickReason.__\u003C\u003EtypeMismatch = new Packets.KickReason(nameof (typeMismatch), 12);
        Packets.KickReason.__\u003C\u003Ewhitelist = new Packets.KickReason(nameof (whitelist), 13);
        Packets.KickReason.__\u003C\u003EplayerLimit = new Packets.KickReason(nameof (playerLimit), 14);
        Packets.KickReason.__\u003C\u003EserverRestarting = new Packets.KickReason(nameof (serverRestarting), 15);
        Packets.KickReason.\u0024VALUES = new Packets.KickReason[16]
        {
          Packets.KickReason.__\u003C\u003Ekick,
          Packets.KickReason.__\u003C\u003EclientOutdated,
          Packets.KickReason.__\u003C\u003EserverOutdated,
          Packets.KickReason.__\u003C\u003Ebanned,
          Packets.KickReason.__\u003C\u003Egameover,
          Packets.KickReason.__\u003C\u003ErecentKick,
          Packets.KickReason.__\u003C\u003EnameInUse,
          Packets.KickReason.__\u003C\u003EidInUse,
          Packets.KickReason.__\u003C\u003EnameEmpty,
          Packets.KickReason.__\u003C\u003EcustomClient,
          Packets.KickReason.__\u003C\u003EserverClose,
          Packets.KickReason.__\u003C\u003Evote,
          Packets.KickReason.__\u003C\u003EtypeMismatch,
          Packets.KickReason.__\u003C\u003Ewhitelist,
          Packets.KickReason.__\u003C\u003EplayerLimit,
          Packets.KickReason.__\u003C\u003EserverRestarting
        };
      }

      [Modifiers]
      public static Packets.KickReason kick
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003Ekick;
      }

      [Modifiers]
      public static Packets.KickReason clientOutdated
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EclientOutdated;
      }

      [Modifiers]
      public static Packets.KickReason serverOutdated
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EserverOutdated;
      }

      [Modifiers]
      public static Packets.KickReason banned
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003Ebanned;
      }

      [Modifiers]
      public static Packets.KickReason gameover
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003Egameover;
      }

      [Modifiers]
      public static Packets.KickReason recentKick
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003ErecentKick;
      }

      [Modifiers]
      public static Packets.KickReason nameInUse
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EnameInUse;
      }

      [Modifiers]
      public static Packets.KickReason idInUse
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EidInUse;
      }

      [Modifiers]
      public static Packets.KickReason nameEmpty
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EnameEmpty;
      }

      [Modifiers]
      public static Packets.KickReason customClient
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EcustomClient;
      }

      [Modifiers]
      public static Packets.KickReason serverClose
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EserverClose;
      }

      [Modifiers]
      public static Packets.KickReason vote
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003Evote;
      }

      [Modifiers]
      public static Packets.KickReason typeMismatch
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EtypeMismatch;
      }

      [Modifiers]
      public static Packets.KickReason whitelist
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003Ewhitelist;
      }

      [Modifiers]
      public static Packets.KickReason playerLimit
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EplayerLimit;
      }

      [Modifiers]
      public static Packets.KickReason serverRestarting
      {
        [HideFromJava] get => Packets.KickReason.__\u003C\u003EserverRestarting;
      }

      [Modifiers]
      public bool quiet
      {
        [HideFromJava] get => this.__\u003C\u003Equiet;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Equiet = value;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        kick,
        clientOutdated,
        serverOutdated,
        banned,
        gameover,
        recentKick,
        nameInUse,
        idInUse,
        nameEmpty,
        customClient,
        serverClose,
        vote,
        typeMismatch,
        whitelist,
        playerLimit,
        serverRestarting,
      }
    }

    [Implements(new string[] {"mindustry.net.Packet"})]
    public class StreamBegin : Object, Packet, Pool.Poolable
    {
      private static int lastid;
      public int id;
      public int total;
      public byte type;

      [LineNumberTable(new byte[] {68, 168})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StreamBegin()
      {
        Packets.StreamBegin streamBegin = this;
        this.id = Packets.StreamBegin.lastid++;
      }

      [LineNumberTable(new byte[] {77, 109, 109, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write(ByteBuffer buffer)
      {
        buffer.putInt(this.id);
        buffer.putInt(this.total);
        buffer.put(this.type);
      }

      [LineNumberTable(new byte[] {84, 108, 108, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void read(ByteBuffer buffer)
      {
        this.id = buffer.getInt();
        this.total = buffer.getInt();
        this.type = buffer.get();
      }

      [HideFromJava]
      public virtual void reset() => Packet.\u003Cdefault\u003Ereset((Packet) this);

      [HideFromJava]
      public virtual bool isImportant() => Packet.\u003Cdefault\u003EisImportant((Packet) this);

      [HideFromJava]
      public virtual bool isUnimportant() => Packet.\u003Cdefault\u003EisUnimportant((Packet) this);
    }

    [Implements(new string[] {"mindustry.net.Packet"})]
    public class StreamChunk : Object, Packet, Pool.Poolable
    {
      public int id;
      public byte[] data;

      [LineNumberTable(140)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StreamChunk()
      {
      }

      [LineNumberTable(new byte[] {96, 109, 111, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write(ByteBuffer buffer)
      {
        buffer.putInt(this.id);
        buffer.putShort((short) this.data.Length);
        buffer.put(this.data);
      }

      [LineNumberTable(new byte[] {103, 108, 113, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void read(ByteBuffer buffer)
      {
        this.id = buffer.getInt();
        this.data = new byte[(int) buffer.getShort()];
        buffer.get(this.data);
      }

      [HideFromJava]
      public virtual void reset() => Packet.\u003Cdefault\u003Ereset((Packet) this);

      [HideFromJava]
      public virtual bool isImportant() => Packet.\u003Cdefault\u003EisImportant((Packet) this);

      [HideFromJava]
      public virtual bool isUnimportant() => Packet.\u003Cdefault\u003EisUnimportant((Packet) this);
    }

    public class WorldStream : Streamable
    {
      [LineNumberTable(66)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public WorldStream()
      {
      }
    }
  }
}
