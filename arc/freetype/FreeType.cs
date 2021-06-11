// Decompiled with JetBrains decompiler
// Type: arc.freetype.FreeType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.graphics;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.freetype
{
  public class FreeType : Object
  {
    public static int FT_PIXEL_MODE_NONE;
    public static int FT_PIXEL_MODE_MONO;
    public static int FT_PIXEL_MODE_GRAY;
    public static int FT_PIXEL_MODE_GRAY2;
    public static int FT_PIXEL_MODE_GRAY4;
    public static int FT_PIXEL_MODE_LCD;
    public static int FT_PIXEL_MODE_LCD_V;
    public static int FT_ENCODING_NONE;
    public static int FT_ENCODING_MS_SYMBOL;
    public static int FT_ENCODING_UNICODE;
    public static int FT_ENCODING_SJIS;
    public static int FT_ENCODING_GB2312;
    public static int FT_ENCODING_BIG5;
    public static int FT_ENCODING_WANSUNG;
    public static int FT_ENCODING_JOHAB;
    public static int FT_ENCODING_ADOBE_STANDARD;
    public static int FT_ENCODING_ADOBE_EXPERT;
    public static int FT_ENCODING_ADOBE_CUSTOM;
    public static int FT_ENCODING_ADOBE_LATIN_1;
    public static int FT_ENCODING_OLD_LATIN_2;
    public static int FT_ENCODING_APPLE_ROMAN;
    public static int FT_FACE_FLAG_SCALABLE;
    public static int FT_FACE_FLAG_FIXED_SIZES;
    public static int FT_FACE_FLAG_FIXED_WIDTH;
    public static int FT_FACE_FLAG_SFNT;
    public static int FT_FACE_FLAG_HORIZONTAL;
    public static int FT_FACE_FLAG_VERTICAL;
    public static int FT_FACE_FLAG_KERNING;
    public static int FT_FACE_FLAG_FAST_GLYPHS;
    public static int FT_FACE_FLAG_MULTIPLE_MASTERS;
    public static int FT_FACE_FLAG_GLYPH_NAMES;
    public static int FT_FACE_FLAG_EXTERNAL_STREAM;
    public static int FT_FACE_FLAG_HINTER;
    public static int FT_FACE_FLAG_CID_KEYED;
    public static int FT_FACE_FLAG_TRICKY;
    public static int FT_STYLE_FLAG_ITALIC;
    public static int FT_STYLE_FLAG_BOLD;
    public static int FT_LOAD_DEFAULT;
    public static int FT_LOAD_NO_SCALE;
    public static int FT_LOAD_NO_HINTING;
    public static int FT_LOAD_RENDER;
    public static int FT_LOAD_NO_BITMAP;
    public static int FT_LOAD_VERTICAL_LAYOUT;
    public static int FT_LOAD_FORCE_AUTOHINT;
    public static int FT_LOAD_CROP_BITMAP;
    public static int FT_LOAD_PEDANTIC;
    public static int FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH;
    public static int FT_LOAD_NO_RECURSE;
    public static int FT_LOAD_IGNORE_TRANSFORM;
    public static int FT_LOAD_MONOCHROME;
    public static int FT_LOAD_LINEAR_DESIGN;
    public static int FT_LOAD_NO_AUTOHINT;
    public static int FT_LOAD_TARGET_NORMAL;
    public static int FT_LOAD_TARGET_LIGHT;
    public static int FT_LOAD_TARGET_MONO;
    public static int FT_LOAD_TARGET_LCD;
    public static int FT_LOAD_TARGET_LCD_V;
    public static int FT_RENDER_MODE_NORMAL;
    public static int FT_RENDER_MODE_LIGHT;
    public static int FT_RENDER_MODE_MONO;
    public static int FT_RENDER_MODE_LCD;
    public static int FT_RENDER_MODE_LCD_V;
    public static int FT_RENDER_MODE_MAX;
    public static int FT_KERNING_DEFAULT;
    public static int FT_KERNING_UNFITTED;
    public static int FT_KERNING_UNSCALED;
    public static int FT_STROKER_LINECAP_BUTT;
    public static int FT_STROKER_LINECAP_ROUND;
    public static int FT_STROKER_LINECAP_SQUARE;
    public static int FT_STROKER_LINEJOIN_ROUND;
    public static int FT_STROKER_LINEJOIN_BEVEL;
    public static int FT_STROKER_LINEJOIN_MITER_VARIABLE;
    public static int FT_STROKER_LINEJOIN_MITER;
    public static int FT_STROKER_LINEJOIN_MITER_FIXED;
    static IntPtr __\u003Cjniptr\u003EgetLastErrorCode\u0028\u0029I;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EinitFreeTypeJni\u0028\u0029J;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    private static long initFreeTypeJni()
    {
      JNI.Frame frame = new JNI.Frame();
      if (FreeType.__\u003Cjniptr\u003EinitFreeTypeJni\u0028\u0029J == IntPtr.Zero)
        FreeType.__\u003Cjniptr\u003EinitFreeTypeJni\u0028\u0029J = JNI.Frame.GetFuncPtr(FreeType.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType", nameof (initFreeTypeJni), "()J");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<long (IntPtr, IntPtr)>) FreeType.__\u003Cjniptr\u003EinitFreeTypeJni\u0028\u0029J)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [Modifiers]
    internal static int getLastErrorCode()
    {
      JNI.Frame frame = new JNI.Frame();
      if (FreeType.__\u003Cjniptr\u003EgetLastErrorCode\u0028\u0029I == IntPtr.Zero)
        FreeType.__\u003Cjniptr\u003EgetLastErrorCode\u0028\u0029I = JNI.Frame.GetFuncPtr(FreeType.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType", nameof (getLastErrorCode), "()I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr)>) FreeType.__\u003Cjniptr\u003EgetLastErrorCode\u0028\u0029I)(num2, num3);
      }
      catch (object ex)
      {
        Console.WriteLine((object) "*** exception in native code ***");
        Console.WriteLine(ex);
        throw;
      }
      finally
      {
        ((JNI.Frame) ref frame).Leave();
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int encode([In] char obj0, [In] char obj1, [In] char obj2, [In] char obj3) => (int) obj0 << 24 | (int) obj1 << 16 | (int) obj2 << 8 | (int) obj3;

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FreeType()
    {
    }

    [LineNumberTable(new byte[] {162, 253, 111, 102, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static FreeType.Library initFreeType()
    {
      new SharedLibraryLoader().load("arc-freetype");
      long num = FreeType.initFreeTypeJni();
      if (num == 0L)
      {
        string message = new StringBuilder().append("Couldn't initialize FreeType library, FreeType error code: ").append(FreeType.getLastErrorCode()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      return new FreeType.Library(num);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toInt(int value) => (value + 63 & -64) >> 6;

    [LineNumberTable(new byte[] {158, 201, 141, 102, 102, 102, 102, 102, 102, 230, 70, 102, 114, 114, 114, 114, 114, 114, 114, 114, 114, 114, 114, 114, 146, 102, 102, 102, 102, 103, 103, 103, 106, 106, 106, 106, 106, 106, 138, 102, 134, 102, 102, 102, 102, 102, 103, 103, 103, 106, 106, 106, 106, 106, 106, 138, 102, 106, 106, 106, 138, 102, 102, 102, 102, 102, 134, 102, 102, 134, 102, 102, 134, 102, 102, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FreeType()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.freetype.FreeType"))
        return;
      FreeType.FT_PIXEL_MODE_NONE = 0;
      FreeType.FT_PIXEL_MODE_MONO = 1;
      FreeType.FT_PIXEL_MODE_GRAY = 2;
      FreeType.FT_PIXEL_MODE_GRAY2 = 3;
      FreeType.FT_PIXEL_MODE_GRAY4 = 4;
      FreeType.FT_PIXEL_MODE_LCD = 5;
      FreeType.FT_PIXEL_MODE_LCD_V = 6;
      FreeType.FT_ENCODING_NONE = 0;
      FreeType.FT_ENCODING_MS_SYMBOL = FreeType.encode('s', 'y', 'm', 'b');
      FreeType.FT_ENCODING_UNICODE = FreeType.encode('u', 'n', 'i', 'c');
      FreeType.FT_ENCODING_SJIS = FreeType.encode('s', 'j', 'i', 's');
      FreeType.FT_ENCODING_GB2312 = FreeType.encode('g', 'b', ' ', ' ');
      FreeType.FT_ENCODING_BIG5 = FreeType.encode('b', 'i', 'g', '5');
      FreeType.FT_ENCODING_WANSUNG = FreeType.encode('w', 'a', 'n', 's');
      FreeType.FT_ENCODING_JOHAB = FreeType.encode('j', 'o', 'h', 'a');
      FreeType.FT_ENCODING_ADOBE_STANDARD = FreeType.encode('A', 'D', 'O', 'B');
      FreeType.FT_ENCODING_ADOBE_EXPERT = FreeType.encode('A', 'D', 'B', 'E');
      FreeType.FT_ENCODING_ADOBE_CUSTOM = FreeType.encode('A', 'D', 'B', 'C');
      FreeType.FT_ENCODING_ADOBE_LATIN_1 = FreeType.encode('l', 'a', 't', '1');
      FreeType.FT_ENCODING_OLD_LATIN_2 = FreeType.encode('l', 'a', 't', '2');
      FreeType.FT_ENCODING_APPLE_ROMAN = FreeType.encode('a', 'r', 'm', 'n');
      FreeType.FT_FACE_FLAG_SCALABLE = 1;
      FreeType.FT_FACE_FLAG_FIXED_SIZES = 2;
      FreeType.FT_FACE_FLAG_FIXED_WIDTH = 4;
      FreeType.FT_FACE_FLAG_SFNT = 8;
      FreeType.FT_FACE_FLAG_HORIZONTAL = 16;
      FreeType.FT_FACE_FLAG_VERTICAL = 32;
      FreeType.FT_FACE_FLAG_KERNING = 64;
      FreeType.FT_FACE_FLAG_FAST_GLYPHS = 128;
      FreeType.FT_FACE_FLAG_MULTIPLE_MASTERS = 256;
      FreeType.FT_FACE_FLAG_GLYPH_NAMES = 512;
      FreeType.FT_FACE_FLAG_EXTERNAL_STREAM = 1024;
      FreeType.FT_FACE_FLAG_HINTER = 2048;
      FreeType.FT_FACE_FLAG_CID_KEYED = 4096;
      FreeType.FT_FACE_FLAG_TRICKY = 8192;
      FreeType.FT_STYLE_FLAG_ITALIC = 1;
      FreeType.FT_STYLE_FLAG_BOLD = 2;
      FreeType.FT_LOAD_DEFAULT = 0;
      FreeType.FT_LOAD_NO_SCALE = 1;
      FreeType.FT_LOAD_NO_HINTING = 2;
      FreeType.FT_LOAD_RENDER = 4;
      FreeType.FT_LOAD_NO_BITMAP = 8;
      FreeType.FT_LOAD_VERTICAL_LAYOUT = 16;
      FreeType.FT_LOAD_FORCE_AUTOHINT = 32;
      FreeType.FT_LOAD_CROP_BITMAP = 64;
      FreeType.FT_LOAD_PEDANTIC = 128;
      FreeType.FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH = 512;
      FreeType.FT_LOAD_NO_RECURSE = 1024;
      FreeType.FT_LOAD_IGNORE_TRANSFORM = 2048;
      FreeType.FT_LOAD_MONOCHROME = 4096;
      FreeType.FT_LOAD_LINEAR_DESIGN = 8192;
      FreeType.FT_LOAD_NO_AUTOHINT = 32768;
      FreeType.FT_LOAD_TARGET_NORMAL = 0;
      FreeType.FT_LOAD_TARGET_LIGHT = 65536;
      FreeType.FT_LOAD_TARGET_MONO = 131072;
      FreeType.FT_LOAD_TARGET_LCD = 196608;
      FreeType.FT_LOAD_TARGET_LCD_V = 262144;
      FreeType.FT_RENDER_MODE_NORMAL = 0;
      FreeType.FT_RENDER_MODE_LIGHT = 1;
      FreeType.FT_RENDER_MODE_MONO = 2;
      FreeType.FT_RENDER_MODE_LCD = 3;
      FreeType.FT_RENDER_MODE_LCD_V = 4;
      FreeType.FT_RENDER_MODE_MAX = 5;
      FreeType.FT_KERNING_DEFAULT = 0;
      FreeType.FT_KERNING_UNFITTED = 1;
      FreeType.FT_KERNING_UNSCALED = 2;
      FreeType.FT_STROKER_LINECAP_BUTT = 0;
      FreeType.FT_STROKER_LINECAP_ROUND = 1;
      FreeType.FT_STROKER_LINECAP_SQUARE = 2;
      FreeType.FT_STROKER_LINEJOIN_ROUND = 0;
      FreeType.FT_STROKER_LINEJOIN_BEVEL = 1;
      FreeType.FT_STROKER_LINEJOIN_MITER_VARIABLE = 2;
      FreeType.FT_STROKER_LINEJOIN_MITER = FreeType.FT_STROKER_LINEJOIN_MITER_VARIABLE;
      FreeType.FT_STROKER_LINEJOIN_MITER_FIXED = 3;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (FreeType.__\u003CcallerID\u003E == null)
        FreeType.__\u003CcallerID\u003E = (CallerID) new FreeType.__\u003CCallerID\u003E();
      return FreeType.__\u003CcallerID\u003E;
    }

    public class Bitmap : FreeType.Pointer
    {
      static IntPtr __\u003Cjniptr\u003EgetRows\u0028J\u0029I;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;
      static IntPtr __\u003Cjniptr\u003EgetWidth\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetPitch\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetBuffer\u0028J\u0029Ljava\u002Fnio\u002FByteBuffer\u003B;
      static IntPtr __\u003Cjniptr\u003EgetNumGray\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetPixelMode\u0028J\u0029I;

      [Modifiers]
      private static int getRows([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Bitmap.__\u003Cjniptr\u003EgetRows\u0028J\u0029I == IntPtr.Zero)
          FreeType.Bitmap.__\u003Cjniptr\u003EgetRows\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Bitmap.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Bitmap", nameof (getRows), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Bitmap.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Bitmap>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Bitmap.__\u003Cjniptr\u003EgetRows\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getWidth([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Bitmap.__\u003Cjniptr\u003EgetWidth\u0028J\u0029I == IntPtr.Zero)
          FreeType.Bitmap.__\u003Cjniptr\u003EgetWidth\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Bitmap.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Bitmap", nameof (getWidth), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Bitmap.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Bitmap>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Bitmap.__\u003Cjniptr\u003EgetWidth\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getPitch([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Bitmap.__\u003Cjniptr\u003EgetPitch\u0028J\u0029I == IntPtr.Zero)
          FreeType.Bitmap.__\u003Cjniptr\u003EgetPitch\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Bitmap.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Bitmap", nameof (getPitch), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Bitmap.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Bitmap>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Bitmap.__\u003Cjniptr\u003EgetPitch\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(576)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getRows() => FreeType.Bitmap.getRows(this.address);

      [Modifiers]
      private static ByteBuffer getBuffer([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Bitmap.__\u003Cjniptr\u003EgetBuffer\u0028J\u0029Ljava\u002Fnio\u002FByteBuffer\u003B == IntPtr.Zero)
          FreeType.Bitmap.__\u003Cjniptr\u003EgetBuffer\u0028J\u0029Ljava\u002Fnio\u002FByteBuffer\u003B = JNI.Frame.GetFuncPtr(FreeType.Bitmap.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Bitmap", nameof (getBuffer), "(J)Ljava/nio/ByteBuffer;");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Bitmap.__\u003CGetCallerID\u003E());
        try
        {
          ref JNI.Frame local = ref frame;
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Bitmap>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          IntPtr num5 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, long)>) FreeType.Bitmap.__\u003Cjniptr\u003EgetBuffer\u0028J\u0029Ljava\u002Fnio\u002FByteBuffer\u003B)((long) num2, num3, (IntPtr) num4);
          return (ByteBuffer) ((JNI.Frame) ref local).UnwrapLocalRef(num5);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(584)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getWidth() => FreeType.Bitmap.getWidth(this.address);

      [LineNumberTable(new byte[] {161, 230, 232, 70, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ByteBuffer getBuffer() => this.getRows() == 0 ? Buffers.newByteBuffer(1) : FreeType.Bitmap.getBuffer(this.address);

      [LineNumberTable(689)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getPixelMode() => FreeType.Bitmap.getPixelMode(this.address);

      [LineNumberTable(592)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getPitch() => FreeType.Bitmap.getPitch(this.address);

      [Modifiers]
      private static int getNumGray([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Bitmap.__\u003Cjniptr\u003EgetNumGray\u0028J\u0029I == IntPtr.Zero)
          FreeType.Bitmap.__\u003Cjniptr\u003EgetNumGray\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Bitmap.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Bitmap", nameof (getNumGray), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Bitmap.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Bitmap>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Bitmap.__\u003Cjniptr\u003EgetNumGray\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getPixelMode([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Bitmap.__\u003Cjniptr\u003EgetPixelMode\u0028J\u0029I == IntPtr.Zero)
          FreeType.Bitmap.__\u003Cjniptr\u003EgetPixelMode\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Bitmap.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Bitmap", nameof (getPixelMode), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Bitmap.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Bitmap>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Bitmap.__\u003Cjniptr\u003EgetPixelMode\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(new byte[] {161, 202, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Bitmap([In] long obj0)
        : base(obj0)
      {
      }

      [LineNumberTable(new byte[] {161, 247, 110, 135, 103, 109, 127, 4, 110, 158, 110, 104, 105, 104, 110, 139, 107, 105, 110, 103, 117, 110, 140, 233, 60, 8, 241, 73, 234, 53, 240, 79, 106, 106, 107, 105, 203, 103, 100, 105, 105, 140, 255, 8, 54, 235, 76, 234, 50, 235, 83, 100, 111, 118, 108, 107, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Pixmap getPixmap(Pixmap.Format format, Color color, float gamma)
      {
        int width = this.getWidth();
        int rows = this.getRows();
        ByteBuffer buffer = this.getBuffer();
        int pixelMode = this.getPixelMode();
        int length = Math.abs(this.getPitch());
        Pixmap pixmap1;
        if (object.ReferenceEquals((object) color, (object) Color.__\u003C\u003Ewhite) && pixelMode == FreeType.FT_PIXEL_MODE_GRAY && (length == width && (double) gamma == 1.0))
        {
          pixmap1 = new Pixmap(width, rows, Pixmap.Format.__\u003C\u003Ealpha);
          Buffers.copy((Buffer) buffer, (Buffer) pixmap1.getPixels(), ((Buffer) pixmap1.getPixels()).capacity());
        }
        else
        {
          pixmap1 = new Pixmap(width, rows, Pixmap.Format.__\u003C\u003Ergba8888);
          int num1 = color.rgba8888();
          byte[] numArray1 = new byte[length];
          int[] numArray2 = new int[width];
          IntBuffer intBuffer = pixmap1.getPixels().asIntBuffer();
          if (pixelMode == FreeType.FT_PIXEL_MODE_MONO)
          {
            for (int index1 = 0; index1 < rows; ++index1)
            {
              buffer.get(numArray1);
              int index2 = 0;
              for (int index3 = 0; index3 < width; index3 += 8)
              {
                int num2 = (int) (sbyte) numArray1[index2];
                int num3 = 0;
                for (int index4 = Math.min(8, width - index3); num3 < index4; ++num3)
                  numArray2[index3 + num3] = (num2 & 1 << 7 - num3) == 0 ? 0 : num1;
                ++index2;
              }
              intBuffer.put(numArray2);
            }
          }
          else
          {
            int num2 = num1 & -256;
            int num3 = num1 & (int) byte.MaxValue;
            for (int index1 = 0; index1 < rows; ++index1)
            {
              buffer.get(numArray1);
              for (int index2 = 0; index2 < width; ++index2)
              {
                int num4 = (int) numArray1[index2];
                switch (num4)
                {
                  case 0:
                    numArray2[index2] = num2;
                    break;
                  case (int) byte.MaxValue:
                    numArray2[index2] = num2 | num3;
                    break;
                  default:
                    numArray2[index2] = num2 | ByteCodeHelper.f2i((float) num3 * (float) Math.pow((double) ((float) num4 / (float) byte.MaxValue), (double) gamma));
                    break;
                }
              }
              intBuffer.put(numArray2);
            }
          }
        }
        Pixmap pixmap2 = pixmap1;
        if (!object.ReferenceEquals((object) format, (object) pixmap1.getFormat()))
        {
          pixmap2 = new Pixmap(pixmap1.getWidth(), pixmap1.getHeight(), format);
          pixmap2.setBlending(Pixmap.Blending.__\u003C\u003Enone);
          pixmap2.drawPixmap(pixmap1, 0, 0);
          pixmap1.dispose();
        }
        return pixmap2;
      }

      [LineNumberTable(681)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getNumGray() => FreeType.Bitmap.getNumGray(this.address);

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (FreeType.Bitmap.__\u003CcallerID\u003E == null)
          FreeType.Bitmap.__\u003CcallerID\u003E = (CallerID) new FreeType.Bitmap.__\u003CCallerID\u003E();
        return FreeType.Bitmap.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [Implements(new string[] {"arc.util.Disposable"})]
    public class Face : FreeType.Pointer, Disposable
    {
      internal FreeType.Library library;
      static IntPtr __\u003Cjniptr\u003EdoneFace\u0028J\u0029V;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;
      static IntPtr __\u003Cjniptr\u003EgetFaceFlags\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetStyleFlags\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetNumGlyphs\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetAscender\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetDescender\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetHeight\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetMaxAdvanceWidth\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetMaxAdvanceHeight\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetUnderlinePosition\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetUnderlineThickness\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EselectSize\u0028JI\u0029Z;
      static IntPtr __\u003Cjniptr\u003EsetCharSize\u0028JIIII\u0029Z;
      static IntPtr __\u003Cjniptr\u003EsetPixelSizes\u0028JII\u0029Z;
      static IntPtr __\u003Cjniptr\u003EloadGlyph\u0028JII\u0029Z;
      static IntPtr __\u003Cjniptr\u003EloadChar\u0028JII\u0029Z;
      static IntPtr __\u003Cjniptr\u003EgetGlyph\u0028J\u0029J;
      static IntPtr __\u003Cjniptr\u003EgetSize\u0028J\u0029J;
      static IntPtr __\u003Cjniptr\u003EhasKerning\u0028J\u0029Z;
      static IntPtr __\u003Cjniptr\u003EgetKerning\u0028JIII\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetCharIndex\u0028JI\u0029I;

      [Modifiers]
      private static void doneFace([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EdoneFace\u0028J\u0029V == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EdoneFace\u0028J\u0029V = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (doneFace), "(J)V");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EdoneFace\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getFaceFlags([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetFaceFlags\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetFaceFlags\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getFaceFlags), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetFaceFlags\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getStyleFlags([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetStyleFlags\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetStyleFlags\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getStyleFlags), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetStyleFlags\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getNumGlyphs([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetNumGlyphs\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetNumGlyphs\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getNumGlyphs), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetNumGlyphs\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getAscender([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetAscender\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetAscender\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getAscender), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetAscender\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getDescender([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetDescender\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetDescender\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getDescender), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetDescender\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getHeight([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetHeight\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetHeight\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getHeight), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetHeight\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getMaxAdvanceWidth([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetMaxAdvanceWidth\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetMaxAdvanceWidth\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getMaxAdvanceWidth), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetMaxAdvanceWidth\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getMaxAdvanceHeight([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetMaxAdvanceHeight\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetMaxAdvanceHeight\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getMaxAdvanceHeight), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetMaxAdvanceHeight\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getUnderlinePosition([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetUnderlinePosition\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetUnderlinePosition\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getUnderlinePosition), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetUnderlinePosition\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getUnderlineThickness([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetUnderlineThickness\u0028J\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetUnderlineThickness\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getUnderlineThickness), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetUnderlineThickness\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static bool selectSize([In] long obj0, [In] int obj1)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EselectSize\u0028JI\u0029Z == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EselectSize\u0028JI\u0029Z = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (selectSize), "(JI)Z");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          int num5 = obj1;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int)>) FreeType.Face.__\u003Cjniptr\u003EselectSize\u0028JI\u0029Z)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static bool setCharSize([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EsetCharSize\u0028JIIII\u0029Z == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EsetCharSize\u0028JIIII\u0029Z = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (setCharSize), "(JIIII)Z");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          int num5 = obj1;
          int num6 = obj2;
          int num7 = obj3;
          int num8 = obj4;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, int, int, int)>) FreeType.Face.__\u003Cjniptr\u003EsetCharSize\u0028JIIII\u0029Z)((int) num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static bool setPixelSizes([In] long obj0, [In] int obj1, [In] int obj2)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EsetPixelSizes\u0028JII\u0029Z == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EsetPixelSizes\u0028JII\u0029Z = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (setPixelSizes), "(JII)Z");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          int num5 = obj1;
          int num6 = obj2;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, int)>) FreeType.Face.__\u003Cjniptr\u003EsetPixelSizes\u0028JII\u0029Z)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static bool loadGlyph([In] long obj0, [In] int obj1, [In] int obj2)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EloadGlyph\u0028JII\u0029Z == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EloadGlyph\u0028JII\u0029Z = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (loadGlyph), "(JII)Z");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          int num5 = obj1;
          int num6 = obj2;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, int)>) FreeType.Face.__\u003Cjniptr\u003EloadGlyph\u0028JII\u0029Z)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static bool loadChar([In] long obj0, [In] int obj1, [In] int obj2)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EloadChar\u0028JII\u0029Z == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EloadChar\u0028JII\u0029Z = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (loadChar), "(JII)Z");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          int num5 = obj1;
          int num6 = obj2;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int, int)>) FreeType.Face.__\u003Cjniptr\u003EloadChar\u0028JII\u0029Z)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static long getGlyph([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetGlyph\u0028J\u0029J == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetGlyph\u0028J\u0029J = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getGlyph), "(J)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetGlyph\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static long getSize([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetSize\u0028J\u0029J == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetSize\u0028J\u0029J = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getSize), "(J)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EgetSize\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static bool hasKerning([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EhasKerning\u0028J\u0029Z == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EhasKerning\u0028J\u0029Z = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (hasKerning), "(J)Z");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long)>) FreeType.Face.__\u003Cjniptr\u003EhasKerning\u0028J\u0029Z)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getKerning([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetKerning\u0028JIII\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetKerning\u0028JIII\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getKerning), "(JIII)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          int num5 = obj1;
          int num6 = obj2;
          int num7 = obj3;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long, int, int, int)>) FreeType.Face.__\u003Cjniptr\u003EgetKerning\u0028JIII\u0029I)((int) num2, (int) num3, (int) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getCharIndex([In] long obj0, [In] int obj1)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Face.__\u003Cjniptr\u003EgetCharIndex\u0028JI\u0029I == IntPtr.Zero)
          FreeType.Face.__\u003Cjniptr\u003EgetCharIndex\u0028JI\u0029I = JNI.Frame.GetFuncPtr(FreeType.Face.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Face", nameof (getCharIndex), "(JI)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Face.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Face>.Value);
          long num4 = obj0;
          int num5 = obj1;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long, int)>) FreeType.Face.__\u003Cjniptr\u003EgetCharIndex\u0028JI\u0029I)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(new byte[] {68, 105, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Face(long address, FreeType.Library library)
        : base(address)
      {
        FreeType.Face face = this;
        this.library = library;
      }

      [LineNumberTable(new byte[] {74, 107, 124, 99, 119, 104, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dispose()
      {
        FreeType.Face.doneFace(this.address);
        ByteBuffer buffer = (ByteBuffer) this.library.fontData.get(this.address);
        if (buffer == null)
          return;
        this.library.fontData.remove(this.address);
        if (!Buffers.isUnsafeByteBuffer(buffer))
          return;
        Buffers.disposeUnsafeByteBuffer(buffer);
      }

      [LineNumberTable(138)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getFaceFlags() => FreeType.Face.getFaceFlags(this.address);

      [LineNumberTable(146)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getStyleFlags() => FreeType.Face.getStyleFlags(this.address);

      [LineNumberTable(154)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getNumGlyphs() => FreeType.Face.getNumGlyphs(this.address);

      [LineNumberTable(162)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getAscender() => FreeType.Face.getAscender(this.address);

      [LineNumberTable(170)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getDescender() => FreeType.Face.getDescender(this.address);

      [LineNumberTable(178)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getHeight() => FreeType.Face.getHeight(this.address);

      [LineNumberTable(186)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getMaxAdvanceWidth() => FreeType.Face.getMaxAdvanceWidth(this.address);

      [LineNumberTable(194)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getMaxAdvanceHeight() => FreeType.Face.getMaxAdvanceHeight(this.address);

      [LineNumberTable(202)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getUnderlinePosition() => FreeType.Face.getUnderlinePosition(this.address);

      [LineNumberTable(210)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getUnderlineThickness() => FreeType.Face.getUnderlineThickness(this.address);

      [LineNumberTable(218)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool selectSize(int strikeIndex) => FreeType.Face.selectSize(this.address, strikeIndex);

      [LineNumberTable(226)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool setCharSize(
        int charWidth,
        int charHeight,
        int horzResolution,
        int vertResolution)
      {
        return FreeType.Face.setCharSize(this.address, charWidth, charHeight, horzResolution, vertResolution);
      }

      [LineNumberTable(234)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool setPixelSizes(int pixelWidth, int pixelHeight) => FreeType.Face.setPixelSizes(this.address, pixelWidth, pixelHeight);

      [LineNumberTable(242)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool loadGlyph(int glyphIndex, int loadFlags) => FreeType.Face.loadGlyph(this.address, glyphIndex, loadFlags);

      [LineNumberTable(250)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool loadChar(int charCode, int loadFlags) => FreeType.Face.loadChar(this.address, charCode, loadFlags);

      [LineNumberTable(258)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.GlyphSlot getGlyph() => new FreeType.GlyphSlot(FreeType.Face.getGlyph(this.address));

      [LineNumberTable(266)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.Size getSize() => new FreeType.Size(FreeType.Face.getSize(this.address));

      [LineNumberTable(274)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasKerning() => FreeType.Face.hasKerning(this.address);

      [LineNumberTable(282)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getKerning(int leftGlyph, int rightGlyph, int kernMode) => FreeType.Face.getKerning(this.address, leftGlyph, rightGlyph, kernMode);

      [LineNumberTable(293)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getCharIndex(int charCode) => FreeType.Face.getCharIndex(this.address, charCode);

      [HideFromJava]
      public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (FreeType.Face.__\u003CcallerID\u003E == null)
          FreeType.Face.__\u003CcallerID\u003E = (CallerID) new FreeType.Face.__\u003CCallerID\u003E();
        return FreeType.Face.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [Implements(new string[] {"arc.util.Disposable"})]
    public class Glyph : FreeType.Pointer, Disposable
    {
      private bool rendered;
      static IntPtr __\u003Cjniptr\u003Edone\u0028J\u0029V;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;
      static IntPtr __\u003Cjniptr\u003EstrokeBorder\u0028JJZ\u0029J;
      static IntPtr __\u003Cjniptr\u003EtoBitmap\u0028JI\u0029J;
      static IntPtr __\u003Cjniptr\u003EgetBitmap\u0028J\u0029J;
      static IntPtr __\u003Cjniptr\u003EgetLeft\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetTop\u0028J\u0029I;

      [Modifiers]
      private static void done([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Glyph.__\u003Cjniptr\u003Edone\u0028J\u0029V == IntPtr.Zero)
          FreeType.Glyph.__\u003Cjniptr\u003Edone\u0028J\u0029V = JNI.Frame.GetFuncPtr(FreeType.Glyph.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Glyph", nameof (done), "(J)V");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Glyph.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Glyph>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, IntPtr, long)>) FreeType.Glyph.__\u003Cjniptr\u003Edone\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static long strokeBorder([In] long obj0, [In] long obj1, [In] bool obj2)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Glyph.__\u003Cjniptr\u003EstrokeBorder\u0028JJZ\u0029J == IntPtr.Zero)
          FreeType.Glyph.__\u003Cjniptr\u003EstrokeBorder\u0028JJZ\u0029J = JNI.Frame.GetFuncPtr(FreeType.Glyph.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Glyph", nameof (strokeBorder), "(JJZ)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Glyph.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Glyph>.Value);
          long num4 = obj0;
          long num5 = obj1;
          int num6 = obj2 ? 1 : 0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long, long, bool)>) FreeType.Glyph.__\u003Cjniptr\u003EstrokeBorder\u0028JJZ\u0029J)((bool) num2, (long) num3, num4, (IntPtr) num5, (IntPtr) num6);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static long toBitmap([In] long obj0, [In] int obj1)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Glyph.__\u003Cjniptr\u003EtoBitmap\u0028JI\u0029J == IntPtr.Zero)
          FreeType.Glyph.__\u003Cjniptr\u003EtoBitmap\u0028JI\u0029J = JNI.Frame.GetFuncPtr(FreeType.Glyph.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Glyph", nameof (toBitmap), "(JI)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Glyph.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Glyph>.Value);
          long num4 = obj0;
          int num5 = obj1;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long, int)>) FreeType.Glyph.__\u003Cjniptr\u003EtoBitmap\u0028JI\u0029J)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static long getBitmap([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Glyph.__\u003Cjniptr\u003EgetBitmap\u0028J\u0029J == IntPtr.Zero)
          FreeType.Glyph.__\u003Cjniptr\u003EgetBitmap\u0028J\u0029J = JNI.Frame.GetFuncPtr(FreeType.Glyph.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Glyph", nameof (getBitmap), "(J)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Glyph.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Glyph>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) FreeType.Glyph.__\u003Cjniptr\u003EgetBitmap\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getLeft([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Glyph.__\u003Cjniptr\u003EgetLeft\u0028J\u0029I == IntPtr.Zero)
          FreeType.Glyph.__\u003Cjniptr\u003EgetLeft\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Glyph.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Glyph", nameof (getLeft), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Glyph.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Glyph>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Glyph.__\u003Cjniptr\u003EgetLeft\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getTop([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Glyph.__\u003Cjniptr\u003EgetTop\u0028J\u0029I == IntPtr.Zero)
          FreeType.Glyph.__\u003Cjniptr\u003EgetTop\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.Glyph.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Glyph", nameof (getTop), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Glyph.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Glyph>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.Glyph.__\u003Cjniptr\u003EgetTop\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(new byte[] {161, 123, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Glyph([In] long obj0)
        : base(obj0)
      {
      }

      [LineNumberTable(new byte[] {161, 128, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dispose() => FreeType.Glyph.done(this.address);

      [LineNumberTable(new byte[] {159, 16, 130, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void strokeBorder(FreeType.Stroker stroker, bool inside)
      {
        int num = inside ? 1 : 0;
        this.address = FreeType.Glyph.strokeBorder(this.address, stroker.address, num != 0);
      }

      [LineNumberTable(new byte[] {161, 146, 109, 127, 15, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void toBitmap(int renderMode)
      {
        long bitmap = FreeType.Glyph.toBitmap(this.address, renderMode);
        if (bitmap == 0L)
        {
          string message = new StringBuilder().append("Couldn't render glyph, FreeType error code: ").append(FreeType.getLastErrorCode()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        this.address = bitmap;
        this.rendered = true;
      }

      [LineNumberTable(new byte[] {161, 163, 104, 144})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.Bitmap getBitmap()
      {
        if (!this.rendered)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Glyph is not yet rendered");
        }
        return new FreeType.Bitmap(FreeType.Glyph.getBitmap(this.address));
      }

      [LineNumberTable(new byte[] {161, 175, 104, 144})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getLeft()
      {
        if (!this.rendered)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Glyph is not yet rendered");
        }
        return FreeType.Glyph.getLeft(this.address);
      }

      [LineNumberTable(new byte[] {161, 187, 104, 144})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getTop()
      {
        if (!this.rendered)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Glyph is not yet rendered");
        }
        return FreeType.Glyph.getTop(this.address);
      }

      [HideFromJava]
      public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (FreeType.Glyph.__\u003CcallerID\u003E == null)
          FreeType.Glyph.__\u003CcallerID\u003E = (CallerID) new FreeType.Glyph.__\u003CCallerID\u003E();
        return FreeType.Glyph.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    public class GlyphMetrics : FreeType.Pointer
    {
      static IntPtr __\u003Cjniptr\u003EgetWidth\u0028J\u0029I;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;
      static IntPtr __\u003Cjniptr\u003EgetHeight\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetHoriBearingX\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetHoriBearingY\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetHoriAdvance\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetVertBearingX\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetVertBearingY\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetVertAdvance\u0028J\u0029I;

      [Modifiers]
      private static int getWidth([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetWidth\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetWidth\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphMetrics", nameof (getWidth), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetWidth\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getHeight([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHeight\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHeight\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphMetrics", nameof (getHeight), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHeight\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getHoriBearingX([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHoriBearingX\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHoriBearingX\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphMetrics", nameof (getHoriBearingX), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHoriBearingX\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getHoriBearingY([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHoriBearingY\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHoriBearingY\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphMetrics", nameof (getHoriBearingY), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHoriBearingY\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getHoriAdvance([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHoriAdvance\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHoriAdvance\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphMetrics", nameof (getHoriAdvance), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetHoriAdvance\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getVertBearingX([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetVertBearingX\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetVertBearingX\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphMetrics", nameof (getVertBearingX), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetVertBearingX\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getVertBearingY([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetVertBearingY\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetVertBearingY\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphMetrics", nameof (getVertBearingY), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetVertBearingY\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getVertAdvance([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetVertAdvance\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetVertAdvance\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphMetrics", nameof (getVertAdvance), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphMetrics.__\u003Cjniptr\u003EgetVertAdvance\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(new byte[] {162, 73, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal GlyphMetrics([In] long obj0)
        : base(obj0)
      {
      }

      [LineNumberTable(703)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getWidth() => FreeType.GlyphMetrics.getWidth(this.address);

      [LineNumberTable(711)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getHeight() => FreeType.GlyphMetrics.getHeight(this.address);

      [LineNumberTable(719)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getHoriBearingX() => FreeType.GlyphMetrics.getHoriBearingX(this.address);

      [LineNumberTable(727)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getHoriBearingY() => FreeType.GlyphMetrics.getHoriBearingY(this.address);

      [LineNumberTable(735)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getHoriAdvance() => FreeType.GlyphMetrics.getHoriAdvance(this.address);

      [LineNumberTable(743)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getVertBearingX() => FreeType.GlyphMetrics.getVertBearingX(this.address);

      [LineNumberTable(751)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getVertBearingY() => FreeType.GlyphMetrics.getVertBearingY(this.address);

      [LineNumberTable(759)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getVertAdvance() => FreeType.GlyphMetrics.getVertAdvance(this.address);

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (FreeType.GlyphMetrics.__\u003CcallerID\u003E == null)
          FreeType.GlyphMetrics.__\u003CcallerID\u003E = (CallerID) new FreeType.GlyphMetrics.__\u003CCallerID\u003E();
        return FreeType.GlyphMetrics.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    public class GlyphSlot : FreeType.Pointer
    {
      static IntPtr __\u003Cjniptr\u003EgetMetrics\u0028J\u0029J;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;
      static IntPtr __\u003Cjniptr\u003EgetLinearHoriAdvance\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetLinearVertAdvance\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetAdvanceX\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetAdvanceY\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetFormat\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetBitmap\u0028J\u0029J;
      static IntPtr __\u003Cjniptr\u003EgetBitmapLeft\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetBitmapTop\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003ErenderGlyph\u0028JI\u0029Z;
      static IntPtr __\u003Cjniptr\u003EgetGlyph\u0028J\u0029J;

      [LineNumberTable(new byte[] {161, 18, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal GlyphSlot([In] long obj0)
        : base(obj0)
      {
      }

      [Modifiers]
      private static long getMetrics([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetMetrics\u0028J\u0029J == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetMetrics\u0028J\u0029J = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getMetrics), "(J)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetMetrics\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getLinearHoriAdvance([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetLinearHoriAdvance\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetLinearHoriAdvance\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getLinearHoriAdvance), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetLinearHoriAdvance\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getLinearVertAdvance([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetLinearVertAdvance\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetLinearVertAdvance\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getLinearVertAdvance), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetLinearVertAdvance\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getAdvanceX([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetAdvanceX\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetAdvanceX\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getAdvanceX), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetAdvanceX\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getAdvanceY([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetAdvanceY\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetAdvanceY\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getAdvanceY), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetAdvanceY\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getFormat([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetFormat\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetFormat\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getFormat), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetFormat\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static long getBitmap([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetBitmap\u0028J\u0029J == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetBitmap\u0028J\u0029J = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getBitmap), "(J)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetBitmap\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getBitmapLeft([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetBitmapLeft\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetBitmapLeft\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getBitmapLeft), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetBitmapLeft\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getBitmapTop([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetBitmapTop\u0028J\u0029I == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetBitmapTop\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getBitmapTop), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetBitmapTop\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static bool renderGlyph([In] long obj0, [In] int obj1)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003ErenderGlyph\u0028JI\u0029Z == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003ErenderGlyph\u0028JI\u0029Z = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (renderGlyph), "(JI)Z");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          int num5 = obj1;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return (bool) __calli((__FnPtr<byte (IntPtr, IntPtr, long, int)>) FreeType.GlyphSlot.__\u003Cjniptr\u003ErenderGlyph\u0028JI\u0029Z)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static long getGlyph([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.GlyphSlot.__\u003Cjniptr\u003EgetGlyph\u0028J\u0029J == IntPtr.Zero)
          FreeType.GlyphSlot.__\u003Cjniptr\u003EgetGlyph\u0028J\u0029J = JNI.Frame.GetFuncPtr(FreeType.GlyphSlot.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$GlyphSlot", nameof (getGlyph), "(J)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.GlyphSlot.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.GlyphSlot>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) FreeType.GlyphSlot.__\u003Cjniptr\u003EgetGlyph\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(392)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.GlyphMetrics getMetrics() => new FreeType.GlyphMetrics(FreeType.GlyphSlot.getMetrics(this.address));

      [LineNumberTable(400)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getLinearHoriAdvance() => FreeType.GlyphSlot.getLinearHoriAdvance(this.address);

      [LineNumberTable(408)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getLinearVertAdvance() => FreeType.GlyphSlot.getLinearVertAdvance(this.address);

      [LineNumberTable(416)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getAdvanceX() => FreeType.GlyphSlot.getAdvanceX(this.address);

      [LineNumberTable(424)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getAdvanceY() => FreeType.GlyphSlot.getAdvanceY(this.address);

      [LineNumberTable(432)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getFormat() => FreeType.GlyphSlot.getFormat(this.address);

      [LineNumberTable(440)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.Bitmap getBitmap() => new FreeType.Bitmap(FreeType.GlyphSlot.getBitmap(this.address));

      [LineNumberTable(449)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getBitmapLeft() => FreeType.GlyphSlot.getBitmapLeft(this.address);

      [LineNumberTable(457)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getBitmapTop() => FreeType.GlyphSlot.getBitmapTop(this.address);

      [LineNumberTable(465)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool renderGlyph(int renderMode) => FreeType.GlyphSlot.renderGlyph(this.address, renderMode);

      [LineNumberTable(new byte[] {161, 103, 108, 127, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.Glyph getGlyph()
      {
        long glyph = FreeType.GlyphSlot.getGlyph(this.address);
        if (glyph == 0L)
        {
          string message = new StringBuilder().append("Couldn't get glyph, FreeType error code: ").append(FreeType.getLastErrorCode()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        return new FreeType.Glyph(glyph);
      }

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (FreeType.GlyphSlot.__\u003CcallerID\u003E == null)
          FreeType.GlyphSlot.__\u003CcallerID\u003E = (CallerID) new FreeType.GlyphSlot.__\u003CCallerID\u003E();
        return FreeType.GlyphSlot.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [Implements(new string[] {"arc.util.Disposable"})]
    public class Library : FreeType.Pointer, Disposable
    {
      [Signature("Larc/struct/LongMap<Ljava/nio/ByteBuffer;>;")]
      internal LongMap fontData;
      static IntPtr __\u003Cjniptr\u003EdoneFreeType\u0028J\u0029V;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;
      static IntPtr __\u003Cjniptr\u003EnewMemoryFace\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J;
      static IntPtr __\u003Cjniptr\u003EstrokerNew\u0028J\u0029J;

      [LineNumberTable(new byte[] {159, 189, 233, 61, 203})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Library([In] long obj0)
        : base(obj0)
      {
        FreeType.Library library = this;
        this.fontData = new LongMap();
      }

      [Modifiers]
      private static void doneFreeType([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Library.__\u003Cjniptr\u003EdoneFreeType\u0028J\u0029V == IntPtr.Zero)
          FreeType.Library.__\u003Cjniptr\u003EdoneFreeType\u0028J\u0029V = JNI.Frame.GetFuncPtr(FreeType.Library.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Library", nameof (doneFreeType), "(J)V");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Library.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Library>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, IntPtr, long)>) FreeType.Library.__\u003Cjniptr\u003EdoneFreeType\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(new byte[] {19, 104, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.Face newMemoryFace(byte[] data, int dataSize, int faceIndex)
      {
        ByteBuffer buffer = Buffers.newUnsafeByteBuffer(data.Length);
        Buffers.copy(data, 0, (Buffer) buffer, data.Length);
        return this.newMemoryFace(buffer, faceIndex);
      }

      [LineNumberTable(new byte[] {25, 116, 101, 104, 102, 191, 10, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.Face newMemoryFace(ByteBuffer buffer, int faceIndex)
      {
        long num = FreeType.Library.newMemoryFace(this.address, buffer, ((Buffer) buffer).remaining(), faceIndex);
        if (num == 0L)
        {
          if (Buffers.isUnsafeByteBuffer(buffer))
            Buffers.disposeUnsafeByteBuffer(buffer);
          string message = new StringBuilder().append("Couldn't load font, FreeType error code: ").append(FreeType.getLastErrorCode()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        this.fontData.put(num, (object) buffer);
        return new FreeType.Face(num, this);
      }

      [Modifiers]
      private static long newMemoryFace([In] long obj0, [In] ByteBuffer obj1, [In] int obj2, [In] int obj3)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Library.__\u003Cjniptr\u003EnewMemoryFace\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J == IntPtr.Zero)
          FreeType.Library.__\u003Cjniptr\u003EnewMemoryFace\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J = JNI.Frame.GetFuncPtr(FreeType.Library.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Library", nameof (newMemoryFace), "(JLjava/nio/ByteBuffer;II)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Library.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Library>.Value);
          long num4 = obj0;
          IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
          int num6 = obj2;
          int num7 = obj3;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long, IntPtr, int, int)>) FreeType.Library.__\u003Cjniptr\u003EnewMemoryFace\u0028JLjava\u002Fnio\u002FByteBuffer\u003BII\u0029J)((int) num2, (int) num3, (IntPtr) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static long strokerNew([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Library.__\u003Cjniptr\u003EstrokerNew\u0028J\u0029J == IntPtr.Zero)
          FreeType.Library.__\u003Cjniptr\u003EstrokerNew\u0028J\u0029J = JNI.Frame.GetFuncPtr(FreeType.Library.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Library", nameof (strokerNew), "(J)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Library.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Library>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) FreeType.Library.__\u003Cjniptr\u003EstrokerNew\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(new byte[] {2, 107, 127, 6, 104, 102, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dispose()
      {
        FreeType.Library.doneFreeType(this.address);
        Iterator iterator = this.fontData.values().iterator();
        while (iterator.hasNext())
        {
          ByteBuffer buffer = (ByteBuffer) iterator.next();
          if (Buffers.isUnsafeByteBuffer(buffer))
            Buffers.disposeUnsafeByteBuffer(buffer);
        }
      }

      [LineNumberTable(new byte[] {14, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.Face newFace(Fi font, int faceIndex)
      {
        byte[] data = font.readBytes();
        return this.newMemoryFace(data, data.Length, faceIndex);
      }

      [LineNumberTable(new byte[] {48, 108, 127, 15})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.Stroker createStroker()
      {
        long num = FreeType.Library.strokerNew(this.address);
        if (num == 0L)
        {
          string message = new StringBuilder().append("Couldn't create FreeType stroker, FreeType error code: ").append(FreeType.getLastErrorCode()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        return new FreeType.Stroker(num);
      }

      [HideFromJava]
      public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (FreeType.Library.__\u003CcallerID\u003E == null)
          FreeType.Library.__\u003CcallerID\u003E = (CallerID) new FreeType.Library.__\u003CCallerID\u003E();
        return FreeType.Library.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [InnerClass]
    internal class Pointer : Object
    {
      internal long address;

      [LineNumberTable(new byte[] {159, 180, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Pointer([In] long obj0)
      {
        FreeType.Pointer pointer = this;
        this.address = obj0;
      }
    }

    public class Size : FreeType.Pointer
    {
      static IntPtr __\u003Cjniptr\u003EgetMetrics\u0028J\u0029J;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;

      [LineNumberTable(new byte[] {160, 190, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Size([In] long obj0)
        : base(obj0)
      {
      }

      [Modifiers]
      private static long getMetrics([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Size.__\u003Cjniptr\u003EgetMetrics\u0028J\u0029J == IntPtr.Zero)
          FreeType.Size.__\u003Cjniptr\u003EgetMetrics\u0028J\u0029J = JNI.Frame.GetFuncPtr(FreeType.Size.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Size", nameof (getMetrics), "(J)J");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Size.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Size>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<long (IntPtr, IntPtr, long)>) FreeType.Size.__\u003Cjniptr\u003EgetMetrics\u0028J\u0029J)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(308)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual FreeType.SizeMetrics getMetrics() => new FreeType.SizeMetrics(FreeType.Size.getMetrics(this.address));

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (FreeType.Size.__\u003CcallerID\u003E == null)
          FreeType.Size.__\u003CcallerID\u003E = (CallerID) new FreeType.Size.__\u003CCallerID\u003E();
        return FreeType.Size.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    public class SizeMetrics : FreeType.Pointer
    {
      static IntPtr __\u003Cjniptr\u003EgetXppem\u0028J\u0029I;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;
      static IntPtr __\u003Cjniptr\u003EgetYppem\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetXscale\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetYscale\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetAscender\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetDescender\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetHeight\u0028J\u0029I;
      static IntPtr __\u003Cjniptr\u003EgetMaxAdvance\u0028J\u0029I;

      [LineNumberTable(new byte[] {160, 204, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal SizeMetrics([In] long obj0)
        : base(obj0)
      {
      }

      [Modifiers]
      private static int getXppem([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.SizeMetrics.__\u003Cjniptr\u003EgetXppem\u0028J\u0029I == IntPtr.Zero)
          FreeType.SizeMetrics.__\u003Cjniptr\u003EgetXppem\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.SizeMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$SizeMetrics", nameof (getXppem), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.SizeMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.SizeMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.SizeMetrics.__\u003Cjniptr\u003EgetXppem\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getYppem([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.SizeMetrics.__\u003Cjniptr\u003EgetYppem\u0028J\u0029I == IntPtr.Zero)
          FreeType.SizeMetrics.__\u003Cjniptr\u003EgetYppem\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.SizeMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$SizeMetrics", nameof (getYppem), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.SizeMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.SizeMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.SizeMetrics.__\u003Cjniptr\u003EgetYppem\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getXscale([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.SizeMetrics.__\u003Cjniptr\u003EgetXscale\u0028J\u0029I == IntPtr.Zero)
          FreeType.SizeMetrics.__\u003Cjniptr\u003EgetXscale\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.SizeMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$SizeMetrics", nameof (getXscale), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.SizeMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.SizeMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.SizeMetrics.__\u003Cjniptr\u003EgetXscale\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getYscale([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.SizeMetrics.__\u003Cjniptr\u003EgetYscale\u0028J\u0029I == IntPtr.Zero)
          FreeType.SizeMetrics.__\u003Cjniptr\u003EgetYscale\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.SizeMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$SizeMetrics", nameof (getYscale), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.SizeMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.SizeMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.SizeMetrics.__\u003Cjniptr\u003EgetYscale\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getAscender([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.SizeMetrics.__\u003Cjniptr\u003EgetAscender\u0028J\u0029I == IntPtr.Zero)
          FreeType.SizeMetrics.__\u003Cjniptr\u003EgetAscender\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.SizeMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$SizeMetrics", nameof (getAscender), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.SizeMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.SizeMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.SizeMetrics.__\u003Cjniptr\u003EgetAscender\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getDescender([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.SizeMetrics.__\u003Cjniptr\u003EgetDescender\u0028J\u0029I == IntPtr.Zero)
          FreeType.SizeMetrics.__\u003Cjniptr\u003EgetDescender\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.SizeMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$SizeMetrics", nameof (getDescender), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.SizeMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.SizeMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.SizeMetrics.__\u003Cjniptr\u003EgetDescender\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getHeight([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.SizeMetrics.__\u003Cjniptr\u003EgetHeight\u0028J\u0029I == IntPtr.Zero)
          FreeType.SizeMetrics.__\u003Cjniptr\u003EgetHeight\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.SizeMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$SizeMetrics", nameof (getHeight), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.SizeMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.SizeMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.SizeMetrics.__\u003Cjniptr\u003EgetHeight\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static int getMaxAdvance([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.SizeMetrics.__\u003Cjniptr\u003EgetMaxAdvance\u0028J\u0029I == IntPtr.Zero)
          FreeType.SizeMetrics.__\u003Cjniptr\u003EgetMaxAdvance\u0028J\u0029I = JNI.Frame.GetFuncPtr(FreeType.SizeMetrics.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$SizeMetrics", nameof (getMaxAdvance), "(J)I");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.SizeMetrics.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.SizeMetrics>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          return __calli((__FnPtr<int (IntPtr, IntPtr, long)>) FreeType.SizeMetrics.__\u003Cjniptr\u003EgetMaxAdvance\u0028J\u0029I)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(322)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getXppem() => FreeType.SizeMetrics.getXppem(this.address);

      [LineNumberTable(330)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getYppem() => FreeType.SizeMetrics.getYppem(this.address);

      [LineNumberTable(338)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getXScale() => FreeType.SizeMetrics.getXscale(this.address);

      [LineNumberTable(346)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getYscale() => FreeType.SizeMetrics.getYscale(this.address);

      [LineNumberTable(354)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getAscender() => FreeType.SizeMetrics.getAscender(this.address);

      [LineNumberTable(362)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getDescender() => FreeType.SizeMetrics.getDescender(this.address);

      [LineNumberTable(370)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getHeight() => FreeType.SizeMetrics.getHeight(this.address);

      [LineNumberTable(378)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int getMaxAdvance() => FreeType.SizeMetrics.getMaxAdvance(this.address);

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (FreeType.SizeMetrics.__\u003CcallerID\u003E == null)
          FreeType.SizeMetrics.__\u003CcallerID\u003E = (CallerID) new FreeType.SizeMetrics.__\u003CCallerID\u003E();
        return FreeType.SizeMetrics.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    [Implements(new string[] {"arc.util.Disposable"})]
    public class Stroker : FreeType.Pointer, Disposable
    {
      static IntPtr __\u003Cjniptr\u003Eset\u0028JIIII\u0029V;
      [SpecialName]
      private static CallerID __\u003CcallerID\u003E;
      static IntPtr __\u003Cjniptr\u003Edone\u0028J\u0029V;

      [LineNumberTable(new byte[] {162, 143, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Stroker([In] long obj0)
        : base(obj0)
      {
      }

      [Modifiers]
      private static void set([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Stroker.__\u003Cjniptr\u003Eset\u0028JIIII\u0029V == IntPtr.Zero)
          FreeType.Stroker.__\u003Cjniptr\u003Eset\u0028JIIII\u0029V = JNI.Frame.GetFuncPtr(FreeType.Stroker.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Stroker", nameof (set), "(JIIII)V");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Stroker.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Stroker>.Value);
          long num4 = obj0;
          int num5 = obj1;
          int num6 = obj2;
          int num7 = obj3;
          int num8 = obj4;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int, int, int)>) FreeType.Stroker.__\u003Cjniptr\u003Eset\u0028JIIII\u0029V)((int) num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [Modifiers]
      private static void done([In] long obj0)
      {
        JNI.Frame frame = new JNI.Frame();
        if (FreeType.Stroker.__\u003Cjniptr\u003Edone\u0028J\u0029V == IntPtr.Zero)
          FreeType.Stroker.__\u003Cjniptr\u003Edone\u0028J\u0029V = JNI.Frame.GetFuncPtr(FreeType.Stroker.__\u003CGetCallerID\u003E(), "arc/freetype/FreeType$Stroker", nameof (done), "(J)V");
        IntPtr num1 = ((JNI.Frame) ref frame).Enter(FreeType.Stroker.__\u003CGetCallerID\u003E());
        try
        {
          IntPtr num2 = num1;
          IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<FreeType.Stroker>.Value);
          long num4 = obj0;
          // ISSUE: cast to a function pointer type
          // ISSUE: function pointer call
          __calli((__FnPtr<void (IntPtr, IntPtr, long)>) FreeType.Stroker.__\u003Cjniptr\u003Edone\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
        }
        catch (object ex)
        {
          Console.WriteLine((object) "*** exception in native code ***");
          Console.WriteLine(ex);
          throw;
        }
        finally
        {
          ((JNI.Frame) ref frame).Leave();
        }
      }

      [LineNumberTable(new byte[] {162, 147, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(int radius, int lineCap, int lineJoin, int miterLimit) => FreeType.Stroker.set(this.address, radius, lineCap, lineJoin, miterLimit);

      [LineNumberTable(new byte[] {162, 156, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dispose() => FreeType.Stroker.done(this.address);

      [HideFromJava]
      public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

      static CallerID __\u003CGetCallerID\u003E()
      {
        if (FreeType.Stroker.__\u003CcallerID\u003E == null)
          FreeType.Stroker.__\u003CcallerID\u003E = (CallerID) new FreeType.Stroker.__\u003CCallerID\u003E();
        return FreeType.Stroker.__\u003CcallerID\u003E;
      }

      private sealed class __\u003CCallerID\u003E : CallerID
      {
        internal __\u003CCallerID\u003E()
        {
        }
      }
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
