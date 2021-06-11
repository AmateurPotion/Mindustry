// Decompiled with JetBrains decompiler
// Type: arc.scene.utils.Elem
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.graphics;
using arc.scene.style;
using arc.scene.ui;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene.utils
{
  public class Elem : Object
  {
    [LineNumberTable(new byte[] {159, 155, 103, 99, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static CheckBox newCheck(string text, Boolc listener)
    {
      CheckBox checkBox = new CheckBox(text);
      if (listener != null)
        checkBox.changed((Runnable) new Elem.__\u003C\u003EAnon0(listener, checkBox));
      return checkBox;
    }

    [LineNumberTable(new byte[] {159, 162, 103, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextButton newButton(string text, Runnable listener)
    {
      TextButton textButton = new TextButton(text);
      if (listener != null)
        textButton.changed(listener);
      return textButton;
    }

    [LineNumberTable(new byte[] {159, 170, 104, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextButton newButton(
      string text,
      TextButton.TextButtonStyle style,
      Runnable listener)
    {
      TextButton textButton = new TextButton(text, style);
      if (listener != null)
        textButton.changed(listener);
      return textButton;
    }

    [LineNumberTable(new byte[] {159, 178, 103, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ImageButton newImageButton(Drawable icon, Runnable listener)
    {
      ImageButton imageButton = new ImageButton(icon);
      if (listener != null)
        imageButton.changed(listener);
      return imageButton;
    }

    [Signature("(Ljava/lang/String;Larc/func/Cons<Ljava/lang/String;>;)Larc/scene/ui/TextField;")]
    [LineNumberTable(new byte[] {18, 103, 99, 242, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextField newField(string text, Cons listener)
    {
      TextField textField = new TextField(text);
      if (listener != null)
        textField.changed((Runnable) new Elem.__\u003C\u003EAnon1(textField, listener));
      return textField;
    }

    [Modifiers]
    [LineNumberTable(15)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024newCheck\u00240([In] Boolc obj0, [In] CheckBox obj1) => obj0.get(obj1.isChecked());

    [Modifiers]
    [LineNumberTable(new byte[] {21, 104, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024newField\u00241([In] TextField obj0, [In] Cons obj1)
    {
      if (!obj0.isValid())
        return;
      obj1.get((object) obj0.getText());
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Elem()
    {
    }

    [LineNumberTable(new byte[] {159, 185, 103, 104, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ImageButton newImageButton(
      Drawable icon,
      float size,
      Runnable listener)
    {
      ImageButton imageButton = new ImageButton(icon);
      imageButton.resizeImage(size);
      if (listener != null)
        imageButton.changed(listener);
      return imageButton;
    }

    [LineNumberTable(new byte[] {1, 104, 104, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ImageButton newImageButton(
      ImageButton.ImageButtonStyle style,
      Drawable icon,
      float size,
      Runnable listener)
    {
      ImageButton imageButton = new ImageButton(icon, style);
      imageButton.resizeImage(size);
      if (listener != null)
        imageButton.changed(listener);
      return imageButton;
    }

    [LineNumberTable(new byte[] {9, 103, 104, 108, 99, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ImageButton newImageButton(
      Drawable icon,
      float size,
      Color color,
      Runnable listener)
    {
      ImageButton imageButton = new ImageButton(icon);
      imageButton.resizeImage(size);
      imageButton.getImage().setColor(color);
      if (listener != null)
        imageButton.changed(listener);
      return imageButton;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly Boolc arg\u00241;
      private readonly CheckBox arg\u00242;

      internal __\u003C\u003EAnon0([In] Boolc obj0, [In] CheckBox obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Elem.lambda\u0024newCheck\u00240(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly TextField arg\u00241;
      private readonly Cons arg\u00242;

      internal __\u003C\u003EAnon1([In] TextField obj0, [In] Cons obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => Elem.lambda\u0024newField\u00241(this.arg\u00241, this.arg\u00242);
    }
  }
}
