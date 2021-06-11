// Decompiled with JetBrains decompiler
// Type: rhino.v8dtoa.FastDtoaBuilder
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.v8dtoa
{
  public class FastDtoaBuilder : Object
  {
    [Modifiers]
    internal char[] chars;
    internal int end;
    internal int point;
    internal bool formatted;
    [Modifiers]
    internal static char[] digits;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void decreaseLast()
    {
      char[] chars = this.chars;
      int index = this.end - 1;
      char[] chArray = chars;
      chArray[index] = (char) ((uint) chArray[index] - 1U);
    }

    [LineNumberTable(new byte[] {159, 139, 130, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void append([In] char obj0)
    {
      int num1 = (int) obj0;
      char[] chars = this.chars;
      FastDtoaBuilder fastDtoaBuilder1 = this;
      int end = fastDtoaBuilder1.end;
      FastDtoaBuilder fastDtoaBuilder2 = fastDtoaBuilder1;
      int index = end;
      fastDtoaBuilder2.end = end + 1;
      int num2 = num1;
      chars[index] = (char) num2;
    }

    [LineNumberTable(new byte[] {159, 147, 168, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public FastDtoaBuilder()
    {
      FastDtoaBuilder fastDtoaBuilder = this;
      this.chars = new char[25];
      this.end = 0;
      this.formatted = false;
    }

    [LineNumberTable(new byte[] {159, 174, 136, 109, 105, 106, 138, 136, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string format()
    {
      if (!this.formatted)
      {
        int num1 = this.chars[0] == '-' ? 1 : 0;
        int num2 = this.point - num1;
        if (num2 < -5 || num2 > 21)
          this.toExponentialFormat(num1, num2);
        else
          this.toFixedFormat(num1, num2);
        this.formatted = true;
      }
      return String.newhelper(this.chars, 0, this.end);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      this.end = 0;
      this.formatted = false;
    }

    [LineNumberTable(new byte[] {24, 139, 100, 125, 106, 142, 124, 99, 100, 100, 99, 131, 155, 127, 7, 202, 111, 119, 101, 101, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void toExponentialFormat([In] int obj0, [In] int obj1)
    {
      if (this.end - obj0 > 1)
      {
        int index = obj0 + 1;
        ByteCodeHelper.arraycopy_primitive_2((Array) this.chars, index, (Array) this.chars, index + 1, this.end - index);
        this.chars[index] = '.';
        ++this.end;
      }
      char[] chars1 = this.chars;
      FastDtoaBuilder fastDtoaBuilder1 = this;
      int end1 = fastDtoaBuilder1.end;
      FastDtoaBuilder fastDtoaBuilder2 = fastDtoaBuilder1;
      int index1 = end1;
      fastDtoaBuilder2.end = end1 + 1;
      chars1[index1] = 'e';
      int num1 = 43;
      int num2 = obj1 - 1;
      if (num2 < 0)
      {
        num1 = 45;
        num2 = -num2;
      }
      char[] chars2 = this.chars;
      FastDtoaBuilder fastDtoaBuilder3 = this;
      int end2 = fastDtoaBuilder3.end;
      FastDtoaBuilder fastDtoaBuilder4 = fastDtoaBuilder3;
      int index2 = end2;
      fastDtoaBuilder4.end = end2 + 1;
      int num3 = num1;
      chars2[index2] = (char) num3;
      int num4 = num2 <= 99 ? (num2 <= 9 ? this.end : this.end + 1) : this.end + 2;
      this.end = num4 + 1;
      do
      {
        int num5 = num2;
        int num6 = 10;
        int index3 = num6 != -1 ? num5 % num6 : 0;
        char[] chars3 = this.chars;
        int index4 = num4;
        num4 += -1;
        int digit = (int) FastDtoaBuilder.digits[index3];
        chars3[index4] = (char) digit;
        num2 /= 10;
      }
      while (num2 != 0);
    }

    [LineNumberTable(new byte[] {159, 190, 145, 132, 127, 13, 111, 179, 102, 123, 106, 108, 100, 145, 112, 98, 142, 121, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void toFixedFormat([In] int obj0, [In] int obj1)
    {
      if (this.point < this.end)
      {
        if (obj1 > 0)
        {
          ByteCodeHelper.arraycopy_primitive_2((Array) this.chars, this.point, (Array) this.chars, this.point + 1, this.end - this.point);
          this.chars[this.point] = '.';
          ++this.end;
        }
        else
        {
          int num = obj0 + 2 - obj1;
          ByteCodeHelper.arraycopy_primitive_2((Array) this.chars, obj0, (Array) this.chars, num, this.end - obj0);
          this.chars[obj0] = '0';
          this.chars[obj0 + 1] = '.';
          if (obj1 < 0)
            Arrays.fill(this.chars, obj0 + 2, num, '0');
          this.end += 2 - obj1;
        }
      }
      else
      {
        if (this.point <= this.end)
          return;
        Arrays.fill(this.chars, this.end, this.point, '0');
        this.end += this.point - this.end;
      }
    }

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[chars:").append(String.newhelper(this.chars, 0, this.end)).append(", point:").append(this.point).append("]").toString();

    [LineNumberTable(102)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static FastDtoaBuilder()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.v8dtoa.FastDtoaBuilder"))
        return;
      FastDtoaBuilder.digits = new char[10]
      {
        '0',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9'
      };
    }
  }
}
