// Decompiled with JetBrains decompiler
// Type: arc.struct.StringMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.@struct
{
  [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;")]
  public class StringMap : ObjectMap
  {
    [LineNumberTable(new byte[] {159, 160, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringMap()
    {
    }

    [LineNumberTable(new byte[] {159, 151, 134, 105, 61, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static StringMap of(params object[] values)
    {
      StringMap stringMap = new StringMap();
      for (int index = 0; index < values.Length / 2; ++index)
        stringMap.put((object) (string) values[index * 2], (object) String.valueOf(values[index * 2 + 1]));
      return stringMap;
    }

    [Signature("(Larc/struct/ObjectMap<+Ljava/lang/String;+Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {159, 165, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public StringMap(ObjectMap map)
      : base(map)
    {
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(string name) => this.getInt(name, 0);

    [LineNumberTable(39)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getLong(string name) => this.getLong(name, 0L);

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFloat(string name, float def) => this.containsKey((object) name) ? Strings.parseFloat((string) this.get((object) name), def) : def;

    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(string name, int def) => this.containsKey((object) name) ? Strings.parseInt((string) this.get((object) name), def) : def;

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getLong(string name, long def) => this.containsKey((object) name) ? Strings.parseLong((string) this.get((object) name), def) : def;

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getBool(string name) => String.instancehelper_equals((string) this.get((object) name, (object) ""), (object) "true");

    [LineNumberTable(35)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFloat(string name) => this.getFloat(name, 0.0f);
  }
}
