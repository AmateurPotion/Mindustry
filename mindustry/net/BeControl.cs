// Decompiled with JetBrains decompiler
// Type: mindustry.net.BeControl
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.files;
using arc.func;
using arc.graphics;
using arc.scene;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using arc.util.async;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.util;
using mindustry.gen;
using mindustry.graphics;
using mindustry.io;
using mindustry.ui.dialogs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class BeControl : Object
  {
    private const int updateInterval = 60;
    private AsyncExecutor executor;
    private bool checkUpdates;
    private bool updateAvailable;
    private string updateUrl;
    private int updateBuild;

    [LineNumberTable(new byte[] {159, 181, 232, 53, 108, 231, 75, 104, 251, 71, 143, 112, 159, 5, 159, 28, 187, 2, 98, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public BeControl()
    {
      BeControl beControl = this;
      this.executor = new AsyncExecutor(1);
      this.checkUpdates = true;
      if (this.active())
        Timer.schedule((Runnable) new BeControl.__\u003C\u003EAnon0(this), 60f, 60f);
      if (!OS.hasProp("becopy"))
        return;
      Exception exception;
      try
      {
        Fi dest = Fi.get(OS.prop("becopy"));
        Fi fi = Fi.get(((Class) ClassLiteral<BeControl>.Value).getProtectionDomain().getCodeSource().getLocation().toURI().getPath());
        Iterator iterator = fi.parent().findAll((Boolf) new BeControl.__\u003C\u003EAnon1(fi)).iterator();
        while (iterator.hasNext())
          ((Fi) iterator.next()).delete();
        fi.copyTo(dest);
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Throwable.instancehelper_printStackTrace(exception);
    }

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool active() => String.instancehelper_equals(mindustry.core.Version.type, (object) "bleeding-edge");

    [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/func/Intc;Larc/func/Floatc;Larc/func/Boolp;Ljava/lang/Runnable;Larc/func/Cons<Ljava/lang/Throwable;>;)V")]
    [LineNumberTable(new byte[] {123, 255, 2, 87})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void download(
      [In] string obj0,
      [In] Fi obj1,
      [In] Intc obj2,
      [In] Floatc obj3,
      [In] Boolp obj4,
      [In] Runnable obj5,
      [In] Cons obj6)
    {
      this.executor.submit((Runnable) new BeControl.__\u003C\u003EAnon11(obj0, obj1, obj2, obj4, obj3, obj5, obj6));
    }

    [LineNumberTable(new byte[] {44, 137, 103, 103, 255, 86, 102, 126, 111, 202, 127, 5, 159, 17, 255, 57, 85, 2, 97, 166, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void showUpdateDialog()
    {
      if (!this.updateAvailable)
        return;
      if (!Vars.headless)
      {
        this.checkUpdates = false;
        Vars.ui.showCustomConfirm(new StringBuilder().append(Core.bundle.format("be.update", (object) "")).append(" ").append(this.updateBuild).toString(), "@be.update.confirm", "@ok", "@be.ignore", (Runnable) new BeControl.__\u003C\u003EAnon4(this), (Runnable) new BeControl.__\u003C\u003EAnon5(this));
      }
      else
      {
        Log.info("&lcA new update is available: &lyBleeding Edge build @", (object) Integer.valueOf(this.updateBuild));
        if (Administration.Config.__\u003C\u003EautoUpdate.@bool())
        {
          Log.info((object) "&lcAuto-downloading next version...");
          Exception exception;
          try
          {
            Fi fi1 = Fi.get(((Class) ClassLiteral<BeControl>.Value).getProtectionDomain().getCodeSource().getLocation().toURI().getPath());
            Fi fi2 = fi1.sibling(new StringBuilder().append("server-be-").append(this.updateBuild).append(".jar").toString());
            this.download(this.updateUrl, fi2, (Intc) new BeControl.__\u003C\u003EAnon6(), (Floatc) new BeControl.__\u003C\u003EAnon7(), (Boolp) new BeControl.__\u003C\u003EAnon8(), (Runnable) new BeControl.__\u003C\u003EAnon9(fi2, fi1), (Cons) new BeControl.__\u003C\u003EAnon10());
            goto label_11;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              exception = (Exception) m0;
          }
          Throwable.instancehelper_printStackTrace((Exception) exception);
        }
label_11:
        this.checkUpdates = false;
      }
    }

    [LineNumberTable(new byte[] {14, 255, 6, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void checkUpdate(Boolc done) => Core.net.httpGet("https://api.github.com/repos/Anuken/MindustryBuilds/releases/latest", (Cons) new BeControl.__\u003C\u003EAnon2(this, done), (Cons) new BeControl.__\u003C\u003EAnon3());

    [Modifiers]
    [LineNumberTable(new byte[] {159, 184, 111, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241()
    {
      if (!this.checkUpdates || Vars.mobile)
        return;
      this.checkUpdate((Boolc) new BeControl.__\u003C\u003EAnon27());
    }

    [Modifiers]
    [LineNumberTable(53)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00242([In] Fi obj0, [In] Fi obj1) => !obj1.equals((object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {15, 117, 108, 118, 104, 127, 6, 113, 103, 103, 103, 214, 98, 149, 98, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024checkUpdate\u00247([In] Boolc obj0, [In] arc.Net.HttpResponse obj1)
    {
      if (object.ReferenceEquals((object) obj1.getStatus(), (object) arc.Net.HttpStatus.__\u003C\u003EOK))
      {
        Jval jval = Jval.read(obj1.getResultAsString());
        int num = Strings.parseInt(jval.getString("tag_name", "0"));
        if (num > mindustry.core.Version.build)
        {
          string str = ((Jval) jval.get("assets").asArray().find((Boolf) new BeControl.__\u003C\u003EAnon23())).getString("browser_download_url", "");
          this.updateAvailable = true;
          this.updateBuild = num;
          this.updateUrl = str;
          Core.app.post((Runnable) new BeControl.__\u003C\u003EAnon24(this, obj0));
        }
        else
          Core.app.post((Runnable) new BeControl.__\u003C\u003EAnon25(obj0));
      }
      else
        Core.app.post((Runnable) new BeControl.__\u003C\u003EAnon26(obj0));
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024checkUpdate\u00248([In] Exception obj0)
    {
    }

    [Modifiers]
    [LineNumberTable(new byte[] {50, 107, 111, 107, 127, 21, 108, 113, 159, 6, 108, 255, 40, 79, 127, 45, 191, 14, 102, 104, 191, 2, 2, 98, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showUpdateDialog\u002418()
    {
      Exception exception1;
      try
      {
        bool[] flagArray = new bool[1]{ false };
        float[] numArray1 = new float[1]{ 0.0f };
        int[] numArray2 = new int[1]{ 0 };
        Fi fi1 = Vars.bebuildDirectory.child(new StringBuilder().append("client-be-").append(this.updateBuild).append(".jar").toString());
        Fi fi2 = !OS.hasProp("becopy") ? Fi.get(((Class) ClassLiteral<BeControl>.Value).getProtectionDomain().getCodeSource().getLocation().toURI().getPath()) : Fi.get(OS.prop("becopy"));
        BaseDialog baseDialog = new BaseDialog("@be.updating");
        this.download(this.updateUrl, fi1, (Intc) new BeControl.__\u003C\u003EAnon14(numArray2), (Floatc) new BeControl.__\u003C\u003EAnon15(numArray1), (Boolp) new BeControl.__\u003C\u003EAnon16(flagArray), (Runnable) new BeControl.__\u003C\u003EAnon17(fi2, fi1), (Cons) new BeControl.__\u003C\u003EAnon18(baseDialog));
        Table cont = baseDialog.__\u003C\u003Econt;
        mindustry.ui.Bar.__\u003Cclinit\u003E();
        mindustry.ui.Bar bar = new mindustry.ui.Bar((Prov) new BeControl.__\u003C\u003EAnon19(numArray2, numArray1), (Prov) new BeControl.__\u003C\u003EAnon20(), (Floatp) new BeControl.__\u003C\u003EAnon21(numArray1));
        cont.add((Element) bar).width(400f).height(70f);
        baseDialog.__\u003C\u003Ebuttons.button("@cancel", (Drawable) Icon.cancel, (Runnable) new BeControl.__\u003C\u003EAnon22(flagArray, baseDialog)).size(210f, 64f);
        baseDialog.setFillParent(false);
        baseDialog.show();
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Vars.ui.showException((Exception) exception2);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showUpdateDialog\u002419() => this.checkUpdates = false;

    [Modifiers]
    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u002421([In] int obj0) => Core.app.post((Runnable) new BeControl.__\u003C\u003EAnon13(obj0));

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u002422([In] float obj0)
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024showUpdateDialog\u002423() => false;

    [Modifiers]
    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u002425([In] Fi obj0, [In] Fi obj1) => Core.app.post((Runnable) new BeControl.__\u003C\u003EAnon12(obj0, obj1));

    [Modifiers]
    [LineNumberTable(new byte[] {125, 113, 113, 141, 107, 105, 100, 137, 120, 104, 111, 140, 102, 102, 191, 4, 2, 98, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024download\u002426(
      [In] string obj0,
      [In] Fi obj1,
      [In] Intc obj2,
      [In] Boolp obj3,
      [In] Floatc obj4,
      [In] Runnable obj5,
      [In] Cons obj6)
    {
      Exception exception1;
      try
      {
        HttpURLConnection httpUrlConnection = (HttpURLConnection) new URL(obj0).openConnection();
        BufferedInputStream.__\u003Cclinit\u003E();
        BufferedInputStream bufferedInputStream = new BufferedInputStream(((URLConnection) httpUrlConnection).getInputStream());
        OutputStream outputStream = obj1.write(false, 4096);
        byte[] numArray = new byte[4096];
        long contentLength = (long) ((URLConnection) httpUrlConnection).getContentLength();
        long num1 = 0;
        obj2.get((int) contentLength);
        int num2;
        while ((num2 = bufferedInputStream.read(numArray, 0, numArray.Length)) >= 0 && !obj3.get())
        {
          num1 += (long) num2;
          obj4.get((float) num1 / (float) contentLength);
          outputStream.write(numArray, 0, num2);
        }
        outputStream.close();
        bufferedInputStream.close();
        if (obj3.get())
          return;
        obj5.run();
        return;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      obj6.get((object) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {100, 106, 116, 138, 111, 136, 138, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u002424([In] Fi obj0, [In] Fi obj1)
    {
      Log.info((object) "&lcSaving...");
      SaveIO.save(Vars.saveDirectory.child("autosavebe.msav"));
      Log.info((object) "&lcAutosaved.");
      Vars.netServer.kickAll(Packets.KickReason.__\u003C\u003EserverRestarting);
      Threads.sleep(32L);
      Log.info((object) "&lcVersion downloaded, exiting. Note that if you are not using a auto-restart script, the server will not restart automatically.");
      obj0.copyTo(obj1);
      obj0.delete();
      java.lang.System.exit(2);
    }

    [Modifiers]
    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u002420([In] int obj0) => Log.info("&ly| Size: @ MB.", (object) Strings.@fixed((float) obj0 / 1024f / 1024f, 2));

    [Modifiers]
    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u00249([In] int[] obj0, [In] int obj1) => obj0[0] = obj1;

    [Modifiers]
    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u002410([In] float[] obj0, [In] float obj1) => obj0[0] = obj1;

    [Modifiers]
    [LineNumberTable(109)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024showUpdateDialog\u002411([In] bool[] obj0) => obj0[0];

    [Modifiers]
    [LineNumberTable(new byte[] {61, 108, 127, 85, 31, 75, 198, 184, 2, 97, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u002412([In] Fi obj0, [In] Fi obj1)
    {
      IOException ioException1;
      try
      {
        java.lang.Runtime runtime = java.lang.Runtime.getRuntime();
        string[] strArray;
        if (OS.isMac)
          strArray = new string[7]
          {
            "java",
            "-XstartOnFirstThread",
            new StringBuilder().append("-DlastBuild=").append(mindustry.core.Version.build).toString(),
            "-Dberestart",
            new StringBuilder().append("-Dbecopy=").append(obj0.absolutePath()).toString(),
            "-jar",
            obj1.absolutePath()
          };
        else
          strArray = new string[6]
          {
            "java",
            new StringBuilder().append("-DlastBuild=").append(mindustry.core.Version.build).toString(),
            "-Dberestart",
            new StringBuilder().append("-Dbecopy=").append(obj0.absolutePath()).toString(),
            "-jar",
            obj1.absolutePath()
          };
        runtime.exec(strArray);
        java.lang.System.exit(0);
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Vars.ui.showException((Exception) ioException2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {70, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u002413([In] BaseDialog obj0, [In] Exception obj1)
    {
      obj0.hide();
      Vars.ui.showException(obj1);
    }

    [Modifiers]
    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024showUpdateDialog\u002414([In] int[] obj0, [In] float[] obj1) => obj0[0] == 0 ? Core.bundle.get("be.updating") : new StringBuilder().append(ByteCodeHelper.f2i(obj1[0] * (float) obj0[0]) / 1024 / 1024).append("/").append(obj0[0] / 1024 / 1024).append(" MB").toString();

    [Modifiers]
    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Color lambda\u0024showUpdateDialog\u002415() => Pal.accent;

    [Modifiers]
    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024showUpdateDialog\u002416([In] float[] obj0) => obj0[0];

    [Modifiers]
    [LineNumberTable(new byte[] {76, 100, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showUpdateDialog\u002417([In] bool[] obj0, [In] BaseDialog obj1)
    {
      obj0[0] = true;
      obj1.hide();
    }

    [Modifiers]
    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024checkUpdate\u00243([In] Jval obj0) => String.instancehelper_startsWith(obj0.getString("name", ""), !Vars.headless ? "Mindustry-BE-Desktop" : "Mindustry-BE-Server");

    [Modifiers]
    [LineNumberTable(new byte[] {25, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024checkUpdate\u00244([In] Boolc obj0)
    {
      this.showUpdateDialog();
      obj0.get(true);
    }

    [Modifiers]
    [LineNumberTable(79)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024checkUpdate\u00245([In] Boolc obj0) => obj0.get(false);

    [Modifiers]
    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024checkUpdate\u00246([In] Boolc obj0) => obj0.get(false);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00240([In] bool obj0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isUpdateAvailable() => this.updateAvailable;

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly BeControl arg\u00241;

      internal __\u003C\u003EAnon0([In] BeControl obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly Fi arg\u00241;

      internal __\u003C\u003EAnon1([In] Fi obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (BeControl.lambda\u0024new\u00242(this.arg\u00241, (Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly BeControl arg\u00241;
      private readonly Boolc arg\u00242;

      internal __\u003C\u003EAnon2([In] BeControl obj0, [In] Boolc obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024checkUpdate\u00247(this.arg\u00242, (arc.Net.HttpResponse) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => BeControl.lambda\u0024checkUpdate\u00248((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly BeControl arg\u00241;

      internal __\u003C\u003EAnon4([In] BeControl obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024showUpdateDialog\u002418();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly BeControl arg\u00241;

      internal __\u003C\u003EAnon5([In] BeControl obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024showUpdateDialog\u002419();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Intc
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void get([In] int obj0) => BeControl.lambda\u0024showUpdateDialog\u002421(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Floatc
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void get([In] float obj0) => BeControl.lambda\u0024showUpdateDialog\u002422(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolp
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public bool get() => (BeControl.lambda\u0024showUpdateDialog\u002423() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly Fi arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon9([In] Fi obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => BeControl.lambda\u0024showUpdateDialog\u002425(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public void get([In] object obj0) => Throwable.instancehelper_printStackTrace((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly string arg\u00241;
      private readonly Fi arg\u00242;
      private readonly Intc arg\u00243;
      private readonly Boolp arg\u00244;
      private readonly Floatc arg\u00245;
      private readonly Runnable arg\u00246;
      private readonly Cons arg\u00247;

      internal __\u003C\u003EAnon11(
        [In] string obj0,
        [In] Fi obj1,
        [In] Intc obj2,
        [In] Boolp obj3,
        [In] Floatc obj4,
        [In] Runnable obj5,
        [In] Cons obj6)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
        this.arg\u00246 = obj5;
        this.arg\u00247 = obj6;
      }

      public void run() => BeControl.lambda\u0024download\u002426(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, this.arg\u00246, this.arg\u00247);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly Fi arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon12([In] Fi obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => BeControl.lambda\u0024showUpdateDialog\u002424(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly int arg\u00241;

      internal __\u003C\u003EAnon13([In] int obj0) => this.arg\u00241 = obj0;

      public void run() => BeControl.lambda\u0024showUpdateDialog\u002420(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Intc
    {
      private readonly int[] arg\u00241;

      internal __\u003C\u003EAnon14([In] int[] obj0) => this.arg\u00241 = obj0;

      public void get([In] int obj0) => BeControl.lambda\u0024showUpdateDialog\u00249(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Floatc
    {
      private readonly float[] arg\u00241;

      internal __\u003C\u003EAnon15([In] float[] obj0) => this.arg\u00241 = obj0;

      public void get([In] float obj0) => BeControl.lambda\u0024showUpdateDialog\u002410(this.arg\u00241, obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Boolp
    {
      private readonly bool[] arg\u00241;

      internal __\u003C\u003EAnon16([In] bool[] obj0) => this.arg\u00241 = obj0;

      public bool get() => (BeControl.lambda\u0024showUpdateDialog\u002411(this.arg\u00241) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly Fi arg\u00241;
      private readonly Fi arg\u00242;

      internal __\u003C\u003EAnon17([In] Fi obj0, [In] Fi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => BeControl.lambda\u0024showUpdateDialog\u002412(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Cons
    {
      private readonly BaseDialog arg\u00241;

      internal __\u003C\u003EAnon18([In] BaseDialog obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => BeControl.lambda\u0024showUpdateDialog\u002413(this.arg\u00241, (Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Prov
    {
      private readonly int[] arg\u00241;
      private readonly float[] arg\u00242;

      internal __\u003C\u003EAnon19([In] int[] obj0, [In] float[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get() => (object) BeControl.lambda\u0024showUpdateDialog\u002414(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Prov
    {
      internal __\u003C\u003EAnon20()
      {
      }

      public object get() => (object) BeControl.lambda\u0024showUpdateDialog\u002415();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Floatp
    {
      private readonly float[] arg\u00241;

      internal __\u003C\u003EAnon21([In] float[] obj0) => this.arg\u00241 = obj0;

      public float get() => BeControl.lambda\u0024showUpdateDialog\u002416(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Runnable
    {
      private readonly bool[] arg\u00241;
      private readonly BaseDialog arg\u00242;

      internal __\u003C\u003EAnon22([In] bool[] obj0, [In] BaseDialog obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => BeControl.lambda\u0024showUpdateDialog\u002417(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon23 : Boolf
    {
      internal __\u003C\u003EAnon23()
      {
      }

      public bool get([In] object obj0) => (BeControl.lambda\u0024checkUpdate\u00243((Jval) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon24 : Runnable
    {
      private readonly BeControl arg\u00241;
      private readonly Boolc arg\u00242;

      internal __\u003C\u003EAnon24([In] BeControl obj0, [In] Boolc obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024checkUpdate\u00244(this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon25 : Runnable
    {
      private readonly Boolc arg\u00241;

      internal __\u003C\u003EAnon25([In] Boolc obj0) => this.arg\u00241 = obj0;

      public void run() => BeControl.lambda\u0024checkUpdate\u00245(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon26 : Runnable
    {
      private readonly Boolc arg\u00241;

      internal __\u003C\u003EAnon26([In] Boolc obj0) => this.arg\u00241 = obj0;

      public void run() => BeControl.lambda\u0024checkUpdate\u00246(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon27 : Boolc
    {
      internal __\u003C\u003EAnon27()
      {
      }

      public void get([In] bool obj0) => BeControl.lambda\u0024new\u00240(obj0);
    }
  }
}
