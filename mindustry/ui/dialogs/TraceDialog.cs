// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.TraceDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.scene;
using arc.scene.style;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using mindustry.gen;
using mindustry.net;
using System.Runtime.CompilerServices;

namespace mindustry.ui.dialogs
{
  public class TraceDialog : BaseDialog
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 160, 139, 112, 108, 145, 108, 127, 22, 103, 127, 22, 103, 127, 22, 103, 127, 27, 103, 127, 27, 103, 127, 27, 103, 127, 27, 135, 113, 135, 141, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(Player player, Administration.TraceInfo info)
    {
      this.__\u003C\u003Econt.clear();
      Table.__\u003Cclinit\u003E();
      Table table1 = new Table((Drawable) Tex.clear);
      table1.margin(14f);
      table1.defaults().pad(1f);
      table1.defaults().left();
      Table table2 = table1;
      object obj1 = (object) Core.bundle.format("trace.playername", (object) player.name);
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj1;
      CharSequence text1 = charSequence;
      table2.add(text1);
      table1.row();
      Table table3 = table1;
      object obj2 = (object) Core.bundle.format("trace.ip", (object) info.ip);
      charSequence.__\u003Cref\u003E = (__Null) obj2;
      CharSequence text2 = charSequence;
      table3.add(text2);
      table1.row();
      Table table4 = table1;
      object obj3 = (object) Core.bundle.format("trace.id", (object) info.uuid);
      charSequence.__\u003Cref\u003E = (__Null) obj3;
      CharSequence text3 = charSequence;
      table4.add(text3);
      table1.row();
      Table table5 = table1;
      object obj4 = (object) Core.bundle.format("trace.modclient", (object) Boolean.valueOf(info.modded));
      charSequence.__\u003Cref\u003E = (__Null) obj4;
      CharSequence text4 = charSequence;
      table5.add(text4);
      table1.row();
      Table table6 = table1;
      object obj5 = (object) Core.bundle.format("trace.mobile", (object) Boolean.valueOf(info.mobile));
      charSequence.__\u003Cref\u003E = (__Null) obj5;
      CharSequence text5 = charSequence;
      table6.add(text5);
      table1.row();
      Table table7 = table1;
      object obj6 = (object) Core.bundle.format("trace.times.joined", (object) Integer.valueOf(info.timesJoined));
      charSequence.__\u003Cref\u003E = (__Null) obj6;
      CharSequence text6 = charSequence;
      table7.add(text6);
      table1.row();
      Table table8 = table1;
      object obj7 = (object) Core.bundle.format("trace.times.kicked", (object) Integer.valueOf(info.timesKicked));
      charSequence.__\u003Cref\u003E = (__Null) obj7;
      CharSequence text7 = charSequence;
      table8.add(text7);
      table1.row();
      table1.add().pad(5f);
      table1.row();
      this.__\u003C\u003Econt.add((Element) table1);
      this.show();
    }

    [LineNumberTable(new byte[] {159, 153, 141, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TraceDialog()
      : base("@trace")
    {
      TraceDialog traceDialog = this;
      this.addCloseButton();
      this.setFillParent(false);
    }

    [HideFromJava]
    static TraceDialog() => BaseDialog.__\u003Cclinit\u003E();
  }
}
