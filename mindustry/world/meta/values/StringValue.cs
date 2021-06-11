// Decompiled with JetBrains decompiler
// Type: mindustry.world.meta.values.StringValue
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.world.meta.values
{
  public class StringValue : Object, StatValue
  {
    [Modifiers]
    private string value;

    [LineNumberTable(new byte[] {159, 152, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringValue(string value, params object[] args)
    {
      StringValue stringValue = this;
      this.value = Strings.format(value, args);
    }

    [LineNumberTable(new byte[] {159, 158, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
      Table table1 = table;
      object obj = (object) this.value;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table1.add(text);
    }
  }
}
