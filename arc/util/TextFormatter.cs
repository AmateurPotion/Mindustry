// Decompiled with JetBrains decompiler
// Type: arc.util.TextFormatter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.text;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  internal class TextFormatter : Object
  {
    private MessageFormat messageFormat;
    private StringBuilder buffer;

    [LineNumberTable(new byte[] {159, 139, 162, 104, 107, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public TextFormatter([In] Locale obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      TextFormatter textFormatter = this;
      this.buffer = new StringBuilder();
      if (num == 0)
        return;
      this.messageFormat = new MessageFormat("", obj0);
    }

    [LineNumberTable(new byte[] {159, 188, 104, 114, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string format(string _param1, params object[] _param2)
    {
      if (this.messageFormat == null)
        return this.simpleFormat(_param1, _param2);
      this.messageFormat.applyPattern(this.replaceEscapeChars(_param1));
      return ((Format) this.messageFormat).format((object) _param2);
    }

    [LineNumberTable(new byte[] {9, 108, 98, 103, 105, 104, 101, 98, 118, 104, 101, 113, 104, 104, 101, 98, 142, 110, 107, 142, 127, 0, 101, 98, 237, 43, 233, 88})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string replaceEscapeChars([In] string obj0)
    {
      this.buffer.setLength(0);
      int num1 = 0;
      int num2 = String.instancehelper_length(obj0);
      for (int index = 0; index < num2; ++index)
      {
        int num3 = (int) String.instancehelper_charAt(obj0, index);
        switch (num3)
        {
          case 39:
            num1 = 1;
            this.buffer.append("''");
            break;
          case 123:
            int num4 = index + 1;
            while (num4 < num2 && String.instancehelper_charAt(obj0, num4) == '{')
              ++num4;
            int num5 = (num4 - index) / 2;
            if (num5 > 0)
            {
              num1 = 1;
              this.buffer.append('\'');
              do
              {
                this.buffer.append('{');
                num5 += -1;
              }
              while (num5 > 0);
              this.buffer.append('\'');
            }
            int num6 = num4 - index;
            int num7 = 2;
            if ((num7 != -1 ? num6 % num7 : 0) != 0)
              this.buffer.append('{');
            index = num4 - 1;
            break;
          default:
            this.buffer.append((char) num3);
            break;
        }
      }
      return num1 != 0 ? this.buffer.toString() : obj0;
    }

    [LineNumberTable(new byte[] {53, 108, 98, 98, 103, 105, 105, 100, 102, 98, 115, 110, 137, 167, 179, 105, 101, 127, 6, 109, 112, 101, 147, 116, 132, 108, 127, 17, 235, 36, 233, 96, 148})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string simpleFormat(string _param1, params object[] _param2)
    {
      this.buffer.setLength(0);
      int num1 = 0;
      int index1 = -1;
      int num2 = String.instancehelper_length(_param1);
      for (int index2 = 0; index2 < num2; ++index2)
      {
        int num3 = (int) String.instancehelper_charAt(_param1, index2);
        if (index1 < 0)
        {
          if (num3 == 123)
          {
            num1 = 1;
            if (index2 + 1 < num2 && String.instancehelper_charAt(_param1, index2 + 1) == '{')
            {
              this.buffer.append((char) num3);
              ++index2;
            }
            else
              index1 = 0;
          }
          else
            this.buffer.append((char) num3);
        }
        else if (num3 == 125)
        {
          if (index1 >= _param2.Length)
          {
            string str = new StringBuilder().append("Argument index out of bounds: ").append(index1).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
          }
          if (String.instancehelper_charAt(_param1, index2 - 1) == '{')
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("Missing argument index after a left curly brace");
          }
          if (_param2[index1] == null)
            this.buffer.append("null");
          else
            this.buffer.append(Object.instancehelper_toString(_param2[index1]));
          index1 = -1;
        }
        else
        {
          if (num3 < 48 || num3 > 57)
          {
            string str = new StringBuilder().append("Unexpected '").append((char) num3).append("' while parsing argument index").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
          }
          index1 = index1 * 10 + (num3 - 48);
        }
      }
      if (index1 >= 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Unmatched braces in the pattern.");
      }
      return num1 != 0 ? this.buffer.toString() : _param1;
    }
  }
}
