// Decompiled with JetBrains decompiler
// Type: com.sun.jna.DefaultTypeMapper
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  public class DefaultTypeMapper : Object, TypeMapper
  {
    [Signature("Ljava/util/List<Lcom/sun/jna/DefaultTypeMapper$Entry;>;")]
    private List toNativeConverters;
    [Signature("Ljava/util/List<Lcom/sun/jna/DefaultTypeMapper$Entry;>;")]
    private List fromNativeConverters;

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {9, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 102, 109, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Class getAltClass([In] Class obj0)
    {
      if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Boolean>.Value))
        return (Class) Boolean.TYPE;
      if (object.ReferenceEquals((object) obj0, (object) Boolean.TYPE))
        return (Class) ClassLiteral<Boolean>.Value;
      if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Byte>.Value))
        return (Class) Byte.TYPE;
      if (object.ReferenceEquals((object) obj0, (object) Byte.TYPE))
        return (Class) ClassLiteral<Byte>.Value;
      if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Character>.Value))
        return (Class) Character.TYPE;
      if (object.ReferenceEquals((object) obj0, (object) Character.TYPE))
        return (Class) ClassLiteral<Character>.Value;
      if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Short>.Value))
        return (Class) Short.TYPE;
      if (object.ReferenceEquals((object) obj0, (object) Short.TYPE))
        return (Class) ClassLiteral<Short>.Value;
      if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Integer>.Value))
        return (Class) Integer.TYPE;
      if (object.ReferenceEquals((object) obj0, (object) Integer.TYPE))
        return (Class) ClassLiteral<Integer>.Value;
      if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Long>.Value))
        return (Class) Long.TYPE;
      if (object.ReferenceEquals((object) obj0, (object) Long.TYPE))
        return (Class) ClassLiteral<Long>.Value;
      if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Float>.Value))
        return (Class) Float.TYPE;
      if (object.ReferenceEquals((object) obj0, (object) Float.TYPE))
        return (Class) ClassLiteral<Float>.Value;
      if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<Double>.Value))
        return (Class) Double.TYPE;
      return object.ReferenceEquals((object) obj0, (object) Double.TYPE) ? (Class) ClassLiteral<Double>.Value : (Class) null;
    }

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/FromNativeConverter;)V")]
    [LineNumberTable(new byte[] {67, 115, 104, 99, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addFromNativeConverter(Class cls, FromNativeConverter converter)
    {
      this.fromNativeConverters.add((object) new DefaultTypeMapper.Entry(cls, (object) converter));
      Class altClass = this.getAltClass(cls);
      if (altClass == null)
        return;
      this.fromNativeConverters.add((object) new DefaultTypeMapper.Entry(altClass, (object) converter));
    }

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/ToNativeConverter;)V")]
    [LineNumberTable(new byte[] {52, 115, 104, 99, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addToNativeConverter(Class cls, ToNativeConverter converter)
    {
      this.toNativeConverters.add((object) new DefaultTypeMapper.Entry(cls, (object) converter));
      Class altClass = this.getAltClass(cls);
      if (altClass == null)
        return;
      this.toNativeConverters.add((object) new DefaultTypeMapper.Entry(altClass, (object) converter));
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/util/Collection<+Lcom/sun/jna/DefaultTypeMapper$Entry;>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {88, 123, 110, 135, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object lookupConverter([In] Class obj0, [In] Collection obj1)
    {
      Iterator iterator = obj1.iterator();
      while (iterator.hasNext())
      {
        DefaultTypeMapper.Entry entry = (DefaultTypeMapper.Entry) iterator.next();
        if (entry.type.isAssignableFrom(obj0))
          return entry.converter;
      }
      return (object) null;
    }

    [LineNumberTable(new byte[] {159, 187, 232, 74, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DefaultTypeMapper()
    {
      DefaultTypeMapper defaultTypeMapper = this;
      this.toNativeConverters = (List) new ArrayList();
      this.fromNativeConverters = (List) new ArrayList();
    }

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/TypeConverter;)V")]
    [LineNumberTable(new byte[] {83, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addTypeConverter(Class cls, TypeConverter converter)
    {
      this.addFromNativeConverter(cls, (FromNativeConverter) converter);
      this.addToNativeConverter(cls, (ToNativeConverter) converter);
    }

    [Signature("(Ljava/lang/Class<*>;)Lcom/sun/jna/FromNativeConverter;")]
    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FromNativeConverter getFromNativeConverter(Class javaType) => (FromNativeConverter) this.lookupConverter(javaType, (Collection) this.fromNativeConverters);

    [Signature("(Ljava/lang/Class<*>;)Lcom/sun/jna/ToNativeConverter;")]
    [LineNumberTable(153)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ToNativeConverter getToNativeConverter(Class javaType) => (ToNativeConverter) this.lookupConverter(javaType, (Collection) this.toNativeConverters);

    [InnerClass]
    internal class Entry : Object
    {
      [Signature("Ljava/lang/Class<*>;")]
      public Class type;
      public object converter;

      [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;)V")]
      [LineNumberTable(new byte[] {159, 191, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Entry([In] Class obj0, [In] object obj1)
      {
        DefaultTypeMapper.Entry entry = this;
        this.type = obj0;
        this.converter = obj1;
      }
    }
  }
}
