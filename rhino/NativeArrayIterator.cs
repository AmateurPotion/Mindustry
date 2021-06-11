// Decompiled with JetBrains decompiler
// Type: rhino.NativeArrayIterator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public sealed class NativeArrayIterator : ES6Iterator
  {
    private const string ITERATOR_TAG = "ArrayIterator";
    private NativeArrayIterator.ARRAY_ITERATOR_TYPE type;
    private Scriptable arrayLike;
    private int index;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 168, 110, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeArrayIterator(
      Scriptable scope,
      Scriptable arrayLike,
      NativeArrayIterator.ARRAY_ITERATOR_TYPE type)
      : base(scope, "ArrayIterator")
    {
      NativeArrayIterator nativeArrayIterator = this;
      this.index = 0;
      this.arrayLike = arrayLike;
      this.type = type;
    }

    [LineNumberTable(new byte[] {159, 164, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeArrayIterator()
    {
    }

    [LineNumberTable(new byte[] {159, 139, 162, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] ScriptableObject obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      ES6Iterator.init(obj0, num != 0, (IdScriptableObject) new NativeArrayIterator(), "ArrayIterator");
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Array Iterator";

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool isDone(Context cx, Scriptable scope) => (long) this.index >= NativeArray.getLengthProperty(cx, this.arrayLike, false);

    [LineNumberTable(new byte[] {159, 186, 114, 185, 120, 109, 166, 114, 191, 1, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object nextValue(Context cx, Scriptable scope)
    {
      if (object.ReferenceEquals((object) this.type, (object) NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EKEYS))
      {
        NativeArrayIterator nativeArrayIterator1 = this;
        int index = nativeArrayIterator1.index;
        NativeArrayIterator nativeArrayIterator2 = nativeArrayIterator1;
        int num = index;
        nativeArrayIterator2.index = index + 1;
        return (object) Integer.valueOf(num);
      }
      object objA = this.arrayLike.get(this.index, this.arrayLike);
      if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        objA = Undefined.__\u003C\u003Einstance;
      if (object.ReferenceEquals((object) this.type, (object) NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EENTRIES))
        objA = (object) cx.newArray(scope, new object[2]
        {
          (object) Integer.valueOf(this.index),
          objA
        });
      ++this.index;
      return objA;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getTag() => "ArrayIterator";

    [HideFromJava]
    static NativeArrayIterator() => ES6Iterator.__\u003Cclinit\u003E();

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lrhino/NativeArrayIterator$ARRAY_ITERATOR_TYPE;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ARRAY_ITERATOR_TYPE : Enum
    {
      [Modifiers]
      internal static NativeArrayIterator.ARRAY_ITERATOR_TYPE __\u003C\u003EENTRIES;
      [Modifiers]
      internal static NativeArrayIterator.ARRAY_ITERATOR_TYPE __\u003C\u003EKEYS;
      [Modifiers]
      internal static NativeArrayIterator.ARRAY_ITERATOR_TYPE __\u003C\u003EVALUES;
      [Modifiers]
      private static NativeArrayIterator.ARRAY_ITERATOR_TYPE[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(4)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ARRAY_ITERATOR_TYPE([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(4)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static NativeArrayIterator.ARRAY_ITERATOR_TYPE[] values() => (NativeArrayIterator.ARRAY_ITERATOR_TYPE[]) NativeArrayIterator.ARRAY_ITERATOR_TYPE.\u0024VALUES.Clone();

      [LineNumberTable(4)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static NativeArrayIterator.ARRAY_ITERATOR_TYPE valueOf(string name) => (NativeArrayIterator.ARRAY_ITERATOR_TYPE) Enum.valueOf((Class) ClassLiteral<NativeArrayIterator.ARRAY_ITERATOR_TYPE>.Value, name);

      [LineNumberTable(new byte[] {159, 141, 109, 112, 112, 240, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ARRAY_ITERATOR_TYPE()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.NativeArrayIterator$ARRAY_ITERATOR_TYPE"))
          return;
        NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EENTRIES = new NativeArrayIterator.ARRAY_ITERATOR_TYPE(nameof (ENTRIES), 0);
        NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EKEYS = new NativeArrayIterator.ARRAY_ITERATOR_TYPE(nameof (KEYS), 1);
        NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EVALUES = new NativeArrayIterator.ARRAY_ITERATOR_TYPE(nameof (VALUES), 2);
        NativeArrayIterator.ARRAY_ITERATOR_TYPE.\u0024VALUES = new NativeArrayIterator.ARRAY_ITERATOR_TYPE[3]
        {
          NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EENTRIES,
          NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EKEYS,
          NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EVALUES
        };
      }

      [Modifiers]
      public static NativeArrayIterator.ARRAY_ITERATOR_TYPE ENTRIES
      {
        [HideFromJava] get => NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EENTRIES;
      }

      [Modifiers]
      public static NativeArrayIterator.ARRAY_ITERATOR_TYPE KEYS
      {
        [HideFromJava] get => NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EKEYS;
      }

      [Modifiers]
      public static NativeArrayIterator.ARRAY_ITERATOR_TYPE VALUES
      {
        [HideFromJava] get => NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EVALUES;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        ENTRIES,
        KEYS,
        VALUES,
      }
    }
  }
}
