// Decompiled with JetBrains decompiler
// Type: arc.util.Eachable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using IKVM.Attributes;

namespace arc.util
{
  [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
  public interface Eachable
  {
    [Signature("(Larc/func/Cons<-TT;>;)V")]
    void each(Cons c);
  }
}
