// Decompiled with JetBrains decompiler
// Type: arc.util.OS
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.util
{
  public class OS : Object
  {
    internal static int __\u003C\u003Ecores;
    internal static string __\u003C\u003Eusername;
    internal static string __\u003C\u003Euserhome;
    public static bool isWindows;
    public static bool isLinux;
    public static bool isMac;
    public static bool isIos;
    public static bool isAndroid;
    public static bool isARM;
    public static bool is64Bit;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(108)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string env(string name) => java.lang.System.getenv(name);

    [LineNumberTable(96)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasProp(string name) => java.lang.System.getProperty(name) != null;

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string prop(string name) => java.lang.System.getProperty(name);

    [LineNumberTable(new byte[] {159, 182, 103, 127, 11, 110, 107, 106, 108, 107, 127, 9, 159, 2, 127, 21, 103, 159, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getAppDataDirectoryString(string appname)
    {
      if (OS.isWindows)
        return new StringBuilder().append(OS.env("AppData")).append("\\\\").append(appname).toString();
      if (OS.isIos || OS.isAndroid)
        return Core.files.getLocalStoragePath();
      if (OS.isLinux)
      {
        if (java.lang.System.getenv("XDG_DATA_HOME") == null)
          return new StringBuilder().append(OS.prop("user.home")).append("/.local/share/").append(appname).append("/").toString();
        string str = java.lang.System.getenv("XDG_DATA_HOME");
        if (!String.instancehelper_endsWith(str, "/"))
          str = new StringBuilder().append(str).append("/").toString();
        return new StringBuilder().append(str).append(appname).append("/").toString();
      }
      return OS.isMac ? new StringBuilder().append(OS.prop("user.home")).append("/Library/Application Support/").append(appname).append("/").toString() : (string) null;
    }

    [LineNumberTable(new byte[] {30, 155, 106, 141, 118, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool execSafe(string command)
    {
      int num;
      try
      {
        BufferedReader bufferedReader = new BufferedReader((Reader) new InputStreamReader(java.lang.Runtime.getRuntime().exec(command).getInputStream()));
        string str;
        while ((str = bufferedReader.readLine()) != null)
          java.lang.System.@out.println(str);
        num = 1;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_6;
      }
      return num != 0;
label_6:
      return false;
    }

    [LineNumberTable(new byte[] {62, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string propNoNull(string name) => OS.prop(name) ?? "";

    [LineNumberTable(8)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OS()
    {
    }

    [LineNumberTable(new byte[] {10, 108, 113, 134, 106, 180, 114, 107, 148, 127, 2, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string exec(params string[] args)
    {
      string str1;
      IOException ioException1;
      try
      {
        Process process = java.lang.Runtime.getRuntime().exec(args);
        BufferedReader bufferedReader1 = new BufferedReader((Reader) new InputStreamReader(process.getInputStream()));
        StringBuilder stringBuilder = new StringBuilder();
        string str2;
        while ((str2 = bufferedReader1.readLine()) != null)
          stringBuilder.append(str2).append("\n");
        BufferedReader bufferedReader2 = new BufferedReader((Reader) new InputStreamReader(process.getErrorStream()));
        string str3;
        while ((str3 = bufferedReader2.readLine()) != null)
          stringBuilder.append(str3).append("\n");
        str1 = stringBuilder.toString();
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_9;
      }
      return str1;
label_9:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Fi getAppDataDirectory(string appname) => Core.files.absolute(OS.getAppDataDirectoryString(appname));

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasEnv(string name) => java.lang.System.getenv(name) != null;

    [LineNumberTable(new byte[] {159, 140, 109, 111, 158, 127, 10, 127, 54, 127, 10, 102, 102, 127, 22, 191, 38, 127, 83, 102, 102, 102, 102, 166, 127, 19, 102, 102, 102, 102, 102, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static OS()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.OS"))
        return;
      OS.__\u003C\u003Ecores = java.lang.Runtime.getRuntime().availableProcessors();
      OS.__\u003C\u003Eusername = OS.prop("user.name");
      OS.__\u003C\u003Euserhome = OS.prop("user.home");
      string str1 = OS.propNoNull("os.name");
      object obj1 = (object) "Windows";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence charSequence2 = charSequence1;
      OS.isWindows = String.instancehelper_contains(str1, charSequence2);
      string str2 = OS.propNoNull("os.name");
      object obj2 = (object) "Linux";
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence3 = charSequence1;
      int num;
      if (!String.instancehelper_contains(str2, charSequence3))
      {
        string str3 = OS.propNoNull("os.name");
        object obj3 = (object) "BSD";
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence4 = charSequence1;
        if (!String.instancehelper_contains(str3, charSequence4))
        {
          num = 0;
          goto label_6;
        }
      }
      num = 1;
label_6:
      OS.isLinux = num != 0;
      string str4 = OS.propNoNull("os.name");
      object obj4 = (object) "Mac";
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      CharSequence charSequence5 = charSequence1;
      OS.isMac = String.instancehelper_contains(str4, charSequence5);
      OS.isIos = false;
      OS.isAndroid = false;
      OS.isARM = String.instancehelper_startsWith(OS.propNoNull("os.arch"), "arm") || String.instancehelper_startsWith(OS.propNoNull("os.arch"), "aarch64");
      string str5 = OS.propNoNull("os.arch");
      object obj5 = (object) "64";
      charSequence1.__\u003Cref\u003E = (__Null) obj5;
      CharSequence charSequence6 = charSequence1;
      OS.is64Bit = String.instancehelper_contains(str5, charSequence6) || String.instancehelper_startsWith(OS.propNoNull("os.arch"), "armv8");
      string str6 = OS.propNoNull("java.runtime.name");
      object obj6 = (object) "Android Runtime";
      charSequence1.__\u003Cref\u003E = (__Null) obj6;
      CharSequence charSequence7 = charSequence1;
      if (!String.instancehelper_contains(str6, charSequence7))
      {
        string str3 = OS.propNoNull("java.vm.vendor");
        object obj3 = (object) "The Android Project";
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence4 = charSequence1;
        if (!String.instancehelper_contains(str3, charSequence4))
        {
          string str7 = OS.propNoNull("java.vendor");
          object obj7 = (object) "The Android Project";
          charSequence1.__\u003Cref\u003E = (__Null) obj7;
          CharSequence charSequence8 = charSequence1;
          if (!String.instancehelper_contains(str7, charSequence8))
            goto label_10;
        }
      }
      OS.isAndroid = true;
      OS.isWindows = false;
      OS.isLinux = false;
      OS.isMac = false;
      OS.is64Bit = false;
label_10:
      if (!String.instancehelper_equals(OS.propNoNull("moe.platform.name"), (object) "iOS") && (OS.isAndroid || OS.isWindows || (OS.isLinux || OS.isMac)))
        return;
      OS.isIos = true;
      OS.isAndroid = false;
      OS.isWindows = false;
      OS.isLinux = false;
      OS.isMac = false;
      OS.is64Bit = false;
    }

    [Modifiers]
    public static int cores
    {
      [HideFromJava] get => OS.__\u003C\u003Ecores;
    }

    [Modifiers]
    public static string username
    {
      [HideFromJava] get => OS.__\u003C\u003Eusername;
    }

    [Modifiers]
    public static string userhome
    {
      [HideFromJava] get => OS.__\u003C\u003Euserhome;
    }
  }
}
