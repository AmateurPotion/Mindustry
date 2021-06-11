// Decompiled with JetBrains decompiler
// Type: mindustry.game.Objectives
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.game
{
  public class Objectives : Object
  {
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Objectives()
    {
    }

    public interface Objective
    {
      bool complete();

      string display();

      [Modifiers]
      void build(Table table);

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static void \u003Cdefault\u003Ebuild([In] Objectives.Objective obj0, [In] Table obj1)
      {
      }

      [HideFromJava]
      static class __DefaultMethods
      {
        public static void build([In] Objectives.Objective obj0, [In] Table obj1)
        {
          Objectives.Objective objective = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(objective, ToString);
          Objectives.Objective.\u003Cdefault\u003Ebuild(objective, obj1);
        }
      }
    }

    public class Produce : Object, Objectives.Objective
    {
      public UnlockableContent content;

      [LineNumberTable(new byte[] {159, 176, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Produce(UnlockableContent content)
      {
        Objectives.Produce produce = this;
        this.content = content;
      }

      [LineNumberTable(38)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal Produce()
      {
      }

      [LineNumberTable(42)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool complete() => this.content.unlocked();

      [LineNumberTable(47)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string display() => Core.bundle.format("requirement.produce", (object) new StringBuilder().append(this.content.emoji()).append(" ").append(this.content.localizedName).toString());

      [HideFromJava]
      public virtual void build([In] Table obj0) => Objectives.Objective.\u003Cdefault\u003Ebuild((Objectives.Objective) this, obj0);
    }

    public class Research : Object, Objectives.Objective
    {
      public UnlockableContent content;

      [LineNumberTable(new byte[] {159, 156, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Research(UnlockableContent content)
      {
        Objectives.Research research = this;
        this.content = content;
      }

      [LineNumberTable(18)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal Research()
      {
      }

      [LineNumberTable(22)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool complete() => this.content.unlocked();

      [LineNumberTable(27)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string display() => Core.bundle.format("requirement.research", (object) new StringBuilder().append(this.content.emoji()).append(" ").append(this.content.localizedName).toString());

      [HideFromJava]
      public virtual void build([In] Table obj0) => Objectives.Objective.\u003Cdefault\u003Ebuild((Objectives.Objective) this, obj0);
    }

    public class SectorComplete : Object, Objectives.Objective
    {
      public SectorPreset preset;

      [LineNumberTable(new byte[] {4, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SectorComplete(SectorPreset zone)
      {
        Objectives.SectorComplete sectorComplete = this;
        this.preset = zone;
      }

      [LineNumberTable(58)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal SectorComplete()
      {
      }

      [LineNumberTable(62)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool complete() => this.preset.sector.save != null && (!this.preset.sector.isAttacked() || this.preset.sector.info.wasCaptured) && this.preset.sector.hasBase();

      [LineNumberTable(67)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string display() => Core.bundle.format("requirement.capture", (object) this.preset.localizedName);

      [HideFromJava]
      public virtual void build([In] Table obj0) => Objectives.Objective.\u003Cdefault\u003Ebuild((Objectives.Objective) this, obj0);
    }
  }
}
