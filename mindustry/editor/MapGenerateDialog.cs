// Decompiled with JetBrains decompiler
// Type: mindustry.editor.MapGenerateDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using arc.util.async;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.io;
using mindustry.maps.filters;
using mindustry.ui;
using mindustry.ui.dialogs;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class MapGenerateDialog : BaseDialog
  {
    [Modifiers]
    [Signature("[Larc/func/Prov<Lmindustry/maps/filters/GenerateFilter;>;")]
    private Prov[] filterTypes;
    [Modifiers]
    private MapEditor editor;
    [Modifiers]
    private bool applied;
    private Pixmap pixmap;
    private Texture texture;
    private GenerateFilter.GenerateInput input;
    [Signature("Larc/struct/Seq<Lmindustry/maps/filters/GenerateFilter;>;")]
    internal Seq filters;
    private int scaling;
    private Table filterTable;
    private AsyncExecutor executor;
    [Signature("Larc/util/async/AsyncResult<Ljava/lang/Void;>;")]
    private AsyncResult result;
    internal bool generating;
    private long[] buffer1;
    private long[] buffer2;
    [Signature("Larc/func/Cons<Larc/struct/Seq<Lmindustry/maps/filters/GenerateFilter;>;>;")]
    private Cons applier;
    internal CachedTile ctile;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 126, 130, 237, 27, 255, 160, 105, 75, 107, 107, 177, 236, 70, 236, 80, 103, 135, 113, 102, 99, 255, 11, 69, 136, 223, 6, 134, 255, 11, 69, 134, 159, 22, 99, 177, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapGenerateDialog(MapEditor editor, bool applied)
    {
      int num = applied ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector("@editor.generate");
      MapGenerateDialog mapGenerateDialog = this;
      this.filterTypes = new Prov[14]
      {
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon0(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon1(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon2(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon3(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon4(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon5(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon6(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon7(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon8(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon9(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon10(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon11(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon12(),
        (Prov) new MapGenerateDialog.__\u003C\u003EAnon13()
      };
      this.input = new GenerateFilter.GenerateInput();
      this.filters = new Seq();
      this.scaling = !Vars.mobile ? 1 : 3;
      this.executor = new AsyncExecutor(1);
      this.ctile = (CachedTile) new MapGenerateDialog.\u0031(this);
      this.editor = editor;
      this.applied = num != 0;
      this.shown((Runnable) new MapGenerateDialog.__\u003C\u003EAnon14(this));
      this.addCloseButton();
      if (num != 0)
        this.__\u003C\u003Ebuttons.button("@editor.apply", (Drawable) Icon.ok, (Runnable) new MapGenerateDialog.__\u003C\u003EAnon15(this)).size(160f, 64f);
      else
        this.__\u003C\u003Ebuttons.button("@settings.reset", (Runnable) new MapGenerateDialog.__\u003C\u003EAnon16(this)).size(160f, 64f);
      this.__\u003C\u003Ebuttons.button("@editor.randomize", (Drawable) Icon.refresh, (Runnable) new MapGenerateDialog.__\u003C\u003EAnon17(this)).size(160f, 64f);
      this.__\u003C\u003Ebuttons.button("@add", (Drawable) Icon.add, (Runnable) new MapGenerateDialog.__\u003C\u003EAnon18(this)).height(64f).width(150f);
      if (num == 0)
        this.hidden((Runnable) new MapGenerateDialog.__\u003C\u003EAnon19(this));
      this.onResize((Runnable) new MapGenerateDialog.__\u003C\u003EAnon20(this));
    }

    [Signature("(Larc/func/Cons<Larc/struct/Seq<Lmindustry/maps/filters/GenerateFilter;>;>;)V")]
    [LineNumberTable(new byte[] {59, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Cons applier) => this.show(this.filters, applier);

    [Signature("(Larc/struct/Seq<Lmindustry/maps/filters/GenerateFilter;>;)V")]
    [LineNumberTable(new byte[] {65, 157, 126, 191, 26, 115, 117, 112, 127, 4, 108, 255, 39, 60, 43, 233, 73, 247, 81, 165, 112, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void applyToEditor(Seq filters)
    {
      long[] numArray = new long[this.editor.width() * this.editor.height()];
      Iterator iterator = filters.iterator();
      while (iterator.hasNext())
      {
        GenerateFilter generateFilter = (GenerateFilter) iterator.next();
        GenerateFilter.GenerateInput input = this.input;
        GenerateFilter filter = generateFilter;
        int width = this.editor.width();
        int height = this.editor.height();
        MapEditor editor = this.editor;
        Objects.requireNonNull((object) editor);
        GenerateFilter.GenerateInput.TileProvider buffer = (GenerateFilter.GenerateInput.TileProvider) new MapGenerateDialog.__\u003C\u003EAnon21(editor);
        input.begin(filter, width, height, buffer);
        for (int x = 0; x < this.editor.width(); ++x)
        {
          for (int y = 0; y < this.editor.height(); ++y)
          {
            Tile tile = this.editor.tile(x, y);
            this.input.apply(x, y, tile.block(), (Block) tile.floor(), (Block) tile.overlay());
            generateFilter.apply(this.input);
            numArray[x + y * Vars.world.width()] = PackTile.get(this.input.block.__\u003C\u003Eid, this.input.floor.__\u003C\u003Eid, this.input.overlay.__\u003C\u003Eid);
          }
        }
        this.editor.load((Runnable) new MapGenerateDialog.__\u003C\u003EAnon22(this, numArray));
      }
      this.editor.renderer.updateAll();
      this.editor.clearOp();
    }

    [Signature("(Larc/struct/Seq<Lmindustry/maps/filters/GenerateFilter;>;Larc/func/Cons<Larc/struct/Seq<Lmindustry/maps/filters/GenerateFilter;>;>;)V")]
    [LineNumberTable(new byte[] {53, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Seq filters, Cons applier)
    {
      this.filters = filters;
      this.applier = applier;
      this.show();
    }

    [LineNumberTable(208)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual long[] create()
    {
      int num1 = this.editor.width();
      int scaling1 = this.scaling;
      int num2 = scaling1 != -1 ? num1 / scaling1 : -num1;
      int num3 = this.editor.height();
      int scaling2 = this.scaling;
      int num4 = scaling2 != -1 ? num3 / scaling2 : -num3;
      return new long[num2 * num4];
    }

    [LineNumberTable(new byte[] {160, 235, 104, 161, 140, 253, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void update()
    {
      if (this.generating)
        return;
      this.result = this.executor.submit((Runnable) new MapGenerateDialog.__\u003C\u003EAnon26(this, new Seq(this.filters)));
    }

    [LineNumberTable(new byte[] {160, 98, 127, 12, 107, 113, 130, 191, 4, 255, 2, 117, 191, 0, 114, 140, 133, 109, 159, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void rebuildFilters()
    {
      int num1 = Math.max(ByteCodeHelper.f2i((float) Core.graphics.getWidth() / 2f / Scl.scl(290f)), 1);
      this.filterTable.clearChildren();
      this.filterTable.top().left();
      int num2 = 0;
      Iterator iterator = this.filters.iterator();
      while (iterator.hasNext())
      {
        GenerateFilter generateFilter = (GenerateFilter) iterator.next();
        this.filterTable.table((Drawable) Tex.pane, (Cons) new MapGenerateDialog.__\u003C\u003EAnon24(this, generateFilter)).width(280f).pad(3f).top().left().fillY();
        ++num2;
        int num3 = num2;
        int num4 = num1;
        if ((num4 != -1 ? num3 % num4 : 0) == 0)
          this.filterTable.row();
      }
      if (!this.filters.isEmpty())
        return;
      Table filterTable = this.filterTable;
      object obj = (object) "@filters.empty";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      filterTable.add(text).wrap().width(200f);
    }

    [LineNumberTable(319)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual long pack([In] Tile obj0) => PackTile.get(obj0.blockID(), obj0.floorID(), obj0.overlayID());

    [LineNumberTable(new byte[] {160, 209, 127, 1, 123, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Tile unpack([In] long obj0)
    {
      this.ctile.setFloor((Floor) Vars.content.block((int) PackTile.floor(obj0)));
      this.ctile.setBlock(Vars.content.block((int) PackTile.block(obj0)));
      this.ctile.setOverlay(Vars.content.block((int) PackTile.overlay(obj0)));
      return (Tile) this.ctile;
    }

    [LineNumberTable(new byte[] {160, 216, 104, 172, 103, 103, 103, 104, 107, 107, 103, 167, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void apply()
    {
      if (this.result != null)
        this.result.get();
      this.buffer1 = (long[]) null;
      this.buffer2 = (long[]) null;
      this.generating = false;
      if (this.pixmap != null)
      {
        this.pixmap.dispose();
        this.texture.dispose();
        this.pixmap = (Pixmap) null;
        this.texture = (Texture) null;
      }
      this.applier.get((object) this.filters);
    }

    [LineNumberTable(new byte[] {105, 104, 107, 107, 103, 167, 127, 32, 145, 107, 246, 96, 134, 108, 140, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setup()
    {
      if (this.pixmap != null)
      {
        this.pixmap.dispose();
        this.texture.dispose();
        this.pixmap = (Pixmap) null;
        this.texture = (Texture) null;
      }
      int num1 = this.editor.width();
      int scaling1 = this.scaling;
      int width = scaling1 != -1 ? num1 / scaling1 : -num1;
      int num2 = this.editor.height();
      int scaling2 = this.scaling;
      int height = scaling2 != -1 ? num2 / scaling2 : -num2;
      this.pixmap = new Pixmap(width, height);
      this.texture = new Texture(this.pixmap);
      this.__\u003C\u003Econt.clear();
      this.__\u003C\u003Econt.table((Cons) new MapGenerateDialog.__\u003C\u003EAnon23(this)).grow();
      this.buffer1 = this.create();
      this.buffer2 = this.create();
      this.update();
      this.rebuildFilters();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {24, 213})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241() => Vars.ui.loadAnd((Runnable) new MapGenerateDialog.__\u003C\u003EAnon43(this));

    [Modifiers]
    [LineNumberTable(new byte[] {31, 122, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242()
    {
      this.filters.set(Vars.maps.readFilters(""));
      this.rebuildFilters();
      this.update();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {37, 127, 1, 102, 98, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243()
    {
      Iterator iterator = this.filters.iterator();
      while (iterator.hasNext())
        ((GenerateFilter) iterator.next()).randomize();
      this.update();
    }

    [LineNumberTable(new byte[] {160, 173, 107, 247, 88, 145, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void showAdd()
    {
      BaseDialog baseDialog = new BaseDialog("@add");
      ((ScrollPane) baseDialog.__\u003C\u003Econt.pane((Cons) new MapGenerateDialog.__\u003C\u003EAnon25(this, baseDialog)).get()).setScrollingDisabled(true, false);
      baseDialog.addCloseButton();
      baseDialog.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {82, 127, 0, 113, 132, 191, 22, 112, 167, 109, 232, 52, 233, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024applyToEditor\u00244([In] long[] obj0)
    {
      for (int idx = 0; idx < this.editor.width() * this.editor.height(); ++idx)
      {
        Tile tile = Vars.world.tiles.geti(idx);
        long packtile = obj0[idx];
        Block type = Vars.content.block((int) PackTile.block(packtile));
        Block block1 = Vars.content.block((int) PackTile.floor(packtile));
        Block block2 = Vars.content.block((int) PackTile.overlay(packtile));
        if (!tile.synthetic() && !type.synthetic())
          tile.setBlock(type);
        tile.setFloor((Floor) block1);
        tile.setOverlay(block2);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {117, 108, 255, 5, 80, 117, 255, 2, 76, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00247([In] Table obj0)
    {
      obj0.margin(8f);
      obj0.stack((Element) new MapGenerateDialog.\u0032(this, this.texture), (Element) new MapGenerateDialog.\u0033(this)).uniformX().grow().padRight(10f);
      ((ScrollPane) obj0.pane((Cons) new MapGenerateDialog.__\u003C\u003EAnon41(this)).update((Cons) new MapGenerateDialog.__\u003C\u003EAnon42(this)).grow().uniformX().get()).setScrollingDisabled(true, false);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 107, 172, 247, 97, 134, 135, 242, 75, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildFilters\u002415([In] GenerateFilter obj0, [In] Table obj1)
    {
      obj1.margin(0.0f);
      obj1.table((Drawable) Tex.whiteui, (Cons) new MapGenerateDialog.__\u003C\u003EAnon33(this, obj0)).growX();
      obj1.row();
      obj1.table((Cons) new MapGenerateDialog.__\u003C\u003EAnon34(this, obj0)).grow().left().pad(6f).top();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 175, 108, 118, 98, 120, 142, 147, 252, 70, 249, 53, 233, 78, 248, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showAdd\u002418([In] BaseDialog obj0, [In] Table obj1)
    {
      obj1.marginRight(14f);
      obj1.defaults().size(210f, 60f);
      int num1 = 0;
      Prov[] filterTypes = this.filterTypes;
      int length = filterTypes.Length;
      for (int index = 0; index < length; ++index)
      {
        GenerateFilter generateFilter = (GenerateFilter) filterTypes[index].get();
        if (!generateFilter.isPost() || !this.applied)
        {
          obj1.button(generateFilter.name(), (Runnable) new MapGenerateDialog.__\u003C\u003EAnon31(this, generateFilter, obj0));
          ++num1;
          int num2 = num1;
          int num3 = 2;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            obj1.row();
        }
      }
      obj1.button("@filter.defaultores", (Runnable) new MapGenerateDialog.__\u003C\u003EAnon32(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 243, 108, 107, 135, 144, 112, 112, 63, 14, 38, 233, 71, 127, 0, 191, 16, 249, 72, 119, 133, 115, 179, 109, 125, 127, 2, 98, 110, 159, 32, 253, 54, 41, 233, 79, 255, 15, 74, 226, 61, 98, 103, 135, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002423([In] Seq obj0)
    {
      Exception exception1;
      try
      {
        int width = this.pixmap.getWidth();
        Vars.world.setGenerating(true);
        this.generating = true;
        if (!this.filters.isEmpty())
        {
          for (int index1 = 0; index1 < this.pixmap.getWidth(); ++index1)
          {
            for (int index2 = 0; index2 < this.pixmap.getHeight(); ++index2)
              this.buffer1[index1 + index2 * width] = this.pack(this.editor.tile(index1 * this.scaling, index2 * this.scaling));
          }
        }
        Iterator iterator = obj0.iterator();
        while (iterator.hasNext())
        {
          GenerateFilter filter = (GenerateFilter) iterator.next();
          this.input.begin(filter, this.editor.width(), this.editor.height(), (GenerateFilter.GenerateInput.TileProvider) new MapGenerateDialog.__\u003C\u003EAnon27(this, width));
          this.pixmap.each((Intc2) new MapGenerateDialog.__\u003C\u003EAnon28(this, width, filter));
          this.pixmap.each((Intc2) new MapGenerateDialog.__\u003C\u003EAnon29(this, width));
        }
        for (int x = 0; x < this.pixmap.getWidth(); ++x)
        {
          for (int index = 0; index < this.pixmap.getHeight(); ++index)
          {
            int color;
            if (this.filters.isEmpty())
            {
              Tile tile = this.editor.tile(x * this.scaling, index * this.scaling);
              color = MapIO.colorFor(tile.block(), (Block) tile.floor(), (Block) tile.overlay(), Team.__\u003C\u003Ederelict);
            }
            else
            {
              long packtile = this.buffer1[x + index * width];
              color = MapIO.colorFor(Vars.content.block((int) PackTile.block(packtile)), Vars.content.block((int) PackTile.floor(packtile)), Vars.content.block((int) PackTile.overlay(packtile)), Team.__\u003C\u003Ederelict);
            }
            this.pixmap.draw(x, this.pixmap.getHeight() - 1 - index, color);
          }
        }
        Core.app.post((Runnable) new MapGenerateDialog.__\u003C\u003EAnon30(this));
        goto label_24;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      this.generating = false;
      Log.err((Exception) exception2);
label_24:
      Vars.world.setGenerating(false);
    }

    [Modifiers]
    [LineNumberTable(371)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Tile lambda\u0024update\u002419([In] int obj0, [In] int obj1, [In] int obj2)
    {
      long[] buffer1 = this.buffer1;
      int num1 = obj1;
      int scaling1 = this.scaling;
      int num2 = Mathf.clamp(scaling1 != -1 ? num1 / scaling1 : -num1, 0, this.pixmap.getWidth() - 1);
      int num3 = obj0;
      int num4 = obj2;
      int scaling2 = this.scaling;
      int num5 = Mathf.clamp(scaling2 != -1 ? num4 / scaling2 : -num4, 0, this.pixmap.getHeight() - 1);
      int num6 = num3 * num5;
      int index = num2 + num6;
      return this.unpack(buffer1[index]);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 5, 115, 110, 127, 30, 108, 127, 35})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002420([In] int obj0, [In] GenerateFilter obj1, [In] int obj2, [In] int obj3)
    {
      int x = obj2 * this.scaling;
      int y = obj3 * this.scaling;
      long packtile = this.buffer1[obj2 + obj3 * obj0];
      this.input.apply(x, y, Vars.content.block((int) PackTile.block(packtile)), Vars.content.block((int) PackTile.floor(packtile)), Vars.content.block((int) PackTile.overlay(packtile)));
      obj1.apply(this.input);
      this.buffer2[obj2 + obj3 * obj0] = PackTile.get(this.input.block.__\u003C\u003Eid, this.input.floor.__\u003C\u003Eid, this.input.overlay.__\u003C\u003Eid);
    }

    [Modifiers]
    [LineNumberTable(382)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002421([In] int obj0, [In] int obj1, [In] int obj2) => this.buffer1[obj1 + obj2 * obj0] = this.buffer2[obj1 + obj2 * obj0];

    [Modifiers]
    [LineNumberTable(new byte[] {161, 31, 112, 129, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002422()
    {
      if (this.pixmap == null || this.texture == null)
        return;
      this.texture.draw(this.pixmap);
      this.generating = false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 184, 108, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showAdd\u002416([In] GenerateFilter obj0, [In] BaseDialog obj1)
    {
      this.filters.add((object) obj0);
      this.rebuildFilters();
      this.update();
      obj1.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 193, 112, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showAdd\u002417([In] BaseDialog obj0)
    {
      Vars.maps.addDefaultOres(this.filters);
      this.rebuildFilters();
      this.update();
      obj0.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 111, 139, 108, 159, 28, 140, 102, 145, 249, 69, 249, 70, 249, 70, 249, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildFilters\u002412([In] GenerateFilter obj0, [In] Table obj1)
    {
      obj1.setColor(Pal.gray);
      obj1.top().left();
      Table table = obj1;
      object obj = (object) obj0.name();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).left().padLeft(6f).width(100f).wrap();
      obj1.add().growX();
      ImageButton.ImageButtonStyle geni = Styles.geni;
      obj1.defaults().size(42f);
      obj1.button((Drawable) Icon.refresh, geni, (Runnable) new MapGenerateDialog.__\u003C\u003EAnon37(this, obj0));
      obj1.button((Drawable) Icon.upOpen, geni, (Runnable) new MapGenerateDialog.__\u003C\u003EAnon38(this, obj0));
      obj1.button((Drawable) Icon.downOpen, geni, (Runnable) new MapGenerateDialog.__\u003C\u003EAnon39(this, obj0));
      obj1.button((Drawable) Icon.cancel, geni, (Runnable) new MapGenerateDialog.__\u003C\u003EAnon40(this, obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 148, 108, 116, 145, 177, 107, 231, 57, 230, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildFilters\u002414([In] GenerateFilter obj0, [In] Table obj1)
    {
      obj1.left().top();
      FilterOption[] filterOptionArray = obj0.options();
      int length = filterOptionArray.Length;
      for (int index = 0; index < length; ++index)
      {
        FilterOption filterOption = filterOptionArray[index];
        filterOption.changed = (Runnable) new MapGenerateDialog.__\u003C\u003EAnon35(this);
        obj1.table((Cons) new MapGenerateDialog.__\u003C\u003EAnon36(filterOption)).growX().left();
        obj1.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 153, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024rebuildFilters\u002413([In] FilterOption obj0, [In] Table obj1)
    {
      obj1.left();
      obj0.build(obj1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 122, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildFilters\u00248([In] GenerateFilter obj0)
    {
      obj0.randomize();
      this.update();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 127, 109, 117, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildFilters\u00249([In] GenerateFilter obj0)
    {
      int first = this.filters.indexOf((object) obj0);
      this.filters.swap(first, Math.max(0, first - 1));
      this.rebuildFilters();
      this.update();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 133, 109, 127, 2, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildFilters\u002410([In] GenerateFilter obj0)
    {
      int first = this.filters.indexOf((object) obj0);
      this.filters.swap(first, Math.min(this.filters.size - 1, first + 1));
      this.rebuildFilters();
      this.update();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 139, 109, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuildFilters\u002411([In] GenerateFilter obj0)
    {
      this.filters.remove((object) obj0);
      this.rebuildFilters();
      this.update();
    }

    [Modifiers]
    [LineNumberTable(185)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00245([In] Table obj0) => this.filterTable = obj0.marginRight(6f);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 72, 127, 4, 161, 145, 127, 25, 142, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00246([In] ScrollPane obj0)
    {
      if (Core.scene.getKeyboardFocus() is Dialog && !object.ReferenceEquals((object) Core.scene.getKeyboardFocus(), (object) this))
        return;
      Vec2 localCoordinates = obj0.stageToLocalCoordinates(Core.input.mouse());
      if ((double) localCoordinates.x >= 0.0 && (double) localCoordinates.y >= 0.0 && ((double) localCoordinates.x <= (double) obj0.getWidth() && (double) localCoordinates.y <= (double) obj0.getHeight()))
        Core.scene.setScrollFocus((Element) obj0);
      else
        Core.scene.setScrollFocus((Element) null);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {25, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      this.apply();
      this.hide();
    }

    [HideFromJava]
    static MapGenerateDialog() => BaseDialog.__\u003Cclinit\u003E();

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal new class \u0031 : CachedTile
    {
      [Modifiers]
      internal MapGenerateDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(51)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] MapGenerateDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [Signature("(Lmindustry/game/Team;Larc/func/Prov<Lmindustry/gen/Building;>;I)V")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override void changeBuild([In] Team obj0, [In] Prov obj1, [In] int obj2)
      {
      }

      [Signature("(Lmindustry/world/Block;Lmindustry/game/Team;ILarc/func/Prov<Lmindustry/gen/Building;>;)V")]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void setBlock([In] Block obj0, [In] Team obj1, [In] int obj2, [In] Prov obj3) => this.block = obj0;

      [HideFromJava]
      static \u0031() => CachedTile.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "setup", "()V")]
    [SpecialName]
    internal new class \u0032 : BorderImage
    {
      [Modifiers]
      internal MapGenerateDialog this\u00240;

      [LineNumberTable(new byte[] {118, 144, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] MapGenerateDialog obj0, [In] Texture obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        MapGenerateDialog.\u0032 obj = this;
        this.setScaling(Scaling.__\u003C\u003Efit);
      }

      [LineNumberTable(new byte[] {125, 102, 127, 6, 103, 98})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        base.draw();
        Iterator iterator = this.this\u00240.filters.iterator();
        while (iterator.hasNext())
          ((GenerateFilter) iterator.next()).draw((Image) this);
      }
    }

    [EnclosingMethod(null, "setup", "()V")]
    [SpecialName]
    internal new class \u0033 : Stack
    {
      [Modifiers]
      internal MapGenerateDialog this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {160, 66, 111, 112, 117, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] MapGenerateDialog obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        MapGenerateDialog.\u0033 obj = this;
        this.add((Element) new Image(Styles.black8));
        this.add((Element) new Image((Drawable) Icon.refresh, Scaling.__\u003C\u003Enone));
        this.visible((Boolp) new MapGenerateDialog.\u0033.__\u003C\u003EAnon0(this));
      }

      [Modifiers]
      [LineNumberTable(183)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private bool lambda\u0024new\u00240() => this.this\u00240.generating && !Vars.updateEditorOnChange;

      [HideFromJava]
      static \u0033() => Stack.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Boolp
      {
        private readonly MapGenerateDialog.\u0033 arg\u00241;

        internal __\u003C\u003EAnon0([In] MapGenerateDialog.\u0033 obj0) => this.arg\u00241 = obj0;

        public bool get() => (this.arg\u00241.lambda\u0024new\u00240() ? 1 : 0) != 0;
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new NoiseFilter();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new ScatterFilter();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new TerrainFilter();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Prov
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get() => (object) new DistortFilter();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Prov
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get() => (object) new RiverNoiseFilter();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Prov
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public object get() => (object) new OreFilter();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Prov
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public object get() => (object) new OreMedianFilter();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Prov
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public object get() => (object) new MedianFilter();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Prov
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public object get() => (object) new BlendFilter();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) new MirrorFilter();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Prov
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public object get() => (object) new ClearFilter();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Prov
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public object get() => (object) new CoreSpawnFilter();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public object get() => (object) new EnemySpawnFilter();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Prov
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public object get() => (object) new SpawnPathFilter();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon14([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.setup();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon15([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon16([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon17([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00243();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon18([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.showAdd();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon19([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.apply();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon20([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.rebuildFilters();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : GenerateFilter.GenerateInput.TileProvider
    {
      private readonly MapEditor arg\u00241;

      internal __\u003C\u003EAnon21([In] MapEditor obj0) => this.arg\u00241 = obj0;

      public Tile get([In] int obj0, [In] int obj1) => this.arg\u00241.tile(obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly long[] arg\u00242;

      internal __\u003C\u003EAnon22([In] MapGenerateDialog obj0, [In] long[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024applyToEditor\u00244(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Cons
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon23([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00247((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly GenerateFilter arg\u00242;

      internal __\u003C\u003EAnon24([In] MapGenerateDialog obj0, [In] GenerateFilter obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuildFilters\u002415(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Cons
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon25([In] MapGenerateDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024showAdd\u002418(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly Seq arg\u00242;

      internal __\u003C\u003EAnon26([In] MapGenerateDialog obj0, [In] Seq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024update\u002423(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : GenerateFilter.GenerateInput.TileProvider
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon27([In] MapGenerateDialog obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public Tile get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024update\u002419(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Intc2
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly int arg\u00242;
      private readonly GenerateFilter arg\u00243;

      internal __\u003C\u003EAnon28([In] MapGenerateDialog obj0, [In] int obj1, [In] GenerateFilter obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024update\u002420(this.arg\u00242, this.arg\u00243, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Intc2
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly int arg\u00242;

      internal __\u003C\u003EAnon29([In] MapGenerateDialog obj0, [In] int obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] int obj0, [In] int obj1) => this.arg\u00241.lambda\u0024update\u002421(this.arg\u00242, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon30([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024update\u002422();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly GenerateFilter arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon31([In] MapGenerateDialog obj0, [In] GenerateFilter obj1, [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024showAdd\u002416(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon32([In] MapGenerateDialog obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showAdd\u002417(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Cons
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly GenerateFilter arg\u00242;

      internal __\u003C\u003EAnon33([In] MapGenerateDialog obj0, [In] GenerateFilter obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuildFilters\u002412(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Cons
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly GenerateFilter arg\u00242;

      internal __\u003C\u003EAnon34([In] MapGenerateDialog obj0, [In] GenerateFilter obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024rebuildFilters\u002414(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon35([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.update();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Cons
    {
      private readonly FilterOption arg\u00241;

      internal __\u003C\u003EAnon36([In] FilterOption obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => MapGenerateDialog.lambda\u0024rebuildFilters\u002413(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly GenerateFilter arg\u00242;

      internal __\u003C\u003EAnon37([In] MapGenerateDialog obj0, [In] GenerateFilter obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildFilters\u00248(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly GenerateFilter arg\u00242;

      internal __\u003C\u003EAnon38([In] MapGenerateDialog obj0, [In] GenerateFilter obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildFilters\u00249(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly GenerateFilter arg\u00242;

      internal __\u003C\u003EAnon39([In] MapGenerateDialog obj0, [In] GenerateFilter obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildFilters\u002410(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;
      private readonly GenerateFilter arg\u00242;

      internal __\u003C\u003EAnon40([In] MapGenerateDialog obj0, [In] GenerateFilter obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuildFilters\u002411(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Cons
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon41([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00245((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Cons
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon42([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00246((ScrollPane) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Runnable
    {
      private readonly MapGenerateDialog arg\u00241;

      internal __\u003C\u003EAnon43([In] MapGenerateDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }
  }
}
