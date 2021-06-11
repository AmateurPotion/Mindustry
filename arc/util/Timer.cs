// Decompiled with JetBrains decompiler
// Type: arc.util.Timer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace arc.util
{
  public class Timer : Object
  {
    [Modifiers]
    internal static object threadLock;
    internal static Timer.TimerThread thread;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/util/Timer$Task;>;")]
    internal Seq tasks;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(98)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Timer.Task schedule(
      Runnable task,
      float delaySeconds,
      float intervalSeconds)
    {
      return Timer.instance().scheduleTask((Timer.Task) new Timer.\u0032(task), delaySeconds, intervalSeconds);
    }

    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Timer.Task schedule(Runnable task, float delaySeconds) => Timer.instance().scheduleTask((Timer.Task) new Timer.\u0031(task), delaySeconds);

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Timer.Task schedule(Timer.Task task, float delaySeconds) => Timer.instance().scheduleTask(task, delaySeconds);

    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Timer.Task schedule(
      Timer.Task task,
      float delaySeconds,
      float intervalSeconds)
    {
      return Timer.instance().scheduleTask(task, delaySeconds, intervalSeconds);
    }

    [LineNumberTable(new byte[] {114, 108, 102, 103, 114, 103, 106, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void start()
    {
      object threadLock;
      System.Threading.Monitor.Enter(threadLock = Timer.threadLock);
      // ISSUE: fault handler
      try
      {
        Seq instances = Timer.thread().instances;
        if (instances.contains((object) this, true))
        {
          System.Threading.Monitor.Exit(threadLock);
        }
        else
        {
          instances.add((object) this);
          Object.instancehelper_notifyAll(Timer.threadLock);
          System.Threading.Monitor.Exit(threadLock);
        }
      }
      __fault
      {
        System.Threading.Monitor.Exit(threadLock);
      }
    }

    [LineNumberTable(new byte[] {159, 181, 108, 125, 113, 138, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Timer.TimerThread thread()
    {
      Timer.TimerThread thread;
      lock (Timer.threadLock)
      {
        if (Timer.thread == null || !object.ReferenceEquals((object) Timer.thread.files, (object) Core.files))
        {
          if (Timer.thread != null)
            Timer.thread.dispose();
          Timer.thread = new Timer.TimerThread();
        }
        thread = Timer.thread;
      }
      return thread;
    }

    [LineNumberTable(new byte[] {159, 164, 8, 173, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Timer()
    {
      Timer timer = this;
      this.tasks = new Seq(false, 8);
      this.start();
    }

    [LineNumberTable(new byte[] {159, 173, 108, 102, 115, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Timer instance()
    {
      Timer instance;
      lock (Timer.threadLock)
      {
        Timer.TimerThread timerThread = Timer.thread();
        if (timerThread.instance == null)
          timerThread.instance = new Timer();
        instance = timerThread.instance;
      }
      return instance;
    }

    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Timer.Task postTask(Timer.Task task) => this.scheduleTask(task, 0.0f, 0.0f, 0);

    [LineNumberTable(126)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Timer.Task scheduleTask(Timer.Task task, float delaySeconds) => this.scheduleTask(task, delaySeconds, 0.0f, 0);

    [LineNumberTable(131)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Timer.Task scheduleTask(
      Timer.Task task,
      float delaySeconds,
      float intervalSeconds)
    {
      return this.scheduleTask(task, delaySeconds, intervalSeconds, -1);
    }

    [LineNumberTable(new byte[] {89, 104, 104, 122, 110, 127, 2, 116, 104, 108, 127, 31, 117, 109, 106, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Timer.Task scheduleTask(
      Timer.Task task,
      float delaySeconds,
      float intervalSeconds,
      int repeatCount)
    {
      Timer timer;
      System.Threading.Monitor.Enter((object) (timer = this));
      Timer.Task task1;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        System.Threading.Monitor.Enter((object) (task1 = task));
        try
        {
          if (task.timer != null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("The same task may not be scheduled twice.");
          }
          task.timer = this;
          Thread.MemoryBarrier();
          task.executeTimeMillis = java.lang.System.nanoTime() / 1000000L + ByteCodeHelper.f2l(delaySeconds * 1000f);
          task.intervalMillis = ByteCodeHelper.f2l(intervalSeconds * 1000f);
          task.repeatCount = repeatCount;
          this.tasks.add((object) task);
          System.Threading.Monitor.Exit((object) task1);
          goto label_10;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        System.Threading.Monitor.Exit((object) timer);
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        System.Threading.Monitor.Exit((object) task1);
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      __fault
      {
        System.Threading.Monitor.Exit((object) timer);
      }
label_10:
      // ISSUE: fault handler
      try
      {
        System.Threading.Monitor.Exit((object) timer);
      }
      __fault
      {
        System.Threading.Monitor.Exit((object) timer);
      }
      lock (Timer.threadLock)
        Object.instancehelper_notifyAll(Timer.threadLock);
      return task;
    }

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Timer.Task post(Timer.Task task) => Timer.instance().postTask(task);

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Timer.Task schedule(
      Timer.Task task,
      float delaySeconds,
      float intervalSeconds,
      int repeatCount)
    {
      return Timer.instance().scheduleTask(task, delaySeconds, intervalSeconds, repeatCount);
    }

    [LineNumberTable(111)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Timer.Task schedule(
      Runnable task,
      float delaySeconds,
      float intervalSeconds,
      int repeatCount)
    {
      return Timer.instance().scheduleTask((Timer.Task) new Timer.\u0033(task), delaySeconds, intervalSeconds, repeatCount);
    }

    [LineNumberTable(new byte[] {107, 108, 114, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop()
    {
      lock (Timer.threadLock)
        Timer.thread().instances.remove((object) this, true);
    }

    [LineNumberTable(new byte[] {125, 114, 114, 104, 104, 110, 239, 59, 230, 71, 108})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      int index = 0;
      for (int size = this.tasks.size; index < size; ++index)
      {
        Timer.Task task = (Timer.Task) this.tasks.get(index);
        lock (task)
        {
          task.executeTimeMillis = 0L;
          task.timer = (Timer) null;
          Thread.MemoryBarrier();
        }
      }
      this.tasks.clear();
    }

    [LineNumberTable(190)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.tasks.size == 0;

    [LineNumberTable(new byte[] {160, 80, 117, 114, 104, 105, 112, 156, 104, 110, 109, 100, 134, 110, 110, 151, 108, 239, 46, 233, 84})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    internal virtual long update([In] long obj0, [In] long obj1)
    {
      int index = 0;
      for (int size = this.tasks.size; index < size; ++index)
      {
        Timer.Task task1 = (Timer.Task) this.tasks.get(index);
        Timer.Task task2;
        System.Threading.Monitor.Enter((object) (task2 = task1));
        // ISSUE: fault handler
        try
        {
          if (task1.executeTimeMillis > obj0)
          {
            obj1 = Math.min(obj1, task1.executeTimeMillis - obj0);
            System.Threading.Monitor.Exit((object) task2);
            continue;
          }
        }
        __fault
        {
          System.Threading.Monitor.Exit((object) task2);
        }
        try
        {
          if (task1.repeatCount == 0)
          {
            task1.timer = (Timer) null;
            Thread.MemoryBarrier();
            this.tasks.remove(index);
            index += -1;
            size += -1;
          }
          else
          {
            task1.executeTimeMillis = obj0 + task1.intervalMillis;
            obj1 = Math.min(obj1, task1.intervalMillis);
            if (task1.repeatCount > 0)
              --task1.repeatCount;
          }
          task1.app.post((Runnable) task1);
        }
        finally
        {
          System.Threading.Monitor.Exit((object) task2);
        }
      }
      return obj1;
    }

    [LineNumberTable(new byte[] {160, 105, 114, 114, 104, 110, 239, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void delay(long delayMillis)
    {
      int index = 0;
      for (int size = this.tasks.size; index < size; ++index)
      {
        Timer.Task task = (Timer.Task) this.tasks.get(index);
        lock (task)
          task.executeTimeMillis += delayMillis;
      }
    }

    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Timer()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.Timer"))
        return;
      Timer.threadLock = (object) new Object();
    }

    [InnerClass]
    [EnclosingMethod(null, "schedule", "(Ljava.lang.Runnable;F)Larc.util.Timer$Task;")]
    [SpecialName]
    internal class \u0031 : Timer.Task
    {
      [Modifiers]
      internal Runnable val\u0024task;

      [LineNumberTable(85)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Runnable obj0)
      {
        this.val\u0024task = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {38, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void run() => this.val\u0024task.run();
    }

    [InnerClass]
    [EnclosingMethod(null, "schedule", "(Ljava.lang.Runnable;FF)Larc.util.Timer$Task;")]
    [SpecialName]
    internal class \u0032 : Timer.Task
    {
      [Modifiers]
      internal Runnable val\u0024task;

      [LineNumberTable(98)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Runnable obj0)
      {
        this.val\u0024task = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {51, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void run() => this.val\u0024task.run();
    }

    [InnerClass]
    [EnclosingMethod(null, "schedule", "(Ljava.lang.Runnable;FFI)Larc.util.Timer$Task;")]
    [SpecialName]
    internal class \u0033 : Timer.Task
    {
      [Modifiers]
      internal Runnable val\u0024task;

      [LineNumberTable(111)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] Runnable obj0)
      {
        this.val\u0024task = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {64, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void run() => this.val\u0024task.run();
    }

    public abstract class Task : Object, Runnable
    {
      [Modifiers]
      internal Application app;
      internal long executeTimeMillis;
      internal long intervalMillis;
      internal int repeatCount;
      internal volatile Timer timer;

      [LineNumberTable(new byte[] {160, 136, 105, 102, 104, 104, 104, 110, 110, 127, 33, 151, 105, 104, 110, 144})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void cancel()
      {
        Timer timer1 = this.timer;
        if (timer1 != null)
        {
          Timer timer2;
          System.Threading.Monitor.Enter((object) (timer2 = timer1));
          Timer.Task task;
          Exception exception1;
          // ISSUE: fault handler
          try
          {
            System.Threading.Monitor.Enter((object) (task = this));
            try
            {
              this.executeTimeMillis = 0L;
              this.timer = (Timer) null;
              Thread.MemoryBarrier();
              timer1.tasks.remove((object) this, true);
              System.Threading.Monitor.Exit((object) task);
              goto label_9;
            }
            catch (Exception ex)
            {
              exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) timer2);
          }
          Exception exception2 = exception1;
          // ISSUE: fault handler
          try
          {
            Exception exception3 = exception2;
            System.Threading.Monitor.Exit((object) task);
            throw Throwable.__\u003Cunmap\u003E(exception3);
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) timer2);
          }
label_9:
          // ISSUE: fault handler
          try
          {
            System.Threading.Monitor.Exit((object) timer2);
          }
          __fault
          {
            System.Threading.Monitor.Exit((object) timer2);
          }
        }
        else
        {
          lock (this)
          {
            this.executeTimeMillis = 0L;
            this.timer = (Timer) null;
            Thread.MemoryBarrier();
          }
        }
      }

      [LineNumberTable(new byte[] {160, 123, 104, 107, 120})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Task()
      {
        Timer.Task task = this;
        this.app = Core.app;
        if (this.app == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("Core.app not available.");
        }
      }

      public abstract void run();

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool isScheduled() => this.timer != null;

      [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
      public virtual long getExecuteTimeMillis() => this.executeTimeMillis;
    }

    [Implements(new string[] {"java.lang.Runnable", "arc.ApplicationListener"})]
    internal class TimerThread : Object, Runnable, ApplicationListener
    {
      [Modifiers]
      internal Files files;
      [Modifiers]
      [Signature("Larc/struct/Seq<Larc/util/Timer;>;")]
      internal Seq instances;
      internal Timer instance;
      private long pauseMillis;

      [LineNumberTable(new byte[] {160, 247, 108, 115, 108, 106, 111, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void dispose()
      {
        lock (Timer.threadLock)
        {
          if (object.ReferenceEquals((object) Timer.thread, (object) this))
            Timer.thread = (Timer.TimerThread) null;
          this.instances.clear();
          Object.instancehelper_notifyAll(Timer.threadLock);
        }
        Core.app.removeListener((ApplicationListener) this);
      }

      [LineNumberTable(new byte[] {160, 184, 232, 60, 236, 69, 107, 107, 134, 108, 103, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TimerThread()
      {
        Timer.TimerThread timerThread = this;
        this.instances = new Seq(1);
        this.files = Core.files;
        Core.app.addListener((ApplicationListener) this);
        this.resume();
        Thread thread = new Thread((Runnable) this, nameof (Timer));
        thread.setDaemon(true);
        thread.start();
      }

      [LineNumberTable(new byte[] {160, 225, 109, 108, 116, 114, 55, 134, 104, 106, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void resume()
      {
        if (Core.app.isDesktop())
          return;
        lock (Timer.threadLock)
        {
          long delayMillis = java.lang.System.nanoTime() / 1000000L - this.pauseMillis;
          int index = 0;
          for (int size = this.instances.size; index < size; ++index)
            ((Timer) this.instances.get(index)).delay(delayMillis);
          this.pauseMillis = 0L;
          Object.instancehelper_notifyAll(Timer.threadLock);
        }
      }

      [LineNumberTable(new byte[] {160, 197, 108, 159, 28, 103, 106, 109, 159, 9, 191, 10, 28, 98, 255, 41, 60, 244, 73, 191, 25, 159, 3, 34, 129, 154, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void run()
      {
        object threadLock;
        int index;
        Exception exception1;
        while (true)
        {
          System.Threading.Monitor.Enter(threadLock = Timer.threadLock);
          // ISSUE: fault handler
          try
          {
            if (object.ReferenceEquals((object) Timer.thread, (object) this))
            {
              if (object.ReferenceEquals((object) this.files, (object) Core.files))
                goto label_5;
            }
            System.Threading.Monitor.Exit(threadLock);
            goto label_28;
          }
          __fault
          {
            System.Threading.Monitor.Exit(threadLock);
          }
label_5:
          long num1;
          long num2;
          int size;
          // ISSUE: fault handler
          try
          {
            num1 = 5000L;
            if (this.pauseMillis == 0L)
            {
              num2 = java.lang.System.nanoTime() / 1000000L;
              index = 0;
              size = this.instances.size;
            }
            else
              goto label_17;
          }
          __fault
          {
            System.Threading.Monitor.Exit(threadLock);
          }
          while (true)
          {
            // ISSUE: fault handler
            try
            {
              if (index < size)
              {
                try
                {
                  num1 = ((Timer) this.instances.get(index)).update(num2, num1);
                }
                catch (Exception ex)
                {
                  exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                  goto label_12;
                }
              }
              else
                break;
            }
            __fault
            {
              System.Threading.Monitor.Exit(threadLock);
            }
            // ISSUE: fault handler
            try
            {
              ++index;
            }
            __fault
            {
              System.Threading.Monitor.Exit(threadLock);
            }
          }
label_17:
          // ISSUE: fault handler
          try
          {
            if (object.ReferenceEquals((object) Timer.thread, (object) this))
            {
              if (object.ReferenceEquals((object) this.files, (object) Core.files))
                goto label_21;
            }
            System.Threading.Monitor.Exit(threadLock);
            goto label_28;
          }
          __fault
          {
            System.Threading.Monitor.Exit(threadLock);
          }
label_21:
          // ISSUE: fault handler
          try
          {
            if (num1 > 0L)
            {
              Object.instancehelper_wait(Timer.threadLock, num1);
              goto label_26;
            }
            else
              goto label_26;
          }
          catch (InterruptedException ex)
          {
          }
          __fault
          {
            System.Threading.Monitor.Exit(threadLock);
          }
label_26:
          // ISSUE: fault handler
          try
          {
            System.Threading.Monitor.Exit(threadLock);
          }
          __fault
          {
            System.Threading.Monitor.Exit(threadLock);
          }
        }
label_12:
        Exception exception2 = exception1;
        // ISSUE: fault handler
        try
        {
          Exception exception3 = exception2;
          string message = new StringBuilder().append("Task failed: ").append(Object.instancehelper_getClass((object) (Timer) this.instances.get(index)).getName()).toString();
          Exception t = exception3;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message, t);
        }
        __fault
        {
          System.Threading.Monitor.Exit(threadLock);
        }
label_28:
        this.dispose();
      }

      [LineNumberTable(new byte[] {160, 238, 109, 108, 114, 106, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void pause()
      {
        if (Core.app.isDesktop())
          return;
        lock (Timer.threadLock)
        {
          this.pauseMillis = java.lang.System.nanoTime() / 1000000L;
          Object.instancehelper_notifyAll(Timer.threadLock);
        }
      }

      [HideFromJava]
      public virtual void init() => ApplicationListener.\u003Cdefault\u003Einit((ApplicationListener) this);

      [HideFromJava]
      public virtual void resize([In] int obj0, [In] int obj1) => ApplicationListener.\u003Cdefault\u003Eresize((ApplicationListener) this, obj0, obj1);

      [HideFromJava]
      public virtual void update() => ApplicationListener.\u003Cdefault\u003Eupdate((ApplicationListener) this);

      [HideFromJava]
      public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);

      [HideFromJava]
      public virtual void fileDropped([In] Fi obj0) => ApplicationListener.\u003Cdefault\u003EfileDropped((ApplicationListener) this, obj0);
    }
  }
}
