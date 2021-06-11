// Decompiled with JetBrains decompiler
// Type: rhino.annotations.JSSetterAttribute
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace rhino.annotations
{
  [Modifiers]
  [InnerClass]
  [Implements(new string[] {"rhino.annotations.JSSetter"})]
  [AttributeUsage(AttributeTargets.Method)]
  public sealed class JSSetterAttribute : AnnotationAttributeBase, JSSetter
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    public JSSetterAttribute([In] object[] obj0)
      : this()
    {
      this.setDefinition(obj0);
    }

    public JSSetterAttribute()
      : base((Class) ClassLiteral<JSSetter>.Value)
    {
    }

    [HideFromJava]
    public JSSetterAttribute(string value)
      : this()
    {
      this.setValue(nameof (value), (object) value);
    }

    string JSSetter.value() => (string) this.getValue(nameof (value));
  }
}
