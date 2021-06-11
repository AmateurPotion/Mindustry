// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.Pixelator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class Pixelator : Object, Disposable
  {
    private FrameBuffer buffer;
    private float px;
    private float py;
    private float pre;

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool enabled() => Core.settings.getBool("pixelate");

    [LineNumberTable(new byte[] {159, 155, 104, 203, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pixelator()
    {
      Pixelator pixelator = this;
      this.buffer = new FrameBuffer();
      this.buffer.getTexture().setFilter(Texture.TextureFilter.__\u003C\u003Enearest, Texture.TextureFilter.__\u003C\u003Enearest);
    }

    [LineNumberTable(new byte[] {159, 164, 113, 108, 104, 107, 122, 154, 117, 117, 159, 93, 125, 157, 141, 112, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPixelate()
    {
      this.pre = Vars.renderer.getScale();
      float scl = (float) ByteCodeHelper.f2i(Vars.renderer.getScale());
      Vars.renderer.setScale(scl);
      Core.camera.width = (float) ByteCodeHelper.f2i(Core.camera.width);
      Core.camera.height = (float) ByteCodeHelper.f2i(Core.camera.height);
      this.px = Core.camera.__\u003C\u003Eposition.x;
      this.py = Core.camera.__\u003C\u003Eposition.y;
      Vec2 position = Core.camera.__\u003C\u003Eposition;
      double num1 = (double) ByteCodeHelper.f2i(this.px);
      int num2 = ByteCodeHelper.f2i(Core.camera.width);
      int num3 = 2;
      double num4 = (num3 != -1 ? num2 % num3 : 0) != 0 ? 0.5 : 0.0;
      double num5 = num1 + num4;
      double num6 = (double) ByteCodeHelper.f2i(this.py);
      int num7 = ByteCodeHelper.f2i(Core.camera.height);
      int num8 = 2;
      double num9 = (num8 != -1 ? num7 % num8 : 0) != 0 ? 0.5 : 0.0;
      double num10 = num6 + num9;
      position.set((float) num5, (float) num10);
      this.buffer.resize(ByteCodeHelper.f2i(Core.camera.width * Vars.renderer.landScale()), ByteCodeHelper.f2i(Core.camera.height * Vars.renderer.landScale()));
      this.buffer.begin(Color.__\u003C\u003Eclear);
      Vars.renderer.draw();
    }

    [LineNumberTable(new byte[] {159, 185, 245, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void register() => Draw.draw(200f, (Runnable) new Pixelator.__\u003C\u003EAnon0(this));

    [Modifiers]
    [LineNumberTable(new byte[] {159, 186, 139, 106, 144, 124, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024register\u00240()
    {
      this.buffer.end();
      Blending.__\u003C\u003Edisabled.apply();
      this.buffer.blit(Shaders.screenspace);
      Core.camera.__\u003C\u003Eposition.set(this.px, this.py);
      Vars.renderer.setScale(this.pre);
    }

    [LineNumberTable(new byte[] {10, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => this.buffer.dispose();

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Pixelator arg\u00241;

      internal __\u003C\u003EAnon0([In] Pixelator obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024register\u00240();
    }
  }
}
