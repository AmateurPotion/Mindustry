// Decompiled with JetBrains decompiler
// Type: rhino.SlotMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;

namespace rhino
{
  [Signature("Ljava/lang/Object;Ljava/lang/Iterable<Lrhino/ScriptableObject$Slot;>;")]
  [Implements(new string[] {"java.lang.Iterable"})]
  public interface SlotMap : Iterable
  {
    int size();

    bool isEmpty();

    ScriptableObject.Slot get(object obj, int i, ScriptableObject.SlotAccess sosa);

    ScriptableObject.Slot query(object obj, int i);

    void addSlot(ScriptableObject.Slot sos);

    void remove(object obj, int i);
  }
}
