// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.BooleanValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.world.meta.values
{
  public class BooleanValue : Object, StatValue
  {
    [Modifiers]
    private bool value;

    [LineNumberTable(new byte[] {159, 140, 98, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BooleanValue(bool value)
    {
      int num = value ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      BooleanValue booleanValue = this;
      this.value = num != 0;
    }

    [LineNumberTable(new byte[] {159, 157, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      Table table1 = table;
      object obj = this.value ? (object) "@yes" : (object) "@no";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table1.add(text);
    }
  }
}
