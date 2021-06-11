// Decompiled with JetBrains decompiler
// Type: rhino.ScriptStackElement
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public sealed class ScriptStackElement : Object
  {
    internal string __\u003C\u003EfileName;
    internal string __\u003C\u003EfunctionName;
    internal int __\u003C\u003ElineNumber;

    [LineNumberTable(new byte[] {159, 191, 104, 151, 116, 105, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderMozillaStyle(StringBuilder sb)
    {
      if (this.__\u003C\u003EfunctionName != null)
        sb.append(this.__\u003C\u003EfunctionName).append("()");
      sb.append('@').append(this.__\u003C\u003EfileName);
      if (this.__\u003C\u003ElineNumber <= -1)
        return;
      sb.append(':').append(this.__\u003C\u003ElineNumber);
    }

    [LineNumberTable(new byte[] {16, 140, 127, 6, 135, 169, 119, 103, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderV8Style(StringBuilder sb)
    {
      sb.append("    at ");
      if (this.__\u003C\u003EfunctionName == null || String.instancehelper_equals("anonymous", (object) this.__\u003C\u003EfunctionName) || String.instancehelper_equals("undefined", (object) this.__\u003C\u003EfunctionName))
      {
        this.appendV8Location(sb);
      }
      else
      {
        sb.append(this.__\u003C\u003EfunctionName).append(" (");
        this.appendV8Location(sb);
        sb.append(')');
      }
    }

    [LineNumberTable(new byte[] {159, 176, 119, 105, 148, 104, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void renderJavaStyle(StringBuilder sb)
    {
      sb.append("\tat ").append(this.__\u003C\u003EfileName);
      if (this.__\u003C\u003ElineNumber > -1)
        sb.append(':').append(this.__\u003C\u003ElineNumber);
      if (this.__\u003C\u003EfunctionName == null)
        return;
      sb.append(" (").append(this.__\u003C\u003EfunctionName).append(')');
    }

    [LineNumberTable(new byte[] {159, 157, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ScriptStackElement(string fileName, string functionName, int lineNumber)
    {
      ScriptStackElement scriptStackElement = this;
      this.__\u003C\u003EfileName = fileName;
      this.__\u003C\u003EfunctionName = functionName;
      this.__\u003C\u003ElineNumber = lineNumber;
    }

    [LineNumberTable(new byte[] {159, 165, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString()
    {
      StringBuilder sb = new StringBuilder();
      this.renderMozillaStyle(sb);
      return sb.toString();
    }

    [LineNumberTable(new byte[] {31, 116, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void appendV8Location([In] StringBuilder obj0)
    {
      obj0.append(this.__\u003C\u003EfileName).append(':');
      obj0.append(this.__\u003C\u003ElineNumber <= -1 ? 0 : this.__\u003C\u003ElineNumber).append(":0");
    }

    [Modifiers]
    public string fileName
    {
      [HideFromJava] get => this.__\u003C\u003EfileName;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EfileName = value;
    }

    [Modifiers]
    public string functionName
    {
      [HideFromJava] get => this.__\u003C\u003EfunctionName;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EfunctionName = value;
    }

    [Modifiers]
    public int lineNumber
    {
      [HideFromJava] get => this.__\u003C\u003ElineNumber;
      [HideFromJava] [param: In] private set => this.__\u003C\u003ElineNumber = value;
    }
  }
}
