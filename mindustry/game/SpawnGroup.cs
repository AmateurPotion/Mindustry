// Decompiled with JetBrains decompiler
// Type: mindustry.game.SpawnGroup
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using arc.util.serialization;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.ctype;
using mindustry.gen;
using mindustry.io.legacy;
using mindustry.type;
using System.Runtime.CompilerServices;

namespace mindustry.game
{
  public class SpawnGroup : Object, Json.JsonSerializable
  {
    public const int never = 2147483647;
    public UnitType type;
    public int end;
    public int begin;
    public int spacing;
    public int max;
    public float unitScaling;
    public float shields;
    public float shieldScaling;
    public int unitAmount;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public StatusEffect effect;
    [Nullable(new object[] {64, "Larc/util/Nullable;"})]
    public ItemStack items;

    [LineNumberTable(new byte[] {9, 111, 127, 13, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getSpawned(int wave)
    {
      if (this.spacing == 0)
        this.spacing = 1;
      if (wave >= this.begin && wave <= this.end)
      {
        int num1 = wave - this.begin;
        int spacing1 = this.spacing;
        if ((spacing1 != -1 ? num1 % spacing1 : 0) == 0)
        {
          int unitAmount = this.unitAmount;
          int num2 = wave - this.begin;
          int spacing2 = this.spacing;
          int num3 = ByteCodeHelper.f2i((spacing2 != -1 ? (float) (num2 / spacing2) : (float) -num2) / this.unitScaling);
          return Math.min(unitAmount + num3, this.max);
        }
      }
      return 0;
    }

    [LineNumberTable(new byte[] {26, 141, 104, 177, 104, 188, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Unit createUnit(Team team, int wave)
    {
      Unit unit = this.type.create(team);
      if (this.effect != null)
        unit.apply(this.effect, 999999f);
      if (this.items != null)
        unit.addItem(this.items.item, this.items.amount);
      unit.shield = this.getShield(wave);
      return unit;
    }

    [LineNumberTable(new byte[] {159, 191, 232, 40, 139, 203, 135, 136, 139, 139, 139, 231, 73, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpawnGroup(UnitType type)
    {
      SpawnGroup spawnGroup = this;
      this.type = UnitTypes.dagger;
      this.end = int.MaxValue;
      this.spacing = 1;
      this.max = 40;
      this.unitScaling = (float) int.MaxValue;
      this.shields = 0.0f;
      this.shieldScaling = 0.0f;
      this.unitAmount = 1;
      this.type = type;
    }

    [LineNumberTable(68)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getShield(int wave) => Math.max(this.shields + this.shieldScaling * (float) (wave - this.begin), 0.0f);

    [LineNumberTable(new byte[] {3, 232, 36, 139, 203, 135, 136, 139, 139, 139, 231, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SpawnGroup()
    {
      SpawnGroup spawnGroup = this;
      this.type = UnitTypes.dagger;
      this.end = int.MaxValue;
      this.spacing = 1;
      this.max = 40;
      this.unitScaling = (float) int.MaxValue;
      this.shields = 0.0f;
      this.shieldScaling = 0.0f;
      this.unitAmount = 1;
    }

    [LineNumberTable(new byte[] {43, 115, 118, 126, 127, 4, 127, 0, 127, 1, 127, 4, 127, 4, 127, 4, 127, 0, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(Json json)
    {
      if (this.type == null)
        this.type = UnitTypes.dagger;
      json.writeValue("type", (object) this.type.__\u003C\u003Ename);
      if (this.begin != 0)
        json.writeValue("begin", (object) Integer.valueOf(this.begin));
      if (this.end != int.MaxValue)
        json.writeValue("end", (object) Integer.valueOf(this.end));
      if (this.spacing != 1)
        json.writeValue("spacing", (object) Integer.valueOf(this.spacing));
      if (this.max != 40)
        json.writeValue("max", (object) Integer.valueOf(this.max));
      if ((double) this.unitScaling != 2147483648.0)
        json.writeValue("scaling", (object) Float.valueOf(this.unitScaling));
      if ((double) this.shields != 0.0)
        json.writeValue("shields", (object) Float.valueOf(this.shields));
      if ((double) this.shieldScaling != 0.0)
        json.writeValue("shieldScaling", (object) Float.valueOf(this.shieldScaling));
      if (this.unitAmount != 1)
        json.writeValue("amount", (object) Integer.valueOf(this.unitAmount));
      if (this.effect == null)
        return;
      json.writeValue("effect", (object) this.effect.__\u003C\u003Ename);
    }

    [LineNumberTable(new byte[] {58, 145, 127, 12, 115, 114, 118, 114, 115, 119, 119, 119, 178, 127, 15, 141, 159, 49})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read(Json json, JsonValue data)
    {
      string str = data.getString("type", "dagger");
      this.type = (UnitType) Vars.content.getByName(ContentType.__\u003C\u003Eunit, (string) LegacyIO.__\u003C\u003EunitMap.get((object) str, (object) str));
      if (this.type == null)
        this.type = UnitTypes.dagger;
      this.begin = data.getInt("begin", 0);
      this.end = data.getInt("end", int.MaxValue);
      this.spacing = data.getInt("spacing", 1);
      this.max = data.getInt("max", 40);
      this.unitScaling = data.getFloat("scaling", (float) int.MaxValue);
      this.shields = data.getFloat("shields", 0.0f);
      this.shieldScaling = data.getFloat("shieldScaling", 0.0f);
      this.unitAmount = data.getInt("amount", 1);
      if (data.has("effect") && data.get("effect").isNumber() && data.getInt("effect", -1) == 8)
        this.effect = StatusEffects.boss;
      else
        this.effect = (StatusEffect) Vars.content.getByName(ContentType.__\u003C\u003Estatus, !data.has("effect") || !data.get("effect").isString() ? "none" : data.getString("effect", "none"));
    }

    [LineNumberTable(131)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("SpawnGroup{type=").append((object) this.type).append(", end=").append(this.end).append(", begin=").append(this.begin).append(", spacing=").append(this.spacing).append(", max=").append(this.max).append(", unitScaling=").append(this.unitScaling).append(", unitAmount=").append(this.unitAmount).append(", effect=").append((object) this.effect).append(", items=").append((object) this.items).append('}').toString();

    [LineNumberTable(new byte[] {96, 107, 120, 103, 127, 49, 127, 13, 127, 40, 235, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (object.ReferenceEquals((object) this, o))
        return true;
      if (o == null || !object.ReferenceEquals((object) ((object) this).GetType(), (object) o.GetType()))
        return false;
      SpawnGroup spawnGroup = (SpawnGroup) o;
      return this.end == spawnGroup.end && this.begin == spawnGroup.begin && (this.spacing == spawnGroup.spacing && this.max == spawnGroup.max) && (Float.compare(spawnGroup.unitScaling, this.unitScaling) == 0 && Float.compare(spawnGroup.shields, this.shields) == 0 && (Float.compare(spawnGroup.shieldScaling, this.shieldScaling) == 0 && this.unitAmount == spawnGroup.unitAmount)) && (object.ReferenceEquals((object) this.type, (object) spawnGroup.type) && object.ReferenceEquals((object) this.effect, (object) spawnGroup.effect) && Structs.eq((object) this.items, (object) spawnGroup.items));
    }

    [LineNumberTable(157)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => Arrays.hashCode(new object[11]
    {
      (object) this.type,
      (object) Integer.valueOf(this.end),
      (object) Integer.valueOf(this.begin),
      (object) Integer.valueOf(this.spacing),
      (object) Integer.valueOf(this.max),
      (object) Float.valueOf(this.unitScaling),
      (object) Float.valueOf(this.shields),
      (object) Float.valueOf(this.shieldScaling),
      (object) Integer.valueOf(this.unitAmount),
      (object) this.effect,
      (object) this.items
    });
  }
}
