// Decompiled with JetBrains decompiler
// Type: <Module>
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.runtime;
using java.lang;
using mindustry.desktop;
using System;
using System.Runtime.InteropServices;

internal class \u003CModule\u003E
{
  [STAThread]
  public static int main([In] string[] obj0)
  {
    int num;
    try
    {
      Startup.enterMainThread();
      DesktopLauncher.main(Startup.glob(obj0, 0));
    }
    catch (Exception ex)
    {
      Exception exception = Util.mapException(ex);
      Thread thread = Thread.currentThread();
      thread.getThreadGroup().uncaughtException(thread, exception);
      num = 1;
    }
    finally
    {
      Startup.exitMainThread();
    }
    return num;
  }
}
