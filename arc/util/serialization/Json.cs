// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.Json
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.lang.reflect;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util.serialization
{
  public class Json : Object
  {
    private const bool debug = false;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class;Larc/struct/OrderedMap<Ljava/lang/String;Larc/util/serialization/Json$FieldMetadata;>;>;")]
    private ObjectMap typeToFields;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/Class;>;")]
    private ObjectMap tagToClass;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class;Ljava/lang/String;>;")]
    private ObjectMap classToTag;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class;Larc/util/serialization/Json$Serializer;>;")]
    private ObjectMap classToSerializer;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class;[Ljava/lang/Object;>;")]
    private ObjectMap classToDefaultValues;
    [Modifiers]
    private object[] equals1;
    [Modifiers]
    private object[] equals2;
    private BaseJsonWriter writer;
    private string typeName;
    private bool usePrototypes;
    private JsonWriter.OutputType outputType;
    private bool quoteLongValues;
    private bool ignoreUnknownFields;
    private bool ignoreDeprecated;
    private bool readDeprecated;
    private bool enumNames;
    private Json.Serializer defaultSerializer;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [LineNumberTable(new byte[] {161, 58, 191, 0, 2, 97, 140, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeValue(string name, object value, Class knownType)
    {
      IOException ioException1;
      try
      {
        this.writer.name(name);
        goto label_3;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
label_3:
      this.writeValue(value, knownType, (Class) null);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/util/serialization/JsonValue;)TT;")]
    [LineNumberTable(980)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readValue(Class type, JsonValue jsonData) => this.readValue(type, (Class) null, jsonData);

    [LineNumberTable(new byte[] {161, 39, 191, 0, 2, 97, 140, 99, 139, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeValue(string name, object value)
    {
      IOException ioException1;
      try
      {
        this.writer.name(name);
        goto label_3;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
label_3:
      if (value == null)
        this.writeValue(value, (Class) null, (Class) null);
      else
        this.writeValue(value, Object.instancehelper_getClass(value), (Class) null);
    }

    [Signature("(Ljava/lang/Class;)Larc/struct/OrderedMap<Ljava/lang/String;Larc/util/serialization/Json$FieldMetadata;>;")]
    [LineNumberTable(new byte[] {107, 114, 133, 102, 98, 109, 103, 137, 102, 111, 62, 168, 141, 127, 3, 112, 112, 187, 137, 189, 2, 97, 197, 127, 4, 137, 113, 101, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual OrderedMap getFields(Class type)
    {
      OrderedMap orderedMap1 = (OrderedMap) this.typeToFields.get((object) type);
      if (orderedMap1 != null)
        return orderedMap1;
      Seq seq1 = new Seq();
      for (Class @class = type; !object.ReferenceEquals((object) @class, (object) ClassLiteral<Object>.Value); @class = @class.getSuperclass())
        seq1.add((object) @class);
      Seq seq2 = new Seq();
      for (int index = seq1.size - 1; index >= 0; index += -1)
        seq2.addAll((object[]) ((Class) seq1.get(index)).getDeclaredFields(Json.__\u003CGetCallerID\u003E()));
      OrderedMap orderedMap2 = new OrderedMap(seq2.size);
      Iterator iterator = seq2.iterator();
      while (iterator.hasNext())
      {
        Field field = (Field) iterator.next();
        if (!Modifier.isTransient(field.getModifiers()) && !Modifier.isStatic(field.getModifiers()) && (!field.isSynthetic() && !type.isEnum()) && !Reflect.isWrapper(type))
        {
          if (!((AccessibleObject) field).isAccessible())
          {
            try
            {
              ((AccessibleObject) field).setAccessible(true);
              goto label_16;
            }
            catch (Exception ex)
            {
              if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
                throw;
            }
            continue;
          }
label_16:
          if (!this.ignoreDeprecated || this.readDeprecated || !((AccessibleObject) field).isAnnotationPresent((Class) ClassLiteral<Deprecated>.Value))
          {
            Json.FieldMetadata fieldMetadata = new Json.FieldMetadata(field);
            orderedMap2.put((object) field.getName(), (object) fieldMetadata);
          }
        }
      }
      this.typeToFields.put((object) type, (object) orderedMap2);
      return orderedMap2;
    }

    [LineNumberTable(new byte[] {160, 100, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toJson(object @object, Class knownType, Class elementType)
    {
      StringWriter stringWriter = new StringWriter();
      this.toJson(@object, knownType, elementType, (Writer) stringWriter);
      return stringWriter.toString();
    }

    [LineNumberTable(new byte[] {160, 144, 141, 141, 107, 103, 3, 130, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toJson(object @object, Class knownType, Class elementType, Writer writer)
    {
      this.setWriter((BaseJsonWriter) new JsonWriter(writer));
      try
      {
        this.writeValue(@object, knownType, elementType);
      }
      finally
      {
        Streams.close((Closeable) this.writer);
        this.writer = (BaseJsonWriter) null;
      }
    }

    [LineNumberTable(new byte[] {160, 119, 130, 110, 220, 102, 38, 102, 228, 60, 97, 159, 8, 102, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toJson(object @object, Class knownType, Class elementType, Fi file)
    {
      Writer writer = (Writer) null;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        writer = file.writer(false, "UTF-8");
        this.toJson(@object, knownType, elementType, writer);
        goto label_7;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      __fault
      {
        Streams.close((Closeable) writer);
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string message = new StringBuilder().append("Error writing file: ").append((object) file).toString();
        Exception exception4 = exception3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message, (Exception) exception4);
      }
      __fault
      {
        Streams.close((Closeable) writer);
      }
label_7:
      Streams.close((Closeable) writer);
    }

    [LineNumberTable(new byte[] {160, 160, 103, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWriter(BaseJsonWriter writer)
    {
      this.writer = writer;
      this.writer.setOutputType(this.outputType);
      this.writer.setQuoteLongValues(this.quoteLongValues);
    }

    [LineNumberTable(new byte[] {161, 109, 107, 200, 99, 109, 165, 191, 103, 109, 165, 159, 2, 191, 103, 104, 108, 102, 165, 104, 104, 108, 102, 165, 114, 99, 105, 197, 107, 121, 159, 22, 102, 103, 111, 47, 134, 102, 133, 104, 106, 104, 113, 102, 127, 0, 108, 102, 102, 133, 104, 106, 104, 113, 102, 118, 122, 102, 102, 133, 107, 121, 159, 22, 102, 104, 112, 48, 134, 102, 133, 107, 127, 5, 104, 107, 127, 0, 108, 102, 136, 102, 127, 0, 108, 134, 133, 104, 107, 104, 102, 103, 47, 134, 102, 197, 107, 106, 104, 127, 10, 121, 111, 98, 102, 165, 107, 106, 104, 127, 10, 121, 120, 98, 102, 133, 107, 106, 104, 104, 112, 123, 17, 198, 102, 133, 107, 106, 104, 127, 10, 121, 111, 98, 102, 197, 112, 148, 143, 104, 113, 120, 136, 152, 162, 104, 103, 191, 11, 2, 98, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeValue(object value, Class knownType, Class elementType)
    {
      if (knownType != null)
      {
        if (knownType.isAnonymousClass())
          knownType = knownType.getSuperclass();
      }
      IOException ioException1;
      try
      {
        if (value == null)
        {
          this.writer.value((object) null);
          return;
        }
        if (knownType != null && knownType.isPrimitive() || (object.ReferenceEquals((object) knownType, (object) ClassLiteral<String>.Value) || object.ReferenceEquals((object) knownType, (object) ClassLiteral<Integer>.Value)) || (object.ReferenceEquals((object) knownType, (object) ClassLiteral<Boolean>.Value) || object.ReferenceEquals((object) knownType, (object) ClassLiteral<Float>.Value) || (object.ReferenceEquals((object) knownType, (object) ClassLiteral<Long>.Value) || object.ReferenceEquals((object) knownType, (object) ClassLiteral<Double>.Value))) || (object.ReferenceEquals((object) knownType, (object) ClassLiteral<Short>.Value) || object.ReferenceEquals((object) knownType, (object) ClassLiteral<Byte>.Value) || object.ReferenceEquals((object) knownType, (object) ClassLiteral<Character>.Value)))
        {
          this.writer.value(value);
          return;
        }
        Class actualType = !Object.instancehelper_getClass(value).isAnonymousClass() ? Object.instancehelper_getClass(value) : Object.instancehelper_getClass(value).getSuperclass();
        if (actualType.isPrimitive() || object.ReferenceEquals((object) actualType, (object) ClassLiteral<String>.Value) || (object.ReferenceEquals((object) actualType, (object) ClassLiteral<Integer>.Value) || object.ReferenceEquals((object) actualType, (object) ClassLiteral<Boolean>.Value)) || (object.ReferenceEquals((object) actualType, (object) ClassLiteral<Float>.Value) || object.ReferenceEquals((object) actualType, (object) ClassLiteral<Long>.Value) || (object.ReferenceEquals((object) actualType, (object) ClassLiteral<Double>.Value) || object.ReferenceEquals((object) actualType, (object) ClassLiteral<Short>.Value))) || (object.ReferenceEquals((object) actualType, (object) ClassLiteral<Byte>.Value) || object.ReferenceEquals((object) actualType, (object) ClassLiteral<Character>.Value)))
        {
          this.writeObjectStart(actualType, (Class) null);
          this.writeValue(nameof (value), value);
          this.writeObjectEnd();
          return;
        }
        if (value is Json.JsonSerializable)
        {
          this.writeObjectStart(actualType, knownType);
          ((Json.JsonSerializable) value).write(this);
          this.writeObjectEnd();
          return;
        }
        Json.Serializer serializer = (Json.Serializer) this.classToSerializer.get((object) actualType);
        if (serializer != null)
        {
          serializer.write(this, value, knownType);
          return;
        }
        switch (value)
        {
          case Seq _:
            if (knownType != null && !object.ReferenceEquals((object) actualType, (object) knownType) && !object.ReferenceEquals((object) actualType, (object) ClassLiteral<Seq>.Value))
            {
              string message = new StringBuilder().append("Serialization of an Array other than the known type is not supported.\nKnown type: ").append((object) knownType).append("\nActual type: ").append((object) actualType).toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new SerializationException(message);
            }
            this.writeArrayStart();
            Seq seq = (Seq) value;
            int index1 = 0;
            for (int size = seq.size; index1 < size; ++index1)
              this.writeValue(seq.get(index1), elementType, (Class) null);
            this.writeArrayEnd();
            return;
          case ObjectSet _:
            if (knownType == null)
              knownType = (Class) ClassLiteral<ObjectSet>.Value;
            this.writeObjectStart(actualType, knownType);
            this.writer.name("values");
            this.writeArrayStart();
            ObjectSet.ObjectSetIterator objectSetIterator = ((ObjectSet) value).iterator();
            while (((Iterator) objectSetIterator).hasNext())
              this.writeValue(((Iterator) objectSetIterator).next(), elementType, (Class) null);
            this.writeArrayEnd();
            this.writeObjectEnd();
            return;
          case IntSet _:
            if (knownType == null)
              knownType = (Class) ClassLiteral<IntSet>.Value;
            this.writeObjectStart(actualType, knownType);
            this.writer.name("values");
            this.writeArrayStart();
            IntSet.IntSetIterator intSetIterator = ((IntSet) value).iterator();
            while (intSetIterator.hasNext)
              this.writeValue((object) Integer.valueOf(intSetIterator.next()), (Class) ClassLiteral<Integer>.Value, (Class) null);
            this.writeArrayEnd();
            this.writeObjectEnd();
            return;
          case Queue _:
            if (knownType != null && !object.ReferenceEquals((object) actualType, (object) knownType) && !object.ReferenceEquals((object) actualType, (object) ClassLiteral<Queue>.Value))
            {
              string message = new StringBuilder().append("Serialization of a Queue other than the known type is not supported.\nKnown type: ").append((object) knownType).append("\nActual type: ").append((object) actualType).toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new SerializationException(message);
            }
            this.writeArrayStart();
            Queue queue = (Queue) value;
            int index2 = 0;
            for (int size = queue.size; index2 < size; ++index2)
              this.writeValue(queue.get(index2), elementType, (Class) null);
            this.writeArrayEnd();
            return;
          case Collection _:
            if (this.typeName != null && !object.ReferenceEquals((object) actualType, (object) ClassLiteral<ArrayList>.Value) && (knownType == null || !object.ReferenceEquals((object) knownType, (object) actualType)))
            {
              this.writeObjectStart(actualType, knownType);
              this.writeArrayStart("items");
              Iterator iterator = ((Collection) value).iterator();
              while (iterator.hasNext())
                this.writeValue(iterator.next(), elementType, (Class) null);
              this.writeArrayEnd();
              this.writeObjectEnd();
              return;
            }
            this.writeArrayStart();
            Iterator iterator1 = ((Collection) value).iterator();
            while (iterator1.hasNext())
              this.writeValue(iterator1.next(), elementType, (Class) null);
            this.writeArrayEnd();
            return;
          default:
            if (actualType.isArray())
            {
              if (elementType == null)
                elementType = actualType.getComponentType();
              int length = Array.getLength(value);
              this.writeArrayStart();
              for (int index3 = 0; index3 < length; ++index3)
                this.writeValue(Array.get(value, index3), elementType, (Class) null);
              this.writeArrayEnd();
              return;
            }
            switch (value)
            {
              case ObjectMap _:
                if (knownType == null)
                  knownType = (Class) ClassLiteral<ObjectMap>.Value;
                this.writeObjectStart(actualType, knownType);
                ObjectMap.Entries entries1 = ((ObjectMap) value).entries().iterator();
                while (((Iterator) entries1).hasNext())
                {
                  ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries1).next();
                  this.writer.name(this.convertToString(entry.key));
                  this.writeValue(entry.value, elementType, (Class) null);
                }
                this.writeObjectEnd();
                return;
              case ObjectIntMap _:
                if (knownType == null)
                  knownType = (Class) ClassLiteral<ObjectIntMap>.Value;
                this.writeObjectStart(actualType, knownType);
                ObjectIntMap.Entries entries2 = ((ObjectIntMap) value).entries().iterator();
                while (((Iterator) entries2).hasNext())
                {
                  ObjectIntMap.Entry entry = (ObjectIntMap.Entry) ((Iterator) entries2).next();
                  this.writer.name(this.convertToString(entry.key));
                  this.writer.value((object) Integer.valueOf(entry.value));
                }
                this.writeObjectEnd();
                return;
              case ArrayMap _:
                if (knownType == null)
                  knownType = (Class) ClassLiteral<ArrayMap>.Value;
                this.writeObjectStart(actualType, knownType);
                ArrayMap arrayMap = (ArrayMap) value;
                int index4 = 0;
                for (int size = arrayMap.size; index4 < size; ++index4)
                {
                  this.writer.name(this.convertToString(arrayMap.keys[index4]));
                  this.writeValue(arrayMap.values[index4], elementType, (Class) null);
                }
                this.writeObjectEnd();
                return;
              case Map _:
                if (knownType == null)
                  knownType = (Class) ClassLiteral<HashMap>.Value;
                this.writeObjectStart(actualType, knownType);
                Iterator iterator2 = ((Map) value).entrySet().iterator();
                while (iterator2.hasNext())
                {
                  Map.Entry entry = (Map.Entry) iterator2.next();
                  this.writer.name(this.convertToString(entry.getKey()));
                  this.writeValue(entry.getValue(), elementType, (Class) null);
                }
                this.writeObjectEnd();
                return;
              default:
                if (((Class) ClassLiteral<Enum>.Value).isAssignableFrom(actualType))
                {
                  if (this.typeName != null && (knownType == null || !object.ReferenceEquals((object) knownType, (object) actualType)))
                  {
                    if (actualType.getEnumConstants() == null)
                      actualType = actualType.getSuperclass();
                    this.writeObjectStart(actualType, (Class) null);
                    this.writer.name(nameof (value));
                    this.writer.value((object) this.convertToString((Enum) value));
                    this.writeObjectEnd();
                    return;
                  }
                  this.writer.value((object) this.convertToString((Enum) value));
                  return;
                }
                this.writeObjectStart(actualType, knownType);
                this.writeFields(value);
                this.writeObjectEnd();
                return;
            }
        }
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {160, 208, 106, 191, 1, 221, 226, 61, 97, 110, 162, 104, 108, 142, 98, 127, 8, 105, 159, 1, 255, 45, 74, 229, 55, 98, 127, 45, 98, 127, 24, 104, 98, 105, 127, 24, 136, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object[] getDefaultValues([In] Class obj0)
    {
      if (!this.usePrototypes)
        return (object[]) null;
      if (this.classToDefaultValues.containsKey((object) obj0))
        return (object[]) this.classToDefaultValues.get((object) obj0);
      object obj1;
      try
      {
        obj1 = this.newInstance(obj0);
        goto label_8;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      this.classToDefaultValues.put((object) obj0, (object) null);
      return (object[]) null;
label_8:
      OrderedMap fields = this.getFields(obj0);
      object[] objArray1 = new object[fields.size];
      this.classToDefaultValues.put((object) obj0, (object) objArray1);
      int num = 0;
      ObjectMap.Values values = fields.values().iterator();
      while (((Iterator) values).hasNext())
      {
        Field field = ((Json.FieldMetadata) ((Iterator) values).next()).__\u003C\u003Efield;
        if (this.readDeprecated)
        {
          if (this.ignoreDeprecated)
          {
            if (((AccessibleObject) field).isAnnotationPresent((Class) ClassLiteral<Deprecated>.Value))
              continue;
          }
        }
        IllegalAccessException illegalAccessException1;
        SerializationException serializationException1;
        RuntimeException runtimeException;
        try
        {
          try
          {
            try
            {
              object[] objArray2 = objArray1;
              int index = num;
              ++num;
              object obj2 = field.get(obj1, Json.__\u003CGetCallerID\u003E());
              objArray2[index] = obj2;
              continue;
            }
            catch (IllegalAccessException ex)
            {
              illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
          }
          catch (SerializationException ex)
          {
            serializationException1 = (SerializationException) ByteCodeHelper.MapException<SerializationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_20;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException = (RuntimeException) m0;
            goto label_21;
          }
        }
        IllegalAccessException illegalAccessException2 = illegalAccessException1;
        string message = new StringBuilder().append("Error accessing field: ").append(field.getName()).append(" (").append(obj0.getName()).append(")").toString();
        IllegalAccessException illegalAccessException3 = illegalAccessException2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message, (Exception) illegalAccessException3);
label_20:
        SerializationException serializationException2 = serializationException1;
        serializationException2.addTrace(new StringBuilder().append((object) field).append(" (").append(obj0.getName()).append(")").toString());
        throw Throwable.__\u003Cunmap\u003E((Exception) serializationException2);
label_21:
        SerializationException serializationException3 = new SerializationException((Exception) runtimeException);
        serializationException3.addTrace(new StringBuilder().append((object) field).append(" (").append(obj0.getName()).append(")").toString());
        throw Throwable.__\u003Cunmap\u003E((Exception) serializationException3);
      }
      return objArray1;
    }

    [LineNumberTable(new byte[] {164, 89, 127, 29, 161, 114, 103, 127, 31, 225, 78, 229, 51, 97, 109, 112, 137, 104, 127, 12, 117, 159, 12, 127, 12, 98, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual object newInstance(Class type)
    {
      object obj1;
      Exception exception1;
      try
      {
        obj1 = type.getDeclaredConstructor(new Class[0], Json.__\u003CGetCallerID\u003E()).newInstance(new object[0], Json.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj1;
label_5:
      Exception exception2 = exception1;
      object obj2;
      Exception exception3;
      try
      {
        try
        {
          try
          {
            Constructor declaredConstructor = type.getDeclaredConstructor(new Class[0], Json.__\u003CGetCallerID\u003E());
            ((AccessibleObject) declaredConstructor).setAccessible(true);
            obj2 = declaredConstructor.newInstance(new object[0], Json.__\u003CGetCallerID\u003E());
          }
          catch (SecurityException ex)
          {
            goto label_13;
          }
        }
        catch (IllegalAccessException ex)
        {
          goto label_14;
        }
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception3 = (Exception) m0;
          goto label_15;
        }
      }
      return obj2;
label_13:
      goto label_24;
label_14:
      if (((Class) ClassLiteral<Enum>.Value).isAssignableFrom(type))
      {
        if (type.getEnumConstants() == null)
          type = type.getSuperclass();
        return type.getEnumConstants()[0];
      }
      if (type.isArray())
      {
        string message = new StringBuilder().append("Encountered JSON object when expected array of type: ").append(type.getName()).toString();
        Exception exception4 = exception2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message, (Exception) exception4);
      }
      if (type.isMemberClass() && !Modifier.isStatic(type.getModifiers()))
      {
        string message = new StringBuilder().append("Class cannot be created (non-static member class): ").append(type.getName()).toString();
        Exception exception4 = exception2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message, (Exception) exception4);
      }
      string message1 = new StringBuilder().append("Class cannot be created (missing no-arg constructor): ").append(type.getName()).toString();
      Exception exception5 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException(message1, (Exception) exception5);
label_15:
      exception2 = exception3;
label_24:
      string message2 = new StringBuilder().append("Error constructing instance of class: ").append(type.getName()).toString();
      Exception exception6 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException(message2, (Exception) exception6);
    }

    [LineNumberTable(new byte[] {159, 48, 163, 103, 104, 109, 99, 127, 37, 103, 172, 109, 255, 51, 74, 229, 55, 98, 127, 44, 98, 127, 23, 104, 98, 105, 127, 23, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeField(
      object @object,
      string fieldName,
      string jsonName,
      Class elementType)
    {
      ref Class local = ref elementType;
      Class type = Object.instancehelper_getClass(@object);
      Json.FieldMetadata fieldMetadata = (Json.FieldMetadata) this.getFields(type).get((object) fieldName);
      if (fieldMetadata == null)
      {
        string message = new StringBuilder().append("Field not found: ").append(fieldName).append(" (").append(type.getName()).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message);
      }
      Field field = fieldMetadata.__\u003C\u003Efield;
      if (elementType == null)
        elementType = fieldMetadata.elementType;
      IllegalAccessException illegalAccessException1;
      SerializationException serializationException1;
      Exception exception;
      try
      {
        try
        {
          try
          {
            this.writer.name(jsonName);
            this.writeValue(field.get(@object, Json.__\u003CGetCallerID\u003E()), field.getType(), elementType);
            return;
          }
          catch (IllegalAccessException ex)
          {
            illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
        }
        catch (SerializationException ex)
        {
          serializationException1 = (SerializationException) ByteCodeHelper.MapException<SerializationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_11;
        }
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception = (Exception) m0;
          goto label_12;
        }
      }
      IllegalAccessException illegalAccessException2 = illegalAccessException1;
      string message1 = new StringBuilder().append("Error accessing field: ").append(field.getName()).append(" (").append(type.getName()).append(")").toString();
      IllegalAccessException illegalAccessException3 = illegalAccessException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException(message1, (Exception) illegalAccessException3);
label_11:
      SerializationException serializationException2 = serializationException1;
      serializationException2.addTrace(new StringBuilder().append((object) field).append(" (").append(type.getName()).append(")").toString());
      throw Throwable.__\u003Cunmap\u003E((Exception) serializationException2);
label_12:
      SerializationException serializationException3 = new SerializationException((Exception) exception);
      serializationException3.addTrace(new StringBuilder().append((object) field).append(" (").append(type.getName()).append(")").toString());
      throw Throwable.__\u003Cunmap\u003E((Exception) serializationException3);
    }

    [LineNumberTable(new byte[] {162, 66, 190, 2, 97, 140, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeObjectStart(Class actualType, Class knownType)
    {
      IOException ioException1;
      try
      {
        this.writer.@object();
        goto label_4;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
label_4:
      if (knownType != null && object.ReferenceEquals((object) knownType, (object) actualType))
        return;
      this.writeType(actualType);
    }

    [LineNumberTable(new byte[] {162, 75, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeObjectEnd()
    {
      IOException ioException1;
      try
      {
        this.writer.pop();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {162, 92, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeArrayStart()
    {
      IOException ioException1;
      try
      {
        this.writer.array();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {162, 100, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeArrayEnd()
    {
      IOException ioException1;
      try
      {
        this.writer.pop();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {162, 83, 109, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeArrayStart(string name)
    {
      IOException ioException1;
      try
      {
        this.writer.name(name);
        this.writer.array();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {164, 82, 117, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string convertToString(object @object)
    {
      switch (@object)
      {
        case Enum _:
          return this.convertToString((Enum) @object);
        case Class _:
          return ((Class) @object).getName();
        default:
          return String.valueOf(@object);
      }
    }

    [LineNumberTable(1216)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string convertToString([In] Enum obj0) => this.enumNames ? obj0.name() : obj0.toString();

    [LineNumberTable(new byte[] {160, 167, 135, 136, 104, 98, 127, 8, 105, 159, 1, 111, 99, 105, 127, 55, 104, 127, 58, 124, 106, 106, 255, 59, 70, 115, 255, 47, 74, 229, 55, 98, 127, 45, 98, 127, 24, 104, 98, 105, 127, 24, 136, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeFields(object @object)
    {
      Class type = Object.instancehelper_getClass(@object);
      object[] defaultValues = this.getDefaultValues(type);
      OrderedMap fields = this.getFields(type);
      int num = 0;
      ObjectMap.Values values = new OrderedMap.OrderedMapValues(fields).iterator();
      while (((Iterator) values).hasNext())
      {
        Json.FieldMetadata fieldMetadata = (Json.FieldMetadata) ((Iterator) values).next();
        Field field = fieldMetadata.__\u003C\u003Efield;
        if (this.readDeprecated)
        {
          if (this.ignoreDeprecated)
          {
            if (((AccessibleObject) field).isAnnotationPresent((Class) ClassLiteral<Deprecated>.Value))
              continue;
          }
        }
        object obj1;
        object obj2;
        IllegalAccessException illegalAccessException1;
        SerializationException serializationException1;
        Exception exception1;
        try
        {
          try
          {
            try
            {
              obj1 = field.get(@object, Json.__\u003CGetCallerID\u003E());
              if (defaultValues != null)
              {
                object[] objArray = defaultValues;
                int index = num;
                ++num;
                obj2 = objArray[index];
                if (obj1 == null)
                {
                  if (obj2 != null)
                    goto label_16;
                  else
                    continue;
                }
                else
                  goto label_16;
              }
              else
                goto label_38;
            }
            catch (IllegalAccessException ex)
            {
              illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
          }
          catch (SerializationException ex)
          {
            serializationException1 = (SerializationException) ByteCodeHelper.MapException<SerializationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_14;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            exception1 = (Exception) m0;
            goto label_15;
          }
        }
        IllegalAccessException illegalAccessException2 = illegalAccessException1;
        goto label_47;
label_14:
        SerializationException serializationException2 = serializationException1;
        goto label_48;
label_15:
        Exception exception2 = exception1;
        goto label_49;
label_16:
        IllegalAccessException illegalAccessException3;
        SerializationException serializationException3;
        Exception exception3;
        try
        {
          try
          {
            try
            {
              if (obj1 != null)
              {
                if (obj2 != null)
                {
                  if (!Object.instancehelper_equals(obj1, obj2))
                    goto label_27;
                  else
                    continue;
                }
                else
                  goto label_38;
              }
              else
                goto label_38;
            }
            catch (IllegalAccessException ex)
            {
              illegalAccessException3 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
          }
          catch (SerializationException ex)
          {
            serializationException3 = (SerializationException) ByteCodeHelper.MapException<SerializationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_25;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            exception3 = (Exception) m0;
            goto label_26;
          }
        }
        illegalAccessException2 = illegalAccessException3;
        goto label_47;
label_25:
        serializationException2 = serializationException3;
        goto label_48;
label_26:
        exception2 = exception3;
        goto label_49;
label_27:
        IllegalAccessException illegalAccessException4;
        SerializationException serializationException4;
        Exception exception4;
        try
        {
          try
          {
            try
            {
              if (Object.instancehelper_getClass(obj1).isArray())
              {
                if (Object.instancehelper_getClass(obj2).isArray())
                {
                  this.equals1[0] = obj1;
                  this.equals2[0] = obj2;
                  if (!Arrays.deepEquals(this.equals1, this.equals2))
                    goto label_38;
                  else
                    continue;
                }
                else
                  goto label_38;
              }
              else
                goto label_38;
            }
            catch (IllegalAccessException ex)
            {
              illegalAccessException4 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
          }
          catch (SerializationException ex)
          {
            serializationException4 = (SerializationException) ByteCodeHelper.MapException<SerializationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_36;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            exception4 = (Exception) m0;
            goto label_37;
          }
        }
        illegalAccessException2 = illegalAccessException4;
        goto label_47;
label_36:
        serializationException2 = serializationException4;
        goto label_48;
label_37:
        exception2 = exception4;
        goto label_49;
label_38:
        IllegalAccessException illegalAccessException5;
        SerializationException serializationException5;
        Exception exception5;
        try
        {
          try
          {
            try
            {
              this.writer.name(field.getName());
              this.writeValue(obj1, field.getType(), fieldMetadata.elementType);
              continue;
            }
            catch (IllegalAccessException ex)
            {
              illegalAccessException5 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
          }
          catch (SerializationException ex)
          {
            serializationException5 = (SerializationException) ByteCodeHelper.MapException<SerializationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_45;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            exception5 = (Exception) m0;
            goto label_46;
          }
        }
        illegalAccessException2 = illegalAccessException5;
        goto label_47;
label_45:
        serializationException2 = serializationException5;
        goto label_48;
label_46:
        exception2 = exception5;
        goto label_49;
label_47:
        IllegalAccessException illegalAccessException6 = illegalAccessException2;
        string message = new StringBuilder().append("Error accessing field: ").append(field.getName()).append(" (").append(type.getName()).append(")").toString();
        IllegalAccessException illegalAccessException7 = illegalAccessException6;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message, (Exception) illegalAccessException7);
label_48:
        SerializationException serializationException6 = serializationException2;
        serializationException6.addTrace(new StringBuilder().append((object) field).append(" (").append(type.getName()).append(")").toString());
        throw Throwable.__\u003Cunmap\u003E((Exception) serializationException6);
label_49:
        SerializationException serializationException7 = new SerializationException((Exception) exception2);
        serializationException7.addTrace(new StringBuilder().append((object) field).append(" (").append(type.getName()).append(")").toString());
        throw Throwable.__\u003Cunmap\u003E((Exception) serializationException7);
      }
    }

    [LineNumberTable(new byte[] {162, 54, 190, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeObjectStart()
    {
      IOException ioException1;
      try
      {
        this.writer.@object();
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {162, 107, 105, 104, 138, 191, 6, 2, 97, 172})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeType(Class type)
    {
      if (this.typeName != null)
      {
        string str = this.getTag(type) ?? type.getName();
        IOException ioException1;
        try
        {
          this.writer.set(this.typeName, (object) str);
          return;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        IOException ioException2 = ioException1;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException((Exception) ioException2);
      }
    }

    [LineNumberTable(106)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getTag(Class type) => (string) this.classToTag.get((object) type);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;Larc/util/serialization/JsonValue;)TT;")]
    [LineNumberTable(984)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readValue(Class type, Class elementType, JsonValue jsonData) => this.readValue(type, elementType, jsonData, (Class) null);

    [LineNumberTable(new byte[] {162, 224, 103, 104, 109, 99, 127, 37, 103, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readField(
      object @object,
      string fieldName,
      string jsonName,
      Class elementType,
      JsonValue jsonMap)
    {
      Class type = Object.instancehelper_getClass(@object);
      Json.FieldMetadata fieldMetadata = (Json.FieldMetadata) this.getFields(type).get((object) fieldName);
      if (fieldMetadata == null)
      {
        string message = new StringBuilder().append("Field not found: ").append(fieldName).append(" (").append(type.getName()).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message);
      }
      Field field = fieldMetadata.__\u003C\u003Efield;
      if (elementType == null)
        elementType = fieldMetadata.elementType;
      this.readField(@object, field, jsonName, elementType, jsonMap);
    }

    [LineNumberTable(new byte[] {162, 239, 105, 132, 255, 46, 76, 229, 53, 98, 112, 127, 33, 98, 127, 33, 104, 98, 105, 109, 127, 33, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readField(
      object @object,
      Field field,
      string jsonName,
      Class elementType,
      JsonValue jsonMap)
    {
      JsonValue jsonData = jsonMap.get(jsonName);
      if (jsonData != null)
      {
        IllegalAccessException illegalAccessException1;
        SerializationException serializationException1;
        RuntimeException runtimeException;
        try
        {
          try
          {
            try
            {
              field.set(@object, this.readValue(field.getType(), elementType, jsonData), Json.__\u003CGetCallerID\u003E());
              return;
            }
            catch (IllegalAccessException ex)
            {
              illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            }
          }
          catch (SerializationException ex)
          {
            serializationException1 = (SerializationException) ByteCodeHelper.MapException<SerializationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_8;
          }
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
          {
            throw;
          }
          else
          {
            runtimeException = (RuntimeException) m0;
            goto label_9;
          }
        }
        IllegalAccessException illegalAccessException2 = illegalAccessException1;
        string message = new StringBuilder().append("Error accessing field: ").append(field.getName()).append(" (").append(field.getDeclaringClass().getName()).append(")").toString();
        IllegalAccessException illegalAccessException3 = illegalAccessException2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message, (Exception) illegalAccessException3);
label_8:
        SerializationException serializationException2 = serializationException1;
        serializationException2.addTrace(new StringBuilder().append(field.getName()).append(" (").append(field.getDeclaringClass().getName()).append(")").toString());
        throw Throwable.__\u003Cunmap\u003E((Exception) serializationException2);
label_9:
        SerializationException serializationException3 = new SerializationException((Exception) runtimeException);
        serializationException3.addTrace(jsonData.trace());
        serializationException3.addTrace(new StringBuilder().append(field.getName()).append(" (").append(field.getDeclaringClass().getName()).append(")").toString());
        throw Throwable.__\u003Cunmap\u003E((Exception) serializationException3);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual bool ignoreUnknownField(Class type, string fieldName) => false;

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;Larc/util/serialization/JsonValue;Ljava/lang/Class;)TT;")]
    [LineNumberTable(new byte[] {163, 111, 133, 107, 121, 99, 105, 131, 191, 0, 2, 97, 236, 69, 99, 119, 162, 149, 109, 127, 7, 159, 5, 114, 141, 159, 98, 103, 174, 137, 105, 110, 195, 105, 105, 140, 31, 21, 235, 69, 131, 105, 105, 108, 63, 15, 203, 131, 105, 105, 113, 50, 139, 131, 105, 105, 113, 47, 139, 131, 105, 105, 108, 57, 171, 131, 105, 105, 108, 116, 130, 249, 60, 235, 70, 163, 105, 195, 99, 115, 143, 141, 105, 110, 195, 139, 119, 109, 127, 3, 108, 49, 139, 131, 109, 127, 3, 108, 50, 139, 131, 109, 127, 3, 108, 49, 139, 131, 112, 125, 108, 63, 10, 139, 131, 104, 104, 103, 111, 99, 108, 57, 139, 131, 191, 37, 139, 127, 17, 127, 13, 127, 13, 127, 14, 122, 127, 10, 159, 47, 34, 129, 173, 136, 125, 159, 2, 34, 129, 173, 107, 103, 146, 127, 8, 127, 78, 127, 8, 127, 8, 127, 5, 159, 38, 34, 129, 127, 2, 127, 8, 109, 109, 110, 103, 19, 232, 69, 111, 191, 37})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readValue(
      Class type,
      Class elementType,
      JsonValue jsonData,
      Class keytype)
    {
      if (jsonData == null)
        return (object) null;
      if (jsonData.isObject())
      {
        string tag = this.typeName != null ? jsonData.getString(this.typeName, (string) null) : (string) null;
        if (tag != null)
        {
          type = this.getClass(tag);
          if (type == null)
          {
            Exception exception;
            try
            {
              type = Class.forName(tag, Json.__\u003CGetCallerID\u003E());
              goto label_8;
            }
            catch (Exception ex)
            {
              exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception cause = exception;
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new SerializationException(cause);
          }
        }
label_8:
        if (type == null)
          return this.defaultSerializer != null ? this.defaultSerializer.read(this, jsonData, type) : (object) jsonData;
        if (this.typeName != null && ((Class) ClassLiteral<Collection>.Value).isAssignableFrom(type))
        {
          jsonData = jsonData.get("items");
          if (jsonData == null)
          {
            string message = new StringBuilder().append("Unable to convert object to struct: ").append((object) jsonData).append(" (").append(type.getName()).append(")").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new SerializationException(message);
          }
        }
        else
        {
          Json.Serializer serializer = (Json.Serializer) this.classToSerializer.get((object) type);
          if (serializer != null)
            return serializer.read(this, jsonData, type);
          if (object.ReferenceEquals((object) type, (object) ClassLiteral<String>.Value) || object.ReferenceEquals((object) type, (object) ClassLiteral<Integer>.Value) || (object.ReferenceEquals((object) type, (object) ClassLiteral<Boolean>.Value) || object.ReferenceEquals((object) type, (object) ClassLiteral<Float>.Value)) || (object.ReferenceEquals((object) type, (object) ClassLiteral<Long>.Value) || object.ReferenceEquals((object) type, (object) ClassLiteral<Double>.Value) || (object.ReferenceEquals((object) type, (object) ClassLiteral<Short>.Value) || object.ReferenceEquals((object) type, (object) ClassLiteral<Byte>.Value))) || (object.ReferenceEquals((object) type, (object) ClassLiteral<Character>.Value) || ((Class) ClassLiteral<Enum>.Value).isAssignableFrom(type)))
            return this.readValue("value", type, jsonData);
          object @object = this.newInstance(type);
          switch (@object)
          {
            case Json.JsonSerializable _:
              ((Json.JsonSerializable) @object).read(this, jsonData);
              return @object;
            case ObjectMap _:
              ObjectMap objectMap = (ObjectMap) @object;
              for (JsonValue jsonData1 = jsonData.child; jsonData1 != null; jsonData1 = jsonData1.next)
                objectMap.put(keytype == null ? (object) jsonData1.name : this.readValue(keytype, (Class) null, new JsonValue(jsonData1.name)), this.readValue(elementType, (Class) null, jsonData1));
              return (object) objectMap;
            case ObjectIntMap _:
              ObjectIntMap objectIntMap = (ObjectIntMap) @object;
              for (JsonValue jsonValue = jsonData.child; jsonValue != null; jsonValue = jsonValue.next)
                objectIntMap.put(elementType == null ? (object) jsonValue.name : this.readValue(elementType, (Class) null, new JsonValue(jsonValue.name)), jsonValue.asInt());
              return (object) objectIntMap;
            case ObjectSet _:
              ObjectSet objectSet = (ObjectSet) @object;
              for (JsonValue jsonData1 = jsonData.getChild("values"); jsonData1 != null; jsonData1 = jsonData1.next)
                objectSet.add(this.readValue(elementType, (Class) null, jsonData1));
              return (object) objectSet;
            case IntSet _:
              IntSet intSet = (IntSet) @object;
              for (JsonValue jsonValue = jsonData.getChild("values"); jsonValue != null; jsonValue = jsonValue.next)
                intSet.add(jsonValue.asInt());
              return (object) intSet;
            case ArrayMap _:
              ArrayMap arrayMap = (ArrayMap) @object;
              for (JsonValue jsonData1 = jsonData.child; jsonData1 != null; jsonData1 = jsonData1.next)
                arrayMap.put((object) jsonData1.name, this.readValue(elementType, (Class) null, jsonData1));
              return (object) arrayMap;
            case Map _:
              Map map = (Map) @object;
              for (JsonValue jsonData1 = jsonData.child; jsonData1 != null; jsonData1 = jsonData1.next)
              {
                if (!String.instancehelper_equals(jsonData1.name, (object) this.typeName))
                  map.put((object) jsonData1.name, this.readValue(elementType, (Class) null, jsonData1));
              }
              return (object) map;
            default:
              this.readFields(@object, jsonData);
              return @object;
          }
        }
      }
      if (type != null)
      {
        Json.Serializer serializer = (Json.Serializer) this.classToSerializer.get((object) type);
        if (serializer != null)
          return serializer.read(this, jsonData, type);
        if (((Class) ClassLiteral<Json.JsonSerializable>.Value).isAssignableFrom(type))
        {
          object obj = this.newInstance(type);
          ((Json.JsonSerializable) obj).read(this, jsonData);
          return obj;
        }
      }
      if (jsonData.isArray())
      {
        if (type == null || object.ReferenceEquals((object) type, (object) ClassLiteral<Object>.Value))
          type = (Class) ClassLiteral<Seq>.Value;
        if (((Class) ClassLiteral<Seq>.Value).isAssignableFrom(type))
        {
          Seq seq = !object.ReferenceEquals((object) type, (object) ClassLiteral<Seq>.Value) ? (Seq) this.newInstance(type) : new Seq();
          for (JsonValue jsonData1 = jsonData.child; jsonData1 != null; jsonData1 = jsonData1.next)
            seq.add(this.readValue(elementType, (Class) null, jsonData1));
          return (object) seq;
        }
        if (((Class) ClassLiteral<ObjectSet>.Value).isAssignableFrom(type))
        {
          ObjectSet objectSet = !object.ReferenceEquals((object) type, (object) ClassLiteral<ObjectSet>.Value) ? (ObjectSet) this.newInstance(type) : new ObjectSet();
          for (JsonValue jsonData1 = jsonData.child; jsonData1 != null; jsonData1 = jsonData1.next)
            objectSet.add(this.readValue(elementType, (Class) null, jsonData1));
          return (object) objectSet;
        }
        if (((Class) ClassLiteral<Queue>.Value).isAssignableFrom(type))
        {
          Queue queue = !object.ReferenceEquals((object) type, (object) ClassLiteral<Queue>.Value) ? (Queue) this.newInstance(type) : new Queue();
          for (JsonValue jsonData1 = jsonData.child; jsonData1 != null; jsonData1 = jsonData1.next)
            queue.addLast(this.readValue(elementType, (Class) null, jsonData1));
          return (object) queue;
        }
        if (((Class) ClassLiteral<Collection>.Value).isAssignableFrom(type))
        {
          object obj1 = !type.isInterface() ? (object) (Collection) this.newInstance(type) : (object) (Collection) new ArrayList();
          for (JsonValue jsonData1 = jsonData.child; jsonData1 != null; jsonData1 = jsonData1.next)
          {
            object obj2 = obj1;
            object obj3 = this.readValue(elementType, (Class) null, jsonData1);
            Collection collection1;
            if (obj2 != null)
              collection1 = obj2 is Collection collection8 ? collection8 : throw new IncompatibleClassChangeError();
            else
              collection1 = (Collection) null;
            object obj4 = obj3;
            collection1.add(obj4);
          }
          return obj1;
        }
        if (type.isArray())
        {
          Class componentType = type.getComponentType();
          if (elementType == null)
            elementType = componentType;
          object obj1 = Array.newInstance(componentType, jsonData.size);
          int num1 = 0;
          for (JsonValue jsonData1 = jsonData.child; jsonData1 != null; jsonData1 = jsonData1.next)
          {
            object obj2 = obj1;
            int num2 = num1;
            ++num1;
            object obj3 = this.readValue(elementType, (Class) null, jsonData1);
            Array.set(obj2, num2, obj3);
          }
          return obj1;
        }
        string message = new StringBuilder().append("Unable to convert value to required type: ").append((object) jsonData).append(" (").append(type.getName()).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message);
      }
      if (jsonData.isNumber())
      {
        Byte @byte;
        try
        {
          if (type == null || object.ReferenceEquals((object) type, (object) Float.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Float>.Value))
            return (object) Float.valueOf(jsonData.asFloat());
          if (object.ReferenceEquals((object) type, (object) Integer.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Integer>.Value))
            return (object) Integer.valueOf(jsonData.asInt());
          if (object.ReferenceEquals((object) type, (object) Long.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Long>.Value))
            return (object) Long.valueOf(jsonData.asLong());
          if (object.ReferenceEquals((object) type, (object) Double.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Double>.Value))
            return (object) Double.valueOf(jsonData.asDouble());
          if (object.ReferenceEquals((object) type, (object) ClassLiteral<String>.Value))
            return (object) jsonData.asString();
          if (object.ReferenceEquals((object) type, (object) Short.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Short>.Value))
            return (object) Short.valueOf(jsonData.asShort());
          if (!object.ReferenceEquals((object) type, (object) Byte.TYPE))
          {
            if (!object.ReferenceEquals((object) type, (object) ClassLiteral<Byte>.Value))
              goto label_107;
          }
          @byte = Byte.valueOf(jsonData.asByte());
        }
        catch (NumberFormatException ex)
        {
          goto label_106;
        }
        return (object) @byte;
label_106:
label_107:
        jsonData = new JsonValue(jsonData.asString());
      }
      if (jsonData.isBoolean())
      {
        Boolean boolean;
        try
        {
          if (type != null && !object.ReferenceEquals((object) type, (object) Boolean.TYPE))
          {
            if (!object.ReferenceEquals((object) type, (object) ClassLiteral<Boolean>.Value))
              goto label_115;
          }
          boolean = Boolean.valueOf(jsonData.asBoolean());
        }
        catch (NumberFormatException ex)
        {
          goto label_114;
        }
        return (object) boolean;
label_114:
label_115:
        jsonData = new JsonValue(jsonData.asString());
      }
      if (!jsonData.isString())
        return (object) null;
      string str = jsonData.asString();
      if (type != null)
      {
        if (!object.ReferenceEquals((object) type, (object) ClassLiteral<String>.Value))
        {
          Byte @byte;
          try
          {
            if (object.ReferenceEquals((object) type, (object) Integer.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Integer>.Value))
              return (object) Integer.valueOf(str);
            if (object.ReferenceEquals((object) type, (object) Float.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Float>.Value))
              return !String.instancehelper_endsWith(str, "f") ? (!String.instancehelper_endsWith(str, "f,") ? (object) Float.valueOf(str) : (object) Float.valueOf(String.instancehelper_substring(str, 0, String.instancehelper_length(str) - 2))) : (object) Float.valueOf(String.instancehelper_substring(str, 0, String.instancehelper_length(str) - 1));
            if (object.ReferenceEquals((object) type, (object) Long.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Long>.Value))
              return (object) Long.valueOf(str);
            if (object.ReferenceEquals((object) type, (object) Double.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Double>.Value))
              return (object) Double.valueOf(str);
            if (object.ReferenceEquals((object) type, (object) Short.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Short>.Value))
              return (object) Short.valueOf(str);
            if (!object.ReferenceEquals((object) type, (object) Byte.TYPE))
            {
              if (!object.ReferenceEquals((object) type, (object) ClassLiteral<Byte>.Value))
                goto label_136;
            }
            @byte = Byte.valueOf(str);
          }
          catch (NumberFormatException ex)
          {
            goto label_135;
          }
          return (object) @byte;
label_135:
label_136:
          if (object.ReferenceEquals((object) type, (object) Boolean.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Boolean>.Value))
            return (object) Boolean.valueOf(str);
          if (object.ReferenceEquals((object) type, (object) Character.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Character>.Value))
            return (object) Character.valueOf(String.instancehelper_charAt(str, 0));
          if (((Class) ClassLiteral<Enum>.Value).isAssignableFrom(type))
          {
            Enum[] enumConstants = (Enum[]) type.getEnumConstants();
            int index = 0;
            for (int length = enumConstants.Length; index < length; ++index)
            {
              Enum @enum = enumConstants[index];
              if (String.instancehelper_equals(str, (object) this.convertToString(@enum)))
                return (object) @enum;
            }
          }
          if (object.ReferenceEquals((object) type, (object) ClassLiteral<CharSequence>.Value))
            return (object) str;
          string message = new StringBuilder().append("Unable to convert value to required type: ").append((object) jsonData).append(" (").append(type.getName()).append(")").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new SerializationException(message);
        }
      }
      return (object) str;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;TT;Larc/util/serialization/JsonValue;)TT;")]
    [LineNumberTable(new byte[] {163, 89, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readValue(
      Class type,
      Class elementType,
      object defaultValue,
      JsonValue jsonData)
    {
      return jsonData == null ? defaultValue : this.readValue(type, elementType, jsonData);
    }

    [LineNumberTable(101)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class getClass(string tag) => (Class) this.tagToClass.get((object) tag);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;Larc/util/serialization/JsonValue;)TT;")]
    [LineNumberTable(933)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readValue(string name, Class type, JsonValue jsonMap) => this.readValue(type, (Class) null, jsonMap.get(name));

    [LineNumberTable(new byte[] {163, 2, 103, 104, 109, 127, 41, 103, 120, 154, 133, 127, 38, 109, 168, 137, 255, 66, 75, 229, 54, 98, 127, 45, 98, 127, 29, 104, 98, 105, 109, 127, 29, 232, 39, 236, 92})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readFields(object @object, JsonValue jsonMap)
    {
      Class type = Object.instancehelper_getClass(@object);
      OrderedMap fields = this.getFields(type);
      for (JsonValue jsonData = jsonMap.child; jsonData != null; jsonData = jsonData.next)
      {
        OrderedMap orderedMap = fields;
        string str1 = jsonData.name();
        object obj1 = (object) "_";
        object obj2 = (object) " ";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        string str2 = String.instancehelper_replace(str1, charSequence2, charSequence3);
        Json.FieldMetadata fieldMetadata = (Json.FieldMetadata) orderedMap.get((object) str2);
        if (fieldMetadata == null)
        {
          if (!String.instancehelper_equals(jsonData.name, (object) this.typeName) && !this.ignoreUnknownFields && !this.ignoreUnknownField(type, jsonData.name))
          {
            SerializationException serializationException = new SerializationException(new StringBuilder().append("Field not found: ").append(jsonData.name).append(" (").append(type.getName()).append(")").toString());
            serializationException.addTrace(jsonData.trace());
            throw Throwable.__\u003Cunmap\u003E((Exception) serializationException);
          }
        }
        else
        {
          Field field = fieldMetadata.__\u003C\u003Efield;
          IllegalAccessException illegalAccessException1;
          SerializationException serializationException1;
          RuntimeException runtimeException;
          try
          {
            try
            {
              try
              {
                field.set(@object, this.readValue(field.getType(), fieldMetadata.elementType, jsonData, fieldMetadata.keyType), Json.__\u003CGetCallerID\u003E());
                continue;
              }
              catch (IllegalAccessException ex)
              {
                illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              }
            }
            catch (SerializationException ex)
            {
              serializationException1 = (SerializationException) ByteCodeHelper.MapException<SerializationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              goto label_13;
            }
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              runtimeException = (RuntimeException) m0;
              goto label_14;
            }
          }
          IllegalAccessException illegalAccessException2 = illegalAccessException1;
          string message = new StringBuilder().append("Error accessing field: ").append(field.getName()).append(" (").append(type.getName()).append(")").toString();
          IllegalAccessException illegalAccessException3 = illegalAccessException2;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new SerializationException(message, (Exception) illegalAccessException3);
label_13:
          SerializationException serializationException2 = serializationException1;
          serializationException2.addTrace(new StringBuilder().append(field.getName()).append(" (").append(type.getName()).append(")").toString());
          throw Throwable.__\u003Cunmap\u003E((Exception) serializationException2);
label_14:
          SerializationException serializationException3 = new SerializationException((Exception) runtimeException);
          serializationException3.addTrace(jsonData.trace());
          serializationException3.addTrace(new StringBuilder().append(field.getName()).append(" (").append(type.getName()).append(")").toString());
          throw Throwable.__\u003Cunmap\u003E((Exception) serializationException3);
        }
      }
    }

    [LineNumberTable(new byte[] {158, 98, 66, 109, 127, 10, 120, 114, 147, 159, 20, 191, 20, 2, 98, 159, 14, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void copyFields(object from, object to, bool setFinals)
    {
      int num = setFinals ? 1 : 0;
      OrderedMap fields = this.getFields(Object.instancehelper_getClass(from));
      ObjectMap.Entries entries = this.getFields(Object.instancehelper_getClass(from)).iterator();
      while (((Iterator) entries).hasNext())
      {
        ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
        Json.FieldMetadata fieldMetadata = (Json.FieldMetadata) fields.get((object) (string) entry.key);
        Field field = ((Json.FieldMetadata) entry.value).__\u003C\u003Efield;
        if (!Modifier.isFinal(field.getModifiers()) || num != 0)
        {
          if (fieldMetadata == null)
          {
            string message = new StringBuilder().append("To object is missing field").append((string) entry.key).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new SerializationException(message);
          }
          IllegalAccessException illegalAccessException1;
          try
          {
            fieldMetadata.__\u003C\u003Efield.set(to, field.get(from, Json.__\u003CGetCallerID\u003E()), Json.__\u003CGetCallerID\u003E());
            continue;
          }
          catch (IllegalAccessException ex)
          {
            illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          IllegalAccessException illegalAccessException2 = illegalAccessException1;
          string message1 = new StringBuilder().append("Error copying field: ").append(field.getName()).toString();
          IllegalAccessException illegalAccessException3 = illegalAccessException2;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new SerializationException(message1, (Exception) illegalAccessException3);
        }
      }
    }

    [LineNumberTable(1262)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string prettyPrint(object @object, int singleLineColumns) => this.prettyPrint(this.toJson(@object), singleLineColumns);

    [LineNumberTable(1266)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string prettyPrint(string json, int singleLineColumns) => new JsonReader().parse(json).prettyPrint(this.outputType, singleLineColumns);

    [LineNumberTable(197)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toJson(object @object) => this.toJson(@object, @object != null ? Object.instancehelper_getClass(@object) : (Class) null, (Class) null);

    [LineNumberTable(1274)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string prettyPrint(string json, JsonValue.PrettyPrintSettings settings) => new JsonReader().parse(json).prettyPrint(settings);

    [LineNumberTable(new byte[] {159, 185, 232, 47, 107, 107, 107, 107, 107, 159, 1, 107, 167, 167, 199, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Json()
    {
      Json json = this;
      this.typeToFields = new ObjectMap();
      this.tagToClass = new ObjectMap();
      this.classToTag = new ObjectMap();
      this.classToSerializer = new ObjectMap();
      this.classToDefaultValues = new ObjectMap();
      this.equals1 = new object[1]{ (object) null };
      this.equals2 = new object[1]{ (object) null };
      this.typeName = "class";
      this.usePrototypes = true;
      this.ignoreUnknownFields = true;
      this.enumNames = true;
      this.outputType = JsonWriter.OutputType.__\u003C\u003Eminimal;
    }

    [LineNumberTable(new byte[] {159, 189, 232, 43, 107, 107, 107, 107, 107, 159, 1, 107, 167, 167, 231, 72, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Json(JsonWriter.OutputType outputType)
    {
      Json json = this;
      this.typeToFields = new ObjectMap();
      this.tagToClass = new ObjectMap();
      this.classToTag = new ObjectMap();
      this.classToSerializer = new ObjectMap();
      this.classToDefaultValues = new ObjectMap();
      this.equals1 = new object[1]{ (object) null };
      this.equals2 = new object[1]{ (object) null };
      this.typeName = "class";
      this.usePrototypes = true;
      this.ignoreUnknownFields = true;
      this.enumNames = true;
      this.outputType = outputType;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getIgnoreUnknownFields() => this.ignoreUnknownFields;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIgnoreUnknownFields(bool ignoreUnknownFields) => this.ignoreUnknownFields = ignoreUnknownFields;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setIgnoreDeprecated(bool ignoreDeprecated) => this.ignoreDeprecated = ignoreDeprecated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setReadDeprecated(bool readDeprecated) => this.readDeprecated = readDeprecated;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOutputType(JsonWriter.OutputType outputType) => this.outputType = outputType;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setQuoteLongValues(bool quoteLongValues) => this.quoteLongValues = quoteLongValues;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setEnumNames(bool enumNames) => this.enumNames = enumNames;

    [LineNumberTable(new byte[] {45, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addClassTag(string tag, Class type)
    {
      this.tagToClass.put((object) tag, (object) type);
      this.classToTag.put((object) type, (object) tag);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTypeName(string typeName) => this.typeName = typeName;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDefaultSerializer(Json.Serializer defaultSerializer) => this.defaultSerializer = defaultSerializer;

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/util/serialization/Json$Serializer<TT;>;)V")]
    [LineNumberTable(new byte[] {81, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setSerializer(Class type, Json.Serializer serializer) => this.classToSerializer.put((object) type, (object) serializer);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;)Larc/util/serialization/Json$Serializer<TT;>;")]
    [LineNumberTable(135)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Json.Serializer getSerializer(Class type) => (Json.Serializer) this.classToSerializer.get((object) type);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUsePrototypes(bool usePrototypes) => this.usePrototypes = usePrototypes;

    [LineNumberTable(new byte[] {98, 104, 109, 99, 127, 37, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setElementType(Class type, string fieldName, Class elementType)
    {
      Json.FieldMetadata fieldMetadata = (Json.FieldMetadata) this.getFields(type).get((object) fieldName);
      if (fieldMetadata == null)
      {
        string message = new StringBuilder().append("Field not found: ").append(fieldName).append(" (").append(type.getName()).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message);
      }
      fieldMetadata.elementType = elementType;
    }

    [LineNumberTable(201)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toJson(object @object, Class knownType) => this.toJson(@object, knownType, (Class) null);

    [LineNumberTable(new byte[] {160, 91, 108, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toUBJson(object @object, Class knownType, OutputStream stream)
    {
      this.writer = (BaseJsonWriter) new UBJsonWriter(stream);
      this.toJson(@object, knownType, (Class) null);
    }

    [LineNumberTable(new byte[] {160, 106, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toJson(object @object, Fi file) => this.toJson(@object, @object != null ? Object.instancehelper_getClass(@object) : (Class) null, (Class) null, file);

    [LineNumberTable(new byte[] {160, 111, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toJson(object @object, Class knownType, Fi file) => this.toJson(@object, knownType, (Class) null, file);

    [LineNumberTable(new byte[] {160, 131, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toJson(object @object, Writer writer) => this.toJson(@object, @object != null ? Object.instancehelper_getClass(@object) : (Class) null, (Class) null, writer);

    [LineNumberTable(new byte[] {160, 136, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void toJson(object @object, Class knownType, Writer writer) => this.toJson(@object, knownType, (Class) null, writer);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BaseJsonWriter getWriter() => this.writer;

    [LineNumberTable(new byte[] {160, 244, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeField(object @object, string name) => this.writeField(@object, name, name, (Class) null);

    [LineNumberTable(new byte[] {160, 252, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeField(object @object, string name, Class elementType) => this.writeField(@object, name, name, elementType);

    [LineNumberTable(new byte[] {161, 1, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeField(object @object, string fieldName, string jsonName) => this.writeField(@object, fieldName, jsonName, (Class) null);

    [LineNumberTable(new byte[] {161, 74, 191, 0, 2, 97, 140, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeValue(string name, object value, Class knownType, Class elementType)
    {
      IOException ioException1;
      try
      {
        this.writer.name(name);
        goto label_3;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
label_3:
      this.writeValue(value, knownType, elementType);
    }

    [LineNumberTable(new byte[] {161, 86, 99, 139, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeValue(object value)
    {
      if (value == null)
        this.writeValue(value, (Class) null, (Class) null);
      else
        this.writeValue(value, Object.instancehelper_getClass(value), (Class) null);
    }

    [LineNumberTable(new byte[] {161, 98, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeValue(object value, Class knownType) => this.writeValue(value, knownType, (Class) null);

    [LineNumberTable(new byte[] {162, 35, 191, 0, 2, 97, 140, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeObjectStart(string name)
    {
      IOException ioException1;
      try
      {
        this.writer.name(name);
        goto label_3;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
label_3:
      this.writeObjectStart();
    }

    [LineNumberTable(new byte[] {162, 45, 191, 0, 2, 97, 140, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeObjectStart(string name, Class actualType, Class knownType)
    {
      IOException ioException1;
      try
      {
        this.writer.name(name);
        goto label_3;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException((Exception) ioException2);
label_3:
      this.writeObjectStart(actualType, knownType);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/io/Reader;)TT;")]
    [LineNumberTable(749)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(Class type, Reader reader) => this.readValue(type, (Class) null, new JsonReader().parse(reader));

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;Ljava/io/Reader;)TT;")]
    [LineNumberTable(758)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(Class type, Class elementType, Reader reader) => this.readValue(type, elementType, new JsonReader().parse(reader));

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/io/InputStream;)TT;")]
    [LineNumberTable(766)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(Class type, InputStream input) => this.readValue(type, (Class) null, new JsonReader().parse(input));

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;Ljava/io/InputStream;)TT;")]
    [LineNumberTable(775)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(Class type, Class elementType, InputStream input) => this.readValue(type, elementType, new JsonReader().parse(input));

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/files/Fi;)TT;")]
    [LineNumberTable(new byte[] {162, 158, 127, 15, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(Class type, Fi file)
    {
      object obj;
      Exception exception1;
      try
      {
        obj = this.readValue(type, (Class) null, new JsonReader().parse(file));
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj;
label_5:
      Exception exception2 = exception1;
      string message = new StringBuilder().append("Error reading file: ").append((object) file).toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException(message, (Exception) exception3);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;Larc/files/Fi;)TT;")]
    [LineNumberTable(new byte[] {162, 171, 127, 15, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(Class type, Class elementType, Fi file)
    {
      object obj;
      Exception exception1;
      try
      {
        obj = this.readValue(type, elementType, new JsonReader().parse(file));
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj;
label_5:
      Exception exception2 = exception1;
      string message = new StringBuilder().append("Error reading file: ").append((object) file).toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SerializationException(message, (Exception) exception3);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;[CII)TT;")]
    [LineNumberTable(808)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(Class type, char[] data, int offset, int length) => this.readValue(type, (Class) null, new JsonReader().parse(data, offset, length));

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;[CII)TT;")]
    [LineNumberTable(817)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(
      Class type,
      Class elementType,
      char[] data,
      int offset,
      int length)
    {
      return this.readValue(type, elementType, new JsonReader().parse(data, offset, length));
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/String;)TT;")]
    [LineNumberTable(825)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(Class type, string json) => this.readValue(type, (Class) null, new JsonReader().parse(json));

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;Ljava/lang/String;)TT;")]
    [LineNumberTable(833)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromJson(Class type, Class elementType, string json) => this.readValue(type, elementType, new JsonReader().parse(json));

    [LineNumberTable(new byte[] {162, 211, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readField(object @object, string name, JsonValue jsonData) => this.readField(@object, name, name, (Class) null, jsonData);

    [LineNumberTable(new byte[] {162, 215, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readField(
      object @object,
      string name,
      Class elementType,
      JsonValue jsonData)
    {
      this.readField(@object, name, name, elementType, jsonData);
    }

    [LineNumberTable(new byte[] {162, 219, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void readField(
      object @object,
      string fieldName,
      string jsonName,
      JsonValue jsonData)
    {
      this.readField(@object, fieldName, jsonName, (Class) null, jsonData);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;TT;Larc/util/serialization/JsonValue;)TT;")]
    [LineNumberTable(new byte[] {163, 59, 105, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readValue(
      string name,
      Class type,
      object defaultValue,
      JsonValue jsonMap)
    {
      JsonValue jsonData = jsonMap.get(name);
      return jsonData == null ? defaultValue : this.readValue(type, (Class) null, jsonData);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;Ljava/lang/Class;Larc/util/serialization/JsonValue;)TT;")]
    [LineNumberTable(952)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readValue(string name, Class type, Class elementType, JsonValue jsonMap) => this.readValue(type, elementType, jsonMap.get(name));

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;Ljava/lang/Class;TT;Larc/util/serialization/JsonValue;)TT;")]
    [LineNumberTable(new byte[] {163, 79, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readValue(
      string name,
      Class type,
      Class elementType,
      object defaultValue,
      JsonValue jsonMap)
    {
      JsonValue jsonData = jsonMap.get(name);
      return this.readValue(type, elementType, defaultValue, jsonData);
    }

    [LineNumberTable(new byte[] {164, 58, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void copyFields(object from, object to) => this.copyFields(from, to, false);

    [LineNumberTable(1254)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string prettyPrint(object @object) => this.prettyPrint(@object, 0);

    [LineNumberTable(1258)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string prettyPrint(string json) => this.prettyPrint(json, 0);

    [LineNumberTable(1270)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string prettyPrint(object @object, JsonValue.PrettyPrintSettings settings) => this.prettyPrint(this.toJson(@object), settings);

    [LineNumberTable(new byte[] {164, 165, 103, 107, 108, 106, 100, 104, 103, 104, 113, 104, 108, 104, 210})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Class getElementType([In] Field obj0, [In] int obj1)
    {
      Type genericType = obj0.getGenericType();
      if (genericType is ParameterizedType)
      {
        Type[] actualTypeArguments = ((ParameterizedType) genericType).getActualTypeArguments();
        if (actualTypeArguments.Length - 1 >= obj1)
        {
          Type type = actualTypeArguments[obj1];
          switch (type)
          {
            case Class _:
              return (Class) type;
            case ParameterizedType _:
              return (Class) ((ParameterizedType) type).getRawType();
            case GenericArrayType _:
              Type genericComponentType = ((GenericArrayType) type).getGenericComponentType();
              if (genericComponentType is Class)
                return Object.instancehelper_getClass(Array.newInstance((Class) genericComponentType, 0));
              break;
          }
        }
      }
      return (Class) null;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Json.__\u003CcallerID\u003E == null)
        Json.__\u003CcallerID\u003E = (CallerID) new Json.__\u003CCallerID\u003E();
      return Json.__\u003CcallerID\u003E;
    }

    public class FieldMetadata : Object
    {
      internal Field __\u003C\u003Efield;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Class elementType;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public Class keyType;

      [LineNumberTable(new byte[] {164, 154, 104, 120, 145, 103, 115, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public FieldMetadata(Field field)
      {
        Json.FieldMetadata fieldMetadata = this;
        int num = ((Class) ClassLiteral<ObjectMap>.Value).isAssignableFrom(field.getType()) || ((Class) ClassLiteral<Map>.Value).isAssignableFrom(field.getType()) ? 1 : 0;
        this.__\u003C\u003Efield = field;
        this.elementType = Json.getElementType(field, num == 0 ? 0 : 1);
        this.keyType = num == 0 ? (Class) null : Json.getElementType(field, 0);
      }

      [Modifiers]
      public Field field
      {
        [HideFromJava] get => this.__\u003C\u003Efield;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Efield = value;
      }
    }

    public interface JsonSerializable
    {
      void write(Json j);

      void read(Json j, JsonValue jv);
    }

    [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
    public interface Serializer
    {
      [Signature("(Larc/util/serialization/Json;TT;Ljava/lang/Class;)V")]
      void write(Json j, object obj, Class c);

      [Signature("(Larc/util/serialization/Json;Larc/util/serialization/JsonValue;Ljava/lang/Class;)TT;")]
      object read(Json j, JsonValue jv, Class c);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
