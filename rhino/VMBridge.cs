// Decompiled with JetBrains decompiler
// Type: rhino.VMBridge
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using System.Runtime.CompilerServices;

namespace rhino
{
  public abstract class VMBridge : Object
  {
    [Modifiers]
    internal static VMBridge instance;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    protected internal abstract object getThreadContextHelper();

    protected internal abstract Context getContext(object obj);

    protected internal abstract void setContext(object obj, Context c);

    protected internal abstract object newInterfaceProxy(
      object obj1,
      ContextFactory cf,
      InterfaceAdapter ia,
      object obj2,
      Scriptable s);

    [Signature("(Lrhino/ContextFactory;[Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    protected internal abstract object getInterfaceProxyHelper(ContextFactory cf, Class[] carr);

    protected internal abstract bool tryToMakeAccessible(AccessibleObject ao);

    [LineNumberTable(new byte[] {159, 154, 215, 103, 100, 103, 99, 109, 100, 227, 58, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static VMBridge makeInstance()
    {
      string[] strArray = new string[2]
      {
        "rhino.VMBridge_custom",
        "rhino.jdk18.VMBridge_jdk18"
      };
      for (int index = 0; index != strArray.Length; ++index)
      {
        Class @class = Kit.classOrNull(strArray[index]);
        if (@class != null)
        {
          VMBridge vmBridge = (VMBridge) Kit.newInstanceOrNull(@class);
          if (vmBridge != null)
            return vmBridge;
        }
      }
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException("Failed to create VMBridge instance");
    }

    [LineNumberTable(7)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VMBridge()
    {
    }

    [LineNumberTable(9)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static VMBridge()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.VMBridge"))
        return;
      VMBridge.instance = VMBridge.makeInstance();
    }
  }
}
