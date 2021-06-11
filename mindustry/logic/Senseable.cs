// Decompiled with JetBrains decompiler
// Type: mindustry.logic.Senseable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.ctype;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.logic
{
  public interface Senseable
  {
    static readonly object noSensed;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void __\u003Cclinit\u003E()
    {
    }

    double sense(LAccess la);

    double sense(Content c);

    [Modifiers]
    object senseObject(LAccess sensor);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static object \u003Cdefault\u003EsenseObject([In] Senseable obj0, [In] LAccess obj1) => Senseable.noSensed;

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Senseable()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.logic.Senseable"))
        return;
      Senseable.noSensed = (object) new Object();
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static object senseObject([In] Senseable obj0, [In] LAccess obj1)
      {
        Senseable senseable = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(senseable, ToString);
        return Senseable.\u003Cdefault\u003EsenseObject(senseable, obj1);
      }
    }

    [HideFromJava]
    static class __Fields
    {
      public static readonly object noSensed = Senseable.noSensed;
    }
  }
}
