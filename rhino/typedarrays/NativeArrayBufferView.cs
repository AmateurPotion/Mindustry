// Decompiled with JetBrains decompiler
// Type: rhino.typedarrays.NativeArrayBufferView
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino.typedarrays
{
  public abstract class NativeArrayBufferView : IdScriptableObject
  {
    private static Boolean useLittleEndian;
    internal NativeArrayBuffer __\u003C\u003EarrayBuffer;
    internal int __\u003C\u003Eoffset;
    internal int __\u003C\u003EbyteLength;
    private const int Id_buffer = 1;
    private const int Id_byteOffset = 2;
    private const int Id_byteLength = 3;
    protected internal const int MAX_INSTANCE_ID = 3;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 104, 107, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeArrayBufferView()
    {
      NativeArrayBufferView nativeArrayBufferView = this;
      this.__\u003C\u003EarrayBuffer = new NativeArrayBuffer();
      this.__\u003C\u003Eoffset = 0;
      this.__\u003C\u003EbyteLength = 0;
    }

    [LineNumberTable(new byte[] {159, 169, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal NativeArrayBufferView(NativeArrayBuffer ab, int offset, int byteLength)
    {
      NativeArrayBufferView nativeArrayBufferView = this;
      this.__\u003C\u003Eoffset = offset;
      this.__\u003C\u003EbyteLength = byteLength;
      this.__\u003C\u003EarrayBuffer = ab;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual NativeArrayBuffer getBuffer() => this.__\u003C\u003EarrayBuffer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getByteOffset() => this.__\u003C\u003Eoffset;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getByteLength() => this.__\u003C\u003EbyteLength;

    [LineNumberTable(new byte[] {5, 103, 134, 99, 130, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static bool useLittleEndian()
    {
      if (NativeArrayBufferView.useLittleEndian == null)
      {
        Context currentContext = Context.getCurrentContext();
        if (currentContext == null)
          return false;
        NativeArrayBufferView.useLittleEndian = Boolean.valueOf(currentContext.hasFeature(19));
      }
      return NativeArrayBufferView.useLittleEndian.booleanValue();
    }

    [LineNumberTable(67)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static bool isArg(object[] args, int i) => args.Length > i && !Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, args[i]);

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getMaxInstanceId() => 3;

    [LineNumberTable(new byte[] {29, 150, 134, 134, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override string getInstanceIdName(int id)
    {
      switch (id)
      {
        case 1:
          return "buffer";
        case 2:
          return "byteOffset";
        case 3:
          return "byteLength";
        default:
          return base.getInstanceIdName(id);
      }
    }

    [LineNumberTable(new byte[] {43, 150, 135, 140, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object getInstanceIdValue(int id)
    {
      switch (id)
      {
        case 1:
          return (object) this.__\u003C\u003EarrayBuffer;
        case 2:
          return (object) ScriptRuntime.wrapInt(this.__\u003C\u003Eoffset);
        case 3:
          return (object) ScriptRuntime.wrapInt(this.__\u003C\u003EbyteLength);
        default:
          return base.getInstanceIdValue(id);
      }
    }

    [LineNumberTable(new byte[] {63, 98, 130, 103, 100, 102, 100, 101, 104, 101, 102, 100, 101, 102, 162, 183, 99, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findInstanceIdInfo(string s)
    {
      int id = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 6:
          str = "buffer";
          id = 1;
          break;
        case 10:
          switch (String.instancehelper_charAt(s, 4))
          {
            case 'L':
              str = "byteLength";
              id = 3;
              break;
            case 'O':
              str = "byteOffset";
              id = 2;
              break;
          }
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        id = 0;
      return id == 0 ? base.findInstanceIdInfo(s) : IdScriptableObject.instanceIdInfo(5, id);
    }

    [HideFromJava]
    static NativeArrayBufferView() => IdScriptableObject.__\u003Cclinit\u003E();

    [Modifiers]
    protected internal NativeArrayBuffer arrayBuffer
    {
      [HideFromJava] get => this.__\u003C\u003EarrayBuffer;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EarrayBuffer = value;
    }

    [Modifiers]
    protected internal int offset
    {
      [HideFromJava] get => this.__\u003C\u003Eoffset;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eoffset = value;
    }

    [Modifiers]
    protected internal int byteLength
    {
      [HideFromJava] get => this.__\u003C\u003EbyteLength;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EbyteLength = value;
    }
  }
}
