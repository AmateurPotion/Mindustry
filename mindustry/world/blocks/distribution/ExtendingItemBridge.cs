// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.distribution.ExtendingItemBridge
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using IKVM.Attributes;
using java.lang;
using mindustry.core;
using System.Runtime.CompilerServices;

namespace mindustry.world.blocks.distribution
{
  public class ExtendingItemBridge : ItemBridge
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 157, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ExtendingItemBridge(string name)
      : base(name)
    {
      ExtendingItemBridge extendingItemBridge = this;
      this.hasItems = true;
    }

    [HideFromJava]
    static ExtendingItemBridge() => ItemBridge.__\u003Cclinit\u003E();

    public class ExtendingItemBridgeBuild : ItemBridge.ItemBridgeBuild
    {
      [Modifiers]
      internal ExtendingItemBridge this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(19)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ExtendingItemBridgeBuild(ExtendingItemBridge _param1)
      {
        this.this\u00240 = _param1;
        // ISSUE: explicit constructor call
        base.\u002Ector((ItemBridge) _param1);
      }

      [LineNumberTable(new byte[] {159, 164, 156, 138, 113, 149, 153, 127, 8, 159, 8, 155, 102, 134, 109, 138, 106, 114, 125, 31, 10, 229, 70, 127, 5, 117, 127, 1, 31, 2, 197, 159, 22, 138, 133, 108, 127, 24, 114, 127, 19, 31, 21, 5, 235, 71, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.rect(this.this\u00240.region, this.x, this.y);
        Draw.z(70f);
        Tile other = Vars.world.tile(this.link);
        if (!this.this\u00240.linkValid(this.tile, other))
          return;
        int i = (int) (sbyte) this.tile.absoluteRelativeTo((int) other.x, (int) other.y);
        float num1 = other.worldx() - this.x - (float) (Geometry.d4(i).x * 8) / 2f;
        float num2 = other.worldy() - this.y - (float) (Geometry.d4(i).y * 8) / 2f;
        float num3 = !Vars.state.isEditor() ? this.uptime : 1f;
        float num4 = num1 * num3;
        float num5 = num2 * num3;
        if (Mathf.zero(Renderer.bridgeOpacity))
          return;
        Draw.alpha(Renderer.bridgeOpacity);
        Lines.stroke(8f);
        Lines.line(this.this\u00240.bridgeRegion, this.x + (float) (Geometry.d4(i).x * 8) / 2f, this.y + (float) (Geometry.d4(i).y * 8) / 2f, this.x + num4, this.y + num5, false);
        Draw.rect(this.this\u00240.endRegion, this.x, this.y, (float) (i * 90 + 90));
        Draw.rect(this.this\u00240.endRegion, this.x + num4 + (float) (Geometry.d4(i).x * 8) / 2f, this.y + num5 + (float) (Geometry.d4(i).y * 8) / 2f, (float) (i * 90 + 270));
        int num6 = Math.max(Math.abs((int) other.x - (int) this.tile.x), Math.abs((int) other.y - (int) this.tile.y)) * 8 / 6 - 1;
        Draw.color();
        for (int index = 0; index < num6; ++index)
        {
          Draw.alpha(Mathf.absin((float) index / (float) num6 - this.time / 100f, 0.1f, 1f) * num3 * Renderer.bridgeOpacity);
          Draw.rect(this.this\u00240.arrowRegion, this.x + (float) Geometry.d4(i).x * (4f + (float) index * 6f + 2f) * num3, this.y + (float) Geometry.d4(i).y * (4f + (float) index * 6f + 2f) * num3, (float) i * 90f);
        }
        Draw.reset();
      }

      [HideFromJava]
      static ExtendingItemBridgeBuild() => ItemBridge.ItemBridgeBuild.__\u003Cclinit\u003E();
    }
  }
}
