// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Itemsc
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.math.geom;
using IKVM.Attributes;
using mindustry.type;

namespace mindustry.gen
{
  [Implements(new string[] {"mindustry.gen.Posc", "mindustry.gen.Entityc"})]
  public interface Itemsc : Posc, Position, Entityc
  {
    bool acceptsItem(Item i);

    void clearItem();

    Item item();

    int itemCapacity();

    new void update();

    bool hasItem();

    void addItem(Item i);

    void addItem(Item i1, int i2);

    int maxAccepted(Item i);

    ItemStack stack();

    void stack(ItemStack @is);

    float itemTime();

    void itemTime(float f);
  }
}
