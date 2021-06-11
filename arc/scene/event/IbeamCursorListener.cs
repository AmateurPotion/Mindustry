// Decompiled with JetBrains decompiler
// Type: arc.scene.event.IbeamCursorListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.scene.@event
{
  public class IbeamCursorListener : ClickListener
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IbeamCursorListener()
    {
    }

    [LineNumberTable(new byte[] {159, 152, 111, 114, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void enter(
      InputEvent @event,
      float x,
      float y,
      int pointer,
      Element fromActor)
    {
      base.enter(@event, x, y, pointer, fromActor);
      if (pointer != -1 || !@event.targetActor.visible)
        return;
      Core.graphics.cursor((Graphics.Cursor) Graphics.Cursor.SystemCursor.__\u003C\u003Eibeam);
    }

    [LineNumberTable(new byte[] {159, 160, 111, 101, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void exit(InputEvent @event, float x, float y, int pointer, Element toActor)
    {
      base.exit(@event, x, y, pointer, toActor);
      if (pointer != -1)
        return;
      Core.graphics.restoreCursor();
    }

    [HideFromJava]
    static IbeamCursorListener() => ClickListener.__\u003Cclinit\u003E();
  }
}
