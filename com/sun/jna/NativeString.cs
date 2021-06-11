// Decompiled with JetBrains decompiler
// Type: com.sun.jna.NativeString
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.nio;
using java.util.stream;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  [Implements(new string[] {"java.lang.CharSequence", "java.lang.Comparable"})]
  internal class NativeString : Object, CharSequence.__Interface, Comparable
  {
    internal const string WIDE_STRING = "--WIDE-STRING--";
    private Pointer pointer;
    private string encoding;

    [LineNumberTable(new byte[] {159, 126, 98, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeString([In] string obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(obj0, num == 0 ? Native.getDefaultStringEncoding() : "--WIDE-STRING--");
    }

    [LineNumberTable(new byte[] {28, 104, 99, 240, 69, 103, 114, 111, 110, 110, 98, 104, 118, 113, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeString([In] string obj0, [In] string obj1)
    {
      NativeString nativeString = this;
      if (obj0 == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("String must not be null");
      }
      this.encoding = obj1;
      if (String.instancehelper_equals("--WIDE-STRING--", (object) this.encoding))
      {
        this.pointer = (Pointer) new NativeString.StringMemory(this, (long) ((String.instancehelper_length(obj0) + 1) * Native.__\u003C\u003EWCHAR_SIZE));
        this.pointer.setWideString(0L, obj0);
      }
      else
      {
        byte[] bytes = Native.getBytes(obj0, obj1);
        NativeString.StringMemory.__\u003Cclinit\u003E();
        this.pointer = (Pointer) new NativeString.StringMemory(this, (long) (bytes.Length + 1));
        this.pointer.write(0L, bytes, 0, bytes.Length);
        this.pointer.setByte((long) bytes.Length, (byte) 0);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer getPointer() => this.pointer;

    [LineNumberTable(new byte[] {63, 113, 112, 127, 48})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      int num = String.instancehelper_equals("--WIDE-STRING--", (object) this.encoding) ? 1 : 0;
      return new StringBuilder().append(num == 0 ? "const char*" : "const wchar_t*").append("(").append(num == 0 ? this.pointer.getString(0L, this.encoding) : this.pointer.getWideString(0L)).append(")").toString();
    }

    [LineNumberTable(new byte[] {90, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo([In] object obj0) => obj0 == null ? 1 : String.instancehelper_compareTo(this.toString(), Object.instancehelper_toString(obj0));

    [LineNumberTable(new byte[] {3, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeString([In] string obj0)
      : this(obj0, Native.getDefaultStringEncoding())
    {
    }

    [LineNumberTable(new byte[] {22, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeString([In] WString obj0)
      : this(obj0.toString(), "--WIDE-STRING--")
    {
    }

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => String.instancehelper_hashCode(this.toString());

    [LineNumberTable(new byte[] {55, 104, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals([In] object obj0) => CharSequence.IsInstance(obj0) && this.compareTo(obj0) == 0;

    [LineNumberTable(125)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual char charAt([In] int obj0) => String.instancehelper_charAt(this.toString(), obj0);

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int length() => String.instancehelper_length(this.toString());

    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CharSequence subSequence([In] int obj0, [In] int obj1)
    {
      object obj2 = (object) this.toString();
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      object obj3 = (object) CharBuffer.wrap(charSequence1).subSequence(obj0, obj1);
      CharSequence charSequence2;
      charSequence2.__\u003Cref\u003E = (__Null) obj3;
      return charSequence2;
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

    int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
      [In] object obj0)
    {
      return this.compareTo(obj0);
    }

    [InnerClass]
    internal class StringMemory : Memory
    {
      [Modifiers]
      internal NativeString this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public StringMemory([In] NativeString obj0, [In] long obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(45)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string toString() => this.this\u00240.toString();

      [HideFromJava]
      static StringMemory() => Memory.__\u003Cclinit\u003E();
    }
  }
}
