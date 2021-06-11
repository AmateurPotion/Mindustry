// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Musics
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.audio;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.gen
{
  public class Musics : Object
  {
    public static Music game3;
    public static Music game8;
    public static Music menu;
    public static Music editor;
    public static Music game9;
    public static Music boss2;
    public static Music land;
    public static Music game5;
    public static Music game6;
    public static Music boss1;
    public static Music game4;
    public static Music game2;
    public static Music launch;
    public static Music game7;
    public static Music game1;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 179, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load()
    {
      Core.assets.load("music/game3.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon0();
      Core.assets.load("music/game8.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon1();
      Core.assets.load("music/menu.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon2();
      Core.assets.load("music/editor.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon3();
      Core.assets.load("music/game9.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon4();
      Core.assets.load("music/boss2.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon5();
      Core.assets.load("music/land.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon6();
      Core.assets.load("music/game5.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon7();
      Core.assets.load("music/game6.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon8();
      Core.assets.load("music/boss1.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon9();
      Core.assets.load("music/game4.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon10();
      Core.assets.load("music/game2.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon11();
      Core.assets.load("music/launch.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon12();
      Core.assets.load("music/game7.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon13();
      Core.assets.load("music/game1.mp3", (Class) ClassLiteral<Music>.Value).loaded = (Cons) new Musics.__\u003C\u003EAnon14();
    }

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00240([In] object obj0) => Musics.game3 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00241([In] object obj0) => Musics.game8 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00242([In] object obj0) => Musics.menu = (Music) obj0;

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00243([In] object obj0) => Musics.editor = (Music) obj0;

    [Modifiers]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00244([In] object obj0) => Musics.game9 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00245([In] object obj0) => Musics.boss2 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00246([In] object obj0) => Musics.land = (Music) obj0;

    [Modifiers]
    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00247([In] object obj0) => Musics.game5 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00248([In] object obj0) => Musics.game6 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u00249([In] object obj0) => Musics.boss1 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002410([In] object obj0) => Musics.game4 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002411([In] object obj0) => Musics.game2 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002412([In] object obj0) => Musics.launch = (Music) obj0;

    [Modifiers]
    [LineNumberTable(50)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002413([In] object obj0) => Musics.game7 = (Music) obj0;

    [Modifiers]
    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024load\u002414([In] object obj0) => Musics.game1 = (Music) obj0;

    [LineNumberTable(5)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Musics()
    {
    }

    [LineNumberTable(new byte[] {159, 141, 141, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Musics()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.gen.Musics"))
        return;
      Musics.game3 = new Music();
      Musics.game8 = new Music();
      Musics.menu = new Music();
      Musics.editor = new Music();
      Musics.game9 = new Music();
      Musics.boss2 = new Music();
      Musics.land = new Music();
      Musics.game5 = new Music();
      Musics.game6 = new Music();
      Musics.boss1 = new Music();
      Musics.game4 = new Music();
      Musics.game2 = new Music();
      Musics.launch = new Music();
      Musics.game7 = new Music();
      Musics.game1 = new Music();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00240(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00242(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00243(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00244(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00245(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00246(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00247(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00248(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u00249(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u002410(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u002411(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u002412(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u002413(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public void get([In] object obj0) => Musics.lambda\u0024load\u002414(obj0);
    }
  }
}
