// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.HudFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
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
using mindustry.content;
using mindustry.core;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.graphics;
using mindustry.input;
using mindustry.net;
using mindustry.type;
using mindustry.ui.dialogs;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class HudFragment : Fragment
  {
    private const float dsize = 65f;
    internal PlacementFragment __\u003C\u003Eblockfrag;
    public bool shown;
    private ImageButton flip;
    private CoreItemsDisplay coreItems;
    private string hudText;
    private bool showHudText;
    private Table lastUnlockTable;
    private Table lastUnlockLayout;
    private long lastToast;

    [LineNumberTable(new byte[] {161, 183, 102, 112, 107, 103, 127, 2, 242, 70, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showLand()
    {
      Image image = new Image();
      image.__\u003C\u003Ecolor.a = 1f;
      image.touchable = Touchable.__\u003C\u003Edisabled;
      image.setFillParent(true);
      image.actions((Action) Actions.fadeOut(0.8f), (Action) Actions.remove());
      image.update((Runnable) new HudFragment.__\u003C\u003EAnon17(image));
      Core.scene.add((Element) image);
    }

    [LineNumberTable(new byte[] {161, 75, 141, 171, 104, 247, 104, 130, 166, 113, 167, 165, 152, 107, 157, 104, 153, 114, 236, 60, 232, 73, 132, 114, 141, 110, 98, 177, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showUnlock(UnlockableContent content)
    {
      if (Vars.state.isMenu())
        return;
      Sounds.message.play();
      if (this.lastUnlockTable == null)
      {
        this.scheduleToast((Runnable) new HudFragment.__\u003C\u003EAnon15(this, content));
      }
      else
      {
        int num1 = 3;
        int num2 = num1 * num1 - 1;
        Seq seq = new Seq((Seq) this.lastUnlockLayout.getChildren());
        int size1 = seq.size;
        if (size1 > num2)
          return;
        float size2 = 48f / (float) Math.min(seq.size + 1, num1);
        this.lastUnlockLayout.clearChildren();
        this.lastUnlockLayout.defaults().size(size2).pad(2f);
        for (int index = 0; index < size1; ++index)
        {
          this.lastUnlockLayout.add((Element) seq.get(index));
          int num3 = index;
          int num4 = num1;
          if ((num4 != -1 ? num3 % num4 : 0) == num1 - 1)
            this.lastUnlockLayout.row();
        }
        if (size1 < num2)
        {
          Image image = new Image(content.icon(Cicon.__\u003C\u003Emedium));
          image.setScaling(Scaling.__\u003C\u003Efit);
          this.lastUnlockLayout.add((Element) image);
        }
        else
          this.lastUnlockLayout.image((Drawable) Icon.add);
        this.lastUnlockLayout.pack();
      }
    }

    [LineNumberTable(new byte[] {161, 45, 141, 242, 86})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showToast(Drawable icon, string text)
    {
      if (Vars.state.isMenu())
        return;
      this.scheduleToast((Runnable) new HudFragment.__\u003C\u003EAnon14(icon, text));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setHudText(string text)
    {
      this.showHudText = true;
      this.hudText = text;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toggleHudText(bool shown) => this.showHudText = shown;

    [LineNumberTable(new byte[] {159, 174, 168, 107, 167, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HudFragment()
    {
      HudFragment hudFragment = this;
      this.__\u003C\u003Eblockfrag = new PlacementFragment();
      this.shown = true;
      this.coreItems = new CoreItemsDisplay();
      this.hudText = "";
    }

    [LineNumberTable(new byte[] {2, 245, 84, 213, 213, 213, 245, 70, 241, 71, 241, 78, 176, 241, 160, 152, 241, 71, 240, 73, 240, 71, 241, 98, 240, 70, 241, 114, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void build(Group parent)
    {
      Events.on((Class) ClassLiteral<EventType.WaveEvent>.Value, (Cons) new HudFragment.__\u003C\u003EAnon0(this));
      Events.on((Class) ClassLiteral<EventType.SectorCaptureEvent>.Value, (Cons) new HudFragment.__\u003C\u003EAnon1(this));
      Events.on((Class) ClassLiteral<EventType.SectorLoseEvent>.Value, (Cons) new HudFragment.__\u003C\u003EAnon2(this));
      Events.on((Class) ClassLiteral<EventType.SectorInvasionEvent>.Value, (Cons) new HudFragment.__\u003C\u003EAnon3(this));
      Events.on((Class) ClassLiteral<EventType.ResetEvent>.Value, (Cons) new HudFragment.__\u003C\u003EAnon4(this));
      parent.fill((Cons) new HudFragment.__\u003C\u003EAnon5(this));
      parent.fill((Cons) new HudFragment.__\u003C\u003EAnon6(this));
      Vars.ui.hints.build(parent);
      parent.fill((Cons) new HudFragment.__\u003C\u003EAnon7(this));
      parent.fill((Cons) new HudFragment.__\u003C\u003EAnon8(this));
      parent.fill((Cons) new HudFragment.__\u003C\u003EAnon9());
      parent.fill((Cons) new HudFragment.__\u003C\u003EAnon10());
      parent.fill((Cons) new HudFragment.__\u003C\u003EAnon11(this));
      parent.fill((Cons) new HudFragment.__\u003C\u003EAnon12());
      parent.fill((Cons) new HudFragment.__\u003C\u003EAnon13(this));
      this.__\u003C\u003Eblockfrag.build(parent);
    }

    [LineNumberTable(new byte[] {161, 14, 111, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setPlayerTeamEditor(Player player, Team team)
    {
      if (!Vars.state.isEditor() || player == null)
        return;
      player.team(team);
    }

    [LineNumberTable(new byte[] {161, 162, 102, 112, 103, 127, 20, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showLaunchDirect()
    {
      Image image = new Image();
      image.__\u003C\u003Ecolor.a = 0.0f;
      image.setFillParent(true);
      image.actions((Action) Actions.fadeIn(2.333333f, (Interp) Interp.pow2In), (Action) Actions.delay(0.1333333f), (Action) Actions.remove());
      Core.scene.add((Element) image);
    }

    [LineNumberTable(new byte[] {161, 29, 103, 108, 100, 107, 136, 121, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void scheduleToast([In] Runnable obj0)
    {
      long num1 = 3500;
      long num2 = Time.timeSinceMillis(this.lastToast);
      if (num2 > num1)
      {
        this.lastToast = Time.millis();
        obj0.run();
      }
      else
      {
        Time.runTask((float) (num1 - num2) / 1000f * 60f, obj0);
        this.lastToast += num1;
      }
    }

    [LineNumberTable(new byte[] {161, 206, 144, 134, 107, 107, 108, 108, 108, 108, 247, 79, 139, 135, 139, 255, 1, 160, 80, 255, 24, 92, 144, 254, 104, 144, 135, 112, 247, 74, 155})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Table makeStatusTable()
    {
      Table.__\u003Cclinit\u003E();
      Table table1 = new Table((Drawable) Tex.wavepane);
      StringBuilder stringBuilder1 = new StringBuilder();
      IntFormat intFormat1 = new IntFormat("wave");
      IntFormat intFormat2 = new IntFormat("wave.cap");
      IntFormat intFormat3 = new IntFormat("wave.enemy");
      IntFormat intFormat4 = new IntFormat("wave.enemies");
      IntFormat intFormat5 = new IntFormat("wave.enemycore");
      IntFormat intFormat6 = new IntFormat("wave.enemycores");
      IntFormat intFormat7 = new IntFormat("wave.waiting", (Func) new HudFragment.__\u003C\u003EAnon18(stringBuilder1));
      table1.touchable = Touchable.__\u003C\u003Eenabled;
      StringBuilder stringBuilder2 = new StringBuilder();
      table1.name = "waves";
      table1.marginTop(0.0f).marginBottom(4f).marginLeft(4f);
      Table table2 = table1;
      Element[] elementArray = new Element[2]
      {
        (Element) new HudFragment.\u0031(this),
        null
      };
      Table.__\u003Cclinit\u003E();
      elementArray[1] = (Element) new Table((Cons) new HudFragment.__\u003C\u003EAnon19(this));
      table2.stack(elementArray).size(120f, 80f).padRight(4f);
      table1.labelWrap((Prov) new HudFragment.__\u003C\u003EAnon20(stringBuilder2, intFormat6, intFormat5, intFormat2, intFormat1, intFormat3, intFormat4, intFormat7)).growX().pad(8f);
      table1.row();
      float[] numArray = new float[1]{ -1f };
      table1.table().update((Cons) new HudFragment.__\u003C\u003EAnon21(numArray)).growX().visible((Boolp) new HudFragment.__\u003C\u003EAnon22()).colspan(2);
      return table1;
    }

    [LineNumberTable(778)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool canSkipWave() => Vars.state.rules.waves && (Vars.net.server() || Vars.player.admin || !Vars.net.active()) && (Vars.state.enemies == 0 && !Vars.spawner.isSpawning());

    [LineNumberTable(new byte[] {161, 198, 104, 191, 5, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void toggleMenus()
    {
      if (this.flip != null)
        this.flip.getStyle().imageUp = !this.shown ? (Drawable) Icon.upOpen : (Drawable) Icon.downOpen;
      this.shown = !this.shown;
    }

    [LineNumberTable(new byte[] {161, 41, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showToast(string text) => this.showToast((Drawable) Icon.ok, text);

    [Modifiers]
    [LineNumberTable(new byte[] {3, 99, 159, 22, 127, 8, 127, 14, 127, 5, 176, 117, 255, 50, 69, 229, 52, 233, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00240([In] EventType.WaveEvent obj0)
    {
      int num1 = 10;
      int num2 = !Vars.state.isCampaign() || Vars.state.rules.winWave <= 0 ? int.MaxValue : Vars.state.rules.winWave;
      for (int wave = Vars.state.wave - 1; wave <= Math.min(Vars.state.wave + num1, num2 - 2); ++wave)
      {
        Iterator iterator = Vars.state.rules.spawns.iterator();
        while (iterator.hasNext())
        {
          SpawnGroup spawnGroup = (SpawnGroup) iterator.next();
          if (object.ReferenceEquals((object) spawnGroup.effect, (object) StatusEffects.boss) && spawnGroup.getSpawned(wave) > 0)
          {
            int num3 = wave + 2 - Vars.state.wave;
            switch (num3)
            {
              case 1:
              case 2:
              case 5:
              case 10:
                this.showToast((Drawable) Icon.warning, Core.bundle.format(new StringBuilder().append("wave.guardianwarn").append(num3 != 1 ? "" : ".one").toString(), (object) Integer.valueOf(num3)));
                return;
              default:
                return;
            }
          }
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {23, 127, 55})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00241([In] EventType.SectorCaptureEvent obj0) => this.showToast(Core.bundle.format("sector.captured", !obj0.__\u003C\u003Esector.isBeingPlayed() ? (object) new StringBuilder().append(obj0.__\u003C\u003Esector.name()).append(" ").toString() : (object) ""));

    [Modifiers]
    [LineNumberTable(new byte[] {27, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00242([In] EventType.SectorLoseEvent obj0) => this.showToast((Drawable) Icon.warning, Core.bundle.format("sector.lost", (object) obj0.__\u003C\u003Esector.name()));

    [Modifiers]
    [LineNumberTable(new byte[] {31, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00243([In] EventType.SectorInvasionEvent obj0) => this.showToast((Drawable) Icon.warning, Core.bundle.format("sector.attacked", (object) obj0.__\u003C\u003Esector.name()));

    [Modifiers]
    [LineNumberTable(new byte[] {35, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00244([In] EventType.ResetEvent obj0)
    {
      this.coreItems.resetUsed();
      this.coreItems.clear();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {41, 107, 127, 1, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u00248([In] Table obj0)
    {
      obj0.name = "paused";
      obj0.top().visible((Boolp) new HudFragment.__\u003C\u003EAnon88(this)).touchable = Touchable.__\u003C\u003Edisabled;
      obj0.table(Styles.black5, (Cons) new HudFragment.__\u003C\u003EAnon89()).growX();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {48, 107, 146, 118, 135, 122, 106, 106, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002412([In] Table obj0)
    {
      obj0.name = "minimap/position";
      obj0.visible((Boolp) new HudFragment.__\u003C\u003EAnon85(this));
      obj0.add((Element) new Minimap()).name("minimap");
      obj0.row();
      obj0.label((Prov) new HudFragment.__\u003C\u003EAnon86()).visible((Boolp) new HudFragment.__\u003C\u003EAnon87()).touchable(Touchable.__\u003C\u003Edisabled).name("position");
      obj0.top().right();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {65, 107, 140, 103, 242, 118, 103, 127, 1, 167, 242, 75, 127, 18, 134, 114, 149, 246, 76, 134, 135, 117, 159, 10, 135, 107, 250, 84, 102, 178, 241, 85, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002438([In] Table obj0)
    {
      obj0.name = "overlaymarker";
      obj0.top().left();
      if (Vars.mobile)
      {
        obj0.table((Cons) new HudFragment.__\u003C\u003EAnon56(this));
        obj0.row();
        obj0.image().height(4f).color(Pal.gray).fillX();
        obj0.row();
      }
      obj0.update((Runnable) new HudFragment.__\u003C\u003EAnon57(this));
      Table table1;
      Table table2;
      obj0.stack((Element) (table1 = new Table()), (Element) (table2 = new Table())).height(table1.getPrefHeight()).name("waves/editor");
      table1.visible((Boolp) new HudFragment.__\u003C\u003EAnon58(this));
      table1.top().left().name = "waves";
      table1.table((Cons) new HudFragment.__\u003C\u003EAnon59(this)).width(329f);
      table1.row();
      table1.table((Drawable) Tex.button, (Cons) new HudFragment.__\u003C\u003EAnon60()).fillX().visible((Boolp) new HudFragment.__\u003C\u003EAnon61()).height(60f).name("boss");
      table1.row();
      table2.name = "editor";
      table2.table((Drawable) Tex.buttonEdge4, (Cons) new HudFragment.__\u003C\u003EAnon62()).width(329f);
      table2.visible((Boolp) new HudFragment.__\u003C\u003EAnon63(this));
      obj0.table((Cons) new HudFragment.__\u003C\u003EAnon64(this)).top().left();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 153, 107, 114, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002440([In] Table obj0)
    {
      obj0.name = "coreitems";
      obj0.top().add((Element) this.coreItems);
      obj0.visible((Boolp) new HudFragment.__\u003C\u003EAnon55(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 160, 107, 107, 186, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002444([In] Table obj0)
    {
      obj0.name = "nearpoint";
      obj0.touchable = Touchable.__\u003C\u003Edisabled;
      obj0.table(Styles.black, (Cons) new HudFragment.__\u003C\u003EAnon52()).margin(6f).update((Cons) new HudFragment.__\u003C\u003EAnon53()).get().__\u003C\u003Ecolor.a = 0.0f;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 169, 107, 113, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002447([In] Table obj0)
    {
      obj0.name = "waiting";
      obj0.visible((Boolp) new HudFragment.__\u003C\u003EAnon50());
      obj0.table((Drawable) Tex.button, (Cons) new HudFragment.__\u003C\u003EAnon51());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 176, 107, 107, 102, 111, 143, 214, 250, 82, 122, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002452([In] Table obj0)
    {
      obj0.name = "coreattack";
      obj0.touchable = Touchable.__\u003C\u003Edisabled;
      float num = 240f;
      float[] numArray1 = new float[1]{ 0.0f };
      float[] numArray2 = new float[1]{ 0.0f };
      Events.run((object) EventType.Trigger.__\u003C\u003EteamCoreDamage, (Runnable) new HudFragment.__\u003C\u003EAnon46(numArray1, num));
      obj0.top().visible((Boolp) new HudFragment.__\u003C\u003EAnon47(this, numArray1, obj0, numArray2));
      obj0.table((Drawable) Tex.button, (Cons) new HudFragment.__\u003C\u003EAnon48()).touchable(Touchable.__\u003C\u003Edisabled);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 210, 107, 118, 127, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002454([In] Table obj0)
    {
      obj0.name = "saving";
      obj0.bottom().visible((Boolp) new HudFragment.__\u003C\u003EAnon45());
      Table table = obj0;
      object obj = (object) "@saving";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).style((Style) Styles.outlineLabel);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 216, 107, 127, 1, 127, 1, 243, 71, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002458([In] Table obj0)
    {
      obj0.name = "hudtext";
      obj0.top().table(Styles.black3, (Cons) new HudFragment.__\u003C\u003EAnon42(this)).padTop(10f).visible((double) obj0.__\u003C\u003Ecolor.a >= 1.0 / 1000.0);
      obj0.update((Runnable) new HudFragment.__\u003C\u003EAnon43(this, obj0));
      obj0.touchable = Touchable.__\u003C\u003Edisabled;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 48, 139, 112, 242, 69, 108, 114, 127, 24, 166, 107, 109, 114, 159, 34, 6, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showToast\u002468([In] Drawable obj0, [In] string obj1)
    {
      Sounds.message.play();
      Table.__\u003Cclinit\u003E();
      Table table1 = new Table((Drawable) Tex.button);
      table1.update((Runnable) new HudFragment.__\u003C\u003EAnon34(table1));
      table1.margin(12f);
      table1.image(obj0).pad(3f);
      Table table2 = table1;
      object obj = (object) obj1;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      ((Label) table2.add(text).wrap().width(280f).get()).setAlignment(1, 1);
      table1.pack();
      Table table3 = Core.scene.table();
      table3.top().add((Element) table1);
      table3.setTranslation(0.0f, table1.getPrefHeight());
      table3.actions((Action) Actions.translateBy(0.0f, -table1.getPrefHeight(), 1f, Interp.fade), (Action) Actions.delay(2.5f), (Action) Actions.run((Runnable) new HudFragment.__\u003C\u003EAnon35(table3, table1)));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 82, 112, 243, 71, 140, 166, 113, 140, 188, 114, 124, 166, 108, 110, 115, 159, 37, 6, 229, 71, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showUnlock\u002472([In] UnlockableContent obj0)
    {
      Table.__\u003Cclinit\u003E();
      Table table1 = new Table((Drawable) Tex.button);
      table1.update((Runnable) new HudFragment.__\u003C\u003EAnon31(this, table1));
      table1.margin(12f);
      Table table2 = new Table();
      Image image = new Image(obj0.icon(Cicon.__\u003C\u003Exlarge));
      image.setScaling(Scaling.__\u003C\u003Efit);
      table2.add((Element) image).size(48f).pad(2f);
      table1.add((Element) table2).padRight(8f);
      Table table3 = table1;
      object obj = (object) "@unlocked";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table3.add(text);
      table1.pack();
      Table table4 = Core.scene.table();
      table4.top().add((Element) table1);
      table4.setTranslation(0.0f, table1.getPrefHeight());
      table4.actions((Action) Actions.translateBy(0.0f, -table1.getPrefHeight(), 1f, Interp.fade), (Action) Actions.delay(2.5f), (Action) Actions.run((Runnable) new HudFragment.__\u003C\u003EAnon32(this, table4, table1)));
      this.lastUnlockTable = table4;
      this.lastUnlockLayout = table2;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 175, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showLaunch\u002473([In] Image obj0)
    {
      if (!Vars.state.isMenu())
        return;
      obj0.remove();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 189, 102, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showLand\u002474([In] Image obj0)
    {
      obj0.toFront();
      if (!Vars.state.isMenu())
        return;
      obj0.remove();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 217, 103, 106, 115, 100, 104, 108, 101, 172, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024makeStatusTable\u002475([In] StringBuilder obj0, [In] Integer obj1)
    {
      obj0.setLength(0);
      int num1 = obj1.intValue() / 60;
      int num2 = obj1.intValue();
      int num3 = 60;
      int num4 = num3 != -1 ? num2 % num3 : 0;
      if (num1 > 0)
      {
        obj0.append(num1);
        obj0.append(":");
        if (num4 < 10)
          obj0.append("0");
      }
      obj0.append(num4);
      return obj0.toString();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 72, 102, 102, 108, 241, 71, 127, 20, 127, 11, 223, 35, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024makeStatusTable\u002483([In] Table obj0)
    {
      float width = 40f;
      float num = -20f;
      obj0.margin(0.0f);
      obj0.clicked((Runnable) new HudFragment.__\u003C\u003EAnon24());
      obj0.add((Element) new HudFragment.\u0031SideBar(this, (Floatp) new HudFragment.__\u003C\u003EAnon25(), (Boolp) new HudFragment.__\u003C\u003EAnon26(), true)).width(width).growY().padRight(num);
      obj0.image((Prov) new HudFragment.__\u003C\u003EAnon27()).scaling(Scaling.__\u003C\u003Ebounded).grow().maxWidth(54f);
      obj0.add((Element) new HudFragment.\u0031SideBar(this, (Floatp) new HudFragment.__\u003C\u003EAnon28(), (Boolp) new HudFragment.__\u003C\u003EAnon29(), false)).width(width).growY().padLeft(num).update((Cons) new HudFragment.__\u003C\u003EAnon30());
      ((Element) obj0.getChildren().get(1)).toFront();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 92, 135, 127, 9, 127, 6, 127, 28, 180, 125, 191, 1, 113, 180, 127, 29, 159, 34, 159, 18, 140, 112, 109, 159, 20, 159, 18, 172, 113, 127, 61, 108, 182})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024makeStatusTable\u002485(
      [In] StringBuilder obj0,
      [In] IntFormat obj1,
      [In] IntFormat obj2,
      [In] IntFormat obj3,
      [In] IntFormat obj4,
      [In] IntFormat obj5,
      [In] IntFormat obj6,
      [In] IntFormat obj7)
    {
      obj0.setLength(0);
      if (!Vars.state.rules.waves && Vars.state.rules.attackMode)
      {
        int num = Math.max(Vars.state.teams.present.sum((Intf) new HudFragment.__\u003C\u003EAnon23()), 1);
        StringBuilder stringBuilder = obj0;
        object obj8 = num <= 1 ? (object) obj2.get(num).__\u003Cref\u003E : (object) obj1.get(num).__\u003Cref\u003E;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj8;
        CharSequence charSequence2 = charSequence1;
        stringBuilder.append(charSequence2);
        object obj9 = (object) obj0;
        CharSequence charSequence3;
        charSequence3.__\u003Cref\u003E = (__Null) obj9;
        return charSequence3;
      }
      if (!Vars.state.rules.waves && Vars.state.isCampaign())
        obj0.append("[lightgray]").append(Core.bundle.get("sector.curcapture"));
      if (!Vars.state.rules.waves)
      {
        object obj = (object) obj0;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        return charSequence;
      }
      CharSequence charSequence4;
      if (Vars.state.rules.winWave > 1 && Vars.state.rules.winWave >= Vars.state.wave && Vars.state.isCampaign())
      {
        StringBuilder stringBuilder = obj0;
        object obj = (object) obj3.get(Vars.state.wave, Vars.state.rules.winWave).__\u003Cref\u003E;
        charSequence4.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence1 = charSequence4;
        stringBuilder.append(charSequence1);
      }
      else
      {
        StringBuilder stringBuilder = obj0;
        object obj = (object) obj4.get(Vars.state.wave).__\u003Cref\u003E;
        charSequence4.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence1 = charSequence4;
        stringBuilder.append(charSequence1);
      }
      obj0.append("\n");
      if (Vars.state.enemies > 0)
      {
        if (Vars.state.enemies == 1)
        {
          StringBuilder stringBuilder = obj0;
          object obj = (object) obj5.get(Vars.state.enemies).__\u003Cref\u003E;
          charSequence4.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence1 = charSequence4;
          stringBuilder.append(charSequence1);
        }
        else
        {
          StringBuilder stringBuilder = obj0;
          object obj = (object) obj6.get(Vars.state.enemies).__\u003Cref\u003E;
          charSequence4.__\u003Cref\u003E = (__Null) obj;
          CharSequence charSequence1 = charSequence4;
          stringBuilder.append(charSequence1);
        }
        obj0.append("\n");
      }
      if (Vars.state.rules.waveTimer)
      {
        StringBuilder stringBuilder = obj0;
        object obj = !Vars.logic.isWaitingWave() ? (object) (string) obj7.get(ByteCodeHelper.f2i(Vars.state.wavetime / 60f)).__\u003Cref\u003E : (object) Core.bundle.get("wave.waveInProgress");
        charSequence4.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence1 = charSequence4;
        stringBuilder.append(charSequence1);
      }
      else if (Vars.state.enemies == 0)
        obj0.append(Core.bundle.get("waiting"));
      object obj10 = (object) obj0;
      CharSequence charSequence5;
      charSequence5.__\u003Cref\u003E = (__Null) obj10;
      return charSequence5;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 137, 127, 9, 108, 113, 172, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024makeStatusTable\u002486([In] float[] obj0, [In] Table obj1)
    {
      Unit unit = Vars.player.unit();
      Payloadc payloadc;
      if (unit is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit), (object) (Payloadc) unit))
      {
        if ((double) obj0[0] == (double) payloadc.payloadUsed())
          return;
        payloadc.contentInfo(obj1, 16f, 275f);
        obj0[0] = payloadc.payloadUsed();
      }
      else
      {
        obj0[0] = -1f;
        obj1.clear();
      }
    }

    [Modifiers]
    [LineNumberTable(772)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024makeStatusTable\u002487()
    {
      Unit unit = Vars.player.unit();
      Payloadc payloadc;
      return unit is Payloadc && object.ReferenceEquals((object) (payloadc = (Payloadc) unit), (object) (Payloadc) unit) && (double) payloadc.payloadUsed() > 0.0;
    }

    [Modifiers]
    [LineNumberTable(721)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024makeStatusTable\u002484([In] Teams.TeamData obj0) => !object.ReferenceEquals((object) obj0.__\u003C\u003Eteam, (object) Vars.player.team()) ? obj0.__\u003C\u003Ecores.size : 0;

    [Modifiers]
    [LineNumberTable(new byte[] {162, 76, 115, 106, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024makeStatusTable\u002476()
    {
      if (Vars.player.dead() || !Vars.mobile)
        return;
      Call.unitClear(Vars.player);
      Vars.control.input.controlledType = (UnitType) null;
    }

    [Modifiers]
    [LineNumberTable(708)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024makeStatusTable\u002477() => Vars.player.unit().healthf();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024makeStatusTable\u002478() => true;

    [Modifiers]
    [LineNumberTable(709)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static TextureRegion lambda\u0024makeStatusTable\u002479() => Vars.player.icon();

    [Modifiers]
    [LineNumberTable(710)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024makeStatusTable\u002480()
    {
      if (Vars.player.dead())
        return 0.0f;
      return Vars.player.displayAmmo() ? Vars.player.unit().ammof() : Vars.player.unit().healthf();
    }

    [Modifiers]
    [LineNumberTable(710)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024makeStatusTable\u002481() => !Vars.player.displayAmmo();

    [Modifiers]
    [LineNumberTable(new byte[] {162, 85, 127, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024makeStatusTable\u002482([In] HudFragment.\u0031SideBar obj0) => obj0.__\u003C\u003Ecolor.set(!Vars.player.displayAmmo() ? Pal.health : (Vars.player.dead() || Vars.player.unit() is BlockUnitc ? Pal.ammo : Vars.player.unit().type.ammoType.color));

    [Modifiers]
    [LineNumberTable(new byte[] {161, 84, 108, 103, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showUnlock\u002469([In] Table obj0)
    {
      if (!Vars.state.isMenu())
        return;
      obj0.remove();
      this.lastUnlockLayout = (Table) null;
      this.lastUnlockTable = (Table) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 111, 191, 27, 230, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showUnlock\u002471([In] Table obj0, [In] Table obj1) => obj0.actions((Action) Actions.translateBy(0.0f, obj1.getPrefHeight(), 1f, Interp.fade), (Action) Actions.run((Runnable) new HudFragment.__\u003C\u003EAnon33(this)), (Action) Actions.remove());

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showUnlock\u002470()
    {
      this.lastUnlockTable = (Table) null;
      this.lastUnlockLayout = (Table) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 52, 125, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showToast\u002466([In] Table obj0)
    {
      if (!Vars.state.isMenu() && Vars.ui.hudfrag.shown)
        return;
      obj0.remove();
    }

    [Modifiers]
    [LineNumberTable(437)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showToast\u002467([In] Table obj0, [In] Table obj1) => obj0.actions((Action) Actions.translateBy(0.0f, obj1.getPrefHeight(), 1f, Interp.fade), (Action) Actions.remove());

    [Modifiers]
    [LineNumberTable(new byte[] {160, 235, 149, 236, 76, 243, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002462([In] Table obj0)
    {
      Bits bits = new Bits(Vars.content.items().size);
      Runnable runnable = (Runnable) new HudFragment.__\u003C\u003EAnon39(obj0);
      obj0.update((Runnable) new HudFragment.__\u003C\u003EAnon40(bits, runnable));
    }

    [Modifiers]
    [LineNumberTable(376)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u002464() => Vars.state.isCampaign() && Vars.content.items().contains((Boolf) new HudFragment.__\u003C\u003EAnon38());

    [Modifiers]
    [LineNumberTable(376)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u002463([In] Item obj0) => Vars.state.rules.sector != null && (double) Vars.state.rules.sector.info.getExport(obj0) > 0.0;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 238, 134, 127, 8, 127, 20, 114, 124, 135, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002460([In] Table obj0)
    {
      obj0.clearChildren();
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        if (Vars.state.rules.sector != null && (double) Vars.state.rules.sector.info.getExport(obj) >= 1.0)
        {
          obj0.image(obj.icon(Cicon.__\u003C\u003Esmall));
          obj0.label((Prov) new HudFragment.__\u003C\u003EAnon41(obj)).color(Color.__\u003C\u003ElightGray);
          obj0.row();
        }
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 250, 98, 127, 8, 127, 25, 111, 109, 130, 101, 99, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002461([In] Bits obj0, [In] Runnable obj1)
    {
      int num1 = 0;
      Iterator iterator = Vars.content.items().iterator();
      while (iterator.hasNext())
      {
        Item obj = (Item) iterator.next();
        int num2 = Vars.state.rules.sector == null || (double) Vars.state.rules.sector.info.getExport(obj) < 1.0 ? 0 : 1;
        if ((obj0.get((int) obj.__\u003C\u003Eid) ? 1 : 0) != num2)
        {
          obj0.set((int) obj.__\u003C\u003Eid, num2 != 0);
          num1 = 1;
        }
      }
      if (num1 == 0)
        return;
      obj1.run();
    }

    [Modifiers]
    [LineNumberTable(357)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024build\u002459([In] Item obj0)
    {
      object obj = (object) new StringBuilder().append(ByteCodeHelper.f2i(Vars.state.rules.sector.info.getExport(obj0))).append(" /s").toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 217, 127, 1, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002456([In] Table obj0) => obj0.margin(4f).label((Prov) new HudFragment.__\u003C\u003EAnon44(this)).style((Style) Styles.outlineLabel);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 220, 127, 14, 108, 112, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002457([In] Table obj0)
    {
      obj0.__\u003C\u003Ecolor.a = Mathf.lerpDelta(obj0.__\u003C\u003Ecolor.a, (float) Mathf.num(this.showHudText), 0.2f);
      if (!Vars.state.isMenu())
        return;
      obj0.__\u003C\u003Ecolor.a = 0.0f;
      this.showHudText = false;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private CharSequence lambda\u0024build\u002455()
    {
      object hudText = (object) this.hudText;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) hudText;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(325)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u002453() => Vars.control.saves.isSaving();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 183, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002448([In] float[] obj0, [In] float obj1) => obj0[0] = obj1;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 187, 106, 127, 13, 104, 162, 110, 106, 152, 182, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u002449([In] float[] obj0, [In] Table obj1, [In] float[] obj2)
    {
      if (!this.shown)
        return false;
      if (Vars.state.isMenu() || !Vars.state.teams.get(Vars.player.team()).hasCore())
      {
        obj0[0] = 0.0f;
        return false;
      }
      obj1.__\u003C\u003Ecolor.a = obj2[0];
      obj2[0] = (double) obj0[0] <= 0.0 ? Mathf.lerpDelta(obj2[0], 0.0f, 0.1f) : Mathf.lerpDelta(obj2[0], 1f, 0.1f);
      float[] numArray1 = obj0;
      int index = 0;
      float[] numArray2 = numArray1;
      numArray2[index] = numArray2[index] - Time.delta;
      return (double) obj2[0] > 0.0;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 204, 127, 16, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002451([In] Table obj0)
    {
      Table table = obj0;
      object obj = (object) "@coreattack";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).pad(2f).update((Cons) new HudFragment.__\u003C\u003EAnon49());
    }

    [Modifiers]
    [LineNumberTable(319)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002450([In] Label obj0) => obj0.__\u003C\u003Ecolor.set(Color.__\u003C\u003Eorange).lerp(Color.__\u003C\u003Escarlet, Mathf.absin(Time.time, 2f, 1f));

    [Modifiers]
    [LineNumberTable(284)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u002445() => Vars.netServer.isWaitingForPlayers();

    [Modifiers]
    [LineNumberTable(285)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002446([In] Table obj0)
    {
      Table table = obj0;
      object obj = (object) "@waiting.players";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 164, 6, 127, 0, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002442([In] Table obj0)
    {
      Table table = obj0;
      object obj = (object) "@nearpoint";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      ((Label) table.add(text).update((Cons) new HudFragment.__\u003C\u003EAnon54()).get()).setAlignment(1, 1);
    }

    [Modifiers]
    [LineNumberTable(279)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002443([In] Table obj0) => obj0.__\u003C\u003Ecolor.a = Mathf.lerpDelta(obj0.__\u003C\u003Ecolor.a, (float) Mathf.num(Vars.spawner.playerNear()), 0.1f);

    [Modifiers]
    [LineNumberTable(277)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002441([In] Label obj0) => obj0.setColor(Tmp.__\u003C\u003Ec1.set(Color.__\u003C\u003Ewhite).lerp(Color.__\u003C\u003Escarlet, Mathf.absin(Time.time, 10f, 1f)));

    [Modifiers]
    [LineNumberTable(269)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u002439() => Core.settings.getBool("coreitems") && !Vars.mobile && (!Vars.state.isPaused() && this.shown);

    [Modifiers]
    [LineNumberTable(new byte[] {70, 107, 103, 150, 134, 127, 19, 127, 8, 144, 127, 13, 134, 251, 70, 245, 73, 251, 76, 245, 74, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002417([In] Table obj0)
    {
      obj0.name = "mobile buttons";
      obj0.left();
      obj0.defaults().size(65f).left();
      ImageButton.ImageButtonStyle clearTransi = Styles.clearTransi;
      Table table1 = obj0;
      TextureRegionDrawable menu = Icon.menu;
      ImageButton.ImageButtonStyle style1 = clearTransi;
      PausedDialog paused = Vars.ui.paused;
      Objects.requireNonNull((object) paused);
      Runnable listener1 = (Runnable) new HudFragment.__\u003C\u003EAnon78(paused);
      table1.button((Drawable) menu, style1, listener1).name("menu");
      this.flip = (ImageButton) obj0.button((Drawable) Icon.upOpen, clearTransi, (Runnable) new HudFragment.__\u003C\u003EAnon79(this)).get();
      this.flip.name = "flip";
      Table table2 = obj0;
      TextureRegionDrawable paste = Icon.paste;
      ImageButton.ImageButtonStyle style2 = clearTransi;
      SchematicsDialog schematics = Vars.ui.schematics;
      Objects.requireNonNull((object) schematics);
      Runnable listener2 = (Runnable) new HudFragment.__\u003C\u003EAnon80(schematics);
      table2.button((Drawable) paste, style2, listener2).name("schematics");
      obj0.button((Drawable) Icon.pause, clearTransi, (Runnable) new HudFragment.__\u003C\u003EAnon81()).name("pause").update((Cons) new HudFragment.__\u003C\u003EAnon82());
      obj0.button((Drawable) Icon.chat, clearTransi, (Runnable) new HudFragment.__\u003C\u003EAnon83()).name("chat").update((Cons) new HudFragment.__\u003C\u003EAnon84());
      obj0.image().color(Pal.gray).width(4f).fillY();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 65, 127, 32, 185, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002419()
    {
      if (!Core.input.keyTap((KeyBinds.KeyBind) Binding.__\u003C\u003Etoggle_menus) || Vars.ui.chatfrag.shown() || (Core.scene.hasDialog() || Core.scene.getKeyboardFocus() is TextField))
        return;
      Core.settings.getBoolOnce("ui-hidden", (Runnable) new HudFragment.__\u003C\u003EAnon77());
      this.toggleMenus();
    }

    [Modifiers]
    [LineNumberTable(192)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u002420() => this.shown && !Vars.state.isEditor();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 83, 188, 255, 0, 70, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002423([In] Table obj0)
    {
      obj0.add((Element) this.makeStatusTable()).grow().name("status");
      obj0.button((Drawable) Icon.play, Styles.righti, 30f, (Runnable) new HudFragment.__\u003C\u003EAnon75()).growY().fillX().right().width(40f).disabled((Boolf) new HudFragment.__\u003C\u003EAnon76(this)).name("skip");
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 97, 127, 25, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002425([In] Table obj0)
    {
      Table table = obj0.margin(10f);
      mindustry.ui.Bar.__\u003Cclinit\u003E();
      mindustry.ui.Bar bar = new mindustry.ui.Bar("boss.health", Pal.health, (Floatp) new HudFragment.__\u003C\u003EAnon74()).blink(Color.__\u003C\u003Ewhite);
      table.add((Element) bar).grow();
    }

    [Modifiers]
    [LineNumberTable(212)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u002426() => Vars.state.rules.waves && Vars.state.boss() != null;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 105, 107, 127, 7, 103, 240, 78, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002430([In] Table obj0)
    {
      obj0.name = "teams";
      Table table = obj0;
      object obj = (object) "@editor.teams";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).growX().left();
      obj0.row();
      obj0.table((Cons) new HudFragment.__\u003C\u003EAnon71()).left();
    }

    [Modifiers]
    [LineNumberTable(238)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u002431() => this.shown && Vars.state.isEditor();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 128, 107, 107, 127, 7, 107, 107, 107, 139, 127, 12, 135, 103, 159, 14, 159, 12, 135, 159, 39})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024build\u002437([In] Table obj0)
    {
      obj0.name = "fps/ping";
      obj0.touchable = Touchable.__\u003C\u003Edisabled;
      obj0.top().left().margin(4f).visible((Boolp) new HudFragment.__\u003C\u003EAnon65(this));
      IntFormat intFormat1 = new IntFormat("fps");
      IntFormat intFormat2 = new IntFormat("ping");
      IntFormat intFormat3 = new IntFormat("memory");
      IntFormat intFormat4 = new IntFormat("memory2");
      obj0.label((Prov) new HudFragment.__\u003C\u003EAnon66(intFormat1)).left().style((Style) Styles.outlineLabel).name("fps");
      obj0.row();
      if (Vars.android)
        obj0.label((Prov) new HudFragment.__\u003C\u003EAnon67(intFormat4)).left().style((Style) Styles.outlineLabel).name("memory2");
      else
        obj0.label((Prov) new HudFragment.__\u003C\u003EAnon68(intFormat3)).left().style((Style) Styles.outlineLabel).name("memory");
      obj0.row();
      Cell cell = obj0.label((Prov) new HudFragment.__\u003C\u003EAnon69(intFormat2));
      mindustry.net.Net net = Vars.net;
      Objects.requireNonNull((object) net);
      Boolp prov = (Boolp) new HudFragment.__\u003C\u003EAnon70(net);
      cell.visible(prov).left().style((Style) Styles.outlineLabel).name("ping");
    }

    [Modifiers]
    [LineNumberTable(244)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u002432() => Core.settings.getBool("fps") && this.shown;

    [Modifiers]
    [LineNumberTable(250)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024build\u002433([In] IntFormat obj0)
    {
      object obj = (object) obj0.get(Core.graphics.getFramesPerSecond()).__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(254)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024build\u002434([In] IntFormat obj0)
    {
      object obj = (object) obj0.get((int) (Core.app.getJavaHeap() / 1024L / 1024L), (int) (Core.app.getNativeHeap() / 1024L / 1024L)).__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(256)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024build\u002435([In] IntFormat obj0)
    {
      object obj = (object) obj0.get((int) (Core.app.getJavaHeap() / 1024L / 1024L)).__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(260)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024build\u002436([In] IntFormat obj0)
    {
      object obj = (object) obj0.get(Vars.netClient.getPing()).__\u003Cref\u003E;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 109, 103, 98, 119, 127, 7, 123, 109, 115, 150, 114, 231, 56, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002429([In] Table obj0)
    {
      obj0.left();
      int num1 = 0;
      Team[] baseTeams = Team.__\u003C\u003EbaseTeams;
      int length = baseTeams.Length;
      for (int index = 0; index < length; ++index)
      {
        Team team = baseTeams[index];
        ImageButton imageButton = (ImageButton) obj0.button((Drawable) Tex.whiteui, Styles.clearTogglePartiali, 40f, (Runnable) new HudFragment.__\u003C\u003EAnon72(team)).size(50f).margin(6f).get();
        imageButton.getImageCell().grow();
        imageButton.getStyle().imageUpColor = team.__\u003C\u003Ecolor;
        imageButton.update((Runnable) new HudFragment.__\u003C\u003EAnon73(imageButton, team));
        ++num1;
        int num2 = num1;
        int num3 = 3;
        if ((num3 != -1 ? num2 % num3 : 0) == 0)
          obj0.row();
      }
    }

    [Modifiers]
    [LineNumberTable(226)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002427([In] Team obj0) => Call.setPlayerTeamEditor(Vars.player, obj0);

    [Modifiers]
    [LineNumberTable(230)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002428([In] ImageButton obj0, [In] Team obj1) => obj0.setChecked(object.ReferenceEquals((object) Vars.player.team(), (object) obj1));

    [Modifiers]
    [LineNumberTable(211)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024build\u002424() => Vars.state.boss() == null ? 0.0f : Vars.state.boss().healthf();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 87, 120, 145, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002421()
    {
      if (Vars.net.client() && Vars.player.admin)
        Call.adminRequest(Vars.player, Packets.AdminAction.__\u003C\u003Ewave);
      else
        Vars.logic.skipWave();
    }

    [Modifiers]
    [LineNumberTable(206)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u002422([In] ImageButton obj0) => !this.canSkipWave();

    [Modifiers]
    [LineNumberTable(new byte[] {160, 67, 127, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002418() => Vars.ui.announce(Core.bundle.format("showui", (object) Core.keybinds.get((KeyBinds.KeyBind) Binding.__\u003C\u003Etoggle_menus).key.toString(), (object) Integer.valueOf(11)));

    [Modifiers]
    [LineNumberTable(new byte[] {84, 108, 145, 159, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002413()
    {
      if (Vars.net.active())
        Vars.ui.listfrag.toggle();
      else
        Vars.state.set(!Vars.state.@is(GameState.State.__\u003C\u003Epaused) ? GameState.State.__\u003C\u003Epaused : GameState.State.__\u003C\u003Eplaying);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {90, 108, 146, 103, 159, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002414([In] ImageButton obj0)
    {
      if (Vars.net.active())
      {
        obj0.getStyle().imageUp = (Drawable) Icon.players;
      }
      else
      {
        obj0.setDisabled(false);
        obj0.getStyle().imageUp = !Vars.state.@is(GameState.State.__\u003C\u003Epaused) ? (Drawable) Icon.pause : (Drawable) Icon.play;
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {99, 115, 113, 145, 145, 108, 146, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002415()
    {
      if (Vars.net.active() && Vars.mobile)
      {
        if (Vars.ui.chatfrag.shown())
          Vars.ui.chatfrag.hide();
        else
          Vars.ui.chatfrag.toggle();
      }
      else if (Vars.state.isCampaign())
        Vars.ui.research.show();
      else
        Vars.ui.database.show();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {111, 115, 114, 108, 146, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002416([In] ImageButton obj0)
    {
      if (Vars.net.active() && Vars.mobile)
        obj0.getStyle().imageUp = (Drawable) Icon.chat;
      else if (Vars.state.isCampaign())
        obj0.getStyle().imageUp = (Drawable) Icon.tree;
      else
        obj0.getStyle().imageUp = (Drawable) Icon.book;
    }

    [Modifiers]
    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u00249() => Core.settings.getBool("minimap") && this.shown;

    [Modifiers]
    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024build\u002410()
    {
      object obj = (object) new StringBuilder().append(Vars.player.tileX()).append(",").append(Vars.player.tileY()).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [Modifiers]
    [LineNumberTable(105)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024build\u002411() => Core.settings.getBool("position");

    [Modifiers]
    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024build\u00245() => Vars.state.isPaused() && this.shown;

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u00247([In] Table obj0) => obj0.label((Prov) new HudFragment.__\u003C\u003EAnon90()).style((Style) Styles.outlineLabel).pad(8f);

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static CharSequence lambda\u0024build\u00246()
    {
      object obj = !Vars.state.gameOver || !Vars.state.isCampaign() ? (object) "@paused" : (object) "@sector.curlost";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [LineNumberTable(new byte[] {161, 170, 102, 112, 103, 121, 242, 69, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showLaunch()
    {
      Image image = new Image();
      image.__\u003C\u003Ecolor.a = 0.0f;
      image.setFillParent(true);
      image.actions((Action) Actions.fadeIn(0.6666667f));
      image.update((Runnable) new HudFragment.__\u003C\u003EAnon16(image));
      Core.scene.add((Element) image);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 232, 107, 108, 255, 0, 92, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024build\u002465([In] Table obj0)
    {
      obj0.name = "rates";
      obj0.bottom().left();
      obj0.table(Styles.black6, (Cons) new HudFragment.__\u003C\u003EAnon36()).visible((Boolp) new HudFragment.__\u003C\u003EAnon37());
    }

    [Modifiers]
    public PlacementFragment blockfrag
    {
      [HideFromJava] get => this.__\u003C\u003Eblockfrag;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eblockfrag = value;
    }

    [EnclosingMethod(null, "makeStatusTable", "()Larc.scene.ui.layout.Table;")]
    [SpecialName]
    internal class \u0031 : Element
    {
      [Modifiers]
      internal HudFragment this\u00240;

      [LineNumberTable(688)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] HudFragment obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {162, 65, 106, 127, 30, 101, 127, 29})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        Draw.color(Pal.darkerGray);
        Fill.poly(this.x + this.width / 2f, this.y + this.height / 2f, 6, this.height / Mathf.__\u003C\u003Esqrt3);
        Draw.reset();
        Drawf.shadow(this.x + this.width / 2f, this.y + this.height / 2f, this.height * 1.13f);
      }
    }

    [EnclosingMethod(null, "makeStatusTable", "()Larc.scene.ui.layout.Table;")]
    [SpecialName]
    internal class \u0031SideBar : Element
    {
      [Modifiers]
      public Floatp amount;
      [Modifiers]
      public bool flip;
      [Modifiers]
      public Boolp flash;
      internal float last;
      internal float blink;
      internal float value;
      [Modifiers]
      internal HudFragment this\u00240;

      [LineNumberTable(new byte[] {158, 244, 67, 111, 103, 103, 135, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public \u0031SideBar([In] HudFragment obj0, [In] Floatp obj1, [In] Boolp obj2, [In] bool obj3)
      {
        int num = obj3 ? 1 : 0;
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        HudFragment.\u0031SideBar obj = this;
        this.amount = obj1;
        this.flip = num != 0;
        this.flash = obj2;
        this.setColor(Pal.health);
      }

      [LineNumberTable(new byte[] {162, 19, 138, 106, 104, 116, 173, 110, 110, 134, 159, 7, 150, 255, 64, 71, 107, 125, 255, 66, 72, 133, 104, 109, 148})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void drawInner([In] Color obj0, [In] float obj1)
      {
        if ((double) obj1 < 0.0)
          return;
        obj1 = Mathf.clamp(obj1);
        if (this.flip)
        {
          this.x += this.width;
          this.width = -this.width;
        }
        float num1 = this.width * 0.35f;
        float num2 = this.height / 2f;
        Draw.color(obj0);
        float num3 = Math.min(obj1 * 2f, 1f);
        float num4 = (obj1 - 0.5f) * 2f;
        float num5 = -(1f - num3) * (this.width - num1);
        Fill.quad(this.x, this.y, this.x + num1, this.y, this.x + this.width + num5, this.y + num2 * num3, this.x + this.width - num1 + num5, this.y + num2 * num3);
        if ((double) num4 > 0.0)
        {
          float x3 = this.x + (this.width - num1) * (1f - num4);
          Fill.quad(this.x + this.width, this.y + num2, this.x + this.width - num1, this.y + num2, x3, this.y + this.height * obj1, x3 + num1, this.y + this.height * obj1);
        }
        Draw.reset();
        if (!this.flip)
          return;
        this.width = -this.width;
        this.x -= this.width;
      }

      [LineNumberTable(new byte[] {162, 0, 141, 150, 118, 171, 124, 120, 135, 159, 6, 112, 127, 13})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw()
      {
        float toValue = this.amount.get();
        if (Float.isNaN(toValue) || Float.isInfinite(toValue))
          toValue = 1f;
        if ((double) toValue < (double) this.last && this.flash.get())
          this.blink = 1f;
        this.blink = Mathf.lerpDelta(this.blink, 0.0f, 0.2f);
        this.value = Mathf.lerpDelta(this.value, toValue, 0.15f);
        this.last = toValue;
        if (Float.isNaN(this.value) || Float.isInfinite(this.value))
          this.value = 1f;
        this.drawInner(Pal.darkishGray, 1f);
        this.drawInner(Tmp.__\u003C\u003Ec1.set(this.__\u003C\u003Ecolor).lerp(Color.__\u003C\u003Ewhite, this.blink), this.value);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon0([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00240((EventType.WaveEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon1([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00241((EventType.SectorCaptureEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon2([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00242((EventType.SectorLoseEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon3([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00243((EventType.SectorInvasionEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon4([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00244((EventType.ResetEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon5([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u00248((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon6([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002412((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon7([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002438((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon8([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002440((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002444((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002447((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon11([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002452((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002454((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon13([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002458((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly Drawable arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon14([In] Drawable obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => HudFragment.lambda\u0024showToast\u002468(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Runnable
    {
      private readonly HudFragment arg\u00241;
      private readonly UnlockableContent arg\u00242;

      internal __\u003C\u003EAnon15([In] HudFragment obj0, [In] UnlockableContent obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showUnlock\u002472(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly Image arg\u00241;

      internal __\u003C\u003EAnon16([In] Image obj0) => this.arg\u00241 = obj0;

      public void run() => HudFragment.lambda\u0024showLaunch\u002473(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly Image arg\u00241;

      internal __\u003C\u003EAnon17([In] Image obj0) => this.arg\u00241 = obj0;

      public void run() => HudFragment.lambda\u0024showLand\u002474(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Func
    {
      private readonly StringBuilder arg\u00241;

      internal __\u003C\u003EAnon18([In] StringBuilder obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) HudFragment.lambda\u0024makeStatusTable\u002475(this.arg\u00241, (Integer) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon19([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024makeStatusTable\u002483((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Prov
    {
      private readonly StringBuilder arg\u00241;
      private readonly IntFormat arg\u00242;
      private readonly IntFormat arg\u00243;
      private readonly IntFormat arg\u00244;
      private readonly IntFormat arg\u00245;
      private readonly IntFormat arg\u00246;
      private readonly IntFormat arg\u00247;
      private readonly IntFormat arg\u00248;

      internal __\u003C\u003EAnon20(
        [In] StringBuilder obj0,
        [In] IntFormat obj1,
        [In] IntFormat obj2,
        [In] IntFormat obj3,
        [In] IntFormat obj4,
        [In] IntFormat obj5,
        [In] IntFormat obj6,
        [In] IntFormat obj7)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
        this.arg\u00248 = obj7;
      }

      public object get() => (object) HudFragment.lambda\u0024makeStatusTable\u002485(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247, this.arg\u00248).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Cons
    {
      private readonly float[] arg\u00241;

      internal __\u003C\u003EAnon21([In] float[] obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => HudFragment.lambda\u0024makeStatusTable\u002486(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Boolp
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public bool get() => (HudFragment.lambda\u0024makeStatusTable\u002487() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Intf
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public int get([In] object obj0) => HudFragment.lambda\u0024makeStatusTable\u002484((Teams.TeamData) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Runnable
    {
      internal __\u003C\u003EAnon24()
      {
      }

      public void run() => HudFragment.lambda\u0024makeStatusTable\u002476();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Floatp
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public float get() => HudFragment.lambda\u0024makeStatusTable\u002477();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Boolp
    {
      internal __\u003C\u003EAnon26()
      {
      }

      public bool get() => (HudFragment.lambda\u0024makeStatusTable\u002478() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Prov
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public object get() => (object) HudFragment.lambda\u0024makeStatusTable\u002479();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon28 : Floatp
    {
      internal __\u003C\u003EAnon28()
      {
      }

      public float get() => HudFragment.lambda\u0024makeStatusTable\u002480();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon29 : Boolp
    {
      internal __\u003C\u003EAnon29()
      {
      }

      public bool get() => (HudFragment.lambda\u0024makeStatusTable\u002481() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon30 : Cons
    {
      internal __\u003C\u003EAnon30()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024makeStatusTable\u002482((HudFragment.\u0031SideBar) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon31 : Runnable
    {
      private readonly HudFragment arg\u00241;
      private readonly Table arg\u00242;

      internal __\u003C\u003EAnon31([In] HudFragment obj0, [In] Table obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024showUnlock\u002469(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon32 : Runnable
    {
      private readonly HudFragment arg\u00241;
      private readonly Table arg\u00242;
      private readonly Table arg\u00243;

      internal __\u003C\u003EAnon32([In] HudFragment obj0, [In] Table obj1, [In] Table obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024showUnlock\u002471(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon33 : Runnable
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon33([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024showUnlock\u002470();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon34 : Runnable
    {
      private readonly Table arg\u00241;

      internal __\u003C\u003EAnon34([In] Table obj0) => this.arg\u00241 = obj0;

      public void run() => HudFragment.lambda\u0024showToast\u002466(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon35 : Runnable
    {
      private readonly Table arg\u00241;
      private readonly Table arg\u00242;

      internal __\u003C\u003EAnon35([In] Table obj0, [In] Table obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => HudFragment.lambda\u0024showToast\u002467(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon36 : Cons
    {
      internal __\u003C\u003EAnon36()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002462((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon37 : Boolp
    {
      internal __\u003C\u003EAnon37()
      {
      }

      public bool get() => (HudFragment.lambda\u0024build\u002464() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon38 : Boolf
    {
      internal __\u003C\u003EAnon38()
      {
      }

      public bool get([In] object obj0) => (HudFragment.lambda\u0024build\u002463((Item) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon39 : Runnable
    {
      private readonly Table arg\u00241;

      internal __\u003C\u003EAnon39([In] Table obj0) => this.arg\u00241 = obj0;

      public void run() => HudFragment.lambda\u0024build\u002460(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon40 : Runnable
    {
      private readonly Bits arg\u00241;
      private readonly Runnable arg\u00242;

      internal __\u003C\u003EAnon40([In] Bits obj0, [In] Runnable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => HudFragment.lambda\u0024build\u002461(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon41 : Prov
    {
      private readonly Item arg\u00241;

      internal __\u003C\u003EAnon41([In] Item obj0) => this.arg\u00241 = obj0;

      public object get() => (object) HudFragment.lambda\u0024build\u002459(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon42 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon42([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002456((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon43 : Runnable
    {
      private readonly HudFragment arg\u00241;
      private readonly Table arg\u00242;

      internal __\u003C\u003EAnon43([In] HudFragment obj0, [In] Table obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024build\u002457(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon44 : Prov
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon44([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public object get() => (object) this.arg\u00241.lambda\u0024build\u002455().__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon45 : Boolp
    {
      internal __\u003C\u003EAnon45()
      {
      }

      public bool get() => (HudFragment.lambda\u0024build\u002453() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon46 : Runnable
    {
      private readonly float[] arg\u00241;
      private readonly float arg\u00242;

      internal __\u003C\u003EAnon46([In] float[] obj0, [In] float obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => HudFragment.lambda\u0024build\u002448(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon47 : Boolp
    {
      private readonly HudFragment arg\u00241;
      private readonly float[] arg\u00242;
      private readonly Table arg\u00243;
      private readonly float[] arg\u00244;

      internal __\u003C\u003EAnon47([In] HudFragment obj0, [In] float[] obj1, [In] Table obj2, [In] float[] obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public bool get() => (this.arg\u00241.lambda\u0024build\u002449(this.arg\u00242, this.arg\u00243, this.arg\u00244) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon48 : Cons
    {
      internal __\u003C\u003EAnon48()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002451((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon49 : Cons
    {
      internal __\u003C\u003EAnon49()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002450((Label) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon50 : Boolp
    {
      internal __\u003C\u003EAnon50()
      {
      }

      public bool get() => (HudFragment.lambda\u0024build\u002445() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon51 : Cons
    {
      internal __\u003C\u003EAnon51()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002446((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon52 : Cons
    {
      internal __\u003C\u003EAnon52()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002442((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon53 : Cons
    {
      internal __\u003C\u003EAnon53()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002443((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon54 : Cons
    {
      internal __\u003C\u003EAnon54()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002441((Label) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon55 : Boolp
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon55([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u002439() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon56 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon56([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002417((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon57 : Runnable
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon57([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024build\u002419();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon58 : Boolp
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon58([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u002420() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon59 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon59([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002423((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon60 : Cons
    {
      internal __\u003C\u003EAnon60()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002425((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon61 : Boolp
    {
      internal __\u003C\u003EAnon61()
      {
      }

      public bool get() => (HudFragment.lambda\u0024build\u002426() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon62 : Cons
    {
      internal __\u003C\u003EAnon62()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002430((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon63 : Boolp
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon63([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u002431() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon64 : Cons
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon64([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024build\u002437((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon65 : Boolp
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon65([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u002432() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon66 : Prov
    {
      private readonly IntFormat arg\u00241;

      internal __\u003C\u003EAnon66([In] IntFormat obj0) => this.arg\u00241 = obj0;

      public object get() => (object) HudFragment.lambda\u0024build\u002433(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon67 : Prov
    {
      private readonly IntFormat arg\u00241;

      internal __\u003C\u003EAnon67([In] IntFormat obj0) => this.arg\u00241 = obj0;

      public object get() => (object) HudFragment.lambda\u0024build\u002434(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon68 : Prov
    {
      private readonly IntFormat arg\u00241;

      internal __\u003C\u003EAnon68([In] IntFormat obj0) => this.arg\u00241 = obj0;

      public object get() => (object) HudFragment.lambda\u0024build\u002435(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon69 : Prov
    {
      private readonly IntFormat arg\u00241;

      internal __\u003C\u003EAnon69([In] IntFormat obj0) => this.arg\u00241 = obj0;

      public object get() => (object) HudFragment.lambda\u0024build\u002436(this.arg\u00241).__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon70 : Boolp
    {
      private readonly mindustry.net.Net arg\u00241;

      internal __\u003C\u003EAnon70([In] mindustry.net.Net obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.client() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon71 : Cons
    {
      internal __\u003C\u003EAnon71()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002429((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon72 : Runnable
    {
      private readonly Team arg\u00241;

      internal __\u003C\u003EAnon72([In] Team obj0) => this.arg\u00241 = obj0;

      public void run() => HudFragment.lambda\u0024build\u002427(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon73 : Runnable
    {
      private readonly ImageButton arg\u00241;
      private readonly Team arg\u00242;

      internal __\u003C\u003EAnon73([In] ImageButton obj0, [In] Team obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => HudFragment.lambda\u0024build\u002428(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon74 : Floatp
    {
      internal __\u003C\u003EAnon74()
      {
      }

      public float get() => HudFragment.lambda\u0024build\u002424();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon75 : Runnable
    {
      internal __\u003C\u003EAnon75()
      {
      }

      public void run() => HudFragment.lambda\u0024build\u002421();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon76 : Boolf
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon76([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024build\u002422((ImageButton) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon77 : Runnable
    {
      internal __\u003C\u003EAnon77()
      {
      }

      public void run() => HudFragment.lambda\u0024build\u002418();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon78 : Runnable
    {
      private readonly PausedDialog arg\u00241;

      internal __\u003C\u003EAnon78([In] PausedDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon79 : Runnable
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon79([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.toggleMenus();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon80 : Runnable
    {
      private readonly SchematicsDialog arg\u00241;

      internal __\u003C\u003EAnon80([In] SchematicsDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.show();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon81 : Runnable
    {
      internal __\u003C\u003EAnon81()
      {
      }

      public void run() => HudFragment.lambda\u0024build\u002413();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon82 : Cons
    {
      internal __\u003C\u003EAnon82()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002414((ImageButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon83 : Runnable
    {
      internal __\u003C\u003EAnon83()
      {
      }

      public void run() => HudFragment.lambda\u0024build\u002415();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon84 : Cons
    {
      internal __\u003C\u003EAnon84()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u002416((ImageButton) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon85 : Boolp
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon85([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u00249() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon86 : Prov
    {
      internal __\u003C\u003EAnon86()
      {
      }

      public object get() => (object) HudFragment.lambda\u0024build\u002410().__\u003Cref\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon87 : Boolp
    {
      internal __\u003C\u003EAnon87()
      {
      }

      public bool get() => (HudFragment.lambda\u0024build\u002411() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon88 : Boolp
    {
      private readonly HudFragment arg\u00241;

      internal __\u003C\u003EAnon88([In] HudFragment obj0) => this.arg\u00241 = obj0;

      public bool get() => (this.arg\u00241.lambda\u0024build\u00245() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon89 : Cons
    {
      internal __\u003C\u003EAnon89()
      {
      }

      public void get([In] object obj0) => HudFragment.lambda\u0024build\u00247((Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon90 : Prov
    {
      internal __\u003C\u003EAnon90()
      {
      }

      public object get() => (object) HudFragment.lambda\u0024build\u00246().__\u003Cref\u003E;
    }
  }
}
