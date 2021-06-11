// Decompiled with JetBrains decompiler
// Type: mindustry.ui.IntFormat
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class IntFormat : Object
  {
    [Modifiers]
    private StringBuilder builder;
    [Modifiers]
    private string text;
    private int lastValue;
    private int lastValue2;
    [Signature("Larc/func/Func<Ljava/lang/Integer;Ljava/lang/String;>;")]
    private Func converter;

    [LineNumberTable(new byte[] {159, 158, 232, 59, 139, 118, 176, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntFormat(string text)
    {
      IntFormat intFormat = this;
      this.builder = new StringBuilder();
      this.lastValue = int.MinValue;
      this.lastValue2 = int.MinValue;
      this.converter = (Func) new IntFormat.__\u003C\u003EAnon0();
      this.text = text;
    }

    [Signature("(Ljava/lang/String;Larc/func/Func<Ljava/lang/Integer;Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {159, 162, 232, 55, 139, 118, 240, 71, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntFormat(string text, Func converter)
    {
      IntFormat intFormat = this;
      this.builder = new StringBuilder();
      this.lastValue = int.MinValue;
      this.lastValue2 = int.MinValue;
      this.converter = (Func) new IntFormat.__\u003C\u003EAnon0();
      this.text = text;
      this.converter = converter;
    }

    [LineNumberTable(new byte[] {159, 168, 105, 108, 159, 23, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CharSequence get(int value)
    {
      if (this.lastValue != value)
      {
        this.builder.setLength(0);
        this.builder.append(Core.bundle.format(this.text, this.converter.get((object) Integer.valueOf(value))));
      }
      this.lastValue = value;
      object builder = (object) this.builder;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) builder;
      return charSequence;
    }

    [LineNumberTable(new byte[] {159, 177, 114, 108, 159, 21, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CharSequence get(int value1, int value2)
    {
      if (this.lastValue != value1 || this.lastValue2 != value2)
      {
        this.builder.setLength(0);
        this.builder.append(Core.bundle.format(this.text, (object) Integer.valueOf(value1), (object) Integer.valueOf(value2)));
      }
      this.lastValue = value1;
      this.lastValue2 = value2;
      object builder = (object) this.builder;
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) builder;
      return charSequence;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) String.valueOf((object) (Integer) obj0);
    }
  }
}
