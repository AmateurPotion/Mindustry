// Decompiled with JetBrains decompiler
// Type: mindustry.ui.LiquidDisplay
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.type;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class LiquidDisplay : Table
  {
    internal Liquid __\u003C\u003Eliquid;
    internal float __\u003C\u003Eamount;
    internal bool __\u003C\u003EperSecond;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 138, 66, 104, 103, 104, 135, 244, 72, 159, 12, 99, 191, 42, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LiquidDisplay(Liquid liquid, float amount, bool perSecond)
    {
      int num = perSecond ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      LiquidDisplay liquidDisplay = this;
      this.__\u003C\u003Eliquid = liquid;
      this.__\u003C\u003Eamount = amount;
      this.__\u003C\u003EperSecond = num != 0;
      this.add((Element) new LiquidDisplay.\u0031(this, liquid, amount)).size(32f).padRight((float) (3 + ((double) amount == 0.0 || String.instancehelper_length(Strings.autoFixed(amount, 2)) <= 2 ? 0 : 8)));
      CharSequence text;
      if (num != 0)
      {
        object obj = (object) StatUnit.__\u003C\u003EperSecond.localized();
        text.__\u003Cref\u003E = (__Null) obj;
        this.add(text).padLeft(2f).padRight(5f).color(Color.__\u003C\u003ElightGray).style((Style) Styles.outlineLabel);
      }
      object localizedName = (object) liquid.localizedName;
      text.__\u003Cref\u003E = (__Null) localizedName;
      this.add(text);
    }

    [HideFromJava]
    static LiquidDisplay() => Table.__\u003Cclinit\u003E();

    [Modifiers]
    public Liquid liquid
    {
      [HideFromJava] get => this.__\u003C\u003Eliquid;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eliquid = value;
    }

    [Modifiers]
    public float amount
    {
      [HideFromJava] get => this.__\u003C\u003Eamount;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eamount = value;
    }

    [Modifiers]
    public bool perSecond
    {
      [HideFromJava] get => this.__\u003C\u003EperSecond;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EperSecond = value;
    }

    [EnclosingMethod(null, "<init>", "(Lmindustry.type.Liquid;FZ)V")]
    [SpecialName]
    internal new class \u0031 : Stack
    {
      [Modifiers]
      internal Liquid val\u0024liquid;
      [Modifiers]
      internal float val\u0024amount;
      [Modifiers]
      internal LiquidDisplay this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {159, 163, 126, 155, 109, 112, 127, 14, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] LiquidDisplay obj0, [In] Liquid obj1, [In] float obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024liquid = obj1;
        this.val\u0024amount = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LiquidDisplay.\u0031 obj3 = this;
        this.add((Element) new Image(this.val\u0024liquid.icon(Cicon.__\u003C\u003Emedium)));
        if ((double) this.val\u0024amount == 0.0)
          return;
        Table table1 = new Table().left().bottom();
        Table table2 = table1;
        object obj4 = (object) Strings.autoFixed(this.val\u0024amount, 2);
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj4;
        CharSequence text = charSequence;
        table2.add(text).style((Style) Styles.outlineLabel);
        this.add((Element) table1);
      }

      [HideFromJava]
      static \u0031() => Stack.__\u003Cclinit\u003E();
    }
  }
}
