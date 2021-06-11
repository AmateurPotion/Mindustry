// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.BufferedItemBridge
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using arc.util.io;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.distribution
{
  public class BufferedItemBridge : ExtendingItemBridge
  {
    internal int __\u003C\u003EtimerAccept;
    public float speed;
    public int bufferCapacity;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 233, 58, 153, 107, 200, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BufferedItemBridge(string name)
      : base(name)
    {
      BufferedItemBridge bufferedItemBridge1 = this;
      BufferedItemBridge bufferedItemBridge2 = this;
      int timers = bufferedItemBridge2.timers;
      BufferedItemBridge bufferedItemBridge3 = bufferedItemBridge2;
      int num = timers;
      bufferedItemBridge3.timers = timers + 1;
      this.__\u003C\u003EtimerAccept = num;
      this.speed = 40f;
      this.bufferCapacity = 50;
      this.hasPower = false;
      this.hasItems = true;
      this.canOverdrive = true;
    }

    [HideFromJava]
    static BufferedItemBridge() => ExtendingItemBridge.__\u003Cclinit\u003E();

    [Modifiers]
    public int timerAccept
    {
      [HideFromJava] get => this.__\u003C\u003EtimerAccept;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EtimerAccept = value;
    }

    public class BufferedItemBridgeBuild : ExtendingItemBridge.ExtendingItemBridgeBuild
    {
      internal ItemBuffer buffer;
      [Modifiers]
      internal BufferedItemBridge this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 164, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BufferedItemBridgeBuild(BufferedItemBridge _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((ExtendingItemBridge) _param1);
        BufferedItemBridge.BufferedItemBridgeBuild bufferedItemBridgeBuild = this;
        this.buffer = new ItemBuffer(this.this\u00240.bufferCapacity);
      }

      [LineNumberTable(new byte[] {159, 169, 123, 182, 127, 0, 127, 14, 124, 104, 141, 156})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void updateTransport(Building other)
      {
        if (this.buffer.accepts() && this.items.total() > 0)
          this.buffer.accept(this.items.take());
        Item obj = this.buffer.poll(this.this\u00240.speed / this.timeScale);
        if (this.timer(this.this\u00240.__\u003C\u003EtimerAccept, 4f / this.timeScale) && obj != null && other.acceptItem((Building) this, obj))
        {
          this.cycleSpeed = Mathf.lerpDelta(this.cycleSpeed, 4f, 0.05f);
          other.handleItem((Building) this, obj);
          this.buffer.remove();
        }
        else
          this.cycleSpeed = Mathf.lerpDelta(this.cycleSpeed, 0.0f, 0.008f);
      }

      [LineNumberTable(new byte[] {159, 185, 103, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void write(Writes write)
      {
        base.write(write);
        this.buffer.write(write);
      }

      [LineNumberTable(new byte[] {159, 130, 99, 104, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num = (int) (sbyte) revision;
        base.read(read, (byte) num);
        this.buffer.read(read);
      }

      [HideFromJava]
      static BufferedItemBridgeBuild() => ExtendingItemBridge.ExtendingItemBridgeBuild.__\u003Cclinit\u003E();
    }
  }
}
