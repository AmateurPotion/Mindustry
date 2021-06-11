// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.MinimapRenderer
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
using arc.scene.ui.layout;
using arc.util;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.entities;
using mindustry.game;
using mindustry.gen;
using mindustry.io;
using mindustry.ui;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class MinimapRenderer : Object
  {
    private const float baseSize = 16f;
    [Modifiers]
    [Signature("Larc/struct/Seq<Lmindustry/gen/Unit;>;")]
    private Seq units;
    private Pixmap pixmap;
    private Texture texture;
    private TextureRegion region;
    private Rect rect;
    private float zoom;

    [LineNumberTable(new byte[] {159, 173, 232, 57, 203, 107, 171, 245, 70, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MinimapRenderer()
    {
      MinimapRenderer minimapRenderer = this;
      this.units = new Seq();
      this.rect = new Rect();
      this.zoom = 4f;
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new MinimapRenderer.__\u003C\u003EAnon0(this));
      Events.on((Class) ClassLiteral<EventType.TileChangeEvent>.Value, (Cons) new MinimapRenderer.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {95, 153, 125, 159, 7, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update(Tile tile)
    {
      if (Vars.world.isGenerating() || !Vars.state.isGame())
        return;
      int color = this.colorFor(Vars.world.tile((int) tile.x, (int) tile.y));
      this.pixmap.draw((int) tile.x, this.pixmap.getHeight() - 1 - (int) tile.y, color);
      Pixmaps.drawPixel(this.texture, (int) tile.x, this.pixmap.getHeight() - 1 - (int) tile.y, color);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pixmap getPixmap() => this.pixmap;

    [LineNumberTable(new byte[] {9, 127, 28})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setZoom(float amount) => this.zoom = Mathf.clamp(amount, 1f, (float) Math.min(Vars.world.width(), Vars.world.height()) / 16f / 2f);

    [LineNumberTable(new byte[] {104, 110, 119, 119, 119, 151, 108, 127, 49})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateUnitArray()
    {
      float min = 16f * this.zoom;
      float num1 = Core.camera.__\u003C\u003Eposition.x / 8f;
      float num2 = Core.camera.__\u003C\u003Eposition.y / 8f;
      float num3 = Mathf.clamp(num1, min, (float) Vars.world.width() - min);
      float num4 = Mathf.clamp(num2, min, (float) Vars.world.height() - min);
      this.units.clear();
      double num5 = (double) ((num3 - min) * 8f);
      double num6 = (double) ((num4 - min) * 8f);
      double num7 = (double) (min * 2f * 8f);
      double num8 = (double) (min * 2f * 8f);
      Seq units = this.units;
      Objects.requireNonNull((object) units);
      Cons cons = (Cons) new MinimapRenderer.__\u003C\u003EAnon2(units);
      Units.nearby((float) num5, (float) num6, (float) num7, (float) num8, cons);
    }

    [LineNumberTable(new byte[] {124, 102, 122, 103, 125, 135, 127, 18, 103, 135, 121, 127, 17, 101, 104, 127, 43, 135, 144, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawLabel(float x, float y, string text, Color color)
    {
      Font outline = Fonts.outline;
      GlyphLayout glyphLayout1 = (GlyphLayout) Pools.obtain((Class) ClassLiteral<GlyphLayout>.Value, (Prov) new MinimapRenderer.__\u003C\u003EAnon3());
      int num1 = outline.usesIntegerPositions() ? 1 : 0;
      outline.getData().setScale(0.6666667f / Scl.scl(1f));
      outline.setUseIntegerPositions(false);
      GlyphLayout glyphLayout2 = glyphLayout1;
      Font font1 = outline;
      string str1 = text;
      Color color1 = color;
      bool flag1 = true;
      int num2 = 8;
      float num3 = 90f;
      Color color2 = color1;
      object obj1 = (object) str1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence str2 = charSequence;
      Color color3 = color2;
      double num4 = (double) num3;
      int halign1 = num2;
      int num5 = flag1 ? 1 : 0;
      glyphLayout2.setText(font1, str2, color3, (float) num4, halign1, num5 != 0);
      float num6 = 20f;
      float num7 = 3f;
      Draw.color(0.0f, 0.0f, 0.0f, 0.2f);
      Fill.rect(x, y + num6 - glyphLayout1.height / 2f, glyphLayout1.width + num7, glyphLayout1.height + num7);
      Draw.color();
      outline.setColor(color);
      Font font2 = outline;
      string str3 = text;
      double num8 = (double) (x - glyphLayout1.width / 2f);
      double num9 = (double) (y + num6);
      bool flag2 = true;
      int num10 = 8;
      float num11 = 90f;
      float num12 = (float) num9;
      float num13 = (float) num8;
      object obj2 = (object) str3;
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence str4 = charSequence;
      double num14 = (double) num13;
      double num15 = (double) num12;
      double num16 = (double) num11;
      int halign2 = num10;
      int num17 = flag2 ? 1 : 0;
      font2.draw(str4, (float) num14, (float) num15, (float) num16, halign2, num17 != 0);
      outline.setUseIntegerPositions(num1 != 0);
      outline.getData().setScale(1f);
      Pools.free((object) glyphLayout1);
    }

    [LineNumberTable(new byte[] {159, 123, 131, 99, 136, 108, 191, 2, 110, 119, 119, 119, 151, 159, 33, 127, 8, 127, 39, 159, 41, 118, 127, 1, 115, 127, 27, 101, 133, 117, 127, 7, 105, 124, 157, 159, 6, 165, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawEntities(
      float x,
      float y,
      float w,
      float h,
      float scaling,
      bool withLabels)
    {
      int num1 = withLabels ? 1 : 0;
      if (num1 == 0)
      {
        this.updateUnitArray();
      }
      else
      {
        this.units.clear();
        EntityGroup unit = Groups.unit;
        Seq units = this.units;
        Objects.requireNonNull((object) units);
        Cons cons = (Cons) new MinimapRenderer.__\u003C\u003EAnon2(units);
        unit.each(cons);
      }
      float min = 16f * this.zoom;
      float num2 = Core.camera.__\u003C\u003Eposition.x / 8f;
      float num3 = Core.camera.__\u003C\u003Eposition.y / 8f;
      float num4 = Mathf.clamp(num2, min, (float) Vars.world.width() - min);
      float num5 = Mathf.clamp(num3, min, (float) Vars.world.height() - min);
      this.rect.set((num4 - min) * 8f, (num5 - min) * 8f, min * 2f * 8f, min * 2f * 8f);
      Iterator iterator1 = this.units.iterator();
      while (iterator1.hasNext())
      {
        Unit unit = (Unit) iterator1.next();
        float num6 = num1 != 0 ? unit.x / (float) (Vars.world.width() * 8) * w : (unit.x - this.rect.x) / this.rect.width * w;
        float num7 = num1 != 0 ? unit.y / (float) (Vars.world.height() * 8) * h : (unit.y - this.rect.y) / this.rect.width * h;
        Draw.mixcol(unit.team().__\u003C\u003Ecolor, 1f);
        float w1 = Scl.scl(1f) / 2f * scaling * 32f;
        TextureRegion region = unit.type.icon(Cicon.__\u003C\u003Efull);
        Draw.rect(region, x + num6, y + num7, w1, w1 * (float) region.height / (float) region.width, unit.rotation() - 90f);
        Draw.reset();
      }
      if (num1 != 0 && Vars.net.active())
      {
        Iterator iterator2 = Groups.player.iterator();
        while (iterator2.hasNext())
        {
          Player player = (Player) iterator2.next();
          if (!player.dead())
          {
            float num6 = player.x / (float) (Vars.world.width() * 8) * w;
            float num7 = player.y / (float) (Vars.world.height() * 8) * h;
            this.drawLabel(x + num6, y + num7, player.name, player.team().__\u003C\u003Ecolor);
          }
        }
      }
      Draw.reset();
    }

    [LineNumberTable(new byte[] {115, 101, 109, 127, 15, 159, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int colorFor([In] Tile obj0)
    {
      if (obj0 == null)
        return 0;
      int num = obj0.block().minimapColor(obj0);
      Color color = Tmp.__\u003C\u003Ec1.set(num != 0 ? num : MapIO.colorFor(obj0.block(), (Block) obj0.floor(), (Block) obj0.overlay(), obj0.team()));
      color.mul(1f - Mathf.clamp(Vars.world.getDarkness((int) obj0.x, (int) obj0.y) / 4f));
      return color.rgba();
    }

    [LineNumberTable(new byte[] {17, 104, 107, 139, 107, 127, 5, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      if (this.pixmap != null)
      {
        this.pixmap.dispose();
        this.texture.dispose();
      }
      this.setZoom(4f);
      this.pixmap = new Pixmap(Vars.world.width(), Vars.world.height(), Pixmap.Format.__\u003C\u003Ergba8888);
      this.texture = new Texture(this.pixmap);
      this.region = new TextureRegion(this.texture);
    }

    [LineNumberTable(new byte[] {88, 127, 5, 127, 13, 98, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateAll()
    {
      Iterator iterator = Vars.world.tiles.iterator();
      while (iterator.hasNext())
      {
        Tile tile = (Tile) iterator.next();
        this.pixmap.draw((int) tile.x, this.pixmap.getHeight() - 1 - (int) tile.y, this.colorFor(tile));
      }
      this.texture.draw(this.pixmap);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 175, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.WorldLoadEvent obj0)
    {
      this.reset();
      this.updateAll();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 181, 113, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] EventType.TileChangeEvent obj0)
    {
      if (Vars.ui.editor.isShown())
        return;
      this.update(obj0.__\u003C\u003Etile);
    }

    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Texture getTexture() => this.texture;

    [LineNumberTable(new byte[] {4, 112, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void zoomBy(float amount)
    {
      this.zoom += amount;
      this.setZoom(this.zoom);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getZoom() => this.zoom;

    [LineNumberTable(new byte[] {69, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void drawEntities(float x, float y, float w, float h) => this.drawEntities(x, y, w, h, 1f, true);

    [LineNumberTable(new byte[] {73, 138, 127, 20, 119, 119, 119, 119, 116, 117, 127, 14, 127, 10})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion getRegion()
    {
      if (this.texture == null)
        return (TextureRegion) null;
      float min = Mathf.clamp(16f * this.zoom, 16f, (float) Math.min(Vars.world.width(), Vars.world.height()));
      float num1 = Core.camera.__\u003C\u003Eposition.x / 8f;
      float num2 = Core.camera.__\u003C\u003Eposition.y / 8f;
      float num3 = Mathf.clamp(num1, min, (float) Vars.world.width() - min);
      float num4 = Mathf.clamp(num2, min, (float) Vars.world.height() - min);
      float num5 = 1f / (float) this.texture.width;
      float num6 = 1f / (float) this.texture.height;
      float num7 = num3 - min;
      float num8 = (float) Vars.world.height() - num4 - min;
      float num9 = min * 2f;
      float num10 = min * 2f;
      this.region.set(num7 * num5, num8 * num6, (num7 + num9) * num5, (num8 + num10) * num6);
      return this.region;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly MinimapRenderer arg\u00241;

      internal __\u003C\u003EAnon0([In] MinimapRenderer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly MinimapRenderer arg\u00241;

      internal __\u003C\u003EAnon1([In] MinimapRenderer obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((EventType.TileChangeEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon2([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.add((object) (Unit) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Prov
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get() => (object) new GlyphLayout();
    }
  }
}
