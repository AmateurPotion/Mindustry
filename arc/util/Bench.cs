// Decompiled with JetBrains decompiler
// Type: arc.util.Bench
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class Bench : Object
  {
    private static long totalStart;
    private static string lastName;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/Long;>;")]
    private static ObjectMap times;
    private static long last;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 174, 127, 0, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void endi()
    {
      Bench.times.put((object) Bench.lastName, (object) Long.valueOf(Time.timeSinceMillis(Bench.last)));
      Bench.lastName = (string) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 168, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024end\u00240([In] long obj0, [In] string obj1, [In] Long obj2) => Log.info("[PERF] @: @ms (@%)", (object) obj1, (object) obj2, (object) Integer.valueOf(ByteCodeHelper.f2i((float) obj2.longValue() / (float) obj0 * 100f)));

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Bench()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 103, 135, 138, 106, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void begin(string name)
    {
      if (Bench.lastName != null)
        Bench.endi();
      else
        Bench.totalStart = Time.millis();
      Bench.last = Time.millis();
      Bench.lastName = name;
    }

    [LineNumberTable(new byte[] {159, 164, 101, 139, 181, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void end()
    {
      Bench.endi();
      long num = Time.timeSinceMillis(Bench.totalStart);
      Bench.times.each((Cons2) new Bench.__\u003C\u003EAnon0(num));
      Log.info("[PERF] TOTAL: @ms", (object) Long.valueOf(num));
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Bench()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.Bench"))
        return;
      Bench.times = new ObjectMap();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons2
    {
      private readonly long arg\u00241;

      internal __\u003C\u003EAnon0([In] long obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => Bench.lambda\u0024end\u00240(this.arg\u00241, (string) obj0, (Long) obj1);
    }
  }
}
