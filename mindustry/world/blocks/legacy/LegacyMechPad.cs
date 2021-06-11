// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.legacy.LegacyMechPad
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.io;
using IKVM.Attributes;
using mindustry.gen;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.legacy
{
  public class LegacyMechPad : LegacyBlock
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 105, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LegacyMechPad(string name)
      : base(name)
    {
      LegacyMechPad legacyMechPad = this;
      this.update = true;
      this.hasPower = true;
    }

    [HideFromJava]
    static LegacyMechPad() => LegacyBlock.__\u003Cclinit\u003E();

    public class LegacyMechPadBuild : Building
    {
      [Modifiers]
      internal LegacyMechPad this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LegacyMechPadBuild(LegacyMechPad _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 138, 131, 136, 104, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void read(Reads read, byte revision)
      {
        int num1 = (int) (sbyte) revision;
        base.read(read, (byte) num1);
        double num2 = (double) read.f();
        double num3 = (double) read.f();
        double num4 = (double) read.f();
      }

      [HideFromJava]
      static LegacyMechPadBuild() => Building.__\u003Cclinit\u003E();
    }
  }
}
