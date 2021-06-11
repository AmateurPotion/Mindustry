// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SdlGraphics
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.backend.sdl.jni;
using arc.func;
using arc.graphics;
using arc.graphics.gl;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.backend.sdl
{
  public class SdlGraphics : Graphics
  {
    private GL20 gl20;
    private GL30 gl30;
    private GLVersion glVersion;
    private Graphics.BufferFormat bufferFormat;
    private SdlApplication app;
    [Signature("Larc/struct/ObjectMap<Larc/Graphics$Cursor$SystemCursor;Larc/backend/sdl/SdlGraphics$SdlCursor;>;")]
    private ObjectMap cursors;
    private long lastFrameTime;
    private float deltaTime;
    private long frameId;
    private long frameCounterStart;
    private int frames;
    private int fps;
    internal int backBufferWidth;
    internal int backBufferHeight;
    internal int logicalWidth;
    internal int logicalHeight;

    [LineNumberTable(new byte[] {159, 175, 232, 52, 168, 232, 74, 103, 155, 113, 113, 146, 107, 116, 159, 58, 119, 223, 6, 124, 191, 19, 113, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SdlGraphics([In] SdlApplication obj0)
    {
      SdlGraphics sdlGraphics1 = this;
      this.lastFrameTime = -1L;
      this.frameCounterStart = 0L;
      this.app = obj0;
      SdlGraphics sdlGraphics2 = this;
      SdlGL20 sdlGl20_1 = new SdlGL20();
      SdlGL20 sdlGl20_2 = sdlGl20_1;
      this.gl20 = (GL20) sdlGl20_1;
      Core.gl20 = (GL20) sdlGl20_2;
      Core.gl = (GL20) sdlGl20_2;
      string versionString = this.gl20.glGetString(7938);
      string vendorString = this.gl20.glGetString(7936);
      string rendererString = this.gl20.glGetString(7937);
      this.cursors = new ObjectMap();
      this.glVersion = new GLVersion(Application.ApplicationType.__\u003C\u003Edesktop, versionString, vendorString, rendererString);
      this.bufferFormat = new Graphics.BufferFormat(obj0.config.r, obj0.config.g, obj0.config.b, obj0.config.a, obj0.config.depth, obj0.config.stencil, obj0.config.samples, false);
      if (!this.glVersion.atLeast(2, 0) || !this.supportsFBO())
      {
        string message = new StringBuilder().append("OpenGL 2.0 or higher with the FBO extension is required. OpenGL version: ").append(versionString).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (this.glVersion.atLeast(3, 0) && obj0.config.gl30)
      {
        SdlGraphics sdlGraphics3 = this;
        SdlGraphics sdlGraphics4 = this;
        SdlGL30 sdlGl30_1 = new SdlGL30();
        SdlGL30 sdlGl30_2 = sdlGl30_1;
        this.gl30 = (GL30) sdlGl30_1;
        Core.gl30 = (GL30) sdlGl30_2;
        SdlGL30 sdlGl30_3 = sdlGl30_2;
        SdlGL30 sdlGl30_4 = sdlGl30_3;
        this.gl20 = (GL20) sdlGl30_3;
        Core.gl20 = (GL20) sdlGl30_4;
        Core.gl = (GL20) sdlGl30_4;
      }
      this.clear(obj0.config.initialBackgroundColor);
      SDL.SDL_GL_SwapWindow(obj0.window);
    }

    [LineNumberTable(new byte[] {29, 103, 103, 103, 135, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void updateSize([In] int obj0, [In] int obj1)
    {
      this.logicalWidth = obj0;
      this.logicalHeight = obj1;
      this.backBufferWidth = obj0;
      this.backBufferHeight = obj1;
      this.gl20.glViewport(0, 0, obj0, obj1);
    }

    [LineNumberTable(new byte[] {13, 102, 106, 103, 118, 135, 112, 108, 103, 135, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void update()
    {
      long num = java.lang.System.nanoTime();
      if (this.lastFrameTime == -1L)
        this.lastFrameTime = num;
      this.deltaTime = (float) (num - this.lastFrameTime) / 1E+09f;
      this.lastFrameTime = num;
      if (num - this.frameCounterStart >= 1000000000L)
      {
        this.fps = this.frames;
        this.frames = 0;
        this.frameCounterStart = num;
      }
      ++this.frames;
      ++this.frameId;
    }

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool supportsFBO() => this.glVersion.atLeast(3, 0) || SDL.SDL_GL_ExtensionSupported("GL_EXT_framebuffer_object");

    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.Monitor getMonitor() => new Graphics.Monitor(0, 0, "Monitor");

    [LineNumberTable(new byte[] {66, 124, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getWidth() => object.ReferenceEquals((object) this.app.config.hdpiMode, (object) HdpiMode.__\u003C\u003Epixels) ? this.backBufferWidth : this.logicalWidth;

    [LineNumberTable(new byte[] {75, 124, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getHeight() => object.ReferenceEquals((object) this.app.config.hdpiMode, (object) HdpiMode.__\u003C\u003Epixels) ? this.backBufferHeight : this.logicalHeight;

    [LineNumberTable(219)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.DisplayMode getDisplayMode() => new Graphics.DisplayMode(this.getWidth(), this.getHeight(), 60, 32);

    [LineNumberTable(new byte[] {160, 215, 127, 14, 98, 98, 98, 99, 98, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int mapCursor([In] Graphics.Cursor.SystemCursor obj0)
    {
      switch (SdlGraphics.\u0031.\u0024SwitchMap\u0024arc\u0024Graphics\u0024Cursor\u0024SystemCursor[obj0.ordinal()])
      {
        case 1:
          return 0;
        case 2:
          return 1;
        case 3:
          return 3;
        case 4:
          return 11;
        case 5:
          return 7;
        case 6:
          return 8;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("this is impossible.");
      }
    }

    [Modifiers]
    [LineNumberTable(325)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024dispose\u00240(
      [In] Graphics.Cursor.SystemCursor obj0,
      [In] SdlGraphics.SdlCursor obj1)
    {
      obj1.dispose();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isGL30Available() => this.gl30 != null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override GL20 getGL20() => this.gl20;

    [LineNumberTable(new byte[] {49, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setGL20(GL20 gl20)
    {
      this.gl20 = gl20;
      Core.gl = Core.gl20 = gl20;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override GL30 getGL30() => this.gl30;

    [LineNumberTable(new byte[] {60, 114, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setGL30(GL30 gl30)
    {
      SdlGraphics sdlGraphics = this;
      GL30 gl30_1 = gl30;
      GL30 gl30_2 = gl30_1;
      this.gl30 = gl30_1;
      this.gl20 = (GL20) gl30_2;
      Core.gl = Core.gl20 = (GL20) gl30;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getBackBufferWidth() => this.backBufferWidth;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getBackBufferHeight() => this.backBufferHeight;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long getFrameId() => this.frameId;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getDeltaTime() => this.deltaTime;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getFramesPerSecond() => this.fps;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override GLVersion getGLVersion() => this.glVersion;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPpiX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPpiY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPpcX() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getPpcY() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override float getDensity() => 0.0f;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool supportsDisplayModeChange() => true;

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.Monitor getPrimaryMonitor() => this.getMonitor();

    [LineNumberTable(204)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.Monitor[] getMonitors() => new Graphics.Monitor[0];

    [LineNumberTable(209)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.DisplayMode[] getDisplayModes() => new Graphics.DisplayMode[0];

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.DisplayMode[] getDisplayModes(Graphics.Monitor monitor) => new Graphics.DisplayMode[0];

    [LineNumberTable(224)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.DisplayMode getDisplayMode(Graphics.Monitor monitor) => this.getDisplayMode();

    [LineNumberTable(new byte[] {160, 116, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool setFullscreenMode(Graphics.DisplayMode displayMode)
    {
      SDL.SDL_SetWindowFullscreen(this.app.window, 4097);
      return true;
    }

    [LineNumberTable(new byte[] {160, 122, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool setWindowedMode(int width, int height)
    {
      SDL.SDL_SetWindowFullscreen(this.app.window, 0);
      SDL.SDL_SetWindowSize(this.app.window, width, height);
      return true;
    }

    [LineNumberTable(new byte[] {160, 129, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setTitle(string title) => SDL.SDL_SetWindowTitle(this.app.window, title);

    [LineNumberTable(new byte[] {159, 80, 66, 126, 99, 176, 151, 99, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setUndecorated(bool undecorated)
    {
      int num1 = undecorated ? 1 : 0;
      int num2 = (SDL.SDL_GetWindowFlags(this.app.window) & 128) == 128 ? 1 : 0;
      if (num2 != 0)
        SDL.SDL_RestoreWindow(this.app.window);
      SDL.SDL_SetWindowBordered(this.app.window, num1 == 0);
      if (num2 == 0)
        return;
      SDL.SDL_MaximizeWindow(this.app.window);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setResizable(bool resizable)
    {
    }

    [LineNumberTable(new byte[] {159, 76, 162, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setVSync(bool vsync) => SDL.SDL_GL_SetSwapInterval(!vsync ? 0 : 1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.BufferFormat getBufferFormat() => this.bufferFormat;

    [LineNumberTable(277)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool supportsExtension(string extension) => SDL.SDL_GL_ExtensionSupported(extension);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isContinuousRendering() => true;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setContinuousRendering(bool isContinuous)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void requestRendering()
    {
    }

    [LineNumberTable(297)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isFullscreen() => (SDL.SDL_GetWindowFlags(this.app.window) & 1) == 1;

    [LineNumberTable(new byte[] {160, 188, 120, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.Cursor newCursor(Pixmap pixmap, int xHotspot, int yHotspot)
    {
      long rgbSurfaceFrom = SDL.SDL_CreateRGBSurfaceFrom(pixmap.getPixels(), pixmap.getWidth(), pixmap.getHeight());
      long colorCursor = SDL.SDL_CreateColorCursor(rgbSurfaceFrom, xHotspot, yHotspot);
      return (Graphics.Cursor) new SdlGraphics.SdlCursor(rgbSurfaceFrom, colorCursor);
    }

    [LineNumberTable(new byte[] {160, 195, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setCursor(Graphics.Cursor cursor) => SDL.SDL_SetCursor(((SdlGraphics.SdlCursor) cursor).cursorHandle);

    [LineNumberTable(new byte[] {160, 200, 110, 109, 149, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setSystemCursor(Graphics.Cursor.SystemCursor cursor)
    {
      if (!this.cursors.containsKey((object) cursor))
      {
        long systemCursor = SDL.SDL_CreateSystemCursor(this.mapCursor(cursor));
        this.cursors.put((object) cursor, (object) new SdlGraphics.SdlCursor(0L, systemCursor));
      }
      SDL.SDL_SetCursor(((SdlGraphics.SdlCursor) this.cursors.get((object) cursor)).cursorHandle);
    }

    [LineNumberTable(new byte[] {160, 209, 134, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void dispose()
    {
      base.dispose();
      this.cursors.each((Cons2) new SdlGraphics.__\u003C\u003EAnon0());
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024Graphics\u0024Cursor\u0024SystemCursor;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(329)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.backend.sdl.SdlGraphics$1"))
          return;
        SdlGraphics.\u0031.\u0024SwitchMap\u0024arc\u0024Graphics\u0024Cursor\u0024SystemCursor = new int[Graphics.Cursor.SystemCursor.values().Length];
        try
        {
          SdlGraphics.\u0031.\u0024SwitchMap\u0024arc\u0024Graphics\u0024Cursor\u0024SystemCursor[Graphics.Cursor.SystemCursor.__\u003C\u003Earrow.ordinal()] = 1;
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
          SdlGraphics.\u0031.\u0024SwitchMap\u0024arc\u0024Graphics\u0024Cursor\u0024SystemCursor[Graphics.Cursor.SystemCursor.__\u003C\u003Eibeam.ordinal()] = 2;
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
          SdlGraphics.\u0031.\u0024SwitchMap\u0024arc\u0024Graphics\u0024Cursor\u0024SystemCursor[Graphics.Cursor.SystemCursor.__\u003C\u003Ecrosshair.ordinal()] = 3;
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
          SdlGraphics.\u0031.\u0024SwitchMap\u0024arc\u0024Graphics\u0024Cursor\u0024SystemCursor[Graphics.Cursor.SystemCursor.__\u003C\u003Ehand.ordinal()] = 4;
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
          SdlGraphics.\u0031.\u0024SwitchMap\u0024arc\u0024Graphics\u0024Cursor\u0024SystemCursor[Graphics.Cursor.SystemCursor.__\u003C\u003EhorizontalResize.ordinal()] = 5;
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
          SdlGraphics.\u0031.\u0024SwitchMap\u0024arc\u0024Graphics\u0024Cursor\u0024SystemCursor[Graphics.Cursor.SystemCursor.__\u003C\u003EverticalResize.ordinal()] = 6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [Implements(new string[] {"arc.Graphics$Cursor"})]
    public class SdlCursor : Object, Graphics.Cursor, Disposable
    {
      [Modifiers]
      internal long surfaceHandle;
      [Modifiers]
      internal long cursorHandle;

      [LineNumberTable(new byte[] {160, 229, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SdlCursor(long surfaceHandle, long cursorHandle)
      {
        SdlGraphics.SdlCursor sdlCursor = this;
        this.surfaceHandle = surfaceHandle;
        this.cursorHandle = cursorHandle;
      }

      [LineNumberTable(new byte[] {160, 236, 117, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dispose()
      {
        if (this.cursorHandle != 0L)
          SDL.SDL_FreeCursor(this.cursorHandle);
        if (this.surfaceHandle == 0L)
          return;
        SDL.SDL_FreeSurface(this.surfaceHandle);
      }

      [HideFromJava]
      public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => SdlGraphics.lambda\u0024dispose\u00240((Graphics.Cursor.SystemCursor) obj0, (SdlGraphics.SdlCursor) obj1);
    }
  }
}
