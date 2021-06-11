// Decompiled with JetBrains decompiler
// Type: mindustry.entities.Effect
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.gen;
using mindustry.graphics;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities
{
  public class Effect : Object
  {
    private const float shakeFalloff = 10000f;
    [Modifiers]
    private static Effect.EffectContainer container;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/entities/Effect;>;")]
    private static Seq all;
    private bool initialized;
    internal int __\u003C\u003Eid;
    [Signature("Larc/func/Cons<Lmindustry/entities/Effect$EffectContainer;>;")]
    public Cons renderer;
    public float lifetime;
    public float clip;
    public float layer;
    public float layerDuration;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {18, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void at(Position pos) => Effect.create(this, pos.getX(), pos.getY(), 0.0f, Color.__\u003C\u003Ewhite, (object) null);

    [LineNumberTable(new byte[] {30, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void at(float x, float y, float rotation) => Effect.create(this, x, y, rotation, Color.__\u003C\u003Ewhite, (object) null);

    [LineNumberTable(new byte[] {46, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void at(float x, float y, float rotation, object data) => Effect.create(this, x, y, rotation, Color.__\u003C\u003Ewhite, data);

    [LineNumberTable(new byte[] {26, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void at(float x, float y) => Effect.create(this, x, y, 0.0f, Color.__\u003C\u003Ewhite, (object) null);

    [LineNumberTable(new byte[] {22, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void at(Position pos, float rotation) => Effect.create(this, pos.getX(), pos.getY(), rotation, Color.__\u003C\u003Ewhite, (object) null);

    [LineNumberTable(new byte[] {34, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void at(float x, float y, float rotation, Color color) => Effect.create(this, x, y, rotation, color, (object) null);

    [LineNumberTable(new byte[] {83, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shake(float intensity, float duration, Position loc) => Effect.shake(intensity, duration, loc.getX(), loc.getY());

    [LineNumberTable(new byte[] {42, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void at(float x, float y, float rotation, Color color, object data) => Effect.create(this, x, y, rotation, color, data);

    [LineNumberTable(new byte[] {38, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void at(float x, float y, Color color) => Effect.create(this, x, y, 0.0f, color, (object) null);

    [Signature("(FFLarc/func/Cons<Lmindustry/entities/Effect$EffectContainer;>;)V")]
    [LineNumberTable(new byte[] {159, 178, 232, 56, 112, 203, 203, 112, 104, 103, 104, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Effect(float life, float clipsize, Cons renderer)
    {
      Effect effect = this;
      this.renderer = (Cons) new Effect.__\u003C\u003EAnon0();
      this.lifetime = 50f;
      this.layer = 110f;
      this.__\u003C\u003Eid = Effect.all.size;
      this.lifetime = life;
      this.renderer = renderer;
      this.clip = clipsize;
      Effect.all.add((object) this);
    }

    [Signature("(FLarc/func/Cons<Lmindustry/entities/Effect$EffectContainer;>;)V")]
    [LineNumberTable(new byte[] {159, 187, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Effect(float life, Cons renderer)
      : this(life, 50f, renderer)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Effect layer(float l)
    {
      this.layer = l;
      return this;
    }

    [LineNumberTable(new byte[] {74, 136, 117, 142, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shake(float intensity, float duration, float x, float y)
    {
      if (Core.camera == null)
        return;
      float num = Core.camera.__\u003C\u003Eposition.dst(x, y);
      if ((double) num < 1.0)
        num = 1f;
      Effect.shake(Mathf.clamp(1f / (num * num / 10000f)) * intensity, duration);
    }

    [LineNumberTable(new byte[] {87, 117, 116, 112, 154, 108, 104, 103, 166, 102, 103, 104, 104, 108, 106, 110, 118, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void create(
      Effect effect,
      float x,
      float y,
      float rotation,
      Color color,
      object data)
    {
      if (Vars.headless || object.ReferenceEquals((object) effect, (object) Fx.__\u003C\u003Enone) || (!Core.settings.getBool("effects") || !Core.camera.bounds(Tmp.__\u003C\u003Er1).overlaps(Tmp.__\u003C\u003Er2.setSize(effect.clip).setCenter(x, y))))
        return;
      if (!effect.initialized)
      {
        effect.initialized = true;
        effect.init();
      }
      EffectState effectState = EffectState.create();
      effectState.effect = effect;
      effectState.rotation = rotation;
      effectState.data = data;
      effectState.lifetime = effect.lifetime;
      effectState.set(x, y);
      effectState.color.set(color);
      if (data is Posc)
        effectState.parent = (Posc) data;
      effectState.add();
    }

    [LineNumberTable(new byte[] {60, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(Effect.EffectContainer e) => this.renderer.get((object) e);

    [LineNumberTable(new byte[] {68, 103, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void shake([In] float obj0, [In] float obj1)
    {
      if (Vars.headless)
        return;
      Vars.renderer.shake(obj0, obj1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
    }

    [LineNumberTable(new byte[] {116, 152, 111, 145, 102, 106, 104, 105, 110, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void decal(
      TextureRegion region,
      float x,
      float y,
      float rotation,
      float lifetime,
      Color color)
    {
      if (Vars.headless || region == null || !Core.atlas.isFound(region))
        return;
      Tile tile = Vars.world.tileWorld(x, y);
      if (tile == null || !tile.floor().hasSurface())
        return;
      Decal decal = Decal.create();
      decal.set(x, y);
      decal.rotation(rotation);
      decal.lifetime(lifetime);
      decal.color().set(color);
      decal.region(region);
      decal.add();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] Effect.EffectContainer obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 191, 232, 43, 112, 203, 235, 81, 112, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Effect()
    {
      Effect effect = this;
      this.renderer = (Cons) new Effect.__\u003C\u003EAnon0();
      this.lifetime = 50f;
      this.layer = 110f;
      this.__\u003C\u003Eid = Effect.all.size;
      Effect.all.add((object) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Effect layer(float l, float duration)
    {
      this.layer = l;
      this.layerDuration = duration;
      return this;
    }

    [LineNumberTable(new byte[] {50, 124, 107, 101, 107, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float render(
      int id,
      Color color,
      float life,
      float lifetime,
      float rotation,
      float x,
      float y,
      object data)
    {
      Effect.container.set(id, color, life, lifetime, rotation, x, y, data);
      Draw.z(this.layer);
      Draw.reset();
      this.render(Effect.container);
      Draw.reset();
      return Effect.container.lifetime;
    }

    [LineNumberTable(114)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Effect get(int id) => id >= Effect.all.size || id < 0 ? (Effect) null : (Effect) Effect.all.get(id);

    [LineNumberTable(new byte[] {112, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void decal(TextureRegion region, float x, float y, float rotation) => Effect.decal(region, x, y, rotation, 3600f, Pal.rubble);

    [LineNumberTable(new byte[] {160, 67, 136, 139, 127, 27, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void scorch(float x, float y, int size)
    {
      if (Vars.headless)
        return;
      size = Mathf.clamp(size, 0, 9);
      Effect.decal((TextureRegion) Core.atlas.find(new StringBuilder().append("scorch-").append(size).append("-").append(Mathf.random(2)).toString()), x, y, (float) (Mathf.random(4) * 90), 3600f, Pal.rubble);
    }

    [LineNumberTable(new byte[] {160, 76, 136, 127, 88, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void rubble(float x, float y, int blockSize)
    {
      if (Vars.headless)
        return;
      Effect.decal((TextureRegion) Core.atlas.find(new StringBuilder().append("rubble-").append(blockSize).append("-").append(!Core.atlas.has(new StringBuilder().append("rubble-").append(blockSize).append("-1").toString()) ? (object) "0" : (object) (string) Integer.valueOf(Mathf.random(0, 1))).toString()), x, y, (float) (Mathf.random(4) * 90), 3600f, Pal.rubble);
    }

    [LineNumberTable(new byte[] {159, 137, 109, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Effect()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.entities.Effect"))
        return;
      Effect.container = new Effect.EffectContainer();
      Effect.all = new Seq();
    }

    [Modifiers]
    public int id
    {
      [HideFromJava] get => this.__\u003C\u003Eid;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eid = value;
    }

    public class EffectContainer : Object, Scaled
    {
      public float x;
      public float y;
      public float time;
      public float lifetime;
      public float rotation;
      public Color color;
      public int id;
      public object data;
      private Effect.EffectContainer innerContainer;

      [Signature("<T:Ljava/lang/Object;>()TT;")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object data() => this.data;

      [Signature("(FLarc/func/Cons<Lmindustry/entities/Effect$EffectContainer;>;)V")]
      [LineNumberTable(new byte[] {160, 105, 115, 106, 127, 24, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void scaled(float lifetime, Cons cons)
      {
        if (this.innerContainer == null)
          this.innerContainer = new Effect.EffectContainer();
        if ((double) this.time > (double) lifetime)
          return;
        this.innerContainer.set(this.id, this.color, this.time, lifetime, this.rotation, this.x, this.y, this.data);
        cons.get((object) this.innerContainer);
      }

      [HideFromJava]
      public virtual float fout() => Scaled.\u003Cdefault\u003Efout((Scaled) this);

      [HideFromJava]
      public virtual float finpow() => Scaled.\u003Cdefault\u003Efinpow((Scaled) this);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual float fin() => this.time / this.lifetime;

      [HideFromJava]
      public virtual float fslope() => Scaled.\u003Cdefault\u003Efslope((Scaled) this);

      [HideFromJava]
      public virtual float fout([In] float obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

      [HideFromJava]
      public virtual float fin([In] Interp obj0) => Scaled.\u003Cdefault\u003Efin((Scaled) this, obj0);

      [HideFromJava]
      public virtual float fout([In] Interp obj0) => Scaled.\u003Cdefault\u003Efout((Scaled) this, obj0);

      [LineNumberTable(196)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public EffectContainer()
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void set(
        int id,
        Color color,
        float life,
        float lifetime,
        float rotation,
        float x,
        float y,
        object data)
      {
        this.x = x;
        this.y = y;
        this.color = color;
        this.time = life;
        this.lifetime = lifetime;
        this.id = id;
        this.rotation = rotation;
        this.data = data;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => Effect.lambda\u0024new\u00240((Effect.EffectContainer) obj0);
    }
  }
}
