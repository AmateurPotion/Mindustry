// Decompiled with JetBrains decompiler
// Type: com.sun.jna.Structure
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using ikvm.lang;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.nio;
using java.util;
using java.util.function;
using java.util.stream;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace com.sun.jna
{
  public abstract class Structure : Object
  {
    public const int ALIGN_DEFAULT = 0;
    public const int ALIGN_NONE = 1;
    public const int ALIGN_GNUC = 2;
    public const int ALIGN_MSVC = 3;
    protected internal const int CALCULATE_SIZE = -1;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Class<*>;Lcom/sun/jna/Structure$LayoutInfo;>;")]
    internal static Map layoutInfo;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/Class<*>;Ljava/util/List<Ljava/lang/String;>;>;")]
    internal static Map fieldOrder;
    private Pointer memory;
    private int size;
    private int alignType;
    private string encoding;
    private int actualAlignType;
    private int structAlignment;
    [Signature("Ljava/util/Map<Ljava/lang/String;Lcom/sun/jna/Structure$StructField;>;")]
    private Map structFields;
    [Modifiers]
    [Signature("Ljava/util/Map<Ljava/lang/String;Ljava/lang/Object;>;")]
    private Map nativeStrings;
    private TypeMapper typeMapper;
    private long typeInfo;
    private bool autoRead;
    private bool autoWrite;
    private Structure[] array;
    private bool readCalled;
    [Modifiers]
    [Signature("Ljava/lang/ThreadLocal<Ljava/util/Map<Lcom/sun/jna/Pointer;Lcom/sun/jna/Structure;>;>;")]
    private static ThreadLocal reads;
    [Modifiers]
    [Signature("Ljava/lang/ThreadLocal<Ljava/util/Set<Lcom/sun/jna/Structure;>;>;")]
    private static ThreadLocal busy;
    [Modifiers]
    private static Pointer PLACEHOLDER_MEMORY;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 51, 98, 104, 140, 108, 110, 173, 223, 18, 2, 97, 209})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void ensureAllocated([In] bool obj0)
    {
      int num = obj0 ? 1 : 0;
      if (this.memory == null)
      {
        this.allocateMemory(num != 0);
      }
      else
      {
        if (this.size != -1)
          return;
        this.size = this.calculateSize(true, num != 0);
        if (!(this.memory is Structure.AutoAllocated))
        {
          IndexOutOfBoundsException ofBoundsException1;
          try
          {
            this.memory = this.memory.share(0L, (long) this.size);
            return;
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<IndexOutOfBoundsException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
              throw;
            else
              ofBoundsException1 = (IndexOutOfBoundsException) m0;
          }
          IndexOutOfBoundsException ofBoundsException2 = ofBoundsException1;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Structure exceeds provided memory bounds", (Exception) ofBoundsException2);
        }
      }
    }

    [LineNumberTable(new byte[] {119, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Structure(int alignType)
      : this((Pointer) null, alignType)
    {
    }

    [LineNumberTable(new byte[] {160, 71, 232, 20, 231, 72, 235, 69, 103, 231, 95, 103, 113, 103, 102, 99, 171, 135, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Structure(Pointer p, int alignType, TypeMapper mapper)
    {
      Structure structure = this;
      this.size = -1;
      this.nativeStrings = (Map) new HashMap();
      this.autoRead = true;
      this.autoWrite = true;
      this.setAlignType(alignType);
      this.setStringEncoding(Native.getStringEncoding(Object.instancehelper_getClass((object) this)));
      this.initializeTypeMapper(mapper);
      this.validateFields();
      if (p != null)
        this.useMemory(p, 0, true);
      else
        this.allocateMemory(-1);
      this.initializeFields();
    }

    [LineNumberTable(new byte[] {160, 68, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Structure(Pointer p, int alignType)
      : this(p, alignType, (TypeMapper) null)
    {
    }

    [LineNumberTable(new byte[] {160, 153, 103, 99, 109, 99, 103, 133, 163, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setAlignType(int alignType)
    {
      this.alignType = alignType;
      if (alignType == 0)
      {
        alignType = Native.getStructureAlignment(Object.instancehelper_getClass((object) this));
        if (alignType == 0)
          alignType = !Platform.isWindows() ? 2 : 3;
      }
      this.actualAlignType = alignType;
      this.layoutChanged();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void setStringEncoding(string encoding) => this.encoding = encoding;

    [LineNumberTable(new byte[] {160, 110, 99, 141, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initializeTypeMapper([In] TypeMapper obj0)
    {
      if (obj0 == null)
        obj0 = Native.getTypeMapper(Object.instancehelper_getClass((object) this));
      this.typeMapper = obj0;
      this.layoutChanged();
    }

    [LineNumberTable(new byte[] {164, 22, 103, 123, 114, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void validateFields()
    {
      Iterator iterator = this.getFieldList().iterator();
      while (iterator.hasNext())
      {
        Field field = (Field) iterator.next();
        this.validateField(field.getName(), field.getType());
      }
    }

    [LineNumberTable(new byte[] {159, 61, 98, 139, 171, 108, 108, 113, 194, 110, 105, 141, 105, 181, 103, 222, 2, 97, 145})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void useMemory([In] Pointer obj0, [In] int obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      IndexOutOfBoundsException ofBoundsException1;
      try
      {
        this.nativeStrings.clear();
        if (this is Structure.ByValue && num == 0)
        {
          byte[] buf = new byte[this.size()];
          obj0.read(0L, buf, 0, buf.Length);
          this.memory.write(0L, buf, 0, buf.Length);
        }
        else
        {
          this.memory = obj0.share((long) obj1);
          if (this.size == -1)
            this.size = this.calculateSize(false);
          if (this.size != -1)
            this.memory = obj0.share((long) obj1, (long) this.size);
        }
        this.array = (Structure[]) null;
        this.readCalled = false;
        return;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<IndexOutOfBoundsException>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          ofBoundsException1 = (IndexOutOfBoundsException) m0;
      }
      IndexOutOfBoundsException ofBoundsException2 = ofBoundsException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException("Structure exceeds provided memory bounds", (Exception) ofBoundsException2);
    }

    [LineNumberTable(new byte[] {161, 31, 132, 139, 100, 223, 6, 100, 149, 141, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void allocateMemory(int size)
    {
      if (size == -1)
        size = this.calculateSize(false);
      else if (size <= 0)
      {
        string str = new StringBuilder().append("Structure size must be greater than zero: ").append(size).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (size == -1)
        return;
      if (this.memory == null || this.memory is Structure.AutoAllocated)
        this.memory = (Pointer) this.autoAllocate(size);
      this.size = size;
    }

    [LineNumberTable(new byte[] {164, 186, 103, 158, 109, 99, 255, 8, 69, 2, 98, 159, 34, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void initializeFields()
    {
      Iterator iterator = this.getFieldList().iterator();
      while (iterator.hasNext())
      {
        Field field = (Field) iterator.next();
        Exception exception1;
        try
        {
          if (field.get((object) this, Structure.__\u003CGetCallerID\u003E()) == null)
          {
            this.initializeField(field, field.getType());
            continue;
          }
          continue;
        }
        catch (Exception ex)
        {
          M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          if (m0 == null)
            throw;
          else
            exception1 = (Exception) m0;
        }
        Exception exception2 = exception1;
        string str = new StringBuilder().append("Exception reading field '").append(field.getName()).append("' in ").append((object) Object.instancehelper_getClass((object) this)).toString();
        Exception exception3 = exception2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new Error(str, (Exception) exception3);
      }
    }

    [LineNumberTable(new byte[] {160, 121, 105, 103, 109, 167, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void layoutChanged()
    {
      if (this.size == -1)
        return;
      this.size = -1;
      if (this.memory is Structure.AutoAllocated)
        this.memory = (Pointer) null;
      this.ensureAllocated();
    }

    [LineNumberTable(new byte[] {160, 242, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void ensureAllocated() => this.ensureAllocated(false);

    [LineNumberTable(new byte[] {160, 195, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void useMemory(Pointer m, int offset) => this.useMemory(m, offset, false);

    [LineNumberTable(new byte[] {161, 53, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int size()
    {
      this.ensureAllocated();
      return this.size;
    }

    [LineNumberTable(1049)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int calculateSize(bool force) => this.calculateSize(force, false);

    [LineNumberTable(new byte[] {159, 45, 130, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void allocateMemory([In] bool obj0) => this.allocateMemory(this.calculateSize(true, obj0));

    [LineNumberTable(new byte[] {158, 126, 68, 98, 135, 109, 114, 119, 108, 111, 108, 138, 103, 109, 141, 105, 237, 70, 189, 142, 144, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual int calculateSize([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      int num3 = -1;
      Class @class = Object.instancehelper_getClass((object) this);
      Map layoutInfo1;
      Monitor.Enter((object) (layoutInfo1 = Structure.layoutInfo));
      Structure.LayoutInfo layoutInfo2;
      // ISSUE: fault handler
      try
      {
        layoutInfo2 = (Structure.LayoutInfo) Structure.layoutInfo.get((object) @class);
        Monitor.Exit((object) layoutInfo1);
      }
      __fault
      {
        Monitor.Exit((object) layoutInfo1);
      }
      if (layoutInfo2 == null || this.alignType != Structure.LayoutInfo.access\u0024200(layoutInfo2) || !object.ReferenceEquals((object) this.typeMapper, (object) Structure.LayoutInfo.access\u0024300(layoutInfo2)))
        layoutInfo2 = this.deriveLayout(num1 != 0, num2 != 0);
      if (layoutInfo2 != null)
      {
        this.structAlignment = Structure.LayoutInfo.access\u0024400(layoutInfo2);
        this.structFields = Structure.LayoutInfo.access\u0024500(layoutInfo2);
        if (!Structure.LayoutInfo.access\u0024000(layoutInfo2))
        {
          lock (Structure.layoutInfo)
          {
            if (Structure.layoutInfo.containsKey((object) @class) && this.alignType == 0)
            {
              if (this.typeMapper == null)
                goto label_12;
            }
            Structure.layoutInfo.put((object) @class, (object) layoutInfo2);
          }
        }
label_12:
        num3 = Structure.LayoutInfo.access\u0024100(layoutInfo2);
      }
      return num3;
    }

    [LineNumberTable(287)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Memory autoAllocate(int size) => (Memory) new Structure.AutoAllocated(size);

    [LineNumberTable(new byte[] {167, 168, 104, 102, 104, 108, 45, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void autoRead()
    {
      if (!this.getAutoRead())
        return;
      this.read();
      if (this.array == null)
        return;
      for (int index = 1; index < this.array.Length; ++index)
        this.array[index].autoRead();
    }

    [Signature("()Ljava/util/Set<Lcom/sun/jna/Structure;>;")]
    [LineNumberTable(541)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Set busy() => (Set) Structure.busy.get();

    [Signature("()Ljava/util/Map<Lcom/sun/jna/Pointer;Lcom/sun/jna/Structure;>;")]
    [LineNumberTable(544)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Map reading() => (Map) Structure.reads.get();

    [LineNumberTable(new byte[] {161, 74, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Pointer getPointer()
    {
      this.ensureAllocated();
      return this.memory;
    }

    [Signature("()Ljava/util/Map<Ljava/lang/String;Lcom/sun/jna/Structure$StructField;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Map fields() => this.structFields;

    [LineNumberTable(new byte[] {162, 71, 167, 103, 103, 99, 167, 115, 116, 109, 109, 104, 110, 169, 109, 111, 120, 130, 145, 99, 112, 109, 195, 115, 103, 127, 25, 223, 14, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual object readField(Structure.StructField structField)
    {
      int offset = structField.offset;
      Class @class = structField.type;
      FromNativeConverter readConverter = structField.readConverter;
      if (readConverter != null)
        @class = readConverter.nativeType();
      object obj1 = ((Class) ClassLiteral<Structure>.Value).isAssignableFrom(@class) || ((Class) ClassLiteral<Callback>.Value).isAssignableFrom(@class) || Platform.__\u003C\u003EHAS_BUFFERS && ((Class) ClassLiteral<Buffer>.Value).isAssignableFrom(@class) || (((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(@class) || ((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(@class) || @class.isArray()) ? this.getFieldValue(structField.field) : (object) null;
      object obj2 = !object.ReferenceEquals((object) @class, (object) ClassLiteral<String>.Value) ? this.memory.getValue((long) offset, @class, obj1) : (object) this.memory.getPointer((long) offset)?.getString(0L, this.encoding);
      if (readConverter != null)
      {
        obj2 = readConverter.fromNative(obj2, structField.context);
        if (obj1 != null && Object.instancehelper_equals(obj1, obj2))
          obj2 = obj1;
      }
      if (Object.instancehelper_equals((object) @class, (object) ClassLiteral<String>.Value) || Object.instancehelper_equals((object) @class, (object) ClassLiteral<WString>.Value))
      {
        this.nativeStrings.put((object) new StringBuilder().append(structField.name).append(".ptr").toString(), (object) this.memory.getPointer((long) offset));
        this.nativeStrings.put((object) new StringBuilder().append(structField.name).append(".val").toString(), obj2);
      }
      this.setFieldValue(structField.field, obj2, true);
      return obj2;
    }

    [LineNumberTable(new byte[] {158, 238, 130, 255, 0, 77, 229, 53, 97, 103, 107, 163, 159, 43, 159, 33, 159, 33})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setFieldValue([In] Field obj0, [In] object obj1, [In] bool obj2)
    {
      int num = obj2 ? 1 : 0;
      IllegalAccessException illegalAccessException1;
      try
      {
        obj0.set((object) this, obj1, Structure.__\u003CGetCallerID\u003E());
        return;
      }
      catch (IllegalAccessException ex)
      {
        illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IllegalAccessException illegalAccessException2 = illegalAccessException1;
      if (Modifier.isFinal(obj0.getModifiers()))
      {
        if (num != 0)
        {
          string str = new StringBuilder().append("This VM does not support Structures with final fields (field '").append(obj0.getName()).append("' within ").append((object) Object.instancehelper_getClass((object) this)).append(")").toString();
          IllegalAccessException illegalAccessException3 = illegalAccessException2;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new UnsupportedOperationException(str, (Exception) illegalAccessException3);
        }
        string str1 = new StringBuilder().append("Attempt to write to read-only field '").append(obj0.getName()).append("' within ").append((object) Object.instancehelper_getClass((object) this)).toString();
        IllegalAccessException illegalAccessException4 = illegalAccessException2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new UnsupportedOperationException(str1, (Exception) illegalAccessException4);
      }
      string str2 = new StringBuilder().append("Unexpectedly unable to write to field '").append(obj0.getName()).append("' within ").append((object) Object.instancehelper_getClass((object) this)).toString();
      IllegalAccessException illegalAccessException5 = illegalAccessException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new Error(str2, (Exception) illegalAccessException5);
    }

    [Throws(new string[] {"java.lang.IllegalArgumentException"})]
    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/Pointer;)Lcom/sun/jna/Structure;")]
    [LineNumberTable(new byte[] {166, 132, 122, 159, 56, 225, 82, 229, 49, 225, 79, 229, 52, 98, 124, 143, 98, 127, 7, 143, 98, 124, 103, 143, 104, 109, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Structure newInstance(Class type, Pointer init)
    {
      Structure structure1;
      InstantiationException instantiationException1;
      IllegalAccessException illegalAccessException1;
      InvocationTargetException invocationTargetException1;
      try
      {
        try
        {
          try
          {
            try
            {
              try
              {
                structure1 = (Structure) type.getConstructor(new Class[1]
                {
                  (Class) ClassLiteral<Pointer>.Value
                }, Structure.__\u003CGetCallerID\u003E()).newInstance(new object[1]
                {
                  (object) init
                }, Structure.__\u003CGetCallerID\u003E());
              }
              catch (NoSuchMethodException ex)
              {
                goto label_7;
              }
            }
            catch (SecurityException ex)
            {
              goto label_8;
            }
          }
          catch (InstantiationException ex)
          {
            instantiationException1 = (InstantiationException) ByteCodeHelper.MapException<InstantiationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_9;
          }
        }
        catch (IllegalAccessException ex)
        {
          illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_10;
        }
      }
      catch (InvocationTargetException ex)
      {
        invocationTargetException1 = (InvocationTargetException) ByteCodeHelper.MapException<InvocationTargetException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_11;
      }
      return structure1;
label_7:
      goto label_12;
label_8:
      goto label_12;
label_9:
      InstantiationException instantiationException2 = instantiationException1;
      string str1 = new StringBuilder().append("Can't instantiate ").append((object) type).toString();
      InstantiationException instantiationException3 = instantiationException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str1, (Exception) instantiationException3);
label_10:
      IllegalAccessException illegalAccessException2 = illegalAccessException1;
      string str2 = new StringBuilder().append("Instantiation of ").append((object) type).append(" (Pointer) not allowed, is it public?").toString();
      IllegalAccessException illegalAccessException3 = illegalAccessException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str2, (Exception) illegalAccessException3);
label_11:
      InvocationTargetException invocationTargetException2 = invocationTargetException1;
      string str3 = new StringBuilder().append("Exception thrown while instantiating an instance of ").append((object) type).toString();
      Throwable.instancehelper_printStackTrace((Exception) invocationTargetException2);
      string str4 = str3;
      InvocationTargetException invocationTargetException3 = invocationTargetException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str4, (Exception) invocationTargetException3);
label_12:
      Structure structure2 = Structure.newInstance(type);
      if (!object.ReferenceEquals((object) init, (object) Structure.PLACEHOLDER_MEMORY))
        structure2.useMemory(init);
      return structure2;
    }

    [LineNumberTable(new byte[] {161, 179, 104, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void conditionalAutoRead()
    {
      if (this.readCalled)
        return;
      this.autoRead();
    }

    [LineNumberTable(new byte[] {161, 254, 159, 8, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object getFieldValue([In] Field obj0)
    {
      object obj;
      Exception exception1;
      try
      {
        obj = obj0.get((object) this, Structure.__\u003CGetCallerID\u003E());
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
      string str = new StringBuilder().append("Exception reading field '").append(obj0.getName()).append("' in ").append((object) Object.instancehelper_getClass((object) this)).toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new Error(str, (Exception) exception3);
    }

    [LineNumberTable(new byte[] {166, 35, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Pointer getTypeInfo()
    {
      Pointer typeInfo = Structure.getTypeInfo((object) this);
      this.cacheTypeInfo(typeInfo);
      return typeInfo;
    }

    [LineNumberTable(new byte[] {162, 185, 104, 161, 167, 173, 103, 103, 99, 116, 199, 189, 115, 166, 127, 51, 108, 129, 101, 110, 178, 116, 104, 130, 146, 127, 12, 223, 12, 255, 4, 73, 229, 57, 98, 255, 95, 69, 143})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void writeField(Structure.StructField structField)
    {
      if (!structField.isReadOnly)
      {
        int offset = structField.offset;
        object obj = this.getFieldValue(structField.field);
        Class @class = structField.type;
        ToNativeConverter writeConverter = structField.writeConverter;
        if (writeConverter != null)
        {
          obj = writeConverter.toNative(obj, (ToNativeContext) new StructureWriteContext(this, structField.field));
          @class = writeConverter.nativeType();
        }
        if (!object.ReferenceEquals((object) ClassLiteral<String>.Value, (object) @class))
        {
          if (!object.ReferenceEquals((object) ClassLiteral<WString>.Value, (object) @class))
            goto label_11;
        }
        int num = !object.ReferenceEquals((object) @class, (object) ClassLiteral<WString>.Value) ? 0 : 1;
        if (obj != null)
        {
          if (this.nativeStrings.containsKey((object) new StringBuilder().append(structField.name).append(".ptr").toString()) && Object.instancehelper_equals(obj, this.nativeStrings.get((object) new StringBuilder().append(structField.name).append(".val").toString())))
            return;
          NativeString nativeString = num == 0 ? new NativeString(Object.instancehelper_toString(obj), this.encoding) : new NativeString(Object.instancehelper_toString(obj), true);
          this.nativeStrings.put((object) structField.name, (object) nativeString);
          obj = (object) nativeString.getPointer();
        }
        else
          this.nativeStrings.remove((object) structField.name);
        this.nativeStrings.remove((object) new StringBuilder().append(structField.name).append(".ptr").toString());
        this.nativeStrings.remove((object) new StringBuilder().append(structField.name).append(".val").toString());
label_11:
        IllegalArgumentException argumentException1;
        try
        {
          this.memory.setValue((long) offset, obj, @class);
          return;
        }
        catch (IllegalArgumentException ex)
        {
          argumentException1 = (IllegalArgumentException) ByteCodeHelper.MapException<IllegalArgumentException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        IllegalArgumentException argumentException2 = argumentException1;
        string str = new StringBuilder().append("Structure field \"").append(structField.name).append("\" was declared as ").append((object) structField.type).append(!object.ReferenceEquals((object) structField.type, (object) @class) ? new StringBuilder().append(" (native type ").append((object) @class).append(")").toString() : "").append(", which is not supported within a Structure").toString();
        IllegalArgumentException argumentException3 = argumentException2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str, (Exception) argumentException3);
      }
    }

    [LineNumberTable(new byte[] {162, 10, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setFieldValue([In] Field obj0, [In] object obj1) => this.setFieldValue(obj0, obj1, false);

    [Signature("()Ljava/util/List<Ljava/lang/String;>;")]
    protected internal abstract List getFieldOrder();

    [Signature("(Ljava/util/List<Ljava/lang/String;>;Ljava/util/List<Ljava/lang/String;>;)Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(new byte[] {163, 82, 120, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static List createFieldsOrder(List baseFields, List extraFields)
    {
      ArrayList.__\u003Cclinit\u003E();
      ArrayList arrayList = new ArrayList(baseFields.size() + extraFields.size());
      ((List) arrayList).addAll((Collection) baseFields);
      ((List) arrayList).addAll((Collection) extraFields);
      return java.util.Collections.unmodifiableList((List) arrayList);
    }

    [Signature("()Ljava/util/List<Ljava/lang/reflect/Field;>;")]
    [LineNumberTable(new byte[] {163, 44, 102, 103, 144, 102, 108, 105, 107, 114, 130, 235, 59, 232, 71, 233, 54, 236, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual List getFieldList()
    {
      ArrayList arrayList1 = new ArrayList();
      for (Class superclass = Object.instancehelper_getClass((object) this); !Object.instancehelper_equals((object) superclass, (object) ClassLiteral<Structure>.Value); superclass = superclass.getSuperclass())
      {
        ArrayList arrayList2 = new ArrayList();
        Field[] declaredFields = superclass.getDeclaredFields(Structure.__\u003CGetCallerID\u003E());
        for (int index = 0; index < declaredFields.Length; ++index)
        {
          int modifiers = declaredFields[index].getModifiers();
          if (!Modifier.isStatic(modifiers) && Modifier.isPublic(modifiers))
            ((List) arrayList2).add((object) declaredFields[index]);
        }
        ((List) arrayList1).addAll(0, (Collection) arrayList2);
      }
      return (List) arrayList1;
    }

    [Signature("()Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(new byte[] {163, 66, 103, 108, 113, 99, 103, 141, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private List fieldOrder()
    {
      Class @class = Object.instancehelper_getClass((object) this);
      List list;
      lock (Structure.fieldOrder)
      {
        List fieldOrder = (List) Structure.fieldOrder.get((object) @class);
        if (fieldOrder == null)
        {
          fieldOrder = this.getFieldOrder();
          Structure.fieldOrder.put((object) @class, (object) fieldOrder);
        }
        list = fieldOrder;
      }
      return list;
    }

    [Signature("<T::Ljava/lang/Comparable<TT;>;>(Ljava/util/Collection<+TT;>;)Ljava/util/List<TT;>;")]
    [LineNumberTable(new byte[] {163, 105, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static List sort([In] Collection obj0)
    {
      ArrayList arrayList = new ArrayList(obj0);
      java.util.Collections.sort((List) arrayList);
      return (List) arrayList;
    }

    [Signature("(Ljava/util/List<Ljava/lang/reflect/Field;>;Ljava/util/List<Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {163, 27, 110, 109, 107, 109, 110, 104, 226, 60, 6, 233, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void sortFields(List fields, List names)
    {
      for (int index1 = 0; index1 < names.size(); ++index1)
      {
        string str = (string) names.get(index1);
        for (int index2 = 0; index2 < fields.size(); ++index2)
        {
          Field field = (Field) fields.get(index2);
          if (String.instancehelper_equals(str, (object) field.getName()))
          {
            java.util.Collections.swap(fields, index1, index2);
            break;
          }
        }
      }
    }

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/Structure;)I")]
    [LineNumberTable(new byte[] {163, 185, 108, 113, 111, 117, 100, 99, 141, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int size([In] Class obj0, [In] Structure obj1)
    {
      Structure.LayoutInfo layoutInfo;
      lock (Structure.layoutInfo)
        layoutInfo = (Structure.LayoutInfo) Structure.layoutInfo.get((object) obj0);
      int num = layoutInfo == null || Structure.LayoutInfo.access\u0024000(layoutInfo) ? -1 : Structure.LayoutInfo.access\u0024100(layoutInfo);
      if (num == -1)
      {
        if (obj1 == null)
          obj1 = Structure.newInstance(obj0, Structure.PLACEHOLDER_MEMORY);
        num = obj1.size();
      }
      return num;
    }

    [LineNumberTable(new byte[] {158, 106, 164, 98, 104, 99, 162, 104, 110, 142, 99, 116, 110, 137, 105, 105, 137, 103, 110, 110, 105, 103, 113, 223, 26, 136, 105, 110, 169, 119, 113, 191, 5, 112, 108, 167, 173, 98, 110, 165, 111, 109, 99, 176, 130, 100, 110, 105, 105, 105, 105, 111, 101, 107, 111, 111, 104, 152, 116, 105, 105, 145, 104, 125, 205, 100, 209, 113, 255, 3, 73, 229, 57, 130, 107, 130, 127, 68, 207, 100, 159, 33, 118, 111, 147, 104, 104, 176, 104, 202, 150, 107, 117, 127, 0, 103, 234, 159, 139, 232, 160, 121, 100, 144, 107, 135, 106, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Structure.LayoutInfo deriveLayout([In] bool obj0, [In] bool obj1)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      int num3 = 0;
      List fields = this.getFields(num1 != 0);
      if (fields == null)
        return (Structure.LayoutInfo) null;
      Structure.LayoutInfo layoutInfo = new Structure.LayoutInfo((Structure.\u0031) null);
      Structure.LayoutInfo.access\u0024202(layoutInfo, this.alignType);
      Structure.LayoutInfo.access\u0024302(layoutInfo, this.typeMapper);
      int num4 = 1;
      Iterator iterator = fields.iterator();
      while (iterator.hasNext())
      {
        Field field = (Field) iterator.next();
        int modifiers = field.getModifiers();
        Class type = field.getType();
        if (type.isArray())
          Structure.LayoutInfo.access\u0024002(layoutInfo, true);
        Structure.StructField structField = new Structure.StructField();
        structField.isVolatile = Modifier.isVolatile(modifiers);
        structField.isReadOnly = Modifier.isFinal(modifiers);
        if (structField.isReadOnly)
        {
          if (!Platform.__\u003C\u003ERO_FIELDS)
          {
            string str = new StringBuilder().append("This VM does not support read-only fields (field '").append(field.getName()).append("' within ").append((object) Object.instancehelper_getClass((object) this)).append(")").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str);
          }
          ((AccessibleObject) field).setAccessible(true);
        }
        structField.field = field;
        structField.name = field.getName();
        structField.type = type;
        if (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(type) && !type.isInterface())
        {
          string str = new StringBuilder().append("Structure Callback field '").append(field.getName()).append("' must be an interface").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
        if (type.isArray() && Object.instancehelper_equals((object) ClassLiteral<Structure>.Value, (object) type.getComponentType()))
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Nested Structure arrays must use a derived Structure type so that the size of the elements can be determined");
        }
        if (Modifier.isPublic(field.getModifiers()))
        {
          object obj = this.getFieldValue(structField.field);
          if (obj == null && type.isArray())
          {
            if (num1 != 0)
            {
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalStateException("Array fields must be initialized");
            }
            return (Structure.LayoutInfo) null;
          }
          Class @class = type;
          if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(type))
          {
            NativeMappedConverter instance = NativeMappedConverter.getInstance(type);
            @class = instance.nativeType();
            structField.writeConverter = (ToNativeConverter) instance;
            structField.readConverter = (FromNativeConverter) instance;
            structField.context = (FromNativeContext) new StructureReadContext(this, field);
          }
          else if (this.typeMapper != null)
          {
            ToNativeConverter toNativeConverter = this.typeMapper.getToNativeConverter(type);
            FromNativeConverter fromNativeConverter = this.typeMapper.getFromNativeConverter(type);
            if (toNativeConverter != null && fromNativeConverter != null)
            {
              obj = toNativeConverter.toNative(obj, (ToNativeContext) new StructureWriteContext(this, structField.field));
              @class = obj == null ? (Class) ClassLiteral<Pointer>.Value : Object.instancehelper_getClass(obj);
              structField.writeConverter = toNativeConverter;
              structField.readConverter = fromNativeConverter;
              structField.context = (FromNativeContext) new StructureReadContext(this, field);
            }
            else if (toNativeConverter != null || fromNativeConverter != null)
            {
              string str = new StringBuilder().append("Structures require bidirectional type conversion for ").append((object) type).toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalArgumentException(str);
            }
          }
          if (obj == null)
            obj = this.initializeField(structField.field, type);
          int nativeAlignment;
          IllegalArgumentException argumentException1;
          try
          {
            structField.size = this.getNativeSize(@class, obj);
            nativeAlignment = this.getNativeAlignment(@class, obj, num4 != 0);
            goto label_33;
          }
          catch (IllegalArgumentException ex)
          {
            argumentException1 = (IllegalArgumentException) ByteCodeHelper.MapException<IllegalArgumentException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          IllegalArgumentException argumentException2 = argumentException1;
          if (num1 == 0 && this.typeMapper == null)
            return (Structure.LayoutInfo) null;
          string str1 = new StringBuilder().append("Invalid Structure field in ").append((object) Object.instancehelper_getClass((object) this)).append(", field name '").append(structField.name).append("' (").append((object) structField.type).append("): ").append(Throwable.instancehelper_getMessage((Exception) argumentException2)).toString();
          IllegalArgumentException argumentException3 = argumentException2;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str1, (Exception) argumentException3);
label_33:
          if (nativeAlignment == 0)
          {
            string str2 = new StringBuilder().append("Field alignment is zero for field '").append(structField.name).append("' within ").append((object) Object.instancehelper_getClass((object) this)).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new Error(str2);
          }
          Structure.LayoutInfo.access\u0024402(layoutInfo, Math.max(Structure.LayoutInfo.access\u0024400(layoutInfo), nativeAlignment));
          int num5 = num3;
          int num6 = nativeAlignment;
          if ((num6 != -1 ? num5 % num6 : 0) != 0)
          {
            int num7 = num3;
            int num8 = nativeAlignment;
            int num9 = num3;
            int num10 = nativeAlignment;
            int num11 = num10 != -1 ? num9 % num10 : 0;
            int num12 = num8 - num11;
            num3 = num7 + num12;
          }
          if (this is Union)
          {
            structField.offset = 0;
            num3 = Math.max(num3, structField.size);
          }
          else
          {
            structField.offset = num3;
            num3 += structField.size;
          }
          Structure.LayoutInfo.access\u0024500(layoutInfo).put((object) structField.name, (object) structField);
          if (Structure.LayoutInfo.access\u0024700(layoutInfo) == null || Structure.LayoutInfo.access\u0024700(layoutInfo).size < structField.size || Structure.LayoutInfo.access\u0024700(layoutInfo).size == structField.size && ((Class) ClassLiteral<Structure>.Value).isAssignableFrom(structField.type))
            Structure.LayoutInfo.access\u0024702(layoutInfo, structField);
        }
        num4 = 0;
      }
      if (num3 > 0)
      {
        int num5 = this.addPadding(num3, Structure.LayoutInfo.access\u0024400(layoutInfo));
        if (this is Structure.ByValue && num2 == 0)
          this.getTypeInfo();
        Structure.LayoutInfo.access\u0024102(layoutInfo, num5);
        return layoutInfo;
      }
      string str3 = new StringBuilder().append("Structure ").append((object) Object.instancehelper_getClass((object) this)).append(" has unknown or zero size (ensure all fields are public)").toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str3);
    }

    [Signature("(Ljava/lang/String;Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {163, 255, 104, 109, 99, 109, 161, 104, 210, 250, 69, 226, 61, 97, 127, 54, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void validateField([In] string obj0, [In] Class obj1)
    {
      if (this.typeMapper != null)
      {
        ToNativeConverter toNativeConverter = this.typeMapper.getToNativeConverter(obj1);
        if (toNativeConverter != null)
        {
          this.validateField(obj0, toNativeConverter.nativeType());
          return;
        }
      }
      if (obj1.isArray())
      {
        this.validateField(obj0, obj1.getComponentType());
      }
      else
      {
        IllegalArgumentException argumentException1;
        try
        {
          this.getNativeSize(obj1);
          return;
        }
        catch (IllegalArgumentException ex)
        {
          argumentException1 = (IllegalArgumentException) ByteCodeHelper.MapException<IllegalArgumentException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        IllegalArgumentException argumentException2 = argumentException1;
        string str = new StringBuilder().append("Invalid Structure field in ").append((object) Object.instancehelper_getClass((object) this)).append(", field name '").append(obj0).append("' (").append((object) obj1).append("): ").append(Throwable.instancehelper_getMessage((Exception) argumentException2)).toString();
        IllegalArgumentException argumentException3 = argumentException2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str, (Exception) argumentException3);
      }
    }

    [Signature("(Ljava/lang/Class<*>;)I")]
    [LineNumberTable(2115)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int getNativeSize(Class nativeType) => this.getNativeSize(nativeType, (object) null);

    [Signature("(Z)Ljava/util/List<Ljava/lang/reflect/Field;>;")]
    [LineNumberTable(new byte[] {158, 148, 66, 103, 102, 124, 110, 130, 104, 126, 102, 127, 7, 150, 117, 149, 191, 5, 162, 105, 106, 159, 7, 149, 191, 5, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual List getFields(bool force)
    {
      int num = force ? 1 : 0;
      List fieldList = this.getFieldList();
      HashSet hashSet = new HashSet();
      Iterator iterator = fieldList.iterator();
      while (iterator.hasNext())
      {
        Field field = (Field) iterator.next();
        ((Set) hashSet).add((object) field.getName());
      }
      List names = this.fieldOrder();
      if (names.size() != fieldList.size() && fieldList.size() > 1)
      {
        if (num != 0)
        {
          string str = new StringBuilder().append("Structure.getFieldOrder() on ").append((object) Object.instancehelper_getClass((object) this)).append(" does not provide enough names [").append(names.size()).append("] (").append((object) Structure.sort((Collection) names)).append(") to match declared fields [").append(fieldList.size()).append("] (").append((object) Structure.sort((Collection) hashSet)).append(")").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new Error(str);
        }
        return (List) null;
      }
      if (!((Set) new HashSet((Collection) names)).equals((object) hashSet))
      {
        string str = new StringBuilder().append("Structure.getFieldOrder() on ").append((object) Object.instancehelper_getClass((object) this)).append(" returns names (").append((object) Structure.sort((Collection) names)).append(") which do not match declared field names (").append((object) Structure.sort((Collection) hashSet)).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new Error(str);
      }
      this.sortFields(fieldList, names);
      return fieldList;
    }

    [Signature("(Ljava/lang/reflect/Field;Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {164, 201, 98, 115, 135, 108, 255, 0, 69, 226, 61, 97, 102, 173, 109, 104, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object initializeField([In] Field obj0, [In] Class obj1)
    {
      object obj = (object) null;
      if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj1))
      {
        if (!((Class) ClassLiteral<Structure.ByReference>.Value).isAssignableFrom(obj1))
        {
          IllegalArgumentException argumentException1;
          try
          {
            obj = (object) Structure.newInstance(obj1, Structure.PLACEHOLDER_MEMORY);
            this.setFieldValue(obj0, (object) (Structure) obj);
            goto label_7;
          }
          catch (IllegalArgumentException ex)
          {
            argumentException1 = (IllegalArgumentException) ByteCodeHelper.MapException<IllegalArgumentException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
          IllegalArgumentException argumentException2 = argumentException1;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException("Can't determine size of nested structure", (Exception) argumentException2);
        }
      }
      if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(obj1))
      {
        obj = (object) NativeMappedConverter.getInstance(obj1).defaultValue();
        this.setFieldValue(obj0, (object) (NativeMapped) obj);
      }
label_7:
      return obj;
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;)I")]
    [LineNumberTable(2125)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int getNativeSize(Class nativeType, object value) => Native.getNativeSize(nativeType, value);

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/Object;Z)I")]
    [LineNumberTable(new byte[] {158, 49, 66, 98, 109, 103, 104, 142, 104, 223, 84, 135, 127, 8, 109, 191, 2, 139, 109, 109, 168, 99, 109, 174, 104, 177, 191, 16, 105, 135, 105, 138, 169, 113, 140, 127, 5, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int getNativeAlignment(
      Class type,
      object value,
      bool isFirstElement)
    {
      int num1 = isFirstElement ? 1 : 0;
      if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(type))
      {
        NativeMappedConverter instance = NativeMappedConverter.getInstance(type);
        type = instance.nativeType();
        value = instance.toNative(value, new ToNativeContext());
      }
      int nativeSize = Native.getNativeSize(type, value);
      int num2;
      if (type.isPrimitive() || object.ReferenceEquals((object) ClassLiteral<Long>.Value, (object) type) || (object.ReferenceEquals((object) ClassLiteral<Integer>.Value, (object) type) || object.ReferenceEquals((object) ClassLiteral<Short>.Value, (object) type)) || (object.ReferenceEquals((object) ClassLiteral<Character>.Value, (object) type) || object.ReferenceEquals((object) ClassLiteral<Byte>.Value, (object) type) || (object.ReferenceEquals((object) ClassLiteral<Boolean>.Value, (object) type) || object.ReferenceEquals((object) ClassLiteral<Float>.Value, (object) type))) || object.ReferenceEquals((object) ClassLiteral<Double>.Value, (object) type))
        num2 = nativeSize;
      else if (((Class) ClassLiteral<Pointer>.Value).isAssignableFrom(type) && !((Class) ClassLiteral<Function>.Value).isAssignableFrom(type) || Platform.__\u003C\u003EHAS_BUFFERS && ((Class) ClassLiteral<Buffer>.Value).isAssignableFrom(type) || (((Class) ClassLiteral<Callback>.Value).isAssignableFrom(type) || object.ReferenceEquals((object) ClassLiteral<WString>.Value, (object) type) || object.ReferenceEquals((object) ClassLiteral<String>.Value, (object) type)))
        num2 = Pointer.__\u003C\u003ESIZE;
      else if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(type))
      {
        if (((Class) ClassLiteral<Structure.ByReference>.Value).isAssignableFrom(type))
        {
          num2 = Pointer.__\u003C\u003ESIZE;
        }
        else
        {
          if (value == null)
            value = (object) Structure.newInstance(type, Structure.PLACEHOLDER_MEMORY);
          num2 = ((Structure) value).getStructAlignment();
        }
      }
      else if (type.isArray())
      {
        num2 = this.getNativeAlignment(type.getComponentType(), (object) null, num1 != 0);
      }
      else
      {
        string str = new StringBuilder().append("Type ").append((object) type).append(" has unknown native alignment").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (this.actualAlignType == 1)
        num2 = 1;
      else if (this.actualAlignType == 3)
        num2 = Math.min(8, num2);
      else if (this.actualAlignType == 2)
      {
        if (num1 == 0 || !Platform.isMac() || !Platform.isPPC())
          num2 = Math.min(Native.MAX_ALIGNMENT, num2);
        if (num1 == 0 && Platform.isAIX() && (object.ReferenceEquals((object) type, (object) Double.TYPE) || object.ReferenceEquals((object) type, (object) ClassLiteral<Double>.Value)))
          num2 = 4;
      }
      return num2;
    }

    [LineNumberTable(new byte[] {164, 228, 105, 110, 178})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int addPadding([In] int obj0, [In] int obj1)
    {
      if (this.actualAlignType != 1)
      {
        int num1 = obj0;
        int num2 = obj1;
        if ((num2 != -1 ? num1 % num2 : 0) != 0)
        {
          int num3 = obj0;
          int num4 = obj1;
          int num5 = obj0;
          int num6 = obj1;
          int num7 = num6 != -1 ? num5 % num6 : 0;
          int num8 = num4 - num7;
          obj0 = num3 + num8;
        }
      }
      return obj0;
    }

    [LineNumberTable(new byte[] {164, 240, 137, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int getStructAlignment()
    {
      if (this.size == -1)
        this.calculateSize(true);
      return this.structAlignment;
    }

    [LineNumberTable(1468)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString(bool debug) => this.toString(0, true, debug);

    [LineNumberTable(new byte[] {158, 29, 132, 102, 107, 127, 28, 109, 159, 17, 103, 104, 61, 168, 99, 99, 140, 126, 110, 111, 111, 103, 122, 114, 116, 159, 13, 127, 44, 113, 105, 159, 0, 125, 105, 159, 15, 105, 159, 15, 105, 159, 12, 105, 191, 13, 159, 5, 121, 105, 127, 5, 101, 108, 98, 127, 10, 117, 109, 127, 13, 113, 125, 127, 3, 121, 255, 4, 58, 235, 72, 157})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string toString([In] int obj0, [In] bool obj1, [In] bool obj2)
    {
      int num1 = obj1 ? 1 : 0;
      int num2 = obj2 ? 1 : 0;
      this.ensureAllocated();
      string property = java.lang.System.getProperty("line.separator");
      string str1 = new StringBuilder().append(this.format(Object.instancehelper_getClass((object) this))).append("(").append((object) this.getPointer()).append(")").toString();
      if (!(this.getPointer() is Memory))
        str1 = new StringBuilder().append(str1).append(" (").append(this.size()).append(" bytes)").toString();
      string str2 = "";
      for (int index = 0; index < obj0; ++index)
        str2 = new StringBuilder().append(str2).append("  ").toString();
      string str3 = property;
      if (num1 == 0)
      {
        str3 = "...}";
      }
      else
      {
        Iterator iterator = this.fields().values().iterator();
        while (iterator.hasNext())
        {
          Structure.StructField structField = (Structure.StructField) iterator.next();
          object fieldValue = this.getFieldValue(structField.field);
          string str4 = this.format(structField.type);
          string str5 = "";
          string str6 = new StringBuilder().append(str3).append(str2).toString();
          if (structField.type.isArray() && fieldValue != null)
          {
            str4 = this.format(structField.type.getComponentType());
            str5 = new StringBuilder().append("[").append(Array.getLength(fieldValue)).append("]").toString();
          }
          string str7 = new StringBuilder().append(str6).append("  ").append(str4).append(" ").append(structField.name).append(str5).append("@").append(Integer.toHexString(structField.offset)).toString();
          if (fieldValue is Structure)
            fieldValue = (object) ((Structure) fieldValue).toString(obj0 + 1, !(fieldValue is Structure.ByReference), num2 != 0);
          string str8 = new StringBuilder().append(str7).append("=").toString();
          str3 = new StringBuilder().append(!(fieldValue is Long) ? (!(fieldValue is Integer) ? (!(fieldValue is Short) ? (!(fieldValue is Byte) ? new StringBuilder().append(str8).append(String.instancehelper_trim(String.valueOf(fieldValue))).toString() : new StringBuilder().append(str8).append(Integer.toHexString((int) (sbyte) ((Byte) fieldValue).byteValue())).toString()) : new StringBuilder().append(str8).append(Integer.toHexString((int) ((Short) fieldValue).shortValue())).toString()) : new StringBuilder().append(str8).append(Integer.toHexString(((Integer) fieldValue).intValue())).toString()) : new StringBuilder().append(str8).append(Long.toHexString(((Long) fieldValue).longValue())).toString()).append(property).toString();
          if (!iterator.hasNext())
            str3 = new StringBuilder().append(str3).append(str2).append("}").toString();
        }
      }
      if (obj0 == 0 && num2 != 0)
      {
        string str4 = new StringBuilder().append(str3).append(property).append("memory dump").append(property).toString();
        byte[] byteArray = this.getPointer().getByteArray(0L, this.size());
        for (int index = 0; index < byteArray.Length; ++index)
        {
          int num3 = index;
          int num4 = 4;
          if ((num4 != -1 ? num3 % num4 : 0) == 0)
            str4 = new StringBuilder().append(str4).append("[").toString();
          if ((sbyte) byteArray[index] >= (sbyte) 0 && (sbyte) byteArray[index] < (sbyte) 16)
            str4 = new StringBuilder().append(str4).append("0").toString();
          str4 = new StringBuilder().append(str4).append(Integer.toHexString((int) byteArray[index])).toString();
          int num5 = index;
          int num6 = 4;
          if ((num6 != -1 ? num5 % num6 : 0) == 3 && index < byteArray.Length - 1)
            str4 = new StringBuilder().append(str4).append("]").append(property).toString();
        }
        str3 = new StringBuilder().append(str4).append("]").toString();
      }
      return new StringBuilder().append(str1).append(" {").append(str3).toString();
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {165, 78, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string format([In] Class obj0)
    {
      string name = obj0.getName();
      int num = String.instancehelper_lastIndexOf(name, ".");
      return String.instancehelper_substring(name, num + 1);
    }

    [LineNumberTable(new byte[] {160, 183, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void useMemory(Pointer m) => this.useMemory(m, 0);

    [LineNumberTable(new byte[] {165, 159, 102, 141, 108, 106, 106, 205, 100, 103, 103, 127, 0, 8, 230, 69, 136, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Structure[] toArray(Structure[] array)
    {
      this.ensureAllocated();
      if (this.memory is Structure.AutoAllocated)
      {
        Memory memory = (Memory) this.memory;
        int size = array.Length * this.size();
        if (memory.size() < (long) size)
          this.useMemory((Pointer) this.autoAllocate(size));
      }
      array[0] = this;
      int num = this.size();
      for (int index = 1; index < array.Length; ++index)
      {
        array[index] = Structure.newInstance(Object.instancehelper_getClass((object) this), this.memory.share((long) (index * num), (long) num));
        array[index].conditionalAutoRead();
      }
      if (!(this is Structure.ByValue))
        this.array = array;
      return array;
    }

    [LineNumberTable(new byte[] {157, 250, 66, 99, 114, 102, 114, 134, 116, 116, 102, 103, 104, 2, 230, 69, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dataEquals(Structure s, bool clear)
    {
      if (clear)
      {
        s.getPointer().clear((long) s.size());
        s.write();
        this.getPointer().clear((long) this.size());
        this.write();
      }
      byte[] byteArray1 = s.getPointer().getByteArray(0L, s.size());
      byte[] byteArray2 = this.getPointer().getByteArray(0L, this.size());
      if (byteArray1.Length != byteArray2.Length)
        return false;
      for (int index = 0; index < byteArray1.Length; ++index)
      {
        if ((int) (sbyte) byteArray1[index] != (int) (sbyte) byteArray2[index])
          return false;
      }
      return true;
    }

    [LineNumberTable(new byte[] {162, 119, 114, 225, 70, 166, 104, 199, 109, 129, 172, 127, 6, 104, 135, 164, 79, 98, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write()
    {
      if (object.ReferenceEquals((object) this.memory, (object) Structure.PLACEHOLDER_MEMORY))
        return;
      this.ensureAllocated();
      if (this is Structure.ByValue)
        this.getTypeInfo();
      if (Structure.busy().contains((object) this))
        return;
      Structure.busy().add((object) this);
      try
      {
        Iterator iterator = this.fields().values().iterator();
        while (iterator.hasNext())
        {
          Structure.StructField structField = (Structure.StructField) iterator.next();
          if (!structField.isVolatile)
            this.writeField(structField);
        }
      }
      finally
      {
        Structure.busy().remove((object) this);
      }
    }

    [LineNumberTable(1752)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Pointer getTypeInfo([In] object obj0) => Structure.FFIType.get(obj0);

    [LineNumberTable(new byte[] {166, 11, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void cacheTypeInfo(Pointer p) => this.typeInfo = p.peer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAutoRead(bool auto) => this.autoRead = auto;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAutoWrite(bool auto) => this.autoWrite = auto;

    [Throws(new string[] {"java.lang.IllegalArgumentException"})]
    [Signature("(Ljava/lang/Class<*>;)Lcom/sun/jna/Structure;")]
    [LineNumberTable(new byte[] {166, 168, 113, 104, 134, 159, 4, 98, 124, 143, 98, 159, 7})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Structure newInstance(Class type)
    {
      Structure structure1;
      InstantiationException instantiationException1;
      IllegalAccessException illegalAccessException1;
      try
      {
        try
        {
          Structure structure2 = (Structure) type.newInstance(Structure.__\u003CGetCallerID\u003E());
          if (structure2 is Structure.ByValue)
            structure2.allocateMemory();
          structure1 = structure2;
        }
        catch (InstantiationException ex)
        {
          instantiationException1 = (InstantiationException) ByteCodeHelper.MapException<InstantiationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_6;
        }
      }
      catch (IllegalAccessException ex)
      {
        illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_7;
      }
      return structure1;
label_6:
      InstantiationException instantiationException2 = instantiationException1;
      string str1 = new StringBuilder().append("Can't instantiate ").append((object) type).toString();
      InstantiationException instantiationException3 = instantiationException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str1, (Exception) instantiationException3);
label_7:
      IllegalAccessException illegalAccessException2 = illegalAccessException1;
      string str2 = new StringBuilder().append("Instantiation of ").append((object) type).append(" not allowed, is it public?").toString();
      IllegalAccessException illegalAccessException3 = illegalAccessException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str2, (Exception) illegalAccessException3);
    }

    [LineNumberTable(new byte[] {161, 16, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void allocateMemory() => this.allocateMemory(false);

    [LineNumberTable(new byte[] {167, 139, 114, 129, 105, 105, 103, 122, 159, 6, 236, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void structureArrayCheck([In] Structure[] obj0)
    {
      if (((Class) ClassLiteral<Structure.ByReference[]>.Value).isAssignableFrom(Object.instancehelper_getClass((object) obj0)))
        return;
      Pointer pointer = obj0[0].getPointer();
      int num = obj0[0].size();
      for (int index = 1; index < obj0.Length; ++index)
      {
        if (obj0[index].getPointer().peer != pointer.peer + (long) (num * index))
        {
          string str = new StringBuilder().append("Structure array elements must use contiguous memory (bad backing address at Structure array index ").append(index).append(")").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getAutoRead() => this.autoRead;

    [LineNumberTable(new byte[] {161, 189, 114, 129, 231, 70, 166, 109, 129, 108, 104, 178, 127, 6, 104, 164, 108, 120, 20, 108, 120, 179})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void read()
    {
      if (object.ReferenceEquals((object) this.memory, (object) Structure.PLACEHOLDER_MEMORY))
        return;
      this.readCalled = true;
      this.ensureAllocated();
      if (Structure.busy().contains((object) this))
        return;
      Structure.busy().add((object) this);
      if (this is Structure.ByReference)
        Structure.reading().put((object) this.getPointer(), (object) this);
      // ISSUE: fault handler
      try
      {
        Iterator iterator = this.fields().values().iterator();
        while (iterator.hasNext())
          this.readField((Structure.StructField) iterator.next());
      }
      __fault
      {
        Structure.busy().remove((object) this);
        if (object.ReferenceEquals(Structure.reading().get((object) this.getPointer()), (object) this))
          Structure.reading().remove((object) this.getPointer());
      }
      Structure.busy().remove((object) this);
      if (!object.ReferenceEquals(Structure.reading().get((object) this.getPointer()), (object) this))
        return;
      Structure.reading().remove((object) this.getPointer());
    }

    [LineNumberTable(new byte[] {167, 193, 104, 102, 104, 108, 45, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void autoWrite()
    {
      if (!this.getAutoWrite())
        return;
      this.write();
      if (this.array == null)
        return;
      for (int index = 1; index < this.array.Length; ++index)
        this.array[index].autoWrite();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getAutoWrite() => this.autoWrite;

    [LineNumberTable(new byte[] {111, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Structure()
      : this(0)
    {
    }

    [LineNumberTable(new byte[] {115, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Structure(TypeMapper mapper)
      : this((Pointer) null, 0, mapper)
    {
    }

    [LineNumberTable(new byte[] {123, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Structure(int alignType, TypeMapper mapper)
      : this((Pointer) null, alignType, mapper)
    {
    }

    [LineNumberTable(new byte[] {160, 64, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Structure(Pointer p)
      : this(p, 0)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual TypeMapper getTypeMapper() => this.typeMapper;

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string getStringEncoding() => this.encoding;

    [LineNumberTable(new byte[] {161, 59, 102, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.ensureAllocated();
      this.memory.clear((long) this.size());
    }

    [LineNumberTable(new byte[] {161, 226, 102, 114, 99, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int fieldOffset(string name)
    {
      this.ensureAllocated();
      Structure.StructField structField = (Structure.StructField) this.fields().get((object) name);
      if (structField == null)
      {
        string str = new StringBuilder().append("No such field: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return structField.offset;
    }

    [LineNumberTable(new byte[] {161, 240, 102, 114, 99, 127, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object readField(string name)
    {
      this.ensureAllocated();
      Structure.StructField structField = (Structure.StructField) this.fields().get((object) name);
      if (structField == null)
      {
        string str = new StringBuilder().append("No such field: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return this.readField(structField);
    }

    [Signature("(Ljava/lang/Class<*>;Lcom/sun/jna/Structure;Lcom/sun/jna/Pointer;)Lcom/sun/jna/Structure;")]
    [LineNumberTable(new byte[] {162, 40, 99, 165, 113, 113, 113, 99, 168, 105, 134, 130, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Structure updateStructureByReference(
      [In] Class obj0,
      [In] Structure obj1,
      [In] Pointer obj2)
    {
      if (obj2 == null)
        obj1 = (Structure) null;
      else if (obj1 == null || !obj2.equals((object) obj1.getPointer()))
      {
        Structure structure = (Structure) Structure.reading().get((object) obj2);
        if (structure != null && Object.instancehelper_equals((object) obj0, (object) Object.instancehelper_getClass((object) structure)))
        {
          obj1 = structure;
          obj1.autoRead();
        }
        else
        {
          obj1 = Structure.newInstance(obj0, obj2);
          obj1.conditionalAutoRead();
        }
      }
      else
        obj1.autoRead();
      return obj1;
    }

    [LineNumberTable(new byte[] {162, 157, 102, 114, 99, 127, 6, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeField(string name)
    {
      this.ensureAllocated();
      Structure.StructField structField = (Structure.StructField) this.fields().get((object) name);
      if (structField == null)
      {
        string str = new StringBuilder().append("No such field: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.writeField(structField);
    }

    [LineNumberTable(new byte[] {162, 172, 102, 114, 99, 127, 6, 109, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeField(string name, object value)
    {
      this.ensureAllocated();
      Structure.StructField structField = (Structure.StructField) this.fields().get((object) name);
      if (structField == null)
      {
        string str = new StringBuilder().append("No such field: ").append(name).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      this.setFieldValue(structField.field, value);
      this.writeField(structField);
    }

    [Obsolete]
    [LineNumberTable(901)]
    [Deprecated(new object[] {64, "Ljava/lang/Deprecated;"})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal void setFieldOrder(string[] fields)
    {
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new Error("This method is obsolete, use getFieldOrder() instead");
    }

    [Signature("(Ljava/util/List<Ljava/lang/String;>;[Ljava/lang/String;)Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(960)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static List createFieldsOrder(List baseFields, params string[] extraFields) => Structure.createFieldsOrder(baseFields, Arrays.asList((object[]) extraFields));

    [Signature("(Ljava/lang/String;)Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(975)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static List createFieldsOrder(string field) => java.util.Collections.unmodifiableList(java.util.Collections.singletonList((object) field));

    [Signature("([Ljava/lang/String;)Ljava/util/List<Ljava/lang/String;>;")]
    [LineNumberTable(983)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static List createFieldsOrder(params string[] fields) => java.util.Collections.unmodifiableList(Arrays.asList((object[]) fields));

    [Signature("(Ljava/lang/Class<*>;)I")]
    [LineNumberTable(1057)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int size([In] Class obj0) => Structure.size(obj0, (Structure) null);

    [LineNumberTable(1360)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int addPadding([In] int obj0) => this.addPadding(obj0, this.structAlignment);

    [LineNumberTable(1459)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => this.toString(Boolean.getBoolean("jna.dump_memory"));

    [LineNumberTable(1588)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Structure[] toArray(int size) => this.toArray((Structure[]) Array.newInstance(Object.instancehelper_getClass((object) this), size));

    [Signature("()Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {165, 198, 150, 113, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Class baseClass()
    {
      switch (this)
      {
        case Structure.ByReference _:
        case Structure.ByValue _:
          if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(Object.instancehelper_getClass((object) this).getSuperclass()))
            return Object.instancehelper_getClass((object) this).getSuperclass();
          break;
      }
      return Object.instancehelper_getClass((object) this);
    }

    [LineNumberTable(1606)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool dataEquals(Structure s) => this.dataEquals(s, false);

    [LineNumberTable(new byte[] {165, 246, 105, 120, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object o) => o is Structure && object.ReferenceEquals((object) o.GetType(), (object) ((object) this).GetType()) && ((Structure) o).getPointer().equals((object) this.getPointer());

    [LineNumberTable(new byte[] {166, 0, 103, 99, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => this.getPointer() != null ? this.getPointer().hashCode() : Object.instancehelper_hashCode((object) Object.instancehelper_getClass((object) this));

    [LineNumberTable(new byte[] {166, 19, 103, 109, 104, 109, 99, 103, 173})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Pointer getFieldTypeInfo([In] Structure.StructField obj0)
    {
      Class c = obj0.type;
      object obj = this.getFieldValue(obj0.field);
      if (this.typeMapper != null)
      {
        ToNativeConverter toNativeConverter = this.typeMapper.getToNativeConverter(c);
        if (toNativeConverter != null)
        {
          c = toNativeConverter.nativeType();
          obj = toNativeConverter.toNative(obj, new ToNativeContext());
        }
      }
      return Structure.FFIType.access\u0024800(obj, c);
    }

    [LineNumberTable(new byte[] {157, 227, 162, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAutoSynch(bool auto)
    {
      int num = auto ? 1 : 0;
      this.setAutoRead(num != 0);
      this.setAutoWrite(num != 0);
    }

    [Signature("(Ljava/lang/Class<*>;J)Lcom/sun/jna/Structure;")]
    [LineNumberTable(new byte[] {166, 111, 125, 105, 134, 151, 97, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Structure newInstance([In] Class obj0, [In] long obj1)
    {
      Structure structure1;
      Exception exception1;
      try
      {
        Structure structure2 = Structure.newInstance(obj0, obj1 != 0L ? new Pointer(obj1) : Structure.PLACEHOLDER_MEMORY);
        if (obj1 != 0L)
          structure2.conditionalAutoRead();
        structure1 = structure2;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_5;
      }
      return structure1;
label_5:
      Exception exception2 = exception1;
      java.lang.System.err.println(new StringBuilder().append("JNA: Error creating structure: ").append((object) exception2).toString());
      return (Structure) null;
    }

    [LineNumberTable(new byte[] {166, 191, 108, 118, 111, 99, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Structure.StructField typeInfoField()
    {
      Structure.LayoutInfo layoutInfo;
      lock (Structure.layoutInfo)
        layoutInfo = (Structure.LayoutInfo) Structure.layoutInfo.get((object) Object.instancehelper_getClass((object) this));
      return layoutInfo != null ? Structure.LayoutInfo.access\u0024700(layoutInfo) : (Structure.StructField) null;
    }

    [LineNumberTable(new byte[] {167, 154, 102, 112, 170, 103, 101, 8, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void autoRead(Structure[] ss)
    {
      Structure.structureArrayCheck(ss);
      if (object.ReferenceEquals((object) ss[0].array, (object) ss))
      {
        ss[0].autoRead();
      }
      else
      {
        for (int index = 0; index < ss.Length; ++index)
        {
          if (ss[index] != null)
            ss[index].autoRead();
        }
      }
    }

    [LineNumberTable(new byte[] {167, 179, 102, 112, 170, 103, 101, 8, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void autoWrite(Structure[] ss)
    {
      Structure.structureArrayCheck(ss);
      if (object.ReferenceEquals((object) ss[0].array, (object) ss))
      {
        ss[0].autoWrite();
      }
      else
      {
        for (int index = 0; index < ss.Length; ++index)
        {
          if (ss[index] != null)
            ss[index].autoWrite();
        }
      }
    }

    [Signature("(Ljava/lang/Class<*>;)V")]
    [LineNumberTable(new byte[] {167, 234, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void validate([In] Class obj0) => Structure.newInstance(obj0, Structure.PLACEHOLDER_MEMORY);

    [Modifiers]
    [LineNumberTable(103)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void access\u00241900([In] Structure obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      obj0.ensureAllocated(num != 0);
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static Pointer access\u00242000() => Structure.PLACEHOLDER_MEMORY;

    [LineNumberTable(new byte[] {159, 108, 77, 106, 234, 161, 61, 234, 73, 234, 166, 132})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Structure()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.Structure"))
        return;
      Structure.layoutInfo = (Map) new WeakHashMap();
      Structure.fieldOrder = (Map) new WeakHashMap();
      Structure.reads = (ThreadLocal) new Structure.\u0031();
      Structure.busy = (ThreadLocal) new Structure.\u0032();
      Structure.PLACEHOLDER_MEMORY = (Pointer) new Structure.\u0033(0L);
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Structure.__\u003CcallerID\u003E == null)
        Structure.__\u003CcallerID\u003E = (CallerID) new Structure.__\u003CCallerID\u003E();
      return Structure.__\u003CcallerID\u003E;
    }

    [Signature("Ljava/lang/ThreadLocal<Ljava/util/Map<Lcom/sun/jna/Pointer;Lcom/sun/jna/Structure;>;>;")]
    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal sealed class \u0031 : ThreadLocal
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(454)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
      }

      [Signature("()Ljava/util/Map<Lcom/sun/jna/Pointer;Lcom/sun/jna/Structure;>;")]
      [LineNumberTable(457)]
      [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
      protected internal virtual Map initialValue() => (Map) new HashMap();

      [Modifiers]
      [LineNumberTable(454)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual object initialValue() => (object) this.initialValue();

      [HideFromJava]
      static \u0031() => ThreadLocal.__\u003Cclinit\u003E();
    }

    [Signature("Ljava/lang/ThreadLocal<Ljava/util/Set<Lcom/sun/jna/Structure;>;>;")]
    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal sealed class \u0032 : ThreadLocal
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(463)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032()
      {
      }

      [Signature("()Ljava/util/Set<Lcom/sun/jna/Structure;>;")]
      [LineNumberTable(466)]
      [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
      protected internal virtual Set initialValue() => (Set) new Structure.StructureSet();

      [Modifiers]
      [LineNumberTable(463)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal virtual object initialValue() => (object) this.initialValue();

      [HideFromJava]
      static \u0032() => ThreadLocal.__\u003Cclinit\u003E();
    }

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal sealed class \u0033 : Pointer
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(2131)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] long obj0)
        : base(obj0)
      {
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Pointer share([In] long obj0, [In] long obj1) => (Pointer) this;

      [HideFromJava]
      static \u0033() => Pointer.__\u003Cclinit\u003E();
    }

    [InnerClass]
    internal class AutoAllocated : Memory
    {
      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {167, 128, 138, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public AutoAllocated([In] int obj0)
        : base((long) obj0)
      {
        Structure.AutoAllocated autoAllocated = this;
        this.clear();
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(2040)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override string toString() => new StringBuilder().append("auto-").append(base.toString()).toString();

      [HideFromJava]
      static AutoAllocated() => Memory.__\u003Cclinit\u003E();
    }

    public interface ByReference
    {
    }

    public interface ByValue
    {
    }

    [NonNestedInnerClass("com.sun.jna.Structure$FFIType$size_t")]
    internal class FFIType : Structure
    {
      [Modifiers]
      [Signature("Ljava/util/Map<Ljava/lang/Object;Ljava/lang/Object;>;")]
      private static Map typeInfoMap;
      private const int FFI_TYPE_STRUCT = 13;
      public Structure\u0024FFIType\u0024size_t size;
      public short alignment;
      public short type;
      public Pointer elements;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [LineNumberTable(1870)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static Pointer access\u0024800([In] object obj0, [In] Class obj1) => Structure.FFIType.get(obj0, obj1);

      [LineNumberTable(new byte[] {167, 73, 99, 102, 104, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static Pointer get([In] object obj0)
      {
        if (obj0 == null)
          return Structure.FFIType.FFITypes.access\u00241800();
        return obj0 is Class ? Structure.FFIType.get((object) null, (Class) obj0) : Structure.FFIType.get(obj0, Object.instancehelper_getClass(obj0));
      }

      [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)Lcom/sun/jna/Pointer;")]
      [LineNumberTable(new byte[] {167, 81, 103, 99, 104, 99, 168, 108, 108, 104, 147, 104, 152, 122, 103, 113, 146, 112, 112, 109, 113, 146, 109, 110, 148, 109, 104, 159, 7, 104, 137, 110, 145, 127, 45})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static Pointer get([In] object obj0, [In] Class obj1)
      {
        TypeMapper typeMapper = Native.getTypeMapper(obj1);
        if (typeMapper != null)
        {
          ToNativeConverter toNativeConverter = typeMapper.getToNativeConverter(obj1);
          if (toNativeConverter != null)
            obj1 = toNativeConverter.nativeType();
        }
        Map typeInfoMap;
        Monitor.Enter((object) (typeInfoMap = Structure.FFIType.typeInfoMap));
        Exception exception1;
        try
        {
          object obj = Structure.FFIType.typeInfoMap.get((object) obj1);
          if (obj is Pointer)
          {
            Pointer pointer = (Pointer) obj;
            Monitor.Exit((object) typeInfoMap);
            return pointer;
          }
          if (obj is Structure.FFIType)
          {
            Pointer pointer = ((Structure) obj).getPointer();
            Monitor.Exit((object) typeInfoMap);
            return pointer;
          }
          if (Platform.__\u003C\u003EHAS_BUFFERS && ((Class) ClassLiteral<Buffer>.Value).isAssignableFrom(obj1) || ((Class) ClassLiteral<Callback>.Value).isAssignableFrom(obj1))
          {
            Structure.FFIType.typeInfoMap.put((object) obj1, (object) Structure.FFIType.FFITypes.access\u00241800());
            Pointer pointer = Structure.FFIType.FFITypes.access\u00241800();
            Monitor.Exit((object) typeInfoMap);
            return pointer;
          }
          if (((Class) ClassLiteral<Structure>.Value).isAssignableFrom(obj1))
          {
            if (obj0 == null)
              obj0 = (object) Structure.newInstance(obj1, Structure.access\u00242000());
            if (((Class) ClassLiteral<Structure.ByReference>.Value).isAssignableFrom(obj1))
            {
              Structure.FFIType.typeInfoMap.put((object) obj1, (object) Structure.FFIType.FFITypes.access\u00241800());
              Pointer pointer = Structure.FFIType.FFITypes.access\u00241800();
              Monitor.Exit((object) typeInfoMap);
              return pointer;
            }
            Structure.FFIType ffiType = new Structure.FFIType((Structure) obj0);
            Structure.FFIType.typeInfoMap.put((object) obj1, (object) ffiType);
            Pointer pointer1 = ffiType.getPointer();
            Monitor.Exit((object) typeInfoMap);
            return pointer1;
          }
          if (((Class) ClassLiteral<NativeMapped>.Value).isAssignableFrom(obj1))
          {
            NativeMappedConverter instance = NativeMappedConverter.getInstance(obj1);
            Pointer pointer = Structure.FFIType.get(instance.toNative(obj0, new ToNativeContext()), instance.nativeType());
            Monitor.Exit((object) typeInfoMap);
            return pointer;
          }
          if (obj1.isArray())
          {
            Structure.FFIType ffiType = new Structure.FFIType(obj0, obj1);
            Structure.FFIType.typeInfoMap.put(obj0, (object) ffiType);
            Pointer pointer = ffiType.getPointer();
            Monitor.Exit((object) typeInfoMap);
            return pointer;
          }
          string str = new StringBuilder().append("Unsupported type ").append((object) obj1).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception exception2 = exception1;
        Exception exception3;
        while (true)
        {
          Exception exception4 = exception2;
          Exception exception5;
          try
          {
            exception3 = exception4;
            Monitor.Exit((object) typeInfoMap);
            break;
          }
          catch (Exception ex)
          {
            exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          exception2 = exception5;
        }
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }

      [LineNumberTable(new byte[] {167, 66, 121, 113, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void init([In] Pointer[] obj0)
      {
        Memory.__\u003Cclinit\u003E();
        this.elements = (Pointer) new Memory((long) (Pointer.__\u003C\u003ESIZE * obj0.Length));
        this.elements.write(0L, obj0, 0, obj0.Length);
        this.write();
      }

      [LineNumberTable(new byte[] {167, 30, 232, 61, 232, 69, 135, 104, 108, 111, 182, 130, 115, 98, 127, 10, 111, 130, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private FFIType([In] Structure obj0)
      {
        Structure.FFIType ffiType = this;
        this.type = (short) 13;
        Structure.access\u00241900(obj0, true);
        Pointer[] pointerArray1;
        if (obj0 is Union)
        {
          Structure.StructField structField = obj0.typeInfoField();
          pointerArray1 = new Pointer[2]
          {
            Structure.FFIType.get(obj0.getFieldValue(structField.field), structField.type),
            (Pointer) null
          };
        }
        else
        {
          pointerArray1 = new Pointer[obj0.fields().size() + 1];
          int num = 0;
          Iterator iterator = obj0.fields().values().iterator();
          while (iterator.hasNext())
          {
            Structure.StructField structField = (Structure.StructField) iterator.next();
            Pointer[] pointerArray2 = pointerArray1;
            int index = num;
            ++num;
            Pointer fieldTypeInfo = obj0.getFieldTypeInfo(structField);
            pointerArray2[index] = fieldTypeInfo;
          }
        }
        this.init(pointerArray1);
      }

      [Signature("(Ljava/lang/Object;Ljava/lang/Class<*>;)V")]
      [LineNumberTable(new byte[] {167, 51, 232, 40, 232, 89, 103, 105, 109, 104, 37, 168, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private FFIType([In] object obj0, [In] Class obj1)
      {
        Structure.FFIType ffiType = this;
        this.type = (short) 13;
        int length = Array.getLength(obj0);
        Pointer[] pointerArray = new Pointer[length + 1];
        Pointer pointer = Structure.FFIType.get((object) null, obj1.getComponentType());
        for (int index = 0; index < length; ++index)
          pointerArray[index] = pointer;
        this.init(pointerArray);
      }

      [Signature("()Ljava/util/List<Ljava/lang/String;>;")]
      [LineNumberTable(1969)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal override List getFieldOrder() => Arrays.asList((object[]) new string[4]
      {
        "size",
        "alignment",
        "type",
        "elements"
      });

      [LineNumberTable(new byte[] {157, 185, 146, 234, 86, 103, 112, 103, 112, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 117, 104, 109, 113, 113, 117, 117, 117, 117, 117, 117, 117})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static FFIType()
      {
        Structure.__\u003Cclinit\u003E();
        if (ByteCodeHelper.isAlreadyInited("com.sun.jna.Structure$FFIType"))
          return;
        Structure.FFIType.typeInfoMap = (Map) new WeakHashMap();
        if (Native.__\u003C\u003EPOINTER_SIZE == 0)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new Error("Native library not initialized");
        }
        if (Structure.FFIType.FFITypes.access\u0024900() == null)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new Error("FFI types not initialized");
        }
        Structure.FFIType.typeInfoMap.put((object) Void.TYPE, (object) Structure.FFIType.FFITypes.access\u0024900());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Void>.Value, (object) Structure.FFIType.FFITypes.access\u0024900());
        Structure.FFIType.typeInfoMap.put((object) Float.TYPE, (object) Structure.FFIType.FFITypes.access\u00241000());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Float>.Value, (object) Structure.FFIType.FFITypes.access\u00241000());
        Structure.FFIType.typeInfoMap.put((object) Double.TYPE, (object) Structure.FFIType.FFITypes.access\u00241100());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Double>.Value, (object) Structure.FFIType.FFITypes.access\u00241100());
        Structure.FFIType.typeInfoMap.put((object) Long.TYPE, (object) Structure.FFIType.FFITypes.access\u00241200());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Long>.Value, (object) Structure.FFIType.FFITypes.access\u00241200());
        Structure.FFIType.typeInfoMap.put((object) Integer.TYPE, (object) Structure.FFIType.FFITypes.access\u00241300());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Integer>.Value, (object) Structure.FFIType.FFITypes.access\u00241300());
        Structure.FFIType.typeInfoMap.put((object) Short.TYPE, (object) Structure.FFIType.FFITypes.access\u00241400());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Short>.Value, (object) Structure.FFIType.FFITypes.access\u00241400());
        Pointer pointer = Native.__\u003C\u003EWCHAR_SIZE != 2 ? Structure.FFIType.FFITypes.access\u00241600() : Structure.FFIType.FFITypes.access\u00241500();
        Structure.FFIType.typeInfoMap.put((object) Character.TYPE, (object) pointer);
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Character>.Value, (object) pointer);
        Structure.FFIType.typeInfoMap.put((object) Byte.TYPE, (object) Structure.FFIType.FFITypes.access\u00241700());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Byte>.Value, (object) Structure.FFIType.FFITypes.access\u00241700());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Pointer>.Value, (object) Structure.FFIType.FFITypes.access\u00241800());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<String>.Value, (object) Structure.FFIType.FFITypes.access\u00241800());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<WString>.Value, (object) Structure.FFIType.FFITypes.access\u00241800());
        Structure.FFIType.typeInfoMap.put((object) Boolean.TYPE, (object) Structure.FFIType.FFITypes.access\u00241600());
        Structure.FFIType.typeInfoMap.put((object) ClassLiteral<Boolean>.Value, (object) Structure.FFIType.FFITypes.access\u00241600());
      }

      [InnerClass]
      internal class FFITypes : Object
      {
        private static Pointer ffi_type_void;
        private static Pointer ffi_type_float;
        private static Pointer ffi_type_double;
        private static Pointer ffi_type_longdouble;
        private static Pointer ffi_type_uint8;
        private static Pointer ffi_type_sint8;
        private static Pointer ffi_type_uint16;
        private static Pointer ffi_type_sint16;
        private static Pointer ffi_type_uint32;
        private static Pointer ffi_type_sint32;
        private static Pointer ffi_type_uint64;
        private static Pointer ffi_type_sint64;
        private static Pointer ffi_type_pointer;

        [LineNumberTable(1883)]
        [MethodImpl(MethodImplOptions.NoInlining)]
        private FFITypes()
        {
        }

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u0024900() => Structure.FFIType.FFITypes.ffi_type_void;

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u00241000() => Structure.FFIType.FFITypes.ffi_type_float;

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u00241100() => Structure.FFIType.FFITypes.ffi_type_double;

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u00241200() => Structure.FFIType.FFITypes.ffi_type_sint64;

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u00241300() => Structure.FFIType.FFITypes.ffi_type_sint32;

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u00241400() => Structure.FFIType.FFITypes.ffi_type_sint16;

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u00241500() => Structure.FFIType.FFITypes.ffi_type_uint16;

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u00241600() => Structure.FFIType.FFITypes.ffi_type_uint32;

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u00241700() => Structure.FFIType.FFITypes.ffi_type_sint8;

        [Modifiers]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static Pointer access\u00241800() => Structure.FFIType.FFITypes.ffi_type_pointer;
      }
    }

    [InnerClass]
    internal class LayoutInfo : Object
    {
      private int size;
      private int alignment;
      [Modifiers]
      [Signature("Ljava/util/Map<Ljava/lang/String;Lcom/sun/jna/Structure$StructField;>;")]
      private Map fields;
      private int alignType;
      private TypeMapper typeMapper;
      private bool variable;
      private Structure.StructField typeInfoField;

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool access\u0024000([In] Structure.LayoutInfo obj0) => obj0.variable;

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024100([In] Structure.LayoutInfo obj0) => obj0.size;

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024200([In] Structure.LayoutInfo obj0) => obj0.alignType;

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static TypeMapper access\u0024300([In] Structure.LayoutInfo obj0) => obj0.typeMapper;

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024400([In] Structure.LayoutInfo obj0) => obj0.alignment;

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static Map access\u0024500([In] Structure.LayoutInfo obj0) => obj0.fields;

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal LayoutInfo([In] Structure.\u0031 obj0)
        : this()
      {
      }

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024202([In] Structure.LayoutInfo obj0, [In] int obj1)
      {
        Structure.LayoutInfo layoutInfo1 = obj0;
        int num1 = obj1;
        Structure.LayoutInfo layoutInfo2 = layoutInfo1;
        int num2 = num1;
        layoutInfo2.alignType = num1;
        return num2;
      }

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static TypeMapper access\u0024302(
        [In] Structure.LayoutInfo obj0,
        [In] TypeMapper obj1)
      {
        Structure.LayoutInfo layoutInfo1 = obj0;
        TypeMapper typeMapper1 = obj1;
        Structure.LayoutInfo layoutInfo2 = layoutInfo1;
        TypeMapper typeMapper2 = typeMapper1;
        layoutInfo2.typeMapper = typeMapper1;
        return typeMapper2;
      }

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static bool access\u0024002([In] Structure.LayoutInfo obj0, [In] bool obj1)
      {
        int num1 = obj1 ? 1 : 0;
        Structure.LayoutInfo layoutInfo1 = obj0;
        int num2 = num1;
        Structure.LayoutInfo layoutInfo2 = layoutInfo1;
        int num3 = num2;
        layoutInfo2.variable = num2 != 0;
        return num3 != 0;
      }

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024402([In] Structure.LayoutInfo obj0, [In] int obj1)
      {
        Structure.LayoutInfo layoutInfo1 = obj0;
        int num1 = obj1;
        Structure.LayoutInfo layoutInfo2 = layoutInfo1;
        int num2 = num1;
        layoutInfo2.alignment = num1;
        return num2;
      }

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static Structure.StructField access\u0024700([In] Structure.LayoutInfo obj0) => obj0.typeInfoField;

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static Structure.StructField access\u0024702(
        [In] Structure.LayoutInfo obj0,
        [In] Structure.StructField obj1)
      {
        Structure.LayoutInfo layoutInfo1 = obj0;
        Structure.StructField structField1 = obj1;
        Structure.LayoutInfo layoutInfo2 = layoutInfo1;
        Structure.StructField structField2 = structField1;
        layoutInfo2.typeInfoField = structField1;
        return structField2;
      }

      [Modifiers]
      [LineNumberTable(1125)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal static int access\u0024102([In] Structure.LayoutInfo obj0, [In] int obj1)
      {
        Structure.LayoutInfo layoutInfo1 = obj0;
        int num1 = obj1;
        Structure.LayoutInfo layoutInfo2 = layoutInfo1;
        int num2 = num1;
        layoutInfo2.size = num1;
        return num2;
      }

      [LineNumberTable(new byte[] {163, 243, 104, 103, 103, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private LayoutInfo()
      {
        Structure.LayoutInfo layoutInfo = this;
        this.size = -1;
        this.alignment = 1;
        this.fields = java.util.Collections.synchronizedMap((Map) new LinkedHashMap());
        this.alignType = 0;
      }
    }

    [InnerClass]
    public class StructField : Object
    {
      public string name;
      [Signature("Ljava/lang/Class<*>;")]
      public Class type;
      public Field field;
      public int size;
      public int offset;
      public bool isVolatile;
      public bool isReadOnly;
      public FromNativeConverter readConverter;
      public ToNativeConverter writeConverter;
      public FromNativeContext context;

      [LineNumberTable(new byte[] {166, 200, 200, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      protected internal StructField()
      {
        Structure.StructField structField = this;
        this.size = -1;
        this.offset = -1;
      }

      [LineNumberTable(1863)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual string toString() => new StringBuilder().append(this.name).append("@").append(this.offset).append("[").append(this.size).append("] (").append((object) this.type).append(")").toString();
    }

    [Signature("Ljava/util/AbstractCollection<Lcom/sun/jna/Structure;>;Ljava/util/Set<Lcom/sun/jna/Structure;>;")]
    [Implements(new string[] {"java.util.Set"})]
    internal class StructureSet : AbstractCollection, Set, Collection, Iterable, IEnumerable
    {
      internal Structure[] elements;
      private int count;

      [LineNumberTable(473)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal StructureSet()
      {
      }

      [LineNumberTable(new byte[] {161, 134, 107, 105, 106, 115, 110, 114, 226, 58, 233, 73})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int indexOf([In] Structure obj0)
      {
        for (int index = 0; index < this.count; ++index)
        {
          Structure element = this.elements[index];
          if (object.ReferenceEquals((object) obj0, (object) element) || object.ReferenceEquals((object) ((object) obj0).GetType(), (object) ((object) element).GetType()) && obj0.size() == element.size() && obj0.getPointer().equals((object) element.getPointer()))
            return index;
        }
        return -1;
      }

      [LineNumberTable(493)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool contains([In] object obj0) => this.indexOf((Structure) obj0) != -1;

      [LineNumberTable(new byte[] {161, 107, 104, 146, 106, 107, 117, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void ensureCapacity([In] int obj0)
      {
        if (this.elements == null)
        {
          this.elements = new Structure[obj0 * 3 / 2];
        }
        else
        {
          if (this.elements.Length >= obj0)
            return;
          Structure[] structureArray = new Structure[obj0 * 3 / 2];
          ByteCodeHelper.arraycopy((object) this.elements, 0, (object) structureArray, 0, this.elements.Length);
          this.elements = structureArray;
        }
      }

      [LineNumberTable(new byte[] {161, 127, 105, 110, 155})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool add([In] Structure obj0)
      {
        if (!this.contains((object) obj0))
        {
          this.ensureCapacity(this.count + 1);
          Structure[] elements = this.elements;
          Structure.StructureSet structureSet1 = this;
          int count = structureSet1.count;
          Structure.StructureSet structureSet2 = structureSet1;
          int index = count;
          structureSet2.count = count + 1;
          Structure structure = obj0;
          elements[index] = structure;
        }
        return true;
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Structure[] getElements() => this.elements;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int size() => this.count;

      [LineNumberTable(new byte[] {161, 147, 109, 100, 118, 117, 142, 130})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool remove([In] object obj0)
      {
        int index = this.indexOf((Structure) obj0);
        if (index == -1)
          return false;
        Structure.StructureSet structureSet1 = this;
        int num1 = structureSet1.count - 1;
        Structure.StructureSet structureSet2 = structureSet1;
        int num2 = num1;
        structureSet2.count = num1;
        if (num2 >= 0)
        {
          this.elements[index] = this.elements[this.count];
          this.elements[this.count] = (Structure) null;
        }
        return true;
      }

      [Signature("()Ljava/util/Iterator<Lcom/sun/jna/Structure;>;")]
      [LineNumberTable(new byte[] {161, 162, 108, 105, 148})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual Iterator iterator()
      {
        Structure[] structureArray = new Structure[this.count];
        if (this.count > 0)
          ByteCodeHelper.arraycopy((object) this.elements, 0, (object) structureArray, 0, this.count);
        return Arrays.asList((object[]) structureArray).iterator();
      }

      [Modifiers]
      [LineNumberTable(473)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool add([In] object obj0) => this.add((Structure) obj0);

      [HideFromJava]
      [SpecialName]
      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) new IterableEnumerator((Iterable) this);

      bool Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003AisEmpty() => this.isEmpty();

      object[] Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003AtoArray() => this.toArray();

      object[] Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003AtoArray(
        [In] object[] obj0)
      {
        return this.toArray(obj0);
      }

      bool Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003AcontainsAll(
        [In] Collection obj0)
      {
        return this.containsAll(obj0);
      }

      bool Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003AaddAll(
        [In] Collection obj0)
      {
        return this.addAll(obj0);
      }

      bool Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003AretainAll(
        [In] Collection obj0)
      {
        return this.retainAll(obj0);
      }

      bool Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003AremoveAll(
        [In] Collection obj0)
      {
        return this.removeAll(obj0);
      }

      void Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003Aclear() => this.clear();

      bool Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003Aequals([In] object obj0) => Object.instancehelper_equals((object) this, obj0);

      int Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003AhashCode() => Object.instancehelper_hashCode((object) this);

      Spliterator Set.__\u003Coverridestub\u003Ejava\u002Eutil\u002ESet\u003A\u003Aspliterator() => this.spliterator();

      object[] Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AtoArray(
        [In] object[] obj0)
      {
        return this.toArray(obj0);
      }

      Spliterator Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003Aspliterator() => this.spliterator();

      bool Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AisEmpty() => this.isEmpty();

      object[] Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AtoArray() => this.toArray();

      bool Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AcontainsAll(
        [In] Collection obj0)
      {
        return this.containsAll(obj0);
      }

      bool Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AaddAll(
        [In] Collection obj0)
      {
        return this.addAll(obj0);
      }

      bool Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AremoveAll(
        [In] Collection obj0)
      {
        return this.removeAll(obj0);
      }

      bool Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AremoveIf(
        [In] Predicate obj0)
      {
        return this.removeIf(obj0);
      }

      bool Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AretainAll(
        [In] Collection obj0)
      {
        return this.retainAll(obj0);
      }

      void Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003Aclear() => this.clear();

      bool Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003Aequals(
        [In] object obj0)
      {
        return Object.instancehelper_equals((object) this, obj0);
      }

      int Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AhashCode() => Object.instancehelper_hashCode((object) this);

      Stream Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003Astream() => this.stream();

      Stream Collection.__\u003Coverridestub\u003Ejava\u002Eutil\u002ECollection\u003A\u003AparallelStream() => this.parallelStream();

      void Iterable.__\u003Coverridestub\u003Ejava\u002Elang\u002EIterable\u003A\u003AforEach(
        [In] Consumer obj0)
      {
        this.forEach(obj0);
      }

      Spliterator Iterable.__\u003Coverridestub\u003Ejava\u002Elang\u002EIterable\u003A\u003Aspliterator() => this.spliterator();
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
