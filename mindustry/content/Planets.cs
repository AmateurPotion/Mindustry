// Decompiled with JetBrains decompiler
// Type: mindustry.content.Planets
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.graphics.g3d;
using mindustry.maps.generators;
using mindustry.maps.planet;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.content
{
  public class Planets : Object, ContentList
  {
    public static Planet sun;
    public static Planet serpulo;

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Planets()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 247, 92, 255, 1, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      Planets.sun = (Planet) new Planets.\u0031(this, "sun", (Planet) null, 0, 2f);
      Planets.\u0032.__\u003Cclinit\u003E();
      Planets.serpulo = (Planet) new Planets.\u0032(this, "serpulo", Planets.sun, 3, 1f);
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : Planet
    {
      [Modifiers]
      internal Planets this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {159, 165, 223, 30, 109, 109, 109, 109, 109, 235, 55})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PlanetMesh lambda\u0024new\u00240() => (PlanetMesh) new SunMesh((Planet) this, 4, 5.0, 0.3, 1.7, 1.2, 1.0, 1.1f, new Color[6]
      {
        Color.valueOf("ff7a38"),
        Color.valueOf("ff9638"),
        Color.valueOf("ffc64c"),
        Color.valueOf("ffc64c"),
        Color.valueOf("ffe371"),
        Color.valueOf("f4ee8e")
      });

      [LineNumberTable(new byte[] {159, 159, 118, 103, 199, 241, 75})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Planets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3, [In] float obj4)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3, obj4);
        Planets.\u0031 obj = this;
        this.bloom = true;
        this.accessible = false;
        this.meshLoader = (Prov) new Planets.\u0031.__\u003C\u003EAnon0(this);
      }

      [HideFromJava]
      static \u0031() => Planet.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        private readonly Planets.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] Planets.\u0031 obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024new\u00240();
      }
    }

    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : Planet
    {
      [Modifiers]
      internal Planets this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 187, 118, 107, 113, 112, 107, 107, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] Planets obj0, [In] string obj1, [In] Planet obj2, [In] int obj3, [In] float obj4)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3, obj4);
        Planets.\u0032 obj = this;
        this.generator = (PlanetGenerator) new SerpuloPlanetGenerator();
        this.meshLoader = (Prov) new Planets.\u0032.__\u003C\u003EAnon0(this);
        this.atmosphereColor = Color.valueOf("3c1b8f");
        this.atmosphereRadIn = 0.02f;
        this.atmosphereRadOut = 0.3f;
        this.startSector = 15;
      }

      [Modifiers]
      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PlanetMesh lambda\u0024new\u00240() => (PlanetMesh) new HexMesh((Planet) this, 6);

      [HideFromJava]
      static \u0032() => Planet.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Prov
      {
        private readonly Planets.\u0032 arg\u00241;

        internal __\u003C\u003EAnon0([In] Planets.\u0032 obj0) => this.arg\u00241 = obj0;

        public object get() => (object) this.arg\u00241.lambda\u0024new\u00240();
      }
    }
  }
}
