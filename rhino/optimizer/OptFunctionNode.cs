// Decompiled with JetBrains decompiler
// Type: rhino.optimizer.OptFunctionNode
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using rhino.ast;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.optimizer
{
  public sealed class OptFunctionNode : Object
  {
    internal FunctionNode __\u003C\u003Efnode;
    private bool[] numberVarFlags;
    private int directTargetIndex;
    private bool itsParameterNumberContext;
    internal bool itsContainsCalls0;
    internal bool itsContainsCalls1;

    [LineNumberTable(new byte[] {11, 143, 106, 104, 120, 140, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setIsNumberVar([In] int obj0)
    {
      obj0 -= this.__\u003C\u003Efnode.getParamCount();
      if (obj0 < 0)
        Kit.codeBug();
      if (this.numberVarFlags == null)
        this.numberVarFlags = new bool[this.__\u003C\u003Efnode.getParamAndVarCount() - this.__\u003C\u003Efnode.getParamCount()];
      this.numberVarFlags[obj0] = true;
    }

    [LineNumberTable(new byte[] {22, 105, 135, 103, 101, 100, 141, 137, 139, 109, 111, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getVarIndex(Node n)
    {
      int prop = n.getIntProp(7, -1);
      if (prop == -1)
      {
        Node nameNode;
        switch (n.getType())
        {
          case 55:
            nameNode = n;
            break;
          case 56:
          case 157:
            nameNode = n.getFirstChild();
            break;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        }
        prop = this.__\u003C\u003Efnode.getIndexForNameNode(nameNode);
        if (prop < 0)
          throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
        n.putIntProp(7, prop);
      }
      return prop;
    }

    [LineNumberTable(45)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getVarCount() => this.__\u003C\u003Efnode.getParamAndVarCount();

    [LineNumberTable(new byte[] {159, 155, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static OptFunctionNode get(ScriptNode scriptOrFn, int i) => (OptFunctionNode) scriptOrFn.getFunctionNode(i).getCompilerData();

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static OptFunctionNode get(ScriptNode scriptOrFn) => (OptFunctionNode) scriptOrFn.getCompilerData();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTargetOfDirectCall() => this.directTargetIndex >= 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getParameterNumberContext() => this.itsParameterNumberContext;

    [LineNumberTable(new byte[] {3, 111, 108, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isNumberVar(int varIndex)
    {
      varIndex -= this.__\u003C\u003Efnode.getParamCount();
      return varIndex >= 0 && this.numberVarFlags != null && this.numberVarFlags[varIndex];
    }

    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isParameter(int varIndex) => varIndex < this.__\u003C\u003Efnode.getParamCount();

    [LineNumberTable(new byte[] {159, 149, 232, 160, 87, 231, 159, 170, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal OptFunctionNode([In] FunctionNode obj0)
    {
      OptFunctionNode optFunctionNode = this;
      this.directTargetIndex = -1;
      this.__\u003C\u003Efnode = obj0;
      obj0.setCompilerData((object) this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getDirectTargetIndex() => this.directTargetIndex;

    [LineNumberTable(new byte[] {159, 173, 109, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setDirectTargetIndex([In] int obj0)
    {
      if (obj0 < 0 || this.directTargetIndex >= 0)
        Kit.codeBug();
      this.directTargetIndex = obj0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setParameterNumberContext([In] bool obj0) => this.itsParameterNumberContext = obj0;

    [Modifiers]
    public FunctionNode fnode
    {
      [HideFromJava] get => this.__\u003C\u003Efnode;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Efnode = value;
    }
  }
}
