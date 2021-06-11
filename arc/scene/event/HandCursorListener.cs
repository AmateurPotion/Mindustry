// Decompiled with JetBrains decompiler
// Type: arc.scene.event.HandCursorListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.scene.@event;
using arc.scene.utils;
using IKVM.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.@event
{
  public class HandCursorListener : ClickListener
  {
    public Boolp enabled;
    public bool checkEnabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 232, 56, 112, 231, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HandCursorListener()
    {
      HandCursorListener handCursorListener = this;
      this.enabled = (Boolp) new HandCursorListener.__\u003C\u003EAnon0();
      this.checkEnabled = true;
    }

    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool isDisabled([In] Element obj0) => obj0 != null && (obj0 is Disableable && ((Disableable) obj0).isDisabled() || (!obj0.visible || HandCursorListener.isDisabled((Element) obj0.parent)));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00240() => true;

    [LineNumberTable(new byte[] {159, 139, 98, 232, 61, 112, 167, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HandCursorListener(Boolp enabled, bool check)
    {
      int num = check ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      HandCursorListener handCursorListener = this;
      this.enabled = (Boolp) new HandCursorListener.__\u003C\u003EAnon0();
      this.checkEnabled = true;
      this.enabled = enabled;
      this.checkEnabled = num != 0;
    }

    [LineNumberTable(new byte[] {159, 165, 143, 127, 17, 161, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void enter(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      Element fromActor)
    {
      base.enter(@event, x, y, pointer, fromActor);
      if (pointer != -1 || !this.enabled.get() || this.checkEnabled && (HandCursorListener.isDisabled(@event.targetActor) || HandCursorListener.isDisabled(fromActor)))
        return;
      Core.graphics.cursor((Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Ehand);
    }

    [LineNumberTable(new byte[] {159, 176, 143, 101, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void exit(InputEvent @event, float x, float y, int pointer, Element toActor)
    {
      base.exit(@event, x, y, pointer, toActor);
      if (pointer != -1)
        return;
      Core.graphics.restoreCursor();
    }

    [HideFromJava]
    static HandCursorListener() => ClickListener.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Boolp
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get() => (HandCursorListener.lambda\u0024new\u00240() ? 1 : 0) != 0;
    }
  }
}
