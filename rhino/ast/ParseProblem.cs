// Decompiled with JetBrains decompiler
// Type: rhino.ast.ParseProblem
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.ast
{
  public class ParseProblem : Object
  {
    private ParseProblem.Type type;
    private string message;
    private string sourceName;
    private int offset;
    private int length;

    [LineNumberTable(new byte[] {159, 162, 104, 103, 103, 103, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParseProblem(
      ParseProblem.Type type,
      string message,
      string sourceName,
      int offset,
      int length)
    {
      ParseProblem parseProblem = this;
      this.setType(type);
      this.setMessage(message);
      this.setSourceName(sourceName);
      this.setFileOffset(offset);
      this.setLength(length);
    }

    [LineNumberTable(new byte[] {20, 255, 89, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append(this.sourceName).append(":offset=").append(this.offset).append(",length=").append(this.length).append(",").append(!object.ReferenceEquals((object) this.type, (object) ParseProblem.Type.__\u003C\u003EError) ? "warning: " : "error: ").append(this.message).toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setType(ParseProblem.Type type) => this.type = type;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setMessage(string msg) => this.message = msg;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSourceName(string name) => this.sourceName = name;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setFileOffset(int offset) => this.offset = offset;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setLength(int length) => this.length = length;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ParseProblem.Type getType() => this.type;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getMessage() => this.message;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getSourceName() => this.sourceName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getFileOffset() => this.offset;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getLength() => this.length;

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lrhino/ast/ParseProblem$Type;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Type : Enum
    {
      [Modifiers]
      internal static ParseProblem.Type __\u003C\u003EError;
      [Modifiers]
      internal static ParseProblem.Type __\u003C\u003EWarning;
      [Modifiers]
      private static ParseProblem.Type[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(8)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Type([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(8)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static ParseProblem.Type[] values() => (ParseProblem.Type[]) ParseProblem.Type.\u0024VALUES.Clone();

      [LineNumberTable(8)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static ParseProblem.Type valueOf(string name) => (ParseProblem.Type) Enum.valueOf((Class) ClassLiteral<ParseProblem.Type>.Value, name);

      [LineNumberTable(8)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Type()
      {
        if (ByteCodeHelper.isAlreadyInited("rhino.ast.ParseProblem$Type"))
          return;
        ParseProblem.Type.__\u003C\u003EError = new ParseProblem.Type(nameof (Error), 0);
        ParseProblem.Type.__\u003C\u003EWarning = new ParseProblem.Type(nameof (Warning), 1);
        ParseProblem.Type.\u0024VALUES = new ParseProblem.Type[2]
        {
          ParseProblem.Type.__\u003C\u003EError,
          ParseProblem.Type.__\u003C\u003EWarning
        };
      }

      [Modifiers]
      public static ParseProblem.Type Error
      {
        [HideFromJava] get => ParseProblem.Type.__\u003C\u003EError;
      }

      [Modifiers]
      public static ParseProblem.Type Warning
      {
        [HideFromJava] get => ParseProblem.Type.__\u003C\u003EWarning;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        Error,
        Warning,
      }
    }
  }
}
