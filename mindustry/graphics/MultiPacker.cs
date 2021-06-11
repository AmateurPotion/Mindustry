// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.MultiPacker
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class MultiPacker : Object, Disposable
  {
    private PixmapPacker[] packers;

    [LineNumberTable(new byte[] {159, 166, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(MultiPacker.PageType type, string name, PixmapRegion region) => this.packers[type.ordinal()].pack(name, region);

    [LineNumberTable(new byte[] {159, 170, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(MultiPacker.PageType type, string name, Pixmap pix) => this.packers[type.ordinal()].pack(name, pix);

    [LineNumberTable(new byte[] {159, 154, 8, 177, 108, 102, 22, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MultiPacker()
    {
      MultiPacker multiPacker = this;
      this.packers = new PixmapPacker[MultiPacker.PageType.__\u003C\u003Eall.Length];
      for (int index = 0; index < this.packers.Length; ++index)
      {
        int num = 2048;
        this.packers[index] = new PixmapPacker(num, num, Pixmap.Format.__\u003C\u003Ergba8888, 2, true);
      }
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(MultiPacker.PageType type, string name) => this.packers[type.ordinal()].getRect(name) != null;

    [LineNumberTable(new byte[] {159, 174, 116, 43, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureAtlas flush(Texture.TextureFilter filter, TextureAtlas atlas)
    {
      PixmapPacker[] packers = this.packers;
      int length = packers.Length;
      for (int index = 0; index < length; ++index)
        packers[index].updateTextureAtlas(atlas, filter, filter, false, false);
      return atlas;
    }

    [LineNumberTable(new byte[] {159, 182, 116, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      PixmapPacker[] packers = this.packers;
      int length = packers.Length;
      for (int index = 0; index < length; ++index)
        packers[index].dispose();
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/graphics/MultiPacker$PageType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class PageType : Enum
    {
      [Modifiers]
      internal static MultiPacker.PageType __\u003C\u003Emain;
      [Modifiers]
      internal static MultiPacker.PageType __\u003C\u003Eenvironment;
      [Modifiers]
      internal static MultiPacker.PageType __\u003C\u003Eeditor;
      [Modifiers]
      internal static MultiPacker.PageType __\u003C\u003Eui;
      internal static MultiPacker.PageType[] __\u003C\u003Eall;
      [Modifiers]
      private static MultiPacker.PageType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PageType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static MultiPacker.PageType[] values() => (MultiPacker.PageType[]) MultiPacker.PageType.\u0024VALUES.Clone();

      [LineNumberTable(52)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static MultiPacker.PageType valueOf(string name) => (MultiPacker.PageType) Enum.valueOf((Class) ClassLiteral<MultiPacker.PageType>.Value, name);

      [LineNumberTable(new byte[] {159, 129, 109, 112, 112, 112, 240, 60, 255, 12, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static PageType()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.MultiPacker$PageType"))
          return;
        MultiPacker.PageType.__\u003C\u003Emain = new MultiPacker.PageType(nameof (main), 0);
        MultiPacker.PageType.__\u003C\u003Eenvironment = new MultiPacker.PageType(nameof (environment), 1);
        MultiPacker.PageType.__\u003C\u003Eeditor = new MultiPacker.PageType(nameof (editor), 2);
        MultiPacker.PageType.__\u003C\u003Eui = new MultiPacker.PageType(nameof (ui), 3);
        MultiPacker.PageType.\u0024VALUES = new MultiPacker.PageType[4]
        {
          MultiPacker.PageType.__\u003C\u003Emain,
          MultiPacker.PageType.__\u003C\u003Eenvironment,
          MultiPacker.PageType.__\u003C\u003Eeditor,
          MultiPacker.PageType.__\u003C\u003Eui
        };
        MultiPacker.PageType.__\u003C\u003Eall = MultiPacker.PageType.values();
      }

      [Modifiers]
      public static MultiPacker.PageType main
      {
        [HideFromJava] get => MultiPacker.PageType.__\u003C\u003Emain;
      }

      [Modifiers]
      public static MultiPacker.PageType environment
      {
        [HideFromJava] get => MultiPacker.PageType.__\u003C\u003Eenvironment;
      }

      [Modifiers]
      public static MultiPacker.PageType editor
      {
        [HideFromJava] get => MultiPacker.PageType.__\u003C\u003Eeditor;
      }

      [Modifiers]
      public static MultiPacker.PageType ui
      {
        [HideFromJava] get => MultiPacker.PageType.__\u003C\u003Eui;
      }

      [Modifiers]
      public static MultiPacker.PageType[] all
      {
        [HideFromJava] get => MultiPacker.PageType.__\u003C\u003Eall;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        main,
        environment,
        editor,
        ui,
      }
    }
  }
}
