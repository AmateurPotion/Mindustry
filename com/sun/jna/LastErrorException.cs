// Decompiled with JetBrains decompiler
// Type: com.sun.jna.LastErrorException
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class LastErrorException : RuntimeException
  {
    private const long serialVersionUID = 1;
    private int errorCode;

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string formatMessage([In] int obj0) => Platform.isWindows() ? new StringBuilder().append("GetLastError() returned ").append(obj0).toString() : new StringBuilder().append("errno was ").append(obj0).toString();

    [LineNumberTable(new byte[] {159, 186, 122, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string parseMessage([In] string obj0)
    {
      string str;
      try
      {
        str = LastErrorException.formatMessage(Integer.parseInt(obj0));
      }
      catch (NumberFormatException ex)
      {
        goto label_3;
      }
      return str;
label_3:
      return obj0;
    }

    [LineNumberTable(new byte[] {24, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal LastErrorException(int code, string msg)
      : base(msg)
    {
      LastErrorException lastErrorException = this;
      this.errorCode = code;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getErrorCode() => this.errorCode;

    [LineNumberTable(new byte[] {8, 147, 109, 148, 183, 2, 97, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LastErrorException(string msg)
      : base(LastErrorException.parseMessage(String.instancehelper_trim(msg)))
    {
      LastErrorException lastErrorException = this;
      try
      {
        if (String.instancehelper_startsWith(msg, "["))
          msg = String.instancehelper_substring(msg, 1, String.instancehelper_indexOf(msg, "]"));
        this.errorCode = Integer.parseInt(msg);
        return;
      }
      catch (NumberFormatException ex)
      {
      }
      this.errorCode = -1;
    }

    [LineNumberTable(new byte[] {20, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LastErrorException(int code)
      : this(code, LastErrorException.formatMessage(code))
    {
    }
  }
}
