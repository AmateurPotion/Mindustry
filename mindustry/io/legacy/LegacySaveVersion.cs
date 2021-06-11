// Decompiled with JetBrains decompiler
// Type: mindustry.io.legacy.LegacySaveVersion
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.io.legacy
{
  public abstract class LegacySaveVersion : SaveVersion
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [LineNumberTable(new byte[] {16, 136, 114, 104, 123, 136, 108, 140, 127, 5, 127, 5, 127, 5, 191, 5, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024readMap\u00240([In] Tile obj0, [In] DataInput obj1, [In] DataInput obj2)
    {
      int num1 = (int) (sbyte) obj2.readByte();
      obj0.build.health = (float) obj1.readUnsignedShort();
      int num2 = (int) (sbyte) obj1.readByte();
      int id = Pack.leftByte((byte) num2) != (byte) 8 ? (int) (sbyte) Pack.leftByte((byte) num2) : (int) (sbyte) obj1.readByte();
      int num3 = (int) (sbyte) Pack.rightByte((byte) num2);
      obj0.setTeam(Team.get(id));
      obj0.build.rotation = num3;
      if (obj0.build.items != null)
        obj0.build.items.read(Reads.get(obj1), true);
      if (obj0.build.power != null)
        obj0.build.power.read(Reads.get(obj1), true);
      if (obj0.build.liquids != null)
        obj0.build.liquids.read(Reads.get(obj1), true);
      if (obj0.build.cons != null)
        obj0.build.cons.read(Reads.get(obj1), true);
      obj0.build.read(Reads.get(obj2), (byte) num1);
    }

    [LineNumberTable(new byte[] {159, 159, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LegacySaveVersion(int version)
      : base(version)
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 164, 103, 135, 135, 137, 168, 107, 123, 104, 104, 104, 159, 5, 144, 111, 125, 16, 232, 69, 229, 50, 233, 82, 239, 118, 236, 11, 114, 105, 171, 191, 28, 100, 169, 137, 255, 7, 85, 241, 82, 242, 44, 98, 255, 18, 83, 225, 48, 243, 80, 230, 50, 168, 110, 111, 47, 232, 69, 242, 69, 227, 10, 241, 118, 38, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void readMap(DataInput stream, WorldContext context)
    {
      int i1_1 = stream.readUnsignedShort();
      int i2_1 = stream.readUnsignedShort();
      int num1 = context.isGenerating() ? 1 : 0;
      if (num1 == 0)
        context.begin();
      int i1;
      // ISSUE: fault handler
      try
      {
        context.resize(i1_1, i2_1);
        for (i1 = 0; i1 < i1_1 * i2_1; ++i1)
        {
          int num2 = i1;
          int num3 = i1_1;
          int i1_2 = num3 != -1 ? num2 % num3 : 0;
          int num4 = i1;
          int num5 = i1_1;
          int i2_2 = num5 != -1 ? num4 / num5 : -num4;
          int num6 = (int) stream.readShort();
          int i4 = (int) stream.readShort();
          int num7 = stream.readUnsignedByte();
          if (object.ReferenceEquals((object) Vars.content.block(num6), (object) Blocks.air))
            num6 = (int) Blocks.stone.__\u003C\u003Eid;
          context.create(i1_2, i2_2, num6, i4, 0);
          for (int index = i1 + 1; index < i1 + 1 + num7; ++index)
          {
            int num8 = index;
            int num9 = i1_1;
            int i1_3 = num9 != -1 ? num8 % num9 : 0;
            int num10 = index;
            int num11 = i1_1;
            int i2_3 = num11 != -1 ? num10 / num11 : -num10;
            context.create(i1_3, i2_3, num6, i4, 0);
          }
          i1 += num7;
        }
        i1 = 0;
      }
      __fault
      {
        if (num1 == 0)
          context.end();
      }
      Block type;
      Exception exception1;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (i1 < i1_1 * i2_1)
          {
            type = Vars.content.block((int) stream.readShort());
            Tile tile = context.tile(i1);
            if (type == null)
              type = Blocks.air;
            if ((tile.build == null || tile.isCenter() || !object.ReferenceEquals((object) tile.build.block, (object) type) && !object.ReferenceEquals((object) type, (object) Blocks.air) ? 0 : 1) == 0)
              tile.setBlock(type);
            if (type.hasBuilding())
            {
              try
              {
                this.readChunk(stream, true, (SaveFileReader.IORunner) new LegacySaveVersion.__\u003C\u003EAnon0(tile, stream));
              }
              catch (Exception ex)
              {
                exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                break;
              }
            }
            else
              goto label_34;
          }
          else
            goto label_47;
        }
        __fault
        {
          if (num1 == 0)
            context.end();
        }
        // ISSUE: fault handler
        try
        {
          context.onReadBuilding();
          goto label_42;
        }
        __fault
        {
          if (num1 == 0)
            context.end();
        }
label_34:
        // ISSUE: fault handler
        try
        {
          int num2 = stream.readUnsignedByte();
          if (!object.ReferenceEquals((object) type, (object) Blocks.air))
          {
            for (int i2 = i1 + 1; i2 < i1 + 1 + num2; ++i2)
              context.tile(i2).setBlock(type);
          }
          i1 += num2;
        }
        __fault
        {
          if (num1 == 0)
            context.end();
        }
label_42:
        // ISSUE: fault handler
        try
        {
          ++i1;
        }
        __fault
        {
          if (num1 == 0)
            context.end();
        }
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string str = new StringBuilder().append("Failed to read tile entity of block: ").append((object) type).toString();
        Exception exception4 = exception3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str, exception4);
      }
      __fault
      {
        if (num1 == 0)
          context.end();
      }
label_47:
      if (num1 != 0)
        return;
      context.end();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {58, 136, 102, 103, 134, 8, 6, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readLegacyEntities(DataInput stream)
    {
      int num1 = (int) (sbyte) stream.readByte();
      for (int index1 = 0; index1 < num1; ++index1)
      {
        int num2 = stream.readInt();
        for (int index2 = 0; index2 < num2; ++index2)
          this.skipChunk(stream, true);
      }
    }

    [HideFromJava]
    static LegacySaveVersion() => SaveVersion.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : SaveFileReader.IORunner
    {
      private readonly Tile arg\u00241;
      private readonly DataInput arg\u00242;

      internal __\u003C\u003EAnon0([In] Tile obj0, [In] DataInput obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void accept([In] object obj0) => LegacySaveVersion.lambda\u0024readMap\u00240(this.arg\u00241, this.arg\u00242, (DataInput) obj0);
    }
  }
}
