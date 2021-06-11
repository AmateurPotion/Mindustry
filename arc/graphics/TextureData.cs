// Decompiled with JetBrains decompiler
// Type: arc.graphics.TextureData
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.graphics.gl;
using IKVM.Attributes;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public interface TextureData
  {
    [LineNumberTable(new byte[] {159, 123, 130, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TextureData load(Fi file, Pixmap.Format format, bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      return file == null ? (TextureData) null : (TextureData) new FileTextureData(file, new Pixmap(file), format, num != 0);
    }

    bool isPrepared();

    void prepare();

    bool isCustom();

    void consumeCustomData(int i);

    Pixmap consumePixmap();

    bool disposePixmap();

    Pixmap.Format getFormat();

    bool useMipMaps();

    [LineNumberTable(74)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static TextureData load(Fi file, bool useMipMaps)
    {
      int num = useMipMaps ? 1 : 0;
      return TextureData.load(file, (Pixmap.Format) null, num != 0);
    }

    int getWidth();

    int getHeight();

    [Modifiers]
    Pixmap getPixmap();

    [LineNumberTable(new byte[] {159, 188, 104, 134})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Pixmap \u003Cdefault\u003EgetPixmap([In] TextureData obj0)
    {
      if (!obj0.isPrepared())
        obj0.prepare();
      return obj0.consumePixmap();
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static Pixmap getPixmap([In] TextureData obj0)
      {
        TextureData textureData = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(textureData, ToString);
        return TextureData.\u003Cdefault\u003EgetPixmap(textureData);
      }
    }

    [HideFromJava]
    static class __Methods
    {
      public static TextureData load([In] Fi obj0, [In] bool obj1) => TextureData.load(obj0, obj1);

      public static TextureData load([In] Fi obj0, [In] Pixmap.Format obj1, [In] bool obj2) => TextureData.load(obj0, obj1, obj2);
    }
  }
}
