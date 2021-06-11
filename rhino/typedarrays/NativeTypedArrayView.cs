// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.NativeTypedArrayView
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.util;
using java.util.function;
using java.util.stream;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.typedarrays
{
  [Signature("<T:Ljava/lang/Object;>Lrhino/typedarrays/NativeArrayBufferView;Ljava/util/List<TT;>;Ljava/util/RandomAccess;Lrhino/ExternalArrayData;")]
  [Implements(new string[] {"java.util.List", "java.util.RandomAccess", "rhino.ExternalArrayData"})]
  public abstract class NativeTypedArrayView : 
    NativeArrayBufferView,
    List,
    Collection,
    Iterable,
    IEnumerable,
    RandomAccess,
    ExternalArrayData
  {
    internal int __\u003C\u003Elength;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_get = 3;
    private const int Id_set = 4;
    private const int Id_subarray = 5;
    private const int SymbolId_iterator = 6;
    protected internal const int MAX_PROTOTYPE_ID = 6;
    private const int Id_length = 4;
    private const int Id_BYTES_PER_ELEMENT = 5;
    private new const int MAX_INSTANCE_ID = 5;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    protected internal abstract object js_get(int i);

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool checkIndex(int index) => index < 0 || index >= this.__\u003C\u003Elength;

    protected internal abstract object js_set(int i, object obj);

    [Signature("(Lrhino/typedarrays/NativeArrayBuffer;II)Lrhino/typedarrays/NativeTypedArrayView<TT;>;")]
    protected internal abstract NativeTypedArrayView construct(
      NativeArrayBuffer nab,
      int i1,
      int i2);

    public abstract int getBytesPerElement();

    [LineNumberTable(new byte[] {29, 112, 38})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeArrayBuffer makeArrayBuffer(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] int obj2)
    {
      return (NativeArrayBuffer) obj0.newObject(obj1, "ArrayBuffer", new object[1]
      {
        (object) Integer.valueOf(obj2)
      });
    }

    [Signature("(Lrhino/Context;Lrhino/Scriptable;[Ljava/lang/Object;)Lrhino/typedarrays/NativeTypedArrayView<TT;>;")]
    [LineNumberTable(new byte[] {34, 105, 174, 100, 99, 174, 144, 103, 113, 170, 139, 103, 118, 144, 109, 50, 168, 163, 139, 104, 182, 105, 147, 172, 113, 149, 116, 149, 116, 149, 116, 181, 188, 139, 136, 119, 113, 177, 109, 124, 122, 105, 152, 236, 55, 235, 76, 163, 136, 141, 115, 109, 106, 47, 168, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeTypedArrayView js_constructor(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] object[] obj2)
    {
      if (!NativeArrayBufferView.isArg(obj2, 0))
        return this.construct(new NativeArrayBuffer(), 0, 0);
      object val = obj2[0];
      switch (val)
      {
        case null:
          return this.construct(new NativeArrayBuffer(), 0, 0);
        case Number _:
        case string _:
          int int32 = ScriptRuntime.toInt32(val);
          return this.construct(this.makeArrayBuffer(obj0, obj1, int32 * this.getBytesPerElement()), 0, int32);
        case NativeTypedArrayView _:
          NativeTypedArrayView nativeTypedArrayView1 = (NativeTypedArrayView) val;
          NativeTypedArrayView nativeTypedArrayView2 = this.construct(this.makeArrayBuffer(obj0, obj1, nativeTypedArrayView1.__\u003C\u003Elength * this.getBytesPerElement()), 0, nativeTypedArrayView1.__\u003C\u003Elength);
          for (int i = 0; i < nativeTypedArrayView1.__\u003C\u003Elength; ++i)
            nativeTypedArrayView2.js_set(i, nativeTypedArrayView1.js_get(i));
          return nativeTypedArrayView2;
        case NativeArrayBuffer _:
          NativeArrayBuffer nativeArrayBuffer = (NativeArrayBuffer) val;
          int num1 = !NativeArrayBufferView.isArg(obj2, 1) ? 0 : ScriptRuntime.toInt32(obj2[1]);
          int num2 = !NativeArrayBufferView.isArg(obj2, 2) ? nativeArrayBuffer.getLength() - num1 : ScriptRuntime.toInt32(obj2[2]) * this.getBytesPerElement();
          if (num1 < 0 || num1 > nativeArrayBuffer.buffer.Length)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
          if (num2 < 0 || num1 + num2 > nativeArrayBuffer.buffer.Length)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "length out of range"));
          int num3 = num1;
          int bytesPerElement1 = this.getBytesPerElement();
          if ((bytesPerElement1 != -1 ? num3 % bytesPerElement1 : 0) != 0)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset must be a multiple of the byte size"));
          int num4 = num2;
          int bytesPerElement2 = this.getBytesPerElement();
          if ((bytesPerElement2 != -1 ? num4 % bytesPerElement2 : 0) != 0)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset and buffer must be a multiple of the byte size"));
          NativeArrayBuffer nab = nativeArrayBuffer;
          int i1 = num1;
          int num5 = num2;
          int bytesPerElement3 = this.getBytesPerElement();
          int i2 = bytesPerElement3 != -1 ? num5 / bytesPerElement3 : -num5;
          return this.construct(nab, i1, i2);
        case NativeArray _:
          NativeArray nativeArray = (NativeArray) val;
          NativeTypedArrayView nativeTypedArrayView3 = this.construct(this.makeArrayBuffer(obj0, obj1, nativeArray.size() * this.getBytesPerElement()), 0, nativeArray.size());
          for (int index = 0; index < nativeArray.size(); ++index)
          {
            object objA = nativeArray.get(index, (Scriptable) nativeArray);
            if (object.ReferenceEquals(objA, Scriptable.NOT_FOUND) || object.ReferenceEquals(objA, Undefined.__\u003C\u003Einstance))
              nativeTypedArrayView3.js_set(index, (object) Double.valueOf(double.NaN));
            else if (objA is Wrapper)
              nativeTypedArrayView3.js_set(index, ((Wrapper) objA).unwrap());
            else
              nativeTypedArrayView3.js_set(index, objA);
          }
          return nativeTypedArrayView3;
        default:
          object[] objArray = ScriptRuntime.isArrayObject(val) ? ScriptRuntime.getArrayElements((Scriptable) val) : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("Error", "invalid argument"));
          NativeTypedArrayView nativeTypedArrayView4 = this.construct(this.makeArrayBuffer(obj0, obj1, objArray.Length * this.getBytesPerElement()), 0, objArray.Length);
          for (int i = 0; i < objArray.Length; ++i)
            nativeTypedArrayView4.js_set(i, objArray[i]);
          return nativeTypedArrayView4;
      }
    }

    [Signature("(Lrhino/Scriptable;Lrhino/IdFunctionObject;)Lrhino/typedarrays/NativeTypedArrayView<TT;>;")]
    protected internal abstract NativeTypedArrayView realThis(
      Scriptable s,
      IdFunctionObject ifo);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getArrayLength() => this.__\u003C\u003Elength;

    [Signature("(Lrhino/typedarrays/NativeTypedArrayView<TT;>;I)V")]
    [LineNumberTable(new byte[] {126, 105, 181, 112, 181, 150, 108, 107, 42, 166, 107, 45, 166, 98, 107, 49, 198})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setRange([In] NativeTypedArrayView obj0, [In] int obj1)
    {
      if (obj1 >= this.__\u003C\u003Elength)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
      if (obj0.__\u003C\u003Elength > this.__\u003C\u003Elength - obj1)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "source array too long"));
      if (object.ReferenceEquals((object) obj0.__\u003C\u003EarrayBuffer, (object) this.__\u003C\u003EarrayBuffer))
      {
        object[] objArray = new object[obj0.__\u003C\u003Elength];
        for (int i = 0; i < obj0.__\u003C\u003Elength; ++i)
          objArray[i] = obj0.js_get(i);
        for (int index = 0; index < obj0.__\u003C\u003Elength; ++index)
          this.js_set(index + obj1, objArray[index]);
      }
      else
      {
        for (int i = 0; i < obj0.__\u003C\u003Elength; ++i)
          this.js_set(i + obj1, obj0.js_get(i));
      }
    }

    [LineNumberTable(new byte[] {160, 87, 105, 149, 112, 181, 98, 118, 105, 100, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setRange([In] NativeArray obj0, [In] int obj1)
    {
      if (obj1 > this.__\u003C\u003Elength)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset out of range"));
      if (obj1 + obj0.size() > this.__\u003C\u003Elength)
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("RangeError", "offset + length out of range"));
      int i = obj1;
      Iterator iterator = obj0.iterator();
      while (iterator.hasNext())
      {
        object obj = iterator.next();
        this.js_set(i, obj);
        ++i;
      }
    }

    [LineNumberTable(new byte[] {160, 102, 112, 179, 104, 109, 106, 153, 99, 119, 47, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_subarray([In] Context obj0, [In] Scriptable obj1, [In] int obj2, [In] int obj3)
    {
      int num1 = obj2 >= 0 ? obj2 : this.__\u003C\u003Elength + obj2;
      int num2 = obj3 >= 0 ? obj3 : this.__\u003C\u003Elength + obj3;
      int num3 = Math.max(0, num1);
      int num4 = Math.max(0, Math.min(this.__\u003C\u003Elength, num2) - num3);
      int num5 = Math.min(num3 * this.getBytesPerElement(), this.__\u003C\u003EarrayBuffer.getLength());
      return (object) obj0.newObject(obj1, this.getClassName(), new object[3]
      {
        (object) this.__\u003C\u003EarrayBuffer,
        (object) Integer.valueOf(num5),
        (object) Integer.valueOf(num4)
      });
    }

    [LineNumberTable(582)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(object o) => this.indexOf(o) >= 0;

    [LineNumberTable(new byte[] {161, 146, 107, 111, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int indexOf(object o)
    {
      for (int i = 0; i < this.__\u003C\u003Elength; ++i)
      {
        if (Object.instancehelper_equals(o, this.js_get(i)))
          return i;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {159, 161, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal NativeTypedArrayView()
    {
      NativeTypedArrayView nativeTypedArrayView = this;
      this.__\u003C\u003Elength = 0;
    }

    [LineNumberTable(new byte[] {159, 166, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal NativeTypedArrayView(NativeArrayBuffer ab, int off, int len, int byteLen)
      : base(ab, off, byteLen)
    {
      NativeTypedArrayView nativeTypedArrayView = this;
      this.__\u003C\u003Elength = len;
    }

    [LineNumberTable(32)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(int index, Scriptable start) => this.js_get(index);

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(int index, Scriptable start) => !this.checkIndex(index);

    [LineNumberTable(new byte[] {159, 184, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(int index, Scriptable start, object val) => this.js_set(index, val);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void delete(int index)
    {
    }

    [LineNumberTable(new byte[] {1, 108, 107, 41, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object[] getIds()
    {
      object[] objArray = new object[this.__\u003C\u003Elength];
      for (int index = 0; index < this.__\u003C\u003Elength; ++index)
        objArray[index] = (object) Integer.valueOf(index);
      return objArray;
    }

    [LineNumberTable(new byte[] {160, 121, 110, 142, 103, 159, 6, 171, 106, 103, 102, 100, 147, 104, 105, 20, 200, 167, 102, 152, 181, 105, 107, 107, 120, 114, 134, 107, 120, 114, 134, 139, 134, 106, 181, 181, 102, 107, 107, 126, 142, 181, 147})]
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
      int num1 = f.methodId();
      switch (num1)
      {
        case 1:
          return (object) this.js_constructor(cx, scope, args);
        case 2:
          NativeTypedArrayView nativeTypedArrayView1 = this.realThis(thisObj, f);
          int arrayLength = nativeTypedArrayView1.getArrayLength();
          StringBuilder stringBuilder = new StringBuilder();
          if (arrayLength > 0)
            stringBuilder.append(ScriptRuntime.toString(nativeTypedArrayView1.js_get(0)));
          for (int i = 1; i < arrayLength; ++i)
          {
            stringBuilder.append(',');
            stringBuilder.append(ScriptRuntime.toString(nativeTypedArrayView1.js_get(i)));
          }
          return (object) stringBuilder.toString();
        case 3:
          if (args.Length > 0)
            return this.realThis(thisObj, f).js_get(ScriptRuntime.toInt32(args[0]));
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("Error", "invalid arguments"));
        case 4:
          if (args.Length > 0)
          {
            NativeTypedArrayView nativeTypedArrayView2 = this.realThis(thisObj, f);
            if (args[0] is NativeTypedArrayView)
            {
              int num2 = !NativeArrayBufferView.isArg(args, 1) ? 0 : ScriptRuntime.toInt32(args[1]);
              nativeTypedArrayView2.setRange((NativeTypedArrayView) args[0], num2);
              return Undefined.__\u003C\u003Einstance;
            }
            if (args[0] is NativeArray)
            {
              int num2 = !NativeArrayBufferView.isArg(args, 1) ? 0 : ScriptRuntime.toInt32(args[1]);
              nativeTypedArrayView2.setRange((NativeArray) args[0], num2);
              return Undefined.__\u003C\u003Einstance;
            }
            if (args[0] is Scriptable)
              return Undefined.__\u003C\u003Einstance;
            if (NativeArrayBufferView.isArg(args, 2))
              return nativeTypedArrayView2.js_set(ScriptRuntime.toInt32(args[0]), args[1]);
          }
          throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("Error", "invalid arguments"));
        case 5:
          if (args.Length <= 0)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("Error", "invalid arguments"));
          NativeTypedArrayView nativeTypedArrayView3 = this.realThis(thisObj, f);
          int int32 = ScriptRuntime.toInt32(args[0]);
          int num3 = !NativeArrayBufferView.isArg(args, 1) ? nativeTypedArrayView3.__\u003C\u003Elength : ScriptRuntime.toInt32(args[1]);
          return nativeTypedArrayView3.js_subarray(cx, scope, int32, num3);
        case 6:
          NativeArrayIterator.__\u003Cclinit\u003E();
          return (object) new NativeArrayIterator(scope, thisObj, NativeArrayIterator.ARRAY_ITERATOR_TYPE.__\u003C\u003EVALUES);
        default:
          string str = String.valueOf(num1);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 188, 100, 121, 161, 130, 158, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      if (id == 6)
      {
        this.initPrototypeMethod((object) this.getClassName(), id, (Symbol) SymbolKey.__\u003C\u003EITERATOR, "[Symbol.iterator]", 0);
      }
      else
      {
        int arity;
        string propertyName;
        switch (id - 1)
        {
          case 0:
            arity = 3;
            propertyName = "constructor";
            break;
          case 1:
            arity = 0;
            propertyName = "toString";
            break;
          case 2:
            arity = 1;
            propertyName = "get";
            break;
          case 3:
            arity = 2;
            propertyName = "set";
            break;
          case 4:
            arity = 2;
            propertyName = "subarray";
            break;
          default:
            string str = String.valueOf(id);
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
        }
        this.initPrototypeMethod((object) this.getClassName(), id, propertyName, (string) null, arity);
      }
    }

    [LineNumberTable(new byte[] {160, 224, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(Symbol k) => SymbolKey.__\u003C\u003EITERATOR.equals((object) k) ? 6 : 0;

    [LineNumberTable(new byte[] {160, 238, 98, 130, 103, 100, 104, 101, 124, 98, 133, 104, 121, 98, 165, 100, 104, 101, 102, 100, 101, 102, 132, 101, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 3:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'g':
              if (String.instancehelper_charAt(s, 2) == 't' && String.instancehelper_charAt(s, 1) == 'e')
              {
                num = 3;
                break;
              }
              goto label_10;
            case 's':
              if (String.instancehelper_charAt(s, 2) == 't' && String.instancehelper_charAt(s, 1) == 'e')
              {
                num = 4;
                break;
              }
              goto label_10;
            default:
              goto label_10;
          }
          break;
        case 8:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 's':
              str = "subarray";
              num = 5;
              goto label_10;
            case 't':
              str = "toString";
              num = 2;
              goto label_10;
            default:
              goto label_10;
          }
        case 11:
          str = "constructor";
          num = 1;
          goto default;
        default:
label_10:
          if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
          {
            num = 0;
            break;
          }
          break;
      }
      return num;
    }

    [LineNumberTable(new byte[] {161, 36, 183, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties(IdFunctionObject ctor)
    {
      ctor.defineProperty("BYTES_PER_ELEMENT", (object) ScriptRuntime.wrapInt(this.getBytesPerElement()), 7);
      base.fillConstructorProperties(ctor);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getMaxInstanceId() => 5;

    [LineNumberTable(new byte[] {161, 51, 146, 134, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getInstanceIdName(int id)
    {
      switch (id)
      {
        case 4:
          return "length";
        case 5:
          return "BYTES_PER_ELEMENT";
        default:
          return base.getInstanceIdName(id);
      }
    }

    [LineNumberTable(new byte[] {161, 63, 146, 140, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue(int id)
    {
      switch (id)
      {
        case 4:
          return (object) ScriptRuntime.wrapInt(this.__\u003C\u003Elength);
        case 5:
          return (object) ScriptRuntime.wrapInt(this.getBytesPerElement());
        default:
          return base.getInstanceIdValue(id);
      }
    }

    [LineNumberTable(new byte[] {161, 81, 98, 98, 103, 100, 102, 100, 101, 102, 130, 183, 99, 136, 100, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo(string s)
    {
      int id = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 6:
          str = "length";
          id = 4;
          break;
        case 17:
          str = "BYTES_PER_ELEMENT";
          id = 5;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        id = 0;
      if (id == 0)
        return base.findInstanceIdInfo(s);
      return id == 5 ? IdScriptableObject.instanceIdInfo(7, id) : IdScriptableObject.instanceIdInfo(5, id);
    }

    [LineNumberTable(487)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getArrayElement(int index) => this.js_get(index);

    [LineNumberTable(new byte[] {161, 122, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setArrayElement(int index, object value) => this.js_set(index, value);

    [Signature("(Ljava/util/Collection<*>;)Z")]
    [LineNumberTable(new byte[] {161, 135, 118, 105, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsAll(Collection objects)
    {
      Iterator iterator = objects.iterator();
      while (iterator.hasNext())
      {
        if (!this.contains(iterator.next()))
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {161, 157, 109, 111, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int lastIndexOf(object o)
    {
      for (int i = this.__\u003C\u003Elength - 1; i >= 0; i += -1)
      {
        if (Object.instancehelper_equals(o, this.js_get(i)))
          return i;
      }
      return -1;
    }

    [LineNumberTable(new byte[] {161, 168, 108, 107, 42, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] toArray()
    {
      object[] objArray = new object[this.__\u003C\u003Elength];
      for (int i = 0; i < this.__\u003C\u003Elength; ++i)
        objArray[i] = this.js_get(i);
      return objArray;
    }

    [Signature("<U:Ljava/lang/Object;>([TU;)[TU;")]
    [LineNumberTable(new byte[] {161, 180, 106, 132, 191, 2, 139, 191, 0, 2, 97, 235, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object[] toArray(object[] ts)
    {
      object[] objArray = ts.Length < this.__\u003C\u003Elength ? (object[]) Array.newInstance(Object.instancehelper_getClass((object) ts).getComponentType(), this.__\u003C\u003Elength) : ts;
      for (int i = 0; i < this.__\u003C\u003Elength; ++i)
      {
        try
        {
          objArray[i] = this.js_get(i);
          continue;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<ClassCastException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArrayStoreException();
      }
      return objArray;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int size() => this.__\u003C\u003Elength;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isEmpty() => this.__\u003C\u003Elength == 0;

    [LineNumberTable(new byte[] {161, 218, 99, 162, 103, 110, 132, 107, 117, 4, 230, 69, 126, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o)
    {
      if (o == null)
        return false;
      int num;
      try
      {
        NativeTypedArrayView nativeTypedArrayView = (NativeTypedArrayView) o;
        if (this.__\u003C\u003Elength != nativeTypedArrayView.__\u003C\u003Elength)
          return false;
        for (int i = 0; i < this.__\u003C\u003Elength; ++i)
        {
          if (!Object.instancehelper_equals(this.js_get(i), nativeTypedArrayView.js_get(i)))
            return false;
        }
        num = 1;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<ClassCastException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_13;
      }
      return num != 0;
label_13:
      return false;
    }

    [LineNumberTable(new byte[] {161, 239, 98, 107, 47, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      int num = 0;
      for (int i = 0; i < this.__\u003C\u003Elength; ++i)
        num += Object.instancehelper_hashCode(this.js_get(i));
      return num;
    }

    [Signature("()Ljava/util/Iterator<TT;>;")]
    [LineNumberTable(619)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterator iterator() => (Iterator) new NativeTypedArrayIterator(this, 0);

    [Signature("()Ljava/util/ListIterator<TT;>;")]
    [LineNumberTable(625)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ListIterator listIterator() => (ListIterator) new NativeTypedArrayIterator(this, 0);

    [Signature("(I)Ljava/util/ListIterator<TT;>;")]
    [LineNumberTable(new byte[] {162, 5, 105, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ListIterator listIterator(int start)
    {
      if (this.checkIndex(start))
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IndexOutOfBoundsException();
      }
      return (ListIterator) new NativeTypedArrayIterator(this, start);
    }

    [Signature("(II)Ljava/util/List<TT;>;")]
    [LineNumberTable(640)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual List subList(int i, int i2)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("(TT;)Z")]
    [LineNumberTable(646)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool add(object aByte)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("(ITT;)V")]
    [LineNumberTable(652)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void add(int i, object aByte)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("(Ljava/util/Collection<+TT;>;)Z")]
    [LineNumberTable(658)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addAll(Collection bytes)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("(ILjava/util/Collection<+TT;>;)Z")]
    [LineNumberTable(664)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool addAll(int i, Collection bytes)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(670)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("(I)TT;")]
    [LineNumberTable(676)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object remove(int i)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(682)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool remove(object o)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("(Ljava/util/Collection<*>;)Z")]
    [LineNumberTable(688)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeAll(Collection objects)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [Signature("(Ljava/util/Collection<*>;)Z")]
    [LineNumberTable(694)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool retainAll(Collection objects)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [HideFromJava]
    public virtual void forEach([In] Consumer obj0) => Iterable.\u003Cdefault\u003EforEach((Iterable) this, obj0);

    [HideFromJava]
    public virtual Spliterator spliterator() => List.\u003Cdefault\u003Espliterator((List) this);

    [HideFromJava]
    public virtual bool removeIf([In] Predicate obj0) => Collection.\u003Cdefault\u003EremoveIf((Collection) this, obj0);

    [HideFromJava]
    public virtual Stream stream() => Collection.\u003Cdefault\u003Estream((Collection) this);

    [HideFromJava]
    public virtual Stream parallelStream() => Collection.\u003Cdefault\u003EparallelStream((Collection) this);

    [HideFromJava]
    public abstract object get([In] int obj0);

    [HideFromJava]
    public abstract object set([In] int obj0, [In] object obj1);

    [HideFromJava]
    public virtual void replaceAll([In] UnaryOperator obj0) => List.\u003Cdefault\u003EreplaceAll((List) this, obj0);

    [HideFromJava]
    public virtual void sort([In] Comparator obj0) => List.\u003Cdefault\u003Esort((List) this, obj0);

    [HideFromJava]
    static NativeTypedArrayView() => NativeArrayBufferView.__\u003Cclinit\u003E();

    [HideFromJava]
    [SpecialName]
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

    [Modifiers]
    protected internal int length
    {
      [HideFromJava] get => this.__\u003C\u003Elength;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Elength = value;
    }
  }
}
