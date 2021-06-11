// Decompiled with JetBrains decompiler
// Type: arc.graphics.g2d.DrawRequest
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g2d
{
  [Signature("Ljava/lang/Object;Ljava/lang/Comparable<Larc/graphics/g2d/DrawRequest;>;")]
  [Implements(new string[] {"java.lang.Comparable"})]
  internal class DrawRequest : Object, Comparable
  {
    internal TextureRegion region;
    internal float x;
    internal float y;
    internal float z;
    internal float originX;
    internal float originY;
    internal float width;
    internal float height;
    internal float rotation;
    internal float color;
    internal float mixColor;
    internal float[] vertices;
    internal Texture texture;
    internal Blending blending;
    internal Runnable run;

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo([In] DrawRequest obj0) => Float.compare(this.z, obj0.z);

    [LineNumberTable(new byte[] {159, 147, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal DrawRequest()
    {
      DrawRequest drawRequest = this;
      this.region = new TextureRegion();
      this.vertices = new float[24];
    }

    [Modifiers]
    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo([In] object obj0) => this.compareTo((DrawRequest) obj0);

    int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
      [In] object obj0)
    {
      return this.compareTo(obj0);
    }
  }
}
