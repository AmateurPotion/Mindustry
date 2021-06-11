// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SDLError
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.backend.sdl.jni;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.backend.sdl
{
  public class SDLError : RuntimeException
  {
    [LineNumberTable(new byte[] {159, 149, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SDLError()
      : base(SDL.SDL_GetError())
    {
    }
  }
}
