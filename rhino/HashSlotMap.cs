// Decompiled with JetBrains decompiler
// Type: rhino.HashSlotMap
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
  public class HashSlotMap : Object, SlotMap, Iterable, IEnumerable
  {
    [Modifiers]
    [Signature("Ljava/util/LinkedHashMap<Ljava/lang/Object;Lrhino/ScriptableObject$Slot;>;")]
    private LinkedHashMap map;

    [LineNumberTable(new byte[] {14, 114, 166, 150, 117, 150, 117, 110, 130, 130, 108, 110, 162, 191, 2, 110, 136, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ScriptableObject.Slot createSlot(
      [In] object obj0,
      [In] int obj1,
      [In] object obj2,
      [In] ScriptableObject.SlotAccess obj3)
    {
      ScriptableObject.Slot slot1 = (ScriptableObject.Slot) this.map.get(obj2);
      if (slot1 != null)
      {
        ScriptableObject.Slot slot2;
        if (object.ReferenceEquals((object) obj3, (object) ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER) && !(slot1 is ScriptableObject.GetterSlot))
          slot2 = (ScriptableObject.Slot) new ScriptableObject.GetterSlot(obj2, slot1.indexOrHash, slot1.getAttributes());
        else if (object.ReferenceEquals((object) obj3, (object) ScriptableObject.SlotAccess.CONVERT_ACCESSOR_TO_DATA) && slot1 is ScriptableObject.GetterSlot)
          slot2 = new ScriptableObject.Slot(obj2, slot1.indexOrHash, slot1.getAttributes());
        else
          return object.ReferenceEquals((object) obj3, (object) ScriptableObject.SlotAccess.MODIFY_CONST) ? (ScriptableObject.Slot) null : slot1;
        slot2.value = slot1.value;
        ((HashMap) this.map).put(obj2, (object) slot2);
        return slot2;
      }
      ScriptableObject.Slot newSlot = !object.ReferenceEquals((object) obj3, (object) ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER) ? new ScriptableObject.Slot(obj0, obj1, 0) : (ScriptableObject.Slot) new ScriptableObject.GetterSlot(obj0, obj1, 0);
      if (object.ReferenceEquals((object) obj3, (object) ScriptableObject.SlotAccess.MODIFY_CONST))
        newSlot.setAttributes(13);
      this.addSlot(newSlot);
      return newSlot;
    }

    [LineNumberTable(new byte[] {46, 124, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addSlot(ScriptableObject.Slot newSlot) => ((HashMap) this.map).put(newSlot.name != null ? newSlot.name : (object) String.valueOf(newSlot.indexOrHash), (object) newSlot);

    [LineNumberTable(new byte[] {159, 157, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public HashSlotMap()
    {
      HashSlotMap hashSlotMap = this;
      this.map = new LinkedHashMap();
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size() => ((HashMap) this.map).size();

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => ((HashMap) this.map).isEmpty();

    [LineNumberTable(new byte[] {159, 175, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptableObject.Slot query(object key, int index) => (ScriptableObject.Slot) this.map.get(key != null ? key : (object) String.valueOf(index));

    [LineNumberTable(new byte[] {159, 181, 109, 114, 159, 10, 162, 99, 162, 104, 162, 104, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ScriptableObject.Slot get(
      object key,
      int index,
      ScriptableObject.SlotAccess accessType)
    {
      object obj = key != null ? key : (object) String.valueOf(index);
      ScriptableObject.Slot slot = (ScriptableObject.Slot) this.map.get(obj);
      switch (HashSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[accessType.ordinal()])
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
      return this.createSlot(key, index, obj, accessType);
    }

    [LineNumberTable(new byte[] {52, 109, 114, 131, 106, 102, 104, 145, 129, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void remove(object key, int index)
    {
      object obj = key != null ? key : (object) String.valueOf(index);
      ScriptableObject.Slot slot = (ScriptableObject.Slot) this.map.get(obj);
      if (slot == null)
        return;
      if ((slot.getAttributes() & 4) != 0)
      {
        if (Context.getContext().isStrictMode())
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.delete.property.with.configurable.false", key));
      }
      else
        ((HashMap) this.map).remove(obj);
    }

    [Signature("()Ljava/util/Iterator<Lrhino/ScriptableObject$Slot;>;")]
    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => this.map.values().iterator();

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

      [LineNumberTable(41)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.HashSlotMap$1"))
          return;
        HashSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess = new int[ScriptableObject.SlotAccess.values().Length];
        try
        {
          HashSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.QUERY.ordinal()] = 1;
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
          HashSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.MODIFY.ordinal()] = 2;
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
          HashSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.MODIFY_CONST.ordinal()] = 3;
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
          HashSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.MODIFY_GETTER_SETTER.ordinal()] = 4;
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
          HashSlotMap.\u0031.\u0024SwitchMap\u0024rhino\u0024ScriptableObject\u0024SlotAccess[ScriptableObject.SlotAccess.CONVERT_ACCESSOR_TO_DATA.ordinal()] = 5;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }
  }
}
