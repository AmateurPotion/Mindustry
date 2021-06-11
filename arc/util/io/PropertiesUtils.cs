// Decompiled with JetBrains decompiler
// Type: arc.util.io.PropertiesUtils
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.io
{
  public sealed class PropertiesUtils : Object
  {
    private const int NONE = 0;
    private const int SLASH = 1;
    private const int UNICODE = 2;
    private const int CONTINUE = 3;
    private const int KEY_DONE = 4;
    private const int IGNORE = 5;
    private const string LINE_SEPARATOR = "\n";

    [Signature("(Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;Ljava/io/Reader;)V")]
    [LineNumberTable(new byte[] {2, 115, 115, 134, 104, 102, 195, 168, 105, 101, 133, 133, 102, 107, 108, 131, 103, 107, 101, 103, 104, 133, 100, 144, 98, 108, 102, 165, 103, 98, 159, 38, 98, 133, 98, 133, 99, 130, 100, 130, 100, 130, 100, 130, 100, 130, 98, 100, 170, 191, 48, 135, 105, 101, 133, 101, 111, 229, 71, 100, 98, 197, 98, 99, 109, 101, 132, 107, 154, 99, 99, 133, 100, 132, 98, 165, 101, 98, 100, 229, 69, 105, 100, 162, 116, 133, 101, 98, 165, 104, 162, 99, 100, 100, 130, 145, 104, 144, 106, 132, 101, 107, 108, 107, 100, 157, 223, 0, 2, 98, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load(ObjectMap properties, Reader reader)
    {
      if (properties == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("ObjectMap cannot be null");
      }
      if (reader == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException("Reader cannot be null");
      }
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      char[] chArray1 = new char[40];
      int num4 = 0;
      int num5 = -1;
      int num6 = 1;
      IOException ioException1;
      try
      {
        BufferedReader bufferedReader = new BufferedReader(reader);
        while (true)
        {
          int num7;
          do
          {
            int num8 = bufferedReader.read();
            if (num8 != -1)
            {
              num7 = (int) (ushort) num8;
              if (num4 == chArray1.Length)
              {
                char[] chArray2 = new char[chArray1.Length * 2];
                ByteCodeHelper.arraycopy_primitive_2((Array) chArray1, 0, (Array) chArray2, 0, num4);
                chArray1 = chArray2;
              }
              if (num1 == 2)
              {
                int num9 = Character.digit((char) num7, 16);
                if (num9 >= 0)
                {
                  num2 = (num2 << 4) + num9;
                  ++num3;
                  if (num3 < 4)
                    continue;
                }
                else if (num3 <= 4)
                {
                  Throwable.__\u003CsuppressFillInStackTrace\u003E();
                  throw new IllegalArgumentException("Invalid Unicode sequence: illegal character");
                }
                num1 = 0;
                char[] chArray2 = chArray1;
                int index = num4;
                ++num4;
                int num10 = (int) (ushort) num2;
                chArray2[index] = (char) num10;
                if (num7 != 10)
                  continue;
              }
              if (num1 == 1)
              {
                num1 = 0;
                switch (num7)
                {
                  case 10:
                    num1 = 5;
                    continue;
                  case 13:
                    num1 = 3;
                    continue;
                  case 98:
                    num7 = 8;
                    goto label_49;
                  case 102:
                    num7 = 12;
                    goto label_49;
                  case 110:
                    num7 = 10;
                    goto label_49;
                  case 114:
                    num7 = 13;
                    goto label_49;
                  case 116:
                    num7 = 9;
                    goto label_49;
                  case 117:
                    num1 = 2;
                    num2 = num3 = 0;
                    continue;
                  default:
                    goto label_49;
                }
              }
              else
              {
                switch (num7)
                {
                  case 10:
                    if (num1 == 3)
                    {
                      num1 = 5;
                      continue;
                    }
                    goto case 13;
                  case 13:
                    num1 = 0;
                    num6 = 1;
                    if (num4 > 0 || num4 == 0 && num5 == 0)
                    {
                      if (num5 == -1)
                        num5 = num4;
                      string str = String.newhelper(chArray1, 0, num4);
                      properties.put((object) String.instancehelper_substring(str, 0, num5), (object) String.instancehelper_substring(str, num5));
                    }
                    num5 = -1;
                    num4 = 0;
                    continue;
                  case 33:
                  case 35:
                    if (num6 != 0)
                    {
label_29:
                      int num9 = bufferedReader.read();
                      if (num9 != -1)
                      {
                        switch ((ushort) num9)
                        {
                          case 10:
                          case 13:
                            continue;
                          default:
                            goto label_29;
                        }
                      }
                      else
                        continue;
                    }
                    else
                      break;
                  case 58:
                  case 61:
                    if (num5 == -1)
                    {
                      num1 = 0;
                      num5 = num4;
                      continue;
                    }
                    break;
                  case 92:
                    if (num1 == 4)
                      num5 = num4;
                    num1 = 1;
                    continue;
                }
                if (Character.isWhitespace((char) num7))
                {
                  if (num1 == 3)
                    num1 = 5;
                }
                else
                  goto label_47;
              }
            }
            else
              goto label_52;
          }
          while (num4 == 0 || num4 == num5 || num1 == 5);
          if (num5 == -1)
          {
            num1 = 4;
            continue;
          }
label_47:
          if (num1 == 5 || num1 == 3)
            num1 = 0;
label_49:
          num6 = 0;
          if (num1 == 4)
          {
            num5 = num4;
            num1 = 0;
          }
          char[] chArray3 = chArray1;
          int index1 = num4;
          ++num4;
          int num11 = num7;
          chArray3[index1] = (char) num11;
        }
label_52:
        if (num1 == 2 && num3 <= 4)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Invalid Unicode sequence: expected format \\uxxxx");
        }
        if (num5 == -1 && num4 > 0)
          num5 = num4;
        if (num5 < 0)
          return;
        string str1 = String.newhelper(chArray1, 0, num4);
        string str2 = String.instancehelper_substring(str1, 0, num5);
        string str3 = String.instancehelper_substring(str1, num5);
        if (num1 == 1)
          str3 = new StringBuilder().append(str3).append("\0").toString();
        properties.put((object) str2, (object) str3);
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException((Exception) ioException2);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;Ljava/io/Writer;Ljava/lang/String;ZZ)V")]
    [LineNumberTable(new byte[] {159, 81, 69, 99, 135, 99, 107, 112, 171, 107, 127, 5, 116, 105, 116, 107, 108, 103, 101, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void storeImpl([In] ObjectMap obj0, [In] Writer obj1, [In] string obj2, [In] bool obj3, [In] bool obj4)
    {
      int num1 = obj3 ? 1 : 0;
      int num2 = obj4 ? 1 : 0;
      if (obj2 != null)
        PropertiesUtils.writeComment(obj1, obj2);
      if (num1 != 0)
      {
        obj1.write("#");
        obj1.write(new Date().toString());
        obj1.write("\n");
      }
      StringBuilder stringBuilder = new StringBuilder(200);
      ObjectMap.Entries entries = obj0.entries().iterator();
      while (((Iterator) entries).hasNext())
      {
        ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
        PropertiesUtils.dumpString(stringBuilder, (string) entry.key, true, num2 != 0);
        stringBuilder.append('=');
        PropertiesUtils.dumpString(stringBuilder, (string) entry.value, false, num2 != 0);
        obj1.write("\n");
        obj1.write(stringBuilder.toString());
        stringBuilder.setLength(0);
      }
      obj1.flush();
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;Ljava/io/Writer;Ljava/lang/String;Z)V")]
    [LineNumberTable(new byte[] {159, 83, 66, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void store(ObjectMap properties, Writer writer, string comment, bool date)
    {
      int num = date ? 1 : 0;
      PropertiesUtils.storeImpl(properties, writer, comment, false, num != 0);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 203, 107, 103, 98, 98, 103, 104, 117, 114, 104, 104, 107, 112, 40, 168, 104, 101, 107, 120, 132, 127, 1, 139, 132, 100, 101, 114, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void writeComment([In] Writer obj0, [In] string obj1)
    {
      obj0.write("#");
      int num1 = String.instancehelper_length(obj1);
      int num2 = 0;
      int num3 = 0;
      for (; num2 < num1; ++num2)
      {
        int num4 = (int) String.instancehelper_charAt(obj1, num2);
        if (num4 > (int) byte.MaxValue || num4 == 10 || num4 == 13)
        {
          if (num3 != num2)
            obj0.write(String.instancehelper_substring(obj1, num3, num2));
          if (num4 > (int) byte.MaxValue)
          {
            string hexString = Integer.toHexString(num4);
            obj0.write("\\u");
            for (int index = 0; index < 4 - String.instancehelper_length(hexString); ++index)
              obj0.write(48);
            obj0.write(hexString);
          }
          else
          {
            obj0.write("\n");
            if (num4 == 13 && num2 != num1 - 1 && String.instancehelper_charAt(obj1, num2 + 1) == '\n')
              ++num2;
            if (num2 == num1 - 1 || String.instancehelper_charAt(obj1, num2 + 1) != '#' && String.instancehelper_charAt(obj1, num2 + 1) != '!')
              obj0.write("#");
          }
          num3 = num2 + 1;
        }
      }
      if (num3 != num2)
        obj0.write(String.instancehelper_substring(obj1, num3, num2));
      obj0.write("\n");
    }

    [LineNumberTable(new byte[] {159, 76, 132, 103, 105, 137, 108, 123, 133, 159, 73, 102, 145, 137, 133, 108, 133, 108, 133, 108, 133, 108, 229, 69, 112, 133, 116, 105, 108, 112, 41, 168, 105, 98, 233, 22, 233, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void dumpString([In] StringBuilder obj0, [In] string obj1, [In] bool obj2, [In] bool obj3)
    {
      int num1 = obj2 ? 1 : 0;
      int num2 = obj3 ? 1 : 0;
      int num3 = String.instancehelper_length(obj1);
      for (int index1 = 0; index1 < num3; ++index1)
      {
        int num4 = (int) String.instancehelper_charAt(obj1, index1);
        if (num4 > 61 && num4 < (int) sbyte.MaxValue)
        {
          obj0.append(num4 != 92 ? (object) Character.valueOf((char) num4) : (object) (Character) "\\\\");
        }
        else
        {
          switch (num4)
          {
            case 9:
              obj0.append("\\t");
              continue;
            case 10:
              obj0.append("\\n");
              continue;
            case 12:
              obj0.append("\\f");
              continue;
            case 13:
              obj0.append("\\r");
              continue;
            case 32:
              if (index1 == 0 || num1 != 0)
              {
                obj0.append("\\ ");
                continue;
              }
              obj0.append((char) num4);
              continue;
            case 33:
            case 35:
            case 58:
            case 61:
              obj0.append('\\').append((char) num4);
              continue;
            default:
              if (((num4 < 32 || num4 > 126 ? 1 : 0) & num2) != 0)
              {
                string hexString = Integer.toHexString(num4);
                obj0.append("\\u");
                for (int index2 = 0; index2 < 4 - String.instancehelper_length(hexString); ++index2)
                  obj0.append('0');
                obj0.append(hexString);
                continue;
              }
              obj0.append((char) num4);
              continue;
          }
        }
      }
    }

    [LineNumberTable(new byte[] {159, 180, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private PropertiesUtils()
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;Ljava/io/Writer;Ljava/lang/String;)V")]
    [LineNumberTable(new byte[] {160, 126, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void store(ObjectMap properties, Writer writer, string comment) => PropertiesUtils.store(properties, writer, comment, false);
  }
}
