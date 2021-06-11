// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.NativeDataView
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.typedarrays
{
  public class NativeDataView : NativeArrayBufferView
  {
    public const string CLASS_NAME = "DataView";
    private const int Id_constructor = 1;
    private const int Id_getInt8 = 2;
    private const int Id_getUint8 = 3;
    private const int Id_getInt16 = 4;
    private const int Id_getUint16 = 5;
    private const int Id_getInt32 = 6;
    private const int Id_getUint32 = 7;
    private const int Id_getFloat32 = 8;
    private const int Id_getFloat64 = 9;
    private const int Id_setInt8 = 10;
    private const int Id_setUint8 = 11;
    private const int Id_setInt16 = 12;
    private const int Id_setUint16 = 13;
    private const int Id_setInt32 = 14;
    private const int Id_setUint32 = 15;
    private const int Id_setFloat32 = 16;
    private const int Id_setFloat64 = 17;
    private const int MAX_PROTOTYPE_ID = 17;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 158, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeDataView()
    {
    }

    [LineNumberTable(new byte[] {159, 162, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeDataView(NativeArrayBuffer ab, int offset, int length)
      : base(ab, offset, length)
    {
    }

    [LineNumberTable(new byte[] {159, 176, 105, 107, 104, 149, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int determinePos([In] object[] obj0)
    {
      if (!NativeArrayBufferView.isArg(obj0, 0))
        return 0;
      double number = ScriptRuntime.toNumber(obj0[0]);
      return !Double.isInfinite(number) ? ScriptRuntime.toInt32(number) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
    }

    [LineNumberTable(new byte[] {159, 187, 111, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void rangeCheck([In] int obj0, [In] int obj1)
    {
      if (obj0 < 0 || obj0 + obj1 > this.__\u003C\u003EbyteLength)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "DataView";

    [LineNumberTable(new byte[] {7, 115, 181, 169, 105, 107, 104, 149, 103, 98, 194, 105, 107, 104, 149, 104, 98, 170, 101, 149, 112, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeDataView js_constructor([In] object[] obj0)
    {
      NativeArrayBuffer ab = NativeArrayBufferView.isArg(obj0, 0) && obj0[0] is NativeArrayBuffer ? (NativeArrayBuffer) obj0[0] : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("TypeError", "Missing parameters"));
      int offset;
      if (NativeArrayBufferView.isArg(obj0, 1))
      {
        double number = ScriptRuntime.toNumber(obj0[1]);
        offset = !Double.isInfinite(number) ? ScriptRuntime.toInt32(number) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
      }
      else
        offset = 0;
      int length;
      if (NativeArrayBufferView.isArg(obj0, 2))
      {
        double number = ScriptRuntime.toNumber(obj0[2]);
        length = !Double.isInfinite(number) ? ScriptRuntime.toInt32(number) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
      }
      else
        length = ab.getLength() - offset;
      if (length < 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "length out of range"));
      if (offset < 0 || offset + length > ab.getLength())
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
      return new NativeDataView(ab, offset, length);
    }

    [LineNumberTable(new byte[] {1, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeDataView realThis([In] Scriptable obj0, [In] IdFunctionObject obj1) => obj0 is NativeDataView ? (NativeDataView) obj0 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));

    [LineNumberTable(new byte[] {159, 119, 162, 104, 136, 156, 157, 127, 17, 37, 161, 127, 19, 37, 161, 127, 19, 37, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_getInt([In] int obj0, [In] bool obj1, [In] object[] obj2)
    {
      int num1 = obj1 ? 1 : 0;
      int pos = this.determinePos(obj2);
      this.rangeCheck(pos, obj0);
      int num2 = !NativeArrayBufferView.isArg(obj2, 1) || obj0 <= 1 || !ScriptRuntime.toBoolean(obj2[1]) ? 0 : 1;
      switch (obj0)
      {
        case 1:
          return num1 != 0 ? ByteIo.readInt8(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos) : ByteIo.readUint8(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos);
        case 2:
          return num1 != 0 ? ByteIo.readInt16(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, num2 != 0) : ByteIo.readUint16(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, num2 != 0);
        case 4:
          return num1 != 0 ? ByteIo.readInt32(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, num2 != 0) : ByteIo.readUint32(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, num2 != 0);
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
      }
    }

    [LineNumberTable(new byte[] {66, 104, 136, 156, 146, 154, 154})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_getFloat([In] int obj0, [In] object[] obj1)
    {
      int pos = this.determinePos(obj1);
      this.rangeCheck(pos, obj0);
      int num = !NativeArrayBufferView.isArg(obj1, 1) || obj0 <= 1 || !ScriptRuntime.toBoolean(obj1[1]) ? 0 : 1;
      switch (obj0)
      {
        case 4:
          return ByteIo.readFloat32(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, num != 0);
        case 8:
          return ByteIo.readFloat64(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, num != 0);
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
      }
    }

    [LineNumberTable(new byte[] {159, 109, 66, 104, 100, 181, 156, 103, 101, 164, 157, 99, 104, 107, 149, 122, 101, 104, 107, 149, 154, 133, 99, 104, 107, 149, 123, 101, 104, 107, 149, 155, 133, 99, 104, 107, 149, 123, 98, 104, 107, 149, 155, 130, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void js_setInt([In] int obj0, [In] bool obj1, [In] object[] obj2)
    {
      int num1 = obj1 ? 1 : 0;
      int pos = this.determinePos(obj2);
      if (pos < 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
      int num2 = !NativeArrayBufferView.isArg(obj2, 2) || obj0 <= 1 || !ScriptRuntime.toBoolean(obj2[2]) ? 0 : 1;
      object obj = (object) Integer.valueOf(0);
      if (obj2.Length > 1)
        obj = obj2[1];
      switch (obj0)
      {
        case 1:
          if (num1 != 0)
          {
            int int8 = Conversions.toInt8(obj);
            if (pos + obj0 > this.__\u003C\u003EbyteLength)
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
            ByteIo.writeInt8(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, int8);
            break;
          }
          int uint8 = Conversions.toUint8(obj);
          if (pos + obj0 > this.__\u003C\u003EbyteLength)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
          ByteIo.writeUint8(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, uint8);
          break;
        case 2:
          if (num1 != 0)
          {
            int int16 = Conversions.toInt16(obj);
            if (pos + obj0 > this.__\u003C\u003EbyteLength)
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
            ByteIo.writeInt16(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, int16, num2 != 0);
            break;
          }
          int uint16 = Conversions.toUint16(obj);
          if (pos + obj0 > this.__\u003C\u003EbyteLength)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
          ByteIo.writeUint16(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, uint16, num2 != 0);
          break;
        case 4:
          if (num1 != 0)
          {
            int int32 = Conversions.toInt32(obj);
            if (pos + obj0 > this.__\u003C\u003EbyteLength)
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
            ByteIo.writeInt32(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, int32, num2 != 0);
            break;
          }
          long uint32 = Conversions.toUint32(obj);
          if (pos + obj0 > this.__\u003C\u003EbyteLength)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
          ByteIo.writeUint32(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, uint32, num2 != 0);
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
      }
    }

    [LineNumberTable(new byte[] {160, 82, 104, 100, 181, 156, 106, 101, 171, 107, 181, 146, 122, 130, 122, 130, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void js_setFloat([In] int obj0, [In] object[] obj1)
    {
      int pos = this.determinePos(obj1);
      if (pos < 0)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
      int num = !NativeArrayBufferView.isArg(obj1, 2) || obj0 <= 1 || !ScriptRuntime.toBoolean(obj1[2]) ? 0 : 1;
      double val = double.NaN;
      if (obj1.Length > 1)
        val = ScriptRuntime.toNumber(obj1[1]);
      if (pos + obj0 > this.__\u003C\u003EbyteLength)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
      switch (obj0)
      {
        case 4:
          ByteIo.writeFloat32(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, val, num != 0);
          break;
        case 8:
          ByteIo.writeFloat64(this.__\u003C\u003EarrayBuffer.buffer, this.__\u003C\u003Eoffset + pos, val, num != 0);
          break;
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
      }
    }

    [LineNumberTable(new byte[] {159, 135, 98, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      new NativeDataView().exportAsJSClass(17, scope, num != 0);
    }

    [LineNumberTable(new byte[] {160, 115, 110, 142, 103, 159, 50, 137, 146, 146, 146, 146, 146, 146, 145, 145, 113, 134, 113, 134, 113, 134, 113, 134, 113, 134, 113, 134, 112, 134, 112, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag((object) this.getClassName()))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      switch (num)
      {
        case 1:
          return (object) this.js_constructor(args);
        case 2:
          return NativeDataView.realThis(thisObj, f).js_getInt(1, true, args);
        case 3:
          return NativeDataView.realThis(thisObj, f).js_getInt(1, false, args);
        case 4:
          return NativeDataView.realThis(thisObj, f).js_getInt(2, true, args);
        case 5:
          return NativeDataView.realThis(thisObj, f).js_getInt(2, false, args);
        case 6:
          return NativeDataView.realThis(thisObj, f).js_getInt(4, true, args);
        case 7:
          return NativeDataView.realThis(thisObj, f).js_getInt(4, false, args);
        case 8:
          return NativeDataView.realThis(thisObj, f).js_getFloat(4, args);
        case 9:
          return NativeDataView.realThis(thisObj, f).js_getFloat(8, args);
        case 10:
          NativeDataView.realThis(thisObj, f).js_setInt(1, true, args);
          return Undefined.__\u003C\u003Einstance;
        case 11:
          NativeDataView.realThis(thisObj, f).js_setInt(1, false, args);
          return Undefined.__\u003C\u003Einstance;
        case 12:
          NativeDataView.realThis(thisObj, f).js_setInt(2, true, args);
          return Undefined.__\u003C\u003Einstance;
        case 13:
          NativeDataView.realThis(thisObj, f).js_setInt(2, false, args);
          return Undefined.__\u003C\u003Einstance;
        case 14:
          NativeDataView.realThis(thisObj, f).js_setInt(4, true, args);
          return Undefined.__\u003C\u003Einstance;
        case 15:
          NativeDataView.realThis(thisObj, f).js_setInt(4, false, args);
          return Undefined.__\u003C\u003Einstance;
        case 16:
          NativeDataView.realThis(thisObj, f).js_setFloat(4, args);
          return Undefined.__\u003C\u003Einstance;
        case 17:
          NativeDataView.realThis(thisObj, f).js_setFloat(8, args);
          return Undefined.__\u003C\u003Einstance;
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 170, 159, 50, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 3;
          name = "constructor";
          break;
        case 2:
          arity = 1;
          name = "getInt8";
          break;
        case 3:
          arity = 1;
          name = "getUint8";
          break;
        case 4:
          arity = 1;
          name = "getInt16";
          break;
        case 5:
          arity = 1;
          name = "getUint16";
          break;
        case 6:
          arity = 1;
          name = "getInt32";
          break;
        case 7:
          arity = 1;
          name = "getUint32";
          break;
        case 8:
          arity = 1;
          name = "getFloat32";
          break;
        case 9:
          arity = 1;
          name = "getFloat64";
          break;
        case 10:
          arity = 2;
          name = "setInt8";
          break;
        case 11:
          arity = 2;
          name = "setUint8";
          break;
        case 12:
          arity = 2;
          name = "setInt16";
          break;
        case 13:
          arity = 2;
          name = "setUint16";
          break;
        case 14:
          arity = 2;
          name = "setInt32";
          break;
        case 15:
          arity = 2;
          name = "setUint32";
          break;
        case 16:
          arity = 2;
          name = "setFloat32";
          break;
        case 17:
          arity = 2;
          name = "setFloat64";
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod((object) this.getClassName(), id, name, arity);
    }

    [LineNumberTable(new byte[] {160, 253, 98, 162, 159, 7, 104, 101, 102, 103, 104, 102, 200, 104, 101, 104, 101, 102, 103, 104, 102, 136, 101, 104, 101, 102, 103, 104, 102, 136, 104, 104, 101, 102, 103, 104, 102, 232, 69, 104, 101, 104, 101, 102, 103, 104, 102, 135, 104, 104, 101, 102, 104, 104, 102, 232, 69, 104, 101, 105, 101, 102, 103, 101, 102, 133, 101, 105, 101, 102, 101, 101, 102, 229, 69, 102, 162, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 7:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'g':
              str = "getInt8";
              num = 2;
              break;
            case 's':
              str = "setInt8";
              num = 10;
              break;
          }
          break;
        case 8:
          switch (String.instancehelper_charAt(s, 6))
          {
            case '1':
              switch (String.instancehelper_charAt(s, 0))
              {
                case 'g':
                  str = "getInt16";
                  num = 4;
                  break;
                case 's':
                  str = "setInt16";
                  num = 12;
                  break;
              }
              break;
            case '3':
              switch (String.instancehelper_charAt(s, 0))
              {
                case 'g':
                  str = "getInt32";
                  num = 6;
                  break;
                case 's':
                  str = "setInt32";
                  num = 14;
                  break;
              }
              break;
            case 't':
              switch (String.instancehelper_charAt(s, 0))
              {
                case 'g':
                  str = "getUint8";
                  num = 3;
                  break;
                case 's':
                  str = "setUint8";
                  num = 11;
                  break;
              }
              break;
          }
          break;
        case 9:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'g':
              switch (String.instancehelper_charAt(s, 8))
              {
                case '2':
                  str = "getUint32";
                  num = 7;
                  break;
                case '6':
                  str = "getUint16";
                  num = 5;
                  break;
              }
              break;
            case 's':
              switch (String.instancehelper_charAt(s, 8))
              {
                case '2':
                  str = "setUint32";
                  num = 15;
                  break;
                case '6':
                  str = "setUint16";
                  num = 13;
                  break;
              }
              break;
          }
          break;
        case 10:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'g':
              switch (String.instancehelper_charAt(s, 9))
              {
                case '2':
                  str = "getFloat32";
                  num = 8;
                  break;
                case '4':
                  str = "getFloat64";
                  num = 9;
                  break;
              }
              break;
            case 's':
              switch (String.instancehelper_charAt(s, 9))
              {
                case '2':
                  str = "setFloat32";
                  num = 16;
                  break;
                case '4':
                  str = "setFloat64";
                  num = 17;
                  break;
              }
              break;
          }
          break;
        case 11:
          str = "constructor";
          num = 1;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [HideFromJava]
    static NativeDataView() => NativeArrayBufferView.__\u003Cclinit\u003E();
  }
}
