// Decompiled with JetBrains decompiler
// Type: arc.graphics.Pixmap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.func;
using arc.graphics.g2d;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public class Pixmap : Object, Disposable
  {
    internal const int pixmapFormatAlpha = 1;
    internal const int pixmapFormatLuminanceAlpha = 2;
    internal const int pixmapFormatRGB888 = 3;
    internal const int pixmapFormatRGBA8888 = 4;
    internal const int pixmapFormatRGB565 = 5;
    internal const int pixmapFormatRGBA4444 = 6;
    internal const int pixmapScaleNearest = 0;
    internal const int pixmapScaleLinear = 1;
    [Modifiers]
    internal Pixmap.NativePixmap pixmap;
    internal int color;
    private Pixmap.Blending blending;
    private Pixmap.PixmapFilter filter;
    private bool disposed;
    static IntPtr __\u003Cjniptr\u003Eload\u0028\u005BJ\u005BBII\u0029Ljava\u002Fnio\u002FByteBuffer\u003B;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;
    static IntPtr __\u003Cjniptr\u003EnewPixmap\u0028\u005BJIII\u0029Ljava\u002Fnio\u002FByteBuffer\u003B;
    static IntPtr __\u003Cjniptr\u003Efree\u0028J\u0029V;
    static IntPtr __\u003Cjniptr\u003Eclear\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetPixel\u0028JIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetPixel\u0028JII\u0029I;
    static IntPtr __\u003Cjniptr\u003EdrawLine\u0028JIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EdrawRect\u0028JIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EdrawCircle\u0028JIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EfillRect\u0028JIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EfillCircle\u0028JIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EfillTriangle\u0028JIIIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EdrawPixmap\u0028JJIIIIIIII\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetBlend\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EsetScale\u0028JI\u0029V;
    static IntPtr __\u003Cjniptr\u003EgetFailureReason\u0028\u0029Ljava\u002Flang\u002FString\u003B;

    [LineNumberTable(new byte[] {159, 185, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pixmap(int width, int height)
      : this(width, height, Pixmap.Format.__\u003C\u003Ergba8888)
    {
    }

    [LineNumberTable(new byte[] {160, 197, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(int x, int y, Color color) => this.draw(x, y, color.rgba());

    [LineNumberTable(new byte[] {160, 74, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPixmap(Pixmap pixmap) => this.drawPixmap(pixmap, 0, 0);

    [LineNumberTable(new byte[] {118, 127, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(PixmapRegion region) => this.drawPixmap(region.pixmap, region.x, region.y, region.width, region.height, 0, 0, region.width, region.height);

    [LineNumberTable(290)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getWidth() => this.pixmap.width;

    [LineNumberTable(295)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getHeight() => this.pixmap.height;

    [LineNumberTable(new byte[] {38, 232, 12, 103, 107, 235, 116, 103, 191, 8, 2, 97, 159, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pixmap(Fi file)
    {
      Pixmap pixmap = this;
      this.color = 0;
      this.blending = Pixmap.Blending.__\u003C\u003EsourceOver;
      this.filter = Pixmap.PixmapFilter.__\u003C\u003Ebilinear;
      Exception exception1;
      try
      {
        byte[] numArray = file.readBytes();
        this.pixmap = new Pixmap.NativePixmap(numArray, 0, numArray.Length, 0);
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      string message = new StringBuilder().append("Couldn't load file: ").append((object) file).toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message, (Exception) exception3);
    }

    [LineNumberTable(285)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getPixel(int x, int y) => Pixmap.getPixel(this.pixmap.basePtr, x, y);

    [LineNumberTable(new byte[] {160, 186, 120, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      if (this.disposed)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Pixmap already disposed!");
      }
      Pixmap.free(this.pixmap.basePtr);
      this.disposed = true;
    }

    [LineNumberTable(new byte[] {2, 232, 48, 103, 107, 235, 79, 115, 122, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pixmap(int width, int height, Pixmap.Format format)
    {
      Pixmap pixmap = this;
      this.color = 0;
      this.blending = Pixmap.Blending.__\u003C\u003EsourceOver;
      this.filter = Pixmap.PixmapFilter.__\u003C\u003Ebilinear;
      this.pixmap = new Pixmap.NativePixmap(width, height, format.toPixmapFormat());
      this.setColor(0.0f, 0.0f, 0.0f, 0.0f);
      this.fill();
    }

    [LineNumberTable(new byte[] {160, 254, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ByteBuffer getPixels()
    {
      if (this.disposed)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Pixmap already disposed");
      }
      return this.pixmap.pixelPtr;
    }

    [LineNumberTable(new byte[] {55, 107, 107, 40, 38, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void each(Intc2 cons)
    {
      for (int i1 = 0; i1 < this.getWidth(); ++i1)
      {
        for (int i2 = 0; i2 < this.getHeight(); ++i2)
          cons.get(i1, i2);
      }
    }

    [LineNumberTable(new byte[] {160, 216, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(int x, int y, int color) => Pixmap.setPixel(this.pixmap.basePtr, x, y, color);

    [LineNumberTable(new byte[] {160, 84, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPixmap(Pixmap pixmap, int x, int y) => this.drawPixmap(pixmap, x, y, 0, 0, pixmap.getWidth(), pixmap.getHeight());

    [LineNumberTable(new byte[] {21, 232, 29, 103, 107, 235, 99, 191, 2, 2, 97, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pixmap(byte[] encodedData, int offset, int len)
    {
      Pixmap pixmap = this;
      this.color = 0;
      this.blending = Pixmap.Blending.__\u003C\u003EsourceOver;
      this.filter = Pixmap.PixmapFilter.__\u003C\u003Ebilinear;
      IOException ioException1;
      try
      {
        this.pixmap = new Pixmap.NativePixmap(encodedData, offset, len, 0);
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("Couldn't load pixmap from image data", (Exception) ioException2);
    }

    [LineNumberTable(new byte[] {12, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pixmap(byte[] encodedData)
      : this(encodedData, 0, encodedData.Length)
    {
    }

    [LineNumberTable(new byte[] {86, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(Color color) => this.color = Color.rgba8888(color.r, color.g, color.b, color.a);

    [LineNumberTable(374)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.Format getFormat() => Pixmap.Format.fromPixmapFormat(this.pixmap.format);

    [LineNumberTable(new byte[] {161, 17, 103, 114, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setBlending(Pixmap.Blending blending)
    {
      this.blending = blending;
      Pixmap.setBlend(this.pixmap.basePtr, !object.ReferenceEquals((object) blending, (object) Pixmap.Blending.__\u003C\u003Enone) ? 1 : 0);
    }

    [LineNumberTable(new byte[] {160, 98, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPixmap(
      Pixmap pixmap,
      int x,
      int y,
      int srcx,
      int srcy,
      int srcWidth,
      int srcHeight)
    {
      Pixmap.drawPixmap(pixmap.pixmap.basePtr, this.pixmap.basePtr, srcx, srcy, srcWidth, srcHeight, x, y, srcWidth, srcHeight);
    }

    [LineNumberTable(348)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getGLInternalFormat() => Pixmap.toGlFormat(this.pixmap.format);

    [LineNumberTable(339)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getGLFormat() => Pixmap.toGlFormat(this.pixmap.format);

    [LineNumberTable(357)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getGLType() => Pixmap.toGlType(this.pixmap.format);

    [LineNumberTable(new byte[] {78, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(float r, float g, float b, float a) => this.color = Color.rgba8888(r, g, b, a);

    [LineNumberTable(new byte[] {91, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fill() => Pixmap.clear(this.pixmap.basePtr, this.color);

    [Modifiers]
    private static void clear([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003Eclear\u0028JI\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003Eclear\u0028JI\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (clear), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) Pixmap.__\u003Cjniptr\u003Eclear\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void drawLine([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EdrawLine\u0028JIIIII\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EdrawLine\u0028JIIIII\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (drawLine), "(JIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int, int, int, int)>) Pixmap.__\u003Cjniptr\u003EdrawLine\u0028JIIIII\u0029V)((int) num2, (int) num3, (int) num4, num5, num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
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
    private static void drawRect([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EdrawRect\u0028JIIIII\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EdrawRect\u0028JIIIII\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (drawRect), "(JIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int, int, int, int)>) Pixmap.__\u003Cjniptr\u003EdrawRect\u0028JIIIII\u0029V)((int) num2, (int) num3, (int) num4, num5, num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
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

    [LineNumberTable(new byte[] {160, 116, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawPixmap(
      Pixmap pixmap,
      int srcx,
      int srcy,
      int srcWidth,
      int srcHeight,
      int dstx,
      int dsty,
      int dstWidth,
      int dstHeight)
    {
      Pixmap.drawPixmap(pixmap.pixmap.basePtr, this.pixmap.basePtr, srcx, srcy, srcWidth, srcHeight, dstx, dsty, dstWidth, dstHeight);
    }

    [Modifiers]
    internal static void drawPixmap(
      [In] long obj0,
      [In] long obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7,
      [In] int obj8,
      [In] int obj9)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EdrawPixmap\u0028JJIIIIIIII\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EdrawPixmap\u0028JJIIIIIIII\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (drawPixmap), "(JJIIIIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        long num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        int num10 = obj6;
        int num11 = obj7;
        int num12 = obj8;
        int num13 = obj9;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, long, int, int, int, int, int, int, int, int)>) Pixmap.__\u003Cjniptr\u003EdrawPixmap\u0028JJIIIIIIII\u0029V)((int) num2, (int) num3, (int) num4, (int) num5, num6, num7, num8, num9, (long) num10, (long) num11, (IntPtr) num12, (IntPtr) num13);
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
    private static void fillRect([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4, [In] int obj5)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EfillRect\u0028JIIIII\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EfillRect\u0028JIIIII\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (fillRect), "(JIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int, int, int, int)>) Pixmap.__\u003Cjniptr\u003EfillRect\u0028JIIIII\u0029V)((int) num2, (int) num3, (int) num4, num5, num6, (long) num7, (IntPtr) num8, (IntPtr) num9);
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
    private static void drawCircle([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EdrawCircle\u0028JIIII\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EdrawCircle\u0028JIIII\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (drawCircle), "(JIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int, int, int)>) Pixmap.__\u003Cjniptr\u003EdrawCircle\u0028JIIII\u0029V)((int) num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static void fillCircle([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] int obj4)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EfillCircle\u0028JIIII\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EfillCircle\u0028JIIII\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (fillCircle), "(JIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int, int, int)>) Pixmap.__\u003Cjniptr\u003EfillCircle\u0028JIIII\u0029V)((int) num2, (int) num3, (int) num4, num5, (long) num6, (IntPtr) num7, (IntPtr) num8);
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
    private static void fillTriangle(
      [In] long obj0,
      [In] int obj1,
      [In] int obj2,
      [In] int obj3,
      [In] int obj4,
      [In] int obj5,
      [In] int obj6,
      [In] int obj7)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EfillTriangle\u0028JIIIIIII\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EfillTriangle\u0028JIIIIIII\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (fillTriangle), "(JIIIIIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        int num8 = obj4;
        int num9 = obj5;
        int num10 = obj6;
        int num11 = obj7;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int, int, int, int, int, int)>) Pixmap.__\u003Cjniptr\u003EfillTriangle\u0028JIIIIIII\u0029V)((int) num2, (int) num3, (int) num4, num5, num6, num7, num8, (long) num9, (IntPtr) num10, (IntPtr) num11);
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
    private static int getPixel([In] long obj0, [In] int obj1, [In] int obj2)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EgetPixel\u0028JII\u0029I == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EgetPixel\u0028JII\u0029I = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (getPixel), "(JII)I");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        return __calli((__FnPtr<int (IntPtr, IntPtr, long, int, int)>) Pixmap.__\u003Cjniptr\u003EgetPixel\u0028JII\u0029I)((int) num2, (int) num3, num4, (IntPtr) num5, (IntPtr) num6);
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
    internal static void free([In] long obj0)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003Efree\u0028J\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003Efree\u0028J\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (free), "(J)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long)>) Pixmap.__\u003Cjniptr\u003Efree\u0028J\u0029V)((long) num2, num3, (IntPtr) num4);
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
    private static void setPixel([In] long obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EsetPixel\u0028JIII\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EsetPixel\u0028JIII\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (setPixel), "(JIII)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int, int, int)>) Pixmap.__\u003Cjniptr\u003EsetPixel\u0028JIII\u0029V)((int) num2, (int) num3, (int) num4, (long) num5, (IntPtr) num6, (IntPtr) num7);
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

    [LineNumberTable(new byte[] {161, 80, 127, 3, 102, 134, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toGlFormat(int format)
    {
      switch (format)
      {
        case 1:
          return 6406;
        case 2:
          return 6410;
        case 3:
        case 5:
          return 6407;
        case 4:
        case 6:
          return 6408;
        default:
          string message = new StringBuilder().append("unknown format: ").append(format).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
      }
    }

    [LineNumberTable(new byte[] {161, 92, 223, 3, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int toGlType(int format)
    {
      switch (format)
      {
        case 1:
        case 2:
        case 3:
        case 4:
          return 5121;
        case 5:
          return 33635;
        case 6:
          return 32819;
        default:
          string message = new StringBuilder().append("unknown format: ").append(format).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
      }
    }

    [Modifiers]
    private static void setBlend([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EsetBlend\u0028JI\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EsetBlend\u0028JI\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (setBlend), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) Pixmap.__\u003Cjniptr\u003EsetBlend\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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
    private static void setScale([In] long obj0, [In] int obj1)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EsetScale\u0028JI\u0029V == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EsetScale\u0028JI\u0029V = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (setScale), "(JI)V");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        long num4 = obj0;
        int num5 = obj1;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        __calli((__FnPtr<void (IntPtr, IntPtr, long, int)>) Pixmap.__\u003Cjniptr\u003EsetScale\u0028JI\u0029V)((int) num2, (long) num3, (IntPtr) num4, (IntPtr) num5);
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

    [LineNumberTable(new byte[] {30, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pixmap(string file)
      : this(Core.files.@internal(file))
    {
    }

    [LineNumberTable(new byte[] {50, 232, 0, 103, 107, 235, 127, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Pixmap(Pixmap.NativePixmap pixmap)
    {
      Pixmap pixmap1 = this;
      this.color = 0;
      this.blending = Pixmap.Blending.__\u003C\u003EsourceOver;
      this.filter = Pixmap.PixmapFilter.__\u003C\u003Ebilinear;
      this.pixmap = pixmap;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(int color) => this.color = color;

    [LineNumberTable(new byte[] {102, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLine(int x, int y, int x2, int y2) => Pixmap.drawLine(this.pixmap.basePtr, x, y, x2, y2, this.color);

    [LineNumberTable(new byte[] {114, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawRectangle(int x, int y, int width, int height) => Pixmap.drawRect(this.pixmap.basePtr, x, y, width, height, this.color);

    [LineNumberTable(new byte[] {122, 127, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(PixmapRegion region, int x, int y) => this.drawPixmap(region.pixmap, region.x, region.y, region.width, region.height, x, y, region.width, region.height);

    [LineNumberTable(new byte[] {126, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(PixmapRegion region, int x, int y, int width, int height) => this.drawPixmap(region.pixmap, region.x, region.y, region.width, region.height, x, y, width, height);

    [LineNumberTable(new byte[] {160, 66, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(
      PixmapRegion region,
      int x,
      int y,
      int srcx,
      int srcy,
      int srcWidth,
      int srcHeight)
    {
      this.drawPixmap(region.pixmap, x, y, region.x + srcx, region.y + srcy, srcWidth, srcHeight);
    }

    [LineNumberTable(new byte[] {160, 70, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(
      PixmapRegion region,
      int srcx,
      int srcy,
      int srcWidth,
      int srcHeight,
      int dstx,
      int dsty,
      int dstWidth,
      int dstHeight)
    {
      this.drawPixmap(region.pixmap, region.x + srcx, region.y + srcy, srcWidth, srcHeight, dstx, dsty, dstWidth, dstHeight);
    }

    [LineNumberTable(new byte[] {160, 128, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fillRectangle(int x, int y, int width, int height) => Pixmap.fillRect(this.pixmap.basePtr, x, y, width, height, this.color);

    [LineNumberTable(new byte[] {160, 138, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawCircle(int x, int y, int radius) => Pixmap.drawCircle(this.pixmap.basePtr, x, y, radius, this.color);

    [LineNumberTable(new byte[] {160, 148, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fillCircle(int x, int y, int radius) => Pixmap.fillCircle(this.pixmap.basePtr, x, y, radius, this.color);

    [LineNumberTable(new byte[] {160, 161, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fillTriangle(int x1, int y1, int x2, int y2, int x3, int y3) => Pixmap.fillTriangle(this.pixmap.basePtr, x1, y1, x2, y2, x3, y3, this.color);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDisposed() => this.disposed;

    [LineNumberTable(new byte[] {160, 206, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(int x, int y) => Pixmap.setPixel(this.pixmap.basePtr, x, y, this.color);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.Blending getBlending() => this.blending;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap.PixmapFilter getFilter() => this.filter;

    [LineNumberTable(new byte[] {161, 33, 103, 114, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFilter(Pixmap.PixmapFilter filter)
    {
      this.filter = filter;
      Pixmap.setScale(this.pixmap.basePtr, !object.ReferenceEquals((object) filter, (object) Pixmap.PixmapFilter.__\u003C\u003EnearestNeighbour) ? 1 : 0);
    }

    [Modifiers]
    internal static ByteBuffer load([In] long[] obj0, [In] byte[] obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003Eload\u0028\u005BJ\u005BBII\u0029Ljava\u002Fnio\u002FByteBuffer\u003B == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003Eload\u0028\u005BJ\u005BBII\u0029Ljava\u002Fnio\u002FByteBuffer\u003B = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (load), "([J[BII)Ljava/nio/ByteBuffer;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        IntPtr num5 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj1);
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num8 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, IntPtr, IntPtr, int, int)>) Pixmap.__\u003Cjniptr\u003Eload\u0028\u005BJ\u005BBII\u0029Ljava\u002Fnio\u002FByteBuffer\u003B)((int) num2, (int) num3, num4, num5, (IntPtr) num6, (IntPtr) num7);
        return (ByteBuffer) ((JNI.Frame) ref local).UnwrapLocalRef(num8);
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
    internal static ByteBuffer newPixmap([In] long[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EnewPixmap\u0028\u005BJIII\u0029Ljava\u002Fnio\u002FByteBuffer\u003B == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EnewPixmap\u0028\u005BJIII\u0029Ljava\u002Fnio\u002FByteBuffer\u003B = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (newPixmap), "([JIII)Ljava/nio/ByteBuffer;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        IntPtr num4 = ((JNI.Frame) ref frame).MakeLocalRef((object) obj0);
        int num5 = obj1;
        int num6 = obj2;
        int num7 = obj3;
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num8 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr, IntPtr, int, int, int)>) Pixmap.__\u003Cjniptr\u003EnewPixmap\u0028\u005BJIII\u0029Ljava\u002Fnio\u002FByteBuffer\u003B)((int) num2, (int) num3, (int) num4, (IntPtr) num5, (IntPtr) num6, (IntPtr) num7);
        return (ByteBuffer) ((JNI.Frame) ref local).UnwrapLocalRef(num8);
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
    public static string getFailureReason()
    {
      JNI.Frame frame = new JNI.Frame();
      if (Pixmap.__\u003Cjniptr\u003EgetFailureReason\u0028\u0029Ljava\u002Flang\u002FString\u003B == IntPtr.Zero)
        Pixmap.__\u003Cjniptr\u003EgetFailureReason\u0028\u0029Ljava\u002Flang\u002FString\u003B = JNI.Frame.GetFuncPtr(Pixmap.__\u003CGetCallerID\u003E(), "arc/graphics/Pixmap", nameof (getFailureReason), "()Ljava/lang/String;");
      IntPtr num1 = ((JNI.Frame) ref frame).Enter(Pixmap.__\u003CGetCallerID\u003E());
      try
      {
        ref JNI.Frame local = ref frame;
        IntPtr num2 = num1;
        IntPtr num3 = ((JNI.Frame) ref frame).MakeLocalRef((object) ClassLiteral<Pixmap>.Value);
        // ISSUE: cast to a function pointer type
        // ISSUE: function pointer call
        IntPtr num4 = __calli((__FnPtr<IntPtr (IntPtr, IntPtr)>) Pixmap.__\u003Cjniptr\u003EgetFailureReason\u0028\u0029Ljava\u002Flang\u002FString\u003B)(num2, num3);
        return (string) ((JNI.Frame) ref local).UnwrapLocalRef(num4);
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

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Pixmap.__\u003CcallerID\u003E == null)
        Pixmap.__\u003CcallerID\u003E = (CallerID) new Pixmap.__\u003CCallerID\u003E();
      return Pixmap.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    [NameSig("<init>", "(Larc.graphics.Pixmap$NativePixmap;)V")]
    public Pixmap([In] object obj0)
      : this((Pixmap.NativePixmap) obj0)
    {
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(416)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.Pixmap$1"))
          return;
        Pixmap.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format = new int[Pixmap.Format.values().Length];
        try
        {
          Pixmap.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format[Pixmap.Format.__\u003C\u003Ealpha.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          Pixmap.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format[Pixmap.Format.__\u003C\u003Eintensity.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          Pixmap.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format[Pixmap.Format.__\u003C\u003EluminanceAlpha.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          Pixmap.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format[Pixmap.Format.__\u003C\u003Ergb565.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          Pixmap.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format[Pixmap.Format.__\u003C\u003Ergba4444.ordinal()] = 5;
          goto label_22;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_22:
        try
        {
          Pixmap.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format[Pixmap.Format.__\u003C\u003Ergb888.ordinal()] = 6;
          goto label_26;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_26:
        try
        {
          Pixmap.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format[Pixmap.Format.__\u003C\u003Ergba8888.ordinal()] = 7;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/graphics/Pixmap$Blending;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Blending : Enum
    {
      [Modifiers]
      internal static Pixmap.Blending __\u003C\u003Enone;
      [Modifiers]
      internal static Pixmap.Blending __\u003C\u003EsourceOver;
      [Modifiers]
      private static Pixmap.Blending[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(477)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Blending([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(477)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Pixmap.Blending[] values() => (Pixmap.Blending[]) Pixmap.Blending.\u0024VALUES.Clone();

      [LineNumberTable(477)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Pixmap.Blending valueOf(string name) => (Pixmap.Blending) Enum.valueOf((Class) ClassLiteral<Pixmap.Blending>.Value, name);

      [LineNumberTable(new byte[] {159, 23, 141, 63, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Blending()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.Pixmap$Blending"))
          return;
        Pixmap.Blending.__\u003C\u003Enone = new Pixmap.Blending(nameof (none), 0);
        Pixmap.Blending.__\u003C\u003EsourceOver = new Pixmap.Blending(nameof (sourceOver), 1);
        Pixmap.Blending.\u0024VALUES = new Pixmap.Blending[2]
        {
          Pixmap.Blending.__\u003C\u003Enone,
          Pixmap.Blending.__\u003C\u003EsourceOver
        };
      }

      [Modifiers]
      public static Pixmap.Blending none
      {
        [HideFromJava] get => Pixmap.Blending.__\u003C\u003Enone;
      }

      [Modifiers]
      public static Pixmap.Blending sourceOver
      {
        [HideFromJava] get => Pixmap.Blending.__\u003C\u003EsourceOver;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        none,
        sourceOver,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/graphics/Pixmap$Format;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Format : Enum
    {
      [Modifiers]
      internal static Pixmap.Format __\u003C\u003Ealpha;
      [Modifiers]
      internal static Pixmap.Format __\u003C\u003Eintensity;
      [Modifiers]
      internal static Pixmap.Format __\u003C\u003EluminanceAlpha;
      [Modifiers]
      internal static Pixmap.Format __\u003C\u003Ergb565;
      [Modifiers]
      internal static Pixmap.Format __\u003C\u003Ergba4444;
      [Modifiers]
      internal static Pixmap.Format __\u003C\u003Ergb888;
      [Modifiers]
      internal static Pixmap.Format __\u003C\u003Ergba8888;
      [Modifiers]
      private static Pixmap.Format[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(412)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Pixmap.Format[] values() => (Pixmap.Format[]) Pixmap.Format.\u0024VALUES.Clone();

      [LineNumberTable(new byte[] {161, 46, 159, 18, 98, 98, 98, 98, 98, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int toPixmapFormat()
      {
        switch (Pixmap.\u0031.\u0024SwitchMap\u0024arc\u0024graphics\u0024Pixmap\u0024Format[this.ordinal()])
        {
          case 1:
          case 2:
            return 1;
          case 3:
            return 2;
          case 4:
            return 5;
          case 5:
            return 6;
          case 6:
            return 3;
          case 7:
            return 4;
          default:
            string message = new StringBuilder().append("Unknown Format: ").append((object) this).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException(message);
        }
      }

      [LineNumberTable(new byte[] {161, 59, 127, 3, 102, 102, 102, 102, 102, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Pixmap.Format fromPixmapFormat(int format)
      {
        switch (format)
        {
          case 1:
            return Pixmap.Format.__\u003C\u003Ealpha;
          case 2:
            return Pixmap.Format.__\u003C\u003EluminanceAlpha;
          case 3:
            return Pixmap.Format.__\u003C\u003Ergb888;
          case 4:
            return Pixmap.Format.__\u003C\u003Ergba8888;
          case 5:
            return Pixmap.Format.__\u003C\u003Ergb565;
          case 6:
            return Pixmap.Format.__\u003C\u003Ergba4444;
          default:
            string message = new StringBuilder().append("Unknown Pixmap Format: ").append(format).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException(message);
        }
      }

      [Signature("()V")]
      [LineNumberTable(412)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Format([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(412)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Pixmap.Format valueOf(string name) => (Pixmap.Format) Enum.valueOf((Class) ClassLiteral<Pixmap.Format>.Value, name);

      [LineNumberTable(441)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int toGlFormat() => Pixmap.toGlFormat(this.toPixmapFormat());

      [LineNumberTable(445)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int toGlType() => Pixmap.toGlType(this.toPixmapFormat());

      [LineNumberTable(new byte[] {159, 39, 109, 63, 81})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Format()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.Pixmap$Format"))
          return;
        Pixmap.Format.__\u003C\u003Ealpha = new Pixmap.Format(nameof (alpha), 0);
        Pixmap.Format.__\u003C\u003Eintensity = new Pixmap.Format(nameof (intensity), 1);
        Pixmap.Format.__\u003C\u003EluminanceAlpha = new Pixmap.Format(nameof (luminanceAlpha), 2);
        Pixmap.Format.__\u003C\u003Ergb565 = new Pixmap.Format(nameof (rgb565), 3);
        Pixmap.Format.__\u003C\u003Ergba4444 = new Pixmap.Format(nameof (rgba4444), 4);
        Pixmap.Format.__\u003C\u003Ergb888 = new Pixmap.Format(nameof (rgb888), 5);
        Pixmap.Format.__\u003C\u003Ergba8888 = new Pixmap.Format(nameof (rgba8888), 6);
        Pixmap.Format.\u0024VALUES = new Pixmap.Format[7]
        {
          Pixmap.Format.__\u003C\u003Ealpha,
          Pixmap.Format.__\u003C\u003Eintensity,
          Pixmap.Format.__\u003C\u003EluminanceAlpha,
          Pixmap.Format.__\u003C\u003Ergb565,
          Pixmap.Format.__\u003C\u003Ergba4444,
          Pixmap.Format.__\u003C\u003Ergb888,
          Pixmap.Format.__\u003C\u003Ergba8888
        };
      }

      [Modifiers]
      public static Pixmap.Format alpha
      {
        [HideFromJava] get => Pixmap.Format.__\u003C\u003Ealpha;
      }

      [Modifiers]
      public static Pixmap.Format intensity
      {
        [HideFromJava] get => Pixmap.Format.__\u003C\u003Eintensity;
      }

      [Modifiers]
      public static Pixmap.Format luminanceAlpha
      {
        [HideFromJava] get => Pixmap.Format.__\u003C\u003EluminanceAlpha;
      }

      [Modifiers]
      public static Pixmap.Format rgb565
      {
        [HideFromJava] get => Pixmap.Format.__\u003C\u003Ergb565;
      }

      [Modifiers]
      public static Pixmap.Format rgba4444
      {
        [HideFromJava] get => Pixmap.Format.__\u003C\u003Ergba4444;
      }

      [Modifiers]
      public static Pixmap.Format rgb888
      {
        [HideFromJava] get => Pixmap.Format.__\u003C\u003Ergb888;
      }

      [Modifiers]
      public static Pixmap.Format rgba8888
      {
        [HideFromJava] get => Pixmap.Format.__\u003C\u003Ergba8888;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        alpha,
        intensity,
        luminanceAlpha,
        rgb565,
        rgba4444,
        rgb888,
        rgba8888,
      }
    }

    [InnerClass]
    internal class NativePixmap : Object
    {
      internal long basePtr;
      internal int width;
      internal int height;
      internal int format;
      internal ByteBuffer pixelPtr;
      internal long[] nativeData;

      [Throws(new string[] {"arc.util.ArcRuntimeException"})]
      [LineNumberTable(new byte[] {161, 239, 232, 47, 236, 82, 116, 152, 110, 111, 111, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NativePixmap([In] int obj0, [In] int obj1, [In] int obj2)
      {
        Pixmap.NativePixmap nativePixmap = this;
        this.nativeData = new long[4];
        this.pixelPtr = Pixmap.newPixmap(this.nativeData, obj0, obj1, obj2);
        if (this.pixelPtr == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException("Error loading pixmap.");
        }
        this.basePtr = this.nativeData[0];
        this.width = (int) this.nativeData[1];
        this.height = (int) this.nativeData[2];
        this.format = (int) this.nativeData[3];
      }

      [Throws(new string[] {"java.io.IOException"})]
      [LineNumberTable(new byte[] {161, 224, 8, 172, 116, 159, 18, 110, 111, 111, 143, 110, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public NativePixmap([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] int obj3)
      {
        Pixmap.NativePixmap nativePixmap = this;
        this.nativeData = new long[4];
        this.pixelPtr = Pixmap.load(this.nativeData, obj0, obj1, obj2);
        if (this.pixelPtr == null)
        {
          string str = new StringBuilder().append("Error loading pixmap: ").append(Pixmap.getFailureReason()).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException(str);
        }
        this.basePtr = this.nativeData[0];
        this.width = (int) this.nativeData[1];
        this.height = (int) this.nativeData[2];
        this.format = (int) this.nativeData[3];
        if (obj3 == 0 || obj3 == this.format)
          return;
        this.convert(obj3);
      }

      [LineNumberTable(new byte[] {161, 250, 115, 127, 14, 107, 108, 108, 108, 108, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void convert([In] int obj0)
      {
        Pixmap.NativePixmap nativePixmap = new Pixmap.NativePixmap(this.width, this.height, obj0);
        Pixmap.drawPixmap(this.basePtr, nativePixmap.basePtr, 0, 0, this.width, this.height, 0, 0, this.width, this.height);
        Pixmap.free(this.basePtr);
        this.basePtr = nativePixmap.basePtr;
        this.format = nativePixmap.format;
        this.height = nativePixmap.height;
        this.nativeData = nativePixmap.nativeData;
        this.pixelPtr = nativePixmap.pixelPtr;
        this.width = nativePixmap.width;
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/graphics/Pixmap$PixmapFilter;>;")]
    [Modifiers]
    [Serializable]
    public sealed class PixmapFilter : Enum
    {
      [Modifiers]
      internal static Pixmap.PixmapFilter __\u003C\u003EnearestNeighbour;
      [Modifiers]
      internal static Pixmap.PixmapFilter __\u003C\u003Ebilinear;
      [Modifiers]
      private static Pixmap.PixmapFilter[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(485)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PixmapFilter([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(485)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Pixmap.PixmapFilter[] values() => (Pixmap.PixmapFilter[]) Pixmap.PixmapFilter.\u0024VALUES.Clone();

      [LineNumberTable(485)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Pixmap.PixmapFilter valueOf(string name) => (Pixmap.PixmapFilter) Enum.valueOf((Class) ClassLiteral<Pixmap.PixmapFilter>.Value, name);

      [LineNumberTable(new byte[] {159, 21, 141, 63, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static PixmapFilter()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.Pixmap$PixmapFilter"))
          return;
        Pixmap.PixmapFilter.__\u003C\u003EnearestNeighbour = new Pixmap.PixmapFilter(nameof (nearestNeighbour), 0);
        Pixmap.PixmapFilter.__\u003C\u003Ebilinear = new Pixmap.PixmapFilter(nameof (bilinear), 1);
        Pixmap.PixmapFilter.\u0024VALUES = new Pixmap.PixmapFilter[2]
        {
          Pixmap.PixmapFilter.__\u003C\u003EnearestNeighbour,
          Pixmap.PixmapFilter.__\u003C\u003Ebilinear
        };
      }

      [Modifiers]
      public static Pixmap.PixmapFilter nearestNeighbour
      {
        [HideFromJava] get => Pixmap.PixmapFilter.__\u003C\u003EnearestNeighbour;
      }

      [Modifiers]
      public static Pixmap.PixmapFilter bilinear
      {
        [HideFromJava] get => Pixmap.PixmapFilter.__\u003C\u003Ebilinear;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        nearestNeighbour,
        bilinear,
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
