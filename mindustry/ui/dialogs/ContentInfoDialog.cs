// Decompiled with JetBrains decompiler
// Type: mindustry.ui.dialogs.ContentInfoDialog
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.scene;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.ctype;
using mindustry.graphics;
using mindustry.world.meta;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui.dialogs
{
  public class ContentInfoDialog : BaseDialog
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 141, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContentInfoDialog()
      : base("@info.title")
    {
      ContentInfoDialog contentInfoDialog = this;
      this.addCloseButton();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 171, 135, 127, 5, 127, 33})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u00240([In] UnlockableContent obj0, [In] Table obj1)
    {
      Cicon icon = obj0.prefDatabaseIcon();
      obj1.image(obj0.icon(icon)).size((float) icon.__\u003C\u003Esize).scaling(Scaling.__\u003C\u003Efit);
      Table table = obj1;
      object obj = (object) new StringBuilder().append("[accent]").append(obj0.localizedName).toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).padLeft(5f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {19, 103, 127, 38, 109, 124, 104, 113, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024show\u00241([In] Stat obj0, [In] OrderedMap obj1, [In] Table obj2)
    {
      obj2.left();
      Table table = obj2;
      object obj = (object) new StringBuilder().append("[lightgray]").append(obj0.localized()).append(":[] ").toString();
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      table.add(text).left();
      Iterator iterator = ((Seq) obj1.get((object) obj0)).iterator();
      while (iterator.hasNext())
      {
        ((StatValue) iterator.next()).display(obj2);
        obj2.add().size(10f);
      }
    }

    [LineNumberTable(new byte[] {159, 162, 139, 102, 172, 134, 242, 71, 135, 107, 148, 99, 127, 22, 167, 127, 88, 135, 112, 127, 12, 199, 136, 127, 14, 149, 171, 105, 127, 39, 167, 127, 6, 244, 73, 112, 103, 98, 133, 104, 127, 63, 167, 104, 142, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void show(UnlockableContent content)
    {
      this.__\u003C\u003Econt.clear();
      Table table1 = new Table();
      table1.margin(10f);
      content.checkStats();
      table1.table((Cons) new ContentInfoDialog.__\u003C\u003EAnon0(content));
      table1.row();
      CharSequence charSequence;
      if (content.description != null)
      {
        int num = content.stats.toMap().size > 0 ? 1 : 0;
        if (num != 0)
        {
          Table table2 = table1;
          object obj = (object) "@category.purpose";
          charSequence.__\u003Cref\u003E = (__Null) obj;
          CharSequence text = charSequence;
          table2.add(text).color(Pal.accent).fillX().padTop(10f);
          table1.row();
        }
        Table table3 = table1;
        object obj1 = (object) new StringBuilder().append("[lightgray]").append(content.displayDescription()).toString();
        charSequence.__\u003Cref\u003E = (__Null) obj1;
        CharSequence text1 = charSequence;
        table3.add(text1).wrap().fillX().padLeft(num == 0 ? 0.0f : 10f).width(500f).padTop(num == 0 ? 10f : 0.0f).left();
        table1.row();
        if (!content.stats.useCategories && num != 0)
        {
          Table table2 = table1;
          object obj2 = (object) "@category.general";
          charSequence.__\u003Cref\u003E = (__Null) obj2;
          CharSequence text2 = charSequence;
          table2.add(text2).fillX().color(Pal.accent);
          table1.row();
        }
      }
      Stats stats = content.stats;
      ObjectMap.Keys keys1 = stats.toMap().keys().iterator();
label_6:
      while (((Iterator) keys1).hasNext())
      {
        StatCat statCat = (StatCat) ((Iterator) keys1).next();
        OrderedMap orderedMap = (OrderedMap) stats.toMap().get((object) statCat);
        if (orderedMap.size != 0)
        {
          if (stats.useCategories)
          {
            Table table2 = table1;
            object obj = (object) new StringBuilder().append("@category.").append(statCat.name()).toString();
            charSequence.__\u003Cref\u003E = (__Null) obj;
            CharSequence text = charSequence;
            table2.add(text).color(Pal.accent).fillX();
            table1.row();
          }
          ObjectMap.Keys keys2 = orderedMap.keys().iterator();
          while (true)
          {
            if (((Iterator) keys2).hasNext())
            {
              Stat stat = (Stat) ((Iterator) keys2).next();
              table1.table((Cons) new ContentInfoDialog.__\u003C\u003EAnon1(stat, orderedMap)).fillX().padLeft(10f);
              table1.row();
            }
            else
              goto label_6;
          }
        }
      }
      if (content.details != null)
      {
        Table table2 = table1;
        object obj = (object) new StringBuilder().append("[gray]").append(content.details).toString();
        charSequence.__\u003Cref\u003E = (__Null) obj;
        CharSequence text = charSequence;
        table2.add(text).pad(6f).padTop(20f).width(400f).wrap().fillX();
        table1.row();
      }
      this.__\u003C\u003Econt.add((Element) new ScrollPane((Element) table1));
      this.show();
    }

    [HideFromJava]
    static ContentInfoDialog() => BaseDialog.__\u003Cclinit\u003E();

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly UnlockableContent arg\u00241;

      internal __\u003C\u003EAnon0([In] UnlockableContent obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ContentInfoDialog.lambda\u0024show\u00240(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Stat arg\u00241;
      private readonly OrderedMap arg\u00242;

      internal __\u003C\u003EAnon1([In] Stat obj0, [In] OrderedMap obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => ContentInfoDialog.lambda\u0024show\u00241(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }
  }
}
