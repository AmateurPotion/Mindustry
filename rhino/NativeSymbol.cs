// Decompiled with JetBrains decompiler
// Type: rhino.NativeSymbol
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.Symbol"})]
  public class NativeSymbol : IdScriptableObject, Symbol
  {
    public const string CLASS_NAME = "Symbol";
    public const string TYPE_NAME = "symbol";
    [Modifiers]
    private static object GLOBAL_TABLE_KEY;
    [Modifiers]
    private static object CONSTRUCTOR_SLOT;
    [Modifiers]
    private SymbolKey key;
    [Modifiers]
    private NativeSymbol symbolData;
    private const int ConstructorId_keyFor = -2;
    private const int ConstructorId_for = -1;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_valueOf = 4;
    private const int SymbolId_toStringTag = 3;
    private const int SymbolId_toPrimitive = 5;
    private const int MAX_PROTOTYPE_ID = 5;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual SymbolKey getKey() => this.key;

    [LineNumberTable(new byte[] {7, 104, 108, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeSymbol([In] string obj0)
    {
      NativeSymbol nativeSymbol = this;
      this.key = new SymbolKey(obj0);
      this.symbolData = (NativeSymbol) null;
    }

    [LineNumberTable(new byte[] {50, 124, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void createStandardSymbol(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] ScriptableObject obj2,
      [In] string obj3,
      [In] SymbolKey obj4)
    {
      Scriptable scriptable = obj0.newObject(obj1, "Symbol", new object[2]
      {
        (object) obj3,
        (object) obj4
      });
      obj2.defineProperty(obj3, (object) scriptable, 7);
    }

    [LineNumberTable(new byte[] {160, 130, 154, 103, 141, 99, 114, 137})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_for([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      string str = obj2.Length <= 0 ? ScriptRuntime.toString(Undefined.__\u003C\u003Einstance) : ScriptRuntime.toString(obj2[0]);
      Map globalMap = this.getGlobalMap();
      NativeSymbol nativeSymbol = (NativeSymbol) globalMap.get((object) str);
      if (nativeSymbol == null)
      {
        nativeSymbol = NativeSymbol.construct(obj0, obj1, new object[1]
        {
          (object) str
        });
        globalMap.put((object) str, (object) nativeSymbol);
      }
      return (object) nativeSymbol;
    }

    [LineNumberTable(new byte[] {160, 143, 112, 104, 151, 135, 103, 127, 2, 126, 136, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_keyFor([In] Context obj0, [In] Scriptable obj1, [In] object[] obj2)
    {
      object obj = obj2.Length <= 0 ? Undefined.__\u003C\u003Einstance : obj2[0];
      NativeSymbol nativeSymbol = obj is NativeSymbol ? (NativeSymbol) obj : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.throwCustomError(obj0, obj1, "TypeError", "Not a Symbol"));
      Iterator iterator = this.getGlobalMap().entrySet().iterator();
      while (iterator.hasNext())
      {
        Map.Entry entry = (Map.Entry) iterator.next();
        if (object.ReferenceEquals((object) ((NativeSymbol) entry.getValue()).key, (object) nativeSymbol.key))
          return entry.getKey();
      }
      return Undefined.__\u003C\u003Einstance;
    }

    [LineNumberTable(new byte[] {160, 107, 101, 111, 136, 171, 166, 101, 174})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeSymbol js_constructor([In] object[] obj0)
    {
      string name = obj0.Length <= 0 ? "" : (!Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, obj0[0]) ? ScriptRuntime.toString(obj0[0]) : "");
      return obj0.Length > 1 ? new NativeSymbol((SymbolKey) obj0[1]) : new NativeSymbol(new SymbolKey(name));
    }

    [LineNumberTable(new byte[] {27, 144, 151, 107, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static NativeSymbol construct(Context cx, Scriptable scope, object[] args)
    {
      cx.putThreadLocal(NativeSymbol.CONSTRUCTOR_SLOT, (object) Boolean.TRUE);
      try
      {
        return (NativeSymbol) cx.newObject(scope, "Symbol", args);
      }
      finally
      {
        cx.removeThreadLocal(NativeSymbol.CONSTRUCTOR_SLOT);
      }
    }

    [LineNumberTable(new byte[] {160, 99, 127, 0, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static NativeSymbol getSelf([In] object obj0)
    {
      NativeSymbol nativeSymbol;
      try
      {
        nativeSymbol = (NativeSymbol) obj0;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<ClassCastException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_4;
      }
      return nativeSymbol;
label_4:
      throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.invalid.type", (object) Object.instancehelper_getClass(obj0).getName()));
    }

    [LineNumberTable(274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.key.toString();

    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_valueOf() => (object) this.symbolData;

    [LineNumberTable(new byte[] {12, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private NativeSymbol([In] SymbolKey obj0)
    {
      NativeSymbol nativeSymbol = this;
      this.key = obj0;
      this.symbolData = this;
    }

    [Signature("()Ljava/util/Map<Ljava/lang/String;Lrhino/NativeSymbol;>;")]
    [LineNumberTable(new byte[] {160, 226, 108, 113, 104, 102, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Map getGlobalMap()
    {
      ScriptableObject topLevelScope = (ScriptableObject) ScriptableObject.getTopLevelScope((Scriptable) this);
      object obj1 = (object) (Map) topLevelScope.getAssociatedValue(NativeSymbol.GLOBAL_TABLE_KEY);
      if ((Map) obj1 == null)
      {
        obj1 = (object) new HashMap();
        topLevelScope.associateValue(NativeSymbol.GLOBAL_TABLE_KEY, (object) (HashMap) obj1);
      }
      object obj2 = obj1;
      if (obj2 == null)
        return (Map) null;
      return obj2 is Map map ? map : throw new IncompatibleClassChangeError();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isSymbol() => object.ReferenceEquals((object) this.symbolData, (object) this);

    [LineNumberTable(new byte[] {160, 166, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool isStrictMode()
    {
      Context currentContext = Context.getCurrentContext();
      return currentContext != null && currentContext.isStrictMode();
    }

    [LineNumberTable(new byte[] {159, 136, 66, 107, 138, 144, 114, 114, 114, 114, 114, 114, 114, 114, 114, 114, 114, 182, 107, 35, 98, 130, 131, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      IdFunctionObject idFunctionObject = new NativeSymbol("").exportAsJSClass(5, scope, false);
      cx.putThreadLocal(NativeSymbol.CONSTRUCTOR_SLOT, (object) Boolean.TRUE);
      try
      {
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "iterator", SymbolKey.__\u003C\u003EITERATOR);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "species", SymbolKey.__\u003C\u003ESPECIES);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "toStringTag", SymbolKey.__\u003C\u003ETO_STRING_TAG);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "hasInstance", SymbolKey.__\u003C\u003EHAS_INSTANCE);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "isConcatSpreadable", SymbolKey.__\u003C\u003EIS_CONCAT_SPREADABLE);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "isRegExp", SymbolKey.__\u003C\u003EIS_REGEXP);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "toPrimitive", SymbolKey.__\u003C\u003ETO_PRIMITIVE);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "match", SymbolKey.__\u003C\u003EMATCH);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "replace", SymbolKey.__\u003C\u003EREPLACE);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "search", SymbolKey.__\u003C\u003ESEARCH);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "split", SymbolKey.__\u003C\u003ESPLIT);
        NativeSymbol.createStandardSymbol(cx, scope, (ScriptableObject) idFunctionObject, "unscopables", SymbolKey.__\u003C\u003EUNSCOPABLES);
      }
      finally
      {
        cx.removeThreadLocal(NativeSymbol.CONSTRUCTOR_SLOT);
      }
      if (num == 0)
        return;
      idFunctionObject.sealObject();
    }

    [LineNumberTable(new byte[] {17, 104, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeSymbol(NativeSymbol s)
    {
      NativeSymbol nativeSymbol = this;
      this.key = s.key;
      this.symbolData = s.symbolData;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Symbol";

    [LineNumberTable(new byte[] {42, 103, 115, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties(IdFunctionObject ctor)
    {
      base.fillConstructorProperties(ctor);
      this.addIdFunctionProperty((Scriptable) ctor, (object) "Symbol", -1, "for", 1);
      this.addIdFunctionProperty((Scriptable) ctor, (object) "Symbol", -2, "keyFor", 1);
    }

    [LineNumberTable(new byte[] {62, 98, 98, 103, 100, 102, 100, 100, 102, 100, 101, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 7:
          str = "valueOf";
          num = 4;
          break;
        case 8:
          str = "toString";
          num = 2;
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

    [LineNumberTable(new byte[] {83, 109, 98, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(Symbol key)
    {
      if (SymbolKey.__\u003C\u003ETO_STRING_TAG.equals((object) key))
        return 3;
      return SymbolKey.__\u003C\u003ETO_PRIMITIVE.equals((object) key) ? 5 : 0;
    }

    [LineNumberTable(new byte[] {106, 158, 115, 130, 115, 130, 115, 130, 114, 130, 120, 130, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      switch (id)
      {
        case 1:
          this.initPrototypeMethod((object) "Symbol", id, "constructor", 0);
          break;
        case 2:
          this.initPrototypeMethod((object) "Symbol", id, "toString", 0);
          break;
        case 3:
          this.initPrototypeValue(id, (Symbol) SymbolKey.__\u003C\u003ETO_STRING_TAG, (object) "Symbol", 3);
          break;
        case 4:
          this.initPrototypeMethod((object) "Symbol", id, "valueOf", 0);
          break;
        case 5:
          this.initPrototypeMethod((object) "Symbol", id, (Symbol) SymbolKey.__\u003C\u003ETO_PRIMITIVE, "Symbol.toPrimitive", 1);
          break;
        default:
          base.initPrototypeId(id);
          break;
      }
    }

    [LineNumberTable(new byte[] {160, 66, 109, 142, 103, 159, 12, 139, 171, 100, 141, 176, 136, 170, 173, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag((object) "Symbol"))
        return base.execIdCall(f, cx, scope, thisObj, args);
      switch (f.methodId())
      {
        case -2:
          return this.js_keyFor(cx, scope, args);
        case -1:
          return this.js_for(cx, scope, args);
        case 1:
          if (thisObj != null)
            return (object) NativeSymbol.construct(cx, scope, args);
          if (cx.getThreadLocal(NativeSymbol.CONSTRUCTOR_SLOT) == null)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.no.symbol.new"));
          return (object) NativeSymbol.js_constructor(args);
        case 2:
          return (object) NativeSymbol.getSelf((object) thisObj).toString();
        case 4:
        case 5:
          return NativeSymbol.getSelf((object) thisObj).js_valueOf();
        default:
          return base.execIdCall(f, cx, scope, thisObj, args);
      }
    }

    [LineNumberTable(new byte[] {160, 172, 104, 107, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(string name, Scriptable start, object value)
    {
      if (!this.isSymbol())
        base.put(name, start, value);
      else if (this.isStrictMode())
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.no.assign.symbol.strict"));
    }

    [LineNumberTable(new byte[] {160, 181, 104, 107, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(int index, Scriptable start, object value)
    {
      if (!this.isSymbol())
        base.put(index, start, value);
      else if (this.isStrictMode())
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.no.assign.symbol.strict"));
    }

    [LineNumberTable(new byte[] {160, 190, 104, 107, 104, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(Symbol key, Scriptable start, object value)
    {
      if (!this.isSymbol())
        base.put(key, start, value);
      else if (this.isStrictMode())
        throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.no.assign.symbol.strict"));
    }

    [LineNumberTable(322)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getTypeOf() => this.isSymbol() ? "symbol" : base.getTypeOf();

    [LineNumberTable(327)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => this.key.hashCode();

    [LineNumberTable(332)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object x) => this.key.equals(x);

    [LineNumberTable(new byte[] {159, 138, 114, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeSymbol()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeSymbol"))
        return;
      NativeSymbol.GLOBAL_TABLE_KEY = (object) new Object();
      NativeSymbol.CONSTRUCTOR_SLOT = (object) new Object();
    }
  }
}
