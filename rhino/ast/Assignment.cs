// Decompiled with JetBrains decompiler
// Type: rhino.ast.Assignment
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using System.Runtime.CompilerServices;

namespace rhino.ast
{
  public class Assignment : InfixExpression
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 172, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Assignment(int @operator, AstNode left, AstNode right, int operatorPos)
      : base(@operator, left, right, operatorPos)
    {
    }

    [LineNumberTable(new byte[] {159, 151, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Assignment()
    {
    }

    [LineNumberTable(new byte[] {159, 155, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Assignment(int pos)
      : base(pos)
    {
    }

    [LineNumberTable(new byte[] {159, 159, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Assignment(int pos, int len)
      : base(pos, len)
    {
    }

    [LineNumberTable(new byte[] {159, 163, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Assignment(int pos, int len, AstNode left, AstNode right)
      : base(pos, len, left, right)
    {
    }

    [LineNumberTable(new byte[] {159, 167, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Assignment(AstNode left, AstNode right)
      : base(left, right)
    {
    }

    [HideFromJava]
    static Assignment() => InfixExpression.__\u003Cclinit\u003E();
  }
}
