// Decompiled with JetBrains decompiler
// Type: rhino.module.provider.ParsedContentType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;

namespace rhino.module.provider
{
  public sealed class ParsedContentType : Object
  {
    [Modifiers]
    private string contentType;
    [Modifiers]
    private string encoding;

    [LineNumberTable(new byte[] {159, 162, 104, 98, 98, 102, 108, 107, 108, 107, 109, 110, 110, 104, 101, 107, 136, 110, 238, 69, 165, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ParsedContentType(string mimeType)
    {
      ParsedContentType parsedContentType = this;
      string str1 = (string) null;
      string str2 = (string) null;
      if (mimeType != null)
      {
        StringTokenizer stringTokenizer = new StringTokenizer(mimeType, ";");
        if (stringTokenizer.hasMoreTokens())
        {
          str1 = String.instancehelper_trim(stringTokenizer.nextToken());
          while (stringTokenizer.hasMoreTokens())
          {
            string str3 = String.instancehelper_trim(stringTokenizer.nextToken());
            if (String.instancehelper_startsWith(str3, "charset="))
            {
              str2 = String.instancehelper_trim(String.instancehelper_substring(str3, 8));
              int num = String.instancehelper_length(str2);
              if (num > 0)
              {
                if (String.instancehelper_charAt(str2, 0) == '"')
                  str2 = String.instancehelper_substring(str2, 1);
                if (String.instancehelper_charAt(str2, num - 1) == '"')
                {
                  str2 = String.instancehelper_substring(str2, 0, num - 1);
                  break;
                }
                break;
              }
              break;
            }
          }
        }
      }
      this.contentType = str1;
      this.encoding = str2;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getEncoding() => this.encoding;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getContentType() => this.contentType;
  }
}
