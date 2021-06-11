// Decompiled with JetBrains decompiler
// Type: mindustry.io.JsonIO
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using mindustry.content;
using mindustry.ctype;
using mindustry.game;
using mindustry.type;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.io
{
  public class JsonIO : Object
  {
    [Modifiers]
    private static JsonIO.CustomJson jsonBase;
    internal static Json __\u003C\u003Ejson;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(TT;TT;)TT;")]
    [LineNumberTable(new byte[] {159, 190, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object copy(object @object, object dest)
    {
      JsonIO.__\u003C\u003Ejson.copyFields(@object, dest);
      return dest;
    }

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string write(object @object) => JsonIO.__\u003C\u003Ejson.toJson(@object, Object.instancehelper_getClass(@object));

    [Signature("<T:Ljava/lang/Object;>(TT;)TT;")]
    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object copy(object @object) => JsonIO.read(Object.instancehelper_getClass(@object), JsonIO.write(@object));

    [LineNumberTable(new byte[] {19, 117, 213, 240, 78, 240, 76, 240, 78, 240, 78, 240, 76, 240, 77, 240, 76, 240, 76, 240, 79, 240, 78})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void apply([In] Json obj0)
    {
      obj0.setElementType((Class) ClassLiteral<Rules>.Value, "spawns", (Class) ClassLiteral<SpawnGroup>.Value);
      obj0.setElementType((Class) ClassLiteral<Rules>.Value, "loadout", (Class) ClassLiteral<ItemStack>.Value);
      obj0.setSerializer((Class) ClassLiteral<Sector>.Value, (Json.Serializer) new JsonIO.\u0032());
      obj0.setSerializer((Class) ClassLiteral<SectorPreset>.Value, (Json.Serializer) new JsonIO.\u0033());
      obj0.setSerializer((Class) ClassLiteral<Liquid>.Value, (Json.Serializer) new JsonIO.\u0034());
      obj0.setSerializer((Class) ClassLiteral<Item>.Value, (Json.Serializer) new JsonIO.\u0035());
      obj0.setSerializer((Class) ClassLiteral<Team>.Value, (Json.Serializer) new JsonIO.\u0036());
      obj0.setSerializer((Class) ClassLiteral<Block>.Value, (Json.Serializer) new JsonIO.\u0037());
      obj0.setSerializer((Class) ClassLiteral<Weather>.Value, (Json.Serializer) new JsonIO.\u0038());
      obj0.setSerializer((Class) ClassLiteral<UnitType>.Value, (Json.Serializer) new JsonIO.\u0039());
      obj0.setSerializer((Class) ClassLiteral<ItemStack>.Value, (Json.Serializer) new JsonIO.\u00310());
      obj0.setSerializer((Class) ClassLiteral<UnlockableContent>.Value, (Json.Serializer) new JsonIO.\u00311());
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/String;)TT;")]
    [LineNumberTable(57)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object read(Class type, string @string)
    {
      Json json1 = JsonIO.__\u003C\u003Ejson;
      Class type1 = type;
      string str = @string;
      object obj1 = (object) "";
      object obj2 = (object) "io.anuke.";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence2 = charSequence1;
      object obj3 = obj1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence3 = charSequence1;
      string json2 = String.instancehelper_replace(str, charSequence2, charSequence3);
      return json1.fromJson(type1, json2);
    }

    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonIO()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;TT;Ljava/lang/String;)TT;")]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object read(Class type, object @base, string @string)
    {
      JsonIO.CustomJson jsonBase = JsonIO.jsonBase;
      Class @class = type;
      object obj1 = @base;
      string str1 = @string;
      object obj2 = (object) "";
      object obj3 = (object) "io.anuke.";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence2 = charSequence1;
      object obj4 = obj2;
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      CharSequence charSequence3 = charSequence1;
      string str2 = String.instancehelper_replace(str1, charSequence2, charSequence3);
      return jsonBase.fromBaseJson(@class, obj1, str2);
    }

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string print(string @in) => JsonIO.__\u003C\u003Ejson.prettyPrint(@in);

    [LineNumberTable(new byte[] {159, 138, 77, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static JsonIO()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.io.JsonIO"))
        return;
      JsonIO.jsonBase = new JsonIO.CustomJson();
      JsonIO.__\u003C\u003Ejson = (Json) new JsonIO.\u0031();
    }

    [Modifiers]
    public static Json json
    {
      [HideFromJava] get => JsonIO.__\u003C\u003Ejson;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0031 : Json
    {
      [LineNumberTable(new byte[] {159, 160, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
        JsonIO.\u0031 obj = this;
        JsonIO.apply((Json) this);
      }

      [LineNumberTable(new byte[] {159, 165, 136, 191, 10, 2, 97, 172, 137})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void writeValue([In] object obj0, [In] Class obj1, [In] Class obj2)
      {
        if (obj0 is MappableContent)
        {
          IOException ioException1;
          try
          {
            this.getWriter().value((object) ((MappableContent) obj0).__\u003C\u003Ename);
            return;
          }
          catch (IOException ex)
          {
            ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          IOException ioException2 = ioException1;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException((Exception) ioException2);
        }
        base.writeValue(obj0, obj1, obj2);
      }

      [LineNumberTable(new byte[] {159, 178, 104, 140})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override string convertToString([In] object obj0) => obj0 is MappableContent ? ((MappableContent) obj0).__\u003C\u003Ename : base.convertToString(obj0);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/type/ItemStack;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u00310 : Object, Json.Serializer
    {
      [LineNumberTable(177)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310()
      {
      }

      [LineNumberTable(188)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ItemStack read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2)
      {
        ItemStack.__\u003Cclinit\u003E();
        return new ItemStack((Item) obj0.getSerializer((Class) ClassLiteral<Item>.Value).read(obj0, obj1.get("item"), (Class) ClassLiteral<Item>.Value), obj1.getInt("amount"));
      }

      [LineNumberTable(new byte[] {160, 66, 102, 113, 118, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] ItemStack obj1, [In] Class obj2)
      {
        obj0.writeObjectStart();
        obj0.writeValue("item", (object) obj1.item);
        obj0.writeValue("amount", (object) Integer.valueOf(obj1.amount));
        obj0.writeObjectEnd();
      }

      [Modifiers]
      [LineNumberTable(177)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(177)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (ItemStack) obj1, obj2);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/ctype/UnlockableContent;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u00311 : Object, Json.Serializer
    {
      [LineNumberTable(192)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00311()
      {
      }

      [LineNumberTable(new byte[] {160, 86, 103, 118, 118})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual UnlockableContent read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2)
      {
        string name = obj1.asString();
        Item byName1 = (Item) Vars.content.getByName(ContentType.__\u003C\u003Eitem, name);
        Liquid byName2 = (Liquid) Vars.content.getByName(ContentType.__\u003C\u003Eliquid, name);
        return (UnlockableContent) byName1 ?? (UnlockableContent) byName2;
      }

      [LineNumberTable(new byte[] {160, 81, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] UnlockableContent obj1, [In] Class obj2) => obj0.writeValue((object) obj1.__\u003C\u003Ename);

      [Modifiers]
      [LineNumberTable(192)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(192)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (UnlockableContent) obj1, obj2);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/type/Sector;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u0032 : Object, Json.Serializer
    {
      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032()
      {
      }

      [LineNumberTable(new byte[] {32, 103, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Sector read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2)
      {
        string str = obj1.asString();
        int num = String.instancehelper_lastIndexOf(str, 45);
        return (Sector) ((Planet) Vars.content.getByName(ContentType.__\u003C\u003Eplanet, String.instancehelper_substring(str, 0, num))).sectors.get(Integer.parseInt(String.instancehelper_substring(str, num + 1)));
      }

      [LineNumberTable(new byte[] {27, 127, 22})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] Sector obj1, [In] Class obj2) => obj0.writeValue((object) new StringBuilder().append(obj1.__\u003C\u003Eplanet.__\u003C\u003Ename).append("-").append(obj1.__\u003C\u003Eid).toString());

      [Modifiers]
      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(74)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (Sector) obj1, obj2);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/type/SectorPreset;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u0033 : Object, Json.Serializer
    {
      [LineNumberTable(88)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033()
      {
      }

      [LineNumberTable(96)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual SectorPreset read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (SectorPreset) Vars.content.getByName(ContentType.__\u003C\u003Esector, obj1.asString());

      [LineNumberTable(new byte[] {41, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] SectorPreset obj1, [In] Class obj2) => obj0.writeValue((object) obj1.__\u003C\u003Ename);

      [Modifiers]
      [LineNumberTable(88)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(88)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (SectorPreset) obj1, obj2);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/type/Liquid;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u0034 : Object, Json.Serializer
    {
      [LineNumberTable(100)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034()
      {
      }

      [LineNumberTable(new byte[] {58, 110, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Liquid read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => obj1.asString() == null ? Liquids.water : (Liquid) Vars.content.getByName(ContentType.__\u003C\u003Eliquid, obj1.asString()) ?? Liquids.water;

      [LineNumberTable(new byte[] {53, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] Liquid obj1, [In] Class obj2) => obj0.writeValue((object) obj1.__\u003C\u003Ename);

      [Modifiers]
      [LineNumberTable(100)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(100)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (Liquid) obj1, obj2);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/type/Item;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u0035 : Object, Json.Serializer
    {
      [LineNumberTable(114)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035()
      {
      }

      [LineNumberTable(new byte[] {72, 110, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Item read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => obj1.asString() == null ? Items.copper : (Item) Vars.content.getByName(ContentType.__\u003C\u003Eitem, obj1.asString()) ?? Items.copper;

      [LineNumberTable(new byte[] {67, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] Item obj1, [In] Class obj2) => obj0.writeValue((object) obj1.__\u003C\u003Ename);

      [Modifiers]
      [LineNumberTable(114)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(114)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (Item) obj1, obj2);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/game/Team;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u0036 : Object, Json.Serializer
    {
      [LineNumberTable(128)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036()
      {
      }

      [LineNumberTable(136)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Team read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => Team.get(obj1.asInt());

      [LineNumberTable(new byte[] {81, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] Team obj1, [In] Class obj2) => obj0.writeValue((object) Integer.valueOf(obj1.__\u003C\u003Eid));

      [Modifiers]
      [LineNumberTable(128)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(128)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (Team) obj1, obj2);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/world/Block;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u0037 : Object, Json.Serializer
    {
      [LineNumberTable(140)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037()
      {
      }

      [LineNumberTable(new byte[] {98, 123})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Block read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (Block) Vars.content.getByName(ContentType.__\u003C\u003Eblock, obj1.asString()) ?? Blocks.air;

      [LineNumberTable(new byte[] {93, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] Block obj1, [In] Class obj2) => obj0.writeValue((object) obj1.__\u003C\u003Ename);

      [Modifiers]
      [LineNumberTable(140)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(140)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (Block) obj1, obj2);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/type/Weather;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u0038 : Object, Json.Serializer
    {
      [LineNumberTable(153)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038()
      {
      }

      [LineNumberTable(161)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Weather read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (Weather) Vars.content.getByName(ContentType.__\u003C\u003Eweather, obj1.asString());

      [LineNumberTable(new byte[] {106, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] Weather obj1, [In] Class obj2) => obj0.writeValue((object) obj1.__\u003C\u003Ename);

      [Modifiers]
      [LineNumberTable(153)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(153)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (Weather) obj1, obj2);
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Larc/util/serialization/Json$Serializer<Lmindustry/type/UnitType;>;")]
    [EnclosingMethod(null, "apply", "(Larc.util.serialization.Json;)V")]
    [SpecialName]
    internal class \u0039 : Object, Json.Serializer
    {
      [LineNumberTable(165)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039()
      {
      }

      [LineNumberTable(173)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual UnitType read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (UnitType) Vars.content.getByName(ContentType.__\u003C\u003Eunit, obj1.asString());

      [LineNumberTable(new byte[] {118, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] UnitType obj1, [In] Class obj2) => obj0.writeValue((object) obj1.__\u003C\u003Ename);

      [Modifiers]
      [LineNumberTable(165)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object read([In] Json obj0, [In] JsonValue obj1, [In] Class obj2) => (object) this.read(obj0, obj1, obj2);

      [Modifiers]
      [LineNumberTable(165)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void write([In] Json obj0, [In] object obj1, [In] Class obj2) => this.write(obj0, (UnitType) obj1, obj2);
    }

    internal class CustomJson : Json
    {
      private object baseObject;

      [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;TT;Ljava/lang/String;)TT;")]
      [LineNumberTable(new byte[] {160, 105, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object fromBaseJson([In] Class obj0, [In] object obj1, [In] string obj2)
      {
        this.baseObject = obj1;
        return this.readValue(obj0, (Class) null, new JsonReader().parse(obj2));
      }

      [LineNumberTable(new byte[] {160, 94, 168})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal CustomJson()
      {
        JsonIO.CustomJson customJson = this;
        JsonIO.apply((Json) this);
      }

      [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/String;)TT;")]
      [LineNumberTable(215)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object fromJson([In] Class obj0, [In] string obj1) => this.fromBaseJson(obj0, (object) null, obj1);

      [LineNumberTable(new byte[] {160, 111, 123, 136})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override object newInstance([In] Class obj0) => this.baseObject == null || !object.ReferenceEquals((object) Object.instancehelper_getClass(this.baseObject), (object) obj0) ? base.newInstance(obj0) : this.baseObject;
    }
  }
}
