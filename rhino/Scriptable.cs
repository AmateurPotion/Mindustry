// Decompiled with JetBrains decompiler
// Type: rhino.Scriptable
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace rhino
{
  public interface Scriptable
  {
    static readonly object NOT_FOUND;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void __\u003Cclinit\u003E()
    {
    }

    string getClassName();

    object get(string str, Scriptable s);

    object get(int i, Scriptable s);

    bool has(string str, Scriptable s);

    bool has(int i, Scriptable s);

    void put(string str, Scriptable s, object obj);

    void put(int i, Scriptable s, object obj);

    void delete(string str);

    void delete(int i);

    Scriptable getPrototype();

    void setPrototype(Scriptable s);

    Scriptable getParentScope();

    void setParentScope(Scriptable s);

    object[] getIds();

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    object getDefaultValue(Class c);

    bool hasInstance(Scriptable s);

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Scriptable()
    {
      if (ByteCodeHelper.isAlreadyInited("rhino.Scriptable"))
        return;
      Scriptable.NOT_FOUND = (object) UniqueTag.__\u003C\u003ENOT_FOUND;
    }

    [HideFromJava]
    static class __Fields
    {
      public static readonly object NOT_FOUND = Scriptable.NOT_FOUND;
    }
  }
}
