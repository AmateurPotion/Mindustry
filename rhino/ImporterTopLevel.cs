// Decompiled with JetBrains decompiler
// Type: rhino.ImporterTopLevel
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace rhino
{
  public class ImporterTopLevel : TopLevel
  {
    [Modifiers]
    private static object IMPORTER_TAG;
    private const int Id_constructor = 1;
    private const int Id_importClass = 2;
    private const int Id_importPackage = 3;
    private const int MAX_PROTOTYPE_ID = 3;
    [Modifiers]
    private ObjArray importedPackages;
    private bool topScopeFlag;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 184, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImporterTopLevel(Context cx)
      : this(cx, false)
    {
    }

    [LineNumberTable(new byte[] {159, 131, 98, 232, 160, 242, 235, 159, 15, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImporterTopLevel(Context cx, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      ImporterTopLevel importerTopLevel = this;
      this.importedPackages = new ObjArray();
      this.initStandardObjects(cx, num != 0);
    }

    [LineNumberTable(new byte[] {159, 127, 130, 105, 199, 106, 99, 230, 69, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void initStandardObjects(Context cx, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      cx.initStandardObjects((ScriptableObject) this, num != 0);
      this.topScopeFlag = true;
      IdFunctionObject idFunctionObject = this.exportAsJSClass(3, (Scriptable) this, false);
      if (num != 0)
        idFunctionObject.sealObject();
      this.delete("constructor");
    }

    [LineNumberTable(new byte[] {159, 180, 232, 160, 249, 235, 159, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ImporterTopLevel()
    {
      ImporterTopLevel importerTopLevel = this;
      this.importedPackages = new ObjArray();
    }

    [LineNumberTable(new byte[] {43, 134, 109, 108, 111, 106, 106, 108, 109, 109, 133, 102, 44, 235, 57, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object getPackageProperty([In] string obj0, [In] Scriptable obj1)
    {
      object objA = Scriptable.NOT_FOUND;
      object[] array;
      lock (this.importedPackages)
        array = this.importedPackages.toArray();
      for (int index = 0; index < array.Length; ++index)
      {
        object pkgProperty = ((NativeJavaPackage) array[index]).getPkgProperty(obj0, obj1, false);
        if (pkgProperty != null && !(pkgProperty is NativeJavaPackage))
          objA = object.ReferenceEquals(objA, Scriptable.NOT_FOUND) ? pkgProperty : throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError2("msg.ambig.import", (object) Object.instancehelper_toString(objA), (object) Object.instancehelper_toString(pkgProperty)));
      }
      return objA;
    }

    [LineNumberTable(new byte[] {108, 103, 100, 104, 102, 37, 171, 236, 58, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_importPackage([In] object[] obj0)
    {
      for (int index = 0; index != obj0.Length; ++index)
      {
        object obj = obj0[index];
        if (!(obj is NativeJavaPackage))
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.not.pkg", (object) Context.toString(obj)));
        this.importPackage((NativeJavaPackage) obj);
      }
      return Undefined.__\u003C\u003Einstance;
    }

    [LineNumberTable(new byte[] {160, 70, 108, 113, 105, 118, 177, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void importClass([In] NativeJavaClass obj0)
    {
      string name1 = obj0.getClassObject().getName();
      string name2 = String.instancehelper_substring(name1, String.instancehelper_lastIndexOf(name1, 46) + 1);
      object objA = this.get(name2, (Scriptable) this);
      if (!object.ReferenceEquals(objA, Scriptable.NOT_FOUND) && !object.ReferenceEquals(objA, (object) obj0))
        throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.prop.defined", (object) name2));
      this.put(name2, (Scriptable) this, (object) obj0);
    }

    [LineNumberTable(new byte[] {120, 99, 129, 109, 112, 116, 8, 230, 69, 108, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void importPackage([In] NativeJavaPackage obj0)
    {
      if (obj0 == null)
        return;
      ObjArray importedPackages;
      Monitor.Enter((object) (importedPackages = this.importedPackages));
      // ISSUE: fault handler
      try
      {
        for (int index = 0; index != this.importedPackages.size(); ++index)
        {
          if (obj0.equals(this.importedPackages.get(index)))
          {
            Monitor.Exit((object) importedPackages);
            return;
          }
        }
        this.importedPackages.add((object) obj0);
        Monitor.Exit((object) importedPackages);
      }
      __fault
      {
        Monitor.Exit((object) importedPackages);
      }
    }

    [LineNumberTable(new byte[] {35, 105, 109, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object get(string name, Scriptable start)
    {
      object objA = base.get(name, start);
      return !object.ReferenceEquals(objA, Scriptable.NOT_FOUND) ? objA : this.getPackageProperty(name, start);
    }

    [LineNumberTable(new byte[] {73, 102, 103, 100, 104, 110, 104, 142, 102, 37, 235, 57, 233, 80, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_construct([In] Scriptable obj0, [In] object[] obj1)
    {
      ImporterTopLevel importerTopLevel = new ImporterTopLevel();
      for (int index = 0; index != obj1.Length; ++index)
      {
        object obj = obj1[index];
        switch (obj)
        {
          case NativeJavaClass _:
            importerTopLevel.importClass((NativeJavaClass) obj);
            break;
          case NativeJavaPackage _:
            importerTopLevel.importPackage((NativeJavaPackage) obj);
            break;
          default:
            throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.not.class.not.pkg", (object) Context.toString(obj)));
        }
      }
      importerTopLevel.setParentScope(obj0);
      importerTopLevel.setPrototype((Scriptable) this);
      return (object) importerTopLevel;
    }

    [LineNumberTable(new byte[] {160, 124, 168, 130, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ImporterTopLevel realThis([In] Scriptable obj0, [In] IdFunctionObject obj1)
    {
      if (this.topScopeFlag)
        return this;
      return obj0 is ImporterTopLevel ? (ImporterTopLevel) obj0 : throw Throwable.__\u003Cunmap\u003E((Exception) IdScriptableObject.incompatibleCallError(obj1));
    }

    [LineNumberTable(new byte[] {96, 103, 100, 104, 102, 37, 171, 236, 58, 230, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object js_importClass([In] object[] obj0)
    {
      for (int index = 0; index != obj0.Length; ++index)
      {
        object obj = obj0[index];
        if (!(obj is NativeJavaClass))
          throw Throwable.__\u003Cunmap\u003E((Exception) Context.reportRuntimeError1("msg.not.class", (object) Context.toString(obj)));
        this.importClass((NativeJavaClass) obj);
      }
      return Undefined.__\u003C\u003Einstance;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string getClassName() => this.topScopeFlag ? "global" : "JavaImporter";

    [LineNumberTable(new byte[] {159, 129, 162, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void init(Context cx, Scriptable scope, bool @sealed)
    {
      int num = @sealed ? 1 : 0;
      new ImporterTopLevel().exportAsJSClass(3, scope, num != 0);
    }

    [LineNumberTable(new byte[] {29, 109, 53})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool has(string name, Scriptable start) => base.has(name, start) || !object.ReferenceEquals(this.getPackageProperty(name, start), Scriptable.NOT_FOUND);

    [Obsolete]
    [LineNumberTable(new byte[] {69, 104})]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void importPackage(
      Context cx,
      Scriptable thisObj,
      object[] args,
      Function funObj)
    {
      this.js_importPackage(args);
    }

    [LineNumberTable(new byte[] {160, 84, 150, 98, 102, 130, 98, 102, 130, 98, 102, 130, 145, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void initPrototypeId(int id)
    {
      int arity;
      string name;
      switch (id)
      {
        case 1:
          arity = 0;
          name = "constructor";
          break;
        case 2:
          arity = 1;
          name = "importClass";
          break;
        case 3:
          arity = 1;
          name = "importPackage";
          break;
        default:
          string str = String.valueOf(id);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
      this.initPrototypeMethod(ImporterTopLevel.IMPORTER_TAG, id, name, arity);
    }

    [LineNumberTable(new byte[] {160, 106, 109, 142, 103, 150, 170, 177, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object execIdCall(
      IdFunctionObject f,
      Context cx,
      Scriptable scope,
      Scriptable thisObj,
      object[] args)
    {
      if (!f.hasTag(ImporterTopLevel.IMPORTER_TAG))
        return base.execIdCall(f, cx, scope, thisObj, args);
      int num = f.methodId();
      switch (num)
      {
        case 1:
          return this.js_construct(scope, args);
        case 2:
          return this.realThis(thisObj, f).js_importClass(args);
        case 3:
          return this.realThis(thisObj, f).js_importPackage(args);
        default:
          string str = String.valueOf(num);
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {160, 142, 98, 130, 103, 101, 104, 101, 102, 100, 101, 102, 132, 101, 102, 130, 183})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int findPrototypeId(string s)
    {
      int num = 0;
      string str = (string) null;
      switch (String.instancehelper_length(s))
      {
        case 11:
          switch (String.instancehelper_charAt(s, 0))
          {
            case 'c':
              str = "constructor";
              num = 1;
              break;
            case 'i':
              str = "importClass";
              num = 2;
              break;
          }
          break;
        case 13:
          str = "importPackage";
          num = 3;
          break;
      }
      if (str != null && !object.ReferenceEquals((object) str, (object) s) && !String.instancehelper_equals(str, (object) s))
        num = 0;
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static ImporterTopLevel()
    {
      TopLevel.__\u003Cclinit\u003E();
      if (ByteCodeHelper.isAlreadyInited("rhino.ImporterTopLevel"))
        return;
      ImporterTopLevel.IMPORTER_TAG = (object) "Importer";
    }
  }
}
