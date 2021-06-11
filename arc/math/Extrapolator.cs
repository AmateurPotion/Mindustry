// Decompiled with JetBrains decompiler
// Type: arc.math.Extrapolator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.math
{
  public class Extrapolator : Object
  {
    private float[] snapPos;
    private float[] snapVel;
    private float[] aimPos;
    private float[] lastPacketPos;
    private float[] tmpArr;
    private float[] tmpArr2;
    private double snapTime;
    private double aimTime;
    private double lastPacketTime;
    private double latency;
    private double updateTime;
    private int size;

    [LineNumberTable(new byte[] {160, 110, 103, 40, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float[] clear([In] float[] obj0)
    {
      for (int index = 0; index < obj0.Length; ++index)
        obj0[index] = 0.0f;
      return obj0;
    }

    [LineNumberTable(new byte[] {159, 178, 108, 162, 109, 105, 111, 113, 108, 105, 107, 55, 230, 74, 127, 0, 144, 119, 107, 63, 0, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addSample(double packetTime, double curTime, float[] pos, float[] vel)
    {
      if (!this.estimates(packetTime, curTime))
        return false;
      this.copyArray(this.lastPacketPos, pos);
      this.lastPacketTime = packetTime;
      this.readPosition(curTime, this.snapPos);
      this.aimTime = curTime + this.updateTime;
      double num1 = this.aimTime - packetTime;
      this.snapTime = curTime;
      for (int index = 0; index < this.size; ++index)
        this.aimPos[index] = pos[index] + vel[index] * (float) num1;
      if (Math.abs(this.aimTime - this.snapTime) < 0.0001)
      {
        this.copyArray(this.snapVel, vel);
      }
      else
      {
        double num2 = 1.0 / (this.aimTime - this.snapTime);
        for (int index = 0; index < this.size; ++index)
          this.snapVel[index] = (this.aimPos[index] - this.snapPos[index]) * (float) num2;
      }
      return true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool estimates([In] double obj0, [In] double obj1)
    {
      if (obj0 <= this.lastPacketTime)
        return false;
      double num1 = obj1 - obj0;
      if (num1 < 0.0)
        num1 = 0.0;
      this.latency = num1 <= this.latency ? (this.latency * 7.0 + num1) * 0.125 : (this.latency + num1) * 0.5;
      double num2 = obj0 - this.lastPacketTime;
      this.updateTime = num2 <= this.updateTime ? (this.updateTime * 7.0 + num2) * 0.125 : (this.updateTime + num2) * 0.5;
      return true;
    }

    [LineNumberTable(new byte[] {160, 117, 105, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void copyArray([In] float[] obj0, [In] float[] obj1)
    {
      int index = 0;
      for (int length = obj1.Length; index < length; ++index)
        obj0[index] = obj1[index];
    }

    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool readPosition(double forTime, float[] outPos) => this.readPosition(forTime, outPos, (float[]) null);

    [LineNumberTable(new byte[] {160, 123, 105, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void checkArraySizeOne()
    {
      if (this.size != 1)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException("This function should be called only when size = 1!");
      }
    }

    [LineNumberTable(new byte[] {159, 164, 103, 123, 115, 107, 53, 166, 98, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addSample(double packetTime, double curTime, float[] pos)
    {
      float[] tmpArr2 = this.tmpArr2;
      if (Math.abs(packetTime - this.lastPacketTime) > 0.0001)
      {
        double num = 1.0 / (packetTime - this.lastPacketTime);
        for (int index = 0; index < this.size; ++index)
          tmpArr2[index] = (pos[index] - this.lastPacketPos[index]) * (float) num;
      }
      else
        this.clear(tmpArr2);
      return this.addSample(packetTime, curTime, pos, tmpArr2);
    }

    [LineNumberTable(new byte[] {44, 105, 109, 105, 109, 109, 109, 113, 142, 107, 63, 6, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset(double packetTime, double curTime, float[] pos, float[] vel)
    {
      this.lastPacketTime = packetTime;
      this.copyArray(this.lastPacketPos, pos);
      this.snapTime = curTime;
      this.copyArray(this.snapPos, pos);
      this.updateTime = curTime - packetTime;
      this.latency = this.updateTime;
      this.aimTime = curTime + this.updateTime;
      this.copyArray(this.snapVel, vel);
      for (int index = 0; index < this.size; ++index)
        this.aimPos[index] = this.snapPos[index] + this.snapVel[index] * (float) this.updateTime;
    }

    [LineNumberTable(new byte[] {71, 134, 105, 106, 105, 106, 109, 109, 113, 107, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset(double packetTime, double curTime, float pos, float vel)
    {
      this.checkArraySizeOne();
      this.lastPacketTime = packetTime;
      this.lastPacketPos[0] = pos;
      this.snapTime = curTime;
      this.snapPos[0] = pos;
      this.updateTime = curTime - packetTime;
      this.latency = this.updateTime;
      this.aimTime = curTime + this.updateTime;
      this.snapVel[0] = vel;
      this.aimPos[0] = this.snapPos[0] + this.snapVel[0] * (float) this.updateTime;
    }

    [LineNumberTable(new byte[] {89, 162, 106, 104, 194, 112, 101, 99, 194, 107, 99, 171, 255, 5, 59, 230, 72, 102, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool readPosition(double forTime, float[] outPos, float[] outVel)
    {
      int num1 = 1;
      if (forTime < this.snapTime)
      {
        forTime = this.snapTime;
        num1 = 0;
      }
      double num2 = this.aimTime + this.updateTime;
      if (forTime > num2)
      {
        forTime = num2;
        num1 = 0;
      }
      for (int index = 0; index < this.size; ++index)
      {
        if (outVel != null)
          outVel[index] = this.snapVel[index];
        outPos[index] = this.snapPos[index] + this.snapVel[index] * (float) (forTime - this.snapTime);
      }
      if (num1 == 0 && outVel != null)
        this.clear(outVel);
      return num1 != 0;
    }

    [LineNumberTable(new byte[] {159, 151, 104, 103, 108, 108, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Extrapolator(int size)
    {
      Extrapolator extrapolator = this;
      this.size = size;
      this.snapPos = new float[size];
      this.snapVel = new float[size];
      this.aimPos = new float[size];
      this.lastPacketPos = new float[size];
      this.tmpArr = new float[size];
      this.tmpArr2 = new float[size];
    }

    [LineNumberTable(new byte[] {22, 134, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addSample(double packetTime, double curTime, float pos)
    {
      this.checkArraySizeOne();
      this.tmpArr[0] = pos;
      return this.addSample(packetTime, curTime, this.tmpArr);
    }

    [LineNumberTable(new byte[] {32, 134, 106, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addSample(double packetTime, double curTime, float pos, float vel)
    {
      this.checkArraySizeOne();
      this.tmpArr[0] = pos;
      this.tmpArr2[0] = vel;
      return this.addSample(packetTime, curTime, this.tmpArr, this.tmpArr2);
    }

    [LineNumberTable(new byte[] {40, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset(double packetTime, double curTime, float[] pos) => this.reset(packetTime, curTime, pos, this.clear(this.tmpArr));

    [LineNumberTable(new byte[] {62, 134, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset(double packetTime, double curTime, float pos)
    {
      this.checkArraySizeOne();
      this.reset(packetTime, curTime, pos, 0.0f);
    }

    [LineNumberTable(new byte[] {124, 134, 112, 169})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float readPosition(double forTime)
    {
      this.checkArraySizeOne();
      return this.readPosition(forTime, this.tmpArr) ? this.tmpArr[0] : 0.0f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double estimateLatency() => this.latency;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double estimateUpdateTime() => this.updateTime;
  }
}
