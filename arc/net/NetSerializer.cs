// Decompiled with JetBrains decompiler
// Type: arc.net.NetSerializer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.nio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.net
{
  public interface NetSerializer
  {
    void write(ByteBuffer bb, object obj);

    object read(ByteBuffer bb);

    [Modifiers]
    int getLengthLength();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static int \u003Cdefault\u003EgetLengthLength([In] NetSerializer obj0) => 2;

    [Modifiers]
    void writeLength(ByteBuffer buffer, int length);

    [LineNumberTable(new byte[] {159, 172, 105})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EwriteLength([In] NetSerializer obj0, [In] ByteBuffer obj1, [In] int obj2) => obj1.putShort((short) obj2);

    [Modifiers]
    int readLength(ByteBuffer buffer);

    [LineNumberTable(34)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static int \u003Cdefault\u003EreadLength([In] NetSerializer obj0, [In] ByteBuffer obj1) => (int) obj1.getShort();

    [HideFromJava]
    static class __DefaultMethods
    {
      public static int getLengthLength([In] NetSerializer obj0)
      {
        NetSerializer netSerializer = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(netSerializer, ToString);
        return NetSerializer.\u003Cdefault\u003EgetLengthLength(netSerializer);
      }

      public static void writeLength([In] NetSerializer obj0, [In] ByteBuffer obj1, [In] int obj2)
      {
        NetSerializer netSerializer = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(netSerializer, ToString);
        NetSerializer.\u003Cdefault\u003EwriteLength(netSerializer, obj1, obj2);
      }

      public static int readLength([In] NetSerializer obj0, [In] ByteBuffer obj1)
      {
        NetSerializer netSerializer = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(netSerializer, ToString);
        return NetSerializer.\u003Cdefault\u003EreadLength(netSerializer, obj1);
      }
    }
  }
}
