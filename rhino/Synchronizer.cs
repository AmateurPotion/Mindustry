// Decompiled with JetBrains decompiler
// Type: rhino.Synchronizer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class Synchronizer : Delegator
  {
    private object syncObject;

    [LineNumberTable(new byte[] {159, 173, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Synchronizer(Scriptable obj)
      : base(obj)
    {
    }

    [LineNumberTable(new byte[] {159, 183, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Synchronizer(Scriptable obj, object syncObject)
      : base(obj)
    {
      Synchronizer synchronizer = this;
      this.syncObject = syncObject;
    }

    [LineNumberTable(new byte[] {1, 114, 125, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args)
    {
      object obj1 = this.syncObject == null ? (object) thisObj : this.syncObject;
      object obj2;
      lock (!(obj1 is Wrapper) ? obj1 : ((Wrapper) obj1).unwrap())
        obj2 = ((Function) this.obj).call(cx, scope, thisObj, args);
      return obj2;
    }
  }
}
