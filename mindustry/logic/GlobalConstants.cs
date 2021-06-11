// Decompiled with JetBrains decompiler
// Type: mindustry.logic.GlobalConstants
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.content;
using mindustry.type;
using mindustry.world;
using System.Runtime.CompilerServices;

namespace mindustry.logic
{
  public class GlobalConstants : Object
  {
    public const int ctrlProcessor = 1;
    public const int ctrlPlayer = 2;
    public const int ctrlFormation = 3;
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/String;>;")]
    private ObjectIntMap namesToIds;
    [Signature("Larc/struct/Seq<Lmindustry/logic/LExecutor$Var;>;")]
    private Seq vars;

    [LineNumberTable(new byte[] {159, 153, 168, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GlobalConstants()
    {
      GlobalConstants globalConstants = this;
      this.namesToIds = new ObjectIntMap();
      this.vars = new Seq((Class) ClassLiteral<LExecutor.Var>.Value);
    }

    [LineNumberTable(new byte[] {159, 160, 141, 114, 114, 205, 114, 114, 210, 127, 5, 127, 8, 130, 127, 5, 127, 8, 130, 127, 5, 104, 159, 8, 162, 113, 145, 127, 6, 127, 10, 162, 124, 63, 10, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
      this.put("the end", (object) null);
      this.put("false", (object) Integer.valueOf(0));
      this.put("true", (object) Integer.valueOf(1));
      this.put("null", (object) null);
      this.put("@ctrlProcessor", (object) Integer.valueOf(1));
      this.put("@ctrlPlayer", (object) Integer.valueOf(2));
      this.put("@ctrlFormation", (object) Integer.valueOf(3));
      Iterator iterator1 = Vars.content.items().iterator();
      while (iterator1.hasNext())
      {
        Item obj = (Item) iterator1.next();
        this.put(new StringBuilder().append("@").append(obj.__\u003C\u003Ename).toString(), (object) obj);
      }
      Iterator iterator2 = Vars.content.liquids().iterator();
      while (iterator2.hasNext())
      {
        Liquid liquid = (Liquid) iterator2.next();
        this.put(new StringBuilder().append("@").append(liquid.__\u003C\u003Ename).toString(), (object) liquid);
      }
      Iterator iterator3 = Vars.content.blocks().iterator();
      while (iterator3.hasNext())
      {
        Block block = (Block) iterator3.next();
        if (block.synthetic())
          this.put(new StringBuilder().append("@").append(block.__\u003C\u003Ename).toString(), (object) block);
      }
      this.put("@solid", (object) Blocks.stoneWall);
      this.put("@air", (object) Blocks.air);
      Iterator iterator4 = Vars.content.units().iterator();
      while (iterator4.hasNext())
      {
        UnitType unitType = (UnitType) iterator4.next();
        this.put(new StringBuilder().append("@").append(unitType.__\u003C\u003Ename).toString(), (object) unitType);
      }
      LAccess[] all = LAccess.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        LAccess laccess = all[index];
        this.put(new StringBuilder().append("@").append(laccess.name()).toString(), (object) laccess);
      }
    }

    [LineNumberTable(new byte[] {22, 103, 103, 127, 0, 144, 103, 167, 108, 109, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LExecutor.Var put(string name, object value)
    {
      LExecutor.Var var = new LExecutor.Var(name);
      var.constant = true;
      object obj = value;
      Number number;
      if (obj is Number && object.ReferenceEquals((object) (number = (Number) obj), (object) (Number) obj))
      {
        var.numval = number.doubleValue();
      }
      else
      {
        var.isobj = true;
        var.objval = value;
      }
      int size = this.vars.size;
      this.namesToIds.put((object) name, size);
      this.vars.add((object) var);
      return var;
    }

    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int get(string name) => this.namesToIds.get((object) name, -1);

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual LExecutor.Var get(int id) => ((LExecutor.Var[]) this.vars.items)[id];
  }
}
