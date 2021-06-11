// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.FloorValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene;
using arc.scene.ui;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.ui;
using mindustry.world.blocks.environment;
using System.Runtime.CompilerServices;

namespace mindustry.world.meta.values
{
  public class FloorValue : Object, StatValue
  {
    [Modifiers]
    private Floor floor;

    [LineNumberTable(new byte[] {159, 154, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FloorValue(Floor floor)
    {
      FloorValue floorValue = this;
      this.floor = floor;
    }

    [LineNumberTable(new byte[] {159, 160, 127, 7, 127, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      table.add((Element) new Image(this.floor.icon(Cicon.__\u003C\u003Esmall))).padRight(3f);
      Table table1 = table;
      object localizedName = (object) this.floor.localizedName;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) localizedName;
      CharSequence text = charSequence;
      table1.add(text).padRight(3f);
    }
  }
}
