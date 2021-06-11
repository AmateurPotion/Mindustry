// Decompiled with JetBrains decompiler
// Type: arc.graphics.Cubemap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.graphics.gl;
using arc.math.geom;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public class Cubemap : GLTexture
  {
    protected internal CubemapData data;

    [LineNumberTable(new byte[] {59, 105, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      if (this.glHandle == 0)
        return;
      this.delete();
    }

    [LineNumberTable(new byte[] {159, 167, 127, 37, 127, 5, 127, 5, 127, 5, 127, 5, 229, 59, 229, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cubemap(string @base)
      : this(Core.files.@internal(new StringBuilder().append(@base).append("right.png").toString()), Core.files.@internal(new StringBuilder().append(@base).append("left.png").toString()), Core.files.@internal(new StringBuilder().append(@base).append("top.png").toString()), Core.files.@internal(new StringBuilder().append(@base).append("bottom.png").toString()), Core.files.@internal(new StringBuilder().append(@base).append("front.png").toString()), Core.files.@internal(new StringBuilder().append(@base).append("back.png").toString()))
    {
    }

    [LineNumberTable(new byte[] {33, 110, 108, 108, 102, 115, 115, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(CubemapData data)
    {
      if (!data.isPrepared())
        data.prepare();
      this.width = data.getWidth();
      this.height = data.getHeight();
      this.bind();
      this.unsafeSetFilter(this.minFilter, this.magFilter, true);
      this.unsafeSetWrap(this.uWrap, this.vWrap, true);
      data.consumeCubemapData();
      Gl.bindTexture(this.__\u003C\u003EglTarget, 0);
    }

    [LineNumberTable(new byte[] {159, 161, 109, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cubemap(CubemapData data)
      : base(34067)
    {
      Cubemap cubemap = this;
      this.data = data;
      this.load(data);
    }

    [LineNumberTable(new byte[] {159, 179, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cubemap(
      Fi positiveX,
      Fi negativeX,
      Fi positiveY,
      Fi negativeY,
      Fi positiveZ,
      Fi negativeZ)
      : this(positiveX, negativeX, positiveY, negativeY, positiveZ, negativeZ, false)
    {
    }

    [LineNumberTable(new byte[] {159, 132, 131, 113, 112, 13, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cubemap(
      Fi positiveX,
      Fi negativeX,
      Fi positiveY,
      Fi negativeY,
      Fi positiveZ,
      Fi negativeZ,
      bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(TextureData.load(positiveX, num != 0), TextureData.load(negativeX, num != 0), TextureData.load(positiveY, num != 0), TextureData.load(negativeY, num != 0), TextureData.load(positiveZ, num != 0), TextureData.load(negativeZ, num != 0));
    }

    [LineNumberTable(new byte[] {22, 109, 107, 107, 107, 107, 116, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cubemap(
      TextureData positiveX,
      TextureData negativeX,
      TextureData positiveY,
      TextureData negativeY,
      TextureData positiveZ,
      TextureData negativeZ)
      : base(34067)
    {
      Cubemap cubemap = this;
      this.minFilter = Texture.TextureFilter.__\u003C\u003Enearest;
      this.magFilter = Texture.TextureFilter.__\u003C\u003Enearest;
      this.uWrap = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      this.vWrap = Texture.TextureWrap.__\u003C\u003EclampToEdge;
      this.data = (CubemapData) new FacedCubemapData(positiveX, negativeX, positiveY, negativeY, positiveZ, negativeZ);
      this.load(this.data);
    }

    [LineNumberTable(new byte[] {159, 129, 131, 118, 120, 113, 120, 234, 60, 229, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cubemap(
      Pixmap positiveX,
      Pixmap negativeX,
      Pixmap positiveY,
      Pixmap negativeY,
      Pixmap positiveZ,
      Pixmap negativeZ,
      bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(positiveX != null ? (TextureData) new PixmapTextureData(positiveX, (Pixmap.Format) null, num != 0, false) : (TextureData) null, negativeX != null ? (TextureData) new PixmapTextureData(negativeX, (Pixmap.Format) null, num != 0, false) : (TextureData) null, positiveY != null ? (TextureData) new PixmapTextureData(positiveY, (Pixmap.Format) null, num != 0, false) : (TextureData) null, negativeY != null ? (TextureData) new PixmapTextureData(negativeY, (Pixmap.Format) null, num != 0, false) : (TextureData) null, positiveZ != null ? (TextureData) new PixmapTextureData(positiveZ, (Pixmap.Format) null, num != 0, false) : (TextureData) null, negativeZ != null ? (TextureData) new PixmapTextureData(negativeZ, (Pixmap.Format) null, num != 0, false) : (TextureData) null);
    }

    [LineNumberTable(new byte[] {159, 191, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cubemap(
      Pixmap positiveX,
      Pixmap negativeX,
      Pixmap positiveY,
      Pixmap negativeY,
      Pixmap positiveZ,
      Pixmap negativeZ)
      : this(positiveX, negativeX, positiveY, negativeY, positiveZ, negativeZ, false)
    {
    }

    [LineNumberTable(new byte[] {13, 223, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Cubemap(int width, int height, int depth, Pixmap.Format format)
      : this((TextureData) new PixmapTextureData(new Pixmap(depth, height, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(depth, height, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(width, depth, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(width, depth, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(width, height, format), (Pixmap.Format) null, false, true), (TextureData) new PixmapTextureData(new Pixmap(width, height, format), (Pixmap.Format) null, false, true))
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CubemapData getCubemapData() => this.data;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getDepth() => 0;

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/graphics/Cubemap$CubemapSide;>;")]
    [Modifiers]
    [Serializable]
    public sealed class CubemapSide : Enum
    {
      [Modifiers]
      internal static Cubemap.CubemapSide __\u003C\u003EpositiveX;
      [Modifiers]
      internal static Cubemap.CubemapSide __\u003C\u003EnegativeX;
      [Modifiers]
      internal static Cubemap.CubemapSide __\u003C\u003EpositiveY;
      [Modifiers]
      internal static Cubemap.CubemapSide __\u003C\u003EnegativeY;
      [Modifiers]
      internal static Cubemap.CubemapSide __\u003C\u003EpositiveZ;
      [Modifiers]
      internal static Cubemap.CubemapSide __\u003C\u003EnegativeZ;
      internal int __\u003C\u003Eindex;
      internal int __\u003C\u003EglEnum;
      internal Vec3 __\u003C\u003Eup;
      internal Vec3 __\u003C\u003Edirection;
      [Modifiers]
      private static Cubemap.CubemapSide[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(IIFFFFFF)V")]
      [LineNumberTable(new byte[] {87, 106, 103, 104, 116, 116})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private CubemapSide(
        [In] string obj0,
        [In] int obj1,
        [In] int obj2,
        [In] int obj3,
        [In] float obj4,
        [In] float obj5,
        [In] float obj6,
        [In] float obj7,
        [In] float obj8,
        [In] float obj9)
        : base(obj0, obj1)
      {
        Cubemap.CubemapSide cubemapSide = this;
        this.__\u003C\u003Eindex = obj2;
        this.__\u003C\u003EglEnum = obj3;
        this.__\u003C\u003Eup = new Vec3(obj4, obj5, obj6);
        this.__\u003C\u003Edirection = new Vec3(obj7, obj8, obj9);
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(114)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Cubemap.CubemapSide[] values() => (Cubemap.CubemapSide[]) Cubemap.CubemapSide.\u0024VALUES.Clone();

      [LineNumberTable(114)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Cubemap.CubemapSide valueOf(string name) => (Cubemap.CubemapSide) Enum.valueOf((Class) ClassLiteral<Cubemap.CubemapSide>.Value, name);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getGLEnum() => this.__\u003C\u003EglEnum;

      [LineNumberTable(151)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Vec3 getUp(Vec3 @out) => @out.set(this.__\u003C\u003Eup);

      [LineNumberTable(156)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Vec3 getDirection(Vec3 @out) => @out.set(this.__\u003C\u003Edirection);

      [LineNumberTable(new byte[] {159, 113, 77, 159, 21, 159, 21, 159, 21, 159, 21, 159, 21, 255, 21, 52})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static CubemapSide()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.Cubemap$CubemapSide"))
          return;
        Cubemap.CubemapSide.__\u003C\u003EpositiveX = new Cubemap.CubemapSide(nameof (positiveX), 0, 0, 34069, 0.0f, -1f, 0.0f, 1f, 0.0f, 0.0f);
        Cubemap.CubemapSide.__\u003C\u003EnegativeX = new Cubemap.CubemapSide(nameof (negativeX), 1, 1, 34070, 0.0f, -1f, 0.0f, -1f, 0.0f, 0.0f);
        Cubemap.CubemapSide.__\u003C\u003EpositiveY = new Cubemap.CubemapSide(nameof (positiveY), 2, 2, 34071, 0.0f, 0.0f, 1f, 0.0f, 1f, 0.0f);
        Cubemap.CubemapSide.__\u003C\u003EnegativeY = new Cubemap.CubemapSide(nameof (negativeY), 3, 3, 34072, 0.0f, 0.0f, -1f, 0.0f, -1f, 0.0f);
        Cubemap.CubemapSide.__\u003C\u003EpositiveZ = new Cubemap.CubemapSide(nameof (positiveZ), 4, 4, 34073, 0.0f, -1f, 0.0f, 0.0f, 0.0f, 1f);
        Cubemap.CubemapSide.__\u003C\u003EnegativeZ = new Cubemap.CubemapSide(nameof (negativeZ), 5, 5, 34074, 0.0f, -1f, 0.0f, 0.0f, 0.0f, -1f);
        Cubemap.CubemapSide.\u0024VALUES = new Cubemap.CubemapSide[6]
        {
          Cubemap.CubemapSide.__\u003C\u003EpositiveX,
          Cubemap.CubemapSide.__\u003C\u003EnegativeX,
          Cubemap.CubemapSide.__\u003C\u003EpositiveY,
          Cubemap.CubemapSide.__\u003C\u003EnegativeY,
          Cubemap.CubemapSide.__\u003C\u003EpositiveZ,
          Cubemap.CubemapSide.__\u003C\u003EnegativeZ
        };
      }

      [Modifiers]
      public static Cubemap.CubemapSide positiveX
      {
        [HideFromJava] get => Cubemap.CubemapSide.__\u003C\u003EpositiveX;
      }

      [Modifiers]
      public static Cubemap.CubemapSide negativeX
      {
        [HideFromJava] get => Cubemap.CubemapSide.__\u003C\u003EnegativeX;
      }

      [Modifiers]
      public static Cubemap.CubemapSide positiveY
      {
        [HideFromJava] get => Cubemap.CubemapSide.__\u003C\u003EpositiveY;
      }

      [Modifiers]
      public static Cubemap.CubemapSide negativeY
      {
        [HideFromJava] get => Cubemap.CubemapSide.__\u003C\u003EnegativeY;
      }

      [Modifiers]
      public static Cubemap.CubemapSide positiveZ
      {
        [HideFromJava] get => Cubemap.CubemapSide.__\u003C\u003EpositiveZ;
      }

      [Modifiers]
      public static Cubemap.CubemapSide negativeZ
      {
        [HideFromJava] get => Cubemap.CubemapSide.__\u003C\u003EnegativeZ;
      }

      [Modifiers]
      public int index
      {
        [HideFromJava] get => this.__\u003C\u003Eindex;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eindex = value;
      }

      [Modifiers]
      public int glEnum
      {
        [HideFromJava] get => this.__\u003C\u003EglEnum;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EglEnum = value;
      }

      [Modifiers]
      public Vec3 up
      {
        [HideFromJava] get => this.__\u003C\u003Eup;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eup = value;
      }

      [Modifiers]
      public Vec3 direction
      {
        [HideFromJava] get => this.__\u003C\u003Edirection;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Edirection = value;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        positiveX,
        negativeX,
        positiveY,
        negativeY,
        positiveZ,
        negativeZ,
      }
    }
  }
}
