// Decompiled with JetBrains decompiler
// Type: com.sun.jna.StructureReadContext
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang.reflect;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class StructureReadContext : FromNativeContext
  {
    private Structure structure;
    private Field field;

    [LineNumberTable(new byte[] {159, 178, 110, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal StructureReadContext([In] Structure obj0, [In] Field obj1)
      : base(obj1.getType())
    {
      StructureReadContext structureReadContext = this;
      this.structure = obj0;
      this.field = obj1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Structure getStructure() => this.structure;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Field getField() => this.field;
  }
}
