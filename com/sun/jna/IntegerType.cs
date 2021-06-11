// Decompiled with JetBrains decompiler
// Type: com.sun.jna.IntegerType
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace com.sun.jna
{
  [Implements(new string[] {"com.sun.jna.NativeMapped"})]
  public abstract class IntegerType : Number, NativeMapped
  {
    private const long serialVersionUID = 1;
    private int size;
    private Number number;
    private bool unsigned;
    private long value;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long longValue() => this.value;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int intValue() => (int) this.value;

    [LineNumberTable(new byte[] {159, 126, 66, 104, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntegerType(int size, long value, bool unsigned)
    {
      int num = unsigned ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      IntegerType integerType = this;
      this.size = size;
      this.unsigned = num != 0;
      this.setValue(value);
    }

    [LineNumberTable(new byte[] {24, 98, 103, 159, 19, 118, 101, 110, 133, 118, 101, 110, 130, 118, 100, 109, 130, 108, 130, 159, 11, 108, 117, 149, 112, 127, 11, 186})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setValue(long value)
    {
      long num1 = value;
      this.value = value;
      switch (this.size)
      {
        case 1:
          if (this.unsigned)
            this.value = value & (long) byte.MaxValue;
          num1 = (long) (sbyte) (int) value;
          this.number = (Number) Byte.valueOf((byte) (int) value);
          break;
        case 2:
          if (this.unsigned)
            this.value = value & (long) ushort.MaxValue;
          num1 = (long) (short) (int) value;
          this.number = (Number) Short.valueOf((short) (int) value);
          break;
        case 4:
          if (this.unsigned)
            this.value = value & (long) uint.MaxValue;
          num1 = (long) (int) value;
          this.number = (Number) Integer.valueOf((int) value);
          break;
        case 8:
          this.number = (Number) Long.valueOf(value);
          break;
        default:
          string str1 = new StringBuilder().append("Unsupported size: ").append(this.size).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str1);
      }
      if (this.size >= 8)
        return;
      long num2 = (1L << this.size * 8) - 1L ^ -1L;
      if (value < 0L && num1 != value || value >= 0L && (num2 & value) != 0L)
      {
        string str2 = new StringBuilder().append("Argument value 0x").append(Long.toHexString(value)).append(" exceeds native capacity (").append(this.size).append(" bytes) mask=0x").append(Long.toHexString(num2)).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str2);
      }
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int compare(long v1, long v2)
    {
      if (v1 == v2)
        return 0;
      return v1 < v2 ? -1 : 1;
    }

    [LineNumberTable(new byte[] {0, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntegerType(int size)
      : this(size, 0L, false)
    {
    }

    [LineNumberTable(new byte[] {159, 129, 162, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntegerType(int size, bool unsigned)
    {
      int num = unsigned ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(size, 0L, num != 0);
    }

    [LineNumberTable(new byte[] {10, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IntegerType(int size, long value)
      : this(size, value, false)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object toNative() => (object) this.number;

    [LineNumberTable(new byte[] {67, 109, 134, 118, 103, 149, 97, 112, 154, 97, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object fromNative(object nativeValue, FromNativeContext context)
    {
      long num = nativeValue != null ? ((Number) nativeValue).longValue() : 0L;
      IntegerType integerType1;
      try
      {
        try
        {
          IntegerType integerType2 = (IntegerType) Object.instancehelper_getClass((object) this).newInstance(IntegerType.__\u003CGetCallerID\u003E());
          integerType2.setValue(num);
          integerType1 = integerType2;
        }
        catch (InstantiationException ex)
        {
          goto label_5;
        }
      }
      catch (IllegalAccessException ex)
      {
        goto label_6;
      }
      return (object) integerType1;
label_5:
      string str1 = new StringBuilder().append("Can't instantiate ").append((object) Object.instancehelper_getClass((object) this)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str1);
label_6:
      string str2 = new StringBuilder().append("Not allowed to instantiate ").append((object) Object.instancehelper_getClass((object) this)).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str2);
    }

    [Signature("()Ljava/lang/Class<*>;")]
    [LineNumberTable(136)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Class nativeType() => Object.instancehelper_getClass((object) this.number);

    [LineNumberTable(151)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float floatValue() => this.number.floatValue();

    [LineNumberTable(156)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual double doubleValue() => this.number.doubleValue();

    [LineNumberTable(new byte[] {111, 121, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object rhs) => rhs is IntegerType && Object.instancehelper_equals((object) this.number, (object) ((IntegerType) rhs).number);

    [LineNumberTable(167)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => Object.instancehelper_toString((object) this.number);

    [LineNumberTable(172)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => Object.instancehelper_hashCode((object) this.number);

    [Signature("<T:Lcom/sun/jna/IntegerType;>(TT;TT;)I")]
    [LineNumberTable(new byte[] {160, 76, 105, 98, 99, 98, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int compare(IntegerType v1, IntegerType v2)
    {
      if (object.ReferenceEquals((object) v1, (object) v2))
        return 0;
      if (v1 == null)
        return 1;
      return v2 == null ? -1 : IntegerType.compare(v1.longValue(), v2.longValue());
    }

    [LineNumberTable(new byte[] {160, 99, 99, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int compare(IntegerType v1, long v2) => v1 == null ? 1 : IntegerType.compare(v1.longValue(), v2);

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (IntegerType.__\u003CcallerID\u003E == null)
        IntegerType.__\u003CcallerID\u003E = (CallerID) new IntegerType.__\u003CCallerID\u003E();
      return IntegerType.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
