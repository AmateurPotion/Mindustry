// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.SerializationException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.serialization
{
  public class SerializationException : RuntimeException
  {
    private StringBuilder trace;

    [LineNumberTable(new byte[] {159, 161, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SerializationException(string message)
      : base(message)
    {
    }

    [LineNumberTable(new byte[] {159, 157, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SerializationException(string message, Exception cause)
      : base(message, cause)
    {
    }

    [LineNumberTable(new byte[] {3, 115, 120, 110, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addTrace(string info)
    {
      if (info == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("info cannot be null.");
      }
      if (this.trace == null)
        this.trace = new StringBuilder(512);
      this.trace.append('\n');
      this.trace.append(info);
    }

    [LineNumberTable(new byte[] {159, 165, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SerializationException(Exception cause)
      : base("", cause)
    {
    }

    [Signature("(Ljava/lang/Throwable;Ljava/lang/Class<*>;)Z")]
    [LineNumberTable(new byte[] {159, 174, 103, 110, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool causedBy([In] Exception obj0, [In] Class obj1)
    {
      Exception cause = Throwable.instancehelper_getCause(obj0);
      if (cause == null || object.ReferenceEquals((object) cause, (object) obj0))
        return false;
      return obj1.isAssignableFrom(Object.instancehelper_getClass((object) cause)) || this.causedBy(cause, obj1);
    }

    [LineNumberTable(new byte[] {159, 153, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SerializationException()
    {
    }

    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool causedBy(Class type) => this.causedBy((Exception) this, type);

    [LineNumberTable(new byte[] {159, 181, 111, 107, 109, 114, 108, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getMessage()
    {
      if (this.trace == null)
        return ((Throwable) this).getMessage();
      StringBuilder stringBuilder1 = new StringBuilder(512);
      stringBuilder1.append(((Throwable) this).getMessage());
      if (stringBuilder1.length() > 0)
        stringBuilder1.append('\n');
      stringBuilder1.append("Serialization trace:");
      StringBuilder stringBuilder2 = stringBuilder1;
      object trace = (object) this.trace;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) trace;
      CharSequence charSequence2 = charSequence1;
      stringBuilder2.append(charSequence2);
      return stringBuilder1.toString();
    }
  }
}
