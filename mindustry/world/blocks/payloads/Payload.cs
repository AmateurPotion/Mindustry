// Decompiled with JetBrains decompiler
// Type: mindustry.world.blocks.payloads.Payload
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics.g2d;
using arc.util.io;
using IKVM.Attributes;
using java.lang;
using mindustry.game;
using mindustry.gen;
using mindustry.ui;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.blocks.payloads
{
  public interface Payload
  {
    const int payloadUnit = 0;
    const int payloadBlock = 1;

    void set(float f1, float f2, float f3);

    void draw();

    float size();

    TextureRegion icon(Cicon c);

    [LineNumberTable(new byte[] {159, 189, 99, 137, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void write([arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})] Payload payload, Writes write)
    {
      if (payload == null)
      {
        write.@bool(false);
      }
      else
      {
        write.@bool(true);
        payload.write(write);
      }
    }

    [Signature("<T::Lmindustry/world/blocks/payloads/Payload;>(Larc/util/io/Reads;)TT;")]
    [LineNumberTable(new byte[] {8, 103, 133, 104, 100, 113, 108, 105, 110, 98, 99, 105, 127, 26, 115, 104, 136})]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Payload read(Reads read)
    {
      if (!read.@bool())
        return (Payload) null;
      int num1 = (int) (sbyte) read.b();
      switch (num1)
      {
        case 0:
          int id = (int) (sbyte) read.b();
          if (EntityMapping.map(id) == null)
          {
            string str = new StringBuilder().append("No type with ID ").append(id).append(" found.").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException(str);
          }
          Unit unit = (Unit) EntityMapping.map(id).get();
          unit.read(read);
          return (Payload) new UnitPayload(unit);
        case 1:
          BuildPayload buildPayload = new BuildPayload(Vars.content.block((int) read.s()), Team.__\u003C\u003Ederelict);
          int num2 = (int) (sbyte) read.b();
          buildPayload.build.readAll(read, (byte) num2);
          return (Payload) buildPayload;
        default:
          string str1 = new StringBuilder().append("Unknown payload type: ").append(num1).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str1);
      }
    }

    [Modifiers]
    bool dump();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003Edump([In] Payload obj0) => false;

    [Modifiers]
    bool fits(float s);

    [LineNumberTable(32)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003Efits([In] Payload obj0, [In] float obj1) => (double) (obj0.size() / 8f) <= (double) obj1;

    [Modifiers]
    float rotation();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static float \u003Cdefault\u003Erotation([In] Payload obj0) => 0.0f;

    void write(Writes w);

    [HideFromJava]
    static class __DefaultMethods
    {
      public static bool dump([In] Payload obj0)
      {
        Payload payload = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(payload, ToString);
        return Payload.\u003Cdefault\u003Edump(payload);
      }

      public static bool fits([In] Payload obj0, [In] float obj1)
      {
        Payload payload = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(payload, ToString);
        return Payload.\u003Cdefault\u003Efits(payload, obj1);
      }

      public static float rotation([In] Payload obj0)
      {
        Payload payload = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(payload, ToString);
        return Payload.\u003Cdefault\u003Erotation(payload);
      }
    }

    [HideFromJava]
    static class __Fields
    {
      public const int payloadUnit = 0;
      public const int payloadBlock = 1;
    }

    [HideFromJava]
    static class __Methods
    {
      public static void write([In] Payload obj0, [In] Writes obj1) => Payload.write(obj0, obj1);

      public static Payload read([In] Reads obj0) => Payload.read(obj0);
    }
  }
}
