// Decompiled with JetBrains decompiler
// Type: rhino.RhinoSecurityManager
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino
{
  public class RhinoSecurityManager : SecurityManager
  {
    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(11)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public RhinoSecurityManager()
    {
    }

    [Signature("()Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {159, 161, 103, 112, 127, 4, 103, 227, 61, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Class getCurrentScriptClass()
    {
      Class[] classContext = this.getClassContext();
      int length = classContext.Length;
      for (int index = 0; index < length; ++index)
      {
        Class @class = classContext[index];
        if (!object.ReferenceEquals((object) @class, (object) ClassLiteral<InterpretedFunction>.Value) && ((Class) ClassLiteral<NativeFunction>.Value).isAssignableFrom(@class) || ((Class) ClassLiteral<PolicySecurityController.SecureCaller>.Value).isAssignableFrom(@class))
          return @class;
      }
      return (Class) null;
    }

    [HideFromJava]
    static RhinoSecurityManager() => SecurityManager.__\u003Cclinit\u003E();
  }
}
