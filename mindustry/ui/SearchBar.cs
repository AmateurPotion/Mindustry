// Decompiled with JetBrains decompiler
// Type: mindustry.ui.SearchBar
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.scene.style;
using arc.scene.ui.layout;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class SearchBar : Object
  {
    [Signature("<T:Ljava/lang/Object;>(Larc/scene/ui/layout/Table;Larc/struct/Seq<TT;>;Larc/func/Func<Ljava/lang/String;Ljava/lang/String;>;Larc/func/Func<TT;Ljava/lang/String;>;Larc/func/Cons2<Larc/scene/ui/layout/Table;TT;>;Z)Larc/scene/ui/layout/Table;")]
    [LineNumberTable(new byte[] {159, 139, 99, 139, 241, 81, 99, 177, 176, 103, 211})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Table add(
      Table parent,
      Seq list,
      Func queryf,
      Func namef,
      Cons2 itemc,
      bool show)
    {
      int num = show ? 1 : 0;
      Table[] tableArray = new Table[1]{ (Table) null };
      Cons cons = (Cons) new SearchBar.__\u003C\u003EAnon0(queryf, tableArray, list, namef, itemc);
      if (num != 0)
        parent.table((Cons) new SearchBar.__\u003C\u003EAnon1(cons)).fillX().padBottom(4f);
      parent.row();
      parent.pane((Cons) new SearchBar.__\u003C\u003EAnon2(tableArray, cons));
      return tableArray[0];
    }

    [LineNumberTable(new byte[] {7, 107, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool matches(string query, string name)
    {
      if (name == null || String.instancehelper_isEmpty(name))
        return false;
      string lowerCase = String.instancehelper_toLowerCase(name);
      object obj = (object) query;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      return String.instancehelper_contains(lowerCase, charSequence2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 158, 142, 104, 98, 118, 124, 98, 139, 130, 99, 159, 21})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024add\u00240(
      [In] Func obj0,
      [In] Table[] obj1,
      [In] Seq obj2,
      [In] Func obj3,
      [In] Cons2 obj4,
      [In] string obj5)
    {
      string query = (string) obj0.get((object) obj5);
      obj1[0].clear();
      int num = 0;
      Iterator iterator = obj2.iterator();
      while (iterator.hasNext())
      {
        object obj = iterator.next();
        if (String.instancehelper_isEmpty(query) || SearchBar.matches(query, (string) obj3.get(obj)))
        {
          num = 1;
          obj4.get((object) obj1[0], obj);
        }
      }
      if (num != 0)
        return;
      Table table = obj1[0];
      object obj6 = (object) "@none.found";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj6;
      CharSequence text = charSequence;
      table.add(text).color(Color.__\u003C\u003ElightGray).pad(4f);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 176, 118, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024add\u00241([In] Cons obj0, [In] Table obj1)
    {
      obj1.image((Drawable) Icon.zoom).padRight(8f);
      obj1.field("", obj0).growX();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 183, 100, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024add\u00242([In] Table[] obj0, [In] Cons obj1, [In] Table obj2)
    {
      obj0[0] = obj2;
      obj1.get((object) "");
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SearchBar()
    {
    }

    [Signature("<T:Ljava/lang/Object;>(Larc/scene/ui/layout/Table;Larc/struct/Seq<TT;>;Larc/func/Func<Ljava/lang/String;Ljava/lang/String;>;Larc/func/Func<TT;Ljava/lang/String;>;Larc/func/Cons2<Larc/scene/ui/layout/Table;TT;>;)Larc/scene/ui/layout/Table;")]
    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Table add(Table parent, Seq list, Func queryf, Func namef, Cons2 itemc) => SearchBar.add(parent, list, queryf, namef, itemc, true);

    [Signature("<T:Ljava/lang/Object;>(Larc/scene/ui/layout/Table;Larc/struct/Seq<TT;>;Larc/func/Func<TT;Ljava/lang/String;>;Larc/func/Cons2<Larc/scene/ui/layout/Table;TT;>;Z)Larc/scene/ui/layout/Table;")]
    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Table add(Table parent, Seq list, Func namef, Cons2 itemc, bool show)
    {
      int num = show ? 1 : 0;
      return SearchBar.add(parent, list, (Func) new SearchBar.__\u003C\u003EAnon3(), namef, itemc, num != 0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Func arg\u00241;
      private readonly Table[] arg\u00242;
      private readonly Seq arg\u00243;
      private readonly Func arg\u00244;
      private readonly Cons2 arg\u00245;

      internal __\u003C\u003EAnon0([In] Func obj0, [In] Table[] obj1, [In] Seq obj2, [In] Func obj3, [In] Cons2 obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void get([In] object obj0) => SearchBar.lambda\u0024add\u00240(this.arg\u00241, this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245, (string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon1([In] Cons obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => SearchBar.lambda\u0024add\u00241(this.arg\u00241, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly Table[] arg\u00241;
      private readonly Cons arg\u00242;

      internal __\u003C\u003EAnon2([In] Table[] obj0, [In] Cons obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => SearchBar.lambda\u0024add\u00242(this.arg\u00241, this.arg\u00242, (Table) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Func
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get([In] object obj0) => (object) String.instancehelper_toLowerCase((string) obj0);
    }
  }
}
