// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.layout.Scl
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.scene.ui.layout
{
  public class Scl : Object
  {
    private static float scl;
    private static float addition;
    private static float product;
    private const float debugScale = 1f;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 140, 120, 172, 191, 42})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float scl(float amount)
    {
      if ((double) Scl.scl < 0.0)
        Scl.scl = Core.app.isDesktop() || Core.app.isWeb() ? Scl.product : Math.max((float) Math.round((double) (Core.graphics.getDensity() / 1.5f + Scl.addition) / 0.5) * 0.5f, 1f) * Scl.product;
      return amount * Scl.scl * 1f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setProduct(float product)
    {
      Scl.product = product;
      Scl.scl = -1f;
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float scl() => Scl.scl(1f);

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Scl()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setAddition(float addition)
    {
      Scl.addition = addition;
      Scl.scl = -1f;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static Scl()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.scene.ui.layout.Scl"))
        return;
      Scl.scl = -1f;
      Scl.addition = 0.0f;
      Scl.product = 1f;
    }
  }
}
