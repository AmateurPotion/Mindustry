// Decompiled with JetBrains decompiler
// Type: mindustry.game.Gamemode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.maps;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  [Signature("Ljava/lang/Enum<Lmindustry/game/Gamemode;>;")]
  [Modifiers]
  [Serializable]
  public sealed class Gamemode : Enum
  {
    [Modifiers]
    internal static Gamemode __\u003C\u003Esurvival;
    [Modifiers]
    internal static Gamemode __\u003C\u003Esandbox;
    [Modifiers]
    internal static Gamemode __\u003C\u003Eattack;
    [Modifiers]
    internal static Gamemode __\u003C\u003Epvp;
    [Modifiers]
    internal static Gamemode __\u003C\u003Eeditor;
    [Modifiers]
    [Signature("Larc/func/Cons<Lmindustry/game/Rules;>;")]
    private Cons rules;
    [Modifiers]
    [Signature("Larc/func/Boolf<Lmindustry/maps/Map;>;")]
    private Boolf validator;
    internal bool __\u003C\u003Ehidden;
    internal static Gamemode[] __\u003C\u003Eall;
    [Modifiers]
    private static Gamemode[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Gamemode valueOf(string name) => (Gamemode) Enum.valueOf((Class) ClassLiteral<Gamemode>.Value, name);

    [LineNumberTable(new byte[] {20, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rules apply(Rules @in)
    {
      this.rules.get((object) @in);
      return @in;
    }

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool valid(Map map) => this.validator.get((object) map);

    [Signature("(ZLarc/func/Cons<Lmindustry/game/Rules;>;)V")]
    [LineNumberTable(new byte[] {159, 129, 162, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Gamemode([In] string obj0, [In] int obj1, [In] bool obj2, [In] Cons obj3)
    {
      int num = obj2 ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(obj0, obj1, num != 0, obj3, (Boolf) new Gamemode.__\u003C\u003EAnon0());
      GC.KeepAlive((object) this);
    }

    [Signature("(ZLarc/func/Cons<Lmindustry/game/Rules;>;Larc/func/Boolf<Lmindustry/maps/Map;>;)V")]
    [LineNumberTable(new byte[] {159, 127, 130, 106, 104, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Gamemode([In] string obj0, [In] int obj1, [In] bool obj2, [In] Cons obj3, [In] Boolf obj4)
    {
      int num = obj2 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector(obj0, obj1);
      Gamemode gamemode = this;
      this.rules = obj3;
      this.__\u003C\u003Ehidden = num != 0;
      this.validator = obj4;
      GC.KeepAlive((object) this);
    }

    [Signature("(Larc/func/Cons<Lmindustry/game/Rules;>;Larc/func/Boolf<Lmindustry/maps/Map;>;)V")]
    [LineNumberTable(new byte[] {9, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Gamemode([In] string obj0, [In] int obj1, [In] Cons obj2, [In] Boolf obj3)
      : this(obj0, obj1, false, obj2, obj3)
    {
      GC.KeepAlive((object) this);
    }

    [Signature("(Larc/func/Cons<Lmindustry/game/Rules;>;)V")]
    [LineNumberTable(new byte[] {1, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Gamemode([In] string obj0, [In] int obj1, [In] Cons obj2)
      : this(obj0, obj1, false, obj2)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Gamemode[] values() => (Gamemode[]) Gamemode.\u0024VALUES.Clone();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00248([In] Map obj0) => true;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 154, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00240([In] Rules obj0)
    {
      obj0.waveTimer = true;
      obj0.waves = true;
    }

    [Modifiers]
    [LineNumberTable(14)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00241([In] Map obj0) => obj0.spawns > 0;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 158, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00242([In] Rules obj0)
    {
      obj0.infiniteResources = true;
      obj0.waves = true;
      obj0.waveTimer = false;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 163, 103, 103, 135, 115, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00243([In] Rules obj0)
    {
      obj0.attackMode = true;
      obj0.waves = true;
      obj0.waveTimer = true;
      obj0.waveSpacing /= 2f;
      obj0.teams.get(obj0.waveTeam).infiniteResources = true;
    }

    [Modifiers]
    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00244([In] Map obj0) => obj0.teams.contains(Vars.state.rules.waveTeam.__\u003C\u003Eid);

    [Modifiers]
    [LineNumberTable(new byte[] {159, 171, 103, 107, 107, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00245([In] Rules obj0)
    {
      obj0.pvp = true;
      obj0.enemyCoreBuildRadius = 600f;
      obj0.buildCostMultiplier = 1f;
      obj0.buildSpeedMultiplier = 1f;
      obj0.unitBuildSpeedMultiplier = 2f;
      obj0.attackMode = true;
    }

    [Modifiers]
    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024static\u00246([In] Map obj0) => obj0.teams.size > 1;

    [Modifiers]
    [LineNumberTable(new byte[] {159, 179, 103, 103, 103, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024static\u00247([In] Rules obj0)
    {
      obj0.infiniteResources = true;
      obj0.editor = true;
      obj0.waves = false;
      obj0.enemyCoreBuildRadius = 0.0f;
      obj0.waveTimer = false;
    }

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string description() => Core.bundle.get(new StringBuilder().append("mode.").append(this.name()).append(".description").toString());

    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Core.bundle.get(new StringBuilder().append("mode.").append(this.name()).append(".name").toString());

    [LineNumberTable(new byte[] {159, 140, 173, 223, 5, 250, 69, 255, 5, 72, 255, 5, 72, 251, 38, 255, 20, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Gamemode()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.game.Gamemode"))
        return;
      Gamemode.__\u003C\u003Esurvival = new Gamemode(nameof (survival), 0, (Cons) new Gamemode.__\u003C\u003EAnon1(), (Boolf) new Gamemode.__\u003C\u003EAnon2());
      Gamemode.__\u003C\u003Esandbox = new Gamemode(nameof (sandbox), 1, (Cons) new Gamemode.__\u003C\u003EAnon3());
      Gamemode.__\u003C\u003Eattack = new Gamemode(nameof (attack), 2, (Cons) new Gamemode.__\u003C\u003EAnon4(), (Boolf) new Gamemode.__\u003C\u003EAnon5());
      Gamemode.__\u003C\u003Epvp = new Gamemode(nameof (pvp), 3, (Cons) new Gamemode.__\u003C\u003EAnon6(), (Boolf) new Gamemode.__\u003C\u003EAnon7());
      Gamemode.__\u003C\u003Eeditor = new Gamemode(nameof (editor), 4, true, (Cons) new Gamemode.__\u003C\u003EAnon8());
      Gamemode.\u0024VALUES = new Gamemode[5]
      {
        Gamemode.__\u003C\u003Esurvival,
        Gamemode.__\u003C\u003Esandbox,
        Gamemode.__\u003C\u003Eattack,
        Gamemode.__\u003C\u003Epvp,
        Gamemode.__\u003C\u003Eeditor
      };
      Gamemode.__\u003C\u003Eall = Gamemode.values();
    }

    [Modifiers]
    public static Gamemode survival
    {
      [HideFromJava] get => Gamemode.__\u003C\u003Esurvival;
    }

    [Modifiers]
    public static Gamemode sandbox
    {
      [HideFromJava] get => Gamemode.__\u003C\u003Esandbox;
    }

    [Modifiers]
    public static Gamemode attack
    {
      [HideFromJava] get => Gamemode.__\u003C\u003Eattack;
    }

    [Modifiers]
    public static Gamemode pvp
    {
      [HideFromJava] get => Gamemode.__\u003C\u003Epvp;
    }

    [Modifiers]
    public static Gamemode editor
    {
      [HideFromJava] get => Gamemode.__\u003C\u003Eeditor;
    }

    [Modifiers]
    public bool hidden
    {
      [HideFromJava] get => this.__\u003C\u003Ehidden;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Ehidden = value;
    }

    [Modifiers]
    public static Gamemode[] all
    {
      [HideFromJava] get => Gamemode.__\u003C\u003Eall;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      survival,
      sandbox,
      attack,
      pvp,
      editor,
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (Gamemode.lambda\u0024new\u00248((Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => Gamemode.lambda\u0024static\u00240((Rules) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (Gamemode.lambda\u0024static\u00241((Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => Gamemode.lambda\u0024static\u00242((Rules) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public void get([In] object obj0) => Gamemode.lambda\u0024static\u00243((Rules) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public bool get([In] object obj0) => (Gamemode.lambda\u0024static\u00244((Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void get([In] object obj0) => Gamemode.lambda\u0024static\u00245((Rules) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Boolf
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public bool get([In] object obj0) => (Gamemode.lambda\u0024static\u00246((Map) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void get([In] object obj0) => Gamemode.lambda\u0024static\u00247((Rules) obj0);
    }
  }
}
