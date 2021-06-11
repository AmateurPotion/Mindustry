// Decompiled with JetBrains decompiler
// Type: mindustry.mod.ModListing
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.mod
{
  public class ModListing : Object
  {
    public string repo;
    public string name;
    public string author;
    public string lastUpdated;
    public string description;
    public string minGameVersion;
    public bool hasScripts;
    public bool hasJava;
    public string[] contentTypes;
    public int stars;

    [LineNumberTable(new byte[] {159, 146, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ModListing()
    {
      ModListing modListing = this;
      this.contentTypes = new string[0];
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("ModListing{repo='").append(this.repo).append('\'').append(", name='").append(this.name).append('\'').append(", author='").append(this.author).append('\'').append(", lastUpdated='").append(this.lastUpdated).append('\'').append(", description='").append(this.description).append('\'').append(", minGameVersion='").append(this.minGameVersion).append('\'').append(", hasScripts=").append(this.hasScripts).append(", hasJava=").append(this.hasJava).append(", stars=").append(this.stars).append('}').toString();
  }
}
