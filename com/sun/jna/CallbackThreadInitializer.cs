// Decompiled with JetBrains decompiler
// Type: com.sun.jna.CallbackThreadInitializer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.sun.jna
{
  public class CallbackThreadInitializer : Object
  {
    private bool daemon;
    private bool detach;
    private string name;
    private ThreadGroup group;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ThreadGroup getThreadGroup(Callback cb) => this.group;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName(Callback cb) => this.name;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDaemon(Callback cb) => this.daemon;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool detach(Callback cb) => this.detach;

    [LineNumberTable(new byte[] {159, 127, 66, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CallbackThreadInitializer(bool daemon)
      : this(daemon, false)
    {
    }

    [LineNumberTable(new byte[] {159, 126, 68, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CallbackThreadInitializer(bool daemon, bool detach)
      : this(daemon, detach, (string) null)
    {
    }

    [LineNumberTable(new byte[] {159, 125, 68, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CallbackThreadInitializer(bool daemon, bool detach, string name)
      : this(daemon, detach, name, (ThreadGroup) null)
    {
    }

    [LineNumberTable(new byte[] {159, 125, 164, 104, 103, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CallbackThreadInitializer(bool daemon, bool detach, string name, ThreadGroup group)
    {
      int num1 = daemon ? 1 : 0;
      int num2 = detach ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      CallbackThreadInitializer threadInitializer = this;
      this.daemon = num1 != 0;
      this.detach = num2 != 0;
      this.name = name;
      this.group = group;
    }

    [LineNumberTable(new byte[] {4, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CallbackThreadInitializer()
      : this(true)
    {
    }
  }
}
