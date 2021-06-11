// Decompiled with JetBrains decompiler
// Type: mindustry.io.legacy.Save3
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using java.lang;
using mindustry.game;
using System.Runtime.CompilerServices;

namespace mindustry.io.legacy
{
  public class Save3 : LegacySaveVersion
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Save3()
      : base(3)
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 160, 103, 105, 108, 103, 104, 105, 63, 35, 232, 60, 233, 73, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void readEntities(DataInput stream)
    {
      int num1 = stream.readInt();
      for (int index1 = 0; index1 < num1; ++index1)
      {
        Teams.TeamData teamData = Team.get(stream.readInt()).data();
        int num2 = stream.readInt();
        for (int index2 = 0; index2 < num2; ++index2)
          teamData.blocks.addLast((object) new Teams.BlockPlan((int) stream.readShort(), (int) stream.readShort(), stream.readShort(), Vars.content.block((int) stream.readShort()).__\u003C\u003Eid, (object) Integer.valueOf(stream.readInt())));
      }
      this.readLegacyEntities(stream);
    }

    [HideFromJava]
    static Save3() => LegacySaveVersion.__\u003Cclinit\u003E();
  }
}
