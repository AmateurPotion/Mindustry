// Decompiled with JetBrains decompiler
// Type: mindustry.net.CrashSender
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.util;
using arc.util.io;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.text;
using java.util;
using mindustry.gen;
using mindustry.mod;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.net
{
  public class CrashSender : Object
  {
    [Signature("(Ljava/lang/Throwable;Larc/func/Cons<Ljava/io/File;>;)V")]
    [LineNumberTable(new byte[] {2, 191, 7, 4, 97, 251, 69, 120, 185, 127, 16, 197, 138, 102, 154, 117, 122, 117, 127, 15, 124, 110, 110, 98, 255, 37, 69, 255, 0, 61, 98, 103, 255, 8, 69, 127, 46, 127, 0, 119, 184, 31, 0, 98, 255, 4, 69, 114, 211, 26, 225, 70, 120, 179, 58, 193, 103, 165, 198, 108, 108, 152, 58, 161, 140, 168, 113, 113, 113, 113, 113, 115, 115, 113, 113, 113, 114, 113, 145, 140, 138, 255, 15, 76, 102, 144, 184, 2, 98, 167, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void send(Exception exception, Cons writeListener)
    {
      Exception exception1;
      try
      {
        try
        {
          Log.err(exception);
          goto label_8;
        }
        catch (Exception ex)
        {
          ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        }
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_4;
      }
      Exception exception2;
      try
      {
        Throwable.instancehelper_printStackTrace(exception);
        goto label_8;
      }
      catch (Exception ex)
      {
        exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception3 = exception2;
      goto label_62;
label_4:
      exception3 = exception1;
      goto label_62;
label_8:
      Exception exception4;
      try
      {
        try
        {
          Core.settings.manualSave();
          goto label_13;
        }
        catch (Exception ex)
        {
          ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        }
      }
      catch (Exception ex)
      {
        exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_12;
      }
      goto label_13;
label_12:
      exception3 = exception4;
      goto label_62;
label_13:
      Exception exception5;
      Exception exception6;
      try
      {
        if (mindustry.core.Version.build == -1 || String.instancehelper_equals(java.lang.System.getProperty("user.name"), (object) "anuke") && String.instancehelper_equals("release", (object) mindustry.core.Version.modifier))
          CrashSender.ret();
        if (mindustry.core.Version.number == 0)
        {
          try
          {
            ObjectMap properties = new ObjectMap();
            PropertiesUtils.load(properties, (Reader) new InputStreamReader(((Class) ClassLiteral<CrashSender>.Value).getResourceAsStream("/version.properties")));
            mindustry.core.Version.type = (string) properties.get((object) "type");
            mindustry.core.Version.number = Integer.parseInt((string) properties.get((object) "number"));
            mindustry.core.Version.modifier = (string) properties.get((object) "modifier");
            string str = (string) properties.get((object) "build");
            object obj = (object) ".";
            CharSequence charSequence1;
            charSequence1.__\u003Cref\u003E = (__Null) obj;
            CharSequence charSequence2 = charSequence1;
            if (String.instancehelper_contains(str, charSequence2))
            {
              string[] strArray = String.instancehelper_split((string) properties.get((object) "build"), "\\.");
              mindustry.core.Version.build = Integer.parseInt(strArray[0]);
              mindustry.core.Version.revision = Integer.parseInt(strArray[1]);
              goto label_26;
            }
            else
            {
              mindustry.core.Version.build = !Strings.canParseInt((string) properties.get((object) "build")) ? -1 : Integer.parseInt((string) properties.get((object) "build"));
              goto label_26;
            }
          }
          catch (Exception ex)
          {
            exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
        }
        else
          goto label_26;
      }
      catch (Exception ex)
      {
        exception6 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_22;
      }
      Exception exception7 = exception5;
      Exception exception8;
      try
      {
        Throwable.instancehelper_printStackTrace(exception7);
        Log.err("Failed to parse version.");
        goto label_26;
      }
      catch (Exception ex)
      {
        exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception3 = exception8;
      goto label_62;
label_22:
      exception3 = exception6;
      goto label_62;
label_26:
      Exception exception9;
      Exception exception10;
      try
      {
        try
        {
          File.__\u003Cclinit\u003E();
          File file = new File(OS.getAppDataDirectoryString("Mindustry"), new StringBuilder().append("crashes/crash-report-").append(((DateFormat) new SimpleDateFormat("MM_dd_yyyy_HH_mm_ss")).format(new Date())).append(".txt").toString());
          new Fi(OS.getAppDataDirectoryString("Mindustry")).child("crashes").mkdirs();
          new Fi(file).writeString(CrashSender.createReport(CrashSender.parseException(exception)));
          writeListener.get((object) file);
          goto label_34;
        }
        catch (Exception ex)
        {
          exception9 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception10 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_30;
      }
      Exception th = exception9;
      Exception exception11;
      try
      {
        Log.err("Failed to save local crash report.", th);
        goto label_34;
      }
      catch (Exception ex)
      {
        exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception3 = exception11;
      goto label_62;
label_30:
      exception3 = exception10;
      goto label_62;
label_34:
      Exception exception12;
      try
      {
        try
        {
          if (!Core.settings.getBool("crashreport", true))
          {
            CrashSender.ret();
            goto label_40;
          }
          else
            goto label_40;
        }
        catch (Exception ex)
        {
          ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        }
      }
      catch (Exception ex)
      {
        exception12 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_39;
      }
      goto label_40;
label_39:
      exception3 = exception12;
      goto label_62;
label_40:
      Exception exception13;
      try
      {
        try
        {
          if (Vars.mods != null)
          {
            if (!Vars.mods.list().isEmpty())
            {
              CrashSender.ret();
              goto label_47;
            }
            else
              goto label_47;
          }
          else
            goto label_47;
        }
        catch (Exception ex)
        {
          ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        }
      }
      catch (Exception ex)
      {
        exception13 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_46;
      }
      goto label_47;
label_46:
      exception3 = exception13;
      goto label_62;
label_47:
      int num1;
      int num2;
      Exception exception14;
      try
      {
        if (mindustry.core.Version.number == 0)
          CrashSender.ret();
        num1 = 0;
        num2 = 0;
        try
        {
          num1 = Vars.net.active() ? 1 : 0;
          num2 = Vars.net.server() ? 1 : 0;
          Vars.net.dispose();
          goto label_55;
        }
        catch (Exception ex)
        {
          ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        }
      }
      catch (Exception ex)
      {
        exception14 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_54;
      }
      goto label_55;
label_54:
      exception3 = exception14;
      goto label_62;
label_55:
      Exception exception15;
      try
      {
        JsonValue jsonValue = new JsonValue(JsonValue.ValueType.__\u003C\u003Eobject);
        int num3 = num1;
        int num4 = num2;
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon1(jsonValue));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon2(jsonValue));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon3(jsonValue));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon4(jsonValue));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon5(jsonValue));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon6(jsonValue, num3 != 0));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon7(jsonValue, num4 != 0));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon8(jsonValue));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon9(jsonValue));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon10(jsonValue));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon11(jsonValue, exception));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon12(jsonValue));
        CrashSender.ex((Runnable) new CrashSender.__\u003C\u003EAnon13(jsonValue));
        bool[] flagArray = new bool[1]{ false };
        Log.info((object) "Sending crash report.");
        CrashSender.httpPost("http://192.99.169.18/report", jsonValue.toJson(JsonWriter.OutputType.__\u003C\u003Ejson), (Cons) new CrashSender.__\u003C\u003EAnon14(flagArray), (Cons) new CrashSender.__\u003C\u003EAnon15(flagArray));
        try
        {
          while (!flagArray[0])
            Thread.sleep(30L);
          goto label_63;
        }
        catch (InterruptedException ex)
        {
        }
      }
      catch (Exception ex)
      {
        exception15 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_61;
      }
      goto label_63;
label_61:
      exception3 = exception15;
label_62:
      Throwable.instancehelper_printStackTrace(exception3);
label_63:
      CrashSender.ret();
    }

    [LineNumberTable(new byte[] {159, 170, 102, 121, 155, 127, 39, 127, 28, 121, 121, 255, 99, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string createReport(string error)
    {
      string str = "Mindustry has crashed. How unfortunate.\n";
      if (Vars.mods.list().size == 0 && mindustry.core.Version.build != -1)
        str = new StringBuilder().append(str).append("Report this at https://github.com/Anuken/Mindustry/issues/new?labels=bug&template=bug_report.md\n\n").toString();
      return new StringBuilder().append(str).append("Version: ").append(mindustry.core.Version.combined()).append(!Vars.headless ? "" : " (Server)").append("\nOS: ").append(java.lang.System.getProperty("os.name")).append(" x").append(!OS.is64Bit ? "32" : "64").append("\nJava Version: ").append(java.lang.System.getProperty("java.version")).append("\nJava Architecture: ").append(java.lang.System.getProperty("sun.arch.data.model")).append("\n").append(Vars.mods.list().size).append(" Mods").append(!Vars.mods.list().isEmpty() ? new StringBuilder().append(": ").append(Vars.mods.list().toString(", ", (Func) new CrashSender.__\u003C\u003EAnon0())).toString() : "").append("\n\n").append(error).toString();
    }

    [LineNumberTable(new byte[] {127, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ret() => java.lang.System.exit(1);

    [LineNumberTable(new byte[] {160, 71, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string parseException([In] Exception obj0)
    {
      StringWriter stringWriter = new StringWriter();
      PrintWriter printWriter = new PrintWriter((Writer) stringWriter);
      Throwable.instancehelper_printStackTrace(obj0, printWriter);
      return stringWriter.toString();
    }

    [LineNumberTable(new byte[] {160, 79, 151, 34, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ex([In] Runnable obj0)
    {
      try
      {
        obj0.run();
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
    }

    [Signature("(Ljava/lang/String;Ljava/lang/String;Larc/func/Cons<Larc/Net$HttpResponse;>;Larc/func/Cons<Ljava/lang/Throwable;>;)V")]
    [LineNumberTable(new byte[] {160, 67, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void httpPost([In] string obj0, [In] string obj1, [In] Cons obj2, [In] Cons obj3) => new NetJavaImpl().http(new arc.Net.HttpRequest().method(arc.Net.HttpMethod.__\u003C\u003EPOST).content(obj1).url(obj0), obj2, obj3);

    [Modifiers]
    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024createReport\u00240([In] Mods.LoadedMod obj0) => new StringBuilder().append(obj0.__\u003C\u003Ename).append(":").append(obj0.__\u003C\u003Emeta.version).toString();

    [Modifiers]
    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u00241([In] JsonValue obj0) => obj0.addChild("versionType", new JsonValue(mindustry.core.Version.type));

    [Modifiers]
    [LineNumberTable(136)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u00242([In] JsonValue obj0) => obj0.addChild("versionNumber", new JsonValue((long) mindustry.core.Version.number));

    [Modifiers]
    [LineNumberTable(137)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u00243([In] JsonValue obj0) => obj0.addChild("versionModifier", new JsonValue(mindustry.core.Version.modifier));

    [Modifiers]
    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u00244([In] JsonValue obj0) => obj0.addChild("build", new JsonValue((long) mindustry.core.Version.build));

    [Modifiers]
    [LineNumberTable(139)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u00245([In] JsonValue obj0) => obj0.addChild("revision", new JsonValue((long) mindustry.core.Version.revision));

    [Modifiers]
    [LineNumberTable(140)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u00246([In] JsonValue obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      obj0.addChild("net", new JsonValue(num != 0));
    }

    [Modifiers]
    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u00247([In] JsonValue obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      obj0.addChild("server", new JsonValue(num != 0));
    }

    [Modifiers]
    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u00248([In] JsonValue obj0) => obj0.addChild("players", new JsonValue((long) Groups.player.size()));

    [Modifiers]
    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u00249([In] JsonValue obj0) => obj0.addChild("state", new JsonValue(Vars.state.getState().name()));

    [Modifiers]
    [LineNumberTable(144)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u002410([In] JsonValue obj0) => obj0.addChild("os", new JsonValue(new StringBuilder().append(java.lang.System.getProperty("os.name")).append("x").append(!OS.is64Bit ? "32" : "64").toString()));

    [Modifiers]
    [LineNumberTable(145)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u002411([In] JsonValue obj0, [In] Exception obj1) => obj0.addChild("trace", new JsonValue(CrashSender.parseException(obj1)));

    [Modifiers]
    [LineNumberTable(146)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u002412([In] JsonValue obj0) => obj0.addChild("javaVersion", new JsonValue(java.lang.System.getProperty("java.version")));

    [Modifiers]
    [LineNumberTable(147)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u002413([In] JsonValue obj0) => obj0.addChild("javaArch", new JsonValue(java.lang.System.getProperty("sun.arch.data.model")));

    [Modifiers]
    [LineNumberTable(new byte[] {104, 106, 100, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u002414([In] bool[] obj0, [In] arc.Net.HttpResponse obj1)
    {
      Log.info((object) "Crash sent successfully.");
      obj0[0] = true;
      java.lang.System.exit(1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {108, 102, 100, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024send\u002415([In] bool[] obj0, [In] Exception obj1)
    {
      Throwable.instancehelper_printStackTrace(obj1);
      obj0[0] = true;
      java.lang.System.exit(-1);
    }

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CrashSender()
    {
    }

    [LineNumberTable(new byte[] {159, 184, 127, 35, 159, 1, 34, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void log(Exception exception)
    {
      try
      {
        Core.settings.getDataDirectory().child("crashes").child(new StringBuilder().append("crash_").append(java.lang.System.currentTimeMillis()).append(".txt").toString()).writeString(CrashSender.createReport(Strings.neatError(exception)));
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) CrashSender.lambda\u0024createReport\u00240((Mods.LoadedMod) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon1([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u00241(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon2([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u00242(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon3([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u00243(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon4([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u00244(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon5([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u00245(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly JsonValue arg\u00241;
      private readonly bool arg\u00242;

      internal __\u003C\u003EAnon6([In] JsonValue obj0, [In] bool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => CrashSender.lambda\u0024send\u00246(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Runnable
    {
      private readonly JsonValue arg\u00241;
      private readonly bool arg\u00242;

      internal __\u003C\u003EAnon7([In] JsonValue obj0, [In] bool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => CrashSender.lambda\u0024send\u00247(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon8([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u00248(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon9([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u00249(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon10([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u002410(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly JsonValue arg\u00241;
      private readonly Exception arg\u00242;

      internal __\u003C\u003EAnon11([In] JsonValue obj0, [In] Exception obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => CrashSender.lambda\u0024send\u002411(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon12([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u002412(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      private readonly JsonValue arg\u00241;

      internal __\u003C\u003EAnon13([In] JsonValue obj0) => this.arg\u00241 = obj0;

      public void run() => CrashSender.lambda\u0024send\u002413(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly bool[] arg\u00241;

      internal __\u003C\u003EAnon14([In] bool[] obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => CrashSender.lambda\u0024send\u002414(this.arg\u00241, (arc.Net.HttpResponse) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly bool[] arg\u00241;

      internal __\u003C\u003EAnon15([In] bool[] obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => CrashSender.lambda\u0024send\u002415(this.arg\u00241, (Exception) obj0);
    }
  }
}
