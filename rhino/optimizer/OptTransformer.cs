// Decompiled with JetBrains decompiler
// Type: rhino.optimizer.OptTransformer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using rhino.ast;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.optimizer
{
  internal class OptTransformer : NodeTransformer
  {
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;Lrhino/optimizer/OptFunctionNode;>;")]
    private Map possibleDirectCalls;
    [Modifiers]
    private ObjArray directCallTargets;

    [Signature("(Ljava/util/Map<Ljava/lang/String;Lrhino/optimizer/OptFunctionNode;>;Lrhino/ObjArray;)V")]
    [LineNumberTable(new byte[] {159, 158, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal OptTransformer([In] Map obj0, [In] ObjArray obj1)
    {
      OptTransformer optTransformer = this;
      this.possibleDirectCalls = obj0;
      this.directCallTargets = obj1;
    }

    [LineNumberTable(new byte[] {159, 176, 109, 167, 98, 103, 99, 103, 166, 99, 236, 79, 107, 98, 106, 105, 106, 115, 106, 139, 134, 115, 108, 110, 199, 101, 106, 105, 109, 109, 233, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void detectDirectCall([In] Node obj0, [In] ScriptNode obj1)
    {
      if (obj1.getType() != 110)
        return;
      Node firstChild = obj0.getFirstChild();
      int num1 = 0;
      Node next = firstChild.getNext();
      while (next != null)
      {
        next = next.getNext();
        ++num1;
      }
      if (num1 == 0)
        OptFunctionNode.get(obj1).itsContainsCalls0 = true;
      if (this.possibleDirectCalls == null)
        return;
      string str = (string) null;
      if (firstChild.getType() == 39)
        str = firstChild.getString();
      else if (firstChild.getType() == 33)
        str = firstChild.getFirstChild().getNext().getString();
      else if (firstChild.getType() == 34)
        throw Throwable.__\u003Cunmap\u003E((Exception) Kit.codeBug());
      if (str == null)
        return;
      OptFunctionNode optFunctionNode = (OptFunctionNode) this.possibleDirectCalls.get((object) str);
      if (optFunctionNode == null || num1 != optFunctionNode.__\u003C\u003Efnode.getParamCount() || (optFunctionNode.__\u003C\u003Efnode.requiresActivation() || num1 > 32))
        return;
      obj0.putProp(9, (object) optFunctionNode);
      if (optFunctionNode.isTargetOfDirectCall())
        return;
      int num2 = this.directCallTargets.size();
      this.directCallTargets.add((object) optFunctionNode);
      optFunctionNode.setDirectTargetIndex(num2);
    }

    [LineNumberTable(new byte[] {159, 165, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void visitNew([In] Node obj0, [In] ScriptNode obj1)
    {
      this.detectDirectCall(obj0, obj1);
      base.visitNew(obj0, obj1);
    }

    [LineNumberTable(new byte[] {159, 171, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void visitCall([In] Node obj0, [In] ScriptNode obj1)
    {
      this.detectDirectCall(obj0, obj1);
      base.visitCall(obj0, obj1);
    }
  }
}
