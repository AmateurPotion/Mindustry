// Decompiled with JetBrains decompiler
// Type: mindustry.net.Registrator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class Registrator : Object
  {
    [Modifiers]
    private static Registrator.ClassEntry[] classes;
    [Modifiers]
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/Class<*>;>;")]
    private static ObjectIntMap ids;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("(Ljava/lang/Class<*>;)B")]
    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte getID(Class type) => (byte) Registrator.ids.get((object) type, -1);

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Registrator.ClassEntry getByID(byte id)
    {
      int index = (int) (sbyte) id;
      return Registrator.classes[index];
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Registrator()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Registrator.ClassEntry[] getClasses() => Registrator.classes;

    [LineNumberTable(new byte[] {159, 140, 77, 255, 95, 71, 170, 122, 107, 55, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Registrator()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.net.Registrator"))
        return;
      Registrator.classes = new Registrator.ClassEntry[5]
      {
        new Registrator.ClassEntry((Class) ClassLiteral<Packets.StreamBegin>.Value, (Prov) new Registrator.__\u003C\u003EAnon0()),
        new Registrator.ClassEntry((Class) ClassLiteral<Packets.StreamChunk>.Value, (Prov) new Registrator.__\u003C\u003EAnon1()),
        new Registrator.ClassEntry((Class) ClassLiteral<Packets.WorldStream>.Value, (Prov) new Registrator.__\u003C\u003EAnon2()),
        new Registrator.ClassEntry((Class) ClassLiteral<Packets.ConnectPacket>.Value, (Prov) new Registrator.__\u003C\u003EAnon3()),
        new Registrator.ClassEntry((Class) ClassLiteral<Packets.InvokePacket>.Value, (Prov) new Registrator.__\u003C\u003EAnon4())
      };
      Registrator.ids = new ObjectIntMap();
      if (Registrator.classes.Length > (int) sbyte.MaxValue)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Can't have more than 127 registered classes!");
      }
      for (int index = 0; index < Registrator.classes.Length; ++index)
        Registrator.ids.put((object) Registrator.classes[index].__\u003C\u003Etype, index);
    }

    public class ClassEntry : Object
    {
      [Signature("Ljava/lang/Class<*>;")]
      internal Class __\u003C\u003Etype;
      [Signature("Larc/func/Prov<*>;")]
      internal Prov __\u003C\u003Econstructor;

      [Signature("<T::Lmindustry/net/Packet;>(Ljava/lang/Class<TT;>;Larc/func/Prov<TT;>;)V")]
      [LineNumberTable(new byte[] {159, 182, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ClassEntry(Class type, Prov constructor)
      {
        Registrator.ClassEntry classEntry = this;
        this.__\u003C\u003Etype = type;
        this.__\u003C\u003Econstructor = constructor;
      }

      [Modifiers]
      public Class type
      {
        [HideFromJava] get => this.__\u003C\u003Etype;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etype = value;
      }

      [Modifiers]
      public Prov constructor
      {
        [HideFromJava] get => this.__\u003C\u003Econstructor;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Econstructor = value;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new Packets.StreamBegin();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Prov
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get() => (object) new Packets.StreamChunk();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new Packets.WorldStream();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Prov
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get() => (object) new Packets.ConnectPacket();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Prov
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get() => (object) new Packets.InvokePacket();
    }
  }
}
