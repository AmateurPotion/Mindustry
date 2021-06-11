// Decompiled with JetBrains decompiler
// Type: mindustry.audio.SoundControl
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.audio;
using arc.files;
using arc.func;
using arc.math;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.game;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.audio
{
  public class SoundControl : Object
  {
    protected internal const float finTime = 120f;
    protected internal const float foutTime = 120f;
    protected internal const float musicInterval = 10800f;
    protected internal const float musicChance = 0.6f;
    protected internal const float musicWaveChance = 0.46f;
    [Signature("Larc/struct/Seq<Larc/audio/Music;>;")]
    public Seq ambientMusic;
    [Signature("Larc/struct/Seq<Larc/audio/Music;>;")]
    public Seq darkMusic;
    [Signature("Larc/struct/Seq<Larc/audio/Music;>;")]
    public Seq bossMusic;
    protected internal Music lastRandomPlayed;
    protected internal Interval timer;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    protected internal Music current;
    protected internal float fade;
    protected internal bool silenced;
    protected internal AudioBus uiBus;
    protected internal bool wasPlaying;
    protected internal AudioFilter filter;
    [Signature("Larc/struct/ObjectMap<Larc/audio/Sound;Lmindustry/audio/SoundControl$SoundData;>;")]
    protected internal ObjectMap sounds;

    [LineNumberTable(new byte[] {11, 118, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setupFilters()
    {
      Core.audio.soundBus.setFilter(0, this.filter);
      Core.audio.soundBus.setFilterParam(0, 0, 0.0f);
    }

    [LineNumberTable(new byte[] {38, 136, 118, 134, 124, 111, 124, 111, 127, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loop(Sound sound, Position pos, float volume)
    {
      if (Vars.headless)
        return;
      float num1 = sound.calcFalloff(pos.getX(), pos.getY());
      float num2 = num1 * volume;
      SoundControl.SoundData soundData = (SoundControl.SoundData) this.sounds.get((object) sound, (Prov) new SoundControl.__\u003C\u003EAnon2());
      soundData.volume += num2;
      soundData.volume = Mathf.clamp(soundData.volume, 0.0f, 1f);
      soundData.total += num1;
      soundData.sum.add(pos.getX() * num1, pos.getY() * num1);
    }

    [LineNumberTable(new byte[] {160, 113, 104, 104, 176, 107, 193, 104, 223, 11, 104, 161, 139, 103, 108, 123, 107, 108, 145, 127, 6, 139, 159, 1, 141, 107, 103, 103, 131, 103, 123, 108, 107, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void play([Nullable(new object[] {64, "Larc/util/Nullable;"})] Music music)
    {
      if (!this.shouldPlay())
      {
        if (this.current != null)
          this.current.setVolume(0.0f);
        this.fade = 0.0f;
      }
      else
      {
        if (this.current != null)
          this.current.setVolume(this.fade * (float) Core.settings.getInt("musicvol") / 100f);
        if (this.silenced)
          return;
        if (this.current == null && music != null)
        {
          this.current = music;
          this.current.setLooping(true);
          Music current = this.current;
          SoundControl soundControl = this;
          float num1 = 0.0f;
          double num2 = (double) num1;
          this.fade = num1;
          current.setVolume((float) num2);
          this.current.play();
          this.silenced = false;
        }
        else if (object.ReferenceEquals((object) this.current, (object) music) && music != null)
        {
          this.fade = Mathf.clamp(this.fade + Time.delta / 120f);
        }
        else
        {
          if (this.current == null)
            return;
          this.fade = Mathf.clamp(this.fade - Time.delta / 120f);
          if ((double) this.fade > 0.00999999977648258)
            return;
          this.current.stop();
          this.current = (Music) null;
          this.silenced = true;
          if (music == null)
            return;
          this.current = music;
          Music current = this.current;
          SoundControl soundControl = this;
          float num1 = 0.0f;
          double num2 = (double) num1;
          this.fade = num1;
          current.setVolume((float) num2);
          this.current.setLooping(true);
          this.current.play();
          this.silenced = false;
        }
      }
    }

    [LineNumberTable(new byte[] {160, 184, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void silence() => this.play((Music) null);

    [LineNumberTable(new byte[] {160, 87, 104, 158, 156})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void playRandom()
    {
      if (this.isDark())
        this.playOnce((Music) this.darkMusic.random((object) this.lastRandomPlayed));
      else
        this.playOnce((Music) this.ambientMusic.random((object) this.lastRandomPlayed));
    }

    [LineNumberTable(new byte[] {117, 108, 107, 161, 154, 246, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void updateLoops()
    {
      if (!Vars.state.isGame())
        this.sounds.clear();
      else
        this.sounds.each((Cons2) new SoundControl.__\u003C\u003EAnon3((float) Core.settings.getInt("ambientvol", 100) / 100f));
    }

    [LineNumberTable(new byte[] {160, 96, 159, 44, 194, 127, 24, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool isDark() => Vars.state.teams.get(Vars.player.team()).hasCore() && (double) Vars.state.teams.get(Vars.player.team()).core().healthf() < 0.850000023841858 || Mathf.chance((double) ((float) (Math.log10((double) (((float) Vars.state.wave - 17f) / 19f)) + 1.0) / 4f)) || Mathf.chance((double) ((float) Vars.state.enemies / 70f + 0.1f));

    [LineNumberTable(new byte[] {160, 165, 180, 167, 107, 103, 112, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void playOnce(Music music)
    {
      if (this.current != null || music == null || !this.shouldPlay())
        return;
      this.lastRandomPlayed = music;
      this.fade = 1f;
      this.current = music;
      this.current.setVolume(1f);
      this.current.setLooping(false);
      this.current.play();
    }

    [LineNumberTable(293)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool shouldPlay() => Core.settings.getInt("musicvol") > 0;

    [LineNumberTable(new byte[] {16, 103, 107, 127, 26, 127, 18, 191, 18, 127, 15, 113, 119, 140, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void reload()
    {
      this.current = (Music) null;
      this.fade = 0.0f;
      this.ambientMusic = Seq.with((object[]) new Music[5]
      {
        Musics.game1,
        Musics.game3,
        Musics.game6,
        Musics.game8,
        Musics.game9
      });
      this.darkMusic = Seq.with((object[]) new Music[4]
      {
        Musics.game2,
        Musics.game5,
        Musics.game7,
        Musics.game4
      });
      this.bossMusic = Seq.with((object[]) new Music[4]
      {
        Musics.boss1,
        Musics.boss2,
        Musics.game2,
        Musics.game5
      });
      Iterator iterator = Core.assets.getAll((Class) ClassLiteral<Sound>.Value, new Seq()).iterator();
      while (iterator.hasNext())
      {
        Sound sound = (Sound) iterator.next();
        if (String.instancehelper_equals(Fi.get(Core.assets.getAssetFileName((object) sound)).parent().name(), (object) "ui"))
          sound.setBus(this.uiBus);
      }
    }

    [Modifiers]
    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] EventType.ClientLoadEvent obj0) => this.reload();

    [Modifiers]
    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] EventType.WaveEvent obj0) => Time.run(Mathf.random(8f, 15f) * 60f, (Runnable) new SoundControl.__\u003C\u003EAnon4(this));

    [Modifiers]
    [LineNumberTable(new byte[] {125, 159, 2, 110, 127, 40, 123, 99, 120, 179, 109, 102, 103, 129, 183, 107, 107, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024updateLoops\u00244(
      [In] float obj0,
      [In] Sound obj1,
      [In] SoundControl.SoundData obj2)
    {
      obj2.curVolume = Mathf.lerpDelta(obj2.curVolume, obj2.volume * obj0, 0.2f);
      int num = (double) obj2.curVolume > 0.00999999977648258 ? 1 : 0;
      float pan = !Mathf.zero(obj2.total, 0.0001f) ? obj1.calcPan(obj2.sum.x / obj2.total, obj2.sum.y / obj2.total) : 0.0f;
      if (obj2.soundID <= 0 || !Core.audio.isPlaying(obj2.soundID))
      {
        if (num != 0)
        {
          obj2.soundID = obj1.loop(obj2.curVolume, 1f, pan);
          Core.audio.protect(obj2.soundID, true);
        }
      }
      else
      {
        if ((double) obj2.curVolume <= 1.0 / 1000.0)
        {
          obj1.stop();
          obj2.soundID = -1;
          return;
        }
        Core.audio.set(obj2.soundID, pan, obj2.curVolume);
      }
      obj2.volume = 0.0f;
      obj2.total = 0.0f;
      obj2.sum.setZero();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 190, 159, 0, 99, 126, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242()
    {
      if (Vars.state.rules.spawns.contains((Boolf) new SoundControl.__\u003C\u003EAnon5()))
      {
        this.playOnce((Music) this.bossMusic.random((object) this.lastRandomPlayed));
      }
      else
      {
        if (!Mathf.chance(0.46000000834465))
          return;
        this.playRandom();
      }
    }

    [Modifiers]
    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00241([In] SpawnGroup obj0) => obj0.getSpawned(Vars.state.wave - 2) > 0 && object.ReferenceEquals((object) obj0.effect, (object) StatusEffects.boss);

    [LineNumberTable(new byte[] {159, 185, 232, 44, 145, 145, 177, 236, 69, 139, 204, 171, 181, 245, 74, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SoundControl()
    {
      SoundControl soundControl = this;
      this.ambientMusic = Seq.with((object[]) new Music[0]);
      this.darkMusic = Seq.with((object[]) new Music[0]);
      this.bossMusic = Seq.with((object[]) new Music[0]);
      this.timer = new Interval(4);
      this.uiBus = new AudioBus();
      this.filter = (AudioFilter) new SoundControl.\u0031(this);
      this.sounds = new ObjectMap();
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new SoundControl.__\u003C\u003EAnon0(this));
      Events.on((Class) ClassLiteral<EventType.WaveEvent>.Value, (Cons) new SoundControl.__\u003C\u003EAnon1(this));
      this.setupFilters();
    }

    [LineNumberTable(new byte[] {32, 136, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void loop(Sound sound, float volume)
    {
      if (Vars.headless)
        return;
      this.loop(sound, (Position) Core.camera.__\u003C\u003Eposition, volume);
    }

    [LineNumberTable(new byte[] {51, 103, 104, 107, 103, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void stop()
    {
      this.silenced = true;
      if (this.current == null)
        return;
      this.current.stop();
      this.current = (Music) null;
      this.fade = 0.0f;
    }

    [LineNumberTable(new byte[] {61, 125, 171, 117, 103, 203, 115, 223, 6, 105, 135, 99, 111, 136, 207, 108, 103, 113, 112, 113, 141, 141, 113, 103, 173, 166, 146, 112, 230, 69, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      int num1 = !Vars.state.isGame() || !Core.scene.hasDialog() ? 0 : 1;
      int num2 = Vars.state.isGame() ? 1 : 0;
      if (this.current != null && !this.current.isPlaying())
      {
        this.current = (Music) null;
        this.fade = 0.0f;
      }
      if (this.timer.get(1, 30f))
        Core.audio.soundBus.fadeFilterParam(0, 0, num1 == 0 ? 0.0f : 1f, 0.4f);
      if (num2 != (this.wasPlaying ? 1 : 0))
      {
        this.wasPlaying = num2 != 0;
        if (num2 != 0)
        {
          Core.audio.soundBus.play();
          this.setupFilters();
        }
        else
          Core.audio.soundBus.replay();
      }
      if (Vars.state.isMenu())
      {
        this.silenced = false;
        if (Vars.ui.planet.isShown())
          this.play(Musics.launch);
        else if (Vars.ui.editor.isShown())
          this.play(Musics.editor);
        else
          this.play(Musics.menu);
      }
      else if (Vars.state.rules.editor)
      {
        this.silenced = false;
        this.play(Musics.editor);
      }
      else
      {
        this.silence();
        if (this.timer.get(10800f) && Mathf.chance(0.600000023841858))
          this.playRandom();
      }
      this.updateLoops();
    }

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0031 : Filters.BiquadFilter
    {
      [Modifiers]
      internal SoundControl this\u00240;

      [LineNumberTable(new byte[] {159, 179, 111, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] SoundControl obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        SoundControl.\u0031 obj = this;
        this.set(0, 500f, 1f);
      }
    }

    [InnerClass]
    public class SoundData : Object
    {
      internal float volume;
      internal float total;
      internal Vec2 sum;
      internal int soundID;
      internal float curVolume;

      [LineNumberTable(new byte[] {160, 187, 168})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal SoundData()
      {
        SoundControl.SoundData soundData = this;
        this.sum = new Vec2();
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly SoundControl arg\u00241;

      internal __\u003C\u003EAnon0([In] SoundControl obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly SoundControl arg\u00241;

      internal __\u003C\u003EAnon1([In] SoundControl obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243((EventType.WaveEvent) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Prov
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public object get() => (object) new SoundControl.SoundData();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons2
    {
      private readonly float arg\u00241;

      internal __\u003C\u003EAnon3([In] float obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => SoundControl.lambda\u0024updateLoops\u00244(this.arg\u00241, (Sound) obj0, (SoundControl.SoundData) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly SoundControl arg\u00241;

      internal __\u003C\u003EAnon4([In] SoundControl obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public bool get([In] object obj0) => (SoundControl.lambda\u0024new\u00241((SpawnGroup) obj0) ? 1 : 0) != 0;
    }
  }
}
