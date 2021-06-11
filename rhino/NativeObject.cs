// Decompiled with JetBrains decompiler
// Type: rhino.NativeObject
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using java.util.function;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"java.util.Map"})]
  public class NativeObject : IdScriptableObject, Map
  {
    [Modifiers]
    private static object OBJECT_TAG;
    private const int ConstructorId_getPrototypeOf = -1;
    private const int ConstructorId_keys = -2;
    private const int ConstructorId_getOwnPropertyNames = -3;
    private const int ConstructorId_getOwnPropertyDescriptor = -4;
    private const int ConstructorId_defineProperty = -5;
    private const int ConstructorId_isExtensible = -6;
    private const int ConstructorId_preventExtensions = -7;
    private const int ConstructorId_defineProperties = -8;
    private const int ConstructorId_create = -9;
    private const int ConstructorId_isSealed = -10;
    private const int ConstructorId_isFrozen = -11;
    private const int ConstructorId_seal = -12;
    private const int ConstructorId_freeze = -13;
    private const int ConstructorId_getOwnPropertySymbols = -14;
    private const int ConstructorId_assign = -15;
    private const int ConstructorId_is = -16;
    private const int ConstructorId_setPrototypeOf = -17;
    private const int Id_constructor = 1;
    private const int Id_toString = 2;
    private const int Id_toLocaleString = 3;
    private const int Id_valueOf = 4;
    private const int Id_hasOwnProperty = 5;
    private const int Id_propertyIsEnumerable = 6;
    private const int Id_isPrototypeOf = 7;
    private const int Id_toSource = 8;
    private const int Id___defineGetter__ = 9;
    private const int Id___defineSetter__ = 10;
    private const int Id___lookupGetter__ = 11;
    private const int Id___lookupSetter__ = 12;
    private const int MAX_PROTOTYPE_ID = 12;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public NativeObject()
    {
    }

    [LineNumberTable(new byte[] {161, 206, 109, 105, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Scriptable getCompatibleObject(
      [In] Context obj0,
      [In] Scriptable obj1,
      [In] object obj2)
    {
      return obj0.getLanguageVersion() >= 200 ? ScriptableObject.ensureScriptable((object) ScriptRuntime.toObject(obj0, obj1, obj2)) : ScriptableObject.ensureScriptable(obj2);
    }

    [Signature("()Ljava/util/Collection<Ljava/lang/Object;>;")]
    [LineNumberTable(624)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Collection values() => (Collection) new NativeObject.ValueCollection(this);

    [LineNumberTable(new byte[] {159, 138, 66, 102, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void init([In] Scriptable obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      new NativeObject().exportAsJSClass(12, obj0, num != 0);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => "Object";

    [LineNumberTable(27)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => ScriptRuntime.defaultObjectToString((Scriptable) this);

    [LineNumberTable(new byte[] {159, 174, 147, 113, 180, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 148, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void fillConstructorProperties(IdFunctionObject ctor)
    {
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -1, "getPrototypeOf", 1);
      if (Context.getCurrentContext().version >= 200)
        this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -17, "setPrototypeOf", 2);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -2, "keys", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -3, "getOwnPropertyNames", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -14, "getOwnPropertySymbols", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -4, "getOwnPropertyDescriptor", 2);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -5, "defineProperty", 3);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -6, "isExtensible", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -7, "preventExtensions", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -8, "defineProperties", 2);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -9, "create", 2);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -10, "isSealed", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -11, "isFrozen", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -12, "seal", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -13, "freeze", 1);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -15, "assign", 2);
      this.addIdFunctionProperty((Scriptable) ctor, NativeObject.OBJECT_TAG, -16, "is", 2);
      base.fillConstructorProperties(ctor);
    }

    [LineNumberTable(new byte[] {25, 159, 30, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 133, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 1;
          name = "constructor";
          break;
        case 2:
          arity = 0;
          name = "toString";
          break;
        case 3:
          arity = 0;
          name = "toLocaleString";
          break;
        case 4:
          arity = 0;
          name = "valueOf";
          break;
        case 5:
          arity = 1;
          name = "hasOwnProperty";
          break;
        case 6:
          arity = 1;
          name = "propertyIsEnumerable";
          break;
        case 7:
          arity = 1;
          name = "isPrototypeOf";
          break;
        case 8:
          arity = 0;
          name = "toSource";
          break;
        case 9:
          arity = 2;
          name = "__defineGetter__";
          break;
        case 10:
          arity = 2;
          name = "__defineSetter__";
          break;
        case 11:
          arity = 1;
          name = "__lookupGetter__";
          break;
        case 12:
          arity = 1;
          name = "__lookupSetter__";
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(NativeObject.OBJECT_TAG, id, name, arity);
    }

    [LineNumberTable(new byte[] {83, 109, 142, 103, 159, 103, 132, 139, 155, 134, 204, 109, 104, 140, 103, 208, 105, 140, 104, 157, 140, 130, 200, 122, 159, 31, 163, 122, 191, 31, 115, 105, 153, 106, 105, 148, 178, 200, 122, 223, 31, 147, 105, 119, 115, 105, 112, 108, 133, 202, 105, 114, 115, 105, 112, 108, 130, 114, 109, 105, 112, 255, 1, 74, 226, 57, 98, 124, 46, 140, 133, 200, 200, 122, 191, 31, 99, 112, 139, 105, 107, 99, 130, 132, 200, 204, 113, 146, 140, 105, 146, 110, 229, 61, 235, 69, 105, 108, 117, 107, 103, 116, 105, 141, 198, 143, 134, 105, 108, 117, 167, 116, 100, 162, 105, 100, 98, 105, 169, 98, 100, 131, 166, 114, 106, 168, 102, 149, 116, 105, 183, 107, 133, 107, 105, 208, 100, 100, 107, 156, 139, 105, 163, 114, 106, 105, 106, 47, 168, 170, 114, 106, 105, 107, 106, 47, 168, 170, 114, 106, 105, 107, 103, 106, 108, 13, 232, 69, 175, 210, 106, 105, 115, 108, 174, 114, 104, 115, 115, 105, 108, 163, 114, 149, 166, 104, 173, 114, 149, 162, 104, 103, 163, 114, 104, 115, 106, 111, 163, 114, 142, 103, 104, 137, 118, 108, 175, 163, 114, 149, 166, 136, 143, 126, 118, 110, 230, 61, 232, 70, 166, 114, 149, 166, 136, 143, 127, 2, 108, 120, 102, 127, 3, 230, 59, 235, 72, 166, 114, 149, 162, 136, 126, 108, 120, 115, 237, 60, 232, 71, 135, 163, 114, 149, 162, 136, 127, 4, 108, 127, 3, 147, 120, 147, 237, 56, 235, 74, 135, 195, 102, 149, 110, 109, 123, 133, 111, 105, 124, 105, 114, 124, 146, 107, 105, 109, 124, 237, 54, 235, 58, 235, 85, 195, 114, 115, 238, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(NativeObject.OBJECT_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num1 = f.methodId();
      switch (num1)
      {
        case -17:
          if (args.Length < 2)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.incompat.call", (object) "setPrototypeOf"));
          Scriptable m1 = args[1] != null ? ScriptableObject.ensureScriptable(args[1]) : (Scriptable) null;
          if (m1 is Symbol)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.arg.not.object", (object) ScriptRuntime.@typeof((object) m1)));
          if (!(args[0] is ScriptableObject))
            return args[0];
          ScriptableObject scriptableObject1 = (ScriptableObject) args[0];
          if (!scriptableObject1.isExtensible())
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.not.extensible"));
          for (Scriptable scriptable = m1; scriptable != null; scriptable = scriptable.getPrototype())
          {
            if (object.ReferenceEquals((object) scriptable, (object) scriptableObject1))
              throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.object.cyclic.prototype", (object) Object.instancehelper_getClass((object) scriptableObject1).getSimpleName()));
          }
          scriptableObject1.setPrototype(m1);
          return (object) scriptableObject1;
        case -16:
          return (object) ScriptRuntime.wrapBoolean(ScriptRuntime.same(args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance, args.Length >= 2 ? args[1] : Undefined.__\u003C\u003Einstance));
        case -15:
          if (args.Length < 1)
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.incompat.call", (object) "assign"));
          Scriptable s = ScriptRuntime.toObject(cx, thisObj, args[0]);
          for (int index1 = 1; index1 < args.Length; ++index1)
          {
            if (args[index1] != null && !Object.instancehelper_equals(Undefined.__\u003C\u003Einstance, args[index1]))
            {
              Scriptable scriptable = ScriptRuntime.toObject(cx, thisObj, args[index1]);
              object[] ids = scriptable.getIds();
              int length = ids.Length;
              for (int index2 = 0; index2 < length; ++index2)
              {
                object val = ids[index2];
                switch (val)
                {
                  case string _:
                    object objA1 = scriptable.get((string) val, s);
                    if (!object.ReferenceEquals(objA1, Scriptable.NOT_FOUND) && !object.ReferenceEquals(objA1, Undefined.__\u003C\u003Einstance))
                    {
                      s.put((string) val, s, objA1);
                      break;
                    }
                    break;
                  case Number _:
                    int int32 = ScriptRuntime.toInt32(val);
                    object objA2 = scriptable.get(int32, s);
                    if (!object.ReferenceEquals(objA2, Scriptable.NOT_FOUND) && !object.ReferenceEquals(objA2, Undefined.__\u003C\u003Einstance))
                    {
                      s.put(int32, s, objA2);
                      break;
                    }
                    break;
                }
              }
            }
          }
          return (object) s;
        case -14:
          object obj1 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          object[] ids1 = ScriptableObject.ensureScriptableObject((object) NativeObject.getCompatibleObject(cx, scope, obj1)).getIds(true, true);
          ArrayList arrayList = new ArrayList();
          for (int index = 0; index < ids1.Length; ++index)
          {
            if (ids1[index] is Symbol)
              arrayList.add(ids1[index]);
          }
          return (object) cx.newArray(scope, arrayList.toArray());
        case -13:
          object obj2 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          if (cx.getLanguageVersion() >= 200 && !(obj2 is ScriptableObject))
            return obj2;
          ScriptableObject scriptableObject2 = ScriptableObject.ensureScriptableObject(obj2);
          object[] ids2 = scriptableObject2.getIds(true, true);
          int length1 = ids2.Length;
          for (int index = 0; index < length1; ++index)
          {
            object id = ids2[index];
            ScriptableObject propertyDescriptor = scriptableObject2.getOwnPropertyDescriptor(cx, id);
            if (this.isDataDescriptor(propertyDescriptor) && ((Boolean) Boolean.TRUE).equals(propertyDescriptor.get((object) "writable")))
              propertyDescriptor.put("writable", (Scriptable) propertyDescriptor, (object) Boolean.FALSE);
            if (((Boolean) Boolean.TRUE).equals(propertyDescriptor.get((object) "configurable")))
              propertyDescriptor.put("configurable", (Scriptable) propertyDescriptor, (object) Boolean.FALSE);
            scriptableObject2.defineOwnProperty(cx, id, propertyDescriptor, false);
          }
          scriptableObject2.preventExtensions();
          return (object) scriptableObject2;
        case -12:
          object obj3 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          if (cx.getLanguageVersion() >= 200 && !(obj3 is ScriptableObject))
            return obj3;
          ScriptableObject scriptableObject3 = ScriptableObject.ensureScriptableObject(obj3);
          object[] allIds1 = scriptableObject3.getAllIds();
          int length2 = allIds1.Length;
          for (int index = 0; index < length2; ++index)
          {
            object id = allIds1[index];
            ScriptableObject propertyDescriptor = scriptableObject3.getOwnPropertyDescriptor(cx, id);
            if (((Boolean) Boolean.TRUE).equals(propertyDescriptor.get((object) "configurable")))
            {
              propertyDescriptor.put("configurable", (Scriptable) propertyDescriptor, (object) Boolean.FALSE);
              scriptableObject3.defineOwnProperty(cx, id, propertyDescriptor, false);
            }
          }
          scriptableObject3.preventExtensions();
          return (object) scriptableObject3;
        case -11:
          object obj4 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          if (cx.getLanguageVersion() >= 200 && !(obj4 is ScriptableObject))
            return (object) Boolean.TRUE;
          ScriptableObject scriptableObject4 = ScriptableObject.ensureScriptableObject(obj4);
          if (scriptableObject4.isExtensible())
            return (object) Boolean.FALSE;
          object[] allIds2 = scriptableObject4.getAllIds();
          int length3 = allIds2.Length;
          for (int index = 0; index < length3; ++index)
          {
            object id = allIds2[index];
            ScriptableObject propertyDescriptor = scriptableObject4.getOwnPropertyDescriptor(cx, id);
            if (((Boolean) Boolean.TRUE).equals(propertyDescriptor.get((object) "configurable")))
              return (object) Boolean.FALSE;
            if (this.isDataDescriptor(propertyDescriptor) && ((Boolean) Boolean.TRUE).equals(propertyDescriptor.get((object) "writable")))
              return (object) Boolean.FALSE;
          }
          return (object) Boolean.TRUE;
        case -10:
          object obj5 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          if (cx.getLanguageVersion() >= 200 && !(obj5 is ScriptableObject))
            return (object) Boolean.TRUE;
          ScriptableObject scriptableObject5 = ScriptableObject.ensureScriptableObject(obj5);
          if (scriptableObject5.isExtensible())
            return (object) Boolean.FALSE;
          object[] allIds3 = scriptableObject5.getAllIds();
          int length4 = allIds3.Length;
          for (int index = 0; index < length4; ++index)
          {
            object id = allIds3[index];
            object obj6 = scriptableObject5.getOwnPropertyDescriptor(cx, id).get((object) "configurable");
            if (((Boolean) Boolean.TRUE).equals(obj6))
              return (object) Boolean.FALSE;
          }
          return (object) Boolean.TRUE;
        case -9:
          object obj7 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          Scriptable m2 = obj7 != null ? ScriptableObject.ensureScriptable(obj7) : (Scriptable) null;
          NativeObject nativeObject = new NativeObject();
          nativeObject.setParentScope(scope);
          nativeObject.setPrototype(m2);
          if (args.Length > 1 && !object.ReferenceEquals(args[1], Undefined.__\u003C\u003Einstance))
          {
            Scriptable scriptable = Context.toObject(args[1], scope);
            nativeObject.defineOwnProperties(cx, ScriptableObject.ensureScriptableObject((object) scriptable));
          }
          return (object) nativeObject;
        case -8:
          ScriptableObject scriptableObject6 = ScriptableObject.ensureScriptableObject(args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance);
          Scriptable scriptable1 = Context.toObject(args.Length >= 2 ? args[1] : Undefined.__\u003C\u003Einstance, scope);
          scriptableObject6.defineOwnProperties(cx, ScriptableObject.ensureScriptableObject((object) scriptable1));
          return (object) scriptableObject6;
        case -7:
          object obj8 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          if (cx.getLanguageVersion() >= 200 && !(obj8 is ScriptableObject))
            return obj8;
          ScriptableObject scriptableObject7 = ScriptableObject.ensureScriptableObject(obj8);
          scriptableObject7.preventExtensions();
          return (object) scriptableObject7;
        case -6:
          object obj9 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          return cx.getLanguageVersion() >= 200 && !(obj9 is ScriptableObject) ? (object) Boolean.FALSE : (object) Boolean.valueOf(ScriptableObject.ensureScriptableObject(obj9).isExtensible());
        case -5:
          ScriptableObject scriptableObject8 = ScriptableObject.ensureScriptableObject(args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance);
          object id1 = args.Length >= 2 ? args[1] : Undefined.__\u003C\u003Einstance;
          ScriptableObject desc = ScriptableObject.ensureScriptableObject(args.Length >= 3 ? args[2] : Undefined.__\u003C\u003Einstance);
          scriptableObject8.defineOwnProperty(cx, id1, desc);
          return (object) scriptableObject8;
        case -4:
          object obj10 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          ScriptableObject scriptableObject9 = ScriptableObject.ensureScriptableObject((object) NativeObject.getCompatibleObject(cx, scope, obj10));
          object id2 = args.Length >= 2 ? args[1] : Undefined.__\u003C\u003Einstance;
          return (object) scriptableObject9.getOwnPropertyDescriptor(cx, id2) ?? Undefined.__\u003C\u003Einstance;
        case -3:
          object obj11 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          object[] ids3 = ScriptableObject.ensureScriptableObject((object) NativeObject.getCompatibleObject(cx, scope, obj11)).getIds(true, false);
          for (int index = 0; index < ids3.Length; ++index)
            ids3[index] = (object) ScriptRuntime.toString(ids3[index]);
          return (object) cx.newArray(scope, ids3);
        case -2:
          object obj12 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          object[] ids4 = NativeObject.getCompatibleObject(cx, scope, obj12).getIds();
          for (int index = 0; index < ids4.Length; ++index)
            ids4[index] = (object) ScriptRuntime.toString(ids4[index]);
          return (object) cx.newArray(scope, ids4);
        case -1:
          object obj13 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          return (object) NativeObject.getCompatibleObject(cx, scope, obj13).getPrototype();
        case 1:
          if (thisObj != null)
            return (object) f.construct(cx, scope, args);
          return args.Length == 0 || args[0] == null || object.ReferenceEquals(args[0], Undefined.__\u003C\u003Einstance) ? (object) new NativeObject() : (object) ScriptRuntime.toObject(cx, scope, args[0]);
        case 2:
          if (!cx.hasFeature(4))
            return (object) ScriptRuntime.defaultObjectToString(thisObj);
          string str1 = ScriptRuntime.defaultObjectToSource(cx, scope, thisObj, args);
          int num2 = String.instancehelper_length(str1);
          if (num2 != 0 && String.instancehelper_charAt(str1, 0) == '(' && String.instancehelper_charAt(str1, num2 - 1) == ')')
            str1 = String.instancehelper_substring(str1, 1, num2 - 1);
          return (object) str1;
        case 3:
          object property = ScriptableObject.getProperty(thisObj, "toString");
          if (!(property is Callable))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(property));
          return ((Callable) property).call(cx, scope, thisObj, ScriptRuntime.__\u003C\u003EemptyArgs);
        case 4:
          return cx.getLanguageVersion() < 180 || thisObj != null && !Undefined.isUndefined((object) thisObj) ? (object) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0(new StringBuilder().append("msg.").append(thisObj != null ? "undef" : "null").append(".to.object").toString()));
        case 5:
          if (cx.getLanguageVersion() >= 180 && (thisObj == null || Undefined.isUndefined((object) thisObj)))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0(new StringBuilder().append("msg.").append(thisObj != null ? "undef" : "null").append(".to.object").toString()));
          object obj14 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          int num3;
          if (obj14 is Symbol)
          {
            num3 = ScriptableObject.ensureSymbolScriptable((object) thisObj).has((Symbol) obj14, thisObj) ? 1 : 0;
          }
          else
          {
            ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(cx, obj14);
            num3 = stringIdOrIndex.stringId != null ? (thisObj.has(stringIdOrIndex.stringId, thisObj) ? 1 : 0) : (thisObj.has(stringIdOrIndex.index, thisObj) ? 1 : 0);
          }
          return (object) ScriptRuntime.wrapBoolean(num3 != 0);
        case 6:
          if (cx.getLanguageVersion() >= 180 && (thisObj == null || Undefined.isUndefined((object) thisObj)))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0(new StringBuilder().append("msg.").append(thisObj != null ? "undef" : "null").append(".to.object").toString()));
          object obj15 = args.Length >= 1 ? args[0] : Undefined.__\u003C\u003Einstance;
          int num4;
          if (obj15 is Symbol)
          {
            num4 = ((SymbolScriptable) thisObj).has((Symbol) obj15, thisObj) ? 1 : 0;
            if (num4 != 0 && thisObj is ScriptableObject)
              num4 = (((ScriptableObject) thisObj).getAttributes((Symbol) obj15) & 2) != 0 ? 0 : 1;
          }
          else
          {
            ScriptRuntime.StringIdOrIndex stringIdOrIndex = ScriptRuntime.toStringIdOrIndex(cx, obj15);
            EvaluatorException evaluatorException1;
            try
            {
              if (stringIdOrIndex.stringId == null)
              {
                num4 = thisObj.has(stringIdOrIndex.index, thisObj) ? 1 : 0;
                if (num4 != 0)
                {
                  if (thisObj is ScriptableObject)
                  {
                    num4 = (((ScriptableObject) thisObj).getAttributes(stringIdOrIndex.index) & 2) != 0 ? 0 : 1;
                    goto label_42;
                  }
                  else
                    goto label_42;
                }
                else
                  goto label_42;
              }
              else
              {
                num4 = thisObj.has(stringIdOrIndex.stringId, thisObj) ? 1 : 0;
                if (num4 != 0)
                {
                  if (thisObj is ScriptableObject)
                  {
                    num4 = (((ScriptableObject) thisObj).getAttributes(stringIdOrIndex.stringId) & 2) != 0 ? 0 : 1;
                    goto label_42;
                  }
                  else
                    goto label_42;
                }
                else
                  goto label_42;
              }
            }
            catch (EvaluatorException ex)
            {
              evaluatorException1 = (EvaluatorException) ByteCodeHelper.MapException<EvaluatorException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
            EvaluatorException evaluatorException2 = evaluatorException1;
            if (!String.instancehelper_startsWith(evaluatorException2.getMessage(), ScriptRuntime.getMessage1("msg.prop.not.found", stringIdOrIndex.stringId != null ? (object) stringIdOrIndex.stringId : (object) Integer.toString(stringIdOrIndex.index))))
              throw Throwable.__\u003Cunmap\u003E((Exception) evaluatorException2);
            num4 = 0;
          }
label_42:
          return (object) ScriptRuntime.wrapBoolean(num4 != 0);
        case 7:
          if (cx.getLanguageVersion() >= 180 && (thisObj == null || Undefined.isUndefined((object) thisObj)))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0(new StringBuilder().append("msg.").append(thisObj != null ? "undef" : "null").append(".to.object").toString()));
          int num5 = 0;
          if (args.Length != 0 && args[0] is Scriptable)
          {
            Scriptable prototype = (Scriptable) args[0];
            do
            {
              prototype = prototype.getPrototype();
              if (object.ReferenceEquals((object) prototype, (object) thisObj))
              {
                num5 = 1;
                break;
              }
            }
            while (prototype != null);
          }
          return (object) ScriptRuntime.wrapBoolean(num5 != 0);
        case 8:
          return (object) ScriptRuntime.defaultObjectToSource(cx, scope, thisObj, args);
        case 9:
        case 10:
          if (args.Length < 2 || !(args[1] is Callable))
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.notFunctionError(args.Length < 2 ? Undefined.__\u003C\u003Einstance : args[1]));
          ScriptableObject scriptableObject10 = thisObj is ScriptableObject ? (ScriptableObject) thisObj : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.extend.scriptable", thisObj != null ? (object) Object.instancehelper_getClass((object) thisObj).getName() : (object) "null", (object) String.valueOf(args[0])));
          ScriptRuntime.StringIdOrIndex stringIdOrIndex1 = ScriptRuntime.toStringIdOrIndex(cx, args[0]);
          int index3 = stringIdOrIndex1.stringId == null ? stringIdOrIndex1.index : 0;
          Callable getterOrSetter1 = (Callable) args[1];
          int num6 = num1 == 10 ? 1 : 0;
          scriptableObject10.setGetterOrSetter(stringIdOrIndex1.stringId, index3, getterOrSetter1, num6 != 0);
          if (scriptableObject10 is NativeArray)
            ((NativeArray) scriptableObject10).setDenseOnly(false);
          return Undefined.__\u003C\u003Einstance;
        case 11:
        case 12:
          if (args.Length < 1 || !(thisObj is ScriptableObject))
            return Undefined.__\u003C\u003Einstance;
          ScriptableObject scriptableObject11 = (ScriptableObject) thisObj;
          ScriptRuntime.StringIdOrIndex stringIdOrIndex2 = ScriptRuntime.toStringIdOrIndex(cx, args[0]);
          int index4 = stringIdOrIndex2.stringId == null ? stringIdOrIndex2.index : 0;
          int num7 = num1 == 12 ? 1 : 0;
          object getterOrSetter2;
          while (true)
          {
            getterOrSetter2 = scriptableObject11.getGetterOrSetter(stringIdOrIndex2.stringId, index4, num7 != 0);
            if (getterOrSetter2 == null)
            {
              Scriptable prototype = scriptableObject11.getPrototype();
              if (prototype != null && prototype is ScriptableObject)
                scriptableObject11 = (ScriptableObject) prototype;
              else
                break;
            }
            else
              break;
          }
          return getterOrSetter2 ?? Undefined.__\u003C\u003Einstance;
        default:
          string str2 = String.valueOf(num1);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str2);
      }
    }

    [LineNumberTable(new byte[] {161, 217, 104, 110, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsKey(object key)
    {
      switch (key)
      {
        case string _:
          return this.has((string) key, (Scriptable) this);
        case Number _:
          return this.has(((Number) key).intValue(), (Scriptable) this);
        default:
          return false;
      }
    }

    [LineNumberTable(new byte[] {161, 227, 123, 110, 103, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool containsValue(object value)
    {
      Iterator iterator = this.values().iterator();
      while (iterator.hasNext())
      {
        object objB = iterator.next();
        if (object.ReferenceEquals(value, objB) || value != null && Object.instancehelper_equals(value, objB))
          return true;
      }
      return false;
    }

    [LineNumberTable(new byte[] {161, 238, 104, 104, 110, 104, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object remove(object key)
    {
      object obj = this.get(key);
      switch (key)
      {
        case string _:
          this.delete((string) key);
          break;
        case Number _:
          this.delete(((Number) key).intValue());
          break;
      }
      return obj;
    }

    [Signature("()Ljava/util/Set<Ljava/lang/Object;>;")]
    [LineNumberTable(619)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Set keySet() => (Set) new NativeObject.KeySet(this);

    [Signature("()Ljava/util/Set<Ljava/util/Map$Entry<Ljava/lang/Object;Ljava/lang/Object;>;>;")]
    [LineNumberTable(629)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Set entrySet() => (Set) new NativeObject.EntrySet(this);

    [LineNumberTable(634)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object put(object key, object value)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(639)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putAll(Map m)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(644)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new UnsupportedOperationException();
    }

    [LineNumberTable(new byte[] {162, 186, 98, 162, 159, 43, 102, 98, 133, 104, 101, 102, 103, 104, 102, 199, 102, 98, 133, 102, 98, 133, 104, 101, 102, 103, 104, 102, 199, 104, 101, 104, 101, 102, 104, 101, 102, 133, 101, 104, 101, 102, 101, 101, 102, 229, 69, 102, 162, 183})]
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
          switch (String.instancehelper_charAt(s, 3))
          {
            case 'o':
              str = "toSource";
              num = 8;
              break;
            case 't':
              str = "toString";
              num = 2;
              break;
          }
          break;
        case 11:
          str = "constructor";
          num = 1;
          break;
        case 13:
          str = "isPrototypeOf";
          num = 7;
          break;
        case 14:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'h':
              str = "hasOwnProperty";
              num = 5;
              break;
            case 't':
              str = "toLocaleString";
              num = 3;
              break;
          }
          break;
        case 16:
          switch (String.instancehelper_charAt(s, 2))
          {
            case 'd':
              switch (String.instancehelper_charAt(s, 8))
              {
                case 'G':
                  str = "__defineGetter__";
                  num = 9;
                  break;
                case 'S':
                  str = "__defineSetter__";
                  num = 10;
                  break;
              }
              break;
            case 'l':
              switch (String.instancehelper_charAt(s, 8))
              {
                case 'G':
                  str = "__lookupGetter__";
                  num = 11;
                  break;
                case 'S':
                  str = "__lookupSetter__";
                  num = 12;
                  break;
              }
              break;
          }
          break;
        case 20:
          str = "propertyIsEnumerable";
          num = 6;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static NativeObject()
    {
      IdScriptableObject.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.NativeObject"))
        return;
      NativeObject.OBJECT_TAG = (object) "Object";
    }

    [HideFromJava]
    public virtual object putIfAbsent([In] object obj0, [In] object obj1) => Map.\u003Cdefault\u003EputIfAbsent((Map) this, obj0, obj1);

    [HideFromJava]
    public virtual object getOrDefault([In] object obj0, [In] object obj1) => Map.\u003Cdefault\u003EgetOrDefault((Map) this, obj0, obj1);

    [HideFromJava]
    public virtual void forEach([In] BiConsumer obj0) => Map.\u003Cdefault\u003EforEach((Map) this, obj0);

    [HideFromJava]
    public virtual void replaceAll([In] BiFunction obj0) => Map.\u003Cdefault\u003EreplaceAll((Map) this, obj0);

    [HideFromJava]
    public virtual bool remove([In] object obj0, [In] object obj1) => Map.\u003Cdefault\u003Eremove((Map) this, obj0, obj1);

    [HideFromJava]
    public virtual bool replace([In] object obj0, [In] object obj1, [In] object obj2) => Map.\u003Cdefault\u003Ereplace((Map) this, obj0, obj1, obj2);

    [HideFromJava]
    public virtual object replace([In] object obj0, [In] object obj1) => Map.\u003Cdefault\u003Ereplace((Map) this, obj0, obj1);

    [HideFromJava]
    public virtual object computeIfAbsent([In] object obj0, [In] Function obj1) => Map.\u003Cdefault\u003EcomputeIfAbsent((Map) this, obj0, obj1);

    [HideFromJava]
    public virtual object computeIfPresent([In] object obj0, [In] BiFunction obj1) => Map.\u003Cdefault\u003EcomputeIfPresent((Map) this, obj0, obj1);

    [HideFromJava]
    public virtual object compute([In] object obj0, [In] BiFunction obj1) => Map.\u003Cdefault\u003Ecompute((Map) this, obj0, obj1);

    [HideFromJava]
    public virtual object merge([In] object obj0, [In] object obj1, [In] BiFunction obj2) => Map.\u003Cdefault\u003Emerge((Map) this, obj0, obj1, obj2);

    bool Map.__\u003Coverridestub\u003Ejava\u002Eutil\u002EMap\u003A\u003Aequals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

    int Map.__\u003Coverridestub\u003Ejava\u002Eutil\u002EMap\u003A\u003AhashCode() => Object.instancehelper_hashCode((object) this);

    [Signature("Ljava/util/AbstractSet<Ljava/util/Map$Entry<Ljava/lang/Object;Ljava/lang/Object;>;>;")]
    internal class EntrySet : AbstractSet
    {
      [Modifiers]
      internal NativeObject this\u00240;

      [LineNumberTable(648)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal EntrySet([In] NativeObject obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [Signature("()Ljava/util/Iterator<Ljava/util/Map$Entry<Ljava/lang/Object;Ljava/lang/Object;>;>;")]
      [LineNumberTable(651)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) new NativeObject.EntrySet.\u0031(this);

      [LineNumberTable(717)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int size() => this.this\u00240.size();

      [InnerClass]
      [Signature("Ljava/lang/Object;Ljava/util/Iterator<Ljava/util/Map$Entry<Ljava/lang/Object;Ljava/lang/Object;>;>;")]
      [EnclosingMethod(null, "iterator", "()Ljava.util.Iterator;")]
      [SpecialName]
      internal class \u0031 : Object, Iterator
      {
        [Modifiers]
        internal object[] ids;
        internal object key;
        internal int index;
        [Modifiers]
        internal NativeObject.EntrySet this\u00241;

        [Signature("()Ljava/util/Map$Entry<Ljava/lang/Object;Ljava/lang/Object;>;")]
        [LineNumberTable(new byte[] {162, 37, 127, 7, 120})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual Map.Entry next()
        {
          NativeObject.EntrySet.\u0031 obj1 = this;
          object[] ids = this.ids;
          NativeObject.EntrySet.\u0031 obj2 = this;
          int index1 = obj2.index;
          NativeObject.EntrySet.\u0031 obj3 = obj2;
          int index2 = index1;
          obj3.index = index1 + 1;
          object obj4 = ids[index2];
          object obj5 = obj4;
          this.key = obj4;
          return (Map.Entry) new NativeObject.EntrySet.\u0031.\u0031(this, obj5, this.this\u00241.this\u00240.get(this.key));
        }

        [LineNumberTable(new byte[] {162, 25, 111, 118, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] NativeObject.EntrySet obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          NativeObject.EntrySet.\u0031 obj = this;
          this.ids = this.this\u00241.this\u00240.getIds();
          this.key = (object) null;
          this.index = 0;
        }

        [LineNumberTable(658)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool hasNext() => this.index < this.ids.Length;

        [LineNumberTable(new byte[] {162, 80, 104, 139, 119, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void remove()
        {
          if (this.key == null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException();
          }
          this.this\u00241.this\u00240.remove(this.key);
          this.key = (object) null;
        }

        [Modifiers]
        [LineNumberTable(651)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual object next() => (object) this.next();

        [HideFromJava]
        public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);

        [InnerClass]
        [Signature("Ljava/lang/Object;Ljava/util/Map$Entry<Ljava/lang/Object;Ljava/lang/Object;>;")]
        [EnclosingMethod(null, "next", "()Ljava.util.Map$Entry;")]
        [SpecialName]
        internal class \u0031 : Object, Map.Entry
        {
          [Modifiers]
          internal object val\u0024ekey;
          [Modifiers]
          internal object val\u0024value;
          [Modifiers]
          internal NativeObject.EntrySet.\u0031 this\u00242;

          [LineNumberTable(665)]
          [MethodImpl(MethodImplOptions.NoInlining)]
          internal \u0031([In] NativeObject.EntrySet.\u0031 obj0, [In] object obj1, [In] object obj2)
          {
            this.this\u00242 = obj0;
            this.val\u0024ekey = obj1;
            this.val\u0024value = obj2;
            // ISSUE: explicit constructor call
            base.\u002Ector();
          }

          [MethodImpl(MethodImplOptions.NoInlining)]
          public virtual object getKey() => this.val\u0024ekey;

          [MethodImpl(MethodImplOptions.NoInlining)]
          public virtual object getValue() => this.val\u0024value;

          [LineNumberTable(678)]
          [MethodImpl(MethodImplOptions.NoInlining)]
          public virtual object setValue([In] object obj0)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new UnsupportedOperationException();
          }

          [LineNumberTable(new byte[] {162, 57, 104, 130, 103, 127, 15, 63, 1})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          public virtual bool equals([In] object obj0)
          {
            if (!(obj0 is Map.Entry))
              return false;
            Map.Entry entry = (Map.Entry) obj0;
            if (this.val\u0024ekey == null)
            {
              if (entry.getKey() != null)
                goto label_9;
            }
            else if (!Object.instancehelper_equals(this.val\u0024ekey, entry.getKey()))
              goto label_9;
            if (this.val\u0024value == null)
            {
              if (entry.getValue() != null)
                goto label_9;
            }
            else if (!Object.instancehelper_equals(this.val\u0024value, entry.getValue()))
              goto label_9;
            return true;
label_9:
            return false;
          }

          [LineNumberTable(new byte[] {162, 67, 127, 8, 38})]
          [MethodImpl(MethodImplOptions.NoInlining)]
          public virtual int hashCode() => (this.val\u0024ekey != null ? Object.instancehelper_hashCode(this.val\u0024ekey) : 0) ^ (this.val\u0024value != null ? Object.instancehelper_hashCode(this.val\u0024value) : 0);

          [LineNumberTable(699)]
          [MethodImpl(MethodImplOptions.NoInlining)]
          public virtual string toString() => new StringBuilder().append(this.val\u0024ekey).append("=").append(this.val\u0024value).toString();
        }
      }
    }

    [Signature("Ljava/util/AbstractSet<Ljava/lang/Object;>;")]
    internal class KeySet : AbstractSet
    {
      [Modifiers]
      internal NativeObject this\u00240;

      [LineNumberTable(721)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal KeySet([In] NativeObject obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(725)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool contains([In] object obj0) => this.this\u00240.containsKey(obj0);

      [Signature("()Ljava/util/Iterator<Ljava/lang/Object;>;")]
      [LineNumberTable(730)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) new NativeObject.KeySet.\u0031(this);

      [LineNumberTable(763)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int size() => this.this\u00240.size();

      [InnerClass]
      [Signature("Ljava/lang/Object;Ljava/util/Iterator<Ljava/lang/Object;>;")]
      [EnclosingMethod(null, "iterator", "()Ljava.util.Iterator;")]
      [SpecialName]
      internal class \u0031 : Object, Iterator
      {
        [Modifiers]
        internal object[] ids;
        internal object key;
        internal int index;
        [Modifiers]
        internal NativeObject.KeySet this\u00241;

        [LineNumberTable(new byte[] {162, 104, 111, 150})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] NativeObject.KeySet obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          NativeObject.KeySet.\u0031 obj = this;
          this.ids = this.this\u00241.this\u00240.getIds();
          this.index = 0;
        }

        [LineNumberTable(737)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool hasNext() => this.index < this.ids.Length;

        [LineNumberTable(new byte[] {162, 117, 127, 31, 97, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual object next()
        {
          object obj1;
          try
          {
            NativeObject.KeySet.\u0031 obj2 = this;
            object[] ids = this.ids;
            NativeObject.KeySet.\u0031 obj3 = this;
            int index1 = obj3.index;
            NativeObject.KeySet.\u0031 obj4 = obj3;
            int index2 = index1;
            obj4.index = index1 + 1;
            object obj5 = ids[index2];
            object obj6 = obj5;
            this.key = obj5;
            obj1 = obj6;
          }
          catch (Exception ex)
          {
            if (ByteCodeHelper.MapException<ArrayIndexOutOfBoundsException>(ex, (ByteCodeHelper.MapFlags) 2) == null)
              throw;
            else
              goto label_4;
          }
          return obj1;
label_4:
          this.key = (object) null;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new NoSuchElementException();
        }

        [LineNumberTable(new byte[] {162, 126, 104, 139, 119, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void remove()
        {
          if (this.key == null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException();
          }
          this.this\u00241.this\u00240.remove(this.key);
          this.key = (object) null;
        }

        [HideFromJava]
        public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
      }
    }

    [Signature("Ljava/util/AbstractCollection<Ljava/lang/Object;>;")]
    internal class ValueCollection : AbstractCollection
    {
      [Modifiers]
      internal NativeObject this\u00240;

      [LineNumberTable(767)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ValueCollection([In] NativeObject obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [Signature("()Ljava/util/Iterator<Ljava/lang/Object;>;")]
      [LineNumberTable(771)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator() => (Iterator) new NativeObject.ValueCollection.\u0031(this);

      [LineNumberTable(799)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int size() => this.this\u00240.size();

      [InnerClass]
      [Signature("Ljava/lang/Object;Ljava/util/Iterator<Ljava/lang/Object;>;")]
      [EnclosingMethod(null, "iterator", "()Ljava.util.Iterator;")]
      [SpecialName]
      internal class \u0031 : Object, Iterator
      {
        [Modifiers]
        internal object[] ids;
        internal object key;
        internal int index;
        [Modifiers]
        internal NativeObject.ValueCollection this\u00241;

        [LineNumberTable(new byte[] {162, 145, 111, 150})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal \u0031([In] NativeObject.ValueCollection obj0)
        {
          this.this\u00241 = obj0;
          // ISSUE: explicit constructor call
          base.\u002Ector();
          NativeObject.ValueCollection.\u0031 obj = this;
          this.ids = this.this\u00241.this\u00240.getIds();
          this.index = 0;
        }

        [LineNumberTable(778)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual bool hasNext() => this.index < this.ids.Length;

        [LineNumberTable(783)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual object next()
        {
          NativeObject this0 = this.this\u00241.this\u00240;
          NativeObject.ValueCollection.\u0031 obj1 = this;
          object[] ids = this.ids;
          NativeObject.ValueCollection.\u0031 obj2 = this;
          int index1 = obj2.index;
          NativeObject.ValueCollection.\u0031 obj3 = obj2;
          int index2 = index1;
          obj3.index = index1 + 1;
          object obj4 = ids[index2];
          object key = obj4;
          this.key = obj4;
          return this0.get(key);
        }

        [LineNumberTable(new byte[] {162, 162, 104, 139, 119, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void remove()
        {
          if (this.key == null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException();
          }
          this.this\u00241.this\u00240.remove(this.key);
          this.key = (object) null;
        }

        [HideFromJava]
        public virtual void forEachRemaining([In] Consumer obj0) => Iterator.\u003Cdefault\u003EforEachRemaining((Iterator) this, obj0);
      }
    }
  }
}
