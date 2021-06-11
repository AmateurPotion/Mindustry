// Decompiled with JetBrains decompiler
// Type: rhino.EmbeddedSlotMap
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.SlotMap"})]
  public class EmbeddedSlotMap : Object, SlotMap, Iterable, IEnumerable
  {
    private ScriptableObject.Slot[] slots;
    private ScriptableObject.Slot firstAdded;
    private ScriptableObject.Slot lastAdded;
    private int count;
    private const int INITIAL_SLOT_SIZE = 4;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int getSlotIndex([In] int obj0, [In] int obj1) => obj1 & obj0 - 1;

    [LineNumberTable(new byte[] {100, 136, 113, 167, 110, 105, 98, 99, 159, 2, 103, 130, 98, 169, 230, 72, 149, 99, 109, 149, 112, 109, 130, 162, 108, 172, 110, 137, 104, 115, 139, 100, 168, 108, 110, 199, 105, 139, 135, 226, 70, 149, 112, 110, 168, 191, 2, 109, 137, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ScriptableObject.Slot createSlot(
      [In] object obj0,
      [In] int obj1,
      [In] ScriptableObject.SlotAccess obj2,
      [In] ScriptableObject.Slot obj3)
    {
      if (this.count == 0)
        this.slots = new ScriptableObject.Slot[4];
      else if (obj3 != null)
      {
        int slotIndex = EmbeddedSlotMap.getSlotIndex(this.slots.Length, obj1);
        ScriptableObject.Slot slot1 = this.slots[slotIndex];
        ScriptableObject.Slot slot2;
        for (slot2 = slot1; slot2 != null && (slot2.indexOrHash != obj1 || !object.ReferenceEquals(slot2.name, obj0) && (obj0 == null || !Object.instancehelper_equals(obj0, slot2.name))); slot2 = slot2.next)
          slot1 = slot2;
        if (slot2 != null)
        {
          ScriptableObject.Slot slot3;
          if (object.ReferenceEquals((object) obj2, (object) ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER) && !(slot2 is ScriptableObject.GetterSlot))
            slot3 = (ScriptableObject.Slot) new ScriptableObject.GetterSlot(obj0, obj1, slot2.getAttributes());
          else if (object.ReferenceEquals((object) obj2, (object) ScriptableObject.SlotAccess.CONVERT_ACCESSOR_TO_DATA) && slot2 is ScriptableObject.GetterSlot)
            slot3 = new ScriptableObject.Slot(obj0, obj1, slot2.getAttributes());
          else
            return object.ReferenceEquals((object) obj2, (object) ScriptableObject.SlotAccess.MODIFY_CONST) ? (ScriptableObject.Slot) null : slot2;
          slot3.value = slot2.value;
          slot3.next = slot2.next;
          if (object.ReferenceEquals((object) slot2, (object) this.firstAdded))
          {
            this.firstAdded = slot3;
          }
          else
          {
            ScriptableObject.Slot slot4 = this.firstAdded;
            while (slot4 != null && !object.ReferenceEquals((object) slot4.orderedNext, (object) slot2))
              slot4 = slot4.orderedNext;
            if (slot4 != null)
              slot4.orderedNext = slot3;
          }
          slot3.orderedNext = slot2.orderedNext;
          if (object.ReferenceEquals((object) slot2, (object) this.lastAdded))
            this.lastAdded = slot3;
          if (object.ReferenceEquals((object) slot1, (object) slot2))
            this.slots[slotIndex] = slot3;
          else
            slot1.next = slot3;
          return slot3;
        }
      }
      if (4 * (this.count + 1) > 3 * this.slots.Length)
      {
        ScriptableObject.Slot[] slotArray = new ScriptableObject.Slot[this.slots.Length * 2];
        this.copyTable(this.slots, slotArray);
        this.slots = slotArray;
      }
      ScriptableObject.Slot slot = !object.ReferenceEquals((object) obj2, (object) ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER) ? new ScriptableObject.Slot(obj0, obj1, 0) : (ScriptableObject.Slot) new ScriptableObject.GetterSlot(obj0, obj1, 0);
      if (object.ReferenceEquals((object) obj2, (object) ScriptableObject.SlotAccess.MODIFY_CONST))
        slot.setAttributes(13);
      this.insertNewSlot(slot);
      return slot;
    }

    [LineNumberTable(new byte[] {160, 204, 111, 99, 104, 103, 104, 99, 226, 58, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void copyTable([In] ScriptableObject.Slot[] obj0, [In] ScriptableObject.Slot[] obj1)
    {
      ScriptableObject.Slot[] slotArray = obj0;
      int length = slotArray.Length;
      ScriptableObject.Slot next;
      for (int index = 0; index < length; ++index)
      {
        for (ScriptableObject.Slot slot = slotArray[index]; slot != null; slot = next)
        {
          next = slot.next;
          slot.next = (ScriptableObject.Slot) null;
          this.addKnownAbsentSlot(obj1, slot);
        }
      }
    }

    [LineNumberTable(new byte[] {160, 134, 142, 104, 140, 104, 135, 135, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void insertNewSlot([In] ScriptableObject.Slot obj0)
    {
      ++this.count;
      if (this.lastAdded != null)
        this.lastAdded.orderedNext = obj0;
      if (this.firstAdded == null)
        this.firstAdded = obj0;
      this.lastAdded = obj0;
      this.addKnownAbsentSlot(this.slots, obj0);
    }

    [LineNumberTable(new byte[] {160, 220, 110, 100, 100, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addKnownAbsentSlot([In] ScriptableObject.Slot[] obj0, [In] ScriptableObject.Slot obj1)
    {
      int slotIndex = EmbeddedSlotMap.getSlotIndex(obj0.Length, obj1.indexOrHash);
      ScriptableObject.Slot slot = obj0[slotIndex];
      obj0[slotIndex] = obj1;
      obj1.next = slot;
    }

    [LineNumberTable(new byte[] {2, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public EmbeddedSlotMap()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => this.count;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.count == 0;

    [Signature("()Ljava/util/Iterator<Lrhino/ScriptableObject$Slot;>;")]
    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) new EmbeddedSlotMap.Iter(this.firstAdded);

    [LineNumberTable(new byte[] {25, 104, 162, 109, 110, 105, 131, 103, 151, 103, 226, 59, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptableObject.Slot query(object key, int index)
    {
      if (this.slots == null)
        return (ScriptableObject.Slot) null;
      int num = key == null ? index : Object.instancehelper_hashCode(key);
      for (ScriptableObject.Slot slot = this.slots[EmbeddedSlotMap.getSlotIndex(this.slots.Length, num)]; slot != null; slot = slot.next)
      {
        object name = slot.name;
        if (num == slot.indexOrHash && (object.ReferenceEquals(name, key) || key != null && Object.instancehelper_equals(key, name)))
          return slot;
      }
      return (ScriptableObject.Slot) null;
    }

    [LineNumberTable(new byte[] {52, 117, 162, 109, 130, 107, 110, 105, 131, 103, 151, 103, 226, 59, 233, 72, 159, 10, 162, 99, 194, 104, 194, 104, 226, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptableObject.Slot get(
      object key,
      int index,
      ScriptableObject.SlotAccess accessType)
    {
      if (this.slots == null && object.ReferenceEquals((object) accessType, (object) ScriptableObject.SlotAccess.QUERY))
        return (ScriptableObject.Slot) null;
      int num = key == null ? index : Object.instancehelper_hashCode(key);
      ScriptableObject.Slot slot = (ScriptableObject.Slot) null;
      if (this.slots != null)
      {
        for (slot = this.slots[EmbeddedSlotMap.getSlotIndex(this.slots.Length, num)]; slot != null; slot = slot.next)
        {
          object name = slot.name;
          if (num == slot.indexOrHash && (object.ReferenceEquals(name, key) || key != null && Object.instancehelper_equals(key, name)))
            break;
        }
        switch (EmbeddedSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[accessType.ordinal()])
        {
          case 1:
            return slot;
          case 2:
          case 3:
            if (slot != null)
              return slot;
            break;
          case 4:
            if (slot is ScriptableObject.GetterSlot)
              return slot;
            break;
          case 5:
            if (!(slot is ScriptableObject.GetterSlot))
              return slot;
            break;
        }
      }
      return this.createSlot(key, num, accessType, slot);
    }

    [LineNumberTable(new byte[] {160, 127, 104, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addSlot(ScriptableObject.Slot newSlot)
    {
      if (this.slots == null)
        this.slots = new ScriptableObject.Slot[4];
      this.insertNewSlot(newSlot);
    }

    [LineNumberTable(new byte[] {160, 149, 141, 107, 110, 105, 98, 99, 159, 2, 103, 130, 98, 137, 134, 106, 103, 105, 145, 129, 142, 105, 144, 236, 72, 110, 98, 142, 103, 110, 137, 140, 110, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(object key, int index)
    {
      int num = key == null ? index : Object.instancehelper_hashCode(key);
      if (this.count == 0)
        return;
      int slotIndex = EmbeddedSlotMap.getSlotIndex(this.slots.Length, num);
      ScriptableObject.Slot slot1 = this.slots[slotIndex];
      ScriptableObject.Slot slot2;
      for (slot2 = slot1; slot2 != null && (slot2.indexOrHash != num || !object.ReferenceEquals(slot2.name, key) && (key == null || !Object.instancehelper_equals(key, slot2.name))); slot2 = slot2.next)
        slot1 = slot2;
      if (slot2 == null)
        return;
      if ((slot2.getAttributes() & 4) != 0)
      {
        if (Context.getContext().isStrictMode())
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.delete.property.with.configurable.false", key));
      }
      else
      {
        --this.count;
        if (object.ReferenceEquals((object) slot1, (object) slot2))
          this.slots[slotIndex] = slot2.next;
        else
          slot1.next = slot2.next;
        ScriptableObject.Slot slot3;
        if (object.ReferenceEquals((object) slot2, (object) this.firstAdded))
        {
          slot3 = (ScriptableObject.Slot) null;
          this.firstAdded = slot2.orderedNext;
        }
        else
        {
          slot3 = this.firstAdded;
          while (!object.ReferenceEquals((object) slot3.orderedNext, (object) slot2))
            slot3 = slot3.orderedNext;
          slot3.orderedNext = slot2.orderedNext;
        }
        if (!object.ReferenceEquals((object) slot2, (object) this.lastAdded))
          return;
        this.lastAdded = slot3;
      }
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => Iterable.\u003Cdefault\u003Espliterator((Iterable) this);

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [HideFromJava]
    [NameSig("query", "(Ljava.lang.Object;I)Lrhino.ScriptableObject$Slot;")]
    public object query([In] object obj0, [In] int obj1) => (object) this.query(obj0, obj1);

    [HideFromJava]
    [NameSig("query", "(Ljava.lang.Object;I)Lrhino.ScriptableObject$Slot;")]
    protected internal object \u003Cnonvirtual\u003E0([In] object obj0, [In] int obj1) => (object) this.query(obj0, obj1);

    [HideFromJava]
    [NameSig("get", "(Ljava.lang.Object;ILrhino.ScriptableObject$SlotAccess;)Lrhino.ScriptableObject$Slot;")]
    public object get([In] object obj0, [In] int obj1, [In] Enum obj2) => (object) this.get(obj0, obj1, (ScriptableObject.SlotAccess) obj2);

    [HideFromJava]
    [NameSig("get", "(Ljava.lang.Object;ILrhino.ScriptableObject$SlotAccess;)Lrhino.ScriptableObject$Slot;")]
    protected internal object \u003Cnonvirtual\u003E1([In] object obj0, [In] int obj1, [In] Enum obj2) => (object) this.get(obj0, obj1, (ScriptableObject.SlotAccess) obj2);

    [HideFromJava]
    [NameSig("addSlot", "(Lrhino.ScriptableObject$Slot;)V")]
    public void addSlot([In] object obj0) => this.addSlot((ScriptableObject.Slot) obj0);

    [HideFromJava]
    [NameSig("addSlot", "(Lrhino.ScriptableObject$Slot;)V")]
    protected internal void \u003Cnonvirtual\u003E2([In] object obj0) => this.addSlot((ScriptableObject.Slot) obj0);

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(121)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.EmbeddedSlotMap$1"))
          return;
        EmbeddedSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess = new int[ScriptableObject.SlotAccess.values().Length];
        try
        {
          EmbeddedSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.QUERY.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          EmbeddedSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.MODIFY.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          EmbeddedSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.MODIFY_CONST.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          EmbeddedSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER.ordinal()] = 4;
          goto label_18;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_18:
        try
        {
          EmbeddedSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.CONVERT_ACCESSOR_TO_DATA.ordinal()] = 5;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [InnerClass]
    [Signature("Ljava/lang/Object;Ljava/util/Iterator<Lrhino/ScriptableObject$Slot;>;")]
    internal sealed class Iter : Object, Iterator
    {
      private ScriptableObject.Slot next;

      [LineNumberTable(new byte[] {159, 174, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Iter([In] ScriptableObject.Slot obj0)
      {
        EmbeddedSlotMap.Iter iter = this;
        this.next = obj0;
      }

      [LineNumberTable(new byte[] {159, 185, 103, 99, 139, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual ScriptableObject.Slot next()
      {
        ScriptableObject.Slot next = this.next;
        if (next == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }
        this.next = this.next.orderedNext;
        return next;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool hasNext() => this.next != null;

      [Modifiers]
      [LineNumberTable(28)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual object next() => (object) this.next();

      [HideFromJava]
      public virtual void remove() => Iterator.\u003Cdefault\u003Eremove((Iterator) this);

      [HideFromJava]
      public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
    }
  }
}
