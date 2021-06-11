// Decompiled with JetBrains decompiler
// Type: mindustry.editor.WaveGraph
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class WaveGraph : Table
  {
    [Signature("Larc/struct/Seq<Lmindustry/game/SpawnGroup;>;")]
    public Seq groups;
    public int from;
    public int to;
    private WaveGraph.Mode mode;
    private int[][] values;
    [Signature("Larc/struct/OrderedSet<Lmindustry/type/UnitType;>;")]
    private OrderedSet used;
    private int max;
    private int maxTotal;
    private float maxHealth;
    private Table colors;
    [Signature("Larc/struct/ObjectSet<Lmindustry/type/UnitType;>;")]
    private ObjectSet hidden;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(200)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Color color([In] UnitType obj0) => Tmp.__\u003C\u003Ec1.fromHsv((float) obj0.__\u003C\u003Eid / (float) Vars.content.units().size * 360f, 0.7f, 1f);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 176, 144, 122, 134, 156, 104, 159, 12, 127, 2, 144, 117, 127, 13, 109, 139, 133, 110, 115, 127, 18, 233, 61, 235, 70, 101, 106, 117, 133, 106, 113, 99, 127, 10, 118, 130, 127, 18, 233, 57, 235, 74, 106, 117, 133, 106, 113, 103, 127, 10, 127, 2, 130, 127, 16, 233, 57, 235, 74, 197, 159, 16, 152, 106, 112, 191, 18, 159, 19, 255, 65, 58, 236, 73, 109, 139, 113, 159, 6, 113, 109, 255, 52, 59, 235, 72, 139, 134, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
    {
      Lines.stroke(Scl.scl(3f));
      GlyphLayout glyphLayout1 = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new WaveGraph.__\u003C\u003EAnon11());
      Font outline = Fonts.outline;
      GlyphLayout glyphLayout2 = glyphLayout1;
      Font font1 = outline;
      object obj4 = (object) "1";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence str1 = charSequence;
      glyphLayout2.setText(font1, str1);
      float height = glyphLayout1.height;
      float num1 = Scl.scl(30f);
      float num2 = Scl.scl(22f) + height + Scl.scl(5f);
      float num3 = obj0 + num1;
      float num4 = obj1 + num2;
      float num5 = obj2 - num1;
      float num6 = obj3 - num2;
      float num7 = num5 / (float) (this.values.Length - 1);
      if (object.ReferenceEquals((object) this.mode, (object) WaveGraph.Mode.counts))
      {
        Iterator iterator = this.used.orderedItems().iterator();
        while (iterator.hasNext())
        {
          UnitType unitType = (UnitType) iterator.next();
          Draw.color(this.color(unitType));
          Draw.alpha(this.parentAlpha);
          Lines.beginLine();
          for (int index = 0; index < this.values.Length; ++index)
          {
            int num8 = this.values[index][(int) unitType.__\u003C\u003Eid];
            Lines.linePoint(num3 + (float) index * num7, 2f + num4 + (float) num8 * (num6 - 4f) / (float) this.max);
          }
          Lines.endLine();
        }
      }
      else if (object.ReferenceEquals((object) this.mode, (object) WaveGraph.Mode.totals))
      {
        Lines.beginLine();
        Draw.color(Pal.accent);
        for (int index = 0; index < this.values.Length; ++index)
        {
          int num8 = 0;
          Iterator iterator = this.used.orderedItems().iterator();
          while (iterator.hasNext())
          {
            UnitType unitType = (UnitType) iterator.next();
            num8 += this.values[index][(int) unitType.__\u003C\u003Eid];
          }
          Lines.linePoint(num3 + (float) index * num7, 2f + num4 + (float) num8 * (num6 - 4f) / (float) this.maxTotal);
        }
        Lines.endLine();
      }
      else if (object.ReferenceEquals((object) this.mode, (object) WaveGraph.Mode.health))
      {
        Lines.beginLine();
        Draw.color(Pal.health);
        for (int index = 0; index < this.values.Length; ++index)
        {
          float num8 = 0.0f;
          Iterator iterator = this.used.orderedItems().iterator();
          while (iterator.hasNext())
          {
            UnitType unitType = (UnitType) iterator.next();
            num8 += unitType.health * (float) this.values[index][(int) unitType.__\u003C\u003Eid];
          }
          Lines.linePoint(num3 + (float) index * num7, 2f + num4 + num8 * (num6 - 4f) / this.maxHealth);
        }
        Lines.endLine();
      }
      int num9 = Math.max(1, Mathf.ceil((float) this.max / ((obj3 - num2 - this.getMarginBottom() * 2f - 1f) / (glyphLayout1.height * 2f))));
      Draw.color(Color.__\u003C\u003ElightGray);
      for (int index = 0; index < this.max; index += num9)
      {
        float num8 = 2f + obj1 + (float) index * (obj3 - 4f) / (float) this.max + num2;
        float num10 = obj0 + num1;
        GlyphLayout glyphLayout3 = glyphLayout1;
        Font font2 = outline;
        object obj5 = (object) new StringBuilder().append("").append(index).toString();
        charSequence.__\u003Cref\u003E = (__Null) obj5;
        CharSequence str2 = charSequence;
        glyphLayout3.setText(font2, str2);
        Font font3 = outline;
        string str3 = new StringBuilder().append("").append(index).toString();
        double num11 = (double) num10;
        double num12 = (double) (num8 + glyphLayout1.height / 2f - Scl.scl(3f));
        int num13 = 16;
        float num14 = (float) num12;
        float num15 = (float) num11;
        object obj6 = (object) str3;
        charSequence.__\u003Cref\u003E = (__Null) obj6;
        CharSequence str4 = charSequence;
        double num16 = (double) num15;
        double num17 = (double) num14;
        int halign = num13;
        font3.draw(str4, (float) num16, (float) num17, halign);
      }
      float num18 = Scl.scl(4f);
      outline.setColor(Color.__\u003C\u003ElightGray);
      for (int index = 0; index < this.values.Length; ++index)
      {
        float y = obj1 + height;
        float num8 = obj0 + num5 / (float) (this.values.Length - 1) * (float) index + num1;
        Lines.line(num8, y, num8, y + num18);
        if (index == this.values.Length / 2)
        {
          Font font2 = outline;
          string str2 = new StringBuilder().append("").append(index + this.from + 1).toString();
          double num10 = (double) num8;
          double num11 = (double) (y - 2f);
          int num12 = 1;
          float num13 = (float) num11;
          float num14 = (float) num10;
          object obj5 = (object) str2;
          charSequence.__\u003Cref\u003E = (__Null) obj5;
          CharSequence str3 = charSequence;
          double num15 = (double) num14;
          double num16 = (double) num13;
          int halign = num12;
          font2.draw(str3, (float) num15, (float) num16, halign);
        }
      }
      outline.setColor(Color.__\u003C\u003Ewhite);
      Pools.free((object) glyphLayout1);
      Draw.reset();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] Table obj0) => this.colors = obj0;

    [Modifiers]
    [LineNumberTable(new byte[] {84, 103, 134, 119, 159, 26, 255, 13, 61, 233, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00244([In] Table obj0)
    {
      obj0.left();
      ButtonGroup group = new ButtonGroup();
      WaveGraph.Mode[] all = WaveGraph.Mode.all;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        WaveGraph.Mode mode = all[index];
        obj0.button(new StringBuilder().append("@wavemode.").append(mode.name()).toString(), Styles.fullTogglet, (Runnable) new WaveGraph.__\u003C\u003EAnon9(this, mode)).group(group).height(35f).update((Cons) new WaveGraph.__\u003C\u003EAnon10(this, mode)).width(130f);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {125, 103, 127, 1, 255, 17, 77, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u002410([In] ObjectSet obj0, [In] Table obj1)
    {
      obj1.left();
      OrderedSet.OrderedSetIterator orderedSetIterator = this.used.iterator();
      while (((Iterator) orderedSetIterator).hasNext())
      {
        UnitType unitType = (UnitType) ((Iterator) orderedSetIterator).next();
        obj1.button((Cons) new WaveGraph.__\u003C\u003EAnon4(this, unitType), (Button.ButtonStyle) Styles.fullTogglet, (Runnable) new WaveGraph.__\u003C\u003EAnon5(this, unitType, obj0)).update((Cons) new WaveGraph.__\u003C\u003EAnon6(this, unitType));
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 64, 109, 127, 22, 127, 42, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00247([In] UnitType obj0, [In] Button obj1)
    {
      Color color = this.color(obj0).cpy();
      obj1.image().size(32f).update((Cons) new WaveGraph.__\u003C\u003EAnon7(obj1, color)).get().act(1f);
      obj1.image(obj0.icon(Cicon.__\u003C\u003Emedium)).size(32f).padRight(20f).update((Cons) new WaveGraph.__\u003C\u003EAnon8(obj1)).get().act(1f);
      obj1.margin(0.0f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 69, 110, 173, 107, 108, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00248([In] UnitType obj0, [In] ObjectSet obj1)
    {
      if (!this.hidden.add((object) obj0))
        this.hidden.remove((object) obj0);
      this.used.clear();
      this.used.addAll(obj1);
      ObjectSet.ObjectSetIterator objectSetIterator = this.hidden.iterator();
      while (((Iterator) objectSetIterator).hasNext())
        this.used.remove((object) (UnitType) ((Iterator) objectSetIterator).next());
    }

    [Modifiers]
    [LineNumberTable(190)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00249([In] UnitType obj0, [In] Button obj1) => obj1.setChecked(this.hidden.contains((object) obj0));

    [Modifiers]
    [LineNumberTable(179)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00245([In] Button obj0, [In] Color obj1, [In] Image obj2) => obj2.setColor(!obj0.isChecked() ? obj1 : Tmp.__\u003C\u003Ec1.set(obj1).mul(0.5f));

    [Modifiers]
    [LineNumberTable(180)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuild\u00246([In] Button obj0, [In] Image obj1) => obj1.setColor(!obj0.isChecked() ? Color.__\u003C\u003Ewhite : Color.__\u003C\u003Egray);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] WaveGraph.Mode obj0) => this.mode = obj0;

    [Modifiers]
    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] WaveGraph.Mode obj0, [In] TextButton obj1) => obj1.setChecked(object.ReferenceEquals((object) obj0, (object) this.mode));

    [LineNumberTable(new byte[] {159, 172, 232, 53, 107, 143, 139, 203, 171, 140, 246, 160, 92, 149, 135, 151, 135, 241, 73, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WaveGraph()
    {
      WaveGraph waveGraph = this;
      this.groups = new Seq();
      this.from = 0;
      this.to = 20;
      this.mode = WaveGraph.Mode.counts;
      this.used = new OrderedSet();
      this.hidden = new ObjectSet();
      this.background((Drawable) Tex.pane);
      this.rect((Table.DrawRect) new WaveGraph.__\u003C\u003EAnon0(this)).pad(4f).padBottom(10f).grow();
      this.row();
      this.table((Cons) new WaveGraph.__\u003C\u003EAnon1(this)).growX();
      this.row();
      this.table((Cons) new WaveGraph.__\u003C\u003EAnon2(this)).growX();
    }

    [LineNumberTable(new byte[] {96, 127, 38, 107, 114, 139, 115, 105, 103, 131, 127, 8, 106, 127, 0, 101, 147, 127, 7, 119, 103, 101, 115, 244, 48, 233, 83, 141, 107, 108, 248, 82, 145, 127, 5, 110, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void rebuild()
    {
      int num1 = this.to - this.from + 1;
      int size = Vars.content.units().size;
      int[] numArray1 = new int[2];
      int num2 = size;
      numArray1[1] = num2;
      int num3 = num1;
      numArray1[0] = num3;
      // ISSUE: type reference
      this.values = (int[][]) ByteCodeHelper.multianewarray(__typeref (int[][]), numArray1);
      this.used.clear();
      WaveGraph waveGraph = this;
      int num4 = 1;
      int num5 = num4;
      this.maxTotal = num4;
      this.max = num5;
      this.maxHealth = 1f;
      for (int from = this.from; from <= this.to; ++from)
      {
        int index = from - this.from;
        float num6 = 0.0f;
        int num7 = 0;
        Iterator iterator = this.groups.iterator();
        while (iterator.hasNext())
        {
          SpawnGroup spawnGroup = (SpawnGroup) iterator.next();
          int spawned = spawnGroup.getSpawned(from);
          int[] numArray2 = this.values[index];
          int id = (int) spawnGroup.type.__\u003C\u003Eid;
          int[] numArray3 = numArray2;
          numArray3[id] = numArray3[id] + spawned;
          if (spawned > 0)
            this.used.add((object) spawnGroup.type);
          this.max = Math.max(this.max, this.values[index][(int) spawnGroup.type.__\u003C\u003Eid]);
          num6 += (float) spawned * spawnGroup.type.health;
          num7 += spawned;
        }
        this.maxTotal = Math.max(this.maxTotal, num7);
        this.maxHealth = Math.max(this.maxHealth, num6);
      }
      ObjectSet objectSet = new ObjectSet((ObjectSet) this.used);
      this.colors.clear();
      this.colors.left();
      ((ScrollPane) this.colors.pane((Cons) new WaveGraph.__\u003C\u003EAnon3(this, objectSet)).get()).setScrollingDisabled(false, true);
      ObjectSet.ObjectSetIterator objectSetIterator = this.hidden.iterator();
      while (((Iterator) objectSetIterator).hasNext())
        this.used.remove((object) (UnitType) ((Iterator) objectSetIterator).next());
    }

    [HideFromJava]
    static WaveGraph() => Table.__\u003Cclinit\u003E();

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/editor/WaveGraph$Mode;>;")]
    [Modifiers]
    [Serializable]
    internal sealed class Mode : Enum
    {
      [Modifiers]
      public static WaveGraph.Mode counts;
      [Modifiers]
      public static WaveGraph.Mode totals;
      [Modifiers]
      public static WaveGraph.Mode health;
      internal static WaveGraph.Mode[] all;
      [Modifiers]
      private static WaveGraph.Mode[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(203)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Mode([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(203)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static WaveGraph.Mode[] values() => (WaveGraph.Mode[]) WaveGraph.Mode.\u0024VALUES.Clone();

      [LineNumberTable(203)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static WaveGraph.Mode valueOf([In] string obj0) => (WaveGraph.Mode) Enum.valueOf((Class) ClassLiteral<WaveGraph.Mode>.Value, obj0);

      [LineNumberTable(new byte[] {159, 91, 77, 63, 17, 191, 4})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Mode()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.editor.WaveGraph$Mode"))
          return;
        WaveGraph.Mode.counts = new WaveGraph.Mode(nameof (counts), 0);
        WaveGraph.Mode.totals = new WaveGraph.Mode(nameof (totals), 1);
        WaveGraph.Mode.health = new WaveGraph.Mode(nameof (health), 2);
        WaveGraph.Mode.\u0024VALUES = new WaveGraph.Mode[3]
        {
          WaveGraph.Mode.counts,
          WaveGraph.Mode.totals,
          WaveGraph.Mode.health
        };
        WaveGraph.Mode.all = WaveGraph.Mode.values();
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Table.DrawRect
    {
      private readonly WaveGraph arg\u00241;

      internal __\u003C\u003EAnon0([In] WaveGraph obj0) => this.arg\u00241 = obj0;

      public void draw([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3) => this.arg\u00241.lambda\u0024new\u00240(obj0, obj1, obj2, obj3);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly WaveGraph arg\u00241;

      internal __\u003C\u003EAnon1([In] WaveGraph obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly WaveGraph arg\u00241;

      internal __\u003C\u003EAnon2([In] WaveGraph obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00244((Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly WaveGraph arg\u00241;
      private readonly ObjectSet arg\u00242;

      internal __\u003C\u003EAnon3([In] WaveGraph obj0, [In] ObjectSet obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u002410(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly WaveGraph arg\u00241;
      private readonly UnitType arg\u00242;

      internal __\u003C\u003EAnon4([In] WaveGraph obj0, [In] UnitType obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00247(this.arg\u00242, (Button) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly WaveGraph arg\u00241;
      private readonly UnitType arg\u00242;
      private readonly ObjectSet arg\u00243;

      internal __\u003C\u003EAnon5([In] WaveGraph obj0, [In] UnitType obj1, [In] ObjectSet obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00248(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly WaveGraph arg\u00241;
      private readonly UnitType arg\u00242;

      internal __\u003C\u003EAnon6([In] WaveGraph obj0, [In] UnitType obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuild\u00249(this.arg\u00242, (Button) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly Button arg\u00241;
      private readonly Color arg\u00242;

      internal __\u003C\u003EAnon7([In] Button obj0, [In] Color obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => WaveGraph.lambda\u0024rebuild\u00245(this.arg\u00241, this.arg\u00242, (Image) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly Button arg\u00241;

      internal __\u003C\u003EAnon8([In] Button obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => WaveGraph.lambda\u0024rebuild\u00246(this.arg\u00241, (Image) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly WaveGraph arg\u00241;
      private readonly WaveGraph.Mode arg\u00242;

      internal __\u003C\u003EAnon9([In] WaveGraph obj0, [In] WaveGraph.Mode obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00242(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      private readonly WaveGraph arg\u00241;
      private readonly WaveGraph.Mode arg\u00242;

      internal __\u003C\u003EAnon10([In] WaveGraph obj0, [In] WaveGraph.Mode obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243(this.arg\u00242, (TextButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Prov
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public object get() => (object) new GlyphLayout();
    }
  }
}
