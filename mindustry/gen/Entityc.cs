// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Entityc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.util.io;
using IKVM.Attributes;

namespace mindustry.gen
{
  public interface Entityc
  {
    bool isLocal();

    void add();

    bool isAdded();

    void remove();

    void id(int i);

    int id();

    int classId();

    void update();

    bool isRemote();

    bool isNull();

    [Signature("<T::Lmindustry/gen/Entityc;>()TT;")]
    Entityc self();

    [Signature("<T:Ljava/lang/Object;>()TT;")]
    object @as();

    [Signature("<T:Ljava/lang/Object;>(Larc/func/Cons<TT;>;)TT;")]
    object with(Cons c);

    bool serialize();

    void read(Reads r);

    void write(Writes w);

    void afterRead();
  }
}
