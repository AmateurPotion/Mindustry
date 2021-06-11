// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.environment.TreeBlock
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.environment
{
  public class TreeBlock : Block
  {
    public TextureRegion shadow;
    public float shadowOffset;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 233, 61, 203, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TreeBlock(string name)
      : base(name)
    {
      TreeBlock treeBlock = this;
      this.shadowOffset = -4f;
      this.solid = true;
      this.expanded = true;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 178, 121, 127, 58, 31, 13, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024drawBase\u00240([In] float obj0, [In] float obj1, [In] Vec2 obj2) => obj2.add(Mathf.sin(obj2.y * 3f + Time.time, obj0, obj1) + Mathf.sin(obj2.x * 3f - Time.time, 70f, 0.8f), Mathf.cos(obj2.x * 3f + Time.time + 8f, obj0 + 6f, obj1 * 1.1f) + Mathf.sin(obj2.y * 3f - Time.time, 50f, 0.2f));

    [LineNumberTable(new byte[] {159, 166, 112, 127, 69, 127, 10, 142, 109, 106, 191, 11, 106, 255, 0, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void drawBase(Tile tile)
    {
      float x = tile.worldx();
      float y = tile.worldy();
      float rotation = (float) (Mathf.randomSeed((long) tile.pos(), 0, 4) * 90) + Mathf.sin(Time.time + x, 50f, 0.5f) + Mathf.sin(Time.time - y, 65f, 0.9f) + Mathf.sin(Time.time + y - x, 85f, 0.9f);
      float width = (float) this.region.width * Draw.scl;
      float height = (float) this.region.height * Draw.scl;
      float num1 = 30f;
      float num2 = 0.2f;
      if (this.shadow.found())
      {
        Draw.z(69f);
        Draw.rect(this.shadow, tile.worldx() + this.shadowOffset, tile.worldy() + this.shadowOffset, rotation);
      }
      Draw.z(71f);
      Draw.rectv(this.region, x, y, width, height, rotation, (Cons) new TreeBlock.__\u003C\u003EAnon0(num1, num2));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void tweak([In] Vec2 obj0)
    {
    }

    [HideFromJava]
    static TreeBlock() => Block.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly float arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon0([In] float obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => TreeBlock.lambda\u0024drawBase\u00240(this.arg\u00241, this.arg\u00242, (Vec2) obj0);
    }
  }
}
