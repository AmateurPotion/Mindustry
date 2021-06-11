// Decompiled with JetBrains decompiler
// Type: arc.Events
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc
{
  public class Events : Object
  {
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Object;Larc/struct/Seq<Larc/func/Cons<*>;>;>;")]
    private static ObjectMap events;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(TT;)V")]
    [LineNumberTable(new byte[] {159, 167, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void fire(object type) => Events.fire(Object.instancehelper_getClass(type), type);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 155, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void on(Class type, Cons listener) => ((Seq) Events.events.get((object) type, (Prov) new Events.__\u003C\u003EAnon0())).add((object) listener);

    [LineNumberTable(new byte[] {159, 159, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void run(object type, Runnable listener) => ((Seq) Events.events.get(type, (Prov) new Events.__\u003C\u003EAnon0())).add((object) new Events.__\u003C\u003EAnon1(listener));

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<*>;TT;)V")]
    [LineNumberTable(new byte[] {159, 171, 127, 14, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void fire(Class ctype, object type)
    {
      if (Events.events.get(type) != null)
        ((Seq) Events.events.get(type)).each((Cons) new Events.__\u003C\u003EAnon2(type));
      if (Events.events.get((object) ctype) == null)
        return;
      ((Seq) Events.events.get((object) ctype)).each((Cons) new Events.__\u003C\u003EAnon3(type));
    }

    [Modifiers]
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024run\u00240([In] Runnable obj0, [In] object obj1) => obj0.run();

    [Modifiers]
    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024fire\u00241([In] object obj0, [In] Cons obj1) => obj1.get(obj0);

    [Modifiers]
    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024fire\u00242([In] object obj0, [In] Cons obj1) => obj1.get(obj0);

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Events()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/func/Cons<TT;>;)V")]
    [LineNumberTable(new byte[] {159, 163, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void remove(Class type, Cons listener) => ((Seq) Events.events.get((object) type, (Prov) new Events.__\u003C\u003EAnon0())).remove((object) listener);

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Events()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.Events"))
        return;
      Events.events = new ObjectMap();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Seq();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Runnable arg\u00241;

      internal __\u003C\u003EAnon1([In] Runnable obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Events.lambda\u0024run\u00240(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly object arg\u00241;

      internal __\u003C\u003EAnon2([In] object obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Events.lambda\u0024fire\u00241(this.arg\u00241, (Cons) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly object arg\u00241;

      internal __\u003C\u003EAnon3([In] object obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Events.lambda\u0024fire\u00242(this.arg\u00241, (Cons) obj0);
    }
  }
}
