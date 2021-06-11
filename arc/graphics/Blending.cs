// Decompiled with JetBrains decompiler
// Type: arc.graphics.Blending
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  [Signature("Ljava/lang/Enum<Larc/graphics/Blending;>;")]
  [Modifiers]
  [Serializable]
  public class Blending : Enum
  {
    [Modifiers]
    internal static Blending __\u003C\u003Enormal;
    [Modifiers]
    internal static Blending __\u003C\u003Eadditive;
    [Modifiers]
    internal static Blending __\u003C\u003Edisabled;
    internal int __\u003C\u003Esrc;
    internal int __\u003C\u003Edst;
    [Modifiers]
    private static Blending[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 106, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void apply()
    {
      Gl.enable(3042);
      Gl.blendFunc(this.__\u003C\u003Esrc, this.__\u003C\u003Edst);
    }

    [Signature("(II)V")]
    [LineNumberTable(new byte[] {159, 159, 106, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Blending([In] string obj0, [In] int obj1, [In] int obj2, [In] int obj3)
      : base(obj0, obj1)
    {
      Blending blending = this;
      this.__\u003C\u003Esrc = obj2;
      this.__\u003C\u003Edst = obj3;
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Blending[] values() => (Blending[]) Blending.\u0024VALUES.Clone();

    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Blending valueOf(string name) => (Blending) Enum.valueOf((Class) ClassLiteral<Blending>.Value, name);

    [Modifiers]
    [LineNumberTable(4)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal Blending([In] string obj0, [In] int obj1, [In] int obj2, [In] int obj3, [In] Blending.\u0031 obj4)
      : this(obj0, obj1, obj2, obj3)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 141, 109, 122, 118, 250, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Blending()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.Blending"))
        return;
      Blending.__\u003C\u003Enormal = new Blending(nameof (normal), 0, 770, 771);
      Blending.__\u003C\u003Eadditive = new Blending(nameof (additive), 1, 770, 1);
      Blending.__\u003C\u003Edisabled = (Blending) new Blending.\u0031(nameof (disabled), 2, 770, 771);
      Blending.\u0024VALUES = new Blending[3]
      {
        Blending.__\u003C\u003Enormal,
        Blending.__\u003C\u003Eadditive,
        Blending.__\u003C\u003Edisabled
      };
    }

    [Modifiers]
    public static Blending normal
    {
      [HideFromJava] get => Blending.__\u003C\u003Enormal;
    }

    [Modifiers]
    public static Blending additive
    {
      [HideFromJava] get => Blending.__\u003C\u003Eadditive;
    }

    [Modifiers]
    public static Blending disabled
    {
      [HideFromJava] get => Blending.__\u003C\u003Edisabled;
    }

    [Modifiers]
    public int src
    {
      [HideFromJava] get => this.__\u003C\u003Esrc;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Esrc = value;
    }

    [Modifiers]
    public int dst
    {
      [HideFromJava] get => this.__\u003C\u003Edst;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Edst = value;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      normal,
      additive,
      disabled,
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [Serializable]
    [SpecialName]
    internal sealed class \u0031 : Blending
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(7)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] string obj0, [In] int obj1, [In] int obj2, [In] int obj3)
        : base(obj0, obj1, obj2, obj3, (Blending.\u0031) null)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(new byte[] {159, 153, 106})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void apply() => Gl.disable(3042);

      [HideFromJava]
      static \u0031() => Blending.__\u003Cclinit\u003E();
    }
  }
}
