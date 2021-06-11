// Decompiled with JetBrains decompiler
// Type: mindustry.ctype.Content
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.files;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.mod;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ctype
{
  [Signature("Ljava/lang/Object;Ljava/lang/Comparable<Lmindustry/ctype/Content;>;Larc/util/Disposable;")]
  [Implements(new string[] {"java.lang.Comparable", "arc.util.Disposable"})]
  public abstract class Content : Object, Comparable, Disposable
  {
    internal short __\u003C\u003Eid;
    public Content.ModContentInfo minfo;

    public abstract ContentType getContentType();

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(Content c) => Integer.compare((int) this.__\u003C\u003Eid, (int) c.__\u003C\u003Eid);

    [LineNumberTable(new byte[] {159, 156, 8, 171, 124, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Content()
    {
      Content content = this;
      this.minfo = new Content.ModContentInfo();
      this.__\u003C\u003Eid = (short) Vars.content.getBy(this.getContentType()).size;
      Vars.content.handleContent(this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
    }

    [LineNumberTable(36)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasErrored() => this.minfo.error != null;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
    }

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(this.getContentType().name()).append("#").append((int) this.__\u003C\u003Eid).toString();

    [Modifiers]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int compareTo(object obj) => this.compareTo((Content) obj);

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    int IComparable.__\u003Coverridestub\u003Ejava\u002Elang\u002EComparable\u003A\u003AcompareTo(
      [In] object obj0)
    {
      return this.compareTo(obj0);
    }

    [Modifiers]
    public short id
    {
      [HideFromJava] get => this.__\u003C\u003Eid;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eid = value;
    }

    public class ModContentInfo : Object
    {
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Mods.LoadedMod mod;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Fi sourceFile;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public string error;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Exception baseError;

      [LineNumberTable(54)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public ModContentInfo()
      {
      }
    }
  }
}
