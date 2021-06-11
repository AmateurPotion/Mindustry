// Decompiled with JetBrains decompiler
// Type: rhino.NativeStringIterator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public sealed class NativeStringIterator : ES6Iterator
  {
    private const string ITERATOR_TAG = "StringIterator";
    private string @string;
    private int index;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 110, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal NativeStringIterator([In] Scriptable obj0, [In] Scriptable obj1)
      : base(obj0, "StringIterator")
    {
      NativeStringIterator nativeStringIterator = this;
      this.index = 0;
      this.@string = ScriptRuntime.toString((object) obj1);
    }

    [LineNumberTable(new byte[] {159, 156, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeStringIterator()
    {
    }

    [LineNumberTable(new byte[] {159, 141, 162, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] ScriptableObject obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      ES6Iterator.init(obj0, num != 0, (IdScriptableObject) new NativeStringIterator(), "StringIterator");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "String Iterator";

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool isDone(Context cx, Scriptable scope) => this.index >= String.instancehelper_length(this.@string);

    [LineNumberTable(new byte[] {159, 177, 115, 115, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object nextValue(Context cx, Scriptable scope)
    {
      int num = String.instancehelper_offsetByCodePoints(this.@string, this.index, 1);
      string str = String.instancehelper_substring(this.@string, this.index, num);
      this.index = num;
      return (object) str;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getTag() => "StringIterator";

    [HideFromJava]
    static NativeStringIterator() => ES6Iterator.__\u003Cclinit\u003E();
  }
}
