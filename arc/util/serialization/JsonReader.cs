// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.JsonReader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.serialization
{
  public class JsonReader : Object, BaseJsonReader
  {
    internal const int json_start = 1;
    internal const int json_first_final = 35;
    internal const int json_error = 0;
    internal const int json_en_object = 5;
    internal const int json_en_array = 23;
    internal const int json_en_main = 1;
    [Modifiers]
    private static byte[] _json_actions;
    [Modifiers]
    private static short[] _json_key_offsets;
    [Modifiers]
    private static char[] _json_trans_keys;
    [Modifiers]
    private static byte[] _json_single_lengths;
    [Modifiers]
    private static byte[] _json_range_lengths;
    [Modifiers]
    private static short[] _json_index_offsets;
    [Modifiers]
    private static byte[] _json_indicies;
    [Modifiers]
    private static byte[] _json_trans_targs;
    [Modifiers]
    private static byte[] _json_trans_actions;
    [Modifiers]
    private static byte[] _json_eof_actions;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/util/serialization/JsonValue;>;")]
    private Seq elements;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/util/serialization/JsonValue;>;")]
    private Seq lastChild;
    private JsonValue root;
    private JsonValue current;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 232, 81, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public JsonReader()
    {
      JsonReader jsonReader = this;
      this.elements = new Seq(8);
      this.lastChild = new Seq(8);
    }

    [LineNumberTable(new byte[] {64, 107, 130, 109, 102, 99, 106, 107, 98, 98, 100, 98, 217, 102, 39, 230, 60, 103, 98, 141, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue parse(Reader reader)
    {
      JsonValue jsonValue;
      IOException ioException1;
      // ISSUE: fault handler
      try
      {
        char[] data = new char[1024];
        int length = 0;
        while (true)
        {
          int num = reader.read(data, length, data.Length - length);
          switch (num)
          {
            case -1:
              goto label_4;
            case 0:
              char[] chArray = new char[data.Length * 2];
              ByteCodeHelper.arraycopy_primitive_2((Array) data, 0, (Array) chArray, 0, data.Length);
              data = chArray;
              continue;
            default:
              length += num;
              continue;
          }
        }
label_4:
        jsonValue = this.parse(data, 0, length);
        goto label_8;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      __fault
      {
        Streams.close((Closeable) reader);
      }
      IOException ioException2 = ioException1;
      // ISSUE: fault handler
      try
      {
        IOException ioException3 = ioException2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException((Exception) ioException3);
      }
      __fault
      {
        Streams.close((Closeable) reader);
      }
label_8:
      Streams.close((Closeable) reader);
      return jsonValue;
    }

    [LineNumberTable(new byte[] {88, 150, 102, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue parse(InputStream input)
    {
      try
      {
        return this.parse((Reader) new InputStreamReader(input, Strings.__\u003C\u003Eutf8));
      }
      finally
      {
        Streams.close((Closeable) input);
      }
    }

    [LineNumberTable(new byte[] {96, 127, 13, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue parse(Fi file)
    {
      JsonValue jsonValue;
      Exception exception1;
      try
      {
        jsonValue = this.parse(file.reader("UTF-8"));
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return jsonValue;
label_5:
      Exception exception2 = exception1;
      string message = new StringBuilder().append("Error parsing file: ").append((object) file).toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException(message, (Exception) exception3);
    }

    [LineNumberTable(new byte[] {103, 100, 135, 98, 103, 105, 131, 99, 238, 70, 99, 227, 70, 194, 195, 159, 5, 100, 99, 130, 100, 99, 226, 69, 106, 106, 106, 104, 132, 137, 136, 108, 109, 104, 109, 136, 106, 165, 103, 167, 106, 104, 132, 139, 136, 111, 109, 104, 111, 136, 108, 162, 199, 106, 138, 106, 106, 127, 34, 110, 223, 29, 131, 197, 108, 142, 100, 99, 127, 10, 141, 121, 103, 110, 127, 20, 105, 101, 110, 127, 20, 105, 101, 110, 105, 133, 134, 107, 255, 160, 155, 77, 194, 99, 99, 130, 99, 99, 226, 40, 235, 91, 135, 100, 127, 29, 125, 127, 77, 97, 101, 100, 100, 159, 29, 121, 127, 7, 193, 127, 27, 159, 7, 99, 130, 197, 121, 127, 10, 136, 102, 107, 108, 163, 108, 99, 99, 255, 0, 72, 115, 134, 108, 99, 255, 0, 71, 121, 127, 10, 136, 102, 107, 108, 163, 108, 100, 99, 255, 0, 72, 115, 134, 108, 99, 255, 0, 71, 101, 107, 107, 102, 134, 118, 102, 132, 100, 159, 16, 223, 0, 115, 98, 99, 99, 167, 159, 18, 99, 130, 104, 103, 244, 69, 133, 100, 127, 17, 100, 236, 69, 159, 40, 99, 130, 104, 103, 238, 71, 130, 100, 127, 17, 100, 169, 100, 106, 255, 4, 70, 115, 102, 163, 150, 99, 100, 130, 162, 100, 134, 159, 1, 229, 71, 100, 99, 133, 104, 99, 165, 100, 106, 127, 20, 110, 113, 108, 142, 100, 99, 127, 10, 141, 121, 103, 110, 127, 20, 105, 101, 110, 127, 20, 105, 101, 110, 105, 133, 134, 107, 255, 160, 155, 77, 194, 99, 99, 130, 99, 99, 226, 40, 235, 91, 135, 100, 127, 29, 122, 127, 21, 97, 101, 100, 100, 159, 29, 121, 127, 7, 193, 127, 27, 159, 4, 99, 130, 229, 70, 226, 72, 2, 98, 164, 104, 103, 103, 140, 103, 99, 104, 46, 136, 108, 127, 35, 127, 2, 109, 114, 108, 109, 144, 112, 100, 159, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue parse(char[] data, int offset, int length)
    {
      int index1 = offset;
      int[] numArray1 = new int[4];
      int num1 = 0;
      Seq seq = new Seq(8);
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      RuntimeException runtimeException1 = (RuntimeException) null;
      int num5 = 0;
      if (num5 != 0)
        java.lang.System.@out.println();
      int index2 = 1;
      int num6 = 0;
      int num7 = 0;
      RuntimeException runtimeException2;
      RuntimeException runtimeException3;
      RuntimeException runtimeException4;
      RuntimeException runtimeException5;
      RuntimeException runtimeException6;
      RuntimeException runtimeException7;
      RuntimeException runtimeException8;
      RuntimeException runtimeException9;
      RuntimeException runtimeException10;
      RuntimeException runtimeException11;
      RuntimeException runtimeException12;
      while (true)
      {
        int num8;
        int num9;
        try
        {
          switch (num7)
          {
            case 0:
              if (index1 == length)
              {
                num7 = 4;
                continue;
              }
              if (index2 == 0)
              {
                num7 = 5;
                continue;
              }
              goto case 1;
            case 1:
              int jsonKeyOffset = (int) JsonReader._json_key_offsets[index2];
              int jsonIndexOffset = (int) JsonReader._json_index_offsets[index2];
              int jsonSingleLength = (int) (sbyte) JsonReader._json_single_lengths[index2];
              if (jsonSingleLength > 0)
              {
                int num10 = jsonKeyOffset;
                int num11 = jsonKeyOffset + jsonSingleLength - 1;
                while (num11 >= num10)
                {
                  int index3 = num10 + (num11 - num10 >> 1);
                  if ((int) data[index1] < (int) JsonReader._json_trans_keys[index3])
                    num11 = index3 - 1;
                  else if ((int) data[index1] > (int) JsonReader._json_trans_keys[index3])
                  {
                    num10 = index3 + 1;
                  }
                  else
                  {
                    jsonIndexOffset += index3 - jsonKeyOffset;
                    goto label_26;
                  }
                }
                jsonKeyOffset += jsonSingleLength;
                jsonIndexOffset += jsonSingleLength;
              }
              int jsonRangeLength = (int) (sbyte) JsonReader._json_range_lengths[index2];
              if (jsonRangeLength > 0)
              {
                int num10 = jsonKeyOffset;
                int num11 = jsonKeyOffset + (jsonRangeLength << 1) - 2;
                while (num11 >= num10)
                {
                  int index3 = num10 + (num11 - num10 >> 1 & -2);
                  if ((int) data[index1] < (int) JsonReader._json_trans_keys[index3])
                    num11 = index3 - 2;
                  else if ((int) data[index1] > (int) JsonReader._json_trans_keys[index3 + 1])
                  {
                    num10 = index3 + 2;
                  }
                  else
                  {
                    jsonIndexOffset += index3 - jsonKeyOffset >> 1;
                    goto label_26;
                  }
                }
                jsonIndexOffset += jsonRangeLength;
              }
label_26:
              int jsonIndicy = (int) (sbyte) JsonReader._json_indicies[jsonIndexOffset];
              index2 = (int) (sbyte) JsonReader._json_trans_targs[jsonIndicy];
              if (JsonReader._json_trans_actions[jsonIndicy] != (byte) 0)
              {
                int jsonTransAction = (int) (sbyte) JsonReader._json_trans_actions[jsonIndicy];
                byte[] jsonActions = JsonReader._json_actions;
                int index3 = jsonTransAction;
                num8 = jsonTransAction + 1;
                num9 = (int) (sbyte) jsonActions[index3];
                break;
              }
              goto label_166;
            case 2:
              goto label_166;
            case 4:
              goto label_170;
            default:
              goto label_230;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException2 = (RuntimeException) m0;
            break;
          }
        }
label_32:
        while (true)
        {
          string stringValue;
          string name;
          int num10;
          try
          {
            int num11 = num9;
            num9 += -1;
            if (num11 > 0)
            {
              byte[] jsonActions = JsonReader._json_actions;
              int index3 = num8;
              ++num8;
              switch ((sbyte) jsonActions[index3])
              {
                case 0:
                  num3 = 1;
                  continue;
                case 1:
                  stringValue = String.newhelper(data, num1, index1 - num1);
                  if (num2 != 0)
                    stringValue = this.unescape(stringValue);
                  if (num3 != 0)
                  {
                    num3 = 0;
                    if (num5 != 0)
                      java.lang.System.@out.println(new StringBuilder().append("name: ").append(stringValue).toString());
                    seq.add((object) stringValue);
                    goto label_85;
                  }
                  else
                  {
                    name = seq.size <= 0 ? (string) null : (string) seq.pop();
                    if (num4 != 0)
                    {
                      if (String.instancehelper_equals(stringValue, (object) "true"))
                      {
                        if (num5 != 0)
                          java.lang.System.@out.println(new StringBuilder().append("boolean: ").append(name).append("=true").toString());
                        this.@bool(name, true);
                        goto label_85;
                      }
                      else if (String.instancehelper_equals(stringValue, (object) "false"))
                      {
                        if (num5 != 0)
                          java.lang.System.@out.println(new StringBuilder().append("boolean: ").append(name).append("=false").toString());
                        this.@bool(name, false);
                        goto label_85;
                      }
                      else if (String.instancehelper_equals(stringValue, (object) "null"))
                      {
                        this.@string(name, (string) null);
                        goto label_85;
                      }
                      else
                      {
                        int num12 = 0;
                        num10 = 1;
                        for (int index4 = num1; index4 < index1; ++index4)
                        {
                          switch (data[index4])
                          {
                            case '+':
                            case '-':
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9':
                              continue;
                            case '.':
                            case 'E':
                            case 'e':
                              num12 = 1;
                              num10 = 0;
                              continue;
                            default:
                              num12 = 0;
                              num10 = 0;
                              goto label_58;
                          }
                        }
label_58:
                        if (num12 != 0)
                        {
                          try
                          {
                            if (num5 != 0)
                              java.lang.System.@out.println(new StringBuilder().append("double: ").append(name).append("=").append(Double.parseDouble(stringValue)).toString());
                            this.number(name, Double.parseDouble(stringValue), stringValue);
                            goto label_85;
                          }
                          catch (NumberFormatException ex)
                          {
                            break;
                          }
                        }
                        else
                          goto label_68;
                      }
                    }
                    else
                      goto label_78;
                  }
                case 2:
                  goto label_86;
                case 3:
                  goto label_95;
                case 4:
                  goto label_102;
                case 5:
                  goto label_111;
                case 6:
                  goto label_118;
                case 7:
                  goto label_131;
                case 8:
                  goto label_155;
                default:
                  continue;
              }
            }
            else
              goto label_166;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              runtimeException3 = (RuntimeException) m0;
              goto label_67;
            }
          }
          goto label_78;
label_68:
          try
          {
            if (num10 != 0)
            {
              if (num5 != 0)
                java.lang.System.@out.println(new StringBuilder().append("double: ").append(name).append("=").append(Double.parseDouble(stringValue)).toString());
              try
              {
                this.number(name, Long.parseLong(stringValue), stringValue);
                goto label_85;
              }
              catch (NumberFormatException ex)
              {
              }
            }
            else
              goto label_78;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              runtimeException4 = (RuntimeException) m0;
              goto label_77;
            }
          }
label_78:
          try
          {
            if (num5 != 0)
              java.lang.System.@out.println(new StringBuilder().append("string: ").append(name).append("=").append(stringValue).toString());
            this.@string(name, stringValue);
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              runtimeException5 = (RuntimeException) m0;
              goto label_84;
            }
          }
label_85:
          num4 = 0;
          num1 = index1;
          continue;
label_118:
          try
          {
            int num11 = index1 - 1;
            char[] chArray = data;
            int index3 = index1;
            ++index1;
            if (chArray[index3] == '/')
            {
              while (index1 != length && data[index1] != '\n')
                ++index1;
              index1 += -1;
            }
            else
            {
              while (index1 + 1 < length && data[index1] != '*' || data[index1 + 1] != '/')
                ++index1;
              ++index1;
            }
            if (num5 != 0)
            {
              java.lang.System.@out.println(new StringBuilder().append("comment ").append(String.newhelper(data, num11, index1 - num11)).toString());
              continue;
            }
            continue;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              runtimeException10 = (RuntimeException) m0;
              goto label_130;
            }
          }
label_155:
          try
          {
            if (num5 != 0)
              java.lang.System.@out.println("quotedChars");
            ++index1;
            num1 = index1;
            num2 = 0;
            do
            {
              switch (data[index1])
              {
                case '"':
                  goto label_161;
                case '\\':
                  num2 = 1;
                  ++index1;
                  break;
              }
              ++index1;
            }
            while (index1 != length);
label_161:
            index1 += -1;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              runtimeException12 = (RuntimeException) m0;
              goto label_165;
            }
          }
        }
label_86:
        try
        {
          string name = seq.size <= 0 ? (string) null : (string) seq.pop();
          if (num5 != 0)
            java.lang.System.@out.println(new StringBuilder().append("startObject: ").append(name).toString());
          this.startObject(name);
          if (num6 == numArray1.Length)
          {
            int[] numArray2 = new int[numArray1.Length * 2];
            ByteCodeHelper.arraycopy_primitive_4((Array) numArray1, 0, (Array) numArray2, 0, numArray1.Length);
            numArray1 = numArray2;
          }
          int[] numArray3 = numArray1;
          int index3 = num6;
          ++num6;
          int num10 = index2;
          numArray3[index3] = num10;
          index2 = 5;
          num7 = 2;
          continue;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException6 = (RuntimeException) m0;
            goto label_94;
          }
        }
label_95:
        try
        {
          if (num5 != 0)
            java.lang.System.@out.println("endObject");
          this.pop();
          int[] numArray2 = numArray1;
          num6 += -1;
          int index3 = num6;
          index2 = numArray2[index3];
          num7 = 2;
          continue;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException7 = (RuntimeException) m0;
            goto label_101;
          }
        }
label_102:
        try
        {
          string name = seq.size <= 0 ? (string) null : (string) seq.pop();
          if (num5 != 0)
            java.lang.System.@out.println(new StringBuilder().append("startArray: ").append(name).toString());
          this.startArray(name);
          if (num6 == numArray1.Length)
          {
            int[] numArray2 = new int[numArray1.Length * 2];
            ByteCodeHelper.arraycopy_primitive_4((Array) numArray1, 0, (Array) numArray2, 0, numArray1.Length);
            numArray1 = numArray2;
          }
          int[] numArray3 = numArray1;
          int index3 = num6;
          ++num6;
          int num10 = index2;
          numArray3[index3] = num10;
          index2 = 23;
          num7 = 2;
          continue;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException8 = (RuntimeException) m0;
            goto label_110;
          }
        }
label_111:
        try
        {
          if (num5 != 0)
            java.lang.System.@out.println("endArray");
          this.pop();
          int[] numArray2 = numArray1;
          num6 += -1;
          int index3 = num6;
          index2 = numArray2[index3];
          num7 = 2;
          continue;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException9 = (RuntimeException) m0;
            goto label_117;
          }
        }
label_131:
        try
        {
          if (num5 != 0)
            java.lang.System.@out.println("unquotedChars");
          num1 = index1;
          num2 = 0;
          num4 = 1;
          if (num3 != 0)
          {
            do
            {
              switch (data[index1])
              {
                case '\n':
                case '\r':
                case ':':
                  goto label_148;
                case '/':
                  if (index1 + 1 != length)
                  {
                    switch (data[index1 + 1])
                    {
                      case '*':
                      case '/':
                        goto label_148;
                    }
                  }
                  else
                    break;
                  break;
                case '\\':
                  num2 = 1;
                  break;
              }
              if (num5 != 0)
                java.lang.System.@out.println(new StringBuilder().append("unquotedChar (name): '").append(data[index1]).append("'").toString());
              ++index1;
            }
            while (index1 != length);
          }
          else
          {
            do
            {
              switch (data[index1])
              {
                case '\n':
                case '\r':
                case ',':
                case ']':
                case '}':
                  goto label_148;
                case '/':
                  if (index1 + 1 != length)
                  {
                    switch (data[index1 + 1])
                    {
                      case '*':
                      case '/':
                        goto label_148;
                    }
                  }
                  else
                    break;
                  break;
                case '\\':
                  num2 = 1;
                  break;
              }
              if (num5 != 0)
                java.lang.System.@out.println(new StringBuilder().append("unquotedChar (value): '").append(data[index1]).append("'").toString());
              ++index1;
            }
            while (index1 != length);
          }
label_148:
          index1 += -1;
          while (true)
          {
            if (Character.isWhitespace(data[index1]))
              index1 += -1;
            else
              goto label_32;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException11 = (RuntimeException) m0;
            goto label_154;
          }
        }
label_166:
        if (index2 == 0)
        {
          num7 = 5;
        }
        else
        {
          ++index1;
          if (index1 != length)
            num7 = 1;
          else
            goto label_170;
        }
      }
      RuntimeException runtimeException13 = runtimeException2;
      goto label_229;
label_67:
      runtimeException13 = runtimeException3;
      goto label_229;
label_77:
      runtimeException13 = runtimeException4;
      goto label_229;
label_84:
      runtimeException13 = runtimeException5;
      goto label_229;
label_94:
      runtimeException13 = runtimeException6;
      goto label_229;
label_101:
      runtimeException13 = runtimeException7;
      goto label_229;
label_110:
      runtimeException13 = runtimeException8;
      goto label_229;
label_117:
      runtimeException13 = runtimeException9;
      goto label_229;
label_130:
      runtimeException13 = runtimeException10;
      goto label_229;
label_154:
      runtimeException13 = runtimeException11;
      goto label_229;
label_165:
      runtimeException13 = runtimeException12;
      goto label_229;
label_170:
      int num13;
      int num14;
      RuntimeException runtimeException14;
      try
      {
        if (index1 == length)
        {
          int jsonEofAction = (int) (sbyte) JsonReader._json_eof_actions[index2];
          byte[] jsonActions = JsonReader._json_actions;
          int index3 = jsonEofAction;
          num13 = jsonEofAction + 1;
          num14 = (int) (sbyte) jsonActions[index3];
          goto label_176;
        }
        else
          goto label_230;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          runtimeException14 = (RuntimeException) m0;
      }
      runtimeException13 = runtimeException14;
      goto label_229;
label_176:
      RuntimeException runtimeException15;
      RuntimeException runtimeException16;
      RuntimeException runtimeException17;
      while (true)
      {
        string stringValue;
        string name;
        int num8;
        try
        {
          byte[] jsonActions;
          int index3;
          do
          {
            int num9 = num14;
            num14 += -1;
            if (num9 > 0)
            {
              jsonActions = JsonReader._json_actions;
              index3 = num13;
              ++num13;
            }
            else
              goto label_230;
          }
          while (jsonActions[index3] != (byte) 1);
          stringValue = String.newhelper(data, num1, index1 - num1);
          if (num2 != 0)
            stringValue = this.unescape(stringValue);
          if (num3 != 0)
          {
            num3 = 0;
            if (num5 != 0)
              java.lang.System.@out.println(new StringBuilder().append("name: ").append(stringValue).toString());
            seq.add((object) stringValue);
            goto label_228;
          }
          else
          {
            name = seq.size <= 0 ? (string) null : (string) seq.pop();
            if (num4 != 0)
            {
              if (String.instancehelper_equals(stringValue, (object) "true"))
              {
                if (num5 != 0)
                  java.lang.System.@out.println(new StringBuilder().append("boolean: ").append(name).append("=true").toString());
                this.@bool(name, true);
                goto label_228;
              }
              else if (String.instancehelper_equals(stringValue, (object) "false"))
              {
                if (num5 != 0)
                  java.lang.System.@out.println(new StringBuilder().append("boolean: ").append(name).append("=false").toString());
                this.@bool(name, false);
                goto label_228;
              }
              else if (String.instancehelper_equals(stringValue, (object) "null"))
              {
                this.@string(name, (string) null);
                goto label_228;
              }
              else
              {
                int num9 = 0;
                num8 = 1;
                for (int index4 = num1; index4 < index1; ++index4)
                {
                  switch (data[index4])
                  {
                    case '+':
                    case '-':
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                      continue;
                    case '.':
                    case 'E':
                    case 'e':
                      num9 = 1;
                      num8 = 0;
                      continue;
                    default:
                      num9 = 0;
                      num8 = 0;
                      goto label_201;
                  }
                }
label_201:
                if (num9 != 0)
                {
                  try
                  {
                    if (num5 != 0)
                      java.lang.System.@out.println(new StringBuilder().append("double: ").append(name).append("=").append(Double.parseDouble(stringValue)).toString());
                    this.number(name, Double.parseDouble(stringValue), stringValue);
                    goto label_228;
                  }
                  catch (NumberFormatException ex)
                  {
                  }
                }
                else
                  goto label_211;
              }
            }
            else
              goto label_221;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException15 = (RuntimeException) m0;
            break;
          }
        }
        goto label_221;
label_211:
        try
        {
          if (num8 != 0)
          {
            if (num5 != 0)
              java.lang.System.@out.println(new StringBuilder().append("double: ").append(name).append("=").append(Double.parseDouble(stringValue)).toString());
            try
            {
              this.number(name, Long.parseLong(stringValue), stringValue);
              goto label_228;
            }
            catch (NumberFormatException ex)
            {
            }
          }
          else
            goto label_221;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException16 = (RuntimeException) m0;
            goto label_220;
          }
        }
label_221:
        try
        {
          if (num5 != 0)
            java.lang.System.@out.println(new StringBuilder().append("string: ").append(name).append("=").append(stringValue).toString());
          this.@string(name, stringValue);
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException17 = (RuntimeException) m0;
            goto label_227;
          }
        }
label_228:
        num4 = 0;
        num1 = index1;
      }
      runtimeException13 = runtimeException15;
      goto label_229;
label_220:
      runtimeException13 = runtimeException16;
      goto label_229;
label_227:
      runtimeException13 = runtimeException17;
label_229:
      runtimeException1 = runtimeException13;
label_230:
      JsonValue root = this.root;
      this.root = (JsonValue) null;
      this.current = (JsonValue) null;
      this.lastChild.clear();
      if (index1 < length)
      {
        int num8 = 1;
        for (int index3 = 0; index3 < index1; ++index3)
        {
          if (data[index3] == '\n')
            ++num8;
        }
        int num9 = Math.max(0, index1 - 32);
        string message = new StringBuilder().append("Error parsing JSON on line ").append(num8).append(" near: ").append(String.newhelper(data, num9, index1 - num9)).append("*ERROR*").append(String.newhelper(data, index1, Math.min(64, length - index1))).toString();
        RuntimeException runtimeException18 = runtimeException1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message, (Exception) runtimeException18);
      }
      if (this.elements.size != 0)
      {
        JsonValue jsonValue = (JsonValue) this.elements.peek();
        this.elements.clear();
        if (jsonValue != null && jsonValue.isObject())
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new SerializationException("Error parsing JSON, unmatched brace.");
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException("Error parsing JSON, unmatched bracket.");
      }
      if (runtimeException1 != null)
      {
        string message = new StringBuilder().append("Error parsing JSON: ").append(String.newhelper(data)).toString();
        RuntimeException runtimeException18 = runtimeException1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message, (Exception) runtimeException18);
      }
      return root;
    }

    [LineNumberTable(new byte[] {58, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual JsonValue parse(string json)
    {
      char[] charArray = String.instancehelper_toCharArray(json);
      return this.parse(charArray, 0, charArray.Length);
    }

    [LineNumberTable(new byte[] {162, 67, 103, 106, 105, 108, 101, 104, 130, 105, 108, 101, 125, 100, 133, 223, 37, 130, 98, 130, 99, 130, 99, 130, 99, 130, 99, 130, 159, 6, 104, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string unescape([In] string obj0)
    {
      int num1 = String.instancehelper_length(obj0);
      StringBuilder stringBuilder = new StringBuilder(num1 + 16);
      int num2 = 0;
      while (num2 < num1)
      {
        string str1 = obj0;
        int num3 = num2;
        ++num2;
        int num4 = (int) String.instancehelper_charAt(str1, num3);
        if (num4 != 92)
          stringBuilder.append((char) num4);
        else if (num2 != num1)
        {
          string str2 = obj0;
          int num5 = num2;
          ++num2;
          int num6 = (int) String.instancehelper_charAt(str2, num5);
          switch (num6)
          {
            case 34:
            case 47:
            case 92:
              stringBuilder.append((char) num6);
              continue;
            case 98:
              num6 = 8;
              goto case 34;
            case 102:
              num6 = 12;
              goto case 34;
            case 110:
              num6 = 10;
              goto case 34;
            case 114:
              num6 = 13;
              goto case 34;
            case 116:
              num6 = 9;
              goto case 34;
            case 117:
              stringBuilder.append(Character.toChars(Integer.parseInt(String.instancehelper_substring(obj0, num2, num2 + 4), 16)));
              num2 += 4;
              continue;
            default:
              string message = new StringBuilder().append("Illegal escaped character: \\").append((char) num6).toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new SerializationException(message);
          }
        }
        else
          break;
      }
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {158, 226, 98, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void @bool(string name, bool value)
    {
      int num = value ? 1 : 0;
      this.addChild(name, new JsonValue(num != 0));
    }

    [LineNumberTable(new byte[] {162, 51, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void @string(string name, string value) => this.addChild(name, new JsonValue(value));

    [LineNumberTable(new byte[] {162, 55, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void number(string name, double value, string stringValue) => this.addChild(name, new JsonValue(value, stringValue));

    [LineNumberTable(new byte[] {162, 59, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void number(string name, long value, string stringValue) => this.addChild(name, new JsonValue(value, stringValue));

    [LineNumberTable(new byte[] {162, 31, 107, 112, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void startObject(string name)
    {
      JsonValue jsonValue = new JsonValue(JsonValue.ValueType.__\u003C\u003Eobject);
      if (this.current != null)
        this.addChild(name, jsonValue);
      this.elements.add((object) jsonValue);
      this.current = jsonValue;
    }

    [LineNumberTable(new byte[] {162, 45, 118, 122, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void pop()
    {
      this.root = (JsonValue) this.elements.pop();
      if (this.current.size > 0)
        this.lastChild.pop();
      this.current = this.elements.size <= 0 ? (JsonValue) null : (JsonValue) this.elements.peek();
    }

    [LineNumberTable(new byte[] {162, 38, 107, 112, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void startArray(string name)
    {
      JsonValue jsonValue = new JsonValue(JsonValue.ValueType.__\u003C\u003Earray);
      if (this.current != null)
        this.addChild(name, jsonValue);
      this.elements.add((object) jsonValue);
      this.current = jsonValue;
    }

    [LineNumberTable(new byte[] {162, 11, 103, 104, 103, 108, 122, 108, 109, 142, 113, 103, 135, 108, 149, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addChild([In] string obj0, [In] JsonValue obj1)
    {
      obj1.setName(obj0);
      if (this.current == null)
      {
        this.current = obj1;
        this.root = obj1;
      }
      else if (this.current.isArray() || this.current.isObject())
      {
        obj1.parent = this.current;
        if (this.current.size == 0)
        {
          this.current.child = obj1;
        }
        else
        {
          JsonValue jsonValue = (JsonValue) this.lastChild.pop();
          jsonValue.next = obj1;
          obj1.prev = jsonValue;
        }
        this.lastChild.add((object) obj1);
        ++this.current.size;
      }
      else
        this.root = this.current;
    }

    [LineNumberTable(47)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] init__json_actions_0() => new byte[29]
    {
      (byte) 0,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 2,
      (byte) 1,
      (byte) 3,
      (byte) 1,
      (byte) 4,
      (byte) 1,
      (byte) 5,
      (byte) 1,
      (byte) 6,
      (byte) 1,
      (byte) 7,
      (byte) 1,
      (byte) 8,
      (byte) 2,
      (byte) 0,
      (byte) 7,
      (byte) 2,
      (byte) 0,
      (byte) 8,
      (byte) 2,
      (byte) 1,
      (byte) 3,
      (byte) 2,
      (byte) 1,
      (byte) 5
    };

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static short[] init__json_key_offsets_0() => new short[39]
    {
      (short) 0,
      (short) 0,
      (short) 11,
      (short) 13,
      (short) 14,
      (short) 16,
      (short) 25,
      (short) 31,
      (short) 37,
      (short) 39,
      (short) 50,
      (short) 57,
      (short) 64,
      (short) 73,
      (short) 74,
      (short) 83,
      (short) 85,
      (short) 87,
      (short) 96,
      (short) 98,
      (short) 100,
      (short) 101,
      (short) 103,
      (short) 105,
      (short) 116,
      (short) 123,
      (short) 130,
      (short) 141,
      (short) 142,
      (short) 153,
      (short) 155,
      (short) 157,
      (short) 168,
      (short) 170,
      (short) 172,
      (short) 174,
      (short) 179,
      (short) 184,
      (short) 184
    };

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static char[] init__json_trans_keys_0() => new char[185]
    {
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '[',
      ']',
      '{',
      '\t',
      '\n',
      '*',
      '/',
      '"',
      '*',
      '/',
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '}',
      '\t',
      '\n',
      '\r',
      ' ',
      '/',
      ':',
      '\t',
      '\n',
      '\r',
      ' ',
      '/',
      ':',
      '\t',
      '\n',
      '*',
      '/',
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '[',
      ']',
      '{',
      '\t',
      '\n',
      '\t',
      '\n',
      '\r',
      ' ',
      ',',
      '/',
      '}',
      '\t',
      '\n',
      '\r',
      ' ',
      ',',
      '/',
      '}',
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '}',
      '\t',
      '\n',
      '"',
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '}',
      '\t',
      '\n',
      '*',
      '/',
      '*',
      '/',
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '}',
      '\t',
      '\n',
      '*',
      '/',
      '*',
      '/',
      '"',
      '*',
      '/',
      '*',
      '/',
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '[',
      ']',
      '{',
      '\t',
      '\n',
      '\t',
      '\n',
      '\r',
      ' ',
      ',',
      '/',
      ']',
      '\t',
      '\n',
      '\r',
      ' ',
      ',',
      '/',
      ']',
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '[',
      ']',
      '{',
      '\t',
      '\n',
      '"',
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '[',
      ']',
      '{',
      '\t',
      '\n',
      '*',
      '/',
      '*',
      '/',
      '\r',
      ' ',
      '"',
      ',',
      '/',
      ':',
      '[',
      ']',
      '{',
      '\t',
      '\n',
      '*',
      '/',
      '*',
      '/',
      '*',
      '/',
      '\r',
      ' ',
      '/',
      '\t',
      '\n',
      '\r',
      ' ',
      '/',
      '\t',
      '\n',
      char.MinValue
    };

    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] init__json_single_lengths_0() => new byte[39]
    {
      (byte) 0,
      (byte) 9,
      (byte) 2,
      (byte) 1,
      (byte) 2,
      (byte) 7,
      (byte) 4,
      (byte) 4,
      (byte) 2,
      (byte) 9,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 1,
      (byte) 7,
      (byte) 2,
      (byte) 2,
      (byte) 7,
      (byte) 2,
      (byte) 2,
      (byte) 1,
      (byte) 2,
      (byte) 2,
      (byte) 9,
      (byte) 7,
      (byte) 7,
      (byte) 9,
      (byte) 1,
      (byte) 9,
      (byte) 2,
      (byte) 2,
      (byte) 9,
      (byte) 2,
      (byte) 2,
      (byte) 2,
      (byte) 3,
      (byte) 3,
      (byte) 0,
      (byte) 0
    };

    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] init__json_range_lengths_0() => new byte[39]
    {
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 1,
      (byte) 0,
      (byte) 0
    };

    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static short[] init__json_index_offsets_0() => new short[39]
    {
      (short) 0,
      (short) 0,
      (short) 11,
      (short) 14,
      (short) 16,
      (short) 19,
      (short) 28,
      (short) 34,
      (short) 40,
      (short) 43,
      (short) 54,
      (short) 62,
      (short) 70,
      (short) 79,
      (short) 81,
      (short) 90,
      (short) 93,
      (short) 96,
      (short) 105,
      (short) 108,
      (short) 111,
      (short) 113,
      (short) 116,
      (short) 119,
      (short) 130,
      (short) 138,
      (short) 146,
      (short) 157,
      (short) 159,
      (short) 170,
      (short) 173,
      (short) 176,
      (short) 187,
      (short) 190,
      (short) 193,
      (short) 196,
      (short) 201,
      (short) 206,
      (short) 207
    };

    [LineNumberTable(81)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] init__json_indicies_0() => new byte[209]
    {
      (byte) 1,
      (byte) 1,
      (byte) 2,
      (byte) 3,
      (byte) 4,
      (byte) 3,
      (byte) 5,
      (byte) 3,
      (byte) 6,
      (byte) 1,
      (byte) 0,
      (byte) 7,
      (byte) 7,
      (byte) 3,
      (byte) 8,
      (byte) 3,
      (byte) 9,
      (byte) 9,
      (byte) 3,
      (byte) 11,
      (byte) 11,
      (byte) 12,
      (byte) 13,
      (byte) 14,
      (byte) 3,
      (byte) 15,
      (byte) 11,
      (byte) 10,
      (byte) 16,
      (byte) 16,
      (byte) 17,
      (byte) 18,
      (byte) 16,
      (byte) 3,
      (byte) 19,
      (byte) 19,
      (byte) 20,
      (byte) 21,
      (byte) 19,
      (byte) 3,
      (byte) 22,
      (byte) 22,
      (byte) 3,
      (byte) 21,
      (byte) 21,
      (byte) 24,
      (byte) 3,
      (byte) 25,
      (byte) 3,
      (byte) 26,
      (byte) 3,
      (byte) 27,
      (byte) 21,
      (byte) 23,
      (byte) 28,
      (byte) 29,
      (byte) 29,
      (byte) 28,
      (byte) 30,
      (byte) 31,
      (byte) 32,
      (byte) 3,
      (byte) 33,
      (byte) 34,
      (byte) 34,
      (byte) 33,
      (byte) 13,
      (byte) 35,
      (byte) 15,
      (byte) 3,
      (byte) 34,
      (byte) 34,
      (byte) 12,
      (byte) 36,
      (byte) 37,
      (byte) 3,
      (byte) 15,
      (byte) 34,
      (byte) 10,
      (byte) 16,
      (byte) 3,
      (byte) 36,
      (byte) 36,
      (byte) 12,
      (byte) 3,
      (byte) 38,
      (byte) 3,
      (byte) 3,
      (byte) 36,
      (byte) 10,
      (byte) 39,
      (byte) 39,
      (byte) 3,
      (byte) 40,
      (byte) 40,
      (byte) 3,
      (byte) 13,
      (byte) 13,
      (byte) 12,
      (byte) 3,
      (byte) 41,
      (byte) 3,
      (byte) 15,
      (byte) 13,
      (byte) 10,
      (byte) 42,
      (byte) 42,
      (byte) 3,
      (byte) 43,
      (byte) 43,
      (byte) 3,
      (byte) 28,
      (byte) 3,
      (byte) 44,
      (byte) 44,
      (byte) 3,
      (byte) 45,
      (byte) 45,
      (byte) 3,
      (byte) 47,
      (byte) 47,
      (byte) 48,
      (byte) 49,
      (byte) 50,
      (byte) 3,
      (byte) 51,
      (byte) 52,
      (byte) 53,
      (byte) 47,
      (byte) 46,
      (byte) 54,
      (byte) 55,
      (byte) 55,
      (byte) 54,
      (byte) 56,
      (byte) 57,
      (byte) 58,
      (byte) 3,
      (byte) 59,
      (byte) 60,
      (byte) 60,
      (byte) 59,
      (byte) 49,
      (byte) 61,
      (byte) 52,
      (byte) 3,
      (byte) 60,
      (byte) 60,
      (byte) 48,
      (byte) 62,
      (byte) 63,
      (byte) 3,
      (byte) 51,
      (byte) 52,
      (byte) 53,
      (byte) 60,
      (byte) 46,
      (byte) 54,
      (byte) 3,
      (byte) 62,
      (byte) 62,
      (byte) 48,
      (byte) 3,
      (byte) 64,
      (byte) 3,
      (byte) 51,
      (byte) 3,
      (byte) 53,
      (byte) 62,
      (byte) 46,
      (byte) 65,
      (byte) 65,
      (byte) 3,
      (byte) 66,
      (byte) 66,
      (byte) 3,
      (byte) 49,
      (byte) 49,
      (byte) 48,
      (byte) 3,
      (byte) 67,
      (byte) 3,
      (byte) 51,
      (byte) 52,
      (byte) 53,
      (byte) 49,
      (byte) 46,
      (byte) 68,
      (byte) 68,
      (byte) 3,
      (byte) 69,
      (byte) 69,
      (byte) 3,
      (byte) 70,
      (byte) 70,
      (byte) 3,
      (byte) 8,
      (byte) 8,
      (byte) 71,
      (byte) 8,
      (byte) 3,
      (byte) 72,
      (byte) 72,
      (byte) 73,
      (byte) 72,
      (byte) 3,
      (byte) 3,
      (byte) 3,
      (byte) 0
    };

    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] init__json_trans_targs_0() => new byte[74]
    {
      (byte) 35,
      (byte) 1,
      (byte) 3,
      (byte) 0,
      (byte) 4,
      (byte) 36,
      (byte) 36,
      (byte) 36,
      (byte) 36,
      (byte) 1,
      (byte) 6,
      (byte) 5,
      (byte) 13,
      (byte) 17,
      (byte) 22,
      (byte) 37,
      (byte) 7,
      (byte) 8,
      (byte) 9,
      (byte) 7,
      (byte) 8,
      (byte) 9,
      (byte) 7,
      (byte) 10,
      (byte) 20,
      (byte) 21,
      (byte) 11,
      (byte) 11,
      (byte) 11,
      (byte) 12,
      (byte) 17,
      (byte) 19,
      (byte) 37,
      (byte) 11,
      (byte) 12,
      (byte) 19,
      (byte) 14,
      (byte) 16,
      (byte) 15,
      (byte) 14,
      (byte) 12,
      (byte) 18,
      (byte) 17,
      (byte) 11,
      (byte) 9,
      (byte) 5,
      (byte) 24,
      (byte) 23,
      (byte) 27,
      (byte) 31,
      (byte) 34,
      (byte) 25,
      (byte) 38,
      (byte) 25,
      (byte) 25,
      (byte) 26,
      (byte) 31,
      (byte) 33,
      (byte) 38,
      (byte) 25,
      (byte) 26,
      (byte) 33,
      (byte) 28,
      (byte) 30,
      (byte) 29,
      (byte) 28,
      (byte) 26,
      (byte) 32,
      (byte) 31,
      (byte) 25,
      (byte) 23,
      (byte) 2,
      (byte) 36,
      (byte) 2
    };

    [LineNumberTable(97)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] init__json_trans_actions_0() => new byte[74]
    {
      (byte) 13,
      (byte) 0,
      (byte) 15,
      (byte) 0,
      (byte) 0,
      (byte) 7,
      (byte) 3,
      (byte) 11,
      (byte) 1,
      (byte) 11,
      (byte) 17,
      (byte) 0,
      (byte) 20,
      (byte) 0,
      (byte) 0,
      (byte) 5,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 11,
      (byte) 13,
      (byte) 15,
      (byte) 0,
      (byte) 7,
      (byte) 3,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 23,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 11,
      (byte) 11,
      (byte) 0,
      (byte) 11,
      (byte) 11,
      (byte) 11,
      (byte) 11,
      (byte) 13,
      (byte) 0,
      (byte) 15,
      (byte) 0,
      (byte) 0,
      (byte) 7,
      (byte) 9,
      (byte) 3,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 1,
      (byte) 26,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 11,
      (byte) 11,
      (byte) 0,
      (byte) 11,
      (byte) 11,
      (byte) 11,
      (byte) 1,
      (byte) 0,
      (byte) 0
    };

    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static byte[] init__json_eof_actions_0() => new byte[39]
    {
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 0
    };

    [LineNumberTable(new byte[] {159, 135, 173, 106, 106, 106, 106, 106, 106, 106, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static JsonReader()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.serialization.JsonReader"))
        return;
      JsonReader._json_actions = JsonReader.init__json_actions_0();
      JsonReader._json_key_offsets = JsonReader.init__json_key_offsets_0();
      JsonReader._json_trans_keys = JsonReader.init__json_trans_keys_0();
      JsonReader._json_single_lengths = JsonReader.init__json_single_lengths_0();
      JsonReader._json_range_lengths = JsonReader.init__json_range_lengths_0();
      JsonReader._json_index_offsets = JsonReader.init__json_index_offsets_0();
      JsonReader._json_indicies = JsonReader.init__json_indicies_0();
      JsonReader._json_trans_targs = JsonReader.init__json_trans_targs_0();
      JsonReader._json_trans_actions = JsonReader.init__json_trans_actions_0();
      JsonReader._json_eof_actions = JsonReader.init__json_eof_actions_0();
    }
  }
}
