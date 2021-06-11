// Decompiled with JetBrains decompiler
// Type: mindustry.editor.OperationStack
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.editor
{
  public class OperationStack : Object
  {
    private const int maxSize = 10;
    [Signature("Larc/struct/Seq<Lmindustry/editor/DrawOperation;>;")]
    private Seq stack;
    private int index;

    [LineNumberTable(new byte[] {159, 152, 232, 61, 107, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public OperationStack()
    {
      OperationStack operationStack = this;
      this.stack = new Seq();
      this.index = 0;
    }

    [LineNumberTable(new byte[] {159, 157, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.stack.clear();
      this.index = 0;
    }

    [LineNumberTable(30)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canUndo() => this.stack.size - 1 + this.index >= 0;

    [LineNumberTable(new byte[] {159, 180, 137, 127, 10, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void undo()
    {
      if (!this.canUndo())
        return;
      ((DrawOperation) this.stack.get(this.stack.size - 1 + this.index)).undo();
      --this.index;
    }

    [LineNumberTable(34)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool canRedo() => this.index <= -1 && this.stack.size + this.index >= 0;

    [LineNumberTable(new byte[] {159, 187, 137, 110, 159, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void redo()
    {
      if (!this.canRedo())
        return;
      ++this.index;
      ((DrawOperation) this.stack.get(this.stack.size - 1 + this.index)).redo();
    }

    [LineNumberTable(new byte[] {159, 162, 125, 103, 140, 111, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(DrawOperation action)
    {
      this.stack.truncate(this.stack.size + this.index);
      this.index = 0;
      this.stack.add((object) action);
      if (this.stack.size <= 10)
        return;
      this.stack.remove(0);
    }
  }
}
