// Decompiled with JetBrains decompiler
// Type: arc.input.InputEventQueue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.input
{
  public class InputEventQueue : Object, InputProcessor
  {
    private const int SKIP = -1;
    private const int KEY_DOWN = 0;
    private const int KEY_UP = 1;
    private const int KEY_TYPED = 2;
    private const int TOUCH_DOWN = 3;
    private const int TOUCH_UP = 4;
    private const int TOUCH_DRAGGED = 5;
    private const int MOUSE_MOVED = 6;
    private const int SCROLLED = 7;
    [Modifiers]
    private IntSeq queue;
    [Modifiers]
    private IntSeq processingQueue;
    private InputProcessor processor;
    private long currentEventTime;

    [LineNumberTable(new byte[] {159, 167, 232, 59, 107, 235, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InputEventQueue()
    {
      InputEventQueue inputEventQueue = this;
      this.queue = new IntSeq();
      this.processingQueue = new IntSeq();
    }

    [LineNumberTable(new byte[] {88, 108, 102, 113})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool keyDown(KeyCode key)
    {
      this.queue.add(0);
      this.queueTime();
      this.queue.add(key.ordinal());
      return false;
    }

    [LineNumberTable(new byte[] {96, 108, 102, 113})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool keyUp(KeyCode key)
    {
      this.queue.add(1);
      this.queueTime();
      this.queue.add(key.ordinal());
      return false;
    }

    [LineNumberTable(new byte[] {159, 104, 130, 108, 102, 108})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool keyTyped(char character)
    {
      int num = (int) character;
      this.queue.add(2);
      this.queueTime();
      this.queue.add(num);
      return false;
    }

    [LineNumberTable(new byte[] {112, 108, 102, 108, 108, 108, 114})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool touchDown(int screenX, int screenY, int pointer, KeyCode button)
    {
      this.queue.add(3);
      this.queueTime();
      this.queue.add(screenX);
      this.queue.add(screenY);
      this.queue.add(pointer);
      this.queue.add(button.ordinal());
      return false;
    }

    [LineNumberTable(new byte[] {123, 108, 102, 108, 108, 108, 114})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool touchUp(int screenX, int screenY, int pointer, KeyCode button)
    {
      this.queue.add(4);
      this.queueTime();
      this.queue.add(screenX);
      this.queue.add(screenY);
      this.queue.add(pointer);
      this.queue.add(button.ordinal());
      return false;
    }

    [LineNumberTable(new byte[] {160, 71, 109, 113, 109, 239, 61, 237, 70, 108, 102, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool touchDragged(int screenX, int screenY, int pointer)
    {
      for (int index = this.next(5, 0); index >= 0; index = this.next(5, index + 6))
      {
        if (this.queue.get(index + 5) == pointer)
        {
          this.queue.set(index, -1);
          this.queue.set(index + 3, 3);
        }
      }
      this.queue.add(5);
      this.queueTime();
      this.queue.add(screenX);
      this.queue.add(screenY);
      this.queue.add(pointer);
      return false;
    }

    [LineNumberTable(new byte[] {160, 88, 109, 109, 15, 205, 108, 102, 108, 108})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool mouseMoved(int screenX, int screenY)
    {
      for (int index = this.next(6, 0); index >= 0; index = this.next(6, index + 5))
      {
        this.queue.set(index, -1);
        this.queue.set(index + 3, 2);
      }
      this.queue.add(6);
      this.queueTime();
      this.queue.add(screenX);
      this.queue.add(screenY);
      return false;
    }

    [LineNumberTable(new byte[] {160, 101, 108, 102, 121, 121})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool scrolled(float amountX, float amountY)
    {
      this.queue.add(7);
      this.queueTime();
      this.queue.add(ByteCodeHelper.f2i(amountX * 256f));
      this.queue.add(ByteCodeHelper.f2i(amountY * 256f));
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProcessor(InputProcessor processor) => this.processor = processor;

    [LineNumberTable(new byte[] {159, 183, 104, 104, 107, 136, 113, 107, 118, 108, 103, 119, 105, 127, 2, 159, 19, 102, 133, 115, 133, 115, 133, 111, 133, 127, 9, 133, 127, 9, 133, 124, 133, 117, 130, 127, 6, 130, 139, 101, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drain()
    {
      InputEventQueue inputEventQueue;
      System.Threading.Monitor.Enter((object) (inputEventQueue = this));
      // ISSUE: fault handler
      try
      {
        if (this.processor == null)
        {
          this.queue.clear();
          System.Threading.Monitor.Exit((object) inputEventQueue);
          return;
        }
        this.processingQueue.addAll(this.queue);
        this.queue.clear();
        System.Threading.Monitor.Exit((object) inputEventQueue);
      }
      __fault
      {
        System.Threading.Monitor.Exit((object) inputEventQueue);
      }
      int[] items = this.processingQueue.items;
      InputProcessor processor = this.processor;
      int num1 = 0;
      int size = this.processingQueue.size;
      while (num1 < size)
      {
        int[] numArray1 = items;
        int index1 = num1;
        int num2 = num1 + 1;
        int num3 = numArray1[index1];
        int[] numArray2 = items;
        int index2 = num2;
        int num4 = num2 + 1;
        long num5 = (long) numArray2[index2] << 32;
        int[] numArray3 = items;
        int index3 = num4;
        int index4 = num4 + 1;
        long num6 = (long) numArray3[index3] & (long) uint.MaxValue;
        this.currentEventTime = num5 | num6;
        switch (num3)
        {
          case -1:
            num1 = index4 + items[index4];
            continue;
          case 0:
            InputProcessor nputProcessor1 = processor;
            int[] numArray4 = items;
            int index5 = index4;
            num1 = index4 + 1;
            KeyCode keycode1 = KeyCode.byOrdinal(numArray4[index5]);
            nputProcessor1.keyDown(keycode1);
            continue;
          case 1:
            InputProcessor nputProcessor2 = processor;
            int[] numArray5 = items;
            int index6 = index4;
            num1 = index4 + 1;
            KeyCode keycode2 = KeyCode.byOrdinal(numArray5[index6]);
            nputProcessor2.keyUp(keycode2);
            continue;
          case 2:
            InputProcessor nputProcessor3 = processor;
            int[] numArray6 = items;
            int index7 = index4;
            num1 = index4 + 1;
            int num7 = (int) (ushort) numArray6[index7];
            nputProcessor3.keyTyped((char) num7);
            continue;
          case 3:
            InputProcessor nputProcessor4 = processor;
            int[] numArray7 = items;
            int index8 = index4;
            int num8 = index4 + 1;
            int screenX1 = numArray7[index8];
            int[] numArray8 = items;
            int index9 = num8;
            int num9 = num8 + 1;
            int screenY1 = numArray8[index9];
            int[] numArray9 = items;
            int index10 = num9;
            int num10 = num9 + 1;
            int pointer1 = numArray9[index10];
            int[] numArray10 = items;
            int index11 = num10;
            num1 = num10 + 1;
            KeyCode button1 = KeyCode.byOrdinal(numArray10[index11]);
            nputProcessor4.touchDown(screenX1, screenY1, pointer1, button1);
            continue;
          case 4:
            InputProcessor nputProcessor5 = processor;
            int[] numArray11 = items;
            int index12 = index4;
            int num11 = index4 + 1;
            int screenX2 = numArray11[index12];
            int[] numArray12 = items;
            int index13 = num11;
            int num12 = num11 + 1;
            int screenY2 = numArray12[index13];
            int[] numArray13 = items;
            int index14 = num12;
            int num13 = num12 + 1;
            int pointer2 = numArray13[index14];
            int[] numArray14 = items;
            int index15 = num13;
            num1 = num13 + 1;
            KeyCode button2 = KeyCode.byOrdinal(numArray14[index15]);
            nputProcessor5.touchUp(screenX2, screenY2, pointer2, button2);
            continue;
          case 5:
            InputProcessor nputProcessor6 = processor;
            int[] numArray15 = items;
            int index16 = index4;
            int num14 = index4 + 1;
            int screenX3 = numArray15[index16];
            int[] numArray16 = items;
            int index17 = num14;
            int num15 = num14 + 1;
            int screenY3 = numArray16[index17];
            int[] numArray17 = items;
            int index18 = num15;
            num1 = num15 + 1;
            int pointer3 = numArray17[index18];
            nputProcessor6.touchDragged(screenX3, screenY3, pointer3);
            continue;
          case 6:
            InputProcessor nputProcessor7 = processor;
            int[] numArray18 = items;
            int index19 = index4;
            int num16 = index4 + 1;
            int screenX4 = numArray18[index19];
            int[] numArray19 = items;
            int index20 = num16;
            num1 = num16 + 1;
            int screenY4 = numArray19[index20];
            nputProcessor7.mouseMoved(screenX4, screenY4);
            continue;
          case 7:
            InputProcessor nputProcessor8 = processor;
            int[] numArray20 = items;
            int index21 = index4;
            int num17 = index4 + 1;
            double num18 = (double) ((float) numArray20[index21] / 256f);
            int[] numArray21 = items;
            int index22 = num17;
            num1 = num17 + 1;
            double num19 = (double) ((float) numArray21[index22] / 256f);
            nputProcessor8.scrolled((float) num18, (float) num19);
            continue;
          default:
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException();
        }
      }
      this.processingQueue.clear();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getCurrentEventTime() => this.currentEventTime;

    [LineNumberTable(new byte[] {81, 102, 112, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void queueTime()
    {
      long num = Time.nanos();
      this.queue.add((int) (num >> 32));
      this.queue.add((int) num);
    }

    [LineNumberTable(new byte[] {40, 108, 115, 100, 102, 101, 159, 15, 103, 130, 101, 130, 101, 130, 101, 130, 101, 130, 101, 130, 101, 130, 101, 130, 101, 130, 139, 101})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    private int next([In] int obj0, [In] int obj1)
    {
      int[] items = this.queue.items;
      int size = this.queue.size;
      while (obj1 < size)
      {
        int num = items[obj1];
        if (num == obj0)
          return obj1;
        obj1 += 3;
        switch (num)
        {
          case -1:
            obj1 += items[obj1];
            continue;
          case 0:
            ++obj1;
            continue;
          case 1:
            ++obj1;
            continue;
          case 2:
            ++obj1;
            continue;
          case 3:
            obj1 += 4;
            continue;
          case 4:
            obj1 += 4;
            continue;
          case 5:
            obj1 += 3;
            continue;
          case 6:
            obj1 += 2;
            continue;
          case 7:
            obj1 += 2;
            continue;
          default:
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException();
        }
      }
      return -1;
    }

    [LineNumberTable(new byte[] {159, 170, 232, 56, 107, 235, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InputEventQueue(InputProcessor processor)
    {
      InputEventQueue inputEventQueue = this;
      this.queue = new IntSeq();
      this.processingQueue = new IntSeq();
      this.processor = processor;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual InputProcessor getProcessor() => this.processor;

    [HideFromJava]
    public virtual void connected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Econnected((InputProcessor) this, obj0);

    [HideFromJava]
    public virtual void disconnected([In] InputDevice obj0) => InputProcessor.\u003Cdefault\u003Edisconnected((InputProcessor) this, obj0);
  }
}
