// Decompiled with JetBrains decompiler
// Type: arc.graphics.Colors
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics
{
  public sealed class Colors : Object
  {
    [Modifiers]
    [Signature("Larc/struct/OrderedMap<Ljava/lang/String;Larc/graphics/Color;>;")]
    private static OrderedMap map;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color get(string name) => (Color) Colors.map.get((object) name);

    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Color put(string name, Color color) => (Color) Colors.map.put((object) name, (object) color);

    [LineNumberTable(new byte[] {4, 106, 117, 149, 117, 117, 117, 117, 117, 117, 149, 117, 117, 117, 117, 117, 117, 149, 122, 117, 117, 117, 149, 117, 117, 117, 149, 117, 117, 149, 122, 117, 117, 117, 117, 117, 149, 117, 117, 213, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void reset()
    {
      Colors.map.clear();
      Colors.map.put((object) "CLEAR", (object) Color.__\u003C\u003Eclear);
      Colors.map.put((object) "BLACK", (object) Color.__\u003C\u003Eblack);
      Colors.map.put((object) "WHITE", (object) Color.__\u003C\u003Ewhite);
      Colors.map.put((object) "LIGHT_GRAY", (object) Color.__\u003C\u003ElightGray);
      Colors.map.put((object) "GRAY", (object) Color.__\u003C\u003Egray);
      Colors.map.put((object) "DARK_GRAY", (object) Color.__\u003C\u003EdarkGray);
      Colors.map.put((object) "LIGHT_GREY", (object) Color.__\u003C\u003ElightGray);
      Colors.map.put((object) "GREY", (object) Color.__\u003C\u003Egray);
      Colors.map.put((object) "DARK_GREY", (object) Color.__\u003C\u003EdarkGray);
      Colors.map.put((object) "BLUE", (object) Color.__\u003C\u003Eroyal);
      Colors.map.put((object) "NAVY", (object) Color.__\u003C\u003Enavy);
      Colors.map.put((object) "ROYAL", (object) Color.__\u003C\u003Eroyal);
      Colors.map.put((object) "SLATE", (object) Color.__\u003C\u003Eslate);
      Colors.map.put((object) "SKY", (object) Color.__\u003C\u003Esky);
      Colors.map.put((object) "CYAN", (object) Color.__\u003C\u003Ecyan);
      Colors.map.put((object) "TEAL", (object) Color.__\u003C\u003Eteal);
      Colors.map.put((object) "GREEN", (object) Color.valueOf("38d667"));
      Colors.map.put((object) "ACID", (object) Color.__\u003C\u003Eacid);
      Colors.map.put((object) "LIME", (object) Color.__\u003C\u003Elime);
      Colors.map.put((object) "FOREST", (object) Color.__\u003C\u003Eforest);
      Colors.map.put((object) "OLIVE", (object) Color.__\u003C\u003Eolive);
      Colors.map.put((object) "YELLOW", (object) Color.__\u003C\u003Eyellow);
      Colors.map.put((object) "GOLD", (object) Color.__\u003C\u003Egold);
      Colors.map.put((object) "GOLDENROD", (object) Color.__\u003C\u003Egoldenrod);
      Colors.map.put((object) "ORANGE", (object) Color.__\u003C\u003Eorange);
      Colors.map.put((object) "BROWN", (object) Color.__\u003C\u003Ebrown);
      Colors.map.put((object) "TAN", (object) Color.__\u003C\u003Etan);
      Colors.map.put((object) "BRICK", (object) Color.__\u003C\u003Ebrick);
      Colors.map.put((object) "RED", (object) Color.valueOf("e55454"));
      Colors.map.put((object) "SCARLET", (object) Color.__\u003C\u003Escarlet);
      Colors.map.put((object) "CRIMSON", (object) Color.__\u003C\u003Ecrimson);
      Colors.map.put((object) "CORAL", (object) Color.__\u003C\u003Ecoral);
      Colors.map.put((object) "SALMON", (object) Color.__\u003C\u003Esalmon);
      Colors.map.put((object) "PINK", (object) Color.__\u003C\u003Epink);
      Colors.map.put((object) "MAGENTA", (object) Color.__\u003C\u003Emagenta);
      Colors.map.put((object) "PURPLE", (object) Color.__\u003C\u003Epurple);
      Colors.map.put((object) "VIOLET", (object) Color.__\u003C\u003Eviolet);
      Colors.map.put((object) "MAROON", (object) Color.__\u003C\u003Emaroon);
      Colors.map.copy().each((Cons2) new Colors.__\u003C\u003EAnon0());
    }

    [Modifiers]
    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024reset\u00240([In] string obj0, [In] Color obj1)
    {
      OrderedMap map = Colors.map;
      string lowerCase = String.instancehelper_toLowerCase(obj0, (Locale) Locale.ROOT);
      object obj2 = (object) "";
      object obj3 = (object) "_";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence2 = charSequence1;
      object obj4 = obj2;
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      CharSequence charSequence3 = charSequence1;
      string str = String.instancehelper_replace(lowerCase, charSequence2, charSequence3);
      Color color = obj1;
      map.put((object) str, (object) color);
    }

    [LineNumberTable(new byte[] {159, 162, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Colors()
    {
    }

    [Signature("()Larc/struct/OrderedMap<Ljava/lang/String;Larc/graphics/Color;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static OrderedMap getColors() => Colors.map;

    [LineNumberTable(new byte[] {159, 139, 141, 170, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Colors()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.Colors"))
        return;
      Colors.map = new OrderedMap();
      Colors.reset();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons2
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0, [In] object obj1) => Colors.lambda\u0024reset\u00240((string) obj0, (Color) obj1);
    }
  }
}
