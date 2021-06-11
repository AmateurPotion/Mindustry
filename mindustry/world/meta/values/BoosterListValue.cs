// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.BoosterListValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using mindustry.type;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.meta.values
{
  public class BoosterListValue : Object, StatValue
  {
    protected internal float reload;
    protected internal float maxUsed;
    protected internal float multiplier;
    protected internal bool baseReload;
    [Signature("Larc/func/Boolf<Lmindustry/type/Liquid;>;")]
    protected internal Boolf filter;

    [Signature("(FFFZLarc/func/Boolf<Lmindustry/type/Liquid;>;)V")]
    [LineNumberTable(new byte[] {159, 138, 163, 104, 104, 104, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BoosterListValue(
      float reload,
      float maxUsed,
      float multiplier,
      bool baseReload,
      Boolf filter)
    {
      int num = baseReload ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      BoosterListValue boosterListValue = this;
      this.reload = reload;
      this.maxUsed = maxUsed;
      this.baseReload = num != 0;
      this.multiplier = multiplier;
      this.filter = filter;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 174, 127, 8, 144, 127, 17, 127, 18, 247, 71, 112, 103, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00241([In] Table obj0)
    {
      Iterator iterator = Vars.content.liquids().iterator();
      while (iterator.hasNext())
      {
        Liquid liquid = (Liquid) iterator.next();
        if (this.filter.get((object) liquid))
        {
          obj0.image(liquid.icon(Cicon.__\u003C\u003Emedium)).size(24f).padRight(4f).right().top();
          Table table = obj0;
          object localizedName = (object) liquid.localizedName;
          CharSequence charSequence;
          charSequence.__\u003Cref\u003E = (__Null) localizedName;
          CharSequence text = charSequence;
          table.add(text).padRight(10f).left().top();
          obj0.table((Drawable) Tex.underline, (Cons) new BoosterListValue.__\u003C\u003EAnon1(this, liquid)).left().padTop(-9f);
          obj0.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 180, 155, 127, 14, 127, 15, 109, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00240([In] Liquid obj0, [In] Table obj1)
    {
      obj1.left().defaults().padRight(3f).left();
      float num1 = (!this.baseReload ? 0.0f : 1f) + this.maxUsed * this.multiplier * obj0.heatCapacity;
      float num2 = (!this.baseReload ? this.reload / (this.maxUsed * this.multiplier * 0.4f) : this.reload) / (this.reload / num1);
      Table table = obj1;
      object obj = (object) Core.bundle.format("bullet.reload", (object) Strings.autoFixed(num2, 2));
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
    }

    [LineNumberTable(new byte[] {159, 172, 103, 242, 80, 107, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      table.row();
      table.table((Cons) new BoosterListValue.__\u003C\u003EAnon0(this)).colspan(table.getColumns());
      table.row();
    }

    [LineNumberTable(new byte[] {3, 103, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void sep([In] Table obj0, [In] string obj1)
    {
      obj0.row();
      Table table = obj0;
      object obj = (object) obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly BoosterListValue arg\u00241;

      internal __\u003C\u003EAnon0([In] BoosterListValue obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00241((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly BoosterListValue arg\u00241;
      private readonly Liquid arg\u00242;

      internal __\u003C\u003EAnon1([In] BoosterListValue obj0, [In] Liquid obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00240(this.arg\u00242, (Table) obj0);
    }
  }
}
