// Decompiled with JetBrains decompiler
// Type: mindustry.ui.MobileButton
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.style;
using arc.scene.ui;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.ui
{
  public class MobileButton : ImageButton
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 152, 105, 104, 103, 127, 24})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MobileButton(Drawable icon, string text, Runnable listener)
      : base(icon)
    {
      MobileButton mobileButton = this;
      this.clicked(listener);
      this.row();
      object obj = (object) text;
      CharSequence text1;
      text1.__\u003Cref\u003E = (__Null) obj;
      ((Label) this.add(text1).growX().wrap().center().get()).setAlignment(1, 1);
    }

    [HideFromJava]
    static MobileButton() => ImageButton.__\u003Cclinit\u003E();
  }
}
