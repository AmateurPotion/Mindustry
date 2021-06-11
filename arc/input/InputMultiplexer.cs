// Decompiled with JetBrains decompiler
// Type: arc.input.InputMultiplexer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.input
{
  public class InputMultiplexer : Object, InputProcessor
  {
    [Signature("Larc/struct/SnapshotSeq<Larc/input/InputProcessor;>;")]
    private SnapshotSeq processors;

    [LineNumberTable(new byte[] {159, 159, 232, 59, 236, 70, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InputMultiplexer(params InputProcessor[] processors)
    {
      InputMultiplexer inputMultiplexer = this;
      this.processors = new SnapshotSeq(4);
      this.processors.addAll((object[]) processors);
    }

    [LineNumberTable(new byte[] {159, 173, 115, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addProcessor(InputProcessor processor)
    {
      if (processor == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("processor cannot be null");
      }
      this.processors.add((object) processor);
    }

    [LineNumberTable(new byte[] {159, 178, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeProcessor(InputProcessor processor) => this.processors.remove((object) processor, true);

    [Signature("()Larc/struct/SnapshotSeq<Larc/input/InputProcessor;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SnapshotSeq getProcessors() => this.processors;

    [LineNumberTable(new byte[] {159, 156, 8, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InputMultiplexer()
    {
      InputMultiplexer inputMultiplexer = this;
      this.processors = new SnapshotSeq(4);
    }

    [LineNumberTable(new byte[] {159, 164, 115, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addProcessor(int index, InputProcessor processor)
    {
      if (processor == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("processor cannot be null");
      }
      this.processors.insert(index, (object) processor);
    }

    [LineNumberTable(new byte[] {159, 169, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeProcessor(int index) => this.processors.remove(index);

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.processors.size;

    [LineNumberTable(new byte[] {159, 187, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear() => this.processors.clear();

    [LineNumberTable(new byte[] {3, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProcessors(params InputProcessor[] processors)
    {
      this.processors.clear();
      this.processors.addAll((object[]) processors);
    }

    [Signature("(Larc/struct/Seq<Larc/input/InputProcessor;>;)V")]
    [LineNumberTable(new byte[] {8, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProcessors(Seq processors)
    {
      this.processors.clear();
      this.processors.addAll(processors);
    }

    [LineNumberTable(new byte[] {14, 140, 114, 46, 168, 107, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void connected(InputDevice device)
    {
      object[] objArray = this.processors.begin();
      try
      {
        int index = 0;
        for (int size = this.processors.size; index < size; ++index)
          ((InputProcessor) objArray[index]).connected(device);
      }
      finally
      {
        this.processors.end();
      }
    }

    [LineNumberTable(new byte[] {25, 140, 114, 46, 168, 107, 35, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disconnected(InputDevice device)
    {
      object[] objArray = this.processors.begin();
      try
      {
        int index = 0;
        for (int size = this.processors.size; index < size; ++index)
          ((InputProcessor) objArray[index]).disconnected(device);
      }
      finally
      {
        this.processors.end();
      }
    }

    [LineNumberTable(new byte[] {36, 140, 178, 107, 231, 61, 154, 107, 39, 11, 34, 168, 107, 38, 107, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyDown(KeyCode keycode)
    {
      object[] objArray = this.processors.begin();
      int index;
      int size;
      // ISSUE: fault handler
      try
      {
        index = 0;
        size = this.processors.size;
      }
      __fault
      {
        this.processors.end();
      }
      int num;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            if (((InputProcessor) objArray[index]).keyDown(keycode))
            {
              num = 1;
              break;
            }
          }
          else
            goto label_10;
        }
        __fault
        {
          this.processors.end();
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          this.processors.end();
        }
      }
      this.processors.end();
      return num != 0;
label_10:
      this.processors.end();
      return false;
    }

    [LineNumberTable(new byte[] {48, 140, 178, 107, 231, 61, 154, 107, 39, 11, 34, 168, 107, 38, 107, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyUp(KeyCode keycode)
    {
      object[] objArray = this.processors.begin();
      int index;
      int size;
      // ISSUE: fault handler
      try
      {
        index = 0;
        size = this.processors.size;
      }
      __fault
      {
        this.processors.end();
      }
      int num;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            if (((InputProcessor) objArray[index]).keyUp(keycode))
            {
              num = 1;
              break;
            }
          }
          else
            goto label_10;
        }
        __fault
        {
          this.processors.end();
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          this.processors.end();
        }
      }
      this.processors.end();
      return num != 0;
label_10:
      this.processors.end();
      return false;
    }

    [LineNumberTable(new byte[] {159, 115, 130, 140, 178, 107, 231, 61, 155, 107, 39, 11, 35, 168, 107, 38, 107, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyTyped(char character)
    {
      int num1 = (int) character;
      object[] objArray = this.processors.begin();
      int index;
      int size;
      // ISSUE: fault handler
      try
      {
        index = 0;
        size = this.processors.size;
      }
      __fault
      {
        this.processors.end();
      }
      int num2;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            if (((InputProcessor) objArray[index]).keyTyped((char) num1))
            {
              num2 = 1;
              break;
            }
          }
          else
            goto label_10;
        }
        __fault
        {
          this.processors.end();
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          this.processors.end();
        }
      }
      this.processors.end();
      return num2 != 0;
label_10:
      this.processors.end();
      return false;
    }

    [LineNumberTable(new byte[] {72, 140, 178, 107, 231, 61, 158, 107, 39, 11, 34, 168, 107, 38, 107, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDown(int screenX, int screenY, int pointer, KeyCode button)
    {
      object[] objArray = this.processors.begin();
      int index;
      int size;
      // ISSUE: fault handler
      try
      {
        index = 0;
        size = this.processors.size;
      }
      __fault
      {
        this.processors.end();
      }
      int num;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            if (((InputProcessor) objArray[index]).touchDown(screenX, screenY, pointer, button))
            {
              num = 1;
              break;
            }
          }
          else
            goto label_10;
        }
        __fault
        {
          this.processors.end();
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          this.processors.end();
        }
      }
      this.processors.end();
      return num != 0;
label_10:
      this.processors.end();
      return false;
    }

    [LineNumberTable(new byte[] {84, 140, 178, 107, 231, 61, 158, 107, 39, 11, 34, 168, 107, 38, 107, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchUp(int screenX, int screenY, int pointer, KeyCode button)
    {
      object[] objArray = this.processors.begin();
      int index;
      int size;
      // ISSUE: fault handler
      try
      {
        index = 0;
        size = this.processors.size;
      }
      __fault
      {
        this.processors.end();
      }
      int num;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            if (((InputProcessor) objArray[index]).touchUp(screenX, screenY, pointer, button))
            {
              num = 1;
              break;
            }
          }
          else
            goto label_10;
        }
        __fault
        {
          this.processors.end();
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          this.processors.end();
        }
      }
      this.processors.end();
      return num != 0;
label_10:
      this.processors.end();
      return false;
    }

    [LineNumberTable(new byte[] {96, 140, 178, 107, 231, 61, 156, 107, 39, 11, 34, 168, 107, 38, 107, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool touchDragged(int screenX, int screenY, int pointer)
    {
      object[] objArray = this.processors.begin();
      int index;
      int size;
      // ISSUE: fault handler
      try
      {
        index = 0;
        size = this.processors.size;
      }
      __fault
      {
        this.processors.end();
      }
      int num;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            if (((InputProcessor) objArray[index]).touchDragged(screenX, screenY, pointer))
            {
              num = 1;
              break;
            }
          }
          else
            goto label_10;
        }
        __fault
        {
          this.processors.end();
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          this.processors.end();
        }
      }
      this.processors.end();
      return num != 0;
label_10:
      this.processors.end();
      return false;
    }

    [LineNumberTable(new byte[] {108, 140, 178, 107, 231, 61, 155, 107, 39, 11, 34, 168, 107, 38, 107, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool mouseMoved(int screenX, int screenY)
    {
      object[] objArray = this.processors.begin();
      int index;
      int size;
      // ISSUE: fault handler
      try
      {
        index = 0;
        size = this.processors.size;
      }
      __fault
      {
        this.processors.end();
      }
      int num;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            if (((InputProcessor) objArray[index]).mouseMoved(screenX, screenY))
            {
              num = 1;
              break;
            }
          }
          else
            goto label_10;
        }
        __fault
        {
          this.processors.end();
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          this.processors.end();
        }
      }
      this.processors.end();
      return num != 0;
label_10:
      this.processors.end();
      return false;
    }

    [LineNumberTable(new byte[] {120, 140, 178, 107, 231, 61, 157, 107, 39, 11, 34, 168, 107, 38, 107, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool scrolled(float amountX, float amountY)
    {
      object[] objArray = this.processors.begin();
      int index;
      int size;
      // ISSUE: fault handler
      try
      {
        index = 0;
        size = this.processors.size;
      }
      __fault
      {
        this.processors.end();
      }
      int num;
      while (true)
      {
        // ISSUE: fault handler
        try
        {
          if (index < size)
          {
            if (((InputProcessor) objArray[index]).scrolled(amountX, amountY))
            {
              num = 1;
              break;
            }
          }
          else
            goto label_10;
        }
        __fault
        {
          this.processors.end();
        }
        // ISSUE: fault handler
        try
        {
          ++index;
        }
        __fault
        {
          this.processors.end();
        }
      }
      this.processors.end();
      return num != 0;
label_10:
      this.processors.end();
      return false;
    }
  }
}
