// Decompiled with JetBrains decompiler
// Type: arc.net.InputStreamSender
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;

namespace arc.net
{
  public abstract class InputStreamSender : TcpIdleSender
  {
    [Modifiers]
    private InputStream input;
    [Modifiers]
    private byte[] chunk;

    protected internal abstract object next(byte[] barr);

    [LineNumberTable(new byte[] {159, 154, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public InputStreamSender(InputStream input, int chunkSize)
    {
      InputStreamSender inputStreamSender = this;
      this.input = input;
      this.chunk = new byte[chunkSize];
    }

    [LineNumberTable(new byte[] {159, 162, 98, 109, 124, 100, 99, 100, 103, 111, 138, 100, 187, 2, 98, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override sealed object next()
    {
      IOException ioException1;
      try
      {
        int num;
        for (int length = 0; length < this.chunk.Length; length += num)
        {
          num = this.input.read(this.chunk, length, this.chunk.Length - length);
          if (num < 0)
          {
            if (length == 0)
              return (object) null;
            byte[] barr = new byte[length];
            ByteCodeHelper.arraycopy_primitive_1((Array) this.chunk, 0, (Array) barr, 0, length);
            return this.next(barr);
          }
        }
        goto label_9;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcNetException((Exception) ioException2);
label_9:
      return this.next(this.chunk);
    }
  }
}
