// Decompiled with JetBrains decompiler
// Type: rhino.NativeCollectionIterator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class NativeCollectionIterator : ES6Iterator
  {
    private string className;
    private NativeCollectionIterator.Type type;
    [Signature("Ljava/util/Iterator<Lrhino/Hashtable$Entry;>;")]
    [NonSerialized]
    private Iterator iterator;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 159, 104, 103, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeCollectionIterator(string tag)
    {
      NativeCollectionIterator collectionIterator = this;
      this.className = tag;
      this.iterator = Collections.emptyIterator();
      this.type = NativeCollectionIterator.Type.BOTH;
    }

    [LineNumberTable(new byte[] {159, 139, 130, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] ScriptableObject obj0, [In] string obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      ES6Iterator.init(obj0, num != 0, (IdScriptableObject) new NativeCollectionIterator(obj1), obj1);
    }

    [Signature("(Lrhino/Scriptable;Ljava/lang/String;Lrhino/NativeCollectionIterator$Type;Ljava/util/Iterator<Lrhino/Hashtable$Entry;>;)V")]
    [LineNumberTable(new byte[] {159, 168, 106, 103, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeCollectionIterator(
      Scriptable scope,
      string className,
      NativeCollectionIterator.Type type,
      Iterator iterator)
      : base(scope, className)
    {
      NativeCollectionIterator collectionIterator = this;
      this.className = className;
      this.iterator = iterator;
      this.type = type;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => this.className;

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override bool isDone(Context cx, Scriptable scope) => !this.iterator.hasNext();

    [LineNumberTable(new byte[] {159, 186, 113, 159, 7, 135, 135, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object nextValue(Context cx, Scriptable scope)
    {
      Hashtable.Entry entry = (Hashtable.Entry) this.iterator.next();
      switch (NativeCollectionIterator.\u0031.\u0024SwitchMap\u0024rhino\u0024NativeCollectionIterator\u0024Type[this.type.ordinal()])
      {
        case 1:
          return entry.key;
        case 2:
          return entry.value;
        case 3:
          return (object) cx.newArray(scope, new object[2]
          {
            entry.key,
            entry.value
          });
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
      }
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {9, 102, 113, 113, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      this.className = (string) obj0.readObject();
      this.type = (NativeCollectionIterator.Type) obj0.readObject();
      this.iterator = Collections.emptyIterator();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {17, 102, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeObject([In] ObjectOutputStream obj0)
    {
      obj0.defaultWriteObject();
      obj0.writeObject((object) this.className);
      obj0.writeObject((object) this.type);
    }

    [HideFromJava]
    static NativeCollectionIterator() => ES6Iterator.__\u003Cclinit\u003E();

    [HideFromJava]
    [NameSig("<init>", "(Lrhino.Scriptable;Ljava.lang.String;Lrhino.NativeCollectionIterator$Type;Ljava.util.Iterator;)V")]
    public NativeCollectionIterator([In] Scriptable obj0, [In] string obj1, [In] Enum obj2, [In] Iterator obj3)
      : this(obj0, obj1, (NativeCollectionIterator.Type) obj2, obj3)
    {
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024rhino\u0024NativeCollectionIterator\u0024Type;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(45)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.NativeCollectionIterator$1"))
          return;
        NativeCollectionIterator.\u0031.\u0024SwitchMap\u0024rhino\u0024NativeCollectionIterator\u0024Type = new int[NativeCollectionIterator.Type.values().Length];
        try
        {
          NativeCollectionIterator.\u0031.\u0024SwitchMap\u0024rhino\u0024NativeCollectionIterator\u0024Type[NativeCollectionIterator.Type.KEYS.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          NativeCollectionIterator.\u0031.\u0024SwitchMap\u0024rhino\u0024NativeCollectionIterator\u0024Type[NativeCollectionIterator.Type.VALUES.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          NativeCollectionIterator.\u0031.\u0024SwitchMap\u0024rhino\u0024NativeCollectionIterator\u0024Type[NativeCollectionIterator.Type.BOTH.ordinal()] = 3;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lrhino/NativeCollectionIterator$Type;>;")]
    [Modifiers]
    [Serializable]
    internal sealed class Type : Enum
    {
      [Modifiers]
      public static NativeCollectionIterator.Type KEYS;
      [Modifiers]
      public static NativeCollectionIterator.Type VALUES;
      [Modifiers]
      public static NativeCollectionIterator.Type BOTH;
      [Modifiers]
      private static NativeCollectionIterator.Type[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(11)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static NativeCollectionIterator.Type[] values() => (NativeCollectionIterator.Type[]) NativeCollectionIterator.Type.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(11)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Type([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(11)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static NativeCollectionIterator.Type valueOf([In] string obj0) => (NativeCollectionIterator.Type) Enum.valueOf((Class) ClassLiteral<NativeCollectionIterator.Type>.Value, obj0);

      [LineNumberTable(11)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Type()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.NativeCollectionIterator$Type"))
          return;
        NativeCollectionIterator.Type.KEYS = new NativeCollectionIterator.Type(nameof (KEYS), 0);
        NativeCollectionIterator.Type.VALUES = new NativeCollectionIterator.Type(nameof (VALUES), 1);
        NativeCollectionIterator.Type.BOTH = new NativeCollectionIterator.Type(nameof (BOTH), 2);
        NativeCollectionIterator.Type.\u0024VALUES = new NativeCollectionIterator.Type[3]
        {
          NativeCollectionIterator.Type.KEYS,
          NativeCollectionIterator.Type.VALUES,
          NativeCollectionIterator.Type.BOTH
        };
      }
    }
  }
}
