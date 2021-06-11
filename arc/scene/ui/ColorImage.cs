// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.ColorImage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.ui
{
  public class ColorImage : Image
  {
    private Color set;

    [LineNumberTable(new byte[] {159, 150, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ColorImage(Color set)
    {
      ColorImage colorImage = this;
      this.set = new Color(set);
    }

    [LineNumberTable(new byte[] {159, 156, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      this.setColor(this.set);
      base.draw();
    }
  }
}
