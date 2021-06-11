// Decompiled with JetBrains decompiler
// Type: com.sun.jna.NativeLong
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using System.Runtime.CompilerServices;

namespace com.sun.jna
{
  public class NativeLong : IntegerType
  {
    private const long serialVersionUID = 1;
    internal static int __\u003C\u003ESIZE;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 186, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeLong(long value)
      : this(value, false)
    {
    }

    [LineNumberTable(new byte[] {159, 130, 98, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeLong(long value, bool unsigned)
    {
      int num = unsigned ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(NativeLong.__\u003C\u003ESIZE, value, num != 0);
    }

    [LineNumberTable(new byte[] {159, 181, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeLong()
      : this(0L)
    {
    }

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeLong()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.NativeLong"))
        return;
      NativeLong.__\u003C\u003ESIZE = Native.__\u003C\u003ELONG_SIZE;
    }

    [Modifiers]
    public static int SIZE
    {
      [HideFromJava] get => NativeLong.__\u003C\u003ESIZE;
    }
  }
}
