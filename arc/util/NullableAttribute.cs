// Decompiled with JetBrains decompiler
// Type: arc.util.NullableAttribute
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace arc.util
{
  [Modifiers]
  [InnerClass]
  [Implements(new string[] {"arc.util.Nullable"})]
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Parameter)]
  public sealed class NullableAttribute : AnnotationAttributeBase, Nullable
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    public NullableAttribute([In] object[] obj0)
      : this()
    {
      this.setDefinition(obj0);
    }

    public NullableAttribute()
      : base((Class) ClassLiteral<Nullable>.Value)
    {
    }
  }
}
