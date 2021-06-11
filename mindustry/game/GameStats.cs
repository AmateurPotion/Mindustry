// Decompiled with JetBrains decompiler
// Type: mindustry.game.GameStats
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.math;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  public class GameStats : Object
  {
    [Signature("Larc/struct/ObjectIntMap<Lmindustry/type/Item;>;")]
    public ObjectIntMap itemsDelivered;
    public int enemyUnitsDestroyed;
    public int wavesLasted;
    public long timeLasted;
    public int buildingsBuilt;
    public int buildingsDeconstructed;
    public int buildingsDestroyed;

    [LineNumberTable(new byte[] {159, 151, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GameStats()
    {
      GameStats gameStats = this;
      this.itemsDelivered = new ObjectIntMap();
    }

    [LineNumberTable(new byte[] {159, 169, 134, 117, 104, 159, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GameStats.RankResult calculateRank(Sector sector)
    {
      float num = 0.0f;
      int index = Mathf.clamp(ByteCodeHelper.f2i(num), 0, GameStats.Rank.__\u003C\u003Eall.Length - 1);
      GameStats.Rank rank = GameStats.Rank.__\u003C\u003Eall[index];
      string str1;
      if ((double) Math.abs((float) index + 0.5f - num) >= 0.200000002980232)
      {
        string str2 = rank.name();
        object obj = (object) "S";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        if (!String.instancehelper_contains(str2, charSequence2))
        {
          str1 = (double) ((float) index + 0.5f) >= (double) num ? "+" : "-";
          goto label_4;
        }
      }
      str1 = "";
label_4:
      string modifier = str1;
      return new GameStats.RankResult(rank, modifier);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/game/GameStats$Rank;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Rank : Enum
    {
      [Modifiers]
      internal static GameStats.Rank __\u003C\u003EF;
      [Modifiers]
      internal static GameStats.Rank __\u003C\u003ED;
      [Modifiers]
      internal static GameStats.Rank __\u003C\u003EC;
      [Modifiers]
      internal static GameStats.Rank __\u003C\u003EB;
      [Modifiers]
      internal static GameStats.Rank __\u003C\u003EA;
      [Modifiers]
      internal static GameStats.Rank __\u003C\u003ES;
      [Modifiers]
      internal static GameStats.Rank __\u003C\u003ESS;
      internal static GameStats.Rank[] __\u003C\u003Eall;
      [Modifiers]
      private static GameStats.Rank[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Rank([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GameStats.Rank[] values() => (GameStats.Rank[]) GameStats.Rank.\u0024VALUES.Clone();

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GameStats.Rank valueOf(string name) => (GameStats.Rank) Enum.valueOf((Class) ClassLiteral<GameStats.Rank>.Value, name);

      [LineNumberTable(new byte[] {159, 130, 77, 63, 81, 191, 36})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Rank()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.game.GameStats$Rank"))
          return;
        GameStats.Rank.__\u003C\u003EF = new GameStats.Rank(nameof (F), 0);
        GameStats.Rank.__\u003C\u003ED = new GameStats.Rank(nameof (D), 1);
        GameStats.Rank.__\u003C\u003EC = new GameStats.Rank(nameof (C), 2);
        GameStats.Rank.__\u003C\u003EB = new GameStats.Rank(nameof (B), 3);
        GameStats.Rank.__\u003C\u003EA = new GameStats.Rank(nameof (A), 4);
        GameStats.Rank.__\u003C\u003ES = new GameStats.Rank(nameof (S), 5);
        GameStats.Rank.__\u003C\u003ESS = new GameStats.Rank(nameof (SS), 6);
        GameStats.Rank.\u0024VALUES = new GameStats.Rank[7]
        {
          GameStats.Rank.__\u003C\u003EF,
          GameStats.Rank.__\u003C\u003ED,
          GameStats.Rank.__\u003C\u003EC,
          GameStats.Rank.__\u003C\u003EB,
          GameStats.Rank.__\u003C\u003EA,
          GameStats.Rank.__\u003C\u003ES,
          GameStats.Rank.__\u003C\u003ESS
        };
        GameStats.Rank.__\u003C\u003Eall = GameStats.Rank.values();
      }

      [Modifiers]
      public static GameStats.Rank F
      {
        [HideFromJava] get => GameStats.Rank.__\u003C\u003EF;
      }

      [Modifiers]
      public static GameStats.Rank D
      {
        [HideFromJava] get => GameStats.Rank.__\u003C\u003ED;
      }

      [Modifiers]
      public static GameStats.Rank C
      {
        [HideFromJava] get => GameStats.Rank.__\u003C\u003EC;
      }

      [Modifiers]
      public static GameStats.Rank B
      {
        [HideFromJava] get => GameStats.Rank.__\u003C\u003EB;
      }

      [Modifiers]
      public static GameStats.Rank A
      {
        [HideFromJava] get => GameStats.Rank.__\u003C\u003EA;
      }

      [Modifiers]
      public static GameStats.Rank S
      {
        [HideFromJava] get => GameStats.Rank.__\u003C\u003ES;
      }

      [Modifiers]
      public static GameStats.Rank SS
      {
        [HideFromJava] get => GameStats.Rank.__\u003C\u003ESS;
      }

      [Modifiers]
      public static GameStats.Rank[] all
      {
        [HideFromJava] get => GameStats.Rank.__\u003C\u003Eall;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        F,
        D,
        C,
        B,
        A,
        S,
        SS,
      }
    }

    public class RankResult : Object
    {
      internal GameStats.Rank __\u003C\u003Erank;
      internal string __\u003C\u003Emodifier;

      [LineNumberTable(new byte[] {159, 183, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public RankResult(GameStats.Rank rank, string modifier)
      {
        GameStats.RankResult rankResult = this;
        this.__\u003C\u003Erank = rank;
        this.__\u003C\u003Emodifier = modifier;
      }

      [Modifiers]
      public GameStats.Rank rank
      {
        [HideFromJava] get => this.__\u003C\u003Erank;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Erank = value;
      }

      [Modifiers]
      public string modifier
      {
        [HideFromJava] get => this.__\u003C\u003Emodifier;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Emodifier = value;
      }
    }
  }
}
