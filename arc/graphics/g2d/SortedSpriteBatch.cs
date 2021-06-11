// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.SortedSpriteBatch
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics.gl;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.graphics.g2d
{
  public class SortedSpriteBatch : SpriteBatch
  {
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/DrawRequest;>;")]
    protected internal Seq requestPool;
    [Signature("Larc/struct/Seq<Larc/graphics/g2d/DrawRequest;>;")]
    protected internal Seq requests;
    protected internal bool sort;
    protected internal bool flushing;

    [LineNumberTable(new byte[] {159, 149, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SortedSpriteBatch()
    {
      SortedSpriteBatch sortedSpriteBatch = this;
      this.requestPool = new Seq(10000);
      this.requests = new Seq((Class) ClassLiteral<DrawRequest>.Value);
    }

    [LineNumberTable(new byte[] {47, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void flush()
    {
      this.flushRequests();
      base.flush();
    }

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual DrawRequest obtain() => this.requestPool.size > 0 ? (DrawRequest) this.requestPool.pop() : new DrawRequest();

    [LineNumberTable(new byte[] {52, 123, 103, 102, 110, 135, 115, 148, 109, 141, 141, 105, 113, 105, 159, 0, 255, 31, 51, 233, 81, 103, 103, 114, 114, 135, 114, 140, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void flushRequests()
    {
      if (this.flushing || this.requests.isEmpty())
        return;
      this.flushing = true;
      this.sortRequests();
      float colorPacked = this.colorPacked;
      float mixColorPacked = this.mixColorPacked;
      Blending blending = this.blending;
      for (int index = 0; index < this.requests.size; ++index)
      {
        DrawRequest drawRequest = ((DrawRequest[]) this.requests.items)[index];
        this.colorPacked = drawRequest.color;
        this.mixColorPacked = drawRequest.mixColor;
        base.setBlending(drawRequest.blending);
        if (drawRequest.run != null)
          drawRequest.run.run();
        else if (drawRequest.texture != null)
          base.draw(drawRequest.texture, drawRequest.vertices, 0, drawRequest.vertices.Length);
        else
          base.draw(drawRequest.region, drawRequest.x, drawRequest.y, drawRequest.originX, drawRequest.originY, drawRequest.width, drawRequest.height, drawRequest.rotation);
      }
      this.colorPacked = colorPacked;
      this.mixColorPacked = mixColorPacked;
      this.__\u003C\u003Ecolor.abgr8888(this.colorPacked);
      this.__\u003C\u003EmixColor.abgr8888(this.mixColorPacked);
      this.blending = blending;
      this.requestPool.addAll(this.requests);
      this.requests.size = 0;
      this.flushing = false;
    }

    [LineNumberTable(new byte[] {89, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void sortRequests() => this.requests.sort();

    [LineNumberTable(new byte[] {159, 139, 162, 105, 134, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setSort(bool sort)
    {
      int num = sort ? 1 : 0;
      if ((this.sort ? 1 : 0) != num)
        this.flush();
      this.sort = num != 0;
    }

    [LineNumberTable(new byte[] {159, 137, 162, 112, 144, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setShader(Shader shader, bool apply)
    {
      int num = apply ? 1 : 0;
      if (!this.flushing && this.sort)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Shaders cannot be set while sorting is enabled. Set shaders inside Draw.run(...).");
      }
      base.setShader(shader, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setBlending(Blending blending) => this.blending = blending;

    [LineNumberTable(new byte[] {159, 178, 118, 103, 103, 108, 117, 103, 108, 103, 236, 57, 236, 74, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void draw(
      Texture texture,
      float[] spriteVertices,
      int offset,
      int count)
    {
      if (this.sort && !this.flushing)
      {
        for (int index = offset; index < count; index += 24)
        {
          DrawRequest drawRequest = this.obtain();
          drawRequest.z = this.z;
          ByteCodeHelper.arraycopy_primitive_4((Array) spriteVertices, index, (Array) drawRequest.vertices, 0, drawRequest.vertices.Length);
          drawRequest.texture = texture;
          drawRequest.blending = this.blending;
          drawRequest.run = (Runnable) null;
          this.requests.add((object) drawRequest);
        }
      }
      else
        base.draw(texture, spriteVertices, offset, count);
    }

    [LineNumberTable(new byte[] {3, 118, 103, 104, 104, 108, 105, 105, 105, 105, 108, 105, 108, 108, 108, 103, 103, 108, 98, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void draw(
      TextureRegion region,
      float x,
      float y,
      float originX,
      float originY,
      float width,
      float height,
      float rotation)
    {
      if (this.sort && !this.flushing)
      {
        DrawRequest drawRequest = this.obtain();
        drawRequest.x = x;
        drawRequest.y = y;
        drawRequest.z = this.z;
        drawRequest.originX = originX;
        drawRequest.originY = originY;
        drawRequest.width = width;
        drawRequest.height = height;
        drawRequest.color = this.colorPacked;
        drawRequest.rotation = rotation;
        drawRequest.region.set(region);
        drawRequest.mixColor = this.mixColorPacked;
        drawRequest.blending = this.blending;
        drawRequest.texture = (Texture) null;
        drawRequest.run = (Runnable) null;
        this.requests.add((object) drawRequest);
      }
      else
        base.draw(region, x, y, originX, originY, width, height, rotation);
    }

    [LineNumberTable(new byte[] {27, 112, 103, 103, 108, 108, 108, 108, 103, 108, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void draw(Runnable request)
    {
      if (this.sort && !this.flushing)
      {
        DrawRequest drawRequest = this.obtain();
        drawRequest.run = request;
        drawRequest.blending = this.blending;
        drawRequest.mixColor = this.mixColorPacked;
        drawRequest.color = this.colorPacked;
        drawRequest.z = this.z;
        drawRequest.texture = (Texture) null;
        this.requests.add((object) drawRequest);
      }
      else
        base.draw(request);
    }

    [HideFromJava]
    [NameSig("obtain", "()Larc.graphics.g2d.DrawRequest;")]
    protected internal object obtain() => (object) this.obtain();

    [HideFromJava]
    [NameSig("obtain", "()Larc.graphics.g2d.DrawRequest;")]
    protected internal object \u003Cnonvirtual\u003E0() => (object) this.obtain();
  }
}
