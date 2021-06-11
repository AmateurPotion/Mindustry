// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ptr.ByReference
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace com.sun.jna.ptr
{
  public abstract class ByReference : PointerType
  {
    [LineNumberTable(new byte[] {159, 183, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal ByReference(int dataSize)
    {
      ByReference byReference = this;
      this.setPointer((Pointer) new Memory((long) dataSize));
    }
  }
}
