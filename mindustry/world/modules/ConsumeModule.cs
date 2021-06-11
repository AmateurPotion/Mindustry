// Decompiled with JetBrains decompiler
// Type: mindustry.world.modules.ConsumeModule
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.io;
using IKVM.Attributes;
using mindustry.gen;
using mindustry.world.consumers;
using mindustry.world.meta;
using System.Runtime.CompilerServices;

namespace mindustry.world.modules
{
  public class ConsumeModule : BlockModule
  {
    private bool valid;
    private bool optionalValid;
    [Modifiers]
    private Building entity;

    [LineNumberTable(new byte[] {159, 154, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConsumeModule(Building entity)
    {
      ConsumeModule consumeModule = this;
      this.entity = entity;
    }

    [LineNumberTable(new byte[] {25, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void write(Writes write) => write.@bool(this.valid);

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool valid() => this.valid && this.entity.shouldConsume() && this.entity.enabled;

    [LineNumberTable(new byte[] {10, 127, 4, 44, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void trigger()
    {
      Consume[] consumeArray = this.entity.block.__\u003C\u003Econsumes.all();
      int length = consumeArray.Length;
      for (int index = 0; index < length; ++index)
        consumeArray[index].trigger(this.entity);
    }

    [LineNumberTable(new byte[] {159, 159, 109, 166, 117, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BlockStatus status()
    {
      if (!this.entity.shouldConsume())
        return BlockStatus.__\u003C\u003EnoOutput;
      return !this.valid || !this.entity.productionValid() ? BlockStatus.__\u003C\u003EnoInput : BlockStatus.__\u003C\u003Eactive;
    }

    [LineNumberTable(new byte[] {159, 172, 109, 114, 161, 103, 103, 103, 159, 0, 127, 13, 139, 126, 173, 250, 57, 235, 74, 127, 10, 126, 173, 250, 59, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void update()
    {
      if (this.entity.cheating())
      {
        ConsumeModule consumeModule = this;
        int num1 = 1;
        int num2 = num1;
        this.optionalValid = num1 != 0;
        this.valid = num2 != 0;
      }
      else
      {
        int num1 = this.valid() ? 1 : 0;
        this.valid = true;
        this.optionalValid = true;
        int num2 = !this.entity.shouldConsume() || !this.entity.productionValid() ? 0 : 1;
        Consume[] consumeArray1 = this.entity.block.__\u003C\u003Econsumes.all();
        int length1 = consumeArray1.Length;
        for (int index = 0; index < length1; ++index)
        {
          Consume consume = consumeArray1[index];
          if (!consume.isOptional())
          {
            if (num2 != 0 && consume.isUpdate() && (num1 != 0 && consume.valid(this.entity)))
              consume.update(this.entity);
            this.valid &= consume.valid(this.entity);
          }
        }
        Consume[] consumeArray2 = this.entity.block.__\u003C\u003Econsumes.optionals();
        int length2 = consumeArray2.Length;
        for (int index = 0; index < length2; ++index)
        {
          Consume consume = consumeArray2[index];
          if (num2 != 0 && consume.isUpdate() && (num1 != 0 && consume.valid(this.entity)))
            consume.update(this.entity);
          this.optionalValid &= consume.valid(this.entity);
        }
      }
    }

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool optionalValid() => this.valid() && this.optionalValid && this.entity.enabled;

    [LineNumberTable(new byte[] {30, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void read(Reads read) => this.valid = read.@bool();
  }
}
