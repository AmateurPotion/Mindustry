// Decompiled with JetBrains decompiler
// Type: com.sun.jna.Union
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.lang.reflect;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public abstract class Union : Structure
  {
    private Structure.StructField activeField;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal new static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {52, 102, 114, 99, 169, 191, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setType(string fieldName)
    {
      this.ensureAllocated();
      Structure.StructField structField = (Structure.StructField) this.fields().get((object) fieldName);
      if (structField != null)
      {
        this.activeField = structField;
      }
      else
      {
        string str = new StringBuilder().append("No field named ").append(fieldName).append(" in ").append((object) this).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [Signature("(Ljava/lang/Class<*>;)Lcom/sun/jna/Structure$StructField;")]
    [LineNumberTable(new byte[] {160, 82, 102, 127, 6, 110, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Structure.StructField findField([In] Class obj0)
    {
      this.ensureAllocated();
      Iterator iterator = this.fields().values().iterator();
      while (iterator.hasNext())
      {
        Structure.StructField structField = (Structure.StructField) iterator.next();
        if (structField.type.isAssignableFrom(obj0))
          return structField;
      }
      return (Structure.StructField) null;
    }

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Union()
    {
    }

    [LineNumberTable(new byte[] {159, 191, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Union(Pointer p)
      : base(p)
    {
    }

    [LineNumberTable(new byte[] {3, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Union(Pointer p, int alignType)
      : base(p, alignType)
    {
    }

    [LineNumberTable(new byte[] {7, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Union(TypeMapper mapper)
      : base(mapper)
    {
    }

    [LineNumberTable(new byte[] {11, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Union(Pointer p, int alignType, TypeMapper mapper)
      : base(p, alignType, mapper)
    {
    }

    [Signature("()Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(new byte[] {19, 103, 113, 123, 109, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override List getFieldOrder()
    {
      List fieldList = this.getFieldList();
      ArrayList.__\u003Cclinit\u003E();
      ArrayList arrayList = new ArrayList(fieldList.size());
      Iterator iterator = fieldList.iterator();
      while (iterator.hasNext())
      {
        Field field = (Field) iterator.next();
        ((List) arrayList).add((object) field.getName());
      }
      return (List) arrayList;
    }

    [Signature("(Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {35, 102, 127, 6, 110, 103, 129, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setType(Class type)
    {
      this.ensureAllocated();
      Iterator iterator = this.fields().values().iterator();
      while (iterator.hasNext())
      {
        Structure.StructField structField = (Structure.StructField) iterator.next();
        if (object.ReferenceEquals((object) structField.type, (object) type))
        {
          this.activeField = structField;
          return;
        }
      }
      string str = new StringBuilder().append("No field of type ").append((object) type).append(" in ").append((object) this).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {69, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override object readField(string fieldName)
    {
      this.ensureAllocated();
      this.setType(fieldName);
      return base.readField(fieldName);
    }

    [LineNumberTable(new byte[] {80, 102, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void writeField(string fieldName)
    {
      this.ensureAllocated();
      this.setType(fieldName);
      base.writeField(fieldName);
    }

    [LineNumberTable(new byte[] {91, 102, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void writeField(string fieldName, object value)
    {
      this.ensureAllocated();
      this.setType(fieldName);
      base.writeField(fieldName, value);
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {109, 102, 127, 6, 110, 103, 102, 146, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getTypedValue(Class type)
    {
      this.ensureAllocated();
      Iterator iterator = this.fields().values().iterator();
      while (iterator.hasNext())
      {
        Structure.StructField structField = (Structure.StructField) iterator.next();
        if (object.ReferenceEquals((object) structField.type, (object) type))
        {
          this.activeField = structField;
          this.read();
          return this.getFieldValue(this.activeField.field);
        }
      }
      string str = new StringBuilder().append("No field of type ").append((object) type).append(" in ").append((object) this).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {160, 67, 109, 99, 103, 109, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object setTypedValue(object @object)
    {
      Structure.StructField field = this.findField(Object.instancehelper_getClass(@object));
      if (field != null)
      {
        this.activeField = field;
        this.setFieldValue(field.field, @object);
        return (object) this;
      }
      string str = new StringBuilder().append("No field of type ").append((object) Object.instancehelper_getClass(@object)).append(" in ").append((object) this).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {160, 94, 110, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void writeField(Structure.StructField field)
    {
      if (!object.ReferenceEquals((object) field, (object) this.activeField))
        return;
      base.writeField(field);
    }

    [LineNumberTable(new byte[] {160, 105, 121, 114, 114, 103, 232, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override object readField(Structure.StructField field) => object.ReferenceEquals((object) field, (object) this.activeField) || !((Class) ClassLiteral<Structure>.Value).isAssignableFrom(field.type) && !((Class) ClassLiteral<String>.Value).isAssignableFrom(field.type) && !((Class) ClassLiteral<WString>.Value).isAssignableFrom(field.type) ? base.readField(field) : (object) null;

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;Z)I")]
    [LineNumberTable(235)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override int getNativeAlignment(
      Class type,
      object value,
      bool isFirstElement)
    {
      return base.getNativeAlignment(type, value, true);
    }

    [HideFromJava]
    static Union() => Structure.__\u003Cclinit\u003E();
  }
}
