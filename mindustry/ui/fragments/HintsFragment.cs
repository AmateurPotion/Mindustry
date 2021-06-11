// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.HintsFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.input;
using arc.math;
using arc.scene;
using arc.scene.@event;
using arc.scene.actions;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using mindustry.input;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class HintsFragment : Fragment
  {
    [Modifiers]
    private static Boolp isTutorial;
    private const float foutTime = 0.6f;
    [Signature("Larc/struct/Seq<Lmindustry/ui/fragments/HintsFragment$Hint;>;")]
    public Seq hints;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    internal HintsFragment.Hint current;
    internal Group group;
    [Signature("Larc/struct/ObjectSet<Ljava/lang/String;>;")]
    internal ObjectSet events;
    [Signature("Larc/struct/ObjectSet<Lmindustry/world/Block;>;")]
    internal ObjectSet placedBlocks;
    internal Table last;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 232, 69, 186, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HintsFragment()
    {
      HintsFragment hintsFragment = this;
      this.hints = new Seq().and((object[]) HintsFragment.DefaultHint.values()).@as();
      this.group = (Group) new WidgetGroup();
      this.events = new ObjectSet();
      this.placedBlocks = new ObjectSet();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Boolp access\u0024000() => HintsFragment.isTutorial;

    [LineNumberTable(new byte[] {32, 137, 118, 150, 123, 99, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void checkNext()
    {
      if (this.current != null)
        return;
      this.hints.removeAll((Boolf) new HintsFragment.__\u003C\u003EAnon4());
      this.hints.sort((Floatf) new HintsFragment.__\u003C\u003EAnon5());
      HintsFragment.Hint hint = (HintsFragment.Hint) this.hints.find((Boolf) new HintsFragment.__\u003C\u003EAnon6());
      if (hint == null)
        return;
      this.hints.remove((object) hint);
      this.display(hint);
    }

    [LineNumberTable(new byte[] {45, 137, 247, 79, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void display([In] HintsFragment.Hint obj0)
    {
      if (this.current != null)
        return;
      this.group.fill((Cons) new HintsFragment.__\u003C\u003EAnon7(this, obj0));
      this.current = obj0;
    }

    [LineNumberTable(new byte[] {78, 104, 191, 53, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void hide()
    {
      if (this.last != null)
        this.last.actions((arc.scene.Action) Actions.parallel((arc.scene.Action) Actions.alpha(0.0f, 0.6f, Interp.smooth), (arc.scene.Action) Actions.translateBy(0.0f, Scl.scl(-200f), 0.6f, Interp.smooth)), (arc.scene.Action) Actions.remove());
      this.current = (HintsFragment.Hint) null;
      this.last = (Table) null;
      this.checkNext();
    }

    [LineNumberTable(new byte[] {67, 137, 107, 146, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void complete()
    {
      if (this.current == null)
        return;
      this.current.finish();
      this.hints.remove((object) this.current);
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u00241() => Core.settings.getBool("hints", true) && Vars.ui.hudfrag.shown;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 185, 136, 109, 107, 109, 136, 142, 123, 107, 111, 99, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00242()
    {
      if (this.current != null)
      {
        if (this.current.complete())
        {
          this.complete();
        }
        else
        {
          if (this.current.show())
            return;
          this.hide();
        }
      }
      else
      {
        if (this.hints.size <= 0)
          return;
        HintsFragment.Hint hint = (HintsFragment.Hint) this.hints.find((Boolf) new HintsFragment.__\u003C\u003EAnon6());
        if (hint != null && hint.complete())
        {
          this.hints.remove((object) hint);
        }
        else
        {
          if (hint == null)
            return;
          this.display(hint);
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {15, 127, 0, 183, 104, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00243([In] EventType.BlockBuildEndEvent obj0)
    {
      if (!obj0.__\u003C\u003Ebreaking && object.ReferenceEquals((object) obj0.__\u003C\u003Eunit, (object) Vars.player.unit()))
        this.placedBlocks.add((object) obj0.__\u003C\u003Etile.block());
      if (!obj0.__\u003C\u003Ebreaking)
        return;
      this.events.add((object) "break");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {25, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00244([In] EventType.ResetEvent obj0)
    {
      this.placedBlocks.clear();
      this.events.clear();
    }

    [Modifiers]
    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkNext\u00245([In] HintsFragment.Hint obj0) => !obj0.valid() || obj0.finished() || obj0.show() && obj0.complete();

    [Modifiers]
    [LineNumberTable(new byte[] {48, 103, 103, 215, 103, 223, 6, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00248([In] HintsFragment.Hint obj0, [In] Table obj1)
    {
      this.last = obj1;
      obj1.left();
      obj1.table(Styles.black5, (Cons) new HintsFragment.__\u003C\u003EAnon8(obj0));
      obj1.row();
      obj1.button("@hint.skip", Styles.nonet, (Runnable) new HintsFragment.__\u003C\u003EAnon9(this)).size(112f, 40f).left();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {51, 127, 17, 127, 48})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024display\u00246([In] HintsFragment.Hint obj0, [In] Table obj1)
    {
      obj1.actions((arc.scene.Action) Actions.alpha(0.0f), (arc.scene.Action) Actions.alpha(1f, 1f, Interp.smooth));
      Table table = obj1.margin(6f);
      object obj = (object) obj0.text();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).width(!Vars.mobile ? 400f : 270f).left().labelAlign(8).wrap();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {56, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00247()
    {
      if (this.current == null)
        return;
      this.complete();
    }

    [Modifiers]
    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00240() => object.ReferenceEquals((object) Vars.state.rules.sector, (object) SectorPresets.groundZero.sector);

    [LineNumberTable(new byte[] {159, 181, 108, 112, 117, 247, 82, 140, 134, 245, 74, 245, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent)
    {
      this.group.setFillParent(true);
      this.group.touchable = Touchable.__\u003C\u003EchildrenOnly;
      this.group.visibility = (Boolp) new HintsFragment.__\u003C\u003EAnon0();
      this.group.update((Runnable) new HintsFragment.__\u003C\u003EAnon1(this));
      parent.addChild((Element) this.group);
      this.checkNext();
      Events.on((Class) ClassLiteral<EventType.BlockBuildEndEvent>.Value, (Cons) new HintsFragment.__\u003C\u003EAnon2(this));
      Events.on((Class) ClassLiteral<EventType.ResetEvent>.Value, (Cons) new HintsFragment.__\u003C\u003EAnon3(this));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shown() => this.current != null;

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static HintsFragment()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ui.fragments.HintsFragment"))
        return;
      HintsFragment.isTutorial = (Boolp) new HintsFragment.__\u003C\u003EAnon10();
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/ui/fragments/HintsFragment$DefaultHint;>;Lmindustry/ui/fragments/HintsFragment$Hint;")]
    [Modifiers]
    [Implements(new string[] {"mindustry.ui.fragments.HintsFragment$Hint"})]
    [Serializable]
    public sealed class DefaultHint : Enum, HintsFragment.Hint
    {
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EdesktopMove;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Ezoom;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Emine;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EplaceDrill;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EplaceConveyor;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EplaceTurret;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Ebreaking;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EdesktopShoot;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EdepositItems;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EdesktopPause;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Eresearch;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EunitControl;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Erespawn;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Elaunch;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EschematicSelect;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EconveyorPathfind;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Eboost;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Ecommand;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EpayloadPickup;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EpayloadDrop;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EwaveFire;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Egenerator;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003Eguardian;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EcoreUpgrade;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EpresetLaunch;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EcoreIncinerate;
      [Modifiers]
      internal static HintsFragment.DefaultHint __\u003C\u003EcoopCampaign;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      internal string text;
      internal int visibility;
      internal HintsFragment.Hint[] dependencies;
      internal bool finished;
      internal bool cached;
      internal Boolp complete;
      internal Boolp shown;
      [Modifiers]
      private static HintsFragment.DefaultHint[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(Larc/func/Boolp;)V")]
      [LineNumberTable(new byte[] {160, 72, 234, 59, 103, 140, 176, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private DefaultHint([In] string obj0, [In] int obj1, [In] Boolp obj2)
        : base(obj0, obj1)
      {
        HintsFragment.DefaultHint defaultHint = this;
        this.visibility = 3;
        this.dependencies = new HintsFragment.Hint[0];
        this.shown = (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon0();
        this.complete = obj2;
        GC.KeepAlive((object) this);
      }

      [Signature("(ILarc/func/Boolp;)V")]
      [LineNumberTable(new byte[] {160, 77, 108, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private DefaultHint([In] string obj0, [In] int obj1, [In] int obj2, [In] Boolp obj3)
        : this(obj0, obj1, obj3)
      {
        HintsFragment.DefaultHint defaultHint = this;
        this.visibility = obj2;
        GC.KeepAlive((object) this);
      }

      [Signature("(Larc/func/Boolp;Larc/func/Boolp;)V")]
      [LineNumberTable(new byte[] {160, 82, 108, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private DefaultHint([In] string obj0, [In] int obj1, [In] Boolp obj2, [In] Boolp obj3)
        : this(obj0, obj1, obj3)
      {
        HintsFragment.DefaultHint defaultHint = this;
        this.shown = obj2;
        GC.KeepAlive((object) this);
      }

      [Signature("(ILarc/func/Boolp;Larc/func/Boolp;)V")]
      [LineNumberTable(new byte[] {160, 87, 108, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private DefaultHint([In] string obj0, [In] int obj1, [In] int obj2, [In] Boolp obj3, [In] Boolp obj4)
        : this(obj0, obj1, obj4)
      {
        HintsFragment.DefaultHint defaultHint = this;
        this.shown = obj3;
        this.visibility = obj2;
        GC.KeepAlive((object) this);
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u002447() => true;

      [Modifiers]
      [LineNumberTable(236)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024show\u002448([In] HintsFragment.Hint obj0) => !obj0.finished();

      [Modifiers]
      [LineNumberTable(142)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00240() => (double) Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_x) != 0.0 || (double) Core.input.axis((KeyBinds.KeyBind) Binding.__\u003C\u003Emove_y) != 0.0;

      [Modifiers]
      [LineNumberTable(143)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00241() => (double) Core.input.axis(KeyCode.__\u003C\u003Escroll) != 0.0;

      [Modifiers]
      [LineNumberTable(144)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00242() => Vars.player.unit().canMine() && HintsFragment.access\u0024000().get();

      [Modifiers]
      [LineNumberTable(144)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00243() => Vars.player.unit().mining();

      [Modifiers]
      [LineNumberTable(145)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00244() => Vars.ui.hints.placedBlocks.contains((object) Blocks.mechanicalDrill);

      [Modifiers]
      [LineNumberTable(146)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00245() => Vars.ui.hints.placedBlocks.contains((object) Blocks.conveyor);

      [Modifiers]
      [LineNumberTable(147)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00246() => Vars.ui.hints.placedBlocks.contains((object) Blocks.duo);

      [Modifiers]
      [LineNumberTable(148)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00247() => Vars.ui.hints.events.contains((object) "break");

      [Modifiers]
      [LineNumberTable(149)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00248() => Vars.state.enemies > 0;

      [Modifiers]
      [LineNumberTable(149)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u00249() => Vars.player.shooting;

      [Modifiers]
      [LineNumberTable(150)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002410() => Vars.player.unit().hasItem();

      [Modifiers]
      [LineNumberTable(150)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002411() => !Vars.player.unit().hasItem();

      [Modifiers]
      [LineNumberTable(151)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002412() => HintsFragment.access\u0024000().get() && !Vars.net.active();

      [Modifiers]
      [LineNumberTable(151)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002413() => Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Epause);

      [Modifiers]
      [LineNumberTable(152)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002414() => Vars.ui.research.isShown();

      [Modifiers]
      [LineNumberTable(153)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002415() => Vars.state.rules.defaultTeam.data().units.size > 2 && !Vars.net.active() && !Vars.player.dead();

      [Modifiers]
      [LineNumberTable(153)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002416() => !Vars.player.dead() && !Vars.player.unit().spawnedByCore;

      [Modifiers]
      [LineNumberTable(154)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002417() => !Vars.player.dead() && !Vars.player.unit().spawnedByCore;

      [Modifiers]
      [LineNumberTable(154)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002418() => !Vars.player.dead() && Vars.player.unit().spawnedByCore;

      [Modifiers]
      [LineNumberTable(155)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002419() => HintsFragment.access\u0024000().get() && Vars.state.rules.sector.isCaptured();

      [Modifiers]
      [LineNumberTable(155)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002420() => Vars.ui.planet.isShown();

      [Modifiers]
      [LineNumberTable(156)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002421() => Vars.ui.hints.placedBlocks.contains((object) Blocks.router);

      [Modifiers]
      [LineNumberTable(156)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002422() => Core.input.keyRelease((KeyBinds.KeyBind) Binding.__\u003C\u003Eschematic_select) || Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Epick);

      [Modifiers]
      [LineNumberTable(157)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002423() => object.ReferenceEquals((object) Vars.control.input.block, (object) Blocks.titaniumConveyor);

      [Modifiers]
      [LineNumberTable(157)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002424() => Core.input.keyRelease((KeyBinds.KeyBind) Binding.__\u003C\u003Ediagonal_placement) || Vars.mobile && Core.settings.getBool("swapdiagonal");

      [Modifiers]
      [LineNumberTable(158)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002425() => !Vars.player.dead() && Vars.player.unit().type.canBoost;

      [Modifiers]
      [LineNumberTable(158)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002426() => Core.input.keyDown((KeyBinds.KeyBind) Binding.__\u003C\u003Eboost);

      [Modifiers]
      [LineNumberTable(159)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002427() => Vars.state.rules.defaultTeam.data().units.size > 3 && !Vars.net.active();

      [Modifiers]
      [LineNumberTable(159)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002428() => Vars.player.unit().isCommanding();

      [Modifiers]
      [LineNumberTable(160)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002429()
      {
        if (!Vars.player.unit().dead)
        {
          Unit unit = Vars.player.unit();
          Payloadc payloadc;
          if (unit is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit), (object) (Payloadc) unit) && payloadc.payloads().isEmpty())
            return true;
        }
        return false;
      }

      [Modifiers]
      [LineNumberTable(160)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002430()
      {
        Unit unit = Vars.player.unit();
        Payloadc payloadc;
        return unit is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit), (object) (Payloadc) unit) && payloadc.payloads().any();
      }

      [Modifiers]
      [LineNumberTable(161)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002431()
      {
        if (!Vars.player.unit().dead)
        {
          Unit unit = Vars.player.unit();
          Payloadc payloadc;
          if (unit is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit), (object) (Payloadc) unit) && payloadc.payloads().any())
            return true;
        }
        return false;
      }

      [Modifiers]
      [LineNumberTable(161)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002432()
      {
        Unit unit = Vars.player.unit();
        Payloadc payloadc;
        return unit is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit), (object) (Payloadc) unit) && payloadc.payloads().isEmpty();
      }

      [Modifiers]
      [LineNumberTable(162)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002433() => Groups.fire.size() > 0 && Blocks.wave.unlockedNow();

      [Modifiers]
      [LineNumberTable(162)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002434() => Vars.indexer.getAllied(Vars.state.rules.defaultTeam, BlockFlag.__\u003C\u003Eextinguisher).size() > 0;

      [Modifiers]
      [LineNumberTable(163)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002435() => object.ReferenceEquals((object) Vars.control.input.block, (object) Blocks.combustionGenerator);

      [Modifiers]
      [LineNumberTable(163)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002436() => Vars.ui.hints.placedBlocks.contains((object) Blocks.combustionGenerator);

      [Modifiers]
      [LineNumberTable(164)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002437() => Vars.state.boss() != null && (double) Vars.state.boss().armor >= 4.0;

      [Modifiers]
      [LineNumberTable(164)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002438() => Vars.state.boss() == null;

      [Modifiers]
      [LineNumberTable(new byte[] {115, 127, 11, 118, 127, 6, 255, 0, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002439() => Vars.state.isCampaign() && Blocks.coreFoundation.unlocked() && (Vars.state.rules.defaultTeam.core() != null && object.ReferenceEquals((object) Vars.state.rules.defaultTeam.core().block, (object) Blocks.coreShard)) && Vars.state.rules.defaultTeam.core().items.has(Blocks.coreFoundation.requirements);

      [Modifiers]
      [LineNumberTable(169)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002440() => Vars.ui.hints.placedBlocks.contains((object) Blocks.coreFoundation);

      [Modifiers]
      [LineNumberTable(new byte[] {120, 113, 113, 28})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002441() => Vars.state.isCampaign() && Vars.state.getSector().preset == null && (SectorPresets.frozenForest.unlocked() && SectorPresets.frozenForest.sector.save == null);

      [Modifiers]
      [LineNumberTable(174)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002442() => Vars.state.isCampaign() && object.ReferenceEquals((object) Vars.state.getSector().preset, (object) SectorPresets.frozenForest);

      [Modifiers]
      [LineNumberTable(175)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002443() => Vars.state.isCampaign() && Vars.state.rules.defaultTeam.core() != null && Vars.state.rules.defaultTeam.core().items.get(Items.copper) >= Vars.state.rules.defaultTeam.core().storageCapacity - 10;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002444() => false;

      [Modifiers]
      [LineNumberTable(176)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002445() => Vars.net.client() && Vars.state.isCampaign() && SectorPresets.groundZero.sector.hasBase();

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024static\u002446() => false;

      [LineNumberTable(141)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static HintsFragment.DefaultHint[] values() => (HintsFragment.DefaultHint[]) HintsFragment.DefaultHint.\u0024VALUES.Clone();

      [LineNumberTable(141)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static HintsFragment.DefaultHint valueOf(string name) => (HintsFragment.DefaultHint) Enum.valueOf((Class) ClassLiteral<HintsFragment.DefaultHint>.Value, name);

      [LineNumberTable(new byte[] {160, 94, 104, 103, 159, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool finished()
      {
        if (!this.cached)
        {
          this.cached = true;
          this.finished = Core.settings.getBool(new StringBuilder().append(this.name()).append("-hint-done").toString(), false);
        }
        return this.finished;
      }

      [LineNumberTable(new byte[] {160, 103, 127, 27})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void finish()
      {
        Settings settings = Core.settings;
        string name = new StringBuilder().append(this.name()).append("-hint-done").toString();
        HintsFragment.DefaultHint defaultHint = this;
        int num1 = 1;
        int num2 = num1;
        this.finished = num1 != 0;
        Boolean boolean = Boolean.valueOf(num2 != 0);
        settings.put(name, (object) boolean);
      }

      [LineNumberTable(new byte[] {160, 108, 107, 127, 160, 65, 159, 89})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string text()
      {
        if (this.text == null)
        {
          this.text = !Vars.mobile || !Core.bundle.has(new StringBuilder().append("hint.").append(this.name()).append(".mobile").toString()) ? Core.bundle.get(new StringBuilder().append("hint.").append(this.name()).toString()) : Core.bundle.get(new StringBuilder().append("hint.").append(this.name()).append(".mobile").toString());
          if (!Vars.mobile)
          {
            string text = this.text;
            object obj1 = (object) "click";
            object obj2 = (object) "tap";
            CharSequence charSequence1;
            charSequence1.__\u003Cref\u003E = (__Null) obj2;
            CharSequence charSequence2 = charSequence1;
            object obj3 = obj1;
            charSequence1.__\u003Cref\u003E = (__Null) obj3;
            CharSequence charSequence3 = charSequence1;
            string str = String.instancehelper_replace(text, charSequence2, charSequence3);
            object obj4 = (object) "Click";
            object obj5 = (object) "Tap";
            charSequence1.__\u003Cref\u003E = (__Null) obj5;
            CharSequence charSequence4 = charSequence1;
            object obj6 = obj4;
            charSequence1.__\u003Cref\u003E = (__Null) obj6;
            CharSequence charSequence5 = charSequence1;
            this.text = String.instancehelper_replace(str, charSequence4, charSequence5);
          }
        }
        return this.text;
      }

      [LineNumberTable(231)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool complete() => this.complete.get();

      [LineNumberTable(236)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool show() => this.shown.get() && (this.dependencies.Length == 0 || !Structs.contains((object[]) this.dependencies, (Boolf) new HintsFragment.DefaultHint.__\u003C\u003EAnon1()));

      [LineNumberTable(241)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int order() => this.ordinal();

      [LineNumberTable(246)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool valid() => Vars.mobile && (this.visibility & 2) != 0 || !Vars.mobile && (this.visibility & 1) != 0;

      [LineNumberTable(new byte[] {159, 107, 141, 123, 123, 127, 5, 127, 0, 127, 0, 127, 0, 127, 0, 127, 6, 127, 5, 127, 7, 127, 1, 127, 6, 127, 7, 127, 6, 127, 7, 127, 6, 127, 7, 127, 6, 127, 6, 127, 6, 127, 6, 127, 6, 127, 6, 255, 6, 69, 255, 6, 69, 127, 6, 255, 6, 29})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static DefaultHint()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.ui.fragments.HintsFragment$DefaultHint"))
          return;
        HintsFragment.DefaultHint.__\u003C\u003EdesktopMove = new HintsFragment.DefaultHint(nameof (desktopMove), 0, 1, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon2());
        HintsFragment.DefaultHint.__\u003C\u003Ezoom = new HintsFragment.DefaultHint(nameof (zoom), 1, 1, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon3());
        HintsFragment.DefaultHint.__\u003C\u003Emine = new HintsFragment.DefaultHint(nameof (mine), 2, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon4(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon5());
        HintsFragment.DefaultHint.__\u003C\u003EplaceDrill = new HintsFragment.DefaultHint(nameof (placeDrill), 3, HintsFragment.access\u0024000(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon6());
        HintsFragment.DefaultHint.__\u003C\u003EplaceConveyor = new HintsFragment.DefaultHint(nameof (placeConveyor), 4, HintsFragment.access\u0024000(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon7());
        HintsFragment.DefaultHint.__\u003C\u003EplaceTurret = new HintsFragment.DefaultHint(nameof (placeTurret), 5, HintsFragment.access\u0024000(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon8());
        HintsFragment.DefaultHint.__\u003C\u003Ebreaking = new HintsFragment.DefaultHint(nameof (breaking), 6, HintsFragment.access\u0024000(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon9());
        HintsFragment.DefaultHint.__\u003C\u003EdesktopShoot = new HintsFragment.DefaultHint(nameof (desktopShoot), 7, 1, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon10(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon11());
        HintsFragment.DefaultHint.__\u003C\u003EdepositItems = new HintsFragment.DefaultHint(nameof (depositItems), 8, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon12(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon13());
        HintsFragment.DefaultHint.__\u003C\u003EdesktopPause = new HintsFragment.DefaultHint(nameof (desktopPause), 9, 1, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon14(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon15());
        HintsFragment.DefaultHint.__\u003C\u003Eresearch = new HintsFragment.DefaultHint(nameof (research), 10, HintsFragment.access\u0024000(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon16());
        HintsFragment.DefaultHint.__\u003C\u003EunitControl = new HintsFragment.DefaultHint(nameof (unitControl), 11, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon17(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon18());
        HintsFragment.DefaultHint.__\u003C\u003Erespawn = new HintsFragment.DefaultHint(nameof (respawn), 12, 2, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon19(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon20());
        HintsFragment.DefaultHint.__\u003C\u003Elaunch = new HintsFragment.DefaultHint(nameof (launch), 13, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon21(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon22());
        HintsFragment.DefaultHint.__\u003C\u003EschematicSelect = new HintsFragment.DefaultHint(nameof (schematicSelect), 14, 1, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon23(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon24());
        HintsFragment.DefaultHint.__\u003C\u003EconveyorPathfind = new HintsFragment.DefaultHint(nameof (conveyorPathfind), 15, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon25(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon26());
        HintsFragment.DefaultHint.__\u003C\u003Eboost = new HintsFragment.DefaultHint(nameof (boost), 16, 1, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon27(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon28());
        HintsFragment.DefaultHint.__\u003C\u003Ecommand = new HintsFragment.DefaultHint(nameof (command), 17, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon29(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon30());
        HintsFragment.DefaultHint.__\u003C\u003EpayloadPickup = new HintsFragment.DefaultHint(nameof (payloadPickup), 18, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon31(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon32());
        HintsFragment.DefaultHint.__\u003C\u003EpayloadDrop = new HintsFragment.DefaultHint(nameof (payloadDrop), 19, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon33(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon34());
        HintsFragment.DefaultHint.__\u003C\u003EwaveFire = new HintsFragment.DefaultHint(nameof (waveFire), 20, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon35(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon36());
        HintsFragment.DefaultHint.__\u003C\u003Egenerator = new HintsFragment.DefaultHint(nameof (generator), 21, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon37(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon38());
        HintsFragment.DefaultHint.__\u003C\u003Eguardian = new HintsFragment.DefaultHint(nameof (guardian), 22, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon39(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon40());
        HintsFragment.DefaultHint.__\u003C\u003EcoreUpgrade = new HintsFragment.DefaultHint(nameof (coreUpgrade), 23, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon41(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon42());
        HintsFragment.DefaultHint.__\u003C\u003EpresetLaunch = new HintsFragment.DefaultHint(nameof (presetLaunch), 24, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon43(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon44());
        HintsFragment.DefaultHint.__\u003C\u003EcoreIncinerate = new HintsFragment.DefaultHint(nameof (coreIncinerate), 25, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon45(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon46());
        HintsFragment.DefaultHint.__\u003C\u003EcoopCampaign = new HintsFragment.DefaultHint(nameof (coopCampaign), 26, (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon47(), (Boolp) new HintsFragment.DefaultHint.__\u003C\u003EAnon48());
        HintsFragment.DefaultHint.\u0024VALUES = new HintsFragment.DefaultHint[27]
        {
          HintsFragment.DefaultHint.__\u003C\u003EdesktopMove,
          HintsFragment.DefaultHint.__\u003C\u003Ezoom,
          HintsFragment.DefaultHint.__\u003C\u003Emine,
          HintsFragment.DefaultHint.__\u003C\u003EplaceDrill,
          HintsFragment.DefaultHint.__\u003C\u003EplaceConveyor,
          HintsFragment.DefaultHint.__\u003C\u003EplaceTurret,
          HintsFragment.DefaultHint.__\u003C\u003Ebreaking,
          HintsFragment.DefaultHint.__\u003C\u003EdesktopShoot,
          HintsFragment.DefaultHint.__\u003C\u003EdepositItems,
          HintsFragment.DefaultHint.__\u003C\u003EdesktopPause,
          HintsFragment.DefaultHint.__\u003C\u003Eresearch,
          HintsFragment.DefaultHint.__\u003C\u003EunitControl,
          HintsFragment.DefaultHint.__\u003C\u003Erespawn,
          HintsFragment.DefaultHint.__\u003C\u003Elaunch,
          HintsFragment.DefaultHint.__\u003C\u003EschematicSelect,
          HintsFragment.DefaultHint.__\u003C\u003EconveyorPathfind,
          HintsFragment.DefaultHint.__\u003C\u003Eboost,
          HintsFragment.DefaultHint.__\u003C\u003Ecommand,
          HintsFragment.DefaultHint.__\u003C\u003EpayloadPickup,
          HintsFragment.DefaultHint.__\u003C\u003EpayloadDrop,
          HintsFragment.DefaultHint.__\u003C\u003EwaveFire,
          HintsFragment.DefaultHint.__\u003C\u003Egenerator,
          HintsFragment.DefaultHint.__\u003C\u003Eguardian,
          HintsFragment.DefaultHint.__\u003C\u003EcoreUpgrade,
          HintsFragment.DefaultHint.__\u003C\u003EpresetLaunch,
          HintsFragment.DefaultHint.__\u003C\u003EcoreIncinerate,
          HintsFragment.DefaultHint.__\u003C\u003EcoopCampaign
        };
      }

      string HintsFragment.Hint.__\u003Coverridestub\u003Emindustry\u002Eui\u002Efragments\u002EHintsFragment\u0024Hint\u003A\u003Aname() => this.name();

      [Modifiers]
      public static HintsFragment.DefaultHint desktopMove
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EdesktopMove;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint zoom
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Ezoom;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint mine
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Emine;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint placeDrill
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EplaceDrill;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint placeConveyor
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EplaceConveyor;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint placeTurret
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EplaceTurret;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint breaking
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Ebreaking;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint desktopShoot
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EdesktopShoot;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint depositItems
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EdepositItems;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint desktopPause
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EdesktopPause;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint research
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Eresearch;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint unitControl
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EunitControl;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint respawn
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Erespawn;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint launch
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Elaunch;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint schematicSelect
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EschematicSelect;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint conveyorPathfind
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EconveyorPathfind;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint boost
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Eboost;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint command
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Ecommand;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint payloadPickup
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EpayloadPickup;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint payloadDrop
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EpayloadDrop;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint waveFire
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EwaveFire;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint generator
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Egenerator;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint guardian
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003Eguardian;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint coreUpgrade
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EcoreUpgrade;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint presetLaunch
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EpresetLaunch;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint coreIncinerate
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EcoreIncinerate;
      }

      [Modifiers]
      public static HintsFragment.DefaultHint coopCampaign
      {
        [HideFromJava] get => HintsFragment.DefaultHint.__\u003C\u003EcoopCampaign;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        desktopMove,
        zoom,
        mine,
        placeDrill,
        placeConveyor,
        placeTurret,
        breaking,
        desktopShoot,
        depositItems,
        desktopPause,
        research,
        unitControl,
        respawn,
        launch,
        schematicSelect,
        conveyorPathfind,
        boost,
        command,
        payloadPickup,
        payloadDrop,
        waveFire,
        generator,
        guardian,
        coreUpgrade,
        presetLaunch,
        coreIncinerate,
        coopCampaign,
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Boolp
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024new\u002447() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Boolf
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public bool get([In] object obj0) => (HintsFragment.DefaultHint.lambda\u0024show\u002448((HintsFragment.Hint) obj0) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Boolp
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00240() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon3 : Boolp
      {
        internal __\u003C\u003EAnon3()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00241() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon4 : Boolp
      {
        internal __\u003C\u003EAnon4()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00242() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon5 : Boolp
      {
        internal __\u003C\u003EAnon5()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00243() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon6 : Boolp
      {
        internal __\u003C\u003EAnon6()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00244() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon7 : Boolp
      {
        internal __\u003C\u003EAnon7()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00245() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon8 : Boolp
      {
        internal __\u003C\u003EAnon8()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00246() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon9 : Boolp
      {
        internal __\u003C\u003EAnon9()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00247() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : Boolp
      {
        internal __\u003C\u003EAnon10()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00248() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon11 : Boolp
      {
        internal __\u003C\u003EAnon11()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u00249() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon12 : Boolp
      {
        internal __\u003C\u003EAnon12()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002410() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon13 : Boolp
      {
        internal __\u003C\u003EAnon13()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002411() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon14 : Boolp
      {
        internal __\u003C\u003EAnon14()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002412() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon15 : Boolp
      {
        internal __\u003C\u003EAnon15()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002413() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon16 : Boolp
      {
        internal __\u003C\u003EAnon16()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002414() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon17 : Boolp
      {
        internal __\u003C\u003EAnon17()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002415() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon18 : Boolp
      {
        internal __\u003C\u003EAnon18()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002416() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon19 : Boolp
      {
        internal __\u003C\u003EAnon19()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002417() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon20 : Boolp
      {
        internal __\u003C\u003EAnon20()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002418() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon21 : Boolp
      {
        internal __\u003C\u003EAnon21()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002419() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon22 : Boolp
      {
        internal __\u003C\u003EAnon22()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002420() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon23 : Boolp
      {
        internal __\u003C\u003EAnon23()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002421() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon24 : Boolp
      {
        internal __\u003C\u003EAnon24()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002422() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon25 : Boolp
      {
        internal __\u003C\u003EAnon25()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002423() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon26 : Boolp
      {
        internal __\u003C\u003EAnon26()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002424() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon27 : Boolp
      {
        internal __\u003C\u003EAnon27()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002425() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon28 : Boolp
      {
        internal __\u003C\u003EAnon28()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002426() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon29 : Boolp
      {
        internal __\u003C\u003EAnon29()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002427() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon30 : Boolp
      {
        internal __\u003C\u003EAnon30()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002428() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon31 : Boolp
      {
        internal __\u003C\u003EAnon31()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002429() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon32 : Boolp
      {
        internal __\u003C\u003EAnon32()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002430() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon33 : Boolp
      {
        internal __\u003C\u003EAnon33()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002431() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon34 : Boolp
      {
        internal __\u003C\u003EAnon34()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002432() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon35 : Boolp
      {
        internal __\u003C\u003EAnon35()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002433() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon36 : Boolp
      {
        internal __\u003C\u003EAnon36()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002434() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon37 : Boolp
      {
        internal __\u003C\u003EAnon37()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002435() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon38 : Boolp
      {
        internal __\u003C\u003EAnon38()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002436() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon39 : Boolp
      {
        internal __\u003C\u003EAnon39()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002437() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon40 : Boolp
      {
        internal __\u003C\u003EAnon40()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002438() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon41 : Boolp
      {
        internal __\u003C\u003EAnon41()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002439() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon42 : Boolp
      {
        internal __\u003C\u003EAnon42()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002440() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon43 : Boolp
      {
        internal __\u003C\u003EAnon43()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002441() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon44 : Boolp
      {
        internal __\u003C\u003EAnon44()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002442() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon45 : Boolp
      {
        internal __\u003C\u003EAnon45()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002443() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon46 : Boolp
      {
        internal __\u003C\u003EAnon46()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002444() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon47 : Boolp
      {
        internal __\u003C\u003EAnon47()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002445() ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon48 : Boolp
      {
        internal __\u003C\u003EAnon48()
        {
        }

        public bool get() => (HintsFragment.DefaultHint.lambda\u0024static\u002446() ? 1 : 0) != 0;
      }
    }

    public interface Hint
    {
      const int visibleDesktop = 1;
      const int visibleMobile = 2;
      const int visibleAll = 3;

      string name();

      string text();

      bool complete();

      bool show();

      int order();

      bool valid();

      [Modifiers]
      void finish();

      [LineNumberTable(new byte[] {160, 155, 127, 16})]
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static void \u003Cdefault\u003Efinish([In] HintsFragment.Hint obj0) => Core.settings.put(new StringBuilder().append(obj0.name()).append("-hint-done").toString(), (object) Boolean.valueOf(true));

      [Modifiers]
      bool finished();

      [LineNumberTable(274)]
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static bool \u003Cdefault\u003Efinished([In] HintsFragment.Hint obj0) => Core.settings.getBool(new StringBuilder().append(obj0.name()).append("-hint-done").toString(), false);

      [HideFromJava]
      static class __DefaultMethods
      {
        public static void finish([In] HintsFragment.Hint obj0)
        {
          HintsFragment.Hint hint = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(hint, ToString);
          HintsFragment.Hint.\u003Cdefault\u003Efinish(hint);
        }

        public static bool finished([In] HintsFragment.Hint obj0)
        {
          HintsFragment.Hint hint = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(hint, ToString);
          return HintsFragment.Hint.\u003Cdefault\u003Efinished(hint);
        }
      }

      [HideFromJava]
      static class __Fields
      {
        public const int visibleDesktop = 1;
        public const int visibleMobile = 2;
        public const int visibleAll = 3;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolp
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get() => (HintsFragment.lambda\u0024build\u00241() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly HintsFragment arg\u00241;

      internal __\u003C\u003EAnon1([In] HintsFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024build\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly HintsFragment arg\u00241;

      internal __\u003C\u003EAnon2([In] HintsFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00243((EventType.BlockBuildEndEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly HintsFragment arg\u00241;

      internal __\u003C\u003EAnon3([In] HintsFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00244((EventType.ResetEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (HintsFragment.lambda\u0024checkNext\u00245((HintsFragment.Hint) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Floatf
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public float get([In] object obj0) => (float) ((HintsFragment.Hint) obj0).order();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] object obj0) => (((HintsFragment.Hint) obj0).show() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly HintsFragment arg\u00241;
      private readonly HintsFragment.Hint arg\u00242;

      internal __\u003C\u003EAnon7([In] HintsFragment obj0, [In] HintsFragment.Hint obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00248(this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly HintsFragment.Hint arg\u00241;

      internal __\u003C\u003EAnon8([In] HintsFragment.Hint obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => HintsFragment.lambda\u0024display\u00246(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly HintsFragment arg\u00241;

      internal __\u003C\u003EAnon9([In] HintsFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024display\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Boolp
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public bool get() => (HintsFragment.lambda\u0024static\u00240() ? 1 : 0) != 0;
    }
  }
}
