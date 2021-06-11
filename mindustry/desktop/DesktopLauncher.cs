// Decompiled with JetBrains decompiler
// Type: mindustry.desktop.DesktopLauncher
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.backend.sdl;
using arc.backend.sdl.jni;
using arc.files;
using arc.func;
using arc.math;
using arc.util;
using arc.util.serialization;
using club.minnced.discord.rpc;
using com.codedisaster.steamworks;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using mindustry.desktop.steam;
using mindustry.game;
using mindustry.gen;
using mindustry.net;
using mindustry.type;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.desktop
{
  public class DesktopLauncher : ClientLauncher
  {
    public const string discordID = "610508934456934412";
    internal bool useDiscord;
    internal bool loadError;
    internal Exception steamError;

    [LineNumberTable(new byte[] {159, 177, 101, 255, 4, 73, 2, 97, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void main(string[] arg)
    {
      Exception exception;
      try
      {
        Vars.loadLogger();
        SdlApplication sdlApplication = new SdlApplication((ApplicationListener) new DesktopLauncher(arg), (SdlConfig) new DesktopLauncher.\u0031());
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      DesktopLauncher.handleCrash(exception);
    }

    [LineNumberTable(new byte[] {159, 190, 232, 46, 255, 12, 83, 101, 127, 1, 149, 139, 118, 106, 255, 31, 69, 226, 60, 98, 103, 112, 218, 134, 127, 15, 127, 61, 8, 235, 70, 245, 73, 133, 103, 103, 146, 103, 166, 108, 255, 10, 73, 226, 57, 97, 102, 234, 69, 226, 60, 98, 102, 112, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DesktopLauncher(string[] args)
    {
      DesktopLauncher desktopLauncher = this;
      this.useDiscord = OS.is64Bit && !OS.isARM && !OS.hasProp("nodiscord");
      this.loadError = false;
      mindustry.core.Version.init();
      string modifier = mindustry.core.Version.modifier;
      object obj1 = (object) "steam";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence charSequence2 = charSequence1;
      int num = String.instancehelper_contains(modifier, charSequence2) ? 1 : 0;
      Vars.testMobile = Seq.with((object[]) args).contains((object) "-testMobile");
      if (this.useDiscord)
      {
        Exception exception;
        try
        {
          DiscordRPC.INSTANCE.Discord_Initialize("610508934456934412", (DiscordEventHandlers) null, true, "1127400");
          Log.info((object) "Initialized Discord rich presence.");
          java.lang.Runtime runtime = java.lang.Runtime.getRuntime();
          Thread.__\u003Cclinit\u003E();
          DiscordRPC instance = DiscordRPC.INSTANCE;
          Objects.requireNonNull((object) instance);
          Thread thread = new Thread((Runnable) new DesktopLauncher.__\u003C\u003EAnon0(instance));
          runtime.addShutdownHook(thread);
          goto label_4;
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception e = exception;
        this.useDiscord = false;
        Log.err("Failed to initialize discord. Enable debug logging for details.");
        Log.debug("Discord init error: \n@\n", (object) Strings.getStackTrace(e));
      }
label_4:
      if (num == 0)
        return;
      Fi[] fiArray = new Fi(".").parent().list();
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Fi fi = fiArray[index];
        string str = fi.name();
        object obj2 = (object) "steam";
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence3 = charSequence1;
        if (String.instancehelper_contains(str, charSequence3) && (String.instancehelper_equals(fi.extension(), (object) "dll") || String.instancehelper_equals(fi.extension(), (object) "so") || String.instancehelper_equals(fi.extension(), (object) "dylib")))
          fi.delete();
      }
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new DesktopLauncher.__\u003C\u003EAnon1(this));
      Exception exception1;
      try
      {
        try
        {
          SteamAPI.loadLibraries();
          if (!SteamAPI.init())
          {
            this.loadError = true;
            Log.err("Steam client not running.");
          }
          else
          {
            this.initSteam(args);
            Vars.steam = true;
          }
          if (!SteamAPI.restartAppIfNecessary(1127400))
            return;
          java.lang.System.exit(0);
          return;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NullPointerException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_21;
      }
      Vars.steam = false;
      Log.info((object) "Running in offline mode.");
      return;
label_21:
      Exception exception2 = exception1;
      Vars.steam = false;
      Log.err("Failed to load Steam native libraries.");
      this.logSteamError(exception2);
    }

    [LineNumberTable(new byte[] {119, 107, 98, 103, 140, 159, 160, 71, 242, 69, 162, 131, 244, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void handleCrash([In] Exception obj0)
    {
      Cons cons = (Cons) new DesktopLauncher.__\u003C\u003EAnon5();
      int num1 = 0;
      string finalMessage = Strings.getFinalMessage(obj0);
      string str1 = Strings.getCauses(obj0).toString();
      string str2 = str1;
      object obj1 = (object) "Couldn't create window";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence charSequence2 = charSequence1;
      if (!String.instancehelper_contains(str2, charSequence2))
      {
        string str3 = str1;
        object obj2 = (object) "OpenGL 2.0 or higher";
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence3 = charSequence1;
        if (!String.instancehelper_contains(str3, charSequence3))
        {
          string lowerCase = String.instancehelper_toLowerCase(str1);
          object obj3 = (object) "pixel format";
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence4 = charSequence1;
          if (!String.instancehelper_contains(lowerCase, charSequence4))
          {
            string str4 = str1;
            object obj4 = (object) "GLEW";
            charSequence1.__\u003Cref\u003E = (__Null) obj4;
            CharSequence charSequence5 = charSequence1;
            if (!String.instancehelper_contains(str4, charSequence5))
            {
              string str5 = str1;
              object obj5 = (object) "unsupported combination of formats";
              charSequence1.__\u003Cref\u003E = (__Null) obj5;
              CharSequence charSequence6 = charSequence1;
              if (!String.instancehelper_contains(str5, charSequence6))
                goto label_6;
            }
          }
        }
      }
      cons.get((object) (Runnable) new DesktopLauncher.__\u003C\u003EAnon6(str1, finalMessage));
      num1 = 1;
label_6:
      int num2 = num1;
      CrashSender.send(obj0, (Cons) new DesktopLauncher.__\u003C\u003EAnon7(obj0, num2 != 0, cons));
    }

    [LineNumberTable(new byte[] {69, 111, 106, 106, 106, 139, 246, 94, 245, 70, 255, 0, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void initSteam([In] string[] obj0)
    {
      SVars.net = new SNet((mindustry.net.Net.NetProvider) new ArcNetProvider());
      SVars.stats = new SStats();
      SVars.workshop = new SWorkshop();
      SVars.user = new SUser();
      bool[] flagArray = new bool[1]{ false };
      Events.on((Class) ClassLiteral<EventType.ClientLoadEvent>.Value, (Cons) new DesktopLauncher.__\u003C\u003EAnon2(this, obj0));
      Events.on((Class) ClassLiteral<EventType.DisposeEvent>.Value, (Cons) new DesktopLauncher.__\u003C\u003EAnon3(flagArray));
      java.lang.Runtime runtime = java.lang.Runtime.getRuntime();
      Thread.__\u003Cclinit\u003E();
      Thread thread = new Thread((Runnable) new DesktopLauncher.__\u003C\u003EAnon4(flagArray));
      runtime.addShutdownHook(thread);
    }

    [LineNumberTable(new byte[] {57, 103, 103, 102, 127, 20, 103, 123, 255, 11, 61, 255, 89, 69, 2, 98, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void logSteamError([In] Exception obj0)
    {
      this.steamError = obj0;
      this.loadError = true;
      Log.err(obj0);
      FileOutputStream fileOutputStream;
      Exception exception1;
      Exception exception2;
      try
      {
        FileOutputStream.__\u003Cclinit\u003E();
        fileOutputStream = new FileOutputStream(new StringBuilder().append("steam-error-log-").append(java.lang.System.nanoTime()).append(".txt").toString());
        try
        {
          string str = Strings.neatError(obj0);
          ((OutputStream) fileOutputStream).write(String.instancehelper_getBytes(str));
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_8;
        }
        ((OutputStream) fileOutputStream).close();
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception2 = (Exception) m0;
          goto label_9;
        }
      }
label_8:
      Exception exception3 = exception1;
      Exception exception4;
      Exception exception5;
      Exception exception6;
      try
      {
        exception4 = exception3;
        try
        {
          ((OutputStream) fileOutputStream).close();
          goto label_23;
        }
        catch (Exception ex)
        {
          exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception6 = (Exception) m0;
          goto label_17;
        }
      }
      Exception exception7 = exception5;
      Exception exception8;
      try
      {
        Exception exception9 = exception7;
        Throwable.instancehelper_addSuppressed(exception4, exception9);
        goto label_23;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception8 = (Exception) m0;
      }
      Exception exception10 = exception8;
      goto label_28;
label_17:
      exception10 = exception6;
      goto label_28;
label_23:
      Exception exception11;
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception4);
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception11 = (Exception) m0;
      }
      exception10 = exception11;
      goto label_28;
label_9:
      exception10 = exception2;
label_28:
      Log.err((Exception) exception10);
    }

    [LineNumberTable(new byte[] {160, 201, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void message([In] string obj0) => SDL.SDL_ShowSimpleMessageBox(16, "oh no", obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {24, 104, 213})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] EventType.ClientLoadEvent obj0)
    {
      if (this.steamError == null)
        return;
      Core.app.post((Runnable) new DesktopLauncher.__\u003C\u003EAnon10(this));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {76, 127, 11, 113, 121, 153, 148, 240, 73, 245, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024initSteam\u00245([In] string[] obj0, [In] EventType.ClientLoadEvent obj1)
    {
      Core.settings.defaults((object) "name", (object) SVars.net.__\u003C\u003Efriends.getPersonaName());
      if (String.instancehelper_isEmpty(Vars.player.name))
      {
        Vars.player.name = SVars.net.__\u003C\u003Efriends.getPersonaName();
        Core.settings.put("name", (object) Vars.player.name);
      }
      Vars.steamPlayerName = SVars.net.__\u003C\u003Efriends.getPersonaName();
      Core.app.addListener((ApplicationListener) new DesktopLauncher.\u0032(this));
      Core.app.post((Runnable) new DesktopLauncher.__\u003C\u003EAnon9(obj0));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {106, 101, 100})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024initSteam\u00246([In] bool[] obj0, [In] EventType.DisposeEvent obj1)
    {
      SteamAPI.shutdown();
      obj0[0] = true;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {112, 101, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024initSteam\u00247([In] bool[] obj0)
    {
      if (obj0[0])
        return;
      SteamAPI.shutdown();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {127, 191, 26, 250, 60})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024handleCrash\u00248([In] string obj0, [In] string obj1)
    {
      string str = obj0;
      object obj = (object) "Couldn't create window";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      DesktopLauncher.message(!String.instancehelper_contains(str, charSequence2) ? new StringBuilder().append("Your graphics card does not support the right OpenGL features.\nTry to update your graphics drivers. If this doesn't work, your computer may not support Mindustry.\n\nFull message: ").append(obj1).toString() : new StringBuilder().append("A graphics initialization error has occured! Try to update your graphics drivers:\n").append(obj1).toString());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 96, 162, 103, 99, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024handleCrash\u002410(
      [In] Exception obj0,
      [In] bool obj1,
      [In] Cons obj2,
      [In] File obj3)
    {
      int num = obj1 ? 1 : 0;
      Exception finalCause = Strings.getFinalCause(obj0);
      if (num != 0)
        return;
      obj2.get((object) (Runnable) new DesktopLauncher.__\u003C\u003EAnon8(obj3, finalCause));
    }

    [Modifiers]
    [LineNumberTable(189)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024handleCrash\u00249([In] File obj0, [In] Exception obj1)
    {
      StringBuilder stringBuilder = new StringBuilder().append("A crash has occured. It has been saved in:\n").append(obj0.getAbsolutePath()).append("\n");
      string simpleName = Object.instancehelper_getClass((object) obj1).getSimpleName();
      object obj2 = (object) "";
      object obj3 = (object) "Exception";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence2 = charSequence1;
      object obj4 = obj2;
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      CharSequence charSequence3 = charSequence1;
      string str = String.instancehelper_replace(simpleName, charSequence2, charSequence3);
      DesktopLauncher.message(stringBuilder.append(str).append(Throwable.instancehelper_getMessage(obj1) != null ? new StringBuilder().append(":\n").append(Throwable.instancehelper_getMessage(obj1)).toString() : "").toString());
    }

    [Modifiers]
    [LineNumberTable(new byte[] {93, 154, 105, 223, 38, 226, 61, 97, 121, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024initSteam\u00244([In] string[] obj0)
    {
      if (obj0.Length < 2)
        return;
      if (!String.instancehelper_equals(obj0[0], (object) "+connect_lobby"))
        return;
      Exception exception1;
      try
      {
        long num = Long.parseLong(obj0[1]);
        Vars.ui.join.connect(new StringBuilder().append("steam:").append(num).toString(), 6567);
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
      Log.err("Failed to parse steam lobby ID: @", (object) Throwable.instancehelper_getMessage((Exception) exception2));
      Throwable.instancehelper_printStackTrace((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242() => Core.app.post((Runnable) new DesktopLauncher.__\u003C\u003EAnon11(this));

    [Modifiers]
    [LineNumberTable(75)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00241() => Core.app.post((Runnable) new DesktopLauncher.__\u003C\u003EAnon12(this));

    [Modifiers]
    [LineNumberTable(new byte[] {26, 127, 91})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240() => Vars.ui.showErrorMessage(Core.bundle.format("steam.error", Throwable.instancehelper_getMessage(this.steamError) != null ? (object) new StringBuilder().append(Object.instancehelper_getClass((object) this.steamError).getSimpleName()).append(": ").append(Throwable.instancehelper_getMessage(this.steamError)).toString() : (object) Object.instancehelper_getClass((object) this.steamError).getSimpleName()));

    [Signature("(Ljava/lang/Class<+Lmindustry/type/Publishable;>;)Larc/struct/Seq<Larc/files/Fi;>;")]
    [LineNumberTable(196)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Seq getWorkshopContent(Class type) => !Vars.steam ? base.getWorkshopContent(type) : SVars.workshop.getWorkshopFiles(type);

    [LineNumberTable(new byte[] {160, 87, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void viewListing(Publishable pub) => SVars.workshop.viewListing(pub);

    [LineNumberTable(new byte[] {160, 92, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void viewListingID(string id) => SVars.net.__\u003C\u003Efriends.activateGameOverlayToWebPage(new StringBuilder().append("steam://url/CommunityFilePage/").append(id).toString());

    [LineNumberTable(211)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override mindustry.net.Net.NetProvider getNet()
    {
      Object @object = !Vars.steam ? (Object) new ArcNetProvider() : (Object) SVars.net;
      if (@object == null)
        return (mindustry.net.Net.NetProvider) null;
      return @object is mindustry.net.Net.NetProvider netProvider ? netProvider : throw new IncompatibleClassChangeError();
    }

    [LineNumberTable(new byte[] {160, 102, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void openWorkshop() => SVars.net.__\u003C\u003Efriends.activateGameOverlayToWebPage("https://steamcommunity.com/app/1127400/workshop/");

    [LineNumberTable(new byte[] {160, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void publish(Publishable pub) => SVars.workshop.publish(pub);

    [LineNumberTable(new byte[] {160, 112, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void inviteFriends() => SVars.net.showFriendInvites();

    [LineNumberTable(new byte[] {160, 117, 103, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateLobby()
    {
      if (SVars.net == null)
        return;
      SVars.net.updateLobby();
    }

    [LineNumberTable(new byte[] {160, 125, 176, 107, 102, 102, 102, 135, 134, 159, 13, 113, 159, 11, 127, 23, 127, 0, 191, 17, 125, 105, 125, 137, 199, 107, 135, 99, 125, 104, 113, 191, 13, 169, 140, 172, 135, 154, 99, 152, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void updateRPC()
    {
      if (!this.useDiscord && !Vars.steam)
        return;
      int num = Vars.state.isGame() ? 1 : 0;
      string str1 = "Unknown Map";
      string str2 = "";
      string str3 = "";
      string str4 = "";
      if (num != 0)
      {
        object obj = (object) Vars.state.map.name();
        CharSequence str5;
        str5.__\u003Cref\u003E = (__Null) obj;
        str1 = Strings.capitalize(Strings.stripColors(str5));
        if (Vars.state.rules.waves)
          str1 = new StringBuilder().append(str1).append(" | Wave ").append(Vars.state.wave).toString();
        str2 = !Vars.state.rules.pvp ? (!Vars.state.rules.attackMode ? "Survival" : "Attack") : "PvP";
        if (Vars.net.active() && Groups.player.size() > 1)
          str3 = new StringBuilder().append(" | ").append(Groups.player.size()).append(" Players").toString();
      }
      else
        str4 = Vars.ui.editor == null || !Vars.ui.editor.isShown() ? (Vars.ui.planet == null || !Vars.ui.planet.isShown() ? "In Menu" : "In Launch Selection") : "In Editor";
      if (this.useDiscord)
      {
        DiscordRichPresence drp = new DiscordRichPresence();
        if (num != 0)
        {
          drp.state = new StringBuilder().append(str2).append(str3).toString();
          drp.details = str1;
          if (Vars.state.rules.waves)
            drp.largeImageText = new StringBuilder().append("Wave ").append(Vars.state.wave).toString();
        }
        else
          drp.state = str4;
        drp.largeImageKey = "logo";
        DiscordRPC.INSTANCE.Discord_UpdatePresence(drp);
      }
      if (!Vars.steam)
        return;
      SVars.net.__\u003C\u003Efriends.setRichPresence("steam_display", "#steam_status_raw");
      if (num != 0)
        SVars.net.__\u003C\u003Efriends.setRichPresence("steam_status", str1);
      else
        SVars.net.__\u003C\u003Efriends.setRichPresence("steam_status", str4);
    }

    [LineNumberTable(new byte[] {160, 187, 138, 103, 127, 6, 127, 7, 97, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getUUID()
    {
      if (Vars.steam)
      {
        string str;
        Exception exception;
        try
        {
          byte[] numArray = new byte[8];
          Rand.__\u003Cclinit\u003E();
          new Rand((long) SVars.user.__\u003C\u003Euser.getSteamID().getAccountID()).nextBytes(numArray);
          str = String.newhelper(Base64Coder.encode(numArray));
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            exception = (Exception) m0;
            goto label_6;
          }
        }
        return str;
label_6:
        Throwable.instancehelper_printStackTrace((Exception) exception);
      }
      return base.getUUID();
    }

    [LineNumberTable(new byte[] {160, 205, 101, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool validAddress([In] byte[] obj0)
    {
      if (obj0 == null)
        return false;
      byte[] @in = new byte[8];
      ByteCodeHelper.arraycopy_primitive_1((Array) obj0, 0, (Array) @in, 0, obj0.Length);
      return !String.instancehelper_equals(String.newhelper(Base64Coder.encode(@in)), (object) "AAAAAAAAAOA=") && !String.instancehelper_equals(String.newhelper(Base64Coder.encode(@in)), (object) "AAAAAAAAAAA=");
    }

    [EnclosingMethod(null, "initSteam", "([Ljava.lang.String;)V")]
    [SpecialName]
    internal class \u0032 : Object, ApplicationListener
    {
      [Modifiers]
      internal DesktopLauncher this\u00240;

      [LineNumberTable(133)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] DesktopLauncher obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {86, 103, 133})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void update()
      {
        if (!SteamAPI.isSteamRunning())
          return;
        SteamAPI.runCallbacks();
      }

      [HideFromJava]
      public virtual void init() => ApplicationListener.\u003Cdefault\u003Einit((ApplicationListener) this);

      [HideFromJava]
      public virtual void resize([In] int obj0, [In] int obj1) => ApplicationListener.\u003Cdefault\u003Eresize((ApplicationListener) this, obj0, obj1);

      [HideFromJava]
      public virtual void pause() => ApplicationListener.\u003Cdefault\u003Epause((ApplicationListener) this);

      [HideFromJava]
      public virtual void resume() => ApplicationListener.\u003Cdefault\u003Eresume((ApplicationListener) this);

      [HideFromJava]
      public virtual void dispose() => ApplicationListener.\u003Cdefault\u003Edispose((ApplicationListener) this);

      [HideFromJava]
      public virtual void exit() => ApplicationListener.\u003Cdefault\u003Eexit((ApplicationListener) this);

      [HideFromJava]
      public virtual void fileDropped([In] Fi obj0) => ApplicationListener.\u003Cdefault\u003EfileDropped((ApplicationListener) this, obj0);
    }

    [InnerClass]
    [EnclosingMethod(null, "main", "([Ljava.lang.String;)V")]
    [SpecialName]
    internal class \u0031 : SdlConfig
    {
      [LineNumberTable(new byte[] {159, 178, 104, 107, 103, 107, 107, 121})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
        DesktopLauncher.\u0031 obj = this;
        this.title = "Mindustry";
        this.maximized = true;
        this.width = 900;
        this.height = 700;
        this.setWindowIcon(Files.FileType.__\u003C\u003Einternal, "icons/icon_64.png");
      }
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly DiscordRPC arg\u00241;

      internal __\u003C\u003EAnon0([In] DiscordRPC obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.Discord_Shutdown();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly DesktopLauncher arg\u00241;

      internal __\u003C\u003EAnon1([In] DesktopLauncher obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243((EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly DesktopLauncher arg\u00241;
      private readonly string[] arg\u00242;

      internal __\u003C\u003EAnon2([In] DesktopLauncher obj0, [In] string[] obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024initSteam\u00245(this.arg\u00242, (EventType.ClientLoadEvent) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly bool[] arg\u00241;

      internal __\u003C\u003EAnon3([In] bool[] obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => DesktopLauncher.lambda\u0024initSteam\u00246(this.arg\u00241, (EventType.DisposeEvent) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : Runnable
    {
      private readonly bool[] arg\u00241;

      internal __\u003C\u003EAnon4([In] bool[] obj0) => this.arg\u00241 = obj0;

      public void run() => DesktopLauncher.lambda\u0024initSteam\u00247(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon5 : Cons
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public void get([In] object obj0) => ((Runnable) obj0).run();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon6 : Runnable
    {
      private readonly string arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon6([In] string obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => DesktopLauncher.lambda\u0024handleCrash\u00248(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly Exception arg\u00241;
      private readonly bool arg\u00242;
      private readonly Cons arg\u00243;

      internal __\u003C\u003EAnon7([In] Exception obj0, [In] bool obj1, [In] Cons obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0) => DesktopLauncher.lambda\u0024handleCrash\u002410(this.arg\u00241, this.arg\u00242, this.arg\u00243, (File) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon8 : Runnable
    {
      private readonly File arg\u00241;
      private readonly Exception arg\u00242;

      internal __\u003C\u003EAnon8([In] File obj0, [In] Exception obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => DesktopLauncher.lambda\u0024handleCrash\u00249(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon9 : Runnable
    {
      private readonly string[] arg\u00241;

      internal __\u003C\u003EAnon9([In] string[] obj0) => this.arg\u00241 = obj0;

      public void run() => DesktopLauncher.lambda\u0024initSteam\u00244(this.arg\u00241);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon10 : Runnable
    {
      private readonly DesktopLauncher arg\u00241;

      internal __\u003C\u003EAnon10([In] DesktopLauncher obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00242();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly DesktopLauncher arg\u00241;

      internal __\u003C\u003EAnon11([In] DesktopLauncher obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00241();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly DesktopLauncher arg\u00241;

      internal __\u003C\u003EAnon12([In] DesktopLauncher obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.lambda\u0024new\u00240();
    }
  }
}
