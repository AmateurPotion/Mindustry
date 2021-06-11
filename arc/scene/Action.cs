// Decompiled with JetBrains decompiler
// Type: arc.scene.Action
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.pooling;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene
{
  public abstract class Action : Object, Pool.Poolable
  {
    protected internal Element actor;
    protected internal Element target;
    [Signature("Larc/util/pooling/Pool<Larc/scene/Action;>;")]
    private Pool pool;

    public abstract bool act(float f);

    [LineNumberTable(new byte[] {1, 103, 111, 99, 104, 108, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setActor(Element actor)
    {
      this.actor = actor;
      if (this.target == null)
        this.setTarget(actor);
      if (actor != null || this.pool == null)
        return;
      this.pool.free((object) this);
      this.pool = (Pool) null;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTarget(Element target) => this.target = target;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void restart()
    {
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Action()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element getActor() => this.actor;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element getTarget() => this.target;

    [LineNumberTable(new byte[] {34, 103, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.actor = (Element) null;
      this.target = (Element) null;
      this.pool = (Pool) null;
      this.restart();
    }

    [Signature("()Larc/util/pooling/Pool<Larc/scene/Action;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pool getPool() => this.pool;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPool(Pool pool) => this.pool = pool;

    [LineNumberTable(new byte[] {56, 115, 105, 110, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      string str = String.instancehelper_split(base.toString(), "@")[0];
      int num = String.instancehelper_lastIndexOf(str, 46);
      if (num != -1)
        str = String.instancehelper_substring(str, num + 1);
      if (String.instancehelper_endsWith(str, nameof (Action)))
        str = String.instancehelper_substring(str, 0, String.instancehelper_length(str) - 6);
      return str;
    }
  }
}
