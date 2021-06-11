// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.BaseJsonReader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using java.io;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.serialization
{
  public interface BaseJsonReader
  {
    JsonValue parse(InputStream @is);

    [Modifiers]
    JsonValue parse(Fi file);

    [LineNumberTable(11)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static JsonValue \u003Cdefault\u003Eparse([In] BaseJsonReader obj0, [In] Fi obj1) => obj0.parse(obj1.read());

    [HideFromJava]
    static class __DefaultMethods
    {
      public static JsonValue parse([In] BaseJsonReader obj0, [In] Fi obj1)
      {
        BaseJsonReader baseJsonReader = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(baseJsonReader, ToString);
        return BaseJsonReader.\u003Cdefault\u003Eparse(baseJsonReader, obj1);
      }
    }
  }
}
