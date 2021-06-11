// Decompiled with JetBrains decompiler
// Type: arc.KeyBinds
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.input;
using arc.math;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc
{
  public class KeyBinds : Object
  {
    private KeyBinds.Section defaultSection;
    [Signature("Larc/struct/ObjectMap<Larc/KeyBinds$KeyBind;Larc/struct/ObjectMap<Larc/input/InputDevice$DeviceType;Larc/KeyBinds$Axis;>;>;")]
    private ObjectMap defaultCache;
    private KeyBinds.KeyBind[] definitions;
    private KeyBinds.Section[] sections;

    [LineNumberTable(new byte[] {159, 184, 112, 103, 111, 110, 144, 114, 114, 127, 0, 115, 111, 31, 2, 38, 11, 233, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDefaults(KeyBinds.KeyBind[] defs, params KeyBinds.Section[] sectionArr)
    {
      this.defaultSection = new KeyBinds.Section("default");
      this.definitions = defs;
      this.sections = new KeyBinds.Section[sectionArr.Length + 1];
      this.sections[0] = this.defaultSection;
      ByteCodeHelper.arraycopy((object) sectionArr, 0, (object) this.sections, 1, sectionArr.Length);
      KeyBinds.KeyBind[] keyBindArray = defs;
      int length1 = keyBindArray.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        KeyBinds.KeyBind keyBind = keyBindArray[index1];
        this.defaultCache.put((object) keyBind, (object) new ObjectMap());
        InputDevice.DeviceType[] deviceTypeArray = InputDevice.DeviceType.values();
        int length2 = deviceTypeArray.Length;
        for (int index2 = 0; index2 < length2; ++index2)
        {
          InputDevice.DeviceType iddt = deviceTypeArray[index2];
          ((ObjectMap) this.defaultCache.get((object) keyBind)).put((object) iddt, !(keyBind.defaultValue(iddt) is KeyBinds.Axis) ? (object) new KeyBinds.Axis((KeyCode) keyBind.defaultValue(iddt)) : (object) (KeyBinds.Axis) keyBind.defaultValue(iddt));
        }
      }
    }

    [LineNumberTable(162)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeyBinds.Axis get(KeyBinds.KeyBind name) => this.get(this.defaultSection, name);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeyBinds.Section[] getSections() => this.sections;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeyBinds.KeyBind[] getKeybinds() => this.definitions;

    [LineNumberTable(new byte[] {116, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeyBinds.Axis get(KeyBinds.Section section, KeyBinds.KeyBind def)
    {
      if (this.definitions == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("No keybinds defined! Did you forget to call setDefaults(...)?");
      }
      return this.get(section, section.device.type(), def);
    }

    [LineNumberTable(new byte[] {49, 119, 127, 13, 127, 1, 127, 46, 127, 6, 127, 6, 127, 6, 255, 6, 59, 235, 71, 229, 55, 233, 77, 116, 43, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resetToDefaults()
    {
      KeyBinds.Section[] sections1 = this.sections;
      int length1 = sections1.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        KeyBinds.Section section = sections1[index1];
        ObjectMap.Keys keys = section.binds.keys().iterator();
label_3:
        while (((Iterator) keys).hasNext())
        {
          InputDevice.DeviceType deviceType = (InputDevice.DeviceType) ((Iterator) keys).next();
          KeyBinds.KeyBind[] definitions = this.definitions;
          int length2 = definitions.Length;
          int index2 = 0;
          while (true)
          {
            if (index2 < length2)
            {
              KeyBinds.KeyBind keyBind = definitions[index2];
              string str = new StringBuilder().append("keybind-").append(section.__\u003C\u003Ename).append("-").append(deviceType.name()).append("-").append(keyBind.name()).toString();
              Core.settings.remove(new StringBuilder().append(str).append("-single").toString());
              Core.settings.remove(new StringBuilder().append(str).append("-key").toString());
              Core.settings.remove(new StringBuilder().append(str).append("-min").toString());
              Core.settings.remove(new StringBuilder().append(str).append("-max").toString());
              ++index2;
            }
            else
              goto label_3;
          }
        }
      }
      KeyBinds.Section[] sections2 = this.sections;
      int length3 = sections2.Length;
      for (int index = 0; index < length3; ++index)
        sections2[index].binds.clear();
    }

    [LineNumberTable(new byte[] {72, 127, 53, 127, 5, 127, 5, 127, 5, 159, 5, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resetToDefault(KeyBinds.Section section, KeyBinds.KeyBind bind)
    {
      string str = new StringBuilder().append("keybind-").append(section.__\u003C\u003Ename).append("-").append(section.device.type().name()).append("-").append(bind.name()).toString();
      Core.settings.remove(new StringBuilder().append(str).append("-single").toString());
      Core.settings.remove(new StringBuilder().append(str).append("-key").toString());
      Core.settings.remove(new StringBuilder().append(str).append("-min").toString());
      Core.settings.remove(new StringBuilder().append(str).append("-max").toString());
      section.binds.each((Cons2) new KeyBinds.__\u003C\u003EAnon1(bind));
    }

    [LineNumberTable(new byte[] {159, 173, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public KeyBinds()
    {
      KeyBinds keyBinds = this;
      this.defaultCache = new ObjectMap();
    }

    [LineNumberTable(new byte[] {82, 159, 22, 104, 159, 23, 127, 21, 159, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void save([In] KeyBinds.Axis obj0, [In] string obj1)
    {
      Core.settings.put(new StringBuilder().append(obj1).append("-single").toString(), (object) Boolean.valueOf(obj0.key != null));
      if (obj0.key != null)
      {
        Core.settings.put(new StringBuilder().append(obj1).append("-key").toString(), (object) Integer.valueOf(obj0.key.ordinal()));
      }
      else
      {
        Core.settings.put(new StringBuilder().append(obj1).append("-min").toString(), (object) Integer.valueOf(obj0.min.ordinal()));
        Core.settings.put(new StringBuilder().append(obj1).append("-max").toString(), (object) Integer.valueOf(obj0.max.ordinal()));
      }
    }

    [LineNumberTable(new byte[] {93, 127, 8, 127, 21, 151, 127, 21, 127, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private KeyBinds.Axis load([In] string obj0)
    {
      if (Core.settings.getBool(new StringBuilder().append(obj0).append("-single").toString(), true))
      {
        KeyCode key = KeyCode.byOrdinal(Core.settings.getInt(new StringBuilder().append(obj0).append("-key").toString(), KeyCode.__\u003C\u003Eunset.ordinal()));
        return object.ReferenceEquals((object) key, (object) KeyCode.__\u003C\u003Eunset) ? (KeyBinds.Axis) null : new KeyBinds.Axis(key);
      }
      KeyCode min = KeyCode.byOrdinal(Core.settings.getInt(new StringBuilder().append(obj0).append("-min").toString(), KeyCode.__\u003C\u003Eunset.ordinal()));
      KeyCode max = KeyCode.byOrdinal(Core.settings.getInt(new StringBuilder().append(obj0).append("-max").toString(), KeyCode.__\u003C\u003Eunset.ordinal()));
      return object.ReferenceEquals((object) min, (object) KeyCode.__\u003C\u003Eunset) || object.ReferenceEquals((object) max, (object) KeyCode.__\u003C\u003Eunset) ? (KeyBinds.Axis) null : new KeyBinds.Axis(min, max);
    }

    [LineNumberTable(new byte[] {121, 127, 8, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeyBinds.Axis get(
      KeyBinds.Section section,
      InputDevice.DeviceType type,
      KeyBinds.KeyBind def)
    {
      return section.binds.containsKey((object) type) && ((ObjectMap) section.binds.get((object) type)).containsKey((object) def) ? (KeyBinds.Axis) ((ObjectMap) section.binds.get((object) type)).get((object) def) : (KeyBinds.Axis) ((ObjectMap) this.defaultCache.get((object) def)).get((object) type);
    }

    [Modifiers]
    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024resetToDefault\u00240(
      [In] KeyBinds.KeyBind obj0,
      [In] InputDevice.DeviceType obj1,
      [In] OrderedMap obj2)
    {
      obj2.remove((object) obj0);
    }

    [LineNumberTable(new byte[] {10, 137, 119, 127, 13, 127, 25, 127, 56, 116, 101, 101, 255, 37, 57, 233, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void save()
    {
      if (this.definitions == null)
        return;
      KeyBinds.Section[] sections = this.sections;
      int length = sections.Length;
      for (int index = 0; index < length; ++index)
      {
        KeyBinds.Section section = sections[index];
        ObjectMap.Keys keys = section.binds.keys().iterator();
label_5:
        while (((Iterator) keys).hasNext())
        {
          InputDevice.DeviceType deviceType = (InputDevice.DeviceType) ((Iterator) keys).next();
          ObjectMap.Entries entries = ((OrderedMap) section.binds.get((object) deviceType)).entries().iterator();
          while (true)
          {
            if (((Iterator) entries).hasNext())
            {
              ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
              string str = new StringBuilder().append("keybind-").append(section.__\u003C\u003Ename).append("-").append(deviceType.name()).append("-").append(((KeyBinds.KeyBind) entry.key).name()).toString();
              this.save((KeyBinds.Axis) entry.value, str);
            }
            else
              goto label_5;
          }
        }
        Core.settings.put(new StringBuilder().append(section.__\u003C\u003Ename).append("-last-device-type").toString(), (object) Integer.valueOf(Core.input.getDevices().indexOf((object) section.device, true)));
      }
    }

    [LineNumberTable(new byte[] {25, 137, 119, 127, 0, 127, 1, 159, 46, 138, 100, 255, 7, 58, 43, 235, 76, 255, 60, 51, 233, 79})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void load()
    {
      if (this.definitions == null)
        return;
      KeyBinds.Section[] sections = this.sections;
      int length1 = sections.Length;
      for (int index1 = 0; index1 < length1; ++index1)
      {
        KeyBinds.Section section = sections[index1];
        InputDevice.DeviceType[] deviceTypeArray = InputDevice.DeviceType.values();
        int length2 = deviceTypeArray.Length;
        for (int index2 = 0; index2 < length2; ++index2)
        {
          InputDevice.DeviceType deviceType = deviceTypeArray[index2];
          KeyBinds.KeyBind[] definitions = this.definitions;
          int length3 = definitions.Length;
          for (int index3 = 0; index3 < length3; ++index3)
          {
            KeyBinds.KeyBind keyBind = definitions[index3];
            KeyBinds.Axis axis = this.load(new StringBuilder().append("keybind-").append(section.__\u003C\u003Ename).append("-").append(deviceType.name()).append("-").append(keyBind.name()).toString());
            if (axis != null)
              ((OrderedMap) section.binds.get((object) deviceType, (Prov) new KeyBinds.__\u003C\u003EAnon0())).put((object) keyBind, (object) axis);
          }
        }
        section.device = (InputDevice) Core.input.getDevices().get(Mathf.clamp(Core.settings.getInt(new StringBuilder().append(section.__\u003C\u003Ename).append("-last-device-type").toString(), 0), 0, Core.input.getDevices().size - 1));
      }
    }

    public class Axis : Object, KeyBinds.KeybindValue
    {
      public KeyCode min;
      public KeyCode max;
      public KeyCode key;

      [LineNumberTable(new byte[] {160, 114, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Axis(KeyCode min, KeyCode max)
      {
        KeyBinds.Axis axis = this;
        this.min = min;
        this.max = max;
        this.key = (KeyCode) null;
      }

      [LineNumberTable(new byte[] {160, 108, 104, 103, 114})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Axis(KeyCode key)
      {
        KeyBinds.Axis axis1 = this;
        this.key = key;
        KeyBinds.Axis axis2 = this;
        this.max = (KeyCode) null;
        this.min = (KeyCode) null;
      }

      [LineNumberTable(236)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append("Axis{min=").append((object) this.min).append(", max=").append((object) this.max).append(", key=").append((object) this.key).append('}').toString();
    }

    public interface KeyBind
    {
      string name();

      KeyBinds.KeybindValue defaultValue(InputDevice.DeviceType iddt);

      [Modifiers]
      string category();

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static string \u003Cdefault\u003Ecategory([In] KeyBinds.KeyBind obj0) => (string) null;

      [HideFromJava]
      static class __DefaultMethods
      {
        public static string category([In] KeyBinds.KeyBind obj0)
        {
          KeyBinds.KeyBind keyBind = obj0;
          // ISSUE: virtual method pointer
          IntPtr num = __vmethodptr(keyBind, ToString);
          return KeyBinds.KeyBind.\u003Cdefault\u003Ecategory(keyBind);
        }
      }
    }

    public interface KeybindValue
    {
    }

    public class Section : Object
    {
      internal string __\u003C\u003Ename;
      [Signature("Larc/struct/ObjectMap<Larc/input/InputDevice$DeviceType;Larc/struct/OrderedMap<Larc/KeyBinds$KeyBind;Larc/KeyBinds$Axis;>;>;")]
      public ObjectMap binds;
      public InputDevice device;

      [LineNumberTable(new byte[] {160, 98, 232, 61, 107, 176, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal Section([In] string obj0)
      {
        KeyBinds.Section section = this;
        this.binds = new ObjectMap();
        this.device = (InputDevice) Core.input.getKeyboard();
        this.__\u003C\u003Ename = obj0;
      }

      [Modifiers]
      public string name
      {
        [HideFromJava] get => this.__\u003C\u003Ename;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ename = value;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Prov
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get() => (object) new OrderedMap();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons2
    {
      private readonly KeyBinds.KeyBind arg\u00241;

      internal __\u003C\u003EAnon1([In] KeyBinds.KeyBind obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0, [In] object obj1) => KeyBinds.lambda\u0024resetToDefault\u00240(this.arg\u00241, (InputDevice.DeviceType) obj0, (OrderedMap) obj1);
    }
  }
}
