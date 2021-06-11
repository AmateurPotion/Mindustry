// Decompiled with JetBrains decompiler
// Type: mindustry.core.Platform
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.math;
using arc.util;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.net;
using mindustry.mod;
using mindustry.net;
using mindustry.type;
using mindustry.ui.dialogs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.core
{
  public interface Platform
  {
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [Modifiers]
    [Signature("(ZLjava/lang/String;Larc/func/Cons<Larc/files/Fi;>;)V")]
    void showFileChooser(bool open, string extension, Cons cons);

    [LineNumberTable(new byte[] {159, 109, 66, 120})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EshowFileChooser(
      [In] Platform obj0,
      [In] bool obj1,
      [In] string obj2,
      [In] Cons obj3)
    {
      int num = obj1 ? 1 : 0;
      obj0.showFileChooser(num != 0, num == 0 ? "@save" : "@open", obj2, obj3);
    }

    [Modifiers]
    [Signature("(ZLjava/lang/String;Ljava/lang/String;Larc/func/Cons<Larc/files/Fi;>;)V")]
    void showFileChooser(bool open, string title, string extension, Cons cons);

    [LineNumberTable(new byte[] {159, 112, 130, 255, 6, 70, 102})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EshowFileChooser(
      [In] Platform obj0,
      [In] bool obj1,
      [In] string obj2,
      [In] string obj3,
      [In] Cons obj4)
    {
      int num = obj1 ? 1 : 0;
      FileChooser.__\u003Cclinit\u003E();
      new FileChooser(obj2, (Boolf) new Platform.__\u003C\u003EAnon5(obj3), num != 0, (Cons) new Platform.__\u003C\u003EAnon6(num != 0, obj4, obj3)).show();
    }

    [Modifiers]
    void shareFile(Fi file);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EshareFile([In] Platform obj0, [In] Fi obj1)
    {
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    ClassLoader loadJar(Fi jar, string mainClass);

    [LineNumberTable(25)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ClassLoader \u003Cdefault\u003EloadJar([In] Platform obj0, [In] Fi obj1, [In] string obj2)
    {
      URLClassLoader.__\u003Cclinit\u003E();
      return (ClassLoader) new URLClassLoader(new URL[1]
      {
        obj1.file().toURI().toURL()
      }, Object.instancehelper_getClass((object) obj0).getClassLoader(Platform.__\u003C\u003EIHM.__\u003CGetCallerID\u003E()));
    }

    [Modifiers]
    void updateLobby();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EupdateLobby([In] Platform obj0)
    {
    }

    [Modifiers]
    void inviteFriends();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EinviteFriends([In] Platform obj0)
    {
    }

    [Modifiers]
    void publish(Publishable pub);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Epublish([In] Platform obj0, [In] Publishable obj1)
    {
    }

    [Modifiers]
    void viewListing(Publishable pub);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EviewListing([In] Platform obj0, [In] Publishable obj1)
    {
    }

    [Modifiers]
    void viewListingID(string mapid);

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EviewListingID([In] Platform obj0, [In] string obj1)
    {
    }

    [Modifiers]
    [Signature("(Ljava/lang/Class<+Lmindustry/type/Publishable;>;)Larc/struct/Seq<Larc/files/Fi;>;")]
    Seq getWorkshopContent(Class type);

    [LineNumberTable(45)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Seq \u003Cdefault\u003EgetWorkshopContent([In] Platform obj0, [In] Class obj1) => new Seq(0);

    [Modifiers]
    void openWorkshop();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EopenWorkshop([In] Platform obj0)
    {
    }

    [Modifiers]
    mindustry.net.Net.NetProvider getNet();

    [LineNumberTable(53)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static mindustry.net.Net.NetProvider \u003Cdefault\u003EgetNet([In] Platform obj0) => (mindustry.net.Net.NetProvider) new ArcNetProvider();

    [Modifiers]
    Scripts createScripts();

    [LineNumberTable(58)]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Scripts \u003Cdefault\u003EcreateScripts([In] Platform obj0) => new Scripts();

    [Modifiers]
    rhino.Context getScriptContext();

    [LineNumberTable(new byte[] {12, 102, 104})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static rhino.Context \u003Cdefault\u003EgetScriptContext([In] Platform obj0)
    {
      rhino.Context context = rhino.Context.enter();
      context.setOptimizationLevel(9);
      return context;
    }

    [Modifiers]
    void updateRPC();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EupdateRPC([In] Platform obj0)
    {
    }

    [Modifiers]
    string getUUID();

    [LineNumberTable(new byte[] {23, 117, 104, 103, 107, 108, 112, 130})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static string \u003Cdefault\u003EgetUUID([In] Platform obj0)
    {
      string str1 = Core.settings.getString("uuid", "");
      if (!String.instancehelper_isEmpty(str1))
        return str1;
      byte[] numArray = new byte[8];
      new Rand().nextBytes(numArray);
      string str2 = String.newhelper(Base64Coder.encode(numArray));
      Core.settings.put("uuid", (object) str2);
      return str2;
    }

    [Modifiers]
    void export(string name, string extension, Platform.FileWriter writer);

    [LineNumberTable(new byte[] {39, 103, 249, 75, 247, 75})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Eexport(
      [In] Platform obj0,
      [In] string obj1,
      [In] string obj2,
      [In] Platform.FileWriter obj3)
    {
      if (!Vars.ios)
        Vars.platform.showFileChooser(false, obj2, (Cons) new Platform.__\u003C\u003EAnon3(obj3));
      else
        Vars.ui.loadAnd((Runnable) new Platform.__\u003C\u003EAnon4(obj1, obj2, obj3));
    }

    [Modifiers]
    [Signature("(Larc/func/Cons<Larc/files/Fi;>;[Ljava/lang/String;)V")]
    void showMultiFileChooser(Cons cons, params string[] extensions);

    [LineNumberTable(new byte[] {91, 103, 141, 159, 3})]
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EshowMultiFileChooser([In] Platform obj0, [In] Cons obj1, [In] string[] obj2)
    {
      if (Vars.mobile)
      {
        obj0.showFileChooser(true, obj2[0], obj1);
      }
      else
      {
        FileChooser.__\u003Cclinit\u003E();
        new FileChooser("@open", (Boolf) new Platform.__\u003C\u003EAnon7(obj2), true, obj1).show();
      }
    }

    [Modifiers]
    void hide();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003Ehide([In] Platform obj0)
    {
    }

    [Modifiers]
    void beginForceLandscape();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EbeginForceLandscape([In] Platform obj0)
    {
    }

    [Modifiers]
    void endForceLandscape();

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void \u003Cdefault\u003EendForceLandscape([In] Platform obj0)
    {
    }

    interface FileWriter
    {
      [Throws(new string[] {"java.lang.Throwable"})]
      void write(Fi f);
    }

    private static class __\u003C\u003EPIM
    {
      [Modifiers]
      [LineNumberTable(new byte[] {41, 246, 72})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static void lambda\u0024export\u00241([In] Platform.FileWriter obj0, [In] Fi obj1) => Vars.ui.loadAnd((Runnable) new Platform.__\u003C\u003EAnon8(obj0, obj1));

      [Modifiers]
      [LineNumberTable(new byte[] {53, 127, 12, 103, 221, 226, 61, 97, 107, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static void lambda\u0024export\u00242(
        [In] string obj0,
        [In] string obj1,
        [In] Platform.FileWriter obj2)
      {
        Exception exception1;
        try
        {
          Fi fi = Core.files.local(new StringBuilder().append(obj0).append(".").append(obj1).toString());
          obj2.write(fi);
          Vars.platform.shareFile(fi);
          return;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception exception2 = exception1;
        Vars.ui.showException(exception2);
        Log.err(exception2);
      }

      [Modifiers]
      [LineNumberTable(122)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool lambda\u0024showFileChooser\u00243([In] string obj0, [In] Fi obj1) => obj1.extEquals(obj0);

      [Modifiers]
      [LineNumberTable(new byte[] {159, 112, 162, 99, 159, 25, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static void lambda\u0024showFileChooser\u00244(
        [In] bool obj0,
        [In] Cons obj1,
        [In] string obj2,
        [In] Fi obj3)
      {
        if (!obj0)
          obj1.get((object) obj3.parent().child(new StringBuilder().append(obj3.nameWithoutExtension()).append(".").append(obj2).toString()));
        else
          obj1.get((object) obj3);
      }

      [Modifiers]
      [LineNumberTable(144)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool lambda\u0024showMultiFileChooser\u00245([In] string[] obj0, [In] Fi obj1) => Structs.contains((object[]) obj0, (object) String.instancehelper_toLowerCase(obj1.extension()));

      [Modifiers]
      [LineNumberTable(new byte[] {43, 217, 226, 61, 97, 107, 134})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static void lambda\u0024export\u00240([In] Platform.FileWriter obj0, [In] Fi obj1)
      {
        Exception exception1;
        try
        {
          obj0.write(obj1);
          return;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception exception2 = exception1;
        Vars.ui.showException(exception2);
        Log.err(exception2);
      }
    }

    [HideFromJava]
    static class __DefaultMethods
    {
      public static ClassLoader loadJar([In] Platform obj0, [In] Fi obj1, [In] string obj2)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        return Platform.\u003Cdefault\u003EloadJar(platform, obj1, obj2);
      }

      public static void updateLobby([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EupdateLobby(platform);
      }

      public static void inviteFriends([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EinviteFriends(platform);
      }

      public static void publish([In] Platform obj0, [In] Publishable obj1)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003Epublish(platform, obj1);
      }

      public static void viewListing([In] Platform obj0, [In] Publishable obj1)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EviewListing(platform, obj1);
      }

      public static void viewListingID([In] Platform obj0, [In] string obj1)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EviewListingID(platform, obj1);
      }

      public static Seq getWorkshopContent([In] Platform obj0, [In] Class obj1)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        return Platform.\u003Cdefault\u003EgetWorkshopContent(platform, obj1);
      }

      public static void openWorkshop([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EopenWorkshop(platform);
      }

      public static mindustry.net.Net.NetProvider getNet([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        return Platform.\u003Cdefault\u003EgetNet(platform);
      }

      public static Scripts createScripts([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        return Platform.\u003Cdefault\u003EcreateScripts(platform);
      }

      public static rhino.Context getScriptContext([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        return Platform.\u003Cdefault\u003EgetScriptContext(platform);
      }

      public static void updateRPC([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EupdateRPC(platform);
      }

      public static string getUUID([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        return Platform.\u003Cdefault\u003EgetUUID(platform);
      }

      public static void shareFile([In] Platform obj0, [In] Fi obj1)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EshareFile(platform, obj1);
      }

      public static void export([In] Platform obj0, [In] string obj1, [In] string obj2, [In] Platform.FileWriter obj3)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003Eexport(platform, obj1, obj2, obj3);
      }

      public static void showFileChooser(
        [In] Platform obj0,
        [In] bool obj1,
        [In] string obj2,
        [In] string obj3,
        [In] Cons obj4)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EshowFileChooser(platform, obj1, obj2, obj3, obj4);
      }

      public static void showFileChooser([In] Platform obj0, [In] bool obj1, [In] string obj2, [In] Cons obj3)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EshowFileChooser(platform, obj1, obj2, obj3);
      }

      public static void showMultiFileChooser([In] Platform obj0, [In] Cons obj1, [In] string[] obj2)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EshowMultiFileChooser(platform, obj1, obj2);
      }

      public static void hide([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003Ehide(platform);
      }

      public static void beginForceLandscape([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EbeginForceLandscape(platform);
      }

      public static void endForceLandscape([In] Platform obj0)
      {
        Platform platform = obj0;
        // ISSUE: virtual method pointer
        IntPtr num = __vmethodptr(platform, ToString);
        Platform.\u003Cdefault\u003EendForceLandscape(platform);
      }
    }

    private static class __\u003C\u003EIHM
    {
      static CallerID __\u003CGetCallerID\u003E()
      {
        if (Platform.__\u003CcallerID\u003E == null)
          Platform.__\u003CcallerID\u003E = (CallerID) new Platform.__\u003CCallerID\u003E();
        return Platform.__\u003CcallerID\u003E;
      }
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Platform.FileWriter arg\u00241;

      internal __\u003C\u003EAnon3([In] Platform.FileWriter obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Platform.__\u003C\u003EPIM.lambda\u0024export\u00241(this.arg\u00241, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly string arg\u00241;
      private readonly string arg\u00242;
      private readonly Platform.FileWriter arg\u00243;

      internal __\u003C\u003EAnon4([In] string obj0, [In] string obj1, [In] Platform.FileWriter obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => Platform.__\u003C\u003EPIM.lambda\u0024export\u00242(this.arg\u00241, this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon5([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Platform.__\u003C\u003EPIM.lambda\u0024showFileChooser\u00243(this.arg\u00241, (Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly bool arg\u00241;
      private readonly Cons arg\u00242;
      private readonly string arg\u00243;

      internal __\u003C\u003EAnon6([In] bool obj0, [In] Cons obj1, [In] string obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => Platform.__\u003C\u003EPIM.lambda\u0024showFileChooser\u00244(this.arg\u00241, this.arg\u00242, this.arg\u00243, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Boolf
    {
      private readonly string[] arg\u00241;

      internal __\u003C\u003EAnon7([In] string[] obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Platform.__\u003C\u003EPIM.lambda\u0024showMultiFileChooser\u00245(this.arg\u00241, (Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly Platform.FileWriter arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon8([In] Platform.FileWriter obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Platform.__\u003C\u003EPIM.lambda\u0024export\u00240(this.arg\u00241, this.arg\u00242);
    }
  }
}
