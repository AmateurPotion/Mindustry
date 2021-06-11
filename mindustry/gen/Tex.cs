// Decompiled with JetBrains decompiler
// Type: mindustry.gen.Tex
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.scene.style;
using arc.scene.ui;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using mindustry.ui;
using System.Runtime.CompilerServices;

namespace mindustry.gen
{
  public class Tex : Object
  {
    public static TextureRegionDrawable sliderKnob;
    public static NinePatchDrawable flatDownBase;
    public static TextureRegionDrawable checkOver;
    public static TextureRegionDrawable nomap;
    public static NinePatchDrawable buttonOver;
    public static NinePatchDrawable buttonSelect;
    public static TextureRegionDrawable checkOnOver;
    public static TextureRegionDrawable scrollKnobHorizontalBlack;
    public static NinePatchDrawable buttonEdge3;
    public static TextureRegionDrawable scrollKnobVerticalThin;
    public static TextureRegionDrawable checkDisabled;
    public static NinePatchDrawable underlineDisabled;
    public static NinePatchDrawable paneSolid;
    public static NinePatchDrawable underline2;
    public static TextureRegionDrawable sliderVertical;
    public static TextureRegionDrawable checkOff;
    public static NinePatchDrawable buttonSquare;
    public static NinePatchDrawable buttonSquareOver;
    public static TextureRegionDrawable cursor;
    public static TextureRegionDrawable slider;
    public static TextureRegionDrawable discordBanner;
    public static NinePatchDrawable pane;
    public static NinePatchDrawable wavepane;
    public static TextureRegionDrawable checkOn;
    public static TextureRegionDrawable logicNode;
    public static TextureRegionDrawable sliderKnobOver;
    public static TextureRegionDrawable alphaBg;
    public static NinePatchDrawable underline;
    public static NinePatchDrawable buttonDisabled;
    public static TextureRegionDrawable crater;
    public static NinePatchDrawable buttonTrans;
    public static NinePatchDrawable whitePane;
    public static TextureRegionDrawable logo;
    public static TextureRegionDrawable sliderKnobDown;
    public static NinePatchDrawable buttonRightOver;
    public static TextureRegionDrawable whiteui;
    public static NinePatchDrawable scrollHorizontal;
    public static TextureRegionDrawable selection;
    public static NinePatchDrawable buttonRightDown;
    public static NinePatchDrawable windowEmpty;
    public static NinePatchDrawable buttonSquareDown;
    public static NinePatchDrawable underlineRed;
    public static NinePatchDrawable button;
    public static NinePatchDrawable buttonEdge4;
    public static TextureRegionDrawable infoBanner;
    public static NinePatchDrawable bar;
    public static NinePatchDrawable barTop;
    public static NinePatchDrawable inventory;
    public static NinePatchDrawable buttonRightDisabled;
    public static NinePatchDrawable scroll;
    public static NinePatchDrawable buttonRed;
    public static NinePatchDrawable buttonRight;
    public static TextureRegionDrawable scrollKnobVerticalBlack;
    public static NinePatchDrawable buttonEdge1;
    public static TextureRegionDrawable clear;
    public static TextureRegionDrawable checkOnDisabled;
    public static NinePatchDrawable buttonEdgeOver4;
    public static NinePatchDrawable underlineWhite;
    public static NinePatchDrawable pane2;
    public static NinePatchDrawable buttonDown;
    public static NinePatchDrawable buttonEdge2;

    [LineNumberTable(new byte[] {80, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load()
    {
      Tex.sliderKnob = (TextureRegionDrawable) Core.atlas.drawable("slider-knob");
      Tex.flatDownBase = (NinePatchDrawable) Core.atlas.drawable("flat-down-base");
      Tex.checkOver = (TextureRegionDrawable) Core.atlas.drawable("check-over");
      Tex.nomap = (TextureRegionDrawable) Core.atlas.drawable("nomap");
      Tex.buttonOver = (NinePatchDrawable) Core.atlas.drawable("button-over");
      Tex.buttonSelect = (NinePatchDrawable) Core.atlas.drawable("button-select");
      Tex.checkOnOver = (TextureRegionDrawable) Core.atlas.drawable("check-on-over");
      Tex.scrollKnobHorizontalBlack = (TextureRegionDrawable) Core.atlas.drawable("scroll-knob-horizontal-black");
      Tex.buttonEdge3 = (NinePatchDrawable) Core.atlas.drawable("button-edge-3");
      Tex.scrollKnobVerticalThin = (TextureRegionDrawable) Core.atlas.drawable("scroll-knob-vertical-thin");
      Tex.checkDisabled = (TextureRegionDrawable) Core.atlas.drawable("check-disabled");
      Tex.underlineDisabled = (NinePatchDrawable) Core.atlas.drawable("underline-disabled");
      Tex.paneSolid = (NinePatchDrawable) Core.atlas.drawable("pane-solid");
      Tex.underline2 = (NinePatchDrawable) Core.atlas.drawable("underline-2");
      Tex.sliderVertical = (TextureRegionDrawable) Core.atlas.drawable("slider-vertical");
      Tex.checkOff = (TextureRegionDrawable) Core.atlas.drawable("check-off");
      Tex.buttonSquare = (NinePatchDrawable) Core.atlas.drawable("button-square");
      Tex.buttonSquareOver = (NinePatchDrawable) Core.atlas.drawable("button-square-over");
      Tex.cursor = (TextureRegionDrawable) Core.atlas.drawable("cursor");
      Tex.slider = (TextureRegionDrawable) Core.atlas.drawable("slider");
      Tex.discordBanner = (TextureRegionDrawable) Core.atlas.drawable("discord-banner");
      Tex.pane = (NinePatchDrawable) Core.atlas.drawable("pane");
      Tex.wavepane = (NinePatchDrawable) Core.atlas.drawable("wavepane");
      Tex.checkOn = (TextureRegionDrawable) Core.atlas.drawable("check-on");
      Tex.logicNode = (TextureRegionDrawable) Core.atlas.drawable("logic-node");
      Tex.sliderKnobOver = (TextureRegionDrawable) Core.atlas.drawable("slider-knob-over");
      Tex.alphaBg = (TextureRegionDrawable) Core.atlas.drawable("alpha-bg");
      Tex.underline = (NinePatchDrawable) Core.atlas.drawable("underline");
      Tex.buttonDisabled = (NinePatchDrawable) Core.atlas.drawable("button-disabled");
      Tex.crater = (TextureRegionDrawable) Core.atlas.drawable("crater");
      Tex.buttonTrans = (NinePatchDrawable) Core.atlas.drawable("button-trans");
      Tex.whitePane = (NinePatchDrawable) Core.atlas.drawable("white-pane");
      Tex.logo = (TextureRegionDrawable) Core.atlas.drawable("logo");
      Tex.sliderKnobDown = (TextureRegionDrawable) Core.atlas.drawable("slider-knob-down");
      Tex.buttonRightOver = (NinePatchDrawable) Core.atlas.drawable("button-right-over");
      Tex.whiteui = (TextureRegionDrawable) Core.atlas.drawable("whiteui");
      Tex.scrollHorizontal = (NinePatchDrawable) Core.atlas.drawable("scroll-horizontal");
      Tex.selection = (TextureRegionDrawable) Core.atlas.drawable("selection");
      Tex.buttonRightDown = (NinePatchDrawable) Core.atlas.drawable("button-right-down");
      Tex.windowEmpty = (NinePatchDrawable) Core.atlas.drawable("window-empty");
      Tex.buttonSquareDown = (NinePatchDrawable) Core.atlas.drawable("button-square-down");
      Tex.underlineRed = (NinePatchDrawable) Core.atlas.drawable("underline-red");
      Tex.button = (NinePatchDrawable) Core.atlas.drawable("button");
      Tex.buttonEdge4 = (NinePatchDrawable) Core.atlas.drawable("button-edge-4");
      Tex.infoBanner = (TextureRegionDrawable) Core.atlas.drawable("info-banner");
      Tex.bar = (NinePatchDrawable) Core.atlas.drawable("bar");
      Tex.barTop = (NinePatchDrawable) Core.atlas.drawable("bar-top");
      Tex.inventory = (NinePatchDrawable) Core.atlas.drawable("inventory");
      Tex.buttonRightDisabled = (NinePatchDrawable) Core.atlas.drawable("button-right-disabled");
      Tex.scroll = (NinePatchDrawable) Core.atlas.drawable("scroll");
      Tex.buttonRed = (NinePatchDrawable) Core.atlas.drawable("button-red");
      Tex.buttonRight = (NinePatchDrawable) Core.atlas.drawable("button-right");
      Tex.scrollKnobVerticalBlack = (TextureRegionDrawable) Core.atlas.drawable("scroll-knob-vertical-black");
      Tex.buttonEdge1 = (NinePatchDrawable) Core.atlas.drawable("button-edge-1");
      Tex.clear = (TextureRegionDrawable) Core.atlas.drawable("clear");
      Tex.checkOnDisabled = (TextureRegionDrawable) Core.atlas.drawable("check-on-disabled");
      Tex.buttonEdgeOver4 = (NinePatchDrawable) Core.atlas.drawable("button-edge-over-4");
      Tex.underlineWhite = (NinePatchDrawable) Core.atlas.drawable("underline-white");
      Tex.pane2 = (NinePatchDrawable) Core.atlas.drawable("pane-2");
      Tex.buttonDown = (NinePatchDrawable) Core.atlas.drawable("button-down");
      Tex.buttonEdge2 = (NinePatchDrawable) Core.atlas.drawable("button-edge-2");
    }

    [LineNumberTable(new byte[] {160, 80, 116, 116, 116, 116, 116, 116, 116, 116, 116, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadStyles()
    {
      Core.scene.addStyle((Class) ClassLiteral<Button.ButtonStyle>.Value, (object) Styles.defaultb);
      Core.scene.addStyle((Class) ClassLiteral<TextButton.TextButtonStyle>.Value, (object) Styles.defaultt);
      Core.scene.addStyle((Class) ClassLiteral<ImageButton.ImageButtonStyle>.Value, (object) Styles.defaulti);
      Core.scene.addStyle((Class) ClassLiteral<ScrollPane.ScrollPaneStyle>.Value, (object) Styles.defaultPane);
      Core.scene.addStyle((Class) ClassLiteral<KeybindDialog.KeybindDialogStyle>.Value, (object) Styles.defaultKeybindDialog);
      Core.scene.addStyle((Class) ClassLiteral<Slider.SliderStyle>.Value, (object) Styles.defaultSlider);
      Core.scene.addStyle((Class) ClassLiteral<Label.LabelStyle>.Value, (object) Styles.defaultLabel);
      Core.scene.addStyle((Class) ClassLiteral<TextField.TextFieldStyle>.Value, (object) Styles.defaultField);
      Core.scene.addStyle((Class) ClassLiteral<CheckBox.CheckBoxStyle>.Value, (object) Styles.defaultCheck);
      Core.scene.addStyle((Class) ClassLiteral<Dialog.DialogStyle>.Value, (object) Styles.defaultDialog);
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Tex()
    {
    }
  }
}
