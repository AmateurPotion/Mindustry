// Decompiled with JetBrains decompiler
// Type: mindustry.core.Version
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.core
{
  public class Version : Object
  {
    public static string type;
    public static string modifier;
    public static int number;
    public static int build;
    public static int revision;
    public static bool enabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 167, 136, 159, 16, 102, 140, 117, 127, 0, 117, 127, 16, 156, 110, 223, 3, 226, 61, 98, 103, 134, 98, 159, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init()
    {
      if (!Version.enabled)
        return;
      Fi fi = OS.isAndroid || OS.isIos ? Core.files.@internal("version.properties") : new Fi("version.properties", Files.FileType.__\u003C\u003Einternal);
      ObjectMap properties = new ObjectMap();
      PropertiesUtils.load(properties, fi.reader());
      Version.type = (string) properties.get((object) "type");
      Version.number = Integer.parseInt((string) properties.get((object) "number", (object) "4"));
      Version.modifier = (string) properties.get((object) "modifier");
      string str = (string) properties.get((object) "build");
      object obj = (object) ".";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      if (String.instancehelper_contains(str, charSequence2))
      {
        string[] strArray = String.instancehelper_split((string) properties.get((object) "build"), "\\.");
        Exception exception;
        try
        {
          Version.build = Integer.parseInt(strArray[0]);
          Version.revision = Integer.parseInt(strArray[1]);
          return;
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Throwable.instancehelper_printStackTrace(exception);
        Version.build = -1;
      }
      else
        Version.build = !Strings.canParseInt((string) properties.get((object) "build")) ? -1 : Integer.parseInt((string) properties.get((object) "build"));
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Version()
    {
    }

    [LineNumberTable(new byte[] {1, 149, 105, 100, 127, 0, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isAtLeast(string str)
    {
      if (Version.build <= 0 || str == null || String.instancehelper_isEmpty(str))
        return true;
      int num1 = String.instancehelper_indexOf(str, 46);
      if (num1 == -1)
        return Version.build >= Strings.parseInt(str, 0);
      int num2 = Strings.parseInt(String.instancehelper_substring(str, 0, num1), 0);
      int num3 = Strings.parseInt(String.instancehelper_substring(str, num1 + 1), 0);
      return Version.build > num2 || Version.build == num2 && Version.revision >= num3;
    }

    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string buildString() => Version.build < 0 ? "custom" : new StringBuilder().append(Version.build).append(Version.revision != 0 ? new StringBuilder().append(".").append(Version.revision).toString() : "").toString();

    [LineNumberTable(new byte[] {18, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string combined() => Version.build == -1 ? "custom build" : new StringBuilder().append(!String.instancehelper_equals(Version.type, (object) "official") ? Version.type : Version.modifier).append(" build ").append(Version.build).append(Version.revision != 0 ? new StringBuilder().append(".").append(Version.revision).toString() : "").toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    static Version()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.core.Version"))
        return;
      Version.type = "unknown";
      Version.modifier = "unknown";
      Version.build = 0;
      Version.revision = 0;
      Version.enabled = true;
    }
  }
}
