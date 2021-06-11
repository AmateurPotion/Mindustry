// Decompiled with JetBrains decompiler
// Type: com.sun.jna.Platform
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util.logging;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public sealed class Platform : Object
  {
    public const int UNSPECIFIED = -1;
    public const int MAC = 0;
    public const int LINUX = 1;
    public const int WINDOWS = 2;
    public const int SOLARIS = 3;
    public const int FREEBSD = 4;
    public const int OPENBSD = 5;
    public const int WINDOWSCE = 6;
    public const int AIX = 7;
    public const int ANDROID = 8;
    public const int GNU = 9;
    public const int KFREEBSD = 10;
    public const int NETBSD = 11;
    internal static bool __\u003C\u003ERO_FIELDS;
    internal static bool __\u003C\u003EHAS_BUFFERS;
    internal static bool __\u003C\u003EHAS_AWT;
    internal static bool __\u003C\u003EHAS_JAWT;
    internal static string __\u003C\u003EMATH_LIBRARY_NAME;
    internal static string __\u003C\u003EC_LIBRARY_NAME;
    internal static bool __\u003C\u003EHAS_DLL_CALLBACKS;
    internal static string __\u003C\u003ERESOURCE_PREFIX;
    [Modifiers]
    private static int osType;
    internal static string __\u003C\u003EARCH;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isWindows() => Platform.osType == 2 || Platform.osType == 6;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isMac() => Platform.osType == 0;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 100, 113, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isPPC() => String.instancehelper_startsWith(Platform.__\u003C\u003EARCH, "ppc");

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isAIX() => Platform.osType == 7;

    [Modifiers]
    [LineNumberTable(225)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isSPARC() => String.instancehelper_startsWith(Platform.__\u003C\u003EARCH, "sparc");

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isLinux() => Platform.osType == 1;

    [Modifiers]
    [LineNumberTable(221)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isARM() => String.instancehelper_startsWith(Platform.__\u003C\u003EARCH, "arm");

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isAndroid() => Platform.osType == 8;

    [Modifiers]
    [LineNumberTable(183)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isX11() => !Platform.isWindows() && !Platform.isMac();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isFreeBSD() => Platform.osType == 4;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool iskFreeBSD() => Platform.osType == 10;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isGNU() => Platform.osType == 9;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 93, 113, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isIntel() => String.instancehelper_startsWith(Platform.__\u003C\u003EARCH, "x86");

    [Modifiers]
    [LineNumberTable(new byte[] {160, 77, 106, 37, 134, 99, 140, 123, 113, 127, 3, 113, 103, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool is64Bit()
    {
      string property = java.lang.System.getProperty("sun.arch.data.model", java.lang.System.getProperty("com.ibm.vm.bitmode"));
      if (property != null)
        return String.instancehelper_equals("64", (object) property);
      return String.instancehelper_equals("x86-64", (object) Platform.__\u003C\u003EARCH) || String.instancehelper_equals("ia64", (object) Platform.__\u003C\u003EARCH) || (String.instancehelper_equals("ppc64", (object) Platform.__\u003C\u003EARCH) || String.instancehelper_equals("ppc64le", (object) Platform.__\u003C\u003EARCH)) || (String.instancehelper_equals("sparcv9", (object) Platform.__\u003C\u003EARCH) || String.instancehelper_equals("amd64", (object) Platform.__\u003C\u003EARCH)) || Native.__\u003C\u003EPOINTER_SIZE == 8;
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isSolaris() => Platform.osType == 3;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isWindowsCE() => Platform.osType == 6;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getOSType() => Platform.osType;

    [LineNumberTable(287)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getNativeLibraryResourcePrefix([In] int obj0, [In] string obj1, [In] string obj2) => Platform.getNativeLibraryResourcePrefix(obj0, obj1, obj2, Platform.isSoftFloat());

    [LineNumberTable(new byte[] {160, 144, 107, 108, 124, 130, 159, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isSoftFloat()
    {
      int num;
      IOException ioException1;
      try
      {
        num = ELFAnalyser.analyse(new File("/proc/self/exe").getCanonicalPath()).isArmSoftFloat() ? 1 : 0;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return num != 0;
label_3:
      IOException ioException2 = ioException1;
      Logger.getLogger(((Class) ClassLiteral<Platform>.Value).getName(), Platform.__\u003CGetCallerID\u003E()).log((Level) Level.FINE, (string) null, (Exception) ioException2);
      return false;
    }

    [LineNumberTable(new byte[] {159, 69, 66, 105, 159, 28, 109, 135, 123, 133, 123, 133, 123, 133, 102, 133, 123, 133, 123, 133, 123, 133, 123, 133, 123, 133, 123, 130, 103, 108, 100, 137, 191, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getNativeLibraryResourcePrefix(
      [In] int obj0,
      [In] string obj1,
      [In] string obj2,
      [In] bool obj3)
    {
      int num1 = obj3 ? 1 : 0;
      obj1 = Platform.getCanonicalArchitecture(obj1, num1 != 0);
      string str1;
      switch (obj0)
      {
        case 0:
          str1 = "darwin";
          break;
        case 1:
          str1 = new StringBuilder().append("linux-").append(obj1).toString();
          break;
        case 2:
          str1 = new StringBuilder().append("win32-").append(obj1).toString();
          break;
        case 3:
          str1 = new StringBuilder().append("sunos-").append(obj1).toString();
          break;
        case 4:
          str1 = new StringBuilder().append("freebsd-").append(obj1).toString();
          break;
        case 5:
          str1 = new StringBuilder().append("openbsd-").append(obj1).toString();
          break;
        case 6:
          str1 = new StringBuilder().append("w32ce-").append(obj1).toString();
          break;
        case 8:
          if (String.instancehelper_startsWith(obj1, "arm"))
            obj1 = "arm";
          str1 = new StringBuilder().append("android-").append(obj1).toString();
          break;
        case 10:
          str1 = new StringBuilder().append("kfreebsd-").append(obj1).toString();
          break;
        case 11:
          str1 = new StringBuilder().append("netbsd-").append(obj1).toString();
          break;
        default:
          string str2 = String.instancehelper_toLowerCase(obj2);
          int num2 = String.instancehelper_indexOf(str2, " ");
          if (num2 != -1)
            str2 = String.instancehelper_substring(str2, 0, num2);
          str1 = new StringBuilder().append(str2).append("-").append(obj1).toString();
          break;
      }
      return str1;
    }

    [LineNumberTable(new byte[] {159, 85, 98, 109, 109, 137, 109, 137, 122, 137, 122, 199, 127, 4, 167, 112, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getCanonicalArchitecture([In] string obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      obj0 = String.instancehelper_trim(String.instancehelper_toLowerCase(obj0));
      if (String.instancehelper_equals("powerpc", (object) obj0))
        obj0 = "ppc";
      else if (String.instancehelper_equals("powerpc64", (object) obj0))
        obj0 = "ppc64";
      else if (String.instancehelper_equals("i386", (object) obj0) || String.instancehelper_equals("i686", (object) obj0))
        obj0 = "x86";
      else if (String.instancehelper_equals("x86_64", (object) obj0) || String.instancehelper_equals("amd64", (object) obj0))
        obj0 = "x86-64";
      if (String.instancehelper_equals("ppc64", (object) obj0) && String.instancehelper_equals("little", (object) java.lang.System.getProperty("sun.cpu.endian")))
        obj0 = "ppc64le";
      if (String.instancehelper_equals("arm", (object) obj0) && num != 0)
        obj0 = "armel";
      return obj0;
    }

    [LineNumberTable(new byte[] {160, 158, 107, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string getNativeLibraryResourcePrefix() => java.lang.System.getProperty("jna.prefix") ?? Platform.getNativeLibraryResourcePrefix(Platform.getOSType(), java.lang.System.getProperty("os.arch"), java.lang.System.getProperty("os.name"));

    [LineNumberTable(136)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Platform()
    {
    }

    [Modifiers]
    [Obsolete]
    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isAix() => Platform.isAIX();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isOpenBSD() => Platform.osType == 5;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isNetBSD() => Platform.osType == 11;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 72, 125, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool hasRuntimeExec() => !Platform.isWindowsCE() || !String.instancehelper_equals("J9", (object) java.lang.System.getProperty("java.vm.name"));

    [LineNumberTable(new byte[] {159, 124, 77, 107, 109, 123, 134, 181, 171, 109, 139, 122, 139, 109, 139, 109, 139, 122, 139, 109, 139, 109, 136, 109, 137, 109, 137, 109, 169, 134, 130, 112, 173, 34, 225, 69, 127, 2, 119, 102, 112, 127, 9, 127, 9, 109, 121, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Platform()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.Platform"))
        return;
      string property = java.lang.System.getProperty("os.name");
      if (String.instancehelper_startsWith(property, "Linux"))
      {
        if (String.instancehelper_equals("dalvik", (object) String.instancehelper_toLowerCase(java.lang.System.getProperty("java.vm.name"))))
        {
          Platform.osType = 8;
          java.lang.System.setProperty("jna.nounpack", "true");
        }
        else
          Platform.osType = 1;
      }
      else
        Platform.osType = !String.instancehelper_startsWith(property, nameof (AIX)) ? (String.instancehelper_startsWith(property, "Mac") || String.instancehelper_startsWith(property, "Darwin") ? 0 : (!String.instancehelper_startsWith(property, "Windows CE") ? (!String.instancehelper_startsWith(property, "Windows") ? (String.instancehelper_startsWith(property, "Solaris") || String.instancehelper_startsWith(property, "SunOS") ? 3 : (!String.instancehelper_startsWith(property, "FreeBSD") ? (!String.instancehelper_startsWith(property, "OpenBSD") ? (!String.instancehelper_equalsIgnoreCase(property, "gnu") ? (!String.instancehelper_equalsIgnoreCase(property, "gnu/kfreebsd") ? (!String.instancehelper_equalsIgnoreCase(property, "netbsd") ? -1 : 11) : 10) : 9) : 5) : 4)) : 2) : 6)) : 7;
      int num = 0;
      try
      {
        Class.forName("java.nio.Buffer", Platform.__\u003CGetCallerID\u003E());
        num = 1;
        goto label_11;
      }
      catch (ClassNotFoundException ex)
      {
      }
label_11:
      Platform.__\u003C\u003EHAS_AWT = Platform.osType != 6 && Platform.osType != 8 && Platform.osType != 7;
      Platform.__\u003C\u003EHAS_JAWT = Platform.__\u003C\u003EHAS_AWT && Platform.osType != 0;
      Platform.__\u003C\u003EHAS_BUFFERS = num != 0;
      Platform.__\u003C\u003ERO_FIELDS = Platform.osType != 6;
      string str1;
      switch (Platform.osType)
      {
        case 2:
          str1 = "msvcrt";
          break;
        case 6:
          str1 = "coredll";
          break;
        default:
          str1 = "c";
          break;
      }
      Platform.__\u003C\u003EC_LIBRARY_NAME = str1;
      string str2;
      switch (Platform.osType)
      {
        case 2:
          str2 = "msvcrt";
          break;
        case 6:
          str2 = "coredll";
          break;
        default:
          str2 = "m";
          break;
      }
      Platform.__\u003C\u003EMATH_LIBRARY_NAME = str2;
      Platform.__\u003C\u003EHAS_DLL_CALLBACKS = Platform.osType == 2;
      Platform.__\u003C\u003EARCH = Platform.getCanonicalArchitecture(java.lang.System.getProperty("os.arch"), Platform.isSoftFloat());
      Platform.__\u003C\u003ERESOURCE_PREFIX = Platform.getNativeLibraryResourcePrefix();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Platform.__\u003CcallerID\u003E == null)
        Platform.__\u003CcallerID\u003E = (CallerID) new Platform.__\u003CCallerID\u003E();
      return Platform.__\u003CcallerID\u003E;
    }

    [Modifiers]
    public static bool RO_FIELDS
    {
      [HideFromJava] get => Platform.__\u003C\u003ERO_FIELDS;
    }

    [Modifiers]
    public static bool HAS_BUFFERS
    {
      [HideFromJava] get => Platform.__\u003C\u003EHAS_BUFFERS;
    }

    [Modifiers]
    public static bool HAS_AWT
    {
      [HideFromJava] get => Platform.__\u003C\u003EHAS_AWT;
    }

    [Modifiers]
    public static bool HAS_JAWT
    {
      [HideFromJava] get => Platform.__\u003C\u003EHAS_JAWT;
    }

    [Modifiers]
    public static string MATH_LIBRARY_NAME
    {
      [HideFromJava] get => Platform.__\u003C\u003EMATH_LIBRARY_NAME;
    }

    [Modifiers]
    public static string C_LIBRARY_NAME
    {
      [HideFromJava] get => Platform.__\u003C\u003EC_LIBRARY_NAME;
    }

    [Modifiers]
    public static bool HAS_DLL_CALLBACKS
    {
      [HideFromJava] get => Platform.__\u003C\u003EHAS_DLL_CALLBACKS;
    }

    [Modifiers]
    public static string RESOURCE_PREFIX
    {
      [HideFromJava] get => Platform.__\u003C\u003ERESOURCE_PREFIX;
    }

    [Modifiers]
    public static string ARCH
    {
      [HideFromJava] get => Platform.__\u003C\u003EARCH;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
