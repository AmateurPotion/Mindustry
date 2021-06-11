// Decompiled with JetBrains decompiler
// Type: mindustry.entities.effect.MultiEffect
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.entities.effect
{
  public class MultiEffect : Effect
  {
    public Effect[] effects;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 8, 172, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MultiEffect()
    {
      MultiEffect multiEffect = this;
      this.effects = new Effect[0];
      this.clip = 100f;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024render\u00240(
      [In] Effect.EffectContainer obj0,
      [In] int obj1,
      [In] Effect obj2,
      [In] Effect.EffectContainer obj3)
    {
      obj3.id = obj0.id + obj1;
      obj2.render(obj3);
    }

    [LineNumberTable(new byte[] {159, 156, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MultiEffect(params Effect[] effects)
      : this()
    {
      MultiEffect multiEffect = this;
      this.effects = effects;
    }

    [LineNumberTable(new byte[] {159, 162, 116, 120, 24, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void init()
    {
      Effect[] effects = this.effects;
      int length = effects.Length;
      for (int index = 0; index < length; ++index)
      {
        Effect effect = effects[index];
        this.clip = Math.max(this.clip, effect.clip);
        this.lifetime = Math.max(this.lifetime, effect.lifetime);
      }
    }

    [LineNumberTable(new byte[] {159, 170, 98, 117, 103, 220, 249, 58, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void render(Effect.EffectContainer e)
    {
      int num1 = 0;
      Effect[] effects = this.effects;
      int length = effects.Length;
      for (int index = 0; index < length; ++index)
      {
        Effect effect = effects[index];
        ++num1;
        int num2 = num1;
        e.scaled(effect.lifetime, (Cons) new MultiEffect.__\u003C\u003EAnon0(e, num2, effect));
        this.clip = Math.max(this.clip, effect.clip);
      }
    }

    [HideFromJava]
    static MultiEffect() => Effect.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Effect.EffectContainer arg\u00241;
      private readonly int arg\u00242;
      private readonly Effect arg\u00243;

      internal __\u003C\u003EAnon0([In] Effect.EffectContainer obj0, [In] int obj1, [In] Effect obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => MultiEffect.lambda\u0024render\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Effect.EffectContainer) obj0);
    }
  }
}
