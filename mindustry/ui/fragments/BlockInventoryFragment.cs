// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.BlockInventoryFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene;
using arc.scene.@event;
using arc.scene.actions;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class BlockInventoryFragment : Fragment
  {
    private const float holdWithdraw = 20f;
    private const float holdShrink = 120f;
    internal Table table;
    internal Building tile;
    internal float holdTime;
    internal float emptyTime;
    internal bool holding;
    internal float[] shrinkHoldTimes;
    internal Item lastItem;

    [LineNumberTable(new byte[] {11, 137, 223, 31, 230, 60, 229, 69, 112, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hide()
    {
      if (this.table == null)
        return;
      this.table.actions((Action) Actions.scaleTo(0.0f, 1f, 0.06f, (Interp) Interp.pow3Out), (Action) Actions.run((Runnable) new BlockInventoryFragment.__\u003C\u003EAnon1(this)), (Action) Actions.visible(false));
      this.table.touchable = Touchable.__\u003C\u003Edisabled;
      this.tile = (Building) null;
    }

    [LineNumberTable(new byte[] {0, 110, 102, 129, 103, 127, 13, 97, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showFor(Building t)
    {
      if (object.ReferenceEquals((object) this.tile, (object) t))
      {
        this.hide();
      }
      else
      {
        this.tile = t;
        if (this.tile == null || !this.tile.block.isAccessible() || this.tile.items.total() == 0)
          return;
        this.rebuild(true);
      }
    }

    [LineNumberTable(new byte[] {159, 124, 98, 134, 112, 150, 107, 107, 113, 112, 248, 113, 98, 131, 113, 159, 1, 149, 121, 110, 153, 137, 143, 103, 137, 255, 2, 70, 138, 242, 85, 142, 255, 5, 22, 235, 110, 100, 181, 134, 140, 99, 117, 159, 16, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rebuild([In] bool obj0)
    {
      int num1 = obj0 ? 1 : 0;
      IntSet intSet = new IntSet();
      Arrays.fill(this.shrinkHoldTimes, 0.0f);
      BlockInventoryFragment inventoryFragment = this;
      float num2 = 0.0f;
      double num3 = (double) num2;
      this.emptyTime = num2;
      this.holdTime = (float) num3;
      this.table.clearChildren();
      this.table.clearActions();
      this.table.background((Drawable) Tex.inventory);
      this.table.touchable = Touchable.__\u003C\u003Eenabled;
      this.table.update((Runnable) new BlockInventoryFragment.__\u003C\u003EAnon2(this, intSet));
      int num4 = 3;
      int num5 = 0;
      this.table.margin(4f);
      this.table.defaults().size(40f).pad(4f);
      if (this.tile.block.hasItems)
      {
        for (int index = 0; index < Vars.content.items().size; ++index)
        {
          Item obj = Vars.content.item(index);
          if (this.tile.items.has(obj))
          {
            intSet.add(index);
            Boolp boolp = (Boolp) new BlockInventoryFragment.__\u003C\u003EAnon3(this, obj);
            HandCursorListener handCursorListener = new HandCursorListener();
            handCursorListener.enabled = boolp;
            Element element = this.itemImage(obj.icon(Cicon.__\u003C\u003Exlarge), (Prov) new BlockInventoryFragment.__\u003C\u003EAnon4(this, obj));
            element.addListener((EventListener) handCursorListener);
            element.addListener((EventListener) new BlockInventoryFragment.\u0031(this, boolp, obj));
            this.table.add(element);
            int num6 = num5;
            ++num5;
            int num7 = num4;
            if ((num7 != -1 ? num6 % num7 : 0) == num4 - 1)
              this.table.row();
          }
        }
      }
      if (num5 == 0)
        this.table.setSize(0.0f, 0.0f);
      this.updateTablePosition();
      this.table.visible = true;
      if (num1 != 0)
      {
        this.table.setScale(0.0f, 1f);
        this.table.actions((Action) Actions.scaleTo(1f, 1f, 0.07f, (Interp) Interp.pow3Out));
      }
      else
        this.table.setScale(1f, 1f);
    }

    [Signature("(Larc/graphics/g2d/TextureRegion;Larc/func/Prov<Ljava/lang/CharSequence;>;)Larc/scene/Element;")]
    [LineNumberTable(new byte[] {160, 105, 134, 112, 136, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Element itemImage([In] TextureRegion obj0, [In] Prov obj1)
    {
      Stack stack = new Stack();
      Table table = new Table().left().bottom();
      table.label(obj1);
      stack.add((Element) new Image(obj0));
      stack.add((Element) table);
      return (Element) stack;
    }

    [LineNumberTable(new byte[] {160, 99, 127, 58, 107, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateTablePosition()
    {
      Vec2 vec2 = Core.input.mouseScreen(this.tile.x + (float) (this.tile.block.size * 8) / 2f, this.tile.y + (float) (this.tile.block.size * 8) / 2f);
      this.table.pack();
      this.table.setPosition(vec2.x, vec2.y, 10);
    }

    [LineNumberTable(new byte[] {160, 88, 106, 105, 127, 39, 105, 159, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string round([In] float obj0)
    {
      obj0 = (float) ByteCodeHelper.f2i(obj0);
      if ((double) obj0 >= 1000000.0)
        return new StringBuilder().append(ByteCodeHelper.f2i(obj0 / 1000000f)).append("[gray]").append(Core.bundle.getOrNull("unit.millions")).append("[]").toString();
      return (double) obj0 >= 1000.0 ? new StringBuilder().append(ByteCodeHelper.f2i(obj0 / 1000f)).append(Core.bundle.getOrNull("unit.thousands")).toString() : new StringBuilder().append(ByteCodeHelper.f2i(obj0)).append("").toString();
    }

    [Modifiers]
    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.WorldLoadEvent obj0) => this.hide();

    [Modifiers]
    [LineNumberTable(new byte[] {14, 107, 107, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024hide\u00241()
    {
      this.table.clearChildren();
      this.table.clearListeners();
      this.table.update((Runnable) null);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {34, 127, 33, 139, 114, 149, 171, 118, 147, 112, 127, 18, 119, 103, 139, 223, 9, 102, 117, 98, 159, 19, 119, 124, 104, 99, 109, 108, 99, 124, 245, 56, 233, 75, 170, 114, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024rebuild\u00242([In] IntSet obj0)
    {
      if (Vars.state.isMenu() || this.tile == null || (!this.tile.isValid() || !this.tile.block.isAccessible()) || (double) this.emptyTime >= 120.0)
      {
        this.hide();
      }
      else
      {
        if (this.tile.items.total() == 0)
          this.emptyTime += Time.delta;
        else
          this.emptyTime = 0.0f;
        if (this.holding && this.lastItem != null)
        {
          this.holdTime += Time.delta;
          if ((double) this.holdTime >= 20.0)
          {
            int amount = Math.min(this.tile.items.get(this.lastItem), Vars.player.unit().maxAccepted(this.lastItem));
            Call.requestItem(Vars.player, this.tile, this.lastItem, amount);
            this.holding = false;
            this.holdTime = 0.0f;
            if (Vars.net.client())
              Events.fire((object) new EventType.WithdrawEvent(this.tile, Vars.player, this.lastItem, amount));
          }
        }
        this.updateTablePosition();
        if (this.tile.block.hasItems)
        {
          int num1 = 0;
          if (this.shrinkHoldTimes.Length != Vars.content.items().size)
            this.shrinkHoldTimes = new float[Vars.content.items().size];
          for (int index1 = 0; index1 < Vars.content.items().size; ++index1)
          {
            int num2 = this.tile.items.has(Vars.content.item(index1)) ? 1 : 0;
            int num3 = obj0.contains(index1) ? 1 : 0;
            if (num2 != 0)
            {
              this.shrinkHoldTimes[index1] = 0.0f;
              num1 |= num3 != 0 ? 0 : 1;
            }
            else if (num3 != 0)
            {
              float[] shrinkHoldTimes = this.shrinkHoldTimes;
              int index2 = index1;
              float[] numArray = shrinkHoldTimes;
              numArray[index2] = numArray[index2] + Time.delta;
              num1 |= (double) this.shrinkHoldTimes[index1] >= 120.0 ? 1 : 0;
            }
          }
          if (num1 != 0)
            this.rebuild(false);
        }
        if (!this.table.getChildren().isEmpty())
          return;
        this.hide();
      }
    }

    [Modifiers]
    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024rebuild\u00243([In] Item obj0) => Vars.player.unit().acceptsItem(obj0) && !Vars.state.isPaused() && Vars.player.within((Position) this.tile, 220f);

    [Modifiers]
    [LineNumberTable(new byte[] {101, 117, 150})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024rebuild\u00244([In] Item obj0)
    {
      if (this.tile == null || !this.tile.isValid())
      {
        object obj = (object) "";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }
      object obj1 = (object) this.round((float) this.tile.items.get(obj0));
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      return charSequence1;
    }

    [LineNumberTable(new byte[] {159, 168, 200, 139, 139, 218, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockInventoryFragment()
    {
      BlockInventoryFragment inventoryFragment = this;
      this.table = new Table();
      this.holdTime = 0.0f;
      this.shrinkHoldTimes = new float[Vars.content.items().size];
      Events.on((Class) ClassLiteral<EventType.WorldLoadEvent>.Value, (Cons) new BlockInventoryFragment.__\u003C\u003EAnon0(this));
    }

    [LineNumberTable(new byte[] {159, 185, 112, 108, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent)
    {
      this.table.name = "inventory";
      this.table.setTransform(true);
      parent.setTransform(true);
      parent.addChild((Element) this.table);
    }

    [EnclosingMethod(null, "rebuild", "(Z)V")]
    [SpecialName]
    internal class \u0031 : InputListener
    {
      [Modifiers]
      internal Boolp val\u0024canPick;
      [Modifiers]
      internal Item val\u0024item;
      [Modifiers]
      internal BlockInventoryFragment this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(158)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] BlockInventoryFragment obj0, [In] Boolp obj1, [In] Item obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024canPick = obj1;
        this.val\u0024item = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {111, 127, 62, 124, 103, 124, 113, 108, 112, 159, 14})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool touchDown(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        if (!this.val\u0024canPick.get() || this.this\u00240.tile == null || (!this.this\u00240.tile.isValid() || this.this\u00240.tile.items == null) || !this.this\u00240.tile.items.has(this.val\u0024item))
          return false;
        int amount = Math.min(1, Vars.player.unit().maxAccepted(this.val\u0024item));
        if (amount > 0)
        {
          Call.requestItem(Vars.player, this.this\u00240.tile, this.val\u0024item, amount);
          this.this\u00240.lastItem = this.val\u0024item;
          this.this\u00240.holding = true;
          this.this\u00240.holdTime = 0.0f;
          if (Vars.net.client())
            Events.fire((object) new EventType.WithdrawEvent(this.this\u00240.tile, Vars.player, this.val\u0024item, amount));
        }
        return true;
      }

      [LineNumberTable(new byte[] {125, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void touchUp(
        [In] InputEvent obj0,
        [In] float obj1,
        [In] float obj2,
        [In] int obj3,
        [In] KeyCode obj4)
      {
        this.this\u00240.holding = false;
        this.this\u00240.lastItem = (Item) null;
      }

      [HideFromJava]
      static \u0031() => InputListener.__\u003Cclinit\u003E();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly BlockInventoryFragment arg\u00241;

      internal __\u003C\u003EAnon0([In] BlockInventoryFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.WorldLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly BlockInventoryFragment arg\u00241;

      internal __\u003C\u003EAnon1([In] BlockInventoryFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024hide\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly BlockInventoryFragment arg\u00241;
      private readonly IntSet arg\u00242;

      internal __\u003C\u003EAnon2([In] BlockInventoryFragment obj0, [In] IntSet obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024rebuild\u00242(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolp
    {
      private readonly BlockInventoryFragment arg\u00241;
      private readonly Item arg\u00242;

      internal __\u003C\u003EAnon3([In] BlockInventoryFragment obj0, [In] Item obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get() => (this.arg\u00241.lambda\u0024rebuild\u00243(this.arg\u00242) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Prov
    {
      private readonly BlockInventoryFragment arg\u00241;
      private readonly Item arg\u00242;

      internal __\u003C\u003EAnon4([In] BlockInventoryFragment obj0, [In] Item obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) this.arg\u00241.lambda\u0024rebuild\u00244(this.arg\u00242).__\u003Cref\u003E;
    }
  }
}
