// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.FloorEfficiencyValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.scene;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.ui;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.world.meta.values
{
  public class FloorEfficiencyValue : Object, StatValue
  {
    [Modifiers]
    private Floor floor;
    [Modifiers]
    private float multiplier;
    [Modifiers]
    private bool startZero;

    [LineNumberTable(new byte[] {159, 139, 162, 104, 103, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloorEfficiencyValue(Floor floor, float multiplier, bool startZero)
    {
      int num = startZero ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      FloorEfficiencyValue floorEfficiencyValue = this;
      this.floor = floor;
      this.multiplier = multiplier;
      this.startZero = num != 0;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 166, 127, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024display\u00240([In] Table obj0)
    {
      Table table = obj0.top().right();
      object obj = (object) new StringBuilder().append((double) this.multiplier >= 0.0 ? (!this.startZero ? "[accent]+" : "[accent]") : "[scarlet]").append(ByteCodeHelper.f2i(this.multiplier * 100f)).append("%").toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).style((Style) Styles.outlineLabel);
    }

    [LineNumberTable(new byte[] {159, 165, 191, 40})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      Table table1 = table;
      Element[] elementArray = new Element[2]
      {
        (Element) new Image(this.floor.icon(Cicon.__\u003C\u003Emedium)).setScaling(Scaling.__\u003C\u003Efit),
        null
      };
      Table.__\u003Cclinit\u003E();
      elementArray[1] = (Element) new Table((Cons) new FloorEfficiencyValue.__\u003C\u003EAnon0(this));
      table1.stack(elementArray);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly FloorEfficiencyValue arg\u00241;

      internal __\u003C\u003EAnon0([In] FloorEfficiencyValue obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024display\u00240((Table) obj0);
    }
  }
}
