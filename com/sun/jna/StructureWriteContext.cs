// Decompiled with JetBrains decompiler
// Type: com.sun.jna.StructureWriteContext
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang.reflect;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class StructureWriteContext : ToNativeContext
  {
    private Structure @struct;
    private Field field;

    [LineNumberTable(new byte[] {159, 177, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal StructureWriteContext([In] Structure obj0, [In] Field obj1)
    {
      StructureWriteContext structureWriteContext = this;
      this.@struct = obj0;
      this.field = obj1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Structure getStructure() => this.@struct;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Field getField() => this.field;
  }
}
