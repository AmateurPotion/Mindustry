// Decompiled with JetBrains decompiler
// Type: mindustry.core.GameState
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.game;
using mindustry.gen;
using mindustry.maps;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  public class GameState : Object
  {
    public int wave;
    public float wavetime;
    public bool gameOver;
    public bool serverPaused;
    public bool wasTimeout;
    public Map map;
    public Rules rules;
    public GameStats stats;
    public mindustry.world.blocks.Attributes envAttrs;
    public Teams teams;
    public int enemies;
    private GameState.State state;

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isGame() => !object.ReferenceEquals((object) this.state, (object) GameState.State.__\u003C\u003Emenu);

    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCampaign() => this.rules.sector != null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool @is(GameState.State astate) => object.ReferenceEquals((object) this.state, (object) astate);

    [LineNumberTable(new byte[] {159, 184, 154, 113, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void set(GameState.State astate)
    {
      if (object.ReferenceEquals((object) astate, (object) GameState.State.__\u003C\u003Epaused) && Vars.net.active())
        return;
      Events.fire((object) new EventType.StateChangeEvent(this.state, astate));
      this.state = astate;
    }

    [LineNumberTable(new byte[] {159, 156, 136, 199, 142, 139, 139, 139, 139, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GameState()
    {
      GameState gameState = this;
      this.wave = 1;
      this.gameOver = false;
      this.serverPaused = false;
      this.map = Vars.emptyMap;
      this.rules = new Rules();
      this.stats = new GameStats();
      this.envAttrs = new mindustry.world.blocks.Attributes();
      this.teams = new Teams();
      this.state = GameState.State.__\u003C\u003Emenu;
    }

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEditor() => this.rules.editor;

    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPlaying() => object.ReferenceEquals((object) this.state, (object) GameState.State.__\u003C\u003Eplaying) || object.ReferenceEquals((object) this.state, (object) GameState.State.__\u003C\u003Epaused) && !this.isPaused();

    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasSpawns() => this.rules.waves && (!this.isCampaign() || !this.rules.attackMode);

    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isMenu() => object.ReferenceEquals((object) this.state, (object) GameState.State.__\u003C\u003Emenu);

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPaused() => this.@is(GameState.State.__\u003C\u003Epaused) && !Vars.net.active() || this.gameOver && (!Vars.net.active() || this.isCampaign()) || this.serverPaused && !this.isMenu();

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Unit boss() => this.teams.boss;

    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasSector() => this.rules.sector != null;

    [LineNumberTable(63)]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Sector getSector() => this.rules.sector;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual GameState.State getState() => this.state;

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/core/GameState$State;>;")]
    [Modifiers]
    [Serializable]
    public sealed class State : Enum
    {
      [Modifiers]
      internal static GameState.State __\u003C\u003Epaused;
      [Modifiers]
      internal static GameState.State __\u003C\u003Eplaying;
      [Modifiers]
      internal static GameState.State __\u003C\u003Emenu;
      [Modifiers]
      private static GameState.State[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(95)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private State([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(95)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GameState.State[] values() => (GameState.State[]) GameState.State.\u0024VALUES.Clone();

      [LineNumberTable(95)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GameState.State valueOf(string name) => (GameState.State) Enum.valueOf((Class) ClassLiteral<GameState.State>.Value, name);

      [LineNumberTable(new byte[] {159, 118, 77, 63, 17})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static State()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.core.GameState$State"))
          return;
        GameState.State.__\u003C\u003Epaused = new GameState.State(nameof (paused), 0);
        GameState.State.__\u003C\u003Eplaying = new GameState.State(nameof (playing), 1);
        GameState.State.__\u003C\u003Emenu = new GameState.State(nameof (menu), 2);
        GameState.State.\u0024VALUES = new GameState.State[3]
        {
          GameState.State.__\u003C\u003Epaused,
          GameState.State.__\u003C\u003Eplaying,
          GameState.State.__\u003C\u003Emenu
        };
      }

      [Modifiers]
      public static GameState.State paused
      {
        [HideFromJava] get => GameState.State.__\u003C\u003Epaused;
      }

      [Modifiers]
      public static GameState.State playing
      {
        [HideFromJava] get => GameState.State.__\u003C\u003Eplaying;
      }

      [Modifiers]
      public static GameState.State menu
      {
        [HideFromJava] get => GameState.State.__\u003C\u003Emenu;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        paused,
        playing,
        menu,
      }
    }
  }
}
