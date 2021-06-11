// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.NumberValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.world.meta.values
{
  public class NumberValue : Object, StatValue
  {
    [Modifiers]
    private StatUnit unit;
    [Modifiers]
    private float value;

    [LineNumberTable(new byte[] {159, 157, 104, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NumberValue(float value, StatUnit unit)
    {
      NumberValue numberValue = this;
      this.unit = unit;
      this.value = value;
    }

    [LineNumberTable(new byte[] {159, 164, 159, 57, 127, 4, 127, 48})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      int decimalPlaces = (double) Math.abs((float) ByteCodeHelper.f2i(this.value) - this.value) > 1.0 / 1000.0 ? ((double) Math.abs((float) ByteCodeHelper.f2i(this.value * 10f) - this.value * 10f) > 1.0 / 1000.0 ? 2 : 1) : 0;
      Table table1 = table;
      object obj1 = (object) Strings.@fixed(this.value, decimalPlaces);
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence text1 = charSequence;
      table1.add(text1);
      Table table2 = table;
      object obj2 = (object) new StringBuilder().append(!this.unit.__\u003C\u003Espace ? "" : " ").append(this.unit.localized()).toString();
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text2 = charSequence;
      table2.add(text2);
    }
  }
}
