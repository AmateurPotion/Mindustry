// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.Bloom
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.gl;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  public class Bloom : Object
  {
    public static bool useAlphaChannelAsMask;
    public int blurPasses;
    private Shader thresholdShader;
    private Shader bloomShader;
    private Shader blurShader;
    private FrameBuffer buffer;
    private FrameBuffer pingPong1;
    private FrameBuffer pingPong2;
    private float bloomIntensity;
    private float originalIntensity;
    private float threshold;
    private bool blending;
    private bool capturing;
    private float r;
    private float g;
    private float b;
    private float a;

    [LineNumberTable(new byte[] {159, 176, 107, 113, 145, 124, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resume()
    {
      this.bloomShader.bind();
      this.bloomShader.setUniformi("u_texture0", 0);
      this.bloomShader.setUniformi("u_texture1", 1);
      this.setSize(this.pingPong1.getWidth(), this.pingPong1.getHeight());
      this.setThreshold(this.threshold);
      this.setBloomIntesity(this.bloomIntensity);
      this.setOriginalIntesity(this.originalIntensity);
    }

    [LineNumberTable(new byte[] {160, 118, 107, 107, 139, 107, 107, 188, 2, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      try
      {
        this.buffer.dispose();
        this.pingPong1.dispose();
        this.pingPong2.dispose();
        this.blurShader.dispose();
        this.bloomShader.dispose();
        this.thresholdShader.dispose();
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
    }

    [LineNumberTable(new byte[] {159, 130, 98, 232, 38, 231, 70, 238, 85, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bloom(bool useBlending)
    {
      int num = useBlending ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Bloom bloom = this;
      this.blurPasses = 1;
      this.blending = false;
      this.capturing = false;
      this.init(Core.graphics.getWidth() / 4, Core.graphics.getHeight() / 4, false, num != 0);
    }

    [LineNumberTable(new byte[] {16, 159, 2, 99, 109, 109, 127, 0, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int width, int height)
    {
      if ((this.pingPong1.getWidth() != width || this.pingPong1.getHeight() != height ? 1 : 0) == 0)
        return;
      this.pingPong1.resize(width, height);
      this.pingPong2.resize(width, height);
      this.buffer.resize(Core.graphics.getWidth(), Core.graphics.getHeight());
      this.setSize(width, height);
    }

    [LineNumberTable(new byte[] {66, 104, 103, 107, 125, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void capture()
    {
      if (this.capturing)
        return;
      this.capturing = true;
      this.buffer.begin();
      Gl.clearColor(this.r, this.g, this.b, this.a);
      Gl.clear(16640);
    }

    [LineNumberTable(new byte[] {92, 104, 103, 171, 106, 106, 134, 134, 104, 106, 175, 118, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render()
    {
      if (this.capturing)
      {
        this.capturing = false;
        this.buffer.end();
      }
      Gl.disable(3042);
      Gl.disable(2929);
      Gl.depthMask(false);
      this.gaussianBlur();
      if (this.blending)
      {
        Gl.enable(3042);
        Gl.blendFunc(770, 771);
      }
      this.pingPong1.getTexture().bind(1);
      this.buffer.blit(this.bloomShader);
    }

    [LineNumberTable(new byte[] {160, 111, 107, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setSize([In] int obj0, [In] int obj1)
    {
      this.blurShader.bind();
      this.blurShader.setUniformf("size", (float) obj0, (float) obj1);
    }

    [LineNumberTable(new byte[] {160, 105, 104, 107, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setThreshold(float threshold)
    {
      this.threshold = threshold;
      this.thresholdShader.bind();
      this.thresholdShader.setUniformf(nameof (threshold), threshold, 1f / (1f - threshold));
    }

    [LineNumberTable(new byte[] {160, 81, 104, 107, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBloomIntesity(float intensity)
    {
      this.bloomIntensity = intensity;
      this.bloomShader.bind();
      this.bloomShader.setUniformf("BloomIntensity", intensity);
    }

    [LineNumberTable(new byte[] {160, 94, 104, 107, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOriginalIntesity(float intensity)
    {
      this.originalIntensity = intensity;
      this.bloomShader.bind();
      this.bloomShader.setUniformf("OriginalIntensity", intensity);
    }

    [LineNumberTable(new byte[] {159, 123, 101, 103, 144, 127, 2, 111, 143, 144, 159, 11, 103, 151, 191, 11, 159, 11, 104, 107, 107, 139, 107, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void init([In] int obj0, [In] int obj1, [In] bool obj2, [In] bool obj3)
    {
      int num1 = obj3 ? 1 : 0;
      int num2 = obj2 ? 1 : 0;
      this.blending = num1 != 0;
      Pixmap.Format format = num1 == 0 ? Pixmap.Format.__\u003C\u003Ergb888 : Pixmap.Format.__\u003C\u003Ergba8888;
      this.buffer = new FrameBuffer(format, Core.graphics.getWidth(), Core.graphics.getHeight(), num2 != 0);
      this.pingPong1 = new FrameBuffer(format, obj0, obj1, false);
      this.pingPong2 = new FrameBuffer(format, obj0, obj1, false);
      string str = num1 == 0 ? "" : "alpha_";
      this.bloomShader = Bloom.createShader("screenspace", new StringBuilder().append(str).append("bloom").toString());
      this.thresholdShader = !Bloom.useAlphaChannelAsMask ? Bloom.createShader("screenspace", new StringBuilder().append(str).append("threshold").toString()) : Bloom.createShader("screenspace", "maskedthreshold");
      this.blurShader = Bloom.createShader("blurspace", new StringBuilder().append(str).append("gaussian").toString());
      this.setSize(obj0, obj1);
      this.setBloomIntesity(2.5f);
      this.setOriginalIntesity(1f);
      this.setThreshold(0.5f);
      this.bloomShader.bind();
      this.bloomShader.setUniformi("u_texture0", 0);
      this.bloomShader.setUniformi("u_texture1", 1);
    }

    [LineNumberTable(245)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Shader createShader([In] string obj0, [In] string obj1)
    {
      Shader.__\u003Cclinit\u003E();
      return new Shader(Core.files.@internal(new StringBuilder().append("bloomshaders/").append(obj0).append(".vert").toString()), Core.files.@internal(new StringBuilder().append("bloomshaders/").append(obj1).append(".frag").toString()));
    }

    [LineNumberTable(new byte[] {115, 107, 113, 139, 174, 107, 107, 122, 113, 171, 107, 107, 122, 113, 235, 50, 233, 80})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void gaussianBlur()
    {
      this.pingPong1.begin();
      this.buffer.blit(this.thresholdShader);
      this.pingPong1.end();
      for (int index = 0; index < this.blurPasses; ++index)
      {
        this.pingPong2.begin();
        this.blurShader.bind();
        this.blurShader.setUniformf("dir", 1f, 0.0f);
        this.pingPong1.blit(this.blurShader);
        this.pingPong2.end();
        this.pingPong1.begin();
        this.blurShader.bind();
        this.blurShader.setUniformf("dir", 0.0f, 1f);
        this.pingPong2.blit(this.blurShader);
        this.pingPong1.end();
      }
    }

    [LineNumberTable(new byte[] {159, 187, 232, 42, 231, 70, 238, 81, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bloom()
    {
      Bloom bloom = this;
      this.blurPasses = 1;
      this.blending = false;
      this.capturing = false;
      this.init(Core.graphics.getWidth() / 4, Core.graphics.getHeight() / 4, false, false);
    }

    [LineNumberTable(new byte[] {159, 127, 101, 232, 26, 231, 70, 238, 97, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bloom(int width, int height, bool hasDepth, bool useBlending)
    {
      int num1 = hasDepth ? 1 : 0;
      int num2 = useBlending ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      Bloom bloom = this;
      this.blurPasses = 1;
      this.blending = false;
      this.capturing = false;
      this.init(width, height, num1 != 0, num2 != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setClearColor(float r, float g, float b, float a)
    {
      this.r = r;
      this.g = g;
      this.b = b;
      this.a = a;
    }

    [LineNumberTable(new byte[] {76, 104, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void capturePause()
    {
      if (!this.capturing)
        return;
      this.capturing = false;
      this.buffer.end();
    }

    [LineNumberTable(new byte[] {84, 104, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void captureContinue()
    {
      if (this.capturing)
        return;
      this.capturing = true;
      this.buffer.begin();
    }
  }
}
