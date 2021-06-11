// Decompiled with JetBrains decompiler
// Type: arc.graphics.Texture
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.graphics.gl;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public class Texture : GLTexture
  {
    internal TextureData data;

    [LineNumberTable(new byte[] {71, 105, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      if (this.glHandle == 0)
        return;
      this.delete();
    }

    [LineNumberTable(new byte[] {159, 185, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Texture(Pixmap pixmap)
      : this((TextureData) new PixmapTextureData(pixmap, (Pixmap.Format) null, false, false))
    {
    }

    [LineNumberTable(new byte[] {44, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Pixmap pixmap) => this.draw(pixmap, 0, 0);

    [LineNumberTable(new byte[] {159, 169, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Texture(string internalPath)
      : this(Core.files.@internal(internalPath))
    {
    }

    [LineNumberTable(new byte[] {29, 103, 108, 140, 142, 102, 139, 115, 115, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(TextureData data)
    {
      this.data = data;
      this.width = data.getWidth();
      this.height = data.getHeight();
      if (!data.isPrepared())
        data.prepare();
      this.bind();
      GLTexture.uploadImageData(3553, data);
      this.unsafeSetFilter(this.minFilter, this.magFilter, true);
      this.unsafeSetWrap(this.uWrap, this.vWrap, true);
      Gl.bindTexture(this.__\u003C\u003EglTarget, 0);
    }

    [LineNumberTable(new byte[] {9, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Texture(TextureData data)
      : this(3553, Gl.genTexture(), data)
    {
    }

    [LineNumberTable(new byte[] {159, 173, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Texture(Fi file)
      : this(file, (Pixmap.Format) null, false)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isDisposed() => this.glHandle == 0;

    [LineNumberTable(new byte[] {55, 102, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(Pixmap pixmap, int x, int y)
    {
      this.bind();
      Gl.texSubImage2D(this.__\u003C\u003EglTarget, 0, x, y, pixmap.getWidth(), pixmap.getHeight(), pixmap.getGLFormat(), pixmap.getGLType(), (Buffer) pixmap.getPixels());
    }

    [LineNumberTable(new byte[] {159, 133, 162, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Texture(Fi file, Pixmap.Format format, bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(TextureData.load(file, format, num != 0));
    }

    [LineNumberTable(new byte[] {18, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Texture(int glTarget, int glHandle, TextureData data)
      : base(glTarget, glHandle)
    {
      Texture texture = this;
      this.load(data);
    }

    [LineNumberTable(new byte[] {14, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Texture()
      : base(0, 0)
    {
    }

    [LineNumberTable(new byte[] {159, 134, 162, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Texture(Fi file, bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(file, (Pixmap.Format) null, num != 0);
    }

    [LineNumberTable(new byte[] {159, 131, 162, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Texture(Pixmap pixmap, bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector((TextureData) new PixmapTextureData(pixmap, (Pixmap.Format) null, num != 0, false));
    }

    [LineNumberTable(new byte[] {159, 130, 162, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Texture(Pixmap pixmap, Pixmap.Format format, bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector((TextureData) new PixmapTextureData(pixmap, format, num != 0, false));
    }

    [LineNumberTable(new byte[] {5, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Texture(int width, int height, Pixmap.Format format)
      : this((TextureData) new PixmapTextureData(new Pixmap(width, height, format), (Pixmap.Format) null, false, true))
    {
    }

    [LineNumberTable(new byte[] {23, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Texture createEmpty(TextureData data) => new Texture()
    {
      data = data
    };

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getDepth() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureData getTextureData() => this.data;

    [LineNumberTable(new byte[] {81, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.data is FileTextureData ? Object.instancehelper_toString((object) this.data) : base.toString();

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/graphics/Texture$TextureFilter;>;")]
    [Modifiers]
    [Serializable]
    public sealed class TextureFilter : Enum
    {
      [Modifiers]
      internal static Texture.TextureFilter __\u003C\u003Enearest;
      [Modifiers]
      internal static Texture.TextureFilter __\u003C\u003Elinear;
      [Modifiers]
      internal static Texture.TextureFilter __\u003C\u003EmipMap;
      [Modifiers]
      internal static Texture.TextureFilter __\u003C\u003EmipMapNearestNearest;
      [Modifiers]
      internal static Texture.TextureFilter __\u003C\u003EmipMapLinearNearest;
      [Modifiers]
      internal static Texture.TextureFilter __\u003C\u003EmipMapNearestLinear;
      [Modifiers]
      internal static Texture.TextureFilter __\u003C\u003EmipMapLinearLinear;
      internal int __\u003C\u003EglEnum;
      [Modifiers]
      private static Texture.TextureFilter[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {121, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private TextureFilter([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        Texture.TextureFilter textureFilter = this;
        this.__\u003C\u003EglEnum = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(135)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Texture.TextureFilter[] values() => (Texture.TextureFilter[]) Texture.TextureFilter.\u0024VALUES.Clone();

      [LineNumberTable(135)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Texture.TextureFilter valueOf(string name) => (Texture.TextureFilter) Enum.valueOf((Class) ClassLiteral<Texture.TextureFilter>.Value, name);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isMipMap() => this.__\u003C\u003EglEnum != 9728 && this.__\u003C\u003EglEnum != 9729;

      [LineNumberTable(new byte[] {159, 108, 109, 181, 181, 245, 70, 245, 70, 245, 70, 245, 70, 245, 32})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static TextureFilter()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.Texture$TextureFilter"))
          return;
        Texture.TextureFilter.__\u003C\u003Enearest = new Texture.TextureFilter(nameof (nearest), 0, 9728);
        Texture.TextureFilter.__\u003C\u003Elinear = new Texture.TextureFilter(nameof (linear), 1, 9729);
        Texture.TextureFilter.__\u003C\u003EmipMap = new Texture.TextureFilter(nameof (mipMap), 2, 9987);
        Texture.TextureFilter.__\u003C\u003EmipMapNearestNearest = new Texture.TextureFilter(nameof (mipMapNearestNearest), 3, 9984);
        Texture.TextureFilter.__\u003C\u003EmipMapLinearNearest = new Texture.TextureFilter(nameof (mipMapLinearNearest), 4, 9985);
        Texture.TextureFilter.__\u003C\u003EmipMapNearestLinear = new Texture.TextureFilter(nameof (mipMapNearestLinear), 5, 9986);
        Texture.TextureFilter.__\u003C\u003EmipMapLinearLinear = new Texture.TextureFilter(nameof (mipMapLinearLinear), 6, 9987);
        Texture.TextureFilter.\u0024VALUES = new Texture.TextureFilter[7]
        {
          Texture.TextureFilter.__\u003C\u003Enearest,
          Texture.TextureFilter.__\u003C\u003Elinear,
          Texture.TextureFilter.__\u003C\u003EmipMap,
          Texture.TextureFilter.__\u003C\u003EmipMapNearestNearest,
          Texture.TextureFilter.__\u003C\u003EmipMapLinearNearest,
          Texture.TextureFilter.__\u003C\u003EmipMapNearestLinear,
          Texture.TextureFilter.__\u003C\u003EmipMapLinearLinear
        };
      }

      [Modifiers]
      public static Texture.TextureFilter nearest
      {
        [HideFromJava] get => Texture.TextureFilter.__\u003C\u003Enearest;
      }

      [Modifiers]
      public static Texture.TextureFilter linear
      {
        [HideFromJava] get => Texture.TextureFilter.__\u003C\u003Elinear;
      }

      [Modifiers]
      public static Texture.TextureFilter mipMap
      {
        [HideFromJava] get => Texture.TextureFilter.__\u003C\u003EmipMap;
      }

      [Modifiers]
      public static Texture.TextureFilter mipMapNearestNearest
      {
        [HideFromJava] get => Texture.TextureFilter.__\u003C\u003EmipMapNearestNearest;
      }

      [Modifiers]
      public static Texture.TextureFilter mipMapLinearNearest
      {
        [HideFromJava] get => Texture.TextureFilter.__\u003C\u003EmipMapLinearNearest;
      }

      [Modifiers]
      public static Texture.TextureFilter mipMapNearestLinear
      {
        [HideFromJava] get => Texture.TextureFilter.__\u003C\u003EmipMapNearestLinear;
      }

      [Modifiers]
      public static Texture.TextureFilter mipMapLinearLinear
      {
        [HideFromJava] get => Texture.TextureFilter.__\u003C\u003EmipMapLinearLinear;
      }

      [Modifiers]
      public int glEnum
      {
        [HideFromJava] get => this.__\u003C\u003EglEnum;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EglEnum = value;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        nearest,
        linear,
        mipMap,
        mipMapNearestNearest,
        mipMapLinearNearest,
        mipMapNearestLinear,
        mipMapLinearLinear,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/graphics/Texture$TextureWrap;>;")]
    [Modifiers]
    [Serializable]
    public sealed class TextureWrap : Enum
    {
      [Modifiers]
      internal static Texture.TextureWrap __\u003C\u003EmirroredRepeat;
      [Modifiers]
      internal static Texture.TextureWrap __\u003C\u003EclampToEdge;
      [Modifiers]
      internal static Texture.TextureWrap __\u003C\u003Erepeat;
      [Modifiers]
      internal int glEnum;
      [Modifiers]
      private static Texture.TextureWrap[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getGLEnum() => this.glEnum;

      [Signature("(I)V")]
      [LineNumberTable(new byte[] {160, 71, 106, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private TextureWrap([In] string obj0, [In] int obj1, [In] int obj2)
        : base(obj0, obj1)
      {
        Texture.TextureWrap textureWrap = this;
        this.glEnum = obj2;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(180)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Texture.TextureWrap[] values() => (Texture.TextureWrap[]) Texture.TextureWrap.\u0024VALUES.Clone();

      [LineNumberTable(180)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Texture.TextureWrap valueOf(string name) => (Texture.TextureWrap) Enum.valueOf((Class) ClassLiteral<Texture.TextureWrap>.Value, name);

      [LineNumberTable(new byte[] {159, 97, 109, 63, 32})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static TextureWrap()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.Texture$TextureWrap"))
          return;
        Texture.TextureWrap.__\u003C\u003EmirroredRepeat = new Texture.TextureWrap(nameof (mirroredRepeat), 0, 33648);
        Texture.TextureWrap.__\u003C\u003EclampToEdge = new Texture.TextureWrap(nameof (clampToEdge), 1, 33071);
        Texture.TextureWrap.__\u003C\u003Erepeat = new Texture.TextureWrap(nameof (repeat), 2, 10497);
        Texture.TextureWrap.\u0024VALUES = new Texture.TextureWrap[3]
        {
          Texture.TextureWrap.__\u003C\u003EmirroredRepeat,
          Texture.TextureWrap.__\u003C\u003EclampToEdge,
          Texture.TextureWrap.__\u003C\u003Erepeat
        };
      }

      [Modifiers]
      public static Texture.TextureWrap mirroredRepeat
      {
        [HideFromJava] get => Texture.TextureWrap.__\u003C\u003EmirroredRepeat;
      }

      [Modifiers]
      public static Texture.TextureWrap clampToEdge
      {
        [HideFromJava] get => Texture.TextureWrap.__\u003C\u003EclampToEdge;
      }

      [Modifiers]
      public static Texture.TextureWrap repeat
      {
        [HideFromJava] get => Texture.TextureWrap.__\u003C\u003Erepeat;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        mirroredRepeat,
        clampToEdge,
        repeat,
      }
    }
  }
}
