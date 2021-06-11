// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.FadeInFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics.g2d;
using arc.math;
using arc.scene;
using arc.scene.@event;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class FadeInFragment : Fragment
  {
    private const float duration = 40f;
    internal float time;

    [LineNumberTable(new byte[] {159, 152, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FadeInFragment()
    {
      FadeInFragment fadeInFragment = this;
      this.time = 0.0f;
    }

    [LineNumberTable(new byte[] {159, 158, 236, 86})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent) => parent.addChild((Element) new FadeInFragment.\u0031(this));

    [EnclosingMethod(null, "build", "(Larc.scene.Group;)V")]
    [SpecialName]
    internal class \u0031 : Element
    {
      [Modifiers]
      internal FadeInFragment this\u00240;

      [LineNumberTable(new byte[] {159, 158, 143, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] FadeInFragment obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        FadeInFragment.\u0031 obj = this;
        this.setFillParent(true);
        this.touchable = Touchable.__\u003C\u003Edisabled;
      }

      [LineNumberTable(new byte[] {159, 166, 127, 13, 127, 6, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.color(0.0f, 0.0f, 0.0f, Mathf.clamp(1f - this.this\u00240.time));
        Fill.crect(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
        Draw.color();
      }

      [LineNumberTable(new byte[] {159, 173, 104, 120, 114, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void act([In] float obj0)
      {
        base.act(obj0);
        this.this\u00240.time += 0.025f;
        if ((double) this.this\u00240.time <= 1.0)
          return;
        this.remove();
      }
    }
  }
}
