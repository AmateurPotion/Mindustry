// Decompiled with JetBrains decompiler
// Type: rhino.NativeJavaConstructor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class NativeJavaConstructor : BaseFunction
  {
    internal MemberBox ctor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 161, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeJavaConstructor(MemberBox ctor)
    {
      NativeJavaConstructor nativeJavaConstructor = this;
      this.ctor = ctor;
    }

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object call(Context cx, Scriptable scope, Scriptable thisObj, object[] args) => (object) NativeJavaClass.constructSpecific(cx, scope, args, this.ctor);

    [LineNumberTable(new byte[] {159, 173, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getFunctionName() => String.instancehelper_concat("<init>", JavaMembers.liveConnectSignature(this.ctor.argTypes));

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[JavaConstructor ").append(this.ctor.getName()).append("]").toString();

    [HideFromJava]
    static NativeJavaConstructor() => BaseFunction.__\u003Cclinit\u003E();

    [HideFromJava]
    [NameSig("<init>", "(Lrhino.MemberBox;)V")]
    public NativeJavaConstructor([In] object obj0)
      : this((MemberBox) obj0)
    {
    }
  }
}
