// Decompiled with JetBrains decompiler
// Type: mindustry.io.SaveMeta
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.game;
using mindustry.maps;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.io
{
  public class SaveMeta : Object
  {
    public int version;
    public int build;
    public long timestamp;
    public long timePlayed;
    public Map map;
    public int wave;
    public Rules rules;
    public StringMap tags;
    public string[] mods;

    [Modifiers]
    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00240([In] string obj0, [In] Map obj1) => String.instancehelper_equals(obj1.name(), (object) obj0);

    [LineNumberTable(new byte[] {159, 162, 104, 103, 104, 103, 103, 127, 7, 104, 104, 104, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SaveMeta(
      int version,
      long timestamp,
      long timePlayed,
      int build,
      string map,
      int wave,
      Rules rules,
      StringMap tags)
    {
      SaveMeta saveMeta = this;
      this.version = version;
      this.build = build;
      this.timestamp = timestamp;
      this.timePlayed = timePlayed;
      this.map = (Map) Vars.maps.all().find((Boolf) new SaveMeta.__\u003C\u003EAnon0(map));
      this.wave = wave;
      this.rules = rules;
      this.tags = tags;
      this.mods = (string[]) JsonIO.read((Class) ClassLiteral<string[]>.Value, (string) tags.get((object) nameof (mods), (object) "[]"));
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon0([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (SaveMeta.lambda\u0024new\u00240(this.arg\u00241, (Map) obj0) ? 1 : 0) != 0;
    }
  }
}
