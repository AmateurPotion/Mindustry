// Decompiled with JetBrains decompiler
// Type: arc.net.TcpIdleSender
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.net
{
  public abstract class TcpIdleSender : Object, NetListener
  {
    internal bool started;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void start()
    {
    }

    protected internal abstract object next();

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TcpIdleSender()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 104, 103, 134, 103, 99, 137, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void idle(Connection connection)
    {
      if (!this.started)
      {
        this.started = true;
        this.start();
      }
      object @object = this.next();
      if (@object == null)
        connection.removeListener((NetListener) this);
      else
        connection.sendTCP(@object);
    }

    [HideFromJava]
    public virtual void connected([In] Connection obj0) => NetListener.\u003Cdefault\u003Econnected((NetListener) this, obj0);

    [HideFromJava]
    public virtual void disconnected([In] Connection obj0, [In] DcReason obj1) => NetListener.\u003Cdefault\u003Edisconnected((NetListener) this, obj0, obj1);

    [HideFromJava]
    public virtual void received([In] Connection obj0, [In] object obj1) => NetListener.\u003Cdefault\u003Ereceived((NetListener) this, obj0, obj1);
  }
}
