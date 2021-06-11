// Decompiled with JetBrains decompiler
// Type: arc.scene.ui.Tooltip
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.input;
using arc.math;
using arc.math.geom;
using arc.scene.@event;
using arc.scene.actions;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.ui
{
  public class Tooltip : InputListener
  {
    internal static Vec2 tmp;
    internal Tooltip.Tooltips __\u003C\u003Emanager;
    internal Table __\u003C\u003Econtainer;
    internal bool instant;
    internal bool always;
    internal Element targetActor;
    internal Runnable show;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;)V")]
    [LineNumberTable(new byte[] {159, 175, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tooltip(Cons contents)
      : this(contents, Tooltip.Tooltips.getInstance())
    {
    }

    [LineNumberTable(new byte[] {86, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void hide() => this.__\u003C\u003Emanager.hide(this);

    [LineNumberTable(new byte[] {78, 107, 108, 139, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Element element, float x, float y)
    {
      this.setContainerPosition(element, x, y);
      this.__\u003C\u003Emanager.enter(this);
      this.__\u003C\u003Econtainer.pack();
      if (this.show == null)
        return;
      this.show.run();
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;Larc/scene/ui/Tooltip$Tooltips;)V")]
    [LineNumberTable(new byte[] {159, 183, 232, 51, 231, 78, 135, 236, 71, 108, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tooltip(Cons contents, Tooltip.Tooltips manager)
    {
      Tooltip tooltip = this;
      this.instant = true;
      this.__\u003C\u003Emanager = manager;
      this.__\u003C\u003Econtainer = (Table) new Tooltip.\u0031(this);
      contents.get((object) this.__\u003C\u003Econtainer);
      this.__\u003C\u003Econtainer.touchable = Touchable.__\u003C\u003Edisabled;
    }

    [LineNumberTable(new byte[] {41, 103, 103, 132, 107, 127, 5, 127, 11, 127, 7, 114, 127, 2, 127, 0, 127, 2, 127, 0, 153, 127, 15, 126, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setContainerPosition(Element element, float x, float y)
    {
      this.targetActor = element;
      Scene scene = element.getScene();
      if (scene == null)
        return;
      this.__\u003C\u003Econtainer.pack();
      float offsetX = this.__\u003C\u003Emanager.offsetX;
      float offsetY = this.__\u003C\u003Emanager.offsetY;
      float edgeDistance = this.__\u003C\u003Emanager.edgeDistance;
      Vec2 stageCoordinates1 = element.localToStageCoordinates(Tooltip.tmp.set(x + offsetX, y - offsetY - this.__\u003C\u003Econtainer.getHeight()));
      if ((double) stageCoordinates1.y < (double) edgeDistance)
        stageCoordinates1 = element.localToStageCoordinates(Tooltip.tmp.set(x + offsetX, y + offsetY));
      if ((double) stageCoordinates1.x < (double) edgeDistance)
        stageCoordinates1.x = edgeDistance;
      if ((double) (stageCoordinates1.x + this.__\u003C\u003Econtainer.getWidth()) > (double) (scene.getWidth() - edgeDistance))
        stageCoordinates1.x = scene.getWidth() - edgeDistance - this.__\u003C\u003Econtainer.getWidth();
      if ((double) (stageCoordinates1.y + this.__\u003C\u003Econtainer.getHeight()) > (double) (scene.getHeight() - edgeDistance))
        stageCoordinates1.y = scene.getHeight() - edgeDistance - this.__\u003C\u003Econtainer.getHeight();
      this.__\u003C\u003Econtainer.setPosition(stageCoordinates1.x, stageCoordinates1.y);
      Vec2 stageCoordinates2 = element.localToStageCoordinates(Tooltip.tmp.set(element.getWidth() / 2f, element.getHeight() / 2f));
      stageCoordinates2.sub(this.__\u003C\u003Econtainer.x, this.__\u003C\u003Econtainer.y);
      this.__\u003C\u003Econtainer.setOrigin(stageCoordinates2.x, stageCoordinates2.y);
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;Ljava/lang/Runnable;)V")]
    [LineNumberTable(new byte[] {159, 179, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tooltip(Cons contents, Runnable show)
      : this(contents, Tooltip.Tooltips.getInstance())
    {
      Tooltip tooltip = this;
      this.show = show;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Tooltip.Tooltips getManager() => this.__\u003C\u003Emanager;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Table getContainer() => this.__\u003C\u003Econtainer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setInstant(bool instant) => this.instant = instant;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAlways(bool always) => this.always = always;

    [LineNumberTable(new byte[] {25, 104, 107, 130, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool touchDown(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      KeyCode button)
    {
      if (this.instant)
      {
        this.__\u003C\u003Econtainer.toFront();
        return false;
      }
      this.__\u003C\u003Emanager.touchDown(this);
      return false;
    }

    [LineNumberTable(new byte[] {35, 111, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool mouseMoved(InputEvent @event, float x, float y)
    {
      if (this.__\u003C\u003Econtainer.hasParent())
        return false;
      this.setContainerPosition(@event.listenerActor, x, y);
      return true;
    }

    [LineNumberTable(new byte[] {63, 102, 109, 103, 143, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void enter(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      Element fromActor)
    {
      if (pointer != -1 || Core.input.isTouched())
        return;
      Element listenerActor = @event.listenerActor;
      if (fromActor != null && fromActor.isDescendantOf(listenerActor))
        return;
      this.show(listenerActor, x, y);
    }

    [LineNumberTable(new byte[] {73, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void exit(InputEvent @event, float x, float y, int pointer, Element toActor)
    {
      if (toActor != null && toActor.isDescendantOf(@event.listenerActor))
        return;
      this.hide();
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Tooltip()
    {
      InputListener.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("arc.scene.ui.Tooltip"))
        return;
      Tooltip.tmp = new Vec2();
    }

    [Modifiers]
    public Tooltip.Tooltips manager
    {
      [HideFromJava] get => this.__\u003C\u003Emanager;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Emanager = value;
    }

    [Modifiers]
    public Table container
    {
      [HideFromJava] get => this.__\u003C\u003Econtainer;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Econtainer = value;
    }

    [EnclosingMethod(null, "<init>", "(Larc.func.Cons;Larc.scene.ui.Tooltip$Tooltips;)V")]
    [SpecialName]
    internal new class \u0031 : Table
    {
      [Modifiers]
      internal Tooltip this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(44)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Tooltip obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {159, 189, 104, 127, 7})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void act([In] float obj0)
      {
        base.act(obj0);
        if (this.this\u00240.targetActor == null || this.this\u00240.targetActor.getScene() != null)
          return;
        this.remove();
      }

      [HideFromJava]
      static \u0031() => Table.__\u003Cclinit\u003E();
    }

    public class Tooltips : Object
    {
      private static Tooltip.Tooltips instance;
      [Modifiers]
      [Signature("Larc/struct/Seq<Larc/scene/ui/Tooltip;>;")]
      internal Seq shown;
      [Signature("Larc/func/Func<Ljava/lang/String;Larc/scene/ui/Tooltip;>;")]
      public Func textProvider;
      public float initialTime;
      public float subsequentTime;
      public float resetTime;
      public bool enabled;
      public bool animations;
      public float maxWidth;
      public float offsetX;
      public float offsetY;
      public float edgeDistance;
      internal float time;
      [Modifiers]
      internal Timer.Task resetTask;
      internal Tooltip showTooltip;
      [Modifiers]
      internal Timer.Task showTask;

      [LineNumberTable(new byte[] {160, 89, 103, 138})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Tooltip.Tooltips getInstance()
      {
        if (Tooltip.Tooltips.instance == null)
          Tooltip.Tooltips.instance = new Tooltip.Tooltips();
        return Tooltip.Tooltips.instance;
      }

      [LineNumberTable(new byte[] {160, 100, 107, 120, 107, 112, 103, 146})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void touchDown(Tooltip tooltip)
      {
        this.showTask.cancel();
        if (tooltip.__\u003C\u003Econtainer.remove())
          this.resetTask.cancel();
        this.resetTask.run();
        if (!this.enabled && !tooltip.always)
          return;
        this.showTooltip = tooltip;
        Timer.schedule(this.showTask, this.time);
      }

      [LineNumberTable(new byte[] {160, 110, 103, 107, 112, 117, 141, 146})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void enter(Tooltip tooltip)
      {
        this.showTooltip = tooltip;
        this.showTask.cancel();
        if (!this.enabled && !tooltip.always)
          return;
        if ((double) this.time == 0.0 || tooltip.instant)
          this.showTask.run();
        else
          Timer.schedule(this.showTask, this.time);
      }

      [LineNumberTable(new byte[] {160, 121, 103, 107, 109, 110, 103, 107, 146})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void hide(Tooltip tooltip)
      {
        this.showTooltip = (Tooltip) null;
        this.showTask.cancel();
        if (!tooltip.__\u003C\u003Econtainer.hasParent())
          return;
        this.shown.remove((object) tooltip, true);
        this.hideAction(tooltip);
        this.resetTask.cancel();
        Timer.schedule(this.resetTask, this.resetTime);
      }

      [LineNumberTable(new byte[] {93, 136, 171, 240, 69, 139, 139, 139, 135, 135, 139, 246, 69, 139, 108, 236, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Tooltips()
      {
        Tooltip.Tooltips tooltips = this;
        this.shown = new Seq();
        this.textProvider = (Func) new Tooltip.Tooltips.__\u003C\u003EAnon0();
        this.initialTime = 2f;
        this.subsequentTime = 0.0f;
        this.resetTime = 1.5f;
        this.enabled = true;
        this.animations = false;
        this.maxWidth = (float) int.MaxValue;
        this.offsetX = 15f;
        this.offsetY = 19f;
        this.edgeDistance = 7f;
        this.time = this.initialTime;
        this.resetTask = (Timer.Task) new Tooltip.Tooltips.\u0031(this);
        this.showTask = (Timer.Task) new Tooltip.Tooltips.\u0032(this);
      }

      [LineNumberTable(new byte[] {160, 145, 117, 127, 19})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void hideAction(Tooltip tooltip) => tooltip.__\u003C\u003Econtainer.addAction((Action) Actions.sequence((Action) Actions.parallel((Action) Actions.alpha(0.2f, 0.2f, Interp.fade), (Action) Actions.scaleTo(0.05f, 0.05f, 0.2f, Interp.fade)), (Action) Actions.remove()));

      [Modifiers]
      [LineNumberTable(148)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static Tooltip lambda\u0024new\u00241([In] string obj0)
      {
        Tooltip.__\u003Cclinit\u003E();
        return new Tooltip((Cons) new Tooltip.Tooltips.__\u003C\u003EAnon1(obj0));
      }

      [Modifiers]
      [LineNumberTable(148)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00240([In] string obj0, [In] Table obj1)
      {
        Table table = obj1;
        object obj = (object) obj0;
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table.add(text);
      }

      [LineNumberTable(210)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Tooltip create(string text) => (Tooltip) this.textProvider.get((object) text);

      [LineNumberTable(new byte[] {160, 133, 127, 10, 108, 117, 112, 127, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual void showAction(Tooltip tooltip)
      {
        float duration = !this.animations ? 0.1f : ((double) this.time <= 0.0 ? 0.15f : 0.5f);
        tooltip.__\u003C\u003Econtainer.setTransform(true);
        tooltip.__\u003C\u003Econtainer.__\u003C\u003Ecolor.a = 0.2f;
        tooltip.__\u003C\u003Econtainer.setScale(0.05f);
        tooltip.__\u003C\u003Econtainer.addAction((Action) Actions.parallel((Action) Actions.fadeIn(duration, Interp.fade), (Action) Actions.scaleTo(1f, 1f, duration, Interp.fade)));
      }

      [LineNumberTable(new byte[] {160, 150, 107, 107, 108, 135, 127, 1, 104, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void hideAll()
      {
        this.resetTask.cancel();
        this.showTask.cancel();
        this.time = this.initialTime;
        this.showTooltip = (Tooltip) null;
        Iterator iterator = this.shown.iterator();
        while (iterator.hasNext())
          ((Tooltip) iterator.next()).hide();
        this.shown.clear();
      }

      [LineNumberTable(new byte[] {160, 162, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void instant()
      {
        this.time = 0.0f;
        this.showTask.run();
        this.showTask.cancel();
      }

      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0031 : Timer.Task
      {
        [Modifiers]
        internal Tooltip.Tooltips this\u00240;

        [LineNumberTable(173)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] Tooltip.Tooltips obj0)
        {
          this.this\u00240 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
        }

        [LineNumberTable(new byte[] {126, 118})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void run() => this.this\u00240.time = this.this\u00240.initialTime;
      }

      [EnclosingMethod(null, null, null)]
      [SpecialName]
      internal class \u0032 : Timer.Task
      {
        [Modifiers]
        internal Tooltip.Tooltips this\u00240;

        [LineNumberTable(181)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0032([In] Tooltip.Tooltips obj0)
        {
          this.this\u00240 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
        }

        [LineNumberTable(new byte[] {160, 70, 142, 118, 100, 118, 117, 155, 117, 150, 114, 118, 144})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void run()
        {
          if (this.this\u00240.showTooltip == null)
            return;
          Scene scene = this.this\u00240.showTooltip.targetActor.getScene();
          if (scene == null)
            return;
          scene.add((Element) this.this\u00240.showTooltip.__\u003C\u003Econtainer);
          this.this\u00240.showTooltip.__\u003C\u003Econtainer.toFront();
          this.this\u00240.shown.add((object) this.this\u00240.showTooltip);
          this.this\u00240.showTooltip.__\u003C\u003Econtainer.clearActions();
          this.this\u00240.showAction(this.this\u00240.showTooltip);
          if (this.this\u00240.showTooltip.instant)
            return;
          this.this\u00240.time = this.this\u00240.subsequentTime;
          this.this\u00240.resetTask.cancel();
        }
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Func
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get([In] object obj0) => (object) Tooltip.Tooltips.lambda\u0024new\u00241((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Cons
      {
        private readonly string arg\u00241;

        internal __\u003C\u003EAnon1([In] string obj0) => this.arg\u00241 = obj0;

        public void get([In] object obj0) => Tooltip.Tooltips.lambda\u0024new\u00240(this.arg\u00241, (Table) obj0);
      }
    }
  }
}
