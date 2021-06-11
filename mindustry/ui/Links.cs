// Decompiled with JetBrains decompiler
// Type: mindustry.ui.Links
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.func;
using arc.graphics;
using arc.scene.style;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.core;
using mindustry.gen;
using mindustry.graphics;
using mindustry.mod;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class Links : Object
  {
    private static Links.LinkEntry[] links;

    [LineNumberTable(new byte[] {7, 252, 77, 127, 65, 104, 255, 34, 50, 52})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string report() => new StringBuilder().append("https://github.com/Anuken/Mindustry/issues/new?assignees=&labels=bug&body=").append(Strings.encode(Strings.format("**Platform**: `@`\n\n**Build**: `@`\n\n**Issue**: *Explain your issue in detail.*\n\n**Steps to reproduce**: *How you happened across the issue, and what exactly you did to make the bug happen.*\n\n**Link(s) to mod(s) used**: `@`\n\n**Save file**: *The (zipped) save file you were playing on when the bug happened. THIS IS REQUIRED FOR ANY ISSUE HAPPENING IN-GAME, REGARDLESS OF WHETHER YOU THINK IT HAPPENS EVERYWHERE. DO NOT DELETE OR OMIT THIS LINE UNLESS YOU ARE SURE THAT THE ISSUE DOES NOT HAPPEN IN-GAME.*\n\n**Crash report**: *The contents of relevant crash report files. REQUIRED if you are reporting a crash.*\n\n---\n\n*Place an X (no spaces) between the brackets to confirm that you have read the line below.*\n- [ ] **I have updated to the latest release (https://github.com/Anuken/Mindustry/releases) to make sure my issue has not been fixed.**\n- [ ] **I have searched the closed and open issues to make sure that this problem has not already been reported.**", !OS.isAndroid ? (object) new StringBuilder().append(java.lang.System.getProperty("os.name")).append(!OS.is64Bit ? " x32" : " x64").toString() : (object) new StringBuilder().append("Android ").append(Core.app.getVersion()).toString(), (object) Version.combined(), !Vars.mods.list().any() ? (object) "none" : (object) (string) Vars.mods.list().select((Boolf) new Links.__\u003C\u003EAnon0()).map((Func) new Links.__\u003C\u003EAnon1())))).toString();

    [LineNumberTable(new byte[] {159, 159, 125, 127, 2, 127, 2, 127, 2, 127, 2, 127, 2, 127, 2, 127, 2, 127, 2, 127, 3, 127, 3, 115, 159, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void createLinks() => Links.links = new Links.LinkEntry[12]
    {
      new Links.LinkEntry("discord", "https://discord.gg/mindustry", (Drawable) Icon.discord, Color.valueOf("7289da")),
      new Links.LinkEntry("changelog", "https://github.com/Anuken/Mindustry/releases", (Drawable) Icon.list, Pal.accent.cpy()),
      new Links.LinkEntry("trello", "https://trello.com/b/aE2tcUwF", (Drawable) Icon.trello, Color.valueOf("026aa7")),
      new Links.LinkEntry("wiki", "https://mindustrygame.github.io/wiki/", (Drawable) Icon.book, Color.valueOf("0f142f")),
      new Links.LinkEntry("suggestions", "https://github.com/Anuken/Mindustry-Suggestions/issues/new/choose/", (Drawable) Icon.add, Color.valueOf("ebebeb")),
      new Links.LinkEntry("reddit", "https://www.reddit.com/r/Mindustry/", (Drawable) Icon.redditAlien, Color.valueOf("ee593b")),
      new Links.LinkEntry("itch.io", "https://anuke.itch.io/mindustry", (Drawable) Icon.itchio, Color.valueOf("fa5c5c")),
      new Links.LinkEntry("google-play", "https://play.google.com/store/apps/details?id=io.anuke.mindustry", (Drawable) Icon.googleplay, Color.valueOf("689f38")),
      new Links.LinkEntry("f-droid", "https://f-droid.org/packages/io.anuke.mindustry/", (Drawable) Icon.android, Color.valueOf("026aa7")),
      new Links.LinkEntry("github", "https://github.com/Anuken/Mindustry/", (Drawable) Icon.github, Color.valueOf("24292e")),
      new Links.LinkEntry("dev-builds", "https://github.com/Anuken/MindustryBuilds", (Drawable) Icon.githubSquare, Color.valueOf("fafbfc")),
      new Links.LinkEntry("bug", Links.report(), (Drawable) Icon.wrench, Color.valueOf("cbd97f"))
    };

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024report\u00240([In] Mods.LoadedMod obj0) => new StringBuilder().append(obj0.__\u003C\u003Emeta.author).append("/").append(obj0.__\u003C\u003Ename).append(":").append(obj0.__\u003C\u003Emeta.version).toString();

    [LineNumberTable(13)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Links()
    {
    }

    [LineNumberTable(new byte[] {159, 176, 103, 165})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Links.LinkEntry[] getLinks()
    {
      if (Links.links == null)
        Links.createLinks();
      return Links.links;
    }

    public class LinkEntry : Object
    {
      internal string __\u003C\u003Ename;
      internal string __\u003C\u003Etitle;
      internal string __\u003C\u003Edescription;
      internal string __\u003C\u003Elink;
      internal Color __\u003C\u003Ecolor;
      internal Drawable __\u003C\u003Eicon;

      [LineNumberTable(new byte[] {159, 188, 104, 103, 104, 127, 26, 103, 103, 127, 76})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public LinkEntry(string name, string link, Drawable icon, Color color)
      {
        Links.LinkEntry linkEntry = this;
        this.__\u003C\u003Ename = name;
        this.__\u003C\u003Ecolor = color;
        this.__\u003C\u003Edescription = Core.bundle.get(new StringBuilder().append("link.").append(name).append(".description").toString(), "");
        this.__\u003C\u003Elink = link;
        this.__\u003C\u003Eicon = icon;
        I18NBundle bundle = Core.bundle;
        string key = new StringBuilder().append("link.").append(name).append(".title").toString();
        string str = name;
        object obj1 = (object) " ";
        object obj2 = (object) "-";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        string def = Strings.capitalize(String.instancehelper_replace(str, charSequence2, charSequence3));
        this.__\u003C\u003Etitle = bundle.get(key, def);
      }

      [Modifiers]
      public string name
      {
        [HideFromJava] get => this.__\u003C\u003Ename;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ename = value;
      }

      [Modifiers]
      public string title
      {
        [HideFromJava] get => this.__\u003C\u003Etitle;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etitle = value;
      }

      [Modifiers]
      public string description
      {
        [HideFromJava] get => this.__\u003C\u003Edescription;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Edescription = value;
      }

      [Modifiers]
      public string link
      {
        [HideFromJava] get => this.__\u003C\u003Elink;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Elink = value;
      }

      [Modifiers]
      public Color color
      {
        [HideFromJava] get => this.__\u003C\u003Ecolor;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ecolor = value;
      }

      [Modifiers]
      public Drawable icon
      {
        [HideFromJava] get => this.__\u003C\u003Eicon;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eicon = value;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get([In] object obj0) => (((Mods.LoadedMod) obj0).enabled() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Func
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public object get([In] object obj0) => (object) Links.lambda\u0024report\u00240((Mods.LoadedMod) obj0);
    }
  }
}
