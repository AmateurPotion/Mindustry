// Decompiled with JetBrains decompiler
// Type: mindustry.type.SectorPreset
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics.g2d;
using IKVM.Attributes;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.maps.generators;
using mindustry.ui;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.type
{
  public class SectorPreset : UnlockableContent
  {
    public FileMapGenerator generator;
    public Planet planet;
    public Sector sector;
    public int captureWave;
    [Signature("Larc/func/Cons<Lmindustry/game/Rules;>;")]
    public Cons rules;
    public bool useAI;
    public float difficulty;
    public bool addStartingItems;

    [Modifiers]
    [LineNumberTable(17)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] Rules obj0) => obj0.winWave = this.captureWave;

    [LineNumberTable(new byte[] {159, 166, 233, 56, 103, 113, 167, 199, 109, 103, 120, 119, 135, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SectorPreset(string name, Planet planet, int sector)
      : base(name)
    {
      SectorPreset sectorPreset = this;
      this.captureWave = 0;
      this.rules = (Cons) new SectorPreset.__\u003C\u003EAnon0(this);
      this.useAI = true;
      this.addStartingItems = false;
      this.generator = new FileMapGenerator(name, this);
      this.planet = planet;
      int num = sector;
      int size = planet.sectors.size;
      sector = size != -1 ? num % size : 0;
      this.sector = (Sector) planet.sectors.get(sector);
      this.inlineDescription = false;
      planet.preset(sector, this);
    }

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override TextureRegion icon(Cicon c) => Icon.terrain.getRegion();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isHidden() => this.description == null;

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Esector;

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly SectorPreset arg\u00241;

      internal __\u003C\u003EAnon0([In] SectorPreset obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240((Rules) obj0);
    }
  }
}
