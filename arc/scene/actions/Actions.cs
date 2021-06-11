// Decompiled with JetBrains decompiler
// Type: arc.scene.actions.Actions
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.math;
using arc.scene.@event;
using arc.util.pooling;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.actions
{
  public class Actions : Object
  {
    [LineNumberTable(new byte[] {161, 16, 122, 105, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SequenceAction sequence(params Action[] actions)
    {
      SequenceAction sequenceAction = (SequenceAction) Actions.action((Class) ClassLiteral<SequenceAction>.Value, (Prov) new Actions.__\u003C\u003EAnon20());
      int index = 0;
      for (int length = actions.Length; index < length; ++index)
        sequenceAction.addAction(actions[index]);
      return sequenceAction;
    }

    [LineNumberTable(new byte[] {159, 19, 162, 122, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RemoveListenerAction removeListener(
      EventListener listener,
      bool capture)
    {
      int num = capture ? 1 : 0;
      RemoveListenerAction removeListenerAction = (RemoveListenerAction) Actions.action((Class) ClassLiteral<RemoveListenerAction>.Value, (Prov) new Actions.__\u003C\u003EAnon26());
      removeListenerAction.setListener(listener);
      removeListenerAction.setCapture(num != 0);
      return removeListenerAction;
    }

    [LineNumberTable(316)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RemoveActorAction remove() => (RemoveActorAction) Actions.action((Class) ClassLiteral<RemoveActorAction>.Value, (Prov) new Actions.__\u003C\u003EAnon17());

    [LineNumberTable(new byte[] {160, 245, 122, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SequenceAction sequence(
      Action action1,
      Action action2,
      Action action3)
    {
      SequenceAction sequenceAction = (SequenceAction) Actions.action((Class) ClassLiteral<SequenceAction>.Value, (Prov) new Actions.__\u003C\u003EAnon20());
      sequenceAction.addAction(action1);
      sequenceAction.addAction(action2);
      sequenceAction.addAction(action3);
      return sequenceAction;
    }

    [LineNumberTable(new byte[] {160, 160, 122, 107, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AlphaAction fadeOut(float duration, Interp interpolation)
    {
      AlphaAction alphaAction = (AlphaAction) Actions.action((Class) ClassLiteral<AlphaAction>.Value, (Prov) new Actions.__\u003C\u003EAnon14());
      alphaAction.setAlpha(0.0f);
      alphaAction.setDuration(duration);
      alphaAction.setInterpolation(interpolation);
      return alphaAction;
    }

    [LineNumberTable(250)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AlphaAction alpha(float a) => Actions.alpha(a, 0.0f, (Interp) null);

    [LineNumberTable(new byte[] {160, 174, 122, 107, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AlphaAction fadeIn(float duration, Interp interpolation)
    {
      AlphaAction alphaAction = (AlphaAction) Actions.action((Class) ClassLiteral<AlphaAction>.Value, (Prov) new Actions.__\u003C\u003EAnon14());
      alphaAction.setAlpha(1f);
      alphaAction.setDuration(duration);
      alphaAction.setInterpolation(interpolation);
      return alphaAction;
    }

    [LineNumberTable(new byte[] {160, 238, 122, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SequenceAction sequence(Action action1, Action action2)
    {
      SequenceAction sequenceAction = (SequenceAction) Actions.action((Class) ClassLiteral<SequenceAction>.Value, (Prov) new Actions.__\u003C\u003EAnon20());
      sequenceAction.addAction(action1);
      sequenceAction.addAction(action2);
      return sequenceAction;
    }

    [LineNumberTable(new byte[] {160, 212, 122, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static DelayAction delay(float duration)
    {
      DelayAction delayAction = (DelayAction) Actions.action((Class) ClassLiteral<DelayAction>.Value, (Prov) new Actions.__\u003C\u003EAnon18());
      delayAction.setDuration(duration);
      return delayAction;
    }

    [LineNumberTable(269)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AlphaAction fadeOut(float duration) => Actions.alpha(0.0f, duration, (Interp) null);

    [LineNumberTable(new byte[] {160, 232, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SequenceAction sequence(Action action1)
    {
      SequenceAction sequenceAction = (SequenceAction) Actions.action((Class) ClassLiteral<SequenceAction>.Value, (Prov) new Actions.__\u003C\u003EAnon20());
      sequenceAction.addAction(action1);
      return sequenceAction;
    }

    [LineNumberTable(283)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AlphaAction fadeIn(float duration) => Actions.alpha(1f, duration, (Interp) null);

    [LineNumberTable(new byte[] {160, 127, 122, 103, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ColorAction color(Color color, float duration, Interp interpolation)
    {
      ColorAction colorAction = (ColorAction) Actions.action((Class) ClassLiteral<ColorAction>.Value, (Prov) new Actions.__\u003C\u003EAnon13());
      colorAction.setEndColor(color);
      colorAction.setDuration(duration);
      colorAction.setInterpolation(interpolation);
      return colorAction;
    }

    [LineNumberTable(163)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScaleToAction scaleTo(float x, float y) => Actions.scaleTo(x, y, 0.0f, (Interp) null);

    [LineNumberTable(new byte[] {159, 66, 66, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static VisibleAction visible(bool visible)
    {
      int num = visible ? 1 : 0;
      VisibleAction visibleAction = (VisibleAction) Actions.action((Class) ClassLiteral<VisibleAction>.Value, (Prov) new Actions.__\u003C\u003EAnon15());
      visibleAction.setVisible(num != 0);
      return visibleAction;
    }

    [LineNumberTable(new byte[] {121, 122, 106, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScaleToAction scaleTo(
      float x,
      float y,
      float duration,
      Interp interpolation)
    {
      ScaleToAction scaleToAction = (ScaleToAction) Actions.action((Class) ClassLiteral<ScaleToAction>.Value, (Prov) new Actions.__\u003C\u003EAnon9());
      scaleToAction.setScale(x, y);
      scaleToAction.setDuration(duration);
      scaleToAction.setInterpolation(interpolation);
      return scaleToAction;
    }

    [LineNumberTable(new byte[] {161, 92, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RunnableAction run(Runnable runnable)
    {
      RunnableAction runnableAction = (RunnableAction) Actions.action((Class) ClassLiteral<RunnableAction>.Value, (Prov) new Actions.__\u003C\u003EAnon3());
      runnableAction.setRunnable(runnable);
      return runnableAction;
    }

    [LineNumberTable(new byte[] {160, 146, 122, 104, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AlphaAction alpha(float a, float duration, Interp interpolation)
    {
      AlphaAction alphaAction = (AlphaAction) Actions.action((Class) ClassLiteral<AlphaAction>.Value, (Prov) new Actions.__\u003C\u003EAnon14());
      alphaAction.setAlpha(a);
      alphaAction.setDuration(duration);
      alphaAction.setInterpolation(interpolation);
      return alphaAction;
    }

    [LineNumberTable(new byte[] {54, 122, 106, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TranslateByAction translateBy(
      float amountX,
      float amountY,
      float duration,
      Interp interpolation)
    {
      TranslateByAction translateByAction = (TranslateByAction) Actions.action((Class) ClassLiteral<TranslateByAction>.Value, (Prov) new Actions.__\u003C\u003EAnon5());
      translateByAction.setAmount(amountX, amountY);
      translateByAction.setDuration(duration);
      translateByAction.setInterpolation(interpolation);
      return translateByAction;
    }

    [LineNumberTable(new byte[] {161, 33, 122, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ParallelAction parallel(Action action1, Action action2)
    {
      ParallelAction parallelAction = (ParallelAction) Actions.action((Class) ClassLiteral<ParallelAction>.Value, (Prov) new Actions.__\u003C\u003EAnon21());
      parallelAction.addAction(action1);
      parallelAction.addAction(action2);
      return parallelAction;
    }

    [Signature("<T:Larc/scene/Action;>(Ljava/lang/Class<TT;>;Larc/func/Prov<TT;>;)TT;")]
    [LineNumberTable(new byte[] {159, 161, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Action action(Class type, Prov sup)
    {
      Action action = (Action) Pools.obtain(type, sup);
      action.setPool(Pools.get(type, sup));
      return action;
    }

    [LineNumberTable(new byte[] {15, 122, 106, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MoveToAction moveTo(
      float x,
      float y,
      float duration,
      Interp interpolation)
    {
      MoveToAction moveToAction = (MoveToAction) Actions.action((Class) ClassLiteral<MoveToAction>.Value, (Prov) new Actions.__\u003C\u003EAnon2());
      moveToAction.setPosition(x, y);
      moveToAction.setDuration(duration);
      moveToAction.setInterpolation(interpolation);
      return moveToAction;
    }

    [LineNumberTable(new byte[] {31, 122, 107, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MoveToAction moveToAligned(
      float x,
      float y,
      int alignment,
      float duration,
      Interp interpolation)
    {
      MoveToAction moveToAction = (MoveToAction) Actions.action((Class) ClassLiteral<MoveToAction>.Value, (Prov) new Actions.__\u003C\u003EAnon2());
      moveToAction.setPosition(x, y, alignment);
      moveToAction.setDuration(duration);
      moveToAction.setInterpolation(interpolation);
      return moveToAction;
    }

    [LineNumberTable(new byte[] {70, 122, 106, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MoveByAction moveBy(
      float amountX,
      float amountY,
      float duration,
      Interp interpolation)
    {
      MoveByAction moveByAction = (MoveByAction) Actions.action((Class) ClassLiteral<MoveByAction>.Value, (Prov) new Actions.__\u003C\u003EAnon6());
      moveByAction.setAmount(amountX, amountY);
      moveByAction.setDuration(duration);
      moveByAction.setInterpolation(interpolation);
      return moveByAction;
    }

    [LineNumberTable(new byte[] {87, 122, 106, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SizeToAction sizeTo(
      float x,
      float y,
      float duration,
      Interp interpolation)
    {
      SizeToAction sizeToAction = (SizeToAction) Actions.action((Class) ClassLiteral<SizeToAction>.Value, (Prov) new Actions.__\u003C\u003EAnon7());
      sizeToAction.setSize(x, y);
      sizeToAction.setDuration(duration);
      sizeToAction.setInterpolation(interpolation);
      return sizeToAction;
    }

    [LineNumberTable(new byte[] {104, 122, 106, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SizeByAction sizeBy(
      float amountX,
      float amountY,
      float duration,
      Interp interpolation)
    {
      SizeByAction sizeByAction = (SizeByAction) Actions.action((Class) ClassLiteral<SizeByAction>.Value, (Prov) new Actions.__\u003C\u003EAnon8());
      sizeByAction.setAmount(amountX, amountY);
      sizeByAction.setDuration(duration);
      sizeByAction.setInterpolation(interpolation);
      return sizeByAction;
    }

    [LineNumberTable(new byte[] {160, 74, 122, 106, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScaleByAction scaleBy(
      float amountX,
      float amountY,
      float duration,
      Interp interpolation)
    {
      ScaleByAction scaleByAction = (ScaleByAction) Actions.action((Class) ClassLiteral<ScaleByAction>.Value, (Prov) new Actions.__\u003C\u003EAnon10());
      scaleByAction.setAmount(amountX, amountY);
      scaleByAction.setDuration(duration);
      scaleByAction.setInterpolation(interpolation);
      return scaleByAction;
    }

    [LineNumberTable(new byte[] {160, 91, 122, 104, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RotateToAction rotateTo(
      float rotation,
      float duration,
      Interp interpolation)
    {
      RotateToAction rotateToAction = (RotateToAction) Actions.action((Class) ClassLiteral<RotateToAction>.Value, (Prov) new Actions.__\u003C\u003EAnon11());
      rotateToAction.setRotation(rotation);
      rotateToAction.setDuration(duration);
      rotateToAction.setInterpolation(interpolation);
      return rotateToAction;
    }

    [LineNumberTable(new byte[] {160, 108, 122, 104, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RotateByAction rotateBy(
      float rotationAmount,
      float duration,
      Interp interpolation)
    {
      RotateByAction rotateByAction = (RotateByAction) Actions.action((Class) ClassLiteral<RotateByAction>.Value, (Prov) new Actions.__\u003C\u003EAnon12());
      rotateByAction.setAmount(rotationAmount);
      rotateByAction.setDuration(duration);
      rotateByAction.setInterpolation(interpolation);
      return rotateByAction;
    }

    [Modifiers]
    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024translateTo\u00240([In] RunnableAction obj0, [In] float obj1, [In] float obj2) => obj0.getActor().setTranslation(obj1, obj2);

    [LineNumberTable(16)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Actions()
    {
    }

    [LineNumberTable(new byte[] {159, 167, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AddAction addAction(Action action)
    {
      AddAction addAction = (AddAction) Actions.action((Class) ClassLiteral<AddAction>.Value, (Prov) new Actions.__\u003C\u003EAnon0());
      addAction.setAction(action);
      return addAction;
    }

    [LineNumberTable(new byte[] {159, 173, 122, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AddAction addAction(Action action, Element targetActor)
    {
      AddAction addAction = (AddAction) Actions.action((Class) ClassLiteral<AddAction>.Value, (Prov) new Actions.__\u003C\u003EAnon0());
      addAction.setTarget(targetActor);
      addAction.setAction(action);
      return addAction;
    }

    [LineNumberTable(new byte[] {159, 180, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RemoveAction removeAction(Action action)
    {
      RemoveAction removeAction = (RemoveAction) Actions.action((Class) ClassLiteral<RemoveAction>.Value, (Prov) new Actions.__\u003C\u003EAnon1());
      removeAction.setAction(action);
      return removeAction;
    }

    [LineNumberTable(new byte[] {159, 186, 122, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RemoveAction removeAction(Action action, Element targetActor)
    {
      RemoveAction removeAction = (RemoveAction) Actions.action((Class) ClassLiteral<RemoveAction>.Value, (Prov) new Actions.__\u003C\u003EAnon1());
      removeAction.setTarget(targetActor);
      removeAction.setAction(action);
      return removeAction;
    }

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Action originCenter() => (Action) new OriginAction();

    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MoveToAction moveTo(float x, float y) => Actions.moveTo(x, y, 0.0f, (Interp) null);

    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MoveToAction moveTo(float x, float y, float duration) => Actions.moveTo(x, y, duration, (Interp) null);

    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MoveToAction moveToAligned(float x, float y, int alignment) => Actions.moveToAligned(x, y, alignment, 0.0f, (Interp) null);

    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MoveToAction moveToAligned(
      float x,
      float y,
      int alignment,
      float duration)
    {
      return Actions.moveToAligned(x, y, alignment, duration, (Interp) null);
    }

    [LineNumberTable(90)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MoveByAction moveBy(float amountX, float amountY) => Actions.moveBy(amountX, amountY, 0.0f, (Interp) null);

    [LineNumberTable(94)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static MoveByAction moveBy(float amountX, float amountY, float duration) => Actions.moveBy(amountX, amountY, duration, (Interp) null);

    [LineNumberTable(new byte[] {48, 122, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RunnableAction translateTo(float amountX, float amountY)
    {
      RunnableAction runnableAction = (RunnableAction) Actions.action((Class) ClassLiteral<RunnableAction>.Value, (Prov) new Actions.__\u003C\u003EAnon3());
      runnableAction.setRunnable((Runnable) new Actions.__\u003C\u003EAnon4(runnableAction, amountX, amountY));
      return runnableAction;
    }

    [LineNumberTable(112)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TranslateByAction translateBy(float amountX, float amountY) => Actions.translateBy(amountX, amountY, 0.0f, (Interp) null);

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TranslateByAction translateBy(
      float amountX,
      float amountY,
      float duration)
    {
      return Actions.translateBy(amountX, amountY, duration, (Interp) null);
    }

    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SizeToAction sizeTo(float x, float y) => Actions.sizeTo(x, y, 0.0f, (Interp) null);

    [LineNumberTable(133)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SizeToAction sizeTo(float x, float y, float duration) => Actions.sizeTo(x, y, duration, (Interp) null);

    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SizeByAction sizeBy(float amountX, float amountY) => Actions.sizeBy(amountX, amountY, 0.0f, (Interp) null);

    [LineNumberTable(150)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SizeByAction sizeBy(float amountX, float amountY, float duration) => Actions.sizeBy(amountX, amountY, duration, (Interp) null);

    [LineNumberTable(167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScaleToAction scaleTo(float x, float y, float duration) => Actions.scaleTo(x, y, duration, (Interp) null);

    [LineNumberTable(180)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScaleByAction scaleBy(float amountX, float amountY) => Actions.scaleBy(amountX, amountY, 0.0f, (Interp) null);

    [LineNumberTable(184)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ScaleByAction scaleBy(float amountX, float amountY, float duration) => Actions.scaleBy(amountX, amountY, duration, (Interp) null);

    [LineNumberTable(197)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RotateToAction rotateTo(float rotation) => Actions.rotateTo(rotation, 0.0f, (Interp) null);

    [LineNumberTable(201)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RotateToAction rotateTo(float rotation, float duration) => Actions.rotateTo(rotation, duration, (Interp) null);

    [LineNumberTable(214)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RotateByAction rotateBy(float rotationAmount) => Actions.rotateBy(rotationAmount, 0.0f, (Interp) null);

    [LineNumberTable(218)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RotateByAction rotateBy(float rotationAmount, float duration) => Actions.rotateBy(rotationAmount, duration, (Interp) null);

    [LineNumberTable(231)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ColorAction color(Color color) => Actions.color(color, 0.0f, (Interp) null);

    [LineNumberTable(236)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ColorAction color(Color color, float duration) => Actions.color(color, duration, (Interp) null);

    [LineNumberTable(255)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AlphaAction alpha(float a, float duration) => Actions.alpha(a, duration, (Interp) null);

    [LineNumberTable(296)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static VisibleAction show() => Actions.visible(true);

    [LineNumberTable(300)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static VisibleAction hide() => Actions.visible(false);

    [LineNumberTable(new byte[] {160, 196, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TouchableAction touchable(Touchable touchable)
    {
      TouchableAction touchableAction = (TouchableAction) Actions.action((Class) ClassLiteral<TouchableAction>.Value, (Prov) new Actions.__\u003C\u003EAnon16());
      touchableAction.touchable(touchable);
      return touchableAction;
    }

    [LineNumberTable(new byte[] {160, 206, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RemoveActorAction remove(Element removeActor)
    {
      RemoveActorAction removeActorAction = (RemoveActorAction) Actions.action((Class) ClassLiteral<RemoveActorAction>.Value, (Prov) new Actions.__\u003C\u003EAnon17());
      removeActorAction.setTarget(removeActor);
      return removeActorAction;
    }

    [LineNumberTable(new byte[] {160, 218, 122, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static DelayAction delay(float duration, Action delayedAction)
    {
      DelayAction delayAction = (DelayAction) Actions.action((Class) ClassLiteral<DelayAction>.Value, (Prov) new Actions.__\u003C\u003EAnon18());
      delayAction.setDuration(duration);
      delayAction.setAction(delayedAction);
      return delayAction;
    }

    [LineNumberTable(new byte[] {160, 225, 122, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TimeScaleAction timeScale(float scale, Action scaledAction)
    {
      TimeScaleAction timeScaleAction = (TimeScaleAction) Actions.action((Class) ClassLiteral<TimeScaleAction>.Value, (Prov) new Actions.__\u003C\u003EAnon19());
      timeScaleAction.setScale(scale);
      timeScaleAction.setAction(scaledAction);
      return timeScaleAction;
    }

    [LineNumberTable(new byte[] {160, 253, 122, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SequenceAction sequence(
      Action action1,
      Action action2,
      Action action3,
      Action action4)
    {
      SequenceAction sequenceAction = (SequenceAction) Actions.action((Class) ClassLiteral<SequenceAction>.Value, (Prov) new Actions.__\u003C\u003EAnon20());
      sequenceAction.addAction(action1);
      sequenceAction.addAction(action2);
      sequenceAction.addAction(action3);
      sequenceAction.addAction(action4);
      return sequenceAction;
    }

    [LineNumberTable(new byte[] {161, 6, 122, 103, 103, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SequenceAction sequence(
      Action action1,
      Action action2,
      Action action3,
      Action action4,
      Action action5)
    {
      SequenceAction sequenceAction = (SequenceAction) Actions.action((Class) ClassLiteral<SequenceAction>.Value, (Prov) new Actions.__\u003C\u003EAnon20());
      sequenceAction.addAction(action1);
      sequenceAction.addAction(action2);
      sequenceAction.addAction(action3);
      sequenceAction.addAction(action4);
      sequenceAction.addAction(action5);
      return sequenceAction;
    }

    [LineNumberTable(393)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SequenceAction sequence() => (SequenceAction) Actions.action((Class) ClassLiteral<SequenceAction>.Value, (Prov) new Actions.__\u003C\u003EAnon20());

    [LineNumberTable(new byte[] {161, 27, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ParallelAction parallel(Action action1)
    {
      ParallelAction parallelAction = (ParallelAction) Actions.action((Class) ClassLiteral<ParallelAction>.Value, (Prov) new Actions.__\u003C\u003EAnon21());
      parallelAction.addAction(action1);
      return parallelAction;
    }

    [LineNumberTable(new byte[] {161, 40, 122, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ParallelAction parallel(
      Action action1,
      Action action2,
      Action action3)
    {
      ParallelAction parallelAction = (ParallelAction) Actions.action((Class) ClassLiteral<ParallelAction>.Value, (Prov) new Actions.__\u003C\u003EAnon21());
      parallelAction.addAction(action1);
      parallelAction.addAction(action2);
      parallelAction.addAction(action3);
      return parallelAction;
    }

    [LineNumberTable(new byte[] {161, 48, 122, 103, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ParallelAction parallel(
      Action action1,
      Action action2,
      Action action3,
      Action action4)
    {
      ParallelAction parallelAction = (ParallelAction) Actions.action((Class) ClassLiteral<ParallelAction>.Value, (Prov) new Actions.__\u003C\u003EAnon21());
      parallelAction.addAction(action1);
      parallelAction.addAction(action2);
      parallelAction.addAction(action3);
      parallelAction.addAction(action4);
      return parallelAction;
    }

    [LineNumberTable(new byte[] {161, 57, 122, 103, 103, 103, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ParallelAction parallel(
      Action action1,
      Action action2,
      Action action3,
      Action action4,
      Action action5)
    {
      ParallelAction parallelAction = (ParallelAction) Actions.action((Class) ClassLiteral<ParallelAction>.Value, (Prov) new Actions.__\u003C\u003EAnon21());
      parallelAction.addAction(action1);
      parallelAction.addAction(action2);
      parallelAction.addAction(action3);
      parallelAction.addAction(action4);
      parallelAction.addAction(action5);
      return parallelAction;
    }

    [LineNumberTable(new byte[] {161, 67, 122, 105, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ParallelAction parallel(params Action[] actions)
    {
      ParallelAction parallelAction = (ParallelAction) Actions.action((Class) ClassLiteral<ParallelAction>.Value, (Prov) new Actions.__\u003C\u003EAnon21());
      int index = 0;
      for (int length = actions.Length; index < length; ++index)
        parallelAction.addAction(actions[index]);
      return parallelAction;
    }

    [LineNumberTable(444)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ParallelAction parallel() => (ParallelAction) Actions.action((Class) ClassLiteral<ParallelAction>.Value, (Prov) new Actions.__\u003C\u003EAnon21());

    [LineNumberTable(new byte[] {161, 78, 122, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RepeatAction repeat(int count, Action repeatedAction)
    {
      RepeatAction repeatAction = (RepeatAction) Actions.action((Class) ClassLiteral<RepeatAction>.Value, (Prov) new Actions.__\u003C\u003EAnon22());
      repeatAction.setCount(count);
      repeatAction.setAction(repeatedAction);
      return repeatAction;
    }

    [LineNumberTable(new byte[] {161, 85, 122, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RepeatAction forever(Action repeatedAction)
    {
      RepeatAction repeatAction = (RepeatAction) Actions.action((Class) ClassLiteral<RepeatAction>.Value, (Prov) new Actions.__\u003C\u003EAnon22());
      repeatAction.setCount(-1);
      repeatAction.setAction(repeatedAction);
      return repeatAction;
    }

    [LineNumberTable(new byte[] {159, 25, 66, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static LayoutAction layout(bool enabled)
    {
      int num = enabled ? 1 : 0;
      LayoutAction layoutAction = (LayoutAction) Actions.action((Class) ClassLiteral<LayoutAction>.Value, (Prov) new Actions.__\u003C\u003EAnon23());
      layoutAction.setLayoutEnabled(num != 0);
      return layoutAction;
    }

    [LineNumberTable(new byte[] {161, 104, 122, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AfterAction after(Action action)
    {
      AfterAction afterAction = (AfterAction) Actions.action((Class) ClassLiteral<AfterAction>.Value, (Prov) new Actions.__\u003C\u003EAnon24());
      afterAction.setAction(action);
      return afterAction;
    }

    [LineNumberTable(new byte[] {159, 22, 66, 122, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AddListenerAction addListener(
      EventListener listener,
      bool capture)
    {
      int num = capture ? 1 : 0;
      AddListenerAction addListenerAction = (AddListenerAction) Actions.action((Class) ClassLiteral<AddListenerAction>.Value, (Prov) new Actions.__\u003C\u003EAnon25());
      addListenerAction.setListener(listener);
      addListenerAction.setCapture(num != 0);
      return addListenerAction;
    }

    [LineNumberTable(new byte[] {159, 21, 162, 122, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static AddListenerAction addListener(
      EventListener listener,
      bool capture,
      Element targetActor)
    {
      int num = capture ? 1 : 0;
      AddListenerAction addListenerAction = (AddListenerAction) Actions.action((Class) ClassLiteral<AddListenerAction>.Value, (Prov) new Actions.__\u003C\u003EAnon25());
      addListenerAction.setTarget(targetActor);
      addListenerAction.setListener(listener);
      addListenerAction.setCapture(num != 0);
      return addListenerAction;
    }

    [LineNumberTable(new byte[] {159, 17, 130, 122, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RemoveListenerAction removeListener(
      EventListener listener,
      bool capture,
      Element targetActor)
    {
      int num = capture ? 1 : 0;
      RemoveListenerAction removeListenerAction = (RemoveListenerAction) Actions.action((Class) ClassLiteral<RemoveListenerAction>.Value, (Prov) new Actions.__\u003C\u003EAnon26());
      removeListenerAction.setTarget(targetActor);
      removeListenerAction.setListener(listener);
      removeListenerAction.setCapture(num != 0);
      return removeListenerAction;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new AddAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new RemoveAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new MoveToAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Prov
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get() => (object) new RunnableAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly RunnableAction arg\u00241;
      private readonly float arg\u00242;
      private readonly float arg\u00243;

      internal __\u003C\u003EAnon4([In] RunnableAction obj0, [In] float obj1, [In] float obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => Actions.lambda\u0024translateTo\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Prov
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public object get() => (object) new TranslateByAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Prov
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public object get() => (object) new MoveByAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Prov
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public object get() => (object) new SizeToAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Prov
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public object get() => (object) new SizeByAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) new ScaleToAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Prov
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public object get() => (object) new ScaleByAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Prov
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public object get() => (object) new RotateToAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Prov
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public object get() => (object) new RotateByAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Prov
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public object get() => (object) new ColorAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Prov
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public object get() => (object) new AlphaAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Prov
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public object get() => (object) new VisibleAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Prov
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public object get() => (object) new TouchableAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Prov
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public object get() => (object) new RemoveActorAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Prov
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public object get() => (object) new DelayAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Prov
    {
      internal __\u003C\u003EAnon19()
      {
      }

      public object get() => (object) new TimeScaleAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Prov
    {
      internal __\u003C\u003EAnon20()
      {
      }

      public object get() => (object) new SequenceAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Prov
    {
      internal __\u003C\u003EAnon21()
      {
      }

      public object get() => (object) new ParallelAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Prov
    {
      internal __\u003C\u003EAnon22()
      {
      }

      public object get() => (object) new RepeatAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Prov
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public object get() => (object) new LayoutAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Prov
    {
      internal __\u003C\u003EAnon24()
      {
      }

      public object get() => (object) new AfterAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Prov
    {
      internal __\u003C\u003EAnon25()
      {
      }

      public object get() => (object) new AddListenerAction();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Prov
    {
      internal __\u003C\u003EAnon26()
      {
      }

      public object get() => (object) new RemoveListenerAction();
    }
  }
}
