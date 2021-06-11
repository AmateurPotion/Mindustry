// Decompiled with JetBrains decompiler
// Type: rhino.ResolvedOverload
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [SourceFile("NativeJavaMethod.java")]
  internal class ResolvedOverload : Object
  {
    [Modifiers]
    [Signature("[Ljava/lang/Class<*>;")]
    internal Class[] types;
    [Modifiers]
    internal int index;

    [LineNumberTable(new byte[] {161, 174, 107, 130, 105, 100, 104, 108, 99, 108, 117, 226, 57, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool matches([In] object[] obj0)
    {
      if (obj0.Length != this.types.Length)
        return false;
      int index = 0;
      for (int length = obj0.Length; index < length; ++index)
      {
        object obj = obj0[index];
        if (obj is Wrapper)
          obj = ((Wrapper) obj).unwrap();
        if (obj == null)
        {
          if (this.types[index] != null)
            return false;
        }
        else if (!object.ReferenceEquals((object) Object.instancehelper_getClass(obj), (object) this.types[index]))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 162, 104, 103, 109, 105, 100, 104, 108, 244, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ResolvedOverload([In] object[] obj0, [In] int obj1)
    {
      ResolvedOverload resolvedOverload = this;
      this.index = obj1;
      this.types = new Class[obj0.Length];
      int index = 0;
      for (int length = obj0.Length; index < length; ++index)
      {
        object obj = obj0[index];
        if (obj is Wrapper)
          obj = ((Wrapper) obj).unwrap();
        this.types[index] = obj != null ? Object.instancehelper_getClass(obj) : (Class) null;
      }
    }

    [LineNumberTable(new byte[] {161, 192, 104, 130, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals([In] object obj0)
    {
      if (!(obj0 is ResolvedOverload))
        return false;
      ResolvedOverload resolvedOverload = (ResolvedOverload) obj0;
      return Arrays.equals((object[]) this.types, (object[]) resolvedOverload.types) && this.index == resolvedOverload.index;
    }

    [LineNumberTable(571)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => Arrays.hashCode((object[]) this.types);
  }
}
