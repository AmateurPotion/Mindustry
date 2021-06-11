// Decompiled with JetBrains decompiler
// Type: rhino.ES6Iterator
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public abstract class ES6Iterator : IdScriptableObject
  {
    protected internal bool exhausted;
    private string tag;
    private const int Id_next = 1;
    private const int SymbolId_iterator = 2;
    private const int SymbolId_toStringTag = 3;
    private const int MAX_PROTOTYPE_ID = 3;
    public const string NEXT_METHOD = "next";
    public const string DONE_PROPERTY = "done";
    public const string RETURN_PROPERTY = "return";
    public const string VALUE_PROPERTY = "value";
    public const string RETURN_METHOD = "return";

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(121)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Scriptable makeIteratorResult(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      return ES6Iterator.makeIteratorResult(obj0, obj1, num != 0, Undefined.__\u003C\u003Einstance);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string getTag() => this.tag;

    [LineNumberTable(new byte[] {55, 102, 119, 99, 139, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual object next(Context cx, Scriptable scope)
    {
      object obj = Undefined.__\u003C\u003Einstance;
      int num = this.isDone(cx, scope) || this.exhausted ? 1 : 0;
      if (num == 0)
        obj = this.nextValue(cx, scope);
      else
        this.exhausted = true;
      return (object) ES6Iterator.makeIteratorResult(cx, scope, num != 0, obj);
    }

    protected internal abstract bool isDone(Context c, Scriptable s);

    protected internal abstract object nextValue(Context c, Scriptable s);

    [LineNumberTable(new byte[] {159, 111, 98, 104, 113, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Scriptable makeIteratorResult(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] bool obj2,
      [In] object obj3)
    {
      int num = obj2 ? 1 : 0;
      Scriptable scriptable = obj0.newObject(obj1);
      ScriptableObject.putProperty(scriptable, "done", (object) Boolean.valueOf(num != 0));
      ScriptableObject.putProperty(scriptable, "value", obj3);
      return scriptable;
    }

    [LineNumberTable(new byte[] {159, 141, 130, 99, 103, 140, 103, 99, 230, 71, 99, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init(
      [In] ScriptableObject obj0,
      [In] bool obj1,
      [In] IdScriptableObject obj2,
      [In] string obj3)
    {
      int num = obj1 ? 1 : 0;
      if (obj0 != null)
      {
        obj2.setParentScope((Scriptable) obj0);
        obj2.setPrototype(ScriptableObject.getObjectPrototype((Scriptable) obj0));
      }
      obj2.activatePrototypeMap(3);
      if (num != 0)
        obj2.sealObject();
      obj0?.associateValue((object) obj3, (object) obj2);
    }

    [LineNumberTable(new byte[] {159, 169, 232, 61, 199})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ES6Iterator()
    {
      ES6Iterator es6Iterator = this;
      this.exhausted = false;
    }

    [LineNumberTable(new byte[] {159, 172, 232, 58, 231, 74, 103, 103, 103, 98, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal ES6Iterator([In] Scriptable obj0, [In] string obj1)
    {
      ES6Iterator es6Iterator = this;
      this.exhausted = false;
      this.tag = obj1;
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(obj0);
      this.setParentScope(topLevelScope);
      this.setPrototype((Scriptable) ScriptableObject.getTopScopeValue(topLevelScope, (object) obj1));
    }

    [LineNumberTable(new byte[] {159, 186, 150, 116, 129, 121, 129, 115, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      switch (id)
      {
        case 1:
          this.initPrototypeMethod((object) this.getTag(), id, "next", 0);
          break;
        case 2:
          this.initPrototypeMethod((object) this.getTag(), id, (Symbol) SymbolKey.__\u003C\u003EITERATOR, "[Symbol.iterator]", 3);
          break;
        case 3:
          this.initPrototypeValue(3, (Symbol) SymbolKey.__\u003C\u003ETO_STRING_TAG, (object) this.getClassName(), 3);
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {12, 110, 142, 135, 105, 140, 136, 146, 137, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag((object) this.getTag()))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      ES6Iterator es6Iterator = thisObj is ES6Iterator ? (ES6Iterator) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(f));
      switch (num)
      {
        case 1:
          return es6Iterator.next(cx, scope);
        case 2:
          return (object) es6Iterator;
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {34, 109, 98, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(Symbol k)
    {
      if (SymbolKey.__\u003C\u003EITERATOR.equals((object) k))
        return 2;
      return SymbolKey.__\u003C\u003ETO_STRING_TAG.equals((object) k) ? 3 : 0;
    }

    [LineNumberTable(new byte[] {44, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s) => String.instancehelper_equals("next", (object) s) ? 1 : 0;

    [HideFromJava]
    static ES6Iterator() => IdScriptableObject.__\u003Cclinit\u003E();
  }
}
