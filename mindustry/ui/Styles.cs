// Decompiled with JetBrains decompiler
// Type: mindustry.ui.Styles
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using arc.scene.style;
using arc.scene.ui;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.graphics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class Styles : Object
  {
    public static Drawable black;
    public static Drawable black9;
    public static Drawable black8;
    public static Drawable black6;
    public static Drawable black3;
    public static Drawable black5;
    public static Drawable none;
    public static Drawable flatDown;
    public static Drawable flatOver;
    public static Drawable accentDrawable;
    public static Button.ButtonStyle defaultb;
    public static Button.ButtonStyle waveb;
    public static Button.ButtonStyle modsb;
    public static TextButton.TextButtonStyle defaultt;
    public static TextButton.TextButtonStyle squaret;
    public static TextButton.TextButtonStyle nodet;
    public static TextButton.TextButtonStyle cleart;
    public static TextButton.TextButtonStyle discordt;
    public static TextButton.TextButtonStyle nonet;
    public static TextButton.TextButtonStyle infot;
    public static TextButton.TextButtonStyle clearPartialt;
    public static TextButton.TextButtonStyle clearTogglet;
    public static TextButton.TextButtonStyle logicTogglet;
    public static TextButton.TextButtonStyle clearToggleMenut;
    public static TextButton.TextButtonStyle togglet;
    public static TextButton.TextButtonStyle transt;
    public static TextButton.TextButtonStyle fullTogglet;
    public static TextButton.TextButtonStyle logict;
    public static ImageButton.ImageButtonStyle defaulti;
    public static ImageButton.ImageButtonStyle nodei;
    public static ImageButton.ImageButtonStyle righti;
    public static ImageButton.ImageButtonStyle emptyi;
    public static ImageButton.ImageButtonStyle emptytogglei;
    public static ImageButton.ImageButtonStyle selecti;
    public static ImageButton.ImageButtonStyle logici;
    public static ImageButton.ImageButtonStyle geni;
    public static ImageButton.ImageButtonStyle colori;
    public static ImageButton.ImageButtonStyle accenti;
    public static ImageButton.ImageButtonStyle cleari;
    public static ImageButton.ImageButtonStyle clearFulli;
    public static ImageButton.ImageButtonStyle clearPartiali;
    public static ImageButton.ImageButtonStyle clearPartial2i;
    public static ImageButton.ImageButtonStyle clearTogglei;
    public static ImageButton.ImageButtonStyle clearTransi;
    public static ImageButton.ImageButtonStyle clearToggleTransi;
    public static ImageButton.ImageButtonStyle clearTogglePartiali;
    public static ScrollPane.ScrollPaneStyle defaultPane;
    public static ScrollPane.ScrollPaneStyle horizontalPane;
    public static ScrollPane.ScrollPaneStyle smallPane;
    public static KeybindDialog.KeybindDialogStyle defaultKeybindDialog;
    public static Slider.SliderStyle defaultSlider;
    public static Slider.SliderStyle vSlider;
    public static Label.LabelStyle defaultLabel;
    public static Label.LabelStyle outlineLabel;
    public static Label.LabelStyle techLabel;
    public static TextField.TextFieldStyle defaultField;
    public static TextField.TextFieldStyle nodeField;
    public static TextField.TextFieldStyle areaField;
    public static TextField.TextFieldStyle nodeArea;
    public static CheckBox.CheckBoxStyle defaultCheck;
    public static Dialog.DialogStyle defaultDialog;
    public static Dialog.DialogStyle fullDialog;

    [LineNumberTable(new byte[] {159, 182, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 127, 4, 106, 121, 148, 234, 71, 234, 70, 234, 70, 234, 73, 234, 73, 234, 72, 234, 71, 234, 72, 234, 72, 234, 69, 234, 69, 234, 72, 234, 72, 234, 74, 234, 74, 234, 74, 234, 74, 234, 74, 234, 72, 202, 234, 72, 202, 234, 69, 202, 202, 202, 202, 234, 69, 234, 69, 234, 69, 234, 72, 234, 69, 234, 70, 234, 72, 234, 70, 234, 71, 202, 234, 70, 234, 69, 234, 70, 234, 70, 234, 71, 202, 202, 234, 69, 234, 77, 234, 77, 234, 75, 234, 75, 234, 76, 234, 70, 234, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load()
    {
      Styles.black = Tex.whiteui.tint(0.0f, 0.0f, 0.0f, 1f);
      Styles.black9 = Tex.whiteui.tint(0.0f, 0.0f, 0.0f, 0.9f);
      Styles.black8 = Tex.whiteui.tint(0.0f, 0.0f, 0.0f, 0.8f);
      Styles.black6 = Tex.whiteui.tint(0.0f, 0.0f, 0.0f, 0.6f);
      Styles.black5 = Tex.whiteui.tint(0.0f, 0.0f, 0.0f, 0.5f);
      Styles.black3 = Tex.whiteui.tint(0.0f, 0.0f, 0.0f, 0.3f);
      Styles.none = Tex.whiteui.tint(0.0f, 0.0f, 0.0f, 0.0f);
      Styles.flatDown = Styles.createFlatDown();
      Styles.flatOver = Tex.whiteui.tint(Color.valueOf("454545"));
      Styles.accentDrawable = Tex.whiteui.tint(Pal.accent);
      Styles.defaultb = (Button.ButtonStyle) new Styles.\u0031();
      Styles.modsb = (Button.ButtonStyle) new Styles.\u0032();
      Styles.waveb = (Button.ButtonStyle) new Styles.\u0033();
      Styles.defaultt = (TextButton.TextButtonStyle) new Styles.\u0034();
      Styles.squaret = (TextButton.TextButtonStyle) new Styles.\u0035();
      Styles.nodet = (TextButton.TextButtonStyle) new Styles.\u0036();
      Styles.nonet = (TextButton.TextButtonStyle) new Styles.\u0037();
      Styles.cleart = (TextButton.TextButtonStyle) new Styles.\u0038();
      Styles.logict = (TextButton.TextButtonStyle) new Styles.\u0039();
      Styles.discordt = (TextButton.TextButtonStyle) new Styles.\u00310();
      Styles.infot = (TextButton.TextButtonStyle) new Styles.\u00311();
      Styles.clearPartialt = (TextButton.TextButtonStyle) new Styles.\u00312();
      Styles.transt = (TextButton.TextButtonStyle) new Styles.\u00313();
      Styles.clearTogglet = (TextButton.TextButtonStyle) new Styles.\u00314();
      Styles.logicTogglet = (TextButton.TextButtonStyle) new Styles.\u00315();
      Styles.clearToggleMenut = (TextButton.TextButtonStyle) new Styles.\u00316();
      Styles.togglet = (TextButton.TextButtonStyle) new Styles.\u00317();
      Styles.fullTogglet = (TextButton.TextButtonStyle) new Styles.\u00318();
      Styles.defaulti = (ImageButton.ImageButtonStyle) new Styles.\u00319();
      Styles.nodei = (ImageButton.ImageButtonStyle) new Styles.\u00320();
      Styles.righti = (ImageButton.ImageButtonStyle) new Styles.\u00321();
      Styles.emptyi = (ImageButton.ImageButtonStyle) new Styles.\u00322();
      Styles.emptytogglei = (ImageButton.ImageButtonStyle) new Styles.\u00323();
      Styles.selecti = (ImageButton.ImageButtonStyle) new Styles.\u00324();
      Styles.logici = (ImageButton.ImageButtonStyle) new Styles.\u00325();
      Styles.geni = (ImageButton.ImageButtonStyle) new Styles.\u00326();
      Styles.colori = (ImageButton.ImageButtonStyle) new Styles.\u00327();
      Styles.accenti = (ImageButton.ImageButtonStyle) new Styles.\u00328();
      Styles.cleari = (ImageButton.ImageButtonStyle) new Styles.\u00329();
      Styles.clearFulli = (ImageButton.ImageButtonStyle) new Styles.\u00330();
      Styles.clearPartiali = (ImageButton.ImageButtonStyle) new Styles.\u00331();
      Styles.clearPartial2i = (ImageButton.ImageButtonStyle) new Styles.\u00332();
      Styles.clearTogglei = (ImageButton.ImageButtonStyle) new Styles.\u00333();
      Styles.clearTransi = (ImageButton.ImageButtonStyle) new Styles.\u00334();
      Styles.clearToggleTransi = (ImageButton.ImageButtonStyle) new Styles.\u00335();
      Styles.clearTogglePartiali = (ImageButton.ImageButtonStyle) new Styles.\u00336();
      Styles.defaultPane = (ScrollPane.ScrollPaneStyle) new Styles.\u00337();
      Styles.horizontalPane = (ScrollPane.ScrollPaneStyle) new Styles.\u00338();
      Styles.smallPane = (ScrollPane.ScrollPaneStyle) new Styles.\u00339();
      Styles.defaultKeybindDialog = (KeybindDialog.KeybindDialogStyle) new Styles.\u00340();
      Styles.defaultSlider = (Slider.SliderStyle) new Styles.\u00341();
      Styles.vSlider = (Slider.SliderStyle) new Styles.\u00342();
      Styles.defaultLabel = (Label.LabelStyle) new Styles.\u00343();
      Styles.outlineLabel = (Label.LabelStyle) new Styles.\u00344();
      Styles.techLabel = (Label.LabelStyle) new Styles.\u00345();
      Styles.defaultField = (TextField.TextFieldStyle) new Styles.\u00346();
      Styles.nodeField = (TextField.TextFieldStyle) new Styles.\u00347();
      Styles.areaField = (TextField.TextFieldStyle) new Styles.\u00348();
      Styles.nodeArea = (TextField.TextFieldStyle) new Styles.\u00349();
      Styles.defaultCheck = (CheckBox.CheckBoxStyle) new Styles.\u00350();
      Styles.defaultDialog = (Dialog.DialogStyle) new Styles.\u00351();
      Styles.fullDialog = (Dialog.DialogStyle) new Styles.\u00352();
    }

    [LineNumberTable(new byte[] {161, 47, 112, 135, 253, 70, 107, 107, 107, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Drawable createFlatDown()
    {
      TextureAtlas.AtlasRegion atlasRegion = Core.atlas.find("flat-down-base");
      int[] splits = atlasRegion.splits;
      NinePatch.__\u003Cclinit\u003E();
      Styles.\u00353 obj = new Styles.\u00353(new NinePatch((TextureRegion) atlasRegion, splits[0], splits[1], splits[2], splits[3]));
      obj.setMinWidth(0.0f);
      obj.setMinHeight(0.0f);
      obj.setTopHeight(0.0f);
      obj.setRightWidth(0.0f);
      obj.setBottomHeight(0.0f);
      obj.setLeftWidth(0.0f);
      return (Drawable) obj;
    }

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Styles()
    {
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0031 : Button.ButtonStyle
    {
      [LineNumberTable(new byte[] {1, 104, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
        Styles.\u0031 obj = this;
        this.down = (Drawable) Tex.buttonDown;
        this.up = (Drawable) Tex.button;
        this.over = (Drawable) Tex.buttonOver;
        this.disabled = (Drawable) Tex.buttonDisabled;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00310 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {69, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00310()
      {
        Styles.\u00310 obj = this;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.up = (Drawable) Tex.discordBanner;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00311 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {74, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00311()
      {
        Styles.\u00311 obj = this;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.up = (Drawable) Tex.infoBanner;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00312 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {79, 104, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00312()
      {
        Styles.\u00312 obj = this;
        this.down = Styles.flatOver;
        this.up = (Drawable) Tex.pane;
        this.over = (Drawable) Tex.flatDownBase;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00313 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {87, 104, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00313()
      {
        Styles.\u00313 obj = this;
        this.down = Styles.flatDown;
        this.up = Styles.none;
        this.over = Styles.flatOver;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00314 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {95, 104, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00314()
      {
        Styles.\u00314 obj = this;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.@checked = Styles.flatDown;
        this.down = Styles.flatDown;
        this.up = Styles.black;
        this.over = Styles.flatOver;
        this.disabled = Styles.black;
        this.disabledFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00315 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {105, 104, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00315()
      {
        Styles.\u00315 obj = this;
        this.font = Fonts.outline;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.@checked = Styles.accentDrawable;
        this.down = Styles.accentDrawable;
        this.up = Styles.black;
        this.over = Styles.flatOver;
        this.disabled = Styles.black;
        this.disabledFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00316 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {115, 104, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00316()
      {
        Styles.\u00316 obj = this;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.@checked = Styles.flatDown;
        this.down = Styles.flatDown;
        this.up = (Drawable) Tex.clear;
        this.over = Styles.flatOver;
        this.disabled = Styles.black;
        this.disabledFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00317 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {125, 104, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00317()
      {
        Styles.\u00317 obj = this;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.@checked = (Drawable) Tex.buttonDown;
        this.down = (Drawable) Tex.buttonDown;
        this.up = (Drawable) Tex.button;
        this.over = (Drawable) Tex.buttonOver;
        this.disabled = (Drawable) Tex.buttonDisabled;
        this.disabledFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00318 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {160, 71, 104, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00318()
      {
        Styles.\u00318 obj = this;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.@checked = Styles.flatOver;
        this.down = Styles.flatOver;
        this.up = Styles.black;
        this.over = Styles.flatOver;
        this.disabled = Styles.black;
        this.disabledFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00319 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 81, 104, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00319()
      {
        Styles.\u00319 obj = this;
        this.down = (Drawable) Tex.buttonDown;
        this.up = (Drawable) Tex.button;
        this.over = (Drawable) Tex.buttonOver;
        this.imageDisabledColor = Color.__\u003C\u003Egray;
        this.imageUpColor = Color.__\u003C\u003Ewhite;
        this.disabled = (Drawable) Tex.buttonDisabled;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0032 : Button.ButtonStyle
    {
      [LineNumberTable(new byte[] {8, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032()
      {
        Styles.\u0032 obj = this;
        this.down = Styles.flatOver;
        this.up = (Drawable) Tex.underline;
        this.over = (Drawable) Tex.underlineWhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00320 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 89, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00320()
      {
        Styles.\u00320 obj = this;
        this.up = (Drawable) Tex.buttonOver;
        this.over = (Drawable) Tex.buttonDown;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00321 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 93, 104, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00321()
      {
        Styles.\u00321 obj = this;
        this.over = (Drawable) Tex.buttonRightOver;
        this.down = (Drawable) Tex.buttonRightDown;
        this.up = (Drawable) Tex.buttonRight;
        this.disabled = (Drawable) Tex.buttonRightDisabled;
        this.imageDisabledColor = Color.__\u003C\u003Eclear;
        this.imageUpColor = Color.__\u003C\u003Ewhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00322 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 101, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00322()
      {
        Styles.\u00322 obj = this;
        this.imageDownColor = Pal.accent;
        this.imageUpColor = Color.__\u003C\u003Ewhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00323 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 105, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00323()
      {
        Styles.\u00323 obj = this;
        this.imageCheckedColor = Color.__\u003C\u003Ewhite;
        this.imageDownColor = Color.__\u003C\u003Ewhite;
        this.imageUpColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00324 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 110, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00324()
      {
        Styles.\u00324 obj = this;
        this.@checked = (Drawable) Tex.buttonSelect;
        this.up = Styles.none;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00325 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 114, 136, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00325()
      {
        Styles.\u00325 obj = this;
        this.imageUpColor = Color.__\u003C\u003Eblack;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00326 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 118, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00326()
      {
        Styles.\u00326 obj = this;
        this.imageDownColor = Pal.accent;
        this.imageUpColor = Color.__\u003C\u003Eblack;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00327 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 122, 136, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00327()
      {
        Styles.\u00327 obj = this;
        this.imageUpColor = Color.__\u003C\u003Ewhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00328 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 126, 136, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00328()
      {
        Styles.\u00328 obj = this;
        this.imageUpColor = Color.__\u003C\u003ElightGray;
        this.imageDownColor = Color.__\u003C\u003Ewhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00329 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 131, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00329()
      {
        Styles.\u00329 obj = this;
        this.down = Styles.flatOver;
        this.up = Styles.black;
        this.over = Styles.flatOver;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0033 : Button.ButtonStyle
    {
      [LineNumberTable(new byte[] {14, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033()
      {
        Styles.\u0033 obj = this;
        this.up = (Drawable) Tex.wavepane;
        this.over = (Drawable) Tex.wavepane;
        this.disabled = (Drawable) Tex.wavepane;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00330 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 136, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00330()
      {
        Styles.\u00330 obj = this;
        this.down = (Drawable) Tex.whiteui;
        this.up = (Drawable) Tex.pane;
        this.over = Styles.flatDown;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00331 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 141, 104, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00331()
      {
        Styles.\u00331 obj = this;
        this.down = Styles.flatDown;
        this.up = Styles.none;
        this.over = Styles.flatOver;
        this.disabled = Styles.none;
        this.imageDisabledColor = Color.__\u003C\u003Egray;
        this.imageUpColor = Color.__\u003C\u003Ewhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00332 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 149, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00332()
      {
        Styles.\u00332 obj = this;
        this.down = (Drawable) Tex.whiteui;
        this.up = (Drawable) Tex.pane;
        this.over = Styles.flatDown;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00333 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 154, 104, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00333()
      {
        Styles.\u00333 obj = this;
        this.down = Styles.flatDown;
        this.@checked = Styles.flatDown;
        this.up = Styles.black;
        this.over = Styles.flatOver;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00334 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 160, 104, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00334()
      {
        Styles.\u00334 obj = this;
        this.down = Styles.flatDown;
        this.up = Styles.black6;
        this.over = Styles.flatOver;
        this.disabled = Styles.black8;
        this.imageDisabledColor = Color.__\u003C\u003ElightGray;
        this.imageUpColor = Color.__\u003C\u003Ewhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00335 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 168, 104, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00335()
      {
        Styles.\u00335 obj = this;
        this.down = Styles.flatDown;
        this.@checked = Styles.flatDown;
        this.up = Styles.black6;
        this.over = Styles.flatOver;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00336 : ImageButton.ImageButtonStyle
    {
      [LineNumberTable(new byte[] {160, 174, 104, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00336()
      {
        Styles.\u00336 obj = this;
        this.down = Styles.flatDown;
        this.@checked = Styles.flatDown;
        this.up = Styles.none;
        this.over = Styles.flatOver;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00337 : ScrollPane.ScrollPaneStyle
    {
      [LineNumberTable(new byte[] {160, 181, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00337()
      {
        Styles.\u00337 obj = this;
        this.vScroll = (Drawable) Tex.scroll;
        this.vScrollKnob = (Drawable) Tex.scrollKnobVerticalBlack;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00338 : ScrollPane.ScrollPaneStyle
    {
      [LineNumberTable(new byte[] {160, 185, 104, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00338()
      {
        Styles.\u00338 obj = this;
        this.vScroll = (Drawable) Tex.scroll;
        this.vScrollKnob = (Drawable) Tex.scrollKnobVerticalBlack;
        this.hScroll = (Drawable) Tex.scrollHorizontal;
        this.hScrollKnob = (Drawable) Tex.scrollKnobHorizontalBlack;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00339 : ScrollPane.ScrollPaneStyle
    {
      [LineNumberTable(new byte[] {160, 191, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00339()
      {
        Styles.\u00339 obj = this;
        this.vScroll = (Drawable) Tex.clear;
        this.vScrollKnob = (Drawable) Tex.scrollKnobVerticalThin;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0034 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {20, 104, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034()
      {
        Styles.\u0034 obj = this;
        this.over = (Drawable) Tex.buttonOver;
        this.disabled = (Drawable) Tex.buttonDisabled;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.down = (Drawable) Tex.buttonDown;
        this.up = (Drawable) Tex.button;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00340 : KeybindDialog.KeybindDialogStyle
    {
      [LineNumberTable(new byte[] {160, 196, 104, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00340()
      {
        Styles.\u00340 obj = this;
        this.keyColor = Pal.accent;
        this.keyNameColor = Color.__\u003C\u003Ewhite;
        this.controllerColor = Color.__\u003C\u003ElightGray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00341 : Slider.SliderStyle
    {
      [LineNumberTable(new byte[] {160, 202, 104, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00341()
      {
        Styles.\u00341 obj = this;
        this.background = (Drawable) Tex.slider;
        this.knob = (Drawable) Tex.sliderKnob;
        this.knobOver = (Drawable) Tex.sliderKnobOver;
        this.knobDown = (Drawable) Tex.sliderKnobDown;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00342 : Slider.SliderStyle
    {
      [LineNumberTable(new byte[] {160, 208, 104, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00342()
      {
        Styles.\u00342 obj = this;
        this.background = (Drawable) Tex.sliderVertical;
        this.knob = (Drawable) Tex.sliderKnob;
        this.knobOver = (Drawable) Tex.sliderKnobOver;
        this.knobDown = (Drawable) Tex.sliderKnobDown;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00343 : Label.LabelStyle
    {
      [LineNumberTable(new byte[] {160, 215, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00343()
      {
        Styles.\u00343 obj = this;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00344 : Label.LabelStyle
    {
      [LineNumberTable(new byte[] {160, 219, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00344()
      {
        Styles.\u00344 obj = this;
        this.font = Fonts.outline;
        this.fontColor = Color.__\u003C\u003Ewhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00345 : Label.LabelStyle
    {
      [LineNumberTable(new byte[] {160, 223, 104, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00345()
      {
        Styles.\u00345 obj = this;
        this.font = Fonts.tech;
        this.fontColor = Color.__\u003C\u003Ewhite;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00346 : TextField.TextFieldStyle
    {
      [LineNumberTable(new byte[] {160, 228, 104, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00346()
      {
        Styles.\u00346 obj = this;
        this.font = Fonts.chat;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.disabledBackground = (Drawable) Tex.underlineDisabled;
        this.selection = (Drawable) Tex.selection;
        this.background = (Drawable) Tex.underline;
        this.invalidBackground = (Drawable) Tex.underlineRed;
        this.cursor = (Drawable) Tex.cursor;
        this.messageFont = Fonts.def;
        this.messageFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00347 : TextField.TextFieldStyle
    {
      [LineNumberTable(new byte[] {160, 241, 104, 107, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00347()
      {
        Styles.\u00347 obj = this;
        this.font = Fonts.chat;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.disabledBackground = (Drawable) Tex.underlineDisabled;
        this.selection = (Drawable) Tex.selection;
        this.background = (Drawable) Tex.underlineWhite;
        this.invalidBackground = (Drawable) Tex.underlineRed;
        this.cursor = (Drawable) Tex.cursor;
        this.messageFont = Fonts.def;
        this.messageFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00348 : TextField.TextFieldStyle
    {
      [LineNumberTable(new byte[] {160, 254, 104, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00348()
      {
        Styles.\u00348 obj = this;
        this.font = Fonts.chat;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.selection = (Drawable) Tex.selection;
        this.background = (Drawable) Tex.underline;
        this.cursor = (Drawable) Tex.cursor;
        this.messageFont = Fonts.def;
        this.messageFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00349 : TextField.TextFieldStyle
    {
      [LineNumberTable(new byte[] {161, 9, 104, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00349()
      {
        Styles.\u00349 obj = this;
        this.font = Fonts.chat;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.selection = (Drawable) Tex.selection;
        this.background = (Drawable) Tex.underlineWhite;
        this.cursor = (Drawable) Tex.cursor;
        this.messageFont = Fonts.def;
        this.messageFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0035 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {29, 104, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035()
      {
        Styles.\u0035 obj = this;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.over = (Drawable) Tex.buttonSquareOver;
        this.disabled = (Drawable) Tex.buttonDisabled;
        this.down = (Drawable) Tex.buttonSquareDown;
        this.up = (Drawable) Tex.buttonSquare;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00350 : CheckBox.CheckBoxStyle
    {
      [LineNumberTable(new byte[] {161, 20, 104, 107, 107, 107, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00350()
      {
        Styles.\u00350 obj = this;
        this.checkboxOn = (Drawable) Tex.checkOn;
        this.checkboxOff = (Drawable) Tex.checkOff;
        this.checkboxOnOver = (Drawable) Tex.checkOnOver;
        this.checkboxOver = (Drawable) Tex.checkOver;
        this.checkboxOnDisabled = (Drawable) Tex.checkOnDisabled;
        this.checkboxOffDisabled = (Drawable) Tex.checkDisabled;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00351 : Dialog.DialogStyle
    {
      [LineNumberTable(new byte[] {161, 32, 104, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00351()
      {
        Styles.\u00351 obj = this;
        this.stageBackground = Styles.black9;
        this.titleFont = Fonts.def;
        this.background = (Drawable) Tex.windowEmpty;
        this.titleFontColor = Pal.accent;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u00352 : Dialog.DialogStyle
    {
      [LineNumberTable(new byte[] {161, 38, 104, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00352()
      {
        Styles.\u00352 obj = this;
        this.stageBackground = Styles.black;
        this.titleFont = Fonts.def;
        this.background = (Drawable) Tex.windowEmpty;
        this.titleFontColor = Pal.accent;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "createFlatDown", "()Larc.scene.style.Drawable;")]
    [SpecialName]
    internal class \u00353 : ScaledNinePatchDrawable
    {
      [LineNumberTable(420)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u00353([In] NinePatch obj0)
        : base(obj0)
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getLeftWidth() => 0.0f;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getRightWidth() => 0.0f;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getTopHeight() => 0.0f;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float getBottomHeight() => 0.0f;
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0036 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {38, 104, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036()
      {
        Styles.\u0036 obj = this;
        this.disabled = (Drawable) Tex.button;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.up = (Drawable) Tex.buttonOver;
        this.over = (Drawable) Tex.buttonDown;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0037 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {46, 104, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037()
      {
        Styles.\u0037 obj = this;
        this.font = Fonts.outline;
        this.fontColor = Color.__\u003C\u003ElightGray;
        this.overFontColor = Pal.accent;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.up = Styles.none;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0038 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {53, 104, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0038()
      {
        Styles.\u0038 obj = this;
        this.over = Styles.flatOver;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.down = Styles.flatOver;
        this.up = Styles.black;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "load", "()V")]
    [SpecialName]
    internal class \u0039 : TextButton.TextButtonStyle
    {
      [LineNumberTable(new byte[] {61, 104, 107, 107, 107, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0039()
      {
        Styles.\u0039 obj = this;
        this.over = Styles.flatOver;
        this.font = Fonts.def;
        this.fontColor = Color.__\u003C\u003Ewhite;
        this.disabledFontColor = Color.__\u003C\u003Egray;
        this.down = Styles.flatOver;
        this.up = (Drawable) Tex.underlineWhite;
      }
    }
  }
}
