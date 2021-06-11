// Decompiled with JetBrains decompiler
// Type: rhino.UniqueTag
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public sealed class UniqueTag : Object
  {
    private const int ID_NOT_FOUND = 1;
    private const int ID_NULL_VALUE = 2;
    private const int ID_DOUBLE_MARK = 3;
    internal static UniqueTag __\u003C\u003ENOT_FOUND;
    internal static UniqueTag __\u003C\u003ENULL_VALUE;
    internal static UniqueTag __\u003C\u003EDOUBLE_MARK;
    [Modifiers]
    private int tagId;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 180, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private UniqueTag([In] int obj0)
    {
      UniqueTag uniqueTag = this;
      this.tagId = obj0;
    }

    [LineNumberTable(new byte[] {159, 185, 155, 134, 134, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readResolve()
    {
      switch (this.tagId)
      {
        case 1:
          return (object) UniqueTag.__\u003C\u003ENOT_FOUND;
        case 2:
          return (object) UniqueTag.__\u003C\u003ENULL_VALUE;
        case 3:
          return (object) UniqueTag.__\u003C\u003EDOUBLE_MARK;
        default:
          string str = String.valueOf(this.tagId);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
      }
    }

    [LineNumberTable(new byte[] {8, 155, 102, 130, 102, 130, 102, 130, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      string str;
      switch (this.tagId)
      {
        case 1:
          str = "NOT_FOUND";
          break;
        case 2:
          str = "NULL_VALUE";
          break;
        case 3:
          str = "DOUBLE_MARK";
          break;
        default:
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      }
      return new StringBuilder().append(base.toString()).append(": ").append(str).toString();
    }

    [LineNumberTable(new byte[] {159, 137, 109, 235, 70, 235, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static UniqueTag()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.UniqueTag"))
        return;
      UniqueTag.__\u003C\u003ENOT_FOUND = new UniqueTag(1);
      UniqueTag.__\u003C\u003ENULL_VALUE = new UniqueTag(2);
      UniqueTag.__\u003C\u003EDOUBLE_MARK = new UniqueTag(3);
    }

    [Modifiers]
    public static UniqueTag NOT_FOUND
    {
      [HideFromJava] get => UniqueTag.__\u003C\u003ENOT_FOUND;
    }

    [Modifiers]
    public static UniqueTag NULL_VALUE
    {
      [HideFromJava] get => UniqueTag.__\u003C\u003ENULL_VALUE;
    }

    [Modifiers]
    public static UniqueTag DOUBLE_MARK
    {
      [HideFromJava] get => UniqueTag.__\u003C\u003EDOUBLE_MARK;
    }
  }
}
