// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.LanguageDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class LanguageDialog : BaseDialog
  {
    private Locale lastLocale;
    [Signature("Larc/struct/ObjectMap<Ljava/util/Locale;Ljava/lang/String;>;")]
    private ObjectMap displayNames;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 164, 237, 58, 255, 18, 71, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LanguageDialog()
      : base("@settings.language")
    {
      LanguageDialog languageDialog = this;
      this.displayNames = ObjectMap.of((object) Locale.TRADITIONAL_CHINESE, (object) "正體中文", (object) Locale.SIMPLIFIED_CHINESE, (object) "简体中文");
      this.addCloseButton();
      this.setup();
    }

    [LineNumberTable(new byte[] {159, 170, 102, 118, 103, 136, 134, 124, 127, 18, 245, 70, 255, 21, 56, 235, 75, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setup()
    {
      Table table = new Table();
      table.marginRight(24f).marginLeft(24f);
      ScrollPane scrollPane = new ScrollPane((Element) table);
      scrollPane.setScrollingDisabled(true, false);
      ButtonGroup group = new ButtonGroup();
      Locale[] locales = Vars.locales;
      int length = locales.Length;
      for (int index = 0; index < length; ++index)
      {
        Locale locale = locales[index];
        TextButton.__\u003Cclinit\u003E();
        TextButton textButton = new TextButton(Strings.capitalize((string) this.displayNames.get((object) locale, (object) locale.getDisplayName(locale))), Styles.clearTogglet);
        textButton.clicked((Runnable) new LanguageDialog.__\u003C\u003EAnon0(this, locale));
        table.add((Element) textButton).group(group).update((Cons) new LanguageDialog.__\u003C\u003EAnon1(this, locale)).size(400f, 50f).row();
      }
      this.__\u003C\u003Econt.add((Element) scrollPane);
    }

    [LineNumberTable(new byte[] {20, 115, 109, 117, 225, 61, 230, 72, 115, 119, 117, 225, 61, 230, 71, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void findClosestLocale()
    {
      Locale[] locales1 = Vars.locales;
      int length1 = locales1.Length;
      for (int index = 0; index < length1; ++index)
      {
        Locale locale = locales1[index];
        if (locale.equals((object) Locale.getDefault()))
        {
          Core.settings.put("locale", (object) locale.toString());
          return;
        }
      }
      Locale[] locales2 = Vars.locales;
      int length2 = locales2.Length;
      for (int index = 0; index < length2; ++index)
      {
        Locale locale = locales2[index];
        if (String.instancehelper_equals(locale.getLanguage(), (object) Locale.getDefault().getLanguage()))
        {
          Core.settings.put("locale", (object) locale.toString());
          return;
        }
      }
      Core.settings.put("locale", (object) new Locale("en").toString());
    }

    [LineNumberTable(new byte[] {0, 144, 109, 166, 123, 125, 108, 118, 98, 204})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Locale getLocale()
    {
      string str1 = Core.settings.getString("locale");
      if (String.instancehelper_equals(str1, (object) "default"))
        this.findClosestLocale();
      if (this.lastLocale == null || !String.instancehelper_equals(this.lastLocale.toString(), (object) str1))
      {
        string str2 = str1;
        object obj = (object) "_";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        if (String.instancehelper_contains(str2, charSequence2))
        {
          string[] strArray = String.instancehelper_split(str1, "_");
          Locale.__\u003Cclinit\u003E();
          this.lastLocale = new Locale(strArray[0], strArray[1]);
        }
        else
          this.lastLocale = new Locale(str1);
      }
      return this.lastLocale;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 180, 111, 117, 121, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00240([In] Locale obj0)
    {
      if (this.getLocale().equals((object) obj0))
        return;
      Core.settings.put("locale", (object) obj0.toString());
      Log.info("Setting locale: @", (object) obj0.toString());
      Vars.ui.showInfo("@language.restart");
    }

    [Modifiers]
    [LineNumberTable(43)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setup\u00241([In] Locale obj0, [In] TextButton obj1) => obj1.setChecked(obj0.equals((object) this.getLocale()));

    [HideFromJava]
    static LanguageDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly LanguageDialog arg\u00241;
      private readonly Locale arg\u00242;

      internal __\u003C\u003EAnon0([In] LanguageDialog obj0, [In] Locale obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024setup\u00240(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly LanguageDialog arg\u00241;
      private readonly Locale arg\u00242;

      internal __\u003C\u003EAnon1([In] LanguageDialog obj0, [In] Locale obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setup\u00241(this.arg\u00242, (TextButton) obj0);
    }
  }
}
