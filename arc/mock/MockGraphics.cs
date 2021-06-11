// Decompiled with JetBrains decompiler
// Type: arc.mock.MockGraphics
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.gl;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.mock
{
  public class MockGraphics : Graphics
  {
    internal long frameId;
    internal float deltaTime;
    internal long frameStart;
    internal int frames;
    internal int fps;
    internal long lastTime;
    internal GLVersion glVersion;

    [LineNumberTable(new byte[] {159, 154, 104, 104, 107, 104, 135, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MockGraphics()
    {
      MockGraphics mockGraphics = this;
      this.frameId = -1L;
      this.deltaTime = 0.0f;
      this.frameStart = 0L;
      this.frames = 0;
      this.lastTime = java.lang.System.nanoTime();
      this.glVersion = new GLVersion(Application.ApplicationType.__\u003C\u003Eheadless, "", "", "");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isGL30Available() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override GL20 getGL20() => (GL20) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setGL20(GL20 gl20)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override GL30 getGL30() => (GL30) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setGL30(GL30 gl30)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getWidth() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getHeight() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getBackBufferWidth() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getBackBufferHeight() => 0;

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
    public override bool supportsDisplayModeChange() => false;

    [LineNumberTable(118)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.DisplayMode[] getDisplayModes() => new Graphics.DisplayMode[0];

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.DisplayMode getDisplayMode() => (Graphics.DisplayMode) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool setFullscreenMode(Graphics.DisplayMode displayMode) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool setWindowedMode(int width, int height) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setTitle(string title)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setVSync(bool vsync)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.BufferFormat getBufferFormat() => (Graphics.BufferFormat) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool supportsExtension(string extension) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isContinuousRendering() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setContinuousRendering(bool isContinuous)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void requestRendering()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isFullscreen() => false;

    [LineNumberTable(new byte[] {127, 102, 118, 135, 112, 108, 103, 135, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateTime()
    {
      long num = java.lang.System.nanoTime();
      this.deltaTime = (float) (num - this.lastTime) / 1E+09f;
      this.lastTime = num;
      if (num - this.frameStart >= 1000000000L)
      {
        this.fps = this.frames;
        this.frames = 0;
        this.frameStart = num;
      }
      ++this.frames;
    }

    [LineNumberTable(new byte[] {160, 76, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void incrementFrameId() => ++this.frameId;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.Cursor newCursor(Pixmap pixmap, int xHotspot, int yHotspot) => (Graphics.Cursor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setCursor(Graphics.Cursor cursor)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setSystemCursor(Graphics.Cursor.SystemCursor systemCursor)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.Monitor getPrimaryMonitor() => (Graphics.Monitor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.Monitor getMonitor() => (Graphics.Monitor) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.Monitor[] getMonitors() => (Graphics.Monitor[]) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.DisplayMode[] getDisplayModes(Graphics.Monitor monitor) => (Graphics.DisplayMode[]) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Graphics.DisplayMode getDisplayMode(Graphics.Monitor monitor) => (Graphics.DisplayMode) null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setUndecorated(bool undecorated)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setResizable(bool resizable)
    {
    }
  }
}
