// Decompiled with JetBrains decompiler
// Type: arc.util.ScreenRecorder
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class ScreenRecorder : Object
  {
    private static Runnable record;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 162, 127, 0, 99})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00240([In] Method obj0, [In] object obj1, [In] object[] obj2)
    {
      try
      {
        obj0.invoke(obj1, obj2, ScreenRecorder.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScreenRecorder()
    {
    }

    [LineNumberTable(new byte[] {159, 170, 104, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void record()
    {
      if (ScreenRecorder.record == null)
        return;
      ScreenRecorder.record.run();
    }

    [LineNumberTable(new byte[] {159, 139, 109, 112, 127, 3, 122, 119, 103, 255, 4, 70, 34, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ScreenRecorder()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.ScreenRecorder"))
        return;
      try
      {
        Class @class = Class.forName("arc.gif.GifRecorder", ScreenRecorder.__\u003CGetCallerID\u003E());
        object @object = @class.getConstructor(new Class[0], ScreenRecorder.__\u003CGetCallerID\u003E()).newInstance(new object[0], ScreenRecorder.__\u003CGetCallerID\u003E());
        Reflect.set(@object, "exportDirectory", (object) Core.files.local("../../gifs"));
        Method method = @class.getMethod("update", new Class[0], ScreenRecorder.__\u003CGetCallerID\u003E());
        object[] objArray = new object[0];
        ScreenRecorder.record = (Runnable) new ScreenRecorder.__\u003C\u003EAnon1(method, @object, objArray);
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (ScreenRecorder.__\u003CcallerID\u003E == null)
        ScreenRecorder.__\u003CcallerID\u003E = (CallerID) new ScreenRecorder.__\u003CCallerID\u003E();
      return ScreenRecorder.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly Method arg\u00241;
      private readonly object arg\u00242;
      private readonly object[] arg\u00243;

      internal __\u003C\u003EAnon1([In] Method obj0, [In] object obj1, [In] object[] obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => ScreenRecorder.lambda\u0024static\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }
  }
}
