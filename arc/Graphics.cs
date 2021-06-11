// Decompiled with JetBrains decompiler
// Type: arc.Graphics
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.gl;
using arc.math;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc
{
  public abstract class Graphics : Object, Disposable
  {
    private object lastCursor;

    public abstract GLVersion getGLVersion();

    public abstract int getWidth();

    public abstract int getHeight();

    public abstract float getDeltaTime();

    public abstract void requestRendering();

    public abstract bool setWindowedMode(int i1, int i2);

    public abstract Graphics.DisplayMode getDisplayMode();

    public abstract bool setFullscreenMode(Graphics.DisplayMode gdm);

    [LineNumberTable(new byte[] {11, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(Color color) => this.clear(color.r, color.g, color.b, color.a);

    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int[] getSafeInsets() => new int[4];

    [LineNumberTable(new byte[] {160, 199, 122, 127, 21, 124, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Graphics.Cursor newCursor(string filename, int scale)
    {
      if (scale == 1 || OS.isAndroid || OS.isIos)
        return this.newCursor(filename);
      Pixmap pixmap = new Pixmap(Core.files.@internal(new StringBuilder().append("cursors/").append(filename).append(".png").toString()));
      Pixmap p = Pixmaps.scale(pixmap, pixmap.getWidth() * scale, pixmap.getHeight() * scale, Pixmap.PixmapFilter.__\u003C\u003EnearestNeighbour);
      pixmap.dispose();
      return this.newCursor(p, p.getWidth() / 2, p.getHeight() / 2);
    }

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPortrait() => this.getWidth() < this.getHeight();

    [LineNumberTable(new byte[] {160, 238, 143, 104, 109, 147, 174, 167, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cursor(Graphics.Cursor cursor)
    {
      if (object.ReferenceEquals(this.lastCursor, (object) cursor))
        return;
      if (cursor is Graphics.Cursor.SystemCursor)
      {
        if (((Graphics.Cursor.SystemCursor) cursor).cursor != null)
          this.setCursor(((Graphics.Cursor.SystemCursor) cursor).cursor);
        else
          this.setSystemCursor((Graphics.Cursor.SystemCursor) cursor);
      }
      else
        this.setCursor(cursor);
      this.lastCursor = (object) cursor;
    }

    public abstract long getFrameId();

    [LineNumberTable(new byte[] {160, 233, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void restoreCursor() => this.cursor((Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Earrow);

    public abstract void setVSync(bool b);

    public abstract void setUndecorated(bool b);

    public abstract int getFramesPerSecond();

    [LineNumberTable(new byte[] {5, 110, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear(float r, float g, float b, float a)
    {
      Gl.clearColor(r, g, b, a);
      Gl.clear(16384);
    }

    public abstract Graphics.Cursor newCursor(Pixmap p, int i1, int i2);

    [LineNumberTable(new byte[] {160, 211, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Graphics.Cursor newCursor(string filename)
    {
      Pixmap p = new Pixmap(Core.files.@internal(new StringBuilder().append("cursors/").append(filename).append(".png").toString()));
      return this.newCursor(p, p.getWidth() / 2, p.getHeight() / 2);
    }

    [LineNumberTable(new byte[] {160, 155, 104, 107, 137, 109, 98, 125, 166, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Graphics.Cursor newCursor(
      Pixmap pixmap,
      int scaling,
      Color outlineColor)
    {
      Pixmap input = Pixmaps.outline(pixmap, outlineColor);
      input.setColor(Color.__\u003C\u003Ewhite);
      Pixmap pixmap1 = Pixmaps.scale(input, (float) scaling);
      if (!Mathf.isPowerOfTwo(pixmap1.getWidth()))
      {
        Pixmap pixmap2 = pixmap1;
        pixmap1 = Pixmaps.resize(pixmap1, Mathf.nextPowerOfTwo(pixmap1.getWidth()), Mathf.nextPowerOfTwo(pixmap1.getWidth()));
        pixmap2.dispose();
      }
      input.dispose();
      pixmap.dispose();
      return this.newCursor(pixmap1, pixmap1.getWidth() / 2, pixmap1.getHeight() / 2);
    }

    [LineNumberTable(new byte[] {160, 178, 106, 107, 137, 109, 98, 125, 166, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Graphics.Cursor newCursor(
      Pixmap pixmap,
      int scaling,
      Color outlineColor,
      int outlineThickness)
    {
      Pixmap input = Pixmaps.outline(pixmap, outlineColor, outlineThickness);
      input.setColor(Color.__\u003C\u003Ewhite);
      Pixmap pixmap1 = Pixmaps.scale(input, (float) scaling);
      if (!Mathf.isPowerOfTwo(pixmap1.getWidth()))
      {
        Pixmap pixmap2 = pixmap1;
        pixmap1 = Pixmaps.resize(pixmap1, Mathf.nextPowerOfTwo(pixmap1.getWidth()), Mathf.nextPowerOfTwo(pixmap1.getWidth()));
        pixmap2.dispose();
      }
      input.dispose();
      pixmap.dispose();
      return this.newCursor(pixmap1, pixmap1.getWidth() / 2, pixmap1.getHeight() / 2);
    }

    protected internal abstract void setCursor(Graphics.Cursor gc);

    protected internal abstract void setSystemCursor(Graphics.Cursor.SystemCursor gcsc);

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Graphics()
    {
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isGL30Available() => Core.gl30 != null;

    public abstract GL20 getGL20();

    public abstract void setGL20(GL20 gl);

    public abstract GL30 getGL30();

    public abstract void setGL30(GL30 gl);

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAspect() => (float) this.getWidth() / (float) this.getHeight();

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isHidden() => this.getWidth() < 2 || this.getHeight() < 2;

    public abstract int getBackBufferWidth();

    public abstract int getBackBufferHeight();

    public abstract float getPpiX();

    public abstract float getPpiY();

    public abstract float getPpcX();

    public abstract float getPpcY();

    public abstract float getDensity();

    public abstract bool supportsDisplayModeChange();

    public abstract Graphics.Monitor getPrimaryMonitor();

    public abstract Graphics.Monitor getMonitor();

    public abstract Graphics.Monitor[] getMonitors();

    public abstract Graphics.DisplayMode[] getDisplayModes();

    public abstract Graphics.DisplayMode[] getDisplayModes(Graphics.Monitor gm);

    public abstract Graphics.DisplayMode getDisplayMode(Graphics.Monitor gm);

    public abstract void setTitle(string str);

    public abstract void setResizable(bool b);

    public abstract Graphics.BufferFormat getBufferFormat();

    public abstract bool supportsExtension(string str);

    public abstract bool isContinuousRendering();

    public abstract void setContinuousRendering(bool b);

    public abstract bool isFullscreen();

    [LineNumberTable(334)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Graphics.Cursor newCursor(
      string filename,
      int scaling,
      Color outlineColor)
    {
      return this.newCursor(new Pixmap(Core.files.@internal(new StringBuilder().append("cursors/").append(filename).append(".png").toString())), scaling, outlineColor);
    }

    [LineNumberTable(342)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Graphics.Cursor newCursor(
      string filename,
      int scaling,
      Color outlineColor,
      int outlineScaling)
    {
      return this.newCursor(new Pixmap(Core.files.@internal(new StringBuilder().append("cursors/").append(filename).append(".png").toString())), scaling, outlineColor, outlineScaling);
    }

    [LineNumberTable(new byte[] {161, 12, 115, 38, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      Graphics.Cursor.SystemCursor[] systemCursorArray = Graphics.Cursor.SystemCursor.values();
      int length = systemCursorArray.Length;
      for (int index = 0; index < length; ++index)
        systemCursorArray[index].dispose();
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    public class BufferFormat : Object
    {
      internal int __\u003C\u003Er;
      internal int __\u003C\u003Eg;
      internal int __\u003C\u003Eb;
      internal int __\u003C\u003Ea;
      internal int __\u003C\u003Edepth;
      internal int __\u003C\u003Estencil;
      internal int __\u003C\u003Esamples;
      internal bool __\u003C\u003EcoverageSampling;

      [LineNumberTable(new byte[] {159, 32, 67, 104, 103, 103, 103, 104, 104, 104, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public BufferFormat(
        int r,
        int g,
        int b,
        int a,
        int depth,
        int stencil,
        int samples,
        bool coverageSampling)
      {
        int num = coverageSampling ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        Graphics.BufferFormat bufferFormat = this;
        this.__\u003C\u003Er = r;
        this.__\u003C\u003Eg = g;
        this.__\u003C\u003Eb = b;
        this.__\u003C\u003Ea = a;
        this.__\u003C\u003Edepth = depth;
        this.__\u003C\u003Estencil = stencil;
        this.__\u003C\u003Esamples = samples;
        this.__\u003C\u003EcoverageSampling = num != 0;
      }

      [LineNumberTable(452)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append("r: ").append(this.__\u003C\u003Er).append(", g: ").append(this.__\u003C\u003Eg).append(", b: ").append(this.__\u003C\u003Eb).append(", a: ").append(this.__\u003C\u003Ea).append(", depth: ").append(this.__\u003C\u003Edepth).append(", stencil: ").append(this.__\u003C\u003Estencil).append(", num samples: ").append(this.__\u003C\u003Esamples).append(", coverage sampling: ").append(this.__\u003C\u003EcoverageSampling).toString();

      [Modifiers]
      public int r
      {
        [HideFromJava] get => this.__\u003C\u003Er;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Er = value;
      }

      [Modifiers]
      public int g
      {
        [HideFromJava] get => this.__\u003C\u003Eg;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eg = value;
      }

      [Modifiers]
      public int b
      {
        [HideFromJava] get => this.__\u003C\u003Eb;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eb = value;
      }

      [Modifiers]
      public int a
      {
        [HideFromJava] get => this.__\u003C\u003Ea;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ea = value;
      }

      [Modifiers]
      public int depth
      {
        [HideFromJava] get => this.__\u003C\u003Edepth;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Edepth = value;
      }

      [Modifiers]
      public int stencil
      {
        [HideFromJava] get => this.__\u003C\u003Estencil;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Estencil = value;
      }

      [Modifiers]
      public int samples
      {
        [HideFromJava] get => this.__\u003C\u003Esamples;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Esamples = value;
      }

      [Modifiers]
      public bool coverageSampling
      {
        [HideFromJava] get => this.__\u003C\u003EcoverageSampling;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EcoverageSampling = value;
      }
    }

    [Implements(new string[] {"arc.util.Disposable"})]
    public interface Cursor : Disposable
    {
      [InnerClass]
      [Signature("Ljava/lang/Enum<Larc/Graphics$Cursor$SystemCursor;>;Larc/Graphics$Cursor;")]
      [Modifiers]
      [Implements(new string[] {"arc.Graphics$Cursor"})]
      [Serializable]
      sealed class SystemCursor : Enum, Graphics.Cursor, Disposable
      {
        [Modifiers]
        internal static Graphics.Cursor.SystemCursor __\u003C\u003Earrow;
        [Modifiers]
        internal static Graphics.Cursor.SystemCursor __\u003C\u003Eibeam;
        [Modifiers]
        internal static Graphics.Cursor.SystemCursor __\u003C\u003Ecrosshair;
        [Modifiers]
        internal static Graphics.Cursor.SystemCursor __\u003C\u003Ehand;
        [Modifiers]
        internal static Graphics.Cursor.SystemCursor __\u003C\u003EhorizontalResize;
        [Modifiers]
        internal static Graphics.Cursor.SystemCursor __\u003C\u003EverticalResize;
        protected internal Graphics.Cursor cursor;
        [Modifiers]
        private static Graphics.Cursor.SystemCursor[] \u0024VALUES;

        [SpecialName]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void __\u003Cclinit\u003E()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void set(Graphics.Cursor cursor) => this.cursor = cursor;

        [LineNumberTable(467)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Graphics.Cursor.SystemCursor[] values() => (Graphics.Cursor.SystemCursor[]) Graphics.Cursor.SystemCursor.\u0024VALUES.Clone();

        [LineNumberTable(new byte[] {161, 115, 117, 107, 135})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void dispose()
        {
          if (this.cursor == null || this.cursor is Graphics.Cursor.SystemCursor)
            return;
          this.cursor.dispose();
          this.cursor = (Graphics.Cursor) null;
        }

        [Signature("()V")]
        [LineNumberTable(467)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private SystemCursor([In] string obj0, [In] int obj1)
          : base(obj0, obj1)
        {
          GC.KeepAlive((object) this);
        }

        [LineNumberTable(467)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Graphics.Cursor.SystemCursor valueOf(string name) => (Graphics.Cursor.SystemCursor) Enum.valueOf((Class) ClassLiteral<Graphics.Cursor.SystemCursor>.Value, name);

        [LineNumberTable(new byte[] {159, 25, 77, 112, 112, 112, 112, 112, 240, 58})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        static SystemCursor()
        {
          if (ByteCodeHelper.isAlreadyInited("arc.Graphics$Cursor$SystemCursor"))
            return;
          Graphics.Cursor.SystemCursor.__\u003C\u003Earrow = new Graphics.Cursor.SystemCursor(nameof (arrow), 0);
          Graphics.Cursor.SystemCursor.__\u003C\u003Eibeam = new Graphics.Cursor.SystemCursor(nameof (ibeam), 1);
          Graphics.Cursor.SystemCursor.__\u003C\u003Ecrosshair = new Graphics.Cursor.SystemCursor(nameof (crosshair), 2);
          Graphics.Cursor.SystemCursor.__\u003C\u003Ehand = new Graphics.Cursor.SystemCursor(nameof (hand), 3);
          Graphics.Cursor.SystemCursor.__\u003C\u003EhorizontalResize = new Graphics.Cursor.SystemCursor(nameof (horizontalResize), 4);
          Graphics.Cursor.SystemCursor.__\u003C\u003EverticalResize = new Graphics.Cursor.SystemCursor(nameof (verticalResize), 5);
          Graphics.Cursor.SystemCursor.\u0024VALUES = new Graphics.Cursor.SystemCursor[6]
          {
            Graphics.Cursor.SystemCursor.__\u003C\u003Earrow,
            Graphics.Cursor.SystemCursor.__\u003C\u003Eibeam,
            Graphics.Cursor.SystemCursor.__\u003C\u003Ecrosshair,
            Graphics.Cursor.SystemCursor.__\u003C\u003Ehand,
            Graphics.Cursor.SystemCursor.__\u003C\u003EhorizontalResize,
            Graphics.Cursor.SystemCursor.__\u003C\u003EverticalResize
          };
        }

        [HideFromJava]
        public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

        [Modifiers]
        public static Graphics.Cursor.SystemCursor arrow
        {
          [HideFromJava] get => Graphics.Cursor.SystemCursor.__\u003C\u003Earrow;
        }

        [Modifiers]
        public static Graphics.Cursor.SystemCursor ibeam
        {
          [HideFromJava] get => Graphics.Cursor.SystemCursor.__\u003C\u003Eibeam;
        }

        [Modifiers]
        public static Graphics.Cursor.SystemCursor crosshair
        {
          [HideFromJava] get => Graphics.Cursor.SystemCursor.__\u003C\u003Ecrosshair;
        }

        [Modifiers]
        public static Graphics.Cursor.SystemCursor hand
        {
          [HideFromJava] get => Graphics.Cursor.SystemCursor.__\u003C\u003Ehand;
        }

        [Modifiers]
        public static Graphics.Cursor.SystemCursor horizontalResize
        {
          [HideFromJava] get => Graphics.Cursor.SystemCursor.__\u003C\u003EhorizontalResize;
        }

        [Modifiers]
        public static Graphics.Cursor.SystemCursor verticalResize
        {
          [HideFromJava] get => Graphics.Cursor.SystemCursor.__\u003C\u003EverticalResize;
        }

        [HideFromJava]
        [Serializable]
        public enum __Enum
        {
          arrow,
          ibeam,
          crosshair,
          hand,
          horizontalResize,
          verticalResize,
        }
      }
    }

    public class DisplayMode : Object
    {
      internal int __\u003C\u003Ewidth;
      internal int __\u003C\u003Eheight;
      internal int __\u003C\u003ErefreshRate;
      internal int __\u003C\u003EbitsPerPixel;

      [LineNumberTable(new byte[] {161, 31, 104, 103, 103, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public DisplayMode(int width, int height, int refreshRate, int bitsPerPixel)
      {
        Graphics.DisplayMode displayMode = this;
        this.__\u003C\u003Ewidth = width;
        this.__\u003C\u003Eheight = height;
        this.__\u003C\u003ErefreshRate = refreshRate;
        this.__\u003C\u003EbitsPerPixel = bitsPerPixel;
      }

      [LineNumberTable(409)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append(this.__\u003C\u003Ewidth).append("x").append(this.__\u003C\u003Eheight).append(", bpp: ").append(this.__\u003C\u003EbitsPerPixel).append(", hz: ").append(this.__\u003C\u003ErefreshRate).toString();

      [Modifiers]
      public int width
      {
        [HideFromJava] get => this.__\u003C\u003Ewidth;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ewidth = value;
      }

      [Modifiers]
      public int height
      {
        [HideFromJava] get => this.__\u003C\u003Eheight;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eheight = value;
      }

      [Modifiers]
      public int refreshRate
      {
        [HideFromJava] get => this.__\u003C\u003ErefreshRate;
        [HideFromJava] [param: In] private set => this.__\u003C\u003ErefreshRate = value;
      }

      [Modifiers]
      public int bitsPerPixel
      {
        [HideFromJava] get => this.__\u003C\u003EbitsPerPixel;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EbitsPerPixel = value;
      }
    }

    public class Monitor : Object
    {
      internal int __\u003C\u003EvirtualX;
      internal int __\u003C\u003EvirtualY;
      internal string __\u003C\u003Ename;

      [LineNumberTable(new byte[] {161, 52, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Monitor(int virtualX, int virtualY, string name)
      {
        Graphics.Monitor monitor = this;
        this.__\u003C\u003EvirtualX = virtualX;
        this.__\u003C\u003EvirtualY = virtualY;
        this.__\u003C\u003Ename = name;
      }

      [Modifiers]
      public int virtualX
      {
        [HideFromJava] get => this.__\u003C\u003EvirtualX;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EvirtualX = value;
      }

      [Modifiers]
      public int virtualY
      {
        [HideFromJava] get => this.__\u003C\u003EvirtualY;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EvirtualY = value;
      }

      [Modifiers]
      public string name
      {
        [HideFromJava] get => this.__\u003C\u003Ename;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ename = value;
      }
    }
  }
}
