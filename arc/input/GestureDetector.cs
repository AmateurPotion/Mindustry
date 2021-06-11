// Decompiled with JetBrains decompiler
// Type: arc.input.GestureDetector
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.input
{
  public class GestureDetector : Object, InputProcessor
  {
    [Modifiers]
    internal GestureDetector.GestureListener listener;
    [Modifiers]
    private GestureDetector.VelocityTracker tracker;
    [Modifiers]
    private Vec2 pointer2;
    [Modifiers]
    private Vec2 initialPointer1;
    [Modifiers]
    private Vec2 initialPointer2;
    internal bool longPressFired;
    internal Vec2 pointer1;
    [Modifiers]
    private Timer.Task longPressTask;
    private float tapRectangleWidth;
    private float tapRectangleHeight;
    private long tapCountInterval;
    private float longPressSeconds;
    private long maxFlingDelay;
    private bool inTapRectangle;
    private int tapCount;
    private long lastTapTime;
    private float lastTapX;
    private float lastTapY;
    private int lastTapPointer;
    private KeyCode lastTapButton;
    private bool pinching;
    private bool panning;
    private float tapRectangleCenterX;
    private float tapRectangleCenterY;
    private long gestureStartTime;

    [LineNumberTable(new byte[] {11, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GestureDetector(
      float halfTapSquareSize,
      float tapCountInterval,
      float longPressDuration,
      float maxFlingDelay,
      GestureDetector.GestureListener listener)
      : this(halfTapSquareSize, halfTapSquareSize, tapCountInterval, longPressDuration, maxFlingDelay, listener)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GestureDetector.GestureListener getListener() => this.listener;

    [LineNumberTable(new byte[] {43, 134, 102, 112, 112, 117, 141, 103, 103, 114, 114, 176, 103, 103, 103, 104, 104, 223, 2, 112, 103, 103, 114, 114, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDown(float x, float y, int pointer, KeyCode button)
    {
      if (pointer > 1)
        return false;
      if (pointer == 0)
      {
        this.pointer1.set(x, y);
        this.gestureStartTime = Core.input.getCurrentEventTime();
        this.tracker.start(x, y, this.gestureStartTime);
        if (Core.input.isTouched(1))
        {
          this.inTapRectangle = false;
          this.pinching = true;
          this.initialPointer1.set(this.pointer1);
          this.initialPointer2.set(this.pointer2);
          this.longPressTask.cancel();
        }
        else
        {
          this.inTapRectangle = true;
          this.pinching = false;
          this.longPressFired = false;
          this.tapRectangleCenterX = x;
          this.tapRectangleCenterY = y;
          if (!this.longPressTask.isScheduled())
            Timer.schedule(this.longPressTask, this.longPressSeconds);
        }
      }
      else
      {
        this.pointer2.set(x, y);
        this.inTapRectangle = false;
        this.pinching = true;
        this.initialPointer1.set(this.pointer1);
        this.initialPointer2.set(this.pointer2);
        this.longPressTask.cancel();
      }
      return this.listener.touchDown(x, y, pointer, button);
    }

    [LineNumberTable(new byte[] {124, 166, 127, 1, 135, 103, 135, 107, 138, 139, 127, 30, 110, 110, 107, 104, 104, 104, 103, 104, 184, 136, 103, 107, 135, 131, 191, 14, 159, 12, 194, 98, 190, 104, 107, 117, 112, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchUp(float x, float y, int pointer, KeyCode button)
    {
      if (pointer > 1)
        return false;
      if (this.inTapRectangle && !this.isWithinTapRectangle(x, y, this.tapRectangleCenterX, this.tapRectangleCenterY))
        this.inTapRectangle = false;
      int num1 = this.panning ? 1 : 0;
      this.panning = false;
      this.longPressTask.cancel();
      if (this.longPressFired)
        return false;
      if (this.inTapRectangle)
      {
        if (!object.ReferenceEquals((object) this.lastTapButton, (object) button) || this.lastTapPointer != pointer || (Time.nanos() - this.lastTapTime > this.tapCountInterval || !this.isWithinTapRectangle(x, y, this.lastTapX, this.lastTapY)))
          this.tapCount = 0;
        ++this.tapCount;
        this.lastTapTime = Time.nanos();
        this.lastTapX = x;
        this.lastTapY = y;
        this.lastTapButton = button;
        this.lastTapPointer = pointer;
        this.gestureStartTime = 0L;
        return this.listener.tap(x, y, this.tapCount, button);
      }
      if (this.pinching)
      {
        this.pinching = false;
        this.listener.pinchStop();
        this.panning = true;
        if (pointer == 0)
          this.tracker.start(this.pointer2.x, this.pointer2.y, Core.input.getCurrentEventTime());
        else
          this.tracker.start(this.pointer1.x, this.pointer1.y, Core.input.getCurrentEventTime());
        return false;
      }
      int num2 = 0;
      if (num1 != 0 && !this.panning)
        num2 = this.listener.panStop(x, y, pointer, button) ? 1 : 0;
      this.gestureStartTime = 0L;
      long currentEventTime = Core.input.getCurrentEventTime();
      if (currentEventTime - this.tracker.lastTime < this.maxFlingDelay)
      {
        this.tracker.update(x, y, currentEventTime);
        num2 = this.listener.fling(this.tracker.getVelocityX(), this.tracker.getVelocityY(), button) || num2 != 0 ? 1 : 0;
      }
      return num2 != 0;
    }

    [LineNumberTable(new byte[] {83, 102, 138, 99, 146, 176, 104, 104, 127, 5, 159, 26, 194, 185, 127, 1, 107, 199, 104, 103, 191, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDragged(float x, float y, int pointer)
    {
      if (pointer > 1 || this.longPressFired)
        return false;
      if (pointer == 0)
        this.pointer1.set(x, y);
      else
        this.pointer2.set(x, y);
      if (this.pinching)
      {
        if (this.listener == null)
          return false;
        int num = this.listener.pinch(this.initialPointer1, this.initialPointer2, this.pointer1, this.pointer2) ? 1 : 0;
        return this.listener.zoom(this.initialPointer1.dst(this.initialPointer2), this.pointer1.dst(this.pointer2)) || num != 0;
      }
      this.tracker.update(x, y, Core.input.getCurrentEventTime());
      if (this.inTapRectangle && !this.isWithinTapRectangle(x, y, this.tapRectangleCenterX, this.tapRectangleCenterY))
      {
        this.longPressTask.cancel();
        this.inTapRectangle = false;
      }
      if (this.inTapRectangle)
        return false;
      this.panning = true;
      return this.listener.pan(x, y, this.tracker.deltaX, this.tracker.deltaY);
    }

    [LineNumberTable(new byte[] {24, 232, 5, 107, 107, 107, 139, 107, 236, 118, 104, 104, 116, 105, 117, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GestureDetector(
      float halfTapRectangleWidth,
      float halfTapRectangleHeight,
      float tapCountInterval,
      float longPressDuration,
      float maxFlingDelay,
      GestureDetector.GestureListener listener)
    {
      GestureDetector gestureDetector = this;
      this.tracker = new GestureDetector.VelocityTracker();
      this.pointer2 = new Vec2();
      this.initialPointer1 = new Vec2();
      this.initialPointer2 = new Vec2();
      this.pointer1 = new Vec2();
      this.longPressTask = (Timer.Task) new GestureDetector.\u0031(this);
      this.tapRectangleWidth = halfTapRectangleWidth;
      this.tapRectangleHeight = halfTapRectangleHeight;
      this.tapCountInterval = ByteCodeHelper.f2l(tapCountInterval * 1E+09f);
      this.longPressSeconds = longPressDuration;
      this.maxFlingDelay = ByteCodeHelper.f2l(maxFlingDelay * 1E+09f);
      this.listener = listener;
    }

    [LineNumberTable(261)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isWithinTapRectangle([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => (double) Math.abs(obj0 - obj2) < (double) this.tapRectangleWidth && (double) Math.abs(obj1 - obj3) < (double) this.tapRectangleHeight;

    [LineNumberTable(new byte[] {160, 131, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLongPressed(float duration) => this.gestureStartTime != 0L && Time.nanos() - this.gestureStartTime > ByteCodeHelper.f2l(duration * 1E+09f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTapRectangleSize(
      float halfTapRectangleWidth,
      float halfTapRectangleHeight)
    {
      this.tapRectangleWidth = halfTapRectangleWidth;
      this.tapRectangleHeight = halfTapRectangleHeight;
    }

    [LineNumberTable(new byte[] {159, 190, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GestureDetector(GestureDetector.GestureListener listener)
      : this(20f, 0.4f, 1.1f, 0.15f, listener)
    {
    }

    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDown(int x, int y, int pointer, KeyCode button) => this.touchDown((float) x, (float) y, pointer, button);

    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDragged(int x, int y, int pointer) => this.touchDragged((float) x, (float) y, pointer);

    [LineNumberTable(170)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchUp(int x, int y, int pointer, KeyCode button) => this.touchUp((float) x, (float) y, pointer, button);

    [LineNumberTable(new byte[] {160, 118, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancel()
    {
      this.longPressTask.cancel();
      this.longPressFired = true;
    }

    [LineNumberTable(238)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isLongPressed() => this.isLongPressed(this.longPressSeconds);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPanning() => this.panning;

    [LineNumberTable(new byte[] {160, 140, 104, 103, 103, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.gestureStartTime = 0L;
      this.panning = false;
      this.inTapRectangle = false;
      this.tracker.lastTime = 0L;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void invalidateTapSquare() => this.inTapRectangle = false;

    [LineNumberTable(new byte[] {160, 156, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTapSquareSize(float halfTapSquareSize) => this.setTapRectangleSize(halfTapSquareSize, halfTapSquareSize);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTapCountInterval(float tapCountInterval) => this.tapCountInterval = ByteCodeHelper.f2l(tapCountInterval * 1E+09f);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLongPressSeconds(float longPressSeconds) => this.longPressSeconds = longPressSeconds;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMaxFlingDelay(long maxFlingDelay) => this.maxFlingDelay = maxFlingDelay;

    [HideFromJava]
    public virtual void connected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Econnected((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual void disconnected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Edisconnected((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool keyDown([In] KeyCode obj0) => InputProcessor.\u003Cdefault\u003EkeyDown((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool keyUp([In] KeyCode obj0) => InputProcessor.\u003Cdefault\u003EkeyUp((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool keyTyped([In] char obj0) => InputProcessor.\u003Cdefault\u003EkeyTyped((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual bool mouseMoved([In] int obj0, [In] int obj1) => InputProcessor.\u003Cdefault\u003EmouseMoved((InputProcessor) this, obj0, obj1);

    [HideFromJava]
    public virtual bool scrolled([In] float obj0, [In] float obj1) => InputProcessor.\u003Cdefault\u003Escrolled((InputProcessor) this, obj0, obj1);

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0031 : Timer.Task
    {
      [Modifiers]
      internal GestureDetector this\u00240;

      [LineNumberTable(21)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] GestureDetector obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 166, 127, 41})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void run()
      {
        if (this.this\u00240.longPressFired)
          return;
        this.this\u00240.longPressFired = this.this\u00240.listener.longPress(this.this\u00240.pointer1.x, this.this\u00240.pointer1.y);
      }
    }

    public interface GestureListener
    {
      [Modifiers]
      bool touchDown(float x, float y, int pointer, KeyCode button);

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static bool \u003Cdefault\u003EtouchDown(
        [In] GestureDetector.GestureListener obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        return false;
      }

      [Modifiers]
      bool tap(float x, float y, int count, KeyCode button);

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static bool \u003Cdefault\u003Etap(
        [In] GestureDetector.GestureListener obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        return false;
      }

      [Modifiers]
      bool longPress(float x, float y);

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static bool \u003Cdefault\u003ElongPress(
        [In] GestureDetector.GestureListener obj0,
        [In] float obj1,
        [In] float obj2)
      {
        return false;
      }

      [Modifiers]
      bool fling(float velocityX, float velocityY, KeyCode button);

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static bool \u003Cdefault\u003Efling(
        [In] GestureDetector.GestureListener obj0,
        [In] float obj1,
        [In] float obj2,
        [In] KeyCode obj3)
      {
        return false;
      }

      [Modifiers]
      bool pan(float x, float y, float deltaX, float deltaY);

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static bool \u003Cdefault\u003Epan(
        [In] GestureDetector.GestureListener obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4)
      {
        return false;
      }

      [Modifiers]
      bool panStop(float x, float y, int pointer, KeyCode button);

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static bool \u003Cdefault\u003EpanStop(
        [In] GestureDetector.GestureListener obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        return false;
      }

      [Modifiers]
      bool zoom(float initialDistance, float distance);

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static bool \u003Cdefault\u003Ezoom(
        [In] GestureDetector.GestureListener obj0,
        [In] float obj1,
        [In] float obj2)
      {
        return false;
      }

      [Modifiers]
      bool pinch(Vec2 initialPointer1, Vec2 initialPointer2, Vec2 pointer1, Vec2 pointer2);

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static bool \u003Cdefault\u003Epinch(
        [In] GestureDetector.GestureListener obj0,
        [In] Vec2 obj1,
        [In] Vec2 obj2,
        [In] Vec2 obj3,
        [In] Vec2 obj4)
      {
        return false;
      }

      [Modifiers]
      void pinchStop();

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static void \u003Cdefault\u003EpinchStop([In] GestureDetector.GestureListener obj0)
      {
      }

      [HideFromJava]
      static class __DefaultMethods
      {
        public static bool touchDown(
          [In] GestureDetector.GestureListener obj0,
          [In] float obj1,
          [In] float obj2,
          [In] int obj3,
          [In] KeyCode obj4)
        {
          GestureDetector.GestureListener gestureListener = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(gestureListener, ToString);
          return GestureDetector.GestureListener.\u003Cdefault\u003EtouchDown(gestureListener, obj1, obj2, obj3, obj4);
        }

        public static bool tap(
          [In] GestureDetector.GestureListener obj0,
          [In] float obj1,
          [In] float obj2,
          [In] int obj3,
          [In] KeyCode obj4)
        {
          GestureDetector.GestureListener gestureListener = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(gestureListener, ToString);
          return GestureDetector.GestureListener.\u003Cdefault\u003Etap(gestureListener, obj1, obj2, obj3, obj4);
        }

        public static bool longPress([In] GestureDetector.GestureListener obj0, [In] float obj1, [In] float obj2)
        {
          GestureDetector.GestureListener gestureListener = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(gestureListener, ToString);
          return GestureDetector.GestureListener.\u003Cdefault\u003ElongPress(gestureListener, obj1, obj2);
        }

        public static bool fling(
          [In] GestureDetector.GestureListener obj0,
          [In] float obj1,
          [In] float obj2,
          [In] KeyCode obj3)
        {
          GestureDetector.GestureListener gestureListener = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(gestureListener, ToString);
          return GestureDetector.GestureListener.\u003Cdefault\u003Efling(gestureListener, obj1, obj2, obj3);
        }

        public static bool pan(
          [In] GestureDetector.GestureListener obj0,
          [In] float obj1,
          [In] float obj2,
          [In] float obj3,
          [In] float obj4)
        {
          GestureDetector.GestureListener gestureListener = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(gestureListener, ToString);
          return GestureDetector.GestureListener.\u003Cdefault\u003Epan(gestureListener, obj1, obj2, obj3, obj4);
        }

        public static bool panStop(
          [In] GestureDetector.GestureListener obj0,
          [In] float obj1,
          [In] float obj2,
          [In] int obj3,
          [In] KeyCode obj4)
        {
          GestureDetector.GestureListener gestureListener = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(gestureListener, ToString);
          return GestureDetector.GestureListener.\u003Cdefault\u003EpanStop(gestureListener, obj1, obj2, obj3, obj4);
        }

        public static bool zoom([In] GestureDetector.GestureListener obj0, [In] float obj1, [In] float obj2)
        {
          GestureDetector.GestureListener gestureListener = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(gestureListener, ToString);
          return GestureDetector.GestureListener.\u003Cdefault\u003Ezoom(gestureListener, obj1, obj2);
        }

        public static bool pinch(
          [In] GestureDetector.GestureListener obj0,
          [In] Vec2 obj1,
          [In] Vec2 obj2,
          [In] Vec2 obj3,
          [In] Vec2 obj4)
        {
          GestureDetector.GestureListener gestureListener = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(gestureListener, ToString);
          return GestureDetector.GestureListener.\u003Cdefault\u003Epinch(gestureListener, obj1, obj2, obj3, obj4);
        }

        public static void pinchStop([In] GestureDetector.GestureListener obj0)
        {
          GestureDetector.GestureListener gestureListener = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(gestureListener, ToString);
          GestureDetector.GestureListener.\u003Cdefault\u003EpinchStop(gestureListener);
        }
      }
    }

    internal class VelocityTracker : Object
    {
      internal int sampleSize;
      internal float lastX;
      internal float lastY;
      internal float deltaX;
      internal float deltaY;
      internal long lastTime;
      internal int numSamples;
      internal float[] meanX;
      internal float[] meanY;
      internal long[] meanTime;

      [LineNumberTable(new byte[] {160, 249, 104, 232, 69, 113, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal VelocityTracker()
      {
        GestureDetector.VelocityTracker velocityTracker = this;
        this.sampleSize = 10;
        this.meanX = new float[this.sampleSize];
        this.meanY = new float[this.sampleSize];
        this.meanTime = new long[this.sampleSize];
      }

      [LineNumberTable(new byte[] {161, 4, 104, 104, 107, 107, 103, 107, 109, 109, 234, 61, 230, 69, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void start([In] float obj0, [In] float obj1, [In] long obj2)
      {
        this.lastX = obj0;
        this.lastY = obj1;
        this.deltaX = 0.0f;
        this.deltaY = 0.0f;
        this.numSamples = 0;
        for (int index = 0; index < this.sampleSize; ++index)
        {
          this.meanX[index] = 0.0f;
          this.meanY[index] = 0.0f;
          this.meanTime[index] = 0L;
        }
        this.lastTime = obj2;
      }

      [LineNumberTable(new byte[] {161, 18, 112, 112, 104, 104, 105, 103, 119, 110, 110, 105, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void update([In] float obj0, [In] float obj1, [In] long obj2)
      {
        this.deltaX = obj0 - this.lastX;
        this.deltaY = obj1 - this.lastY;
        this.lastX = obj0;
        this.lastY = obj1;
        long num = obj2 - this.lastTime;
        this.lastTime = obj2;
        int numSamples = this.numSamples;
        int sampleSize = this.sampleSize;
        int index = sampleSize != -1 ? numSamples % sampleSize : 0;
        this.meanX[index] = this.deltaX;
        this.meanY[index] = this.deltaY;
        this.meanTime[index] = num;
        ++this.numSamples;
      }

      [LineNumberTable(new byte[] {161, 32, 116, 123, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float getVelocityX()
      {
        float average = this.getAverage(this.meanX, this.numSamples);
        float num = (float) this.getAverage(this.meanTime, this.numSamples) / 1E+09f;
        return (double) num == 0.0 ? 0.0f : average / num;
      }

      [LineNumberTable(new byte[] {161, 39, 116, 123, 110})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float getVelocityY()
      {
        float average = this.getAverage(this.meanY, this.numSamples);
        float num = (float) this.getAverage(this.meanTime, this.numSamples) / 1E+09f;
        return (double) num == 0.0 ? 0.0f : average / num;
      }

      [LineNumberTable(new byte[] {161, 46, 110, 102, 102, 39, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private float getAverage([In] float[] obj0, [In] int obj1)
      {
        obj1 = Math.min(this.sampleSize, obj1);
        float num = 0.0f;
        for (int index = 0; index < obj1; ++index)
          num += obj0[index];
        return num / (float) obj1;
      }

      [LineNumberTable(new byte[] {161, 55, 110, 99, 102, 38, 166, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private long getAverage([In] long[] obj0, [In] int obj1)
      {
        obj1 = Math.min(this.sampleSize, obj1);
        long num1 = 0;
        for (int index = 0; index < obj1; ++index)
          num1 += obj0[index];
        if (obj1 == 0)
          return 0;
        long num2 = num1;
        long num3 = (long) obj1;
        return num3 == -1L ? -num2 : num2 / num3;
      }

      [LineNumberTable(new byte[] {161, 65, 110, 102, 102, 39, 166, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private float getSum([In] float[] obj0, [In] int obj1)
      {
        obj1 = Math.min(this.sampleSize, obj1);
        float num = 0.0f;
        for (int index = 0; index < obj1; ++index)
          num += obj0[index];
        return obj1 == 0 ? 0.0f : num;
      }
    }
  }
}
