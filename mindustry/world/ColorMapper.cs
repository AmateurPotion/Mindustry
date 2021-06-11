// Decompiled with JetBrains decompiler
// Type: mindustry.world.ColorMapper
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using System.Runtime.CompilerServices;

namespace mindustry.world
{
  public class ColorMapper : Object
  {
    [Modifiers]
    [Signature("Larc/struct/IntMap<Lmindustry/world/Block;>;")]
    private static IntMap color2block;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 138, 127, 5, 119, 130, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load()
    {
      ColorMapper.color2block.clear();
      Iterator iterator = Vars.content.blocks().iterator();
      while (iterator.hasNext())
      {
        Block block = (Block) iterator.next();
        ColorMapper.color2block.put(block.mapColor.rgba(), (object) block);
      }
      ColorMapper.color2block.put(Color.rgba8888(0.0f, 0.0f, 0.0f, 1f), (object) Blocks.air);
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Block get(int color) => (Block) ColorMapper.color2block.get(color, (object) Blocks.air);

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ColorMapper()
    {
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ColorMapper()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.world.ColorMapper"))
        return;
      ColorMapper.color2block = new IntMap();
    }
  }
}
