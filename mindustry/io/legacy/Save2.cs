// Decompiled with JetBrains decompiler
// Type: mindustry.io.legacy.Save2
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using System.Runtime.CompilerServices;

namespace mindustry.io.legacy
{
  public class Save2 : LegacySaveVersion
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 150, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Save2()
      : base(2)
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 155, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void readEntities(DataInput stream) => this.readLegacyEntities(stream);

    [HideFromJava]
    static Save2() => LegacySaveVersion.__\u003Cclinit\u003E();
  }
}
