// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.PlacementFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.input;
using arc.math.geom;
using arc.scene;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using java.util.function;
using mindustry.core;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.units;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.input;
using mindustry.type;
using mindustry.world;
using mindustry.world.blocks;
using mindustry.world.blocks.storage;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class PlacementFragment : Fragment
  {
    [Modifiers]
    internal int rowWidth;
    public Category currentCategory;
    [Signature("Larc/struct/Seq<Lmindustry/world/Block;>;")]
    internal Seq returnArray;
    [Signature("Larc/struct/Seq<Lmindustry/world/Block;>;")]
    internal Seq returnArray2;
    [Signature("Larc/struct/Seq<Lmindustry/type/Category;>;")]
    internal Seq returnCatArray;
    internal bool[] categoryEmpty;
    [Signature("Larc/struct/ObjectMap<Lmindustry/type/Category;Lmindustry/world/Block;>;")]
    internal ObjectMap selectedBlocks;
    [Signature("Larc/struct/ObjectFloatMap<Lmindustry/type/Category;>;")]
    internal ObjectFloatMap scrollPositions;
    internal Block menuHoverBlock;
    internal Displayable hover;
    internal object lastDisplayState;
    internal bool wasHovered;
    internal Table blockTable;
    internal Table toggler;
    internal Table topTable;
    internal ScrollPane blockPane;
    internal bool blockSelectEnd;
    internal int blockSelectSeq;
    internal long blockSelectSeqMillis;
    internal Binding[] blockSelect;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Displayable hover() => this.hover;

    [LineNumberTable(new byte[] {14, 232, 29, 135, 139, 118, 107, 113, 107, 235, 74, 255, 99, 82, 245, 71, 245, 70, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PlacementFragment()
    {
      PlacementFragment placementFragment = this;
      this.rowWidth = 4;
      this.currentCategory = Category.__\u003C\u003Edistribution;
      this.returnArray = new Seq();
      this.returnArray2 = new Seq();
      this.returnCatArray = new Seq();
      this.categoryEmpty = new bool[Category.__\u003C\u003Eall.Length];
      this.selectedBlocks = new ObjectMap();
      this.scrollPositions = new ObjectFloatMap();
      this.blockSelect = new Binding[14]
      {
        Binding.__\u003C\u003Eblock_select_01,
        Binding.__\u003C\u003Eblock_select_02,
        Binding.__\u003C\u003Eblock_select_03,
        Binding.__\u003C\u003Eblock_select_04,
        Binding.__\u003C\u003Eblock_select_05,
        Binding.__\u003C\u003Eblock_select_06,
        Binding.__\u003C\u003Eblock_select_07,
        Binding.__\u003C\u003Eblock_select_08,
        Binding.__\u003C\u003Eblock_select_09,
        Binding.__\u003C\u003Eblock_select_10,
        Binding.__\u003C\u003Eblock_select_left,
        Binding.__\u003C\u003Eblock_select_right,
        Binding.__\u003C\u003Eblock_select_up,
        Binding.__\u003C\u003Eblock_select_down
      };
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new PlacementFragment.__\u003C\u003EAnon0(this));
      Events.on((Class) ClassLiteral<EventType.UnlockEvent>.Value, (Cons) new PlacementFragment.__\u003C\u003EAnon1(this));
      Events.on((Class) ClassLiteral<EventType.ResetEvent>.Value, (Cons) new PlacementFragment.__\u003C\u003EAnon2(this));
    }

    [LineNumberTable(new byte[] {160, 91, 241, 160, 219})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent) => parent.fill((Cons) new PlacementFragment.__\u003C\u003EAnon3(this));

    [LineNumberTable(443)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool unlocked([In] Block obj0) => obj0.unlockedNow();

    [Signature("(Lmindustry/type/Category;)Larc/struct/Seq<Lmindustry/world/Block;>;")]
    [LineNumberTable(435)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Seq getUnlockedByCategory([In] Category obj0) => this.returnArray2.selectFrom(Vars.content.blocks(), (Boolf) new PlacementFragment.__\u003C\u003EAnon6(this, obj0)).sort((Comparator) new PlacementFragment.__\u003C\u003EAnon7());

    [LineNumberTable(439)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Block getSelectedBlock([In] Category obj0) => (Block) this.selectedBlocks.get((object) obj0, (Prov) new PlacementFragment.__\u003C\u003EAnon8(this, obj0));

    [Signature("(Lmindustry/type/Category;)Larc/struct/Seq<Lmindustry/world/Block;>;")]
    [LineNumberTable(431)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Seq getByCategory([In] Category obj0) => this.returnArray.selectFrom(Vars.content.blocks(), (Boolf) new PlacementFragment.__\u003C\u003EAnon5(obj0));

    [LineNumberTable(new byte[] {161, 84, 182, 191, 9, 159, 22, 165, 127, 10, 131, 104, 108, 199, 104, 194})]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Displayable hovered()
    {
      Vec2 localCoordinates = this.topTable.stageToLocalCoordinates(Core.input.mouse());
      if (Core.scene.hasMouse() || this.topTable.hit(localCoordinates.x, localCoordinates.y, false) != null)
        return (Displayable) null;
      Unit unit = Units.closestOverlap(Vars.player.team(), Core.input.mouseWorldX(), Core.input.mouseWorldY(), 5f, (Boolf) new PlacementFragment.__\u003C\u003EAnon9());
      if (unit != null)
        return (Displayable) unit;
      Tile tile = Vars.world.tileWorld(Core.input.mouseWorld().x, Core.input.mouseWorld().y);
      if (tile != null)
      {
        if (tile.build != null)
        {
          tile.build.updateFlow = true;
          return (Displayable) tile.build;
        }
        if (tile.drop() != null)
          return (Displayable) tile;
      }
      return (Displayable) null;
    }

    [LineNumberTable(new byte[] {47, 157, 127, 4, 127, 10, 127, 21, 155, 127, 17, 127, 26, 104, 105, 130, 133, 116, 103, 104, 113, 194, 159, 0, 113, 120, 105, 110, 110, 113, 117, 159, 0, 159, 5, 188, 127, 11, 20, 226, 69, 159, 3, 116, 120, 226, 47, 235, 84, 159, 1, 120, 110, 104, 146, 103, 103, 176, 104, 172, 121, 135, 110, 127, 4, 127, 3, 120, 139, 226, 14, 235, 118, 145, 113, 116, 114, 162, 145, 113, 116, 114, 162, 113, 120, 100, 113, 202})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool gridUpdate([In] InputHandler obj0)
    {
      this.scrollPositions.put((object) this.currentCategory, this.blockPane.getScrollY());
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Epick) && Vars.player.isBuilder())
      {
        Building building1 = Vars.world.buildWorld(Core.input.mouseWorld().x, Core.input.mouseWorld().y);
        Block block1;
        if (building1 == null)
        {
          block1 = (Block) null;
        }
        else
        {
          Building building2 = building1;
          ConstructBlock.ConstructBuild constructBuild;
          block1 = !(building2 is ConstructBlock.ConstructBuild) || !object.ReferenceEquals((object) (constructBuild = (ConstructBlock.ConstructBuild) building2), (object) (ConstructBlock.ConstructBuild) building2) ? building1.block : constructBuild.cblock;
        }
        Block block2 = block1;
        object obj = building1 == null || !building1.block.copyConfig ? (object) null : building1.config();
        Iterator iterator = Vars.player.unit().plans().iterator();
        while (iterator.hasNext())
        {
          BuildPlan buildPlan = (BuildPlan) iterator.next();
          if (!buildPlan.breaking && buildPlan.block.bounds(buildPlan.x, buildPlan.y, Tmp.__\u003C\u003Er1).contains(Core.input.mouseWorld()))
          {
            block2 = buildPlan.block;
            obj = buildPlan.config;
            break;
          }
        }
        if (block2 != null && block2.isVisible() && this.unlocked(block2))
        {
          obj0.block = block2;
          block2.lastConfig = obj;
          this.currentCategory = obj0.block.category;
          return true;
        }
      }
      if (Vars.ui.chatfrag.shown() || Core.scene.hasKeyboard())
        return false;
      for (int index1 = 0; index1 < this.blockSelect.Length; ++index1)
      {
        if (Core.input.keyTap((KeyBinds.KeyBind) this.blockSelect[index1]))
        {
          if (index1 > 9)
          {
            Seq unlockedByCategory = this.getUnlockedByCategory(this.currentCategory);
            Block selectedBlock = this.getSelectedBlock(this.currentCategory);
            for (int index2 = 0; index2 < unlockedByCategory.size; ++index2)
            {
              if (object.ReferenceEquals(unlockedByCategory.get(index2), (object) selectedBlock))
              {
                switch (index1)
                {
                  case 10:
                    int num1 = index2 - 1 + unlockedByCategory.size;
                    int size1 = unlockedByCategory.size;
                    index2 = size1 != -1 ? num1 % size1 : 0;
                    break;
                  case 11:
                    int num2 = index2 + 1;
                    int size2 = unlockedByCategory.size;
                    index2 = size2 != -1 ? num2 % size2 : 0;
                    break;
                  case 12:
                    int num3;
                    if (index2 > 3)
                    {
                      num3 = index2 - 4;
                    }
                    else
                    {
                      int size3 = unlockedByCategory.size;
                      int size4 = unlockedByCategory.size;
                      int num4 = 4;
                      int num5 = num4 != -1 ? size4 % num4 : 0;
                      num3 = size3 - num5 + index2;
                    }
                    int num6 = num3;
                    index2 = num6 - (num6 >= unlockedByCategory.size ? 4 : 0);
                    break;
                  case 13:
                    int num7;
                    if (index2 < unlockedByCategory.size - 4)
                    {
                      num7 = index2 + 4;
                    }
                    else
                    {
                      int num4 = index2;
                      int num5 = 4;
                      num7 = num5 != -1 ? num4 % num5 : 0;
                    }
                    index2 = num7;
                    break;
                }
                obj0.block = (Block) unlockedByCategory.get(index2);
                this.selectedBlocks.put((object) this.currentCategory, (object) obj0.block);
                break;
              }
            }
          }
          else if (this.blockSelectEnd || Time.timeSinceMillis(this.blockSelectSeqMillis) > 400L)
          {
            if (!this.getUnlockedByCategory(Category.__\u003C\u003Eall[index1]).isEmpty())
            {
              this.currentCategory = Category.__\u003C\u003Eall[index1];
              if (obj0.block != null)
                obj0.block = this.getSelectedBlock(this.currentCategory);
              this.blockSelectEnd = false;
              this.blockSelectSeq = 0;
              this.blockSelectSeqMillis = Time.millis();
            }
          }
          else
          {
            if (this.blockSelectSeq == 0)
            {
              this.blockSelectSeq = index1 + 1;
            }
            else
            {
              index1 += (this.blockSelectSeq - (index1 == 9 ? 1 : 0)) * 10;
              this.blockSelectEnd = true;
            }
            Seq byCategory = this.getByCategory(this.currentCategory);
            if (index1 >= byCategory.size || !this.unlocked((Block) byCategory.get(index1)))
              return true;
            obj0.block = index1 >= byCategory.size ? (Block) null : (Block) byCategory.get(index1);
            this.selectedBlocks.put((object) this.currentCategory, (object) obj0.block);
            this.blockSelectSeqMillis = Time.millis();
          }
          return true;
        }
      }
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Ecategory_prev))
      {
        do
        {
          this.currentCategory = this.currentCategory.prev();
        }
        while (this.categoryEmpty[this.currentCategory.ordinal()]);
        obj0.block = this.getSelectedBlock(this.currentCategory);
        return true;
      }
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Ecategory_next))
      {
        do
        {
          this.currentCategory = this.currentCategory.next();
        }
        while (this.categoryEmpty[this.currentCategory.ordinal()]);
        obj0.block = this.getSelectedBlock(this.currentCategory);
        return true;
      }
      if (Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Eblock_info))
      {
        Block block = this.menuHoverBlock == null ? obj0.block : this.menuHoverBlock;
        if (block != null)
        {
          Vars.ui.content.show((UnlockableContent) block);
          Events.fire((object) new EventType.BlockInfoEvent());
        }
      }
      return false;
    }

    [Signature("()Larc/struct/Seq<Lmindustry/type/Category;>;")]
    [LineNumberTable(427)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Seq getCategories() => this.returnCatArray.clear().addAll((object[]) Category.__\u003C\u003Eall).sort((Comparator) new PlacementFragment.__\u003C\u003EAnon4(this));

    [LineNumberTable(new byte[] {38, 107, 108, 108, 108, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void rebuild()
    {
      this.currentCategory = Category.__\u003C\u003Eturret;
      Group parent = this.toggler.parent;
      int zindex = this.toggler.getZIndex();
      this.toggler.remove();
      this.build(parent);
      this.toggler.setZIndex(zindex);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {16, 213})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241([In] EventType.WorldLoadEvent obj0) => Core.app.post((Runnable) new PlacementFragment.__\u003C\u003EAnon39(this));

    [Modifiers]
    [LineNumberTable(new byte[] {23, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] EventType.UnlockEvent obj0)
    {
      if (!(obj0.__\u003C\u003Econtent is Block))
        return;
      this.rebuild();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {29, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] EventType.ResetEvent obj0) => this.selectedBlocks.clear();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 92, 103, 155, 242, 160, 214})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002430([In] Table obj0)
    {
      this.toggler = obj0;
      obj0.bottom().right().visible((Boolp) new PlacementFragment.__\u003C\u003EAnon11());
      obj0.table((Cons) new PlacementFragment.__\u003C\u003EAnon12(this));
    }

    [Modifiers]
    [LineNumberTable(427)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024getCategories\u002431([In] Category obj0, [In] Category obj1) => Boolean.compare(this.categoryEmpty[obj0.ordinal()], this.categoryEmpty[obj1.ordinal()]);

    [Modifiers]
    [LineNumberTable(431)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024getByCategory\u002432([In] Category obj0, [In] Block obj1) => object.ReferenceEquals((object) obj1.category, (object) obj0) && obj1.isVisible();

    [Modifiers]
    [LineNumberTable(435)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024getUnlockedByCategory\u002433([In] Category obj0, [In] Block obj1) => object.ReferenceEquals((object) obj1.category, (object) obj0) && obj1.isVisible() && this.unlocked(obj1);

    [Modifiers]
    [LineNumberTable(435)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024getUnlockedByCategory\u002434([In] Block obj0, [In] Block obj1) => Boolean.compare(!obj0.isPlaceable(), !obj1.isPlaceable());

    [Modifiers]
    [LineNumberTable(439)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024getSelectedBlock\u002435([In] Category obj0) => (Block) this.getByCategory(obj0).find((Boolf) new PlacementFragment.__\u003C\u003EAnon10(this));

    [Modifiers]
    [LineNumberTable(460)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024hovered\u002436([In] Unit obj0) => !obj0.isLocal();

    [Modifiers]
    [LineNumberTable(207)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u00244() => Vars.ui.hudfrag.shown;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 98, 236, 126, 247, 160, 88, 127, 6, 103, 127, 7, 103, 246, 77, 117, 242, 100, 149, 102, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002429([In] Table obj0)
    {
      Runnable runnable = (Runnable) new PlacementFragment.__\u003C\u003EAnon13(this);
      obj0.table((Drawable) Tex.buttonEdge2, (Cons) new PlacementFragment.__\u003C\u003EAnon14(this)).colspan(3).fillX().visible((Boolp) new PlacementFragment.__\u003C\u003EAnon15(this)).touchable(Touchable.__\u003C\u003Eenabled);
      obj0.row();
      obj0.image().color(Pal.gray).colspan(3).height(4f).growX();
      obj0.row();
      obj0.table((Drawable) Tex.pane2, (Cons) new PlacementFragment.__\u003C\u003EAnon16(this)).fillY().bottom().touchable(Touchable.__\u003C\u003Eenabled);
      obj0.table((Cons) new PlacementFragment.__\u003C\u003EAnon17(this, runnable)).fillY().bottom().touchable(Touchable.__\u003C\u003Eenabled);
      runnable.run();
      obj0.update((Runnable) new PlacementFragment.__\u003C\u003EAnon18(this, runnable));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 99, 107, 150, 130, 102, 135, 127, 10, 107, 114, 172, 255, 18, 74, 127, 28, 146, 245, 75, 115, 243, 69, 133, 100, 106, 54, 200, 112, 127, 3, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002412()
    {
      this.blockTable.clear();
      this.blockTable.top().margin(5f);
      int num1 = 0;
      ButtonGroup group = new ButtonGroup();
      group.setMinCheckCount(0);
      Iterator iterator = this.getUnlockedByCategory(this.currentCategory).iterator();
      while (iterator.hasNext())
      {
        Block block = (Block) iterator.next();
        if (this.unlocked(block))
        {
          int num2 = num1;
          ++num1;
          int num3 = 4;
          if ((num3 != -1 ? num2 % num3 : 0) == 0)
            this.blockTable.row();
          ImageButton imageButton = (ImageButton) this.blockTable.button((Drawable) new TextureRegionDrawable(block.icon(Cicon.__\u003C\u003Emedium)), Styles.selecti, (Runnable) new PlacementFragment.__\u003C\u003EAnon32(this, block)).size(46f).group(group).name(new StringBuilder().append("block-").append(block.__\u003C\u003Ename).toString()).get();
          imageButton.resizeImage((float) Cicon.__\u003C\u003Emedium.__\u003C\u003Esize);
          imageButton.update((Runnable) new PlacementFragment.__\u003C\u003EAnon33(block, imageButton));
          imageButton.hovered((Runnable) new PlacementFragment.__\u003C\u003EAnon34(this, block));
          imageButton.exited((Runnable) new PlacementFragment.__\u003C\u003EAnon35(this, block));
        }
      }
      if (num1 < 4)
      {
        for (int index = 0; index < 4 - num1; ++index)
          this.blockTable.add().size(46f);
      }
      this.blockTable.act(0.0f);
      this.blockPane.setScrollYForce(this.scrollPositions.get((object) this.currentCategory, 0.0f));
      Core.app.post((Runnable) new PlacementFragment.__\u003C\u003EAnon36(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 161, 103, 255, 2, 160, 86})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002421([In] Table obj0)
    {
      this.topTable = obj0;
      obj0.add((Element) new Table()).growX().update((Cons) new PlacementFragment.__\u003C\u003EAnon24(this));
    }

    [LineNumberTable(new byte[] {161, 77, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual bool hasInfoBox()
    {
      this.hover = this.hovered();
      return Vars.control.input.block != null || this.menuHoverBlock != null || this.hover != null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 253, 118, 255, 12, 71, 116, 112, 103, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002424([In] Table obj0)
    {
      obj0.margin(4f).marginTop(0.0f);
      this.blockPane = (ScrollPane) obj0.pane((Cons) new PlacementFragment.__\u003C\u003EAnon21(this)).height(194f).update((Cons) new PlacementFragment.__\u003C\u003EAnon22()).grow().get();
      this.blockPane.setStyle(Styles.smallPane);
      obj0.row();
      Table table = obj0;
      InputHandler input = Vars.control.input;
      Objects.requireNonNull((object) input);
      Cons cons = (Cons) new PlacementFragment.__\u003C\u003EAnon23(input);
      table.table(cons).name("inputTable").growX();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 11, 103, 242, 70, 126, 145, 166, 116, 106, 21, 230, 69, 99, 127, 8, 156, 112, 108, 162, 255, 12, 70, 127, 30, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002427([In] Runnable obj0, [In] Table obj1)
    {
      obj1.bottom();
      obj1.add((Element) new PlacementFragment.\u0031(this, Styles.black6)).colspan(2).growX().growY().padTop(-3f).row();
      obj1.defaults().size(50f);
      ButtonGroup group = new ButtonGroup();
      Category[] all = Category.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        Category category = all[index];
        Seq unlockedByCategory = this.getUnlockedByCategory(category);
        this.categoryEmpty[category.ordinal()] = unlockedByCategory.isEmpty();
      }
      int num1 = 0;
      Iterator iterator = this.getCategories().iterator();
      while (iterator.hasNext())
      {
        Category category = (Category) iterator.next();
        int num2 = num1;
        ++num1;
        int num3 = 2;
        if ((num3 != -1 ? num2 % num3 : 0) == 0)
          obj1.row();
        if (this.categoryEmpty[category.ordinal()])
          obj1.image(Styles.black6);
        else
          obj1.button((Drawable) Vars.ui.getIcon(category.name()), Styles.clearToggleTransi, (Runnable) new PlacementFragment.__\u003C\u003EAnon19(this, category, obj0)).group(group).update((Cons) new PlacementFragment.__\u003C\u003EAnon20(this, category)).name(new StringBuilder().append("category-").append(category.name()).toString());
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 50, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002428([In] Runnable obj0)
    {
      if (!this.gridUpdate(Vars.control.input))
        return;
      obj0.run();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 39, 103, 113, 155, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002425([In] Category obj0, [In] Runnable obj1)
    {
      this.currentCategory = obj0;
      if (Vars.control.input.block != null)
        Vars.control.input.block = this.getSelectedBlock(this.currentCategory);
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(414)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002426([In] Category obj0, [In] ImageButton obj1) => obj1.setChecked(object.ReferenceEquals((object) this.currentCategory, (object) obj0));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002422([In] Table obj0) => this.blockTable = obj0;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 255, 104, 127, 3, 108, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002423([In] ScrollPane obj0)
    {
      if (!obj0.hasScroll())
        return;
      Element element = Core.scene.hit((float) Core.input.mouseX(), (float) Core.input.mouseY(), true);
      if (element != null && element.isDescendantOf((Element) obj0))
        return;
      Core.scene.setScrollFocus((Element) null);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 165, 103, 127, 1, 104, 200, 152, 102, 150, 103, 167, 134, 242, 89, 107, 135, 241, 85, 149, 116, 103, 213, 173, 131, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002420([In] Table obj0)
    {
      Displayable hover = this.hover;
      Block block = this.menuHoverBlock == null ? Vars.control.input.block : this.menuHoverBlock;
      object objB = block == null ? (object) hover : (object) (Displayable) block;
      int num = block != null ? 0 : 1;
      if ((this.wasHovered ? 1 : 0) == num && object.ReferenceEquals(this.lastDisplayState, objB))
        return;
      obj0.clear();
      obj0.top().left().margin(5f);
      this.lastDisplayState = objB;
      this.wasHovered = num != 0;
      if (block != null)
      {
        obj0.table((Cons) new PlacementFragment.__\u003C\u003EAnon25(this, block)).growX().left();
        obj0.row();
        obj0.table((Cons) new PlacementFragment.__\u003C\u003EAnon26(block)).growX().left().margin(3f);
        if (block.isPlaceable() && Vars.player.isBuilder())
          return;
        obj0.row();
        obj0.table((Cons) new PlacementFragment.__\u003C\u003EAnon27()).padTop(2f).left();
      }
      else
        hover?.display(obj0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 184, 102, 106, 109, 110, 127, 7, 127, 41, 127, 71, 127, 5, 226, 59, 233, 73, 98, 103, 127, 2, 115, 122, 108, 105, 191, 1, 159, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002415([In] Block obj0, [In] Table obj1)
    {
      string str1 = "";
      if (!Vars.mobile)
      {
        Seq byCategory = this.getByCategory(this.currentCategory);
        for (int index1 = 0; index1 < byCategory.size; ++index1)
        {
          if (object.ReferenceEquals(byCategory.get(index1), (object) obj0) && (index1 + 1) / 10 - 1 < this.blockSelect.Length)
          {
            StringBuilder stringBuilder = new StringBuilder().append(Core.bundle.format("placement.blockselectkeys", (object) Core.keybinds.get((KeyBinds.KeyBind) this.blockSelect[this.currentCategory.ordinal()]).key.toString())).append(index1 >= 10 ? new StringBuilder().append(Core.keybinds.get((KeyBinds.KeyBind) this.blockSelect[(index1 + 1) / 10 - 1]).key.toString()).append(",").toString() : "");
            KeyBinds keybinds = Core.keybinds;
            Binding[] blockSelect = this.blockSelect;
            int num1 = index1;
            int num2 = 10;
            int index2 = num2 != -1 ? num1 % num2 : 0;
            Binding binding = blockSelect[index2];
            string str2 = keybinds.get((KeyBinds.KeyBind) binding).key.toString();
            str1 = stringBuilder.append(str2).append("]").toString();
            break;
          }
        }
      }
      string str3 = str1;
      obj1.left();
      obj1.add((Element) new Image(obj0.icon(Cicon.__\u003C\u003Emedium))).size(32f);
      obj1.labelWrap((Prov) new PlacementFragment.__\u003C\u003EAnon30(this, obj0, str3)).left().width(190f).padLeft(5f);
      obj1.add().growX();
      if (!this.unlocked(obj0))
        return;
      obj1.button("?", Styles.clearPartialt, (Runnable) new PlacementFragment.__\u003C\u003EAnon31(obj0)).size(40f).padTop(-5f).padRight(-5f).right().grow().name("blockinfo");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 212, 140, 116, 241, 78, 102, 231, 48, 230, 82})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002418([In] Block obj0, [In] Table obj1)
    {
      obj1.top().left();
      ItemStack[] requirements = obj0.requirements;
      int length = requirements.Length;
      for (int index = 0; index < length; ++index)
      {
        ItemStack itemStack = requirements[index];
        obj1.table((Cons) new PlacementFragment.__\u003C\u003EAnon28(itemStack)).left();
        obj1.row();
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 237, 127, 1, 127, 31, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002419([In] Table obj0)
    {
      obj0.image((Drawable) Icon.cancel).padRight(2f).color(Color.__\u003C\u003Escarlet);
      Table table = obj0;
      object obj = Vars.player.isBuilder() ? (object) "@banned" : (object) "@unit.nobuild";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).width(190f).wrap();
      obj0.left();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 216, 103, 127, 2, 127, 58, 246, 73, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002417([In] ItemStack obj0, [In] Table obj1)
    {
      obj1.left();
      obj1.image(obj0.item.icon(Cicon.__\u003C\u003Esmall)).size(16f);
      Table table = obj1;
      object localizedName = (object) obj0.item.localizedName;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) localizedName;
      CharSequence text = charSequence;
      ((Label) table.add(text).maxWidth(140f).fillX().color(Color.__\u003C\u003ElightGray).padLeft(2f).left().get()).setEllipsis(true);
      obj1.labelWrap((Prov) new PlacementFragment.__\u003C\u003EAnon29(obj0)).padLeft(5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 220, 107, 159, 11, 114, 127, 0, 159, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024build\u002416([In] ItemStack obj0)
    {
      CoreBlock.CoreBuild coreBuild = Vars.player.core();
      if (coreBuild == null || Vars.state.rules.infiniteResources)
      {
        object obj = (object) "*/*";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }
      int number = coreBuild.items.get(obj0.item);
      int num = Math.round((float) obj0.amount * Vars.state.rules.buildCostMultiplier);
      object obj1 = (object) new StringBuilder().append((double) number >= (double) ((float) num / 2f) ? (number >= num ? "[white]" : "[accent]") : "[scarlet]").append(UI.formatAmount(number)).append("[white]/").append(num).toString();
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      return charSequence1;
    }

    [Modifiers]
    [LineNumberTable(313)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024build\u002413([In] Block obj0, [In] string obj1)
    {
      object obj = this.unlocked(obj0) ? (object) new StringBuilder().append(obj0.localizedName).append(obj1).toString() : (object) Core.bundle.get("block.unknown");
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 204, 112, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002414([In] Block obj0)
    {
      Vars.ui.content.show((UnlockableContent) obj0);
      Events.fire((object) new EventType.BlockInfoEvent());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 114, 108, 126, 127, 16, 145, 127, 11, 191, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00245([In] Block obj0)
    {
      if (!this.unlocked(obj0))
        return;
      if (Core.input.keyDown(KeyCode.__\u003C\u003EshiftLeft) && Fonts.getUnicode(obj0.__\u003C\u003Ename) != 0)
      {
        Core.app.setClipboardText(new StringBuilder().append((char) Fonts.getUnicode(obj0.__\u003C\u003Ename)).append("").toString());
        Vars.ui.showInfoFade("@copied");
      }
      else
      {
        Vars.control.input.block = !object.ReferenceEquals((object) Vars.control.input.block, (object) obj0) ? obj0 : (Block) null;
        this.selectedBlocks.put((object) this.currentCategory, (object) Vars.control.input.block);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 127, 107, 127, 65, 113, 159, 2, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00248([In] Block obj0, [In] ImageButton obj1)
    {
      CoreBlock.CoreBuild coreBuild = Vars.player.core();
      Color color = !Vars.state.rules.infiniteResources && (coreBuild == null || !coreBuild.items.has(obj0.requirements, Vars.state.rules.buildCostMultiplier) && !Vars.state.rules.infiniteResources) || !Vars.player.isBuilder() ? Color.__\u003C\u003Egray : Color.__\u003C\u003Ewhite;
      obj1.forEach((Cons) new PlacementFragment.__\u003C\u003EAnon37(color));
      obj1.setChecked(object.ReferenceEquals((object) Vars.control.input.block, (object) obj0));
      if (obj0.isPlaceable())
        return;
      obj1.forEach((Cons) new PlacementFragment.__\u003C\u003EAnon38());
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00249([In] Block obj0) => this.menuHoverBlock = obj0;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002410([In] Block obj0)
    {
      if (!object.ReferenceEquals((object) this.menuHoverBlock, (object) obj0))
        return;
      this.menuHoverBlock = (Block) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 153, 127, 3, 112, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002411()
    {
      this.blockPane.setScrollYForce(this.scrollPositions.get((object) this.currentCategory, 0.0f));
      this.blockPane.act(0.0f);
      this.blockPane.layout();
    }

    [Modifiers]
    [LineNumberTable(243)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00246([In] Color obj0, [In] Element obj1) => obj1.setColor(obj0);

    [Modifiers]
    [LineNumberTable(247)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00247([In] Element obj0) => obj0.setColor(Color.__\u003C\u003EdarkGray);

    [Modifiers]
    [LineNumberTable(new byte[] {17, 112, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240()
    {
      Vars.control.input.block = (Block) null;
      this.rebuild();
    }

    [EnclosingMethod(null, "build", "(Larc.scene.Group;)V")]
    [SpecialName]
    internal class \u0031 : Image
    {
      [Modifiers]
      internal PlacementFragment this\u00240;

      [LineNumberTable(382)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] PlacementFragment obj0, [In] Drawable obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
      }

      [LineNumberTable(new byte[] {161, 15, 116, 127, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        if ((double) this.height <= (double) Scl.scl(3f))
          return;
        this.getDrawable().draw(this.x, this.y, this.width, this.height - Scl.scl(3f));
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon0([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00241((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon1([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00242((EventType.UnlockEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon2([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243((EventType.ResetEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon3([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002430((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Comparator
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon4([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public int compare([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024getCategories\u002431((Category) obj0, (Category) obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      private readonly Category arg\u00241;

      internal __\u003C\u003EAnon5([In] Category obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (PlacementFragment.lambda\u0024getByCategory\u002432(this.arg\u00241, (Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Category arg\u00242;

      internal __\u003C\u003EAnon6([In] PlacementFragment obj0, [In] Category obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024getUnlockedByCategory\u002433(this.arg\u00242, (Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Comparator
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public int compare([In] object obj0, [In] object obj1) => PlacementFragment.lambda\u0024getUnlockedByCategory\u002434((Block) obj0, (Block) obj1);

      [SpecialName]
      public Comparator thenComparing([In] Comparator obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public bool equals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      [SpecialName]
      public Comparator reversed() => Comparator.\u003Cdefault\u003Ereversed((Comparator) this);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0, [In] Comparator obj1) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0, obj1);

      [SpecialName]
      public Comparator thenComparing([In] Function obj0) => Comparator.\u003Cdefault\u003EthenComparing((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingInt([In] ToIntFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingInt((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingLong([In] ToLongFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingLong((Comparator) this, obj0);

      [SpecialName]
      public Comparator thenComparingDouble([In] ToDoubleFunction obj0) => Comparator.\u003Cdefault\u003EthenComparingDouble((Comparator) this, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Prov
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Category arg\u00242;

      internal __\u003C\u003EAnon8([In] PlacementFragment obj0, [In] Category obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024getSelectedBlock\u002435(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Boolf
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public bool get([In] object obj0) => (PlacementFragment.lambda\u0024hovered\u002436((Unit) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Boolf
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon10([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.unlocked((Block) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Boolp
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public bool get() => (PlacementFragment.lambda\u0024build\u00244() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon12([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002429((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon13([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024build\u002412();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon14([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002421((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Boolp
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon15([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.hasInfoBox() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Cons
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon16([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002424((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon17([In] PlacementFragment obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002427(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Runnable
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon18([In] PlacementFragment obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002428(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Category arg\u00242;
      private readonly Runnable arg\u00243;

      internal __\u003C\u003EAnon19([In] PlacementFragment obj0, [In] Category obj1, [In] Runnable obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002425(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Cons
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Category arg\u00242;

      internal __\u003C\u003EAnon20([In] PlacementFragment obj0, [In] Category obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002426(this.arg\u00242, (ImageButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Cons
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon21([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002422((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Cons
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public void get([In] object obj0) => PlacementFragment.lambda\u0024build\u002423((ScrollPane) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Cons
    {
      private readonly InputHandler arg\u00241;

      internal __\u003C\u003EAnon23([In] InputHandler obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.buildPlacementUI((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Cons
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon24([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002420((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Cons
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Block arg\u00242;

      internal __\u003C\u003EAnon25([In] PlacementFragment obj0, [In] Block obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002415(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Cons
    {
      private readonly Block arg\u00241;

      internal __\u003C\u003EAnon26([In] Block obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlacementFragment.lambda\u0024build\u002418(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Cons
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public void get([In] object obj0) => PlacementFragment.lambda\u0024build\u002419((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Cons
    {
      private readonly ItemStack arg\u00241;

      internal __\u003C\u003EAnon28([In] ItemStack obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlacementFragment.lambda\u0024build\u002417(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Prov
    {
      private readonly ItemStack arg\u00241;

      internal __\u003C\u003EAnon29([In] ItemStack obj0) => this.arg\u00241 = obj0;

      public object get() => (object) PlacementFragment.lambda\u0024build\u002416(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Prov
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Block arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon30([In] PlacementFragment obj0, [In] Block obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024build\u002413(this.arg\u00242, this.arg\u00243).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      private readonly Block arg\u00241;

      internal __\u003C\u003EAnon31([In] Block obj0) => this.arg\u00241 = obj0;

      public void run() => PlacementFragment.lambda\u0024build\u002414(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Runnable
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Block arg\u00242;

      internal __\u003C\u003EAnon32([In] PlacementFragment obj0, [In] Block obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u00245(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Runnable
    {
      private readonly Block arg\u00241;
      private readonly ImageButton arg\u00242;

      internal __\u003C\u003EAnon33([In] Block obj0, [In] ImageButton obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => PlacementFragment.lambda\u0024build\u00248(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Block arg\u00242;

      internal __\u003C\u003EAnon34([In] PlacementFragment obj0, [In] Block obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u00249(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Runnable
    {
      private readonly PlacementFragment arg\u00241;
      private readonly Block arg\u00242;

      internal __\u003C\u003EAnon35([In] PlacementFragment obj0, [In] Block obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002410(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Runnable
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon36([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024build\u002411();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Cons
    {
      private readonly Color arg\u00241;

      internal __\u003C\u003EAnon37([In] Color obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => PlacementFragment.lambda\u0024build\u00246(this.arg\u00241, (Element) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Cons
    {
      internal __\u003C\u003EAnon38()
      {
      }

      public void get([In] object obj0) => PlacementFragment.lambda\u0024build\u00247((Element) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      private readonly PlacementFragment arg\u00241;

      internal __\u003C\u003EAnon39([In] PlacementFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }
  }
}
