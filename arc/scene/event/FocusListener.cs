// Decompiled with JetBrains decompiler
// Type: arc.scene.event.FocusListener
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.@event;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.@event
{
  public abstract class FocusListener : Object, EventListener
  {
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void keyboardFocusChanged(
      FocusListener.FocusEvent @event,
      Element element,
      bool focused)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void scrollFocusChanged(
      FocusListener.FocusEvent @event,
      Element element,
      bool focused)
    {
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FocusListener()
    {
    }

    [LineNumberTable(new byte[] {159, 154, 106, 103, 159, 3, 115, 130, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool handle(SceneEvent @event)
    {
      if (!(@event is FocusListener.FocusEvent))
        return false;
      FocusListener.FocusEvent event1 = (FocusListener.FocusEvent) @event;
      switch (FocusListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024FocusListener\u0024FocusEvent\u0024Type[event1.type.ordinal()])
      {
        case 1:
          this.keyboardFocusChanged(event1, @event.targetActor, event1.focused);
          break;
        case 2:
          this.scrollFocusChanged(event1, @event.targetActor, event1.focused);
          break;
      }
      return false;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024FocusListener\u0024FocusEvent\u0024Type;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(14)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.scene.event.FocusListener$1"))
          return;
        FocusListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024FocusListener\u0024FocusEvent\u0024Type = new int[FocusListener.FocusEvent.Type.values().Length];
        try
        {
          FocusListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024FocusListener\u0024FocusEvent\u0024Type[FocusListener.FocusEvent.Type.__\u003C\u003Ekeyboard.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          FocusListener.\u0031.\u0024SwitchMap\u0024arc\u0024scene\u0024event\u0024FocusListener\u0024FocusEvent\u0024Type[FocusListener.FocusEvent.Type.__\u003C\u003Escroll.ordinal()] = 2;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    public class FocusEvent : SceneEvent
    {
      public bool focused;
      public FocusListener.FocusEvent.Type type;
      public Element relatedActor;

      [LineNumberTable(37)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FocusEvent()
      {
      }

      [LineNumberTable(new byte[] {159, 186, 102, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void reset()
      {
        base.reset();
        this.relatedActor = (Element) null;
      }

      [InnerClass]
      [Signature("Ljava/lang/Enum<Larc/scene/event/FocusListener$FocusEvent$Type;>;")]
      [Modifiers]
      [Serializable]
      public sealed class Type : Enum
      {
        [Modifiers]
        internal static FocusListener.FocusEvent.Type __\u003C\u003Ekeyboard;
        [Modifiers]
        internal static FocusListener.FocusEvent.Type __\u003C\u003Escroll;
        [Modifiers]
        private static FocusListener.FocusEvent.Type[] \u0024VALUES;

        [SpecialName]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void __\u003Cclinit\u003E()
        {
        }

        [LineNumberTable(49)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FocusListener.FocusEvent.Type[] values() => (FocusListener.FocusEvent.Type[]) FocusListener.FocusEvent.Type.\u0024VALUES.Clone();

        [Signature("()V")]
        [LineNumberTable(49)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private Type([In] string obj0, [In] int obj1)
          : base(obj0, obj1)
        {
          GC.KeepAlive((object) this);
        }

        [LineNumberTable(49)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FocusListener.FocusEvent.Type valueOf(string name) => (FocusListener.FocusEvent.Type) Enum.valueOf((Class) ClassLiteral<FocusListener.FocusEvent.Type>.Value, name);

        [LineNumberTable(new byte[] {159, 130, 141, 63, 1})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        static Type()
        {
          if (ByteCodeHelper.isAlreadyInited("arc.scene.event.FocusListener$FocusEvent$Type"))
            return;
          FocusListener.FocusEvent.Type.__\u003C\u003Ekeyboard = new FocusListener.FocusEvent.Type(nameof (keyboard), 0);
          FocusListener.FocusEvent.Type.__\u003C\u003Escroll = new FocusListener.FocusEvent.Type(nameof (scroll), 1);
          FocusListener.FocusEvent.Type.\u0024VALUES = new FocusListener.FocusEvent.Type[2]
          {
            FocusListener.FocusEvent.Type.__\u003C\u003Ekeyboard,
            FocusListener.FocusEvent.Type.__\u003C\u003Escroll
          };
        }

        [Modifiers]
        public static FocusListener.FocusEvent.Type keyboard
        {
          [HideFromJava] get => FocusListener.FocusEvent.Type.__\u003C\u003Ekeyboard;
        }

        [Modifiers]
        public static FocusListener.FocusEvent.Type scroll
        {
          [HideFromJava] get => FocusListener.FocusEvent.Type.__\u003C\u003Escroll;
        }

        [HideFromJava]
        [Serializable]
        public enum __Enum
        {
          keyboard,
          scroll,
        }
      }
    }
  }
}
