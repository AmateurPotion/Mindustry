// Decompiled with JetBrains decompiler
// Type: rhino.ConsString
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using java.util.stream;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class ConsString : Object, CharSequence.__Interface
  {
    private CharSequence left;
    private CharSequence right;
    [Modifiers]
    private int length;
    private bool isFlat;

    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.isFlat ? (string) this.left.__\u003Cref\u003E : this.flatten();

    [LineNumberTable(new byte[] {159, 187, 107, 108, 135, 102, 148, 145, 105, 105, 105, 148, 118, 114, 194, 105, 106, 113, 122, 135, 126, 125, 135})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    private string flatten()
    {
      if (!this.isFlat)
      {
        char[] chArray = new char[this.length];
        int length = this.length;
        ArrayDeque arrayDeque = new ArrayDeque();
        arrayDeque.addFirst((object) this.left.__\u003Cref\u003E);
        object obj1 = (object) this.right.__\u003Cref\u003E;
        do
        {
          if (obj1 is ConsString)
          {
            ConsString consString = (ConsString) obj1;
            if (consString.isFlat)
            {
              obj1 = (object) consString.left.__\u003Cref\u003E;
            }
            else
            {
              arrayDeque.addFirst((object) consString.left.__\u003Cref\u003E);
              obj1 = (object) consString.right.__\u003Cref\u003E;
              goto label_10;
            }
          }
          string str = (string) obj1;
          length -= String.instancehelper_length(str);
          String.instancehelper_getChars(str, 0, String.instancehelper_length(str), chArray, length);
          object obj2;
          if (arrayDeque.isEmpty())
          {
            obj2 = (object) null;
          }
          else
          {
            obj2 = arrayDeque.removeFirst();
            CharSequence.Cast(obj2);
          }
          obj1 = obj2;
label_10:;
        }
        while (obj1 != null);
        object obj3 = (object) String.newhelper(chArray);
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        this.left = charSequence1;
        object obj4 = (object) "";
        CharSequence charSequence2;
        charSequence2.__\u003Cref\u003E = (__Null) obj4;
        this.right = charSequence2;
        this.isFlat = true;
      }
      return (string) this.left.__\u003Cref\u003E;
    }

    [LineNumberTable(new byte[] {159, 136, 180, 105, 121, 121, 127, 42, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConsString(CharSequence str1, CharSequence str2)
    {
      object obj1 = (object) str1.__\u003Cref\u003E;
      object obj2 = (object) str2.__\u003Cref\u003E;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ConsString consString = this;
      object obj3 = obj1;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      this.left = charSequence1;
      object obj4 = obj2;
      CharSequence charSequence2;
      charSequence2.__\u003Cref\u003E = (__Null) obj4;
      this.right = charSequence2;
      object obj5 = (object) this.left.__\u003Cref\u003E;
      CharSequence charSequence3;
      charSequence3.__\u003Cref\u003E = (__Null) obj5;
      int num1 = ((CharSequence) ref charSequence3).length();
      object obj6 = (object) this.right.__\u003Cref\u003E;
      charSequence3.__\u003Cref\u003E = (__Null) obj6;
      int num2 = ((CharSequence) ref charSequence3).length();
      this.length = num1 + num2;
      this.isFlat = false;
    }

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object writeReplace() => (object) this.toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int length() => this.length;

    [LineNumberTable(new byte[] {35, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char charAt(int index) => String.instancehelper_charAt(!this.isFlat ? this.flatten() : (string) this.left.__\u003Cref\u003E, index);

    [LineNumberTable(new byte[] {41, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CharSequence subSequence(int start, int end)
    {
      object obj = (object) String.instancehelper_substring(!this.isFlat ? this.flatten() : (string) this.left.__\u003Cref\u003E, start, end);
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      return charSequence;
    }

    [HideFromJava]
    public virtual IntStream chars()
    {
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) this;
      return ((CharSequence) ref charSequence).\u003Cdefault\u003Echars();
    }

    [HideFromJava]
    public virtual IntStream codePoints()
    {
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) this;
      return ((CharSequence) ref charSequence).\u003Cdefault\u003EcodePoints();
    }

    [HideFromJava]
    public static implicit operator CharSequence([In] ConsString obj0)
    {
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj0;
      return charSequence;
    }
  }
}
