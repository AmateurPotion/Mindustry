// Decompiled with JetBrains decompiler
// Type: com.sun.jna.WString
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util.stream;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  [Implements(new string[] {"java.lang.CharSequence", "java.lang.Comparable"})]
  public sealed class WString : Object, CharSequence.__Interface, Comparable
  {
    private string @string;

    [LineNumberTable(new byte[] {159, 173, 104, 99, 144, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public WString(string s)
    {
      WString wstring = this;
      if (s == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("String initializer must be non-null");
      }
      this.@string = s;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.@string;

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o) => o is WString && String.instancehelper_equals(this.toString(), (object) Object.instancehelper_toString(o));

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => String.instancehelper_hashCode(this.toString());

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(object o) => String.instancehelper_compareTo(this.toString(), Object.instancehelper_toString(o));

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int length() => String.instancehelper_length(this.toString());

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char charAt(int index) => String.instancehelper_charAt(this.toString(), index);

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CharSequence subSequence(int start, int end)
    {
      object obj = (object) String.instancehelper_subSequence(this.toString(), start, end).__\u003Cref\u003E;
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
    public static implicit operator CharSequence([In] WString obj0)
    {
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj0;
      return charSequence;
    }

    int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
      [In] object obj0)
    {
      return this.compareTo(obj0);
    }
  }
}
