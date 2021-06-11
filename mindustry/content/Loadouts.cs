// Decompiled with JetBrains decompiler
// Type: mindustry.content.Loadouts
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.game;
using System.Runtime.CompilerServices;

namespace mindustry.content
{
  public class Loadouts : Object, ContentList
  {
    public static Schematic basicShard;
    public static Schematic basicFoundation;
    public static Schematic basicNucleus;

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Loadouts()
    {
    }

    [LineNumberTable(new byte[] {159, 156, 111, 111, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      Loadouts.basicShard = Schematics.readBase64("bXNjaAB4nD2K2wqAIBiD5ymibnoRn6YnEP1BwUMoBL19FuJ2sbFvUFgYZDaJsLeQrkinN9UJHImsNzlYE7WrIUastuSbnlKx2VJJt+8IQGGKdfO/8J5yrGJSMegLg+YUIA==");
      Loadouts.basicFoundation = Schematics.readBase64("bXNjaAB4nD1OSQ6DMBBzFhVu8BG+0X8MQyoiJTNSukj8nlCi2Adbtg/GA4OBF8oB00rvyE/9ykafqOIw58A7SWRKy1ZiShhZ5RcOLZhYS1hefQ1gRIeptH9jq/qW2lvc1d2tgWsOfVX/tOwE86AYBA==");
      Loadouts.basicNucleus = Schematics.readBase64("bXNjaAB4nD2MUQqAIBBEJy0s6qOLdJXuYNtCgikYBd2+LNmdj308hkGHtkId7M4YFns4mk/yfB4a48602eDI+mlNznu0FMPFd0wYKCaewl8F0EOueqM+yKSLVfJrNKWnSw/FZGzEGXFG9sy/px4gEBW1");
    }
  }
}
