// Decompiled with JetBrains decompiler
// Type: mindustry.editor.MapResizeDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.func;
using arc.math;
using arc.scene;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.ui.dialogs;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class MapResizeDialog : BaseDialog
  {
    public static int minSize;
    public static int maxSize;
    public static int increment;
    internal int width;
    internal int height;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 109, 242, 87, 123, 124, 221})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MapResizeDialog(MapEditor editor, Intc2 cons)
      : base("@editor.resizemap")
    {
      MapResizeDialog mapResizeDialog = this;
      this.shown((Runnable) new MapResizeDialog.__\u003C\u003EAnon0(this, editor));
      this.__\u003C\u003Ebuttons.defaults().size(200f, 50f);
      this.__\u003C\u003Ebuttons.button("@cancel", (Runnable) new MapResizeDialog.__\u003C\u003EAnon1(this));
      this.__\u003C\u003Ebuttons.button("@ok", (Runnable) new MapResizeDialog.__\u003C\u003EAnon2(this, cons));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 160, 107, 108, 140, 134, 119, 127, 20, 155, 191, 46, 140, 231, 55, 233, 75, 108, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] MapEditor obj0)
    {
      this.__\u003C\u003Econt.clear();
      this.width = obj0.width();
      this.height = obj0.height();
      Table table1 = new Table();
      bool[] booleans = Mathf.__\u003C\u003Ebooleans;
      int length = booleans.Length;
      for (int index = 0; index < length; ++index)
      {
        int num = booleans[index] ? 1 : 0;
        Table table2 = table1;
        object obj = num == 0 ? (object) "@height" : (object) "@width";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table2.add(text).padRight(8f);
        table1.defaults().height(60f).padTop(8f);
        table1.field(new StringBuilder().append(num == 0 ? this.height : this.width).append("").toString(), TextField.TextFieldFilter.digitsOnly, (Cons) new MapResizeDialog.__\u003C\u003EAnon3(this, num != 0)).valid((TextField.TextFieldValidator) new MapResizeDialog.__\u003C\u003EAnon4()).addInputDialog(3);
        table1.row();
      }
      this.__\u003C\u003Econt.row();
      this.__\u003C\u003Econt.add((Element) table1);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 185, 114, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] Intc2 obj0)
    {
      obj0.get(this.width, this.height);
      this.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 135, 98, 103, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] bool obj0, [In] string obj1)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = Integer.parseInt(obj1);
      if (num1 != 0)
        this.width = num2;
      else
        this.height = num2;
    }

    [Modifiers]
    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00241([In] string obj0) => Strings.canParsePositiveInt(obj0) && Integer.parseInt(obj0) <= MapResizeDialog.maxSize && Integer.parseInt(obj0) >= MapResizeDialog.minSize;

    [MethodImpl(MethodImplOptions.NoInlining)]
    static MapResizeDialog()
    {
      BaseDialog.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("mindustry.editor.MapResizeDialog"))
        return;
      MapResizeDialog.minSize = 50;
      MapResizeDialog.maxSize = 500;
      MapResizeDialog.increment = 50;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly MapResizeDialog arg\u00241;
      private readonly MapEditor arg\u00242;

      internal __\u003C\u003EAnon0([In] MapResizeDialog obj0, [In] MapEditor obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00242(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Runnable
    {
      private readonly MapResizeDialog arg\u00241;

      internal __\u003C\u003EAnon1([In] MapResizeDialog obj0) => this.arg\u00241 = obj0;

      public void run() => this.arg\u00241.hide();
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon2 : Runnable
    {
      private readonly MapResizeDialog arg\u00241;
      private readonly Intc2 arg\u00242;

      internal __\u003C\u003EAnon2([In] MapResizeDialog obj0, [In] Intc2 obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00243(this.arg\u00242);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly MapResizeDialog arg\u00241;
      private readonly bool arg\u00242;

      internal __\u003C\u003EAnon3([In] MapResizeDialog obj0, [In] bool obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242, (string) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon4 : TextField.TextFieldValidator
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool valid([In] string obj0) => (MapResizeDialog.lambda\u0024new\u00241(obj0) ? 1 : 0) != 0;
    }
  }
}
