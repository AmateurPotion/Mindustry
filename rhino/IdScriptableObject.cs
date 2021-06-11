// Decompiled with JetBrains decompiler
// Type: rhino.IdScriptableObject
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  [Implements(new string[] {"rhino.IdFunctionCall"})]
  public abstract class IdScriptableObject : ScriptableObject, IdFunctionCall
  {
    [NonSerialized]
    private IdScriptableObject.PrototypeValues prototypeValues;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int findInstanceIdInfo(string name) => 0;

    [LineNumberTable(686)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual object getInstanceIdValue(int id)
    {
      string str = String.valueOf(id);
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException(str);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int findInstanceIdInfo(Symbol key) => 0;

    [LineNumberTable(694)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setInstanceIdValue(int id, object value)
    {
      string str = String.valueOf(id);
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException(str);
    }

    [LineNumberTable(new byte[] {162, 80, 117, 118, 25})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setInstanceIdAttributes(int id, int attr) => throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.constructError("InternalError", new StringBuilder().append("Changing attributes not supported for ").append(this.getClassName()).append(" ").append(this.getInstanceIdName(id)).append(" property").toString()));

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int getMaxInstanceId() => 0;

    [LineNumberTable(675)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string getInstanceIdName(int id)
    {
      string str = String.valueOf(id);
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {162, 122, 104, 104, 104, 107, 103, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void activatePrototypeMap(int maxPrototypeId)
    {
      IdScriptableObject.PrototypeValues prototypeValues = new IdScriptableObject.PrototypeValues(this, maxPrototypeId);
      lock (this)
      {
        if (this.prototypeValues != null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
        }
        this.prototypeValues = prototypeValues;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void fillConstructorProperties(IdFunctionObject ctor)
    {
    }

    [LineNumberTable(new byte[] {162, 137, 103, 181, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IdFunctionObject initPrototypeMethod(
      object tag,
      int id,
      string propertyName,
      string functionName,
      int arity)
    {
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope((Scriptable) this);
      IdFunctionObject idFunctionObject = this.newIdFunction(tag, id, functionName == null ? propertyName : functionName, arity, topLevelScope);
      this.prototypeValues.initValue(id, propertyName, (object) idFunctionObject, 2);
      return idFunctionObject;
    }

    [LineNumberTable(new byte[] {162, 226, 113, 144, 174, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private IdFunctionObject newIdFunction(
      [In] object obj0,
      [In] int obj1,
      [In] string obj2,
      [In] int obj3,
      [In] Scriptable obj4)
    {
      IdFunctionObject idFunctionObject = Context.getContext().getLanguageVersion() >= 200 ? (IdFunctionObject) new IdFunctionObjectES6((IdFunctionCall) this, obj0, obj1, obj2, obj3, obj4) : new IdFunctionObject((IdFunctionCall) this, obj0, obj1, obj2, obj3, obj4);
      if (this.isSealed())
        idFunctionObject.sealObject();
      return idFunctionObject;
    }

    [LineNumberTable(new byte[] {163, 43, 105, 99, 104, 111, 104, 178})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override ScriptableObject getOwnPropertyDescriptor(
      Context cx,
      object id)
    {
      ScriptableObject scriptableObject = base.getOwnPropertyDescriptor(cx, id);
      if (scriptableObject == null)
      {
        if (id is string)
          scriptableObject = this.getBuiltInDescriptor((string) id);
        else if (ScriptRuntime.isSymbol(id))
          scriptableObject = this.getBuiltInDescriptor((Symbol) ((NativeSymbol) id).getKey());
      }
      return scriptableObject;
    }

    [LineNumberTable(new byte[] {161, 206, 102, 104, 99, 104, 101, 100, 136, 129, 104, 109, 99, 109, 161, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void setAttributes(string name, int attributes)
    {
      ScriptableObject.checkValidAttributes(attributes);
      int instanceIdInfo = this.findInstanceIdInfo(name);
      if (instanceIdInfo != 0)
      {
        int id = instanceIdInfo & (int) ushort.MaxValue;
        int num = (int) ((uint) instanceIdInfo >> 16);
        if (attributes == num)
          return;
        this.setInstanceIdAttributes(id, attributes);
      }
      else
      {
        if (this.prototypeValues != null)
        {
          int id = this.prototypeValues.findId(name);
          if (id != 0)
          {
            this.prototypeValues.setAttributes(id, attributes);
            return;
          }
        }
        base.setAttributes(name, attributes);
      }
    }

    [LineNumberTable(new byte[] {163, 58, 103, 104, 162, 104, 99, 104, 104, 102, 159, 6, 104, 109, 99, 109, 110, 191, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ScriptableObject getBuiltInDescriptor([In] string obj0)
    {
      object obj1 = (object) this.getParentScope();
      if ((Scriptable) obj1 == null)
        obj1 = (object) this;
      int instanceIdInfo = this.findInstanceIdInfo(obj0);
      if (instanceIdInfo != 0)
      {
        object instanceIdValue = this.getInstanceIdValue(instanceIdInfo & (int) ushort.MaxValue);
        int num1 = (int) ((uint) instanceIdInfo >> 16);
        object obj2 = obj1;
        object obj3 = instanceIdValue;
        int num2 = num1;
        object obj4 = obj3;
        Scriptable scope;
        if (obj2 != null)
          scope = obj2 is Scriptable scriptable4 ? scriptable4 : throw new IncompatibleClassChangeError();
        else
          scope = (Scriptable) null;
        object obj5 = obj4;
        int attributes = num2;
        return ScriptableObject.buildDataDescriptor(scope, obj5, attributes);
      }
      if (this.prototypeValues != null)
      {
        int id = this.prototypeValues.findId(obj0);
        if (id != 0)
        {
          object obj2 = this.prototypeValues.get(id);
          int attributes1 = this.prototypeValues.getAttributes(id);
          object obj3 = obj1;
          object obj4 = obj2;
          int num = attributes1;
          object obj5 = obj4;
          Scriptable scope;
          if (obj3 != null)
            scope = obj3 is Scriptable scriptable8 ? scriptable8 : throw new IncompatibleClassChangeError();
          else
            scope = (Scriptable) null;
          object obj6 = obj5;
          int attributes2 = num;
          return ScriptableObject.buildDataDescriptor(scope, obj6, attributes2);
        }
      }
      return (ScriptableObject) null;
    }

    [LineNumberTable(new byte[] {163, 85, 103, 104, 162, 104, 109, 99, 109, 109, 191, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ScriptableObject getBuiltInDescriptor([In] Symbol obj0)
    {
      object obj1 = (object) this.getParentScope();
      if ((Scriptable) obj1 == null)
        obj1 = (object) this;
      if (this.prototypeValues != null)
      {
        int id = this.prototypeValues.findId(obj0);
        if (id != 0)
        {
          object obj2 = this.prototypeValues.get(id);
          int attributes1 = this.prototypeValues.getAttributes(id);
          object obj3 = obj1;
          object obj4 = obj2;
          int num = attributes1;
          object obj5 = obj4;
          Scriptable scope;
          if (obj3 != null)
            scope = obj3 is Scriptable scriptable6 ? scriptable6 : throw new IncompatibleClassChangeError();
          else
            scope = (Scriptable) null;
          object obj6 = obj5;
          int attributes2 = num;
          return ScriptableObject.buildDataDescriptor(scope, obj6, attributes2);
        }
      }
      return (ScriptableObject) null;
    }

    [LineNumberTable(new byte[] {160, 194, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IdScriptableObject()
    {
    }

    [LineNumberTable(new byte[] {160, 198, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IdScriptableObject(Scriptable scope, Scriptable prototype)
      : base(scope, prototype)
    {
    }

    [LineNumberTable(316)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal bool defaultHas(string name) => base.has(name, (Scriptable) this);

    [LineNumberTable(320)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal object defaultGet(string name) => base.get(name, (Scriptable) this);

    [LineNumberTable(new byte[] {160, 210, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal void defaultPut(string name, object value) => base.put(name, (Scriptable) this, value);

    [LineNumberTable(new byte[] {160, 215, 104, 99, 101, 101, 130, 104, 152, 104, 109, 99, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(string name, Scriptable start)
    {
      int instanceIdInfo = this.findInstanceIdInfo(name);
      if (instanceIdInfo != 0)
      {
        if (((int) ((uint) instanceIdInfo >> 16) & 4) != 0)
          return true;
        int id = instanceIdInfo & (int) ushort.MaxValue;
        return !object.ReferenceEquals(Scriptable.NOT_FOUND, this.getInstanceIdValue(id));
      }
      if (this.prototypeValues != null)
      {
        int id = this.prototypeValues.findId(name);
        if (id != 0)
          return this.prototypeValues.has(id);
      }
      return base.has(name, start);
    }

    [LineNumberTable(new byte[] {160, 236, 104, 99, 101, 101, 130, 104, 152, 104, 109, 99, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(Symbol key, Scriptable start)
    {
      int instanceIdInfo = this.findInstanceIdInfo(key);
      if (instanceIdInfo != 0)
      {
        if (((int) ((uint) instanceIdInfo >> 16) & 4) != 0)
          return true;
        int id = instanceIdInfo & (int) ushort.MaxValue;
        return !object.ReferenceEquals(Scriptable.NOT_FOUND, this.getInstanceIdValue(id));
      }
      if (this.prototypeValues != null)
      {
        int id = this.prototypeValues.findId(key);
        if (id != 0)
          return this.prototypeValues.has(id);
      }
      return base.has(key, start);
    }

    [LineNumberTable(new byte[] {161, 2, 105, 109, 130, 104, 99, 104, 104, 143, 104, 109, 99, 109, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(string name, Scriptable start)
    {
      object objA = base.get(name, start);
      if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        return objA;
      int instanceIdInfo = this.findInstanceIdInfo(name);
      if (instanceIdInfo != 0)
      {
        object instanceIdValue = this.getInstanceIdValue(instanceIdInfo & (int) ushort.MaxValue);
        if (!object.ReferenceEquals(instanceIdValue, Scriptable.NOT_FOUND))
          return instanceIdValue;
      }
      if (this.prototypeValues != null)
      {
        int id = this.prototypeValues.findId(name);
        if (id != 0)
          return this.prototypeValues.get(id);
      }
      return Scriptable.NOT_FOUND;
    }

    [LineNumberTable(new byte[] {161, 24, 105, 109, 130, 104, 99, 104, 104, 143, 104, 109, 99, 109, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(Symbol key, Scriptable start)
    {
      object objA = base.get(key, start);
      if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
        return objA;
      int instanceIdInfo = this.findInstanceIdInfo(key);
      if (instanceIdInfo != 0)
      {
        object instanceIdValue = this.getInstanceIdValue(instanceIdInfo & (int) ushort.MaxValue);
        if (!object.ReferenceEquals(instanceIdValue, Scriptable.NOT_FOUND))
          return instanceIdValue;
      }
      if (this.prototypeValues != null)
      {
        int id = this.prototypeValues.findId(key);
        if (id != 0)
          return this.prototypeValues.get(id);
      }
      return Scriptable.NOT_FOUND;
    }

    [LineNumberTable(new byte[] {161, 46, 104, 99, 113, 177, 101, 101, 105, 104, 104, 98, 169, 129, 104, 109, 99, 113, 177, 110, 161, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(string name, Scriptable start, object value)
    {
      int instanceIdInfo = this.findInstanceIdInfo(name);
      if (instanceIdInfo != 0)
      {
        if (object.ReferenceEquals((object) start, (object) this) && this.isSealed())
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.modify.sealed", (object) name));
        if (((int) ((uint) instanceIdInfo >> 16) & 1) != 0)
          return;
        if (object.ReferenceEquals((object) start, (object) this))
          this.setInstanceIdValue(instanceIdInfo & (int) ushort.MaxValue, value);
        else
          start.put(name, start, value);
      }
      else
      {
        if (this.prototypeValues != null)
        {
          int id = this.prototypeValues.findId(name);
          if (id != 0)
          {
            if (object.ReferenceEquals((object) start, (object) this) && this.isSealed())
              throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.modify.sealed", (object) name));
            this.prototypeValues.set(id, start, value);
            return;
          }
        }
        base.put(name, start, value);
      }
    }

    [LineNumberTable(new byte[] {161, 79, 104, 99, 113, 144, 101, 101, 105, 104, 104, 98, 174, 129, 104, 109, 99, 113, 144, 110, 161, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void put(Symbol key, Scriptable start, object value)
    {
      int instanceIdInfo = this.findInstanceIdInfo(key);
      if (instanceIdInfo != 0)
      {
        if (object.ReferenceEquals((object) start, (object) this) && this.isSealed())
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.modify.sealed"));
        if (((int) ((uint) instanceIdInfo >> 16) & 1) != 0)
          return;
        if (object.ReferenceEquals((object) start, (object) this))
          this.setInstanceIdValue(instanceIdInfo & (int) ushort.MaxValue, value);
        else
          ScriptableObject.ensureSymbolScriptable((object) start).put(key, start, value);
      }
      else
      {
        if (this.prototypeValues != null)
        {
          int id = this.prototypeValues.findId(key);
          if (id != 0)
          {
            if (object.ReferenceEquals((object) start, (object) this) && this.isSealed())
              throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError0("msg.modify.sealed"));
            this.prototypeValues.set(id, start, value);
            return;
          }
        }
        base.put(key, start, value);
      }
    }

    [LineNumberTable(new byte[] {161, 110, 104, 131, 104, 133, 101, 102, 104, 145, 98, 104, 140, 161, 104, 109, 99, 104, 140, 161, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void delete(string name)
    {
      int instanceIdInfo = this.findInstanceIdInfo(name);
      if (instanceIdInfo != 0 && !this.isSealed())
      {
        if (((int) ((uint) instanceIdInfo >> 16) & 4) != 0)
        {
          if (Context.getContext().isStrictMode())
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.delete.property.with.configurable.false", (object) name));
        }
        else
          this.setInstanceIdValue(instanceIdInfo & (int) ushort.MaxValue, Scriptable.NOT_FOUND);
      }
      else
      {
        if (this.prototypeValues != null)
        {
          int id = this.prototypeValues.findId(name);
          if (id != 0)
          {
            if (this.isSealed())
              return;
            this.prototypeValues.delete(id);
            return;
          }
        }
        base.delete(name);
      }
    }

    [LineNumberTable(new byte[] {161, 142, 104, 131, 104, 133, 101, 102, 104, 144, 98, 104, 140, 161, 104, 109, 99, 104, 140, 161, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void delete(Symbol key)
    {
      int instanceIdInfo = this.findInstanceIdInfo(key);
      if (instanceIdInfo != 0 && !this.isSealed())
      {
        if (((int) ((uint) instanceIdInfo >> 16) & 4) != 0)
        {
          if (Context.getContext().isStrictMode())
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError0("msg.delete.property.with.configurable.false"));
        }
        else
          this.setInstanceIdValue(instanceIdInfo & (int) ushort.MaxValue, Scriptable.NOT_FOUND);
      }
      else
      {
        if (this.prototypeValues != null)
        {
          int id = this.prototypeValues.findId(key);
          if (id != 0)
          {
            if (this.isSealed())
              return;
            this.prototypeValues.delete(id);
            return;
          }
        }
        base.delete(key);
      }
    }

    [LineNumberTable(new byte[] {161, 174, 104, 99, 101, 130, 104, 109, 99, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getAttributes(string name)
    {
      int instanceIdInfo = this.findInstanceIdInfo(name);
      if (instanceIdInfo != 0)
        return (int) ((uint) instanceIdInfo >> 16);
      if (this.prototypeValues != null)
      {
        int id = this.prototypeValues.findId(name);
        if (id != 0)
          return this.prototypeValues.getAttributes(id);
      }
      return base.getAttributes(name);
    }

    [LineNumberTable(new byte[] {161, 190, 104, 99, 101, 130, 104, 109, 99, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int getAttributes(Symbol key)
    {
      int instanceIdInfo = this.findInstanceIdInfo(key);
      if (instanceIdInfo != 0)
        return (int) ((uint) instanceIdInfo >> 16);
      if (this.prototypeValues != null)
      {
        int id = this.prototypeValues.findId(key);
        if (id != 0)
          return this.prototypeValues.getAttributes(id);
      }
      return base.getAttributes(key);
    }

    [LineNumberTable(new byte[] {158, 249, 132, 137, 104, 175, 103, 102, 99, 131, 106, 106, 106, 100, 103, 102, 116, 162, 105, 132, 137, 237, 49, 235, 83, 100, 107, 133, 108, 108, 110, 195})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal override object[] getIds([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      object[] objArray1 = base.getIds(num1 != 0, num2 != 0);
      if (this.prototypeValues != null)
        objArray1 = this.prototypeValues.getNames(num1 != 0, num2 != 0, objArray1);
      int maxInstanceId = this.getMaxInstanceId();
      if (maxInstanceId != 0)
      {
        object[] objArray2 = (object[]) null;
        int num3 = 0;
        for (int id = maxInstanceId; id != 0; id += -1)
        {
          string instanceIdName = this.getInstanceIdName(id);
          int instanceIdInfo = this.findInstanceIdInfo(instanceIdName);
          if (instanceIdInfo != 0)
          {
            int num4 = (int) ((uint) instanceIdInfo >> 16);
            if (((num4 & 4) != 0 || !object.ReferenceEquals(Scriptable.NOT_FOUND, this.getInstanceIdValue(id))) && (num1 != 0 || (num4 & 2) == 0))
            {
              if (num3 == 0)
                objArray2 = new object[id];
              object[] objArray3 = objArray2;
              int index = num3;
              ++num3;
              string str = instanceIdName;
              objArray3[index] = (object) str;
            }
          }
        }
        if (num3 != 0)
        {
          if (objArray1.Length == 0 && objArray2.Length == num3)
          {
            objArray1 = objArray2;
          }
          else
          {
            object[] objArray3 = new object[objArray1.Length + num3];
            ByteCodeHelper.arraycopy((object) objArray1, 0, (object) objArray3, 0, objArray1.Length);
            ByteCodeHelper.arraycopy((object) objArray2, 0, (object) objArray3, objArray1.Length, num3);
            objArray1 = objArray3;
          }
        }
      }
      return objArray1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static int instanceIdInfo(int attributes, int id) => attributes << 16 | id;

    [LineNumberTable(718)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      throw Throwable.__\u003Cunmap\u003E((Exception) f.unknown());
    }

    [LineNumberTable(new byte[] {158, 217, 98, 108, 103, 172, 103, 108, 99, 134, 103, 99, 134, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IdFunctionObject exportAsJSClass(
      int maxPrototypeId,
      Scriptable scope,
      bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      if (!object.ReferenceEquals((object) scope, (object) this) && scope != null)
      {
        this.setParentScope(scope);
        this.setPrototype(ScriptableObject.getObjectPrototype(scope));
      }
      this.activatePrototypeMap(maxPrototypeId);
      IdFunctionObject precachedConstructor = this.prototypeValues.createPrecachedConstructor();
      if (num != 0)
        this.sealObject();
      this.fillConstructorProperties(precachedConstructor);
      if (num != 0)
        precachedConstructor.sealObject();
      precachedConstructor.exportAsScopeProperty();
      return precachedConstructor;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool hasPrototypeMap() => this.prototypeValues != null;

    [LineNumberTable(758)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IdFunctionObject initPrototypeMethod(
      object tag,
      int id,
      string name,
      int arity)
    {
      return this.initPrototypeMethod(tag, id, name, name, arity);
    }

    [LineNumberTable(new byte[] {162, 147, 103, 110, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IdFunctionObject initPrototypeMethod(
      object tag,
      int id,
      Symbol key,
      string functionName,
      int arity)
    {
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope((Scriptable) this);
      IdFunctionObject idFunctionObject = this.newIdFunction(tag, id, functionName, arity, topLevelScope);
      this.prototypeValues.initValue(id, key, (object) idFunctionObject, 2);
      return idFunctionObject;
    }

    [LineNumberTable(new byte[] {162, 154, 108, 99, 107, 105, 107, 104, 134, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initPrototypeConstructor(IdFunctionObject f)
    {
      int constructorId = this.prototypeValues.constructorId;
      if (constructorId == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalStateException();
      }
      if (f.methodId() != constructorId)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (this.isSealed())
        f.sealObject();
      this.prototypeValues.initValue(constructorId, "constructor", (object) f, 2);
    }

    [LineNumberTable(new byte[] {162, 167, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initPrototypeValue(int id, string name, object value, int attributes) => this.prototypeValues.initValue(id, name, value, attributes);

    [LineNumberTable(new byte[] {162, 172, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void initPrototypeValue(int id, Symbol key, object value, int attributes) => this.prototypeValues.initValue(id, key, value, attributes);

    [LineNumberTable(802)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void initPrototypeId(int id)
    {
      string str = String.valueOf(id);
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException(str);
    }

    [LineNumberTable(806)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int findPrototypeId(string name)
    {
      string str = name;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalStateException(str);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int findPrototypeId(Symbol key) => 0;

    [LineNumberTable(new byte[] {162, 192, 103, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void addIdFunctionProperty(
      Scriptable obj,
      object tag,
      int id,
      string name,
      int arity)
    {
      Scriptable topLevelScope = ScriptableObject.getTopLevelScope(obj);
      this.newIdFunction(tag, id, name, arity, topLevelScope).addAsProperty(obj);
    }

    [LineNumberTable(new byte[] {162, 219, 102, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static EcmaError incompatibleCallError(IdFunctionObject f) => throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.incompat.call", (object) f.getFunctionName()));

    [LineNumberTable(new byte[] {162, 240, 107, 103, 104, 102, 104, 105, 140, 103, 105, 105, 102, 109, 116, 105, 108, 169, 112, 161, 107, 109, 102, 105, 145, 103, 105, 105, 110, 109, 116, 110, 108, 175, 213, 106, 167, 225, 69, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void defineOwnProperty(Context cx, object key, ScriptableObject desc)
    {
      if (key is string)
      {
        string name = (string) key;
        int instanceIdInfo = this.findInstanceIdInfo(name);
        if (instanceIdInfo != 0)
        {
          int num = instanceIdInfo & (int) ushort.MaxValue;
          if (this.isAccessorDescriptor(desc))
          {
            this.delete(num);
          }
          else
          {
            this.checkPropertyDefinition(desc);
            ScriptableObject propertyDescriptor = this.getOwnPropertyDescriptor(cx, key);
            this.checkPropertyChange((object) name, propertyDescriptor, desc);
            int attributes = (int) ((uint) instanceIdInfo >> 16);
            object property = ScriptableObject.getProperty((Scriptable) desc, "value");
            if (!object.ReferenceEquals(property, Scriptable.NOT_FOUND) && (attributes & 1) == 0)
            {
              object instanceIdValue = this.getInstanceIdValue(num);
              if (!this.sameValue(property, instanceIdValue))
                this.setInstanceIdValue(num, property);
            }
            this.setAttributes(name, this.applyDescriptorToAttributeBitset(attributes, desc));
            return;
          }
        }
        if (this.prototypeValues != null)
        {
          int id = this.prototypeValues.findId(name);
          if (id != 0)
          {
            if (this.isAccessorDescriptor(desc))
            {
              this.prototypeValues.delete(id);
            }
            else
            {
              this.checkPropertyDefinition(desc);
              ScriptableObject propertyDescriptor = this.getOwnPropertyDescriptor(cx, key);
              this.checkPropertyChange((object) name, propertyDescriptor, desc);
              int attributes = this.prototypeValues.getAttributes(id);
              object property = ScriptableObject.getProperty((Scriptable) desc, "value");
              if (!object.ReferenceEquals(property, Scriptable.NOT_FOUND) && (attributes & 1) == 0)
              {
                object currentValue = this.prototypeValues.get(id);
                if (!this.sameValue(property, currentValue))
                  this.prototypeValues.set(id, (Scriptable) this, property);
              }
              this.prototypeValues.setAttributes(id, this.applyDescriptorToAttributeBitset(attributes, desc));
              if (!base.has(name, (Scriptable) this))
                return;
              base.delete(name);
              return;
            }
          }
        }
      }
      base.defineOwnProperty(cx, key, desc);
    }

    [Throws(new string[] {"java.io.IOException", "java.lang.ClassNotFoundException"})]
    [LineNumberTable(new byte[] {163, 103, 102, 103, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readObject([In] ObjectInputStream obj0)
    {
      obj0.defaultReadObject();
      int maxPrototypeId = obj0.readInt();
      if (maxPrototypeId == 0)
        return;
      this.activatePrototypeMap(maxPrototypeId);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {163, 112, 102, 98, 104, 140, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void writeObject([In] ObjectOutputStream obj0)
    {
      obj0.defaultWriteObject();
      int num = 0;
      if (this.prototypeValues != null)
        num = this.prototypeValues.getMaxId();
      obj0.writeInt(num);
    }

    [HideFromJava]
    static IdScriptableObject() => ScriptableObject.__\u003Cclinit\u003E();

    [InnerClass]
    internal sealed class PrototypeValues : Object
    {
      private const int NAME_SLOT = 1;
      private const int SLOT_SPAN = 2;
      [Modifiers]
      private IdScriptableObject obj;
      [Modifiers]
      private int maxId;
      private object[] valueArray;
      private short[] attributeArray;
      internal int constructorId;
      private IdFunctionObject constructor;
      private short constructorAttrs;

      [LineNumberTable(144)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal int findId([In] string obj0) => this.obj.findPrototypeId(obj0);

      [LineNumberTable(new byte[] {102, 103, 131, 130, 102, 100, 131, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal bool has([In] int obj0)
      {
        object[] valueArray = this.valueArray;
        if (valueArray == null)
          return true;
        int index = (obj0 - 1) * 2;
        object objA = valueArray[index];
        return objA == null || !object.ReferenceEquals(objA, Scriptable.NOT_FOUND);
      }

      [LineNumberTable(148)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal int findId([In] Symbol obj0) => this.obj.findPrototypeId(obj0);

      [LineNumberTable(new byte[] {117, 104, 109, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal object get([In] int obj0)
      {
        object objA = this.ensureId(obj0);
        if (object.ReferenceEquals(objA, (object) UniqueTag.__\u003C\u003ENULL_VALUE))
          objA = (object) null;
        return objA;
      }

      [LineNumberTable(new byte[] {125, 120, 104, 107, 104, 110, 99, 135, 102, 104, 105, 111, 98, 104, 105, 104, 104, 181, 206})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal void set([In] int obj0, [In] Scriptable obj1, [In] object obj2)
      {
        if (object.ReferenceEquals(obj2, Scriptable.NOT_FOUND))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        this.ensureId(obj0);
        if (((int) this.attributeArray[obj0 - 1] & 1) != 0)
          return;
        if (object.ReferenceEquals((object) obj1, (object) this.obj))
        {
          if (obj2 == null)
            obj2 = (object) UniqueTag.__\u003C\u003ENULL_VALUE;
          int index = (obj0 - 1) * 2;
          lock (this)
            this.valueArray[index] = obj2;
        }
        else
        {
          object obj = this.valueArray[(obj0 - 1) * 2 + 1];
          if (obj is Symbol)
          {
            if (!(obj1 is SymbolScriptable))
              return;
            ((SymbolScriptable) obj1).put((Symbol) obj, obj1, obj2);
          }
          else
            obj1.put((string) obj, obj1, obj2);
        }
      }

      [LineNumberTable(new byte[] {160, 88, 104, 139, 101, 102, 104, 104, 110, 145, 98, 103, 105, 110, 107, 144})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal void delete([In] int obj0)
      {
        this.ensureId(obj0);
        if (((int) this.attributeArray[obj0 - 1] & 4) != 0)
        {
          if (Context.getContext().isStrictMode())
            throw Throwable.__\u003Cunmap\u003E((Exception) ScriptRuntime.typeError1("msg.delete.property.with.configurable.false", (object) (string) this.valueArray[(obj0 - 1) * 2 + 1]));
        }
        else
        {
          int index = (obj0 - 1) * 2;
          lock (this)
          {
            this.valueArray[index] = Scriptable.NOT_FOUND;
            this.attributeArray[obj0 - 1] = (short) 0;
          }
        }
      }

      [LineNumberTable(new byte[] {160, 108, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal int getAttributes([In] int obj0)
      {
        this.ensureId(obj0);
        return (int) this.attributeArray[obj0 - 1];
      }

      [LineNumberTable(new byte[] {160, 113, 102, 104, 104, 108, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal void setAttributes([In] int obj0, [In] int obj1)
      {
        ScriptableObject.checkValidAttributes(obj1);
        this.ensureId(obj0);
        lock (this)
          this.attributeArray[obj0 - 1] = (short) obj1;
      }

      [LineNumberTable(new byte[] {159, 84, 164, 98, 98, 112, 106, 117, 113, 106, 107, 105, 99, 140, 107, 108, 99, 140, 238, 49, 235, 84, 99, 98, 103, 101, 104, 107, 131, 130, 100, 107, 108, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal object[] getNames([In] bool obj0, [In] bool obj1, [In] object[] obj2)
      {
        int num1 = obj0 ? 1 : 0;
        int num2 = obj1 ? 1 : 0;
        object[] objArray1 = (object[]) null;
        int length1 = 0;
        for (int index1 = 1; index1 <= this.maxId; ++index1)
        {
          object objA = this.ensureId(index1);
          if ((num1 != 0 || ((int) this.attributeArray[index1 - 1] & 2) == 0) && !object.ReferenceEquals(objA, Scriptable.NOT_FOUND))
          {
            object obj3 = this.valueArray[(index1 - 1) * 2 + 1];
            if (obj3 is string)
            {
              if (objArray1 == null)
                objArray1 = new object[this.maxId];
              object[] objArray2 = objArray1;
              int index2 = length1;
              ++length1;
              object obj4 = obj3;
              objArray2[index2] = obj4;
            }
            else if (num2 != 0 && obj3 is Symbol)
            {
              if (objArray1 == null)
                objArray1 = new object[this.maxId];
              object[] objArray2 = objArray1;
              int index2 = length1;
              ++length1;
              string str = Object.instancehelper_toString(obj3);
              objArray2[index2] = (object) str;
            }
          }
        }
        if (length1 == 0)
          return obj2;
        if (obj2 == null || obj2.Length == 0)
        {
          if (length1 != objArray1.Length)
          {
            object[] objArray2 = new object[length1];
            ByteCodeHelper.arraycopy((object) objArray1, 0, (object) objArray2, 0, length1);
            objArray1 = objArray2;
          }
          return objArray1;
        }
        int length2 = obj2.Length;
        object[] objArray3 = new object[length2 + length1];
        ByteCodeHelper.arraycopy((object) obj2, 0, (object) objArray3, 0, length2);
        ByteCodeHelper.arraycopy((object) objArray1, 0, (object) objArray3, length2, length1);
        return objArray3;
      }

      [LineNumberTable(new byte[] {75, 115, 118, 104, 176, 113, 104, 107, 191, 21, 119, 37, 133, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal IdFunctionObject createPrecachedConstructor()
      {
        if (this.constructorId != 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
        }
        this.constructorId = this.obj.findPrototypeId("constructor");
        if (this.constructorId == 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException("No id for constructor property");
        }
        this.obj.initPrototypeId(this.constructorId);
        if (this.constructor == null)
        {
          string str = new StringBuilder().append(Object.instancehelper_getClass((object) this.obj).getName()).append(".initPrototypeId() did not initialize id=").append(this.constructorId).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException(str);
        }
        this.constructor.initFunction(this.obj.getClassName(), ScriptableObject.getTopLevelScope((Scriptable) this.obj));
        this.constructor.markAsConstructor((Scriptable) this.obj);
        return this.constructor;
      }

      [LineNumberTable(new byte[] {159, 186, 104, 110, 111, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal PrototypeValues([In] IdScriptableObject obj0, [In] int obj1)
      {
        IdScriptableObject.PrototypeValues prototypeValues = this;
        if (obj0 == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        if (obj1 < 1)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        this.obj = obj0;
        this.maxId = obj1;
      }

      [LineNumberTable(new byte[] {6, 109, 107, 99, 107, 109, 107, 103, 111, 140, 105, 104, 144, 108, 105, 161, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal void initValue([In] int obj0, [In] string obj1, [In] object obj2, [In] int obj3)
      {
        if (1 > obj0 || obj0 > this.maxId)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        if (obj1 == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        if (object.ReferenceEquals(obj2, Scriptable.NOT_FOUND))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        ScriptableObject.checkValidAttributes(obj3);
        if (this.obj.findPrototypeId(obj1) != obj0)
        {
          string str = obj1;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
        if (obj0 == this.constructorId)
        {
          if (!(obj2 is IdFunctionObject))
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("consructor should be initialized with IdFunctionObject");
          }
          this.constructor = (IdFunctionObject) obj2;
          this.constructorAttrs = (short) obj3;
        }
        else
          this.initSlot(obj0, (object) obj1, obj2, obj3);
      }

      [LineNumberTable(new byte[] {29, 109, 107, 99, 107, 109, 107, 103, 111, 145, 105, 104, 144, 108, 105, 161, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal void initValue([In] int obj0, [In] Symbol obj1, [In] object obj2, [In] int obj3)
      {
        if (1 > obj0 || obj0 > this.maxId)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        if (obj1 == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        if (object.ReferenceEquals(obj2, Scriptable.NOT_FOUND))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        ScriptableObject.checkValidAttributes(obj3);
        if (this.obj.findPrototypeId(obj1) != obj0)
        {
          string str = Object.instancehelper_toString((object) obj1);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
        if (obj0 == this.constructorId)
        {
          if (!(obj2 is IdFunctionObject))
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("consructor should be initialized with IdFunctionObject");
          }
          this.constructor = (IdFunctionObject) obj2;
          this.constructorAttrs = (short) obj3;
        }
        else
          this.initSlot(obj0, (object) obj1, obj2, obj3);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      internal int getMaxId() => this.maxId;

      [LineNumberTable(new byte[] {53, 103, 99, 139, 99, 135, 102, 104, 100, 99, 100, 102, 143, 109, 139, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void initSlot([In] int obj0, [In] object obj1, [In] object obj2, [In] int obj3)
      {
        object[] valueArray = this.valueArray;
        if (valueArray == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalStateException();
        }
        if (obj2 == null)
          obj2 = (object) UniqueTag.__\u003C\u003ENULL_VALUE;
        int index = (obj0 - 1) * 2;
        lock (this)
        {
          if (valueArray[index] == null)
          {
            valueArray[index] = obj2;
            valueArray[index + 1] = obj1;
            this.attributeArray[obj0 - 1] = (short) obj3;
          }
          else if (!Object.instancehelper_equals(obj1, valueArray[index + 1]))
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException();
          }
        }
      }

      [LineNumberTable(new byte[] {160, 162, 103, 99, 104, 103, 99, 110, 103, 145, 143, 102, 100, 102, 105, 157, 137, 140, 100, 99, 107, 223, 16})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object ensureId([In] int obj0)
      {
        object[] objArray = this.valueArray;
        if (objArray == null)
        {
          lock (this)
          {
            objArray = this.valueArray;
            if (objArray == null)
            {
              objArray = new object[this.maxId * 2];
              this.valueArray = objArray;
              this.attributeArray = new short[this.maxId];
            }
          }
        }
        int index = (obj0 - 1) * 2;
        object obj = objArray[index];
        if (obj == null)
        {
          if (obj0 == this.constructorId)
          {
            this.initSlot(this.constructorId, (object) "constructor", (object) this.constructor, (int) this.constructorAttrs);
            this.constructor = (IdFunctionObject) null;
          }
          else
            this.obj.initPrototypeId(obj0);
          obj = objArray[index];
          if (obj == null)
          {
            string str = new StringBuilder().append(Object.instancehelper_getClass((object) this.obj).getName()).append(".initPrototypeId(int id) did not initialize id=").append(obj0).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalStateException(str);
          }
        }
        return obj;
      }
    }
  }
}
