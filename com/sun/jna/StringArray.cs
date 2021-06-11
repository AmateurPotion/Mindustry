// Decompiled with JetBrains decompiler
// Type: com.sun.jna.StringArray
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  [Implements(new string[] {"com.sun.jna.Function$PostCallRead"})]
  public class StringArray : Memory, Function.PostCallRead
  {
    private string encoding;
    [Signature("Ljava/util/List<Lcom/sun/jna/NativeString;>;")]
    private List natives;
    private object[] original;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 191, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringArray(string[] strings, string encoding)
      : this((object[]) strings, encoding)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {3, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringArray(WString[] strings)
      : this((object[]) strings, "--WIDE-STRING--")
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 131, 98, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringArray(string[] strings, bool wide)
    {
      int num = wide ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector((object[]) strings, num == 0 ? Native.getDefaultStringEncoding() : "--WIDE-STRING--");
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {6, 243, 45, 235, 84, 103, 103, 103, 98, 101, 111, 109, 135, 239, 57, 236, 73, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private StringArray([In] object[] obj0, [In] string obj1)
      : base((long) ((obj0.Length + 1) * Pointer.__\u003C\u003ESIZE))
    {
      StringArray stringArray = this;
      this.natives = (List) new ArrayList();
      this.original = obj0;
      this.encoding = obj1;
      int index = 0;
      while (index < obj0.Length)
      {
        Pointer pointer = (Pointer) null;
        if (obj0[index] != null)
        {
          NativeString nativeString = new NativeString(Object.instancehelper_toString(obj0[index]), obj1);
          this.natives.add((object) nativeString);
          pointer = nativeString.getPointer();
        }
        this.setPointer((long) (Pointer.__\u003C\u003ESIZE * index), pointer);
        ++index;
        GC.KeepAlive((object) this);
      }
      this.setPointer((long) (Pointer.__\u003C\u003ESIZE * obj0.Length), (Pointer) null);
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 183, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringArray(string[] strings)
      : this(strings, false)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {23, 111, 113, 111, 111, 99, 99, 125, 150, 234, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read()
    {
      int num1 = this.original is WString[] ? 1 : 0;
      int num2 = String.instancehelper_equals("--WIDE-STRING--", (object) this.encoding) ? 1 : 0;
      for (int index = 0; index < this.original.Length; ++index)
      {
        Pointer pointer = this.getPointer((long) (index * Pointer.__\u003C\u003ESIZE));
        object obj = (object) null;
        if (pointer != null)
        {
          obj = num2 == 0 ? (object) pointer.getString(0L, this.encoding) : (object) pointer.getWideString(0L);
          if (num1 != 0)
            obj = (object) new WString((string) obj);
        }
        this.original[index] = obj;
      }
    }

    [LineNumberTable(new byte[] {38, 113, 112, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => new StringBuilder().append(!String.instancehelper_equals("--WIDE-STRING--", (object) this.encoding) ? "const char*[]" : "const wchar_t*[]").append((object) Arrays.asList(this.original)).toString();

    [HideFromJava]
    static StringArray() => Memory.__\u003Cclinit\u003E();
  }
}
