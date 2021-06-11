// Decompiled with JetBrains decompiler
// Type: mindustry.ui.ReqImage
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using arc.scene;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class ReqImage : Stack
  {
    [Modifiers]
    private Boolp valid;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool valid() => this.valid.get();

    [LineNumberTable(new byte[] {159, 155, 104, 103, 103, 237, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReqImage(Element image, Boolp valid)
    {
      ReqImage reqImage = this;
      this.valid = valid;
      this.add(image);
      this.add((Element) new ReqImage.\u0031(this, valid));
    }

    [LineNumberTable(new byte[] {159, 175, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ReqImage(TextureRegion region, Boolp valid)
      : this((Element) new Image(region), valid)
    {
    }

    [HideFromJava]
    static ReqImage() => Stack.__\u003Cclinit\u003E();

    [EnclosingMethod(null, "<init>", "(Larc.scene.Element;Larc.func.Boolp;)V")]
    [SpecialName]
    internal new class \u0031 : Element
    {
      [Modifiers]
      internal Boolp val\u0024valid;
      [Modifiers]
      internal ReqImage this\u00240;

      [Modifiers]
      [LineNumberTable(18)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00240([In] Boolp obj0) => !obj0.get();

      [LineNumberTable(new byte[] {159, 158, 150, 119})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ReqImage obj0, [In] Boolp obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024valid = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ReqImage.\u0031 obj = this;
        this.visible((Boolp) new ReqImage.\u0031.__\u003C\u003EAnon0(this.val\u0024valid));
      }

      [LineNumberTable(new byte[] {159, 165, 117, 127, 28, 106, 127, 14, 101})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Lines.stroke(Scl.scl(2f), Pal.removeBack);
        Lines.line(this.x, this.y - 2f + this.height, this.x + this.width, this.y - 2f);
        Draw.color(Pal.remove);
        Lines.line(this.x, this.y + this.height, this.x + this.width, this.y);
        Draw.reset();
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolp
      {
        private readonly Boolp arg\u00241;

        internal __\u003C\u003EAnon0([In] Boolp obj0) => this.arg\u00241 = obj0;

        public bool get() => (ReqImage.\u0031.lambda\u0024new\u00240(this.arg\u00241) ? 1 : 0) != 0;
      }
    }
  }
}
