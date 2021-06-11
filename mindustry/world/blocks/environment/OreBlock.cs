// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.OreBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using IKVM.Attributes;
using java.lang;
using mindustry.graphics;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.environment
{
  public class OreBlock : OverlayFloor
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 127, 8, 108, 103, 103, 114, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OreBlock(Item ore)
      : base(new StringBuilder().append("ore-").append(ore.__\u003C\u003Ename).toString())
    {
      OreBlock oreBlock = this;
      this.localizedName = ore.localizedName;
      this.itemDrop = ore;
      this.variants = 3;
      this.mapColor.set(ore.color);
      this.useColor = true;
    }

    [LineNumberTable(new byte[] {159, 175, 108, 103, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setup(Item ore)
    {
      this.localizedName = ore.localizedName;
      this.itemDrop = ore;
      this.mapColor.set(ore.color);
    }

    [LineNumberTable(new byte[] {159, 170, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OreBlock(string name)
      : base(name)
    {
      OreBlock oreBlock = this;
      this.variants = 3;
    }

    [LineNumberTable(new byte[] {159, 183, 110, 106, 159, 14, 107, 135, 112, 109, 143, 110, 124, 236, 59, 40, 235, 75, 135, 127, 10, 159, 20, 99, 127, 22, 255, 22, 39, 233, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void createIcons(MultiPacker packer)
    {
      for (int index = 0; index < this.variants; ++index)
      {
        Pixmap pix = new Pixmap(32, 32);
        PixmapRegion pixmap = Core.atlas.getPixmap(new StringBuilder().append(this.itemDrop.__\u003C\u003Ename).append(index + 1).toString());
        int num = pix.getWidth() / 8 - 1;
        Color color = new Color();
        for (int x = 0; x < pix.getWidth(); ++x)
        {
          for (int y = num; y < pix.getHeight(); ++y)
          {
            pixmap.getPixel(x, y - num, color);
            if ((double) color.a > 1.0 / 1000.0)
            {
              color.set(0.0f, 0.0f, 0.0f, 0.3f);
              pix.draw(x, y, color);
            }
          }
        }
        pix.draw(pixmap);
        packer.add(MultiPacker.PageType.__\u003C\u003Eenvironment, new StringBuilder().append(this.__\u003C\u003Ename).append(index + 1).toString(), pix);
        packer.add(MultiPacker.PageType.__\u003C\u003Eeditor, new StringBuilder().append("editor-").append(this.__\u003C\u003Ename).append(index + 1).toString(), pix);
        if (index == 0)
        {
          packer.add(MultiPacker.PageType.__\u003C\u003Eeditor, new StringBuilder().append("editor-block-").append(this.__\u003C\u003Ename).append("-full").toString(), pix);
          packer.add(MultiPacker.PageType.__\u003C\u003Emain, new StringBuilder().append("block-").append(this.__\u003C\u003Ename).append("-full").toString(), pix);
        }
      }
    }

    [LineNumberTable(new byte[] {23, 134, 104, 142, 159, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      base.init();
      if (this.itemDrop != null)
      {
        this.setup(this.itemDrop);
      }
      else
      {
        string str = new StringBuilder().append(this.__\u003C\u003Ename).append(" must have an item drop!").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getDisplayName(Tile tile) => this.itemDrop.localizedName;

    [HideFromJava]
    static OreBlock() => OverlayFloor.__\u003Cclinit\u003E();
  }
}
