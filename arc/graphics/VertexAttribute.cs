// Decompiled with JetBrains decompiler
// Type: arc.graphics.VertexAttribute
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public sealed class VertexAttribute : Object
  {
    internal static VertexAttribute __\u003C\u003Eposition;
    internal static VertexAttribute __\u003C\u003Eposition3;
    internal static VertexAttribute __\u003C\u003EtexCoords;
    internal static VertexAttribute __\u003C\u003Enormal;
    internal static VertexAttribute __\u003C\u003Ecolor;
    internal static VertexAttribute __\u003C\u003EmixColor;
    internal int __\u003C\u003Ecomponents;
    internal bool __\u003C\u003Enormalized;
    internal int __\u003C\u003Etype;
    internal string __\u003C\u003Ealias;
    internal int __\u003C\u003Esize;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 130, 162, 104, 103, 103, 103, 168, 98, 191, 35, 100, 162, 98, 162, 164, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VertexAttribute(int components, int type, bool normalized, string alias)
    {
      int num1 = normalized ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      VertexAttribute vertexAttribute = this;
      this.__\u003C\u003Ecomponents = components;
      this.__\u003C\u003Etype = type;
      this.__\u003C\u003Enormalized = num1 != 0;
      this.__\u003C\u003Ealias = alias;
      int num2 = 0;
      switch (type)
      {
        case 5120:
        case 5121:
          num2 = components;
          break;
        case 5122:
        case 5123:
          num2 = 2 * components;
          break;
        case 5126:
        case 5132:
          num2 = 4 * components;
          break;
      }
      this.__\u003C\u003Esize = num2;
    }

    [LineNumberTable(new byte[] {159, 181, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VertexAttribute(int components, string alias)
      : this(components, 5126, false, alias)
    {
    }

    [LineNumberTable(new byte[] {159, 139, 173, 112, 112, 112, 112, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static VertexAttribute()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.VertexAttribute"))
        return;
      VertexAttribute.__\u003C\u003Eposition = new VertexAttribute(2, "a_position");
      VertexAttribute.__\u003C\u003Eposition3 = new VertexAttribute(3, "a_position");
      VertexAttribute.__\u003C\u003EtexCoords = new VertexAttribute(2, "a_texCoord0");
      VertexAttribute.__\u003C\u003Enormal = new VertexAttribute(3, "a_normal");
      VertexAttribute.__\u003C\u003Ecolor = new VertexAttribute(4, 5121, true, "a_color");
      VertexAttribute.__\u003C\u003EmixColor = new VertexAttribute(4, 5121, true, "a_mix_color");
    }

    [Modifiers]
    public static VertexAttribute position
    {
      [HideFromJava] get => VertexAttribute.__\u003C\u003Eposition;
    }

    [Modifiers]
    public static VertexAttribute position3
    {
      [HideFromJava] get => VertexAttribute.__\u003C\u003Eposition3;
    }

    [Modifiers]
    public static VertexAttribute texCoords
    {
      [HideFromJava] get => VertexAttribute.__\u003C\u003EtexCoords;
    }

    [Modifiers]
    public static VertexAttribute normal
    {
      [HideFromJava] get => VertexAttribute.__\u003C\u003Enormal;
    }

    [Modifiers]
    public static VertexAttribute color
    {
      [HideFromJava] get => VertexAttribute.__\u003C\u003Ecolor;
    }

    [Modifiers]
    public static VertexAttribute mixColor
    {
      [HideFromJava] get => VertexAttribute.__\u003C\u003EmixColor;
    }

    [Modifiers]
    public int components
    {
      [HideFromJava] get => this.__\u003C\u003Ecomponents;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ecomponents = value;
    }

    [Modifiers]
    public bool normalized
    {
      [HideFromJava] get => this.__\u003C\u003Enormalized;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Enormalized = value;
    }

    [Modifiers]
    public int type
    {
      [HideFromJava] get => this.__\u003C\u003Etype;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etype = value;
    }

    [Modifiers]
    public string alias
    {
      [HideFromJava] get => this.__\u003C\u003Ealias;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ealias = value;
    }

    [Modifiers]
    public int size
    {
      [HideFromJava] get => this.__\u003C\u003Esize;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Esize = value;
    }
  }
}
