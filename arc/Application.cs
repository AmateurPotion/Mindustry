// Decompiled with JetBrains decompiler
// Type: arc.Application
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc
{
  [Implements(new string[] {"arc.util.Disposable"})]
  public interface Application : Disposable
  {
    void post(Runnable r);

    [Modifiers]
    void addListener(ApplicationListener listener);

    [LineNumberTable(new byte[] {159, 155, 109, 108, 111})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EaddListener([In] Application obj0, [In] ApplicationListener obj1)
    {
      lock (obj0.getListeners())
        obj0.getListeners().add((object) obj1);
    }

    [Modifiers]
    bool isMobile();

    [LineNumberTable(51)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisMobile([In] Application obj0) => obj0.isAndroid() || obj0.isIOS();

    [Modifiers]
    bool isIOS();

    [LineNumberTable(47)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisIOS([In] Application obj0) => object.ReferenceEquals((object) obj0.getType(), (object) Application.ApplicationType.__\u003C\u003EiOS);

    [Modifiers]
    bool isAndroid();

    [LineNumberTable(43)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisAndroid([In] Application obj0) => object.ReferenceEquals((object) obj0.getType(), (object) Application.ApplicationType.__\u003C\u003Eandroid);

    void exit();

    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    string getClipboardText();

    void setClipboardText(string str);

    [Modifiers]
    long getJavaHeap();

    [LineNumberTable(65)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static long \u003Cdefault\u003EgetJavaHeap([In] Application obj0) => java.lang.Runtime.getRuntime().totalMemory() - java.lang.Runtime.getRuntime().freeMemory();

    [Modifiers]
    bool isDesktop();

    [LineNumberTable(35)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisDesktop([In] Application obj0) => object.ReferenceEquals((object) obj0.getType(), (object) Application.ApplicationType.__\u003C\u003Edesktop);

    [Modifiers]
    int getVersion();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static int \u003Cdefault\u003EgetVersion([In] Application obj0) => 0;

    [Modifiers]
    bool openURI(string URI);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EopenURI([In] Application obj0, [In] string obj1) => false;

    [Modifiers]
    bool openFolder(string file);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EopenFolder([In] Application obj0, [In] string obj1) => false;

    [Modifiers]
    long getNativeHeap();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static long \u003Cdefault\u003EgetNativeHeap([In] Application obj0) => 0;

    [Signature("()Larc/struct/Seq<Larc/ApplicationListener;>;")]
    Seq getListeners();

    Application.ApplicationType getType();

    [Modifiers]
    void removeListener(ApplicationListener listener);

    [LineNumberTable(new byte[] {159, 162, 109, 109, 111})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EremoveListener([In] Application obj0, [In] ApplicationListener obj1)
    {
      lock (obj0.getListeners())
        obj0.getListeners().remove((object) obj1);
    }

    [Modifiers]
    void defaultUpdate();

    [LineNumberTable(new byte[] {159, 169, 106, 101})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EdefaultUpdate([In] Application obj0)
    {
      Core.settings.autosave();
      Time.updateGlobal();
    }

    [Modifiers]
    bool isHeadless();

    [LineNumberTable(39)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisHeadless([In] Application obj0) => object.ReferenceEquals((object) obj0.getType(), (object) Application.ApplicationType.__\u003C\u003Eheadless);

    [Modifiers]
    bool isWeb();

    [LineNumberTable(55)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool \u003Cdefault\u003EisWeb([In] Application obj0) => object.ReferenceEquals((object) obj0.getType(), (object) Application.ApplicationType.__\u003C\u003Eweb);

    [Modifiers]
    new void dispose();

    [LineNumberTable(new byte[] {61, 103, 170, 103, 138})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Edispose([In] Application obj0)
    {
      if (Core.settings != null)
        Core.settings.autosave();
      if (Core.audio == null)
        return;
      Core.audio.dispose();
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/Application$ApplicationType;>;")]
    [Modifiers]
    [Serializable]
    sealed class ApplicationType : Enum
    {
      [Modifiers]
      internal static Application.ApplicationType __\u003C\u003Eandroid;
      [Modifiers]
      internal static Application.ApplicationType __\u003C\u003Edesktop;
      [Modifiers]
      internal static Application.ApplicationType __\u003C\u003Eheadless;
      [Modifiers]
      internal static Application.ApplicationType __\u003C\u003Eweb;
      [Modifiers]
      internal static Application.ApplicationType __\u003C\u003EiOS;
      [Modifiers]
      private static Application.ApplicationType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(121)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ApplicationType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(121)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Application.ApplicationType[] values() => (Application.ApplicationType[]) Application.ApplicationType.\u0024VALUES.Clone();

      [LineNumberTable(121)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Application.ApplicationType valueOf(string name) => (Application.ApplicationType) Enum.valueOf((Class) ClassLiteral<Application.ApplicationType>.Value, name);

      [LineNumberTable(new byte[] {159, 112, 141, 63, 49})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ApplicationType()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.Application$ApplicationType"))
          return;
        Application.ApplicationType.__\u003C\u003Eandroid = new Application.ApplicationType(nameof (android), 0);
        Application.ApplicationType.__\u003C\u003Edesktop = new Application.ApplicationType(nameof (desktop), 1);
        Application.ApplicationType.__\u003C\u003Eheadless = new Application.ApplicationType(nameof (headless), 2);
        Application.ApplicationType.__\u003C\u003Eweb = new Application.ApplicationType(nameof (web), 3);
        Application.ApplicationType.__\u003C\u003EiOS = new Application.ApplicationType(nameof (iOS), 4);
        Application.ApplicationType.\u0024VALUES = new Application.ApplicationType[5]
        {
          Application.ApplicationType.__\u003C\u003Eandroid,
          Application.ApplicationType.__\u003C\u003Edesktop,
          Application.ApplicationType.__\u003C\u003Eheadless,
          Application.ApplicationType.__\u003C\u003Eweb,
          Application.ApplicationType.__\u003C\u003EiOS
        };
      }

      [Modifiers]
      public static Application.ApplicationType android
      {
        [HideFromJava] get => Application.ApplicationType.__\u003C\u003Eandroid;
      }

      [Modifiers]
      public static Application.ApplicationType desktop
      {
        [HideFromJava] get => Application.ApplicationType.__\u003C\u003Edesktop;
      }

      [Modifiers]
      public static Application.ApplicationType headless
      {
        [HideFromJava] get => Application.ApplicationType.__\u003C\u003Eheadless;
      }

      [Modifiers]
      public static Application.ApplicationType web
      {
        [HideFromJava] get => Application.ApplicationType.__\u003C\u003Eweb;
      }

      [Modifiers]
      public static Application.ApplicationType iOS
      {
        [HideFromJava] get => Application.ApplicationType.__\u003C\u003EiOS;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        android,
        desktop,
        headless,
        web,
        iOS,
      }
    }

    [HideFromJava]
    new static class __DefaultMethods
    {
      public static void addListener([In] Application obj0, [In] ApplicationListener obj1)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        Application.\u003Cdefault\u003EaddListener(application, obj1);
      }

      public static void removeListener([In] Application obj0, [In] ApplicationListener obj1)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        Application.\u003Cdefault\u003EremoveListener(application, obj1);
      }

      public static void defaultUpdate([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        Application.\u003Cdefault\u003EdefaultUpdate(application);
      }

      public static bool isDesktop([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EisDesktop(application);
      }

      public static bool isHeadless([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EisHeadless(application);
      }

      public static bool isAndroid([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EisAndroid(application);
      }

      public static bool isIOS([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EisIOS(application);
      }

      public static bool isMobile([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EisMobile(application);
      }

      public static bool isWeb([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EisWeb(application);
      }

      public static int getVersion([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EgetVersion(application);
      }

      public static long getJavaHeap([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EgetJavaHeap(application);
      }

      public static long getNativeHeap([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EgetNativeHeap(application);
      }

      public static bool openFolder([In] Application obj0, [In] string obj1)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EopenFolder(application, obj1);
      }

      public static bool openURI([In] Application obj0, [In] string obj1)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        return Application.\u003Cdefault\u003EopenURI(application, obj1);
      }

      public static void dispose([In] Application obj0)
      {
        Application application = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(application, ToString);
        Application.\u003Cdefault\u003Edispose(application);
      }
    }
  }
}
