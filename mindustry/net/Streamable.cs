// Decompiled with JetBrains decompiler
// Type: mindustry.net.Streamable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.pooling;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  [Implements(new string[] {"mindustry.net.Packet"})]
  public class Streamable : Object, Packet, Pool.Poolable
  {
    [NonSerialized]
    public ByteArrayInputStream stream;

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Streamable()
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

    public class StreamBuilder : Object
    {
      internal int __\u003C\u003Eid;
      internal byte __\u003C\u003Etype;
      internal int __\u003C\u003Etotal;
      internal ByteArrayOutputStream __\u003C\u003Estream;

      [LineNumberTable(new byte[] {159, 163, 8, 171, 108, 109, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StreamBuilder(Packets.StreamBegin begin)
      {
        Streamable.StreamBuilder streamBuilder = this;
        this.__\u003C\u003Estream = new ByteArrayOutputStream();
        this.__\u003C\u003Eid = begin.id;
        this.__\u003C\u003Etype = begin.type;
        this.__\u003C\u003Etotal = begin.total;
      }

      [LineNumberTable(new byte[] {159, 175, 190, 2, 97, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void add(byte[] bytes)
      {
        IOException ioException1;
        try
        {
          ((OutputStream) this.__\u003C\u003Estream).write(bytes);
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

      [LineNumberTable(46)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isDone() => this.__\u003C\u003Estream.size() >= this.__\u003C\u003Etotal;

      [LineNumberTable(new byte[] {159, 182, 124, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Streamable build()
      {
        Streamable streamable = (Streamable) Registrator.getByID(this.__\u003C\u003Etype).__\u003C\u003Econstructor.get();
        streamable.stream = new ByteArrayInputStream(this.__\u003C\u003Estream.toByteArray());
        return streamable;
      }

      [LineNumberTable(28)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float progress() => (float) this.__\u003C\u003Estream.size() / (float) this.__\u003C\u003Etotal;

      [Modifiers]
      public int id
      {
        [HideFromJava] get => this.__\u003C\u003Eid;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eid = value;
      }

      [Modifiers]
      public byte type
      {
        [HideFromJava] get => this.__\u003C\u003Etype;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etype = value;
      }

      [Modifiers]
      public int total
      {
        [HideFromJava] get => this.__\u003C\u003Etotal;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etotal = value;
      }

      [Modifiers]
      public ByteArrayOutputStream stream
      {
        [HideFromJava] get => this.__\u003C\u003Estream;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Estream = value;
      }
    }
  }
}
