// Decompiled with JetBrains decompiler
// Type: com.sun.jna.NativeLibrary
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.lang.@ref;
using java.lang.reflect;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace com.sun.jna
{
  public class NativeLibrary : Object
  {
    private long handle;
    [Modifiers]
    private string libraryName;
    [Modifiers]
    private string libraryPath;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;Lcom/sun/jna/Function;>;")]
    private Map functions;
    [Modifiers]
    internal int callFlags;
    private string encoding;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;*>;")]
    internal Map options;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;Ljava/lang/ref/Reference<Lcom/sun/jna/NativeLibrary;>;>;")]
    private static Map libraries;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;Ljava/util/List<Ljava/lang/String;>;>;")]
    private static Map searchPaths;
    [Modifiers]
    [Signature("Ljava/util/List<Ljava/lang/String;>;")]
    private static List librarySearchPath;
    private const int DEFAULT_OPEN_OPTIONS = -1;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(369)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static NativeLibrary getInstance(string libraryName) => NativeLibrary.getInstance(libraryName, Collections.emptyMap());

    [LineNumberTable(493)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Function getFunction(string functionName) => this.getFunction(functionName, this.callFlags);

    [LineNumberTable(new byte[] {161, 189, 99, 144, 109, 105, 114, 99, 106, 142, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Function getFunction(
      string functionName,
      int callFlags,
      string encoding)
    {
      if (functionName == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("Function name may not be null");
      }
      Function function1;
      lock (this.functions)
      {
        string str = NativeLibrary.functionKey(functionName, callFlags, encoding);
        Function function2 = (Function) this.functions.get((object) str);
        if (function2 == null)
        {
          function2 = new Function(this, functionName, callFlags, encoding);
          this.functions.put((object) str, (object) function2);
        }
        function1 = function2;
      }
      return function1;
    }

    [LineNumberTable(new byte[] {161, 226, 106, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual long getSymbolAddress([In] string obj0)
    {
      if (this.handle == 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsatisfiedLinkError("Library has been unloaded");
      }
      return Native.findSymbol(this.handle, obj0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getName() => this.libraryName;

    [Modifiers]
    [Signature("(Ljava/lang/String;Ljava/util/Map<Ljava/lang/String;*>;)Lcom/sun/jna/NativeLibrary;")]
    [LineNumberTable(new byte[] {161, 37, 103, 109, 242, 69, 123, 103, 131, 108, 127, 7, 146, 102, 99, 187, 136, 104, 127, 9, 104, 100, 127, 10, 191, 10, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static NativeLibrary getInstance(string libraryName, Map libraryOptions)
    {
      HashMap hashMap = new HashMap(libraryOptions);
      if (((Map) hashMap).get((object) "calling-convention") == null)
        ((Map) hashMap).put((object) "calling-convention", (object) Integer.valueOf(0));
      if ((Platform.isLinux() || Platform.isFreeBSD() || Platform.isAIX()) && String.instancehelper_equals(Platform.__\u003C\u003EC_LIBRARY_NAME, (object) libraryName))
        libraryName = (string) null;
      NativeLibrary nativeLibrary1;
      lock (NativeLibrary.libraries)
      {
        Reference reference = (Reference) NativeLibrary.libraries.get((object) new StringBuilder().append(libraryName).append((object) hashMap).toString());
        NativeLibrary nativeLibrary2 = reference == null ? (NativeLibrary) null : (NativeLibrary) reference.get();
        if (nativeLibrary2 == null)
        {
          nativeLibrary2 = libraryName != null ? NativeLibrary.loadLibrary(libraryName, (Map) hashMap) : new NativeLibrary("<process>", (string) null, Native.open((string) null, NativeLibrary.openFlags((Map) hashMap)), (Map) hashMap);
          WeakReference weakReference = new WeakReference((object) nativeLibrary2);
          NativeLibrary.libraries.put((object) new StringBuilder().append(nativeLibrary2.getName()).append((object) hashMap).toString(), (object) weakReference);
          File file = nativeLibrary2.getFile();
          if (file != null)
          {
            NativeLibrary.libraries.put((object) new StringBuilder().append(file.getAbsolutePath()).append((object) hashMap).toString(), (object) weakReference);
            NativeLibrary.libraries.put((object) new StringBuilder().append(file.getName()).append((object) hashMap).toString(), (object) weakReference);
          }
        }
        nativeLibrary1 = nativeLibrary2;
      }
      return nativeLibrary1;
    }

    [LineNumberTable(new byte[] {161, 142, 118, 99, 170, 112, 105, 142, 103, 103, 105, 112, 5, 232, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Function getFunction([In] string obj0, [In] Method obj1)
    {
      FunctionMapper functionMapper = (FunctionMapper) this.options.get((object) "function-mapper");
      if (functionMapper != null)
        obj0 = functionMapper.getFunctionName(this, obj1);
      string property = java.lang.System.getProperty("jna.profiler.prefix", "$$YJP$$");
      if (String.instancehelper_startsWith(obj0, property))
        obj0 = String.instancehelper_substring(obj0, String.instancehelper_length(property));
      int callFlags = this.callFlags;
      foreach (Class exceptionType in obj1.getExceptionTypes())
      {
        if (((Class) ClassLiteral<LastErrorException>.Value).isAssignableFrom(exceptionType))
          callFlags |= 64;
      }
      return this.getFunction(obj0, callFlags);
    }

    [LineNumberTable(new byte[] {162, 2, 108, 117, 111, 123, 109, 100, 135, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void disposeAll()
    {
      LinkedHashSet linkedHashSet;
      lock (NativeLibrary.libraries)
      {
        LinkedHashSet.__\u003Cclinit\u003E();
        linkedHashSet = new LinkedHashSet(NativeLibrary.libraries.values());
      }
      Iterator iterator = ((Set) linkedHashSet).iterator();
      while (iterator.hasNext())
        ((NativeLibrary) ((Reference) iterator.next()).get())?.dispose();
    }

    [LineNumberTable(new byte[] {162, 98, 106, 115, 109, 103, 130, 199, 109, 159, 13, 130, 110, 149, 162, 103, 109, 162, 103, 122, 194})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string mapSharedLibraryName([In] string obj0)
    {
      if (Platform.isMac())
      {
        if (String.instancehelper_startsWith(obj0, "lib") && (String.instancehelper_endsWith(obj0, ".dylib") || String.instancehelper_endsWith(obj0, ".jnilib")))
          return obj0;
        string str = java.lang.System.mapLibraryName(obj0);
        return String.instancehelper_endsWith(str, ".jnilib") ? new StringBuilder().append(String.instancehelper_substring(str, 0, String.instancehelper_lastIndexOf(str, ".jnilib"))).append(".dylib").toString() : str;
      }
      if (Platform.isLinux() || Platform.isFreeBSD())
      {
        if (NativeLibrary.isVersionedName(obj0) || String.instancehelper_endsWith(obj0, ".so"))
          return obj0;
      }
      else if (Platform.isAIX())
      {
        if (String.instancehelper_startsWith(obj0, "lib"))
          return obj0;
      }
      else if (Platform.isWindows() && (String.instancehelper_endsWith(obj0, ".drv") || String.instancehelper_endsWith(obj0, ".dll")))
        return obj0;
      return java.lang.System.mapLibraryName(obj0);
    }

    [Signature("()Ljava/util/Map<Ljava/lang/String;*>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Map getOptions() => this.options;

    [LineNumberTable(new byte[] {162, 134, 112, 108, 111, 109, 104, 109, 226, 61, 230, 70, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool isVersionedName([In] string obj0)
    {
      if (String.instancehelper_startsWith(obj0, "lib"))
      {
        int num1 = String.instancehelper_lastIndexOf(obj0, ".so.");
        if (num1 != -1 && num1 + 4 < String.instancehelper_length(obj0))
        {
          for (int index = num1 + 4; index < String.instancehelper_length(obj0); ++index)
          {
            int num2 = (int) String.instancehelper_charAt(obj0, index);
            if (!Character.isDigit((char) num2) && num2 != 46)
              return false;
          }
          return true;
        }
      }
      return false;
    }

    [LineNumberTable(new byte[] {160, 227, 98, 102, 107, 108, 116, 136, 115, 105, 101, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string getLibraryName([In] string obj0)
    {
      string str1 = obj0;
      string str2 = NativeLibrary.mapSharedLibraryName("---");
      int num1 = String.instancehelper_indexOf(str2, "---");
      if (num1 > 0 && String.instancehelper_startsWith(str1, String.instancehelper_substring(str2, 0, num1)))
        str1 = String.instancehelper_substring(str1, num1);
      string str3 = String.instancehelper_substring(str2, num1 + String.instancehelper_length("---"));
      int num2 = String.instancehelper_indexOf(str1, str3);
      if (num2 != -1)
        str1 = String.instancehelper_substring(str1, 0, num2);
      return str1;
    }

    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string functionKey([In] string obj0, [In] int obj1, [In] string obj2) => new StringBuilder().append(obj0).append("|").append(obj1).append("|").append(obj2).toString();

    [Signature("(Ljava/util/Map<Ljava/lang/String;*>;)I")]
    [LineNumberTable(new byte[] {89, 108, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int openFlags([In] Map obj0)
    {
      object obj = obj0.get((object) "open-flags");
      return obj is Number ? ((Number) obj).intValue() : -1;
    }

    [Signature("(Ljava/lang/String;)Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(new byte[] {162, 38, 108, 109, 134, 108, 102, 104, 103, 109, 136, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static List initPaths([In] string obj0)
    {
      string property = java.lang.System.getProperty(obj0, "");
      if (String.instancehelper_equals("", (object) property))
        return Collections.emptyList();
      StringTokenizer stringTokenizer = new StringTokenizer(property, (string) File.pathSeparator);
      ArrayList arrayList = new ArrayList();
      while (stringTokenizer.hasMoreTokens())
      {
        string str = stringTokenizer.nextToken();
        if (!String.instancehelper_equals("", (object) str))
          ((List) arrayList).add((object) str);
      }
      return (List) arrayList;
    }

    [Signature("(Ljava/lang/String;Ljava/util/List<Ljava/lang/String;>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {162, 59, 109, 226, 70, 167, 126, 104, 104, 135, 167, 109, 127, 24, 104, 199, 229, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string findLibraryPath([In] string obj0, [In] List obj1)
    {
      if (new File(obj0).isAbsolute())
        return obj0;
      string str1 = NativeLibrary.mapSharedLibraryName(obj0);
      Iterator iterator = obj1.iterator();
      while (iterator.hasNext())
      {
        string str2 = (string) iterator.next();
        File file1 = new File(str2, str1);
        if (file1.exists())
          return file1.getAbsolutePath();
        if (Platform.isMac() && String.instancehelper_endsWith(str1, ".dylib"))
        {
          File.__\u003Cclinit\u003E();
          File file2 = new File(str2, new StringBuilder().append(String.instancehelper_substring(str1, 0, String.instancehelper_lastIndexOf(str1, ".dylib"))).append(".jnilib").toString());
          if (file2.exists())
            return file2.getAbsolutePath();
        }
      }
      return str1;
    }

    [Signature("(Ljava/lang/String;Ljava/util/List<Ljava/lang/String;>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {162, 155, 103, 104, 150, 231, 74, 102, 124, 111, 106, 142, 226, 69, 107, 99, 127, 0, 105, 119, 107, 102, 100, 132, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string matchLibrary([In] string obj0, [In] List obj1)
    {
      File file = new File(obj0);
      if (file.isAbsolute())
        obj1 = Arrays.asList((object[]) new string[1]
        {
          file.getParent()
        });
      NativeLibrary.\u0032 obj = new NativeLibrary.\u0032(obj0);
      LinkedList linkedList = new LinkedList();
      Iterator iterator1 = obj1.iterator();
      while (iterator1.hasNext())
      {
        File[] fileArray = new File((string) iterator1.next()).listFiles((FilenameFilter) obj);
        if (fileArray != null && fileArray.Length > 0)
          ((Collection) linkedList).addAll((Collection) Arrays.asList((object[]) fileArray));
      }
      double num = -1.0;
      string str = (string) null;
      Iterator iterator2 = ((Collection) linkedList).iterator();
      while (iterator2.hasNext())
      {
        string absolutePath = ((File) iterator2.next()).getAbsolutePath();
        double version = NativeLibrary.parseVersion(String.instancehelper_substring(absolutePath, String.instancehelper_lastIndexOf(absolutePath, ".so.") + 4));
        if (version > num)
        {
          num = version;
          str = absolutePath;
        }
      }
      return str;
    }

    [LineNumberTable(new byte[] {160, 201, 103, 107, 111, 103, 135, 127, 33, 107, 199, 127, 5, 159, 19, 103, 127, 5, 110, 227, 61, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static string matchFramework([In] string obj0)
    {
      File file1 = new File(obj0);
      if (file1.isAbsolute())
      {
        if (String.instancehelper_indexOf(obj0, ".framework") != -1 && file1.exists())
          return file1.getAbsolutePath();
        File.__\u003Cclinit\u003E();
        File.__\u003Cclinit\u003E();
        File file2 = new File(new File(file1.getParentFile(), new StringBuilder().append(file1.getName()).append(".framework").toString()), file1.getName());
        if (file2.exists())
          return file2.getAbsolutePath();
      }
      else
      {
        string[] strArray = new string[3]
        {
          java.lang.System.getProperty("user.home"),
          "",
          "/System"
        };
        string str1 = String.instancehelper_indexOf(obj0, ".framework") != -1 ? obj0 : new StringBuilder().append(obj0).append(".framework/").append(obj0).toString();
        for (int index = 0; index < strArray.Length; ++index)
        {
          string str2 = new StringBuilder().append(strArray[index]).append("/Library/Frameworks/").append(str1).toString();
          if (new File(str2).exists())
            return str2;
        }
      }
      return (string) null;
    }

    [Signature("(Ljava/lang/String;Ljava/lang/String;JLjava/util/Map<Ljava/lang/String;*>;)V")]
    [LineNumberTable(new byte[] {54, 232, 45, 235, 84, 109, 103, 103, 109, 119, 103, 104, 119, 104, 235, 69, 127, 2, 109, 251, 75, 127, 5, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeLibrary([In] string obj0, [In] string obj1, [In] long obj2, [In] Map obj3)
    {
      NativeLibrary nativeLibrary = this;
      this.functions = (Map) new HashMap();
      this.libraryName = this.getLibraryName(obj0);
      this.libraryPath = obj1;
      this.handle = obj2;
      object obj4 = obj3.get((object) "calling-convention");
      this.callFlags = !(obj4 is Number) ? 0 : ((Number) obj4).intValue();
      this.options = obj3;
      this.encoding = (string) obj3.get((object) "string-encoding");
      if (this.encoding == null)
        this.encoding = Native.getDefaultStringEncoding();
      if (Platform.isWindows() && String.instancehelper_equals("kernel32", (object) String.instancehelper_toLowerCase(this.libraryName)))
      {
        Map functions;
        Monitor.Enter((object) (functions = this.functions));
        try
        {
          NativeLibrary.\u0031.__\u003Cclinit\u003E();
          NativeLibrary.\u0031 obj5 = new NativeLibrary.\u0031(this, this, "GetLastError", 63, this.encoding);
          this.functions.put((object) NativeLibrary.functionKey("GetLastError", this.callFlags, this.encoding), (object) obj5);
        }
        finally
        {
          Monitor.Exit((object) functions);
          GC.KeepAlive((object) this);
        }
      }
      GC.KeepAlive((object) this);
    }

    [Signature("(Ljava/lang/String;Ljava/util/Map<Ljava/lang/String;*>;)Lcom/sun/jna/NativeLibrary;")]
    [LineNumberTable(new byte[] {97, 103, 191, 15, 108, 102, 199, 103, 99, 103, 159, 5, 232, 70, 114, 100, 106, 106, 183, 103, 191, 14, 113, 105, 228, 71, 103, 159, 6, 255, 0, 71, 226, 58, 129, 103, 159, 9, 204, 105, 105, 103, 159, 6, 106, 102, 255, 39, 160, 97, 229, 159, 162, 194, 138, 103, 159, 5, 107, 223, 4, 5, 98, 100, 133, 209, 103, 143, 105, 103, 103, 191, 6, 223, 4, 5, 98, 100, 197, 122, 103, 143, 104, 135, 103, 159, 6, 223, 4, 5, 98, 100, 197, 112, 103, 143, 127, 3, 103, 103, 191, 6, 191, 4, 2, 98, 228, 70, 137, 152, 111, 185, 105, 63, 5, 107, 254, 70, 2, 98, 206, 102, 223, 28, 103, 159, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeLibrary loadLibrary([In] string obj0, [In] Map obj1)
    {
      if (Native.DEBUG_LOAD)
        java.lang.System.@out.println(new StringBuilder().append("Looking for library '").append(obj0).append("'").toString());
      int num1 = new File(obj0).isAbsolute() ? 1 : 0;
      ArrayList arrayList = new ArrayList();
      int num2 = NativeLibrary.openFlags(obj1);
      string startLibraryPath = Native.getWebStartLibraryPath(obj0);
      if (startLibraryPath != null)
      {
        if (Native.DEBUG_LOAD)
          java.lang.System.@out.println(new StringBuilder().append("Adding web start path ").append(startLibraryPath).toString());
        ((List) arrayList).add((object) startLibraryPath);
      }
      List list1 = (List) NativeLibrary.searchPaths.get((object) obj0);
      if (list1 != null)
      {
        List list2;
        Monitor.Enter((object) (list2 = list1));
        // ISSUE: fault handler
        try
        {
          ((List) arrayList).addAll(0, (Collection) list1);
          Monitor.Exit((object) list2);
        }
        __fault
        {
          Monitor.Exit((object) list2);
        }
      }
      if (Native.DEBUG_LOAD)
        java.lang.System.@out.println(new StringBuilder().append("Adding paths from jna.library.path: ").append(java.lang.System.getProperty("jna.library.path")).toString());
      ((List) arrayList).addAll((Collection) NativeLibrary.initPaths("jna.library.path"));
      string str1 = NativeLibrary.findLibraryPath(obj0, (List) arrayList);
      long num3 = 0;
      try
      {
        if (Native.DEBUG_LOAD)
          java.lang.System.@out.println(new StringBuilder().append("Trying ").append(str1).toString());
        num3 = Native.open(str1, num2);
        goto label_21;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      if (Native.DEBUG_LOAD)
        java.lang.System.@out.println(new StringBuilder().append("Adding system paths: ").append((object) NativeLibrary.librarySearchPath).toString());
      ((List) arrayList).addAll((Collection) NativeLibrary.librarySearchPath);
label_21:
      UnsatisfiedLinkError unsatisfiedLinkError1;
      try
      {
        if (num3 == 0L)
        {
          str1 = NativeLibrary.findLibraryPath(obj0, (List) arrayList);
          if (Native.DEBUG_LOAD)
            java.lang.System.@out.println(new StringBuilder().append("Trying ").append(str1).toString());
          num3 = Native.open(str1, num2);
          if (num3 == 0L)
          {
            string str2 = new StringBuilder().append("Failed to load library '").append(obj0).append("'").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new UnsatisfiedLinkError(str2);
          }
          goto label_87;
        }
        else
          goto label_87;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          unsatisfiedLinkError1 = (UnsatisfiedLinkError) m0;
      }
      UnsatisfiedLinkError unsatisfiedLinkError2 = unsatisfiedLinkError1;
      if (Platform.isAndroid())
      {
        UnsatisfiedLinkError unsatisfiedLinkError3;
        try
        {
          if (Native.DEBUG_LOAD)
            java.lang.System.@out.println(new StringBuilder().append("Preload (via System.loadLibrary) ").append(obj0).toString());
          java.lang.System.loadLibrary(obj0, NativeLibrary.__\u003CGetCallerID\u003E());
          num3 = Native.open(str1, num2);
          goto label_70;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            unsatisfiedLinkError3 = (UnsatisfiedLinkError) m0;
        }
        unsatisfiedLinkError2 = unsatisfiedLinkError3;
      }
      else if (Platform.isLinux() || Platform.isFreeBSD())
      {
        if (Native.DEBUG_LOAD)
          java.lang.System.@out.println("Looking for version variants");
        str1 = NativeLibrary.matchLibrary(obj0, (List) arrayList);
        if (str1 != null)
        {
          if (Native.DEBUG_LOAD)
            java.lang.System.@out.println(new StringBuilder().append("Trying ").append(str1).toString());
          UnsatisfiedLinkError unsatisfiedLinkError3;
          try
          {
            num3 = Native.open(str1, num2);
            goto label_70;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              unsatisfiedLinkError3 = (UnsatisfiedLinkError) m0;
          }
          unsatisfiedLinkError2 = unsatisfiedLinkError3;
        }
      }
      else if (Platform.isMac() && !String.instancehelper_endsWith(obj0, ".dylib"))
      {
        if (Native.DEBUG_LOAD)
          java.lang.System.@out.println("Looking for matching frameworks");
        str1 = NativeLibrary.matchFramework(obj0);
        if (str1 != null)
        {
          UnsatisfiedLinkError unsatisfiedLinkError3;
          try
          {
            if (Native.DEBUG_LOAD)
              java.lang.System.@out.println(new StringBuilder().append("Trying ").append(str1).toString());
            num3 = Native.open(str1, num2);
            goto label_70;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              unsatisfiedLinkError3 = (UnsatisfiedLinkError) m0;
          }
          unsatisfiedLinkError2 = unsatisfiedLinkError3;
        }
      }
      else if (Platform.isWindows() && num1 == 0)
      {
        if (Native.DEBUG_LOAD)
          java.lang.System.@out.println("Looking for lib- prefix");
        str1 = NativeLibrary.findLibraryPath(new StringBuilder().append("lib").append(obj0).toString(), (List) arrayList);
        if (str1 != null)
        {
          if (Native.DEBUG_LOAD)
            java.lang.System.@out.println(new StringBuilder().append("Trying ").append(str1).toString());
          UnsatisfiedLinkError unsatisfiedLinkError3;
          try
          {
            num3 = Native.open(str1, num2);
            goto label_70;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              unsatisfiedLinkError3 = (UnsatisfiedLinkError) m0;
          }
          unsatisfiedLinkError2 = unsatisfiedLinkError3;
        }
      }
label_70:
      if (num3 == 0L)
      {
        File fromResourcePath;
        Exception exception1;
        IOException ioException1;
        try
        {
          fromResourcePath = Native.extractFromResourcePath(obj0, (ClassLoader) obj1.get((object) "classloader"));
          try
          {
            num3 = Native.open(fromResourcePath.getAbsolutePath(), num2);
            str1 = fromResourcePath.getAbsolutePath();
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_77;
          }
          if (Native.isUnpacked(fromResourcePath))
          {
            Native.deleteLibrary(fromResourcePath);
            goto label_85;
          }
          else
            goto label_85;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_78;
        }
label_77:
        Exception exception2 = exception1;
        IOException ioException2;
        try
        {
          Exception exception3 = exception2;
          if (Native.isUnpacked(fromResourcePath))
            Native.deleteLibrary(fromResourcePath);
          throw Throwable.__\u003Cunmap\u003E(exception3);
        }
        catch (IOException ex)
        {
          ioException2 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        IOException ioException3 = ioException2;
        goto label_84;
label_78:
        ioException3 = ioException1;
label_84:
        unsatisfiedLinkError2 = new UnsatisfiedLinkError(Throwable.instancehelper_getMessage((Exception) ioException3));
      }
label_85:
      if (num3 == 0L)
      {
        string str2 = new StringBuilder().append("Unable to load library '").append(obj0).append("': ").append(Throwable.instancehelper_getMessage((Exception) unsatisfiedLinkError2)).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsatisfiedLinkError(str2);
      }
label_87:
      if (Native.DEBUG_LOAD)
        java.lang.System.@out.println(new StringBuilder().append("Found library '").append(obj0).append("' at ").append(str1).toString());
      return new NativeLibrary(obj0, str1, num3, obj1);
    }

    [LineNumberTable(new byte[] {161, 245, 104, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual File getFile()
    {
      if (this.libraryPath == null)
        return (File) null;
      File.__\u003Cclinit\u003E();
      return new File(this.libraryPath);
    }

    [LineNumberTable(542)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Function getFunction(string functionName, int callFlags) => this.getFunction(functionName, callFlags, this.encoding);

    [LineNumberTable(new byte[] {162, 15, 102, 108, 127, 5, 109, 111, 141, 130, 124, 109, 98, 149, 105, 106, 107, 136, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      HashSet hashSet = new HashSet();
      Map libraries;
      Monitor.Enter((object) (libraries = NativeLibrary.libraries));
      // ISSUE: fault handler
      try
      {
        Iterator iterator1 = NativeLibrary.libraries.entrySet().iterator();
        while (iterator1.hasNext())
        {
          Map.Entry entry = (Map.Entry) iterator1.next();
          if (object.ReferenceEquals(((Reference) entry.getValue()).get(), (object) this))
            ((Set) hashSet).add(entry.getKey());
        }
        Iterator iterator2 = ((Set) hashSet).iterator();
        while (iterator2.hasNext())
        {
          string str = (string) iterator2.next();
          NativeLibrary.libraries.remove((object) str);
        }
        Monitor.Exit((object) libraries);
      }
      __fault
      {
        Monitor.Exit((object) libraries);
      }
      lock (this)
      {
        if (this.handle == 0L)
          return;
        Native.close(this.handle);
        this.handle = 0L;
      }
    }

    [LineNumberTable(new byte[] {162, 195, 102, 102, 108, 134, 100, 105, 107, 174, 98, 163, 218, 2, 97, 134, 110, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static double parseVersion([In] string obj0)
    {
      double num1 = 0.0;
      double num2 = 1.0;
      int num3 = String.instancehelper_indexOf(obj0, ".");
      while (obj0 != null)
      {
        string str;
        if (num3 != -1)
        {
          str = String.instancehelper_substring(obj0, 0, num3);
          obj0 = String.instancehelper_substring(obj0, num3 + 1);
          num3 = String.instancehelper_indexOf(obj0, ".");
        }
        else
        {
          str = obj0;
          obj0 = (string) null;
        }
        try
        {
          num1 += (double) Integer.parseInt(str) / num2;
          goto label_8;
        }
        catch (NumberFormatException ex)
        {
        }
        return 0.0;
label_8:
        num2 *= 100.0;
      }
      return num1;
    }

    [LineNumberTable(new byte[] {163, 52, 102, 142, 116, 134, 103, 150, 103, 150, 103, 102, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string getMultiArchPath()
    {
      string str1 = Platform.__\u003C\u003EARCH;
      string str2 = !Platform.iskFreeBSD() ? (!Platform.isGNU() ? "-linux" : "") : "-kfreebsd";
      string str3 = "-gnu";
      if (Platform.isIntel())
        str1 = !Platform.is64Bit() ? "i386" : "x86_64";
      else if (Platform.isPPC())
        str1 = !Platform.is64Bit() ? "powerpc" : "powerpc64";
      else if (Platform.isARM())
      {
        str1 = "arm";
        str3 = "-gnueabi";
      }
      return new StringBuilder().append(str1).append(str2).append(str3).toString();
    }

    [Signature("()Ljava/util/ArrayList<Ljava/lang/String;>;")]
    [LineNumberTable(new byte[] {163, 76, 134, 112, 113, 102, 109, 109, 106, 112, 110, 106, 169, 101, 155, 34, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ArrayList getLinuxLdPaths()
    {
      ArrayList arrayList = new ArrayList();
      try
      {
        BufferedReader bufferedReader = new BufferedReader((Reader) new InputStreamReader(java.lang.Runtime.getRuntime().exec("/sbin/ldconfig -p").getInputStream()));
        string str1;
        while ((str1 = bufferedReader.readLine()) != null)
        {
          int num1 = String.instancehelper_indexOf(str1, " => ");
          int num2 = String.instancehelper_lastIndexOf(str1, 47);
          if (num1 != -1 && num2 != -1 && num1 < num2)
          {
            string str2 = String.instancehelper_substring(str1, num1 + 4, num2);
            if (!arrayList.contains((object) str2))
              arrayList.add((object) str2);
          }
        }
        bufferedReader.close();
        goto label_10;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
label_10:
      return arrayList;
    }

    [Modifiers]
    [LineNumberTable(389)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static NativeLibrary getInstance(
      string libraryName,
      ClassLoader classLoader)
    {
      return NativeLibrary.getInstance(libraryName, Collections.singletonMap((object) "classloader", (object) classLoader));
    }

    [Modifiers]
    [LineNumberTable(448)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static NativeLibrary getProcess()
    {
      lock ((object) ClassLiteral<NativeLibrary>.Value)
        return NativeLibrary.getInstance((string) null);
    }

    [Modifiers]
    [Signature("(Ljava/util/Map<Ljava/lang/String;*>;)Lcom/sun/jna/NativeLibrary;")]
    [LineNumberTable(458)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static NativeLibrary getProcess(Map options)
    {
      lock ((object) ClassLiteral<NativeLibrary>.Value)
        return NativeLibrary.getInstance((string) null, options);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 100, 108, 113, 99, 107, 173, 104, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void addSearchPath(string libraryName, string path)
    {
      lock (NativeLibrary.searchPaths)
      {
        List list = (List) NativeLibrary.searchPaths.get((object) libraryName);
        if (list == null)
        {
          list = Collections.synchronizedList((List) new ArrayList());
          NativeLibrary.searchPaths.put((object) libraryName, (object) list);
        }
        list.add((object) path);
      }
    }

    [LineNumberTable(new byte[] {161, 215, 127, 13, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer getGlobalVariableAddress(string symbolName)
    {
      Pointer pointer;
      UnsatisfiedLinkError unsatisfiedLinkError1;
      try
      {
        Pointer.__\u003Cclinit\u003E();
        pointer = new Pointer(this.getSymbolAddress(symbolName));
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          unsatisfiedLinkError1 = (UnsatisfiedLinkError) m0;
          goto label_5;
        }
      }
      return pointer;
label_5:
      UnsatisfiedLinkError unsatisfiedLinkError2 = unsatisfiedLinkError1;
      string str = new StringBuilder().append("Error looking up '").append(symbolName).append("': ").append(Throwable.instancehelper_getMessage((Exception) unsatisfiedLinkError2)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsatisfiedLinkError(str);
    }

    [LineNumberTable(604)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("Native Library <").append(this.libraryPath).append("@").append(this.handle).append(">").toString();

    [LineNumberTable(new byte[] {161, 252, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void finalize() => this.dispose();

    [HideFromJava]
    ~NativeLibrary()
    {
      if (ByteCodeHelper.SkipFinalizer())
        return;
      try
      {
        this.finalize();
      }
      catch
      {
      }
    }

    [Modifiers]
    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool access\u0024000([In] string obj0) => NativeLibrary.isVersionedName(obj0);

    [LineNumberTable(new byte[] {159, 120, 141, 106, 111, 202, 103, 240, 162, 239, 107, 99, 140, 111, 138, 102, 102, 230, 77, 110, 142, 159, 16, 255, 51, 75, 120, 167, 255, 111, 80, 106, 135, 108, 110, 101, 138, 237, 59, 232, 71, 186, 106, 113, 114, 127, 2, 230, 60, 235, 71, 109, 172, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeLibrary()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.NativeLibrary"))
        return;
      NativeLibrary.libraries = (Map) new HashMap();
      NativeLibrary.searchPaths = Collections.synchronizedMap((Map) new HashMap());
      NativeLibrary.librarySearchPath = (List) new ArrayList();
      if (Native.__\u003C\u003EPOINTER_SIZE == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new Error("Native library not initialized");
      }
      string startLibraryPath = Native.getWebStartLibraryPath("jnidispatch");
      if (startLibraryPath != null)
        NativeLibrary.librarySearchPath.add((object) startLibraryPath);
      if (java.lang.System.getProperty("jna.platform.library.path") == null && !Platform.isWindows())
      {
        string str1 = "";
        string str2 = "";
        string str3 = "";
        if (Platform.isLinux() || Platform.isSolaris() || (Platform.isFreeBSD() || Platform.iskFreeBSD()))
          str3 = new StringBuilder().append(!Platform.isSolaris() ? "" : "/").append(Pointer.__\u003C\u003ESIZE * 8).toString();
        string[] strArray = new string[4]
        {
          new StringBuilder().append("/usr/lib").append(str3).toString(),
          new StringBuilder().append("/lib").append(str3).toString(),
          "/usr/lib",
          "/lib"
        };
        if (Platform.isLinux() || Platform.iskFreeBSD() || Platform.isGNU())
        {
          string multiArchPath = NativeLibrary.getMultiArchPath();
          strArray = new string[6]
          {
            new StringBuilder().append("/usr/lib/").append(multiArchPath).toString(),
            new StringBuilder().append("/lib/").append(multiArchPath).toString(),
            new StringBuilder().append("/usr/lib").append(str3).toString(),
            new StringBuilder().append("/lib").append(str3).toString(),
            "/usr/lib",
            "/lib"
          };
        }
        if (Platform.isLinux())
        {
          ArrayList linuxLdPaths = NativeLibrary.getLinuxLdPaths();
          for (int index = strArray.Length - 1; 0 <= index; index += -1)
          {
            int num = linuxLdPaths.indexOf((object) strArray[index]);
            if (num != -1)
              linuxLdPaths.remove(num);
            linuxLdPaths.add(0, (object) strArray[index]);
          }
          strArray = (string[]) linuxLdPaths.toArray((object[]) new string[linuxLdPaths.size()]);
        }
        for (int index = 0; index < strArray.Length; ++index)
        {
          File.__\u003Cclinit\u003E();
          File file = new File(strArray[index]);
          if (file.exists() && file.isDirectory())
          {
            str1 = new StringBuilder().append(str1).append(str2).append(strArray[index]).toString();
            str2 = (string) File.pathSeparator;
          }
        }
        if (!String.instancehelper_equals("", (object) str1))
          java.lang.System.setProperty("jna.platform.library.path", str1);
      }
      NativeLibrary.librarySearchPath.addAll((Collection) NativeLibrary.initPaths("jna.platform.library.path"));
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (NativeLibrary.__\u003CcallerID\u003E == null)
        NativeLibrary.__\u003CcallerID\u003E = (CallerID) new NativeLibrary.__\u003CCallerID\u003E();
      return NativeLibrary.__\u003CcallerID\u003E;
    }

    [EnclosingMethod(null, "<init>", "(Ljava.lang.String;Ljava.lang.String;JLjava.util.Map;)V")]
    [SpecialName]
    internal class \u0031 : Function
    {
      [Modifiers]
      internal NativeLibrary this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(121)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] NativeLibrary obj0, [In] NativeLibrary obj1, [In] string obj2, [In] int obj3, [In] string obj4)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2, obj3, obj4);
      }

      [Signature("([Ljava/lang/Object;Ljava/lang/Class<*>;ZI)Ljava/lang/Object;")]
      [LineNumberTable(124)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal override object invoke([In] object[] obj0, [In] Class obj1, [In] bool obj2, [In] int obj3) => (object) Integer.valueOf(Native.getLastError());

      [Signature("(Ljava/lang/reflect/Method;[Ljava/lang/Class<*>;Ljava/lang/Class<*>;[Ljava/lang/Object;Ljava/util/Map<Ljava/lang/String;*>;)Ljava/lang/Object;")]
      [LineNumberTable(129)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal override object invoke(
        [In] Method obj0,
        [In] Class[] obj1,
        [In] Class obj2,
        [In] object[] obj3,
        [In] Map obj4)
      {
        return (object) Integer.valueOf(Native.getLastError());
      }

      [HideFromJava]
      static \u0031() => Function.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, "matchLibrary", "(Ljava.lang.String;Ljava.util.List;)Ljava.lang.String;")]
    [SpecialName]
    internal sealed class \u0032 : Object, FilenameFilter
    {
      [Modifiers]
      internal string val\u0024libName;

      [LineNumberTable(785)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] string obj0)
      {
        this.val\u0024libName = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {162, 162, 127, 50, 114, 104, 235, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool accept([In] File obj0, [In] string obj1) => (String.instancehelper_startsWith(obj1, new StringBuilder().append("lib").append(this.val\u0024libName).append(".so").toString()) || String.instancehelper_startsWith(obj1, new StringBuilder().append(this.val\u0024libName).append(".so").toString()) && String.instancehelper_startsWith(this.val\u0024libName, "lib")) && NativeLibrary.access\u0024000(obj1);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
