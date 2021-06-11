// Decompiled with JetBrains decompiler
// Type: mindustry.ui.fragments.OverlayFragment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.scene;
using arc.scene.@event;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.fragments
{
  public class OverlayFragment : Object
  {
    internal BlockInventoryFragment __\u003C\u003Einv;
    internal BlockConfigFragment __\u003C\u003Econfig;
    private WidgetGroup group;

    [LineNumberTable(new byte[] {159, 157, 8, 171, 112, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OverlayFragment()
    {
      OverlayFragment overlayFragment = this;
      this.group = new WidgetGroup();
      this.group.touchable = Touchable.__\u003C\u003EchildrenOnly;
      this.__\u003C\u003Einv = new BlockInventoryFragment();
      this.__\u003C\u003Econfig = new BlockConfigFragment();
    }

    [LineNumberTable(new byte[] {159, 172, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove() => this.group.remove();

    [LineNumberTable(new byte[] {159, 164, 108, 159, 5, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add()
    {
      this.group.setFillParent(true);
      Vars.ui.hudGroup.addChildBefore(Core.scene.find("overlaymarker"), (Element) this.group);
      this.__\u003C\u003Einv.build((Group) this.group);
      this.__\u003C\u003Econfig.build((Group) this.group);
    }

    [Modifiers]
    public BlockInventoryFragment inv
    {
      [HideFromJava] get => this.__\u003C\u003Einv;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Einv = value;
    }

    [Modifiers]
    public BlockConfigFragment config
    {
      [HideFromJava] get => this.__\u003C\u003Econfig;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Econfig = value;
    }
  }
}
