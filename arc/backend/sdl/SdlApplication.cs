// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SdlApplication
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.audio;
using arc.backend.sdl.jni;
using arc.func;
using arc.graphics;
using arc.util;
using arc.util.async;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.backend.sdl
{
  [Implements(new string[] {"arc.Application"})]
  public class SdlApplication : Object, Application, Disposable
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/ApplicationListener;>;")]
    private Seq listeners;
    [Modifiers]
    private TaskQueue runnables;
    [Modifiers]
    private int[] inputs;
    [Modifiers]
    internal SdlGraphics graphics;
    [Modifiers]
    internal SdlInput input;
    [Modifiers]
    internal SdlConfig config;
    internal bool running;
    internal long window;
    internal long context;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [LineNumberTable(new byte[] {159, 167, 232, 53, 107, 107, 237, 70, 199, 103, 140, 134, 102, 106, 106, 118, 117, 106, 138, 134, 183, 102, 180, 184, 2, 98, 135, 227, 60, 186, 2, 98, 135, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SdlApplication(ApplicationListener listener, SdlConfig config)
    {
      SdlApplication sdlApplication1 = this;
      this.listeners = new Seq();
      this.runnables = new TaskQueue();
      this.inputs = new int[34];
      this.running = true;
      this.config = config;
      this.listeners.add((object) listener);
      this.init();
      Core.app = (Application) this;
      Core.files = (Files) new SdlFiles();
      Core.net = new Net();
      SdlApplication sdlApplication2 = this;
      SdlGraphics sdlGraphics1 = new SdlGraphics(this);
      SdlGraphics sdlGraphics2 = sdlGraphics1;
      this.graphics = sdlGraphics1;
      Core.graphics = (Graphics) sdlGraphics2;
      SdlApplication sdlApplication3 = this;
      SdlInput sdlInput1 = new SdlInput();
      SdlInput sdlInput2 = sdlInput1;
      this.input = sdlInput1;
      Core.input = (Input) sdlInput2;
      Core.settings = new Settings();
      Core.audio = new Audio();
      this.initIcon();
      this.graphics.updateSize(config.width, config.height);
      // ISSUE: fault handler
      try
      {
        this.loop();
        this.listen((Cons) new SdlApplication.__\u003C\u003EAnon0());
      }
      __fault
      {
        Exception exception;
        try
        {
          this.cleanup();
          goto label_5;
        }
        catch (Exception ex)
        {
          exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Throwable.instancehelper_printStackTrace(exception);
label_5:;
      }
      Exception exception1;
      try
      {
        this.cleanup();
        return;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Throwable.instancehelper_printStackTrace(exception1);
    }

    [LineNumberTable(new byte[] {21, 133, 176, 113, 145, 116, 176, 113, 113, 113, 113, 113, 176, 110, 112, 177, 98, 113, 114, 114, 149, 127, 14, 149, 113, 149, 109, 199, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void init()
    {
      ArcNativesLoader.load();
      this.check((Intp) new SdlApplication.__\u003C\u003EAnon1());
      this.check((Intp) new SdlApplication.__\u003C\u003EAnon2(this));
      this.check((Intp) new SdlApplication.__\u003C\u003EAnon3(this));
      if (this.config.gl30 && OS.isMac)
        this.check((Intp) new SdlApplication.__\u003C\u003EAnon4());
      this.check((Intp) new SdlApplication.__\u003C\u003EAnon5(this));
      this.check((Intp) new SdlApplication.__\u003C\u003EAnon6(this));
      this.check((Intp) new SdlApplication.__\u003C\u003EAnon7(this));
      this.check((Intp) new SdlApplication.__\u003C\u003EAnon8(this));
      this.check((Intp) new SdlApplication.__\u003C\u003EAnon9(this));
      this.check((Intp) new SdlApplication.__\u003C\u003EAnon10());
      if (this.config.samples > 0)
      {
        this.check((Intp) new SdlApplication.__\u003C\u003EAnon11());
        this.check((Intp) new SdlApplication.__\u003C\u003EAnon12(this));
      }
      int i3 = 2;
      if (this.config.initialVisible)
        i3 |= 4;
      if (!this.config.decorated)
        i3 |= 16;
      if (this.config.resizable)
        i3 |= 32;
      if (this.config.maximized)
        i3 |= 128;
      this.window = SDL.SDL_CreateWindow(this.config.title, this.config.width, this.config.height, i3);
      if (this.window == 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SDLError();
      }
      this.context = SDL.SDL_GL_CreateContext(this.window);
      if (this.context == 0L)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SDLError();
      }
      if (this.config.vSyncEnabled)
        SDL.SDL_GL_SetSwapInterval(1);
      SDL.SDL_StartTextInput();
    }

    [LineNumberTable(new byte[] {6, 127, 3, 142, 124, 120, 108, 102, 189, 2, 98, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initIcon()
    {
      if (this.config.windowIconPaths == null || this.config.windowIconPaths.Length <= 0)
        return;
      string windowIconPath = this.config.windowIconPaths[0];
      Exception exception;
      try
      {
        Pixmap pixmap = new Pixmap(Core.files.get(windowIconPath, this.config.windowIconFileType));
        long rgbSurfaceFrom = SDL.SDL_CreateRGBSurfaceFrom(pixmap.getPixels(), pixmap.getWidth(), pixmap.getHeight());
        SDL.SDL_SetWindowIcon(this.window, rgbSurfaceFrom);
        SDL.SDL_FreeSurface(rgbSurfaceFrom);
        pixmap.dispose();
        return;
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

    [LineNumberTable(new byte[] {68, 127, 2, 144, 107, 112, 106, 105, 110, 105, 100, 123, 115, 101, 114, 101, 144, 255, 32, 69, 214, 107, 107, 134, 144, 139, 107, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void loop()
    {
      this.graphics.updateSize(this.config.width, this.config.height);
      this.listen((Cons) new SdlApplication.__\u003C\u003EAnon13());
      while (this.running)
      {
        while (SDL.SDL_PollEvent(this.inputs))
        {
          if (this.inputs[0] == 0)
            this.running = false;
          else if (this.inputs[0] == 1)
          {
            switch (this.inputs[1])
            {
              case 6:
                this.graphics.updateSize(this.inputs[2], this.inputs[3]);
                this.listen((Cons) new SdlApplication.__\u003C\u003EAnon14(this));
                continue;
              case 12:
                this.listen((Cons) new SdlApplication.__\u003C\u003EAnon15());
                continue;
              case 13:
                this.listen((Cons) new SdlApplication.__\u003C\u003EAnon16());
                continue;
              default:
                continue;
            }
          }
          else if (this.inputs[0] == 2 || this.inputs[0] == 3 || (this.inputs[0] == 4 || this.inputs[0] == 5) || this.inputs[0] == 6)
            this.input.handleInput(this.inputs);
        }
        this.graphics.update();
        this.input.update();
        this.defaultUpdate();
        this.listen((Cons) new SdlApplication.__\u003C\u003EAnon17());
        this.runnables.run();
        SDL.SDL_GL_SwapWindow(this.window);
        this.input.postUpdate();
      }
    }

    [Signature("(Larc/func/Cons<Larc/ApplicationListener;>;)V")]
    [LineNumberTable(new byte[] {108, 109, 127, 1, 103, 98, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void listen([In] Cons obj0)
    {
      lock (this.listeners)
      {
        Iterator iterator = this.listeners.iterator();
        while (iterator.hasNext())
        {
          ApplicationListener applicationListener = (ApplicationListener) iterator.next();
          obj0.get((object) applicationListener);
        }
      }
    }

    [LineNumberTable(new byte[] {116, 240, 72, 134, 107, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void cleanup()
    {
      this.listen((Cons) new SdlApplication.__\u003C\u003EAnon18());
      this.dispose();
      SDL.SDL_DestroyWindow(this.window);
      SDL.SDL_Quit();
    }

    [LineNumberTable(new byte[] {160, 67, 104, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void check([In] Intp obj0)
    {
      if (obj0.get() != 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SDLError();
      }
    }

    [HideFromJava]
    public virtual void defaultUpdate() => Application.\u003Cdefault\u003EdefaultUpdate((Application) this);

    [HideFromJava]
    public virtual void dispose() => Application.\u003Cdefault\u003Edispose((Application) this);

    [Modifiers]
    [LineNumberTable(73)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024init\u00240() => SDL.SDL_Init(16416);

    [Modifiers]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024init\u00241() => SDL.SDL_GL_SetAttribute(17, !this.config.gl30 ? 2 : this.config.gl30Major);

    [Modifiers]
    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024init\u00242() => SDL.SDL_GL_SetAttribute(18, !this.config.gl30 ? 0 : this.config.gl30Minor);

    [Modifiers]
    [LineNumberTable(80)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024init\u00243() => SDL.SDL_GL_SetAttribute(21, 1);

    [Modifiers]
    [LineNumberTable(83)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024init\u00244() => SDL.SDL_GL_SetAttribute(0, this.config.r);

    [Modifiers]
    [LineNumberTable(84)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024init\u00245() => SDL.SDL_GL_SetAttribute(1, this.config.g);

    [Modifiers]
    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024init\u00246() => SDL.SDL_GL_SetAttribute(2, this.config.b);

    [Modifiers]
    [LineNumberTable(86)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024init\u00247() => SDL.SDL_GL_SetAttribute(6, this.config.depth);

    [Modifiers]
    [LineNumberTable(87)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024init\u00248() => SDL.SDL_GL_SetAttribute(7, this.config.stencil);

    [Modifiers]
    [LineNumberTable(88)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024init\u00249() => SDL.SDL_GL_SetAttribute(5, 1);

    [Modifiers]
    [LineNumberTable(92)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int lambda\u0024init\u002410() => SDL.SDL_GL_SetAttribute(13, 1);

    [Modifiers]
    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int lambda\u0024init\u002411() => SDL.SDL_GL_SetAttribute(14, this.config.samples);

    [Modifiers]
    [LineNumberTable(129)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024loop\u002412([In] ApplicationListener obj0) => obj0.resize(this.inputs[2], this.inputs[3]);

    [Modifiers]
    [LineNumberTable(new byte[] {117, 134, 184, 2, 97, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024cleanup\u002413([In] ApplicationListener obj0)
    {
      obj0.pause();
      Exception exception;
      try
      {
        obj0.dispose();
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Throwable.instancehelper_printStackTrace(exception);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 75, 103, 127, 52, 103, 127, 3, 103, 159, 1})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024openFolder\u002414([In] string obj0)
    {
      if (OS.isWindows)
      {
        StringBuilder stringBuilder = new StringBuilder().append("explorer.exe /select,");
        string str1 = obj0;
        object obj1 = (object) "\\";
        object obj2 = (object) "/";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        string str2 = String.instancehelper_replace(str1, charSequence2, charSequence3);
        OS.execSafe(stringBuilder.append(str2).toString());
      }
      else if (OS.isLinux)
      {
        OS.execSafe(new StringBuilder().append("xdg-open ").append(obj0).toString());
      }
      else
      {
        if (!OS.isMac)
          return;
        OS.execSafe(new StringBuilder().append("open ").append(obj0).toString());
      }
    }

    [LineNumberTable(new byte[] {160, 74, 241, 73})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool openFolder(string file)
    {
      Threads.daemon((Runnable) new SdlApplication.__\u003C\u003EAnon19(file));
      return true;
    }

    [LineNumberTable(new byte[] {160, 89, 103, 127, 35, 103, 103, 127, 3, 103, 159, 3, 125, 97, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool openURI(string url)
    {
      int num;
      Exception exception;
      try
      {
        if (OS.isMac)
        {
          Class.forName("com.apple.eio.FileManager", SdlApplication.__\u003CGetCallerID\u003E()).getMethod("openURL", new Class[1]
          {
            (Class) ClassLiteral<String>.Value
          }, SdlApplication.__\u003CGetCallerID\u003E()).invoke((object) null, new object[1]
          {
            (object) url
          }, SdlApplication.__\u003CGetCallerID\u003E());
          return true;
        }
        if (OS.isLinux)
          return OS.execSafe(new StringBuilder().append("xdg-open ").append(url).toString());
        if (OS.isWindows)
          return OS.execSafe(new StringBuilder().append("rundll32 url.dll,FileProtocolHandler ").append(url).toString());
        num = 0;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_9;
      }
      return num != 0;
label_9:
      Throwable.instancehelper_printStackTrace(exception);
      return false;
    }

    [Signature("()Larc/struct/Seq<Larc/ApplicationListener;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getListeners() => this.listeners;

    [LineNumberTable(225)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Application.ApplicationType getType() => Application.ApplicationType.__\u003C\u003Edesktop;

    [LineNumberTable(230)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getClipboardText() => SDL.SDL_GetClipboardText();

    [LineNumberTable(new byte[] {160, 121, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setClipboardText(string text) => SDL.SDL_SetClipboardText(text);

    [LineNumberTable(new byte[] {160, 126, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void post(Runnable runnable) => this.runnables.post(runnable);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void exit() => this.running = false;

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [HideFromJava]
    public virtual void addListener([In] ApplicationListener obj0) => Application.\u003Cdefault\u003EaddListener((Application) this, obj0);

    [HideFromJava]
    public virtual void removeListener([In] ApplicationListener obj0) => Application.\u003Cdefault\u003EremoveListener((Application) this, obj0);

    [HideFromJava]
    public virtual bool isDesktop() => Application.\u003Cdefault\u003EisDesktop((Application) this);

    [HideFromJava]
    public virtual bool isHeadless() => Application.\u003Cdefault\u003EisHeadless((Application) this);

    [HideFromJava]
    public virtual bool isAndroid() => Application.\u003Cdefault\u003EisAndroid((Application) this);

    [HideFromJava]
    public virtual bool isIOS() => Application.\u003Cdefault\u003EisIOS((Application) this);

    [HideFromJava]
    public virtual bool isMobile() => Application.\u003Cdefault\u003EisMobile((Application) this);

    [HideFromJava]
    public virtual bool isWeb() => Application.\u003Cdefault\u003EisWeb((Application) this);

    [HideFromJava]
    public virtual int getVersion() => Application.\u003Cdefault\u003EgetVersion((Application) this);

    [HideFromJava]
    public virtual long getJavaHeap() => Application.\u003Cdefault\u003EgetJavaHeap((Application) this);

    [HideFromJava]
    public virtual long getNativeHeap() => Application.\u003Cdefault\u003EgetNativeHeap((Application) this);

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SdlApplication.__\u003CcallerID\u003E == null)
        SdlApplication.__\u003CcallerID\u003E = (CallerID) new SdlApplication.__\u003CCallerID\u003E();
      return SdlApplication.__\u003CcallerID\u003E;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => ((ApplicationListener) obj0).exit();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Intp
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public int get() => SdlApplication.lambda\u0024init\u00240();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Intp
    {
      private readonly SdlApplication arg\u00241;

      internal __\u003C\u003EAnon2([In] SdlApplication obj0) => this.arg\u00241 = obj0;

      public int get() => this.arg\u00241.lambda\u0024init\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Intp
    {
      private readonly SdlApplication arg\u00241;

      internal __\u003C\u003EAnon3([In] SdlApplication obj0) => this.arg\u00241 = obj0;

      public int get() => this.arg\u00241.lambda\u0024init\u00242();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Intp
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public int get() => SdlApplication.lambda\u0024init\u00243();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Intp
    {
      private readonly SdlApplication arg\u00241;

      internal __\u003C\u003EAnon5([In] SdlApplication obj0) => this.arg\u00241 = obj0;

      public int get() => this.arg\u00241.lambda\u0024init\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Intp
    {
      private readonly SdlApplication arg\u00241;

      internal __\u003C\u003EAnon6([In] SdlApplication obj0) => this.arg\u00241 = obj0;

      public int get() => this.arg\u00241.lambda\u0024init\u00245();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Intp
    {
      private readonly SdlApplication arg\u00241;

      internal __\u003C\u003EAnon7([In] SdlApplication obj0) => this.arg\u00241 = obj0;

      public int get() => this.arg\u00241.lambda\u0024init\u00246();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Intp
    {
      private readonly SdlApplication arg\u00241;

      internal __\u003C\u003EAnon8([In] SdlApplication obj0) => this.arg\u00241 = obj0;

      public int get() => this.arg\u00241.lambda\u0024init\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Intp
    {
      private readonly SdlApplication arg\u00241;

      internal __\u003C\u003EAnon9([In] SdlApplication obj0) => this.arg\u00241 = obj0;

      public int get() => this.arg\u00241.lambda\u0024init\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Intp
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public int get() => SdlApplication.lambda\u0024init\u00249();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Intp
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public int get() => SdlApplication.lambda\u0024init\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Intp
    {
      private readonly SdlApplication arg\u00241;

      internal __\u003C\u003EAnon12([In] SdlApplication obj0) => this.arg\u00241 = obj0;

      public int get() => this.arg\u00241.lambda\u0024init\u002411();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Cons
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public void get([In] object obj0) => ((ApplicationListener) obj0).init();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Cons
    {
      private readonly SdlApplication arg\u00241;

      internal __\u003C\u003EAnon14([In] SdlApplication obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024loop\u002412((ApplicationListener) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public void get([In] object obj0) => ((ApplicationListener) obj0).resume();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Cons
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public void get([In] object obj0) => ((ApplicationListener) obj0).pause();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Cons
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public void get([In] object obj0) => ((ApplicationListener) obj0).update();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Cons
    {
      internal __\u003C\u003EAnon18()
      {
      }

      public void get([In] object obj0) => SdlApplication.lambda\u0024cleanup\u002413((ApplicationListener) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon19([In] string obj0) => this.arg\u00241 = obj0;

      public void run() => SdlApplication.lambda\u0024openFolder\u002414(this.arg\u00241);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
