// Decompiled with JetBrains decompiler
// Type: mindustry.net.Packet
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.pooling;
using IKVM.Attributes;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  [Implements(new string[] {"arc.util.pooling.Pool$Poolable"})]
  public interface Packet : Pool.Poolable
  {
    [Modifiers]
    void read(ByteBuffer buffer);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eread([In] Packet obj0, [In] ByteBuffer obj1)
    {
    }

    [Modifiers]
    void write(ByteBuffer buffer);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Ewrite([In] Packet obj0, [In] ByteBuffer obj1)
    {
    }

    [Modifiers]
    bool isImportant();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisImportant([In] Packet obj0) => false;

    [Modifiers]
    bool isUnimportant();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisUnimportant([In] Packet obj0) => false;

    [Modifiers]
    new void reset();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Ereset([In] Packet obj0)
    {
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static void read([In] Packet obj0, [In] ByteBuffer obj1)
      {
        Packet packet = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(packet, ToString);
        Packet.\u003Cdefault\u003Eread(packet, obj1);
      }

      public static void write([In] Packet obj0, [In] ByteBuffer obj1)
      {
        Packet packet = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(packet, ToString);
        Packet.\u003Cdefault\u003Ewrite(packet, obj1);
      }

      public static void reset([In] Packet obj0)
      {
        Packet packet = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(packet, ToString);
        Packet.\u003Cdefault\u003Ereset(packet);
      }

      public static bool isImportant([In] Packet obj0)
      {
        Packet packet = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(packet, ToString);
        return Packet.\u003Cdefault\u003EisImportant(packet);
      }

      public static bool isUnimportant([In] Packet obj0)
      {
        Packet packet = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(packet, ToString);
        return Packet.\u003Cdefault\u003EisUnimportant(packet);
      }
    }
  }
}
