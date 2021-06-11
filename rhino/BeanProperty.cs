// Decompiled with JetBrains decompiler
// Type: rhino.BeanProperty
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [SourceFile("JavaMembers.java")]
  internal class BeanProperty : Object
  {
    internal MemberBox getter;
    internal MemberBox setter;
    internal NativeJavaMethod setters;

    [LineNumberTable(new byte[] {162, 196, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal BeanProperty([In] MemberBox obj0, [In] MemberBox obj1, [In] NativeJavaMethod obj2)
    {
      BeanProperty beanProperty = this;
      this.getter = obj0;
      this.setter = obj1;
      this.setters = obj2;
    }
  }
}
