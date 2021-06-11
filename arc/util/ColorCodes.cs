// Decompiled with JetBrains decompiler
// Type: arc.util.ColorCodes
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class ColorCodes : Object
  {
    public static string flush;
    public static string reset;
    public static string bold;
    public static string italic;
    public static string underline;
    public static string black;
    public static string red;
    public static string green;
    public static string yellow;
    public static string blue;
    public static string purple;
    public static string cyan;
    public static string lightBlack;
    public static string lightRed;
    public static string lightGreen;
    public static string lightYellow;
    public static string lightBlue;
    public static string lightMagenta;
    public static string lightCyan;
    public static string lightWhite;
    public static string white;
    public static string backDefault;
    public static string backRed;
    public static string backGreen;
    public static string backYellow;
    public static string backBlue;
    internal static string[] __\u003C\u003Ecodes;
    internal static string[] __\u003C\u003Evalues;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ColorCodes()
    {
    }

    [LineNumberTable(new byte[] {159, 140, 77, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 106, 138, 106, 106, 106, 106, 234, 71, 113, 255, 160, 65, 69, 255, 161, 121, 94, 127, 0, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ColorCodes()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.ColorCodes"))
        return;
      ColorCodes.flush = "\u001B[H\u001B[2J";
      ColorCodes.reset = "\u001B[0m";
      ColorCodes.bold = "\u001B[1m";
      ColorCodes.italic = "\u001B[3m";
      ColorCodes.underline = "\u001B[4m";
      ColorCodes.black = "\u001B[30m";
      ColorCodes.red = "\u001B[31m";
      ColorCodes.green = "\u001B[32m";
      ColorCodes.yellow = "\u001B[33m";
      ColorCodes.blue = "\u001B[34m";
      ColorCodes.purple = "\u001B[35m";
      ColorCodes.cyan = "\u001B[36m";
      ColorCodes.lightBlack = "\u001B[90m";
      ColorCodes.lightRed = "\u001B[91m";
      ColorCodes.lightGreen = "\u001B[92m";
      ColorCodes.lightYellow = "\u001B[93m";
      ColorCodes.lightBlue = "\u001B[94m";
      ColorCodes.lightMagenta = "\u001B[95m";
      ColorCodes.lightCyan = "\u001B[96m";
      ColorCodes.lightWhite = "\u001B[97m";
      ColorCodes.white = "\u001B[37m";
      ColorCodes.backDefault = "\u001B[49m";
      ColorCodes.backRed = "\u001B[41m";
      ColorCodes.backGreen = "\u001B[42m";
      ColorCodes.backYellow = "\u001B[43m";
      ColorCodes.backBlue = "\u001B[44m";
      if (OS.isWindows || OS.isAndroid)
      {
        string str;
        ColorCodes.italic = str = "";
        ColorCodes.backGreen = str;
        ColorCodes.backBlue = str;
        ColorCodes.backYellow = str;
        ColorCodes.backRed = str;
        ColorCodes.backDefault = str;
        ColorCodes.white = str;
        ColorCodes.lightCyan = str;
        ColorCodes.lightMagenta = str;
        ColorCodes.lightBlue = str;
        ColorCodes.lightYellow = str;
        ColorCodes.lightGreen = str;
        ColorCodes.lightRed = str;
        ColorCodes.lightBlack = str;
        ColorCodes.lightWhite = str;
        ColorCodes.cyan = str;
        ColorCodes.purple = str;
        ColorCodes.blue = str;
        ColorCodes.yellow = str;
        ColorCodes.green = str;
        ColorCodes.red = str;
        ColorCodes.black = str;
        ColorCodes.underline = str;
        ColorCodes.bold = str;
        ColorCodes.reset = str;
        ColorCodes.flush = str;
      }
      ObjectMap objectMap = ObjectMap.of((object) "ff", (object) ColorCodes.flush, (object) "fr", (object) ColorCodes.reset, (object) "fb", (object) ColorCodes.bold, (object) "fi", (object) ColorCodes.italic, (object) "fu", (object) ColorCodes.underline, (object) "k", (object) ColorCodes.black, (object) "lk", (object) ColorCodes.lightBlack, (object) "lw", (object) ColorCodes.lightWhite, (object) "r", (object) ColorCodes.red, (object) "g", (object) ColorCodes.green, (object) "y", (object) ColorCodes.yellow, (object) "b", (object) ColorCodes.blue, (object) "p", (object) ColorCodes.purple, (object) "c", (object) ColorCodes.cyan, (object) "lr", (object) ColorCodes.lightRed, (object) "lg", (object) ColorCodes.lightGreen, (object) "ly", (object) ColorCodes.lightYellow, (object) "lm", (object) ColorCodes.lightMagenta, (object) "lb", (object) ColorCodes.lightBlue, (object) "lc", (object) ColorCodes.lightCyan, (object) "w", (object) ColorCodes.white, (object) "bd", (object) ColorCodes.backDefault, (object) "br", (object) ColorCodes.backRed, (object) "bg", (object) ColorCodes.backGreen, (object) "by", (object) ColorCodes.backYellow, (object) "bb", (object) ColorCodes.backBlue);
      ColorCodes.__\u003C\u003Ecodes = (string[]) objectMap.keys().toSeq().toArray((Class) ClassLiteral<String>.Value);
      ColorCodes.__\u003C\u003Evalues = (string[]) objectMap.values().toSeq().toArray((Class) ClassLiteral<String>.Value);
    }

    [Modifiers]
    public static string[] codes
    {
      [HideFromJava] get => ColorCodes.__\u003C\u003Ecodes;
    }

    [Modifiers]
    public static string[] values
    {
      [HideFromJava] get => ColorCodes.__\u003C\u003Evalues;
    }
  }
}
