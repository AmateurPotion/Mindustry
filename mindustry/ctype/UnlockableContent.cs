// Decompiled with JetBrains decompiler
// Type: mindustry.ctype.UnlockableContent
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics.g2d;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.content;
using mindustry.game;
using mindustry.graphics;
using mindustry.type;
using mindustry.ui;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.ctype
{
  public abstract class UnlockableContent : MappableContent
  {
    public Stats stats;
    public string localizedName;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public string description;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public string details;
    public bool alwaysUnlocked;
    public bool inlineDescription;
    public int iconId;
    protected internal TextureRegion[] cicons;
    protected internal bool unlocked;

    [LineNumberTable(new byte[] {97, 127, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool unlocked() => Vars.net != null && Vars.net.client() ? this.unlocked || this.alwaysUnlocked || Vars.state.rules.researched.contains((object) this.__\u003C\u003Ename) : this.unlocked || this.alwaysUnlocked;

    [LineNumberTable(165)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool locked() => !this.unlocked();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isHidden() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setStats()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onUnlock()
    {
    }

    [LineNumberTable(new byte[] {159, 181, 233, 47, 235, 70, 135, 135, 135, 241, 71, 127, 43, 127, 37, 127, 37, 127, 30})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public UnlockableContent(string name)
      : base(name)
    {
      UnlockableContent unlockableContent = this;
      this.stats = new Stats();
      this.alwaysUnlocked = false;
      this.inlineDescription = true;
      this.iconId = 0;
      this.cicons = new TextureRegion[Cicon.__\u003C\u003Eall.Length];
      this.localizedName = Core.bundle.get(new StringBuilder().append((object) this.getContentType()).append(".").append(this.__\u003C\u003Ename).append(".name").toString(), this.__\u003C\u003Ename);
      this.description = Core.bundle.getOrNull(new StringBuilder().append((object) this.getContentType()).append(".").append(this.__\u003C\u003Ename).append(".description").toString());
      this.details = Core.bundle.getOrNull(new StringBuilder().append((object) this.getContentType()).append(".").append(this.__\u003C\u003Ename).append(".details").toString());
      this.unlocked = Core.settings != null && Core.settings.getBool(new StringBuilder().append(this.__\u003C\u003Ename).append("-unlocked").toString(), false);
    }

    [LineNumberTable(49)]
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TechTree.TechNode node() => TechTree.get(this);

    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string displayDescription()
    {
      if (this.minfo.mod == null)
        return this.description;
      return new StringBuilder().append(this.description).append("\n").append(Core.bundle.format("mod.display", (object) this.minfo.mod.__\u003C\u003Emeta.displayName())).toString();
    }

    [LineNumberTable(new byte[] {8, 109, 102, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void checkStats()
    {
      if (this.stats.intialized)
        return;
      this.setStats();
      this.stats.intialized = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void createIcons(MultiPacker packer)
    {
    }

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ItemStack[] researchRequirements() => ItemStack.__\u003C\u003Eempty;

    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string emoji() => Fonts.getUnicodeStr(this.__\u003C\u003Ename);

    [LineNumberTable(new byte[] {35, 114, 119, 127, 42, 127, 52, 191, 42, 127, 46, 37, 37, 37, 37, 37, 37, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual TextureRegion icon(Cicon icon)
    {
      if (this.cicons[icon.ordinal()] == null)
        this.cicons[icon.ordinal()] = Core.atlas.find(new StringBuilder().append(this.getContentType().name()).append("-").append(this.__\u003C\u003Ename).append("-").append(icon.name()).toString(), Core.atlas.find(new StringBuilder().append(this.getContentType().name()).append("-").append(this.__\u003C\u003Ename).append("-full").toString(), Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-").append(icon.name()).toString(), Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("-full").toString(), Core.atlas.find(this.__\u003C\u003Ename, Core.atlas.find(new StringBuilder().append(this.getContentType().name()).append("-").append(this.__\u003C\u003Ename).toString(), (TextureRegion) Core.atlas.find(new StringBuilder().append(this.__\u003C\u003Ename).append("1").toString())))))));
      return this.cicons[icon.ordinal()];
    }

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Cicon prefDatabaseIcon() => Cicon.__\u003C\u003Exlarge;

    [Signature("(Larc/func/Cons<Lmindustry/ctype/UnlockableContent;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getDependencies(Cons cons)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void display(Table table)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool showUnlock() => true;

    [LineNumberTable(new byte[] {79, 112, 103, 159, 16, 102, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void unlock()
    {
      if (this.unlocked || this.alwaysUnlocked)
        return;
      this.unlocked = true;
      Core.settings.put(new StringBuilder().append(this.__\u003C\u003Ename).append("-unlocked").toString(), (object) Boolean.valueOf(true));
      this.onUnlock();
      Events.fire((object) new EventType.UnlockEvent(this));
    }

    [LineNumberTable(new byte[] {90, 104, 103, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void quietUnlock()
    {
      if (this.unlocked())
        return;
      this.unlocked = true;
      Core.settings.put(new StringBuilder().append(this.__\u003C\u003Ename).append("-unlocked").toString(), (object) Boolean.valueOf(true));
    }

    [LineNumberTable(new byte[] {103, 104, 103, 159, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearUnlock()
    {
      if (!this.unlocked)
        return;
      this.unlocked = false;
      Core.settings.put(new StringBuilder().append(this.__\u003C\u003Ename).append("-unlocked").toString(), (object) Boolean.valueOf(false));
    }

    [LineNumberTable(161)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool unlockedNow() => this.unlocked() || !Vars.state.isCampaign();
  }
}
