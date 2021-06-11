// Decompiled with JetBrains decompiler
// Type: arc.mock.MockInput
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace arc.mock
{
  public class MockInput : Input
  {
    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public MockInput()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int mouseX() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int mouseX(int pointer) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int deltaX() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int deltaX(int pointer) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int mouseY() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int mouseY(int pointer) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int deltaY() => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int deltaY(int pointer) => 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isTouched() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool justTouched() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isTouched(int pointer) => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long getCurrentEventTime() => 0;
  }
}
