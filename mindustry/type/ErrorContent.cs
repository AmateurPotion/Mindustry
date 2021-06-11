// Decompiled with JetBrains decompiler
// Type: mindustry.type.ErrorContent
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using mindustry.ctype;
using System.Runtime.CompilerServices;

namespace mindustry.type
{
  public class ErrorContent : Content
  {
    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ErrorContent()
    {
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override ContentType getContentType() => ContentType.__\u003C\u003Eerror;
  }
}
