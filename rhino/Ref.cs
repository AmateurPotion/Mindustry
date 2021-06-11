// Decompiled with JetBrains decompiler
// Type: rhino.Ref
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino
{
  public abstract class Ref : Object
  {
    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Ref()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(Context cx) => true;

    public abstract object get(Context c);

    public abstract object set(Context c, Scriptable s, object obj);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool delete(Context cx) => false;
  }
}
