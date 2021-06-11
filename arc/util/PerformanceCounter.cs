// Decompiled with JetBrains decompiler
// Type: arc.util.PerformanceCounter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class PerformanceCounter : Object
  {
    private const float nano2seconds = 1E-09f;
    internal FloatCounter __\u003C\u003Etime;
    internal FloatCounter __\u003C\u003Eload;
    internal string __\u003C\u003Ename;
    public float current;
    public bool valid;
    private long startTime;
    private long lastTick;

    [LineNumberTable(new byte[] {159, 176, 232, 54, 139, 103, 104, 232, 71, 103, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PerformanceCounter(string name, int windowSize)
    {
      PerformanceCounter performanceCounter = this;
      this.current = 0.0f;
      this.valid = false;
      this.startTime = 0L;
      this.lastTick = 0L;
      this.__\u003C\u003Ename = name;
      this.__\u003C\u003Etime = new FloatCounter(windowSize);
      this.__\u003C\u003Eload = new FloatCounter(1);
    }

    [LineNumberTable(new byte[] {5, 104, 112, 161, 152, 123, 159, 21, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tick(float delta)
    {
      if (!this.valid)
      {
        Log.err("[PerformanceCounter] Invalid data, check if you called PerformanceCounter#stop()");
      }
      else
      {
        this.__\u003C\u003Etime.put(this.current / 1E-09f);
        float num = (double) delta != 0.0 ? this.current / delta : 0.0f;
        this.__\u003C\u003Eload.put((double) delta <= 1.0 ? delta * num + (1f - delta) * this.__\u003C\u003Eload.latest : num);
        this.current = 0.0f;
        this.valid = false;
      }
    }

    [LineNumberTable(new byte[] {57, 119, 119, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual StringBuilder toString(StringBuilder sb)
    {
      sb.append(this.__\u003C\u003Ename).append(":\n  time: ");
      this.commas(sb, ByteCodeHelper.f2i(this.__\u003C\u003Etime.value));
      sb.append("\n  load: ").append(ByteCodeHelper.f2i(this.__\u003C\u003Eload.value * 100f)).append('%');
      return sb;
    }

    [LineNumberTable(new byte[] {64, 102, 98, 100, 110, 104, 102, 118, 137, 98, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void commas([In] StringBuilder obj0, [In] int obj1)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      int num1 = 0;
      while (obj1 > 0)
      {
        int num2 = obj1;
        int num3 = 10;
        int num4 = num3 != -1 ? num2 % num3 : 0;
        stringBuilder1.append(num4);
        obj1 /= 10;
        ++num1;
        int num5 = num1;
        int num6 = 3;
        if ((num6 != -1 ? num5 % num6 : 0) == 0 && obj1 > 0)
          stringBuilder1.append(',');
      }
      StringBuilder stringBuilder2 = obj0;
      object obj = (object) stringBuilder1.reverse();
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      stringBuilder2.append(charSequence2);
    }

    [LineNumberTable(new byte[] {159, 173, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PerformanceCounter(string name)
      : this(name, 5)
    {
    }

    [LineNumberTable(new byte[] {159, 187, 102, 127, 1, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tick()
    {
      long num = Time.nanos();
      if (this.lastTick > 0L)
        this.tick((float) (num - this.lastTick) * 1E-09f);
      this.lastTick = num;
    }

    [LineNumberTable(new byte[] {21, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void start()
    {
      this.startTime = Time.nanos();
      this.valid = false;
    }

    [LineNumberTable(new byte[] {30, 106, 127, 3, 104, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop()
    {
      if (this.startTime <= 0L)
        return;
      this.current += (float) (Time.nanos() - this.startTime) * 1E-09f;
      this.startTime = 0L;
      this.valid = true;
    }

    [LineNumberTable(new byte[] {39, 107, 107, 104, 104, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.__\u003C\u003Etime.reset();
      this.__\u003C\u003Eload.reset();
      this.startTime = 0L;
      this.lastTick = 0L;
      this.current = 0.0f;
      this.valid = false;
    }

    [LineNumberTable(new byte[] {50, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.toString(new StringBuilder()).toString();

    [Modifiers]
    public FloatCounter time
    {
      [HideFromJava] get => this.__\u003C\u003Etime;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etime = value;
    }

    [Modifiers]
    public FloatCounter load
    {
      [HideFromJava] get => this.__\u003C\u003Eload;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eload = value;
    }

    [Modifiers]
    public string name
    {
      [HideFromJava] get => this.__\u003C\u003Ename;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ename = value;
    }
  }
}
