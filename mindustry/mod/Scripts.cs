// Decompiled with JetBrains decompiler
// Type: mindustry.mod.Scripts
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
using arc.assets.loaders;
using arc.audio;
using arc.files;
using arc.func;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.net;
using java.util;
using java.util.regex;
using rhino;
using rhino.module;
using rhino.module.provider;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.mod
{
  public class Scripts : Object, Disposable
  {
    [Modifiers]
    [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
    private static Seq blacklist;
    [Modifiers]
    [Signature("Larc/struct/Seq<Ljava/lang/String;>;")]
    private static Seq whitelist;
    [Modifiers]
    private Context context;
    [Modifiers]
    private Scriptable scope;
    private bool errored;
    internal Mods.LoadedMod currentMod;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 182, 232, 58, 231, 71, 133, 112, 117, 113, 144, 150, 117, 102, 159, 2, 127, 3, 135, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Scripts()
    {
      Scripts scripts = this;
      this.currentMod = (Mods.LoadedMod) null;
      Time.mark();
      this.context = Vars.platform.getScriptContext();
      this.context.setClassShutter((ClassShutter) new Scripts.__\u003C\u003EAnon2());
      this.context.getWrapFactory().setJavaPrimitiveWrap(false);
      this.context.setLanguageVersion(200);
      ImporterTopLevel.__\u003Cclinit\u003E();
      this.scope = (Scriptable) new ImporterTopLevel(this.context);
      RequireBuilder requireBuilder = new RequireBuilder();
      SoftCachingModuleScriptProvider.__\u003Cclinit\u003E();
      SoftCachingModuleScriptProvider moduleScriptProvider = new SoftCachingModuleScriptProvider((ModuleSourceProvider) new Scripts.ScriptModuleProvider(this));
      requireBuilder.setModuleScriptProvider((ModuleScriptProvider) moduleScriptProvider).setSandboxed(true).createRequire(this.context, this.scope).install(this.scope);
      if (!this.run(Core.files.@internal("scripts/global.js").readString(), "global.js", false))
        this.errored = true;
      Log.debug("Time to load script engine: @", (object) Float.valueOf(Time.elapsed()));
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool allowClass(string type) => !Scripts.blacklist.contains((Boolf) new Scripts.__\u003C\u003EAnon0(type)) || Scripts.whitelist.contains((Boolf) new Scripts.__\u003C\u003EAnon1(type));

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasErrored() => this.errored;

    [LineNumberTable(new byte[] {119, 103, 116, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void run(Mods.LoadedMod mod, Fi file)
    {
      this.currentMod = mod;
      this.run(file.readString(), file.name(), true);
      this.currentMod = (Mods.LoadedMod) null;
    }

    [LineNumberTable(new byte[] {159, 98, 66, 136, 159, 56, 108, 63, 14, 166, 119, 97, 104, 159, 13, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool run([In] string obj0, [In] string obj1, [In] bool obj2)
    {
      int num1 = obj2 ? 1 : 0;
      int num2;
      Exception exception1;
      try
      {
        if (this.currentMod != null)
          this.context.evaluateString(this.scope, new StringBuilder().append("modName = \"").append(this.currentMod.__\u003C\u003Ename).append("\"\nscriptName = \"").append(obj1).append("\"").toString(), "initscript.js", 1, (object) null);
        this.context.evaluateString(this.scope, num1 == 0 ? obj0 : new StringBuilder().append("(function(){'use strict';\n").append(obj0).append("\n})();").toString(), obj1, 0, (object) null);
        num2 = 1;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_6;
      }
      return num2 != 0;
label_6:
      Exception exception2 = exception1;
      if (this.currentMod != null)
        obj1 = new StringBuilder().append(this.currentMod.__\u003C\u003Ename).append("/").append(obj1).toString();
      this.log(Log.LogLevel.__\u003C\u003Eerr, obj1, new StringBuilder().append("").append(this.getError(exception2, true)).toString());
      return false;
    }

    [LineNumberTable(new byte[] {159, 123, 66, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string getError([In] Exception obj0, [In] bool obj1)
    {
      if (obj1)
        Log.err(obj0);
      return new StringBuilder().append(Object.instancehelper_getClass((object) obj0).getSimpleName()).append(Throwable.instancehelper_getMessage(obj0) != null ? new StringBuilder().append(": ").append(Throwable.instancehelper_getMessage(obj0)).toString() : "").toString();
    }

    [LineNumberTable(new byte[] {35, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void log(Log.LogLevel level, string source, string message) => Log.log(level, "[@]: @", (object) source, (object) message);

    [Signature("(ZLjava/lang/String;Ljava/lang/String;Larc/func/Cons<Larc/files/Fi;>;)V")]
    [LineNumberTable(new byte[] {159, 104, 98, 159, 4, 127, 52, 249, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void selectFile([In] bool obj0, [In] string obj1, [In] string obj2, [In] Cons obj3)
    {
      int num = obj0 ? 1 : 0;
      obj1 = !String.instancehelper_startsWith(obj1, "@") ? obj1 : Core.bundle.get(String.instancehelper_substring(obj1, 1));
      string title = new StringBuilder().append(Core.bundle.get(num == 0 ? "save" : "open")).append(" - ").append(obj1).append(" (.").append(obj2).append(")").toString();
      Vars.platform.showFileChooser(num != 0, title, obj2, (Cons) new Scripts.__\u003C\u003EAnon8(obj3));
    }

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024allowClass\u00240([In] string obj0, [In] string obj1)
    {
      string lowerCase = String.instancehelper_toLowerCase(obj0, (Locale) Locale.ROOT);
      object obj = (object) obj1;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      return String.instancehelper_contains(lowerCase, charSequence2);
    }

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024allowClass\u00241([In] string obj0, [In] string obj1)
    {
      string lowerCase = String.instancehelper_toLowerCase(obj0, (Locale) Locale.ROOT);
      object obj = (object) obj1;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      return String.instancehelper_contains(lowerCase, charSequence2);
    }

    [Modifiers]
    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024readFile\u00242([In] Cons obj0, [In] Fi obj1) => obj0.get((object) obj1.readString());

    [Modifiers]
    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024readBinFile\u00243([In] Cons obj0, [In] Fi obj1) => obj0.get((object) obj1.readBytes());

    [Modifiers]
    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024writeFile\u00244([In] string obj0, [In] Fi obj1) => obj1.writeString(obj0);

    [Modifiers]
    [LineNumberTable(149)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024writeBinFile\u00245([In] byte[] obj0, [In] Fi obj1) => obj1.writeBytes(obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {108, 222, 226, 61, 97, 116, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024selectFile\u00246([In] Cons obj0, [In] Fi obj1)
    {
      Exception exception1;
      try
      {
        obj0.get((object) obj1);
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
      Log.err("Failed to select file '@' for a mod", (object) obj1);
      Log.err((Exception) exception2);
    }

    [LineNumberTable(new byte[] {16, 122, 127, 7, 110, 126, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string runConsole(string text)
    {
      string str;
      Exception exception;
      try
      {
        object obj1 = this.context.evaluateString(this.scope, text, "console.js", 1, (object) null);
        object obj2 = obj1;
        NativeJavaObject nativeJavaObject;
        if (obj2 is NativeJavaObject && object.ReferenceEquals((object) (nativeJavaObject = (NativeJavaObject) obj2), (object) (NativeJavaObject) obj2))
          obj1 = nativeJavaObject.unwrap();
        if (obj1 is Undefined)
          obj1 = (object) "undefined";
        str = String.valueOf(obj1);
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_7;
      }
      return str;
label_7:
      return this.getError(exception, false);
    }

    [LineNumberTable(new byte[] {31, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void log(string source, string message) => this.log(Log.LogLevel.__\u003C\u003Einfo, source, message);

    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float[] newFloats(int capacity) => new float[capacity];

    [LineNumberTable(95)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string readString(string path) => Vars.tree.get(path, true).readString();

    [LineNumberTable(99)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] readBytes(string path) => Vars.tree.get(path, true).readBytes();

    [LineNumberTable(new byte[] {53, 141, 123, 159, 67, 102, 119, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Sound loadSound(string soundName)
    {
      if (Vars.headless)
        return new Sound();
      string str = new StringBuilder().append("sounds/").append(soundName).toString();
      string fileName = !Vars.tree.get(new StringBuilder().append(str).append(".ogg").toString()).exists() ? new StringBuilder().append(str).append(".mp3").toString() : new StringBuilder().append(str).append(".ogg").toString();
      Sound sound = new Sound();
      Core.assets.load(fileName, (Class) ClassLiteral<Sound>.Value, (AssetLoaderParameters) new SoundLoader.SoundParameter(sound)).errored = (Cons) new Scripts.__\u003C\u003EAnon3();
      return sound;
    }

    [LineNumberTable(new byte[] {66, 141, 123, 159, 67, 102, 119, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Music loadMusic(string soundName)
    {
      if (Vars.headless)
        return new Music();
      string str = new StringBuilder().append("music/").append(soundName).toString();
      string fileName = !Vars.tree.get(new StringBuilder().append(str).append(".ogg").toString()).exists() ? new StringBuilder().append(str).append(".mp3").toString() : new StringBuilder().append(str).append(".ogg").toString();
      Music music = new Music();
      Core.assets.load(fileName, (Class) ClassLiteral<Music>.Value, (AssetLoaderParameters) new MusicLoader.MusicParameter(music)).errored = (Cons) new Scripts.__\u003C\u003EAnon3();
      return music;
    }

    [Signature("(Ljava/lang/String;Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {80, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readFile(string purpose, string ext, Cons cons) => this.selectFile(true, purpose, ext, (Cons) new Scripts.__\u003C\u003EAnon4(cons));

    [Signature("(Ljava/lang/String;Ljava/lang/String;Larc/func/Cons<[B>;)V")]
    [LineNumberTable(new byte[] {85, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readBinFile(string purpose, string ext, Cons cons) => this.selectFile(true, purpose, ext, (Cons) new Scripts.__\u003C\u003EAnon5(cons));

    [LineNumberTable(new byte[] {90, 106, 98, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeFile(string purpose, string ext, string contents)
    {
      if (contents == null)
        contents = "";
      string str = contents;
      this.selectFile(false, purpose, ext, (Cons) new Scripts.__\u003C\u003EAnon6(str));
    }

    [LineNumberTable(new byte[] {97, 107, 98, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeBinFile(string purpose, string ext, byte[] contents)
    {
      if (contents == null)
        contents = new byte[0];
      byte[] numArray = contents;
      this.selectFile(false, purpose, ext, (Cons) new Scripts.__\u003C\u003EAnon7(numArray));
    }

    [LineNumberTable(new byte[] {160, 81, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose() => Context.exit();

    [LineNumberTable(new byte[] {159, 136, 109, 191, 160, 192})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Scripts()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.mod.Scripts"))
        return;
      Scripts.blacklist = Seq.with((object[]) new string[31]
      {
        ".net.",
        "java.net",
        "files",
        "reflect",
        "javax",
        "rhino",
        "file",
        "channels",
        "jdk",
        "runtime",
        "util.os",
        "rmi",
        "security",
        "org.",
        "sun.",
        "beans",
        "sql",
        "http",
        "exec",
        "compiler",
        "process",
        "system",
        ".awt",
        "socket",
        "classloader",
        "oracle",
        "invoke",
        "java.util.function",
        "java.util.stream",
        "org.",
        "mod.classmap"
      });
      Scripts.whitelist = Seq.with((object[]) new string[11]
      {
        "mindustry.net",
        "netserver",
        "netclient",
        "com.sun.proxy.$proxy",
        "jdk.proxy1",
        "mindustry.gen.",
        "mindustry.logic.",
        "mindustry.async.",
        "saveio",
        "systemcursor",
        "filetreeinitevent"
      });
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [InnerClass]
    internal class ScriptModuleProvider : UrlModuleSourceProvider
    {
      private Pattern directory;
      [Modifiers]
      internal Scripts this\u00240;

      [Throws(new string[] {"java.net.URISyntaxException"})]
      [LineNumberTable(new byte[] {160, 98, 125, 107, 114, 105, 99, 111, 107, 172, 108, 186, 127, 3, 116, 98, 124, 16})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ModuleSource loadSource([In] string obj0, [In] Fi obj1, [In] object obj2)
      {
        Pattern directory = this.directory;
        object obj = (object) obj0;
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        Matcher matcher = directory.matcher(charSequence2);
        if (matcher.find())
        {
          Mods.LoadedMod loadedMod = Vars.mods.locateMod(matcher.group(1));
          string str = matcher.group(2);
          if (loadedMod == null)
          {
            Fi fi = obj1.child(matcher.group(1));
            return !fi.exists() ? (ModuleSource) null : this.loadSource(str, fi, obj2);
          }
          this.this\u00240.currentMod = loadedMod;
          return this.loadSource(str, loadedMod.__\u003C\u003Eroot.child("scripts"), obj2);
        }
        Fi fi1 = obj1.child(new StringBuilder().append(obj0).append(".js").toString());
        return !fi1.exists() || fi1.isDirectory() ? (ModuleSource) null : new ModuleSource((Reader) new InputStreamReader((InputStream) new ByteArrayInputStream(String.instancehelper_getBytes(fi1.readString()))), (object) null, new URI(obj0), obj1.file().toURI(), obj2);
      }

      [LineNumberTable(new byte[] {160, 87, 103, 234, 61, 208})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ScriptModuleProvider([In] Scripts obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector((Iterable) null, (Iterable) null);
        Scripts.ScriptModuleProvider scriptModuleProvider = this;
        this.directory = Pattern.compile("^(.+?)/(.+)");
      }

      [Throws(new string[] {"java.net.URISyntaxException"})]
      [LineNumberTable(new byte[] {160, 93, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override ModuleSource loadSource(
        [In] string obj0,
        [In] Scriptable obj1,
        [In] object obj2)
      {
        return this.this\u00240.currentMod == null ? (ModuleSource) null : this.loadSource(obj0, this.this\u00240.currentMod.__\u003C\u003Eroot.child("scripts"), obj2);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon0([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Scripts.lambda\u0024allowClass\u00240(this.arg\u00241, (string) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon1([In] string obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Scripts.lambda\u0024allowClass\u00241(this.arg\u00241, (string) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : ClassShutter
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool visibleToScripts([In] string obj0) => (Scripts.allowClass(obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => Throwable.instancehelper_printStackTrace((Exception) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Cons
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon4([In] Cons obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Scripts.lambda\u0024readFile\u00242(this.arg\u00241, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon5([In] Cons obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Scripts.lambda\u0024readBinFile\u00243(this.arg\u00241, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon6([In] string obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Scripts.lambda\u0024writeFile\u00244(this.arg\u00241, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      private readonly byte[] arg\u00241;

      internal __\u003C\u003EAnon7([In] byte[] obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Scripts.lambda\u0024writeBinFile\u00245(this.arg\u00241, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon8([In] Cons obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => Scripts.lambda\u0024selectFile\u00246(this.arg\u00241, (Fi) obj0);
    }
  }
}
