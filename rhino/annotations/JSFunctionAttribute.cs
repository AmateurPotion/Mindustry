// Decompiled with JetBrains decompiler
// Type: rhino.annotations.JSFunctionAttribute
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
  [Implements(new string[] {"rhino.annotations.JSFunction"})]
  [AttributeUsage(AttributeTargets.Method)]
  public sealed class JSFunctionAttribute : AnnotationAttributeBase, JSFunction
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    public JSFunctionAttribute([In] object[] obj0)
      : this()
    {
      this.setDefinition(obj0);
    }

    public JSFunctionAttribute()
      : base((Class) ClassLiteral<JSFunction>.Value)
    {
    }

    [HideFromJava]
    public JSFunctionAttribute(string value)
      : this()
    {
      this.setValue(nameof (value), (object) value);
    }

    string JSFunction.value() => (string) this.getValue(nameof (value));
  }
}
