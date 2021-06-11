// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.BlockConfigFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.math;
using arc.scene;
using arc.scene.actions;
using arc.scene.ui.layout;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class BlockConfigFragment : Fragment
  {
    internal Table table;
    internal Building configTile;

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isShown() => this.table.visible && this.configTile != null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Building getSelectedTile() => this.configTile;

    [LineNumberTable(new byte[] {35, 103, 127, 23})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hideConfig()
    {
      this.configTile = (Building) null;
      this.table.actions((Action) Actions.scaleTo(0.0f, 1f, 0.06f, (Interp) Interp.pow3Out), (Action) Actions.visible(false));
    }

    [LineNumberTable(new byte[] {2, 107, 135, 108, 107, 108, 107, 108, 127, 30, 38, 165, 247, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showConfig(Building tile)
    {
      if (!tile.configTapped())
        return;
      this.configTile = tile;
      this.table.visible = true;
      this.table.clear();
      tile.buildConfiguration(this.table);
      this.table.pack();
      this.table.setTransform(true);
      this.table.actions((Action) Actions.scaleTo(0.0f, 1f), (Action) Actions.visible(true), (Action) Actions.scaleTo(1f, 1f, 0.07f, (Interp) Interp.pow3Out));
      this.table.update((Runnable) new BlockConfigFragment.__\u003C\u003EAnon1(this));
    }

    [LineNumberTable(new byte[] {30, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasConfigMouse()
    {
      Element element = Core.scene.hit((float) Core.input.mouseX(), (float) (Core.graphics.getHeight() - Core.input.mouseY()), true);
      return element != null && (object.ReferenceEquals((object) element, (object) this.table) || element.isDescendantOf((Element) this.table));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 180, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00240([In] EventType.ResetEvent obj0)
    {
      this.table.visible = false;
      this.configTile = (Building) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {14, 122, 102, 161, 108, 127, 13, 136, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showConfig\u00241()
    {
      if (this.configTile != null && this.configTile.shouldHideConfigure(Vars.player))
      {
        this.hideConfig();
      }
      else
      {
        this.table.setOrigin(1);
        if (this.configTile == null || object.ReferenceEquals((object) this.configTile.block, (object) Blocks.air) || !this.configTile.isValid())
          this.hideConfig();
        else
          this.configTile.updateTableAlign(this.table);
      }
    }

    [LineNumberTable(new byte[] {159, 157, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BlockConfigFragment()
    {
      BlockConfigFragment blockConfigFragment = this;
      this.table = new Table();
    }

    [LineNumberTable(new byte[] {159, 163, 108, 204, 240, 75, 213})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent)
    {
      this.table.visible = false;
      parent.addChild((Element) this.table);
      Core.scene.add((Element) new BlockConfigFragment.\u0031(this));
      Events.on((Class) ClassLiteral<EventType.ResetEvent>.Value, (Cons) new BlockConfigFragment.__\u003C\u003EAnon0(this));
    }

    [EnclosingMethod(null, "build", "(Larc.scene.Group;)V")]
    [SpecialName]
    internal class \u0031 : Element
    {
      [Modifiers]
      internal BlockConfigFragment this\u00240;

      [LineNumberTable(26)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] BlockConfigFragment obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 171, 104, 108, 113, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void act([In] float obj0)
      {
        base.act(obj0);
        if (!Vars.state.isMenu())
          return;
        this.this\u00240.table.visible = false;
        this.this\u00240.configTile = (Building) null;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly BlockConfigFragment arg\u00241;

      internal __\u003C\u003EAnon0([In] BlockConfigFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((EventType.ResetEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly BlockConfigFragment arg\u00241;

      internal __\u003C\u003EAnon1([In] BlockConfigFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024showConfig\u00241();
    }
  }
}
