// Decompiled with JetBrains decompiler
// Type: mindustry.input.Binding
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.input;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.input
{
  [Signature("Ljava/lang/Enum<Lmindustry/input/Binding;>;Larc/KeyBinds$KeyBind;")]
  [Modifiers]
  [Implements(new string[] {"arc.KeyBinds$KeyBind"})]
  [Serializable]
  public sealed class Binding : Enum, KeyBinds.KeyBind
  {
    [Modifiers]
    internal static Binding __\u003C\u003Emove_x;
    [Modifiers]
    internal static Binding __\u003C\u003Emove_y;
    [Modifiers]
    internal static Binding __\u003C\u003Emouse_move;
    [Modifiers]
    internal static Binding __\u003C\u003Epan;
    [Modifiers]
    internal static Binding __\u003C\u003Eboost;
    [Modifiers]
    internal static Binding __\u003C\u003Econtrol;
    [Modifiers]
    internal static Binding __\u003C\u003Erespawn;
    [Modifiers]
    internal static Binding __\u003C\u003Eselect;
    [Modifiers]
    internal static Binding __\u003C\u003Edeselect;
    [Modifiers]
    internal static Binding __\u003C\u003Ebreak_block;
    [Modifiers]
    internal static Binding __\u003C\u003EpickupCargo;
    [Modifiers]
    internal static Binding __\u003C\u003EdropCargo;
    [Modifiers]
    internal static Binding __\u003C\u003Ecommand;
    [Modifiers]
    internal static Binding __\u003C\u003Eclear_building;
    [Modifiers]
    internal static Binding __\u003C\u003Epause_building;
    [Modifiers]
    internal static Binding __\u003C\u003Erotate;
    [Modifiers]
    internal static Binding __\u003C\u003Erotateplaced;
    [Modifiers]
    internal static Binding __\u003C\u003Ediagonal_placement;
    [Modifiers]
    internal static Binding __\u003C\u003Epick;
    [Modifiers]
    internal static Binding __\u003C\u003Eschematic_select;
    [Modifiers]
    internal static Binding __\u003C\u003Eschematic_flip_x;
    [Modifiers]
    internal static Binding __\u003C\u003Eschematic_flip_y;
    [Modifiers]
    internal static Binding __\u003C\u003Eschematic_menu;
    [Modifiers]
    internal static Binding __\u003C\u003Ecategory_prev;
    [Modifiers]
    internal static Binding __\u003C\u003Ecategory_next;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_left;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_right;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_up;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_down;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_01;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_02;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_03;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_04;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_05;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_06;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_07;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_08;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_09;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_select_10;
    [Modifiers]
    internal static Binding __\u003C\u003Ezoom;
    [Modifiers]
    internal static Binding __\u003C\u003Emenu;
    [Modifiers]
    internal static Binding __\u003C\u003Efullscreen;
    [Modifiers]
    internal static Binding __\u003C\u003Epause;
    [Modifiers]
    internal static Binding __\u003C\u003Eminimap;
    [Modifiers]
    internal static Binding __\u003C\u003Eresearch;
    [Modifiers]
    internal static Binding __\u003C\u003Eplanet_map;
    [Modifiers]
    internal static Binding __\u003C\u003Eblock_info;
    [Modifiers]
    internal static Binding __\u003C\u003Etoggle_menus;
    [Modifiers]
    internal static Binding __\u003C\u003Escreenshot;
    [Modifiers]
    internal static Binding __\u003C\u003Etoggle_power_lines;
    [Modifiers]
    internal static Binding __\u003C\u003Etoggle_block_status;
    [Modifiers]
    internal static Binding __\u003C\u003Eplayer_list;
    [Modifiers]
    internal static Binding __\u003C\u003Echat;
    [Modifiers]
    internal static Binding __\u003C\u003Echat_history_prev;
    [Modifiers]
    internal static Binding __\u003C\u003Echat_history_next;
    [Modifiers]
    internal static Binding __\u003C\u003Echat_scroll;
    [Modifiers]
    internal static Binding __\u003C\u003Echat_mode;
    [Modifiers]
    internal static Binding __\u003C\u003Econsole;
    [Modifiers]
    private KeyBinds.KeybindValue defaultValue;
    [Modifiers]
    private string category;
    [Modifiers]
    private static Binding[] \u0024VALUES;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Binding[] values() => (Binding[]) Binding.\u0024VALUES.Clone();

    [Signature("(Larc/KeyBinds$KeybindValue;Ljava/lang/String;)V")]
    [LineNumberTable(new byte[] {30, 106, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Binding([In] string obj0, [In] int obj1, [In] KeyBinds.KeybindValue obj2, [In] string obj3)
      : base(obj0, obj1)
    {
      Binding binding = this;
      this.defaultValue = obj2;
      this.category = obj3;
      GC.KeepAlive((object) this);
    }

    [Signature("(Larc/KeyBinds$KeybindValue;)V")]
    [LineNumberTable(new byte[] {36, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Binding([In] string obj0, [In] int obj1, [In] KeyBinds.KeybindValue obj2)
      : this(obj0, obj1, obj2, (string) null)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Binding valueOf(string name) => (Binding) Enum.valueOf((Class) ClassLiteral<Binding>.Value, name);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeyBinds.KeybindValue defaultValue(InputDevice.DeviceType type) => this.defaultValue;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string category() => this.category;

    [LineNumberTable(new byte[] {159, 140, 109, 127, 5, 127, 0, 117, 149, 117, 117, 117, 117, 117, 150, 118, 150, 150, 118, 118, 123, 118, 118, 150, 118, 118, 118, 150, 123, 150, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 150, 127, 1, 127, 10, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 123, 118, 118, 118, 123, 118, 246, 159, 190})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Binding()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.input.Binding"))
        return;
      Binding.__\u003C\u003Emove_x = new Binding(nameof (move_x), 0, (KeyBinds.KeybindValue) new KeyBinds.Axis(KeyCode.__\u003C\u003Ea, KeyCode.__\u003C\u003Ed), "general");
      Binding.__\u003C\u003Emove_y = new Binding(nameof (move_y), 1, (KeyBinds.KeybindValue) new KeyBinds.Axis(KeyCode.__\u003C\u003Es, KeyCode.__\u003C\u003Ew));
      Binding.__\u003C\u003Emouse_move = new Binding(nameof (mouse_move), 2, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EmouseBack);
      Binding.__\u003C\u003Epan = new Binding(nameof (pan), 3, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EmouseForward);
      Binding.__\u003C\u003Eboost = new Binding(nameof (boost), 4, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EshiftLeft);
      Binding.__\u003C\u003Econtrol = new Binding(nameof (control), 5, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EcontrolLeft);
      Binding.__\u003C\u003Erespawn = new Binding(nameof (respawn), 6, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ev);
      Binding.__\u003C\u003Eselect = new Binding(nameof (select), 7, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EmouseLeft);
      Binding.__\u003C\u003Edeselect = new Binding(nameof (deselect), 8, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EmouseRight);
      Binding.__\u003C\u003Ebreak_block = new Binding(nameof (break_block), 9, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EmouseRight);
      Binding.__\u003C\u003EpickupCargo = new Binding(nameof (pickupCargo), 10, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EleftBracket);
      Binding.__\u003C\u003EdropCargo = new Binding(nameof (dropCargo), 11, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003ErightBracket);
      Binding.__\u003C\u003Ecommand = new Binding(nameof (command), 12, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eg);
      Binding.__\u003C\u003Eclear_building = new Binding(nameof (clear_building), 13, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eq);
      Binding.__\u003C\u003Epause_building = new Binding(nameof (pause_building), 14, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ee);
      Binding.__\u003C\u003Erotate = new Binding(nameof (rotate), 15, (KeyBinds.KeybindValue) new KeyBinds.Axis(KeyCode.__\u003C\u003Escroll));
      Binding.__\u003C\u003Erotateplaced = new Binding(nameof (rotateplaced), 16, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Er);
      Binding.__\u003C\u003Ediagonal_placement = new Binding(nameof (diagonal_placement), 17, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EcontrolLeft);
      Binding.__\u003C\u003Epick = new Binding(nameof (pick), 18, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003EmouseMiddle);
      Binding.__\u003C\u003Eschematic_select = new Binding(nameof (schematic_select), 19, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ef);
      Binding.__\u003C\u003Eschematic_flip_x = new Binding(nameof (schematic_flip_x), 20, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ez);
      Binding.__\u003C\u003Eschematic_flip_y = new Binding(nameof (schematic_flip_y), 21, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ex);
      Binding.__\u003C\u003Eschematic_menu = new Binding(nameof (schematic_menu), 22, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Et);
      Binding.__\u003C\u003Ecategory_prev = new Binding(nameof (category_prev), 23, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ecomma, "blocks");
      Binding.__\u003C\u003Ecategory_next = new Binding(nameof (category_next), 24, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eperiod);
      Binding.__\u003C\u003Eblock_select_left = new Binding(nameof (block_select_left), 25, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eleft);
      Binding.__\u003C\u003Eblock_select_right = new Binding(nameof (block_select_right), 26, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eright);
      Binding.__\u003C\u003Eblock_select_up = new Binding(nameof (block_select_up), 27, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eup);
      Binding.__\u003C\u003Eblock_select_down = new Binding(nameof (block_select_down), 28, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Edown);
      Binding.__\u003C\u003Eblock_select_01 = new Binding(nameof (block_select_01), 29, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum1);
      Binding.__\u003C\u003Eblock_select_02 = new Binding(nameof (block_select_02), 30, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum2);
      Binding.__\u003C\u003Eblock_select_03 = new Binding(nameof (block_select_03), 31, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum3);
      Binding.__\u003C\u003Eblock_select_04 = new Binding(nameof (block_select_04), 32, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum4);
      Binding.__\u003C\u003Eblock_select_05 = new Binding(nameof (block_select_05), 33, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum5);
      Binding.__\u003C\u003Eblock_select_06 = new Binding(nameof (block_select_06), 34, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum6);
      Binding.__\u003C\u003Eblock_select_07 = new Binding(nameof (block_select_07), 35, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum7);
      Binding.__\u003C\u003Eblock_select_08 = new Binding(nameof (block_select_08), 36, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum8);
      Binding.__\u003C\u003Eblock_select_09 = new Binding(nameof (block_select_09), 37, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum9);
      Binding.__\u003C\u003Eblock_select_10 = new Binding(nameof (block_select_10), 38, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Enum0);
      Binding.__\u003C\u003Ezoom = new Binding(nameof (zoom), 39, (KeyBinds.KeybindValue) new KeyBinds.Axis(KeyCode.__\u003C\u003Escroll), "view");
      Binding.__\u003C\u003Emenu = new Binding(nameof (menu), 40, !Core.app.isAndroid() ? (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eescape : (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eback);
      Binding.__\u003C\u003Efullscreen = new Binding(nameof (fullscreen), 41, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ef11);
      Binding.__\u003C\u003Epause = new Binding(nameof (pause), 42, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Espace);
      Binding.__\u003C\u003Eminimap = new Binding(nameof (minimap), 43, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Em);
      Binding.__\u003C\u003Eresearch = new Binding(nameof (research), 44, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eb);
      Binding.__\u003C\u003Eplanet_map = new Binding(nameof (planet_map), 45, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003En);
      Binding.__\u003C\u003Eblock_info = new Binding(nameof (block_info), 46, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ef1);
      Binding.__\u003C\u003Etoggle_menus = new Binding(nameof (toggle_menus), 47, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ec);
      Binding.__\u003C\u003Escreenshot = new Binding(nameof (screenshot), 48, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ep);
      Binding.__\u003C\u003Etoggle_power_lines = new Binding(nameof (toggle_power_lines), 49, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ef5);
      Binding.__\u003C\u003Etoggle_block_status = new Binding(nameof (toggle_block_status), 50, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ef6);
      Binding.__\u003C\u003Eplayer_list = new Binding(nameof (player_list), 51, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Etab, "multiplayer");
      Binding.__\u003C\u003Echat = new Binding(nameof (chat), 52, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eenter);
      Binding.__\u003C\u003Echat_history_prev = new Binding(nameof (chat_history_prev), 53, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Eup);
      Binding.__\u003C\u003Echat_history_next = new Binding(nameof (chat_history_next), 54, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Edown);
      Binding.__\u003C\u003Echat_scroll = new Binding(nameof (chat_scroll), 55, (KeyBinds.KeybindValue) new KeyBinds.Axis(KeyCode.__\u003C\u003Escroll));
      Binding.__\u003C\u003Echat_mode = new Binding(nameof (chat_mode), 56, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Etab);
      Binding.__\u003C\u003Econsole = new Binding(nameof (console), 57, (KeyBinds.KeybindValue) KeyCode.__\u003C\u003Ef8);
      Binding.\u0024VALUES = new Binding[58]
      {
        Binding.__\u003C\u003Emove_x,
        Binding.__\u003C\u003Emove_y,
        Binding.__\u003C\u003Emouse_move,
        Binding.__\u003C\u003Epan,
        Binding.__\u003C\u003Eboost,
        Binding.__\u003C\u003Econtrol,
        Binding.__\u003C\u003Erespawn,
        Binding.__\u003C\u003Eselect,
        Binding.__\u003C\u003Edeselect,
        Binding.__\u003C\u003Ebreak_block,
        Binding.__\u003C\u003EpickupCargo,
        Binding.__\u003C\u003EdropCargo,
        Binding.__\u003C\u003Ecommand,
        Binding.__\u003C\u003Eclear_building,
        Binding.__\u003C\u003Epause_building,
        Binding.__\u003C\u003Erotate,
        Binding.__\u003C\u003Erotateplaced,
        Binding.__\u003C\u003Ediagonal_placement,
        Binding.__\u003C\u003Epick,
        Binding.__\u003C\u003Eschematic_select,
        Binding.__\u003C\u003Eschematic_flip_x,
        Binding.__\u003C\u003Eschematic_flip_y,
        Binding.__\u003C\u003Eschematic_menu,
        Binding.__\u003C\u003Ecategory_prev,
        Binding.__\u003C\u003Ecategory_next,
        Binding.__\u003C\u003Eblock_select_left,
        Binding.__\u003C\u003Eblock_select_right,
        Binding.__\u003C\u003Eblock_select_up,
        Binding.__\u003C\u003Eblock_select_down,
        Binding.__\u003C\u003Eblock_select_01,
        Binding.__\u003C\u003Eblock_select_02,
        Binding.__\u003C\u003Eblock_select_03,
        Binding.__\u003C\u003Eblock_select_04,
        Binding.__\u003C\u003Eblock_select_05,
        Binding.__\u003C\u003Eblock_select_06,
        Binding.__\u003C\u003Eblock_select_07,
        Binding.__\u003C\u003Eblock_select_08,
        Binding.__\u003C\u003Eblock_select_09,
        Binding.__\u003C\u003Eblock_select_10,
        Binding.__\u003C\u003Ezoom,
        Binding.__\u003C\u003Emenu,
        Binding.__\u003C\u003Efullscreen,
        Binding.__\u003C\u003Epause,
        Binding.__\u003C\u003Eminimap,
        Binding.__\u003C\u003Eresearch,
        Binding.__\u003C\u003Eplanet_map,
        Binding.__\u003C\u003Eblock_info,
        Binding.__\u003C\u003Etoggle_menus,
        Binding.__\u003C\u003Escreenshot,
        Binding.__\u003C\u003Etoggle_power_lines,
        Binding.__\u003C\u003Etoggle_block_status,
        Binding.__\u003C\u003Eplayer_list,
        Binding.__\u003C\u003Echat,
        Binding.__\u003C\u003Echat_history_prev,
        Binding.__\u003C\u003Echat_history_next,
        Binding.__\u003C\u003Echat_scroll,
        Binding.__\u003C\u003Echat_mode,
        Binding.__\u003C\u003Econsole
      };
    }

    string KeyBinds.KeyBind.__\u003Coverridestub\u003Earc\u002EKeyBinds\u0024KeyBind\u003A\u003Aname() => this.name();

    [Modifiers]
    public static Binding move_x
    {
      [HideFromJava] get => Binding.__\u003C\u003Emove_x;
    }

    [Modifiers]
    public static Binding move_y
    {
      [HideFromJava] get => Binding.__\u003C\u003Emove_y;
    }

    [Modifiers]
    public static Binding mouse_move
    {
      [HideFromJava] get => Binding.__\u003C\u003Emouse_move;
    }

    [Modifiers]
    public static Binding pan
    {
      [HideFromJava] get => Binding.__\u003C\u003Epan;
    }

    [Modifiers]
    public static Binding boost
    {
      [HideFromJava] get => Binding.__\u003C\u003Eboost;
    }

    [Modifiers]
    public static Binding control
    {
      [HideFromJava] get => Binding.__\u003C\u003Econtrol;
    }

    [Modifiers]
    public static Binding respawn
    {
      [HideFromJava] get => Binding.__\u003C\u003Erespawn;
    }

    [Modifiers]
    public static Binding select
    {
      [HideFromJava] get => Binding.__\u003C\u003Eselect;
    }

    [Modifiers]
    public static Binding deselect
    {
      [HideFromJava] get => Binding.__\u003C\u003Edeselect;
    }

    [Modifiers]
    public static Binding break_block
    {
      [HideFromJava] get => Binding.__\u003C\u003Ebreak_block;
    }

    [Modifiers]
    public static Binding pickupCargo
    {
      [HideFromJava] get => Binding.__\u003C\u003EpickupCargo;
    }

    [Modifiers]
    public static Binding dropCargo
    {
      [HideFromJava] get => Binding.__\u003C\u003EdropCargo;
    }

    [Modifiers]
    public static Binding command
    {
      [HideFromJava] get => Binding.__\u003C\u003Ecommand;
    }

    [Modifiers]
    public static Binding clear_building
    {
      [HideFromJava] get => Binding.__\u003C\u003Eclear_building;
    }

    [Modifiers]
    public static Binding pause_building
    {
      [HideFromJava] get => Binding.__\u003C\u003Epause_building;
    }

    [Modifiers]
    public static Binding rotate
    {
      [HideFromJava] get => Binding.__\u003C\u003Erotate;
    }

    [Modifiers]
    public static Binding rotateplaced
    {
      [HideFromJava] get => Binding.__\u003C\u003Erotateplaced;
    }

    [Modifiers]
    public static Binding diagonal_placement
    {
      [HideFromJava] get => Binding.__\u003C\u003Ediagonal_placement;
    }

    [Modifiers]
    public static Binding pick
    {
      [HideFromJava] get => Binding.__\u003C\u003Epick;
    }

    [Modifiers]
    public static Binding schematic_select
    {
      [HideFromJava] get => Binding.__\u003C\u003Eschematic_select;
    }

    [Modifiers]
    public static Binding schematic_flip_x
    {
      [HideFromJava] get => Binding.__\u003C\u003Eschematic_flip_x;
    }

    [Modifiers]
    public static Binding schematic_flip_y
    {
      [HideFromJava] get => Binding.__\u003C\u003Eschematic_flip_y;
    }

    [Modifiers]
    public static Binding schematic_menu
    {
      [HideFromJava] get => Binding.__\u003C\u003Eschematic_menu;
    }

    [Modifiers]
    public static Binding category_prev
    {
      [HideFromJava] get => Binding.__\u003C\u003Ecategory_prev;
    }

    [Modifiers]
    public static Binding category_next
    {
      [HideFromJava] get => Binding.__\u003C\u003Ecategory_next;
    }

    [Modifiers]
    public static Binding block_select_left
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_left;
    }

    [Modifiers]
    public static Binding block_select_right
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_right;
    }

    [Modifiers]
    public static Binding block_select_up
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_up;
    }

    [Modifiers]
    public static Binding block_select_down
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_down;
    }

    [Modifiers]
    public static Binding block_select_01
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_01;
    }

    [Modifiers]
    public static Binding block_select_02
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_02;
    }

    [Modifiers]
    public static Binding block_select_03
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_03;
    }

    [Modifiers]
    public static Binding block_select_04
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_04;
    }

    [Modifiers]
    public static Binding block_select_05
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_05;
    }

    [Modifiers]
    public static Binding block_select_06
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_06;
    }

    [Modifiers]
    public static Binding block_select_07
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_07;
    }

    [Modifiers]
    public static Binding block_select_08
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_08;
    }

    [Modifiers]
    public static Binding block_select_09
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_09;
    }

    [Modifiers]
    public static Binding block_select_10
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_select_10;
    }

    [Modifiers]
    public static Binding zoom
    {
      [HideFromJava] get => Binding.__\u003C\u003Ezoom;
    }

    [Modifiers]
    public static Binding menu
    {
      [HideFromJava] get => Binding.__\u003C\u003Emenu;
    }

    [Modifiers]
    public static Binding fullscreen
    {
      [HideFromJava] get => Binding.__\u003C\u003Efullscreen;
    }

    [Modifiers]
    public static Binding pause
    {
      [HideFromJava] get => Binding.__\u003C\u003Epause;
    }

    [Modifiers]
    public static Binding minimap
    {
      [HideFromJava] get => Binding.__\u003C\u003Eminimap;
    }

    [Modifiers]
    public static Binding research
    {
      [HideFromJava] get => Binding.__\u003C\u003Eresearch;
    }

    [Modifiers]
    public static Binding planet_map
    {
      [HideFromJava] get => Binding.__\u003C\u003Eplanet_map;
    }

    [Modifiers]
    public static Binding block_info
    {
      [HideFromJava] get => Binding.__\u003C\u003Eblock_info;
    }

    [Modifiers]
    public static Binding toggle_menus
    {
      [HideFromJava] get => Binding.__\u003C\u003Etoggle_menus;
    }

    [Modifiers]
    public static Binding screenshot
    {
      [HideFromJava] get => Binding.__\u003C\u003Escreenshot;
    }

    [Modifiers]
    public static Binding toggle_power_lines
    {
      [HideFromJava] get => Binding.__\u003C\u003Etoggle_power_lines;
    }

    [Modifiers]
    public static Binding toggle_block_status
    {
      [HideFromJava] get => Binding.__\u003C\u003Etoggle_block_status;
    }

    [Modifiers]
    public static Binding player_list
    {
      [HideFromJava] get => Binding.__\u003C\u003Eplayer_list;
    }

    [Modifiers]
    public static Binding chat
    {
      [HideFromJava] get => Binding.__\u003C\u003Echat;
    }

    [Modifiers]
    public static Binding chat_history_prev
    {
      [HideFromJava] get => Binding.__\u003C\u003Echat_history_prev;
    }

    [Modifiers]
    public static Binding chat_history_next
    {
      [HideFromJava] get => Binding.__\u003C\u003Echat_history_next;
    }

    [Modifiers]
    public static Binding chat_scroll
    {
      [HideFromJava] get => Binding.__\u003C\u003Echat_scroll;
    }

    [Modifiers]
    public static Binding chat_mode
    {
      [HideFromJava] get => Binding.__\u003C\u003Echat_mode;
    }

    [Modifiers]
    public static Binding console
    {
      [HideFromJava] get => Binding.__\u003C\u003Econsole;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
      move_x,
      move_y,
      mouse_move,
      pan,
      boost,
      control,
      respawn,
      select,
      deselect,
      break_block,
      pickupCargo,
      dropCargo,
      command,
      clear_building,
      pause_building,
      rotate,
      rotateplaced,
      diagonal_placement,
      pick,
      schematic_select,
      schematic_flip_x,
      schematic_flip_y,
      schematic_menu,
      category_prev,
      category_next,
      block_select_left,
      block_select_right,
      block_select_up,
      block_select_down,
      block_select_01,
      block_select_02,
      block_select_03,
      block_select_04,
      block_select_05,
      block_select_06,
      block_select_07,
      block_select_08,
      block_select_09,
      block_select_10,
      zoom,
      menu,
      fullscreen,
      pause,
      minimap,
      research,
      planet_map,
      block_info,
      toggle_menus,
      screenshot,
      toggle_power_lines,
      toggle_block_status,
      player_list,
      chat,
      chat_history_prev,
      chat_history_next,
      chat_scroll,
      chat_mode,
      console,
    }
  }
}
